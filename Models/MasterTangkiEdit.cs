namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterTangkiEdit
    /// </summary>
    public static MasterTangkiEdit masterTangkiEdit
    {
        get => HttpData.Get<MasterTangkiEdit>("masterTangkiEdit")!;
        set => HttpData["masterTangkiEdit"] = value;
    }

    /// <summary>
    /// Page class for MasterTangki
    /// </summary>
    public class MasterTangkiEdit : MasterTangkiEditBase
    {
        // Constructor
        public MasterTangkiEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterTangkiEdit() : base()
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
    public class MasterTangkiEditBase : MasterTangki
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterTangkiEdit";

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
        public MasterTangkiEditBase()
        {
            TableName = "MasterTangki";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterTangki)
            if (masterTangki == null || masterTangki is MasterTangki)
                masterTangki = this;

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
        public string PageName => "MasterTangkiEdit";

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
            LastUpdatedBy.Visible = false;
            lastUpdatedDate.Visible = false;
        }

        // Constructor
        public MasterTangkiEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "MasterTangkiView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(Status);

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
                if (RouteValues.TryGetValue("id", out rv)) { // DN
                    id.FormValue = UrlDecode(rv); // DN
                    id.OldValue = id.FormValue;
                } else if (CurrentForm.HasValue("x_id")) {
                    id.FormValue = CurrentForm.GetValue("x_id");
                    id.OldValue = id.FormValue;
                } else if (!Empty(keyValues)) {
                    id.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("id", out rv)) { // DN
                        id.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("id", out sv)) {
                        id.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        id.CurrentValue = DbNullValue;
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
                id.FormValue = ConvertToString(keyValues[0]);
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
                            return Terminate("MasterTangkiList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "MasterTangkiList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MasterTangkiList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MasterTangkiList"; // Return list page content
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
                masterTangkiEdit?.PageRender();
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

            // Check field name 'NamaTerminal' before field var 'x_NamaTerminal'
            val = CurrentForm.HasValue("NamaTerminal") ? CurrentForm.GetValue("NamaTerminal") : CurrentForm.GetValue("x_NamaTerminal");
            if (!NamaTerminal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaTerminal") && !CurrentForm.HasValue("x_NamaTerminal")) // DN
                    NamaTerminal.Visible = false; // Disable update for API request
                else
                    NamaTerminal.SetFormValue(val);
            }

            // Check field name 'Plant' before field var 'x_Plant'
            val = CurrentForm.HasValue("Plant") ? CurrentForm.GetValue("Plant") : CurrentForm.GetValue("x_Plant");
            if (!Plant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Plant") && !CurrentForm.HasValue("x_Plant")) // DN
                    Plant.Visible = false; // Disable update for API request
                else
                    Plant.SetFormValue(val);
            }

            // Check field name 'Sloc' before field var 'x_Sloc'
            val = CurrentForm.HasValue("Sloc") ? CurrentForm.GetValue("Sloc") : CurrentForm.GetValue("x_Sloc");
            if (!Sloc.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Sloc") && !CurrentForm.HasValue("x_Sloc")) // DN
                    Sloc.Visible = false; // Disable update for API request
                else
                    Sloc.SetFormValue(val);
            }

            // Check field name 'SeqTangki' before field var 'x_SeqTangki'
            val = CurrentForm.HasValue("SeqTangki") ? CurrentForm.GetValue("SeqTangki") : CurrentForm.GetValue("x_SeqTangki");
            if (!SeqTangki.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SeqTangki") && !CurrentForm.HasValue("x_SeqTangki")) // DN
                    SeqTangki.Visible = false; // Disable update for API request
                else
                    SeqTangki.SetFormValue(val);
            }

            // Check field name 'MatNo' before field var 'x_MatNo'
            val = CurrentForm.HasValue("MatNo") ? CurrentForm.GetValue("MatNo") : CurrentForm.GetValue("x_MatNo");
            if (!MatNo.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MatNo") && !CurrentForm.HasValue("x_MatNo")) // DN
                    MatNo.Visible = false; // Disable update for API request
                else
                    MatNo.SetFormValue(val);
            }

            // Check field name 'TglKalibrasi' before field var 'x_TglKalibrasi'
            val = CurrentForm.HasValue("TglKalibrasi") ? CurrentForm.GetValue("TglKalibrasi") : CurrentForm.GetValue("x_TglKalibrasi");
            if (!TglKalibrasi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TglKalibrasi") && !CurrentForm.HasValue("x_TglKalibrasi")) // DN
                    TglKalibrasi.Visible = false; // Disable update for API request
                else
                    TglKalibrasi.SetFormValue(val, true, validate);
                TglKalibrasi.CurrentValue = UnformatDateTime(TglKalibrasi.CurrentValue, TglKalibrasi.FormatPattern);
            }

            // Check field name 'ExpDate' before field var 'x_ExpDate'
            val = CurrentForm.HasValue("ExpDate") ? CurrentForm.GetValue("ExpDate") : CurrentForm.GetValue("x_ExpDate");
            if (!ExpDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ExpDate") && !CurrentForm.HasValue("x_ExpDate")) // DN
                    ExpDate.Visible = false; // Disable update for API request
                else
                    ExpDate.SetFormValue(val, true, validate);
                ExpDate.CurrentValue = UnformatDateTime(ExpDate.CurrentValue, ExpDate.FormatPattern);
            }

            // Check field name 'Status' before field var 'x_Status'
            val = CurrentForm.HasValue("Status") ? CurrentForm.GetValue("Status") : CurrentForm.GetValue("x_Status");
            if (!Status.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Status") && !CurrentForm.HasValue("x_Status")) // DN
                    Status.Visible = false; // Disable update for API request
                else
                    Status.SetFormValue(val);
            }

            // Check field name 'TinggiMejaUk' before field var 'x_TinggiMejaUk'
            val = CurrentForm.HasValue("TinggiMejaUk") ? CurrentForm.GetValue("TinggiMejaUk") : CurrentForm.GetValue("x_TinggiMejaUk");
            if (!TinggiMejaUk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TinggiMejaUk") && !CurrentForm.HasValue("x_TinggiMejaUk")) // DN
                    TinggiMejaUk.Visible = false; // Disable update for API request
                else
                    TinggiMejaUk.SetFormValue(val);
            }

            // Check field name 'MaxDipping' before field var 'x_MaxDipping'
            val = CurrentForm.HasValue("MaxDipping") ? CurrentForm.GetValue("MaxDipping") : CurrentForm.GetValue("x_MaxDipping");
            if (!MaxDipping.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MaxDipping") && !CurrentForm.HasValue("x_MaxDipping")) // DN
                    MaxDipping.Visible = false; // Disable update for API request
                else
                    MaxDipping.SetFormValue(val);
            }

            // Check field name 'MaxCapacity' before field var 'x_MaxCapacity'
            val = CurrentForm.HasValue("MaxCapacity") ? CurrentForm.GetValue("MaxCapacity") : CurrentForm.GetValue("x_MaxCapacity");
            if (!MaxCapacity.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MaxCapacity") && !CurrentForm.HasValue("x_MaxCapacity")) // DN
                    MaxCapacity.Visible = false; // Disable update for API request
                else
                    MaxCapacity.SetFormValue(val);
            }

            // Check field name 'UnpumpableQty' before field var 'x_UnpumpableQty'
            val = CurrentForm.HasValue("UnpumpableQty") ? CurrentForm.GetValue("UnpumpableQty") : CurrentForm.GetValue("x_UnpumpableQty");
            if (!UnpumpableQty.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UnpumpableQty") && !CurrentForm.HasValue("x_UnpumpableQty")) // DN
                    UnpumpableQty.Visible = false; // Disable update for API request
                else
                    UnpumpableQty.SetFormValue(val);
            }

            // Check field name 'PumpableQty' before field var 'x_PumpableQty'
            val = CurrentForm.HasValue("PumpableQty") ? CurrentForm.GetValue("PumpableQty") : CurrentForm.GetValue("x_PumpableQty");
            if (!PumpableQty.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PumpableQty") && !CurrentForm.HasValue("x_PumpableQty")) // DN
                    PumpableQty.Visible = false; // Disable update for API request
                else
                    PumpableQty.SetFormValue(val);
            }

            // Check field name 'id' before field var 'x_id'
            val = CurrentForm.HasValue("id") ? CurrentForm.GetValue("id") : CurrentForm.GetValue("x_id");
            if (!id.IsDetailKey)
                id.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            id.CurrentValue = id.FormValue;
            NamaTerminal.CurrentValue = NamaTerminal.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            Sloc.CurrentValue = Sloc.FormValue;
            SeqTangki.CurrentValue = SeqTangki.FormValue;
            MatNo.CurrentValue = MatNo.FormValue;
            TglKalibrasi.CurrentValue = TglKalibrasi.FormValue;
            TglKalibrasi.CurrentValue = UnformatDateTime(TglKalibrasi.CurrentValue, TglKalibrasi.FormatPattern);
            ExpDate.CurrentValue = ExpDate.FormValue;
            ExpDate.CurrentValue = UnformatDateTime(ExpDate.CurrentValue, ExpDate.FormatPattern);
            Status.CurrentValue = Status.FormValue;
            TinggiMejaUk.CurrentValue = TinggiMejaUk.FormValue;
            MaxDipping.CurrentValue = MaxDipping.FormValue;
            MaxCapacity.CurrentValue = MaxCapacity.FormValue;
            UnpumpableQty.CurrentValue = UnpumpableQty.FormValue;
            PumpableQty.CurrentValue = PumpableQty.FormValue;
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
            id.RowCssClass = "row";

            // NamaTerminal
            NamaTerminal.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // Sloc
            Sloc.RowCssClass = "row";

            // SeqTangki
            SeqTangki.RowCssClass = "row";

            // MatNo
            MatNo.RowCssClass = "row";

            // TglKalibrasi
            TglKalibrasi.RowCssClass = "row";

            // ExpDate
            ExpDate.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // TinggiMejaUk
            TinggiMejaUk.RowCssClass = "row";

            // MaxDipping
            MaxDipping.RowCssClass = "row";

            // MaxCapacity
            MaxCapacity.RowCssClass = "row";

            // UnpumpableQty
            UnpumpableQty.RowCssClass = "row";

            // PumpableQty
            PumpableQty.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // NamaTerminal
                NamaTerminal.ViewValue = ConvertToString(NamaTerminal.CurrentValue); // DN
                NamaTerminal.ViewCustomAttributes = "";

                // Plant
                string curVal = ConvertToString(Plant.CurrentValue);
                if (!Empty(curVal)) {
                    if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Plant.ViewValue = Plant.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(Plant.Lookup?.GetTable()?.Fields["Plant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["Plant"].SearchDataType, "");
                        string? sqlWrk = Plant.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                            var listwrk = Plant.Lookup?.RenderViewRow(rswrk[0]);
                            Plant.ViewValue = Plant.DisplayValue(listwrk);
                        } else {
                            Plant.ViewValue = Plant.CurrentValue;
                        }
                    }
                } else {
                    Plant.ViewValue = DbNullValue;
                }
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

                // Plant
                Plant.HrefValue = "";

                // Sloc
                Sloc.HrefValue = "";

                // SeqTangki
                SeqTangki.HrefValue = "";

                // MatNo
                MatNo.HrefValue = "";

                // TglKalibrasi
                TglKalibrasi.HrefValue = "";

                // ExpDate
                ExpDate.HrefValue = "";

                // Status
                Status.HrefValue = "";

                // TinggiMejaUk
                TinggiMejaUk.HrefValue = "";

                // MaxDipping
                MaxDipping.HrefValue = "";

                // MaxCapacity
                MaxCapacity.HrefValue = "";

                // UnpumpableQty
                UnpumpableQty.HrefValue = "";

                // PumpableQty
                PumpableQty.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // NamaTerminal
                NamaTerminal.SetupEditAttributes();
                if (!NamaTerminal.Raw)
                    NamaTerminal.CurrentValue = HtmlDecode(NamaTerminal.CurrentValue);
                NamaTerminal.EditValue = HtmlEncode(NamaTerminal.CurrentValue);
                NamaTerminal.PlaceHolder = RemoveHtml(NamaTerminal.Caption);

                // Plant
                Plant.SetupEditAttributes();
                string curVal = ConvertToString(Plant.CurrentValue);
                if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Plant.EditValue = Plant.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk = "";
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter(Plant.Lookup?.GetTable()?.Fields["Plant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["Plant"].SearchDataType, "");
                    }
                    string? sqlWrk = Plant.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Plant.EditValue = rswrk;
                }
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);

                // Sloc
                Sloc.SetupEditAttributes();
                if (!Sloc.Raw)
                    Sloc.CurrentValue = HtmlDecode(Sloc.CurrentValue);
                Sloc.EditValue = HtmlEncode(Sloc.CurrentValue);
                Sloc.PlaceHolder = RemoveHtml(Sloc.Caption);

                // SeqTangki
                SeqTangki.SetupEditAttributes();
                if (!SeqTangki.Raw)
                    SeqTangki.CurrentValue = HtmlDecode(SeqTangki.CurrentValue);
                SeqTangki.EditValue = HtmlEncode(SeqTangki.CurrentValue);
                SeqTangki.PlaceHolder = RemoveHtml(SeqTangki.Caption);

                // MatNo
                MatNo.SetupEditAttributes();
                if (!MatNo.Raw)
                    MatNo.CurrentValue = HtmlDecode(MatNo.CurrentValue);
                MatNo.EditValue = HtmlEncode(MatNo.CurrentValue);
                MatNo.PlaceHolder = RemoveHtml(MatNo.Caption);

                // TglKalibrasi
                TglKalibrasi.SetupEditAttributes();
                TglKalibrasi.EditValue = FormatDateTime(TglKalibrasi.CurrentValue, TglKalibrasi.FormatPattern);
                TglKalibrasi.PlaceHolder = RemoveHtml(TglKalibrasi.Caption);

                // ExpDate
                ExpDate.SetupEditAttributes();
                ExpDate.EditValue = FormatDateTime(ExpDate.CurrentValue, ExpDate.FormatPattern);
                ExpDate.PlaceHolder = RemoveHtml(ExpDate.Caption);

                // Status
                Status.SetupEditAttributes();
                Status.EditValue = Status.Options(true);
                Status.PlaceHolder = RemoveHtml(Status.Caption);

                // TinggiMejaUk
                TinggiMejaUk.SetupEditAttributes();
                if (!TinggiMejaUk.Raw)
                    TinggiMejaUk.CurrentValue = HtmlDecode(TinggiMejaUk.CurrentValue);
                TinggiMejaUk.EditValue = HtmlEncode(TinggiMejaUk.CurrentValue);
                TinggiMejaUk.PlaceHolder = RemoveHtml(TinggiMejaUk.Caption);

                // MaxDipping
                MaxDipping.SetupEditAttributes();
                if (!MaxDipping.Raw)
                    MaxDipping.CurrentValue = HtmlDecode(MaxDipping.CurrentValue);
                MaxDipping.EditValue = HtmlEncode(MaxDipping.CurrentValue);
                MaxDipping.PlaceHolder = RemoveHtml(MaxDipping.Caption);

                // MaxCapacity
                MaxCapacity.SetupEditAttributes();
                if (!MaxCapacity.Raw)
                    MaxCapacity.CurrentValue = HtmlDecode(MaxCapacity.CurrentValue);
                MaxCapacity.EditValue = HtmlEncode(MaxCapacity.CurrentValue);
                MaxCapacity.PlaceHolder = RemoveHtml(MaxCapacity.Caption);

                // UnpumpableQty
                UnpumpableQty.SetupEditAttributes();
                if (!UnpumpableQty.Raw)
                    UnpumpableQty.CurrentValue = HtmlDecode(UnpumpableQty.CurrentValue);
                UnpumpableQty.EditValue = HtmlEncode(UnpumpableQty.CurrentValue);
                UnpumpableQty.PlaceHolder = RemoveHtml(UnpumpableQty.Caption);

                // PumpableQty
                PumpableQty.SetupEditAttributes();
                if (!PumpableQty.Raw)
                    PumpableQty.CurrentValue = HtmlDecode(PumpableQty.CurrentValue);
                PumpableQty.EditValue = HtmlEncode(PumpableQty.CurrentValue);
                PumpableQty.PlaceHolder = RemoveHtml(PumpableQty.Caption);

                // Edit refer script

                // NamaTerminal
                NamaTerminal.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // Sloc
                Sloc.HrefValue = "";

                // SeqTangki
                SeqTangki.HrefValue = "";

                // MatNo
                MatNo.HrefValue = "";

                // TglKalibrasi
                TglKalibrasi.HrefValue = "";

                // ExpDate
                ExpDate.HrefValue = "";

                // Status
                Status.HrefValue = "";

                // TinggiMejaUk
                TinggiMejaUk.HrefValue = "";

                // MaxDipping
                MaxDipping.HrefValue = "";

                // MaxCapacity
                MaxCapacity.HrefValue = "";

                // UnpumpableQty
                UnpumpableQty.HrefValue = "";

                // PumpableQty
                PumpableQty.HrefValue = "";
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
                if (NamaTerminal.Visible && NamaTerminal.Required) {
                    if (!NamaTerminal.IsDetailKey && Empty(NamaTerminal.FormValue)) {
                        NamaTerminal.AddErrorMessage(ConvertToString(NamaTerminal.RequiredErrorMessage).Replace("%s", NamaTerminal.Caption));
                    }
                }
                if (Plant.Visible && Plant.Required) {
                    if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                        Plant.AddErrorMessage(ConvertToString(Plant.RequiredErrorMessage).Replace("%s", Plant.Caption));
                    }
                }
                if (Sloc.Visible && Sloc.Required) {
                    if (!Sloc.IsDetailKey && Empty(Sloc.FormValue)) {
                        Sloc.AddErrorMessage(ConvertToString(Sloc.RequiredErrorMessage).Replace("%s", Sloc.Caption));
                    }
                }
                if (SeqTangki.Visible && SeqTangki.Required) {
                    if (!SeqTangki.IsDetailKey && Empty(SeqTangki.FormValue)) {
                        SeqTangki.AddErrorMessage(ConvertToString(SeqTangki.RequiredErrorMessage).Replace("%s", SeqTangki.Caption));
                    }
                }
                if (MatNo.Visible && MatNo.Required) {
                    if (!MatNo.IsDetailKey && Empty(MatNo.FormValue)) {
                        MatNo.AddErrorMessage(ConvertToString(MatNo.RequiredErrorMessage).Replace("%s", MatNo.Caption));
                    }
                }
                if (TglKalibrasi.Visible && TglKalibrasi.Required) {
                    if (!TglKalibrasi.IsDetailKey && Empty(TglKalibrasi.FormValue)) {
                        TglKalibrasi.AddErrorMessage(ConvertToString(TglKalibrasi.RequiredErrorMessage).Replace("%s", TglKalibrasi.Caption));
                    }
                }
                if (!CheckDate(TglKalibrasi.FormValue, TglKalibrasi.FormatPattern)) {
                    TglKalibrasi.AddErrorMessage(TglKalibrasi.GetErrorMessage(false));
                }
                if (ExpDate.Visible && ExpDate.Required) {
                    if (!ExpDate.IsDetailKey && Empty(ExpDate.FormValue)) {
                        ExpDate.AddErrorMessage(ConvertToString(ExpDate.RequiredErrorMessage).Replace("%s", ExpDate.Caption));
                    }
                }
                if (!CheckDate(ExpDate.FormValue, ExpDate.FormatPattern)) {
                    ExpDate.AddErrorMessage(ExpDate.GetErrorMessage(false));
                }
                if (Status.Visible && Status.Required) {
                    if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                        Status.AddErrorMessage(ConvertToString(Status.RequiredErrorMessage).Replace("%s", Status.Caption));
                    }
                }
                if (TinggiMejaUk.Visible && TinggiMejaUk.Required) {
                    if (!TinggiMejaUk.IsDetailKey && Empty(TinggiMejaUk.FormValue)) {
                        TinggiMejaUk.AddErrorMessage(ConvertToString(TinggiMejaUk.RequiredErrorMessage).Replace("%s", TinggiMejaUk.Caption));
                    }
                }
                if (MaxDipping.Visible && MaxDipping.Required) {
                    if (!MaxDipping.IsDetailKey && Empty(MaxDipping.FormValue)) {
                        MaxDipping.AddErrorMessage(ConvertToString(MaxDipping.RequiredErrorMessage).Replace("%s", MaxDipping.Caption));
                    }
                }
                if (MaxCapacity.Visible && MaxCapacity.Required) {
                    if (!MaxCapacity.IsDetailKey && Empty(MaxCapacity.FormValue)) {
                        MaxCapacity.AddErrorMessage(ConvertToString(MaxCapacity.RequiredErrorMessage).Replace("%s", MaxCapacity.Caption));
                    }
                }
                if (UnpumpableQty.Visible && UnpumpableQty.Required) {
                    if (!UnpumpableQty.IsDetailKey && Empty(UnpumpableQty.FormValue)) {
                        UnpumpableQty.AddErrorMessage(ConvertToString(UnpumpableQty.RequiredErrorMessage).Replace("%s", UnpumpableQty.Caption));
                    }
                }
                if (PumpableQty.Visible && PumpableQty.Required) {
                    if (!PumpableQty.IsDetailKey && Empty(PumpableQty.FormValue)) {
                        PumpableQty.AddErrorMessage(ConvertToString(PumpableQty.RequiredErrorMessage).Replace("%s", PumpableQty.Caption));
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

            // NamaTerminal
            NamaTerminal.SetDbValue(rsnew, NamaTerminal.CurrentValue, NamaTerminal.ReadOnly);

            // Plant
            Plant.SetDbValue(rsnew, Plant.CurrentValue, Plant.ReadOnly);

            // Sloc
            Sloc.SetDbValue(rsnew, Sloc.CurrentValue, Sloc.ReadOnly);

            // SeqTangki
            SeqTangki.SetDbValue(rsnew, SeqTangki.CurrentValue, SeqTangki.ReadOnly);

            // MatNo
            MatNo.SetDbValue(rsnew, MatNo.CurrentValue, MatNo.ReadOnly);

            // TglKalibrasi
            TglKalibrasi.SetDbValue(rsnew, ConvertToDateTime(TglKalibrasi.CurrentValue, TglKalibrasi.FormatPattern), TglKalibrasi.ReadOnly);

            // ExpDate
            ExpDate.SetDbValue(rsnew, ConvertToDateTime(ExpDate.CurrentValue, ExpDate.FormatPattern), ExpDate.ReadOnly);

            // Status
            Status.SetDbValue(rsnew, Status.CurrentValue, Status.ReadOnly);

            // TinggiMejaUk
            TinggiMejaUk.SetDbValue(rsnew, TinggiMejaUk.CurrentValue, TinggiMejaUk.ReadOnly);

            // MaxDipping
            MaxDipping.SetDbValue(rsnew, MaxDipping.CurrentValue, MaxDipping.ReadOnly);

            // MaxCapacity
            MaxCapacity.SetDbValue(rsnew, MaxCapacity.CurrentValue, MaxCapacity.ReadOnly);

            // UnpumpableQty
            UnpumpableQty.SetDbValue(rsnew, UnpumpableQty.CurrentValue, UnpumpableQty.ReadOnly);

            // PumpableQty
            PumpableQty.SetDbValue(rsnew, PumpableQty.CurrentValue, PumpableQty.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("NamaTerminal", out value)) // NamaTerminal
                NamaTerminal.CurrentValue = value;
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.CurrentValue = value;
            if (row.TryGetValue("Sloc", out value)) // Sloc
                Sloc.CurrentValue = value;
            if (row.TryGetValue("SeqTangki", out value)) // SeqTangki
                SeqTangki.CurrentValue = value;
            if (row.TryGetValue("MatNo", out value)) // MatNo
                MatNo.CurrentValue = value;
            if (row.TryGetValue("TglKalibrasi", out value)) // TglKalibrasi
                TglKalibrasi.CurrentValue = value;
            if (row.TryGetValue("ExpDate", out value)) // ExpDate
                ExpDate.CurrentValue = value;
            if (row.TryGetValue("Status", out value)) // Status
                Status.CurrentValue = value;
            if (row.TryGetValue("TinggiMejaUk", out value)) // TinggiMejaUk
                TinggiMejaUk.CurrentValue = value;
            if (row.TryGetValue("MaxDipping", out value)) // MaxDipping
                MaxDipping.CurrentValue = value;
            if (row.TryGetValue("MaxCapacity", out value)) // MaxCapacity
                MaxCapacity.CurrentValue = value;
            if (row.TryGetValue("UnpumpableQty", out value)) // UnpumpableQty
                UnpumpableQty.CurrentValue = value;
            if (row.TryGetValue("PumpableQty", out value)) // PumpableQty
                PumpableQty.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterTangkiList")), "", TableVar, true);
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
