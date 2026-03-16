using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penyaluranSearch
    /// </summary>
    public static PenyaluranSearch penyaluranSearch
    {
        get => HttpData.Get<PenyaluranSearch>("penyaluranSearch")!;
        set => HttpData["penyaluranSearch"] = value;
    }

    /// <summary>
    /// Page class for Penyaluran
    /// </summary>
    public class PenyaluranSearch : PenyaluranSearchBase
    {
        // Constructor
        public PenyaluranSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenyaluranSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenyaluranSearchBase : Penyaluran
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penyaluranSearch";

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
        public PenyaluranSearchBase(Controller? controller)
        {
            TableName = "Penyaluran";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (penyaluran)
            if (penyaluran == null || penyaluran is Penyaluran)
                penyaluran = this;

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
        public string PageName => "PenyaluranSearch";

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
            IdPenyaluran.Visible = false;
            NomorPenyaluran.Visible = false;
            LinkProses.Visible = false;
            LookupPlant.Visible = false;
            IdPlant.Visible = false;
            TipePenyaluran.Visible = false;
            TipeProdukSTS.Visible = false;
            KategoriPenyaluran.Visible = false;
            IdModa.Visible = false;
            DetailRTW.Visible = false;
            NoShipment.SetVisibility();
            IdPipa.SetVisibility();
            NomorPolisi.Visible = false;
            NamaKapal.Visible = false;
            JenisProduk.Visible = false;
            IdPenimbunan.Visible = false;
            StatusProses.Visible = false;
            IdTemplate.Visible = false;
            PersentaseProgress.Visible = false;
            Tujuan.Visible = false;
            TujuanKonsinyasi.Visible = false;
            Volume.Visible = false;
            TujuanKonsinyasiPipa.SetVisibility();
            QuantityKonsinyasiPipa.SetVisibility();
            TujuanKonsinyasi2.Visible = false;
            Volume2.Visible = false;
            TujuanKonsinyasi3.Visible = false;
            Volume3.Visible = false;
            TanggalSandar.SetVisibility();
            Catatan.Visible = false;
            DibuatOleh.Visible = false;
            TanggalDibuat.SetVisibility();
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.SetVisibility();
            LookupTipeProduk.Visible = false;
            LookupJenisPlant.Visible = false;
            MultipleTujuanKonsinyasi.SetVisibility();
            MultipleTujuanKonsinyasiHidden.SetVisibility();
            MultipleQuantity.SetVisibility();
        }

        // Constructor
        public PenyaluranSearchBase() : this(null) { }

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
                        result.Add("view", pageName == "PenyaluranView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdPenyaluran") ? dict["IdPenyaluran"] : IdPenyaluran.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdPenyaluran.Visible = false;
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
                    srchStr = "PenyaluranList?" + srchStr;
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
                    await SetupLookupOptions(LookupPlant);
                    await SetupLookupOptions(IdPlant);
                    await SetupLookupOptions(TipePenyaluran);
                    await SetupLookupOptions(TipeProdukSTS);
                    await SetupLookupOptions(KategoriPenyaluran);
                    await SetupLookupOptions(IdModa);
                    await SetupLookupOptions(IdPipa);
                    await SetupLookupOptions(JenisProduk);
                    await SetupLookupOptions(IdPenimbunan);
                    await SetupLookupOptions(TujuanKonsinyasi);
                    await SetupLookupOptions(TujuanKonsinyasi2);
                    await SetupLookupOptions(TujuanKonsinyasi3);
                    await SetupLookupOptions(MultipleTujuanKonsinyasi);
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
                        penyaluranSearch?.PageRender();
                    }
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, NoShipment); // NoShipment
            BuildSearchUrl(ref srchUrl, IdPipa); // IdPipa
            BuildSearchUrl(ref srchUrl, TujuanKonsinyasiPipa); // TujuanKonsinyasiPipa
            BuildSearchUrl(ref srchUrl, QuantityKonsinyasiPipa); // QuantityKonsinyasiPipa
            BuildSearchUrl(ref srchUrl, TanggalSandar); // TanggalSandar
            BuildSearchUrl(ref srchUrl, TanggalDibuat); // TanggalDibuat
            BuildSearchUrl(ref srchUrl, TanggalDiperbarui); // TanggalDiperbarui
            BuildSearchUrl(ref srchUrl, MultipleTujuanKonsinyasi); // MultipleTujuanKonsinyasi
            BuildSearchUrl(ref srchUrl, MultipleTujuanKonsinyasiHidden); // MultipleTujuanKonsinyasiHidden
            BuildSearchUrl(ref srchUrl, MultipleQuantity); // MultipleQuantity
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
            LoadFieldNomorPenyaluranSearchValues();
            LoadFieldLinkProsesSearchValues();
            LoadFieldIdPlantSearchValues();
            LoadFieldTipePenyaluranSearchValues();
            LoadFieldTipeProdukSTSSearchValues();
            LoadFieldKategoriPenyaluranSearchValues();
            LoadFieldIdModaSearchValues();
            LoadFieldNoShipmentSearchValues();
            LoadFieldIdPipaSearchValues();
            LoadFieldNomorPolisiSearchValues();
            LoadFieldNamaKapalSearchValues();
            LoadFieldJenisProdukSearchValues();
            LoadFieldIdPenimbunanSearchValues();
            LoadFieldStatusProsesSearchValues();
            LoadFieldIdTemplateSearchValues();
            LoadFieldPersentaseProgressSearchValues();
            LoadFieldTujuanSearchValues();
            LoadFieldTujuanKonsinyasiSearchValues();
            LoadFieldVolumeSearchValues();
            LoadFieldTujuanKonsinyasiPipaSearchValues();
            LoadFieldQuantityKonsinyasiPipaSearchValues();
            LoadFieldTujuanKonsinyasi2SearchValues();
            LoadFieldVolume2SearchValues();
            LoadFieldTujuanKonsinyasi3SearchValues();
            LoadFieldVolume3SearchValues();
            LoadFieldTanggalSandarSearchValues();
            LoadFieldCatatanSearchValues();
            LoadFieldDibuatOlehSearchValues();
            LoadFieldTanggalDibuatSearchValues();
            LoadFieldDiperbaruiOlehSearchValues();
            LoadFieldTanggalDiperbaruiSearchValues();
            LoadFieldMultipleTujuanKonsinyasiSearchValues();
            LoadFieldMultipleTujuanKonsinyasiHiddenSearchValues();
            LoadFieldMultipleQuantitySearchValues();
        }

        private void LoadFieldNomorPenyaluranSearchValues()
        {
            // NomorPenyaluran
            LoadPrimarySearchValueNomorPenyaluran();
            LoadSearchOperatorNomorPenyaluran();
        }

        private void LoadPrimarySearchValueNomorPenyaluran()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_NomorPenyaluran")) {
                NomorPenyaluran.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomorPenyaluran", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorNomorPenyaluran()
        {
            if (Form.ContainsKey("z_NomorPenyaluran"))
                NomorPenyaluran.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomorPenyaluran", Config.FilterOptionSeparator);
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

        private void LoadFieldNoShipmentSearchValues()
        {
            // NoShipment
            LoadPrimarySearchValueNoShipment();
            LoadSearchOperatorNoShipment();
        }

        private void LoadPrimarySearchValueNoShipment()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_NoShipment")) {
                NoShipment.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NoShipment");
            }
        }

        private void LoadSearchOperatorNoShipment()
        {
            if (Form.ContainsKey("z_NoShipment"))
                NoShipment.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NoShipment");
        }

        private void LoadFieldIdPipaSearchValues()
        {
            // IdPipa
            LoadPrimarySearchValueIdPipa();
            LoadSearchOperatorIdPipa();
        }

        private void LoadPrimarySearchValueIdPipa()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_IdPipa")) {
                IdPipa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdPipa", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorIdPipa()
        {
            if (Form.ContainsKey("z_IdPipa"))
                IdPipa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdPipa", Config.FilterOptionSeparator);
        }

        private void LoadFieldNomorPolisiSearchValues()
        {
            // NomorPolisi
            LoadPrimarySearchValueNomorPolisi();
            LoadSearchOperatorNomorPolisi();
        }

        private void LoadPrimarySearchValueNomorPolisi()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_NomorPolisi")) {
                NomorPolisi.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomorPolisi", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorNomorPolisi()
        {
            if (Form.ContainsKey("z_NomorPolisi"))
                NomorPolisi.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomorPolisi", Config.FilterOptionSeparator);
        }

        private void LoadFieldNamaKapalSearchValues()
        {
            // NamaKapal
            LoadPrimarySearchValueNamaKapal();
            LoadSearchOperatorNamaKapal();
        }

        private void LoadPrimarySearchValueNamaKapal()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_NamaKapal")) {
                NamaKapal.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NamaKapal", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorNamaKapal()
        {
            if (Form.ContainsKey("z_NamaKapal"))
                NamaKapal.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NamaKapal", Config.FilterOptionSeparator);
        }

        private void LoadFieldJenisProdukSearchValues()
        {
            // JenisProduk
            LoadPrimarySearchValueJenisProduk();
            LoadSearchOperatorJenisProduk();
        }

        private void LoadPrimarySearchValueJenisProduk()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_JenisProduk")) {
                JenisProduk.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_JenisProduk", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorJenisProduk()
        {
            if (Form.ContainsKey("z_JenisProduk"))
                JenisProduk.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_JenisProduk", Config.FilterOptionSeparator);
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

        private void LoadFieldTujuanKonsinyasiSearchValues()
        {
            // TujuanKonsinyasi
            LoadPrimarySearchValueTujuanKonsinyasi();
            LoadSearchOperatorTujuanKonsinyasi();
        }

        private void LoadPrimarySearchValueTujuanKonsinyasi()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TujuanKonsinyasi")) {
                TujuanKonsinyasi.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TujuanKonsinyasi", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTujuanKonsinyasi()
        {
            if (Form.ContainsKey("z_TujuanKonsinyasi"))
                TujuanKonsinyasi.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TujuanKonsinyasi", Config.FilterOptionSeparator);
        }

        private void LoadFieldVolumeSearchValues()
        {
            // Volume
            LoadPrimarySearchValueVolume();
            LoadSearchOperatorVolume();
        }

        private void LoadPrimarySearchValueVolume()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_Volume")) {
                Volume.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Volume", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorVolume()
        {
            if (Form.ContainsKey("z_Volume"))
                Volume.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Volume", Config.FilterOptionSeparator);
        }

        private void LoadFieldTujuanKonsinyasiPipaSearchValues()
        {
            // TujuanKonsinyasiPipa
            LoadPrimarySearchValueTujuanKonsinyasiPipa();
            LoadSearchOperatorTujuanKonsinyasiPipa();
        }

        private void LoadPrimarySearchValueTujuanKonsinyasiPipa()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TujuanKonsinyasiPipa")) {
                TujuanKonsinyasiPipa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TujuanKonsinyasiPipa", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTujuanKonsinyasiPipa()
        {
            if (Form.ContainsKey("z_TujuanKonsinyasiPipa"))
                TujuanKonsinyasiPipa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TujuanKonsinyasiPipa", Config.FilterOptionSeparator);
        }

        private void LoadFieldQuantityKonsinyasiPipaSearchValues()
        {
            // QuantityKonsinyasiPipa
            LoadPrimarySearchValueQuantityKonsinyasiPipa();
            LoadSearchOperatorQuantityKonsinyasiPipa();
        }

        private void LoadPrimarySearchValueQuantityKonsinyasiPipa()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_QuantityKonsinyasiPipa")) {
                QuantityKonsinyasiPipa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_QuantityKonsinyasiPipa", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorQuantityKonsinyasiPipa()
        {
            if (Form.ContainsKey("z_QuantityKonsinyasiPipa"))
                QuantityKonsinyasiPipa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_QuantityKonsinyasiPipa", Config.FilterOptionSeparator);
        }

        private void LoadFieldTujuanKonsinyasi2SearchValues()
        {
            // TujuanKonsinyasi2
            LoadPrimarySearchValueTujuanKonsinyasi2();
            LoadSearchOperatorTujuanKonsinyasi2();
        }

        private void LoadPrimarySearchValueTujuanKonsinyasi2()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TujuanKonsinyasi2")) {
                TujuanKonsinyasi2.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TujuanKonsinyasi2", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTujuanKonsinyasi2()
        {
            if (Form.ContainsKey("z_TujuanKonsinyasi2"))
                TujuanKonsinyasi2.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TujuanKonsinyasi2", Config.FilterOptionSeparator);
        }

        private void LoadFieldVolume2SearchValues()
        {
            // Volume2
            LoadPrimarySearchValueVolume2();
            LoadSearchOperatorVolume2();
        }

        private void LoadPrimarySearchValueVolume2()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_Volume2")) {
                Volume2.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Volume2", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorVolume2()
        {
            if (Form.ContainsKey("z_Volume2"))
                Volume2.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Volume2", Config.FilterOptionSeparator);
        }

        private void LoadFieldTujuanKonsinyasi3SearchValues()
        {
            // TujuanKonsinyasi3
            LoadPrimarySearchValueTujuanKonsinyasi3();
            LoadSearchOperatorTujuanKonsinyasi3();
        }

        private void LoadPrimarySearchValueTujuanKonsinyasi3()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TujuanKonsinyasi3")) {
                TujuanKonsinyasi3.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TujuanKonsinyasi3", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTujuanKonsinyasi3()
        {
            if (Form.ContainsKey("z_TujuanKonsinyasi3"))
                TujuanKonsinyasi3.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TujuanKonsinyasi3", Config.FilterOptionSeparator);
        }

        private void LoadFieldVolume3SearchValues()
        {
            // Volume3
            LoadPrimarySearchValueVolume3();
            LoadSearchOperatorVolume3();
        }

        private void LoadPrimarySearchValueVolume3()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_Volume3")) {
                Volume3.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Volume3", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorVolume3()
        {
            if (Form.ContainsKey("z_Volume3"))
                Volume3.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Volume3", Config.FilterOptionSeparator);
        }

        private void LoadFieldTanggalSandarSearchValues()
        {
            // TanggalSandar
            LoadPrimarySearchValueTanggalSandar();
            LoadSearchOperatorTanggalSandar();
            LoadSecondarySearchValuesTanggalSandar();
        }

        private void LoadPrimarySearchValueTanggalSandar()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_TanggalSandar")) {
                TanggalSandar.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalSandar", Config.FilterOptionSeparator);
            }
        }

        private void LoadSearchOperatorTanggalSandar()
        {
            if (Form.ContainsKey("z_TanggalSandar"))
                TanggalSandar.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalSandar", Config.FilterOptionSeparator);
        }

        private void LoadSecondarySearchValuesTanggalSandar()
        {
            if (Form.ContainsKey("v_TanggalSandar"))
                TanggalSandar.AdvancedSearch.SearchCondition = CurrentForm.GetValue("v_TanggalSandar", Config.FilterOptionSeparator);
            if (Form.ContainsKey("y_TanggalSandar"))
                TanggalSandar.AdvancedSearch.SearchValue2 = CurrentForm.GetValue("y_TanggalSandar", Config.FilterOptionSeparator);
            if (Form.ContainsKey("w_TanggalSandar"))
                TanggalSandar.AdvancedSearch.SearchOperator2 = CurrentForm.GetValue("w_TanggalSandar", Config.FilterOptionSeparator);
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

        private void LoadFieldMultipleTujuanKonsinyasiSearchValues()
        {
            // MultipleTujuanKonsinyasi
            LoadPrimarySearchValueMultipleTujuanKonsinyasi();
            LoadSearchOperatorMultipleTujuanKonsinyasi();
        }

        private void LoadPrimarySearchValueMultipleTujuanKonsinyasi()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_MultipleTujuanKonsinyasi")) {
                MultipleTujuanKonsinyasi.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MultipleTujuanKonsinyasi");
            }
        }

        private void LoadSearchOperatorMultipleTujuanKonsinyasi()
        {
            if (Form.ContainsKey("z_MultipleTujuanKonsinyasi"))
                MultipleTujuanKonsinyasi.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MultipleTujuanKonsinyasi");
        }

        private void LoadFieldMultipleTujuanKonsinyasiHiddenSearchValues()
        {
            // MultipleTujuanKonsinyasiHidden
            LoadPrimarySearchValueMultipleTujuanKonsinyasiHidden();
            LoadSearchOperatorMultipleTujuanKonsinyasiHidden();
        }

        private void LoadPrimarySearchValueMultipleTujuanKonsinyasiHidden()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_MultipleTujuanKonsinyasiHidden")) {
                MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MultipleTujuanKonsinyasiHidden");
            }
        }

        private void LoadSearchOperatorMultipleTujuanKonsinyasiHidden()
        {
            if (Form.ContainsKey("z_MultipleTujuanKonsinyasiHidden"))
                MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MultipleTujuanKonsinyasiHidden");
        }

        private void LoadFieldMultipleQuantitySearchValues()
        {
            // MultipleQuantity
            LoadPrimarySearchValueMultipleQuantity();
            LoadSearchOperatorMultipleQuantity();
        }

        private void LoadPrimarySearchValueMultipleQuantity()
        {
            if (!IsAddOrEdit && Form.ContainsKey("x_MultipleQuantity")) {
                MultipleQuantity.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MultipleQuantity");
            }
        }

        private void LoadSearchOperatorMultipleQuantity()
        {
            if (Form.ContainsKey("z_MultipleQuantity"))
                MultipleQuantity.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MultipleQuantity");
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
            IdPenyaluran.SetDbValue(row["IdPenyaluran"]);
            NomorPenyaluran.SetDbValue(row["NomorPenyaluran"]);
            LinkProses.SetDbValue(row["LinkProses"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            TipePenyaluran.SetDbValue(row["TipePenyaluran"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            KategoriPenyaluran.SetDbValue(row["KategoriPenyaluran"]);
            IdModa.SetDbValue(row["IdModa"]);
            DetailRTW.SetDbValue(row["DetailRTW"]);
            NoShipment.SetDbValue(row["NoShipment"]);
            IdPipa.SetDbValue(row["IdPipa"]);
            NomorPolisi.SetDbValue(row["NomorPolisi"]);
            NamaKapal.SetDbValue(row["NamaKapal"]);
            JenisProduk.SetDbValue(row["JenisProduk"]);
            IdPenimbunan.SetDbValue(row["IdPenimbunan"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            Tujuan.SetDbValue(row["Tujuan"]);
            TujuanKonsinyasi.SetDbValue(row["TujuanKonsinyasi"]);
            Volume.SetDbValue(IsNull(row["Volume"]) ? DbNullValue : ConvertToDouble(row["Volume"]));
            TujuanKonsinyasiPipa.SetDbValue(row["TujuanKonsinyasiPipa"]);
            QuantityKonsinyasiPipa.SetDbValue(row["QuantityKonsinyasiPipa"]);
            TujuanKonsinyasi2.SetDbValue(row["TujuanKonsinyasi2"]);
            Volume2.SetDbValue(IsNull(row["Volume2"]) ? DbNullValue : ConvertToDouble(row["Volume2"]));
            TujuanKonsinyasi3.SetDbValue(row["TujuanKonsinyasi3"]);
            Volume3.SetDbValue(IsNull(row["Volume3"]) ? DbNullValue : ConvertToDouble(row["Volume3"]));
            TanggalSandar.SetDbValue(row["TanggalSandar"]);
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            LookupTipeProduk.SetDbValue(row["LookupTipeProduk"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
            MultipleTujuanKonsinyasi.SetDbValue(row["MultipleTujuanKonsinyasi"]);
            MultipleTujuanKonsinyasiHidden.SetDbValue(row["MultipleTujuanKonsinyasiHidden"]);
            MultipleQuantity.SetDbValue(row["MultipleQuantity"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdPenyaluran", IdPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPenyaluran", NomorPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkProses", LinkProses.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("TipePenyaluran", TipePenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("KategoriPenyaluran", KategoriPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("IdModa", IdModa.DefaultValue ?? DbNullValue); // DN
            row.Add("DetailRTW", DetailRTW.DefaultValue ?? DbNullValue); // DN
            row.Add("NoShipment", NoShipment.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPipa", IdPipa.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPolisi", NomorPolisi.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaKapal", NamaKapal.DefaultValue ?? DbNullValue); // DN
            row.Add("JenisProduk", JenisProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPenimbunan", IdPenimbunan.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("Tujuan", Tujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("TujuanKonsinyasi", TujuanKonsinyasi.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume", Volume.DefaultValue ?? DbNullValue); // DN
            row.Add("TujuanKonsinyasiPipa", TujuanKonsinyasiPipa.DefaultValue ?? DbNullValue); // DN
            row.Add("QuantityKonsinyasiPipa", QuantityKonsinyasiPipa.DefaultValue ?? DbNullValue); // DN
            row.Add("TujuanKonsinyasi2", TujuanKonsinyasi2.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume2", Volume2.DefaultValue ?? DbNullValue); // DN
            row.Add("TujuanKonsinyasi3", TujuanKonsinyasi3.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume3", Volume3.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalSandar", TanggalSandar.DefaultValue ?? DbNullValue); // DN
            row.Add("Catatan", Catatan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupTipeProduk", LookupTipeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupJenisPlant", LookupJenisPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("MultipleTujuanKonsinyasi", MultipleTujuanKonsinyasi.DefaultValue ?? DbNullValue); // DN
            row.Add("MultipleTujuanKonsinyasiHidden", MultipleTujuanKonsinyasiHidden.DefaultValue ?? DbNullValue); // DN
            row.Add("MultipleQuantity", MultipleQuantity.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // IdPenyaluran
            IdPenyaluran.RowCssClass = "row";

            // NomorPenyaluran
            NomorPenyaluran.RowCssClass = "row";

            // LinkProses
            LinkProses.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // TipePenyaluran
            TipePenyaluran.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // KategoriPenyaluran
            KategoriPenyaluran.RowCssClass = "row";

            // IdModa
            IdModa.RowCssClass = "row";

            // DetailRTW
            DetailRTW.RowCssClass = "row";

            // NoShipment
            NoShipment.RowCssClass = "row";

            // IdPipa
            IdPipa.RowCssClass = "row";

            // NomorPolisi
            NomorPolisi.RowCssClass = "row";

            // NamaKapal
            NamaKapal.RowCssClass = "row";

            // JenisProduk
            JenisProduk.RowCssClass = "row";

            // IdPenimbunan
            IdPenimbunan.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // PersentaseProgress
            PersentaseProgress.RowCssClass = "row";

            // Tujuan
            Tujuan.RowCssClass = "row";

            // TujuanKonsinyasi
            TujuanKonsinyasi.RowCssClass = "row";

            // Volume
            Volume.RowCssClass = "row";

            // TujuanKonsinyasiPipa
            TujuanKonsinyasiPipa.RowCssClass = "row";

            // QuantityKonsinyasiPipa
            QuantityKonsinyasiPipa.RowCssClass = "row";

            // TujuanKonsinyasi2
            TujuanKonsinyasi2.RowCssClass = "row";

            // Volume2
            Volume2.RowCssClass = "row";

            // TujuanKonsinyasi3
            TujuanKonsinyasi3.RowCssClass = "row";

            // Volume3
            Volume3.RowCssClass = "row";

            // TanggalSandar
            TanggalSandar.RowCssClass = "row";

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

            // MultipleTujuanKonsinyasi
            MultipleTujuanKonsinyasi.RowCssClass = "row";

            // MultipleTujuanKonsinyasiHidden
            MultipleTujuanKonsinyasiHidden.RowCssClass = "row";

            // MultipleQuantity
            MultipleQuantity.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // LookupPlant

                // IdPlant

                // TipePenyaluran

                // TipeProdukSTS

                // KategoriPenyaluran

                // IdModa

                // NoShipment

                // IdPipa

                // NomorPolisi

                // NamaKapal

                // JenisProduk

                // StatusProses

                // PersentaseProgress

                // Tujuan

                // TujuanKonsinyasi

                // Volume

                // TujuanKonsinyasiPipa

                // QuantityKonsinyasiPipa

                // TanggalSandar

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

                // MultipleTujuanKonsinyasi

                // MultipleTujuanKonsinyasiHidden

                // MultipleQuantity

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

                    // TipePenyaluran
                    if (!Empty(TipePenyaluran.CurrentValue)) {
                        TipePenyaluran.ViewValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
                    } else {
                        TipePenyaluran.ViewValue = DbNullValue;
                    }
                    TipePenyaluran.ViewCustomAttributes = "";

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

                    // KategoriPenyaluran
                    if (!Empty(KategoriPenyaluran.CurrentValue)) {
                        KategoriPenyaluran.ViewValue = KategoriPenyaluran.OptionCaption(ConvertToString(KategoriPenyaluran.CurrentValue));
                    } else {
                        KategoriPenyaluran.ViewValue = DbNullValue;
                    }
                    KategoriPenyaluran.ViewCustomAttributes = "";

                    // IdModa

                    // awallookupbung
                    // IdModa
                    ResolveLookupView(IdModa, "IdModa", "number");
                    // akhirlookupbung
                    IdModa.ViewCustomAttributes = "";

                    // NoShipment
                    NoShipment.ViewValue = ConvertToString(NoShipment.CurrentValue); // DN
                    NoShipment.ViewCustomAttributes = "";

                    // IdPipa

                    // awallookupbung
                    // IdPipa
                    ResolveLookupView(IdPipa, "id", "number");
                    // akhirlookupbung
                    IdPipa.ViewCustomAttributes = "";

                    // NomorPolisi
                    NomorPolisi.ViewValue = ConvertToString(NomorPolisi.CurrentValue); // DN
                    NomorPolisi.ViewCustomAttributes = "";

                    // NamaKapal
                    NamaKapal.ViewValue = ConvertToString(NamaKapal.CurrentValue); // DN
                    NamaKapal.ViewCustomAttributes = "";

                    // JenisProduk

                    // awallookupbung
                    // JenisProduk (jaga leading zero)
                    ResolveLookupView(JenisProduk, "NoProduk", "string");
                    // akhirlookupbung
                    JenisProduk.ViewCustomAttributes = "";

                    // StatusProses
                    StatusProses.ViewValue = StatusProses.CurrentValue;
                    StatusProses.ViewCustomAttributes = "";

                    // PersentaseProgress
                    PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                    PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                    PersentaseProgress.ViewCustomAttributes = "";

                    // Tujuan
                    Tujuan.ViewValue = ConvertToString(Tujuan.CurrentValue); // DN
                    Tujuan.ViewCustomAttributes = "";

                    // TujuanKonsinyasi

                    // awallookupbung
                    // TujuanKonsinyasi
                    ResolveLookupView(TujuanKonsinyasi, "IdPlant", "number");
                    // akhirlookupbung
                    TujuanKonsinyasi.ViewCustomAttributes = "";

                    // Volume
                    Volume.ViewValue = Volume.CurrentValue;
                    Volume.ViewValue = FormatNumber(Volume.ViewValue, Volume.FormatPattern);
                    Volume.ViewCustomAttributes = "";

                    // TujuanKonsinyasiPipa
                    TujuanKonsinyasiPipa.ViewValue = ConvertToString(TujuanKonsinyasiPipa.CurrentValue); // DN
                    TujuanKonsinyasiPipa.ViewCustomAttributes = "";

                    // QuantityKonsinyasiPipa
                    QuantityKonsinyasiPipa.ViewValue = ConvertToString(QuantityKonsinyasiPipa.CurrentValue); // DN
                    QuantityKonsinyasiPipa.ViewCustomAttributes = "";

                    // TanggalSandar
                    TanggalSandar.ViewValue = TanggalSandar.CurrentValue;
                    TanggalSandar.ViewValue = FormatDateTime(TanggalSandar.ViewValue, TanggalSandar.FormatPattern);
                    TanggalSandar.ViewCustomAttributes = "";

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

                    // MultipleTujuanKonsinyasi
                    if (!Empty(MultipleTujuanKonsinyasi.CurrentValue)) {
                        MultipleTujuanKonsinyasi.ViewValue = MultipleTujuanKonsinyasi.OptionCaption(ConvertToString(MultipleTujuanKonsinyasi.CurrentValue));
                    } else {
                        MultipleTujuanKonsinyasi.ViewValue = DbNullValue;
                    }
                    MultipleTujuanKonsinyasi.ViewCustomAttributes = "";

                    // MultipleTujuanKonsinyasiHidden
                    MultipleTujuanKonsinyasiHidden.ViewValue = MultipleTujuanKonsinyasiHidden.CurrentValue;
                    MultipleTujuanKonsinyasiHidden.ViewCustomAttributes = "";

                    // MultipleQuantity
                    MultipleQuantity.ViewValue = ConvertToString(MultipleQuantity.CurrentValue); // DN
                    MultipleQuantity.ViewCustomAttributes = "";

                // NoShipment
                NoShipment.HrefValue = "";
                NoShipment.TooltipValue = "";

                // IdPipa
                IdPipa.HrefValue = "";
                IdPipa.TooltipValue = "";

                // TujuanKonsinyasiPipa
                TujuanKonsinyasiPipa.HrefValue = "";
                TujuanKonsinyasiPipa.TooltipValue = "";

                // QuantityKonsinyasiPipa
                QuantityKonsinyasiPipa.HrefValue = "";
                QuantityKonsinyasiPipa.TooltipValue = "";

                // TanggalSandar
                TanggalSandar.HrefValue = "";
                TanggalSandar.TooltipValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";
                TanggalDibuat.TooltipValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
                TanggalDiperbarui.TooltipValue = "";

                // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.HrefValue = "";
                MultipleTujuanKonsinyasi.TooltipValue = "";

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.HrefValue = "";
                MultipleTujuanKonsinyasiHidden.TooltipValue = "";

                // MultipleQuantity
                MultipleQuantity.HrefValue = "";
                MultipleQuantity.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // NoShipment
                NoShipment.SetupEditAttributes();
                if (!NoShipment.Raw)
                    NoShipment.AdvancedSearch.SearchValue = HtmlDecode(NoShipment.AdvancedSearch.SearchValue);
                NoShipment.EditValue = HtmlEncode(NoShipment.AdvancedSearch.SearchValue);
                NoShipment.PlaceHolder = RemoveHtml(NoShipment.Caption);

                // IdPipa
                IdPipa.SetupEditAttributes();
                string curVal7 = ConvertToString(IdPipa.AdvancedSearch.SearchValue);
                if (IdPipa.Lookup != null && IsDictionary(IdPipa.Lookup?.Options) && IdPipa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPipa.EditValue = IdPipa.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk7 = "";
                    if (curVal7 == "") {
                        filterWrk7 = "0=1";
                    } else {
                        filterWrk7 = SearchFilter(IdPipa.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdPipa.AdvancedSearch.SearchValue, IdPipa.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                    }
                    string? sqlWrk7 = IdPipa.Lookup?.GetSql(true, filterWrk7, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdPipa.EditValue = rswrk7;
                }
                IdPipa.PlaceHolder = RemoveHtml(IdPipa.Caption);

                // TujuanKonsinyasiPipa
                TujuanKonsinyasiPipa.SetupEditAttributes();
                if (!TujuanKonsinyasiPipa.Raw)
                    TujuanKonsinyasiPipa.AdvancedSearch.SearchValue = HtmlDecode(TujuanKonsinyasiPipa.AdvancedSearch.SearchValue);
                TujuanKonsinyasiPipa.EditValue = HtmlEncode(TujuanKonsinyasiPipa.AdvancedSearch.SearchValue);
                TujuanKonsinyasiPipa.PlaceHolder = RemoveHtml(TujuanKonsinyasiPipa.Caption);

                // QuantityKonsinyasiPipa
                QuantityKonsinyasiPipa.SetupEditAttributes();
                if (!QuantityKonsinyasiPipa.Raw)
                    QuantityKonsinyasiPipa.AdvancedSearch.SearchValue = HtmlDecode(QuantityKonsinyasiPipa.AdvancedSearch.SearchValue);
                QuantityKonsinyasiPipa.EditValue = HtmlEncode(QuantityKonsinyasiPipa.AdvancedSearch.SearchValue);
                QuantityKonsinyasiPipa.PlaceHolder = RemoveHtml(QuantityKonsinyasiPipa.Caption);

                // TanggalSandar
                TanggalSandar.SetupEditAttributes();
                TanggalSandar.EditValue = FormatDateTime(UnformatDateTime(TanggalSandar.AdvancedSearch.SearchValue, TanggalSandar.FormatPattern), TanggalSandar.FormatPattern);
                TanggalSandar.PlaceHolder = RemoveHtml(TanggalSandar.Caption);
                TanggalSandar.SetupEditAttributes();
                TanggalSandar.EditValue2 = FormatDateTime(UnformatDateTime(TanggalSandar.AdvancedSearch.SearchValue2, TanggalSandar.FormatPattern), TanggalSandar.FormatPattern);
                TanggalSandar.PlaceHolder = RemoveHtml(TanggalSandar.Caption);

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

                // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.SetupEditAttributes();
                MultipleTujuanKonsinyasi.EditValue = MultipleTujuanKonsinyasi.Options(true);
                MultipleTujuanKonsinyasi.PlaceHolder = RemoveHtml(MultipleTujuanKonsinyasi.Caption);

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.SetupEditAttributes();
                if (!MultipleTujuanKonsinyasiHidden.Raw)
                    MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchValue = HtmlDecode(MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchValue);
                MultipleTujuanKonsinyasiHidden.EditValue = HtmlEncode(MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchValue);
                MultipleTujuanKonsinyasiHidden.PlaceHolder = RemoveHtml(MultipleTujuanKonsinyasiHidden.Caption);

                // MultipleQuantity
                MultipleQuantity.SetupEditAttributes();
                if (!MultipleQuantity.Raw)
                    MultipleQuantity.AdvancedSearch.SearchValue = HtmlDecode(MultipleQuantity.AdvancedSearch.SearchValue);
                MultipleQuantity.EditValue = HtmlEncode(MultipleQuantity.AdvancedSearch.SearchValue);
                MultipleQuantity.PlaceHolder = RemoveHtml(MultipleQuantity.Caption);
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
            if (!CheckDate(ConvertToString(TanggalSandar.AdvancedSearch.SearchValue), TanggalSandar.FormatPattern)) {
                TanggalSandar.AddErrorMessage(TanggalSandar.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalSandar.AdvancedSearch.SearchValue2), TanggalSandar.FormatPattern)) {
                TanggalSandar.AddErrorMessage(TanggalSandar.GetErrorMessage(false));
            }
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
            NoShipment.AdvancedSearch.Load();
            IdPipa.AdvancedSearch.Load();
            TujuanKonsinyasiPipa.AdvancedSearch.Load();
            QuantityKonsinyasiPipa.AdvancedSearch.Load();
            TanggalSandar.AdvancedSearch.Load();
            TanggalDibuat.AdvancedSearch.Load();
            TanggalDiperbarui.AdvancedSearch.Load();
            MultipleTujuanKonsinyasi.AdvancedSearch.Load();
            MultipleTujuanKonsinyasiHidden.AdvancedSearch.Load();
            MultipleQuantity.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("PenyaluranList")), "", TableVar, true);
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
