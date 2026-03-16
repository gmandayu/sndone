using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasInputDataRtwEdit
    /// </summary>
    public static SubAktivitasInputDataRtwEdit subAktivitasInputDataRtwEdit
    {
        get => HttpData.Get<SubAktivitasInputDataRtwEdit>("subAktivitasInputDataRtwEdit")!;
        set => HttpData["subAktivitasInputDataRtwEdit"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasInputDataRTW
    /// </summary>
    public class SubAktivitasInputDataRtwEdit : SubAktivitasInputDataRtwEditBase
    {
        // Constructor
        public SubAktivitasInputDataRtwEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasInputDataRtwEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasInputDataRtwEditBase : SubAktivitasInputDataRtw
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasInputDataRtwEdit";

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
        public SubAktivitasInputDataRtwEditBase(Controller? controller)
        {
            TableName = "SubAktivitasInputDataRTW";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasInputDataRtw)
            if (subAktivitasInputDataRtw == null || subAktivitasInputDataRtw is SubAktivitasInputDataRtw)
                subAktivitasInputDataRtw = this;

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
        public string PageName => "SubAktivitasInputDataRtwEdit";

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
            Produk.SetVisibility();
            StatusAktivitas.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            NomorGerbongKertel.SetVisibility();
            MeterAwal.SetVisibility();
            MeterAkhir.SetVisibility();
            Total.SetVisibility();
            userInput.Visible = false;
            etlDate.Visible = false;
            NoMeter.SetVisibility();
            Quantity.SetVisibility();
            HasilPengukuranT2.SetVisibility();
            PICPengisian.SetVisibility();
            NomorGerbongKertel2.SetVisibility();
            NomorGerbongKertel3.SetVisibility();
            Quantity2.SetVisibility();
            Quantity3.SetVisibility();
            HasilPengukuranT2_2.SetVisibility();
            HasilPengukuranT2_3.SetVisibility();
            TotalGK.SetVisibility();
            Selisih.SetVisibility();
        }

        // Constructor
        public SubAktivitasInputDataRtwEditBase() : this(null) { }

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
                        result.Add("view", pageName == "SubAktivitasInputDataRtwView" ? "1" : "0"); // If View page, no primary button
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
                return Terminate("SubAktivitasInputDataRtwList");
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
                    if (GetPageName(returnUrl) != "SubAktivitasInputDataRtwList") {
                        TempData["Return-Url"] = returnUrl;
                        returnUrl = "SubAktivitasInputDataRtwList";
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
            if (GetPageName(returnUrl) == "SubAktivitasInputDataRtwList")
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
                    await SetupLookupOptions(idAktifitas);
                    await SetupLookupOptions(idProses);
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
                        subAktivitasInputDataRtwEdit?.PageRender();
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

            // Standard handling for 'idAktifitas'
            idAktifitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idAktifitas, "idAktifitas", "x_idAktifitas");

            // Standard handling for 'idProses'
            idProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(idProses, "idProses", "x_idProses");

            // Standard handling for 'NoReferensi'
            NoReferensi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NoReferensi, "NoReferensi", "x_NoReferensi");

            // Standard handling for 'Produk'
            Produk.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Produk, "Produk", "x_Produk");

            // Standard handling for 'StatusAktivitas'
            StatusAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(StatusAktivitas, "StatusAktivitas", "x_StatusAktivitas");

            // Standard handling for 'LastUpdatedBy'
            LastUpdatedBy.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LastUpdatedBy, "LastUpdatedBy", "x_LastUpdatedBy");

            // Standard handling for 'lastUpdatedDate'
            lastUpdatedDate.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(lastUpdatedDate, "lastUpdatedDate", "x_lastUpdatedDate", false, false, true);

            // Standard handling for 'NomorGerbongKertel'
            NomorGerbongKertel.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NomorGerbongKertel, "NomorGerbongKertel", "x_NomorGerbongKertel");

            // Standard handling for 'MeterAwal'
            MeterAwal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(MeterAwal, "MeterAwal", "x_MeterAwal");

            // Standard handling for 'MeterAkhir'
            MeterAkhir.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(MeterAkhir, "MeterAkhir", "x_MeterAkhir");

            // Standard handling for 'Total'
            Total.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Total, "Total", "x_Total");

            // Standard handling for 'NoMeter'
            NoMeter.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NoMeter, "NoMeter", "x_NoMeter");

            // Standard handling for 'Quantity'
            Quantity.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Quantity, "Quantity", "x_Quantity");

            // Standard handling for 'HasilPengukuranT2'
            HasilPengukuranT2.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(HasilPengukuranT2, "HasilPengukuranT2", "x_HasilPengukuranT2");

            // Standard handling for 'PICPengisian'
            PICPengisian.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PICPengisian, "PICPengisian", "x_PICPengisian");

            // Standard handling for 'NomorGerbongKertel2'
            NomorGerbongKertel2.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NomorGerbongKertel2, "NomorGerbongKertel2", "x_NomorGerbongKertel2");

            // Standard handling for 'NomorGerbongKertel3'
            NomorGerbongKertel3.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NomorGerbongKertel3, "NomorGerbongKertel3", "x_NomorGerbongKertel3");

            // Standard handling for 'Quantity2'
            Quantity2.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Quantity2, "Quantity2", "x_Quantity2");

            // Standard handling for 'Quantity3'
            Quantity3.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Quantity3, "Quantity3", "x_Quantity3");

            // Standard handling for 'HasilPengukuranT2_2'
            HasilPengukuranT2_2.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(HasilPengukuranT2_2, "HasilPengukuranT2_2", "x_HasilPengukuranT2_2");

            // Standard handling for 'HasilPengukuranT2_3'
            HasilPengukuranT2_3.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(HasilPengukuranT2_3, "HasilPengukuranT2_3", "x_HasilPengukuranT2_3");

            // Standard handling for 'TotalGK'
            TotalGK.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TotalGK, "TotalGK", "x_TotalGK");

            // Standard handling for 'Selisih'
            Selisih.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Selisih, "Selisih", "x_Selisih");
            if (!id.IsDetailKey) {
                SetNormalField(id, "id", "x_id");
            }
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            id.CurrentValue = id.FormValue;
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            Produk.CurrentValue = Produk.FormValue;
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            NomorGerbongKertel.CurrentValue = NomorGerbongKertel.FormValue;
            MeterAwal.CurrentValue = MeterAwal.FormValue;
            MeterAkhir.CurrentValue = MeterAkhir.FormValue;
            Total.CurrentValue = Total.FormValue;
            NoMeter.CurrentValue = NoMeter.FormValue;
            Quantity.CurrentValue = Quantity.FormValue;
            HasilPengukuranT2.CurrentValue = HasilPengukuranT2.FormValue;
            PICPengisian.CurrentValue = PICPengisian.FormValue;
            NomorGerbongKertel2.CurrentValue = NomorGerbongKertel2.FormValue;
            NomorGerbongKertel3.CurrentValue = NomorGerbongKertel3.FormValue;
            Quantity2.CurrentValue = Quantity2.FormValue;
            Quantity3.CurrentValue = Quantity3.FormValue;
            HasilPengukuranT2_2.CurrentValue = HasilPengukuranT2_2.FormValue;
            HasilPengukuranT2_3.CurrentValue = HasilPengukuranT2_3.FormValue;
            TotalGK.CurrentValue = TotalGK.FormValue;
            Selisih.CurrentValue = Selisih.FormValue;
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
            Produk.SetDbValue(row["Produk"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            NomorGerbongKertel.SetDbValue(row["NomorGerbongKertel"]);
            MeterAwal.SetDbValue(row["MeterAwal"]);
            MeterAkhir.SetDbValue(row["MeterAkhir"]);
            Total.SetDbValue(row["Total"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            NoMeter.SetDbValue(row["NoMeter"]);
            Quantity.SetDbValue(row["Quantity"]);
            HasilPengukuranT2.SetDbValue(row["HasilPengukuranT2"]);
            PICPengisian.SetDbValue(row["PICPengisian"]);
            NomorGerbongKertel2.SetDbValue(row["NomorGerbongKertel2"]);
            NomorGerbongKertel3.SetDbValue(row["NomorGerbongKertel3"]);
            Quantity2.SetDbValue(row["Quantity2"]);
            Quantity3.SetDbValue(row["Quantity3"]);
            HasilPengukuranT2_2.SetDbValue(row["HasilPengukuranT2_2"]);
            HasilPengukuranT2_3.SetDbValue(row["HasilPengukuranT2_3"]);
            TotalGK.SetDbValue(row["TotalGK"]);
            Selisih.SetDbValue(row["Selisih"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("Produk", Produk.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorGerbongKertel", NomorGerbongKertel.DefaultValue ?? DbNullValue); // DN
            row.Add("MeterAwal", MeterAwal.DefaultValue ?? DbNullValue); // DN
            row.Add("MeterAkhir", MeterAkhir.DefaultValue ?? DbNullValue); // DN
            row.Add("Total", Total.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("NoMeter", NoMeter.DefaultValue ?? DbNullValue); // DN
            row.Add("Quantity", Quantity.DefaultValue ?? DbNullValue); // DN
            row.Add("HasilPengukuranT2", HasilPengukuranT2.DefaultValue ?? DbNullValue); // DN
            row.Add("PICPengisian", PICPengisian.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorGerbongKertel2", NomorGerbongKertel2.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorGerbongKertel3", NomorGerbongKertel3.DefaultValue ?? DbNullValue); // DN
            row.Add("Quantity2", Quantity2.DefaultValue ?? DbNullValue); // DN
            row.Add("Quantity3", Quantity3.DefaultValue ?? DbNullValue); // DN
            row.Add("HasilPengukuranT2_2", HasilPengukuranT2_2.DefaultValue ?? DbNullValue); // DN
            row.Add("HasilPengukuranT2_3", HasilPengukuranT2_3.DefaultValue ?? DbNullValue); // DN
            row.Add("TotalGK", TotalGK.DefaultValue ?? DbNullValue); // DN
            row.Add("Selisih", Selisih.DefaultValue ?? DbNullValue); // DN
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

            // Produk
            Produk.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // NomorGerbongKertel
            NomorGerbongKertel.RowCssClass = "row";

            // MeterAwal
            MeterAwal.RowCssClass = "row";

            // MeterAkhir
            MeterAkhir.RowCssClass = "row";

            // Total
            Total.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // NoMeter
            NoMeter.RowCssClass = "row";

            // Quantity
            Quantity.RowCssClass = "row";

            // HasilPengukuranT2
            HasilPengukuranT2.RowCssClass = "row";

            // PICPengisian
            PICPengisian.RowCssClass = "row";

            // NomorGerbongKertel2
            NomorGerbongKertel2.RowCssClass = "row";

            // NomorGerbongKertel3
            NomorGerbongKertel3.RowCssClass = "row";

            // Quantity2
            Quantity2.RowCssClass = "row";

            // Quantity3
            Quantity3.RowCssClass = "row";

            // HasilPengukuranT2_2
            HasilPengukuranT2_2.RowCssClass = "row";

            // HasilPengukuranT2_3
            HasilPengukuranT2_3.RowCssClass = "row";

            // TotalGK
            TotalGK.RowCssClass = "row";

            // Selisih
            Selisih.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // idAktifitas

                // idProses

                // NoReferensi

                // Produk

                // StatusAktivitas

                // LastUpdatedBy

                // lastUpdatedDate

                // NomorGerbongKertel

                // MeterAwal

                // MeterAkhir

                // Total

                // userInput

                // etlDate

                // NoMeter

                // Quantity

                // HasilPengukuranT2

                // PICPengisian

                // NomorGerbongKertel2

                // NomorGerbongKertel3

                // Quantity2

                // Quantity3

                // HasilPengukuranT2_2

                // HasilPengukuranT2_3

                // TotalGK

                // Selisih

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

                    // idProses
                    idProses.ViewValue = idProses.CurrentValue;

                    // awallookupbung
                    // idProses
                    ResolveLookupView(idProses, "IdProses", "number");
                    // akhirlookupbung
                    idProses.ViewCustomAttributes = "";

                    // NoReferensi
                    NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                    NoReferensi.ViewCustomAttributes = "";

                    // Produk
                    Produk.ViewValue = ConvertToString(Produk.CurrentValue); // DN
                    Produk.ViewCustomAttributes = "";

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

                    // NomorGerbongKertel
                    NomorGerbongKertel.ViewValue = ConvertToString(NomorGerbongKertel.CurrentValue); // DN
                    NomorGerbongKertel.ViewCustomAttributes = "";

                    // MeterAwal
                    MeterAwal.ViewValue = ConvertToString(MeterAwal.CurrentValue); // DN
                    MeterAwal.ViewCustomAttributes = "";

                    // MeterAkhir
                    MeterAkhir.ViewValue = ConvertToString(MeterAkhir.CurrentValue); // DN
                    MeterAkhir.ViewCustomAttributes = "";

                    // Total
                    Total.ViewValue = ConvertToString(Total.CurrentValue); // DN
                    Total.ViewCustomAttributes = "";

                    // userInput
                    userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                    userInput.ViewCustomAttributes = "";

                    // etlDate
                    etlDate.ViewValue = etlDate.CurrentValue;
                    etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                    etlDate.ViewCustomAttributes = "";

                    // NoMeter
                    NoMeter.ViewValue = ConvertToString(NoMeter.CurrentValue); // DN
                    NoMeter.ViewCustomAttributes = "";

                    // Quantity
                    Quantity.ViewValue = ConvertToString(Quantity.CurrentValue); // DN
                    Quantity.ViewCustomAttributes = "";

                    // HasilPengukuranT2
                    HasilPengukuranT2.ViewValue = ConvertToString(HasilPengukuranT2.CurrentValue); // DN
                    HasilPengukuranT2.ViewCustomAttributes = "";

                    // PICPengisian
                    PICPengisian.ViewValue = ConvertToString(PICPengisian.CurrentValue); // DN
                    PICPengisian.ViewCustomAttributes = "";

                    // NomorGerbongKertel2
                    NomorGerbongKertel2.ViewValue = ConvertToString(NomorGerbongKertel2.CurrentValue); // DN
                    NomorGerbongKertel2.ViewCustomAttributes = "";

                    // NomorGerbongKertel3
                    NomorGerbongKertel3.ViewValue = ConvertToString(NomorGerbongKertel3.CurrentValue); // DN
                    NomorGerbongKertel3.ViewCustomAttributes = "";

                    // Quantity2
                    Quantity2.ViewValue = ConvertToString(Quantity2.CurrentValue); // DN
                    Quantity2.ViewCustomAttributes = "";

                    // Quantity3
                    Quantity3.ViewValue = ConvertToString(Quantity3.CurrentValue); // DN
                    Quantity3.ViewCustomAttributes = "";

                    // HasilPengukuranT2_2
                    HasilPengukuranT2_2.ViewValue = ConvertToString(HasilPengukuranT2_2.CurrentValue); // DN
                    HasilPengukuranT2_2.ViewCustomAttributes = "";

                    // HasilPengukuranT2_3
                    HasilPengukuranT2_3.ViewValue = ConvertToString(HasilPengukuranT2_3.CurrentValue); // DN
                    HasilPengukuranT2_3.ViewCustomAttributes = "";

                    // TotalGK
                    TotalGK.ViewValue = ConvertToString(TotalGK.CurrentValue); // DN
                    TotalGK.ViewCustomAttributes = "";

                    // Selisih
                    Selisih.ViewValue = ConvertToString(Selisih.CurrentValue); // DN
                    Selisih.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // NomorGerbongKertel
                NomorGerbongKertel.HrefValue = "";

                // MeterAwal
                MeterAwal.HrefValue = "";

                // MeterAkhir
                MeterAkhir.HrefValue = "";

                // Total
                Total.HrefValue = "";

                // NoMeter
                NoMeter.HrefValue = "";

                // Quantity
                Quantity.HrefValue = "";

                // HasilPengukuranT2
                HasilPengukuranT2.HrefValue = "";

                // PICPengisian
                PICPengisian.HrefValue = "";

                // NomorGerbongKertel2
                NomorGerbongKertel2.HrefValue = "";

                // NomorGerbongKertel3
                NomorGerbongKertel3.HrefValue = "";

                // Quantity2
                Quantity2.HrefValue = "";

                // Quantity3
                Quantity3.HrefValue = "";

                // HasilPengukuranT2_2
                HasilPengukuranT2_2.HrefValue = "";

                // HasilPengukuranT2_3
                HasilPengukuranT2_3.HrefValue = "";

                // TotalGK
                TotalGK.HrefValue = "";

                // Selisih
                Selisih.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;

                // awallookupbung
                string curVal = ConvertToString(idAktifitas.CurrentValue);
                idAktifitas.EditValue = Empty(curVal) ? DbNullValue : FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
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
                idAktifitas.ViewCustomAttributes = "";

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;

                // awallookupbung
                string curVal2 = ConvertToString(idProses.CurrentValue);
                idProses.EditValue = Empty(curVal2) ? DbNullValue : FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
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
                idProses.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                NoReferensi.EditValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // Produk
                Produk.SetupEditAttributes();
                if (!Produk.Raw)
                    Produk.CurrentValue = HtmlDecode(Produk.CurrentValue);
                Produk.EditValue = HtmlEncode(Produk.CurrentValue);
                Produk.PlaceHolder = RemoveHtml(Produk.Caption);

                // StatusAktivitas
                StatusAktivitas.SetupEditAttributes();
                StatusAktivitas.EditValue = StatusAktivitas.CurrentValue;

                // awallookupbung
                string curVal3 = ConvertToString(StatusAktivitas.CurrentValue);
                StatusAktivitas.EditValue = Empty(curVal3) ? DbNullValue : FormatNumber(StatusAktivitas.CurrentValue, StatusAktivitas.FormatPattern);
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
                StatusAktivitas.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                LastUpdatedBy.EditValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // lastUpdatedDate
                lastUpdatedDate.SetupEditAttributes();
                lastUpdatedDate.EditValue = lastUpdatedDate.CurrentValue;
                lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.EditValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.ViewCustomAttributes = "";

                // NomorGerbongKertel
                NomorGerbongKertel.SetupEditAttributes();
                if (!NomorGerbongKertel.Raw)
                    NomorGerbongKertel.CurrentValue = HtmlDecode(NomorGerbongKertel.CurrentValue);
                NomorGerbongKertel.EditValue = HtmlEncode(NomorGerbongKertel.CurrentValue);
                NomorGerbongKertel.PlaceHolder = RemoveHtml(NomorGerbongKertel.Caption);

                // MeterAwal
                MeterAwal.SetupEditAttributes();
                if (!MeterAwal.Raw)
                    MeterAwal.CurrentValue = HtmlDecode(MeterAwal.CurrentValue);
                MeterAwal.EditValue = HtmlEncode(MeterAwal.CurrentValue);
                MeterAwal.PlaceHolder = RemoveHtml(MeterAwal.Caption);

                // MeterAkhir
                MeterAkhir.SetupEditAttributes();
                if (!MeterAkhir.Raw)
                    MeterAkhir.CurrentValue = HtmlDecode(MeterAkhir.CurrentValue);
                MeterAkhir.EditValue = HtmlEncode(MeterAkhir.CurrentValue);
                MeterAkhir.PlaceHolder = RemoveHtml(MeterAkhir.Caption);

                // Total
                Total.SetupEditAttributes();
                if (!Total.Raw)
                    Total.CurrentValue = HtmlDecode(Total.CurrentValue);
                Total.EditValue = HtmlEncode(Total.CurrentValue);
                Total.PlaceHolder = RemoveHtml(Total.Caption);

                // NoMeter
                NoMeter.SetupEditAttributes();
                if (!NoMeter.Raw)
                    NoMeter.CurrentValue = HtmlDecode(NoMeter.CurrentValue);
                NoMeter.EditValue = HtmlEncode(NoMeter.CurrentValue);
                NoMeter.PlaceHolder = RemoveHtml(NoMeter.Caption);

                // Quantity
                Quantity.SetupEditAttributes();
                if (!Quantity.Raw)
                    Quantity.CurrentValue = HtmlDecode(Quantity.CurrentValue);
                Quantity.EditValue = HtmlEncode(Quantity.CurrentValue);
                Quantity.PlaceHolder = RemoveHtml(Quantity.Caption);

                // HasilPengukuranT2
                HasilPengukuranT2.SetupEditAttributes();
                if (!HasilPengukuranT2.Raw)
                    HasilPengukuranT2.CurrentValue = HtmlDecode(HasilPengukuranT2.CurrentValue);
                HasilPengukuranT2.EditValue = HtmlEncode(HasilPengukuranT2.CurrentValue);
                HasilPengukuranT2.PlaceHolder = RemoveHtml(HasilPengukuranT2.Caption);

                // PICPengisian
                PICPengisian.SetupEditAttributes();
                if (!PICPengisian.Raw)
                    PICPengisian.CurrentValue = HtmlDecode(PICPengisian.CurrentValue);
                PICPengisian.EditValue = HtmlEncode(PICPengisian.CurrentValue);
                PICPengisian.PlaceHolder = RemoveHtml(PICPengisian.Caption);

                // NomorGerbongKertel2
                NomorGerbongKertel2.SetupEditAttributes();
                if (!NomorGerbongKertel2.Raw)
                    NomorGerbongKertel2.CurrentValue = HtmlDecode(NomorGerbongKertel2.CurrentValue);
                NomorGerbongKertel2.EditValue = HtmlEncode(NomorGerbongKertel2.CurrentValue);
                NomorGerbongKertel2.PlaceHolder = RemoveHtml(NomorGerbongKertel2.Caption);

                // NomorGerbongKertel3
                NomorGerbongKertel3.SetupEditAttributes();
                if (!NomorGerbongKertel3.Raw)
                    NomorGerbongKertel3.CurrentValue = HtmlDecode(NomorGerbongKertel3.CurrentValue);
                NomorGerbongKertel3.EditValue = HtmlEncode(NomorGerbongKertel3.CurrentValue);
                NomorGerbongKertel3.PlaceHolder = RemoveHtml(NomorGerbongKertel3.Caption);

                // Quantity2
                Quantity2.SetupEditAttributes();
                if (!Quantity2.Raw)
                    Quantity2.CurrentValue = HtmlDecode(Quantity2.CurrentValue);
                Quantity2.EditValue = HtmlEncode(Quantity2.CurrentValue);
                Quantity2.PlaceHolder = RemoveHtml(Quantity2.Caption);

                // Quantity3
                Quantity3.SetupEditAttributes();
                if (!Quantity3.Raw)
                    Quantity3.CurrentValue = HtmlDecode(Quantity3.CurrentValue);
                Quantity3.EditValue = HtmlEncode(Quantity3.CurrentValue);
                Quantity3.PlaceHolder = RemoveHtml(Quantity3.Caption);

                // HasilPengukuranT2_2
                HasilPengukuranT2_2.SetupEditAttributes();
                if (!HasilPengukuranT2_2.Raw)
                    HasilPengukuranT2_2.CurrentValue = HtmlDecode(HasilPengukuranT2_2.CurrentValue);
                HasilPengukuranT2_2.EditValue = HtmlEncode(HasilPengukuranT2_2.CurrentValue);
                HasilPengukuranT2_2.PlaceHolder = RemoveHtml(HasilPengukuranT2_2.Caption);

                // HasilPengukuranT2_3
                HasilPengukuranT2_3.SetupEditAttributes();
                if (!HasilPengukuranT2_3.Raw)
                    HasilPengukuranT2_3.CurrentValue = HtmlDecode(HasilPengukuranT2_3.CurrentValue);
                HasilPengukuranT2_3.EditValue = HtmlEncode(HasilPengukuranT2_3.CurrentValue);
                HasilPengukuranT2_3.PlaceHolder = RemoveHtml(HasilPengukuranT2_3.Caption);

                // TotalGK
                TotalGK.SetupEditAttributes();
                if (!TotalGK.Raw)
                    TotalGK.CurrentValue = HtmlDecode(TotalGK.CurrentValue);
                TotalGK.EditValue = HtmlEncode(TotalGK.CurrentValue);
                TotalGK.PlaceHolder = RemoveHtml(TotalGK.Caption);

                // Selisih
                Selisih.SetupEditAttributes();
                if (!Selisih.Raw)
                    Selisih.CurrentValue = HtmlDecode(Selisih.CurrentValue);
                Selisih.EditValue = HtmlEncode(Selisih.CurrentValue);
                Selisih.PlaceHolder = RemoveHtml(Selisih.Caption);

                // Edit refer script

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // NomorGerbongKertel
                NomorGerbongKertel.HrefValue = "";

                // MeterAwal
                MeterAwal.HrefValue = "";

                // MeterAkhir
                MeterAkhir.HrefValue = "";

                // Total
                Total.HrefValue = "";

                // NoMeter
                NoMeter.HrefValue = "";

                // Quantity
                Quantity.HrefValue = "";

                // HasilPengukuranT2
                HasilPengukuranT2.HrefValue = "";

                // PICPengisian
                PICPengisian.HrefValue = "";

                // NomorGerbongKertel2
                NomorGerbongKertel2.HrefValue = "";

                // NomorGerbongKertel3
                NomorGerbongKertel3.HrefValue = "";

                // Quantity2
                Quantity2.HrefValue = "";

                // Quantity3
                Quantity3.HrefValue = "";

                // HasilPengukuranT2_2
                HasilPengukuranT2_2.HrefValue = "";

                // HasilPengukuranT2_3
                HasilPengukuranT2_3.HrefValue = "";

                // TotalGK
                TotalGK.HrefValue = "";

                // Selisih
                Selisih.HrefValue = "";
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
                    idAktifitas.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomidProses() {
            if (idProses.Visible && idProses.Required) {
                if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                    idProses.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomNoReferensi() {
            if (NoReferensi.Visible && NoReferensi.Required) {
                if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                    NoReferensi.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomProduk() {
            if (Produk.Visible && Produk.Required) {
                if (!Produk.IsDetailKey && Empty(Produk.FormValue)) {
                    Produk.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomStatusAktivitas() {
            if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                    StatusAktivitas.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomLastUpdatedBy() {
            if (LastUpdatedBy.Visible && LastUpdatedBy.Required) {
                if (!LastUpdatedBy.IsDetailKey && Empty(LastUpdatedBy.FormValue)) {
                    LastUpdatedBy.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomlastUpdatedDate() {
            if (lastUpdatedDate.Visible && lastUpdatedDate.Required) {
                if (!lastUpdatedDate.IsDetailKey && Empty(lastUpdatedDate.FormValue)) {
                    lastUpdatedDate.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomNomorGerbongKertel() {
            if (NomorGerbongKertel.Visible && NomorGerbongKertel.Required) {
                if (!NomorGerbongKertel.IsDetailKey && Empty(NomorGerbongKertel.FormValue)) {
                    NomorGerbongKertel.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomMeterAwal() {
            if (MeterAwal.Visible && MeterAwal.Required) {
                if (!MeterAwal.IsDetailKey && Empty(MeterAwal.FormValue)) {
                    MeterAwal.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomMeterAkhir() {
            if (MeterAkhir.Visible && MeterAkhir.Required) {
                if (!MeterAkhir.IsDetailKey && Empty(MeterAkhir.FormValue)) {
                    MeterAkhir.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomTotal() {
            if (Total.Visible && Total.Required) {
                if (!Total.IsDetailKey && Empty(Total.FormValue)) {
                    Total.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomNoMeter() {
            if (NoMeter.Visible && NoMeter.Required) {
                if (!NoMeter.IsDetailKey && Empty(NoMeter.FormValue)) {
                    NoMeter.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomQuantity() {
            if (Quantity.Visible && Quantity.Required) {
                if (!Quantity.IsDetailKey && Empty(Quantity.FormValue)) {
                    Quantity.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomHasilPengukuranT2() {
            if (HasilPengukuranT2.Visible && HasilPengukuranT2.Required) {
                if (!HasilPengukuranT2.IsDetailKey && Empty(HasilPengukuranT2.FormValue)) {
                    HasilPengukuranT2.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomPICPengisian() {
            if (PICPengisian.Visible && PICPengisian.Required) {
                if (!PICPengisian.IsDetailKey && Empty(PICPengisian.FormValue)) {
                    PICPengisian.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomNomorGerbongKertel2() {
            if (NomorGerbongKertel2.Visible && NomorGerbongKertel2.Required) {
                if (!NomorGerbongKertel2.IsDetailKey && Empty(NomorGerbongKertel2.FormValue)) {
                    NomorGerbongKertel2.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomNomorGerbongKertel3() {
            if (NomorGerbongKertel3.Visible && NomorGerbongKertel3.Required) {
                if (!NomorGerbongKertel3.IsDetailKey && Empty(NomorGerbongKertel3.FormValue)) {
                    NomorGerbongKertel3.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomQuantity2() {
            if (Quantity2.Visible && Quantity2.Required) {
                if (!Quantity2.IsDetailKey && Empty(Quantity2.FormValue)) {
                    Quantity2.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomQuantity3() {
            if (Quantity3.Visible && Quantity3.Required) {
                if (!Quantity3.IsDetailKey && Empty(Quantity3.FormValue)) {
                    Quantity3.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomHasilPengukuranT2_2() {
            if (HasilPengukuranT2_2.Visible && HasilPengukuranT2_2.Required) {
                if (!HasilPengukuranT2_2.IsDetailKey && Empty(HasilPengukuranT2_2.FormValue)) {
                    HasilPengukuranT2_2.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomHasilPengukuranT2_3() {
            if (HasilPengukuranT2_3.Visible && HasilPengukuranT2_3.Required) {
                if (!HasilPengukuranT2_3.IsDetailKey && Empty(HasilPengukuranT2_3.FormValue)) {
                    HasilPengukuranT2_3.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomTotalGK() {
            if (TotalGK.Visible && TotalGK.Required) {
                if (!TotalGK.IsDetailKey && Empty(TotalGK.FormValue)) {
                    TotalGK.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
                }
            }
        }

        private void ValidateCustomSelisih() {
            if (Selisih.Visible && Selisih.Required) {
                if (!Selisih.IsDetailKey && Empty(Selisih.FormValue)) {
                    Selisih.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
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
                ValidateCustomidProses();
                ValidateCustomNoReferensi();
                ValidateCustomProduk();
                ValidateCustomStatusAktivitas();
                ValidateCustomLastUpdatedBy();
                ValidateCustomlastUpdatedDate();
                ValidateCustomNomorGerbongKertel();
                ValidateCustomMeterAwal();
                ValidateCustomMeterAkhir();
                ValidateCustomTotal();
                ValidateCustomNoMeter();
                ValidateCustomQuantity();
                ValidateCustomHasilPengukuranT2();
                ValidateCustomPICPengisian();
                ValidateCustomNomorGerbongKertel2();
                ValidateCustomNomorGerbongKertel3();
                ValidateCustomQuantity2();
                ValidateCustomQuantity3();
                ValidateCustomHasilPengukuranT2_2();
                ValidateCustomHasilPengukuranT2_3();
                ValidateCustomTotalGK();
                ValidateCustomSelisih();

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

            // Produk
            Produk.SetDbValue(rsnew, Produk.CurrentValue, Produk.ReadOnly);

            // NomorGerbongKertel
            NomorGerbongKertel.SetDbValue(rsnew, NomorGerbongKertel.CurrentValue, NomorGerbongKertel.ReadOnly);

            // MeterAwal
            MeterAwal.SetDbValue(rsnew, MeterAwal.CurrentValue, MeterAwal.ReadOnly);

            // MeterAkhir
            MeterAkhir.SetDbValue(rsnew, MeterAkhir.CurrentValue, MeterAkhir.ReadOnly);

            // Total
            Total.SetDbValue(rsnew, Total.CurrentValue, Total.ReadOnly);

            // NoMeter
            NoMeter.SetDbValue(rsnew, NoMeter.CurrentValue, NoMeter.ReadOnly);

            // Quantity
            Quantity.SetDbValue(rsnew, Quantity.CurrentValue, Quantity.ReadOnly);

            // HasilPengukuranT2
            HasilPengukuranT2.SetDbValue(rsnew, HasilPengukuranT2.CurrentValue, HasilPengukuranT2.ReadOnly);

            // PICPengisian
            PICPengisian.SetDbValue(rsnew, PICPengisian.CurrentValue, PICPengisian.ReadOnly);

            // NomorGerbongKertel2
            NomorGerbongKertel2.SetDbValue(rsnew, NomorGerbongKertel2.CurrentValue, NomorGerbongKertel2.ReadOnly);

            // NomorGerbongKertel3
            NomorGerbongKertel3.SetDbValue(rsnew, NomorGerbongKertel3.CurrentValue, NomorGerbongKertel3.ReadOnly);

            // Quantity2
            Quantity2.SetDbValue(rsnew, Quantity2.CurrentValue, Quantity2.ReadOnly);

            // Quantity3
            Quantity3.SetDbValue(rsnew, Quantity3.CurrentValue, Quantity3.ReadOnly);

            // HasilPengukuranT2_2
            HasilPengukuranT2_2.SetDbValue(rsnew, HasilPengukuranT2_2.CurrentValue, HasilPengukuranT2_2.ReadOnly);

            // HasilPengukuranT2_3
            HasilPengukuranT2_3.SetDbValue(rsnew, HasilPengukuranT2_3.CurrentValue, HasilPengukuranT2_3.ReadOnly);

            // TotalGK
            TotalGK.SetDbValue(rsnew, TotalGK.CurrentValue, TotalGK.ReadOnly);

            // Selisih
            Selisih.SetDbValue(rsnew, Selisih.CurrentValue, Selisih.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Produk", out value)) // Produk
                Produk.CurrentValue = value;
            if (row.TryGetValue("NomorGerbongKertel", out value)) // NomorGerbongKertel
                NomorGerbongKertel.CurrentValue = value;
            if (row.TryGetValue("MeterAwal", out value)) // MeterAwal
                MeterAwal.CurrentValue = value;
            if (row.TryGetValue("MeterAkhir", out value)) // MeterAkhir
                MeterAkhir.CurrentValue = value;
            if (row.TryGetValue("Total", out value)) // Total
                Total.CurrentValue = value;
            if (row.TryGetValue("NoMeter", out value)) // NoMeter
                NoMeter.CurrentValue = value;
            if (row.TryGetValue("Quantity", out value)) // Quantity
                Quantity.CurrentValue = value;
            if (row.TryGetValue("HasilPengukuranT2", out value)) // HasilPengukuranT2
                HasilPengukuranT2.CurrentValue = value;
            if (row.TryGetValue("PICPengisian", out value)) // PICPengisian
                PICPengisian.CurrentValue = value;
            if (row.TryGetValue("NomorGerbongKertel2", out value)) // NomorGerbongKertel2
                NomorGerbongKertel2.CurrentValue = value;
            if (row.TryGetValue("NomorGerbongKertel3", out value)) // NomorGerbongKertel3
                NomorGerbongKertel3.CurrentValue = value;
            if (row.TryGetValue("Quantity2", out value)) // Quantity2
                Quantity2.CurrentValue = value;
            if (row.TryGetValue("Quantity3", out value)) // Quantity3
                Quantity3.CurrentValue = value;
            if (row.TryGetValue("HasilPengukuranT2_2", out value)) // HasilPengukuranT2_2
                HasilPengukuranT2_2.CurrentValue = value;
            if (row.TryGetValue("HasilPengukuranT2_3", out value)) // HasilPengukuranT2_3
                HasilPengukuranT2_3.CurrentValue = value;
            if (row.TryGetValue("TotalGK", out value)) // TotalGK
                TotalGK.CurrentValue = value;
            if (row.TryGetValue("Selisih", out value)) // Selisih
                Selisih.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasInputDataRtwList")), "", TableVar, true);
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
