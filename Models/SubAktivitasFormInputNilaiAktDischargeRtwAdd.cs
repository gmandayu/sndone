using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasFormInputNilaiAktDischargeRtwAdd
    /// </summary>
    public static SubAktivitasFormInputNilaiAktDischargeRtwAdd subAktivitasFormInputNilaiAktDischargeRtwAdd
    {
        get => HttpData.Get<SubAktivitasFormInputNilaiAktDischargeRtwAdd>("subAktivitasFormInputNilaiAktDischargeRtwAdd")!;
        set => HttpData["subAktivitasFormInputNilaiAktDischargeRtwAdd"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasFormInputNilaiAktDischargeRTW
    /// </summary>
    public class SubAktivitasFormInputNilaiAktDischargeRtwAdd : SubAktivitasFormInputNilaiAktDischargeRtwAddBase
    {
        // Constructor
        public SubAktivitasFormInputNilaiAktDischargeRtwAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasFormInputNilaiAktDischargeRtwAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasFormInputNilaiAktDischargeRtwAddBase : SubAktivitasFormInputNilaiAktDischargeRtw
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasFormInputNilaiAktDischargeRtwAdd";

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
        public SubAktivitasFormInputNilaiAktDischargeRtwAddBase(Controller? controller)
        {
            TableName = "SubAktivitasFormInputNilaiAktDischargeRTW";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasFormInputNilaiAktDischargeRtw)
            if (subAktivitasFormInputNilaiAktDischargeRtw == null || subAktivitasFormInputNilaiAktDischargeRtw is SubAktivitasFormInputNilaiAktDischargeRtw)
                subAktivitasFormInputNilaiAktDischargeRtw = this;

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
        public string PageName => "SubAktivitasFormInputNilaiAktDischargeRtwAdd";

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
            NoReferensi.SetVisibility();
            idProses.SetVisibility();
            idAktifitas.SetVisibility();
            StatusAktivitas.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            Import.SetVisibility();
            ApakahAdaROB.SetVisibility();
            Tujuan.SetVisibility();
            SFAD_KLObs.SetVisibility();
            SFAD_KL15.SetVisibility();
            SFAD_Barrels.SetVisibility();
            SFAD_LT.SetVisibility();
            SFAD_MT.SetVisibility();
            NewBL_KLObs.SetVisibility();
            NewBL_KL15.SetVisibility();
            NewBL_Barrels.SetVisibility();
            NewBL_LT.SetVisibility();
            NewBL_MT.SetVisibility();
            userInput.SetVisibility();
            etlDate.SetVisibility();
            AR45B_klobs.SetVisibility();
            AR45B_kl15.SetVisibility();
            AR45B_Barrel.SetVisibility();
            AR45B_lt.SetVisibility();
            AR45B_mt.SetVisibility();
        }

        // Constructor
        public SubAktivitasFormInputNilaiAktDischargeRtwAddBase() : this(null) { }

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
                        result.Add("view", pageName == "SubAktivitasFormInputNilaiAktDischargeRtwView" ? "1" : "0"); // If View page, no primary button
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
                return Terminate("SubAktivitasFormInputNilaiAktDischargeRtwList");
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
            if (GetPageName(returnUrl) == "SubAktivitasFormInputNilaiAktDischargeRtwList")
                returnUrl = AddMasterUrl(ListUrl);
            else if (GetPageName(returnUrl) == "SubAktivitasFormInputNilaiAktDischargeRtwView")
                returnUrl = ViewUrl;
            return returnUrl;
        }

        private void HandleAjaxActions(ref string returnUrl)
        {
            if (IsModal && UseAjaxActions) {
                IsModal = false;
                if (GetPageName(returnUrl) != "SubAktivitasFormInputNilaiAktDischargeRtwList") {
                    TempData["Return-Url"] = returnUrl;
                    returnUrl = "SubAktivitasFormInputNilaiAktDischargeRtwList";
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
                    await SetupLookupOptions(idProses);
                    await SetupLookupOptions(idAktifitas);
                    await SetupLookupOptions(StatusAktivitas);
                    await SetupLookupOptions(Import);
                    await SetupLookupOptions(ApakahAdaROB);
                    await SetupLookupOptions(Tujuan);

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
                        subAktivitasFormInputNilaiAktDischargeRtwAdd?.PageRender();
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

            // Standard handling for 'NoReferensi'
            NoReferensi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NoReferensi, "NoReferensi", "x_NoReferensi");

            // Standard handling for 'idProses'
            idProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idProses, "idProses", "x_idProses", true, validate, false);

            // Standard handling for 'idAktifitas'
            idAktifitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idAktifitas, "idAktifitas", "x_idAktifitas", true, validate, false);

            // Standard handling for 'StatusAktivitas'
            StatusAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(StatusAktivitas, "StatusAktivitas", "x_StatusAktivitas", true, validate, false);

            // Standard handling for 'LastUpdatedBy'
            LastUpdatedBy.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LastUpdatedBy, "LastUpdatedBy", "x_LastUpdatedBy");

            // Standard handling for 'lastUpdatedDate'
            lastUpdatedDate.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(lastUpdatedDate, "lastUpdatedDate", "x_lastUpdatedDate", true, validate, true);

            // Standard handling for 'Import'
            Import.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Import, "Import", "x_Import");

            // Standard handling for 'ApakahAdaROB'
            ApakahAdaROB.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(ApakahAdaROB, "ApakahAdaROB", "x_ApakahAdaROB");

            // Standard handling for 'Tujuan'
            Tujuan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Tujuan, "Tujuan", "x_Tujuan");

            // Standard handling for 'SFAD_KLObs'
            SFAD_KLObs.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_KLObs, "SFAD_KLObs", "x_SFAD_KLObs");

            // Standard handling for 'SFAD_KL15'
            SFAD_KL15.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_KL15, "SFAD_KL15", "x_SFAD_KL15");

            // Standard handling for 'SFAD_Barrels'
            SFAD_Barrels.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_Barrels, "SFAD_Barrels", "x_SFAD_Barrels");

            // Standard handling for 'SFAD_LT'
            SFAD_LT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_LT, "SFAD_LT", "x_SFAD_LT");

            // Standard handling for 'SFAD_MT'
            SFAD_MT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SFAD_MT, "SFAD_MT", "x_SFAD_MT");

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

            // Standard handling for 'userInput'
            userInput.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(userInput, "userInput", "x_userInput");

            // Standard handling for 'etlDate'
            etlDate.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(etlDate, "etlDate", "x_etlDate", true, validate, true);

            // Standard handling for 'AR45B_klobs'
            AR45B_klobs.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(AR45B_klobs, "AR45B_klobs", "x_AR45B_klobs");

            // Standard handling for 'AR45B_kl15'
            AR45B_kl15.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(AR45B_kl15, "AR45B_kl15", "x_AR45B_kl15");

            // Standard handling for 'AR45B_Barrel'
            AR45B_Barrel.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(AR45B_Barrel, "AR45B_Barrel", "x_AR45B_Barrel");

            // Standard handling for 'AR45B_lt'
            AR45B_lt.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(AR45B_lt, "AR45B_lt", "x_AR45B_lt");

            // Standard handling for 'AR45B_mt'
            AR45B_mt.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(AR45B_mt, "AR45B_mt", "x_AR45B_mt");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            Import.CurrentValue = Import.FormValue;
            ApakahAdaROB.CurrentValue = ApakahAdaROB.FormValue;
            Tujuan.CurrentValue = Tujuan.FormValue;
            SFAD_KLObs.CurrentValue = SFAD_KLObs.FormValue;
            SFAD_KL15.CurrentValue = SFAD_KL15.FormValue;
            SFAD_Barrels.CurrentValue = SFAD_Barrels.FormValue;
            SFAD_LT.CurrentValue = SFAD_LT.FormValue;
            SFAD_MT.CurrentValue = SFAD_MT.FormValue;
            NewBL_KLObs.CurrentValue = NewBL_KLObs.FormValue;
            NewBL_KL15.CurrentValue = NewBL_KL15.FormValue;
            NewBL_Barrels.CurrentValue = NewBL_Barrels.FormValue;
            NewBL_LT.CurrentValue = NewBL_LT.FormValue;
            NewBL_MT.CurrentValue = NewBL_MT.FormValue;
            userInput.CurrentValue = userInput.FormValue;
            etlDate.CurrentValue = etlDate.FormValue;
            etlDate.CurrentValue = UnformatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            AR45B_klobs.CurrentValue = AR45B_klobs.FormValue;
            AR45B_kl15.CurrentValue = AR45B_kl15.FormValue;
            AR45B_Barrel.CurrentValue = AR45B_Barrel.FormValue;
            AR45B_lt.CurrentValue = AR45B_lt.FormValue;
            AR45B_mt.CurrentValue = AR45B_mt.FormValue;
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
            NoReferensi.SetDbValue(row["NoReferensi"]);
            idProses.SetDbValue(row["idProses"]);
            idAktifitas.SetDbValue(row["idAktifitas"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            Import.SetDbValue((ConvertToBool(row["Import"]) ? "1" : "0"));
            ApakahAdaROB.SetDbValue((ConvertToBool(row["ApakahAdaROB"]) ? "1" : "0"));
            Tujuan.SetDbValue(row["Tujuan"]);
            SFAD_KLObs.SetDbValue(row["SFAD_KLObs"]);
            SFAD_KL15.SetDbValue(row["SFAD_KL15"]);
            SFAD_Barrels.SetDbValue(row["SFAD_Barrels"]);
            SFAD_LT.SetDbValue(row["SFAD_LT"]);
            SFAD_MT.SetDbValue(row["SFAD_MT"]);
            NewBL_KLObs.SetDbValue(row["NewBL_KLObs"]);
            NewBL_KL15.SetDbValue(row["NewBL_KL15"]);
            NewBL_Barrels.SetDbValue(row["NewBL_Barrels"]);
            NewBL_LT.SetDbValue(row["NewBL_LT"]);
            NewBL_MT.SetDbValue(row["NewBL_MT"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            AR45B_klobs.SetDbValue(row["AR45B_klobs"]);
            AR45B_kl15.SetDbValue(row["AR45B_kl15"]);
            AR45B_Barrel.SetDbValue(row["AR45B_Barrel"]);
            AR45B_lt.SetDbValue(row["AR45B_lt"]);
            AR45B_mt.SetDbValue(row["AR45B_mt"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("Import", Import.DefaultValue ?? DbNullValue); // DN
            row.Add("ApakahAdaROB", ApakahAdaROB.DefaultValue ?? DbNullValue); // DN
            row.Add("Tujuan", Tujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_KLObs", SFAD_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_KL15", SFAD_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_Barrels", SFAD_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_LT", SFAD_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_MT", SFAD_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_KLObs", NewBL_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_KL15", NewBL_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_Barrels", NewBL_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_LT", NewBL_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_MT", NewBL_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_klobs", AR45B_klobs.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_kl15", AR45B_kl15.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_Barrel", AR45B_Barrel.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_lt", AR45B_lt.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_mt", AR45B_mt.DefaultValue ?? DbNullValue); // DN
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

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // idProses
            idProses.RowCssClass = "row";

            // idAktifitas
            idAktifitas.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // Import
            Import.RowCssClass = "row";

            // ApakahAdaROB
            ApakahAdaROB.RowCssClass = "row";

            // Tujuan
            Tujuan.RowCssClass = "row";

            // SFAD_KLObs
            SFAD_KLObs.RowCssClass = "row";

            // SFAD_KL15
            SFAD_KL15.RowCssClass = "row";

            // SFAD_Barrels
            SFAD_Barrels.RowCssClass = "row";

            // SFAD_LT
            SFAD_LT.RowCssClass = "row";

            // SFAD_MT
            SFAD_MT.RowCssClass = "row";

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

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // AR45B_klobs
            AR45B_klobs.RowCssClass = "row";

            // AR45B_kl15
            AR45B_kl15.RowCssClass = "row";

            // AR45B_Barrel
            AR45B_Barrel.RowCssClass = "row";

            // AR45B_lt
            AR45B_lt.RowCssClass = "row";

            // AR45B_mt
            AR45B_mt.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // NoReferensi

                // idProses

                // idAktifitas

                // StatusAktivitas

                // LastUpdatedBy

                // lastUpdatedDate

                // Import

                // ApakahAdaROB

                // Tujuan

                // SFAD_KLObs

                // SFAD_KL15

                // SFAD_Barrels

                // SFAD_LT

                // SFAD_MT

                // NewBL_KLObs

                // NewBL_KL15

                // NewBL_Barrels

                // NewBL_LT

                // NewBL_MT

                // userInput

                // etlDate

                // AR45B_klobs

                // AR45B_kl15

                // AR45B_Barrel

                // AR45B_lt

                // AR45B_mt

                    // id
                    id.ViewValue = id.CurrentValue;
                    id.ViewCustomAttributes = "";

                    // NoReferensi
                    NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                    NoReferensi.ViewCustomAttributes = "";

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

                    // StatusAktivitas
                    StatusAktivitas.ViewValue = StatusAktivitas.CurrentValue;

                    // awallookupbung
                    // StatusAktivitas
                    ResolveLookupView(StatusAktivitas, "IdAktivitas", "number");
                    // akhirlookupbung
                    StatusAktivitas.ViewCustomAttributes = "";

                    // LastUpdatedBy
                    LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                    LastUpdatedBy.ViewCustomAttributes = "";

                    // lastUpdatedDate
                    lastUpdatedDate.ViewValue = lastUpdatedDate.CurrentValue;
                    lastUpdatedDate.ViewValue = FormatDateTime(lastUpdatedDate.ViewValue, lastUpdatedDate.FormatPattern);
                    lastUpdatedDate.ViewCustomAttributes = "";

                    // Import
                    if (ConvertToBool(Import.CurrentValue)) {
                        Import.ViewValue = Import.TagCaption(1) != "" ? Import.TagCaption(1) : "Yes";
                    } else {
                        Import.ViewValue = Import.TagCaption(2) != "" ? Import.TagCaption(2) : "No";
                    }
                    Import.ViewCustomAttributes = "";

                    // ApakahAdaROB
                    if (ConvertToBool(ApakahAdaROB.CurrentValue)) {
                        ApakahAdaROB.ViewValue = ApakahAdaROB.TagCaption(1) != "" ? ApakahAdaROB.TagCaption(1) : "Yes";
                    } else {
                        ApakahAdaROB.ViewValue = ApakahAdaROB.TagCaption(2) != "" ? ApakahAdaROB.TagCaption(2) : "No";
                    }
                    ApakahAdaROB.ViewCustomAttributes = "";

                    // Tujuan

                    // awallookupbung
                    // Tujuan (jaga leading zero)
                    ResolveLookupView(Tujuan, "IdPlant", "string");
                    // akhirlookupbung
                    Tujuan.ViewCustomAttributes = "";

                    // SFAD_KLObs
                    SFAD_KLObs.ViewValue = ConvertToString(SFAD_KLObs.CurrentValue); // DN
                    SFAD_KLObs.ViewCustomAttributes = "";

                    // SFAD_KL15
                    SFAD_KL15.ViewValue = ConvertToString(SFAD_KL15.CurrentValue); // DN
                    SFAD_KL15.ViewCustomAttributes = "";

                    // SFAD_Barrels
                    SFAD_Barrels.ViewValue = ConvertToString(SFAD_Barrels.CurrentValue); // DN
                    SFAD_Barrels.ViewCustomAttributes = "";

                    // SFAD_LT
                    SFAD_LT.ViewValue = ConvertToString(SFAD_LT.CurrentValue); // DN
                    SFAD_LT.ViewCustomAttributes = "";

                    // SFAD_MT
                    SFAD_MT.ViewValue = ConvertToString(SFAD_MT.CurrentValue); // DN
                    SFAD_MT.ViewCustomAttributes = "";

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

                    // userInput
                    userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                    userInput.ViewCustomAttributes = "";

                    // etlDate
                    etlDate.ViewValue = etlDate.CurrentValue;
                    etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                    etlDate.ViewCustomAttributes = "";

                    // AR45B_klobs
                    AR45B_klobs.ViewValue = ConvertToString(AR45B_klobs.CurrentValue); // DN
                    AR45B_klobs.ViewCustomAttributes = "";

                    // AR45B_kl15
                    AR45B_kl15.ViewValue = ConvertToString(AR45B_kl15.CurrentValue); // DN
                    AR45B_kl15.ViewCustomAttributes = "";

                    // AR45B_Barrel
                    AR45B_Barrel.ViewValue = ConvertToString(AR45B_Barrel.CurrentValue); // DN
                    AR45B_Barrel.ViewCustomAttributes = "";

                    // AR45B_lt
                    AR45B_lt.ViewValue = ConvertToString(AR45B_lt.CurrentValue); // DN
                    AR45B_lt.ViewCustomAttributes = "";

                    // AR45B_mt
                    AR45B_mt.ViewValue = ConvertToString(AR45B_mt.CurrentValue); // DN
                    AR45B_mt.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // Import
                Import.HrefValue = "";

                // ApakahAdaROB
                ApakahAdaROB.HrefValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // SFAD_KLObs
                SFAD_KLObs.HrefValue = "";

                // SFAD_KL15
                SFAD_KL15.HrefValue = "";

                // SFAD_Barrels
                SFAD_Barrels.HrefValue = "";

                // SFAD_LT
                SFAD_LT.HrefValue = "";

                // SFAD_MT
                SFAD_MT.HrefValue = "";

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

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // AR45B_klobs
                AR45B_klobs.HrefValue = "";

                // AR45B_kl15
                AR45B_kl15.HrefValue = "";

                // AR45B_Barrel
                AR45B_Barrel.HrefValue = "";

                // AR45B_lt
                AR45B_lt.HrefValue = "";

                // AR45B_mt
                AR45B_mt.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;

                // awallookupbung
                string curVal = ConvertToString(idProses.CurrentValue);
                idProses.EditValue = Empty(curVal) ? DbNullValue : HtmlEncode(FormatNumber(idProses.CurrentValue, idProses.FormatPattern));
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
                idProses.PlaceHolder = RemoveHtml(idProses.Caption);
                if (!Empty(idProses.EditValue) && IsNumeric(idProses.EditValue))
                    idProses.EditValue = FormatNumber(idProses.EditValue, null);

                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;

                // awallookupbung
                string curVal2 = ConvertToString(idAktifitas.CurrentValue);
                idAktifitas.EditValue = Empty(curVal2) ? DbNullValue : HtmlEncode(FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern));
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
                idAktifitas.PlaceHolder = RemoveHtml(idAktifitas.Caption);
                if (!Empty(idAktifitas.EditValue) && IsNumeric(idAktifitas.EditValue))
                    idAktifitas.EditValue = FormatNumber(idAktifitas.EditValue, null);

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

                // Import
                Import.EditValue = Import.Options(false);
                Import.PlaceHolder = RemoveHtml(Import.Caption);

                // ApakahAdaROB
                ApakahAdaROB.EditValue = ApakahAdaROB.Options(false);
                ApakahAdaROB.PlaceHolder = RemoveHtml(ApakahAdaROB.Caption);

                // Tujuan
                Tujuan.SetupEditAttributes();
                string curVal6 = ConvertToString(Tujuan.CurrentValue);
                if (Tujuan.Lookup != null && IsDictionary(Tujuan.Lookup?.Options) && Tujuan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Tujuan.EditValue = Tujuan.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk6 = "";
                    if (curVal6 == "") {
                        filterWrk6 = "0=1";
                    } else {
                        filterWrk6 = SearchFilter(Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Tujuan.CurrentValue, Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk6 = Tujuan.Lookup?.GetSql(true, filterWrk6, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk6 = sqlWrk6 != null ? Connection.GetRows(sqlWrk6) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Tujuan.EditValue = rswrk6;
                }
                Tujuan.PlaceHolder = RemoveHtml(Tujuan.Caption);

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

                // SFAD_LT
                SFAD_LT.SetupEditAttributes();
                if (!SFAD_LT.Raw)
                    SFAD_LT.CurrentValue = HtmlDecode(SFAD_LT.CurrentValue);
                SFAD_LT.EditValue = HtmlEncode(SFAD_LT.CurrentValue);
                SFAD_LT.PlaceHolder = RemoveHtml(SFAD_LT.Caption);

                // SFAD_MT
                SFAD_MT.SetupEditAttributes();
                if (!SFAD_MT.Raw)
                    SFAD_MT.CurrentValue = HtmlDecode(SFAD_MT.CurrentValue);
                SFAD_MT.EditValue = HtmlEncode(SFAD_MT.CurrentValue);
                SFAD_MT.PlaceHolder = RemoveHtml(SFAD_MT.Caption);

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

                // AR45B_klobs
                AR45B_klobs.SetupEditAttributes();
                if (!AR45B_klobs.Raw)
                    AR45B_klobs.CurrentValue = HtmlDecode(AR45B_klobs.CurrentValue);
                AR45B_klobs.EditValue = HtmlEncode(AR45B_klobs.CurrentValue);
                AR45B_klobs.PlaceHolder = RemoveHtml(AR45B_klobs.Caption);

                // AR45B_kl15
                AR45B_kl15.SetupEditAttributes();
                if (!AR45B_kl15.Raw)
                    AR45B_kl15.CurrentValue = HtmlDecode(AR45B_kl15.CurrentValue);
                AR45B_kl15.EditValue = HtmlEncode(AR45B_kl15.CurrentValue);
                AR45B_kl15.PlaceHolder = RemoveHtml(AR45B_kl15.Caption);

                // AR45B_Barrel
                AR45B_Barrel.SetupEditAttributes();
                if (!AR45B_Barrel.Raw)
                    AR45B_Barrel.CurrentValue = HtmlDecode(AR45B_Barrel.CurrentValue);
                AR45B_Barrel.EditValue = HtmlEncode(AR45B_Barrel.CurrentValue);
                AR45B_Barrel.PlaceHolder = RemoveHtml(AR45B_Barrel.Caption);

                // AR45B_lt
                AR45B_lt.SetupEditAttributes();
                if (!AR45B_lt.Raw)
                    AR45B_lt.CurrentValue = HtmlDecode(AR45B_lt.CurrentValue);
                AR45B_lt.EditValue = HtmlEncode(AR45B_lt.CurrentValue);
                AR45B_lt.PlaceHolder = RemoveHtml(AR45B_lt.Caption);

                // AR45B_mt
                AR45B_mt.SetupEditAttributes();
                if (!AR45B_mt.Raw)
                    AR45B_mt.CurrentValue = HtmlDecode(AR45B_mt.CurrentValue);
                AR45B_mt.EditValue = HtmlEncode(AR45B_mt.CurrentValue);
                AR45B_mt.PlaceHolder = RemoveHtml(AR45B_mt.Caption);

                // Add refer script

                // NoReferensi
                NoReferensi.HrefValue = "";

                // idProses
                idProses.HrefValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";

                // Import
                Import.HrefValue = "";

                // ApakahAdaROB
                ApakahAdaROB.HrefValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // SFAD_KLObs
                SFAD_KLObs.HrefValue = "";

                // SFAD_KL15
                SFAD_KL15.HrefValue = "";

                // SFAD_Barrels
                SFAD_Barrels.HrefValue = "";

                // SFAD_LT
                SFAD_LT.HrefValue = "";

                // SFAD_MT
                SFAD_MT.HrefValue = "";

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

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // AR45B_klobs
                AR45B_klobs.HrefValue = "";

                // AR45B_kl15
                AR45B_kl15.HrefValue = "";

                // AR45B_Barrel
                AR45B_Barrel.HrefValue = "";

                // AR45B_lt
                AR45B_lt.HrefValue = "";

                // AR45B_mt
                AR45B_mt.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998

        private void ValidateCustomNoReferensi() {
            if (NoReferensi.Visible && NoReferensi.Required) {
                if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                    NoReferensi.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomidProses() {
            if (idProses.Visible && idProses.Required) {
                if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                    idProses.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomidAktifitas() {
            if (idAktifitas.Visible && idAktifitas.Required) {
                if (!idAktifitas.IsDetailKey && Empty(idAktifitas.FormValue)) {
                    idAktifitas.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomStatusAktivitas() {
            if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                    StatusAktivitas.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomLastUpdatedBy() {
            if (LastUpdatedBy.Visible && LastUpdatedBy.Required) {
                if (!LastUpdatedBy.IsDetailKey && Empty(LastUpdatedBy.FormValue)) {
                    LastUpdatedBy.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomlastUpdatedDate() {
            if (lastUpdatedDate.Visible && lastUpdatedDate.Required) {
                if (!lastUpdatedDate.IsDetailKey && Empty(lastUpdatedDate.FormValue)) {
                    lastUpdatedDate.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomImport() {
            if (Import.Visible && Import.Required) {
                if (Empty(Import.FormValue)) {
                    Import.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomApakahAdaROB() {
            if (ApakahAdaROB.Visible && ApakahAdaROB.Required) {
                if (Empty(ApakahAdaROB.FormValue)) {
                    ApakahAdaROB.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomTujuan() {
            if (Tujuan.Visible && Tujuan.Required) {
                if (!Tujuan.IsDetailKey && Empty(Tujuan.FormValue)) {
                    Tujuan.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_KLObs() {
            if (SFAD_KLObs.Visible && SFAD_KLObs.Required) {
                if (!SFAD_KLObs.IsDetailKey && Empty(SFAD_KLObs.FormValue)) {
                    SFAD_KLObs.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_KL15() {
            if (SFAD_KL15.Visible && SFAD_KL15.Required) {
                if (!SFAD_KL15.IsDetailKey && Empty(SFAD_KL15.FormValue)) {
                    SFAD_KL15.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_Barrels() {
            if (SFAD_Barrels.Visible && SFAD_Barrels.Required) {
                if (!SFAD_Barrels.IsDetailKey && Empty(SFAD_Barrels.FormValue)) {
                    SFAD_Barrels.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_LT() {
            if (SFAD_LT.Visible && SFAD_LT.Required) {
                if (!SFAD_LT.IsDetailKey && Empty(SFAD_LT.FormValue)) {
                    SFAD_LT.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomSFAD_MT() {
            if (SFAD_MT.Visible && SFAD_MT.Required) {
                if (!SFAD_MT.IsDetailKey && Empty(SFAD_MT.FormValue)) {
                    SFAD_MT.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_KLObs() {
            if (NewBL_KLObs.Visible && NewBL_KLObs.Required) {
                if (!NewBL_KLObs.IsDetailKey && Empty(NewBL_KLObs.FormValue)) {
                    NewBL_KLObs.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_KL15() {
            if (NewBL_KL15.Visible && NewBL_KL15.Required) {
                if (!NewBL_KL15.IsDetailKey && Empty(NewBL_KL15.FormValue)) {
                    NewBL_KL15.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_Barrels() {
            if (NewBL_Barrels.Visible && NewBL_Barrels.Required) {
                if (!NewBL_Barrels.IsDetailKey && Empty(NewBL_Barrels.FormValue)) {
                    NewBL_Barrels.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_LT() {
            if (NewBL_LT.Visible && NewBL_LT.Required) {
                if (!NewBL_LT.IsDetailKey && Empty(NewBL_LT.FormValue)) {
                    NewBL_LT.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomNewBL_MT() {
            if (NewBL_MT.Visible && NewBL_MT.Required) {
                if (!NewBL_MT.IsDetailKey && Empty(NewBL_MT.FormValue)) {
                    NewBL_MT.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomuserInput() {
            if (userInput.Visible && userInput.Required) {
                if (!userInput.IsDetailKey && Empty(userInput.FormValue)) {
                    userInput.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustometlDate() {
            if (etlDate.Visible && etlDate.Required) {
                if (!etlDate.IsDetailKey && Empty(etlDate.FormValue)) {
                    etlDate.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomAR45B_klobs() {
            if (AR45B_klobs.Visible && AR45B_klobs.Required) {
                if (!AR45B_klobs.IsDetailKey && Empty(AR45B_klobs.FormValue)) {
                    AR45B_klobs.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomAR45B_kl15() {
            if (AR45B_kl15.Visible && AR45B_kl15.Required) {
                if (!AR45B_kl15.IsDetailKey && Empty(AR45B_kl15.FormValue)) {
                    AR45B_kl15.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomAR45B_Barrel() {
            if (AR45B_Barrel.Visible && AR45B_Barrel.Required) {
                if (!AR45B_Barrel.IsDetailKey && Empty(AR45B_Barrel.FormValue)) {
                    AR45B_Barrel.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomAR45B_lt() {
            if (AR45B_lt.Visible && AR45B_lt.Required) {
                if (!AR45B_lt.IsDetailKey && Empty(AR45B_lt.FormValue)) {
                    AR45B_lt.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        private void ValidateCustomAR45B_mt() {
            if (AR45B_mt.Visible && AR45B_mt.Required) {
                if (!AR45B_mt.IsDetailKey && Empty(AR45B_mt.FormValue)) {
                    AR45B_mt.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomNoReferensi();
                ValidateCustomidProses();
                if (!CheckInteger(idProses.FormValue)) {
                    idProses.AddErrorMessage(idProses.GetErrorMessage(false));
                }
                ValidateCustomidAktifitas();
                if (!CheckInteger(idAktifitas.FormValue)) {
                    idAktifitas.AddErrorMessage(idAktifitas.GetErrorMessage(false));
                }
                ValidateCustomStatusAktivitas();
                if (!CheckInteger(StatusAktivitas.FormValue)) {
                    StatusAktivitas.AddErrorMessage(StatusAktivitas.GetErrorMessage(false));
                }
                ValidateCustomLastUpdatedBy();
                ValidateCustomlastUpdatedDate();
                if (!CheckDate(lastUpdatedDate.FormValue, lastUpdatedDate.FormatPattern)) {
                    lastUpdatedDate.AddErrorMessage(lastUpdatedDate.GetErrorMessage(false));
                }
                ValidateCustomImport();
                ValidateCustomApakahAdaROB();
                ValidateCustomTujuan();
                ValidateCustomSFAD_KLObs();
                ValidateCustomSFAD_KL15();
                ValidateCustomSFAD_Barrels();
                ValidateCustomSFAD_LT();
                ValidateCustomSFAD_MT();
                ValidateCustomNewBL_KLObs();
                ValidateCustomNewBL_KL15();
                ValidateCustomNewBL_Barrels();
                ValidateCustomNewBL_LT();
                ValidateCustomNewBL_MT();
                ValidateCustomuserInput();
                ValidateCustometlDate();
                if (!CheckDate(etlDate.FormValue, etlDate.FormatPattern)) {
                    etlDate.AddErrorMessage(etlDate.GetErrorMessage(false));
                }
                ValidateCustomAR45B_klobs();
                ValidateCustomAR45B_kl15();
                ValidateCustomAR45B_Barrel();
                ValidateCustomAR45B_lt();
                ValidateCustomAR45B_mt();

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

                // NoReferensi
                NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue);

                // idProses
                idProses.SetDbValue(rsnew, idProses.CurrentValue);

                // idAktifitas
                idAktifitas.SetDbValue(rsnew, idAktifitas.CurrentValue);

                // StatusAktivitas
                StatusAktivitas.SetDbValue(rsnew, StatusAktivitas.CurrentValue);

                // LastUpdatedBy
                LastUpdatedBy.SetDbValue(rsnew, LastUpdatedBy.CurrentValue);

                // lastUpdatedDate
                lastUpdatedDate.SetDbValue(rsnew, ConvertToDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern));

                // Import
                Import.SetDbValue(rsnew, ConvertToBool(Import.CurrentValue));

                // ApakahAdaROB
                ApakahAdaROB.SetDbValue(rsnew, ConvertToBool(ApakahAdaROB.CurrentValue));

                // Tujuan
                Tujuan.SetDbValue(rsnew, Tujuan.CurrentValue);

                // SFAD_KLObs
                SFAD_KLObs.SetDbValue(rsnew, SFAD_KLObs.CurrentValue);

                // SFAD_KL15
                SFAD_KL15.SetDbValue(rsnew, SFAD_KL15.CurrentValue);

                // SFAD_Barrels
                SFAD_Barrels.SetDbValue(rsnew, SFAD_Barrels.CurrentValue);

                // SFAD_LT
                SFAD_LT.SetDbValue(rsnew, SFAD_LT.CurrentValue);

                // SFAD_MT
                SFAD_MT.SetDbValue(rsnew, SFAD_MT.CurrentValue);

                // NewBL_KLObs
                NewBL_KLObs.SetDbValue(rsnew, NewBL_KLObs.CurrentValue);

                // NewBL_KL15
                NewBL_KL15.SetDbValue(rsnew, NewBL_KL15.CurrentValue);

                // NewBL_Barrels
                NewBL_Barrels.SetDbValue(rsnew, NewBL_Barrels.CurrentValue);

                // NewBL_LT
                NewBL_LT.SetDbValue(rsnew, NewBL_LT.CurrentValue);

                // NewBL_MT
                NewBL_MT.SetDbValue(rsnew, NewBL_MT.CurrentValue);

                // userInput
                userInput.SetDbValue(rsnew, userInput.CurrentValue);

                // etlDate
                etlDate.SetDbValue(rsnew, ConvertToDateTime(etlDate.CurrentValue, etlDate.FormatPattern), Empty(etlDate.CurrentValue));

                // AR45B_klobs
                AR45B_klobs.SetDbValue(rsnew, AR45B_klobs.CurrentValue);

                // AR45B_kl15
                AR45B_kl15.SetDbValue(rsnew, AR45B_kl15.CurrentValue);

                // AR45B_Barrel
                AR45B_Barrel.SetDbValue(rsnew, AR45B_Barrel.CurrentValue);

                // AR45B_lt
                AR45B_lt.SetDbValue(rsnew, AR45B_lt.CurrentValue);

                // AR45B_mt
                AR45B_mt.SetDbValue(rsnew, AR45B_mt.CurrentValue);
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
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("idProses", out value)) // idProses
                idProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("idAktifitas", out value)) // idAktifitas
                idAktifitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusAktivitas", out value)) // StatusAktivitas
                StatusAktivitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LastUpdatedBy", out value)) // LastUpdatedBy
                LastUpdatedBy.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("lastUpdatedDate", out value)) // lastUpdatedDate
                lastUpdatedDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Import", out value)) // Import
                Import.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("ApakahAdaROB", out value)) // ApakahAdaROB
                ApakahAdaROB.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Tujuan", out value)) // Tujuan
                Tujuan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_KLObs", out value)) // SFAD_KLObs
                SFAD_KLObs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_KL15", out value)) // SFAD_KL15
                SFAD_KL15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_Barrels", out value)) // SFAD_Barrels
                SFAD_Barrels.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_LT", out value)) // SFAD_LT
                SFAD_LT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_MT", out value)) // SFAD_MT
                SFAD_MT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_KLObs", out value)) // NewBL_KLObs
                NewBL_KLObs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_KL15", out value)) // NewBL_KL15
                NewBL_KL15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_Barrels", out value)) // NewBL_Barrels
                NewBL_Barrels.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_LT", out value)) // NewBL_LT
                NewBL_LT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_MT", out value)) // NewBL_MT
                NewBL_MT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("userInput", out value)) // userInput
                userInput.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("etlDate", out value)) // etlDate
                etlDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_klobs", out value)) // AR45B_klobs
                AR45B_klobs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_kl15", out value)) // AR45B_kl15
                AR45B_kl15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_Barrel", out value)) // AR45B_Barrel
                AR45B_Barrel.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_lt", out value)) // AR45B_lt
                AR45B_lt.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_mt", out value)) // AR45B_mt
                AR45B_mt.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasFormInputNilaiAktDischargeRtwList")), "", TableVar, true);
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
