namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// bukuTamuList
    /// </summary>
    public static BukuTamuList bukuTamuList
    {
        get => HttpData.Get<BukuTamuList>("bukuTamuList")!;
        set => HttpData["bukuTamuList"] = value;
    }

    /// <summary>
    /// Page class for BukuTamu
    /// </summary>
    public class BukuTamuList : BukuTamuListBase
    {
        // Constructor
        public BukuTamuList(Controller controller) : base(controller)
        {
        }

        // Constructor
        public BukuTamuList() : base()
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
    public class BukuTamuListBase : BukuTamu
    {
        // Page ID
        public string PageID = "list";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "bukuTamuList";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fBukuTamulist";

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
        public BukuTamuListBase()
        {
            TableName = "BukuTamu";

            // CSS class name as context
            TableVar = "BukuTamu";
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

            // Table object (bukuTamu)
            if (bukuTamu == null || bukuTamu is BukuTamu)
                bukuTamu = this;

            // Initialize URLs
            AddUrl = "BukuTamuAdd";
            InlineAddUrl = PageUrl + "action=add";
            GridAddUrl = PageUrl + "action=gridadd";
            GridEditUrl = PageUrl + "action=gridedit";
            MultiEditUrl = PageUrl + "action=multiedit";
            MultiDeleteUrl = "BukuTamuDelete";
            MultiUpdateUrl = "BukuTamuUpdate";

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
        public string PageName => "BukuTamuList";

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
            NomorBukuTamu.Visible = false;
            LinkRedirect.SetVisibility();
            LookupPlant.Visible = false;
            Plant.SetVisibility();
            Tanggal.SetVisibility();
            StatusZona.SetVisibility();
            Nama.SetVisibility();
            AsalPerusahaan.SetVisibility();
            Jabatan.SetVisibility();
            FungsiygDikunjungi.SetVisibility();
            MaksudKunjungan.SetVisibility();
            TandaPengenal.SetVisibility();
            TandaTangan.Visible = false;
            TandaTanganDownload.SetVisibility();
            Keterangan.SetVisibility();
            PintuUtamaId.SetVisibility();
            PintuUtamaInTanggal.SetVisibility();
            PintuUtamaInFoto.Visible = false;
            PintuUtamaInFotoDownload.SetVisibility();
            PintuUtamaInUser.SetVisibility();
            CustomPilihPintu.SetVisibility();
            PintuUtamaOutTanggal.SetVisibility();
            PintuUtamaOutFoto.Visible = false;
            PintuUtamaOutFotoDownload.SetVisibility();
            PintuUtamaOutUser.SetVisibility();
            LobbyUtamaId.SetVisibility();
            LobbyUtamaInTanggal.SetVisibility();
            LobbyUtamaInFoto.Visible = false;
            LobbyUtamaInFotoDownload.SetVisibility();
            LobbyUtamaInUser.SetVisibility();
            LobbyUtamaOutTanggal.SetVisibility();
            LobbyUtamaOutFoto.Visible = false;
            LobbyUtamaOutFotoDownload.SetVisibility();
            LobbyUtamaOutUser.SetVisibility();
            AreaTerlarangId.SetVisibility();
            AreaTerlarangInTanggal.SetVisibility();
            AreaTerlarangInFoto.Visible = false;
            AreaTerlarangInFotoDownload.SetVisibility();
            AreaTerlarangInUser.SetVisibility();
            AreaTerlarangOutTanggal.SetVisibility();
            AreaTerlarangOutFoto.Visible = false;
            AreaTerlarangOutFotoDownload.SetVisibility();
            AreaTerlarangOutUser.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            StatusZonaPrev.Visible = false;
        }

        // Constructor
        public BukuTamuListBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "BukuTamuView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(LookupPlant);
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(FungsiygDikunjungi);
            await SetupLookupOptions(TandaPengenal);

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fBukuTamugrid";

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
                bukuTamuList?.PageRender();
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
            filters.Merge(JObject.Parse(Tanggal.AdvancedSearch.ToJson())); // Field Tanggal
            filters.Merge(JObject.Parse(PintuUtamaInTanggal.AdvancedSearch.ToJson())); // Field PintuUtamaInTanggal
            filters.Merge(JObject.Parse(PintuUtamaOutTanggal.AdvancedSearch.ToJson())); // Field PintuUtamaOutTanggal
            filters.Merge(JObject.Parse(LobbyUtamaInTanggal.AdvancedSearch.ToJson())); // Field LobbyUtamaInTanggal
            filters.Merge(JObject.Parse(LobbyUtamaOutTanggal.AdvancedSearch.ToJson())); // Field LobbyUtamaOutTanggal
            filters.Merge(JObject.Parse(AreaTerlarangInTanggal.AdvancedSearch.ToJson())); // Field AreaTerlarangInTanggal
            filters.Merge(JObject.Parse(AreaTerlarangOutTanggal.AdvancedSearch.ToJson())); // Field AreaTerlarangOutTanggal
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
            string? sv;

            // Field Tanggal
            if (filter?.TryGetValue("x_Tanggal", out sv) ?? false) {
                Tanggal.AdvancedSearch.SearchValue = sv;
                Tanggal.AdvancedSearch.SearchOperator = filter["z_Tanggal"];
                Tanggal.AdvancedSearch.SearchCondition = filter["v_Tanggal"];
                Tanggal.AdvancedSearch.SearchValue2 = filter["y_Tanggal"];
                Tanggal.AdvancedSearch.SearchOperator2 = filter["w_Tanggal"];
                Tanggal.AdvancedSearch.Save();
            }

            // Field PintuUtamaInTanggal
            if (filter?.TryGetValue("x_PintuUtamaInTanggal", out sv) ?? false) {
                PintuUtamaInTanggal.AdvancedSearch.SearchValue = sv;
                PintuUtamaInTanggal.AdvancedSearch.SearchOperator = filter["z_PintuUtamaInTanggal"];
                PintuUtamaInTanggal.AdvancedSearch.SearchCondition = filter["v_PintuUtamaInTanggal"];
                PintuUtamaInTanggal.AdvancedSearch.SearchValue2 = filter["y_PintuUtamaInTanggal"];
                PintuUtamaInTanggal.AdvancedSearch.SearchOperator2 = filter["w_PintuUtamaInTanggal"];
                PintuUtamaInTanggal.AdvancedSearch.Save();
            }

            // Field PintuUtamaOutTanggal
            if (filter?.TryGetValue("x_PintuUtamaOutTanggal", out sv) ?? false) {
                PintuUtamaOutTanggal.AdvancedSearch.SearchValue = sv;
                PintuUtamaOutTanggal.AdvancedSearch.SearchOperator = filter["z_PintuUtamaOutTanggal"];
                PintuUtamaOutTanggal.AdvancedSearch.SearchCondition = filter["v_PintuUtamaOutTanggal"];
                PintuUtamaOutTanggal.AdvancedSearch.SearchValue2 = filter["y_PintuUtamaOutTanggal"];
                PintuUtamaOutTanggal.AdvancedSearch.SearchOperator2 = filter["w_PintuUtamaOutTanggal"];
                PintuUtamaOutTanggal.AdvancedSearch.Save();
            }

            // Field LobbyUtamaInTanggal
            if (filter?.TryGetValue("x_LobbyUtamaInTanggal", out sv) ?? false) {
                LobbyUtamaInTanggal.AdvancedSearch.SearchValue = sv;
                LobbyUtamaInTanggal.AdvancedSearch.SearchOperator = filter["z_LobbyUtamaInTanggal"];
                LobbyUtamaInTanggal.AdvancedSearch.SearchCondition = filter["v_LobbyUtamaInTanggal"];
                LobbyUtamaInTanggal.AdvancedSearch.SearchValue2 = filter["y_LobbyUtamaInTanggal"];
                LobbyUtamaInTanggal.AdvancedSearch.SearchOperator2 = filter["w_LobbyUtamaInTanggal"];
                LobbyUtamaInTanggal.AdvancedSearch.Save();
            }

            // Field LobbyUtamaOutTanggal
            if (filter?.TryGetValue("x_LobbyUtamaOutTanggal", out sv) ?? false) {
                LobbyUtamaOutTanggal.AdvancedSearch.SearchValue = sv;
                LobbyUtamaOutTanggal.AdvancedSearch.SearchOperator = filter["z_LobbyUtamaOutTanggal"];
                LobbyUtamaOutTanggal.AdvancedSearch.SearchCondition = filter["v_LobbyUtamaOutTanggal"];
                LobbyUtamaOutTanggal.AdvancedSearch.SearchValue2 = filter["y_LobbyUtamaOutTanggal"];
                LobbyUtamaOutTanggal.AdvancedSearch.SearchOperator2 = filter["w_LobbyUtamaOutTanggal"];
                LobbyUtamaOutTanggal.AdvancedSearch.Save();
            }

            // Field AreaTerlarangInTanggal
            if (filter?.TryGetValue("x_AreaTerlarangInTanggal", out sv) ?? false) {
                AreaTerlarangInTanggal.AdvancedSearch.SearchValue = sv;
                AreaTerlarangInTanggal.AdvancedSearch.SearchOperator = filter["z_AreaTerlarangInTanggal"];
                AreaTerlarangInTanggal.AdvancedSearch.SearchCondition = filter["v_AreaTerlarangInTanggal"];
                AreaTerlarangInTanggal.AdvancedSearch.SearchValue2 = filter["y_AreaTerlarangInTanggal"];
                AreaTerlarangInTanggal.AdvancedSearch.SearchOperator2 = filter["w_AreaTerlarangInTanggal"];
                AreaTerlarangInTanggal.AdvancedSearch.Save();
            }

            // Field AreaTerlarangOutTanggal
            if (filter?.TryGetValue("x_AreaTerlarangOutTanggal", out sv) ?? false) {
                AreaTerlarangOutTanggal.AdvancedSearch.SearchValue = sv;
                AreaTerlarangOutTanggal.AdvancedSearch.SearchOperator = filter["z_AreaTerlarangOutTanggal"];
                AreaTerlarangOutTanggal.AdvancedSearch.SearchCondition = filter["v_AreaTerlarangOutTanggal"];
                AreaTerlarangOutTanggal.AdvancedSearch.SearchValue2 = filter["y_AreaTerlarangOutTanggal"];
                AreaTerlarangOutTanggal.AdvancedSearch.SearchOperator2 = filter["w_AreaTerlarangOutTanggal"];
                AreaTerlarangOutTanggal.AdvancedSearch.Save();
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
            BuildSearchSql(ref where, NomorBukuTamu, def, true); // NomorBukuTamu
            BuildSearchSql(ref where, LinkRedirect, def, true); // LinkRedirect
            BuildSearchSql(ref where, Plant, def, true); // Plant
            BuildSearchSql(ref where, Tanggal, def, true); // Tanggal
            BuildSearchSql(ref where, StatusZona, def, true); // StatusZona
            BuildSearchSql(ref where, Nama, def, true); // Nama
            BuildSearchSql(ref where, AsalPerusahaan, def, true); // AsalPerusahaan
            BuildSearchSql(ref where, Jabatan, def, true); // Jabatan
            BuildSearchSql(ref where, FungsiygDikunjungi, def, true); // FungsiygDikunjungi
            BuildSearchSql(ref where, MaksudKunjungan, def, true); // MaksudKunjungan
            BuildSearchSql(ref where, TandaPengenal, def, true); // TandaPengenal
            BuildSearchSql(ref where, TandaTangan, def, true); // TandaTangan
            BuildSearchSql(ref where, Keterangan, def, true); // Keterangan
            BuildSearchSql(ref where, PintuUtamaId, def, true); // PintuUtamaId
            BuildSearchSql(ref where, PintuUtamaInTanggal, def, true); // PintuUtamaInTanggal
            BuildSearchSql(ref where, PintuUtamaInFoto, def, true); // PintuUtamaInFoto
            BuildSearchSql(ref where, PintuUtamaInUser, def, true); // PintuUtamaInUser
            BuildSearchSql(ref where, CustomPilihPintu, def, true); // CustomPilihPintu
            BuildSearchSql(ref where, PintuUtamaOutTanggal, def, true); // PintuUtamaOutTanggal
            BuildSearchSql(ref where, PintuUtamaOutFoto, def, true); // PintuUtamaOutFoto
            BuildSearchSql(ref where, PintuUtamaOutUser, def, true); // PintuUtamaOutUser
            BuildSearchSql(ref where, LobbyUtamaId, def, true); // LobbyUtamaId
            BuildSearchSql(ref where, LobbyUtamaInTanggal, def, true); // LobbyUtamaInTanggal
            BuildSearchSql(ref where, LobbyUtamaInFoto, def, true); // LobbyUtamaInFoto
            BuildSearchSql(ref where, LobbyUtamaInUser, def, true); // LobbyUtamaInUser
            BuildSearchSql(ref where, LobbyUtamaOutTanggal, def, true); // LobbyUtamaOutTanggal
            BuildSearchSql(ref where, LobbyUtamaOutFoto, def, true); // LobbyUtamaOutFoto
            BuildSearchSql(ref where, LobbyUtamaOutUser, def, true); // LobbyUtamaOutUser
            BuildSearchSql(ref where, AreaTerlarangId, def, true); // AreaTerlarangId
            BuildSearchSql(ref where, AreaTerlarangInTanggal, def, true); // AreaTerlarangInTanggal
            BuildSearchSql(ref where, AreaTerlarangInFoto, def, true); // AreaTerlarangInFoto
            BuildSearchSql(ref where, AreaTerlarangInUser, def, true); // AreaTerlarangInUser
            BuildSearchSql(ref where, AreaTerlarangOutTanggal, def, true); // AreaTerlarangOutTanggal
            BuildSearchSql(ref where, AreaTerlarangOutFoto, def, true); // AreaTerlarangOutFoto
            BuildSearchSql(ref where, AreaTerlarangOutUser, def, true); // AreaTerlarangOutUser
            BuildSearchSql(ref where, etlDate, def, true); // etlDate
            BuildSearchSql(ref where, LastUpdatedBy, def, true); // LastUpdatedBy
            BuildSearchSql(ref where, lastUpdatedDate, def, true); // lastUpdatedDate

            // Set up search command
            if (!def && !Empty(where) && (new[] { "", "reset", "resetall" }).Contains(Command))
                Command = "search";
            if (!def && Command == "search") {
                Tanggal.AdvancedSearch.Save(); // Tanggal
                PintuUtamaInTanggal.AdvancedSearch.Save(); // PintuUtamaInTanggal
                PintuUtamaOutTanggal.AdvancedSearch.Save(); // PintuUtamaOutTanggal
                LobbyUtamaInTanggal.AdvancedSearch.Save(); // LobbyUtamaInTanggal
                LobbyUtamaOutTanggal.AdvancedSearch.Save(); // LobbyUtamaOutTanggal
                AreaTerlarangInTanggal.AdvancedSearch.Save(); // AreaTerlarangInTanggal
                AreaTerlarangOutTanggal.AdvancedSearch.Save(); // AreaTerlarangOutTanggal
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
                Tanggal.AdvancedSearch.Save(); // Tanggal
                PintuUtamaInTanggal.AdvancedSearch.Save(); // PintuUtamaInTanggal
                PintuUtamaOutTanggal.AdvancedSearch.Save(); // PintuUtamaOutTanggal
                LobbyUtamaInTanggal.AdvancedSearch.Save(); // LobbyUtamaInTanggal
                LobbyUtamaOutTanggal.AdvancedSearch.Save(); // LobbyUtamaOutTanggal
                AreaTerlarangInTanggal.AdvancedSearch.Save(); // AreaTerlarangInTanggal
                AreaTerlarangOutTanggal.AdvancedSearch.Save(); // AreaTerlarangOutTanggal
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

            // Field LinkRedirect
            filter = QueryBuilderWhere("LinkRedirect");
            if (Empty(filter))
                BuildSearchSql(ref filter, LinkRedirect, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LinkRedirect.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Plant
            filter = QueryBuilderWhere("Plant");
            if (Empty(filter))
                BuildSearchSql(ref filter, Plant, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Plant.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Tanggal
            filter = QueryBuilderWhere("Tanggal");
            if (Empty(filter))
                BuildSearchSql(ref filter, Tanggal, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Tanggal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field StatusZona
            filter = QueryBuilderWhere("StatusZona");
            if (Empty(filter))
                BuildSearchSql(ref filter, StatusZona, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + StatusZona.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Nama
            filter = QueryBuilderWhere("Nama");
            if (Empty(filter))
                BuildSearchSql(ref filter, Nama, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Nama.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field AsalPerusahaan
            filter = QueryBuilderWhere("AsalPerusahaan");
            if (Empty(filter))
                BuildSearchSql(ref filter, AsalPerusahaan, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + AsalPerusahaan.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Jabatan
            filter = QueryBuilderWhere("Jabatan");
            if (Empty(filter))
                BuildSearchSql(ref filter, Jabatan, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Jabatan.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field FungsiygDikunjungi
            filter = QueryBuilderWhere("FungsiygDikunjungi");
            if (Empty(filter))
                BuildSearchSql(ref filter, FungsiygDikunjungi, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + FungsiygDikunjungi.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field MaksudKunjungan
            filter = QueryBuilderWhere("MaksudKunjungan");
            if (Empty(filter))
                BuildSearchSql(ref filter, MaksudKunjungan, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + MaksudKunjungan.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field TandaPengenal
            filter = QueryBuilderWhere("TandaPengenal");
            if (Empty(filter))
                BuildSearchSql(ref filter, TandaPengenal, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + TandaPengenal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Keterangan
            filter = QueryBuilderWhere("Keterangan");
            if (Empty(filter))
                BuildSearchSql(ref filter, Keterangan, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Keterangan.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field PintuUtamaId
            filter = QueryBuilderWhere("PintuUtamaId");
            if (Empty(filter))
                BuildSearchSql(ref filter, PintuUtamaId, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + PintuUtamaId.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field PintuUtamaInTanggal
            filter = QueryBuilderWhere("PintuUtamaInTanggal");
            if (Empty(filter))
                BuildSearchSql(ref filter, PintuUtamaInTanggal, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + PintuUtamaInTanggal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field PintuUtamaInUser
            filter = QueryBuilderWhere("PintuUtamaInUser");
            if (Empty(filter))
                BuildSearchSql(ref filter, PintuUtamaInUser, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + PintuUtamaInUser.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CustomPilihPintu
            filter = QueryBuilderWhere("CustomPilihPintu");
            if (Empty(filter))
                BuildSearchSql(ref filter, CustomPilihPintu, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CustomPilihPintu.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field PintuUtamaOutTanggal
            filter = QueryBuilderWhere("PintuUtamaOutTanggal");
            if (Empty(filter))
                BuildSearchSql(ref filter, PintuUtamaOutTanggal, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + PintuUtamaOutTanggal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field PintuUtamaOutUser
            filter = QueryBuilderWhere("PintuUtamaOutUser");
            if (Empty(filter))
                BuildSearchSql(ref filter, PintuUtamaOutUser, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + PintuUtamaOutUser.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LobbyUtamaId
            filter = QueryBuilderWhere("LobbyUtamaId");
            if (Empty(filter))
                BuildSearchSql(ref filter, LobbyUtamaId, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LobbyUtamaId.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LobbyUtamaInTanggal
            filter = QueryBuilderWhere("LobbyUtamaInTanggal");
            if (Empty(filter))
                BuildSearchSql(ref filter, LobbyUtamaInTanggal, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LobbyUtamaInTanggal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LobbyUtamaInUser
            filter = QueryBuilderWhere("LobbyUtamaInUser");
            if (Empty(filter))
                BuildSearchSql(ref filter, LobbyUtamaInUser, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LobbyUtamaInUser.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LobbyUtamaOutTanggal
            filter = QueryBuilderWhere("LobbyUtamaOutTanggal");
            if (Empty(filter))
                BuildSearchSql(ref filter, LobbyUtamaOutTanggal, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LobbyUtamaOutTanggal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LobbyUtamaOutUser
            filter = QueryBuilderWhere("LobbyUtamaOutUser");
            if (Empty(filter))
                BuildSearchSql(ref filter, LobbyUtamaOutUser, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LobbyUtamaOutUser.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field AreaTerlarangId
            filter = QueryBuilderWhere("AreaTerlarangId");
            if (Empty(filter))
                BuildSearchSql(ref filter, AreaTerlarangId, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + AreaTerlarangId.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field AreaTerlarangInTanggal
            filter = QueryBuilderWhere("AreaTerlarangInTanggal");
            if (Empty(filter))
                BuildSearchSql(ref filter, AreaTerlarangInTanggal, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + AreaTerlarangInTanggal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field AreaTerlarangInUser
            filter = QueryBuilderWhere("AreaTerlarangInUser");
            if (Empty(filter))
                BuildSearchSql(ref filter, AreaTerlarangInUser, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + AreaTerlarangInUser.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field AreaTerlarangOutTanggal
            filter = QueryBuilderWhere("AreaTerlarangOutTanggal");
            if (Empty(filter))
                BuildSearchSql(ref filter, AreaTerlarangOutTanggal, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + AreaTerlarangOutTanggal.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field AreaTerlarangOutUser
            filter = QueryBuilderWhere("AreaTerlarangOutUser");
            if (Empty(filter))
                BuildSearchSql(ref filter, AreaTerlarangOutUser, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + AreaTerlarangOutUser.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field etlDate
            filter = QueryBuilderWhere("etlDate");
            if (Empty(filter))
                BuildSearchSql(ref filter, etlDate, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + etlDate.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LastUpdatedBy
            filter = QueryBuilderWhere("LastUpdatedBy");
            if (Empty(filter))
                BuildSearchSql(ref filter, LastUpdatedBy, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LastUpdatedBy.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field lastUpdatedDate
            filter = QueryBuilderWhere("lastUpdatedDate");
            if (Empty(filter))
                BuildSearchSql(ref filter, lastUpdatedDate, false, true);
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
            searchFlds.Add(NomorBukuTamu);
            searchFlds.Add(LinkRedirect);
            searchFlds.Add(Plant);
            searchFlds.Add(Tanggal);
            searchFlds.Add(StatusZona);
            searchFlds.Add(Nama);
            searchFlds.Add(AsalPerusahaan);
            searchFlds.Add(Jabatan);
            searchFlds.Add(FungsiygDikunjungi);
            searchFlds.Add(MaksudKunjungan);
            searchFlds.Add(TandaPengenal);
            searchFlds.Add(TandaTangan);
            searchFlds.Add(TandaTanganDownload);
            searchFlds.Add(Keterangan);
            searchFlds.Add(PintuUtamaInFoto);
            searchFlds.Add(PintuUtamaInFotoDownload);
            searchFlds.Add(PintuUtamaInUser);
            searchFlds.Add(CustomPilihPintu);
            searchFlds.Add(PintuUtamaOutTanggal);
            searchFlds.Add(PintuUtamaOutFoto);
            searchFlds.Add(PintuUtamaOutFotoDownload);
            searchFlds.Add(PintuUtamaOutUser);
            searchFlds.Add(LobbyUtamaId);
            searchFlds.Add(LobbyUtamaInTanggal);
            searchFlds.Add(LobbyUtamaInFoto);
            searchFlds.Add(LobbyUtamaInFotoDownload);
            searchFlds.Add(LobbyUtamaInUser);
            searchFlds.Add(LobbyUtamaOutTanggal);
            searchFlds.Add(LobbyUtamaOutFoto);
            searchFlds.Add(LobbyUtamaOutFotoDownload);
            searchFlds.Add(LobbyUtamaOutUser);
            searchFlds.Add(AreaTerlarangId);
            searchFlds.Add(AreaTerlarangInTanggal);
            searchFlds.Add(AreaTerlarangInFoto);
            searchFlds.Add(AreaTerlarangInFotoDownload);
            searchFlds.Add(AreaTerlarangInUser);
            searchFlds.Add(AreaTerlarangOutTanggal);
            searchFlds.Add(AreaTerlarangOutFoto);
            searchFlds.Add(AreaTerlarangOutFotoDownload);
            searchFlds.Add(AreaTerlarangOutUser);
            searchFlds.Add(etlDate);
            searchFlds.Add(LastUpdatedBy);
            searchFlds.Add(lastUpdatedDate);
            searchFlds.Add(StatusZonaPrev);
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
            if (NomorBukuTamu.AdvancedSearch.IssetSession)
                return true;
            if (LinkRedirect.AdvancedSearch.IssetSession)
                return true;
            if (Plant.AdvancedSearch.IssetSession)
                return true;
            if (Tanggal.AdvancedSearch.IssetSession)
                return true;
            if (StatusZona.AdvancedSearch.IssetSession)
                return true;
            if (Nama.AdvancedSearch.IssetSession)
                return true;
            if (AsalPerusahaan.AdvancedSearch.IssetSession)
                return true;
            if (Jabatan.AdvancedSearch.IssetSession)
                return true;
            if (FungsiygDikunjungi.AdvancedSearch.IssetSession)
                return true;
            if (MaksudKunjungan.AdvancedSearch.IssetSession)
                return true;
            if (TandaPengenal.AdvancedSearch.IssetSession)
                return true;
            if (TandaTangan.AdvancedSearch.IssetSession)
                return true;
            if (Keterangan.AdvancedSearch.IssetSession)
                return true;
            if (PintuUtamaId.AdvancedSearch.IssetSession)
                return true;
            if (PintuUtamaInTanggal.AdvancedSearch.IssetSession)
                return true;
            if (PintuUtamaInFoto.AdvancedSearch.IssetSession)
                return true;
            if (PintuUtamaInUser.AdvancedSearch.IssetSession)
                return true;
            if (CustomPilihPintu.AdvancedSearch.IssetSession)
                return true;
            if (PintuUtamaOutTanggal.AdvancedSearch.IssetSession)
                return true;
            if (PintuUtamaOutFoto.AdvancedSearch.IssetSession)
                return true;
            if (PintuUtamaOutUser.AdvancedSearch.IssetSession)
                return true;
            if (LobbyUtamaId.AdvancedSearch.IssetSession)
                return true;
            if (LobbyUtamaInTanggal.AdvancedSearch.IssetSession)
                return true;
            if (LobbyUtamaInFoto.AdvancedSearch.IssetSession)
                return true;
            if (LobbyUtamaInUser.AdvancedSearch.IssetSession)
                return true;
            if (LobbyUtamaOutTanggal.AdvancedSearch.IssetSession)
                return true;
            if (LobbyUtamaOutFoto.AdvancedSearch.IssetSession)
                return true;
            if (LobbyUtamaOutUser.AdvancedSearch.IssetSession)
                return true;
            if (AreaTerlarangId.AdvancedSearch.IssetSession)
                return true;
            if (AreaTerlarangInTanggal.AdvancedSearch.IssetSession)
                return true;
            if (AreaTerlarangInFoto.AdvancedSearch.IssetSession)
                return true;
            if (AreaTerlarangInUser.AdvancedSearch.IssetSession)
                return true;
            if (AreaTerlarangOutTanggal.AdvancedSearch.IssetSession)
                return true;
            if (AreaTerlarangOutFoto.AdvancedSearch.IssetSession)
                return true;
            if (AreaTerlarangOutUser.AdvancedSearch.IssetSession)
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
            NomorBukuTamu.AdvancedSearch.UnsetSession();
            LinkRedirect.AdvancedSearch.UnsetSession();
            Plant.AdvancedSearch.UnsetSession();
            Tanggal.AdvancedSearch.UnsetSession();
            StatusZona.AdvancedSearch.UnsetSession();
            Nama.AdvancedSearch.UnsetSession();
            AsalPerusahaan.AdvancedSearch.UnsetSession();
            Jabatan.AdvancedSearch.UnsetSession();
            FungsiygDikunjungi.AdvancedSearch.UnsetSession();
            MaksudKunjungan.AdvancedSearch.UnsetSession();
            TandaPengenal.AdvancedSearch.UnsetSession();
            TandaTangan.AdvancedSearch.UnsetSession();
            Keterangan.AdvancedSearch.UnsetSession();
            PintuUtamaId.AdvancedSearch.UnsetSession();
            PintuUtamaInTanggal.AdvancedSearch.UnsetSession();
            PintuUtamaInFoto.AdvancedSearch.UnsetSession();
            PintuUtamaInUser.AdvancedSearch.UnsetSession();
            CustomPilihPintu.AdvancedSearch.UnsetSession();
            PintuUtamaOutTanggal.AdvancedSearch.UnsetSession();
            PintuUtamaOutFoto.AdvancedSearch.UnsetSession();
            PintuUtamaOutUser.AdvancedSearch.UnsetSession();
            LobbyUtamaId.AdvancedSearch.UnsetSession();
            LobbyUtamaInTanggal.AdvancedSearch.UnsetSession();
            LobbyUtamaInFoto.AdvancedSearch.UnsetSession();
            LobbyUtamaInUser.AdvancedSearch.UnsetSession();
            LobbyUtamaOutTanggal.AdvancedSearch.UnsetSession();
            LobbyUtamaOutFoto.AdvancedSearch.UnsetSession();
            LobbyUtamaOutUser.AdvancedSearch.UnsetSession();
            AreaTerlarangId.AdvancedSearch.UnsetSession();
            AreaTerlarangInTanggal.AdvancedSearch.UnsetSession();
            AreaTerlarangInFoto.AdvancedSearch.UnsetSession();
            AreaTerlarangInUser.AdvancedSearch.UnsetSession();
            AreaTerlarangOutTanggal.AdvancedSearch.UnsetSession();
            AreaTerlarangOutFoto.AdvancedSearch.UnsetSession();
            AreaTerlarangOutUser.AdvancedSearch.UnsetSession();
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
            NomorBukuTamu.AdvancedSearch.Load();
            LinkRedirect.AdvancedSearch.Load();
            Plant.AdvancedSearch.Load();
            Tanggal.AdvancedSearch.Load();
            StatusZona.AdvancedSearch.Load();
            Nama.AdvancedSearch.Load();
            AsalPerusahaan.AdvancedSearch.Load();
            Jabatan.AdvancedSearch.Load();
            FungsiygDikunjungi.AdvancedSearch.Load();
            MaksudKunjungan.AdvancedSearch.Load();
            TandaPengenal.AdvancedSearch.Load();
            TandaTangan.AdvancedSearch.Load();
            Keterangan.AdvancedSearch.Load();
            PintuUtamaId.AdvancedSearch.Load();
            PintuUtamaInTanggal.AdvancedSearch.Load();
            PintuUtamaInFoto.AdvancedSearch.Load();
            PintuUtamaInUser.AdvancedSearch.Load();
            CustomPilihPintu.AdvancedSearch.Load();
            PintuUtamaOutTanggal.AdvancedSearch.Load();
            PintuUtamaOutFoto.AdvancedSearch.Load();
            PintuUtamaOutUser.AdvancedSearch.Load();
            LobbyUtamaId.AdvancedSearch.Load();
            LobbyUtamaInTanggal.AdvancedSearch.Load();
            LobbyUtamaInFoto.AdvancedSearch.Load();
            LobbyUtamaInUser.AdvancedSearch.Load();
            LobbyUtamaOutTanggal.AdvancedSearch.Load();
            LobbyUtamaOutFoto.AdvancedSearch.Load();
            LobbyUtamaOutUser.AdvancedSearch.Load();
            AreaTerlarangId.AdvancedSearch.Load();
            AreaTerlarangInTanggal.AdvancedSearch.Load();
            AreaTerlarangInFoto.AdvancedSearch.Load();
            AreaTerlarangInUser.AdvancedSearch.Load();
            AreaTerlarangOutTanggal.AdvancedSearch.Load();
            AreaTerlarangOutFoto.AdvancedSearch.Load();
            AreaTerlarangOutUser.AdvancedSearch.Load();
            etlDate.AdvancedSearch.Load();
            LastUpdatedBy.AdvancedSearch.Load();
            lastUpdatedDate.AdvancedSearch.Load();
        }

        // Set up sort parameters
        protected void SetupSortOrder() {
            // Load default Sorting Order
            if (Command != "json") {
                string defaultSort = etlDate.Expression + " DESC"; // Set up default sort
                if (Empty(SessionOrderBy) && !Empty(defaultSort))
                    SessionOrderBy = defaultSort;
            }

            // Check for Ctrl pressed
            bool ctrl = Get<bool>("ctrl");

            // Check for "order" parameter
            if (Get("order", out StringValues sv)) {
                CurrentOrder = sv.ToString();
                CurrentOrderType = Get("ordertype");
                UpdateSort(LinkRedirect, ctrl); // LinkRedirect
                UpdateSort(Plant, ctrl); // Plant
                UpdateSort(Tanggal, ctrl); // Tanggal
                UpdateSort(StatusZona, ctrl); // StatusZona
                UpdateSort(Nama, ctrl); // Nama
                UpdateSort(AsalPerusahaan, ctrl); // AsalPerusahaan
                UpdateSort(Jabatan, ctrl); // Jabatan
                UpdateSort(FungsiygDikunjungi, ctrl); // FungsiygDikunjungi
                UpdateSort(MaksudKunjungan, ctrl); // MaksudKunjungan
                UpdateSort(TandaPengenal, ctrl); // TandaPengenal
                UpdateSort(TandaTanganDownload, ctrl); // TandaTanganDownload
                UpdateSort(Keterangan, ctrl); // Keterangan
                UpdateSort(PintuUtamaId, ctrl); // PintuUtamaId
                UpdateSort(PintuUtamaInTanggal, ctrl); // PintuUtamaInTanggal
                UpdateSort(PintuUtamaInFotoDownload, ctrl); // PintuUtamaInFotoDownload
                UpdateSort(PintuUtamaInUser, ctrl); // PintuUtamaInUser
                UpdateSort(CustomPilihPintu, ctrl); // CustomPilihPintu
                UpdateSort(PintuUtamaOutTanggal, ctrl); // PintuUtamaOutTanggal
                UpdateSort(PintuUtamaOutFotoDownload, ctrl); // PintuUtamaOutFotoDownload
                UpdateSort(PintuUtamaOutUser, ctrl); // PintuUtamaOutUser
                UpdateSort(LobbyUtamaId, ctrl); // LobbyUtamaId
                UpdateSort(LobbyUtamaInTanggal, ctrl); // LobbyUtamaInTanggal
                UpdateSort(LobbyUtamaInFotoDownload, ctrl); // LobbyUtamaInFotoDownload
                UpdateSort(LobbyUtamaInUser, ctrl); // LobbyUtamaInUser
                UpdateSort(LobbyUtamaOutTanggal, ctrl); // LobbyUtamaOutTanggal
                UpdateSort(LobbyUtamaOutFotoDownload, ctrl); // LobbyUtamaOutFotoDownload
                UpdateSort(LobbyUtamaOutUser, ctrl); // LobbyUtamaOutUser
                UpdateSort(AreaTerlarangId, ctrl); // AreaTerlarangId
                UpdateSort(AreaTerlarangInTanggal, ctrl); // AreaTerlarangInTanggal
                UpdateSort(AreaTerlarangInFotoDownload, ctrl); // AreaTerlarangInFotoDownload
                UpdateSort(AreaTerlarangInUser, ctrl); // AreaTerlarangInUser
                UpdateSort(AreaTerlarangOutTanggal, ctrl); // AreaTerlarangOutTanggal
                UpdateSort(AreaTerlarangOutFotoDownload, ctrl); // AreaTerlarangOutFotoDownload
                UpdateSort(AreaTerlarangOutUser, ctrl); // AreaTerlarangOutUser
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
                    NomorBukuTamu.Sort = "";
                    LinkRedirect.Sort = "";
                    LookupPlant.Sort = "";
                    Plant.Sort = "";
                    Tanggal.Sort = "";
                    StatusZona.Sort = "";
                    Nama.Sort = "";
                    AsalPerusahaan.Sort = "";
                    Jabatan.Sort = "";
                    FungsiygDikunjungi.Sort = "";
                    MaksudKunjungan.Sort = "";
                    TandaPengenal.Sort = "";
                    TandaTangan.Sort = "";
                    TandaTanganDownload.Sort = "";
                    Keterangan.Sort = "";
                    PintuUtamaId.Sort = "";
                    PintuUtamaInTanggal.Sort = "";
                    PintuUtamaInFoto.Sort = "";
                    PintuUtamaInFotoDownload.Sort = "";
                    PintuUtamaInUser.Sort = "";
                    CustomPilihPintu.Sort = "";
                    PintuUtamaOutTanggal.Sort = "";
                    PintuUtamaOutFoto.Sort = "";
                    PintuUtamaOutFotoDownload.Sort = "";
                    PintuUtamaOutUser.Sort = "";
                    LobbyUtamaId.Sort = "";
                    LobbyUtamaInTanggal.Sort = "";
                    LobbyUtamaInFoto.Sort = "";
                    LobbyUtamaInFotoDownload.Sort = "";
                    LobbyUtamaInUser.Sort = "";
                    LobbyUtamaOutTanggal.Sort = "";
                    LobbyUtamaOutFoto.Sort = "";
                    LobbyUtamaOutFotoDownload.Sort = "";
                    LobbyUtamaOutUser.Sort = "";
                    AreaTerlarangId.Sort = "";
                    AreaTerlarangInTanggal.Sort = "";
                    AreaTerlarangInFoto.Sort = "";
                    AreaTerlarangInFotoDownload.Sort = "";
                    AreaTerlarangInUser.Sort = "";
                    AreaTerlarangOutTanggal.Sort = "";
                    AreaTerlarangOutFoto.Sort = "";
                    AreaTerlarangOutFotoDownload.Sort = "";
                    AreaTerlarangOutUser.Sort = "";
                    etlDate.Sort = "";
                    LastUpdatedBy.Sort = "";
                    lastUpdatedDate.Sort = "";
                    StatusZonaPrev.Sort = "";
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-table=""BukuTamu"" data-caption=""{viewcaption}"" data-ew-action=""modal"" data-action=""view"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(ViewUrl)) + "\" data-btn=\"null\">" + Language.Phrase("ViewLink") + "</a>");
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-table=""BukuTamu"" data-caption=""{editcaption}"" data-ew-action=""modal"" data-action=""edit"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\" data-btn=\"SaveBtn\">" + Language.Phrase("EditLink") + "</a>");
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-copy"" title=""{copycaption}"" data-table=""BukuTamu"" data-caption=""{copycaption}"" data-ew-action=""modal"" data-action=""add"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(CopyUrl)) + "\" data-btn=\"AddBtn\">" + Language.Phrase("CopyLink") + "</a>");
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
                                : "<li><button type=\"button\" class=\"dropdown-item ew-action ew-list-action\" data-caption=\"" + title + "\" data-ew-action=\"submit\" form=\"fBukuTamulist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttributes() + ">" + icon + " " + caption + "</button></li>";
                            if (!Empty(link)) {
                                links.Add(link);
                                if (Empty(body)) // Setup first button
                                    body = disabled
                                    ? "<div class=\"alert alert-light\">" + icon + " " + caption + "</div>"
                                    : "<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlTitle(caption) + "\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fBukuTamulist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttributes() + ">" + icon + caption + "</button>";
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
                item.Body = $@"<a class=""ew-add-edit ew-add"" title=""{addTitle}"" data-table=""BukuTamu"" data-caption=""{addTitle}"" data-ew-action=""modal"" data-action=""add"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(AddUrl)) + "\" data-btn=\"AddBtn\">" + Language.Phrase("AddLink") + "</a>";
            else
                item.Body = $@"<a class=""ew-add-edit ew-add"" title=""{addTitle}"" data-caption=""{addTitle}"" href=""" + HtmlEncode(AppPath(AddUrl)) + "\">" + Language.Phrase("AddLink") + "</a>";
            item.Visible = AddUrl != "" && Security.CanAdd;
            option = options["action"];

            // Add multi delete
            item = option.Add("multidelete");
            string deleteTitle = Language.Phrase("DeleteSelectedLink", true);
            item.Body = $@"<button type=""button"" class=""ew-action ew-multi-delete"" title=""{deleteTitle}"" data-caption=""{deleteTitle}"" form=""fBukuTamulist""" +
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
                CreateColumnOption(option.Add("LinkRedirect")); // DN
                CreateColumnOption(option.Add("Plant")); // DN
                CreateColumnOption(option.Add("Tanggal")); // DN
                CreateColumnOption(option.Add("StatusZona")); // DN
                CreateColumnOption(option.Add("Nama")); // DN
                CreateColumnOption(option.Add("AsalPerusahaan")); // DN
                CreateColumnOption(option.Add("Jabatan")); // DN
                CreateColumnOption(option.Add("FungsiygDikunjungi")); // DN
                CreateColumnOption(option.Add("MaksudKunjungan")); // DN
                CreateColumnOption(option.Add("TandaPengenal")); // DN
                CreateColumnOption(option.Add("TandaTanganDownload")); // DN
                CreateColumnOption(option.Add("Keterangan")); // DN
                CreateColumnOption(option.Add("PintuUtamaId")); // DN
                CreateColumnOption(option.Add("PintuUtamaInTanggal")); // DN
                CreateColumnOption(option.Add("PintuUtamaInFotoDownload")); // DN
                CreateColumnOption(option.Add("PintuUtamaInUser")); // DN
                CreateColumnOption(option.Add("CustomPilihPintu")); // DN
                CreateColumnOption(option.Add("PintuUtamaOutTanggal")); // DN
                CreateColumnOption(option.Add("PintuUtamaOutFotoDownload")); // DN
                CreateColumnOption(option.Add("PintuUtamaOutUser")); // DN
                CreateColumnOption(option.Add("LobbyUtamaId")); // DN
                CreateColumnOption(option.Add("LobbyUtamaInTanggal")); // DN
                CreateColumnOption(option.Add("LobbyUtamaInFotoDownload")); // DN
                CreateColumnOption(option.Add("LobbyUtamaInUser")); // DN
                CreateColumnOption(option.Add("LobbyUtamaOutTanggal")); // DN
                CreateColumnOption(option.Add("LobbyUtamaOutFotoDownload")); // DN
                CreateColumnOption(option.Add("LobbyUtamaOutUser")); // DN
                CreateColumnOption(option.Add("AreaTerlarangId")); // DN
                CreateColumnOption(option.Add("AreaTerlarangInTanggal")); // DN
                CreateColumnOption(option.Add("AreaTerlarangInFotoDownload")); // DN
                CreateColumnOption(option.Add("AreaTerlarangInUser")); // DN
                CreateColumnOption(option.Add("AreaTerlarangOutTanggal")); // DN
                CreateColumnOption(option.Add("AreaTerlarangOutFotoDownload")); // DN
                CreateColumnOption(option.Add("AreaTerlarangOutUser")); // DN
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
            item.Body = "<a class=\"ew-save-filter\" data-form=\"fBukuTamusrch\" data-ew-action=\"none\">" + Language.Phrase("SaveCurrentFilter") + "</a>";
            item.Visible = true;
            item = FilterOptions.Add("deletefilter");
            item.Body = "<a class=\"ew-delete-filter\" data-form=\"fBukuTamusrch\" data-ew-action=\"none\">" + Language.Phrase("DeleteFilter") + "</a>";
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
                    item.Body = "<<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlEncode(caption) + "\" data-caption=\"" + HtmlEncode(caption) + "\" data-ew-action=\"submit\" form=\"fBukuTamulist\"" + act.ToDataAttributes() + ">" + icon + "</button>";
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
                    RowAttrs.Add("id", "r0_BukuTamu");
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
            RowAttrs.Add("data-rowindex", ConvertToString(bukuTamuList.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(bukuTamuList.RowCount) + "_BukuTamu");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(bukuTamuList.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && bukuTamuList.RowType == RowType.Add || IsEdit && bukuTamuList.RowType == RowType.Edit) // Inline-Add/Edit row
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

            // NomorBukuTamu
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_NomorBukuTamu[]"))
                    NomorBukuTamu.AdvancedSearch.SearchValue = Get("x_NomorBukuTamu[]", Config.FilterOptionSeparator);
                else
                    NomorBukuTamu.AdvancedSearch.SearchValue = Get("NomorBukuTamu"); // Default Value // DN
            if (!Empty(NomorBukuTamu.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_NomorBukuTamu"))
                NomorBukuTamu.AdvancedSearch.SearchOperator = Get("z_NomorBukuTamu", Config.FilterOptionSeparator);

            // LinkRedirect
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LinkRedirect[]"))
                    LinkRedirect.AdvancedSearch.SearchValue = Get("x_LinkRedirect[]", Config.FilterOptionSeparator);
                else
                    LinkRedirect.AdvancedSearch.SearchValue = Get("LinkRedirect"); // Default Value // DN
            if (!Empty(LinkRedirect.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LinkRedirect"))
                LinkRedirect.AdvancedSearch.SearchOperator = Get("z_LinkRedirect", Config.FilterOptionSeparator);

            // Plant
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Plant[]"))
                    Plant.AdvancedSearch.SearchValue = Get("x_Plant[]", Config.FilterOptionSeparator);
                else
                    Plant.AdvancedSearch.SearchValue = Get("Plant"); // Default Value // DN
            if (!Empty(Plant.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Plant"))
                Plant.AdvancedSearch.SearchOperator = Get("z_Plant", Config.FilterOptionSeparator);

            // Tanggal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Tanggal[]"))
                    Tanggal.AdvancedSearch.SearchValue = Get("x_Tanggal[]", Config.FilterOptionSeparator);
                else
                    Tanggal.AdvancedSearch.SearchValue = Get("Tanggal"); // Default Value // DN
            if (!Empty(Tanggal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Tanggal"))
                Tanggal.AdvancedSearch.SearchOperator = Get("z_Tanggal", Config.FilterOptionSeparator);

            // StatusZona
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_StatusZona[]"))
                    StatusZona.AdvancedSearch.SearchValue = Get("x_StatusZona[]", Config.FilterOptionSeparator);
                else
                    StatusZona.AdvancedSearch.SearchValue = Get("StatusZona"); // Default Value // DN
            if (!Empty(StatusZona.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_StatusZona"))
                StatusZona.AdvancedSearch.SearchOperator = Get("z_StatusZona", Config.FilterOptionSeparator);

            // Nama
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Nama[]"))
                    Nama.AdvancedSearch.SearchValue = Get("x_Nama[]", Config.FilterOptionSeparator);
                else
                    Nama.AdvancedSearch.SearchValue = Get("Nama"); // Default Value // DN
            if (!Empty(Nama.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Nama"))
                Nama.AdvancedSearch.SearchOperator = Get("z_Nama", Config.FilterOptionSeparator);

            // AsalPerusahaan
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AsalPerusahaan[]"))
                    AsalPerusahaan.AdvancedSearch.SearchValue = Get("x_AsalPerusahaan[]", Config.FilterOptionSeparator);
                else
                    AsalPerusahaan.AdvancedSearch.SearchValue = Get("AsalPerusahaan"); // Default Value // DN
            if (!Empty(AsalPerusahaan.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AsalPerusahaan"))
                AsalPerusahaan.AdvancedSearch.SearchOperator = Get("z_AsalPerusahaan", Config.FilterOptionSeparator);

            // Jabatan
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Jabatan[]"))
                    Jabatan.AdvancedSearch.SearchValue = Get("x_Jabatan[]", Config.FilterOptionSeparator);
                else
                    Jabatan.AdvancedSearch.SearchValue = Get("Jabatan"); // Default Value // DN
            if (!Empty(Jabatan.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Jabatan"))
                Jabatan.AdvancedSearch.SearchOperator = Get("z_Jabatan", Config.FilterOptionSeparator);

            // FungsiygDikunjungi
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_FungsiygDikunjungi[]"))
                    FungsiygDikunjungi.AdvancedSearch.SearchValue = Get("x_FungsiygDikunjungi[]", Config.FilterOptionSeparator);
                else
                    FungsiygDikunjungi.AdvancedSearch.SearchValue = Get("FungsiygDikunjungi"); // Default Value // DN
            if (!Empty(FungsiygDikunjungi.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_FungsiygDikunjungi"))
                FungsiygDikunjungi.AdvancedSearch.SearchOperator = Get("z_FungsiygDikunjungi", Config.FilterOptionSeparator);

            // MaksudKunjungan
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_MaksudKunjungan[]"))
                    MaksudKunjungan.AdvancedSearch.SearchValue = Get("x_MaksudKunjungan[]", Config.FilterOptionSeparator);
                else
                    MaksudKunjungan.AdvancedSearch.SearchValue = Get("MaksudKunjungan"); // Default Value // DN
            if (!Empty(MaksudKunjungan.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_MaksudKunjungan"))
                MaksudKunjungan.AdvancedSearch.SearchOperator = Get("z_MaksudKunjungan", Config.FilterOptionSeparator);

            // TandaPengenal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_TandaPengenal[]"))
                    TandaPengenal.AdvancedSearch.SearchValue = Get("x_TandaPengenal[]", Config.FilterOptionSeparator);
                else
                    TandaPengenal.AdvancedSearch.SearchValue = Get("TandaPengenal"); // Default Value // DN
            if (!Empty(TandaPengenal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_TandaPengenal"))
                TandaPengenal.AdvancedSearch.SearchOperator = Get("z_TandaPengenal", Config.FilterOptionSeparator);

            // TandaTangan
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_TandaTangan[]"))
                    TandaTangan.AdvancedSearch.SearchValue = Get("x_TandaTangan[]", Config.FilterOptionSeparator);
                else
                    TandaTangan.AdvancedSearch.SearchValue = Get("TandaTangan"); // Default Value // DN
            if (!Empty(TandaTangan.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_TandaTangan"))
                TandaTangan.AdvancedSearch.SearchOperator = Get("z_TandaTangan", Config.FilterOptionSeparator);

            // Keterangan
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Keterangan[]"))
                    Keterangan.AdvancedSearch.SearchValue = Get("x_Keterangan[]", Config.FilterOptionSeparator);
                else
                    Keterangan.AdvancedSearch.SearchValue = Get("Keterangan"); // Default Value // DN
            if (!Empty(Keterangan.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Keterangan"))
                Keterangan.AdvancedSearch.SearchOperator = Get("z_Keterangan", Config.FilterOptionSeparator);

            // PintuUtamaId
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PintuUtamaId[]"))
                    PintuUtamaId.AdvancedSearch.SearchValue = Get("x_PintuUtamaId[]", Config.FilterOptionSeparator);
                else
                    PintuUtamaId.AdvancedSearch.SearchValue = Get("PintuUtamaId"); // Default Value // DN
            if (!Empty(PintuUtamaId.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PintuUtamaId"))
                PintuUtamaId.AdvancedSearch.SearchOperator = Get("z_PintuUtamaId", Config.FilterOptionSeparator);

            // PintuUtamaInTanggal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PintuUtamaInTanggal[]"))
                    PintuUtamaInTanggal.AdvancedSearch.SearchValue = Get("x_PintuUtamaInTanggal[]", Config.FilterOptionSeparator);
                else
                    PintuUtamaInTanggal.AdvancedSearch.SearchValue = Get("PintuUtamaInTanggal"); // Default Value // DN
            if (!Empty(PintuUtamaInTanggal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PintuUtamaInTanggal"))
                PintuUtamaInTanggal.AdvancedSearch.SearchOperator = Get("z_PintuUtamaInTanggal", Config.FilterOptionSeparator);

            // PintuUtamaInFoto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PintuUtamaInFoto[]"))
                    PintuUtamaInFoto.AdvancedSearch.SearchValue = Get("x_PintuUtamaInFoto[]", Config.FilterOptionSeparator);
                else
                    PintuUtamaInFoto.AdvancedSearch.SearchValue = Get("PintuUtamaInFoto"); // Default Value // DN
            if (!Empty(PintuUtamaInFoto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PintuUtamaInFoto"))
                PintuUtamaInFoto.AdvancedSearch.SearchOperator = Get("z_PintuUtamaInFoto", Config.FilterOptionSeparator);

            // PintuUtamaInUser
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PintuUtamaInUser[]"))
                    PintuUtamaInUser.AdvancedSearch.SearchValue = Get("x_PintuUtamaInUser[]", Config.FilterOptionSeparator);
                else
                    PintuUtamaInUser.AdvancedSearch.SearchValue = Get("PintuUtamaInUser"); // Default Value // DN
            if (!Empty(PintuUtamaInUser.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PintuUtamaInUser"))
                PintuUtamaInUser.AdvancedSearch.SearchOperator = Get("z_PintuUtamaInUser", Config.FilterOptionSeparator);

            // CustomPilihPintu
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CustomPilihPintu[]"))
                    CustomPilihPintu.AdvancedSearch.SearchValue = Get("x_CustomPilihPintu[]", Config.FilterOptionSeparator);
                else
                    CustomPilihPintu.AdvancedSearch.SearchValue = Get("CustomPilihPintu"); // Default Value // DN
            if (!Empty(CustomPilihPintu.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CustomPilihPintu"))
                CustomPilihPintu.AdvancedSearch.SearchOperator = Get("z_CustomPilihPintu", Config.FilterOptionSeparator);

            // PintuUtamaOutTanggal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PintuUtamaOutTanggal[]"))
                    PintuUtamaOutTanggal.AdvancedSearch.SearchValue = Get("x_PintuUtamaOutTanggal[]", Config.FilterOptionSeparator);
                else
                    PintuUtamaOutTanggal.AdvancedSearch.SearchValue = Get("PintuUtamaOutTanggal"); // Default Value // DN
            if (!Empty(PintuUtamaOutTanggal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PintuUtamaOutTanggal"))
                PintuUtamaOutTanggal.AdvancedSearch.SearchOperator = Get("z_PintuUtamaOutTanggal", Config.FilterOptionSeparator);

            // PintuUtamaOutFoto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PintuUtamaOutFoto[]"))
                    PintuUtamaOutFoto.AdvancedSearch.SearchValue = Get("x_PintuUtamaOutFoto[]", Config.FilterOptionSeparator);
                else
                    PintuUtamaOutFoto.AdvancedSearch.SearchValue = Get("PintuUtamaOutFoto"); // Default Value // DN
            if (!Empty(PintuUtamaOutFoto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PintuUtamaOutFoto"))
                PintuUtamaOutFoto.AdvancedSearch.SearchOperator = Get("z_PintuUtamaOutFoto", Config.FilterOptionSeparator);

            // PintuUtamaOutUser
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PintuUtamaOutUser[]"))
                    PintuUtamaOutUser.AdvancedSearch.SearchValue = Get("x_PintuUtamaOutUser[]", Config.FilterOptionSeparator);
                else
                    PintuUtamaOutUser.AdvancedSearch.SearchValue = Get("PintuUtamaOutUser"); // Default Value // DN
            if (!Empty(PintuUtamaOutUser.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PintuUtamaOutUser"))
                PintuUtamaOutUser.AdvancedSearch.SearchOperator = Get("z_PintuUtamaOutUser", Config.FilterOptionSeparator);

            // LobbyUtamaId
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LobbyUtamaId[]"))
                    LobbyUtamaId.AdvancedSearch.SearchValue = Get("x_LobbyUtamaId[]", Config.FilterOptionSeparator);
                else
                    LobbyUtamaId.AdvancedSearch.SearchValue = Get("LobbyUtamaId"); // Default Value // DN
            if (!Empty(LobbyUtamaId.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LobbyUtamaId"))
                LobbyUtamaId.AdvancedSearch.SearchOperator = Get("z_LobbyUtamaId", Config.FilterOptionSeparator);

            // LobbyUtamaInTanggal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LobbyUtamaInTanggal[]"))
                    LobbyUtamaInTanggal.AdvancedSearch.SearchValue = Get("x_LobbyUtamaInTanggal[]", Config.FilterOptionSeparator);
                else
                    LobbyUtamaInTanggal.AdvancedSearch.SearchValue = Get("LobbyUtamaInTanggal"); // Default Value // DN
            if (!Empty(LobbyUtamaInTanggal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LobbyUtamaInTanggal"))
                LobbyUtamaInTanggal.AdvancedSearch.SearchOperator = Get("z_LobbyUtamaInTanggal", Config.FilterOptionSeparator);

            // LobbyUtamaInFoto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LobbyUtamaInFoto[]"))
                    LobbyUtamaInFoto.AdvancedSearch.SearchValue = Get("x_LobbyUtamaInFoto[]", Config.FilterOptionSeparator);
                else
                    LobbyUtamaInFoto.AdvancedSearch.SearchValue = Get("LobbyUtamaInFoto"); // Default Value // DN
            if (!Empty(LobbyUtamaInFoto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LobbyUtamaInFoto"))
                LobbyUtamaInFoto.AdvancedSearch.SearchOperator = Get("z_LobbyUtamaInFoto", Config.FilterOptionSeparator);

            // LobbyUtamaInUser
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LobbyUtamaInUser[]"))
                    LobbyUtamaInUser.AdvancedSearch.SearchValue = Get("x_LobbyUtamaInUser[]", Config.FilterOptionSeparator);
                else
                    LobbyUtamaInUser.AdvancedSearch.SearchValue = Get("LobbyUtamaInUser"); // Default Value // DN
            if (!Empty(LobbyUtamaInUser.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LobbyUtamaInUser"))
                LobbyUtamaInUser.AdvancedSearch.SearchOperator = Get("z_LobbyUtamaInUser", Config.FilterOptionSeparator);

            // LobbyUtamaOutTanggal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LobbyUtamaOutTanggal[]"))
                    LobbyUtamaOutTanggal.AdvancedSearch.SearchValue = Get("x_LobbyUtamaOutTanggal[]", Config.FilterOptionSeparator);
                else
                    LobbyUtamaOutTanggal.AdvancedSearch.SearchValue = Get("LobbyUtamaOutTanggal"); // Default Value // DN
            if (!Empty(LobbyUtamaOutTanggal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LobbyUtamaOutTanggal"))
                LobbyUtamaOutTanggal.AdvancedSearch.SearchOperator = Get("z_LobbyUtamaOutTanggal", Config.FilterOptionSeparator);

            // LobbyUtamaOutFoto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LobbyUtamaOutFoto[]"))
                    LobbyUtamaOutFoto.AdvancedSearch.SearchValue = Get("x_LobbyUtamaOutFoto[]", Config.FilterOptionSeparator);
                else
                    LobbyUtamaOutFoto.AdvancedSearch.SearchValue = Get("LobbyUtamaOutFoto"); // Default Value // DN
            if (!Empty(LobbyUtamaOutFoto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LobbyUtamaOutFoto"))
                LobbyUtamaOutFoto.AdvancedSearch.SearchOperator = Get("z_LobbyUtamaOutFoto", Config.FilterOptionSeparator);

            // LobbyUtamaOutUser
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LobbyUtamaOutUser[]"))
                    LobbyUtamaOutUser.AdvancedSearch.SearchValue = Get("x_LobbyUtamaOutUser[]", Config.FilterOptionSeparator);
                else
                    LobbyUtamaOutUser.AdvancedSearch.SearchValue = Get("LobbyUtamaOutUser"); // Default Value // DN
            if (!Empty(LobbyUtamaOutUser.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LobbyUtamaOutUser"))
                LobbyUtamaOutUser.AdvancedSearch.SearchOperator = Get("z_LobbyUtamaOutUser", Config.FilterOptionSeparator);

            // AreaTerlarangId
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AreaTerlarangId[]"))
                    AreaTerlarangId.AdvancedSearch.SearchValue = Get("x_AreaTerlarangId[]", Config.FilterOptionSeparator);
                else
                    AreaTerlarangId.AdvancedSearch.SearchValue = Get("AreaTerlarangId"); // Default Value // DN
            if (!Empty(AreaTerlarangId.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AreaTerlarangId"))
                AreaTerlarangId.AdvancedSearch.SearchOperator = Get("z_AreaTerlarangId", Config.FilterOptionSeparator);

            // AreaTerlarangInTanggal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AreaTerlarangInTanggal[]"))
                    AreaTerlarangInTanggal.AdvancedSearch.SearchValue = Get("x_AreaTerlarangInTanggal[]", Config.FilterOptionSeparator);
                else
                    AreaTerlarangInTanggal.AdvancedSearch.SearchValue = Get("AreaTerlarangInTanggal"); // Default Value // DN
            if (!Empty(AreaTerlarangInTanggal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AreaTerlarangInTanggal"))
                AreaTerlarangInTanggal.AdvancedSearch.SearchOperator = Get("z_AreaTerlarangInTanggal", Config.FilterOptionSeparator);

            // AreaTerlarangInFoto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AreaTerlarangInFoto[]"))
                    AreaTerlarangInFoto.AdvancedSearch.SearchValue = Get("x_AreaTerlarangInFoto[]", Config.FilterOptionSeparator);
                else
                    AreaTerlarangInFoto.AdvancedSearch.SearchValue = Get("AreaTerlarangInFoto"); // Default Value // DN
            if (!Empty(AreaTerlarangInFoto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AreaTerlarangInFoto"))
                AreaTerlarangInFoto.AdvancedSearch.SearchOperator = Get("z_AreaTerlarangInFoto", Config.FilterOptionSeparator);

            // AreaTerlarangInUser
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AreaTerlarangInUser[]"))
                    AreaTerlarangInUser.AdvancedSearch.SearchValue = Get("x_AreaTerlarangInUser[]", Config.FilterOptionSeparator);
                else
                    AreaTerlarangInUser.AdvancedSearch.SearchValue = Get("AreaTerlarangInUser"); // Default Value // DN
            if (!Empty(AreaTerlarangInUser.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AreaTerlarangInUser"))
                AreaTerlarangInUser.AdvancedSearch.SearchOperator = Get("z_AreaTerlarangInUser", Config.FilterOptionSeparator);

            // AreaTerlarangOutTanggal
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AreaTerlarangOutTanggal[]"))
                    AreaTerlarangOutTanggal.AdvancedSearch.SearchValue = Get("x_AreaTerlarangOutTanggal[]", Config.FilterOptionSeparator);
                else
                    AreaTerlarangOutTanggal.AdvancedSearch.SearchValue = Get("AreaTerlarangOutTanggal"); // Default Value // DN
            if (!Empty(AreaTerlarangOutTanggal.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AreaTerlarangOutTanggal"))
                AreaTerlarangOutTanggal.AdvancedSearch.SearchOperator = Get("z_AreaTerlarangOutTanggal", Config.FilterOptionSeparator);

            // AreaTerlarangOutFoto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AreaTerlarangOutFoto[]"))
                    AreaTerlarangOutFoto.AdvancedSearch.SearchValue = Get("x_AreaTerlarangOutFoto[]", Config.FilterOptionSeparator);
                else
                    AreaTerlarangOutFoto.AdvancedSearch.SearchValue = Get("AreaTerlarangOutFoto"); // Default Value // DN
            if (!Empty(AreaTerlarangOutFoto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AreaTerlarangOutFoto"))
                AreaTerlarangOutFoto.AdvancedSearch.SearchOperator = Get("z_AreaTerlarangOutFoto", Config.FilterOptionSeparator);

            // AreaTerlarangOutUser
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AreaTerlarangOutUser[]"))
                    AreaTerlarangOutUser.AdvancedSearch.SearchValue = Get("x_AreaTerlarangOutUser[]", Config.FilterOptionSeparator);
                else
                    AreaTerlarangOutUser.AdvancedSearch.SearchValue = Get("AreaTerlarangOutUser"); // Default Value // DN
            if (!Empty(AreaTerlarangOutUser.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AreaTerlarangOutUser"))
                AreaTerlarangOutUser.AdvancedSearch.SearchOperator = Get("z_AreaTerlarangOutUser", Config.FilterOptionSeparator);

            // etlDate
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_etlDate[]"))
                    etlDate.AdvancedSearch.SearchValue = Get("x_etlDate[]", Config.FilterOptionSeparator);
                else
                    etlDate.AdvancedSearch.SearchValue = Get("etlDate"); // Default Value // DN
            if (!Empty(etlDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_etlDate"))
                etlDate.AdvancedSearch.SearchOperator = Get("z_etlDate", Config.FilterOptionSeparator);

            // LastUpdatedBy
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LastUpdatedBy[]"))
                    LastUpdatedBy.AdvancedSearch.SearchValue = Get("x_LastUpdatedBy[]", Config.FilterOptionSeparator);
                else
                    LastUpdatedBy.AdvancedSearch.SearchValue = Get("LastUpdatedBy"); // Default Value // DN
            if (!Empty(LastUpdatedBy.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LastUpdatedBy"))
                LastUpdatedBy.AdvancedSearch.SearchOperator = Get("z_LastUpdatedBy", Config.FilterOptionSeparator);

            // lastUpdatedDate
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_lastUpdatedDate[]"))
                    lastUpdatedDate.AdvancedSearch.SearchValue = Get("x_lastUpdatedDate[]", Config.FilterOptionSeparator);
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
            NomorBukuTamu.SetDbValue(row["NomorBukuTamu"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            Plant.SetDbValue(row["Plant"]);
            Tanggal.SetDbValue(row["Tanggal"]);
            StatusZona.SetDbValue(row["StatusZona"]);
            Nama.SetDbValue(row["Nama"]);
            AsalPerusahaan.SetDbValue(row["AsalPerusahaan"]);
            Jabatan.SetDbValue(row["Jabatan"]);
            FungsiygDikunjungi.SetDbValue(row["FungsiygDikunjungi"]);
            MaksudKunjungan.SetDbValue(row["MaksudKunjungan"]);
            TandaPengenal.SetDbValue(row["TandaPengenal"]);
            TandaTangan.SetDbValue(row["TandaTangan"]);
            TandaTanganDownload.SetDbValue(row["TandaTanganDownload"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            PintuUtamaId.SetDbValue(row["PintuUtamaId"]);
            PintuUtamaInTanggal.SetDbValue(row["PintuUtamaInTanggal"]);
            PintuUtamaInFoto.SetDbValue(row["PintuUtamaInFoto"]);
            PintuUtamaInFotoDownload.SetDbValue(row["PintuUtamaInFotoDownload"]);
            PintuUtamaInUser.SetDbValue(row["PintuUtamaInUser"]);
            CustomPilihPintu.SetDbValue(row["CustomPilihPintu"]);
            PintuUtamaOutTanggal.SetDbValue(row["PintuUtamaOutTanggal"]);
            PintuUtamaOutFoto.SetDbValue(row["PintuUtamaOutFoto"]);
            PintuUtamaOutFotoDownload.SetDbValue(row["PintuUtamaOutFotoDownload"]);
            PintuUtamaOutUser.SetDbValue(row["PintuUtamaOutUser"]);
            LobbyUtamaId.SetDbValue(row["LobbyUtamaId"]);
            LobbyUtamaInTanggal.SetDbValue(row["LobbyUtamaInTanggal"]);
            LobbyUtamaInFoto.SetDbValue(row["LobbyUtamaInFoto"]);
            LobbyUtamaInFotoDownload.SetDbValue(row["LobbyUtamaInFotoDownload"]);
            LobbyUtamaInUser.SetDbValue(row["LobbyUtamaInUser"]);
            LobbyUtamaOutTanggal.SetDbValue(row["LobbyUtamaOutTanggal"]);
            LobbyUtamaOutFoto.SetDbValue(row["LobbyUtamaOutFoto"]);
            LobbyUtamaOutFotoDownload.SetDbValue(row["LobbyUtamaOutFotoDownload"]);
            LobbyUtamaOutUser.SetDbValue(row["LobbyUtamaOutUser"]);
            AreaTerlarangId.SetDbValue(row["AreaTerlarangId"]);
            AreaTerlarangInTanggal.SetDbValue(row["AreaTerlarangInTanggal"]);
            AreaTerlarangInFoto.SetDbValue(row["AreaTerlarangInFoto"]);
            AreaTerlarangInFotoDownload.SetDbValue(row["AreaTerlarangInFotoDownload"]);
            AreaTerlarangInUser.SetDbValue(row["AreaTerlarangInUser"]);
            AreaTerlarangOutTanggal.SetDbValue(row["AreaTerlarangOutTanggal"]);
            AreaTerlarangOutFoto.SetDbValue(row["AreaTerlarangOutFoto"]);
            AreaTerlarangOutFotoDownload.SetDbValue(row["AreaTerlarangOutFotoDownload"]);
            AreaTerlarangOutUser.SetDbValue(row["AreaTerlarangOutUser"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            StatusZonaPrev.SetDbValue(row["StatusZonaPrev"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorBukuTamu", NomorBukuTamu.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("Tanggal", Tanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusZona", StatusZona.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama", Nama.DefaultValue ?? DbNullValue); // DN
            row.Add("AsalPerusahaan", AsalPerusahaan.DefaultValue ?? DbNullValue); // DN
            row.Add("Jabatan", Jabatan.DefaultValue ?? DbNullValue); // DN
            row.Add("FungsiygDikunjungi", FungsiygDikunjungi.DefaultValue ?? DbNullValue); // DN
            row.Add("MaksudKunjungan", MaksudKunjungan.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaPengenal", TandaPengenal.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaTangan", TandaTangan.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaTanganDownload", TandaTanganDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaId", PintuUtamaId.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInTanggal", PintuUtamaInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInFoto", PintuUtamaInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInFotoDownload", PintuUtamaInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInUser", PintuUtamaInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("CustomPilihPintu", CustomPilihPintu.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutTanggal", PintuUtamaOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutFoto", PintuUtamaOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutFotoDownload", PintuUtamaOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutUser", PintuUtamaOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaId", LobbyUtamaId.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInTanggal", LobbyUtamaInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInFoto", LobbyUtamaInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInFotoDownload", LobbyUtamaInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInUser", LobbyUtamaInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutTanggal", LobbyUtamaOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutFoto", LobbyUtamaOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutFotoDownload", LobbyUtamaOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutUser", LobbyUtamaOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangId", AreaTerlarangId.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInTanggal", AreaTerlarangInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInFoto", AreaTerlarangInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInFotoDownload", AreaTerlarangInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInUser", AreaTerlarangInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutTanggal", AreaTerlarangOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutFoto", AreaTerlarangOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutFotoDownload", AreaTerlarangOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutUser", AreaTerlarangOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusZonaPrev", StatusZonaPrev.DefaultValue ?? DbNullValue); // DN
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

            // NomorBukuTamu

            // LinkRedirect

            // LookupPlant

            // Plant

            // Tanggal

            // StatusZona

            // Nama

            // AsalPerusahaan

            // Jabatan

            // FungsiygDikunjungi

            // MaksudKunjungan

            // TandaPengenal

            // TandaTangan

            // TandaTanganDownload

            // Keterangan

            // PintuUtamaId

            // PintuUtamaInTanggal

            // PintuUtamaInFoto

            // PintuUtamaInFotoDownload

            // PintuUtamaInUser

            // CustomPilihPintu

            // PintuUtamaOutTanggal

            // PintuUtamaOutFoto

            // PintuUtamaOutFotoDownload

            // PintuUtamaOutUser

            // LobbyUtamaId

            // LobbyUtamaInTanggal

            // LobbyUtamaInFoto

            // LobbyUtamaInFotoDownload

            // LobbyUtamaInUser

            // LobbyUtamaOutTanggal

            // LobbyUtamaOutFoto

            // LobbyUtamaOutFotoDownload

            // LobbyUtamaOutUser

            // AreaTerlarangId

            // AreaTerlarangInTanggal

            // AreaTerlarangInFoto

            // AreaTerlarangInFotoDownload

            // AreaTerlarangInUser

            // AreaTerlarangOutTanggal

            // AreaTerlarangOutFoto

            // AreaTerlarangOutFotoDownload

            // AreaTerlarangOutUser

            // etlDate

            // LastUpdatedBy

            // lastUpdatedDate

            // StatusZonaPrev

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // NomorBukuTamu
                NomorBukuTamu.ViewValue = ConvertToString(NomorBukuTamu.CurrentValue); // DN
                NomorBukuTamu.ViewCustomAttributes = "";

                // LinkRedirect
                LinkRedirect.ViewValue = ConvertToString(LinkRedirect.CurrentValue); // DN
                LinkRedirect.ViewCustomAttributes = "";

                // LookupPlant
                if (!Empty(LookupPlant.CurrentValue)) {
                    LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                } else {
                    LookupPlant.ViewValue = DbNullValue;
                }
                LookupPlant.ViewCustomAttributes = "";

                // Plant
                Plant.ViewValue = Plant.CurrentValue;
                string curVal2 = ConvertToString(Plant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Plant.ViewValue = Plant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = Plant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                            var listwrk = Plant.Lookup?.RenderViewRow(rswrk2[0]);
                            Plant.ViewValue = Plant.DisplayValue(listwrk);
                        } else {
                            Plant.ViewValue = Plant.CurrentValue;
                        }
                    }
                } else {
                    Plant.ViewValue = DbNullValue;
                }
                Plant.ViewCustomAttributes = "";

                // Tanggal
                Tanggal.ViewValue = Tanggal.CurrentValue;
                Tanggal.ViewValue = FormatDateTime(Tanggal.ViewValue, Tanggal.FormatPattern);
                Tanggal.ViewCustomAttributes = "";

                // StatusZona
                StatusZona.ViewValue = ConvertToString(StatusZona.CurrentValue); // DN
                StatusZona.ViewCustomAttributes = "";

                // Nama
                Nama.ViewValue = ConvertToString(Nama.CurrentValue); // DN
                Nama.ViewCustomAttributes = "";

                // AsalPerusahaan
                AsalPerusahaan.ViewValue = ConvertToString(AsalPerusahaan.CurrentValue); // DN
                AsalPerusahaan.ViewCustomAttributes = "";

                // Jabatan
                Jabatan.ViewValue = ConvertToString(Jabatan.CurrentValue); // DN
                Jabatan.ViewCustomAttributes = "";

                // FungsiygDikunjungi
                string curVal3 = ConvertToString(FungsiygDikunjungi.CurrentValue);
                if (!Empty(curVal3)) {
                    if (FungsiygDikunjungi.Lookup != null && IsDictionary(FungsiygDikunjungi.Lookup?.Options) && FungsiygDikunjungi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        FungsiygDikunjungi.ViewValue = FungsiygDikunjungi.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchExpression, "=", FungsiygDikunjungi.CurrentValue, FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchDataType, "");
                        string? sqlWrk3 = FungsiygDikunjungi.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && FungsiygDikunjungi.Lookup != null) { // Lookup values found
                            var listwrk = FungsiygDikunjungi.Lookup?.RenderViewRow(rswrk3[0]);
                            FungsiygDikunjungi.ViewValue = FungsiygDikunjungi.DisplayValue(listwrk);
                        } else {
                            FungsiygDikunjungi.ViewValue = FungsiygDikunjungi.CurrentValue;
                        }
                    }
                } else {
                    FungsiygDikunjungi.ViewValue = DbNullValue;
                }
                FungsiygDikunjungi.ViewCustomAttributes = "";

                // MaksudKunjungan
                MaksudKunjungan.ViewValue = ConvertToString(MaksudKunjungan.CurrentValue); // DN
                MaksudKunjungan.ViewCustomAttributes = "";

                // TandaPengenal
                if (!Empty(TandaPengenal.CurrentValue)) {
                    TandaPengenal.ViewValue = TandaPengenal.OptionCaption(ConvertToString(TandaPengenal.CurrentValue));
                } else {
                    TandaPengenal.ViewValue = DbNullValue;
                }
                TandaPengenal.ViewCustomAttributes = "";

                // TandaTangan
                TandaTangan.ViewValue = TandaTangan.CurrentValue;
                TandaTangan.ViewCustomAttributes = "";

                // TandaTanganDownload
                TandaTanganDownload.ViewValue = TandaTanganDownload.CurrentValue;
                TandaTanganDownload.ViewCustomAttributes = "";

                // Keterangan
                Keterangan.ViewValue = Keterangan.CurrentValue;
                Keterangan.ViewCustomAttributes = "";

                // PintuUtamaId
                PintuUtamaId.ViewValue = ConvertToString(PintuUtamaId.CurrentValue); // DN
                PintuUtamaId.ViewCustomAttributes = "";

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.ViewValue = PintuUtamaInTanggal.CurrentValue;
                PintuUtamaInTanggal.ViewValue = FormatDateTime(PintuUtamaInTanggal.ViewValue, PintuUtamaInTanggal.FormatPattern);
                PintuUtamaInTanggal.ViewCustomAttributes = "";

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.ViewValue = PintuUtamaInFotoDownload.CurrentValue;
                PintuUtamaInFotoDownload.ViewCustomAttributes = "";

                // PintuUtamaInUser
                PintuUtamaInUser.ViewValue = ConvertToString(PintuUtamaInUser.CurrentValue); // DN
                PintuUtamaInUser.ViewCustomAttributes = "";

                // CustomPilihPintu
                CustomPilihPintu.ViewValue = ConvertToString(CustomPilihPintu.CurrentValue); // DN
                CustomPilihPintu.ViewCustomAttributes = "";

                // PintuUtamaOutTanggal
                PintuUtamaOutTanggal.ViewValue = PintuUtamaOutTanggal.CurrentValue;
                PintuUtamaOutTanggal.ViewValue = FormatDateTime(PintuUtamaOutTanggal.ViewValue, PintuUtamaOutTanggal.FormatPattern);
                PintuUtamaOutTanggal.ViewCustomAttributes = "";

                // PintuUtamaOutFotoDownload
                PintuUtamaOutFotoDownload.ViewValue = PintuUtamaOutFotoDownload.CurrentValue;
                PintuUtamaOutFotoDownload.ViewCustomAttributes = "";

                // PintuUtamaOutUser
                PintuUtamaOutUser.ViewValue = ConvertToString(PintuUtamaOutUser.CurrentValue); // DN
                PintuUtamaOutUser.ViewCustomAttributes = "";

                // LobbyUtamaId
                LobbyUtamaId.ViewValue = ConvertToString(LobbyUtamaId.CurrentValue); // DN
                LobbyUtamaId.ViewCustomAttributes = "";

                // LobbyUtamaInTanggal
                LobbyUtamaInTanggal.ViewValue = LobbyUtamaInTanggal.CurrentValue;
                LobbyUtamaInTanggal.ViewValue = FormatDateTime(LobbyUtamaInTanggal.ViewValue, LobbyUtamaInTanggal.FormatPattern);
                LobbyUtamaInTanggal.ViewCustomAttributes = "";

                // LobbyUtamaInFotoDownload
                LobbyUtamaInFotoDownload.ViewValue = LobbyUtamaInFotoDownload.CurrentValue;
                LobbyUtamaInFotoDownload.ViewCustomAttributes = "";

                // LobbyUtamaInUser
                LobbyUtamaInUser.ViewValue = ConvertToString(LobbyUtamaInUser.CurrentValue); // DN
                LobbyUtamaInUser.ViewCustomAttributes = "";

                // LobbyUtamaOutTanggal
                LobbyUtamaOutTanggal.ViewValue = LobbyUtamaOutTanggal.CurrentValue;
                LobbyUtamaOutTanggal.ViewValue = FormatDateTime(LobbyUtamaOutTanggal.ViewValue, LobbyUtamaOutTanggal.FormatPattern);
                LobbyUtamaOutTanggal.ViewCustomAttributes = "";

                // LobbyUtamaOutFotoDownload
                LobbyUtamaOutFotoDownload.ViewValue = LobbyUtamaOutFotoDownload.CurrentValue;
                LobbyUtamaOutFotoDownload.ViewCustomAttributes = "";

                // LobbyUtamaOutUser
                LobbyUtamaOutUser.ViewValue = ConvertToString(LobbyUtamaOutUser.CurrentValue); // DN
                LobbyUtamaOutUser.ViewCustomAttributes = "";

                // AreaTerlarangId
                AreaTerlarangId.ViewValue = ConvertToString(AreaTerlarangId.CurrentValue); // DN
                AreaTerlarangId.ViewCustomAttributes = "";

                // AreaTerlarangInTanggal
                AreaTerlarangInTanggal.ViewValue = AreaTerlarangInTanggal.CurrentValue;
                AreaTerlarangInTanggal.ViewValue = FormatDateTime(AreaTerlarangInTanggal.ViewValue, AreaTerlarangInTanggal.FormatPattern);
                AreaTerlarangInTanggal.ViewCustomAttributes = "";

                // AreaTerlarangInFotoDownload
                AreaTerlarangInFotoDownload.ViewValue = AreaTerlarangInFotoDownload.CurrentValue;
                AreaTerlarangInFotoDownload.ViewCustomAttributes = "";

                // AreaTerlarangInUser
                AreaTerlarangInUser.ViewValue = ConvertToString(AreaTerlarangInUser.CurrentValue); // DN
                AreaTerlarangInUser.ViewCustomAttributes = "";

                // AreaTerlarangOutTanggal
                AreaTerlarangOutTanggal.ViewValue = AreaTerlarangOutTanggal.CurrentValue;
                AreaTerlarangOutTanggal.ViewValue = FormatDateTime(AreaTerlarangOutTanggal.ViewValue, AreaTerlarangOutTanggal.FormatPattern);
                AreaTerlarangOutTanggal.ViewCustomAttributes = "";

                // AreaTerlarangOutFotoDownload
                AreaTerlarangOutFotoDownload.ViewValue = AreaTerlarangOutFotoDownload.CurrentValue;
                AreaTerlarangOutFotoDownload.ViewCustomAttributes = "";

                // AreaTerlarangOutUser
                AreaTerlarangOutUser.ViewValue = ConvertToString(AreaTerlarangOutUser.CurrentValue); // DN
                AreaTerlarangOutUser.ViewCustomAttributes = "";

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

                // StatusZonaPrev
                StatusZonaPrev.ViewValue = ConvertToString(StatusZonaPrev.CurrentValue); // DN
                StatusZonaPrev.ViewCustomAttributes = "";

                // LinkRedirect
                LinkRedirect.HrefValue = "";
                LinkRedirect.TooltipValue = "";

                // Plant
                Plant.HrefValue = "";
                Plant.TooltipValue = "";

                // Tanggal
                Tanggal.HrefValue = "";
                Tanggal.TooltipValue = "";

                // StatusZona
                StatusZona.HrefValue = "";
                StatusZona.TooltipValue = "";

                // Nama
                Nama.HrefValue = "";
                Nama.TooltipValue = "";

                // AsalPerusahaan
                AsalPerusahaan.HrefValue = "";
                AsalPerusahaan.TooltipValue = "";

                // Jabatan
                Jabatan.HrefValue = "";
                Jabatan.TooltipValue = "";

                // FungsiygDikunjungi
                FungsiygDikunjungi.HrefValue = "";
                FungsiygDikunjungi.TooltipValue = "";

                // MaksudKunjungan
                MaksudKunjungan.HrefValue = "";
                MaksudKunjungan.TooltipValue = "";

                // TandaPengenal
                TandaPengenal.HrefValue = "";
                TandaPengenal.TooltipValue = "";

                // TandaTanganDownload
                TandaTanganDownload.HrefValue = "";
                TandaTanganDownload.TooltipValue = "";

                // Keterangan
                Keterangan.HrefValue = "";
                Keterangan.TooltipValue = "";

                // PintuUtamaId
                PintuUtamaId.HrefValue = "";
                PintuUtamaId.TooltipValue = "";

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.HrefValue = "";
                PintuUtamaInTanggal.TooltipValue = "";

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.HrefValue = "";
                PintuUtamaInFotoDownload.TooltipValue = "";

                // PintuUtamaInUser
                PintuUtamaInUser.HrefValue = "";
                PintuUtamaInUser.TooltipValue = "";

                // CustomPilihPintu
                CustomPilihPintu.HrefValue = "";
                CustomPilihPintu.TooltipValue = "";

                // PintuUtamaOutTanggal
                PintuUtamaOutTanggal.HrefValue = "";
                PintuUtamaOutTanggal.TooltipValue = "";

                // PintuUtamaOutFotoDownload
                PintuUtamaOutFotoDownload.HrefValue = "";
                PintuUtamaOutFotoDownload.TooltipValue = "";

                // PintuUtamaOutUser
                PintuUtamaOutUser.HrefValue = "";
                PintuUtamaOutUser.TooltipValue = "";

                // LobbyUtamaId
                LobbyUtamaId.HrefValue = "";
                LobbyUtamaId.TooltipValue = "";

                // LobbyUtamaInTanggal
                LobbyUtamaInTanggal.HrefValue = "";
                LobbyUtamaInTanggal.TooltipValue = "";

                // LobbyUtamaInFotoDownload
                LobbyUtamaInFotoDownload.HrefValue = "";
                LobbyUtamaInFotoDownload.TooltipValue = "";

                // LobbyUtamaInUser
                LobbyUtamaInUser.HrefValue = "";
                LobbyUtamaInUser.TooltipValue = "";

                // LobbyUtamaOutTanggal
                LobbyUtamaOutTanggal.HrefValue = "";
                LobbyUtamaOutTanggal.TooltipValue = "";

                // LobbyUtamaOutFotoDownload
                LobbyUtamaOutFotoDownload.HrefValue = "";
                LobbyUtamaOutFotoDownload.TooltipValue = "";

                // LobbyUtamaOutUser
                LobbyUtamaOutUser.HrefValue = "";
                LobbyUtamaOutUser.TooltipValue = "";

                // AreaTerlarangId
                AreaTerlarangId.HrefValue = "";
                AreaTerlarangId.TooltipValue = "";

                // AreaTerlarangInTanggal
                AreaTerlarangInTanggal.HrefValue = "";
                AreaTerlarangInTanggal.TooltipValue = "";

                // AreaTerlarangInFotoDownload
                AreaTerlarangInFotoDownload.HrefValue = "";
                AreaTerlarangInFotoDownload.TooltipValue = "";

                // AreaTerlarangInUser
                AreaTerlarangInUser.HrefValue = "";
                AreaTerlarangInUser.TooltipValue = "";

                // AreaTerlarangOutTanggal
                AreaTerlarangOutTanggal.HrefValue = "";
                AreaTerlarangOutTanggal.TooltipValue = "";

                // AreaTerlarangOutFotoDownload
                AreaTerlarangOutFotoDownload.HrefValue = "";
                AreaTerlarangOutFotoDownload.TooltipValue = "";

                // AreaTerlarangOutUser
                AreaTerlarangOutUser.HrefValue = "";
                AreaTerlarangOutUser.TooltipValue = "";

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
                // LinkRedirect
                if (LinkRedirect.UseFilter && !Empty(LinkRedirect.AdvancedSearch.SearchValue)) {
                    LinkRedirect.EditValue = ConvertToString(LinkRedirect.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // Plant
                if (Plant.UseFilter && !Empty(Plant.AdvancedSearch.SearchValue)) {
                    Plant.EditValue = ConvertToString(Plant.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // Tanggal
                if (Tanggal.UseFilter && !Empty(Tanggal.AdvancedSearch.SearchValue)) {
                    Tanggal.EditValue = ConvertToString(Tanggal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // StatusZona
                if (StatusZona.UseFilter && !Empty(StatusZona.AdvancedSearch.SearchValue)) {
                    StatusZona.EditValue = ConvertToString(StatusZona.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // Nama
                if (Nama.UseFilter && !Empty(Nama.AdvancedSearch.SearchValue)) {
                    Nama.EditValue = ConvertToString(Nama.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // AsalPerusahaan
                if (AsalPerusahaan.UseFilter && !Empty(AsalPerusahaan.AdvancedSearch.SearchValue)) {
                    AsalPerusahaan.EditValue = ConvertToString(AsalPerusahaan.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // Jabatan
                if (Jabatan.UseFilter && !Empty(Jabatan.AdvancedSearch.SearchValue)) {
                    Jabatan.EditValue = ConvertToString(Jabatan.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // FungsiygDikunjungi
                if (FungsiygDikunjungi.UseFilter && !Empty(FungsiygDikunjungi.AdvancedSearch.SearchValue)) {
                    FungsiygDikunjungi.EditValue = ConvertToString(FungsiygDikunjungi.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // MaksudKunjungan
                if (MaksudKunjungan.UseFilter && !Empty(MaksudKunjungan.AdvancedSearch.SearchValue)) {
                    MaksudKunjungan.EditValue = ConvertToString(MaksudKunjungan.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // TandaPengenal
                if (TandaPengenal.UseFilter && !Empty(TandaPengenal.AdvancedSearch.SearchValue)) {
                    TandaPengenal.EditValue = ConvertToString(TandaPengenal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // TandaTanganDownload
                TandaTanganDownload.SetupEditAttributes();
                TandaTanganDownload.EditValue = TandaTanganDownload.AdvancedSearch.SearchValue; // DN
                TandaTanganDownload.PlaceHolder = RemoveHtml(TandaTanganDownload.Caption);

                // Keterangan
                if (Keterangan.UseFilter && !Empty(Keterangan.AdvancedSearch.SearchValue)) {
                    Keterangan.EditValue = ConvertToString(Keterangan.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // PintuUtamaId
                if (PintuUtamaId.UseFilter && !Empty(PintuUtamaId.AdvancedSearch.SearchValue)) {
                    PintuUtamaId.EditValue = ConvertToString(PintuUtamaId.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // PintuUtamaInTanggal
                if (PintuUtamaInTanggal.UseFilter && !Empty(PintuUtamaInTanggal.AdvancedSearch.SearchValue)) {
                    PintuUtamaInTanggal.EditValue = ConvertToString(PintuUtamaInTanggal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.SetupEditAttributes();
                PintuUtamaInFotoDownload.EditValue = PintuUtamaInFotoDownload.AdvancedSearch.SearchValue; // DN
                PintuUtamaInFotoDownload.PlaceHolder = RemoveHtml(PintuUtamaInFotoDownload.Caption);

                // PintuUtamaInUser
                if (PintuUtamaInUser.UseFilter && !Empty(PintuUtamaInUser.AdvancedSearch.SearchValue)) {
                    PintuUtamaInUser.EditValue = ConvertToString(PintuUtamaInUser.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // CustomPilihPintu
                if (CustomPilihPintu.UseFilter && !Empty(CustomPilihPintu.AdvancedSearch.SearchValue)) {
                    CustomPilihPintu.EditValue = ConvertToString(CustomPilihPintu.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // PintuUtamaOutTanggal
                if (PintuUtamaOutTanggal.UseFilter && !Empty(PintuUtamaOutTanggal.AdvancedSearch.SearchValue)) {
                    PintuUtamaOutTanggal.EditValue = ConvertToString(PintuUtamaOutTanggal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // PintuUtamaOutFotoDownload
                PintuUtamaOutFotoDownload.SetupEditAttributes();
                PintuUtamaOutFotoDownload.EditValue = PintuUtamaOutFotoDownload.AdvancedSearch.SearchValue; // DN
                PintuUtamaOutFotoDownload.PlaceHolder = RemoveHtml(PintuUtamaOutFotoDownload.Caption);

                // PintuUtamaOutUser
                if (PintuUtamaOutUser.UseFilter && !Empty(PintuUtamaOutUser.AdvancedSearch.SearchValue)) {
                    PintuUtamaOutUser.EditValue = ConvertToString(PintuUtamaOutUser.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // LobbyUtamaId
                if (LobbyUtamaId.UseFilter && !Empty(LobbyUtamaId.AdvancedSearch.SearchValue)) {
                    LobbyUtamaId.EditValue = ConvertToString(LobbyUtamaId.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // LobbyUtamaInTanggal
                if (LobbyUtamaInTanggal.UseFilter && !Empty(LobbyUtamaInTanggal.AdvancedSearch.SearchValue)) {
                    LobbyUtamaInTanggal.EditValue = ConvertToString(LobbyUtamaInTanggal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // LobbyUtamaInFotoDownload
                LobbyUtamaInFotoDownload.SetupEditAttributes();
                LobbyUtamaInFotoDownload.EditValue = LobbyUtamaInFotoDownload.AdvancedSearch.SearchValue; // DN
                LobbyUtamaInFotoDownload.PlaceHolder = RemoveHtml(LobbyUtamaInFotoDownload.Caption);

                // LobbyUtamaInUser
                if (LobbyUtamaInUser.UseFilter && !Empty(LobbyUtamaInUser.AdvancedSearch.SearchValue)) {
                    LobbyUtamaInUser.EditValue = ConvertToString(LobbyUtamaInUser.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // LobbyUtamaOutTanggal
                if (LobbyUtamaOutTanggal.UseFilter && !Empty(LobbyUtamaOutTanggal.AdvancedSearch.SearchValue)) {
                    LobbyUtamaOutTanggal.EditValue = ConvertToString(LobbyUtamaOutTanggal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // LobbyUtamaOutFotoDownload
                LobbyUtamaOutFotoDownload.SetupEditAttributes();
                LobbyUtamaOutFotoDownload.EditValue = LobbyUtamaOutFotoDownload.AdvancedSearch.SearchValue; // DN
                LobbyUtamaOutFotoDownload.PlaceHolder = RemoveHtml(LobbyUtamaOutFotoDownload.Caption);

                // LobbyUtamaOutUser
                if (LobbyUtamaOutUser.UseFilter && !Empty(LobbyUtamaOutUser.AdvancedSearch.SearchValue)) {
                    LobbyUtamaOutUser.EditValue = ConvertToString(LobbyUtamaOutUser.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // AreaTerlarangId
                if (AreaTerlarangId.UseFilter && !Empty(AreaTerlarangId.AdvancedSearch.SearchValue)) {
                    AreaTerlarangId.EditValue = ConvertToString(AreaTerlarangId.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // AreaTerlarangInTanggal
                if (AreaTerlarangInTanggal.UseFilter && !Empty(AreaTerlarangInTanggal.AdvancedSearch.SearchValue)) {
                    AreaTerlarangInTanggal.EditValue = ConvertToString(AreaTerlarangInTanggal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // AreaTerlarangInFotoDownload
                AreaTerlarangInFotoDownload.SetupEditAttributes();
                AreaTerlarangInFotoDownload.EditValue = AreaTerlarangInFotoDownload.AdvancedSearch.SearchValue; // DN
                AreaTerlarangInFotoDownload.PlaceHolder = RemoveHtml(AreaTerlarangInFotoDownload.Caption);

                // AreaTerlarangInUser
                if (AreaTerlarangInUser.UseFilter && !Empty(AreaTerlarangInUser.AdvancedSearch.SearchValue)) {
                    AreaTerlarangInUser.EditValue = ConvertToString(AreaTerlarangInUser.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // AreaTerlarangOutTanggal
                if (AreaTerlarangOutTanggal.UseFilter && !Empty(AreaTerlarangOutTanggal.AdvancedSearch.SearchValue)) {
                    AreaTerlarangOutTanggal.EditValue = ConvertToString(AreaTerlarangOutTanggal.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // AreaTerlarangOutFotoDownload
                AreaTerlarangOutFotoDownload.SetupEditAttributes();
                AreaTerlarangOutFotoDownload.EditValue = AreaTerlarangOutFotoDownload.AdvancedSearch.SearchValue; // DN
                AreaTerlarangOutFotoDownload.PlaceHolder = RemoveHtml(AreaTerlarangOutFotoDownload.Caption);

                // AreaTerlarangOutUser
                if (AreaTerlarangOutUser.UseFilter && !Empty(AreaTerlarangOutUser.AdvancedSearch.SearchValue)) {
                    AreaTerlarangOutUser.EditValue = ConvertToString(AreaTerlarangOutUser.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
                }

                // etlDate
                if (etlDate.UseFilter && !Empty(etlDate.AdvancedSearch.SearchValue)) {
                    etlDate.EditValue = ConvertToString(etlDate.AdvancedSearch.SearchValue).Split(Config.FilterOptionSeparator).ToList();
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
            Tanggal.AdvancedSearch.Load();
            PintuUtamaInTanggal.AdvancedSearch.Load();
            PintuUtamaOutTanggal.AdvancedSearch.Load();
            LobbyUtamaInTanggal.AdvancedSearch.Load();
            LobbyUtamaOutTanggal.AdvancedSearch.Load();
            AreaTerlarangInTanggal.AdvancedSearch.Load();
            AreaTerlarangOutTanggal.AdvancedSearch.Load();
            etlDate.AdvancedSearch.Load();
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
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fBukuTamulist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fBukuTamulist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fBukuTamulist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
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
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fBukuTamulist\" data-ew-action=\"email\" data-custom=\"false\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
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
            item.Body = "<a class=\"btn btn-default ew-search-toggle" + searchToggleClass + "\" role=\"button\" title=\"" + Language.Phrase("SearchPanel") + "\" data-caption=\"" + Language.Phrase("SearchPanel") + "\" data-ew-action=\"search-toggle\" data-form=\"fBukuTamusrch\" aria-pressed=\"" + (searchToggleClass == " active" ? "true" : "false") + "\">" + Language.Phrase("SearchLink") + "</a>";
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
