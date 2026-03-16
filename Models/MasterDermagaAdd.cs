using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterDermagaAdd
    /// </summary>
    public static MasterDermagaAdd masterDermagaAdd
    {
        get => HttpData.Get<MasterDermagaAdd>("masterDermagaAdd")!;
        set => HttpData["masterDermagaAdd"] = value;
    }

    /// <summary>
    /// Page class for MasterDermaga
    /// </summary>
    public class MasterDermagaAdd : MasterDermagaAddBase
    {
        // Constructor
        public MasterDermagaAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterDermagaAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Id_Plant.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MasterDermagaAddBase : MasterDermaga
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterDermagaAdd";

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
        public MasterDermagaAddBase(Controller? controller)
        {
            TableName = "MasterDermaga";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterDermaga)
            if (masterDermaga == null || masterDermaga is MasterDermaga)
                masterDermaga = this;

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
        public string PageName => "MasterDermagaAdd";

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
            IdDermaga.Visible = false;
            Region.SetVisibility();
            Id_Plant.SetVisibility();
            Plant.Visible = false;
            TBBM.SetVisibility();
            Equipment_ID.SetVisibility();
            Fungsi.SetVisibility();
            Kapasitas_DWT.SetVisibility();
            Kategori_Kapasitas.SetVisibility();
            Jenis_Sartam.SetVisibility();
            Type_Sartam.SetVisibility();
            Tahun_Pembuatan.SetVisibility();
            Kategori_Port.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
        }

        // Constructor
        public MasterDermagaAddBase() : this(null) { }

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
                        result.Add("view", pageName == "MasterDermagaView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdDermaga") ? dict["IdDermaga"] : IdDermaga.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdDermaga.Visible = false;
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
            if (RouteValues.TryGetValue("IdDermaga", out rv)) {
                IdDermaga.QueryValue = UrlDecode(rv);
            } else if (Get("IdDermaga", out sv)) {
                IdDermaga.QueryValue = sv.ToString();
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
                return Terminate("MasterDermagaList");
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
            if (GetPageName(returnUrl) == "MasterDermagaList")
                returnUrl = AddMasterUrl(ListUrl);
            else if (GetPageName(returnUrl) == "MasterDermagaView")
                returnUrl = ViewUrl;
            return returnUrl;
        }

        private void HandleAjaxActions(ref string returnUrl)
        {
            if (IsModal && UseAjaxActions) {
                IsModal = false;
                if (GetPageName(returnUrl) != "MasterDermagaList") {
                    TempData["Return-Url"] = returnUrl;
                    returnUrl = "MasterDermagaList";
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
                    await SetupLookupOptions(Id_Plant);

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
                        masterDermagaAdd?.PageRender();
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

            // Standard handling for 'Region'
            Region.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Region, "Region", "x_Region");

            // Standard handling for 'Id_Plant'
            Id_Plant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Id_Plant, "Id_Plant", "x_Id_Plant");

            // Standard handling for 'TBBM'
            TBBM.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TBBM, "TBBM", "x_TBBM");

            // Standard handling for 'Equipment_ID'
            Equipment_ID.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Equipment_ID, "Equipment_ID", "x_Equipment_ID");

            // Standard handling for 'Fungsi'
            Fungsi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Fungsi, "Fungsi", "x_Fungsi");

            // Standard handling for 'Kapasitas_DWT'
            Kapasitas_DWT.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Kapasitas_DWT, "Kapasitas_DWT", "x_Kapasitas_DWT");

            // Standard handling for 'Kategori_Kapasitas'
            Kategori_Kapasitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Kategori_Kapasitas, "Kategori_Kapasitas", "x_Kategori_Kapasitas");

            // Standard handling for 'Jenis_Sartam'
            Jenis_Sartam.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Jenis_Sartam, "Jenis_Sartam", "x_Jenis_Sartam");

            // Standard handling for 'Type_Sartam'
            Type_Sartam.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Type_Sartam, "Type_Sartam", "x_Type_Sartam");

            // Standard handling for 'Tahun_Pembuatan'
            Tahun_Pembuatan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Tahun_Pembuatan, "Tahun_Pembuatan", "x_Tahun_Pembuatan");

            // Standard handling for 'Kategori_Port'
            Kategori_Port.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Kategori_Port, "Kategori_Port", "x_Kategori_Port");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            Region.CurrentValue = Region.FormValue;
            Id_Plant.CurrentValue = Id_Plant.FormValue;
            TBBM.CurrentValue = TBBM.FormValue;
            Equipment_ID.CurrentValue = Equipment_ID.FormValue;
            Fungsi.CurrentValue = Fungsi.FormValue;
            Kapasitas_DWT.CurrentValue = Kapasitas_DWT.FormValue;
            Kategori_Kapasitas.CurrentValue = Kategori_Kapasitas.FormValue;
            Jenis_Sartam.CurrentValue = Jenis_Sartam.FormValue;
            Type_Sartam.CurrentValue = Type_Sartam.FormValue;
            Tahun_Pembuatan.CurrentValue = Tahun_Pembuatan.FormValue;
            Kategori_Port.CurrentValue = Kategori_Port.FormValue;
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
            IdDermaga.SetDbValue(row["IdDermaga"]);
            Region.SetDbValue(row["Region"]);
            Id_Plant.SetDbValue(row["Id_Plant"]);
            Plant.SetDbValue(row["Plant"]);
            TBBM.SetDbValue(row["TBBM"]);
            Equipment_ID.SetDbValue(row["Equipment_ID"]);
            Fungsi.SetDbValue(row["Fungsi"]);
            Kapasitas_DWT.SetDbValue(row["Kapasitas_DWT"]);
            Kategori_Kapasitas.SetDbValue(row["Kategori_Kapasitas"]);
            Jenis_Sartam.SetDbValue(row["Jenis_Sartam"]);
            Type_Sartam.SetDbValue(row["Type_Sartam"]);
            Tahun_Pembuatan.SetDbValue(row["Tahun_Pembuatan"]);
            Kategori_Port.SetDbValue(row["Kategori_Port"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdDermaga", IdDermaga.DefaultValue ?? DbNullValue); // DN
            row.Add("Region", Region.DefaultValue ?? DbNullValue); // DN
            row.Add("Id_Plant", Id_Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("TBBM", TBBM.DefaultValue ?? DbNullValue); // DN
            row.Add("Equipment_ID", Equipment_ID.DefaultValue ?? DbNullValue); // DN
            row.Add("Fungsi", Fungsi.DefaultValue ?? DbNullValue); // DN
            row.Add("Kapasitas_DWT", Kapasitas_DWT.DefaultValue ?? DbNullValue); // DN
            row.Add("Kategori_Kapasitas", Kategori_Kapasitas.DefaultValue ?? DbNullValue); // DN
            row.Add("Jenis_Sartam", Jenis_Sartam.DefaultValue ?? DbNullValue); // DN
            row.Add("Type_Sartam", Type_Sartam.DefaultValue ?? DbNullValue); // DN
            row.Add("Tahun_Pembuatan", Tahun_Pembuatan.DefaultValue ?? DbNullValue); // DN
            row.Add("Kategori_Port", Kategori_Port.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
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

            // IdDermaga
            IdDermaga.RowCssClass = "row";

            // Region
            Region.RowCssClass = "row";

            // Id_Plant
            Id_Plant.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // TBBM
            TBBM.RowCssClass = "row";

            // Equipment_ID
            Equipment_ID.RowCssClass = "row";

            // Fungsi
            Fungsi.RowCssClass = "row";

            // Kapasitas_DWT
            Kapasitas_DWT.RowCssClass = "row";

            // Kategori_Kapasitas
            Kategori_Kapasitas.RowCssClass = "row";

            // Jenis_Sartam
            Jenis_Sartam.RowCssClass = "row";

            // Type_Sartam
            Type_Sartam.RowCssClass = "row";

            // Tahun_Pembuatan
            Tahun_Pembuatan.RowCssClass = "row";

            // Kategori_Port
            Kategori_Port.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaruiOleh
            DiperbaruiOleh.RowCssClass = "row";

            // TanggalDiperbarui
            TanggalDiperbarui.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // Region

                // Id_Plant

                // Plant

                // TBBM

                // Equipment_ID

                // Fungsi

                // Kapasitas_DWT

                // Kategori_Kapasitas

                // Jenis_Sartam

                // Type_Sartam

                // Tahun_Pembuatan

                // Kategori_Port

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

                    // IdDermaga
                    IdDermaga.ViewValue = IdDermaga.CurrentValue;
                    IdDermaga.ViewCustomAttributes = "";

                    // Region
                    Region.ViewValue = ConvertToString(Region.CurrentValue); // DN
                    Region.ViewCustomAttributes = "";

                    // Id_Plant

                    // awallookupbung
                    // Id_Plant
                    ResolveLookupView(Id_Plant, "IdPlant", "number");
                    // akhirlookupbung
                    Id_Plant.ViewCustomAttributes = "";

                    // Plant
                    Plant.ViewValue = ConvertToString(Plant.CurrentValue); // DN
                    Plant.ViewCustomAttributes = "";

                    // TBBM
                    TBBM.ViewValue = ConvertToString(TBBM.CurrentValue); // DN
                    TBBM.ViewCustomAttributes = "";

                    // Equipment_ID
                    Equipment_ID.ViewValue = ConvertToString(Equipment_ID.CurrentValue); // DN
                    Equipment_ID.ViewCustomAttributes = "";

                    // Fungsi
                    Fungsi.ViewValue = ConvertToString(Fungsi.CurrentValue); // DN
                    Fungsi.ViewCustomAttributes = "";

                    // Kapasitas_DWT
                    Kapasitas_DWT.ViewValue = ConvertToString(Kapasitas_DWT.CurrentValue); // DN
                    Kapasitas_DWT.ViewCustomAttributes = "";

                    // Kategori_Kapasitas
                    Kategori_Kapasitas.ViewValue = ConvertToString(Kategori_Kapasitas.CurrentValue); // DN
                    Kategori_Kapasitas.ViewCustomAttributes = "";

                    // Jenis_Sartam
                    Jenis_Sartam.ViewValue = ConvertToString(Jenis_Sartam.CurrentValue); // DN
                    Jenis_Sartam.ViewCustomAttributes = "";

                    // Type_Sartam
                    Type_Sartam.ViewValue = ConvertToString(Type_Sartam.CurrentValue); // DN
                    Type_Sartam.ViewCustomAttributes = "";

                    // Tahun_Pembuatan
                    Tahun_Pembuatan.ViewValue = ConvertToString(Tahun_Pembuatan.CurrentValue); // DN
                    Tahun_Pembuatan.ViewCustomAttributes = "";

                    // Kategori_Port
                    Kategori_Port.ViewValue = ConvertToString(Kategori_Port.CurrentValue); // DN
                    Kategori_Port.ViewCustomAttributes = "";

                    // DibuatOleh
                    DibuatOleh.ViewValue = ConvertToString(DibuatOleh.CurrentValue); // DN
                    DibuatOleh.ViewCustomAttributes = "";

                    // TanggalDibuat
                    TanggalDibuat.ViewValue = TanggalDibuat.CurrentValue;
                    TanggalDibuat.ViewValue = FormatDateTime(TanggalDibuat.ViewValue, TanggalDibuat.FormatPattern);
                    TanggalDibuat.ViewCustomAttributes = "";

                    // DiperbaruiOleh
                    DiperbaruiOleh.ViewValue = ConvertToString(DiperbaruiOleh.CurrentValue); // DN
                    DiperbaruiOleh.ViewCustomAttributes = "";

                    // TanggalDiperbarui
                    TanggalDiperbarui.ViewValue = TanggalDiperbarui.CurrentValue;
                    TanggalDiperbarui.ViewValue = FormatDateTime(TanggalDiperbarui.ViewValue, TanggalDiperbarui.FormatPattern);
                    TanggalDiperbarui.ViewCustomAttributes = "";

                // Region
                Region.HrefValue = "";

                // Id_Plant
                Id_Plant.HrefValue = "";

                // TBBM
                TBBM.HrefValue = "";

                // Equipment_ID
                Equipment_ID.HrefValue = "";

                // Fungsi
                Fungsi.HrefValue = "";

                // Kapasitas_DWT
                Kapasitas_DWT.HrefValue = "";

                // Kategori_Kapasitas
                Kategori_Kapasitas.HrefValue = "";

                // Jenis_Sartam
                Jenis_Sartam.HrefValue = "";

                // Type_Sartam
                Type_Sartam.HrefValue = "";

                // Tahun_Pembuatan
                Tahun_Pembuatan.HrefValue = "";

                // Kategori_Port
                Kategori_Port.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // Region
                Region.SetupEditAttributes();
                if (!Region.Raw)
                    Region.CurrentValue = HtmlDecode(Region.CurrentValue);
                Region.EditValue = HtmlEncode(Region.CurrentValue);
                Region.PlaceHolder = RemoveHtml(Region.Caption);

                // Id_Plant
                Id_Plant.SetupEditAttributes();
                string curVal = ConvertToString(Id_Plant.CurrentValue);
                if (Id_Plant.Lookup != null && IsDictionary(Id_Plant.Lookup?.Options) && Id_Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Id_Plant.EditValue = Id_Plant.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk = "";
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter(Id_Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Id_Plant.CurrentValue, Id_Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk = Id_Plant.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Id_Plant.EditValue = rswrk;
                }
                Id_Plant.PlaceHolder = RemoveHtml(Id_Plant.Caption);
                if (!Empty(Id_Plant.EditValue) && IsNumeric(Id_Plant.EditValue))
                    Id_Plant.EditValue = FormatNumber(Id_Plant.EditValue, null);

                // TBBM
                TBBM.SetupEditAttributes();
                if (!TBBM.Raw)
                    TBBM.CurrentValue = HtmlDecode(TBBM.CurrentValue);
                TBBM.EditValue = HtmlEncode(TBBM.CurrentValue);
                TBBM.PlaceHolder = RemoveHtml(TBBM.Caption);

                // Equipment_ID
                Equipment_ID.SetupEditAttributes();
                if (!Equipment_ID.Raw)
                    Equipment_ID.CurrentValue = HtmlDecode(Equipment_ID.CurrentValue);
                Equipment_ID.EditValue = HtmlEncode(Equipment_ID.CurrentValue);
                Equipment_ID.PlaceHolder = RemoveHtml(Equipment_ID.Caption);

                // Fungsi
                Fungsi.SetupEditAttributes();
                if (!Fungsi.Raw)
                    Fungsi.CurrentValue = HtmlDecode(Fungsi.CurrentValue);
                Fungsi.EditValue = HtmlEncode(Fungsi.CurrentValue);
                Fungsi.PlaceHolder = RemoveHtml(Fungsi.Caption);

                // Kapasitas_DWT
                Kapasitas_DWT.SetupEditAttributes();
                if (!Kapasitas_DWT.Raw)
                    Kapasitas_DWT.CurrentValue = HtmlDecode(Kapasitas_DWT.CurrentValue);
                Kapasitas_DWT.EditValue = HtmlEncode(Kapasitas_DWT.CurrentValue);
                Kapasitas_DWT.PlaceHolder = RemoveHtml(Kapasitas_DWT.Caption);

                // Kategori_Kapasitas
                Kategori_Kapasitas.SetupEditAttributes();
                if (!Kategori_Kapasitas.Raw)
                    Kategori_Kapasitas.CurrentValue = HtmlDecode(Kategori_Kapasitas.CurrentValue);
                Kategori_Kapasitas.EditValue = HtmlEncode(Kategori_Kapasitas.CurrentValue);
                Kategori_Kapasitas.PlaceHolder = RemoveHtml(Kategori_Kapasitas.Caption);

                // Jenis_Sartam
                Jenis_Sartam.SetupEditAttributes();
                if (!Jenis_Sartam.Raw)
                    Jenis_Sartam.CurrentValue = HtmlDecode(Jenis_Sartam.CurrentValue);
                Jenis_Sartam.EditValue = HtmlEncode(Jenis_Sartam.CurrentValue);
                Jenis_Sartam.PlaceHolder = RemoveHtml(Jenis_Sartam.Caption);

                // Type_Sartam
                Type_Sartam.SetupEditAttributes();
                if (!Type_Sartam.Raw)
                    Type_Sartam.CurrentValue = HtmlDecode(Type_Sartam.CurrentValue);
                Type_Sartam.EditValue = HtmlEncode(Type_Sartam.CurrentValue);
                Type_Sartam.PlaceHolder = RemoveHtml(Type_Sartam.Caption);

                // Tahun_Pembuatan
                Tahun_Pembuatan.SetupEditAttributes();
                if (!Tahun_Pembuatan.Raw)
                    Tahun_Pembuatan.CurrentValue = HtmlDecode(Tahun_Pembuatan.CurrentValue);
                Tahun_Pembuatan.EditValue = HtmlEncode(Tahun_Pembuatan.CurrentValue);
                Tahun_Pembuatan.PlaceHolder = RemoveHtml(Tahun_Pembuatan.Caption);

                // Kategori_Port
                Kategori_Port.SetupEditAttributes();
                if (!Kategori_Port.Raw)
                    Kategori_Port.CurrentValue = HtmlDecode(Kategori_Port.CurrentValue);
                Kategori_Port.EditValue = HtmlEncode(Kategori_Port.CurrentValue);
                Kategori_Port.PlaceHolder = RemoveHtml(Kategori_Port.Caption);

                // Add refer script

                // Region
                Region.HrefValue = "";

                // Id_Plant
                Id_Plant.HrefValue = "";

                // TBBM
                TBBM.HrefValue = "";

                // Equipment_ID
                Equipment_ID.HrefValue = "";

                // Fungsi
                Fungsi.HrefValue = "";

                // Kapasitas_DWT
                Kapasitas_DWT.HrefValue = "";

                // Kategori_Kapasitas
                Kategori_Kapasitas.HrefValue = "";

                // Jenis_Sartam
                Jenis_Sartam.HrefValue = "";

                // Type_Sartam
                Type_Sartam.HrefValue = "";

                // Tahun_Pembuatan
                Tahun_Pembuatan.HrefValue = "";

                // Kategori_Port
                Kategori_Port.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998

        private void ValidateCustomRegion() {
            if (Region.Visible && Region.Required) {
                if (!Region.IsDetailKey && Empty(Region.FormValue)) {
                    Region.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomId_Plant() {
            if (Id_Plant.Visible && Id_Plant.Required) {
                if (!Id_Plant.IsDetailKey && Empty(Id_Plant.FormValue)) {
                    Id_Plant.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomTBBM() {
            if (TBBM.Visible && TBBM.Required) {
                if (!TBBM.IsDetailKey && Empty(TBBM.FormValue)) {
                    TBBM.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomEquipment_ID() {
            if (Equipment_ID.Visible && Equipment_ID.Required) {
                if (!Equipment_ID.IsDetailKey && Empty(Equipment_ID.FormValue)) {
                    Equipment_ID.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomFungsi() {
            if (Fungsi.Visible && Fungsi.Required) {
                if (!Fungsi.IsDetailKey && Empty(Fungsi.FormValue)) {
                    Fungsi.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomKapasitas_DWT() {
            if (Kapasitas_DWT.Visible && Kapasitas_DWT.Required) {
                if (!Kapasitas_DWT.IsDetailKey && Empty(Kapasitas_DWT.FormValue)) {
                    Kapasitas_DWT.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomKategori_Kapasitas() {
            if (Kategori_Kapasitas.Visible && Kategori_Kapasitas.Required) {
                if (!Kategori_Kapasitas.IsDetailKey && Empty(Kategori_Kapasitas.FormValue)) {
                    Kategori_Kapasitas.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomJenis_Sartam() {
            if (Jenis_Sartam.Visible && Jenis_Sartam.Required) {
                if (!Jenis_Sartam.IsDetailKey && Empty(Jenis_Sartam.FormValue)) {
                    Jenis_Sartam.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomType_Sartam() {
            if (Type_Sartam.Visible && Type_Sartam.Required) {
                if (!Type_Sartam.IsDetailKey && Empty(Type_Sartam.FormValue)) {
                    Type_Sartam.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomTahun_Pembuatan() {
            if (Tahun_Pembuatan.Visible && Tahun_Pembuatan.Required) {
                if (!Tahun_Pembuatan.IsDetailKey && Empty(Tahun_Pembuatan.FormValue)) {
                    Tahun_Pembuatan.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        private void ValidateCustomKategori_Port() {
            if (Kategori_Port.Visible && Kategori_Port.Required) {
                if (!Kategori_Port.IsDetailKey && Empty(Kategori_Port.FormValue)) {
                    Kategori_Port.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomRegion();
                ValidateCustomId_Plant();
                ValidateCustomTBBM();
                ValidateCustomEquipment_ID();
                ValidateCustomFungsi();
                ValidateCustomKapasitas_DWT();
                ValidateCustomKategori_Kapasitas();
                ValidateCustomJenis_Sartam();
                ValidateCustomType_Sartam();
                ValidateCustomTahun_Pembuatan();
                ValidateCustomKategori_Port();

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
                    rsnew["IdDermaga"] = IdDermaga.CurrentValue!;
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

                // Region
                Region.SetDbValue(rsnew, Region.CurrentValue);

                // Id_Plant
                Id_Plant.SetDbValue(rsnew, Id_Plant.CurrentValue);

                // TBBM
                TBBM.SetDbValue(rsnew, TBBM.CurrentValue);

                // Equipment_ID
                Equipment_ID.SetDbValue(rsnew, Equipment_ID.CurrentValue);

                // Fungsi
                Fungsi.SetDbValue(rsnew, Fungsi.CurrentValue);

                // Kapasitas_DWT
                Kapasitas_DWT.SetDbValue(rsnew, Kapasitas_DWT.CurrentValue);

                // Kategori_Kapasitas
                Kategori_Kapasitas.SetDbValue(rsnew, Kategori_Kapasitas.CurrentValue);

                // Jenis_Sartam
                Jenis_Sartam.SetDbValue(rsnew, Jenis_Sartam.CurrentValue);

                // Type_Sartam
                Type_Sartam.SetDbValue(rsnew, Type_Sartam.CurrentValue);

                // Tahun_Pembuatan
                Tahun_Pembuatan.SetDbValue(rsnew, Tahun_Pembuatan.CurrentValue);

                // Kategori_Port
                Kategori_Port.SetDbValue(rsnew, Kategori_Port.CurrentValue);
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
            if (row.TryGetValue("Region", out value)) // Region
                Region.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Id_Plant", out value)) // Id_Plant
                Id_Plant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TBBM", out value)) // TBBM
                TBBM.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Equipment_ID", out value)) // Equipment_ID
                Equipment_ID.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Fungsi", out value)) // Fungsi
                Fungsi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Kapasitas_DWT", out value)) // Kapasitas_DWT
                Kapasitas_DWT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Kategori_Kapasitas", out value)) // Kategori_Kapasitas
                Kategori_Kapasitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Jenis_Sartam", out value)) // Jenis_Sartam
                Jenis_Sartam.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Type_Sartam", out value)) // Type_Sartam
                Type_Sartam.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Tahun_Pembuatan", out value)) // Tahun_Pembuatan
                Tahun_Pembuatan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Kategori_Port", out value)) // Kategori_Port
                Kategori_Port.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterDermagaList")), "", TableVar, true);
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
