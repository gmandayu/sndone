namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterPlantAdd
    /// </summary>
    public static MasterPlantAdd masterPlantAdd
    {
        get => HttpData.Get<MasterPlantAdd>("masterPlantAdd")!;
        set => HttpData["masterPlantAdd"] = value;
    }

    /// <summary>
    /// Page class for MasterPlant
    /// </summary>
    public class MasterPlantAdd : MasterPlantAddBase
    {
        // Constructor
        public MasterPlantAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterPlantAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MasterPlantAddBase : MasterPlant
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterPlantAdd";

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
        public MasterPlantAddBase()
        {
            TableName = "MasterPlant";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterPlant)
            if (masterPlant == null || masterPlant is MasterPlant)
                masterPlant = this;

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
        public string PageName => "MasterPlantAdd";

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
            IdPlant.Visible = false;
            Terminal_Manager.SetVisibility();
            PRL.SetVisibility();
            Status.SetVisibility();
            Terminal_Induk.SetVisibility();
            Nama_Terminal.SetVisibility();
            Region.SetVisibility();
            Fungsi.SetVisibility();
            Cost_Center.SetVisibility();
            Jenis.SetVisibility();
            Plant.SetVisibility();
            UTC.SetVisibility();
            TipeProduk.SetVisibility();
            JenisPlant.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
        }

        // Constructor
        public MasterPlantAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "MasterPlantView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdPlant") ? dict["IdPlant"] : IdPlant.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdPlant.Visible = false;
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

        // Properties
        public string FormClassName = "ew-form ew-add-form";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public int StartRecord;

        public DbDataReader? Recordset = null; // Reserved // DN

        public bool CopyRecord;

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
            await SetupLookupOptions(UTC);
            await SetupLookupOptions(TipeProduk);
            await SetupLookupOptions(JenisPlant);

            // Load default values for add
            LoadDefaultValues();

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;
            bool postBack = false;
            StringValues sv;

            // Set up current action
            if (IsApi()) {
                CurrentAction = "insert"; // Add record directly
                postBack = true;
            } else if (!Empty(Post("action"))) {
                CurrentAction = Post("action"); // Get form action
                if (Post(OldKeyName, out sv))
                    SetKey(sv.ToString());
                postBack = true;
            } else {
                // Load key from QueryString
                string[] keyValues = {};
                object? rv;
                if (RouteValues.TryGetValue("key", out object? k))
                    keyValues = ConvertToString(k).Split('/'); // For Copy page
                if (RouteValues.TryGetValue("IdPlant", out rv)) { // DN
                    IdPlant.QueryValue = UrlDecode(rv); // DN
                } else if (Get("IdPlant", out sv)) {
                    IdPlant.QueryValue = sv.ToString();
                }
                OldKey = GetKey(true); // Get from CurrentValue
                CopyRecord = !Empty(OldKey);
                if (CopyRecord) {
                    CurrentAction = "copy"; // Copy record
                    SetKey(OldKey); // Set up record key
                } else {
                    CurrentAction = "show"; // Display blank record
                }
            }

            // Load old record / default values
            var rsold = await LoadOldRecord();

            // Load form values
            if (postBack) {
                await LoadFormValues(); // Load form values
            }

            // Validate form if post back
            if (postBack) {
                if (!await ValidateForm()) {
                    EventCancelled = true; // Event cancelled
                    RestoreFormValues(); // Restore form values
                    if (IsApi())
                        return Terminate();
                    else
                        CurrentAction = "show"; // Form error, reset action
                }
            }

            // Perform current action
            switch (CurrentAction) {
                case "copy": // Copy an existing record
                    if (rsold == null) { // Record not loaded
                        if (Empty(FailureMessage))
                            FailureMessage = Language.Phrase("NoRecord"); // No record found
                        return Terminate("MasterPlantList"); // No matching record, return to List page // DN
                    }
                    break;
                case "insert": // Add new record // DN
                    SendEmail = true; // Send email on add success
                    var res = await AddRow(rsold);
                    if (res) { // Add successful
                        if (Empty(SuccessMessage) && Post("addopt") != "1") // Skip success message for addopt (done in JavaScript)
                            SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
                        string returnUrl = "";
                        returnUrl = ReturnUrl;
                        if (GetPageName(returnUrl) == "MasterPlantList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "MasterPlantView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MasterPlantList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MasterPlantList"; // Return list page content
                            }
                        }
                        if (IsJsonResponse()) { // Return to caller
                            ClearMessages(); // Clear messages for Json response
                            return res;
                        } else {
                            return Terminate(returnUrl);
                        }
                    } else if (IsApi()) { // API request, return
                        return Terminate();
                    } else {
                        EventCancelled = true; // Event cancelled
                        RestoreFormValues(); // Add failed, restore form values
                    }
                    break;
            }

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Render row based on row type
            RowType = RowType.Add; // Render add type

            // Render row
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
                masterPlantAdd?.PageRender();
            }
            return PageResult();
        }

        // Confirm page
        public bool ConfirmPage = false; // DN

        #pragma warning disable 1998
        // Get upload files
        public async Task GetUploadFiles()
        {
            // Get upload data
        }
        #pragma warning restore 1998

        // Load default values
        protected void LoadDefaultValues() {
        }

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'Terminal_Manager' before field var 'x_Terminal_Manager'
            val = CurrentForm.HasValue("Terminal_Manager") ? CurrentForm.GetValue("Terminal_Manager") : CurrentForm.GetValue("x_Terminal_Manager");
            if (!Terminal_Manager.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Terminal_Manager") && !CurrentForm.HasValue("x_Terminal_Manager")) // DN
                    Terminal_Manager.Visible = false; // Disable update for API request
                else
                    Terminal_Manager.SetFormValue(val);
            }

            // Check field name 'PRL' before field var 'x_PRL'
            val = CurrentForm.HasValue("PRL") ? CurrentForm.GetValue("PRL") : CurrentForm.GetValue("x_PRL");
            if (!PRL.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PRL") && !CurrentForm.HasValue("x_PRL")) // DN
                    PRL.Visible = false; // Disable update for API request
                else
                    PRL.SetFormValue(val);
            }

            // Check field name 'Status' before field var 'x_Status'
            val = CurrentForm.HasValue("Status") ? CurrentForm.GetValue("Status") : CurrentForm.GetValue("x_Status");
            if (!Status.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Status") && !CurrentForm.HasValue("x_Status")) // DN
                    Status.Visible = false; // Disable update for API request
                else
                    Status.SetFormValue(val);
            }

            // Check field name 'Terminal_Induk' before field var 'x_Terminal_Induk'
            val = CurrentForm.HasValue("Terminal_Induk") ? CurrentForm.GetValue("Terminal_Induk") : CurrentForm.GetValue("x_Terminal_Induk");
            if (!Terminal_Induk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Terminal_Induk") && !CurrentForm.HasValue("x_Terminal_Induk")) // DN
                    Terminal_Induk.Visible = false; // Disable update for API request
                else
                    Terminal_Induk.SetFormValue(val);
            }

            // Check field name 'Nama_Terminal' before field var 'x_Nama_Terminal'
            val = CurrentForm.HasValue("Nama_Terminal") ? CurrentForm.GetValue("Nama_Terminal") : CurrentForm.GetValue("x_Nama_Terminal");
            if (!Nama_Terminal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Nama_Terminal") && !CurrentForm.HasValue("x_Nama_Terminal")) // DN
                    Nama_Terminal.Visible = false; // Disable update for API request
                else
                    Nama_Terminal.SetFormValue(val);
            }

            // Check field name 'Region' before field var 'x_Region'
            val = CurrentForm.HasValue("Region") ? CurrentForm.GetValue("Region") : CurrentForm.GetValue("x_Region");
            if (!Region.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Region") && !CurrentForm.HasValue("x_Region")) // DN
                    Region.Visible = false; // Disable update for API request
                else
                    Region.SetFormValue(val);
            }

            // Check field name 'Fungsi' before field var 'x_Fungsi'
            val = CurrentForm.HasValue("Fungsi") ? CurrentForm.GetValue("Fungsi") : CurrentForm.GetValue("x_Fungsi");
            if (!Fungsi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Fungsi") && !CurrentForm.HasValue("x_Fungsi")) // DN
                    Fungsi.Visible = false; // Disable update for API request
                else
                    Fungsi.SetFormValue(val);
            }

            // Check field name 'Cost_Center' before field var 'x_Cost_Center'
            val = CurrentForm.HasValue("Cost_Center") ? CurrentForm.GetValue("Cost_Center") : CurrentForm.GetValue("x_Cost_Center");
            if (!Cost_Center.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Cost_Center") && !CurrentForm.HasValue("x_Cost_Center")) // DN
                    Cost_Center.Visible = false; // Disable update for API request
                else
                    Cost_Center.SetFormValue(val);
            }

            // Check field name 'Jenis' before field var 'x_Jenis'
            val = CurrentForm.HasValue("Jenis") ? CurrentForm.GetValue("Jenis") : CurrentForm.GetValue("x_Jenis");
            if (!Jenis.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Jenis") && !CurrentForm.HasValue("x_Jenis")) // DN
                    Jenis.Visible = false; // Disable update for API request
                else
                    Jenis.SetFormValue(val);
            }

            // Check field name 'Plant' before field var 'x_Plant'
            val = CurrentForm.HasValue("Plant") ? CurrentForm.GetValue("Plant") : CurrentForm.GetValue("x_Plant");
            if (!Plant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Plant") && !CurrentForm.HasValue("x_Plant")) // DN
                    Plant.Visible = false; // Disable update for API request
                else
                    Plant.SetFormValue(val);
            }

            // Check field name 'UTC' before field var 'x_UTC'
            val = CurrentForm.HasValue("UTC") ? CurrentForm.GetValue("UTC") : CurrentForm.GetValue("x_UTC");
            if (!UTC.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UTC") && !CurrentForm.HasValue("x_UTC")) // DN
                    UTC.Visible = false; // Disable update for API request
                else
                    UTC.SetFormValue(val);
            }

            // Check field name 'TipeProduk' before field var 'x_TipeProduk'
            val = CurrentForm.HasValue("TipeProduk") ? CurrentForm.GetValue("TipeProduk") : CurrentForm.GetValue("x_TipeProduk");
            if (!TipeProduk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipeProduk") && !CurrentForm.HasValue("x_TipeProduk")) // DN
                    TipeProduk.Visible = false; // Disable update for API request
                else
                    TipeProduk.SetFormValue(val);
            }

            // Check field name 'JenisPlant' before field var 'x_JenisPlant'
            val = CurrentForm.HasValue("JenisPlant") ? CurrentForm.GetValue("JenisPlant") : CurrentForm.GetValue("x_JenisPlant");
            if (!JenisPlant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("JenisPlant") && !CurrentForm.HasValue("x_JenisPlant")) // DN
                    JenisPlant.Visible = false; // Disable update for API request
                else
                    JenisPlant.SetFormValue(val);
            }

            // Check field name 'IdPlant' before field var 'x_IdPlant'
            val = CurrentForm.HasValue("IdPlant") ? CurrentForm.GetValue("IdPlant") : CurrentForm.GetValue("x_IdPlant");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            Terminal_Manager.CurrentValue = Terminal_Manager.FormValue;
            PRL.CurrentValue = PRL.FormValue;
            Status.CurrentValue = Status.FormValue;
            Terminal_Induk.CurrentValue = Terminal_Induk.FormValue;
            Nama_Terminal.CurrentValue = Nama_Terminal.FormValue;
            Region.CurrentValue = Region.FormValue;
            Fungsi.CurrentValue = Fungsi.FormValue;
            Cost_Center.CurrentValue = Cost_Center.FormValue;
            Jenis.CurrentValue = Jenis.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            UTC.CurrentValue = UTC.FormValue;
            TipeProduk.CurrentValue = TipeProduk.FormValue;
            JenisPlant.CurrentValue = JenisPlant.FormValue;
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
            IdPlant.SetDbValue(row["IdPlant"]);
            Terminal_Manager.SetDbValue(row["Terminal_Manager"]);
            PRL.SetDbValue(row["PRL"]);
            Status.SetDbValue(row["Status"]);
            Terminal_Induk.SetDbValue(row["Terminal_Induk"]);
            Nama_Terminal.SetDbValue(row["Nama_Terminal"]);
            Region.SetDbValue(row["Region"]);
            Fungsi.SetDbValue(row["Fungsi"]);
            Cost_Center.SetDbValue(row["Cost_Center"]);
            Jenis.SetDbValue(row["Jenis"]);
            Plant.SetDbValue(row["Plant"]);
            UTC.SetDbValue(row["UTC"]);
            TipeProduk.SetDbValue(row["TipeProduk"]);
            JenisPlant.SetDbValue(row["JenisPlant"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Terminal_Manager", Terminal_Manager.DefaultValue ?? DbNullValue); // DN
            row.Add("PRL", PRL.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("Terminal_Induk", Terminal_Induk.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama_Terminal", Nama_Terminal.DefaultValue ?? DbNullValue); // DN
            row.Add("Region", Region.DefaultValue ?? DbNullValue); // DN
            row.Add("Fungsi", Fungsi.DefaultValue ?? DbNullValue); // DN
            row.Add("Cost_Center", Cost_Center.DefaultValue ?? DbNullValue); // DN
            row.Add("Jenis", Jenis.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("UTC", UTC.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProduk", TipeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("JenisPlant", JenisPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
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

            // IdPlant
            IdPlant.RowCssClass = "row";

            // Terminal_Manager
            Terminal_Manager.RowCssClass = "row";

            // PRL
            PRL.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // Terminal_Induk
            Terminal_Induk.RowCssClass = "row";

            // Nama_Terminal
            Nama_Terminal.RowCssClass = "row";

            // Region
            Region.RowCssClass = "row";

            // Fungsi
            Fungsi.RowCssClass = "row";

            // Cost_Center
            Cost_Center.RowCssClass = "row";

            // Jenis
            Jenis.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // UTC
            UTC.RowCssClass = "row";

            // TipeProduk
            TipeProduk.RowCssClass = "row";

            // JenisPlant
            JenisPlant.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaruiOleh
            DiperbaruiOleh.RowCssClass = "row";

            // TanggalDiperbarui
            TanggalDiperbarui.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdPlant
                IdPlant.ViewValue = IdPlant.CurrentValue;
                IdPlant.ViewCustomAttributes = "";

                // Terminal_Manager
                Terminal_Manager.ViewValue = ConvertToString(Terminal_Manager.CurrentValue); // DN
                Terminal_Manager.ViewCustomAttributes = "";

                // PRL
                PRL.ViewValue = ConvertToString(PRL.CurrentValue); // DN
                PRL.ViewCustomAttributes = "";

                // Status
                Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // Terminal_Induk
                Terminal_Induk.ViewValue = ConvertToString(Terminal_Induk.CurrentValue); // DN
                Terminal_Induk.ViewCustomAttributes = "";

                // Nama_Terminal
                Nama_Terminal.ViewValue = ConvertToString(Nama_Terminal.CurrentValue); // DN
                Nama_Terminal.ViewCustomAttributes = "";

                // Region
                Region.ViewValue = ConvertToString(Region.CurrentValue); // DN
                Region.ViewCustomAttributes = "";

                // Fungsi
                Fungsi.ViewValue = ConvertToString(Fungsi.CurrentValue); // DN
                Fungsi.ViewCustomAttributes = "";

                // Cost_Center
                Cost_Center.ViewValue = ConvertToString(Cost_Center.CurrentValue); // DN
                Cost_Center.ViewCustomAttributes = "";

                // Jenis
                Jenis.ViewValue = ConvertToString(Jenis.CurrentValue); // DN
                Jenis.ViewCustomAttributes = "";

                // Plant
                Plant.ViewValue = ConvertToString(Plant.CurrentValue); // DN
                Plant.ViewCustomAttributes = "";

                // UTC
                if (!Empty(UTC.CurrentValue)) {
                    UTC.ViewValue = UTC.OptionCaption(ConvertToString(UTC.CurrentValue));
                } else {
                    UTC.ViewValue = DbNullValue;
                }
                UTC.ViewCustomAttributes = "";

                // TipeProduk
                if (!Empty(TipeProduk.CurrentValue)) {
                    TipeProduk.ViewValue = TipeProduk.OptionCaption(ConvertToString(TipeProduk.CurrentValue));
                } else {
                    TipeProduk.ViewValue = DbNullValue;
                }
                TipeProduk.ViewCustomAttributes = "";

                // JenisPlant
                if (!Empty(JenisPlant.CurrentValue)) {
                    JenisPlant.ViewValue = JenisPlant.OptionCaption(ConvertToString(JenisPlant.CurrentValue));
                } else {
                    JenisPlant.ViewValue = DbNullValue;
                }
                JenisPlant.ViewCustomAttributes = "";

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

                // Terminal_Manager
                Terminal_Manager.HrefValue = "";

                // PRL
                PRL.HrefValue = "";

                // Status
                Status.HrefValue = "";

                // Terminal_Induk
                Terminal_Induk.HrefValue = "";

                // Nama_Terminal
                Nama_Terminal.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Fungsi
                Fungsi.HrefValue = "";

                // Cost_Center
                Cost_Center.HrefValue = "";

                // Jenis
                Jenis.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // UTC
                UTC.HrefValue = "";

                // TipeProduk
                TipeProduk.HrefValue = "";

                // JenisPlant
                JenisPlant.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // Terminal_Manager
                Terminal_Manager.SetupEditAttributes();
                if (!Terminal_Manager.Raw)
                    Terminal_Manager.CurrentValue = HtmlDecode(Terminal_Manager.CurrentValue);
                Terminal_Manager.EditValue = HtmlEncode(Terminal_Manager.CurrentValue);
                Terminal_Manager.PlaceHolder = RemoveHtml(Terminal_Manager.Caption);

                // PRL
                PRL.SetupEditAttributes();
                if (!PRL.Raw)
                    PRL.CurrentValue = HtmlDecode(PRL.CurrentValue);
                PRL.EditValue = HtmlEncode(PRL.CurrentValue);
                PRL.PlaceHolder = RemoveHtml(PRL.Caption);

                // Status
                Status.SetupEditAttributes();
                if (!Status.Raw)
                    Status.CurrentValue = HtmlDecode(Status.CurrentValue);
                Status.EditValue = HtmlEncode(Status.CurrentValue);
                Status.PlaceHolder = RemoveHtml(Status.Caption);

                // Terminal_Induk
                Terminal_Induk.SetupEditAttributes();
                if (!Terminal_Induk.Raw)
                    Terminal_Induk.CurrentValue = HtmlDecode(Terminal_Induk.CurrentValue);
                Terminal_Induk.EditValue = HtmlEncode(Terminal_Induk.CurrentValue);
                Terminal_Induk.PlaceHolder = RemoveHtml(Terminal_Induk.Caption);

                // Nama_Terminal
                Nama_Terminal.SetupEditAttributes();
                if (!Nama_Terminal.Raw)
                    Nama_Terminal.CurrentValue = HtmlDecode(Nama_Terminal.CurrentValue);
                Nama_Terminal.EditValue = HtmlEncode(Nama_Terminal.CurrentValue);
                Nama_Terminal.PlaceHolder = RemoveHtml(Nama_Terminal.Caption);

                // Region
                Region.SetupEditAttributes();
                if (!Region.Raw)
                    Region.CurrentValue = HtmlDecode(Region.CurrentValue);
                Region.EditValue = HtmlEncode(Region.CurrentValue);
                Region.PlaceHolder = RemoveHtml(Region.Caption);

                // Fungsi
                Fungsi.SetupEditAttributes();
                if (!Fungsi.Raw)
                    Fungsi.CurrentValue = HtmlDecode(Fungsi.CurrentValue);
                Fungsi.EditValue = HtmlEncode(Fungsi.CurrentValue);
                Fungsi.PlaceHolder = RemoveHtml(Fungsi.Caption);

                // Cost_Center
                Cost_Center.SetupEditAttributes();
                if (!Cost_Center.Raw)
                    Cost_Center.CurrentValue = HtmlDecode(Cost_Center.CurrentValue);
                Cost_Center.EditValue = HtmlEncode(Cost_Center.CurrentValue);
                Cost_Center.PlaceHolder = RemoveHtml(Cost_Center.Caption);

                // Jenis
                Jenis.SetupEditAttributes();
                if (!Jenis.Raw)
                    Jenis.CurrentValue = HtmlDecode(Jenis.CurrentValue);
                Jenis.EditValue = HtmlEncode(Jenis.CurrentValue);
                Jenis.PlaceHolder = RemoveHtml(Jenis.Caption);

                // Plant
                Plant.SetupEditAttributes();
                if (!Plant.Raw)
                    Plant.CurrentValue = HtmlDecode(Plant.CurrentValue);
                Plant.EditValue = HtmlEncode(Plant.CurrentValue);
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);

                // UTC
                UTC.SetupEditAttributes();
                UTC.EditValue = UTC.Options(true);
                UTC.PlaceHolder = RemoveHtml(UTC.Caption);

                // TipeProduk
                TipeProduk.SetupEditAttributes();
                TipeProduk.EditValue = TipeProduk.Options(true);
                TipeProduk.PlaceHolder = RemoveHtml(TipeProduk.Caption);

                // JenisPlant
                JenisPlant.SetupEditAttributes();
                JenisPlant.EditValue = JenisPlant.Options(true);
                JenisPlant.PlaceHolder = RemoveHtml(JenisPlant.Caption);

                // Add refer script

                // Terminal_Manager
                Terminal_Manager.HrefValue = "";

                // PRL
                PRL.HrefValue = "";

                // Status
                Status.HrefValue = "";

                // Terminal_Induk
                Terminal_Induk.HrefValue = "";

                // Nama_Terminal
                Nama_Terminal.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Fungsi
                Fungsi.HrefValue = "";

                // Cost_Center
                Cost_Center.HrefValue = "";

                // Jenis
                Jenis.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // UTC
                UTC.HrefValue = "";

                // TipeProduk
                TipeProduk.HrefValue = "";

                // JenisPlant
                JenisPlant.HrefValue = "";
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
                if (Terminal_Manager.Visible && Terminal_Manager.Required) {
                    if (!Terminal_Manager.IsDetailKey && Empty(Terminal_Manager.FormValue)) {
                        Terminal_Manager.AddErrorMessage(ConvertToString(Terminal_Manager.RequiredErrorMessage).Replace("%s", Terminal_Manager.Caption));
                    }
                }
                if (PRL.Visible && PRL.Required) {
                    if (!PRL.IsDetailKey && Empty(PRL.FormValue)) {
                        PRL.AddErrorMessage(ConvertToString(PRL.RequiredErrorMessage).Replace("%s", PRL.Caption));
                    }
                }
                if (Status.Visible && Status.Required) {
                    if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                        Status.AddErrorMessage(ConvertToString(Status.RequiredErrorMessage).Replace("%s", Status.Caption));
                    }
                }
                if (Terminal_Induk.Visible && Terminal_Induk.Required) {
                    if (!Terminal_Induk.IsDetailKey && Empty(Terminal_Induk.FormValue)) {
                        Terminal_Induk.AddErrorMessage(ConvertToString(Terminal_Induk.RequiredErrorMessage).Replace("%s", Terminal_Induk.Caption));
                    }
                }
                if (Nama_Terminal.Visible && Nama_Terminal.Required) {
                    if (!Nama_Terminal.IsDetailKey && Empty(Nama_Terminal.FormValue)) {
                        Nama_Terminal.AddErrorMessage(ConvertToString(Nama_Terminal.RequiredErrorMessage).Replace("%s", Nama_Terminal.Caption));
                    }
                }
                if (Region.Visible && Region.Required) {
                    if (!Region.IsDetailKey && Empty(Region.FormValue)) {
                        Region.AddErrorMessage(ConvertToString(Region.RequiredErrorMessage).Replace("%s", Region.Caption));
                    }
                }
                if (Fungsi.Visible && Fungsi.Required) {
                    if (!Fungsi.IsDetailKey && Empty(Fungsi.FormValue)) {
                        Fungsi.AddErrorMessage(ConvertToString(Fungsi.RequiredErrorMessage).Replace("%s", Fungsi.Caption));
                    }
                }
                if (Cost_Center.Visible && Cost_Center.Required) {
                    if (!Cost_Center.IsDetailKey && Empty(Cost_Center.FormValue)) {
                        Cost_Center.AddErrorMessage(ConvertToString(Cost_Center.RequiredErrorMessage).Replace("%s", Cost_Center.Caption));
                    }
                }
                if (Jenis.Visible && Jenis.Required) {
                    if (!Jenis.IsDetailKey && Empty(Jenis.FormValue)) {
                        Jenis.AddErrorMessage(ConvertToString(Jenis.RequiredErrorMessage).Replace("%s", Jenis.Caption));
                    }
                }
                if (Plant.Visible && Plant.Required) {
                    if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                        Plant.AddErrorMessage(ConvertToString(Plant.RequiredErrorMessage).Replace("%s", Plant.Caption));
                    }
                }
                if (UTC.Visible && UTC.Required) {
                    if (!UTC.IsDetailKey && Empty(UTC.FormValue)) {
                        UTC.AddErrorMessage(ConvertToString(UTC.RequiredErrorMessage).Replace("%s", UTC.Caption));
                    }
                }
                if (TipeProduk.Visible && TipeProduk.Required) {
                    if (!TipeProduk.IsDetailKey && Empty(TipeProduk.FormValue)) {
                        TipeProduk.AddErrorMessage(ConvertToString(TipeProduk.RequiredErrorMessage).Replace("%s", TipeProduk.Caption));
                    }
                }
                if (JenisPlant.Visible && JenisPlant.Required) {
                    if (!JenisPlant.IsDetailKey && Empty(JenisPlant.FormValue)) {
                        JenisPlant.AddErrorMessage(ConvertToString(JenisPlant.RequiredErrorMessage).Replace("%s", JenisPlant.Caption));
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

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Get new row
            Dictionary<string, object> rsnew = GetAddRow();
            if (rsnew.Count == 0)
                return JsonBoolResult.FalseResult;

            // Update current values
            SetCurrentValues(rsnew);

            // Load db values from rsold
            LoadDbValues(rsold);

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["IdPlant"] = IdPlant.CurrentValue!;
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    result = false;
                }
            } else {
                if (SuccessMessage != "" || FailureMessage != "") {
                    // Use the message, do nothing
                } else if (CancelMessage != "") {
                    FailureMessage = CancelMessage;
                    CancelMessage = "";
                } else {
                    FailureMessage = Language.Phrase("InsertCancelled");
                }
                result = false;
            }

            // Call Row Inserted event
            if (result)
                RowInserted(rsold, rsnew);

            // Write JSON for API request
            Dictionary<string, object> d = new();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                if (GetRecordFromDictionary(rsnew) is var row && row != null) {
                    string table = TableVar;
                    d.Add(table, row);
                }
                d.Add("action", Config.ApiAddAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, result);
            }
            return new JsonBoolResult(d, result);
        }

        /// <summary>
        /// Get add row
        /// </summary>
        /// <returns>New row</returns>
        protected Dictionary<string, object> GetAddRow()
        {
            try {
                Dictionary<string, object> rsnew = new();

                // Terminal_Manager
                Terminal_Manager.SetDbValue(rsnew, Terminal_Manager.CurrentValue);

                // PRL
                PRL.SetDbValue(rsnew, PRL.CurrentValue);

                // Status
                Status.SetDbValue(rsnew, Status.CurrentValue);

                // Terminal_Induk
                Terminal_Induk.SetDbValue(rsnew, Terminal_Induk.CurrentValue);

                // Nama_Terminal
                Nama_Terminal.SetDbValue(rsnew, Nama_Terminal.CurrentValue);

                // Region
                Region.SetDbValue(rsnew, Region.CurrentValue);

                // Fungsi
                Fungsi.SetDbValue(rsnew, Fungsi.CurrentValue);

                // Cost_Center
                Cost_Center.SetDbValue(rsnew, Cost_Center.CurrentValue);

                // Jenis
                Jenis.SetDbValue(rsnew, Jenis.CurrentValue);

                // Plant
                Plant.SetDbValue(rsnew, Plant.CurrentValue);

                // UTC
                UTC.SetDbValue(rsnew, UTC.CurrentValue);

                // TipeProduk
                TipeProduk.SetDbValue(rsnew, TipeProduk.CurrentValue);

                // JenisPlant
                JenisPlant.SetDbValue(rsnew, JenisPlant.CurrentValue);
                return rsnew;
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return new();
            }
        }

        /// <summary>
        /// Restore add form from row
        /// </summary>
        /// <param name="row">Current row</param>
        private void RestoreAddFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Terminal_Manager", out value)) // Terminal_Manager
                Terminal_Manager.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PRL", out value)) // PRL
                PRL.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Status", out value)) // Status
                Status.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Terminal_Induk", out value)) // Terminal_Induk
                Terminal_Induk.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Nama_Terminal", out value)) // Nama_Terminal
                Nama_Terminal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Region", out value)) // Region
                Region.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Fungsi", out value)) // Fungsi
                Fungsi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Cost_Center", out value)) // Cost_Center
                Cost_Center.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Jenis", out value)) // Jenis
                Jenis.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("UTC", out value)) // UTC
                UTC.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TipeProduk", out value)) // TipeProduk
                TipeProduk.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("JenisPlant", out value)) // JenisPlant
                JenisPlant.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterPlantList")), "", TableVar, true);
            string pageId = IsCopy ? "Copy" : "Add";
            breadcrumb.Add("add", pageId, url);
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
