using ApplicationUser = SnDOne.Models.ApplicationUser;

namespace SnDOne.Controllers;

// Partial class
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi=true)]
public partial class HomeController : Controller
{
    private IMemoryCache _cache;

    // Constructor
    public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
    {
        _cache = memoryCache;
        GLOBALS.Logger = logger;
    }

    // Destructor
    protected override void Dispose(bool disposing)
    {
        if (disposing) {
            // Clean up temp folder if not add/edit/export
            dynamic page = CurrentPage;
            if (page != null) {
                string pageId = page.PageID;
                if (GetProperty(page, "TableName") != null &&
                    !(new [] { "add", "register", "edit", "update" }).Contains(pageId) &&
                    !(pageId == "list" && page.IsAddOrEdit) &&
                    !(!Empty(GetPropertyValue(page, "Export")) && page.Export != "print" && page.UseCustomTemplate))
                CleanUploadTempPaths(Session.SessionId);
            }
        }
        base.Dispose(disposing);
    }

    // Personal Data
    [Route("personaldata/{cmd?}", Name = "personaldata")]
    [Route("Home/personaldata/{cmd?}", Name = "personaldata-2")]
    public async Task<IActionResult> PersonalData()
    {
        // Create page object
        personalData = new GLOBALS.PersonalData(this);

        // Run the page
        return await personalData.Run();
    }

    // Login
    [Route("login/{provider?}", Name = "login")]
    [Route("Home/login/{provider?}", Name = "login-2")]
    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
        // Create page object
        login = new GLOBALS.Login(this);

        // Run the page
        return await login.Run();
    }

    // Change Password
    [Route("changepassword", Name = "changepassword")]
    [Route("Home/changepassword", Name = "changepassword-2")]
    public async Task<IActionResult> ChangePassword()
    {
        // Create page object
        changePassword = new GLOBALS.ChangePassword(this);

        // Run the page
        return await changePassword.Run();
    }

    // Userpriv
    [Route("userpriv/{UserLevelID?}", Name = "userpriv")]
    [Route("Home/userpriv/{UserLevelID?}", Name = "userpriv-2")]
    public async Task<IActionResult> Userpriv()
    {
        // Create page object
        userpriv = new GLOBALS.Userpriv(this);

        // Run the page
        return await userpriv.Run();
    }

    // Logout
    [Route("logout", Name = "logout")]
    [Route("Home/logout", Name = "logout-2")]
    public async Task<IActionResult> Logout()
    {
        // Create page object
        logout = new GLOBALS.Logout(this);

        // Run the page
        return await logout.Run();
    }

    // Index
    [Route("")]
    [Route("index", Name = "index")]
    [Route("Home/index", Name = "index-2")]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        // Create page object
        index = new GLOBALS.Index(this);

        // Run the page
        return await index.Run();
    }

    // Error
    [Route("error", Name = "error")]
    [Route("Home/error", Name = "error-2")]
    [AllowAnonymous]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> Error()
    {
        // Create page object
        error = new GLOBALS.Error(this);

        // Run the page
        return await error.Run();
    }

    // Swagger
    [Route("swagger/swagger", Name = "swagger")]
    [Route("Home/swagger/swagger", Name = "swagger-2")]
    [AllowAnonymous]
    public IActionResult Swagger()
    {
        Language = ResolveLanguage();
        ViewData["Title"] = Language.Phrase("ApiTitle");
        ViewData["Version"] = Config.ApiVersion;
        ViewData["BasePath"] = Request.PathBase.ToString();
        return View();
    }

    // Custom actions
    public static string GenerateRandomPassword(int length = 8)
    {
        const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lower = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        const string special = "!@#$%^&*()-_=+[]{};:,.<>?";
        string allChars = upper + lower + digits + special;
        var password = new StringBuilder();
        password.Append(GetRandomChar(upper));
        password.Append(GetRandomChar(lower));
        password.Append(GetRandomChar(digits));
        password.Append(GetRandomChar(special));
        for (int i = password.Length; i < length; i++)
        {
            password.Append(GetRandomChar(allChars));
        }
        return ShuffleString(password.ToString());
    }

    private static char GetRandomChar(string source)
    {
        byte[] buffer = new byte[1];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(buffer);
            int index = buffer[0] % source.Length;
            return source[index];
        }
    }

    private static string ShuffleString(string input)
    {
        var array = input.ToCharArray();
        var rng = RandomNumberGenerator.Create();
        byte[] buffer = new byte[1];
        for (int i = array.Length - 1; i > 0; i--)
        {
            rng.GetBytes(buffer);
            int j = buffer[0] % (i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
        return new string(array);
    }

    [Route("IdamanLogin", Name = "IdamanLogin")]
    [AllowAnonymous]
    public IActionResult IdamanLogin()
    {
        if (IsLoggedIn()) {
            return Redirect(AppPath() + "WelcomePage");
        }
        if (HttpContext?.User?.Identity != null)
        {
            if (!HttpContext.User.Identity.IsAuthenticated) {
                return Challenge("oidc");
            }
            foreach (var claim in HttpContext.User.Claims)
            {
                Console.WriteLine($"Type: {claim.Type} | Value: {claim.Value}");
            }
            var idIdaman = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "";
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email))?.Value ?? "";
            string fullName = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("display_name"))?.Value ?? "";
            string companyCode = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("company_code"))?.Value ?? "";
            string username = email.Contains("@") ? email.Split('@')[0] : email;
            if (companyCode != "2222")
            {
                Console.WriteLine("Blocked login: company_code bukan 2222");
                Session.SetBool("IdamanUserNotPatraNiaga", true);
                return Redirect(AppPath() + "login");
            }
            using var httpClient = new HttpClient();
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, $"{IdamanApiUrls.LoginBaseUrl}/connect/token")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", IdamanApiUrls.ClientId },
                    { "client_secret", IdamanApiUrls.ClientSecret },
                    { "scope", IdamanApiUrls.Scope },
                    { "grant_type", IdamanApiUrls.GrantType }
                })
            };
            var tokenResponse = httpClient.SendAsync(tokenRequest).Result;
            var tokenJson = tokenResponse.Content.ReadAsStringAsync().Result;
            var tokenData = System.Text.Json.JsonSerializer.Deserialize<TokenResponse>(
                tokenJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            var token = tokenData?.access_token;
            string? nextUrl = $"{IdamanApiUrls.RestBaseUrl}/v1/users/company/2222?SearchText={email}";
            int idamanPos = 0;
            string posName = "";
            while (!string.IsNullOrEmpty(nextUrl))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, nextUrl);
                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = httpClient.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                var data = System.Text.Json.JsonSerializer.Deserialize<IdamanPositionsResponse>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                Console.WriteLine(
                    System.Text.Json.JsonSerializer.Serialize(
                        data,
                        new JsonSerializerOptions { WriteIndented = true }
                    )
                );
                if (data?.value != null)
                {
                    var user = data.value.FirstOrDefault(x => x.email == email);
                    if (user != null)
                    {
                        int.TryParse(user.position?.id, out idamanPos);
                        posName = user.position?.name ?? "";
                        Console.WriteLine($"Id Position  : {idamanPos.ToString()}");
                        Console.WriteLine($"Position Name: {posName}");
                        break;
                    }
                }
                nextUrl = data?.next;
            }
            if (string.IsNullOrEmpty(email))
            {
                return Redirect(AppPath() + "login");
            }
            SqlConnection sqlConnection = GetConnection("Db").OpenConnection();
            if (idamanPos == 0) {
                // position default jika id position tidak valid
                idamanPos = 11111111;
            }

            // jika IdPosition tidak terdaftar, maka insert position baru
            dynamic posQuery = QueryBuilder("MasterPosition").Where("IdPosition", idamanPos).Select(["IdPosition", "Role", "UserLevel"]).FirstOrDefault();
            var rolePosition = posQuery != null && posQuery?.Role != null ? Convert.ToInt32(posQuery?.Role) : -1;
            var userLevelPosition = posQuery != null && posQuery?.UserLevel != null ? Convert.ToInt32(posQuery?.UserLevel) : 8;
            if (posQuery == null || posQuery?.IdPosition == null) {
                QueryBuilder("MasterPosition").Insert(new {
                    IdPosition = idamanPos,
                    NamaPosition = posName,
                    Role = -1,
                    UserLevel = 8
                });
            }
            dynamic userQuery = QueryBuilder("MasterUser").Where("Email", email).Select(["Username", "exception"]).FirstOrDefault();
            // insert user baru kalau email belum terdaftar
            if (userQuery == null || userQuery?.Username == null)
            {
                QueryBuilder("MasterUser").Insert(new {
                    Username = username,
                    Email = email,
                    PasswordHash = EncryptPassword(GenerateRandomPassword()),
                    NamaLengkap = fullName,
                    Rule = rolePosition,
                    UserLevel = userLevelPosition,
                    IdPosition = idamanPos,
                    Region = 8,
                    Plant = 473,
                    StatusAktif = 1,
                    DibuatOleh = email,
                    TanggalDibuat = DateTime.Now
                });
            }
            bool isException = Convert.ToBoolean(userQuery?.exception ?? false);
            if (!isException) {
                dynamic userPosQuery = QueryBuilder("MasterUser").Where("Email", email).Select("IdPosition").FirstOrDefault();
                // update position jika user belum punya position atau position user berubah
                if (userPosQuery == null || userPosQuery?.IdPosition == null || userPosQuery?.IdPosition != idamanPos) {
                    QueryBuilder("MasterUser").Where("Email", email).Update(new {
                        IdPosition = idamanPos,
                        DiperbaruiOleh = username,
                        TanggalDiperbarui = DateTime.Now
                    });
                }
                dynamic userIdamanId = QueryBuilder("MasterUser").Where("Email", email).Select("IdIdaman").FirstOrDefault();
                // update IdIdaman jika user belum punya IdIdaman atau IdIdaman user berubah
                if (userIdamanId == null || userIdamanId?.IdIdaman == null || userIdamanId?.IdIdaman != idIdaman) {
                    QueryBuilder("MasterUser").Where("Email", email).Update(new {
                        IdIdaman = idIdaman,
                        DiperbaruiOleh = username,
                        TanggalDiperbarui = DateTime.Now
                    });
                }
            }
            dynamic mappingQuery = QueryBuilder("MappingPosition").Where("IdPosition", idamanPos).Select("IdPosition").FirstOrDefault();
            if (mappingQuery == null || mappingQuery?.IdPosition == null) {
                Session.SetString("IdPositionIsNotMapped", "y");
            }
            userQuery = QueryBuilder("MasterUser").Where("Email", email).Select("Username").FirstOrDefault();
            LoginModel model = new()
            {
                Username = userQuery.Username,
                Password = ""
            };
            Session.SetBool("IsIdamanUserRegistered", true);
            Session.SetBool("BypassIdamanPwdCheck", true);
            var userClaimDictionary = new Dictionary<string, string>
            {
                { ClaimTypes.Email.Split('/').Last(), email }
            };
            var userClaimDictionaryObject = ConvertToObjectDictionary(userClaimDictionary);
            Profile = ResolveProfile();
            Profile.Assign(userClaimDictionaryObject);
            Task.Run(async () =>
            {
                await Security.ValidateUser(model);
            }).GetAwaiter().GetResult();
            return Redirect(AppPath() + "WelcomePage");
        }
        return Redirect(AppPath() + "login");
    }

    private Dictionary<string, object> ConvertToObjectDictionary(Dictionary<string, string> stringDictionary)
    {
        return stringDictionary.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value);
    }

    // Dispose
    // protected override void Dispose(bool disposing) {
    //     try {
    //         base.Dispose(disposing);
    //     } finally {
    //         CurrentPage?.Terminate();
    //     }
    // }
}
