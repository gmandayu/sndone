namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterPipaView
    /// </summary>
    public static MasterPipaView masterPipaView
    {
        get => HttpData.Get<MasterPipaView>("masterPipaView")!;
        set => HttpData["masterPipaView"] = value;
    }

    /// <summary>
    /// Page class for MasterPipa
    /// </summary>
    public class MasterPipaView : MasterPipaViewBase
    {
        // Constructor
        public MasterPipaView(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterPipaView() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            idPlantAsal.DisplayValueSeparator = " - ";
            idPlantTujuan.DisplayValueSeparator = " - ";
            idPlantTujuan2.DisplayValueSeparator = " - ";
            idPlantTujuan3.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MasterPipaViewBase : MasterPipa
    {
        // Page ID
        public string PageID = "view";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterPipaView";

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
        public MasterPipaViewBase()
        {
            TableName = "MasterPipa";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-view-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterPipa)
            if (masterPipa == null || masterPipa is MasterPipa)
                masterPipa = this;

            // DN
            string[] keys = new string[0];
            StringValues str = "";
            object? obj = null;
            string currentPageName = CurrentPageName();
            string currentUrl = AppPath(currentPageName); // DN
            if (IsApi()) {
                if (RouteValues.TryGetValue("key", out object? k) && !Empty(k))
                    keys = ConvertToString(k).Split('/');
                if (keys.Length > 0)
                    RecordKeys["id"] = keys[0];
            } else {
                RecordKeys["id"] = RouteValues.TryGetValue("id", out obj) && obj != null ? UrlDecode(obj) : Get("id"); // DN
            }

            // Start time
            StartTime = Environment.TickCount;

            // Debug message
            LoadDebugMessage();

            // Open connection
            Conn = Connection; // DN

            // Other options
            OtherOptions["detail"] = new() { TagClassName = "ew-detail-option" };
            OtherOptions["action"] = new() { TagClassName = "ew-action-option" };
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
        public string PageName => "MasterPipaView";

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
            id.SetVisibility();
            KeteranganPipa.SetVisibility();
            idPlantAsal.SetVisibility();
            idPlantTujuan.SetVisibility();
            Panjang.SetVisibility();
            Diameter.SetVisibility();
            Volume.SetVisibility();
            Flowrate.SetVisibility();
            idPlantTujuan2.SetVisibility();
            Panjang2.SetVisibility();
            Diameter2.SetVisibility();
            Volume2.SetVisibility();
            Flowrate2.SetVisibility();
            idPlantTujuan3.SetVisibility();
            Panjang3.SetVisibility();
            Diameter3.SetVisibility();
            Volume3.SetVisibility();
            Flowrate3.SetVisibility();
            BiayaProject.SetVisibility();
            PlantAsal.SetVisibility();
            NamaPlantAsal.SetVisibility();
            PlantTujuan.SetVisibility();
            NamaPlantTujuan.SetVisibility();
            PlantTujuan2.SetVisibility();
            NamaPlantTujuan2.SetVisibility();
            PlantTujuan3.SetVisibility();
            NamaPlantTujuan3.SetVisibility();
            CreatedBy.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            LastUpdatedDate.SetVisibility();
        }

        // Constructor
        public MasterPipaViewBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "MasterPipaView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("id") ? dict["id"] : id.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                id.Visible = false;
        }

        public int DisplayRecords = 1; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public int RecordCount;

        public Dictionary<string, string> RecordKeys = new();

        public bool IsModal = false;

        public string SearchWhere = "";

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public bool MasterRecordExists;

        public DbDataReader? Recordset = null;

        #pragma warning disable 168, 219
        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
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

            // Set up lookup cache
            await SetupLookupOptions(idPlantAsal);
            await SetupLookupOptions(idPlantTujuan);
            await SetupLookupOptions(idPlantTujuan2);
            await SetupLookupOptions(idPlantTujuan3);

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;

            // Load current record
            bool loadCurrentRecord = false;
            string returnUrl = "";
            bool matchRecord = false;
            string[] keyValues = {};
            object? v;
            StringValues sv;
            if (IsApi()) {
                if (RouteValues.TryGetValue(Config.ApiKeyName, out object? k)) {
                    if (!Empty(k))
                        keyValues = ConvertToString(k).Split('/');
                } else { // Get key from query string
                    string key = Get(Config.ApiKeyName);
                    if (!Empty(key))
                        keyValues = key.Split(',');
                }
                if (keyValues.Length == 0)
                    return new JsonBoolResult(false, Language.Phrase("NoRecord"));
            }
            if (RouteValues.TryGetValue("id", out v) && !Empty(v)) { // DN
                id.QueryValue = UrlDecode(v); // DN
                RecordKeys["id"] = id.QueryValue;
            } else if (Get("id", out sv)) {
                id.QueryValue = sv.ToString();
                RecordKeys["id"] = id.QueryValue;
            } else if (IsApi() && !Empty(keyValues)) {
                id.QueryValue = ConvertToString(keyValues[0]);
                RecordKeys["id"] = id.QueryValue;
            } else if (!loadCurrentRecord) {
                returnUrl = "MasterPipaList"; // Return to list
            }

            // Get action
            CurrentAction = "show"; // Display form
            switch (CurrentAction) {
                case "show": // Get a record to display
                        bool res;
                        if (IsApi()) {
                            string filter = GetRecordFilter();
                            CurrentFilter = filter;
                            string sql = CurrentSql;
                            var conn = await GetConnectionAsync();
                            Recordset = await conn.ExecuteReaderAsync(sql);
                            res = !Empty(Recordset) && await Recordset.ReadAsync();
                        } else {
                            res = await LoadRow();
                        }
                        if (!res) { // Load record based on key
                            if (Empty(SuccessMessage) && Empty(FailureMessage))
                                FailureMessage = Language.Phrase("NoRecord"); // Set no record message
                            if (IsApi()) {
                                if (!Empty(SuccessMessage))
                                    return new JsonBoolResult(true, SuccessMessage);
                                else
                                    return new JsonBoolResult(false, FailureMessage);
                            } else {
                                return Terminate("MasterPipaList"); // Return to list page
                            }
                        }
                    break;
            }
            if (!Empty(returnUrl))
                return Terminate(returnUrl);

            // Render row
            RowType = RowType.View;
            ResetAttributes();
            await RenderRow();

            // Setup export options
            SetupExportOptions();

            // Set up Breadcrumb
            if (!IsExport())
                SetupBreadcrumb();

            // Normal return
            if (IsApi()) // Get current record only
                if (!IsExport())
                    return Controller.Json(new { success = true, TableVar = await GetRecordFromRecordset(Recordset), version = Config.ProductVersion });

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();
                PageRenderingEventHandler?.Invoke(this, EventArgs.Empty);

                // Page Render event
                masterPipaView?.PageRender();
            }
            return PageResult();
        }
        #pragma warning restore 168, 219

        // Set up other options
        #pragma warning disable 168, 219

        public void SetupOtherOptions()
        {
            var options = OtherOptions;
            var option = options["action"];
            ListOption item;
            string links = "";

            // Add
            item = option.Add("add");
            string addTitle = Language.Phrase("ViewPageAddLink", true);
            if (IsModal) // Modal
                item.Body = "<a class=\"ew-action ew-add\" title=\"" + addTitle + "\" data-caption=\"" + addTitle + "\" data-ew-action=\"modal\" data-url=\"" + HtmlEncode(AppPath(AddUrl)) + "\">" + Language.Phrase("ViewPageAddLink") + "</a>";
            else
                item.Body = "<a class=\"ew-action ew-add\" title=\"" + addTitle + "\" data-caption=\"" + addTitle + "\" href=\"" + HtmlEncode(AppPath(AddUrl)) + "\">" + Language.Phrase("ViewPageAddLink") + "</a>";
                item.Visible = AddUrl != "" && Security.CanAdd;

            // Edit
            item = option.Add("edit");
            var editTitle = Language.Phrase("ViewPageEditLink", true);
            if (IsModal) // Modal
                item.Body = "<a class=\"ew-action ew-edit\" title=\"" + editTitle + "\" data-caption=\"" + editTitle + "\" data-ew-action=\"modal\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("ViewPageEditLink") + "</a>";
            else
                item.Body = "<a class=\"ew-action ew-edit\" title=\"" + editTitle + "\" data-caption=\"" + editTitle + "\" href=\"" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("ViewPageEditLink") + "</a>";
                item.Visible = EditUrl != "" && Security.CanEdit;

            // Copy
            item = option.Add("copy");
            var copyTitle = Language.Phrase("ViewPageCopyLink", true);
            if (IsModal) // Modal
                item.Body = "<a class=\"ew-action ew-copy\" title=\"" + copyTitle + "\" data-caption=\"" + copyTitle + "\" data-ew-action=\"modal\" data-url=\"" + HtmlEncode(AppPath(CopyUrl)) + "\" data-btn=\"AddBtn\">" + Language.Phrase("ViewPageCopyLink") + "</a>";
            else
                item.Body = "<a class=\"ew-action ew-copy\" title=\"" + copyTitle + "\" data-caption=\"" + copyTitle + "\" href=\"" + HtmlEncode(AppPath(CopyUrl)) + "\">" + Language.Phrase("ViewPageCopyLink") + "</a>";
                item.Visible = CopyUrl != "" && Security.CanAdd;

            // Delete
            item = option.Add("delete");
            string url = AppPath(DeleteUrl);
            item.Body = "<a class=\"ew-action ew-delete\"" +
                (InlineDelete || IsModal ? " data-ew-action=\"inline-delete\"" : "") +
                " title=\"" + Language.Phrase("ViewPageDeleteLink", true) + "\" data-caption=\"" + Language.Phrase("ViewPageDeleteLink", true) +
                "\" href=\"" + HtmlEncode(url) + "\">" + Language.Phrase("ViewPageDeleteLink") + "</a>";
            item.Visible = DeleteUrl != "" && Security.CanDelete;

            // Set up action default
            option = options["action"];
            option.DropDownButtonPhrase = "ButtonActions";
            option.UseDropDownButton = !IsJsonResponse() && true;
            option.UseButtonGroup = true;
            item = option.AddGroupOption();
            item.Body = "";
            item.Visible = false;
        }
        #pragma warning restore 168, 219

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
            KeteranganPipa.SetDbValue(row["KeteranganPipa"]);
            idPlantAsal.SetDbValue(row["idPlantAsal"]);
            idPlantTujuan.SetDbValue(row["idPlantTujuan"]);
            Panjang.SetDbValue(IsNull(row["Panjang"]) ? DbNullValue : ConvertToDouble(row["Panjang"]));
            Diameter.SetDbValue(IsNull(row["Diameter"]) ? DbNullValue : ConvertToDouble(row["Diameter"]));
            Volume.SetDbValue(IsNull(row["Volume"]) ? DbNullValue : ConvertToDouble(row["Volume"]));
            Flowrate.SetDbValue(IsNull(row["Flowrate"]) ? DbNullValue : ConvertToDouble(row["Flowrate"]));
            idPlantTujuan2.SetDbValue(row["idPlantTujuan2"]);
            Panjang2.SetDbValue(IsNull(row["Panjang2"]) ? DbNullValue : ConvertToDouble(row["Panjang2"]));
            Diameter2.SetDbValue(IsNull(row["Diameter2"]) ? DbNullValue : ConvertToDouble(row["Diameter2"]));
            Volume2.SetDbValue(IsNull(row["Volume2"]) ? DbNullValue : ConvertToDouble(row["Volume2"]));
            Flowrate2.SetDbValue(IsNull(row["Flowrate2"]) ? DbNullValue : ConvertToDouble(row["Flowrate2"]));
            idPlantTujuan3.SetDbValue(row["idPlantTujuan3"]);
            Panjang3.SetDbValue(IsNull(row["Panjang3"]) ? DbNullValue : ConvertToDouble(row["Panjang3"]));
            Diameter3.SetDbValue(IsNull(row["Diameter3"]) ? DbNullValue : ConvertToDouble(row["Diameter3"]));
            Volume3.SetDbValue(IsNull(row["Volume3"]) ? DbNullValue : ConvertToDouble(row["Volume3"]));
            Flowrate3.SetDbValue(IsNull(row["Flowrate3"]) ? DbNullValue : ConvertToDouble(row["Flowrate3"]));
            BiayaProject.SetDbValue(IsNull(row["BiayaProject"]) ? DbNullValue : ConvertToDouble(row["BiayaProject"]));
            PlantAsal.SetDbValue(row["PlantAsal"]);
            NamaPlantAsal.SetDbValue(row["NamaPlantAsal"]);
            PlantTujuan.SetDbValue(row["PlantTujuan"]);
            NamaPlantTujuan.SetDbValue(row["NamaPlantTujuan"]);
            PlantTujuan2.SetDbValue(row["PlantTujuan2"]);
            NamaPlantTujuan2.SetDbValue(row["NamaPlantTujuan2"]);
            PlantTujuan3.SetDbValue(row["PlantTujuan3"]);
            NamaPlantTujuan3.SetDbValue(row["NamaPlantTujuan3"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDate.SetDbValue(row["LastUpdatedDate"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("KeteranganPipa", KeteranganPipa.DefaultValue ?? DbNullValue); // DN
            row.Add("idPlantAsal", idPlantAsal.DefaultValue ?? DbNullValue); // DN
            row.Add("idPlantTujuan", idPlantTujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("Panjang", Panjang.DefaultValue ?? DbNullValue); // DN
            row.Add("Diameter", Diameter.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume", Volume.DefaultValue ?? DbNullValue); // DN
            row.Add("Flowrate", Flowrate.DefaultValue ?? DbNullValue); // DN
            row.Add("idPlantTujuan2", idPlantTujuan2.DefaultValue ?? DbNullValue); // DN
            row.Add("Panjang2", Panjang2.DefaultValue ?? DbNullValue); // DN
            row.Add("Diameter2", Diameter2.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume2", Volume2.DefaultValue ?? DbNullValue); // DN
            row.Add("Flowrate2", Flowrate2.DefaultValue ?? DbNullValue); // DN
            row.Add("idPlantTujuan3", idPlantTujuan3.DefaultValue ?? DbNullValue); // DN
            row.Add("Panjang3", Panjang3.DefaultValue ?? DbNullValue); // DN
            row.Add("Diameter3", Diameter3.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume3", Volume3.DefaultValue ?? DbNullValue); // DN
            row.Add("Flowrate3", Flowrate3.DefaultValue ?? DbNullValue); // DN
            row.Add("BiayaProject", BiayaProject.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantAsal", PlantAsal.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaPlantAsal", NamaPlantAsal.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantTujuan", PlantTujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaPlantTujuan", NamaPlantTujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantTujuan2", PlantTujuan2.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaPlantTujuan2", NamaPlantTujuan2.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantTujuan3", PlantTujuan3.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaPlantTujuan3", NamaPlantTujuan3.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDate", LastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            SetupOtherOptions();

            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // id

            // KeteranganPipa

            // idPlantAsal

            // idPlantTujuan

            // Panjang

            // Diameter

            // Volume

            // Flowrate

            // idPlantTujuan2

            // Panjang2

            // Diameter2

            // Volume2

            // Flowrate2

            // idPlantTujuan3

            // Panjang3

            // Diameter3

            // Volume3

            // Flowrate3

            // BiayaProject

            // PlantAsal

            // NamaPlantAsal

            // PlantTujuan

            // NamaPlantTujuan

            // PlantTujuan2

            // NamaPlantTujuan2

            // PlantTujuan3

            // NamaPlantTujuan3

            // CreatedBy

            // etlDate

            // LastUpdatedBy

            // LastUpdatedDate

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // KeteranganPipa
                KeteranganPipa.ViewValue = ConvertToString(KeteranganPipa.CurrentValue); // DN
                KeteranganPipa.ViewCustomAttributes = "";

                // idPlantAsal
                string curVal = ConvertToString(idPlantAsal.CurrentValue);
                if (!Empty(curVal)) {
                    if (idPlantAsal.Lookup != null && IsDictionary(idPlantAsal.Lookup?.Options) && idPlantAsal.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idPlantAsal.ViewValue = idPlantAsal.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idPlantAsal.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantAsal.CurrentValue, idPlantAsal.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk = idPlantAsal.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idPlantAsal.Lookup != null) { // Lookup values found
                            var listwrk = idPlantAsal.Lookup?.RenderViewRow(rswrk[0]);
                            idPlantAsal.ViewValue = idPlantAsal.DisplayValue(listwrk);
                        } else {
                            idPlantAsal.ViewValue = FormatNumber(idPlantAsal.CurrentValue, idPlantAsal.FormatPattern);
                        }
                    }
                } else {
                    idPlantAsal.ViewValue = DbNullValue;
                }
                idPlantAsal.ViewCustomAttributes = "";

                // idPlantTujuan
                string curVal2 = ConvertToString(idPlantTujuan.CurrentValue);
                if (!Empty(curVal2)) {
                    if (idPlantTujuan.Lookup != null && IsDictionary(idPlantTujuan.Lookup?.Options) && idPlantTujuan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idPlantTujuan.ViewValue = idPlantTujuan.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idPlantTujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan.CurrentValue, idPlantTujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = idPlantTujuan.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idPlantTujuan.Lookup != null) { // Lookup values found
                            var listwrk = idPlantTujuan.Lookup?.RenderViewRow(rswrk2[0]);
                            idPlantTujuan.ViewValue = idPlantTujuan.DisplayValue(listwrk);
                        } else {
                            idPlantTujuan.ViewValue = FormatNumber(idPlantTujuan.CurrentValue, idPlantTujuan.FormatPattern);
                        }
                    }
                } else {
                    idPlantTujuan.ViewValue = DbNullValue;
                }
                idPlantTujuan.ViewCustomAttributes = "";

                // Panjang
                Panjang.ViewValue = Panjang.CurrentValue;
                Panjang.ViewValue = FormatNumber(Panjang.ViewValue, Panjang.FormatPattern);
                Panjang.ViewCustomAttributes = "";

                // Diameter
                Diameter.ViewValue = Diameter.CurrentValue;
                Diameter.ViewValue = FormatNumber(Diameter.ViewValue, Diameter.FormatPattern);
                Diameter.ViewCustomAttributes = "";

                // Volume
                Volume.ViewValue = Volume.CurrentValue;
                Volume.ViewValue = FormatNumber(Volume.ViewValue, Volume.FormatPattern);
                Volume.ViewCustomAttributes = "";

                // Flowrate
                Flowrate.ViewValue = Flowrate.CurrentValue;
                Flowrate.ViewValue = FormatNumber(Flowrate.ViewValue, Flowrate.FormatPattern);
                Flowrate.ViewCustomAttributes = "";

                // idPlantTujuan2
                string curVal3 = ConvertToString(idPlantTujuan2.CurrentValue);
                if (!Empty(curVal3)) {
                    if (idPlantTujuan2.Lookup != null && IsDictionary(idPlantTujuan2.Lookup?.Options) && idPlantTujuan2.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idPlantTujuan2.ViewValue = idPlantTujuan2.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(idPlantTujuan2.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan2.CurrentValue, idPlantTujuan2.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk3 = idPlantTujuan2.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && idPlantTujuan2.Lookup != null) { // Lookup values found
                            var listwrk = idPlantTujuan2.Lookup?.RenderViewRow(rswrk3[0]);
                            idPlantTujuan2.ViewValue = idPlantTujuan2.DisplayValue(listwrk);
                        } else {
                            idPlantTujuan2.ViewValue = FormatNumber(idPlantTujuan2.CurrentValue, idPlantTujuan2.FormatPattern);
                        }
                    }
                } else {
                    idPlantTujuan2.ViewValue = DbNullValue;
                }
                idPlantTujuan2.ViewCustomAttributes = "";

                // Panjang2
                Panjang2.ViewValue = Panjang2.CurrentValue;
                Panjang2.ViewValue = FormatNumber(Panjang2.ViewValue, Panjang2.FormatPattern);
                Panjang2.ViewCustomAttributes = "";

                // Diameter2
                Diameter2.ViewValue = Diameter2.CurrentValue;
                Diameter2.ViewValue = FormatNumber(Diameter2.ViewValue, Diameter2.FormatPattern);
                Diameter2.ViewCustomAttributes = "";

                // Volume2
                Volume2.ViewValue = Volume2.CurrentValue;
                Volume2.ViewValue = FormatNumber(Volume2.ViewValue, Volume2.FormatPattern);
                Volume2.ViewCustomAttributes = "";

                // Flowrate2
                Flowrate2.ViewValue = Flowrate2.CurrentValue;
                Flowrate2.ViewValue = FormatNumber(Flowrate2.ViewValue, Flowrate2.FormatPattern);
                Flowrate2.ViewCustomAttributes = "";

                // idPlantTujuan3
                string curVal4 = ConvertToString(idPlantTujuan3.CurrentValue);
                if (!Empty(curVal4)) {
                    if (idPlantTujuan3.Lookup != null && IsDictionary(idPlantTujuan3.Lookup?.Options) && idPlantTujuan3.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idPlantTujuan3.ViewValue = idPlantTujuan3.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(idPlantTujuan3.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan3.CurrentValue, idPlantTujuan3.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk4 = idPlantTujuan3.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && idPlantTujuan3.Lookup != null) { // Lookup values found
                            var listwrk = idPlantTujuan3.Lookup?.RenderViewRow(rswrk4[0]);
                            idPlantTujuan3.ViewValue = idPlantTujuan3.DisplayValue(listwrk);
                        } else {
                            idPlantTujuan3.ViewValue = FormatNumber(idPlantTujuan3.CurrentValue, idPlantTujuan3.FormatPattern);
                        }
                    }
                } else {
                    idPlantTujuan3.ViewValue = DbNullValue;
                }
                idPlantTujuan3.ViewCustomAttributes = "";

                // Panjang3
                Panjang3.ViewValue = Panjang3.CurrentValue;
                Panjang3.ViewValue = FormatNumber(Panjang3.ViewValue, Panjang3.FormatPattern);
                Panjang3.ViewCustomAttributes = "";

                // Diameter3
                Diameter3.ViewValue = Diameter3.CurrentValue;
                Diameter3.ViewValue = FormatNumber(Diameter3.ViewValue, Diameter3.FormatPattern);
                Diameter3.ViewCustomAttributes = "";

                // Volume3
                Volume3.ViewValue = Volume3.CurrentValue;
                Volume3.ViewValue = FormatNumber(Volume3.ViewValue, Volume3.FormatPattern);
                Volume3.ViewCustomAttributes = "";

                // Flowrate3
                Flowrate3.ViewValue = Flowrate3.CurrentValue;
                Flowrate3.ViewValue = FormatNumber(Flowrate3.ViewValue, Flowrate3.FormatPattern);
                Flowrate3.ViewCustomAttributes = "";

                // BiayaProject
                BiayaProject.ViewValue = BiayaProject.CurrentValue;
                BiayaProject.ViewValue = FormatNumber(BiayaProject.ViewValue, BiayaProject.FormatPattern);
                BiayaProject.ViewCustomAttributes = "";

                // PlantAsal
                PlantAsal.ViewValue = ConvertToString(PlantAsal.CurrentValue); // DN
                PlantAsal.ViewCustomAttributes = "";

                // NamaPlantAsal
                NamaPlantAsal.ViewValue = ConvertToString(NamaPlantAsal.CurrentValue); // DN
                NamaPlantAsal.ViewCustomAttributes = "";

                // PlantTujuan
                PlantTujuan.ViewValue = ConvertToString(PlantTujuan.CurrentValue); // DN
                PlantTujuan.ViewCustomAttributes = "";

                // NamaPlantTujuan
                NamaPlantTujuan.ViewValue = ConvertToString(NamaPlantTujuan.CurrentValue); // DN
                NamaPlantTujuan.ViewCustomAttributes = "";

                // PlantTujuan2
                PlantTujuan2.ViewValue = ConvertToString(PlantTujuan2.CurrentValue); // DN
                PlantTujuan2.ViewCustomAttributes = "";

                // NamaPlantTujuan2
                NamaPlantTujuan2.ViewValue = ConvertToString(NamaPlantTujuan2.CurrentValue); // DN
                NamaPlantTujuan2.ViewCustomAttributes = "";

                // PlantTujuan3
                PlantTujuan3.ViewValue = ConvertToString(PlantTujuan3.CurrentValue); // DN
                PlantTujuan3.ViewCustomAttributes = "";

                // NamaPlantTujuan3
                NamaPlantTujuan3.ViewValue = ConvertToString(NamaPlantTujuan3.CurrentValue); // DN
                NamaPlantTujuan3.ViewCustomAttributes = "";

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

                // LastUpdatedDate
                LastUpdatedDate.ViewValue = LastUpdatedDate.CurrentValue;
                LastUpdatedDate.ViewValue = FormatDateTime(LastUpdatedDate.ViewValue, LastUpdatedDate.FormatPattern);
                LastUpdatedDate.ViewCustomAttributes = "";

                // KeteranganPipa
                KeteranganPipa.HrefValue = "";
                KeteranganPipa.TooltipValue = "";

                // idPlantAsal
                idPlantAsal.HrefValue = "";
                idPlantAsal.TooltipValue = "";

                // Flowrate
                Flowrate.HrefValue = "";
                Flowrate.TooltipValue = "";

                // BiayaProject
                BiayaProject.HrefValue = "";
                BiayaProject.TooltipValue = "";

                // PlantAsal
                PlantAsal.HrefValue = "";
                PlantAsal.TooltipValue = "";

                // NamaPlantAsal
                NamaPlantAsal.HrefValue = "";
                NamaPlantAsal.TooltipValue = "";

                // CreatedBy
                CreatedBy.HrefValue = "";
                CreatedBy.TooltipValue = "";

                // etlDate
                etlDate.HrefValue = "";
                etlDate.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // LastUpdatedDate
                LastUpdatedDate.HrefValue = "";
                LastUpdatedDate.TooltipValue = "";
            }

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        // Get export HTML tag
        protected string GetExportTag(string type, bool custom = false) {
            string exportUrl = AppPath(CurrentPageName()); // DN
            if (type == "print" || custom) { // Printer friendly / custom export
                exportUrl += "/" + GetKey(true, "/");
                exportUrl += "?export=" + type + (custom ? "&amp;custom=1" : "");
            } else {
                exportUrl = AppPath(Config.ApiUrl + Config.ApiExportAction + "/" + type + "/" + TableVar);
                exportUrl += "?" + Config.ApiKeyName + "=" + GetKey(true);
            }
            if (SameText(type, "excel")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fMasterPipaview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fMasterPipaview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fMasterPipaview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
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
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fMasterPipaview\" data-ew-action=\"email\" data-custom=\"false\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-key='" + ConvertToJsonAttribute(RecordKeys) + "' data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
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

            // Hide options for export
            if (IsExport())
                ExportOptions.HideAllOptions();

            // Hide options if json response
            if (IsJsonResponse())
                ExportOptions.HideAllOptions();
            if (!Security.CanExport) // Export not allowed
                ExportOptions.HideAllOptions();
        }

        #pragma warning disable 168

        /// <summary>
        /// Export data
        /// </summary>
        public async Task ExportData(dynamic? doc, string[] keys)
        {
            // Load recordset // DN
            DbDataReader? dr = null;
            if (TotalRecords < 0)
                TotalRecords = await ListRecordCountAsync();
            StartRecord = 1;
            if (keys.Length >= 1) {
                id.OldValue = keys[0];
                var c = await GetConnection2Async(DbId); // Note: Use new connection for view page export // DN
                dr = await c.ExecuteReaderAsync(GetSql(GetRecordFilter()));
            }
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
                await ExportDocument(doc, dr, StartRecord, StopRecord, "view");

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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterPipaList")), "", TableVar, true);
            string pageId = "view";
            breadcrumb.Add("view", pageId, url);
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
    } // End page class
} // End Partial class
