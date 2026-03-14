namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// closingStockEdit
    /// </summary>
    public static ClosingStockEdit closingStockEdit
    {
        get => HttpData.Get<ClosingStockEdit>("closingStockEdit")!;
        set => HttpData["closingStockEdit"] = value;
    }

    /// <summary>
    /// Page class for ClosingStock
    /// </summary>
    public class ClosingStockEdit : ClosingStockEditBase
    {
        // Constructor
        public ClosingStockEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public ClosingStockEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
            IdTangki.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class ClosingStockEditBase : ClosingStock
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "closingStockEdit";

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
        public ClosingStockEditBase()
        {
            TableName = "ClosingStock";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (closingStock)
            if (closingStock == null || closingStock is ClosingStock)
                closingStock = this;

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
        public string PageName => "ClosingStockEdit";

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
            IdClosingStock.Visible = false;
            IdTemplate.Visible = false;
            NomorClosingStock.SetVisibility();
            Proses2.Visible = false;
            LookupPlant.Visible = false;
            Plant.SetVisibility();
            TipeProdukSTS.SetVisibility();
            IdTangki.SetVisibility();
            TanggalClosingStock.SetVisibility();
            Produk.SetVisibility();
            StatusProses.SetVisibility();
            PersentaseProgress.SetVisibility();
            Catatan.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.SetVisibility();
            TanggalDiperbarui.SetVisibility();
            PlantForLookup.SetVisibility();
            LookupJenisPlant.SetVisibility();
        }

        // Constructor
        public ClosingStockEditBase(Controller? controller = null): this() { // DN
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
                        if (SameString(pageName, GetPageName(ListUrl)) ||
                            SameString(pageName, GetPageName(ViewUrl)) ||
                            SameString(pageName, GetPageName(GetCurrentMasterTable()?.ViewUrl ?? ""))
                        ) { // List / View / Master View page
                            if (!SameString(pageName, ListUrl)) { // Not List page
                                result.Add("caption", GetModalCaption(pageName));
                                result.Add("view", pageName == "ClosingStockView" ? "1" : "0"); // If View page, no primary button
                            } else { // List page
                                // result.Add("list", PageID == "search" ? "1" : "0"); // Refresh List page if current page is Search page
                                result.Add("error", FailureMessage); // List page should not be shown as modal => error
                                ClearFailureMessage();
                            }
                        } else { // Other pages (add messages and then clear messages)
                            result = GetMessages();
                            result.Add("modal", "1");
                            ClearMessages();
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdClosingStock") ? dict["IdClosingStock"] : IdClosingStock.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdClosingStock.Visible = false;
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
            NomorClosingStock.Required = false;
            Plant.Required = false;
            IdTangki.Required = false;

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
            await SetupLookupOptions(LookupPlant);
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(TipeProdukSTS);
            await SetupLookupOptions(IdTangki);
            await SetupLookupOptions(Produk);

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;
            bool loaded = false;
            bool postBack = false;
            StringValues sv;
            object? rv;

            // Set up current action and primary key
            if (IsApi()) {
                loaded = true;

                // Load key from form
                string[] keyValues = {};
                if (RouteValues.TryGetValue("key", out object? k))
                    keyValues = ConvertToString(k).Split('/');
                if (RouteValues.TryGetValue("IdClosingStock", out rv)) { // DN
                    IdClosingStock.FormValue = UrlDecode(rv); // DN
                    IdClosingStock.OldValue = IdClosingStock.FormValue;
                } else if (CurrentForm.HasValue("x_IdClosingStock")) {
                    IdClosingStock.FormValue = CurrentForm.GetValue("x_IdClosingStock");
                    IdClosingStock.OldValue = IdClosingStock.FormValue;
                } else if (!Empty(keyValues)) {
                    IdClosingStock.OldValue = ConvertToString(keyValues[0]);
                } else {
                    loaded = false; // Unable to load key
                }

                // Load record
                if (loaded)
                    loaded = await LoadRow();
                if (!loaded) {
                    FailureMessage = Language.Phrase("NoRecord"); // Set no record message
                    return Terminate();
                }
                CurrentAction = "update"; // Update record directly
                OldKey = GetKey(true); // Get from CurrentValue
                postBack = true;
            } else {
                if (!Empty(Post("action"))) {
                    CurrentAction = Post("action"); // Get action code
                    if (!IsShow) // Not reload record, handle as postback
                        postBack = true;

                    // Get key from Form
                    if (Post(OldKeyName, out sv))
                        SetKey(sv.ToString(), IsShow);
                } else {
                    CurrentAction = "show"; // Default action is display

                    // Load key from QueryString
                    bool loadByQuery = false;
                    if (RouteValues.TryGetValue("IdClosingStock", out rv)) { // DN
                        IdClosingStock.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("IdClosingStock", out sv)) {
                        IdClosingStock.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdClosingStock.CurrentValue = DbNullValue;
                    }
                }

                // Load recordset
                if (IsShow) {
                    // Load current record
                    loaded = await LoadRow();
                OldKey = loaded ? GetKey(true) : ""; // Get from CurrentValue
            }
        }

        // Process form if post back
        if (postBack) {
            await LoadFormValues(); // Get form values
            if (IsApi() && RouteValues.TryGetValue("key", out object? k)) {
                var keyValues = ConvertToString(k).Split('/');
                IdClosingStock.FormValue = ConvertToString(keyValues[0]);
            }
        }

        // Validate form if post back
        if (postBack) {
            if (!await ValidateForm()) {
                EventCancelled = true; // Event cancelled
                RestoreFormValues();
                if (IsApi())
                    return Terminate();
                else
                    CurrentAction = ""; // Form error, reset action
            }
        }

        // Perform current action
        switch (CurrentAction) {
                case "show": // Get a record to display
                        if (!loaded) { // Load record based on key
                            if (Empty(FailureMessage))
                                FailureMessage = Language.Phrase("NoRecord"); // No record found
                            return Terminate("ClosingStockList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "ClosingStockList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "ClosingStockList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "ClosingStockList"; // Return list page content
                            }
                        }
                        if (IsJsonResponse()) {
                            ClearMessages(); // Clear messages for Json response
                            return res;
                        } else {
                            return Terminate(returnUrl); // Return to caller
                        }
                    } else if (IsApi()) { // API request, return
                        return Terminate();
                    } else if (IsModal && UseAjaxActions) { // Return JSON error message
                        return Controller.Json(new { success = false, error = GetFailureMessage() });
                    } else if (FailureMessage == Language.Phrase("NoRecord")) {
                        return Terminate(returnUrl); // Return to caller
                    } else {
                        EventCancelled = true; // Event cancelled
                        RestoreFormValues(); // Restore form values if update failed
                    }
                    break;
            }

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Render the record
            RowType = RowType.Edit; // Render as Edit
            ResetAttributes();
            await RenderRow();

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();
                PageRenderingEventHandler?.Invoke(this, EventArgs.Empty);

                // Page Render event
                closingStockEdit?.PageRender();
            }
            return PageResult();
        }
        #pragma warning restore 219

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
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'NomorClosingStock' before field var 'x_NomorClosingStock'
            val = CurrentForm.HasValue("NomorClosingStock") ? CurrentForm.GetValue("NomorClosingStock") : CurrentForm.GetValue("x_NomorClosingStock");
            if (!NomorClosingStock.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorClosingStock") && !CurrentForm.HasValue("x_NomorClosingStock")) // DN
                    NomorClosingStock.Visible = false; // Disable update for API request
                else
                    NomorClosingStock.SetFormValue(val);
            }

            // Check field name 'Plant' before field var 'x_Plant'
            val = CurrentForm.HasValue("Plant") ? CurrentForm.GetValue("Plant") : CurrentForm.GetValue("x_Plant");
            if (!Plant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Plant") && !CurrentForm.HasValue("x_Plant")) // DN
                    Plant.Visible = false; // Disable update for API request
                else
                    Plant.SetFormValue(val);
            }

            // Check field name 'TipeProdukSTS' before field var 'x_TipeProdukSTS'
            val = CurrentForm.HasValue("TipeProdukSTS") ? CurrentForm.GetValue("TipeProdukSTS") : CurrentForm.GetValue("x_TipeProdukSTS");
            if (!TipeProdukSTS.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipeProdukSTS") && !CurrentForm.HasValue("x_TipeProdukSTS")) // DN
                    TipeProdukSTS.Visible = false; // Disable update for API request
                else
                    TipeProdukSTS.SetFormValue(val);
            }

            // Check field name 'IdTangki' before field var 'x_IdTangki'
            val = CurrentForm.HasValue("IdTangki") ? CurrentForm.GetValue("IdTangki") : CurrentForm.GetValue("x_IdTangki");
            if (!IdTangki.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTangki") && !CurrentForm.HasValue("x_IdTangki")) // DN
                    IdTangki.Visible = false; // Disable update for API request
                else
                    IdTangki.SetFormValue(val);
            }

            // Check field name 'TanggalClosingStock' before field var 'x_TanggalClosingStock'
            val = CurrentForm.HasValue("TanggalClosingStock") ? CurrentForm.GetValue("TanggalClosingStock") : CurrentForm.GetValue("x_TanggalClosingStock");
            if (!TanggalClosingStock.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalClosingStock") && !CurrentForm.HasValue("x_TanggalClosingStock")) // DN
                    TanggalClosingStock.Visible = false; // Disable update for API request
                else
                    TanggalClosingStock.SetFormValue(val);
                TanggalClosingStock.CurrentValue = UnformatDateTime(TanggalClosingStock.CurrentValue, TanggalClosingStock.FormatPattern);
            }

            // Check field name 'Produk' before field var 'x_Produk'
            val = CurrentForm.HasValue("Produk") ? CurrentForm.GetValue("Produk") : CurrentForm.GetValue("x_Produk");
            if (!Produk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Produk") && !CurrentForm.HasValue("x_Produk")) // DN
                    Produk.Visible = false; // Disable update for API request
                else
                    Produk.SetFormValue(val);
            }

            // Check field name 'StatusProses' before field var 'x_StatusProses'
            val = CurrentForm.HasValue("StatusProses") ? CurrentForm.GetValue("StatusProses") : CurrentForm.GetValue("x_StatusProses");
            if (!StatusProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusProses") && !CurrentForm.HasValue("x_StatusProses")) // DN
                    StatusProses.Visible = false; // Disable update for API request
                else
                    StatusProses.SetFormValue(val);
            }

            // Check field name 'PersentaseProgress' before field var 'x_PersentaseProgress'
            val = CurrentForm.HasValue("PersentaseProgress") ? CurrentForm.GetValue("PersentaseProgress") : CurrentForm.GetValue("x_PersentaseProgress");
            if (!PersentaseProgress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PersentaseProgress") && !CurrentForm.HasValue("x_PersentaseProgress")) // DN
                    PersentaseProgress.Visible = false; // Disable update for API request
                else
                    PersentaseProgress.SetFormValue(val);
            }

            // Check field name 'Catatan' before field var 'x_Catatan'
            val = CurrentForm.HasValue("Catatan") ? CurrentForm.GetValue("Catatan") : CurrentForm.GetValue("x_Catatan");
            if (!Catatan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Catatan") && !CurrentForm.HasValue("x_Catatan")) // DN
                    Catatan.Visible = false; // Disable update for API request
                else
                    Catatan.SetFormValue(val);
            }

            // Check field name 'DiperbaruiOleh' before field var 'x_DiperbaruiOleh'
            val = CurrentForm.HasValue("DiperbaruiOleh") ? CurrentForm.GetValue("DiperbaruiOleh") : CurrentForm.GetValue("x_DiperbaruiOleh");
            if (!DiperbaruiOleh.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DiperbaruiOleh") && !CurrentForm.HasValue("x_DiperbaruiOleh")) // DN
                    DiperbaruiOleh.Visible = false; // Disable update for API request
                else
                    DiperbaruiOleh.SetFormValue(val);
            }

            // Check field name 'TanggalDiperbarui' before field var 'x_TanggalDiperbarui'
            val = CurrentForm.HasValue("TanggalDiperbarui") ? CurrentForm.GetValue("TanggalDiperbarui") : CurrentForm.GetValue("x_TanggalDiperbarui");
            if (!TanggalDiperbarui.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalDiperbarui") && !CurrentForm.HasValue("x_TanggalDiperbarui")) // DN
                    TanggalDiperbarui.Visible = false; // Disable update for API request
                else
                    TanggalDiperbarui.SetFormValue(val);
                TanggalDiperbarui.CurrentValue = UnformatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
            }

            // Check field name 'PlantForLookup' before field var 'x_PlantForLookup'
            val = CurrentForm.HasValue("PlantForLookup") ? CurrentForm.GetValue("PlantForLookup") : CurrentForm.GetValue("x_PlantForLookup");
            if (!PlantForLookup.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PlantForLookup") && !CurrentForm.HasValue("x_PlantForLookup")) // DN
                    PlantForLookup.Visible = false; // Disable update for API request
                else
                    PlantForLookup.SetFormValue(val);
            }

            // Check field name 'LookupJenisPlant' before field var 'x_LookupJenisPlant'
            val = CurrentForm.HasValue("LookupJenisPlant") ? CurrentForm.GetValue("LookupJenisPlant") : CurrentForm.GetValue("x_LookupJenisPlant");
            if (!LookupJenisPlant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LookupJenisPlant") && !CurrentForm.HasValue("x_LookupJenisPlant")) // DN
                    LookupJenisPlant.Visible = false; // Disable update for API request
                else
                    LookupJenisPlant.SetFormValue(val);
            }

            // Check field name 'IdClosingStock' before field var 'x_IdClosingStock'
            val = CurrentForm.HasValue("IdClosingStock") ? CurrentForm.GetValue("IdClosingStock") : CurrentForm.GetValue("x_IdClosingStock");
            if (!IdClosingStock.IsDetailKey)
                IdClosingStock.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdClosingStock.CurrentValue = IdClosingStock.FormValue;
            NomorClosingStock.CurrentValue = NomorClosingStock.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            TipeProdukSTS.CurrentValue = TipeProdukSTS.FormValue;
            IdTangki.CurrentValue = IdTangki.FormValue;
            TanggalClosingStock.CurrentValue = TanggalClosingStock.FormValue;
            TanggalClosingStock.CurrentValue = UnformatDateTime(TanggalClosingStock.CurrentValue, TanggalClosingStock.FormatPattern);
            Produk.CurrentValue = Produk.FormValue;
            StatusProses.CurrentValue = StatusProses.FormValue;
            PersentaseProgress.CurrentValue = PersentaseProgress.FormValue;
            Catatan.CurrentValue = Catatan.FormValue;
            DiperbaruiOleh.CurrentValue = DiperbaruiOleh.FormValue;
            TanggalDiperbarui.CurrentValue = TanggalDiperbarui.FormValue;
            TanggalDiperbarui.CurrentValue = UnformatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
            PlantForLookup.CurrentValue = PlantForLookup.FormValue;
            LookupJenisPlant.CurrentValue = LookupJenisPlant.FormValue;
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
            IdClosingStock.SetDbValue(row["IdClosingStock"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            NomorClosingStock.SetDbValue(row["NomorClosingStock"]);
            Proses2.SetDbValue(row["Proses"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            Plant.SetDbValue(row["Plant"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            IdTangki.SetDbValue(row["IdTangki"]);
            TanggalClosingStock.SetDbValue(row["TanggalClosingStock"]);
            Produk.SetDbValue(row["Produk"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            PlantForLookup.SetDbValue(row["PlantForLookup"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdClosingStock", IdClosingStock.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorClosingStock", NomorClosingStock.DefaultValue ?? DbNullValue); // DN
            row.Add("Proses", Proses2.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTangki", IdTangki.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalClosingStock", TanggalClosingStock.DefaultValue ?? DbNullValue); // DN
            row.Add("Produk", Produk.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("Catatan", Catatan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantForLookup", PlantForLookup.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupJenisPlant", LookupJenisPlant.DefaultValue ?? DbNullValue); // DN
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

            // IdClosingStock
            IdClosingStock.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // NomorClosingStock
            NomorClosingStock.RowCssClass = "row";

            // Proses
            Proses2.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // IdTangki
            IdTangki.RowCssClass = "row";

            // TanggalClosingStock
            TanggalClosingStock.RowCssClass = "row";

            // Produk
            Produk.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

            // PersentaseProgress
            PersentaseProgress.RowCssClass = "row";

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

            // PlantForLookup
            PlantForLookup.RowCssClass = "row";

            // LookupJenisPlant
            LookupJenisPlant.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdClosingStock
                IdClosingStock.ViewValue = IdClosingStock.CurrentValue;
                IdClosingStock.ViewValue = FormatNumber(IdClosingStock.ViewValue, IdClosingStock.FormatPattern);
                IdClosingStock.ViewCustomAttributes = "";

                // IdTemplate
                IdTemplate.ViewValue = IdTemplate.CurrentValue;
                IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
                IdTemplate.ViewCustomAttributes = "";

                // NomorClosingStock
                NomorClosingStock.ViewValue = ConvertToString(NomorClosingStock.CurrentValue); // DN
                NomorClosingStock.ViewCustomAttributes = "";

                // Proses
                Proses2.ViewValue = ConvertToString(Proses2.CurrentValue); // DN
                Proses2.ViewCustomAttributes = "";

                // LookupPlant
                if (!Empty(LookupPlant.CurrentValue)) {
                    LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                } else {
                    LookupPlant.ViewValue = DbNullValue;
                }
                LookupPlant.ViewCustomAttributes = "";

                // Plant
                Plant.ViewValue = ConvertToString(Plant.CurrentValue); // DN
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

                // TipeProdukSTS
                List<object?>? listWrk3 = [ // DN
                    TipeProdukSTS.CurrentValue,
                    TipeProdukSTS.CurrentValue,
                ];
                listWrk3 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk3, this);
                string? dispVal3 = TipeProdukSTS.DisplayValue(listWrk3);
                if (!Empty(dispVal3))
                    TipeProdukSTS.ViewValue = dispVal3;
                TipeProdukSTS.ViewCustomAttributes = "";

                // IdTangki
                string curVal4 = ConvertToString(IdTangki.CurrentValue);
                if (!Empty(curVal4)) {
                    if (IdTangki.Lookup != null && IsDictionary(IdTangki.Lookup?.Options) && IdTangki.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTangki.ViewValue = IdTangki.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(IdTangki.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdTangki.CurrentValue, IdTangki.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                        var lookupFilter4 = () => IdTangki.GetSelectFilter();
                        string? sqlWrk4 = IdTangki.Lookup?.GetSql(false, filterWrk4, lookupFilter4, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && IdTangki.Lookup != null) { // Lookup values found
                            var listwrk = IdTangki.Lookup?.RenderViewRow(rswrk4[0]);
                            IdTangki.ViewValue = IdTangki.DisplayValue(listwrk);
                        } else {
                            IdTangki.ViewValue = FormatNumber(IdTangki.CurrentValue, IdTangki.FormatPattern);
                        }
                    }
                } else {
                    IdTangki.ViewValue = DbNullValue;
                }
                IdTangki.ViewCustomAttributes = "";

                // TanggalClosingStock
                TanggalClosingStock.ViewValue = TanggalClosingStock.CurrentValue;
                TanggalClosingStock.ViewValue = FormatDateTime(TanggalClosingStock.ViewValue, TanggalClosingStock.FormatPattern);
                TanggalClosingStock.ViewCustomAttributes = "";

                // Produk
                if (!Empty(Produk.CurrentValue)) {
                    Produk.ViewValue = Produk.OptionCaption(ConvertToString(Produk.CurrentValue));
                } else {
                    Produk.ViewValue = DbNullValue;
                }
                Produk.ViewCustomAttributes = "";

                // StatusProses
                StatusProses.ViewValue = StatusProses.CurrentValue;
                StatusProses.ViewCustomAttributes = "";

                // PersentaseProgress
                PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                PersentaseProgress.ViewCustomAttributes = "";

                // Catatan
                Catatan.ViewValue = Catatan.CurrentValue;
                Catatan.ViewCustomAttributes = "";

                // DibuatOleh
                DibuatOleh.ViewValue = DibuatOleh.CurrentValue;
                DibuatOleh.ViewCustomAttributes = "";

                // TanggalDibuat
                TanggalDibuat.ViewValue = TanggalDibuat.CurrentValue;
                TanggalDibuat.ViewValue = FormatDateTime(TanggalDibuat.ViewValue, TanggalDibuat.FormatPattern);
                TanggalDibuat.ViewCustomAttributes = "";

                // DiperbaruiOleh
                DiperbaruiOleh.ViewValue = DiperbaruiOleh.CurrentValue;
                DiperbaruiOleh.ViewCustomAttributes = "";

                // TanggalDiperbarui
                TanggalDiperbarui.ViewValue = TanggalDiperbarui.CurrentValue;
                TanggalDiperbarui.ViewValue = FormatDateTime(TanggalDiperbarui.ViewValue, TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.ViewCustomAttributes = "";

                // PlantForLookup
                PlantForLookup.ViewValue = PlantForLookup.CurrentValue;
                PlantForLookup.ViewCustomAttributes = "";

                // LookupJenisPlant
                LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
                LookupJenisPlant.ViewCustomAttributes = "";

                // NomorClosingStock
                NomorClosingStock.HrefValue = "";
                NomorClosingStock.TooltipValue = "";

                // Plant
                Plant.HrefValue = "";
                Plant.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // IdTangki
                IdTangki.HrefValue = "";
                IdTangki.TooltipValue = "";

                // TanggalClosingStock
                TanggalClosingStock.HrefValue = "";
                TanggalClosingStock.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";

                // StatusProses
                StatusProses.HrefValue = "";
                StatusProses.TooltipValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";
                PersentaseProgress.TooltipValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";

                // PlantForLookup
                PlantForLookup.HrefValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // NomorClosingStock
                NomorClosingStock.SetupEditAttributes();
                NomorClosingStock.EditValue = ConvertToString(NomorClosingStock.CurrentValue); // DN
                NomorClosingStock.ViewCustomAttributes = "";

                // Plant
                Plant.SetupEditAttributes();
                Plant.EditValue = ConvertToString(Plant.CurrentValue); // DN
                string curVal2 = ConvertToString(Plant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Plant.EditValue = Plant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = Plant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                            var listwrk = Plant.Lookup?.RenderViewRow(rswrk2[0]);
                            Plant.EditValue = Plant.DisplayValue(listwrk);
                        } else {
                            Plant.EditValue = Plant.CurrentValue;
                        }
                    }
                } else {
                    Plant.EditValue = DbNullValue;
                }
                Plant.ViewCustomAttributes = "";

                // TipeProdukSTS
                TipeProdukSTS.SetupEditAttributes();
                List<object?>? listWrk3 = [ // DN
                    TipeProdukSTS.CurrentValue,
                    TipeProdukSTS.CurrentValue,
                ];
                listWrk3 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk3, this);
                string? dispVal3 = TipeProdukSTS.DisplayValue(listWrk3);
                if (!Empty(dispVal3))
                    TipeProdukSTS.EditValue = dispVal3;
                TipeProdukSTS.ViewCustomAttributes = "";

                // IdTangki
                IdTangki.SetupEditAttributes();
                string curVal4 = ConvertToString(IdTangki.CurrentValue);
                if (!Empty(curVal4)) {
                    if (IdTangki.Lookup != null && IsDictionary(IdTangki.Lookup?.Options) && IdTangki.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTangki.EditValue = IdTangki.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(IdTangki.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdTangki.CurrentValue, IdTangki.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                        var lookupFilter4 = () => IdTangki.GetSelectFilter();
                        string? sqlWrk4 = IdTangki.Lookup?.GetSql(false, filterWrk4, lookupFilter4, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && IdTangki.Lookup != null) { // Lookup values found
                            var listwrk = IdTangki.Lookup?.RenderViewRow(rswrk4[0]);
                            IdTangki.EditValue = IdTangki.DisplayValue(listwrk);
                        } else {
                            IdTangki.EditValue = FormatNumber(IdTangki.CurrentValue, IdTangki.FormatPattern);
                        }
                    }
                } else {
                    IdTangki.EditValue = DbNullValue;
                }
                IdTangki.ViewCustomAttributes = "";

                // TanggalClosingStock
                TanggalClosingStock.SetupEditAttributes();
                TanggalClosingStock.EditValue = TanggalClosingStock.CurrentValue;
                TanggalClosingStock.EditValue = FormatDateTime(TanggalClosingStock.EditValue, TanggalClosingStock.FormatPattern);
                TanggalClosingStock.ViewCustomAttributes = "";

                // Produk
                Produk.SetupEditAttributes();
                Produk.EditValue = Produk.Options(true);
                Produk.PlaceHolder = RemoveHtml(Produk.Caption);

                // StatusProses
                StatusProses.SetupEditAttributes();

                // PersentaseProgress
                PersentaseProgress.SetupEditAttributes();
                PersentaseProgress.CurrentValue = FormatPercent(PersentaseProgress.CurrentValue, PersentaseProgress.FormatPattern);

                // Catatan
                Catatan.SetupEditAttributes();
                Catatan.EditValue = Catatan.CurrentValue; // DN
                Catatan.PlaceHolder = RemoveHtml(Catatan.Caption);

                // DiperbaruiOleh

                // TanggalDiperbarui

                // PlantForLookup
                PlantForLookup.SetupEditAttributes();

                // LookupJenisPlant
                LookupJenisPlant.SetupEditAttributes();

                // Edit refer script

                // NomorClosingStock
                NomorClosingStock.HrefValue = "";
                NomorClosingStock.TooltipValue = "";

                // Plant
                Plant.HrefValue = "";
                Plant.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // IdTangki
                IdTangki.HrefValue = "";
                IdTangki.TooltipValue = "";

                // TanggalClosingStock
                TanggalClosingStock.HrefValue = "";
                TanggalClosingStock.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";

                // StatusProses
                StatusProses.HrefValue = "";
                StatusProses.TooltipValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";
                PersentaseProgress.TooltipValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";

                // PlantForLookup
                PlantForLookup.HrefValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
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
                if (NomorClosingStock.Visible && NomorClosingStock.Required) {
                    if (!NomorClosingStock.IsDetailKey && Empty(NomorClosingStock.FormValue)) {
                        NomorClosingStock.AddErrorMessage(ConvertToString(NomorClosingStock.RequiredErrorMessage).Replace("%s", NomorClosingStock.Caption));
                    }
                }
                if (Plant.Visible && Plant.Required) {
                    if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                        Plant.AddErrorMessage(ConvertToString(Plant.RequiredErrorMessage).Replace("%s", Plant.Caption));
                    }
                }
                if (TipeProdukSTS.Visible && TipeProdukSTS.Required) {
                    if (!TipeProdukSTS.IsDetailKey && Empty(TipeProdukSTS.FormValue)) {
                        TipeProdukSTS.AddErrorMessage(ConvertToString(TipeProdukSTS.RequiredErrorMessage).Replace("%s", TipeProdukSTS.Caption));
                    }
                }
                if (IdTangki.Visible && IdTangki.Required) {
                    if (!IdTangki.IsDetailKey && Empty(IdTangki.FormValue)) {
                        IdTangki.AddErrorMessage(ConvertToString(IdTangki.RequiredErrorMessage).Replace("%s", IdTangki.Caption));
                    }
                }
                if (TanggalClosingStock.Visible && TanggalClosingStock.Required) {
                    if (!TanggalClosingStock.IsDetailKey && Empty(TanggalClosingStock.FormValue)) {
                        TanggalClosingStock.AddErrorMessage(ConvertToString(TanggalClosingStock.RequiredErrorMessage).Replace("%s", TanggalClosingStock.Caption));
                    }
                }
                if (Produk.Visible && Produk.Required) {
                    if (!Produk.IsDetailKey && Empty(Produk.FormValue)) {
                        Produk.AddErrorMessage(ConvertToString(Produk.RequiredErrorMessage).Replace("%s", Produk.Caption));
                    }
                }
                if (StatusProses.Visible && StatusProses.Required) {
                    if (!StatusProses.IsDetailKey && Empty(StatusProses.FormValue)) {
                        StatusProses.AddErrorMessage(ConvertToString(StatusProses.RequiredErrorMessage).Replace("%s", StatusProses.Caption));
                    }
                }
                if (PersentaseProgress.Visible && PersentaseProgress.Required) {
                    if (!PersentaseProgress.IsDetailKey && Empty(PersentaseProgress.FormValue)) {
                        PersentaseProgress.AddErrorMessage(ConvertToString(PersentaseProgress.RequiredErrorMessage).Replace("%s", PersentaseProgress.Caption));
                    }
                }
                if (Catatan.Visible && Catatan.Required) {
                    if (!Catatan.IsDetailKey && Empty(Catatan.FormValue)) {
                        Catatan.AddErrorMessage(ConvertToString(Catatan.RequiredErrorMessage).Replace("%s", Catatan.Caption));
                    }
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
                if (PlantForLookup.Visible && PlantForLookup.Required) {
                    if (!PlantForLookup.IsDetailKey && Empty(PlantForLookup.FormValue)) {
                        PlantForLookup.AddErrorMessage(ConvertToString(PlantForLookup.RequiredErrorMessage).Replace("%s", PlantForLookup.Caption));
                    }
                }
                if (LookupJenisPlant.Visible && LookupJenisPlant.Required) {
                    if (!LookupJenisPlant.IsDetailKey && Empty(LookupJenisPlant.FormValue)) {
                        LookupJenisPlant.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
                    }
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

            // Produk
            Produk.SetDbValue(rsnew, Produk.CurrentValue, Produk.ReadOnly);

            // Catatan
            Catatan.SetDbValue(rsnew, Catatan.CurrentValue, Catatan.ReadOnly);

            // DiperbaruiOleh
            DiperbaruiOleh.CurrentValue = DiperbaruiOleh.GetAutoUpdateValue();
            DiperbaruiOleh.SetDbValue(rsnew, DiperbaruiOleh.CurrentValue, DiperbaruiOleh.ReadOnly);

            // TanggalDiperbarui
            TanggalDiperbarui.CurrentValue = TanggalDiperbarui.GetAutoUpdateValue();
            TanggalDiperbarui.SetDbValue(rsnew, ConvertToDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern), TanggalDiperbarui.ReadOnly);

            // PlantForLookup
            PlantForLookup.SetDbValue(rsnew, PlantForLookup.CurrentValue, PlantForLookup.ReadOnly);

            // LookupJenisPlant
            LookupJenisPlant.SetDbValue(rsnew, LookupJenisPlant.CurrentValue, LookupJenisPlant.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Produk", out value)) // Produk
                Produk.CurrentValue = value;
            if (row.TryGetValue("Catatan", out value)) // Catatan
                Catatan.CurrentValue = value;
            if (row.TryGetValue("DiperbaruiOleh", out value)) // DiperbaruiOleh
                DiperbaruiOleh.CurrentValue = value;
            if (row.TryGetValue("TanggalDiperbarui", out value)) // TanggalDiperbarui
                TanggalDiperbarui.CurrentValue = value;
            if (row.TryGetValue("PlantForLookup", out value)) // PlantForLookup
                PlantForLookup.CurrentValue = value;
            if (row.TryGetValue("LookupJenisPlant", out value)) // LookupJenisPlant
                LookupJenisPlant.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("ClosingStockList")), "", TableVar, true);
            string pageId = "edit";
            breadcrumb.Add("edit", pageId, url);
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
                // Set up lookup SQL
                switch (fld.FieldVar) {
                    case "x_IdTangki":
                        lookupFilter = () => fld.GetSelectFilter();
                        break;
                }

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

        // Form Custom Validate event
        public virtual bool FormCustomValidate(ref string customError) {
            //Return error message in customError
            return true;
        }
    } // End page class
} // End Partial class
