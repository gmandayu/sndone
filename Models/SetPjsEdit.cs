using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// setPjsEdit
    /// </summary>
    public static SetPjsEdit setPjsEdit
    {
        get => HttpData.Get<SetPjsEdit>("setPjsEdit")!;
        set => HttpData["setPjsEdit"] = value;
    }

    /// <summary>
    /// Page class for SetPjs
    /// </summary>
    public class SetPjsEdit : SetPjsEditBase
    {
        // Constructor
        public SetPjsEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SetPjsEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
            PosisiAwal.DisplayValueSeparator = " - ";
            PosisiPJS.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SetPjsEditBase : SetPjs
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "setPjsEdit";

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
        public SetPjsEditBase(Controller? controller)
        {
            TableName = "SetPjs";

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

            // Table object (setPjs)
            if (setPjs == null || setPjs is SetPjs)
                setPjs = this;

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
        public string PageName => "SetPjsEdit";

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
            Id.SetVisibility();
            NomorPjs.SetVisibility();
            RedirectLink.SetVisibility();
            Nama.SetVisibility();
            OrganizationLevel.SetVisibility();
            Region.SetVisibility();
            Plant.SetVisibility();
            PosisiAwal.SetVisibility();
            PosisiPJS.SetVisibility();
            LookupPosition.SetVisibility();
            TanggalMulai.SetVisibility();
            TanggalSelesai.SetVisibility();
            Status.SetVisibility();
            DownloadSuratTugas.SetVisibility();
            SuratTugas.SetVisibility();
            Keterangan.SetVisibility();
            Remaks.SetVisibility();
            DibuatOleh.SetVisibility();
            TanggalDibuat.SetVisibility();
            DiperbaharuiOleh.SetVisibility();
            DiperbaharuiTanggal.SetVisibility();
            PlantAwal.SetVisibility();
            RegionAwal.SetVisibility();
        }

        // Constructor
        public SetPjsEditBase() : this(null) { }

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
                        result.Add("view", pageName == "SetPjsView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("Id") ? dict["Id"] : Id.CurrentValue));
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
                if (RouteValues.TryGetValue("Id", out rv)) {
                    Id.FormValue = UrlDecode(rv);
                    Id.OldValue = Id.FormValue;
                } else if (CurrentForm.HasValue("x_Id")) {
                    Id.FormValue = CurrentForm.GetValue("x_Id");
                    Id.OldValue = Id.FormValue;
                } else if (!Empty(keyValues)) {
                    Id.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("Id", out rv)) {
                        Id.QueryValue = UrlDecode(rv);
                        loadByQuery = true;
                    } else if (Get("Id", out sv)) {
                        Id.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        Id.CurrentValue = DbNullValue;
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
                Id.FormValue = ConvertToString(keyValues[0]);
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
                return Terminate("SetPjsList");
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
                    if (GetPageName(returnUrl) != "SetPjsList") {
                        TempData["Return-Url"] = returnUrl;
                        returnUrl = "SetPjsList";
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
            if (GetPageName(returnUrl) == "SetPjsList")
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
                    NomorPjs.Required = false;
                    Status.Required = false;

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
                    await SetupLookupOptions(OrganizationLevel);
                    await SetupLookupOptions(Region);
                    await SetupLookupOptions(Plant);
                    await SetupLookupOptions(PosisiAwal);
                    await SetupLookupOptions(PosisiPJS);
                    await SetupLookupOptions(LookupPosition);
                    await SetupLookupOptions(DibuatOleh);
                    await SetupLookupOptions(DiperbaharuiOleh);
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
                        setPjsEdit?.PageRender();
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
            if (!Id.IsDetailKey) {
                SetNormalField(Id, "Id", "x_Id");
            }

            // Standard handling for 'NomorPjs'
            NomorPjs.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NomorPjs, "NomorPjs", "x_NomorPjs");

            // Standard handling for 'RedirectLink'
            RedirectLink.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(RedirectLink, "RedirectLink", "x_RedirectLink");

            // Standard handling for 'Nama'
            Nama.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Nama, "Nama", "x_Nama");

            // Standard handling for 'OrganizationLevel'
            OrganizationLevel.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(OrganizationLevel, "OrganizationLevel", "x_OrganizationLevel");

            // Standard handling for 'Region'
            Region.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Region, "Region", "x_Region");

            // Standard handling for 'Plant'
            Plant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Plant, "Plant", "x_Plant");

            // Standard handling for 'PosisiAwal'
            PosisiAwal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PosisiAwal, "PosisiAwal", "x_PosisiAwal");

            // Standard handling for 'PosisiPJS'
            PosisiPJS.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PosisiPJS, "PosisiPJS", "x_PosisiPJS");

            // Standard handling for 'LookupPosition'
            LookupPosition.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LookupPosition, "LookupPosition", "x_LookupPosition");

            // Standard handling for 'TanggalMulai'
            TanggalMulai.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalMulai, "TanggalMulai", "x_TanggalMulai", true, validate, true);

            // Standard handling for 'TanggalSelesai'
            TanggalSelesai.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalSelesai, "TanggalSelesai", "x_TanggalSelesai", true, validate, true);

            // Standard handling for 'Status'
            Status.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Status, "Status", "x_Status");

            // Standard handling for 'DownloadSuratTugas'
            DownloadSuratTugas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(DownloadSuratTugas, "DownloadSuratTugas", "x_DownloadSuratTugas");

            // Standard handling for 'SuratTugas'
            SuratTugas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(SuratTugas, "SuratTugas", "x_SuratTugas");

            // Standard handling for 'Keterangan'
            Keterangan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Keterangan, "Keterangan", "x_Keterangan");

            // Standard handling for 'Remaks'
            Remaks.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Remaks, "Remaks", "x_Remaks");

            // Standard handling for 'DibuatOleh'
            DibuatOleh.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(DibuatOleh, "DibuatOleh", "x_DibuatOleh");

            // Standard handling for 'TanggalDibuat'
            TanggalDibuat.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalDibuat, "TanggalDibuat", "x_TanggalDibuat", true, validate, true);

            // Standard handling for 'DiperbaharuiOleh'
            DiperbaharuiOleh.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(DiperbaharuiOleh, "DiperbaharuiOleh", "x_DiperbaharuiOleh");

            // Standard handling for 'DiperbaharuiTanggal'
            DiperbaharuiTanggal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(DiperbaharuiTanggal, "DiperbaharuiTanggal", "x_DiperbaharuiTanggal", false, false, true);

            // Standard handling for 'PlantAwal'
            PlantAwal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PlantAwal, "PlantAwal", "x_PlantAwal");

            // Standard handling for 'RegionAwal'
            RegionAwal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(RegionAwal, "RegionAwal", "x_RegionAwal", true, validate, false);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            Id.CurrentValue = Id.FormValue;
            NomorPjs.CurrentValue = NomorPjs.FormValue;
            RedirectLink.CurrentValue = RedirectLink.FormValue;
            Nama.CurrentValue = Nama.FormValue;
            OrganizationLevel.CurrentValue = OrganizationLevel.FormValue;
            Region.CurrentValue = Region.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            PosisiAwal.CurrentValue = PosisiAwal.FormValue;
            PosisiPJS.CurrentValue = PosisiPJS.FormValue;
            LookupPosition.CurrentValue = LookupPosition.FormValue;
            TanggalMulai.CurrentValue = TanggalMulai.FormValue;
            TanggalMulai.CurrentValue = UnformatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
            TanggalSelesai.CurrentValue = TanggalSelesai.FormValue;
            TanggalSelesai.CurrentValue = UnformatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
            Status.CurrentValue = Status.FormValue;
            DownloadSuratTugas.CurrentValue = DownloadSuratTugas.FormValue;
            SuratTugas.CurrentValue = SuratTugas.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            Remaks.CurrentValue = Remaks.FormValue;
            DibuatOleh.CurrentValue = DibuatOleh.FormValue;
            TanggalDibuat.CurrentValue = TanggalDibuat.FormValue;
            TanggalDibuat.CurrentValue = UnformatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            DiperbaharuiOleh.CurrentValue = DiperbaharuiOleh.FormValue;
            DiperbaharuiTanggal.CurrentValue = DiperbaharuiTanggal.FormValue;
            DiperbaharuiTanggal.CurrentValue = UnformatDateTime(DiperbaharuiTanggal.CurrentValue, DiperbaharuiTanggal.FormatPattern);
            PlantAwal.CurrentValue = PlantAwal.FormValue;
            RegionAwal.CurrentValue = RegionAwal.FormValue;
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
            Id.SetDbValue(row["Id"]);
            NomorPjs.SetDbValue(row["NomorPjs"]);
            RedirectLink.SetDbValue(row["RedirectLink"]);
            Nama.SetDbValue(row["Nama"]);
            OrganizationLevel.SetDbValue(row["OrganizationLevel"]);
            Region.SetDbValue(row["Region"]);
            Plant.SetDbValue(row["Plant"]);
            PosisiAwal.SetDbValue(row["PosisiAwal"]);
            PosisiPJS.SetDbValue(row["PosisiPJS"]);
            LookupPosition.SetDbValue(row["LookupPosition"]);
            TanggalMulai.SetDbValue(row["TanggalMulai"]);
            TanggalSelesai.SetDbValue(row["TanggalSelesai"]);
            Status.SetDbValue(row["Status"]);
            DownloadSuratTugas.SetDbValue(row["DownloadSuratTugas"]);
            SuratTugas.SetDbValue(row["SuratTugas"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            Remaks.SetDbValue(row["Remaks"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaharuiOleh.SetDbValue(row["DiperbaharuiOleh"]);
            DiperbaharuiTanggal.SetDbValue(row["DiperbaharuiTanggal"]);
            PlantAwal.SetDbValue(row["PlantAwal"]);
            RegionAwal.SetDbValue(row["RegionAwal"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("Id", Id.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPjs", NomorPjs.DefaultValue ?? DbNullValue); // DN
            row.Add("RedirectLink", RedirectLink.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama", Nama.DefaultValue ?? DbNullValue); // DN
            row.Add("OrganizationLevel", OrganizationLevel.DefaultValue ?? DbNullValue); // DN
            row.Add("Region", Region.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("PosisiAwal", PosisiAwal.DefaultValue ?? DbNullValue); // DN
            row.Add("PosisiPJS", PosisiPJS.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPosition", LookupPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalMulai", TanggalMulai.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalSelesai", TanggalSelesai.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadSuratTugas", DownloadSuratTugas.DefaultValue ?? DbNullValue); // DN
            row.Add("SuratTugas", SuratTugas.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("Remaks", Remaks.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaharuiOleh", DiperbaharuiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaharuiTanggal", DiperbaharuiTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantAwal", PlantAwal.DefaultValue ?? DbNullValue); // DN
            row.Add("RegionAwal", RegionAwal.DefaultValue ?? DbNullValue); // DN
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

            // Id
            Id.RowCssClass = "row";

            // NomorPjs
            NomorPjs.RowCssClass = "row";

            // RedirectLink
            RedirectLink.RowCssClass = "row";

            // Nama
            Nama.RowCssClass = "row";

            // OrganizationLevel
            OrganizationLevel.RowCssClass = "row";

            // Region
            Region.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // PosisiAwal
            PosisiAwal.RowCssClass = "row";

            // PosisiPJS
            PosisiPJS.RowCssClass = "row";

            // LookupPosition
            LookupPosition.RowCssClass = "row";

            // TanggalMulai
            TanggalMulai.RowCssClass = "row";

            // TanggalSelesai
            TanggalSelesai.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // DownloadSuratTugas
            DownloadSuratTugas.RowCssClass = "row";

            // SuratTugas
            SuratTugas.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // Remaks
            Remaks.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaharuiOleh
            DiperbaharuiOleh.RowCssClass = "row";

            // DiperbaharuiTanggal
            DiperbaharuiTanggal.RowCssClass = "row";

            // PlantAwal
            PlantAwal.RowCssClass = "row";

            // RegionAwal
            RegionAwal.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // NomorPjs

                // RedirectLink

                // Nama

                // OrganizationLevel

                // Region

                // Plant

                // PosisiAwal

                // PosisiPJS

                // LookupPosition

                // TanggalMulai

                // TanggalSelesai

                // Status

                // DownloadSuratTugas

                // SuratTugas

                // Keterangan

                // Remaks

                // DibuatOleh

                // TanggalDibuat

                // DiperbaharuiOleh

                // DiperbaharuiTanggal

                // PlantAwal

                // RegionAwal

                    // Id
                    Id.ViewValue = Id.CurrentValue;
                    Id.ViewCustomAttributes = "";

                    // NomorPjs
                    NomorPjs.ViewValue = ConvertToString(NomorPjs.CurrentValue); // DN
                    NomorPjs.ViewCustomAttributes = "";

                    // RedirectLink
                    RedirectLink.ViewValue = ConvertToString(RedirectLink.CurrentValue); // DN
                    RedirectLink.ViewCustomAttributes = "";

                    // Nama
                    Nama.ViewValue = ConvertToString(Nama.CurrentValue); // DN
                    Nama.ViewCustomAttributes = "";

                    // OrganizationLevel
                    if (!Empty(OrganizationLevel.CurrentValue)) {
                        OrganizationLevel.ViewValue = OrganizationLevel.OptionCaption(ConvertToString(OrganizationLevel.CurrentValue));
                    } else {
                        OrganizationLevel.ViewValue = DbNullValue;
                    }
                    OrganizationLevel.ViewCustomAttributes = "";

                    // Region

                    // awallookupbung
                    // Region (jaga leading zero)
                    ResolveLookupView(Region, "IdRegion", "string");
                    // akhirlookupbung
                    Region.ViewCustomAttributes = "";

                    // Plant

                    // awallookupbung
                    // Plant (jaga leading zero)
                    ResolveLookupView(Plant, "IdPlant", "string");
                    // akhirlookupbung
                    Plant.ViewCustomAttributes = "";

                    // PosisiAwal
                    PosisiAwal.ViewValue = PosisiAwal.CurrentValue;

                    // awallookupbung
                    // PosisiAwal (jaga leading zero)
                    ResolveLookupView(PosisiAwal, "IdPosition", "string");
                    // akhirlookupbung
                    PosisiAwal.ViewCustomAttributes = "";

                    // PosisiPJS
                    PosisiPJS.ViewValue = PosisiPJS.CurrentValue;

                    // awallookupbung
                    // PosisiPJS (jaga leading zero)
                    ResolveLookupView(PosisiPJS, "IdPosition", "string");
                    // akhirlookupbung
                    PosisiPJS.ViewCustomAttributes = "";

                    // LookupPosition
                    if (!Empty(LookupPosition.CurrentValue)) {
                        LookupPosition.ViewValue = LookupPosition.OptionCaption(ConvertToString(LookupPosition.CurrentValue));
                    } else {
                        LookupPosition.ViewValue = DbNullValue;
                    }
                    LookupPosition.ViewCustomAttributes = "";

                    // TanggalMulai
                    TanggalMulai.ViewValue = TanggalMulai.CurrentValue;
                    TanggalMulai.ViewValue = FormatDateTime(TanggalMulai.ViewValue, TanggalMulai.FormatPattern);
                    TanggalMulai.ViewCustomAttributes = "";

                    // TanggalSelesai
                    TanggalSelesai.ViewValue = TanggalSelesai.CurrentValue;
                    TanggalSelesai.ViewValue = FormatDateTime(TanggalSelesai.ViewValue, TanggalSelesai.FormatPattern);
                    TanggalSelesai.ViewCustomAttributes = "";

                    // Status
                    Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                    Status.ViewCustomAttributes = "";

                    // DownloadSuratTugas
                    DownloadSuratTugas.ViewValue = ConvertToString(DownloadSuratTugas.CurrentValue); // DN
                    DownloadSuratTugas.ViewCustomAttributes = "";

                    // SuratTugas
                    SuratTugas.ViewValue = ConvertToString(SuratTugas.CurrentValue); // DN
                    SuratTugas.ViewCustomAttributes = "";

                    // Keterangan
                    Keterangan.ViewValue = Keterangan.CurrentValue;
                    Keterangan.ViewCustomAttributes = "";

                    // Remaks
                    Remaks.ViewValue = Remaks.CurrentValue;
                    Remaks.ViewCustomAttributes = "";

                    // DibuatOleh
                    DibuatOleh.ViewValue = DibuatOleh.CurrentValue;

                    // awallookupbung
                    // DibuatOleh (jaga leading zero)
                    ResolveLookupView(DibuatOleh, "IdUser", "string");
                    // akhirlookupbung
                    DibuatOleh.ViewCustomAttributes = "";

                    // TanggalDibuat
                    TanggalDibuat.ViewValue = TanggalDibuat.CurrentValue;
                    TanggalDibuat.ViewValue = FormatDateTime(TanggalDibuat.ViewValue, TanggalDibuat.FormatPattern);
                    TanggalDibuat.ViewCustomAttributes = "";

                    // DiperbaharuiOleh
                    DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.CurrentValue;

                    // awallookupbung
                    // DiperbaharuiOleh (jaga leading zero)
                    ResolveLookupView(DiperbaharuiOleh, "IdUser", "string");
                    // akhirlookupbung
                    DiperbaharuiOleh.ViewCustomAttributes = "";

                    // DiperbaharuiTanggal
                    DiperbaharuiTanggal.ViewValue = DiperbaharuiTanggal.CurrentValue;
                    DiperbaharuiTanggal.ViewValue = FormatDateTime(DiperbaharuiTanggal.ViewValue, DiperbaharuiTanggal.FormatPattern);
                    DiperbaharuiTanggal.ViewCustomAttributes = "";

                    // PlantAwal
                    PlantAwal.ViewValue = PlantAwal.CurrentValue;
                    PlantAwal.ViewCustomAttributes = "";

                    // RegionAwal
                    RegionAwal.ViewValue = RegionAwal.CurrentValue;
                    RegionAwal.ViewValue = FormatNumber(RegionAwal.ViewValue, RegionAwal.FormatPattern);
                    RegionAwal.ViewCustomAttributes = "";

                // Id
                Id.HrefValue = "";

                // NomorPjs
                NomorPjs.HrefValue = "";
                NomorPjs.TooltipValue = "";

                // RedirectLink
                RedirectLink.HrefValue = "";

                // Nama
                Nama.HrefValue = "";

                // OrganizationLevel
                OrganizationLevel.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // PosisiAwal
                PosisiAwal.HrefValue = "";

                // PosisiPJS
                PosisiPJS.HrefValue = "";

                // LookupPosition
                LookupPosition.HrefValue = "";

                // TanggalMulai
                TanggalMulai.HrefValue = "";

                // TanggalSelesai
                TanggalSelesai.HrefValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // DownloadSuratTugas
                DownloadSuratTugas.HrefValue = "";
                DownloadSuratTugas.TooltipValue = "";

                // SuratTugas
                SuratTugas.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // Remaks
                Remaks.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // DiperbaharuiOleh
                DiperbaharuiOleh.HrefValue = "";
                DiperbaharuiOleh.TooltipValue = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.HrefValue = "";
                DiperbaharuiTanggal.TooltipValue = "";

                // PlantAwal
                PlantAwal.HrefValue = "";

                // RegionAwal
                RegionAwal.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // Id
                Id.SetupEditAttributes();
                Id.EditValue = Id.CurrentValue;
                Id.ViewCustomAttributes = "";

                // NomorPjs
                NomorPjs.SetupEditAttributes();
                NomorPjs.EditValue = ConvertToString(NomorPjs.CurrentValue); // DN
                NomorPjs.ViewCustomAttributes = "";

                // RedirectLink
                RedirectLink.SetupEditAttributes();
                if (!RedirectLink.Raw)
                    RedirectLink.CurrentValue = HtmlDecode(RedirectLink.CurrentValue);
                RedirectLink.EditValue = HtmlEncode(RedirectLink.CurrentValue);
                RedirectLink.PlaceHolder = RemoveHtml(RedirectLink.Caption);

                // Nama
                Nama.SetupEditAttributes();
                if (!Nama.Raw)
                    Nama.CurrentValue = HtmlDecode(Nama.CurrentValue);
                Nama.EditValue = HtmlEncode(Nama.CurrentValue);
                Nama.PlaceHolder = RemoveHtml(Nama.Caption);

                // OrganizationLevel
                OrganizationLevel.SetupEditAttributes();
                OrganizationLevel.EditValue = OrganizationLevel.Options(true);
                OrganizationLevel.PlaceHolder = RemoveHtml(OrganizationLevel.Caption);

                // Region
                Region.SetupEditAttributes();
                string curVal2 = ConvertToString(Region.CurrentValue);
                if (Region.Lookup != null && IsDictionary(Region.Lookup?.Options) && Region.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Region.EditValue = Region.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk2 = "";
                    if (curVal2 == "") {
                        filterWrk2 = "0=1";
                    } else {
                        filterWrk2 = SearchFilter(Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchExpression, "=", Region.CurrentValue, Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchDataType, "");
                    }
                    string? sqlWrk2 = Region.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Region.EditValue = rswrk2;
                }
                Region.PlaceHolder = RemoveHtml(Region.Caption);

                // Plant
                Plant.SetupEditAttributes();
                string curVal3 = ConvertToString(Plant.CurrentValue);
                if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Plant.EditValue = Plant.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk3 = "";
                    if (curVal3 == "") {
                        filterWrk3 = "0=1";
                    } else {
                        filterWrk3 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk3 = Plant.Lookup?.GetSql(true, filterWrk3, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Plant.EditValue = rswrk3;
                }
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);

                // PosisiAwal
                PosisiAwal.SetupEditAttributes();
                PosisiAwal.EditValue = PosisiAwal.CurrentValue;

                // awallookupbung
                string curVal4 = ConvertToString(PosisiAwal.CurrentValue);
                PosisiAwal.EditValue = Empty(curVal4) ? DbNullValue : HtmlEncode(PosisiAwal.CurrentValue);
                if (!Empty(curVal4)) {
                    if (PosisiAwal.Lookup != null && IsDictionary(PosisiAwal.Lookup?.Options) && PosisiAwal.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PosisiAwal.EditValue = PosisiAwal.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(PosisiAwal.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", PosisiAwal.CurrentValue, PosisiAwal.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk4 = PosisiAwal.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && PosisiAwal.Lookup != null) { // Lookup values found
                            var listwrk = PosisiAwal.Lookup?.RenderViewRow(rswrk4[0]);
                            PosisiAwal.EditValue = PosisiAwal.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                PosisiAwal.PlaceHolder = RemoveHtml(PosisiAwal.Caption);

                // PosisiPJS
                PosisiPJS.SetupEditAttributes();
                PosisiPJS.EditValue = PosisiPJS.CurrentValue;

                // awallookupbung
                string curVal5 = ConvertToString(PosisiPJS.CurrentValue);
                PosisiPJS.EditValue = Empty(curVal5) ? DbNullValue : HtmlEncode(PosisiPJS.CurrentValue);
                if (!Empty(curVal5)) {
                    if (PosisiPJS.Lookup != null && IsDictionary(PosisiPJS.Lookup?.Options) && PosisiPJS.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PosisiPJS.EditValue = PosisiPJS.LookupCacheOption(curVal5);
                    } else { // Lookup from database // DN
                        string filterWrk5 = SearchFilter(PosisiPJS.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", PosisiPJS.CurrentValue, PosisiPJS.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk5 = PosisiPJS.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk5?.Count > 0 && PosisiPJS.Lookup != null) { // Lookup values found
                            var listwrk = PosisiPJS.Lookup?.RenderViewRow(rswrk5[0]);
                            PosisiPJS.EditValue = PosisiPJS.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                PosisiPJS.PlaceHolder = RemoveHtml(PosisiPJS.Caption);

                // LookupPosition
                LookupPosition.SetupEditAttributes();
                LookupPosition.EditValue = LookupPosition.Options(true);
                LookupPosition.PlaceHolder = RemoveHtml(LookupPosition.Caption);

                // TanggalMulai
                TanggalMulai.SetupEditAttributes();
                TanggalMulai.EditValue = FormatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
                TanggalMulai.PlaceHolder = RemoveHtml(TanggalMulai.Caption);

                // TanggalSelesai
                TanggalSelesai.SetupEditAttributes();
                TanggalSelesai.EditValue = FormatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
                TanggalSelesai.PlaceHolder = RemoveHtml(TanggalSelesai.Caption);

                // Status
                Status.SetupEditAttributes();
                Status.EditValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // DownloadSuratTugas
                DownloadSuratTugas.SetupEditAttributes();
                DownloadSuratTugas.EditValue = ConvertToString(DownloadSuratTugas.CurrentValue); // DN
                DownloadSuratTugas.ViewCustomAttributes = "";

                // SuratTugas
                SuratTugas.SetupEditAttributes();
                if (!SuratTugas.Raw)
                    SuratTugas.CurrentValue = HtmlDecode(SuratTugas.CurrentValue);
                SuratTugas.EditValue = HtmlEncode(SuratTugas.CurrentValue);
                SuratTugas.PlaceHolder = RemoveHtml(SuratTugas.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // Remaks
                Remaks.SetupEditAttributes();
                Remaks.EditValue = Remaks.CurrentValue; // DN
                Remaks.PlaceHolder = RemoveHtml(Remaks.Caption);

                // DibuatOleh
                DibuatOleh.SetupEditAttributes();
                DibuatOleh.EditValue = DibuatOleh.CurrentValue;

                // awallookupbung
                string curVal7 = ConvertToString(DibuatOleh.CurrentValue);
                DibuatOleh.EditValue = Empty(curVal7) ? DbNullValue : HtmlEncode(DibuatOleh.CurrentValue);
                if (!Empty(curVal7)) {
                    if (DibuatOleh.Lookup != null && IsDictionary(DibuatOleh.Lookup?.Options) && DibuatOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        DibuatOleh.EditValue = DibuatOleh.LookupCacheOption(curVal7);
                    } else { // Lookup from database // DN
                        string filterWrk7 = SearchFilter(DibuatOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DibuatOleh.CurrentValue, DibuatOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                        string? sqlWrk7 = DibuatOleh.Lookup?.GetSql(false, filterWrk7, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk7?.Count > 0 && DibuatOleh.Lookup != null) { // Lookup values found
                            var listwrk = DibuatOleh.Lookup?.RenderViewRow(rswrk7[0]);
                            DibuatOleh.EditValue = DibuatOleh.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                DibuatOleh.PlaceHolder = RemoveHtml(DibuatOleh.Caption);

                // TanggalDibuat
                TanggalDibuat.SetupEditAttributes();
                TanggalDibuat.EditValue = FormatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
                TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);

                // DiperbaharuiOleh
                DiperbaharuiOleh.SetupEditAttributes();
                DiperbaharuiOleh.EditValue = DiperbaharuiOleh.CurrentValue;

                // awallookupbung
                string curVal8 = ConvertToString(DiperbaharuiOleh.CurrentValue);
                DiperbaharuiOleh.EditValue = Empty(curVal8) ? DbNullValue : DiperbaharuiOleh.CurrentValue;
                if (!Empty(curVal8)) {
                    if (DiperbaharuiOleh.Lookup != null && IsDictionary(DiperbaharuiOleh.Lookup?.Options) && DiperbaharuiOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        DiperbaharuiOleh.EditValue = DiperbaharuiOleh.LookupCacheOption(curVal8);
                    } else { // Lookup from database // DN
                        string filterWrk8 = SearchFilter(DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DiperbaharuiOleh.CurrentValue, DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                        string? sqlWrk8 = DiperbaharuiOleh.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk8?.Count > 0 && DiperbaharuiOleh.Lookup != null) { // Lookup values found
                            var listwrk = DiperbaharuiOleh.Lookup?.RenderViewRow(rswrk8[0]);
                            DiperbaharuiOleh.EditValue = DiperbaharuiOleh.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                DiperbaharuiOleh.ViewCustomAttributes = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.SetupEditAttributes();
                DiperbaharuiTanggal.EditValue = DiperbaharuiTanggal.CurrentValue;
                DiperbaharuiTanggal.EditValue = FormatDateTime(DiperbaharuiTanggal.EditValue, DiperbaharuiTanggal.FormatPattern);
                DiperbaharuiTanggal.ViewCustomAttributes = "";

                // PlantAwal
                PlantAwal.SetupEditAttributes();
                PlantAwal.EditValue = PlantAwal.CurrentValue;
                PlantAwal.PlaceHolder = RemoveHtml(PlantAwal.Caption);

                // RegionAwal
                RegionAwal.SetupEditAttributes();
                RegionAwal.EditValue = RegionAwal.CurrentValue;
                RegionAwal.PlaceHolder = RemoveHtml(RegionAwal.Caption);
                if (!Empty(RegionAwal.EditValue) && IsNumeric(RegionAwal.EditValue))
                    RegionAwal.EditValue = FormatNumber(RegionAwal.EditValue, null);

                // Edit refer script

                // Id
                Id.HrefValue = "";

                // NomorPjs
                NomorPjs.HrefValue = "";
                NomorPjs.TooltipValue = "";

                // RedirectLink
                RedirectLink.HrefValue = "";

                // Nama
                Nama.HrefValue = "";

                // OrganizationLevel
                OrganizationLevel.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // PosisiAwal
                PosisiAwal.HrefValue = "";

                // PosisiPJS
                PosisiPJS.HrefValue = "";

                // LookupPosition
                LookupPosition.HrefValue = "";

                // TanggalMulai
                TanggalMulai.HrefValue = "";

                // TanggalSelesai
                TanggalSelesai.HrefValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // DownloadSuratTugas
                DownloadSuratTugas.HrefValue = "";
                DownloadSuratTugas.TooltipValue = "";

                // SuratTugas
                SuratTugas.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // Remaks
                Remaks.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // DiperbaharuiOleh
                DiperbaharuiOleh.HrefValue = "";
                DiperbaharuiOleh.TooltipValue = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.HrefValue = "";
                DiperbaharuiTanggal.TooltipValue = "";

                // PlantAwal
                PlantAwal.HrefValue = "";

                // RegionAwal
                RegionAwal.HrefValue = "";
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

        private void ValidateCustomId() {
            if (Id.Visible && Id.Required) {
                if (!Id.IsDetailKey && Empty(Id.FormValue)) {
                    Id.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomNomorPjs() {
            if (NomorPjs.Visible && NomorPjs.Required) {
                if (!NomorPjs.IsDetailKey && Empty(NomorPjs.FormValue)) {
                    NomorPjs.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomRedirectLink() {
            if (RedirectLink.Visible && RedirectLink.Required) {
                if (!RedirectLink.IsDetailKey && Empty(RedirectLink.FormValue)) {
                    RedirectLink.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomNama() {
            if (Nama.Visible && Nama.Required) {
                if (!Nama.IsDetailKey && Empty(Nama.FormValue)) {
                    Nama.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomOrganizationLevel() {
            if (OrganizationLevel.Visible && OrganizationLevel.Required) {
                if (!OrganizationLevel.IsDetailKey && Empty(OrganizationLevel.FormValue)) {
                    OrganizationLevel.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomRegion() {
            if (Region.Visible && Region.Required) {
                if (!Region.IsDetailKey && Empty(Region.FormValue)) {
                    Region.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomPlant() {
            if (Plant.Visible && Plant.Required) {
                if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                    Plant.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomPosisiAwal() {
            if (PosisiAwal.Visible && PosisiAwal.Required) {
                if (!PosisiAwal.IsDetailKey && Empty(PosisiAwal.FormValue)) {
                    PosisiAwal.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomPosisiPJS() {
            if (PosisiPJS.Visible && PosisiPJS.Required) {
                if (!PosisiPJS.IsDetailKey && Empty(PosisiPJS.FormValue)) {
                    PosisiPJS.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomLookupPosition() {
            if (LookupPosition.Visible && LookupPosition.Required) {
                if (!LookupPosition.IsDetailKey && Empty(LookupPosition.FormValue)) {
                    LookupPosition.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomTanggalMulai() {
            if (TanggalMulai.Visible && TanggalMulai.Required) {
                if (!TanggalMulai.IsDetailKey && Empty(TanggalMulai.FormValue)) {
                    TanggalMulai.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomTanggalSelesai() {
            if (TanggalSelesai.Visible && TanggalSelesai.Required) {
                if (!TanggalSelesai.IsDetailKey && Empty(TanggalSelesai.FormValue)) {
                    TanggalSelesai.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomStatus() {
            if (Status.Visible && Status.Required) {
                if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                    Status.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomDownloadSuratTugas() {
            if (DownloadSuratTugas.Visible && DownloadSuratTugas.Required) {
                if (!DownloadSuratTugas.IsDetailKey && Empty(DownloadSuratTugas.FormValue)) {
                    DownloadSuratTugas.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomSuratTugas() {
            if (SuratTugas.Visible && SuratTugas.Required) {
                if (!SuratTugas.IsDetailKey && Empty(SuratTugas.FormValue)) {
                    SuratTugas.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomKeterangan() {
            if (Keterangan.Visible && Keterangan.Required) {
                if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                    Keterangan.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomRemaks() {
            if (Remaks.Visible && Remaks.Required) {
                if (!Remaks.IsDetailKey && Empty(Remaks.FormValue)) {
                    Remaks.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomDibuatOleh() {
            if (DibuatOleh.Visible && DibuatOleh.Required) {
                if (!DibuatOleh.IsDetailKey && Empty(DibuatOleh.FormValue)) {
                    DibuatOleh.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomTanggalDibuat() {
            if (TanggalDibuat.Visible && TanggalDibuat.Required) {
                if (!TanggalDibuat.IsDetailKey && Empty(TanggalDibuat.FormValue)) {
                    TanggalDibuat.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomDiperbaharuiOleh() {
            if (DiperbaharuiOleh.Visible && DiperbaharuiOleh.Required) {
                if (!DiperbaharuiOleh.IsDetailKey && Empty(DiperbaharuiOleh.FormValue)) {
                    DiperbaharuiOleh.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomDiperbaharuiTanggal() {
            if (DiperbaharuiTanggal.Visible && DiperbaharuiTanggal.Required) {
                if (!DiperbaharuiTanggal.IsDetailKey && Empty(DiperbaharuiTanggal.FormValue)) {
                    DiperbaharuiTanggal.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomPlantAwal() {
            if (PlantAwal.Visible && PlantAwal.Required) {
                if (!PlantAwal.IsDetailKey && Empty(PlantAwal.FormValue)) {
                    PlantAwal.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        private void ValidateCustomRegionAwal() {
            if (RegionAwal.Visible && RegionAwal.Required) {
                if (!RegionAwal.IsDetailKey && Empty(RegionAwal.FormValue)) {
                    RegionAwal.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomId();
                ValidateCustomNomorPjs();
                ValidateCustomRedirectLink();
                ValidateCustomNama();
                ValidateCustomOrganizationLevel();
                ValidateCustomRegion();
                ValidateCustomPlant();
                ValidateCustomPosisiAwal();
                ValidateCustomPosisiPJS();
                ValidateCustomLookupPosition();
                ValidateCustomTanggalMulai();
                if (!CheckDate(TanggalMulai.FormValue, TanggalMulai.FormatPattern)) {
                    TanggalMulai.AddErrorMessage(TanggalMulai.GetErrorMessage(false));
                }
                ValidateCustomTanggalSelesai();
                if (!CheckDate(TanggalSelesai.FormValue, TanggalSelesai.FormatPattern)) {
                    TanggalSelesai.AddErrorMessage(TanggalSelesai.GetErrorMessage(false));
                }
                ValidateCustomStatus();
                ValidateCustomDownloadSuratTugas();
                ValidateCustomSuratTugas();
                ValidateCustomKeterangan();
                ValidateCustomRemaks();
                ValidateCustomDibuatOleh();
                ValidateCustomTanggalDibuat();
                if (!CheckDate(TanggalDibuat.FormValue, TanggalDibuat.FormatPattern)) {
                    TanggalDibuat.AddErrorMessage(TanggalDibuat.GetErrorMessage(false));
                }
                ValidateCustomDiperbaharuiOleh();
                ValidateCustomDiperbaharuiTanggal();
                ValidateCustomPlantAwal();
                ValidateCustomRegionAwal();
                if (!CheckInteger(RegionAwal.FormValue)) {
                    RegionAwal.AddErrorMessage(RegionAwal.GetErrorMessage(false));
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

            // RedirectLink
            RedirectLink.SetDbValue(rsnew, RedirectLink.CurrentValue, RedirectLink.ReadOnly);

            // Nama
            Nama.SetDbValue(rsnew, Nama.CurrentValue, Nama.ReadOnly);

            // OrganizationLevel
            OrganizationLevel.SetDbValue(rsnew, OrganizationLevel.CurrentValue, OrganizationLevel.ReadOnly);

            // Region
            Region.SetDbValue(rsnew, Region.CurrentValue, Region.ReadOnly);

            // Plant
            Plant.SetDbValue(rsnew, Plant.CurrentValue, Plant.ReadOnly);

            // PosisiAwal
            PosisiAwal.SetDbValue(rsnew, PosisiAwal.CurrentValue, PosisiAwal.ReadOnly);

            // PosisiPJS
            PosisiPJS.SetDbValue(rsnew, PosisiPJS.CurrentValue, PosisiPJS.ReadOnly);

            // LookupPosition
            LookupPosition.SetDbValue(rsnew, LookupPosition.CurrentValue, LookupPosition.ReadOnly);

            // TanggalMulai
            TanggalMulai.SetDbValue(rsnew, ConvertToDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern), TanggalMulai.ReadOnly);

            // TanggalSelesai
            TanggalSelesai.SetDbValue(rsnew, ConvertToDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern), TanggalSelesai.ReadOnly);

            // SuratTugas
            SuratTugas.SetDbValue(rsnew, SuratTugas.CurrentValue, SuratTugas.ReadOnly);

            // Keterangan
            Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue, Keterangan.ReadOnly);

            // Remaks
            Remaks.SetDbValue(rsnew, Remaks.CurrentValue, Remaks.ReadOnly);

            // DibuatOleh
            DibuatOleh.SetDbValue(rsnew, DibuatOleh.CurrentValue, DibuatOleh.ReadOnly);

            // TanggalDibuat
            TanggalDibuat.SetDbValue(rsnew, ConvertToDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern), TanggalDibuat.ReadOnly);

            // PlantAwal
            PlantAwal.SetDbValue(rsnew, PlantAwal.CurrentValue, PlantAwal.ReadOnly);

            // RegionAwal
            RegionAwal.SetDbValue(rsnew, RegionAwal.CurrentValue, RegionAwal.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("RedirectLink", out value)) // RedirectLink
                RedirectLink.CurrentValue = value;
            if (row.TryGetValue("Nama", out value)) // Nama
                Nama.CurrentValue = value;
            if (row.TryGetValue("OrganizationLevel", out value)) // OrganizationLevel
                OrganizationLevel.CurrentValue = value;
            if (row.TryGetValue("Region", out value)) // Region
                Region.CurrentValue = value;
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.CurrentValue = value;
            if (row.TryGetValue("PosisiAwal", out value)) // PosisiAwal
                PosisiAwal.CurrentValue = value;
            if (row.TryGetValue("PosisiPJS", out value)) // PosisiPJS
                PosisiPJS.CurrentValue = value;
            if (row.TryGetValue("LookupPosition", out value)) // LookupPosition
                LookupPosition.CurrentValue = value;
            if (row.TryGetValue("TanggalMulai", out value)) // TanggalMulai
                TanggalMulai.CurrentValue = value;
            if (row.TryGetValue("TanggalSelesai", out value)) // TanggalSelesai
                TanggalSelesai.CurrentValue = value;
            if (row.TryGetValue("SuratTugas", out value)) // SuratTugas
                SuratTugas.CurrentValue = value;
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.CurrentValue = value;
            if (row.TryGetValue("Remaks", out value)) // Remaks
                Remaks.CurrentValue = value;
            if (row.TryGetValue("DibuatOleh", out value)) // DibuatOleh
                DibuatOleh.CurrentValue = value;
            if (row.TryGetValue("TanggalDibuat", out value)) // TanggalDibuat
                TanggalDibuat.CurrentValue = value;
            if (row.TryGetValue("PlantAwal", out value)) // PlantAwal
                PlantAwal.CurrentValue = value;
            if (row.TryGetValue("RegionAwal", out value)) // RegionAwal
                RegionAwal.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SetPjsList")), "", TableVar, true);
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
