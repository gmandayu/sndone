namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterPipaDelete
    /// </summary>
    public static MasterPipaDelete masterPipaDelete
    {
        get => HttpData.Get<MasterPipaDelete>("masterPipaDelete")!;
        set => HttpData["masterPipaDelete"] = value;
    }

    /// <summary>
    /// Page class for MasterPipa
    /// </summary>
    public class MasterPipaDelete : MasterPipaDeleteBase
    {
        // Constructor
        public MasterPipaDelete(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterPipaDelete() : base()
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
    public class MasterPipaDeleteBase : MasterPipa
    {
        // Page ID
        public string PageID = "delete";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterPipaDelete";

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
        public MasterPipaDeleteBase()
        {
            TableName = "MasterPipa";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterPipa)
            if (masterPipa == null || masterPipa is MasterPipa)
                masterPipa = this;

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
        public string PageName => "MasterPipaDelete";

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
            KeteranganPipa.SetVisibility();
            idPlantAsal.SetVisibility();
            idPlantTujuan.Visible = false;
            Panjang.Visible = false;
            Diameter.Visible = false;
            Volume.Visible = false;
            Flowrate.SetVisibility();
            idPlantTujuan2.Visible = false;
            Panjang2.Visible = false;
            Diameter2.Visible = false;
            Volume2.Visible = false;
            Flowrate2.Visible = false;
            idPlantTujuan3.Visible = false;
            Panjang3.Visible = false;
            Diameter3.Visible = false;
            Volume3.Visible = false;
            Flowrate3.Visible = false;
            BiayaProject.SetVisibility();
            PlantAsal.SetVisibility();
            NamaPlantAsal.SetVisibility();
            PlantTujuan.Visible = false;
            NamaPlantTujuan.Visible = false;
            PlantTujuan2.Visible = false;
            NamaPlantTujuan2.Visible = false;
            PlantTujuan3.Visible = false;
            NamaPlantTujuan3.Visible = false;
            CreatedBy.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            LastUpdatedDate.SetVisibility();
        }

        // Constructor
        public MasterPipaDeleteBase(Controller? controller = null): this() { // DN
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("id") ? dict["id"] : id.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                id.Visible = false;
        }

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public int StartRecord;

        public int TotalRecords;

        public int RecordCount;

        public List<string> RecordKeys = new();

        public DbDataReader? Recordset;

        public int StartRowCount = 1;

        public bool IsModal = false;

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
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

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Load key parameters
            RecordKeys = GetRecordKeys(); // Load record keys
            string filter = GetFilterFromRecordKeys();
            if (Empty(filter))
                return Terminate("MasterPipaList"); // Prevent SQL injection, return to List page

            // Set up filter (WHERE Clause)
            CurrentFilter = filter;

            // Get action
            if (IsApi()) {
                CurrentAction = "delete"; // Delete record directly
            } else if (!Empty(Param("action"))) {
                CurrentAction = Param("action") == "delete" ? "delete" : "show";
            } else {
                CurrentAction = InlineDelete ?
                    "delete" : // Delete record directly
                    "show"; // Display record
            }
            if (IsDelete) { // DN
                SendEmail = true; // Send email on delete success
                var res = await DeleteRows();
                if (res) { // Delete rows
                    if (Empty(SuccessMessage))
                        SuccessMessage = Language.Phrase("DeleteSuccess"); // Set up success message
                    if (IsJsonResponse()) {
                        ClearMessages(); // Clear messages for Json response
                        return res;
                    } else {
                        return Terminate(ReturnUrl); // Return to caller
                    }
                } else { // Delete failed
                    if (IsJsonResponse()) {
                        return Terminate();
                    }
                    // Return JSON error message if UseAjaxActions
                    if (UseAjaxActions)
                        return Controller.Json(new { success = false, error = GetFailureMessage() });
                    if (InlineDelete)
                        return Terminate(ReturnUrl); // Return to caller
                    else
                        CurrentAction = "show"; // Display record
                }
            }
            if (IsShow) { // Load records for display // DN
                Recordset = await LoadRecordset();
                TotalRecords = await ListRecordCountAsync(); // Get record count
                if (TotalRecords <= 0) { // No record found, exit
                    CloseRecordset(); // DN
                    return Terminate("MasterPipaList"); // Return to list
                }
            }

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();
                PageRenderingEventHandler?.Invoke(this, EventArgs.Empty);

                // Page Render event
                masterPipaDelete?.PageRender();
            }
            return PageResult();
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
            if (UseTransaction)
                Connection.BeginTrans();
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
            if (result) {
                if (UseTransaction)
                    Connection.CommitTrans(); // Commit the changes

                // Set warning message if delete some records failed
                if (failKeys.Count > 0)
                    WarningMessage = Language.Phrase("DeleteRecordsFailed").Replace("%k", String.Join(", ", failKeys));
            } else {
                if (UseTransaction)
                    Connection.RollbackTrans(); // Rollback changes
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

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterPipaList")), "", TableVar, true);
            string pageId = "delete";
            breadcrumb.Add("delete", pageId, url);
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
    } // End page class
} // End Partial class
