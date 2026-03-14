namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// vFaceEnrollmentEdit
    /// </summary>
    public static VFaceEnrollmentEdit vFaceEnrollmentEdit
    {
        get => HttpData.Get<VFaceEnrollmentEdit>("vFaceEnrollmentEdit")!;
        set => HttpData["vFaceEnrollmentEdit"] = value;
    }

    /// <summary>
    /// Page class for VFaceEnrollment
    /// </summary>
    public class VFaceEnrollmentEdit : VFaceEnrollmentEditBase
    {
        // Constructor
        public VFaceEnrollmentEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VFaceEnrollmentEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VFaceEnrollmentEditBase : VFaceEnrollment
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "vFaceEnrollmentEdit";

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
        public VFaceEnrollmentEditBase()
        {
            TableName = "VFaceEnrollment";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (vFaceEnrollment)
            if (vFaceEnrollment == null || vFaceEnrollment is VFaceEnrollment)
                vFaceEnrollment = this;

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
        public string PageName => "VFaceEnrollmentEdit";

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
            IdUser.SetVisibility();
            _Username.SetVisibility();
            LinkRedirect.SetVisibility();
            _Email.SetVisibility();
            NamaLengkap.SetVisibility();
            DownloadFace.SetVisibility();
            IdPosition.SetVisibility();
            Jabatan.SetVisibility();
            Face.SetVisibility();
            TanggalInputFace.SetVisibility();
            UserInputFace.SetVisibility();
            AzurePersonId.SetVisibility();
        }

        // Constructor
        public VFaceEnrollmentEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "VFaceEnrollmentView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdUser") ? dict["IdUser"] : IdUser.CurrentValue));
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
            _Username.Required = false;

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
            await SetupLookupOptions(IdPosition);

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
                if (RouteValues.TryGetValue("IdUser", out rv)) { // DN
                    IdUser.FormValue = UrlDecode(rv); // DN
                    IdUser.OldValue = IdUser.FormValue;
                } else if (CurrentForm.HasValue("x_IdUser")) {
                    IdUser.FormValue = CurrentForm.GetValue("x_IdUser");
                    IdUser.OldValue = IdUser.FormValue;
                } else if (!Empty(keyValues)) {
                    IdUser.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("IdUser", out rv)) { // DN
                        IdUser.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("IdUser", out sv)) {
                        IdUser.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdUser.CurrentValue = DbNullValue;
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
                IdUser.FormValue = ConvertToString(keyValues[0]);
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
                            return Terminate("VFaceEnrollmentList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "VFaceEnrollmentList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "VFaceEnrollmentList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "VFaceEnrollmentList"; // Return list page content
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
                vFaceEnrollmentEdit?.PageRender();
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

            // Check field name 'IdUser' before field var 'x_IdUser'
            val = CurrentForm.HasValue("IdUser") ? CurrentForm.GetValue("IdUser") : CurrentForm.GetValue("x_IdUser");
            if (!IdUser.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdUser") && !CurrentForm.HasValue("x_IdUser")) // DN
                    IdUser.Visible = false; // Disable update for API request
                else
                    IdUser.SetFormValue(val, true, validate);
            }
            if (CurrentForm.HasValue("o_IdUser"))
                IdUser.OldValue = CurrentForm.GetValue("o_IdUser");

            // Check field name 'Username' before field var 'x__Username'
            val = CurrentForm.HasValue("Username") ? CurrentForm.GetValue("Username") : CurrentForm.GetValue("x__Username");
            if (!_Username.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Username") && !CurrentForm.HasValue("x__Username")) // DN
                    _Username.Visible = false; // Disable update for API request
                else
                    _Username.SetFormValue(val);
            }

            // Check field name 'LinkRedirect' before field var 'x_LinkRedirect'
            val = CurrentForm.HasValue("LinkRedirect") ? CurrentForm.GetValue("LinkRedirect") : CurrentForm.GetValue("x_LinkRedirect");
            if (!LinkRedirect.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LinkRedirect") && !CurrentForm.HasValue("x_LinkRedirect")) // DN
                    LinkRedirect.Visible = false; // Disable update for API request
                else
                    LinkRedirect.SetFormValue(val);
            }

            // Check field name 'Email' before field var 'x__Email'
            val = CurrentForm.HasValue("Email") ? CurrentForm.GetValue("Email") : CurrentForm.GetValue("x__Email");
            if (!_Email.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Email") && !CurrentForm.HasValue("x__Email")) // DN
                    _Email.Visible = false; // Disable update for API request
                else
                    _Email.SetFormValue(val);
            }

            // Check field name 'NamaLengkap' before field var 'x_NamaLengkap'
            val = CurrentForm.HasValue("NamaLengkap") ? CurrentForm.GetValue("NamaLengkap") : CurrentForm.GetValue("x_NamaLengkap");
            if (!NamaLengkap.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaLengkap") && !CurrentForm.HasValue("x_NamaLengkap")) // DN
                    NamaLengkap.Visible = false; // Disable update for API request
                else
                    NamaLengkap.SetFormValue(val);
            }

            // Check field name 'DownloadFace' before field var 'x_DownloadFace'
            val = CurrentForm.HasValue("DownloadFace") ? CurrentForm.GetValue("DownloadFace") : CurrentForm.GetValue("x_DownloadFace");
            if (!DownloadFace.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DownloadFace") && !CurrentForm.HasValue("x_DownloadFace")) // DN
                    DownloadFace.Visible = false; // Disable update for API request
                else
                    DownloadFace.SetFormValue(val);
            }

            // Check field name 'IdPosition' before field var 'x_IdPosition'
            val = CurrentForm.HasValue("IdPosition") ? CurrentForm.GetValue("IdPosition") : CurrentForm.GetValue("x_IdPosition");
            if (!IdPosition.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPosition") && !CurrentForm.HasValue("x_IdPosition")) // DN
                    IdPosition.Visible = false; // Disable update for API request
                else
                    IdPosition.SetFormValue(val, true, validate);
            }

            // Check field name 'Jabatan' before field var 'x_Jabatan'
            val = CurrentForm.HasValue("Jabatan") ? CurrentForm.GetValue("Jabatan") : CurrentForm.GetValue("x_Jabatan");
            if (!Jabatan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Jabatan") && !CurrentForm.HasValue("x_Jabatan")) // DN
                    Jabatan.Visible = false; // Disable update for API request
                else
                    Jabatan.SetFormValue(val);
            }

            // Check field name 'Face' before field var 'x_Face'
            val = CurrentForm.HasValue("Face") ? CurrentForm.GetValue("Face") : CurrentForm.GetValue("x_Face");
            if (!Face.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Face") && !CurrentForm.HasValue("x_Face")) // DN
                    Face.Visible = false; // Disable update for API request
                else
                    Face.SetFormValue(val);
            }

            // Check field name 'TanggalInputFace' before field var 'x_TanggalInputFace'
            val = CurrentForm.HasValue("TanggalInputFace") ? CurrentForm.GetValue("TanggalInputFace") : CurrentForm.GetValue("x_TanggalInputFace");
            if (!TanggalInputFace.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalInputFace") && !CurrentForm.HasValue("x_TanggalInputFace")) // DN
                    TanggalInputFace.Visible = false; // Disable update for API request
                else
                    TanggalInputFace.SetFormValue(val, true, validate);
                TanggalInputFace.CurrentValue = UnformatDateTime(TanggalInputFace.CurrentValue, TanggalInputFace.FormatPattern);
            }

            // Check field name 'UserInputFace' before field var 'x_UserInputFace'
            val = CurrentForm.HasValue("UserInputFace") ? CurrentForm.GetValue("UserInputFace") : CurrentForm.GetValue("x_UserInputFace");
            if (!UserInputFace.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UserInputFace") && !CurrentForm.HasValue("x_UserInputFace")) // DN
                    UserInputFace.Visible = false; // Disable update for API request
                else
                    UserInputFace.SetFormValue(val);
            }

            // Check field name 'AzurePersonId' before field var 'x_AzurePersonId'
            val = CurrentForm.HasValue("AzurePersonId") ? CurrentForm.GetValue("AzurePersonId") : CurrentForm.GetValue("x_AzurePersonId");
            if (!AzurePersonId.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AzurePersonId") && !CurrentForm.HasValue("x_AzurePersonId")) // DN
                    AzurePersonId.Visible = false; // Disable update for API request
                else
                    AzurePersonId.SetFormValue(val, true, validate);
            }
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdUser.CurrentValue = IdUser.FormValue;
            _Username.CurrentValue = _Username.FormValue;
            LinkRedirect.CurrentValue = LinkRedirect.FormValue;
            _Email.CurrentValue = _Email.FormValue;
            NamaLengkap.CurrentValue = NamaLengkap.FormValue;
            DownloadFace.CurrentValue = DownloadFace.FormValue;
            IdPosition.CurrentValue = IdPosition.FormValue;
            Jabatan.CurrentValue = Jabatan.FormValue;
            Face.CurrentValue = Face.FormValue;
            TanggalInputFace.CurrentValue = TanggalInputFace.FormValue;
            TanggalInputFace.CurrentValue = UnformatDateTime(TanggalInputFace.CurrentValue, TanggalInputFace.FormatPattern);
            UserInputFace.CurrentValue = UserInputFace.FormValue;
            AzurePersonId.CurrentValue = AzurePersonId.FormValue;
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
            IdUser.SetDbValue(row["IdUser"]);
            _Username.SetDbValue(row["Username"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            _Email.SetDbValue(row["Email"]);
            NamaLengkap.SetDbValue(row["NamaLengkap"]);
            DownloadFace.SetDbValue(row["DownloadFace"]);
            IdPosition.SetDbValue(row["IdPosition"]);
            Jabatan.SetDbValue(row["Jabatan"]);
            Face.SetDbValue(row["Face"]);
            TanggalInputFace.SetDbValue(row["TanggalInputFace"]);
            UserInputFace.SetDbValue(row["UserInputFace"]);
            AzurePersonId.SetDbValue(row["AzurePersonId"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdUser", IdUser.DefaultValue ?? DbNullValue); // DN
            row.Add("Username", _Username.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaLengkap", NamaLengkap.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadFace", DownloadFace.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPosition", IdPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("Jabatan", Jabatan.DefaultValue ?? DbNullValue); // DN
            row.Add("Face", Face.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalInputFace", TanggalInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("UserInputFace", UserInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("AzurePersonId", AzurePersonId.DefaultValue ?? DbNullValue); // DN
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

            // IdUser
            IdUser.RowCssClass = "row";

            // Username
            _Username.RowCssClass = "row";

            // LinkRedirect
            LinkRedirect.RowCssClass = "row";

            // Email
            _Email.RowCssClass = "row";

            // NamaLengkap
            NamaLengkap.RowCssClass = "row";

            // DownloadFace
            DownloadFace.RowCssClass = "row";

            // IdPosition
            IdPosition.RowCssClass = "row";

            // Jabatan
            Jabatan.RowCssClass = "row";

            // Face
            Face.RowCssClass = "row";

            // TanggalInputFace
            TanggalInputFace.RowCssClass = "row";

            // UserInputFace
            UserInputFace.RowCssClass = "row";

            // AzurePersonId
            AzurePersonId.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdUser
                IdUser.ViewValue = IdUser.CurrentValue;
                IdUser.ViewValue = FormatNumber(IdUser.ViewValue, IdUser.FormatPattern);
                IdUser.ViewCustomAttributes = "";

                // Username
                _Username.ViewValue = ConvertToString(_Username.CurrentValue); // DN
                _Username.ViewCustomAttributes = "";

                // LinkRedirect
                LinkRedirect.ViewValue = ConvertToString(LinkRedirect.CurrentValue); // DN
                LinkRedirect.ViewCustomAttributes = "";

                // Email
                _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                _Email.ViewCustomAttributes = "";

                // NamaLengkap
                NamaLengkap.ViewValue = ConvertToString(NamaLengkap.CurrentValue); // DN
                NamaLengkap.ViewCustomAttributes = "";

                // DownloadFace
                DownloadFace.ViewValue = DownloadFace.CurrentValue;
                DownloadFace.ViewCustomAttributes = "";

                // IdPosition
                IdPosition.ViewValue = IdPosition.CurrentValue;
                string curVal = ConvertToString(IdPosition.CurrentValue);
                if (!Empty(curVal)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.ViewValue = IdPosition.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.CurrentValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk = IdPosition.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk[0]);
                            IdPosition.ViewValue = IdPosition.DisplayValue(listwrk);
                        } else {
                            IdPosition.ViewValue = FormatNumber(IdPosition.CurrentValue, IdPosition.FormatPattern);
                        }
                    }
                } else {
                    IdPosition.ViewValue = DbNullValue;
                }
                IdPosition.ViewCustomAttributes = "";

                // Jabatan
                Jabatan.ViewValue = ConvertToString(Jabatan.CurrentValue); // DN
                Jabatan.ViewCustomAttributes = "";

                // Face
                Face.ViewValue = ConvertToString(Face.CurrentValue); // DN
                Face.ViewCustomAttributes = "";

                // TanggalInputFace
                TanggalInputFace.ViewValue = TanggalInputFace.CurrentValue;
                TanggalInputFace.ViewValue = FormatDateTime(TanggalInputFace.ViewValue, TanggalInputFace.FormatPattern);
                TanggalInputFace.ViewCustomAttributes = "";

                // UserInputFace
                UserInputFace.ViewValue = ConvertToString(UserInputFace.CurrentValue); // DN
                UserInputFace.ViewCustomAttributes = "";

                // AzurePersonId
                AzurePersonId.ViewValue = ConvertToString(AzurePersonId.CurrentValue); // DN
                AzurePersonId.ViewCustomAttributes = "";

                // IdUser
                IdUser.HrefValue = "";

                // Username
                _Username.HrefValue = "";
                _Username.TooltipValue = "";

                // LinkRedirect
                LinkRedirect.HrefValue = "";

                // Email
                _Email.HrefValue = "";
                _Email.TooltipValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";
                NamaLengkap.TooltipValue = "";

                // DownloadFace
                DownloadFace.HrefValue = "";
                DownloadFace.TooltipValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // Jabatan
                Jabatan.HrefValue = "";

                // Face
                Face.HrefValue = "";

                // TanggalInputFace
                TanggalInputFace.HrefValue = "";

                // UserInputFace
                UserInputFace.HrefValue = "";

                // AzurePersonId
                AzurePersonId.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // IdUser
                IdUser.SetupEditAttributes();
                IdUser.EditValue = IdUser.CurrentValue;
                IdUser.PlaceHolder = RemoveHtml(IdUser.Caption);

                // Username
                _Username.SetupEditAttributes();
                _Username.EditValue = ConvertToString(_Username.CurrentValue); // DN
                _Username.ViewCustomAttributes = "";

                // LinkRedirect
                LinkRedirect.SetupEditAttributes();
                if (!LinkRedirect.Raw)
                    LinkRedirect.CurrentValue = HtmlDecode(LinkRedirect.CurrentValue);
                LinkRedirect.EditValue = HtmlEncode(LinkRedirect.CurrentValue);
                LinkRedirect.PlaceHolder = RemoveHtml(LinkRedirect.Caption);

                // Email
                _Email.SetupEditAttributes();
                _Email.EditValue = ConvertToString(_Email.CurrentValue); // DN
                _Email.ViewCustomAttributes = "";

                // NamaLengkap
                NamaLengkap.SetupEditAttributes();
                NamaLengkap.EditValue = ConvertToString(NamaLengkap.CurrentValue); // DN
                NamaLengkap.ViewCustomAttributes = "";

                // DownloadFace
                DownloadFace.SetupEditAttributes();
                DownloadFace.EditValue = DownloadFace.CurrentValue;
                DownloadFace.ViewCustomAttributes = "";

                // IdPosition
                IdPosition.SetupEditAttributes();
                IdPosition.EditValue = IdPosition.CurrentValue;
                string curVal = ConvertToString(IdPosition.CurrentValue);
                if (!Empty(curVal)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.EditValue = IdPosition.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.CurrentValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk = IdPosition.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk[0]);
                            IdPosition.EditValue = IdPosition.DisplayValue(listwrk);
                        } else {
                            IdPosition.EditValue = HtmlEncode(FormatNumber(IdPosition.CurrentValue, IdPosition.FormatPattern));
                        }
                    }
                } else {
                    IdPosition.EditValue = DbNullValue;
                }
                IdPosition.PlaceHolder = RemoveHtml(IdPosition.Caption);
                if (!Empty(IdPosition.EditValue) && IsNumeric(IdPosition.EditValue))
                    IdPosition.EditValue = FormatNumber(IdPosition.EditValue, null);

                // Jabatan
                Jabatan.SetupEditAttributes();
                if (!Jabatan.Raw)
                    Jabatan.CurrentValue = HtmlDecode(Jabatan.CurrentValue);
                Jabatan.EditValue = HtmlEncode(Jabatan.CurrentValue);
                Jabatan.PlaceHolder = RemoveHtml(Jabatan.Caption);

                // Face
                Face.SetupEditAttributes();
                if (!Face.Raw)
                    Face.CurrentValue = HtmlDecode(Face.CurrentValue);
                Face.EditValue = HtmlEncode(Face.CurrentValue);
                Face.PlaceHolder = RemoveHtml(Face.Caption);

                // TanggalInputFace
                TanggalInputFace.SetupEditAttributes();
                TanggalInputFace.EditValue = FormatDateTime(TanggalInputFace.CurrentValue, TanggalInputFace.FormatPattern);
                TanggalInputFace.PlaceHolder = RemoveHtml(TanggalInputFace.Caption);

                // UserInputFace
                UserInputFace.SetupEditAttributes();
                if (!UserInputFace.Raw)
                    UserInputFace.CurrentValue = HtmlDecode(UserInputFace.CurrentValue);
                UserInputFace.EditValue = HtmlEncode(UserInputFace.CurrentValue);
                UserInputFace.PlaceHolder = RemoveHtml(UserInputFace.Caption);

                // AzurePersonId
                AzurePersonId.SetupEditAttributes();
                AzurePersonId.EditValue = AzurePersonId.CurrentValue;
                AzurePersonId.PlaceHolder = RemoveHtml(AzurePersonId.Caption);

                // Edit refer script

                // IdUser
                IdUser.HrefValue = "";

                // Username
                _Username.HrefValue = "";
                _Username.TooltipValue = "";

                // LinkRedirect
                LinkRedirect.HrefValue = "";

                // Email
                _Email.HrefValue = "";
                _Email.TooltipValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";
                NamaLengkap.TooltipValue = "";

                // DownloadFace
                DownloadFace.HrefValue = "";
                DownloadFace.TooltipValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // Jabatan
                Jabatan.HrefValue = "";

                // Face
                Face.HrefValue = "";

                // TanggalInputFace
                TanggalInputFace.HrefValue = "";

                // UserInputFace
                UserInputFace.HrefValue = "";

                // AzurePersonId
                AzurePersonId.HrefValue = "";
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
                if (IdUser.Visible && IdUser.Required) {
                    if (!IdUser.IsDetailKey && Empty(IdUser.FormValue)) {
                        IdUser.AddErrorMessage(ConvertToString(IdUser.RequiredErrorMessage).Replace("%s", IdUser.Caption));
                    }
                }
                if (!CheckInteger(IdUser.FormValue)) {
                    IdUser.AddErrorMessage(IdUser.GetErrorMessage(false));
                }
                if (_Username.Visible && _Username.Required) {
                    if (!_Username.IsDetailKey && Empty(_Username.FormValue)) {
                        _Username.AddErrorMessage(ConvertToString(_Username.RequiredErrorMessage).Replace("%s", _Username.Caption));
                    }
                }
                if (LinkRedirect.Visible && LinkRedirect.Required) {
                    if (!LinkRedirect.IsDetailKey && Empty(LinkRedirect.FormValue)) {
                        LinkRedirect.AddErrorMessage(ConvertToString(LinkRedirect.RequiredErrorMessage).Replace("%s", LinkRedirect.Caption));
                    }
                }
                if (_Email.Visible && _Email.Required) {
                    if (!_Email.IsDetailKey && Empty(_Email.FormValue)) {
                        _Email.AddErrorMessage(ConvertToString(_Email.RequiredErrorMessage).Replace("%s", _Email.Caption));
                    }
                }
                if (NamaLengkap.Visible && NamaLengkap.Required) {
                    if (!NamaLengkap.IsDetailKey && Empty(NamaLengkap.FormValue)) {
                        NamaLengkap.AddErrorMessage(ConvertToString(NamaLengkap.RequiredErrorMessage).Replace("%s", NamaLengkap.Caption));
                    }
                }
                if (DownloadFace.Visible && DownloadFace.Required) {
                    if (!DownloadFace.IsDetailKey && Empty(DownloadFace.FormValue)) {
                        DownloadFace.AddErrorMessage(ConvertToString(DownloadFace.RequiredErrorMessage).Replace("%s", DownloadFace.Caption));
                    }
                }
                if (IdPosition.Visible && IdPosition.Required) {
                    if (!IdPosition.IsDetailKey && Empty(IdPosition.FormValue)) {
                        IdPosition.AddErrorMessage(ConvertToString(IdPosition.RequiredErrorMessage).Replace("%s", IdPosition.Caption));
                    }
                }
                if (!CheckInteger(IdPosition.FormValue)) {
                    IdPosition.AddErrorMessage(IdPosition.GetErrorMessage(false));
                }
                if (Jabatan.Visible && Jabatan.Required) {
                    if (!Jabatan.IsDetailKey && Empty(Jabatan.FormValue)) {
                        Jabatan.AddErrorMessage(ConvertToString(Jabatan.RequiredErrorMessage).Replace("%s", Jabatan.Caption));
                    }
                }
                if (Face.Visible && Face.Required) {
                    if (!Face.IsDetailKey && Empty(Face.FormValue)) {
                        Face.AddErrorMessage(ConvertToString(Face.RequiredErrorMessage).Replace("%s", Face.Caption));
                    }
                }
                if (TanggalInputFace.Visible && TanggalInputFace.Required) {
                    if (!TanggalInputFace.IsDetailKey && Empty(TanggalInputFace.FormValue)) {
                        TanggalInputFace.AddErrorMessage(ConvertToString(TanggalInputFace.RequiredErrorMessage).Replace("%s", TanggalInputFace.Caption));
                    }
                }
                if (!CheckDate(TanggalInputFace.FormValue, TanggalInputFace.FormatPattern)) {
                    TanggalInputFace.AddErrorMessage(TanggalInputFace.GetErrorMessage(false));
                }
                if (UserInputFace.Visible && UserInputFace.Required) {
                    if (!UserInputFace.IsDetailKey && Empty(UserInputFace.FormValue)) {
                        UserInputFace.AddErrorMessage(ConvertToString(UserInputFace.RequiredErrorMessage).Replace("%s", UserInputFace.Caption));
                    }
                }
                if (AzurePersonId.Visible && AzurePersonId.Required) {
                    if (!AzurePersonId.IsDetailKey && Empty(AzurePersonId.FormValue)) {
                        AzurePersonId.AddErrorMessage(ConvertToString(AzurePersonId.RequiredErrorMessage).Replace("%s", AzurePersonId.Caption));
                    }
                }
                if (!CheckGuid(AzurePersonId.FormValue)) {
                    AzurePersonId.AddErrorMessage(AzurePersonId.GetErrorMessage(false));
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

            // Check for duplicate key when key changed
            if (updateRow) {
                string newKeyFilter = GetRecordFilter(rsnew);
                if (newKeyFilter != oldKeyFilter) {
                    if (await GetQueryBuilder().WhereRaw(newKeyFilter).ExistsAsync()) { // DN
                        FailureMessage = Language.Phrase("DupKey").Replace("%f", newKeyFilter);
                        updateRow = false;
                    }
                }
            }
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

            // IdUser
            IdUser.SetDbValue(rsnew, IdUser.CurrentValue, IdUser.ReadOnly);

            // LinkRedirect
            LinkRedirect.SetDbValue(rsnew, LinkRedirect.CurrentValue, LinkRedirect.ReadOnly);

            // IdPosition
            IdPosition.SetDbValue(rsnew, IdPosition.CurrentValue, IdPosition.ReadOnly);

            // Jabatan
            Jabatan.SetDbValue(rsnew, Jabatan.CurrentValue, Jabatan.ReadOnly);

            // Face
            Face.SetDbValue(rsnew, Face.CurrentValue, Face.ReadOnly);

            // TanggalInputFace
            TanggalInputFace.SetDbValue(rsnew, ConvertToDateTime(TanggalInputFace.CurrentValue, TanggalInputFace.FormatPattern), TanggalInputFace.ReadOnly);

            // UserInputFace
            UserInputFace.SetDbValue(rsnew, UserInputFace.CurrentValue, UserInputFace.ReadOnly);

            // AzurePersonId
            AzurePersonId.SetDbValue(rsnew, ConvertToGuid(AzurePersonId.CurrentValue), AzurePersonId.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("IdUser", out value)) // IdUser
                IdUser.CurrentValue = value;
            if (row.TryGetValue("LinkRedirect", out value)) // LinkRedirect
                LinkRedirect.CurrentValue = value;
            if (row.TryGetValue("IdPosition", out value)) // IdPosition
                IdPosition.CurrentValue = value;
            if (row.TryGetValue("Jabatan", out value)) // Jabatan
                Jabatan.CurrentValue = value;
            if (row.TryGetValue("Face", out value)) // Face
                Face.CurrentValue = value;
            if (row.TryGetValue("TanggalInputFace", out value)) // TanggalInputFace
                TanggalInputFace.CurrentValue = value;
            if (row.TryGetValue("UserInputFace", out value)) // UserInputFace
                UserInputFace.CurrentValue = value;
            if (row.TryGetValue("AzurePersonId", out value)) // AzurePersonId
                AzurePersonId.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("VFaceEnrollmentList")), "", TableVar, true);
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
