using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// samplingLabTestEdit
    /// </summary>
    public static SamplingLabTestEdit samplingLabTestEdit
    {
        get => HttpData.Get<SamplingLabTestEdit>("samplingLabTestEdit")!;
        set => HttpData["samplingLabTestEdit"] = value;
    }

    /// <summary>
    /// Page class for SamplingLabTest
    /// </summary>
    public class SamplingLabTestEdit : SamplingLabTestEditBase
    {
        // Constructor
        public SamplingLabTestEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SamplingLabTestEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            IdPlant.DisplayValueSeparator = " - ";
            KodeProduk.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SamplingLabTestEditBase : SamplingLabTest
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "samplingLabTestEdit";

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
        public SamplingLabTestEditBase(Controller? controller)
        {
            TableName = "SamplingLabTest";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (samplingLabTest)
            if (samplingLabTest == null || samplingLabTest is SamplingLabTest)
                samplingLabTest = this;

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
        public string PageName => "SamplingLabTestEdit";

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
            IdSamplingLabTest.Visible = false;
            NomorSamplingLabTest.SetVisibility();
            LinkProses.Visible = false;
            LookupPlant.SetVisibility();
            IdPlant.SetVisibility();
            LookupIdReferensi.Visible = false;
            IdReferensi.SetVisibility();
            IdPenimbunan.Visible = false;
            IdTemplate.Visible = false;
            StatusProses.Visible = false;
            PersentaseProgress.Visible = false;
            IdModa.SetVisibility();
            TipePenyaluran.SetVisibility();
            KategoriPenyaluran.SetVisibility();
            NomorPolisi.SetVisibility();
            TipeProdukSTS.SetVisibility();
            KodeProduk.SetVisibility();
            Tujuan.SetVisibility();
            Catatan.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            LookupTipeProduk.SetVisibility();
            LookupJenisPlant.SetVisibility();
        }

        // Constructor
        public SamplingLabTestEditBase() : this(null) { }

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
                        result.Add("view", pageName == "SamplingLabTestView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdSamplingLabTest") ? dict["IdSamplingLabTest"] : IdSamplingLabTest.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdSamplingLabTest.Visible = false;
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
                if (RouteValues.TryGetValue("IdSamplingLabTest", out rv)) {
                    IdSamplingLabTest.FormValue = UrlDecode(rv);
                    IdSamplingLabTest.OldValue = IdSamplingLabTest.FormValue;
                } else if (CurrentForm.HasValue("x_IdSamplingLabTest")) {
                    IdSamplingLabTest.FormValue = CurrentForm.GetValue("x_IdSamplingLabTest");
                    IdSamplingLabTest.OldValue = IdSamplingLabTest.FormValue;
                } else if (!Empty(keyValues)) {
                    IdSamplingLabTest.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("IdSamplingLabTest", out rv)) {
                        IdSamplingLabTest.QueryValue = UrlDecode(rv);
                        loadByQuery = true;
                    } else if (Get("IdSamplingLabTest", out sv)) {
                        IdSamplingLabTest.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdSamplingLabTest.CurrentValue = DbNullValue;
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
                IdSamplingLabTest.FormValue = ConvertToString(keyValues[0]);
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
                return Terminate("SamplingLabTestList");
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
                    if (GetPageName(returnUrl) != "SamplingLabTestList") {
                        TempData["Return-Url"] = returnUrl;
                        returnUrl = "SamplingLabTestList";
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
            returnUrl = "SamplingLabTestList";
            if (GetPageName(returnUrl) == "SamplingLabTestList")
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
                    NomorSamplingLabTest.Required = false;
                    LookupPlant.Required = false;
                    IdPlant.Required = false;
                    IdReferensi.Required = false;
                    KodeProduk.Required = false;

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
                    await SetupLookupOptions(IdPlant);
                    await SetupLookupOptions(LookupIdReferensi);
                    await SetupLookupOptions(IdModa);
                    await SetupLookupOptions(TipePenyaluran);
                    await SetupLookupOptions(KategoriPenyaluran);
                    await SetupLookupOptions(TipeProdukSTS);
                    await SetupLookupOptions(KodeProduk);
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
                        samplingLabTestEdit?.PageRender();
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

            // Standard handling for 'NomorSamplingLabTest'
            NomorSamplingLabTest.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NomorSamplingLabTest, "NomorSamplingLabTest", "x_NomorSamplingLabTest");

            // Standard handling for 'LookupPlant'
            LookupPlant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LookupPlant, "LookupPlant", "x_LookupPlant");

            // Standard handling for 'IdPlant'
            IdPlant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdPlant, "IdPlant", "x_IdPlant");

            // Standard handling for 'IdReferensi'
            IdReferensi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdReferensi, "IdReferensi", "x_IdReferensi");

            // Standard handling for 'IdModa'
            IdModa.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdModa, "IdModa", "x_IdModa");

            // Standard handling for 'TipePenyaluran'
            TipePenyaluran.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TipePenyaluran, "TipePenyaluran", "x_TipePenyaluran");

            // Standard handling for 'KategoriPenyaluran'
            KategoriPenyaluran.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(KategoriPenyaluran, "KategoriPenyaluran", "x_KategoriPenyaluran");

            // Standard handling for 'NomorPolisi'
            NomorPolisi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NomorPolisi, "NomorPolisi", "x_NomorPolisi");

            // Standard handling for 'TipeProdukSTS'
            TipeProdukSTS.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TipeProdukSTS, "TipeProdukSTS", "x_TipeProdukSTS");

            // Standard handling for 'KodeProduk'
            KodeProduk.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(KodeProduk, "KodeProduk", "x_KodeProduk");

            // Standard handling for 'Tujuan'
            Tujuan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Tujuan, "Tujuan", "x_Tujuan");

            // Standard handling for 'Catatan'
            Catatan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Catatan, "Catatan", "x_Catatan");

            // Standard handling for 'LookupTipeProduk'
            LookupTipeProduk.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LookupTipeProduk, "LookupTipeProduk", "x_LookupTipeProduk");

            // Standard handling for 'LookupJenisPlant'
            LookupJenisPlant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LookupJenisPlant, "LookupJenisPlant", "x_LookupJenisPlant");
            if (!IdSamplingLabTest.IsDetailKey) {
                SetNormalField(IdSamplingLabTest, "IdSamplingLabTest", "x_IdSamplingLabTest");
            }
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdSamplingLabTest.CurrentValue = IdSamplingLabTest.FormValue;
            NomorSamplingLabTest.CurrentValue = NomorSamplingLabTest.FormValue;
            LookupPlant.CurrentValue = LookupPlant.FormValue;
            IdPlant.CurrentValue = IdPlant.FormValue;
            IdReferensi.CurrentValue = IdReferensi.FormValue;
            IdModa.CurrentValue = IdModa.FormValue;
            TipePenyaluran.CurrentValue = TipePenyaluran.FormValue;
            KategoriPenyaluran.CurrentValue = KategoriPenyaluran.FormValue;
            NomorPolisi.CurrentValue = NomorPolisi.FormValue;
            TipeProdukSTS.CurrentValue = TipeProdukSTS.FormValue;
            KodeProduk.CurrentValue = KodeProduk.FormValue;
            Tujuan.CurrentValue = Tujuan.FormValue;
            Catatan.CurrentValue = Catatan.FormValue;
            LookupTipeProduk.CurrentValue = LookupTipeProduk.FormValue;
            LookupJenisPlant.CurrentValue = LookupJenisPlant.FormValue;
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
            IdSamplingLabTest.SetDbValue(row["IdSamplingLabTest"]);
            NomorSamplingLabTest.SetDbValue(row["NomorSamplingLabTest"]);
            LinkProses.SetDbValue(row["LinkProses"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            LookupIdReferensi.SetDbValue(row["LookupIdReferensi"]);
            IdReferensi.SetDbValue(row["IdReferensi"]);
            IdPenimbunan.SetDbValue(row["IdPenimbunan"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            IdModa.SetDbValue(row["IdModa"]);
            TipePenyaluran.SetDbValue(row["TipePenyaluran"]);
            KategoriPenyaluran.SetDbValue(row["KategoriPenyaluran"]);
            NomorPolisi.SetDbValue(row["NomorPolisi"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            KodeProduk.SetDbValue(row["KodeProduk"]);
            Tujuan.SetDbValue(row["Tujuan"]);
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            LookupTipeProduk.SetDbValue(row["LookupTipeProduk"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdSamplingLabTest", IdSamplingLabTest.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorSamplingLabTest", NomorSamplingLabTest.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkProses", LinkProses.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupIdReferensi", LookupIdReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("IdReferensi", IdReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPenimbunan", IdPenimbunan.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("IdModa", IdModa.DefaultValue ?? DbNullValue); // DN
            row.Add("TipePenyaluran", TipePenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("KategoriPenyaluran", KategoriPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPolisi", NomorPolisi.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("KodeProduk", KodeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("Tujuan", Tujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("Catatan", Catatan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupTipeProduk", LookupTipeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupJenisPlant", LookupJenisPlant.DefaultValue ?? DbNullValue); // DN
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

            // IdSamplingLabTest
            IdSamplingLabTest.RowCssClass = "row";

            // NomorSamplingLabTest
            NomorSamplingLabTest.RowCssClass = "row";

            // LinkProses
            LinkProses.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // LookupIdReferensi
            LookupIdReferensi.RowCssClass = "row";

            // IdReferensi
            IdReferensi.RowCssClass = "row";

            // IdPenimbunan
            IdPenimbunan.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

            // PersentaseProgress
            PersentaseProgress.RowCssClass = "row";

            // IdModa
            IdModa.RowCssClass = "row";

            // TipePenyaluran
            TipePenyaluran.RowCssClass = "row";

            // KategoriPenyaluran
            KategoriPenyaluran.RowCssClass = "row";

            // NomorPolisi
            NomorPolisi.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // KodeProduk
            KodeProduk.RowCssClass = "row";

            // Tujuan
            Tujuan.RowCssClass = "row";

            // Catatan
            Catatan.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaruiOleh
            DiperbaruiOleh.RowCssClass = "row";

            // TanggalDiperbarui
            TanggalDiperbarui.RowCssClass = "row";

            // LookupTipeProduk
            LookupTipeProduk.RowCssClass = "row";

            // LookupJenisPlant
            LookupJenisPlant.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // NomorSamplingLabTest

                // LinkProses

                // LookupPlant

                // IdPlant

                // IdReferensi

                // IdPenimbunan

                // IdTemplate

                // StatusProses

                // PersentaseProgress

                // IdModa

                // TipePenyaluran

                // KategoriPenyaluran

                // NomorPolisi

                // TipeProdukSTS

                // KodeProduk

                // Tujuan

                // Catatan

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

                // LookupTipeProduk

                // LookupJenisPlant

                    // IdSamplingLabTest
                    IdSamplingLabTest.ViewValue = IdSamplingLabTest.CurrentValue;
                    IdSamplingLabTest.ViewCustomAttributes = "";

                    // NomorSamplingLabTest
                    NomorSamplingLabTest.ViewValue = ConvertToString(NomorSamplingLabTest.CurrentValue); // DN
                    NomorSamplingLabTest.ViewCustomAttributes = "";

                    // LinkProses
                    LinkProses.ViewValue = ConvertToString(LinkProses.CurrentValue); // DN
                    LinkProses.ViewCustomAttributes = "";

                    // LookupPlant
                    if (!Empty(LookupPlant.CurrentValue)) {
                        LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                    } else {
                        LookupPlant.ViewValue = DbNullValue;
                    }
                    LookupPlant.ViewCustomAttributes = "";

                    // IdPlant
                    IdPlant.ViewValue = IdPlant.CurrentValue;

                    // awallookupbung
                    // IdPlant
                    ResolveLookupView(IdPlant, "IdPlant", "number");
                    // akhirlookupbung
                    IdPlant.ViewCustomAttributes = "";

                    // IdReferensi
                    IdReferensi.ViewValue = ConvertToString(IdReferensi.CurrentValue); // DN
                    IdReferensi.ViewCustomAttributes = "";

                    // IdPenimbunan
                    IdPenimbunan.ViewValue = IdPenimbunan.CurrentValue;
                    IdPenimbunan.ViewValue = FormatNumber(IdPenimbunan.ViewValue, IdPenimbunan.FormatPattern);
                    IdPenimbunan.ViewCustomAttributes = "";

                    // IdTemplate
                    IdTemplate.ViewValue = IdTemplate.CurrentValue;
                    IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
                    IdTemplate.ViewCustomAttributes = "";

                    // StatusProses
                    StatusProses.ViewValue = StatusProses.CurrentValue;
                    StatusProses.ViewCustomAttributes = "";

                    // PersentaseProgress
                    PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                    PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                    PersentaseProgress.ViewCustomAttributes = "";

                    // IdModa

                    // awallookupbung
                    // IdModa
                    ResolveLookupView(IdModa, "IdModa", "number");
                    // akhirlookupbung
                    IdModa.ViewCustomAttributes = "";

                    // TipePenyaluran
                    if (!Empty(TipePenyaluran.CurrentValue)) {
                        TipePenyaluran.ViewValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
                    } else {
                        TipePenyaluran.ViewValue = DbNullValue;
                    }
                    TipePenyaluran.ViewCustomAttributes = "";

                    // KategoriPenyaluran
                    if (!Empty(KategoriPenyaluran.CurrentValue)) {
                        KategoriPenyaluran.ViewValue = KategoriPenyaluran.OptionCaption(ConvertToString(KategoriPenyaluran.CurrentValue));
                    } else {
                        KategoriPenyaluran.ViewValue = DbNullValue;
                    }
                    KategoriPenyaluran.ViewCustomAttributes = "";

                    // NomorPolisi
                    NomorPolisi.ViewValue = ConvertToString(NomorPolisi.CurrentValue); // DN
                    NomorPolisi.ViewCustomAttributes = "";

                    // TipeProdukSTS
                    List<object?>? listWrk7 = [ // DN
                        TipeProdukSTS.CurrentValue,
                        TipeProdukSTS.CurrentValue,
                    ];
                    listWrk7 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk7, this);
                    string? dispVal7 = TipeProdukSTS.DisplayValue(listWrk7);
                    if (!Empty(dispVal7))
                        TipeProdukSTS.ViewValue = dispVal7;

                    // akhirlookupbung
                    TipeProdukSTS.ViewCustomAttributes = "";

                    // KodeProduk

                    // awallookupbung
                    // KodeProduk (jaga leading zero)
                    ResolveLookupView(KodeProduk, "NoProduk", "string");
                    // akhirlookupbung
                    KodeProduk.ViewCustomAttributes = "";

                    // Tujuan
                    Tujuan.ViewValue = ConvertToString(Tujuan.CurrentValue); // DN
                    Tujuan.ViewCustomAttributes = "";

                    // Catatan
                    Catatan.ViewValue = Catatan.CurrentValue;
                    Catatan.ViewCustomAttributes = "";

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

                    // LookupTipeProduk
                    LookupTipeProduk.ViewValue = LookupTipeProduk.CurrentValue;
                    LookupTipeProduk.ViewCustomAttributes = "";

                    // LookupJenisPlant
                    LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
                    LookupJenisPlant.ViewCustomAttributes = "";

                // NomorSamplingLabTest
                NomorSamplingLabTest.HrefValue = "";
                NomorSamplingLabTest.TooltipValue = "";

                // LookupPlant
                LookupPlant.HrefValue = "";
                LookupPlant.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // IdReferensi
                IdReferensi.HrefValue = "";
                IdReferensi.TooltipValue = "";

                // IdModa
                IdModa.HrefValue = "";
                IdModa.TooltipValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";
                TipePenyaluran.TooltipValue = "";

                // KategoriPenyaluran
                KategoriPenyaluran.HrefValue = "";
                KategoriPenyaluran.TooltipValue = "";

                // NomorPolisi
                NomorPolisi.HrefValue = "";
                NomorPolisi.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // KodeProduk
                KodeProduk.HrefValue = "";
                KodeProduk.TooltipValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";
                LookupTipeProduk.TooltipValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
                LookupJenisPlant.TooltipValue = "";
            } else if (RowType == RowType.Edit) {
                // NomorSamplingLabTest
                NomorSamplingLabTest.SetupEditAttributes();
                NomorSamplingLabTest.EditValue = ConvertToString(NomorSamplingLabTest.CurrentValue); // DN
                NomorSamplingLabTest.ViewCustomAttributes = "";

                // LookupPlant
                LookupPlant.SetupEditAttributes();
                if (!Empty(LookupPlant.CurrentValue)) {
                    LookupPlant.EditValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                } else {
                    LookupPlant.EditValue = DbNullValue;
                }
                LookupPlant.ViewCustomAttributes = "";

                // IdPlant
                IdPlant.SetupEditAttributes();
                IdPlant.EditValue = IdPlant.CurrentValue;

                // awallookupbung
                string curVal2 = ConvertToString(IdPlant.CurrentValue);
                IdPlant.EditValue = Empty(curVal2) ? DbNullValue : FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
                if (!Empty(curVal2)) {
                    if (IdPlant.Lookup != null && IsDictionary(IdPlant.Lookup?.Options) && IdPlant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPlant.EditValue = IdPlant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", IdPlant.CurrentValue, IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = IdPlant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && IdPlant.Lookup != null) { // Lookup values found
                            var listwrk = IdPlant.Lookup?.RenderViewRow(rswrk2[0]);
                            IdPlant.EditValue = IdPlant.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                IdPlant.ViewCustomAttributes = "";

                // IdReferensi
                IdReferensi.SetupEditAttributes();
                IdReferensi.EditValue = ConvertToString(IdReferensi.CurrentValue); // DN
                IdReferensi.ViewCustomAttributes = "";

                // IdModa
                IdModa.SetupEditAttributes();

                // awallookupbung
                string curVal4 = ConvertToString(IdModa.CurrentValue);
                IdModa.EditValue = Empty(curVal4) ? DbNullValue : FormatNumber(IdModa.CurrentValue, IdModa.FormatPattern);
                if (!Empty(curVal4)) {
                    if (IdModa.Lookup != null && IsDictionary(IdModa.Lookup?.Options) && IdModa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdModa.EditValue = IdModa.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", IdModa.CurrentValue, IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                        string? sqlWrk4 = IdModa.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && IdModa.Lookup != null) { // Lookup values found
                            var listwrk = IdModa.Lookup?.RenderViewRow(rswrk4[0]);
                            IdModa.EditValue = IdModa.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                IdModa.ViewCustomAttributes = "";

                // TipePenyaluran
                TipePenyaluran.SetupEditAttributes();
                if (!Empty(TipePenyaluran.CurrentValue)) {
                    TipePenyaluran.EditValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
                } else {
                    TipePenyaluran.EditValue = DbNullValue;
                }
                TipePenyaluran.ViewCustomAttributes = "";

                // KategoriPenyaluran
                KategoriPenyaluran.SetupEditAttributes();
                if (!Empty(KategoriPenyaluran.CurrentValue)) {
                    KategoriPenyaluran.EditValue = KategoriPenyaluran.OptionCaption(ConvertToString(KategoriPenyaluran.CurrentValue));
                } else {
                    KategoriPenyaluran.EditValue = DbNullValue;
                }
                KategoriPenyaluran.ViewCustomAttributes = "";

                // NomorPolisi
                NomorPolisi.SetupEditAttributes();
                NomorPolisi.EditValue = ConvertToString(NomorPolisi.CurrentValue); // DN
                NomorPolisi.ViewCustomAttributes = "";

                // TipeProdukSTS
                TipeProdukSTS.SetupEditAttributes();
                List<object?>? listWrk7 = [ // DN
                    TipeProdukSTS.CurrentValue,
                    TipeProdukSTS.CurrentValue,
                ];
                listWrk7 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk7, this);
                string? dispVal7 = TipeProdukSTS.DisplayValue(listWrk7);
                if (!Empty(dispVal7))
                    TipeProdukSTS.EditValue = dispVal7;

                // akhirlookupbung
                TipeProdukSTS.ViewCustomAttributes = "";

                // KodeProduk
                KodeProduk.SetupEditAttributes();

                // awallookupbung
                string curVal8 = ConvertToString(KodeProduk.CurrentValue);
                KodeProduk.EditValue = Empty(curVal8) ? DbNullValue : KodeProduk.CurrentValue;
                if (!Empty(curVal8)) {
                    if (KodeProduk.Lookup != null && IsDictionary(KodeProduk.Lookup?.Options) && KodeProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        KodeProduk.EditValue = KodeProduk.LookupCacheOption(curVal8);
                    } else { // Lookup from database // DN
                        string filterWrk8 = SearchFilter(KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", KodeProduk.CurrentValue, KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                        string? sqlWrk8 = KodeProduk.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk8?.Count > 0 && KodeProduk.Lookup != null) { // Lookup values found
                            var listwrk = KodeProduk.Lookup?.RenderViewRow(rswrk8[0]);
                            KodeProduk.EditValue = KodeProduk.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                KodeProduk.ViewCustomAttributes = "";

                // Tujuan
                Tujuan.SetupEditAttributes();
                if (!Tujuan.Raw)
                    Tujuan.CurrentValue = HtmlDecode(Tujuan.CurrentValue);
                Tujuan.EditValue = HtmlEncode(Tujuan.CurrentValue);
                Tujuan.PlaceHolder = RemoveHtml(Tujuan.Caption);

                // Catatan
                Catatan.SetupEditAttributes();
                Catatan.EditValue = Catatan.CurrentValue; // DN
                Catatan.PlaceHolder = RemoveHtml(Catatan.Caption);

                // LookupTipeProduk
                LookupTipeProduk.SetupEditAttributes();

                // LookupJenisPlant
                LookupJenisPlant.SetupEditAttributes();

                // Edit refer script

                // NomorSamplingLabTest
                NomorSamplingLabTest.HrefValue = "";
                NomorSamplingLabTest.TooltipValue = "";

                // LookupPlant
                LookupPlant.HrefValue = "";
                LookupPlant.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // IdReferensi
                IdReferensi.HrefValue = "";
                IdReferensi.TooltipValue = "";

                // IdModa
                IdModa.HrefValue = "";
                IdModa.TooltipValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";
                TipePenyaluran.TooltipValue = "";

                // KategoriPenyaluran
                KategoriPenyaluran.HrefValue = "";
                KategoriPenyaluran.TooltipValue = "";

                // NomorPolisi
                NomorPolisi.HrefValue = "";
                NomorPolisi.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // KodeProduk
                KodeProduk.HrefValue = "";
                KodeProduk.TooltipValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";
                LookupTipeProduk.TooltipValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
                LookupJenisPlant.TooltipValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998

        private void ValidateCustomNomorSamplingLabTest() {
            if (NomorSamplingLabTest.Visible && NomorSamplingLabTest.Required) {
                if (!NomorSamplingLabTest.IsDetailKey && Empty(NomorSamplingLabTest.FormValue)) {
                    NomorSamplingLabTest.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomLookupPlant() {
            if (LookupPlant.Visible && LookupPlant.Required) {
                if (!LookupPlant.IsDetailKey && Empty(LookupPlant.FormValue)) {
                    LookupPlant.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomIdPlant() {
            if (IdPlant.Visible && IdPlant.Required) {
                if (!IdPlant.IsDetailKey && Empty(IdPlant.FormValue)) {
                    IdPlant.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomIdReferensi() {
            if (IdReferensi.Visible && IdReferensi.Required) {
                if (!IdReferensi.IsDetailKey && Empty(IdReferensi.FormValue)) {
                    IdReferensi.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomIdModa() {
            if (IdModa.Visible && IdModa.Required) {
                if (!IdModa.IsDetailKey && Empty(IdModa.FormValue)) {
                    IdModa.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomTipePenyaluran() {
            if (TipePenyaluran.Visible && TipePenyaluran.Required) {
                if (!TipePenyaluran.IsDetailKey && Empty(TipePenyaluran.FormValue)) {
                    TipePenyaluran.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomKategoriPenyaluran() {
            if (KategoriPenyaluran.Visible && KategoriPenyaluran.Required) {
                if (!KategoriPenyaluran.IsDetailKey && Empty(KategoriPenyaluran.FormValue)) {
                    KategoriPenyaluran.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomNomorPolisi() {
            if (NomorPolisi.Visible && NomorPolisi.Required) {
                if (!NomorPolisi.IsDetailKey && Empty(NomorPolisi.FormValue)) {
                    NomorPolisi.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomTipeProdukSTS() {
            if (TipeProdukSTS.Visible && TipeProdukSTS.Required) {
                if (!TipeProdukSTS.IsDetailKey && Empty(TipeProdukSTS.FormValue)) {
                    TipeProdukSTS.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomKodeProduk() {
            if (KodeProduk.Visible && KodeProduk.Required) {
                if (!KodeProduk.IsDetailKey && Empty(KodeProduk.FormValue)) {
                    KodeProduk.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomTujuan() {
            if (Tujuan.Visible && Tujuan.Required) {
                if (!Tujuan.IsDetailKey && Empty(Tujuan.FormValue)) {
                    Tujuan.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomCatatan() {
            if (Catatan.Visible && Catatan.Required) {
                if (!Catatan.IsDetailKey && Empty(Catatan.FormValue)) {
                    Catatan.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomLookupTipeProduk() {
            if (LookupTipeProduk.Visible && LookupTipeProduk.Required) {
                if (!LookupTipeProduk.IsDetailKey && Empty(LookupTipeProduk.FormValue)) {
                    LookupTipeProduk.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        private void ValidateCustomLookupJenisPlant() {
            if (LookupJenisPlant.Visible && LookupJenisPlant.Required) {
                if (!LookupJenisPlant.IsDetailKey && Empty(LookupJenisPlant.FormValue)) {
                    LookupJenisPlant.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomNomorSamplingLabTest();
                ValidateCustomLookupPlant();
                ValidateCustomIdPlant();
                ValidateCustomIdReferensi();
                ValidateCustomIdModa();
                ValidateCustomTipePenyaluran();
                ValidateCustomKategoriPenyaluran();
                ValidateCustomNomorPolisi();
                ValidateCustomTipeProdukSTS();
                ValidateCustomKodeProduk();
                ValidateCustomTujuan();
                ValidateCustomCatatan();
                ValidateCustomLookupTipeProduk();
                ValidateCustomLookupJenisPlant();

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

            // Tujuan
            Tujuan.SetDbValue(rsnew, Tujuan.CurrentValue, Tujuan.ReadOnly);

            // Catatan
            Catatan.SetDbValue(rsnew, Catatan.CurrentValue, Catatan.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Tujuan", out value)) // Tujuan
                Tujuan.CurrentValue = value;
            if (row.TryGetValue("Catatan", out value)) // Catatan
                Catatan.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SamplingLabTestList")), "", TableVar, true);
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
