namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasInputDataRtwEdit
    /// </summary>
    public static SubAktivitasInputDataRtwEdit subAktivitasInputDataRtwEdit
    {
        get => HttpData.Get<SubAktivitasInputDataRtwEdit>("subAktivitasInputDataRtwEdit")!;
        set => HttpData["subAktivitasInputDataRtwEdit"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasInputDataRTW
    /// </summary>
    public class SubAktivitasInputDataRtwEdit : SubAktivitasInputDataRtwEditBase
    {
        // Constructor
        public SubAktivitasInputDataRtwEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasInputDataRtwEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasInputDataRtwEditBase : SubAktivitasInputDataRtw
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasInputDataRtwEdit";

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
        public SubAktivitasInputDataRtwEditBase()
        {
            TableName = "SubAktivitasInputDataRTW";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasInputDataRtw)
            if (subAktivitasInputDataRtw == null || subAktivitasInputDataRtw is SubAktivitasInputDataRtw)
                subAktivitasInputDataRtw = this;

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
        public string PageName => "SubAktivitasInputDataRtwEdit";

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
            idProses.SetVisibility();
            NoReferensi.SetVisibility();
            Produk.SetVisibility();
            StatusAktivitas.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            NomorGerbongKertel.SetVisibility();
            MeterAwal.SetVisibility();
            MeterAkhir.SetVisibility();
            Total.SetVisibility();
            userInput.Visible = false;
            etlDate.Visible = false;
            NoMeter.SetVisibility();
            Quantity.SetVisibility();
            HasilPengukuranT2.SetVisibility();
            PICPengisian.SetVisibility();
            NomorGerbongKertel2.SetVisibility();
            NomorGerbongKertel3.SetVisibility();
            Quantity2.SetVisibility();
            Quantity3.SetVisibility();
            HasilPengukuranT2_2.SetVisibility();
            HasilPengukuranT2_3.SetVisibility();
            TotalGK.SetVisibility();
            Selisih.SetVisibility();
        }

        // Constructor
        public SubAktivitasInputDataRtwEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "SubAktivitasInputDataRtwView" ? "1" : "0"); // If View page, no primary button
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
                            return Terminate("SubAktivitasInputDataRtwList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "SubAktivitasInputDataRtwList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SubAktivitasInputDataRtwList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SubAktivitasInputDataRtwList"; // Return list page content
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
                subAktivitasInputDataRtwEdit?.PageRender();
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

            // Check field name 'idProses' before field var 'x_idProses'
            val = CurrentForm.HasValue("idProses") ? CurrentForm.GetValue("idProses") : CurrentForm.GetValue("x_idProses");
            if (!idProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idProses") && !CurrentForm.HasValue("x_idProses")) // DN
                    idProses.Visible = false; // Disable update for API request
                else
                    idProses.SetFormValue(val);
            }

            // Check field name 'NoReferensi' before field var 'x_NoReferensi'
            val = CurrentForm.HasValue("NoReferensi") ? CurrentForm.GetValue("NoReferensi") : CurrentForm.GetValue("x_NoReferensi");
            if (!NoReferensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoReferensi") && !CurrentForm.HasValue("x_NoReferensi")) // DN
                    NoReferensi.Visible = false; // Disable update for API request
                else
                    NoReferensi.SetFormValue(val);
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

            // Check field name 'NomorGerbongKertel' before field var 'x_NomorGerbongKertel'
            val = CurrentForm.HasValue("NomorGerbongKertel") ? CurrentForm.GetValue("NomorGerbongKertel") : CurrentForm.GetValue("x_NomorGerbongKertel");
            if (!NomorGerbongKertel.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorGerbongKertel") && !CurrentForm.HasValue("x_NomorGerbongKertel")) // DN
                    NomorGerbongKertel.Visible = false; // Disable update for API request
                else
                    NomorGerbongKertel.SetFormValue(val);
            }

            // Check field name 'MeterAwal' before field var 'x_MeterAwal'
            val = CurrentForm.HasValue("MeterAwal") ? CurrentForm.GetValue("MeterAwal") : CurrentForm.GetValue("x_MeterAwal");
            if (!MeterAwal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MeterAwal") && !CurrentForm.HasValue("x_MeterAwal")) // DN
                    MeterAwal.Visible = false; // Disable update for API request
                else
                    MeterAwal.SetFormValue(val);
            }

            // Check field name 'MeterAkhir' before field var 'x_MeterAkhir'
            val = CurrentForm.HasValue("MeterAkhir") ? CurrentForm.GetValue("MeterAkhir") : CurrentForm.GetValue("x_MeterAkhir");
            if (!MeterAkhir.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MeterAkhir") && !CurrentForm.HasValue("x_MeterAkhir")) // DN
                    MeterAkhir.Visible = false; // Disable update for API request
                else
                    MeterAkhir.SetFormValue(val);
            }

            // Check field name 'Total' before field var 'x_Total'
            val = CurrentForm.HasValue("Total") ? CurrentForm.GetValue("Total") : CurrentForm.GetValue("x_Total");
            if (!Total.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Total") && !CurrentForm.HasValue("x_Total")) // DN
                    Total.Visible = false; // Disable update for API request
                else
                    Total.SetFormValue(val);
            }

            // Check field name 'NoMeter' before field var 'x_NoMeter'
            val = CurrentForm.HasValue("NoMeter") ? CurrentForm.GetValue("NoMeter") : CurrentForm.GetValue("x_NoMeter");
            if (!NoMeter.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoMeter") && !CurrentForm.HasValue("x_NoMeter")) // DN
                    NoMeter.Visible = false; // Disable update for API request
                else
                    NoMeter.SetFormValue(val);
            }

            // Check field name 'Quantity' before field var 'x_Quantity'
            val = CurrentForm.HasValue("Quantity") ? CurrentForm.GetValue("Quantity") : CurrentForm.GetValue("x_Quantity");
            if (!Quantity.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Quantity") && !CurrentForm.HasValue("x_Quantity")) // DN
                    Quantity.Visible = false; // Disable update for API request
                else
                    Quantity.SetFormValue(val);
            }

            // Check field name 'HasilPengukuranT2' before field var 'x_HasilPengukuranT2'
            val = CurrentForm.HasValue("HasilPengukuranT2") ? CurrentForm.GetValue("HasilPengukuranT2") : CurrentForm.GetValue("x_HasilPengukuranT2");
            if (!HasilPengukuranT2.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("HasilPengukuranT2") && !CurrentForm.HasValue("x_HasilPengukuranT2")) // DN
                    HasilPengukuranT2.Visible = false; // Disable update for API request
                else
                    HasilPengukuranT2.SetFormValue(val);
            }

            // Check field name 'PICPengisian' before field var 'x_PICPengisian'
            val = CurrentForm.HasValue("PICPengisian") ? CurrentForm.GetValue("PICPengisian") : CurrentForm.GetValue("x_PICPengisian");
            if (!PICPengisian.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PICPengisian") && !CurrentForm.HasValue("x_PICPengisian")) // DN
                    PICPengisian.Visible = false; // Disable update for API request
                else
                    PICPengisian.SetFormValue(val);
            }

            // Check field name 'NomorGerbongKertel2' before field var 'x_NomorGerbongKertel2'
            val = CurrentForm.HasValue("NomorGerbongKertel2") ? CurrentForm.GetValue("NomorGerbongKertel2") : CurrentForm.GetValue("x_NomorGerbongKertel2");
            if (!NomorGerbongKertel2.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorGerbongKertel2") && !CurrentForm.HasValue("x_NomorGerbongKertel2")) // DN
                    NomorGerbongKertel2.Visible = false; // Disable update for API request
                else
                    NomorGerbongKertel2.SetFormValue(val);
            }

            // Check field name 'NomorGerbongKertel3' before field var 'x_NomorGerbongKertel3'
            val = CurrentForm.HasValue("NomorGerbongKertel3") ? CurrentForm.GetValue("NomorGerbongKertel3") : CurrentForm.GetValue("x_NomorGerbongKertel3");
            if (!NomorGerbongKertel3.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorGerbongKertel3") && !CurrentForm.HasValue("x_NomorGerbongKertel3")) // DN
                    NomorGerbongKertel3.Visible = false; // Disable update for API request
                else
                    NomorGerbongKertel3.SetFormValue(val);
            }

            // Check field name 'Quantity2' before field var 'x_Quantity2'
            val = CurrentForm.HasValue("Quantity2") ? CurrentForm.GetValue("Quantity2") : CurrentForm.GetValue("x_Quantity2");
            if (!Quantity2.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Quantity2") && !CurrentForm.HasValue("x_Quantity2")) // DN
                    Quantity2.Visible = false; // Disable update for API request
                else
                    Quantity2.SetFormValue(val);
            }

            // Check field name 'Quantity3' before field var 'x_Quantity3'
            val = CurrentForm.HasValue("Quantity3") ? CurrentForm.GetValue("Quantity3") : CurrentForm.GetValue("x_Quantity3");
            if (!Quantity3.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Quantity3") && !CurrentForm.HasValue("x_Quantity3")) // DN
                    Quantity3.Visible = false; // Disable update for API request
                else
                    Quantity3.SetFormValue(val);
            }

            // Check field name 'HasilPengukuranT2_2' before field var 'x_HasilPengukuranT2_2'
            val = CurrentForm.HasValue("HasilPengukuranT2_2") ? CurrentForm.GetValue("HasilPengukuranT2_2") : CurrentForm.GetValue("x_HasilPengukuranT2_2");
            if (!HasilPengukuranT2_2.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("HasilPengukuranT2_2") && !CurrentForm.HasValue("x_HasilPengukuranT2_2")) // DN
                    HasilPengukuranT2_2.Visible = false; // Disable update for API request
                else
                    HasilPengukuranT2_2.SetFormValue(val);
            }

            // Check field name 'HasilPengukuranT2_3' before field var 'x_HasilPengukuranT2_3'
            val = CurrentForm.HasValue("HasilPengukuranT2_3") ? CurrentForm.GetValue("HasilPengukuranT2_3") : CurrentForm.GetValue("x_HasilPengukuranT2_3");
            if (!HasilPengukuranT2_3.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("HasilPengukuranT2_3") && !CurrentForm.HasValue("x_HasilPengukuranT2_3")) // DN
                    HasilPengukuranT2_3.Visible = false; // Disable update for API request
                else
                    HasilPengukuranT2_3.SetFormValue(val);
            }

            // Check field name 'TotalGK' before field var 'x_TotalGK'
            val = CurrentForm.HasValue("TotalGK") ? CurrentForm.GetValue("TotalGK") : CurrentForm.GetValue("x_TotalGK");
            if (!TotalGK.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TotalGK") && !CurrentForm.HasValue("x_TotalGK")) // DN
                    TotalGK.Visible = false; // Disable update for API request
                else
                    TotalGK.SetFormValue(val);
            }

            // Check field name 'Selisih' before field var 'x_Selisih'
            val = CurrentForm.HasValue("Selisih") ? CurrentForm.GetValue("Selisih") : CurrentForm.GetValue("x_Selisih");
            if (!Selisih.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Selisih") && !CurrentForm.HasValue("x_Selisih")) // DN
                    Selisih.Visible = false; // Disable update for API request
                else
                    Selisih.SetFormValue(val);
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
            idProses.CurrentValue = idProses.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            Produk.CurrentValue = Produk.FormValue;
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            NomorGerbongKertel.CurrentValue = NomorGerbongKertel.FormValue;
            MeterAwal.CurrentValue = MeterAwal.FormValue;
            MeterAkhir.CurrentValue = MeterAkhir.FormValue;
            Total.CurrentValue = Total.FormValue;
            NoMeter.CurrentValue = NoMeter.FormValue;
            Quantity.CurrentValue = Quantity.FormValue;
            HasilPengukuranT2.CurrentValue = HasilPengukuranT2.FormValue;
            PICPengisian.CurrentValue = PICPengisian.FormValue;
            NomorGerbongKertel2.CurrentValue = NomorGerbongKertel2.FormValue;
            NomorGerbongKertel3.CurrentValue = NomorGerbongKertel3.FormValue;
            Quantity2.CurrentValue = Quantity2.FormValue;
            Quantity3.CurrentValue = Quantity3.FormValue;
            HasilPengukuranT2_2.CurrentValue = HasilPengukuranT2_2.FormValue;
            HasilPengukuranT2_3.CurrentValue = HasilPengukuranT2_3.FormValue;
            TotalGK.CurrentValue = TotalGK.FormValue;
            Selisih.CurrentValue = Selisih.FormValue;
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
            idProses.SetDbValue(row["idProses"]);
            NoReferensi.SetDbValue(row["NoReferensi"]);
            Produk.SetDbValue(row["Produk"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            NomorGerbongKertel.SetDbValue(row["NomorGerbongKertel"]);
            MeterAwal.SetDbValue(row["MeterAwal"]);
            MeterAkhir.SetDbValue(row["MeterAkhir"]);
            Total.SetDbValue(row["Total"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            NoMeter.SetDbValue(row["NoMeter"]);
            Quantity.SetDbValue(row["Quantity"]);
            HasilPengukuranT2.SetDbValue(row["HasilPengukuranT2"]);
            PICPengisian.SetDbValue(row["PICPengisian"]);
            NomorGerbongKertel2.SetDbValue(row["NomorGerbongKertel2"]);
            NomorGerbongKertel3.SetDbValue(row["NomorGerbongKertel3"]);
            Quantity2.SetDbValue(row["Quantity2"]);
            Quantity3.SetDbValue(row["Quantity3"]);
            HasilPengukuranT2_2.SetDbValue(row["HasilPengukuranT2_2"]);
            HasilPengukuranT2_3.SetDbValue(row["HasilPengukuranT2_3"]);
            TotalGK.SetDbValue(row["TotalGK"]);
            Selisih.SetDbValue(row["Selisih"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("Produk", Produk.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorGerbongKertel", NomorGerbongKertel.DefaultValue ?? DbNullValue); // DN
            row.Add("MeterAwal", MeterAwal.DefaultValue ?? DbNullValue); // DN
            row.Add("MeterAkhir", MeterAkhir.DefaultValue ?? DbNullValue); // DN
            row.Add("Total", Total.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("NoMeter", NoMeter.DefaultValue ?? DbNullValue); // DN
            row.Add("Quantity", Quantity.DefaultValue ?? DbNullValue); // DN
            row.Add("HasilPengukuranT2", HasilPengukuranT2.DefaultValue ?? DbNullValue); // DN
            row.Add("PICPengisian", PICPengisian.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorGerbongKertel2", NomorGerbongKertel2.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorGerbongKertel3", NomorGerbongKertel3.DefaultValue ?? DbNullValue); // DN
            row.Add("Quantity2", Quantity2.DefaultValue ?? DbNullValue); // DN
            row.Add("Quantity3", Quantity3.DefaultValue ?? DbNullValue); // DN
            row.Add("HasilPengukuranT2_2", HasilPengukuranT2_2.DefaultValue ?? DbNullValue); // DN
            row.Add("HasilPengukuranT2_3", HasilPengukuranT2_3.DefaultValue ?? DbNullValue); // DN
            row.Add("TotalGK", TotalGK.DefaultValue ?? DbNullValue); // DN
            row.Add("Selisih", Selisih.DefaultValue ?? DbNullValue); // DN
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

            // idProses
            idProses.RowCssClass = "row";

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // Produk
            Produk.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // NomorGerbongKertel
            NomorGerbongKertel.RowCssClass = "row";

            // MeterAwal
            MeterAwal.RowCssClass = "row";

            // MeterAkhir
            MeterAkhir.RowCssClass = "row";

            // Total
            Total.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // NoMeter
            NoMeter.RowCssClass = "row";

            // Quantity
            Quantity.RowCssClass = "row";

            // HasilPengukuranT2
            HasilPengukuranT2.RowCssClass = "row";

            // PICPengisian
            PICPengisian.RowCssClass = "row";

            // NomorGerbongKertel2
            NomorGerbongKertel2.RowCssClass = "row";

            // NomorGerbongKertel3
            NomorGerbongKertel3.RowCssClass = "row";

            // Quantity2
            Quantity2.RowCssClass = "row";

            // Quantity3
            Quantity3.RowCssClass = "row";

            // HasilPengukuranT2_2
            HasilPengukuranT2_2.RowCssClass = "row";

            // HasilPengukuranT2_3
            HasilPengukuranT2_3.RowCssClass = "row";

            // TotalGK
            TotalGK.RowCssClass = "row";

            // Selisih
            Selisih.RowCssClass = "row";

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

                // NoReferensi
                NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // Produk
                Produk.ViewValue = ConvertToString(Produk.CurrentValue); // DN
                Produk.ViewCustomAttributes = "";

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

                // NomorGerbongKertel
                NomorGerbongKertel.ViewValue = ConvertToString(NomorGerbongKertel.CurrentValue); // DN
                NomorGerbongKertel.ViewCustomAttributes = "";

                // MeterAwal
                MeterAwal.ViewValue = ConvertToString(MeterAwal.CurrentValue); // DN
                MeterAwal.ViewCustomAttributes = "";

                // MeterAkhir
                MeterAkhir.ViewValue = ConvertToString(MeterAkhir.CurrentValue); // DN
                MeterAkhir.ViewCustomAttributes = "";

                // Total
                Total.ViewValue = ConvertToString(Total.CurrentValue); // DN
                Total.ViewCustomAttributes = "";

                // userInput
                userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                userInput.ViewCustomAttributes = "";

                // etlDate
                etlDate.ViewValue = etlDate.CurrentValue;
                etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                etlDate.ViewCustomAttributes = "";

                // NoMeter
                NoMeter.ViewValue = ConvertToString(NoMeter.CurrentValue); // DN
                NoMeter.ViewCustomAttributes = "";

                // Quantity
                Quantity.ViewValue = ConvertToString(Quantity.CurrentValue); // DN
                Quantity.ViewCustomAttributes = "";

                // HasilPengukuranT2
                HasilPengukuranT2.ViewValue = ConvertToString(HasilPengukuranT2.CurrentValue); // DN
                HasilPengukuranT2.ViewCustomAttributes = "";

                // PICPengisian
                PICPengisian.ViewValue = ConvertToString(PICPengisian.CurrentValue); // DN
                PICPengisian.ViewCustomAttributes = "";

                // NomorGerbongKertel2
                NomorGerbongKertel2.ViewValue = ConvertToString(NomorGerbongKertel2.CurrentValue); // DN
                NomorGerbongKertel2.ViewCustomAttributes = "";

                // NomorGerbongKertel3
                NomorGerbongKertel3.ViewValue = ConvertToString(NomorGerbongKertel3.CurrentValue); // DN
                NomorGerbongKertel3.ViewCustomAttributes = "";

                // Quantity2
                Quantity2.ViewValue = ConvertToString(Quantity2.CurrentValue); // DN
                Quantity2.ViewCustomAttributes = "";

                // Quantity3
                Quantity3.ViewValue = ConvertToString(Quantity3.CurrentValue); // DN
                Quantity3.ViewCustomAttributes = "";

                // HasilPengukuranT2_2
                HasilPengukuranT2_2.ViewValue = ConvertToString(HasilPengukuranT2_2.CurrentValue); // DN
                HasilPengukuranT2_2.ViewCustomAttributes = "";

                // HasilPengukuranT2_3
                HasilPengukuranT2_3.ViewValue = ConvertToString(HasilPengukuranT2_3.CurrentValue); // DN
                HasilPengukuranT2_3.ViewCustomAttributes = "";

                // TotalGK
                TotalGK.ViewValue = ConvertToString(TotalGK.CurrentValue); // DN
                TotalGK.ViewCustomAttributes = "";

                // Selisih
                Selisih.ViewValue = ConvertToString(Selisih.CurrentValue); // DN
                Selisih.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // NomorGerbongKertel
                NomorGerbongKertel.HrefValue = "";

                // MeterAwal
                MeterAwal.HrefValue = "";

                // MeterAkhir
                MeterAkhir.HrefValue = "";

                // Total
                Total.HrefValue = "";

                // NoMeter
                NoMeter.HrefValue = "";

                // Quantity
                Quantity.HrefValue = "";

                // HasilPengukuranT2
                HasilPengukuranT2.HrefValue = "";

                // PICPengisian
                PICPengisian.HrefValue = "";

                // NomorGerbongKertel2
                NomorGerbongKertel2.HrefValue = "";

                // NomorGerbongKertel3
                NomorGerbongKertel3.HrefValue = "";

                // Quantity2
                Quantity2.HrefValue = "";

                // Quantity3
                Quantity3.HrefValue = "";

                // HasilPengukuranT2_2
                HasilPengukuranT2_2.HrefValue = "";

                // HasilPengukuranT2_3
                HasilPengukuranT2_3.HrefValue = "";

                // TotalGK
                TotalGK.HrefValue = "";

                // Selisih
                Selisih.HrefValue = "";
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

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                NoReferensi.EditValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // Produk
                Produk.SetupEditAttributes();
                if (!Produk.Raw)
                    Produk.CurrentValue = HtmlDecode(Produk.CurrentValue);
                Produk.EditValue = HtmlEncode(Produk.CurrentValue);
                Produk.PlaceHolder = RemoveHtml(Produk.Caption);

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

                // NomorGerbongKertel
                NomorGerbongKertel.SetupEditAttributes();
                if (!NomorGerbongKertel.Raw)
                    NomorGerbongKertel.CurrentValue = HtmlDecode(NomorGerbongKertel.CurrentValue);
                NomorGerbongKertel.EditValue = HtmlEncode(NomorGerbongKertel.CurrentValue);
                NomorGerbongKertel.PlaceHolder = RemoveHtml(NomorGerbongKertel.Caption);

                // MeterAwal
                MeterAwal.SetupEditAttributes();
                if (!MeterAwal.Raw)
                    MeterAwal.CurrentValue = HtmlDecode(MeterAwal.CurrentValue);
                MeterAwal.EditValue = HtmlEncode(MeterAwal.CurrentValue);
                MeterAwal.PlaceHolder = RemoveHtml(MeterAwal.Caption);

                // MeterAkhir
                MeterAkhir.SetupEditAttributes();
                if (!MeterAkhir.Raw)
                    MeterAkhir.CurrentValue = HtmlDecode(MeterAkhir.CurrentValue);
                MeterAkhir.EditValue = HtmlEncode(MeterAkhir.CurrentValue);
                MeterAkhir.PlaceHolder = RemoveHtml(MeterAkhir.Caption);

                // Total
                Total.SetupEditAttributes();
                if (!Total.Raw)
                    Total.CurrentValue = HtmlDecode(Total.CurrentValue);
                Total.EditValue = HtmlEncode(Total.CurrentValue);
                Total.PlaceHolder = RemoveHtml(Total.Caption);

                // NoMeter
                NoMeter.SetupEditAttributes();
                if (!NoMeter.Raw)
                    NoMeter.CurrentValue = HtmlDecode(NoMeter.CurrentValue);
                NoMeter.EditValue = HtmlEncode(NoMeter.CurrentValue);
                NoMeter.PlaceHolder = RemoveHtml(NoMeter.Caption);

                // Quantity
                Quantity.SetupEditAttributes();
                if (!Quantity.Raw)
                    Quantity.CurrentValue = HtmlDecode(Quantity.CurrentValue);
                Quantity.EditValue = HtmlEncode(Quantity.CurrentValue);
                Quantity.PlaceHolder = RemoveHtml(Quantity.Caption);

                // HasilPengukuranT2
                HasilPengukuranT2.SetupEditAttributes();
                if (!HasilPengukuranT2.Raw)
                    HasilPengukuranT2.CurrentValue = HtmlDecode(HasilPengukuranT2.CurrentValue);
                HasilPengukuranT2.EditValue = HtmlEncode(HasilPengukuranT2.CurrentValue);
                HasilPengukuranT2.PlaceHolder = RemoveHtml(HasilPengukuranT2.Caption);

                // PICPengisian
                PICPengisian.SetupEditAttributes();
                if (!PICPengisian.Raw)
                    PICPengisian.CurrentValue = HtmlDecode(PICPengisian.CurrentValue);
                PICPengisian.EditValue = HtmlEncode(PICPengisian.CurrentValue);
                PICPengisian.PlaceHolder = RemoveHtml(PICPengisian.Caption);

                // NomorGerbongKertel2
                NomorGerbongKertel2.SetupEditAttributes();
                if (!NomorGerbongKertel2.Raw)
                    NomorGerbongKertel2.CurrentValue = HtmlDecode(NomorGerbongKertel2.CurrentValue);
                NomorGerbongKertel2.EditValue = HtmlEncode(NomorGerbongKertel2.CurrentValue);
                NomorGerbongKertel2.PlaceHolder = RemoveHtml(NomorGerbongKertel2.Caption);

                // NomorGerbongKertel3
                NomorGerbongKertel3.SetupEditAttributes();
                if (!NomorGerbongKertel3.Raw)
                    NomorGerbongKertel3.CurrentValue = HtmlDecode(NomorGerbongKertel3.CurrentValue);
                NomorGerbongKertel3.EditValue = HtmlEncode(NomorGerbongKertel3.CurrentValue);
                NomorGerbongKertel3.PlaceHolder = RemoveHtml(NomorGerbongKertel3.Caption);

                // Quantity2
                Quantity2.SetupEditAttributes();
                if (!Quantity2.Raw)
                    Quantity2.CurrentValue = HtmlDecode(Quantity2.CurrentValue);
                Quantity2.EditValue = HtmlEncode(Quantity2.CurrentValue);
                Quantity2.PlaceHolder = RemoveHtml(Quantity2.Caption);

                // Quantity3
                Quantity3.SetupEditAttributes();
                if (!Quantity3.Raw)
                    Quantity3.CurrentValue = HtmlDecode(Quantity3.CurrentValue);
                Quantity3.EditValue = HtmlEncode(Quantity3.CurrentValue);
                Quantity3.PlaceHolder = RemoveHtml(Quantity3.Caption);

                // HasilPengukuranT2_2
                HasilPengukuranT2_2.SetupEditAttributes();
                if (!HasilPengukuranT2_2.Raw)
                    HasilPengukuranT2_2.CurrentValue = HtmlDecode(HasilPengukuranT2_2.CurrentValue);
                HasilPengukuranT2_2.EditValue = HtmlEncode(HasilPengukuranT2_2.CurrentValue);
                HasilPengukuranT2_2.PlaceHolder = RemoveHtml(HasilPengukuranT2_2.Caption);

                // HasilPengukuranT2_3
                HasilPengukuranT2_3.SetupEditAttributes();
                if (!HasilPengukuranT2_3.Raw)
                    HasilPengukuranT2_3.CurrentValue = HtmlDecode(HasilPengukuranT2_3.CurrentValue);
                HasilPengukuranT2_3.EditValue = HtmlEncode(HasilPengukuranT2_3.CurrentValue);
                HasilPengukuranT2_3.PlaceHolder = RemoveHtml(HasilPengukuranT2_3.Caption);

                // TotalGK
                TotalGK.SetupEditAttributes();
                if (!TotalGK.Raw)
                    TotalGK.CurrentValue = HtmlDecode(TotalGK.CurrentValue);
                TotalGK.EditValue = HtmlEncode(TotalGK.CurrentValue);
                TotalGK.PlaceHolder = RemoveHtml(TotalGK.Caption);

                // Selisih
                Selisih.SetupEditAttributes();
                if (!Selisih.Raw)
                    Selisih.CurrentValue = HtmlDecode(Selisih.CurrentValue);
                Selisih.EditValue = HtmlEncode(Selisih.CurrentValue);
                Selisih.PlaceHolder = RemoveHtml(Selisih.Caption);

                // Edit refer script

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // NomorGerbongKertel
                NomorGerbongKertel.HrefValue = "";

                // MeterAwal
                MeterAwal.HrefValue = "";

                // MeterAkhir
                MeterAkhir.HrefValue = "";

                // Total
                Total.HrefValue = "";

                // NoMeter
                NoMeter.HrefValue = "";

                // Quantity
                Quantity.HrefValue = "";

                // HasilPengukuranT2
                HasilPengukuranT2.HrefValue = "";

                // PICPengisian
                PICPengisian.HrefValue = "";

                // NomorGerbongKertel2
                NomorGerbongKertel2.HrefValue = "";

                // NomorGerbongKertel3
                NomorGerbongKertel3.HrefValue = "";

                // Quantity2
                Quantity2.HrefValue = "";

                // Quantity3
                Quantity3.HrefValue = "";

                // HasilPengukuranT2_2
                HasilPengukuranT2_2.HrefValue = "";

                // HasilPengukuranT2_3
                HasilPengukuranT2_3.HrefValue = "";

                // TotalGK
                TotalGK.HrefValue = "";

                // Selisih
                Selisih.HrefValue = "";
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
                if (idAktifitas.Visible && idAktifitas.Required) {
                    if (!idAktifitas.IsDetailKey && Empty(idAktifitas.FormValue)) {
                        idAktifitas.AddErrorMessage(ConvertToString(idAktifitas.RequiredErrorMessage).Replace("%s", idAktifitas.Caption));
                    }
                }
                if (idProses.Visible && idProses.Required) {
                    if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                        idProses.AddErrorMessage(ConvertToString(idProses.RequiredErrorMessage).Replace("%s", idProses.Caption));
                    }
                }
                if (NoReferensi.Visible && NoReferensi.Required) {
                    if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                        NoReferensi.AddErrorMessage(ConvertToString(NoReferensi.RequiredErrorMessage).Replace("%s", NoReferensi.Caption));
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
                if (NomorGerbongKertel.Visible && NomorGerbongKertel.Required) {
                    if (!NomorGerbongKertel.IsDetailKey && Empty(NomorGerbongKertel.FormValue)) {
                        NomorGerbongKertel.AddErrorMessage(ConvertToString(NomorGerbongKertel.RequiredErrorMessage).Replace("%s", NomorGerbongKertel.Caption));
                    }
                }
                if (MeterAwal.Visible && MeterAwal.Required) {
                    if (!MeterAwal.IsDetailKey && Empty(MeterAwal.FormValue)) {
                        MeterAwal.AddErrorMessage(ConvertToString(MeterAwal.RequiredErrorMessage).Replace("%s", MeterAwal.Caption));
                    }
                }
                if (MeterAkhir.Visible && MeterAkhir.Required) {
                    if (!MeterAkhir.IsDetailKey && Empty(MeterAkhir.FormValue)) {
                        MeterAkhir.AddErrorMessage(ConvertToString(MeterAkhir.RequiredErrorMessage).Replace("%s", MeterAkhir.Caption));
                    }
                }
                if (Total.Visible && Total.Required) {
                    if (!Total.IsDetailKey && Empty(Total.FormValue)) {
                        Total.AddErrorMessage(ConvertToString(Total.RequiredErrorMessage).Replace("%s", Total.Caption));
                    }
                }
                if (NoMeter.Visible && NoMeter.Required) {
                    if (!NoMeter.IsDetailKey && Empty(NoMeter.FormValue)) {
                        NoMeter.AddErrorMessage(ConvertToString(NoMeter.RequiredErrorMessage).Replace("%s", NoMeter.Caption));
                    }
                }
                if (Quantity.Visible && Quantity.Required) {
                    if (!Quantity.IsDetailKey && Empty(Quantity.FormValue)) {
                        Quantity.AddErrorMessage(ConvertToString(Quantity.RequiredErrorMessage).Replace("%s", Quantity.Caption));
                    }
                }
                if (HasilPengukuranT2.Visible && HasilPengukuranT2.Required) {
                    if (!HasilPengukuranT2.IsDetailKey && Empty(HasilPengukuranT2.FormValue)) {
                        HasilPengukuranT2.AddErrorMessage(ConvertToString(HasilPengukuranT2.RequiredErrorMessage).Replace("%s", HasilPengukuranT2.Caption));
                    }
                }
                if (PICPengisian.Visible && PICPengisian.Required) {
                    if (!PICPengisian.IsDetailKey && Empty(PICPengisian.FormValue)) {
                        PICPengisian.AddErrorMessage(ConvertToString(PICPengisian.RequiredErrorMessage).Replace("%s", PICPengisian.Caption));
                    }
                }
                if (NomorGerbongKertel2.Visible && NomorGerbongKertel2.Required) {
                    if (!NomorGerbongKertel2.IsDetailKey && Empty(NomorGerbongKertel2.FormValue)) {
                        NomorGerbongKertel2.AddErrorMessage(ConvertToString(NomorGerbongKertel2.RequiredErrorMessage).Replace("%s", NomorGerbongKertel2.Caption));
                    }
                }
                if (NomorGerbongKertel3.Visible && NomorGerbongKertel3.Required) {
                    if (!NomorGerbongKertel3.IsDetailKey && Empty(NomorGerbongKertel3.FormValue)) {
                        NomorGerbongKertel3.AddErrorMessage(ConvertToString(NomorGerbongKertel3.RequiredErrorMessage).Replace("%s", NomorGerbongKertel3.Caption));
                    }
                }
                if (Quantity2.Visible && Quantity2.Required) {
                    if (!Quantity2.IsDetailKey && Empty(Quantity2.FormValue)) {
                        Quantity2.AddErrorMessage(ConvertToString(Quantity2.RequiredErrorMessage).Replace("%s", Quantity2.Caption));
                    }
                }
                if (Quantity3.Visible && Quantity3.Required) {
                    if (!Quantity3.IsDetailKey && Empty(Quantity3.FormValue)) {
                        Quantity3.AddErrorMessage(ConvertToString(Quantity3.RequiredErrorMessage).Replace("%s", Quantity3.Caption));
                    }
                }
                if (HasilPengukuranT2_2.Visible && HasilPengukuranT2_2.Required) {
                    if (!HasilPengukuranT2_2.IsDetailKey && Empty(HasilPengukuranT2_2.FormValue)) {
                        HasilPengukuranT2_2.AddErrorMessage(ConvertToString(HasilPengukuranT2_2.RequiredErrorMessage).Replace("%s", HasilPengukuranT2_2.Caption));
                    }
                }
                if (HasilPengukuranT2_3.Visible && HasilPengukuranT2_3.Required) {
                    if (!HasilPengukuranT2_3.IsDetailKey && Empty(HasilPengukuranT2_3.FormValue)) {
                        HasilPengukuranT2_3.AddErrorMessage(ConvertToString(HasilPengukuranT2_3.RequiredErrorMessage).Replace("%s", HasilPengukuranT2_3.Caption));
                    }
                }
                if (TotalGK.Visible && TotalGK.Required) {
                    if (!TotalGK.IsDetailKey && Empty(TotalGK.FormValue)) {
                        TotalGK.AddErrorMessage(ConvertToString(TotalGK.RequiredErrorMessage).Replace("%s", TotalGK.Caption));
                    }
                }
                if (Selisih.Visible && Selisih.Required) {
                    if (!Selisih.IsDetailKey && Empty(Selisih.FormValue)) {
                        Selisih.AddErrorMessage(ConvertToString(Selisih.RequiredErrorMessage).Replace("%s", Selisih.Caption));
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

            // Produk
            Produk.SetDbValue(rsnew, Produk.CurrentValue, Produk.ReadOnly);

            // NomorGerbongKertel
            NomorGerbongKertel.SetDbValue(rsnew, NomorGerbongKertel.CurrentValue, NomorGerbongKertel.ReadOnly);

            // MeterAwal
            MeterAwal.SetDbValue(rsnew, MeterAwal.CurrentValue, MeterAwal.ReadOnly);

            // MeterAkhir
            MeterAkhir.SetDbValue(rsnew, MeterAkhir.CurrentValue, MeterAkhir.ReadOnly);

            // Total
            Total.SetDbValue(rsnew, Total.CurrentValue, Total.ReadOnly);

            // NoMeter
            NoMeter.SetDbValue(rsnew, NoMeter.CurrentValue, NoMeter.ReadOnly);

            // Quantity
            Quantity.SetDbValue(rsnew, Quantity.CurrentValue, Quantity.ReadOnly);

            // HasilPengukuranT2
            HasilPengukuranT2.SetDbValue(rsnew, HasilPengukuranT2.CurrentValue, HasilPengukuranT2.ReadOnly);

            // PICPengisian
            PICPengisian.SetDbValue(rsnew, PICPengisian.CurrentValue, PICPengisian.ReadOnly);

            // NomorGerbongKertel2
            NomorGerbongKertel2.SetDbValue(rsnew, NomorGerbongKertel2.CurrentValue, NomorGerbongKertel2.ReadOnly);

            // NomorGerbongKertel3
            NomorGerbongKertel3.SetDbValue(rsnew, NomorGerbongKertel3.CurrentValue, NomorGerbongKertel3.ReadOnly);

            // Quantity2
            Quantity2.SetDbValue(rsnew, Quantity2.CurrentValue, Quantity2.ReadOnly);

            // Quantity3
            Quantity3.SetDbValue(rsnew, Quantity3.CurrentValue, Quantity3.ReadOnly);

            // HasilPengukuranT2_2
            HasilPengukuranT2_2.SetDbValue(rsnew, HasilPengukuranT2_2.CurrentValue, HasilPengukuranT2_2.ReadOnly);

            // HasilPengukuranT2_3
            HasilPengukuranT2_3.SetDbValue(rsnew, HasilPengukuranT2_3.CurrentValue, HasilPengukuranT2_3.ReadOnly);

            // TotalGK
            TotalGK.SetDbValue(rsnew, TotalGK.CurrentValue, TotalGK.ReadOnly);

            // Selisih
            Selisih.SetDbValue(rsnew, Selisih.CurrentValue, Selisih.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Produk", out value)) // Produk
                Produk.CurrentValue = value;
            if (row.TryGetValue("NomorGerbongKertel", out value)) // NomorGerbongKertel
                NomorGerbongKertel.CurrentValue = value;
            if (row.TryGetValue("MeterAwal", out value)) // MeterAwal
                MeterAwal.CurrentValue = value;
            if (row.TryGetValue("MeterAkhir", out value)) // MeterAkhir
                MeterAkhir.CurrentValue = value;
            if (row.TryGetValue("Total", out value)) // Total
                Total.CurrentValue = value;
            if (row.TryGetValue("NoMeter", out value)) // NoMeter
                NoMeter.CurrentValue = value;
            if (row.TryGetValue("Quantity", out value)) // Quantity
                Quantity.CurrentValue = value;
            if (row.TryGetValue("HasilPengukuranT2", out value)) // HasilPengukuranT2
                HasilPengukuranT2.CurrentValue = value;
            if (row.TryGetValue("PICPengisian", out value)) // PICPengisian
                PICPengisian.CurrentValue = value;
            if (row.TryGetValue("NomorGerbongKertel2", out value)) // NomorGerbongKertel2
                NomorGerbongKertel2.CurrentValue = value;
            if (row.TryGetValue("NomorGerbongKertel3", out value)) // NomorGerbongKertel3
                NomorGerbongKertel3.CurrentValue = value;
            if (row.TryGetValue("Quantity2", out value)) // Quantity2
                Quantity2.CurrentValue = value;
            if (row.TryGetValue("Quantity3", out value)) // Quantity3
                Quantity3.CurrentValue = value;
            if (row.TryGetValue("HasilPengukuranT2_2", out value)) // HasilPengukuranT2_2
                HasilPengukuranT2_2.CurrentValue = value;
            if (row.TryGetValue("HasilPengukuranT2_3", out value)) // HasilPengukuranT2_3
                HasilPengukuranT2_3.CurrentValue = value;
            if (row.TryGetValue("TotalGK", out value)) // TotalGK
                TotalGK.CurrentValue = value;
            if (row.TryGetValue("Selisih", out value)) // Selisih
                Selisih.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasInputDataRtwList")), "", TableVar, true);
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
