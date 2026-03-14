namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penyaluranAdd
    /// </summary>
    public static PenyaluranAdd penyaluranAdd
    {
        get => HttpData.Get<PenyaluranAdd>("penyaluranAdd")!;
        set => HttpData["penyaluranAdd"] = value;
    }

    /// <summary>
    /// Page class for Penyaluran
    /// </summary>
    public class PenyaluranAdd : PenyaluranAddBase
    {
        // Constructor
        public PenyaluranAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenyaluranAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            IdPlant.DisplayValueSeparator = " - ";
            JenisProduk.DisplayValueSeparator = " - ";
            TujuanKonsinyasi.DisplayValueSeparator = " - ";
            TujuanKonsinyasi2.DisplayValueSeparator = " - ";
            TujuanKonsinyasi3.DisplayValueSeparator = " - ";
            IdPipa.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenyaluranAddBase : Penyaluran
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penyaluranAdd";

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
        public PenyaluranAddBase()
        {
            TableName = "Penyaluran";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (penyaluran)
            if (penyaluran == null || penyaluran is Penyaluran)
                penyaluran = this;

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
        public string PageName => "PenyaluranAdd";

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
            IdPenyaluran.Visible = false;
            NomorPenyaluran.Visible = false;
            LinkProses.Visible = false;
            LookupPlant.SetVisibility();
            IdPlant.SetVisibility();
            TipePenyaluran.SetVisibility();
            TipeProdukSTS.SetVisibility();
            KategoriPenyaluran.SetVisibility();
            IdModa.SetVisibility();
            DetailRTW.Visible = false;
            NoShipment.SetVisibility();
            IdPipa.SetVisibility();
            NomorPolisi.SetVisibility();
            NamaKapal.SetVisibility();
            JenisProduk.SetVisibility();
            IdPenimbunan.Visible = false;
            StatusProses.SetVisibility();
            IdTemplate.SetVisibility();
            PersentaseProgress.SetVisibility();
            Tujuan.SetVisibility();
            TujuanKonsinyasi.SetVisibility();
            Volume.SetVisibility();
            TujuanKonsinyasiPipa.Visible = false;
            QuantityKonsinyasiPipa.Visible = false;
            TujuanKonsinyasi2.Visible = false;
            Volume2.Visible = false;
            TujuanKonsinyasi3.Visible = false;
            Volume3.Visible = false;
            TanggalSandar.SetVisibility();
            Catatan.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            LookupTipeProduk.SetVisibility();
            LookupJenisPlant.SetVisibility();
            MultipleTujuanKonsinyasi.SetVisibility();
            MultipleTujuanKonsinyasiHidden.SetVisibility();
            MultipleQuantity.SetVisibility();
        }

        // Constructor
        public PenyaluranAddBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "PenyaluranView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdPenyaluran") ? dict["IdPenyaluran"] : IdPenyaluran.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdPenyaluran.Visible = false;
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
            await SetupLookupOptions(TipePenyaluran);
            await SetupLookupOptions(TipeProdukSTS);
            await SetupLookupOptions(KategoriPenyaluran);
            await SetupLookupOptions(IdModa);
            await SetupLookupOptions(IdPipa);
            await SetupLookupOptions(JenisProduk);
            await SetupLookupOptions(IdPenimbunan);
            await SetupLookupOptions(TujuanKonsinyasi);
            await SetupLookupOptions(TujuanKonsinyasi2);
            await SetupLookupOptions(TujuanKonsinyasi3);
            await SetupLookupOptions(MultipleTujuanKonsinyasi);

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
                if (RouteValues.TryGetValue("IdPenyaluran", out rv)) { // DN
                    IdPenyaluran.QueryValue = UrlDecode(rv); // DN
                } else if (Get("IdPenyaluran", out sv)) {
                    IdPenyaluran.QueryValue = sv.ToString();
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
                        return Terminate("PenyaluranList"); // No matching record, return to List page // DN
                    }
                    break;
                case "insert": // Add new record // DN
                    SendEmail = true; // Send email on add success
                    var res = await AddRow(rsold);
                    if (res) { // Add successful
                        if (Empty(SuccessMessage) && Post("addopt") != "1") // Skip success message for addopt (done in JavaScript)
                            SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
                        string returnUrl = "";
                        returnUrl = "PenyaluranList";
                        if (GetPageName(returnUrl) == "PenyaluranList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "PenyaluranView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "PenyaluranList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "PenyaluranList"; // Return list page content
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
                penyaluranAdd?.PageRender();
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
            IdTemplate.DefaultValue = IdTemplate.GetDefault(); // DN
            IdTemplate.OldValue = IdTemplate.DefaultValue;
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

            // Check field name 'TipePenyaluran' before field var 'x_TipePenyaluran'
            val = CurrentForm.HasValue("TipePenyaluran") ? CurrentForm.GetValue("TipePenyaluran") : CurrentForm.GetValue("x_TipePenyaluran");
            if (!TipePenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipePenyaluran") && !CurrentForm.HasValue("x_TipePenyaluran")) // DN
                    TipePenyaluran.Visible = false; // Disable update for API request
                else
                    TipePenyaluran.SetFormValue(val);
            }

            // Check field name 'TipeProdukSTS' before field var 'x_TipeProdukSTS'
            val = CurrentForm.HasValue("TipeProdukSTS") ? CurrentForm.GetValue("TipeProdukSTS") : CurrentForm.GetValue("x_TipeProdukSTS");
            if (!TipeProdukSTS.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipeProdukSTS") && !CurrentForm.HasValue("x_TipeProdukSTS")) // DN
                    TipeProdukSTS.Visible = false; // Disable update for API request
                else
                    TipeProdukSTS.SetFormValue(val);
            }

            // Check field name 'KategoriPenyaluran' before field var 'x_KategoriPenyaluran'
            val = CurrentForm.HasValue("KategoriPenyaluran") ? CurrentForm.GetValue("KategoriPenyaluran") : CurrentForm.GetValue("x_KategoriPenyaluran");
            if (!KategoriPenyaluran.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("KategoriPenyaluran") && !CurrentForm.HasValue("x_KategoriPenyaluran")) // DN
                    KategoriPenyaluran.Visible = false; // Disable update for API request
                else
                    KategoriPenyaluran.SetFormValue(val);
            }

            // Check field name 'IdModa' before field var 'x_IdModa'
            val = CurrentForm.HasValue("IdModa") ? CurrentForm.GetValue("IdModa") : CurrentForm.GetValue("x_IdModa");
            if (!IdModa.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdModa") && !CurrentForm.HasValue("x_IdModa")) // DN
                    IdModa.Visible = false; // Disable update for API request
                else
                    IdModa.SetFormValue(val);
            }

            // Check field name 'NoShipment' before field var 'x_NoShipment'
            val = CurrentForm.HasValue("NoShipment") ? CurrentForm.GetValue("NoShipment") : CurrentForm.GetValue("x_NoShipment");
            if (!NoShipment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NoShipment") && !CurrentForm.HasValue("x_NoShipment")) // DN
                    NoShipment.Visible = false; // Disable update for API request
                else
                    NoShipment.SetFormValue(val);
            }

            // Check field name 'IdPipa' before field var 'x_IdPipa'
            val = CurrentForm.HasValue("IdPipa") ? CurrentForm.GetValue("IdPipa") : CurrentForm.GetValue("x_IdPipa");
            if (!IdPipa.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPipa") && !CurrentForm.HasValue("x_IdPipa")) // DN
                    IdPipa.Visible = false; // Disable update for API request
                else
                    IdPipa.SetFormValue(val);
            }

            // Check field name 'NomorPolisi' before field var 'x_NomorPolisi'
            val = CurrentForm.HasValue("NomorPolisi") ? CurrentForm.GetValue("NomorPolisi") : CurrentForm.GetValue("x_NomorPolisi");
            if (!NomorPolisi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorPolisi") && !CurrentForm.HasValue("x_NomorPolisi")) // DN
                    NomorPolisi.Visible = false; // Disable update for API request
                else
                    NomorPolisi.SetFormValue(val);
            }

            // Check field name 'NamaKapal' before field var 'x_NamaKapal'
            val = CurrentForm.HasValue("NamaKapal") ? CurrentForm.GetValue("NamaKapal") : CurrentForm.GetValue("x_NamaKapal");
            if (!NamaKapal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaKapal") && !CurrentForm.HasValue("x_NamaKapal")) // DN
                    NamaKapal.Visible = false; // Disable update for API request
                else
                    NamaKapal.SetFormValue(val);
            }

            // Check field name 'JenisProduk' before field var 'x_JenisProduk'
            val = CurrentForm.HasValue("JenisProduk") ? CurrentForm.GetValue("JenisProduk") : CurrentForm.GetValue("x_JenisProduk");
            if (!JenisProduk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("JenisProduk") && !CurrentForm.HasValue("x_JenisProduk")) // DN
                    JenisProduk.Visible = false; // Disable update for API request
                else
                    JenisProduk.SetFormValue(val);
            }

            // Check field name 'StatusProses' before field var 'x_StatusProses'
            val = CurrentForm.HasValue("StatusProses") ? CurrentForm.GetValue("StatusProses") : CurrentForm.GetValue("x_StatusProses");
            if (!StatusProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusProses") && !CurrentForm.HasValue("x_StatusProses")) // DN
                    StatusProses.Visible = false; // Disable update for API request
                else
                    StatusProses.SetFormValue(val);
            }

            // Check field name 'IdTemplate' before field var 'x_IdTemplate'
            val = CurrentForm.HasValue("IdTemplate") ? CurrentForm.GetValue("IdTemplate") : CurrentForm.GetValue("x_IdTemplate");
            if (!IdTemplate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTemplate") && !CurrentForm.HasValue("x_IdTemplate")) // DN
                    IdTemplate.Visible = false; // Disable update for API request
                else
                    IdTemplate.SetFormValue(val);
            }

            // Check field name 'PersentaseProgress' before field var 'x_PersentaseProgress'
            val = CurrentForm.HasValue("PersentaseProgress") ? CurrentForm.GetValue("PersentaseProgress") : CurrentForm.GetValue("x_PersentaseProgress");
            if (!PersentaseProgress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PersentaseProgress") && !CurrentForm.HasValue("x_PersentaseProgress")) // DN
                    PersentaseProgress.Visible = false; // Disable update for API request
                else
                    PersentaseProgress.SetFormValue(val);
            }

            // Check field name 'Tujuan' before field var 'x_Tujuan'
            val = CurrentForm.HasValue("Tujuan") ? CurrentForm.GetValue("Tujuan") : CurrentForm.GetValue("x_Tujuan");
            if (!Tujuan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Tujuan") && !CurrentForm.HasValue("x_Tujuan")) // DN
                    Tujuan.Visible = false; // Disable update for API request
                else
                    Tujuan.SetFormValue(val);
            }

            // Check field name 'TujuanKonsinyasi' before field var 'x_TujuanKonsinyasi'
            val = CurrentForm.HasValue("TujuanKonsinyasi") ? CurrentForm.GetValue("TujuanKonsinyasi") : CurrentForm.GetValue("x_TujuanKonsinyasi");
            if (!TujuanKonsinyasi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TujuanKonsinyasi") && !CurrentForm.HasValue("x_TujuanKonsinyasi")) // DN
                    TujuanKonsinyasi.Visible = false; // Disable update for API request
                else
                    TujuanKonsinyasi.SetFormValue(val);
            }

            // Check field name 'Volume' before field var 'x_Volume'
            val = CurrentForm.HasValue("Volume") ? CurrentForm.GetValue("Volume") : CurrentForm.GetValue("x_Volume");
            if (!Volume.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Volume") && !CurrentForm.HasValue("x_Volume")) // DN
                    Volume.Visible = false; // Disable update for API request
                else
                    Volume.SetFormValue(val, true, validate);
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

            // Check field name 'Catatan' before field var 'x_Catatan'
            val = CurrentForm.HasValue("Catatan") ? CurrentForm.GetValue("Catatan") : CurrentForm.GetValue("x_Catatan");
            if (!Catatan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Catatan") && !CurrentForm.HasValue("x_Catatan")) // DN
                    Catatan.Visible = false; // Disable update for API request
                else
                    Catatan.SetFormValue(val);
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

            // Check field name 'MultipleTujuanKonsinyasi' before field var 'x_MultipleTujuanKonsinyasi'
            val = CurrentForm.HasValue("MultipleTujuanKonsinyasi") ? CurrentForm.GetValue("MultipleTujuanKonsinyasi") : CurrentForm.GetValue("x_MultipleTujuanKonsinyasi");
            if (!MultipleTujuanKonsinyasi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MultipleTujuanKonsinyasi") && !CurrentForm.HasValue("x_MultipleTujuanKonsinyasi")) // DN
                    MultipleTujuanKonsinyasi.Visible = false; // Disable update for API request
                else
                    MultipleTujuanKonsinyasi.SetFormValue(val);
            }

            // Check field name 'MultipleTujuanKonsinyasiHidden' before field var 'x_MultipleTujuanKonsinyasiHidden'
            val = CurrentForm.HasValue("MultipleTujuanKonsinyasiHidden") ? CurrentForm.GetValue("MultipleTujuanKonsinyasiHidden") : CurrentForm.GetValue("x_MultipleTujuanKonsinyasiHidden");
            if (!MultipleTujuanKonsinyasiHidden.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MultipleTujuanKonsinyasiHidden") && !CurrentForm.HasValue("x_MultipleTujuanKonsinyasiHidden")) // DN
                    MultipleTujuanKonsinyasiHidden.Visible = false; // Disable update for API request
                else
                    MultipleTujuanKonsinyasiHidden.SetFormValue(val);
            }

            // Check field name 'MultipleQuantity' before field var 'x_MultipleQuantity'
            val = CurrentForm.HasValue("MultipleQuantity") ? CurrentForm.GetValue("MultipleQuantity") : CurrentForm.GetValue("x_MultipleQuantity");
            if (!MultipleQuantity.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MultipleQuantity") && !CurrentForm.HasValue("x_MultipleQuantity")) // DN
                    MultipleQuantity.Visible = false; // Disable update for API request
                else
                    MultipleQuantity.SetFormValue(val);
            }

            // Check field name 'IdPenyaluran' before field var 'x_IdPenyaluran'
            val = CurrentForm.HasValue("IdPenyaluran") ? CurrentForm.GetValue("IdPenyaluran") : CurrentForm.GetValue("x_IdPenyaluran");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            LookupPlant.CurrentValue = LookupPlant.FormValue;
            IdPlant.CurrentValue = IdPlant.FormValue;
            TipePenyaluran.CurrentValue = TipePenyaluran.FormValue;
            TipeProdukSTS.CurrentValue = TipeProdukSTS.FormValue;
            KategoriPenyaluran.CurrentValue = KategoriPenyaluran.FormValue;
            IdModa.CurrentValue = IdModa.FormValue;
            NoShipment.CurrentValue = NoShipment.FormValue;
            IdPipa.CurrentValue = IdPipa.FormValue;
            NomorPolisi.CurrentValue = NomorPolisi.FormValue;
            NamaKapal.CurrentValue = NamaKapal.FormValue;
            JenisProduk.CurrentValue = JenisProduk.FormValue;
            StatusProses.CurrentValue = StatusProses.FormValue;
            IdTemplate.CurrentValue = IdTemplate.FormValue;
            PersentaseProgress.CurrentValue = PersentaseProgress.FormValue;
            Tujuan.CurrentValue = Tujuan.FormValue;
            TujuanKonsinyasi.CurrentValue = TujuanKonsinyasi.FormValue;
            Volume.CurrentValue = Volume.FormValue;
            TanggalSandar.CurrentValue = TanggalSandar.FormValue;
            TanggalSandar.CurrentValue = UnformatDateTime(TanggalSandar.CurrentValue, TanggalSandar.FormatPattern);
            Catatan.CurrentValue = Catatan.FormValue;
            LookupTipeProduk.CurrentValue = LookupTipeProduk.FormValue;
            LookupJenisPlant.CurrentValue = LookupJenisPlant.FormValue;
            MultipleTujuanKonsinyasi.CurrentValue = MultipleTujuanKonsinyasi.FormValue;
            MultipleTujuanKonsinyasiHidden.CurrentValue = MultipleTujuanKonsinyasiHidden.FormValue;
            MultipleQuantity.CurrentValue = MultipleQuantity.FormValue;
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
            IdPenyaluran.SetDbValue(row["IdPenyaluran"]);
            NomorPenyaluran.SetDbValue(row["NomorPenyaluran"]);
            LinkProses.SetDbValue(row["LinkProses"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            TipePenyaluran.SetDbValue(row["TipePenyaluran"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            KategoriPenyaluran.SetDbValue(row["KategoriPenyaluran"]);
            IdModa.SetDbValue(row["IdModa"]);
            DetailRTW.SetDbValue(row["DetailRTW"]);
            NoShipment.SetDbValue(row["NoShipment"]);
            IdPipa.SetDbValue(row["IdPipa"]);
            NomorPolisi.SetDbValue(row["NomorPolisi"]);
            NamaKapal.SetDbValue(row["NamaKapal"]);
            JenisProduk.SetDbValue(row["JenisProduk"]);
            IdPenimbunan.SetDbValue(row["IdPenimbunan"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            Tujuan.SetDbValue(row["Tujuan"]);
            TujuanKonsinyasi.SetDbValue(row["TujuanKonsinyasi"]);
            Volume.SetDbValue(IsNull(row["Volume"]) ? DbNullValue : ConvertToDouble(row["Volume"]));
            TujuanKonsinyasiPipa.SetDbValue(row["TujuanKonsinyasiPipa"]);
            QuantityKonsinyasiPipa.SetDbValue(row["QuantityKonsinyasiPipa"]);
            TujuanKonsinyasi2.SetDbValue(row["TujuanKonsinyasi2"]);
            Volume2.SetDbValue(IsNull(row["Volume2"]) ? DbNullValue : ConvertToDouble(row["Volume2"]));
            TujuanKonsinyasi3.SetDbValue(row["TujuanKonsinyasi3"]);
            Volume3.SetDbValue(IsNull(row["Volume3"]) ? DbNullValue : ConvertToDouble(row["Volume3"]));
            TanggalSandar.SetDbValue(row["TanggalSandar"]);
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            LookupTipeProduk.SetDbValue(row["LookupTipeProduk"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
            MultipleTujuanKonsinyasi.SetDbValue(row["MultipleTujuanKonsinyasi"]);
            MultipleTujuanKonsinyasiHidden.SetDbValue(row["MultipleTujuanKonsinyasiHidden"]);
            MultipleQuantity.SetDbValue(row["MultipleQuantity"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdPenyaluran", IdPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPenyaluran", NomorPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkProses", LinkProses.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("TipePenyaluran", TipePenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("KategoriPenyaluran", KategoriPenyaluran.DefaultValue ?? DbNullValue); // DN
            row.Add("IdModa", IdModa.DefaultValue ?? DbNullValue); // DN
            row.Add("DetailRTW", DetailRTW.DefaultValue ?? DbNullValue); // DN
            row.Add("NoShipment", NoShipment.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPipa", IdPipa.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPolisi", NomorPolisi.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaKapal", NamaKapal.DefaultValue ?? DbNullValue); // DN
            row.Add("JenisProduk", JenisProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPenimbunan", IdPenimbunan.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("Tujuan", Tujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("TujuanKonsinyasi", TujuanKonsinyasi.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume", Volume.DefaultValue ?? DbNullValue); // DN
            row.Add("TujuanKonsinyasiPipa", TujuanKonsinyasiPipa.DefaultValue ?? DbNullValue); // DN
            row.Add("QuantityKonsinyasiPipa", QuantityKonsinyasiPipa.DefaultValue ?? DbNullValue); // DN
            row.Add("TujuanKonsinyasi2", TujuanKonsinyasi2.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume2", Volume2.DefaultValue ?? DbNullValue); // DN
            row.Add("TujuanKonsinyasi3", TujuanKonsinyasi3.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume3", Volume3.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalSandar", TanggalSandar.DefaultValue ?? DbNullValue); // DN
            row.Add("Catatan", Catatan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupTipeProduk", LookupTipeProduk.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupJenisPlant", LookupJenisPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("MultipleTujuanKonsinyasi", MultipleTujuanKonsinyasi.DefaultValue ?? DbNullValue); // DN
            row.Add("MultipleTujuanKonsinyasiHidden", MultipleTujuanKonsinyasiHidden.DefaultValue ?? DbNullValue); // DN
            row.Add("MultipleQuantity", MultipleQuantity.DefaultValue ?? DbNullValue); // DN
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

            // IdPenyaluran
            IdPenyaluran.RowCssClass = "row";

            // NomorPenyaluran
            NomorPenyaluran.RowCssClass = "row";

            // LinkProses
            LinkProses.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // TipePenyaluran
            TipePenyaluran.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // KategoriPenyaluran
            KategoriPenyaluran.RowCssClass = "row";

            // IdModa
            IdModa.RowCssClass = "row";

            // DetailRTW
            DetailRTW.RowCssClass = "row";

            // NoShipment
            NoShipment.RowCssClass = "row";

            // IdPipa
            IdPipa.RowCssClass = "row";

            // NomorPolisi
            NomorPolisi.RowCssClass = "row";

            // NamaKapal
            NamaKapal.RowCssClass = "row";

            // JenisProduk
            JenisProduk.RowCssClass = "row";

            // IdPenimbunan
            IdPenimbunan.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // PersentaseProgress
            PersentaseProgress.RowCssClass = "row";

            // Tujuan
            Tujuan.RowCssClass = "row";

            // TujuanKonsinyasi
            TujuanKonsinyasi.RowCssClass = "row";

            // Volume
            Volume.RowCssClass = "row";

            // TujuanKonsinyasiPipa
            TujuanKonsinyasiPipa.RowCssClass = "row";

            // QuantityKonsinyasiPipa
            QuantityKonsinyasiPipa.RowCssClass = "row";

            // TujuanKonsinyasi2
            TujuanKonsinyasi2.RowCssClass = "row";

            // Volume2
            Volume2.RowCssClass = "row";

            // TujuanKonsinyasi3
            TujuanKonsinyasi3.RowCssClass = "row";

            // Volume3
            Volume3.RowCssClass = "row";

            // TanggalSandar
            TanggalSandar.RowCssClass = "row";

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

            // MultipleTujuanKonsinyasi
            MultipleTujuanKonsinyasi.RowCssClass = "row";

            // MultipleTujuanKonsinyasiHidden
            MultipleTujuanKonsinyasiHidden.RowCssClass = "row";

            // MultipleQuantity
            MultipleQuantity.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // LinkProses
                LinkProses.ViewValue = ConvertToString(LinkProses.CurrentValue); // DN
                LinkProses.ViewCustomAttributes = "";

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

                // TipePenyaluran
                if (!Empty(TipePenyaluran.CurrentValue)) {
                    TipePenyaluran.ViewValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
                } else {
                    TipePenyaluran.ViewValue = DbNullValue;
                }
                TipePenyaluran.ViewCustomAttributes = "";

                // TipeProdukSTS
                List<object?>? listWrk4 = [ // DN
                    TipeProdukSTS.CurrentValue,
                    TipeProdukSTS.CurrentValue,
                ];
                listWrk4 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk4, this);
                string? dispVal4 = TipeProdukSTS.DisplayValue(listWrk4);
                if (!Empty(dispVal4))
                    TipeProdukSTS.ViewValue = dispVal4;
                TipeProdukSTS.ViewCustomAttributes = "";

                // KategoriPenyaluran
                if (!Empty(KategoriPenyaluran.CurrentValue)) {
                    KategoriPenyaluran.ViewValue = KategoriPenyaluran.OptionCaption(ConvertToString(KategoriPenyaluran.CurrentValue));
                } else {
                    KategoriPenyaluran.ViewValue = DbNullValue;
                }
                KategoriPenyaluran.ViewCustomAttributes = "";

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

                // NoShipment
                NoShipment.ViewValue = ConvertToString(NoShipment.CurrentValue); // DN
                NoShipment.ViewCustomAttributes = "";

                // IdPipa
                string curVal7 = ConvertToString(IdPipa.CurrentValue);
                if (!Empty(curVal7)) {
                    if (IdPipa.Lookup != null && IsDictionary(IdPipa.Lookup?.Options) && IdPipa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPipa.ViewValue = IdPipa.LookupCacheOption(curVal7);
                    } else { // Lookup from database // DN
                        string filterWrk7 = SearchFilter(IdPipa.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdPipa.CurrentValue, IdPipa.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                        string? sqlWrk7 = IdPipa.Lookup?.GetSql(false, filterWrk7, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk7?.Count > 0 && IdPipa.Lookup != null) { // Lookup values found
                            var listwrk = IdPipa.Lookup?.RenderViewRow(rswrk7[0]);
                            IdPipa.ViewValue = IdPipa.DisplayValue(listwrk);
                        } else {
                            IdPipa.ViewValue = FormatNumber(IdPipa.CurrentValue, IdPipa.FormatPattern);
                        }
                    }
                } else {
                    IdPipa.ViewValue = DbNullValue;
                }
                IdPipa.ViewCustomAttributes = "";

                // NomorPolisi
                NomorPolisi.ViewValue = ConvertToString(NomorPolisi.CurrentValue); // DN
                NomorPolisi.ViewCustomAttributes = "";

                // NamaKapal
                NamaKapal.ViewValue = ConvertToString(NamaKapal.CurrentValue); // DN
                NamaKapal.ViewCustomAttributes = "";

                // JenisProduk
                string curVal8 = ConvertToString(JenisProduk.CurrentValue);
                if (!Empty(curVal8)) {
                    if (JenisProduk.Lookup != null && IsDictionary(JenisProduk.Lookup?.Options) && JenisProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        JenisProduk.ViewValue = JenisProduk.LookupCacheOption(curVal8);
                    } else { // Lookup from database // DN
                        string filterWrk8 = SearchFilter(JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", JenisProduk.CurrentValue, JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                        string? sqlWrk8 = JenisProduk.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk8?.Count > 0 && JenisProduk.Lookup != null) { // Lookup values found
                            var listwrk = JenisProduk.Lookup?.RenderViewRow(rswrk8[0]);
                            JenisProduk.ViewValue = JenisProduk.DisplayValue(listwrk);
                        } else {
                            JenisProduk.ViewValue = JenisProduk.CurrentValue;
                        }
                    }
                } else {
                    JenisProduk.ViewValue = DbNullValue;
                }
                JenisProduk.ViewCustomAttributes = "";

                // StatusProses
                StatusProses.ViewValue = StatusProses.CurrentValue;
                StatusProses.ViewCustomAttributes = "";

                // IdTemplate
                IdTemplate.ViewValue = IdTemplate.CurrentValue;
                IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
                IdTemplate.ViewCustomAttributes = "";

                // PersentaseProgress
                PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                PersentaseProgress.ViewCustomAttributes = "";

                // Tujuan
                Tujuan.ViewValue = ConvertToString(Tujuan.CurrentValue); // DN
                Tujuan.ViewCustomAttributes = "";

                // TujuanKonsinyasi
                string curVal10 = ConvertToString(TujuanKonsinyasi.CurrentValue);
                if (!Empty(curVal10)) {
                    if (TujuanKonsinyasi.Lookup != null && IsDictionary(TujuanKonsinyasi.Lookup?.Options) && TujuanKonsinyasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        TujuanKonsinyasi.ViewValue = TujuanKonsinyasi.LookupCacheOption(curVal10);
                    } else { // Lookup from database // DN
                        string filterWrk10 = SearchFilter(TujuanKonsinyasi.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", TujuanKonsinyasi.CurrentValue, TujuanKonsinyasi.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk10 = TujuanKonsinyasi.Lookup?.GetSql(false, filterWrk10, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk10 = sqlWrk10 != null ? Connection.GetRows(sqlWrk10) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk10?.Count > 0 && TujuanKonsinyasi.Lookup != null) { // Lookup values found
                            var listwrk = TujuanKonsinyasi.Lookup?.RenderViewRow(rswrk10[0]);
                            TujuanKonsinyasi.ViewValue = TujuanKonsinyasi.DisplayValue(listwrk);
                        } else {
                            TujuanKonsinyasi.ViewValue = FormatNumber(TujuanKonsinyasi.CurrentValue, TujuanKonsinyasi.FormatPattern);
                        }
                    }
                } else {
                    TujuanKonsinyasi.ViewValue = DbNullValue;
                }
                TujuanKonsinyasi.ViewCustomAttributes = "";

                // Volume
                Volume.ViewValue = Volume.CurrentValue;
                Volume.ViewValue = FormatNumber(Volume.ViewValue, Volume.FormatPattern);
                Volume.ViewCustomAttributes = "";

                // TujuanKonsinyasiPipa
                TujuanKonsinyasiPipa.ViewValue = ConvertToString(TujuanKonsinyasiPipa.CurrentValue); // DN
                TujuanKonsinyasiPipa.ViewCustomAttributes = "";

                // QuantityKonsinyasiPipa
                QuantityKonsinyasiPipa.ViewValue = ConvertToString(QuantityKonsinyasiPipa.CurrentValue); // DN
                QuantityKonsinyasiPipa.ViewCustomAttributes = "";

                // TanggalSandar
                TanggalSandar.ViewValue = TanggalSandar.CurrentValue;
                TanggalSandar.ViewValue = FormatDateTime(TanggalSandar.ViewValue, TanggalSandar.FormatPattern);
                TanggalSandar.ViewCustomAttributes = "";

                // Catatan
                Catatan.ViewValue = Catatan.CurrentValue;
                Catatan.ViewCustomAttributes = "";

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

                // LookupTipeProduk
                LookupTipeProduk.ViewValue = LookupTipeProduk.CurrentValue;
                LookupTipeProduk.ViewCustomAttributes = "";

                // LookupJenisPlant
                LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
                LookupJenisPlant.ViewCustomAttributes = "";

                // MultipleTujuanKonsinyasi
                if (!Empty(MultipleTujuanKonsinyasi.CurrentValue)) {
                    MultipleTujuanKonsinyasi.ViewValue = MultipleTujuanKonsinyasi.OptionCaption(ConvertToString(MultipleTujuanKonsinyasi.CurrentValue));
                } else {
                    MultipleTujuanKonsinyasi.ViewValue = DbNullValue;
                }
                MultipleTujuanKonsinyasi.ViewCustomAttributes = "";

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.ViewValue = MultipleTujuanKonsinyasiHidden.CurrentValue;
                MultipleTujuanKonsinyasiHidden.ViewCustomAttributes = "";

                // MultipleQuantity
                MultipleQuantity.ViewValue = ConvertToString(MultipleQuantity.CurrentValue); // DN
                MultipleQuantity.ViewCustomAttributes = "";

                // LookupPlant
                LookupPlant.HrefValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";
                TipePenyaluran.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // KategoriPenyaluran
                KategoriPenyaluran.HrefValue = "";
                KategoriPenyaluran.TooltipValue = "";

                // IdModa
                IdModa.HrefValue = "";
                IdModa.TooltipValue = "";

                // NoShipment
                NoShipment.HrefValue = "";

                // IdPipa
                IdPipa.HrefValue = "";
                IdPipa.TooltipValue = "";

                // NomorPolisi
                NomorPolisi.HrefValue = "";
                NomorPolisi.TooltipValue = "";

                // NamaKapal
                NamaKapal.HrefValue = "";
                NamaKapal.TooltipValue = "";

                // JenisProduk
                JenisProduk.HrefValue = "";
                JenisProduk.TooltipValue = "";

                // StatusProses
                StatusProses.HrefValue = "";

                // IdTemplate
                IdTemplate.HrefValue = "";
                IdTemplate.TooltipValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";

                // Tujuan
                Tujuan.HrefValue = "";
                Tujuan.TooltipValue = "";

                // TujuanKonsinyasi
                TujuanKonsinyasi.HrefValue = "";
                TujuanKonsinyasi.TooltipValue = "";

                // Volume
                Volume.HrefValue = "";
                Volume.TooltipValue = "";

                // TanggalSandar
                TanggalSandar.HrefValue = "";
                TanggalSandar.TooltipValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";
                LookupTipeProduk.TooltipValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";
                LookupJenisPlant.TooltipValue = "";

                // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.HrefValue = "";
                MultipleTujuanKonsinyasi.TooltipValue = "";

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.HrefValue = "";
                MultipleTujuanKonsinyasiHidden.TooltipValue = "";

                // MultipleQuantity
                MultipleQuantity.HrefValue = "";
                MultipleQuantity.TooltipValue = "";
            } else if (RowType == RowType.Add) {
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

                // TipePenyaluran
                TipePenyaluran.SetupEditAttributes();
                TipePenyaluran.EditValue = TipePenyaluran.Options(true);
                TipePenyaluran.PlaceHolder = RemoveHtml(TipePenyaluran.Caption);

                // TipeProdukSTS
                TipeProdukSTS.SetupEditAttributes();
                string curVal4 = ConvertToString(TipeProdukSTS.CurrentValue);
                if (TipeProdukSTS.Lookup != null && IsDictionary(TipeProdukSTS.Lookup?.Options) && TipeProdukSTS.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TipeProdukSTS.EditValue = TipeProdukSTS.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk4 = "";
                    if (curVal4 == "") {
                        filterWrk4 = "0=1";
                    } else {
                        filterWrk4 = SearchFilter(TipeProdukSTS.Lookup?.GetTable()?.Fields["TipeProduk"].SearchExpression, "=", TipeProdukSTS.CurrentValue, TipeProdukSTS.Lookup?.GetTable()?.Fields["TipeProduk"].SearchDataType, "");
                    }
                    string? sqlWrk4 = TipeProdukSTS.Lookup?.GetSql(true, filterWrk4, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    TipeProdukSTS.EditValue = rswrk4;
                }
                TipeProdukSTS.PlaceHolder = RemoveHtml(TipeProdukSTS.Caption);

                // KategoriPenyaluran
                KategoriPenyaluran.SetupEditAttributes();
                KategoriPenyaluran.EditValue = KategoriPenyaluran.Options(true);
                KategoriPenyaluran.PlaceHolder = RemoveHtml(KategoriPenyaluran.Caption);

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

                // NoShipment
                NoShipment.SetupEditAttributes();
                if (!NoShipment.Raw)
                    NoShipment.CurrentValue = HtmlDecode(NoShipment.CurrentValue);
                NoShipment.EditValue = HtmlEncode(NoShipment.CurrentValue);
                NoShipment.PlaceHolder = RemoveHtml(NoShipment.Caption);

                // IdPipa
                IdPipa.SetupEditAttributes();
                string curVal7 = ConvertToString(IdPipa.CurrentValue);
                if (IdPipa.Lookup != null && IsDictionary(IdPipa.Lookup?.Options) && IdPipa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPipa.EditValue = IdPipa.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk7 = "";
                    if (curVal7 == "") {
                        filterWrk7 = "0=1";
                    } else {
                        filterWrk7 = SearchFilter(IdPipa.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdPipa.CurrentValue, IdPipa.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                    }
                    string? sqlWrk7 = IdPipa.Lookup?.GetSql(true, filterWrk7, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdPipa.EditValue = rswrk7;
                }
                IdPipa.PlaceHolder = RemoveHtml(IdPipa.Caption);
                if (!Empty(IdPipa.EditValue) && IsNumeric(IdPipa.EditValue))
                    IdPipa.EditValue = FormatNumber(IdPipa.EditValue, null);

                // NomorPolisi
                NomorPolisi.SetupEditAttributes();
                if (!NomorPolisi.Raw)
                    NomorPolisi.CurrentValue = HtmlDecode(NomorPolisi.CurrentValue);
                NomorPolisi.EditValue = HtmlEncode(NomorPolisi.CurrentValue);
                NomorPolisi.PlaceHolder = RemoveHtml(NomorPolisi.Caption);

                // NamaKapal
                NamaKapal.SetupEditAttributes();
                if (!NamaKapal.Raw)
                    NamaKapal.CurrentValue = HtmlDecode(NamaKapal.CurrentValue);
                NamaKapal.EditValue = HtmlEncode(NamaKapal.CurrentValue);
                NamaKapal.PlaceHolder = RemoveHtml(NamaKapal.Caption);

                // JenisProduk
                JenisProduk.SetupEditAttributes();
                string curVal8 = ConvertToString(JenisProduk.CurrentValue);
                if (JenisProduk.Lookup != null && IsDictionary(JenisProduk.Lookup?.Options) && JenisProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    JenisProduk.EditValue = JenisProduk.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk8 = "";
                    if (curVal8 == "") {
                        filterWrk8 = "0=1";
                    } else {
                        filterWrk8 = SearchFilter(JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", JenisProduk.CurrentValue, JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                    }
                    string? sqlWrk8 = JenisProduk.Lookup?.GetSql(true, filterWrk8, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    JenisProduk.EditValue = rswrk8;
                }
                JenisProduk.PlaceHolder = RemoveHtml(JenisProduk.Caption);

                // StatusProses
                StatusProses.SetupEditAttributes();
                StatusProses.CurrentValue = StatusProses.GetDefault();

                // IdTemplate
                IdTemplate.SetupEditAttributes();
                IdTemplate.CurrentValue = FormatNumber(IdTemplate.GetDefault(), IdTemplate.FormatPattern);
                if (!Empty(IdTemplate.EditValue) && IsNumeric(IdTemplate.EditValue))
                    IdTemplate.EditValue = FormatNumber(IdTemplate.EditValue, null);

                // PersentaseProgress
                PersentaseProgress.SetupEditAttributes();
                PersentaseProgress.CurrentValue = FormatPercent(PersentaseProgress.GetDefault(), PersentaseProgress.FormatPattern);

                // Tujuan
                Tujuan.SetupEditAttributes();
                if (!Tujuan.Raw)
                    Tujuan.CurrentValue = HtmlDecode(Tujuan.CurrentValue);
                Tujuan.EditValue = HtmlEncode(Tujuan.CurrentValue);
                Tujuan.PlaceHolder = RemoveHtml(Tujuan.Caption);

                // TujuanKonsinyasi
                TujuanKonsinyasi.SetupEditAttributes();
                string curVal10 = ConvertToString(TujuanKonsinyasi.CurrentValue);
                if (TujuanKonsinyasi.Lookup != null && IsDictionary(TujuanKonsinyasi.Lookup?.Options) && TujuanKonsinyasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TujuanKonsinyasi.EditValue = TujuanKonsinyasi.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk10 = "";
                    if (curVal10 == "") {
                        filterWrk10 = "0=1";
                    } else {
                        filterWrk10 = SearchFilter(TujuanKonsinyasi.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", TujuanKonsinyasi.CurrentValue, TujuanKonsinyasi.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk10 = TujuanKonsinyasi.Lookup?.GetSql(true, filterWrk10, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk10 = sqlWrk10 != null ? Connection.GetRows(sqlWrk10) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    TujuanKonsinyasi.EditValue = rswrk10;
                }
                TujuanKonsinyasi.PlaceHolder = RemoveHtml(TujuanKonsinyasi.Caption);
                if (!Empty(TujuanKonsinyasi.EditValue) && IsNumeric(TujuanKonsinyasi.EditValue))
                    TujuanKonsinyasi.EditValue = FormatNumber(TujuanKonsinyasi.EditValue, null);

                // Volume
                Volume.SetupEditAttributes();
                Volume.EditValue = Volume.CurrentValue;
                Volume.PlaceHolder = RemoveHtml(Volume.Caption);
                if (!Empty(Volume.EditValue) && IsNumeric(Volume.EditValue))
                    Volume.EditValue = FormatNumber(Volume.EditValue, null);

                // TanggalSandar
                TanggalSandar.SetupEditAttributes();
                TanggalSandar.EditValue = FormatDateTime(TanggalSandar.CurrentValue, TanggalSandar.FormatPattern);
                TanggalSandar.PlaceHolder = RemoveHtml(TanggalSandar.Caption);

                // Catatan
                Catatan.SetupEditAttributes();
                Catatan.EditValue = Catatan.CurrentValue; // DN
                Catatan.PlaceHolder = RemoveHtml(Catatan.Caption);

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

                // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.SetupEditAttributes();
                MultipleTujuanKonsinyasi.EditValue = MultipleTujuanKonsinyasi.Options(true);
                MultipleTujuanKonsinyasi.PlaceHolder = RemoveHtml(MultipleTujuanKonsinyasi.Caption);

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.SetupEditAttributes();
                if (!MultipleTujuanKonsinyasiHidden.Raw)
                    MultipleTujuanKonsinyasiHidden.CurrentValue = HtmlDecode(MultipleTujuanKonsinyasiHidden.CurrentValue);
                MultipleTujuanKonsinyasiHidden.EditValue = HtmlEncode(MultipleTujuanKonsinyasiHidden.CurrentValue);
                MultipleTujuanKonsinyasiHidden.PlaceHolder = RemoveHtml(MultipleTujuanKonsinyasiHidden.Caption);

                // MultipleQuantity
                MultipleQuantity.SetupEditAttributes();
                if (!MultipleQuantity.Raw)
                    MultipleQuantity.CurrentValue = HtmlDecode(MultipleQuantity.CurrentValue);
                MultipleQuantity.EditValue = HtmlEncode(MultipleQuantity.CurrentValue);
                MultipleQuantity.PlaceHolder = RemoveHtml(MultipleQuantity.Caption);

                // Add refer script

                // LookupPlant
                LookupPlant.HrefValue = "";

                // IdPlant
                IdPlant.HrefValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";

                // KategoriPenyaluran
                KategoriPenyaluran.HrefValue = "";

                // IdModa
                IdModa.HrefValue = "";

                // NoShipment
                NoShipment.HrefValue = "";

                // IdPipa
                IdPipa.HrefValue = "";

                // NomorPolisi
                NomorPolisi.HrefValue = "";

                // NamaKapal
                NamaKapal.HrefValue = "";

                // JenisProduk
                JenisProduk.HrefValue = "";

                // StatusProses
                StatusProses.HrefValue = "";

                // IdTemplate
                IdTemplate.HrefValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";

                // Tujuan
                Tujuan.HrefValue = "";

                // TujuanKonsinyasi
                TujuanKonsinyasi.HrefValue = "";

                // Volume
                Volume.HrefValue = "";

                // TanggalSandar
                TanggalSandar.HrefValue = "";

                // Catatan
                Catatan.HrefValue = "";

                // LookupTipeProduk
                LookupTipeProduk.HrefValue = "";

                // LookupJenisPlant
                LookupJenisPlant.HrefValue = "";

                // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.HrefValue = "";

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.HrefValue = "";

                // MultipleQuantity
                MultipleQuantity.HrefValue = "";
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
                if (TipePenyaluran.Visible && TipePenyaluran.Required) {
                    if (!TipePenyaluran.IsDetailKey && Empty(TipePenyaluran.FormValue)) {
                        TipePenyaluran.AddErrorMessage(ConvertToString(TipePenyaluran.RequiredErrorMessage).Replace("%s", TipePenyaluran.Caption));
                    }
                }
                if (TipeProdukSTS.Visible && TipeProdukSTS.Required) {
                    if (!TipeProdukSTS.IsDetailKey && Empty(TipeProdukSTS.FormValue)) {
                        TipeProdukSTS.AddErrorMessage(ConvertToString(TipeProdukSTS.RequiredErrorMessage).Replace("%s", TipeProdukSTS.Caption));
                    }
                }
                if (KategoriPenyaluran.Visible && KategoriPenyaluran.Required) {
                    if (!KategoriPenyaluran.IsDetailKey && Empty(KategoriPenyaluran.FormValue)) {
                        KategoriPenyaluran.AddErrorMessage(ConvertToString(KategoriPenyaluran.RequiredErrorMessage).Replace("%s", KategoriPenyaluran.Caption));
                    }
                }
                if (IdModa.Visible && IdModa.Required) {
                    if (!IdModa.IsDetailKey && Empty(IdModa.FormValue)) {
                        IdModa.AddErrorMessage(ConvertToString(IdModa.RequiredErrorMessage).Replace("%s", IdModa.Caption));
                    }
                }
                if (NoShipment.Visible && NoShipment.Required) {
                    if (!NoShipment.IsDetailKey && Empty(NoShipment.FormValue)) {
                        NoShipment.AddErrorMessage(ConvertToString(NoShipment.RequiredErrorMessage).Replace("%s", NoShipment.Caption));
                    }
                }
                if (IdPipa.Visible && IdPipa.Required) {
                    if (!IdPipa.IsDetailKey && Empty(IdPipa.FormValue)) {
                        IdPipa.AddErrorMessage(ConvertToString(IdPipa.RequiredErrorMessage).Replace("%s", IdPipa.Caption));
                    }
                }
                if (NomorPolisi.Visible && NomorPolisi.Required) {
                    if (!NomorPolisi.IsDetailKey && Empty(NomorPolisi.FormValue)) {
                        NomorPolisi.AddErrorMessage(ConvertToString(NomorPolisi.RequiredErrorMessage).Replace("%s", NomorPolisi.Caption));
                    }
                }
                if (NamaKapal.Visible && NamaKapal.Required) {
                    if (!NamaKapal.IsDetailKey && Empty(NamaKapal.FormValue)) {
                        NamaKapal.AddErrorMessage(ConvertToString(NamaKapal.RequiredErrorMessage).Replace("%s", NamaKapal.Caption));
                    }
                }
                if (JenisProduk.Visible && JenisProduk.Required) {
                    if (!JenisProduk.IsDetailKey && Empty(JenisProduk.FormValue)) {
                        JenisProduk.AddErrorMessage(ConvertToString(JenisProduk.RequiredErrorMessage).Replace("%s", JenisProduk.Caption));
                    }
                }
                if (StatusProses.Visible && StatusProses.Required) {
                    if (!StatusProses.IsDetailKey && Empty(StatusProses.FormValue)) {
                        StatusProses.AddErrorMessage(ConvertToString(StatusProses.RequiredErrorMessage).Replace("%s", StatusProses.Caption));
                    }
                }
                if (IdTemplate.Visible && IdTemplate.Required) {
                    if (!IdTemplate.IsDetailKey && Empty(IdTemplate.FormValue)) {
                        IdTemplate.AddErrorMessage(ConvertToString(IdTemplate.RequiredErrorMessage).Replace("%s", IdTemplate.Caption));
                    }
                }
                if (PersentaseProgress.Visible && PersentaseProgress.Required) {
                    if (!PersentaseProgress.IsDetailKey && Empty(PersentaseProgress.FormValue)) {
                        PersentaseProgress.AddErrorMessage(ConvertToString(PersentaseProgress.RequiredErrorMessage).Replace("%s", PersentaseProgress.Caption));
                    }
                }
                if (Tujuan.Visible && Tujuan.Required) {
                    if (!Tujuan.IsDetailKey && Empty(Tujuan.FormValue)) {
                        Tujuan.AddErrorMessage(ConvertToString(Tujuan.RequiredErrorMessage).Replace("%s", Tujuan.Caption));
                    }
                }
                if (TujuanKonsinyasi.Visible && TujuanKonsinyasi.Required) {
                    if (!TujuanKonsinyasi.IsDetailKey && Empty(TujuanKonsinyasi.FormValue)) {
                        TujuanKonsinyasi.AddErrorMessage(ConvertToString(TujuanKonsinyasi.RequiredErrorMessage).Replace("%s", TujuanKonsinyasi.Caption));
                    }
                }
                if (Volume.Visible && Volume.Required) {
                    if (!Volume.IsDetailKey && Empty(Volume.FormValue)) {
                        Volume.AddErrorMessage(ConvertToString(Volume.RequiredErrorMessage).Replace("%s", Volume.Caption));
                    }
                }
                if (!CheckNumber(Volume.FormValue)) {
                    Volume.AddErrorMessage(Volume.GetErrorMessage(false));
                }
                if (TanggalSandar.Visible && TanggalSandar.Required) {
                    if (!TanggalSandar.IsDetailKey && Empty(TanggalSandar.FormValue)) {
                        TanggalSandar.AddErrorMessage(ConvertToString(TanggalSandar.RequiredErrorMessage).Replace("%s", TanggalSandar.Caption));
                    }
                }
                if (!CheckDate(TanggalSandar.FormValue, TanggalSandar.FormatPattern)) {
                    TanggalSandar.AddErrorMessage(TanggalSandar.GetErrorMessage(false));
                }
                if (Catatan.Visible && Catatan.Required) {
                    if (!Catatan.IsDetailKey && Empty(Catatan.FormValue)) {
                        Catatan.AddErrorMessage(ConvertToString(Catatan.RequiredErrorMessage).Replace("%s", Catatan.Caption));
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
                if (MultipleTujuanKonsinyasi.Visible && MultipleTujuanKonsinyasi.Required) {
                    if (!MultipleTujuanKonsinyasi.IsDetailKey && Empty(MultipleTujuanKonsinyasi.FormValue)) {
                        MultipleTujuanKonsinyasi.AddErrorMessage(ConvertToString(MultipleTujuanKonsinyasi.RequiredErrorMessage).Replace("%s", MultipleTujuanKonsinyasi.Caption));
                    }
                }
                if (MultipleTujuanKonsinyasiHidden.Visible && MultipleTujuanKonsinyasiHidden.Required) {
                    if (!MultipleTujuanKonsinyasiHidden.IsDetailKey && Empty(MultipleTujuanKonsinyasiHidden.FormValue)) {
                        MultipleTujuanKonsinyasiHidden.AddErrorMessage(ConvertToString(MultipleTujuanKonsinyasiHidden.RequiredErrorMessage).Replace("%s", MultipleTujuanKonsinyasiHidden.Caption));
                    }
                }
                if (MultipleQuantity.Visible && MultipleQuantity.Required) {
                    if (!MultipleQuantity.IsDetailKey && Empty(MultipleQuantity.FormValue)) {
                        MultipleQuantity.AddErrorMessage(ConvertToString(MultipleQuantity.RequiredErrorMessage).Replace("%s", MultipleQuantity.Caption));
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
                    rsnew["IdPenyaluran"] = IdPenyaluran.CurrentValue!;
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

                // IdPlant
                IdPlant.SetDbValue(rsnew, IdPlant.CurrentValue);

                // TipePenyaluran
                TipePenyaluran.SetDbValue(rsnew, TipePenyaluran.CurrentValue);

                // TipeProdukSTS
                TipeProdukSTS.SetDbValue(rsnew, TipeProdukSTS.CurrentValue);

                // KategoriPenyaluran
                KategoriPenyaluran.SetDbValue(rsnew, KategoriPenyaluran.CurrentValue);

                // IdModa
                IdModa.SetDbValue(rsnew, IdModa.CurrentValue);

                // NoShipment
                NoShipment.SetDbValue(rsnew, NoShipment.CurrentValue);

                // IdPipa
                IdPipa.SetDbValue(rsnew, IdPipa.CurrentValue);

                // NomorPolisi
                NomorPolisi.SetDbValue(rsnew, NomorPolisi.CurrentValue);

                // NamaKapal
                NamaKapal.SetDbValue(rsnew, NamaKapal.CurrentValue);

                // JenisProduk
                JenisProduk.SetDbValue(rsnew, JenisProduk.CurrentValue);

                // StatusProses
                StatusProses.SetDbValue(rsnew, StatusProses.CurrentValue);

                // IdTemplate
                IdTemplate.SetDbValue(rsnew, IdTemplate.CurrentValue);

                // PersentaseProgress
                PersentaseProgress.SetDbValue(rsnew, PersentaseProgress.CurrentValue);

                // Tujuan
                Tujuan.SetDbValue(rsnew, Tujuan.CurrentValue);

                // TujuanKonsinyasi
                TujuanKonsinyasi.SetDbValue(rsnew, TujuanKonsinyasi.CurrentValue);

                // Volume
                Volume.SetDbValue(rsnew, Volume.CurrentValue);

                // TanggalSandar
                TanggalSandar.SetDbValue(rsnew, ConvertToDateTime(TanggalSandar.CurrentValue, TanggalSandar.FormatPattern));

                // Catatan
                Catatan.SetDbValue(rsnew, Catatan.CurrentValue);

                // LookupTipeProduk
                LookupTipeProduk.SetDbValue(rsnew, LookupTipeProduk.CurrentValue);

                // LookupJenisPlant
                LookupJenisPlant.SetDbValue(rsnew, LookupJenisPlant.CurrentValue);

                // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.SetDbValue(rsnew, MultipleTujuanKonsinyasi.CurrentValue);

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.SetDbValue(rsnew, MultipleTujuanKonsinyasiHidden.CurrentValue);

                // MultipleQuantity
                MultipleQuantity.SetDbValue(rsnew, MultipleQuantity.CurrentValue);
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
            if (row.TryGetValue("IdPlant", out value)) // IdPlant
                IdPlant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TipePenyaluran", out value)) // TipePenyaluran
                TipePenyaluran.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TipeProdukSTS", out value)) // TipeProdukSTS
                TipeProdukSTS.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("KategoriPenyaluran", out value)) // KategoriPenyaluran
                KategoriPenyaluran.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdModa", out value)) // IdModa
                IdModa.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NoShipment", out value)) // NoShipment
                NoShipment.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdPipa", out value)) // IdPipa
                IdPipa.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NomorPolisi", out value)) // NomorPolisi
                NomorPolisi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NamaKapal", out value)) // NamaKapal
                NamaKapal.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("JenisProduk", out value)) // JenisProduk
                JenisProduk.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusProses", out value)) // StatusProses
                StatusProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdTemplate", out value)) // IdTemplate
                IdTemplate.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PersentaseProgress", out value)) // PersentaseProgress
                PersentaseProgress.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Tujuan", out value)) // Tujuan
                Tujuan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TujuanKonsinyasi", out value)) // TujuanKonsinyasi
                TujuanKonsinyasi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Volume", out value)) // Volume
                Volume.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalSandar", out value)) // TanggalSandar
                TanggalSandar.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Catatan", out value)) // Catatan
                Catatan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupTipeProduk", out value)) // LookupTipeProduk
                LookupTipeProduk.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupJenisPlant", out value)) // LookupJenisPlant
                LookupJenisPlant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("MultipleTujuanKonsinyasi", out value)) // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("MultipleTujuanKonsinyasiHidden", out value)) // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("MultipleQuantity", out value)) // MultipleQuantity
                MultipleQuantity.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("PenyaluranList")), "", TableVar, true);
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
