namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasSfadNewBlstsPnrBbmEdit
    /// </summary>
    public static SubAktivitasSfadNewBlstsPnrBbmEdit subAktivitasSfadNewBlstsPnrBbmEdit
    {
        get => HttpData.Get<SubAktivitasSfadNewBlstsPnrBbmEdit>("subAktivitasSfadNewBlstsPnrBbmEdit")!;
        set => HttpData["subAktivitasSfadNewBlstsPnrBbmEdit"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasSFADNewBLSTSPnrBBM
    /// </summary>
    public class SubAktivitasSfadNewBlstsPnrBbmEdit : SubAktivitasSfadNewBlstsPnrBbmEditBase
    {
        // Constructor
        public SubAktivitasSfadNewBlstsPnrBbmEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasSfadNewBlstsPnrBbmEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Tujuan.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasSfadNewBlstsPnrBbmEditBase : SubAktivitasSfadNewBlstsPnrBbm
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasSfadNewBlstsPnrBbmEdit";

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
        public SubAktivitasSfadNewBlstsPnrBbmEditBase()
        {
            TableName = "SubAktivitasSFADNewBLSTSPnrBBM";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasSfadNewBlstsPnrBbm)
            if (subAktivitasSfadNewBlstsPnrBbm == null || subAktivitasSfadNewBlstsPnrBbm is SubAktivitasSfadNewBlstsPnrBbm)
                subAktivitasSfadNewBlstsPnrBbm = this;

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
        public string PageName => "SubAktivitasSfadNewBlstsPnrBbmEdit";

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
            NoReferensi.SetVisibility();
            idProses.SetVisibility();
            idAktifitas.SetVisibility();
            StatusAktivitas.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            ApakahAdaROB.Visible = false;
            ApakahTerdapatROB.SetVisibility();
            Import.SetVisibility();
            Tujuan.SetVisibility();
            SFAD_klobs.SetVisibility();
            SFAD_kl15.SetVisibility();
            SFAD_barrels.SetVisibility();
            SFAD_lt.SetVisibility();
            SFAD_mt.SetVisibility();
            NewBl_klobs.SetVisibility();
            NewBl_kl15.SetVisibility();
            NewBl_barrels.SetVisibility();
            NewBl_lt.SetVisibility();
            NewBl_mt.SetVisibility();
            AR45B_klobs.SetVisibility();
            AR45B_kl15.SetVisibility();
            AR45B_barrels.SetVisibility();
            AR45B_lt.SetVisibility();
            AR45B_mt.SetVisibility();
            userInput.Visible = false;
            etlDate.Visible = false;
        }

        // Constructor
        public SubAktivitasSfadNewBlstsPnrBbmEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "SubAktivitasSfadNewBlstsPnrBbmView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(idProses);
            await SetupLookupOptions(idAktifitas);
            await SetupLookupOptions(StatusAktivitas);
            await SetupLookupOptions(ApakahTerdapatROB);
            await SetupLookupOptions(Import);
            await SetupLookupOptions(Tujuan);

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
                            return Terminate("SubAktivitasSfadNewBlstsPnrBbmList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "SubAktivitasSfadNewBlstsPnrBbmList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SubAktivitasSfadNewBlstsPnrBbmList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SubAktivitasSfadNewBlstsPnrBbmList"; // Return list page content
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
                subAktivitasSfadNewBlstsPnrBbmEdit?.PageRender();
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

            // Check field name 'NoReferensi' before field var 'x_NoReferensi'
            val = CurrentForm.HasValue("NoReferensi") ? CurrentForm.GetValue("NoReferensi") : CurrentForm.GetValue("x_NoReferensi");
            if (!NoReferensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoReferensi") && !CurrentForm.HasValue("x_NoReferensi")) // DN
                    NoReferensi.Visible = false; // Disable update for API request
                else
                    NoReferensi.SetFormValue(val);
            }

            // Check field name 'idProses' before field var 'x_idProses'
            val = CurrentForm.HasValue("idProses") ? CurrentForm.GetValue("idProses") : CurrentForm.GetValue("x_idProses");
            if (!idProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idProses") && !CurrentForm.HasValue("x_idProses")) // DN
                    idProses.Visible = false; // Disable update for API request
                else
                    idProses.SetFormValue(val);
            }

            // Check field name 'idAktifitas' before field var 'x_idAktifitas'
            val = CurrentForm.HasValue("idAktifitas") ? CurrentForm.GetValue("idAktifitas") : CurrentForm.GetValue("x_idAktifitas");
            if (!idAktifitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idAktifitas") && !CurrentForm.HasValue("x_idAktifitas")) // DN
                    idAktifitas.Visible = false; // Disable update for API request
                else
                    idAktifitas.SetFormValue(val);
            }

            // Check field name 'StatusAktivitas' before field var 'x_StatusAktivitas'
            val = CurrentForm.HasValue("StatusAktivitas") ? CurrentForm.GetValue("StatusAktivitas") : CurrentForm.GetValue("x_StatusAktivitas");
            if (!StatusAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusAktivitas") && !CurrentForm.HasValue("x_StatusAktivitas")) // DN
                    StatusAktivitas.Visible = false; // Disable update for API request
                else
                    StatusAktivitas.SetFormValue(val);
            }

            // Check field name 'LastUpdatedBy' before field var 'x_LastUpdatedBy'
            val = CurrentForm.HasValue("LastUpdatedBy") ? CurrentForm.GetValue("LastUpdatedBy") : CurrentForm.GetValue("x_LastUpdatedBy");
            if (!LastUpdatedBy.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LastUpdatedBy") && !CurrentForm.HasValue("x_LastUpdatedBy")) // DN
                    LastUpdatedBy.Visible = false; // Disable update for API request
                else
                    LastUpdatedBy.SetFormValue(val);
            }

            // Check field name 'lastUpdatedDate' before field var 'x_lastUpdatedDate'
            val = CurrentForm.HasValue("lastUpdatedDate") ? CurrentForm.GetValue("lastUpdatedDate") : CurrentForm.GetValue("x_lastUpdatedDate");
            if (!lastUpdatedDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("lastUpdatedDate") && !CurrentForm.HasValue("x_lastUpdatedDate")) // DN
                    lastUpdatedDate.Visible = false; // Disable update for API request
                else
                    lastUpdatedDate.SetFormValue(val);
                lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            }

            // Check field name 'ApakahTerdapatROB' before field var 'x_ApakahTerdapatROB'
            val = CurrentForm.HasValue("ApakahTerdapatROB") ? CurrentForm.GetValue("ApakahTerdapatROB") : CurrentForm.GetValue("x_ApakahTerdapatROB");
            if (!ApakahTerdapatROB.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ApakahTerdapatROB") && !CurrentForm.HasValue("x_ApakahTerdapatROB")) // DN
                    ApakahTerdapatROB.Visible = false; // Disable update for API request
                else
                    ApakahTerdapatROB.SetFormValue(val);
            }

            // Check field name 'Import' before field var 'x_Import'
            val = CurrentForm.HasValue("Import") ? CurrentForm.GetValue("Import") : CurrentForm.GetValue("x_Import");
            if (!Import.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Import") && !CurrentForm.HasValue("x_Import")) // DN
                    Import.Visible = false; // Disable update for API request
                else
                    Import.SetFormValue(val);
            }

            // Check field name 'Tujuan' before field var 'x_Tujuan'
            val = CurrentForm.HasValue("Tujuan") ? CurrentForm.GetValue("Tujuan") : CurrentForm.GetValue("x_Tujuan");
            if (!Tujuan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Tujuan") && !CurrentForm.HasValue("x_Tujuan")) // DN
                    Tujuan.Visible = false; // Disable update for API request
                else
                    Tujuan.SetFormValue(val);
            }

            // Check field name 'SFAD_klobs' before field var 'x_SFAD_klobs'
            val = CurrentForm.HasValue("SFAD_klobs") ? CurrentForm.GetValue("SFAD_klobs") : CurrentForm.GetValue("x_SFAD_klobs");
            if (!SFAD_klobs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_klobs") && !CurrentForm.HasValue("x_SFAD_klobs")) // DN
                    SFAD_klobs.Visible = false; // Disable update for API request
                else
                    SFAD_klobs.SetFormValue(val);
            }

            // Check field name 'SFAD_kl15' before field var 'x_SFAD_kl15'
            val = CurrentForm.HasValue("SFAD_kl15") ? CurrentForm.GetValue("SFAD_kl15") : CurrentForm.GetValue("x_SFAD_kl15");
            if (!SFAD_kl15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_kl15") && !CurrentForm.HasValue("x_SFAD_kl15")) // DN
                    SFAD_kl15.Visible = false; // Disable update for API request
                else
                    SFAD_kl15.SetFormValue(val);
            }

            // Check field name 'SFAD_barrels' before field var 'x_SFAD_barrels'
            val = CurrentForm.HasValue("SFAD_barrels") ? CurrentForm.GetValue("SFAD_barrels") : CurrentForm.GetValue("x_SFAD_barrels");
            if (!SFAD_barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_barrels") && !CurrentForm.HasValue("x_SFAD_barrels")) // DN
                    SFAD_barrels.Visible = false; // Disable update for API request
                else
                    SFAD_barrels.SetFormValue(val);
            }

            // Check field name 'SFAD_lt' before field var 'x_SFAD_lt'
            val = CurrentForm.HasValue("SFAD_lt") ? CurrentForm.GetValue("SFAD_lt") : CurrentForm.GetValue("x_SFAD_lt");
            if (!SFAD_lt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_lt") && !CurrentForm.HasValue("x_SFAD_lt")) // DN
                    SFAD_lt.Visible = false; // Disable update for API request
                else
                    SFAD_lt.SetFormValue(val);
            }

            // Check field name 'SFAD_mt' before field var 'x_SFAD_mt'
            val = CurrentForm.HasValue("SFAD_mt") ? CurrentForm.GetValue("SFAD_mt") : CurrentForm.GetValue("x_SFAD_mt");
            if (!SFAD_mt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_mt") && !CurrentForm.HasValue("x_SFAD_mt")) // DN
                    SFAD_mt.Visible = false; // Disable update for API request
                else
                    SFAD_mt.SetFormValue(val);
            }

            // Check field name 'NewBl_klobs' before field var 'x_NewBl_klobs'
            val = CurrentForm.HasValue("NewBl_klobs") ? CurrentForm.GetValue("NewBl_klobs") : CurrentForm.GetValue("x_NewBl_klobs");
            if (!NewBl_klobs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBl_klobs") && !CurrentForm.HasValue("x_NewBl_klobs")) // DN
                    NewBl_klobs.Visible = false; // Disable update for API request
                else
                    NewBl_klobs.SetFormValue(val);
            }

            // Check field name 'NewBl_kl15' before field var 'x_NewBl_kl15'
            val = CurrentForm.HasValue("NewBl_kl15") ? CurrentForm.GetValue("NewBl_kl15") : CurrentForm.GetValue("x_NewBl_kl15");
            if (!NewBl_kl15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBl_kl15") && !CurrentForm.HasValue("x_NewBl_kl15")) // DN
                    NewBl_kl15.Visible = false; // Disable update for API request
                else
                    NewBl_kl15.SetFormValue(val);
            }

            // Check field name 'NewBl_barrels' before field var 'x_NewBl_barrels'
            val = CurrentForm.HasValue("NewBl_barrels") ? CurrentForm.GetValue("NewBl_barrels") : CurrentForm.GetValue("x_NewBl_barrels");
            if (!NewBl_barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBl_barrels") && !CurrentForm.HasValue("x_NewBl_barrels")) // DN
                    NewBl_barrels.Visible = false; // Disable update for API request
                else
                    NewBl_barrels.SetFormValue(val);
            }

            // Check field name 'NewBl_lt' before field var 'x_NewBl_lt'
            val = CurrentForm.HasValue("NewBl_lt") ? CurrentForm.GetValue("NewBl_lt") : CurrentForm.GetValue("x_NewBl_lt");
            if (!NewBl_lt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBl_lt") && !CurrentForm.HasValue("x_NewBl_lt")) // DN
                    NewBl_lt.Visible = false; // Disable update for API request
                else
                    NewBl_lt.SetFormValue(val);
            }

            // Check field name 'NewBl_mt' before field var 'x_NewBl_mt'
            val = CurrentForm.HasValue("NewBl_mt") ? CurrentForm.GetValue("NewBl_mt") : CurrentForm.GetValue("x_NewBl_mt");
            if (!NewBl_mt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBl_mt") && !CurrentForm.HasValue("x_NewBl_mt")) // DN
                    NewBl_mt.Visible = false; // Disable update for API request
                else
                    NewBl_mt.SetFormValue(val);
            }

            // Check field name 'AR45B_klobs' before field var 'x_AR45B_klobs'
            val = CurrentForm.HasValue("AR45B_klobs") ? CurrentForm.GetValue("AR45B_klobs") : CurrentForm.GetValue("x_AR45B_klobs");
            if (!AR45B_klobs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_klobs") && !CurrentForm.HasValue("x_AR45B_klobs")) // DN
                    AR45B_klobs.Visible = false; // Disable update for API request
                else
                    AR45B_klobs.SetFormValue(val);
            }

            // Check field name 'AR45B_kl15' before field var 'x_AR45B_kl15'
            val = CurrentForm.HasValue("AR45B_kl15") ? CurrentForm.GetValue("AR45B_kl15") : CurrentForm.GetValue("x_AR45B_kl15");
            if (!AR45B_kl15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_kl15") && !CurrentForm.HasValue("x_AR45B_kl15")) // DN
                    AR45B_kl15.Visible = false; // Disable update for API request
                else
                    AR45B_kl15.SetFormValue(val);
            }

            // Check field name 'AR45B_barrels' before field var 'x_AR45B_barrels'
            val = CurrentForm.HasValue("AR45B_barrels") ? CurrentForm.GetValue("AR45B_barrels") : CurrentForm.GetValue("x_AR45B_barrels");
            if (!AR45B_barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_barrels") && !CurrentForm.HasValue("x_AR45B_barrels")) // DN
                    AR45B_barrels.Visible = false; // Disable update for API request
                else
                    AR45B_barrels.SetFormValue(val);
            }

            // Check field name 'AR45B_lt' before field var 'x_AR45B_lt'
            val = CurrentForm.HasValue("AR45B_lt") ? CurrentForm.GetValue("AR45B_lt") : CurrentForm.GetValue("x_AR45B_lt");
            if (!AR45B_lt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_lt") && !CurrentForm.HasValue("x_AR45B_lt")) // DN
                    AR45B_lt.Visible = false; // Disable update for API request
                else
                    AR45B_lt.SetFormValue(val);
            }

            // Check field name 'AR45B_mt' before field var 'x_AR45B_mt'
            val = CurrentForm.HasValue("AR45B_mt") ? CurrentForm.GetValue("AR45B_mt") : CurrentForm.GetValue("x_AR45B_mt");
            if (!AR45B_mt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_mt") && !CurrentForm.HasValue("x_AR45B_mt")) // DN
                    AR45B_mt.Visible = false; // Disable update for API request
                else
                    AR45B_mt.SetFormValue(val);
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
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            ApakahTerdapatROB.CurrentValue = ApakahTerdapatROB.FormValue;
            Import.CurrentValue = Import.FormValue;
            Tujuan.CurrentValue = Tujuan.FormValue;
            SFAD_klobs.CurrentValue = SFAD_klobs.FormValue;
            SFAD_kl15.CurrentValue = SFAD_kl15.FormValue;
            SFAD_barrels.CurrentValue = SFAD_barrels.FormValue;
            SFAD_lt.CurrentValue = SFAD_lt.FormValue;
            SFAD_mt.CurrentValue = SFAD_mt.FormValue;
            NewBl_klobs.CurrentValue = NewBl_klobs.FormValue;
            NewBl_kl15.CurrentValue = NewBl_kl15.FormValue;
            NewBl_barrels.CurrentValue = NewBl_barrels.FormValue;
            NewBl_lt.CurrentValue = NewBl_lt.FormValue;
            NewBl_mt.CurrentValue = NewBl_mt.FormValue;
            AR45B_klobs.CurrentValue = AR45B_klobs.FormValue;
            AR45B_kl15.CurrentValue = AR45B_kl15.FormValue;
            AR45B_barrels.CurrentValue = AR45B_barrels.FormValue;
            AR45B_lt.CurrentValue = AR45B_lt.FormValue;
            AR45B_mt.CurrentValue = AR45B_mt.FormValue;
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
            NoReferensi.SetDbValue(row["NoReferensi"]);
            idProses.SetDbValue(row["idProses"]);
            idAktifitas.SetDbValue(row["idAktifitas"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            ApakahAdaROB.SetDbValue(row["ApakahAdaROB"]);
            ApakahTerdapatROB.SetDbValue((ConvertToBool(row["ApakahTerdapatROB"]) ? "1" : "0"));
            Import.SetDbValue((ConvertToBool(row["Import"]) ? "1" : "0"));
            Tujuan.SetDbValue(row["Tujuan"]);
            SFAD_klobs.SetDbValue(row["SFAD_klobs"]);
            SFAD_kl15.SetDbValue(row["SFAD_kl15"]);
            SFAD_barrels.SetDbValue(row["SFAD_barrels"]);
            SFAD_lt.SetDbValue(row["SFAD_lt"]);
            SFAD_mt.SetDbValue(row["SFAD_mt"]);
            NewBl_klobs.SetDbValue(row["NewBl_klobs"]);
            NewBl_kl15.SetDbValue(row["NewBl_kl15"]);
            NewBl_barrels.SetDbValue(row["NewBl_barrels"]);
            NewBl_lt.SetDbValue(row["NewBl_lt"]);
            NewBl_mt.SetDbValue(row["NewBl_mt"]);
            AR45B_klobs.SetDbValue(row["AR45B_klobs"]);
            AR45B_kl15.SetDbValue(row["AR45B_kl15"]);
            AR45B_barrels.SetDbValue(row["AR45B_barrels"]);
            AR45B_lt.SetDbValue(row["AR45B_lt"]);
            AR45B_mt.SetDbValue(row["AR45B_mt"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("ApakahAdaROB", ApakahAdaROB.DefaultValue ?? DbNullValue); // DN
            row.Add("ApakahTerdapatROB", ApakahTerdapatROB.DefaultValue ?? DbNullValue); // DN
            row.Add("Import", Import.DefaultValue ?? DbNullValue); // DN
            row.Add("Tujuan", Tujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_klobs", SFAD_klobs.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_kl15", SFAD_kl15.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_barrels", SFAD_barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_lt", SFAD_lt.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_mt", SFAD_mt.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBl_klobs", NewBl_klobs.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBl_kl15", NewBl_kl15.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBl_barrels", NewBl_barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBl_lt", NewBl_lt.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBl_mt", NewBl_mt.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_klobs", AR45B_klobs.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_kl15", AR45B_kl15.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_barrels", AR45B_barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_lt", AR45B_lt.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_mt", AR45B_mt.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
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

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // idProses
            idProses.RowCssClass = "row";

            // idAktifitas
            idAktifitas.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // ApakahAdaROB
            ApakahAdaROB.RowCssClass = "row";

            // ApakahTerdapatROB
            ApakahTerdapatROB.RowCssClass = "row";

            // Import
            Import.RowCssClass = "row";

            // Tujuan
            Tujuan.RowCssClass = "row";

            // SFAD_klobs
            SFAD_klobs.RowCssClass = "row";

            // SFAD_kl15
            SFAD_kl15.RowCssClass = "row";

            // SFAD_barrels
            SFAD_barrels.RowCssClass = "row";

            // SFAD_lt
            SFAD_lt.RowCssClass = "row";

            // SFAD_mt
            SFAD_mt.RowCssClass = "row";

            // NewBl_klobs
            NewBl_klobs.RowCssClass = "row";

            // NewBl_kl15
            NewBl_kl15.RowCssClass = "row";

            // NewBl_barrels
            NewBl_barrels.RowCssClass = "row";

            // NewBl_lt
            NewBl_lt.RowCssClass = "row";

            // NewBl_mt
            NewBl_mt.RowCssClass = "row";

            // AR45B_klobs
            AR45B_klobs.RowCssClass = "row";

            // AR45B_kl15
            AR45B_kl15.RowCssClass = "row";

            // AR45B_barrels
            AR45B_barrels.RowCssClass = "row";

            // AR45B_lt
            AR45B_lt.RowCssClass = "row";

            // AR45B_mt
            AR45B_mt.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // idProses
                idProses.ViewValue = idProses.CurrentValue;
                string curVal = ConvertToString(idProses.CurrentValue);
                if (!Empty(curVal)) {
                    if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idProses.ViewValue = idProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk = idProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                            var listwrk = idProses.Lookup?.RenderViewRow(rswrk[0]);
                            idProses.ViewValue = idProses.DisplayValue(listwrk);
                        } else {
                            idProses.ViewValue = FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
                        }
                    }
                } else {
                    idProses.ViewValue = DbNullValue;
                }
                idProses.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.ViewValue = idAktifitas.CurrentValue;
                string curVal2 = ConvertToString(idAktifitas.CurrentValue);
                if (!Empty(curVal2)) {
                    if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idAktifitas.ViewValue = idAktifitas.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk2 = idAktifitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                            var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk2[0]);
                            idAktifitas.ViewValue = idAktifitas.DisplayValue(listwrk);
                        } else {
                            idAktifitas.ViewValue = FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
                        }
                    }
                } else {
                    idAktifitas.ViewValue = DbNullValue;
                }
                idAktifitas.ViewCustomAttributes = "";

                // StatusAktivitas
                StatusAktivitas.ViewValue = StatusAktivitas.CurrentValue;
                string curVal3 = ConvertToString(StatusAktivitas.CurrentValue);
                if (!Empty(curVal3)) {
                    if (StatusAktivitas.Lookup != null && IsDictionary(StatusAktivitas.Lookup?.Options) && StatusAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        StatusAktivitas.ViewValue = StatusAktivitas.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", StatusAktivitas.CurrentValue, StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk3 = StatusAktivitas.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && StatusAktivitas.Lookup != null) { // Lookup values found
                            var listwrk = StatusAktivitas.Lookup?.RenderViewRow(rswrk3[0]);
                            StatusAktivitas.ViewValue = StatusAktivitas.DisplayValue(listwrk);
                        } else {
                            StatusAktivitas.ViewValue = FormatNumber(StatusAktivitas.CurrentValue, StatusAktivitas.FormatPattern);
                        }
                    }
                } else {
                    StatusAktivitas.ViewValue = DbNullValue;
                }
                StatusAktivitas.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // lastUpdatedDate
                lastUpdatedDate.ViewValue = lastUpdatedDate.CurrentValue;
                lastUpdatedDate.ViewValue = FormatDateTime(lastUpdatedDate.ViewValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.ViewCustomAttributes = "";

                // ApakahAdaROB
                ApakahAdaROB.ViewValue = ConvertToString(ApakahAdaROB.CurrentValue); // DN
                ApakahAdaROB.ViewCustomAttributes = "";

                // ApakahTerdapatROB
                if (ConvertToBool(ApakahTerdapatROB.CurrentValue)) {
                    ApakahTerdapatROB.ViewValue = ApakahTerdapatROB.TagCaption(1) != "" ? ApakahTerdapatROB.TagCaption(1) : "Yes";
                } else {
                    ApakahTerdapatROB.ViewValue = ApakahTerdapatROB.TagCaption(2) != "" ? ApakahTerdapatROB.TagCaption(2) : "No";
                }
                ApakahTerdapatROB.ViewCustomAttributes = "";

                // Import
                if (ConvertToBool(Import.CurrentValue)) {
                    Import.ViewValue = Import.TagCaption(1) != "" ? Import.TagCaption(1) : "Yes";
                } else {
                    Import.ViewValue = Import.TagCaption(2) != "" ? Import.TagCaption(2) : "No";
                }
                Import.ViewCustomAttributes = "";

                // Tujuan
                string curVal6 = ConvertToString(Tujuan.CurrentValue);
                if (!Empty(curVal6)) {
                    if (Tujuan.Lookup != null && IsDictionary(Tujuan.Lookup?.Options) && Tujuan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Tujuan.ViewValue = Tujuan.LookupCacheOption(curVal6);
                    } else { // Lookup from database // DN
                        string filterWrk6 = SearchFilter(Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Tujuan.CurrentValue, Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk6 = Tujuan.Lookup?.GetSql(false, filterWrk6, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk6 = sqlWrk6 != null ? Connection.GetRows(sqlWrk6) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk6?.Count > 0 && Tujuan.Lookup != null) { // Lookup values found
                            var listwrk = Tujuan.Lookup?.RenderViewRow(rswrk6[0]);
                            Tujuan.ViewValue = Tujuan.DisplayValue(listwrk);
                        } else {
                            Tujuan.ViewValue = FormatNumber(Tujuan.CurrentValue, Tujuan.FormatPattern);
                        }
                    }
                } else {
                    Tujuan.ViewValue = DbNullValue;
                }
                Tujuan.ViewCustomAttributes = "";

                // SFAD_klobs
                SFAD_klobs.ViewValue = ConvertToString(SFAD_klobs.CurrentValue); // DN
                SFAD_klobs.ViewCustomAttributes = "";

                // SFAD_kl15
                SFAD_kl15.ViewValue = ConvertToString(SFAD_kl15.CurrentValue); // DN
                SFAD_kl15.ViewCustomAttributes = "";

                // SFAD_barrels
                SFAD_barrels.ViewValue = ConvertToString(SFAD_barrels.CurrentValue); // DN
                SFAD_barrels.ViewCustomAttributes = "";

                // SFAD_lt
                SFAD_lt.ViewValue = ConvertToString(SFAD_lt.CurrentValue); // DN
                SFAD_lt.ViewCustomAttributes = "";

                // SFAD_mt
                SFAD_mt.ViewValue = ConvertToString(SFAD_mt.CurrentValue); // DN
                SFAD_mt.ViewCustomAttributes = "";

                // NewBl_klobs
                NewBl_klobs.ViewValue = ConvertToString(NewBl_klobs.CurrentValue); // DN
                NewBl_klobs.ViewCustomAttributes = "";

                // NewBl_kl15
                NewBl_kl15.ViewValue = ConvertToString(NewBl_kl15.CurrentValue); // DN
                NewBl_kl15.ViewCustomAttributes = "";

                // NewBl_barrels
                NewBl_barrels.ViewValue = ConvertToString(NewBl_barrels.CurrentValue); // DN
                NewBl_barrels.ViewCustomAttributes = "";

                // NewBl_lt
                NewBl_lt.ViewValue = ConvertToString(NewBl_lt.CurrentValue); // DN
                NewBl_lt.ViewCustomAttributes = "";

                // NewBl_mt
                NewBl_mt.ViewValue = ConvertToString(NewBl_mt.CurrentValue); // DN
                NewBl_mt.ViewCustomAttributes = "";

                // AR45B_klobs
                AR45B_klobs.ViewValue = ConvertToString(AR45B_klobs.CurrentValue); // DN
                AR45B_klobs.ViewCustomAttributes = "";

                // AR45B_kl15
                AR45B_kl15.ViewValue = ConvertToString(AR45B_kl15.CurrentValue); // DN
                AR45B_kl15.ViewCustomAttributes = "";

                // AR45B_barrels
                AR45B_barrels.ViewValue = ConvertToString(AR45B_barrels.CurrentValue); // DN
                AR45B_barrels.ViewCustomAttributes = "";

                // AR45B_lt
                AR45B_lt.ViewValue = ConvertToString(AR45B_lt.CurrentValue); // DN
                AR45B_lt.ViewCustomAttributes = "";

                // AR45B_mt
                AR45B_mt.ViewValue = ConvertToString(AR45B_mt.CurrentValue); // DN
                AR45B_mt.ViewCustomAttributes = "";

                // userInput
                userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                userInput.ViewCustomAttributes = "";

                // etlDate
                etlDate.ViewValue = etlDate.CurrentValue;
                etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                etlDate.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // ApakahTerdapatROB
                ApakahTerdapatROB.HrefValue = "";

                // Import
                Import.HrefValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // SFAD_klobs
                SFAD_klobs.HrefValue = "";

                // SFAD_kl15
                SFAD_kl15.HrefValue = "";

                // SFAD_barrels
                SFAD_barrels.HrefValue = "";

                // SFAD_lt
                SFAD_lt.HrefValue = "";

                // SFAD_mt
                SFAD_mt.HrefValue = "";

                // NewBl_klobs
                NewBl_klobs.HrefValue = "";

                // NewBl_kl15
                NewBl_kl15.HrefValue = "";

                // NewBl_barrels
                NewBl_barrels.HrefValue = "";

                // NewBl_lt
                NewBl_lt.HrefValue = "";

                // NewBl_mt
                NewBl_mt.HrefValue = "";

                // AR45B_klobs
                AR45B_klobs.HrefValue = "";

                // AR45B_kl15
                AR45B_kl15.HrefValue = "";

                // AR45B_barrels
                AR45B_barrels.HrefValue = "";

                // AR45B_lt
                AR45B_lt.HrefValue = "";

                // AR45B_mt
                AR45B_mt.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // NoReferensi
                NoReferensi.SetupEditAttributes();
                NoReferensi.EditValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;
                string curVal = ConvertToString(idProses.CurrentValue);
                if (!Empty(curVal)) {
                    if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idProses.EditValue = idProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk = idProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                            var listwrk = idProses.Lookup?.RenderViewRow(rswrk[0]);
                            idProses.EditValue = idProses.DisplayValue(listwrk);
                        } else {
                            idProses.EditValue = FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
                        }
                    }
                } else {
                    idProses.EditValue = DbNullValue;
                }
                idProses.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;
                string curVal2 = ConvertToString(idAktifitas.CurrentValue);
                if (!Empty(curVal2)) {
                    if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idAktifitas.EditValue = idAktifitas.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk2 = idAktifitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                            var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk2[0]);
                            idAktifitas.EditValue = idAktifitas.DisplayValue(listwrk);
                        } else {
                            idAktifitas.EditValue = FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
                        }
                    }
                } else {
                    idAktifitas.EditValue = DbNullValue;
                }
                idAktifitas.ViewCustomAttributes = "";

                // StatusAktivitas
                StatusAktivitas.SetupEditAttributes();
                StatusAktivitas.EditValue = StatusAktivitas.CurrentValue;
                string curVal3 = ConvertToString(StatusAktivitas.CurrentValue);
                if (!Empty(curVal3)) {
                    if (StatusAktivitas.Lookup != null && IsDictionary(StatusAktivitas.Lookup?.Options) && StatusAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        StatusAktivitas.EditValue = StatusAktivitas.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", StatusAktivitas.CurrentValue, StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk3 = StatusAktivitas.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && StatusAktivitas.Lookup != null) { // Lookup values found
                            var listwrk = StatusAktivitas.Lookup?.RenderViewRow(rswrk3[0]);
                            StatusAktivitas.EditValue = StatusAktivitas.DisplayValue(listwrk);
                        } else {
                            StatusAktivitas.EditValue = FormatNumber(StatusAktivitas.CurrentValue, StatusAktivitas.FormatPattern);
                        }
                    }
                } else {
                    StatusAktivitas.EditValue = DbNullValue;
                }
                StatusAktivitas.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                LastUpdatedBy.EditValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // lastUpdatedDate
                lastUpdatedDate.SetupEditAttributes();
                lastUpdatedDate.EditValue = lastUpdatedDate.CurrentValue;
                lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.EditValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.ViewCustomAttributes = "";

                // ApakahTerdapatROB
                ApakahTerdapatROB.EditValue = ApakahTerdapatROB.Options(false);
                ApakahTerdapatROB.PlaceHolder = RemoveHtml(ApakahTerdapatROB.Caption);

                // Import
                Import.EditValue = Import.Options(false);
                Import.PlaceHolder = RemoveHtml(Import.Caption);

                // Tujuan
                Tujuan.SetupEditAttributes();
                string curVal6 = ConvertToString(Tujuan.CurrentValue);
                if (Tujuan.Lookup != null && IsDictionary(Tujuan.Lookup?.Options) && Tujuan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Tujuan.EditValue = Tujuan.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk6 = "";
                    if (curVal6 == "") {
                        filterWrk6 = "0=1";
                    } else {
                        filterWrk6 = SearchFilter(Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Tujuan.CurrentValue, Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk6 = Tujuan.Lookup?.GetSql(true, filterWrk6, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk6 = sqlWrk6 != null ? Connection.GetRows(sqlWrk6) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Tujuan.EditValue = rswrk6;
                }
                Tujuan.PlaceHolder = RemoveHtml(Tujuan.Caption);
                if (!Empty(Tujuan.EditValue) && IsNumeric(Tujuan.EditValue))
                    Tujuan.EditValue = FormatNumber(Tujuan.EditValue, null);

                // SFAD_klobs
                SFAD_klobs.SetupEditAttributes();
                if (!SFAD_klobs.Raw)
                    SFAD_klobs.CurrentValue = HtmlDecode(SFAD_klobs.CurrentValue);
                SFAD_klobs.EditValue = HtmlEncode(SFAD_klobs.CurrentValue);
                SFAD_klobs.PlaceHolder = RemoveHtml(SFAD_klobs.Caption);

                // SFAD_kl15
                SFAD_kl15.SetupEditAttributes();
                if (!SFAD_kl15.Raw)
                    SFAD_kl15.CurrentValue = HtmlDecode(SFAD_kl15.CurrentValue);
                SFAD_kl15.EditValue = HtmlEncode(SFAD_kl15.CurrentValue);
                SFAD_kl15.PlaceHolder = RemoveHtml(SFAD_kl15.Caption);

                // SFAD_barrels
                SFAD_barrels.SetupEditAttributes();
                if (!SFAD_barrels.Raw)
                    SFAD_barrels.CurrentValue = HtmlDecode(SFAD_barrels.CurrentValue);
                SFAD_barrels.EditValue = HtmlEncode(SFAD_barrels.CurrentValue);
                SFAD_barrels.PlaceHolder = RemoveHtml(SFAD_barrels.Caption);

                // SFAD_lt
                SFAD_lt.SetupEditAttributes();
                if (!SFAD_lt.Raw)
                    SFAD_lt.CurrentValue = HtmlDecode(SFAD_lt.CurrentValue);
                SFAD_lt.EditValue = HtmlEncode(SFAD_lt.CurrentValue);
                SFAD_lt.PlaceHolder = RemoveHtml(SFAD_lt.Caption);

                // SFAD_mt
                SFAD_mt.SetupEditAttributes();
                if (!SFAD_mt.Raw)
                    SFAD_mt.CurrentValue = HtmlDecode(SFAD_mt.CurrentValue);
                SFAD_mt.EditValue = HtmlEncode(SFAD_mt.CurrentValue);
                SFAD_mt.PlaceHolder = RemoveHtml(SFAD_mt.Caption);

                // NewBl_klobs
                NewBl_klobs.SetupEditAttributes();
                if (!NewBl_klobs.Raw)
                    NewBl_klobs.CurrentValue = HtmlDecode(NewBl_klobs.CurrentValue);
                NewBl_klobs.EditValue = HtmlEncode(NewBl_klobs.CurrentValue);
                NewBl_klobs.PlaceHolder = RemoveHtml(NewBl_klobs.Caption);

                // NewBl_kl15
                NewBl_kl15.SetupEditAttributes();
                if (!NewBl_kl15.Raw)
                    NewBl_kl15.CurrentValue = HtmlDecode(NewBl_kl15.CurrentValue);
                NewBl_kl15.EditValue = HtmlEncode(NewBl_kl15.CurrentValue);
                NewBl_kl15.PlaceHolder = RemoveHtml(NewBl_kl15.Caption);

                // NewBl_barrels
                NewBl_barrels.SetupEditAttributes();
                if (!NewBl_barrels.Raw)
                    NewBl_barrels.CurrentValue = HtmlDecode(NewBl_barrels.CurrentValue);
                NewBl_barrels.EditValue = HtmlEncode(NewBl_barrels.CurrentValue);
                NewBl_barrels.PlaceHolder = RemoveHtml(NewBl_barrels.Caption);

                // NewBl_lt
                NewBl_lt.SetupEditAttributes();
                if (!NewBl_lt.Raw)
                    NewBl_lt.CurrentValue = HtmlDecode(NewBl_lt.CurrentValue);
                NewBl_lt.EditValue = HtmlEncode(NewBl_lt.CurrentValue);
                NewBl_lt.PlaceHolder = RemoveHtml(NewBl_lt.Caption);

                // NewBl_mt
                NewBl_mt.SetupEditAttributes();
                if (!NewBl_mt.Raw)
                    NewBl_mt.CurrentValue = HtmlDecode(NewBl_mt.CurrentValue);
                NewBl_mt.EditValue = HtmlEncode(NewBl_mt.CurrentValue);
                NewBl_mt.PlaceHolder = RemoveHtml(NewBl_mt.Caption);

                // AR45B_klobs
                AR45B_klobs.SetupEditAttributes();
                if (!AR45B_klobs.Raw)
                    AR45B_klobs.CurrentValue = HtmlDecode(AR45B_klobs.CurrentValue);
                AR45B_klobs.EditValue = HtmlEncode(AR45B_klobs.CurrentValue);
                AR45B_klobs.PlaceHolder = RemoveHtml(AR45B_klobs.Caption);

                // AR45B_kl15
                AR45B_kl15.SetupEditAttributes();
                if (!AR45B_kl15.Raw)
                    AR45B_kl15.CurrentValue = HtmlDecode(AR45B_kl15.CurrentValue);
                AR45B_kl15.EditValue = HtmlEncode(AR45B_kl15.CurrentValue);
                AR45B_kl15.PlaceHolder = RemoveHtml(AR45B_kl15.Caption);

                // AR45B_barrels
                AR45B_barrels.SetupEditAttributes();
                if (!AR45B_barrels.Raw)
                    AR45B_barrels.CurrentValue = HtmlDecode(AR45B_barrels.CurrentValue);
                AR45B_barrels.EditValue = HtmlEncode(AR45B_barrels.CurrentValue);
                AR45B_barrels.PlaceHolder = RemoveHtml(AR45B_barrels.Caption);

                // AR45B_lt
                AR45B_lt.SetupEditAttributes();
                if (!AR45B_lt.Raw)
                    AR45B_lt.CurrentValue = HtmlDecode(AR45B_lt.CurrentValue);
                AR45B_lt.EditValue = HtmlEncode(AR45B_lt.CurrentValue);
                AR45B_lt.PlaceHolder = RemoveHtml(AR45B_lt.Caption);

                // AR45B_mt
                AR45B_mt.SetupEditAttributes();
                if (!AR45B_mt.Raw)
                    AR45B_mt.CurrentValue = HtmlDecode(AR45B_mt.CurrentValue);
                AR45B_mt.EditValue = HtmlEncode(AR45B_mt.CurrentValue);
                AR45B_mt.PlaceHolder = RemoveHtml(AR45B_mt.Caption);

                // Edit refer script

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // ApakahTerdapatROB
                ApakahTerdapatROB.HrefValue = "";

                // Import
                Import.HrefValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // SFAD_klobs
                SFAD_klobs.HrefValue = "";

                // SFAD_kl15
                SFAD_kl15.HrefValue = "";

                // SFAD_barrels
                SFAD_barrels.HrefValue = "";

                // SFAD_lt
                SFAD_lt.HrefValue = "";

                // SFAD_mt
                SFAD_mt.HrefValue = "";

                // NewBl_klobs
                NewBl_klobs.HrefValue = "";

                // NewBl_kl15
                NewBl_kl15.HrefValue = "";

                // NewBl_barrels
                NewBl_barrels.HrefValue = "";

                // NewBl_lt
                NewBl_lt.HrefValue = "";

                // NewBl_mt
                NewBl_mt.HrefValue = "";

                // AR45B_klobs
                AR45B_klobs.HrefValue = "";

                // AR45B_kl15
                AR45B_kl15.HrefValue = "";

                // AR45B_barrels
                AR45B_barrels.HrefValue = "";

                // AR45B_lt
                AR45B_lt.HrefValue = "";

                // AR45B_mt
                AR45B_mt.HrefValue = "";
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
                if (NoReferensi.Visible && NoReferensi.Required) {
                    if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                        NoReferensi.AddErrorMessage(ConvertToString(NoReferensi.RequiredErrorMessage).Replace("%s", NoReferensi.Caption));
                    }
                }
                if (idProses.Visible && idProses.Required) {
                    if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                        idProses.AddErrorMessage(ConvertToString(idProses.RequiredErrorMessage).Replace("%s", idProses.Caption));
                    }
                }
                if (idAktifitas.Visible && idAktifitas.Required) {
                    if (!idAktifitas.IsDetailKey && Empty(idAktifitas.FormValue)) {
                        idAktifitas.AddErrorMessage(ConvertToString(idAktifitas.RequiredErrorMessage).Replace("%s", idAktifitas.Caption));
                    }
                }
                if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                    if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                        StatusAktivitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                    }
                }
                if (LastUpdatedBy.Visible && LastUpdatedBy.Required) {
                    if (!LastUpdatedBy.IsDetailKey && Empty(LastUpdatedBy.FormValue)) {
                        LastUpdatedBy.AddErrorMessage(ConvertToString(LastUpdatedBy.RequiredErrorMessage).Replace("%s", LastUpdatedBy.Caption));
                    }
                }
                if (lastUpdatedDate.Visible && lastUpdatedDate.Required) {
                    if (!lastUpdatedDate.IsDetailKey && Empty(lastUpdatedDate.FormValue)) {
                        lastUpdatedDate.AddErrorMessage(ConvertToString(lastUpdatedDate.RequiredErrorMessage).Replace("%s", lastUpdatedDate.Caption));
                    }
                }
                if (ApakahTerdapatROB.Visible && ApakahTerdapatROB.Required) {
                    if (Empty(ApakahTerdapatROB.FormValue)) {
                        ApakahTerdapatROB.AddErrorMessage(ConvertToString(ApakahTerdapatROB.RequiredErrorMessage).Replace("%s", ApakahTerdapatROB.Caption));
                    }
                }
                if (Import.Visible && Import.Required) {
                    if (Empty(Import.FormValue)) {
                        Import.AddErrorMessage(ConvertToString(Import.RequiredErrorMessage).Replace("%s", Import.Caption));
                    }
                }
                if (Tujuan.Visible && Tujuan.Required) {
                    if (!Tujuan.IsDetailKey && Empty(Tujuan.FormValue)) {
                        Tujuan.AddErrorMessage(ConvertToString(Tujuan.RequiredErrorMessage).Replace("%s", Tujuan.Caption));
                    }
                }
                if (SFAD_klobs.Visible && SFAD_klobs.Required) {
                    if (!SFAD_klobs.IsDetailKey && Empty(SFAD_klobs.FormValue)) {
                        SFAD_klobs.AddErrorMessage(ConvertToString(SFAD_klobs.RequiredErrorMessage).Replace("%s", SFAD_klobs.Caption));
                    }
                }
                if (SFAD_kl15.Visible && SFAD_kl15.Required) {
                    if (!SFAD_kl15.IsDetailKey && Empty(SFAD_kl15.FormValue)) {
                        SFAD_kl15.AddErrorMessage(ConvertToString(SFAD_kl15.RequiredErrorMessage).Replace("%s", SFAD_kl15.Caption));
                    }
                }
                if (SFAD_barrels.Visible && SFAD_barrels.Required) {
                    if (!SFAD_barrels.IsDetailKey && Empty(SFAD_barrels.FormValue)) {
                        SFAD_barrels.AddErrorMessage(ConvertToString(SFAD_barrels.RequiredErrorMessage).Replace("%s", SFAD_barrels.Caption));
                    }
                }
                if (SFAD_lt.Visible && SFAD_lt.Required) {
                    if (!SFAD_lt.IsDetailKey && Empty(SFAD_lt.FormValue)) {
                        SFAD_lt.AddErrorMessage(ConvertToString(SFAD_lt.RequiredErrorMessage).Replace("%s", SFAD_lt.Caption));
                    }
                }
                if (SFAD_mt.Visible && SFAD_mt.Required) {
                    if (!SFAD_mt.IsDetailKey && Empty(SFAD_mt.FormValue)) {
                        SFAD_mt.AddErrorMessage(ConvertToString(SFAD_mt.RequiredErrorMessage).Replace("%s", SFAD_mt.Caption));
                    }
                }
                if (NewBl_klobs.Visible && NewBl_klobs.Required) {
                    if (!NewBl_klobs.IsDetailKey && Empty(NewBl_klobs.FormValue)) {
                        NewBl_klobs.AddErrorMessage(ConvertToString(NewBl_klobs.RequiredErrorMessage).Replace("%s", NewBl_klobs.Caption));
                    }
                }
                if (NewBl_kl15.Visible && NewBl_kl15.Required) {
                    if (!NewBl_kl15.IsDetailKey && Empty(NewBl_kl15.FormValue)) {
                        NewBl_kl15.AddErrorMessage(ConvertToString(NewBl_kl15.RequiredErrorMessage).Replace("%s", NewBl_kl15.Caption));
                    }
                }
                if (NewBl_barrels.Visible && NewBl_barrels.Required) {
                    if (!NewBl_barrels.IsDetailKey && Empty(NewBl_barrels.FormValue)) {
                        NewBl_barrels.AddErrorMessage(ConvertToString(NewBl_barrels.RequiredErrorMessage).Replace("%s", NewBl_barrels.Caption));
                    }
                }
                if (NewBl_lt.Visible && NewBl_lt.Required) {
                    if (!NewBl_lt.IsDetailKey && Empty(NewBl_lt.FormValue)) {
                        NewBl_lt.AddErrorMessage(ConvertToString(NewBl_lt.RequiredErrorMessage).Replace("%s", NewBl_lt.Caption));
                    }
                }
                if (NewBl_mt.Visible && NewBl_mt.Required) {
                    if (!NewBl_mt.IsDetailKey && Empty(NewBl_mt.FormValue)) {
                        NewBl_mt.AddErrorMessage(ConvertToString(NewBl_mt.RequiredErrorMessage).Replace("%s", NewBl_mt.Caption));
                    }
                }
                if (AR45B_klobs.Visible && AR45B_klobs.Required) {
                    if (!AR45B_klobs.IsDetailKey && Empty(AR45B_klobs.FormValue)) {
                        AR45B_klobs.AddErrorMessage(ConvertToString(AR45B_klobs.RequiredErrorMessage).Replace("%s", AR45B_klobs.Caption));
                    }
                }
                if (AR45B_kl15.Visible && AR45B_kl15.Required) {
                    if (!AR45B_kl15.IsDetailKey && Empty(AR45B_kl15.FormValue)) {
                        AR45B_kl15.AddErrorMessage(ConvertToString(AR45B_kl15.RequiredErrorMessage).Replace("%s", AR45B_kl15.Caption));
                    }
                }
                if (AR45B_barrels.Visible && AR45B_barrels.Required) {
                    if (!AR45B_barrels.IsDetailKey && Empty(AR45B_barrels.FormValue)) {
                        AR45B_barrels.AddErrorMessage(ConvertToString(AR45B_barrels.RequiredErrorMessage).Replace("%s", AR45B_barrels.Caption));
                    }
                }
                if (AR45B_lt.Visible && AR45B_lt.Required) {
                    if (!AR45B_lt.IsDetailKey && Empty(AR45B_lt.FormValue)) {
                        AR45B_lt.AddErrorMessage(ConvertToString(AR45B_lt.RequiredErrorMessage).Replace("%s", AR45B_lt.Caption));
                    }
                }
                if (AR45B_mt.Visible && AR45B_mt.Required) {
                    if (!AR45B_mt.IsDetailKey && Empty(AR45B_mt.FormValue)) {
                        AR45B_mt.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
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

            // ApakahTerdapatROB
            ApakahTerdapatROB.SetDbValue(rsnew, ConvertToBool(ApakahTerdapatROB.CurrentValue), ApakahTerdapatROB.ReadOnly);

            // Import
            Import.SetDbValue(rsnew, ConvertToBool(Import.CurrentValue), Import.ReadOnly);

            // Tujuan
            Tujuan.SetDbValue(rsnew, Tujuan.CurrentValue, Tujuan.ReadOnly);

            // SFAD_klobs
            SFAD_klobs.SetDbValue(rsnew, SFAD_klobs.CurrentValue, SFAD_klobs.ReadOnly);

            // SFAD_kl15
            SFAD_kl15.SetDbValue(rsnew, SFAD_kl15.CurrentValue, SFAD_kl15.ReadOnly);

            // SFAD_barrels
            SFAD_barrels.SetDbValue(rsnew, SFAD_barrels.CurrentValue, SFAD_barrels.ReadOnly);

            // SFAD_lt
            SFAD_lt.SetDbValue(rsnew, SFAD_lt.CurrentValue, SFAD_lt.ReadOnly);

            // SFAD_mt
            SFAD_mt.SetDbValue(rsnew, SFAD_mt.CurrentValue, SFAD_mt.ReadOnly);

            // NewBl_klobs
            NewBl_klobs.SetDbValue(rsnew, NewBl_klobs.CurrentValue, NewBl_klobs.ReadOnly);

            // NewBl_kl15
            NewBl_kl15.SetDbValue(rsnew, NewBl_kl15.CurrentValue, NewBl_kl15.ReadOnly);

            // NewBl_barrels
            NewBl_barrels.SetDbValue(rsnew, NewBl_barrels.CurrentValue, NewBl_barrels.ReadOnly);

            // NewBl_lt
            NewBl_lt.SetDbValue(rsnew, NewBl_lt.CurrentValue, NewBl_lt.ReadOnly);

            // NewBl_mt
            NewBl_mt.SetDbValue(rsnew, NewBl_mt.CurrentValue, NewBl_mt.ReadOnly);

            // AR45B_klobs
            AR45B_klobs.SetDbValue(rsnew, AR45B_klobs.CurrentValue, AR45B_klobs.ReadOnly);

            // AR45B_kl15
            AR45B_kl15.SetDbValue(rsnew, AR45B_kl15.CurrentValue, AR45B_kl15.ReadOnly);

            // AR45B_barrels
            AR45B_barrels.SetDbValue(rsnew, AR45B_barrels.CurrentValue, AR45B_barrels.ReadOnly);

            // AR45B_lt
            AR45B_lt.SetDbValue(rsnew, AR45B_lt.CurrentValue, AR45B_lt.ReadOnly);

            // AR45B_mt
            AR45B_mt.SetDbValue(rsnew, AR45B_mt.CurrentValue, AR45B_mt.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("ApakahTerdapatROB", out value)) // ApakahTerdapatROB
                ApakahTerdapatROB.CurrentValue = value;
            if (row.TryGetValue("Import", out value)) // Import
                Import.CurrentValue = value;
            if (row.TryGetValue("Tujuan", out value)) // Tujuan
                Tujuan.CurrentValue = value;
            if (row.TryGetValue("SFAD_klobs", out value)) // SFAD_klobs
                SFAD_klobs.CurrentValue = value;
            if (row.TryGetValue("SFAD_kl15", out value)) // SFAD_kl15
                SFAD_kl15.CurrentValue = value;
            if (row.TryGetValue("SFAD_barrels", out value)) // SFAD_barrels
                SFAD_barrels.CurrentValue = value;
            if (row.TryGetValue("SFAD_lt", out value)) // SFAD_lt
                SFAD_lt.CurrentValue = value;
            if (row.TryGetValue("SFAD_mt", out value)) // SFAD_mt
                SFAD_mt.CurrentValue = value;
            if (row.TryGetValue("NewBl_klobs", out value)) // NewBl_klobs
                NewBl_klobs.CurrentValue = value;
            if (row.TryGetValue("NewBl_kl15", out value)) // NewBl_kl15
                NewBl_kl15.CurrentValue = value;
            if (row.TryGetValue("NewBl_barrels", out value)) // NewBl_barrels
                NewBl_barrels.CurrentValue = value;
            if (row.TryGetValue("NewBl_lt", out value)) // NewBl_lt
                NewBl_lt.CurrentValue = value;
            if (row.TryGetValue("NewBl_mt", out value)) // NewBl_mt
                NewBl_mt.CurrentValue = value;
            if (row.TryGetValue("AR45B_klobs", out value)) // AR45B_klobs
                AR45B_klobs.CurrentValue = value;
            if (row.TryGetValue("AR45B_kl15", out value)) // AR45B_kl15
                AR45B_kl15.CurrentValue = value;
            if (row.TryGetValue("AR45B_barrels", out value)) // AR45B_barrels
                AR45B_barrels.CurrentValue = value;
            if (row.TryGetValue("AR45B_lt", out value)) // AR45B_lt
                AR45B_lt.CurrentValue = value;
            if (row.TryGetValue("AR45B_mt", out value)) // AR45B_mt
                AR45B_mt.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasSfadNewBlstsPnrBbmList")), "", TableVar, true);
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
