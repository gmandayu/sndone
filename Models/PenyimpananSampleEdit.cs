namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penyimpananSampleEdit
    /// </summary>
    public static PenyimpananSampleEdit penyimpananSampleEdit
    {
        get => HttpData.Get<PenyimpananSampleEdit>("penyimpananSampleEdit")!;
        set => HttpData["penyimpananSampleEdit"] = value;
    }

    /// <summary>
    /// Page class for PenyimpananSample
    /// </summary>
    public class PenyimpananSampleEdit : PenyimpananSampleEditBase
    {
        // Constructor
        public PenyimpananSampleEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenyimpananSampleEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            //Log("Page Load");
            IdPlant.DisplayValueSeparator = " - ";
        }
        // Page Load event
        public override void PageRender() {
            //Log("Page Render");
            string status = Convert.ToString(Status.CurrentValue)?.Trim() ?? "";
            if (status.Equals("Dimusnahkan", StringComparison.OrdinalIgnoreCase)) 
            {
                Write("<style>#btn-action{display:none !important;}</style>");
                TanggalDimusnahkan.Disabled = true;
                LokasiPemusnahan.Disabled = true;
            }
            if (Empty(TanggalDimusnahkan.EditValue))
                TanggalDimusnahkan.EditValue = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            Write(@"
            <style>
                button[name='btn-action'], button[name='btn-cancel']{visibility:visible;}
            </style>
            <script>
                document.addEventListener('DOMContentLoaded', function(){
                    const saveBtn=document.querySelector(""button[name='btn-action']"");
                    const cancelBtn=document.querySelector(""button[name='btn-cancel']"");
                    if(saveBtn && !saveBtn.dataset.iconized){
                        saveBtn.insertAdjacentHTML('afterbegin','<i class=""fas fa-save me-2""></i>');
                        saveBtn.dataset.iconized='1';
                    }
                    if(cancelBtn && !cancelBtn.dataset.iconized){
                        cancelBtn.insertAdjacentHTML('afterbegin','<i class=""fas fa-ban me-2""></i>');
                        cancelBtn.dataset.iconized='1';
                    }
                });
            </script>");    
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenyimpananSampleEditBase : PenyimpananSample
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penyimpananSampleEdit";

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
        public PenyimpananSampleEditBase()
        {
            TableName = "PenyimpananSample";

            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (penyimpananSample)
            if (penyimpananSample == null || penyimpananSample is PenyimpananSample)
                penyimpananSample = this;

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
        public string PageName => "PenyimpananSampleEdit";

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
            NomorPenyimpananSample.SetVisibility();
            JenisSample.SetVisibility();
            IdPlant.SetVisibility();
            Tanggal.SetVisibility();
            NamaMasterSample.SetVisibility();
            NomorSegel.SetVisibility();
            Status.SetVisibility();
            Foto.SetVisibility();
            DownloadFoto.Visible = false;
            ExpiredEst.SetVisibility();
            TanggalDimusnahkan.SetVisibility();
            LokasiPemusnahan.SetVisibility();
            CreatedBy.Visible = false;
            etlDate.Visible = false;
            LastUpdatedBy.Visible = false;
            lastUpdatedDate.Visible = false;
        }

        // Constructor
        public PenyimpananSampleEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "PenyimpananSampleView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(JenisSample);
            await SetupLookupOptions(IdPlant);

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
                if (RouteValues.TryGetValue("id", out rv)) { // DN
                    id.FormValue = UrlDecode(rv); // DN
                    id.OldValue = id.FormValue;
                } else if (CurrentForm.HasValue("x_id")) {
                    id.FormValue = CurrentForm.GetValue("x_id");
                    id.OldValue = id.FormValue;
                } else if (!Empty(keyValues)) {
                    id.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("id", out rv)) { // DN
                        id.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("id", out sv)) {
                        id.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        id.CurrentValue = DbNullValue;
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
                id.FormValue = ConvertToString(keyValues[0]);
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
                            return Terminate("PenyimpananSampleList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "PenyimpananSampleList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "PenyimpananSampleList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "PenyimpananSampleList"; // Return list page content
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
                penyimpananSampleEdit?.PageRender();
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

            // Check field name 'NomorPenyimpananSample' before field var 'x_NomorPenyimpananSample'
            val = CurrentForm.HasValue("NomorPenyimpananSample") ? CurrentForm.GetValue("NomorPenyimpananSample") : CurrentForm.GetValue("x_NomorPenyimpananSample");
            if (!NomorPenyimpananSample.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorPenyimpananSample") && !CurrentForm.HasValue("x_NomorPenyimpananSample")) // DN
                    NomorPenyimpananSample.Visible = false; // Disable update for API request
                else
                    NomorPenyimpananSample.SetFormValue(val);
            }

            // Check field name 'JenisSample' before field var 'x_JenisSample'
            val = CurrentForm.HasValue("JenisSample") ? CurrentForm.GetValue("JenisSample") : CurrentForm.GetValue("x_JenisSample");
            if (!JenisSample.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("JenisSample") && !CurrentForm.HasValue("x_JenisSample")) // DN
                    JenisSample.Visible = false; // Disable update for API request
                else
                    JenisSample.SetFormValue(val);
            }

            // Check field name 'IdPlant' before field var 'x_IdPlant'
            val = CurrentForm.HasValue("IdPlant") ? CurrentForm.GetValue("IdPlant") : CurrentForm.GetValue("x_IdPlant");
            if (!IdPlant.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdPlant") && !CurrentForm.HasValue("x_IdPlant")) // DN
                    IdPlant.Visible = false; // Disable update for API request
                else
                    IdPlant.SetFormValue(val);
            }

            // Check field name 'Tanggal' before field var 'x_Tanggal'
            val = CurrentForm.HasValue("Tanggal") ? CurrentForm.GetValue("Tanggal") : CurrentForm.GetValue("x_Tanggal");
            if (!Tanggal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Tanggal") && !CurrentForm.HasValue("x_Tanggal")) // DN
                    Tanggal.Visible = false; // Disable update for API request
                else
                    Tanggal.SetFormValue(val);
                Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            }

            // Check field name 'NamaMasterSample' before field var 'x_NamaMasterSample'
            val = CurrentForm.HasValue("NamaMasterSample") ? CurrentForm.GetValue("NamaMasterSample") : CurrentForm.GetValue("x_NamaMasterSample");
            if (!NamaMasterSample.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaMasterSample") && !CurrentForm.HasValue("x_NamaMasterSample")) // DN
                    NamaMasterSample.Visible = false; // Disable update for API request
                else
                    NamaMasterSample.SetFormValue(val);
            }

            // Check field name 'NomorSegel' before field var 'x_NomorSegel'
            val = CurrentForm.HasValue("NomorSegel") ? CurrentForm.GetValue("NomorSegel") : CurrentForm.GetValue("x_NomorSegel");
            if (!NomorSegel.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomorSegel") && !CurrentForm.HasValue("x_NomorSegel")) // DN
                    NomorSegel.Visible = false; // Disable update for API request
                else
                    NomorSegel.SetFormValue(val);
            }

            // Check field name 'Status' before field var 'x_Status'
            val = CurrentForm.HasValue("Status") ? CurrentForm.GetValue("Status") : CurrentForm.GetValue("x_Status");
            if (!Status.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Status") && !CurrentForm.HasValue("x_Status")) // DN
                    Status.Visible = false; // Disable update for API request
                else
                    Status.SetFormValue(val);
            }

            // Check field name 'Foto' before field var 'x_Foto'
            val = CurrentForm.HasValue("Foto") ? CurrentForm.GetValue("Foto") : CurrentForm.GetValue("x_Foto");
            if (!Foto.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Foto") && !CurrentForm.HasValue("x_Foto")) // DN
                    Foto.Visible = false; // Disable update for API request
                else
                    Foto.SetFormValue(val);
            }

            // Check field name 'ExpiredEst' before field var 'x_ExpiredEst'
            val = CurrentForm.HasValue("ExpiredEst") ? CurrentForm.GetValue("ExpiredEst") : CurrentForm.GetValue("x_ExpiredEst");
            if (!ExpiredEst.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ExpiredEst") && !CurrentForm.HasValue("x_ExpiredEst")) // DN
                    ExpiredEst.Visible = false; // Disable update for API request
                else
                    ExpiredEst.SetFormValue(val);
                ExpiredEst.CurrentValue = UnformatDateTime(ExpiredEst.CurrentValue, ExpiredEst.FormatPattern);
            }

            // Check field name 'TanggalDimusnahkan' before field var 'x_TanggalDimusnahkan'
            val = CurrentForm.HasValue("TanggalDimusnahkan") ? CurrentForm.GetValue("TanggalDimusnahkan") : CurrentForm.GetValue("x_TanggalDimusnahkan");
            if (!TanggalDimusnahkan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalDimusnahkan") && !CurrentForm.HasValue("x_TanggalDimusnahkan")) // DN
                    TanggalDimusnahkan.Visible = false; // Disable update for API request
                else
                    TanggalDimusnahkan.SetFormValue(val, true, validate);
                TanggalDimusnahkan.CurrentValue = UnformatDateTime(TanggalDimusnahkan.CurrentValue, TanggalDimusnahkan.FormatPattern);
            }

            // Check field name 'LokasiPemusnahan' before field var 'x_LokasiPemusnahan'
            val = CurrentForm.HasValue("LokasiPemusnahan") ? CurrentForm.GetValue("LokasiPemusnahan") : CurrentForm.GetValue("x_LokasiPemusnahan");
            if (!LokasiPemusnahan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LokasiPemusnahan") && !CurrentForm.HasValue("x_LokasiPemusnahan")) // DN
                    LokasiPemusnahan.Visible = false; // Disable update for API request
                else
                    LokasiPemusnahan.SetFormValue(val);
            }

            // Check field name 'id' before field var 'x_id'
            val = CurrentForm.HasValue("id") ? CurrentForm.GetValue("id") : CurrentForm.GetValue("x_id");
            if (!id.IsDetailKey)
                id.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            id.CurrentValue = id.FormValue;
            NomorPenyimpananSample.CurrentValue = NomorPenyimpananSample.FormValue;
            JenisSample.CurrentValue = JenisSample.FormValue;
            IdPlant.CurrentValue = IdPlant.FormValue;
            Tanggal.CurrentValue = Tanggal.FormValue;
            Tanggal.CurrentValue = UnformatDateTime(Tanggal.CurrentValue, Tanggal.FormatPattern);
            NamaMasterSample.CurrentValue = NamaMasterSample.FormValue;
            NomorSegel.CurrentValue = NomorSegel.FormValue;
            Status.CurrentValue = Status.FormValue;
            Foto.CurrentValue = Foto.FormValue;
            ExpiredEst.CurrentValue = ExpiredEst.FormValue;
            ExpiredEst.CurrentValue = UnformatDateTime(ExpiredEst.CurrentValue, ExpiredEst.FormatPattern);
            TanggalDimusnahkan.CurrentValue = TanggalDimusnahkan.FormValue;
            TanggalDimusnahkan.CurrentValue = UnformatDateTime(TanggalDimusnahkan.CurrentValue, TanggalDimusnahkan.FormatPattern);
            LokasiPemusnahan.CurrentValue = LokasiPemusnahan.FormValue;
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
            NomorPenyimpananSample.SetDbValue(row["NomorPenyimpananSample"]);
            JenisSample.SetDbValue(row["JenisSample"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            Tanggal.SetDbValue(row["Tanggal"]);
            NamaMasterSample.SetDbValue(row["NamaMasterSample"]);
            NomorSegel.SetDbValue(row["NomorSegel"]);
            Status.SetDbValue(row["Status"]);
            Foto.SetDbValue(row["Foto"]);
            DownloadFoto.SetDbValue(row["DownloadFoto"]);
            ExpiredEst.SetDbValue(row["ExpiredEst"]);
            TanggalDimusnahkan.SetDbValue(row["TanggalDimusnahkan"]);
            LokasiPemusnahan.SetDbValue(row["LokasiPemusnahan"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorPenyimpananSample", NomorPenyimpananSample.DefaultValue ?? DbNullValue); // DN
            row.Add("JenisSample", JenisSample.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPlant", IdPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Tanggal", Tanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaMasterSample", NamaMasterSample.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorSegel", NomorSegel.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("Foto", Foto.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadFoto", DownloadFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("ExpiredEst", ExpiredEst.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDimusnahkan", TanggalDimusnahkan.DefaultValue ?? DbNullValue); // DN
            row.Add("LokasiPemusnahan", LokasiPemusnahan.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
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

            // NomorPenyimpananSample
            NomorPenyimpananSample.RowCssClass = "row";

            // JenisSample
            JenisSample.RowCssClass = "row";

            // IdPlant
            IdPlant.RowCssClass = "row";

            // Tanggal
            Tanggal.RowCssClass = "row";

            // NamaMasterSample
            NamaMasterSample.RowCssClass = "row";

            // NomorSegel
            NomorSegel.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // Foto
            Foto.RowCssClass = "row";

            // DownloadFoto
            DownloadFoto.RowCssClass = "row";

            // ExpiredEst
            ExpiredEst.RowCssClass = "row";

            // TanggalDimusnahkan
            TanggalDimusnahkan.RowCssClass = "row";

            // LokasiPemusnahan
            LokasiPemusnahan.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // lastUpdatedDate
            lastUpdatedDate.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // NomorPenyimpananSample
                NomorPenyimpananSample.ViewValue = ConvertToString(NomorPenyimpananSample.CurrentValue); // DN
                NomorPenyimpananSample.ViewCustomAttributes = "";

                // JenisSample
                if (!Empty(JenisSample.CurrentValue)) {
                    JenisSample.ViewValue = JenisSample.OptionCaption(ConvertToString(JenisSample.CurrentValue));
                } else {
                    JenisSample.ViewValue = DbNullValue;
                }
                JenisSample.ViewCustomAttributes = "";

                // IdPlant
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

                // Tanggal
                Tanggal.ViewValue = Tanggal.CurrentValue;
                Tanggal.ViewValue = FormatDateTime(Tanggal.ViewValue, Tanggal.FormatPattern);
                Tanggal.ViewCustomAttributes = "";

                // NamaMasterSample
                NamaMasterSample.ViewValue = ConvertToString(NamaMasterSample.CurrentValue); // DN
                NamaMasterSample.ViewCustomAttributes = "";

                // NomorSegel
                NomorSegel.ViewValue = ConvertToString(NomorSegel.CurrentValue); // DN
                NomorSegel.ViewCustomAttributes = "";

                // Status
                Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // Foto
                Foto.ViewValue = Foto.CurrentValue;
                Foto.ViewCustomAttributes = "";

                // ExpiredEst
                ExpiredEst.ViewValue = ExpiredEst.CurrentValue;
                ExpiredEst.ViewValue = FormatDateTime(ExpiredEst.ViewValue, ExpiredEst.FormatPattern);
                ExpiredEst.ViewCustomAttributes = "";

                // TanggalDimusnahkan
                TanggalDimusnahkan.ViewValue = TanggalDimusnahkan.CurrentValue;
                TanggalDimusnahkan.ViewValue = FormatDateTime(TanggalDimusnahkan.ViewValue, TanggalDimusnahkan.FormatPattern);
                TanggalDimusnahkan.ViewCustomAttributes = "";

                // LokasiPemusnahan
                LokasiPemusnahan.ViewValue = ConvertToString(LokasiPemusnahan.CurrentValue); // DN
                LokasiPemusnahan.ViewCustomAttributes = "";

                // CreatedBy
                CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
                CreatedBy.ViewCustomAttributes = "";

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

                // NomorPenyimpananSample
                NomorPenyimpananSample.HrefValue = "";
                NomorPenyimpananSample.TooltipValue = "";

                // JenisSample
                JenisSample.HrefValue = "";
                JenisSample.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // Tanggal
                Tanggal.HrefValue = "";
                Tanggal.TooltipValue = "";

                // NamaMasterSample
                NamaMasterSample.HrefValue = "";
                NamaMasterSample.TooltipValue = "";

                // NomorSegel
                NomorSegel.HrefValue = "";
                NomorSegel.TooltipValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // Foto
                Foto.HrefValue = "";
                Foto.TooltipValue = "";

                // ExpiredEst
                ExpiredEst.HrefValue = "";
                ExpiredEst.TooltipValue = "";

                // TanggalDimusnahkan
                TanggalDimusnahkan.HrefValue = "";

                // LokasiPemusnahan
                LokasiPemusnahan.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // NomorPenyimpananSample
                NomorPenyimpananSample.SetupEditAttributes();
                NomorPenyimpananSample.EditValue = ConvertToString(NomorPenyimpananSample.CurrentValue); // DN
                NomorPenyimpananSample.ViewCustomAttributes = "";

                // JenisSample
                JenisSample.SetupEditAttributes();
                if (!Empty(JenisSample.CurrentValue)) {
                    JenisSample.EditValue = JenisSample.OptionCaption(ConvertToString(JenisSample.CurrentValue));
                } else {
                    JenisSample.EditValue = DbNullValue;
                }
                JenisSample.ViewCustomAttributes = "";

                // IdPlant
                IdPlant.SetupEditAttributes();
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
                            IdPlant.EditValue = FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
                        }
                    }
                } else {
                    IdPlant.EditValue = DbNullValue;
                }
                IdPlant.ViewCustomAttributes = "";

                // Tanggal
                Tanggal.SetupEditAttributes();
                Tanggal.EditValue = Tanggal.CurrentValue;
                Tanggal.EditValue = FormatDateTime(Tanggal.EditValue, Tanggal.FormatPattern);
                Tanggal.ViewCustomAttributes = "";

                // NamaMasterSample
                NamaMasterSample.SetupEditAttributes();
                NamaMasterSample.EditValue = ConvertToString(NamaMasterSample.CurrentValue); // DN
                NamaMasterSample.ViewCustomAttributes = "";

                // NomorSegel
                NomorSegel.SetupEditAttributes();
                NomorSegel.EditValue = ConvertToString(NomorSegel.CurrentValue); // DN
                NomorSegel.ViewCustomAttributes = "";

                // Status
                Status.SetupEditAttributes();
                Status.EditValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // Foto
                Foto.SetupEditAttributes();
                Foto.EditValue = Foto.CurrentValue;
                Foto.ViewCustomAttributes = "";

                // ExpiredEst
                ExpiredEst.SetupEditAttributes();
                ExpiredEst.EditValue = ExpiredEst.CurrentValue;
                ExpiredEst.EditValue = FormatDateTime(ExpiredEst.EditValue, ExpiredEst.FormatPattern);
                ExpiredEst.ViewCustomAttributes = "";

                // TanggalDimusnahkan
                TanggalDimusnahkan.SetupEditAttributes();
                TanggalDimusnahkan.EditValue = FormatDateTime(TanggalDimusnahkan.CurrentValue, TanggalDimusnahkan.FormatPattern);
                TanggalDimusnahkan.PlaceHolder = RemoveHtml(TanggalDimusnahkan.Caption);

                // LokasiPemusnahan
                LokasiPemusnahan.SetupEditAttributes();
                if (!LokasiPemusnahan.Raw)
                    LokasiPemusnahan.CurrentValue = HtmlDecode(LokasiPemusnahan.CurrentValue);
                LokasiPemusnahan.EditValue = HtmlEncode(LokasiPemusnahan.CurrentValue);
                LokasiPemusnahan.PlaceHolder = RemoveHtml(LokasiPemusnahan.Caption);

                // Edit refer script

                // NomorPenyimpananSample
                NomorPenyimpananSample.HrefValue = "";
                NomorPenyimpananSample.TooltipValue = "";

                // JenisSample
                JenisSample.HrefValue = "";
                JenisSample.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // Tanggal
                Tanggal.HrefValue = "";
                Tanggal.TooltipValue = "";

                // NamaMasterSample
                NamaMasterSample.HrefValue = "";
                NamaMasterSample.TooltipValue = "";

                // NomorSegel
                NomorSegel.HrefValue = "";
                NomorSegel.TooltipValue = "";

                // Status
                Status.HrefValue = "";
                Status.TooltipValue = "";

                // Foto
                Foto.HrefValue = "";
                Foto.TooltipValue = "";

                // ExpiredEst
                ExpiredEst.HrefValue = "";
                ExpiredEst.TooltipValue = "";

                // TanggalDimusnahkan
                TanggalDimusnahkan.HrefValue = "";

                // LokasiPemusnahan
                LokasiPemusnahan.HrefValue = "";
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
                if (NomorPenyimpananSample.Visible && NomorPenyimpananSample.Required) {
                    if (!NomorPenyimpananSample.IsDetailKey && Empty(NomorPenyimpananSample.FormValue)) {
                        NomorPenyimpananSample.AddErrorMessage(ConvertToString(NomorPenyimpananSample.RequiredErrorMessage).Replace("%s", NomorPenyimpananSample.Caption));
                    }
                }
                if (JenisSample.Visible && JenisSample.Required) {
                    if (!JenisSample.IsDetailKey && Empty(JenisSample.FormValue)) {
                        JenisSample.AddErrorMessage(ConvertToString(JenisSample.RequiredErrorMessage).Replace("%s", JenisSample.Caption));
                    }
                }
                if (IdPlant.Visible && IdPlant.Required) {
                    if (!IdPlant.IsDetailKey && Empty(IdPlant.FormValue)) {
                        IdPlant.AddErrorMessage(ConvertToString(IdPlant.RequiredErrorMessage).Replace("%s", IdPlant.Caption));
                    }
                }
                if (Tanggal.Visible && Tanggal.Required) {
                    if (!Tanggal.IsDetailKey && Empty(Tanggal.FormValue)) {
                        Tanggal.AddErrorMessage(ConvertToString(Tanggal.RequiredErrorMessage).Replace("%s", Tanggal.Caption));
                    }
                }
                if (NamaMasterSample.Visible && NamaMasterSample.Required) {
                    if (!NamaMasterSample.IsDetailKey && Empty(NamaMasterSample.FormValue)) {
                        NamaMasterSample.AddErrorMessage(ConvertToString(NamaMasterSample.RequiredErrorMessage).Replace("%s", NamaMasterSample.Caption));
                    }
                }
                if (NomorSegel.Visible && NomorSegel.Required) {
                    if (!NomorSegel.IsDetailKey && Empty(NomorSegel.FormValue)) {
                        NomorSegel.AddErrorMessage(ConvertToString(NomorSegel.RequiredErrorMessage).Replace("%s", NomorSegel.Caption));
                    }
                }
                if (Status.Visible && Status.Required) {
                    if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                        Status.AddErrorMessage(ConvertToString(Status.RequiredErrorMessage).Replace("%s", Status.Caption));
                    }
                }
                if (Foto.Visible && Foto.Required) {
                    if (!Foto.IsDetailKey && Empty(Foto.FormValue)) {
                        Foto.AddErrorMessage(ConvertToString(Foto.RequiredErrorMessage).Replace("%s", Foto.Caption));
                    }
                }
                if (ExpiredEst.Visible && ExpiredEst.Required) {
                    if (!ExpiredEst.IsDetailKey && Empty(ExpiredEst.FormValue)) {
                        ExpiredEst.AddErrorMessage(ConvertToString(ExpiredEst.RequiredErrorMessage).Replace("%s", ExpiredEst.Caption));
                    }
                }
                if (TanggalDimusnahkan.Visible && TanggalDimusnahkan.Required) {
                    if (!TanggalDimusnahkan.IsDetailKey && Empty(TanggalDimusnahkan.FormValue)) {
                        TanggalDimusnahkan.AddErrorMessage(ConvertToString(TanggalDimusnahkan.RequiredErrorMessage).Replace("%s", TanggalDimusnahkan.Caption));
                    }
                }
                if (!CheckDate(TanggalDimusnahkan.FormValue, TanggalDimusnahkan.FormatPattern)) {
                    TanggalDimusnahkan.AddErrorMessage(TanggalDimusnahkan.GetErrorMessage(false));
                }
                if (LokasiPemusnahan.Visible && LokasiPemusnahan.Required) {
                    if (!LokasiPemusnahan.IsDetailKey && Empty(LokasiPemusnahan.FormValue)) {
                        LokasiPemusnahan.AddErrorMessage(ConvertToString(LokasiPemusnahan.RequiredErrorMessage).Replace("%s", LokasiPemusnahan.Caption));
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

            // TanggalDimusnahkan
            TanggalDimusnahkan.SetDbValue(rsnew, ConvertToDateTime(TanggalDimusnahkan.CurrentValue, TanggalDimusnahkan.FormatPattern), TanggalDimusnahkan.ReadOnly);

            // LokasiPemusnahan
            LokasiPemusnahan.SetDbValue(rsnew, LokasiPemusnahan.CurrentValue, LokasiPemusnahan.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("TanggalDimusnahkan", out value)) // TanggalDimusnahkan
                TanggalDimusnahkan.CurrentValue = value;
            if (row.TryGetValue("LokasiPemusnahan", out value)) // LokasiPemusnahan
                LokasiPemusnahan.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("PenyimpananSampleList")), "", TableVar, true);
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
