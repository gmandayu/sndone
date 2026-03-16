using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penyimpananSampleEdit
    /// </summary>
    public static PenyimpananSampleEdit penyimpananSampleEdit
    {
        get => HttpData.Get<PenyimpananSampleEdit>("penyimpananSampleEdit")!;
        set => HttpData["penyimpananSampleEdit"] = value;
    }

    /// <summary>
    /// Page class for PenyimpananSample
    /// </summary>
    public class PenyimpananSampleEdit : PenyimpananSampleEditBase
    {
        // Constructor
        public PenyimpananSampleEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenyimpananSampleEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            //Log("Page Load");
            IdPlant.DisplayValueSeparator = " - ";
        }
        // Page Load event
        public override void PageRender() {
            //Log("Page Render");
            string status = Convert.ToString(Status.CurrentValue)?.Trim() ?? "";
            if (status.Equals("Dimusnahkan", StringComparison.OrdinalIgnoreCase)) 
            {
                Write("<style>#btn-action{display:none !important;}</style>");
                TanggalDimusnahkan.Disabled = true;
                LokasiPemusnahan.Disabled = true;
            }
            if (Empty(TanggalDimusnahkan.EditValue))
                TanggalDimusnahkan.EditValue = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            Write(@"
            <style>
                button[name='btn-action'], button[name='btn-cancel']{visibility:visible;}
            </style>
            <script>
                document.addEventListener('DOMContentLoaded', function(){
                    const saveBtn=document.querySelector(""button[name='btn-action']"");
                    const cancelBtn=document.querySelector(""button[name='btn-cancel']"");
                    if(saveBtn && !saveBtn.dataset.iconized){
                        saveBtn.insertAdjacentHTML('afterbegin','<i class=""fas fa-save me-2""></i>');
                        saveBtn.dataset.iconized='1';
                    }
                    if(cancelBtn && !cancelBtn.dataset.iconized){
                        cancelBtn.insertAdjacentHTML('afterbegin','<i class=""fas fa-ban me-2""></i>');
                        cancelBtn.dataset.iconized='1';
                    }
                });
            </script>");    
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenyimpananSampleEditBase : PenyimpananSample
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penyimpananSampleEdit";

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
        public PenyimpananSampleEditBase(Controller? controller)
        {
            TableName = "PenyimpananSample";

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

            // Table object (penyimpananSample)
            if (penyimpananSample == null || penyimpananSample is PenyimpananSample)
                penyimpananSample = this;

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
        public string PageName => "PenyimpananSampleEdit";

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
            NomorPenyimpananSample.SetVisibility();
            JenisSample.SetVisibility();
            IdPlant.SetVisibility();
            Tanggal.SetVisibility();
            NamaMasterSample.SetVisibility();
            NomorSegel.SetVisibility();
            Status.SetVisibility();
            Foto.SetVisibility();
            DownloadFoto.Visible = false;
            ExpiredEst.SetVisibility();
            TanggalDimusnahkan.SetVisibility();
            LokasiPemusnahan.SetVisibility();
            CreatedBy.Visible = false;
            etlDate.Visible = false;
            LastUpdatedBy.Visible = false;
            lastUpdatedDate.Visible = false;
        }

        // Constructor
        public PenyimpananSampleEditBase() : this(null) { }

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
                        result.Add("view", pageName == "PenyimpananSampleView" ? "1" : "0"); // If View page, no primary button
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
                return Terminate("PenyimpananSampleList");
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
                    if (GetPageName(returnUrl) != "PenyimpananSampleList") {
                        TempData["Return-Url"] = returnUrl;
                        returnUrl = "PenyimpananSampleList";
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
            if (GetPageName(returnUrl) == "PenyimpananSampleList")
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
                    await SetupLookupOptions(JenisSample);
                    await SetupLookupOptions(IdPlant);
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
                        penyimpananSampleEdit?.PageRender();
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

            // Standard handling for 'NomorPenyimpananSample'
            NomorPenyimpananSample.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NomorPenyimpananSample, "NomorPenyimpananSample", "x_NomorPenyimpananSample");

            // Standard handling for 'JenisSample'
            JenisSample.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(JenisSample, "JenisSample", "x_JenisSample");

            // Standard handling for 'IdPlant'
            IdPlant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdPlant, "IdPlant", "x_IdPlant");

            // Standard handling for 'Tanggal'
            Tanggal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Tanggal, "Tanggal", "x_Tanggal", false, false, true);

            // Standard handling for 'NamaMasterSample'
            NamaMasterSample.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NamaMasterSample, "NamaMasterSample", "x_NamaMasterSample");

            // Standard handling for 'NomorSegel'
            NomorSegel.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NomorSegel, "NomorSegel", "x_NomorSegel");

            // Standard handling for 'Status'
            Status.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Status, "Status", "x_Status");

            // Standard handling for 'Foto'
            Foto.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Foto, "Foto", "x_Foto");

            // Standard handling for 'ExpiredEst'
            ExpiredEst.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(ExpiredEst, "ExpiredEst", "x_ExpiredEst", false, false, true);

            // Standard handling for 'TanggalDimusnahkan'
            TanggalDimusnahkan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalDimusnahkan, "TanggalDimusnahkan", "x_TanggalDimusnahkan", true, validate, true);

            // Standard handling for 'LokasiPemusnahan'
            LokasiPemusnahan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LokasiPemusnahan, "LokasiPemusnahan", "x_LokasiPemusnahan");
            if (!id.IsDetailKey) {
                SetNormalField(id, "id", "x_id");
            }
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            id.CurrentValue = id.FormValue;
            NomorPenyimpananSample.CurrentValue = NomorPenyimpananSample.FormValue;
            JenisSample.CurrentValue = JenisSample.FormValue;
            IdPlant.CurrentValue = IdPlant.FormValue;
            Tanggal.CurrentValue = Tanggal.FormValue;
            Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            NamaMasterSample.CurrentValue = NamaMasterSample.FormValue;
            NomorSegel.CurrentValue = NomorSegel.FormValue;
            Status.CurrentValue = Status.FormValue;
            Foto.CurrentValue = Foto.FormValue;
            ExpiredEst.CurrentValue = ExpiredEst.FormValue;
            ExpiredEst.CurrentValue = UnformatDateTime(ExpiredEst.CurrentValue, ExpiredEst.FormatPattern);
            TanggalDimusnahkan.CurrentValue = TanggalDimusnahkan.FormValue;
            TanggalDimusnahkan.CurrentValue = UnformatDateTime(TanggalDimusnahkan.CurrentValue, TanggalDimusnahkan.FormatPattern);
            LokasiPemusnahan.CurrentValue = LokasiPemusnahan.FormValue;
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
            NomorPenyimpananSample.SetDbValue(row["NomorPenyimpananSample"]);
            JenisSample.SetDbValue(row["JenisSample"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            Tanggal.SetDbValue(row["Tanggal"]);
            NamaMasterSample.SetDbValue(row["NamaMasterSample"]);
            NomorSegel.SetDbValue(row["NomorSegel"]);
            Status.SetDbValue(row["Status"]);
            Foto.SetDbValue(row["Foto"]);
            DownloadFoto.SetDbValue(row["DownloadFoto"]);
            ExpiredEst.SetDbValue(row["ExpiredEst"]);
            TanggalDimusnahkan.SetDbValue(row["TanggalDimusnahkan"]);
            LokasiPemusnahan.SetDbValue(row["LokasiPemusnahan"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPenyimpananSample", NomorPenyimpananSample.DefaultValue ?? DbNullValue); // DN
            row.Add("JenisSample", JenisSample.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Tanggal", Tanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaMasterSample", NamaMasterSample.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorSegel", NomorSegel.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("Foto", Foto.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadFoto", DownloadFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("ExpiredEst", ExpiredEst.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDimusnahkan", TanggalDimusnahkan.DefaultValue ?? DbNullValue); // DN
            row.Add("LokasiPemusnahan", LokasiPemusnahan.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
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

            // NomorPenyimpananSample
            NomorPenyimpananSample.RowCssClass = "row";

            // JenisSample
            JenisSample.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // Tanggal
            Tanggal.RowCssClass = "row";

            // NamaMasterSample
            NamaMasterSample.RowCssClass = "row";

            // NomorSegel
            NomorSegel.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // Foto
            Foto.RowCssClass = "row";

            // DownloadFoto
            DownloadFoto.RowCssClass = "row";

            // ExpiredEst
            ExpiredEst.RowCssClass = "row";

            // TanggalDimusnahkan
            TanggalDimusnahkan.RowCssClass = "row";

            // LokasiPemusnahan
            LokasiPemusnahan.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // JenisSample

                // IdPlant

                // Tanggal

                // NamaMasterSample

                // NomorSegel

                // Status

                // Foto

                // ExpiredEst

                // TanggalDimusnahkan

                // LokasiPemusnahan

                // CreatedBy

                // etlDate

                // LastUpdatedBy

                // lastUpdatedDate

                    // NomorPenyimpananSample
                    NomorPenyimpananSample.ViewValue = ConvertToString(NomorPenyimpananSample.CurrentValue); // DN
                    NomorPenyimpananSample.ViewCustomAttributes = "";

                    // JenisSample
                    if (!Empty(JenisSample.CurrentValue)) {
                        JenisSample.ViewValue = JenisSample.OptionCaption(ConvertToString(JenisSample.CurrentValue));
                    } else {
                        JenisSample.ViewValue = DbNullValue;
                    }
                    JenisSample.ViewCustomAttributes = "";

                    // IdPlant

                    // awallookupbung
                    // IdPlant
                    ResolveLookupView(IdPlant, "IdPlant", "number");
                    // akhirlookupbung
                    IdPlant.ViewCustomAttributes = "";

                    // Tanggal
                    Tanggal.ViewValue = Tanggal.CurrentValue;
                    Tanggal.ViewValue = FormatDateTime(Tanggal.ViewValue, Tanggal.FormatPattern);
                    Tanggal.ViewCustomAttributes = "";

                    // NamaMasterSample
                    NamaMasterSample.ViewValue = ConvertToString(NamaMasterSample.CurrentValue); // DN
                    NamaMasterSample.ViewCustomAttributes = "";

                    // NomorSegel
                    NomorSegel.ViewValue = ConvertToString(NomorSegel.CurrentValue); // DN
                    NomorSegel.ViewCustomAttributes = "";

                    // Status
                    Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                    Status.ViewCustomAttributes = "";

                    // Foto
                    Foto.ViewValue = Foto.CurrentValue;
                    Foto.ViewCustomAttributes = "";

                    // ExpiredEst
                    ExpiredEst.ViewValue = ExpiredEst.CurrentValue;
                    ExpiredEst.ViewValue = FormatDateTime(ExpiredEst.ViewValue, ExpiredEst.FormatPattern);
                    ExpiredEst.ViewCustomAttributes = "";

                    // TanggalDimusnahkan
                    TanggalDimusnahkan.ViewValue = TanggalDimusnahkan.CurrentValue;
                    TanggalDimusnahkan.ViewValue = FormatDateTime(TanggalDimusnahkan.ViewValue, TanggalDimusnahkan.FormatPattern);
                    TanggalDimusnahkan.ViewCustomAttributes = "";

                    // LokasiPemusnahan
                    LokasiPemusnahan.ViewValue = ConvertToString(LokasiPemusnahan.CurrentValue); // DN
                    LokasiPemusnahan.ViewCustomAttributes = "";

                    // CreatedBy
                    CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
                    CreatedBy.ViewCustomAttributes = "";

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

                // NomorPenyimpananSample
                NomorPenyimpananSample.HrefValue = "";
                NomorPenyimpananSample.TooltipValue = "";

                // JenisSample
                JenisSample.HrefValue = "";
                JenisSample.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // Tanggal
                Tanggal.HrefValue = "";
                Tanggal.TooltipValue = "";

                // NamaMasterSample
                NamaMasterSample.HrefValue = "";
                NamaMasterSample.TooltipValue = "";

                // NomorSegel
                NomorSegel.HrefValue = "";
                NomorSegel.TooltipValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // Foto
                Foto.HrefValue = "";
                Foto.TooltipValue = "";

                // ExpiredEst
                ExpiredEst.HrefValue = "";
                ExpiredEst.TooltipValue = "";

                // TanggalDimusnahkan
                TanggalDimusnahkan.HrefValue = "";

                // LokasiPemusnahan
                LokasiPemusnahan.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // NomorPenyimpananSample
                NomorPenyimpananSample.SetupEditAttributes();
                NomorPenyimpananSample.EditValue = ConvertToString(NomorPenyimpananSample.CurrentValue); // DN
                NomorPenyimpananSample.ViewCustomAttributes = "";

                // JenisSample
                JenisSample.SetupEditAttributes();
                if (!Empty(JenisSample.CurrentValue)) {
                    JenisSample.EditValue = JenisSample.OptionCaption(ConvertToString(JenisSample.CurrentValue));
                } else {
                    JenisSample.EditValue = DbNullValue;
                }
                JenisSample.ViewCustomAttributes = "";

                // IdPlant
                IdPlant.SetupEditAttributes();

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

                // Tanggal
                Tanggal.SetupEditAttributes();
                Tanggal.EditValue = Tanggal.CurrentValue;
                Tanggal.EditValue = FormatDateTime(Tanggal.EditValue, Tanggal.FormatPattern);
                Tanggal.ViewCustomAttributes = "";

                // NamaMasterSample
                NamaMasterSample.SetupEditAttributes();
                NamaMasterSample.EditValue = ConvertToString(NamaMasterSample.CurrentValue); // DN
                NamaMasterSample.ViewCustomAttributes = "";

                // NomorSegel
                NomorSegel.SetupEditAttributes();
                NomorSegel.EditValue = ConvertToString(NomorSegel.CurrentValue); // DN
                NomorSegel.ViewCustomAttributes = "";

                // Status
                Status.SetupEditAttributes();
                Status.EditValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // Foto
                Foto.SetupEditAttributes();
                Foto.EditValue = Foto.CurrentValue;
                Foto.ViewCustomAttributes = "";

                // ExpiredEst
                ExpiredEst.SetupEditAttributes();
                ExpiredEst.EditValue = ExpiredEst.CurrentValue;
                ExpiredEst.EditValue = FormatDateTime(ExpiredEst.EditValue, ExpiredEst.FormatPattern);
                ExpiredEst.ViewCustomAttributes = "";

                // TanggalDimusnahkan
                TanggalDimusnahkan.SetupEditAttributes();
                TanggalDimusnahkan.EditValue = FormatDateTime(TanggalDimusnahkan.CurrentValue, TanggalDimusnahkan.FormatPattern);
                TanggalDimusnahkan.PlaceHolder = RemoveHtml(TanggalDimusnahkan.Caption);

                // LokasiPemusnahan
                LokasiPemusnahan.SetupEditAttributes();
                if (!LokasiPemusnahan.Raw)
                    LokasiPemusnahan.CurrentValue = HtmlDecode(LokasiPemusnahan.CurrentValue);
                LokasiPemusnahan.EditValue = HtmlEncode(LokasiPemusnahan.CurrentValue);
                LokasiPemusnahan.PlaceHolder = RemoveHtml(LokasiPemusnahan.Caption);

                // Edit refer script

                // NomorPenyimpananSample
                NomorPenyimpananSample.HrefValue = "";
                NomorPenyimpananSample.TooltipValue = "";

                // JenisSample
                JenisSample.HrefValue = "";
                JenisSample.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // Tanggal
                Tanggal.HrefValue = "";
                Tanggal.TooltipValue = "";

                // NamaMasterSample
                NamaMasterSample.HrefValue = "";
                NamaMasterSample.TooltipValue = "";

                // NomorSegel
                NomorSegel.HrefValue = "";
                NomorSegel.TooltipValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // Foto
                Foto.HrefValue = "";
                Foto.TooltipValue = "";

                // ExpiredEst
                ExpiredEst.HrefValue = "";
                ExpiredEst.TooltipValue = "";

                // TanggalDimusnahkan
                TanggalDimusnahkan.HrefValue = "";

                // LokasiPemusnahan
                LokasiPemusnahan.HrefValue = "";
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

        private void ValidateCustomNomorPenyimpananSample() {
            if (NomorPenyimpananSample.Visible && NomorPenyimpananSample.Required) {
                if (!NomorPenyimpananSample.IsDetailKey && Empty(NomorPenyimpananSample.FormValue)) {
                    NomorPenyimpananSample.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomJenisSample() {
            if (JenisSample.Visible && JenisSample.Required) {
                if (!JenisSample.IsDetailKey && Empty(JenisSample.FormValue)) {
                    JenisSample.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomIdPlant() {
            if (IdPlant.Visible && IdPlant.Required) {
                if (!IdPlant.IsDetailKey && Empty(IdPlant.FormValue)) {
                    IdPlant.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomTanggal() {
            if (Tanggal.Visible && Tanggal.Required) {
                if (!Tanggal.IsDetailKey && Empty(Tanggal.FormValue)) {
                    Tanggal.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomNamaMasterSample() {
            if (NamaMasterSample.Visible && NamaMasterSample.Required) {
                if (!NamaMasterSample.IsDetailKey && Empty(NamaMasterSample.FormValue)) {
                    NamaMasterSample.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomNomorSegel() {
            if (NomorSegel.Visible && NomorSegel.Required) {
                if (!NomorSegel.IsDetailKey && Empty(NomorSegel.FormValue)) {
                    NomorSegel.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomStatus() {
            if (Status.Visible && Status.Required) {
                if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                    Status.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomFoto() {
            if (Foto.Visible && Foto.Required) {
                if (!Foto.IsDetailKey && Empty(Foto.FormValue)) {
                    Foto.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomExpiredEst() {
            if (ExpiredEst.Visible && ExpiredEst.Required) {
                if (!ExpiredEst.IsDetailKey && Empty(ExpiredEst.FormValue)) {
                    ExpiredEst.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomTanggalDimusnahkan() {
            if (TanggalDimusnahkan.Visible && TanggalDimusnahkan.Required) {
                if (!TanggalDimusnahkan.IsDetailKey && Empty(TanggalDimusnahkan.FormValue)) {
                    TanggalDimusnahkan.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        private void ValidateCustomLokasiPemusnahan() {
            if (LokasiPemusnahan.Visible && LokasiPemusnahan.Required) {
                if (!LokasiPemusnahan.IsDetailKey && Empty(LokasiPemusnahan.FormValue)) {
                    LokasiPemusnahan.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomNomorPenyimpananSample();
                ValidateCustomJenisSample();
                ValidateCustomIdPlant();
                ValidateCustomTanggal();
                ValidateCustomNamaMasterSample();
                ValidateCustomNomorSegel();
                ValidateCustomStatus();
                ValidateCustomFoto();
                ValidateCustomExpiredEst();
                ValidateCustomTanggalDimusnahkan();
                if (!CheckDate(TanggalDimusnahkan.FormValue, TanggalDimusnahkan.FormatPattern)) {
                    TanggalDimusnahkan.AddErrorMessage(TanggalDimusnahkan.GetErrorMessage(false));
                }
                ValidateCustomLokasiPemusnahan();

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

            // TanggalDimusnahkan
            TanggalDimusnahkan.SetDbValue(rsnew, ConvertToDateTime(TanggalDimusnahkan.CurrentValue, TanggalDimusnahkan.FormatPattern), TanggalDimusnahkan.ReadOnly);

            // LokasiPemusnahan
            LokasiPemusnahan.SetDbValue(rsnew, LokasiPemusnahan.CurrentValue, LokasiPemusnahan.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("TanggalDimusnahkan", out value)) // TanggalDimusnahkan
                TanggalDimusnahkan.CurrentValue = value;
            if (row.TryGetValue("LokasiPemusnahan", out value)) // LokasiPemusnahan
                LokasiPemusnahan.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("PenyimpananSampleList")), "", TableVar, true);
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
