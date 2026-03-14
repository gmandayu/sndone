namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterDermagaEdit
    /// </summary>
    public static MasterDermagaEdit masterDermagaEdit
    {
        get => HttpData.Get<MasterDermagaEdit>("masterDermagaEdit")!;
        set => HttpData["masterDermagaEdit"] = value;
    }

    /// <summary>
    /// Page class for MasterDermaga
    /// </summary>
    public class MasterDermagaEdit : MasterDermagaEditBase
    {
        // Constructor
        public MasterDermagaEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterDermagaEdit() : base()
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
    public class MasterDermagaEditBase : MasterDermaga
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterDermagaEdit";

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
        public MasterDermagaEditBase()
        {
            TableName = "MasterDermaga";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

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
        public string PageName => "MasterDermagaEdit";

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
            IdDermaga.SetVisibility();
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
        public MasterDermagaEditBase(Controller? controller = null): this() { // DN
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
            await SetupLookupOptions(Id_Plant);

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
                if (RouteValues.TryGetValue("IdDermaga", out rv)) { // DN
                    IdDermaga.FormValue = UrlDecode(rv); // DN
                    IdDermaga.OldValue = IdDermaga.FormValue;
                } else if (CurrentForm.HasValue("x_IdDermaga")) {
                    IdDermaga.FormValue = CurrentForm.GetValue("x_IdDermaga");
                    IdDermaga.OldValue = IdDermaga.FormValue;
                } else if (!Empty(keyValues)) {
                    IdDermaga.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("IdDermaga", out rv)) { // DN
                        IdDermaga.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("IdDermaga", out sv)) {
                        IdDermaga.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdDermaga.CurrentValue = DbNullValue;
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
                IdDermaga.FormValue = ConvertToString(keyValues[0]);
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
                            return Terminate("MasterDermagaList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "MasterDermagaList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MasterDermagaList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MasterDermagaList"; // Return list page content
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
                masterDermagaEdit?.PageRender();
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

            // Check field name 'IdDermaga' before field var 'x_IdDermaga'
            val = CurrentForm.HasValue("IdDermaga") ? CurrentForm.GetValue("IdDermaga") : CurrentForm.GetValue("x_IdDermaga");
            if (!IdDermaga.IsDetailKey)
                IdDermaga.SetFormValue(val);

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
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdDermaga.CurrentValue = IdDermaga.FormValue;
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

                // IdDermaga
                IdDermaga.HrefValue = "";

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
            } else if (RowType == RowType.Edit) {
                // IdDermaga
                IdDermaga.SetupEditAttributes();
                IdDermaga.EditValue = IdDermaga.CurrentValue;
                IdDermaga.ViewCustomAttributes = "";

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

                // Edit refer script

                // IdDermaga
                IdDermaga.HrefValue = "";

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
                if (IdDermaga.Visible && IdDermaga.Required) {
                    if (!IdDermaga.IsDetailKey && Empty(IdDermaga.FormValue)) {
                        IdDermaga.AddErrorMessage(ConvertToString(IdDermaga.RequiredErrorMessage).Replace("%s", IdDermaga.Caption));
                    }
                }
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

            // Region
            Region.SetDbValue(rsnew, Region.CurrentValue, Region.ReadOnly);

            // Id_Plant
            Id_Plant.SetDbValue(rsnew, Id_Plant.CurrentValue, Id_Plant.ReadOnly);

            // TBBM
            TBBM.SetDbValue(rsnew, TBBM.CurrentValue, TBBM.ReadOnly);

            // Equipment_ID
            Equipment_ID.SetDbValue(rsnew, Equipment_ID.CurrentValue, Equipment_ID.ReadOnly);

            // Fungsi
            Fungsi.SetDbValue(rsnew, Fungsi.CurrentValue, Fungsi.ReadOnly);

            // Kapasitas_DWT
            Kapasitas_DWT.SetDbValue(rsnew, Kapasitas_DWT.CurrentValue, Kapasitas_DWT.ReadOnly);

            // Kategori_Kapasitas
            Kategori_Kapasitas.SetDbValue(rsnew, Kategori_Kapasitas.CurrentValue, Kategori_Kapasitas.ReadOnly);

            // Jenis_Sartam
            Jenis_Sartam.SetDbValue(rsnew, Jenis_Sartam.CurrentValue, Jenis_Sartam.ReadOnly);

            // Type_Sartam
            Type_Sartam.SetDbValue(rsnew, Type_Sartam.CurrentValue, Type_Sartam.ReadOnly);

            // Tahun_Pembuatan
            Tahun_Pembuatan.SetDbValue(rsnew, Tahun_Pembuatan.CurrentValue, Tahun_Pembuatan.ReadOnly);

            // Kategori_Port
            Kategori_Port.SetDbValue(rsnew, Kategori_Port.CurrentValue, Kategori_Port.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("Region", out value)) // Region
                Region.CurrentValue = value;
            if (row.TryGetValue("Id_Plant", out value)) // Id_Plant
                Id_Plant.CurrentValue = value;
            if (row.TryGetValue("TBBM", out value)) // TBBM
                TBBM.CurrentValue = value;
            if (row.TryGetValue("Equipment_ID", out value)) // Equipment_ID
                Equipment_ID.CurrentValue = value;
            if (row.TryGetValue("Fungsi", out value)) // Fungsi
                Fungsi.CurrentValue = value;
            if (row.TryGetValue("Kapasitas_DWT", out value)) // Kapasitas_DWT
                Kapasitas_DWT.CurrentValue = value;
            if (row.TryGetValue("Kategori_Kapasitas", out value)) // Kategori_Kapasitas
                Kategori_Kapasitas.CurrentValue = value;
            if (row.TryGetValue("Jenis_Sartam", out value)) // Jenis_Sartam
                Jenis_Sartam.CurrentValue = value;
            if (row.TryGetValue("Type_Sartam", out value)) // Type_Sartam
                Type_Sartam.CurrentValue = value;
            if (row.TryGetValue("Tahun_Pembuatan", out value)) // Tahun_Pembuatan
                Tahun_Pembuatan.CurrentValue = value;
            if (row.TryGetValue("Kategori_Port", out value)) // Kategori_Port
                Kategori_Port.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterDermagaList")), "", TableVar, true);
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
