public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/mwtChatHub"))
        {
            await _next(context);
            return;
        }
        var traceId = context.TraceIdentifier;
        bool isApiRequest = context.Request.Path.ToString().Contains("/api/", StringComparison.OrdinalIgnoreCase);

        try
        {
            await _next(context);
        }
        catch (LogErrorException ex)
        {
            _logger.LogError(ex, $"{traceId} - An error occurred: ", ex.Message);

            await LogExceptionToDatabase(context, ex);

            if (isApiRequest && !context.Response.HasStarted)
            {
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = "application/json";

                var response = new ErrorResponseVm
                {
                    TraceId = traceId,
                    Message = ex.StatusCode >= 500 ? "Terjadi kesalahan, hubungi Administrator untuk bantuan." : ex.Message,
                    StatusCode = ex.StatusCode
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{traceId} - An unhandled exception occurred: ", ex.Message);

            await LogExceptionToDatabase(context, null, ex);

            if (isApiRequest && !context.Response.HasStarted)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new ErrorResponseVm
                {
                    TraceId = traceId,
                    Message = "Terjadi kesalahan, hubungi Administrator untuk bantuan.",
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            else if (context.Response.HasStarted)
            {
                // Log saja jika response sudah dimulai
                _logger.LogWarning($"{traceId} - Cannot write error response, response has already started");
            }
        }
    }

    private async Task LogExceptionToDatabase(HttpContext context, LogErrorException? logEx,
        Exception? generalEx = null)
    {
            var userName = logEx?.Username
                           ?? context.User?.FindFirst(ClaimTypes.Name)?.Value
                           ?? context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                           ?? context.User?.FindFirst("name")?.Value
                           ?? context.User?.FindFirst("sub")?.Value
                           ?? context.User?.FindFirst("UserName")?.Value
                           ?? context.User?.FindFirst("username")?.Value
                           ?? context.User?.Identity?.Name
                           ?? "Anonymous";

            _logger.LogInformation("Resolved username: {UserName}", userName);

            string? noReferensi = logEx?.NoReferensi;
            int? idProses = logEx?.IdProses;
            int? idAktivitas = logEx?.IdAktivitas;

            // Try to extract from query string
            if (string.IsNullOrEmpty(noReferensi))
                noReferensi = context.Request.Query["NoReferensi"].FirstOrDefault() ??
                              context.Request.Query["noReferensi"].FirstOrDefault() ??
                              context.Request.Query["no_Referensi"].FirstOrDefault();

            if (!idProses.HasValue &&
                int.TryParse(
                    context.Request.Query["IdProses"].FirstOrDefault() ??
                    context.Request.Query["idProses"].FirstOrDefault() ??
                    context.Request.Query["id_Proses"].FirstOrDefault(), out int parsedIdProses))
                idProses = parsedIdProses;

            if (!idAktivitas.HasValue &&
                int.TryParse(
                    context.Request.Query["IdAktivitas"].FirstOrDefault() ??
                    context.Request.Query["idAktivitas"].FirstOrDefault() ??
                    context.Request.Query["id_Aktivitas"].FirstOrDefault(), out int parsedIdAktivitas))
                idAktivitas = parsedIdAktivitas;

            // Try to extract from request body
            if (context.Request.ContentType?.Contains("application/json") == true && context.Request.Body.CanSeek)
            {
                context.Request.Body.Position = 0;
                using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
                var requestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    try
                    {
                        var jsonDoc = JsonDocument.Parse(requestBody);

                        if (string.IsNullOrEmpty(noReferensi) &&
                            jsonDoc.RootElement.TryGetProperty("NoReferensi", out var noRefProp))
                            noReferensi = noRefProp.GetString();
                        if (string.IsNullOrEmpty(noReferensi) &&
                            jsonDoc.RootElement.TryGetProperty("noReferensi", out var noRefPropLower))
                            noReferensi = noRefPropLower.GetString();
                        if (string.IsNullOrEmpty(noReferensi) &&
                            jsonDoc.RootElement.TryGetProperty("No_Referensi", out var noRefProp_))
                            noReferensi = noRefProp_.GetString();
                        if (string.IsNullOrEmpty(noReferensi) &&
                            jsonDoc.RootElement.TryGetProperty("no_Referensi", out var noRefPropLower_))
                            noReferensi = noRefPropLower_.GetString();

                        if (!idProses.HasValue &&
                            jsonDoc.RootElement.TryGetProperty("IdProses", out var idProsesProp) &&
                            idProsesProp.TryGetInt32(out int idProsesValue))
                            idProses = idProsesValue;
                        if (!idProses.HasValue &&
                            jsonDoc.RootElement.TryGetProperty("idProses", out var idProsesPropLower) &&
                            idProsesPropLower.TryGetInt32(out int idProsesValueLower))
                            idProses = idProsesValueLower;
                        if (!idProses.HasValue &&
                            jsonDoc.RootElement.TryGetProperty("Id_Proses", out var idProsesProp_) &&
                            idProsesProp_.TryGetInt32(out int idProsesValue_))
                            idProses = idProsesValue_;
                        if (!idProses.HasValue &&
                            jsonDoc.RootElement.TryGetProperty("id_Proses", out var idProsesPropLower_) &&
                            idProsesPropLower_.TryGetInt32(out int idProsesValueLower_))
                            idProses = idProsesValueLower_;

                        if (!idAktivitas.HasValue &&
                            jsonDoc.RootElement.TryGetProperty("IdAktivitas", out var idAktivitasProp) &&
                            idAktivitasProp.TryGetInt32(out int idAktivitasValue))
                            idAktivitas = idAktivitasValue;
                        if (!idAktivitas.HasValue &&
                            jsonDoc.RootElement.TryGetProperty("idAktivitas", out var idAktivitasPropLower) &&
                            idAktivitasPropLower.TryGetInt32(out int idAktivitasValueLower))
                            idAktivitas = idAktivitasValueLower;
                        if (!idAktivitas.HasValue &&
                            jsonDoc.RootElement.TryGetProperty("IdAktivitas", out var idAktivitasProp_) &&
                            idAktivitasProp_.TryGetInt32(out int idAktivitasValue_))
                            idAktivitas = idAktivitasValue_;
                        if (!idAktivitas.HasValue &&
                            jsonDoc.RootElement.TryGetProperty("idAktivitas", out var idAktivitasPropLower_) &&
                            idAktivitasPropLower_.TryGetInt32(out int idAktivitasValueLower_))
                            idAktivitas = idAktivitasValueLower_;
                    }
                    catch
                    {
                        /* Ignore JSON parsing errors */
                    }
                }
            }

            var errorMessage = logEx?.Message ?? generalEx?.Message ?? "Unknown error";

            if (errorMessage.Length > 255)
                errorMessage = errorMessage.Substring(0, 252) + "...";

            using (var conn = GetConnection("Db").OpenConnection())
            {
                using (var cmd = new SqlCommand(
                           @"INSERT INTO dbo.Log_Error (NoReferensi, IdProses, IdAktivitas, UserName, ErrorMessage)
                      VALUES (@NoReferensi, @IdProses, @IdAktivitas, @UserName, @ErrorMessage)", conn))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", (object?)noReferensi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdProses", (object?)idProses ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdAktivitas", (object?)idAktivitas ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserName", (object?)userName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ErrorMessage", errorMessage);

                    await cmd.ExecuteNonQueryAsync();

                    _logger.LogInformation("API error saved to database - User: {UserName}, Error: {ErrorMessage}",
                        userName, errorMessage);
                }
            }
    }


    public class ErrorResponseVm
    {
        public string TraceId { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
