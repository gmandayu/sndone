namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// bukuTamuAdd
    /// </summary>
    public static BukuTamuAdd bukuTamuAdd
    {
        get => HttpData.Get<BukuTamuAdd>("bukuTamuAdd")!;
        set => HttpData["bukuTamuAdd"] = value;
    }

    /// <summary>
    /// Page class for BukuTamu
    /// </summary>
    public class BukuTamuAdd : BukuTamuAddBase
    {
        // Constructor
        public BukuTamuAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public BukuTamuAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class BukuTamuAddBase : BukuTamu
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "bukuTamuAdd";

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
        public BukuTamuAddBase()
        {
            TableName = "BukuTamu";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (bukuTamu)
            if (bukuTamu == null || bukuTamu is BukuTamu)
                bukuTamu = this;

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
        public string PageName => "BukuTamuAdd";

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
            NomorBukuTamu.Visible = false;
            LinkRedirect.Visible = false;
            LookupPlant.SetVisibility();
            Plant.SetVisibility();
            Tanggal.SetVisibility();
            StatusZona.SetVisibility();
            Nama.SetVisibility();
            AsalPerusahaan.SetVisibility();
            Jabatan.SetVisibility();
            FungsiygDikunjungi.SetVisibility();
            MaksudKunjungan.SetVisibility();
            TandaPengenal.SetVisibility();
            TandaTangan.SetVisibility();
            TandaTanganDownload.SetVisibility();
            Keterangan.SetVisibility();
            PintuUtamaId.SetVisibility();
            PintuUtamaInTanggal.SetVisibility();
            PintuUtamaInFoto.SetVisibility();
            PintuUtamaInFotoDownload.SetVisibility();
            PintuUtamaInUser.Visible = false;
            CustomPilihPintu.Visible = false;
            PintuUtamaOutTanggal.Visible = false;
            PintuUtamaOutFoto.Visible = false;
            PintuUtamaOutFotoDownload.Visible = false;
            PintuUtamaOutUser.Visible = false;
            LobbyUtamaId.Visible = false;
            LobbyUtamaInTanggal.Visible = false;
            LobbyUtamaInFoto.Visible = false;
            LobbyUtamaInFotoDownload.Visible = false;
            LobbyUtamaInUser.Visible = false;
            LobbyUtamaOutTanggal.Visible = false;
            LobbyUtamaOutFoto.Visible = false;
            LobbyUtamaOutFotoDownload.Visible = false;
            LobbyUtamaOutUser.Visible = false;
            AreaTerlarangId.Visible = false;
            AreaTerlarangInTanggal.Visible = false;
            AreaTerlarangInFoto.Visible = false;
            AreaTerlarangInFotoDownload.Visible = false;
            AreaTerlarangInUser.Visible = false;
            AreaTerlarangOutTanggal.Visible = false;
            AreaTerlarangOutFoto.Visible = false;
            AreaTerlarangOutFotoDownload.Visible = false;
            AreaTerlarangOutUser.Visible = false;
            etlDate.Visible = false;
            LastUpdatedBy.Visible = false;
            lastUpdatedDate.Visible = false;
            StatusZonaPrev.SetVisibility();
        }

        // Constructor
        public BukuTamuAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "BukuTamuView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(FungsiygDikunjungi);
            await SetupLookupOptions(TandaPengenal);

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
                        return Terminate("BukuTamuList"); // No matching record, return to List page // DN
                    }
                    break;
                case "insert": // Add new record // DN
                    SendEmail = true; // Send email on add success
                    var res = await AddRow(rsold);
                    if (res) { // Add successful
                        if (Empty(SuccessMessage) && Post("addopt") != "1") // Skip success message for addopt (done in JavaScript)
                            SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
                        string returnUrl = "";
                        returnUrl = "BukuTamuList";
                        if (GetPageName(returnUrl) == "BukuTamuList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "BukuTamuView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "BukuTamuList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "BukuTamuList"; // Return list page content
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
                bukuTamuAdd?.PageRender();
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

            // Check field name 'Tanggal' before field var 'x_Tanggal'
            val = CurrentForm.HasValue("Tanggal") ? CurrentForm.GetValue("Tanggal") : CurrentForm.GetValue("x_Tanggal");
            if (!Tanggal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Tanggal") && !CurrentForm.HasValue("x_Tanggal")) // DN
                    Tanggal.Visible = false; // Disable update for API request
                else
                    Tanggal.SetFormValue(val, true, validate);
                Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            }

            // Check field name 'StatusZona' before field var 'x_StatusZona'
            val = CurrentForm.HasValue("StatusZona") ? CurrentForm.GetValue("StatusZona") : CurrentForm.GetValue("x_StatusZona");
            if (!StatusZona.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusZona") && !CurrentForm.HasValue("x_StatusZona")) // DN
                    StatusZona.Visible = false; // Disable update for API request
                else
                    StatusZona.SetFormValue(val);
            }

            // Check field name 'Nama' before field var 'x_Nama'
            val = CurrentForm.HasValue("Nama") ? CurrentForm.GetValue("Nama") : CurrentForm.GetValue("x_Nama");
            if (!Nama.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Nama") && !CurrentForm.HasValue("x_Nama")) // DN
                    Nama.Visible = false; // Disable update for API request
                else
                    Nama.SetFormValue(val);
            }

            // Check field name 'AsalPerusahaan' before field var 'x_AsalPerusahaan'
            val = CurrentForm.HasValue("AsalPerusahaan") ? CurrentForm.GetValue("AsalPerusahaan") : CurrentForm.GetValue("x_AsalPerusahaan");
            if (!AsalPerusahaan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AsalPerusahaan") && !CurrentForm.HasValue("x_AsalPerusahaan")) // DN
                    AsalPerusahaan.Visible = false; // Disable update for API request
                else
                    AsalPerusahaan.SetFormValue(val);
            }

            // Check field name 'Jabatan' before field var 'x_Jabatan'
            val = CurrentForm.HasValue("Jabatan") ? CurrentForm.GetValue("Jabatan") : CurrentForm.GetValue("x_Jabatan");
            if (!Jabatan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Jabatan") && !CurrentForm.HasValue("x_Jabatan")) // DN
                    Jabatan.Visible = false; // Disable update for API request
                else
                    Jabatan.SetFormValue(val);
            }

            // Check field name 'FungsiygDikunjungi' before field var 'x_FungsiygDikunjungi'
            val = CurrentForm.HasValue("FungsiygDikunjungi") ? CurrentForm.GetValue("FungsiygDikunjungi") : CurrentForm.GetValue("x_FungsiygDikunjungi");
            if (!FungsiygDikunjungi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FungsiygDikunjungi") && !CurrentForm.HasValue("x_FungsiygDikunjungi")) // DN
                    FungsiygDikunjungi.Visible = false; // Disable update for API request
                else
                    FungsiygDikunjungi.SetFormValue(val);
            }

            // Check field name 'MaksudKunjungan' before field var 'x_MaksudKunjungan'
            val = CurrentForm.HasValue("MaksudKunjungan") ? CurrentForm.GetValue("MaksudKunjungan") : CurrentForm.GetValue("x_MaksudKunjungan");
            if (!MaksudKunjungan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MaksudKunjungan") && !CurrentForm.HasValue("x_MaksudKunjungan")) // DN
                    MaksudKunjungan.Visible = false; // Disable update for API request
                else
                    MaksudKunjungan.SetFormValue(val);
            }

            // Check field name 'TandaPengenal' before field var 'x_TandaPengenal'
            val = CurrentForm.HasValue("TandaPengenal") ? CurrentForm.GetValue("TandaPengenal") : CurrentForm.GetValue("x_TandaPengenal");
            if (!TandaPengenal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TandaPengenal") && !CurrentForm.HasValue("x_TandaPengenal")) // DN
                    TandaPengenal.Visible = false; // Disable update for API request
                else
                    TandaPengenal.SetFormValue(val);
            }

            // Check field name 'TandaTangan' before field var 'x_TandaTangan'
            val = CurrentForm.HasValue("TandaTangan") ? CurrentForm.GetValue("TandaTangan") : CurrentForm.GetValue("x_TandaTangan");
            if (!TandaTangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TandaTangan") && !CurrentForm.HasValue("x_TandaTangan")) // DN
                    TandaTangan.Visible = false; // Disable update for API request
                else
                    TandaTangan.SetFormValue(val);
            }

            // Check field name 'TandaTanganDownload' before field var 'x_TandaTanganDownload'
            val = CurrentForm.HasValue("TandaTanganDownload") ? CurrentForm.GetValue("TandaTanganDownload") : CurrentForm.GetValue("x_TandaTanganDownload");
            if (!TandaTanganDownload.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TandaTanganDownload") && !CurrentForm.HasValue("x_TandaTanganDownload")) // DN
                    TandaTanganDownload.Visible = false; // Disable update for API request
                else
                    TandaTanganDownload.SetFormValue(val);
            }

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }

            // Check field name 'PintuUtamaId' before field var 'x_PintuUtamaId'
            val = CurrentForm.HasValue("PintuUtamaId") ? CurrentForm.GetValue("PintuUtamaId") : CurrentForm.GetValue("x_PintuUtamaId");
            if (!PintuUtamaId.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PintuUtamaId") && !CurrentForm.HasValue("x_PintuUtamaId")) // DN
                    PintuUtamaId.Visible = false; // Disable update for API request
                else
                    PintuUtamaId.SetFormValue(val, true, validate);
            }

            // Check field name 'PintuUtamaInTanggal' before field var 'x_PintuUtamaInTanggal'
            val = CurrentForm.HasValue("PintuUtamaInTanggal") ? CurrentForm.GetValue("PintuUtamaInTanggal") : CurrentForm.GetValue("x_PintuUtamaInTanggal");
            if (!PintuUtamaInTanggal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PintuUtamaInTanggal") && !CurrentForm.HasValue("x_PintuUtamaInTanggal")) // DN
                    PintuUtamaInTanggal.Visible = false; // Disable update for API request
                else
                    PintuUtamaInTanggal.SetFormValue(val, true, validate);
                PintuUtamaInTanggal.CurrentValue = UnformatDateTime(PintuUtamaInTanggal.CurrentValue, PintuUtamaInTanggal.FormatPattern);
            }

            // Check field name 'PintuUtamaInFoto' before field var 'x_PintuUtamaInFoto'
            val = CurrentForm.HasValue("PintuUtamaInFoto") ? CurrentForm.GetValue("PintuUtamaInFoto") : CurrentForm.GetValue("x_PintuUtamaInFoto");
            if (!PintuUtamaInFoto.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PintuUtamaInFoto") && !CurrentForm.HasValue("x_PintuUtamaInFoto")) // DN
                    PintuUtamaInFoto.Visible = false; // Disable update for API request
                else
                    PintuUtamaInFoto.SetFormValue(val);
            }

            // Check field name 'PintuUtamaInFotoDownload' before field var 'x_PintuUtamaInFotoDownload'
            val = CurrentForm.HasValue("PintuUtamaInFotoDownload") ? CurrentForm.GetValue("PintuUtamaInFotoDownload") : CurrentForm.GetValue("x_PintuUtamaInFotoDownload");
            if (!PintuUtamaInFotoDownload.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PintuUtamaInFotoDownload") && !CurrentForm.HasValue("x_PintuUtamaInFotoDownload")) // DN
                    PintuUtamaInFotoDownload.Visible = false; // Disable update for API request
                else
                    PintuUtamaInFotoDownload.SetFormValue(val);
            }

            // Check field name 'StatusZonaPrev' before field var 'x_StatusZonaPrev'
            val = CurrentForm.HasValue("StatusZonaPrev") ? CurrentForm.GetValue("StatusZonaPrev") : CurrentForm.GetValue("x_StatusZonaPrev");
            if (!StatusZonaPrev.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusZonaPrev") && !CurrentForm.HasValue("x_StatusZonaPrev")) // DN
                    StatusZonaPrev.Visible = false; // Disable update for API request
                else
                    StatusZonaPrev.SetFormValue(val);
            }

            // Check field name 'id' before field var 'x_id'
            val = CurrentForm.HasValue("id") ? CurrentForm.GetValue("id") : CurrentForm.GetValue("x_id");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            LookupPlant.CurrentValue = LookupPlant.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            Tanggal.CurrentValue = Tanggal.FormValue;
            Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            StatusZona.CurrentValue = StatusZona.FormValue;
            Nama.CurrentValue = Nama.FormValue;
            AsalPerusahaan.CurrentValue = AsalPerusahaan.FormValue;
            Jabatan.CurrentValue = Jabatan.FormValue;
            FungsiygDikunjungi.CurrentValue = FungsiygDikunjungi.FormValue;
            MaksudKunjungan.CurrentValue = MaksudKunjungan.FormValue;
            TandaPengenal.CurrentValue = TandaPengenal.FormValue;
            TandaTangan.CurrentValue = TandaTangan.FormValue;
            TandaTanganDownload.CurrentValue = TandaTanganDownload.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            PintuUtamaId.CurrentValue = PintuUtamaId.FormValue;
            PintuUtamaInTanggal.CurrentValue = PintuUtamaInTanggal.FormValue;
            PintuUtamaInTanggal.CurrentValue = UnformatDateTime(PintuUtamaInTanggal.CurrentValue, PintuUtamaInTanggal.FormatPattern);
            PintuUtamaInFoto.CurrentValue = PintuUtamaInFoto.FormValue;
            PintuUtamaInFotoDownload.CurrentValue = PintuUtamaInFotoDownload.FormValue;
            StatusZonaPrev.CurrentValue = StatusZonaPrev.FormValue;
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
            NomorBukuTamu.SetDbValue(row["NomorBukuTamu"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            Plant.SetDbValue(row["Plant"]);
            Tanggal.SetDbValue(row["Tanggal"]);
            StatusZona.SetDbValue(row["StatusZona"]);
            Nama.SetDbValue(row["Nama"]);
            AsalPerusahaan.SetDbValue(row["AsalPerusahaan"]);
            Jabatan.SetDbValue(row["Jabatan"]);
            FungsiygDikunjungi.SetDbValue(row["FungsiygDikunjungi"]);
            MaksudKunjungan.SetDbValue(row["MaksudKunjungan"]);
            TandaPengenal.SetDbValue(row["TandaPengenal"]);
            TandaTangan.SetDbValue(row["TandaTangan"]);
            TandaTanganDownload.SetDbValue(row["TandaTanganDownload"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            PintuUtamaId.SetDbValue(row["PintuUtamaId"]);
            PintuUtamaInTanggal.SetDbValue(row["PintuUtamaInTanggal"]);
            PintuUtamaInFoto.SetDbValue(row["PintuUtamaInFoto"]);
            PintuUtamaInFotoDownload.SetDbValue(row["PintuUtamaInFotoDownload"]);
            PintuUtamaInUser.SetDbValue(row["PintuUtamaInUser"]);
            CustomPilihPintu.SetDbValue(row["CustomPilihPintu"]);
            PintuUtamaOutTanggal.SetDbValue(row["PintuUtamaOutTanggal"]);
            PintuUtamaOutFoto.SetDbValue(row["PintuUtamaOutFoto"]);
            PintuUtamaOutFotoDownload.SetDbValue(row["PintuUtamaOutFotoDownload"]);
            PintuUtamaOutUser.SetDbValue(row["PintuUtamaOutUser"]);
            LobbyUtamaId.SetDbValue(row["LobbyUtamaId"]);
            LobbyUtamaInTanggal.SetDbValue(row["LobbyUtamaInTanggal"]);
            LobbyUtamaInFoto.SetDbValue(row["LobbyUtamaInFoto"]);
            LobbyUtamaInFotoDownload.SetDbValue(row["LobbyUtamaInFotoDownload"]);
            LobbyUtamaInUser.SetDbValue(row["LobbyUtamaInUser"]);
            LobbyUtamaOutTanggal.SetDbValue(row["LobbyUtamaOutTanggal"]);
            LobbyUtamaOutFoto.SetDbValue(row["LobbyUtamaOutFoto"]);
            LobbyUtamaOutFotoDownload.SetDbValue(row["LobbyUtamaOutFotoDownload"]);
            LobbyUtamaOutUser.SetDbValue(row["LobbyUtamaOutUser"]);
            AreaTerlarangId.SetDbValue(row["AreaTerlarangId"]);
            AreaTerlarangInTanggal.SetDbValue(row["AreaTerlarangInTanggal"]);
            AreaTerlarangInFoto.SetDbValue(row["AreaTerlarangInFoto"]);
            AreaTerlarangInFotoDownload.SetDbValue(row["AreaTerlarangInFotoDownload"]);
            AreaTerlarangInUser.SetDbValue(row["AreaTerlarangInUser"]);
            AreaTerlarangOutTanggal.SetDbValue(row["AreaTerlarangOutTanggal"]);
            AreaTerlarangOutFoto.SetDbValue(row["AreaTerlarangOutFoto"]);
            AreaTerlarangOutFotoDownload.SetDbValue(row["AreaTerlarangOutFotoDownload"]);
            AreaTerlarangOutUser.SetDbValue(row["AreaTerlarangOutUser"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            StatusZonaPrev.SetDbValue(row["StatusZonaPrev"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorBukuTamu", NomorBukuTamu.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("Tanggal", Tanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusZona", StatusZona.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama", Nama.DefaultValue ?? DbNullValue); // DN
            row.Add("AsalPerusahaan", AsalPerusahaan.DefaultValue ?? DbNullValue); // DN
            row.Add("Jabatan", Jabatan.DefaultValue ?? DbNullValue); // DN
            row.Add("FungsiygDikunjungi", FungsiygDikunjungi.DefaultValue ?? DbNullValue); // DN
            row.Add("MaksudKunjungan", MaksudKunjungan.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaPengenal", TandaPengenal.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaTangan", TandaTangan.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaTanganDownload", TandaTanganDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaId", PintuUtamaId.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInTanggal", PintuUtamaInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInFoto", PintuUtamaInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInFotoDownload", PintuUtamaInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInUser", PintuUtamaInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("CustomPilihPintu", CustomPilihPintu.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutTanggal", PintuUtamaOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutFoto", PintuUtamaOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutFotoDownload", PintuUtamaOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutUser", PintuUtamaOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaId", LobbyUtamaId.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInTanggal", LobbyUtamaInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInFoto", LobbyUtamaInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInFotoDownload", LobbyUtamaInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInUser", LobbyUtamaInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutTanggal", LobbyUtamaOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutFoto", LobbyUtamaOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutFotoDownload", LobbyUtamaOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutUser", LobbyUtamaOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangId", AreaTerlarangId.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInTanggal", AreaTerlarangInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInFoto", AreaTerlarangInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInFotoDownload", AreaTerlarangInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInUser", AreaTerlarangInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutTanggal", AreaTerlarangOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutFoto", AreaTerlarangOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutFotoDownload", AreaTerlarangOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutUser", AreaTerlarangOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusZonaPrev", StatusZonaPrev.DefaultValue ?? DbNullValue); // DN
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

            // NomorBukuTamu
            NomorBukuTamu.RowCssClass = "row";

            // LinkRedirect
            LinkRedirect.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // Tanggal
            Tanggal.RowCssClass = "row";

            // StatusZona
            StatusZona.RowCssClass = "row";

            // Nama
            Nama.RowCssClass = "row";

            // AsalPerusahaan
            AsalPerusahaan.RowCssClass = "row";

            // Jabatan
            Jabatan.RowCssClass = "row";

            // FungsiygDikunjungi
            FungsiygDikunjungi.RowCssClass = "row";

            // MaksudKunjungan
            MaksudKunjungan.RowCssClass = "row";

            // TandaPengenal
            TandaPengenal.RowCssClass = "row";

            // TandaTangan
            TandaTangan.RowCssClass = "row";

            // TandaTanganDownload
            TandaTanganDownload.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // PintuUtamaId
            PintuUtamaId.RowCssClass = "row";

            // PintuUtamaInTanggal
            PintuUtamaInTanggal.RowCssClass = "row";

            // PintuUtamaInFoto
            PintuUtamaInFoto.RowCssClass = "row";

            // PintuUtamaInFotoDownload
            PintuUtamaInFotoDownload.RowCssClass = "row";

            // PintuUtamaInUser
            PintuUtamaInUser.RowCssClass = "row";

            // CustomPilihPintu
            CustomPilihPintu.RowCssClass = "row";

            // PintuUtamaOutTanggal
            PintuUtamaOutTanggal.RowCssClass = "row";

            // PintuUtamaOutFoto
            PintuUtamaOutFoto.RowCssClass = "row";

            // PintuUtamaOutFotoDownload
            PintuUtamaOutFotoDownload.RowCssClass = "row";

            // PintuUtamaOutUser
            PintuUtamaOutUser.RowCssClass = "row";

            // LobbyUtamaId
            LobbyUtamaId.RowCssClass = "row";

            // LobbyUtamaInTanggal
            LobbyUtamaInTanggal.RowCssClass = "row";

            // LobbyUtamaInFoto
            LobbyUtamaInFoto.RowCssClass = "row";

            // LobbyUtamaInFotoDownload
            LobbyUtamaInFotoDownload.RowCssClass = "row";

            // LobbyUtamaInUser
            LobbyUtamaInUser.RowCssClass = "row";

            // LobbyUtamaOutTanggal
            LobbyUtamaOutTanggal.RowCssClass = "row";

            // LobbyUtamaOutFoto
            LobbyUtamaOutFoto.RowCssClass = "row";

            // LobbyUtamaOutFotoDownload
            LobbyUtamaOutFotoDownload.RowCssClass = "row";

            // LobbyUtamaOutUser
            LobbyUtamaOutUser.RowCssClass = "row";

            // AreaTerlarangId
            AreaTerlarangId.RowCssClass = "row";

            // AreaTerlarangInTanggal
            AreaTerlarangInTanggal.RowCssClass = "row";

            // AreaTerlarangInFoto
            AreaTerlarangInFoto.RowCssClass = "row";

            // AreaTerlarangInFotoDownload
            AreaTerlarangInFotoDownload.RowCssClass = "row";

            // AreaTerlarangInUser
            AreaTerlarangInUser.RowCssClass = "row";

            // AreaTerlarangOutTanggal
            AreaTerlarangOutTanggal.RowCssClass = "row";

            // AreaTerlarangOutFoto
            AreaTerlarangOutFoto.RowCssClass = "row";

            // AreaTerlarangOutFotoDownload
            AreaTerlarangOutFotoDownload.RowCssClass = "row";

            // AreaTerlarangOutUser
            AreaTerlarangOutUser.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // StatusZonaPrev
            StatusZonaPrev.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // NomorBukuTamu
                NomorBukuTamu.ViewValue = ConvertToString(NomorBukuTamu.CurrentValue); // DN
                NomorBukuTamu.ViewCustomAttributes = "";

                // LinkRedirect
                LinkRedirect.ViewValue = ConvertToString(LinkRedirect.CurrentValue); // DN
                LinkRedirect.ViewCustomAttributes = "";

                // LookupPlant
                if (!Empty(LookupPlant.CurrentValue)) {
                    LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                } else {
                    LookupPlant.ViewValue = DbNullValue;
                }
                LookupPlant.ViewCustomAttributes = "";

                // Plant
                Plant.ViewValue = Plant.CurrentValue;
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

                // Tanggal
                Tanggal.ViewValue = Tanggal.CurrentValue;
                Tanggal.ViewValue = FormatDateTime(Tanggal.ViewValue, Tanggal.FormatPattern);
                Tanggal.ViewCustomAttributes = "";

                // StatusZona
                StatusZona.ViewValue = ConvertToString(StatusZona.CurrentValue); // DN
                StatusZona.ViewCustomAttributes = "";

                // Nama
                Nama.ViewValue = ConvertToString(Nama.CurrentValue); // DN
                Nama.ViewCustomAttributes = "";

                // AsalPerusahaan
                AsalPerusahaan.ViewValue = ConvertToString(AsalPerusahaan.CurrentValue); // DN
                AsalPerusahaan.ViewCustomAttributes = "";

                // Jabatan
                Jabatan.ViewValue = ConvertToString(Jabatan.CurrentValue); // DN
                Jabatan.ViewCustomAttributes = "";

                // FungsiygDikunjungi
                string curVal3 = ConvertToString(FungsiygDikunjungi.CurrentValue);
                if (!Empty(curVal3)) {
                    if (FungsiygDikunjungi.Lookup != null && IsDictionary(FungsiygDikunjungi.Lookup?.Options) && FungsiygDikunjungi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        FungsiygDikunjungi.ViewValue = FungsiygDikunjungi.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchExpression, "=", FungsiygDikunjungi.CurrentValue, FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchDataType, "");
                        string? sqlWrk3 = FungsiygDikunjungi.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && FungsiygDikunjungi.Lookup != null) { // Lookup values found
                            var listwrk = FungsiygDikunjungi.Lookup?.RenderViewRow(rswrk3[0]);
                            FungsiygDikunjungi.ViewValue = FungsiygDikunjungi.DisplayValue(listwrk);
                        } else {
                            FungsiygDikunjungi.ViewValue = FungsiygDikunjungi.CurrentValue;
                        }
                    }
                } else {
                    FungsiygDikunjungi.ViewValue = DbNullValue;
                }
                FungsiygDikunjungi.ViewCustomAttributes = "";

                // MaksudKunjungan
                MaksudKunjungan.ViewValue = ConvertToString(MaksudKunjungan.CurrentValue); // DN
                MaksudKunjungan.ViewCustomAttributes = "";

                // TandaPengenal
                if (!Empty(TandaPengenal.CurrentValue)) {
                    TandaPengenal.ViewValue = TandaPengenal.OptionCaption(ConvertToString(TandaPengenal.CurrentValue));
                } else {
                    TandaPengenal.ViewValue = DbNullValue;
                }
                TandaPengenal.ViewCustomAttributes = "";

                // TandaTangan
                TandaTangan.ViewValue = TandaTangan.CurrentValue;
                TandaTangan.ViewCustomAttributes = "";

                // TandaTanganDownload
                TandaTanganDownload.ViewValue = TandaTanganDownload.CurrentValue;
                TandaTanganDownload.ViewCustomAttributes = "";

                // Keterangan
                Keterangan.ViewValue = Keterangan.CurrentValue;
                Keterangan.ViewCustomAttributes = "";

                // PintuUtamaId
                PintuUtamaId.ViewValue = ConvertToString(PintuUtamaId.CurrentValue); // DN
                PintuUtamaId.ViewCustomAttributes = "";

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.ViewValue = PintuUtamaInTanggal.CurrentValue;
                PintuUtamaInTanggal.ViewValue = FormatDateTime(PintuUtamaInTanggal.ViewValue, PintuUtamaInTanggal.FormatPattern);
                PintuUtamaInTanggal.ViewCustomAttributes = "";

                // PintuUtamaInFoto
                PintuUtamaInFoto.ViewValue = PintuUtamaInFoto.CurrentValue;
                PintuUtamaInFoto.ViewCustomAttributes = "";

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.ViewValue = PintuUtamaInFotoDownload.CurrentValue;
                PintuUtamaInFotoDownload.ViewCustomAttributes = "";

                // PintuUtamaInUser
                PintuUtamaInUser.ViewValue = ConvertToString(PintuUtamaInUser.CurrentValue); // DN
                PintuUtamaInUser.ViewCustomAttributes = "";

                // CustomPilihPintu
                CustomPilihPintu.ViewValue = ConvertToString(CustomPilihPintu.CurrentValue); // DN
                CustomPilihPintu.ViewCustomAttributes = "";

                // PintuUtamaOutTanggal
                PintuUtamaOutTanggal.ViewValue = PintuUtamaOutTanggal.CurrentValue;
                PintuUtamaOutTanggal.ViewValue = FormatDateTime(PintuUtamaOutTanggal.ViewValue, PintuUtamaOutTanggal.FormatPattern);
                PintuUtamaOutTanggal.ViewCustomAttributes = "";

                // PintuUtamaOutUser
                PintuUtamaOutUser.ViewValue = ConvertToString(PintuUtamaOutUser.CurrentValue); // DN
                PintuUtamaOutUser.ViewCustomAttributes = "";

                // LobbyUtamaId
                LobbyUtamaId.ViewValue = ConvertToString(LobbyUtamaId.CurrentValue); // DN
                LobbyUtamaId.ViewCustomAttributes = "";

                // LobbyUtamaInTanggal
                LobbyUtamaInTanggal.ViewValue = LobbyUtamaInTanggal.CurrentValue;
                LobbyUtamaInTanggal.ViewValue = FormatDateTime(LobbyUtamaInTanggal.ViewValue, LobbyUtamaInTanggal.FormatPattern);
                LobbyUtamaInTanggal.ViewCustomAttributes = "";

                // LobbyUtamaInUser
                LobbyUtamaInUser.ViewValue = ConvertToString(LobbyUtamaInUser.CurrentValue); // DN
                LobbyUtamaInUser.ViewCustomAttributes = "";

                // LobbyUtamaOutTanggal
                LobbyUtamaOutTanggal.ViewValue = LobbyUtamaOutTanggal.CurrentValue;
                LobbyUtamaOutTanggal.ViewValue = FormatDateTime(LobbyUtamaOutTanggal.ViewValue, LobbyUtamaOutTanggal.FormatPattern);
                LobbyUtamaOutTanggal.ViewCustomAttributes = "";

                // LobbyUtamaOutUser
                LobbyUtamaOutUser.ViewValue = ConvertToString(LobbyUtamaOutUser.CurrentValue); // DN
                LobbyUtamaOutUser.ViewCustomAttributes = "";

                // AreaTerlarangId
                AreaTerlarangId.ViewValue = ConvertToString(AreaTerlarangId.CurrentValue); // DN
                AreaTerlarangId.ViewCustomAttributes = "";

                // AreaTerlarangInTanggal
                AreaTerlarangInTanggal.ViewValue = AreaTerlarangInTanggal.CurrentValue;
                AreaTerlarangInTanggal.ViewValue = FormatDateTime(AreaTerlarangInTanggal.ViewValue, AreaTerlarangInTanggal.FormatPattern);
                AreaTerlarangInTanggal.ViewCustomAttributes = "";

                // AreaTerlarangInUser
                AreaTerlarangInUser.ViewValue = ConvertToString(AreaTerlarangInUser.CurrentValue); // DN
                AreaTerlarangInUser.ViewCustomAttributes = "";

                // AreaTerlarangOutTanggal
                AreaTerlarangOutTanggal.ViewValue = AreaTerlarangOutTanggal.CurrentValue;
                AreaTerlarangOutTanggal.ViewValue = FormatDateTime(AreaTerlarangOutTanggal.ViewValue, AreaTerlarangOutTanggal.FormatPattern);
                AreaTerlarangOutTanggal.ViewCustomAttributes = "";

                // AreaTerlarangOutUser
                AreaTerlarangOutUser.ViewValue = ConvertToString(AreaTerlarangOutUser.CurrentValue); // DN
                AreaTerlarangOutUser.ViewCustomAttributes = "";

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

                // StatusZonaPrev
                StatusZonaPrev.ViewValue = ConvertToString(StatusZonaPrev.CurrentValue); // DN
                StatusZonaPrev.ViewCustomAttributes = "";

                // LookupPlant
                LookupPlant.HrefValue = "";

                // Plant
                Plant.HrefValue = "";
                Plant.TooltipValue = "";

                // Tanggal
                Tanggal.HrefValue = "";
                Tanggal.TooltipValue = "";

                // StatusZona
                StatusZona.HrefValue = "";
                StatusZona.TooltipValue = "";

                // Nama
                Nama.HrefValue = "";
                Nama.TooltipValue = "";

                // AsalPerusahaan
                AsalPerusahaan.HrefValue = "";
                AsalPerusahaan.TooltipValue = "";

                // Jabatan
                Jabatan.HrefValue = "";
                Jabatan.TooltipValue = "";

                // FungsiygDikunjungi
                FungsiygDikunjungi.HrefValue = "";
                FungsiygDikunjungi.TooltipValue = "";

                // MaksudKunjungan
                MaksudKunjungan.HrefValue = "";
                MaksudKunjungan.TooltipValue = "";

                // TandaPengenal
                TandaPengenal.HrefValue = "";
                TandaPengenal.TooltipValue = "";

                // TandaTangan
                TandaTangan.HrefValue = "";

                // TandaTanganDownload
                TandaTanganDownload.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // PintuUtamaId
                PintuUtamaId.HrefValue = "";

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.HrefValue = "";

                // PintuUtamaInFoto
                PintuUtamaInFoto.HrefValue = "";

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.HrefValue = "";

                // StatusZonaPrev
                StatusZonaPrev.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // LookupPlant
                LookupPlant.SetupEditAttributes();
                LookupPlant.EditValue = LookupPlant.Options(true);
                LookupPlant.PlaceHolder = RemoveHtml(LookupPlant.Caption);
                if (!Empty(LookupPlant.EditValue) && IsNumeric(LookupPlant.EditValue))
                    LookupPlant.EditValue = FormatNumber(LookupPlant.EditValue, null);

                // Plant
                Plant.SetupEditAttributes();
                Plant.EditValue = Plant.CurrentValue;
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

                // Tanggal
                Tanggal.SetupEditAttributes();
                Tanggal.EditValue = FormatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
                Tanggal.PlaceHolder = RemoveHtml(Tanggal.Caption);

                // StatusZona
                StatusZona.SetupEditAttributes();
                if (!StatusZona.Raw)
                    StatusZona.CurrentValue = HtmlDecode(StatusZona.CurrentValue);
                StatusZona.EditValue = HtmlEncode(StatusZona.CurrentValue);
                StatusZona.PlaceHolder = RemoveHtml(StatusZona.Caption);

                // Nama
                Nama.SetupEditAttributes();
                if (!Nama.Raw)
                    Nama.CurrentValue = HtmlDecode(Nama.CurrentValue);
                Nama.EditValue = HtmlEncode(Nama.CurrentValue);
                Nama.PlaceHolder = RemoveHtml(Nama.Caption);

                // AsalPerusahaan
                AsalPerusahaan.SetupEditAttributes();
                if (!AsalPerusahaan.Raw)
                    AsalPerusahaan.CurrentValue = HtmlDecode(AsalPerusahaan.CurrentValue);
                AsalPerusahaan.EditValue = HtmlEncode(AsalPerusahaan.CurrentValue);
                AsalPerusahaan.PlaceHolder = RemoveHtml(AsalPerusahaan.Caption);

                // Jabatan
                Jabatan.SetupEditAttributes();
                if (!Jabatan.Raw)
                    Jabatan.CurrentValue = HtmlDecode(Jabatan.CurrentValue);
                Jabatan.EditValue = HtmlEncode(Jabatan.CurrentValue);
                Jabatan.PlaceHolder = RemoveHtml(Jabatan.Caption);

                // FungsiygDikunjungi
                FungsiygDikunjungi.SetupEditAttributes();
                string curVal3 = ConvertToString(FungsiygDikunjungi.CurrentValue);
                if (FungsiygDikunjungi.Lookup != null && IsDictionary(FungsiygDikunjungi.Lookup?.Options) && FungsiygDikunjungi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    FungsiygDikunjungi.EditValue = FungsiygDikunjungi.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk3 = "";
                    if (curVal3 == "") {
                        filterWrk3 = "0=1";
                    } else {
                        filterWrk3 = SearchFilter(FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchExpression, "=", FungsiygDikunjungi.CurrentValue, FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchDataType, "");
                    }
                    string? sqlWrk3 = FungsiygDikunjungi.Lookup?.GetSql(true, filterWrk3, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    FungsiygDikunjungi.EditValue = rswrk3;
                }
                FungsiygDikunjungi.PlaceHolder = RemoveHtml(FungsiygDikunjungi.Caption);

                // MaksudKunjungan
                MaksudKunjungan.SetupEditAttributes();
                if (!MaksudKunjungan.Raw)
                    MaksudKunjungan.CurrentValue = HtmlDecode(MaksudKunjungan.CurrentValue);
                MaksudKunjungan.EditValue = HtmlEncode(MaksudKunjungan.CurrentValue);
                MaksudKunjungan.PlaceHolder = RemoveHtml(MaksudKunjungan.Caption);

                // TandaPengenal
                TandaPengenal.SetupEditAttributes();
                TandaPengenal.EditValue = TandaPengenal.Options(true);
                TandaPengenal.PlaceHolder = RemoveHtml(TandaPengenal.Caption);

                // TandaTangan
                TandaTangan.SetupEditAttributes();
                TandaTangan.EditValue = TandaTangan.CurrentValue; // DN
                TandaTangan.PlaceHolder = RemoveHtml(TandaTangan.Caption);

                // TandaTanganDownload
                TandaTanganDownload.SetupEditAttributes();
                TandaTanganDownload.EditValue = TandaTanganDownload.CurrentValue; // DN
                TandaTanganDownload.PlaceHolder = RemoveHtml(TandaTanganDownload.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // PintuUtamaId
                PintuUtamaId.SetupEditAttributes();
                if (!PintuUtamaId.Raw)
                    PintuUtamaId.CurrentValue = HtmlDecode(PintuUtamaId.CurrentValue);
                PintuUtamaId.EditValue = HtmlEncode(PintuUtamaId.CurrentValue);
                PintuUtamaId.PlaceHolder = RemoveHtml(PintuUtamaId.Caption);

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.SetupEditAttributes();
                PintuUtamaInTanggal.EditValue = FormatDateTime(PintuUtamaInTanggal.CurrentValue, PintuUtamaInTanggal.FormatPattern);
                PintuUtamaInTanggal.PlaceHolder = RemoveHtml(PintuUtamaInTanggal.Caption);

                // PintuUtamaInFoto
                PintuUtamaInFoto.SetupEditAttributes();
                PintuUtamaInFoto.EditValue = PintuUtamaInFoto.CurrentValue; // DN
                PintuUtamaInFoto.PlaceHolder = RemoveHtml(PintuUtamaInFoto.Caption);

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.SetupEditAttributes();
                PintuUtamaInFotoDownload.EditValue = PintuUtamaInFotoDownload.CurrentValue; // DN
                PintuUtamaInFotoDownload.PlaceHolder = RemoveHtml(PintuUtamaInFotoDownload.Caption);

                // StatusZonaPrev
                StatusZonaPrev.SetupEditAttributes();
                if (!StatusZonaPrev.Raw)
                    StatusZonaPrev.CurrentValue = HtmlDecode(StatusZonaPrev.CurrentValue);
                StatusZonaPrev.EditValue = HtmlEncode(StatusZonaPrev.CurrentValue);
                StatusZonaPrev.PlaceHolder = RemoveHtml(StatusZonaPrev.Caption);

                // Add refer script

                // LookupPlant
                LookupPlant.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // Tanggal
                Tanggal.HrefValue = "";

                // StatusZona
                StatusZona.HrefValue = "";

                // Nama
                Nama.HrefValue = "";

                // AsalPerusahaan
                AsalPerusahaan.HrefValue = "";

                // Jabatan
                Jabatan.HrefValue = "";

                // FungsiygDikunjungi
                FungsiygDikunjungi.HrefValue = "";

                // MaksudKunjungan
                MaksudKunjungan.HrefValue = "";

                // TandaPengenal
                TandaPengenal.HrefValue = "";

                // TandaTangan
                TandaTangan.HrefValue = "";

                // TandaTanganDownload
                TandaTanganDownload.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // PintuUtamaId
                PintuUtamaId.HrefValue = "";

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.HrefValue = "";

                // PintuUtamaInFoto
                PintuUtamaInFoto.HrefValue = "";

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.HrefValue = "";

                // StatusZonaPrev
                StatusZonaPrev.HrefValue = "";
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
                if (Tanggal.Visible && Tanggal.Required) {
                    if (!Tanggal.IsDetailKey && Empty(Tanggal.FormValue)) {
                        Tanggal.AddErrorMessage(ConvertToString(Tanggal.RequiredErrorMessage).Replace("%s", Tanggal.Caption));
                    }
                }
                if (!CheckDate(Tanggal.FormValue, Tanggal.FormatPattern)) {
                    Tanggal.AddErrorMessage(Tanggal.GetErrorMessage(false));
                }
                if (StatusZona.Visible && StatusZona.Required) {
                    if (!StatusZona.IsDetailKey && Empty(StatusZona.FormValue)) {
                        StatusZona.AddErrorMessage(ConvertToString(StatusZona.RequiredErrorMessage).Replace("%s", StatusZona.Caption));
                    }
                }
                if (Nama.Visible && Nama.Required) {
                    if (!Nama.IsDetailKey && Empty(Nama.FormValue)) {
                        Nama.AddErrorMessage(ConvertToString(Nama.RequiredErrorMessage).Replace("%s", Nama.Caption));
                    }
                }
                if (AsalPerusahaan.Visible && AsalPerusahaan.Required) {
                    if (!AsalPerusahaan.IsDetailKey && Empty(AsalPerusahaan.FormValue)) {
                        AsalPerusahaan.AddErrorMessage(ConvertToString(AsalPerusahaan.RequiredErrorMessage).Replace("%s", AsalPerusahaan.Caption));
                    }
                }
                if (Jabatan.Visible && Jabatan.Required) {
                    if (!Jabatan.IsDetailKey && Empty(Jabatan.FormValue)) {
                        Jabatan.AddErrorMessage(ConvertToString(Jabatan.RequiredErrorMessage).Replace("%s", Jabatan.Caption));
                    }
                }
                if (FungsiygDikunjungi.Visible && FungsiygDikunjungi.Required) {
                    if (!FungsiygDikunjungi.IsDetailKey && Empty(FungsiygDikunjungi.FormValue)) {
                        FungsiygDikunjungi.AddErrorMessage(ConvertToString(FungsiygDikunjungi.RequiredErrorMessage).Replace("%s", FungsiygDikunjungi.Caption));
                    }
                }
                if (MaksudKunjungan.Visible && MaksudKunjungan.Required) {
                    if (!MaksudKunjungan.IsDetailKey && Empty(MaksudKunjungan.FormValue)) {
                        MaksudKunjungan.AddErrorMessage(ConvertToString(MaksudKunjungan.RequiredErrorMessage).Replace("%s", MaksudKunjungan.Caption));
                    }
                }
                if (TandaPengenal.Visible && TandaPengenal.Required) {
                    if (!TandaPengenal.IsDetailKey && Empty(TandaPengenal.FormValue)) {
                        TandaPengenal.AddErrorMessage(ConvertToString(TandaPengenal.RequiredErrorMessage).Replace("%s", TandaPengenal.Caption));
                    }
                }
                if (TandaTangan.Visible && TandaTangan.Required) {
                    if (!TandaTangan.IsDetailKey && Empty(TandaTangan.FormValue)) {
                        TandaTangan.AddErrorMessage(ConvertToString(TandaTangan.RequiredErrorMessage).Replace("%s", TandaTangan.Caption));
                    }
                }
                if (TandaTanganDownload.Visible && TandaTanganDownload.Required) {
                    if (!TandaTanganDownload.IsDetailKey && Empty(TandaTanganDownload.FormValue)) {
                        TandaTanganDownload.AddErrorMessage(ConvertToString(TandaTanganDownload.RequiredErrorMessage).Replace("%s", TandaTanganDownload.Caption));
                    }
                }
                if (Keterangan.Visible && Keterangan.Required) {
                    if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                        Keterangan.AddErrorMessage(ConvertToString(Keterangan.RequiredErrorMessage).Replace("%s", Keterangan.Caption));
                    }
                }
                if (PintuUtamaId.Visible && PintuUtamaId.Required) {
                    if (!PintuUtamaId.IsDetailKey && Empty(PintuUtamaId.FormValue)) {
                        PintuUtamaId.AddErrorMessage(ConvertToString(PintuUtamaId.RequiredErrorMessage).Replace("%s", PintuUtamaId.Caption));
                    }
                }
                if (!CheckInteger(PintuUtamaId.FormValue)) {
                    PintuUtamaId.AddErrorMessage(PintuUtamaId.GetErrorMessage(false));
                }
                if (PintuUtamaInTanggal.Visible && PintuUtamaInTanggal.Required) {
                    if (!PintuUtamaInTanggal.IsDetailKey && Empty(PintuUtamaInTanggal.FormValue)) {
                        PintuUtamaInTanggal.AddErrorMessage(ConvertToString(PintuUtamaInTanggal.RequiredErrorMessage).Replace("%s", PintuUtamaInTanggal.Caption));
                    }
                }
                if (!CheckDate(PintuUtamaInTanggal.FormValue, PintuUtamaInTanggal.FormatPattern)) {
                    PintuUtamaInTanggal.AddErrorMessage(PintuUtamaInTanggal.GetErrorMessage(false));
                }
                if (PintuUtamaInFoto.Visible && PintuUtamaInFoto.Required) {
                    if (!PintuUtamaInFoto.IsDetailKey && Empty(PintuUtamaInFoto.FormValue)) {
                        PintuUtamaInFoto.AddErrorMessage(ConvertToString(PintuUtamaInFoto.RequiredErrorMessage).Replace("%s", PintuUtamaInFoto.Caption));
                    }
                }
                if (PintuUtamaInFotoDownload.Visible && PintuUtamaInFotoDownload.Required) {
                    if (!PintuUtamaInFotoDownload.IsDetailKey && Empty(PintuUtamaInFotoDownload.FormValue)) {
                        PintuUtamaInFotoDownload.AddErrorMessage(ConvertToString(PintuUtamaInFotoDownload.RequiredErrorMessage).Replace("%s", PintuUtamaInFotoDownload.Caption));
                    }
                }
                if (StatusZonaPrev.Visible && StatusZonaPrev.Required) {
                    if (!StatusZonaPrev.IsDetailKey && Empty(StatusZonaPrev.FormValue)) {
                        StatusZonaPrev.AddErrorMessage(ConvertToString(StatusZonaPrev.RequiredErrorMessage).Replace("%s", StatusZonaPrev.Caption));
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

                // LookupPlant
                LookupPlant.SetDbValue(rsnew, LookupPlant.CurrentValue);

                // Plant
                Plant.SetDbValue(rsnew, Plant.CurrentValue);

                // Tanggal
                Tanggal.SetDbValue(rsnew, ConvertToDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern));

                // StatusZona
                StatusZona.SetDbValue(rsnew, StatusZona.CurrentValue);

                // Nama
                Nama.SetDbValue(rsnew, Nama.CurrentValue);

                // AsalPerusahaan
                AsalPerusahaan.SetDbValue(rsnew, AsalPerusahaan.CurrentValue);

                // Jabatan
                Jabatan.SetDbValue(rsnew, Jabatan.CurrentValue);

                // FungsiygDikunjungi
                FungsiygDikunjungi.SetDbValue(rsnew, FungsiygDikunjungi.CurrentValue);

                // MaksudKunjungan
                MaksudKunjungan.SetDbValue(rsnew, MaksudKunjungan.CurrentValue);

                // TandaPengenal
                TandaPengenal.SetDbValue(rsnew, TandaPengenal.CurrentValue);

                // TandaTangan
                TandaTangan.SetDbValue(rsnew, TandaTangan.CurrentValue);

                // TandaTanganDownload
                TandaTanganDownload.SetDbValue(rsnew, TandaTanganDownload.CurrentValue);

                // Keterangan
                Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue);

                // PintuUtamaId
                PintuUtamaId.SetDbValue(rsnew, PintuUtamaId.CurrentValue);

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.SetDbValue(rsnew, ConvertToDateTime(PintuUtamaInTanggal.CurrentValue, PintuUtamaInTanggal.FormatPattern));

                // PintuUtamaInFoto
                PintuUtamaInFoto.SetDbValue(rsnew, PintuUtamaInFoto.CurrentValue);

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.SetDbValue(rsnew, PintuUtamaInFotoDownload.CurrentValue);

                // StatusZonaPrev
                StatusZonaPrev.SetDbValue(rsnew, StatusZonaPrev.CurrentValue);
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
            if (row.TryGetValue("LookupPlant", out value)) // LookupPlant
                LookupPlant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Tanggal", out value)) // Tanggal
                Tanggal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusZona", out value)) // StatusZona
                StatusZona.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Nama", out value)) // Nama
                Nama.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("AsalPerusahaan", out value)) // AsalPerusahaan
                AsalPerusahaan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Jabatan", out value)) // Jabatan
                Jabatan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("FungsiygDikunjungi", out value)) // FungsiygDikunjungi
                FungsiygDikunjungi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("MaksudKunjungan", out value)) // MaksudKunjungan
                MaksudKunjungan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TandaPengenal", out value)) // TandaPengenal
                TandaPengenal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TandaTangan", out value)) // TandaTangan
                TandaTangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TandaTanganDownload", out value)) // TandaTanganDownload
                TandaTanganDownload.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PintuUtamaId", out value)) // PintuUtamaId
                PintuUtamaId.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PintuUtamaInTanggal", out value)) // PintuUtamaInTanggal
                PintuUtamaInTanggal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PintuUtamaInFoto", out value)) // PintuUtamaInFoto
                PintuUtamaInFoto.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PintuUtamaInFotoDownload", out value)) // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusZonaPrev", out value)) // StatusZonaPrev
                StatusZonaPrev.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("BukuTamuList")), "", TableVar, true);
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
