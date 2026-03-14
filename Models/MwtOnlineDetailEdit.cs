namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// mwtOnlineDetailEdit
    /// </summary>
    public static MwtOnlineDetailEdit mwtOnlineDetailEdit
    {
        get => HttpData.Get<MwtOnlineDetailEdit>("mwtOnlineDetailEdit")!;
        set => HttpData["mwtOnlineDetailEdit"] = value;
    }

    /// <summary>
    /// Page class for MWTOnlineDetail
    /// </summary>
    public class MwtOnlineDetailEdit : MwtOnlineDetailEditBase
    {
        // Constructor
        public MwtOnlineDetailEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MwtOnlineDetailEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MwtOnlineDetailEditBase : MwtOnlineDetail
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "mwtOnlineDetailEdit";

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
        public MwtOnlineDetailEditBase()
        {
            TableName = "MWTOnlineDetail";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (mwtOnlineDetail)
            if (mwtOnlineDetail == null || mwtOnlineDetail is MwtOnlineDetail)
                mwtOnlineDetail = this;

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
        public string PageName => "MwtOnlineDetailEdit";

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
            Id.SetVisibility();
            NoReferensi.SetVisibility();
            Penjelasan.SetVisibility();
            UploadEvidence.SetVisibility();
            CreatedDate.SetVisibility();
            CreatedBy.SetVisibility();
            LastUpdatedBy.SetVisibility();
            LastUpdatedDate.SetVisibility();
            StatusEmail.SetVisibility();
            FileType.SetVisibility();
            OriginalFileName.SetVisibility();
            Flag.SetVisibility();
        }

        // Constructor
        public MwtOnlineDetailEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "MwtOnlineDetailView" ? "1" : "0"); // If View page, no primary button
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
            if (IsAdd || IsCopy || IsGridAdd)
                Id.Visible = false;
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
                            return Terminate("MwtOnlineDetailList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "MwtOnlineDetailList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MwtOnlineDetailList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MwtOnlineDetailList"; // Return list page content
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
                mwtOnlineDetailEdit?.PageRender();
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

            // Check field name 'Id' before field var 'x_Id'
            val = CurrentForm.HasValue("Id") ? CurrentForm.GetValue("Id") : CurrentForm.GetValue("x_Id");
            if (!Id.IsDetailKey)
                Id.SetFormValue(val);

            // Check field name 'NoReferensi' before field var 'x_NoReferensi'
            val = CurrentForm.HasValue("NoReferensi") ? CurrentForm.GetValue("NoReferensi") : CurrentForm.GetValue("x_NoReferensi");
            if (!NoReferensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoReferensi") && !CurrentForm.HasValue("x_NoReferensi")) // DN
                    NoReferensi.Visible = false; // Disable update for API request
                else
                    NoReferensi.SetFormValue(val);
            }

            // Check field name 'Penjelasan' before field var 'x_Penjelasan'
            val = CurrentForm.HasValue("Penjelasan") ? CurrentForm.GetValue("Penjelasan") : CurrentForm.GetValue("x_Penjelasan");
            if (!Penjelasan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Penjelasan") && !CurrentForm.HasValue("x_Penjelasan")) // DN
                    Penjelasan.Visible = false; // Disable update for API request
                else
                    Penjelasan.SetFormValue(val);
            }

            // Check field name 'UploadEvidence' before field var 'x_UploadEvidence'
            val = CurrentForm.HasValue("UploadEvidence") ? CurrentForm.GetValue("UploadEvidence") : CurrentForm.GetValue("x_UploadEvidence");
            if (!UploadEvidence.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UploadEvidence") && !CurrentForm.HasValue("x_UploadEvidence")) // DN
                    UploadEvidence.Visible = false; // Disable update for API request
                else
                    UploadEvidence.SetFormValue(val);
            }

            // Check field name 'CreatedDate' before field var 'x_CreatedDate'
            val = CurrentForm.HasValue("CreatedDate") ? CurrentForm.GetValue("CreatedDate") : CurrentForm.GetValue("x_CreatedDate");
            if (!CreatedDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CreatedDate") && !CurrentForm.HasValue("x_CreatedDate")) // DN
                    CreatedDate.Visible = false; // Disable update for API request
                else
                    CreatedDate.SetFormValue(val, true, validate);
                CreatedDate.CurrentValue = UnformatDateTime(CreatedDate.CurrentValue, CreatedDate.FormatPattern);
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
                    LastUpdatedDate.SetFormValue(val, true, validate);
                LastUpdatedDate.CurrentValue = UnformatDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern);
            }

            // Check field name 'StatusEmail' before field var 'x_StatusEmail'
            val = CurrentForm.HasValue("StatusEmail") ? CurrentForm.GetValue("StatusEmail") : CurrentForm.GetValue("x_StatusEmail");
            if (!StatusEmail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusEmail") && !CurrentForm.HasValue("x_StatusEmail")) // DN
                    StatusEmail.Visible = false; // Disable update for API request
                else
                    StatusEmail.SetFormValue(val);
            }

            // Check field name 'FileType' before field var 'x_FileType'
            val = CurrentForm.HasValue("FileType") ? CurrentForm.GetValue("FileType") : CurrentForm.GetValue("x_FileType");
            if (!FileType.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FileType") && !CurrentForm.HasValue("x_FileType")) // DN
                    FileType.Visible = false; // Disable update for API request
                else
                    FileType.SetFormValue(val);
            }

            // Check field name 'OriginalFileName' before field var 'x_OriginalFileName'
            val = CurrentForm.HasValue("OriginalFileName") ? CurrentForm.GetValue("OriginalFileName") : CurrentForm.GetValue("x_OriginalFileName");
            if (!OriginalFileName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("OriginalFileName") && !CurrentForm.HasValue("x_OriginalFileName")) // DN
                    OriginalFileName.Visible = false; // Disable update for API request
                else
                    OriginalFileName.SetFormValue(val);
            }

            // Check field name 'Flag' before field var 'x_Flag'
            val = CurrentForm.HasValue("Flag") ? CurrentForm.GetValue("Flag") : CurrentForm.GetValue("x_Flag");
            if (!Flag.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Flag") && !CurrentForm.HasValue("x_Flag")) // DN
                    Flag.Visible = false; // Disable update for API request
                else
                    Flag.SetFormValue(val);
            }
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            Id.CurrentValue = Id.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            Penjelasan.CurrentValue = Penjelasan.FormValue;
            UploadEvidence.CurrentValue = UploadEvidence.FormValue;
            CreatedDate.CurrentValue = CreatedDate.FormValue;
            CreatedDate.CurrentValue = UnformatDateTime(CreatedDate.CurrentValue, CreatedDate.FormatPattern);
            CreatedBy.CurrentValue = CreatedBy.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            LastUpdatedDate.CurrentValue = LastUpdatedDate.FormValue;
            LastUpdatedDate.CurrentValue = UnformatDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern);
            StatusEmail.CurrentValue = StatusEmail.FormValue;
            FileType.CurrentValue = FileType.FormValue;
            OriginalFileName.CurrentValue = OriginalFileName.FormValue;
            Flag.CurrentValue = Flag.FormValue;
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
            NoReferensi.SetDbValue(row["NoReferensi"]);
            Penjelasan.SetDbValue(row["Penjelasan"]);
            UploadEvidence.SetDbValue(row["UploadEvidence"]);
            CreatedDate.SetDbValue(row["CreatedDate"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDate.SetDbValue(row["LastUpdatedDate"]);
            StatusEmail.SetDbValue(row["StatusEmail"]);
            FileType.SetDbValue(row["FileType"]);
            OriginalFileName.SetDbValue(row["OriginalFileName"]);
            Flag.SetDbValue(row["Flag"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("Id", Id.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("Penjelasan", Penjelasan.DefaultValue ?? DbNullValue); // DN
            row.Add("UploadEvidence", UploadEvidence.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDate", CreatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDate", LastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusEmail", StatusEmail.DefaultValue ?? DbNullValue); // DN
            row.Add("FileType", FileType.DefaultValue ?? DbNullValue); // DN
            row.Add("OriginalFileName", OriginalFileName.DefaultValue ?? DbNullValue); // DN
            row.Add("Flag", Flag.DefaultValue ?? DbNullValue); // DN
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

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // Penjelasan
            Penjelasan.RowCssClass = "row";

            // UploadEvidence
            UploadEvidence.RowCssClass = "row";

            // CreatedDate
            CreatedDate.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // LastUpdatedDate
            LastUpdatedDate.RowCssClass = "row";

            // StatusEmail
            StatusEmail.RowCssClass = "row";

            // FileType
            FileType.RowCssClass = "row";

            // OriginalFileName
            OriginalFileName.RowCssClass = "row";

            // Flag
            Flag.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // Id
                Id.ViewValue = Id.CurrentValue;
                Id.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // Penjelasan
                Penjelasan.ViewValue = Penjelasan.CurrentValue;
                Penjelasan.ViewCustomAttributes = "";

                // UploadEvidence
                UploadEvidence.ViewValue = ConvertToString(UploadEvidence.CurrentValue); // DN
                UploadEvidence.ViewCustomAttributes = "";

                // CreatedDate
                CreatedDate.ViewValue = CreatedDate.CurrentValue;
                CreatedDate.ViewValue = FormatDateTime(CreatedDate.ViewValue, CreatedDate.FormatPattern);
                CreatedDate.ViewCustomAttributes = "";

                // CreatedBy
                CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
                CreatedBy.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // LastUpdatedDate
                LastUpdatedDate.ViewValue = LastUpdatedDate.CurrentValue;
                LastUpdatedDate.ViewValue = FormatDateTime(LastUpdatedDate.ViewValue, LastUpdatedDate.FormatPattern);
                LastUpdatedDate.ViewCustomAttributes = "";

                // StatusEmail
                StatusEmail.ViewValue = ConvertToString(StatusEmail.CurrentValue); // DN
                StatusEmail.ViewCustomAttributes = "";

                // FileType
                FileType.ViewValue = ConvertToString(FileType.CurrentValue); // DN
                FileType.ViewCustomAttributes = "";

                // OriginalFileName
                OriginalFileName.ViewValue = ConvertToString(OriginalFileName.CurrentValue); // DN
                OriginalFileName.ViewCustomAttributes = "";

                // Flag
                Flag.ViewValue = ConvertToString(Flag.CurrentValue); // DN
                Flag.ViewCustomAttributes = "";

                // Id
                Id.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // Penjelasan
                Penjelasan.HrefValue = "";

                // UploadEvidence
                UploadEvidence.HrefValue = "";

                // CreatedDate
                CreatedDate.HrefValue = "";

                // CreatedBy
                CreatedBy.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // LastUpdatedDate
                LastUpdatedDate.HrefValue = "";

                // StatusEmail
                StatusEmail.HrefValue = "";

                // FileType
                FileType.HrefValue = "";

                // OriginalFileName
                OriginalFileName.HrefValue = "";

                // Flag
                Flag.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // Id
                Id.SetupEditAttributes();
                Id.EditValue = Id.CurrentValue;
                Id.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // Penjelasan
                Penjelasan.SetupEditAttributes();
                Penjelasan.EditValue = Penjelasan.CurrentValue; // DN
                Penjelasan.PlaceHolder = RemoveHtml(Penjelasan.Caption);

                // UploadEvidence
                UploadEvidence.SetupEditAttributes();
                if (!UploadEvidence.Raw)
                    UploadEvidence.CurrentValue = HtmlDecode(UploadEvidence.CurrentValue);
                UploadEvidence.EditValue = HtmlEncode(UploadEvidence.CurrentValue);
                UploadEvidence.PlaceHolder = RemoveHtml(UploadEvidence.Caption);

                // CreatedDate
                CreatedDate.SetupEditAttributes();
                CreatedDate.EditValue = FormatDateTime(CreatedDate.CurrentValue, CreatedDate.FormatPattern);
                CreatedDate.PlaceHolder = RemoveHtml(CreatedDate.Caption);

                // CreatedBy
                CreatedBy.SetupEditAttributes();
                if (!CreatedBy.Raw)
                    CreatedBy.CurrentValue = HtmlDecode(CreatedBy.CurrentValue);
                CreatedBy.EditValue = HtmlEncode(CreatedBy.CurrentValue);
                CreatedBy.PlaceHolder = RemoveHtml(CreatedBy.Caption);

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                if (!LastUpdatedBy.Raw)
                    LastUpdatedBy.CurrentValue = HtmlDecode(LastUpdatedBy.CurrentValue);
                LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.CurrentValue);
                LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

                // LastUpdatedDate
                LastUpdatedDate.SetupEditAttributes();
                LastUpdatedDate.EditValue = FormatDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern);
                LastUpdatedDate.PlaceHolder = RemoveHtml(LastUpdatedDate.Caption);

                // StatusEmail
                StatusEmail.SetupEditAttributes();
                if (!StatusEmail.Raw)
                    StatusEmail.CurrentValue = HtmlDecode(StatusEmail.CurrentValue);
                StatusEmail.EditValue = HtmlEncode(StatusEmail.CurrentValue);
                StatusEmail.PlaceHolder = RemoveHtml(StatusEmail.Caption);

                // FileType
                FileType.SetupEditAttributes();
                if (!FileType.Raw)
                    FileType.CurrentValue = HtmlDecode(FileType.CurrentValue);
                FileType.EditValue = HtmlEncode(FileType.CurrentValue);
                FileType.PlaceHolder = RemoveHtml(FileType.Caption);

                // OriginalFileName
                OriginalFileName.SetupEditAttributes();
                if (!OriginalFileName.Raw)
                    OriginalFileName.CurrentValue = HtmlDecode(OriginalFileName.CurrentValue);
                OriginalFileName.EditValue = HtmlEncode(OriginalFileName.CurrentValue);
                OriginalFileName.PlaceHolder = RemoveHtml(OriginalFileName.Caption);

                // Flag
                Flag.SetupEditAttributes();
                if (!Flag.Raw)
                    Flag.CurrentValue = HtmlDecode(Flag.CurrentValue);
                Flag.EditValue = HtmlEncode(Flag.CurrentValue);
                Flag.PlaceHolder = RemoveHtml(Flag.Caption);

                // Edit refer script

                // Id
                Id.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // Penjelasan
                Penjelasan.HrefValue = "";

                // UploadEvidence
                UploadEvidence.HrefValue = "";

                // CreatedDate
                CreatedDate.HrefValue = "";

                // CreatedBy
                CreatedBy.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // LastUpdatedDate
                LastUpdatedDate.HrefValue = "";

                // StatusEmail
                StatusEmail.HrefValue = "";

                // FileType
                FileType.HrefValue = "";

                // OriginalFileName
                OriginalFileName.HrefValue = "";

                // Flag
                Flag.HrefValue = "";
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
                if (Id.Visible && Id.Required) {
                    if (!Id.IsDetailKey && Empty(Id.FormValue)) {
                        Id.AddErrorMessage(ConvertToString(Id.RequiredErrorMessage).Replace("%s", Id.Caption));
                    }
                }
                if (NoReferensi.Visible && NoReferensi.Required) {
                    if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                        NoReferensi.AddErrorMessage(ConvertToString(NoReferensi.RequiredErrorMessage).Replace("%s", NoReferensi.Caption));
                    }
                }
                if (Penjelasan.Visible && Penjelasan.Required) {
                    if (!Penjelasan.IsDetailKey && Empty(Penjelasan.FormValue)) {
                        Penjelasan.AddErrorMessage(ConvertToString(Penjelasan.RequiredErrorMessage).Replace("%s", Penjelasan.Caption));
                    }
                }
                if (UploadEvidence.Visible && UploadEvidence.Required) {
                    if (!UploadEvidence.IsDetailKey && Empty(UploadEvidence.FormValue)) {
                        UploadEvidence.AddErrorMessage(ConvertToString(UploadEvidence.RequiredErrorMessage).Replace("%s", UploadEvidence.Caption));
                    }
                }
                if (CreatedDate.Visible && CreatedDate.Required) {
                    if (!CreatedDate.IsDetailKey && Empty(CreatedDate.FormValue)) {
                        CreatedDate.AddErrorMessage(ConvertToString(CreatedDate.RequiredErrorMessage).Replace("%s", CreatedDate.Caption));
                    }
                }
                if (!CheckDate(CreatedDate.FormValue, CreatedDate.FormatPattern)) {
                    CreatedDate.AddErrorMessage(CreatedDate.GetErrorMessage(false));
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
                if (!CheckDate(LastUpdatedDate.FormValue, LastUpdatedDate.FormatPattern)) {
                    LastUpdatedDate.AddErrorMessage(LastUpdatedDate.GetErrorMessage(false));
                }
                if (StatusEmail.Visible && StatusEmail.Required) {
                    if (!StatusEmail.IsDetailKey && Empty(StatusEmail.FormValue)) {
                        StatusEmail.AddErrorMessage(ConvertToString(StatusEmail.RequiredErrorMessage).Replace("%s", StatusEmail.Caption));
                    }
                }
                if (FileType.Visible && FileType.Required) {
                    if (!FileType.IsDetailKey && Empty(FileType.FormValue)) {
                        FileType.AddErrorMessage(ConvertToString(FileType.RequiredErrorMessage).Replace("%s", FileType.Caption));
                    }
                }
                if (OriginalFileName.Visible && OriginalFileName.Required) {
                    if (!OriginalFileName.IsDetailKey && Empty(OriginalFileName.FormValue)) {
                        OriginalFileName.AddErrorMessage(ConvertToString(OriginalFileName.RequiredErrorMessage).Replace("%s", OriginalFileName.Caption));
                    }
                }
                if (Flag.Visible && Flag.Required) {
                    if (!Flag.IsDetailKey && Empty(Flag.FormValue)) {
                        Flag.AddErrorMessage(ConvertToString(Flag.RequiredErrorMessage).Replace("%s", Flag.Caption));
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

            // NoReferensi
            NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue, NoReferensi.ReadOnly);

            // Penjelasan
            Penjelasan.SetDbValue(rsnew, Penjelasan.CurrentValue, Penjelasan.ReadOnly);

            // UploadEvidence
            UploadEvidence.SetDbValue(rsnew, UploadEvidence.CurrentValue, UploadEvidence.ReadOnly);

            // CreatedDate
            CreatedDate.SetDbValue(rsnew, ConvertToDateTime(CreatedDate.CurrentValue, CreatedDate.FormatPattern), CreatedDate.ReadOnly);

            // CreatedBy
            CreatedBy.SetDbValue(rsnew, CreatedBy.CurrentValue, CreatedBy.ReadOnly);

            // LastUpdatedBy
            LastUpdatedBy.SetDbValue(rsnew, LastUpdatedBy.CurrentValue, LastUpdatedBy.ReadOnly);

            // LastUpdatedDate
            LastUpdatedDate.SetDbValue(rsnew, ConvertToDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern), LastUpdatedDate.ReadOnly);

            // StatusEmail
            StatusEmail.SetDbValue(rsnew, StatusEmail.CurrentValue, StatusEmail.ReadOnly);

            // FileType
            FileType.SetDbValue(rsnew, FileType.CurrentValue, FileType.ReadOnly);

            // OriginalFileName
            OriginalFileName.SetDbValue(rsnew, OriginalFileName.CurrentValue, OriginalFileName.ReadOnly);

            // Flag
            Flag.SetDbValue(rsnew, Flag.CurrentValue, Flag.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.CurrentValue = value;
            if (row.TryGetValue("Penjelasan", out value)) // Penjelasan
                Penjelasan.CurrentValue = value;
            if (row.TryGetValue("UploadEvidence", out value)) // UploadEvidence
                UploadEvidence.CurrentValue = value;
            if (row.TryGetValue("CreatedDate", out value)) // CreatedDate
                CreatedDate.CurrentValue = value;
            if (row.TryGetValue("CreatedBy", out value)) // CreatedBy
                CreatedBy.CurrentValue = value;
            if (row.TryGetValue("LastUpdatedBy", out value)) // LastUpdatedBy
                LastUpdatedBy.CurrentValue = value;
            if (row.TryGetValue("LastUpdatedDate", out value)) // LastUpdatedDate
                LastUpdatedDate.CurrentValue = value;
            if (row.TryGetValue("StatusEmail", out value)) // StatusEmail
                StatusEmail.CurrentValue = value;
            if (row.TryGetValue("FileType", out value)) // FileType
                FileType.CurrentValue = value;
            if (row.TryGetValue("OriginalFileName", out value)) // OriginalFileName
                OriginalFileName.CurrentValue = value;
            if (row.TryGetValue("Flag", out value)) // Flag
                Flag.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MwtOnlineDetailList")), "", TableVar, true);
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
