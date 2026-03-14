namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// mwtOnlineEdit
    /// </summary>
    public static MwtOnlineEdit mwtOnlineEdit
    {
        get => HttpData.Get<MwtOnlineEdit>("mwtOnlineEdit")!;
        set => HttpData["mwtOnlineEdit"] = value;
    }

    /// <summary>
    /// Page class for MWTOnline
    /// </summary>
    public class MwtOnlineEdit : MwtOnlineEditBase
    {
        // Constructor
        public MwtOnlineEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MwtOnlineEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            IdPlant.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MwtOnlineEditBase : MwtOnline
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "mwtOnlineEdit";

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
        public MwtOnlineEditBase()
        {
            TableName = "MWTOnline";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (mwtOnline)
            if (mwtOnline == null || mwtOnline is MwtOnline)
                mwtOnline = this;

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
        public string PageName => "MwtOnlineEdit";

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
            Id.Visible = false;
            NoMWTOnline.SetVisibility();
            LinkRedirect.Visible = false;
            LookupPlant.Visible = false;
            IdPlant.SetVisibility();
            TaskList.SetVisibility();
            Status.SetVisibility();
            _File.SetVisibility();
            DownloadFile.SetVisibility();
            KeteranganFile.Visible = false;
            StatusEmail.SetVisibility();
            CreatedBy.SetVisibility();
            CreatedDate.Visible = false;
            LastUpdatedBy.SetVisibility();
            LastUpdatedDate.SetVisibility();
            CompletedBy.SetVisibility();
            CompletedDate.SetVisibility();
        }

        // Constructor
        public MwtOnlineEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "MwtOnlineView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("Id") ? dict["Id"] : Id.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
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
            await SetupLookupOptions(LookupPlant);
            await SetupLookupOptions(IdPlant);

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
                if (RouteValues.TryGetValue("Id", out rv)) { // DN
                    Id.FormValue = UrlDecode(rv); // DN
                    Id.OldValue = Id.FormValue;
                } else if (CurrentForm.HasValue("x_Id")) {
                    Id.FormValue = CurrentForm.GetValue("x_Id");
                    Id.OldValue = Id.FormValue;
                } else if (!Empty(keyValues)) {
                    Id.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("Id", out rv)) { // DN
                        Id.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("Id", out sv)) {
                        Id.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        Id.CurrentValue = DbNullValue;
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
                Id.FormValue = ConvertToString(keyValues[0]);
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
                            return Terminate("MwtOnlineList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "MwtOnlineList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MwtOnlineList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MwtOnlineList"; // Return list page content
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
                mwtOnlineEdit?.PageRender();
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

            // Check field name 'NoMWTOnline' before field var 'x_NoMWTOnline'
            val = CurrentForm.HasValue("NoMWTOnline") ? CurrentForm.GetValue("NoMWTOnline") : CurrentForm.GetValue("x_NoMWTOnline");
            if (!NoMWTOnline.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoMWTOnline") && !CurrentForm.HasValue("x_NoMWTOnline")) // DN
                    NoMWTOnline.Visible = false; // Disable update for API request
                else
                    NoMWTOnline.SetFormValue(val);
            }

            // Check field name 'IdPlant' before field var 'x_IdPlant'
            val = CurrentForm.HasValue("IdPlant") ? CurrentForm.GetValue("IdPlant") : CurrentForm.GetValue("x_IdPlant");
            if (!IdPlant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPlant") && !CurrentForm.HasValue("x_IdPlant")) // DN
                    IdPlant.Visible = false; // Disable update for API request
                else
                    IdPlant.SetFormValue(val);
            }

            // Check field name 'TaskList' before field var 'x_TaskList'
            val = CurrentForm.HasValue("TaskList") ? CurrentForm.GetValue("TaskList") : CurrentForm.GetValue("x_TaskList");
            if (!TaskList.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TaskList") && !CurrentForm.HasValue("x_TaskList")) // DN
                    TaskList.Visible = false; // Disable update for API request
                else
                    TaskList.SetFormValue(val);
            }

            // Check field name 'Status' before field var 'x_Status'
            val = CurrentForm.HasValue("Status") ? CurrentForm.GetValue("Status") : CurrentForm.GetValue("x_Status");
            if (!Status.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Status") && !CurrentForm.HasValue("x_Status")) // DN
                    Status.Visible = false; // Disable update for API request
                else
                    Status.SetFormValue(val);
            }

            // Check field name 'File' before field var 'x__File'
            val = CurrentForm.HasValue("File") ? CurrentForm.GetValue("File") : CurrentForm.GetValue("x__File");
            if (!_File.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("File") && !CurrentForm.HasValue("x__File")) // DN
                    _File.Visible = false; // Disable update for API request
                else
                    _File.SetFormValue(val);
            }

            // Check field name 'DownloadFile' before field var 'x_DownloadFile'
            val = CurrentForm.HasValue("DownloadFile") ? CurrentForm.GetValue("DownloadFile") : CurrentForm.GetValue("x_DownloadFile");
            if (!DownloadFile.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DownloadFile") && !CurrentForm.HasValue("x_DownloadFile")) // DN
                    DownloadFile.Visible = false; // Disable update for API request
                else
                    DownloadFile.SetFormValue(val);
            }

            // Check field name 'StatusEmail' before field var 'x_StatusEmail'
            val = CurrentForm.HasValue("StatusEmail") ? CurrentForm.GetValue("StatusEmail") : CurrentForm.GetValue("x_StatusEmail");
            if (!StatusEmail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusEmail") && !CurrentForm.HasValue("x_StatusEmail")) // DN
                    StatusEmail.Visible = false; // Disable update for API request
                else
                    StatusEmail.SetFormValue(val);
            }

            // Check field name 'CreatedBy' before field var 'x_CreatedBy'
            val = CurrentForm.HasValue("CreatedBy") ? CurrentForm.GetValue("CreatedBy") : CurrentForm.GetValue("x_CreatedBy");
            if (!CreatedBy.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CreatedBy") && !CurrentForm.HasValue("x_CreatedBy")) // DN
                    CreatedBy.Visible = false; // Disable update for API request
                else
                    CreatedBy.SetFormValue(val);
            }

            // Check field name 'LastUpdatedBy' before field var 'x_LastUpdatedBy'
            val = CurrentForm.HasValue("LastUpdatedBy") ? CurrentForm.GetValue("LastUpdatedBy") : CurrentForm.GetValue("x_LastUpdatedBy");
            if (!LastUpdatedBy.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LastUpdatedBy") && !CurrentForm.HasValue("x_LastUpdatedBy")) // DN
                    LastUpdatedBy.Visible = false; // Disable update for API request
                else
                    LastUpdatedBy.SetFormValue(val);
            }

            // Check field name 'LastUpdatedDate' before field var 'x_LastUpdatedDate'
            val = CurrentForm.HasValue("LastUpdatedDate") ? CurrentForm.GetValue("LastUpdatedDate") : CurrentForm.GetValue("x_LastUpdatedDate");
            if (!LastUpdatedDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LastUpdatedDate") && !CurrentForm.HasValue("x_LastUpdatedDate")) // DN
                    LastUpdatedDate.Visible = false; // Disable update for API request
                else
                    LastUpdatedDate.SetFormValue(val);
                LastUpdatedDate.CurrentValue = UnformatDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern);
            }

            // Check field name 'CompletedBy' before field var 'x_CompletedBy'
            val = CurrentForm.HasValue("CompletedBy") ? CurrentForm.GetValue("CompletedBy") : CurrentForm.GetValue("x_CompletedBy");
            if (!CompletedBy.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CompletedBy") && !CurrentForm.HasValue("x_CompletedBy")) // DN
                    CompletedBy.Visible = false; // Disable update for API request
                else
                    CompletedBy.SetFormValue(val);
            }

            // Check field name 'CompletedDate' before field var 'x_CompletedDate'
            val = CurrentForm.HasValue("CompletedDate") ? CurrentForm.GetValue("CompletedDate") : CurrentForm.GetValue("x_CompletedDate");
            if (!CompletedDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CompletedDate") && !CurrentForm.HasValue("x_CompletedDate")) // DN
                    CompletedDate.Visible = false; // Disable update for API request
                else
                    CompletedDate.SetFormValue(val);
                CompletedDate.CurrentValue = UnformatDateTime(CompletedDate.CurrentValue, CompletedDate.FormatPattern);
            }

            // Check field name 'Id' before field var 'x_Id'
            val = CurrentForm.HasValue("Id") ? CurrentForm.GetValue("Id") : CurrentForm.GetValue("x_Id");
            if (!Id.IsDetailKey)
                Id.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            Id.CurrentValue = Id.FormValue;
            NoMWTOnline.CurrentValue = NoMWTOnline.FormValue;
            IdPlant.CurrentValue = IdPlant.FormValue;
            TaskList.CurrentValue = TaskList.FormValue;
            Status.CurrentValue = Status.FormValue;
            _File.CurrentValue = _File.FormValue;
            DownloadFile.CurrentValue = DownloadFile.FormValue;
            StatusEmail.CurrentValue = StatusEmail.FormValue;
            CreatedBy.CurrentValue = CreatedBy.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            LastUpdatedDate.CurrentValue = LastUpdatedDate.FormValue;
            LastUpdatedDate.CurrentValue = UnformatDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern);
            CompletedBy.CurrentValue = CompletedBy.FormValue;
            CompletedDate.CurrentValue = CompletedDate.FormValue;
            CompletedDate.CurrentValue = UnformatDateTime(CompletedDate.CurrentValue, CompletedDate.FormatPattern);
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
            Id.SetDbValue(row["Id"]);
            NoMWTOnline.SetDbValue(row["NoMWTOnline"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            TaskList.SetDbValue(row["TaskList"]);
            Status.SetDbValue(row["Status"]);
            _File.SetDbValue(row["File"]);
            DownloadFile.SetDbValue(row["DownloadFile"]);
            KeteranganFile.SetDbValue(row["KeteranganFile"]);
            StatusEmail.SetDbValue(row["StatusEmail"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            CreatedDate.SetDbValue(row["CreatedDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDate.SetDbValue(row["LastUpdatedDate"]);
            CompletedBy.SetDbValue(row["CompletedBy"]);
            CompletedDate.SetDbValue(row["CompletedDate"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("Id", Id.DefaultValue ?? DbNullValue); // DN
            row.Add("NoMWTOnline", NoMWTOnline.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("TaskList", TaskList.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("File", _File.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadFile", DownloadFile.DefaultValue ?? DbNullValue); // DN
            row.Add("KeteranganFile", KeteranganFile.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusEmail", StatusEmail.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDate", CreatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDate", LastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("CompletedBy", CompletedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("CompletedDate", CompletedDate.DefaultValue ?? DbNullValue); // DN
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

            // Id
            Id.RowCssClass = "row";

            // NoMWTOnline
            NoMWTOnline.RowCssClass = "row";

            // LinkRedirect
            LinkRedirect.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // TaskList
            TaskList.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // File
            _File.RowCssClass = "row";

            // DownloadFile
            DownloadFile.RowCssClass = "row";

            // KeteranganFile
            KeteranganFile.RowCssClass = "row";

            // StatusEmail
            StatusEmail.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // CreatedDate
            CreatedDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // LastUpdatedDate
            LastUpdatedDate.RowCssClass = "row";

            // CompletedBy
            CompletedBy.RowCssClass = "row";

            // CompletedDate
            CompletedDate.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // NoMWTOnline
                NoMWTOnline.ViewValue = ConvertToString(NoMWTOnline.CurrentValue); // DN
                NoMWTOnline.ViewCustomAttributes = "";

                // IdPlant
                IdPlant.ViewValue = IdPlant.CurrentValue;
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

                // TaskList
                TaskList.ViewValue = TaskList.CurrentValue;
                TaskList.ViewCustomAttributes = "";

                // Status
                Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // File
                _File.ViewValue = ConvertToString(_File.CurrentValue); // DN
                _File.ViewCustomAttributes = "";

                // DownloadFile
                DownloadFile.ViewValue = ConvertToString(DownloadFile.CurrentValue); // DN
                DownloadFile.ViewCustomAttributes = "";

                // StatusEmail
                StatusEmail.ViewValue = ConvertToString(StatusEmail.CurrentValue); // DN
                StatusEmail.ViewCustomAttributes = "";

                // CreatedBy
                CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
                CreatedBy.ViewCustomAttributes = "";

                // CreatedDate
                CreatedDate.ViewValue = CreatedDate.CurrentValue;
                CreatedDate.ViewValue = FormatDateTime(CreatedDate.ViewValue, CreatedDate.FormatPattern);
                CreatedDate.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // LastUpdatedDate
                LastUpdatedDate.ViewValue = LastUpdatedDate.CurrentValue;
                LastUpdatedDate.ViewValue = FormatDateTime(LastUpdatedDate.ViewValue, LastUpdatedDate.FormatPattern);
                LastUpdatedDate.ViewCustomAttributes = "";

                // CompletedBy
                CompletedBy.ViewValue = ConvertToString(CompletedBy.CurrentValue); // DN
                CompletedBy.ViewCustomAttributes = "";

                // CompletedDate
                CompletedDate.ViewValue = CompletedDate.CurrentValue;
                CompletedDate.ViewValue = FormatDateTime(CompletedDate.ViewValue, CompletedDate.FormatPattern);
                CompletedDate.ViewCustomAttributes = "";

                // NoMWTOnline
                NoMWTOnline.HrefValue = "";
                NoMWTOnline.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // TaskList
                TaskList.HrefValue = "";
                TaskList.TooltipValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // File
                _File.HrefValue = "";

                // DownloadFile
                DownloadFile.HrefValue = "";

                // StatusEmail
                StatusEmail.HrefValue = "";
                StatusEmail.TooltipValue = "";

                // CreatedBy
                CreatedBy.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // LastUpdatedDate
                LastUpdatedDate.HrefValue = "";
                LastUpdatedDate.TooltipValue = "";

                // CompletedBy
                CompletedBy.HrefValue = "";
                CompletedBy.TooltipValue = "";

                // CompletedDate
                CompletedDate.HrefValue = "";
                CompletedDate.TooltipValue = "";
            } else if (RowType == RowType.Edit) {
                // NoMWTOnline
                NoMWTOnline.SetupEditAttributes();
                NoMWTOnline.EditValue = ConvertToString(NoMWTOnline.CurrentValue); // DN
                NoMWTOnline.ViewCustomAttributes = "";

                // IdPlant
                IdPlant.SetupEditAttributes();
                IdPlant.EditValue = IdPlant.CurrentValue;
                string curVal2 = ConvertToString(IdPlant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (IdPlant.Lookup != null && IsDictionary(IdPlant.Lookup?.Options) && IdPlant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPlant.EditValue = IdPlant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", IdPlant.CurrentValue, IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = IdPlant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && IdPlant.Lookup != null) { // Lookup values found
                            var listwrk = IdPlant.Lookup?.RenderViewRow(rswrk2[0]);
                            IdPlant.EditValue = IdPlant.DisplayValue(listwrk);
                        } else {
                            IdPlant.EditValue = FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
                        }
                    }
                } else {
                    IdPlant.EditValue = DbNullValue;
                }
                IdPlant.ViewCustomAttributes = "";

                // TaskList
                TaskList.SetupEditAttributes();
                TaskList.EditValue = TaskList.CurrentValue;
                TaskList.ViewCustomAttributes = "";

                // Status
                Status.SetupEditAttributes();
                Status.EditValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // File
                _File.SetupEditAttributes();
                if (!_File.Raw)
                    _File.CurrentValue = HtmlDecode(_File.CurrentValue);
                _File.EditValue = HtmlEncode(_File.CurrentValue);
                _File.PlaceHolder = RemoveHtml(_File.Caption);

                // DownloadFile
                DownloadFile.SetupEditAttributes();
                if (!DownloadFile.Raw)
                    DownloadFile.CurrentValue = HtmlDecode(DownloadFile.CurrentValue);
                DownloadFile.EditValue = HtmlEncode(DownloadFile.CurrentValue);
                DownloadFile.PlaceHolder = RemoveHtml(DownloadFile.Caption);

                // StatusEmail
                StatusEmail.SetupEditAttributes();
                StatusEmail.EditValue = ConvertToString(StatusEmail.CurrentValue); // DN
                StatusEmail.ViewCustomAttributes = "";

                // CreatedBy

                // LastUpdatedBy

                // LastUpdatedDate

                // CompletedBy
                CompletedBy.SetupEditAttributes();
                CompletedBy.EditValue = ConvertToString(CompletedBy.CurrentValue); // DN
                CompletedBy.ViewCustomAttributes = "";

                // CompletedDate
                CompletedDate.SetupEditAttributes();
                CompletedDate.EditValue = CompletedDate.CurrentValue;
                CompletedDate.EditValue = FormatDateTime(CompletedDate.EditValue, CompletedDate.FormatPattern);
                CompletedDate.ViewCustomAttributes = "";

                // Edit refer script

                // NoMWTOnline
                NoMWTOnline.HrefValue = "";
                NoMWTOnline.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // TaskList
                TaskList.HrefValue = "";
                TaskList.TooltipValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // File
                _File.HrefValue = "";

                // DownloadFile
                DownloadFile.HrefValue = "";

                // StatusEmail
                StatusEmail.HrefValue = "";
                StatusEmail.TooltipValue = "";

                // CreatedBy
                CreatedBy.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // LastUpdatedDate
                LastUpdatedDate.HrefValue = "";
                LastUpdatedDate.TooltipValue = "";

                // CompletedBy
                CompletedBy.HrefValue = "";
                CompletedBy.TooltipValue = "";

                // CompletedDate
                CompletedDate.HrefValue = "";
                CompletedDate.TooltipValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();

            // Save data for Custom Template
            if (RowType == RowType.View || RowType == RowType.Edit || RowType == RowType.Add)
                Rows.Add(CustomTemplateFieldValues());
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                if (NoMWTOnline.Visible && NoMWTOnline.Required) {
                    if (!NoMWTOnline.IsDetailKey && Empty(NoMWTOnline.FormValue)) {
                        NoMWTOnline.AddErrorMessage(ConvertToString(NoMWTOnline.RequiredErrorMessage).Replace("%s", NoMWTOnline.Caption));
                    }
                }
                if (IdPlant.Visible && IdPlant.Required) {
                    if (!IdPlant.IsDetailKey && Empty(IdPlant.FormValue)) {
                        IdPlant.AddErrorMessage(ConvertToString(IdPlant.RequiredErrorMessage).Replace("%s", IdPlant.Caption));
                    }
                }
                if (TaskList.Visible && TaskList.Required) {
                    if (!TaskList.IsDetailKey && Empty(TaskList.FormValue)) {
                        TaskList.AddErrorMessage(ConvertToString(TaskList.RequiredErrorMessage).Replace("%s", TaskList.Caption));
                    }
                }
                if (Status.Visible && Status.Required) {
                    if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                        Status.AddErrorMessage(ConvertToString(Status.RequiredErrorMessage).Replace("%s", Status.Caption));
                    }
                }
                if (_File.Visible && _File.Required) {
                    if (!_File.IsDetailKey && Empty(_File.FormValue)) {
                        _File.AddErrorMessage(ConvertToString(_File.RequiredErrorMessage).Replace("%s", _File.Caption));
                    }
                }
                if (DownloadFile.Visible && DownloadFile.Required) {
                    if (!DownloadFile.IsDetailKey && Empty(DownloadFile.FormValue)) {
                        DownloadFile.AddErrorMessage(ConvertToString(DownloadFile.RequiredErrorMessage).Replace("%s", DownloadFile.Caption));
                    }
                }
                if (StatusEmail.Visible && StatusEmail.Required) {
                    if (!StatusEmail.IsDetailKey && Empty(StatusEmail.FormValue)) {
                        StatusEmail.AddErrorMessage(ConvertToString(StatusEmail.RequiredErrorMessage).Replace("%s", StatusEmail.Caption));
                    }
                }
                if (CreatedBy.Visible && CreatedBy.Required) {
                    if (!CreatedBy.IsDetailKey && Empty(CreatedBy.FormValue)) {
                        CreatedBy.AddErrorMessage(ConvertToString(CreatedBy.RequiredErrorMessage).Replace("%s", CreatedBy.Caption));
                    }
                }
                if (LastUpdatedBy.Visible && LastUpdatedBy.Required) {
                    if (!LastUpdatedBy.IsDetailKey && Empty(LastUpdatedBy.FormValue)) {
                        LastUpdatedBy.AddErrorMessage(ConvertToString(LastUpdatedBy.RequiredErrorMessage).Replace("%s", LastUpdatedBy.Caption));
                    }
                }
                if (LastUpdatedDate.Visible && LastUpdatedDate.Required) {
                    if (!LastUpdatedDate.IsDetailKey && Empty(LastUpdatedDate.FormValue)) {
                        LastUpdatedDate.AddErrorMessage(ConvertToString(LastUpdatedDate.RequiredErrorMessage).Replace("%s", LastUpdatedDate.Caption));
                    }
                }
                if (CompletedBy.Visible && CompletedBy.Required) {
                    if (!CompletedBy.IsDetailKey && Empty(CompletedBy.FormValue)) {
                        CompletedBy.AddErrorMessage(ConvertToString(CompletedBy.RequiredErrorMessage).Replace("%s", CompletedBy.Caption));
                    }
                }
                if (CompletedDate.Visible && CompletedDate.Required) {
                    if (!CompletedDate.IsDetailKey && Empty(CompletedDate.FormValue)) {
                        CompletedDate.AddErrorMessage(ConvertToString(CompletedDate.RequiredErrorMessage).Replace("%s", CompletedDate.Caption));
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

            // File
            _File.SetDbValue(rsnew, _File.CurrentValue, _File.ReadOnly);

            // DownloadFile
            DownloadFile.SetDbValue(rsnew, DownloadFile.CurrentValue, DownloadFile.ReadOnly);

            // CreatedBy
            CreatedBy.CurrentValue = CreatedBy.GetAutoUpdateValue();
            CreatedBy.SetDbValue(rsnew, CreatedBy.CurrentValue, CreatedBy.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("File", out value)) // File
                _File.CurrentValue = value;
            if (row.TryGetValue("DownloadFile", out value)) // DownloadFile
                DownloadFile.CurrentValue = value;
            if (row.TryGetValue("CreatedBy", out value)) // CreatedBy
                CreatedBy.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MwtOnlineList")), "", TableVar, true);
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
