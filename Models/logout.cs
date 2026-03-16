using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// logout
    /// </summary>
    public static Logout logout
    {
        get => HttpData.Get<Logout>("logout")!;
        set => HttpData["logout"] = value;
    }

    /// <summary>
    /// Page class (logout)
    /// </summary>
    public class Logout : LogoutBase
    {
        // Constructor
        public Logout(Controller controller) : base(controller)
        {
        }

        // Constructor
        public Logout() : base()
        {
        }

        // Server events
        public override void UserLoggedOut(string usr) {
            if (Session.GetBool("IsIdamanUserRegistered"))
            {
                Session.SetBool("IsIdamanUserRegistered", false);
                Task.Run(async () =>
                {
                    await HttpContext.SignOutAsync("oidc");
                }).GetAwaiter().GetResult();
                HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());
                if (Session.GetBool("BypassIdamanPwdCheck"))
                {
                    Session.SetBool("BypassIdamanPwdCheck", false);
                }
            }
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class LogoutBase : MasterUser
    {
        // Page ID
        public string PageID = "logout";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "logout";

        // Title
        public string? Title = null; // Title for <title> tag

        // Page headings
        public string Heading = "";

        public string Subheading = "";

        public string PageHeader = "";

        public string PageFooter = "";

        // Token
        public string? Token = null; // DN

        public bool CheckToken = Config.CheckToken;

        // Action result // DN
        public IActionResult? ActionResult;

        // Cache // DN
        public IMemoryCache? Cache;

        // Page layout
        public bool UseLayout = true;

        // Page terminated // DN
        private bool _terminated = false;

        // Is terminated
        public bool IsTerminated => _terminated;

        // Is lookup
        public bool IsLookup => IsApi() && RouteValues.TryGetValue("controller", out object? name) && SameText(name, Config.ApiLookupAction);

        // Is AutoFill
        public bool IsAutoFill => IsLookup && SameText(Post("ajax"), "autofill");

        // Is AutoSuggest
        public bool IsAutoSuggest => IsLookup && SameText(Post("ajax"), "autosuggest");

        // Is modal lookup
        public bool IsModalLookup => IsLookup && SameText(Post("ajax"), "modal");

        // Page URL
        private string _pageUrl = "";

        // Constructor
        public LogoutBase(Controller? controller)
        {
            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Language object
            Language = ResolveLanguage();

            // Table object (masterUser)
            if (masterUser == null || masterUser is MasterUser)
                masterUser = this;
            masterUser ??= this;

            // Start time
            StartTime = Environment.TickCount;

            // Debug message
            LoadDebugMessage();

            // Open connection
            Conn = Connection; // DN
        }

        // Page action result
        public IActionResult PageResult()
        {
            if (ActionResult != null)
                return ActionResult;
            SetupMenus();
            return Controller.View();
        }

        // Page heading
        public string PageHeading
        {
            get {
                if (!Empty(Heading))
                    return Heading;
                else
                    return "";
            }
        }

        // Page subheading
        public string PageSubheading
        {
            get {
                if (!Empty(Subheading))
                    return Subheading;
                return "";
            }
        }

        // Page name
        public string PageName => "logout";

        // Page URL
        public string PageUrl
        {
            get {
                if (_pageUrl == "") {
                    _pageUrl = PageName + "?";
                }
                return _pageUrl;
            }
        }

        // Valid post
        protected async Task<bool> ValidPost() => !CheckToken || !IsPost() || IsApi() || Antiforgery != null && HttpContext != null && await Antiforgery.IsRequestValidAsync(HttpContext);

        // Create token
        public void CreateToken()
        {
            Token ??= HttpContext != null ? Antiforgery?.GetAndStoreTokens(HttpContext).RequestToken : null;
            CurrentToken = Token ?? ""; // Save to global variable
        }

        // Constructor
        public LogoutBase() : this(null) { }

        /// <summary>
        /// Terminate page
        /// </summary>
        /// <param name="url">URL to rediect to</param>
        /// <returns>Page result</returns>
        public override IActionResult Terminate(string url = "")
        { // DN
            if (_terminated) return new EmptyResult();
            InvokeUnloadHooks();
            if (!IsApi()) PageRedirecting(ref url);
            Collect();                // DN
            _terminated = true;       // DN
            if (IsApi()) return BuildApiTerminateResult(url);
            if (ActionResult != null) return ActionResult;
            if (Empty(url)) return new EmptyResult();
            if (!Config.Debug) ResponseClear();
            if (Response != null && !Response.HasStarted)
                return HandleRedirect(url);
            return new EmptyResult();
        }

        // ================= HELPER METHODS =================
        private void InvokeUnloadHooks()
        {
                    // Page Unload event
                    PageUnload();

                // Global Page Unloaded event
                PageUnloaded();
            PageUnloadedEventHandler?.Invoke(null, EventArgs.Empty);
        }

        private IActionResult BuildApiTerminateResult(string url)
        {
            var result = new Dictionary<string, string> { { "version", Config.ProductVersion } };
            if (!Empty(url)) result.Add("url", GetUrl(url));
            foreach (var (key, value) in GetMessages()) result.Add(key, value);
            return Controller.Json(result);
        }

        private IActionResult HandleRedirect(string url)
        {
            SaveDebugMessage();
            return RedirectCore(url);
        }

        private IActionResult RedirectCore(string url)
        {
            return Controller.LocalRedirect(AppPath(url));
        }

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            // Use layout
            if (!Empty(Param("layout")) && !Param<bool>("layout"))
                UseLayout = false;

            // User profile
            Profile = ResolveProfile();

            // Security
            Security = ResolveSecurity();

            // Load user profile
            if (IsLoggedIn()) {
                await Profile.SetUserName(CurrentUserName()).LoadFromStorageAsync();
            }
            CurrentAction = Param("action"); // Set up current action

            // Global Page Loading event
            PageLoading();
            PageLoadingEventHandler?.Invoke(null, EventArgs.Empty);

            // Page Load event
            PageLoad();

            // Check token
            if (!await ValidPost())
                End(Language.Phrase("InvalidPostRequest"));

            // Check action result
            if (ActionResult != null) // Action result set by server event // DN
                return ActionResult;

            // Create token
            CreateToken();
            bool validate = true;
            string username = Security.CurrentUserName;

            // Call User LoggingOut event
            validate = UserLoggingOut(username);
            if (!validate) {
                string lastUrl = Security.LastUrl;
                if (Empty(lastUrl))
                    lastUrl = "index";
                return Terminate(lastUrl); // Go to last accessed URL
            } else {
                Cookie.Remove("LastUrl"); // Clear last URL

                // Clear jwt from AutoLogin Cookie
                string jwt = Cookie["AutoLogin"]; // DN
                if (!Empty(jwt)) {
                    Dictionary<string, string> values = DecodeJwt(jwt);
                    Cookie["AutoLogin"] = CreateJwt(new Dictionary<string, object?>
                        {
                            { "Username", values.ContainsKey("Username") ? values["Username"] : "" }
                        }, Config.RememberMeExpiryTime); // Write cookie without autologin
                }

                // Password changed (after expired password)
                bool isPasswordChanged = Config.UseTwoFactorAuthentication && SameString(Session[Config.SessionStatus], "passwordchanged");
                await WriteAuditTrailOnLogout();

                // Call User LoggedOut event
                UserLoggedOut(username);

                // Clean upload temp folder
                CleanUploadTempPaths(Session.SessionId);

                // Unset all of the session variables
                Session.Clear();

                // Sign out
                if (HttpContext != null)
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                if (Param<bool>("deleted")) {
                    TempData["heading"] = Language.Phrase("Notice");
                    TempData["success"] = Language.Phrase("PersonalDataDeleteSuccess");
                }

                // If password changed, show login message
                if (isPasswordChanged) {
                    TempData["heading"] = Language.Phrase("Notice");
                    TempData["failure"] = Language.Phrase("LoginAfterPasswordChanged");
                }

                // If session expired, show expired message
                if (Param<bool>("expired")) {
                    TempData["heading"] = Language.Phrase("Notice");
                    TempData["failure"] = Language.Phrase("SessionExpired");
                }
                return Terminate("login"); // Go to login page
            }
        }

        // Write audit trail on logout
        protected async Task WriteAuditTrailOnLogout() {
            var usr = CurrentUserIdentifier();
            await WriteAuditLogAsync(usr, Language.Phrase("AuditTrailLogout"), CurrentUserIpAddress());
        }

        // Page Load event
        public virtual void PageLoad() {
            //Log("Page Load");
        }

        // Page Unload event
        public virtual void PageUnload() {
            //Log("Page Unload");
        }

        // Page Redirecting event
        public virtual void PageRedirecting(ref string url) {
            //url = newurl;
        }

        // Message Showing event
        // type = ""|"success"|"failure"|"warning"
        public virtual void MessageShowing(ref string msg, string type) {
            // Note: Do not change msg outside the following 4 cases.
            if (type == "success") {
                //msg = "your success message";
            } else if (type == "failure") {
                //msg = "your failure message";
            } else if (type == "warning") {
                //msg = "your warning message";
            } else {
                //msg = "your message";
            }
        }

        // User Logging Out event
        public virtual bool UserLoggingOut(string usr) {
            // Enter your code here
            // To cancel, set return value to False
            return true;
        }

        // User Logged Out event
        public virtual void UserLoggedOut(string usr) {
            //Log("User Logged Out");
        }
    } // End page class
} // End Partial class
