using ApplicationUser = SnDOne.Models.ApplicationUser;
using Microsoft.AspNetCore.DataProtection;
using Azure.Storage.Blobs;
using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);

Config.JsonFiles.ForEach(file => JsonConfigurationExtensions.AddJsonFile(builder.Configuration, file.Path, file.Optional, file.ReloadOnChange));

Configuration = builder.Configuration;

// if (string.IsNullOrEmpty(Configuration["Databases:DB:connectionstring"]))
// {
//     await ModifyConfiguration();
// }
// async Task ModifyConfiguration()
// {
//     var configDict = new Dictionary<string, string>();
//     var vaultService = new VaultService(
//         Configuration["Vault:url"],
//         Configuration["Vault:client"],
//         Configuration["Vault:sec"],
//         Configuration["Vault:name"]
//     );
//     string token = await vaultService.GetVaultTokenAsync();
//     if (!string.IsNullOrEmpty(token))
//     {
//         string secPath = Configuration["Vault:secPath"];
//         var secretValue = await vaultService.GetAllKeysAsync($"VENUS/data/{secPath}", token);
//         configDict["Jwt:SecretKey"] = secretValue.GetValueOrDefault("SecretKey", "");
//         configDict["Google:Id"] = secretValue.GetValueOrDefault("googleId", "");
//         configDict["Google:Secret"] = secretValue.GetValueOrDefault("googleSecret", "");
//         configDict["Databases:DB:username"] = secretValue.GetValueOrDefault("id", "");
//         configDict["Databases:DB:password"] = secretValue.GetValueOrDefault("pwd", "");
//         string connstr = "Data Source=" + secretValue.GetValueOrDefault("Server", "") + "; Initial Catalog=" + secretValue.GetValueOrDefault("Database", "") + ";User Id={uid};Password={pwd};Persist Security Info=false;MultipleActiveResultSets=true;Pooling=true;Min Pool Size=500;Max Pool Size=1000;TrustServerCertificate=True;";
//         configDict["Databases:DB:connectionstring"] = connstr;
//         builder.Configuration.AddInMemoryCollection(configDict);
//         Configuration = builder.Configuration;
//     }
// }

builder.Logging.AddFile(Configuration.GetSection("Logging"));

builder.WebHost
    .UseUrls("http://localhost:5000", "https://localhost:5001");


bool noCache = !Config.Cache;
builder.Services.AddHttpCacheHeaders(
    (expirationModelOptions) =>
    {
        expirationModelOptions.CacheLocation = noCache ? CacheLocation.Private : CacheLocation.Public;
        expirationModelOptions.NoStore = noCache; // Note: "no-store, max-age=0" disable caching
        expirationModelOptions.MaxAge = noCache ? 0 : 60;
    },
    (validationModelOptions) =>
    {
        validationModelOptions.MustRevalidate = noCache; // Note: "no-cache" and "max-age=0, must-revalidate" have the same meaning
        validationModelOptions.NoCache = noCache;
    });
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddSessionStateTempDataProvider();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserLevel", policy =>
    {
        policy.AuthenticationSchemes.Add(CookieAuthenticationDefaults.AuthenticationScheme); // Cookie
        policy.Requirements.Add(new PermissionRequirement()); // User Level security
    });
    options.AddPolicy("ApiUserLevel", policy =>
    { // API
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme); // JWT
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new PermissionRequirement()); // User Level security
    });
    options.AddPolicy("ApiUserLevelLite", policy =>
    { // API (Skip RequireAuthenticatedUser)
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme); // JWT
        policy.Requirements.Add(new PermissionRequirement()); // User Level security
    });
});


builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

builder.Services.Configure<CookiePolicyOptions>(options => options.CheckConsentNeeded = context => true);

builder.Services.AddMemoryCache();

builder.Services.AddHttpClient();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>();

builder.Services.AddTransient<IUserStore<ApplicationUser>, CustomUserStore>();
builder.Services.AddTransient<IRoleStore<ApplicationRole>, CustomRoleStore>();

builder.Services.AddMvc()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

var blobConnectionString = Configuration["AzureBlob:ConnectionString"];
var containerName = Configuration["AzureBlob:ContainerName"]; // "sndone-docs"

// if (!string.IsNullOrEmpty(blobConnectionString) && !string.IsNullOrEmpty(containerName))
// {
//     try
//     {
//         var blobServiceClient = new BlobServiceClient(blobConnectionString);
//         var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

//         // Pakai path khusus untuk keys: .system/dataprotection/keys.xml
//         var blobClient = containerClient.GetBlobClient(".system/dataprotection/keys.xml");

//         builder.Services.AddDataProtection()
//             .PersistKeysToAzureBlobStorage(blobClient)
//             .SetApplicationName("SnDOne")
//             .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

//         Console.WriteLine("✓ Data Protection configured with Azure Blob Storage (container: " + containerName + ")");
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"✗ Failed to configure Data Protection: {ex.Message}");

//         // Fallback ke file system
//         var keysPath = Path.Combine(builder.Environment.ContentRootPath, "DataProtection-Keys");
//         Directory.CreateDirectory(keysPath);
//         builder.Services.AddDataProtection()
//             .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
//             .SetApplicationName("SnDOne");

//         Console.WriteLine("✓ Data Protection fallback to file system");
//     }
// }
// else
// {
//     // Fallback untuk local dev
//     var keysPath = Path.Combine(builder.Environment.ContentRootPath, "DataProtection-Keys");
//     Directory.CreateDirectory(keysPath);
//     builder.Services.AddDataProtection()
//         .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
//         .SetApplicationName("SnDOne");
// }
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".SnDOne.Session";
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = Enum.Parse<Microsoft.AspNetCore.Http.SameSiteMode>(Config.CookieSameSite);
    options.Cookie.SecurePolicy = Config.CookieSecure ? CookieSecurePolicy.Always : CookieSecurePolicy.SameAsRequest;
    options.IdleTimeout = TimeSpan.FromMinutes(Config.SessionTimeout);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = Config.CookieHttpOnly;
        options.Cookie.SameSite = Enum.Parse<Microsoft.AspNetCore.Http.SameSiteMode>(Config.CookieSameSite);
        options.Cookie.SecurePolicy = Config.CookieSecure ? CookieSecurePolicy.Always : CookieSecurePolicy.SameAsRequest;
        options.ExpireTimeSpan = TimeSpan.FromDays(ConvertToDouble(Config.CookieExpires));
        options.SlidingExpiration = true;
        options.LoginPath = new PathString("/login");
        options.AccessDeniedPath = new PathString("/error");
    })
    .AddJwtBearer(options =>
    { // JWT
        options.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"] ?? "")),

            ValidateIssuer = true,
            ValidIssuer = Configuration["Jwt:Issuer"] ?? "",

            ValidateAudience = true,
            ValidAudience = Configuration["Jwt:Audience"] ?? "",

            ValidateLifetime = true
        };
        options.Events = new()
        {
            OnMessageReceived = context =>
            {
                string authorization = context.Request.Headers[Configuration["Jwt:AuthHeader"]!].ToString();
                if (authorization?.StartsWith("Bearer ") ?? false)
                { // Authorization header found
                    context.Token = authorization.Substring("Bearer ".Length).Trim();
                }
                else
                {
                    context.NoResult();
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        string allowOrigin = Configuration["Cors:AccessControlAllowOrigin"] ?? "";
        string allowHeaders = Configuration["Cors:AccessControlAllowHeaders"] ?? "";
        if (Empty(allowOrigin) || SameString(allowOrigin, "*"))
            builder.AllowAnyOrigin();
        else
            builder.WithOrigins(allowOrigin.Split(',').Select(x => x.Trim()).Where(x => x != "").ToArray()).AllowCredentials();
        if (Empty(allowHeaders) || SameString(allowHeaders, "*"))
            builder.AllowAnyHeader();
        else
            builder.WithHeaders(allowHeaders.Split(',').Select(x => x.Trim()).Where(x => x != "").ToArray()).AllowCredentials();
        builder.AllowAnyMethod();
    });

    options.AddPolicy("ApiCorsPolicy", builder =>
    {
        string allowOrigin = Configuration["Cors:ApiAccessControlAllowOrigin"] ?? "";
        string allowHeaders = Configuration["Cors:ApiAccessControlAllowHeaders"] ?? "";
        if (Empty(allowOrigin) || SameString(allowOrigin, "*"))
            builder.AllowAnyOrigin();
        else
            builder.WithOrigins(allowOrigin.Split(',').Select(x => x.Trim()).Where(x => x != "").ToArray()).AllowCredentials();
        if (Empty(allowHeaders) || SameString(allowHeaders, "*"))
            builder.AllowAnyHeader();
        else
            builder.WithHeaders(allowHeaders.Split(',').Select(x => x.Trim()).Where(x => x != "").ToArray()).AllowCredentials();
        builder.AllowAnyMethod();
    });
});

builder.Services.AddAntiforgery(options =>
{
    options.FormFieldName = Config.TokenName;
    options.HeaderName = Config.TokenName.HeaderCase();
});

// Hangfire Configuration
builder.Services.AddHangfire(configuration => configuration
    .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection") ?? 
        Configuration["Databases:DB:connectionstring"]?
            .Replace("{dbname}", Configuration["Databases:DB:dbname"] ?? "")
            .Replace("{uid}", Configuration["Databases:DB:username"] ?? "")
            .Replace("{pwd}", Configuration["Databases:DB:password"] ?? ""), 
        new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));
// Add the processing server as IHostedService
builder.Services.AddHangfireServer();

ServiceAdd(builder.Services);
InvokeServiceAddEvent(builder.Services);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));

AppBuild(builder);
InvokeAppBuildEvent(builder);

var app = builder.Build();
Application = app;

string[] supportedCultures = ["en-US"];
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

if (app.Environment.IsDevelopment())
{
}
else
{
    app.UseExceptionHandler("/Home/error");
    app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}


app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseDefaultFiles();
app.UseStaticFiles(StaticFileSettings);
app.UseMiddleware<SQLInjectionMiddleware>();
app.UseRouting();
app.UseWhen(
    context => !context.Request.Path.StartsWithSegments("/mwtChatHub"),
    appBuilder => appBuilder.UseHttpCacheHeaders()
);

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCookiePolicy();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

// Hangfire Dashboard
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "SnDOne Background Jobs"
});
// Register Hangfire recurring jobs
BackgroundJobConfig.Register();

app.MapHub<MwtChatHub>("/mwtChatHub");
app.MapDefaultControllerRoute();
RouteAction(app); // Routes Add event
InvokeRouteActionEvent(app);
app.UseMaintenance();
app.Run();
