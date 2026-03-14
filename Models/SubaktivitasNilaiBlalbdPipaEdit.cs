namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subaktivitasNilaiBlalbdPipaEdit
    /// </summary>
    public static SubaktivitasNilaiBlalbdPipaEdit subaktivitasNilaiBlalbdPipaEdit
    {
        get => HttpData.Get<SubaktivitasNilaiBlalbdPipaEdit>("subaktivitasNilaiBlalbdPipaEdit")!;
        set => HttpData["subaktivitasNilaiBlalbdPipaEdit"] = value;
    }

    /// <summary>
    /// Page class for SubaktivitasNilaiBLALBDPipa
    /// </summary>
    public class SubaktivitasNilaiBlalbdPipaEdit : SubaktivitasNilaiBlalbdPipaEditBase
    {
        // Constructor
        public SubaktivitasNilaiBlalbdPipaEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubaktivitasNilaiBlalbdPipaEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubaktivitasNilaiBlalbdPipaEditBase : SubaktivitasNilaiBlalbdPipa
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subaktivitasNilaiBlalbdPipaEdit";

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
        public SubaktivitasNilaiBlalbdPipaEditBase()
        {
            TableName = "SubaktivitasNilaiBLALBDPipa";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (subaktivitasNilaiBlalbdPipa)
            if (subaktivitasNilaiBlalbdPipa == null || subaktivitasNilaiBlalbdPipa is SubaktivitasNilaiBlalbdPipa)
                subaktivitasNilaiBlalbdPipa = this;

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
        public string PageName => "SubaktivitasNilaiBlalbdPipaEdit";

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
            idAktifitas.SetVisibility();
            BL_klobs.SetVisibility();
            BL_kl15.SetVisibility();
            BL_barrels.SetVisibility();
            BL_lt.SetVisibility();
            BL_mt.SetVisibility();
            AL_klobs.SetVisibility();
            AL_kl15.SetVisibility();
            AL_barrels.SetVisibility();
            AL_lt.SetVisibility();
            AL_mt.SetVisibility();
            BD_klobs.SetVisibility();
            BD_kl15.SetVisibility();
            BD_barrels.SetVisibility();
            BD_lt.SetVisibility();
            BD_mt.SetVisibility();
            userInput.Visible = false;
            etlDate.Visible = false;
            idProses.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            NoReferensi.SetVisibility();
            StatusAktivitas.SetVisibility();
        }

        // Constructor
        public SubaktivitasNilaiBlalbdPipaEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "SubaktivitasNilaiBlalbdPipaView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(idAktifitas);
            await SetupLookupOptions(idProses);
            await SetupLookupOptions(StatusAktivitas);

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
                            return Terminate("SubaktivitasNilaiBlalbdPipaList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "SubaktivitasNilaiBlalbdPipaList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SubaktivitasNilaiBlalbdPipaList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SubaktivitasNilaiBlalbdPipaList"; // Return list page content
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
                subaktivitasNilaiBlalbdPipaEdit?.PageRender();
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

            // Check field name 'idAktifitas' before field var 'x_idAktifitas'
            val = CurrentForm.HasValue("idAktifitas") ? CurrentForm.GetValue("idAktifitas") : CurrentForm.GetValue("x_idAktifitas");
            if (!idAktifitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idAktifitas") && !CurrentForm.HasValue("x_idAktifitas")) // DN
                    idAktifitas.Visible = false; // Disable update for API request
                else
                    idAktifitas.SetFormValue(val);
            }

            // Check field name 'BL_klobs' before field var 'x_BL_klobs'
            val = CurrentForm.HasValue("BL_klobs") ? CurrentForm.GetValue("BL_klobs") : CurrentForm.GetValue("x_BL_klobs");
            if (!BL_klobs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_klobs") && !CurrentForm.HasValue("x_BL_klobs")) // DN
                    BL_klobs.Visible = false; // Disable update for API request
                else
                    BL_klobs.SetFormValue(val);
            }

            // Check field name 'BL_kl15' before field var 'x_BL_kl15'
            val = CurrentForm.HasValue("BL_kl15") ? CurrentForm.GetValue("BL_kl15") : CurrentForm.GetValue("x_BL_kl15");
            if (!BL_kl15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_kl15") && !CurrentForm.HasValue("x_BL_kl15")) // DN
                    BL_kl15.Visible = false; // Disable update for API request
                else
                    BL_kl15.SetFormValue(val);
            }

            // Check field name 'BL_barrels' before field var 'x_BL_barrels'
            val = CurrentForm.HasValue("BL_barrels") ? CurrentForm.GetValue("BL_barrels") : CurrentForm.GetValue("x_BL_barrels");
            if (!BL_barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_barrels") && !CurrentForm.HasValue("x_BL_barrels")) // DN
                    BL_barrels.Visible = false; // Disable update for API request
                else
                    BL_barrels.SetFormValue(val);
            }

            // Check field name 'BL_lt' before field var 'x_BL_lt'
            val = CurrentForm.HasValue("BL_lt") ? CurrentForm.GetValue("BL_lt") : CurrentForm.GetValue("x_BL_lt");
            if (!BL_lt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_lt") && !CurrentForm.HasValue("x_BL_lt")) // DN
                    BL_lt.Visible = false; // Disable update for API request
                else
                    BL_lt.SetFormValue(val);
            }

            // Check field name 'BL_mt' before field var 'x_BL_mt'
            val = CurrentForm.HasValue("BL_mt") ? CurrentForm.GetValue("BL_mt") : CurrentForm.GetValue("x_BL_mt");
            if (!BL_mt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_mt") && !CurrentForm.HasValue("x_BL_mt")) // DN
                    BL_mt.Visible = false; // Disable update for API request
                else
                    BL_mt.SetFormValue(val);
            }

            // Check field name 'AL_klobs' before field var 'x_AL_klobs'
            val = CurrentForm.HasValue("AL_klobs") ? CurrentForm.GetValue("AL_klobs") : CurrentForm.GetValue("x_AL_klobs");
            if (!AL_klobs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_klobs") && !CurrentForm.HasValue("x_AL_klobs")) // DN
                    AL_klobs.Visible = false; // Disable update for API request
                else
                    AL_klobs.SetFormValue(val);
            }

            // Check field name 'AL_kl15' before field var 'x_AL_kl15'
            val = CurrentForm.HasValue("AL_kl15") ? CurrentForm.GetValue("AL_kl15") : CurrentForm.GetValue("x_AL_kl15");
            if (!AL_kl15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_kl15") && !CurrentForm.HasValue("x_AL_kl15")) // DN
                    AL_kl15.Visible = false; // Disable update for API request
                else
                    AL_kl15.SetFormValue(val);
            }

            // Check field name 'AL_barrels' before field var 'x_AL_barrels'
            val = CurrentForm.HasValue("AL_barrels") ? CurrentForm.GetValue("AL_barrels") : CurrentForm.GetValue("x_AL_barrels");
            if (!AL_barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_barrels") && !CurrentForm.HasValue("x_AL_barrels")) // DN
                    AL_barrels.Visible = false; // Disable update for API request
                else
                    AL_barrels.SetFormValue(val);
            }

            // Check field name 'AL_lt' before field var 'x_AL_lt'
            val = CurrentForm.HasValue("AL_lt") ? CurrentForm.GetValue("AL_lt") : CurrentForm.GetValue("x_AL_lt");
            if (!AL_lt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_lt") && !CurrentForm.HasValue("x_AL_lt")) // DN
                    AL_lt.Visible = false; // Disable update for API request
                else
                    AL_lt.SetFormValue(val);
            }

            // Check field name 'AL_mt' before field var 'x_AL_mt'
            val = CurrentForm.HasValue("AL_mt") ? CurrentForm.GetValue("AL_mt") : CurrentForm.GetValue("x_AL_mt");
            if (!AL_mt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_mt") && !CurrentForm.HasValue("x_AL_mt")) // DN
                    AL_mt.Visible = false; // Disable update for API request
                else
                    AL_mt.SetFormValue(val);
            }

            // Check field name 'BD_klobs' before field var 'x_BD_klobs'
            val = CurrentForm.HasValue("BD_klobs") ? CurrentForm.GetValue("BD_klobs") : CurrentForm.GetValue("x_BD_klobs");
            if (!BD_klobs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BD_klobs") && !CurrentForm.HasValue("x_BD_klobs")) // DN
                    BD_klobs.Visible = false; // Disable update for API request
                else
                    BD_klobs.SetFormValue(val);
            }

            // Check field name 'BD_kl15' before field var 'x_BD_kl15'
            val = CurrentForm.HasValue("BD_kl15") ? CurrentForm.GetValue("BD_kl15") : CurrentForm.GetValue("x_BD_kl15");
            if (!BD_kl15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BD_kl15") && !CurrentForm.HasValue("x_BD_kl15")) // DN
                    BD_kl15.Visible = false; // Disable update for API request
                else
                    BD_kl15.SetFormValue(val);
            }

            // Check field name 'BD_barrels' before field var 'x_BD_barrels'
            val = CurrentForm.HasValue("BD_barrels") ? CurrentForm.GetValue("BD_barrels") : CurrentForm.GetValue("x_BD_barrels");
            if (!BD_barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BD_barrels") && !CurrentForm.HasValue("x_BD_barrels")) // DN
                    BD_barrels.Visible = false; // Disable update for API request
                else
                    BD_barrels.SetFormValue(val);
            }

            // Check field name 'BD_lt' before field var 'x_BD_lt'
            val = CurrentForm.HasValue("BD_lt") ? CurrentForm.GetValue("BD_lt") : CurrentForm.GetValue("x_BD_lt");
            if (!BD_lt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BD_lt") && !CurrentForm.HasValue("x_BD_lt")) // DN
                    BD_lt.Visible = false; // Disable update for API request
                else
                    BD_lt.SetFormValue(val);
            }

            // Check field name 'BD_mt' before field var 'x_BD_mt'
            val = CurrentForm.HasValue("BD_mt") ? CurrentForm.GetValue("BD_mt") : CurrentForm.GetValue("x_BD_mt");
            if (!BD_mt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BD_mt") && !CurrentForm.HasValue("x_BD_mt")) // DN
                    BD_mt.Visible = false; // Disable update for API request
                else
                    BD_mt.SetFormValue(val);
            }

            // Check field name 'idProses' before field var 'x_idProses'
            val = CurrentForm.HasValue("idProses") ? CurrentForm.GetValue("idProses") : CurrentForm.GetValue("x_idProses");
            if (!idProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idProses") && !CurrentForm.HasValue("x_idProses")) // DN
                    idProses.Visible = false; // Disable update for API request
                else
                    idProses.SetFormValue(val);
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

            // Check field name 'NoReferensi' before field var 'x_NoReferensi'
            val = CurrentForm.HasValue("NoReferensi") ? CurrentForm.GetValue("NoReferensi") : CurrentForm.GetValue("x_NoReferensi");
            if (!NoReferensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoReferensi") && !CurrentForm.HasValue("x_NoReferensi")) // DN
                    NoReferensi.Visible = false; // Disable update for API request
                else
                    NoReferensi.SetFormValue(val);
            }

            // Check field name 'StatusAktivitas' before field var 'x_StatusAktivitas'
            val = CurrentForm.HasValue("StatusAktivitas") ? CurrentForm.GetValue("StatusAktivitas") : CurrentForm.GetValue("x_StatusAktivitas");
            if (!StatusAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusAktivitas") && !CurrentForm.HasValue("x_StatusAktivitas")) // DN
                    StatusAktivitas.Visible = false; // Disable update for API request
                else
                    StatusAktivitas.SetFormValue(val);
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
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            BL_klobs.CurrentValue = BL_klobs.FormValue;
            BL_kl15.CurrentValue = BL_kl15.FormValue;
            BL_barrels.CurrentValue = BL_barrels.FormValue;
            BL_lt.CurrentValue = BL_lt.FormValue;
            BL_mt.CurrentValue = BL_mt.FormValue;
            AL_klobs.CurrentValue = AL_klobs.FormValue;
            AL_kl15.CurrentValue = AL_kl15.FormValue;
            AL_barrels.CurrentValue = AL_barrels.FormValue;
            AL_lt.CurrentValue = AL_lt.FormValue;
            AL_mt.CurrentValue = AL_mt.FormValue;
            BD_klobs.CurrentValue = BD_klobs.FormValue;
            BD_kl15.CurrentValue = BD_kl15.FormValue;
            BD_barrels.CurrentValue = BD_barrels.FormValue;
            BD_lt.CurrentValue = BD_lt.FormValue;
            BD_mt.CurrentValue = BD_mt.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
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
            idAktifitas.SetDbValue(row["idAktifitas"]);
            BL_klobs.SetDbValue(row["BL_klobs"]);
            BL_kl15.SetDbValue(row["BL_kl15"]);
            BL_barrels.SetDbValue(row["BL_barrels"]);
            BL_lt.SetDbValue(row["BL_lt"]);
            BL_mt.SetDbValue(row["BL_mt"]);
            AL_klobs.SetDbValue(row["AL_klobs"]);
            AL_kl15.SetDbValue(row["AL_kl15"]);
            AL_barrels.SetDbValue(row["AL_barrels"]);
            AL_lt.SetDbValue(row["AL_lt"]);
            AL_mt.SetDbValue(row["AL_mt"]);
            BD_klobs.SetDbValue(row["BD_klobs"]);
            BD_kl15.SetDbValue(row["BD_kl15"]);
            BD_barrels.SetDbValue(row["BD_barrels"]);
            BD_lt.SetDbValue(row["BD_lt"]);
            BD_mt.SetDbValue(row["BD_mt"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            idProses.SetDbValue(row["idProses"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            NoReferensi.SetDbValue(row["NoReferensi"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_klobs", BL_klobs.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_kl15", BL_kl15.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_barrels", BL_barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_lt", BL_lt.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_mt", BL_mt.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_klobs", AL_klobs.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_kl15", AL_kl15.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_barrels", AL_barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_lt", AL_lt.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_mt", AL_mt.DefaultValue ?? DbNullValue); // DN
            row.Add("BD_klobs", BD_klobs.DefaultValue ?? DbNullValue); // DN
            row.Add("BD_kl15", BD_kl15.DefaultValue ?? DbNullValue); // DN
            row.Add("BD_barrels", BD_barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("BD_lt", BD_lt.DefaultValue ?? DbNullValue); // DN
            row.Add("BD_mt", BD_mt.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
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

            // idAktifitas
            idAktifitas.RowCssClass = "row";

            // BL_klobs
            BL_klobs.RowCssClass = "row";

            // BL_kl15
            BL_kl15.RowCssClass = "row";

            // BL_barrels
            BL_barrels.RowCssClass = "row";

            // BL_lt
            BL_lt.RowCssClass = "row";

            // BL_mt
            BL_mt.RowCssClass = "row";

            // AL_klobs
            AL_klobs.RowCssClass = "row";

            // AL_kl15
            AL_kl15.RowCssClass = "row";

            // AL_barrels
            AL_barrels.RowCssClass = "row";

            // AL_lt
            AL_lt.RowCssClass = "row";

            // AL_mt
            AL_mt.RowCssClass = "row";

            // BD_klobs
            BD_klobs.RowCssClass = "row";

            // BD_kl15
            BD_kl15.RowCssClass = "row";

            // BD_barrels
            BD_barrels.RowCssClass = "row";

            // BD_lt
            BD_lt.RowCssClass = "row";

            // BD_mt
            BD_mt.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // idProses
            idProses.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.ViewValue = idAktifitas.CurrentValue;
                string curVal = ConvertToString(idAktifitas.CurrentValue);
                if (!Empty(curVal)) {
                    if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idAktifitas.ViewValue = idAktifitas.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk = idAktifitas.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                            var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk[0]);
                            idAktifitas.ViewValue = idAktifitas.DisplayValue(listwrk);
                        } else {
                            idAktifitas.ViewValue = FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
                        }
                    }
                } else {
                    idAktifitas.ViewValue = DbNullValue;
                }
                idAktifitas.ViewCustomAttributes = "";

                // BL_klobs
                BL_klobs.ViewValue = ConvertToString(BL_klobs.CurrentValue); // DN
                BL_klobs.ViewCustomAttributes = "";

                // BL_kl15
                BL_kl15.ViewValue = ConvertToString(BL_kl15.CurrentValue); // DN
                BL_kl15.ViewCustomAttributes = "";

                // BL_barrels
                BL_barrels.ViewValue = ConvertToString(BL_barrels.CurrentValue); // DN
                BL_barrels.ViewCustomAttributes = "";

                // BL_lt
                BL_lt.ViewValue = ConvertToString(BL_lt.CurrentValue); // DN
                BL_lt.ViewCustomAttributes = "";

                // BL_mt
                BL_mt.ViewValue = ConvertToString(BL_mt.CurrentValue); // DN
                BL_mt.ViewCustomAttributes = "";

                // AL_klobs
                AL_klobs.ViewValue = ConvertToString(AL_klobs.CurrentValue); // DN
                AL_klobs.ViewCustomAttributes = "";

                // AL_kl15
                AL_kl15.ViewValue = ConvertToString(AL_kl15.CurrentValue); // DN
                AL_kl15.ViewCustomAttributes = "";

                // AL_barrels
                AL_barrels.ViewValue = ConvertToString(AL_barrels.CurrentValue); // DN
                AL_barrels.ViewCustomAttributes = "";

                // AL_lt
                AL_lt.ViewValue = ConvertToString(AL_lt.CurrentValue); // DN
                AL_lt.ViewCustomAttributes = "";

                // AL_mt
                AL_mt.ViewValue = ConvertToString(AL_mt.CurrentValue); // DN
                AL_mt.ViewCustomAttributes = "";

                // BD_klobs
                BD_klobs.ViewValue = ConvertToString(BD_klobs.CurrentValue); // DN
                BD_klobs.ViewCustomAttributes = "";

                // BD_kl15
                BD_kl15.ViewValue = ConvertToString(BD_kl15.CurrentValue); // DN
                BD_kl15.ViewCustomAttributes = "";

                // BD_barrels
                BD_barrels.ViewValue = ConvertToString(BD_barrels.CurrentValue); // DN
                BD_barrels.ViewCustomAttributes = "";

                // BD_lt
                BD_lt.ViewValue = ConvertToString(BD_lt.CurrentValue); // DN
                BD_lt.ViewCustomAttributes = "";

                // BD_mt
                BD_mt.ViewValue = ConvertToString(BD_mt.CurrentValue); // DN
                BD_mt.ViewCustomAttributes = "";

                // userInput
                userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                userInput.ViewCustomAttributes = "";

                // etlDate
                etlDate.ViewValue = etlDate.CurrentValue;
                etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                etlDate.ViewCustomAttributes = "";

                // idProses
                idProses.ViewValue = idProses.CurrentValue;
                string curVal2 = ConvertToString(idProses.CurrentValue);
                if (!Empty(curVal2)) {
                    if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idProses.ViewValue = idProses.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk2 = idProses.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                            var listwrk = idProses.Lookup?.RenderViewRow(rswrk2[0]);
                            idProses.ViewValue = idProses.DisplayValue(listwrk);
                        } else {
                            idProses.ViewValue = FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
                        }
                    }
                } else {
                    idProses.ViewValue = DbNullValue;
                }
                idProses.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // lastUpdatedDate
                lastUpdatedDate.ViewValue = lastUpdatedDate.CurrentValue;
                lastUpdatedDate.ViewValue = FormatDateTime(lastUpdatedDate.ViewValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

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

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // BL_klobs
                BL_klobs.HrefValue = "";

                // BL_kl15
                BL_kl15.HrefValue = "";

                // BL_barrels
                BL_barrels.HrefValue = "";

                // BL_lt
                BL_lt.HrefValue = "";

                // BL_mt
                BL_mt.HrefValue = "";

                // AL_klobs
                AL_klobs.HrefValue = "";

                // AL_kl15
                AL_kl15.HrefValue = "";

                // AL_barrels
                AL_barrels.HrefValue = "";

                // AL_lt
                AL_lt.HrefValue = "";

                // AL_mt
                AL_mt.HrefValue = "";

                // BD_klobs
                BD_klobs.HrefValue = "";

                // BD_kl15
                BD_kl15.HrefValue = "";

                // BD_barrels
                BD_barrels.HrefValue = "";

                // BD_lt
                BD_lt.HrefValue = "";

                // BD_mt
                BD_mt.HrefValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";
            } else if (RowType == RowType.Edit) {
                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;
                string curVal = ConvertToString(idAktifitas.CurrentValue);
                if (!Empty(curVal)) {
                    if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idAktifitas.EditValue = idAktifitas.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk = idAktifitas.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                            var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk[0]);
                            idAktifitas.EditValue = idAktifitas.DisplayValue(listwrk);
                        } else {
                            idAktifitas.EditValue = FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
                        }
                    }
                } else {
                    idAktifitas.EditValue = DbNullValue;
                }
                idAktifitas.ViewCustomAttributes = "";

                // BL_klobs
                BL_klobs.SetupEditAttributes();
                if (!BL_klobs.Raw)
                    BL_klobs.CurrentValue = HtmlDecode(BL_klobs.CurrentValue);
                BL_klobs.EditValue = HtmlEncode(BL_klobs.CurrentValue);
                BL_klobs.PlaceHolder = RemoveHtml(BL_klobs.Caption);

                // BL_kl15
                BL_kl15.SetupEditAttributes();
                if (!BL_kl15.Raw)
                    BL_kl15.CurrentValue = HtmlDecode(BL_kl15.CurrentValue);
                BL_kl15.EditValue = HtmlEncode(BL_kl15.CurrentValue);
                BL_kl15.PlaceHolder = RemoveHtml(BL_kl15.Caption);

                // BL_barrels
                BL_barrels.SetupEditAttributes();
                if (!BL_barrels.Raw)
                    BL_barrels.CurrentValue = HtmlDecode(BL_barrels.CurrentValue);
                BL_barrels.EditValue = HtmlEncode(BL_barrels.CurrentValue);
                BL_barrels.PlaceHolder = RemoveHtml(BL_barrels.Caption);

                // BL_lt
                BL_lt.SetupEditAttributes();
                if (!BL_lt.Raw)
                    BL_lt.CurrentValue = HtmlDecode(BL_lt.CurrentValue);
                BL_lt.EditValue = HtmlEncode(BL_lt.CurrentValue);
                BL_lt.PlaceHolder = RemoveHtml(BL_lt.Caption);

                // BL_mt
                BL_mt.SetupEditAttributes();
                if (!BL_mt.Raw)
                    BL_mt.CurrentValue = HtmlDecode(BL_mt.CurrentValue);
                BL_mt.EditValue = HtmlEncode(BL_mt.CurrentValue);
                BL_mt.PlaceHolder = RemoveHtml(BL_mt.Caption);

                // AL_klobs
                AL_klobs.SetupEditAttributes();
                if (!AL_klobs.Raw)
                    AL_klobs.CurrentValue = HtmlDecode(AL_klobs.CurrentValue);
                AL_klobs.EditValue = HtmlEncode(AL_klobs.CurrentValue);
                AL_klobs.PlaceHolder = RemoveHtml(AL_klobs.Caption);

                // AL_kl15
                AL_kl15.SetupEditAttributes();
                if (!AL_kl15.Raw)
                    AL_kl15.CurrentValue = HtmlDecode(AL_kl15.CurrentValue);
                AL_kl15.EditValue = HtmlEncode(AL_kl15.CurrentValue);
                AL_kl15.PlaceHolder = RemoveHtml(AL_kl15.Caption);

                // AL_barrels
                AL_barrels.SetupEditAttributes();
                if (!AL_barrels.Raw)
                    AL_barrels.CurrentValue = HtmlDecode(AL_barrels.CurrentValue);
                AL_barrels.EditValue = HtmlEncode(AL_barrels.CurrentValue);
                AL_barrels.PlaceHolder = RemoveHtml(AL_barrels.Caption);

                // AL_lt
                AL_lt.SetupEditAttributes();
                if (!AL_lt.Raw)
                    AL_lt.CurrentValue = HtmlDecode(AL_lt.CurrentValue);
                AL_lt.EditValue = HtmlEncode(AL_lt.CurrentValue);
                AL_lt.PlaceHolder = RemoveHtml(AL_lt.Caption);

                // AL_mt
                AL_mt.SetupEditAttributes();
                if (!AL_mt.Raw)
                    AL_mt.CurrentValue = HtmlDecode(AL_mt.CurrentValue);
                AL_mt.EditValue = HtmlEncode(AL_mt.CurrentValue);
                AL_mt.PlaceHolder = RemoveHtml(AL_mt.Caption);

                // BD_klobs
                BD_klobs.SetupEditAttributes();
                if (!BD_klobs.Raw)
                    BD_klobs.CurrentValue = HtmlDecode(BD_klobs.CurrentValue);
                BD_klobs.EditValue = HtmlEncode(BD_klobs.CurrentValue);
                BD_klobs.PlaceHolder = RemoveHtml(BD_klobs.Caption);

                // BD_kl15
                BD_kl15.SetupEditAttributes();
                if (!BD_kl15.Raw)
                    BD_kl15.CurrentValue = HtmlDecode(BD_kl15.CurrentValue);
                BD_kl15.EditValue = HtmlEncode(BD_kl15.CurrentValue);
                BD_kl15.PlaceHolder = RemoveHtml(BD_kl15.Caption);

                // BD_barrels
                BD_barrels.SetupEditAttributes();
                if (!BD_barrels.Raw)
                    BD_barrels.CurrentValue = HtmlDecode(BD_barrels.CurrentValue);
                BD_barrels.EditValue = HtmlEncode(BD_barrels.CurrentValue);
                BD_barrels.PlaceHolder = RemoveHtml(BD_barrels.Caption);

                // BD_lt
                BD_lt.SetupEditAttributes();
                if (!BD_lt.Raw)
                    BD_lt.CurrentValue = HtmlDecode(BD_lt.CurrentValue);
                BD_lt.EditValue = HtmlEncode(BD_lt.CurrentValue);
                BD_lt.PlaceHolder = RemoveHtml(BD_lt.Caption);

                // BD_mt
                BD_mt.SetupEditAttributes();
                if (!BD_mt.Raw)
                    BD_mt.CurrentValue = HtmlDecode(BD_mt.CurrentValue);
                BD_mt.EditValue = HtmlEncode(BD_mt.CurrentValue);
                BD_mt.PlaceHolder = RemoveHtml(BD_mt.Caption);

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;
                string curVal2 = ConvertToString(idProses.CurrentValue);
                if (!Empty(curVal2)) {
                    if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idProses.EditValue = idProses.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk2 = idProses.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                            var listwrk = idProses.Lookup?.RenderViewRow(rswrk2[0]);
                            idProses.EditValue = idProses.DisplayValue(listwrk);
                        } else {
                            idProses.EditValue = FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
                        }
                    }
                } else {
                    idProses.EditValue = DbNullValue;
                }
                idProses.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                LastUpdatedBy.EditValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // lastUpdatedDate
                lastUpdatedDate.SetupEditAttributes();
                lastUpdatedDate.EditValue = lastUpdatedDate.CurrentValue;
                lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.EditValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                NoReferensi.EditValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

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

                // Edit refer script

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // BL_klobs
                BL_klobs.HrefValue = "";

                // BL_kl15
                BL_kl15.HrefValue = "";

                // BL_barrels
                BL_barrels.HrefValue = "";

                // BL_lt
                BL_lt.HrefValue = "";

                // BL_mt
                BL_mt.HrefValue = "";

                // AL_klobs
                AL_klobs.HrefValue = "";

                // AL_kl15
                AL_kl15.HrefValue = "";

                // AL_barrels
                AL_barrels.HrefValue = "";

                // AL_lt
                AL_lt.HrefValue = "";

                // AL_mt
                AL_mt.HrefValue = "";

                // BD_klobs
                BD_klobs.HrefValue = "";

                // BD_kl15
                BD_kl15.HrefValue = "";

                // BD_barrels
                BD_barrels.HrefValue = "";

                // BD_lt
                BD_lt.HrefValue = "";

                // BD_mt
                BD_mt.HrefValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";
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
                if (idAktifitas.Visible && idAktifitas.Required) {
                    if (!idAktifitas.IsDetailKey && Empty(idAktifitas.FormValue)) {
                        idAktifitas.AddErrorMessage(ConvertToString(idAktifitas.RequiredErrorMessage).Replace("%s", idAktifitas.Caption));
                    }
                }
                if (BL_klobs.Visible && BL_klobs.Required) {
                    if (!BL_klobs.IsDetailKey && Empty(BL_klobs.FormValue)) {
                        BL_klobs.AddErrorMessage(ConvertToString(BL_klobs.RequiredErrorMessage).Replace("%s", BL_klobs.Caption));
                    }
                }
                if (BL_kl15.Visible && BL_kl15.Required) {
                    if (!BL_kl15.IsDetailKey && Empty(BL_kl15.FormValue)) {
                        BL_kl15.AddErrorMessage(ConvertToString(BL_kl15.RequiredErrorMessage).Replace("%s", BL_kl15.Caption));
                    }
                }
                if (BL_barrels.Visible && BL_barrels.Required) {
                    if (!BL_barrels.IsDetailKey && Empty(BL_barrels.FormValue)) {
                        BL_barrels.AddErrorMessage(ConvertToString(BL_barrels.RequiredErrorMessage).Replace("%s", BL_barrels.Caption));
                    }
                }
                if (BL_lt.Visible && BL_lt.Required) {
                    if (!BL_lt.IsDetailKey && Empty(BL_lt.FormValue)) {
                        BL_lt.AddErrorMessage(ConvertToString(BL_lt.RequiredErrorMessage).Replace("%s", BL_lt.Caption));
                    }
                }
                if (BL_mt.Visible && BL_mt.Required) {
                    if (!BL_mt.IsDetailKey && Empty(BL_mt.FormValue)) {
                        BL_mt.AddErrorMessage(ConvertToString(BL_mt.RequiredErrorMessage).Replace("%s", BL_mt.Caption));
                    }
                }
                if (AL_klobs.Visible && AL_klobs.Required) {
                    if (!AL_klobs.IsDetailKey && Empty(AL_klobs.FormValue)) {
                        AL_klobs.AddErrorMessage(ConvertToString(AL_klobs.RequiredErrorMessage).Replace("%s", AL_klobs.Caption));
                    }
                }
                if (AL_kl15.Visible && AL_kl15.Required) {
                    if (!AL_kl15.IsDetailKey && Empty(AL_kl15.FormValue)) {
                        AL_kl15.AddErrorMessage(ConvertToString(AL_kl15.RequiredErrorMessage).Replace("%s", AL_kl15.Caption));
                    }
                }
                if (AL_barrels.Visible && AL_barrels.Required) {
                    if (!AL_barrels.IsDetailKey && Empty(AL_barrels.FormValue)) {
                        AL_barrels.AddErrorMessage(ConvertToString(AL_barrels.RequiredErrorMessage).Replace("%s", AL_barrels.Caption));
                    }
                }
                if (AL_lt.Visible && AL_lt.Required) {
                    if (!AL_lt.IsDetailKey && Empty(AL_lt.FormValue)) {
                        AL_lt.AddErrorMessage(ConvertToString(AL_lt.RequiredErrorMessage).Replace("%s", AL_lt.Caption));
                    }
                }
                if (AL_mt.Visible && AL_mt.Required) {
                    if (!AL_mt.IsDetailKey && Empty(AL_mt.FormValue)) {
                        AL_mt.AddErrorMessage(ConvertToString(AL_mt.RequiredErrorMessage).Replace("%s", AL_mt.Caption));
                    }
                }
                if (BD_klobs.Visible && BD_klobs.Required) {
                    if (!BD_klobs.IsDetailKey && Empty(BD_klobs.FormValue)) {
                        BD_klobs.AddErrorMessage(ConvertToString(BD_klobs.RequiredErrorMessage).Replace("%s", BD_klobs.Caption));
                    }
                }
                if (BD_kl15.Visible && BD_kl15.Required) {
                    if (!BD_kl15.IsDetailKey && Empty(BD_kl15.FormValue)) {
                        BD_kl15.AddErrorMessage(ConvertToString(BD_kl15.RequiredErrorMessage).Replace("%s", BD_kl15.Caption));
                    }
                }
                if (BD_barrels.Visible && BD_barrels.Required) {
                    if (!BD_barrels.IsDetailKey && Empty(BD_barrels.FormValue)) {
                        BD_barrels.AddErrorMessage(ConvertToString(BD_barrels.RequiredErrorMessage).Replace("%s", BD_barrels.Caption));
                    }
                }
                if (BD_lt.Visible && BD_lt.Required) {
                    if (!BD_lt.IsDetailKey && Empty(BD_lt.FormValue)) {
                        BD_lt.AddErrorMessage(ConvertToString(BD_lt.RequiredErrorMessage).Replace("%s", BD_lt.Caption));
                    }
                }
                if (BD_mt.Visible && BD_mt.Required) {
                    if (!BD_mt.IsDetailKey && Empty(BD_mt.FormValue)) {
                        BD_mt.AddErrorMessage(ConvertToString(BD_mt.RequiredErrorMessage).Replace("%s", BD_mt.Caption));
                    }
                }
                if (idProses.Visible && idProses.Required) {
                    if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                        idProses.AddErrorMessage(ConvertToString(idProses.RequiredErrorMessage).Replace("%s", idProses.Caption));
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
                if (NoReferensi.Visible && NoReferensi.Required) {
                    if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                        NoReferensi.AddErrorMessage(ConvertToString(NoReferensi.RequiredErrorMessage).Replace("%s", NoReferensi.Caption));
                    }
                }
                if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                    if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                        StatusAktivitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
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

            // BL_klobs
            BL_klobs.SetDbValue(rsnew, BL_klobs.CurrentValue, BL_klobs.ReadOnly);

            // BL_kl15
            BL_kl15.SetDbValue(rsnew, BL_kl15.CurrentValue, BL_kl15.ReadOnly);

            // BL_barrels
            BL_barrels.SetDbValue(rsnew, BL_barrels.CurrentValue, BL_barrels.ReadOnly);

            // BL_lt
            BL_lt.SetDbValue(rsnew, BL_lt.CurrentValue, BL_lt.ReadOnly);

            // BL_mt
            BL_mt.SetDbValue(rsnew, BL_mt.CurrentValue, BL_mt.ReadOnly);

            // AL_klobs
            AL_klobs.SetDbValue(rsnew, AL_klobs.CurrentValue, AL_klobs.ReadOnly);

            // AL_kl15
            AL_kl15.SetDbValue(rsnew, AL_kl15.CurrentValue, AL_kl15.ReadOnly);

            // AL_barrels
            AL_barrels.SetDbValue(rsnew, AL_barrels.CurrentValue, AL_barrels.ReadOnly);

            // AL_lt
            AL_lt.SetDbValue(rsnew, AL_lt.CurrentValue, AL_lt.ReadOnly);

            // AL_mt
            AL_mt.SetDbValue(rsnew, AL_mt.CurrentValue, AL_mt.ReadOnly);

            // BD_klobs
            BD_klobs.SetDbValue(rsnew, BD_klobs.CurrentValue, BD_klobs.ReadOnly);

            // BD_kl15
            BD_kl15.SetDbValue(rsnew, BD_kl15.CurrentValue, BD_kl15.ReadOnly);

            // BD_barrels
            BD_barrels.SetDbValue(rsnew, BD_barrels.CurrentValue, BD_barrels.ReadOnly);

            // BD_lt
            BD_lt.SetDbValue(rsnew, BD_lt.CurrentValue, BD_lt.ReadOnly);

            // BD_mt
            BD_mt.SetDbValue(rsnew, BD_mt.CurrentValue, BD_mt.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("BL_klobs", out value)) // BL_klobs
                BL_klobs.CurrentValue = value;
            if (row.TryGetValue("BL_kl15", out value)) // BL_kl15
                BL_kl15.CurrentValue = value;
            if (row.TryGetValue("BL_barrels", out value)) // BL_barrels
                BL_barrels.CurrentValue = value;
            if (row.TryGetValue("BL_lt", out value)) // BL_lt
                BL_lt.CurrentValue = value;
            if (row.TryGetValue("BL_mt", out value)) // BL_mt
                BL_mt.CurrentValue = value;
            if (row.TryGetValue("AL_klobs", out value)) // AL_klobs
                AL_klobs.CurrentValue = value;
            if (row.TryGetValue("AL_kl15", out value)) // AL_kl15
                AL_kl15.CurrentValue = value;
            if (row.TryGetValue("AL_barrels", out value)) // AL_barrels
                AL_barrels.CurrentValue = value;
            if (row.TryGetValue("AL_lt", out value)) // AL_lt
                AL_lt.CurrentValue = value;
            if (row.TryGetValue("AL_mt", out value)) // AL_mt
                AL_mt.CurrentValue = value;
            if (row.TryGetValue("BD_klobs", out value)) // BD_klobs
                BD_klobs.CurrentValue = value;
            if (row.TryGetValue("BD_kl15", out value)) // BD_kl15
                BD_kl15.CurrentValue = value;
            if (row.TryGetValue("BD_barrels", out value)) // BD_barrels
                BD_barrels.CurrentValue = value;
            if (row.TryGetValue("BD_lt", out value)) // BD_lt
                BD_lt.CurrentValue = value;
            if (row.TryGetValue("BD_mt", out value)) // BD_mt
                BD_mt.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubaktivitasNilaiBlalbdPipaList")), "", TableVar, true);
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
