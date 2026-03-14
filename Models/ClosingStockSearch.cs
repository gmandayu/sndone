namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// closingStockSearch
    /// </summary>
    public static ClosingStockSearch closingStockSearch
    {
        get => HttpData.Get<ClosingStockSearch>("closingStockSearch")!;
        set => HttpData["closingStockSearch"] = value;
    }

    /// <summary>
    /// Page class for ClosingStock
    /// </summary>
    public class ClosingStockSearch : ClosingStockSearchBase
    {
        // Constructor
        public ClosingStockSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public ClosingStockSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class ClosingStockSearchBase : ClosingStock
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "closingStockSearch";

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
        public ClosingStockSearchBase()
        {
            TableName = "ClosingStock";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (closingStock)
            if (closingStock == null || closingStock is ClosingStock)
                closingStock = this;

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
        public string PageName => "ClosingStockSearch";

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
            IdClosingStock.Visible = false;
            IdTemplate.Visible = false;
            NomorClosingStock.Visible = false;
            Proses2.Visible = false;
            LookupPlant.Visible = false;
            Plant.Visible = false;
            TipeProdukSTS.Visible = false;
            IdTangki.Visible = false;
            TanggalClosingStock.SetVisibility();
            Produk.SetVisibility();
            StatusProses.Visible = false;
            PersentaseProgress.Visible = false;
            Catatan.Visible = false;
            DibuatOleh.Visible = false;
            TanggalDibuat.SetVisibility();
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.SetVisibility();
            PlantForLookup.Visible = false;
            LookupJenisPlant.Visible = false;
        }

        // Constructor
        public ClosingStockSearchBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "ClosingStockView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdClosingStock") ? dict["IdClosingStock"] : IdClosingStock.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdClosingStock.Visible = false;
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
            await SetupLookupOptions(LookupPlant);
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(TipeProdukSTS);
            await SetupLookupOptions(IdTangki);
            await SetupLookupOptions(Produk);

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
                    srchStr = "ClosingStockList?" + srchStr;
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
                closingStockSearch?.PageRender();
            }
            return PageResult();
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, TanggalClosingStock); // TanggalClosingStock
            BuildSearchUrl(ref srchUrl, Produk); // Produk
            BuildSearchUrl(ref srchUrl, TanggalDibuat); // TanggalDibuat
            BuildSearchUrl(ref srchUrl, TanggalDiperbarui); // TanggalDiperbarui
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
            // NomorClosingStock
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomorClosingStock"))
                    NomorClosingStock.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomorClosingStock", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_NomorClosingStock"))
                NomorClosingStock.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomorClosingStock", Config.FilterOptionSeparator);

            // Proses2
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Proses2"))
                    Proses2.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Proses2", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Proses2"))
                Proses2.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Proses2", Config.FilterOptionSeparator);

            // Plant
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Plant"))
                    Plant.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Plant", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Plant"))
                Plant.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Plant", Config.FilterOptionSeparator);

            // TipeProdukSTS
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TipeProdukSTS"))
                    TipeProdukSTS.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TipeProdukSTS", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TipeProdukSTS"))
                TipeProdukSTS.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TipeProdukSTS", Config.FilterOptionSeparator);

            // IdTangki
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IdTangki"))
                    IdTangki.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdTangki", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_IdTangki"))
                IdTangki.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdTangki", Config.FilterOptionSeparator);

            // TanggalClosingStock
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TanggalClosingStock"))
                    TanggalClosingStock.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalClosingStock", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TanggalClosingStock"))
                TanggalClosingStock.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalClosingStock", Config.FilterOptionSeparator);

            // Produk
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Produk"))
                    Produk.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Produk", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Produk"))
                Produk.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Produk", Config.FilterOptionSeparator);

            // StatusProses
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_StatusProses"))
                    StatusProses.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_StatusProses", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_StatusProses"))
                StatusProses.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_StatusProses", Config.FilterOptionSeparator);

            // PersentaseProgress
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PersentaseProgress"))
                    PersentaseProgress.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PersentaseProgress", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_PersentaseProgress"))
                PersentaseProgress.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PersentaseProgress", Config.FilterOptionSeparator);

            // Catatan
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Catatan"))
                    Catatan.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Catatan", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Catatan"))
                Catatan.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Catatan", Config.FilterOptionSeparator);

            // DibuatOleh
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_DibuatOleh"))
                    DibuatOleh.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DibuatOleh", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_DibuatOleh"))
                DibuatOleh.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DibuatOleh", Config.FilterOptionSeparator);

            // TanggalDibuat
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TanggalDibuat"))
                    TanggalDibuat.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalDibuat", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TanggalDibuat"))
                TanggalDibuat.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalDibuat", Config.FilterOptionSeparator);
            if (Form.ContainsKey("v_TanggalDibuat"))
                TanggalDibuat.AdvancedSearch.SearchCondition = CurrentForm.GetValue("v_TanggalDibuat", Config.FilterOptionSeparator);
            if (Form.ContainsKey("y_TanggalDibuat"))
                TanggalDibuat.AdvancedSearch.SearchValue2 = CurrentForm.GetValue("y_TanggalDibuat", Config.FilterOptionSeparator);
            if (Form.ContainsKey("w_TanggalDibuat"))
                TanggalDibuat.AdvancedSearch.SearchOperator2 = CurrentForm.GetValue("w_TanggalDibuat", Config.FilterOptionSeparator);

            // DiperbaruiOleh
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_DiperbaruiOleh"))
                    DiperbaruiOleh.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DiperbaruiOleh", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_DiperbaruiOleh"))
                DiperbaruiOleh.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DiperbaruiOleh", Config.FilterOptionSeparator);

            // TanggalDiperbarui
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TanggalDiperbarui"))
                    TanggalDiperbarui.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalDiperbarui", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TanggalDiperbarui"))
                TanggalDiperbarui.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalDiperbarui", Config.FilterOptionSeparator);
            if (Form.ContainsKey("v_TanggalDiperbarui"))
                TanggalDiperbarui.AdvancedSearch.SearchCondition = CurrentForm.GetValue("v_TanggalDiperbarui", Config.FilterOptionSeparator);
            if (Form.ContainsKey("y_TanggalDiperbarui"))
                TanggalDiperbarui.AdvancedSearch.SearchValue2 = CurrentForm.GetValue("y_TanggalDiperbarui", Config.FilterOptionSeparator);
            if (Form.ContainsKey("w_TanggalDiperbarui"))
                TanggalDiperbarui.AdvancedSearch.SearchOperator2 = CurrentForm.GetValue("w_TanggalDiperbarui", Config.FilterOptionSeparator);
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
            IdClosingStock.SetDbValue(row["IdClosingStock"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            NomorClosingStock.SetDbValue(row["NomorClosingStock"]);
            Proses2.SetDbValue(row["Proses"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            Plant.SetDbValue(row["Plant"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            IdTangki.SetDbValue(row["IdTangki"]);
            TanggalClosingStock.SetDbValue(row["TanggalClosingStock"]);
            Produk.SetDbValue(row["Produk"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            PersentaseProgress.SetDbValue(IsNull(row["PersentaseProgress"]) ? DbNullValue : ConvertToDouble(row["PersentaseProgress"]));
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            PlantForLookup.SetDbValue(row["PlantForLookup"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdClosingStock", IdClosingStock.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplate", IdTemplate.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorClosingStock", NomorClosingStock.DefaultValue ?? DbNullValue); // DN
            row.Add("Proses", Proses2.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProdukSTS", TipeProdukSTS.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTangki", IdTangki.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalClosingStock", TanggalClosingStock.DefaultValue ?? DbNullValue); // DN
            row.Add("Produk", Produk.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusProses", StatusProses.DefaultValue ?? DbNullValue); // DN
            row.Add("PersentaseProgress", PersentaseProgress.DefaultValue ?? DbNullValue); // DN
            row.Add("Catatan", Catatan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("PlantForLookup", PlantForLookup.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupJenisPlant", LookupJenisPlant.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // IdClosingStock
            IdClosingStock.RowCssClass = "row";

            // IdTemplate
            IdTemplate.RowCssClass = "row";

            // NomorClosingStock
            NomorClosingStock.RowCssClass = "row";

            // Proses
            Proses2.RowCssClass = "row";

            // LookupPlant
            LookupPlant.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // TipeProdukSTS
            TipeProdukSTS.RowCssClass = "row";

            // IdTangki
            IdTangki.RowCssClass = "row";

            // TanggalClosingStock
            TanggalClosingStock.RowCssClass = "row";

            // Produk
            Produk.RowCssClass = "row";

            // StatusProses
            StatusProses.RowCssClass = "row";

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

            // LookupJenisPlant
            LookupJenisPlant.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IdClosingStock
                IdClosingStock.ViewValue = IdClosingStock.CurrentValue;
                IdClosingStock.ViewValue = FormatNumber(IdClosingStock.ViewValue, IdClosingStock.FormatPattern);
                IdClosingStock.ViewCustomAttributes = "";

                // IdTemplate
                IdTemplate.ViewValue = IdTemplate.CurrentValue;
                IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
                IdTemplate.ViewCustomAttributes = "";

                // NomorClosingStock
                NomorClosingStock.ViewValue = ConvertToString(NomorClosingStock.CurrentValue); // DN
                NomorClosingStock.ViewCustomAttributes = "";

                // Proses
                Proses2.ViewValue = ConvertToString(Proses2.CurrentValue); // DN
                Proses2.ViewCustomAttributes = "";

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

                // IdTangki
                string curVal4 = ConvertToString(IdTangki.CurrentValue);
                if (!Empty(curVal4)) {
                    if (IdTangki.Lookup != null && IsDictionary(IdTangki.Lookup?.Options) && IdTangki.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdTangki.ViewValue = IdTangki.LookupCacheOption(curVal4);
                    } else { // Lookup from database // DN
                        string filterWrk4 = SearchFilter(IdTangki.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdTangki.CurrentValue, IdTangki.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                        var lookupFilter4 = () => IdTangki.GetSelectFilter();
                        string? sqlWrk4 = IdTangki.Lookup?.GetSql(false, filterWrk4, lookupFilter4, this, true, true);
                        List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk4?.Count > 0 && IdTangki.Lookup != null) { // Lookup values found
                            var listwrk = IdTangki.Lookup?.RenderViewRow(rswrk4[0]);
                            IdTangki.ViewValue = IdTangki.DisplayValue(listwrk);
                        } else {
                            IdTangki.ViewValue = FormatNumber(IdTangki.CurrentValue, IdTangki.FormatPattern);
                        }
                    }
                } else {
                    IdTangki.ViewValue = DbNullValue;
                }
                IdTangki.ViewCustomAttributes = "";

                // TanggalClosingStock
                TanggalClosingStock.ViewValue = TanggalClosingStock.CurrentValue;
                TanggalClosingStock.ViewValue = FormatDateTime(TanggalClosingStock.ViewValue, TanggalClosingStock.FormatPattern);
                TanggalClosingStock.ViewCustomAttributes = "";

                // Produk
                if (!Empty(Produk.CurrentValue)) {
                    Produk.ViewValue = Produk.OptionCaption(ConvertToString(Produk.CurrentValue));
                } else {
                    Produk.ViewValue = DbNullValue;
                }
                Produk.ViewCustomAttributes = "";

                // StatusProses
                StatusProses.ViewValue = StatusProses.CurrentValue;
                StatusProses.ViewCustomAttributes = "";

                // PersentaseProgress
                PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
                PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
                PersentaseProgress.ViewCustomAttributes = "";

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

                // TanggalClosingStock
                TanggalClosingStock.HrefValue = "";
                TanggalClosingStock.TooltipValue = "";

                // Produk
                Produk.HrefValue = "";
                Produk.TooltipValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";
                TanggalDibuat.TooltipValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
                TanggalDiperbarui.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // TanggalClosingStock
                TanggalClosingStock.SetupEditAttributes();
                TanggalClosingStock.EditValue = FormatDateTime(UnformatDateTime(TanggalClosingStock.AdvancedSearch.SearchValue, TanggalClosingStock.FormatPattern), TanggalClosingStock.FormatPattern);
                TanggalClosingStock.PlaceHolder = RemoveHtml(TanggalClosingStock.Caption);

                // Produk
                Produk.SetupEditAttributes();
                Produk.EditValue = Produk.Options(true);
                Produk.PlaceHolder = RemoveHtml(Produk.Caption);

                // TanggalDibuat
                TanggalDibuat.SetupEditAttributes();
                TanggalDibuat.EditValue = FormatDateTime(UnformatDateTime(TanggalDibuat.AdvancedSearch.SearchValue, TanggalDibuat.FormatPattern), TanggalDibuat.FormatPattern);
                TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);
                TanggalDibuat.SetupEditAttributes();
                TanggalDibuat.EditValue2 = FormatDateTime(UnformatDateTime(TanggalDibuat.AdvancedSearch.SearchValue2, TanggalDibuat.FormatPattern), TanggalDibuat.FormatPattern);
                TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);

                // TanggalDiperbarui
                TanggalDiperbarui.SetupEditAttributes();
                TanggalDiperbarui.EditValue = FormatDateTime(UnformatDateTime(TanggalDiperbarui.AdvancedSearch.SearchValue, TanggalDiperbarui.FormatPattern), TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);
                TanggalDiperbarui.SetupEditAttributes();
                TanggalDiperbarui.EditValue2 = FormatDateTime(UnformatDateTime(TanggalDiperbarui.AdvancedSearch.SearchValue2, TanggalDiperbarui.FormatPattern), TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);
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
            if (!CheckDate(ConvertToString(TanggalClosingStock.AdvancedSearch.SearchValue), TanggalClosingStock.FormatPattern)) {
                TanggalClosingStock.AddErrorMessage(TanggalClosingStock.GetErrorMessage(false));
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
            TanggalClosingStock.AdvancedSearch.Load();
            Produk.AdvancedSearch.Load();
            TanggalDibuat.AdvancedSearch.Load();
            TanggalDiperbarui.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("ClosingStockList")), "", TableVar, true);
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
