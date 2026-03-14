namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// setPjsAdd
    /// </summary>
    public static SetPjsAdd setPjsAdd
    {
        get => HttpData.Get<SetPjsAdd>("setPjsAdd")!;
        set => HttpData["setPjsAdd"] = value;
    }

    /// <summary>
    /// Page class for SetPjs
    /// </summary>
    public class SetPjsAdd : SetPjsAddBase
    {
        // Constructor
        public SetPjsAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SetPjsAdd() : base()
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
    public class SetPjsAddBase : SetPjs
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "setPjsAdd";

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
        public SetPjsAddBase()
        {
            TableName = "SetPjs";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table d-none";

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
        public string PageName => "SetPjsAdd";

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
            Id.Visible = false;
            NomorPjs.Visible = false;
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
            Status.Visible = false;
            DownloadSuratTugas.Visible = false;
            SuratTugas.Visible = false;
            Keterangan.SetVisibility();
            Remaks.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaharuiOleh.SetVisibility();
            DiperbaharuiTanggal.SetVisibility();
            PlantAwal.Visible = false;
            RegionAwal.Visible = false;
        }

        // Constructor
        public SetPjsAddBase(Controller? controller = null): this() { // DN
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
            await SetupLookupOptions(OrganizationLevel);
            await SetupLookupOptions(Region);
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(PosisiAwal);
            await SetupLookupOptions(PosisiPJS);
            await SetupLookupOptions(LookupPosition);
            await SetupLookupOptions(DibuatOleh);
            await SetupLookupOptions(DiperbaharuiOleh);

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
                if (RouteValues.TryGetValue("Id", out rv)) { // DN
                    Id.QueryValue = UrlDecode(rv); // DN
                } else if (Get("Id", out sv)) {
                    Id.QueryValue = sv.ToString();
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
                        return Terminate("SetPjsList"); // No matching record, return to List page // DN
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
                        if (GetPageName(returnUrl) == "SetPjsList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "SetPjsView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SetPjsList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SetPjsList"; // Return list page content
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
                setPjsAdd?.PageRender();
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
                    DiperbaharuiTanggal.SetFormValue(val, true, validate);
                DiperbaharuiTanggal.CurrentValue = UnformatDateTime(DiperbaharuiTanggal.CurrentValue, DiperbaharuiTanggal.FormatPattern);
            }

            // Check field name 'Id' before field var 'x_Id'
            val = CurrentForm.HasValue("Id") ? CurrentForm.GetValue("Id") : CurrentForm.GetValue("x_Id");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
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
            Keterangan.CurrentValue = Keterangan.FormValue;
            Remaks.CurrentValue = Remaks.FormValue;
            DiperbaharuiOleh.CurrentValue = DiperbaharuiOleh.FormValue;
            DiperbaharuiTanggal.CurrentValue = DiperbaharuiTanggal.FormValue;
            DiperbaharuiTanggal.CurrentValue = UnformatDateTime(DiperbaharuiTanggal.CurrentValue, DiperbaharuiTanggal.FormatPattern);
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

                // Keterangan
                Keterangan.HrefValue = "";

                // Remaks
                Remaks.HrefValue = "";

                // DiperbaharuiOleh
                DiperbaharuiOleh.HrefValue = "";
                DiperbaharuiOleh.TooltipValue = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.HrefValue = "";
                DiperbaharuiTanggal.TooltipValue = "";
            } else if (RowType == RowType.Add) {
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

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // Remaks
                Remaks.SetupEditAttributes();
                Remaks.EditValue = Remaks.CurrentValue; // DN
                Remaks.PlaceHolder = RemoveHtml(Remaks.Caption);

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
                            DiperbaharuiOleh.EditValue = HtmlEncode(DiperbaharuiOleh.CurrentValue);
                        }
                    }
                } else {
                    DiperbaharuiOleh.EditValue = DbNullValue;
                }
                DiperbaharuiOleh.PlaceHolder = RemoveHtml(DiperbaharuiOleh.Caption);

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.SetupEditAttributes();
                DiperbaharuiTanggal.EditValue = FormatDateTime(DiperbaharuiTanggal.CurrentValue, DiperbaharuiTanggal.FormatPattern);
                DiperbaharuiTanggal.PlaceHolder = RemoveHtml(DiperbaharuiTanggal.Caption);

                // Add refer script

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

                // Keterangan
                Keterangan.HrefValue = "";

                // Remaks
                Remaks.HrefValue = "";

                // DiperbaharuiOleh
                DiperbaharuiOleh.HrefValue = "";

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.HrefValue = "";
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
                if (!CheckDate(DiperbaharuiTanggal.FormValue, DiperbaharuiTanggal.FormatPattern)) {
                    DiperbaharuiTanggal.AddErrorMessage(DiperbaharuiTanggal.GetErrorMessage(false));
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
                    rsnew["Id"] = Id.CurrentValue!;
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

                // RedirectLink
                RedirectLink.SetDbValue(rsnew, RedirectLink.CurrentValue);

                // Nama
                Nama.SetDbValue(rsnew, Nama.CurrentValue);

                // OrganizationLevel
                OrganizationLevel.SetDbValue(rsnew, OrganizationLevel.CurrentValue);

                // Region
                Region.SetDbValue(rsnew, Region.CurrentValue);

                // Plant
                Plant.SetDbValue(rsnew, Plant.CurrentValue);

                // PosisiAwal
                PosisiAwal.SetDbValue(rsnew, PosisiAwal.CurrentValue);

                // PosisiPJS
                PosisiPJS.SetDbValue(rsnew, PosisiPJS.CurrentValue);

                // LookupPosition
                LookupPosition.SetDbValue(rsnew, LookupPosition.CurrentValue);

                // TanggalMulai
                TanggalMulai.SetDbValue(rsnew, ConvertToDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern));

                // TanggalSelesai
                TanggalSelesai.SetDbValue(rsnew, ConvertToDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern));

                // Keterangan
                Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue);

                // Remaks
                Remaks.SetDbValue(rsnew, Remaks.CurrentValue);

                // DiperbaharuiOleh
                DiperbaharuiOleh.SetDbValue(rsnew, DiperbaharuiOleh.CurrentValue);

                // DiperbaharuiTanggal
                DiperbaharuiTanggal.SetDbValue(rsnew, ConvertToDateTime(DiperbaharuiTanggal.CurrentValue, DiperbaharuiTanggal.FormatPattern));
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
            if (row.TryGetValue("RedirectLink", out value)) // RedirectLink
                RedirectLink.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Nama", out value)) // Nama
                Nama.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("OrganizationLevel", out value)) // OrganizationLevel
                OrganizationLevel.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Region", out value)) // Region
                Region.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PosisiAwal", out value)) // PosisiAwal
                PosisiAwal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PosisiPJS", out value)) // PosisiPJS
                PosisiPJS.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupPosition", out value)) // LookupPosition
                LookupPosition.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalMulai", out value)) // TanggalMulai
                TanggalMulai.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalSelesai", out value)) // TanggalSelesai
                TanggalSelesai.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Remaks", out value)) // Remaks
                Remaks.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DiperbaharuiOleh", out value)) // DiperbaharuiOleh
                DiperbaharuiOleh.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DiperbaharuiTanggal", out value)) // DiperbaharuiTanggal
                DiperbaharuiTanggal.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SetPjsList")), "", TableVar, true);
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
