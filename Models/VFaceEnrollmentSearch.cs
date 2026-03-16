using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// vFaceEnrollmentSearch
    /// </summary>
    public static VFaceEnrollmentSearch vFaceEnrollmentSearch
    {
        get => HttpData.Get<VFaceEnrollmentSearch>("vFaceEnrollmentSearch")!;
        set => HttpData["vFaceEnrollmentSearch"] = value;
    }

    /// <summary>
    /// Page class for VFaceEnrollment
    /// </summary>
    public class VFaceEnrollmentSearch : VFaceEnrollmentSearchBase
    {
        // Constructor
        public VFaceEnrollmentSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VFaceEnrollmentSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VFaceEnrollmentSearchBase : VFaceEnrollment
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "vFaceEnrollmentSearch";

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
        public VFaceEnrollmentSearchBase(Controller? controller)
        {
            TableName = "VFaceEnrollment";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (vFaceEnrollment)
            if (vFaceEnrollment == null || vFaceEnrollment is VFaceEnrollment)
                vFaceEnrollment = this;

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
        public string PageName => "VFaceEnrollmentSearch";

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
            IdUser.SetVisibility();
            _Username.SetVisibility();
            LinkRedirect.Visible = false;
            _Email.SetVisibility();
            NamaLengkap.SetVisibility();
            DownloadFace.Visible = false;
            IdPosition.SetVisibility();
            Jabatan.SetVisibility();
            Face.SetVisibility();
            TanggalInputFace.SetVisibility();
            UserInputFace.SetVisibility();
            AzurePersonId.SetVisibility();
        }

        // Constructor
        public VFaceEnrollmentSearchBase() : this(null) { }

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
                    if (!SameString(pageName, ListUrl))
                    {
                        result.Add("caption", GetModalCaption(pageName));
                        result.Add("view", pageName == "VFaceEnrollmentView" ? "1" : "0"); // If View page, no primary button
                    }
                    else
                    {
                        result.Add("error", FailureMessage); // List page should not be shown as modal => error
                        ClearFailureMessage();
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdUser") ? dict["IdUser"] : IdUser.CurrentValue));
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

        public string FormClassName = "ew-form ew-search-form";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            var beginResult = await PageRunBeginAsync();
            if (beginResult != null) return beginResult;

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;

            // Get action
            CurrentAction = CurrentForm.GetValue("action");
            if (IsSearch) {
                // Build search string for advanced search, remove blank field
                LoadSearchValues(); // Get search values
                string srchStr = ValidateSearch() ? BuildAdvancedSearch() : "";
                if (!Empty(srchStr)) {
                    srchStr = "VFaceEnrollmentList?" + srchStr;
                    // Do not return Json for UseAjaxActions
                    if (IsModal && UseAjaxActions)
                        IsModal = false;
                    return Terminate(srchStr); // Go to List page
                }
            }

            // Restore search settings from Session
            if (!HasInvalidFields())
                LoadAdvancedSearch();

            // Render row for search
            RowType = RowType.Search;
            ResetAttributes();
            await RenderRow();
            PageRunEnd();
            return PageResult();
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
                    await SetupLookupOptions(IdPosition);
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
                        vFaceEnrollmentSearch?.PageRender();
                    }
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, IdUser); // IdUser
            BuildSearchUrl(ref srchUrl, _Username); // Username
            BuildSearchUrl(ref srchUrl, _Email); // Email
            BuildSearchUrl(ref srchUrl, NamaLengkap); // NamaLengkap
            BuildSearchUrl(ref srchUrl, IdPosition); // IdPosition
            BuildSearchUrl(ref srchUrl, Jabatan); // Jabatan
            BuildSearchUrl(ref srchUrl, Face); // Face
            BuildSearchUrl(ref srchUrl, TanggalInputFace); // TanggalInputFace
            BuildSearchUrl(ref srchUrl, UserInputFace); // UserInputFace
            BuildSearchUrl(ref srchUrl, AzurePersonId); // AzurePersonId
            if (!Empty(srchUrl))
                srchUrl += "&";
            srchUrl += "cmd=search";
            return srchUrl;
        }

// Build search URL
protected void BuildSearchUrl(ref string url, DbField fld, bool oprOnly = false)
{
    var searchData = ExtractSearchFieldData(fld);
    var processedData = ProcessSearchValues(searchData, fld);
    string wrk = "";
    if (IsBetweenOperator(processedData.FldOpr))
    {
        wrk = BuildBetweenSearchQuery(processedData, fld);
    }
    else
    {
        wrk = BuildStandardSearchQuery(processedData, fld, oprOnly);
    }
    AppendToUrl(ref url, wrk);
}

// ================= HELPER METHODS =================
private SearchFieldData ExtractSearchFieldData(DbField fld)
{
    string fldParm = fld.Param;
    string ctl = "x_" + fldParm;
    string ctl2 = "y_" + fldParm;
    if (fld.IsMultiSelect)
    {
        ctl += "[]";
        ctl2 += "[]";
    }
    return new SearchFieldData
    {
        FldParm = fldParm,
        Ctl = ctl,
        Ctl2 = ctl2,
        FldVal = CurrentForm.GetValue(ctl),
        FldOpr = CurrentForm.GetValue("z_" + fldParm),
        FldCond = CurrentForm.GetValue("v_" + fldParm),
        FldVal2 = CurrentForm.GetValue(ctl2),
        FldOpr2 = CurrentForm.GetValue("w_" + fldParm),
        DataType = fld.IsVirtual ? DataType.String : fld.DataType
    };
}

private ProcessedSearchData ProcessSearchValues(SearchFieldData data, DbField fld)
{
    string processedVal = ConvertSearchValue(data.FldVal, data.FldOpr, fld);
    string processedVal2 = ConvertSearchValue(data.FldVal2, data.FldOpr2, fld);
    string processedOpr = ConvertSearchOperator(data.FldOpr, fld, processedVal);
    string processedOpr2 = ConvertSearchOperator(data.FldOpr2, fld, processedVal2);
    return new ProcessedSearchData
    {
        Original = data,
        FldVal = processedVal,
        FldVal2 = processedVal2,
        FldOpr = processedOpr,
        FldOpr2 = processedOpr2
    };
}

private bool IsBetweenOperator(string opr)
{
    return (new[] { "BETWEEN", "NOT BETWEEN" }).Contains(opr);
}

private string BuildBetweenSearchQuery(ProcessedSearchData data, DbField fld)
{
    bool isValid = data.Original.DataType != DataType.Number || fld.VirtualSearch ||
                   (IsNumericSearchValue(data.FldVal, data.FldOpr, fld) &&
                    IsNumericSearchValue(data.FldVal2, data.FldOpr2, fld));
    if (!Empty(data.FldVal) && !Empty(data.FldVal2) && isValid)
    {
        return $"{data.Original.Ctl}={UrlEncode(data.FldVal)}&" +
               $"{data.Original.Ctl2}={UrlEncode(data.FldVal2)}&" +
               $"z_{data.Original.FldParm}={UrlEncode(data.FldOpr)}";
    }
    return "";
}

private string BuildStandardSearchQuery(ProcessedSearchData data, DbField fld, bool oprOnly)
{
    string wrk = BuildPrimarySearchQuery(data, fld, oprOnly);
    string secondaryQuery = BuildSecondarySearchQuery(data, fld, oprOnly);
    if (!Empty(secondaryQuery))
    {
        if (!Empty(wrk))
            wrk += $"&v_{data.Original.FldParm}={data.Original.FldCond}&";
        wrk += secondaryQuery;
    }
    return wrk;
}

private string BuildPrimarySearchQuery(ProcessedSearchData data, DbField fld, bool oprOnly)
{
    bool isValid = data.Original.DataType != DataType.Number || fld.VirtualSearch ||
                   IsNumericSearchValue(data.FldVal, data.FldOpr, fld);
    if (!Empty(data.FldVal) && isValid && IsValidOperator(data.FldOpr))
    {
        return $"{data.Original.Ctl}={UrlEncode(data.FldVal)}&z_{data.Original.FldParm}={UrlEncode(data.FldOpr)}";
    }
    else if (IsNullOperator(data.FldOpr) || (!Empty(data.FldOpr) && oprOnly && IsValidOperator(data.FldOpr)))
    {
        return $"z_{data.Original.FldParm}={UrlEncode(data.FldOpr)}";
    }
    return "";
}

private string BuildSecondarySearchQuery(ProcessedSearchData data, DbField fld, bool oprOnly)
{
    bool isValid = data.Original.DataType != DataType.Number || fld.VirtualSearch ||
                   IsNumericSearchValue(data.FldVal2, data.FldOpr2, fld);
    if (!Empty(data.FldVal2) && isValid && IsValidOperator(data.FldOpr2))
    {
        return $"{data.Original.Ctl2}={UrlEncode(data.FldVal2)}&w_{data.Original.FldParm}={UrlEncode(data.FldOpr2)}";
    }
    else if (IsNullOperator(data.FldOpr2) || (!Empty(data.FldOpr2) && oprOnly && IsValidOperator(data.FldOpr2)))
    {
        return $"w_{data.Original.FldParm}={UrlEncode(data.FldOpr2)}";
    }
    return "";
}

private bool IsNullOperator(string opr)
{
    return (new[] { "IS NULL", "IS NOT NULL", "IS EMPTY", "IS NOT EMPTY" }).Contains(opr);
}

private void AppendToUrl(ref string url, string wrk)
{
    if (!Empty(wrk))
    {
        if (!Empty(url))
            url += "&";
        url += wrk;
    }
}

// Data holder classes
private class SearchFieldData
{
    public string FldParm { get; set; } = "";

    public string Ctl { get; set; } = "";

    public string Ctl2 { get; set; } = "";

    public string FldVal { get; set; } = "";

    public string FldOpr { get; set; } = "";

    public string FldCond { get; set; } = "";

    public string FldVal2 { get; set; } = "";

    public string FldOpr2 { get; set; } = "";

    public DataType DataType { get; set; }
}

private class ProcessedSearchData
{
    public SearchFieldData Original { get; set; } = new();

    public string FldVal { get; set; } = "";

    public string FldVal2 { get; set; } = "";

    public string FldOpr { get; set; } = "";

    public string FldOpr2 { get; set; } = "";
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

        // Load search values for validation // DN
        protected void LoadSearchValues() {
            LoadFieldSearchValues();
        }

        // ================= HELPER METHODS =================
        private void LoadFieldSearchValues()
        {
            LoadFieldIdUserSearchValues();
            LoadField_UsernameSearchValues();
            LoadFieldLinkRedirectSearchValues();
            LoadField_EmailSearchValues();
            LoadFieldNamaLengkapSearchValues();
            LoadFieldIdPositionSearchValues();
            LoadFieldJabatanSearchValues();
            LoadFieldFaceSearchValues();
            LoadFieldTanggalInputFaceSearchValues();
            LoadFieldUserInputFaceSearchValues();
            LoadFieldAzurePersonIdSearchValues();
        }

        private void LoadFieldIdUserSearchValues()
        {
            // IdUser
            LoadPrimarySearchValueIdUser();
            LoadSearchOperatorIdUser();
        }

        private void LoadPrimarySearchValueIdUser()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_IdUser")) {
                IdUser.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdUser");
            }
        }

        private void LoadSearchOperatorIdUser()
        {
            if (Form.ContainsKey("z_IdUser"))
                IdUser.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdUser");
        }

        private void LoadField_UsernameSearchValues()
        {
            // _Username
            LoadPrimarySearchValue_Username();
            LoadSearchOperator_Username();
        }

        private void LoadPrimarySearchValue_Username()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x__Username")) {
                _Username.AdvancedSearch.SearchValue = CurrentForm.GetValue("x__Username", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperator_Username()
        {
            if (Form.ContainsKey("z__Username"))
                _Username.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z__Username", Config.FilterOptionSeparator);
        }

        private void LoadFieldLinkRedirectSearchValues()
        {
            // LinkRedirect
            LoadPrimarySearchValueLinkRedirect();
            LoadSearchOperatorLinkRedirect();
        }

        private void LoadPrimarySearchValueLinkRedirect()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_LinkRedirect")) {
                LinkRedirect.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_LinkRedirect", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorLinkRedirect()
        {
            if (Form.ContainsKey("z_LinkRedirect"))
                LinkRedirect.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_LinkRedirect", Config.FilterOptionSeparator);
        }

        private void LoadField_EmailSearchValues()
        {
            // _Email
            LoadPrimarySearchValue_Email();
            LoadSearchOperator_Email();
        }

        private void LoadPrimarySearchValue_Email()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x__Email")) {
                _Email.AdvancedSearch.SearchValue = CurrentForm.GetValue("x__Email", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperator_Email()
        {
            if (Form.ContainsKey("z__Email"))
                _Email.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z__Email", Config.FilterOptionSeparator);
        }

        private void LoadFieldNamaLengkapSearchValues()
        {
            // NamaLengkap
            LoadPrimarySearchValueNamaLengkap();
            LoadSearchOperatorNamaLengkap();
        }

        private void LoadPrimarySearchValueNamaLengkap()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_NamaLengkap")) {
                NamaLengkap.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NamaLengkap", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorNamaLengkap()
        {
            if (Form.ContainsKey("z_NamaLengkap"))
                NamaLengkap.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NamaLengkap", Config.FilterOptionSeparator);
        }

        private void LoadFieldIdPositionSearchValues()
        {
            // IdPosition
            LoadPrimarySearchValueIdPosition();
            LoadSearchOperatorIdPosition();
        }

        private void LoadPrimarySearchValueIdPosition()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_IdPosition")) {
                IdPosition.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdPosition", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorIdPosition()
        {
            if (Form.ContainsKey("z_IdPosition"))
                IdPosition.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdPosition", Config.FilterOptionSeparator);
        }

        private void LoadFieldJabatanSearchValues()
        {
            // Jabatan
            LoadPrimarySearchValueJabatan();
            LoadSearchOperatorJabatan();
        }

        private void LoadPrimarySearchValueJabatan()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_Jabatan")) {
                Jabatan.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Jabatan", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorJabatan()
        {
            if (Form.ContainsKey("z_Jabatan"))
                Jabatan.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Jabatan", Config.FilterOptionSeparator);
        }

        private void LoadFieldFaceSearchValues()
        {
            // Face
            LoadPrimarySearchValueFace();
            LoadSearchOperatorFace();
        }

        private void LoadPrimarySearchValueFace()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_Face")) {
                Face.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Face", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorFace()
        {
            if (Form.ContainsKey("z_Face"))
                Face.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Face", Config.FilterOptionSeparator);
        }

        private void LoadFieldTanggalInputFaceSearchValues()
        {
            // TanggalInputFace
            LoadPrimarySearchValueTanggalInputFace();
            LoadSearchOperatorTanggalInputFace();
        }

        private void LoadPrimarySearchValueTanggalInputFace()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TanggalInputFace")) {
                TanggalInputFace.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalInputFace", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTanggalInputFace()
        {
            if (Form.ContainsKey("z_TanggalInputFace"))
                TanggalInputFace.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalInputFace", Config.FilterOptionSeparator);
        }

        private void LoadFieldUserInputFaceSearchValues()
        {
            // UserInputFace
            LoadPrimarySearchValueUserInputFace();
            LoadSearchOperatorUserInputFace();
        }

        private void LoadPrimarySearchValueUserInputFace()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_UserInputFace")) {
                UserInputFace.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_UserInputFace", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorUserInputFace()
        {
            if (Form.ContainsKey("z_UserInputFace"))
                UserInputFace.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_UserInputFace", Config.FilterOptionSeparator);
        }

        private void LoadFieldAzurePersonIdSearchValues()
        {
            // AzurePersonId
            LoadPrimarySearchValueAzurePersonId();
            LoadSearchOperatorAzurePersonId();
        }

        private void LoadPrimarySearchValueAzurePersonId()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_AzurePersonId")) {
                AzurePersonId.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AzurePersonId");
            }
        }

        private void LoadSearchOperatorAzurePersonId()
        {
            if (Form.ContainsKey("z_AzurePersonId"))
                AzurePersonId.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AzurePersonId");
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
            IdUser.SetDbValue(row["IdUser"]);
            _Username.SetDbValue(row["Username"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            _Email.SetDbValue(row["Email"]);
            NamaLengkap.SetDbValue(row["NamaLengkap"]);
            DownloadFace.SetDbValue(row["DownloadFace"]);
            IdPosition.SetDbValue(row["IdPosition"]);
            Jabatan.SetDbValue(row["Jabatan"]);
            Face.SetDbValue(row["Face"]);
            TanggalInputFace.SetDbValue(row["TanggalInputFace"]);
            UserInputFace.SetDbValue(row["UserInputFace"]);
            AzurePersonId.SetDbValue(row["AzurePersonId"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdUser", IdUser.DefaultValue ?? DbNullValue); // DN
            row.Add("Username", _Username.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaLengkap", NamaLengkap.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadFace", DownloadFace.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPosition", IdPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("Jabatan", Jabatan.DefaultValue ?? DbNullValue); // DN
            row.Add("Face", Face.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalInputFace", TanggalInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("UserInputFace", UserInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("AzurePersonId", AzurePersonId.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // IdUser
            IdUser.RowCssClass = "row";

            // Username
            _Username.RowCssClass = "row";

            // LinkRedirect
            LinkRedirect.RowCssClass = "row";

            // Email
            _Email.RowCssClass = "row";

            // NamaLengkap
            NamaLengkap.RowCssClass = "row";

            // DownloadFace
            DownloadFace.RowCssClass = "row";

            // IdPosition
            IdPosition.RowCssClass = "row";

            // Jabatan
            Jabatan.RowCssClass = "row";

            // Face
            Face.RowCssClass = "row";

            // TanggalInputFace
            TanggalInputFace.RowCssClass = "row";

            // UserInputFace
            UserInputFace.RowCssClass = "row";

            // AzurePersonId
            AzurePersonId.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // Username

                // LinkRedirect

                // Email

                // NamaLengkap

                // DownloadFace

                // IdPosition

                // Jabatan

                // Face

                // TanggalInputFace

                // UserInputFace

                // AzurePersonId

                    // IdUser
                    IdUser.ViewValue = IdUser.CurrentValue;
                    IdUser.ViewValue = FormatNumber(IdUser.ViewValue, IdUser.FormatPattern);
                    IdUser.ViewCustomAttributes = "";

                    // Username
                    _Username.ViewValue = ConvertToString(_Username.CurrentValue); // DN
                    _Username.ViewCustomAttributes = "";

                    // LinkRedirect
                    LinkRedirect.ViewValue = ConvertToString(LinkRedirect.CurrentValue); // DN
                    LinkRedirect.ViewCustomAttributes = "";

                    // Email
                    _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                    _Email.ViewCustomAttributes = "";

                    // NamaLengkap
                    NamaLengkap.ViewValue = ConvertToString(NamaLengkap.CurrentValue); // DN
                    NamaLengkap.ViewCustomAttributes = "";

                    // DownloadFace
                    DownloadFace.ViewValue = DownloadFace.CurrentValue;
                    DownloadFace.ViewCustomAttributes = "";

                    // IdPosition
                    IdPosition.ViewValue = IdPosition.CurrentValue;

                    // awallookupbung
                    // IdPosition
                    ResolveLookupView(IdPosition, "IdPosition", "number");
                    // akhirlookupbung
                    IdPosition.ViewCustomAttributes = "";

                    // Jabatan
                    Jabatan.ViewValue = ConvertToString(Jabatan.CurrentValue); // DN
                    Jabatan.ViewCustomAttributes = "";

                    // Face
                    Face.ViewValue = ConvertToString(Face.CurrentValue); // DN
                    Face.ViewCustomAttributes = "";

                    // TanggalInputFace
                    TanggalInputFace.ViewValue = TanggalInputFace.CurrentValue;
                    TanggalInputFace.ViewValue = FormatDateTime(TanggalInputFace.ViewValue, TanggalInputFace.FormatPattern);
                    TanggalInputFace.ViewCustomAttributes = "";

                    // UserInputFace
                    UserInputFace.ViewValue = ConvertToString(UserInputFace.CurrentValue); // DN
                    UserInputFace.ViewCustomAttributes = "";

                    // AzurePersonId
                    AzurePersonId.ViewValue = ConvertToString(AzurePersonId.CurrentValue); // DN
                    AzurePersonId.ViewCustomAttributes = "";

                // IdUser
                IdUser.HrefValue = "";
                IdUser.TooltipValue = "";

                // Username
                _Username.HrefValue = "";
                _Username.TooltipValue = "";

                // Email
                _Email.HrefValue = "";
                _Email.TooltipValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";
                NamaLengkap.TooltipValue = "";

                // IdPosition
                IdPosition.HrefValue = "";
                IdPosition.TooltipValue = "";

                // Jabatan
                Jabatan.HrefValue = "";
                Jabatan.TooltipValue = "";

                // Face
                Face.HrefValue = "";
                Face.TooltipValue = "";

                // TanggalInputFace
                TanggalInputFace.HrefValue = "";
                TanggalInputFace.TooltipValue = "";

                // UserInputFace
                UserInputFace.HrefValue = "";
                UserInputFace.TooltipValue = "";

                // AzurePersonId
                AzurePersonId.HrefValue = "";
                AzurePersonId.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // IdUser
                IdUser.SetupEditAttributes();
                IdUser.EditValue = IdUser.AdvancedSearch.SearchValue;
                IdUser.PlaceHolder = RemoveHtml(IdUser.Caption);

                // Username
                _Username.SetupEditAttributes();
                if (!_Username.Raw)
                    _Username.AdvancedSearch.SearchValue = HtmlDecode(_Username.AdvancedSearch.SearchValue);
                _Username.EditValue = HtmlEncode(_Username.AdvancedSearch.SearchValue);
                _Username.PlaceHolder = RemoveHtml(_Username.Caption);

                // Email
                _Email.SetupEditAttributes();
                if (!_Email.Raw)
                    _Email.AdvancedSearch.SearchValue = HtmlDecode(_Email.AdvancedSearch.SearchValue);
                _Email.EditValue = HtmlEncode(_Email.AdvancedSearch.SearchValue);
                _Email.PlaceHolder = RemoveHtml(_Email.Caption);

                // NamaLengkap
                NamaLengkap.SetupEditAttributes();
                if (!NamaLengkap.Raw)
                    NamaLengkap.AdvancedSearch.SearchValue = HtmlDecode(NamaLengkap.AdvancedSearch.SearchValue);
                NamaLengkap.EditValue = HtmlEncode(NamaLengkap.AdvancedSearch.SearchValue);
                NamaLengkap.PlaceHolder = RemoveHtml(NamaLengkap.Caption);

                // IdPosition
                IdPosition.SetupEditAttributes();
                IdPosition.EditValue = IdPosition.AdvancedSearch.SearchValue;

                // awallookupbung
                string curVal = ConvertToString(IdPosition.AdvancedSearch.SearchValue);
                IdPosition.EditValue = Empty(curVal) ? DbNullValue : HtmlEncode(FormatNumber(IdPosition.AdvancedSearch.SearchValue, IdPosition.FormatPattern));
                if (!Empty(curVal)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.EditValue = IdPosition.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.AdvancedSearch.SearchValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk = IdPosition.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk[0]);
                            IdPosition.EditValue = IdPosition.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                IdPosition.PlaceHolder = RemoveHtml(IdPosition.Caption);

                // Jabatan
                Jabatan.SetupEditAttributes();
                if (!Jabatan.Raw)
                    Jabatan.AdvancedSearch.SearchValue = HtmlDecode(Jabatan.AdvancedSearch.SearchValue);
                Jabatan.EditValue = HtmlEncode(Jabatan.AdvancedSearch.SearchValue);
                Jabatan.PlaceHolder = RemoveHtml(Jabatan.Caption);

                // Face
                Face.SetupEditAttributes();
                if (!Face.Raw)
                    Face.AdvancedSearch.SearchValue = HtmlDecode(Face.AdvancedSearch.SearchValue);
                Face.EditValue = HtmlEncode(Face.AdvancedSearch.SearchValue);
                Face.PlaceHolder = RemoveHtml(Face.Caption);

                // TanggalInputFace
                TanggalInputFace.SetupEditAttributes();
                TanggalInputFace.EditValue = FormatDateTime(UnformatDateTime(TanggalInputFace.AdvancedSearch.SearchValue, TanggalInputFace.FormatPattern), TanggalInputFace.FormatPattern);
                TanggalInputFace.PlaceHolder = RemoveHtml(TanggalInputFace.Caption);

                // UserInputFace
                UserInputFace.SetupEditAttributes();
                if (!UserInputFace.Raw)
                    UserInputFace.AdvancedSearch.SearchValue = HtmlDecode(UserInputFace.AdvancedSearch.SearchValue);
                UserInputFace.EditValue = HtmlEncode(UserInputFace.AdvancedSearch.SearchValue);
                UserInputFace.PlaceHolder = RemoveHtml(UserInputFace.Caption);

                // AzurePersonId
                AzurePersonId.SetupEditAttributes();
                AzurePersonId.EditValue = AzurePersonId.AdvancedSearch.SearchValue;
                AzurePersonId.PlaceHolder = RemoveHtml(AzurePersonId.Caption);
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        // Validate search
        protected bool ValidateSearch() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            if (!CheckInteger(ConvertToString(IdUser.AdvancedSearch.SearchValue))) {
                IdUser.AddErrorMessage(IdUser.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(IdPosition.AdvancedSearch.SearchValue))) {
                IdPosition.AddErrorMessage(IdPosition.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalInputFace.AdvancedSearch.SearchValue), TanggalInputFace.FormatPattern)) {
                TanggalInputFace.AddErrorMessage(TanggalInputFace.GetErrorMessage(false));
            }
            if (!CheckGuid(ConvertToString(AzurePersonId.AdvancedSearch.SearchValue))) {
                AzurePersonId.AddErrorMessage(AzurePersonId.GetErrorMessage(false));
            }

            // Return validate result
            bool validateSearch = !HasInvalidFields();

            // Call Form CustomValidate event
            string formCustomError = "";
            validateSearch = validateSearch && FormCustomValidate(ref formCustomError);
            if (!Empty(formCustomError))
                FailureMessage = formCustomError;
            return validateSearch;
        }

        // Load advanced search
        public void LoadAdvancedSearch()
        {
            IdUser.AdvancedSearch.Load();
            _Username.AdvancedSearch.Load();
            _Email.AdvancedSearch.Load();
            NamaLengkap.AdvancedSearch.Load();
            IdPosition.AdvancedSearch.Load();
            Jabatan.AdvancedSearch.Load();
            Face.AdvancedSearch.Load();
            TanggalInputFace.AdvancedSearch.Load();
            UserInputFace.AdvancedSearch.Load();
            AzurePersonId.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("VFaceEnrollmentList")), "", TableVar, true);
            string pageId = "search";
            breadcrumb.Add("search", pageId, url);
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
