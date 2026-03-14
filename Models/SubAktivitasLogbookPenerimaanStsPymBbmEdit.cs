namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasLogbookPenerimaanStsPymBbmEdit
    /// </summary>
    public static SubAktivitasLogbookPenerimaanStsPymBbmEdit subAktivitasLogbookPenerimaanStsPymBbmEdit
    {
        get => HttpData.Get<SubAktivitasLogbookPenerimaanStsPymBbmEdit>("subAktivitasLogbookPenerimaanStsPymBbmEdit")!;
        set => HttpData["subAktivitasLogbookPenerimaanStsPymBbmEdit"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasLogbookPenerimaanSTSPymBBM
    /// </summary>
    public class SubAktivitasLogbookPenerimaanStsPymBbmEdit : SubAktivitasLogbookPenerimaanStsPymBbmEditBase
    {
        // Constructor
        public SubAktivitasLogbookPenerimaanStsPymBbmEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasLogbookPenerimaanStsPymBbmEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasLogbookPenerimaanStsPymBbmEditBase : SubAktivitasLogbookPenerimaanStsPymBbm
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasLogbookPenerimaanStsPymBbmEdit";

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
        public SubAktivitasLogbookPenerimaanStsPymBbmEditBase()
        {
            TableName = "SubAktivitasLogbookPenerimaanSTSPymBBM";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasLogbookPenerimaanStsPymBbm)
            if (subAktivitasLogbookPenerimaanStsPymBbm == null || subAktivitasLogbookPenerimaanStsPymBbm is SubAktivitasLogbookPenerimaanStsPymBbm)
                subAktivitasLogbookPenerimaanStsPymBbm = this;

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
        public string PageName => "SubAktivitasLogbookPenerimaanStsPymBbmEdit";

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
            id.SetVisibility();
            idProses.SetVisibility();
            idAktifitas.SetVisibility();
            NoReferensi.SetVisibility();
            Nama_Kapal.SetVisibility();
            TanggalJam.SetVisibility();
            Nama_Kegiatan.SetVisibility();
            Produk.SetVisibility();
            Density.SetVisibility();
            Temperatur.SetVisibility();
            Level.SetVisibility();
            Volume.SetVisibility();
            Flowrate.SetVisibility();
            Keterangan.SetVisibility();
            userInput.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            SubAktivitasHasilPemeriksaanId.SetVisibility();
            TanggalJamSOP.SetVisibility();
            SelisihWaktu.SetVisibility();
            IsQualityActive.SetVisibility();
        }

        // Constructor
        public SubAktivitasLogbookPenerimaanStsPymBbmEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "SubAktivitasLogbookPenerimaanStsPymBbmView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(IsQualityActive);

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
                            return Terminate("SubAktivitasLogbookPenerimaanStsPymBbmList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "SubAktivitasLogbookPenerimaanStsPymBbmList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SubAktivitasLogbookPenerimaanStsPymBbmList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SubAktivitasLogbookPenerimaanStsPymBbmList"; // Return list page content
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
                subAktivitasLogbookPenerimaanStsPymBbmEdit?.PageRender();
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

            // Check field name 'id' before field var 'x_id'
            val = CurrentForm.HasValue("id") ? CurrentForm.GetValue("id") : CurrentForm.GetValue("x_id");
            if (!id.IsDetailKey)
                id.SetFormValue(val);

            // Check field name 'idProses' before field var 'x_idProses'
            val = CurrentForm.HasValue("idProses") ? CurrentForm.GetValue("idProses") : CurrentForm.GetValue("x_idProses");
            if (!idProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idProses") && !CurrentForm.HasValue("x_idProses")) // DN
                    idProses.Visible = false; // Disable update for API request
                else
                    idProses.SetFormValue(val, true, validate);
            }

            // Check field name 'idAktifitas' before field var 'x_idAktifitas'
            val = CurrentForm.HasValue("idAktifitas") ? CurrentForm.GetValue("idAktifitas") : CurrentForm.GetValue("x_idAktifitas");
            if (!idAktifitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idAktifitas") && !CurrentForm.HasValue("x_idAktifitas")) // DN
                    idAktifitas.Visible = false; // Disable update for API request
                else
                    idAktifitas.SetFormValue(val, true, validate);
            }

            // Check field name 'NoReferensi' before field var 'x_NoReferensi'
            val = CurrentForm.HasValue("NoReferensi") ? CurrentForm.GetValue("NoReferensi") : CurrentForm.GetValue("x_NoReferensi");
            if (!NoReferensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoReferensi") && !CurrentForm.HasValue("x_NoReferensi")) // DN
                    NoReferensi.Visible = false; // Disable update for API request
                else
                    NoReferensi.SetFormValue(val);
            }

            // Check field name 'Nama_Kapal' before field var 'x_Nama_Kapal'
            val = CurrentForm.HasValue("Nama_Kapal") ? CurrentForm.GetValue("Nama_Kapal") : CurrentForm.GetValue("x_Nama_Kapal");
            if (!Nama_Kapal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Nama_Kapal") && !CurrentForm.HasValue("x_Nama_Kapal")) // DN
                    Nama_Kapal.Visible = false; // Disable update for API request
                else
                    Nama_Kapal.SetFormValue(val);
            }

            // Check field name 'TanggalJam' before field var 'x_TanggalJam'
            val = CurrentForm.HasValue("TanggalJam") ? CurrentForm.GetValue("TanggalJam") : CurrentForm.GetValue("x_TanggalJam");
            if (!TanggalJam.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalJam") && !CurrentForm.HasValue("x_TanggalJam")) // DN
                    TanggalJam.Visible = false; // Disable update for API request
                else
                    TanggalJam.SetFormValue(val, true, validate);
                TanggalJam.CurrentValue = UnformatDateTime(TanggalJam.CurrentValue, TanggalJam.FormatPattern);
            }

            // Check field name 'Nama_Kegiatan' before field var 'x_Nama_Kegiatan'
            val = CurrentForm.HasValue("Nama_Kegiatan") ? CurrentForm.GetValue("Nama_Kegiatan") : CurrentForm.GetValue("x_Nama_Kegiatan");
            if (!Nama_Kegiatan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Nama_Kegiatan") && !CurrentForm.HasValue("x_Nama_Kegiatan")) // DN
                    Nama_Kegiatan.Visible = false; // Disable update for API request
                else
                    Nama_Kegiatan.SetFormValue(val);
            }

            // Check field name 'Produk' before field var 'x_Produk'
            val = CurrentForm.HasValue("Produk") ? CurrentForm.GetValue("Produk") : CurrentForm.GetValue("x_Produk");
            if (!Produk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Produk") && !CurrentForm.HasValue("x_Produk")) // DN
                    Produk.Visible = false; // Disable update for API request
                else
                    Produk.SetFormValue(val);
            }

            // Check field name 'Density' before field var 'x_Density'
            val = CurrentForm.HasValue("Density") ? CurrentForm.GetValue("Density") : CurrentForm.GetValue("x_Density");
            if (!Density.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Density") && !CurrentForm.HasValue("x_Density")) // DN
                    Density.Visible = false; // Disable update for API request
                else
                    Density.SetFormValue(val);
            }

            // Check field name 'Temperatur' before field var 'x_Temperatur'
            val = CurrentForm.HasValue("Temperatur") ? CurrentForm.GetValue("Temperatur") : CurrentForm.GetValue("x_Temperatur");
            if (!Temperatur.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Temperatur") && !CurrentForm.HasValue("x_Temperatur")) // DN
                    Temperatur.Visible = false; // Disable update for API request
                else
                    Temperatur.SetFormValue(val);
            }

            // Check field name 'Level' before field var 'x_Level'
            val = CurrentForm.HasValue("Level") ? CurrentForm.GetValue("Level") : CurrentForm.GetValue("x_Level");
            if (!Level.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Level") && !CurrentForm.HasValue("x_Level")) // DN
                    Level.Visible = false; // Disable update for API request
                else
                    Level.SetFormValue(val);
            }

            // Check field name 'Volume' before field var 'x_Volume'
            val = CurrentForm.HasValue("Volume") ? CurrentForm.GetValue("Volume") : CurrentForm.GetValue("x_Volume");
            if (!Volume.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Volume") && !CurrentForm.HasValue("x_Volume")) // DN
                    Volume.Visible = false; // Disable update for API request
                else
                    Volume.SetFormValue(val);
            }

            // Check field name 'Flowrate' before field var 'x_Flowrate'
            val = CurrentForm.HasValue("Flowrate") ? CurrentForm.GetValue("Flowrate") : CurrentForm.GetValue("x_Flowrate");
            if (!Flowrate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Flowrate") && !CurrentForm.HasValue("x_Flowrate")) // DN
                    Flowrate.Visible = false; // Disable update for API request
                else
                    Flowrate.SetFormValue(val);
            }

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }

            // Check field name 'userInput' before field var 'x_userInput'
            val = CurrentForm.HasValue("userInput") ? CurrentForm.GetValue("userInput") : CurrentForm.GetValue("x_userInput");
            if (!userInput.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("userInput") && !CurrentForm.HasValue("x_userInput")) // DN
                    userInput.Visible = false; // Disable update for API request
                else
                    userInput.SetFormValue(val);
            }

            // Check field name 'etlDate' before field var 'x_etlDate'
            val = CurrentForm.HasValue("etlDate") ? CurrentForm.GetValue("etlDate") : CurrentForm.GetValue("x_etlDate");
            if (!etlDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("etlDate") && !CurrentForm.HasValue("x_etlDate")) // DN
                    etlDate.Visible = false; // Disable update for API request
                else
                    etlDate.SetFormValue(val, true, validate);
                etlDate.CurrentValue = UnformatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
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
                    lastUpdatedDate.SetFormValue(val, true, validate);
                lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            }

            // Check field name 'SubAktivitasHasilPemeriksaanId' before field var 'x_SubAktivitasHasilPemeriksaanId'
            val = CurrentForm.HasValue("SubAktivitasHasilPemeriksaanId") ? CurrentForm.GetValue("SubAktivitasHasilPemeriksaanId") : CurrentForm.GetValue("x_SubAktivitasHasilPemeriksaanId");
            if (!SubAktivitasHasilPemeriksaanId.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SubAktivitasHasilPemeriksaanId") && !CurrentForm.HasValue("x_SubAktivitasHasilPemeriksaanId")) // DN
                    SubAktivitasHasilPemeriksaanId.Visible = false; // Disable update for API request
                else
                    SubAktivitasHasilPemeriksaanId.SetFormValue(val, true, validate);
            }

            // Check field name 'TanggalJamSOP' before field var 'x_TanggalJamSOP'
            val = CurrentForm.HasValue("TanggalJamSOP") ? CurrentForm.GetValue("TanggalJamSOP") : CurrentForm.GetValue("x_TanggalJamSOP");
            if (!TanggalJamSOP.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalJamSOP") && !CurrentForm.HasValue("x_TanggalJamSOP")) // DN
                    TanggalJamSOP.Visible = false; // Disable update for API request
                else
                    TanggalJamSOP.SetFormValue(val, true, validate);
                TanggalJamSOP.CurrentValue = UnformatDateTime(TanggalJamSOP.CurrentValue, TanggalJamSOP.FormatPattern);
            }

            // Check field name 'SelisihWaktu' before field var 'x_SelisihWaktu'
            val = CurrentForm.HasValue("SelisihWaktu") ? CurrentForm.GetValue("SelisihWaktu") : CurrentForm.GetValue("x_SelisihWaktu");
            if (!SelisihWaktu.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SelisihWaktu") && !CurrentForm.HasValue("x_SelisihWaktu")) // DN
                    SelisihWaktu.Visible = false; // Disable update for API request
                else
                    SelisihWaktu.SetFormValue(val);
            }

            // Check field name 'IsQualityActive' before field var 'x_IsQualityActive'
            val = CurrentForm.HasValue("IsQualityActive") ? CurrentForm.GetValue("IsQualityActive") : CurrentForm.GetValue("x_IsQualityActive");
            if (!IsQualityActive.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IsQualityActive") && !CurrentForm.HasValue("x_IsQualityActive")) // DN
                    IsQualityActive.Visible = false; // Disable update for API request
                else
                    IsQualityActive.SetFormValue(val);
            }
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            id.CurrentValue = id.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            Nama_Kapal.CurrentValue = Nama_Kapal.FormValue;
            TanggalJam.CurrentValue = TanggalJam.FormValue;
            TanggalJam.CurrentValue = UnformatDateTime(TanggalJam.CurrentValue, TanggalJam.FormatPattern);
            Nama_Kegiatan.CurrentValue = Nama_Kegiatan.FormValue;
            Produk.CurrentValue = Produk.FormValue;
            Density.CurrentValue = Density.FormValue;
            Temperatur.CurrentValue = Temperatur.FormValue;
            Level.CurrentValue = Level.FormValue;
            Volume.CurrentValue = Volume.FormValue;
            Flowrate.CurrentValue = Flowrate.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            userInput.CurrentValue = userInput.FormValue;
            etlDate.CurrentValue = etlDate.FormValue;
            etlDate.CurrentValue = UnformatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            SubAktivitasHasilPemeriksaanId.CurrentValue = SubAktivitasHasilPemeriksaanId.FormValue;
            TanggalJamSOP.CurrentValue = TanggalJamSOP.FormValue;
            TanggalJamSOP.CurrentValue = UnformatDateTime(TanggalJamSOP.CurrentValue, TanggalJamSOP.FormatPattern);
            SelisihWaktu.CurrentValue = SelisihWaktu.FormValue;
            IsQualityActive.CurrentValue = IsQualityActive.FormValue;
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
            idProses.SetDbValue(row["idProses"]);
            idAktifitas.SetDbValue(row["idAktifitas"]);
            NoReferensi.SetDbValue(row["NoReferensi"]);
            Nama_Kapal.SetDbValue(row["Nama_Kapal"]);
            TanggalJam.SetDbValue(row["TanggalJam"]);
            Nama_Kegiatan.SetDbValue(row["Nama_Kegiatan"]);
            Produk.SetDbValue(row["Produk"]);
            Density.SetDbValue(row["Density"]);
            Temperatur.SetDbValue(row["Temperatur"]);
            Level.SetDbValue(row["Level"]);
            Volume.SetDbValue(row["Volume"]);
            Flowrate.SetDbValue(row["Flowrate"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            SubAktivitasHasilPemeriksaanId.SetDbValue(row["SubAktivitasHasilPemeriksaanId"]);
            TanggalJamSOP.SetDbValue(row["TanggalJamSOP"]);
            SelisihWaktu.SetDbValue(row["SelisihWaktu"]);
            IsQualityActive.SetDbValue((ConvertToBool(row["IsQualityActive"]) ? "1" : "0"));
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama_Kapal", Nama_Kapal.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalJam", TanggalJam.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama_Kegiatan", Nama_Kegiatan.DefaultValue ?? DbNullValue); // DN
            row.Add("Produk", Produk.DefaultValue ?? DbNullValue); // DN
            row.Add("Density", Density.DefaultValue ?? DbNullValue); // DN
            row.Add("Temperatur", Temperatur.DefaultValue ?? DbNullValue); // DN
            row.Add("Level", Level.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume", Volume.DefaultValue ?? DbNullValue); // DN
            row.Add("Flowrate", Flowrate.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("SubAktivitasHasilPemeriksaanId", SubAktivitasHasilPemeriksaanId.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalJamSOP", TanggalJamSOP.DefaultValue ?? DbNullValue); // DN
            row.Add("SelisihWaktu", SelisihWaktu.DefaultValue ?? DbNullValue); // DN
            row.Add("IsQualityActive", IsQualityActive.DefaultValue ?? DbNullValue); // DN
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

            // idProses
            idProses.RowCssClass = "row";

            // idAktifitas
            idAktifitas.RowCssClass = "row";

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // Nama_Kapal
            Nama_Kapal.RowCssClass = "row";

            // TanggalJam
            TanggalJam.RowCssClass = "row";

            // Nama_Kegiatan
            Nama_Kegiatan.RowCssClass = "row";

            // Produk
            Produk.RowCssClass = "row";

            // Density
            Density.RowCssClass = "row";

            // Temperatur
            Temperatur.RowCssClass = "row";

            // Level
            Level.RowCssClass = "row";

            // Volume
            Volume.RowCssClass = "row";

            // Flowrate
            Flowrate.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // SubAktivitasHasilPemeriksaanId
            SubAktivitasHasilPemeriksaanId.RowCssClass = "row";

            // TanggalJamSOP
            TanggalJamSOP.RowCssClass = "row";

            // SelisihWaktu
            SelisihWaktu.RowCssClass = "row";

            // IsQualityActive
            IsQualityActive.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // idProses
                idProses.ViewValue = idProses.CurrentValue;
                idProses.ViewValue = FormatNumber(idProses.ViewValue, idProses.FormatPattern);
                idProses.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.ViewValue = idAktifitas.CurrentValue;
                idAktifitas.ViewValue = FormatNumber(idAktifitas.ViewValue, idAktifitas.FormatPattern);
                idAktifitas.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // Nama_Kapal
                Nama_Kapal.ViewValue = ConvertToString(Nama_Kapal.CurrentValue); // DN
                Nama_Kapal.ViewCustomAttributes = "";

                // TanggalJam
                TanggalJam.ViewValue = TanggalJam.CurrentValue;
                TanggalJam.ViewValue = FormatDateTime(TanggalJam.ViewValue, TanggalJam.FormatPattern);
                TanggalJam.ViewCustomAttributes = "";

                // Nama_Kegiatan
                Nama_Kegiatan.ViewValue = ConvertToString(Nama_Kegiatan.CurrentValue); // DN
                Nama_Kegiatan.ViewCustomAttributes = "";

                // Produk
                Produk.ViewValue = ConvertToString(Produk.CurrentValue); // DN
                Produk.ViewCustomAttributes = "";

                // Density
                Density.ViewValue = ConvertToString(Density.CurrentValue); // DN
                Density.ViewCustomAttributes = "";

                // Temperatur
                Temperatur.ViewValue = ConvertToString(Temperatur.CurrentValue); // DN
                Temperatur.ViewCustomAttributes = "";

                // Level
                Level.ViewValue = ConvertToString(Level.CurrentValue); // DN
                Level.ViewCustomAttributes = "";

                // Volume
                Volume.ViewValue = ConvertToString(Volume.CurrentValue); // DN
                Volume.ViewCustomAttributes = "";

                // Flowrate
                Flowrate.ViewValue = ConvertToString(Flowrate.CurrentValue); // DN
                Flowrate.ViewCustomAttributes = "";

                // Keterangan
                Keterangan.ViewValue = Keterangan.CurrentValue;
                Keterangan.ViewCustomAttributes = "";

                // userInput
                userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                userInput.ViewCustomAttributes = "";

                // etlDate
                etlDate.ViewValue = etlDate.CurrentValue;
                etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                etlDate.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // lastUpdatedDate
                lastUpdatedDate.ViewValue = lastUpdatedDate.CurrentValue;
                lastUpdatedDate.ViewValue = FormatDateTime(lastUpdatedDate.ViewValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.ViewCustomAttributes = "";

                // SubAktivitasHasilPemeriksaanId
                SubAktivitasHasilPemeriksaanId.ViewValue = SubAktivitasHasilPemeriksaanId.CurrentValue;
                SubAktivitasHasilPemeriksaanId.ViewValue = FormatNumber(SubAktivitasHasilPemeriksaanId.ViewValue, SubAktivitasHasilPemeriksaanId.FormatPattern);
                SubAktivitasHasilPemeriksaanId.ViewCustomAttributes = "";

                // TanggalJamSOP
                TanggalJamSOP.ViewValue = TanggalJamSOP.CurrentValue;
                TanggalJamSOP.ViewValue = FormatDateTime(TanggalJamSOP.ViewValue, TanggalJamSOP.FormatPattern);
                TanggalJamSOP.ViewCustomAttributes = "";

                // SelisihWaktu
                SelisihWaktu.ViewValue = ConvertToString(SelisihWaktu.CurrentValue); // DN
                SelisihWaktu.ViewCustomAttributes = "";

                // IsQualityActive
                if (ConvertToBool(IsQualityActive.CurrentValue)) {
                    IsQualityActive.ViewValue = IsQualityActive.TagCaption(1) != "" ? IsQualityActive.TagCaption(1) : "Yes";
                } else {
                    IsQualityActive.ViewValue = IsQualityActive.TagCaption(2) != "" ? IsQualityActive.TagCaption(2) : "No";
                }
                IsQualityActive.ViewCustomAttributes = "";

                // id
                id.HrefValue = "";

                // idProses
                idProses.HrefValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // Nama_Kapal
                Nama_Kapal.HrefValue = "";

                // TanggalJam
                TanggalJam.HrefValue = "";

                // Nama_Kegiatan
                Nama_Kegiatan.HrefValue = "";

                // Produk
                Produk.HrefValue = "";

                // Density
                Density.HrefValue = "";

                // Temperatur
                Temperatur.HrefValue = "";

                // Level
                Level.HrefValue = "";

                // Volume
                Volume.HrefValue = "";

                // Flowrate
                Flowrate.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";

                // SubAktivitasHasilPemeriksaanId
                SubAktivitasHasilPemeriksaanId.HrefValue = "";

                // TanggalJamSOP
                TanggalJamSOP.HrefValue = "";

                // SelisihWaktu
                SelisihWaktu.HrefValue = "";

                // IsQualityActive
                IsQualityActive.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // id
                id.SetupEditAttributes();
                id.EditValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;
                idProses.PlaceHolder = RemoveHtml(idProses.Caption);
                if (!Empty(idProses.EditValue) && IsNumeric(idProses.EditValue))
                    idProses.EditValue = FormatNumber(idProses.EditValue, null);

                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;
                idAktifitas.PlaceHolder = RemoveHtml(idAktifitas.Caption);
                if (!Empty(idAktifitas.EditValue) && IsNumeric(idAktifitas.EditValue))
                    idAktifitas.EditValue = FormatNumber(idAktifitas.EditValue, null);

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // Nama_Kapal
                Nama_Kapal.SetupEditAttributes();
                if (!Nama_Kapal.Raw)
                    Nama_Kapal.CurrentValue = HtmlDecode(Nama_Kapal.CurrentValue);
                Nama_Kapal.EditValue = HtmlEncode(Nama_Kapal.CurrentValue);
                Nama_Kapal.PlaceHolder = RemoveHtml(Nama_Kapal.Caption);

                // TanggalJam
                TanggalJam.SetupEditAttributes();
                TanggalJam.EditValue = FormatDateTime(TanggalJam.CurrentValue, TanggalJam.FormatPattern);
                TanggalJam.PlaceHolder = RemoveHtml(TanggalJam.Caption);

                // Nama_Kegiatan
                Nama_Kegiatan.SetupEditAttributes();
                if (!Nama_Kegiatan.Raw)
                    Nama_Kegiatan.CurrentValue = HtmlDecode(Nama_Kegiatan.CurrentValue);
                Nama_Kegiatan.EditValue = HtmlEncode(Nama_Kegiatan.CurrentValue);
                Nama_Kegiatan.PlaceHolder = RemoveHtml(Nama_Kegiatan.Caption);

                // Produk
                Produk.SetupEditAttributes();
                if (!Produk.Raw)
                    Produk.CurrentValue = HtmlDecode(Produk.CurrentValue);
                Produk.EditValue = HtmlEncode(Produk.CurrentValue);
                Produk.PlaceHolder = RemoveHtml(Produk.Caption);

                // Density
                Density.SetupEditAttributes();
                if (!Density.Raw)
                    Density.CurrentValue = HtmlDecode(Density.CurrentValue);
                Density.EditValue = HtmlEncode(Density.CurrentValue);
                Density.PlaceHolder = RemoveHtml(Density.Caption);

                // Temperatur
                Temperatur.SetupEditAttributes();
                if (!Temperatur.Raw)
                    Temperatur.CurrentValue = HtmlDecode(Temperatur.CurrentValue);
                Temperatur.EditValue = HtmlEncode(Temperatur.CurrentValue);
                Temperatur.PlaceHolder = RemoveHtml(Temperatur.Caption);

                // Level
                Level.SetupEditAttributes();
                if (!Level.Raw)
                    Level.CurrentValue = HtmlDecode(Level.CurrentValue);
                Level.EditValue = HtmlEncode(Level.CurrentValue);
                Level.PlaceHolder = RemoveHtml(Level.Caption);

                // Volume
                Volume.SetupEditAttributes();
                if (!Volume.Raw)
                    Volume.CurrentValue = HtmlDecode(Volume.CurrentValue);
                Volume.EditValue = HtmlEncode(Volume.CurrentValue);
                Volume.PlaceHolder = RemoveHtml(Volume.Caption);

                // Flowrate
                Flowrate.SetupEditAttributes();
                if (!Flowrate.Raw)
                    Flowrate.CurrentValue = HtmlDecode(Flowrate.CurrentValue);
                Flowrate.EditValue = HtmlEncode(Flowrate.CurrentValue);
                Flowrate.PlaceHolder = RemoveHtml(Flowrate.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // userInput
                userInput.SetupEditAttributes();
                if (!userInput.Raw)
                    userInput.CurrentValue = HtmlDecode(userInput.CurrentValue);
                userInput.EditValue = HtmlEncode(userInput.CurrentValue);
                userInput.PlaceHolder = RemoveHtml(userInput.Caption);

                // etlDate
                etlDate.SetupEditAttributes();
                etlDate.EditValue = FormatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
                etlDate.PlaceHolder = RemoveHtml(etlDate.Caption);

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                if (!LastUpdatedBy.Raw)
                    LastUpdatedBy.CurrentValue = HtmlDecode(LastUpdatedBy.CurrentValue);
                LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.CurrentValue);
                LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

                // lastUpdatedDate
                lastUpdatedDate.SetupEditAttributes();
                lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
                lastUpdatedDate.PlaceHolder = RemoveHtml(lastUpdatedDate.Caption);

                // SubAktivitasHasilPemeriksaanId
                SubAktivitasHasilPemeriksaanId.SetupEditAttributes();
                SubAktivitasHasilPemeriksaanId.EditValue = SubAktivitasHasilPemeriksaanId.CurrentValue;
                SubAktivitasHasilPemeriksaanId.PlaceHolder = RemoveHtml(SubAktivitasHasilPemeriksaanId.Caption);
                if (!Empty(SubAktivitasHasilPemeriksaanId.EditValue) && IsNumeric(SubAktivitasHasilPemeriksaanId.EditValue))
                    SubAktivitasHasilPemeriksaanId.EditValue = FormatNumber(SubAktivitasHasilPemeriksaanId.EditValue, null);

                // TanggalJamSOP
                TanggalJamSOP.SetupEditAttributes();
                TanggalJamSOP.EditValue = FormatDateTime(TanggalJamSOP.CurrentValue, TanggalJamSOP.FormatPattern);
                TanggalJamSOP.PlaceHolder = RemoveHtml(TanggalJamSOP.Caption);

                // SelisihWaktu
                SelisihWaktu.SetupEditAttributes();
                if (!SelisihWaktu.Raw)
                    SelisihWaktu.CurrentValue = HtmlDecode(SelisihWaktu.CurrentValue);
                SelisihWaktu.EditValue = HtmlEncode(SelisihWaktu.CurrentValue);
                SelisihWaktu.PlaceHolder = RemoveHtml(SelisihWaktu.Caption);

                // IsQualityActive
                IsQualityActive.EditValue = IsQualityActive.Options(false);
                IsQualityActive.PlaceHolder = RemoveHtml(IsQualityActive.Caption);

                // Edit refer script

                // id
                id.HrefValue = "";

                // idProses
                idProses.HrefValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // Nama_Kapal
                Nama_Kapal.HrefValue = "";

                // TanggalJam
                TanggalJam.HrefValue = "";

                // Nama_Kegiatan
                Nama_Kegiatan.HrefValue = "";

                // Produk
                Produk.HrefValue = "";

                // Density
                Density.HrefValue = "";

                // Temperatur
                Temperatur.HrefValue = "";

                // Level
                Level.HrefValue = "";

                // Volume
                Volume.HrefValue = "";

                // Flowrate
                Flowrate.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";

                // SubAktivitasHasilPemeriksaanId
                SubAktivitasHasilPemeriksaanId.HrefValue = "";

                // TanggalJamSOP
                TanggalJamSOP.HrefValue = "";

                // SelisihWaktu
                SelisihWaktu.HrefValue = "";

                // IsQualityActive
                IsQualityActive.HrefValue = "";
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
                if (id.Visible && id.Required) {
                    if (!id.IsDetailKey && Empty(id.FormValue)) {
                        id.AddErrorMessage(ConvertToString(id.RequiredErrorMessage).Replace("%s", id.Caption));
                    }
                }
                if (idProses.Visible && idProses.Required) {
                    if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                        idProses.AddErrorMessage(ConvertToString(idProses.RequiredErrorMessage).Replace("%s", idProses.Caption));
                    }
                }
                if (!CheckInteger(idProses.FormValue)) {
                    idProses.AddErrorMessage(idProses.GetErrorMessage(false));
                }
                if (idAktifitas.Visible && idAktifitas.Required) {
                    if (!idAktifitas.IsDetailKey && Empty(idAktifitas.FormValue)) {
                        idAktifitas.AddErrorMessage(ConvertToString(idAktifitas.RequiredErrorMessage).Replace("%s", idAktifitas.Caption));
                    }
                }
                if (!CheckInteger(idAktifitas.FormValue)) {
                    idAktifitas.AddErrorMessage(idAktifitas.GetErrorMessage(false));
                }
                if (NoReferensi.Visible && NoReferensi.Required) {
                    if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                        NoReferensi.AddErrorMessage(ConvertToString(NoReferensi.RequiredErrorMessage).Replace("%s", NoReferensi.Caption));
                    }
                }
                if (Nama_Kapal.Visible && Nama_Kapal.Required) {
                    if (!Nama_Kapal.IsDetailKey && Empty(Nama_Kapal.FormValue)) {
                        Nama_Kapal.AddErrorMessage(ConvertToString(Nama_Kapal.RequiredErrorMessage).Replace("%s", Nama_Kapal.Caption));
                    }
                }
                if (TanggalJam.Visible && TanggalJam.Required) {
                    if (!TanggalJam.IsDetailKey && Empty(TanggalJam.FormValue)) {
                        TanggalJam.AddErrorMessage(ConvertToString(TanggalJam.RequiredErrorMessage).Replace("%s", TanggalJam.Caption));
                    }
                }
                if (!CheckDate(TanggalJam.FormValue, TanggalJam.FormatPattern)) {
                    TanggalJam.AddErrorMessage(TanggalJam.GetErrorMessage(false));
                }
                if (Nama_Kegiatan.Visible && Nama_Kegiatan.Required) {
                    if (!Nama_Kegiatan.IsDetailKey && Empty(Nama_Kegiatan.FormValue)) {
                        Nama_Kegiatan.AddErrorMessage(ConvertToString(Nama_Kegiatan.RequiredErrorMessage).Replace("%s", Nama_Kegiatan.Caption));
                    }
                }
                if (Produk.Visible && Produk.Required) {
                    if (!Produk.IsDetailKey && Empty(Produk.FormValue)) {
                        Produk.AddErrorMessage(ConvertToString(Produk.RequiredErrorMessage).Replace("%s", Produk.Caption));
                    }
                }
                if (Density.Visible && Density.Required) {
                    if (!Density.IsDetailKey && Empty(Density.FormValue)) {
                        Density.AddErrorMessage(ConvertToString(Density.RequiredErrorMessage).Replace("%s", Density.Caption));
                    }
                }
                if (Temperatur.Visible && Temperatur.Required) {
                    if (!Temperatur.IsDetailKey && Empty(Temperatur.FormValue)) {
                        Temperatur.AddErrorMessage(ConvertToString(Temperatur.RequiredErrorMessage).Replace("%s", Temperatur.Caption));
                    }
                }
                if (Level.Visible && Level.Required) {
                    if (!Level.IsDetailKey && Empty(Level.FormValue)) {
                        Level.AddErrorMessage(ConvertToString(Level.RequiredErrorMessage).Replace("%s", Level.Caption));
                    }
                }
                if (Volume.Visible && Volume.Required) {
                    if (!Volume.IsDetailKey && Empty(Volume.FormValue)) {
                        Volume.AddErrorMessage(ConvertToString(Volume.RequiredErrorMessage).Replace("%s", Volume.Caption));
                    }
                }
                if (Flowrate.Visible && Flowrate.Required) {
                    if (!Flowrate.IsDetailKey && Empty(Flowrate.FormValue)) {
                        Flowrate.AddErrorMessage(ConvertToString(Flowrate.RequiredErrorMessage).Replace("%s", Flowrate.Caption));
                    }
                }
                if (Keterangan.Visible && Keterangan.Required) {
                    if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                        Keterangan.AddErrorMessage(ConvertToString(Keterangan.RequiredErrorMessage).Replace("%s", Keterangan.Caption));
                    }
                }
                if (userInput.Visible && userInput.Required) {
                    if (!userInput.IsDetailKey && Empty(userInput.FormValue)) {
                        userInput.AddErrorMessage(ConvertToString(userInput.RequiredErrorMessage).Replace("%s", userInput.Caption));
                    }
                }
                if (etlDate.Visible && etlDate.Required) {
                    if (!etlDate.IsDetailKey && Empty(etlDate.FormValue)) {
                        etlDate.AddErrorMessage(ConvertToString(etlDate.RequiredErrorMessage).Replace("%s", etlDate.Caption));
                    }
                }
                if (!CheckDate(etlDate.FormValue, etlDate.FormatPattern)) {
                    etlDate.AddErrorMessage(etlDate.GetErrorMessage(false));
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
                if (!CheckDate(lastUpdatedDate.FormValue, lastUpdatedDate.FormatPattern)) {
                    lastUpdatedDate.AddErrorMessage(lastUpdatedDate.GetErrorMessage(false));
                }
                if (SubAktivitasHasilPemeriksaanId.Visible && SubAktivitasHasilPemeriksaanId.Required) {
                    if (!SubAktivitasHasilPemeriksaanId.IsDetailKey && Empty(SubAktivitasHasilPemeriksaanId.FormValue)) {
                        SubAktivitasHasilPemeriksaanId.AddErrorMessage(ConvertToString(SubAktivitasHasilPemeriksaanId.RequiredErrorMessage).Replace("%s", SubAktivitasHasilPemeriksaanId.Caption));
                    }
                }
                if (!CheckInteger(SubAktivitasHasilPemeriksaanId.FormValue)) {
                    SubAktivitasHasilPemeriksaanId.AddErrorMessage(SubAktivitasHasilPemeriksaanId.GetErrorMessage(false));
                }
                if (TanggalJamSOP.Visible && TanggalJamSOP.Required) {
                    if (!TanggalJamSOP.IsDetailKey && Empty(TanggalJamSOP.FormValue)) {
                        TanggalJamSOP.AddErrorMessage(ConvertToString(TanggalJamSOP.RequiredErrorMessage).Replace("%s", TanggalJamSOP.Caption));
                    }
                }
                if (!CheckDate(TanggalJamSOP.FormValue, TanggalJamSOP.FormatPattern)) {
                    TanggalJamSOP.AddErrorMessage(TanggalJamSOP.GetErrorMessage(false));
                }
                if (SelisihWaktu.Visible && SelisihWaktu.Required) {
                    if (!SelisihWaktu.IsDetailKey && Empty(SelisihWaktu.FormValue)) {
                        SelisihWaktu.AddErrorMessage(ConvertToString(SelisihWaktu.RequiredErrorMessage).Replace("%s", SelisihWaktu.Caption));
                    }
                }
                if (IsQualityActive.Visible && IsQualityActive.Required) {
                    if (Empty(IsQualityActive.FormValue)) {
                        IsQualityActive.AddErrorMessage(ConvertToString(IsQualityActive.RequiredErrorMessage).Replace("%s", IsQualityActive.Caption));
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

            // idProses
            idProses.SetDbValue(rsnew, idProses.CurrentValue, idProses.ReadOnly);

            // idAktifitas
            idAktifitas.SetDbValue(rsnew, idAktifitas.CurrentValue, idAktifitas.ReadOnly);

            // NoReferensi
            NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue, NoReferensi.ReadOnly);

            // Nama_Kapal
            Nama_Kapal.SetDbValue(rsnew, Nama_Kapal.CurrentValue, Nama_Kapal.ReadOnly);

            // TanggalJam
            TanggalJam.SetDbValue(rsnew, ConvertToDateTime(TanggalJam.CurrentValue, TanggalJam.FormatPattern), TanggalJam.ReadOnly);

            // Nama_Kegiatan
            Nama_Kegiatan.SetDbValue(rsnew, Nama_Kegiatan.CurrentValue, Nama_Kegiatan.ReadOnly);

            // Produk
            Produk.SetDbValue(rsnew, Produk.CurrentValue, Produk.ReadOnly);

            // Density
            Density.SetDbValue(rsnew, Density.CurrentValue, Density.ReadOnly);

            // Temperatur
            Temperatur.SetDbValue(rsnew, Temperatur.CurrentValue, Temperatur.ReadOnly);

            // Level
            Level.SetDbValue(rsnew, Level.CurrentValue, Level.ReadOnly);

            // Volume
            Volume.SetDbValue(rsnew, Volume.CurrentValue, Volume.ReadOnly);

            // Flowrate
            Flowrate.SetDbValue(rsnew, Flowrate.CurrentValue, Flowrate.ReadOnly);

            // Keterangan
            Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue, Keterangan.ReadOnly);

            // userInput
            userInput.SetDbValue(rsnew, userInput.CurrentValue, userInput.ReadOnly);

            // etlDate
            etlDate.SetDbValue(rsnew, ConvertToDateTime(etlDate.CurrentValue, etlDate.FormatPattern), etlDate.ReadOnly);

            // LastUpdatedBy
            LastUpdatedBy.SetDbValue(rsnew, LastUpdatedBy.CurrentValue, LastUpdatedBy.ReadOnly);

            // lastUpdatedDate
            lastUpdatedDate.SetDbValue(rsnew, ConvertToDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern), lastUpdatedDate.ReadOnly);

            // SubAktivitasHasilPemeriksaanId
            SubAktivitasHasilPemeriksaanId.SetDbValue(rsnew, SubAktivitasHasilPemeriksaanId.CurrentValue, SubAktivitasHasilPemeriksaanId.ReadOnly);

            // TanggalJamSOP
            TanggalJamSOP.SetDbValue(rsnew, ConvertToDateTime(TanggalJamSOP.CurrentValue, TanggalJamSOP.FormatPattern), TanggalJamSOP.ReadOnly);

            // SelisihWaktu
            SelisihWaktu.SetDbValue(rsnew, SelisihWaktu.CurrentValue, SelisihWaktu.ReadOnly);

            // IsQualityActive
            IsQualityActive.SetDbValue(rsnew, ConvertToBool(IsQualityActive.CurrentValue), IsQualityActive.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("idProses", out value)) // idProses
                idProses.CurrentValue = value;
            if (row.TryGetValue("idAktifitas", out value)) // idAktifitas
                idAktifitas.CurrentValue = value;
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.CurrentValue = value;
            if (row.TryGetValue("Nama_Kapal", out value)) // Nama_Kapal
                Nama_Kapal.CurrentValue = value;
            if (row.TryGetValue("TanggalJam", out value)) // TanggalJam
                TanggalJam.CurrentValue = value;
            if (row.TryGetValue("Nama_Kegiatan", out value)) // Nama_Kegiatan
                Nama_Kegiatan.CurrentValue = value;
            if (row.TryGetValue("Produk", out value)) // Produk
                Produk.CurrentValue = value;
            if (row.TryGetValue("Density", out value)) // Density
                Density.CurrentValue = value;
            if (row.TryGetValue("Temperatur", out value)) // Temperatur
                Temperatur.CurrentValue = value;
            if (row.TryGetValue("Level", out value)) // Level
                Level.CurrentValue = value;
            if (row.TryGetValue("Volume", out value)) // Volume
                Volume.CurrentValue = value;
            if (row.TryGetValue("Flowrate", out value)) // Flowrate
                Flowrate.CurrentValue = value;
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.CurrentValue = value;
            if (row.TryGetValue("userInput", out value)) // userInput
                userInput.CurrentValue = value;
            if (row.TryGetValue("etlDate", out value)) // etlDate
                etlDate.CurrentValue = value;
            if (row.TryGetValue("LastUpdatedBy", out value)) // LastUpdatedBy
                LastUpdatedBy.CurrentValue = value;
            if (row.TryGetValue("lastUpdatedDate", out value)) // lastUpdatedDate
                lastUpdatedDate.CurrentValue = value;
            if (row.TryGetValue("SubAktivitasHasilPemeriksaanId", out value)) // SubAktivitasHasilPemeriksaanId
                SubAktivitasHasilPemeriksaanId.CurrentValue = value;
            if (row.TryGetValue("TanggalJamSOP", out value)) // TanggalJamSOP
                TanggalJamSOP.CurrentValue = value;
            if (row.TryGetValue("SelisihWaktu", out value)) // SelisihWaktu
                SelisihWaktu.CurrentValue = value;
            if (row.TryGetValue("IsQualityActive", out value)) // IsQualityActive
                IsQualityActive.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasLogbookPenerimaanStsPymBbmList")), "", TableVar, true);
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
