using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// rencanaPenyaluranSearch
    /// </summary>
    public static RencanaPenyaluranSearch rencanaPenyaluranSearch
    {
        get => HttpData.Get<RencanaPenyaluranSearch>("rencanaPenyaluranSearch")!;
        set => HttpData["rencanaPenyaluranSearch"] = value;
    }

    /// <summary>
    /// Page class for RencanaPenyaluran
    /// </summary>
    public class RencanaPenyaluranSearch : RencanaPenyaluranSearchBase
    {
        // Constructor
        public RencanaPenyaluranSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public RencanaPenyaluranSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class RencanaPenyaluranSearchBase : RencanaPenyaluran
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "rencanaPenyaluranSearch";

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
        public RencanaPenyaluranSearchBase(Controller? controller)
        {
            TableName = "RencanaPenyaluran";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (rencanaPenyaluran)
            if (rencanaPenyaluran == null || rencanaPenyaluran is RencanaPenyaluran)
                rencanaPenyaluran = this;

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
        public string PageName => "RencanaPenyaluranSearch";

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
            IdRencanaPenyaluran.Visible = false;
            NomorRencanaPenyaluran.Visible = false;
            LinkProses.Visible = false;
            IdPenimbunan.Visible = false;
            IdTemplate.Visible = false;
            StatusProses.Visible = false;
            PersentaseProgress.Visible = false;
            LookupPlant.Visible = false;
            IdPlant.Visible = false;
            TipeProdukSTS.Visible = false;
            IdModa.Visible = false;
            TipePenyaluran.Visible = false;
            KategoriPenyaluran.Visible = false;
            Tujuan.Visible = false;
            Catatan.Visible = false;
            DibuatOleh.Visible = false;
            TanggalDibuat.SetVisibility();
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.SetVisibility();
            LookupJenisPlant.Visible = false;
        }

        // Constructor
        public RencanaPenyaluranSearchBase() : this(null) { }

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
                        result.Add("view", pageName == "RencanaPenyaluranView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdRencanaPenyaluran") ? dict["IdRencanaPenyaluran"] : IdRencanaPenyaluran.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdRencanaPenyaluran.Visible = false;
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
                    srchStr = "RencanaPenyaluranList?" + srchStr;
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
                    await SetupLookupOptions(IdPenimbunan);
                    await SetupLookupOptions(LookupPlant);
                    await SetupLookupOptions(IdPlant);
                    await SetupLookupOptions(TipeProdukSTS);
                    await SetupLookupOptions(IdModa);
                    await SetupLookupOptions(TipePenyaluran);
                    await SetupLookupOptions(KategoriPenyaluran);
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
                        rencanaPenyaluranSearch?.PageRender();
                    }
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, TanggalDibuat); // TanggalDibuat
            BuildSearchUrl(ref srchUrl, TanggalDiperbarui); // TanggalDiperbarui
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
            LoadFieldNomorRencanaPenyaluranSearchValues();
            LoadFieldLinkProsesSearchValues();
            LoadFieldIdPenimbunanSearchValues();
            LoadFieldIdTemplateSearchValues();
            LoadFieldStatusProsesSearchValues();
            LoadFieldPersentaseProgressSearchValues();
            LoadFieldIdPlantSearchValues();
            LoadFieldTipeProdukSTSSearchValues();
            LoadFieldIdModaSearchValues();
            LoadFieldTipePenyaluranSearchValues();
            LoadFieldKategoriPenyaluranSearchValues();
            LoadFieldTujuanSearchValues();
            LoadFieldCatatanSearchValues();
            LoadFieldDibuatOlehSearchValues();
            LoadFieldTanggalDibuatSearchValues();
            LoadFieldDiperbaruiOlehSearchValues();
            LoadFieldTanggalDiperbaruiSearchValues();
        }

        private void LoadFieldNomorRencanaPenyaluranSearchValues()
        {
            // NomorRencanaPenyaluran
            LoadPrimarySearchValueNomorRencanaPenyaluran();
            LoadSearchOperatorNomorRencanaPenyaluran();
        }

        private void LoadPrimarySearchValueNomorRencanaPenyaluran()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_NomorRencanaPenyaluran")) {
                NomorRencanaPenyaluran.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomorRencanaPenyaluran", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorNomorRencanaPenyaluran()
        {
            if (Form.ContainsKey("z_NomorRencanaPenyaluran"))
                NomorRencanaPenyaluran.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomorRencanaPenyaluran", Config.FilterOptionSeparator);
        }

        private void LoadFieldLinkProsesSearchValues()
        {
            // LinkProses
            LoadPrimarySearchValueLinkProses();
            LoadSearchOperatorLinkProses();
        }

        private void LoadPrimarySearchValueLinkProses()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_LinkProses")) {
                LinkProses.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_LinkProses", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorLinkProses()
        {
            if (Form.ContainsKey("z_LinkProses"))
                LinkProses.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_LinkProses", Config.FilterOptionSeparator);
        }

        private void LoadFieldIdPenimbunanSearchValues()
        {
            // IdPenimbunan
            LoadPrimarySearchValueIdPenimbunan();
            LoadSearchOperatorIdPenimbunan();
        }

        private void LoadPrimarySearchValueIdPenimbunan()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_IdPenimbunan")) {
                IdPenimbunan.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdPenimbunan", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorIdPenimbunan()
        {
            if (Form.ContainsKey("z_IdPenimbunan"))
                IdPenimbunan.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdPenimbunan", Config.FilterOptionSeparator);
        }

        private void LoadFieldIdTemplateSearchValues()
        {
            // IdTemplate
            LoadPrimarySearchValueIdTemplate();
            LoadSearchOperatorIdTemplate();
        }

        private void LoadPrimarySearchValueIdTemplate()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_IdTemplate")) {
                IdTemplate.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdTemplate", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorIdTemplate()
        {
            if (Form.ContainsKey("z_IdTemplate"))
                IdTemplate.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdTemplate", Config.FilterOptionSeparator);
        }

        private void LoadFieldStatusProsesSearchValues()
        {
            // StatusProses
            LoadPrimarySearchValueStatusProses();
            LoadSearchOperatorStatusProses();
        }

        private void LoadPrimarySearchValueStatusProses()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_StatusProses")) {
                StatusProses.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_StatusProses", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorStatusProses()
        {
            if (Form.ContainsKey("z_StatusProses"))
                StatusProses.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_StatusProses", Config.FilterOptionSeparator);
        }

        private void LoadFieldPersentaseProgressSearchValues()
        {
            // PersentaseProgress
            LoadPrimarySearchValuePersentaseProgress();
            LoadSearchOperatorPersentaseProgress();
        }

        private void LoadPrimarySearchValuePersentaseProgress()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_PersentaseProgress")) {
                PersentaseProgress.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PersentaseProgress", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorPersentaseProgress()
        {
            if (Form.ContainsKey("z_PersentaseProgress"))
                PersentaseProgress.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PersentaseProgress", Config.FilterOptionSeparator);
        }

        private void LoadFieldIdPlantSearchValues()
        {
            // IdPlant
            LoadPrimarySearchValueIdPlant();
            LoadSearchOperatorIdPlant();
        }

        private void LoadPrimarySearchValueIdPlant()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_IdPlant")) {
                IdPlant.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdPlant", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorIdPlant()
        {
            if (Form.ContainsKey("z_IdPlant"))
                IdPlant.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdPlant", Config.FilterOptionSeparator);
        }

        private void LoadFieldTipeProdukSTSSearchValues()
        {
            // TipeProdukSTS
            LoadPrimarySearchValueTipeProdukSTS();
            LoadSearchOperatorTipeProdukSTS();
        }

        private void LoadPrimarySearchValueTipeProdukSTS()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TipeProdukSTS")) {
                TipeProdukSTS.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TipeProdukSTS", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTipeProdukSTS()
        {
            if (Form.ContainsKey("z_TipeProdukSTS"))
                TipeProdukSTS.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TipeProdukSTS", Config.FilterOptionSeparator);
        }

        private void LoadFieldIdModaSearchValues()
        {
            // IdModa
            LoadPrimarySearchValueIdModa();
            LoadSearchOperatorIdModa();
        }

        private void LoadPrimarySearchValueIdModa()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_IdModa")) {
                IdModa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdModa", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorIdModa()
        {
            if (Form.ContainsKey("z_IdModa"))
                IdModa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdModa", Config.FilterOptionSeparator);
        }

        private void LoadFieldTipePenyaluranSearchValues()
        {
            // TipePenyaluran
            LoadPrimarySearchValueTipePenyaluran();
            LoadSearchOperatorTipePenyaluran();
        }

        private void LoadPrimarySearchValueTipePenyaluran()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TipePenyaluran")) {
                TipePenyaluran.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TipePenyaluran", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTipePenyaluran()
        {
            if (Form.ContainsKey("z_TipePenyaluran"))
                TipePenyaluran.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TipePenyaluran", Config.FilterOptionSeparator);
        }

        private void LoadFieldKategoriPenyaluranSearchValues()
        {
            // KategoriPenyaluran
            LoadPrimarySearchValueKategoriPenyaluran();
            LoadSearchOperatorKategoriPenyaluran();
        }

        private void LoadPrimarySearchValueKategoriPenyaluran()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_KategoriPenyaluran")) {
                KategoriPenyaluran.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_KategoriPenyaluran", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorKategoriPenyaluran()
        {
            if (Form.ContainsKey("z_KategoriPenyaluran"))
                KategoriPenyaluran.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_KategoriPenyaluran", Config.FilterOptionSeparator);
        }

        private void LoadFieldTujuanSearchValues()
        {
            // Tujuan
            LoadPrimarySearchValueTujuan();
            LoadSearchOperatorTujuan();
        }

        private void LoadPrimarySearchValueTujuan()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_Tujuan")) {
                Tujuan.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Tujuan", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTujuan()
        {
            if (Form.ContainsKey("z_Tujuan"))
                Tujuan.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Tujuan", Config.FilterOptionSeparator);
        }

        private void LoadFieldCatatanSearchValues()
        {
            // Catatan
            LoadPrimarySearchValueCatatan();
            LoadSearchOperatorCatatan();
        }

        private void LoadPrimarySearchValueCatatan()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_Catatan")) {
                Catatan.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Catatan", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorCatatan()
        {
            if (Form.ContainsKey("z_Catatan"))
                Catatan.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Catatan", Config.FilterOptionSeparator);
        }

        private void LoadFieldDibuatOlehSearchValues()
        {
            // DibuatOleh
            LoadPrimarySearchValueDibuatOleh();
            LoadSearchOperatorDibuatOleh();
        }

        private void LoadPrimarySearchValueDibuatOleh()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_DibuatOleh")) {
                DibuatOleh.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DibuatOleh", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorDibuatOleh()
        {
            if (Form.ContainsKey("z_DibuatOleh"))
                DibuatOleh.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DibuatOleh", Config.FilterOptionSeparator);
        }

        private void LoadFieldTanggalDibuatSearchValues()
        {
            // TanggalDibuat
            LoadPrimarySearchValueTanggalDibuat();
            LoadSearchOperatorTanggalDibuat();
            LoadSecondarySearchValuesTanggalDibuat();
        }

        private void LoadPrimarySearchValueTanggalDibuat()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TanggalDibuat")) {
                TanggalDibuat.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalDibuat", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTanggalDibuat()
        {
            if (Form.ContainsKey("z_TanggalDibuat"))
                TanggalDibuat.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalDibuat", Config.FilterOptionSeparator);
        }

        private void LoadSecondarySearchValuesTanggalDibuat()
        {
            if (Form.ContainsKey("v_TanggalDibuat"))
                TanggalDibuat.AdvancedSearch.SearchCondition = CurrentForm.GetValue("v_TanggalDibuat", Config.FilterOptionSeparator);
            if (Form.ContainsKey("y_TanggalDibuat"))
                TanggalDibuat.AdvancedSearch.SearchValue2 = CurrentForm.GetValue("y_TanggalDibuat", Config.FilterOptionSeparator);
            if (Form.ContainsKey("w_TanggalDibuat"))
                TanggalDibuat.AdvancedSearch.SearchOperator2 = CurrentForm.GetValue("w_TanggalDibuat", Config.FilterOptionSeparator);
        }

        private void LoadFieldDiperbaruiOlehSearchValues()
        {
            // DiperbaruiOleh
            LoadPrimarySearchValueDiperbaruiOleh();
            LoadSearchOperatorDiperbaruiOleh();
        }

        private void LoadPrimarySearchValueDiperbaruiOleh()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_DiperbaruiOleh")) {
                DiperbaruiOleh.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DiperbaruiOleh", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorDiperbaruiOleh()
        {
            if (Form.ContainsKey("z_DiperbaruiOleh"))
                DiperbaruiOleh.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DiperbaruiOleh", Config.FilterOptionSeparator);
        }

        private void LoadFieldTanggalDiperbaruiSearchValues()
        {
            // TanggalDiperbarui
            LoadPrimarySearchValueTanggalDiperbarui();
            LoadSearchOperatorTanggalDiperbarui();
            LoadSecondarySearchValuesTanggalDiperbarui();
        }

        private void LoadPrimarySearchValueTanggalDiperbarui()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TanggalDiperbarui")) {
                TanggalDiperbarui.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalDiperbarui", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTanggalDiperbarui()
        {
            if (Form.ContainsKey("z_TanggalDiperbarui"))
                TanggalDiperbarui.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalDiperbarui", Config.FilterOptionSeparator);
        }

        private void LoadSecondarySearchValuesTanggalDiperbarui()
        {
            if (Form.ContainsKey("v_TanggalDiperbarui"))
                TanggalDiperbarui.AdvancedSearch.SearchCondition = CurrentForm.GetValue("v_TanggalDiperbarui", Config.FilterOptionSeparator);
            if (Form.ContainsKey("y_TanggalDiperbarui"))
                TanggalDiperbarui.AdvancedSearch.SearchValue2 = CurrentForm.GetValue("y_TanggalDiperbarui", Config.FilterOptionSeparator);
            if (Form.ContainsKey("w_TanggalDiperbarui"))
                TanggalDiperbarui.AdvancedSearch.SearchOperator2 = CurrentForm.GetValue("w_TanggalDiperbarui", Config.FilterOptionSeparator);
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
            IdRencanaPenyaluran.SetDbValue(row["IdRencanaPenyaluran"]);
            NomorRencanaPenyaluran.SetDbValue(row["NomorRencanaPenyaluran"]);
            LinkProses.SetDbValue(row["LinkProses"]);
            IdPenimbunan.SetDbValue(row["IdPenimbunan"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            LookupPlant.SetDbValue(row["LookupPlant"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            IdModa.SetDbValue(row["IdModa"]);
            TipePenyaluran.SetDbValue(row["TipePenyaluran"]);
            KategoriPenyaluran.SetDbValue(row["KategoriPenyaluran"]);
            Tujuan.SetDbValue(row["Tujuan"]);
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdRencanaPenyaluran", IdRencanaPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorRencanaPenyaluran", NomorRencanaPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkProses", LinkProses.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPenimbunan", IdPenimbunan.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("IdModa", IdModa.DefaultValue ?? DbNullValue); // DN
            row.Add("TipePenyaluran", TipePenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("KategoriPenyaluran", KategoriPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("Tujuan", Tujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("Catatan", Catatan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupJenisPlant", LookupJenisPlant.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // IdRencanaPenyaluran
            IdRencanaPenyaluran.RowCssClass = "row";

            // NomorRencanaPenyaluran
            NomorRencanaPenyaluran.RowCssClass = "row";

            // LinkProses
            LinkProses.RowCssClass = "row";

            // IdPenimbunan
            IdPenimbunan.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

            // PersentaseProgress
            PersentaseProgress.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // IdModa
            IdModa.RowCssClass = "row";

            // TipePenyaluran
            TipePenyaluran.RowCssClass = "row";

            // KategoriPenyaluran
            KategoriPenyaluran.RowCssClass = "row";

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

            // LookupJenisPlant
            LookupJenisPlant.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // StatusProses

                // PersentaseProgress

                // IdPlant

                // TipeProdukSTS

                // IdModa

                // TipePenyaluran

                // KategoriPenyaluran

                // Tujuan

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

                    // LinkProses
                    LinkProses.ViewValue = ConvertToString(LinkProses.CurrentValue); // DN
                    LinkProses.ViewCustomAttributes = "";

                    // StatusProses
                    StatusProses.ViewValue = StatusProses.CurrentValue;
                    StatusProses.ViewCustomAttributes = "";

                    // PersentaseProgress
                    PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                    PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                    PersentaseProgress.ViewCustomAttributes = "";

                    // IdPlant
                    IdPlant.ViewValue = IdPlant.CurrentValue;

                    // awallookupbung
                    // IdPlant
                    ResolveLookupView(IdPlant, "IdPlant", "number");
                    // akhirlookupbung
                    IdPlant.ViewCustomAttributes = "";

                    // TipeProdukSTS
                    List<object?>? listWrk4 = [ // DN
                        TipeProdukSTS.CurrentValue,
                        TipeProdukSTS.CurrentValue,
                    ];
                    listWrk4 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk4, this);
                    string? dispVal4 = TipeProdukSTS.DisplayValue(listWrk4);
                    if (!Empty(dispVal4))
                        TipeProdukSTS.ViewValue = dispVal4;

                    // akhirlookupbung
                    TipeProdukSTS.ViewCustomAttributes = "";

                    // IdModa

                    // awallookupbung
                    // IdModa (jaga leading zero)
                    ResolveLookupView(IdModa, "IdModa", "string");
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

                    // Tujuan
                    Tujuan.ViewValue = ConvertToString(Tujuan.CurrentValue); // DN
                    Tujuan.ViewCustomAttributes = "";

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

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";
                TanggalDibuat.TooltipValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
                TanggalDiperbarui.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // TanggalDibuat
                TanggalDibuat.SetupEditAttributes();
                TanggalDibuat.EditValue = FormatDateTime(UnformatDateTime(TanggalDibuat.AdvancedSearch.SearchValue, TanggalDibuat.FormatPattern), TanggalDibuat.FormatPattern);
                TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);
                TanggalDibuat.SetupEditAttributes();
                TanggalDibuat.EditValue2 = FormatDateTime(UnformatDateTime(TanggalDibuat.AdvancedSearch.SearchValue2, TanggalDibuat.FormatPattern), TanggalDibuat.FormatPattern);
                TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);

                // TanggalDiperbarui
                TanggalDiperbarui.SetupEditAttributes();
                TanggalDiperbarui.EditValue = FormatDateTime(UnformatDateTime(TanggalDiperbarui.AdvancedSearch.SearchValue, TanggalDiperbarui.FormatPattern), TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);
                TanggalDiperbarui.SetupEditAttributes();
                TanggalDiperbarui.EditValue2 = FormatDateTime(UnformatDateTime(TanggalDiperbarui.AdvancedSearch.SearchValue2, TanggalDiperbarui.FormatPattern), TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);
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
            if (!CheckDate(ConvertToString(TanggalDibuat.AdvancedSearch.SearchValue), TanggalDibuat.FormatPattern)) {
                TanggalDibuat.AddErrorMessage(TanggalDibuat.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalDibuat.AdvancedSearch.SearchValue2), TanggalDibuat.FormatPattern)) {
                TanggalDibuat.AddErrorMessage(TanggalDibuat.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalDiperbarui.AdvancedSearch.SearchValue), TanggalDiperbarui.FormatPattern)) {
                TanggalDiperbarui.AddErrorMessage(TanggalDiperbarui.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalDiperbarui.AdvancedSearch.SearchValue2), TanggalDiperbarui.FormatPattern)) {
                TanggalDiperbarui.AddErrorMessage(TanggalDiperbarui.GetErrorMessage(false));
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
            TanggalDibuat.AdvancedSearch.Load();
            TanggalDiperbarui.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("RencanaPenyaluranList")), "", TableVar, true);
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
