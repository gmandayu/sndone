using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasFormInputBLnSfalrtwAdd
    /// </summary>
    public static SubAktivitasFormInputBLnSfalrtwAdd subAktivitasFormInputBLnSfalrtwAdd
    {
        get => HttpData.Get<SubAktivitasFormInputBLnSfalrtwAdd>("subAktivitasFormInputBLnSfalrtwAdd")!;
        set => HttpData["subAktivitasFormInputBLnSfalrtwAdd"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasFormInputBLnSFALRTW
    /// </summary>
    public class SubAktivitasFormInputBLnSfalrtwAdd : SubAktivitasFormInputBLnSfalrtwAddBase
    {
        // Constructor
        public SubAktivitasFormInputBLnSfalrtwAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasFormInputBLnSfalrtwAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasFormInputBLnSfalrtwAddBase : SubAktivitasFormInputBLnSfalrtw
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasFormInputBLnSfalrtwAdd";

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
        public SubAktivitasFormInputBLnSfalrtwAddBase(Controller? controller)
        {
            TableName = "SubAktivitasFormInputBLnSFALRTW";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasFormInputBLnSfalrtw)
            if (subAktivitasFormInputBLnSfalrtw == null || subAktivitasFormInputBLnSfalrtw is SubAktivitasFormInputBLnSfalrtw)
                subAktivitasFormInputBLnSfalrtw = this;

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
        public string PageName => "SubAktivitasFormInputBLnSfalrtwAdd";

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
            id.Visible = false;
            idAktifitas.SetVisibility();
            BL_KLObs.SetVisibility();
            BL_KL15.SetVisibility();
            BL_Barrels.SetVisibility();
            BL_LT.SetVisibility();
            BL_MT.SetVisibility();
            SFAL_KLObs.SetVisibility();
            SFAL_KL15.SetVisibility();
            SFAL_Barrels.SetVisibility();
            SFAL_LT.SetVisibility();
            SFAL_MT.SetVisibility();
            userInput.SetVisibility();
            etlDate.SetVisibility();
            idProses.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            NoReferensi.SetVisibility();
            StatusAktivitas.SetVisibility();
        }

        // Constructor
        public SubAktivitasFormInputBLnSfalrtwAddBase() : this(null) { }

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
                        result.Add("view", pageName == "SubAktivitasFormInputBLnSfalrtwView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("id") ? dict["id"] : id.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                id.Visible = false;
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

        // Properties
        public string FormClassName = "ew-form ew-add-form";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public int StartRecord;

        public DbDataReader? Recordset = null; // Reserved // DN

        public bool CopyRecord;

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            var beginResult = await PageRunBeginAsync();
            if (beginResult != null) return beginResult;

            // === VARIABLES YANG DIAKSES MULTI-SECTION - TETAP DI RUN() ===
            bool postBack = false;
            StringValues sv;

            // === HELPER METHOD CALLS ===
            PrepareInitialSettings();
            var actionSetup = SetupCurrentAction();
            postBack = actionSetup.PostBack;
            sv = actionSetup.StringValues;
            CurrentAction = actionSetup.CurrentAction;
            var rsold = await LoadOldRecord();
            SetupMasterParameters();
            if (postBack) {
                await LoadFormValues();
                await SetupCaptchaAndDetails();
                if (!await ValidateForm()) {
                    EventCancelled = true;
                    RestoreFormValues();
                    if (IsApi())
                        return Terminate();
                    else
                        CurrentAction = "show";
                }
            }
            var actionResult = await ExecuteCurrentAction(rsold);
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

        private ActionSetupResult SetupCurrentAction()
        {
            var result = new ActionSetupResult();
            if (IsApi()) {
                result.CurrentAction = "insert";
                result.PostBack = true;
            } else if (!Empty(Post("action"))) {
                result.CurrentAction = Post("action");
                if (Post(OldKeyName, out StringValues sv)) {
                    SetKey(sv.ToString());
                    result.StringValues = sv;
                }
                result.PostBack = true;
            } else {
                result.CurrentAction = HandleNonPostBackAction();
            }
            return result;
        }

        private string HandleNonPostBackAction()
        {
            string[] keyValues = {};
            object? rv;
            StringValues sv;
            if (RouteValues.TryGetValue("key", out object? k))
                keyValues = ConvertToString(k).Split('/');
            if (RouteValues.TryGetValue("id", out rv)) {
                id.QueryValue = UrlDecode(rv);
            } else if (Get("id", out sv)) {
                id.QueryValue = sv.ToString();
            }
            OldKey = GetKey(true);
            CopyRecord = !Empty(OldKey);
            if (CopyRecord) {
                SetKey(OldKey);
                return "copy";
            } else {
                return "show";
            }
        }

        private void SetupMasterParameters()
        {
        }

        private async Task SetupCaptchaAndDetails()
        {
        }

        private async Task<IActionResult?> ExecuteCurrentAction(Dictionary<string, object>? rsold)
        {
            switch (CurrentAction) {
                case "copy":
                    return HandleCopyAction(rsold);
                case "insert":
                    return await HandleInsertAction(rsold);
            }
            return null;
        }

        private IActionResult? HandleCopyAction(Dictionary<string, object>? rsold)
        {
            if (rsold == null) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("NoRecord");
                return Terminate("SubAktivitasFormInputBLnSfalrtwList");
            }
            return null;
        }

        private async Task<IActionResult?> HandleInsertAction(Dictionary<string, object>? rsold)
        {
            SendEmail = true;
            var res = await AddRow(rsold);
            if (res) {
                return await HandleSuccessfulInsert(res);
            } else if (IsApi()) {
                return Terminate();
            } else {
                EventCancelled = true;
                RestoreFormValues();
                return null;
            }
        }

        private async Task<IActionResult> HandleSuccessfulInsert(JsonBoolResult res)
        {
            if (Empty(SuccessMessage) && Post("addopt") != "1")
                SuccessMessage = Language.Phrase("AddSuccess");
            string returnUrl = DetermineReturnUrl();
            HandleAjaxActions(ref returnUrl);
            if (IsJsonResponse()) {
                ClearMessages();
                return res;
            } else {
                return Terminate(returnUrl);
            }
        }

        private string DetermineReturnUrl()
        {
            string returnUrl = "";
            returnUrl = ReturnUrl;
            if (GetPageName(returnUrl) == "SubAktivitasFormInputBLnSfalrtwList")
                returnUrl = AddMasterUrl(ListUrl);
            else if (GetPageName(returnUrl) == "SubAktivitasFormInputBLnSfalrtwView")
                returnUrl = ViewUrl;
            return returnUrl;
        }

        private void HandleAjaxActions(ref string returnUrl)
        {
            if (IsModal && UseAjaxActions) {
                IsModal = false;
                if (GetPageName(returnUrl) != "SubAktivitasFormInputBLnSfalrtwList") {
                    TempData["Return-Url"] = returnUrl;
                    returnUrl = "SubAktivitasFormInputBLnSfalrtwList";
                }
            }
        }

        private async Task PrepareForRender()
        {
            SetupBreadcrumb();
            RowType = RowType.Add;
            ResetAttributes();
            await RenderRow();
        }

        private async Task<IActionResult?> PageRunBeginAsync()
        {
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
                    await SetupLookupOptions(idAktifitas);
                    await SetupLookupOptions(idProses);
                    await SetupLookupOptions(StatusAktivitas);

                    // Load default values for add
                    LoadDefaultValues();
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
                        subAktivitasFormInputBLnSfalrtwAdd?.PageRender();
                    }
        }

        // Support class
        private sealed class ActionSetupResult
        {
            public string CurrentAction { get; set; } = "";

            public bool PostBack { get; set; }

            public StringValues StringValues { get; set; }
        }

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

        // Load default values
        protected void LoadDefaultValues() {
            // If empty means, all condition is not fulfilled
        }

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

            // Standard handling for 'idAktifitas'
            idAktifitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idAktifitas, "idAktifitas", "x_idAktifitas", true, validate, false);

            // Standard handling for 'BL_KLObs'
            BL_KLObs.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(BL_KLObs, "BL_KLObs", "x_BL_KLObs");

            // Standard handling for 'BL_KL15'
            BL_KL15.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(BL_KL15, "BL_KL15", "x_BL_KL15");

            // Standard handling for 'BL_Barrels'
            BL_Barrels.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(BL_Barrels, "BL_Barrels", "x_BL_Barrels");

            // Standard handling for 'BL_LT'
            BL_LT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(BL_LT, "BL_LT", "x_BL_LT");

            // Standard handling for 'BL_MT'
            BL_MT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(BL_MT, "BL_MT", "x_BL_MT");

            // Standard handling for 'SFAL_KLObs'
            SFAL_KLObs.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAL_KLObs, "SFAL_KLObs", "x_SFAL_KLObs");

            // Standard handling for 'SFAL_KL15'
            SFAL_KL15.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAL_KL15, "SFAL_KL15", "x_SFAL_KL15");

            // Standard handling for 'SFAL_Barrels'
            SFAL_Barrels.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAL_Barrels, "SFAL_Barrels", "x_SFAL_Barrels");

            // Standard handling for 'SFAL_LT'
            SFAL_LT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAL_LT, "SFAL_LT", "x_SFAL_LT");

            // Standard handling for 'SFAL_MT'
            SFAL_MT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAL_MT, "SFAL_MT", "x_SFAL_MT");

            // Standard handling for 'userInput'
            userInput.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(userInput, "userInput", "x_userInput");

            // Standard handling for 'etlDate'
            etlDate.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(etlDate, "etlDate", "x_etlDate", true, validate, true);

            // Standard handling for 'idProses'
            idProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idProses, "idProses", "x_idProses", true, validate, false);

            // Standard handling for 'LastUpdatedBy'
            LastUpdatedBy.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LastUpdatedBy, "LastUpdatedBy", "x_LastUpdatedBy");

            // Standard handling for 'lastUpdatedDate'
            lastUpdatedDate.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(lastUpdatedDate, "lastUpdatedDate", "x_lastUpdatedDate", true, validate, true);

            // Standard handling for 'NoReferensi'
            NoReferensi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NoReferensi, "NoReferensi", "x_NoReferensi");

            // Standard handling for 'StatusAktivitas'
            StatusAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(StatusAktivitas, "StatusAktivitas", "x_StatusAktivitas", true, validate, false);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            BL_KLObs.CurrentValue = BL_KLObs.FormValue;
            BL_KL15.CurrentValue = BL_KL15.FormValue;
            BL_Barrels.CurrentValue = BL_Barrels.FormValue;
            BL_LT.CurrentValue = BL_LT.FormValue;
            BL_MT.CurrentValue = BL_MT.FormValue;
            SFAL_KLObs.CurrentValue = SFAL_KLObs.FormValue;
            SFAL_KL15.CurrentValue = SFAL_KL15.FormValue;
            SFAL_Barrels.CurrentValue = SFAL_Barrels.FormValue;
            SFAL_LT.CurrentValue = SFAL_LT.FormValue;
            SFAL_MT.CurrentValue = SFAL_MT.FormValue;
            userInput.CurrentValue = userInput.FormValue;
            etlDate.CurrentValue = etlDate.FormValue;
            etlDate.CurrentValue = UnformatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            idProses.CurrentValue = idProses.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
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
            id.SetDbValue(row["id"]);
            idAktifitas.SetDbValue(row["idAktifitas"]);
            BL_KLObs.SetDbValue(row["BL_KLObs"]);
            BL_KL15.SetDbValue(row["BL_KL15"]);
            BL_Barrels.SetDbValue(row["BL_Barrels"]);
            BL_LT.SetDbValue(row["BL_LT"]);
            BL_MT.SetDbValue(row["BL_MT"]);
            SFAL_KLObs.SetDbValue(row["SFAL_KLObs"]);
            SFAL_KL15.SetDbValue(row["SFAL_KL15"]);
            SFAL_Barrels.SetDbValue(row["SFAL_Barrels"]);
            SFAL_LT.SetDbValue(row["SFAL_LT"]);
            SFAL_MT.SetDbValue(row["SFAL_MT"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            idProses.SetDbValue(row["idProses"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            NoReferensi.SetDbValue(row["NoReferensi"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_KLObs", BL_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_KL15", BL_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_Barrels", BL_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_LT", BL_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_MT", BL_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAL_KLObs", SFAL_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAL_KL15", SFAL_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAL_Barrels", SFAL_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAL_LT", SFAL_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAL_MT", SFAL_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
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

            // id
            id.RowCssClass = "row";

            // idAktifitas
            idAktifitas.RowCssClass = "row";

            // BL_KLObs
            BL_KLObs.RowCssClass = "row";

            // BL_KL15
            BL_KL15.RowCssClass = "row";

            // BL_Barrels
            BL_Barrels.RowCssClass = "row";

            // BL_LT
            BL_LT.RowCssClass = "row";

            // BL_MT
            BL_MT.RowCssClass = "row";

            // SFAL_KLObs
            SFAL_KLObs.RowCssClass = "row";

            // SFAL_KL15
            SFAL_KL15.RowCssClass = "row";

            // SFAL_Barrels
            SFAL_Barrels.RowCssClass = "row";

            // SFAL_LT
            SFAL_LT.RowCssClass = "row";

            // SFAL_MT
            SFAL_MT.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // idProses
            idProses.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // idAktifitas

                // BL_KLObs

                // BL_KL15

                // BL_Barrels

                // BL_LT

                // BL_MT

                // SFAL_KLObs

                // SFAL_KL15

                // SFAL_Barrels

                // SFAL_LT

                // SFAL_MT

                // userInput

                // etlDate

                // idProses

                // LastUpdatedBy

                // lastUpdatedDate

                // NoReferensi

                // StatusAktivitas

                    // id
                    id.ViewValue = id.CurrentValue;
                    id.ViewCustomAttributes = "";

                    // idAktifitas
                    idAktifitas.ViewValue = idAktifitas.CurrentValue;

                    // awallookupbung
                    // idAktifitas
                    ResolveLookupView(idAktifitas, "IdAktivitas", "number");
                    // akhirlookupbung
                    idAktifitas.ViewCustomAttributes = "";

                    // BL_KLObs
                    BL_KLObs.ViewValue = ConvertToString(BL_KLObs.CurrentValue); // DN
                    BL_KLObs.ViewCustomAttributes = "";

                    // BL_KL15
                    BL_KL15.ViewValue = ConvertToString(BL_KL15.CurrentValue); // DN
                    BL_KL15.ViewCustomAttributes = "";

                    // BL_Barrels
                    BL_Barrels.ViewValue = ConvertToString(BL_Barrels.CurrentValue); // DN
                    BL_Barrels.ViewCustomAttributes = "";

                    // BL_LT
                    BL_LT.ViewValue = ConvertToString(BL_LT.CurrentValue); // DN
                    BL_LT.ViewCustomAttributes = "";

                    // BL_MT
                    BL_MT.ViewValue = ConvertToString(BL_MT.CurrentValue); // DN
                    BL_MT.ViewCustomAttributes = "";

                    // SFAL_KLObs
                    SFAL_KLObs.ViewValue = ConvertToString(SFAL_KLObs.CurrentValue); // DN
                    SFAL_KLObs.ViewCustomAttributes = "";

                    // SFAL_KL15
                    SFAL_KL15.ViewValue = ConvertToString(SFAL_KL15.CurrentValue); // DN
                    SFAL_KL15.ViewCustomAttributes = "";

                    // SFAL_Barrels
                    SFAL_Barrels.ViewValue = ConvertToString(SFAL_Barrels.CurrentValue); // DN
                    SFAL_Barrels.ViewCustomAttributes = "";

                    // SFAL_LT
                    SFAL_LT.ViewValue = ConvertToString(SFAL_LT.CurrentValue); // DN
                    SFAL_LT.ViewCustomAttributes = "";

                    // SFAL_MT
                    SFAL_MT.ViewValue = ConvertToString(SFAL_MT.CurrentValue); // DN
                    SFAL_MT.ViewCustomAttributes = "";

                    // userInput
                    userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                    userInput.ViewCustomAttributes = "";

                    // etlDate
                    etlDate.ViewValue = etlDate.CurrentValue;
                    etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                    etlDate.ViewCustomAttributes = "";

                    // idProses
                    idProses.ViewValue = idProses.CurrentValue;

                    // awallookupbung
                    // idProses
                    ResolveLookupView(idProses, "IdProses", "number");
                    // akhirlookupbung
                    idProses.ViewCustomAttributes = "";

                    // LastUpdatedBy
                    LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                    LastUpdatedBy.ViewCustomAttributes = "";

                    // lastUpdatedDate
                    lastUpdatedDate.ViewValue = lastUpdatedDate.CurrentValue;
                    lastUpdatedDate.ViewValue = FormatDateTime(lastUpdatedDate.ViewValue, lastUpdatedDate.FormatPattern);
                    lastUpdatedDate.ViewCustomAttributes = "";

                    // NoReferensi
                    NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                    NoReferensi.ViewCustomAttributes = "";

                    // StatusAktivitas
                    StatusAktivitas.ViewValue = StatusAktivitas.CurrentValue;

                    // awallookupbung
                    // StatusAktivitas
                    ResolveLookupView(StatusAktivitas, "IdAktivitas", "number");
                    // akhirlookupbung
                    StatusAktivitas.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // BL_KLObs
                BL_KLObs.HrefValue = "";

                // BL_KL15
                BL_KL15.HrefValue = "";

                // BL_Barrels
                BL_Barrels.HrefValue = "";

                // BL_LT
                BL_LT.HrefValue = "";

                // BL_MT
                BL_MT.HrefValue = "";

                // SFAL_KLObs
                SFAL_KLObs.HrefValue = "";

                // SFAL_KL15
                SFAL_KL15.HrefValue = "";

                // SFAL_Barrels
                SFAL_Barrels.HrefValue = "";

                // SFAL_LT
                SFAL_LT.HrefValue = "";

                // SFAL_MT
                SFAL_MT.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";
            } else if (RowType == RowType.Add) {
                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;

                // awallookupbung
                string curVal = ConvertToString(idAktifitas.CurrentValue);
                idAktifitas.EditValue = Empty(curVal) ? DbNullValue : HtmlEncode(FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern));
                if (!Empty(curVal)) {
                    if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idAktifitas.EditValue = idAktifitas.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk = idAktifitas.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                            var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk[0]);
                            idAktifitas.EditValue = idAktifitas.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                idAktifitas.PlaceHolder = RemoveHtml(idAktifitas.Caption);
                if (!Empty(idAktifitas.EditValue) && IsNumeric(idAktifitas.EditValue))
                    idAktifitas.EditValue = FormatNumber(idAktifitas.EditValue, null);

                // BL_KLObs
                BL_KLObs.SetupEditAttributes();
                if (!BL_KLObs.Raw)
                    BL_KLObs.CurrentValue = HtmlDecode(BL_KLObs.CurrentValue);
                BL_KLObs.EditValue = HtmlEncode(BL_KLObs.CurrentValue);
                BL_KLObs.PlaceHolder = RemoveHtml(BL_KLObs.Caption);

                // BL_KL15
                BL_KL15.SetupEditAttributes();
                if (!BL_KL15.Raw)
                    BL_KL15.CurrentValue = HtmlDecode(BL_KL15.CurrentValue);
                BL_KL15.EditValue = HtmlEncode(BL_KL15.CurrentValue);
                BL_KL15.PlaceHolder = RemoveHtml(BL_KL15.Caption);

                // BL_Barrels
                BL_Barrels.SetupEditAttributes();
                if (!BL_Barrels.Raw)
                    BL_Barrels.CurrentValue = HtmlDecode(BL_Barrels.CurrentValue);
                BL_Barrels.EditValue = HtmlEncode(BL_Barrels.CurrentValue);
                BL_Barrels.PlaceHolder = RemoveHtml(BL_Barrels.Caption);

                // BL_LT
                BL_LT.SetupEditAttributes();
                if (!BL_LT.Raw)
                    BL_LT.CurrentValue = HtmlDecode(BL_LT.CurrentValue);
                BL_LT.EditValue = HtmlEncode(BL_LT.CurrentValue);
                BL_LT.PlaceHolder = RemoveHtml(BL_LT.Caption);

                // BL_MT
                BL_MT.SetupEditAttributes();
                if (!BL_MT.Raw)
                    BL_MT.CurrentValue = HtmlDecode(BL_MT.CurrentValue);
                BL_MT.EditValue = HtmlEncode(BL_MT.CurrentValue);
                BL_MT.PlaceHolder = RemoveHtml(BL_MT.Caption);

                // SFAL_KLObs
                SFAL_KLObs.SetupEditAttributes();
                if (!SFAL_KLObs.Raw)
                    SFAL_KLObs.CurrentValue = HtmlDecode(SFAL_KLObs.CurrentValue);
                SFAL_KLObs.EditValue = HtmlEncode(SFAL_KLObs.CurrentValue);
                SFAL_KLObs.PlaceHolder = RemoveHtml(SFAL_KLObs.Caption);

                // SFAL_KL15
                SFAL_KL15.SetupEditAttributes();
                if (!SFAL_KL15.Raw)
                    SFAL_KL15.CurrentValue = HtmlDecode(SFAL_KL15.CurrentValue);
                SFAL_KL15.EditValue = HtmlEncode(SFAL_KL15.CurrentValue);
                SFAL_KL15.PlaceHolder = RemoveHtml(SFAL_KL15.Caption);

                // SFAL_Barrels
                SFAL_Barrels.SetupEditAttributes();
                if (!SFAL_Barrels.Raw)
                    SFAL_Barrels.CurrentValue = HtmlDecode(SFAL_Barrels.CurrentValue);
                SFAL_Barrels.EditValue = HtmlEncode(SFAL_Barrels.CurrentValue);
                SFAL_Barrels.PlaceHolder = RemoveHtml(SFAL_Barrels.Caption);

                // SFAL_LT
                SFAL_LT.SetupEditAttributes();
                if (!SFAL_LT.Raw)
                    SFAL_LT.CurrentValue = HtmlDecode(SFAL_LT.CurrentValue);
                SFAL_LT.EditValue = HtmlEncode(SFAL_LT.CurrentValue);
                SFAL_LT.PlaceHolder = RemoveHtml(SFAL_LT.Caption);

                // SFAL_MT
                SFAL_MT.SetupEditAttributes();
                if (!SFAL_MT.Raw)
                    SFAL_MT.CurrentValue = HtmlDecode(SFAL_MT.CurrentValue);
                SFAL_MT.EditValue = HtmlEncode(SFAL_MT.CurrentValue);
                SFAL_MT.PlaceHolder = RemoveHtml(SFAL_MT.Caption);

                // userInput
                userInput.SetupEditAttributes();
                if (!userInput.Raw)
                    userInput.CurrentValue = HtmlDecode(userInput.CurrentValue);
                userInput.EditValue = HtmlEncode(userInput.CurrentValue);
                userInput.PlaceHolder = RemoveHtml(userInput.Caption);

                // etlDate
                etlDate.SetupEditAttributes();
                etlDate.EditValue = FormatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
                etlDate.PlaceHolder = RemoveHtml(etlDate.Caption);

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;

                // awallookupbung
                string curVal2 = ConvertToString(idProses.CurrentValue);
                idProses.EditValue = Empty(curVal2) ? DbNullValue : HtmlEncode(FormatNumber(idProses.CurrentValue, idProses.FormatPattern));
                if (!Empty(curVal2)) {
                    if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idProses.EditValue = idProses.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk2 = idProses.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                            var listwrk = idProses.Lookup?.RenderViewRow(rswrk2[0]);
                            idProses.EditValue = idProses.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                idProses.PlaceHolder = RemoveHtml(idProses.Caption);
                if (!Empty(idProses.EditValue) && IsNumeric(idProses.EditValue))
                    idProses.EditValue = FormatNumber(idProses.EditValue, null);

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                if (!LastUpdatedBy.Raw)
                    LastUpdatedBy.CurrentValue = HtmlDecode(LastUpdatedBy.CurrentValue);
                LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.CurrentValue);
                LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

                // lastUpdatedDate
                lastUpdatedDate.SetupEditAttributes();
                lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.PlaceHolder = RemoveHtml(lastUpdatedDate.Caption);

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // StatusAktivitas
                StatusAktivitas.SetupEditAttributes();
                StatusAktivitas.EditValue = StatusAktivitas.CurrentValue;

                // awallookupbung
                string curVal3 = ConvertToString(StatusAktivitas.CurrentValue);
                StatusAktivitas.EditValue = Empty(curVal3) ? DbNullValue : HtmlEncode(FormatNumber(StatusAktivitas.CurrentValue, StatusAktivitas.FormatPattern));
                if (!Empty(curVal3)) {
                    if (StatusAktivitas.Lookup != null && IsDictionary(StatusAktivitas.Lookup?.Options) && StatusAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        StatusAktivitas.EditValue = StatusAktivitas.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", StatusAktivitas.CurrentValue, StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk3 = StatusAktivitas.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && StatusAktivitas.Lookup != null) { // Lookup values found
                            var listwrk = StatusAktivitas.Lookup?.RenderViewRow(rswrk3[0]);
                            StatusAktivitas.EditValue = StatusAktivitas.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                StatusAktivitas.PlaceHolder = RemoveHtml(StatusAktivitas.Caption);
                if (!Empty(StatusAktivitas.EditValue) && IsNumeric(StatusAktivitas.EditValue))
                    StatusAktivitas.EditValue = FormatNumber(StatusAktivitas.EditValue, null);

                // Add refer script

                // idAktifitas
                idAktifitas.HrefValue = "";

                // BL_KLObs
                BL_KLObs.HrefValue = "";

                // BL_KL15
                BL_KL15.HrefValue = "";

                // BL_Barrels
                BL_Barrels.HrefValue = "";

                // BL_LT
                BL_LT.HrefValue = "";

                // BL_MT
                BL_MT.HrefValue = "";

                // SFAL_KLObs
                SFAL_KLObs.HrefValue = "";

                // SFAL_KL15
                SFAL_KL15.HrefValue = "";

                // SFAL_Barrels
                SFAL_Barrels.HrefValue = "";

                // SFAL_LT
                SFAL_LT.HrefValue = "";

                // SFAL_MT
                SFAL_MT.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // idProses
                idProses.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998

        private void ValidateCustomidAktifitas() {
            if (idAktifitas.Visible && idAktifitas.Required) {
                if (!idAktifitas.IsDetailKey && Empty(idAktifitas.FormValue)) {
                    idAktifitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomBL_KLObs() {
            if (BL_KLObs.Visible && BL_KLObs.Required) {
                if (!BL_KLObs.IsDetailKey && Empty(BL_KLObs.FormValue)) {
                    BL_KLObs.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomBL_KL15() {
            if (BL_KL15.Visible && BL_KL15.Required) {
                if (!BL_KL15.IsDetailKey && Empty(BL_KL15.FormValue)) {
                    BL_KL15.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomBL_Barrels() {
            if (BL_Barrels.Visible && BL_Barrels.Required) {
                if (!BL_Barrels.IsDetailKey && Empty(BL_Barrels.FormValue)) {
                    BL_Barrels.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomBL_LT() {
            if (BL_LT.Visible && BL_LT.Required) {
                if (!BL_LT.IsDetailKey && Empty(BL_LT.FormValue)) {
                    BL_LT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomBL_MT() {
            if (BL_MT.Visible && BL_MT.Required) {
                if (!BL_MT.IsDetailKey && Empty(BL_MT.FormValue)) {
                    BL_MT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAL_KLObs() {
            if (SFAL_KLObs.Visible && SFAL_KLObs.Required) {
                if (!SFAL_KLObs.IsDetailKey && Empty(SFAL_KLObs.FormValue)) {
                    SFAL_KLObs.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAL_KL15() {
            if (SFAL_KL15.Visible && SFAL_KL15.Required) {
                if (!SFAL_KL15.IsDetailKey && Empty(SFAL_KL15.FormValue)) {
                    SFAL_KL15.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAL_Barrels() {
            if (SFAL_Barrels.Visible && SFAL_Barrels.Required) {
                if (!SFAL_Barrels.IsDetailKey && Empty(SFAL_Barrels.FormValue)) {
                    SFAL_Barrels.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAL_LT() {
            if (SFAL_LT.Visible && SFAL_LT.Required) {
                if (!SFAL_LT.IsDetailKey && Empty(SFAL_LT.FormValue)) {
                    SFAL_LT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAL_MT() {
            if (SFAL_MT.Visible && SFAL_MT.Required) {
                if (!SFAL_MT.IsDetailKey && Empty(SFAL_MT.FormValue)) {
                    SFAL_MT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomuserInput() {
            if (userInput.Visible && userInput.Required) {
                if (!userInput.IsDetailKey && Empty(userInput.FormValue)) {
                    userInput.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustometlDate() {
            if (etlDate.Visible && etlDate.Required) {
                if (!etlDate.IsDetailKey && Empty(etlDate.FormValue)) {
                    etlDate.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomidProses() {
            if (idProses.Visible && idProses.Required) {
                if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                    idProses.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomLastUpdatedBy() {
            if (LastUpdatedBy.Visible && LastUpdatedBy.Required) {
                if (!LastUpdatedBy.IsDetailKey && Empty(LastUpdatedBy.FormValue)) {
                    LastUpdatedBy.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomlastUpdatedDate() {
            if (lastUpdatedDate.Visible && lastUpdatedDate.Required) {
                if (!lastUpdatedDate.IsDetailKey && Empty(lastUpdatedDate.FormValue)) {
                    lastUpdatedDate.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomNoReferensi() {
            if (NoReferensi.Visible && NoReferensi.Required) {
                if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                    NoReferensi.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomStatusAktivitas() {
            if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                    StatusAktivitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomidAktifitas();
                if (!CheckInteger(idAktifitas.FormValue)) {
                    idAktifitas.AddErrorMessage(idAktifitas.GetErrorMessage(false));
                }
                ValidateCustomBL_KLObs();
                ValidateCustomBL_KL15();
                ValidateCustomBL_Barrels();
                ValidateCustomBL_LT();
                ValidateCustomBL_MT();
                ValidateCustomSFAL_KLObs();
                ValidateCustomSFAL_KL15();
                ValidateCustomSFAL_Barrels();
                ValidateCustomSFAL_LT();
                ValidateCustomSFAL_MT();
                ValidateCustomuserInput();
                ValidateCustometlDate();
                if (!CheckDate(etlDate.FormValue, etlDate.FormatPattern)) {
                    etlDate.AddErrorMessage(etlDate.GetErrorMessage(false));
                }
                ValidateCustomidProses();
                if (!CheckInteger(idProses.FormValue)) {
                    idProses.AddErrorMessage(idProses.GetErrorMessage(false));
                }
                ValidateCustomLastUpdatedBy();
                ValidateCustomlastUpdatedDate();
                if (!CheckDate(lastUpdatedDate.FormValue, lastUpdatedDate.FormatPattern)) {
                    lastUpdatedDate.AddErrorMessage(lastUpdatedDate.GetErrorMessage(false));
                }
                ValidateCustomNoReferensi();
                ValidateCustomStatusAktivitas();
                if (!CheckInteger(StatusAktivitas.FormValue)) {
                    StatusAktivitas.AddErrorMessage(StatusAktivitas.GetErrorMessage(false));
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

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Get new row
            Dictionary<string, object> rsnew = GetAddRow();
            if (rsnew.Count == 0)
                return JsonBoolResult.FalseResult;

            // Update current values
            SetCurrentValues(rsnew);

            // Load db values from rsold
            LoadDbValues(rsold);

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["id"] = id.CurrentValue!;
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    result = false;
                }
            } else {
                if (SuccessMessage != "" || FailureMessage != "") {
                    // Use the message, do nothing
                } else if (CancelMessage != "") {
                    FailureMessage = CancelMessage;
                    CancelMessage = "";
                } else {
                    FailureMessage = Language.Phrase("InsertCancelled");
                }
                result = false;
            }

            // Call Row Inserted event
            if (result)
                RowInserted(rsold, rsnew);

            // Write JSON for API request
            Dictionary<string, object> d = new();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                if (GetRecordFromDictionary(rsnew) is var row && row != null) {
                    string table = TableVar;
                    d.Add(table, row);
                }
                d.Add("action", Config.ApiAddAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, result);
            }
            return new JsonBoolResult(d, result);
        }

        /// <summary>
        /// Get add row
        /// </summary>
        /// <returns>New row</returns>
        protected Dictionary<string, object> GetAddRow()
        {
            try {
                Dictionary<string, object> rsnew = new();

                // idAktifitas
                idAktifitas.SetDbValue(rsnew, idAktifitas.CurrentValue);

                // BL_KLObs
                BL_KLObs.SetDbValue(rsnew, BL_KLObs.CurrentValue);

                // BL_KL15
                BL_KL15.SetDbValue(rsnew, BL_KL15.CurrentValue);

                // BL_Barrels
                BL_Barrels.SetDbValue(rsnew, BL_Barrels.CurrentValue);

                // BL_LT
                BL_LT.SetDbValue(rsnew, BL_LT.CurrentValue);

                // BL_MT
                BL_MT.SetDbValue(rsnew, BL_MT.CurrentValue);

                // SFAL_KLObs
                SFAL_KLObs.SetDbValue(rsnew, SFAL_KLObs.CurrentValue);

                // SFAL_KL15
                SFAL_KL15.SetDbValue(rsnew, SFAL_KL15.CurrentValue);

                // SFAL_Barrels
                SFAL_Barrels.SetDbValue(rsnew, SFAL_Barrels.CurrentValue);

                // SFAL_LT
                SFAL_LT.SetDbValue(rsnew, SFAL_LT.CurrentValue);

                // SFAL_MT
                SFAL_MT.SetDbValue(rsnew, SFAL_MT.CurrentValue);

                // userInput
                userInput.SetDbValue(rsnew, userInput.CurrentValue);

                // etlDate
                etlDate.SetDbValue(rsnew, ConvertToDateTime(etlDate.CurrentValue, etlDate.FormatPattern), Empty(etlDate.CurrentValue));

                // idProses
                idProses.SetDbValue(rsnew, idProses.CurrentValue);

                // LastUpdatedBy
                LastUpdatedBy.SetDbValue(rsnew, LastUpdatedBy.CurrentValue);

                // lastUpdatedDate
                lastUpdatedDate.SetDbValue(rsnew, ConvertToDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern));

                // NoReferensi
                NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue);

                // StatusAktivitas
                StatusAktivitas.SetDbValue(rsnew, StatusAktivitas.CurrentValue);
                return rsnew;
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return new();
            }
        }

        /// <summary>
        /// Restore add form from row
        /// </summary>
        /// <param name="row">Current row</param>
        private void RestoreAddFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("idAktifitas", out value)) // idAktifitas
                idAktifitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_KLObs", out value)) // BL_KLObs
                BL_KLObs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_KL15", out value)) // BL_KL15
                BL_KL15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_Barrels", out value)) // BL_Barrels
                BL_Barrels.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_LT", out value)) // BL_LT
                BL_LT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_MT", out value)) // BL_MT
                BL_MT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAL_KLObs", out value)) // SFAL_KLObs
                SFAL_KLObs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAL_KL15", out value)) // SFAL_KL15
                SFAL_KL15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAL_Barrels", out value)) // SFAL_Barrels
                SFAL_Barrels.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAL_LT", out value)) // SFAL_LT
                SFAL_LT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAL_MT", out value)) // SFAL_MT
                SFAL_MT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("userInput", out value)) // userInput
                userInput.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("etlDate", out value)) // etlDate
                etlDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("idProses", out value)) // idProses
                idProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LastUpdatedBy", out value)) // LastUpdatedBy
                LastUpdatedBy.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("lastUpdatedDate", out value)) // lastUpdatedDate
                lastUpdatedDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusAktivitas", out value)) // StatusAktivitas
                StatusAktivitas.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasFormInputBLnSfalrtwList")), "", TableVar, true);
            string pageId = IsCopy ? "Copy" : "Add";
            breadcrumb.Add("add", pageId, url);
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
