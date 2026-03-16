using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// vFaceEnrollmentEdit
    /// </summary>
    public static VFaceEnrollmentEdit vFaceEnrollmentEdit
    {
        get => HttpData.Get<VFaceEnrollmentEdit>("vFaceEnrollmentEdit")!;
        set => HttpData["vFaceEnrollmentEdit"] = value;
    }

    /// <summary>
    /// Page class for VFaceEnrollment
    /// </summary>
    public class VFaceEnrollmentEdit : VFaceEnrollmentEditBase
    {
        // Constructor
        public VFaceEnrollmentEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VFaceEnrollmentEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VFaceEnrollmentEditBase : VFaceEnrollment
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "vFaceEnrollmentEdit";

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
        public VFaceEnrollmentEditBase(Controller? controller)
        {
            TableName = "VFaceEnrollment";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (vFaceEnrollment)
            if (vFaceEnrollment == null || vFaceEnrollment is VFaceEnrollment)
                vFaceEnrollment = this;

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
                else if (!Empty(Caption))
                    return Caption;
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
                if (!Empty(TableName))
                    return Language.Phrase(PageID);
                return "";
            }
        }

        // Page name
        public string PageName => "VFaceEnrollmentEdit";

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

        // Show Page Header
        public IHtmlContent ShowPageHeader()
        {
            string header = PageHeader;
            PageDataRendering(ref header);
            if (!Empty(header)) // Header exists, display
                return new HtmlString("<div id=\"ew-page-header\">" + header + "</div>");
            return HtmlString.Empty;
        }

        // Show Page Footer
        public IHtmlContent ShowPageFooter()
        {
            string footer = PageFooter;
            PageDataRendered(ref footer);
            if (!Empty(footer)) // Footer exists, display
                return new HtmlString("<div id=\"ew-page-footer\">" + footer + "</div>");
            return HtmlString.Empty;
        }

        // Valid post
        protected async Task<bool> ValidPost() => !CheckToken || !IsPost() || IsApi() || Antiforgery != null && HttpContext != null && await Antiforgery.IsRequestValidAsync(HttpContext);

        // Create token
        public void CreateToken()
        {
            Token ??= HttpContext != null ? Antiforgery?.GetAndStoreTokens(HttpContext).RequestToken : null;
            CurrentToken = Token ?? ""; // Save to global variable
        }

        // Set field visibility
        public void SetVisibility()
        {
            IdUser.SetVisibility();
            _Username.SetVisibility();
            LinkRedirect.SetVisibility();
            _Email.SetVisibility();
            NamaLengkap.SetVisibility();
            DownloadFace.SetVisibility();
            IdPosition.SetVisibility();
            Jabatan.SetVisibility();
            Face.SetVisibility();
            TanggalInputFace.SetVisibility();
            UserInputFace.SetVisibility();
            AzurePersonId.SetVisibility();
        }

        // Constructor
        public VFaceEnrollmentEditBase() : this(null) { }

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
            if (IsModal) return BuildModalResult_ListAddEditUpdateViewSearch(url);
            SaveDebugMessage();
            return RedirectCore(url);
        }

        private IActionResult RedirectCore(string url)
        {
            return Controller.LocalRedirect(AppPath(url));
        }

        private IActionResult BuildModalResult_ListAddEditUpdateViewSearch(string url)
        {
            string pageName = GetPageName(url);
                var result = new Dictionary<string, string> { { "url", GetUrl(url) }, { "modal", "1" } }; // modal=1
                    if (SameString(pageName, GetPageName(ListUrl)) ||
                        SameString(pageName, GetPageName(ViewUrl)) ||
                        SameString(pageName, GetPageName(GetCurrentMasterTable()?.ViewUrl ?? "")))
                    {
                // List / View / Master View page
                    if (!SameString(pageName, ListUrl))
                    {
                        result.Add("caption", GetModalCaption(pageName));
                        result.Add("view", pageName == "VFaceEnrollmentView" ? "1" : "0"); // If View page, no primary button
                    }
                    else
                    {
                        result.Add("error", FailureMessage); // List page should not be shown as modal => error
                        ClearFailureMessage();
                    }
                    }
                    else
                    { // Other pages (add messages and then clear messages)
                        result = GetMessages();
                        result.Add("modal", "1");
                        ClearMessages();
                    }
                return Controller.Json(result);
        }

        // Get all records from datareader
        [return: NotNullIfNotNull("dr")]
        protected async Task<List<Dictionary<string, object>>> GetRecordsFromRecordset(DbDataReader? dr)
        {
            List<Dictionary<string, object>> rows = [];
            while (dr != null && await dr.ReadAsync()) {
                await LoadRowValues(dr); // Set up DbValue/CurrentValue
                if (GetRecordFromDictionary(GetDictionary(dr)) is Dictionary<string, object> row)
                    rows.Add(row);
            }
            return rows;
        }

        // Get all records from the list of records
        #pragma warning disable 1998

        protected async Task<List<Dictionary<string, object>>> GetRecordsFromRecordset(List<Dictionary<string, object>>? list)
        {
            List<Dictionary<string, object>> rows = [];
            if (list != null) {
                foreach (var row in list) {
                    if (GetRecordFromDictionary(row) is Dictionary<string, object> d)
                       rows.Add(row);
                }
            }
            return rows;
        }
        #pragma warning restore 1998

        // Get the first record from datareader
        [return: NotNullIfNotNull("dr")]
        protected async Task<Dictionary<string, object>?> GetRecordFromRecordset(DbDataReader? dr)
        {
            if (dr != null) {
                await LoadRowValues(dr); // Set up DbValue/CurrentValue
                return GetRecordFromDictionary(GetDictionary(dr));
            }
            return null;
        }

        // Get the first record from the list of records
        protected Dictionary<string, object>? GetRecordFromRecordset(List<Dictionary<string, object>>? list) =>
            list != null && list.Count > 0 ? GetRecordFromDictionary(list[0]) : null;

        // Get record from Dictionary (refactor: low cognitive complexity)
        protected Dictionary<string, object>? GetRecordFromDictionary(Dictionary<string, object>? dict)
        {
            if (dict is null) return null;
            var row = new Dictionary<string, object>();
            foreach (var (key, value) in dict)
            {
                if (!Fields.TryGetValue(key, out DbField? fld) || fld is null) continue;
                if (!ShouldIncludeField(fld)) continue;
                var cell = fld.HtmlTag == "FILE"
                    ? BuildFileCell(fld, value, dict)
                    : BuildScalarCell(fld, value);
                if (cell is not null)
                    row[key] = cell;
            }
            return row;
        }

        // ---- Helpers ----
        private static bool ShouldIncludeField(DbField fld)
            => fld.Visible || fld.IsPrimaryKey;

        private object? BuildFileCell(DbField fld, object value, Dictionary<string, object> srcRow)
        {
            if (Empty(value)) return null; // (sesuai kode asli: tidak menambahkan key)

            // Blob
            if (fld.DataType == DataType.Blob)
            {
                var bytes = (byte[])value;
                var url = FullUrl($"{GetPageName(Config.ApiUrl)}/{Config.ApiFileAction}/{fld.TableVar}/{fld.Param}/{GetRecordKeyValue(srcRow)}");
                return FileMeta(ContentType(bytes), url, fld.Param + ContentExtension(bytes));
            }

            // Non-blob
            var s = ConvertToString(value);
            if (!fld.UploadMultiple || !s.Contains(Config.MultipleUploadSeparator))
            {
                var url = FullUrl($"{GetPageName(Config.ApiUrl)}/{Config.ApiFileAction}/{fld.TableVar}/{Encrypt(fld.PhysicalUploadPath + s)}");
                return FileMeta(ContentType(s), url, s);
            }

            // Multiple files
            var files = s.Split(Config.MultipleUploadSeparator);
            return files
                .Where(f => !Empty(f))
                .Select(f =>
                {
                    var url = FullUrl($"{GetPageName(Config.ApiUrl)}/{Config.ApiFileAction}/{fld.TableVar}/{Encrypt(fld.PhysicalUploadPath + f)}");
                    return FileMeta(ContentType(f), url, f);
                });
        }

        private static Dictionary<string, object> FileMeta(string type, string url, string name) =>
            new Dictionary<string, object> { { "type", type }, { "url", url }, { "name", name } };

        private object BuildScalarCell(DbField fld, object value)
        {
            var s = ConvertToString(value);
            if (fld.DataType == DataType.Date && value is DateTime dt)
                s = dt.ToString("s");
            return ConvertToString(s);
        }

// Get record key value from array
protected string GetRecordKeyValue(Dictionary<string, object> dict) {
            string key = "";
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdUser") ? dict["IdUser"] : IdUser.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
        }

        #pragma warning disable 219
/// <summary>
/// Lookup data from table
/// </summary>
        public async Task<Dictionary<string, object>> Lookup(Dictionary<string, string>? dict = null)
{
    Language = ResolveLanguage();
    Security = ResolveSecurity();
    var lookupField = FieldByName(GetFieldName(dict));
    var lookup = lookupField?.Lookup;
    if (lookup == null)
        return new Dictionary<string, object>();
            string lookupType = GetLookupType(dict);
    var (searchValue, pageSize) = GetSearchAndPageSize(dict, lookupType);
    int offset = CalculateOffset(dict, pageSize);
    ApplyUserSettings(dict, lookup);
    ApplyFilterValues(dict, lookup);
    lookup.LookupType = lookupType;
    lookup.SearchValue = searchValue;
    lookup.PageSize = pageSize;
    lookup.Offset = offset;
    return await lookup.ToJson(this);
}

private string GetFieldName(Dictionary<string, string>? dict)
{
    return GetValue(dict, "field", Post("field"));
}

private string GetLookupType(Dictionary<string, string>? dict)
{
    return GetValue(dict, "ajax", Post("ajax") ?? "unknown");
}

private (string searchValue, int pageSize) GetSearchAndPageSize(Dictionary<string, string>? dict, string lookupType)
{
    string searchValue = "";
    int pageSize = -1;
    if (SameText(lookupType, "modal") || SameText(lookupType, "filter"))
    {
        searchValue = GetValue(dict, new[] { "q", "sv" }, Param("q") ?? Post("sv"));
        int fallback = 10;
        if (IsNumeric(Param("n")))
        {
            fallback = Param<int>("n");
        }
        else if (Post("recperpage", out StringValues rpp))
        {
            fallback = ConvertToInt(rpp.ToString());
        }
        pageSize = GetInt(dict, new[] { "n", "recperpage" }, fallback);
    }
    else if (SameText(lookupType, "autosuggest"))
    {
        searchValue = GetValue(dict, "q", Param("q"));
        pageSize = GetInt(dict, "n", IsNumeric(Param("n")) ? Param<int>("n") : -1);
        if (pageSize <= 0)
            pageSize = Config.AutoSuggestMaxEntries;
    }
    return (searchValue, pageSize);
}

private int CalculateOffset(Dictionary<string, string>? dict, int pageSize)
{
    int start = GetInt(dict, "start", IsNumeric(Param("start")) ? Param<int>("start") : -1);
    int page = GetInt(dict, "page", IsNumeric(Param("page")) ? Param<int>("page") : -1);
    if (start >= 0)
        return start;
    return (page > 0 && pageSize > 0)
        ? (page - 1) * pageSize
        : 0;
}

private void ApplyUserSettings(Dictionary<string, string>? dict, dynamic lookup)
{
    string userSelect = Decrypt(GetValue(dict, "s", Post("s")));
    string userFilter = Decrypt(GetValue(dict, "f", Post("f")));
    string userOrderBy = Decrypt(GetValue(dict, "o", Post("o")));
    if (!string.IsNullOrEmpty(userSelect)) lookup.UserSelect = userSelect;
    if (!string.IsNullOrEmpty(userFilter)) lookup.UserFilter = userFilter;
    if (!string.IsNullOrEmpty(userOrderBy)) lookup.UserOrderBy = userOrderBy;
}

private void ApplyFilterValues(Dictionary<string, string>? dict, dynamic lookup)
{
    lookup.FilterValues.Clear();
    StringValues keys = GetKeys(dict);
    if (!Empty(keys))
    {
        lookup.FilterFields = new List<string>(); // Skip parent fields if any
        lookup.FilterValues.Add(string.Join(",", keys.ToArray()));
    }
    else
    {
        string lookupValue = GetValue(dict, new[] { "v0", "lookupValue" }, Post<string>("v0") ?? Post("lookupValue"));
        lookup.FilterValues.Add(lookupValue);
        int cnt = lookup.FilterFields?.Count ?? 0;
        for (int i = 1; i <= cnt; i++)
        {
            var val = UrlDecode(GetValue(dict, $"v{i}", Post($"v{i}")));
            if (val != null)
                lookup.FilterValues.Add(val);
        }
    }
}

private string GetValue(Dictionary<string, string>? dict, string key, string? fallback = null)
{
    return IsDictionary(dict) && dict.TryGetValue(key, out var v) && v != null ? v : fallback ?? "";
}

private string GetValue(Dictionary<string, string>? dict, string[] keys, string? fallback = null)
{
    foreach (var key in keys)
    {
        if (IsDictionary(dict) && dict.TryGetValue(key, out var v) && v != null)
            return v;
    }
    return fallback ?? "";
}

private int GetInt(Dictionary<string, string>? dict, string key, int fallback)
{
    return IsDictionary(dict) && dict.TryGetValue(key, out var v) ? ConvertToInt(v) : fallback;
}

private int GetInt(Dictionary<string, string>? dict, string[] keys, int fallback)
{
    foreach (var key in keys)
    {
        if (IsDictionary(dict) && dict.TryGetValue(key, out var v))
            return ConvertToInt(v);
    }
    return fallback;
}

private StringValues GetKeys(Dictionary<string, string>? dict)
{
    if (IsDictionary(dict) && dict.TryGetValue("keys", out var v) && !Empty(v))
        return (StringValues)v;
    return Post("keys[]", out StringValues k) ? k : StringValues.Empty;
}
        #pragma warning restore 219

        public int DisplayRecords = 1; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public int RecordCount;

        public Dictionary<string, string> RecordKeys = new();

        public string FormClassName = "ew-form ew-edit-form overlay-wrapper";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public DbDataReader? Recordset; // DN

        #pragma warning disable 219
        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            var beginResult = await PageRunBeginAsync();
            if (beginResult != null) return beginResult;

            // === VARIABLES YANG DIAKSES MULTI-SECTION ===
            bool loaded = false;
            bool postBack = false;

            // === HELPER METHOD CALLS ===
            PrepareInitialSettings();
            var actionSetup = await SetupCurrentAction();
            loaded = actionSetup.Loaded;
            postBack = actionSetup.PostBack;
            if (postBack) {
                await LoadFormValues();
                await HandleApiFormKeys();
            }
            await SetupCaptchaAndDetails(postBack);
            if (postBack && !await ValidateForm()) {
                EventCancelled = true;
                RestoreFormValues();
                if (IsApi())
                    return Terminate();
                else
                    CurrentAction = "";
            }
            var actionResult = await ExecuteCurrentAction(loaded);
            if (actionResult != null) return actionResult;
            await PrepareForRender();
            PageRunEnd();
            return PageResult();
        }

        // === HELPER METHODS ===
        private void PrepareInitialSettings()
        {
            if (IsModal) SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;
        }

        private async Task<ActionSetupResult> SetupCurrentAction()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            var result = new ActionSetupResult();
            bool loaded = false;
            bool postBack = false;
            StringValues sv;
            object? rv;
            if (IsApi()) {
                loaded = true;
                string[] keyValues = {};
                if (RouteValues.TryGetValue("key", out object? k))
                    keyValues = ConvertToString(k).Split('/');
                if (RouteValues.TryGetValue("IdUser", out rv)) {
                    IdUser.FormValue = UrlDecode(rv);
                    IdUser.OldValue = IdUser.FormValue;
                } else if (CurrentForm.HasValue("x_IdUser")) {
                    IdUser.FormValue = CurrentForm.GetValue("x_IdUser");
                    IdUser.OldValue = IdUser.FormValue;
                } else if (!Empty(keyValues)) {
                    IdUser.OldValue = ConvertToString(keyValues[0]);
                } else {
                    loaded = false;
                }
                if (loaded)
                    loaded = await LoadRow();
                if (!loaded) {
                    FailureMessage = Language.Phrase("NoRecord");
                    return new ActionSetupResult { ActionResult = Terminate() };
                }
                CurrentAction = "update";
                OldKey = GetKey(true);
                postBack = true;
            } else {
                if (!Empty(Post("action"))) {
                    CurrentAction = Post("action");
                    if (!IsShow) postBack = true;
                    if (Post(OldKeyName, out sv))
                        SetKey(sv.ToString(), IsShow);
                } else {
                    CurrentAction = "show";
                    bool loadByQuery = false;
                    if (RouteValues.TryGetValue("IdUser", out rv)) {
                        IdUser.QueryValue = UrlDecode(rv);
                        loadByQuery = true;
                    } else if (Get("IdUser", out sv)) {
                        IdUser.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdUser.CurrentValue = DbNullValue;
                    }
                }
                if (IsShow) {
                    loaded = await LoadRow();
                    OldKey = loaded ? GetKey(true) : "";
                }
            }
            result.Loaded = loaded;
            result.PostBack = postBack;
            return result;
        }

        private async Task HandleApiFormKeys()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            if (IsApi() && RouteValues.TryGetValue("key", out object? k)) {
                var keyValues = ConvertToString(k).Split('/');
                IdUser.FormValue = ConvertToString(keyValues[0]);
            }
        }

        private async Task SetupCaptchaAndDetails(bool postBack)
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
        }

        private async Task<IActionResult?> ExecuteCurrentAction(bool loaded)
        {
            await Task.CompletedTask; // Satisfy async requirement
            switch (CurrentAction) {
                case "show":
                    return await HandleShowAction(loaded);
                case "update":
                    return await HandleUpdateAction();
            }
            return null;
        }

        private async Task<IActionResult?> HandleShowAction(bool loaded)
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            if (!loaded) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("NoRecord");
                return Terminate("VFaceEnrollmentList");
            }
            return null;
        }

        private async Task<IActionResult?> HandleUpdateAction()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            CloseRecordset();
            string returnUrl = DetermineReturnUrl();
            SendEmail = true;
            var res = await EditRow();
            if (res) {
                if (Empty(SuccessMessage))
                    SuccessMessage = Language.Phrase("UpdateSuccess");
                if (IsModal && UseAjaxActions) {
                    IsModal = false;
                    if (GetPageName(returnUrl) != "VFaceEnrollmentList") {
                        TempData["Return-Url"] = returnUrl;
                        returnUrl = "VFaceEnrollmentList";
                    }
                }
                if (IsJsonResponse()) {
                    ClearMessages();
                    return res;
                } else {
                    return Terminate(returnUrl);
                }
            } else if (IsApi()) {
                return Terminate();
            } else if (IsModal && UseAjaxActions) {
                return Controller.Json(new { success = false, error = GetFailureMessage() });
            } else if (FailureMessage == Language.Phrase("NoRecord")) {
                return Terminate(returnUrl);
            } else {
                EventCancelled = true;
                RestoreFormValues();
                return null;
            }
        }

        private string DetermineReturnUrl()
        {
            string returnUrl = "";
            returnUrl = ReturnUrl;
            if (GetPageName(returnUrl) == "VFaceEnrollmentList")
                returnUrl = AddMasterUrl(ListUrl);
            return returnUrl;
        }

        private async Task PrepareForRender()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            SetupBreadcrumb();
            RowType = RowType.Edit;
            ResetAttributes();
            await RenderRow();
        }

        private async Task<IActionResult?> PageRunBeginAsync()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled

                    // Is modal
                    IsModal = Param<bool>("modal");
                    UseLayout = UseLayout && !IsModal;

                    // Use layout
                    if (!Empty(Param("layout")) && !Param<bool>("layout"))
                        UseLayout = false;

                    // User profile
                    Profile = ResolveProfile();

                    // Security
                    Security = ResolveSecurity();
                    if (TableVar != "")
                        Security.LoadTablePermissions(TableVar);

                    // Load user profile
                    if (IsLoggedIn()) {
                        await Profile.SetUserName(CurrentUserName()).LoadFromStorageAsync();
                    }

                    // Create form object
                    CurrentForm ??= new();
                    await CurrentForm.Init();
                    CurrentAction = Param("action"); // Set up current action
                    SetVisibility();
                    _Username.Required = false;

                    // Do not use lookup cache
                    if (!Config.LookupCachePageIds.Contains(PageID))
                        SetUseLookupCache(false);

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

                    // Hide fields for add/edit
                    if (!UseAjaxActions) {
                        HideFieldsForAddEdit();
                    }
                    else { // Use inline delete
                        InlineDelete = true;
                    }

                    // Set up lookup cache
                    await SetupLookupOptions(IdPosition);
            return null;
        }

        private void PageRunEnd()
        {
                    // Set LoginStatus, Page Rendering and Page Render
                    if (!IsApi() && !IsTerminated) {
                        SetupLoginStatus(); // Setup login status

                        // Pass login status to client side
                        SetClientVar("login", LoginStatus);

                        // Global Page Rendering event
                        PageRendering();
                        PageRenderingEventHandler?.Invoke(null, EventArgs.Empty);

                        // Page Render event
                        vFaceEnrollmentEdit?.PageRender();
                    }
        }

        // Support class
        private sealed class ActionSetupResult
        {
            public bool Loaded { get; set; }

            public bool PostBack { get; set; }

            public bool LoadByPosition { get; set; }

            public IActionResult? ActionResult { get; set; }
        }
        #pragma warning restore 219
// ================== GENERATED HELPERS ==================
private void ResolveLookupView(dynamic fld, string keyFieldName, string fallbackType = "auto")
{
    string curVal = ConvertToString(fld.CurrentValue);

    // kosong → DbNullValue lalu selesai
    if (Empty(curVal))
    {
        fld.ViewValue = DbNullValue;
        return;
    }

    // siapkan fallback awal (kalau cache/DB tidak dapat)
    if (fallbackType == "number")
    {
        fld.ViewValue = FormatNumber(fld.CurrentValue, fld.FormatPattern);
    }
    else if (fallbackType == "date")
    {
        var tmp = fld.CurrentValue;
        fld.ViewValue = FormatDateTime(tmp, fld.FormatPattern);
    }
    else if (fallbackType == "string")
    {
        fld.ViewValue = ConvertToString(fld.CurrentValue);
    }
    else
    { // auto
        fld.ViewValue = IsNumeric(fld.CurrentValue)
            ? FormatNumber(fld.CurrentValue, fld.FormatPattern)
            : ConvertToString(fld.CurrentValue);
    }

    // coba dari cache
    if (fld.Lookup != null && IsDictionary(fld.Lookup?.Options) && fld.Lookup?.Options.Values.Count > 0)
    {
        fld.ViewValue = fld.LookupCacheOption(curVal);
        return;
    }

    // fallback: query DB
    var keyField = fld.Lookup?.GetTable()?.Fields[keyFieldName];
    string filterWrk = SearchFilter(keyField?.SearchExpression, "=", fld.CurrentValue, keyField?.SearchDataType, "");
    string? sqlWrk = fld.Lookup?.GetSql(false, filterWrk, null, this, true, true);
    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null;
    if (rswrk?.Count > 0 && fld.Lookup != null)
    {
        var listwrk = fld.Lookup?.RenderViewRow(rswrk[0]);
        fld.ViewValue = fld.DisplayValue(listwrk);
    }
}

        // Confirm page
        public bool ConfirmPage = false; // DN

        #pragma warning disable 1998
        // Get upload files
        public async Task GetUploadFiles()
        {
            // Get upload data
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Helper methods (placed inside the same partial class as LoadFormValues)
        private void SetNormalField(dynamic fld, string fldName, string fldVar, bool includeValidate = false, bool validateFlag = false, bool unformatDate = false) {
            // Determine value once
            string val = CurrentForm.HasValue(fldName) ? CurrentForm.GetValue(fldName) : CurrentForm.GetValue(fldVar);
            if (!fld.IsDetailKey) {
                // API: if field not present in request, disable update
                if (IsApi() && !CurrentForm.HasValue(fldName) && !CurrentForm.HasValue(fldVar))
                    fld.Visible = false; // Disable update for API request
                else {
                    // Call appropriate SetFormValue overload
                    if (includeValidate)
                        fld.SetFormValue(val, true, validateFlag);
                    else
                        fld.SetFormValue(val);
                }
                if (unformatDate)
                    fld.CurrentValue = UnformatDateTime(fld.CurrentValue, fld.FormatPattern);
            }
        }

        private void SetFieldValueWithRaw(dynamic fld, string rawValue) {
            // Helper in case caller wants to set from a raw form object call rather than val computed here
            if (!fld.IsDetailKey) {
                if (IsApi() && string.IsNullOrEmpty(rawValue)) // rawValue empty simulates missing
                    fld.Visible = false;
                else
                    fld.SetFormValue(rawValue);
            }
        }

        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;

            // Standard handling for 'IdUser'
            IdUser.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdUser, "IdUser", "x_IdUser", true, validate, false);
            if (CurrentForm.HasValue("o_IdUser"))
                IdUser.OldValue = CurrentForm.GetValue("o_IdUser");

            // Standard handling for '_Username'
            _Username.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(_Username, "Username", "x__Username");

            // Standard handling for 'LinkRedirect'
            LinkRedirect.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LinkRedirect, "LinkRedirect", "x_LinkRedirect");

            // Standard handling for '_Email'
            _Email.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(_Email, "Email", "x__Email");

            // Standard handling for 'NamaLengkap'
            NamaLengkap.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NamaLengkap, "NamaLengkap", "x_NamaLengkap");

            // Standard handling for 'DownloadFace'
            DownloadFace.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(DownloadFace, "DownloadFace", "x_DownloadFace");

            // Standard handling for 'IdPosition'
            IdPosition.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdPosition, "IdPosition", "x_IdPosition", true, validate, false);

            // Standard handling for 'Jabatan'
            Jabatan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Jabatan, "Jabatan", "x_Jabatan");

            // Standard handling for 'Face'
            Face.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Face, "Face", "x_Face");

            // Standard handling for 'TanggalInputFace'
            TanggalInputFace.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalInputFace, "TanggalInputFace", "x_TanggalInputFace", true, validate, true);

            // Standard handling for 'UserInputFace'
            UserInputFace.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(UserInputFace, "UserInputFace", "x_UserInputFace");

            // Standard handling for 'AzurePersonId'
            AzurePersonId.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(AzurePersonId, "AzurePersonId", "x_AzurePersonId", true, validate, false);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdUser.CurrentValue = IdUser.FormValue;
            _Username.CurrentValue = _Username.FormValue;
            LinkRedirect.CurrentValue = LinkRedirect.FormValue;
            _Email.CurrentValue = _Email.FormValue;
            NamaLengkap.CurrentValue = NamaLengkap.FormValue;
            DownloadFace.CurrentValue = DownloadFace.FormValue;
            IdPosition.CurrentValue = IdPosition.FormValue;
            Jabatan.CurrentValue = Jabatan.FormValue;
            Face.CurrentValue = Face.FormValue;
            TanggalInputFace.CurrentValue = TanggalInputFace.FormValue;
            TanggalInputFace.CurrentValue = UnformatDateTime(TanggalInputFace.CurrentValue, TanggalInputFace.FormatPattern);
            UserInputFace.CurrentValue = UserInputFace.FormValue;
            AzurePersonId.CurrentValue = AzurePersonId.FormValue;
        }

        // Load row based on key values
        public async Task<bool> LoadRow()
        {
            string filter = GetRecordFilter();

            // Call Row Selecting event
            RowSelecting(ref filter);

            // Load SQL based on filter
            CurrentFilter = filter;
            string sql = CurrentSql;
            bool res = false;
            try {
                var row = await Connection.GetRowAsync(sql);
                if (row != null) {
                    await LoadRowValues(row);
                    res = true;
                } else {
                    return false;
                }
            } catch {
                if (Config.Debug)
                    throw;
            }
            return res;
        }

        #pragma warning disable 162, 168, 1998, 4014
        // Load row values from data reader
        public async Task LoadRowValues(DbDataReader? dr = null) => await LoadRowValues(GetDictionary(dr));

        // Load row values from recordset
        public async Task LoadRowValues(Dictionary<string, object>? row)
        {
            row ??= NewRow();

            // Call Row Selected event
            RowSelected(row);
            IdUser.SetDbValue(row["IdUser"]);
            _Username.SetDbValue(row["Username"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            _Email.SetDbValue(row["Email"]);
            NamaLengkap.SetDbValue(row["NamaLengkap"]);
            DownloadFace.SetDbValue(row["DownloadFace"]);
            IdPosition.SetDbValue(row["IdPosition"]);
            Jabatan.SetDbValue(row["Jabatan"]);
            Face.SetDbValue(row["Face"]);
            TanggalInputFace.SetDbValue(row["TanggalInputFace"]);
            UserInputFace.SetDbValue(row["UserInputFace"]);
            AzurePersonId.SetDbValue(row["AzurePersonId"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdUser", IdUser.DefaultValue ?? DbNullValue); // DN
            row.Add("Username", _Username.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaLengkap", NamaLengkap.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadFace", DownloadFace.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPosition", IdPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("Jabatan", Jabatan.DefaultValue ?? DbNullValue); // DN
            row.Add("Face", Face.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalInputFace", TanggalInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("UserInputFace", UserInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("AzurePersonId", AzurePersonId.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 618, 1998
        // Load old record
        protected async Task<Dictionary<string, object>?> LoadOldRecord(DatabaseConnection<SqlConnection, SqlDbType>? cnn = null) {
            // Load old record
            Dictionary<string, object>? row = null;
            bool validKey = !Empty(OldKey);
            if (validKey) {
                SetKey(OldKey);
                CurrentFilter = GetRecordFilter();
                string sql = CurrentSql;
                try {
                    row = await (cnn ?? Connection).GetRowAsync(sql);
                } catch {
                    row = null;
                }
            }
            await LoadRowValues(row); // Load row values
            return row;
        }
        #pragma warning restore 618, 1998

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // IdUser
            IdUser.RowCssClass = "row";

            // Username
            _Username.RowCssClass = "row";

            // LinkRedirect
            LinkRedirect.RowCssClass = "row";

            // Email
            _Email.RowCssClass = "row";

            // NamaLengkap
            NamaLengkap.RowCssClass = "row";

            // DownloadFace
            DownloadFace.RowCssClass = "row";

            // IdPosition
            IdPosition.RowCssClass = "row";

            // Jabatan
            Jabatan.RowCssClass = "row";

            // Face
            Face.RowCssClass = "row";

            // TanggalInputFace
            TanggalInputFace.RowCssClass = "row";

            // UserInputFace
            UserInputFace.RowCssClass = "row";

            // AzurePersonId
            AzurePersonId.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // Username

                // LinkRedirect

                // Email

                // NamaLengkap

                // DownloadFace

                // IdPosition

                // Jabatan

                // Face

                // TanggalInputFace

                // UserInputFace

                // AzurePersonId

                    // IdUser
                    IdUser.ViewValue = IdUser.CurrentValue;
                    IdUser.ViewValue = FormatNumber(IdUser.ViewValue, IdUser.FormatPattern);
                    IdUser.ViewCustomAttributes = "";

                    // Username
                    _Username.ViewValue = ConvertToString(_Username.CurrentValue); // DN
                    _Username.ViewCustomAttributes = "";

                    // LinkRedirect
                    LinkRedirect.ViewValue = ConvertToString(LinkRedirect.CurrentValue); // DN
                    LinkRedirect.ViewCustomAttributes = "";

                    // Email
                    _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                    _Email.ViewCustomAttributes = "";

                    // NamaLengkap
                    NamaLengkap.ViewValue = ConvertToString(NamaLengkap.CurrentValue); // DN
                    NamaLengkap.ViewCustomAttributes = "";

                    // DownloadFace
                    DownloadFace.ViewValue = DownloadFace.CurrentValue;
                    DownloadFace.ViewCustomAttributes = "";

                    // IdPosition
                    IdPosition.ViewValue = IdPosition.CurrentValue;

                    // awallookupbung
                    // IdPosition
                    ResolveLookupView(IdPosition, "IdPosition", "number");
                    // akhirlookupbung
                    IdPosition.ViewCustomAttributes = "";

                    // Jabatan
                    Jabatan.ViewValue = ConvertToString(Jabatan.CurrentValue); // DN
                    Jabatan.ViewCustomAttributes = "";

                    // Face
                    Face.ViewValue = ConvertToString(Face.CurrentValue); // DN
                    Face.ViewCustomAttributes = "";

                    // TanggalInputFace
                    TanggalInputFace.ViewValue = TanggalInputFace.CurrentValue;
                    TanggalInputFace.ViewValue = FormatDateTime(TanggalInputFace.ViewValue, TanggalInputFace.FormatPattern);
                    TanggalInputFace.ViewCustomAttributes = "";

                    // UserInputFace
                    UserInputFace.ViewValue = ConvertToString(UserInputFace.CurrentValue); // DN
                    UserInputFace.ViewCustomAttributes = "";

                    // AzurePersonId
                    AzurePersonId.ViewValue = ConvertToString(AzurePersonId.CurrentValue); // DN
                    AzurePersonId.ViewCustomAttributes = "";

                // IdUser
                IdUser.HrefValue = "";

                // Username
                _Username.HrefValue = "";
                _Username.TooltipValue = "";

                // LinkRedirect
                LinkRedirect.HrefValue = "";

                // Email
                _Email.HrefValue = "";
                _Email.TooltipValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";
                NamaLengkap.TooltipValue = "";

                // DownloadFace
                DownloadFace.HrefValue = "";
                DownloadFace.TooltipValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // Jabatan
                Jabatan.HrefValue = "";

                // Face
                Face.HrefValue = "";

                // TanggalInputFace
                TanggalInputFace.HrefValue = "";

                // UserInputFace
                UserInputFace.HrefValue = "";

                // AzurePersonId
                AzurePersonId.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // IdUser
                IdUser.SetupEditAttributes();
                IdUser.EditValue = IdUser.CurrentValue;
                IdUser.PlaceHolder = RemoveHtml(IdUser.Caption);

                // Username
                _Username.SetupEditAttributes();
                _Username.EditValue = ConvertToString(_Username.CurrentValue); // DN
                _Username.ViewCustomAttributes = "";

                // LinkRedirect
                LinkRedirect.SetupEditAttributes();
                if (!LinkRedirect.Raw)
                    LinkRedirect.CurrentValue = HtmlDecode(LinkRedirect.CurrentValue);
                LinkRedirect.EditValue = HtmlEncode(LinkRedirect.CurrentValue);
                LinkRedirect.PlaceHolder = RemoveHtml(LinkRedirect.Caption);

                // Email
                _Email.SetupEditAttributes();
                _Email.EditValue = ConvertToString(_Email.CurrentValue); // DN
                _Email.ViewCustomAttributes = "";

                // NamaLengkap
                NamaLengkap.SetupEditAttributes();
                NamaLengkap.EditValue = ConvertToString(NamaLengkap.CurrentValue); // DN
                NamaLengkap.ViewCustomAttributes = "";

                // DownloadFace
                DownloadFace.SetupEditAttributes();
                DownloadFace.EditValue = DownloadFace.CurrentValue;
                DownloadFace.ViewCustomAttributes = "";

                // IdPosition
                IdPosition.SetupEditAttributes();
                IdPosition.EditValue = IdPosition.CurrentValue;

                // awallookupbung
                string curVal = ConvertToString(IdPosition.CurrentValue);
                IdPosition.EditValue = Empty(curVal) ? DbNullValue : HtmlEncode(FormatNumber(IdPosition.CurrentValue, IdPosition.FormatPattern));
                if (!Empty(curVal)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.EditValue = IdPosition.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.CurrentValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk = IdPosition.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk[0]);
                            IdPosition.EditValue = IdPosition.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                IdPosition.PlaceHolder = RemoveHtml(IdPosition.Caption);
                if (!Empty(IdPosition.EditValue) && IsNumeric(IdPosition.EditValue))
                    IdPosition.EditValue = FormatNumber(IdPosition.EditValue, null);

                // Jabatan
                Jabatan.SetupEditAttributes();
                if (!Jabatan.Raw)
                    Jabatan.CurrentValue = HtmlDecode(Jabatan.CurrentValue);
                Jabatan.EditValue = HtmlEncode(Jabatan.CurrentValue);
                Jabatan.PlaceHolder = RemoveHtml(Jabatan.Caption);

                // Face
                Face.SetupEditAttributes();
                if (!Face.Raw)
                    Face.CurrentValue = HtmlDecode(Face.CurrentValue);
                Face.EditValue = HtmlEncode(Face.CurrentValue);
                Face.PlaceHolder = RemoveHtml(Face.Caption);

                // TanggalInputFace
                TanggalInputFace.SetupEditAttributes();
                TanggalInputFace.EditValue = FormatDateTime(TanggalInputFace.CurrentValue, TanggalInputFace.FormatPattern);
                TanggalInputFace.PlaceHolder = RemoveHtml(TanggalInputFace.Caption);

                // UserInputFace
                UserInputFace.SetupEditAttributes();
                if (!UserInputFace.Raw)
                    UserInputFace.CurrentValue = HtmlDecode(UserInputFace.CurrentValue);
                UserInputFace.EditValue = HtmlEncode(UserInputFace.CurrentValue);
                UserInputFace.PlaceHolder = RemoveHtml(UserInputFace.Caption);

                // AzurePersonId
                AzurePersonId.SetupEditAttributes();
                AzurePersonId.EditValue = AzurePersonId.CurrentValue;
                AzurePersonId.PlaceHolder = RemoveHtml(AzurePersonId.Caption);

                // Edit refer script

                // IdUser
                IdUser.HrefValue = "";

                // Username
                _Username.HrefValue = "";
                _Username.TooltipValue = "";

                // LinkRedirect
                LinkRedirect.HrefValue = "";

                // Email
                _Email.HrefValue = "";
                _Email.TooltipValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";
                NamaLengkap.TooltipValue = "";

                // DownloadFace
                DownloadFace.HrefValue = "";
                DownloadFace.TooltipValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // Jabatan
                Jabatan.HrefValue = "";

                // Face
                Face.HrefValue = "";

                // TanggalInputFace
                TanggalInputFace.HrefValue = "";

                // UserInputFace
                UserInputFace.HrefValue = "";

                // AzurePersonId
                AzurePersonId.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();

            // Save data for Custom Template
            if (RowType == RowType.View || RowType == RowType.Edit || RowType == RowType.Add)
                Rows.Add(CustomTemplateFieldValues());
        }
        #pragma warning restore 1998

        #pragma warning disable 1998

        private void ValidateCustomIdUser() {
            if (IdUser.Visible && IdUser.Required) {
                if (!IdUser.IsDetailKey && Empty(IdUser.FormValue)) {
                    IdUser.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustom_Username() {
            if (_Username.Visible && _Username.Required) {
                if (!_Username.IsDetailKey && Empty(_Username.FormValue)) {
                    _Username.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomLinkRedirect() {
            if (LinkRedirect.Visible && LinkRedirect.Required) {
                if (!LinkRedirect.IsDetailKey && Empty(LinkRedirect.FormValue)) {
                    LinkRedirect.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustom_Email() {
            if (_Email.Visible && _Email.Required) {
                if (!_Email.IsDetailKey && Empty(_Email.FormValue)) {
                    _Email.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomNamaLengkap() {
            if (NamaLengkap.Visible && NamaLengkap.Required) {
                if (!NamaLengkap.IsDetailKey && Empty(NamaLengkap.FormValue)) {
                    NamaLengkap.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomDownloadFace() {
            if (DownloadFace.Visible && DownloadFace.Required) {
                if (!DownloadFace.IsDetailKey && Empty(DownloadFace.FormValue)) {
                    DownloadFace.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomIdPosition() {
            if (IdPosition.Visible && IdPosition.Required) {
                if (!IdPosition.IsDetailKey && Empty(IdPosition.FormValue)) {
                    IdPosition.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomJabatan() {
            if (Jabatan.Visible && Jabatan.Required) {
                if (!Jabatan.IsDetailKey && Empty(Jabatan.FormValue)) {
                    Jabatan.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomFace() {
            if (Face.Visible && Face.Required) {
                if (!Face.IsDetailKey && Empty(Face.FormValue)) {
                    Face.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomTanggalInputFace() {
            if (TanggalInputFace.Visible && TanggalInputFace.Required) {
                if (!TanggalInputFace.IsDetailKey && Empty(TanggalInputFace.FormValue)) {
                    TanggalInputFace.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomUserInputFace() {
            if (UserInputFace.Visible && UserInputFace.Required) {
                if (!UserInputFace.IsDetailKey && Empty(UserInputFace.FormValue)) {
                    UserInputFace.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        private void ValidateCustomAzurePersonId() {
            if (AzurePersonId.Visible && AzurePersonId.Required) {
                if (!AzurePersonId.IsDetailKey && Empty(AzurePersonId.FormValue)) {
                    AzurePersonId.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomIdUser();
                if (!CheckInteger(IdUser.FormValue)) {
                    IdUser.AddErrorMessage(IdUser.GetErrorMessage(false));
                }
                ValidateCustom_Username();
                ValidateCustomLinkRedirect();
                ValidateCustom_Email();
                ValidateCustomNamaLengkap();
                ValidateCustomDownloadFace();
                ValidateCustomIdPosition();
                if (!CheckInteger(IdPosition.FormValue)) {
                    IdPosition.AddErrorMessage(IdPosition.GetErrorMessage(false));
                }
                ValidateCustomJabatan();
                ValidateCustomFace();
                ValidateCustomTanggalInputFace();
                if (!CheckDate(TanggalInputFace.FormValue, TanggalInputFace.FormatPattern)) {
                    TanggalInputFace.AddErrorMessage(TanggalInputFace.GetErrorMessage(false));
                }
                ValidateCustomUserInputFace();
                ValidateCustomAzurePersonId();
                if (!CheckGuid(AzurePersonId.FormValue)) {
                    AzurePersonId.AddErrorMessage(AzurePersonId.GetErrorMessage(false));
                }

            // Return validate result
            validateForm = validateForm && !HasInvalidFields();

            // Call Form CustomValidate event
            string formCustomError = "";
            validateForm = validateForm && FormCustomValidate(ref formCustomError);
            if (!Empty(formCustomError))
                FailureMessage = formCustomError;
            return validateForm;
        }
        #pragma warning restore 1998

        // Update record based on key values
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> EditRow() { // DN
            bool result = false;
            Dictionary<string, object>? rsold;
            string oldKeyFilter = GetRecordFilter();
            string filter = ApplyUserIDFilters(oldKeyFilter);

            // Load old row
            CurrentFilter = filter;
            string sql = CurrentSql;
            try {
                rsold = await Connection.GetRowAsync(sql);
                if (rsold == null) {
                    FailureMessage = Language.Phrase("NoRecord"); // Set no record message
                    return JsonBoolResult.FalseResult;
                }
                LoadDbValues(rsold);
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }

            // Get new row
            Dictionary<string, object> rsnew = GetEditRow(rsold);

            // Update current values
            SetCurrentValues(rsnew);

            // Call Row Updating event
            bool updateRow = RowUpdating(rsold, rsnew);

            // Check for duplicate key when key changed
            if (updateRow) {
                string newKeyFilter = GetRecordFilter(rsnew);
                if (newKeyFilter != oldKeyFilter) {
                    if (await GetQueryBuilder().WhereRaw(newKeyFilter).ExistsAsync()) { // DN
                        FailureMessage = Language.Phrase("DupKey").Replace("%f", newKeyFilter);
                        updateRow = false;
                    }
                }
            }
            if (updateRow) {
                try {
                    if (rsnew.Count > 0)
                        result = await UpdateAsync(rsnew, null, rsold) > 0;
                    else
                        result = true;
                    if (result) {
                    }
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    return JsonBoolResult.FalseResult;
                }
            } else {
                if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                    // Use the message, do nothing
                } else if (!Empty(CancelMessage)) {
                    FailureMessage = CancelMessage;
                    CancelMessage = "";
                } else {
                    FailureMessage = Language.Phrase("UpdateCancelled");
                }
                result = false;
            }

            // Call Row Updated event
            if (result)
                RowUpdated(rsold, rsnew);

            // Write JSON for API request
            Dictionary<string, object> d = new();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                if (GetRecordFromDictionary(rsnew) is var row && row != null) {
                    string table = TableVar;
                    d.Add(table, row);
                }
                d.Add("action", Config.ApiEditAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, true);
            }
            return new JsonBoolResult(d, result);
        }

        /// <summary>
        /// Get edit row
        /// </summary>
        /// <param name="rsold">Old row</param>
        /// <returns>New row</returns>
        protected Dictionary<string, object> GetEditRow(Dictionary<string, object> rsold)
        {
            Dictionary<string, object> rsnew = new();

            // IdUser
            IdUser.SetDbValue(rsnew, IdUser.CurrentValue, IdUser.ReadOnly);

            // LinkRedirect
            LinkRedirect.SetDbValue(rsnew, LinkRedirect.CurrentValue, LinkRedirect.ReadOnly);

            // IdPosition
            IdPosition.SetDbValue(rsnew, IdPosition.CurrentValue, IdPosition.ReadOnly);

            // Jabatan
            Jabatan.SetDbValue(rsnew, Jabatan.CurrentValue, Jabatan.ReadOnly);

            // Face
            Face.SetDbValue(rsnew, Face.CurrentValue, Face.ReadOnly);

            // TanggalInputFace
            TanggalInputFace.SetDbValue(rsnew, ConvertToDateTime(TanggalInputFace.CurrentValue, TanggalInputFace.FormatPattern), TanggalInputFace.ReadOnly);

            // UserInputFace
            UserInputFace.SetDbValue(rsnew, UserInputFace.CurrentValue, UserInputFace.ReadOnly);

            // AzurePersonId
            AzurePersonId.SetDbValue(rsnew, ConvertToGuid(AzurePersonId.CurrentValue), AzurePersonId.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("IdUser", out value)) // IdUser
                IdUser.CurrentValue = value;
            if (row.TryGetValue("LinkRedirect", out value)) // LinkRedirect
                LinkRedirect.CurrentValue = value;
            if (row.TryGetValue("IdPosition", out value)) // IdPosition
                IdPosition.CurrentValue = value;
            if (row.TryGetValue("Jabatan", out value)) // Jabatan
                Jabatan.CurrentValue = value;
            if (row.TryGetValue("Face", out value)) // Face
                Face.CurrentValue = value;
            if (row.TryGetValue("TanggalInputFace", out value)) // TanggalInputFace
                TanggalInputFace.CurrentValue = value;
            if (row.TryGetValue("UserInputFace", out value)) // UserInputFace
                UserInputFace.CurrentValue = value;
            if (row.TryGetValue("AzurePersonId", out value)) // AzurePersonId
                AzurePersonId.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("VFaceEnrollmentList")), "", TableVar, true);
            string pageId = "edit";
            breadcrumb.Add("edit", pageId, url);
            CurrentBreadcrumb = breadcrumb;
        }

        // Setup lookup options
        public async Task SetupLookupOptions(DbField fld)
        {
            if (fld.Lookup == null)
                return;
            if (fld.Lookup.Options.Count is int opt && opt > 0) 
                return;
            Func<string>? lookupFilter = null;
            dynamic conn = Connection;

                // Set up lookup SQL

                // Always call to Lookup.GetSql so that user can setup Lookup.Options in Lookup Selecting server event
                var sql = fld.Lookup.GetSql(false, "", lookupFilter, this);

                // Set up lookup cache
                if (fld.HasLookupOptions ||
                    !fld.UseLookupCache ||
                    Empty(sql) ||
                    fld.Lookup.ParentFields.Count != 0 ||
                    fld.Lookup.Options.Count != 0)
                            return;
                int totalCnt = await TryGetRecordCountAsync(sql, conn);
                if (totalCnt > fld.LookupCacheCount) // Total count > cache count, do not cache
                    return;
                var dict = new Dictionary<string, Dictionary<string, object>>();
                List<object> values = [];
                List<Dictionary<string, object>> rs = await conn.GetRowsAsync(sql);
                if (rs != null) {
                    for (int i = 0; i < rs.Count; i++) {
                        var row = rs[i];
                        row = fld.Lookup?.RenderViewRow(row, Resolve(fld.Lookup.LinkTable));
                        string key = row?.Values.First()?.ToString() ?? String.Empty;
                        if (!dict.ContainsKey(key) && row != null)
                            dict.Add(key, row);
                    }
                }
                fld.Lookup?.SetOptions(dict);
        }

        // Close recordset
        public void CloseRecordset()
        {
            using (Recordset) {} // Dispose
        }

        // Set up starting record parameters
        public void SetupStartRecord()
        {
            // Exit if DisplayRecords = 0
            if (DisplayRecords == 0)
                return;
            string pageNo = Get(Config.TablePageNumber);
            string startRec = Get(Config.TableStartRec);
            bool infiniteScroll = false;
            string recordNo = !Empty(pageNo) ? pageNo : startRec; // Record number = page number or start record
            if (!Empty(recordNo) && IsNumeric(recordNo))
                StartRecord = ConvertToInt(recordNo);
            else
                StartRecord = StartRecordNumber;

            // Check if correct start record counter
            if (StartRecord <= 0) // Avoid invalid start record counter
                StartRecord = 1; // Reset start record counter
            else if (StartRecord > TotalRecords) // Avoid starting record > total records
                StartRecord = ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1; // Point to last page first record
            else if ((StartRecord - 1) % DisplayRecords != 0)
                StartRecord = ((StartRecord - 1) / DisplayRecords) * DisplayRecords + 1; // Point to page boundary
            if (!infiniteScroll)
                StartRecordNumber = StartRecord;
        }

        // Get page count
        public int PageCount
        {
            get {
                return ConvertToInt(Math.Ceiling((double)TotalRecords / DisplayRecords));
            }
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

        // Page Load event
        public virtual void PageRender() {
            //Log("Page Render");
        }

        // Page Data Rendering event
        public virtual void PageDataRendering(ref string header) {
            // Example:
            //header = "your header";
        }

        // Page Data Rendered event
        public virtual void PageDataRendered(ref string footer) {
            // Example:
            //footer = "your footer";
        }

        // Page Breaking event
        public void PageBreaking(ref bool brk, ref string content) {
            // Example:
            //	brk = false; // Skip page break, or
            //	content = "<div style=\"page-break-after:always;\">&nbsp;</div>"; // Modify page break content
        }

        // Form Custom Validate event
        public virtual bool FormCustomValidate(ref string customError) {
            //Return error message in customError
            return true;
        }
    } // End page class
} // End Partial class
