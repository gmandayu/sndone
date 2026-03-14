using Microsoft.Extensions.Configuration;

public static class IdamanApiUrls
{
    public static string LoginBaseUrl { get; private set; }
    public static string RestBaseUrl { get; private set; }
    public static string ClientId { get; private set; }
    public static string ClientSecret { get; private set; }
    public static string Scope { get; private set; }
    public static string GrantType { get; private set; }

    // Static constructor otomatis dipanggil sekali saat class pertama kali diakses
    static IdamanApiUrls()
    {
        // build konfigurasi dari appsettings.json
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory) // lokasi appsettings.json
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        Initialize(config);
    }

    private static void Initialize(IConfiguration configuration)
    {
        bool enabled = configuration.GetValue<bool>("IdamanApi:IdamanAPIEnabled");

        if (enabled)
        {
            LoginBaseUrl = configuration["IdamanApi:LoginBaseUrl"];
            RestBaseUrl = configuration["IdamanApi:RestBaseUrl"];
            ClientId = configuration["IdamanApi:ClientId"];
            ClientSecret = configuration["IdamanApi:ClientSecret"];
            Scope = configuration["IdamanApi:Scope"];
            GrantType = configuration["IdamanApi:GrantType"];
        }
        else
        {
            // fallback default (hardcoded)
            LoginBaseUrl = "https://login.idaman.pertamina.com";
            RestBaseUrl = "https://rest.idaman.pertamina.com";
            ClientId = "b45b477d365240c2a1aa5a9e2a3a4790";
            ClientSecret = "f0b8366c-9df5-454a-be0d-9efab9754e44";
            Scope = "api.auth user.read user.readAll";
            GrantType = "client_credentials";
        }
    }
}
