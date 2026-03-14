namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// vFaceEnrollmentSearch
    /// </summary>
    public static VFaceEnrollmentSearch vFaceEnrollmentSearch
    {
        get => HttpData.Get<VFaceEnrollmentSearch>("vFaceEnrollmentSearch")!;
        set => HttpData["vFaceEnrollmentSearch"] = value;
    }

    /// <summary>
    /// Page class for VFaceEnrollment
    /// </summary>
    public class VFaceEnrollmentSearch : VFaceEnrollmentSearchBase
    {
        // Constructor
        public VFaceEnrollmentSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VFaceEnrollmentSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VFaceEnrollmentSearchBase : VFaceEnrollment
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "vFaceEnrollmentSearch";

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
        public VFaceEnrollmentSearchBase()
        {
            TableName = "VFaceEnrollment";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (vFaceEnrollment)
            if (vFaceEnrollment == null || vFaceEnrollment is VFaceEnrollment)
                vFaceEnrollment = this;

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
        public string PageName => "VFaceEnrollmentSearch";

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
            IdUser.SetVisibility();
            _Username.SetVisibility();
            LinkRedirect.Visible = false;
            _Email.SetVisibility();
            NamaLengkap.SetVisibility();
            DownloadFace.Visible = false;
            IdPosition.SetVisibility();
            Jabatan.SetVisibility();
            Face.SetVisibility();
            TanggalInputFace.SetVisibility();
            UserInputFace.SetVisibility();
            AzurePersonId.SetVisibility();
        }

        // Constructor
        public VFaceEnrollmentSearchBase(Controller? controller = null): this() { // DN
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
                            if (!SameString(pageName, ListUrl)) { // Not List page
                                result.Add("caption", GetModalCaption(pageName));
                                result.Add("view", pageName == "VFaceEnrollmentView" ? "1" : "0"); // If View page, no primary button
                            } else { // List page
                                // result.Add("list", PageID == "search" ? "1" : "0"); // Refresh List page if current page is Search page
                                result.Add("error", FailureMessage); // List page should not be shown as modal => error
                                ClearFailureMessage();
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdUser") ? dict["IdUser"] : IdUser.CurrentValue));
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

        public string FormClassName = "ew-form ew-search-form";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

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
            await SetupLookupOptions(IdPosition);

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;

            // Get action
            CurrentAction = CurrentForm.GetValue("action");
            if (IsSearch) {
                // Build search string for advanced search, remove blank field
                LoadSearchValues(); // Get search values
                string srchStr = ValidateSearch() ? BuildAdvancedSearch() : "";
                if (!Empty(srchStr)) {
                    srchStr = "VFaceEnrollmentList?" + srchStr;
                    // Do not return Json for UseAjaxActions
                    if (IsModal && UseAjaxActions)
                        IsModal = false;
                    return Terminate(srchStr); // Go to List page
                }
            }

            // Restore search settings from Session
            if (!HasInvalidFields())
                LoadAdvancedSearch();

            // Render row for search
            RowType = RowType.Search;
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
                vFaceEnrollmentSearch?.PageRender();
            }
            return PageResult();
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, IdUser); // IdUser
            BuildSearchUrl(ref srchUrl, _Username); // Username
            BuildSearchUrl(ref srchUrl, _Email); // Email
            BuildSearchUrl(ref srchUrl, NamaLengkap); // NamaLengkap
            BuildSearchUrl(ref srchUrl, IdPosition); // IdPosition
            BuildSearchUrl(ref srchUrl, Jabatan); // Jabatan
            BuildSearchUrl(ref srchUrl, Face); // Face
            BuildSearchUrl(ref srchUrl, TanggalInputFace); // TanggalInputFace
            BuildSearchUrl(ref srchUrl, UserInputFace); // UserInputFace
            BuildSearchUrl(ref srchUrl, AzurePersonId); // AzurePersonId
            if (!Empty(srchUrl))
                srchUrl += "&";
            srchUrl += "cmd=search";
            return srchUrl;
        }

        // Build search URL
        protected void BuildSearchUrl(ref string url, DbField fld, bool oprOnly = false) {
            bool isValid;
            string wrk = "";
            string fldParm = fld.Param;
            string ctl = "x_" + fldParm;
            string ctl2 = "y_" + fldParm;
            if (fld.IsMultiSelect) { // DN
                ctl += "[]";
                ctl2 += "[]";
            }
            string fldVal = CurrentForm.GetValue(ctl);
            string fldOpr = CurrentForm.GetValue("z_" + fldParm);
            string fldCond = CurrentForm.GetValue("v_" + fldParm);
            string fldVal2 = CurrentForm.GetValue(ctl2);
            string fldOpr2 = CurrentForm.GetValue("w_" + fldParm);
            DataType fldDataType = fld.IsVirtual ? DataType.String : fld.DataType;
            fldVal = ConvertSearchValue(fldVal, fldOpr, fld); // For testing if numeric only
            fldVal2 = ConvertSearchValue(fldVal2, fldOpr2, fld); // For testing if numeric only
            fldOpr = ConvertSearchOperator(fldOpr, fld, fldVal);
            fldOpr2 = ConvertSearchOperator(fldOpr2, fld, fldVal2);
            if ((new [] { "BETWEEN", "NOT BETWEEN" }).Contains(fldOpr)) {
                isValid = fldDataType != DataType.Number || fld.VirtualSearch || IsNumericSearchValue(fldVal, fldOpr, fld) && IsNumericSearchValue(fldVal2, fldOpr2, fld);
                if (!Empty(fldVal) && !Empty(fldVal2) && isValid)
                    wrk = ctl + "=" + UrlEncode(fldVal) + "&" + ctl2 + "=" + UrlEncode(fldVal2) + "&z_" + fldParm + "=" + UrlEncode(fldOpr);
            } else {
                isValid = fldDataType != DataType.Number || fld.VirtualSearch || IsNumericSearchValue(fldVal, fldOpr, fld);
                if (!Empty(fldVal) && isValid && IsValidOperator(fldOpr)) {
                    wrk = ctl + "=" + UrlEncode(fldVal) + "&z_" + fldParm + "=" + UrlEncode(fldOpr);
                } else if ((new [] { "IS NULL", "IS NOT NULL", "IS EMPTY", "IS NOT EMPTY" }).Contains(fldOpr) || !Empty(fldOpr) && oprOnly && IsValidOperator(fldOpr)) {
                    wrk = "z_" + fldParm + "=" + UrlEncode(fldOpr);
                }
                isValid = fldDataType != DataType.Number || fld.VirtualSearch || IsNumericSearchValue(fldVal2, fldOpr2, fld);
                if (!Empty(fldVal2) && isValid && IsValidOperator(fldOpr2)) {
                    if (!Empty(wrk))
                        wrk += "&v_" + fldParm + "=" + fldCond + "&";
                    wrk += ctl2 + "=" + UrlEncode(fldVal2) + "&w_" + fldParm + "=" + UrlEncode(fldOpr2);
                } else if ((new [] { "IS NULL", "IS NOT NULL", "IS EMPTY", "IS NOT EMPTY" }).Contains(fldOpr2) || !Empty(fldOpr2) && oprOnly && IsValidOperator(fldOpr2)) {
                    if (!Empty(wrk))
                        wrk += "&v_" + fldParm + "=" + UrlEncode(fldCond) + "&";
                    wrk += "w_" + fldParm + "=" + UrlEncode(fldOpr2);
                }
            }
            if (!Empty(wrk)) {
                if (!Empty(url))
                    url += "&";
                url += wrk;
            }
        }

        // Load search values for validation // DN
        protected void LoadSearchValues() {
            // IdUser
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IdUser"))
                    IdUser.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdUser");
            if (Form.ContainsKey("z_IdUser"))
                IdUser.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdUser");

            // _Username
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x__Username"))
                    _Username.AdvancedSearch.SearchValue = CurrentForm.GetValue("x__Username", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z__Username"))
                _Username.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z__Username", Config.FilterOptionSeparator);

            // LinkRedirect
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_LinkRedirect"))
                    LinkRedirect.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_LinkRedirect", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_LinkRedirect"))
                LinkRedirect.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_LinkRedirect", Config.FilterOptionSeparator);

            // _Email
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x__Email"))
                    _Email.AdvancedSearch.SearchValue = CurrentForm.GetValue("x__Email", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z__Email"))
                _Email.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z__Email", Config.FilterOptionSeparator);

            // NamaLengkap
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NamaLengkap"))
                    NamaLengkap.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NamaLengkap", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_NamaLengkap"))
                NamaLengkap.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NamaLengkap", Config.FilterOptionSeparator);

            // IdPosition
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IdPosition"))
                    IdPosition.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdPosition", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_IdPosition"))
                IdPosition.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdPosition", Config.FilterOptionSeparator);

            // Jabatan
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Jabatan"))
                    Jabatan.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Jabatan", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Jabatan"))
                Jabatan.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Jabatan", Config.FilterOptionSeparator);

            // Face
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Face"))
                    Face.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Face", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Face"))
                Face.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Face", Config.FilterOptionSeparator);

            // TanggalInputFace
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TanggalInputFace"))
                    TanggalInputFace.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalInputFace", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TanggalInputFace"))
                TanggalInputFace.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalInputFace", Config.FilterOptionSeparator);

            // UserInputFace
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_UserInputFace"))
                    UserInputFace.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_UserInputFace", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_UserInputFace"))
                UserInputFace.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_UserInputFace", Config.FilterOptionSeparator);

            // AzurePersonId
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AzurePersonId"))
                    AzurePersonId.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AzurePersonId", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_AzurePersonId"))
                AzurePersonId.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AzurePersonId", Config.FilterOptionSeparator);
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
            IdUser.SetDbValue(row["IdUser"]);
            _Username.SetDbValue(row["Username"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            _Email.SetDbValue(row["Email"]);
            NamaLengkap.SetDbValue(row["NamaLengkap"]);
            DownloadFace.SetDbValue(row["DownloadFace"]);
            IdPosition.SetDbValue(row["IdPosition"]);
            Jabatan.SetDbValue(row["Jabatan"]);
            Face.SetDbValue(row["Face"]);
            TanggalInputFace.SetDbValue(row["TanggalInputFace"]);
            UserInputFace.SetDbValue(row["UserInputFace"]);
            AzurePersonId.SetDbValue(row["AzurePersonId"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdUser", IdUser.DefaultValue ?? DbNullValue); // DN
            row.Add("Username", _Username.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaLengkap", NamaLengkap.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadFace", DownloadFace.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPosition", IdPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("Jabatan", Jabatan.DefaultValue ?? DbNullValue); // DN
            row.Add("Face", Face.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalInputFace", TanggalInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("UserInputFace", UserInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("AzurePersonId", AzurePersonId.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // IdUser
            IdUser.RowCssClass = "row";

            // Username
            _Username.RowCssClass = "row";

            // LinkRedirect
            LinkRedirect.RowCssClass = "row";

            // Email
            _Email.RowCssClass = "row";

            // NamaLengkap
            NamaLengkap.RowCssClass = "row";

            // DownloadFace
            DownloadFace.RowCssClass = "row";

            // IdPosition
            IdPosition.RowCssClass = "row";

            // Jabatan
            Jabatan.RowCssClass = "row";

            // Face
            Face.RowCssClass = "row";

            // TanggalInputFace
            TanggalInputFace.RowCssClass = "row";

            // UserInputFace
            UserInputFace.RowCssClass = "row";

            // AzurePersonId
            AzurePersonId.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdUser
                IdUser.ViewValue = IdUser.CurrentValue;
                IdUser.ViewValue = FormatNumber(IdUser.ViewValue, IdUser.FormatPattern);
                IdUser.ViewCustomAttributes = "";

                // Username
                _Username.ViewValue = ConvertToString(_Username.CurrentValue); // DN
                _Username.ViewCustomAttributes = "";

                // LinkRedirect
                LinkRedirect.ViewValue = ConvertToString(LinkRedirect.CurrentValue); // DN
                LinkRedirect.ViewCustomAttributes = "";

                // Email
                _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                _Email.ViewCustomAttributes = "";

                // NamaLengkap
                NamaLengkap.ViewValue = ConvertToString(NamaLengkap.CurrentValue); // DN
                NamaLengkap.ViewCustomAttributes = "";

                // DownloadFace
                DownloadFace.ViewValue = DownloadFace.CurrentValue;
                DownloadFace.ViewCustomAttributes = "";

                // IdPosition
                IdPosition.ViewValue = IdPosition.CurrentValue;
                string curVal = ConvertToString(IdPosition.CurrentValue);
                if (!Empty(curVal)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.ViewValue = IdPosition.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.CurrentValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk = IdPosition.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk[0]);
                            IdPosition.ViewValue = IdPosition.DisplayValue(listwrk);
                        } else {
                            IdPosition.ViewValue = FormatNumber(IdPosition.CurrentValue, IdPosition.FormatPattern);
                        }
                    }
                } else {
                    IdPosition.ViewValue = DbNullValue;
                }
                IdPosition.ViewCustomAttributes = "";

                // Jabatan
                Jabatan.ViewValue = ConvertToString(Jabatan.CurrentValue); // DN
                Jabatan.ViewCustomAttributes = "";

                // Face
                Face.ViewValue = ConvertToString(Face.CurrentValue); // DN
                Face.ViewCustomAttributes = "";

                // TanggalInputFace
                TanggalInputFace.ViewValue = TanggalInputFace.CurrentValue;
                TanggalInputFace.ViewValue = FormatDateTime(TanggalInputFace.ViewValue, TanggalInputFace.FormatPattern);
                TanggalInputFace.ViewCustomAttributes = "";

                // UserInputFace
                UserInputFace.ViewValue = ConvertToString(UserInputFace.CurrentValue); // DN
                UserInputFace.ViewCustomAttributes = "";

                // AzurePersonId
                AzurePersonId.ViewValue = ConvertToString(AzurePersonId.CurrentValue); // DN
                AzurePersonId.ViewCustomAttributes = "";

                // IdUser
                IdUser.HrefValue = "";
                IdUser.TooltipValue = "";

                // Username
                _Username.HrefValue = "";
                _Username.TooltipValue = "";

                // Email
                _Email.HrefValue = "";
                _Email.TooltipValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";
                NamaLengkap.TooltipValue = "";

                // IdPosition
                IdPosition.HrefValue = "";
                IdPosition.TooltipValue = "";

                // Jabatan
                Jabatan.HrefValue = "";
                Jabatan.TooltipValue = "";

                // Face
                Face.HrefValue = "";
                Face.TooltipValue = "";

                // TanggalInputFace
                TanggalInputFace.HrefValue = "";
                TanggalInputFace.TooltipValue = "";

                // UserInputFace
                UserInputFace.HrefValue = "";
                UserInputFace.TooltipValue = "";

                // AzurePersonId
                AzurePersonId.HrefValue = "";
                AzurePersonId.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // IdUser
                IdUser.SetupEditAttributes();
                IdUser.EditValue = IdUser.AdvancedSearch.SearchValue;
                IdUser.PlaceHolder = RemoveHtml(IdUser.Caption);

                // Username
                _Username.SetupEditAttributes();
                if (!_Username.Raw)
                    _Username.AdvancedSearch.SearchValue = HtmlDecode(_Username.AdvancedSearch.SearchValue);
                _Username.EditValue = HtmlEncode(_Username.AdvancedSearch.SearchValue);
                _Username.PlaceHolder = RemoveHtml(_Username.Caption);

                // Email
                _Email.SetupEditAttributes();
                if (!_Email.Raw)
                    _Email.AdvancedSearch.SearchValue = HtmlDecode(_Email.AdvancedSearch.SearchValue);
                _Email.EditValue = HtmlEncode(_Email.AdvancedSearch.SearchValue);
                _Email.PlaceHolder = RemoveHtml(_Email.Caption);

                // NamaLengkap
                NamaLengkap.SetupEditAttributes();
                if (!NamaLengkap.Raw)
                    NamaLengkap.AdvancedSearch.SearchValue = HtmlDecode(NamaLengkap.AdvancedSearch.SearchValue);
                NamaLengkap.EditValue = HtmlEncode(NamaLengkap.AdvancedSearch.SearchValue);
                NamaLengkap.PlaceHolder = RemoveHtml(NamaLengkap.Caption);

                // IdPosition
                IdPosition.SetupEditAttributes();
                IdPosition.EditValue = IdPosition.AdvancedSearch.SearchValue;
                string curVal = ConvertToString(IdPosition.AdvancedSearch.SearchValue);
                if (!Empty(curVal)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.EditValue = IdPosition.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.AdvancedSearch.SearchValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk = IdPosition.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk[0]);
                            IdPosition.EditValue = IdPosition.DisplayValue(listwrk);
                        } else {
                            IdPosition.EditValue = HtmlEncode(FormatNumber(IdPosition.AdvancedSearch.SearchValue, IdPosition.FormatPattern));
                        }
                    }
                } else {
                    IdPosition.EditValue = DbNullValue;
                }
                IdPosition.PlaceHolder = RemoveHtml(IdPosition.Caption);

                // Jabatan
                Jabatan.SetupEditAttributes();
                if (!Jabatan.Raw)
                    Jabatan.AdvancedSearch.SearchValue = HtmlDecode(Jabatan.AdvancedSearch.SearchValue);
                Jabatan.EditValue = HtmlEncode(Jabatan.AdvancedSearch.SearchValue);
                Jabatan.PlaceHolder = RemoveHtml(Jabatan.Caption);

                // Face
                Face.SetupEditAttributes();
                if (!Face.Raw)
                    Face.AdvancedSearch.SearchValue = HtmlDecode(Face.AdvancedSearch.SearchValue);
                Face.EditValue = HtmlEncode(Face.AdvancedSearch.SearchValue);
                Face.PlaceHolder = RemoveHtml(Face.Caption);

                // TanggalInputFace
                TanggalInputFace.SetupEditAttributes();
                TanggalInputFace.EditValue = FormatDateTime(UnformatDateTime(TanggalInputFace.AdvancedSearch.SearchValue, TanggalInputFace.FormatPattern), TanggalInputFace.FormatPattern);
                TanggalInputFace.PlaceHolder = RemoveHtml(TanggalInputFace.Caption);

                // UserInputFace
                UserInputFace.SetupEditAttributes();
                if (!UserInputFace.Raw)
                    UserInputFace.AdvancedSearch.SearchValue = HtmlDecode(UserInputFace.AdvancedSearch.SearchValue);
                UserInputFace.EditValue = HtmlEncode(UserInputFace.AdvancedSearch.SearchValue);
                UserInputFace.PlaceHolder = RemoveHtml(UserInputFace.Caption);

                // AzurePersonId
                AzurePersonId.SetupEditAttributes();
                AzurePersonId.EditValue = AzurePersonId.AdvancedSearch.SearchValue;
                AzurePersonId.PlaceHolder = RemoveHtml(AzurePersonId.Caption);
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        // Validate search
        protected bool ValidateSearch() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            if (!CheckInteger(ConvertToString(IdUser.AdvancedSearch.SearchValue))) {
                IdUser.AddErrorMessage(IdUser.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(IdPosition.AdvancedSearch.SearchValue))) {
                IdPosition.AddErrorMessage(IdPosition.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalInputFace.AdvancedSearch.SearchValue), TanggalInputFace.FormatPattern)) {
                TanggalInputFace.AddErrorMessage(TanggalInputFace.GetErrorMessage(false));
            }
            if (!CheckGuid(ConvertToString(AzurePersonId.AdvancedSearch.SearchValue))) {
                AzurePersonId.AddErrorMessage(AzurePersonId.GetErrorMessage(false));
            }

            // Return validate result
            bool validateSearch = !HasInvalidFields();

            // Call Form CustomValidate event
            string formCustomError = "";
            validateSearch = validateSearch && FormCustomValidate(ref formCustomError);
            if (!Empty(formCustomError))
                FailureMessage = formCustomError;
            return validateSearch;
        }

        // Load advanced search
        public void LoadAdvancedSearch()
        {
            IdUser.AdvancedSearch.Load();
            _Username.AdvancedSearch.Load();
            _Email.AdvancedSearch.Load();
            NamaLengkap.AdvancedSearch.Load();
            IdPosition.AdvancedSearch.Load();
            Jabatan.AdvancedSearch.Load();
            Face.AdvancedSearch.Load();
            TanggalInputFace.AdvancedSearch.Load();
            UserInputFace.AdvancedSearch.Load();
            AzurePersonId.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("VFaceEnrollmentList")), "", TableVar, true);
            string pageId = "search";
            breadcrumb.Add("search", pageId, url);
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
