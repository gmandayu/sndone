using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasNilaiNewBlsfadsfblEdit
    /// </summary>
    public static SubAktivitasNilaiNewBlsfadsfblEdit subAktivitasNilaiNewBlsfadsfblEdit
    {
        get => HttpData.Get<SubAktivitasNilaiNewBlsfadsfblEdit>("subAktivitasNilaiNewBlsfadsfblEdit")!;
        set => HttpData["subAktivitasNilaiNewBlsfadsfblEdit"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasNilaiNewBLSFADSFBL
    /// </summary>
    public class SubAktivitasNilaiNewBlsfadsfblEdit : SubAktivitasNilaiNewBlsfadsfblEditBase
    {
        // Constructor
        public SubAktivitasNilaiNewBlsfadsfblEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasNilaiNewBlsfadsfblEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasNilaiNewBlsfadsfblEditBase : SubAktivitasNilaiNewBlsfadsfbl
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasNilaiNewBlsfadsfblEdit";

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
        public SubAktivitasNilaiNewBlsfadsfblEditBase(Controller? controller)
        {
            TableName = "SubAktivitasNilaiNewBLSFADSFBL";

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

            // Table object (subAktivitasNilaiNewBlsfadsfbl)
            if (subAktivitasNilaiNewBlsfadsfbl == null || subAktivitasNilaiNewBlsfadsfbl is SubAktivitasNilaiNewBlsfadsfbl)
                subAktivitasNilaiNewBlsfadsfbl = this;

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
        public string PageName => "SubAktivitasNilaiNewBlsfadsfblEdit";

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
            id.SetVisibility();
            idProses.SetVisibility();
            idAktifitas.SetVisibility();
            NoReferensi.SetVisibility();
            NewBL_KLObs.SetVisibility();
            NewBL_KL15.SetVisibility();
            NewBL_Barrels.SetVisibility();
            NewBL_LT.SetVisibility();
            NewBL_MT.SetVisibility();
            SFAD_KLObs.SetVisibility();
            SFAD_KL15.SetVisibility();
            SFAD_Barrels.SetVisibility();
            SFAD_MT.SetVisibility();
            SFAD_LT.SetVisibility();
            SFBL_KLObs.SetVisibility();
            SFBL_KL15.SetVisibility();
            SFBL_Barrels.SetVisibility();
            SFBL_LT.SetVisibility();
            SFBL_MT.SetVisibility();
            userInput.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            ExROB.SetVisibility();
            NoPenerimaan.SetVisibility();
            StatusAktivitas.SetVisibility();
        }

        // Constructor
        public SubAktivitasNilaiNewBlsfadsfblEditBase() : this(null) { }

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
                        result.Add("view", pageName == "SubAktivitasNilaiNewBlsfadsfblView" ? "1" : "0"); // If View page, no primary button
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
                if (RouteValues.TryGetValue("id", out rv)) {
                    id.FormValue = UrlDecode(rv);
                    id.OldValue = id.FormValue;
                } else if (CurrentForm.HasValue("x_id")) {
                    id.FormValue = CurrentForm.GetValue("x_id");
                    id.OldValue = id.FormValue;
                } else if (!Empty(keyValues)) {
                    id.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("id", out rv)) {
                        id.QueryValue = UrlDecode(rv);
                        loadByQuery = true;
                    } else if (Get("id", out sv)) {
                        id.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        id.CurrentValue = DbNullValue;
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
                id.FormValue = ConvertToString(keyValues[0]);
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
                return Terminate("SubAktivitasNilaiNewBlsfadsfblList");
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
                    if (GetPageName(returnUrl) != "SubAktivitasNilaiNewBlsfadsfblList") {
                        TempData["Return-Url"] = returnUrl;
                        returnUrl = "SubAktivitasNilaiNewBlsfadsfblList";
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
            if (GetPageName(returnUrl) == "SubAktivitasNilaiNewBlsfadsfblList")
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
                    await SetupLookupOptions(idProses);
                    await SetupLookupOptions(idAktifitas);
                    await SetupLookupOptions(ExROB);
                    await SetupLookupOptions(NoPenerimaan);
                    await SetupLookupOptions(StatusAktivitas);
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
                        subAktivitasNilaiNewBlsfadsfblEdit?.PageRender();
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
            if (!id.IsDetailKey) {
                SetNormalField(id, "id", "x_id");
            }

            // Standard handling for 'idProses'
            idProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idProses, "idProses", "x_idProses");

            // Standard handling for 'idAktifitas'
            idAktifitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idAktifitas, "idAktifitas", "x_idAktifitas");

            // Standard handling for 'NoReferensi'
            NoReferensi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NoReferensi, "NoReferensi", "x_NoReferensi");

            // Standard handling for 'NewBL_KLObs'
            NewBL_KLObs.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NewBL_KLObs, "NewBL_KLObs", "x_NewBL_KLObs");

            // Standard handling for 'NewBL_KL15'
            NewBL_KL15.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NewBL_KL15, "NewBL_KL15", "x_NewBL_KL15");

            // Standard handling for 'NewBL_Barrels'
            NewBL_Barrels.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NewBL_Barrels, "NewBL_Barrels", "x_NewBL_Barrels");

            // Standard handling for 'NewBL_LT'
            NewBL_LT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NewBL_LT, "NewBL_LT", "x_NewBL_LT");

            // Standard handling for 'NewBL_MT'
            NewBL_MT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NewBL_MT, "NewBL_MT", "x_NewBL_MT");

            // Standard handling for 'SFAD_KLObs'
            SFAD_KLObs.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_KLObs, "SFAD_KLObs", "x_SFAD_KLObs");

            // Standard handling for 'SFAD_KL15'
            SFAD_KL15.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_KL15, "SFAD_KL15", "x_SFAD_KL15");

            // Standard handling for 'SFAD_Barrels'
            SFAD_Barrels.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_Barrels, "SFAD_Barrels", "x_SFAD_Barrels");

            // Standard handling for 'SFAD_MT'
            SFAD_MT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_MT, "SFAD_MT", "x_SFAD_MT");

            // Standard handling for 'SFAD_LT'
            SFAD_LT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_LT, "SFAD_LT", "x_SFAD_LT");

            // Standard handling for 'SFBL_KLObs'
            SFBL_KLObs.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFBL_KLObs, "SFBL_KLObs", "x_SFBL_KLObs");

            // Standard handling for 'SFBL_KL15'
            SFBL_KL15.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFBL_KL15, "SFBL_KL15", "x_SFBL_KL15");

            // Standard handling for 'SFBL_Barrels'
            SFBL_Barrels.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFBL_Barrels, "SFBL_Barrels", "x_SFBL_Barrels");

            // Standard handling for 'SFBL_LT'
            SFBL_LT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFBL_LT, "SFBL_LT", "x_SFBL_LT");

            // Standard handling for 'SFBL_MT'
            SFBL_MT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFBL_MT, "SFBL_MT", "x_SFBL_MT");

            // Standard handling for 'userInput'
            userInput.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(userInput, "userInput", "x_userInput");

            // Standard handling for 'etlDate'
            etlDate.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(etlDate, "etlDate", "x_etlDate", true, validate, true);

            // Standard handling for 'LastUpdatedBy'
            LastUpdatedBy.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LastUpdatedBy, "LastUpdatedBy", "x_LastUpdatedBy");

            // Standard handling for 'lastUpdatedDate'
            lastUpdatedDate.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(lastUpdatedDate, "lastUpdatedDate", "x_lastUpdatedDate", false, false, true);

            // Standard handling for 'ExROB'
            ExROB.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(ExROB, "ExROB", "x_ExROB");

            // Standard handling for 'NoPenerimaan'
            NoPenerimaan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NoPenerimaan, "NoPenerimaan", "x_NoPenerimaan");

            // Standard handling for 'StatusAktivitas'
            StatusAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(StatusAktivitas, "StatusAktivitas", "x_StatusAktivitas");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            id.CurrentValue = id.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            NewBL_KLObs.CurrentValue = NewBL_KLObs.FormValue;
            NewBL_KL15.CurrentValue = NewBL_KL15.FormValue;
            NewBL_Barrels.CurrentValue = NewBL_Barrels.FormValue;
            NewBL_LT.CurrentValue = NewBL_LT.FormValue;
            NewBL_MT.CurrentValue = NewBL_MT.FormValue;
            SFAD_KLObs.CurrentValue = SFAD_KLObs.FormValue;
            SFAD_KL15.CurrentValue = SFAD_KL15.FormValue;
            SFAD_Barrels.CurrentValue = SFAD_Barrels.FormValue;
            SFAD_MT.CurrentValue = SFAD_MT.FormValue;
            SFAD_LT.CurrentValue = SFAD_LT.FormValue;
            SFBL_KLObs.CurrentValue = SFBL_KLObs.FormValue;
            SFBL_KL15.CurrentValue = SFBL_KL15.FormValue;
            SFBL_Barrels.CurrentValue = SFBL_Barrels.FormValue;
            SFBL_LT.CurrentValue = SFBL_LT.FormValue;
            SFBL_MT.CurrentValue = SFBL_MT.FormValue;
            userInput.CurrentValue = userInput.FormValue;
            etlDate.CurrentValue = etlDate.FormValue;
            etlDate.CurrentValue = UnformatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            ExROB.CurrentValue = ExROB.FormValue;
            NoPenerimaan.CurrentValue = NoPenerimaan.FormValue;
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
            idProses.SetDbValue(row["idProses"]);
            idAktifitas.SetDbValue(row["idAktifitas"]);
            NoReferensi.SetDbValue(row["NoReferensi"]);
            NewBL_KLObs.SetDbValue(row["NewBL_KLObs"]);
            NewBL_KL15.SetDbValue(row["NewBL_KL15"]);
            NewBL_Barrels.SetDbValue(row["NewBL_Barrels"]);
            NewBL_LT.SetDbValue(row["NewBL_LT"]);
            NewBL_MT.SetDbValue(row["NewBL_MT"]);
            SFAD_KLObs.SetDbValue(row["SFAD_KLObs"]);
            SFAD_KL15.SetDbValue(row["SFAD_KL15"]);
            SFAD_Barrels.SetDbValue(row["SFAD_Barrels"]);
            SFAD_MT.SetDbValue(row["SFAD_MT"]);
            SFAD_LT.SetDbValue(row["SFAD_LT"]);
            SFBL_KLObs.SetDbValue(row["SFBL_KLObs"]);
            SFBL_KL15.SetDbValue(row["SFBL_KL15"]);
            SFBL_Barrels.SetDbValue(row["SFBL_Barrels"]);
            SFBL_LT.SetDbValue(row["SFBL_LT"]);
            SFBL_MT.SetDbValue(row["SFBL_MT"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            ExROB.SetDbValue((ConvertToBool(row["ExROB"]) ? "1" : "0"));
            NoPenerimaan.SetDbValue(row["NoPenerimaan"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_KLObs", NewBL_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_KL15", NewBL_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_Barrels", NewBL_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_LT", NewBL_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_MT", NewBL_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_KLObs", SFAD_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_KL15", SFAD_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_Barrels", SFAD_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_MT", SFAD_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_LT", SFAD_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("SFBL_KLObs", SFBL_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("SFBL_KL15", SFBL_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("SFBL_Barrels", SFBL_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("SFBL_LT", SFBL_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("SFBL_MT", SFBL_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("ExROB", ExROB.DefaultValue ?? DbNullValue); // DN
            row.Add("NoPenerimaan", NoPenerimaan.DefaultValue ?? DbNullValue); // DN
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

            // idProses
            idProses.RowCssClass = "row";

            // idAktifitas
            idAktifitas.RowCssClass = "row";

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // NewBL_KLObs
            NewBL_KLObs.RowCssClass = "row";

            // NewBL_KL15
            NewBL_KL15.RowCssClass = "row";

            // NewBL_Barrels
            NewBL_Barrels.RowCssClass = "row";

            // NewBL_LT
            NewBL_LT.RowCssClass = "row";

            // NewBL_MT
            NewBL_MT.RowCssClass = "row";

            // SFAD_KLObs
            SFAD_KLObs.RowCssClass = "row";

            // SFAD_KL15
            SFAD_KL15.RowCssClass = "row";

            // SFAD_Barrels
            SFAD_Barrels.RowCssClass = "row";

            // SFAD_MT
            SFAD_MT.RowCssClass = "row";

            // SFAD_LT
            SFAD_LT.RowCssClass = "row";

            // SFBL_KLObs
            SFBL_KLObs.RowCssClass = "row";

            // SFBL_KL15
            SFBL_KL15.RowCssClass = "row";

            // SFBL_Barrels
            SFBL_Barrels.RowCssClass = "row";

            // SFBL_LT
            SFBL_LT.RowCssClass = "row";

            // SFBL_MT
            SFBL_MT.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // ExROB
            ExROB.RowCssClass = "row";

            // NoPenerimaan
            NoPenerimaan.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // idProses

                // idAktifitas

                // NoReferensi

                // NewBL_KLObs

                // NewBL_KL15

                // NewBL_Barrels

                // NewBL_LT

                // NewBL_MT

                // SFAD_KLObs

                // SFAD_KL15

                // SFAD_Barrels

                // SFAD_MT

                // SFAD_LT

                // SFBL_KLObs

                // SFBL_KL15

                // SFBL_Barrels

                // SFBL_LT

                // SFBL_MT

                // userInput

                // etlDate

                // LastUpdatedBy

                // lastUpdatedDate

                // ExROB

                // NoPenerimaan

                // StatusAktivitas

                    // id
                    id.ViewValue = id.CurrentValue;
                    id.ViewCustomAttributes = "";

                    // idProses
                    idProses.ViewValue = idProses.CurrentValue;

                    // awallookupbung
                    // idProses
                    ResolveLookupView(idProses, "IdProses", "number");
                    // akhirlookupbung
                    idProses.ViewCustomAttributes = "";

                    // idAktifitas
                    idAktifitas.ViewValue = idAktifitas.CurrentValue;

                    // awallookupbung
                    // idAktifitas
                    ResolveLookupView(idAktifitas, "IdAktivitas", "number");
                    // akhirlookupbung
                    idAktifitas.ViewCustomAttributes = "";

                    // NoReferensi
                    NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                    NoReferensi.ViewCustomAttributes = "";

                    // NewBL_KLObs
                    NewBL_KLObs.ViewValue = ConvertToString(NewBL_KLObs.CurrentValue); // DN
                    NewBL_KLObs.ViewCustomAttributes = "";

                    // NewBL_KL15
                    NewBL_KL15.ViewValue = ConvertToString(NewBL_KL15.CurrentValue); // DN
                    NewBL_KL15.ViewCustomAttributes = "";

                    // NewBL_Barrels
                    NewBL_Barrels.ViewValue = ConvertToString(NewBL_Barrels.CurrentValue); // DN
                    NewBL_Barrels.ViewCustomAttributes = "";

                    // NewBL_LT
                    NewBL_LT.ViewValue = ConvertToString(NewBL_LT.CurrentValue); // DN
                    NewBL_LT.ViewCustomAttributes = "";

                    // NewBL_MT
                    NewBL_MT.ViewValue = ConvertToString(NewBL_MT.CurrentValue); // DN
                    NewBL_MT.ViewCustomAttributes = "";

                    // SFAD_KLObs
                    SFAD_KLObs.ViewValue = ConvertToString(SFAD_KLObs.CurrentValue); // DN
                    SFAD_KLObs.ViewCustomAttributes = "";

                    // SFAD_KL15
                    SFAD_KL15.ViewValue = ConvertToString(SFAD_KL15.CurrentValue); // DN
                    SFAD_KL15.ViewCustomAttributes = "";

                    // SFAD_Barrels
                    SFAD_Barrels.ViewValue = ConvertToString(SFAD_Barrels.CurrentValue); // DN
                    SFAD_Barrels.ViewCustomAttributes = "";

                    // SFAD_MT
                    SFAD_MT.ViewValue = ConvertToString(SFAD_MT.CurrentValue); // DN
                    SFAD_MT.ViewCustomAttributes = "";

                    // SFAD_LT
                    SFAD_LT.ViewValue = ConvertToString(SFAD_LT.CurrentValue); // DN
                    SFAD_LT.ViewCustomAttributes = "";

                    // SFBL_KLObs
                    SFBL_KLObs.ViewValue = ConvertToString(SFBL_KLObs.CurrentValue); // DN
                    SFBL_KLObs.ViewCustomAttributes = "";

                    // SFBL_KL15
                    SFBL_KL15.ViewValue = ConvertToString(SFBL_KL15.CurrentValue); // DN
                    SFBL_KL15.ViewCustomAttributes = "";

                    // SFBL_Barrels
                    SFBL_Barrels.ViewValue = ConvertToString(SFBL_Barrels.CurrentValue); // DN
                    SFBL_Barrels.ViewCustomAttributes = "";

                    // SFBL_LT
                    SFBL_LT.ViewValue = ConvertToString(SFBL_LT.CurrentValue); // DN
                    SFBL_LT.ViewCustomAttributes = "";

                    // SFBL_MT
                    SFBL_MT.ViewValue = ConvertToString(SFBL_MT.CurrentValue); // DN
                    SFBL_MT.ViewCustomAttributes = "";

                    // userInput
                    userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                    userInput.ViewCustomAttributes = "";

                    // etlDate
                    etlDate.ViewValue = etlDate.CurrentValue;
                    etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                    etlDate.ViewCustomAttributes = "";

                    // LastUpdatedBy
                    LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                    LastUpdatedBy.ViewCustomAttributes = "";

                    // lastUpdatedDate
                    lastUpdatedDate.ViewValue = lastUpdatedDate.CurrentValue;
                    lastUpdatedDate.ViewValue = FormatDateTime(lastUpdatedDate.ViewValue, lastUpdatedDate.FormatPattern);
                    lastUpdatedDate.ViewCustomAttributes = "";

                    // ExROB
                    if (ConvertToBool(ExROB.CurrentValue)) {
                        ExROB.ViewValue = ExROB.TagCaption(1) != "" ? ExROB.TagCaption(1) : "Yes";
                    } else {
                        ExROB.ViewValue = ExROB.TagCaption(2) != "" ? ExROB.TagCaption(2) : "No";
                    }
                    ExROB.ViewCustomAttributes = "";

                    // NoPenerimaan
                    List<object?>? listWrk4 = [ // DN
                        NoPenerimaan.CurrentValue,
                        NoPenerimaan.CurrentValue,
                    ];
                    listWrk4 = NoPenerimaan.Lookup?.RenderViewRow(listWrk4, this);
                    string? dispVal4 = NoPenerimaan.DisplayValue(listWrk4);
                    if (!Empty(dispVal4))
                        NoPenerimaan.ViewValue = dispVal4;

                    // akhirlookupbung
                    NoPenerimaan.ViewCustomAttributes = "";

                    // StatusAktivitas
                    StatusAktivitas.ViewValue = StatusAktivitas.CurrentValue;

                    // awallookupbung
                    // StatusAktivitas
                    ResolveLookupView(StatusAktivitas, "IdAktivitas", "number");
                    // akhirlookupbung
                    StatusAktivitas.ViewCustomAttributes = "";

                // id
                id.HrefValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // NewBL_KLObs
                NewBL_KLObs.HrefValue = "";

                // NewBL_KL15
                NewBL_KL15.HrefValue = "";

                // NewBL_Barrels
                NewBL_Barrels.HrefValue = "";

                // NewBL_LT
                NewBL_LT.HrefValue = "";

                // NewBL_MT
                NewBL_MT.HrefValue = "";

                // SFAD_KLObs
                SFAD_KLObs.HrefValue = "";

                // SFAD_KL15
                SFAD_KL15.HrefValue = "";

                // SFAD_Barrels
                SFAD_Barrels.HrefValue = "";

                // SFAD_MT
                SFAD_MT.HrefValue = "";

                // SFAD_LT
                SFAD_LT.HrefValue = "";

                // SFBL_KLObs
                SFBL_KLObs.HrefValue = "";

                // SFBL_KL15
                SFBL_KL15.HrefValue = "";

                // SFBL_Barrels
                SFBL_Barrels.HrefValue = "";

                // SFBL_LT
                SFBL_LT.HrefValue = "";

                // SFBL_MT
                SFBL_MT.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // ExROB
                ExROB.HrefValue = "";

                // NoPenerimaan
                NoPenerimaan.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";
            } else if (RowType == RowType.Edit) {
                // id
                id.SetupEditAttributes();
                id.EditValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;

                // awallookupbung
                string curVal = ConvertToString(idProses.CurrentValue);
                idProses.EditValue = Empty(curVal) ? DbNullValue : FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
                if (!Empty(curVal)) {
                    if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idProses.EditValue = idProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk = idProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                            var listwrk = idProses.Lookup?.RenderViewRow(rswrk[0]);
                            idProses.EditValue = idProses.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                idProses.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;

                // awallookupbung
                string curVal2 = ConvertToString(idAktifitas.CurrentValue);
                idAktifitas.EditValue = Empty(curVal2) ? DbNullValue : FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
                if (!Empty(curVal2)) {
                    if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idAktifitas.EditValue = idAktifitas.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk2 = idAktifitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                            var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk2[0]);
                            idAktifitas.EditValue = idAktifitas.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                idAktifitas.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                NoReferensi.EditValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // NewBL_KLObs
                NewBL_KLObs.SetupEditAttributes();
                if (!NewBL_KLObs.Raw)
                    NewBL_KLObs.CurrentValue = HtmlDecode(NewBL_KLObs.CurrentValue);
                NewBL_KLObs.EditValue = HtmlEncode(NewBL_KLObs.CurrentValue);
                NewBL_KLObs.PlaceHolder = RemoveHtml(NewBL_KLObs.Caption);

                // NewBL_KL15
                NewBL_KL15.SetupEditAttributes();
                if (!NewBL_KL15.Raw)
                    NewBL_KL15.CurrentValue = HtmlDecode(NewBL_KL15.CurrentValue);
                NewBL_KL15.EditValue = HtmlEncode(NewBL_KL15.CurrentValue);
                NewBL_KL15.PlaceHolder = RemoveHtml(NewBL_KL15.Caption);

                // NewBL_Barrels
                NewBL_Barrels.SetupEditAttributes();
                if (!NewBL_Barrels.Raw)
                    NewBL_Barrels.CurrentValue = HtmlDecode(NewBL_Barrels.CurrentValue);
                NewBL_Barrels.EditValue = HtmlEncode(NewBL_Barrels.CurrentValue);
                NewBL_Barrels.PlaceHolder = RemoveHtml(NewBL_Barrels.Caption);

                // NewBL_LT
                NewBL_LT.SetupEditAttributes();
                if (!NewBL_LT.Raw)
                    NewBL_LT.CurrentValue = HtmlDecode(NewBL_LT.CurrentValue);
                NewBL_LT.EditValue = HtmlEncode(NewBL_LT.CurrentValue);
                NewBL_LT.PlaceHolder = RemoveHtml(NewBL_LT.Caption);

                // NewBL_MT
                NewBL_MT.SetupEditAttributes();
                if (!NewBL_MT.Raw)
                    NewBL_MT.CurrentValue = HtmlDecode(NewBL_MT.CurrentValue);
                NewBL_MT.EditValue = HtmlEncode(NewBL_MT.CurrentValue);
                NewBL_MT.PlaceHolder = RemoveHtml(NewBL_MT.Caption);

                // SFAD_KLObs
                SFAD_KLObs.SetupEditAttributes();
                if (!SFAD_KLObs.Raw)
                    SFAD_KLObs.CurrentValue = HtmlDecode(SFAD_KLObs.CurrentValue);
                SFAD_KLObs.EditValue = HtmlEncode(SFAD_KLObs.CurrentValue);
                SFAD_KLObs.PlaceHolder = RemoveHtml(SFAD_KLObs.Caption);

                // SFAD_KL15
                SFAD_KL15.SetupEditAttributes();
                if (!SFAD_KL15.Raw)
                    SFAD_KL15.CurrentValue = HtmlDecode(SFAD_KL15.CurrentValue);
                SFAD_KL15.EditValue = HtmlEncode(SFAD_KL15.CurrentValue);
                SFAD_KL15.PlaceHolder = RemoveHtml(SFAD_KL15.Caption);

                // SFAD_Barrels
                SFAD_Barrels.SetupEditAttributes();
                if (!SFAD_Barrels.Raw)
                    SFAD_Barrels.CurrentValue = HtmlDecode(SFAD_Barrels.CurrentValue);
                SFAD_Barrels.EditValue = HtmlEncode(SFAD_Barrels.CurrentValue);
                SFAD_Barrels.PlaceHolder = RemoveHtml(SFAD_Barrels.Caption);

                // SFAD_MT
                SFAD_MT.SetupEditAttributes();
                if (!SFAD_MT.Raw)
                    SFAD_MT.CurrentValue = HtmlDecode(SFAD_MT.CurrentValue);
                SFAD_MT.EditValue = HtmlEncode(SFAD_MT.CurrentValue);
                SFAD_MT.PlaceHolder = RemoveHtml(SFAD_MT.Caption);

                // SFAD_LT
                SFAD_LT.SetupEditAttributes();
                if (!SFAD_LT.Raw)
                    SFAD_LT.CurrentValue = HtmlDecode(SFAD_LT.CurrentValue);
                SFAD_LT.EditValue = HtmlEncode(SFAD_LT.CurrentValue);
                SFAD_LT.PlaceHolder = RemoveHtml(SFAD_LT.Caption);

                // SFBL_KLObs
                SFBL_KLObs.SetupEditAttributes();
                if (!SFBL_KLObs.Raw)
                    SFBL_KLObs.CurrentValue = HtmlDecode(SFBL_KLObs.CurrentValue);
                SFBL_KLObs.EditValue = HtmlEncode(SFBL_KLObs.CurrentValue);
                SFBL_KLObs.PlaceHolder = RemoveHtml(SFBL_KLObs.Caption);

                // SFBL_KL15
                SFBL_KL15.SetupEditAttributes();
                if (!SFBL_KL15.Raw)
                    SFBL_KL15.CurrentValue = HtmlDecode(SFBL_KL15.CurrentValue);
                SFBL_KL15.EditValue = HtmlEncode(SFBL_KL15.CurrentValue);
                SFBL_KL15.PlaceHolder = RemoveHtml(SFBL_KL15.Caption);

                // SFBL_Barrels
                SFBL_Barrels.SetupEditAttributes();
                if (!SFBL_Barrels.Raw)
                    SFBL_Barrels.CurrentValue = HtmlDecode(SFBL_Barrels.CurrentValue);
                SFBL_Barrels.EditValue = HtmlEncode(SFBL_Barrels.CurrentValue);
                SFBL_Barrels.PlaceHolder = RemoveHtml(SFBL_Barrels.Caption);

                // SFBL_LT
                SFBL_LT.SetupEditAttributes();
                if (!SFBL_LT.Raw)
                    SFBL_LT.CurrentValue = HtmlDecode(SFBL_LT.CurrentValue);
                SFBL_LT.EditValue = HtmlEncode(SFBL_LT.CurrentValue);
                SFBL_LT.PlaceHolder = RemoveHtml(SFBL_LT.Caption);

                // SFBL_MT
                SFBL_MT.SetupEditAttributes();
                if (!SFBL_MT.Raw)
                    SFBL_MT.CurrentValue = HtmlDecode(SFBL_MT.CurrentValue);
                SFBL_MT.EditValue = HtmlEncode(SFBL_MT.CurrentValue);
                SFBL_MT.PlaceHolder = RemoveHtml(SFBL_MT.Caption);

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

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                LastUpdatedBy.EditValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // lastUpdatedDate
                lastUpdatedDate.SetupEditAttributes();
                lastUpdatedDate.EditValue = lastUpdatedDate.CurrentValue;
                lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.EditValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.ViewCustomAttributes = "";

                // ExROB
                ExROB.EditValue = ExROB.Options(false);
                ExROB.PlaceHolder = RemoveHtml(ExROB.Caption);

                // NoPenerimaan
                NoPenerimaan.SetupEditAttributes();
                string curVal4 = ConvertToString(NoPenerimaan.CurrentValue);
                if (NoPenerimaan.Lookup != null && IsDictionary(NoPenerimaan.Lookup?.Options) && NoPenerimaan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NoPenerimaan.EditValue = NoPenerimaan.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk4 = "";
                    if (curVal4 == "") {
                        filterWrk4 = "0=1";
                    } else {
                        filterWrk4 = SearchFilter(NoPenerimaan.Lookup?.GetTable()?.Fields["NomorPenerimaan"].SearchExpression, "=", NoPenerimaan.CurrentValue, NoPenerimaan.Lookup?.GetTable()?.Fields["NomorPenerimaan"].SearchDataType, "");
                    }
                    var lookupFilter4 = () => NoPenerimaan.GetSelectFilter();
                    string? sqlWrk4 = NoPenerimaan.Lookup?.GetSql(true, filterWrk4, lookupFilter4, this, false, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    NoPenerimaan.EditValue = rswrk4;
                }
                NoPenerimaan.PlaceHolder = RemoveHtml(NoPenerimaan.Caption);

                // StatusAktivitas
                StatusAktivitas.SetupEditAttributes();
                StatusAktivitas.EditValue = StatusAktivitas.CurrentValue;

                // awallookupbung
                string curVal5 = ConvertToString(StatusAktivitas.CurrentValue);
                StatusAktivitas.EditValue = Empty(curVal5) ? DbNullValue : FormatNumber(StatusAktivitas.CurrentValue, StatusAktivitas.FormatPattern);
                if (!Empty(curVal5)) {
                    if (StatusAktivitas.Lookup != null && IsDictionary(StatusAktivitas.Lookup?.Options) && StatusAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        StatusAktivitas.EditValue = StatusAktivitas.LookupCacheOption(curVal5);
                    } else { // Lookup from database // DN
                        string filterWrk5 = SearchFilter(StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", StatusAktivitas.CurrentValue, StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk5 = StatusAktivitas.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk5?.Count > 0 && StatusAktivitas.Lookup != null) { // Lookup values found
                            var listwrk = StatusAktivitas.Lookup?.RenderViewRow(rswrk5[0]);
                            StatusAktivitas.EditValue = StatusAktivitas.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                StatusAktivitas.ViewCustomAttributes = "";

                // Edit refer script

                // id
                id.HrefValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // NewBL_KLObs
                NewBL_KLObs.HrefValue = "";

                // NewBL_KL15
                NewBL_KL15.HrefValue = "";

                // NewBL_Barrels
                NewBL_Barrels.HrefValue = "";

                // NewBL_LT
                NewBL_LT.HrefValue = "";

                // NewBL_MT
                NewBL_MT.HrefValue = "";

                // SFAD_KLObs
                SFAD_KLObs.HrefValue = "";

                // SFAD_KL15
                SFAD_KL15.HrefValue = "";

                // SFAD_Barrels
                SFAD_Barrels.HrefValue = "";

                // SFAD_MT
                SFAD_MT.HrefValue = "";

                // SFAD_LT
                SFAD_LT.HrefValue = "";

                // SFBL_KLObs
                SFBL_KLObs.HrefValue = "";

                // SFBL_KL15
                SFBL_KL15.HrefValue = "";

                // SFBL_Barrels
                SFBL_Barrels.HrefValue = "";

                // SFBL_LT
                SFBL_LT.HrefValue = "";

                // SFBL_MT
                SFBL_MT.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // ExROB
                ExROB.HrefValue = "";

                // NoPenerimaan
                NoPenerimaan.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";
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

        private void ValidateCustomid() {
            if (id.Visible && id.Required) {
                if (!id.IsDetailKey && Empty(id.FormValue)) {
                    id.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
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

        private void ValidateCustomidAktifitas() {
            if (idAktifitas.Visible && idAktifitas.Required) {
                if (!idAktifitas.IsDetailKey && Empty(idAktifitas.FormValue)) {
                    idAktifitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
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

        private void ValidateCustomNewBL_KLObs() {
            if (NewBL_KLObs.Visible && NewBL_KLObs.Required) {
                if (!NewBL_KLObs.IsDetailKey && Empty(NewBL_KLObs.FormValue)) {
                    NewBL_KLObs.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_KL15() {
            if (NewBL_KL15.Visible && NewBL_KL15.Required) {
                if (!NewBL_KL15.IsDetailKey && Empty(NewBL_KL15.FormValue)) {
                    NewBL_KL15.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_Barrels() {
            if (NewBL_Barrels.Visible && NewBL_Barrels.Required) {
                if (!NewBL_Barrels.IsDetailKey && Empty(NewBL_Barrels.FormValue)) {
                    NewBL_Barrels.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_LT() {
            if (NewBL_LT.Visible && NewBL_LT.Required) {
                if (!NewBL_LT.IsDetailKey && Empty(NewBL_LT.FormValue)) {
                    NewBL_LT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_MT() {
            if (NewBL_MT.Visible && NewBL_MT.Required) {
                if (!NewBL_MT.IsDetailKey && Empty(NewBL_MT.FormValue)) {
                    NewBL_MT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_KLObs() {
            if (SFAD_KLObs.Visible && SFAD_KLObs.Required) {
                if (!SFAD_KLObs.IsDetailKey && Empty(SFAD_KLObs.FormValue)) {
                    SFAD_KLObs.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_KL15() {
            if (SFAD_KL15.Visible && SFAD_KL15.Required) {
                if (!SFAD_KL15.IsDetailKey && Empty(SFAD_KL15.FormValue)) {
                    SFAD_KL15.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_Barrels() {
            if (SFAD_Barrels.Visible && SFAD_Barrels.Required) {
                if (!SFAD_Barrels.IsDetailKey && Empty(SFAD_Barrels.FormValue)) {
                    SFAD_Barrels.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_MT() {
            if (SFAD_MT.Visible && SFAD_MT.Required) {
                if (!SFAD_MT.IsDetailKey && Empty(SFAD_MT.FormValue)) {
                    SFAD_MT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_LT() {
            if (SFAD_LT.Visible && SFAD_LT.Required) {
                if (!SFAD_LT.IsDetailKey && Empty(SFAD_LT.FormValue)) {
                    SFAD_LT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFBL_KLObs() {
            if (SFBL_KLObs.Visible && SFBL_KLObs.Required) {
                if (!SFBL_KLObs.IsDetailKey && Empty(SFBL_KLObs.FormValue)) {
                    SFBL_KLObs.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFBL_KL15() {
            if (SFBL_KL15.Visible && SFBL_KL15.Required) {
                if (!SFBL_KL15.IsDetailKey && Empty(SFBL_KL15.FormValue)) {
                    SFBL_KL15.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFBL_Barrels() {
            if (SFBL_Barrels.Visible && SFBL_Barrels.Required) {
                if (!SFBL_Barrels.IsDetailKey && Empty(SFBL_Barrels.FormValue)) {
                    SFBL_Barrels.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFBL_LT() {
            if (SFBL_LT.Visible && SFBL_LT.Required) {
                if (!SFBL_LT.IsDetailKey && Empty(SFBL_LT.FormValue)) {
                    SFBL_LT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomSFBL_MT() {
            if (SFBL_MT.Visible && SFBL_MT.Required) {
                if (!SFBL_MT.IsDetailKey && Empty(SFBL_MT.FormValue)) {
                    SFBL_MT.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
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

        private void ValidateCustomExROB() {
            if (ExROB.Visible && ExROB.Required) {
                if (Empty(ExROB.FormValue)) {
                    ExROB.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                }
            }
        }

        private void ValidateCustomNoPenerimaan() {
            if (NoPenerimaan.Visible && NoPenerimaan.Required) {
                if (!NoPenerimaan.IsDetailKey && Empty(NoPenerimaan.FormValue)) {
                    NoPenerimaan.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
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
                ValidateCustomid();
                ValidateCustomidProses();
                ValidateCustomidAktifitas();
                ValidateCustomNoReferensi();
                ValidateCustomNewBL_KLObs();
                ValidateCustomNewBL_KL15();
                ValidateCustomNewBL_Barrels();
                ValidateCustomNewBL_LT();
                ValidateCustomNewBL_MT();
                ValidateCustomSFAD_KLObs();
                ValidateCustomSFAD_KL15();
                ValidateCustomSFAD_Barrels();
                ValidateCustomSFAD_MT();
                ValidateCustomSFAD_LT();
                ValidateCustomSFBL_KLObs();
                ValidateCustomSFBL_KL15();
                ValidateCustomSFBL_Barrels();
                ValidateCustomSFBL_LT();
                ValidateCustomSFBL_MT();
                ValidateCustomuserInput();
                ValidateCustometlDate();
                if (!CheckDate(etlDate.FormValue, etlDate.FormatPattern)) {
                    etlDate.AddErrorMessage(etlDate.GetErrorMessage(false));
                }
                ValidateCustomLastUpdatedBy();
                ValidateCustomlastUpdatedDate();
                ValidateCustomExROB();
                ValidateCustomNoPenerimaan();
                ValidateCustomStatusAktivitas();

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

            // NewBL_KLObs
            NewBL_KLObs.SetDbValue(rsnew, NewBL_KLObs.CurrentValue, NewBL_KLObs.ReadOnly);

            // NewBL_KL15
            NewBL_KL15.SetDbValue(rsnew, NewBL_KL15.CurrentValue, NewBL_KL15.ReadOnly);

            // NewBL_Barrels
            NewBL_Barrels.SetDbValue(rsnew, NewBL_Barrels.CurrentValue, NewBL_Barrels.ReadOnly);

            // NewBL_LT
            NewBL_LT.SetDbValue(rsnew, NewBL_LT.CurrentValue, NewBL_LT.ReadOnly);

            // NewBL_MT
            NewBL_MT.SetDbValue(rsnew, NewBL_MT.CurrentValue, NewBL_MT.ReadOnly);

            // SFAD_KLObs
            SFAD_KLObs.SetDbValue(rsnew, SFAD_KLObs.CurrentValue, SFAD_KLObs.ReadOnly);

            // SFAD_KL15
            SFAD_KL15.SetDbValue(rsnew, SFAD_KL15.CurrentValue, SFAD_KL15.ReadOnly);

            // SFAD_Barrels
            SFAD_Barrels.SetDbValue(rsnew, SFAD_Barrels.CurrentValue, SFAD_Barrels.ReadOnly);

            // SFAD_MT
            SFAD_MT.SetDbValue(rsnew, SFAD_MT.CurrentValue, SFAD_MT.ReadOnly);

            // SFAD_LT
            SFAD_LT.SetDbValue(rsnew, SFAD_LT.CurrentValue, SFAD_LT.ReadOnly);

            // SFBL_KLObs
            SFBL_KLObs.SetDbValue(rsnew, SFBL_KLObs.CurrentValue, SFBL_KLObs.ReadOnly);

            // SFBL_KL15
            SFBL_KL15.SetDbValue(rsnew, SFBL_KL15.CurrentValue, SFBL_KL15.ReadOnly);

            // SFBL_Barrels
            SFBL_Barrels.SetDbValue(rsnew, SFBL_Barrels.CurrentValue, SFBL_Barrels.ReadOnly);

            // SFBL_LT
            SFBL_LT.SetDbValue(rsnew, SFBL_LT.CurrentValue, SFBL_LT.ReadOnly);

            // SFBL_MT
            SFBL_MT.SetDbValue(rsnew, SFBL_MT.CurrentValue, SFBL_MT.ReadOnly);

            // userInput
            userInput.SetDbValue(rsnew, userInput.CurrentValue, userInput.ReadOnly);

            // etlDate
            etlDate.SetDbValue(rsnew, ConvertToDateTime(etlDate.CurrentValue, etlDate.FormatPattern), etlDate.ReadOnly);

            // ExROB
            ExROB.SetDbValue(rsnew, ConvertToBool(ExROB.CurrentValue), ExROB.ReadOnly);

            // NoPenerimaan
            NoPenerimaan.SetDbValue(rsnew, NoPenerimaan.CurrentValue, NoPenerimaan.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("NewBL_KLObs", out value)) // NewBL_KLObs
                NewBL_KLObs.CurrentValue = value;
            if (row.TryGetValue("NewBL_KL15", out value)) // NewBL_KL15
                NewBL_KL15.CurrentValue = value;
            if (row.TryGetValue("NewBL_Barrels", out value)) // NewBL_Barrels
                NewBL_Barrels.CurrentValue = value;
            if (row.TryGetValue("NewBL_LT", out value)) // NewBL_LT
                NewBL_LT.CurrentValue = value;
            if (row.TryGetValue("NewBL_MT", out value)) // NewBL_MT
                NewBL_MT.CurrentValue = value;
            if (row.TryGetValue("SFAD_KLObs", out value)) // SFAD_KLObs
                SFAD_KLObs.CurrentValue = value;
            if (row.TryGetValue("SFAD_KL15", out value)) // SFAD_KL15
                SFAD_KL15.CurrentValue = value;
            if (row.TryGetValue("SFAD_Barrels", out value)) // SFAD_Barrels
                SFAD_Barrels.CurrentValue = value;
            if (row.TryGetValue("SFAD_MT", out value)) // SFAD_MT
                SFAD_MT.CurrentValue = value;
            if (row.TryGetValue("SFAD_LT", out value)) // SFAD_LT
                SFAD_LT.CurrentValue = value;
            if (row.TryGetValue("SFBL_KLObs", out value)) // SFBL_KLObs
                SFBL_KLObs.CurrentValue = value;
            if (row.TryGetValue("SFBL_KL15", out value)) // SFBL_KL15
                SFBL_KL15.CurrentValue = value;
            if (row.TryGetValue("SFBL_Barrels", out value)) // SFBL_Barrels
                SFBL_Barrels.CurrentValue = value;
            if (row.TryGetValue("SFBL_LT", out value)) // SFBL_LT
                SFBL_LT.CurrentValue = value;
            if (row.TryGetValue("SFBL_MT", out value)) // SFBL_MT
                SFBL_MT.CurrentValue = value;
            if (row.TryGetValue("userInput", out value)) // userInput
                userInput.CurrentValue = value;
            if (row.TryGetValue("etlDate", out value)) // etlDate
                etlDate.CurrentValue = value;
            if (row.TryGetValue("ExROB", out value)) // ExROB
                ExROB.CurrentValue = value;
            if (row.TryGetValue("NoPenerimaan", out value)) // NoPenerimaan
                NoPenerimaan.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasNilaiNewBlsfadsfblList")), "", TableVar, true);
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
                switch (fld.FieldVar) {
                    case "x_NoPenerimaan":
                        lookupFilter = () => fld.GetSelectFilter();
                        break;
                }

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
