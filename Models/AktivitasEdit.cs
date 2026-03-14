namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// aktivitasEdit
    /// </summary>
    public static AktivitasEdit aktivitasEdit
    {
        get => HttpData.Get<AktivitasEdit>("aktivitasEdit")!;
        set => HttpData["aktivitasEdit"] = value;
    }

    /// <summary>
    /// Page class for Aktivitas
    /// </summary>
    public class AktivitasEdit : AktivitasEditBase
    {
        // Constructor
        public AktivitasEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public AktivitasEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class AktivitasEditBase : Aktivitas
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "aktivitasEdit";

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
        public AktivitasEditBase()
        {
            TableName = "Aktivitas";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (aktivitas)
            if (aktivitas == null || aktivitas is Aktivitas)
                aktivitas = this;

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
        public string PageName => "AktivitasEdit";

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
            IdAktivitas.Visible = false;
            No_Referensi.SetVisibility();
            IdProses.SetVisibility();
            IdTemplateAktivitas.SetVisibility();
            Aktivitas2.SetVisibility();
            NamaAktivitas.SetVisibility();
            PIC.SetVisibility();
            TanggalMulai.SetVisibility();
            TanggalSelesai.SetVisibility();
            StatusAktivitas.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            TipeAktivitas.SetVisibility();
            sandar_nama_kapal.SetVisibility();
            sandar_tgl_tiba.SetVisibility();
            sandar_nominasi.SetVisibility();
            Produk.SetVisibility();
            Shipment.SetVisibility();
            Nama_Proses.SetVisibility();
            IdDokumen.SetVisibility();
            PathFile.SetVisibility();
            TanggalUploadDok.SetVisibility();
            UserUploadDok.SetVisibility();
            NamaDokumen.SetVisibility();
            Keterangan.SetVisibility();
            IdRefAnak.SetVisibility();
            TableAnak.SetVisibility();
            TipeProses.SetVisibility();
            Urutan.SetVisibility();
            IsNominationTankReceivingLineOpen.SetVisibility();
            IsNonNominationReceivingLineClosedAndSealed.SetVisibility();
            IsTankEmptyAndDry.SetVisibility();
            IsDocumentationComplete.SetVisibility();
        }

        // Constructor
        public AktivitasEditBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "AktivitasView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdAktivitas") ? dict["IdAktivitas"] : IdAktivitas.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdAktivitas.Visible = false;
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
            await SetupLookupOptions(IdProses);
            await SetupLookupOptions(IdTemplateAktivitas);
            await SetupLookupOptions(TipeAktivitas);
            await SetupLookupOptions(IsNominationTankReceivingLineOpen);
            await SetupLookupOptions(IsNonNominationReceivingLineClosedAndSealed);
            await SetupLookupOptions(IsTankEmptyAndDry);
            await SetupLookupOptions(IsDocumentationComplete);

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
                if (RouteValues.TryGetValue("IdAktivitas", out rv)) { // DN
                    IdAktivitas.FormValue = UrlDecode(rv); // DN
                    IdAktivitas.OldValue = IdAktivitas.FormValue;
                } else if (CurrentForm.HasValue("x_IdAktivitas")) {
                    IdAktivitas.FormValue = CurrentForm.GetValue("x_IdAktivitas");
                    IdAktivitas.OldValue = IdAktivitas.FormValue;
                } else if (!Empty(keyValues)) {
                    IdAktivitas.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("IdAktivitas", out rv)) { // DN
                        IdAktivitas.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("IdAktivitas", out sv)) {
                        IdAktivitas.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdAktivitas.CurrentValue = DbNullValue;
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
                IdAktivitas.FormValue = ConvertToString(keyValues[0]);
            }

            // Set up detail parameters
            SetupDetailParms();
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
                            return Terminate("AktivitasList"); // No matching record, return to list
                        }

                    // Set up detail parameters
                    SetupDetailParms();
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = "";
                    if (!Empty(CurrentDetailTable)) // Master/detail edit
                        returnUrl = GetViewUrl(Config.TableShowDetail + "=" + CurrentDetailTable); // Master/Detail view page
                    else
                        returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "AktivitasList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) { // Update record based on key
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success

                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "AktivitasList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "AktivitasList"; // Return list page content
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

                        // Set up detail parameters
                        SetupDetailParms();
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
                aktivitasEdit?.PageRender();
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

            // Check field name 'No_Referensi' before field var 'x_No_Referensi'
            val = CurrentForm.HasValue("No_Referensi") ? CurrentForm.GetValue("No_Referensi") : CurrentForm.GetValue("x_No_Referensi");
            if (!No_Referensi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("No_Referensi") && !CurrentForm.HasValue("x_No_Referensi")) // DN
                    No_Referensi.Visible = false; // Disable update for API request
                else
                    No_Referensi.SetFormValue(val);
            }

            // Check field name 'IdProses' before field var 'x_IdProses'
            val = CurrentForm.HasValue("IdProses") ? CurrentForm.GetValue("IdProses") : CurrentForm.GetValue("x_IdProses");
            if (!IdProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdProses") && !CurrentForm.HasValue("x_IdProses")) // DN
                    IdProses.Visible = false; // Disable update for API request
                else
                    IdProses.SetFormValue(val);
            }

            // Check field name 'IdTemplateAktivitas' before field var 'x_IdTemplateAktivitas'
            val = CurrentForm.HasValue("IdTemplateAktivitas") ? CurrentForm.GetValue("IdTemplateAktivitas") : CurrentForm.GetValue("x_IdTemplateAktivitas");
            if (!IdTemplateAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdTemplateAktivitas") && !CurrentForm.HasValue("x_IdTemplateAktivitas")) // DN
                    IdTemplateAktivitas.Visible = false; // Disable update for API request
                else
                    IdTemplateAktivitas.SetFormValue(val);
            }

            // Check field name 'Aktivitas' before field var 'x_Aktivitas2'
            val = CurrentForm.HasValue("Aktivitas") ? CurrentForm.GetValue("Aktivitas") : CurrentForm.GetValue("x_Aktivitas2");
            if (!Aktivitas2.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Aktivitas") && !CurrentForm.HasValue("x_Aktivitas2")) // DN
                    Aktivitas2.Visible = false; // Disable update for API request
                else
                    Aktivitas2.SetFormValue(val);
            }

            // Check field name 'NamaAktivitas' before field var 'x_NamaAktivitas'
            val = CurrentForm.HasValue("NamaAktivitas") ? CurrentForm.GetValue("NamaAktivitas") : CurrentForm.GetValue("x_NamaAktivitas");
            if (!NamaAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaAktivitas") && !CurrentForm.HasValue("x_NamaAktivitas")) // DN
                    NamaAktivitas.Visible = false; // Disable update for API request
                else
                    NamaAktivitas.SetFormValue(val);
            }

            // Check field name 'PIC' before field var 'x_PIC'
            val = CurrentForm.HasValue("PIC") ? CurrentForm.GetValue("PIC") : CurrentForm.GetValue("x_PIC");
            if (!PIC.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PIC") && !CurrentForm.HasValue("x_PIC")) // DN
                    PIC.Visible = false; // Disable update for API request
                else
                    PIC.SetFormValue(val);
            }

            // Check field name 'TanggalMulai' before field var 'x_TanggalMulai'
            val = CurrentForm.HasValue("TanggalMulai") ? CurrentForm.GetValue("TanggalMulai") : CurrentForm.GetValue("x_TanggalMulai");
            if (!TanggalMulai.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalMulai") && !CurrentForm.HasValue("x_TanggalMulai")) // DN
                    TanggalMulai.Visible = false; // Disable update for API request
                else
                    TanggalMulai.SetFormValue(val, true, validate);
                TanggalMulai.CurrentValue = UnformatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
            }

            // Check field name 'TanggalSelesai' before field var 'x_TanggalSelesai'
            val = CurrentForm.HasValue("TanggalSelesai") ? CurrentForm.GetValue("TanggalSelesai") : CurrentForm.GetValue("x_TanggalSelesai");
            if (!TanggalSelesai.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalSelesai") && !CurrentForm.HasValue("x_TanggalSelesai")) // DN
                    TanggalSelesai.Visible = false; // Disable update for API request
                else
                    TanggalSelesai.SetFormValue(val, true, validate);
                TanggalSelesai.CurrentValue = UnformatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
            }

            // Check field name 'StatusAktivitas' before field var 'x_StatusAktivitas'
            val = CurrentForm.HasValue("StatusAktivitas") ? CurrentForm.GetValue("StatusAktivitas") : CurrentForm.GetValue("x_StatusAktivitas");
            if (!StatusAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("StatusAktivitas") && !CurrentForm.HasValue("x_StatusAktivitas")) // DN
                    StatusAktivitas.Visible = false; // Disable update for API request
                else
                    StatusAktivitas.SetFormValue(val);
            }

            // Check field name 'TipeAktivitas' before field var 'x_TipeAktivitas'
            val = CurrentForm.HasValue("TipeAktivitas") ? CurrentForm.GetValue("TipeAktivitas") : CurrentForm.GetValue("x_TipeAktivitas");
            if (!TipeAktivitas.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipeAktivitas") && !CurrentForm.HasValue("x_TipeAktivitas")) // DN
                    TipeAktivitas.Visible = false; // Disable update for API request
                else
                    TipeAktivitas.SetFormValue(val);
            }

            // Check field name 'sandar_nama_kapal' before field var 'x_sandar_nama_kapal'
            val = CurrentForm.HasValue("sandar_nama_kapal") ? CurrentForm.GetValue("sandar_nama_kapal") : CurrentForm.GetValue("x_sandar_nama_kapal");
            if (!sandar_nama_kapal.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("sandar_nama_kapal") && !CurrentForm.HasValue("x_sandar_nama_kapal")) // DN
                    sandar_nama_kapal.Visible = false; // Disable update for API request
                else
                    sandar_nama_kapal.SetFormValue(val);
            }

            // Check field name 'sandar_tgl_tiba' before field var 'x_sandar_tgl_tiba'
            val = CurrentForm.HasValue("sandar_tgl_tiba") ? CurrentForm.GetValue("sandar_tgl_tiba") : CurrentForm.GetValue("x_sandar_tgl_tiba");
            if (!sandar_tgl_tiba.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("sandar_tgl_tiba") && !CurrentForm.HasValue("x_sandar_tgl_tiba")) // DN
                    sandar_tgl_tiba.Visible = false; // Disable update for API request
                else
                    sandar_tgl_tiba.SetFormValue(val, true, validate);
                sandar_tgl_tiba.CurrentValue = UnformatDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern);
            }

            // Check field name 'sandar_nominasi' before field var 'x_sandar_nominasi'
            val = CurrentForm.HasValue("sandar_nominasi") ? CurrentForm.GetValue("sandar_nominasi") : CurrentForm.GetValue("x_sandar_nominasi");
            if (!sandar_nominasi.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("sandar_nominasi") && !CurrentForm.HasValue("x_sandar_nominasi")) // DN
                    sandar_nominasi.Visible = false; // Disable update for API request
                else
                    sandar_nominasi.SetFormValue(val);
            }

            // Check field name 'Produk' before field var 'x_Produk'
            val = CurrentForm.HasValue("Produk") ? CurrentForm.GetValue("Produk") : CurrentForm.GetValue("x_Produk");
            if (!Produk.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Produk") && !CurrentForm.HasValue("x_Produk")) // DN
                    Produk.Visible = false; // Disable update for API request
                else
                    Produk.SetFormValue(val);
            }

            // Check field name 'Shipment' before field var 'x_Shipment'
            val = CurrentForm.HasValue("Shipment") ? CurrentForm.GetValue("Shipment") : CurrentForm.GetValue("x_Shipment");
            if (!Shipment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Shipment") && !CurrentForm.HasValue("x_Shipment")) // DN
                    Shipment.Visible = false; // Disable update for API request
                else
                    Shipment.SetFormValue(val);
            }

            // Check field name 'Nama_Proses' before field var 'x_Nama_Proses'
            val = CurrentForm.HasValue("Nama_Proses") ? CurrentForm.GetValue("Nama_Proses") : CurrentForm.GetValue("x_Nama_Proses");
            if (!Nama_Proses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Nama_Proses") && !CurrentForm.HasValue("x_Nama_Proses")) // DN
                    Nama_Proses.Visible = false; // Disable update for API request
                else
                    Nama_Proses.SetFormValue(val);
            }

            // Check field name 'IdDokumen' before field var 'x_IdDokumen'
            val = CurrentForm.HasValue("IdDokumen") ? CurrentForm.GetValue("IdDokumen") : CurrentForm.GetValue("x_IdDokumen");
            if (!IdDokumen.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdDokumen") && !CurrentForm.HasValue("x_IdDokumen")) // DN
                    IdDokumen.Visible = false; // Disable update for API request
                else
                    IdDokumen.SetFormValue(val, true, validate);
            }

            // Check field name 'PathFile' before field var 'x_PathFile'
            val = CurrentForm.HasValue("PathFile") ? CurrentForm.GetValue("PathFile") : CurrentForm.GetValue("x_PathFile");
            if (!PathFile.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PathFile") && !CurrentForm.HasValue("x_PathFile")) // DN
                    PathFile.Visible = false; // Disable update for API request
                else
                    PathFile.SetFormValue(val);
            }

            // Check field name 'TanggalUploadDok' before field var 'x_TanggalUploadDok'
            val = CurrentForm.HasValue("TanggalUploadDok") ? CurrentForm.GetValue("TanggalUploadDok") : CurrentForm.GetValue("x_TanggalUploadDok");
            if (!TanggalUploadDok.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TanggalUploadDok") && !CurrentForm.HasValue("x_TanggalUploadDok")) // DN
                    TanggalUploadDok.Visible = false; // Disable update for API request
                else
                    TanggalUploadDok.SetFormValue(val, true, validate);
                TanggalUploadDok.CurrentValue = UnformatDateTime(TanggalUploadDok.CurrentValue, TanggalUploadDok.FormatPattern);
            }

            // Check field name 'UserUploadDok' before field var 'x_UserUploadDok'
            val = CurrentForm.HasValue("UserUploadDok") ? CurrentForm.GetValue("UserUploadDok") : CurrentForm.GetValue("x_UserUploadDok");
            if (!UserUploadDok.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("UserUploadDok") && !CurrentForm.HasValue("x_UserUploadDok")) // DN
                    UserUploadDok.Visible = false; // Disable update for API request
                else
                    UserUploadDok.SetFormValue(val);
            }

            // Check field name 'NamaDokumen' before field var 'x_NamaDokumen'
            val = CurrentForm.HasValue("NamaDokumen") ? CurrentForm.GetValue("NamaDokumen") : CurrentForm.GetValue("x_NamaDokumen");
            if (!NamaDokumen.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NamaDokumen") && !CurrentForm.HasValue("x_NamaDokumen")) // DN
                    NamaDokumen.Visible = false; // Disable update for API request
                else
                    NamaDokumen.SetFormValue(val);
            }

            // Check field name 'Keterangan' before field var 'x_Keterangan'
            val = CurrentForm.HasValue("Keterangan") ? CurrentForm.GetValue("Keterangan") : CurrentForm.GetValue("x_Keterangan");
            if (!Keterangan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Keterangan") && !CurrentForm.HasValue("x_Keterangan")) // DN
                    Keterangan.Visible = false; // Disable update for API request
                else
                    Keterangan.SetFormValue(val);
            }

            // Check field name 'IdRefAnak' before field var 'x_IdRefAnak'
            val = CurrentForm.HasValue("IdRefAnak") ? CurrentForm.GetValue("IdRefAnak") : CurrentForm.GetValue("x_IdRefAnak");
            if (!IdRefAnak.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IdRefAnak") && !CurrentForm.HasValue("x_IdRefAnak")) // DN
                    IdRefAnak.Visible = false; // Disable update for API request
                else
                    IdRefAnak.SetFormValue(val, true, validate);
            }

            // Check field name 'TableAnak' before field var 'x_TableAnak'
            val = CurrentForm.HasValue("TableAnak") ? CurrentForm.GetValue("TableAnak") : CurrentForm.GetValue("x_TableAnak");
            if (!TableAnak.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TableAnak") && !CurrentForm.HasValue("x_TableAnak")) // DN
                    TableAnak.Visible = false; // Disable update for API request
                else
                    TableAnak.SetFormValue(val);
            }

            // Check field name 'TipeProses' before field var 'x_TipeProses'
            val = CurrentForm.HasValue("TipeProses") ? CurrentForm.GetValue("TipeProses") : CurrentForm.GetValue("x_TipeProses");
            if (!TipeProses.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TipeProses") && !CurrentForm.HasValue("x_TipeProses")) // DN
                    TipeProses.Visible = false; // Disable update for API request
                else
                    TipeProses.SetFormValue(val);
            }

            // Check field name 'Urutan' before field var 'x_Urutan'
            val = CurrentForm.HasValue("Urutan") ? CurrentForm.GetValue("Urutan") : CurrentForm.GetValue("x_Urutan");
            if (!Urutan.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Urutan") && !CurrentForm.HasValue("x_Urutan")) // DN
                    Urutan.Visible = false; // Disable update for API request
                else
                    Urutan.SetFormValue(val, true, validate);
            }

            // Check field name 'IsNominationTankReceivingLineOpen' before field var 'x_IsNominationTankReceivingLineOpen'
            val = CurrentForm.HasValue("IsNominationTankReceivingLineOpen") ? CurrentForm.GetValue("IsNominationTankReceivingLineOpen") : CurrentForm.GetValue("x_IsNominationTankReceivingLineOpen");
            if (!IsNominationTankReceivingLineOpen.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IsNominationTankReceivingLineOpen") && !CurrentForm.HasValue("x_IsNominationTankReceivingLineOpen")) // DN
                    IsNominationTankReceivingLineOpen.Visible = false; // Disable update for API request
                else
                    IsNominationTankReceivingLineOpen.SetFormValue(val);
            }

            // Check field name 'IsNonNominationReceivingLineClosedAndSealed' before field var 'x_IsNonNominationReceivingLineClosedAndSealed'
            val = CurrentForm.HasValue("IsNonNominationReceivingLineClosedAndSealed") ? CurrentForm.GetValue("IsNonNominationReceivingLineClosedAndSealed") : CurrentForm.GetValue("x_IsNonNominationReceivingLineClosedAndSealed");
            if (!IsNonNominationReceivingLineClosedAndSealed.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IsNonNominationReceivingLineClosedAndSealed") && !CurrentForm.HasValue("x_IsNonNominationReceivingLineClosedAndSealed")) // DN
                    IsNonNominationReceivingLineClosedAndSealed.Visible = false; // Disable update for API request
                else
                    IsNonNominationReceivingLineClosedAndSealed.SetFormValue(val);
            }

            // Check field name 'IsTankEmptyAndDry' before field var 'x_IsTankEmptyAndDry'
            val = CurrentForm.HasValue("IsTankEmptyAndDry") ? CurrentForm.GetValue("IsTankEmptyAndDry") : CurrentForm.GetValue("x_IsTankEmptyAndDry");
            if (!IsTankEmptyAndDry.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IsTankEmptyAndDry") && !CurrentForm.HasValue("x_IsTankEmptyAndDry")) // DN
                    IsTankEmptyAndDry.Visible = false; // Disable update for API request
                else
                    IsTankEmptyAndDry.SetFormValue(val);
            }

            // Check field name 'IsDocumentationComplete' before field var 'x_IsDocumentationComplete'
            val = CurrentForm.HasValue("IsDocumentationComplete") ? CurrentForm.GetValue("IsDocumentationComplete") : CurrentForm.GetValue("x_IsDocumentationComplete");
            if (!IsDocumentationComplete.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IsDocumentationComplete") && !CurrentForm.HasValue("x_IsDocumentationComplete")) // DN
                    IsDocumentationComplete.Visible = false; // Disable update for API request
                else
                    IsDocumentationComplete.SetFormValue(val);
            }

            // Check field name 'IdAktivitas' before field var 'x_IdAktivitas'
            val = CurrentForm.HasValue("IdAktivitas") ? CurrentForm.GetValue("IdAktivitas") : CurrentForm.GetValue("x_IdAktivitas");
            if (!IdAktivitas.IsDetailKey)
                IdAktivitas.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            IdAktivitas.CurrentValue = IdAktivitas.FormValue;
            No_Referensi.CurrentValue = No_Referensi.FormValue;
            IdProses.CurrentValue = IdProses.FormValue;
            IdTemplateAktivitas.CurrentValue = IdTemplateAktivitas.FormValue;
            Aktivitas2.CurrentValue = Aktivitas2.FormValue;
            NamaAktivitas.CurrentValue = NamaAktivitas.FormValue;
            PIC.CurrentValue = PIC.FormValue;
            TanggalMulai.CurrentValue = TanggalMulai.FormValue;
            TanggalMulai.CurrentValue = UnformatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
            TanggalSelesai.CurrentValue = TanggalSelesai.FormValue;
            TanggalSelesai.CurrentValue = UnformatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
            StatusAktivitas.CurrentValue = StatusAktivitas.FormValue;
            TipeAktivitas.CurrentValue = TipeAktivitas.FormValue;
            sandar_nama_kapal.CurrentValue = sandar_nama_kapal.FormValue;
            sandar_tgl_tiba.CurrentValue = sandar_tgl_tiba.FormValue;
            sandar_tgl_tiba.CurrentValue = UnformatDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern);
            sandar_nominasi.CurrentValue = sandar_nominasi.FormValue;
            Produk.CurrentValue = Produk.FormValue;
            Shipment.CurrentValue = Shipment.FormValue;
            Nama_Proses.CurrentValue = Nama_Proses.FormValue;
            IdDokumen.CurrentValue = IdDokumen.FormValue;
            PathFile.CurrentValue = PathFile.FormValue;
            TanggalUploadDok.CurrentValue = TanggalUploadDok.FormValue;
            TanggalUploadDok.CurrentValue = UnformatDateTime(TanggalUploadDok.CurrentValue, TanggalUploadDok.FormatPattern);
            UserUploadDok.CurrentValue = UserUploadDok.FormValue;
            NamaDokumen.CurrentValue = NamaDokumen.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            IdRefAnak.CurrentValue = IdRefAnak.FormValue;
            TableAnak.CurrentValue = TableAnak.FormValue;
            TipeProses.CurrentValue = TipeProses.FormValue;
            Urutan.CurrentValue = Urutan.FormValue;
            IsNominationTankReceivingLineOpen.CurrentValue = IsNominationTankReceivingLineOpen.FormValue;
            IsNonNominationReceivingLineClosedAndSealed.CurrentValue = IsNonNominationReceivingLineClosedAndSealed.FormValue;
            IsTankEmptyAndDry.CurrentValue = IsTankEmptyAndDry.FormValue;
            IsDocumentationComplete.CurrentValue = IsDocumentationComplete.FormValue;
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
            IdAktivitas.SetDbValue(row["IdAktivitas"]);
            No_Referensi.SetDbValue(row["No_Referensi"]);
            IdProses.SetDbValue(row["IdProses"]);
            IdTemplateAktivitas.SetDbValue(row["IdTemplateAktivitas"]);
            Aktivitas2.SetDbValue(row["Aktivitas"]);
            NamaAktivitas.SetDbValue(row["NamaAktivitas"]);
            PIC.SetDbValue(row["PIC"]);
            TanggalMulai.SetDbValue(row["TanggalMulai"]);
            TanggalSelesai.SetDbValue(row["TanggalSelesai"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            TipeAktivitas.SetDbValue(row["TipeAktivitas"]);
            sandar_nama_kapal.SetDbValue(row["sandar_nama_kapal"]);
            sandar_tgl_tiba.SetDbValue(row["sandar_tgl_tiba"]);
            sandar_nominasi.SetDbValue(row["sandar_nominasi"]);
            Produk.SetDbValue(row["Produk"]);
            Shipment.SetDbValue(row["Shipment"]);
            Nama_Proses.SetDbValue(row["Nama_Proses"]);
            IdDokumen.SetDbValue(row["IdDokumen"]);
            PathFile.SetDbValue(row["PathFile"]);
            TanggalUploadDok.SetDbValue(row["TanggalUploadDok"]);
            UserUploadDok.SetDbValue(row["UserUploadDok"]);
            NamaDokumen.SetDbValue(row["NamaDokumen"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            IdRefAnak.SetDbValue(row["IdRefAnak"]);
            TableAnak.SetDbValue(row["TableAnak"]);
            TipeProses.SetDbValue(row["TipeProses"]);
            Urutan.SetDbValue(row["Urutan"]);
            IsNominationTankReceivingLineOpen.SetDbValue((ConvertToBool(row["IsNominationTankReceivingLineOpen"]) ? "1" : "0"));
            IsNonNominationReceivingLineClosedAndSealed.SetDbValue((ConvertToBool(row["IsNonNominationReceivingLineClosedAndSealed"]) ? "1" : "0"));
            IsTankEmptyAndDry.SetDbValue((ConvertToBool(row["IsTankEmptyAndDry"]) ? "1" : "0"));
            IsDocumentationComplete.SetDbValue((ConvertToBool(row["IsDocumentationComplete"]) ? "1" : "0"));
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdAktivitas", IdAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("No_Referensi", No_Referensi.DefaultValue ?? DbNullValue); // DN
            row.Add("IdProses", IdProses.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplateAktivitas", IdTemplateAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("Aktivitas", Aktivitas2.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaAktivitas", NamaAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("PIC", PIC.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalMulai", TanggalMulai.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalSelesai", TanggalSelesai.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktivitas", StatusAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeAktivitas", TipeAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("sandar_nama_kapal", sandar_nama_kapal.DefaultValue ?? DbNullValue); // DN
            row.Add("sandar_tgl_tiba", sandar_tgl_tiba.DefaultValue ?? DbNullValue); // DN
            row.Add("sandar_nominasi", sandar_nominasi.DefaultValue ?? DbNullValue); // DN
            row.Add("Produk", Produk.DefaultValue ?? DbNullValue); // DN
            row.Add("Shipment", Shipment.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama_Proses", Nama_Proses.DefaultValue ?? DbNullValue); // DN
            row.Add("IdDokumen", IdDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("PathFile", PathFile.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalUploadDok", TanggalUploadDok.DefaultValue ?? DbNullValue); // DN
            row.Add("UserUploadDok", UserUploadDok.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaDokumen", NamaDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("IdRefAnak", IdRefAnak.DefaultValue ?? DbNullValue); // DN
            row.Add("TableAnak", TableAnak.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProses", TipeProses.DefaultValue ?? DbNullValue); // DN
            row.Add("Urutan", Urutan.DefaultValue ?? DbNullValue); // DN
            row.Add("IsNominationTankReceivingLineOpen", IsNominationTankReceivingLineOpen.DefaultValue ?? DbNullValue); // DN
            row.Add("IsNonNominationReceivingLineClosedAndSealed", IsNonNominationReceivingLineClosedAndSealed.DefaultValue ?? DbNullValue); // DN
            row.Add("IsTankEmptyAndDry", IsTankEmptyAndDry.DefaultValue ?? DbNullValue); // DN
            row.Add("IsDocumentationComplete", IsDocumentationComplete.DefaultValue ?? DbNullValue); // DN
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

            // IdAktivitas
            IdAktivitas.RowCssClass = "row";

            // No_Referensi
            No_Referensi.RowCssClass = "row";

            // IdProses
            IdProses.RowCssClass = "row";

            // IdTemplateAktivitas
            IdTemplateAktivitas.RowCssClass = "row";

            // Aktivitas
            Aktivitas2.RowCssClass = "row";

            // NamaAktivitas
            NamaAktivitas.RowCssClass = "row";

            // PIC
            PIC.RowCssClass = "row";

            // TanggalMulai
            TanggalMulai.RowCssClass = "row";

            // TanggalSelesai
            TanggalSelesai.RowCssClass = "row";

            // StatusAktivitas
            StatusAktivitas.RowCssClass = "row";

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

            // sandar_nama_kapal
            sandar_nama_kapal.RowCssClass = "row";

            // sandar_tgl_tiba
            sandar_tgl_tiba.RowCssClass = "row";

            // sandar_nominasi
            sandar_nominasi.RowCssClass = "row";

            // Produk
            Produk.RowCssClass = "row";

            // Shipment
            Shipment.RowCssClass = "row";

            // Nama_Proses
            Nama_Proses.RowCssClass = "row";

            // IdDokumen
            IdDokumen.RowCssClass = "row";

            // PathFile
            PathFile.RowCssClass = "row";

            // TanggalUploadDok
            TanggalUploadDok.RowCssClass = "row";

            // UserUploadDok
            UserUploadDok.RowCssClass = "row";

            // NamaDokumen
            NamaDokumen.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // IdRefAnak
            IdRefAnak.RowCssClass = "row";

            // TableAnak
            TableAnak.RowCssClass = "row";

            // TipeProses
            TipeProses.RowCssClass = "row";

            // Urutan
            Urutan.RowCssClass = "row";

            // IsNominationTankReceivingLineOpen
            IsNominationTankReceivingLineOpen.RowCssClass = "row";

            // IsNonNominationReceivingLineClosedAndSealed
            IsNonNominationReceivingLineClosedAndSealed.RowCssClass = "row";

            // IsTankEmptyAndDry
            IsTankEmptyAndDry.RowCssClass = "row";

            // IsDocumentationComplete
            IsDocumentationComplete.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdAktivitas
                IdAktivitas.ViewValue = IdAktivitas.CurrentValue;
                IdAktivitas.ViewCustomAttributes = "";

                // No_Referensi
                No_Referensi.ViewValue = ConvertToString(No_Referensi.CurrentValue); // DN
                No_Referensi.ViewCustomAttributes = "";

                // IdProses
                string curVal = ConvertToString(IdProses.CurrentValue);
                if (!Empty(curVal)) {
                    if (IdProses.Lookup != null && IsDictionary(IdProses.Lookup?.Options) && IdProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdProses.ViewValue = IdProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", IdProses.CurrentValue, IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk = IdProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdProses.Lookup != null) { // Lookup values found
                            var listwrk = IdProses.Lookup?.RenderViewRow(rswrk[0]);
                            IdProses.ViewValue = IdProses.DisplayValue(listwrk);
                        } else {
                            IdProses.ViewValue = FormatNumber(IdProses.CurrentValue, IdProses.FormatPattern);
                        }
                    }
                } else {
                    IdProses.ViewValue = DbNullValue;
                }
                IdProses.ViewCustomAttributes = "";

                // IdTemplateAktivitas
                string curVal2 = ConvertToString(IdTemplateAktivitas.CurrentValue);
                if (!Empty(curVal2)) {
                    if (IdTemplateAktivitas.Lookup != null && IsDictionary(IdTemplateAktivitas.Lookup?.Options) && IdTemplateAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTemplateAktivitas.ViewValue = IdTemplateAktivitas.LookupCacheOption(curVal2);
                    } else { // Lookup from database // DN
                        string filterWrk2 = SearchFilter(IdTemplateAktivitas.Lookup?.GetTable()?.Fields["IdTemplateAktivitas"].SearchExpression, "=", IdTemplateAktivitas.CurrentValue, IdTemplateAktivitas.Lookup?.GetTable()?.Fields["IdTemplateAktivitas"].SearchDataType, "");
                        string? sqlWrk2 = IdTemplateAktivitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk2?.Count > 0 && IdTemplateAktivitas.Lookup != null) { // Lookup values found
                            var listwrk = IdTemplateAktivitas.Lookup?.RenderViewRow(rswrk2[0]);
                            IdTemplateAktivitas.ViewValue = IdTemplateAktivitas.DisplayValue(listwrk);
                        } else {
                            IdTemplateAktivitas.ViewValue = FormatNumber(IdTemplateAktivitas.CurrentValue, IdTemplateAktivitas.FormatPattern);
                        }
                    }
                } else {
                    IdTemplateAktivitas.ViewValue = DbNullValue;
                }
                IdTemplateAktivitas.ViewCustomAttributes = "";

                // Aktivitas
                Aktivitas2.ViewValue = Aktivitas2.CurrentValue;
                Aktivitas2.ViewCustomAttributes = "";

                // NamaAktivitas
                NamaAktivitas.ViewValue = ConvertToString(NamaAktivitas.CurrentValue); // DN
                NamaAktivitas.ViewCustomAttributes = "";

                // PIC
                PIC.ViewValue = ConvertToString(PIC.CurrentValue); // DN
                PIC.ViewCustomAttributes = "";

                // TanggalMulai
                TanggalMulai.ViewValue = TanggalMulai.CurrentValue;
                TanggalMulai.ViewValue = FormatDateTime(TanggalMulai.ViewValue, TanggalMulai.FormatPattern);
                TanggalMulai.ViewCustomAttributes = "";

                // TanggalSelesai
                TanggalSelesai.ViewValue = TanggalSelesai.CurrentValue;
                TanggalSelesai.ViewValue = FormatDateTime(TanggalSelesai.ViewValue, TanggalSelesai.FormatPattern);
                TanggalSelesai.ViewCustomAttributes = "";

                // StatusAktivitas
                StatusAktivitas.ViewValue = ConvertToString(StatusAktivitas.CurrentValue); // DN
                StatusAktivitas.ViewCustomAttributes = "";

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

                // sandar_nama_kapal
                sandar_nama_kapal.ViewValue = ConvertToString(sandar_nama_kapal.CurrentValue); // DN
                sandar_nama_kapal.ViewCustomAttributes = "";

                // sandar_tgl_tiba
                sandar_tgl_tiba.ViewValue = sandar_tgl_tiba.CurrentValue;
                sandar_tgl_tiba.ViewValue = FormatDateTime(sandar_tgl_tiba.ViewValue, sandar_tgl_tiba.FormatPattern);
                sandar_tgl_tiba.ViewCustomAttributes = "";

                // sandar_nominasi
                sandar_nominasi.ViewValue = ConvertToString(sandar_nominasi.CurrentValue); // DN
                sandar_nominasi.ViewCustomAttributes = "";

                // Produk
                Produk.ViewValue = ConvertToString(Produk.CurrentValue); // DN
                Produk.ViewCustomAttributes = "";

                // Shipment
                Shipment.ViewValue = ConvertToString(Shipment.CurrentValue); // DN
                Shipment.ViewCustomAttributes = "";

                // Nama_Proses
                Nama_Proses.ViewValue = ConvertToString(Nama_Proses.CurrentValue); // DN
                Nama_Proses.ViewCustomAttributes = "";

                // IdDokumen
                IdDokumen.ViewValue = IdDokumen.CurrentValue;
                IdDokumen.ViewValue = FormatNumber(IdDokumen.ViewValue, IdDokumen.FormatPattern);
                IdDokumen.ViewCustomAttributes = "";

                // PathFile
                PathFile.ViewValue = ConvertToString(PathFile.CurrentValue); // DN
                PathFile.ViewCustomAttributes = "";

                // TanggalUploadDok
                TanggalUploadDok.ViewValue = TanggalUploadDok.CurrentValue;
                TanggalUploadDok.ViewValue = FormatDateTime(TanggalUploadDok.ViewValue, TanggalUploadDok.FormatPattern);
                TanggalUploadDok.ViewCustomAttributes = "";

                // UserUploadDok
                UserUploadDok.ViewValue = ConvertToString(UserUploadDok.CurrentValue); // DN
                UserUploadDok.ViewCustomAttributes = "";

                // NamaDokumen
                NamaDokumen.ViewValue = ConvertToString(NamaDokumen.CurrentValue); // DN
                NamaDokumen.ViewCustomAttributes = "";

                // Keterangan
                Keterangan.ViewValue = Keterangan.CurrentValue;
                Keterangan.ViewCustomAttributes = "";

                // IdRefAnak
                IdRefAnak.ViewValue = IdRefAnak.CurrentValue;
                IdRefAnak.ViewValue = FormatNumber(IdRefAnak.ViewValue, IdRefAnak.FormatPattern);
                IdRefAnak.ViewCustomAttributes = "";

                // TableAnak
                TableAnak.ViewValue = ConvertToString(TableAnak.CurrentValue); // DN
                TableAnak.ViewCustomAttributes = "";

                // TipeProses
                TipeProses.ViewValue = ConvertToString(TipeProses.CurrentValue); // DN
                TipeProses.ViewCustomAttributes = "";

                // Urutan
                Urutan.ViewValue = Urutan.CurrentValue;
                Urutan.ViewValue = FormatNumber(Urutan.ViewValue, Urutan.FormatPattern);
                Urutan.CssClass = "fst-italic";
                Urutan.ViewCustomAttributes = "";

                // IsNominationTankReceivingLineOpen
                if (ConvertToBool(IsNominationTankReceivingLineOpen.CurrentValue)) {
                    IsNominationTankReceivingLineOpen.ViewValue = IsNominationTankReceivingLineOpen.TagCaption(1) != "" ? IsNominationTankReceivingLineOpen.TagCaption(1) : "Yes";
                } else {
                    IsNominationTankReceivingLineOpen.ViewValue = IsNominationTankReceivingLineOpen.TagCaption(2) != "" ? IsNominationTankReceivingLineOpen.TagCaption(2) : "No";
                }
                IsNominationTankReceivingLineOpen.ViewCustomAttributes = "";

                // IsNonNominationReceivingLineClosedAndSealed
                if (ConvertToBool(IsNonNominationReceivingLineClosedAndSealed.CurrentValue)) {
                    IsNonNominationReceivingLineClosedAndSealed.ViewValue = IsNonNominationReceivingLineClosedAndSealed.TagCaption(1) != "" ? IsNonNominationReceivingLineClosedAndSealed.TagCaption(1) : "Yes";
                } else {
                    IsNonNominationReceivingLineClosedAndSealed.ViewValue = IsNonNominationReceivingLineClosedAndSealed.TagCaption(2) != "" ? IsNonNominationReceivingLineClosedAndSealed.TagCaption(2) : "No";
                }
                IsNonNominationReceivingLineClosedAndSealed.ViewCustomAttributes = "";

                // IsTankEmptyAndDry
                if (ConvertToBool(IsTankEmptyAndDry.CurrentValue)) {
                    IsTankEmptyAndDry.ViewValue = IsTankEmptyAndDry.TagCaption(1) != "" ? IsTankEmptyAndDry.TagCaption(1) : "Yes";
                } else {
                    IsTankEmptyAndDry.ViewValue = IsTankEmptyAndDry.TagCaption(2) != "" ? IsTankEmptyAndDry.TagCaption(2) : "No";
                }
                IsTankEmptyAndDry.ViewCustomAttributes = "";

                // IsDocumentationComplete
                if (ConvertToBool(IsDocumentationComplete.CurrentValue)) {
                    IsDocumentationComplete.ViewValue = IsDocumentationComplete.TagCaption(1) != "" ? IsDocumentationComplete.TagCaption(1) : "Yes";
                } else {
                    IsDocumentationComplete.ViewValue = IsDocumentationComplete.TagCaption(2) != "" ? IsDocumentationComplete.TagCaption(2) : "No";
                }
                IsDocumentationComplete.ViewCustomAttributes = "";

                // No_Referensi
                No_Referensi.HrefValue = "";

                // IdProses
                IdProses.HrefValue = "";

                // IdTemplateAktivitas
                IdTemplateAktivitas.HrefValue = "";

                // Aktivitas
                Aktivitas2.HrefValue = "";

                // NamaAktivitas
                NamaAktivitas.HrefValue = "";

                // PIC
                PIC.HrefValue = "";

                // TanggalMulai
                TanggalMulai.HrefValue = "";

                // TanggalSelesai
                TanggalSelesai.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";

                // TipeAktivitas
                TipeAktivitas.HrefValue = "";

                // sandar_nama_kapal
                sandar_nama_kapal.HrefValue = "";

                // sandar_tgl_tiba
                sandar_tgl_tiba.HrefValue = "";

                // sandar_nominasi
                sandar_nominasi.HrefValue = "";

                // Produk
                Produk.HrefValue = "";

                // Shipment
                Shipment.HrefValue = "";

                // Nama_Proses
                Nama_Proses.HrefValue = "";

                // IdDokumen
                IdDokumen.HrefValue = "";

                // PathFile
                PathFile.HrefValue = "";

                // TanggalUploadDok
                TanggalUploadDok.HrefValue = "";

                // UserUploadDok
                UserUploadDok.HrefValue = "";

                // NamaDokumen
                NamaDokumen.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // IdRefAnak
                IdRefAnak.HrefValue = "";

                // TableAnak
                TableAnak.HrefValue = "";

                // TipeProses
                TipeProses.HrefValue = "";

                // Urutan
                Urutan.HrefValue = "";

                // IsNominationTankReceivingLineOpen
                IsNominationTankReceivingLineOpen.HrefValue = "";

                // IsNonNominationReceivingLineClosedAndSealed
                IsNonNominationReceivingLineClosedAndSealed.HrefValue = "";

                // IsTankEmptyAndDry
                IsTankEmptyAndDry.HrefValue = "";

                // IsDocumentationComplete
                IsDocumentationComplete.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // No_Referensi
                No_Referensi.SetupEditAttributes();
                if (!No_Referensi.Raw)
                    No_Referensi.CurrentValue = HtmlDecode(No_Referensi.CurrentValue);
                No_Referensi.EditValue = HtmlEncode(No_Referensi.CurrentValue);
                No_Referensi.PlaceHolder = RemoveHtml(No_Referensi.Caption);

                // IdProses
                IdProses.SetupEditAttributes();
                string curVal = ConvertToString(IdProses.CurrentValue);
                if (IdProses.Lookup != null && IsDictionary(IdProses.Lookup?.Options) && IdProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdProses.EditValue = IdProses.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk = "";
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter(IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", IdProses.CurrentValue, IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                    }
                    string? sqlWrk = IdProses.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdProses.EditValue = rswrk;
                }
                IdProses.PlaceHolder = RemoveHtml(IdProses.Caption);
                if (!Empty(IdProses.EditValue) && IsNumeric(IdProses.EditValue))
                    IdProses.EditValue = FormatNumber(IdProses.EditValue, null);

                // IdTemplateAktivitas
                IdTemplateAktivitas.SetupEditAttributes();
                string curVal2 = ConvertToString(IdTemplateAktivitas.CurrentValue);
                if (IdTemplateAktivitas.Lookup != null && IsDictionary(IdTemplateAktivitas.Lookup?.Options) && IdTemplateAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdTemplateAktivitas.EditValue = IdTemplateAktivitas.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk2 = "";
                    if (curVal2 == "") {
                        filterWrk2 = "0=1";
                    } else {
                        filterWrk2 = SearchFilter(IdTemplateAktivitas.Lookup?.GetTable()?.Fields["IdTemplateAktivitas"].SearchExpression, "=", IdTemplateAktivitas.CurrentValue, IdTemplateAktivitas.Lookup?.GetTable()?.Fields["IdTemplateAktivitas"].SearchDataType, "");
                    }
                    string? sqlWrk2 = IdTemplateAktivitas.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdTemplateAktivitas.EditValue = rswrk2;
                }
                IdTemplateAktivitas.PlaceHolder = RemoveHtml(IdTemplateAktivitas.Caption);
                if (!Empty(IdTemplateAktivitas.EditValue) && IsNumeric(IdTemplateAktivitas.EditValue))
                    IdTemplateAktivitas.EditValue = FormatNumber(IdTemplateAktivitas.EditValue, null);

                // Aktivitas
                Aktivitas2.SetupEditAttributes();
                Aktivitas2.EditValue = Aktivitas2.CurrentValue; // DN
                Aktivitas2.PlaceHolder = RemoveHtml(Aktivitas2.Caption);

                // NamaAktivitas
                NamaAktivitas.SetupEditAttributes();
                if (!NamaAktivitas.Raw)
                    NamaAktivitas.CurrentValue = HtmlDecode(NamaAktivitas.CurrentValue);
                NamaAktivitas.EditValue = HtmlEncode(NamaAktivitas.CurrentValue);
                NamaAktivitas.PlaceHolder = RemoveHtml(NamaAktivitas.Caption);

                // PIC
                PIC.SetupEditAttributes();
                if (!PIC.Raw)
                    PIC.CurrentValue = HtmlDecode(PIC.CurrentValue);
                PIC.EditValue = HtmlEncode(PIC.CurrentValue);
                PIC.PlaceHolder = RemoveHtml(PIC.Caption);

                // TanggalMulai
                TanggalMulai.SetupEditAttributes();
                TanggalMulai.EditValue = FormatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
                TanggalMulai.PlaceHolder = RemoveHtml(TanggalMulai.Caption);

                // TanggalSelesai
                TanggalSelesai.SetupEditAttributes();
                TanggalSelesai.EditValue = FormatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
                TanggalSelesai.PlaceHolder = RemoveHtml(TanggalSelesai.Caption);

                // StatusAktivitas
                StatusAktivitas.SetupEditAttributes();
                if (!StatusAktivitas.Raw)
                    StatusAktivitas.CurrentValue = HtmlDecode(StatusAktivitas.CurrentValue);
                StatusAktivitas.EditValue = HtmlEncode(StatusAktivitas.CurrentValue);
                StatusAktivitas.PlaceHolder = RemoveHtml(StatusAktivitas.Caption);

                // TipeAktivitas
                TipeAktivitas.SetupEditAttributes();
                TipeAktivitas.EditValue = TipeAktivitas.Options(true);
                TipeAktivitas.PlaceHolder = RemoveHtml(TipeAktivitas.Caption);

                // sandar_nama_kapal
                sandar_nama_kapal.SetupEditAttributes();
                if (!sandar_nama_kapal.Raw)
                    sandar_nama_kapal.CurrentValue = HtmlDecode(sandar_nama_kapal.CurrentValue);
                sandar_nama_kapal.EditValue = HtmlEncode(sandar_nama_kapal.CurrentValue);
                sandar_nama_kapal.PlaceHolder = RemoveHtml(sandar_nama_kapal.Caption);

                // sandar_tgl_tiba
                sandar_tgl_tiba.SetupEditAttributes();
                sandar_tgl_tiba.EditValue = FormatDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern);
                sandar_tgl_tiba.PlaceHolder = RemoveHtml(sandar_tgl_tiba.Caption);

                // sandar_nominasi
                sandar_nominasi.SetupEditAttributes();
                if (!sandar_nominasi.Raw)
                    sandar_nominasi.CurrentValue = HtmlDecode(sandar_nominasi.CurrentValue);
                sandar_nominasi.EditValue = HtmlEncode(sandar_nominasi.CurrentValue);
                sandar_nominasi.PlaceHolder = RemoveHtml(sandar_nominasi.Caption);

                // Produk
                Produk.SetupEditAttributes();
                if (!Produk.Raw)
                    Produk.CurrentValue = HtmlDecode(Produk.CurrentValue);
                Produk.EditValue = HtmlEncode(Produk.CurrentValue);
                Produk.PlaceHolder = RemoveHtml(Produk.Caption);

                // Shipment
                Shipment.SetupEditAttributes();
                if (!Shipment.Raw)
                    Shipment.CurrentValue = HtmlDecode(Shipment.CurrentValue);
                Shipment.EditValue = HtmlEncode(Shipment.CurrentValue);
                Shipment.PlaceHolder = RemoveHtml(Shipment.Caption);

                // Nama_Proses
                Nama_Proses.SetupEditAttributes();
                if (!Nama_Proses.Raw)
                    Nama_Proses.CurrentValue = HtmlDecode(Nama_Proses.CurrentValue);
                Nama_Proses.EditValue = HtmlEncode(Nama_Proses.CurrentValue);
                Nama_Proses.PlaceHolder = RemoveHtml(Nama_Proses.Caption);

                // IdDokumen
                IdDokumen.SetupEditAttributes();
                IdDokumen.EditValue = IdDokumen.CurrentValue;
                IdDokumen.PlaceHolder = RemoveHtml(IdDokumen.Caption);
                if (!Empty(IdDokumen.EditValue) && IsNumeric(IdDokumen.EditValue))
                    IdDokumen.EditValue = FormatNumber(IdDokumen.EditValue, null);

                // PathFile
                PathFile.SetupEditAttributes();
                if (!PathFile.Raw)
                    PathFile.CurrentValue = HtmlDecode(PathFile.CurrentValue);
                PathFile.EditValue = HtmlEncode(PathFile.CurrentValue);
                PathFile.PlaceHolder = RemoveHtml(PathFile.Caption);

                // TanggalUploadDok
                TanggalUploadDok.SetupEditAttributes();
                TanggalUploadDok.EditValue = FormatDateTime(TanggalUploadDok.CurrentValue, TanggalUploadDok.FormatPattern);
                TanggalUploadDok.PlaceHolder = RemoveHtml(TanggalUploadDok.Caption);

                // UserUploadDok
                UserUploadDok.SetupEditAttributes();
                if (!UserUploadDok.Raw)
                    UserUploadDok.CurrentValue = HtmlDecode(UserUploadDok.CurrentValue);
                UserUploadDok.EditValue = HtmlEncode(UserUploadDok.CurrentValue);
                UserUploadDok.PlaceHolder = RemoveHtml(UserUploadDok.Caption);

                // NamaDokumen
                NamaDokumen.SetupEditAttributes();
                if (!NamaDokumen.Raw)
                    NamaDokumen.CurrentValue = HtmlDecode(NamaDokumen.CurrentValue);
                NamaDokumen.EditValue = HtmlEncode(NamaDokumen.CurrentValue);
                NamaDokumen.PlaceHolder = RemoveHtml(NamaDokumen.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // IdRefAnak
                IdRefAnak.SetupEditAttributes();
                IdRefAnak.EditValue = IdRefAnak.CurrentValue;
                IdRefAnak.PlaceHolder = RemoveHtml(IdRefAnak.Caption);
                if (!Empty(IdRefAnak.EditValue) && IsNumeric(IdRefAnak.EditValue))
                    IdRefAnak.EditValue = FormatNumber(IdRefAnak.EditValue, null);

                // TableAnak
                TableAnak.SetupEditAttributes();
                if (!TableAnak.Raw)
                    TableAnak.CurrentValue = HtmlDecode(TableAnak.CurrentValue);
                TableAnak.EditValue = HtmlEncode(TableAnak.CurrentValue);
                TableAnak.PlaceHolder = RemoveHtml(TableAnak.Caption);

                // TipeProses
                TipeProses.SetupEditAttributes();
                if (!TipeProses.Raw)
                    TipeProses.CurrentValue = HtmlDecode(TipeProses.CurrentValue);
                TipeProses.EditValue = HtmlEncode(TipeProses.CurrentValue);
                TipeProses.PlaceHolder = RemoveHtml(TipeProses.Caption);

                // Urutan
                Urutan.SetupEditAttributes();
                Urutan.EditValue = Urutan.CurrentValue;
                Urutan.PlaceHolder = RemoveHtml(Urutan.Caption);
                if (!Empty(Urutan.EditValue) && IsNumeric(Urutan.EditValue))
                    Urutan.EditValue = FormatNumber(Urutan.EditValue, null);

                // IsNominationTankReceivingLineOpen
                IsNominationTankReceivingLineOpen.EditValue = IsNominationTankReceivingLineOpen.Options(false);
                IsNominationTankReceivingLineOpen.PlaceHolder = RemoveHtml(IsNominationTankReceivingLineOpen.Caption);

                // IsNonNominationReceivingLineClosedAndSealed
                IsNonNominationReceivingLineClosedAndSealed.EditValue = IsNonNominationReceivingLineClosedAndSealed.Options(false);
                IsNonNominationReceivingLineClosedAndSealed.PlaceHolder = RemoveHtml(IsNonNominationReceivingLineClosedAndSealed.Caption);

                // IsTankEmptyAndDry
                IsTankEmptyAndDry.EditValue = IsTankEmptyAndDry.Options(false);
                IsTankEmptyAndDry.PlaceHolder = RemoveHtml(IsTankEmptyAndDry.Caption);

                // IsDocumentationComplete
                IsDocumentationComplete.EditValue = IsDocumentationComplete.Options(false);
                IsDocumentationComplete.PlaceHolder = RemoveHtml(IsDocumentationComplete.Caption);

                // Edit refer script

                // No_Referensi
                No_Referensi.HrefValue = "";

                // IdProses
                IdProses.HrefValue = "";

                // IdTemplateAktivitas
                IdTemplateAktivitas.HrefValue = "";

                // Aktivitas
                Aktivitas2.HrefValue = "";

                // NamaAktivitas
                NamaAktivitas.HrefValue = "";

                // PIC
                PIC.HrefValue = "";

                // TanggalMulai
                TanggalMulai.HrefValue = "";

                // TanggalSelesai
                TanggalSelesai.HrefValue = "";

                // StatusAktivitas
                StatusAktivitas.HrefValue = "";

                // TipeAktivitas
                TipeAktivitas.HrefValue = "";

                // sandar_nama_kapal
                sandar_nama_kapal.HrefValue = "";

                // sandar_tgl_tiba
                sandar_tgl_tiba.HrefValue = "";

                // sandar_nominasi
                sandar_nominasi.HrefValue = "";

                // Produk
                Produk.HrefValue = "";

                // Shipment
                Shipment.HrefValue = "";

                // Nama_Proses
                Nama_Proses.HrefValue = "";

                // IdDokumen
                IdDokumen.HrefValue = "";

                // PathFile
                PathFile.HrefValue = "";

                // TanggalUploadDok
                TanggalUploadDok.HrefValue = "";

                // UserUploadDok
                UserUploadDok.HrefValue = "";

                // NamaDokumen
                NamaDokumen.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // IdRefAnak
                IdRefAnak.HrefValue = "";

                // TableAnak
                TableAnak.HrefValue = "";

                // TipeProses
                TipeProses.HrefValue = "";

                // Urutan
                Urutan.HrefValue = "";

                // IsNominationTankReceivingLineOpen
                IsNominationTankReceivingLineOpen.HrefValue = "";

                // IsNonNominationReceivingLineClosedAndSealed
                IsNonNominationReceivingLineClosedAndSealed.HrefValue = "";

                // IsTankEmptyAndDry
                IsTankEmptyAndDry.HrefValue = "";

                // IsDocumentationComplete
                IsDocumentationComplete.HrefValue = "";
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
                if (No_Referensi.Visible && No_Referensi.Required) {
                    if (!No_Referensi.IsDetailKey && Empty(No_Referensi.FormValue)) {
                        No_Referensi.AddErrorMessage(ConvertToString(No_Referensi.RequiredErrorMessage).Replace("%s", No_Referensi.Caption));
                    }
                }
                if (IdProses.Visible && IdProses.Required) {
                    if (!IdProses.IsDetailKey && Empty(IdProses.FormValue)) {
                        IdProses.AddErrorMessage(ConvertToString(IdProses.RequiredErrorMessage).Replace("%s", IdProses.Caption));
                    }
                }
                if (IdTemplateAktivitas.Visible && IdTemplateAktivitas.Required) {
                    if (!IdTemplateAktivitas.IsDetailKey && Empty(IdTemplateAktivitas.FormValue)) {
                        IdTemplateAktivitas.AddErrorMessage(ConvertToString(IdTemplateAktivitas.RequiredErrorMessage).Replace("%s", IdTemplateAktivitas.Caption));
                    }
                }
                if (Aktivitas2.Visible && Aktivitas2.Required) {
                    if (!Aktivitas2.IsDetailKey && Empty(Aktivitas2.FormValue)) {
                        Aktivitas2.AddErrorMessage(ConvertToString(Aktivitas2.RequiredErrorMessage).Replace("%s", Aktivitas2.Caption));
                    }
                }
                if (NamaAktivitas.Visible && NamaAktivitas.Required) {
                    if (!NamaAktivitas.IsDetailKey && Empty(NamaAktivitas.FormValue)) {
                        NamaAktivitas.AddErrorMessage(ConvertToString(NamaAktivitas.RequiredErrorMessage).Replace("%s", NamaAktivitas.Caption));
                    }
                }
                if (PIC.Visible && PIC.Required) {
                    if (!PIC.IsDetailKey && Empty(PIC.FormValue)) {
                        PIC.AddErrorMessage(ConvertToString(PIC.RequiredErrorMessage).Replace("%s", PIC.Caption));
                    }
                }
                if (TanggalMulai.Visible && TanggalMulai.Required) {
                    if (!TanggalMulai.IsDetailKey && Empty(TanggalMulai.FormValue)) {
                        TanggalMulai.AddErrorMessage(ConvertToString(TanggalMulai.RequiredErrorMessage).Replace("%s", TanggalMulai.Caption));
                    }
                }
                if (!CheckDate(TanggalMulai.FormValue, TanggalMulai.FormatPattern)) {
                    TanggalMulai.AddErrorMessage(TanggalMulai.GetErrorMessage(false));
                }
                if (TanggalSelesai.Visible && TanggalSelesai.Required) {
                    if (!TanggalSelesai.IsDetailKey && Empty(TanggalSelesai.FormValue)) {
                        TanggalSelesai.AddErrorMessage(ConvertToString(TanggalSelesai.RequiredErrorMessage).Replace("%s", TanggalSelesai.Caption));
                    }
                }
                if (!CheckDate(TanggalSelesai.FormValue, TanggalSelesai.FormatPattern)) {
                    TanggalSelesai.AddErrorMessage(TanggalSelesai.GetErrorMessage(false));
                }
                if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                    if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                        StatusAktivitas.AddErrorMessage(ConvertToString(StatusAktivitas.RequiredErrorMessage).Replace("%s", StatusAktivitas.Caption));
                    }
                }
                if (TipeAktivitas.Visible && TipeAktivitas.Required) {
                    if (!TipeAktivitas.IsDetailKey && Empty(TipeAktivitas.FormValue)) {
                        TipeAktivitas.AddErrorMessage(ConvertToString(TipeAktivitas.RequiredErrorMessage).Replace("%s", TipeAktivitas.Caption));
                    }
                }
                if (sandar_nama_kapal.Visible && sandar_nama_kapal.Required) {
                    if (!sandar_nama_kapal.IsDetailKey && Empty(sandar_nama_kapal.FormValue)) {
                        sandar_nama_kapal.AddErrorMessage(ConvertToString(sandar_nama_kapal.RequiredErrorMessage).Replace("%s", sandar_nama_kapal.Caption));
                    }
                }
                if (sandar_tgl_tiba.Visible && sandar_tgl_tiba.Required) {
                    if (!sandar_tgl_tiba.IsDetailKey && Empty(sandar_tgl_tiba.FormValue)) {
                        sandar_tgl_tiba.AddErrorMessage(ConvertToString(sandar_tgl_tiba.RequiredErrorMessage).Replace("%s", sandar_tgl_tiba.Caption));
                    }
                }
                if (!CheckDate(sandar_tgl_tiba.FormValue, sandar_tgl_tiba.FormatPattern)) {
                    sandar_tgl_tiba.AddErrorMessage(sandar_tgl_tiba.GetErrorMessage(false));
                }
                if (sandar_nominasi.Visible && sandar_nominasi.Required) {
                    if (!sandar_nominasi.IsDetailKey && Empty(sandar_nominasi.FormValue)) {
                        sandar_nominasi.AddErrorMessage(ConvertToString(sandar_nominasi.RequiredErrorMessage).Replace("%s", sandar_nominasi.Caption));
                    }
                }
                if (Produk.Visible && Produk.Required) {
                    if (!Produk.IsDetailKey && Empty(Produk.FormValue)) {
                        Produk.AddErrorMessage(ConvertToString(Produk.RequiredErrorMessage).Replace("%s", Produk.Caption));
                    }
                }
                if (Shipment.Visible && Shipment.Required) {
                    if (!Shipment.IsDetailKey && Empty(Shipment.FormValue)) {
                        Shipment.AddErrorMessage(ConvertToString(Shipment.RequiredErrorMessage).Replace("%s", Shipment.Caption));
                    }
                }
                if (Nama_Proses.Visible && Nama_Proses.Required) {
                    if (!Nama_Proses.IsDetailKey && Empty(Nama_Proses.FormValue)) {
                        Nama_Proses.AddErrorMessage(ConvertToString(Nama_Proses.RequiredErrorMessage).Replace("%s", Nama_Proses.Caption));
                    }
                }
                if (IdDokumen.Visible && IdDokumen.Required) {
                    if (!IdDokumen.IsDetailKey && Empty(IdDokumen.FormValue)) {
                        IdDokumen.AddErrorMessage(ConvertToString(IdDokumen.RequiredErrorMessage).Replace("%s", IdDokumen.Caption));
                    }
                }
                if (!CheckInteger(IdDokumen.FormValue)) {
                    IdDokumen.AddErrorMessage(IdDokumen.GetErrorMessage(false));
                }
                if (PathFile.Visible && PathFile.Required) {
                    if (!PathFile.IsDetailKey && Empty(PathFile.FormValue)) {
                        PathFile.AddErrorMessage(ConvertToString(PathFile.RequiredErrorMessage).Replace("%s", PathFile.Caption));
                    }
                }
                if (TanggalUploadDok.Visible && TanggalUploadDok.Required) {
                    if (!TanggalUploadDok.IsDetailKey && Empty(TanggalUploadDok.FormValue)) {
                        TanggalUploadDok.AddErrorMessage(ConvertToString(TanggalUploadDok.RequiredErrorMessage).Replace("%s", TanggalUploadDok.Caption));
                    }
                }
                if (!CheckDate(TanggalUploadDok.FormValue, TanggalUploadDok.FormatPattern)) {
                    TanggalUploadDok.AddErrorMessage(TanggalUploadDok.GetErrorMessage(false));
                }
                if (UserUploadDok.Visible && UserUploadDok.Required) {
                    if (!UserUploadDok.IsDetailKey && Empty(UserUploadDok.FormValue)) {
                        UserUploadDok.AddErrorMessage(ConvertToString(UserUploadDok.RequiredErrorMessage).Replace("%s", UserUploadDok.Caption));
                    }
                }
                if (NamaDokumen.Visible && NamaDokumen.Required) {
                    if (!NamaDokumen.IsDetailKey && Empty(NamaDokumen.FormValue)) {
                        NamaDokumen.AddErrorMessage(ConvertToString(NamaDokumen.RequiredErrorMessage).Replace("%s", NamaDokumen.Caption));
                    }
                }
                if (Keterangan.Visible && Keterangan.Required) {
                    if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                        Keterangan.AddErrorMessage(ConvertToString(Keterangan.RequiredErrorMessage).Replace("%s", Keterangan.Caption));
                    }
                }
                if (IdRefAnak.Visible && IdRefAnak.Required) {
                    if (!IdRefAnak.IsDetailKey && Empty(IdRefAnak.FormValue)) {
                        IdRefAnak.AddErrorMessage(ConvertToString(IdRefAnak.RequiredErrorMessage).Replace("%s", IdRefAnak.Caption));
                    }
                }
                if (!CheckInteger(IdRefAnak.FormValue)) {
                    IdRefAnak.AddErrorMessage(IdRefAnak.GetErrorMessage(false));
                }
                if (TableAnak.Visible && TableAnak.Required) {
                    if (!TableAnak.IsDetailKey && Empty(TableAnak.FormValue)) {
                        TableAnak.AddErrorMessage(ConvertToString(TableAnak.RequiredErrorMessage).Replace("%s", TableAnak.Caption));
                    }
                }
                if (TipeProses.Visible && TipeProses.Required) {
                    if (!TipeProses.IsDetailKey && Empty(TipeProses.FormValue)) {
                        TipeProses.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                    }
                }
                if (Urutan.Visible && Urutan.Required) {
                    if (!Urutan.IsDetailKey && Empty(Urutan.FormValue)) {
                        Urutan.AddErrorMessage(ConvertToString(Urutan.RequiredErrorMessage).Replace("%s", Urutan.Caption));
                    }
                }
                if (!CheckInteger(Urutan.FormValue)) {
                    Urutan.AddErrorMessage(Urutan.GetErrorMessage(false));
                }
                if (IsNominationTankReceivingLineOpen.Visible && IsNominationTankReceivingLineOpen.Required) {
                    if (Empty(IsNominationTankReceivingLineOpen.FormValue)) {
                        IsNominationTankReceivingLineOpen.AddErrorMessage(ConvertToString(IsNominationTankReceivingLineOpen.RequiredErrorMessage).Replace("%s", IsNominationTankReceivingLineOpen.Caption));
                    }
                }
                if (IsNonNominationReceivingLineClosedAndSealed.Visible && IsNonNominationReceivingLineClosedAndSealed.Required) {
                    if (Empty(IsNonNominationReceivingLineClosedAndSealed.FormValue)) {
                        IsNonNominationReceivingLineClosedAndSealed.AddErrorMessage(ConvertToString(IsNonNominationReceivingLineClosedAndSealed.RequiredErrorMessage).Replace("%s", IsNonNominationReceivingLineClosedAndSealed.Caption));
                    }
                }
                if (IsTankEmptyAndDry.Visible && IsTankEmptyAndDry.Required) {
                    if (Empty(IsTankEmptyAndDry.FormValue)) {
                        IsTankEmptyAndDry.AddErrorMessage(ConvertToString(IsTankEmptyAndDry.RequiredErrorMessage).Replace("%s", IsTankEmptyAndDry.Caption));
                    }
                }
                if (IsDocumentationComplete.Visible && IsDocumentationComplete.Required) {
                    if (Empty(IsDocumentationComplete.FormValue)) {
                        IsDocumentationComplete.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                    }
                }

            // Validate detail grid
            var detailTblVar = CurrentDetailTables;
            if (detailTblVar.Contains("AktivitasDokumen") && aktivitasDokumen?.DetailEdit == true) {
                aktivitasDokumenGrid = Resolve("AktivitasDokumenGrid")!; // Get detail page object
                if (aktivitasDokumenGrid != null)
                    validateForm = validateForm && await aktivitasDokumenGrid.ValidateGridForm();
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

            // Begin transaction
            if (!Empty(CurrentDetailTable) && UseTransaction)
                Connection.BeginTrans();

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

                    // Update detail records
                    var detailTblVar = CurrentDetailTables;
                    if (detailTblVar.Contains("AktivitasDokumen") && aktivitasDokumen?.DetailEdit == true && result) {
                        aktivitasDokumenGrid = Resolve("AktivitasDokumenGrid")!; // Get detail page object
                        if (aktivitasDokumenGrid != null) {
                            Security.LoadCurrentUserLevel(ProjectID + "AktivitasDokumen"); // Load user level of detail table
                            result = await aktivitasDokumenGrid.GridUpdate();
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

            // No_Referensi
            No_Referensi.SetDbValue(rsnew, No_Referensi.CurrentValue, No_Referensi.ReadOnly);

            // IdProses
            IdProses.SetDbValue(rsnew, IdProses.CurrentValue, IdProses.ReadOnly);

            // IdTemplateAktivitas
            IdTemplateAktivitas.SetDbValue(rsnew, IdTemplateAktivitas.CurrentValue, IdTemplateAktivitas.ReadOnly);

            // Aktivitas
            Aktivitas2.SetDbValue(rsnew, Aktivitas2.CurrentValue, Aktivitas2.ReadOnly);

            // NamaAktivitas
            NamaAktivitas.SetDbValue(rsnew, NamaAktivitas.CurrentValue, NamaAktivitas.ReadOnly);

            // PIC
            PIC.SetDbValue(rsnew, PIC.CurrentValue, PIC.ReadOnly);

            // TanggalMulai
            TanggalMulai.SetDbValue(rsnew, ConvertToDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern), TanggalMulai.ReadOnly);

            // TanggalSelesai
            TanggalSelesai.SetDbValue(rsnew, ConvertToDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern), TanggalSelesai.ReadOnly);

            // StatusAktivitas
            StatusAktivitas.SetDbValue(rsnew, StatusAktivitas.CurrentValue, StatusAktivitas.ReadOnly);

            // TipeAktivitas
            TipeAktivitas.SetDbValue(rsnew, TipeAktivitas.CurrentValue, TipeAktivitas.ReadOnly);

            // sandar_nama_kapal
            sandar_nama_kapal.SetDbValue(rsnew, sandar_nama_kapal.CurrentValue, sandar_nama_kapal.ReadOnly);

            // sandar_tgl_tiba
            sandar_tgl_tiba.SetDbValue(rsnew, ConvertToDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern), sandar_tgl_tiba.ReadOnly);

            // sandar_nominasi
            sandar_nominasi.SetDbValue(rsnew, sandar_nominasi.CurrentValue, sandar_nominasi.ReadOnly);

            // Produk
            Produk.SetDbValue(rsnew, Produk.CurrentValue, Produk.ReadOnly);

            // Shipment
            Shipment.SetDbValue(rsnew, Shipment.CurrentValue, Shipment.ReadOnly);

            // Nama_Proses
            Nama_Proses.SetDbValue(rsnew, Nama_Proses.CurrentValue, Nama_Proses.ReadOnly);

            // IdDokumen
            IdDokumen.SetDbValue(rsnew, IdDokumen.CurrentValue, IdDokumen.ReadOnly);

            // PathFile
            PathFile.SetDbValue(rsnew, PathFile.CurrentValue, PathFile.ReadOnly);

            // TanggalUploadDok
            TanggalUploadDok.SetDbValue(rsnew, ConvertToDateTime(TanggalUploadDok.CurrentValue, TanggalUploadDok.FormatPattern), TanggalUploadDok.ReadOnly);

            // UserUploadDok
            UserUploadDok.SetDbValue(rsnew, UserUploadDok.CurrentValue, UserUploadDok.ReadOnly);

            // NamaDokumen
            NamaDokumen.SetDbValue(rsnew, NamaDokumen.CurrentValue, NamaDokumen.ReadOnly);

            // Keterangan
            Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue, Keterangan.ReadOnly);

            // IdRefAnak
            IdRefAnak.SetDbValue(rsnew, IdRefAnak.CurrentValue, IdRefAnak.ReadOnly);

            // TableAnak
            TableAnak.SetDbValue(rsnew, TableAnak.CurrentValue, TableAnak.ReadOnly);

            // TipeProses
            TipeProses.SetDbValue(rsnew, TipeProses.CurrentValue, TipeProses.ReadOnly);

            // Urutan
            Urutan.SetDbValue(rsnew, Urutan.CurrentValue, Urutan.ReadOnly);

            // IsNominationTankReceivingLineOpen
            IsNominationTankReceivingLineOpen.SetDbValue(rsnew, ConvertToBool(IsNominationTankReceivingLineOpen.CurrentValue), IsNominationTankReceivingLineOpen.ReadOnly);

            // IsNonNominationReceivingLineClosedAndSealed
            IsNonNominationReceivingLineClosedAndSealed.SetDbValue(rsnew, ConvertToBool(IsNonNominationReceivingLineClosedAndSealed.CurrentValue), IsNonNominationReceivingLineClosedAndSealed.ReadOnly);

            // IsTankEmptyAndDry
            IsTankEmptyAndDry.SetDbValue(rsnew, ConvertToBool(IsTankEmptyAndDry.CurrentValue), IsTankEmptyAndDry.ReadOnly);

            // IsDocumentationComplete
            IsDocumentationComplete.SetDbValue(rsnew, ConvertToBool(IsDocumentationComplete.CurrentValue), IsDocumentationComplete.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("No_Referensi", out value)) // No_Referensi
                No_Referensi.CurrentValue = value;
            if (row.TryGetValue("IdProses", out value)) // IdProses
                IdProses.CurrentValue = value;
            if (row.TryGetValue("IdTemplateAktivitas", out value)) // IdTemplateAktivitas
                IdTemplateAktivitas.CurrentValue = value;
            if (row.TryGetValue("Aktivitas", out value)) // Aktivitas
                Aktivitas2.CurrentValue = value;
            if (row.TryGetValue("NamaAktivitas", out value)) // NamaAktivitas
                NamaAktivitas.CurrentValue = value;
            if (row.TryGetValue("PIC", out value)) // PIC
                PIC.CurrentValue = value;
            if (row.TryGetValue("TanggalMulai", out value)) // TanggalMulai
                TanggalMulai.CurrentValue = value;
            if (row.TryGetValue("TanggalSelesai", out value)) // TanggalSelesai
                TanggalSelesai.CurrentValue = value;
            if (row.TryGetValue("StatusAktivitas", out value)) // StatusAktivitas
                StatusAktivitas.CurrentValue = value;
            if (row.TryGetValue("TipeAktivitas", out value)) // TipeAktivitas
                TipeAktivitas.CurrentValue = value;
            if (row.TryGetValue("sandar_nama_kapal", out value)) // sandar_nama_kapal
                sandar_nama_kapal.CurrentValue = value;
            if (row.TryGetValue("sandar_tgl_tiba", out value)) // sandar_tgl_tiba
                sandar_tgl_tiba.CurrentValue = value;
            if (row.TryGetValue("sandar_nominasi", out value)) // sandar_nominasi
                sandar_nominasi.CurrentValue = value;
            if (row.TryGetValue("Produk", out value)) // Produk
                Produk.CurrentValue = value;
            if (row.TryGetValue("Shipment", out value)) // Shipment
                Shipment.CurrentValue = value;
            if (row.TryGetValue("Nama_Proses", out value)) // Nama_Proses
                Nama_Proses.CurrentValue = value;
            if (row.TryGetValue("IdDokumen", out value)) // IdDokumen
                IdDokumen.CurrentValue = value;
            if (row.TryGetValue("PathFile", out value)) // PathFile
                PathFile.CurrentValue = value;
            if (row.TryGetValue("TanggalUploadDok", out value)) // TanggalUploadDok
                TanggalUploadDok.CurrentValue = value;
            if (row.TryGetValue("UserUploadDok", out value)) // UserUploadDok
                UserUploadDok.CurrentValue = value;
            if (row.TryGetValue("NamaDokumen", out value)) // NamaDokumen
                NamaDokumen.CurrentValue = value;
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.CurrentValue = value;
            if (row.TryGetValue("IdRefAnak", out value)) // IdRefAnak
                IdRefAnak.CurrentValue = value;
            if (row.TryGetValue("TableAnak", out value)) // TableAnak
                TableAnak.CurrentValue = value;
            if (row.TryGetValue("TipeProses", out value)) // TipeProses
                TipeProses.CurrentValue = value;
            if (row.TryGetValue("Urutan", out value)) // Urutan
                Urutan.CurrentValue = value;
            if (row.TryGetValue("IsNominationTankReceivingLineOpen", out value)) // IsNominationTankReceivingLineOpen
                IsNominationTankReceivingLineOpen.CurrentValue = value;
            if (row.TryGetValue("IsNonNominationReceivingLineClosedAndSealed", out value)) // IsNonNominationReceivingLineClosedAndSealed
                IsNonNominationReceivingLineClosedAndSealed.CurrentValue = value;
            if (row.TryGetValue("IsTankEmptyAndDry", out value)) // IsTankEmptyAndDry
                IsTankEmptyAndDry.CurrentValue = value;
            if (row.TryGetValue("IsDocumentationComplete", out value)) // IsDocumentationComplete
                IsDocumentationComplete.CurrentValue = value;
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
                if (detailTblVars.Contains("AktivitasDokumen")) {
                    aktivitasDokumenGrid = Resolve("AktivitasDokumenGrid")!;
                    if (aktivitasDokumenGrid?.DetailEdit ?? false) {
                        aktivitasDokumenGrid.CurrentMode = "edit";
                        aktivitasDokumenGrid.CurrentAction = "gridedit";

                        // Save current master table to detail table
                        aktivitasDokumenGrid.CurrentMasterTable = TableVar;
                        aktivitasDokumenGrid.StartRecordNumber = 1;
                        aktivitasDokumenGrid.IdAktivitas.IsDetailKey = true;
                        aktivitasDokumenGrid.IdAktivitas.CurrentValue = IdAktivitas.CurrentValue;
                        aktivitasDokumenGrid.IdAktivitas.SessionValue = aktivitasDokumenGrid.IdAktivitas.CurrentValue;
                    }
                }
            }
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("AktivitasList")), "", TableVar, true);
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
