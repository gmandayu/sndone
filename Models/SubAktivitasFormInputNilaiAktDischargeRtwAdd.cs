namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasFormInputNilaiAktDischargeRtwAdd
    /// </summary>
    public static SubAktivitasFormInputNilaiAktDischargeRtwAdd subAktivitasFormInputNilaiAktDischargeRtwAdd
    {
        get => HttpData.Get<SubAktivitasFormInputNilaiAktDischargeRtwAdd>("subAktivitasFormInputNilaiAktDischargeRtwAdd")!;
        set => HttpData["subAktivitasFormInputNilaiAktDischargeRtwAdd"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasFormInputNilaiAktDischargeRTW
    /// </summary>
    public class SubAktivitasFormInputNilaiAktDischargeRtwAdd : SubAktivitasFormInputNilaiAktDischargeRtwAddBase
    {
        // Constructor
        public SubAktivitasFormInputNilaiAktDischargeRtwAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasFormInputNilaiAktDischargeRtwAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasFormInputNilaiAktDischargeRtwAddBase : SubAktivitasFormInputNilaiAktDischargeRtw
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasFormInputNilaiAktDischargeRtwAdd";

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
        public SubAktivitasFormInputNilaiAktDischargeRtwAddBase()
        {
            TableName = "SubAktivitasFormInputNilaiAktDischargeRTW";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasFormInputNilaiAktDischargeRtw)
            if (subAktivitasFormInputNilaiAktDischargeRtw == null || subAktivitasFormInputNilaiAktDischargeRtw is SubAktivitasFormInputNilaiAktDischargeRtw)
                subAktivitasFormInputNilaiAktDischargeRtw = this;

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
        public string PageName => "SubAktivitasFormInputNilaiAktDischargeRtwAdd";

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
            NoReferensi.SetVisibility();
            idProses.SetVisibility();
            idAktifitas.SetVisibility();
            StatusAktivitas.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            Import.SetVisibility();
            ApakahAdaROB.SetVisibility();
            Tujuan.SetVisibility();
            SFAD_KLObs.SetVisibility();
            SFAD_KL15.SetVisibility();
            SFAD_Barrels.SetVisibility();
            SFAD_LT.SetVisibility();
            SFAD_MT.SetVisibility();
            NewBL_KLObs.SetVisibility();
            NewBL_KL15.SetVisibility();
            NewBL_Barrels.SetVisibility();
            NewBL_LT.SetVisibility();
            NewBL_MT.SetVisibility();
            userInput.SetVisibility();
            etlDate.SetVisibility();
            AR45B_klobs.SetVisibility();
            AR45B_kl15.SetVisibility();
            AR45B_Barrel.SetVisibility();
            AR45B_lt.SetVisibility();
            AR45B_mt.SetVisibility();
        }

        // Constructor
        public SubAktivitasFormInputNilaiAktDischargeRtwAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "SubAktivitasFormInputNilaiAktDischargeRtwView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(idProses);
            await SetupLookupOptions(idAktifitas);
            await SetupLookupOptions(StatusAktivitas);
            await SetupLookupOptions(Import);
            await SetupLookupOptions(ApakahAdaROB);
            await SetupLookupOptions(Tujuan);

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
                if (RouteValues.TryGetValue("id", out rv)) { // DN
                    id.QueryValue = UrlDecode(rv); // DN
                } else if (Get("id", out sv)) {
                    id.QueryValue = sv.ToString();
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
                        return Terminate("SubAktivitasFormInputNilaiAktDischargeRtwList"); // No matching record, return to List page // DN
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
                        if (GetPageName(returnUrl) == "SubAktivitasFormInputNilaiAktDischargeRtwList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "SubAktivitasFormInputNilaiAktDischargeRtwView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SubAktivitasFormInputNilaiAktDischargeRtwList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SubAktivitasFormInputNilaiAktDischargeRtwList"; // Return list page content
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
                subAktivitasFormInputNilaiAktDischargeRtwAdd?.PageRender();
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

            // Check field name 'NoReferensi' before field var 'x_NoReferensi'
            val = CurrentForm.HasValue("NoReferensi") ? CurrentForm.GetValue("NoReferensi") : CurrentForm.GetValue("x_NoReferensi");
            if (!NoReferensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoReferensi") && !CurrentForm.HasValue("x_NoReferensi")) // DN
                    NoReferensi.Visible = false; // Disable update for API request
                else
                    NoReferensi.SetFormValue(val);
            }

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

            // Check field name 'StatusAktivitas' before field var 'x_StatusAktivitas'
            val = CurrentForm.HasValue("StatusAktivitas") ? CurrentForm.GetValue("StatusAktivitas") : CurrentForm.GetValue("x_StatusAktivitas");
            if (!StatusAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusAktivitas") && !CurrentForm.HasValue("x_StatusAktivitas")) // DN
                    StatusAktivitas.Visible = false; // Disable update for API request
                else
                    StatusAktivitas.SetFormValue(val, true, validate);
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

            // Check field name 'Import' before field var 'x_Import'
            val = CurrentForm.HasValue("Import") ? CurrentForm.GetValue("Import") : CurrentForm.GetValue("x_Import");
            if (!Import.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Import") && !CurrentForm.HasValue("x_Import")) // DN
                    Import.Visible = false; // Disable update for API request
                else
                    Import.SetFormValue(val);
            }

            // Check field name 'ApakahAdaROB' before field var 'x_ApakahAdaROB'
            val = CurrentForm.HasValue("ApakahAdaROB") ? CurrentForm.GetValue("ApakahAdaROB") : CurrentForm.GetValue("x_ApakahAdaROB");
            if (!ApakahAdaROB.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ApakahAdaROB") && !CurrentForm.HasValue("x_ApakahAdaROB")) // DN
                    ApakahAdaROB.Visible = false; // Disable update for API request
                else
                    ApakahAdaROB.SetFormValue(val);
            }

            // Check field name 'Tujuan' before field var 'x_Tujuan'
            val = CurrentForm.HasValue("Tujuan") ? CurrentForm.GetValue("Tujuan") : CurrentForm.GetValue("x_Tujuan");
            if (!Tujuan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Tujuan") && !CurrentForm.HasValue("x_Tujuan")) // DN
                    Tujuan.Visible = false; // Disable update for API request
                else
                    Tujuan.SetFormValue(val);
            }

            // Check field name 'SFAD_KLObs' before field var 'x_SFAD_KLObs'
            val = CurrentForm.HasValue("SFAD_KLObs") ? CurrentForm.GetValue("SFAD_KLObs") : CurrentForm.GetValue("x_SFAD_KLObs");
            if (!SFAD_KLObs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_KLObs") && !CurrentForm.HasValue("x_SFAD_KLObs")) // DN
                    SFAD_KLObs.Visible = false; // Disable update for API request
                else
                    SFAD_KLObs.SetFormValue(val);
            }

            // Check field name 'SFAD_KL15' before field var 'x_SFAD_KL15'
            val = CurrentForm.HasValue("SFAD_KL15") ? CurrentForm.GetValue("SFAD_KL15") : CurrentForm.GetValue("x_SFAD_KL15");
            if (!SFAD_KL15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_KL15") && !CurrentForm.HasValue("x_SFAD_KL15")) // DN
                    SFAD_KL15.Visible = false; // Disable update for API request
                else
                    SFAD_KL15.SetFormValue(val);
            }

            // Check field name 'SFAD_Barrels' before field var 'x_SFAD_Barrels'
            val = CurrentForm.HasValue("SFAD_Barrels") ? CurrentForm.GetValue("SFAD_Barrels") : CurrentForm.GetValue("x_SFAD_Barrels");
            if (!SFAD_Barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_Barrels") && !CurrentForm.HasValue("x_SFAD_Barrels")) // DN
                    SFAD_Barrels.Visible = false; // Disable update for API request
                else
                    SFAD_Barrels.SetFormValue(val);
            }

            // Check field name 'SFAD_LT' before field var 'x_SFAD_LT'
            val = CurrentForm.HasValue("SFAD_LT") ? CurrentForm.GetValue("SFAD_LT") : CurrentForm.GetValue("x_SFAD_LT");
            if (!SFAD_LT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_LT") && !CurrentForm.HasValue("x_SFAD_LT")) // DN
                    SFAD_LT.Visible = false; // Disable update for API request
                else
                    SFAD_LT.SetFormValue(val);
            }

            // Check field name 'SFAD_MT' before field var 'x_SFAD_MT'
            val = CurrentForm.HasValue("SFAD_MT") ? CurrentForm.GetValue("SFAD_MT") : CurrentForm.GetValue("x_SFAD_MT");
            if (!SFAD_MT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SFAD_MT") && !CurrentForm.HasValue("x_SFAD_MT")) // DN
                    SFAD_MT.Visible = false; // Disable update for API request
                else
                    SFAD_MT.SetFormValue(val);
            }

            // Check field name 'NewBL_KLObs' before field var 'x_NewBL_KLObs'
            val = CurrentForm.HasValue("NewBL_KLObs") ? CurrentForm.GetValue("NewBL_KLObs") : CurrentForm.GetValue("x_NewBL_KLObs");
            if (!NewBL_KLObs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBL_KLObs") && !CurrentForm.HasValue("x_NewBL_KLObs")) // DN
                    NewBL_KLObs.Visible = false; // Disable update for API request
                else
                    NewBL_KLObs.SetFormValue(val);
            }

            // Check field name 'NewBL_KL15' before field var 'x_NewBL_KL15'
            val = CurrentForm.HasValue("NewBL_KL15") ? CurrentForm.GetValue("NewBL_KL15") : CurrentForm.GetValue("x_NewBL_KL15");
            if (!NewBL_KL15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBL_KL15") && !CurrentForm.HasValue("x_NewBL_KL15")) // DN
                    NewBL_KL15.Visible = false; // Disable update for API request
                else
                    NewBL_KL15.SetFormValue(val);
            }

            // Check field name 'NewBL_Barrels' before field var 'x_NewBL_Barrels'
            val = CurrentForm.HasValue("NewBL_Barrels") ? CurrentForm.GetValue("NewBL_Barrels") : CurrentForm.GetValue("x_NewBL_Barrels");
            if (!NewBL_Barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBL_Barrels") && !CurrentForm.HasValue("x_NewBL_Barrels")) // DN
                    NewBL_Barrels.Visible = false; // Disable update for API request
                else
                    NewBL_Barrels.SetFormValue(val);
            }

            // Check field name 'NewBL_LT' before field var 'x_NewBL_LT'
            val = CurrentForm.HasValue("NewBL_LT") ? CurrentForm.GetValue("NewBL_LT") : CurrentForm.GetValue("x_NewBL_LT");
            if (!NewBL_LT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBL_LT") && !CurrentForm.HasValue("x_NewBL_LT")) // DN
                    NewBL_LT.Visible = false; // Disable update for API request
                else
                    NewBL_LT.SetFormValue(val);
            }

            // Check field name 'NewBL_MT' before field var 'x_NewBL_MT'
            val = CurrentForm.HasValue("NewBL_MT") ? CurrentForm.GetValue("NewBL_MT") : CurrentForm.GetValue("x_NewBL_MT");
            if (!NewBL_MT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NewBL_MT") && !CurrentForm.HasValue("x_NewBL_MT")) // DN
                    NewBL_MT.Visible = false; // Disable update for API request
                else
                    NewBL_MT.SetFormValue(val);
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

            // Check field name 'AR45B_klobs' before field var 'x_AR45B_klobs'
            val = CurrentForm.HasValue("AR45B_klobs") ? CurrentForm.GetValue("AR45B_klobs") : CurrentForm.GetValue("x_AR45B_klobs");
            if (!AR45B_klobs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_klobs") && !CurrentForm.HasValue("x_AR45B_klobs")) // DN
                    AR45B_klobs.Visible = false; // Disable update for API request
                else
                    AR45B_klobs.SetFormValue(val);
            }

            // Check field name 'AR45B_kl15' before field var 'x_AR45B_kl15'
            val = CurrentForm.HasValue("AR45B_kl15") ? CurrentForm.GetValue("AR45B_kl15") : CurrentForm.GetValue("x_AR45B_kl15");
            if (!AR45B_kl15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_kl15") && !CurrentForm.HasValue("x_AR45B_kl15")) // DN
                    AR45B_kl15.Visible = false; // Disable update for API request
                else
                    AR45B_kl15.SetFormValue(val);
            }

            // Check field name 'AR45B_Barrel' before field var 'x_AR45B_Barrel'
            val = CurrentForm.HasValue("AR45B_Barrel") ? CurrentForm.GetValue("AR45B_Barrel") : CurrentForm.GetValue("x_AR45B_Barrel");
            if (!AR45B_Barrel.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_Barrel") && !CurrentForm.HasValue("x_AR45B_Barrel")) // DN
                    AR45B_Barrel.Visible = false; // Disable update for API request
                else
                    AR45B_Barrel.SetFormValue(val);
            }

            // Check field name 'AR45B_lt' before field var 'x_AR45B_lt'
            val = CurrentForm.HasValue("AR45B_lt") ? CurrentForm.GetValue("AR45B_lt") : CurrentForm.GetValue("x_AR45B_lt");
            if (!AR45B_lt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_lt") && !CurrentForm.HasValue("x_AR45B_lt")) // DN
                    AR45B_lt.Visible = false; // Disable update for API request
                else
                    AR45B_lt.SetFormValue(val);
            }

            // Check field name 'AR45B_mt' before field var 'x_AR45B_mt'
            val = CurrentForm.HasValue("AR45B_mt") ? CurrentForm.GetValue("AR45B_mt") : CurrentForm.GetValue("x_AR45B_mt");
            if (!AR45B_mt.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AR45B_mt") && !CurrentForm.HasValue("x_AR45B_mt")) // DN
                    AR45B_mt.Visible = false; // Disable update for API request
                else
                    AR45B_mt.SetFormValue(val);
            }

            // Check field name 'id' before field var 'x_id'
            val = CurrentForm.HasValue("id") ? CurrentForm.GetValue("id") : CurrentForm.GetValue("x_id");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            Import.CurrentValue = Import.FormValue;
            ApakahAdaROB.CurrentValue = ApakahAdaROB.FormValue;
            Tujuan.CurrentValue = Tujuan.FormValue;
            SFAD_KLObs.CurrentValue = SFAD_KLObs.FormValue;
            SFAD_KL15.CurrentValue = SFAD_KL15.FormValue;
            SFAD_Barrels.CurrentValue = SFAD_Barrels.FormValue;
            SFAD_LT.CurrentValue = SFAD_LT.FormValue;
            SFAD_MT.CurrentValue = SFAD_MT.FormValue;
            NewBL_KLObs.CurrentValue = NewBL_KLObs.FormValue;
            NewBL_KL15.CurrentValue = NewBL_KL15.FormValue;
            NewBL_Barrels.CurrentValue = NewBL_Barrels.FormValue;
            NewBL_LT.CurrentValue = NewBL_LT.FormValue;
            NewBL_MT.CurrentValue = NewBL_MT.FormValue;
            userInput.CurrentValue = userInput.FormValue;
            etlDate.CurrentValue = etlDate.FormValue;
            etlDate.CurrentValue = UnformatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            AR45B_klobs.CurrentValue = AR45B_klobs.FormValue;
            AR45B_kl15.CurrentValue = AR45B_kl15.FormValue;
            AR45B_Barrel.CurrentValue = AR45B_Barrel.FormValue;
            AR45B_lt.CurrentValue = AR45B_lt.FormValue;
            AR45B_mt.CurrentValue = AR45B_mt.FormValue;
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
            NoReferensi.SetDbValue(row["NoReferensi"]);
            idProses.SetDbValue(row["idProses"]);
            idAktifitas.SetDbValue(row["idAktifitas"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            Import.SetDbValue((ConvertToBool(row["Import"]) ? "1" : "0"));
            ApakahAdaROB.SetDbValue((ConvertToBool(row["ApakahAdaROB"]) ? "1" : "0"));
            Tujuan.SetDbValue(row["Tujuan"]);
            SFAD_KLObs.SetDbValue(row["SFAD_KLObs"]);
            SFAD_KL15.SetDbValue(row["SFAD_KL15"]);
            SFAD_Barrels.SetDbValue(row["SFAD_Barrels"]);
            SFAD_LT.SetDbValue(row["SFAD_LT"]);
            SFAD_MT.SetDbValue(row["SFAD_MT"]);
            NewBL_KLObs.SetDbValue(row["NewBL_KLObs"]);
            NewBL_KL15.SetDbValue(row["NewBL_KL15"]);
            NewBL_Barrels.SetDbValue(row["NewBL_Barrels"]);
            NewBL_LT.SetDbValue(row["NewBL_LT"]);
            NewBL_MT.SetDbValue(row["NewBL_MT"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            AR45B_klobs.SetDbValue(row["AR45B_klobs"]);
            AR45B_kl15.SetDbValue(row["AR45B_kl15"]);
            AR45B_Barrel.SetDbValue(row["AR45B_Barrel"]);
            AR45B_lt.SetDbValue(row["AR45B_lt"]);
            AR45B_mt.SetDbValue(row["AR45B_mt"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("Import", Import.DefaultValue ?? DbNullValue); // DN
            row.Add("ApakahAdaROB", ApakahAdaROB.DefaultValue ?? DbNullValue); // DN
            row.Add("Tujuan", Tujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_KLObs", SFAD_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_KL15", SFAD_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_Barrels", SFAD_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_LT", SFAD_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("SFAD_MT", SFAD_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_KLObs", NewBL_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_KL15", NewBL_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_Barrels", NewBL_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_LT", NewBL_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("NewBL_MT", NewBL_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_klobs", AR45B_klobs.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_kl15", AR45B_kl15.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_Barrel", AR45B_Barrel.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_lt", AR45B_lt.DefaultValue ?? DbNullValue); // DN
            row.Add("AR45B_mt", AR45B_mt.DefaultValue ?? DbNullValue); // DN
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

            // NoReferensi
            NoReferensi.RowCssClass = "row";

            // idProses
            idProses.RowCssClass = "row";

            // idAktifitas
            idAktifitas.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // Import
            Import.RowCssClass = "row";

            // ApakahAdaROB
            ApakahAdaROB.RowCssClass = "row";

            // Tujuan
            Tujuan.RowCssClass = "row";

            // SFAD_KLObs
            SFAD_KLObs.RowCssClass = "row";

            // SFAD_KL15
            SFAD_KL15.RowCssClass = "row";

            // SFAD_Barrels
            SFAD_Barrels.RowCssClass = "row";

            // SFAD_LT
            SFAD_LT.RowCssClass = "row";

            // SFAD_MT
            SFAD_MT.RowCssClass = "row";

            // NewBL_KLObs
            NewBL_KLObs.RowCssClass = "row";

            // NewBL_KL15
            NewBL_KL15.RowCssClass = "row";

            // NewBL_Barrels
            NewBL_Barrels.RowCssClass = "row";

            // NewBL_LT
            NewBL_LT.RowCssClass = "row";

            // NewBL_MT
            NewBL_MT.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // AR45B_klobs
            AR45B_klobs.RowCssClass = "row";

            // AR45B_kl15
            AR45B_kl15.RowCssClass = "row";

            // AR45B_Barrel
            AR45B_Barrel.RowCssClass = "row";

            // AR45B_lt
            AR45B_lt.RowCssClass = "row";

            // AR45B_mt
            AR45B_mt.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                NoReferensi.ViewCustomAttributes = "";

                // idProses
                idProses.ViewValue = idProses.CurrentValue;
                string curVal = ConvertToString(idProses.CurrentValue);
                if (!Empty(curVal)) {
                    if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idProses.ViewValue = idProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk = idProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                            var listwrk = idProses.Lookup?.RenderViewRow(rswrk[0]);
                            idProses.ViewValue = idProses.DisplayValue(listwrk);
                        } else {
                            idProses.ViewValue = FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
                        }
                    }
                } else {
                    idProses.ViewValue = DbNullValue;
                }
                idProses.ViewCustomAttributes = "";

                // idAktifitas
                idAktifitas.ViewValue = idAktifitas.CurrentValue;
                string curVal2 = ConvertToString(idAktifitas.CurrentValue);
                if (!Empty(curVal2)) {
                    if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idAktifitas.ViewValue = idAktifitas.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk2 = idAktifitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                            var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk2[0]);
                            idAktifitas.ViewValue = idAktifitas.DisplayValue(listwrk);
                        } else {
                            idAktifitas.ViewValue = FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
                        }
                    }
                } else {
                    idAktifitas.ViewValue = DbNullValue;
                }
                idAktifitas.ViewCustomAttributes = "";

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

                // Import
                if (ConvertToBool(Import.CurrentValue)) {
                    Import.ViewValue = Import.TagCaption(1) != "" ? Import.TagCaption(1) : "Yes";
                } else {
                    Import.ViewValue = Import.TagCaption(2) != "" ? Import.TagCaption(2) : "No";
                }
                Import.ViewCustomAttributes = "";

                // ApakahAdaROB
                if (ConvertToBool(ApakahAdaROB.CurrentValue)) {
                    ApakahAdaROB.ViewValue = ApakahAdaROB.TagCaption(1) != "" ? ApakahAdaROB.TagCaption(1) : "Yes";
                } else {
                    ApakahAdaROB.ViewValue = ApakahAdaROB.TagCaption(2) != "" ? ApakahAdaROB.TagCaption(2) : "No";
                }
                ApakahAdaROB.ViewCustomAttributes = "";

                // Tujuan
                string curVal6 = ConvertToString(Tujuan.CurrentValue);
                if (!Empty(curVal6)) {
                    if (Tujuan.Lookup != null && IsDictionary(Tujuan.Lookup?.Options) && Tujuan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Tujuan.ViewValue = Tujuan.LookupCacheOption(curVal6);
                    } else { // Lookup from database // DN
                        string filterWrk6 = SearchFilter(Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Tujuan.CurrentValue, Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk6 = Tujuan.Lookup?.GetSql(false, filterWrk6, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk6 = sqlWrk6 != null ? Connection.GetRows(sqlWrk6) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk6?.Count > 0 && Tujuan.Lookup != null) { // Lookup values found
                            var listwrk = Tujuan.Lookup?.RenderViewRow(rswrk6[0]);
                            Tujuan.ViewValue = Tujuan.DisplayValue(listwrk);
                        } else {
                            Tujuan.ViewValue = Tujuan.CurrentValue;
                        }
                    }
                } else {
                    Tujuan.ViewValue = DbNullValue;
                }
                Tujuan.ViewCustomAttributes = "";

                // SFAD_KLObs
                SFAD_KLObs.ViewValue = ConvertToString(SFAD_KLObs.CurrentValue); // DN
                SFAD_KLObs.ViewCustomAttributes = "";

                // SFAD_KL15
                SFAD_KL15.ViewValue = ConvertToString(SFAD_KL15.CurrentValue); // DN
                SFAD_KL15.ViewCustomAttributes = "";

                // SFAD_Barrels
                SFAD_Barrels.ViewValue = ConvertToString(SFAD_Barrels.CurrentValue); // DN
                SFAD_Barrels.ViewCustomAttributes = "";

                // SFAD_LT
                SFAD_LT.ViewValue = ConvertToString(SFAD_LT.CurrentValue); // DN
                SFAD_LT.ViewCustomAttributes = "";

                // SFAD_MT
                SFAD_MT.ViewValue = ConvertToString(SFAD_MT.CurrentValue); // DN
                SFAD_MT.ViewCustomAttributes = "";

                // NewBL_KLObs
                NewBL_KLObs.ViewValue = ConvertToString(NewBL_KLObs.CurrentValue); // DN
                NewBL_KLObs.ViewCustomAttributes = "";

                // NewBL_KL15
                NewBL_KL15.ViewValue = ConvertToString(NewBL_KL15.CurrentValue); // DN
                NewBL_KL15.ViewCustomAttributes = "";

                // NewBL_Barrels
                NewBL_Barrels.ViewValue = ConvertToString(NewBL_Barrels.CurrentValue); // DN
                NewBL_Barrels.ViewCustomAttributes = "";

                // NewBL_LT
                NewBL_LT.ViewValue = ConvertToString(NewBL_LT.CurrentValue); // DN
                NewBL_LT.ViewCustomAttributes = "";

                // NewBL_MT
                NewBL_MT.ViewValue = ConvertToString(NewBL_MT.CurrentValue); // DN
                NewBL_MT.ViewCustomAttributes = "";

                // userInput
                userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
                userInput.ViewCustomAttributes = "";

                // etlDate
                etlDate.ViewValue = etlDate.CurrentValue;
                etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
                etlDate.ViewCustomAttributes = "";

                // AR45B_klobs
                AR45B_klobs.ViewValue = ConvertToString(AR45B_klobs.CurrentValue); // DN
                AR45B_klobs.ViewCustomAttributes = "";

                // AR45B_kl15
                AR45B_kl15.ViewValue = ConvertToString(AR45B_kl15.CurrentValue); // DN
                AR45B_kl15.ViewCustomAttributes = "";

                // AR45B_Barrel
                AR45B_Barrel.ViewValue = ConvertToString(AR45B_Barrel.CurrentValue); // DN
                AR45B_Barrel.ViewCustomAttributes = "";

                // AR45B_lt
                AR45B_lt.ViewValue = ConvertToString(AR45B_lt.CurrentValue); // DN
                AR45B_lt.ViewCustomAttributes = "";

                // AR45B_mt
                AR45B_mt.ViewValue = ConvertToString(AR45B_mt.CurrentValue); // DN
                AR45B_mt.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // Import
                Import.HrefValue = "";

                // ApakahAdaROB
                ApakahAdaROB.HrefValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // SFAD_KLObs
                SFAD_KLObs.HrefValue = "";

                // SFAD_KL15
                SFAD_KL15.HrefValue = "";

                // SFAD_Barrels
                SFAD_Barrels.HrefValue = "";

                // SFAD_LT
                SFAD_LT.HrefValue = "";

                // SFAD_MT
                SFAD_MT.HrefValue = "";

                // NewBL_KLObs
                NewBL_KLObs.HrefValue = "";

                // NewBL_KL15
                NewBL_KL15.HrefValue = "";

                // NewBL_Barrels
                NewBL_Barrels.HrefValue = "";

                // NewBL_LT
                NewBL_LT.HrefValue = "";

                // NewBL_MT
                NewBL_MT.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // AR45B_klobs
                AR45B_klobs.HrefValue = "";

                // AR45B_kl15
                AR45B_kl15.HrefValue = "";

                // AR45B_Barrel
                AR45B_Barrel.HrefValue = "";

                // AR45B_lt
                AR45B_lt.HrefValue = "";

                // AR45B_mt
                AR45B_mt.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // idProses
                idProses.SetupEditAttributes();
                idProses.EditValue = idProses.CurrentValue;
                string curVal = ConvertToString(idProses.CurrentValue);
                if (!Empty(curVal)) {
                    if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idProses.EditValue = idProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk = idProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                            var listwrk = idProses.Lookup?.RenderViewRow(rswrk[0]);
                            idProses.EditValue = idProses.DisplayValue(listwrk);
                        } else {
                            idProses.EditValue = HtmlEncode(FormatNumber(idProses.CurrentValue, idProses.FormatPattern));
                        }
                    }
                } else {
                    idProses.EditValue = DbNullValue;
                }
                idProses.PlaceHolder = RemoveHtml(idProses.Caption);
                if (!Empty(idProses.EditValue) && IsNumeric(idProses.EditValue))
                    idProses.EditValue = FormatNumber(idProses.EditValue, null);

                // idAktifitas
                idAktifitas.SetupEditAttributes();
                idAktifitas.EditValue = idAktifitas.CurrentValue;
                string curVal2 = ConvertToString(idAktifitas.CurrentValue);
                if (!Empty(curVal2)) {
                    if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idAktifitas.EditValue = idAktifitas.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        string? sqlWrk2 = idAktifitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                            var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk2[0]);
                            idAktifitas.EditValue = idAktifitas.DisplayValue(listwrk);
                        } else {
                            idAktifitas.EditValue = HtmlEncode(FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern));
                        }
                    }
                } else {
                    idAktifitas.EditValue = DbNullValue;
                }
                idAktifitas.PlaceHolder = RemoveHtml(idAktifitas.Caption);
                if (!Empty(idAktifitas.EditValue) && IsNumeric(idAktifitas.EditValue))
                    idAktifitas.EditValue = FormatNumber(idAktifitas.EditValue, null);

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
                            StatusAktivitas.EditValue = HtmlEncode(FormatNumber(StatusAktivitas.CurrentValue, StatusAktivitas.FormatPattern));
                        }
                    }
                } else {
                    StatusAktivitas.EditValue = DbNullValue;
                }
                StatusAktivitas.PlaceHolder = RemoveHtml(StatusAktivitas.Caption);
                if (!Empty(StatusAktivitas.EditValue) && IsNumeric(StatusAktivitas.EditValue))
                    StatusAktivitas.EditValue = FormatNumber(StatusAktivitas.EditValue, null);

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

                // Import
                Import.EditValue = Import.Options(false);
                Import.PlaceHolder = RemoveHtml(Import.Caption);

                // ApakahAdaROB
                ApakahAdaROB.EditValue = ApakahAdaROB.Options(false);
                ApakahAdaROB.PlaceHolder = RemoveHtml(ApakahAdaROB.Caption);

                // Tujuan
                Tujuan.SetupEditAttributes();
                string curVal6 = ConvertToString(Tujuan.CurrentValue);
                if (Tujuan.Lookup != null && IsDictionary(Tujuan.Lookup?.Options) && Tujuan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Tujuan.EditValue = Tujuan.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk6 = "";
                    if (curVal6 == "") {
                        filterWrk6 = "0=1";
                    } else {
                        filterWrk6 = SearchFilter(Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Tujuan.CurrentValue, Tujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk6 = Tujuan.Lookup?.GetSql(true, filterWrk6, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk6 = sqlWrk6 != null ? Connection.GetRows(sqlWrk6) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Tujuan.EditValue = rswrk6;
                }
                Tujuan.PlaceHolder = RemoveHtml(Tujuan.Caption);

                // SFAD_KLObs
                SFAD_KLObs.SetupEditAttributes();
                if (!SFAD_KLObs.Raw)
                    SFAD_KLObs.CurrentValue = HtmlDecode(SFAD_KLObs.CurrentValue);
                SFAD_KLObs.EditValue = HtmlEncode(SFAD_KLObs.CurrentValue);
                SFAD_KLObs.PlaceHolder = RemoveHtml(SFAD_KLObs.Caption);

                // SFAD_KL15
                SFAD_KL15.SetupEditAttributes();
                if (!SFAD_KL15.Raw)
                    SFAD_KL15.CurrentValue = HtmlDecode(SFAD_KL15.CurrentValue);
                SFAD_KL15.EditValue = HtmlEncode(SFAD_KL15.CurrentValue);
                SFAD_KL15.PlaceHolder = RemoveHtml(SFAD_KL15.Caption);

                // SFAD_Barrels
                SFAD_Barrels.SetupEditAttributes();
                if (!SFAD_Barrels.Raw)
                    SFAD_Barrels.CurrentValue = HtmlDecode(SFAD_Barrels.CurrentValue);
                SFAD_Barrels.EditValue = HtmlEncode(SFAD_Barrels.CurrentValue);
                SFAD_Barrels.PlaceHolder = RemoveHtml(SFAD_Barrels.Caption);

                // SFAD_LT
                SFAD_LT.SetupEditAttributes();
                if (!SFAD_LT.Raw)
                    SFAD_LT.CurrentValue = HtmlDecode(SFAD_LT.CurrentValue);
                SFAD_LT.EditValue = HtmlEncode(SFAD_LT.CurrentValue);
                SFAD_LT.PlaceHolder = RemoveHtml(SFAD_LT.Caption);

                // SFAD_MT
                SFAD_MT.SetupEditAttributes();
                if (!SFAD_MT.Raw)
                    SFAD_MT.CurrentValue = HtmlDecode(SFAD_MT.CurrentValue);
                SFAD_MT.EditValue = HtmlEncode(SFAD_MT.CurrentValue);
                SFAD_MT.PlaceHolder = RemoveHtml(SFAD_MT.Caption);

                // NewBL_KLObs
                NewBL_KLObs.SetupEditAttributes();
                if (!NewBL_KLObs.Raw)
                    NewBL_KLObs.CurrentValue = HtmlDecode(NewBL_KLObs.CurrentValue);
                NewBL_KLObs.EditValue = HtmlEncode(NewBL_KLObs.CurrentValue);
                NewBL_KLObs.PlaceHolder = RemoveHtml(NewBL_KLObs.Caption);

                // NewBL_KL15
                NewBL_KL15.SetupEditAttributes();
                if (!NewBL_KL15.Raw)
                    NewBL_KL15.CurrentValue = HtmlDecode(NewBL_KL15.CurrentValue);
                NewBL_KL15.EditValue = HtmlEncode(NewBL_KL15.CurrentValue);
                NewBL_KL15.PlaceHolder = RemoveHtml(NewBL_KL15.Caption);

                // NewBL_Barrels
                NewBL_Barrels.SetupEditAttributes();
                if (!NewBL_Barrels.Raw)
                    NewBL_Barrels.CurrentValue = HtmlDecode(NewBL_Barrels.CurrentValue);
                NewBL_Barrels.EditValue = HtmlEncode(NewBL_Barrels.CurrentValue);
                NewBL_Barrels.PlaceHolder = RemoveHtml(NewBL_Barrels.Caption);

                // NewBL_LT
                NewBL_LT.SetupEditAttributes();
                if (!NewBL_LT.Raw)
                    NewBL_LT.CurrentValue = HtmlDecode(NewBL_LT.CurrentValue);
                NewBL_LT.EditValue = HtmlEncode(NewBL_LT.CurrentValue);
                NewBL_LT.PlaceHolder = RemoveHtml(NewBL_LT.Caption);

                // NewBL_MT
                NewBL_MT.SetupEditAttributes();
                if (!NewBL_MT.Raw)
                    NewBL_MT.CurrentValue = HtmlDecode(NewBL_MT.CurrentValue);
                NewBL_MT.EditValue = HtmlEncode(NewBL_MT.CurrentValue);
                NewBL_MT.PlaceHolder = RemoveHtml(NewBL_MT.Caption);

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

                // AR45B_klobs
                AR45B_klobs.SetupEditAttributes();
                if (!AR45B_klobs.Raw)
                    AR45B_klobs.CurrentValue = HtmlDecode(AR45B_klobs.CurrentValue);
                AR45B_klobs.EditValue = HtmlEncode(AR45B_klobs.CurrentValue);
                AR45B_klobs.PlaceHolder = RemoveHtml(AR45B_klobs.Caption);

                // AR45B_kl15
                AR45B_kl15.SetupEditAttributes();
                if (!AR45B_kl15.Raw)
                    AR45B_kl15.CurrentValue = HtmlDecode(AR45B_kl15.CurrentValue);
                AR45B_kl15.EditValue = HtmlEncode(AR45B_kl15.CurrentValue);
                AR45B_kl15.PlaceHolder = RemoveHtml(AR45B_kl15.Caption);

                // AR45B_Barrel
                AR45B_Barrel.SetupEditAttributes();
                if (!AR45B_Barrel.Raw)
                    AR45B_Barrel.CurrentValue = HtmlDecode(AR45B_Barrel.CurrentValue);
                AR45B_Barrel.EditValue = HtmlEncode(AR45B_Barrel.CurrentValue);
                AR45B_Barrel.PlaceHolder = RemoveHtml(AR45B_Barrel.Caption);

                // AR45B_lt
                AR45B_lt.SetupEditAttributes();
                if (!AR45B_lt.Raw)
                    AR45B_lt.CurrentValue = HtmlDecode(AR45B_lt.CurrentValue);
                AR45B_lt.EditValue = HtmlEncode(AR45B_lt.CurrentValue);
                AR45B_lt.PlaceHolder = RemoveHtml(AR45B_lt.Caption);

                // AR45B_mt
                AR45B_mt.SetupEditAttributes();
                if (!AR45B_mt.Raw)
                    AR45B_mt.CurrentValue = HtmlDecode(AR45B_mt.CurrentValue);
                AR45B_mt.EditValue = HtmlEncode(AR45B_mt.CurrentValue);
                AR45B_mt.PlaceHolder = RemoveHtml(AR45B_mt.Caption);

                // Add refer script

                // NoReferensi
                NoReferensi.HrefValue = "";

                // idProses
                idProses.HrefValue = "";

                // idAktifitas
                idAktifitas.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";

                // Import
                Import.HrefValue = "";

                // ApakahAdaROB
                ApakahAdaROB.HrefValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // SFAD_KLObs
                SFAD_KLObs.HrefValue = "";

                // SFAD_KL15
                SFAD_KL15.HrefValue = "";

                // SFAD_Barrels
                SFAD_Barrels.HrefValue = "";

                // SFAD_LT
                SFAD_LT.HrefValue = "";

                // SFAD_MT
                SFAD_MT.HrefValue = "";

                // NewBL_KLObs
                NewBL_KLObs.HrefValue = "";

                // NewBL_KL15
                NewBL_KL15.HrefValue = "";

                // NewBL_Barrels
                NewBL_Barrels.HrefValue = "";

                // NewBL_LT
                NewBL_LT.HrefValue = "";

                // NewBL_MT
                NewBL_MT.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // AR45B_klobs
                AR45B_klobs.HrefValue = "";

                // AR45B_kl15
                AR45B_kl15.HrefValue = "";

                // AR45B_Barrel
                AR45B_Barrel.HrefValue = "";

                // AR45B_lt
                AR45B_lt.HrefValue = "";

                // AR45B_mt
                AR45B_mt.HrefValue = "";
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
                if (NoReferensi.Visible && NoReferensi.Required) {
                    if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                        NoReferensi.AddErrorMessage(ConvertToString(NoReferensi.RequiredErrorMessage).Replace("%s", NoReferensi.Caption));
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
                if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                    if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                        StatusAktivitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                    }
                }
                if (!CheckInteger(StatusAktivitas.FormValue)) {
                    StatusAktivitas.AddErrorMessage(StatusAktivitas.GetErrorMessage(false));
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
                if (Import.Visible && Import.Required) {
                    if (Empty(Import.FormValue)) {
                        Import.AddErrorMessage(ConvertToString(Import.RequiredErrorMessage).Replace("%s", Import.Caption));
                    }
                }
                if (ApakahAdaROB.Visible && ApakahAdaROB.Required) {
                    if (Empty(ApakahAdaROB.FormValue)) {
                        ApakahAdaROB.AddErrorMessage(ConvertToString(ApakahAdaROB.RequiredErrorMessage).Replace("%s", ApakahAdaROB.Caption));
                    }
                }
                if (Tujuan.Visible && Tujuan.Required) {
                    if (!Tujuan.IsDetailKey && Empty(Tujuan.FormValue)) {
                        Tujuan.AddErrorMessage(ConvertToString(Tujuan.RequiredErrorMessage).Replace("%s", Tujuan.Caption));
                    }
                }
                if (SFAD_KLObs.Visible && SFAD_KLObs.Required) {
                    if (!SFAD_KLObs.IsDetailKey && Empty(SFAD_KLObs.FormValue)) {
                        SFAD_KLObs.AddErrorMessage(ConvertToString(SFAD_KLObs.RequiredErrorMessage).Replace("%s", SFAD_KLObs.Caption));
                    }
                }
                if (SFAD_KL15.Visible && SFAD_KL15.Required) {
                    if (!SFAD_KL15.IsDetailKey && Empty(SFAD_KL15.FormValue)) {
                        SFAD_KL15.AddErrorMessage(ConvertToString(SFAD_KL15.RequiredErrorMessage).Replace("%s", SFAD_KL15.Caption));
                    }
                }
                if (SFAD_Barrels.Visible && SFAD_Barrels.Required) {
                    if (!SFAD_Barrels.IsDetailKey && Empty(SFAD_Barrels.FormValue)) {
                        SFAD_Barrels.AddErrorMessage(ConvertToString(SFAD_Barrels.RequiredErrorMessage).Replace("%s", SFAD_Barrels.Caption));
                    }
                }
                if (SFAD_LT.Visible && SFAD_LT.Required) {
                    if (!SFAD_LT.IsDetailKey && Empty(SFAD_LT.FormValue)) {
                        SFAD_LT.AddErrorMessage(ConvertToString(SFAD_LT.RequiredErrorMessage).Replace("%s", SFAD_LT.Caption));
                    }
                }
                if (SFAD_MT.Visible && SFAD_MT.Required) {
                    if (!SFAD_MT.IsDetailKey && Empty(SFAD_MT.FormValue)) {
                        SFAD_MT.AddErrorMessage(ConvertToString(SFAD_MT.RequiredErrorMessage).Replace("%s", SFAD_MT.Caption));
                    }
                }
                if (NewBL_KLObs.Visible && NewBL_KLObs.Required) {
                    if (!NewBL_KLObs.IsDetailKey && Empty(NewBL_KLObs.FormValue)) {
                        NewBL_KLObs.AddErrorMessage(ConvertToString(NewBL_KLObs.RequiredErrorMessage).Replace("%s", NewBL_KLObs.Caption));
                    }
                }
                if (NewBL_KL15.Visible && NewBL_KL15.Required) {
                    if (!NewBL_KL15.IsDetailKey && Empty(NewBL_KL15.FormValue)) {
                        NewBL_KL15.AddErrorMessage(ConvertToString(NewBL_KL15.RequiredErrorMessage).Replace("%s", NewBL_KL15.Caption));
                    }
                }
                if (NewBL_Barrels.Visible && NewBL_Barrels.Required) {
                    if (!NewBL_Barrels.IsDetailKey && Empty(NewBL_Barrels.FormValue)) {
                        NewBL_Barrels.AddErrorMessage(ConvertToString(NewBL_Barrels.RequiredErrorMessage).Replace("%s", NewBL_Barrels.Caption));
                    }
                }
                if (NewBL_LT.Visible && NewBL_LT.Required) {
                    if (!NewBL_LT.IsDetailKey && Empty(NewBL_LT.FormValue)) {
                        NewBL_LT.AddErrorMessage(ConvertToString(NewBL_LT.RequiredErrorMessage).Replace("%s", NewBL_LT.Caption));
                    }
                }
                if (NewBL_MT.Visible && NewBL_MT.Required) {
                    if (!NewBL_MT.IsDetailKey && Empty(NewBL_MT.FormValue)) {
                        NewBL_MT.AddErrorMessage(ConvertToString(NewBL_MT.RequiredErrorMessage).Replace("%s", NewBL_MT.Caption));
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
                if (AR45B_klobs.Visible && AR45B_klobs.Required) {
                    if (!AR45B_klobs.IsDetailKey && Empty(AR45B_klobs.FormValue)) {
                        AR45B_klobs.AddErrorMessage(ConvertToString(AR45B_klobs.RequiredErrorMessage).Replace("%s", AR45B_klobs.Caption));
                    }
                }
                if (AR45B_kl15.Visible && AR45B_kl15.Required) {
                    if (!AR45B_kl15.IsDetailKey && Empty(AR45B_kl15.FormValue)) {
                        AR45B_kl15.AddErrorMessage(ConvertToString(AR45B_kl15.RequiredErrorMessage).Replace("%s", AR45B_kl15.Caption));
                    }
                }
                if (AR45B_Barrel.Visible && AR45B_Barrel.Required) {
                    if (!AR45B_Barrel.IsDetailKey && Empty(AR45B_Barrel.FormValue)) {
                        AR45B_Barrel.AddErrorMessage(ConvertToString(AR45B_Barrel.RequiredErrorMessage).Replace("%s", AR45B_Barrel.Caption));
                    }
                }
                if (AR45B_lt.Visible && AR45B_lt.Required) {
                    if (!AR45B_lt.IsDetailKey && Empty(AR45B_lt.FormValue)) {
                        AR45B_lt.AddErrorMessage(ConvertToString(AR45B_lt.RequiredErrorMessage).Replace("%s", AR45B_lt.Caption));
                    }
                }
                if (AR45B_mt.Visible && AR45B_mt.Required) {
                    if (!AR45B_mt.IsDetailKey && Empty(AR45B_mt.FormValue)) {
                        AR45B_mt.AddErrorMessage(ConvertToString(AR45B_mt.RequiredErrorMessage).Replace("%s", AR45B_mt.Caption));
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
                    rsnew["id"] = id.CurrentValue!;
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

                // NoReferensi
                NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue);

                // idProses
                idProses.SetDbValue(rsnew, idProses.CurrentValue);

                // idAktifitas
                idAktifitas.SetDbValue(rsnew, idAktifitas.CurrentValue);

                // StatusAktivitas
                StatusAktivitas.SetDbValue(rsnew, StatusAktivitas.CurrentValue);

                // LastUpdatedBy
                LastUpdatedBy.SetDbValue(rsnew, LastUpdatedBy.CurrentValue);

                // lastUpdatedDate
                lastUpdatedDate.SetDbValue(rsnew, ConvertToDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern));

                // Import
                Import.SetDbValue(rsnew, ConvertToBool(Import.CurrentValue));

                // ApakahAdaROB
                ApakahAdaROB.SetDbValue(rsnew, ConvertToBool(ApakahAdaROB.CurrentValue));

                // Tujuan
                Tujuan.SetDbValue(rsnew, Tujuan.CurrentValue);

                // SFAD_KLObs
                SFAD_KLObs.SetDbValue(rsnew, SFAD_KLObs.CurrentValue);

                // SFAD_KL15
                SFAD_KL15.SetDbValue(rsnew, SFAD_KL15.CurrentValue);

                // SFAD_Barrels
                SFAD_Barrels.SetDbValue(rsnew, SFAD_Barrels.CurrentValue);

                // SFAD_LT
                SFAD_LT.SetDbValue(rsnew, SFAD_LT.CurrentValue);

                // SFAD_MT
                SFAD_MT.SetDbValue(rsnew, SFAD_MT.CurrentValue);

                // NewBL_KLObs
                NewBL_KLObs.SetDbValue(rsnew, NewBL_KLObs.CurrentValue);

                // NewBL_KL15
                NewBL_KL15.SetDbValue(rsnew, NewBL_KL15.CurrentValue);

                // NewBL_Barrels
                NewBL_Barrels.SetDbValue(rsnew, NewBL_Barrels.CurrentValue);

                // NewBL_LT
                NewBL_LT.SetDbValue(rsnew, NewBL_LT.CurrentValue);

                // NewBL_MT
                NewBL_MT.SetDbValue(rsnew, NewBL_MT.CurrentValue);

                // userInput
                userInput.SetDbValue(rsnew, userInput.CurrentValue);

                // etlDate
                etlDate.SetDbValue(rsnew, ConvertToDateTime(etlDate.CurrentValue, etlDate.FormatPattern), Empty(etlDate.CurrentValue));

                // AR45B_klobs
                AR45B_klobs.SetDbValue(rsnew, AR45B_klobs.CurrentValue);

                // AR45B_kl15
                AR45B_kl15.SetDbValue(rsnew, AR45B_kl15.CurrentValue);

                // AR45B_Barrel
                AR45B_Barrel.SetDbValue(rsnew, AR45B_Barrel.CurrentValue);

                // AR45B_lt
                AR45B_lt.SetDbValue(rsnew, AR45B_lt.CurrentValue);

                // AR45B_mt
                AR45B_mt.SetDbValue(rsnew, AR45B_mt.CurrentValue);
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
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("idProses", out value)) // idProses
                idProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("idAktifitas", out value)) // idAktifitas
                idAktifitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusAktivitas", out value)) // StatusAktivitas
                StatusAktivitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LastUpdatedBy", out value)) // LastUpdatedBy
                LastUpdatedBy.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("lastUpdatedDate", out value)) // lastUpdatedDate
                lastUpdatedDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Import", out value)) // Import
                Import.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("ApakahAdaROB", out value)) // ApakahAdaROB
                ApakahAdaROB.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Tujuan", out value)) // Tujuan
                Tujuan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_KLObs", out value)) // SFAD_KLObs
                SFAD_KLObs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_KL15", out value)) // SFAD_KL15
                SFAD_KL15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_Barrels", out value)) // SFAD_Barrels
                SFAD_Barrels.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_LT", out value)) // SFAD_LT
                SFAD_LT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("SFAD_MT", out value)) // SFAD_MT
                SFAD_MT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_KLObs", out value)) // NewBL_KLObs
                NewBL_KLObs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_KL15", out value)) // NewBL_KL15
                NewBL_KL15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_Barrels", out value)) // NewBL_Barrels
                NewBL_Barrels.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_LT", out value)) // NewBL_LT
                NewBL_LT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NewBL_MT", out value)) // NewBL_MT
                NewBL_MT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("userInput", out value)) // userInput
                userInput.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("etlDate", out value)) // etlDate
                etlDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_klobs", out value)) // AR45B_klobs
                AR45B_klobs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_kl15", out value)) // AR45B_kl15
                AR45B_kl15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_Barrel", out value)) // AR45B_Barrel
                AR45B_Barrel.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_lt", out value)) // AR45B_lt
                AR45B_lt.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AR45B_mt", out value)) // AR45B_mt
                AR45B_mt.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasFormInputNilaiAktDischargeRtwList")), "", TableVar, true);
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
