using Hangfire;

public class BackgroundJobService
{
    private readonly IConfiguration _configuration;

    public BackgroundJobService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void MassUpdateIdPosition()
    {
        try {
            var token = GetAccessToken();
            if (string.IsNullOrEmpty(token))
                return;

            var idamanUsers = GetAllUsersFromIdaman(token);

            var dbName = _configuration["Databases:DB:dbname"] ?? "";
            var user = _configuration["Databases:DB:username"] ?? "";
            var pass = _configuration["Databases:DB:password"] ?? "";
            var baseConn = _configuration["Databases:DB:connectionstring"];
            if (string.IsNullOrEmpty(baseConn))
            {
                throw new Exception("Database connection string not found in configuration.");
            }

            string connectionString = baseConn
                .Replace("{dbname}", dbName)
                .Replace("{uid}", user)
                .Replace("{pwd}", pass);

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var masterUsers = GetAllMasterUsers(conn);

                BuildLookups(masterUsers, out var byIdIdaman, out var byEmail);

                int updated = 0;
                int skipped = 0;

                foreach (var idaman in idamanUsers)
                {
                    if (idaman == null)
                        continue;

                    MasterUserDto? masterUser = null;

                    if (!string.IsNullOrEmpty(idaman.id) && byIdIdaman.TryGetValue(idaman.id, out var byId))
                    {
                        masterUser = byId;
                    }
                    else if (!string.IsNullOrEmpty(idaman.email) && byEmail.TryGetValue(idaman.email.ToLower(), out var byMail))
                    {
                        masterUser = byMail;
                    }

                    if (masterUser == null)
                    {
                        skipped++;
                        continue;
                    }

                    int newIdPosition = 11111111;

                    var posIdStr = idaman.position?.id;
                    if (!string.IsNullOrEmpty(posIdStr) &&
                        int.TryParse(posIdStr, out var parsed))
                    {
                        newIdPosition = parsed;
                    }

                    string posName = string.IsNullOrWhiteSpace(idaman.position?.name)
                        ? "GUEST"
                        : idaman.position.name.Trim();

                    UpdateUserIdPosition(conn, masterUser.IdUser, newIdPosition, posName);
                    updated++;
                }

                Console.WriteLine(
                    $"MassUpdateIdPosition done. Updated={updated}, Skipped={skipped}"
                );
            }
        }
        catch(Exception e) 
        {
            Console.WriteLine(e);
        }
    }

    private static void UpdateUserIdPosition(SqlConnection conn, int idUser, int newIdPosition, string posName)
    {
        using var cmd = new SqlCommand(@"
            IF NOT EXISTS (
                SELECT 1 
                FROM MasterPosition 
                WHERE IdPosition = @IdPosition
            )
            BEGIN
                INSERT INTO MasterPosition (IdPosition, NamaPosition, UserLevel, Role)
                VALUES (@IdPosition, @posName, 8, -1);
            END

            UPDATE MU
            SET 
                MU.IdPosition = MP.IdPosition,
                MU.UserLevel = MP.UserLevel,
                MU.[Rule] = MP.Role,
                MU.DiperbaruiOleh = @Oleh,
                MU.TanggalDiperbarui = @Tanggal
            FROM MasterUser MU
            JOIN MasterPosition MP 
                ON MP.IdPosition = @IdPosition
            WHERE MU.IdUser = @IdUser;
        ", conn);

        cmd.Parameters.AddWithValue("@IdUser", idUser);
        cmd.Parameters.AddWithValue("@IdPosition", newIdPosition);
        cmd.Parameters.AddWithValue("@posName", posName);
        cmd.Parameters.AddWithValue("@Oleh", "SYSTEM_HANGFIRE");
        cmd.Parameters.AddWithValue("@Tanggal", GetWibNow());

        cmd.ExecuteNonQuery();
    }

    private static List<MasterUserDto> GetAllMasterUsers(SqlConnection conn)
    {
        var result = new List<MasterUserDto>();

        // Sinkronisasi exception
        var todayWib = GetWibNow().Date;

        using (var updateCmd = new SqlCommand(@"
            UPDATE mu
            SET mu.IdPosition = sp.PosisiPJS,
                mu.Rule = mp.Role,
                mu.UserLevel = mp.UserLevel,
                mu.[exception] = 1
            FROM MasterUser mu
            INNER JOIN SetPJS sp 
                ON mu.IdUser = sp.DibuatOleh
            INNER JOIN MasterPosition mp
                ON sp.PosisiPJS = mp.IdPosition
            WHERE ISNULL(mu.exception, 0) <> 1
            AND sp.TanggalMulai <= @Today
            AND sp.TanggalSelesai >= @Today
        ", conn))
        {
            updateCmd.Parameters.Add("@Today", SqlDbType.Date).Value = todayWib;
            updateCmd.ExecuteNonQuery();
        }

        using (var updateCmd = new SqlCommand(@"
            UPDATE mu
            SET mu.IdPosition = sp.PosisiAwal,
                mu.Rule = mp.Role,
                mu.UserLevel = mp.UserLevel,
                mu.[exception] = 0
            FROM MasterUser mu
            INNER JOIN SetPJS sp 
                ON mu.IdUser = sp.DibuatOleh
            INNER JOIN MasterPosition mp
                ON sp.PosisiAwal = mp.IdPosition
            WHERE mu.[exception] = 1
            AND sp.TanggalSelesai < @Today
        ", conn))
        {
            updateCmd.Parameters.Add("@Today", SqlDbType.Date).Value = todayWib;
            updateCmd.ExecuteNonQuery();
        }

        // Ambil user yang exception = 0
        using var cmd = new SqlCommand(@"
            SELECT IdUser, IdIdaman, Email, IdPosition
            FROM MasterUser 
            WHERE ISNULL(exception, 0) <> 1;
        ", conn);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new MasterUserDto
            {
                IdUser = reader.GetInt32(reader.GetOrdinal("IdUser")),
                IdIdaman = reader.IsDBNull(reader.GetOrdinal("IdIdaman"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("IdIdaman")),
                Email = reader.IsDBNull(reader.GetOrdinal("Email"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("Email")),
                IdPosition = reader.IsDBNull(reader.GetOrdinal("IdPosition"))
                    ? (int?)null
                    : reader.GetInt32(reader.GetOrdinal("IdPosition"))
            });
        }

        return result;
    }

    private static void BuildLookups(
        List<MasterUserDto> users,
        out Dictionary<string, MasterUserDto> byIdIdaman,
        out Dictionary<string, MasterUserDto> byEmail)
    {
        byIdIdaman = users
            .Where(u => !string.IsNullOrEmpty(u.IdIdaman))
            .GroupBy(u => u.IdIdaman!)
            .ToDictionary(g => g.Key, g => g.First());

        byEmail = users
            .Where(u => !string.IsNullOrEmpty(u.Email))
            .GroupBy(u => u.Email!.ToLower())
            .ToDictionary(g => g.Key, g => g.First());
    }

    private static List<IdamanPositionItem> GetAllUsersFromIdaman(string token)
    {
        using var httpClient = new HttpClient();

        var allUsers = new List<IdamanPositionItem>();

        string? nextUrl =
            $"{IdamanApiUrls.RestBaseUrl}/v1/users?SearchText=2222";

        int page = 0;

        while (!string.IsNullOrEmpty(nextUrl))
        {
            page++;

            var request = new HttpRequestMessage(HttpMethod.Get, nextUrl);
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = httpClient.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            var pageResult = System.Text.Json.JsonSerializer.Deserialize<IdamanPositionsResponse>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (pageResult?.value == null || pageResult.value.Count == 0)
            {
                Console.WriteLine($"Page {page}: no data, stop");
                break;
            }

            allUsers.AddRange(pageResult.value);

            Console.WriteLine(
                $"Page {page}: fetched {pageResult.value.Count} users, total collected {allUsers.Count}"
            );

            nextUrl = pageResult.next;

            if (string.IsNullOrEmpty(nextUrl))
            {
                Console.WriteLine("No next page, finished pagination");
                break;
            }
        }

        Console.WriteLine($"Completed. Get {allUsers.Count} users");
        return allUsers;
    }

    private static string GetAccessToken()
    {
        using var httpClient = new HttpClient();

        var tokenRequest = new HttpRequestMessage(
            HttpMethod.Post,
            $"{IdamanApiUrls.LoginBaseUrl}/connect/token"
        )
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", IdamanApiUrls.ClientId },
                { "client_secret", IdamanApiUrls.ClientSecret },
                { "scope", IdamanApiUrls.Scope },
                { "grant_type", IdamanApiUrls.GrantType }
            })
        };

        var response = httpClient.SendAsync(tokenRequest).Result;
        var json = response.Content.ReadAsStringAsync().Result;

        var tokenData = System.Text.Json.JsonSerializer.Deserialize<TokenResponse>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        return tokenData?.access_token ?? "";
    }

    private static DateTime GetWibNow()
    {
        var wib = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, wib);
    }
}
