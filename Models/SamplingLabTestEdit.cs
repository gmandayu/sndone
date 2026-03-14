namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// samplingLabTestEdit
    /// </summary>
    public static SamplingLabTestEdit samplingLabTestEdit
    {
        get => HttpData.Get<SamplingLabTestEdit>("samplingLabTestEdit")!;
        set => HttpData["samplingLabTestEdit"] = value;
    }

    /// <summary>
    /// Page class for SamplingLabTest
    /// </summary>
    public class SamplingLabTestEdit : SamplingLabTestEditBase
    {
        // Constructor
        public SamplingLabTestEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SamplingLabTestEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            IdPlant.DisplayValueSeparator = " - ";
            KodeProduk.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SamplingLabTestEditBase : SamplingLabTest
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "samplingLabTestEdit";

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
        public SamplingLabTestEditBase()
        {
            TableName = "SamplingLabTest";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (samplingLabTest)
            if (samplingLabTest == null || samplingLabTest is SamplingLabTest)
                samplingLabTest = this;

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
        public string PageName => "SamplingLabTestEdit";

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
            IdSamplingLabTest.Visible = false;
            NomorSamplingLabTest.SetVisibility();
            LinkProses.Visible = false;
            LookupPlant.SetVisibility();
            IdPlant.SetVisibility();
            LookupIdReferensi.Visible = false;
            IdReferensi.SetVisibility();
            IdPenimbunan.Visible = false;
            IdTemplate.Visible = false;
            StatusProses.Visible = false;
            PersentaseProgress.Visible = false;
            IdModa.SetVisibility();
            TipePenyaluran.SetVisibility();
            KategoriPenyaluran.SetVisibility();
            NomorPolisi.SetVisibility();
            TipeProdukSTS.SetVisibility();
            KodeProduk.SetVisibility();
            Tujuan.SetVisibility();
            Catatan.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            LookupTipeProduk.SetVisibility();
            LookupJenisPlant.SetVisibility();
        }

        // Constructor
        public SamplingLabTestEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "SamplingLabTestView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdSamplingLabTest") ? dict["IdSamplingLabTest"] : IdSamplingLabTest.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdSamplingLabTest.Visible = false;
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
            NomorSamplingLabTest.Required = false;
            LookupPlant.Required = false;
            IdPlant.Required = false;
            IdReferensi.Required = false;
            KodeProduk.Required = false;

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
            await SetupLookupOptions(LookupPlant);
            await SetupLookupOptions(IdPlant);
            await SetupLookupOptions(LookupIdReferensi);
            await SetupLookupOptions(IdModa);
            await SetupLookupOptions(TipePenyaluran);
            await SetupLookupOptions(KategoriPenyaluran);
            await SetupLookupOptions(TipeProdukSTS);
            await SetupLookupOptions(KodeProduk);

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
                if (RouteValues.TryGetValue("IdSamplingLabTest", out rv)) { // DN
                    IdSamplingLabTest.FormValue = UrlDecode(rv); // DN
                    IdSamplingLabTest.OldValue = IdSamplingLabTest.FormValue;
                } else if (CurrentForm.HasValue("x_IdSamplingLabTest")) {
                    IdSamplingLabTest.FormValue = CurrentForm.GetValue("x_IdSamplingLabTest");
                    IdSamplingLabTest.OldValue = IdSamplingLabTest.FormValue;
                } else if (!Empty(keyValues)) {
                    IdSamplingLabTest.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("IdSamplingLabTest", out rv)) { // DN
                        IdSamplingLabTest.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("IdSamplingLabTest", out sv)) {
                        IdSamplingLabTest.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdSamplingLabTest.CurrentValue = DbNullValue;
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
                IdSamplingLabTest.FormValue = ConvertToString(keyValues[0]);
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
                            return Terminate("SamplingLabTestList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = "SamplingLabTestList";
                    if (GetPageName(returnUrl) == "SamplingLabTestList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SamplingLabTestList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SamplingLabTestList"; // Return list page content
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
                samplingLabTestEdit?.PageRender();
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

            // Check field name 'NomorSamplingLabTest' before field var 'x_NomorSamplingLabTest'
            val = CurrentForm.HasValue("NomorSamplingLabTest") ? CurrentForm.GetValue("NomorSamplingLabTest") : CurrentForm.GetValue("x_NomorSamplingLabTest");
            if (!NomorSamplingLabTest.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorSamplingLabTest") && !CurrentForm.HasValue("x_NomorSamplingLabTest")) // DN
                    NomorSamplingLabTest.Visible = false; // Disable update for API request
                else
                    NomorSamplingLabTest.SetFormValue(val);
            }

            // Check field name 'LookupPlant' before field var 'x_LookupPlant'
            val = CurrentForm.HasValue("LookupPlant") ? CurrentForm.GetValue("LookupPlant") : CurrentForm.GetValue("x_LookupPlant");
            if (!LookupPlant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LookupPlant") && !CurrentForm.HasValue("x_LookupPlant")) // DN
                    LookupPlant.Visible = false; // Disable update for API request
                else
                    LookupPlant.SetFormValue(val);
            }

            // Check field name 'IdPlant' before field var 'x_IdPlant'
            val = CurrentForm.HasValue("IdPlant") ? CurrentForm.GetValue("IdPlant") : CurrentForm.GetValue("x_IdPlant");
            if (!IdPlant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPlant") && !CurrentForm.HasValue("x_IdPlant")) // DN
                    IdPlant.Visible = false; // Disable update for API request
                else
                    IdPlant.SetFormValue(val);
            }

            // Check field name 'IdReferensi' before field var 'x_IdReferensi'
            val = CurrentForm.HasValue("IdReferensi") ? CurrentForm.GetValue("IdReferensi") : CurrentForm.GetValue("x_IdReferensi");
            if (!IdReferensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdReferensi") && !CurrentForm.HasValue("x_IdReferensi")) // DN
                    IdReferensi.Visible = false; // Disable update for API request
                else
                    IdReferensi.SetFormValue(val);
            }

            // Check field name 'IdModa' before field var 'x_IdModa'
            val = CurrentForm.HasValue("IdModa") ? CurrentForm.GetValue("IdModa") : CurrentForm.GetValue("x_IdModa");
            if (!IdModa.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdModa") && !CurrentForm.HasValue("x_IdModa")) // DN
                    IdModa.Visible = false; // Disable update for API request
                else
                    IdModa.SetFormValue(val);
            }

            // Check field name 'TipePenyaluran' before field var 'x_TipePenyaluran'
            val = CurrentForm.HasValue("TipePenyaluran") ? CurrentForm.GetValue("TipePenyaluran") : CurrentForm.GetValue("x_TipePenyaluran");
            if (!TipePenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipePenyaluran") && !CurrentForm.HasValue("x_TipePenyaluran")) // DN
                    TipePenyaluran.Visible = false; // Disable update for API request
                else
                    TipePenyaluran.SetFormValue(val);
            }

            // Check field name 'KategoriPenyaluran' before field var 'x_KategoriPenyaluran'
            val = CurrentForm.HasValue("KategoriPenyaluran") ? CurrentForm.GetValue("KategoriPenyaluran") : CurrentForm.GetValue("x_KategoriPenyaluran");
            if (!KategoriPenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("KategoriPenyaluran") && !CurrentForm.HasValue("x_KategoriPenyaluran")) // DN
                    KategoriPenyaluran.Visible = false; // Disable update for API request
                else
                    KategoriPenyaluran.SetFormValue(val);
            }

            // Check field name 'NomorPolisi' before field var 'x_NomorPolisi'
            val = CurrentForm.HasValue("NomorPolisi") ? CurrentForm.GetValue("NomorPolisi") : CurrentForm.GetValue("x_NomorPolisi");
            if (!NomorPolisi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorPolisi") && !CurrentForm.HasValue("x_NomorPolisi")) // DN
                    NomorPolisi.Visible = false; // Disable update for API request
                else
                    NomorPolisi.SetFormValue(val);
            }

            // Check field name 'TipeProdukSTS' before field var 'x_TipeProdukSTS'
            val = CurrentForm.HasValue("TipeProdukSTS") ? CurrentForm.GetValue("TipeProdukSTS") : CurrentForm.GetValue("x_TipeProdukSTS");
            if (!TipeProdukSTS.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipeProdukSTS") && !CurrentForm.HasValue("x_TipeProdukSTS")) // DN
                    TipeProdukSTS.Visible = false; // Disable update for API request
                else
                    TipeProdukSTS.SetFormValue(val);
            }

            // Check field name 'KodeProduk' before field var 'x_KodeProduk'
            val = CurrentForm.HasValue("KodeProduk") ? CurrentForm.GetValue("KodeProduk") : CurrentForm.GetValue("x_KodeProduk");
            if (!KodeProduk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("KodeProduk") && !CurrentForm.HasValue("x_KodeProduk")) // DN
                    KodeProduk.Visible = false; // Disable update for API request
                else
                    KodeProduk.SetFormValue(val);
            }

            // Check field name 'Tujuan' before field var 'x_Tujuan'
            val = CurrentForm.HasValue("Tujuan") ? CurrentForm.GetValue("Tujuan") : CurrentForm.GetValue("x_Tujuan");
            if (!Tujuan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Tujuan") && !CurrentForm.HasValue("x_Tujuan")) // DN
                    Tujuan.Visible = false; // Disable update for API request
                else
                    Tujuan.SetFormValue(val);
            }

            // Check field name 'Catatan' before field var 'x_Catatan'
            val = CurrentForm.HasValue("Catatan") ? CurrentForm.GetValue("Catatan") : CurrentForm.GetValue("x_Catatan");
            if (!Catatan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Catatan") && !CurrentForm.HasValue("x_Catatan")) // DN
                    Catatan.Visible = false; // Disable update for API request
                else
                    Catatan.SetFormValue(val);
            }

            // Check field name 'LookupTipeProduk' before field var 'x_LookupTipeProduk'
            val = CurrentForm.HasValue("LookupTipeProduk") ? CurrentForm.GetValue("LookupTipeProduk") : CurrentForm.GetValue("x_LookupTipeProduk");
            if (!LookupTipeProduk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LookupTipeProduk") && !CurrentForm.HasValue("x_LookupTipeProduk")) // DN
                    LookupTipeProduk.Visible = false; // Disable update for API request
                else
                    LookupTipeProduk.SetFormValue(val);
            }

            // Check field name 'LookupJenisPlant' before field var 'x_LookupJenisPlant'
            val = CurrentForm.HasValue("LookupJenisPlant") ? CurrentForm.GetValue("LookupJenisPlant") : CurrentForm.GetValue("x_LookupJenisPlant");
            if (!LookupJenisPlant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LookupJenisPlant") && !CurrentForm.HasValue("x_LookupJenisPlant")) // DN
                    LookupJenisPlant.Visible = false; // Disable update for API request
                else
                    LookupJenisPlant.SetFormValue(val);
            }

            // Check field name 'IdSamplingLabTest' before field var 'x_IdSamplingLabTest'
            val = CurrentForm.HasValue("IdSamplingLabTest") ? CurrentForm.GetValue("IdSamplingLabTest") : CurrentForm.GetValue("x_IdSamplingLabTest");
            if (!IdSamplingLabTest.IsDetailKey)
                IdSamplingLabTest.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdSamplingLabTest.CurrentValue = IdSamplingLabTest.FormValue;
            NomorSamplingLabTest.CurrentValue = NomorSamplingLabTest.FormValue;
            LookupPlant.CurrentValue = LookupPlant.FormValue;
            IdPlant.CurrentValue = IdPlant.FormValue;
            IdReferensi.CurrentValue = IdReferensi.FormValue;
            IdModa.CurrentValue = IdModa.FormValue;
            TipePenyaluran.CurrentValue = TipePenyaluran.FormValue;
            KategoriPenyaluran.CurrentValue = KategoriPenyaluran.FormValue;
            NomorPolisi.CurrentValue = NomorPolisi.FormValue;
            TipeProdukSTS.CurrentValue = TipeProdukSTS.FormValue;
            KodeProduk.CurrentValue = KodeProduk.FormValue;
            Tujuan.CurrentValue = Tujuan.FormValue;
            Catatan.CurrentValue = Catatan.FormValue;
            LookupTipeProduk.CurrentValue = LookupTipeProduk.FormValue;
            LookupJenisPlant.CurrentValue = LookupJenisPlant.FormValue;
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
            IdSamplingLabTest.SetDbValue(row["IdSamplingLabTest"]);
            NomorSamplingLabTest.SetDbValue(row["NomorSamplingLabTest"]);
            LinkProses.SetDbValue(row["LinkProses"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            LookupIdReferensi.SetDbValue(row["LookupIdReferensi"]);
            IdReferensi.SetDbValue(row["IdReferensi"]);
            IdPenimbunan.SetDbValue(row["IdPenimbunan"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            IdModa.SetDbValue(row["IdModa"]);
            TipePenyaluran.SetDbValue(row["TipePenyaluran"]);
            KategoriPenyaluran.SetDbValue(row["KategoriPenyaluran"]);
            NomorPolisi.SetDbValue(row["NomorPolisi"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            KodeProduk.SetDbValue(row["KodeProduk"]);
            Tujuan.SetDbValue(row["Tujuan"]);
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            LookupTipeProduk.SetDbValue(row["LookupTipeProduk"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdSamplingLabTest", IdSamplingLabTest.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorSamplingLabTest", NomorSamplingLabTest.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkProses", LinkProses.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupIdReferensi", LookupIdReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("IdReferensi", IdReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPenimbunan", IdPenimbunan.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("IdModa", IdModa.DefaultValue ?? DbNullValue); // DN
            row.Add("TipePenyaluran", TipePenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("KategoriPenyaluran", KategoriPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPolisi", NomorPolisi.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("KodeProduk", KodeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("Tujuan", Tujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("Catatan", Catatan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupTipeProduk", LookupTipeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupJenisPlant", LookupJenisPlant.DefaultValue ?? DbNullValue); // DN
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

            // IdSamplingLabTest
            IdSamplingLabTest.RowCssClass = "row";

            // NomorSamplingLabTest
            NomorSamplingLabTest.RowCssClass = "row";

            // LinkProses
            LinkProses.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // LookupIdReferensi
            LookupIdReferensi.RowCssClass = "row";

            // IdReferensi
            IdReferensi.RowCssClass = "row";

            // IdPenimbunan
            IdPenimbunan.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

            // PersentaseProgress
            PersentaseProgress.RowCssClass = "row";

            // IdModa
            IdModa.RowCssClass = "row";

            // TipePenyaluran
            TipePenyaluran.RowCssClass = "row";

            // KategoriPenyaluran
            KategoriPenyaluran.RowCssClass = "row";

            // NomorPolisi
            NomorPolisi.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // KodeProduk
            KodeProduk.RowCssClass = "row";

            // Tujuan
            Tujuan.RowCssClass = "row";

            // Catatan
            Catatan.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaruiOleh
            DiperbaruiOleh.RowCssClass = "row";

            // TanggalDiperbarui
            TanggalDiperbarui.RowCssClass = "row";

            // LookupTipeProduk
            LookupTipeProduk.RowCssClass = "row";

            // LookupJenisPlant
            LookupJenisPlant.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdSamplingLabTest
                IdSamplingLabTest.ViewValue = IdSamplingLabTest.CurrentValue;
                IdSamplingLabTest.ViewCustomAttributes = "";

                // NomorSamplingLabTest
                NomorSamplingLabTest.ViewValue = ConvertToString(NomorSamplingLabTest.CurrentValue); // DN
                NomorSamplingLabTest.ViewCustomAttributes = "";

                // LinkProses
                LinkProses.ViewValue = ConvertToString(LinkProses.CurrentValue); // DN
                LinkProses.ViewCustomAttributes = "";

                // LookupPlant
                if (!Empty(LookupPlant.CurrentValue)) {
                    LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                } else {
                    LookupPlant.ViewValue = DbNullValue;
                }
                LookupPlant.ViewCustomAttributes = "";

                // IdPlant
                IdPlant.ViewValue = IdPlant.CurrentValue;
                string curVal2 = ConvertToString(IdPlant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (IdPlant.Lookup != null && IsDictionary(IdPlant.Lookup?.Options) && IdPlant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPlant.ViewValue = IdPlant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", IdPlant.CurrentValue, IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = IdPlant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && IdPlant.Lookup != null) { // Lookup values found
                            var listwrk = IdPlant.Lookup?.RenderViewRow(rswrk2[0]);
                            IdPlant.ViewValue = IdPlant.DisplayValue(listwrk);
                        } else {
                            IdPlant.ViewValue = FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
                        }
                    }
                } else {
                    IdPlant.ViewValue = DbNullValue;
                }
                IdPlant.ViewCustomAttributes = "";

                // IdReferensi
                IdReferensi.ViewValue = ConvertToString(IdReferensi.CurrentValue); // DN
                IdReferensi.ViewCustomAttributes = "";

                // IdPenimbunan
                IdPenimbunan.ViewValue = IdPenimbunan.CurrentValue;
                IdPenimbunan.ViewValue = FormatNumber(IdPenimbunan.ViewValue, IdPenimbunan.FormatPattern);
                IdPenimbunan.ViewCustomAttributes = "";

                // IdTemplate
                IdTemplate.ViewValue = IdTemplate.CurrentValue;
                IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
                IdTemplate.ViewCustomAttributes = "";

                // StatusProses
                StatusProses.ViewValue = StatusProses.CurrentValue;
                StatusProses.ViewCustomAttributes = "";

                // PersentaseProgress
                PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                PersentaseProgress.ViewCustomAttributes = "";

                // IdModa
                string curVal4 = ConvertToString(IdModa.CurrentValue);
                if (!Empty(curVal4)) {
                    if (IdModa.Lookup != null && IsDictionary(IdModa.Lookup?.Options) && IdModa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdModa.ViewValue = IdModa.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", IdModa.CurrentValue, IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                        string? sqlWrk4 = IdModa.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && IdModa.Lookup != null) { // Lookup values found
                            var listwrk = IdModa.Lookup?.RenderViewRow(rswrk4[0]);
                            IdModa.ViewValue = IdModa.DisplayValue(listwrk);
                        } else {
                            IdModa.ViewValue = FormatNumber(IdModa.CurrentValue, IdModa.FormatPattern);
                        }
                    }
                } else {
                    IdModa.ViewValue = DbNullValue;
                }
                IdModa.ViewCustomAttributes = "";

                // TipePenyaluran
                if (!Empty(TipePenyaluran.CurrentValue)) {
                    TipePenyaluran.ViewValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
                } else {
                    TipePenyaluran.ViewValue = DbNullValue;
                }
                TipePenyaluran.ViewCustomAttributes = "";

                // KategoriPenyaluran
                if (!Empty(KategoriPenyaluran.CurrentValue)) {
                    KategoriPenyaluran.ViewValue = KategoriPenyaluran.OptionCaption(ConvertToString(KategoriPenyaluran.CurrentValue));
                } else {
                    KategoriPenyaluran.ViewValue = DbNullValue;
                }
                KategoriPenyaluran.ViewCustomAttributes = "";

                // NomorPolisi
                NomorPolisi.ViewValue = ConvertToString(NomorPolisi.CurrentValue); // DN
                NomorPolisi.ViewCustomAttributes = "";

                // TipeProdukSTS
                List<object?>? listWrk7 = [ // DN
                    TipeProdukSTS.CurrentValue,
                    TipeProdukSTS.CurrentValue,
                ];
                listWrk7 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk7, this);
                string? dispVal7 = TipeProdukSTS.DisplayValue(listWrk7);
                if (!Empty(dispVal7))
                    TipeProdukSTS.ViewValue = dispVal7;
                TipeProdukSTS.ViewCustomAttributes = "";

                // KodeProduk
                string curVal8 = ConvertToString(KodeProduk.CurrentValue);
                if (!Empty(curVal8)) {
                    if (KodeProduk.Lookup != null && IsDictionary(KodeProduk.Lookup?.Options) && KodeProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        KodeProduk.ViewValue = KodeProduk.LookupCacheOption(curVal8);
                    } else { // Lookup from database // DN
                        string filterWrk8 = SearchFilter(KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", KodeProduk.CurrentValue, KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                        string? sqlWrk8 = KodeProduk.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk8?.Count > 0 && KodeProduk.Lookup != null) { // Lookup values found
                            var listwrk = KodeProduk.Lookup?.RenderViewRow(rswrk8[0]);
                            KodeProduk.ViewValue = KodeProduk.DisplayValue(listwrk);
                        } else {
                            KodeProduk.ViewValue = KodeProduk.CurrentValue;
                        }
                    }
                } else {
                    KodeProduk.ViewValue = DbNullValue;
                }
                KodeProduk.ViewCustomAttributes = "";

                // Tujuan
                Tujuan.ViewValue = ConvertToString(Tujuan.CurrentValue); // DN
                Tujuan.ViewCustomAttributes = "";

                // Catatan
                Catatan.ViewValue = Catatan.CurrentValue;
                Catatan.ViewCustomAttributes = "";

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

                // LookupTipeProduk
                LookupTipeProduk.ViewValue = LookupTipeProduk.CurrentValue;
                LookupTipeProduk.ViewCustomAttributes = "";

                // LookupJenisPlant
                LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
                LookupJenisPlant.ViewCustomAttributes = "";

                // NomorSamplingLabTest
                NomorSamplingLabTest.HrefValue = "";
                NomorSamplingLabTest.TooltipValue = "";

                // LookupPlant
                LookupPlant.HrefValue = "";
                LookupPlant.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // IdReferensi
                IdReferensi.HrefValue = "";
                IdReferensi.TooltipValue = "";

                // IdModa
                IdModa.HrefValue = "";
                IdModa.TooltipValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";
                TipePenyaluran.TooltipValue = "";

                // KategoriPenyaluran
                KategoriPenyaluran.HrefValue = "";
                KategoriPenyaluran.TooltipValue = "";

                // NomorPolisi
                NomorPolisi.HrefValue = "";
                NomorPolisi.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // KodeProduk
                KodeProduk.HrefValue = "";
                KodeProduk.TooltipValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";
                LookupTipeProduk.TooltipValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
                LookupJenisPlant.TooltipValue = "";
            } else if (RowType == RowType.Edit) {
                // NomorSamplingLabTest
                NomorSamplingLabTest.SetupEditAttributes();
                NomorSamplingLabTest.EditValue = ConvertToString(NomorSamplingLabTest.CurrentValue); // DN
                NomorSamplingLabTest.ViewCustomAttributes = "";

                // LookupPlant
                LookupPlant.SetupEditAttributes();
                if (!Empty(LookupPlant.CurrentValue)) {
                    LookupPlant.EditValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                } else {
                    LookupPlant.EditValue = DbNullValue;
                }
                LookupPlant.ViewCustomAttributes = "";

                // IdPlant
                IdPlant.SetupEditAttributes();
                IdPlant.EditValue = IdPlant.CurrentValue;
                string curVal2 = ConvertToString(IdPlant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (IdPlant.Lookup != null && IsDictionary(IdPlant.Lookup?.Options) && IdPlant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPlant.EditValue = IdPlant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", IdPlant.CurrentValue, IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = IdPlant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && IdPlant.Lookup != null) { // Lookup values found
                            var listwrk = IdPlant.Lookup?.RenderViewRow(rswrk2[0]);
                            IdPlant.EditValue = IdPlant.DisplayValue(listwrk);
                        } else {
                            IdPlant.EditValue = FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
                        }
                    }
                } else {
                    IdPlant.EditValue = DbNullValue;
                }
                IdPlant.ViewCustomAttributes = "";

                // IdReferensi
                IdReferensi.SetupEditAttributes();
                IdReferensi.EditValue = ConvertToString(IdReferensi.CurrentValue); // DN
                IdReferensi.ViewCustomAttributes = "";

                // IdModa
                IdModa.SetupEditAttributes();
                string curVal4 = ConvertToString(IdModa.CurrentValue);
                if (!Empty(curVal4)) {
                    if (IdModa.Lookup != null && IsDictionary(IdModa.Lookup?.Options) && IdModa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdModa.EditValue = IdModa.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", IdModa.CurrentValue, IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                        string? sqlWrk4 = IdModa.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && IdModa.Lookup != null) { // Lookup values found
                            var listwrk = IdModa.Lookup?.RenderViewRow(rswrk4[0]);
                            IdModa.EditValue = IdModa.DisplayValue(listwrk);
                        } else {
                            IdModa.EditValue = FormatNumber(IdModa.CurrentValue, IdModa.FormatPattern);
                        }
                    }
                } else {
                    IdModa.EditValue = DbNullValue;
                }
                IdModa.ViewCustomAttributes = "";

                // TipePenyaluran
                TipePenyaluran.SetupEditAttributes();
                if (!Empty(TipePenyaluran.CurrentValue)) {
                    TipePenyaluran.EditValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
                } else {
                    TipePenyaluran.EditValue = DbNullValue;
                }
                TipePenyaluran.ViewCustomAttributes = "";

                // KategoriPenyaluran
                KategoriPenyaluran.SetupEditAttributes();
                if (!Empty(KategoriPenyaluran.CurrentValue)) {
                    KategoriPenyaluran.EditValue = KategoriPenyaluran.OptionCaption(ConvertToString(KategoriPenyaluran.CurrentValue));
                } else {
                    KategoriPenyaluran.EditValue = DbNullValue;
                }
                KategoriPenyaluran.ViewCustomAttributes = "";

                // NomorPolisi
                NomorPolisi.SetupEditAttributes();
                NomorPolisi.EditValue = ConvertToString(NomorPolisi.CurrentValue); // DN
                NomorPolisi.ViewCustomAttributes = "";

                // TipeProdukSTS
                TipeProdukSTS.SetupEditAttributes();
                List<object?>? listWrk7 = [ // DN
                    TipeProdukSTS.CurrentValue,
                    TipeProdukSTS.CurrentValue,
                ];
                listWrk7 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk7, this);
                string? dispVal7 = TipeProdukSTS.DisplayValue(listWrk7);
                if (!Empty(dispVal7))
                    TipeProdukSTS.EditValue = dispVal7;
                TipeProdukSTS.ViewCustomAttributes = "";

                // KodeProduk
                KodeProduk.SetupEditAttributes();
                string curVal8 = ConvertToString(KodeProduk.CurrentValue);
                if (!Empty(curVal8)) {
                    if (KodeProduk.Lookup != null && IsDictionary(KodeProduk.Lookup?.Options) && KodeProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        KodeProduk.EditValue = KodeProduk.LookupCacheOption(curVal8);
                    } else { // Lookup from database // DN
                        string filterWrk8 = SearchFilter(KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", KodeProduk.CurrentValue, KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                        string? sqlWrk8 = KodeProduk.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk8?.Count > 0 && KodeProduk.Lookup != null) { // Lookup values found
                            var listwrk = KodeProduk.Lookup?.RenderViewRow(rswrk8[0]);
                            KodeProduk.EditValue = KodeProduk.DisplayValue(listwrk);
                        } else {
                            KodeProduk.EditValue = KodeProduk.CurrentValue;
                        }
                    }
                } else {
                    KodeProduk.EditValue = DbNullValue;
                }
                KodeProduk.ViewCustomAttributes = "";

                // Tujuan
                Tujuan.SetupEditAttributes();
                if (!Tujuan.Raw)
                    Tujuan.CurrentValue = HtmlDecode(Tujuan.CurrentValue);
                Tujuan.EditValue = HtmlEncode(Tujuan.CurrentValue);
                Tujuan.PlaceHolder = RemoveHtml(Tujuan.Caption);

                // Catatan
                Catatan.SetupEditAttributes();
                Catatan.EditValue = Catatan.CurrentValue; // DN
                Catatan.PlaceHolder = RemoveHtml(Catatan.Caption);

                // LookupTipeProduk
                LookupTipeProduk.SetupEditAttributes();

                // LookupJenisPlant
                LookupJenisPlant.SetupEditAttributes();

                // Edit refer script

                // NomorSamplingLabTest
                NomorSamplingLabTest.HrefValue = "";
                NomorSamplingLabTest.TooltipValue = "";

                // LookupPlant
                LookupPlant.HrefValue = "";
                LookupPlant.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // IdReferensi
                IdReferensi.HrefValue = "";
                IdReferensi.TooltipValue = "";

                // IdModa
                IdModa.HrefValue = "";
                IdModa.TooltipValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";
                TipePenyaluran.TooltipValue = "";

                // KategoriPenyaluran
                KategoriPenyaluran.HrefValue = "";
                KategoriPenyaluran.TooltipValue = "";

                // NomorPolisi
                NomorPolisi.HrefValue = "";
                NomorPolisi.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // KodeProduk
                KodeProduk.HrefValue = "";
                KodeProduk.TooltipValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";
                LookupTipeProduk.TooltipValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
                LookupJenisPlant.TooltipValue = "";
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
                if (NomorSamplingLabTest.Visible && NomorSamplingLabTest.Required) {
                    if (!NomorSamplingLabTest.IsDetailKey && Empty(NomorSamplingLabTest.FormValue)) {
                        NomorSamplingLabTest.AddErrorMessage(ConvertToString(NomorSamplingLabTest.RequiredErrorMessage).Replace("%s", NomorSamplingLabTest.Caption));
                    }
                }
                if (LookupPlant.Visible && LookupPlant.Required) {
                    if (!LookupPlant.IsDetailKey && Empty(LookupPlant.FormValue)) {
                        LookupPlant.AddErrorMessage(ConvertToString(LookupPlant.RequiredErrorMessage).Replace("%s", LookupPlant.Caption));
                    }
                }
                if (IdPlant.Visible && IdPlant.Required) {
                    if (!IdPlant.IsDetailKey && Empty(IdPlant.FormValue)) {
                        IdPlant.AddErrorMessage(ConvertToString(IdPlant.RequiredErrorMessage).Replace("%s", IdPlant.Caption));
                    }
                }
                if (IdReferensi.Visible && IdReferensi.Required) {
                    if (!IdReferensi.IsDetailKey && Empty(IdReferensi.FormValue)) {
                        IdReferensi.AddErrorMessage(ConvertToString(IdReferensi.RequiredErrorMessage).Replace("%s", IdReferensi.Caption));
                    }
                }
                if (IdModa.Visible && IdModa.Required) {
                    if (!IdModa.IsDetailKey && Empty(IdModa.FormValue)) {
                        IdModa.AddErrorMessage(ConvertToString(IdModa.RequiredErrorMessage).Replace("%s", IdModa.Caption));
                    }
                }
                if (TipePenyaluran.Visible && TipePenyaluran.Required) {
                    if (!TipePenyaluran.IsDetailKey && Empty(TipePenyaluran.FormValue)) {
                        TipePenyaluran.AddErrorMessage(ConvertToString(TipePenyaluran.RequiredErrorMessage).Replace("%s", TipePenyaluran.Caption));
                    }
                }
                if (KategoriPenyaluran.Visible && KategoriPenyaluran.Required) {
                    if (!KategoriPenyaluran.IsDetailKey && Empty(KategoriPenyaluran.FormValue)) {
                        KategoriPenyaluran.AddErrorMessage(ConvertToString(KategoriPenyaluran.RequiredErrorMessage).Replace("%s", KategoriPenyaluran.Caption));
                    }
                }
                if (NomorPolisi.Visible && NomorPolisi.Required) {
                    if (!NomorPolisi.IsDetailKey && Empty(NomorPolisi.FormValue)) {
                        NomorPolisi.AddErrorMessage(ConvertToString(NomorPolisi.RequiredErrorMessage).Replace("%s", NomorPolisi.Caption));
                    }
                }
                if (TipeProdukSTS.Visible && TipeProdukSTS.Required) {
                    if (!TipeProdukSTS.IsDetailKey && Empty(TipeProdukSTS.FormValue)) {
                        TipeProdukSTS.AddErrorMessage(ConvertToString(TipeProdukSTS.RequiredErrorMessage).Replace("%s", TipeProdukSTS.Caption));
                    }
                }
                if (KodeProduk.Visible && KodeProduk.Required) {
                    if (!KodeProduk.IsDetailKey && Empty(KodeProduk.FormValue)) {
                        KodeProduk.AddErrorMessage(ConvertToString(KodeProduk.RequiredErrorMessage).Replace("%s", KodeProduk.Caption));
                    }
                }
                if (Tujuan.Visible && Tujuan.Required) {
                    if (!Tujuan.IsDetailKey && Empty(Tujuan.FormValue)) {
                        Tujuan.AddErrorMessage(ConvertToString(Tujuan.RequiredErrorMessage).Replace("%s", Tujuan.Caption));
                    }
                }
                if (Catatan.Visible && Catatan.Required) {
                    if (!Catatan.IsDetailKey && Empty(Catatan.FormValue)) {
                        Catatan.AddErrorMessage(ConvertToString(Catatan.RequiredErrorMessage).Replace("%s", Catatan.Caption));
                    }
                }
                if (LookupTipeProduk.Visible && LookupTipeProduk.Required) {
                    if (!LookupTipeProduk.IsDetailKey && Empty(LookupTipeProduk.FormValue)) {
                        LookupTipeProduk.AddErrorMessage(ConvertToString(LookupTipeProduk.RequiredErrorMessage).Replace("%s", LookupTipeProduk.Caption));
                    }
                }
                if (LookupJenisPlant.Visible && LookupJenisPlant.Required) {
                    if (!LookupJenisPlant.IsDetailKey && Empty(LookupJenisPlant.FormValue)) {
                        LookupJenisPlant.AddErrorMessage(ConvertToString(LookupJenisPlant.RequiredErrorMessage).Replace("%s", LookupJenisPlant.Caption));
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

            // Tujuan
            Tujuan.SetDbValue(rsnew, Tujuan.CurrentValue, Tujuan.ReadOnly);

            // Catatan
            Catatan.SetDbValue(rsnew, Catatan.CurrentValue, Catatan.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Tujuan", out value)) // Tujuan
                Tujuan.CurrentValue = value;
            if (row.TryGetValue("Catatan", out value)) // Catatan
                Catatan.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SamplingLabTestList")), "", TableVar, true);
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
