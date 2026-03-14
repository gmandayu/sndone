namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasFormInputNilaiBLnAlAdd
    /// </summary>
    public static SubAktivitasFormInputNilaiBLnAlAdd subAktivitasFormInputNilaiBLnAlAdd
    {
        get => HttpData.Get<SubAktivitasFormInputNilaiBLnAlAdd>("subAktivitasFormInputNilaiBLnAlAdd")!;
        set => HttpData["subAktivitasFormInputNilaiBLnAlAdd"] = value;
    }

    /// <summary>
    /// Page class for SubAktivitasFormInputNilaiBLnAL
    /// </summary>
    public class SubAktivitasFormInputNilaiBLnAlAdd : SubAktivitasFormInputNilaiBLnAlAddBase
    {
        // Constructor
        public SubAktivitasFormInputNilaiBLnAlAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public SubAktivitasFormInputNilaiBLnAlAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class SubAktivitasFormInputNilaiBLnAlAddBase : SubAktivitasFormInputNilaiBLnAl
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "subAktivitasFormInputNilaiBLnAlAdd";

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
        public SubAktivitasFormInputNilaiBLnAlAddBase()
        {
            TableName = "SubAktivitasFormInputNilaiBLnAL";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (subAktivitasFormInputNilaiBLnAl)
            if (subAktivitasFormInputNilaiBLnAl == null || subAktivitasFormInputNilaiBLnAl is SubAktivitasFormInputNilaiBLnAl)
                subAktivitasFormInputNilaiBLnAl = this;

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
        public string PageName => "SubAktivitasFormInputNilaiBLnAlAdd";

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
            BL_KLObs.SetVisibility();
            BL_KL15.SetVisibility();
            BL_Barrels.SetVisibility();
            BL_LT.SetVisibility();
            BL_MT.SetVisibility();
            AL_KLObs.SetVisibility();
            AL_KL15.SetVisibility();
            AL_Barrels.SetVisibility();
            AL_LT.SetVisibility();
            AL_MT.SetVisibility();
            userInput.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            StatusAktivitas.SetVisibility();
        }

        // Constructor
        public SubAktivitasFormInputNilaiBLnAlAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "SubAktivitasFormInputNilaiBLnAlView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(idAktifitas);
            await SetupLookupOptions(idProses);
            await SetupLookupOptions(StatusAktivitas);

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
                        return Terminate("SubAktivitasFormInputNilaiBLnAlList"); // No matching record, return to List page // DN
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
                        if (GetPageName(returnUrl) == "SubAktivitasFormInputNilaiBLnAlList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "SubAktivitasFormInputNilaiBLnAlView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "SubAktivitasFormInputNilaiBLnAlList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "SubAktivitasFormInputNilaiBLnAlList"; // Return list page content
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
                subAktivitasFormInputNilaiBLnAlAdd?.PageRender();
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

            // Check field name 'idAktifitas' before field var 'x_idAktifitas'
            val = CurrentForm.HasValue("idAktifitas") ? CurrentForm.GetValue("idAktifitas") : CurrentForm.GetValue("x_idAktifitas");
            if (!idAktifitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idAktifitas") && !CurrentForm.HasValue("x_idAktifitas")) // DN
                    idAktifitas.Visible = false; // Disable update for API request
                else
                    idAktifitas.SetFormValue(val, true, validate);
            }

            // Check field name 'idProses' before field var 'x_idProses'
            val = CurrentForm.HasValue("idProses") ? CurrentForm.GetValue("idProses") : CurrentForm.GetValue("x_idProses");
            if (!idProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idProses") && !CurrentForm.HasValue("x_idProses")) // DN
                    idProses.Visible = false; // Disable update for API request
                else
                    idProses.SetFormValue(val, true, validate);
            }

            // Check field name 'NoReferensi' before field var 'x_NoReferensi'
            val = CurrentForm.HasValue("NoReferensi") ? CurrentForm.GetValue("NoReferensi") : CurrentForm.GetValue("x_NoReferensi");
            if (!NoReferensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoReferensi") && !CurrentForm.HasValue("x_NoReferensi")) // DN
                    NoReferensi.Visible = false; // Disable update for API request
                else
                    NoReferensi.SetFormValue(val);
            }

            // Check field name 'BL_KLObs' before field var 'x_BL_KLObs'
            val = CurrentForm.HasValue("BL_KLObs") ? CurrentForm.GetValue("BL_KLObs") : CurrentForm.GetValue("x_BL_KLObs");
            if (!BL_KLObs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_KLObs") && !CurrentForm.HasValue("x_BL_KLObs")) // DN
                    BL_KLObs.Visible = false; // Disable update for API request
                else
                    BL_KLObs.SetFormValue(val);
            }

            // Check field name 'BL_KL15' before field var 'x_BL_KL15'
            val = CurrentForm.HasValue("BL_KL15") ? CurrentForm.GetValue("BL_KL15") : CurrentForm.GetValue("x_BL_KL15");
            if (!BL_KL15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_KL15") && !CurrentForm.HasValue("x_BL_KL15")) // DN
                    BL_KL15.Visible = false; // Disable update for API request
                else
                    BL_KL15.SetFormValue(val);
            }

            // Check field name 'BL_Barrels' before field var 'x_BL_Barrels'
            val = CurrentForm.HasValue("BL_Barrels") ? CurrentForm.GetValue("BL_Barrels") : CurrentForm.GetValue("x_BL_Barrels");
            if (!BL_Barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_Barrels") && !CurrentForm.HasValue("x_BL_Barrels")) // DN
                    BL_Barrels.Visible = false; // Disable update for API request
                else
                    BL_Barrels.SetFormValue(val);
            }

            // Check field name 'BL_LT' before field var 'x_BL_LT'
            val = CurrentForm.HasValue("BL_LT") ? CurrentForm.GetValue("BL_LT") : CurrentForm.GetValue("x_BL_LT");
            if (!BL_LT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_LT") && !CurrentForm.HasValue("x_BL_LT")) // DN
                    BL_LT.Visible = false; // Disable update for API request
                else
                    BL_LT.SetFormValue(val);
            }

            // Check field name 'BL_MT' before field var 'x_BL_MT'
            val = CurrentForm.HasValue("BL_MT") ? CurrentForm.GetValue("BL_MT") : CurrentForm.GetValue("x_BL_MT");
            if (!BL_MT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BL_MT") && !CurrentForm.HasValue("x_BL_MT")) // DN
                    BL_MT.Visible = false; // Disable update for API request
                else
                    BL_MT.SetFormValue(val);
            }

            // Check field name 'AL_KLObs' before field var 'x_AL_KLObs'
            val = CurrentForm.HasValue("AL_KLObs") ? CurrentForm.GetValue("AL_KLObs") : CurrentForm.GetValue("x_AL_KLObs");
            if (!AL_KLObs.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_KLObs") && !CurrentForm.HasValue("x_AL_KLObs")) // DN
                    AL_KLObs.Visible = false; // Disable update for API request
                else
                    AL_KLObs.SetFormValue(val);
            }

            // Check field name 'AL_KL15' before field var 'x_AL_KL15'
            val = CurrentForm.HasValue("AL_KL15") ? CurrentForm.GetValue("AL_KL15") : CurrentForm.GetValue("x_AL_KL15");
            if (!AL_KL15.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_KL15") && !CurrentForm.HasValue("x_AL_KL15")) // DN
                    AL_KL15.Visible = false; // Disable update for API request
                else
                    AL_KL15.SetFormValue(val);
            }

            // Check field name 'AL_Barrels' before field var 'x_AL_Barrels'
            val = CurrentForm.HasValue("AL_Barrels") ? CurrentForm.GetValue("AL_Barrels") : CurrentForm.GetValue("x_AL_Barrels");
            if (!AL_Barrels.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_Barrels") && !CurrentForm.HasValue("x_AL_Barrels")) // DN
                    AL_Barrels.Visible = false; // Disable update for API request
                else
                    AL_Barrels.SetFormValue(val);
            }

            // Check field name 'AL_LT' before field var 'x_AL_LT'
            val = CurrentForm.HasValue("AL_LT") ? CurrentForm.GetValue("AL_LT") : CurrentForm.GetValue("x_AL_LT");
            if (!AL_LT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_LT") && !CurrentForm.HasValue("x_AL_LT")) // DN
                    AL_LT.Visible = false; // Disable update for API request
                else
                    AL_LT.SetFormValue(val);
            }

            // Check field name 'AL_MT' before field var 'x_AL_MT'
            val = CurrentForm.HasValue("AL_MT") ? CurrentForm.GetValue("AL_MT") : CurrentForm.GetValue("x_AL_MT");
            if (!AL_MT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AL_MT") && !CurrentForm.HasValue("x_AL_MT")) // DN
                    AL_MT.Visible = false; // Disable update for API request
                else
                    AL_MT.SetFormValue(val);
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

            // Check field name 'StatusAktivitas' before field var 'x_StatusAktivitas'
            val = CurrentForm.HasValue("StatusAktivitas") ? CurrentForm.GetValue("StatusAktivitas") : CurrentForm.GetValue("x_StatusAktivitas");
            if (!StatusAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusAktivitas") && !CurrentForm.HasValue("x_StatusAktivitas")) // DN
                    StatusAktivitas.Visible = false; // Disable update for API request
                else
                    StatusAktivitas.SetFormValue(val, true, validate);
            }

            // Check field name 'id' before field var 'x_id'
            val = CurrentForm.HasValue("id") ? CurrentForm.GetValue("id") : CurrentForm.GetValue("x_id");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            idAktifitas.CurrentValue = idAktifitas.FormValue;
            idProses.CurrentValue = idProses.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            BL_KLObs.CurrentValue = BL_KLObs.FormValue;
            BL_KL15.CurrentValue = BL_KL15.FormValue;
            BL_Barrels.CurrentValue = BL_Barrels.FormValue;
            BL_LT.CurrentValue = BL_LT.FormValue;
            BL_MT.CurrentValue = BL_MT.FormValue;
            AL_KLObs.CurrentValue = AL_KLObs.FormValue;
            AL_KL15.CurrentValue = AL_KL15.FormValue;
            AL_Barrels.CurrentValue = AL_Barrels.FormValue;
            AL_LT.CurrentValue = AL_LT.FormValue;
            AL_MT.CurrentValue = AL_MT.FormValue;
            userInput.CurrentValue = userInput.FormValue;
            etlDate.CurrentValue = etlDate.FormValue;
            etlDate.CurrentValue = UnformatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            LastUpdatedBy.CurrentValue = LastUpdatedBy.FormValue;
            lastUpdatedDate.CurrentValue = lastUpdatedDate.FormValue;
            lastUpdatedDate.CurrentValue = UnformatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
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
            BL_KLObs.SetDbValue(row["BL_KLObs"]);
            BL_KL15.SetDbValue(row["BL_KL15"]);
            BL_Barrels.SetDbValue(row["BL_Barrels"]);
            BL_LT.SetDbValue(row["BL_LT"]);
            BL_MT.SetDbValue(row["BL_MT"]);
            AL_KLObs.SetDbValue(row["AL_KLObs"]);
            AL_KL15.SetDbValue(row["AL_KL15"]);
            AL_Barrels.SetDbValue(row["AL_Barrels"]);
            AL_LT.SetDbValue(row["AL_LT"]);
            AL_MT.SetDbValue(row["AL_MT"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("idAktifitas", idAktifitas.DefaultValue ?? DbNullValue); // DN
            row.Add("idProses", idProses.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_KLObs", BL_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_KL15", BL_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_Barrels", BL_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_LT", BL_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("BL_MT", BL_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_KLObs", AL_KLObs.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_KL15", AL_KL15.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_Barrels", AL_Barrels.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_LT", AL_LT.DefaultValue ?? DbNullValue); // DN
            row.Add("AL_MT", AL_MT.DefaultValue ?? DbNullValue); // DN
            row.Add("userInput", userInput.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
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

            // BL_KLObs
            BL_KLObs.RowCssClass = "row";

            // BL_KL15
            BL_KL15.RowCssClass = "row";

            // BL_Barrels
            BL_Barrels.RowCssClass = "row";

            // BL_LT
            BL_LT.RowCssClass = "row";

            // BL_MT
            BL_MT.RowCssClass = "row";

            // AL_KLObs
            AL_KLObs.RowCssClass = "row";

            // AL_KL15
            AL_KL15.RowCssClass = "row";

            // AL_Barrels
            AL_Barrels.RowCssClass = "row";

            // AL_LT
            AL_LT.RowCssClass = "row";

            // AL_MT
            AL_MT.RowCssClass = "row";

            // userInput
            userInput.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

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

                // BL_KLObs
                BL_KLObs.ViewValue = ConvertToString(BL_KLObs.CurrentValue); // DN
                BL_KLObs.ViewCustomAttributes = "";

                // BL_KL15
                BL_KL15.ViewValue = ConvertToString(BL_KL15.CurrentValue); // DN
                BL_KL15.ViewCustomAttributes = "";

                // BL_Barrels
                BL_Barrels.ViewValue = ConvertToString(BL_Barrels.CurrentValue); // DN
                BL_Barrels.ViewCustomAttributes = "";

                // BL_LT
                BL_LT.ViewValue = ConvertToString(BL_LT.CurrentValue); // DN
                BL_LT.ViewCustomAttributes = "";

                // BL_MT
                BL_MT.ViewValue = ConvertToString(BL_MT.CurrentValue); // DN
                BL_MT.ViewCustomAttributes = "";

                // AL_KLObs
                AL_KLObs.ViewValue = ConvertToString(AL_KLObs.CurrentValue); // DN
                AL_KLObs.ViewCustomAttributes = "";

                // AL_KL15
                AL_KL15.ViewValue = ConvertToString(AL_KL15.CurrentValue); // DN
                AL_KL15.ViewCustomAttributes = "";

                // AL_Barrels
                AL_Barrels.ViewValue = ConvertToString(AL_Barrels.CurrentValue); // DN
                AL_Barrels.ViewCustomAttributes = "";

                // AL_LT
                AL_LT.ViewValue = ConvertToString(AL_LT.CurrentValue); // DN
                AL_LT.ViewCustomAttributes = "";

                // AL_MT
                AL_MT.ViewValue = ConvertToString(AL_MT.CurrentValue); // DN
                AL_MT.ViewCustomAttributes = "";

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

                // idAktifitas
                idAktifitas.HrefValue = "";
                idAktifitas.TooltipValue = "";

                // idProses
                idProses.HrefValue = "";
                idProses.TooltipValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // BL_KLObs
                BL_KLObs.HrefValue = "";

                // BL_KL15
                BL_KL15.HrefValue = "";

                // BL_Barrels
                BL_Barrels.HrefValue = "";

                // BL_LT
                BL_LT.HrefValue = "";

                // BL_MT
                BL_MT.HrefValue = "";

                // AL_KLObs
                AL_KLObs.HrefValue = "";

                // AL_KL15
                AL_KL15.HrefValue = "";

                // AL_Barrels
                AL_Barrels.HrefValue = "";

                // AL_LT
                AL_LT.HrefValue = "";

                // AL_MT
                AL_MT.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
                StatusAktivitas.TooltipValue = "";
            } else if (RowType == RowType.Add) {
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
                            idAktifitas.EditValue = HtmlEncode(FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern));
                        }
                    }
                } else {
                    idAktifitas.EditValue = DbNullValue;
                }
                idAktifitas.PlaceHolder = RemoveHtml(idAktifitas.Caption);
                if (!Empty(idAktifitas.EditValue) && IsNumeric(idAktifitas.EditValue))
                    idAktifitas.EditValue = FormatNumber(idAktifitas.EditValue, null);

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
                            idProses.EditValue = HtmlEncode(FormatNumber(idProses.CurrentValue, idProses.FormatPattern));
                        }
                    }
                } else {
                    idProses.EditValue = DbNullValue;
                }
                idProses.PlaceHolder = RemoveHtml(idProses.Caption);
                if (!Empty(idProses.EditValue) && IsNumeric(idProses.EditValue))
                    idProses.EditValue = FormatNumber(idProses.EditValue, null);

                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // BL_KLObs
                BL_KLObs.SetupEditAttributes();
                if (!BL_KLObs.Raw)
                    BL_KLObs.CurrentValue = HtmlDecode(BL_KLObs.CurrentValue);
                BL_KLObs.EditValue = HtmlEncode(BL_KLObs.CurrentValue);
                BL_KLObs.PlaceHolder = RemoveHtml(BL_KLObs.Caption);

                // BL_KL15
                BL_KL15.SetupEditAttributes();
                if (!BL_KL15.Raw)
                    BL_KL15.CurrentValue = HtmlDecode(BL_KL15.CurrentValue);
                BL_KL15.EditValue = HtmlEncode(BL_KL15.CurrentValue);
                BL_KL15.PlaceHolder = RemoveHtml(BL_KL15.Caption);

                // BL_Barrels
                BL_Barrels.SetupEditAttributes();
                if (!BL_Barrels.Raw)
                    BL_Barrels.CurrentValue = HtmlDecode(BL_Barrels.CurrentValue);
                BL_Barrels.EditValue = HtmlEncode(BL_Barrels.CurrentValue);
                BL_Barrels.PlaceHolder = RemoveHtml(BL_Barrels.Caption);

                // BL_LT
                BL_LT.SetupEditAttributes();
                if (!BL_LT.Raw)
                    BL_LT.CurrentValue = HtmlDecode(BL_LT.CurrentValue);
                BL_LT.EditValue = HtmlEncode(BL_LT.CurrentValue);
                BL_LT.PlaceHolder = RemoveHtml(BL_LT.Caption);

                // BL_MT
                BL_MT.SetupEditAttributes();
                if (!BL_MT.Raw)
                    BL_MT.CurrentValue = HtmlDecode(BL_MT.CurrentValue);
                BL_MT.EditValue = HtmlEncode(BL_MT.CurrentValue);
                BL_MT.PlaceHolder = RemoveHtml(BL_MT.Caption);

                // AL_KLObs
                AL_KLObs.SetupEditAttributes();
                if (!AL_KLObs.Raw)
                    AL_KLObs.CurrentValue = HtmlDecode(AL_KLObs.CurrentValue);
                AL_KLObs.EditValue = HtmlEncode(AL_KLObs.CurrentValue);
                AL_KLObs.PlaceHolder = RemoveHtml(AL_KLObs.Caption);

                // AL_KL15
                AL_KL15.SetupEditAttributes();
                if (!AL_KL15.Raw)
                    AL_KL15.CurrentValue = HtmlDecode(AL_KL15.CurrentValue);
                AL_KL15.EditValue = HtmlEncode(AL_KL15.CurrentValue);
                AL_KL15.PlaceHolder = RemoveHtml(AL_KL15.Caption);

                // AL_Barrels
                AL_Barrels.SetupEditAttributes();
                if (!AL_Barrels.Raw)
                    AL_Barrels.CurrentValue = HtmlDecode(AL_Barrels.CurrentValue);
                AL_Barrels.EditValue = HtmlEncode(AL_Barrels.CurrentValue);
                AL_Barrels.PlaceHolder = RemoveHtml(AL_Barrels.Caption);

                // AL_LT
                AL_LT.SetupEditAttributes();
                if (!AL_LT.Raw)
                    AL_LT.CurrentValue = HtmlDecode(AL_LT.CurrentValue);
                AL_LT.EditValue = HtmlEncode(AL_LT.CurrentValue);
                AL_LT.PlaceHolder = RemoveHtml(AL_LT.Caption);

                // AL_MT
                AL_MT.SetupEditAttributes();
                if (!AL_MT.Raw)
                    AL_MT.CurrentValue = HtmlDecode(AL_MT.CurrentValue);
                AL_MT.EditValue = HtmlEncode(AL_MT.CurrentValue);
                AL_MT.PlaceHolder = RemoveHtml(AL_MT.Caption);

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

                // Add refer script

                // idAktifitas
                idAktifitas.HrefValue = "";

                // idProses
                idProses.HrefValue = "";

                // NoReferensi
                NoReferensi.HrefValue = "";

                // BL_KLObs
                BL_KLObs.HrefValue = "";

                // BL_KL15
                BL_KL15.HrefValue = "";

                // BL_Barrels
                BL_Barrels.HrefValue = "";

                // BL_LT
                BL_LT.HrefValue = "";

                // BL_MT
                BL_MT.HrefValue = "";

                // AL_KLObs
                AL_KLObs.HrefValue = "";

                // AL_KL15
                AL_KL15.HrefValue = "";

                // AL_Barrels
                AL_Barrels.HrefValue = "";

                // AL_LT
                AL_LT.HrefValue = "";

                // AL_MT
                AL_MT.HrefValue = "";

                // userInput
                userInput.HrefValue = "";

                // etlDate
                etlDate.HrefValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";
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
                if (!CheckInteger(idAktifitas.FormValue)) {
                    idAktifitas.AddErrorMessage(idAktifitas.GetErrorMessage(false));
                }
                if (idProses.Visible && idProses.Required) {
                    if (!idProses.IsDetailKey && Empty(idProses.FormValue)) {
                        idProses.AddErrorMessage(ConvertToString(idProses.RequiredErrorMessage).Replace("%s", idProses.Caption));
                    }
                }
                if (!CheckInteger(idProses.FormValue)) {
                    idProses.AddErrorMessage(idProses.GetErrorMessage(false));
                }
                if (NoReferensi.Visible && NoReferensi.Required) {
                    if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                        NoReferensi.AddErrorMessage(ConvertToString(NoReferensi.RequiredErrorMessage).Replace("%s", NoReferensi.Caption));
                    }
                }
                if (BL_KLObs.Visible && BL_KLObs.Required) {
                    if (!BL_KLObs.IsDetailKey && Empty(BL_KLObs.FormValue)) {
                        BL_KLObs.AddErrorMessage(ConvertToString(BL_KLObs.RequiredErrorMessage).Replace("%s", BL_KLObs.Caption));
                    }
                }
                if (BL_KL15.Visible && BL_KL15.Required) {
                    if (!BL_KL15.IsDetailKey && Empty(BL_KL15.FormValue)) {
                        BL_KL15.AddErrorMessage(ConvertToString(BL_KL15.RequiredErrorMessage).Replace("%s", BL_KL15.Caption));
                    }
                }
                if (BL_Barrels.Visible && BL_Barrels.Required) {
                    if (!BL_Barrels.IsDetailKey && Empty(BL_Barrels.FormValue)) {
                        BL_Barrels.AddErrorMessage(ConvertToString(BL_Barrels.RequiredErrorMessage).Replace("%s", BL_Barrels.Caption));
                    }
                }
                if (BL_LT.Visible && BL_LT.Required) {
                    if (!BL_LT.IsDetailKey && Empty(BL_LT.FormValue)) {
                        BL_LT.AddErrorMessage(ConvertToString(BL_LT.RequiredErrorMessage).Replace("%s", BL_LT.Caption));
                    }
                }
                if (BL_MT.Visible && BL_MT.Required) {
                    if (!BL_MT.IsDetailKey && Empty(BL_MT.FormValue)) {
                        BL_MT.AddErrorMessage(ConvertToString(BL_MT.RequiredErrorMessage).Replace("%s", BL_MT.Caption));
                    }
                }
                if (AL_KLObs.Visible && AL_KLObs.Required) {
                    if (!AL_KLObs.IsDetailKey && Empty(AL_KLObs.FormValue)) {
                        AL_KLObs.AddErrorMessage(ConvertToString(AL_KLObs.RequiredErrorMessage).Replace("%s", AL_KLObs.Caption));
                    }
                }
                if (AL_KL15.Visible && AL_KL15.Required) {
                    if (!AL_KL15.IsDetailKey && Empty(AL_KL15.FormValue)) {
                        AL_KL15.AddErrorMessage(ConvertToString(AL_KL15.RequiredErrorMessage).Replace("%s", AL_KL15.Caption));
                    }
                }
                if (AL_Barrels.Visible && AL_Barrels.Required) {
                    if (!AL_Barrels.IsDetailKey && Empty(AL_Barrels.FormValue)) {
                        AL_Barrels.AddErrorMessage(ConvertToString(AL_Barrels.RequiredErrorMessage).Replace("%s", AL_Barrels.Caption));
                    }
                }
                if (AL_LT.Visible && AL_LT.Required) {
                    if (!AL_LT.IsDetailKey && Empty(AL_LT.FormValue)) {
                        AL_LT.AddErrorMessage(ConvertToString(AL_LT.RequiredErrorMessage).Replace("%s", AL_LT.Caption));
                    }
                }
                if (AL_MT.Visible && AL_MT.Required) {
                    if (!AL_MT.IsDetailKey && Empty(AL_MT.FormValue)) {
                        AL_MT.AddErrorMessage(ConvertToString(AL_MT.RequiredErrorMessage).Replace("%s", AL_MT.Caption));
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
                if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                    if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                        StatusAktivitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                    }
                }
                if (!CheckInteger(StatusAktivitas.FormValue)) {
                    StatusAktivitas.AddErrorMessage(StatusAktivitas.GetErrorMessage(false));
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

                // idAktifitas
                idAktifitas.SetDbValue(rsnew, idAktifitas.CurrentValue);

                // idProses
                idProses.SetDbValue(rsnew, idProses.CurrentValue);

                // NoReferensi
                NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue);

                // BL_KLObs
                BL_KLObs.SetDbValue(rsnew, BL_KLObs.CurrentValue);

                // BL_KL15
                BL_KL15.SetDbValue(rsnew, BL_KL15.CurrentValue);

                // BL_Barrels
                BL_Barrels.SetDbValue(rsnew, BL_Barrels.CurrentValue);

                // BL_LT
                BL_LT.SetDbValue(rsnew, BL_LT.CurrentValue);

                // BL_MT
                BL_MT.SetDbValue(rsnew, BL_MT.CurrentValue);

                // AL_KLObs
                AL_KLObs.SetDbValue(rsnew, AL_KLObs.CurrentValue);

                // AL_KL15
                AL_KL15.SetDbValue(rsnew, AL_KL15.CurrentValue);

                // AL_Barrels
                AL_Barrels.SetDbValue(rsnew, AL_Barrels.CurrentValue);

                // AL_LT
                AL_LT.SetDbValue(rsnew, AL_LT.CurrentValue);

                // AL_MT
                AL_MT.SetDbValue(rsnew, AL_MT.CurrentValue);

                // userInput
                userInput.SetDbValue(rsnew, userInput.CurrentValue);

                // etlDate
                etlDate.SetDbValue(rsnew, ConvertToDateTime(etlDate.CurrentValue, etlDate.FormatPattern), Empty(etlDate.CurrentValue));

                // LastUpdatedBy
                LastUpdatedBy.SetDbValue(rsnew, LastUpdatedBy.CurrentValue);

                // lastUpdatedDate
                lastUpdatedDate.SetDbValue(rsnew, ConvertToDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern));

                // StatusAktivitas
                StatusAktivitas.SetDbValue(rsnew, StatusAktivitas.CurrentValue);
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
            if (row.TryGetValue("idAktifitas", out value)) // idAktifitas
                idAktifitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("idProses", out value)) // idProses
                idProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_KLObs", out value)) // BL_KLObs
                BL_KLObs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_KL15", out value)) // BL_KL15
                BL_KL15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_Barrels", out value)) // BL_Barrels
                BL_Barrels.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_LT", out value)) // BL_LT
                BL_LT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("BL_MT", out value)) // BL_MT
                BL_MT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AL_KLObs", out value)) // AL_KLObs
                AL_KLObs.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AL_KL15", out value)) // AL_KL15
                AL_KL15.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AL_Barrels", out value)) // AL_Barrels
                AL_Barrels.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AL_LT", out value)) // AL_LT
                AL_LT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AL_MT", out value)) // AL_MT
                AL_MT.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("userInput", out value)) // userInput
                userInput.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("etlDate", out value)) // etlDate
                etlDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LastUpdatedBy", out value)) // LastUpdatedBy
                LastUpdatedBy.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("lastUpdatedDate", out value)) // lastUpdatedDate
                lastUpdatedDate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusAktivitas", out value)) // StatusAktivitas
                StatusAktivitas.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("SubAktivitasFormInputNilaiBLnAlList")), "", TableVar, true);
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
