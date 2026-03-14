namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterDermagaAdd
    /// </summary>
    public static MasterDermagaAdd masterDermagaAdd
    {
        get => HttpData.Get<MasterDermagaAdd>("masterDermagaAdd")!;
        set => HttpData["masterDermagaAdd"] = value;
    }

    /// <summary>
    /// Page class for MasterDermaga
    /// </summary>
    public class MasterDermagaAdd : MasterDermagaAddBase
    {
        // Constructor
        public MasterDermagaAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterDermagaAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Id_Plant.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MasterDermagaAddBase : MasterDermaga
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterDermagaAdd";

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
        public MasterDermagaAddBase()
        {
            TableName = "MasterDermaga";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterDermaga)
            if (masterDermaga == null || masterDermaga is MasterDermaga)
                masterDermaga = this;

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
        public string PageName => "MasterDermagaAdd";

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
            IdDermaga.Visible = false;
            Region.SetVisibility();
            Id_Plant.SetVisibility();
            Plant.Visible = false;
            TBBM.SetVisibility();
            Equipment_ID.SetVisibility();
            Fungsi.SetVisibility();
            Kapasitas_DWT.SetVisibility();
            Kategori_Kapasitas.SetVisibility();
            Jenis_Sartam.SetVisibility();
            Type_Sartam.SetVisibility();
            Tahun_Pembuatan.SetVisibility();
            Kategori_Port.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
        }

        // Constructor
        public MasterDermagaAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "MasterDermagaView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdDermaga") ? dict["IdDermaga"] : IdDermaga.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdDermaga.Visible = false;
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
            await SetupLookupOptions(Id_Plant);

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
                if (RouteValues.TryGetValue("IdDermaga", out rv)) { // DN
                    IdDermaga.QueryValue = UrlDecode(rv); // DN
                } else if (Get("IdDermaga", out sv)) {
                    IdDermaga.QueryValue = sv.ToString();
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
                        return Terminate("MasterDermagaList"); // No matching record, return to List page // DN
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
                        if (GetPageName(returnUrl) == "MasterDermagaList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "MasterDermagaView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MasterDermagaList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MasterDermagaList"; // Return list page content
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
                masterDermagaAdd?.PageRender();
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

            // Check field name 'Region' before field var 'x_Region'
            val = CurrentForm.HasValue("Region") ? CurrentForm.GetValue("Region") : CurrentForm.GetValue("x_Region");
            if (!Region.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Region") && !CurrentForm.HasValue("x_Region")) // DN
                    Region.Visible = false; // Disable update for API request
                else
                    Region.SetFormValue(val);
            }

            // Check field name 'Id_Plant' before field var 'x_Id_Plant'
            val = CurrentForm.HasValue("Id_Plant") ? CurrentForm.GetValue("Id_Plant") : CurrentForm.GetValue("x_Id_Plant");
            if (!Id_Plant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Id_Plant") && !CurrentForm.HasValue("x_Id_Plant")) // DN
                    Id_Plant.Visible = false; // Disable update for API request
                else
                    Id_Plant.SetFormValue(val);
            }

            // Check field name 'TBBM' before field var 'x_TBBM'
            val = CurrentForm.HasValue("TBBM") ? CurrentForm.GetValue("TBBM") : CurrentForm.GetValue("x_TBBM");
            if (!TBBM.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TBBM") && !CurrentForm.HasValue("x_TBBM")) // DN
                    TBBM.Visible = false; // Disable update for API request
                else
                    TBBM.SetFormValue(val);
            }

            // Check field name 'Equipment_ID' before field var 'x_Equipment_ID'
            val = CurrentForm.HasValue("Equipment_ID") ? CurrentForm.GetValue("Equipment_ID") : CurrentForm.GetValue("x_Equipment_ID");
            if (!Equipment_ID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Equipment_ID") && !CurrentForm.HasValue("x_Equipment_ID")) // DN
                    Equipment_ID.Visible = false; // Disable update for API request
                else
                    Equipment_ID.SetFormValue(val);
            }

            // Check field name 'Fungsi' before field var 'x_Fungsi'
            val = CurrentForm.HasValue("Fungsi") ? CurrentForm.GetValue("Fungsi") : CurrentForm.GetValue("x_Fungsi");
            if (!Fungsi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Fungsi") && !CurrentForm.HasValue("x_Fungsi")) // DN
                    Fungsi.Visible = false; // Disable update for API request
                else
                    Fungsi.SetFormValue(val);
            }

            // Check field name 'Kapasitas_DWT' before field var 'x_Kapasitas_DWT'
            val = CurrentForm.HasValue("Kapasitas_DWT") ? CurrentForm.GetValue("Kapasitas_DWT") : CurrentForm.GetValue("x_Kapasitas_DWT");
            if (!Kapasitas_DWT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Kapasitas_DWT") && !CurrentForm.HasValue("x_Kapasitas_DWT")) // DN
                    Kapasitas_DWT.Visible = false; // Disable update for API request
                else
                    Kapasitas_DWT.SetFormValue(val);
            }

            // Check field name 'Kategori_Kapasitas' before field var 'x_Kategori_Kapasitas'
            val = CurrentForm.HasValue("Kategori_Kapasitas") ? CurrentForm.GetValue("Kategori_Kapasitas") : CurrentForm.GetValue("x_Kategori_Kapasitas");
            if (!Kategori_Kapasitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Kategori_Kapasitas") && !CurrentForm.HasValue("x_Kategori_Kapasitas")) // DN
                    Kategori_Kapasitas.Visible = false; // Disable update for API request
                else
                    Kategori_Kapasitas.SetFormValue(val);
            }

            // Check field name 'Jenis_Sartam' before field var 'x_Jenis_Sartam'
            val = CurrentForm.HasValue("Jenis_Sartam") ? CurrentForm.GetValue("Jenis_Sartam") : CurrentForm.GetValue("x_Jenis_Sartam");
            if (!Jenis_Sartam.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Jenis_Sartam") && !CurrentForm.HasValue("x_Jenis_Sartam")) // DN
                    Jenis_Sartam.Visible = false; // Disable update for API request
                else
                    Jenis_Sartam.SetFormValue(val);
            }

            // Check field name 'Type_Sartam' before field var 'x_Type_Sartam'
            val = CurrentForm.HasValue("Type_Sartam") ? CurrentForm.GetValue("Type_Sartam") : CurrentForm.GetValue("x_Type_Sartam");
            if (!Type_Sartam.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Type_Sartam") && !CurrentForm.HasValue("x_Type_Sartam")) // DN
                    Type_Sartam.Visible = false; // Disable update for API request
                else
                    Type_Sartam.SetFormValue(val);
            }

            // Check field name 'Tahun_Pembuatan' before field var 'x_Tahun_Pembuatan'
            val = CurrentForm.HasValue("Tahun_Pembuatan") ? CurrentForm.GetValue("Tahun_Pembuatan") : CurrentForm.GetValue("x_Tahun_Pembuatan");
            if (!Tahun_Pembuatan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Tahun_Pembuatan") && !CurrentForm.HasValue("x_Tahun_Pembuatan")) // DN
                    Tahun_Pembuatan.Visible = false; // Disable update for API request
                else
                    Tahun_Pembuatan.SetFormValue(val);
            }

            // Check field name 'Kategori_Port' before field var 'x_Kategori_Port'
            val = CurrentForm.HasValue("Kategori_Port") ? CurrentForm.GetValue("Kategori_Port") : CurrentForm.GetValue("x_Kategori_Port");
            if (!Kategori_Port.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Kategori_Port") && !CurrentForm.HasValue("x_Kategori_Port")) // DN
                    Kategori_Port.Visible = false; // Disable update for API request
                else
                    Kategori_Port.SetFormValue(val);
            }

            // Check field name 'IdDermaga' before field var 'x_IdDermaga'
            val = CurrentForm.HasValue("IdDermaga") ? CurrentForm.GetValue("IdDermaga") : CurrentForm.GetValue("x_IdDermaga");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            Region.CurrentValue = Region.FormValue;
            Id_Plant.CurrentValue = Id_Plant.FormValue;
            TBBM.CurrentValue = TBBM.FormValue;
            Equipment_ID.CurrentValue = Equipment_ID.FormValue;
            Fungsi.CurrentValue = Fungsi.FormValue;
            Kapasitas_DWT.CurrentValue = Kapasitas_DWT.FormValue;
            Kategori_Kapasitas.CurrentValue = Kategori_Kapasitas.FormValue;
            Jenis_Sartam.CurrentValue = Jenis_Sartam.FormValue;
            Type_Sartam.CurrentValue = Type_Sartam.FormValue;
            Tahun_Pembuatan.CurrentValue = Tahun_Pembuatan.FormValue;
            Kategori_Port.CurrentValue = Kategori_Port.FormValue;
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
            IdDermaga.SetDbValue(row["IdDermaga"]);
            Region.SetDbValue(row["Region"]);
            Id_Plant.SetDbValue(row["Id_Plant"]);
            Plant.SetDbValue(row["Plant"]);
            TBBM.SetDbValue(row["TBBM"]);
            Equipment_ID.SetDbValue(row["Equipment_ID"]);
            Fungsi.SetDbValue(row["Fungsi"]);
            Kapasitas_DWT.SetDbValue(row["Kapasitas_DWT"]);
            Kategori_Kapasitas.SetDbValue(row["Kategori_Kapasitas"]);
            Jenis_Sartam.SetDbValue(row["Jenis_Sartam"]);
            Type_Sartam.SetDbValue(row["Type_Sartam"]);
            Tahun_Pembuatan.SetDbValue(row["Tahun_Pembuatan"]);
            Kategori_Port.SetDbValue(row["Kategori_Port"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdDermaga", IdDermaga.DefaultValue ?? DbNullValue); // DN
            row.Add("Region", Region.DefaultValue ?? DbNullValue); // DN
            row.Add("Id_Plant", Id_Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("TBBM", TBBM.DefaultValue ?? DbNullValue); // DN
            row.Add("Equipment_ID", Equipment_ID.DefaultValue ?? DbNullValue); // DN
            row.Add("Fungsi", Fungsi.DefaultValue ?? DbNullValue); // DN
            row.Add("Kapasitas_DWT", Kapasitas_DWT.DefaultValue ?? DbNullValue); // DN
            row.Add("Kategori_Kapasitas", Kategori_Kapasitas.DefaultValue ?? DbNullValue); // DN
            row.Add("Jenis_Sartam", Jenis_Sartam.DefaultValue ?? DbNullValue); // DN
            row.Add("Type_Sartam", Type_Sartam.DefaultValue ?? DbNullValue); // DN
            row.Add("Tahun_Pembuatan", Tahun_Pembuatan.DefaultValue ?? DbNullValue); // DN
            row.Add("Kategori_Port", Kategori_Port.DefaultValue ?? DbNullValue); // DN
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

            // IdDermaga
            IdDermaga.RowCssClass = "row";

            // Region
            Region.RowCssClass = "row";

            // Id_Plant
            Id_Plant.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // TBBM
            TBBM.RowCssClass = "row";

            // Equipment_ID
            Equipment_ID.RowCssClass = "row";

            // Fungsi
            Fungsi.RowCssClass = "row";

            // Kapasitas_DWT
            Kapasitas_DWT.RowCssClass = "row";

            // Kategori_Kapasitas
            Kategori_Kapasitas.RowCssClass = "row";

            // Jenis_Sartam
            Jenis_Sartam.RowCssClass = "row";

            // Type_Sartam
            Type_Sartam.RowCssClass = "row";

            // Tahun_Pembuatan
            Tahun_Pembuatan.RowCssClass = "row";

            // Kategori_Port
            Kategori_Port.RowCssClass = "row";

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
                // IdDermaga
                IdDermaga.ViewValue = IdDermaga.CurrentValue;
                IdDermaga.ViewCustomAttributes = "";

                // Region
                Region.ViewValue = ConvertToString(Region.CurrentValue); // DN
                Region.ViewCustomAttributes = "";

                // Id_Plant
                string curVal = ConvertToString(Id_Plant.CurrentValue);
                if (!Empty(curVal)) {
                    if (Id_Plant.Lookup != null && IsDictionary(Id_Plant.Lookup?.Options) && Id_Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Id_Plant.ViewValue = Id_Plant.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(Id_Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Id_Plant.CurrentValue, Id_Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk = Id_Plant.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Id_Plant.Lookup != null) { // Lookup values found
                            var listwrk = Id_Plant.Lookup?.RenderViewRow(rswrk[0]);
                            Id_Plant.ViewValue = Id_Plant.DisplayValue(listwrk);
                        } else {
                            Id_Plant.ViewValue = FormatNumber(Id_Plant.CurrentValue, Id_Plant.FormatPattern);
                        }
                    }
                } else {
                    Id_Plant.ViewValue = DbNullValue;
                }
                Id_Plant.ViewCustomAttributes = "";

                // Plant
                Plant.ViewValue = ConvertToString(Plant.CurrentValue); // DN
                Plant.ViewCustomAttributes = "";

                // TBBM
                TBBM.ViewValue = ConvertToString(TBBM.CurrentValue); // DN
                TBBM.ViewCustomAttributes = "";

                // Equipment_ID
                Equipment_ID.ViewValue = ConvertToString(Equipment_ID.CurrentValue); // DN
                Equipment_ID.ViewCustomAttributes = "";

                // Fungsi
                Fungsi.ViewValue = ConvertToString(Fungsi.CurrentValue); // DN
                Fungsi.ViewCustomAttributes = "";

                // Kapasitas_DWT
                Kapasitas_DWT.ViewValue = ConvertToString(Kapasitas_DWT.CurrentValue); // DN
                Kapasitas_DWT.ViewCustomAttributes = "";

                // Kategori_Kapasitas
                Kategori_Kapasitas.ViewValue = ConvertToString(Kategori_Kapasitas.CurrentValue); // DN
                Kategori_Kapasitas.ViewCustomAttributes = "";

                // Jenis_Sartam
                Jenis_Sartam.ViewValue = ConvertToString(Jenis_Sartam.CurrentValue); // DN
                Jenis_Sartam.ViewCustomAttributes = "";

                // Type_Sartam
                Type_Sartam.ViewValue = ConvertToString(Type_Sartam.CurrentValue); // DN
                Type_Sartam.ViewCustomAttributes = "";

                // Tahun_Pembuatan
                Tahun_Pembuatan.ViewValue = ConvertToString(Tahun_Pembuatan.CurrentValue); // DN
                Tahun_Pembuatan.ViewCustomAttributes = "";

                // Kategori_Port
                Kategori_Port.ViewValue = ConvertToString(Kategori_Port.CurrentValue); // DN
                Kategori_Port.ViewCustomAttributes = "";

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

                // Region
                Region.HrefValue = "";

                // Id_Plant
                Id_Plant.HrefValue = "";

                // TBBM
                TBBM.HrefValue = "";

                // Equipment_ID
                Equipment_ID.HrefValue = "";

                // Fungsi
                Fungsi.HrefValue = "";

                // Kapasitas_DWT
                Kapasitas_DWT.HrefValue = "";

                // Kategori_Kapasitas
                Kategori_Kapasitas.HrefValue = "";

                // Jenis_Sartam
                Jenis_Sartam.HrefValue = "";

                // Type_Sartam
                Type_Sartam.HrefValue = "";

                // Tahun_Pembuatan
                Tahun_Pembuatan.HrefValue = "";

                // Kategori_Port
                Kategori_Port.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // Region
                Region.SetupEditAttributes();
                if (!Region.Raw)
                    Region.CurrentValue = HtmlDecode(Region.CurrentValue);
                Region.EditValue = HtmlEncode(Region.CurrentValue);
                Region.PlaceHolder = RemoveHtml(Region.Caption);

                // Id_Plant
                Id_Plant.SetupEditAttributes();
                string curVal = ConvertToString(Id_Plant.CurrentValue);
                if (Id_Plant.Lookup != null && IsDictionary(Id_Plant.Lookup?.Options) && Id_Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Id_Plant.EditValue = Id_Plant.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk = "";
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter(Id_Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Id_Plant.CurrentValue, Id_Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk = Id_Plant.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Id_Plant.EditValue = rswrk;
                }
                Id_Plant.PlaceHolder = RemoveHtml(Id_Plant.Caption);
                if (!Empty(Id_Plant.EditValue) && IsNumeric(Id_Plant.EditValue))
                    Id_Plant.EditValue = FormatNumber(Id_Plant.EditValue, null);

                // TBBM
                TBBM.SetupEditAttributes();
                if (!TBBM.Raw)
                    TBBM.CurrentValue = HtmlDecode(TBBM.CurrentValue);
                TBBM.EditValue = HtmlEncode(TBBM.CurrentValue);
                TBBM.PlaceHolder = RemoveHtml(TBBM.Caption);

                // Equipment_ID
                Equipment_ID.SetupEditAttributes();
                if (!Equipment_ID.Raw)
                    Equipment_ID.CurrentValue = HtmlDecode(Equipment_ID.CurrentValue);
                Equipment_ID.EditValue = HtmlEncode(Equipment_ID.CurrentValue);
                Equipment_ID.PlaceHolder = RemoveHtml(Equipment_ID.Caption);

                // Fungsi
                Fungsi.SetupEditAttributes();
                if (!Fungsi.Raw)
                    Fungsi.CurrentValue = HtmlDecode(Fungsi.CurrentValue);
                Fungsi.EditValue = HtmlEncode(Fungsi.CurrentValue);
                Fungsi.PlaceHolder = RemoveHtml(Fungsi.Caption);

                // Kapasitas_DWT
                Kapasitas_DWT.SetupEditAttributes();
                if (!Kapasitas_DWT.Raw)
                    Kapasitas_DWT.CurrentValue = HtmlDecode(Kapasitas_DWT.CurrentValue);
                Kapasitas_DWT.EditValue = HtmlEncode(Kapasitas_DWT.CurrentValue);
                Kapasitas_DWT.PlaceHolder = RemoveHtml(Kapasitas_DWT.Caption);

                // Kategori_Kapasitas
                Kategori_Kapasitas.SetupEditAttributes();
                if (!Kategori_Kapasitas.Raw)
                    Kategori_Kapasitas.CurrentValue = HtmlDecode(Kategori_Kapasitas.CurrentValue);
                Kategori_Kapasitas.EditValue = HtmlEncode(Kategori_Kapasitas.CurrentValue);
                Kategori_Kapasitas.PlaceHolder = RemoveHtml(Kategori_Kapasitas.Caption);

                // Jenis_Sartam
                Jenis_Sartam.SetupEditAttributes();
                if (!Jenis_Sartam.Raw)
                    Jenis_Sartam.CurrentValue = HtmlDecode(Jenis_Sartam.CurrentValue);
                Jenis_Sartam.EditValue = HtmlEncode(Jenis_Sartam.CurrentValue);
                Jenis_Sartam.PlaceHolder = RemoveHtml(Jenis_Sartam.Caption);

                // Type_Sartam
                Type_Sartam.SetupEditAttributes();
                if (!Type_Sartam.Raw)
                    Type_Sartam.CurrentValue = HtmlDecode(Type_Sartam.CurrentValue);
                Type_Sartam.EditValue = HtmlEncode(Type_Sartam.CurrentValue);
                Type_Sartam.PlaceHolder = RemoveHtml(Type_Sartam.Caption);

                // Tahun_Pembuatan
                Tahun_Pembuatan.SetupEditAttributes();
                if (!Tahun_Pembuatan.Raw)
                    Tahun_Pembuatan.CurrentValue = HtmlDecode(Tahun_Pembuatan.CurrentValue);
                Tahun_Pembuatan.EditValue = HtmlEncode(Tahun_Pembuatan.CurrentValue);
                Tahun_Pembuatan.PlaceHolder = RemoveHtml(Tahun_Pembuatan.Caption);

                // Kategori_Port
                Kategori_Port.SetupEditAttributes();
                if (!Kategori_Port.Raw)
                    Kategori_Port.CurrentValue = HtmlDecode(Kategori_Port.CurrentValue);
                Kategori_Port.EditValue = HtmlEncode(Kategori_Port.CurrentValue);
                Kategori_Port.PlaceHolder = RemoveHtml(Kategori_Port.Caption);

                // Add refer script

                // Region
                Region.HrefValue = "";

                // Id_Plant
                Id_Plant.HrefValue = "";

                // TBBM
                TBBM.HrefValue = "";

                // Equipment_ID
                Equipment_ID.HrefValue = "";

                // Fungsi
                Fungsi.HrefValue = "";

                // Kapasitas_DWT
                Kapasitas_DWT.HrefValue = "";

                // Kategori_Kapasitas
                Kategori_Kapasitas.HrefValue = "";

                // Jenis_Sartam
                Jenis_Sartam.HrefValue = "";

                // Type_Sartam
                Type_Sartam.HrefValue = "";

                // Tahun_Pembuatan
                Tahun_Pembuatan.HrefValue = "";

                // Kategori_Port
                Kategori_Port.HrefValue = "";
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
                if (Region.Visible && Region.Required) {
                    if (!Region.IsDetailKey && Empty(Region.FormValue)) {
                        Region.AddErrorMessage(ConvertToString(Region.RequiredErrorMessage).Replace("%s", Region.Caption));
                    }
                }
                if (Id_Plant.Visible && Id_Plant.Required) {
                    if (!Id_Plant.IsDetailKey && Empty(Id_Plant.FormValue)) {
                        Id_Plant.AddErrorMessage(ConvertToString(Id_Plant.RequiredErrorMessage).Replace("%s", Id_Plant.Caption));
                    }
                }
                if (TBBM.Visible && TBBM.Required) {
                    if (!TBBM.IsDetailKey && Empty(TBBM.FormValue)) {
                        TBBM.AddErrorMessage(ConvertToString(TBBM.RequiredErrorMessage).Replace("%s", TBBM.Caption));
                    }
                }
                if (Equipment_ID.Visible && Equipment_ID.Required) {
                    if (!Equipment_ID.IsDetailKey && Empty(Equipment_ID.FormValue)) {
                        Equipment_ID.AddErrorMessage(ConvertToString(Equipment_ID.RequiredErrorMessage).Replace("%s", Equipment_ID.Caption));
                    }
                }
                if (Fungsi.Visible && Fungsi.Required) {
                    if (!Fungsi.IsDetailKey && Empty(Fungsi.FormValue)) {
                        Fungsi.AddErrorMessage(ConvertToString(Fungsi.RequiredErrorMessage).Replace("%s", Fungsi.Caption));
                    }
                }
                if (Kapasitas_DWT.Visible && Kapasitas_DWT.Required) {
                    if (!Kapasitas_DWT.IsDetailKey && Empty(Kapasitas_DWT.FormValue)) {
                        Kapasitas_DWT.AddErrorMessage(ConvertToString(Kapasitas_DWT.RequiredErrorMessage).Replace("%s", Kapasitas_DWT.Caption));
                    }
                }
                if (Kategori_Kapasitas.Visible && Kategori_Kapasitas.Required) {
                    if (!Kategori_Kapasitas.IsDetailKey && Empty(Kategori_Kapasitas.FormValue)) {
                        Kategori_Kapasitas.AddErrorMessage(ConvertToString(Kategori_Kapasitas.RequiredErrorMessage).Replace("%s", Kategori_Kapasitas.Caption));
                    }
                }
                if (Jenis_Sartam.Visible && Jenis_Sartam.Required) {
                    if (!Jenis_Sartam.IsDetailKey && Empty(Jenis_Sartam.FormValue)) {
                        Jenis_Sartam.AddErrorMessage(ConvertToString(Jenis_Sartam.RequiredErrorMessage).Replace("%s", Jenis_Sartam.Caption));
                    }
                }
                if (Type_Sartam.Visible && Type_Sartam.Required) {
                    if (!Type_Sartam.IsDetailKey && Empty(Type_Sartam.FormValue)) {
                        Type_Sartam.AddErrorMessage(ConvertToString(Type_Sartam.RequiredErrorMessage).Replace("%s", Type_Sartam.Caption));
                    }
                }
                if (Tahun_Pembuatan.Visible && Tahun_Pembuatan.Required) {
                    if (!Tahun_Pembuatan.IsDetailKey && Empty(Tahun_Pembuatan.FormValue)) {
                        Tahun_Pembuatan.AddErrorMessage(ConvertToString(Tahun_Pembuatan.RequiredErrorMessage).Replace("%s", Tahun_Pembuatan.Caption));
                    }
                }
                if (Kategori_Port.Visible && Kategori_Port.Required) {
                    if (!Kategori_Port.IsDetailKey && Empty(Kategori_Port.FormValue)) {
                        Kategori_Port.AddErrorMessage(ConvertToString(Kategori_Port.RequiredErrorMessage).Replace("%s", Kategori_Port.Caption));
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
                    rsnew["IdDermaga"] = IdDermaga.CurrentValue!;
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

                // Region
                Region.SetDbValue(rsnew, Region.CurrentValue);

                // Id_Plant
                Id_Plant.SetDbValue(rsnew, Id_Plant.CurrentValue);

                // TBBM
                TBBM.SetDbValue(rsnew, TBBM.CurrentValue);

                // Equipment_ID
                Equipment_ID.SetDbValue(rsnew, Equipment_ID.CurrentValue);

                // Fungsi
                Fungsi.SetDbValue(rsnew, Fungsi.CurrentValue);

                // Kapasitas_DWT
                Kapasitas_DWT.SetDbValue(rsnew, Kapasitas_DWT.CurrentValue);

                // Kategori_Kapasitas
                Kategori_Kapasitas.SetDbValue(rsnew, Kategori_Kapasitas.CurrentValue);

                // Jenis_Sartam
                Jenis_Sartam.SetDbValue(rsnew, Jenis_Sartam.CurrentValue);

                // Type_Sartam
                Type_Sartam.SetDbValue(rsnew, Type_Sartam.CurrentValue);

                // Tahun_Pembuatan
                Tahun_Pembuatan.SetDbValue(rsnew, Tahun_Pembuatan.CurrentValue);

                // Kategori_Port
                Kategori_Port.SetDbValue(rsnew, Kategori_Port.CurrentValue);
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
            if (row.TryGetValue("Region", out value)) // Region
                Region.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Id_Plant", out value)) // Id_Plant
                Id_Plant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TBBM", out value)) // TBBM
                TBBM.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Equipment_ID", out value)) // Equipment_ID
                Equipment_ID.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Fungsi", out value)) // Fungsi
                Fungsi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Kapasitas_DWT", out value)) // Kapasitas_DWT
                Kapasitas_DWT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Kategori_Kapasitas", out value)) // Kategori_Kapasitas
                Kategori_Kapasitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Jenis_Sartam", out value)) // Jenis_Sartam
                Jenis_Sartam.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Type_Sartam", out value)) // Type_Sartam
                Type_Sartam.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Tahun_Pembuatan", out value)) // Tahun_Pembuatan
                Tahun_Pembuatan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Kategori_Port", out value)) // Kategori_Port
                Kategori_Port.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterDermagaList")), "", TableVar, true);
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
