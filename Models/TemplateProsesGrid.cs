namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// templateProsesGrid
    /// </summary>
    public static TemplateProsesGrid templateProsesGrid
    {
        get => HttpData.Get<TemplateProsesGrid>("templateProsesGrid")!;
        set => HttpData["templateProsesGrid"] = value;
    }

    /// <summary>
    /// Page class for TemplateProses
    /// </summary>
    public class TemplateProsesGrid : TemplateProsesGridBase
    {
        // Constructor
        public TemplateProsesGrid() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class TemplateProsesGridBase : TemplateProses
    {
        // Page ID
        public string PageID = "grid";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "templateProsesGrid";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fTemplateProsesgrid";

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
        public TemplateProsesGridBase()
        {
            TableName = "TemplateProses";

            // CSS class name as context
            TableVar = "TemplateProses";
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Fixed header table
            if (!UseCustomTemplate)
                SetFixedHeaderTable(Config.UseFixedHeaderTable, Config.FixedHeaderTableHeight);
            FormActionName = Config.FormRowActionName;
            FormBlankRowName = Config.FormBlankRowName;
            FormKeyCountName = Config.FormKeyCountName;

            // Initialize
            FormActionName += "_" + FormName;
            OldKeyName += "_" + FormName;
            FormBlankRowName += "_" + FormName;
            FormKeyCountName += "_" + FormName;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // CSS class name as context
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Language object
            Language = ResolveLanguage();
            AddUrl = "TemplateProsesAdd";

            // Open connection
            Conn = Connection; // DN

            // Other options
            OtherOptions["addedit"] = new() {
                TagClassName = "ew-add-edit-option",
                UseDropDownButton = false,
                DropDownButtonPhrase = "ButtonAddEdit",
                UseButtonGroup = true
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
        public string PageName => "TemplateProsesGrid";

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
            IdTemplateProses.Visible = false;
            IdTemplate.SetVisibility();
            UrutanProses.SetVisibility();
            NamaProses.SetVisibility();
            IdPIC.SetVisibility();
            IdTools.SetVisibility();
            Keterangan.SetVisibility();
            DibuatOleh.SetVisibility();
            TanggalDibuat.SetVisibility();
            DiperbaruiOleh.SetVisibility();
            TanggalDiperbarui.SetVisibility();
            TipeProses.Visible = false;
        }

        /// <summary>
        /// Terminate page
        /// </summary>
        /// <param name="url">URL to rediect to</param>
        /// <returns>Page result</returns>
        public override IActionResult Terminate(string url = "") { // DN
            if (_terminated) // DN
                return new EmptyResult();
            if (Empty(url))
                return new EmptyResult();
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
                    SaveDebugMessage();
                    return Controller.LocalRedirect(AppPath(url));
                }
            }
            return new EmptyResult();
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdTemplateProses") ? dict["IdTemplateProses"] : IdTemplateProses.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdTemplateProses.Visible = false;
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

        #pragma warning disable 169

        public bool ShowOtherOptions = false;

        private DatabaseConnection<SqlConnection, SqlDbType>? _connection;
        #pragma warning restore 169

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

        #pragma warning disable 618
        // Connection
        public override DatabaseConnection<SqlConnection, SqlDbType> Connection
        {
            get {
                _connection ??= GetConnection2(DbId);
                return _connection;
            }
        }
        #pragma warning restore 618

        /// <summary>
        /// Load recordset from filter
        /// <param name="filter">Record filter</param>
        /// </summary>
        public async Task LoadRecordsetFromFilter(string filter)
        {
            // Set up list options
            await SetupListOptions();

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
            if (!Empty(Param("export")))
                Export = Param("export");

            // Get grid add count
            int gridaddcnt = Get<int>(Config.TableGridAddRowCount);
            if (gridaddcnt > 0)
                GridAddRowCount = gridaddcnt;

            // Set up list options
            await SetupListOptions();
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

            // Set up master detail parameters
            SetupMasterParms();

            // Setup other options
            SetupOtherOptions();

            // Set up lookup cache
            await SetupLookupOptions(IdTemplate);
            await SetupLookupOptions(IdPIC);
            await SetupLookupOptions(IdTools);

            // Load default values for add
            LoadDefaultValues();

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fTemplateProsesgrid";

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

            // Set up records per page
            SetupDisplayRecords();

            // Handle reset command
            ResetCommand();

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

            // Show grid delete link for grid add / grid edit
            if (AllowAddDeleteRow) {
                if (IsGridAdd || IsGridEdit) {
                    var item = ListOptions["griddelete"];
                    if (item != null)
                        item.Visible = Security.AllowDelete(CurrentProjectID + TableName);
                }
            }

            // Set up sorting order
            SetupSortOrder();

            // Restore display records
            if (Command != "json" && (RecordsPerPage == -1 || RecordsPerPage > 0)) {
                DisplayRecords = RecordsPerPage; // Restore from Session
            } else {
                DisplayRecords = 10; // Load default
                RecordsPerPage = DisplayRecords; // Save default to session
            }

            // Build filter
            if (!Security.CanList)
                Filter = "(0=1)"; // Filter all records

            // Restore master/detail filter from session
            DbMasterFilter = MasterFilterFromSession;
            DbDetailFilter = DetailFilterFromSession;
            AddFilter(ref Filter, DbDetailFilter);
            AddFilter(ref Filter, SearchWhere);

            // Load master record
            if (CurrentMode != "add" && !Empty(MasterFilterFromSession) && CurrentMasterTable == "MasterTemplate") {
                masterTemplate = Resolve("MasterTemplate")!;
                if (masterTemplate != null) {
                    var rowMaster = await masterTemplate.Connection.GetRowAsync(masterTemplate.GetSql(DbMasterFilter));
                    MasterRecordExists = rowMaster != null;
                    if (!MasterRecordExists) {
                        FailureMessage = Language.Phrase("NoRecord"); // Set no record found
                        return Terminate("MasterTemplateList"); // Return to master page
                    } else {
                        masterTemplate.LoadListRowValues(rowMaster);
                    }
                    masterTemplate.RowType = RowType.Master; // Master row
                    await masterTemplate.RenderListRow(); // Note: Do it outside "using" // DN
                }
            }

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
                if (CurrentMode == "copy") {
                    TotalRecords = await ListRecordCountAsync();
                    Recordset = await LoadRecordset(StartRecord - 1, TotalRecords);
                    StartRecord = 1;
                    DisplayRecords = TotalRecords;
                } else {
                    CurrentFilter = "0=1";
                    StartRecord = 1;
                    DisplayRecords = GridAddRowCount;
                }
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
                DisplayRecords = TotalRecords; // Display all records

                // Recordset
                bool selectLimit = UseSelectLimit;
                if (selectLimit)
                    Recordset = await LoadRecordset(StartRecord - 1, DisplayRecords);
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
                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();
                PageRenderingEventHandler?.Invoke(this, EventArgs.Empty);

                // Page Render event
                templateProsesGrid?.PageRender();
            }
            return new EmptyResult();
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

        // Exit inline mode
        protected void ClearInlineMode() {
            LastAction = CurrentAction; // Save last action
            CurrentAction = ""; // Clear action
            Session[Config.SessionInlineMode] = ""; // Clear inline mode
        }

        // Switch to grid add mode
        protected void GridAddMode() {
            CurrentAction = "gridadd";
            Session[Config.SessionInlineMode] = "gridadd"; // Enabled grid add
            HideFieldsForAddEdit();
        }

        // Switch to grid edit mode
        protected void GridEditMode() {
            CurrentAction = "gridedit";
            Session[Config.SessionInlineMode] = "gridedit"; // Enabled grid edit
            HideFieldsForAddEdit();
        }

        // Perform update to grid
        public async Task<bool> GridUpdate()
        {
            bool gridUpdate = true;

            // Get old recordset
            CurrentFilter = BuildKeyFilter();
            if (Empty(CurrentFilter))
                CurrentFilter = "0=1";
            string sql = CurrentSql;
            List<Dictionary<string, object>> rsold = await Connection.GetRowsAsync(sql);

            // Call Grid Updating event
            if (!GridUpdating(rsold)) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("GridEditCancelled"); // Set grid edit cancelled message
                EventCancelled = true;
                return false;
            }
            string wrkFilter = "";
            string key = "";

            // Update row index and get row key
            CurrentForm?.ResetIndex();
            int rowcnt = CurrentForm?.GetInt(FormKeyCountName) ?? 0;

            // Load default values for emptyRow checking // DN
            LoadDefaultValues();

            // Update all rows based on key
            try {
                for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                    CurrentForm!.Index = rowindex;
                    SetKey(CurrentForm.GetValue(OldKeyName));
                    string rowaction = CurrentForm.GetValue(FormActionName);

                    // Load all values and keys
                    if (rowaction != "insertdelete" && rowaction != "hide") { // Skip insert then deleted rows / hidden rows for grid edit
                        await LoadFormValues(); // Get form values
                        if (Empty(rowaction) || rowaction == "edit" || rowaction == "delete") {
                            gridUpdate = !Empty(OldKey); // Key must not be empty
                        } else {
                            gridUpdate = true;
                        }

                        // Skip empty row
                        if (rowaction == "insert" && EmptyRow()) {
                            // No action required
                        } else if (gridUpdate) { // Validate form and insert/update/delete record
                            if (rowaction == "delete") {
                                CurrentFilter = GetRecordFilter();
                                gridUpdate = await DeleteRows(); // Delete this row
                            } else {
                                if (rowaction == "insert") {
                                    gridUpdate = await AddRow(); // Insert this row
                                } else {
                                    if (!Empty(OldKey)) {
                                        SendEmail = false; // Do not send email on update success
                                        gridUpdate = await EditRow(); // Update this row
                                    }
                                } // End update
                                if (gridUpdate) // Get inserted or updated filter
                                    AddFilter(ref wrkFilter, GetRecordFilter(), "OR");
                            }
                        }
                        if (gridUpdate) {
                            if (!Empty(key))
                                key += ", ";
                            key += OldKey;
                        } else {
                            EventCancelled = true;
                            break;
                        }
                    }
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                gridUpdate = false;
            }
            if (gridUpdate) {
                FilterForModalActions = wrkFilter;

                // Get new recordset
                List<Dictionary<string, object>> rsnew = await Connection.GetRowsAsync(sql, true); // Use main connection (faster) // DN

                // Call Grid Updated event
                GridUpdated(rsold, rsnew);
                ClearInlineMode(); // Clear inline edit mode
            } else {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("UpdateFailed"); // Set update failed message
            }
            return gridUpdate;
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

        // Perform Grid Add
        #pragma warning disable 168, 219

        public async Task<bool> GridInsert()
        {
            int addcnt = 0;
            bool gridInsert = false;

            // Call Grid Inserting event
            if (!GridInserting()) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("GridAddCancelled"); // Set grid add cancelled message
                EventCancelled = true;
                return false;
            }

            // Init key filter
            string wrkFilter = "";
            string key = "";

            // Get row count
            CurrentForm?.ResetIndex();
            int rowcnt = CurrentForm?.GetInt(FormKeyCountName) ?? 0;

            // Load default values for emptyRow checking // DN
            LoadDefaultValues();

            // Insert all rows
            try {
                for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                    // Load current row values
                    CurrentForm!.Index = rowindex;
                    string rowaction = CurrentForm.GetValue(FormActionName);
                    Dictionary<string, object>? rsold = null;
                    if (!Empty(rowaction) && rowaction != "insert")
                        continue; // Skip
                    if (rowaction == "insert") {
                        OldKey = CurrentForm.GetValue(OldKeyName);
                        rsold = await LoadOldRecord(); // Load old record
                    }
                    await LoadFormValues(); // Get form values
                    if (!EmptyRow()) {
                        addcnt++;
                        SendEmail = false; // Do not send email on insert success
                        gridInsert = await AddRow(rsold); // Insert row (already validated by validateGridForm())
                        if (gridInsert) {
                            if (!Empty(key))
                                key += Config.CompositeKeySeparator;
                            key += ConvertToString(IdTemplateProses.CurrentValue);

                            // Add filter for this record
                            AddFilter(ref wrkFilter, GetRecordFilter(), "OR");
                        } else {
                            EventCancelled = true;
                            break;
                        }
                    }
                }
                if (addcnt == 0) { // No record inserted
                    ClearInlineMode(); // Clear grid add mode and return
                    return true;
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                gridInsert = false;
            }
            if (gridInsert) {
                // Get new recordset
                CurrentFilter = wrkFilter;
                FilterForModalActions = wrkFilter;
                string sql = CurrentSql;
                List<Dictionary<string, object>> rsnew = await Connection.GetRowsAsync(sql, true); // Use main connection (faster) // DN

                // Call Grid Inserted event
                GridInserted(rsnew);
                ClearInlineMode(); // Clear grid add mode
            } else {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("InsertFailed"); // Set insert failed message
            }
            return gridInsert;
        }
        #pragma warning restore 168, 219

        // Check if empty row
        public bool EmptyRow()
        {
            if (CurrentForm == null)
                return true;
            if (CurrentForm.HasValue("x_IdTemplate") && CurrentForm.HasValue("o_IdTemplate") && !SameString(IdTemplate.CurrentValue, IdTemplate.DefaultValue) &&
            !(IdTemplate.IsForeignKey && CurrentMasterTable != "" && SameString(IdTemplate.CurrentValue, IdTemplate.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_UrutanProses") && CurrentForm.HasValue("o_UrutanProses") && !SameString(UrutanProses.CurrentValue, UrutanProses.DefaultValue) &&
            !(UrutanProses.IsForeignKey && CurrentMasterTable != "" && SameString(UrutanProses.CurrentValue, UrutanProses.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_NamaProses") && CurrentForm.HasValue("o_NamaProses") && !SameString(NamaProses.CurrentValue, NamaProses.DefaultValue) &&
            !(NamaProses.IsForeignKey && CurrentMasterTable != "" && SameString(NamaProses.CurrentValue, NamaProses.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_IdPIC") && CurrentForm.HasValue("o_IdPIC") && !SameString(IdPIC.CurrentValue, IdPIC.DefaultValue) &&
            !(IdPIC.IsForeignKey && CurrentMasterTable != "" && SameString(IdPIC.CurrentValue, IdPIC.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_IdTools") && CurrentForm.HasValue("o_IdTools") && !SameString(IdTools.CurrentValue, IdTools.DefaultValue) &&
            !(IdTools.IsForeignKey && CurrentMasterTable != "" && SameString(IdTools.CurrentValue, IdTools.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_Keterangan") && CurrentForm.HasValue("o_Keterangan") && !SameString(Keterangan.CurrentValue, Keterangan.DefaultValue) &&
            !(Keterangan.IsForeignKey && CurrentMasterTable != "" && SameString(Keterangan.CurrentValue, Keterangan.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_DibuatOleh") && CurrentForm.HasValue("o_DibuatOleh") && !SameString(DibuatOleh.CurrentValue, DibuatOleh.DefaultValue) &&
            !(DibuatOleh.IsForeignKey && CurrentMasterTable != "" && SameString(DibuatOleh.CurrentValue, DibuatOleh.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_TanggalDibuat") && CurrentForm.HasValue("o_TanggalDibuat") && !SameString(FormatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern), FormatDateTime(TanggalDibuat.DefaultValue, TanggalDibuat.FormatPattern)) &&
            !(TanggalDibuat.IsForeignKey && CurrentMasterTable != "" && SameString(FormatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern), FormatDateTime(TanggalDibuat.SessionValue, TanggalDibuat.FormatPattern))))
                return false;
            if (CurrentForm.HasValue("x_DiperbaruiOleh") && CurrentForm.HasValue("o_DiperbaruiOleh") && !SameString(DiperbaruiOleh.CurrentValue, DiperbaruiOleh.DefaultValue) &&
            !(DiperbaruiOleh.IsForeignKey && CurrentMasterTable != "" && SameString(DiperbaruiOleh.CurrentValue, DiperbaruiOleh.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_TanggalDiperbarui") && CurrentForm.HasValue("o_TanggalDiperbarui") && !SameString(FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern), FormatDateTime(TanggalDiperbarui.DefaultValue, TanggalDiperbarui.FormatPattern)) &&
            !(TanggalDiperbarui.IsForeignKey && CurrentMasterTable != "" && SameString(FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern), FormatDateTime(TanggalDiperbarui.SessionValue, TanggalDiperbarui.FormatPattern))))
                return false;
            return true;
        }

        // Validate grid form
        public async Task<bool> ValidateGridForm()
        {
            // Get row count
            CurrentForm?.ResetIndex();
            int rowcnt = CurrentForm?.GetInt(FormKeyCountName) ?? 0;

            // Load default values for emptyRow checking
            LoadDefaultValues();

            // Validate all records
            for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                // Load current row values
                CurrentForm!.Index = rowindex;
                string rowaction = CurrentForm.GetValue(FormActionName);
                if (rowaction != "delete" && rowaction != "insertdelete" && rowaction != "hide") {
                    await LoadFormValues(); // Get form values
                    if (rowaction == "insert" && EmptyRow()) {
                        // Ignore
                    } else if (!await ValidateForm()) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Get all form values of the grid
        public List<Dictionary<string, string?>> GetGridFormValues()
        {
            // Get row count
            CurrentForm?.ResetIndex();
            int rowcnt = CurrentForm?.GetInt(FormKeyCountName) ?? 0;
            List<Dictionary<string, string?>> rows = new();

            // Loop through all records
            for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                // Load current row values
                CurrentForm!.Index = rowindex;
                string rowaction = CurrentForm.GetValue(FormActionName);
                if (rowaction != "delete" && rowaction != "insertdelete") {
                    LoadFormValues().GetAwaiter().GetResult(); // Load form values (sync)
                    if (rowaction == "insert" && EmptyRow()) {
                        // Ignore
                    } else {
                        rows.Add(GetFormValues()); // Return row as array
                    }
                }
            }
            return rows; // Return as array of array
        }

        // Restore form values for current row
        public async Task RestoreCurrentRowFormValues(object index)
        {
            // Get row based on current index
            if (index is int idx)
                CurrentForm!.Index = idx;
            string rowaction = CurrentForm.GetValue(FormActionName);
            await LoadFormValues(); // Load form values
            // Set up invalid status correctly
            ResetFormError();
            if (rowaction == "insert" && EmptyRow()) {
                // Ignore
            } else {
                await ValidateForm();
            }
        }

        // Reset form status
        public void ResetFormError()
        {
            IdTemplate.ClearErrorMessage();
            UrutanProses.ClearErrorMessage();
            NamaProses.ClearErrorMessage();
            IdPIC.ClearErrorMessage();
            IdTools.ClearErrorMessage();
            Keterangan.ClearErrorMessage();
            DibuatOleh.ClearErrorMessage();
            TanggalDibuat.ClearErrorMessage();
            DiperbaruiOleh.ClearErrorMessage();
            TanggalDiperbarui.ClearErrorMessage();
        }

        // Set up sort parameters
        protected void SetupSortOrder() {
            // Load default Sorting Order
            if (Command != "json") {
                string defaultSort = ""; // Set up default sort
                if (Empty(SessionOrderBy) && !Empty(defaultSort))
                    SessionOrderBy = defaultSort;
            }

            // Check for "order" parameter
            if (Get("order", out StringValues sv)) {
                CurrentOrder = sv.ToString();
                CurrentOrderType = Get("ordertype");
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
                // Reset master/detail keys
                if (SameText(Command, "resetall")) {
                    CurrentMasterTable = ""; // Clear master table
                    DbMasterFilter = "";
                    DbDetailFilter = "";
                    IdTemplate.SessionValue = "";
                }

                // Reset (clear) sorting order
                if (SameText(Command, "resetsort")) {
                    string orderBy = "";
                    SessionOrderBy = orderBy;
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

            // "griddelete"
            if (AllowAddDeleteRow) {
                item = ListOptions.Add("griddelete");
                item.CssClass = "text-nowrap";
                item.OnLeft = true;
                item.Visible = false; // Default hidden
            }

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

            // "delete"
            item = ListOptions.Add("delete");
            item.CssClass = "text-nowrap";
            item.Visible = Security.CanDelete;
            item.OnLeft = true;

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

            // Set up row action and key
            if (IsNumeric(RowIndex) && RowType != RowType.View) {
                CurrentForm!.Index = ConvertToInt(RowIndex);
                var actionName = FormActionName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                var oldKeyName = OldKeyName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                var blankRowName = FormBlankRowName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                if (!Empty(RowAction))
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + actionName + "\" id=\"" + actionName + "\" value=\"" + RowAction + "\">";
                string oldKey = GetKey(false); // Get from OldValue
                if (!Empty(oldKeyName) && !Empty(oldKey)) {
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + oldKeyName + "\" id=\"" + oldKeyName + "\" value=\"" + HtmlEncode(oldKey) + "\">";
                }
                if (RowAction == "insert" && IsConfirm && EmptyRow())
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + blankRowName + "\" id=\"" + blankRowName + "\" value=\"1\">";
            }

            // "delete"
            if (AllowAddDeleteRow) {
                if (CurrentMode == "add" || CurrentMode == "copy" || CurrentMode == "edit") {
                    var options = ListOptions;
                    options.UseButtonGroup = true; // Use button group for grid delete button
                    listOption = options["griddelete"];
                    if (!Security.AllowDelete(CurrentProjectID + TableName) && IsNumeric(RowIndex) && (RowAction == "" || RowAction == "edit")) { // Do not allow delete existing record
                        listOption?.SetBody("&nbsp;");
                    } else {
                        listOption?.SetBody("<a class=\"ew-grid-link ew-grid-delete\" title=\"" + Language.Phrase("DeleteLink", true) + "\" data-caption=\"" + Language.Phrase("DeleteLink", true) + "\" data-ew-action=\"delete-grid-row\" data-rowindex=\"" + RowIndex + "\">" + Language.Phrase("DeleteLink") + "</a>");
                    }
                }
            }

            // "sequence"
            listOption = ListOptions["sequence"];
            listOption?.SetBody(FormatSequenceNumber(RecordCount));
            if (CurrentMode == "view") {
            // "view"
            listOption = ListOptions["view"];
            string viewcaption = Language.Phrase("ViewLink", true);
            isVisible = Security.CanView;
            if (isVisible) {
                if (ModalView && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-table=""TemplateProses"" data-caption=""{viewcaption}"" data-ew-action=""modal"" data-action=""view"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(ViewUrl)) + "\" data-btn=\"null\">" + Language.Phrase("ViewLink") + "</a>");
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-table=""TemplateProses"" data-caption=""{editcaption}"" data-ew-action=""modal"" data-action=""edit"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\" data-btn=\"SaveBtn\">" + Language.Phrase("EditLink") + "</a>");
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-copy"" title=""{copycaption}"" data-table=""TemplateProses"" data-caption=""{copycaption}"" data-ew-action=""modal"" data-action=""add"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(CopyUrl)) + "\" data-btn=\"AddBtn\">" + Language.Phrase("CopyLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-copy"" title=""{copycaption}"" data-caption=""{copycaption}"" href=""" + HtmlEncode(AppPath(CopyUrl)) + "\">" + Language.Phrase("CopyLink") + "</a>");
            } else {
                listOption?.Clear();
            }

            // "delete"
            listOption = ListOptions["delete"];
            isVisible = Security.CanDelete;
            if (isVisible) {
                string deleteCaption = Language.Phrase("DeleteLink");
                string deleteTitle = Language.Phrase("DeleteLink", true);
                if (UseAjaxActions)
                    listOption?.SetBody($@"<a class=""ew-row-link ew-delete"" data-ew-action=""inline"" data-action=""delete"" title=""{deleteTitle}"" data-caption=""{deleteTitle}"" data-key=""" + HtmlEncode(GetKey(true)) + "\" data-url=\"" + HtmlEncode(AppPath(DeleteUrl)) + "\">" + deleteCaption + "</a>");
                else
                    listOption?.SetBody(@"<a class=""ew-row-link ew-delete""" +
                        (InlineDelete ? @" data-ew-action=""inline-delete""" : "") +
                        $@" title=""{deleteTitle}"" data-caption=""{deleteTitle}"" href=""" + HtmlEncode(AppPath(DeleteUrl)) + "\">" + deleteCaption + "</a>");
            } else {
                listOption?.Clear();
            }
            } // End View mode
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
            option = OtherOptions["addedit"];
            option.UseDropDownButton = false;
            option.DropDownButtonPhrase = "ButtonAddEdit";
            option.UseButtonGroup = true;
            option.ButtonClass = ""; // Class for button group
            item = option.AddGroupOption();
            item.Body = "";
            item.Visible = false;

            // Add
            if (CurrentMode == "view") { // Check view mode
                item = option.Add("add");
                string addTitle = Language.Phrase("AddLink", true);
                AddUrl = GetAddUrl();
                if (ModalAdd && !IsMobile())
                    item.Body = $@"<a class=""ew-add-edit ew-add"" title=""{addTitle}"" data-table=""TemplateProses"" data-caption=""{addTitle}"" data-ew-action=""modal"" data-action=""add"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(AddUrl)) + "\" data-btn=\"AddBtn\">" + Language.Phrase("AddLink") + "</a>";
                else
                    item.Body = $@"<a class=""ew-add-edit ew-add"" title=\""{addTitle}"" data-caption=""{addTitle}"" href=""" + HtmlEncode(AppPath(AddUrl)) + "\">" + Language.Phrase("AddLink") + "</a>";
                item.Visible = (AddUrl != "" && Security.CanAdd);
            }
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
                if ((CurrentMode == "add" || CurrentMode == "copy" || CurrentMode == "edit") && !IsConfirm) { // Check add/copy/edit mode
                    if (AllowAddDeleteRow) {
                        option = options["addedit"];
                        option.UseDropDownButton = false;
                        item = option.Add("addblankrow");
                        item.Body = "<a class=\"ew-add-edit ew-add-blank-row\" title=\"" + Language.Phrase("AddBlankRow", true) + "\" data-caption=\"" + Language.Phrase("AddBlankRow", true) + "\" data-ew-action=\"add-grid-row\">" + Language.Phrase("AddBlankRow") + "</a>";
                        item.Visible = Security.CanAdd;
                        ShowOtherOptions = item.Visible;
                    }
                }
                if (CurrentMode == "view") { // Check view mode
                    option = options["addedit"];
                    item = option.GetItem("add");
                    ShowOtherOptions = !Empty(item) && item.Visible;
                }
        }

        // Set up Grid
        public async Task SetupGrid()
        {
            StartRecord = 1;
            StopRecord = TotalRecords; // Show all records

            // Restore number of post back records
            if (CurrentForm != null && (IsConfirm || EventCancelled)) {
                CurrentForm!.ResetIndex(); // DN
                if (CurrentForm!.HasValue(FormKeyCountName) && (IsGridAdd || IsGridEdit || IsConfirm)) {
                    KeyCount = CurrentForm.GetInt(FormKeyCountName);
                    StopRecord = StartRecord + KeyCount - 1;
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
                    RowAttrs.Add("id", "r0_TemplateProses");
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
            if (CurrentForm != null && (IsGridAdd || IsGridEdit || IsConfirm || IsMultiEdit)) {
                RowIndex = ConvertToInt(RowIndex) + 1;
                CurrentForm!.SetIndex(ConvertToInt(RowIndex));
                if (CurrentForm!.HasValue(FormActionName) && (IsConfirm || EventCancelled))
                    RowAction = CurrentForm.GetValue(FormActionName);
                else if (IsGridAdd)
                    RowAction = "insert";
                else
                    RowAction = "";
            }

            // Set up key count
            KeyCount = ConvertToInt(RowIndex);

            // Init row class and style
            ResetAttributes();
            CssClass = "";
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
            RowType = RowType.View; // Render view
            if ((IsAdd || IsCopy) && InlineRowCount == 0 || IsGridAdd) // Add
                RowType = RowType.Add; // Render add
            if (IsGridAdd && EventCancelled && !CurrentForm!.HasValue(FormBlankRowName)) // Insert failed
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values
            if (IsGridEdit) { // Grid edit
                if (EventCancelled)
                    await RestoreCurrentRowFormValues(RowIndex); // Restore form values
                if (RowAction == "insert")
                    RowType = RowType.Add; // Render add
                else
                    RowType = RowType.Edit; // Render edit
            }
            if (IsGridEdit && (RowType == RowType.Edit || RowType == RowType.Add) && EventCancelled) // Update failed
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values
            if (IsConfirm) // Confirm row
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values

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
            RowAttrs.Add("data-rowindex", ConvertToString(templateProsesGrid.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(templateProsesGrid.RowCount) + "_TemplateProses");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(templateProsesGrid.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && templateProsesGrid.RowType == RowType.Add || IsEdit && templateProsesGrid.RowType == RowType.Edit) // Inline-Add/Edit row
                RowAttrs.AppendClass("table-active");

            // Render row
            await RenderRow();

            // Render list options
            await RenderListOptions();
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

        // Load default values
        protected void LoadDefaultValues() {
        }

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            CurrentForm.FormName = FormName;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'IdTemplate' before field var 'x_IdTemplate'
            val = CurrentForm.HasValue("IdTemplate") ? CurrentForm.GetValue("IdTemplate") : CurrentForm.GetValue("x_IdTemplate");
            if (!IdTemplate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTemplate") && !CurrentForm.HasValue("x_IdTemplate")) // DN
                    IdTemplate.Visible = false; // Disable update for API request
                else
                    IdTemplate.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_IdTemplate"))
                IdTemplate.OldValue = CurrentForm.GetValue("o_IdTemplate");

            // Check field name 'UrutanProses' before field var 'x_UrutanProses'
            val = CurrentForm.HasValue("UrutanProses") ? CurrentForm.GetValue("UrutanProses") : CurrentForm.GetValue("x_UrutanProses");
            if (!UrutanProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UrutanProses") && !CurrentForm.HasValue("x_UrutanProses")) // DN
                    UrutanProses.Visible = false; // Disable update for API request
                else
                    UrutanProses.SetFormValue(val, true, validate);
            }
            if (CurrentForm.HasValue("o_UrutanProses"))
                UrutanProses.OldValue = CurrentForm.GetValue("o_UrutanProses");

            // Check field name 'NamaProses' before field var 'x_NamaProses'
            val = CurrentForm.HasValue("NamaProses") ? CurrentForm.GetValue("NamaProses") : CurrentForm.GetValue("x_NamaProses");
            if (!NamaProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaProses") && !CurrentForm.HasValue("x_NamaProses")) // DN
                    NamaProses.Visible = false; // Disable update for API request
                else
                    NamaProses.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_NamaProses"))
                NamaProses.OldValue = CurrentForm.GetValue("o_NamaProses");

            // Check field name 'IdPIC' before field var 'x_IdPIC'
            val = CurrentForm.HasValue("IdPIC") ? CurrentForm.GetValue("IdPIC") : CurrentForm.GetValue("x_IdPIC");
            if (!IdPIC.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPIC") && !CurrentForm.HasValue("x_IdPIC")) // DN
                    IdPIC.Visible = false; // Disable update for API request
                else
                    IdPIC.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_IdPIC"))
                IdPIC.OldValue = CurrentForm.GetValue("o_IdPIC");

            // Check field name 'IdTools' before field var 'x_IdTools'
            val = CurrentForm.HasValue("IdTools") ? CurrentForm.GetValue("IdTools") : CurrentForm.GetValue("x_IdTools");
            if (!IdTools.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTools") && !CurrentForm.HasValue("x_IdTools")) // DN
                    IdTools.Visible = false; // Disable update for API request
                else
                    IdTools.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_IdTools"))
                IdTools.OldValue = CurrentForm.GetValue("o_IdTools");

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_Keterangan"))
                Keterangan.OldValue = CurrentForm.GetValue("o_Keterangan");

            // Check field name 'DibuatOleh' before field var 'x_DibuatOleh'
            val = CurrentForm.HasValue("DibuatOleh") ? CurrentForm.GetValue("DibuatOleh") : CurrentForm.GetValue("x_DibuatOleh");
            if (!DibuatOleh.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DibuatOleh") && !CurrentForm.HasValue("x_DibuatOleh")) // DN
                    DibuatOleh.Visible = false; // Disable update for API request
                else
                    DibuatOleh.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_DibuatOleh"))
                DibuatOleh.OldValue = CurrentForm.GetValue("o_DibuatOleh");

            // Check field name 'TanggalDibuat' before field var 'x_TanggalDibuat'
            val = CurrentForm.HasValue("TanggalDibuat") ? CurrentForm.GetValue("TanggalDibuat") : CurrentForm.GetValue("x_TanggalDibuat");
            if (!TanggalDibuat.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalDibuat") && !CurrentForm.HasValue("x_TanggalDibuat")) // DN
                    TanggalDibuat.Visible = false; // Disable update for API request
                else
                    TanggalDibuat.SetFormValue(val, true, validate);
                TanggalDibuat.CurrentValue = UnformatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            }
            TanggalDibuat.OldValue = UnformatDateTime(CurrentForm.GetValue("o_TanggalDibuat"), TanggalDibuat.FormatPattern);

            // Check field name 'DiperbaruiOleh' before field var 'x_DiperbaruiOleh'
            val = CurrentForm.HasValue("DiperbaruiOleh") ? CurrentForm.GetValue("DiperbaruiOleh") : CurrentForm.GetValue("x_DiperbaruiOleh");
            if (!DiperbaruiOleh.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DiperbaruiOleh") && !CurrentForm.HasValue("x_DiperbaruiOleh")) // DN
                    DiperbaruiOleh.Visible = false; // Disable update for API request
                else
                    DiperbaruiOleh.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_DiperbaruiOleh"))
                DiperbaruiOleh.OldValue = CurrentForm.GetValue("o_DiperbaruiOleh");

            // Check field name 'TanggalDiperbarui' before field var 'x_TanggalDiperbarui'
            val = CurrentForm.HasValue("TanggalDiperbarui") ? CurrentForm.GetValue("TanggalDiperbarui") : CurrentForm.GetValue("x_TanggalDiperbarui");
            if (!TanggalDiperbarui.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalDiperbarui") && !CurrentForm.HasValue("x_TanggalDiperbarui")) // DN
                    TanggalDiperbarui.Visible = false; // Disable update for API request
                else
                    TanggalDiperbarui.SetFormValue(val, true, validate);
                TanggalDiperbarui.CurrentValue = UnformatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
            }
            TanggalDiperbarui.OldValue = UnformatDateTime(CurrentForm.GetValue("o_TanggalDiperbarui"), TanggalDiperbarui.FormatPattern);

            // Check field name 'IdTemplateProses' before field var 'x_IdTemplateProses'
            val = CurrentForm.HasValue("IdTemplateProses") ? CurrentForm.GetValue("IdTemplateProses") : CurrentForm.GetValue("x_IdTemplateProses");
            if (!IdTemplateProses.IsDetailKey && !IsGridAdd && !IsAdd)
                IdTemplateProses.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            if (!IsGridAdd && !IsAdd)
                IdTemplateProses.CurrentValue = IdTemplateProses.FormValue;
            IdTemplate.CurrentValue = IdTemplate.FormValue;
            UrutanProses.CurrentValue = UrutanProses.FormValue;
            NamaProses.CurrentValue = NamaProses.FormValue;
            IdPIC.CurrentValue = IdPIC.FormValue;
            IdTools.CurrentValue = IdTools.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            DibuatOleh.CurrentValue = DibuatOleh.FormValue;
            TanggalDibuat.CurrentValue = TanggalDibuat.FormValue;
            TanggalDibuat.CurrentValue = UnformatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            DiperbaruiOleh.CurrentValue = DiperbaruiOleh.FormValue;
            TanggalDiperbarui.CurrentValue = TanggalDiperbarui.FormValue;
            TanggalDiperbarui.CurrentValue = UnformatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
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
            IdTemplateProses.SetDbValue(row["IdTemplateProses"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            UrutanProses.SetDbValue(row["UrutanProses"]);
            NamaProses.SetDbValue(row["NamaProses"]);
            IdPIC.SetDbValue(row["IdPIC"]);
            IdTools.SetDbValue(row["IdTools"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            TipeProses.SetDbValue(row["TipeProses"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdTemplateProses", IdTemplateProses.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("UrutanProses", UrutanProses.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaProses", NamaProses.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPIC", IdPIC.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTools", IdTools.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProses", TipeProses.DefaultValue ?? DbNullValue); // DN
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

            // IdTemplateProses

            // IdTemplate

            // UrutanProses

            // NamaProses

            // IdPIC

            // IdTools

            // Keterangan

            // DibuatOleh

            // TanggalDibuat

            // DiperbaruiOleh

            // TanggalDiperbarui

            // TipeProses

            // View row
            if (RowType == RowType.View) {
                // IdTemplateProses
                IdTemplateProses.ViewValue = IdTemplateProses.CurrentValue;
                IdTemplateProses.ViewCustomAttributes = "";

                // IdTemplate
                string curVal = ConvertToString(IdTemplate.CurrentValue);
                if (!Empty(curVal)) {
                    if (IdTemplate.Lookup != null && IsDictionary(IdTemplate.Lookup?.Options) && IdTemplate.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTemplate.ViewValue = IdTemplate.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchExpression, "=", IdTemplate.CurrentValue, IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchDataType, "");
                        string? sqlWrk = IdTemplate.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdTemplate.Lookup != null) { // Lookup values found
                            var listwrk = IdTemplate.Lookup?.RenderViewRow(rswrk[0]);
                            IdTemplate.ViewValue = IdTemplate.DisplayValue(listwrk);
                        } else {
                            IdTemplate.ViewValue = FormatNumber(IdTemplate.CurrentValue, IdTemplate.FormatPattern);
                        }
                    }
                } else {
                    IdTemplate.ViewValue = DbNullValue;
                }
                IdTemplate.ViewCustomAttributes = "";

                // UrutanProses
                UrutanProses.ViewValue = UrutanProses.CurrentValue;
                UrutanProses.ViewValue = FormatNumber(UrutanProses.ViewValue, UrutanProses.FormatPattern);
                UrutanProses.ViewCustomAttributes = "";

                // NamaProses
                NamaProses.ViewValue = ConvertToString(NamaProses.CurrentValue); // DN
                NamaProses.ViewCustomAttributes = "";

                // IdPIC
                string curVal2 = ConvertToString(IdPIC.CurrentValue);
                if (!Empty(curVal2)) {
                    if (IdPIC.Lookup != null && IsDictionary(IdPIC.Lookup?.Options) && IdPIC.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPIC.ViewValue = IdPIC.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchExpression, "=", IdPIC.CurrentValue, IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchDataType, "");
                        string? sqlWrk2 = IdPIC.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && IdPIC.Lookup != null) { // Lookup values found
                            var listwrk = IdPIC.Lookup?.RenderViewRow(rswrk2[0]);
                            IdPIC.ViewValue = IdPIC.DisplayValue(listwrk);
                        } else {
                            IdPIC.ViewValue = FormatNumber(IdPIC.CurrentValue, IdPIC.FormatPattern);
                        }
                    }
                } else {
                    IdPIC.ViewValue = DbNullValue;
                }
                IdPIC.ViewCustomAttributes = "";

                // IdTools
                string curVal3 = ConvertToString(IdTools.CurrentValue);
                if (!Empty(curVal3)) {
                    if (IdTools.Lookup != null && IsDictionary(IdTools.Lookup?.Options) && IdTools.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTools.ViewValue = IdTools.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(IdTools.Lookup?.GetTable()?.Fields["IdTools"].SearchExpression, "=", IdTools.CurrentValue, IdTools.Lookup?.GetTable()?.Fields["IdTools"].SearchDataType, "");
                        string? sqlWrk3 = IdTools.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && IdTools.Lookup != null) { // Lookup values found
                            var listwrk = IdTools.Lookup?.RenderViewRow(rswrk3[0]);
                            IdTools.ViewValue = IdTools.DisplayValue(listwrk);
                        } else {
                            IdTools.ViewValue = FormatNumber(IdTools.CurrentValue, IdTools.FormatPattern);
                        }
                    }
                } else {
                    IdTools.ViewValue = DbNullValue;
                }
                IdTools.ViewCustomAttributes = "";

                // Keterangan
                Keterangan.ViewValue = Keterangan.CurrentValue;
                Keterangan.ViewCustomAttributes = "";

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

                // TipeProses
                TipeProses.ViewValue = ConvertToString(TipeProses.CurrentValue); // DN
                TipeProses.ViewCustomAttributes = "";

                // IdTemplate
                IdTemplate.HrefValue = "";
                IdTemplate.TooltipValue = "";

                // UrutanProses
                UrutanProses.HrefValue = "";
                UrutanProses.TooltipValue = "";

                // NamaProses
                NamaProses.HrefValue = "";
                NamaProses.TooltipValue = "";

                // IdPIC
                IdPIC.HrefValue = "";
                IdPIC.TooltipValue = "";

                // IdTools
                IdTools.HrefValue = "";
                IdTools.TooltipValue = "";

                // Keterangan
                Keterangan.HrefValue = "";
                Keterangan.TooltipValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";
                DibuatOleh.TooltipValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";
                TanggalDibuat.TooltipValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";
                DiperbaruiOleh.TooltipValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
                TanggalDiperbarui.TooltipValue = "";
            } else if (RowType == RowType.Add) {
                // IdTemplate
                IdTemplate.SetupEditAttributes();
                if (!Empty(IdTemplate.SessionValue)) {
                    IdTemplate.CurrentValue = ForeignKeyValue(IdTemplate.SessionValue);
                    IdTemplate.OldValue = IdTemplate.CurrentValue;
                    string curVal = ConvertToString(IdTemplate.CurrentValue);
                    if (!Empty(curVal)) {
                        if (IdTemplate.Lookup != null && IsDictionary(IdTemplate.Lookup?.Options) && IdTemplate.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            IdTemplate.ViewValue = IdTemplate.LookupCacheOption(curVal);
                        } else { // Lookup from database // DN
                            string filterWrk = SearchFilter(IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchExpression, "=", IdTemplate.CurrentValue, IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchDataType, "");
                            string? sqlWrk = IdTemplate.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                            List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk?.Count > 0 && IdTemplate.Lookup != null) { // Lookup values found
                                var listwrk = IdTemplate.Lookup?.RenderViewRow(rswrk[0]);
                                IdTemplate.ViewValue = IdTemplate.DisplayValue(listwrk);
                            } else {
                                IdTemplate.ViewValue = FormatNumber(IdTemplate.CurrentValue, IdTemplate.FormatPattern);
                            }
                        }
                    } else {
                        IdTemplate.ViewValue = DbNullValue;
                    }
                    IdTemplate.ViewCustomAttributes = "";
                } else {
                    string curVal = ConvertToString(IdTemplate.CurrentValue);
                    if (IdTemplate.Lookup != null && IsDictionary(IdTemplate.Lookup?.Options) && IdTemplate.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTemplate.EditValue = IdTemplate.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        string filterWrk = "";
                        if (curVal == "") {
                            filterWrk = "0=1";
                        } else {
                            filterWrk = SearchFilter(IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchExpression, "=", IdTemplate.CurrentValue, IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchDataType, "");
                        }
                        string? sqlWrk = IdTemplate.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        IdTemplate.EditValue = rswrk;
                    }
                    IdTemplate.PlaceHolder = RemoveHtml(IdTemplate.Caption);
                    if (!Empty(IdTemplate.EditValue) && IsNumeric(IdTemplate.EditValue))
                        IdTemplate.EditValue = FormatNumber(IdTemplate.EditValue, null);
                }

                // UrutanProses
                UrutanProses.SetupEditAttributes();
                UrutanProses.EditValue = UrutanProses.CurrentValue;
                UrutanProses.PlaceHolder = RemoveHtml(UrutanProses.Caption);
                if (!Empty(UrutanProses.EditValue) && IsNumeric(UrutanProses.EditValue)) {
                    UrutanProses.EditValue = FormatNumber(UrutanProses.EditValue, null);
                }

                // NamaProses
                NamaProses.SetupEditAttributes();
                if (!NamaProses.Raw)
                    NamaProses.CurrentValue = HtmlDecode(NamaProses.CurrentValue);
                NamaProses.EditValue = HtmlEncode(NamaProses.CurrentValue);
                NamaProses.PlaceHolder = RemoveHtml(NamaProses.Caption);

                // IdPIC
                IdPIC.SetupEditAttributes();
                string curVal2 = ConvertToString(IdPIC.CurrentValue);
                if (IdPIC.Lookup != null && IsDictionary(IdPIC.Lookup?.Options) && IdPIC.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPIC.EditValue = IdPIC.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk2 = "";
                    if (curVal2 == "") {
                        filterWrk2 = "0=1";
                    } else {
                        filterWrk2 = SearchFilter(IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchExpression, "=", IdPIC.CurrentValue, IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchDataType, "");
                    }
                    string? sqlWrk2 = IdPIC.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdPIC.EditValue = rswrk2;
                }
                IdPIC.PlaceHolder = RemoveHtml(IdPIC.Caption);
                if (!Empty(IdPIC.EditValue) && IsNumeric(IdPIC.EditValue))
                    IdPIC.EditValue = FormatNumber(IdPIC.EditValue, null);

                // IdTools
                IdTools.SetupEditAttributes();
                string curVal3 = ConvertToString(IdTools.CurrentValue);
                if (IdTools.Lookup != null && IsDictionary(IdTools.Lookup?.Options) && IdTools.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdTools.EditValue = IdTools.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk3 = "";
                    if (curVal3 == "") {
                        filterWrk3 = "0=1";
                    } else {
                        filterWrk3 = SearchFilter(IdTools.Lookup?.GetTable()?.Fields["IdTools"].SearchExpression, "=", IdTools.CurrentValue, IdTools.Lookup?.GetTable()?.Fields["IdTools"].SearchDataType, "");
                    }
                    string? sqlWrk3 = IdTools.Lookup?.GetSql(true, filterWrk3, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdTools.EditValue = rswrk3;
                }
                IdTools.PlaceHolder = RemoveHtml(IdTools.Caption);
                if (!Empty(IdTools.EditValue) && IsNumeric(IdTools.EditValue))
                    IdTools.EditValue = FormatNumber(IdTools.EditValue, null);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // DibuatOleh
                DibuatOleh.SetupEditAttributes();
                if (!DibuatOleh.Raw)
                    DibuatOleh.CurrentValue = HtmlDecode(DibuatOleh.CurrentValue);
                DibuatOleh.EditValue = HtmlEncode(DibuatOleh.CurrentValue);
                DibuatOleh.PlaceHolder = RemoveHtml(DibuatOleh.Caption);

                // TanggalDibuat
                TanggalDibuat.SetupEditAttributes();
                TanggalDibuat.EditValue = FormatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
                TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);

                // DiperbaruiOleh
                DiperbaruiOleh.SetupEditAttributes();
                if (!DiperbaruiOleh.Raw)
                    DiperbaruiOleh.CurrentValue = HtmlDecode(DiperbaruiOleh.CurrentValue);
                DiperbaruiOleh.EditValue = HtmlEncode(DiperbaruiOleh.CurrentValue);
                DiperbaruiOleh.PlaceHolder = RemoveHtml(DiperbaruiOleh.Caption);

                // TanggalDiperbarui
                TanggalDiperbarui.SetupEditAttributes();
                TanggalDiperbarui.EditValue = FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);

                // Add refer script

                // IdTemplate
                IdTemplate.HrefValue = "";

                // UrutanProses
                UrutanProses.HrefValue = "";

                // NamaProses
                NamaProses.HrefValue = "";

                // IdPIC
                IdPIC.HrefValue = "";

                // IdTools
                IdTools.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // IdTemplate
                IdTemplate.SetupEditAttributes();
                if (!Empty(IdTemplate.SessionValue)) {
                    IdTemplate.CurrentValue = ForeignKeyValue(IdTemplate.SessionValue);
                    IdTemplate.OldValue = IdTemplate.CurrentValue;
                    string curVal = ConvertToString(IdTemplate.CurrentValue);
                    if (!Empty(curVal)) {
                        if (IdTemplate.Lookup != null && IsDictionary(IdTemplate.Lookup?.Options) && IdTemplate.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            IdTemplate.ViewValue = IdTemplate.LookupCacheOption(curVal);
                        } else { // Lookup from database // DN
                            string filterWrk = SearchFilter(IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchExpression, "=", IdTemplate.CurrentValue, IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchDataType, "");
                            string? sqlWrk = IdTemplate.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                            List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk?.Count > 0 && IdTemplate.Lookup != null) { // Lookup values found
                                var listwrk = IdTemplate.Lookup?.RenderViewRow(rswrk[0]);
                                IdTemplate.ViewValue = IdTemplate.DisplayValue(listwrk);
                            } else {
                                IdTemplate.ViewValue = FormatNumber(IdTemplate.CurrentValue, IdTemplate.FormatPattern);
                            }
                        }
                    } else {
                        IdTemplate.ViewValue = DbNullValue;
                    }
                    IdTemplate.ViewCustomAttributes = "";
                } else {
                    string curVal = ConvertToString(IdTemplate.CurrentValue);
                    if (IdTemplate.Lookup != null && IsDictionary(IdTemplate.Lookup?.Options) && IdTemplate.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTemplate.EditValue = IdTemplate.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        string filterWrk = "";
                        if (curVal == "") {
                            filterWrk = "0=1";
                        } else {
                            filterWrk = SearchFilter(IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchExpression, "=", IdTemplate.CurrentValue, IdTemplate.Lookup?.GetTable()?.Fields["IdTemplate"].SearchDataType, "");
                        }
                        string? sqlWrk = IdTemplate.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        IdTemplate.EditValue = rswrk;
                    }
                    IdTemplate.PlaceHolder = RemoveHtml(IdTemplate.Caption);
                    if (!Empty(IdTemplate.EditValue) && IsNumeric(IdTemplate.EditValue))
                        IdTemplate.EditValue = FormatNumber(IdTemplate.EditValue, null);
                }

                // UrutanProses
                UrutanProses.SetupEditAttributes();
                UrutanProses.EditValue = UrutanProses.CurrentValue;
                UrutanProses.PlaceHolder = RemoveHtml(UrutanProses.Caption);
                if (!Empty(UrutanProses.EditValue) && IsNumeric(UrutanProses.EditValue)) {
                    UrutanProses.EditValue = FormatNumber(UrutanProses.EditValue, null);
                }

                // NamaProses
                NamaProses.SetupEditAttributes();
                if (!NamaProses.Raw)
                    NamaProses.CurrentValue = HtmlDecode(NamaProses.CurrentValue);
                NamaProses.EditValue = HtmlEncode(NamaProses.CurrentValue);
                NamaProses.PlaceHolder = RemoveHtml(NamaProses.Caption);

                // IdPIC
                IdPIC.SetupEditAttributes();
                string curVal2 = ConvertToString(IdPIC.CurrentValue);
                if (IdPIC.Lookup != null && IsDictionary(IdPIC.Lookup?.Options) && IdPIC.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPIC.EditValue = IdPIC.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk2 = "";
                    if (curVal2 == "") {
                        filterWrk2 = "0=1";
                    } else {
                        filterWrk2 = SearchFilter(IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchExpression, "=", IdPIC.CurrentValue, IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchDataType, "");
                    }
                    string? sqlWrk2 = IdPIC.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdPIC.EditValue = rswrk2;
                }
                IdPIC.PlaceHolder = RemoveHtml(IdPIC.Caption);
                if (!Empty(IdPIC.EditValue) && IsNumeric(IdPIC.EditValue))
                    IdPIC.EditValue = FormatNumber(IdPIC.EditValue, null);

                // IdTools
                IdTools.SetupEditAttributes();
                string curVal3 = ConvertToString(IdTools.CurrentValue);
                if (IdTools.Lookup != null && IsDictionary(IdTools.Lookup?.Options) && IdTools.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdTools.EditValue = IdTools.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk3 = "";
                    if (curVal3 == "") {
                        filterWrk3 = "0=1";
                    } else {
                        filterWrk3 = SearchFilter(IdTools.Lookup?.GetTable()?.Fields["IdTools"].SearchExpression, "=", IdTools.CurrentValue, IdTools.Lookup?.GetTable()?.Fields["IdTools"].SearchDataType, "");
                    }
                    string? sqlWrk3 = IdTools.Lookup?.GetSql(true, filterWrk3, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdTools.EditValue = rswrk3;
                }
                IdTools.PlaceHolder = RemoveHtml(IdTools.Caption);
                if (!Empty(IdTools.EditValue) && IsNumeric(IdTools.EditValue))
                    IdTools.EditValue = FormatNumber(IdTools.EditValue, null);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // DibuatOleh
                DibuatOleh.SetupEditAttributes();
                if (!DibuatOleh.Raw)
                    DibuatOleh.CurrentValue = HtmlDecode(DibuatOleh.CurrentValue);
                DibuatOleh.EditValue = HtmlEncode(DibuatOleh.CurrentValue);
                DibuatOleh.PlaceHolder = RemoveHtml(DibuatOleh.Caption);

                // TanggalDibuat
                TanggalDibuat.SetupEditAttributes();
                TanggalDibuat.EditValue = FormatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
                TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);

                // DiperbaruiOleh
                DiperbaruiOleh.SetupEditAttributes();
                if (!DiperbaruiOleh.Raw)
                    DiperbaruiOleh.CurrentValue = HtmlDecode(DiperbaruiOleh.CurrentValue);
                DiperbaruiOleh.EditValue = HtmlEncode(DiperbaruiOleh.CurrentValue);
                DiperbaruiOleh.PlaceHolder = RemoveHtml(DiperbaruiOleh.Caption);

                // TanggalDiperbarui
                TanggalDiperbarui.SetupEditAttributes();
                TanggalDiperbarui.EditValue = FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);

                // Edit refer script

                // IdTemplate
                IdTemplate.HrefValue = "";

                // UrutanProses
                UrutanProses.HrefValue = "";

                // NamaProses
                NamaProses.HrefValue = "";

                // IdPIC
                IdPIC.HrefValue = "";

                // IdTools
                IdTools.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                if (IdTemplate.Visible && IdTemplate.Required) {
                    if (!IdTemplate.IsDetailKey && Empty(IdTemplate.FormValue)) {
                        IdTemplate.AddErrorMessage(ConvertToString(IdTemplate.RequiredErrorMessage).Replace("%s", IdTemplate.Caption));
                    }
                }
                if (UrutanProses.Visible && UrutanProses.Required) {
                    if (!UrutanProses.IsDetailKey && Empty(UrutanProses.FormValue)) {
                        UrutanProses.AddErrorMessage(ConvertToString(UrutanProses.RequiredErrorMessage).Replace("%s", UrutanProses.Caption));
                    }
                }
                if (!CheckInteger(UrutanProses.FormValue)) {
                    UrutanProses.AddErrorMessage(UrutanProses.GetErrorMessage(false));
                }
                if (NamaProses.Visible && NamaProses.Required) {
                    if (!NamaProses.IsDetailKey && Empty(NamaProses.FormValue)) {
                        NamaProses.AddErrorMessage(ConvertToString(NamaProses.RequiredErrorMessage).Replace("%s", NamaProses.Caption));
                    }
                }
                if (IdPIC.Visible && IdPIC.Required) {
                    if (!IdPIC.IsDetailKey && Empty(IdPIC.FormValue)) {
                        IdPIC.AddErrorMessage(ConvertToString(IdPIC.RequiredErrorMessage).Replace("%s", IdPIC.Caption));
                    }
                }
                if (IdTools.Visible && IdTools.Required) {
                    if (!IdTools.IsDetailKey && Empty(IdTools.FormValue)) {
                        IdTools.AddErrorMessage(ConvertToString(IdTools.RequiredErrorMessage).Replace("%s", IdTools.Caption));
                    }
                }
                if (Keterangan.Visible && Keterangan.Required) {
                    if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                        Keterangan.AddErrorMessage(ConvertToString(Keterangan.RequiredErrorMessage).Replace("%s", Keterangan.Caption));
                    }
                }
                if (DibuatOleh.Visible && DibuatOleh.Required) {
                    if (!DibuatOleh.IsDetailKey && Empty(DibuatOleh.FormValue)) {
                        DibuatOleh.AddErrorMessage(ConvertToString(DibuatOleh.RequiredErrorMessage).Replace("%s", DibuatOleh.Caption));
                    }
                }
                if (TanggalDibuat.Visible && TanggalDibuat.Required) {
                    if (!TanggalDibuat.IsDetailKey && Empty(TanggalDibuat.FormValue)) {
                        TanggalDibuat.AddErrorMessage(ConvertToString(TanggalDibuat.RequiredErrorMessage).Replace("%s", TanggalDibuat.Caption));
                    }
                }
                if (!CheckDate(TanggalDibuat.FormValue, TanggalDibuat.FormatPattern)) {
                    TanggalDibuat.AddErrorMessage(TanggalDibuat.GetErrorMessage(false));
                }
                if (DiperbaruiOleh.Visible && DiperbaruiOleh.Required) {
                    if (!DiperbaruiOleh.IsDetailKey && Empty(DiperbaruiOleh.FormValue)) {
                        DiperbaruiOleh.AddErrorMessage(ConvertToString(DiperbaruiOleh.RequiredErrorMessage).Replace("%s", DiperbaruiOleh.Caption));
                    }
                }
                if (TanggalDiperbarui.Visible && TanggalDiperbarui.Required) {
                    if (!TanggalDiperbarui.IsDetailKey && Empty(TanggalDiperbarui.FormValue)) {
                        TanggalDiperbarui.AddErrorMessage(ConvertToString(TanggalDiperbarui.RequiredErrorMessage).Replace("%s", TanggalDiperbarui.Caption));
                    }
                }
                if (!CheckDate(TanggalDiperbarui.FormValue, TanggalDiperbarui.FormatPattern)) {
                    TanggalDiperbarui.AddErrorMessage(TanggalDiperbarui.GetErrorMessage(false));
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

        // Delete records (based on current filter)
        protected async Task<JsonBoolResult> DeleteRows() { // DN
            if (!Security.CanDelete) {
                FailureMessage = Language.Phrase("NoDeletePermission"); // No delete permission
                return JsonBoolResult.FalseResult; // No delete permission
            }
            List<Dictionary<string, object>> oldRows;
            bool result = true;
            try {
                string sql = CurrentSql;
                oldRows = await Connection.GetRowsAsync(sql);
                if (oldRows.Count() == 0) {
                    FailureMessage = Language.Phrase("NoRecord"); // No record found
                    return JsonBoolResult.FalseResult;
                }
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }
            List<string> successKeys = [], failKeys = [];
            try {
                // Call Row Deleting event
                if (result) {
                    foreach (var row in oldRows)
                        result = result && RowDeleting(row);
                }
                if (result) {
                    foreach (var row in oldRows) {
                        try {
                            result = await DeleteAsync(row) > 0;
                        } catch (Exception e) {
                            if (Config.Debug)
                                throw;
                            FailureMessage = e.Message; // Set up error message
                            result = false;
                        }
                        if (!result) {
                            if (UseTransaction) {
                                successKeys.Clear();
                                break;
                            }
                            failKeys.Add(GetKey(row)); // DN
                        } else {
                            if (Config.DeleteUploadFiles)
                                DeleteUploadedFiles(row);
                            RowDeleted(row);
                            successKeys.Add(GetKey(row)); // DN
                        }
                    }
                }
                result = successKeys.Count > 0;
                if (!result) {
                    // Set up error message
                    if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                        // Use the message, do nothing
                    } else if (!Empty(CancelMessage)) {
                        FailureMessage = CancelMessage;
                        CancelMessage = "";
                    } else {
                        FailureMessage = Language.Phrase("DeleteCancelled");
                    }
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                result = false;
            }

            // Write JSON for API request
            Dictionary<string, object> d = new();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                string table = TableVar;
                d.Add(table, RouteValues.Count > 2 && oldRows.Count == 1 ? oldRows[0] : oldRows); // If single-delete, route values are controller/action/id (count > 2)
                d.Add("action", Config.ApiDeleteAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, true);
            }
            return new JsonBoolResult(d, result);
        }

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
            bool validMasterRecord;
            object keyValue;
            object? v;
            string? masterFilter;
            Dictionary<string, object?> detailKeys;

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

            // IdTemplate
            if (!Empty(IdTemplate.SessionValue))
                IdTemplate.ReadOnly = true;
            IdTemplate.SetDbValue(rsnew, IdTemplate.CurrentValue, IdTemplate.ReadOnly);

            // UrutanProses
            UrutanProses.SetDbValue(rsnew, UrutanProses.CurrentValue, UrutanProses.ReadOnly);

            // NamaProses
            NamaProses.SetDbValue(rsnew, NamaProses.CurrentValue, NamaProses.ReadOnly);

            // IdPIC
            IdPIC.SetDbValue(rsnew, IdPIC.CurrentValue, IdPIC.ReadOnly);

            // IdTools
            IdTools.SetDbValue(rsnew, IdTools.CurrentValue, IdTools.ReadOnly);

            // Keterangan
            Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue, Keterangan.ReadOnly);

            // DibuatOleh
            DibuatOleh.SetDbValue(rsnew, DibuatOleh.CurrentValue, DibuatOleh.ReadOnly);

            // TanggalDibuat
            TanggalDibuat.SetDbValue(rsnew, ConvertToDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern), TanggalDibuat.ReadOnly);

            // DiperbaruiOleh
            DiperbaruiOleh.SetDbValue(rsnew, DiperbaruiOleh.CurrentValue, DiperbaruiOleh.ReadOnly);

            // TanggalDiperbarui
            TanggalDiperbarui.SetDbValue(rsnew, ConvertToDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern), TanggalDiperbarui.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("IdTemplate", out value)) // IdTemplate
                IdTemplate.CurrentValue = value;
            if (row.TryGetValue("UrutanProses", out value)) // UrutanProses
                UrutanProses.CurrentValue = value;
            if (row.TryGetValue("NamaProses", out value)) // NamaProses
                NamaProses.CurrentValue = value;
            if (row.TryGetValue("IdPIC", out value)) // IdPIC
                IdPIC.CurrentValue = value;
            if (row.TryGetValue("IdTools", out value)) // IdTools
                IdTools.CurrentValue = value;
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.CurrentValue = value;
            if (row.TryGetValue("DibuatOleh", out value)) // DibuatOleh
                DibuatOleh.CurrentValue = value;
            if (row.TryGetValue("TanggalDibuat", out value)) // TanggalDibuat
                TanggalDibuat.CurrentValue = value;
            if (row.TryGetValue("DiperbaruiOleh", out value)) // DiperbaruiOleh
                DiperbaruiOleh.CurrentValue = value;
            if (row.TryGetValue("TanggalDiperbarui", out value)) // TanggalDiperbarui
                TanggalDiperbarui.CurrentValue = value;
        }

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Set up foreign key field value from Session
            if (CurrentMasterTable == "MasterTemplate") {
                IdTemplate.Visible = true; // Need to insert foreign key
                IdTemplate.CurrentValue = IdTemplate.SessionValue;
            }

            // Get new row
            Dictionary<string, object> rsnew = GetAddRow();
            if (rsnew.Count == 0)
                return JsonBoolResult.FalseResult;

            // Update current values
            SetCurrentValues(rsnew);
            string? masterFilter;
            Dictionary<string, object?> detailKeys;
            bool validMasterRecord;

            // Load db values from rsold
            LoadDbValues(rsold);

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["IdTemplateProses"] = IdTemplateProses.CurrentValue!;
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    result = false;
                }
            } else {
                if (SuccessMessage != "" || FailureMessage != "") {
                    // Use the message, do nothing
                } else if (CancelMessage != "") {
                    FailureMessage = CancelMessage;
                    CancelMessage = "";
                } else {
                    FailureMessage = Language.Phrase("InsertCancelled");
                }
                result = false;
            }

            // Call Row Inserted event
            if (result)
                RowInserted(rsold, rsnew);

            // Write JSON for API request
            Dictionary<string, object> d = new();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                if (GetRecordFromDictionary(rsnew) is var row && row != null) {
                    string table = TableVar;
                    d.Add(table, row);
                }
                d.Add("action", Config.ApiAddAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, result);
            }
            return new JsonBoolResult(d, result);
        }

        /// <summary>
        /// Get add row
        /// </summary>
        /// <returns>New row</returns>
        protected Dictionary<string, object> GetAddRow()
        {
            try {
                Dictionary<string, object> rsnew = new();

                // IdTemplate
                IdTemplate.SetDbValue(rsnew, IdTemplate.CurrentValue);

                // UrutanProses
                UrutanProses.SetDbValue(rsnew, UrutanProses.CurrentValue);

                // NamaProses
                NamaProses.SetDbValue(rsnew, NamaProses.CurrentValue);

                // IdPIC
                IdPIC.SetDbValue(rsnew, IdPIC.CurrentValue);

                // IdTools
                IdTools.SetDbValue(rsnew, IdTools.CurrentValue);

                // Keterangan
                Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue);

                // DibuatOleh
                DibuatOleh.SetDbValue(rsnew, DibuatOleh.CurrentValue);

                // TanggalDibuat
                TanggalDibuat.SetDbValue(rsnew, ConvertToDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern), Empty(TanggalDibuat.CurrentValue));

                // DiperbaruiOleh
                DiperbaruiOleh.SetDbValue(rsnew, DiperbaruiOleh.CurrentValue);

                // TanggalDiperbarui
                TanggalDiperbarui.SetDbValue(rsnew, ConvertToDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern));
                return rsnew;
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return new();
            }
        }

        /// <summary>
        /// Restore add form from row
        /// </summary>
        /// <param name="row">Current row</param>
        private void RestoreAddFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("IdTemplate", out value)) // IdTemplate
                IdTemplate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("UrutanProses", out value)) // UrutanProses
                UrutanProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NamaProses", out value)) // NamaProses
                NamaProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdPIC", out value)) // IdPIC
                IdPIC.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdTools", out value)) // IdTools
                IdTools.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DibuatOleh", out value)) // DibuatOleh
                DibuatOleh.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalDibuat", out value)) // TanggalDibuat
                TanggalDibuat.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DiperbaruiOleh", out value)) // DiperbaruiOleh
                DiperbaruiOleh.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalDiperbarui", out value)) // TanggalDiperbarui
                TanggalDiperbarui.SetFormValue(ConvertToString(value));
        }

        // Set up master/detail based on QueryString
        protected void SetupMasterParms() {
            // Hide foreign keys
            string masterTblVar = CurrentMasterTable;
            if (masterTblVar == "MasterTemplate") {
                IdTemplate.Visible = false;

                //if (masterTemplate.EventCancelled) EventCancelled = true;
                if (Get<bool>("mastereventcancelled"))
                    EventCancelled = true;
            }
            DbMasterFilter = MasterFilterFromSession; // Get master filter from session
            DbDetailFilter = DetailFilterFromSession; // Get detail filter from session
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
