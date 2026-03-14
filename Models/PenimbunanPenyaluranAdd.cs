namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penimbunanPenyaluranAdd
    /// </summary>
    public static PenimbunanPenyaluranAdd penimbunanPenyaluranAdd
    {
        get => HttpData.Get<PenimbunanPenyaluranAdd>("penimbunanPenyaluranAdd")!;
        set => HttpData["penimbunanPenyaluranAdd"] = value;
    }

    /// <summary>
    /// Page class for PenimbunanPenyaluran
    /// </summary>
    public class PenimbunanPenyaluranAdd : PenimbunanPenyaluranAddBase
    {
        // Constructor
        public PenimbunanPenyaluranAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenimbunanPenyaluranAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
            IdTangki.DisplayValueSeparator = " - ";
            JenisProduk.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenimbunanPenyaluranAddBase : PenimbunanPenyaluran
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penimbunanPenyaluranAdd";

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
        public PenimbunanPenyaluranAddBase()
        {
            TableName = "PenimbunanPenyaluran";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (penimbunanPenyaluran)
            if (penimbunanPenyaluran == null || penimbunanPenyaluran is PenimbunanPenyaluran)
                penimbunanPenyaluran = this;

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
        public string PageName => "PenimbunanPenyaluranAdd";

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
            IdPenimbunanPenyaluran.Visible = false;
            NomorPenimbunanPenyaluran.SetVisibility();
            Proses2.Visible = false;
            IdTemplate.SetVisibility();
            LookupPlant.SetVisibility();
            Plant.SetVisibility();
            TipeProdukSTS.SetVisibility();
            TipePenyaluran.SetVisibility();
            JenisProduk.SetVisibility();
            IdModa.SetVisibility();
            IdTangki.SetVisibility();
            StatusProses.SetVisibility();
            LookupNoPenyaluran.SetVisibility();
            NoPenyaluran.SetVisibility();
            PersentaseProgress.SetVisibility();
            Catatan.SetVisibility();
            DibuatOleh.SetVisibility();
            TanggalDibuat.SetVisibility();
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            PlantForLookup.SetVisibility();
            LookupTipeProduk.SetVisibility();
            LookupJenisPlant.SetVisibility();
        }

        // Constructor
        public PenimbunanPenyaluranAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "PenimbunanPenyaluranView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdPenimbunanPenyaluran") ? dict["IdPenimbunanPenyaluran"] : IdPenimbunanPenyaluran.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdPenimbunanPenyaluran.Visible = false;
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
            await SetupLookupOptions(LookupPlant);
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(TipeProdukSTS);
            await SetupLookupOptions(TipePenyaluran);
            await SetupLookupOptions(JenisProduk);
            await SetupLookupOptions(IdModa);
            await SetupLookupOptions(IdTangki);
            await SetupLookupOptions(LookupNoPenyaluran);

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
                if (RouteValues.TryGetValue("IdPenimbunanPenyaluran", out rv)) { // DN
                    IdPenimbunanPenyaluran.QueryValue = UrlDecode(rv); // DN
                } else if (Get("IdPenimbunanPenyaluran", out sv)) {
                    IdPenimbunanPenyaluran.QueryValue = sv.ToString();
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
                        return Terminate("PenimbunanPenyaluranList"); // No matching record, return to List page // DN
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
                        if (GetPageName(returnUrl) == "PenimbunanPenyaluranList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "PenimbunanPenyaluranView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "PenimbunanPenyaluranList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "PenimbunanPenyaluranList"; // Return list page content
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
                penimbunanPenyaluranAdd?.PageRender();
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
            IdTemplate.DefaultValue = IdTemplate.GetDefault(); // DN
            IdTemplate.OldValue = IdTemplate.DefaultValue;
            StatusProses.DefaultValue = StatusProses.GetDefault(); // DN
            StatusProses.OldValue = StatusProses.DefaultValue;
            PersentaseProgress.DefaultValue = PersentaseProgress.GetDefault(); // DN
            PersentaseProgress.OldValue = PersentaseProgress.DefaultValue;
        }

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'NomorPenimbunanPenyaluran' before field var 'x_NomorPenimbunanPenyaluran'
            val = CurrentForm.HasValue("NomorPenimbunanPenyaluran") ? CurrentForm.GetValue("NomorPenimbunanPenyaluran") : CurrentForm.GetValue("x_NomorPenimbunanPenyaluran");
            if (!NomorPenimbunanPenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorPenimbunanPenyaluran") && !CurrentForm.HasValue("x_NomorPenimbunanPenyaluran")) // DN
                    NomorPenimbunanPenyaluran.Visible = false; // Disable update for API request
                else
                    NomorPenimbunanPenyaluran.SetFormValue(val);
            }

            // Check field name 'IdTemplate' before field var 'x_IdTemplate'
            val = CurrentForm.HasValue("IdTemplate") ? CurrentForm.GetValue("IdTemplate") : CurrentForm.GetValue("x_IdTemplate");
            if (!IdTemplate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTemplate") && !CurrentForm.HasValue("x_IdTemplate")) // DN
                    IdTemplate.Visible = false; // Disable update for API request
                else
                    IdTemplate.SetFormValue(val);
            }

            // Check field name 'LookupPlant' before field var 'x_LookupPlant'
            val = CurrentForm.HasValue("LookupPlant") ? CurrentForm.GetValue("LookupPlant") : CurrentForm.GetValue("x_LookupPlant");
            if (!LookupPlant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LookupPlant") && !CurrentForm.HasValue("x_LookupPlant")) // DN
                    LookupPlant.Visible = false; // Disable update for API request
                else
                    LookupPlant.SetFormValue(val);
            }

            // Check field name 'Plant' before field var 'x_Plant'
            val = CurrentForm.HasValue("Plant") ? CurrentForm.GetValue("Plant") : CurrentForm.GetValue("x_Plant");
            if (!Plant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Plant") && !CurrentForm.HasValue("x_Plant")) // DN
                    Plant.Visible = false; // Disable update for API request
                else
                    Plant.SetFormValue(val);
            }

            // Check field name 'TipeProdukSTS' before field var 'x_TipeProdukSTS'
            val = CurrentForm.HasValue("TipeProdukSTS") ? CurrentForm.GetValue("TipeProdukSTS") : CurrentForm.GetValue("x_TipeProdukSTS");
            if (!TipeProdukSTS.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipeProdukSTS") && !CurrentForm.HasValue("x_TipeProdukSTS")) // DN
                    TipeProdukSTS.Visible = false; // Disable update for API request
                else
                    TipeProdukSTS.SetFormValue(val);
            }

            // Check field name 'TipePenyaluran' before field var 'x_TipePenyaluran'
            val = CurrentForm.HasValue("TipePenyaluran") ? CurrentForm.GetValue("TipePenyaluran") : CurrentForm.GetValue("x_TipePenyaluran");
            if (!TipePenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipePenyaluran") && !CurrentForm.HasValue("x_TipePenyaluran")) // DN
                    TipePenyaluran.Visible = false; // Disable update for API request
                else
                    TipePenyaluran.SetFormValue(val);
            }

            // Check field name 'JenisProduk' before field var 'x_JenisProduk'
            val = CurrentForm.HasValue("JenisProduk") ? CurrentForm.GetValue("JenisProduk") : CurrentForm.GetValue("x_JenisProduk");
            if (!JenisProduk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("JenisProduk") && !CurrentForm.HasValue("x_JenisProduk")) // DN
                    JenisProduk.Visible = false; // Disable update for API request
                else
                    JenisProduk.SetFormValue(val);
            }

            // Check field name 'IdModa' before field var 'x_IdModa'
            val = CurrentForm.HasValue("IdModa") ? CurrentForm.GetValue("IdModa") : CurrentForm.GetValue("x_IdModa");
            if (!IdModa.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdModa") && !CurrentForm.HasValue("x_IdModa")) // DN
                    IdModa.Visible = false; // Disable update for API request
                else
                    IdModa.SetFormValue(val);
            }

            // Check field name 'IdTangki' before field var 'x_IdTangki'
            val = CurrentForm.HasValue("IdTangki") ? CurrentForm.GetValue("IdTangki") : CurrentForm.GetValue("x_IdTangki");
            if (!IdTangki.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTangki") && !CurrentForm.HasValue("x_IdTangki")) // DN
                    IdTangki.Visible = false; // Disable update for API request
                else
                    IdTangki.SetFormValue(val);
            }

            // Check field name 'StatusProses' before field var 'x_StatusProses'
            val = CurrentForm.HasValue("StatusProses") ? CurrentForm.GetValue("StatusProses") : CurrentForm.GetValue("x_StatusProses");
            if (!StatusProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusProses") && !CurrentForm.HasValue("x_StatusProses")) // DN
                    StatusProses.Visible = false; // Disable update for API request
                else
                    StatusProses.SetFormValue(val);
            }

            // Check field name 'LookupNoPenyaluran' before field var 'x_LookupNoPenyaluran'
            val = CurrentForm.HasValue("LookupNoPenyaluran") ? CurrentForm.GetValue("LookupNoPenyaluran") : CurrentForm.GetValue("x_LookupNoPenyaluran");
            if (!LookupNoPenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LookupNoPenyaluran") && !CurrentForm.HasValue("x_LookupNoPenyaluran")) // DN
                    LookupNoPenyaluran.Visible = false; // Disable update for API request
                else
                    LookupNoPenyaluran.SetFormValue(val);
            }

            // Check field name 'NoPenyaluran' before field var 'x_NoPenyaluran'
            val = CurrentForm.HasValue("NoPenyaluran") ? CurrentForm.GetValue("NoPenyaluran") : CurrentForm.GetValue("x_NoPenyaluran");
            if (!NoPenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoPenyaluran") && !CurrentForm.HasValue("x_NoPenyaluran")) // DN
                    NoPenyaluran.Visible = false; // Disable update for API request
                else
                    NoPenyaluran.SetFormValue(val);
            }

            // Check field name 'PersentaseProgress' before field var 'x_PersentaseProgress'
            val = CurrentForm.HasValue("PersentaseProgress") ? CurrentForm.GetValue("PersentaseProgress") : CurrentForm.GetValue("x_PersentaseProgress");
            if (!PersentaseProgress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PersentaseProgress") && !CurrentForm.HasValue("x_PersentaseProgress")) // DN
                    PersentaseProgress.Visible = false; // Disable update for API request
                else
                    PersentaseProgress.SetFormValue(val);
            }

            // Check field name 'Catatan' before field var 'x_Catatan'
            val = CurrentForm.HasValue("Catatan") ? CurrentForm.GetValue("Catatan") : CurrentForm.GetValue("x_Catatan");
            if (!Catatan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Catatan") && !CurrentForm.HasValue("x_Catatan")) // DN
                    Catatan.Visible = false; // Disable update for API request
                else
                    Catatan.SetFormValue(val);
            }

            // Check field name 'DibuatOleh' before field var 'x_DibuatOleh'
            val = CurrentForm.HasValue("DibuatOleh") ? CurrentForm.GetValue("DibuatOleh") : CurrentForm.GetValue("x_DibuatOleh");
            if (!DibuatOleh.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DibuatOleh") && !CurrentForm.HasValue("x_DibuatOleh")) // DN
                    DibuatOleh.Visible = false; // Disable update for API request
                else
                    DibuatOleh.SetFormValue(val);
            }

            // Check field name 'TanggalDibuat' before field var 'x_TanggalDibuat'
            val = CurrentForm.HasValue("TanggalDibuat") ? CurrentForm.GetValue("TanggalDibuat") : CurrentForm.GetValue("x_TanggalDibuat");
            if (!TanggalDibuat.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalDibuat") && !CurrentForm.HasValue("x_TanggalDibuat")) // DN
                    TanggalDibuat.Visible = false; // Disable update for API request
                else
                    TanggalDibuat.SetFormValue(val);
                TanggalDibuat.CurrentValue = UnformatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            }

            // Check field name 'PlantForLookup' before field var 'x_PlantForLookup'
            val = CurrentForm.HasValue("PlantForLookup") ? CurrentForm.GetValue("PlantForLookup") : CurrentForm.GetValue("x_PlantForLookup");
            if (!PlantForLookup.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PlantForLookup") && !CurrentForm.HasValue("x_PlantForLookup")) // DN
                    PlantForLookup.Visible = false; // Disable update for API request
                else
                    PlantForLookup.SetFormValue(val);
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

            // Check field name 'IdPenimbunanPenyaluran' before field var 'x_IdPenimbunanPenyaluran'
            val = CurrentForm.HasValue("IdPenimbunanPenyaluran") ? CurrentForm.GetValue("IdPenimbunanPenyaluran") : CurrentForm.GetValue("x_IdPenimbunanPenyaluran");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            NomorPenimbunanPenyaluran.CurrentValue = NomorPenimbunanPenyaluran.FormValue;
            IdTemplate.CurrentValue = IdTemplate.FormValue;
            LookupPlant.CurrentValue = LookupPlant.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            TipeProdukSTS.CurrentValue = TipeProdukSTS.FormValue;
            TipePenyaluran.CurrentValue = TipePenyaluran.FormValue;
            JenisProduk.CurrentValue = JenisProduk.FormValue;
            IdModa.CurrentValue = IdModa.FormValue;
            IdTangki.CurrentValue = IdTangki.FormValue;
            StatusProses.CurrentValue = StatusProses.FormValue;
            LookupNoPenyaluran.CurrentValue = LookupNoPenyaluran.FormValue;
            NoPenyaluran.CurrentValue = NoPenyaluran.FormValue;
            PersentaseProgress.CurrentValue = PersentaseProgress.FormValue;
            Catatan.CurrentValue = Catatan.FormValue;
            DibuatOleh.CurrentValue = DibuatOleh.FormValue;
            TanggalDibuat.CurrentValue = TanggalDibuat.FormValue;
            TanggalDibuat.CurrentValue = UnformatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            PlantForLookup.CurrentValue = PlantForLookup.FormValue;
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
            IdPenimbunanPenyaluran.SetDbValue(row["IdPenimbunanPenyaluran"]);
            NomorPenimbunanPenyaluran.SetDbValue(row["NomorPenimbunanPenyaluran"]);
            Proses2.SetDbValue(row["Proses"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            Plant.SetDbValue(row["Plant"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            TipePenyaluran.SetDbValue(row["TipePenyaluran"]);
            JenisProduk.SetDbValue(row["JenisProduk"]);
            IdModa.SetDbValue(row["IdModa"]);
            IdTangki.SetDbValue(row["IdTangki"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            LookupNoPenyaluran.SetDbValue(row["LookupNoPenyaluran"]);
            NoPenyaluran.SetDbValue(row["NoPenyaluran"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            PlantForLookup.SetDbValue(row["PlantForLookup"]);
            LookupTipeProduk.SetDbValue(row["LookupTipeProduk"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdPenimbunanPenyaluran", IdPenimbunanPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPenimbunanPenyaluran", NomorPenimbunanPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("Proses", Proses2.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("TipePenyaluran", TipePenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("JenisProduk", JenisProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("IdModa", IdModa.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTangki", IdTangki.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupNoPenyaluran", LookupNoPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("NoPenyaluran", NoPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("Catatan", Catatan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantForLookup", PlantForLookup.DefaultValue ?? DbNullValue); // DN
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

            // IdPenimbunanPenyaluran
            IdPenimbunanPenyaluran.RowCssClass = "row";

            // NomorPenimbunanPenyaluran
            NomorPenimbunanPenyaluran.RowCssClass = "row";

            // Proses
            Proses2.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // TipePenyaluran
            TipePenyaluran.RowCssClass = "row";

            // JenisProduk
            JenisProduk.RowCssClass = "row";

            // IdModa
            IdModa.RowCssClass = "row";

            // IdTangki
            IdTangki.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

            // LookupNoPenyaluran
            LookupNoPenyaluran.RowCssClass = "row";

            // NoPenyaluran
            NoPenyaluran.RowCssClass = "row";

            // PersentaseProgress
            PersentaseProgress.RowCssClass = "row";

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

            // PlantForLookup
            PlantForLookup.RowCssClass = "row";

            // LookupTipeProduk
            LookupTipeProduk.RowCssClass = "row";

            // LookupJenisPlant
            LookupJenisPlant.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // NomorPenimbunanPenyaluran
                NomorPenimbunanPenyaluran.ViewValue = ConvertToString(NomorPenimbunanPenyaluran.CurrentValue); // DN
                NomorPenimbunanPenyaluran.ViewCustomAttributes = "";

                // Proses
                Proses2.ViewValue = ConvertToString(Proses2.CurrentValue); // DN
                Proses2.ViewCustomAttributes = "";

                // IdTemplate
                IdTemplate.ViewValue = IdTemplate.CurrentValue;
                IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
                IdTemplate.ViewCustomAttributes = "";

                // LookupPlant
                if (!Empty(LookupPlant.CurrentValue)) {
                    LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                } else {
                    LookupPlant.ViewValue = DbNullValue;
                }
                LookupPlant.ViewCustomAttributes = "";

                // Plant
                Plant.ViewValue = ConvertToString(Plant.CurrentValue); // DN
                string curVal2 = ConvertToString(Plant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Plant.ViewValue = Plant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = Plant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                            var listwrk = Plant.Lookup?.RenderViewRow(rswrk2[0]);
                            Plant.ViewValue = Plant.DisplayValue(listwrk);
                        } else {
                            Plant.ViewValue = Plant.CurrentValue;
                        }
                    }
                } else {
                    Plant.ViewValue = DbNullValue;
                }
                Plant.ViewCustomAttributes = "";

                // TipeProdukSTS
                List<object?>? listWrk3 = [ // DN
                    TipeProdukSTS.CurrentValue,
                    TipeProdukSTS.CurrentValue,
                ];
                listWrk3 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk3, this);
                string? dispVal3 = TipeProdukSTS.DisplayValue(listWrk3);
                if (!Empty(dispVal3))
                    TipeProdukSTS.ViewValue = dispVal3;
                TipeProdukSTS.ViewCustomAttributes = "";

                // TipePenyaluran
                if (!Empty(TipePenyaluran.CurrentValue)) {
                    TipePenyaluran.ViewValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
                } else {
                    TipePenyaluran.ViewValue = DbNullValue;
                }
                TipePenyaluran.ViewCustomAttributes = "";

                // JenisProduk
                string curVal5 = ConvertToString(JenisProduk.CurrentValue);
                if (!Empty(curVal5)) {
                    if (JenisProduk.Lookup != null && IsDictionary(JenisProduk.Lookup?.Options) && JenisProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        JenisProduk.ViewValue = JenisProduk.LookupCacheOption(curVal5);
                    } else { // Lookup from database // DN
                        string filterWrk5 = SearchFilter(JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", JenisProduk.CurrentValue, JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                        string? sqlWrk5 = JenisProduk.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk5?.Count > 0 && JenisProduk.Lookup != null) { // Lookup values found
                            var listwrk = JenisProduk.Lookup?.RenderViewRow(rswrk5[0]);
                            JenisProduk.ViewValue = JenisProduk.DisplayValue(listwrk);
                        } else {
                            JenisProduk.ViewValue = JenisProduk.CurrentValue;
                        }
                    }
                } else {
                    JenisProduk.ViewValue = DbNullValue;
                }
                JenisProduk.ViewCustomAttributes = "";

                // IdModa
                string curVal6 = ConvertToString(IdModa.CurrentValue);
                if (!Empty(curVal6)) {
                    if (IdModa.Lookup != null && IsDictionary(IdModa.Lookup?.Options) && IdModa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdModa.ViewValue = IdModa.LookupCacheOption(curVal6);
                    } else { // Lookup from database // DN
                        string filterWrk6 = SearchFilter(IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", IdModa.CurrentValue, IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                        string? sqlWrk6 = IdModa.Lookup?.GetSql(false, filterWrk6, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk6 = sqlWrk6 != null ? Connection.GetRows(sqlWrk6) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk6?.Count > 0 && IdModa.Lookup != null) { // Lookup values found
                            var listwrk = IdModa.Lookup?.RenderViewRow(rswrk6[0]);
                            IdModa.ViewValue = IdModa.DisplayValue(listwrk);
                        } else {
                            IdModa.ViewValue = FormatNumber(IdModa.CurrentValue, IdModa.FormatPattern);
                        }
                    }
                } else {
                    IdModa.ViewValue = DbNullValue;
                }
                IdModa.ViewCustomAttributes = "";

                // IdTangki
                string curVal7 = ConvertToString(IdTangki.CurrentValue);
                if (!Empty(curVal7)) {
                    if (IdTangki.Lookup != null && IsDictionary(IdTangki.Lookup?.Options) && IdTangki.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTangki.ViewValue = IdTangki.LookupCacheOption(curVal7);
                    } else { // Lookup from database // DN
                        string filterWrk7 = SearchFilter(IdTangki.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdTangki.CurrentValue, IdTangki.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                        var lookupFilter7 = () => IdTangki.GetSelectFilter();
                        string? sqlWrk7 = IdTangki.Lookup?.GetSql(false, filterWrk7, lookupFilter7, this, true, true);
                        List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk7?.Count > 0 && IdTangki.Lookup != null) { // Lookup values found
                            var listwrk = IdTangki.Lookup?.RenderViewRow(rswrk7[0]);
                            IdTangki.ViewValue = IdTangki.DisplayValue(listwrk);
                        } else {
                            IdTangki.ViewValue = FormatNumber(IdTangki.CurrentValue, IdTangki.FormatPattern);
                        }
                    }
                } else {
                    IdTangki.ViewValue = DbNullValue;
                }
                IdTangki.ViewCustomAttributes = "";

                // StatusProses
                StatusProses.ViewValue = StatusProses.CurrentValue;
                StatusProses.ViewCustomAttributes = "";

                // LookupNoPenyaluran
                if (!Empty(LookupNoPenyaluran.CurrentValue)) {
                    LookupNoPenyaluran.ViewValue = LookupNoPenyaluran.OptionCaption(ConvertToString(LookupNoPenyaluran.CurrentValue));
                } else {
                    LookupNoPenyaluran.ViewValue = DbNullValue;
                }
                LookupNoPenyaluran.ViewCustomAttributes = "";

                // NoPenyaluran
                NoPenyaluran.ViewValue = ConvertToString(NoPenyaluran.CurrentValue); // DN
                NoPenyaluran.ViewCustomAttributes = "";

                // PersentaseProgress
                PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                PersentaseProgress.ViewCustomAttributes = "";

                // Catatan
                Catatan.ViewValue = Catatan.CurrentValue;
                Catatan.ViewCustomAttributes = "";

                // DibuatOleh
                DibuatOleh.ViewValue = DibuatOleh.CurrentValue;
                DibuatOleh.ViewCustomAttributes = "";

                // TanggalDibuat
                TanggalDibuat.ViewValue = TanggalDibuat.CurrentValue;
                TanggalDibuat.ViewValue = FormatDateTime(TanggalDibuat.ViewValue, TanggalDibuat.FormatPattern);
                TanggalDibuat.ViewCustomAttributes = "";

                // DiperbaruiOleh
                DiperbaruiOleh.ViewValue = DiperbaruiOleh.CurrentValue;
                DiperbaruiOleh.ViewCustomAttributes = "";

                // TanggalDiperbarui
                TanggalDiperbarui.ViewValue = TanggalDiperbarui.CurrentValue;
                TanggalDiperbarui.ViewValue = FormatDateTime(TanggalDiperbarui.ViewValue, TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.ViewCustomAttributes = "";

                // PlantForLookup
                PlantForLookup.ViewValue = PlantForLookup.CurrentValue;
                PlantForLookup.ViewCustomAttributes = "";

                // LookupTipeProduk
                LookupTipeProduk.ViewValue = LookupTipeProduk.CurrentValue;
                LookupTipeProduk.ViewCustomAttributes = "";

                // LookupJenisPlant
                LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
                LookupJenisPlant.ViewCustomAttributes = "";

                // NomorPenimbunanPenyaluran
                NomorPenimbunanPenyaluran.HrefValue = "";
                NomorPenimbunanPenyaluran.TooltipValue = "";

                // IdTemplate
                IdTemplate.HrefValue = "";

                // LookupPlant
                LookupPlant.HrefValue = "";

                // Plant
                Plant.HrefValue = "";
                Plant.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";
                TipePenyaluran.TooltipValue = "";

                // JenisProduk
                JenisProduk.HrefValue = "";
                JenisProduk.TooltipValue = "";

                // IdModa
                IdModa.HrefValue = "";
                IdModa.TooltipValue = "";

                // IdTangki
                IdTangki.HrefValue = "";
                IdTangki.TooltipValue = "";

                // StatusProses
                StatusProses.HrefValue = "";
                StatusProses.TooltipValue = "";

                // LookupNoPenyaluran
                LookupNoPenyaluran.HrefValue = "";

                // NoPenyaluran
                NoPenyaluran.HrefValue = "";
                NoPenyaluran.TooltipValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";
                PersentaseProgress.TooltipValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // PlantForLookup
                PlantForLookup.HrefValue = "";
                PlantForLookup.TooltipValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";
                LookupTipeProduk.TooltipValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
                LookupJenisPlant.TooltipValue = "";
            } else if (RowType == RowType.Add) {
                // NomorPenimbunanPenyaluran
                NomorPenimbunanPenyaluran.SetupEditAttributes();
                if (!NomorPenimbunanPenyaluran.Raw)
                    NomorPenimbunanPenyaluran.CurrentValue = HtmlDecode(NomorPenimbunanPenyaluran.CurrentValue);
                NomorPenimbunanPenyaluran.EditValue = HtmlEncode(NomorPenimbunanPenyaluran.CurrentValue);
                NomorPenimbunanPenyaluran.PlaceHolder = RemoveHtml(NomorPenimbunanPenyaluran.Caption);

                // IdTemplate
                IdTemplate.SetupEditAttributes();
                IdTemplate.CurrentValue = FormatNumber(IdTemplate.GetDefault(), IdTemplate.FormatPattern);
                if (!Empty(IdTemplate.EditValue) && IsNumeric(IdTemplate.EditValue))
                    IdTemplate.EditValue = FormatNumber(IdTemplate.EditValue, null);

                // LookupPlant
                LookupPlant.SetupEditAttributes();
                LookupPlant.EditValue = LookupPlant.Options(true);
                LookupPlant.PlaceHolder = RemoveHtml(LookupPlant.Caption);
                if (!Empty(LookupPlant.EditValue) && IsNumeric(LookupPlant.EditValue))
                    LookupPlant.EditValue = FormatNumber(LookupPlant.EditValue, null);

                // Plant
                Plant.SetupEditAttributes();
                if (!Plant.Raw)
                    Plant.CurrentValue = HtmlDecode(Plant.CurrentValue);
                Plant.EditValue = HtmlEncode(Plant.CurrentValue);
                string curVal2 = ConvertToString(Plant.CurrentValue);
                if (!Empty(curVal2)) {
                    if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Plant.EditValue = Plant.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = Plant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                            var listwrk = Plant.Lookup?.RenderViewRow(rswrk2[0]);
                            Plant.EditValue = Plant.DisplayValue(listwrk);
                        } else {
                            Plant.EditValue = HtmlEncode(Plant.CurrentValue);
                        }
                    }
                } else {
                    Plant.EditValue = DbNullValue;
                }
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);

                // TipeProdukSTS
                TipeProdukSTS.SetupEditAttributes();
                string curVal3 = ConvertToString(TipeProdukSTS.CurrentValue);
                if (TipeProdukSTS.Lookup != null && IsDictionary(TipeProdukSTS.Lookup?.Options) && TipeProdukSTS.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TipeProdukSTS.EditValue = TipeProdukSTS.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk3 = "";
                    if (curVal3 == "") {
                        filterWrk3 = "0=1";
                    } else {
                        filterWrk3 = SearchFilter(TipeProdukSTS.Lookup?.GetTable()?.Fields["TipeProduk"].SearchExpression, "=", TipeProdukSTS.CurrentValue, TipeProdukSTS.Lookup?.GetTable()?.Fields["TipeProduk"].SearchDataType, "");
                    }
                    string? sqlWrk3 = TipeProdukSTS.Lookup?.GetSql(true, filterWrk3, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    TipeProdukSTS.EditValue = rswrk3;
                }
                TipeProdukSTS.PlaceHolder = RemoveHtml(TipeProdukSTS.Caption);

                // TipePenyaluran
                TipePenyaluran.SetupEditAttributes();
                TipePenyaluran.EditValue = TipePenyaluran.Options(true);
                TipePenyaluran.PlaceHolder = RemoveHtml(TipePenyaluran.Caption);

                // JenisProduk
                JenisProduk.SetupEditAttributes();
                string curVal5 = ConvertToString(JenisProduk.CurrentValue);
                if (JenisProduk.Lookup != null && IsDictionary(JenisProduk.Lookup?.Options) && JenisProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    JenisProduk.EditValue = JenisProduk.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk5 = "";
                    if (curVal5 == "") {
                        filterWrk5 = "0=1";
                    } else {
                        filterWrk5 = SearchFilter(JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", JenisProduk.CurrentValue, JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                    }
                    string? sqlWrk5 = JenisProduk.Lookup?.GetSql(true, filterWrk5, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    JenisProduk.EditValue = rswrk5;
                }
                JenisProduk.PlaceHolder = RemoveHtml(JenisProduk.Caption);

                // IdModa
                IdModa.SetupEditAttributes();
                string curVal6 = ConvertToString(IdModa.CurrentValue);
                if (IdModa.Lookup != null && IsDictionary(IdModa.Lookup?.Options) && IdModa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdModa.EditValue = IdModa.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk6 = "";
                    if (curVal6 == "") {
                        filterWrk6 = "0=1";
                    } else {
                        filterWrk6 = SearchFilter(IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", IdModa.CurrentValue, IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                    }
                    string? sqlWrk6 = IdModa.Lookup?.GetSql(true, filterWrk6, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk6 = sqlWrk6 != null ? Connection.GetRows(sqlWrk6) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdModa.EditValue = rswrk6;
                }
                IdModa.PlaceHolder = RemoveHtml(IdModa.Caption);
                if (!Empty(IdModa.EditValue) && IsNumeric(IdModa.EditValue))
                    IdModa.EditValue = FormatNumber(IdModa.EditValue, null);

                // IdTangki
                IdTangki.SetupEditAttributes();
                string curVal7 = ConvertToString(IdTangki.CurrentValue);
                if (IdTangki.Lookup != null && IsDictionary(IdTangki.Lookup?.Options) && IdTangki.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdTangki.EditValue = IdTangki.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk7 = "";
                    if (curVal7 == "") {
                        filterWrk7 = "0=1";
                    } else {
                        filterWrk7 = SearchFilter(IdTangki.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdTangki.CurrentValue, IdTangki.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                    }
                    var lookupFilter7 = () => IdTangki.GetSelectFilter();
                    string? sqlWrk7 = IdTangki.Lookup?.GetSql(true, filterWrk7, lookupFilter7, this, false, true);
                    List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdTangki.EditValue = rswrk7;
                }
                IdTangki.PlaceHolder = RemoveHtml(IdTangki.Caption);
                if (!Empty(IdTangki.EditValue) && IsNumeric(IdTangki.EditValue))
                    IdTangki.EditValue = FormatNumber(IdTangki.EditValue, null);

                // StatusProses
                StatusProses.SetupEditAttributes();
                StatusProses.CurrentValue = StatusProses.GetDefault();

                // LookupNoPenyaluran
                LookupNoPenyaluran.SetupEditAttributes();
                LookupNoPenyaluran.EditValue = LookupNoPenyaluran.Options(true);
                LookupNoPenyaluran.PlaceHolder = RemoveHtml(LookupNoPenyaluran.Caption);

                // NoPenyaluran
                NoPenyaluran.SetupEditAttributes();
                if (!NoPenyaluran.Raw)
                    NoPenyaluran.CurrentValue = HtmlDecode(NoPenyaluran.CurrentValue);
                NoPenyaluran.EditValue = HtmlEncode(NoPenyaluran.CurrentValue);
                NoPenyaluran.PlaceHolder = RemoveHtml(NoPenyaluran.Caption);

                // PersentaseProgress
                PersentaseProgress.SetupEditAttributes();
                PersentaseProgress.CurrentValue = FormatPercent(PersentaseProgress.GetDefault(), PersentaseProgress.FormatPattern);

                // Catatan
                Catatan.SetupEditAttributes();
                Catatan.EditValue = Catatan.CurrentValue; // DN
                Catatan.PlaceHolder = RemoveHtml(Catatan.Caption);

                // DibuatOleh

                // TanggalDibuat

                // PlantForLookup
                PlantForLookup.SetupEditAttributes();
                if (!PlantForLookup.Raw)
                    PlantForLookup.CurrentValue = HtmlDecode(PlantForLookup.CurrentValue);
                PlantForLookup.EditValue = HtmlEncode(PlantForLookup.CurrentValue);
                PlantForLookup.PlaceHolder = RemoveHtml(PlantForLookup.Caption);

                // LookupTipeProduk
                LookupTipeProduk.SetupEditAttributes();
                if (!LookupTipeProduk.Raw)
                    LookupTipeProduk.CurrentValue = HtmlDecode(LookupTipeProduk.CurrentValue);
                LookupTipeProduk.EditValue = HtmlEncode(LookupTipeProduk.CurrentValue);
                LookupTipeProduk.PlaceHolder = RemoveHtml(LookupTipeProduk.Caption);

                // LookupJenisPlant
                LookupJenisPlant.SetupEditAttributes();
                if (!LookupJenisPlant.Raw)
                    LookupJenisPlant.CurrentValue = HtmlDecode(LookupJenisPlant.CurrentValue);
                LookupJenisPlant.EditValue = HtmlEncode(LookupJenisPlant.CurrentValue);
                LookupJenisPlant.PlaceHolder = RemoveHtml(LookupJenisPlant.Caption);

                // Add refer script

                // NomorPenimbunanPenyaluran
                NomorPenimbunanPenyaluran.HrefValue = "";

                // IdTemplate
                IdTemplate.HrefValue = "";

                // LookupPlant
                LookupPlant.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";

                // JenisProduk
                JenisProduk.HrefValue = "";

                // IdModa
                IdModa.HrefValue = "";

                // IdTangki
                IdTangki.HrefValue = "";

                // StatusProses
                StatusProses.HrefValue = "";

                // LookupNoPenyaluran
                LookupNoPenyaluran.HrefValue = "";

                // NoPenyaluran
                NoPenyaluran.HrefValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // PlantForLookup
                PlantForLookup.HrefValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
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
                if (NomorPenimbunanPenyaluran.Visible && NomorPenimbunanPenyaluran.Required) {
                    if (!NomorPenimbunanPenyaluran.IsDetailKey && Empty(NomorPenimbunanPenyaluran.FormValue)) {
                        NomorPenimbunanPenyaluran.AddErrorMessage(ConvertToString(NomorPenimbunanPenyaluran.RequiredErrorMessage).Replace("%s", NomorPenimbunanPenyaluran.Caption));
                    }
                }
                if (IdTemplate.Visible && IdTemplate.Required) {
                    if (!IdTemplate.IsDetailKey && Empty(IdTemplate.FormValue)) {
                        IdTemplate.AddErrorMessage(ConvertToString(IdTemplate.RequiredErrorMessage).Replace("%s", IdTemplate.Caption));
                    }
                }
                if (LookupPlant.Visible && LookupPlant.Required) {
                    if (!LookupPlant.IsDetailKey && Empty(LookupPlant.FormValue)) {
                        LookupPlant.AddErrorMessage(ConvertToString(LookupPlant.RequiredErrorMessage).Replace("%s", LookupPlant.Caption));
                    }
                }
                if (Plant.Visible && Plant.Required) {
                    if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                        Plant.AddErrorMessage(ConvertToString(Plant.RequiredErrorMessage).Replace("%s", Plant.Caption));
                    }
                }
                if (TipeProdukSTS.Visible && TipeProdukSTS.Required) {
                    if (!TipeProdukSTS.IsDetailKey && Empty(TipeProdukSTS.FormValue)) {
                        TipeProdukSTS.AddErrorMessage(ConvertToString(TipeProdukSTS.RequiredErrorMessage).Replace("%s", TipeProdukSTS.Caption));
                    }
                }
                if (TipePenyaluran.Visible && TipePenyaluran.Required) {
                    if (!TipePenyaluran.IsDetailKey && Empty(TipePenyaluran.FormValue)) {
                        TipePenyaluran.AddErrorMessage(ConvertToString(TipePenyaluran.RequiredErrorMessage).Replace("%s", TipePenyaluran.Caption));
                    }
                }
                if (JenisProduk.Visible && JenisProduk.Required) {
                    if (!JenisProduk.IsDetailKey && Empty(JenisProduk.FormValue)) {
                        JenisProduk.AddErrorMessage(ConvertToString(JenisProduk.RequiredErrorMessage).Replace("%s", JenisProduk.Caption));
                    }
                }
                if (IdModa.Visible && IdModa.Required) {
                    if (!IdModa.IsDetailKey && Empty(IdModa.FormValue)) {
                        IdModa.AddErrorMessage(ConvertToString(IdModa.RequiredErrorMessage).Replace("%s", IdModa.Caption));
                    }
                }
                if (IdTangki.Visible && IdTangki.Required) {
                    if (!IdTangki.IsDetailKey && Empty(IdTangki.FormValue)) {
                        IdTangki.AddErrorMessage(ConvertToString(IdTangki.RequiredErrorMessage).Replace("%s", IdTangki.Caption));
                    }
                }
                if (StatusProses.Visible && StatusProses.Required) {
                    if (!StatusProses.IsDetailKey && Empty(StatusProses.FormValue)) {
                        StatusProses.AddErrorMessage(ConvertToString(StatusProses.RequiredErrorMessage).Replace("%s", StatusProses.Caption));
                    }
                }
                if (LookupNoPenyaluran.Visible && LookupNoPenyaluran.Required) {
                    if (!LookupNoPenyaluran.IsDetailKey && Empty(LookupNoPenyaluran.FormValue)) {
                        LookupNoPenyaluran.AddErrorMessage(ConvertToString(LookupNoPenyaluran.RequiredErrorMessage).Replace("%s", LookupNoPenyaluran.Caption));
                    }
                }
                if (NoPenyaluran.Visible && NoPenyaluran.Required) {
                    if (!NoPenyaluran.IsDetailKey && Empty(NoPenyaluran.FormValue)) {
                        NoPenyaluran.AddErrorMessage(ConvertToString(NoPenyaluran.RequiredErrorMessage).Replace("%s", NoPenyaluran.Caption));
                    }
                }
                if (PersentaseProgress.Visible && PersentaseProgress.Required) {
                    if (!PersentaseProgress.IsDetailKey && Empty(PersentaseProgress.FormValue)) {
                        PersentaseProgress.AddErrorMessage(ConvertToString(PersentaseProgress.RequiredErrorMessage).Replace("%s", PersentaseProgress.Caption));
                    }
                }
                if (Catatan.Visible && Catatan.Required) {
                    if (!Catatan.IsDetailKey && Empty(Catatan.FormValue)) {
                        Catatan.AddErrorMessage(ConvertToString(Catatan.RequiredErrorMessage).Replace("%s", Catatan.Caption));
                    }
                }
                if (DibuatOleh.Visible && DibuatOleh.Required) {
                    if (!DibuatOleh.IsDetailKey && Empty(DibuatOleh.FormValue)) {
                        DibuatOleh.AddErrorMessage(ConvertToString(DibuatOleh.RequiredErrorMessage).Replace("%s", DibuatOleh.Caption));
                    }
                }
                if (TanggalDibuat.Visible && TanggalDibuat.Required) {
                    if (!TanggalDibuat.IsDetailKey && Empty(TanggalDibuat.FormValue)) {
                        TanggalDibuat.AddErrorMessage(ConvertToString(TanggalDibuat.RequiredErrorMessage).Replace("%s", TanggalDibuat.Caption));
                    }
                }
                if (PlantForLookup.Visible && PlantForLookup.Required) {
                    if (!PlantForLookup.IsDetailKey && Empty(PlantForLookup.FormValue)) {
                        PlantForLookup.AddErrorMessage(ConvertToString(PlantForLookup.RequiredErrorMessage).Replace("%s", PlantForLookup.Caption));
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
                    rsnew["IdPenimbunanPenyaluran"] = IdPenimbunanPenyaluran.CurrentValue!;
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

                // NomorPenimbunanPenyaluran
                NomorPenimbunanPenyaluran.SetDbValue(rsnew, NomorPenimbunanPenyaluran.CurrentValue);

                // IdTemplate
                IdTemplate.SetDbValue(rsnew, IdTemplate.CurrentValue);

                // LookupPlant
                LookupPlant.SetDbValue(rsnew, LookupPlant.CurrentValue);

                // Plant
                Plant.SetDbValue(rsnew, Plant.CurrentValue);

                // TipeProdukSTS
                TipeProdukSTS.SetDbValue(rsnew, TipeProdukSTS.CurrentValue);

                // TipePenyaluran
                TipePenyaluran.SetDbValue(rsnew, TipePenyaluran.CurrentValue);

                // JenisProduk
                JenisProduk.SetDbValue(rsnew, JenisProduk.CurrentValue);

                // IdModa
                IdModa.SetDbValue(rsnew, IdModa.CurrentValue);

                // IdTangki
                IdTangki.SetDbValue(rsnew, IdTangki.CurrentValue);

                // StatusProses
                StatusProses.SetDbValue(rsnew, StatusProses.CurrentValue);

                // LookupNoPenyaluran
                LookupNoPenyaluran.SetDbValue(rsnew, LookupNoPenyaluran.CurrentValue);

                // NoPenyaluran
                NoPenyaluran.SetDbValue(rsnew, NoPenyaluran.CurrentValue);

                // PersentaseProgress
                PersentaseProgress.SetDbValue(rsnew, PersentaseProgress.CurrentValue);

                // Catatan
                Catatan.SetDbValue(rsnew, Catatan.CurrentValue);

                // DibuatOleh
                DibuatOleh.CurrentValue = DibuatOleh.GetAutoUpdateValue();
                DibuatOleh.SetDbValue(rsnew, DibuatOleh.CurrentValue);

                // TanggalDibuat
                TanggalDibuat.CurrentValue = TanggalDibuat.GetAutoUpdateValue();
                TanggalDibuat.SetDbValue(rsnew, ConvertToDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern));

                // PlantForLookup
                PlantForLookup.SetDbValue(rsnew, PlantForLookup.CurrentValue);

                // LookupTipeProduk
                LookupTipeProduk.SetDbValue(rsnew, LookupTipeProduk.CurrentValue);

                // LookupJenisPlant
                LookupJenisPlant.SetDbValue(rsnew, LookupJenisPlant.CurrentValue);
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
            if (row.TryGetValue("NomorPenimbunanPenyaluran", out value)) // NomorPenimbunanPenyaluran
                NomorPenimbunanPenyaluran.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdTemplate", out value)) // IdTemplate
                IdTemplate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupPlant", out value)) // LookupPlant
                LookupPlant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TipeProdukSTS", out value)) // TipeProdukSTS
                TipeProdukSTS.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TipePenyaluran", out value)) // TipePenyaluran
                TipePenyaluran.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("JenisProduk", out value)) // JenisProduk
                JenisProduk.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdModa", out value)) // IdModa
                IdModa.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdTangki", out value)) // IdTangki
                IdTangki.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusProses", out value)) // StatusProses
                StatusProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupNoPenyaluran", out value)) // LookupNoPenyaluran
                LookupNoPenyaluran.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NoPenyaluran", out value)) // NoPenyaluran
                NoPenyaluran.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PersentaseProgress", out value)) // PersentaseProgress
                PersentaseProgress.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Catatan", out value)) // Catatan
                Catatan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DibuatOleh", out value)) // DibuatOleh
                DibuatOleh.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalDibuat", out value)) // TanggalDibuat
                TanggalDibuat.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PlantForLookup", out value)) // PlantForLookup
                PlantForLookup.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupTipeProduk", out value)) // LookupTipeProduk
                LookupTipeProduk.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupJenisPlant", out value)) // LookupJenisPlant
                LookupJenisPlant.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("PenimbunanPenyaluranList")), "", TableVar, true);
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
                // Set up lookup SQL
                switch (fld.FieldVar) {
                    case "x_IdTangki":
                        lookupFilter = () => fld.GetSelectFilter();
                        break;
                }

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
