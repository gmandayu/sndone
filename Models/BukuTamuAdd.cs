using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// bukuTamuAdd
    /// </summary>
    public static BukuTamuAdd bukuTamuAdd
    {
        get => HttpData.Get<BukuTamuAdd>("bukuTamuAdd")!;
        set => HttpData["bukuTamuAdd"] = value;
    }

    /// <summary>
    /// Page class for BukuTamu
    /// </summary>
    public class BukuTamuAdd : BukuTamuAddBase
    {
        // Constructor
        public BukuTamuAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public BukuTamuAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class BukuTamuAddBase : BukuTamu
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "bukuTamuAdd";

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
        public BukuTamuAddBase(Controller? controller)
        {
            TableName = "BukuTamu";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (bukuTamu)
            if (bukuTamu == null || bukuTamu is BukuTamu)
                bukuTamu = this;

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
        public string PageName => "BukuTamuAdd";

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
            NomorBukuTamu.Visible = false;
            LinkRedirect.Visible = false;
            LookupPlant.SetVisibility();
            Plant.SetVisibility();
            Tanggal.SetVisibility();
            StatusZona.SetVisibility();
            Nama.SetVisibility();
            AsalPerusahaan.SetVisibility();
            Jabatan.SetVisibility();
            FungsiygDikunjungi.SetVisibility();
            MaksudKunjungan.SetVisibility();
            TandaPengenal.SetVisibility();
            TandaTangan.SetVisibility();
            TandaTanganDownload.SetVisibility();
            Keterangan.SetVisibility();
            PintuUtamaId.SetVisibility();
            PintuUtamaInTanggal.SetVisibility();
            PintuUtamaInFoto.SetVisibility();
            PintuUtamaInFotoDownload.SetVisibility();
            PintuUtamaInUser.Visible = false;
            CustomPilihPintu.Visible = false;
            PintuUtamaOutTanggal.Visible = false;
            PintuUtamaOutFoto.Visible = false;
            PintuUtamaOutFotoDownload.Visible = false;
            PintuUtamaOutUser.Visible = false;
            LobbyUtamaId.Visible = false;
            LobbyUtamaInTanggal.Visible = false;
            LobbyUtamaInFoto.Visible = false;
            LobbyUtamaInFotoDownload.Visible = false;
            LobbyUtamaInUser.Visible = false;
            LobbyUtamaOutTanggal.Visible = false;
            LobbyUtamaOutFoto.Visible = false;
            LobbyUtamaOutFotoDownload.Visible = false;
            LobbyUtamaOutUser.Visible = false;
            AreaTerlarangId.Visible = false;
            AreaTerlarangInTanggal.Visible = false;
            AreaTerlarangInFoto.Visible = false;
            AreaTerlarangInFotoDownload.Visible = false;
            AreaTerlarangInUser.Visible = false;
            AreaTerlarangOutTanggal.Visible = false;
            AreaTerlarangOutFoto.Visible = false;
            AreaTerlarangOutFotoDownload.Visible = false;
            AreaTerlarangOutUser.Visible = false;
            etlDate.Visible = false;
            LastUpdatedBy.Visible = false;
            lastUpdatedDate.Visible = false;
            StatusZonaPrev.SetVisibility();
        }

        // Constructor
        public BukuTamuAddBase() : this(null) { }

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
                        result.Add("view", pageName == "BukuTamuView" ? "1" : "0"); // If View page, no primary button
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
                return Terminate("BukuTamuList");
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
            returnUrl = "BukuTamuList";
            if (GetPageName(returnUrl) == "BukuTamuList")
                returnUrl = AddMasterUrl(ListUrl);
            else if (GetPageName(returnUrl) == "BukuTamuView")
                returnUrl = ViewUrl;
            return returnUrl;
        }

        private void HandleAjaxActions(ref string returnUrl)
        {
            if (IsModal && UseAjaxActions) {
                IsModal = false;
                if (GetPageName(returnUrl) != "BukuTamuList") {
                    TempData["Return-Url"] = returnUrl;
                    returnUrl = "BukuTamuList";
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
                    await SetupLookupOptions(LookupPlant);
                    await SetupLookupOptions(Plant);
                    await SetupLookupOptions(FungsiygDikunjungi);
                    await SetupLookupOptions(TandaPengenal);

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
                        bukuTamuAdd?.PageRender();
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

            // Standard handling for 'LookupPlant'
            LookupPlant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LookupPlant, "LookupPlant", "x_LookupPlant");

            // Standard handling for 'Plant'
            Plant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Plant, "Plant", "x_Plant");

            // Standard handling for 'Tanggal'
            Tanggal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Tanggal, "Tanggal", "x_Tanggal", true, validate, true);

            // Standard handling for 'StatusZona'
            StatusZona.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(StatusZona, "StatusZona", "x_StatusZona");

            // Standard handling for 'Nama'
            Nama.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Nama, "Nama", "x_Nama");

            // Standard handling for 'AsalPerusahaan'
            AsalPerusahaan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(AsalPerusahaan, "AsalPerusahaan", "x_AsalPerusahaan");

            // Standard handling for 'Jabatan'
            Jabatan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Jabatan, "Jabatan", "x_Jabatan");

            // Standard handling for 'FungsiygDikunjungi'
            FungsiygDikunjungi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(FungsiygDikunjungi, "FungsiygDikunjungi", "x_FungsiygDikunjungi");

            // Standard handling for 'MaksudKunjungan'
            MaksudKunjungan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(MaksudKunjungan, "MaksudKunjungan", "x_MaksudKunjungan");

            // Standard handling for 'TandaPengenal'
            TandaPengenal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TandaPengenal, "TandaPengenal", "x_TandaPengenal");

            // Standard handling for 'TandaTangan'
            TandaTangan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TandaTangan, "TandaTangan", "x_TandaTangan");

            // Standard handling for 'TandaTanganDownload'
            TandaTanganDownload.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TandaTanganDownload, "TandaTanganDownload", "x_TandaTanganDownload");

            // Standard handling for 'Keterangan'
            Keterangan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Keterangan, "Keterangan", "x_Keterangan");

            // Standard handling for 'PintuUtamaId'
            PintuUtamaId.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PintuUtamaId, "PintuUtamaId", "x_PintuUtamaId", true, validate, false);

            // Standard handling for 'PintuUtamaInTanggal'
            PintuUtamaInTanggal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PintuUtamaInTanggal, "PintuUtamaInTanggal", "x_PintuUtamaInTanggal", true, validate, true);

            // Standard handling for 'PintuUtamaInFoto'
            PintuUtamaInFoto.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PintuUtamaInFoto, "PintuUtamaInFoto", "x_PintuUtamaInFoto");

            // Standard handling for 'PintuUtamaInFotoDownload'
            PintuUtamaInFotoDownload.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PintuUtamaInFotoDownload, "PintuUtamaInFotoDownload", "x_PintuUtamaInFotoDownload");

            // Standard handling for 'StatusZonaPrev'
            StatusZonaPrev.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(StatusZonaPrev, "StatusZonaPrev", "x_StatusZonaPrev");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            LookupPlant.CurrentValue = LookupPlant.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            Tanggal.CurrentValue = Tanggal.FormValue;
            Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            StatusZona.CurrentValue = StatusZona.FormValue;
            Nama.CurrentValue = Nama.FormValue;
            AsalPerusahaan.CurrentValue = AsalPerusahaan.FormValue;
            Jabatan.CurrentValue = Jabatan.FormValue;
            FungsiygDikunjungi.CurrentValue = FungsiygDikunjungi.FormValue;
            MaksudKunjungan.CurrentValue = MaksudKunjungan.FormValue;
            TandaPengenal.CurrentValue = TandaPengenal.FormValue;
            TandaTangan.CurrentValue = TandaTangan.FormValue;
            TandaTanganDownload.CurrentValue = TandaTanganDownload.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            PintuUtamaId.CurrentValue = PintuUtamaId.FormValue;
            PintuUtamaInTanggal.CurrentValue = PintuUtamaInTanggal.FormValue;
            PintuUtamaInTanggal.CurrentValue = UnformatDateTime(PintuUtamaInTanggal.CurrentValue, PintuUtamaInTanggal.FormatPattern);
            PintuUtamaInFoto.CurrentValue = PintuUtamaInFoto.FormValue;
            PintuUtamaInFotoDownload.CurrentValue = PintuUtamaInFotoDownload.FormValue;
            StatusZonaPrev.CurrentValue = StatusZonaPrev.FormValue;
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
            NomorBukuTamu.SetDbValue(row["NomorBukuTamu"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            Plant.SetDbValue(row["Plant"]);
            Tanggal.SetDbValue(row["Tanggal"]);
            StatusZona.SetDbValue(row["StatusZona"]);
            Nama.SetDbValue(row["Nama"]);
            AsalPerusahaan.SetDbValue(row["AsalPerusahaan"]);
            Jabatan.SetDbValue(row["Jabatan"]);
            FungsiygDikunjungi.SetDbValue(row["FungsiygDikunjungi"]);
            MaksudKunjungan.SetDbValue(row["MaksudKunjungan"]);
            TandaPengenal.SetDbValue(row["TandaPengenal"]);
            TandaTangan.SetDbValue(row["TandaTangan"]);
            TandaTanganDownload.SetDbValue(row["TandaTanganDownload"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            PintuUtamaId.SetDbValue(row["PintuUtamaId"]);
            PintuUtamaInTanggal.SetDbValue(row["PintuUtamaInTanggal"]);
            PintuUtamaInFoto.SetDbValue(row["PintuUtamaInFoto"]);
            PintuUtamaInFotoDownload.SetDbValue(row["PintuUtamaInFotoDownload"]);
            PintuUtamaInUser.SetDbValue(row["PintuUtamaInUser"]);
            CustomPilihPintu.SetDbValue(row["CustomPilihPintu"]);
            PintuUtamaOutTanggal.SetDbValue(row["PintuUtamaOutTanggal"]);
            PintuUtamaOutFoto.SetDbValue(row["PintuUtamaOutFoto"]);
            PintuUtamaOutFotoDownload.SetDbValue(row["PintuUtamaOutFotoDownload"]);
            PintuUtamaOutUser.SetDbValue(row["PintuUtamaOutUser"]);
            LobbyUtamaId.SetDbValue(row["LobbyUtamaId"]);
            LobbyUtamaInTanggal.SetDbValue(row["LobbyUtamaInTanggal"]);
            LobbyUtamaInFoto.SetDbValue(row["LobbyUtamaInFoto"]);
            LobbyUtamaInFotoDownload.SetDbValue(row["LobbyUtamaInFotoDownload"]);
            LobbyUtamaInUser.SetDbValue(row["LobbyUtamaInUser"]);
            LobbyUtamaOutTanggal.SetDbValue(row["LobbyUtamaOutTanggal"]);
            LobbyUtamaOutFoto.SetDbValue(row["LobbyUtamaOutFoto"]);
            LobbyUtamaOutFotoDownload.SetDbValue(row["LobbyUtamaOutFotoDownload"]);
            LobbyUtamaOutUser.SetDbValue(row["LobbyUtamaOutUser"]);
            AreaTerlarangId.SetDbValue(row["AreaTerlarangId"]);
            AreaTerlarangInTanggal.SetDbValue(row["AreaTerlarangInTanggal"]);
            AreaTerlarangInFoto.SetDbValue(row["AreaTerlarangInFoto"]);
            AreaTerlarangInFotoDownload.SetDbValue(row["AreaTerlarangInFotoDownload"]);
            AreaTerlarangInUser.SetDbValue(row["AreaTerlarangInUser"]);
            AreaTerlarangOutTanggal.SetDbValue(row["AreaTerlarangOutTanggal"]);
            AreaTerlarangOutFoto.SetDbValue(row["AreaTerlarangOutFoto"]);
            AreaTerlarangOutFotoDownload.SetDbValue(row["AreaTerlarangOutFotoDownload"]);
            AreaTerlarangOutUser.SetDbValue(row["AreaTerlarangOutUser"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            StatusZonaPrev.SetDbValue(row["StatusZonaPrev"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorBukuTamu", NomorBukuTamu.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("Tanggal", Tanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusZona", StatusZona.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama", Nama.DefaultValue ?? DbNullValue); // DN
            row.Add("AsalPerusahaan", AsalPerusahaan.DefaultValue ?? DbNullValue); // DN
            row.Add("Jabatan", Jabatan.DefaultValue ?? DbNullValue); // DN
            row.Add("FungsiygDikunjungi", FungsiygDikunjungi.DefaultValue ?? DbNullValue); // DN
            row.Add("MaksudKunjungan", MaksudKunjungan.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaPengenal", TandaPengenal.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaTangan", TandaTangan.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaTanganDownload", TandaTanganDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaId", PintuUtamaId.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInTanggal", PintuUtamaInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInFoto", PintuUtamaInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInFotoDownload", PintuUtamaInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInUser", PintuUtamaInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("CustomPilihPintu", CustomPilihPintu.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutTanggal", PintuUtamaOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutFoto", PintuUtamaOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutFotoDownload", PintuUtamaOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutUser", PintuUtamaOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaId", LobbyUtamaId.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInTanggal", LobbyUtamaInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInFoto", LobbyUtamaInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInFotoDownload", LobbyUtamaInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInUser", LobbyUtamaInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutTanggal", LobbyUtamaOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutFoto", LobbyUtamaOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutFotoDownload", LobbyUtamaOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutUser", LobbyUtamaOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangId", AreaTerlarangId.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInTanggal", AreaTerlarangInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInFoto", AreaTerlarangInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInFotoDownload", AreaTerlarangInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInUser", AreaTerlarangInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutTanggal", AreaTerlarangOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutFoto", AreaTerlarangOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutFotoDownload", AreaTerlarangOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutUser", AreaTerlarangOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusZonaPrev", StatusZonaPrev.DefaultValue ?? DbNullValue); // DN
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

            // NomorBukuTamu
            NomorBukuTamu.RowCssClass = "row";

            // LinkRedirect
            LinkRedirect.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // Tanggal
            Tanggal.RowCssClass = "row";

            // StatusZona
            StatusZona.RowCssClass = "row";

            // Nama
            Nama.RowCssClass = "row";

            // AsalPerusahaan
            AsalPerusahaan.RowCssClass = "row";

            // Jabatan
            Jabatan.RowCssClass = "row";

            // FungsiygDikunjungi
            FungsiygDikunjungi.RowCssClass = "row";

            // MaksudKunjungan
            MaksudKunjungan.RowCssClass = "row";

            // TandaPengenal
            TandaPengenal.RowCssClass = "row";

            // TandaTangan
            TandaTangan.RowCssClass = "row";

            // TandaTanganDownload
            TandaTanganDownload.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // PintuUtamaId
            PintuUtamaId.RowCssClass = "row";

            // PintuUtamaInTanggal
            PintuUtamaInTanggal.RowCssClass = "row";

            // PintuUtamaInFoto
            PintuUtamaInFoto.RowCssClass = "row";

            // PintuUtamaInFotoDownload
            PintuUtamaInFotoDownload.RowCssClass = "row";

            // PintuUtamaInUser
            PintuUtamaInUser.RowCssClass = "row";

            // CustomPilihPintu
            CustomPilihPintu.RowCssClass = "row";

            // PintuUtamaOutTanggal
            PintuUtamaOutTanggal.RowCssClass = "row";

            // PintuUtamaOutFoto
            PintuUtamaOutFoto.RowCssClass = "row";

            // PintuUtamaOutFotoDownload
            PintuUtamaOutFotoDownload.RowCssClass = "row";

            // PintuUtamaOutUser
            PintuUtamaOutUser.RowCssClass = "row";

            // LobbyUtamaId
            LobbyUtamaId.RowCssClass = "row";

            // LobbyUtamaInTanggal
            LobbyUtamaInTanggal.RowCssClass = "row";

            // LobbyUtamaInFoto
            LobbyUtamaInFoto.RowCssClass = "row";

            // LobbyUtamaInFotoDownload
            LobbyUtamaInFotoDownload.RowCssClass = "row";

            // LobbyUtamaInUser
            LobbyUtamaInUser.RowCssClass = "row";

            // LobbyUtamaOutTanggal
            LobbyUtamaOutTanggal.RowCssClass = "row";

            // LobbyUtamaOutFoto
            LobbyUtamaOutFoto.RowCssClass = "row";

            // LobbyUtamaOutFotoDownload
            LobbyUtamaOutFotoDownload.RowCssClass = "row";

            // LobbyUtamaOutUser
            LobbyUtamaOutUser.RowCssClass = "row";

            // AreaTerlarangId
            AreaTerlarangId.RowCssClass = "row";

            // AreaTerlarangInTanggal
            AreaTerlarangInTanggal.RowCssClass = "row";

            // AreaTerlarangInFoto
            AreaTerlarangInFoto.RowCssClass = "row";

            // AreaTerlarangInFotoDownload
            AreaTerlarangInFotoDownload.RowCssClass = "row";

            // AreaTerlarangInUser
            AreaTerlarangInUser.RowCssClass = "row";

            // AreaTerlarangOutTanggal
            AreaTerlarangOutTanggal.RowCssClass = "row";

            // AreaTerlarangOutFoto
            AreaTerlarangOutFoto.RowCssClass = "row";

            // AreaTerlarangOutFotoDownload
            AreaTerlarangOutFotoDownload.RowCssClass = "row";

            // AreaTerlarangOutUser
            AreaTerlarangOutUser.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // StatusZonaPrev
            StatusZonaPrev.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // NomorBukuTamu

                // LinkRedirect

                // LookupPlant

                // Plant

                // Tanggal

                // StatusZona

                // Nama

                // AsalPerusahaan

                // Jabatan

                // FungsiygDikunjungi

                // MaksudKunjungan

                // TandaPengenal

                // TandaTangan

                // TandaTanganDownload

                // Keterangan

                // PintuUtamaId

                // PintuUtamaInTanggal

                // PintuUtamaInFoto

                // PintuUtamaInFotoDownload

                // PintuUtamaInUser

                // CustomPilihPintu

                // PintuUtamaOutTanggal

                // PintuUtamaOutUser

                // LobbyUtamaId

                // LobbyUtamaInTanggal

                // LobbyUtamaInUser

                // LobbyUtamaOutTanggal

                // LobbyUtamaOutUser

                // AreaTerlarangId

                // AreaTerlarangInTanggal

                // AreaTerlarangInUser

                // AreaTerlarangOutTanggal

                // AreaTerlarangOutUser

                // etlDate

                // LastUpdatedBy

                // lastUpdatedDate

                // StatusZonaPrev

                    // id
                    id.ViewValue = id.CurrentValue;
                    id.ViewCustomAttributes = "";

                    // NomorBukuTamu
                    NomorBukuTamu.ViewValue = ConvertToString(NomorBukuTamu.CurrentValue); // DN
                    NomorBukuTamu.ViewCustomAttributes = "";

                    // LinkRedirect
                    LinkRedirect.ViewValue = ConvertToString(LinkRedirect.CurrentValue); // DN
                    LinkRedirect.ViewCustomAttributes = "";

                    // LookupPlant
                    if (!Empty(LookupPlant.CurrentValue)) {
                        LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                    } else {
                        LookupPlant.ViewValue = DbNullValue;
                    }
                    LookupPlant.ViewCustomAttributes = "";

                    // Plant
                    Plant.ViewValue = Plant.CurrentValue;

                    // awallookupbung
                    // Plant (jaga leading zero)
                    ResolveLookupView(Plant, "IdPlant", "string");
                    // akhirlookupbung
                    Plant.ViewCustomAttributes = "";

                    // Tanggal
                    Tanggal.ViewValue = Tanggal.CurrentValue;
                    Tanggal.ViewValue = FormatDateTime(Tanggal.ViewValue, Tanggal.FormatPattern);
                    Tanggal.ViewCustomAttributes = "";

                    // StatusZona
                    StatusZona.ViewValue = ConvertToString(StatusZona.CurrentValue); // DN
                    StatusZona.ViewCustomAttributes = "";

                    // Nama
                    Nama.ViewValue = ConvertToString(Nama.CurrentValue); // DN
                    Nama.ViewCustomAttributes = "";

                    // AsalPerusahaan
                    AsalPerusahaan.ViewValue = ConvertToString(AsalPerusahaan.CurrentValue); // DN
                    AsalPerusahaan.ViewCustomAttributes = "";

                    // Jabatan
                    Jabatan.ViewValue = ConvertToString(Jabatan.CurrentValue); // DN
                    Jabatan.ViewCustomAttributes = "";

                    // FungsiygDikunjungi

                    // awallookupbung
                    // FungsiygDikunjungi (jaga leading zero)
                    ResolveLookupView(FungsiygDikunjungi, "ID", "string");
                    // akhirlookupbung
                    FungsiygDikunjungi.ViewCustomAttributes = "";

                    // MaksudKunjungan
                    MaksudKunjungan.ViewValue = ConvertToString(MaksudKunjungan.CurrentValue); // DN
                    MaksudKunjungan.ViewCustomAttributes = "";

                    // TandaPengenal
                    if (!Empty(TandaPengenal.CurrentValue)) {
                        TandaPengenal.ViewValue = TandaPengenal.OptionCaption(ConvertToString(TandaPengenal.CurrentValue));
                    } else {
                        TandaPengenal.ViewValue = DbNullValue;
                    }
                    TandaPengenal.ViewCustomAttributes = "";

                    // TandaTangan
                    TandaTangan.ViewValue = TandaTangan.CurrentValue;
                    TandaTangan.ViewCustomAttributes = "";

                    // TandaTanganDownload
                    TandaTanganDownload.ViewValue = TandaTanganDownload.CurrentValue;
                    TandaTanganDownload.ViewCustomAttributes = "";

                    // Keterangan
                    Keterangan.ViewValue = Keterangan.CurrentValue;
                    Keterangan.ViewCustomAttributes = "";

                    // PintuUtamaId
                    PintuUtamaId.ViewValue = ConvertToString(PintuUtamaId.CurrentValue); // DN
                    PintuUtamaId.ViewCustomAttributes = "";

                    // PintuUtamaInTanggal
                    PintuUtamaInTanggal.ViewValue = PintuUtamaInTanggal.CurrentValue;
                    PintuUtamaInTanggal.ViewValue = FormatDateTime(PintuUtamaInTanggal.ViewValue, PintuUtamaInTanggal.FormatPattern);
                    PintuUtamaInTanggal.ViewCustomAttributes = "";

                    // PintuUtamaInFoto
                    PintuUtamaInFoto.ViewValue = PintuUtamaInFoto.CurrentValue;
                    PintuUtamaInFoto.ViewCustomAttributes = "";

                    // PintuUtamaInFotoDownload
                    PintuUtamaInFotoDownload.ViewValue = PintuUtamaInFotoDownload.CurrentValue;
                    PintuUtamaInFotoDownload.ViewCustomAttributes = "";

                    // PintuUtamaInUser
                    PintuUtamaInUser.ViewValue = ConvertToString(PintuUtamaInUser.CurrentValue); // DN
                    PintuUtamaInUser.ViewCustomAttributes = "";

                    // CustomPilihPintu
                    CustomPilihPintu.ViewValue = ConvertToString(CustomPilihPintu.CurrentValue); // DN
                    CustomPilihPintu.ViewCustomAttributes = "";

                    // PintuUtamaOutTanggal
                    PintuUtamaOutTanggal.ViewValue = PintuUtamaOutTanggal.CurrentValue;
                    PintuUtamaOutTanggal.ViewValue = FormatDateTime(PintuUtamaOutTanggal.ViewValue, PintuUtamaOutTanggal.FormatPattern);
                    PintuUtamaOutTanggal.ViewCustomAttributes = "";

                    // PintuUtamaOutUser
                    PintuUtamaOutUser.ViewValue = ConvertToString(PintuUtamaOutUser.CurrentValue); // DN
                    PintuUtamaOutUser.ViewCustomAttributes = "";

                    // LobbyUtamaId
                    LobbyUtamaId.ViewValue = ConvertToString(LobbyUtamaId.CurrentValue); // DN
                    LobbyUtamaId.ViewCustomAttributes = "";

                    // LobbyUtamaInTanggal
                    LobbyUtamaInTanggal.ViewValue = LobbyUtamaInTanggal.CurrentValue;
                    LobbyUtamaInTanggal.ViewValue = FormatDateTime(LobbyUtamaInTanggal.ViewValue, LobbyUtamaInTanggal.FormatPattern);
                    LobbyUtamaInTanggal.ViewCustomAttributes = "";

                    // LobbyUtamaInUser
                    LobbyUtamaInUser.ViewValue = ConvertToString(LobbyUtamaInUser.CurrentValue); // DN
                    LobbyUtamaInUser.ViewCustomAttributes = "";

                    // LobbyUtamaOutTanggal
                    LobbyUtamaOutTanggal.ViewValue = LobbyUtamaOutTanggal.CurrentValue;
                    LobbyUtamaOutTanggal.ViewValue = FormatDateTime(LobbyUtamaOutTanggal.ViewValue, LobbyUtamaOutTanggal.FormatPattern);
                    LobbyUtamaOutTanggal.ViewCustomAttributes = "";

                    // LobbyUtamaOutUser
                    LobbyUtamaOutUser.ViewValue = ConvertToString(LobbyUtamaOutUser.CurrentValue); // DN
                    LobbyUtamaOutUser.ViewCustomAttributes = "";

                    // AreaTerlarangId
                    AreaTerlarangId.ViewValue = ConvertToString(AreaTerlarangId.CurrentValue); // DN
                    AreaTerlarangId.ViewCustomAttributes = "";

                    // AreaTerlarangInTanggal
                    AreaTerlarangInTanggal.ViewValue = AreaTerlarangInTanggal.CurrentValue;
                    AreaTerlarangInTanggal.ViewValue = FormatDateTime(AreaTerlarangInTanggal.ViewValue, AreaTerlarangInTanggal.FormatPattern);
                    AreaTerlarangInTanggal.ViewCustomAttributes = "";

                    // AreaTerlarangInUser
                    AreaTerlarangInUser.ViewValue = ConvertToString(AreaTerlarangInUser.CurrentValue); // DN
                    AreaTerlarangInUser.ViewCustomAttributes = "";

                    // AreaTerlarangOutTanggal
                    AreaTerlarangOutTanggal.ViewValue = AreaTerlarangOutTanggal.CurrentValue;
                    AreaTerlarangOutTanggal.ViewValue = FormatDateTime(AreaTerlarangOutTanggal.ViewValue, AreaTerlarangOutTanggal.FormatPattern);
                    AreaTerlarangOutTanggal.ViewCustomAttributes = "";

                    // AreaTerlarangOutUser
                    AreaTerlarangOutUser.ViewValue = ConvertToString(AreaTerlarangOutUser.CurrentValue); // DN
                    AreaTerlarangOutUser.ViewCustomAttributes = "";

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

                    // StatusZonaPrev
                    StatusZonaPrev.ViewValue = ConvertToString(StatusZonaPrev.CurrentValue); // DN
                    StatusZonaPrev.ViewCustomAttributes = "";

                // LookupPlant
                LookupPlant.HrefValue = "";

                // Plant
                Plant.HrefValue = "";
                Plant.TooltipValue = "";

                // Tanggal
                Tanggal.HrefValue = "";
                Tanggal.TooltipValue = "";

                // StatusZona
                StatusZona.HrefValue = "";
                StatusZona.TooltipValue = "";

                // Nama
                Nama.HrefValue = "";
                Nama.TooltipValue = "";

                // AsalPerusahaan
                AsalPerusahaan.HrefValue = "";
                AsalPerusahaan.TooltipValue = "";

                // Jabatan
                Jabatan.HrefValue = "";
                Jabatan.TooltipValue = "";

                // FungsiygDikunjungi
                FungsiygDikunjungi.HrefValue = "";
                FungsiygDikunjungi.TooltipValue = "";

                // MaksudKunjungan
                MaksudKunjungan.HrefValue = "";
                MaksudKunjungan.TooltipValue = "";

                // TandaPengenal
                TandaPengenal.HrefValue = "";
                TandaPengenal.TooltipValue = "";

                // TandaTangan
                TandaTangan.HrefValue = "";

                // TandaTanganDownload
                TandaTanganDownload.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // PintuUtamaId
                PintuUtamaId.HrefValue = "";

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.HrefValue = "";

                // PintuUtamaInFoto
                PintuUtamaInFoto.HrefValue = "";

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.HrefValue = "";

                // StatusZonaPrev
                StatusZonaPrev.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // LookupPlant
                LookupPlant.SetupEditAttributes();
                LookupPlant.EditValue = LookupPlant.Options(true);
                LookupPlant.PlaceHolder = RemoveHtml(LookupPlant.Caption);
                if (!Empty(LookupPlant.EditValue) && IsNumeric(LookupPlant.EditValue))
                    LookupPlant.EditValue = FormatNumber(LookupPlant.EditValue, null);

                // Plant
                Plant.SetupEditAttributes();
                Plant.EditValue = Plant.CurrentValue;

                // awallookupbung
                string curVal2 = ConvertToString(Plant.CurrentValue);
                Plant.EditValue = Empty(curVal2) ? DbNullValue : HtmlEncode(Plant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Plant.EditValue = Plant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = Plant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                            var listwrk = Plant.Lookup?.RenderViewRow(rswrk2[0]);
                            Plant.EditValue = Plant.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);

                // Tanggal
                Tanggal.SetupEditAttributes();
                Tanggal.EditValue = FormatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
                Tanggal.PlaceHolder = RemoveHtml(Tanggal.Caption);

                // StatusZona
                StatusZona.SetupEditAttributes();
                if (!StatusZona.Raw)
                    StatusZona.CurrentValue = HtmlDecode(StatusZona.CurrentValue);
                StatusZona.EditValue = HtmlEncode(StatusZona.CurrentValue);
                StatusZona.PlaceHolder = RemoveHtml(StatusZona.Caption);

                // Nama
                Nama.SetupEditAttributes();
                if (!Nama.Raw)
                    Nama.CurrentValue = HtmlDecode(Nama.CurrentValue);
                Nama.EditValue = HtmlEncode(Nama.CurrentValue);
                Nama.PlaceHolder = RemoveHtml(Nama.Caption);

                // AsalPerusahaan
                AsalPerusahaan.SetupEditAttributes();
                if (!AsalPerusahaan.Raw)
                    AsalPerusahaan.CurrentValue = HtmlDecode(AsalPerusahaan.CurrentValue);
                AsalPerusahaan.EditValue = HtmlEncode(AsalPerusahaan.CurrentValue);
                AsalPerusahaan.PlaceHolder = RemoveHtml(AsalPerusahaan.Caption);

                // Jabatan
                Jabatan.SetupEditAttributes();
                if (!Jabatan.Raw)
                    Jabatan.CurrentValue = HtmlDecode(Jabatan.CurrentValue);
                Jabatan.EditValue = HtmlEncode(Jabatan.CurrentValue);
                Jabatan.PlaceHolder = RemoveHtml(Jabatan.Caption);

                // FungsiygDikunjungi
                FungsiygDikunjungi.SetupEditAttributes();
                string curVal3 = ConvertToString(FungsiygDikunjungi.CurrentValue);
                if (FungsiygDikunjungi.Lookup != null && IsDictionary(FungsiygDikunjungi.Lookup?.Options) && FungsiygDikunjungi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    FungsiygDikunjungi.EditValue = FungsiygDikunjungi.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk3 = "";
                    if (curVal3 == "") {
                        filterWrk3 = "0=1";
                    } else {
                        filterWrk3 = SearchFilter(FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchExpression, "=", FungsiygDikunjungi.CurrentValue, FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchDataType, "");
                    }
                    string? sqlWrk3 = FungsiygDikunjungi.Lookup?.GetSql(true, filterWrk3, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    FungsiygDikunjungi.EditValue = rswrk3;
                }
                FungsiygDikunjungi.PlaceHolder = RemoveHtml(FungsiygDikunjungi.Caption);

                // MaksudKunjungan
                MaksudKunjungan.SetupEditAttributes();
                if (!MaksudKunjungan.Raw)
                    MaksudKunjungan.CurrentValue = HtmlDecode(MaksudKunjungan.CurrentValue);
                MaksudKunjungan.EditValue = HtmlEncode(MaksudKunjungan.CurrentValue);
                MaksudKunjungan.PlaceHolder = RemoveHtml(MaksudKunjungan.Caption);

                // TandaPengenal
                TandaPengenal.SetupEditAttributes();
                TandaPengenal.EditValue = TandaPengenal.Options(true);
                TandaPengenal.PlaceHolder = RemoveHtml(TandaPengenal.Caption);

                // TandaTangan
                TandaTangan.SetupEditAttributes();
                TandaTangan.EditValue = TandaTangan.CurrentValue; // DN
                TandaTangan.PlaceHolder = RemoveHtml(TandaTangan.Caption);

                // TandaTanganDownload
                TandaTanganDownload.SetupEditAttributes();
                TandaTanganDownload.EditValue = TandaTanganDownload.CurrentValue; // DN
                TandaTanganDownload.PlaceHolder = RemoveHtml(TandaTanganDownload.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // PintuUtamaId
                PintuUtamaId.SetupEditAttributes();
                if (!PintuUtamaId.Raw)
                    PintuUtamaId.CurrentValue = HtmlDecode(PintuUtamaId.CurrentValue);
                PintuUtamaId.EditValue = HtmlEncode(PintuUtamaId.CurrentValue);
                PintuUtamaId.PlaceHolder = RemoveHtml(PintuUtamaId.Caption);

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.SetupEditAttributes();
                PintuUtamaInTanggal.EditValue = FormatDateTime(PintuUtamaInTanggal.CurrentValue, PintuUtamaInTanggal.FormatPattern);
                PintuUtamaInTanggal.PlaceHolder = RemoveHtml(PintuUtamaInTanggal.Caption);

                // PintuUtamaInFoto
                PintuUtamaInFoto.SetupEditAttributes();
                PintuUtamaInFoto.EditValue = PintuUtamaInFoto.CurrentValue; // DN
                PintuUtamaInFoto.PlaceHolder = RemoveHtml(PintuUtamaInFoto.Caption);

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.SetupEditAttributes();
                PintuUtamaInFotoDownload.EditValue = PintuUtamaInFotoDownload.CurrentValue; // DN
                PintuUtamaInFotoDownload.PlaceHolder = RemoveHtml(PintuUtamaInFotoDownload.Caption);

                // StatusZonaPrev
                StatusZonaPrev.SetupEditAttributes();
                if (!StatusZonaPrev.Raw)
                    StatusZonaPrev.CurrentValue = HtmlDecode(StatusZonaPrev.CurrentValue);
                StatusZonaPrev.EditValue = HtmlEncode(StatusZonaPrev.CurrentValue);
                StatusZonaPrev.PlaceHolder = RemoveHtml(StatusZonaPrev.Caption);

                // Add refer script

                // LookupPlant
                LookupPlant.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // Tanggal
                Tanggal.HrefValue = "";

                // StatusZona
                StatusZona.HrefValue = "";

                // Nama
                Nama.HrefValue = "";

                // AsalPerusahaan
                AsalPerusahaan.HrefValue = "";

                // Jabatan
                Jabatan.HrefValue = "";

                // FungsiygDikunjungi
                FungsiygDikunjungi.HrefValue = "";

                // MaksudKunjungan
                MaksudKunjungan.HrefValue = "";

                // TandaPengenal
                TandaPengenal.HrefValue = "";

                // TandaTangan
                TandaTangan.HrefValue = "";

                // TandaTanganDownload
                TandaTanganDownload.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // PintuUtamaId
                PintuUtamaId.HrefValue = "";

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.HrefValue = "";

                // PintuUtamaInFoto
                PintuUtamaInFoto.HrefValue = "";

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.HrefValue = "";

                // StatusZonaPrev
                StatusZonaPrev.HrefValue = "";
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

        private void ValidateCustomLookupPlant() {
            if (LookupPlant.Visible && LookupPlant.Required) {
                if (!LookupPlant.IsDetailKey && Empty(LookupPlant.FormValue)) {
                    LookupPlant.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomPlant() {
            if (Plant.Visible && Plant.Required) {
                if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                    Plant.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomTanggal() {
            if (Tanggal.Visible && Tanggal.Required) {
                if (!Tanggal.IsDetailKey && Empty(Tanggal.FormValue)) {
                    Tanggal.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomStatusZona() {
            if (StatusZona.Visible && StatusZona.Required) {
                if (!StatusZona.IsDetailKey && Empty(StatusZona.FormValue)) {
                    StatusZona.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomNama() {
            if (Nama.Visible && Nama.Required) {
                if (!Nama.IsDetailKey && Empty(Nama.FormValue)) {
                    Nama.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomAsalPerusahaan() {
            if (AsalPerusahaan.Visible && AsalPerusahaan.Required) {
                if (!AsalPerusahaan.IsDetailKey && Empty(AsalPerusahaan.FormValue)) {
                    AsalPerusahaan.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomJabatan() {
            if (Jabatan.Visible && Jabatan.Required) {
                if (!Jabatan.IsDetailKey && Empty(Jabatan.FormValue)) {
                    Jabatan.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomFungsiygDikunjungi() {
            if (FungsiygDikunjungi.Visible && FungsiygDikunjungi.Required) {
                if (!FungsiygDikunjungi.IsDetailKey && Empty(FungsiygDikunjungi.FormValue)) {
                    FungsiygDikunjungi.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomMaksudKunjungan() {
            if (MaksudKunjungan.Visible && MaksudKunjungan.Required) {
                if (!MaksudKunjungan.IsDetailKey && Empty(MaksudKunjungan.FormValue)) {
                    MaksudKunjungan.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomTandaPengenal() {
            if (TandaPengenal.Visible && TandaPengenal.Required) {
                if (!TandaPengenal.IsDetailKey && Empty(TandaPengenal.FormValue)) {
                    TandaPengenal.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomTandaTangan() {
            if (TandaTangan.Visible && TandaTangan.Required) {
                if (!TandaTangan.IsDetailKey && Empty(TandaTangan.FormValue)) {
                    TandaTangan.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomTandaTanganDownload() {
            if (TandaTanganDownload.Visible && TandaTanganDownload.Required) {
                if (!TandaTanganDownload.IsDetailKey && Empty(TandaTanganDownload.FormValue)) {
                    TandaTanganDownload.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomKeterangan() {
            if (Keterangan.Visible && Keterangan.Required) {
                if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                    Keterangan.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomPintuUtamaId() {
            if (PintuUtamaId.Visible && PintuUtamaId.Required) {
                if (!PintuUtamaId.IsDetailKey && Empty(PintuUtamaId.FormValue)) {
                    PintuUtamaId.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomPintuUtamaInTanggal() {
            if (PintuUtamaInTanggal.Visible && PintuUtamaInTanggal.Required) {
                if (!PintuUtamaInTanggal.IsDetailKey && Empty(PintuUtamaInTanggal.FormValue)) {
                    PintuUtamaInTanggal.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomPintuUtamaInFoto() {
            if (PintuUtamaInFoto.Visible && PintuUtamaInFoto.Required) {
                if (!PintuUtamaInFoto.IsDetailKey && Empty(PintuUtamaInFoto.FormValue)) {
                    PintuUtamaInFoto.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomPintuUtamaInFotoDownload() {
            if (PintuUtamaInFotoDownload.Visible && PintuUtamaInFotoDownload.Required) {
                if (!PintuUtamaInFotoDownload.IsDetailKey && Empty(PintuUtamaInFotoDownload.FormValue)) {
                    PintuUtamaInFotoDownload.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        private void ValidateCustomStatusZonaPrev() {
            if (StatusZonaPrev.Visible && StatusZonaPrev.Required) {
                if (!StatusZonaPrev.IsDetailKey && Empty(StatusZonaPrev.FormValue)) {
                    StatusZonaPrev.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomLookupPlant();
                ValidateCustomPlant();
                ValidateCustomTanggal();
                if (!CheckDate(Tanggal.FormValue, Tanggal.FormatPattern)) {
                    Tanggal.AddErrorMessage(Tanggal.GetErrorMessage(false));
                }
                ValidateCustomStatusZona();
                ValidateCustomNama();
                ValidateCustomAsalPerusahaan();
                ValidateCustomJabatan();
                ValidateCustomFungsiygDikunjungi();
                ValidateCustomMaksudKunjungan();
                ValidateCustomTandaPengenal();
                ValidateCustomTandaTangan();
                ValidateCustomTandaTanganDownload();
                ValidateCustomKeterangan();
                ValidateCustomPintuUtamaId();
                if (!CheckInteger(PintuUtamaId.FormValue)) {
                    PintuUtamaId.AddErrorMessage(PintuUtamaId.GetErrorMessage(false));
                }
                ValidateCustomPintuUtamaInTanggal();
                if (!CheckDate(PintuUtamaInTanggal.FormValue, PintuUtamaInTanggal.FormatPattern)) {
                    PintuUtamaInTanggal.AddErrorMessage(PintuUtamaInTanggal.GetErrorMessage(false));
                }
                ValidateCustomPintuUtamaInFoto();
                ValidateCustomPintuUtamaInFotoDownload();
                ValidateCustomStatusZonaPrev();

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

                // LookupPlant
                LookupPlant.SetDbValue(rsnew, LookupPlant.CurrentValue);

                // Plant
                Plant.SetDbValue(rsnew, Plant.CurrentValue);

                // Tanggal
                Tanggal.SetDbValue(rsnew, ConvertToDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern));

                // StatusZona
                StatusZona.SetDbValue(rsnew, StatusZona.CurrentValue);

                // Nama
                Nama.SetDbValue(rsnew, Nama.CurrentValue);

                // AsalPerusahaan
                AsalPerusahaan.SetDbValue(rsnew, AsalPerusahaan.CurrentValue);

                // Jabatan
                Jabatan.SetDbValue(rsnew, Jabatan.CurrentValue);

                // FungsiygDikunjungi
                FungsiygDikunjungi.SetDbValue(rsnew, FungsiygDikunjungi.CurrentValue);

                // MaksudKunjungan
                MaksudKunjungan.SetDbValue(rsnew, MaksudKunjungan.CurrentValue);

                // TandaPengenal
                TandaPengenal.SetDbValue(rsnew, TandaPengenal.CurrentValue);

                // TandaTangan
                TandaTangan.SetDbValue(rsnew, TandaTangan.CurrentValue);

                // TandaTanganDownload
                TandaTanganDownload.SetDbValue(rsnew, TandaTanganDownload.CurrentValue);

                // Keterangan
                Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue);

                // PintuUtamaId
                PintuUtamaId.SetDbValue(rsnew, PintuUtamaId.CurrentValue);

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.SetDbValue(rsnew, ConvertToDateTime(PintuUtamaInTanggal.CurrentValue, PintuUtamaInTanggal.FormatPattern));

                // PintuUtamaInFoto
                PintuUtamaInFoto.SetDbValue(rsnew, PintuUtamaInFoto.CurrentValue);

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.SetDbValue(rsnew, PintuUtamaInFotoDownload.CurrentValue);

                // StatusZonaPrev
                StatusZonaPrev.SetDbValue(rsnew, StatusZonaPrev.CurrentValue);
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
            if (row.TryGetValue("LookupPlant", out value)) // LookupPlant
                LookupPlant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Tanggal", out value)) // Tanggal
                Tanggal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusZona", out value)) // StatusZona
                StatusZona.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Nama", out value)) // Nama
                Nama.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AsalPerusahaan", out value)) // AsalPerusahaan
                AsalPerusahaan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Jabatan", out value)) // Jabatan
                Jabatan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("FungsiygDikunjungi", out value)) // FungsiygDikunjungi
                FungsiygDikunjungi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("MaksudKunjungan", out value)) // MaksudKunjungan
                MaksudKunjungan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TandaPengenal", out value)) // TandaPengenal
                TandaPengenal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TandaTangan", out value)) // TandaTangan
                TandaTangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TandaTanganDownload", out value)) // TandaTanganDownload
                TandaTanganDownload.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PintuUtamaId", out value)) // PintuUtamaId
                PintuUtamaId.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PintuUtamaInTanggal", out value)) // PintuUtamaInTanggal
                PintuUtamaInTanggal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PintuUtamaInFoto", out value)) // PintuUtamaInFoto
                PintuUtamaInFoto.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PintuUtamaInFotoDownload", out value)) // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusZonaPrev", out value)) // StatusZonaPrev
                StatusZonaPrev.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("BukuTamuList")), "", TableVar, true);
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
