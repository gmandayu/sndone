using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterPlantEdit
    /// </summary>
    public static MasterPlantEdit masterPlantEdit
    {
        get => HttpData.Get<MasterPlantEdit>("masterPlantEdit")!;
        set => HttpData["masterPlantEdit"] = value;
    }

    /// <summary>
    /// Page class for MasterPlant
    /// </summary>
    public class MasterPlantEdit : MasterPlantEditBase
    {
        // Constructor
        public MasterPlantEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterPlantEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MasterPlantEditBase : MasterPlant
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterPlantEdit";

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
        public MasterPlantEditBase(Controller? controller)
        {
            TableName = "MasterPlant";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterPlant)
            if (masterPlant == null || masterPlant is MasterPlant)
                masterPlant = this;

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
        public string PageName => "MasterPlantEdit";

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
            IdPlant.SetVisibility();
            Terminal_Manager.SetVisibility();
            PRL.SetVisibility();
            Status.SetVisibility();
            Terminal_Induk.SetVisibility();
            Nama_Terminal.SetVisibility();
            Region.SetVisibility();
            Fungsi.SetVisibility();
            Cost_Center.SetVisibility();
            Jenis.SetVisibility();
            Plant.SetVisibility();
            UTC.SetVisibility();
            TipeProduk.SetVisibility();
            JenisPlant.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
        }

        // Constructor
        public MasterPlantEditBase() : this(null) { }

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
                        result.Add("view", pageName == "MasterPlantView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdPlant") ? dict["IdPlant"] : IdPlant.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdPlant.Visible = false;
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
                if (RouteValues.TryGetValue("IdPlant", out rv)) {
                    IdPlant.FormValue = UrlDecode(rv);
                    IdPlant.OldValue = IdPlant.FormValue;
                } else if (CurrentForm.HasValue("x_IdPlant")) {
                    IdPlant.FormValue = CurrentForm.GetValue("x_IdPlant");
                    IdPlant.OldValue = IdPlant.FormValue;
                } else if (!Empty(keyValues)) {
                    IdPlant.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("IdPlant", out rv)) {
                        IdPlant.QueryValue = UrlDecode(rv);
                        loadByQuery = true;
                    } else if (Get("IdPlant", out sv)) {
                        IdPlant.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdPlant.CurrentValue = DbNullValue;
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
                IdPlant.FormValue = ConvertToString(keyValues[0]);
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
                return Terminate("MasterPlantList");
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
                    if (GetPageName(returnUrl) != "MasterPlantList") {
                        TempData["Return-Url"] = returnUrl;
                        returnUrl = "MasterPlantList";
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
            if (GetPageName(returnUrl) == "MasterPlantList")
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
                    await SetupLookupOptions(UTC);
                    await SetupLookupOptions(TipeProduk);
                    await SetupLookupOptions(JenisPlant);
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
                        masterPlantEdit?.PageRender();
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
            if (!IdPlant.IsDetailKey) {
                SetNormalField(IdPlant, "IdPlant", "x_IdPlant");
            }

            // Standard handling for 'Terminal_Manager'
            Terminal_Manager.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Terminal_Manager, "Terminal_Manager", "x_Terminal_Manager");

            // Standard handling for 'PRL'
            PRL.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PRL, "PRL", "x_PRL");

            // Standard handling for 'Status'
            Status.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Status, "Status", "x_Status");

            // Standard handling for 'Terminal_Induk'
            Terminal_Induk.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Terminal_Induk, "Terminal_Induk", "x_Terminal_Induk");

            // Standard handling for 'Nama_Terminal'
            Nama_Terminal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Nama_Terminal, "Nama_Terminal", "x_Nama_Terminal");

            // Standard handling for 'Region'
            Region.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Region, "Region", "x_Region");

            // Standard handling for 'Fungsi'
            Fungsi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Fungsi, "Fungsi", "x_Fungsi");

            // Standard handling for 'Cost_Center'
            Cost_Center.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Cost_Center, "Cost_Center", "x_Cost_Center");

            // Standard handling for 'Jenis'
            Jenis.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Jenis, "Jenis", "x_Jenis");

            // Standard handling for 'Plant'
            Plant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Plant, "Plant", "x_Plant");

            // Standard handling for 'UTC'
            UTC.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(UTC, "UTC", "x_UTC");

            // Standard handling for 'TipeProduk'
            TipeProduk.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TipeProduk, "TipeProduk", "x_TipeProduk");

            // Standard handling for 'JenisPlant'
            JenisPlant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(JenisPlant, "JenisPlant", "x_JenisPlant");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdPlant.CurrentValue = IdPlant.FormValue;
            Terminal_Manager.CurrentValue = Terminal_Manager.FormValue;
            PRL.CurrentValue = PRL.FormValue;
            Status.CurrentValue = Status.FormValue;
            Terminal_Induk.CurrentValue = Terminal_Induk.FormValue;
            Nama_Terminal.CurrentValue = Nama_Terminal.FormValue;
            Region.CurrentValue = Region.FormValue;
            Fungsi.CurrentValue = Fungsi.FormValue;
            Cost_Center.CurrentValue = Cost_Center.FormValue;
            Jenis.CurrentValue = Jenis.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            UTC.CurrentValue = UTC.FormValue;
            TipeProduk.CurrentValue = TipeProduk.FormValue;
            JenisPlant.CurrentValue = JenisPlant.FormValue;
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
            IdPlant.SetDbValue(row["IdPlant"]);
            Terminal_Manager.SetDbValue(row["Terminal_Manager"]);
            PRL.SetDbValue(row["PRL"]);
            Status.SetDbValue(row["Status"]);
            Terminal_Induk.SetDbValue(row["Terminal_Induk"]);
            Nama_Terminal.SetDbValue(row["Nama_Terminal"]);
            Region.SetDbValue(row["Region"]);
            Fungsi.SetDbValue(row["Fungsi"]);
            Cost_Center.SetDbValue(row["Cost_Center"]);
            Jenis.SetDbValue(row["Jenis"]);
            Plant.SetDbValue(row["Plant"]);
            UTC.SetDbValue(row["UTC"]);
            TipeProduk.SetDbValue(row["TipeProduk"]);
            JenisPlant.SetDbValue(row["JenisPlant"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Terminal_Manager", Terminal_Manager.DefaultValue ?? DbNullValue); // DN
            row.Add("PRL", PRL.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("Terminal_Induk", Terminal_Induk.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama_Terminal", Nama_Terminal.DefaultValue ?? DbNullValue); // DN
            row.Add("Region", Region.DefaultValue ?? DbNullValue); // DN
            row.Add("Fungsi", Fungsi.DefaultValue ?? DbNullValue); // DN
            row.Add("Cost_Center", Cost_Center.DefaultValue ?? DbNullValue); // DN
            row.Add("Jenis", Jenis.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("UTC", UTC.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProduk", TipeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("JenisPlant", JenisPlant.DefaultValue ?? DbNullValue); // DN
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

            // IdPlant
            IdPlant.RowCssClass = "row";

            // Terminal_Manager
            Terminal_Manager.RowCssClass = "row";

            // PRL
            PRL.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // Terminal_Induk
            Terminal_Induk.RowCssClass = "row";

            // Nama_Terminal
            Nama_Terminal.RowCssClass = "row";

            // Region
            Region.RowCssClass = "row";

            // Fungsi
            Fungsi.RowCssClass = "row";

            // Cost_Center
            Cost_Center.RowCssClass = "row";

            // Jenis
            Jenis.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // UTC
            UTC.RowCssClass = "row";

            // TipeProduk
            TipeProduk.RowCssClass = "row";

            // JenisPlant
            JenisPlant.RowCssClass = "row";

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
                // Terminal_Manager

                // PRL

                // Status

                // Terminal_Induk

                // Nama_Terminal

                // Region

                // Fungsi

                // Cost_Center

                // Jenis

                // Plant

                // UTC

                // TipeProduk

                // JenisPlant

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

                    // IdPlant
                    IdPlant.ViewValue = IdPlant.CurrentValue;
                    IdPlant.ViewCustomAttributes = "";

                    // Terminal_Manager
                    Terminal_Manager.ViewValue = ConvertToString(Terminal_Manager.CurrentValue); // DN
                    Terminal_Manager.ViewCustomAttributes = "";

                    // PRL
                    PRL.ViewValue = ConvertToString(PRL.CurrentValue); // DN
                    PRL.ViewCustomAttributes = "";

                    // Status
                    Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                    Status.ViewCustomAttributes = "";

                    // Terminal_Induk
                    Terminal_Induk.ViewValue = ConvertToString(Terminal_Induk.CurrentValue); // DN
                    Terminal_Induk.ViewCustomAttributes = "";

                    // Nama_Terminal
                    Nama_Terminal.ViewValue = ConvertToString(Nama_Terminal.CurrentValue); // DN
                    Nama_Terminal.ViewCustomAttributes = "";

                    // Region
                    Region.ViewValue = ConvertToString(Region.CurrentValue); // DN
                    Region.ViewCustomAttributes = "";

                    // Fungsi
                    Fungsi.ViewValue = ConvertToString(Fungsi.CurrentValue); // DN
                    Fungsi.ViewCustomAttributes = "";

                    // Cost_Center
                    Cost_Center.ViewValue = ConvertToString(Cost_Center.CurrentValue); // DN
                    Cost_Center.ViewCustomAttributes = "";

                    // Jenis
                    Jenis.ViewValue = ConvertToString(Jenis.CurrentValue); // DN
                    Jenis.ViewCustomAttributes = "";

                    // Plant
                    Plant.ViewValue = ConvertToString(Plant.CurrentValue); // DN
                    Plant.ViewCustomAttributes = "";

                    // UTC
                    if (!Empty(UTC.CurrentValue)) {
                        UTC.ViewValue = UTC.OptionCaption(ConvertToString(UTC.CurrentValue));
                    } else {
                        UTC.ViewValue = DbNullValue;
                    }
                    UTC.ViewCustomAttributes = "";

                    // TipeProduk
                    if (!Empty(TipeProduk.CurrentValue)) {
                        TipeProduk.ViewValue = TipeProduk.OptionCaption(ConvertToString(TipeProduk.CurrentValue));
                    } else {
                        TipeProduk.ViewValue = DbNullValue;
                    }
                    TipeProduk.ViewCustomAttributes = "";

                    // JenisPlant
                    if (!Empty(JenisPlant.CurrentValue)) {
                        JenisPlant.ViewValue = JenisPlant.OptionCaption(ConvertToString(JenisPlant.CurrentValue));
                    } else {
                        JenisPlant.ViewValue = DbNullValue;
                    }
                    JenisPlant.ViewCustomAttributes = "";

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

                // IdPlant
                IdPlant.HrefValue = "";

                // Terminal_Manager
                Terminal_Manager.HrefValue = "";

                // PRL
                PRL.HrefValue = "";

                // Status
                Status.HrefValue = "";

                // Terminal_Induk
                Terminal_Induk.HrefValue = "";

                // Nama_Terminal
                Nama_Terminal.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Fungsi
                Fungsi.HrefValue = "";

                // Cost_Center
                Cost_Center.HrefValue = "";

                // Jenis
                Jenis.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // UTC
                UTC.HrefValue = "";

                // TipeProduk
                TipeProduk.HrefValue = "";

                // JenisPlant
                JenisPlant.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // IdPlant
                IdPlant.SetupEditAttributes();
                IdPlant.EditValue = IdPlant.CurrentValue;
                IdPlant.ViewCustomAttributes = "";

                // Terminal_Manager
                Terminal_Manager.SetupEditAttributes();
                if (!Terminal_Manager.Raw)
                    Terminal_Manager.CurrentValue = HtmlDecode(Terminal_Manager.CurrentValue);
                Terminal_Manager.EditValue = HtmlEncode(Terminal_Manager.CurrentValue);
                Terminal_Manager.PlaceHolder = RemoveHtml(Terminal_Manager.Caption);

                // PRL
                PRL.SetupEditAttributes();
                if (!PRL.Raw)
                    PRL.CurrentValue = HtmlDecode(PRL.CurrentValue);
                PRL.EditValue = HtmlEncode(PRL.CurrentValue);
                PRL.PlaceHolder = RemoveHtml(PRL.Caption);

                // Status
                Status.SetupEditAttributes();
                if (!Status.Raw)
                    Status.CurrentValue = HtmlDecode(Status.CurrentValue);
                Status.EditValue = HtmlEncode(Status.CurrentValue);
                Status.PlaceHolder = RemoveHtml(Status.Caption);

                // Terminal_Induk
                Terminal_Induk.SetupEditAttributes();
                if (!Terminal_Induk.Raw)
                    Terminal_Induk.CurrentValue = HtmlDecode(Terminal_Induk.CurrentValue);
                Terminal_Induk.EditValue = HtmlEncode(Terminal_Induk.CurrentValue);
                Terminal_Induk.PlaceHolder = RemoveHtml(Terminal_Induk.Caption);

                // Nama_Terminal
                Nama_Terminal.SetupEditAttributes();
                if (!Nama_Terminal.Raw)
                    Nama_Terminal.CurrentValue = HtmlDecode(Nama_Terminal.CurrentValue);
                Nama_Terminal.EditValue = HtmlEncode(Nama_Terminal.CurrentValue);
                Nama_Terminal.PlaceHolder = RemoveHtml(Nama_Terminal.Caption);

                // Region
                Region.SetupEditAttributes();
                if (!Region.Raw)
                    Region.CurrentValue = HtmlDecode(Region.CurrentValue);
                Region.EditValue = HtmlEncode(Region.CurrentValue);
                Region.PlaceHolder = RemoveHtml(Region.Caption);

                // Fungsi
                Fungsi.SetupEditAttributes();
                if (!Fungsi.Raw)
                    Fungsi.CurrentValue = HtmlDecode(Fungsi.CurrentValue);
                Fungsi.EditValue = HtmlEncode(Fungsi.CurrentValue);
                Fungsi.PlaceHolder = RemoveHtml(Fungsi.Caption);

                // Cost_Center
                Cost_Center.SetupEditAttributes();
                if (!Cost_Center.Raw)
                    Cost_Center.CurrentValue = HtmlDecode(Cost_Center.CurrentValue);
                Cost_Center.EditValue = HtmlEncode(Cost_Center.CurrentValue);
                Cost_Center.PlaceHolder = RemoveHtml(Cost_Center.Caption);

                // Jenis
                Jenis.SetupEditAttributes();
                if (!Jenis.Raw)
                    Jenis.CurrentValue = HtmlDecode(Jenis.CurrentValue);
                Jenis.EditValue = HtmlEncode(Jenis.CurrentValue);
                Jenis.PlaceHolder = RemoveHtml(Jenis.Caption);

                // Plant
                Plant.SetupEditAttributes();
                if (!Plant.Raw)
                    Plant.CurrentValue = HtmlDecode(Plant.CurrentValue);
                Plant.EditValue = HtmlEncode(Plant.CurrentValue);
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);

                // UTC
                UTC.SetupEditAttributes();
                UTC.EditValue = UTC.Options(true);
                UTC.PlaceHolder = RemoveHtml(UTC.Caption);

                // TipeProduk
                TipeProduk.SetupEditAttributes();
                TipeProduk.EditValue = TipeProduk.Options(true);
                TipeProduk.PlaceHolder = RemoveHtml(TipeProduk.Caption);

                // JenisPlant
                JenisPlant.SetupEditAttributes();
                JenisPlant.EditValue = JenisPlant.Options(true);
                JenisPlant.PlaceHolder = RemoveHtml(JenisPlant.Caption);

                // Edit refer script

                // IdPlant
                IdPlant.HrefValue = "";

                // Terminal_Manager
                Terminal_Manager.HrefValue = "";

                // PRL
                PRL.HrefValue = "";

                // Status
                Status.HrefValue = "";

                // Terminal_Induk
                Terminal_Induk.HrefValue = "";

                // Nama_Terminal
                Nama_Terminal.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Fungsi
                Fungsi.HrefValue = "";

                // Cost_Center
                Cost_Center.HrefValue = "";

                // Jenis
                Jenis.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // UTC
                UTC.HrefValue = "";

                // TipeProduk
                TipeProduk.HrefValue = "";

                // JenisPlant
                JenisPlant.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998

        private void ValidateCustomIdPlant() {
            if (IdPlant.Visible && IdPlant.Required) {
                if (!IdPlant.IsDetailKey && Empty(IdPlant.FormValue)) {
                    IdPlant.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomTerminal_Manager() {
            if (Terminal_Manager.Visible && Terminal_Manager.Required) {
                if (!Terminal_Manager.IsDetailKey && Empty(Terminal_Manager.FormValue)) {
                    Terminal_Manager.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomPRL() {
            if (PRL.Visible && PRL.Required) {
                if (!PRL.IsDetailKey && Empty(PRL.FormValue)) {
                    PRL.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomStatus() {
            if (Status.Visible && Status.Required) {
                if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                    Status.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomTerminal_Induk() {
            if (Terminal_Induk.Visible && Terminal_Induk.Required) {
                if (!Terminal_Induk.IsDetailKey && Empty(Terminal_Induk.FormValue)) {
                    Terminal_Induk.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomNama_Terminal() {
            if (Nama_Terminal.Visible && Nama_Terminal.Required) {
                if (!Nama_Terminal.IsDetailKey && Empty(Nama_Terminal.FormValue)) {
                    Nama_Terminal.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomRegion() {
            if (Region.Visible && Region.Required) {
                if (!Region.IsDetailKey && Empty(Region.FormValue)) {
                    Region.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomFungsi() {
            if (Fungsi.Visible && Fungsi.Required) {
                if (!Fungsi.IsDetailKey && Empty(Fungsi.FormValue)) {
                    Fungsi.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomCost_Center() {
            if (Cost_Center.Visible && Cost_Center.Required) {
                if (!Cost_Center.IsDetailKey && Empty(Cost_Center.FormValue)) {
                    Cost_Center.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomJenis() {
            if (Jenis.Visible && Jenis.Required) {
                if (!Jenis.IsDetailKey && Empty(Jenis.FormValue)) {
                    Jenis.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomPlant() {
            if (Plant.Visible && Plant.Required) {
                if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                    Plant.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomUTC() {
            if (UTC.Visible && UTC.Required) {
                if (!UTC.IsDetailKey && Empty(UTC.FormValue)) {
                    UTC.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomTipeProduk() {
            if (TipeProduk.Visible && TipeProduk.Required) {
                if (!TipeProduk.IsDetailKey && Empty(TipeProduk.FormValue)) {
                    TipeProduk.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomJenisPlant() {
            if (JenisPlant.Visible && JenisPlant.Required) {
                if (!JenisPlant.IsDetailKey && Empty(JenisPlant.FormValue)) {
                    JenisPlant.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomIdPlant();
                ValidateCustomTerminal_Manager();
                ValidateCustomPRL();
                ValidateCustomStatus();
                ValidateCustomTerminal_Induk();
                ValidateCustomNama_Terminal();
                ValidateCustomRegion();
                ValidateCustomFungsi();
                ValidateCustomCost_Center();
                ValidateCustomJenis();
                ValidateCustomPlant();
                ValidateCustomUTC();
                ValidateCustomTipeProduk();
                ValidateCustomJenisPlant();

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

            // Terminal_Manager
            Terminal_Manager.SetDbValue(rsnew, Terminal_Manager.CurrentValue, Terminal_Manager.ReadOnly);

            // PRL
            PRL.SetDbValue(rsnew, PRL.CurrentValue, PRL.ReadOnly);

            // Status
            Status.SetDbValue(rsnew, Status.CurrentValue, Status.ReadOnly);

            // Terminal_Induk
            Terminal_Induk.SetDbValue(rsnew, Terminal_Induk.CurrentValue, Terminal_Induk.ReadOnly);

            // Nama_Terminal
            Nama_Terminal.SetDbValue(rsnew, Nama_Terminal.CurrentValue, Nama_Terminal.ReadOnly);

            // Region
            Region.SetDbValue(rsnew, Region.CurrentValue, Region.ReadOnly);

            // Fungsi
            Fungsi.SetDbValue(rsnew, Fungsi.CurrentValue, Fungsi.ReadOnly);

            // Cost_Center
            Cost_Center.SetDbValue(rsnew, Cost_Center.CurrentValue, Cost_Center.ReadOnly);

            // Jenis
            Jenis.SetDbValue(rsnew, Jenis.CurrentValue, Jenis.ReadOnly);

            // Plant
            Plant.SetDbValue(rsnew, Plant.CurrentValue, Plant.ReadOnly);

            // UTC
            UTC.SetDbValue(rsnew, UTC.CurrentValue, UTC.ReadOnly);

            // TipeProduk
            TipeProduk.SetDbValue(rsnew, TipeProduk.CurrentValue, TipeProduk.ReadOnly);

            // JenisPlant
            JenisPlant.SetDbValue(rsnew, JenisPlant.CurrentValue, JenisPlant.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Terminal_Manager", out value)) // Terminal_Manager
                Terminal_Manager.CurrentValue = value;
            if (row.TryGetValue("PRL", out value)) // PRL
                PRL.CurrentValue = value;
            if (row.TryGetValue("Status", out value)) // Status
                Status.CurrentValue = value;
            if (row.TryGetValue("Terminal_Induk", out value)) // Terminal_Induk
                Terminal_Induk.CurrentValue = value;
            if (row.TryGetValue("Nama_Terminal", out value)) // Nama_Terminal
                Nama_Terminal.CurrentValue = value;
            if (row.TryGetValue("Region", out value)) // Region
                Region.CurrentValue = value;
            if (row.TryGetValue("Fungsi", out value)) // Fungsi
                Fungsi.CurrentValue = value;
            if (row.TryGetValue("Cost_Center", out value)) // Cost_Center
                Cost_Center.CurrentValue = value;
            if (row.TryGetValue("Jenis", out value)) // Jenis
                Jenis.CurrentValue = value;
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.CurrentValue = value;
            if (row.TryGetValue("UTC", out value)) // UTC
                UTC.CurrentValue = value;
            if (row.TryGetValue("TipeProduk", out value)) // TipeProduk
                TipeProduk.CurrentValue = value;
            if (row.TryGetValue("JenisPlant", out value)) // JenisPlant
                JenisPlant.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterPlantList")), "", TableVar, true);
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
