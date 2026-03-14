namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// setPjsEdit
    /// </summary>
    public static SetPjsEdit setPjsEdit
    {
        get => HttpData.Get<SetPjsEdit>("setPjsEdit")!;
        set => HttpData["setPjsEdit"] = value;
    }

    /// <summary>
    /// Page class for SetPjs
    /// </summary>
    public class SetPjsEdit : SetPjsEditBase
    {
        // Constructor
        public SetPjsEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SetPjsEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
            PosisiAwal.DisplayValueSeparator = " - ";
            PosisiPJS.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SetPjsEditBase : SetPjs
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "setPjsEdit";

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
        public SetPjsEditBase()
        {
            TableName = "SetPjs";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (setPjs)
            if (setPjs == null || setPjs is SetPjs)
                setPjs = this;

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
        public string PageName => "SetPjsEdit";

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
            NomorPjs.SetVisibility();
            RedirectLink.SetVisibility();
            Nama.SetVisibility();
            OrganizationLevel.SetVisibility();
            Region.SetVisibility();
            Plant.SetVisibility();
            PosisiAwal.SetVisibility();
            PosisiPJS.SetVisibility();
            LookupPosition.SetVisibility();
            TanggalMulai.SetVisibility();
            TanggalSelesai.SetVisibility();
            Status.SetVisibility();
            DownloadSuratTugas.SetVisibility();
            SuratTugas.SetVisibility();
            Keterangan.SetVisibility();
            Remaks.SetVisibility();
            DibuatOleh.SetVisibility();
            TanggalDibuat.SetVisibility();
            DiperbaharuiOleh.SetVisibility();
            DiperbaharuiTanggal.SetVisibility();
            PlantAwal.SetVisibility();
            RegionAwal.SetVisibility();
        }

        // Constructor
        public SetPjsEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "SetPjsView" ? "1" : "0"); // If View page, no primary button
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
            NomorPjs.Required = false;
            Status.Required = false;

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
            await SetupLookupOptions(OrganizationLevel);
            await SetupLookupOptions(Region);
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(PosisiAwal);
            await SetupLookupOptions(PosisiPJS);
            await SetupLookupOptions(LookupPosition);
            await SetupLookupOptions(DibuatOleh);
            await SetupLookupOptions(DiperbaharuiOleh);

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
                            return Terminate("SetPjsList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "SetPjsList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SetPjsList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SetPjsList"; // Return list page content
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
                setPjsEdit?.PageRender();
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

            // Check field name 'NomorPjs' before field var 'x_NomorPjs'
            val = CurrentForm.HasValue("NomorPjs") ? CurrentForm.GetValue("NomorPjs") : CurrentForm.GetValue("x_NomorPjs");
            if (!NomorPjs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorPjs") && !CurrentForm.HasValue("x_NomorPjs")) // DN
                    NomorPjs.Visible = false; // Disable update for API request
                else
                    NomorPjs.SetFormValue(val);
            }

            // Check field name 'RedirectLink' before field var 'x_RedirectLink'
            val = CurrentForm.HasValue("RedirectLink") ? CurrentForm.GetValue("RedirectLink") : CurrentForm.GetValue("x_RedirectLink");
            if (!RedirectLink.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RedirectLink") && !CurrentForm.HasValue("x_RedirectLink")) // DN
                    RedirectLink.Visible = false; // Disable update for API request
                else
                    RedirectLink.SetFormValue(val);
            }

            // Check field name 'Nama' before field var 'x_Nama'
            val = CurrentForm.HasValue("Nama") ? CurrentForm.GetValue("Nama") : CurrentForm.GetValue("x_Nama");
            if (!Nama.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Nama") && !CurrentForm.HasValue("x_Nama")) // DN
                    Nama.Visible = false; // Disable update for API request
                else
                    Nama.SetFormValue(val);
            }

            // Check field name 'OrganizationLevel' before field var 'x_OrganizationLevel'
            val = CurrentForm.HasValue("OrganizationLevel") ? CurrentForm.GetValue("OrganizationLevel") : CurrentForm.GetValue("x_OrganizationLevel");
            if (!OrganizationLevel.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("OrganizationLevel") && !CurrentForm.HasValue("x_OrganizationLevel")) // DN
                    OrganizationLevel.Visible = false; // Disable update for API request
                else
                    OrganizationLevel.SetFormValue(val);
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

            // Check field name 'PosisiAwal' before field var 'x_PosisiAwal'
            val = CurrentForm.HasValue("PosisiAwal") ? CurrentForm.GetValue("PosisiAwal") : CurrentForm.GetValue("x_PosisiAwal");
            if (!PosisiAwal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PosisiAwal") && !CurrentForm.HasValue("x_PosisiAwal")) // DN
                    PosisiAwal.Visible = false; // Disable update for API request
                else
                    PosisiAwal.SetFormValue(val);
            }

            // Check field name 'PosisiPJS' before field var 'x_PosisiPJS'
            val = CurrentForm.HasValue("PosisiPJS") ? CurrentForm.GetValue("PosisiPJS") : CurrentForm.GetValue("x_PosisiPJS");
            if (!PosisiPJS.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PosisiPJS") && !CurrentForm.HasValue("x_PosisiPJS")) // DN
                    PosisiPJS.Visible = false; // Disable update for API request
                else
                    PosisiPJS.SetFormValue(val);
            }

            // Check field name 'LookupPosition' before field var 'x_LookupPosition'
            val = CurrentForm.HasValue("LookupPosition") ? CurrentForm.GetValue("LookupPosition") : CurrentForm.GetValue("x_LookupPosition");
            if (!LookupPosition.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LookupPosition") && !CurrentForm.HasValue("x_LookupPosition")) // DN
                    LookupPosition.Visible = false; // Disable update for API request
                else
                    LookupPosition.SetFormValue(val);
            }

            // Check field name 'TanggalMulai' before field var 'x_TanggalMulai'
            val = CurrentForm.HasValue("TanggalMulai") ? CurrentForm.GetValue("TanggalMulai") : CurrentForm.GetValue("x_TanggalMulai");
            if (!TanggalMulai.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalMulai") && !CurrentForm.HasValue("x_TanggalMulai")) // DN
                    TanggalMulai.Visible = false; // Disable update for API request
                else
                    TanggalMulai.SetFormValue(val, true, validate);
                TanggalMulai.CurrentValue = UnformatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
            }

            // Check field name 'TanggalSelesai' before field var 'x_TanggalSelesai'
            val = CurrentForm.HasValue("TanggalSelesai") ? CurrentForm.GetValue("TanggalSelesai") : CurrentForm.GetValue("x_TanggalSelesai");
            if (!TanggalSelesai.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalSelesai") && !CurrentForm.HasValue("x_TanggalSelesai")) // DN
                    TanggalSelesai.Visible = false; // Disable update for API request
                else
                    TanggalSelesai.SetFormValue(val, true, validate);
                TanggalSelesai.CurrentValue = UnformatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
            }

            // Check field name 'Status' before field var 'x_Status'
            val = CurrentForm.HasValue("Status") ? CurrentForm.GetValue("Status") : CurrentForm.GetValue("x_Status");
            if (!Status.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Status") && !CurrentForm.HasValue("x_Status")) // DN
                    Status.Visible = false; // Disable update for API request
                else
                    Status.SetFormValue(val);
            }

            // Check field name 'DownloadSuratTugas' before field var 'x_DownloadSuratTugas'
            val = CurrentForm.HasValue("DownloadSuratTugas") ? CurrentForm.GetValue("DownloadSuratTugas") : CurrentForm.GetValue("x_DownloadSuratTugas");
            if (!DownloadSuratTugas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DownloadSuratTugas") && !CurrentForm.HasValue("x_DownloadSuratTugas")) // DN
                    DownloadSuratTugas.Visible = false; // Disable update for API request
                else
                    DownloadSuratTugas.SetFormValue(val);
            }

            // Check field name 'SuratTugas' before field var 'x_SuratTugas'
            val = CurrentForm.HasValue("SuratTugas") ? CurrentForm.GetValue("SuratTugas") : CurrentForm.GetValue("x_SuratTugas");
            if (!SuratTugas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SuratTugas") && !CurrentForm.HasValue("x_SuratTugas")) // DN
                    SuratTugas.Visible = false; // Disable update for API request
                else
                    SuratTugas.SetFormValue(val);
            }

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }

            // Check field name 'Remaks' before field var 'x_Remaks'
            val = CurrentForm.HasValue("Remaks") ? CurrentForm.GetValue("Remaks") : CurrentForm.GetValue("x_Remaks");
            if (!Remaks.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Remaks") && !CurrentForm.HasValue("x_Remaks")) // DN
                    Remaks.Visible = false; // Disable update for API request
                else
                    Remaks.SetFormValue(val);
            }

            // Check field name 'DibuatOleh' before field var 'x_DibuatOleh'
            val = CurrentForm.HasValue("DibuatOleh") ? CurrentForm.GetValue("DibuatOleh") : CurrentForm.GetValue("x_DibuatOleh");
            if (!DibuatOleh.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DibuatOleh") && !CurrentForm.HasValue("x_DibuatOleh")) // DN
                    DibuatOleh.Visible = false; // Disable update for API request
                else
                    DibuatOleh.SetFormValue(val);
            }

            // Check field name 'TanggalDibuat' before field var 'x_TanggalDibuat'
            val = CurrentForm.HasValue("TanggalDibuat") ? CurrentForm.GetValue("TanggalDibuat") : CurrentForm.GetValue("x_TanggalDibuat");
            if (!TanggalDibuat.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalDibuat") && !CurrentForm.HasValue("x_TanggalDibuat")) // DN
                    TanggalDibuat.Visible = false; // Disable update for API request
                else
                    TanggalDibuat.SetFormValue(val, true, validate);
                TanggalDibuat.CurrentValue = UnformatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            }

            // Check field name 'DiperbaharuiOleh' before field var 'x_DiperbaharuiOleh'
            val = CurrentForm.HasValue("DiperbaharuiOleh") ? CurrentForm.GetValue("DiperbaharuiOleh") : CurrentForm.GetValue("x_DiperbaharuiOleh");
            if (!DiperbaharuiOleh.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DiperbaharuiOleh") && !CurrentForm.HasValue("x_DiperbaharuiOleh")) // DN
                    DiperbaharuiOleh.Visible = false; // Disable update for API request
                else
                    DiperbaharuiOleh.SetFormValue(val);
            }

            // Check field name 'DiperbaharuiTanggal' before field var 'x_DiperbaharuiTanggal'
            val = CurrentForm.HasValue("DiperbaharuiTanggal") ? CurrentForm.GetValue("DiperbaharuiTanggal") : CurrentForm.GetValue("x_DiperbaharuiTanggal");
            if (!DiperbaharuiTanggal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DiperbaharuiTanggal") && !CurrentForm.HasValue("x_DiperbaharuiTanggal")) // DN
                    DiperbaharuiTanggal.Visible = false; // Disable update for API request
                else
                    DiperbaharuiTanggal.SetFormValue(val);
                DiperbaharuiTanggal.CurrentValue = UnformatDateTime(DiperbaharuiTanggal.CurrentValue, DiperbaharuiTanggal.FormatPattern);
            }

            // Check field name 'PlantAwal' before field var 'x_PlantAwal'
            val = CurrentForm.HasValue("PlantAwal") ? CurrentForm.GetValue("PlantAwal") : CurrentForm.GetValue("x_PlantAwal");
            if (!PlantAwal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PlantAwal") && !CurrentForm.HasValue("x_PlantAwal")) // DN
                    PlantAwal.Visible = false; // Disable update for API request
                else
                    PlantAwal.SetFormValue(val);
            }

            // Check field name 'RegionAwal' before field var 'x_RegionAwal'
            val = CurrentForm.HasValue("RegionAwal") ? CurrentForm.GetValue("RegionAwal") : CurrentForm.GetValue("x_RegionAwal");
            if (!RegionAwal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RegionAwal") && !CurrentForm.HasValue("x_RegionAwal")) // DN
                    RegionAwal.Visible = false; // Disable update for API request
                else
                    RegionAwal.SetFormValue(val, true, validate);
            }
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            Id.CurrentValue = Id.FormValue;
            NomorPjs.CurrentValue = NomorPjs.FormValue;
            RedirectLink.CurrentValue = RedirectLink.FormValue;
            Nama.CurrentValue = Nama.FormValue;
            OrganizationLevel.CurrentValue = OrganizationLevel.FormValue;
            Region.CurrentValue = Region.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            PosisiAwal.CurrentValue = PosisiAwal.FormValue;
            PosisiPJS.CurrentValue = PosisiPJS.FormValue;
            LookupPosition.CurrentValue = LookupPosition.FormValue;
            TanggalMulai.CurrentValue = TanggalMulai.FormValue;
            TanggalMulai.CurrentValue = UnformatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
            TanggalSelesai.CurrentValue = TanggalSelesai.FormValue;
            TanggalSelesai.CurrentValue = UnformatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
            Status.CurrentValue = Status.FormValue;
            DownloadSuratTugas.CurrentValue = DownloadSuratTugas.FormValue;
            SuratTugas.CurrentValue = SuratTugas.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            Remaks.CurrentValue = Remaks.FormValue;
            DibuatOleh.CurrentValue = DibuatOleh.FormValue;
            TanggalDibuat.CurrentValue = TanggalDibuat.FormValue;
            TanggalDibuat.CurrentValue = UnformatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            DiperbaharuiOleh.CurrentValue = DiperbaharuiOleh.FormValue;
            DiperbaharuiTanggal.CurrentValue = DiperbaharuiTanggal.FormValue;
            DiperbaharuiTanggal.CurrentValue = UnformatDateTime(DiperbaharuiTanggal.CurrentValue, DiperbaharuiTanggal.FormatPattern);
            PlantAwal.CurrentValue = PlantAwal.FormValue;
            RegionAwal.CurrentValue = RegionAwal.FormValue;
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
            NomorPjs.SetDbValue(row["NomorPjs"]);
            RedirectLink.SetDbValue(row["RedirectLink"]);
            Nama.SetDbValue(row["Nama"]);
            OrganizationLevel.SetDbValue(row["OrganizationLevel"]);
            Region.SetDbValue(row["Region"]);
            Plant.SetDbValue(row["Plant"]);
            PosisiAwal.SetDbValue(row["PosisiAwal"]);
            PosisiPJS.SetDbValue(row["PosisiPJS"]);
            LookupPosition.SetDbValue(row["LookupPosition"]);
            TanggalMulai.SetDbValue(row["TanggalMulai"]);
            TanggalSelesai.SetDbValue(row["TanggalSelesai"]);
            Status.SetDbValue(row["Status"]);
            DownloadSuratTugas.SetDbValue(row["DownloadSuratTugas"]);
            SuratTugas.SetDbValue(row["SuratTugas"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            Remaks.SetDbValue(row["Remaks"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaharuiOleh.SetDbValue(row["DiperbaharuiOleh"]);
            DiperbaharuiTanggal.SetDbValue(row["DiperbaharuiTanggal"]);
            PlantAwal.SetDbValue(row["PlantAwal"]);
            RegionAwal.SetDbValue(row["RegionAwal"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("Id", Id.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPjs", NomorPjs.DefaultValue ?? DbNullValue); // DN
            row.Add("RedirectLink", RedirectLink.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama", Nama.DefaultValue ?? DbNullValue); // DN
            row.Add("OrganizationLevel", OrganizationLevel.DefaultValue ?? DbNullValue); // DN
            row.Add("Region", Region.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("PosisiAwal", PosisiAwal.DefaultValue ?? DbNullValue); // DN
            row.Add("PosisiPJS", PosisiPJS.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPosition", LookupPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalMulai", TanggalMulai.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalSelesai", TanggalSelesai.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadSuratTugas", DownloadSuratTugas.DefaultValue ?? DbNullValue); // DN
            row.Add("SuratTugas", SuratTugas.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("Remaks", Remaks.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaharuiOleh", DiperbaharuiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaharuiTanggal", DiperbaharuiTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantAwal", PlantAwal.DefaultValue ?? DbNullValue); // DN
            row.Add("RegionAwal", RegionAwal.DefaultValue ?? DbNullValue); // DN
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

            // NomorPjs
            NomorPjs.RowCssClass = "row";

            // RedirectLink
            RedirectLink.RowCssClass = "row";

            // Nama
            Nama.RowCssClass = "row";

            // OrganizationLevel
            OrganizationLevel.RowCssClass = "row";

            // Region
            Region.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // PosisiAwal
            PosisiAwal.RowCssClass = "row";

            // PosisiPJS
            PosisiPJS.RowCssClass = "row";

            // LookupPosition
            LookupPosition.RowCssClass = "row";

            // TanggalMulai
            TanggalMulai.RowCssClass = "row";

            // TanggalSelesai
            TanggalSelesai.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // DownloadSuratTugas
            DownloadSuratTugas.RowCssClass = "row";

            // SuratTugas
            SuratTugas.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // Remaks
            Remaks.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaharuiOleh
            DiperbaharuiOleh.RowCssClass = "row";

            // DiperbaharuiTanggal
            DiperbaharuiTanggal.RowCssClass = "row";

            // PlantAwal
            PlantAwal.RowCssClass = "row";

            // RegionAwal
            RegionAwal.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // Id
                Id.ViewValue = Id.CurrentValue;
                Id.ViewCustomAttributes = "";

                // NomorPjs
                NomorPjs.ViewValue = ConvertToString(NomorPjs.CurrentValue); // DN
                NomorPjs.ViewCustomAttributes = "";

                // RedirectLink
                RedirectLink.ViewValue = ConvertToString(RedirectLink.CurrentValue); // DN
                RedirectLink.ViewCustomAttributes = "";

                // Nama
                Nama.ViewValue = ConvertToString(Nama.CurrentValue); // DN
                Nama.ViewCustomAttributes = "";

                // OrganizationLevel
                if (!Empty(OrganizationLevel.CurrentValue)) {
                    OrganizationLevel.ViewValue = OrganizationLevel.OptionCaption(ConvertToString(OrganizationLevel.CurrentValue));
                } else {
                    OrganizationLevel.ViewValue = DbNullValue;
                }
                OrganizationLevel.ViewCustomAttributes = "";

                // Region
                string curVal2 = ConvertToString(Region.CurrentValue);
                if (!Empty(curVal2)) {
                    if (Region.Lookup != null && IsDictionary(Region.Lookup?.Options) && Region.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Region.ViewValue = Region.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchExpression, "=", Region.CurrentValue, Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchDataType, "");
                        string? sqlWrk2 = Region.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && Region.Lookup != null) { // Lookup values found
                            var listwrk = Region.Lookup?.RenderViewRow(rswrk2[0]);
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
                string curVal3 = ConvertToString(Plant.CurrentValue);
                if (!Empty(curVal3)) {
                    if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Plant.ViewValue = Plant.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk3 = Plant.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                            var listwrk = Plant.Lookup?.RenderViewRow(rswrk3[0]);
                            Plant.ViewValue = Plant.DisplayValue(listwrk);
                        } else {
                            Plant.ViewValue = Plant.CurrentValue;
                        }
                    }
                } else {
                    Plant.ViewValue = DbNullValue;
                }
                Plant.ViewCustomAttributes = "";

                // PosisiAwal
                PosisiAwal.ViewValue = PosisiAwal.CurrentValue;
                string curVal4 = ConvertToString(PosisiAwal.CurrentValue);
                if (!Empty(curVal4)) {
                    if (PosisiAwal.Lookup != null && IsDictionary(PosisiAwal.Lookup?.Options) && PosisiAwal.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PosisiAwal.ViewValue = PosisiAwal.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(PosisiAwal.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", PosisiAwal.CurrentValue, PosisiAwal.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk4 = PosisiAwal.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && PosisiAwal.Lookup != null) { // Lookup values found
                            var listwrk = PosisiAwal.Lookup?.RenderViewRow(rswrk4[0]);
                            PosisiAwal.ViewValue = PosisiAwal.DisplayValue(listwrk);
                        } else {
                            PosisiAwal.ViewValue = PosisiAwal.CurrentValue;
                        }
                    }
                } else {
                    PosisiAwal.ViewValue = DbNullValue;
                }
                PosisiAwal.ViewCustomAttributes = "";

                // PosisiPJS
                PosisiPJS.ViewValue = PosisiPJS.CurrentValue;
                string curVal5 = ConvertToString(PosisiPJS.CurrentValue);
                if (!Empty(curVal5)) {
                    if (PosisiPJS.Lookup != null && IsDictionary(PosisiPJS.Lookup?.Options) && PosisiPJS.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PosisiPJS.ViewValue = PosisiPJS.LookupCacheOption(curVal5);
                    } else { // Lookup from database // DN
                        string filterWrk5 = SearchFilter(PosisiPJS.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", PosisiPJS.CurrentValue, PosisiPJS.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk5 = PosisiPJS.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk5?.Count > 0 && PosisiPJS.Lookup != null) { // Lookup values found
                            var listwrk = PosisiPJS.Lookup?.RenderViewRow(rswrk5[0]);
                            PosisiPJS.ViewValue = PosisiPJS.DisplayValue(listwrk);
                        } else {
                            PosisiPJS.ViewValue = PosisiPJS.CurrentValue;
                        }
                    }
                } else {
                    PosisiPJS.ViewValue = DbNullValue;
                }
                PosisiPJS.ViewCustomAttributes = "";

                // LookupPosition
                if (!Empty(LookupPosition.CurrentValue)) {
                    LookupPosition.ViewValue = LookupPosition.OptionCaption(ConvertToString(LookupPosition.CurrentValue));
                } else {
                    LookupPosition.ViewValue = DbNullValue;
                }
                LookupPosition.ViewCustomAttributes = "";

                // TanggalMulai
                TanggalMulai.ViewValue = TanggalMulai.CurrentValue;
                TanggalMulai.ViewValue = FormatDateTime(TanggalMulai.ViewValue, TanggalMulai.FormatPattern);
                TanggalMulai.ViewCustomAttributes = "";

                // TanggalSelesai
                TanggalSelesai.ViewValue = TanggalSelesai.CurrentValue;
                TanggalSelesai.ViewValue = FormatDateTime(TanggalSelesai.ViewValue, TanggalSelesai.FormatPattern);
                TanggalSelesai.ViewCustomAttributes = "";

                // Status
                Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // DownloadSuratTugas
                DownloadSuratTugas.ViewValue = ConvertToString(DownloadSuratTugas.CurrentValue); // DN
                DownloadSuratTugas.ViewCustomAttributes = "";

                // SuratTugas
                SuratTugas.ViewValue = ConvertToString(SuratTugas.CurrentValue); // DN
                SuratTugas.ViewCustomAttributes = "";

                // Keterangan
                Keterangan.ViewValue = Keterangan.CurrentValue;
                Keterangan.ViewCustomAttributes = "";

                // Remaks
                Remaks.ViewValue = Remaks.CurrentValue;
                Remaks.ViewCustomAttributes = "";

                // DibuatOleh
                DibuatOleh.ViewValue = DibuatOleh.CurrentValue;
                string curVal7 = ConvertToString(DibuatOleh.CurrentValue);
                if (!Empty(curVal7)) {
                    if (DibuatOleh.Lookup != null && IsDictionary(DibuatOleh.Lookup?.Options) && DibuatOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        DibuatOleh.ViewValue = DibuatOleh.LookupCacheOption(curVal7);
                    } else { // Lookup from database // DN
                        string filterWrk7 = SearchFilter(DibuatOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DibuatOleh.CurrentValue, DibuatOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                        string? sqlWrk7 = DibuatOleh.Lookup?.GetSql(false, filterWrk7, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk7?.Count > 0 && DibuatOleh.Lookup != null) { // Lookup values found
                            var listwrk = DibuatOleh.Lookup?.RenderViewRow(rswrk7[0]);
                            DibuatOleh.ViewValue = DibuatOleh.DisplayValue(listwrk);
                        } else {
                            DibuatOleh.ViewValue = DibuatOleh.CurrentValue;
                        }
                    }
                } else {
                    DibuatOleh.ViewValue = DbNullValue;
                }
                DibuatOleh.ViewCustomAttributes = "";

                // TanggalDibuat
                TanggalDibuat.ViewValue = TanggalDibuat.CurrentValue;
                TanggalDibuat.ViewValue = FormatDateTime(TanggalDibuat.ViewValue, TanggalDibuat.FormatPattern);
                TanggalDibuat.ViewCustomAttributes = "";

                // DiperbaharuiOleh
                DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.CurrentValue;
                string curVal8 = ConvertToString(DiperbaharuiOleh.CurrentValue);
                if (!Empty(curVal8)) {
                    if (DiperbaharuiOleh.Lookup != null && IsDictionary(DiperbaharuiOleh.Lookup?.Options) && DiperbaharuiOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.LookupCacheOption(curVal8);
                    } else { // Lookup from database // DN
                        string filterWrk8 = SearchFilter(DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DiperbaharuiOleh.CurrentValue, DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                        string? sqlWrk8 = DiperbaharuiOleh.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk8?.Count > 0 && DiperbaharuiOleh.Lookup != null) { // Lookup values found
                            var listwrk = DiperbaharuiOleh.Lookup?.RenderViewRow(rswrk8[0]);
                            DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.DisplayValue(listwrk);
                        } else {
                            DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.CurrentValue;
                        }
                    }
                } else {
                    DiperbaharuiOleh.ViewValue = DbNullValue;
                }
                DiperbaharuiOleh.ViewCustomAttributes = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.ViewValue = DiperbaharuiTanggal.CurrentValue;
                DiperbaharuiTanggal.ViewValue = FormatDateTime(DiperbaharuiTanggal.ViewValue, DiperbaharuiTanggal.FormatPattern);
                DiperbaharuiTanggal.ViewCustomAttributes = "";

                // PlantAwal
                PlantAwal.ViewValue = PlantAwal.CurrentValue;
                PlantAwal.ViewCustomAttributes = "";

                // RegionAwal
                RegionAwal.ViewValue = RegionAwal.CurrentValue;
                RegionAwal.ViewValue = FormatNumber(RegionAwal.ViewValue, RegionAwal.FormatPattern);
                RegionAwal.ViewCustomAttributes = "";

                // Id
                Id.HrefValue = "";

                // NomorPjs
                NomorPjs.HrefValue = "";
                NomorPjs.TooltipValue = "";

                // RedirectLink
                RedirectLink.HrefValue = "";

                // Nama
                Nama.HrefValue = "";

                // OrganizationLevel
                OrganizationLevel.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // PosisiAwal
                PosisiAwal.HrefValue = "";

                // PosisiPJS
                PosisiPJS.HrefValue = "";

                // LookupPosition
                LookupPosition.HrefValue = "";

                // TanggalMulai
                TanggalMulai.HrefValue = "";

                // TanggalSelesai
                TanggalSelesai.HrefValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // DownloadSuratTugas
                DownloadSuratTugas.HrefValue = "";
                DownloadSuratTugas.TooltipValue = "";

                // SuratTugas
                SuratTugas.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // Remaks
                Remaks.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // DiperbaharuiOleh
                DiperbaharuiOleh.HrefValue = "";
                DiperbaharuiOleh.TooltipValue = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.HrefValue = "";
                DiperbaharuiTanggal.TooltipValue = "";

                // PlantAwal
                PlantAwal.HrefValue = "";

                // RegionAwal
                RegionAwal.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // Id
                Id.SetupEditAttributes();
                Id.EditValue = Id.CurrentValue;
                Id.ViewCustomAttributes = "";

                // NomorPjs
                NomorPjs.SetupEditAttributes();
                NomorPjs.EditValue = ConvertToString(NomorPjs.CurrentValue); // DN
                NomorPjs.ViewCustomAttributes = "";

                // RedirectLink
                RedirectLink.SetupEditAttributes();
                if (!RedirectLink.Raw)
                    RedirectLink.CurrentValue = HtmlDecode(RedirectLink.CurrentValue);
                RedirectLink.EditValue = HtmlEncode(RedirectLink.CurrentValue);
                RedirectLink.PlaceHolder = RemoveHtml(RedirectLink.Caption);

                // Nama
                Nama.SetupEditAttributes();
                if (!Nama.Raw)
                    Nama.CurrentValue = HtmlDecode(Nama.CurrentValue);
                Nama.EditValue = HtmlEncode(Nama.CurrentValue);
                Nama.PlaceHolder = RemoveHtml(Nama.Caption);

                // OrganizationLevel
                OrganizationLevel.SetupEditAttributes();
                OrganizationLevel.EditValue = OrganizationLevel.Options(true);
                OrganizationLevel.PlaceHolder = RemoveHtml(OrganizationLevel.Caption);

                // Region
                Region.SetupEditAttributes();
                string curVal2 = ConvertToString(Region.CurrentValue);
                if (Region.Lookup != null && IsDictionary(Region.Lookup?.Options) && Region.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Region.EditValue = Region.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk2 = "";
                    if (curVal2 == "") {
                        filterWrk2 = "0=1";
                    } else {
                        filterWrk2 = SearchFilter(Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchExpression, "=", Region.CurrentValue, Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchDataType, "");
                    }
                    string? sqlWrk2 = Region.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Region.EditValue = rswrk2;
                }
                Region.PlaceHolder = RemoveHtml(Region.Caption);

                // Plant
                Plant.SetupEditAttributes();
                string curVal3 = ConvertToString(Plant.CurrentValue);
                if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Plant.EditValue = Plant.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk3 = "";
                    if (curVal3 == "") {
                        filterWrk3 = "0=1";
                    } else {
                        filterWrk3 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk3 = Plant.Lookup?.GetSql(true, filterWrk3, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Plant.EditValue = rswrk3;
                }
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);

                // PosisiAwal
                PosisiAwal.SetupEditAttributes();
                PosisiAwal.EditValue = PosisiAwal.CurrentValue;
                string curVal4 = ConvertToString(PosisiAwal.CurrentValue);
                if (!Empty(curVal4)) {
                    if (PosisiAwal.Lookup != null && IsDictionary(PosisiAwal.Lookup?.Options) && PosisiAwal.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PosisiAwal.EditValue = PosisiAwal.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(PosisiAwal.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", PosisiAwal.CurrentValue, PosisiAwal.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk4 = PosisiAwal.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && PosisiAwal.Lookup != null) { // Lookup values found
                            var listwrk = PosisiAwal.Lookup?.RenderViewRow(rswrk4[0]);
                            PosisiAwal.EditValue = PosisiAwal.DisplayValue(listwrk);
                        } else {
                            PosisiAwal.EditValue = HtmlEncode(PosisiAwal.CurrentValue);
                        }
                    }
                } else {
                    PosisiAwal.EditValue = DbNullValue;
                }
                PosisiAwal.PlaceHolder = RemoveHtml(PosisiAwal.Caption);

                // PosisiPJS
                PosisiPJS.SetupEditAttributes();
                PosisiPJS.EditValue = PosisiPJS.CurrentValue;
                string curVal5 = ConvertToString(PosisiPJS.CurrentValue);
                if (!Empty(curVal5)) {
                    if (PosisiPJS.Lookup != null && IsDictionary(PosisiPJS.Lookup?.Options) && PosisiPJS.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PosisiPJS.EditValue = PosisiPJS.LookupCacheOption(curVal5);
                    } else { // Lookup from database // DN
                        string filterWrk5 = SearchFilter(PosisiPJS.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", PosisiPJS.CurrentValue, PosisiPJS.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk5 = PosisiPJS.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk5?.Count > 0 && PosisiPJS.Lookup != null) { // Lookup values found
                            var listwrk = PosisiPJS.Lookup?.RenderViewRow(rswrk5[0]);
                            PosisiPJS.EditValue = PosisiPJS.DisplayValue(listwrk);
                        } else {
                            PosisiPJS.EditValue = HtmlEncode(PosisiPJS.CurrentValue);
                        }
                    }
                } else {
                    PosisiPJS.EditValue = DbNullValue;
                }
                PosisiPJS.PlaceHolder = RemoveHtml(PosisiPJS.Caption);

                // LookupPosition
                LookupPosition.SetupEditAttributes();
                LookupPosition.EditValue = LookupPosition.Options(true);
                LookupPosition.PlaceHolder = RemoveHtml(LookupPosition.Caption);

                // TanggalMulai
                TanggalMulai.SetupEditAttributes();
                TanggalMulai.EditValue = FormatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
                TanggalMulai.PlaceHolder = RemoveHtml(TanggalMulai.Caption);

                // TanggalSelesai
                TanggalSelesai.SetupEditAttributes();
                TanggalSelesai.EditValue = FormatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
                TanggalSelesai.PlaceHolder = RemoveHtml(TanggalSelesai.Caption);

                // Status
                Status.SetupEditAttributes();
                Status.EditValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // DownloadSuratTugas
                DownloadSuratTugas.SetupEditAttributes();
                DownloadSuratTugas.EditValue = ConvertToString(DownloadSuratTugas.CurrentValue); // DN
                DownloadSuratTugas.ViewCustomAttributes = "";

                // SuratTugas
                SuratTugas.SetupEditAttributes();
                if (!SuratTugas.Raw)
                    SuratTugas.CurrentValue = HtmlDecode(SuratTugas.CurrentValue);
                SuratTugas.EditValue = HtmlEncode(SuratTugas.CurrentValue);
                SuratTugas.PlaceHolder = RemoveHtml(SuratTugas.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // Remaks
                Remaks.SetupEditAttributes();
                Remaks.EditValue = Remaks.CurrentValue; // DN
                Remaks.PlaceHolder = RemoveHtml(Remaks.Caption);

                // DibuatOleh
                DibuatOleh.SetupEditAttributes();
                DibuatOleh.EditValue = DibuatOleh.CurrentValue;
                string curVal7 = ConvertToString(DibuatOleh.CurrentValue);
                if (!Empty(curVal7)) {
                    if (DibuatOleh.Lookup != null && IsDictionary(DibuatOleh.Lookup?.Options) && DibuatOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        DibuatOleh.EditValue = DibuatOleh.LookupCacheOption(curVal7);
                    } else { // Lookup from database // DN
                        string filterWrk7 = SearchFilter(DibuatOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DibuatOleh.CurrentValue, DibuatOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                        string? sqlWrk7 = DibuatOleh.Lookup?.GetSql(false, filterWrk7, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk7?.Count > 0 && DibuatOleh.Lookup != null) { // Lookup values found
                            var listwrk = DibuatOleh.Lookup?.RenderViewRow(rswrk7[0]);
                            DibuatOleh.EditValue = DibuatOleh.DisplayValue(listwrk);
                        } else {
                            DibuatOleh.EditValue = HtmlEncode(DibuatOleh.CurrentValue);
                        }
                    }
                } else {
                    DibuatOleh.EditValue = DbNullValue;
                }
                DibuatOleh.PlaceHolder = RemoveHtml(DibuatOleh.Caption);

                // TanggalDibuat
                TanggalDibuat.SetupEditAttributes();
                TanggalDibuat.EditValue = FormatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
                TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);

                // DiperbaharuiOleh
                DiperbaharuiOleh.SetupEditAttributes();
                DiperbaharuiOleh.EditValue = DiperbaharuiOleh.CurrentValue;
                string curVal8 = ConvertToString(DiperbaharuiOleh.CurrentValue);
                if (!Empty(curVal8)) {
                    if (DiperbaharuiOleh.Lookup != null && IsDictionary(DiperbaharuiOleh.Lookup?.Options) && DiperbaharuiOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        DiperbaharuiOleh.EditValue = DiperbaharuiOleh.LookupCacheOption(curVal8);
                    } else { // Lookup from database // DN
                        string filterWrk8 = SearchFilter(DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DiperbaharuiOleh.CurrentValue, DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                        string? sqlWrk8 = DiperbaharuiOleh.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk8?.Count > 0 && DiperbaharuiOleh.Lookup != null) { // Lookup values found
                            var listwrk = DiperbaharuiOleh.Lookup?.RenderViewRow(rswrk8[0]);
                            DiperbaharuiOleh.EditValue = DiperbaharuiOleh.DisplayValue(listwrk);
                        } else {
                            DiperbaharuiOleh.EditValue = DiperbaharuiOleh.CurrentValue;
                        }
                    }
                } else {
                    DiperbaharuiOleh.EditValue = DbNullValue;
                }
                DiperbaharuiOleh.ViewCustomAttributes = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.SetupEditAttributes();
                DiperbaharuiTanggal.EditValue = DiperbaharuiTanggal.CurrentValue;
                DiperbaharuiTanggal.EditValue = FormatDateTime(DiperbaharuiTanggal.EditValue, DiperbaharuiTanggal.FormatPattern);
                DiperbaharuiTanggal.ViewCustomAttributes = "";

                // PlantAwal
                PlantAwal.SetupEditAttributes();
                PlantAwal.EditValue = PlantAwal.CurrentValue;
                PlantAwal.PlaceHolder = RemoveHtml(PlantAwal.Caption);

                // RegionAwal
                RegionAwal.SetupEditAttributes();
                RegionAwal.EditValue = RegionAwal.CurrentValue;
                RegionAwal.PlaceHolder = RemoveHtml(RegionAwal.Caption);
                if (!Empty(RegionAwal.EditValue) && IsNumeric(RegionAwal.EditValue))
                    RegionAwal.EditValue = FormatNumber(RegionAwal.EditValue, null);

                // Edit refer script

                // Id
                Id.HrefValue = "";

                // NomorPjs
                NomorPjs.HrefValue = "";
                NomorPjs.TooltipValue = "";

                // RedirectLink
                RedirectLink.HrefValue = "";

                // Nama
                Nama.HrefValue = "";

                // OrganizationLevel
                OrganizationLevel.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // PosisiAwal
                PosisiAwal.HrefValue = "";

                // PosisiPJS
                PosisiPJS.HrefValue = "";

                // LookupPosition
                LookupPosition.HrefValue = "";

                // TanggalMulai
                TanggalMulai.HrefValue = "";

                // TanggalSelesai
                TanggalSelesai.HrefValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // DownloadSuratTugas
                DownloadSuratTugas.HrefValue = "";
                DownloadSuratTugas.TooltipValue = "";

                // SuratTugas
                SuratTugas.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // Remaks
                Remaks.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // DiperbaharuiOleh
                DiperbaharuiOleh.HrefValue = "";
                DiperbaharuiOleh.TooltipValue = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.HrefValue = "";
                DiperbaharuiTanggal.TooltipValue = "";

                // PlantAwal
                PlantAwal.HrefValue = "";

                // RegionAwal
                RegionAwal.HrefValue = "";
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
                if (NomorPjs.Visible && NomorPjs.Required) {
                    if (!NomorPjs.IsDetailKey && Empty(NomorPjs.FormValue)) {
                        NomorPjs.AddErrorMessage(ConvertToString(NomorPjs.RequiredErrorMessage).Replace("%s", NomorPjs.Caption));
                    }
                }
                if (RedirectLink.Visible && RedirectLink.Required) {
                    if (!RedirectLink.IsDetailKey && Empty(RedirectLink.FormValue)) {
                        RedirectLink.AddErrorMessage(ConvertToString(RedirectLink.RequiredErrorMessage).Replace("%s", RedirectLink.Caption));
                    }
                }
                if (Nama.Visible && Nama.Required) {
                    if (!Nama.IsDetailKey && Empty(Nama.FormValue)) {
                        Nama.AddErrorMessage(ConvertToString(Nama.RequiredErrorMessage).Replace("%s", Nama.Caption));
                    }
                }
                if (OrganizationLevel.Visible && OrganizationLevel.Required) {
                    if (!OrganizationLevel.IsDetailKey && Empty(OrganizationLevel.FormValue)) {
                        OrganizationLevel.AddErrorMessage(ConvertToString(OrganizationLevel.RequiredErrorMessage).Replace("%s", OrganizationLevel.Caption));
                    }
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
                if (PosisiAwal.Visible && PosisiAwal.Required) {
                    if (!PosisiAwal.IsDetailKey && Empty(PosisiAwal.FormValue)) {
                        PosisiAwal.AddErrorMessage(ConvertToString(PosisiAwal.RequiredErrorMessage).Replace("%s", PosisiAwal.Caption));
                    }
                }
                if (PosisiPJS.Visible && PosisiPJS.Required) {
                    if (!PosisiPJS.IsDetailKey && Empty(PosisiPJS.FormValue)) {
                        PosisiPJS.AddErrorMessage(ConvertToString(PosisiPJS.RequiredErrorMessage).Replace("%s", PosisiPJS.Caption));
                    }
                }
                if (LookupPosition.Visible && LookupPosition.Required) {
                    if (!LookupPosition.IsDetailKey && Empty(LookupPosition.FormValue)) {
                        LookupPosition.AddErrorMessage(ConvertToString(LookupPosition.RequiredErrorMessage).Replace("%s", LookupPosition.Caption));
                    }
                }
                if (TanggalMulai.Visible && TanggalMulai.Required) {
                    if (!TanggalMulai.IsDetailKey && Empty(TanggalMulai.FormValue)) {
                        TanggalMulai.AddErrorMessage(ConvertToString(TanggalMulai.RequiredErrorMessage).Replace("%s", TanggalMulai.Caption));
                    }
                }
                if (!CheckDate(TanggalMulai.FormValue, TanggalMulai.FormatPattern)) {
                    TanggalMulai.AddErrorMessage(TanggalMulai.GetErrorMessage(false));
                }
                if (TanggalSelesai.Visible && TanggalSelesai.Required) {
                    if (!TanggalSelesai.IsDetailKey && Empty(TanggalSelesai.FormValue)) {
                        TanggalSelesai.AddErrorMessage(ConvertToString(TanggalSelesai.RequiredErrorMessage).Replace("%s", TanggalSelesai.Caption));
                    }
                }
                if (!CheckDate(TanggalSelesai.FormValue, TanggalSelesai.FormatPattern)) {
                    TanggalSelesai.AddErrorMessage(TanggalSelesai.GetErrorMessage(false));
                }
                if (Status.Visible && Status.Required) {
                    if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                        Status.AddErrorMessage(ConvertToString(Status.RequiredErrorMessage).Replace("%s", Status.Caption));
                    }
                }
                if (DownloadSuratTugas.Visible && DownloadSuratTugas.Required) {
                    if (!DownloadSuratTugas.IsDetailKey && Empty(DownloadSuratTugas.FormValue)) {
                        DownloadSuratTugas.AddErrorMessage(ConvertToString(DownloadSuratTugas.RequiredErrorMessage).Replace("%s", DownloadSuratTugas.Caption));
                    }
                }
                if (SuratTugas.Visible && SuratTugas.Required) {
                    if (!SuratTugas.IsDetailKey && Empty(SuratTugas.FormValue)) {
                        SuratTugas.AddErrorMessage(ConvertToString(SuratTugas.RequiredErrorMessage).Replace("%s", SuratTugas.Caption));
                    }
                }
                if (Keterangan.Visible && Keterangan.Required) {
                    if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                        Keterangan.AddErrorMessage(ConvertToString(Keterangan.RequiredErrorMessage).Replace("%s", Keterangan.Caption));
                    }
                }
                if (Remaks.Visible && Remaks.Required) {
                    if (!Remaks.IsDetailKey && Empty(Remaks.FormValue)) {
                        Remaks.AddErrorMessage(ConvertToString(Remaks.RequiredErrorMessage).Replace("%s", Remaks.Caption));
                    }
                }
                if (DibuatOleh.Visible && DibuatOleh.Required) {
                    if (!DibuatOleh.IsDetailKey && Empty(DibuatOleh.FormValue)) {
                        DibuatOleh.AddErrorMessage(ConvertToString(DibuatOleh.RequiredErrorMessage).Replace("%s", DibuatOleh.Caption));
                    }
                }
                if (TanggalDibuat.Visible && TanggalDibuat.Required) {
                    if (!TanggalDibuat.IsDetailKey && Empty(TanggalDibuat.FormValue)) {
                        TanggalDibuat.AddErrorMessage(ConvertToString(TanggalDibuat.RequiredErrorMessage).Replace("%s", TanggalDibuat.Caption));
                    }
                }
                if (!CheckDate(TanggalDibuat.FormValue, TanggalDibuat.FormatPattern)) {
                    TanggalDibuat.AddErrorMessage(TanggalDibuat.GetErrorMessage(false));
                }
                if (DiperbaharuiOleh.Visible && DiperbaharuiOleh.Required) {
                    if (!DiperbaharuiOleh.IsDetailKey && Empty(DiperbaharuiOleh.FormValue)) {
                        DiperbaharuiOleh.AddErrorMessage(ConvertToString(DiperbaharuiOleh.RequiredErrorMessage).Replace("%s", DiperbaharuiOleh.Caption));
                    }
                }
                if (DiperbaharuiTanggal.Visible && DiperbaharuiTanggal.Required) {
                    if (!DiperbaharuiTanggal.IsDetailKey && Empty(DiperbaharuiTanggal.FormValue)) {
                        DiperbaharuiTanggal.AddErrorMessage(ConvertToString(DiperbaharuiTanggal.RequiredErrorMessage).Replace("%s", DiperbaharuiTanggal.Caption));
                    }
                }
                if (PlantAwal.Visible && PlantAwal.Required) {
                    if (!PlantAwal.IsDetailKey && Empty(PlantAwal.FormValue)) {
                        PlantAwal.AddErrorMessage(ConvertToString(PlantAwal.RequiredErrorMessage).Replace("%s", PlantAwal.Caption));
                    }
                }
                if (RegionAwal.Visible && RegionAwal.Required) {
                    if (!RegionAwal.IsDetailKey && Empty(RegionAwal.FormValue)) {
                        RegionAwal.AddErrorMessage(ConvertToString(RegionAwal.RequiredErrorMessage).Replace("%s", RegionAwal.Caption));
                    }
                }
                if (!CheckInteger(RegionAwal.FormValue)) {
                    RegionAwal.AddErrorMessage(RegionAwal.GetErrorMessage(false));
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

            // RedirectLink
            RedirectLink.SetDbValue(rsnew, RedirectLink.CurrentValue, RedirectLink.ReadOnly);

            // Nama
            Nama.SetDbValue(rsnew, Nama.CurrentValue, Nama.ReadOnly);

            // OrganizationLevel
            OrganizationLevel.SetDbValue(rsnew, OrganizationLevel.CurrentValue, OrganizationLevel.ReadOnly);

            // Region
            Region.SetDbValue(rsnew, Region.CurrentValue, Region.ReadOnly);

            // Plant
            Plant.SetDbValue(rsnew, Plant.CurrentValue, Plant.ReadOnly);

            // PosisiAwal
            PosisiAwal.SetDbValue(rsnew, PosisiAwal.CurrentValue, PosisiAwal.ReadOnly);

            // PosisiPJS
            PosisiPJS.SetDbValue(rsnew, PosisiPJS.CurrentValue, PosisiPJS.ReadOnly);

            // LookupPosition
            LookupPosition.SetDbValue(rsnew, LookupPosition.CurrentValue, LookupPosition.ReadOnly);

            // TanggalMulai
            TanggalMulai.SetDbValue(rsnew, ConvertToDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern), TanggalMulai.ReadOnly);

            // TanggalSelesai
            TanggalSelesai.SetDbValue(rsnew, ConvertToDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern), TanggalSelesai.ReadOnly);

            // SuratTugas
            SuratTugas.SetDbValue(rsnew, SuratTugas.CurrentValue, SuratTugas.ReadOnly);

            // Keterangan
            Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue, Keterangan.ReadOnly);

            // Remaks
            Remaks.SetDbValue(rsnew, Remaks.CurrentValue, Remaks.ReadOnly);

            // DibuatOleh
            DibuatOleh.SetDbValue(rsnew, DibuatOleh.CurrentValue, DibuatOleh.ReadOnly);

            // TanggalDibuat
            TanggalDibuat.SetDbValue(rsnew, ConvertToDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern), TanggalDibuat.ReadOnly);

            // PlantAwal
            PlantAwal.SetDbValue(rsnew, PlantAwal.CurrentValue, PlantAwal.ReadOnly);

            // RegionAwal
            RegionAwal.SetDbValue(rsnew, RegionAwal.CurrentValue, RegionAwal.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("RedirectLink", out value)) // RedirectLink
                RedirectLink.CurrentValue = value;
            if (row.TryGetValue("Nama", out value)) // Nama
                Nama.CurrentValue = value;
            if (row.TryGetValue("OrganizationLevel", out value)) // OrganizationLevel
                OrganizationLevel.CurrentValue = value;
            if (row.TryGetValue("Region", out value)) // Region
                Region.CurrentValue = value;
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.CurrentValue = value;
            if (row.TryGetValue("PosisiAwal", out value)) // PosisiAwal
                PosisiAwal.CurrentValue = value;
            if (row.TryGetValue("PosisiPJS", out value)) // PosisiPJS
                PosisiPJS.CurrentValue = value;
            if (row.TryGetValue("LookupPosition", out value)) // LookupPosition
                LookupPosition.CurrentValue = value;
            if (row.TryGetValue("TanggalMulai", out value)) // TanggalMulai
                TanggalMulai.CurrentValue = value;
            if (row.TryGetValue("TanggalSelesai", out value)) // TanggalSelesai
                TanggalSelesai.CurrentValue = value;
            if (row.TryGetValue("SuratTugas", out value)) // SuratTugas
                SuratTugas.CurrentValue = value;
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.CurrentValue = value;
            if (row.TryGetValue("Remaks", out value)) // Remaks
                Remaks.CurrentValue = value;
            if (row.TryGetValue("DibuatOleh", out value)) // DibuatOleh
                DibuatOleh.CurrentValue = value;
            if (row.TryGetValue("TanggalDibuat", out value)) // TanggalDibuat
                TanggalDibuat.CurrentValue = value;
            if (row.TryGetValue("PlantAwal", out value)) // PlantAwal
                PlantAwal.CurrentValue = value;
            if (row.TryGetValue("RegionAwal", out value)) // RegionAwal
                RegionAwal.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SetPjsList")), "", TableVar, true);
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
