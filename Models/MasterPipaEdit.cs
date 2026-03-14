namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterPipaEdit
    /// </summary>
    public static MasterPipaEdit masterPipaEdit
    {
        get => HttpData.Get<MasterPipaEdit>("masterPipaEdit")!;
        set => HttpData["masterPipaEdit"] = value;
    }

    /// <summary>
    /// Page class for MasterPipa
    /// </summary>
    public class MasterPipaEdit : MasterPipaEditBase
    {
        // Constructor
        public MasterPipaEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterPipaEdit() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            idPlantAsal.DisplayValueSeparator = " - ";
            idPlantTujuan.DisplayValueSeparator = " - ";
            idPlantTujuan2.DisplayValueSeparator = " - ";
            idPlantTujuan3.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MasterPipaEditBase : MasterPipa
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterPipaEdit";

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
        public MasterPipaEditBase()
        {
            TableName = "MasterPipa";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterPipa)
            if (masterPipa == null || masterPipa is MasterPipa)
                masterPipa = this;

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
        public string PageName => "MasterPipaEdit";

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
            KeteranganPipa.SetVisibility();
            idPlantAsal.SetVisibility();
            idPlantTujuan.Visible = false;
            Panjang.Visible = false;
            Diameter.Visible = false;
            Volume.Visible = false;
            Flowrate.SetVisibility();
            idPlantTujuan2.Visible = false;
            Panjang2.Visible = false;
            Diameter2.Visible = false;
            Volume2.Visible = false;
            Flowrate2.Visible = false;
            idPlantTujuan3.Visible = false;
            Panjang3.Visible = false;
            Diameter3.Visible = false;
            Volume3.Visible = false;
            Flowrate3.Visible = false;
            BiayaProject.SetVisibility();
            PlantAsal.SetVisibility();
            NamaPlantAsal.SetVisibility();
            PlantTujuan.Visible = false;
            NamaPlantTujuan.Visible = false;
            PlantTujuan2.Visible = false;
            NamaPlantTujuan2.Visible = false;
            PlantTujuan3.Visible = false;
            NamaPlantTujuan3.Visible = false;
            CreatedBy.Visible = false;
            etlDate.Visible = false;
            LastUpdatedBy.Visible = false;
            LastUpdatedDate.Visible = false;
        }

        // Constructor
        public MasterPipaEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "MasterPipaView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(idPlantAsal);
            await SetupLookupOptions(idPlantTujuan);
            await SetupLookupOptions(idPlantTujuan2);
            await SetupLookupOptions(idPlantTujuan3);

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
                            return Terminate("MasterPipaList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "MasterPipaList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MasterPipaList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MasterPipaList"; // Return list page content
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
                masterPipaEdit?.PageRender();
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

            // Check field name 'KeteranganPipa' before field var 'x_KeteranganPipa'
            val = CurrentForm.HasValue("KeteranganPipa") ? CurrentForm.GetValue("KeteranganPipa") : CurrentForm.GetValue("x_KeteranganPipa");
            if (!KeteranganPipa.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("KeteranganPipa") && !CurrentForm.HasValue("x_KeteranganPipa")) // DN
                    KeteranganPipa.Visible = false; // Disable update for API request
                else
                    KeteranganPipa.SetFormValue(val);
            }

            // Check field name 'idPlantAsal' before field var 'x_idPlantAsal'
            val = CurrentForm.HasValue("idPlantAsal") ? CurrentForm.GetValue("idPlantAsal") : CurrentForm.GetValue("x_idPlantAsal");
            if (!idPlantAsal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("idPlantAsal") && !CurrentForm.HasValue("x_idPlantAsal")) // DN
                    idPlantAsal.Visible = false; // Disable update for API request
                else
                    idPlantAsal.SetFormValue(val);
            }

            // Check field name 'Flowrate' before field var 'x_Flowrate'
            val = CurrentForm.HasValue("Flowrate") ? CurrentForm.GetValue("Flowrate") : CurrentForm.GetValue("x_Flowrate");
            if (!Flowrate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Flowrate") && !CurrentForm.HasValue("x_Flowrate")) // DN
                    Flowrate.Visible = false; // Disable update for API request
                else
                    Flowrate.SetFormValue(val, true, validate);
            }

            // Check field name 'BiayaProject' before field var 'x_BiayaProject'
            val = CurrentForm.HasValue("BiayaProject") ? CurrentForm.GetValue("BiayaProject") : CurrentForm.GetValue("x_BiayaProject");
            if (!BiayaProject.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BiayaProject") && !CurrentForm.HasValue("x_BiayaProject")) // DN
                    BiayaProject.Visible = false; // Disable update for API request
                else
                    BiayaProject.SetFormValue(val, true, validate);
            }

            // Check field name 'PlantAsal' before field var 'x_PlantAsal'
            val = CurrentForm.HasValue("PlantAsal") ? CurrentForm.GetValue("PlantAsal") : CurrentForm.GetValue("x_PlantAsal");
            if (!PlantAsal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PlantAsal") && !CurrentForm.HasValue("x_PlantAsal")) // DN
                    PlantAsal.Visible = false; // Disable update for API request
                else
                    PlantAsal.SetFormValue(val);
            }

            // Check field name 'NamaPlantAsal' before field var 'x_NamaPlantAsal'
            val = CurrentForm.HasValue("NamaPlantAsal") ? CurrentForm.GetValue("NamaPlantAsal") : CurrentForm.GetValue("x_NamaPlantAsal");
            if (!NamaPlantAsal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaPlantAsal") && !CurrentForm.HasValue("x_NamaPlantAsal")) // DN
                    NamaPlantAsal.Visible = false; // Disable update for API request
                else
                    NamaPlantAsal.SetFormValue(val);
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
            KeteranganPipa.CurrentValue = KeteranganPipa.FormValue;
            idPlantAsal.CurrentValue = idPlantAsal.FormValue;
            Flowrate.CurrentValue = Flowrate.FormValue;
            BiayaProject.CurrentValue = BiayaProject.FormValue;
            PlantAsal.CurrentValue = PlantAsal.FormValue;
            NamaPlantAsal.CurrentValue = NamaPlantAsal.FormValue;
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
            KeteranganPipa.SetDbValue(row["KeteranganPipa"]);
            idPlantAsal.SetDbValue(row["idPlantAsal"]);
            idPlantTujuan.SetDbValue(row["idPlantTujuan"]);
            Panjang.SetDbValue(IsNull(row["Panjang"]) ? DbNullValue : ConvertToDouble(row["Panjang"]));
            Diameter.SetDbValue(IsNull(row["Diameter"]) ? DbNullValue : ConvertToDouble(row["Diameter"]));
            Volume.SetDbValue(IsNull(row["Volume"]) ? DbNullValue : ConvertToDouble(row["Volume"]));
            Flowrate.SetDbValue(IsNull(row["Flowrate"]) ? DbNullValue : ConvertToDouble(row["Flowrate"]));
            idPlantTujuan2.SetDbValue(row["idPlantTujuan2"]);
            Panjang2.SetDbValue(IsNull(row["Panjang2"]) ? DbNullValue : ConvertToDouble(row["Panjang2"]));
            Diameter2.SetDbValue(IsNull(row["Diameter2"]) ? DbNullValue : ConvertToDouble(row["Diameter2"]));
            Volume2.SetDbValue(IsNull(row["Volume2"]) ? DbNullValue : ConvertToDouble(row["Volume2"]));
            Flowrate2.SetDbValue(IsNull(row["Flowrate2"]) ? DbNullValue : ConvertToDouble(row["Flowrate2"]));
            idPlantTujuan3.SetDbValue(row["idPlantTujuan3"]);
            Panjang3.SetDbValue(IsNull(row["Panjang3"]) ? DbNullValue : ConvertToDouble(row["Panjang3"]));
            Diameter3.SetDbValue(IsNull(row["Diameter3"]) ? DbNullValue : ConvertToDouble(row["Diameter3"]));
            Volume3.SetDbValue(IsNull(row["Volume3"]) ? DbNullValue : ConvertToDouble(row["Volume3"]));
            Flowrate3.SetDbValue(IsNull(row["Flowrate3"]) ? DbNullValue : ConvertToDouble(row["Flowrate3"]));
            BiayaProject.SetDbValue(IsNull(row["BiayaProject"]) ? DbNullValue : ConvertToDouble(row["BiayaProject"]));
            PlantAsal.SetDbValue(row["PlantAsal"]);
            NamaPlantAsal.SetDbValue(row["NamaPlantAsal"]);
            PlantTujuan.SetDbValue(row["PlantTujuan"]);
            NamaPlantTujuan.SetDbValue(row["NamaPlantTujuan"]);
            PlantTujuan2.SetDbValue(row["PlantTujuan2"]);
            NamaPlantTujuan2.SetDbValue(row["NamaPlantTujuan2"]);
            PlantTujuan3.SetDbValue(row["PlantTujuan3"]);
            NamaPlantTujuan3.SetDbValue(row["NamaPlantTujuan3"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDate.SetDbValue(row["LastUpdatedDate"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("KeteranganPipa", KeteranganPipa.DefaultValue ?? DbNullValue); // DN
            row.Add("idPlantAsal", idPlantAsal.DefaultValue ?? DbNullValue); // DN
            row.Add("idPlantTujuan", idPlantTujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("Panjang", Panjang.DefaultValue ?? DbNullValue); // DN
            row.Add("Diameter", Diameter.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume", Volume.DefaultValue ?? DbNullValue); // DN
            row.Add("Flowrate", Flowrate.DefaultValue ?? DbNullValue); // DN
            row.Add("idPlantTujuan2", idPlantTujuan2.DefaultValue ?? DbNullValue); // DN
            row.Add("Panjang2", Panjang2.DefaultValue ?? DbNullValue); // DN
            row.Add("Diameter2", Diameter2.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume2", Volume2.DefaultValue ?? DbNullValue); // DN
            row.Add("Flowrate2", Flowrate2.DefaultValue ?? DbNullValue); // DN
            row.Add("idPlantTujuan3", idPlantTujuan3.DefaultValue ?? DbNullValue); // DN
            row.Add("Panjang3", Panjang3.DefaultValue ?? DbNullValue); // DN
            row.Add("Diameter3", Diameter3.DefaultValue ?? DbNullValue); // DN
            row.Add("Volume3", Volume3.DefaultValue ?? DbNullValue); // DN
            row.Add("Flowrate3", Flowrate3.DefaultValue ?? DbNullValue); // DN
            row.Add("BiayaProject", BiayaProject.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantAsal", PlantAsal.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaPlantAsal", NamaPlantAsal.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantTujuan", PlantTujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaPlantTujuan", NamaPlantTujuan.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantTujuan2", PlantTujuan2.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaPlantTujuan2", NamaPlantTujuan2.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantTujuan3", PlantTujuan3.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaPlantTujuan3", NamaPlantTujuan3.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDate", LastUpdatedDate.DefaultValue ?? DbNullValue); // DN
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

            // KeteranganPipa
            KeteranganPipa.RowCssClass = "row";

            // idPlantAsal
            idPlantAsal.RowCssClass = "row";

            // idPlantTujuan
            idPlantTujuan.RowCssClass = "row";

            // Panjang
            Panjang.RowCssClass = "row";

            // Diameter
            Diameter.RowCssClass = "row";

            // Volume
            Volume.RowCssClass = "row";

            // Flowrate
            Flowrate.RowCssClass = "row";

            // idPlantTujuan2
            idPlantTujuan2.RowCssClass = "row";

            // Panjang2
            Panjang2.RowCssClass = "row";

            // Diameter2
            Diameter2.RowCssClass = "row";

            // Volume2
            Volume2.RowCssClass = "row";

            // Flowrate2
            Flowrate2.RowCssClass = "row";

            // idPlantTujuan3
            idPlantTujuan3.RowCssClass = "row";

            // Panjang3
            Panjang3.RowCssClass = "row";

            // Diameter3
            Diameter3.RowCssClass = "row";

            // Volume3
            Volume3.RowCssClass = "row";

            // Flowrate3
            Flowrate3.RowCssClass = "row";

            // BiayaProject
            BiayaProject.RowCssClass = "row";

            // PlantAsal
            PlantAsal.RowCssClass = "row";

            // NamaPlantAsal
            NamaPlantAsal.RowCssClass = "row";

            // PlantTujuan
            PlantTujuan.RowCssClass = "row";

            // NamaPlantTujuan
            NamaPlantTujuan.RowCssClass = "row";

            // PlantTujuan2
            PlantTujuan2.RowCssClass = "row";

            // NamaPlantTujuan2
            NamaPlantTujuan2.RowCssClass = "row";

            // PlantTujuan3
            PlantTujuan3.RowCssClass = "row";

            // NamaPlantTujuan3
            NamaPlantTujuan3.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // etlDate
            etlDate.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // LastUpdatedDate
            LastUpdatedDate.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // id
                id.ViewValue = id.CurrentValue;
                id.ViewCustomAttributes = "";

                // KeteranganPipa
                KeteranganPipa.ViewValue = ConvertToString(KeteranganPipa.CurrentValue); // DN
                KeteranganPipa.ViewCustomAttributes = "";

                // idPlantAsal
                string curVal = ConvertToString(idPlantAsal.CurrentValue);
                if (!Empty(curVal)) {
                    if (idPlantAsal.Lookup != null && IsDictionary(idPlantAsal.Lookup?.Options) && idPlantAsal.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idPlantAsal.ViewValue = idPlantAsal.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(idPlantAsal.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantAsal.CurrentValue, idPlantAsal.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk = idPlantAsal.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && idPlantAsal.Lookup != null) { // Lookup values found
                            var listwrk = idPlantAsal.Lookup?.RenderViewRow(rswrk[0]);
                            idPlantAsal.ViewValue = idPlantAsal.DisplayValue(listwrk);
                        } else {
                            idPlantAsal.ViewValue = FormatNumber(idPlantAsal.CurrentValue, idPlantAsal.FormatPattern);
                        }
                    }
                } else {
                    idPlantAsal.ViewValue = DbNullValue;
                }
                idPlantAsal.ViewCustomAttributes = "";

                // idPlantTujuan
                string curVal2 = ConvertToString(idPlantTujuan.CurrentValue);
                if (!Empty(curVal2)) {
                    if (idPlantTujuan.Lookup != null && IsDictionary(idPlantTujuan.Lookup?.Options) && idPlantTujuan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idPlantTujuan.ViewValue = idPlantTujuan.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(idPlantTujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan.CurrentValue, idPlantTujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk2 = idPlantTujuan.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && idPlantTujuan.Lookup != null) { // Lookup values found
                            var listwrk = idPlantTujuan.Lookup?.RenderViewRow(rswrk2[0]);
                            idPlantTujuan.ViewValue = idPlantTujuan.DisplayValue(listwrk);
                        } else {
                            idPlantTujuan.ViewValue = FormatNumber(idPlantTujuan.CurrentValue, idPlantTujuan.FormatPattern);
                        }
                    }
                } else {
                    idPlantTujuan.ViewValue = DbNullValue;
                }
                idPlantTujuan.ViewCustomAttributes = "";

                // Panjang
                Panjang.ViewValue = Panjang.CurrentValue;
                Panjang.ViewValue = FormatNumber(Panjang.ViewValue, Panjang.FormatPattern);
                Panjang.ViewCustomAttributes = "";

                // Diameter
                Diameter.ViewValue = Diameter.CurrentValue;
                Diameter.ViewValue = FormatNumber(Diameter.ViewValue, Diameter.FormatPattern);
                Diameter.ViewCustomAttributes = "";

                // Volume
                Volume.ViewValue = Volume.CurrentValue;
                Volume.ViewValue = FormatNumber(Volume.ViewValue, Volume.FormatPattern);
                Volume.ViewCustomAttributes = "";

                // Flowrate
                Flowrate.ViewValue = Flowrate.CurrentValue;
                Flowrate.ViewValue = FormatNumber(Flowrate.ViewValue, Flowrate.FormatPattern);
                Flowrate.ViewCustomAttributes = "";

                // idPlantTujuan2
                string curVal3 = ConvertToString(idPlantTujuan2.CurrentValue);
                if (!Empty(curVal3)) {
                    if (idPlantTujuan2.Lookup != null && IsDictionary(idPlantTujuan2.Lookup?.Options) && idPlantTujuan2.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idPlantTujuan2.ViewValue = idPlantTujuan2.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(idPlantTujuan2.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan2.CurrentValue, idPlantTujuan2.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk3 = idPlantTujuan2.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && idPlantTujuan2.Lookup != null) { // Lookup values found
                            var listwrk = idPlantTujuan2.Lookup?.RenderViewRow(rswrk3[0]);
                            idPlantTujuan2.ViewValue = idPlantTujuan2.DisplayValue(listwrk);
                        } else {
                            idPlantTujuan2.ViewValue = FormatNumber(idPlantTujuan2.CurrentValue, idPlantTujuan2.FormatPattern);
                        }
                    }
                } else {
                    idPlantTujuan2.ViewValue = DbNullValue;
                }
                idPlantTujuan2.ViewCustomAttributes = "";

                // Panjang2
                Panjang2.ViewValue = Panjang2.CurrentValue;
                Panjang2.ViewValue = FormatNumber(Panjang2.ViewValue, Panjang2.FormatPattern);
                Panjang2.ViewCustomAttributes = "";

                // Diameter2
                Diameter2.ViewValue = Diameter2.CurrentValue;
                Diameter2.ViewValue = FormatNumber(Diameter2.ViewValue, Diameter2.FormatPattern);
                Diameter2.ViewCustomAttributes = "";

                // Volume2
                Volume2.ViewValue = Volume2.CurrentValue;
                Volume2.ViewValue = FormatNumber(Volume2.ViewValue, Volume2.FormatPattern);
                Volume2.ViewCustomAttributes = "";

                // Flowrate2
                Flowrate2.ViewValue = Flowrate2.CurrentValue;
                Flowrate2.ViewValue = FormatNumber(Flowrate2.ViewValue, Flowrate2.FormatPattern);
                Flowrate2.ViewCustomAttributes = "";

                // idPlantTujuan3
                string curVal4 = ConvertToString(idPlantTujuan3.CurrentValue);
                if (!Empty(curVal4)) {
                    if (idPlantTujuan3.Lookup != null && IsDictionary(idPlantTujuan3.Lookup?.Options) && idPlantTujuan3.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        idPlantTujuan3.ViewValue = idPlantTujuan3.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(idPlantTujuan3.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan3.CurrentValue, idPlantTujuan3.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                        string? sqlWrk4 = idPlantTujuan3.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && idPlantTujuan3.Lookup != null) { // Lookup values found
                            var listwrk = idPlantTujuan3.Lookup?.RenderViewRow(rswrk4[0]);
                            idPlantTujuan3.ViewValue = idPlantTujuan3.DisplayValue(listwrk);
                        } else {
                            idPlantTujuan3.ViewValue = FormatNumber(idPlantTujuan3.CurrentValue, idPlantTujuan3.FormatPattern);
                        }
                    }
                } else {
                    idPlantTujuan3.ViewValue = DbNullValue;
                }
                idPlantTujuan3.ViewCustomAttributes = "";

                // Panjang3
                Panjang3.ViewValue = Panjang3.CurrentValue;
                Panjang3.ViewValue = FormatNumber(Panjang3.ViewValue, Panjang3.FormatPattern);
                Panjang3.ViewCustomAttributes = "";

                // Diameter3
                Diameter3.ViewValue = Diameter3.CurrentValue;
                Diameter3.ViewValue = FormatNumber(Diameter3.ViewValue, Diameter3.FormatPattern);
                Diameter3.ViewCustomAttributes = "";

                // Volume3
                Volume3.ViewValue = Volume3.CurrentValue;
                Volume3.ViewValue = FormatNumber(Volume3.ViewValue, Volume3.FormatPattern);
                Volume3.ViewCustomAttributes = "";

                // Flowrate3
                Flowrate3.ViewValue = Flowrate3.CurrentValue;
                Flowrate3.ViewValue = FormatNumber(Flowrate3.ViewValue, Flowrate3.FormatPattern);
                Flowrate3.ViewCustomAttributes = "";

                // BiayaProject
                BiayaProject.ViewValue = BiayaProject.CurrentValue;
                BiayaProject.ViewValue = FormatNumber(BiayaProject.ViewValue, BiayaProject.FormatPattern);
                BiayaProject.ViewCustomAttributes = "";

                // PlantAsal
                PlantAsal.ViewValue = ConvertToString(PlantAsal.CurrentValue); // DN
                PlantAsal.ViewCustomAttributes = "";

                // NamaPlantAsal
                NamaPlantAsal.ViewValue = ConvertToString(NamaPlantAsal.CurrentValue); // DN
                NamaPlantAsal.ViewCustomAttributes = "";

                // PlantTujuan
                PlantTujuan.ViewValue = ConvertToString(PlantTujuan.CurrentValue); // DN
                PlantTujuan.ViewCustomAttributes = "";

                // NamaPlantTujuan
                NamaPlantTujuan.ViewValue = ConvertToString(NamaPlantTujuan.CurrentValue); // DN
                NamaPlantTujuan.ViewCustomAttributes = "";

                // PlantTujuan2
                PlantTujuan2.ViewValue = ConvertToString(PlantTujuan2.CurrentValue); // DN
                PlantTujuan2.ViewCustomAttributes = "";

                // NamaPlantTujuan2
                NamaPlantTujuan2.ViewValue = ConvertToString(NamaPlantTujuan2.CurrentValue); // DN
                NamaPlantTujuan2.ViewCustomAttributes = "";

                // PlantTujuan3
                PlantTujuan3.ViewValue = ConvertToString(PlantTujuan3.CurrentValue); // DN
                PlantTujuan3.ViewCustomAttributes = "";

                // NamaPlantTujuan3
                NamaPlantTujuan3.ViewValue = ConvertToString(NamaPlantTujuan3.CurrentValue); // DN
                NamaPlantTujuan3.ViewCustomAttributes = "";

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

                // LastUpdatedDate
                LastUpdatedDate.ViewValue = LastUpdatedDate.CurrentValue;
                LastUpdatedDate.ViewValue = FormatDateTime(LastUpdatedDate.ViewValue, LastUpdatedDate.FormatPattern);
                LastUpdatedDate.ViewCustomAttributes = "";

                // KeteranganPipa
                KeteranganPipa.HrefValue = "";

                // idPlantAsal
                idPlantAsal.HrefValue = "";

                // Flowrate
                Flowrate.HrefValue = "";

                // BiayaProject
                BiayaProject.HrefValue = "";

                // PlantAsal
                PlantAsal.HrefValue = "";

                // NamaPlantAsal
                NamaPlantAsal.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // KeteranganPipa
                KeteranganPipa.SetupEditAttributes();
                if (!KeteranganPipa.Raw)
                    KeteranganPipa.CurrentValue = HtmlDecode(KeteranganPipa.CurrentValue);
                KeteranganPipa.EditValue = HtmlEncode(KeteranganPipa.CurrentValue);
                KeteranganPipa.PlaceHolder = RemoveHtml(KeteranganPipa.Caption);

                // idPlantAsal
                idPlantAsal.SetupEditAttributes();
                string curVal = ConvertToString(idPlantAsal.CurrentValue);
                if (idPlantAsal.Lookup != null && IsDictionary(idPlantAsal.Lookup?.Options) && idPlantAsal.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idPlantAsal.EditValue = idPlantAsal.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk = "";
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter(idPlantAsal.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantAsal.CurrentValue, idPlantAsal.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk = idPlantAsal.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    idPlantAsal.EditValue = rswrk;
                }
                idPlantAsal.PlaceHolder = RemoveHtml(idPlantAsal.Caption);
                if (!Empty(idPlantAsal.EditValue) && IsNumeric(idPlantAsal.EditValue))
                    idPlantAsal.EditValue = FormatNumber(idPlantAsal.EditValue, null);

                // Flowrate
                Flowrate.SetupEditAttributes();
                Flowrate.EditValue = Flowrate.CurrentValue;
                Flowrate.PlaceHolder = RemoveHtml(Flowrate.Caption);
                if (!Empty(Flowrate.EditValue) && IsNumeric(Flowrate.EditValue))
                    Flowrate.EditValue = FormatNumber(Flowrate.EditValue, null);

                // BiayaProject
                BiayaProject.SetupEditAttributes();
                BiayaProject.EditValue = BiayaProject.CurrentValue;
                BiayaProject.PlaceHolder = RemoveHtml(BiayaProject.Caption);
                if (!Empty(BiayaProject.EditValue) && IsNumeric(BiayaProject.EditValue))
                    BiayaProject.EditValue = FormatNumber(BiayaProject.EditValue, null);

                // PlantAsal
                PlantAsal.SetupEditAttributes();
                if (!PlantAsal.Raw)
                    PlantAsal.CurrentValue = HtmlDecode(PlantAsal.CurrentValue);
                PlantAsal.EditValue = HtmlEncode(PlantAsal.CurrentValue);
                PlantAsal.PlaceHolder = RemoveHtml(PlantAsal.Caption);

                // NamaPlantAsal
                NamaPlantAsal.SetupEditAttributes();
                if (!NamaPlantAsal.Raw)
                    NamaPlantAsal.CurrentValue = HtmlDecode(NamaPlantAsal.CurrentValue);
                NamaPlantAsal.EditValue = HtmlEncode(NamaPlantAsal.CurrentValue);
                NamaPlantAsal.PlaceHolder = RemoveHtml(NamaPlantAsal.Caption);

                // Edit refer script

                // KeteranganPipa
                KeteranganPipa.HrefValue = "";

                // idPlantAsal
                idPlantAsal.HrefValue = "";

                // Flowrate
                Flowrate.HrefValue = "";

                // BiayaProject
                BiayaProject.HrefValue = "";

                // PlantAsal
                PlantAsal.HrefValue = "";

                // NamaPlantAsal
                NamaPlantAsal.HrefValue = "";
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
                if (KeteranganPipa.Visible && KeteranganPipa.Required) {
                    if (!KeteranganPipa.IsDetailKey && Empty(KeteranganPipa.FormValue)) {
                        KeteranganPipa.AddErrorMessage(ConvertToString(KeteranganPipa.RequiredErrorMessage).Replace("%s", KeteranganPipa.Caption));
                    }
                }
                if (idPlantAsal.Visible && idPlantAsal.Required) {
                    if (!idPlantAsal.IsDetailKey && Empty(idPlantAsal.FormValue)) {
                        idPlantAsal.AddErrorMessage(ConvertToString(idPlantAsal.RequiredErrorMessage).Replace("%s", idPlantAsal.Caption));
                    }
                }
                if (Flowrate.Visible && Flowrate.Required) {
                    if (!Flowrate.IsDetailKey && Empty(Flowrate.FormValue)) {
                        Flowrate.AddErrorMessage(ConvertToString(Flowrate.RequiredErrorMessage).Replace("%s", Flowrate.Caption));
                    }
                }
                if (!CheckNumber(Flowrate.FormValue)) {
                    Flowrate.AddErrorMessage(Flowrate.GetErrorMessage(false));
                }
                if (BiayaProject.Visible && BiayaProject.Required) {
                    if (!BiayaProject.IsDetailKey && Empty(BiayaProject.FormValue)) {
                        BiayaProject.AddErrorMessage(ConvertToString(BiayaProject.RequiredErrorMessage).Replace("%s", BiayaProject.Caption));
                    }
                }
                if (!CheckNumber(BiayaProject.FormValue)) {
                    BiayaProject.AddErrorMessage(BiayaProject.GetErrorMessage(false));
                }
                if (PlantAsal.Visible && PlantAsal.Required) {
                    if (!PlantAsal.IsDetailKey && Empty(PlantAsal.FormValue)) {
                        PlantAsal.AddErrorMessage(ConvertToString(PlantAsal.RequiredErrorMessage).Replace("%s", PlantAsal.Caption));
                    }
                }
                if (NamaPlantAsal.Visible && NamaPlantAsal.Required) {
                    if (!NamaPlantAsal.IsDetailKey && Empty(NamaPlantAsal.FormValue)) {
                        NamaPlantAsal.AddErrorMessage(ConvertToString(NamaPlantAsal.RequiredErrorMessage).Replace("%s", NamaPlantAsal.Caption));
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

            // KeteranganPipa
            KeteranganPipa.SetDbValue(rsnew, KeteranganPipa.CurrentValue, KeteranganPipa.ReadOnly);

            // idPlantAsal
            idPlantAsal.SetDbValue(rsnew, idPlantAsal.CurrentValue, idPlantAsal.ReadOnly);

            // Flowrate
            Flowrate.SetDbValue(rsnew, Flowrate.CurrentValue, Flowrate.ReadOnly);

            // BiayaProject
            BiayaProject.SetDbValue(rsnew, BiayaProject.CurrentValue, BiayaProject.ReadOnly);

            // PlantAsal
            PlantAsal.SetDbValue(rsnew, PlantAsal.CurrentValue, PlantAsal.ReadOnly);

            // NamaPlantAsal
            NamaPlantAsal.SetDbValue(rsnew, NamaPlantAsal.CurrentValue, NamaPlantAsal.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("KeteranganPipa", out value)) // KeteranganPipa
                KeteranganPipa.CurrentValue = value;
            if (row.TryGetValue("idPlantAsal", out value)) // idPlantAsal
                idPlantAsal.CurrentValue = value;
            if (row.TryGetValue("Flowrate", out value)) // Flowrate
                Flowrate.CurrentValue = value;
            if (row.TryGetValue("BiayaProject", out value)) // BiayaProject
                BiayaProject.CurrentValue = value;
            if (row.TryGetValue("PlantAsal", out value)) // PlantAsal
                PlantAsal.CurrentValue = value;
            if (row.TryGetValue("NamaPlantAsal", out value)) // NamaPlantAsal
                NamaPlantAsal.CurrentValue = value;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterPipaList")), "", TableVar, true);
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
