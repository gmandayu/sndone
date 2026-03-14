namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// templateProsesEdit
    /// </summary>
    public static TemplateProsesEdit templateProsesEdit
    {
        get => HttpData.Get<TemplateProsesEdit>("templateProsesEdit")!;
        set => HttpData["templateProsesEdit"] = value;
    }

    /// <summary>
    /// Page class for TemplateProses
    /// </summary>
    public class TemplateProsesEdit : TemplateProsesEditBase
    {
        // Constructor
        public TemplateProsesEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public TemplateProsesEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class TemplateProsesEditBase : TemplateProses
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "templateProsesEdit";

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
        public TemplateProsesEditBase()
        {
            TableName = "TemplateProses";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (templateProses)
            if (templateProses == null || templateProses is TemplateProses)
                templateProses = this;

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
        public string PageName => "TemplateProsesEdit";

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
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            TipeProses.Visible = false;
        }

        // Constructor
        public TemplateProsesEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "TemplateProsesView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(IdTemplate);
            await SetupLookupOptions(IdPIC);
            await SetupLookupOptions(IdTools);

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
                if (RouteValues.TryGetValue("IdTemplateProses", out rv)) { // DN
                    IdTemplateProses.FormValue = UrlDecode(rv); // DN
                    IdTemplateProses.OldValue = IdTemplateProses.FormValue;
                } else if (CurrentForm.HasValue("x_IdTemplateProses")) {
                    IdTemplateProses.FormValue = CurrentForm.GetValue("x_IdTemplateProses");
                    IdTemplateProses.OldValue = IdTemplateProses.FormValue;
                } else if (!Empty(keyValues)) {
                    IdTemplateProses.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("IdTemplateProses", out rv)) { // DN
                        IdTemplateProses.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("IdTemplateProses", out sv)) {
                        IdTemplateProses.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdTemplateProses.CurrentValue = DbNullValue;
                    }
                }

                // Set up master detail parameters
                SetupMasterParms();

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
                IdTemplateProses.FormValue = ConvertToString(keyValues[0]);
            }

            // Set up detail parameters
            SetupDetailParms();
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
                            return Terminate("TemplateProsesList"); // No matching record, return to list
                        }

                    // Set up detail parameters
                    SetupDetailParms();
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = "";
                    if (!Empty(CurrentDetailTable)) // Master/detail edit
                        returnUrl = GetViewUrl(Config.TableShowDetail + "=" + CurrentDetailTable); // Master/Detail view page
                    else
                        returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "TemplateProsesList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "TemplateProsesList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "TemplateProsesList"; // Return list page content
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

                        // Set up detail parameters
                        SetupDetailParms();
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
                templateProsesEdit?.PageRender();
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

            // Check field name 'IdTemplate' before field var 'x_IdTemplate'
            val = CurrentForm.HasValue("IdTemplate") ? CurrentForm.GetValue("IdTemplate") : CurrentForm.GetValue("x_IdTemplate");
            if (!IdTemplate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTemplate") && !CurrentForm.HasValue("x_IdTemplate")) // DN
                    IdTemplate.Visible = false; // Disable update for API request
                else
                    IdTemplate.SetFormValue(val);
            }

            // Check field name 'UrutanProses' before field var 'x_UrutanProses'
            val = CurrentForm.HasValue("UrutanProses") ? CurrentForm.GetValue("UrutanProses") : CurrentForm.GetValue("x_UrutanProses");
            if (!UrutanProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UrutanProses") && !CurrentForm.HasValue("x_UrutanProses")) // DN
                    UrutanProses.Visible = false; // Disable update for API request
                else
                    UrutanProses.SetFormValue(val, true, validate);
            }

            // Check field name 'NamaProses' before field var 'x_NamaProses'
            val = CurrentForm.HasValue("NamaProses") ? CurrentForm.GetValue("NamaProses") : CurrentForm.GetValue("x_NamaProses");
            if (!NamaProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaProses") && !CurrentForm.HasValue("x_NamaProses")) // DN
                    NamaProses.Visible = false; // Disable update for API request
                else
                    NamaProses.SetFormValue(val);
            }

            // Check field name 'IdPIC' before field var 'x_IdPIC'
            val = CurrentForm.HasValue("IdPIC") ? CurrentForm.GetValue("IdPIC") : CurrentForm.GetValue("x_IdPIC");
            if (!IdPIC.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPIC") && !CurrentForm.HasValue("x_IdPIC")) // DN
                    IdPIC.Visible = false; // Disable update for API request
                else
                    IdPIC.SetFormValue(val);
            }

            // Check field name 'IdTools' before field var 'x_IdTools'
            val = CurrentForm.HasValue("IdTools") ? CurrentForm.GetValue("IdTools") : CurrentForm.GetValue("x_IdTools");
            if (!IdTools.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTools") && !CurrentForm.HasValue("x_IdTools")) // DN
                    IdTools.Visible = false; // Disable update for API request
                else
                    IdTools.SetFormValue(val);
            }

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }

            // Check field name 'IdTemplateProses' before field var 'x_IdTemplateProses'
            val = CurrentForm.HasValue("IdTemplateProses") ? CurrentForm.GetValue("IdTemplateProses") : CurrentForm.GetValue("x_IdTemplateProses");
            if (!IdTemplateProses.IsDetailKey)
                IdTemplateProses.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdTemplateProses.CurrentValue = IdTemplateProses.FormValue;
            IdTemplate.CurrentValue = IdTemplate.FormValue;
            UrutanProses.CurrentValue = UrutanProses.FormValue;
            NamaProses.CurrentValue = NamaProses.FormValue;
            IdPIC.CurrentValue = IdPIC.FormValue;
            IdTools.CurrentValue = IdTools.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
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
            IdTemplateProses.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // UrutanProses
            UrutanProses.RowCssClass = "row";

            // NamaProses
            NamaProses.RowCssClass = "row";

            // IdPIC
            IdPIC.RowCssClass = "row";

            // IdTools
            IdTools.RowCssClass = "row";

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

            // TipeProses
            TipeProses.RowCssClass = "row";

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
            } else if (RowType == RowType.Edit) {
                // IdTemplate
                IdTemplate.SetupEditAttributes();
                if (!Empty(IdTemplate.SessionValue)) {
                    IdTemplate.CurrentValue = ForeignKeyValue(IdTemplate.SessionValue);
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
                if (!Empty(UrutanProses.EditValue) && IsNumeric(UrutanProses.EditValue))
                    UrutanProses.EditValue = FormatNumber(UrutanProses.EditValue, null);

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

            // Validate detail grid
            var detailTblVar = CurrentDetailTables;
            if (detailTblVar.Contains("TemplateAktivitas") && templateAktivitas?.DetailEdit == true) {
                templateAktivitasGrid = Resolve("TemplateAktivitasGrid")!; // Get detail page object
                if (templateAktivitasGrid != null)
                    validateForm = validateForm && await templateAktivitasGrid.ValidateGridForm();
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

            // Begin transaction
            if (!Empty(CurrentDetailTable) && UseTransaction)
                Connection.BeginTrans();
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

                    // Update detail records
                    var detailTblVar = CurrentDetailTables;
                    if (detailTblVar.Contains("TemplateAktivitas") && templateAktivitas?.DetailEdit == true && result) {
                        templateAktivitasGrid = Resolve("TemplateAktivitasGrid")!; // Get detail page object
                        if (templateAktivitasGrid != null) {
                            Security.LoadCurrentUserLevel(ProjectID + "TemplateAktivitas"); // Load user level of detail table
                            result = await templateAktivitasGrid.GridUpdate();
                            Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
                        }
                    }

                    // Commit/Rollback transaction
                    if (!Empty(CurrentDetailTable) && UseTransaction) {
                        if (result) {
                            Connection.CommitTrans(); // Commit transaction
                        } else {
                            Connection.RollbackTrans(); // Rollback transaction
                        }
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
        }

        // Set up master/detail based on QueryString
        protected void SetupMasterParms() {
            bool validMaster = false;
            StringValues masterTblVar;
            StringValues fk;
            Dictionary<string, object> foreignKeys = new();

            // Get the keys for master table
            if (Query.TryGetValue(Config.TableShowMaster, out masterTblVar) || Query.TryGetValue(Config.TableMaster, out masterTblVar)) { // Do not use Get()
                if (Empty(masterTblVar)) {
                    validMaster = true;
                    DbMasterFilter = "";
                    DbDetailFilter = "";
                }
                if (masterTblVar == "MasterTemplate") {
                    validMaster = true;
                    if (masterTemplate != null && (Get("fk_IdTemplate", out fk) || Get("IdTemplate", out fk))) {
                        masterTemplate.IdTemplate.QueryValue = fk;
                        IdTemplate.QueryValue = masterTemplate.IdTemplate.QueryValue;
                        IdTemplate.SessionValue = IdTemplate.QueryValue;
                        foreignKeys.Add("IdTemplate", fk);
                        if (!IsNumeric(IdTemplate.QueryValue))
                            validMaster = false;
                    } else {
                        validMaster = false;
                    }
                }
            } else if (Form.TryGetValue(Config.TableShowMaster, out masterTblVar) || Form.TryGetValue(Config.TableMaster, out masterTblVar)) {
                if (masterTblVar == "") {
                    validMaster = true;
                    DbMasterFilter = "";
                    DbDetailFilter = "";
                }
                if (masterTblVar == "MasterTemplate") {
                    validMaster = true;
                    if (masterTemplate != null && (Post("fk_IdTemplate", out fk) || Post("IdTemplate", out fk))) {
                        masterTemplate.IdTemplate.FormValue = fk;
                        IdTemplate.FormValue = masterTemplate.IdTemplate.FormValue;
                        IdTemplate.SessionValue = IdTemplate.FormValue;
                        foreignKeys.Add("IdTemplate", fk);
                        if (!IsNumeric(IdTemplate.FormValue))
                            validMaster = false;
                    } else {
                        validMaster = false;
                    }
                }
            }
            if (validMaster) {
                // Save current master table
                CurrentMasterTable = masterTblVar.ToString();
                SessionWhere = DetailFilterFromSession;

                // Clear previous master key from Session
                if (masterTblVar != "MasterTemplate") {
                    if (!foreignKeys.ContainsKey("IdTemplate")) // Not current foreign key
                        IdTemplate.SessionValue = "";
                }
            }
            DbMasterFilter = MasterFilterFromSession; // Get master filter from session
            DbDetailFilter = DetailFilterFromSession; // Get detail filter from session
        }

        // Set up detail parms based on QueryString
        protected void SetupDetailParms() {
            StringValues detailTblVar = "";
            // Get the keys for master table
            if (Query.TryGetValue(Config.TableShowDetail, out detailTblVar)) { // Do not use Get()
                CurrentDetailTable = detailTblVar.ToString();
            } else {
                detailTblVar = CurrentDetailTable;
            }
            if (!Empty(detailTblVar)) {
                var detailTblVars = detailTblVar.ToString().Split(',');
                if (detailTblVars.Contains("TemplateAktivitas")) {
                    templateAktivitasGrid = Resolve("TemplateAktivitasGrid")!;
                    if (templateAktivitasGrid?.DetailEdit ?? false) {
                        templateAktivitasGrid.CurrentMode = "edit";
                        templateAktivitasGrid.CurrentAction = "gridedit";

                        // Save current master table to detail table
                        templateAktivitasGrid.CurrentMasterTable = TableVar;
                        templateAktivitasGrid.StartRecordNumber = 1;
                        templateAktivitasGrid.IdTemplateProses.IsDetailKey = true;
                        templateAktivitasGrid.IdTemplateProses.CurrentValue = IdTemplateProses.CurrentValue;
                        templateAktivitasGrid.IdTemplateProses.SessionValue = templateAktivitasGrid.IdTemplateProses.CurrentValue;
                    }
                }
            }
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("TemplateProsesList")), "", TableVar, true);
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
