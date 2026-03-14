namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// vAktifitasSandarEdit
    /// </summary>
    public static VAktifitasSandarEdit vAktifitasSandarEdit
    {
        get => HttpData.Get<VAktifitasSandarEdit>("vAktifitasSandarEdit")!;
        set => HttpData["vAktifitasSandarEdit"] = value;
    }

    /// <summary>
    /// Page class for v_aktifitas_sandar
    /// </summary>
    public class VAktifitasSandarEdit : VAktifitasSandarEditBase
    {
        // Constructor
        public VAktifitasSandarEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VAktifitasSandarEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VAktifitasSandarEditBase : VAktifitasSandar
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "vAktifitasSandarEdit";

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
        public VAktifitasSandarEditBase()
        {
            TableName = "v_aktifitas_sandar";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (vAktifitasSandar)
            if (vAktifitasSandar == null || vAktifitasSandar is VAktifitasSandar)
                vAktifitasSandar = this;

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
        public string PageName => "VAktifitasSandarEdit";

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
            IdAktivitas.Visible = false;
            NamaAktivitas.SetVisibility();
            Nama_Proses.SetVisibility();
            No_referensi.SetVisibility();
            Produk.SetVisibility();
            StatusAktivitas.SetVisibility();
            Shipment.SetVisibility();
            sandar_nama_kapal.SetVisibility();
            sandar_tgl_tiba.SetVisibility();
            sandar_nominasi.SetVisibility();
            IdProses.SetVisibility();
        }

        // Constructor
        public VAktifitasSandarEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "VAktifitasSandarView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdAktivitas") ? dict["IdAktivitas"] : IdAktivitas.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdAktivitas.Visible = false;
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
            await SetupLookupOptions(IdAktivitas);

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
                if (RouteValues.TryGetValue("IdAktivitas", out rv)) { // DN
                    IdAktivitas.FormValue = UrlDecode(rv); // DN
                    IdAktivitas.OldValue = IdAktivitas.FormValue;
                } else if (CurrentForm.HasValue("x_IdAktivitas")) {
                    IdAktivitas.FormValue = CurrentForm.GetValue("x_IdAktivitas");
                    IdAktivitas.OldValue = IdAktivitas.FormValue;
                } else if (!Empty(keyValues)) {
                    IdAktivitas.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("IdAktivitas", out rv)) { // DN
                        IdAktivitas.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("IdAktivitas", out sv)) {
                        IdAktivitas.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdAktivitas.CurrentValue = DbNullValue;
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
                IdAktivitas.FormValue = ConvertToString(keyValues[0]);
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
                            return Terminate("VAktifitasSandarList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "VAktifitasSandarList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "VAktifitasSandarList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "VAktifitasSandarList"; // Return list page content
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
                vAktifitasSandarEdit?.PageRender();
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

            // Check field name 'NamaAktivitas' before field var 'x_NamaAktivitas'
            val = CurrentForm.HasValue("NamaAktivitas") ? CurrentForm.GetValue("NamaAktivitas") : CurrentForm.GetValue("x_NamaAktivitas");
            if (!NamaAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaAktivitas") && !CurrentForm.HasValue("x_NamaAktivitas")) // DN
                    NamaAktivitas.Visible = false; // Disable update for API request
                else
                    NamaAktivitas.SetFormValue(val);
            }

            // Check field name 'Nama_Proses' before field var 'x_Nama_Proses'
            val = CurrentForm.HasValue("Nama_Proses") ? CurrentForm.GetValue("Nama_Proses") : CurrentForm.GetValue("x_Nama_Proses");
            if (!Nama_Proses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Nama_Proses") && !CurrentForm.HasValue("x_Nama_Proses")) // DN
                    Nama_Proses.Visible = false; // Disable update for API request
                else
                    Nama_Proses.SetFormValue(val);
            }

            // Check field name 'No_referensi' before field var 'x_No_referensi'
            val = CurrentForm.HasValue("No_referensi") ? CurrentForm.GetValue("No_referensi") : CurrentForm.GetValue("x_No_referensi");
            if (!No_referensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("No_referensi") && !CurrentForm.HasValue("x_No_referensi")) // DN
                    No_referensi.Visible = false; // Disable update for API request
                else
                    No_referensi.SetFormValue(val);
            }

            // Check field name 'Produk' before field var 'x_Produk'
            val = CurrentForm.HasValue("Produk") ? CurrentForm.GetValue("Produk") : CurrentForm.GetValue("x_Produk");
            if (!Produk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Produk") && !CurrentForm.HasValue("x_Produk")) // DN
                    Produk.Visible = false; // Disable update for API request
                else
                    Produk.SetFormValue(val);
            }

            // Check field name 'StatusAktivitas' before field var 'x_StatusAktivitas'
            val = CurrentForm.HasValue("StatusAktivitas") ? CurrentForm.GetValue("StatusAktivitas") : CurrentForm.GetValue("x_StatusAktivitas");
            if (!StatusAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusAktivitas") && !CurrentForm.HasValue("x_StatusAktivitas")) // DN
                    StatusAktivitas.Visible = false; // Disable update for API request
                else
                    StatusAktivitas.SetFormValue(val);
            }

            // Check field name 'Shipment' before field var 'x_Shipment'
            val = CurrentForm.HasValue("Shipment") ? CurrentForm.GetValue("Shipment") : CurrentForm.GetValue("x_Shipment");
            if (!Shipment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Shipment") && !CurrentForm.HasValue("x_Shipment")) // DN
                    Shipment.Visible = false; // Disable update for API request
                else
                    Shipment.SetFormValue(val);
            }

            // Check field name 'sandar_nama_kapal' before field var 'x_sandar_nama_kapal'
            val = CurrentForm.HasValue("sandar_nama_kapal") ? CurrentForm.GetValue("sandar_nama_kapal") : CurrentForm.GetValue("x_sandar_nama_kapal");
            if (!sandar_nama_kapal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("sandar_nama_kapal") && !CurrentForm.HasValue("x_sandar_nama_kapal")) // DN
                    sandar_nama_kapal.Visible = false; // Disable update for API request
                else
                    sandar_nama_kapal.SetFormValue(val);
            }

            // Check field name 'sandar_tgl_tiba' before field var 'x_sandar_tgl_tiba'
            val = CurrentForm.HasValue("sandar_tgl_tiba") ? CurrentForm.GetValue("sandar_tgl_tiba") : CurrentForm.GetValue("x_sandar_tgl_tiba");
            if (!sandar_tgl_tiba.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("sandar_tgl_tiba") && !CurrentForm.HasValue("x_sandar_tgl_tiba")) // DN
                    sandar_tgl_tiba.Visible = false; // Disable update for API request
                else
                    sandar_tgl_tiba.SetFormValue(val, true, validate);
                sandar_tgl_tiba.CurrentValue = UnformatDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern);
            }

            // Check field name 'sandar_nominasi' before field var 'x_sandar_nominasi'
            val = CurrentForm.HasValue("sandar_nominasi") ? CurrentForm.GetValue("sandar_nominasi") : CurrentForm.GetValue("x_sandar_nominasi");
            if (!sandar_nominasi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("sandar_nominasi") && !CurrentForm.HasValue("x_sandar_nominasi")) // DN
                    sandar_nominasi.Visible = false; // Disable update for API request
                else
                    sandar_nominasi.SetFormValue(val);
            }

            // Check field name 'IdProses' before field var 'x_IdProses'
            val = CurrentForm.HasValue("IdProses") ? CurrentForm.GetValue("IdProses") : CurrentForm.GetValue("x_IdProses");
            if (!IdProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdProses") && !CurrentForm.HasValue("x_IdProses")) // DN
                    IdProses.Visible = false; // Disable update for API request
                else
                    IdProses.SetFormValue(val);
            }

            // Check field name 'IdAktivitas' before field var 'x_IdAktivitas'
            val = CurrentForm.HasValue("IdAktivitas") ? CurrentForm.GetValue("IdAktivitas") : CurrentForm.GetValue("x_IdAktivitas");
            if (!IdAktivitas.IsDetailKey)
                IdAktivitas.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdAktivitas.CurrentValue = IdAktivitas.FormValue;
            NamaAktivitas.CurrentValue = NamaAktivitas.FormValue;
            Nama_Proses.CurrentValue = Nama_Proses.FormValue;
            No_referensi.CurrentValue = No_referensi.FormValue;
            Produk.CurrentValue = Produk.FormValue;
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
            Shipment.CurrentValue = Shipment.FormValue;
            sandar_nama_kapal.CurrentValue = sandar_nama_kapal.FormValue;
            sandar_tgl_tiba.CurrentValue = sandar_tgl_tiba.FormValue;
            sandar_tgl_tiba.CurrentValue = UnformatDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern);
            sandar_nominasi.CurrentValue = sandar_nominasi.FormValue;
            IdProses.CurrentValue = IdProses.FormValue;
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
            IdAktivitas.SetDbValue(row["IdAktivitas"]);
            NamaAktivitas.SetDbValue(row["NamaAktivitas"]);
            Nama_Proses.SetDbValue(row["Nama_Proses"]);
            No_referensi.SetDbValue(row["No_referensi"]);
            Produk.SetDbValue(row["Produk"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
            Shipment.SetDbValue(row["Shipment"]);
            sandar_nama_kapal.SetDbValue(row["sandar_nama_kapal"]);
            sandar_tgl_tiba.SetDbValue(row["sandar_tgl_tiba"]);
            sandar_nominasi.SetDbValue(row["sandar_nominasi"]);
            IdProses.SetDbValue(row["IdProses"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdAktivitas", IdAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaAktivitas", NamaAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama_Proses", Nama_Proses.DefaultValue ?? DbNullValue); // DN
            row.Add("No_referensi", No_referensi.DefaultValue ?? DbNullValue); // DN
            row.Add("Produk", Produk.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("Shipment", Shipment.DefaultValue ?? DbNullValue); // DN
            row.Add("sandar_nama_kapal", sandar_nama_kapal.DefaultValue ?? DbNullValue); // DN
            row.Add("sandar_tgl_tiba", sandar_tgl_tiba.DefaultValue ?? DbNullValue); // DN
            row.Add("sandar_nominasi", sandar_nominasi.DefaultValue ?? DbNullValue); // DN
            row.Add("IdProses", IdProses.DefaultValue ?? DbNullValue); // DN
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

            // IdAktivitas
            IdAktivitas.RowCssClass = "row";

            // NamaAktivitas
            NamaAktivitas.RowCssClass = "row";

            // Nama_Proses
            Nama_Proses.RowCssClass = "row";

            // No_referensi
            No_referensi.RowCssClass = "row";

            // Produk
            Produk.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // Shipment
            Shipment.RowCssClass = "row";

            // sandar_nama_kapal
            sandar_nama_kapal.RowCssClass = "row";

            // sandar_tgl_tiba
            sandar_tgl_tiba.RowCssClass = "row";

            // sandar_nominasi
            sandar_nominasi.RowCssClass = "row";

            // IdProses
            IdProses.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdAktivitas
                IdAktivitas.ViewValue = IdAktivitas.CurrentValue;
                string curVal = ConvertToString(IdAktivitas.CurrentValue);
                if (!Empty(curVal)) {
                    if (IdAktivitas.Lookup != null && IsDictionary(IdAktivitas.Lookup?.Options) && IdAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdAktivitas.ViewValue = IdAktivitas.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", IdAktivitas.CurrentValue, IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk = IdAktivitas.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdAktivitas.Lookup != null) { // Lookup values found
                            var listwrk = IdAktivitas.Lookup?.RenderViewRow(rswrk[0]);
                            IdAktivitas.ViewValue = IdAktivitas.DisplayValue(listwrk);
                        } else {
                            IdAktivitas.ViewValue = FormatNumber(IdAktivitas.CurrentValue, IdAktivitas.FormatPattern);
                        }
                    }
                } else {
                    IdAktivitas.ViewValue = DbNullValue;
                }
                IdAktivitas.ViewCustomAttributes = "";

                // NamaAktivitas
                NamaAktivitas.ViewValue = ConvertToString(NamaAktivitas.CurrentValue); // DN
                NamaAktivitas.ViewCustomAttributes = "";

                // Nama_Proses
                Nama_Proses.ViewValue = ConvertToString(Nama_Proses.CurrentValue); // DN
                Nama_Proses.ViewCustomAttributes = "";

                // No_referensi
                No_referensi.ViewValue = ConvertToString(No_referensi.CurrentValue); // DN
                No_referensi.ViewCustomAttributes = "";

                // Produk
                Produk.ViewValue = ConvertToString(Produk.CurrentValue); // DN
                Produk.ViewCustomAttributes = "";

                // StatusAktivitas
                StatusAktivitas.ViewValue = ConvertToString(StatusAktivitas.CurrentValue); // DN
                StatusAktivitas.ViewCustomAttributes = "";

                // Shipment
                Shipment.ViewValue = ConvertToString(Shipment.CurrentValue); // DN
                Shipment.ViewCustomAttributes = "";

                // sandar_nama_kapal
                sandar_nama_kapal.ViewValue = ConvertToString(sandar_nama_kapal.CurrentValue); // DN
                sandar_nama_kapal.ViewCustomAttributes = "";

                // sandar_tgl_tiba
                sandar_tgl_tiba.ViewValue = sandar_tgl_tiba.CurrentValue;
                sandar_tgl_tiba.ViewValue = FormatDateTime(sandar_tgl_tiba.ViewValue, sandar_tgl_tiba.FormatPattern);
                sandar_tgl_tiba.ViewCustomAttributes = "";

                // sandar_nominasi
                sandar_nominasi.ViewValue = ConvertToString(sandar_nominasi.CurrentValue); // DN
                sandar_nominasi.ViewCustomAttributes = "";

                // IdProses
                IdProses.ViewValue = IdProses.CurrentValue;
                IdProses.ViewValue = FormatNumber(IdProses.ViewValue, IdProses.FormatPattern);
                IdProses.ViewCustomAttributes = "";

                // NamaAktivitas
                NamaAktivitas.HrefValue = "";
                NamaAktivitas.TooltipValue = "";

                // Nama_Proses
                Nama_Proses.HrefValue = "";
                Nama_Proses.TooltipValue = "";

                // No_referensi
                No_referensi.HrefValue = "";
                No_referensi.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";
                Produk.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // Shipment
                Shipment.HrefValue = "";
                Shipment.TooltipValue = "";

                // sandar_nama_kapal
                sandar_nama_kapal.HrefValue = "";

                // sandar_tgl_tiba
                sandar_tgl_tiba.HrefValue = "";

                // sandar_nominasi
                sandar_nominasi.HrefValue = "";

                // IdProses
                IdProses.HrefValue = "";
                IdProses.TooltipValue = "";
            } else if (RowType == RowType.Edit) {
                // NamaAktivitas
                NamaAktivitas.SetupEditAttributes();
                NamaAktivitas.EditValue = ConvertToString(NamaAktivitas.CurrentValue); // DN
                NamaAktivitas.ViewCustomAttributes = "";

                // Nama_Proses
                Nama_Proses.SetupEditAttributes();
                Nama_Proses.EditValue = ConvertToString(Nama_Proses.CurrentValue); // DN
                Nama_Proses.ViewCustomAttributes = "";

                // No_referensi
                No_referensi.SetupEditAttributes();
                No_referensi.EditValue = ConvertToString(No_referensi.CurrentValue); // DN
                No_referensi.ViewCustomAttributes = "";

                // Produk
                Produk.SetupEditAttributes();
                Produk.EditValue = ConvertToString(Produk.CurrentValue); // DN
                Produk.ViewCustomAttributes = "";

                // StatusAktivitas
                StatusAktivitas.SetupEditAttributes();
                StatusAktivitas.EditValue = ConvertToString(StatusAktivitas.CurrentValue); // DN
                StatusAktivitas.ViewCustomAttributes = "";

                // Shipment
                Shipment.SetupEditAttributes();
                Shipment.EditValue = ConvertToString(Shipment.CurrentValue); // DN
                Shipment.ViewCustomAttributes = "";

                // sandar_nama_kapal
                sandar_nama_kapal.SetupEditAttributes();
                if (!sandar_nama_kapal.Raw)
                    sandar_nama_kapal.CurrentValue = HtmlDecode(sandar_nama_kapal.CurrentValue);
                sandar_nama_kapal.EditValue = HtmlEncode(sandar_nama_kapal.CurrentValue);
                sandar_nama_kapal.PlaceHolder = RemoveHtml(sandar_nama_kapal.Caption);

                // sandar_tgl_tiba
                sandar_tgl_tiba.SetupEditAttributes();
                sandar_tgl_tiba.EditValue = FormatDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern);
                sandar_tgl_tiba.PlaceHolder = RemoveHtml(sandar_tgl_tiba.Caption);

                // sandar_nominasi
                sandar_nominasi.SetupEditAttributes();
                if (!sandar_nominasi.Raw)
                    sandar_nominasi.CurrentValue = HtmlDecode(sandar_nominasi.CurrentValue);
                sandar_nominasi.EditValue = HtmlEncode(sandar_nominasi.CurrentValue);
                sandar_nominasi.PlaceHolder = RemoveHtml(sandar_nominasi.Caption);

                // IdProses
                IdProses.SetupEditAttributes();
                IdProses.EditValue = IdProses.CurrentValue;
                IdProses.EditValue = FormatNumber(IdProses.EditValue, IdProses.FormatPattern);
                IdProses.ViewCustomAttributes = "";

                // Edit refer script

                // NamaAktivitas
                NamaAktivitas.HrefValue = "";
                NamaAktivitas.TooltipValue = "";

                // Nama_Proses
                Nama_Proses.HrefValue = "";
                Nama_Proses.TooltipValue = "";

                // No_referensi
                No_referensi.HrefValue = "";
                No_referensi.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";
                Produk.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // Shipment
                Shipment.HrefValue = "";
                Shipment.TooltipValue = "";

                // sandar_nama_kapal
                sandar_nama_kapal.HrefValue = "";

                // sandar_tgl_tiba
                sandar_tgl_tiba.HrefValue = "";

                // sandar_nominasi
                sandar_nominasi.HrefValue = "";

                // IdProses
                IdProses.HrefValue = "";
                IdProses.TooltipValue = "";
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
                if (NamaAktivitas.Visible && NamaAktivitas.Required) {
                    if (!NamaAktivitas.IsDetailKey && Empty(NamaAktivitas.FormValue)) {
                        NamaAktivitas.AddErrorMessage(ConvertToString(NamaAktivitas.RequiredErrorMessage).Replace("%s", NamaAktivitas.Caption));
                    }
                }
                if (Nama_Proses.Visible && Nama_Proses.Required) {
                    if (!Nama_Proses.IsDetailKey && Empty(Nama_Proses.FormValue)) {
                        Nama_Proses.AddErrorMessage(ConvertToString(Nama_Proses.RequiredErrorMessage).Replace("%s", Nama_Proses.Caption));
                    }
                }
                if (No_referensi.Visible && No_referensi.Required) {
                    if (!No_referensi.IsDetailKey && Empty(No_referensi.FormValue)) {
                        No_referensi.AddErrorMessage(ConvertToString(No_referensi.RequiredErrorMessage).Replace("%s", No_referensi.Caption));
                    }
                }
                if (Produk.Visible && Produk.Required) {
                    if (!Produk.IsDetailKey && Empty(Produk.FormValue)) {
                        Produk.AddErrorMessage(ConvertToString(Produk.RequiredErrorMessage).Replace("%s", Produk.Caption));
                    }
                }
                if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                    if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                        StatusAktivitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                    }
                }
                if (Shipment.Visible && Shipment.Required) {
                    if (!Shipment.IsDetailKey && Empty(Shipment.FormValue)) {
                        Shipment.AddErrorMessage(ConvertToString(Shipment.RequiredErrorMessage).Replace("%s", Shipment.Caption));
                    }
                }
                if (sandar_nama_kapal.Visible && sandar_nama_kapal.Required) {
                    if (!sandar_nama_kapal.IsDetailKey && Empty(sandar_nama_kapal.FormValue)) {
                        sandar_nama_kapal.AddErrorMessage(ConvertToString(sandar_nama_kapal.RequiredErrorMessage).Replace("%s", sandar_nama_kapal.Caption));
                    }
                }
                if (sandar_tgl_tiba.Visible && sandar_tgl_tiba.Required) {
                    if (!sandar_tgl_tiba.IsDetailKey && Empty(sandar_tgl_tiba.FormValue)) {
                        sandar_tgl_tiba.AddErrorMessage(ConvertToString(sandar_tgl_tiba.RequiredErrorMessage).Replace("%s", sandar_tgl_tiba.Caption));
                    }
                }
                if (!CheckDate(sandar_tgl_tiba.FormValue, sandar_tgl_tiba.FormatPattern)) {
                    sandar_tgl_tiba.AddErrorMessage(sandar_tgl_tiba.GetErrorMessage(false));
                }
                if (sandar_nominasi.Visible && sandar_nominasi.Required) {
                    if (!sandar_nominasi.IsDetailKey && Empty(sandar_nominasi.FormValue)) {
                        sandar_nominasi.AddErrorMessage(ConvertToString(sandar_nominasi.RequiredErrorMessage).Replace("%s", sandar_nominasi.Caption));
                    }
                }
                if (IdProses.Visible && IdProses.Required) {
                    if (!IdProses.IsDetailKey && Empty(IdProses.FormValue)) {
                        IdProses.AddErrorMessage(ConvertToString(IdProses.RequiredErrorMessage).Replace("%s", IdProses.Caption));
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

            // sandar_nama_kapal
            sandar_nama_kapal.SetDbValue(rsnew, sandar_nama_kapal.CurrentValue, sandar_nama_kapal.ReadOnly);

            // sandar_tgl_tiba
            sandar_tgl_tiba.SetDbValue(rsnew, ConvertToDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern), sandar_tgl_tiba.ReadOnly);

            // sandar_nominasi
            sandar_nominasi.SetDbValue(rsnew, sandar_nominasi.CurrentValue, sandar_nominasi.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("sandar_nama_kapal", out value)) // sandar_nama_kapal
                sandar_nama_kapal.CurrentValue = value;
            if (row.TryGetValue("sandar_tgl_tiba", out value)) // sandar_tgl_tiba
                sandar_tgl_tiba.CurrentValue = value;
            if (row.TryGetValue("sandar_nominasi", out value)) // sandar_nominasi
                sandar_nominasi.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("VAktifitasSandarList")), "", TableVar, true);
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
