namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penyimpananSampleList
    /// </summary>
    public static PenyimpananSampleList penyimpananSampleList
    {
        get => HttpData.Get<PenyimpananSampleList>("penyimpananSampleList")!;
        set => HttpData["penyimpananSampleList"] = value;
    }

    /// <summary>
    /// Page class for PenyimpananSample
    /// </summary>
    public class PenyimpananSampleList : PenyimpananSampleListBase
    {
        // Constructor
        public PenyimpananSampleList(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenyimpananSampleList() : base()
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
            foreach (var item in OtherOptions["addedit"].Items)
            {
                if (item.Name == "add")
                    item.Visible = false;
            }
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenyimpananSampleListBase : PenyimpananSample
    {
        // Page ID
        public string PageID = "list";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penyimpananSampleList";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fPenyimpananSamplelist";

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
        public PenyimpananSampleListBase()
        {
            TableName = "PenyimpananSample";

            // CSS class name as context
            TableVar = "PenyimpananSample";
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

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // CSS class name as context
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Language object
            Language = ResolveLanguage();

            // Table object (penyimpananSample)
            if (penyimpananSample == null || penyimpananSample is PenyimpananSample)
                penyimpananSample = this;

            // Initialize URLs
            AddUrl = "PenyimpananSampleAdd";
            InlineAddUrl = PageUrl + "action=add";
            GridAddUrl = PageUrl + "action=gridadd";
            GridEditUrl = PageUrl + "action=gridedit";
            MultiEditUrl = PageUrl + "action=multiedit";
            MultiDeleteUrl = "PenyimpananSampleDelete";
            MultiUpdateUrl = "PenyimpananSampleUpdate";

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
        public string PageName => "PenyimpananSampleList";

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
            NomorPenyimpananSample.SetVisibility();
            JenisSample.SetVisibility();
            IdPlant.SetVisibility();
            Tanggal.SetVisibility();
            NamaMasterSample.SetVisibility();
            NomorSegel.SetVisibility();
            Status.SetVisibility();
            Foto.Visible = false;
            DownloadFoto.SetVisibility();
            ExpiredEst.SetVisibility();
            TanggalDimusnahkan.SetVisibility();
            LokasiPemusnahan.SetVisibility();
            CreatedBy.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
        }

        // Constructor
        public PenyimpananSampleListBase(Controller? controller = null): this() { // DN
            if (controller != null)
                Controller = controller;
        }

        /// <summary>
        /// Terminate page
        /// </summary>
        /// <param name="url">URL to rediect to</param>
        /// <returns>Page result</returns>
        public override IActionResult Terminate(string url = "") { // DN
            if (_terminated) // DN
                return new EmptyResult();

            // Page Unload event
            PageUnload();

            // Global Page Unloaded event
            PageUnloaded();
            PageUnloadedEventHandler?.Invoke(this, EventArgs.Empty);
            if (!IsApi())
                PageRedirecting(ref url);

            // Gargage collection
            Collect(); // DN

            // Terminate
            _terminated = true; // DN

            // Return for API
            if (IsApi()) {
                var result = new Dictionary<string, string> { { "version", Config.ProductVersion } };
                if (!Empty(url)) // Add url
                    result.Add("url", GetUrl(url));
                foreach (var (key, value) in GetMessages()) // Add messages
                    result.Add(key, value);
                return Controller.Json(result);
            } else if (ActionResult != null) { // Check action result
                return ActionResult;
            }

            // Go to URL if specified
            if (!Empty(url)) {
                if (!Config.Debug)
                    ResponseClear();
                if (Response != null && !Response.HasStarted) {
                    // Handle modal response
                    if (IsModal) { // Show as modal
                        string pageName = GetPageName(url);
                        var result = new Dictionary<string, string> { {"url", GetUrl(url)}, {"modal", "1"} }; // Assume return to modal for simplicity
                            if (!SameString(pageName, ListUrl)) { // Not List page
                                result.Add("caption", GetModalCaption(pageName));
                                result.Add("view", pageName == "PenyimpananSampleView" ? "1" : "0"); // If View page, no primary button
                            } else { // List page
                                // result.Add("list", PageID == "search" ? "1" : "0"); // Refresh List page if current page is Search page
                                result.Add("error", FailureMessage); // List page should not be shown as modal => error
                                ClearFailureMessage();
                            }
                        return Controller.Json(result);
                    } else {
                        SaveDebugMessage();
                        return Controller.LocalRedirect(AppPath(url));
                    }
                }
            }
            return new EmptyResult();
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

        // Get record from Dictionary
        protected Dictionary<string, object>? GetRecordFromDictionary(Dictionary<string, object>? dict) {
            if (dict == null)
                return null;
            var row = new Dictionary<string, object>();
            foreach (var (key, value) in dict) {
                if (Fields.TryGetValue(key, out DbField? fld) && fld != null) {
                    if (fld.Visible || fld.IsPrimaryKey) { // Primary key or Visible
                        if (fld.HtmlTag == "FILE") { // Upload field
                            if (Empty(value)) {
                                // row[key] = null;
                            } else {
                                if (fld.DataType == DataType.Blob) {
                                    string url = FullUrl(GetPageName(Config.ApiUrl) + "/" + Config.ApiFileAction + "/" + fld.TableVar + "/" + fld.Param + "/" + GetRecordKeyValue(dict)); // Query string format
                                    row[key] = new Dictionary<string, object> { { "type", ContentType((byte[])value) }, { "url", url }, { "name", fld.Param + ContentExtension((byte[])value) } };
                                } else if (!fld.UploadMultiple || !ConvertToString(value).Contains(Config.MultipleUploadSeparator)) { // Single file
                                    string url = FullUrl(GetPageName(Config.ApiUrl) + "/" + Config.ApiFileAction + "/" + fld.TableVar + "/" + Encrypt(fld.PhysicalUploadPath + ConvertToString(value))); // Query string format
                                    row[key] = new Dictionary<string, object> { { "type", ContentType(ConvertToString(value)) }, { "url", url }, { "name", ConvertToString(value) } };
                                } else { // Multiple files
                                    var files = ConvertToString(value).Split(Config.MultipleUploadSeparator);
                                    row[key] = files.Where(file => !Empty(file)).Select(file => new Dictionary<string, object> { { "type", ContentType(file) }, { "url", FullUrl(GetPageName(Config.ApiUrl) + "/" + Config.ApiFileAction + "/" + fld.TableVar + "/" + Encrypt(fld.PhysicalUploadPath + file)) }, { "name", file } });
                                }
                            }
                        } else {
                            string val = ConvertToString(value);
                            if (fld.DataType == DataType.Date && value is DateTime dt)
                                val = dt.ToString("s");
                            if (fld.DataType == DataType.Memo && fld.MemoMaxLength > 0 && !Empty(val))
                                val = TruncateMemo(val, fld.MemoMaxLength, fld.TruncateMemoRemoveHtml);
                            row[key] = ConvertToString(val);
                        }
                    }
                }
            }
            return row;
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
            string? v;

            // Get lookup object
            string fieldName = IsDictionary(dict) && dict.TryGetValue("field", out v) && v != null ? v : Post("field");
            var lookupField = FieldByName(fieldName);
            var lookup = lookupField?.Lookup;
            if (lookup == null) // DN
                return new Dictionary<string, object>();
            string lookupType = IsDictionary(dict) && dict.TryGetValue("ajax", out v) && v != null ? v : (Post("ajax") ?? "unknown");
            int pageSize = -1;
            int offset = -1;
            string searchValue = "";
            if (SameText(lookupType, "modal") || SameText(lookupType, "filter")) {
                searchValue = IsDictionary(dict) && (dict.TryGetValue("q", out v) && v != null || dict.TryGetValue("sv", out v) && v != null)
                    ? v
                    : (Param("q") ?? Post("sv"));
                pageSize = IsDictionary(dict) && (dict.TryGetValue("n", out v) || dict.TryGetValue("recperpage", out v))
                    ? ConvertToInt(v)
                    : (IsNumeric(Param("n")) ? Param<int>("n") : (Post("recperpage", out StringValues rpp) ? ConvertToInt(rpp.ToString()) : 10));
            } else if (SameText(lookupType, "autosuggest")) {
                searchValue = IsDictionary(dict) && dict.TryGetValue("q", out v) && v != null ? v : Param("q");
                pageSize = IsDictionary(dict) && dict.TryGetValue("n", out v) ? ConvertToInt(v) : (IsNumeric(Param("n")) ? Param<int>("n") : -1);
                if (pageSize <= 0)
                    pageSize = Config.AutoSuggestMaxEntries;
            }
            int start = IsDictionary(dict) && dict.TryGetValue("start", out v) ? ConvertToInt(v) : (IsNumeric(Param("start")) ? Param<int>("start") : -1);
            int page = IsDictionary(dict) && dict.TryGetValue("page", out v) ? ConvertToInt(v) : (IsNumeric(Param("page")) ? Param<int>("page") : -1);
            offset = start >= 0 ? start : (page > 0 && pageSize > 0 ? (page - 1) * pageSize : 0);
            string userSelect = Decrypt(IsDictionary(dict) && dict.TryGetValue("s", out v) && v != null ? v : Post("s"));
            string userFilter = Decrypt(IsDictionary(dict) && dict.TryGetValue("f", out v) && v != null ? v : Post("f"));
            string userOrderBy = Decrypt(IsDictionary(dict) && dict.TryGetValue("o", out v) && v != null ? v : Post("o"));

            // Selected records from modal, skip parent/filter fields and show all records
            lookup.LookupType = lookupType; // Lookup type
            lookup.FilterValues.Clear(); // Clear filter values first
            StringValues keys = IsDictionary(dict) && dict.TryGetValue("keys", out v) && !Empty(v)
                ? (StringValues)v
                : (Post("keys[]", out StringValues k) ? (StringValues)k : StringValues.Empty);
            if (!Empty(keys)) { // Selected records from modal
                lookup.FilterFields = new(); // Skip parent fields if any
                pageSize = -1; // Show all records
                lookup.FilterValues.Add(String.Join(",", keys.ToArray()));
            } else { // Lookup values
                string lookupValue = IsDictionary(dict) && (dict.TryGetValue("v0", out v) && v != null || dict.TryGetValue("lookupValue", out v) && v != null)
                    ? v
                    : (Post<string>("v0") ?? Post("lookupValue"));
                lookup.FilterValues.Add(lookupValue);
            }
            int cnt = IsDictionary(lookup.FilterFields) ? lookup.FilterFields.Count : 0;
            for (int i = 1; i <= cnt; i++) {
                var val = UrlDecode(IsDictionary(dict) && dict.TryGetValue("v" + i, out v) ? v : Post("v" + i));
                if (val != null) // DN
                    lookup.FilterValues.Add(val);
            }
            lookup.SearchValue = searchValue;
            lookup.PageSize = pageSize;
            lookup.Offset = offset;
            if (userSelect != "")
                lookup.UserSelect = userSelect;
            if (userFilter != "")
                lookup.UserFilter = userFilter;
            if (userOrderBy != "")
                lookup.UserOrderBy = userOrderBy;
            return await lookup.ToJson(this);
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

        #pragma warning disable 219
        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            // Multi column button position
            MultiColumnListOptionsPosition = Config.MultiColumnListOptionsPosition;
            if (Empty(DashboardReport))
                DashboardReport = Param(Config.PageDashboard);

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
            PageLoadingEventHandler?.Invoke(this, EventArgs.Empty);

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
            if (!UseAjaxActions)
                HideFieldsForAddEdit();
            // Use inline delete
            if (UseAjaxActions)
                InlineDelete = true;

            // Setup other options
            SetupOtherOptions();

            // Set up lookup cache
            await SetupLookupOptions(JenisSample);
            await SetupLookupOptions(IdPlant);

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fPenyimpananSamplegrid";

            // Set up infinite scroll
            UseInfiniteScroll = Param<bool>("infinitescroll");

            // Search filters
            string srchAdvanced = ""; // Advanced search filter
            string srchBasic = ""; // Basic search filter
            string query = ""; // Query builder

            // Set up Dashboard Filter
            if (!Empty(DashboardReport))
                AddFilter(ref Filter, GetDashboardFilter(DashboardReport, TableVar));

            // Get command
            Command = Get("cmd").ToLower();

            // Process list action first
            var result = await ProcessListAction();
            if (result is not EmptyResult) // Ajax request
                return result;

            // Set up records per page
            SetupDisplayRecords();

            // Handle reset command
            ResetCommand();

            // Set up Breadcrumb
            if (!IsExport())
                SetupBreadcrumb();

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

            // Get default search criteria
            AddFilter(ref DefaultSearchWhere, BasicSearchWhere(true));
            AddFilter(ref DefaultSearchWhere, AdvancedSearchWhere(true));

            // Get basic search values
            LoadBasicSearchValues();

            // Get and validate search values for advanced search
            if (Empty(UserAction)) // Skip if user action
                LoadSearchValues(); // Get search values

            // Process filter list
            var filterResult = await ProcessFilterList();
            if (filterResult != null) {
                // Clean output buffer
                if (!Config.Debug)
                    Response?.Clear();
                return Controller.Json(filterResult);
            }
            CurrentForm?.ResetIndex();
            if (!ValidateSearch()) {
                // Nothing to do
            }

            // Restore search parms from Session if not searching / reset / export
            if ((IsExport() || Command != "search" && Command != "reset" && Command != "resetall") && Command != "json" && CheckSearchParms())
                RestoreSearchParms();

            // Call Recordset SearchValidated event
            RecordsetSearchValidated();

            // Set up sorting order
            SetupSortOrder();

            // Get basic search criteria
            if (!HasInvalidFields())
                srchBasic = BasicSearchWhere();

            // Get search criteria for advanced search
            if (!HasInvalidFields())
                srchAdvanced = AdvancedSearchWhere();

            // Get query builder criteria
            query = !Empty(DashboardReport) ? "" : QueryBuilderWhere();

            // Restore display records
            if (Command != "json" && (RecordsPerPage == -1 || RecordsPerPage > 0)) {
                DisplayRecords = RecordsPerPage; // Restore from Session
            } else {
                DisplayRecords = 10; // Load default
                RecordsPerPage = DisplayRecords; // Save default to session
            }

            // Load search default if no existing search criteria
            if (!CheckSearchParms() && Empty(query)) {
                // Load basic search from default
                BasicSearch.LoadDefault();
                if (!Empty(BasicSearch.Keyword))
                    srchBasic = BasicSearchWhere(); // Save to session

                // Load advanced search from default
                if (LoadAdvancedSearchDefault())
                    srchAdvanced = AdvancedSearchWhere(); // Save to session
            }

            // Restore search settings from Session
            if (!HasInvalidFields())
                LoadAdvancedSearch();

            // Build search criteria
            if (!Empty(query)) {
                AddFilter(ref SearchWhere, query);
            } else {
                AddFilter(ref SearchWhere, srchAdvanced);
                AddFilter(ref SearchWhere, srchBasic);
            }

            // Call Recordset Searching event
            RecordsetSearching(ref SearchWhere);

            // Save search criteria
            if (Command == "search" && !RestoreSearch) {
                SessionSearchWhere = SearchWhere; // Save to Session (rename as SessionSearchWhere property)
                StartRecord = 1; // Reset start record counter
                StartRecordNumber = StartRecord;
            } else if (Command != "json" && Empty(query)) {
                SearchWhere = SessionSearchWhere;
            }

            // Build filter
            if (!Security.CanList)
                Filter = "(0=1)"; // Filter all records
            AddFilter(ref Filter, DbDetailFilter);
            AddFilter(ref Filter, SearchWhere);

            // Set up filter
            if (Command == "json") {
                UseSessionForListSql = false; // Do not use session for ListSql
                CurrentFilter = Filter;
            } else {
                SessionWhere = Filter;
                CurrentFilter = "";
            }
            Filter = ApplyUserIDFilters(Filter);
            if (IsGridAdd) {
                CurrentFilter = "0=1";
                StartRecord = 1;
                DisplayRecords = GridAddRowCount;
                TotalRecords = DisplayRecords;
                StopRecord = DisplayRecords;
            } else if ((IsEdit || IsCopy || IsInlineInserted || IsInlineUpdated) && UseInfiniteScroll) { // Get current record only
                CurrentFilter = IsInlineUpdated ? GetRecordFilter() : GetFilterFromRecordKeys();
                TotalRecords = ListRecordCount();
                StartRecord = 1;
                StopRecord = DisplayRecords;
                Recordset = await LoadRecordset();
            } else if (
                UseInfiniteScroll && IsGridInserted ||
                UseInfiniteScroll && (IsGridEdit || IsGridUpdated) ||
                IsMultiEdit ||
                UseInfiniteScroll && IsMultiUpdated
            ) { // Get current records only
                CurrentFilter = FilterForModalActions; // Restore filter
                TotalRecords = ListRecordCount();
                StartRecord = 1;
                StopRecord = DisplayRecords;
                Recordset = await LoadRecordset();
            } else {
                TotalRecords = await ListRecordCountAsync();
                StopRecord = DisplayRecords;
                StartRecord = 1;
                if (DisplayRecords <= 0 || (IsExport() && ExportAll)) // Display all records
                    DisplayRecords = TotalRecords;
                if (!(IsExport() && ExportAll)) // Set up start record position
                    SetupStartRecord();

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

            // Search options
            SetupSearchOptions();

            // Set up search panel class
            if (!Empty(SearchWhere)) {
                if (!Empty(query)) { // Hide search panel if using QueryBuilder
                    SearchPanelClass = RemoveClass(SearchPanelClass, "show");
                } else {
                    SearchPanelClass = AppendClass(SearchPanelClass, "show");
                }
            }

            // API list action
            if (IsApi()) {
                if (CurrentPageName().ToLowerInvariant().EndsWith(Config.ApiListAction)) { // DN
                    if (!IsExport()) {
                        if (!Connection.SelectOffset && Recordset != null) { // DN
                            for (var i = 1; i <= StartRecord - 1; i++) // Move to first record
                                await Recordset.ReadAsync();
                        }
                        using (Recordset) {
                            return Controller.Json(new Dictionary<string, object> { {"success", true}, {TableVar, await GetRecordsFromRecordset(Recordset)}, {"totalRecordCount", TotalRecords}, {"version", Config.ProductVersion} });
                        }
                    }
                } else if (!Empty(FailureMessage)) {
                    return Controller.Json(new { success = false, error = GetFailureMessage() });
                }
                return new EmptyResult();
            }

            // Render other options
            RenderOtherOptions();

            // Set ReturnUrl in header if necessary
            if (TempData["Return-Url"] != null)
                AddHeader("Return-Url", ConvertToString(TempData["Return-Url"]));

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();
                PageRenderingEventHandler?.Invoke(this, EventArgs.Empty);

                // Page Render event
                penyimpananSampleList?.PageRender();
            }
            return PageResult();
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
            filters.Merge(JObject.Parse(NomorPenyimpananSample.AdvancedSearch.ToJson())); // Field NomorPenyimpananSample
            filters.Merge(JObject.Parse(JenisSample.AdvancedSearch.ToJson())); // Field JenisSample
            filters.Merge(JObject.Parse(IdPlant.AdvancedSearch.ToJson())); // Field IdPlant
            filters.Merge(JObject.Parse(Tanggal.AdvancedSearch.ToJson())); // Field Tanggal
            filters.Merge(JObject.Parse(NamaMasterSample.AdvancedSearch.ToJson())); // Field NamaMasterSample
            filters.Merge(JObject.Parse(NomorSegel.AdvancedSearch.ToJson())); // Field NomorSegel
            filters.Merge(JObject.Parse(Status.AdvancedSearch.ToJson())); // Field Status
            filters.Merge(JObject.Parse(Foto.AdvancedSearch.ToJson())); // Field Foto
            filters.Merge(JObject.Parse(ExpiredEst.AdvancedSearch.ToJson())); // Field ExpiredEst
            filters.Merge(JObject.Parse(TanggalDimusnahkan.AdvancedSearch.ToJson())); // Field TanggalDimusnahkan
            filters.Merge(JObject.Parse(LokasiPemusnahan.AdvancedSearch.ToJson())); // Field LokasiPemusnahan
            filters.Merge(JObject.Parse(CreatedBy.AdvancedSearch.ToJson())); // Field CreatedBy
            filters.Merge(JObject.Parse(etlDate.AdvancedSearch.ToJson())); // Field etlDate
            filters.Merge(JObject.Parse(LastUpdatedBy.AdvancedSearch.ToJson())); // Field LastUpdatedBy
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
            string? sv;

            // Field NomorPenyimpananSample
            if (filter?.TryGetValue("x_NomorPenyimpananSample", out sv) ?? false) {
                NomorPenyimpananSample.AdvancedSearch.SearchValue = sv;
                NomorPenyimpananSample.AdvancedSearch.SearchOperator = filter["z_NomorPenyimpananSample"];
                NomorPenyimpananSample.AdvancedSearch.SearchCondition = filter["v_NomorPenyimpananSample"];
                NomorPenyimpananSample.AdvancedSearch.SearchValue2 = filter["y_NomorPenyimpananSample"];
                NomorPenyimpananSample.AdvancedSearch.SearchOperator2 = filter["w_NomorPenyimpananSample"];
                NomorPenyimpananSample.AdvancedSearch.Save();
            }

            // Field JenisSample
            if (filter?.TryGetValue("x_JenisSample", out sv) ?? false) {
                JenisSample.AdvancedSearch.SearchValue = sv;
                JenisSample.AdvancedSearch.SearchOperator = filter["z_JenisSample"];
                JenisSample.AdvancedSearch.SearchCondition = filter["v_JenisSample"];
                JenisSample.AdvancedSearch.SearchValue2 = filter["y_JenisSample"];
                JenisSample.AdvancedSearch.SearchOperator2 = filter["w_JenisSample"];
                JenisSample.AdvancedSearch.Save();
            }

            // Field IdPlant
            if (filter?.TryGetValue("x_IdPlant", out sv) ?? false) {
                IdPlant.AdvancedSearch.SearchValue = sv;
                IdPlant.AdvancedSearch.SearchOperator = filter["z_IdPlant"];
                IdPlant.AdvancedSearch.SearchCondition = filter["v_IdPlant"];
                IdPlant.AdvancedSearch.SearchValue2 = filter["y_IdPlant"];
                IdPlant.AdvancedSearch.SearchOperator2 = filter["w_IdPlant"];
                IdPlant.AdvancedSearch.Save();
            }

            // Field Tanggal
            if (filter?.TryGetValue("x_Tanggal", out sv) ?? false) {
                Tanggal.AdvancedSearch.SearchValue = sv;
                Tanggal.AdvancedSearch.SearchOperator = filter["z_Tanggal"];
                Tanggal.AdvancedSearch.SearchCondition = filter["v_Tanggal"];
                Tanggal.AdvancedSearch.SearchValue2 = filter["y_Tanggal"];
                Tanggal.AdvancedSearch.SearchOperator2 = filter["w_Tanggal"];
                Tanggal.AdvancedSearch.Save();
            }

            // Field NamaMasterSample
            if (filter?.TryGetValue("x_NamaMasterSample", out sv) ?? false) {
                NamaMasterSample.AdvancedSearch.SearchValue = sv;
                NamaMasterSample.AdvancedSearch.SearchOperator = filter["z_NamaMasterSample"];
                NamaMasterSample.AdvancedSearch.SearchCondition = filter["v_NamaMasterSample"];
                NamaMasterSample.AdvancedSearch.SearchValue2 = filter["y_NamaMasterSample"];
                NamaMasterSample.AdvancedSearch.SearchOperator2 = filter["w_NamaMasterSample"];
                NamaMasterSample.AdvancedSearch.Save();
            }

            // Field NomorSegel
            if (filter?.TryGetValue("x_NomorSegel", out sv) ?? false) {
                NomorSegel.AdvancedSearch.SearchValue = sv;
                NomorSegel.AdvancedSearch.SearchOperator = filter["z_NomorSegel"];
                NomorSegel.AdvancedSearch.SearchCondition = filter["v_NomorSegel"];
                NomorSegel.AdvancedSearch.SearchValue2 = filter["y_NomorSegel"];
                NomorSegel.AdvancedSearch.SearchOperator2 = filter["w_NomorSegel"];
                NomorSegel.AdvancedSearch.Save();
            }

            // Field Status
            if (filter?.TryGetValue("x_Status", out sv) ?? false) {
                Status.AdvancedSearch.SearchValue = sv;
                Status.AdvancedSearch.SearchOperator = filter["z_Status"];
                Status.AdvancedSearch.SearchCondition = filter["v_Status"];
                Status.AdvancedSearch.SearchValue2 = filter["y_Status"];
                Status.AdvancedSearch.SearchOperator2 = filter["w_Status"];
                Status.AdvancedSearch.Save();
            }

            // Field Foto
            if (filter?.TryGetValue("x_Foto", out sv) ?? false) {
                Foto.AdvancedSearch.SearchValue = sv;
                Foto.AdvancedSearch.SearchOperator = filter["z_Foto"];
                Foto.AdvancedSearch.SearchCondition = filter["v_Foto"];
                Foto.AdvancedSearch.SearchValue2 = filter["y_Foto"];
                Foto.AdvancedSearch.SearchOperator2 = filter["w_Foto"];
                Foto.AdvancedSearch.Save();
            }

            // Field ExpiredEst
            if (filter?.TryGetValue("x_ExpiredEst", out sv) ?? false) {
                ExpiredEst.AdvancedSearch.SearchValue = sv;
                ExpiredEst.AdvancedSearch.SearchOperator = filter["z_ExpiredEst"];
                ExpiredEst.AdvancedSearch.SearchCondition = filter["v_ExpiredEst"];
                ExpiredEst.AdvancedSearch.SearchValue2 = filter["y_ExpiredEst"];
                ExpiredEst.AdvancedSearch.SearchOperator2 = filter["w_ExpiredEst"];
                ExpiredEst.AdvancedSearch.Save();
            }

            // Field TanggalDimusnahkan
            if (filter?.TryGetValue("x_TanggalDimusnahkan", out sv) ?? false) {
                TanggalDimusnahkan.AdvancedSearch.SearchValue = sv;
                TanggalDimusnahkan.AdvancedSearch.SearchOperator = filter["z_TanggalDimusnahkan"];
                TanggalDimusnahkan.AdvancedSearch.SearchCondition = filter["v_TanggalDimusnahkan"];
                TanggalDimusnahkan.AdvancedSearch.SearchValue2 = filter["y_TanggalDimusnahkan"];
                TanggalDimusnahkan.AdvancedSearch.SearchOperator2 = filter["w_TanggalDimusnahkan"];
                TanggalDimusnahkan.AdvancedSearch.Save();
            }

            // Field LokasiPemusnahan
            if (filter?.TryGetValue("x_LokasiPemusnahan", out sv) ?? false) {
                LokasiPemusnahan.AdvancedSearch.SearchValue = sv;
                LokasiPemusnahan.AdvancedSearch.SearchOperator = filter["z_LokasiPemusnahan"];
                LokasiPemusnahan.AdvancedSearch.SearchCondition = filter["v_LokasiPemusnahan"];
                LokasiPemusnahan.AdvancedSearch.SearchValue2 = filter["y_LokasiPemusnahan"];
                LokasiPemusnahan.AdvancedSearch.SearchOperator2 = filter["w_LokasiPemusnahan"];
                LokasiPemusnahan.AdvancedSearch.Save();
            }

            // Field CreatedBy
            if (filter?.TryGetValue("x_CreatedBy", out sv) ?? false) {
                CreatedBy.AdvancedSearch.SearchValue = sv;
                CreatedBy.AdvancedSearch.SearchOperator = filter["z_CreatedBy"];
                CreatedBy.AdvancedSearch.SearchCondition = filter["v_CreatedBy"];
                CreatedBy.AdvancedSearch.SearchValue2 = filter["y_CreatedBy"];
                CreatedBy.AdvancedSearch.SearchOperator2 = filter["w_CreatedBy"];
                CreatedBy.AdvancedSearch.Save();
            }

            // Field etlDate
            if (filter?.TryGetValue("x_etlDate", out sv) ?? false) {
                etlDate.AdvancedSearch.SearchValue = sv;
                etlDate.AdvancedSearch.SearchOperator = filter["z_etlDate"];
                etlDate.AdvancedSearch.SearchCondition = filter["v_etlDate"];
                etlDate.AdvancedSearch.SearchValue2 = filter["y_etlDate"];
                etlDate.AdvancedSearch.SearchOperator2 = filter["w_etlDate"];
                etlDate.AdvancedSearch.Save();
            }

            // Field LastUpdatedBy
            if (filter?.TryGetValue("x_LastUpdatedBy", out sv) ?? false) {
                LastUpdatedBy.AdvancedSearch.SearchValue = sv;
                LastUpdatedBy.AdvancedSearch.SearchOperator = filter["z_LastUpdatedBy"];
                LastUpdatedBy.AdvancedSearch.SearchCondition = filter["v_LastUpdatedBy"];
                LastUpdatedBy.AdvancedSearch.SearchValue2 = filter["y_LastUpdatedBy"];
                LastUpdatedBy.AdvancedSearch.SearchOperator2 = filter["w_LastUpdatedBy"];
                LastUpdatedBy.AdvancedSearch.Save();
            }

            // Field lastUpdatedDate
            if (filter?.TryGetValue("x_lastUpdatedDate", out sv) ?? false) {
                lastUpdatedDate.AdvancedSearch.SearchValue = sv;
                lastUpdatedDate.AdvancedSearch.SearchOperator = filter["z_lastUpdatedDate"];
                lastUpdatedDate.AdvancedSearch.SearchCondition = filter["v_lastUpdatedDate"];
                lastUpdatedDate.AdvancedSearch.SearchValue2 = filter["y_lastUpdatedDate"];
                lastUpdatedDate.AdvancedSearch.SearchOperator2 = filter["w_lastUpdatedDate"];
                lastUpdatedDate.AdvancedSearch.Save();
            }
            if (filter?.TryGetValue(Config.TableBasicSearch, out string? keyword) ?? false)
                BasicSearch.SessionKeyword = keyword;
            if (filter?.TryGetValue(Config.TableBasicSearchType, out string? type) ?? false)
                BasicSearch.SessionType = type;
            return true;
        }

        // Advanced search WHERE clause based on QueryString
        public string AdvancedSearchWhere(bool def = false) {
            string where = "";
            if (!Security.CanSearch)
                return "";
            BuildSearchSql(ref where, NomorPenyimpananSample, def, false); // NomorPenyimpananSample
            BuildSearchSql(ref where, JenisSample, def, true); // JenisSample
            BuildSearchSql(ref where, IdPlant, def, true); // IdPlant
            BuildSearchSql(ref where, Tanggal, def, false); // Tanggal
            BuildSearchSql(ref where, NamaMasterSample, def, false); // NamaMasterSample
            BuildSearchSql(ref where, NomorSegel, def, false); // NomorSegel
            BuildSearchSql(ref where, Status, def, true); // Status
            BuildSearchSql(ref where, Foto, def, false); // Foto
            BuildSearchSql(ref where, ExpiredEst, def, false); // ExpiredEst
            BuildSearchSql(ref where, TanggalDimusnahkan, def, false); // TanggalDimusnahkan
            BuildSearchSql(ref where, LokasiPemusnahan, def, true); // LokasiPemusnahan
            BuildSearchSql(ref where, CreatedBy, def, false); // CreatedBy
            BuildSearchSql(ref where, etlDate, def, false); // etlDate
            BuildSearchSql(ref where, LastUpdatedBy, def, false); // LastUpdatedBy
            BuildSearchSql(ref where, lastUpdatedDate, def, false); // lastUpdatedDate

            // Set up search command
            if (!def && !Empty(where) && (new[] { "", "reset", "resetall" }).Contains(Command))
                Command = "search";
            if (!def && Command == "search") {
                NomorPenyimpananSample.AdvancedSearch.Save(); // NomorPenyimpananSample
                JenisSample.AdvancedSearch.Save(); // JenisSample
                IdPlant.AdvancedSearch.Save(); // IdPlant
                Tanggal.AdvancedSearch.Save(); // Tanggal
                NamaMasterSample.AdvancedSearch.Save(); // NamaMasterSample
                NomorSegel.AdvancedSearch.Save(); // NomorSegel
                Status.AdvancedSearch.Save(); // Status
                Foto.AdvancedSearch.Save(); // Foto
                ExpiredEst.AdvancedSearch.Save(); // ExpiredEst
                TanggalDimusnahkan.AdvancedSearch.Save(); // TanggalDimusnahkan
                LokasiPemusnahan.AdvancedSearch.Save(); // LokasiPemusnahan
                CreatedBy.AdvancedSearch.Save(); // CreatedBy
                etlDate.AdvancedSearch.Save(); // etlDate
                LastUpdatedBy.AdvancedSearch.Save(); // LastUpdatedBy
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
                NomorPenyimpananSample.AdvancedSearch.Save(); // NomorPenyimpananSample
                JenisSample.AdvancedSearch.Save(); // JenisSample
                IdPlant.AdvancedSearch.Save(); // IdPlant
                Tanggal.AdvancedSearch.Save(); // Tanggal
                NamaMasterSample.AdvancedSearch.Save(); // NamaMasterSample
                NomorSegel.AdvancedSearch.Save(); // NomorSegel
                Status.AdvancedSearch.Save(); // Status
                Foto.AdvancedSearch.Save(); // Foto
                ExpiredEst.AdvancedSearch.Save(); // ExpiredEst
                TanggalDimusnahkan.AdvancedSearch.Save(); // TanggalDimusnahkan
                LokasiPemusnahan.AdvancedSearch.Save(); // LokasiPemusnahan
                CreatedBy.AdvancedSearch.Save(); // CreatedBy
                etlDate.AdvancedSearch.Save(); // etlDate
                LastUpdatedBy.AdvancedSearch.Save(); // LastUpdatedBy
                lastUpdatedDate.AdvancedSearch.Save(); // lastUpdatedDate
                SessionRules = rules;
            }

            // Return query
            return where;
        }

        // Build search SQL
        public void BuildSearchSql(ref string where, DbField fld, bool def, bool multiValue)
        {
            string fldParm = fld.Param;
            string fldVal = def ? ConvertToString(fld.AdvancedSearch.SearchValueDefault) : ConvertToString(fld.AdvancedSearch.SearchValue);
            string fldOpr = def ? fld.AdvancedSearch.SearchOperatorDefault : fld.AdvancedSearch.SearchOperator;
            string fldCond = def ? fld.AdvancedSearch.SearchConditionDefault : fld.AdvancedSearch.SearchCondition;
            string fldVal2 = def ? ConvertToString(fld.AdvancedSearch.SearchValue2Default) : ConvertToString(fld.AdvancedSearch.SearchValue2);
            string fldOpr2 = def ? fld.AdvancedSearch.SearchOperator2Default : fld.AdvancedSearch.SearchOperator2;
            fldVal = ConvertSearchValue(fldVal, fldOpr, fld);
            fldVal2 = ConvertSearchValue(fldVal2, fldOpr2, fld);
            fldOpr = ConvertSearchOperator(fldOpr, fld, fldVal);
            fldOpr2 = ConvertSearchOperator(fldOpr2, fld, fldVal2);
            string wrk = "";
            if (Config.SearchMultiValueOption == 1 && !fld.UseFilter || !IsMultiSearchOperator(fldOpr))
                multiValue = false;
            if (multiValue) {
                wrk = !Empty(fldVal) ? GetMultiSearchSql(fld, fldOpr, fldVal, DbId) : ""; // Field value 1
                string wrk2 = !Empty(fldVal2) ? GetMultiSearchSql(fld, fldOpr2, fldVal2, DbId) : ""; // Field value 2
                AddFilter(ref wrk, wrk2, fldCond);
            } else {
                wrk = GetSearchSql(fld, fldVal, fldOpr, fldCond, fldVal2, fldOpr2, DbId);
            }
            string cond = SearchOption == "AUTO" && (new[] { "AND", "OR" }).Contains(BasicSearch.Type)
                ? BasicSearch.Type
                : SameText(SearchOption, "OR") ? "OR" : "AND";
            AddFilter(ref where, wrk, cond);
        }

        // Show list of filters
        public void ShowFilterList()
        {
            // Initialize
            string filterList = "",
                filter = "",
                captionClass = IsExport("email") ? "ew-filter-caption-email" : "ew-filter-caption",
                captionSuffix = IsExport("email") ? ": " : "";

            // Field NomorPenyimpananSample
            filter = QueryBuilderWhere("NomorPenyimpananSample");
            if (Empty(filter))
                BuildSearchSql(ref filter, NomorPenyimpananSample, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + NomorPenyimpananSample.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field JenisSample
            filter = QueryBuilderWhere("JenisSample");
            if (Empty(filter))
                BuildSearchSql(ref filter, JenisSample, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + JenisSample.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field IdPlant
            filter = QueryBuilderWhere("IdPlant");
            if (Empty(filter))
                BuildSearchSql(ref filter, IdPlant, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + IdPlant.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Tanggal
            filter = QueryBuilderWhere("Tanggal");
            if (Empty(filter))
                BuildSearchSql(ref filter, Tanggal, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Tanggal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field NamaMasterSample
            filter = QueryBuilderWhere("NamaMasterSample");
            if (Empty(filter))
                BuildSearchSql(ref filter, NamaMasterSample, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + NamaMasterSample.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field NomorSegel
            filter = QueryBuilderWhere("NomorSegel");
            if (Empty(filter))
                BuildSearchSql(ref filter, NomorSegel, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + NomorSegel.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Status
            filter = QueryBuilderWhere("Status");
            if (Empty(filter))
                BuildSearchSql(ref filter, Status, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Status.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field ExpiredEst
            filter = QueryBuilderWhere("ExpiredEst");
            if (Empty(filter))
                BuildSearchSql(ref filter, ExpiredEst, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + ExpiredEst.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field TanggalDimusnahkan
            filter = QueryBuilderWhere("TanggalDimusnahkan");
            if (Empty(filter))
                BuildSearchSql(ref filter, TanggalDimusnahkan, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + TanggalDimusnahkan.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LokasiPemusnahan
            filter = QueryBuilderWhere("LokasiPemusnahan");
            if (Empty(filter))
                BuildSearchSql(ref filter, LokasiPemusnahan, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LokasiPemusnahan.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CreatedBy
            filter = QueryBuilderWhere("CreatedBy");
            if (Empty(filter))
                BuildSearchSql(ref filter, CreatedBy, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CreatedBy.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field etlDate
            filter = QueryBuilderWhere("etlDate");
            if (Empty(filter))
                BuildSearchSql(ref filter, etlDate, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + etlDate.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LastUpdatedBy
            filter = QueryBuilderWhere("LastUpdatedBy");
            if (Empty(filter))
                BuildSearchSql(ref filter, LastUpdatedBy, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LastUpdatedBy.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field lastUpdatedDate
            filter = QueryBuilderWhere("lastUpdatedDate");
            if (Empty(filter))
                BuildSearchSql(ref filter, lastUpdatedDate, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + lastUpdatedDate.Caption + "</span>" + captionSuffix + filter + "</div>";
            if (!Empty(BasicSearch.Keyword))
                filterList += "<div><span class=\"" + captionClass + "\">" + Language.Phrase("BasicSearchKeyword") + "</span>" + captionSuffix + BasicSearch.Keyword + "</div>";

            // Show Filters
            if (!Empty(filterList)) {
                string message = "<div id=\"ew-filter-list\" class=\"callout callout-info d-table\"><div id=\"ew-current-filters\">" +
                    Language.Phrase("CurrentFilters") + "</div>" + filterList + "</div>";
                MessageShowing(ref message, "");
                Write(message);
            } else { // Output empty tag
                Write("<div id=\"ew-filter-list\"></div>");
            }
        }

        // Return basic search WHERE clause based on search keyword and type
        public string BasicSearchWhere(bool def = false) {
            string searchStr = "";
            if (!Security.CanSearch)
                return "";

            // Fields to search
            List<DbField> searchFlds = [];
            searchFlds.Add(NomorPenyimpananSample);
            searchFlds.Add(JenisSample);
            searchFlds.Add(NamaMasterSample);
            searchFlds.Add(NomorSegel);
            searchFlds.Add(Status);
            searchFlds.Add(Foto);
            searchFlds.Add(LokasiPemusnahan);
            searchFlds.Add(CreatedBy);
            searchFlds.Add(LastUpdatedBy);
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
            if (NomorPenyimpananSample.AdvancedSearch.IssetSession)
                return true;
            if (JenisSample.AdvancedSearch.IssetSession)
                return true;
            if (IdPlant.AdvancedSearch.IssetSession)
                return true;
            if (Tanggal.AdvancedSearch.IssetSession)
                return true;
            if (NamaMasterSample.AdvancedSearch.IssetSession)
                return true;
            if (NomorSegel.AdvancedSearch.IssetSession)
                return true;
            if (Status.AdvancedSearch.IssetSession)
                return true;
            if (Foto.AdvancedSearch.IssetSession)
                return true;
            if (ExpiredEst.AdvancedSearch.IssetSession)
                return true;
            if (TanggalDimusnahkan.AdvancedSearch.IssetSession)
                return true;
            if (LokasiPemusnahan.AdvancedSearch.IssetSession)
                return true;
            if (CreatedBy.AdvancedSearch.IssetSession)
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
            NomorPenyimpananSample.AdvancedSearch.UnsetSession();
            JenisSample.AdvancedSearch.UnsetSession();
            IdPlant.AdvancedSearch.UnsetSession();
            Tanggal.AdvancedSearch.UnsetSession();
            NamaMasterSample.AdvancedSearch.UnsetSession();
            NomorSegel.AdvancedSearch.UnsetSession();
            Status.AdvancedSearch.UnsetSession();
            Foto.AdvancedSearch.UnsetSession();
            ExpiredEst.AdvancedSearch.UnsetSession();
            TanggalDimusnahkan.AdvancedSearch.UnsetSession();
            LokasiPemusnahan.AdvancedSearch.UnsetSession();
            CreatedBy.AdvancedSearch.UnsetSession();
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
            NomorPenyimpananSample.AdvancedSearch.Load();
            JenisSample.AdvancedSearch.Load();
            IdPlant.AdvancedSearch.Load();
            Tanggal.AdvancedSearch.Load();
            NamaMasterSample.AdvancedSearch.Load();
            NomorSegel.AdvancedSearch.Load();
            Status.AdvancedSearch.Load();
            Foto.AdvancedSearch.Load();
            ExpiredEst.AdvancedSearch.Load();
            TanggalDimusnahkan.AdvancedSearch.Load();
            LokasiPemusnahan.AdvancedSearch.Load();
            CreatedBy.AdvancedSearch.Load();
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
                UpdateSort(NomorPenyimpananSample, ctrl); // NomorPenyimpananSample
                UpdateSort(JenisSample, ctrl); // JenisSample
                UpdateSort(IdPlant, ctrl); // IdPlant
                UpdateSort(Tanggal, ctrl); // Tanggal
                UpdateSort(NamaMasterSample, ctrl); // NamaMasterSample
                UpdateSort(NomorSegel, ctrl); // NomorSegel
                UpdateSort(Status, ctrl); // Status
                UpdateSort(DownloadFoto, ctrl); // DownloadFoto
                UpdateSort(ExpiredEst, ctrl); // ExpiredEst
                UpdateSort(TanggalDimusnahkan, ctrl); // TanggalDimusnahkan
                UpdateSort(LokasiPemusnahan, ctrl); // LokasiPemusnahan
                UpdateSort(CreatedBy, ctrl); // CreatedBy
                UpdateSort(etlDate, ctrl); // etlDate
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
                    NomorPenyimpananSample.Sort = "";
                    JenisSample.Sort = "";
                    IdPlant.Sort = "";
                    Tanggal.Sort = "";
                    NamaMasterSample.Sort = "";
                    NomorSegel.Sort = "";
                    Status.Sort = "";
                    Foto.Sort = "";
                    DownloadFoto.Sort = "";
                    ExpiredEst.Sort = "";
                    TanggalDimusnahkan.Sort = "";
                    LokasiPemusnahan.Sort = "";
                    CreatedBy.Sort = "";
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

            // "view"
            listOption = ListOptions["view"];
            string viewcaption = Language.Phrase("ViewLink", true);
            isVisible = Security.CanView;
            if (isVisible) {
                if (ModalView && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-table=""PenyimpananSample"" data-caption=""{viewcaption}"" data-ew-action=""modal"" data-action=""view"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(ViewUrl)) + "\" data-btn=\"null\">" + Language.Phrase("ViewLink") + "</a>");
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-table=""PenyimpananSample"" data-caption=""{editcaption}"" data-ew-action=""modal"" data-action=""edit"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\" data-btn=\"SaveBtn\">" + Language.Phrase("EditLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-caption=""{editcaption}"" href=""" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("EditLink") + "</a>");
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
                                : "<li><button type=\"button\" class=\"dropdown-item ew-action ew-list-action\" data-caption=\"" + title + "\" data-ew-action=\"submit\" form=\"fPenyimpananSamplelist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttributes() + ">" + icon + " " + caption + "</button></li>";
                            if (!Empty(link)) {
                                links.Add(link);
                                if (Empty(body)) // Setup first button
                                    body = disabled
                                    ? "<div class=\"alert alert-light\">" + icon + " " + caption + "</div>"
                                    : "<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlTitle(caption) + "\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fPenyimpananSamplelist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttributes() + ">" + icon + caption + "</button>";
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
                item.Body = $@"<a class=""ew-add-edit ew-add"" title=""{addTitle}"" data-table=""PenyimpananSample"" data-caption=""{addTitle}"" data-ew-action=""modal"" data-action=""add"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(AddUrl)) + "\" data-btn=\"AddBtn\">" + Language.Phrase("AddLink") + "</a>";
            else
                item.Body = $@"<a class=""ew-add-edit ew-add"" title=""{addTitle}"" data-caption=""{addTitle}"" href=""" + HtmlEncode(AppPath(AddUrl)) + "\">" + Language.Phrase("AddLink") + "</a>";
            item.Visible = AddUrl != "" && Security.CanAdd;
            option = options["action"];

            // Add multi delete
            item = option.Add("multidelete");
            string deleteTitle = Language.Phrase("DeleteSelectedLink", true);
            item.Body = $@"<button type=""button"" class=""ew-action ew-multi-delete"" title=""{deleteTitle}"" data-caption=""{deleteTitle}"" form=""fPenyimpananSamplelist""" +
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
                CreateColumnOption(option.Add("NomorPenyimpananSample")); // DN
                CreateColumnOption(option.Add("JenisSample")); // DN
                CreateColumnOption(option.Add("IdPlant")); // DN
                CreateColumnOption(option.Add("Tanggal")); // DN
                CreateColumnOption(option.Add("NamaMasterSample")); // DN
                CreateColumnOption(option.Add("NomorSegel")); // DN
                CreateColumnOption(option.Add("Status")); // DN
                CreateColumnOption(option.Add("DownloadFoto")); // DN
                CreateColumnOption(option.Add("ExpiredEst")); // DN
                CreateColumnOption(option.Add("TanggalDimusnahkan")); // DN
                CreateColumnOption(option.Add("LokasiPemusnahan")); // DN
                CreateColumnOption(option.Add("CreatedBy")); // DN
                CreateColumnOption(option.Add("etlDate")); // DN
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
            item.Body = "<a class=\"ew-save-filter\" data-form=\"fPenyimpananSamplesrch\" data-ew-action=\"none\">" + Language.Phrase("SaveCurrentFilter") + "</a>";
            item.Visible = true;
            item = FilterOptions.Add("deletefilter");
            item.Body = "<a class=\"ew-delete-filter\" data-form=\"fPenyimpananSamplesrch\" data-ew-action=\"none\">" + Language.Phrase("DeleteFilter") + "</a>";
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
                    item.Body = "<<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlEncode(caption) + "\" data-caption=\"" + HtmlEncode(caption) + "\" data-ew-action=\"submit\" form=\"fPenyimpananSamplelist\"" + act.ToDataAttributes() + ">" + icon + "</button>";
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
            ListAction? listAction = null;
            if (filter != "" && userAction != "") {
                // Check permission first
                string actionCaption = userAction;
                foreach (var (key, act) in ListActions.Items) {
                    if (SameString(key, userAction)) {
                        listAction = act;
                        actionCaption = !Empty(act.Caption) ? act.Caption : act.Action;
                        if (CustomActions.ContainsKey(userAction)) {
                            UserAction = userAction;
                            CurrentAction = "";
                        }
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
                CurrentFilter = filter;
                string sql = CurrentSql;
                var rows = await Connection.GetRowsAsync(sql);
                ActionValue = Post("actionvalue");

                // Call row custom action event
                if (rows != null) {
                    if (UseTransaction)
                        Connection.BeginTrans();
                    bool processed = true;
                    SelectedCount = rows.Count();
                    SelectedIndex = 0;
                    foreach (var row in rows) {
                        SelectedIndex++;
                        if (listAction != null) { // Handle list action
                            var result = await listAction.Handle(row, this);
                            processed = result;
                            if (listAction.Method == Config.ActionAjax && result.Value != null) // DN
                                ActionResult = result;
                        }
                        if (!processed)
                            break;
                        processed = RowCustomAction(userAction, row);
                        if (!processed)
                            break;
                    }
                    if (processed) {
                        if (UseTransaction)
                            Connection.CommitTrans(); // Commit the changes
                            SuccessMessage = listAction?.SuccessMessage ?? "";
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("CustomActionCompleted").Replace("%s", actionCaption); // Set up success message
                    } else {
                        if (UseTransaction)
                            Connection.RollbackTrans(); // Rollback changes
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
                }
                CurrentAction = ""; // Clear action
                if (Post("ajax") == userAction) { // Ajax
                    if (ActionResult != null) // Action result set by Row CustomAction event // DN
                        return ActionResult;
                    string msg = "";
                    if (SuccessMessage != "") {
                        msg = "<p class=\"text-success\">" + SuccessMessage + "</p>";
                        ClearSuccessMessage(); // Clear message
                    }
                    if (FailureMessage != "") {
                        msg = "<p class=\"text-danger\">" + FailureMessage + "</p>";
                        ClearFailureMessage(); // Clear message
                    }
                    if (!Empty(msg))
                        return Controller.Content(msg, "text/plain", Encoding.UTF8);
                }
            }
            return new EmptyResult(); // Not ajax request
        }

        // Set up Grid
        public async Task SetupGrid()
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
            if (Recordset != null && Recordset.HasRows) {
                if (!Connection.SelectOffset) { // DN
                    for (int i = 1; i <= StartRecord - 1; i++) { // Move to first record
                        if (await Recordset.ReadAsync())
                            RecordCount++;
                    }
                } else {
                    RecordCount = StartRecord - 1;
                }
            } else if (IsGridAdd && !AllowAddDeleteRow && StopRecord == 0) { // Grid-Add with no records
                StopRecord = GridAddRowCount;
            } else if (IsAdd && TotalRecords == 0) { // Inline-Add with no records
                StopRecord = 1;
            }

            // Initialize aggregate
            RowType = RowType.AggregateInit;
            ResetAttributes();
            await RenderRow();
            if ((IsGridAdd || IsGridEdit)) // Render template row first
                RowIndex = "$rowindex$";
        }

        // Set up Row
        public async Task SetupRow()
        {
            if (IsGridAdd || IsGridEdit) {
                if (SameString(RowIndex, "$rowindex$")) { // Render template row first
                    await LoadRowValues();

                    // Set row properties
                    ResetAttributes();
                    RowAttrs.Add("data-rowindex", ConvertToString(RowIndex));
                    RowAttrs.Add("id", "r0_PenyimpananSample");
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
                    return;
                }
            }

            // Set up key count
            KeyCount = ConvertToInt(RowIndex);

            // Init row class and style
            ResetAttributes();
            CssClass = "";
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
            RowType = RowType.View; // Render view
            if ((IsAdd || IsCopy) && InlineRowCount == 0 || IsGridAdd) // Add
                RowType = RowType.Add; // Render add

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
            RowAttrs.Add("data-rowindex", ConvertToString(penyimpananSampleList.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(penyimpananSampleList.RowCount) + "_PenyimpananSample");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(penyimpananSampleList.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && penyimpananSampleList.RowType == RowType.Add || IsEdit && penyimpananSampleList.RowType == RowType.Edit) // Inline-Add/Edit row
                RowAttrs.AppendClass("table-active");

            // Render row
            await RenderRow();

            // Render list options
            await RenderListOptions();
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
            // Load query builder rules
            string rules = Post("rules");
            if (!Empty(rules) && Empty(Command)) {
                QueryRules = rules;
                Command = "search";
            }

            // NomorPenyimpananSample
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_NomorPenyimpananSample"))
                    NomorPenyimpananSample.AdvancedSearch.SearchValue = Get("x_NomorPenyimpananSample");
                else
                    NomorPenyimpananSample.AdvancedSearch.SearchValue = Get("NomorPenyimpananSample"); // Default Value // DN
            if (!Empty(NomorPenyimpananSample.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_NomorPenyimpananSample"))
                NomorPenyimpananSample.AdvancedSearch.SearchOperator = Get("z_NomorPenyimpananSample");

            // JenisSample
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_JenisSample[]"))
                    JenisSample.AdvancedSearch.SearchValue = Get("x_JenisSample[]", Config.FilterOptionSeparator);
                else
                    JenisSample.AdvancedSearch.SearchValue = Get("JenisSample"); // Default Value // DN
            if (!Empty(JenisSample.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_JenisSample"))
                JenisSample.AdvancedSearch.SearchOperator = Get("z_JenisSample", Config.FilterOptionSeparator);

            // IdPlant
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_IdPlant[]"))
                    IdPlant.AdvancedSearch.SearchValue = Get("x_IdPlant[]", Config.FilterOptionSeparator);
                else
                    IdPlant.AdvancedSearch.SearchValue = Get("IdPlant"); // Default Value // DN
            if (!Empty(IdPlant.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_IdPlant"))
                IdPlant.AdvancedSearch.SearchOperator = Get("z_IdPlant", Config.FilterOptionSeparator);

            // Tanggal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Tanggal"))
                    Tanggal.AdvancedSearch.SearchValue = Get("x_Tanggal", Config.FilterOptionSeparator);
                else
                    Tanggal.AdvancedSearch.SearchValue = Get("Tanggal"); // Default Value // DN
            if (!Empty(Tanggal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Tanggal"))
                Tanggal.AdvancedSearch.SearchOperator = Get("z_Tanggal", Config.FilterOptionSeparator);

            // NamaMasterSample
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_NamaMasterSample"))
                    NamaMasterSample.AdvancedSearch.SearchValue = Get("x_NamaMasterSample", Config.FilterOptionSeparator);
                else
                    NamaMasterSample.AdvancedSearch.SearchValue = Get("NamaMasterSample"); // Default Value // DN
            if (!Empty(NamaMasterSample.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_NamaMasterSample"))
                NamaMasterSample.AdvancedSearch.SearchOperator = Get("z_NamaMasterSample", Config.FilterOptionSeparator);

            // NomorSegel
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_NomorSegel"))
                    NomorSegel.AdvancedSearch.SearchValue = Get("x_NomorSegel", Config.FilterOptionSeparator);
                else
                    NomorSegel.AdvancedSearch.SearchValue = Get("NomorSegel"); // Default Value // DN
            if (!Empty(NomorSegel.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_NomorSegel"))
                NomorSegel.AdvancedSearch.SearchOperator = Get("z_NomorSegel", Config.FilterOptionSeparator);

            // Status
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Status[]"))
                    Status.AdvancedSearch.SearchValue = Get("x_Status[]", Config.FilterOptionSeparator);
                else
                    Status.AdvancedSearch.SearchValue = Get("Status"); // Default Value // DN
            if (!Empty(Status.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Status"))
                Status.AdvancedSearch.SearchOperator = Get("z_Status", Config.FilterOptionSeparator);

            // Foto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Foto"))
                    Foto.AdvancedSearch.SearchValue = Get("x_Foto", Config.FilterOptionSeparator);
                else
                    Foto.AdvancedSearch.SearchValue = Get("Foto"); // Default Value // DN
            if (!Empty(Foto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Foto"))
                Foto.AdvancedSearch.SearchOperator = Get("z_Foto", Config.FilterOptionSeparator);

            // ExpiredEst
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_ExpiredEst"))
                    ExpiredEst.AdvancedSearch.SearchValue = Get("x_ExpiredEst", Config.FilterOptionSeparator);
                else
                    ExpiredEst.AdvancedSearch.SearchValue = Get("ExpiredEst"); // Default Value // DN
            if (!Empty(ExpiredEst.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_ExpiredEst"))
                ExpiredEst.AdvancedSearch.SearchOperator = Get("z_ExpiredEst", Config.FilterOptionSeparator);

            // TanggalDimusnahkan
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_TanggalDimusnahkan"))
                    TanggalDimusnahkan.AdvancedSearch.SearchValue = Get("x_TanggalDimusnahkan", Config.FilterOptionSeparator);
                else
                    TanggalDimusnahkan.AdvancedSearch.SearchValue = Get("TanggalDimusnahkan"); // Default Value // DN
            if (!Empty(TanggalDimusnahkan.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_TanggalDimusnahkan"))
                TanggalDimusnahkan.AdvancedSearch.SearchOperator = Get("z_TanggalDimusnahkan", Config.FilterOptionSeparator);

            // LokasiPemusnahan
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LokasiPemusnahan[]"))
                    LokasiPemusnahan.AdvancedSearch.SearchValue = Get("x_LokasiPemusnahan[]", Config.FilterOptionSeparator);
                else
                    LokasiPemusnahan.AdvancedSearch.SearchValue = Get("LokasiPemusnahan"); // Default Value // DN
            if (!Empty(LokasiPemusnahan.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LokasiPemusnahan"))
                LokasiPemusnahan.AdvancedSearch.SearchOperator = Get("z_LokasiPemusnahan", Config.FilterOptionSeparator);

            // CreatedBy
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CreatedBy"))
                    CreatedBy.AdvancedSearch.SearchValue = Get("x_CreatedBy", Config.FilterOptionSeparator);
                else
                    CreatedBy.AdvancedSearch.SearchValue = Get("CreatedBy"); // Default Value // DN
            if (!Empty(CreatedBy.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CreatedBy"))
                CreatedBy.AdvancedSearch.SearchOperator = Get("z_CreatedBy", Config.FilterOptionSeparator);

            // etlDate
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_etlDate"))
                    etlDate.AdvancedSearch.SearchValue = Get("x_etlDate", Config.FilterOptionSeparator);
                else
                    etlDate.AdvancedSearch.SearchValue = Get("etlDate"); // Default Value // DN
            if (!Empty(etlDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_etlDate"))
                etlDate.AdvancedSearch.SearchOperator = Get("z_etlDate", Config.FilterOptionSeparator);

            // LastUpdatedBy
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LastUpdatedBy"))
                    LastUpdatedBy.AdvancedSearch.SearchValue = Get("x_LastUpdatedBy", Config.FilterOptionSeparator);
                else
                    LastUpdatedBy.AdvancedSearch.SearchValue = Get("LastUpdatedBy"); // Default Value // DN
            if (!Empty(LastUpdatedBy.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LastUpdatedBy"))
                LastUpdatedBy.AdvancedSearch.SearchOperator = Get("z_LastUpdatedBy", Config.FilterOptionSeparator);

            // lastUpdatedDate
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_lastUpdatedDate"))
                    lastUpdatedDate.AdvancedSearch.SearchValue = Get("x_lastUpdatedDate", Config.FilterOptionSeparator);
                else
                    lastUpdatedDate.AdvancedSearch.SearchValue = Get("lastUpdatedDate"); // Default Value // DN
            if (!Empty(lastUpdatedDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
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
            id.CellCssStyle = "white-space: nowrap;";

            // NomorPenyimpananSample

            // JenisSample

            // IdPlant

            // Tanggal

            // NamaMasterSample

            // NomorSegel

            // Status

            // Foto

            // DownloadFoto
            DownloadFoto.CellCssStyle = "white-space: nowrap;";

            // ExpiredEst

            // TanggalDimusnahkan

            // LokasiPemusnahan

            // CreatedBy

            // etlDate

            // LastUpdatedBy

            // lastUpdatedDate

            // View row
            if (RowType == RowType.View) {
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
                string curVal2 = ConvertToString(IdPlant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (IdPlant.Lookup != null && IsDictionary(IdPlant.Lookup?.Options) && IdPlant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPlant.ViewValue = IdPlant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", IdPlant.CurrentValue, IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = IdPlant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && IdPlant.Lookup != null) { // Lookup values found
                            var listwrk = IdPlant.Lookup?.RenderViewRow(rswrk2[0]);
                            IdPlant.ViewValue = IdPlant.DisplayValue(listwrk);
                        } else {
                            IdPlant.ViewValue = FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
                        }
                    }
                } else {
                    IdPlant.ViewValue = DbNullValue;
                }
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

                // DownloadFoto
                DownloadFoto.ViewValue = DownloadFoto.CurrentValue;
                DownloadFoto.ViewCustomAttributes = "";

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

                // DownloadFoto
                DownloadFoto.HrefValue = "";
                DownloadFoto.TooltipValue = "";

                // ExpiredEst
                ExpiredEst.HrefValue = "";
                ExpiredEst.TooltipValue = "";

                // TanggalDimusnahkan
                TanggalDimusnahkan.HrefValue = "";
                TanggalDimusnahkan.TooltipValue = "";

                // LokasiPemusnahan
                LokasiPemusnahan.HrefValue = "";
                LokasiPemusnahan.TooltipValue = "";

                // CreatedBy
                CreatedBy.HrefValue = "";
                CreatedBy.TooltipValue = "";

                // etlDate
                etlDate.HrefValue = "";
                etlDate.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // NomorPenyimpananSample
                NomorPenyimpananSample.SetupEditAttributes();
                if (!NomorPenyimpananSample.Raw)
                    NomorPenyimpananSample.AdvancedSearch.SearchValue = HtmlDecode(NomorPenyimpananSample.AdvancedSearch.SearchValue);
                NomorPenyimpananSample.EditValue = HtmlEncode(NomorPenyimpananSample.AdvancedSearch.SearchValue);
                NomorPenyimpananSample.PlaceHolder = RemoveHtml(NomorPenyimpananSample.Caption);

                // JenisSample
                if (JenisSample.UseFilter && !Empty(JenisSample.AdvancedSearch.SearchValue)) {
                    JenisSample.EditValue = ConvertToString(JenisSample.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // IdPlant
                if (IdPlant.UseFilter && !Empty(IdPlant.AdvancedSearch.SearchValue)) {
                    IdPlant.EditValue = ConvertToString(IdPlant.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // Tanggal
                Tanggal.SetupEditAttributes();
                Tanggal.EditValue = FormatDateTime(UnformatDateTime(Tanggal.AdvancedSearch.SearchValue, Tanggal.FormatPattern), Tanggal.FormatPattern);
                Tanggal.PlaceHolder = RemoveHtml(Tanggal.Caption);

                // NamaMasterSample
                NamaMasterSample.SetupEditAttributes();
                if (!NamaMasterSample.Raw)
                    NamaMasterSample.AdvancedSearch.SearchValue = HtmlDecode(NamaMasterSample.AdvancedSearch.SearchValue);
                NamaMasterSample.EditValue = HtmlEncode(NamaMasterSample.AdvancedSearch.SearchValue);
                NamaMasterSample.PlaceHolder = RemoveHtml(NamaMasterSample.Caption);

                // NomorSegel
                NomorSegel.SetupEditAttributes();
                if (!NomorSegel.Raw)
                    NomorSegel.AdvancedSearch.SearchValue = HtmlDecode(NomorSegel.AdvancedSearch.SearchValue);
                NomorSegel.EditValue = HtmlEncode(NomorSegel.AdvancedSearch.SearchValue);
                NomorSegel.PlaceHolder = RemoveHtml(NomorSegel.Caption);

                // Status
                if (Status.UseFilter && !Empty(Status.AdvancedSearch.SearchValue)) {
                    Status.EditValue = ConvertToString(Status.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // DownloadFoto
                DownloadFoto.SetupEditAttributes();
                DownloadFoto.EditValue = DownloadFoto.AdvancedSearch.SearchValue; // DN
                DownloadFoto.PlaceHolder = RemoveHtml(DownloadFoto.Caption);

                // ExpiredEst
                ExpiredEst.SetupEditAttributes();
                ExpiredEst.EditValue = FormatDateTime(UnformatDateTime(ExpiredEst.AdvancedSearch.SearchValue, ExpiredEst.FormatPattern), ExpiredEst.FormatPattern);
                ExpiredEst.PlaceHolder = RemoveHtml(ExpiredEst.Caption);

                // TanggalDimusnahkan
                TanggalDimusnahkan.SetupEditAttributes();
                TanggalDimusnahkan.EditValue = FormatDateTime(UnformatDateTime(TanggalDimusnahkan.AdvancedSearch.SearchValue, TanggalDimusnahkan.FormatPattern), TanggalDimusnahkan.FormatPattern);
                TanggalDimusnahkan.PlaceHolder = RemoveHtml(TanggalDimusnahkan.Caption);

                // LokasiPemusnahan
                if (LokasiPemusnahan.UseFilter && !Empty(LokasiPemusnahan.AdvancedSearch.SearchValue)) {
                    LokasiPemusnahan.EditValue = ConvertToString(LokasiPemusnahan.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // CreatedBy
                CreatedBy.SetupEditAttributes();
                if (!CreatedBy.Raw)
                    CreatedBy.AdvancedSearch.SearchValue = HtmlDecode(CreatedBy.AdvancedSearch.SearchValue);
                CreatedBy.EditValue = HtmlEncode(CreatedBy.AdvancedSearch.SearchValue);
                CreatedBy.PlaceHolder = RemoveHtml(CreatedBy.Caption);

                // etlDate
                etlDate.SetupEditAttributes();
                etlDate.EditValue = FormatDateTime(UnformatDateTime(etlDate.AdvancedSearch.SearchValue, etlDate.FormatPattern), etlDate.FormatPattern);
                etlDate.PlaceHolder = RemoveHtml(etlDate.Caption);

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                if (!LastUpdatedBy.Raw)
                    LastUpdatedBy.AdvancedSearch.SearchValue = HtmlDecode(LastUpdatedBy.AdvancedSearch.SearchValue);
                LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.AdvancedSearch.SearchValue);
                LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

                // lastUpdatedDate
                lastUpdatedDate.SetupEditAttributes();
                lastUpdatedDate.EditValue = FormatDateTime(UnformatDateTime(lastUpdatedDate.AdvancedSearch.SearchValue, lastUpdatedDate.FormatPattern), lastUpdatedDate.FormatPattern);
                lastUpdatedDate.PlaceHolder = RemoveHtml(lastUpdatedDate.Caption);
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
            NomorPenyimpananSample.AdvancedSearch.Load();
            JenisSample.AdvancedSearch.Load();
            IdPlant.AdvancedSearch.Load();
            Tanggal.AdvancedSearch.Load();
            NamaMasterSample.AdvancedSearch.Load();
            NomorSegel.AdvancedSearch.Load();
            Status.AdvancedSearch.Load();
            Foto.AdvancedSearch.Load();
            ExpiredEst.AdvancedSearch.Load();
            TanggalDimusnahkan.AdvancedSearch.Load();
            LokasiPemusnahan.AdvancedSearch.Load();
            CreatedBy.AdvancedSearch.Load();
            etlDate.AdvancedSearch.Load();
            LastUpdatedBy.AdvancedSearch.Load();
            lastUpdatedDate.AdvancedSearch.Load();
        }

        // Get export HTML tag
        protected string GetExportTag(string type, bool custom = false) {
            string exportUrl = AppPath(CurrentPageName()); // DN
            if (type == "print" || custom) { // Printer friendly / custom export
                exportUrl += "?export=" + type + (custom ? "&amp;custom=1" : "");
            } else {
                exportUrl = AppPath(Config.ApiUrl + Config.ApiExportAction + "/" + type + "/" + TableVar);
            }
            if (SameText(type, "excel")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fPenyimpananSamplelist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fPenyimpananSamplelist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fPenyimpananSamplelist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\">" + Language.Phrase("ExportToPDF") + "</a>";
            } else if (SameText(type, "html")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-html\" title=\"" + HtmlEncode(Language.Phrase("ExportToHtml", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToHtml", true)) + "\">" + Language.Phrase("ExportToHtml") + "</a>";
            } else if (SameText(type, "xml")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-xml\" title=\"" + HtmlEncode(Language.Phrase("ExportToXml", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToXml", true)) + "\">" + Language.Phrase("ExportToXml") + "</a>";
            } else if (SameText(type, "csv")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-csv\" title=\"" + HtmlEncode(Language.Phrase("ExportToCsv", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToCsv", true)) + "\">" + Language.Phrase("ExportToCsv") + "</a>";
            } else if (SameText(type, "email")) {
                string url = custom ? " data-url=\"" + exportUrl + "\"" : "";
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fPenyimpananSamplelist\" data-ew-action=\"email\" data-custom=\"false\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
            } else if (SameText(type, "print")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-print\" title=\"" + HtmlEncode(Language.Phrase("PrinterFriendly", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("PrinterFriendly", true)) + "\">" + Language.Phrase("PrinterFriendly") + "</a>";
            }
            return "";
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
            item.Body = "<a class=\"btn btn-default ew-search-toggle" + searchToggleClass + "\" role=\"button\" title=\"" + Language.Phrase("SearchPanel") + "\" data-caption=\"" + Language.Phrase("SearchPanel") + "\" data-ew-action=\"search-toggle\" data-form=\"fPenyimpananSamplesrch\" aria-pressed=\"" + (searchToggleClass == " active" ? "true" : "false") + "\">" + Language.Phrase("SearchLink") + "</a>";
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
            Func<string>? lookupFilter = null;
            dynamic conn = Connection;
            if (fld.Lookup.Options.Count is int c && c == 0) {
                // Always call to Lookup.GetSql so that user can setup Lookup.Options in Lookup Selecting server event
                var sql = fld.Lookup.GetSql(false, "", lookupFilter, this);

                // Set up lookup cache
                if (!fld.HasLookupOptions && fld.UseLookupCache && !Empty(sql) && fld.Lookup.ParentFields.Count == 0 && fld.Lookup.Options.Count == 0) {
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
            }
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
