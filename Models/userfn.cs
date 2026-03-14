namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// Global events
    /// </summary>

    // ContentType Mapping event
    public static void ContentTypeMapping(IDictionary<string, string> mappings) {
        // Example:
        //mappings[".image"] = "image/png"; // Add new mappings
        //mappings[".rtf"] = "application/x-msdownload"; // Replace an existing mapping
        //mappings.Remove(".mp4"); // Remove MP4 videos
    }

    // Class Init event
    public static void ClassInit() {
        // Enter your code here
    }

    // Page Loading event
    public static void PageLoading() {
        // C# 
        if (!User.Identity.IsAuthenticated && !Request.Path.Value.ToLower().Contains("/login"))
        {
            Response.Redirect("login");
        }
    }

    // Page Rendering event
    public static void PageRendering() {
        //Log("Page Rendering");
    }

    // Page Unloaded event
    public static void PageUnloaded() {
        // Enter your code here
    }

    // Personal Data Downloading event
    public static void PersonalDataDownloading(Dictionary<string, object> row) {
        //Log("PersonalData Downloading");
    }

    // Personal Data Deleted event
    public static void PersonalDataDeleted(Dictionary<string, object> row) {
        //Log("PersonalData Deleted");
    }

    // AuditTrail Inserting event
    public static bool AuditTrailInserting(Dictionary<string, object> rsnew) {
        return true;
    }

    // Chart Rendered event
    public static void ChartRendered(IChartRenderer renderer) {
        // Example:
        //var data = renderer.Data;
        //var options = renderer.Options;
        //DbChart chart = renderer.Chart;
        //if (chart.ID == "<Report>_<Chart>") { // Check chart ID
        //}
    }

    // One Time Password Sending event
    public static bool OtpSending(string user, dynamic client) {
        // Example:
        // Log(user, client); // View user and client (Email or SMS object)
        // if (SameText(Config.TwoFactorAuthenticationType, "email")) { // Possible values: email or SMS
        //     client.Content = ...; // Change content
        //     client.Recipient = ...; // Change recipient
        //     // return false; // Return false to cancel
        // }
        return true;
    }

    // Routes Add event
    public static void RouteAction(IEndpointRouteBuilder app) {
        // Example:
        // app.MapGet("/", () => "Hello World!");
    }

    // Services Add event
    public static void ServiceAdd(IServiceCollection services) {
        // Example:
        // services.AddSignalR();
    }

    // Container Build event
    public static void ContainerBuild(ContainerBuilder builder) {
        // Enter your code here
    }

    // App Build event
    public static void AppBuild(WebApplicationBuilder builder) {
        var idamanConfiguration = new Dictionary<string, string?>
        {
            { "Idaman:UrlLogin", IdamanApiUrls.LoginBaseUrl },
            { "Idaman:UrlApi", IdamanApiUrls.RestBaseUrl },
            { "Idaman:ClientId", IdamanApiUrls.ClientId },
            { "Idaman:ClientSecret", IdamanApiUrls.ClientSecret },
            { "Idaman:Scopes", "api.auth, user.read, user.readAll" }
        };
        builder.Configuration.AddInMemoryCollection(idamanConfiguration);
        builder.Services.AddAuthentication(options => {
            options.DefaultScheme = "oidc";
            options.DefaultChallengeScheme = "oidc";
        }).AddOpenIdConnect("oidc", options => SetOpenIdConnectOptions(options, builder.Configuration));
        builder.Services.AddSingleton(_ =>
        {
            var endpoint = new Uri(builder.Configuration["Face:Endpoint"]!);
            var key = new AzureKeyCredential(builder.Configuration["Face:Key"]!);
            return new FaceClient(endpoint, key);
        });
        builder.Services.AddSingleton(sp =>
        {
            var endpoint = new Uri(builder.Configuration["Face:Endpoint"]!);
            var cred = new AzureKeyCredential(builder.Configuration["Face:Key"]!);
            return new FaceAdministrationClient(endpoint, cred);
        });
        builder.Services.AddSignalR();
    }

    // Global user code
    public static void SetOpenIdConnectOptions(OpenIdConnectOptions options, IConfiguration configuration)
    {
        options.Authority = configuration["Idaman:UrlLogin"];
        options.RequireHttpsMetadata = false;
        options.ClientId = configuration["Idaman:ClientId"];
        options.ClientSecret = configuration["Idaman:ClientSecret"];
        options.ResponseType = "code id_token";
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;

        // Tambahkan scopes
        var scopes = configuration["Idaman:Scopes"].Replace(" ", "").Split(",");
        foreach (var scope in scopes)
        {
            options.Scope.Add(scope);
        }

        // Tambahkan event handler untuk menangani kesalahan
        options.Events = new OpenIdConnectEvents
        {
            OnRemoteFailure = context =>
            {
                Console.WriteLine($"OpenID Connect Error: {context.Failure.Message}");
                context.HandleResponse();
                context.Response.Redirect("/error");
                return Task.CompletedTask;
            }
        };
    }

    public static QueryBuilder QB(DatabaseConnection<SqlConnection, SqlDbType> conn, string tableName, bool useTransaction = false)
    {
        if (conn == null)
            throw new ArgumentNullException(nameof(conn));
        if (string.IsNullOrWhiteSpace(tableName))
            throw new ArgumentException("tableName is required.", nameof(tableName));
        return (QueryBuilder)conn.GetQueryFactory(useTransaction).Query(tableName);
    }

    public class PenyimpananSampleRequest 
    {
        [Required]
        public string JenisSample { get; set; } = default!;

        [Required]
        public int IdPlant { get; set; }

        [Required]
        public DateTime Tanggal { get; set; }

        [Required]
        public string NamaMasterSample { get; set; } = default!;

        public string? NomorSegel { get; set; }

        public List<IFormFile> Foto { get; set; } = new();

        public DateTime? ExpiredEst { get; set; }
    }

    public sealed class PengujianSampleLainnyaRequest 
    {
        public string? idPlant { get; set; }

        public string? Tanggal { get; set; }

        public string? Produk { get; set; }

        public string? Keterangan { get; set; }

        public List<IFormFile>? files { get; set; }
    }

    public static class FileUploadHelper
    {
        public static async Task<string> UploadToAzureBlob(Stream data, string fileName, string path, string contentType)
        {
            string? connectionString = Configuration["AzureBlob:ConnectionString"];
            string? containerName = Configuration["AzureBlob:ContainerName"];
            var originalFileName = Path.GetFileNameWithoutExtension(fileName);
            var extension = Path.GetExtension(fileName);
            var uniqueFileName = $"{originalFileName}_{DateTime.Now:yyyyMMddHHmmssfff}{extension}";
            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
            {
                var blobServiceClient = new BlobServiceClient(connectionString);
                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);
                var blobPath = $"{path}/{uniqueFileName}";
                var blobClient = containerClient.GetBlobClient(blobPath);
                data.Position = 0;
                //await blobClient.UploadAsync(data, new BlobHttpHeaders { ContentType = contentType });
                await blobClient.UploadAsync(data, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = contentType }
                });
                return blobPath;
            }
            string curdir = Directory.GetCurrentDirectory();
            string uploadPath = Path.Combine(curdir, "wwwroot", "Uploads", path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            var filePath = Path.Combine(uploadPath, uniqueFileName);
            data.Position = 0;
            await using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await data.CopyToAsync(fs);
            }
            return uniqueFileName;
        }
    }

    public static async Task<(Stream ZipStream, string FileName)> BuildZipAsync(List<IFormFile> files, string? baseName = null)
    {
        if (files == null || files.Count == 0)
            throw new ArgumentException("File list kosong.");
        var ms = new MemoryStream();
        using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, leaveOpen: true))
        {
            foreach (var f in files.Where(x => x != null && x.Length > 0))
            {
                var safeName = Path.GetFileName(f.FileName); // anti path traversal
                var entry = archive.CreateEntry(safeName, CompressionLevel.Fastest);
                await using var entryStream = entry.Open();
                await using var fileStream = f.OpenReadStream();
                await fileStream.CopyToAsync(entryStream);
            }
        }
        ms.Position = 0;
        string cleanBase;
        if (!string.IsNullOrWhiteSpace(baseName))
        {
            cleanBase = baseName;
        }
        else
        {
            cleanBase = "File";
        }
        cleanBase = cleanBase
            .Replace("/", "-")
            .Replace("\\", "-")
            .Replace(":", "-")
            .Replace("*", "")
            .Replace("?", "")
            .Replace("\"", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("|", "");
        var zipName = $"{cleanBase}_{DateTime.Now:yyyyMMddHHmmssfff}.zip";
        return (ms, zipName);
    }
} // End Partial class
