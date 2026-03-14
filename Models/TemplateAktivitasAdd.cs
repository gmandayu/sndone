namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// templateAktivitasAdd
    /// </summary>
    public static TemplateAktivitasAdd templateAktivitasAdd
    {
        get => HttpData.Get<TemplateAktivitasAdd>("templateAktivitasAdd")!;
        set => HttpData["templateAktivitasAdd"] = value;
    }

    /// <summary>
    /// Page class for TemplateAktivitas
    /// </summary>
    public class TemplateAktivitasAdd : TemplateAktivitasAddBase
    {
        // Constructor
        public TemplateAktivitasAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public TemplateAktivitasAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class TemplateAktivitasAddBase : TemplateAktivitas
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "templateAktivitasAdd";

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
        public TemplateAktivitasAddBase()
        {
            TableName = "TemplateAktivitas";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (templateAktivitas)
            if (templateAktivitas == null || templateAktivitas is TemplateAktivitas)
                templateAktivitas = this;

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
        public string PageName => "TemplateAktivitasAdd";

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
            IdTemplateAktivitas.Visible = false;
            IdTemplateProses.SetVisibility();
            UrutanAktivitas.SetVisibility();
            NamaAktivitas.SetVisibility();
            IdPIC.SetVisibility();
            Keterangan.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            TipeAktivitas.SetVisibility();
            _URL.SetVisibility();
        }

        // Constructor
        public TemplateAktivitasAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "TemplateAktivitasView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdTemplateAktivitas") ? dict["IdTemplateAktivitas"] : IdTemplateAktivitas.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdTemplateAktivitas.Visible = false;
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
            await SetupLookupOptions(IdTemplateProses);
            await SetupLookupOptions(IdPIC);
            await SetupLookupOptions(TipeAktivitas);

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
                if (RouteValues.TryGetValue("IdTemplateAktivitas", out rv)) { // DN
                    IdTemplateAktivitas.QueryValue = UrlDecode(rv); // DN
                } else if (Get("IdTemplateAktivitas", out sv)) {
                    IdTemplateAktivitas.QueryValue = sv.ToString();
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

            // Set up master/detail parameters
            // NOTE: must be after loadOldRecord to prevent master key values overwritten
            SetupMasterParms();

            // Load form values
            if (postBack) {
                await LoadFormValues(); // Load form values
            }

            // Set up detail parameters
            SetupDetailParms();

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
                        return Terminate("TemplateAktivitasList"); // No matching record, return to List page // DN
                    }

                    // Set up detail parameters
                    SetupDetailParms();
                    break;
                case "insert": // Add new record // DN
                    SendEmail = true; // Send email on add success
                    var res = await AddRow(rsold);
                    if (res) { // Add successful
                        if (Empty(SuccessMessage) && Post("addopt") != "1") // Skip success message for addopt (done in JavaScript)
                            SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
                        string returnUrl = "";
                        if (!Empty(CurrentDetailTable)) // Master/detail add
                            returnUrl = DetailUrl;
                        else
                            returnUrl = ReturnUrl;
                        if (GetPageName(returnUrl) == "TemplateAktivitasList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "TemplateAktivitasView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "TemplateAktivitasList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "TemplateAktivitasList"; // Return list page content
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

                        // Set up detail parameters
                        SetupDetailParms();
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
                templateAktivitasAdd?.PageRender();
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

            // Check field name 'IdTemplateProses' before field var 'x_IdTemplateProses'
            val = CurrentForm.HasValue("IdTemplateProses") ? CurrentForm.GetValue("IdTemplateProses") : CurrentForm.GetValue("x_IdTemplateProses");
            if (!IdTemplateProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTemplateProses") && !CurrentForm.HasValue("x_IdTemplateProses")) // DN
                    IdTemplateProses.Visible = false; // Disable update for API request
                else
                    IdTemplateProses.SetFormValue(val);
            }

            // Check field name 'UrutanAktivitas' before field var 'x_UrutanAktivitas'
            val = CurrentForm.HasValue("UrutanAktivitas") ? CurrentForm.GetValue("UrutanAktivitas") : CurrentForm.GetValue("x_UrutanAktivitas");
            if (!UrutanAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UrutanAktivitas") && !CurrentForm.HasValue("x_UrutanAktivitas")) // DN
                    UrutanAktivitas.Visible = false; // Disable update for API request
                else
                    UrutanAktivitas.SetFormValue(val, true, validate);
            }

            // Check field name 'NamaAktivitas' before field var 'x_NamaAktivitas'
            val = CurrentForm.HasValue("NamaAktivitas") ? CurrentForm.GetValue("NamaAktivitas") : CurrentForm.GetValue("x_NamaAktivitas");
            if (!NamaAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaAktivitas") && !CurrentForm.HasValue("x_NamaAktivitas")) // DN
                    NamaAktivitas.Visible = false; // Disable update for API request
                else
                    NamaAktivitas.SetFormValue(val);
            }

            // Check field name 'IdPIC' before field var 'x_IdPIC[]'
            val = CurrentForm.HasValue("IdPIC") ? CurrentForm.GetValue("IdPIC") : CurrentForm.GetValue("x_IdPIC[]");
            if (!IdPIC.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPIC") && !CurrentForm.HasValue("x_IdPIC[]")) // DN
                    IdPIC.Visible = false; // Disable update for API request
                else
                    IdPIC.SetFormValue(val);
            }

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }

            // Check field name 'TipeAktivitas' before field var 'x_TipeAktivitas'
            val = CurrentForm.HasValue("TipeAktivitas") ? CurrentForm.GetValue("TipeAktivitas") : CurrentForm.GetValue("x_TipeAktivitas");
            if (!TipeAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipeAktivitas") && !CurrentForm.HasValue("x_TipeAktivitas")) // DN
                    TipeAktivitas.Visible = false; // Disable update for API request
                else
                    TipeAktivitas.SetFormValue(val);
            }

            // Check field name 'URL' before field var 'x__URL'
            val = CurrentForm.HasValue("URL") ? CurrentForm.GetValue("URL") : CurrentForm.GetValue("x__URL");
            if (!_URL.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("URL") && !CurrentForm.HasValue("x__URL")) // DN
                    _URL.Visible = false; // Disable update for API request
                else
                    _URL.SetFormValue(val);
            }

            // Check field name 'IdTemplateAktivitas' before field var 'x_IdTemplateAktivitas'
            val = CurrentForm.HasValue("IdTemplateAktivitas") ? CurrentForm.GetValue("IdTemplateAktivitas") : CurrentForm.GetValue("x_IdTemplateAktivitas");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdTemplateProses.CurrentValue = IdTemplateProses.FormValue;
            UrutanAktivitas.CurrentValue = UrutanAktivitas.FormValue;
            NamaAktivitas.CurrentValue = NamaAktivitas.FormValue;
            IdPIC.CurrentValue = IdPIC.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            TipeAktivitas.CurrentValue = TipeAktivitas.FormValue;
            _URL.CurrentValue = _URL.FormValue;
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
            IdTemplateAktivitas.SetDbValue(row["IdTemplateAktivitas"]);
            IdTemplateProses.SetDbValue(row["IdTemplateProses"]);
            UrutanAktivitas.SetDbValue(row["UrutanAktivitas"]);
            NamaAktivitas.SetDbValue(row["NamaAktivitas"]);
            IdPIC.SetDbValue(row["IdPIC"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            TipeAktivitas.SetDbValue(row["TipeAktivitas"]);
            _URL.SetDbValue(row["URL"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdTemplateAktivitas", IdTemplateAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplateProses", IdTemplateProses.DefaultValue ?? DbNullValue); // DN
            row.Add("UrutanAktivitas", UrutanAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaAktivitas", NamaAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPIC", IdPIC.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeAktivitas", TipeAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("URL", _URL.DefaultValue ?? DbNullValue); // DN
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

            // IdTemplateAktivitas
            IdTemplateAktivitas.RowCssClass = "row";

            // IdTemplateProses
            IdTemplateProses.RowCssClass = "row";

            // UrutanAktivitas
            UrutanAktivitas.RowCssClass = "row";

            // NamaAktivitas
            NamaAktivitas.RowCssClass = "row";

            // IdPIC
            IdPIC.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaruiOleh
            DiperbaruiOleh.RowCssClass = "row";

            // TanggalDiperbarui
            TanggalDiperbarui.RowCssClass = "row";

            // TipeAktivitas
            TipeAktivitas.RowCssClass = "row";

            // URL
            _URL.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdTemplateAktivitas
                IdTemplateAktivitas.ViewValue = IdTemplateAktivitas.CurrentValue;
                IdTemplateAktivitas.ViewCustomAttributes = "";

                // IdTemplateProses
                string curVal = ConvertToString(IdTemplateProses.CurrentValue);
                if (!Empty(curVal)) {
                    if (IdTemplateProses.Lookup != null && IsDictionary(IdTemplateProses.Lookup?.Options) && IdTemplateProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTemplateProses.ViewValue = IdTemplateProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdTemplateProses.Lookup?.GetTable()?.Fields["IdTemplateProses"].SearchExpression, "=", IdTemplateProses.CurrentValue, IdTemplateProses.Lookup?.GetTable()?.Fields["IdTemplateProses"].SearchDataType, "");
                        string? sqlWrk = IdTemplateProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdTemplateProses.Lookup != null) { // Lookup values found
                            var listwrk = IdTemplateProses.Lookup?.RenderViewRow(rswrk[0]);
                            IdTemplateProses.ViewValue = IdTemplateProses.DisplayValue(listwrk);
                        } else {
                            IdTemplateProses.ViewValue = FormatNumber(IdTemplateProses.CurrentValue, IdTemplateProses.FormatPattern);
                        }
                    }
                } else {
                    IdTemplateProses.ViewValue = DbNullValue;
                }
                IdTemplateProses.ViewCustomAttributes = "";

                // UrutanAktivitas
                UrutanAktivitas.ViewValue = UrutanAktivitas.CurrentValue;
                UrutanAktivitas.ViewValue = FormatNumber(UrutanAktivitas.ViewValue, UrutanAktivitas.FormatPattern);
                UrutanAktivitas.ViewCustomAttributes = "";

                // NamaAktivitas
                NamaAktivitas.ViewValue = ConvertToString(NamaAktivitas.CurrentValue); // DN
                NamaAktivitas.ViewCustomAttributes = "";

                // IdPIC
                string curVal2 = ConvertToString(IdPIC.CurrentValue);
                if (!Empty(curVal2)) {
                    if (IdPIC.Lookup != null && IsDictionary(IdPIC.Lookup?.Options) && IdPIC.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPIC.ViewValue = IdPIC.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        var arWrk2 = curVal2.Split(Config.MultipleOptionSeparator);
                        string filterWrk2 = "";
                        foreach (string wrk in arWrk2)
                            AddFilter(ref filterWrk2, SearchFilter(IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchExpression, "=", wrk.Trim(), IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchDataType, ""), "OR");
                        string? sqlWrk2 = IdPIC.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && IdPIC.Lookup != null) { // Lookup values found
                            var optionsWrk = new OptionValues(rswrk2.Select(row => IdPIC.DisplayValue(IdPIC.Lookup?.RenderViewRow(row))));
                            IdPIC.ViewValue = optionsWrk.ToString(); // DN
                        } else {
                            IdPIC.ViewValue = IdPIC.CurrentValue;
                        }
                    }
                } else {
                    IdPIC.ViewValue = DbNullValue;
                }
                IdPIC.ViewCustomAttributes = "";

                // Keterangan
                Keterangan.ViewValue = ConvertToString(Keterangan.CurrentValue); // DN
                Keterangan.ViewCustomAttributes = "";

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

                // TipeAktivitas
                if (!Empty(TipeAktivitas.CurrentValue)) {
                    TipeAktivitas.ViewValue = TipeAktivitas.OptionCaption(ConvertToString(TipeAktivitas.CurrentValue));
                } else {
                    TipeAktivitas.ViewValue = DbNullValue;
                }
                TipeAktivitas.ViewCustomAttributes = "";

                // URL
                _URL.ViewValue = ConvertToString(_URL.CurrentValue); // DN
                _URL.ViewCustomAttributes = "";

                // IdTemplateProses
                IdTemplateProses.HrefValue = "";

                // UrutanAktivitas
                UrutanAktivitas.HrefValue = "";

                // NamaAktivitas
                NamaAktivitas.HrefValue = "";

                // IdPIC
                IdPIC.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // TipeAktivitas
                TipeAktivitas.HrefValue = "";

                // URL
                _URL.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // IdTemplateProses
                IdTemplateProses.SetupEditAttributes();
                if (!Empty(IdTemplateProses.SessionValue)) {
                    IdTemplateProses.CurrentValue = ForeignKeyValue(IdTemplateProses.SessionValue);
                    string curVal = ConvertToString(IdTemplateProses.CurrentValue);
                    if (!Empty(curVal)) {
                        if (IdTemplateProses.Lookup != null && IsDictionary(IdTemplateProses.Lookup?.Options) && IdTemplateProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            IdTemplateProses.ViewValue = IdTemplateProses.LookupCacheOption(curVal);
                        } else { // Lookup from database // DN
                            string filterWrk = SearchFilter(IdTemplateProses.Lookup?.GetTable()?.Fields["IdTemplateProses"].SearchExpression, "=", IdTemplateProses.CurrentValue, IdTemplateProses.Lookup?.GetTable()?.Fields["IdTemplateProses"].SearchDataType, "");
                            string? sqlWrk = IdTemplateProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                            List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk?.Count > 0 && IdTemplateProses.Lookup != null) { // Lookup values found
                                var listwrk = IdTemplateProses.Lookup?.RenderViewRow(rswrk[0]);
                                IdTemplateProses.ViewValue = IdTemplateProses.DisplayValue(listwrk);
                            } else {
                                IdTemplateProses.ViewValue = FormatNumber(IdTemplateProses.CurrentValue, IdTemplateProses.FormatPattern);
                            }
                        }
                    } else {
                        IdTemplateProses.ViewValue = DbNullValue;
                    }
                    IdTemplateProses.ViewCustomAttributes = "";
                } else {
                    string curVal = ConvertToString(IdTemplateProses.CurrentValue);
                    if (IdTemplateProses.Lookup != null && IsDictionary(IdTemplateProses.Lookup?.Options) && IdTemplateProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTemplateProses.EditValue = IdTemplateProses.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        string filterWrk = "";
                        if (curVal == "") {
                            filterWrk = "0=1";
                        } else {
                            filterWrk = SearchFilter(IdTemplateProses.Lookup?.GetTable()?.Fields["IdTemplateProses"].SearchExpression, "=", IdTemplateProses.CurrentValue, IdTemplateProses.Lookup?.GetTable()?.Fields["IdTemplateProses"].SearchDataType, "");
                        }
                        string? sqlWrk = IdTemplateProses.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        IdTemplateProses.EditValue = rswrk;
                    }
                    IdTemplateProses.PlaceHolder = RemoveHtml(IdTemplateProses.Caption);
                    if (!Empty(IdTemplateProses.EditValue) && IsNumeric(IdTemplateProses.EditValue))
                        IdTemplateProses.EditValue = FormatNumber(IdTemplateProses.EditValue, null);
                }

                // UrutanAktivitas
                UrutanAktivitas.SetupEditAttributes();
                UrutanAktivitas.EditValue = UrutanAktivitas.CurrentValue;
                UrutanAktivitas.PlaceHolder = RemoveHtml(UrutanAktivitas.Caption);
                if (!Empty(UrutanAktivitas.EditValue) && IsNumeric(UrutanAktivitas.EditValue))
                    UrutanAktivitas.EditValue = FormatNumber(UrutanAktivitas.EditValue, null);

                // NamaAktivitas
                NamaAktivitas.SetupEditAttributes();
                if (!NamaAktivitas.Raw)
                    NamaAktivitas.CurrentValue = HtmlDecode(NamaAktivitas.CurrentValue);
                NamaAktivitas.EditValue = HtmlEncode(NamaAktivitas.CurrentValue);
                NamaAktivitas.PlaceHolder = RemoveHtml(NamaAktivitas.Caption);

                // IdPIC
                IdPIC.SetupEditAttributes();
                string curVal2 = ConvertToString(IdPIC.CurrentValue);
                if (IdPIC.Lookup != null && IsDictionary(IdPIC.Lookup?.Options) && IdPIC.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPIC.EditValue = IdPIC.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk2 = "";
                    if (curVal2 == "") {
                        filterWrk2 = "0=1";
                    } else {
                        var arWrk2 = curVal2.Split(Config.MultipleOptionSeparator);
                        filterWrk2 = "";
                        for (int i = 0; i < arWrk2.Length; i++)
                            AddFilter(ref filterWrk2, SearchFilter(IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchExpression, "=", arWrk2[i].Trim(), IdPIC.Lookup?.GetTable()?.Fields["IdPIC"].SearchDataType, ""), "OR");
                    }
                    string? sqlWrk2 = IdPIC.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdPIC.EditValue = rswrk2;
                }
                IdPIC.PlaceHolder = RemoveHtml(IdPIC.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                if (!Keterangan.Raw)
                    Keterangan.CurrentValue = HtmlDecode(Keterangan.CurrentValue);
                Keterangan.EditValue = HtmlEncode(Keterangan.CurrentValue);
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // TipeAktivitas
                TipeAktivitas.SetupEditAttributes();
                TipeAktivitas.EditValue = TipeAktivitas.Options(true);
                TipeAktivitas.PlaceHolder = RemoveHtml(TipeAktivitas.Caption);

                // URL
                _URL.SetupEditAttributes();
                if (!_URL.Raw)
                    _URL.CurrentValue = HtmlDecode(_URL.CurrentValue);
                _URL.EditValue = HtmlEncode(_URL.CurrentValue);
                _URL.PlaceHolder = RemoveHtml(_URL.Caption);

                // Add refer script

                // IdTemplateProses
                IdTemplateProses.HrefValue = "";

                // UrutanAktivitas
                UrutanAktivitas.HrefValue = "";

                // NamaAktivitas
                NamaAktivitas.HrefValue = "";

                // IdPIC
                IdPIC.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // TipeAktivitas
                TipeAktivitas.HrefValue = "";

                // URL
                _URL.HrefValue = "";
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
                if (IdTemplateProses.Visible && IdTemplateProses.Required) {
                    if (!IdTemplateProses.IsDetailKey && Empty(IdTemplateProses.FormValue)) {
                        IdTemplateProses.AddErrorMessage(ConvertToString(IdTemplateProses.RequiredErrorMessage).Replace("%s", IdTemplateProses.Caption));
                    }
                }
                if (UrutanAktivitas.Visible && UrutanAktivitas.Required) {
                    if (!UrutanAktivitas.IsDetailKey && Empty(UrutanAktivitas.FormValue)) {
                        UrutanAktivitas.AddErrorMessage(ConvertToString(UrutanAktivitas.RequiredErrorMessage).Replace("%s", UrutanAktivitas.Caption));
                    }
                }
                if (!CheckInteger(UrutanAktivitas.FormValue)) {
                    UrutanAktivitas.AddErrorMessage(UrutanAktivitas.GetErrorMessage(false));
                }
                if (NamaAktivitas.Visible && NamaAktivitas.Required) {
                    if (!NamaAktivitas.IsDetailKey && Empty(NamaAktivitas.FormValue)) {
                        NamaAktivitas.AddErrorMessage(ConvertToString(NamaAktivitas.RequiredErrorMessage).Replace("%s", NamaAktivitas.Caption));
                    }
                }
                if (IdPIC.Visible && IdPIC.Required) {
                    if (Empty(IdPIC.FormValue)) {
                        IdPIC.AddErrorMessage(ConvertToString(IdPIC.RequiredErrorMessage).Replace("%s", IdPIC.Caption));
                    }
                }
                if (Keterangan.Visible && Keterangan.Required) {
                    if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                        Keterangan.AddErrorMessage(ConvertToString(Keterangan.RequiredErrorMessage).Replace("%s", Keterangan.Caption));
                    }
                }
                if (TipeAktivitas.Visible && TipeAktivitas.Required) {
                    if (!TipeAktivitas.IsDetailKey && Empty(TipeAktivitas.FormValue)) {
                        TipeAktivitas.AddErrorMessage(ConvertToString(TipeAktivitas.RequiredErrorMessage).Replace("%s", TipeAktivitas.Caption));
                    }
                }
                if (_URL.Visible && _URL.Required) {
                    if (!_URL.IsDetailKey && Empty(_URL.FormValue)) {
                        _URL.AddErrorMessage(ConvertToString(_URL.RequiredErrorMessage).Replace("%s", _URL.Caption));
                    }
                }

            // Validate detail grid
            var detailTblVar = CurrentDetailTables;
            if (detailTblVar.Contains("TemplateAktivitasDokumen") && templateAktivitasDokumen?.DetailAdd == true) {
                templateAktivitasDokumenGrid = Resolve("TemplateAktivitasDokumenGrid")!; // Get detail page object
                if (templateAktivitasDokumenGrid != null)
                    validateForm = validateForm && await templateAktivitasDokumenGrid.ValidateGridForm();
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
            string? masterFilter;
            Dictionary<string, object?> detailKeys;
            bool validMasterRecord;

            // Begin transaction
            if (!Empty(CurrentDetailTable) && UseTransaction)
                Connection.BeginTrans();

            // Load db values from rsold
            LoadDbValues(rsold);

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["IdTemplateAktivitas"] = IdTemplateAktivitas.CurrentValue!;
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

            // Add detail records
            var detailTblVar = CurrentDetailTables;
            if (detailTblVar.Contains("TemplateAktivitasDokumen") && templateAktivitasDokumen?.DetailAdd == true && result) {
                templateAktivitasDokumen.IdTemplateAktivitas.SessionValue = ConvertToString(IdTemplateAktivitas.CurrentValue); // Set master key
                templateAktivitasDokumenGrid = Resolve("TemplateAktivitasDokumenGrid")!; // Get detail page object
                if (templateAktivitasDokumenGrid != null) {
                    Security.LoadCurrentUserLevel(ProjectID + "TemplateAktivitasDokumen"); // Load user level of detail table
                    result = await templateAktivitasDokumenGrid.GridInsert();
                    Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
                }
            }

            // Commit/Rollback transaction
            if (!Empty(CurrentDetailTable) && UseTransaction) {
                if (result) {
                    Connection.CommitTrans(); // Commit transaction
                } else {
                    Connection.RollbackTrans(); // Rollback transaction
                }
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

                // IdTemplateProses
                IdTemplateProses.SetDbValue(rsnew, IdTemplateProses.CurrentValue);

                // UrutanAktivitas
                UrutanAktivitas.SetDbValue(rsnew, UrutanAktivitas.CurrentValue);

                // NamaAktivitas
                NamaAktivitas.SetDbValue(rsnew, NamaAktivitas.CurrentValue);

                // IdPIC
                IdPIC.SetDbValue(rsnew, IdPIC.CurrentValue);

                // Keterangan
                Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue);

                // TipeAktivitas
                TipeAktivitas.SetDbValue(rsnew, TipeAktivitas.CurrentValue);

                // URL
                _URL.SetDbValue(rsnew, _URL.CurrentValue);
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
            if (row.TryGetValue("IdTemplateProses", out value)) // IdTemplateProses
                IdTemplateProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("UrutanAktivitas", out value)) // UrutanAktivitas
                UrutanAktivitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NamaAktivitas", out value)) // NamaAktivitas
                NamaAktivitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdPIC", out value)) // IdPIC
                IdPIC.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TipeAktivitas", out value)) // TipeAktivitas
                TipeAktivitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("URL", out value)) // URL
                _URL.SetFormValue(ConvertToString(value));
        }

        // Set up master/detail based on QueryString
        protected void SetupMasterParms() {
            bool validMaster = false;
            StringValues masterTblVar;
            StringValues fk;
            Dictionary<string, object> foreignKeys = new();

            // Get the keys for master table
            if (Query.TryGetValue(Config.TableShowMaster, out masterTblVar) || Query.TryGetValue(Config.TableMaster, out masterTblVar)) { // Do not use Get()
                if (Empty(masterTblVar)) {
                    validMaster = true;
                    DbMasterFilter = "";
                    DbDetailFilter = "";
                }
                if (masterTblVar == "TemplateProses") {
                    validMaster = true;
                    if (templateProses != null && (Get("fk_IdTemplateProses", out fk) || Get("IdTemplateProses", out fk))) {
                        templateProses.IdTemplateProses.QueryValue = fk;
                        IdTemplateProses.QueryValue = templateProses.IdTemplateProses.QueryValue;
                        IdTemplateProses.SessionValue = IdTemplateProses.QueryValue;
                        foreignKeys.Add("IdTemplateProses", fk);
                        if (!IsNumeric(IdTemplateProses.QueryValue))
                            validMaster = false;
                    } else {
                        validMaster = false;
                    }
                }
            } else if (Form.TryGetValue(Config.TableShowMaster, out masterTblVar) || Form.TryGetValue(Config.TableMaster, out masterTblVar)) {
                if (masterTblVar == "") {
                    validMaster = true;
                    DbMasterFilter = "";
                    DbDetailFilter = "";
                }
                if (masterTblVar == "TemplateProses") {
                    validMaster = true;
                    if (templateProses != null && (Post("fk_IdTemplateProses", out fk) || Post("IdTemplateProses", out fk))) {
                        templateProses.IdTemplateProses.FormValue = fk;
                        IdTemplateProses.FormValue = templateProses.IdTemplateProses.FormValue;
                        IdTemplateProses.SessionValue = IdTemplateProses.FormValue;
                        foreignKeys.Add("IdTemplateProses", fk);
                        if (!IsNumeric(IdTemplateProses.FormValue))
                            validMaster = false;
                    } else {
                        validMaster = false;
                    }
                }
            }
            if (validMaster) {
                // Save current master table
                CurrentMasterTable = masterTblVar.ToString();

                // Clear previous master key from Session
                if (masterTblVar != "TemplateProses") {
                    if (!foreignKeys.ContainsKey("IdTemplateProses")) // Not current foreign key
                        IdTemplateProses.SessionValue = "";
                }
            }
            DbMasterFilter = MasterFilterFromSession; // Get master filter from session
            DbDetailFilter = DetailFilterFromSession; // Get detail filter from session
        }

        // Set up detail parms based on QueryString
        protected void SetupDetailParms() {
            StringValues detailTblVar = "";
            // Get the keys for master table
            if (Query.TryGetValue(Config.TableShowDetail, out detailTblVar)) { // Do not use Get()
                CurrentDetailTable = detailTblVar.ToString();
            } else {
                detailTblVar = CurrentDetailTable;
            }
            if (!Empty(detailTblVar)) {
                var detailTblVars = detailTblVar.ToString().Split(',');
                if (detailTblVars.Contains("TemplateAktivitasDokumen")) {
                    templateAktivitasDokumenGrid = Resolve("TemplateAktivitasDokumenGrid")!;
                    if (templateAktivitasDokumenGrid?.DetailAdd ?? false) {
                        if (CopyRecord)
                            templateAktivitasDokumenGrid.CurrentMode = "copy";
                        else
                            templateAktivitasDokumenGrid.CurrentMode = "add";
                        templateAktivitasDokumenGrid.CurrentAction = "gridadd";

                        // Save current master table to detail table
                        templateAktivitasDokumenGrid.CurrentMasterTable = TableVar;
                        templateAktivitasDokumenGrid.StartRecordNumber = 1;
                        templateAktivitasDokumenGrid.IdTemplateAktivitas.IsDetailKey = true;
                        templateAktivitasDokumenGrid.IdTemplateAktivitas.CurrentValue = IdTemplateAktivitas.CurrentValue;
                        templateAktivitasDokumenGrid.IdTemplateAktivitas.SessionValue = templateAktivitasDokumenGrid.IdTemplateAktivitas.CurrentValue;
                    }
                }
            }
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("TemplateAktivitasList")), "", TableVar, true);
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
