using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasFormInputHslPemeriksaanAdd
    /// </summary>
    public static SubAktivitasFormInputHslPemeriksaanAdd subAktivitasFormInputHslPemeriksaanAdd
    {
        get => HttpData.Get<SubAktivitasFormInputHslPemeriksaanAdd>("subAktivitasFormInputHslPemeriksaanAdd")!;
        set => HttpData["subAktivitasFormInputHslPemeriksaanAdd"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasFormInputHslPemeriksaan
    /// </summary>
    public class SubAktivitasFormInputHslPemeriksaanAdd : SubAktivitasFormInputHslPemeriksaanAddBase
    {
        // Constructor
        public SubAktivitasFormInputHslPemeriksaanAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasFormInputHslPemeriksaanAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasFormInputHslPemeriksaanAddBase : SubAktivitasFormInputHslPemeriksaan
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasFormInputHslPemeriksaanAdd";

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
        public SubAktivitasFormInputHslPemeriksaanAddBase(Controller? controller)
        {
            TableName = "SubAktivitasFormInputHslPemeriksaan";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasFormInputHslPemeriksaan)
            if (subAktivitasFormInputHslPemeriksaan == null || subAktivitasFormInputHslPemeriksaan is SubAktivitasFormInputHslPemeriksaan)
                subAktivitasFormInputHslPemeriksaan = this;

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
        public string PageName => "SubAktivitasFormInputHslPemeriksaanAdd";

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
            idProses.SetVisibility();
            NoReferensi.SetVisibility();
            Tanggal.SetVisibility();
            NamaKegiatan.SetVisibility();
            Produk.SetVisibility();
            Density.SetVisibility();
            Temperature.SetVisibility();
            Pressure.SetVisibility();
            Keterangan.SetVisibility();
            userInput.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            TanggalJamSOP.SetVisibility();
            SelisihWaktu.SetVisibility();
            IsQualityActive.SetVisibility();
        }

        // Constructor
        public SubAktivitasFormInputHslPemeriksaanAddBase() : this(null) { }

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
                        result.Add("view", pageName == "SubAktivitasFormInputHslPemeriksaanView" ? "1" : "0"); // If View page, no primary button
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
                return Terminate("SubAktivitasFormInputHslPemeriksaanList");
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
            if (GetPageName(returnUrl) == "SubAktivitasFormInputHslPemeriksaanList")
                returnUrl = AddMasterUrl(ListUrl);
            else if (GetPageName(returnUrl) == "SubAktivitasFormInputHslPemeriksaanView")
                returnUrl = ViewUrl;
            return returnUrl;
        }

        private void HandleAjaxActions(ref string returnUrl)
        {
            if (IsModal && UseAjaxActions) {
                IsModal = false;
                if (GetPageName(returnUrl) != "SubAktivitasFormInputHslPemeriksaanList") {
                    TempData["Return-Url"] = returnUrl;
                    returnUrl = "SubAktivitasFormInputHslPemeriksaanList";
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
                    await SetupLookupOptions(IsQualityActive);

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
                        subAktivitasFormInputHslPemeriksaanAdd?.PageRender();
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

            // Standard handling for 'idProses'
            idProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idProses, "idProses", "x_idProses", true, validate, false);

            // Standard handling for 'NoReferensi'
            NoReferensi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NoReferensi, "NoReferensi", "x_NoReferensi");

            // Standard handling for 'Tanggal'
            Tanggal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Tanggal, "Tanggal", "x_Tanggal", true, validate, true);

            // Standard handling for 'NamaKegiatan'
            NamaKegiatan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NamaKegiatan, "NamaKegiatan", "x_NamaKegiatan");

            // Standard handling for 'Produk'
            Produk.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Produk, "Produk", "x_Produk");

            // Standard handling for 'Density'
            Density.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Density, "Density", "x_Density");

            // Standard handling for 'Temperature'
            Temperature.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Temperature, "Temperature", "x_Temperature");

            // Standard handling for 'Pressure'
            Pressure.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Pressure, "Pressure", "x_Pressure");

            // Standard handling for 'Keterangan'
            Keterangan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Keterangan, "Keterangan", "x_Keterangan");

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
            SetNormalField(lastUpdatedDate, "lastUpdatedDate", "x_lastUpdatedDate", true, validate, true);

            // Standard handling for 'TanggalJamSOP'
            TanggalJamSOP.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalJamSOP, "TanggalJamSOP", "x_TanggalJamSOP", true, validate, true);

            // Standard handling for 'SelisihWaktu'
            SelisihWaktu.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SelisihWaktu, "SelisihWaktu", "x_SelisihWaktu");

            // Standard handling for 'IsQualityActive'
            IsQualityActive.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IsQualityActive, "IsQualityActive", "x_IsQualityActive");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            Tanggal.CurrentValue = Tanggal.FormValue;
            Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            NamaKegiatan.CurrentValue = NamaKegiatan.FormValue;
            Produk.CurrentValue = Produk.FormValue;
            Density.CurrentValue = Density.FormValue;
            Temperature.CurrentValue = Temperature.FormValue;
            Pressure.CurrentValue = Pressure.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            userInput.CurrentValue = userInput.FormValue;
            etlDate.CurrentValue = etlDate.FormValue;
            etlDate.CurrentValue = UnformatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            TanggalJamSOP.CurrentValue = TanggalJamSOP.FormValue;
            TanggalJamSOP.CurrentValue = UnformatDateTime(TanggalJamSOP.CurrentValue, TanggalJamSOP.FormatPattern);
            SelisihWaktu.CurrentValue = SelisihWaktu.FormValue;
            IsQualityActive.CurrentValue = IsQualityActive.FormValue;
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
            idProses.SetDbValue(row["idProses"]);
            NoReferensi.SetDbValue(row["NoReferensi"]);
            Tanggal.SetDbValue(row["Tanggal"]);
            NamaKegiatan.SetDbValue(row["NamaKegiatan"]);
            Produk.SetDbValue(row["Produk"]);
            Density.SetDbValue(row["Density"]);
            Temperature.SetDbValue(row["Temperature"]);
            Pressure.SetDbValue(row["Pressure"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            TanggalJamSOP.SetDbValue(row["TanggalJamSOP"]);
            SelisihWaktu.SetDbValue(row["SelisihWaktu"]);
            IsQualityActive.SetDbValue((ConvertToBool(row["IsQualityActive"]) ? "1" : "0"));
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("Tanggal", Tanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaKegiatan", NamaKegiatan.DefaultValue ?? DbNullValue); // DN
            row.Add("Produk", Produk.DefaultValue ?? DbNullValue); // DN
            row.Add("Density", Density.DefaultValue ?? DbNullValue); // DN
            row.Add("Temperature", Temperature.DefaultValue ?? DbNullValue); // DN
            row.Add("Pressure", Pressure.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalJamSOP", TanggalJamSOP.DefaultValue ?? DbNullValue); // DN
            row.Add("SelisihWaktu", SelisihWaktu.DefaultValue ?? DbNullValue); // DN
            row.Add("IsQualityActive", IsQualityActive.DefaultValue ?? DbNullValue); // DN
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

            // idProses
            idProses.RowCssClass = "row";

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // Tanggal
            Tanggal.RowCssClass = "row";

            // NamaKegiatan
            NamaKegiatan.RowCssClass = "row";

            // Produk
            Produk.RowCssClass = "row";

            // Density
            Density.RowCssClass = "row";

            // Temperature
            Temperature.RowCssClass = "row";

            // Pressure
            Pressure.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // TanggalJamSOP
            TanggalJamSOP.RowCssClass = "row";

            // SelisihWaktu
            SelisihWaktu.RowCssClass = "row";

            // IsQualityActive
            IsQualityActive.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // idAktifitas

                // idProses

                // NoReferensi

                // Tanggal

                // NamaKegiatan

                // Produk

                // Density

                // Temperature

                // Pressure

                // Keterangan

                // userInput

                // etlDate

                // LastUpdatedBy

                // lastUpdatedDate

                // TanggalJamSOP

                // SelisihWaktu

                // IsQualityActive

                    // id
                    id.ViewValue = id.CurrentValue;
                    id.ViewCustomAttributes = "";

                    // idAktifitas
                    idAktifitas.ViewValue = idAktifitas.CurrentValue;
                    idAktifitas.ViewValue = FormatNumber(idAktifitas.ViewValue, idAktifitas.FormatPattern);
                    idAktifitas.ViewCustomAttributes = "";

                    // idProses
                    idProses.ViewValue = idProses.CurrentValue;
                    idProses.ViewValue = FormatNumber(idProses.ViewValue, idProses.FormatPattern);
                    idProses.ViewCustomAttributes = "";

                    // NoReferensi
                    NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                    NoReferensi.ViewCustomAttributes = "";

                    // Tanggal
                    Tanggal.ViewValue = Tanggal.CurrentValue;
                    Tanggal.ViewValue = FormatDateTime(Tanggal.ViewValue, Tanggal.FormatPattern);
                    Tanggal.ViewCustomAttributes = "";

                    // NamaKegiatan
                    NamaKegiatan.ViewValue = ConvertToString(NamaKegiatan.CurrentValue); // DN
                    NamaKegiatan.ViewCustomAttributes = "";

                    // Produk
                    Produk.ViewValue = ConvertToString(Produk.CurrentValue); // DN
                    Produk.ViewCustomAttributes = "";

                    // Density
                    Density.ViewValue = ConvertToString(Density.CurrentValue); // DN
                    Density.ViewCustomAttributes = "";

                    // Temperature
                    Temperature.ViewValue = ConvertToString(Temperature.CurrentValue); // DN
                    Temperature.ViewCustomAttributes = "";

                    // Pressure
                    Pressure.ViewValue = ConvertToString(Pressure.CurrentValue); // DN
                    Pressure.ViewCustomAttributes = "";

                    // Keterangan
                    Keterangan.ViewValue = ConvertToString(Keterangan.CurrentValue); // DN
                    Keterangan.ViewCustomAttributes = "";

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

                    // TanggalJamSOP
                    TanggalJamSOP.ViewValue = TanggalJamSOP.CurrentValue;
                    TanggalJamSOP.ViewValue = FormatDateTime(TanggalJamSOP.ViewValue, TanggalJamSOP.FormatPattern);
                    TanggalJamSOP.ViewCustomAttributes = "";

                    // SelisihWaktu
                    SelisihWaktu.ViewValue = ConvertToString(SelisihWaktu.CurrentValue); // DN
                    SelisihWaktu.ViewCustomAttributes = "";

                    // IsQualityActive
                    if (ConvertToBool(IsQualityActive.CurrentValue)) {
                        IsQualityActive.ViewValue = IsQualityActive.TagCaption(1) != "" ? IsQualityActive.TagCaption(1) : "Yes";
                    } else {
                        IsQualityActive.ViewValue = IsQualityActive.TagCaption(2) != "" ? IsQualityActive.TagCaption(2) : "No";
                    }
                    IsQualityActive.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.HrefValue = "";

                // idProses
                idProses.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // Tanggal
                Tanggal.HrefValue = "";

                // NamaKegiatan
                NamaKegiatan.HrefValue = "";

                // Produk
                Produk.HrefValue = "";

                // Density
                Density.HrefValue = "";

                // Temperature
                Temperature.HrefValue = "";

                // Pressure
                Pressure.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";

                // TanggalJamSOP
                TanggalJamSOP.HrefValue = "";

                // SelisihWaktu
                SelisihWaktu.HrefValue = "";

                // IsQualityActive
                IsQualityActive.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;
                idAktifitas.PlaceHolder = RemoveHtml(idAktifitas.Caption);
                if (!Empty(idAktifitas.EditValue) && IsNumeric(idAktifitas.EditValue))
                    idAktifitas.EditValue = FormatNumber(idAktifitas.EditValue, null);

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;
                idProses.PlaceHolder = RemoveHtml(idProses.Caption);
                if (!Empty(idProses.EditValue) && IsNumeric(idProses.EditValue))
                    idProses.EditValue = FormatNumber(idProses.EditValue, null);

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // Tanggal
                Tanggal.SetupEditAttributes();
                Tanggal.EditValue = FormatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
                Tanggal.PlaceHolder = RemoveHtml(Tanggal.Caption);

                // NamaKegiatan
                NamaKegiatan.SetupEditAttributes();
                if (!NamaKegiatan.Raw)
                    NamaKegiatan.CurrentValue = HtmlDecode(NamaKegiatan.CurrentValue);
                NamaKegiatan.EditValue = HtmlEncode(NamaKegiatan.CurrentValue);
                NamaKegiatan.PlaceHolder = RemoveHtml(NamaKegiatan.Caption);

                // Produk
                Produk.SetupEditAttributes();
                if (!Produk.Raw)
                    Produk.CurrentValue = HtmlDecode(Produk.CurrentValue);
                Produk.EditValue = HtmlEncode(Produk.CurrentValue);
                Produk.PlaceHolder = RemoveHtml(Produk.Caption);

                // Density
                Density.SetupEditAttributes();
                if (!Density.Raw)
                    Density.CurrentValue = HtmlDecode(Density.CurrentValue);
                Density.EditValue = HtmlEncode(Density.CurrentValue);
                Density.PlaceHolder = RemoveHtml(Density.Caption);

                // Temperature
                Temperature.SetupEditAttributes();
                if (!Temperature.Raw)
                    Temperature.CurrentValue = HtmlDecode(Temperature.CurrentValue);
                Temperature.EditValue = HtmlEncode(Temperature.CurrentValue);
                Temperature.PlaceHolder = RemoveHtml(Temperature.Caption);

                // Pressure
                Pressure.SetupEditAttributes();
                if (!Pressure.Raw)
                    Pressure.CurrentValue = HtmlDecode(Pressure.CurrentValue);
                Pressure.EditValue = HtmlEncode(Pressure.CurrentValue);
                Pressure.PlaceHolder = RemoveHtml(Pressure.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                if (!Keterangan.Raw)
                    Keterangan.CurrentValue = HtmlDecode(Keterangan.CurrentValue);
                Keterangan.EditValue = HtmlEncode(Keterangan.CurrentValue);
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

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
                if (!LastUpdatedBy.Raw)
                    LastUpdatedBy.CurrentValue = HtmlDecode(LastUpdatedBy.CurrentValue);
                LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.CurrentValue);
                LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

                // lastUpdatedDate
                lastUpdatedDate.SetupEditAttributes();
                lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.PlaceHolder = RemoveHtml(lastUpdatedDate.Caption);

                // TanggalJamSOP
                TanggalJamSOP.SetupEditAttributes();
                TanggalJamSOP.EditValue = FormatDateTime(TanggalJamSOP.CurrentValue, TanggalJamSOP.FormatPattern);
                TanggalJamSOP.PlaceHolder = RemoveHtml(TanggalJamSOP.Caption);

                // SelisihWaktu
                SelisihWaktu.SetupEditAttributes();
                if (!SelisihWaktu.Raw)
                    SelisihWaktu.CurrentValue = HtmlDecode(SelisihWaktu.CurrentValue);
                SelisihWaktu.EditValue = HtmlEncode(SelisihWaktu.CurrentValue);
                SelisihWaktu.PlaceHolder = RemoveHtml(SelisihWaktu.Caption);

                // IsQualityActive
                IsQualityActive.EditValue = IsQualityActive.Options(false);
                IsQualityActive.PlaceHolder = RemoveHtml(IsQualityActive.Caption);

                // Add refer script

                // idAktifitas
                idAktifitas.HrefValue = "";

                // idProses
                idProses.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // Tanggal
                Tanggal.HrefValue = "";

                // NamaKegiatan
                NamaKegiatan.HrefValue = "";

                // Produk
                Produk.HrefValue = "";

                // Density
                Density.HrefValue = "";

                // Temperature
                Temperature.HrefValue = "";

                // Pressure
                Pressure.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";

                // TanggalJamSOP
                TanggalJamSOP.HrefValue = "";

                // SelisihWaktu
                SelisihWaktu.HrefValue = "";

                // IsQualityActive
                IsQualityActive.HrefValue = "";
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
                    idAktifitas.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomidProses() {
            if (idProses.Visible && idProses.Required) {
                if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                    idProses.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomNoReferensi() {
            if (NoReferensi.Visible && NoReferensi.Required) {
                if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                    NoReferensi.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomTanggal() {
            if (Tanggal.Visible && Tanggal.Required) {
                if (!Tanggal.IsDetailKey && Empty(Tanggal.FormValue)) {
                    Tanggal.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomNamaKegiatan() {
            if (NamaKegiatan.Visible && NamaKegiatan.Required) {
                if (!NamaKegiatan.IsDetailKey && Empty(NamaKegiatan.FormValue)) {
                    NamaKegiatan.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomProduk() {
            if (Produk.Visible && Produk.Required) {
                if (!Produk.IsDetailKey && Empty(Produk.FormValue)) {
                    Produk.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomDensity() {
            if (Density.Visible && Density.Required) {
                if (!Density.IsDetailKey && Empty(Density.FormValue)) {
                    Density.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomTemperature() {
            if (Temperature.Visible && Temperature.Required) {
                if (!Temperature.IsDetailKey && Empty(Temperature.FormValue)) {
                    Temperature.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomPressure() {
            if (Pressure.Visible && Pressure.Required) {
                if (!Pressure.IsDetailKey && Empty(Pressure.FormValue)) {
                    Pressure.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomKeterangan() {
            if (Keterangan.Visible && Keterangan.Required) {
                if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                    Keterangan.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomuserInput() {
            if (userInput.Visible && userInput.Required) {
                if (!userInput.IsDetailKey && Empty(userInput.FormValue)) {
                    userInput.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustometlDate() {
            if (etlDate.Visible && etlDate.Required) {
                if (!etlDate.IsDetailKey && Empty(etlDate.FormValue)) {
                    etlDate.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomLastUpdatedBy() {
            if (LastUpdatedBy.Visible && LastUpdatedBy.Required) {
                if (!LastUpdatedBy.IsDetailKey && Empty(LastUpdatedBy.FormValue)) {
                    LastUpdatedBy.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomlastUpdatedDate() {
            if (lastUpdatedDate.Visible && lastUpdatedDate.Required) {
                if (!lastUpdatedDate.IsDetailKey && Empty(lastUpdatedDate.FormValue)) {
                    lastUpdatedDate.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomTanggalJamSOP() {
            if (TanggalJamSOP.Visible && TanggalJamSOP.Required) {
                if (!TanggalJamSOP.IsDetailKey && Empty(TanggalJamSOP.FormValue)) {
                    TanggalJamSOP.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomSelisihWaktu() {
            if (SelisihWaktu.Visible && SelisihWaktu.Required) {
                if (!SelisihWaktu.IsDetailKey && Empty(SelisihWaktu.FormValue)) {
                    SelisihWaktu.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
                }
            }
        }

        private void ValidateCustomIsQualityActive() {
            if (IsQualityActive.Visible && IsQualityActive.Required) {
                if (Empty(IsQualityActive.FormValue)) {
                    IsQualityActive.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
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
                ValidateCustomidProses();
                if (!CheckInteger(idProses.FormValue)) {
                    idProses.AddErrorMessage(idProses.GetErrorMessage(false));
                }
                ValidateCustomNoReferensi();
                ValidateCustomTanggal();
                if (!CheckDate(Tanggal.FormValue, Tanggal.FormatPattern)) {
                    Tanggal.AddErrorMessage(Tanggal.GetErrorMessage(false));
                }
                ValidateCustomNamaKegiatan();
                ValidateCustomProduk();
                ValidateCustomDensity();
                ValidateCustomTemperature();
                ValidateCustomPressure();
                ValidateCustomKeterangan();
                ValidateCustomuserInput();
                ValidateCustometlDate();
                if (!CheckDate(etlDate.FormValue, etlDate.FormatPattern)) {
                    etlDate.AddErrorMessage(etlDate.GetErrorMessage(false));
                }
                ValidateCustomLastUpdatedBy();
                ValidateCustomlastUpdatedDate();
                if (!CheckDate(lastUpdatedDate.FormValue, lastUpdatedDate.FormatPattern)) {
                    lastUpdatedDate.AddErrorMessage(lastUpdatedDate.GetErrorMessage(false));
                }
                ValidateCustomTanggalJamSOP();
                if (!CheckDate(TanggalJamSOP.FormValue, TanggalJamSOP.FormatPattern)) {
                    TanggalJamSOP.AddErrorMessage(TanggalJamSOP.GetErrorMessage(false));
                }
                ValidateCustomSelisihWaktu();
                ValidateCustomIsQualityActive();

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

                // idProses
                idProses.SetDbValue(rsnew, idProses.CurrentValue);

                // NoReferensi
                NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue);

                // Tanggal
                Tanggal.SetDbValue(rsnew, ConvertToDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern));

                // NamaKegiatan
                NamaKegiatan.SetDbValue(rsnew, NamaKegiatan.CurrentValue);

                // Produk
                Produk.SetDbValue(rsnew, Produk.CurrentValue);

                // Density
                Density.SetDbValue(rsnew, Density.CurrentValue);

                // Temperature
                Temperature.SetDbValue(rsnew, Temperature.CurrentValue);

                // Pressure
                Pressure.SetDbValue(rsnew, Pressure.CurrentValue);

                // Keterangan
                Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue);

                // userInput
                userInput.SetDbValue(rsnew, userInput.CurrentValue);

                // etlDate
                etlDate.SetDbValue(rsnew, ConvertToDateTime(etlDate.CurrentValue, etlDate.FormatPattern), Empty(etlDate.CurrentValue));

                // LastUpdatedBy
                LastUpdatedBy.SetDbValue(rsnew, LastUpdatedBy.CurrentValue);

                // lastUpdatedDate
                lastUpdatedDate.SetDbValue(rsnew, ConvertToDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern));

                // TanggalJamSOP
                TanggalJamSOP.SetDbValue(rsnew, ConvertToDateTime(TanggalJamSOP.CurrentValue, TanggalJamSOP.FormatPattern));

                // SelisihWaktu
                SelisihWaktu.SetDbValue(rsnew, SelisihWaktu.CurrentValue);

                // IsQualityActive
                IsQualityActive.SetDbValue(rsnew, ConvertToBool(IsQualityActive.CurrentValue), Empty(IsQualityActive.CurrentValue));
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
            if (row.TryGetValue("idProses", out value)) // idProses
                idProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Tanggal", out value)) // Tanggal
                Tanggal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NamaKegiatan", out value)) // NamaKegiatan
                NamaKegiatan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Produk", out value)) // Produk
                Produk.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Density", out value)) // Density
                Density.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Temperature", out value)) // Temperature
                Temperature.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Pressure", out value)) // Pressure
                Pressure.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("userInput", out value)) // userInput
                userInput.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("etlDate", out value)) // etlDate
                etlDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LastUpdatedBy", out value)) // LastUpdatedBy
                LastUpdatedBy.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("lastUpdatedDate", out value)) // lastUpdatedDate
                lastUpdatedDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalJamSOP", out value)) // TanggalJamSOP
                TanggalJamSOP.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SelisihWaktu", out value)) // SelisihWaktu
                SelisihWaktu.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IsQualityActive", out value)) // IsQualityActive
                IsQualityActive.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasFormInputHslPemeriksaanList")), "", TableVar, true);
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
