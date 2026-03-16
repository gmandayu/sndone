using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterTangkiList
    /// </summary>
    public static MasterTangkiList masterTangkiList
    {
        get => HttpData.Get<MasterTangkiList>("masterTangkiList")!;
        set => HttpData["masterTangkiList"] = value;
    }

    /// <summary>
    /// Page class for MasterTangki
    /// </summary>
    public class MasterTangkiList : MasterTangkiListBase
    {
        // Constructor
        public MasterTangkiList(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterTangkiList() : base()
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
    public class MasterTangkiListBase : MasterTangki
    {
        // Page ID
        public string PageID = "list";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterTangkiList";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fMasterTangkilist";

        public string FormActionName = "";

        public string FormBlankRowName = "";

        public string FormKeyCountName = "";

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
        public MasterTangkiListBase(Controller? controller)
        {
            TableName = "MasterTangki";

            // CSS class name as context
            TableVar = "MasterTangki";
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Fixed header table
            if (!UseCustomTemplate)
                SetFixedHeaderTable(Config.UseFixedHeaderTable, Config.FixedHeaderTableHeight);
            FormActionName = Config.FormRowActionName;
            FormBlankRowName = Config.FormBlankRowName;
            FormKeyCountName = Config.FormKeyCountName;

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // CSS class name as context
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Language object
            Language = ResolveLanguage();

            // Table object (masterTangki)
            if (masterTangki == null || masterTangki is MasterTangki)
                masterTangki = this;

            // Initialize URLs
            AddUrl = "MasterTangkiAdd";
            InlineAddUrl = PageUrl + "action=add";
            GridAddUrl = PageUrl + "action=gridadd";
            GridEditUrl = PageUrl + "action=gridedit";
            MultiEditUrl = PageUrl + "action=multiedit";
            MultiDeleteUrl = "MasterTangkiDelete";
            MultiUpdateUrl = "MasterTangkiUpdate";

            // Start time
            StartTime = Environment.TickCount;

            // Debug message
            LoadDebugMessage();

            // Open connection
            Conn = Connection; // DN

            // Other options
            OtherOptions["addedit"] = new() {
                TagClassName = "ew-add-edit-option",
                UseDropDownButton = false,
                DropDownButtonPhrase = "ButtonAddEdit",
                UseButtonGroup = true
            };

            // Other options
            OtherOptions["detail"] = new() { TagClassName = "ew-detail-option" };
            OtherOptions["action"] = new() { TagClassName = "ew-action-option" };

            // Column visibility
            OtherOptions["column"] = new() {
                TableVar = TableVar,
                TagClassName = "ew-columns-option",
                ButtonGroupClass = "ew-column-dropdown",
                UseDropDownButton = true,
                DropDownButtonPhrase = "Columns",
                DropDownAutoClose = "outside",
                UseButtonGroup = false
            };
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
        public string PageName => "MasterTangkiList";

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

        // Update URLs
        public string InlineAddUrl = "";

        public string GridAddUrl = "";

        public string GridEditUrl = "";

        public string MultiEditUrl = "";

        public string MultiDeleteUrl = "";

        public string MultiUpdateUrl = "";

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
            NamaTerminal.SetVisibility();
            Plant.SetVisibility();
            Sloc.SetVisibility();
            SeqTangki.SetVisibility();
            MatNo.SetVisibility();
            TglKalibrasi.SetVisibility();
            ExpDate.SetVisibility();
            Status.SetVisibility();
            TinggiMejaUk.SetVisibility();
            MaxDipping.SetVisibility();
            MaxCapacity.SetVisibility();
            UnpumpableQty.SetVisibility();
            PumpableQty.SetVisibility();
            etlDate.Visible = false;
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
        }

        // Constructor
        public MasterTangkiListBase() : this(null) { }

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
                        result.Add("view", pageName == "MasterTangkiView" ? "1" : "0"); // If View page, no primary button
                    }
                    else
                    {
                        result.Add("error", FailureMessage); // List page should not be shown as modal => error
                        ClearFailureMessage();
                    }
                return Controller.Json(result);
        }

        /// <summary>
        /// Run chart
        /// </summary>
        /// <param name="chartVar">Chart variable name</param>
        /// <returns>Page result</returns>
        public async Task<IActionResult> RunChart(string chartVar = "") { // DN
            IActionResult res = await Run();
            DbChart? chart = ChartByParam(chartVar);
            if (!IsTerminated && chart != null) {
                string chartClass = (chart.PageBreakType == "before") ? "ew-chart-bottom" : "ew-chart-top";
                int chartWidth = Query.TryGetValue("width", out StringValues sv) ? ConvertToInt(sv) : -1;
                int chartHeight = Query.TryGetValue("height", out StringValues sv2) ? ConvertToInt(sv2) : -1;
                return Controller.Content(ConvertToString(await chart.Render(chartClass, chartWidth, chartHeight)), "text/html", Encoding.UTF8);
            }
            return res;
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

        // Properties
        private Pager? _pager; // DN

        public int SelectedCount = 0;

        public int SelectedIndex = 0;

        public int DisplayRecords = 10; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public string PageSizes = "10,20,50,100,-1"; // Page sizes (comma separated)

        public string DefaultSearchWhere = ""; // Default search WHERE clause

        public string SearchWhere = ""; // Search WHERE clause

        public string SearchPanelClass = "ew-search-panel collapse show"; // Search panel class

        public int SearchColumnCount = 0; // For extended search

        public int SearchFieldsPerRow = 1; // For extended search

        public int RecordCount = 0; // Record count

        public int InlineRowCount = 0;

        public int StartRowCount = 1;

        public List<Tuple<string, Dictionary<string, string>>> Attributes = new(); // Row attributes and cell attributes

        public object RowIndex = 0; // Row index

        public int KeyCount = 0; // Key count

        public string MultiColumnGridClass = "row-cols-md";

        public string MultiColumnEditClass = "col-12 w-100";

        public string MultiColumnCardClass = "card h-100 ew-card";

        public string MultiColumnListOptionsPosition = "bottom-start";

        public string DbMasterFilter = ""; // Master filter

        public string DbDetailFilter = ""; // Detail filter

        public bool MasterRecordExists;

        public string MultiSelectKey = "";

        public string UserAction = ""; // User action

        public bool RestoreSearch = false;

        public SubPages? DetailPages; // Detail pages object

        public DbDataReader? Recordset;

        public string TopContentClass = "ew-top";

        public string MiddleContentClass = "ew-middle";

        public string BottomContentClass = "ew-bottom";

        public List<string> RecordKeys = [];

        public bool IsModal = false;

        private string FilterForModalActions = "";

        private bool UseInfiniteScroll = false;

        // Pager
        public Pager Pager
        {
            get {
                _pager ??= new PrevNextPager(this, StartRecord, RecordsPerPage, TotalRecords, PageSizes, RecordRange, AutoHidePager, AutoHidePageSizeSelector);
                return _pager;
            }
        }

        /// <summary>
        /// Load recordset from filter
        /// <param name="filter">Record filter</param>
        /// </summary>
        public async Task LoadRecordsetFromFilter(string filter)
        {
            // Set up list options
            await SetupListOptions();

            // Search options
            SetupSearchOptions();

            // Other options
            SetupOtherOptions();

            // Set visibility
            SetVisibility();

            // Load recordset
            TotalRecords = LoadRecordCount(filter);
            StartRecord = 1;
            StopRecord = DisplayRecords;
            CurrentFilter = filter;
            Recordset = await LoadRecordset();
        }

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            // --- BEGIN include dipindah ke helper yang bisa return IActionResult ---
            var beginResult = await PageRunBeginAsync();
            if (beginResult != null)
                return beginResult;

            // --- Initial setup ---
            PrepareInitialSettings();

            // --- Process list actions (for list pages) ---
            var listActionResult = await ProcessListActionsIfNeeded();
            if (listActionResult != null)
                return listActionResult;

            // --- Setup display and commands ---
            SetupDisplayAndCommands();

            // --- Handle import (if applicable) ---
            var importResult = await HandleImportIfNeeded();
            if (importResult != null)
                return importResult;

            // --- Process inline actions ---
            var inlineResult = await ProcessInlineActions();
            if (inlineResult != null)
                return inlineResult;

            // --- Setup options visibility ---
            SetupOptionsVisibility();

            // --- Process search and filters ---
            var searchResult = await ProcessSearchAndFilters();
            if (searchResult != null)
                return searchResult;

            // --- Build filter and load records ---
            var recordResult = await BuildFilterAndLoadRecords();
            if (recordResult != null)
                return recordResult;

            // --- Handle API requests ---
            var apiResult = await HandleApiRequests();
            if (apiResult != null)
                return apiResult;

            // --- Final setup ---
            FinalSetup();

            // --- END include ---
            PageRunEnd();
            return PageResult();
        }

        // ================== GENERATED HELPERS ==================
        private void PrepareInitialSettings()
        {
            // Multi column button position
            MultiColumnListOptionsPosition = Config.MultiColumnListOptionsPosition;
            if (Empty(DashboardReport))
                DashboardReport = Param(Config.PageDashboard);

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fMasterTangkigrid";

            // Set up infinite scroll
            UseInfiniteScroll = Param<bool>("infinitescroll");

            // Set up Dashboard Filter
            if (!Empty(DashboardReport))
                AddFilter(ref Filter, GetDashboardFilter(DashboardReport, TableVar));

            // Get command
            Command = Get("cmd").ToLower();
        }

        private async Task<IActionResult?> ProcessListActionsIfNeeded()
        {
            // Process list action first
            var result = await ProcessListAction();
            if (result is not EmptyResult) // Ajax request
                return result;
            return null;
        }

        private void SetupDisplayAndCommands()
        {
            // Set up records per page
            SetupDisplayRecords();

            // Handle reset command
            ResetCommand();

            // Set up Breadcrumb
            if (!IsExport())
                SetupBreadcrumb();
        }

        private async Task<IActionResult?> HandleImportIfNeeded()
        {
            await Task.CompletedTask; // Satisfy async requirement
            return null;
        }

        private async Task<IActionResult?> ProcessInlineActions()
        {
            await Task.CompletedTask; // Satisfy async requirement
            return null;
        }

        private void SetupOptionsVisibility()
        {
            // Hide list options
            if (IsExport()) {
                ListOptions.HideAllOptions(["sequence"]);
                ListOptions.UseDropDownButton = false; // Disable drop down button
                ListOptions.UseButtonGroup = false; // Disable button group
            } else if (IsGridAdd || IsGridEdit || IsMultiEdit || IsConfirm) {
                ListOptions.HideAllOptions();
                ListOptions.UseDropDownButton = false; // Disable drop down button
                ListOptions.UseButtonGroup = false; // Disable button group
            }

            // Hide options
            if (IsExport() || !(Empty(CurrentAction) || IsSearch)) {
                ExportOptions.HideAllOptions();
                FilterOptions.HideAllOptions();
                ImportOptions.HideAllOptions();
            }

            // Hide other options
            if (IsExport()) {
                foreach (var (key, value) in OtherOptions)
                    value.HideAllOptions();
            }
        }

        private async Task<IActionResult?> ProcessSearchAndFilters()
        {
            // Initialize search variables
            var searchContext = InitializeSearchContext();

            // Setup default search criteria
            SetupDefaultSearchCriteria();

            // Load and validate search values
            await LoadAndValidateSearchValues();

            // Process filter list - early return if needed
            var filterResult = await ProcessFilterList();
            if (filterResult != null) {
                if (!Config.Debug)
                    Response?.Clear();
                return Controller.Json(filterResult);
            }

            // Handle search parameters and events
            HandleSearchParametersAndEvents();

            // Process search criteria and build filters
            ProcessSearchCriteriaAndBuildFilters(searchContext);
            return null;
        }

        private SearchContext InitializeSearchContext()
        {
            return new SearchContext
            {
                SrchAdvanced = "",
                SrchBasic = "",
                Query = ""
            };
        }

        private void SetupDefaultSearchCriteria()
        {
            AddFilter(ref DefaultSearchWhere, BasicSearchWhere(true));
            AddFilter(ref DefaultSearchWhere, AdvancedSearchWhere(true));
        }

        private async Task LoadAndValidateSearchValues()
        {
            await Task.CompletedTask; // Satisfy async requirement
            LoadBasicSearchValues();
            if (Empty(UserAction))
                LoadSearchValues();
        }

        private void HandleSearchParametersAndEvents()
        {
            CurrentForm?.ResetIndex();
            if (!ValidateSearch()) {
                // Nothing to do
            }

            // Restore search parms from Session if not searching / reset / export
            if ((IsExport() || Command != "search" && Command != "reset" && Command != "resetall") && Command != "json" && CheckSearchParms())
                RestoreSearchParms();
            RecordsetSearchValidated();

            // Set up sorting order
            SetupSortOrder();
        }

        private void ProcessSearchCriteriaAndBuildFilters(SearchContext searchContext)
        {
            // Get search criteria
            GetSearchCriteria(searchContext);

            // Restore display records
            RestoreDisplayRecords();

            // Load search defaults if needed
            LoadSearchDefaultsIfNeeded(searchContext);

            // Restore advanced search settings
            RestoreAdvancedSearchSettings();

            // Build and save search criteria
            BuildAndSaveSearchCriteria(searchContext);
        }

        private void GetSearchCriteria(SearchContext searchContext)
        {
            if (!HasInvalidFields())
                searchContext.SrchBasic = BasicSearchWhere();
            if (!HasInvalidFields())
                searchContext.SrchAdvanced = AdvancedSearchWhere();
            searchContext.Query = !Empty(DashboardReport) ? "" : QueryBuilderWhere();
        }

        private void RestoreDisplayRecords()
        {
            if (Command != "json" && (RecordsPerPage == -1 || RecordsPerPage > 0)) {
                DisplayRecords = RecordsPerPage;
            } else {
                DisplayRecords = 10;
                RecordsPerPage = DisplayRecords;
            }
        }

        private void LoadSearchDefaultsIfNeeded(SearchContext searchContext)
        {
            if (!CheckSearchParms() && Empty(searchContext.Query)) {
                BasicSearch.LoadDefault();
                if (!Empty(BasicSearch.Keyword))
                    searchContext.SrchBasic = BasicSearchWhere();
                if (LoadAdvancedSearchDefault())
                    searchContext.SrchAdvanced = AdvancedSearchWhere();
            }
        }

        private void RestoreAdvancedSearchSettings()
        {
            if (!HasInvalidFields())
                LoadAdvancedSearch();
        }

        private void BuildAndSaveSearchCriteria(SearchContext searchContext)
        {
            // Build search criteria
            if (!Empty(searchContext.Query)) {
                AddFilter(ref SearchWhere, searchContext.Query);
            } else {
                AddFilter(ref SearchWhere, searchContext.SrchAdvanced);
                AddFilter(ref SearchWhere, searchContext.SrchBasic);
            }
            RecordsetSearching(ref SearchWhere);

            // Save search criteria
            if (Command == "search" && !RestoreSearch) {
                SessionSearchWhere = SearchWhere;
                StartRecord = 1;
                StartRecordNumber = StartRecord;
            } else if (Command != "json" && Empty(searchContext.Query)) {
                SearchWhere = SessionSearchWhere;
            }
        }

        // Support class
        private sealed class SearchContext
        {
            public string SrchAdvanced { get; set; } = "";

            public string SrchBasic { get; set; } = "";

            public string Query { get; set; } = "";
        }

        private async Task<IActionResult?> BuildFilterAndLoadRecords()
        {
            await Task.CompletedTask; // Satisfy async requirement

            // Build filter
            if (!Security.CanList)
                Filter = "(0=1)"; // Filter all records
            AddFilter(ref Filter, DbDetailFilter);
            AddFilter(ref Filter, SearchWhere);

            // Load master records and handle early returns
            var masterResult = await LoadMasterRecords();
            if (masterResult != null)
                return masterResult;

            // Set up filter and load recordset
            SetupFilterAndRecordset();

            // Load recordset based on mode
            await LoadRecordsetByMode();

            // Setup list actions and load records
            await SetupListActionsAndRecords();
            return null;
        }

        private async Task<IActionResult?> LoadMasterRecords()
        {
            await Task.CompletedTask; // Satisfy async requirement
            return null;
        }

        private void SetupFilterAndRecordset()
        {
            // Set up filter
            if (Command == "json") {
                UseSessionForListSql = false; // Do not use session for ListSql
                CurrentFilter = Filter;
            } else {
                SessionWhere = Filter;
                CurrentFilter = "";
            }
            Filter = ApplyUserIDFilters(Filter);
        }

        private async Task LoadRecordsetByMode()
        {
            if (IsGridAdd) {
                await LoadRecordsetForGridAdd();
            } else if ((IsEdit || IsCopy || IsInlineInserted || IsInlineUpdated) && UseInfiniteScroll) {
                await LoadRecordsetForInlineOperations();
            } else if (UseInfiniteScroll && IsGridInserted ||
                       UseInfiniteScroll && (IsGridEdit || IsGridUpdated) ||
                       IsMultiEdit ||
                       UseInfiniteScroll && IsMultiUpdated) {
                await LoadRecordsetForModalActions();
            } else {
                await LoadRecordsetNormal();
            }
        }

        private async Task LoadRecordsetForGridAdd()
        {
            await Task.CompletedTask; // Satisfy async requirement
            CurrentFilter = "0=1";
            StartRecord = 1;
            DisplayRecords = GridAddRowCount;
            TotalRecords = DisplayRecords;
            StopRecord = DisplayRecords;
        }

        private async Task LoadRecordsetForInlineOperations()
        {
            // Get current record only
            CurrentFilter = IsInlineUpdated ? GetRecordFilter() : GetFilterFromRecordKeys();
            TotalRecords = ListRecordCount();
            StartRecord = 1;
            StopRecord = DisplayRecords;
            Recordset = await LoadRecordset();
        }

        private async Task LoadRecordsetForModalActions()
        {
            // Get current records only
            CurrentFilter = FilterForModalActions; // Restore filter
            TotalRecords = ListRecordCount();
            StartRecord = 1;
            StopRecord = DisplayRecords;
            Recordset = await LoadRecordset();
        }

        private async Task LoadRecordsetNormal()
        {
            TotalRecords = await ListRecordCountAsync();
            StopRecord = DisplayRecords;
            StartRecord = 1;
            if (DisplayRecords <= 0 || (IsExport() && ExportAll)) // Display all records
                DisplayRecords = TotalRecords;
            if (!(IsExport() && ExportAll)) // Set up start record position
                SetupStartRecord();
        }

        private async Task SetupListActionsAndRecords()
        {
            // Recordset
            bool selectLimit = UseSelectLimit;

            // Set up list action columns, must be before LoadRecordset // DN
            foreach (var (key, act) in ListActions.Items.Where(kvp => kvp.Value.Allowed)) {
                if (act.Select == Config.ActionMultiple && ListOptions["checkbox"] is ListOption listOpt) { // Show checkbox column if multiple action
                    listOpt.Visible = true;
                } else if (act.Select == Config.ActionSingle) { // Show list action column
                        ListOptions["listactions"]?.SetVisible(true); // Set visible if any list action is allowed
                }
            }
            if (selectLimit)
                Recordset = await LoadRecordset(StartRecord - 1, DisplayRecords);

            // Set no record found message
            if ((Empty(CurrentAction) || IsSearch) && TotalRecords == 0) {
                if (!Security.CanList)
                    WarningMessage = DeniedMessage();
                if (SearchWhere == "0=101")
                    WarningMessage = Language.Phrase("EnterSearchCriteria");
                else
                    WarningMessage = Language.Phrase("NoRecord");
            }
        }

        private async Task<IActionResult?> HandleApiRequests()
        {
            SetupSearchOptionsAndPanel();
            HandleCustomTemplateLayout();
            return await ProcessApiRequest();
        }

        private void SetupSearchOptionsAndPanel()
        {
            // Search options
            SetupSearchOptions();

            // Set up search panel class
            if (!Empty(SearchWhere)) {
                SetupSearchPanelClass();
            }
        }

        private void SetupSearchPanelClass()
        {
            string query = !Empty(DashboardReport) ? "" : QueryBuilderWhere();
            if (!Empty(query)) {
                SearchPanelClass = RemoveClass(SearchPanelClass, "show");
            } else {
                SearchPanelClass = AppendClass(SearchPanelClass, "show");
            }
        }

        private void HandleCustomTemplateLayout()
        {
            // No custom template handling needed
        }

        private async Task<IActionResult?> ProcessApiRequest()
        {
            if (!IsApi())
                return null;
            if (CurrentPageName().ToLowerInvariant().EndsWith(Config.ApiListAction)) {
                return await HandleApiListAction();
            } else if (!Empty(FailureMessage)) {
                return Controller.Json(new { success = false, error = GetFailureMessage() });
            }
            return new EmptyResult();
        }

        private async Task<IActionResult> HandleApiListAction()
        {
            if (IsExport())
                return new EmptyResult();
            await MoveToStartRecord();
            using (Recordset) {
                return Controller.Json(new Dictionary<string, object> { 
                    {"success", true}, 
                    {TableVar, await GetRecordsFromRecordset(Recordset)}, 
                    {"totalRecordCount", TotalRecords}, 
                    {"version", Config.ProductVersion} 
                });
            }
        }

        private async Task MoveToStartRecord()
        {
            if (!Connection.SelectOffset && Recordset != null) {
                for (var i = 1; i <= StartRecord - 1; i++)
                    await Recordset.ReadAsync();
            }
        }

        private void FinalSetup()
        {
            // Render other options
            RenderOtherOptions();

            // Set ReturnUrl in header if necessary
            if (TempData["Return-Url"] != null)
                AddHeader("Return-Url", ConvertToString(TempData["Return-Url"]));
        }

        // ===== Wrap includes ke helper =====
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

            // Get export parameters
            string custom = "";
            if (!Empty(Param("export"))) {
                Export = Param("export");
                custom = Param("custom");
            } else {
                ExportReturnUrl = CurrentUrl();
            }
            ExportType = Export; // Get export parameter, used in header
            if (!Empty(ExportType))
                SkipHeaderFooter = true;
            if (!Empty(Export) && !SameText(Export, "print") && Empty(custom)) // No layout for export // DN
                UseLayout = false;
            CurrentAction = Param("action"); // Set up current action

            // Get grid add count
            int gridaddcnt = Get<int>(Config.TableGridAddRowCount);
            if (gridaddcnt > 0)
                GridAddRowCount = gridaddcnt;

            // Set up list options
            await SetupListOptions();

            // Setup export options
            SetupExportOptions();
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

            // Setup other options
            SetupOtherOptions();

            // Set up lookup cache
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(Status);
            return null; // kalau include tidak melakukan return
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
                masterTangkiList?.PageRender();
            }
        }
        #pragma warning restore 219

        // Get page number
        public int PageNumber => DisplayRecords > 0 && StartRecord > 0 ? ConvertToInt(Math.Ceiling((double)StartRecord / DisplayRecords)) : 1;

        // Set up number of records displayed per page
        protected void SetupDisplayRecords() {
            string wrk = Get(Config.TableRecordsPerPage);
            if (!Empty(wrk)) {
                if (IsNumeric(wrk)) {
                    DisplayRecords = ConvertToInt(wrk);
                } else {
                    if (SameText(wrk, "all")) { // Display all records
                        DisplayRecords = -1;
                    } else {
                        DisplayRecords = 10; // Non-numeric, load default
                    }
                }
                RecordsPerPage = DisplayRecords; // Save to Session
                // Reset start position
                StartRecord = 1;
                StartRecordNumber = StartRecord;
            }
        }

        // Build filter for all keys
        protected string BuildKeyFilter() {
            string wrkFilter = "";

            // Update row index and get row key
            int rowindex = 1;
            CurrentForm!.Index = rowindex;
            string thisKey = CurrentForm.GetValue(OldKeyName);
            while (!Empty(thisKey)) {
                SetKey(thisKey);
                if (!Empty(OldKey)) {
                    string filter = GetRecordFilter();
                    if (!Empty(wrkFilter))
                        wrkFilter += " OR ";
                    wrkFilter += filter;
                } else {
                    wrkFilter = "0=1";
                    break;
                }

                // Update row index and get row key
                rowindex++; // next row
                CurrentForm!.Index = rowindex;
                thisKey = CurrentForm.GetValue(OldKeyName);
            }
            return wrkFilter;
        }

        // Check if empty row
        public bool EmptyRow() => false;

        #pragma warning disable 162, 1998
        // Get list of filters
        public string GetFilterList()
        {
            string filterList = "";

            // Initialize
            var filters = new JObject(); // DN
            filters.Merge(JObject.Parse(TglKalibrasi.AdvancedSearch.ToJson())); // Field TglKalibrasi
            filters.Merge(JObject.Parse(ExpDate.AdvancedSearch.ToJson())); // Field ExpDate
            filters.Merge(JObject.Parse(etlDate.AdvancedSearch.ToJson())); // Field etlDate
            filters.Merge(JObject.Parse(lastUpdatedDate.AdvancedSearch.ToJson())); // Field lastUpdatedDate
            filters.Merge(JObject.Parse(BasicSearch.ToJson()));

            // Return filter list in JSON
            if (filters.HasValues)
                filterList = "\"data\":" + filters.ToString();
            return (filterList != "") ? "{" + filterList + "}" : "null";
        }

        // Process filter list
        protected async Task<object?> ProcessFilterList() {
            if (Post("cmd") == "resetfilter") {
                RestoreFilterList();
            }
            return null;
        }
        #pragma warning restore 162, 1998

        // Restore list of filters
        protected bool RestoreFilterList() {
            // Return if not reset filter
            if (Post("cmd") != "resetfilter")
                return false;
            var filter = JsonConvert.DeserializeObject<Dictionary<string, string>>(Post("filter"));
            Command = "search";

            // Process field filters
            ProcessFieldFilters(filter);

            // Process basic search and query builder
            ProcessAdditionalFilters(filter);
            return true;
        }

        private void ProcessFieldFilters(Dictionary<string, string>? filter)
        {
            if (filter == null) return;
            string? sv;

            // Field TglKalibrasi
            if (filter.TryGetValue("x_TglKalibrasi", out sv)) {
                RestoreFieldFilter(TglKalibrasi, filter, "TglKalibrasi", sv);
            }

            // Field ExpDate
            if (filter.TryGetValue("x_ExpDate", out sv)) {
                RestoreFieldFilter(ExpDate, filter, "ExpDate", sv);
            }

            // Field etlDate
            if (filter.TryGetValue("x_etlDate", out sv)) {
                RestoreFieldFilter(etlDate, filter, "etlDate", sv);
            }

            // Field lastUpdatedDate
            if (filter.TryGetValue("x_lastUpdatedDate", out sv)) {
                RestoreFieldFilter(lastUpdatedDate, filter, "lastUpdatedDate", sv);
            }
        }

        private void RestoreFieldFilter(dynamic field, Dictionary<string, string> filter, string fieldParm, string searchValue)
        {
            field.AdvancedSearch.SearchValue = searchValue;
            field.AdvancedSearch.SearchOperator = filter.GetValueOrDefault($"z_{fieldParm}", "");
            field.AdvancedSearch.SearchCondition = filter.GetValueOrDefault($"v_{fieldParm}", "");
            field.AdvancedSearch.SearchValue2 = filter.GetValueOrDefault($"y_{fieldParm}", "");
            field.AdvancedSearch.SearchOperator2 = filter.GetValueOrDefault($"w_{fieldParm}", "");
            field.AdvancedSearch.Save();
        }

        private void ProcessAdditionalFilters(Dictionary<string, string>? filter)
        {
            if (filter == null) return;
            if (filter.TryGetValue(Config.TableBasicSearch, out string? keyword))
                BasicSearch.SessionKeyword = keyword;
            if (filter.TryGetValue(Config.TableBasicSearchType, out string? type))
                BasicSearch.SessionType = type;
        }

        // Advanced search WHERE clause based on QueryString
        public string AdvancedSearchWhere(bool def = false) {
            string where = "";
            if (!Security.CanSearch)
                return "";
            BuildSearchSql(ref where, NamaTerminal, def, true); // NamaTerminal
            BuildSearchSql(ref where, Plant, def, true); // Plant
            BuildSearchSql(ref where, Sloc, def, true); // Sloc
            BuildSearchSql(ref where, SeqTangki, def, true); // SeqTangki
            BuildSearchSql(ref where, MatNo, def, true); // MatNo
            BuildSearchSql(ref where, TglKalibrasi, def, true); // TglKalibrasi
            BuildSearchSql(ref where, ExpDate, def, true); // ExpDate
            BuildSearchSql(ref where, Status, def, true); // Status
            BuildSearchSql(ref where, TinggiMejaUk, def, true); // TinggiMejaUk
            BuildSearchSql(ref where, MaxDipping, def, true); // MaxDipping
            BuildSearchSql(ref where, MaxCapacity, def, true); // MaxCapacity
            BuildSearchSql(ref where, UnpumpableQty, def, true); // UnpumpableQty
            BuildSearchSql(ref where, PumpableQty, def, true); // PumpableQty
            BuildSearchSql(ref where, etlDate, def, true); // etlDate
            BuildSearchSql(ref where, LastUpdatedBy, def, true); // LastUpdatedBy
            BuildSearchSql(ref where, lastUpdatedDate, def, true); // lastUpdatedDate

            // Set up search command
            if (!def && !Empty(where) && (new[] { "", "reset", "resetall" }).Contains(Command))
                Command = "search";
            if (!def && Command == "search") {
                TglKalibrasi.AdvancedSearch.Save(); // TglKalibrasi
                ExpDate.AdvancedSearch.Save(); // ExpDate
                etlDate.AdvancedSearch.Save(); // etlDate
                lastUpdatedDate.AdvancedSearch.Save(); // lastUpdatedDate

                // Clear rules for QueryBuilder
                SessionRules = "";
            }
            return where;
        }

        /// <summary>
        /// Get Query Builder rules
        /// </summary>
        /// <returns>Query Builder rules</returns>
        private string QueryBuilderRules()
        {
            string rules = "";
            if (Post("rules", out StringValues sv))
                rules = sv.ToString();
            else
                rules = SessionRules;
            return rules;
        }

        // Quey builder WHERE clause
        public string QueryBuilderWhere(string fieldName = "")
        {
            if (!Security.CanSearch)
                return "";

            // Get rules by query builder
            string rules = QueryBuilderRules();

            // Decode and parse rules
            string where = !Empty(rules) ? ParseRules(JsonConvert.DeserializeObject<Dictionary<string, object>>(rules), fieldName) : "";

            // Clear other search and save rules to session
            if (!Empty(where) && Empty(fieldName)) { // Skip if get query for specific field
                ResetSearchParms();
                TglKalibrasi.AdvancedSearch.Save(); // TglKalibrasi
                ExpDate.AdvancedSearch.Save(); // ExpDate
                etlDate.AdvancedSearch.Save(); // etlDate
                lastUpdatedDate.AdvancedSearch.Save(); // lastUpdatedDate
                SessionRules = rules;
            }

            // Return query
            return where;
        }

        // Build search SQL
        public void BuildSearchSql(ref string where, DbField fld, bool def, bool multiValue)
        {
            var searchParams = ExtractSearchParameters(fld, def);
            var processedParams = ProcessSearchParameters(searchParams, fld);
            if (ShouldUseMultiValue(multiValue, fld, processedParams.Operator))
            {
                var wrk = BuildMultiValueSearch(processedParams, fld);
                AddFilterToWhere(ref where, wrk);
            }
            else
            {
                var wrk = BuildStandardSearch(processedParams, fld);
                AddFilterToWhere(ref where, wrk);
            }
        }

        private SearchParameters ExtractSearchParameters(DbField fld, bool def)
        {
            return new SearchParameters
            {
                Value = def ? ConvertToString(fld.AdvancedSearch.SearchValueDefault) : ConvertToString(fld.AdvancedSearch.SearchValue),
                Operator = def ? fld.AdvancedSearch.SearchOperatorDefault : fld.AdvancedSearch.SearchOperator,
                Condition = def ? fld.AdvancedSearch.SearchConditionDefault : fld.AdvancedSearch.SearchCondition,
                Value2 = def ? ConvertToString(fld.AdvancedSearch.SearchValue2Default) : ConvertToString(fld.AdvancedSearch.SearchValue2),
                Operator2 = def ? fld.AdvancedSearch.SearchOperator2Default : fld.AdvancedSearch.SearchOperator2
            };
        }

        private ProcessedSearchParameters ProcessSearchParameters(SearchParameters searchParams, DbField fld)
        {
            return new ProcessedSearchParameters
            {
                Value = ConvertSearchValue(searchParams.Value, searchParams.Operator, fld),
                Value2 = ConvertSearchValue(searchParams.Value2, searchParams.Operator2, fld),
                Operator = ConvertSearchOperator(searchParams.Operator, fld, searchParams.Value),
                Operator2 = ConvertSearchOperator(searchParams.Operator2, fld, searchParams.Value2),
                Condition = searchParams.Condition
            };
        }

        private bool ShouldUseMultiValue(bool multiValue, DbField fld, string fldOpr)
        {
            if (Config.SearchMultiValueOption == 1 && !fld.UseFilter || !IsMultiSearchOperator(fldOpr))
                return false;
            return multiValue;
        }

        private string BuildMultiValueSearch(ProcessedSearchParameters processedParams, DbField fld)
        {
            string wrk = !Empty(processedParams.Value) ? GetMultiSearchSql(fld, processedParams.Operator, processedParams.Value, DbId) : "";
            string wrk2 = !Empty(processedParams.Value2) ? GetMultiSearchSql(fld, processedParams.Operator2, processedParams.Value2, DbId) : "";
            AddFilter(ref wrk, wrk2, processedParams.Condition);
            return wrk;
        }

        private string BuildStandardSearch(ProcessedSearchParameters processedParams, DbField fld)
        {
            return GetSearchSql(fld, processedParams.Value, processedParams.Operator, processedParams.Condition, processedParams.Value2, processedParams.Operator2, DbId);
        }

        private void AddFilterToWhere(ref string where, string wrk)
        {
            string cond = SearchOption == "AUTO" && (new[] { "AND", "OR" }).Contains(BasicSearch.Type)
                ? BasicSearch.Type
                : SameText(SearchOption, "OR") ? "OR" : "AND";
            AddFilter(ref where, wrk, cond);
        }

        // Support classes
        private sealed class SearchParameters
        {
            public string Value { get; set; } = "";

            public string Operator { get; set; } = "";

            public string Condition { get; set; } = "";

            public string Value2 { get; set; } = "";

            public string Operator2 { get; set; } = "";
        }

        private sealed class ProcessedSearchParameters
        {
            public string Value { get; set; } = "";

            public string Value2 { get; set; } = "";

            public string Operator { get; set; } = "";

            public string Operator2 { get; set; } = "";

            public string Condition { get; set; } = "";
        }

        // Show list of filters
        public void ShowFilterList()
        {
            var filterConfig = InitializeFilterConfiguration();
            string filterList = BuildAllFilters(filterConfig);
            RenderFilterList(filterList, filterConfig);
        }

        private FilterConfiguration InitializeFilterConfiguration()
        {
            return new FilterConfiguration
            {
                CaptionClass = IsExport("email") ? "ew-filter-caption-email" : "ew-filter-caption",
                CaptionSuffix = IsExport("email") ? ": " : ""
            };
        }

        private string BuildAllFilters(FilterConfiguration config)
        {
            string filterList = "";
            filterList += BuildFieldFilters(config);
            filterList += BuildBasicSearchFilter(config);
            return filterList;
        }

        private string BuildFieldFilters(FilterConfiguration config)
        {
            string filterList = "";
            filterList += ProcessFieldFilter("NamaTerminal", NamaTerminal, true, config);
            filterList += ProcessFieldFilter("Plant", Plant, true, config);
            filterList += ProcessFieldFilter("Sloc", Sloc, true, config);
            filterList += ProcessFieldFilter("SeqTangki", SeqTangki, true, config);
            filterList += ProcessFieldFilter("MatNo", MatNo, true, config);
            filterList += ProcessFieldFilter("TglKalibrasi", TglKalibrasi, true, config);
            filterList += ProcessFieldFilter("ExpDate", ExpDate, true, config);
            filterList += ProcessFieldFilter("Status", Status, true, config);
            filterList += ProcessFieldFilter("TinggiMejaUk", TinggiMejaUk, true, config);
            filterList += ProcessFieldFilter("MaxDipping", MaxDipping, true, config);
            filterList += ProcessFieldFilter("MaxCapacity", MaxCapacity, true, config);
            filterList += ProcessFieldFilter("UnpumpableQty", UnpumpableQty, true, config);
            filterList += ProcessFieldFilter("PumpableQty", PumpableQty, true, config);
            filterList += ProcessFieldFilter("LastUpdatedBy", LastUpdatedBy, true, config);
            filterList += ProcessFieldFilter("lastUpdatedDate", lastUpdatedDate, true, config);
            return filterList;
        }

        private string ProcessFieldFilter(string fieldName, dynamic field, bool multiSelect, FilterConfiguration config)
        {
            string filter = QueryBuilderWhere(fieldName);
            if (Empty(filter))
                BuildSearchSql(ref filter, field, false, multiSelect);
            if (!Empty(filter))
                return BuildFilterItem(field.Caption, filter, config);
            return "";
        }

        private string BuildBasicSearchFilter(FilterConfiguration config)
        {
            if (!Empty(BasicSearch.Keyword))
                return BuildFilterItem(Language.Phrase("BasicSearchKeyword"), BasicSearch.Keyword, config);
            return "";
        }

        private string BuildFilterItem(string caption, string filter, FilterConfiguration config)
        {
            return "<div><span class=\"" + config.CaptionClass + "\">" + caption + "</span>" + config.CaptionSuffix + filter + "</div>";
        }

        private void RenderFilterList(string filterList, FilterConfiguration config)
        {
            if (!Empty(filterList)) {
                RenderNonEmptyFilterList(filterList);
            } else {
                RenderEmptyFilterList();
            }
        }

        private void RenderNonEmptyFilterList(string filterList)
        {
            string message = "<div id=\"ew-filter-list\" class=\"callout callout-info d-table\"><div id=\"ew-current-filters\">" +
                Language.Phrase("CurrentFilters") + "</div>" + filterList + "</div>";
            MessageShowing(ref message, "");
            Write(message);
        }

        private void RenderEmptyFilterList()
        {
            Write("<div id=\"ew-filter-list\"></div>");
        }

        // Support class
        private sealed class FilterConfiguration
        {
            public string CaptionClass { get; set; } = "";

            public string CaptionSuffix { get; set; } = "";
        }

        // Return basic search WHERE clause based on search keyword and type
        public string BasicSearchWhere(bool def = false) {
            string searchStr = "";
            if (!Security.CanSearch)
                return "";

            // Fields to search
            List<DbField> searchFlds = [];
            searchFlds.Add(NamaTerminal);
            searchFlds.Add(Plant);
            searchFlds.Add(Sloc);
            searchFlds.Add(SeqTangki);
            searchFlds.Add(MatNo);
            searchFlds.Add(TglKalibrasi);
            searchFlds.Add(ExpDate);
            searchFlds.Add(Status);
            searchFlds.Add(TinggiMejaUk);
            searchFlds.Add(MaxDipping);
            searchFlds.Add(MaxCapacity);
            searchFlds.Add(UnpumpableQty);
            searchFlds.Add(PumpableQty);
            searchFlds.Add(etlDate);
            searchFlds.Add(LastUpdatedBy);
            searchFlds.Add(lastUpdatedDate);
            string searchKeyword = def ? BasicSearch.KeywordDefault : BasicSearch.Keyword;
            string searchType = def ? BasicSearch.TypeDefault : BasicSearch.Type;

            // Get search SQL
            if (!Empty(searchKeyword)) {
                List<string> list = BasicSearch.KeywordList(def);
                searchStr = GetQuickSearchFilter(searchFlds, list, searchType, BasicSearch.BasicSearchAnyFields, DbId);
                if (!def && (new[] { "", "reset", "resetall" }).Contains(Command))
                    Command = "search";
            }
            if (!def && Command == "search") {
                BasicSearch.SessionKeyword = searchKeyword;
                BasicSearch.SessionType = searchType;

                // Clear rules for QueryBuilder
                SessionRules = "";
            }
            return searchStr;
        }

        // Check if search parm exists
        protected bool CheckSearchParms() {
            // Check basic search
            if (BasicSearch.IssetSession)
                return true;
            if (NamaTerminal.AdvancedSearch.IssetSession)
                return true;
            if (Plant.AdvancedSearch.IssetSession)
                return true;
            if (Sloc.AdvancedSearch.IssetSession)
                return true;
            if (SeqTangki.AdvancedSearch.IssetSession)
                return true;
            if (MatNo.AdvancedSearch.IssetSession)
                return true;
            if (TglKalibrasi.AdvancedSearch.IssetSession)
                return true;
            if (ExpDate.AdvancedSearch.IssetSession)
                return true;
            if (Status.AdvancedSearch.IssetSession)
                return true;
            if (TinggiMejaUk.AdvancedSearch.IssetSession)
                return true;
            if (MaxDipping.AdvancedSearch.IssetSession)
                return true;
            if (MaxCapacity.AdvancedSearch.IssetSession)
                return true;
            if (UnpumpableQty.AdvancedSearch.IssetSession)
                return true;
            if (PumpableQty.AdvancedSearch.IssetSession)
                return true;
            if (etlDate.AdvancedSearch.IssetSession)
                return true;
            if (LastUpdatedBy.AdvancedSearch.IssetSession)
                return true;
            if (lastUpdatedDate.AdvancedSearch.IssetSession)
                return true;
            return false;
        }

        // Clear all search parameters
        protected void ResetSearchParms() {
            SearchWhere = "";
            SessionSearchWhere = SearchWhere;

            // Clear basic search parameters
            ResetBasicSearchParms();

            // Clear advanced search parameters
            ResetAdvancedSearchParms();

            // Clear queryBuilder
            SessionRules = "";
        }

        // Load advanced search default values
        protected bool LoadAdvancedSearchDefault() {
        return false;
        }

        // Clear all basic search parameters
        protected void ResetBasicSearchParms() {
            BasicSearch.UnsetSession();
        }

        // Clear all advanced search parameters
        protected void ResetAdvancedSearchParms() {
            NamaTerminal.AdvancedSearch.UnsetSession();
            Plant.AdvancedSearch.UnsetSession();
            Sloc.AdvancedSearch.UnsetSession();
            SeqTangki.AdvancedSearch.UnsetSession();
            MatNo.AdvancedSearch.UnsetSession();
            TglKalibrasi.AdvancedSearch.UnsetSession();
            ExpDate.AdvancedSearch.UnsetSession();
            Status.AdvancedSearch.UnsetSession();
            TinggiMejaUk.AdvancedSearch.UnsetSession();
            MaxDipping.AdvancedSearch.UnsetSession();
            MaxCapacity.AdvancedSearch.UnsetSession();
            UnpumpableQty.AdvancedSearch.UnsetSession();
            PumpableQty.AdvancedSearch.UnsetSession();
            etlDate.AdvancedSearch.UnsetSession();
            LastUpdatedBy.AdvancedSearch.UnsetSession();
            lastUpdatedDate.AdvancedSearch.UnsetSession();
        }

        // Restore all search parameters
        protected void RestoreSearchParms() {
            RestoreSearch = true;

            // Restore basic search values
            BasicSearch.Load();

            // Restore advanced search values
            NamaTerminal.AdvancedSearch.Load();
            Plant.AdvancedSearch.Load();
            Sloc.AdvancedSearch.Load();
            SeqTangki.AdvancedSearch.Load();
            MatNo.AdvancedSearch.Load();
            TglKalibrasi.AdvancedSearch.Load();
            ExpDate.AdvancedSearch.Load();
            Status.AdvancedSearch.Load();
            TinggiMejaUk.AdvancedSearch.Load();
            MaxDipping.AdvancedSearch.Load();
            MaxCapacity.AdvancedSearch.Load();
            UnpumpableQty.AdvancedSearch.Load();
            PumpableQty.AdvancedSearch.Load();
            etlDate.AdvancedSearch.Load();
            LastUpdatedBy.AdvancedSearch.Load();
            lastUpdatedDate.AdvancedSearch.Load();
        }

        // Set up sort parameters
        protected void SetupSortOrder() {
            // Load default Sorting Order
            if (Command != "json") {
                string defaultSort = ""; // Set up default sort
                if (Empty(SessionOrderBy) && !Empty(defaultSort))
                    SessionOrderBy = defaultSort;
            }

            // Check for Ctrl pressed
            bool ctrl = Get<bool>("ctrl");

            // Check for "order" parameter
            if (Get("order", out StringValues sv)) {
                CurrentOrder = sv.ToString();
                CurrentOrderType = Get("ordertype");
                UpdateSort(NamaTerminal, ctrl); // NamaTerminal
                UpdateSort(Plant, ctrl); // Plant
                UpdateSort(Sloc, ctrl); // Sloc
                UpdateSort(SeqTangki, ctrl); // SeqTangki
                UpdateSort(MatNo, ctrl); // MatNo
                UpdateSort(TglKalibrasi, ctrl); // TglKalibrasi
                UpdateSort(ExpDate, ctrl); // ExpDate
                UpdateSort(Status, ctrl); // Status
                UpdateSort(TinggiMejaUk, ctrl); // TinggiMejaUk
                UpdateSort(MaxDipping, ctrl); // MaxDipping
                UpdateSort(MaxCapacity, ctrl); // MaxCapacity
                UpdateSort(UnpumpableQty, ctrl); // UnpumpableQty
                UpdateSort(PumpableQty, ctrl); // PumpableQty
                UpdateSort(LastUpdatedBy, ctrl); // LastUpdatedBy
                UpdateSort(lastUpdatedDate, ctrl); // lastUpdatedDate
                StartRecordNumber = 1; // Reset start position
            }

            // Update field sort
            UpdateFieldSort();
        }

        /// <summary>
        /// Reset command
        /// cmd=reset (Reset search parameters)
        /// cmd=resetall (Reset search and master/detail parameters)
        /// cmd=resetsort (Reset sort parameters)
        /// </summary>
        protected void ResetCommand() {
            // Get reset cmd
            if (Command.ToLower().StartsWith("reset")) {
                // Reset search criteria
                if (SameText(Command, "reset") || SameText(Command, "resetall"))
                    ResetSearchParms();

                // Reset (clear) sorting order
                if (SameText(Command, "resetsort")) {
                    string orderBy = "";
                    SessionOrderBy = orderBy;
                    id.Sort = "";
                    NamaTerminal.Sort = "";
                    Plant.Sort = "";
                    Sloc.Sort = "";
                    SeqTangki.Sort = "";
                    MatNo.Sort = "";
                    TglKalibrasi.Sort = "";
                    ExpDate.Sort = "";
                    Status.Sort = "";
                    TinggiMejaUk.Sort = "";
                    MaxDipping.Sort = "";
                    MaxCapacity.Sort = "";
                    UnpumpableQty.Sort = "";
                    PumpableQty.Sort = "";
                    etlDate.Sort = "";
                    LastUpdatedBy.Sort = "";
                    lastUpdatedDate.Sort = "";
                }

                // Reset start position
                StartRecord = 1;
                StartRecordNumber = StartRecord;
            }
        }

        #pragma warning disable 1998
        // Set up list options
        protected async Task SetupListOptions() {
            ListOption item;

            // Add group option item
            item = ListOptions.AddGroupOption();
            item.Body = "";
            item.OnLeft = true;
            item.Visible = false;

            // "view"
            item = ListOptions.Add("view");
            item.CssClass = "text-nowrap";
            item.Visible = Security.CanView;
            item.OnLeft = true;

            // "edit"
            item = ListOptions.Add("edit");
            item.CssClass = "text-nowrap";
            item.Visible = Security.CanEdit;
            item.OnLeft = true;

            // "copy"
            item = ListOptions.Add("copy");
            item.CssClass = "text-nowrap";
            item.Visible = Security.CanAdd;
            item.OnLeft = true;

            // List actions
            item = ListOptions.Add("listactions");
            item.CssClass = "text-nowrap";
            item.OnLeft = true;
            item.Visible = false;
            item.ShowInButtonGroup = false;
            item.ShowInDropDown = false;

            // "checkbox"
            item = ListOptions.Add("checkbox");
            item.CssStyle = "white-space: nowrap; text-align: center; vertical-align: middle; margin: 0px;";
            item.Visible = Security.CanDelete;
            item.OnLeft = true;
            item.Header = "<div class=\"form-check\"><input type=\"checkbox\" name=\"key\" id=\"key\" class=\"form-check-input\" data-ew-action=\"select-all-keys\"></div>";
            if (item.OnLeft)
                item.MoveTo(0);
            item.ShowInDropDown = false;
            item.ShowInButtonGroup = false;

            // "sequence"
            item = ListOptions.Add("sequence");
            item.CssClass = "text-nowrap";
            item.Visible = true;
            item.OnLeft = true; // Always on left
            item.ShowInDropDown = false;
            item.ShowInButtonGroup = false;

            // Drop down button for ListOptions
            ListOptions.UseDropDownButton = true;
            ListOptions.DropDownButtonPhrase = "ButtonListOptions";
            ListOptions.UseButtonGroup = false;
            if (ListOptions.UseButtonGroup && IsMobile())
                ListOptions.UseDropDownButton = true;

            //ListOptions.ButtonClass = ""; // Class for button group

            // Call ListOptions Load event
            ListOptionsLoad();
            SetupListOptionsExt();
            ListOptions[ListOptions.GroupOptionName]?.SetVisible(ListOptions.GroupOptionVisible);
        }
        #pragma warning restore 1998

        // Set up list options (extensions)
        protected void SetupListOptionsExt() {
            // Set up list options (to be implemented by extensions)
        }

        // Add "hash" parameter to URL
        public string UrlAddHash(string url, string hash)
        {
            return UseAjaxActions ? url : UrlAddQuery(url, "hash=" + hash);
        }

        // Render list options
        #pragma warning disable 168, 219, 1998

        public async Task RenderListOptions()
        {
            ListOption? listOption;
            bool isVisible = false; // DN
            ListOptions.LoadDefault();

            // Call ListOptions Rendering event
            ListOptionsRendering();

            // "sequence"
            listOption = ListOptions["sequence"];
            listOption?.SetBody(FormatSequenceNumber(RecordCount));

            // "view"
            listOption = ListOptions["view"];
            string viewcaption = Language.Phrase("ViewLink", true);
            isVisible = Security.CanView;
            if (isVisible) {
                if (ModalView && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-table=""MasterTangki"" data-caption=""{viewcaption}"" data-ew-action=""modal"" data-action=""view"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(ViewUrl)) + "\" data-btn=\"null\">" + Language.Phrase("ViewLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-caption=""{viewcaption}"" href=""" + HtmlEncode(AppPath(ViewUrl)) + "\">" + Language.Phrase("ViewLink") + "</a>");
            } else {
                listOption?.Clear();
            }

            // "edit"
            listOption = ListOptions["edit"];
            string editcaption = Language.Phrase("EditLink", true);
            isVisible = Security.CanEdit;
            if (isVisible) {
                if (ModalEdit && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-table=""MasterTangki"" data-caption=""{editcaption}"" data-ew-action=""modal"" data-action=""edit"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\" data-btn=\"SaveBtn\">" + Language.Phrase("EditLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-caption=""{editcaption}"" href=""" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("EditLink") + "</a>");
            } else {
                listOption?.Clear();
            }

            // "copy"
            listOption = ListOptions["copy"];
            string copycaption = Language.Phrase("CopyLink", true);
            isVisible = Security.CanAdd;
            if (isVisible) {
                if (ModalAdd && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-copy"" title=""{copycaption}"" data-table=""MasterTangki"" data-caption=""{copycaption}"" data-ew-action=""modal"" data-action=""add"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(CopyUrl)) + "\" data-btn=\"AddBtn\">" + Language.Phrase("CopyLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-copy"" title=""{copycaption}"" data-caption=""{copycaption}"" href=""" + HtmlEncode(AppPath(CopyUrl)) + "\">" + Language.Phrase("CopyLink") + "</a>");
            } else {
                listOption?.Clear();
            }

            // Set up list action buttons
            listOption = ListOptions["listactions"];
            if (listOption != null && !IsExport() && CurrentAction == "") {
                string body = "";
                List<string> links = [];
                foreach (var (key, act) in ListActions.Items) {
                    if (act.Select == Config.ActionSingle && act.Allowed) {
                        var action = act.Action;
                        string caption = act.Caption;
                        string title = HtmlTitle(caption);
                        bool disabled = false;
                        if (action != "") {
                            var icon = (act.Icon != "") ? "<i class=\"" + HtmlEncode(act.Icon.Replace(" ew-icon", "")) + "\" data-caption=\"" + HtmlTitle(caption) + "\"></i> " : "";
                            string link = disabled
                                ? "<li><div class=\"alert alert-light\">" + icon + " " + caption + "</div></li>"
                                : "<li><button type=\"button\" class=\"dropdown-item ew-action ew-list-action\" data-caption=\"" + title + "\" data-ew-action=\"submit\" form=\"fMasterTangkilist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttributes() + ">" + icon + " " + caption + "</button></li>";
                            if (!Empty(link)) {
                                links.Add(link);
                                if (Empty(body)) // Setup first button
                                    body = disabled
                                    ? "<div class=\"alert alert-light\">" + icon + " " + caption + "</div>"
                                    : "<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlTitle(caption) + "\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fMasterTangkilist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttributes() + ">" + icon + caption + "</button>";
                            }
                        }
                    }
                }
                if (links.Count > 1) { // More than one buttons, use dropdown
                    body = "<button type=\"button\" class=\"dropdown-toggle btn btn-default ew-actions\" title=\"" + Language.Phrase("ListActionButton", true) + "\" data-bs-toggle=\"dropdown\">" + Language.Phrase("ListActionButton") + "</button>";
                    string content = links.Aggregate("", (result, link) => result + "<li>" + link + "</li>");
                    body += "<ul class=\"dropdown-menu" + (listOption?.OnLeft ?? false ? "" : " dropdown-menu-right") + "\">" + content + "</ul>";
                    body = "<div class=\"btn-group btn-group-sm\">" + body + "</div>";
                }
                if (links.Count > 0)
                    listOption?.SetBody(body);
            }

            // "checkbox"
            listOption = ListOptions["checkbox"];
            listOption?.SetBody("<div class=\"form-check\"><input type=\"checkbox\" id=\"key_m_" + RowCount + "\" name=\"key_m[]\" class=\"form-check-input ew-multi-select\" value=\"" + HtmlEncode(id.CurrentValue) + "\" data-ew-action=\"select-key\"></div>");
            RenderListOptionsExt();

            // Call ListOptions Rendered event
            ListOptionsRendered();
        }

        // Render list options (extensions)
        protected void RenderListOptionsExt() {
            // Render list options (to be implemented by extensions)
        }

        // Set up other options
        protected void SetupOtherOptions() {
            ListOptions option;
            ListOption item;
            var options = OtherOptions;
            option = options["addedit"];

            // Add
            item = option.Add("add");
            string addTitle = Language.Phrase("AddLink", true);
            if (ModalAdd && !IsMobile())
                item.Body = $@"<a class=""ew-add-edit ew-add"" title=""{addTitle}"" data-table=""MasterTangki"" data-caption=""{addTitle}"" data-ew-action=""modal"" data-action=""add"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(AddUrl)) + "\" data-btn=\"AddBtn\">" + Language.Phrase("AddLink") + "</a>";
            else
                item.Body = $@"<a class=""ew-add-edit ew-add"" title=""{addTitle}"" data-caption=""{addTitle}"" href=""" + HtmlEncode(AppPath(AddUrl)) + "\">" + Language.Phrase("AddLink") + "</a>";
            item.Visible = AddUrl != "" && Security.CanAdd;
            option = options["action"];

            // Add multi delete
            item = option.Add("multidelete");
            string deleteTitle = Language.Phrase("DeleteSelectedLink", true);
            item.Body = $@"<button type=""button"" class=""ew-action ew-multi-delete"" title=""{deleteTitle}"" data-caption=""{deleteTitle}"" form=""fMasterTangkilist""" +
                " data-ew-action=\"" + (UseAjaxActions ? "inline" : "submit") + "\"" +
                (UseAjaxActions ? " data-action=\"delete\"" : "") +
                " data-url=\"" + HtmlEncode(AppPath(MultiDeleteUrl)) + "\"" +
                (InlineDelete ? " data-msg=\"" + HtmlEncode(Language.Phrase("DeleteConfirm")) + "\" data-data='{\"action\":\"delete\"}'" : " data-data='{\"action\":\"show\"}'") +
                ">" + Language.Phrase("DeleteSelectedLink") + "</button>";
            item.Visible = Security.CanDelete;

            // Show column list for column visibility
            if (UseColumnVisibility) {
                option = OtherOptions["column"];
                item = option.AddGroupOption();
                item.Body = "";
                item.Visible = UseColumnVisibility;
                CreateColumnOption(option.Add("NamaTerminal")); // DN
                CreateColumnOption(option.Add("Plant")); // DN
                CreateColumnOption(option.Add("Sloc")); // DN
                CreateColumnOption(option.Add("SeqTangki")); // DN
                CreateColumnOption(option.Add("MatNo")); // DN
                CreateColumnOption(option.Add("TglKalibrasi")); // DN
                CreateColumnOption(option.Add("ExpDate")); // DN
                CreateColumnOption(option.Add("Status")); // DN
                CreateColumnOption(option.Add("TinggiMejaUk")); // DN
                CreateColumnOption(option.Add("MaxDipping")); // DN
                CreateColumnOption(option.Add("MaxCapacity")); // DN
                CreateColumnOption(option.Add("UnpumpableQty")); // DN
                CreateColumnOption(option.Add("PumpableQty")); // DN
                CreateColumnOption(option.Add("LastUpdatedBy")); // DN
                CreateColumnOption(option.Add("lastUpdatedDate")); // DN
            }

            // Set up custom action (compatible with old version)
            ListActions.Add(CustomActions);

            // Set up options default
            foreach (var (key, opt) in options) {
                if (key != "column") { // Always use dropdown for column
                    opt.UseDropDownButton = true;
                    opt.UseButtonGroup = true;
                }
                //opt.ButtonClass = ""; // Class for button group
                item = opt.AddGroupOption();
                item.Body = "";
                item.Visible = false;
            }
            options["addedit"].DropDownButtonPhrase = "ButtonAddEdit";
            options["detail"].DropDownButtonPhrase = "ButtonDetails";
            options["action"].DropDownButtonPhrase = "ButtonActions";

            // Filter button
            item = FilterOptions.Add("savecurrentfilter");
            item.Body = "<a class=\"ew-save-filter\" data-form=\"fMasterTangkisrch\" data-ew-action=\"none\">" + Language.Phrase("SaveCurrentFilter") + "</a>";
            item.Visible = true;
            item = FilterOptions.Add("deletefilter");
            item.Body = "<a class=\"ew-delete-filter\" data-form=\"fMasterTangkisrch\" data-ew-action=\"none\">" + Language.Phrase("DeleteFilter") + "</a>";
            item.Visible = true;
            FilterOptions.UseDropDownButton = true;
            FilterOptions.UseButtonGroup = !FilterOptions.UseDropDownButton;
            FilterOptions.DropDownButtonPhrase = "Filters";

            // Add group option item
            item = FilterOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;

            // Page header/footer options
            item = HeaderOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;
            item = FooterOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;

        // Show active user count from SQL
        }

        // Active user filter
        // - Get active users by SQL (SELECT COUNT(*) FROM UserTable WHERE ProfileField LIKE '%"SessionID":%')
        private string ActiveUserFilter()
        {
            if (UserProfile.IsForceLogoutUser) {
                var userProfileField = Fields[Config.UserProfileFieldName];
                return userProfileField.Expression + " LIKE '%\"" + UserProfile.SessionId + "\":%'";
            }
            return "0=1"; // No active users
        }

        // Create new column option // DN
        public void CreateColumnOption(ListOption item)
        {
            var field = FieldByName(item.Name);
            if (field?.Visible ?? false) {
                item.Body = "<button class=\"dropdown-item\">" +
                    "<div class=\"form-check ew-dropdown-checkbox\">" +
                    "<div class=\"form-check-input ew-dropdown-check-input\" data-field=\"" + field.Param + "\"></div>" +
                    "<label class=\"form-check-label ew-dropdown-check-label\">" + field.Caption + "</label></div></button>";
            }
        }

        // Render other options
        public void RenderOtherOptions()
        {
            ListOptions option;
            ListOption? item;
            var options = OtherOptions;
                option = options["action"];

                // Set up list action buttons
                foreach (var (key, act) in ListActions.Items.Where(kvp => kvp.Value.Select == Config.ActionMultiple)) {
                    item = option.Add("custom_" + act.Action);
                    string caption = act.Caption;
                    var icon = (act.Icon != "") ? "<i class=\"" + HtmlEncode(act.Icon) + "\" data-caption=\"" + HtmlEncode(caption) + "\"></i>" + caption : caption;
                    item.Body = "<<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlEncode(caption) + "\" data-caption=\"" + HtmlEncode(caption) + "\" data-ew-action=\"submit\" form=\"fMasterTangkilist\"" + act.ToDataAttributes() + ">" + icon + "</button>";
                    item.Visible = act.Allowed;
                }

                // Hide multi edit, grid edit and other options
                if (TotalRecords <= 0) {
                    option = options["addedit"];
                    option?["gridedit"]?.SetVisible(false);
                    option = options["action"];
                    option.HideAllOptions();
                }
        }

        // Process list action
        public async Task<IActionResult> ProcessListAction()
        {
            string filter = GetFilterFromRecordKeys();
            string userAction = Post("action");
            if (Empty(filter) || Empty(userAction))
                return new EmptyResult();
            var actionResult = ValidateListAction(userAction);
            if (actionResult != null)
                return actionResult;
            return await ExecuteListAction(userAction, filter);
        }

        private IActionResult? ValidateListAction(string userAction)
        {
            string actionCaption = userAction;
            ListAction? listAction = null;
            foreach (var (key, act) in ListActions.Items) {
                if (SameString(key, userAction)) {
                    listAction = act;
                    actionCaption = !Empty(act.Caption) ? act.Caption : act.Action;
                    SetupCustomAction(userAction, act);
                    if (!act.Allowed) {
                        string errmsg = Language.Phrase("CustomActionNotAllowed").Replace("%s", actionCaption);
                        if (Post("ajax") == userAction) // Ajax
                            return Controller.Content("<p class=\"text-danger\">" + errmsg + "</p>", "text/plain", Encoding.UTF8);
                        else
                            FailureMessage = errmsg;
                        return new EmptyResult();
                    }
                }
            }
            return null;
        }

        private void SetupCustomAction(string userAction, ListAction act)
        {
            if (CustomActions.ContainsKey(userAction)) {
                UserAction = userAction;
                CurrentAction = "";
            }
        }

        private async Task<IActionResult> ExecuteListAction(string userAction, string filter)
        {
            CurrentFilter = filter;
            string sql = CurrentSql;
            var rows = await Connection.GetRowsAsync(sql);
            ActionValue = Post("actionvalue");
            var actionResult = await ProcessListActionRows(userAction, rows);
            return HandleActionResponse(userAction, actionResult);
        }

        private async Task<bool> ProcessListActionRows(string userAction, IEnumerable<Dictionary<string, object>>? rows)
        {
            if (rows == null) return false;
            if (UseTransaction)
                Connection.BeginTrans();
            bool processed = true;
            SelectedCount = rows.Count();
            SelectedIndex = 0;
            foreach (var row in rows) {
                SelectedIndex++;
                processed = await ProcessSingleRow(userAction, row);
                if (!processed)
                    break;
            }
            HandleTransactionResult(processed);
            return processed;
        }

        private async Task<bool> ProcessSingleRow(string userAction, Dictionary<string, object> row)
        {
            var listAction = GetListActionByUserAction(userAction);
            bool processed = true;
            if (listAction != null) { // Handle list action
                var result = await listAction.Handle(row, this);
                processed = result;
                if (listAction.Method == Config.ActionAjax && result.Value != null) // DN
                    ActionResult = result;
            }
            if (!processed) return false;
            processed = RowCustomAction(userAction, row);
            return processed;
        }

        private ListAction? GetListActionByUserAction(string userAction)
        {
            foreach (var (key, act) in ListActions.Items) {
                if (SameString(key, userAction)) {
                    return act;
                }
            }
            return null;
        }

        private void HandleTransactionResult(bool processed)
        {
            var listAction = GetListActionByUserAction(Post("action"));
            var actionCaption = listAction?.Caption ?? Post("action");
            var rows = Connection.GetRowsAsync(CurrentSql).Result;
            if (processed) {
                if (UseTransaction)
                    Connection.CommitTrans(); // Commit the changes
                SetupSuccessMessage(listAction, actionCaption, rows);
            } else {
                if (UseTransaction)
                    Connection.RollbackTrans(); // Rollback changes
                SetupFailureMessage(listAction, actionCaption, rows);
            }
        }

        private void SetupSuccessMessage(ListAction? listAction, string actionCaption, IEnumerable<Dictionary<string, object>>? rows)
        {
            SuccessMessage = listAction?.SuccessMessage ?? "";
            if (Empty(SuccessMessage))
                SuccessMessage = Language.Phrase("CustomActionCompleted").Replace("%s", actionCaption);
        }

        private void SetupFailureMessage(ListAction? listAction, string actionCaption, IEnumerable<Dictionary<string, object>>? rows)
        {
            FailureMessage = listAction?.FailureMessage ?? "";

            // Set up error message
            if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                // Use the message, do nothing
            } else if (!Empty(CancelMessage)) {
                FailureMessage = CancelMessage;
                CancelMessage = "";
            } else {
                FailureMessage = Language.Phrase("CustomActionFailed").Replace("%s", actionCaption);
            }
        }

        private IActionResult HandleActionResponse(string userAction, bool processed)
        {
            CurrentAction = ""; // Clear action
            if (Post("ajax") == userAction) { // Ajax
                if (ActionResult != null) // Action result set by Row CustomAction event // DN
                    return ActionResult;
                string msg = BuildResponseMessage();
                if (!Empty(msg))
                    return Controller.Content(msg, "text/plain", Encoding.UTF8);
            }
            return new EmptyResult(); // Not ajax request
        }

        private string BuildResponseMessage()
        {
            string msg = "";
            if (SuccessMessage != "") {
                msg = "<p class=\"text-success\">" + SuccessMessage + "</p>";
                ClearSuccessMessage(); // Clear message
            }
            if (FailureMessage != "") {
                msg = "<p class=\"text-danger\">" + FailureMessage + "</p>";
                ClearFailureMessage(); // Clear message
            }
            return msg;
        }

        // Set up Grid
        public async Task SetupGrid()
        {
            SetupRecordRange();
            await HandleFormKeyCount();
            await HandleRecordset();
            await SetupAggregateAndInlineOperations();
        }

        private void SetupRecordRange()
        {
            if (ExportAll && IsExport()) {
                StopRecord = TotalRecords;
            } else {
                // Set the last record to display
                if (TotalRecords > StartRecord + DisplayRecords - 1) {
                    StopRecord = StartRecord + DisplayRecords - 1;
                } else {
                    StopRecord = TotalRecords;
                }
            }
        }

        private async Task HandleFormKeyCount()
        {
            // If empty, means all conditions are not fulfilled
        }

        private async Task HandleRecordset()
        {
            if (Recordset != null && Recordset.HasRows) {
                await HandleExistingRecordset();
            } else {
                HandleEmptyRecordset();
            }
        }

        private async Task HandleExistingRecordset()
        {
            if (!Connection.SelectOffset) { // DN
                for (int i = 1; i <= StartRecord - 1; i++) { // Move to first record
                    if (await Recordset.ReadAsync())
                        RecordCount++;
                }
            } else {
                RecordCount = StartRecord - 1;
            }
        }

        private void HandleEmptyRecordset()
        {
            if (IsGridAdd && !AllowAddDeleteRow && StopRecord == 0) { // Grid-Add with no records
                StopRecord = GridAddRowCount;
            } else if (IsAdd && TotalRecords == 0) { // Inline-Add with no records
                StopRecord = 1;
            }
        }

        private async Task SetupAggregateAndInlineOperations()
        {
            // Initialize aggregate
            RowType = RowType.AggregateInit;
            ResetAttributes();
            await RenderRow();
            SetupInlineOperations();
            SetupGridOperations();
        }

        private void SetupInlineOperations()
        {
            // If empty, means all conditions are not fulfilled
        }

        private void SetupGridOperations()
        {
            if ((IsGridAdd || IsGridEdit)) // Render template row first
                RowIndex = "$rowindex$";
        }

        // Set up Row
        public async Task SetupRow()
        {
            // Handle template row for grid operations
            if (await HandleTemplateRow())
                return;

            // Setup form and row index
            SetupFormAndRowIndex();

            // Initialize row attributes
            InitializeRowAttributes();

            // Load row data based on context
            await LoadRowData();

            // Setup row type and actions
            SetupRowTypeAndActions();

            // Handle edit mode specific setup
            await HandleEditModeSetup();

            // Handle form restoration on errors
            await HandleFormRestoration();

            // Setup row counts and final attributes
            SetupRowCountsAndAttributes();

            // Render row and options
            await RenderRowAndOptions();
        }

        private async Task<bool> HandleTemplateRow()
        {
            if ((IsGridAdd || IsGridEdit) && SameString(RowIndex, "$rowindex$")) { // Render template row first
                await LoadRowValues();

                // Set row properties
                ResetAttributes();
                RowAttrs.Add("data-rowindex", ConvertToString(RowIndex));
                RowAttrs.Add("id", "r0_MasterTangki");
                RowAttrs.Add("data-rowtype", ConvertToString((int)RowType.Add));
                RowAttrs.Add("data-inline", (IsAdd || IsCopy || IsEdit) ? "true" : "false");
                RowAttrs.AppendClass("ew-template");

                // Render row
                RowType = RowType.Add;
                await RenderRow();

                // Render list options
                await RenderListOptions();

                // Reset record count for template row
                RecordCount--;
                return true; // Exit early
            }
            return false;
        }

        private void SetupFormAndRowIndex()
        {
            // If empty, means all conditions are not 
        }

        private void InitializeRowAttributes()
        {
            // Set up key count
            KeyCount = ConvertToInt(RowIndex);

            // Init row class and style
            ResetAttributes();
            CssClass = "";
        }

        private async Task LoadRowData()
        {
            await LoadRowDataForList();
        }

        private async Task LoadRowDataForGrid()
        {
            if (IsGridAdd) {
                if (CurrentMode == "copy") {
                    await LoadRowValues(Recordset); // Load row values
                    OldKey = GetKey(true); // Get from CurrentValue
                } else {
                    await LoadRowValues(); // Load default values
                    OldKey = "";
                }
            } else {
                await LoadRowValues(Recordset); // Load row values
                OldKey = GetKey(true); // Get from CurrentValue
            }
            SetKey(OldKey);
        }

        private async Task LoadRowDataForList()
        {
            if (IsCopy && InlineRowCount == 0 && !await LoadRow()) { // Inline copy
                CurrentAction = "add";
            }
            if (IsAdd && InlineRowCount == 0 || IsGridAdd) {
                await LoadRowValues(); // Load default values
                OldKey = "";
                SetKey(OldKey);
            } else if (IsInlineInserted && UseInfiniteScroll) {
                // Nothing to do, just use current values
            } else if (!(IsCopy && InlineRowCount == 0)) {
                await LoadRowValues(Recordset); // Load row values
                if (IsGridEdit || IsMultiEdit) {
                    OldKey = GetKey(true); // Get from CurrentValue
                    SetKey(OldKey);
                }
            }
        }

        private void SetupRowTypeAndActions()
        {
            RowType = RowType.View; // Render view
            if ((IsAdd || IsCopy) && InlineRowCount == 0 || IsGridAdd) // Add
                RowType = RowType.Add; // Render add
        }

        private async Task HandleEditModeSetup()
        {
            // If empty, means all conditions are not 
        }

        private async Task HandleFormRestoration()
        {
            // If empty, means all conditions are not 
        }

        private void SetupRowCountsAndAttributes()
        {
            // Inline Add/Copy row (row 0)
            if (RowType == RowType.Add && (IsAdd || IsCopy)) {
                InlineRowCount++;
                RecordCount--; // Reset record count for inline add/copy row
                if (TotalRecords == 0) // Reset stop record if no records
                    StopRecord = 0;
            } else {
                // Inline Edit row
                if (RowType == RowType.Edit && IsEdit)
                    InlineRowCount++;
                RowCount++; // Increment row count
            }

            // Set up row attributes
            RowAttrs.Add("data-rowindex", ConvertToString(masterTangkiList.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(masterTangkiList.RowCount) + "_MasterTangki");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(masterTangkiList.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && masterTangkiList.RowType == RowType.Add || IsEdit && masterTangkiList.RowType == RowType.Edit) // Inline-Add/Edit row
                RowAttrs.AppendClass("table-active");
        }

        private async Task RenderRowAndOptions()
        {
            // Render row
            await RenderRow();

            // Render list options
            await RenderListOptions();
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
        var listwrk = fld.Lookup?.RenderViewRow(rswrk?[0]);
        fld.ViewValue = fld.DisplayValue(listwrk);
    }
}

        // Load basic search values // DN
        protected void LoadBasicSearchValues() {
            if (Get(Config.TableBasicSearch, out StringValues keyword))
                BasicSearch.Keyword = keyword.ToString();
            if (!Empty(BasicSearch.Keyword) && Empty(Command))
                Command = "search";
            if (Get(Config.TableBasicSearchType, out StringValues type))
                BasicSearch.Type = type.ToString();
        }

        // Load search values for validation // DN
        protected void LoadSearchValues() {
            LoadQueryBuilderRules();
            LoadFieldSearchValues();
        }

        // ================= HELPER METHODS =================
        private void LoadQueryBuilderRules()
        {
            // Load query builder rules
            string rules = Post("rules");
            if (!Empty(rules) && Empty(Command)) {
                QueryRules = rules;
                Command = "search";
            }
        }

        private void LoadFieldSearchValues()
        {
            LoadFieldNamaTerminalSearchValues();
            LoadFieldPlantSearchValues();
            LoadFieldSlocSearchValues();
            LoadFieldSeqTangkiSearchValues();
            LoadFieldMatNoSearchValues();
            LoadFieldTglKalibrasiSearchValues();
            LoadFieldExpDateSearchValues();
            LoadFieldStatusSearchValues();
            LoadFieldTinggiMejaUkSearchValues();
            LoadFieldMaxDippingSearchValues();
            LoadFieldMaxCapacitySearchValues();
            LoadFieldUnpumpableQtySearchValues();
            LoadFieldPumpableQtySearchValues();
            LoadFieldetlDateSearchValues();
            LoadFieldLastUpdatedBySearchValues();
            LoadFieldlastUpdatedDateSearchValues();
        }

        private void LoadFieldNamaTerminalSearchValues()
        {
            // NamaTerminal
            LoadPrimarySearchValueNamaTerminal();
            LoadSearchOperatorNamaTerminal();
        }

        private void LoadPrimarySearchValueNamaTerminal()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_NamaTerminal[]")) {
                NamaTerminal.AdvancedSearch.SearchValue = Get("x_NamaTerminal[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                NamaTerminal.AdvancedSearch.SearchValue = Get("NamaTerminal"); // Default Value // DN
            }
            if (!Empty(NamaTerminal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorNamaTerminal()
        {
            if (Query.ContainsKey("z_NamaTerminal"))
                NamaTerminal.AdvancedSearch.SearchOperator = Get("z_NamaTerminal", Config.FilterOptionSeparator);
        }

        private void LoadFieldPlantSearchValues()
        {
            // Plant
            LoadPrimarySearchValuePlant();
            LoadSearchOperatorPlant();
        }

        private void LoadPrimarySearchValuePlant()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_Plant[]")) {
                Plant.AdvancedSearch.SearchValue = Get("x_Plant[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                Plant.AdvancedSearch.SearchValue = Get("Plant"); // Default Value // DN
            }
            if (!Empty(Plant.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorPlant()
        {
            if (Query.ContainsKey("z_Plant"))
                Plant.AdvancedSearch.SearchOperator = Get("z_Plant", Config.FilterOptionSeparator);
        }

        private void LoadFieldSlocSearchValues()
        {
            // Sloc
            LoadPrimarySearchValueSloc();
            LoadSearchOperatorSloc();
        }

        private void LoadPrimarySearchValueSloc()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_Sloc[]")) {
                Sloc.AdvancedSearch.SearchValue = Get("x_Sloc[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                Sloc.AdvancedSearch.SearchValue = Get("Sloc"); // Default Value // DN
            }
            if (!Empty(Sloc.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorSloc()
        {
            if (Query.ContainsKey("z_Sloc"))
                Sloc.AdvancedSearch.SearchOperator = Get("z_Sloc", Config.FilterOptionSeparator);
        }

        private void LoadFieldSeqTangkiSearchValues()
        {
            // SeqTangki
            LoadPrimarySearchValueSeqTangki();
            LoadSearchOperatorSeqTangki();
        }

        private void LoadPrimarySearchValueSeqTangki()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_SeqTangki[]")) {
                SeqTangki.AdvancedSearch.SearchValue = Get("x_SeqTangki[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                SeqTangki.AdvancedSearch.SearchValue = Get("SeqTangki"); // Default Value // DN
            }
            if (!Empty(SeqTangki.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorSeqTangki()
        {
            if (Query.ContainsKey("z_SeqTangki"))
                SeqTangki.AdvancedSearch.SearchOperator = Get("z_SeqTangki", Config.FilterOptionSeparator);
        }

        private void LoadFieldMatNoSearchValues()
        {
            // MatNo
            LoadPrimarySearchValueMatNo();
            LoadSearchOperatorMatNo();
        }

        private void LoadPrimarySearchValueMatNo()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_MatNo[]")) {
                MatNo.AdvancedSearch.SearchValue = Get("x_MatNo[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                MatNo.AdvancedSearch.SearchValue = Get("MatNo"); // Default Value // DN
            }
            if (!Empty(MatNo.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorMatNo()
        {
            if (Query.ContainsKey("z_MatNo"))
                MatNo.AdvancedSearch.SearchOperator = Get("z_MatNo", Config.FilterOptionSeparator);
        }

        private void LoadFieldTglKalibrasiSearchValues()
        {
            // TglKalibrasi
            LoadPrimarySearchValueTglKalibrasi();
            LoadSearchOperatorTglKalibrasi();
        }

        private void LoadPrimarySearchValueTglKalibrasi()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_TglKalibrasi[]")) {
                TglKalibrasi.AdvancedSearch.SearchValue = Get("x_TglKalibrasi[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                TglKalibrasi.AdvancedSearch.SearchValue = Get("TglKalibrasi"); // Default Value // DN
            }
            if (!Empty(TglKalibrasi.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorTglKalibrasi()
        {
            if (Query.ContainsKey("z_TglKalibrasi"))
                TglKalibrasi.AdvancedSearch.SearchOperator = Get("z_TglKalibrasi", Config.FilterOptionSeparator);
        }

        private void LoadFieldExpDateSearchValues()
        {
            // ExpDate
            LoadPrimarySearchValueExpDate();
            LoadSearchOperatorExpDate();
        }

        private void LoadPrimarySearchValueExpDate()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_ExpDate[]")) {
                ExpDate.AdvancedSearch.SearchValue = Get("x_ExpDate[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                ExpDate.AdvancedSearch.SearchValue = Get("ExpDate"); // Default Value // DN
            }
            if (!Empty(ExpDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorExpDate()
        {
            if (Query.ContainsKey("z_ExpDate"))
                ExpDate.AdvancedSearch.SearchOperator = Get("z_ExpDate", Config.FilterOptionSeparator);
        }

        private void LoadFieldStatusSearchValues()
        {
            // Status
            LoadPrimarySearchValueStatus();
            LoadSearchOperatorStatus();
        }

        private void LoadPrimarySearchValueStatus()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_Status[]")) {
                Status.AdvancedSearch.SearchValue = Get("x_Status[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                Status.AdvancedSearch.SearchValue = Get("Status"); // Default Value // DN
            }
            if (!Empty(Status.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorStatus()
        {
            if (Query.ContainsKey("z_Status"))
                Status.AdvancedSearch.SearchOperator = Get("z_Status", Config.FilterOptionSeparator);
        }

        private void LoadFieldTinggiMejaUkSearchValues()
        {
            // TinggiMejaUk
            LoadPrimarySearchValueTinggiMejaUk();
            LoadSearchOperatorTinggiMejaUk();
        }

        private void LoadPrimarySearchValueTinggiMejaUk()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_TinggiMejaUk[]")) {
                TinggiMejaUk.AdvancedSearch.SearchValue = Get("x_TinggiMejaUk[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                TinggiMejaUk.AdvancedSearch.SearchValue = Get("TinggiMejaUk"); // Default Value // DN
            }
            if (!Empty(TinggiMejaUk.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorTinggiMejaUk()
        {
            if (Query.ContainsKey("z_TinggiMejaUk"))
                TinggiMejaUk.AdvancedSearch.SearchOperator = Get("z_TinggiMejaUk", Config.FilterOptionSeparator);
        }

        private void LoadFieldMaxDippingSearchValues()
        {
            // MaxDipping
            LoadPrimarySearchValueMaxDipping();
            LoadSearchOperatorMaxDipping();
        }

        private void LoadPrimarySearchValueMaxDipping()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_MaxDipping[]")) {
                MaxDipping.AdvancedSearch.SearchValue = Get("x_MaxDipping[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                MaxDipping.AdvancedSearch.SearchValue = Get("MaxDipping"); // Default Value // DN
            }
            if (!Empty(MaxDipping.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorMaxDipping()
        {
            if (Query.ContainsKey("z_MaxDipping"))
                MaxDipping.AdvancedSearch.SearchOperator = Get("z_MaxDipping", Config.FilterOptionSeparator);
        }

        private void LoadFieldMaxCapacitySearchValues()
        {
            // MaxCapacity
            LoadPrimarySearchValueMaxCapacity();
            LoadSearchOperatorMaxCapacity();
        }

        private void LoadPrimarySearchValueMaxCapacity()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_MaxCapacity[]")) {
                MaxCapacity.AdvancedSearch.SearchValue = Get("x_MaxCapacity[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                MaxCapacity.AdvancedSearch.SearchValue = Get("MaxCapacity"); // Default Value // DN
            }
            if (!Empty(MaxCapacity.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorMaxCapacity()
        {
            if (Query.ContainsKey("z_MaxCapacity"))
                MaxCapacity.AdvancedSearch.SearchOperator = Get("z_MaxCapacity", Config.FilterOptionSeparator);
        }

        private void LoadFieldUnpumpableQtySearchValues()
        {
            // UnpumpableQty
            LoadPrimarySearchValueUnpumpableQty();
            LoadSearchOperatorUnpumpableQty();
        }

        private void LoadPrimarySearchValueUnpumpableQty()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_UnpumpableQty[]")) {
                UnpumpableQty.AdvancedSearch.SearchValue = Get("x_UnpumpableQty[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                UnpumpableQty.AdvancedSearch.SearchValue = Get("UnpumpableQty"); // Default Value // DN
            }
            if (!Empty(UnpumpableQty.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorUnpumpableQty()
        {
            if (Query.ContainsKey("z_UnpumpableQty"))
                UnpumpableQty.AdvancedSearch.SearchOperator = Get("z_UnpumpableQty", Config.FilterOptionSeparator);
        }

        private void LoadFieldPumpableQtySearchValues()
        {
            // PumpableQty
            LoadPrimarySearchValuePumpableQty();
            LoadSearchOperatorPumpableQty();
        }

        private void LoadPrimarySearchValuePumpableQty()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_PumpableQty[]")) {
                PumpableQty.AdvancedSearch.SearchValue = Get("x_PumpableQty[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                PumpableQty.AdvancedSearch.SearchValue = Get("PumpableQty"); // Default Value // DN
            }
            if (!Empty(PumpableQty.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorPumpableQty()
        {
            if (Query.ContainsKey("z_PumpableQty"))
                PumpableQty.AdvancedSearch.SearchOperator = Get("z_PumpableQty", Config.FilterOptionSeparator);
        }

        private void LoadFieldetlDateSearchValues()
        {
            // etlDate
            LoadPrimarySearchValueetlDate();
            LoadSearchOperatoretlDate();
        }

        private void LoadPrimarySearchValueetlDate()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_etlDate[]")) {
                etlDate.AdvancedSearch.SearchValue = Get("x_etlDate[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                etlDate.AdvancedSearch.SearchValue = Get("etlDate"); // Default Value // DN
            }
            if (!Empty(etlDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatoretlDate()
        {
            if (Query.ContainsKey("z_etlDate"))
                etlDate.AdvancedSearch.SearchOperator = Get("z_etlDate", Config.FilterOptionSeparator);
        }

        private void LoadFieldLastUpdatedBySearchValues()
        {
            // LastUpdatedBy
            LoadPrimarySearchValueLastUpdatedBy();
            LoadSearchOperatorLastUpdatedBy();
        }

        private void LoadPrimarySearchValueLastUpdatedBy()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_LastUpdatedBy[]")) {
                LastUpdatedBy.AdvancedSearch.SearchValue = Get("x_LastUpdatedBy[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                LastUpdatedBy.AdvancedSearch.SearchValue = Get("LastUpdatedBy"); // Default Value // DN
            }
            if (!Empty(LastUpdatedBy.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorLastUpdatedBy()
        {
            if (Query.ContainsKey("z_LastUpdatedBy"))
                LastUpdatedBy.AdvancedSearch.SearchOperator = Get("z_LastUpdatedBy", Config.FilterOptionSeparator);
        }

        private void LoadFieldlastUpdatedDateSearchValues()
        {
            // lastUpdatedDate
            LoadPrimarySearchValuelastUpdatedDate();
            LoadSearchOperatorlastUpdatedDate();
        }

        private void LoadPrimarySearchValuelastUpdatedDate()
        {
            if (!IsAddOrEdit && Query.ContainsKey("x_lastUpdatedDate[]")) {
                lastUpdatedDate.AdvancedSearch.SearchValue = Get("x_lastUpdatedDate[]", Config.FilterOptionSeparator);
            }
            else if (!IsAddOrEdit) {
                lastUpdatedDate.AdvancedSearch.SearchValue = Get("lastUpdatedDate"); // Default Value // DN
            }
            if (!Empty(lastUpdatedDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
        }

        private void LoadSearchOperatorlastUpdatedDate()
        {
            if (Query.ContainsKey("z_lastUpdatedDate"))
                lastUpdatedDate.AdvancedSearch.SearchOperator = Get("z_lastUpdatedDate", Config.FilterOptionSeparator);
        }

        // Load recordset // DN
        public async Task<DbDataReader?> LoadRecordset(int offset = -1, int rowcnt = -1)
        {
            // Load list page SQL
            string sql = ListSql;

            // Load recordset // DN
            var dr = await Connection.ExecuteReaderAsync(Connection.SelectLimitSql(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy)));

            // Call Recordset Selected event
            RecordsetSelected(dr);
            return dr;
        }

        // Load rows // DN
        public async Task<List<Dictionary<string, object>>> LoadRows(int offset = -1, int rowcnt = -1)
        {
            // Load list page SQL
            string sql = ListSql;

            // Load rows // DN
            return await Connection.GetRowsAsync(Connection.SelectLimitSql(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy)));
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
            NamaTerminal.SetDbValue(row["NamaTerminal"]);
            Plant.SetDbValue(row["Plant"]);
            Sloc.SetDbValue(row["Sloc"]);
            SeqTangki.SetDbValue(row["SeqTangki"]);
            MatNo.SetDbValue(row["MatNo"]);
            TglKalibrasi.SetDbValue(row["TglKalibrasi"]);
            ExpDate.SetDbValue(row["ExpDate"]);
            Status.SetDbValue(row["Status"]);
            TinggiMejaUk.SetDbValue(row["TinggiMejaUk"]);
            MaxDipping.SetDbValue(row["MaxDipping"]);
            MaxCapacity.SetDbValue(row["MaxCapacity"]);
            UnpumpableQty.SetDbValue(row["UnpumpableQty"]);
            PumpableQty.SetDbValue(row["PumpableQty"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaTerminal", NamaTerminal.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("Sloc", Sloc.DefaultValue ?? DbNullValue); // DN
            row.Add("SeqTangki", SeqTangki.DefaultValue ?? DbNullValue); // DN
            row.Add("MatNo", MatNo.DefaultValue ?? DbNullValue); // DN
            row.Add("TglKalibrasi", TglKalibrasi.DefaultValue ?? DbNullValue); // DN
            row.Add("ExpDate", ExpDate.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("TinggiMejaUk", TinggiMejaUk.DefaultValue ?? DbNullValue); // DN
            row.Add("MaxDipping", MaxDipping.DefaultValue ?? DbNullValue); // DN
            row.Add("MaxCapacity", MaxCapacity.DefaultValue ?? DbNullValue); // DN
            row.Add("UnpumpableQty", UnpumpableQty.DefaultValue ?? DbNullValue); // DN
            row.Add("PumpableQty", PumpableQty.DefaultValue ?? DbNullValue); // DN
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

            // NamaTerminal

            // Plant

            // Sloc

            // SeqTangki

            // MatNo

            // TglKalibrasi

            // ExpDate

            // Status

            // TinggiMejaUk

            // MaxDipping

            // MaxCapacity

            // UnpumpableQty

            // PumpableQty

            // etlDate

            // LastUpdatedBy

            // lastUpdatedDate

            // View row
            if (RowType == RowType.View) {
                // NamaTerminal

                // Plant

                // Sloc

                // SeqTangki

                // MatNo

                // TglKalibrasi

                // ExpDate

                // Status

                // TinggiMejaUk

                // MaxDipping

                // MaxCapacity

                // UnpumpableQty

                // PumpableQty

                // etlDate

                // LastUpdatedBy

                // lastUpdatedDate

                    // id
                    id.ViewValue = id.CurrentValue;
                    id.ViewCustomAttributes = "";

                    // NamaTerminal
                    NamaTerminal.ViewValue = ConvertToString(NamaTerminal.CurrentValue); // DN
                    NamaTerminal.ViewCustomAttributes = "";

                    // Plant

                    // awallookupbung
                    // Plant (jaga leading zero)
                    ResolveLookupView(Plant, "Plant", "string");
                    // akhirlookupbung
                    Plant.ViewCustomAttributes = "";

                    // Sloc
                    Sloc.ViewValue = ConvertToString(Sloc.CurrentValue); // DN
                    Sloc.ViewCustomAttributes = "";

                    // SeqTangki
                    SeqTangki.ViewValue = ConvertToString(SeqTangki.CurrentValue); // DN
                    SeqTangki.ViewCustomAttributes = "";

                    // MatNo
                    MatNo.ViewValue = ConvertToString(MatNo.CurrentValue); // DN
                    MatNo.ViewCustomAttributes = "";

                    // TglKalibrasi
                    TglKalibrasi.ViewValue = TglKalibrasi.CurrentValue;
                    TglKalibrasi.ViewValue = FormatDateTime(TglKalibrasi.ViewValue, TglKalibrasi.FormatPattern);
                    TglKalibrasi.ViewCustomAttributes = "";

                    // ExpDate
                    ExpDate.ViewValue = ExpDate.CurrentValue;
                    ExpDate.ViewValue = FormatDateTime(ExpDate.ViewValue, ExpDate.FormatPattern);
                    ExpDate.ViewCustomAttributes = "";

                    // Status
                    if (!Empty(Status.CurrentValue)) {
                        Status.ViewValue = Status.OptionCaption(ConvertToString(Status.CurrentValue));
                    } else {
                        Status.ViewValue = DbNullValue;
                    }
                    Status.ViewCustomAttributes = "";

                    // TinggiMejaUk
                    TinggiMejaUk.ViewValue = ConvertToString(TinggiMejaUk.CurrentValue); // DN
                    TinggiMejaUk.ViewCustomAttributes = "";

                    // MaxDipping
                    MaxDipping.ViewValue = ConvertToString(MaxDipping.CurrentValue); // DN
                    MaxDipping.ViewCustomAttributes = "";

                    // MaxCapacity
                    MaxCapacity.ViewValue = ConvertToString(MaxCapacity.CurrentValue); // DN
                    MaxCapacity.ViewCustomAttributes = "";

                    // UnpumpableQty
                    UnpumpableQty.ViewValue = ConvertToString(UnpumpableQty.CurrentValue); // DN
                    UnpumpableQty.ViewCustomAttributes = "";

                    // PumpableQty
                    PumpableQty.ViewValue = ConvertToString(PumpableQty.CurrentValue); // DN
                    PumpableQty.ViewCustomAttributes = "";

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

                // NamaTerminal
                NamaTerminal.HrefValue = "";
                NamaTerminal.TooltipValue = "";

                // Plant
                Plant.HrefValue = "";
                Plant.TooltipValue = "";

                // Sloc
                Sloc.HrefValue = "";
                Sloc.TooltipValue = "";

                // SeqTangki
                SeqTangki.HrefValue = "";
                SeqTangki.TooltipValue = "";

                // MatNo
                MatNo.HrefValue = "";
                MatNo.TooltipValue = "";

                // TglKalibrasi
                TglKalibrasi.HrefValue = "";
                TglKalibrasi.TooltipValue = "";

                // ExpDate
                ExpDate.HrefValue = "";
                ExpDate.TooltipValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // TinggiMejaUk
                TinggiMejaUk.HrefValue = "";
                TinggiMejaUk.TooltipValue = "";

                // MaxDipping
                MaxDipping.HrefValue = "";
                MaxDipping.TooltipValue = "";

                // MaxCapacity
                MaxCapacity.HrefValue = "";
                MaxCapacity.TooltipValue = "";

                // UnpumpableQty
                UnpumpableQty.HrefValue = "";
                UnpumpableQty.TooltipValue = "";

                // PumpableQty
                PumpableQty.HrefValue = "";
                PumpableQty.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // NamaTerminal
                if (NamaTerminal.UseFilter && !Empty(NamaTerminal.AdvancedSearch.SearchValue)) {
                    NamaTerminal.EditValue = ConvertToString(NamaTerminal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // Plant
                if (Plant.UseFilter && !Empty(Plant.AdvancedSearch.SearchValue)) {
                    Plant.EditValue = ConvertToString(Plant.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // Sloc
                if (Sloc.UseFilter && !Empty(Sloc.AdvancedSearch.SearchValue)) {
                    Sloc.EditValue = ConvertToString(Sloc.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // SeqTangki
                if (SeqTangki.UseFilter && !Empty(SeqTangki.AdvancedSearch.SearchValue)) {
                    SeqTangki.EditValue = ConvertToString(SeqTangki.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // MatNo
                if (MatNo.UseFilter && !Empty(MatNo.AdvancedSearch.SearchValue)) {
                    MatNo.EditValue = ConvertToString(MatNo.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // TglKalibrasi
                if (TglKalibrasi.UseFilter && !Empty(TglKalibrasi.AdvancedSearch.SearchValue)) {
                    TglKalibrasi.EditValue = ConvertToString(TglKalibrasi.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // ExpDate
                if (ExpDate.UseFilter && !Empty(ExpDate.AdvancedSearch.SearchValue)) {
                    ExpDate.EditValue = ConvertToString(ExpDate.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // Status
                if (Status.UseFilter && !Empty(Status.AdvancedSearch.SearchValue)) {
                    Status.EditValue = ConvertToString(Status.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // TinggiMejaUk
                if (TinggiMejaUk.UseFilter && !Empty(TinggiMejaUk.AdvancedSearch.SearchValue)) {
                    TinggiMejaUk.EditValue = ConvertToString(TinggiMejaUk.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // MaxDipping
                if (MaxDipping.UseFilter && !Empty(MaxDipping.AdvancedSearch.SearchValue)) {
                    MaxDipping.EditValue = ConvertToString(MaxDipping.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // MaxCapacity
                if (MaxCapacity.UseFilter && !Empty(MaxCapacity.AdvancedSearch.SearchValue)) {
                    MaxCapacity.EditValue = ConvertToString(MaxCapacity.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // UnpumpableQty
                if (UnpumpableQty.UseFilter && !Empty(UnpumpableQty.AdvancedSearch.SearchValue)) {
                    UnpumpableQty.EditValue = ConvertToString(UnpumpableQty.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // PumpableQty
                if (PumpableQty.UseFilter && !Empty(PumpableQty.AdvancedSearch.SearchValue)) {
                    PumpableQty.EditValue = ConvertToString(PumpableQty.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // LastUpdatedBy
                if (LastUpdatedBy.UseFilter && !Empty(LastUpdatedBy.AdvancedSearch.SearchValue)) {
                    LastUpdatedBy.EditValue = ConvertToString(LastUpdatedBy.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // lastUpdatedDate
                if (lastUpdatedDate.UseFilter && !Empty(lastUpdatedDate.AdvancedSearch.SearchValue)) {
                    lastUpdatedDate.EditValue = ConvertToString(lastUpdatedDate.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }
            }

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
            TglKalibrasi.AdvancedSearch.Load();
            ExpDate.AdvancedSearch.Load();
            etlDate.AdvancedSearch.Load();
            lastUpdatedDate.AdvancedSearch.Load();
        }

        // Get export HTML tag
        protected string GetExportTag(string type, bool custom = false)
{
    // Build export URL
    string exportUrl = AppPath(CurrentPageName()); // DN
    if (type == "print" || custom)
    { // Printer friendly / custom export
                exportUrl += "?export=" + type + (custom ? "&amp;custom=1" : "");
    }
    else
    {
        exportUrl = AppPath(Config.ApiUrl + Config.ApiExportAction + "/" + type + "/" + TableVar);
            }

            // Handle email case separately due to complex logic requirements
            string typeKey = type.ToLower();
    if (typeKey == "email")
    {
        string url = custom ? " data-url=\"" + exportUrl + "\"" : "";
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fMasterTangkilist\" data-ew-action=\"email\" data-custom=\"false\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
            }

    // Handle all other types with switch expression
    return typeKey switch
    {
        "print" => "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-print\" title=\"" + HtmlEncode(Language.Phrase("PrinterFriendly", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("PrinterFriendly", true)) + "\">" + Language.Phrase("PrinterFriendly") + "</a>",
                "excel" => custom ? "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fMasterTangkilist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>" 
                                  : "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>",
                "word" => custom ? "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fMasterTangkilist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>" 
                                 : "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>",
                "pdf" => custom ? "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fMasterTangkilist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>" 
                                : "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\">" + Language.Phrase("ExportToPDF") + "</a>",
                "html" => "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-html\" title=\"" + HtmlEncode(Language.Phrase("ExportToHtml", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToHtml", true)) + "\">" + Language.Phrase("ExportToHtml") + "</a>",
                "xml" => "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-xml\" title=\"" + HtmlEncode(Language.Phrase("ExportToXml", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToXml", true)) + "\">" + Language.Phrase("ExportToXml") + "</a>",
                "csv" => "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-csv\" title=\"" + HtmlEncode(Language.Phrase("ExportToCsv", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToCsv", true)) + "\">" + Language.Phrase("ExportToCsv") + "</a>",
                _ => ""
    };
        }

// Set up export options
protected void SetupExportOptions() {
            ListOption item;

            // Printer friendly
            item = ExportOptions.Add("print");
            item.Body = GetExportTag("print");
            item.Visible = true;

            // Export to Excel
            item = ExportOptions.Add("excel");
            item.Body = GetExportTag("excel");
            item.Visible = true;

            // Export to Word
            item = ExportOptions.Add("word");
            item.Body = GetExportTag("word");
            item.Visible = false;

            // Export to HTML
            item = ExportOptions.Add("html");
            item.Body = GetExportTag("html");
            item.Visible = false;

            // Export to XML
            item = ExportOptions.Add("xml");
            item.Body = GetExportTag("xml");
            item.Visible = false;

            // Export to CSV
            item = ExportOptions.Add("csv");
            item.Body = GetExportTag("csv");
            item.Visible = true;

            // Export to PDF
            item = ExportOptions.Add("pdf");
            item.Body = GetExportTag("pdf");
            item.Visible = false;

            // Export to Email
            item = ExportOptions.Add("email");
            item.Body = GetExportTag("email");
            item.Visible = false;

            // Drop down button for export
            ExportOptions.UseButtonGroup = true;
            ExportOptions.UseDropDownButton = true;
            if (ExportOptions.UseButtonGroup && IsMobile())
                ExportOptions.UseDropDownButton = true;
            ExportOptions.DropDownButtonPhrase = "ButtonExport";

            // Add group option item
            item = ExportOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;
            if (!Security.CanExport) // Export not allowed
                ExportOptions.HideAllOptions();
        }

        // Set up search options
        protected void SetupSearchOptions() {
            ListOption item;

            // Search button
            item = SearchOptions.Add("searchtoggle");
            var searchToggleClass = !Empty(SearchWhere) ? " active" : " active";
            item.Body = "<a class=\"btn btn-default ew-search-toggle" + searchToggleClass + "\" role=\"button\" title=\"" + Language.Phrase("SearchPanel") + "\" data-caption=\"" + Language.Phrase("SearchPanel") + "\" data-ew-action=\"search-toggle\" data-form=\"fMasterTangkisrch\" aria-pressed=\"" + (searchToggleClass == " active" ? "true" : "false") + "\">" + Language.Phrase("SearchLink") + "</a>";
            item.Visible = true;

            // Show all button
            item = SearchOptions.Add("showall");
            if (UseCustomTemplate || !UseAjaxActions)
                item.Body = "<a class=\"btn btn-default ew-show-all\" role=\"button\" title=\"" + Language.Phrase("ShowAll") + "\" data-caption=\"" + Language.Phrase("ShowAll") + "\" href=\"" + AppPath(PageUrl) + "cmd=reset\">" + Language.Phrase("ShowAllBtn") + "</a>";
            else
                item.Body = "<a class=\"btn btn-default ew-show-all\" role=\"button\" title=\"" + Language.Phrase("ShowAll") + "\" data-caption=\"" + Language.Phrase("ShowAll") + "\" data-ew-action=\"refresh\" data-url=\"" + AppPath(PageUrl) + "cmd=reset\">" + Language.Phrase("ShowAllBtn") + "</a>";
            item.Visible = (SearchWhere != DefaultSearchWhere && SearchWhere != "0=101");

            // Button group for search
            SearchOptions.UseDropDownButton = false;
            SearchOptions.UseButtonGroup = true;
            SearchOptions.DropDownButtonPhrase = "ButtonSearch";

            // Add group option item
            item = SearchOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;

            // Hide search options
            if (IsExport() || !Empty(CurrentAction) && CurrentAction != "search")
                SearchOptions.HideAllOptions();
            if (!Security.CanSearch) {
                SearchOptions.HideAllOptions();
                FilterOptions.HideAllOptions();
            }
        }

        // Check if any search fields
        public bool HasSearchFields()
        {
            return true;
        }

        // Render search options
        protected void RenderSearchOptions()
        {
            if (!HasSearchFields() && SearchOptions["searchtoggle"] is ListOption opt)
                opt.Visible = false;
        }

        #pragma warning disable 168

        /// <summary>
        /// Export data
        /// </summary>
        public async Task ExportData(dynamic? doc)
        {
            // Load recordset // DN
            DbDataReader? dr = null;
            if (TotalRecords < 0)
                TotalRecords = await ListRecordCountAsync();
            StartRecord = 1;

            // Export all
            if (ExportAll) {
                DisplayRecords = TotalRecords;
                StopRecord = TotalRecords;
            } else { // Export one page only
                SetupStartRecord(); // Set up start record position
                // Set the last record to display
                if (DisplayRecords < 0) {
                    StopRecord = TotalRecords;
                } else {
                    StopRecord = StartRecord + DisplayRecords - 1;
                }
            }
            CloseRecordset(); // DN
            dr = await LoadRecordset(StartRecord - 1, (DisplayRecords <= 0) ? TotalRecords : DisplayRecords); // DN
            if (doc == null) { // DN
                RemoveHeader("Content-Type"); // Remove header
                RemoveHeader("Content-Disposition");
                FailureMessage = Language.Phrase("ExportClassNotFound"); // Export class not found
                return;
            }

            // Call Page Exporting server event
            doc.ExportCustom = !PageExporting(ref doc);

            // Page header
            string header = PageHeader;
            PageDataRendering(ref header);
            doc.Text.Append(header);

            // Export
            if (dr != null)
                await ExportDocument(doc, dr, StartRecord, StopRecord, "");

            // Page footer
            string footer = PageFooter;
            PageDataRendered(ref footer);
            doc.Text.Append(footer);

            // Close recordset
            using (dr) {} // Dispose

            // Export header and footer
            await doc.ExportHeaderAndFooter();

            // Call Page Exported server event
            PageExported(doc);
        }
        #pragma warning restore 168

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            url = Regex.Replace(url, @"\?cmd=reset(all)?$", ""); // Remove cmd=reset / cmd=resetall
            breadcrumb.Add("list", TableVar, url, "", TableVar, true);
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
            infiniteScroll = Param<bool>("infinitescroll");
            if (!Empty(pageNo) && IsNumeric(pageNo)) {
                int page = ConvertToInt(pageNo);
                StartRecord = (page - 1) * DisplayRecords + 1;
                if (StartRecord <= 0)
                    StartRecord = 1;
                else if (StartRecord >= ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1)
                    StartRecord = ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1;
            } else if (!Empty(startRec) && IsNumeric(startRec)) {
                StartRecord = ConvertToInt(startRec);
            } else if (!infiniteScroll) {
                StartRecord = StartRecordNumber;
            }

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

        // Parse query builder rule function
        protected string ParseRules(Dictionary<string, object>? group, string fieldName = "", string itemName = "")
        {
            if (group == null)
                return "";
            string condition = group.ContainsKey("condition") ? ConvertToString(group["condition"]) : "AND";
            if (!(new [] { "AND", "OR" }).Contains(condition))
                throw new System.Exception("Unable to build SQL query with condition '" + condition + "'");
            List<string> parts = [];
            string where = "";
            var groupRules = group.ContainsKey("rules") ? group["rules"] : null;
            if (groupRules is IEnumerable<object> rules) {
                foreach (object rule in rules) {
                    var subRules = JObject.FromObject(rule).ToObject<Dictionary<string, object>>();
                    if (subRules == null)
                        continue;
                    if (subRules.ContainsKey("rules")) {
                        string rulesPart = ParseRules(subRules, fieldName, itemName);
                        if (!Empty(rulesPart))
                            parts.Add("(" + " " + rulesPart + " " + ")" + " ");
                    } else {
                        string field = subRules.ContainsKey("field") ? ConvertToString(subRules["field"]) : "";
                        var fld = FieldByParam(field);
                        string dbid = DbId;
                        if (fld is ReportField rfld && rfld.DashboardSearchSourceFields != null) {
                            var item = rfld.DashboardSearchSourceFields.ContainsKey(itemName) ? rfld.DashboardSearchSourceFields[itemName] : null;
                            if (item is Dictionary<string, string> dict) {
                                var tbl = Resolve(dict["table"]);
                                dbid = tbl?.DbId ?? "";
                                fld = tbl?.Fields[dict["field"]] ?? null;
                            } else {
                                fld = null;
                            }
                        }
                        if (fld == null)
                            throw new System.Exception("Failed to find field '" + field + "'");
                        if (Empty(fieldName) || fld.Name == fieldName) { // Field name not specified or matched field name
                            string opr = subRules.ContainsKey("operator") ? ConvertToString(subRules["operator"]) : "";
                            string fldOpr = Config.ClientSearchOperators.FirstOrDefault(o => o.Value == opr).Key;
                            Dictionary<string, object>? ope = Config.QueryBuilderOperators.ContainsKey(opr) ? Config.QueryBuilderOperators[opr] : null;
                            if (ope == null || Empty(fldOpr))
                                throw new System.Exception("Unknown SQL operation for operator '" + opr + "'");
                            int nb_inputs = ope.ContainsKey("nb_inputs") ? ConvertToInt(ope["nb_inputs"]) : 0;
                            object val = subRules.ContainsKey("value") ? subRules["value"] : "";
                            if (nb_inputs > 0 && !Empty(val) || IsNullOrEmptyOperator(fldOpr)) {
                                string fldVal = val is List<object> list
                                    ? (list[0] is IEnumerable<string> ? String.Join(Config.MultipleOptionSeparator, list[0]) : ConvertToString(list[0]))
                                    : ConvertToString(val);
                                bool useFilter = fld.UseFilter; // Query builder does not use filter
                                try {
                                    if (fld is ReportField rfld2) { // Search report fields
                                        if (rfld2.SearchType == "dropdown") {
                                            if (val is List<object> list2) {
                                                string sql = "";
                                                foreach (object val2 in list2)
                                                    AddFilter(ref sql, DropDownFilter(rfld2, ConvertToString(val2), fldOpr, dbid), "OR");
                                                parts.Add(sql);
                                            } else {
                                                parts.Add(DropDownFilter(rfld2, fldVal, fldOpr, dbid));
                                            }
                                        } else {
                                            fld.AdvancedSearch.SearchOperator = fldOpr;
                                            fld.AdvancedSearch.SearchValue = fldVal;
                                            parts.Add(GetReportFilter(rfld2, false, dbid));
                                        }
                                    } else { // Search normal fields
                                        if (fld.IsMultiSelect) {
                                            fld.AdvancedSearch.SearchValue = ConvertSearchValue(fldVal, fldOpr, fld);
                                            parts.Add(!Empty(fldVal) ? GetMultiSearchSql(fld, fldOpr, fld.AdvancedSearch.SearchValue, dbid) : "");
                                        } else {
                                            string fldVal2 = fldOpr.Contains("BETWEEN")
                                                ? (val is List<object> list2 && list2.Count > 1
                                                    ? (list2[1] is IEnumerable<string> ? String.Join(Config.MultipleOptionSeparator, list2[1]) : ConvertToString(list2[1]))
                                                    : "")
                                                : ""; // BETWEEN
                                            fld.AdvancedSearch.SearchValue = ConvertSearchValue(fldVal, fldOpr, fld);
                                            fld.AdvancedSearch.SearchValue2 = ConvertSearchValue(fldVal2, fldOpr, fld);
                                            parts.Add(GetSearchSql(
                                                fld,
                                                fld.AdvancedSearch.SearchValue, // SearchValue
                                                fldOpr,
                                                "", // fldCond not used
                                                fld.AdvancedSearch.SearchValue2, // SearchValue2
                                                "", // fldOpr2 not used
                                                dbid
                                            ));
                                        }
                                    }
                                } finally {
                                    fld.UseFilter = useFilter;
                                }
                            }
                        }
                    }
                }
                where = String.Join(" " + condition + " ", parts);
                bool not = group.ContainsKey("not") ? ConvertToBool(group["not"]) : false;
                if (not)
                    where = "NOT (" + where + ")";
            }
            return where;
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

        // ListOptions Load event
        public virtual void ListOptionsLoad() {
            // Example:
            //var opt = ListOptions.Add("new");
            //opt.Header = "xxx";
            //opt.OnLeft = true; // Link on left
            //opt.MoveTo(0); // Move to first column
        }

        // ListOptions Rendering event
        public virtual void ListOptionsRendering() {
            //xxxGrid.DetailAdd = (...condition...); // Set to true or false conditionally
            //xxxGrid.DetailEdit = (...condition...); // Set to true or false conditionally
            //xxxGrid.DetailView = (...condition...); // Set to true or false conditionally
        }

        // ListOptions Rendered event
        public virtual void ListOptionsRendered() {
            //Example:
            //ListOptions["new"].Body = "xxx";
        }

        // Row Custom Action event
        public virtual bool RowCustomAction(string action, Dictionary<string, object> row) {
            // Return false to abort
            return true;
        }

        // Page Exporting event
        // doc = export document object
        public virtual bool PageExporting(ref dynamic doc) {
            //doc.Text.Append("<p>" + "my header" + "</p>"); // Export header
            //return false; // Return false to skip default export and use Row_Export event
            return true; // Return true to use default export and skip Row_Export event
        }

        // Page Exported event
        // doc = export document object
        public virtual void PageExported(dynamic doc) {
            //doc.Text.Append("my footer"); // Export footer
            //Log("Text: {Text}", doc.Text.ToString());
        }

        // Grid Inserting event
        public virtual bool GridInserting() {
            // Enter your code here
            // To reject grid insert, set return value to false
            return true;
        }

        // Grid Inserted event
        public virtual void GridInserted(List<Dictionary<string, object>> rsnew) {
            //Log("Grid Inserted");
        }

        // Grid Updating event
        public virtual bool GridUpdating(List<Dictionary<string, object>> rsold) {
            // Enter your code here
            // To reject grid update, set return value to false
            return true;
        }

        // Grid Updated event
        public virtual void GridUpdated(List<Dictionary<string, object>> rsold, List<Dictionary<string, object>> rsnew) {
            //Log("Grid Updated");
        }
    } // End page class
} // End Partial class
