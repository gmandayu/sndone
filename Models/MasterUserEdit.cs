namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterUserEdit
    /// </summary>
    public static MasterUserEdit masterUserEdit
    {
        get => HttpData.Get<MasterUserEdit>("masterUserEdit")!;
        set => HttpData["masterUserEdit"] = value;
    }

    /// <summary>
    /// Page class for MasterUser
    /// </summary>
    public class MasterUserEdit : MasterUserEditBase
    {
        // Constructor
        public MasterUserEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterUserEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
            IdPosition.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MasterUserEditBase : MasterUser
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterUserEdit";

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
        public MasterUserEditBase()
        {
            TableName = "MasterUser";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterUser)
            if (masterUser == null || masterUser is MasterUser)
                masterUser = this;

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
        public string PageName => "MasterUserEdit";

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
            IdUser.Visible = false;
            _Email.SetVisibility();
            _Username.SetVisibility();
            PasswordHash.Visible = false;
            NamaLengkap.SetVisibility();
            _UserLevel.SetVisibility();
            Rule.SetVisibility();
            IdPosition.SetVisibility();
            Region.SetVisibility();
            Plant.SetVisibility();
            LookupPosition.SetVisibility();
            StatusAktif.SetVisibility();
            Keterangan.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            IsResetable.Visible = false;
            IsVerify.Visible = false;
            Face.Visible = false;
            AzurePersonId.Visible = false;
            TanggalInputFace.Visible = false;
            UserInputFace.Visible = false;
            IdIdaman.Visible = false;
            exception.SetVisibility();
        }

        // Constructor
        public MasterUserEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "MasterUserView" ? "1" : "0"); // If View page, no primary button
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
            if (IsAdd || IsCopy || IsGridAdd)
                IdUser.Visible = false;
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
            await SetupLookupOptions(_UserLevel);
            await SetupLookupOptions(Rule);
            await SetupLookupOptions(IdPosition);
            await SetupLookupOptions(Region);
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(LookupPosition);
            await SetupLookupOptions(StatusAktif);
            await SetupLookupOptions(IsResetable);
            await SetupLookupOptions(IsVerify);
            await SetupLookupOptions(exception);

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
                            return Terminate("MasterUserList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "MasterUserList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MasterUserList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MasterUserList"; // Return list page content
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
                masterUserEdit?.PageRender();
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

            // Check field name 'Email' before field var 'x__Email'
            val = CurrentForm.HasValue("Email") ? CurrentForm.GetValue("Email") : CurrentForm.GetValue("x__Email");
            if (!_Email.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Email") && !CurrentForm.HasValue("x__Email")) // DN
                    _Email.Visible = false; // Disable update for API request
                else
                    _Email.SetFormValue(val, true, validate);
            }

            // Check field name 'Username' before field var 'x__Username'
            val = CurrentForm.HasValue("Username") ? CurrentForm.GetValue("Username") : CurrentForm.GetValue("x__Username");
            if (!_Username.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Username") && !CurrentForm.HasValue("x__Username")) // DN
                    _Username.Visible = false; // Disable update for API request
                else
                    _Username.SetFormValue(val);
            }

            // Check field name 'NamaLengkap' before field var 'x_NamaLengkap'
            val = CurrentForm.HasValue("NamaLengkap") ? CurrentForm.GetValue("NamaLengkap") : CurrentForm.GetValue("x_NamaLengkap");
            if (!NamaLengkap.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaLengkap") && !CurrentForm.HasValue("x_NamaLengkap")) // DN
                    NamaLengkap.Visible = false; // Disable update for API request
                else
                    NamaLengkap.SetFormValue(val);
            }

            // Check field name 'UserLevel' before field var 'x__UserLevel'
            val = CurrentForm.HasValue("UserLevel") ? CurrentForm.GetValue("UserLevel") : CurrentForm.GetValue("x__UserLevel");
            if (!_UserLevel.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UserLevel") && !CurrentForm.HasValue("x__UserLevel")) // DN
                    _UserLevel.Visible = false; // Disable update for API request
                else
                    _UserLevel.SetFormValue(val);
            }

            // Check field name 'Rule' before field var 'x_Rule'
            val = CurrentForm.HasValue("Rule") ? CurrentForm.GetValue("Rule") : CurrentForm.GetValue("x_Rule");
            if (!Rule.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Rule") && !CurrentForm.HasValue("x_Rule")) // DN
                    Rule.Visible = false; // Disable update for API request
                else
                    Rule.SetFormValue(val);
            }

            // Check field name 'IdPosition' before field var 'x_IdPosition'
            val = CurrentForm.HasValue("IdPosition") ? CurrentForm.GetValue("IdPosition") : CurrentForm.GetValue("x_IdPosition");
            if (!IdPosition.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPosition") && !CurrentForm.HasValue("x_IdPosition")) // DN
                    IdPosition.Visible = false; // Disable update for API request
                else
                    IdPosition.SetFormValue(val, true, validate);
            }

            // Check field name 'Region' before field var 'x_Region'
            val = CurrentForm.HasValue("Region") ? CurrentForm.GetValue("Region") : CurrentForm.GetValue("x_Region");
            if (!Region.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Region") && !CurrentForm.HasValue("x_Region")) // DN
                    Region.Visible = false; // Disable update for API request
                else
                    Region.SetFormValue(val);
            }

            // Check field name 'Plant' before field var 'x_Plant'
            val = CurrentForm.HasValue("Plant") ? CurrentForm.GetValue("Plant") : CurrentForm.GetValue("x_Plant");
            if (!Plant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Plant") && !CurrentForm.HasValue("x_Plant")) // DN
                    Plant.Visible = false; // Disable update for API request
                else
                    Plant.SetFormValue(val);
            }

            // Check field name 'LookupPosition' before field var 'x_LookupPosition'
            val = CurrentForm.HasValue("LookupPosition") ? CurrentForm.GetValue("LookupPosition") : CurrentForm.GetValue("x_LookupPosition");
            if (!LookupPosition.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LookupPosition") && !CurrentForm.HasValue("x_LookupPosition")) // DN
                    LookupPosition.Visible = false; // Disable update for API request
                else
                    LookupPosition.SetFormValue(val);
            }

            // Check field name 'StatusAktif' before field var 'x_StatusAktif'
            val = CurrentForm.HasValue("StatusAktif") ? CurrentForm.GetValue("StatusAktif") : CurrentForm.GetValue("x_StatusAktif");
            if (!StatusAktif.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusAktif") && !CurrentForm.HasValue("x_StatusAktif")) // DN
                    StatusAktif.Visible = false; // Disable update for API request
                else
                    StatusAktif.SetFormValue(val);
            }

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }

            // Check field name 'exception ' before field var 'x_exception'
            val = CurrentForm.HasValue("exception ") ? CurrentForm.GetValue("exception ") : CurrentForm.GetValue("x_exception");
            if (!exception.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("exception ") && !CurrentForm.HasValue("x_exception")) // DN
                    exception.Visible = false; // Disable update for API request
                else
                    exception.SetFormValue(val);
            }

            // Check field name 'IdUser' before field var 'x_IdUser'
            val = CurrentForm.HasValue("IdUser") ? CurrentForm.GetValue("IdUser") : CurrentForm.GetValue("x_IdUser");
            if (!IdUser.IsDetailKey)
                IdUser.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdUser.CurrentValue = IdUser.FormValue;
            _Email.CurrentValue = _Email.FormValue;
            _Username.CurrentValue = _Username.FormValue;
            NamaLengkap.CurrentValue = NamaLengkap.FormValue;
            _UserLevel.CurrentValue = _UserLevel.FormValue;
            Rule.CurrentValue = Rule.FormValue;
            IdPosition.CurrentValue = IdPosition.FormValue;
            Region.CurrentValue = Region.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            LookupPosition.CurrentValue = LookupPosition.FormValue;
            StatusAktif.CurrentValue = StatusAktif.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            exception.CurrentValue = exception.FormValue;
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
            _Email.SetDbValue(row["Email"]);
            _Username.SetDbValue(row["Username"]);
            PasswordHash.SetDbValue(row["PasswordHash"]);
            NamaLengkap.SetDbValue(row["NamaLengkap"]);
            _UserLevel.SetDbValue(row["UserLevel"]);
            Rule.SetDbValue(row["Rule"]);
            IdPosition.SetDbValue(row["IdPosition"]);
            Region.SetDbValue(row["Region"]);
            Plant.SetDbValue(row["Plant"]);
            LookupPosition.SetDbValue(row["LookupPosition"]);
            StatusAktif.SetDbValue((ConvertToBool(row["StatusAktif"]) ? "1" : "0"));
            Keterangan.SetDbValue(row["Keterangan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            IsResetable.SetDbValue((ConvertToBool(row["IsResetable"]) ? "1" : "0"));
            IsVerify.SetDbValue((ConvertToBool(row["IsVerify"]) ? "1" : "0"));
            Face.SetDbValue(row["Face"]);
            AzurePersonId.SetDbValue(row["AzurePersonId"]);
            TanggalInputFace.SetDbValue(row["TanggalInputFace"]);
            UserInputFace.SetDbValue(row["UserInputFace"]);
            IdIdaman.SetDbValue(row["IdIdaman"]);
            exception.SetDbValue((ConvertToBool(row["exception "]) ? "1" : "0"));
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdUser", IdUser.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("Username", _Username.DefaultValue ?? DbNullValue); // DN
            row.Add("PasswordHash", PasswordHash.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaLengkap", NamaLengkap.DefaultValue ?? DbNullValue); // DN
            row.Add("UserLevel", _UserLevel.DefaultValue ?? DbNullValue); // DN
            row.Add("Rule", Rule.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPosition", IdPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("Region", Region.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPosition", LookupPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktif", StatusAktif.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("IsResetable", IsResetable.DefaultValue ?? DbNullValue); // DN
            row.Add("IsVerify", IsVerify.DefaultValue ?? DbNullValue); // DN
            row.Add("Face", Face.DefaultValue ?? DbNullValue); // DN
            row.Add("AzurePersonId", AzurePersonId.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalInputFace", TanggalInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("UserInputFace", UserInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("IdIdaman", IdIdaman.DefaultValue ?? DbNullValue); // DN
            row.Add("exception ", exception.DefaultValue ?? DbNullValue); // DN
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

            // Email
            _Email.RowCssClass = "row";

            // Username
            _Username.RowCssClass = "row";

            // PasswordHash
            PasswordHash.RowCssClass = "row";

            // NamaLengkap
            NamaLengkap.RowCssClass = "row";

            // UserLevel
            _UserLevel.RowCssClass = "row";

            // Rule
            Rule.RowCssClass = "row";

            // IdPosition
            IdPosition.RowCssClass = "row";

            // Region
            Region.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // LookupPosition
            LookupPosition.RowCssClass = "row";

            // StatusAktif
            StatusAktif.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaruiOleh
            DiperbaruiOleh.RowCssClass = "row";

            // TanggalDiperbarui
            TanggalDiperbarui.RowCssClass = "row";

            // IsResetable
            IsResetable.RowCssClass = "row";

            // IsVerify
            IsVerify.RowCssClass = "row";

            // Face
            Face.RowCssClass = "row";

            // AzurePersonId
            AzurePersonId.RowCssClass = "row";

            // TanggalInputFace
            TanggalInputFace.RowCssClass = "row";

            // UserInputFace
            UserInputFace.RowCssClass = "row";

            // IdIdaman
            IdIdaman.RowCssClass = "row";

            // exception 
            exception.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdUser
                IdUser.ViewValue = IdUser.CurrentValue;
                IdUser.ViewCustomAttributes = "";

                // Email
                _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                _Email.ViewCustomAttributes = "";

                // Username
                _Username.ViewValue = ConvertToString(_Username.CurrentValue); // DN
                _Username.ViewCustomAttributes = "";

                // PasswordHash
                PasswordHash.ViewValue = Language.Phrase("PasswordMask");
                PasswordHash.ViewCustomAttributes = "";

                // NamaLengkap
                NamaLengkap.ViewValue = ConvertToString(NamaLengkap.CurrentValue); // DN
                NamaLengkap.ViewCustomAttributes = "";

                // UserLevel
                if (Security.CanAdmin) { // System admin
                    string curVal = ConvertToString(_UserLevel.CurrentValue);
                    if (!Empty(curVal)) {
                        if (_UserLevel.Lookup != null && IsDictionary(_UserLevel.Lookup?.Options) && _UserLevel.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            _UserLevel.ViewValue = _UserLevel.LookupCacheOption(curVal);
                        } else { // Lookup from database // DN
                            string filterWrk = SearchFilter(_UserLevel.Lookup?.GetTable()?.Fields["UserLevelID"].SearchExpression, "=", _UserLevel.CurrentValue, _UserLevel.Lookup?.GetTable()?.Fields["UserLevelID"].SearchDataType, "");
                            string? sqlWrk = _UserLevel.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                            List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk?.Count > 0 && _UserLevel.Lookup != null) { // Lookup values found
                                var listwrk = _UserLevel.Lookup?.RenderViewRow(rswrk[0]);
                                _UserLevel.ViewValue = _UserLevel.DisplayValue(listwrk);
                            } else {
                                _UserLevel.ViewValue = FormatNumber(_UserLevel.CurrentValue, _UserLevel.FormatPattern);
                            }
                        }
                    } else {
                        _UserLevel.ViewValue = DbNullValue;
                    }
                } else {
                    _UserLevel.ViewValue = Language.Phrase("PasswordMask");
                }
                _UserLevel.ViewCustomAttributes = "";

                // Rule
                string curVal2 = ConvertToString(Rule.CurrentValue);
                if (!Empty(curVal2)) {
                    if (Rule.Lookup != null && IsDictionary(Rule.Lookup?.Options) && Rule.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Rule.ViewValue = Rule.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(Rule.Lookup?.GetTable()?.Fields["IdPIC"].SearchExpression, "=", Rule.CurrentValue, Rule.Lookup?.GetTable()?.Fields["IdPIC"].SearchDataType, "");
                        string? sqlWrk2 = Rule.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && Rule.Lookup != null) { // Lookup values found
                            var listwrk = Rule.Lookup?.RenderViewRow(rswrk2[0]);
                            Rule.ViewValue = Rule.DisplayValue(listwrk);
                        } else {
                            Rule.ViewValue = Rule.CurrentValue;
                        }
                    }
                } else {
                    Rule.ViewValue = DbNullValue;
                }
                Rule.ViewCustomAttributes = "";

                // IdPosition
                IdPosition.ViewValue = IdPosition.CurrentValue;
                string curVal3 = ConvertToString(IdPosition.CurrentValue);
                if (!Empty(curVal3)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.ViewValue = IdPosition.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.CurrentValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk3 = IdPosition.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk3[0]);
                            IdPosition.ViewValue = IdPosition.DisplayValue(listwrk);
                        } else {
                            IdPosition.ViewValue = FormatNumber(IdPosition.CurrentValue, IdPosition.FormatPattern);
                        }
                    }
                } else {
                    IdPosition.ViewValue = DbNullValue;
                }
                IdPosition.ViewCustomAttributes = "";

                // Region
                string curVal4 = ConvertToString(Region.CurrentValue);
                if (!Empty(curVal4)) {
                    if (Region.Lookup != null && IsDictionary(Region.Lookup?.Options) && Region.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Region.ViewValue = Region.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchExpression, "=", Region.CurrentValue, Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchDataType, "");
                        string? sqlWrk4 = Region.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && Region.Lookup != null) { // Lookup values found
                            var listwrk = Region.Lookup?.RenderViewRow(rswrk4[0]);
                            Region.ViewValue = Region.DisplayValue(listwrk);
                        } else {
                            Region.ViewValue = Region.CurrentValue;
                        }
                    }
                } else {
                    Region.ViewValue = DbNullValue;
                }
                Region.ViewCustomAttributes = "";

                // Plant
                string curVal5 = ConvertToString(Plant.CurrentValue);
                if (!Empty(curVal5)) {
                    if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Plant.ViewValue = Plant.LookupCacheOption(curVal5);
                    } else { // Lookup from database // DN
                        string filterWrk5 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk5 = Plant.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk5?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                            var listwrk = Plant.Lookup?.RenderViewRow(rswrk5[0]);
                            Plant.ViewValue = Plant.DisplayValue(listwrk);
                        } else {
                            Plant.ViewValue = FormatNumber(Plant.CurrentValue, Plant.FormatPattern);
                        }
                    }
                } else {
                    Plant.ViewValue = DbNullValue;
                }
                Plant.ViewCustomAttributes = "";

                // LookupPosition
                if (!Empty(LookupPosition.CurrentValue)) {
                    LookupPosition.ViewValue = LookupPosition.OptionCaption(ConvertToString(LookupPosition.CurrentValue));
                } else {
                    LookupPosition.ViewValue = DbNullValue;
                }
                LookupPosition.ViewCustomAttributes = "";

                // StatusAktif
                if (ConvertToBool(StatusAktif.CurrentValue)) {
                    StatusAktif.ViewValue = StatusAktif.TagCaption(1) != "" ? StatusAktif.TagCaption(1) : "Yes";
                } else {
                    StatusAktif.ViewValue = StatusAktif.TagCaption(2) != "" ? StatusAktif.TagCaption(2) : "No";
                }
                StatusAktif.ViewCustomAttributes = "";

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

                // IsResetable
                if (ConvertToBool(IsResetable.CurrentValue)) {
                    IsResetable.ViewValue = IsResetable.TagCaption(1) != "" ? IsResetable.TagCaption(1) : "Yes";
                } else {
                    IsResetable.ViewValue = IsResetable.TagCaption(2) != "" ? IsResetable.TagCaption(2) : "No";
                }
                IsResetable.ViewCustomAttributes = "";

                // IsVerify
                if (ConvertToBool(IsVerify.CurrentValue)) {
                    IsVerify.ViewValue = IsVerify.TagCaption(1) != "" ? IsVerify.TagCaption(1) : "Yes";
                } else {
                    IsVerify.ViewValue = IsVerify.TagCaption(2) != "" ? IsVerify.TagCaption(2) : "No";
                }
                IsVerify.ViewCustomAttributes = "";

                // Face
                Face.ViewValue = ConvertToString(Face.CurrentValue); // DN
                Face.ViewCustomAttributes = "";

                // AzurePersonId
                AzurePersonId.ViewValue = ConvertToString(AzurePersonId.CurrentValue); // DN
                AzurePersonId.ViewCustomAttributes = "";

                // TanggalInputFace
                TanggalInputFace.ViewValue = TanggalInputFace.CurrentValue;
                TanggalInputFace.ViewValue = FormatDateTime(TanggalInputFace.ViewValue, TanggalInputFace.FormatPattern);
                TanggalInputFace.ViewCustomAttributes = "";

                // UserInputFace
                UserInputFace.ViewValue = ConvertToString(UserInputFace.CurrentValue); // DN
                UserInputFace.ViewCustomAttributes = "";

                // IdIdaman
                IdIdaman.ViewValue = ConvertToString(IdIdaman.CurrentValue); // DN
                IdIdaman.ViewCustomAttributes = "";

                // exception 
                if (ConvertToBool(exception.CurrentValue)) {
                    exception.ViewValue = exception.TagCaption(1) != "" ? exception.TagCaption(1) : "Yes";
                } else {
                    exception.ViewValue = exception.TagCaption(2) != "" ? exception.TagCaption(2) : "No";
                }
                exception.ViewCustomAttributes = "";

                // Email
                _Email.HrefValue = "";

                // Username
                _Username.HrefValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";

                // UserLevel
                _UserLevel.HrefValue = "";

                // Rule
                Rule.HrefValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // LookupPosition
                LookupPosition.HrefValue = "";

                // StatusAktif
                StatusAktif.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // exception 
                exception.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // Email
                _Email.SetupEditAttributes();
                if (!_Email.Raw)
                    _Email.CurrentValue = HtmlDecode(_Email.CurrentValue);
                _Email.EditValue = HtmlEncode(_Email.CurrentValue);
                _Email.PlaceHolder = RemoveHtml(_Email.Caption);

                // Username
                _Username.SetupEditAttributes();
                if (!_Username.Raw)
                    _Username.CurrentValue = HtmlDecode(_Username.CurrentValue);
                _Username.EditValue = HtmlEncode(_Username.CurrentValue);
                _Username.PlaceHolder = RemoveHtml(_Username.Caption);

                // NamaLengkap
                NamaLengkap.SetupEditAttributes();
                if (!NamaLengkap.Raw)
                    NamaLengkap.CurrentValue = HtmlDecode(NamaLengkap.CurrentValue);
                NamaLengkap.EditValue = HtmlEncode(NamaLengkap.CurrentValue);
                NamaLengkap.PlaceHolder = RemoveHtml(NamaLengkap.Caption);

                // UserLevel
                _UserLevel.SetupEditAttributes();
                if (!Security.CanAdmin) { // System admin
                    _UserLevel.EditValue = Language.Phrase("PasswordMask");
                } else {
                    string curVal = ConvertToString(_UserLevel.CurrentValue);
                    if (_UserLevel.Lookup != null && IsDictionary(_UserLevel.Lookup?.Options) && _UserLevel.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        _UserLevel.EditValue = _UserLevel.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        string filterWrk = "";
                        if (curVal == "") {
                            filterWrk = "0=1";
                        } else {
                            filterWrk = SearchFilter(_UserLevel.Lookup?.GetTable()?.Fields["UserLevelID"].SearchExpression, "=", _UserLevel.CurrentValue, _UserLevel.Lookup?.GetTable()?.Fields["UserLevelID"].SearchDataType, "");
                        }
                        string? sqlWrk = _UserLevel.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        _UserLevel.EditValue = rswrk;
                    }
                    _UserLevel.PlaceHolder = RemoveHtml(_UserLevel.Caption);
                    if (!Empty(_UserLevel.EditValue) && IsNumeric(_UserLevel.EditValue))
                        _UserLevel.EditValue = FormatNumber(_UserLevel.EditValue, null);
                }

                // Rule
                Rule.SetupEditAttributes();
                string curVal2 = ConvertToString(Rule.CurrentValue);
                if (Rule.Lookup != null && IsDictionary(Rule.Lookup?.Options) && Rule.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Rule.EditValue = Rule.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk2 = "";
                    if (curVal2 == "") {
                        filterWrk2 = "0=1";
                    } else {
                        filterWrk2 = SearchFilter(Rule.Lookup?.GetTable()?.Fields["IdPIC"].SearchExpression, "=", Rule.CurrentValue, Rule.Lookup?.GetTable()?.Fields["IdPIC"].SearchDataType, "");
                    }
                    string? sqlWrk2 = Rule.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Rule.EditValue = rswrk2;
                }
                Rule.PlaceHolder = RemoveHtml(Rule.Caption);

                // IdPosition
                IdPosition.SetupEditAttributes();
                IdPosition.EditValue = IdPosition.CurrentValue;
                string curVal3 = ConvertToString(IdPosition.CurrentValue);
                if (!Empty(curVal3)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.EditValue = IdPosition.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.CurrentValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk3 = IdPosition.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk3[0]);
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

                // Region
                Region.SetupEditAttributes();
                string curVal4 = ConvertToString(Region.CurrentValue);
                if (Region.Lookup != null && IsDictionary(Region.Lookup?.Options) && Region.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Region.EditValue = Region.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk4 = "";
                    if (curVal4 == "") {
                        filterWrk4 = "0=1";
                    } else {
                        filterWrk4 = SearchFilter(Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchExpression, "=", Region.CurrentValue, Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchDataType, "");
                    }
                    string? sqlWrk4 = Region.Lookup?.GetSql(true, filterWrk4, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Region.EditValue = rswrk4;
                }
                Region.PlaceHolder = RemoveHtml(Region.Caption);

                // Plant
                Plant.SetupEditAttributes();
                string curVal5 = ConvertToString(Plant.CurrentValue);
                if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Plant.EditValue = Plant.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk5 = "";
                    if (curVal5 == "") {
                        filterWrk5 = "0=1";
                    } else {
                        filterWrk5 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk5 = Plant.Lookup?.GetSql(true, filterWrk5, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Plant.EditValue = rswrk5;
                }
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);
                if (!Empty(Plant.EditValue) && IsNumeric(Plant.EditValue))
                    Plant.EditValue = FormatNumber(Plant.EditValue, null);

                // LookupPosition
                LookupPosition.SetupEditAttributes();
                LookupPosition.EditValue = LookupPosition.Options(true);
                LookupPosition.PlaceHolder = RemoveHtml(LookupPosition.Caption);

                // StatusAktif
                StatusAktif.EditValue = StatusAktif.Options(false);
                StatusAktif.PlaceHolder = RemoveHtml(StatusAktif.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // exception 
                exception.EditValue = exception.Options(false);
                exception.PlaceHolder = RemoveHtml(exception.Caption);

                // Edit refer script

                // Email
                _Email.HrefValue = "";

                // Username
                _Username.HrefValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";

                // UserLevel
                _UserLevel.HrefValue = "";

                // Rule
                Rule.HrefValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // LookupPosition
                LookupPosition.HrefValue = "";

                // StatusAktif
                StatusAktif.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // exception 
                exception.HrefValue = "";
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
                if (_Email.Visible && _Email.Required) {
                    if (!_Email.IsDetailKey && Empty(_Email.FormValue)) {
                        _Email.AddErrorMessage(ConvertToString(_Email.RequiredErrorMessage).Replace("%s", _Email.Caption));
                    }
                }
                if (!CheckEmail(_Email.FormValue)) {
                    _Email.AddErrorMessage(_Email.GetErrorMessage(false));
                }
                if (_Username.Visible && _Username.Required) {
                    if (!_Username.IsDetailKey && Empty(_Username.FormValue)) {
                        _Username.AddErrorMessage(ConvertToString(_Username.RequiredErrorMessage).Replace("%s", _Username.Caption));
                    }
                }
                if (!_Username.Raw && Config.RemoveXss && CheckUsername(_Username.FormValue)) {
                    _Username.AddErrorMessage(Language.Phrase("InvalidUsernameChars"));
                }
                if (NamaLengkap.Visible && NamaLengkap.Required) {
                    if (!NamaLengkap.IsDetailKey && Empty(NamaLengkap.FormValue)) {
                        NamaLengkap.AddErrorMessage(ConvertToString(NamaLengkap.RequiredErrorMessage).Replace("%s", NamaLengkap.Caption));
                    }
                }
                if (_UserLevel.Visible && _UserLevel.Required) {
                    if (Security.CanAdmin && !_UserLevel.IsDetailKey && Empty(_UserLevel.FormValue)) {
                        _UserLevel.AddErrorMessage(ConvertToString(_UserLevel.RequiredErrorMessage).Replace("%s", _UserLevel.Caption));
                    }
                }
                if (Rule.Visible && Rule.Required) {
                    if (!Rule.IsDetailKey && Empty(Rule.FormValue)) {
                        Rule.AddErrorMessage(ConvertToString(Rule.RequiredErrorMessage).Replace("%s", Rule.Caption));
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
                if (Region.Visible && Region.Required) {
                    if (!Region.IsDetailKey && Empty(Region.FormValue)) {
                        Region.AddErrorMessage(ConvertToString(Region.RequiredErrorMessage).Replace("%s", Region.Caption));
                    }
                }
                if (Plant.Visible && Plant.Required) {
                    if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                        Plant.AddErrorMessage(ConvertToString(Plant.RequiredErrorMessage).Replace("%s", Plant.Caption));
                    }
                }
                if (LookupPosition.Visible && LookupPosition.Required) {
                    if (!LookupPosition.IsDetailKey && Empty(LookupPosition.FormValue)) {
                        LookupPosition.AddErrorMessage(ConvertToString(LookupPosition.RequiredErrorMessage).Replace("%s", LookupPosition.Caption));
                    }
                }
                if (StatusAktif.Visible && StatusAktif.Required) {
                    if (Empty(StatusAktif.FormValue)) {
                        StatusAktif.AddErrorMessage(ConvertToString(StatusAktif.RequiredErrorMessage).Replace("%s", StatusAktif.Caption));
                    }
                }
                if (Keterangan.Visible && Keterangan.Required) {
                    if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                        Keterangan.AddErrorMessage(ConvertToString(Keterangan.RequiredErrorMessage).Replace("%s", Keterangan.Caption));
                    }
                }
                if (exception.Visible && exception.Required) {
                    if (Empty(exception.FormValue)) {
                        exception.AddErrorMessage(ConvertToString(exception.RequiredErrorMessage).Replace("%s", exception.Caption));
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

            // Check field with unique index (Username)
            if (!Empty(_Username.CurrentValue)) {
                string filterChk = "([Username] = '" + AdjustSql(_Username.CurrentValue, DbId) + "')";
                filterChk = filterChk + " AND NOT (" + filter + ")";
                try {
                    if (await GetQueryBuilder().WhereRaw(filterChk).ExistsAsync()) {
                        var idxErrMsg = Language.Phrase("DupIndex").Replace("%f", _Username.Caption);
                        idxErrMsg = idxErrMsg.Replace("%v", ConvertToString(_Username.CurrentValue));
                        FailureMessage = idxErrMsg;
                        return JsonBoolResult.FalseResult;
                    }
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    return JsonBoolResult.FalseResult;
                }
            }

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

            // Email
            _Email.SetDbValue(rsnew, _Email.CurrentValue, _Email.ReadOnly);

            // Username
            _Username.SetDbValue(rsnew, _Username.CurrentValue, _Username.ReadOnly);

            // NamaLengkap
            NamaLengkap.SetDbValue(rsnew, NamaLengkap.CurrentValue, NamaLengkap.ReadOnly);

            // UserLevel
            if (Security.CanAdmin) { // System admin
            _UserLevel.SetDbValue(rsnew, _UserLevel.CurrentValue, _UserLevel.ReadOnly);
            }

            // Rule
            Rule.SetDbValue(rsnew, Rule.CurrentValue, Rule.ReadOnly);

            // IdPosition
            IdPosition.SetDbValue(rsnew, IdPosition.CurrentValue, IdPosition.ReadOnly);

            // Region
            Region.SetDbValue(rsnew, Region.CurrentValue, Region.ReadOnly);

            // Plant
            Plant.SetDbValue(rsnew, Plant.CurrentValue, Plant.ReadOnly);

            // LookupPosition
            LookupPosition.SetDbValue(rsnew, LookupPosition.CurrentValue, LookupPosition.ReadOnly);

            // StatusAktif
            StatusAktif.SetDbValue(rsnew, ConvertToBool(StatusAktif.CurrentValue), StatusAktif.ReadOnly);

            // Keterangan
            Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue, Keterangan.ReadOnly);

            // exception 
            exception.SetDbValue(rsnew, ConvertToBool(exception.CurrentValue), exception.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Email", out value)) // Email
                _Email.CurrentValue = value;
            if (row.TryGetValue("Username", out value)) // Username
                _Username.CurrentValue = value;
            if (row.TryGetValue("NamaLengkap", out value)) // NamaLengkap
                NamaLengkap.CurrentValue = value;
            if (row.TryGetValue("UserLevel", out value)) // UserLevel
                _UserLevel.CurrentValue = value;
            if (row.TryGetValue("Rule", out value)) // Rule
                Rule.CurrentValue = value;
            if (row.TryGetValue("IdPosition", out value)) // IdPosition
                IdPosition.CurrentValue = value;
            if (row.TryGetValue("Region", out value)) // Region
                Region.CurrentValue = value;
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.CurrentValue = value;
            if (row.TryGetValue("LookupPosition", out value)) // LookupPosition
                LookupPosition.CurrentValue = value;
            if (row.TryGetValue("StatusAktif", out value)) // StatusAktif
                StatusAktif.CurrentValue = value;
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.CurrentValue = value;
            if (row.TryGetValue("exception ", out value)) // exception 
                exception.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterUserList")), "", TableVar, true);
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
