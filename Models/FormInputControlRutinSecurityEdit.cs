namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// formInputControlRutinSecurityEdit
    /// </summary>
    public static FormInputControlRutinSecurityEdit formInputControlRutinSecurityEdit
    {
        get => HttpData.Get<FormInputControlRutinSecurityEdit>("formInputControlRutinSecurityEdit")!;
        set => HttpData["formInputControlRutinSecurityEdit"] = value;
    }

    /// <summary>
    /// Page class for FormInputControlRutinSecurity
    /// </summary>
    public class FormInputControlRutinSecurityEdit : FormInputControlRutinSecurityEditBase
    {
        // Constructor
        public FormInputControlRutinSecurityEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public FormInputControlRutinSecurityEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class FormInputControlRutinSecurityEditBase : FormInputControlRutinSecurity
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "formInputControlRutinSecurityEdit";

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
        public FormInputControlRutinSecurityEditBase()
        {
            TableName = "FormInputControlRutinSecurity";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (formInputControlRutinSecurity)
            if (formInputControlRutinSecurity == null || formInputControlRutinSecurity is FormInputControlRutinSecurity)
                formInputControlRutinSecurity = this;

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
        public string PageName => "FormInputControlRutinSecurityEdit";

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
            NamaSecurity.SetVisibility();
            Tanggal.SetVisibility();
            Lokasi.SetVisibility();
            DownloadDokumen.Visible = false;
            UploadFoto.Visible = false;
            Ketidaksesuaiaan.SetVisibility();
            Keterangan.SetVisibility();
            IdPosition.SetVisibility();
            UserInput.SetVisibility();
            EtlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            LastUpdatedDate.SetVisibility();
        }

        // Constructor
        public FormInputControlRutinSecurityEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "FormInputControlRutinSecurityView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(Lokasi);
            await SetupLookupOptions(Ketidaksesuaiaan);

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
                            return Terminate("FormInputControlRutinSecurityList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "FormInputControlRutinSecurityList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "FormInputControlRutinSecurityList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "FormInputControlRutinSecurityList"; // Return list page content
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
                formInputControlRutinSecurityEdit?.PageRender();
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

            // Check field name 'NamaSecurity' before field var 'x_NamaSecurity'
            val = CurrentForm.HasValue("NamaSecurity") ? CurrentForm.GetValue("NamaSecurity") : CurrentForm.GetValue("x_NamaSecurity");
            if (!NamaSecurity.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaSecurity") && !CurrentForm.HasValue("x_NamaSecurity")) // DN
                    NamaSecurity.Visible = false; // Disable update for API request
                else
                    NamaSecurity.SetFormValue(val);
            }

            // Check field name 'Tanggal' before field var 'x_Tanggal'
            val = CurrentForm.HasValue("Tanggal") ? CurrentForm.GetValue("Tanggal") : CurrentForm.GetValue("x_Tanggal");
            if (!Tanggal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Tanggal") && !CurrentForm.HasValue("x_Tanggal")) // DN
                    Tanggal.Visible = false; // Disable update for API request
                else
                    Tanggal.SetFormValue(val, true, validate);
                Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            }

            // Check field name 'Lokasi' before field var 'x_Lokasi'
            val = CurrentForm.HasValue("Lokasi") ? CurrentForm.GetValue("Lokasi") : CurrentForm.GetValue("x_Lokasi");
            if (!Lokasi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Lokasi") && !CurrentForm.HasValue("x_Lokasi")) // DN
                    Lokasi.Visible = false; // Disable update for API request
                else
                    Lokasi.SetFormValue(val);
            }

            // Check field name 'Ketidaksesuaiaan' before field var 'x_Ketidaksesuaiaan'
            val = CurrentForm.HasValue("Ketidaksesuaiaan") ? CurrentForm.GetValue("Ketidaksesuaiaan") : CurrentForm.GetValue("x_Ketidaksesuaiaan");
            if (!Ketidaksesuaiaan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Ketidaksesuaiaan") && !CurrentForm.HasValue("x_Ketidaksesuaiaan")) // DN
                    Ketidaksesuaiaan.Visible = false; // Disable update for API request
                else
                    Ketidaksesuaiaan.SetFormValue(val);
            }

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }

            // Check field name 'IdPosition' before field var 'x_IdPosition'
            val = CurrentForm.HasValue("IdPosition") ? CurrentForm.GetValue("IdPosition") : CurrentForm.GetValue("x_IdPosition");
            if (!IdPosition.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPosition") && !CurrentForm.HasValue("x_IdPosition")) // DN
                    IdPosition.Visible = false; // Disable update for API request
                else
                    IdPosition.SetFormValue(val, true, validate);
            }

            // Check field name 'UserInput' before field var 'x_UserInput'
            val = CurrentForm.HasValue("UserInput") ? CurrentForm.GetValue("UserInput") : CurrentForm.GetValue("x_UserInput");
            if (!UserInput.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UserInput") && !CurrentForm.HasValue("x_UserInput")) // DN
                    UserInput.Visible = false; // Disable update for API request
                else
                    UserInput.SetFormValue(val);
            }

            // Check field name 'EtlDate' before field var 'x_EtlDate'
            val = CurrentForm.HasValue("EtlDate") ? CurrentForm.GetValue("EtlDate") : CurrentForm.GetValue("x_EtlDate");
            if (!EtlDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("EtlDate") && !CurrentForm.HasValue("x_EtlDate")) // DN
                    EtlDate.Visible = false; // Disable update for API request
                else
                    EtlDate.SetFormValue(val);
                EtlDate.CurrentValue = UnformatDateTime(EtlDate.CurrentValue, EtlDate.FormatPattern);
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
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            Id.CurrentValue = Id.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            NamaSecurity.CurrentValue = NamaSecurity.FormValue;
            Tanggal.CurrentValue = Tanggal.FormValue;
            Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            Lokasi.CurrentValue = Lokasi.FormValue;
            Ketidaksesuaiaan.CurrentValue = Ketidaksesuaiaan.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            IdPosition.CurrentValue = IdPosition.FormValue;
            UserInput.CurrentValue = UserInput.FormValue;
            EtlDate.CurrentValue = EtlDate.FormValue;
            EtlDate.CurrentValue = UnformatDateTime(EtlDate.CurrentValue, EtlDate.FormatPattern);
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            LastUpdatedDate.CurrentValue = LastUpdatedDate.FormValue;
            LastUpdatedDate.CurrentValue = UnformatDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern);
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
            NamaSecurity.SetDbValue(row["NamaSecurity"]);
            Tanggal.SetDbValue(row["Tanggal"]);
            Lokasi.SetDbValue(row["Lokasi"]);
            DownloadDokumen.SetDbValue(row["DownloadDokumen"]);
            UploadFoto.SetDbValue(row["UploadFoto"]);
            Ketidaksesuaiaan.SetDbValue(row["Ketidaksesuaiaan"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            IdPosition.SetDbValue(row["IdPosition"]);
            UserInput.SetDbValue(row["UserInput"]);
            EtlDate.SetDbValue(row["EtlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDate.SetDbValue(row["LastUpdatedDate"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("Id", Id.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaSecurity", NamaSecurity.DefaultValue ?? DbNullValue); // DN
            row.Add("Tanggal", Tanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("Lokasi", Lokasi.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadDokumen", DownloadDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("UploadFoto", UploadFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("Ketidaksesuaiaan", Ketidaksesuaiaan.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPosition", IdPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("UserInput", UserInput.DefaultValue ?? DbNullValue); // DN
            row.Add("EtlDate", EtlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDate", LastUpdatedDate.DefaultValue ?? DbNullValue); // DN
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

            // NamaSecurity
            NamaSecurity.RowCssClass = "row";

            // Tanggal
            Tanggal.RowCssClass = "row";

            // Lokasi
            Lokasi.RowCssClass = "row";

            // DownloadDokumen
            DownloadDokumen.RowCssClass = "row";

            // UploadFoto
            UploadFoto.RowCssClass = "row";

            // Ketidaksesuaiaan
            Ketidaksesuaiaan.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // IdPosition
            IdPosition.RowCssClass = "row";

            // UserInput
            UserInput.RowCssClass = "row";

            // EtlDate
            EtlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // LastUpdatedDate
            LastUpdatedDate.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // Id
                Id.ViewValue = Id.CurrentValue;
                Id.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // NamaSecurity
                NamaSecurity.ViewValue = ConvertToString(NamaSecurity.CurrentValue); // DN
                NamaSecurity.ViewCustomAttributes = "";

                // Tanggal
                Tanggal.ViewValue = Tanggal.CurrentValue;
                Tanggal.ViewValue = FormatDateTime(Tanggal.ViewValue, Tanggal.FormatPattern);
                Tanggal.ViewCustomAttributes = "";

                // Lokasi
                string curVal = ConvertToString(Lokasi.CurrentValue);
                if (!Empty(curVal)) {
                    if (Lokasi.Lookup != null && IsDictionary(Lokasi.Lookup?.Options) && Lokasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Lokasi.ViewValue = Lokasi.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(Lokasi.Lookup?.GetTable()?.Fields["ID"].SearchExpression, "=", Lokasi.CurrentValue, Lokasi.Lookup?.GetTable()?.Fields["ID"].SearchDataType, "");
                        string? sqlWrk = Lokasi.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Lokasi.Lookup != null) { // Lookup values found
                            var listwrk = Lokasi.Lookup?.RenderViewRow(rswrk[0]);
                            Lokasi.ViewValue = Lokasi.DisplayValue(listwrk);
                        } else {
                            Lokasi.ViewValue = Lokasi.CurrentValue;
                        }
                    }
                } else {
                    Lokasi.ViewValue = DbNullValue;
                }
                Lokasi.ViewCustomAttributes = "";

                // Ketidaksesuaiaan
                if (!Empty(Ketidaksesuaiaan.CurrentValue)) {
                    Ketidaksesuaiaan.ViewValue = Ketidaksesuaiaan.OptionCaption(ConvertToString(Ketidaksesuaiaan.CurrentValue));
                } else {
                    Ketidaksesuaiaan.ViewValue = DbNullValue;
                }
                Ketidaksesuaiaan.ViewCustomAttributes = "";

                // Keterangan
                Keterangan.ViewValue = Keterangan.CurrentValue;
                Keterangan.ViewCustomAttributes = "";

                // IdPosition
                IdPosition.ViewValue = IdPosition.CurrentValue;
                IdPosition.ViewCustomAttributes = "";

                // UserInput
                UserInput.ViewValue = ConvertToString(UserInput.CurrentValue); // DN
                UserInput.ViewCustomAttributes = "";

                // EtlDate
                EtlDate.ViewValue = EtlDate.CurrentValue;
                EtlDate.ViewValue = FormatDateTime(EtlDate.ViewValue, EtlDate.FormatPattern);
                EtlDate.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // LastUpdatedDate
                LastUpdatedDate.ViewValue = LastUpdatedDate.CurrentValue;
                LastUpdatedDate.ViewValue = FormatDateTime(LastUpdatedDate.ViewValue, LastUpdatedDate.FormatPattern);
                LastUpdatedDate.ViewCustomAttributes = "";

                // Id
                Id.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // NamaSecurity
                NamaSecurity.HrefValue = "";

                // Tanggal
                Tanggal.HrefValue = "";

                // Lokasi
                Lokasi.HrefValue = "";

                // Ketidaksesuaiaan
                Ketidaksesuaiaan.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // UserInput
                UserInput.HrefValue = "";

                // EtlDate
                EtlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // LastUpdatedDate
                LastUpdatedDate.HrefValue = "";
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

                // NamaSecurity
                NamaSecurity.SetupEditAttributes();
                if (!NamaSecurity.Raw)
                    NamaSecurity.CurrentValue = HtmlDecode(NamaSecurity.CurrentValue);
                NamaSecurity.EditValue = HtmlEncode(NamaSecurity.CurrentValue);
                NamaSecurity.PlaceHolder = RemoveHtml(NamaSecurity.Caption);

                // Tanggal
                Tanggal.SetupEditAttributes();
                Tanggal.EditValue = FormatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
                Tanggal.PlaceHolder = RemoveHtml(Tanggal.Caption);

                // Lokasi
                Lokasi.SetupEditAttributes();
                string curVal = ConvertToString(Lokasi.CurrentValue);
                if (Lokasi.Lookup != null && IsDictionary(Lokasi.Lookup?.Options) && Lokasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Lokasi.EditValue = Lokasi.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk = "";
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter(Lokasi.Lookup?.GetTable()?.Fields["ID"].SearchExpression, "=", Lokasi.CurrentValue, Lokasi.Lookup?.GetTable()?.Fields["ID"].SearchDataType, "");
                    }
                    string? sqlWrk = Lokasi.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Lokasi.EditValue = rswrk;
                }
                Lokasi.PlaceHolder = RemoveHtml(Lokasi.Caption);

                // Ketidaksesuaiaan
                Ketidaksesuaiaan.SetupEditAttributes();
                Ketidaksesuaiaan.EditValue = Ketidaksesuaiaan.Options(true);
                Ketidaksesuaiaan.PlaceHolder = RemoveHtml(Ketidaksesuaiaan.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // IdPosition
                IdPosition.SetupEditAttributes();
                IdPosition.EditValue = IdPosition.CurrentValue;
                IdPosition.PlaceHolder = RemoveHtml(IdPosition.Caption);

                // UserInput

                // EtlDate

                // LastUpdatedBy

                // LastUpdatedDate

                // Edit refer script

                // Id
                Id.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // NamaSecurity
                NamaSecurity.HrefValue = "";

                // Tanggal
                Tanggal.HrefValue = "";

                // Lokasi
                Lokasi.HrefValue = "";

                // Ketidaksesuaiaan
                Ketidaksesuaiaan.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // UserInput
                UserInput.HrefValue = "";

                // EtlDate
                EtlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // LastUpdatedDate
                LastUpdatedDate.HrefValue = "";
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
                if (NamaSecurity.Visible && NamaSecurity.Required) {
                    if (!NamaSecurity.IsDetailKey && Empty(NamaSecurity.FormValue)) {
                        NamaSecurity.AddErrorMessage(ConvertToString(NamaSecurity.RequiredErrorMessage).Replace("%s", NamaSecurity.Caption));
                    }
                }
                if (Tanggal.Visible && Tanggal.Required) {
                    if (!Tanggal.IsDetailKey && Empty(Tanggal.FormValue)) {
                        Tanggal.AddErrorMessage(ConvertToString(Tanggal.RequiredErrorMessage).Replace("%s", Tanggal.Caption));
                    }
                }
                if (!CheckDate(Tanggal.FormValue, Tanggal.FormatPattern)) {
                    Tanggal.AddErrorMessage(Tanggal.GetErrorMessage(false));
                }
                if (Lokasi.Visible && Lokasi.Required) {
                    if (!Lokasi.IsDetailKey && Empty(Lokasi.FormValue)) {
                        Lokasi.AddErrorMessage(ConvertToString(Lokasi.RequiredErrorMessage).Replace("%s", Lokasi.Caption));
                    }
                }
                if (Ketidaksesuaiaan.Visible && Ketidaksesuaiaan.Required) {
                    if (!Ketidaksesuaiaan.IsDetailKey && Empty(Ketidaksesuaiaan.FormValue)) {
                        Ketidaksesuaiaan.AddErrorMessage(ConvertToString(Ketidaksesuaiaan.RequiredErrorMessage).Replace("%s", Ketidaksesuaiaan.Caption));
                    }
                }
                if (Keterangan.Visible && Keterangan.Required) {
                    if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                        Keterangan.AddErrorMessage(ConvertToString(Keterangan.RequiredErrorMessage).Replace("%s", Keterangan.Caption));
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
                if (UserInput.Visible && UserInput.Required) {
                    if (!UserInput.IsDetailKey && Empty(UserInput.FormValue)) {
                        UserInput.AddErrorMessage(ConvertToString(UserInput.RequiredErrorMessage).Replace("%s", UserInput.Caption));
                    }
                }
                if (EtlDate.Visible && EtlDate.Required) {
                    if (!EtlDate.IsDetailKey && Empty(EtlDate.FormValue)) {
                        EtlDate.AddErrorMessage(ConvertToString(EtlDate.RequiredErrorMessage).Replace("%s", EtlDate.Caption));
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

            // NamaSecurity
            NamaSecurity.SetDbValue(rsnew, NamaSecurity.CurrentValue, NamaSecurity.ReadOnly);

            // Tanggal
            Tanggal.SetDbValue(rsnew, ConvertToDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern), Tanggal.ReadOnly);

            // Lokasi
            Lokasi.SetDbValue(rsnew, Lokasi.CurrentValue, Lokasi.ReadOnly);

            // Ketidaksesuaiaan
            Ketidaksesuaiaan.SetDbValue(rsnew, Ketidaksesuaiaan.CurrentValue, Ketidaksesuaiaan.ReadOnly);

            // Keterangan
            Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue, Keterangan.ReadOnly);

            // IdPosition
            IdPosition.SetDbValue(rsnew, IdPosition.CurrentValue, IdPosition.ReadOnly);

            // UserInput
            UserInput.CurrentValue = UserInput.GetAutoUpdateValue();
            UserInput.SetDbValue(rsnew, UserInput.CurrentValue, UserInput.ReadOnly);

            // EtlDate
            EtlDate.CurrentValue = EtlDate.GetAutoUpdateValue();
            EtlDate.SetDbValue(rsnew, ConvertToDateTime(EtlDate.CurrentValue, EtlDate.FormatPattern), EtlDate.ReadOnly);

            // LastUpdatedBy
            LastUpdatedBy.CurrentValue = LastUpdatedBy.GetAutoUpdateValue();
            LastUpdatedBy.SetDbValue(rsnew, LastUpdatedBy.CurrentValue, LastUpdatedBy.ReadOnly);

            // LastUpdatedDate
            LastUpdatedDate.CurrentValue = LastUpdatedDate.GetAutoUpdateValue();
            LastUpdatedDate.SetDbValue(rsnew, ConvertToDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern), LastUpdatedDate.ReadOnly);
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
            if (row.TryGetValue("NamaSecurity", out value)) // NamaSecurity
                NamaSecurity.CurrentValue = value;
            if (row.TryGetValue("Tanggal", out value)) // Tanggal
                Tanggal.CurrentValue = value;
            if (row.TryGetValue("Lokasi", out value)) // Lokasi
                Lokasi.CurrentValue = value;
            if (row.TryGetValue("Ketidaksesuaiaan", out value)) // Ketidaksesuaiaan
                Ketidaksesuaiaan.CurrentValue = value;
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.CurrentValue = value;
            if (row.TryGetValue("IdPosition", out value)) // IdPosition
                IdPosition.CurrentValue = value;
            if (row.TryGetValue("UserInput", out value)) // UserInput
                UserInput.CurrentValue = value;
            if (row.TryGetValue("EtlDate", out value)) // EtlDate
                EtlDate.CurrentValue = value;
            if (row.TryGetValue("LastUpdatedBy", out value)) // LastUpdatedBy
                LastUpdatedBy.CurrentValue = value;
            if (row.TryGetValue("LastUpdatedDate", out value)) // LastUpdatedDate
                LastUpdatedDate.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("FormInputControlRutinSecurityList")), "", TableVar, true);
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
