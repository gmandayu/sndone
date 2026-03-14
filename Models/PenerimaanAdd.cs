namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penerimaanAdd
    /// </summary>
    public static PenerimaanAdd penerimaanAdd
    {
        get => HttpData.Get<PenerimaanAdd>("penerimaanAdd")!;
        set => HttpData["penerimaanAdd"] = value;
    }

    /// <summary>
    /// Page class for Penerimaan
    /// </summary>
    public class PenerimaanAdd : PenerimaanAddBase
    {
        // Constructor
        public PenerimaanAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenerimaanAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            IdPlant.DisplayValueSeparator = " - ";
            KodeProduk.DisplayValueSeparator = " - ";
            IdDermaga.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenerimaanAddBase : Penerimaan
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penerimaanAdd";

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
        public PenerimaanAddBase()
        {
            TableName = "Penerimaan";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (penerimaan)
            if (penerimaan == null || penerimaan is Penerimaan)
                penerimaan = this;

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
        public string PageName => "PenerimaanAdd";

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
            IdPenerimaan.Visible = false;
            NomorPenerimaan.Visible = false;
            Proses2.Visible = false;
            NomorVoyage.SetVisibility();
            NomorPengiriman.SetVisibility();
            LookupPlant.SetVisibility();
            IdPlant.SetVisibility();
            TipeProdukSTS.SetVisibility();
            KodeProduk.SetVisibility();
            ModaTransportasi.SetVisibility();
            NamaKapal.SetVisibility();
            DetailRTW.Visible = false;
            Refinery.SetVisibility();
            IdPenyaluran.SetVisibility();
            PenyaluranLookup.Visible = false;
            TanggalSandar.SetVisibility();
            IdDermaga.SetVisibility();
            StatusProses.SetVisibility();
            PersentaseProgress.SetVisibility();
            IdTemplate.SetVisibility();
            Catatan.SetVisibility();
            DibuatOleh.SetVisibility();
            TanggalDibuat.SetVisibility();
            DiperbaruiOleh.SetVisibility();
            TanggalDiperbarui.SetVisibility();
            LookupTipeProduk.SetVisibility();
            LookupJenisPlant.SetVisibility();
        }

        // Constructor
        public PenerimaanAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "PenerimaanView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdPenerimaan") ? dict["IdPenerimaan"] : IdPenerimaan.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdPenerimaan.Visible = false;
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
            await SetupLookupOptions(IdPlant);
            await SetupLookupOptions(TipeProdukSTS);
            await SetupLookupOptions(KodeProduk);
            await SetupLookupOptions(ModaTransportasi);
            await SetupLookupOptions(Refinery);
            await SetupLookupOptions(IdPenyaluran);
            await SetupLookupOptions(PenyaluranLookup);
            await SetupLookupOptions(IdDermaga);

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
                if (RouteValues.TryGetValue("IdPenerimaan", out rv)) { // DN
                    IdPenerimaan.QueryValue = UrlDecode(rv); // DN
                } else if (Get("IdPenerimaan", out sv)) {
                    IdPenerimaan.QueryValue = sv.ToString();
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
                        return Terminate("PenerimaanList"); // No matching record, return to List page // DN
                    }
                    break;
                case "insert": // Add new record // DN
                    SendEmail = true; // Send email on add success
                    var res = await AddRow(rsold);
                    if (res) { // Add successful
                        if (Empty(SuccessMessage) && Post("addopt") != "1") // Skip success message for addopt (done in JavaScript)
                            SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
                        string returnUrl = "";
                        returnUrl = "PenerimaanList";
                        if (GetPageName(returnUrl) == "PenerimaanList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "PenerimaanView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "PenerimaanList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "PenerimaanList"; // Return list page content
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
                penerimaanAdd?.PageRender();
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
            StatusProses.DefaultValue = StatusProses.GetDefault(); // DN
            StatusProses.OldValue = StatusProses.DefaultValue;
            PersentaseProgress.DefaultValue = PersentaseProgress.GetDefault(); // DN
            PersentaseProgress.OldValue = PersentaseProgress.DefaultValue;
            IdTemplate.DefaultValue = IdTemplate.GetDefault(); // DN
            IdTemplate.OldValue = IdTemplate.DefaultValue;
            DibuatOleh.DefaultValue = DibuatOleh.GetDefault(); // DN
            DibuatOleh.OldValue = DibuatOleh.DefaultValue;
        }

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'NomorVoyage' before field var 'x_NomorVoyage'
            val = CurrentForm.HasValue("NomorVoyage") ? CurrentForm.GetValue("NomorVoyage") : CurrentForm.GetValue("x_NomorVoyage");
            if (!NomorVoyage.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorVoyage") && !CurrentForm.HasValue("x_NomorVoyage")) // DN
                    NomorVoyage.Visible = false; // Disable update for API request
                else
                    NomorVoyage.SetFormValue(val);
            }

            // Check field name 'NomorPengiriman' before field var 'x_NomorPengiriman'
            val = CurrentForm.HasValue("NomorPengiriman") ? CurrentForm.GetValue("NomorPengiriman") : CurrentForm.GetValue("x_NomorPengiriman");
            if (!NomorPengiriman.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorPengiriman") && !CurrentForm.HasValue("x_NomorPengiriman")) // DN
                    NomorPengiriman.Visible = false; // Disable update for API request
                else
                    NomorPengiriman.SetFormValue(val);
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
                    IdPlant.SetFormValue(val, true, validate);
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

            // Check field name 'ModaTransportasi' before field var 'x_ModaTransportasi'
            val = CurrentForm.HasValue("ModaTransportasi") ? CurrentForm.GetValue("ModaTransportasi") : CurrentForm.GetValue("x_ModaTransportasi");
            if (!ModaTransportasi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ModaTransportasi") && !CurrentForm.HasValue("x_ModaTransportasi")) // DN
                    ModaTransportasi.Visible = false; // Disable update for API request
                else
                    ModaTransportasi.SetFormValue(val);
            }

            // Check field name 'NamaKapal' before field var 'x_NamaKapal'
            val = CurrentForm.HasValue("NamaKapal") ? CurrentForm.GetValue("NamaKapal") : CurrentForm.GetValue("x_NamaKapal");
            if (!NamaKapal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaKapal") && !CurrentForm.HasValue("x_NamaKapal")) // DN
                    NamaKapal.Visible = false; // Disable update for API request
                else
                    NamaKapal.SetFormValue(val);
            }

            // Check field name 'Refinery' before field var 'x_Refinery'
            val = CurrentForm.HasValue("Refinery") ? CurrentForm.GetValue("Refinery") : CurrentForm.GetValue("x_Refinery");
            if (!Refinery.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Refinery") && !CurrentForm.HasValue("x_Refinery")) // DN
                    Refinery.Visible = false; // Disable update for API request
                else
                    Refinery.SetFormValue(val);
            }

            // Check field name 'IdPenyaluran' before field var 'x_IdPenyaluran'
            val = CurrentForm.HasValue("IdPenyaluran") ? CurrentForm.GetValue("IdPenyaluran") : CurrentForm.GetValue("x_IdPenyaluran");
            if (!IdPenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPenyaluran") && !CurrentForm.HasValue("x_IdPenyaluran")) // DN
                    IdPenyaluran.Visible = false; // Disable update for API request
                else
                    IdPenyaluran.SetFormValue(val);
            }

            // Check field name 'TanggalSandar' before field var 'x_TanggalSandar'
            val = CurrentForm.HasValue("TanggalSandar") ? CurrentForm.GetValue("TanggalSandar") : CurrentForm.GetValue("x_TanggalSandar");
            if (!TanggalSandar.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalSandar") && !CurrentForm.HasValue("x_TanggalSandar")) // DN
                    TanggalSandar.Visible = false; // Disable update for API request
                else
                    TanggalSandar.SetFormValue(val, true, validate);
                TanggalSandar.CurrentValue = UnformatDateTime(TanggalSandar.CurrentValue, TanggalSandar.FormatPattern);
            }

            // Check field name 'IdDermaga' before field var 'x_IdDermaga'
            val = CurrentForm.HasValue("IdDermaga") ? CurrentForm.GetValue("IdDermaga") : CurrentForm.GetValue("x_IdDermaga");
            if (!IdDermaga.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdDermaga") && !CurrentForm.HasValue("x_IdDermaga")) // DN
                    IdDermaga.Visible = false; // Disable update for API request
                else
                    IdDermaga.SetFormValue(val);
            }

            // Check field name 'StatusProses' before field var 'x_StatusProses'
            val = CurrentForm.HasValue("StatusProses") ? CurrentForm.GetValue("StatusProses") : CurrentForm.GetValue("x_StatusProses");
            if (!StatusProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusProses") && !CurrentForm.HasValue("x_StatusProses")) // DN
                    StatusProses.Visible = false; // Disable update for API request
                else
                    StatusProses.SetFormValue(val);
            }

            // Check field name 'PersentaseProgress' before field var 'x_PersentaseProgress'
            val = CurrentForm.HasValue("PersentaseProgress") ? CurrentForm.GetValue("PersentaseProgress") : CurrentForm.GetValue("x_PersentaseProgress");
            if (!PersentaseProgress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PersentaseProgress") && !CurrentForm.HasValue("x_PersentaseProgress")) // DN
                    PersentaseProgress.Visible = false; // Disable update for API request
                else
                    PersentaseProgress.SetFormValue(val);
            }

            // Check field name 'IdTemplate' before field var 'x_IdTemplate'
            val = CurrentForm.HasValue("IdTemplate") ? CurrentForm.GetValue("IdTemplate") : CurrentForm.GetValue("x_IdTemplate");
            if (!IdTemplate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTemplate") && !CurrentForm.HasValue("x_IdTemplate")) // DN
                    IdTemplate.Visible = false; // Disable update for API request
                else
                    IdTemplate.SetFormValue(val);
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

            // Check field name 'DiperbaruiOleh' before field var 'x_DiperbaruiOleh'
            val = CurrentForm.HasValue("DiperbaruiOleh") ? CurrentForm.GetValue("DiperbaruiOleh") : CurrentForm.GetValue("x_DiperbaruiOleh");
            if (!DiperbaruiOleh.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DiperbaruiOleh") && !CurrentForm.HasValue("x_DiperbaruiOleh")) // DN
                    DiperbaruiOleh.Visible = false; // Disable update for API request
                else
                    DiperbaruiOleh.SetFormValue(val);
            }

            // Check field name 'TanggalDiperbarui' before field var 'x_TanggalDiperbarui'
            val = CurrentForm.HasValue("TanggalDiperbarui") ? CurrentForm.GetValue("TanggalDiperbarui") : CurrentForm.GetValue("x_TanggalDiperbarui");
            if (!TanggalDiperbarui.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalDiperbarui") && !CurrentForm.HasValue("x_TanggalDiperbarui")) // DN
                    TanggalDiperbarui.Visible = false; // Disable update for API request
                else
                    TanggalDiperbarui.SetFormValue(val);
                TanggalDiperbarui.CurrentValue = UnformatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
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

            // Check field name 'IdPenerimaan' before field var 'x_IdPenerimaan'
            val = CurrentForm.HasValue("IdPenerimaan") ? CurrentForm.GetValue("IdPenerimaan") : CurrentForm.GetValue("x_IdPenerimaan");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            NomorVoyage.CurrentValue = NomorVoyage.FormValue;
            NomorPengiriman.CurrentValue = NomorPengiriman.FormValue;
            LookupPlant.CurrentValue = LookupPlant.FormValue;
            IdPlant.CurrentValue = IdPlant.FormValue;
            TipeProdukSTS.CurrentValue = TipeProdukSTS.FormValue;
            KodeProduk.CurrentValue = KodeProduk.FormValue;
            ModaTransportasi.CurrentValue = ModaTransportasi.FormValue;
            NamaKapal.CurrentValue = NamaKapal.FormValue;
            Refinery.CurrentValue = Refinery.FormValue;
            IdPenyaluran.CurrentValue = IdPenyaluran.FormValue;
            TanggalSandar.CurrentValue = TanggalSandar.FormValue;
            TanggalSandar.CurrentValue = UnformatDateTime(TanggalSandar.CurrentValue, TanggalSandar.FormatPattern);
            IdDermaga.CurrentValue = IdDermaga.FormValue;
            StatusProses.CurrentValue = StatusProses.FormValue;
            PersentaseProgress.CurrentValue = PersentaseProgress.FormValue;
            IdTemplate.CurrentValue = IdTemplate.FormValue;
            Catatan.CurrentValue = Catatan.FormValue;
            DibuatOleh.CurrentValue = DibuatOleh.FormValue;
            TanggalDibuat.CurrentValue = TanggalDibuat.FormValue;
            TanggalDibuat.CurrentValue = UnformatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            DiperbaruiOleh.CurrentValue = DiperbaruiOleh.FormValue;
            TanggalDiperbarui.CurrentValue = TanggalDiperbarui.FormValue;
            TanggalDiperbarui.CurrentValue = UnformatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
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
            IdPenerimaan.SetDbValue(row["IdPenerimaan"]);
            NomorPenerimaan.SetDbValue(row["NomorPenerimaan"]);
            Proses2.SetDbValue(row["Proses"]);
            NomorVoyage.SetDbValue(row["NomorVoyage"]);
            NomorPengiriman.SetDbValue(row["NomorPengiriman"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            KodeProduk.SetDbValue(row["KodeProduk"]);
            ModaTransportasi.SetDbValue(row["ModaTransportasi"]);
            NamaKapal.SetDbValue(row["NamaKapal"]);
            DetailRTW.SetDbValue(row["DetailRTW"]);
            Refinery.SetDbValue((ConvertToBool(row["Refinery"]) ? "1" : "0"));
            IdPenyaluran.SetDbValue(row["IdPenyaluran"]);
            PenyaluranLookup.SetDbValue(row["PenyaluranLookup"]);
            TanggalSandar.SetDbValue(row["TanggalSandar"]);
            IdDermaga.SetDbValue(row["IdDermaga"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            IdTemplate.SetDbValue(row["IdTemplate"]);
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
            row.Add("IdPenerimaan", IdPenerimaan.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPenerimaan", NomorPenerimaan.DefaultValue ?? DbNullValue); // DN
            row.Add("Proses", Proses2.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorVoyage", NomorVoyage.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPengiriman", NomorPengiriman.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("KodeProduk", KodeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("ModaTransportasi", ModaTransportasi.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaKapal", NamaKapal.DefaultValue ?? DbNullValue); // DN
            row.Add("DetailRTW", DetailRTW.DefaultValue ?? DbNullValue); // DN
            row.Add("Refinery", Refinery.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPenyaluran", IdPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("PenyaluranLookup", PenyaluranLookup.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalSandar", TanggalSandar.DefaultValue ?? DbNullValue); // DN
            row.Add("IdDermaga", IdDermaga.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
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

            // IdPenerimaan
            IdPenerimaan.RowCssClass = "row";

            // NomorPenerimaan
            NomorPenerimaan.RowCssClass = "row";

            // Proses
            Proses2.RowCssClass = "row";

            // NomorVoyage
            NomorVoyage.RowCssClass = "row";

            // NomorPengiriman
            NomorPengiriman.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // KodeProduk
            KodeProduk.RowCssClass = "row";

            // ModaTransportasi
            ModaTransportasi.RowCssClass = "row";

            // NamaKapal
            NamaKapal.RowCssClass = "row";

            // DetailRTW
            DetailRTW.RowCssClass = "row";

            // Refinery
            Refinery.RowCssClass = "row";

            // IdPenyaluran
            IdPenyaluran.RowCssClass = "row";

            // PenyaluranLookup
            PenyaluranLookup.RowCssClass = "row";

            // TanggalSandar
            TanggalSandar.RowCssClass = "row";

            // IdDermaga
            IdDermaga.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

            // PersentaseProgress
            PersentaseProgress.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

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
                // Proses
                Proses2.ViewValue = ConvertToString(Proses2.CurrentValue); // DN
                Proses2.ViewCustomAttributes = "";

                // NomorVoyage
                NomorVoyage.ViewValue = ConvertToString(NomorVoyage.CurrentValue); // DN
                NomorVoyage.ViewCustomAttributes = "";

                // NomorPengiriman
                NomorPengiriman.ViewValue = ConvertToString(NomorPengiriman.CurrentValue); // DN
                NomorPengiriman.ViewCustomAttributes = "";

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

                // KodeProduk
                string curVal4 = ConvertToString(KodeProduk.CurrentValue);
                if (!Empty(curVal4)) {
                    if (KodeProduk.Lookup != null && IsDictionary(KodeProduk.Lookup?.Options) && KodeProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        KodeProduk.ViewValue = KodeProduk.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", KodeProduk.CurrentValue, KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                        string? sqlWrk4 = KodeProduk.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && KodeProduk.Lookup != null) { // Lookup values found
                            var listwrk = KodeProduk.Lookup?.RenderViewRow(rswrk4[0]);
                            KodeProduk.ViewValue = KodeProduk.DisplayValue(listwrk);
                        } else {
                            KodeProduk.ViewValue = KodeProduk.CurrentValue;
                        }
                    }
                } else {
                    KodeProduk.ViewValue = DbNullValue;
                }
                KodeProduk.ViewCustomAttributes = "";

                // ModaTransportasi
                string curVal5 = ConvertToString(ModaTransportasi.CurrentValue);
                if (!Empty(curVal5)) {
                    if (ModaTransportasi.Lookup != null && IsDictionary(ModaTransportasi.Lookup?.Options) && ModaTransportasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        ModaTransportasi.ViewValue = ModaTransportasi.LookupCacheOption(curVal5);
                    } else { // Lookup from database // DN
                        string filterWrk5 = SearchFilter(ModaTransportasi.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", ModaTransportasi.CurrentValue, ModaTransportasi.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                        string? sqlWrk5 = ModaTransportasi.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk5?.Count > 0 && ModaTransportasi.Lookup != null) { // Lookup values found
                            var listwrk = ModaTransportasi.Lookup?.RenderViewRow(rswrk5[0]);
                            ModaTransportasi.ViewValue = ModaTransportasi.DisplayValue(listwrk);
                        } else {
                            ModaTransportasi.ViewValue = ModaTransportasi.CurrentValue;
                        }
                    }
                } else {
                    ModaTransportasi.ViewValue = DbNullValue;
                }
                ModaTransportasi.ViewCustomAttributes = "";

                // NamaKapal
                NamaKapal.ViewValue = ConvertToString(NamaKapal.CurrentValue); // DN
                NamaKapal.ViewCustomAttributes = "";

                // Refinery
                if (ConvertToBool(Refinery.CurrentValue)) {
                    Refinery.ViewValue = Refinery.TagCaption(1) != "" ? Refinery.TagCaption(1) : "Yes";
                } else {
                    Refinery.ViewValue = Refinery.TagCaption(2) != "" ? Refinery.TagCaption(2) : "No";
                }
                Refinery.ViewCustomAttributes = "";

                // IdPenyaluran
                if (!Empty(IdPenyaluran.CurrentValue)) {
                    IdPenyaluran.ViewValue = IdPenyaluran.OptionCaption(ConvertToString(IdPenyaluran.CurrentValue));
                } else {
                    IdPenyaluran.ViewValue = DbNullValue;
                }
                IdPenyaluran.ViewCustomAttributes = "";

                // PenyaluranLookup
                PenyaluranLookup.ViewValue = PenyaluranLookup.CurrentValue;
                string curVal8 = ConvertToString(PenyaluranLookup.CurrentValue);
                if (!Empty(curVal8)) {
                    if (PenyaluranLookup.Lookup != null && IsDictionary(PenyaluranLookup.Lookup?.Options) && PenyaluranLookup.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PenyaluranLookup.ViewValue = PenyaluranLookup.LookupCacheOption(curVal8);
                    } else { // Lookup from database // DN
                        string filterWrk8 = SearchFilter(PenyaluranLookup.Lookup?.GetTable()?.Fields["IdPenyaluran"].SearchExpression, "=", PenyaluranLookup.CurrentValue, PenyaluranLookup.Lookup?.GetTable()?.Fields["IdPenyaluran"].SearchDataType, "");
                        string? sqlWrk8 = PenyaluranLookup.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk8?.Count > 0 && PenyaluranLookup.Lookup != null) { // Lookup values found
                            var listwrk = PenyaluranLookup.Lookup?.RenderViewRow(rswrk8[0]);
                            PenyaluranLookup.ViewValue = PenyaluranLookup.DisplayValue(listwrk);
                        } else {
                            PenyaluranLookup.ViewValue = FormatNumber(PenyaluranLookup.CurrentValue, PenyaluranLookup.FormatPattern);
                        }
                    }
                } else {
                    PenyaluranLookup.ViewValue = DbNullValue;
                }
                PenyaluranLookup.ViewCustomAttributes = "";

                // TanggalSandar
                TanggalSandar.ViewValue = TanggalSandar.CurrentValue;
                TanggalSandar.ViewValue = FormatDateTime(TanggalSandar.ViewValue, TanggalSandar.FormatPattern);
                TanggalSandar.ViewCustomAttributes = "";

                // IdDermaga
                string curVal9 = ConvertToString(IdDermaga.CurrentValue);
                if (!Empty(curVal9)) {
                    if (IdDermaga.Lookup != null && IsDictionary(IdDermaga.Lookup?.Options) && IdDermaga.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdDermaga.ViewValue = IdDermaga.LookupCacheOption(curVal9);
                    } else { // Lookup from database // DN
                        string filterWrk9 = SearchFilter(IdDermaga.Lookup?.GetTable()?.Fields["IdDermaga"].SearchExpression, "=", IdDermaga.CurrentValue, IdDermaga.Lookup?.GetTable()?.Fields["IdDermaga"].SearchDataType, "");
                        string? sqlWrk9 = IdDermaga.Lookup?.GetSql(false, filterWrk9, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk9 = sqlWrk9 != null ? Connection.GetRows(sqlWrk9) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk9?.Count > 0 && IdDermaga.Lookup != null) { // Lookup values found
                            var listwrk = IdDermaga.Lookup?.RenderViewRow(rswrk9[0]);
                            IdDermaga.ViewValue = IdDermaga.DisplayValue(listwrk);
                        } else {
                            IdDermaga.ViewValue = FormatNumber(IdDermaga.CurrentValue, IdDermaga.FormatPattern);
                        }
                    }
                } else {
                    IdDermaga.ViewValue = DbNullValue;
                }
                IdDermaga.ViewCustomAttributes = "";

                // StatusProses
                StatusProses.ViewValue = StatusProses.CurrentValue;
                StatusProses.ViewCustomAttributes = "";

                // PersentaseProgress
                PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                PersentaseProgress.ViewCustomAttributes = "";

                // IdTemplate
                IdTemplate.ViewValue = IdTemplate.CurrentValue;
                IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
                IdTemplate.ViewCustomAttributes = "";

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

                // LookupTipeProduk
                LookupTipeProduk.ViewValue = LookupTipeProduk.CurrentValue;
                LookupTipeProduk.ViewCustomAttributes = "";

                // LookupJenisPlant
                LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
                LookupJenisPlant.ViewCustomAttributes = "";

                // NomorVoyage
                NomorVoyage.HrefValue = "";

                // NomorPengiriman
                NomorPengiriman.HrefValue = "";

                // LookupPlant
                LookupPlant.HrefValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // KodeProduk
                KodeProduk.HrefValue = "";
                KodeProduk.TooltipValue = "";

                // ModaTransportasi
                ModaTransportasi.HrefValue = "";
                ModaTransportasi.TooltipValue = "";

                // NamaKapal
                NamaKapal.HrefValue = "";
                NamaKapal.TooltipValue = "";

                // Refinery
                Refinery.HrefValue = "";
                Refinery.TooltipValue = "";

                // IdPenyaluran
                IdPenyaluran.HrefValue = "";
                IdPenyaluran.TooltipValue = "";

                // TanggalSandar
                TanggalSandar.HrefValue = "";
                TanggalSandar.TooltipValue = "";

                // IdDermaga
                IdDermaga.HrefValue = "";
                IdDermaga.TooltipValue = "";

                // StatusProses
                StatusProses.HrefValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";

                // IdTemplate
                IdTemplate.HrefValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";
                LookupTipeProduk.TooltipValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
                LookupJenisPlant.TooltipValue = "";
            } else if (RowType == RowType.Add) {
                // NomorVoyage
                NomorVoyage.SetupEditAttributes();
                if (!NomorVoyage.Raw)
                    NomorVoyage.CurrentValue = HtmlDecode(NomorVoyage.CurrentValue);
                NomorVoyage.EditValue = HtmlEncode(NomorVoyage.CurrentValue);
                NomorVoyage.PlaceHolder = RemoveHtml(NomorVoyage.Caption);

                // NomorPengiriman
                NomorPengiriman.SetupEditAttributes();
                if (!NomorPengiriman.Raw)
                    NomorPengiriman.CurrentValue = HtmlDecode(NomorPengiriman.CurrentValue);
                NomorPengiriman.EditValue = HtmlEncode(NomorPengiriman.CurrentValue);
                NomorPengiriman.PlaceHolder = RemoveHtml(NomorPengiriman.Caption);

                // LookupPlant
                LookupPlant.SetupEditAttributes();
                LookupPlant.EditValue = LookupPlant.Options(true);
                LookupPlant.PlaceHolder = RemoveHtml(LookupPlant.Caption);
                if (!Empty(LookupPlant.EditValue) && IsNumeric(LookupPlant.EditValue))
                    LookupPlant.EditValue = FormatNumber(LookupPlant.EditValue, null);

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
                            IdPlant.EditValue = HtmlEncode(FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern));
                        }
                    }
                } else {
                    IdPlant.EditValue = DbNullValue;
                }
                IdPlant.PlaceHolder = RemoveHtml(IdPlant.Caption);
                if (!Empty(IdPlant.EditValue) && IsNumeric(IdPlant.EditValue))
                    IdPlant.EditValue = FormatNumber(IdPlant.EditValue, null);

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

                // KodeProduk
                KodeProduk.SetupEditAttributes();
                string curVal4 = ConvertToString(KodeProduk.CurrentValue);
                if (KodeProduk.Lookup != null && IsDictionary(KodeProduk.Lookup?.Options) && KodeProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    KodeProduk.EditValue = KodeProduk.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk4 = "";
                    if (curVal4 == "") {
                        filterWrk4 = "0=1";
                    } else {
                        filterWrk4 = SearchFilter(KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", KodeProduk.CurrentValue, KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                    }
                    string? sqlWrk4 = KodeProduk.Lookup?.GetSql(true, filterWrk4, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    KodeProduk.EditValue = rswrk4;
                }
                KodeProduk.PlaceHolder = RemoveHtml(KodeProduk.Caption);

                // ModaTransportasi
                ModaTransportasi.SetupEditAttributes();
                string curVal5 = ConvertToString(ModaTransportasi.CurrentValue);
                if (ModaTransportasi.Lookup != null && IsDictionary(ModaTransportasi.Lookup?.Options) && ModaTransportasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ModaTransportasi.EditValue = ModaTransportasi.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk5 = "";
                    if (curVal5 == "") {
                        filterWrk5 = "0=1";
                    } else {
                        filterWrk5 = SearchFilter(ModaTransportasi.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", ModaTransportasi.CurrentValue, ModaTransportasi.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                    }
                    string? sqlWrk5 = ModaTransportasi.Lookup?.GetSql(true, filterWrk5, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    ModaTransportasi.EditValue = rswrk5;
                }
                ModaTransportasi.PlaceHolder = RemoveHtml(ModaTransportasi.Caption);

                // NamaKapal
                NamaKapal.SetupEditAttributes();
                if (!NamaKapal.Raw)
                    NamaKapal.CurrentValue = HtmlDecode(NamaKapal.CurrentValue);
                NamaKapal.EditValue = HtmlEncode(NamaKapal.CurrentValue);
                NamaKapal.PlaceHolder = RemoveHtml(NamaKapal.Caption);

                // Refinery
                Refinery.EditValue = Refinery.Options(false);
                Refinery.PlaceHolder = RemoveHtml(Refinery.Caption);

                // IdPenyaluran
                IdPenyaluran.SetupEditAttributes();
                IdPenyaluran.EditValue = IdPenyaluran.Options(true);
                IdPenyaluran.PlaceHolder = RemoveHtml(IdPenyaluran.Caption);
                if (!Empty(IdPenyaluran.EditValue) && IsNumeric(IdPenyaluran.EditValue))
                    IdPenyaluran.EditValue = FormatNumber(IdPenyaluran.EditValue, null);

                // TanggalSandar
                TanggalSandar.SetupEditAttributes();
                TanggalSandar.EditValue = FormatDateTime(TanggalSandar.CurrentValue, TanggalSandar.FormatPattern);
                TanggalSandar.PlaceHolder = RemoveHtml(TanggalSandar.Caption);

                // IdDermaga
                IdDermaga.SetupEditAttributes();
                string curVal9 = ConvertToString(IdDermaga.CurrentValue);
                if (IdDermaga.Lookup != null && IsDictionary(IdDermaga.Lookup?.Options) && IdDermaga.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdDermaga.EditValue = IdDermaga.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk9 = "";
                    if (curVal9 == "") {
                        filterWrk9 = "0=1";
                    } else {
                        filterWrk9 = SearchFilter(IdDermaga.Lookup?.GetTable()?.Fields["IdDermaga"].SearchExpression, "=", IdDermaga.CurrentValue, IdDermaga.Lookup?.GetTable()?.Fields["IdDermaga"].SearchDataType, "");
                    }
                    string? sqlWrk9 = IdDermaga.Lookup?.GetSql(true, filterWrk9, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk9 = sqlWrk9 != null ? Connection.GetRows(sqlWrk9) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdDermaga.EditValue = rswrk9;
                }
                IdDermaga.PlaceHolder = RemoveHtml(IdDermaga.Caption);
                if (!Empty(IdDermaga.EditValue) && IsNumeric(IdDermaga.EditValue))
                    IdDermaga.EditValue = FormatNumber(IdDermaga.EditValue, null);

                // StatusProses
                StatusProses.SetupEditAttributes();
                StatusProses.CurrentValue = StatusProses.GetDefault();

                // PersentaseProgress
                PersentaseProgress.SetupEditAttributes();
                PersentaseProgress.CurrentValue = FormatPercent(PersentaseProgress.GetDefault(), PersentaseProgress.FormatPattern);

                // IdTemplate
                IdTemplate.SetupEditAttributes();
                IdTemplate.CurrentValue = FormatNumber(IdTemplate.GetDefault(), IdTemplate.FormatPattern);
                if (!Empty(IdTemplate.EditValue) && IsNumeric(IdTemplate.EditValue))
                    IdTemplate.EditValue = FormatNumber(IdTemplate.EditValue, null);

                // Catatan
                Catatan.SetupEditAttributes();
                Catatan.EditValue = Catatan.CurrentValue; // DN
                Catatan.PlaceHolder = RemoveHtml(Catatan.Caption);

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

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

                // NomorVoyage
                NomorVoyage.HrefValue = "";

                // NomorPengiriman
                NomorPengiriman.HrefValue = "";

                // LookupPlant
                LookupPlant.HrefValue = "";

                // IdPlant
                IdPlant.HrefValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";

                // KodeProduk
                KodeProduk.HrefValue = "";

                // ModaTransportasi
                ModaTransportasi.HrefValue = "";

                // NamaKapal
                NamaKapal.HrefValue = "";

                // Refinery
                Refinery.HrefValue = "";

                // IdPenyaluran
                IdPenyaluran.HrefValue = "";

                // TanggalSandar
                TanggalSandar.HrefValue = "";

                // IdDermaga
                IdDermaga.HrefValue = "";

                // StatusProses
                StatusProses.HrefValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";

                // IdTemplate
                IdTemplate.HrefValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";

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
                if (NomorVoyage.Visible && NomorVoyage.Required) {
                    if (!NomorVoyage.IsDetailKey && Empty(NomorVoyage.FormValue)) {
                        NomorVoyage.AddErrorMessage(ConvertToString(NomorVoyage.RequiredErrorMessage).Replace("%s", NomorVoyage.Caption));
                    }
                }
                if (NomorPengiriman.Visible && NomorPengiriman.Required) {
                    if (!NomorPengiriman.IsDetailKey && Empty(NomorPengiriman.FormValue)) {
                        NomorPengiriman.AddErrorMessage(ConvertToString(NomorPengiriman.RequiredErrorMessage).Replace("%s", NomorPengiriman.Caption));
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
                if (!CheckInteger(IdPlant.FormValue)) {
                    IdPlant.AddErrorMessage(IdPlant.GetErrorMessage(false));
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
                if (ModaTransportasi.Visible && ModaTransportasi.Required) {
                    if (!ModaTransportasi.IsDetailKey && Empty(ModaTransportasi.FormValue)) {
                        ModaTransportasi.AddErrorMessage(ConvertToString(ModaTransportasi.RequiredErrorMessage).Replace("%s", ModaTransportasi.Caption));
                    }
                }
                if (NamaKapal.Visible && NamaKapal.Required) {
                    if (!NamaKapal.IsDetailKey && Empty(NamaKapal.FormValue)) {
                        NamaKapal.AddErrorMessage(ConvertToString(NamaKapal.RequiredErrorMessage).Replace("%s", NamaKapal.Caption));
                    }
                }
                if (Refinery.Visible && Refinery.Required) {
                    if (Empty(Refinery.FormValue)) {
                        Refinery.AddErrorMessage(ConvertToString(Refinery.RequiredErrorMessage).Replace("%s", Refinery.Caption));
                    }
                }
                if (IdPenyaluran.Visible && IdPenyaluran.Required) {
                    if (!IdPenyaluran.IsDetailKey && Empty(IdPenyaluran.FormValue)) {
                        IdPenyaluran.AddErrorMessage(ConvertToString(IdPenyaluran.RequiredErrorMessage).Replace("%s", IdPenyaluran.Caption));
                    }
                }
                if (TanggalSandar.Visible && TanggalSandar.Required) {
                    if (!TanggalSandar.IsDetailKey && Empty(TanggalSandar.FormValue)) {
                        TanggalSandar.AddErrorMessage(ConvertToString(TanggalSandar.RequiredErrorMessage).Replace("%s", TanggalSandar.Caption));
                    }
                }
                if (!CheckDate(TanggalSandar.FormValue, TanggalSandar.FormatPattern)) {
                    TanggalSandar.AddErrorMessage(TanggalSandar.GetErrorMessage(false));
                }
                if (IdDermaga.Visible && IdDermaga.Required) {
                    if (!IdDermaga.IsDetailKey && Empty(IdDermaga.FormValue)) {
                        IdDermaga.AddErrorMessage(ConvertToString(IdDermaga.RequiredErrorMessage).Replace("%s", IdDermaga.Caption));
                    }
                }
                if (StatusProses.Visible && StatusProses.Required) {
                    if (!StatusProses.IsDetailKey && Empty(StatusProses.FormValue)) {
                        StatusProses.AddErrorMessage(ConvertToString(StatusProses.RequiredErrorMessage).Replace("%s", StatusProses.Caption));
                    }
                }
                if (PersentaseProgress.Visible && PersentaseProgress.Required) {
                    if (!PersentaseProgress.IsDetailKey && Empty(PersentaseProgress.FormValue)) {
                        PersentaseProgress.AddErrorMessage(ConvertToString(PersentaseProgress.RequiredErrorMessage).Replace("%s", PersentaseProgress.Caption));
                    }
                }
                if (IdTemplate.Visible && IdTemplate.Required) {
                    if (!IdTemplate.IsDetailKey && Empty(IdTemplate.FormValue)) {
                        IdTemplate.AddErrorMessage(ConvertToString(IdTemplate.RequiredErrorMessage).Replace("%s", IdTemplate.Caption));
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
                if (DiperbaruiOleh.Visible && DiperbaruiOleh.Required) {
                    if (!DiperbaruiOleh.IsDetailKey && Empty(DiperbaruiOleh.FormValue)) {
                        DiperbaruiOleh.AddErrorMessage(ConvertToString(DiperbaruiOleh.RequiredErrorMessage).Replace("%s", DiperbaruiOleh.Caption));
                    }
                }
                if (TanggalDiperbarui.Visible && TanggalDiperbarui.Required) {
                    if (!TanggalDiperbarui.IsDetailKey && Empty(TanggalDiperbarui.FormValue)) {
                        TanggalDiperbarui.AddErrorMessage(ConvertToString(TanggalDiperbarui.RequiredErrorMessage).Replace("%s", TanggalDiperbarui.Caption));
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
                    rsnew["IdPenerimaan"] = IdPenerimaan.CurrentValue!;
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

                // NomorVoyage
                NomorVoyage.SetDbValue(rsnew, NomorVoyage.CurrentValue);

                // NomorPengiriman
                NomorPengiriman.SetDbValue(rsnew, NomorPengiriman.CurrentValue);

                // LookupPlant
                LookupPlant.SetDbValue(rsnew, LookupPlant.CurrentValue);

                // IdPlant
                IdPlant.SetDbValue(rsnew, IdPlant.CurrentValue);

                // TipeProdukSTS
                TipeProdukSTS.SetDbValue(rsnew, TipeProdukSTS.CurrentValue);

                // KodeProduk
                KodeProduk.SetDbValue(rsnew, KodeProduk.CurrentValue);

                // ModaTransportasi
                ModaTransportasi.SetDbValue(rsnew, ModaTransportasi.CurrentValue);

                // NamaKapal
                NamaKapal.SetDbValue(rsnew, NamaKapal.CurrentValue);

                // Refinery
                Refinery.SetDbValue(rsnew, ConvertToBool(Refinery.CurrentValue));

                // IdPenyaluran
                IdPenyaluran.SetDbValue(rsnew, IdPenyaluran.CurrentValue);

                // TanggalSandar
                TanggalSandar.SetDbValue(rsnew, ConvertToDateTime(TanggalSandar.CurrentValue, TanggalSandar.FormatPattern));

                // IdDermaga
                IdDermaga.SetDbValue(rsnew, IdDermaga.CurrentValue);

                // StatusProses
                StatusProses.SetDbValue(rsnew, StatusProses.CurrentValue);

                // PersentaseProgress
                PersentaseProgress.SetDbValue(rsnew, PersentaseProgress.CurrentValue);

                // IdTemplate
                IdTemplate.SetDbValue(rsnew, IdTemplate.CurrentValue);

                // Catatan
                Catatan.SetDbValue(rsnew, Catatan.CurrentValue);

                // DibuatOleh
                DibuatOleh.CurrentValue = DibuatOleh.GetAutoUpdateValue();
                DibuatOleh.SetDbValue(rsnew, DibuatOleh.CurrentValue);

                // TanggalDibuat
                TanggalDibuat.CurrentValue = TanggalDibuat.GetAutoUpdateValue();
                TanggalDibuat.SetDbValue(rsnew, ConvertToDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern), Empty(TanggalDibuat.CurrentValue));

                // DiperbaruiOleh
                DiperbaruiOleh.CurrentValue = DiperbaruiOleh.GetAutoUpdateValue();
                DiperbaruiOleh.SetDbValue(rsnew, DiperbaruiOleh.CurrentValue);

                // TanggalDiperbarui
                TanggalDiperbarui.CurrentValue = TanggalDiperbarui.GetAutoUpdateValue();
                TanggalDiperbarui.SetDbValue(rsnew, ConvertToDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern));

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
            if (row.TryGetValue("NomorVoyage", out value)) // NomorVoyage
                NomorVoyage.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NomorPengiriman", out value)) // NomorPengiriman
                NomorPengiriman.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupPlant", out value)) // LookupPlant
                LookupPlant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdPlant", out value)) // IdPlant
                IdPlant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TipeProdukSTS", out value)) // TipeProdukSTS
                TipeProdukSTS.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("KodeProduk", out value)) // KodeProduk
                KodeProduk.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("ModaTransportasi", out value)) // ModaTransportasi
                ModaTransportasi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NamaKapal", out value)) // NamaKapal
                NamaKapal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Refinery", out value)) // Refinery
                Refinery.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdPenyaluran", out value)) // IdPenyaluran
                IdPenyaluran.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalSandar", out value)) // TanggalSandar
                TanggalSandar.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdDermaga", out value)) // IdDermaga
                IdDermaga.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusProses", out value)) // StatusProses
                StatusProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PersentaseProgress", out value)) // PersentaseProgress
                PersentaseProgress.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdTemplate", out value)) // IdTemplate
                IdTemplate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Catatan", out value)) // Catatan
                Catatan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DibuatOleh", out value)) // DibuatOleh
                DibuatOleh.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalDibuat", out value)) // TanggalDibuat
                TanggalDibuat.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DiperbaruiOleh", out value)) // DiperbaruiOleh
                DiperbaruiOleh.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalDiperbarui", out value)) // TanggalDiperbarui
                TanggalDiperbarui.SetFormValue(ConvertToString(value));
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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("PenerimaanList")), "", TableVar, true);
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
