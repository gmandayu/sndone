namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penyaluranSearch
    /// </summary>
    public static PenyaluranSearch penyaluranSearch
    {
        get => HttpData.Get<PenyaluranSearch>("penyaluranSearch")!;
        set => HttpData["penyaluranSearch"] = value;
    }

    /// <summary>
    /// Page class for Penyaluran
    /// </summary>
    public class PenyaluranSearch : PenyaluranSearchBase
    {
        // Constructor
        public PenyaluranSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenyaluranSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenyaluranSearchBase : Penyaluran
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penyaluranSearch";

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
        public PenyaluranSearchBase()
        {
            TableName = "Penyaluran";

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

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
        public string PageName => "PenyaluranSearch";

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
            LookupPlant.Visible = false;
            IdPlant.Visible = false;
            TipePenyaluran.Visible = false;
            TipeProdukSTS.Visible = false;
            KategoriPenyaluran.Visible = false;
            IdModa.Visible = false;
            DetailRTW.Visible = false;
            NoShipment.SetVisibility();
            IdPipa.SetVisibility();
            NomorPolisi.Visible = false;
            NamaKapal.Visible = false;
            JenisProduk.Visible = false;
            IdPenimbunan.Visible = false;
            StatusProses.Visible = false;
            IdTemplate.Visible = false;
            PersentaseProgress.Visible = false;
            Tujuan.Visible = false;
            TujuanKonsinyasi.Visible = false;
            Volume.Visible = false;
            TujuanKonsinyasiPipa.SetVisibility();
            QuantityKonsinyasiPipa.SetVisibility();
            TujuanKonsinyasi2.Visible = false;
            Volume2.Visible = false;
            TujuanKonsinyasi3.Visible = false;
            Volume3.Visible = false;
            TanggalSandar.SetVisibility();
            Catatan.Visible = false;
            DibuatOleh.Visible = false;
            TanggalDibuat.SetVisibility();
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.SetVisibility();
            LookupTipeProduk.Visible = false;
            LookupJenisPlant.Visible = false;
            MultipleTujuanKonsinyasi.SetVisibility();
            MultipleTujuanKonsinyasiHidden.SetVisibility();
            MultipleQuantity.SetVisibility();
        }

        // Constructor
        public PenyaluranSearchBase(Controller? controller = null): this() { // DN
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
                                result.Add("view", pageName == "PenyaluranView" ? "1" : "0"); // If View page, no primary button
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
                    srchStr = "PenyaluranList?" + srchStr;
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
                penyaluranSearch?.PageRender();
            }
            return PageResult();
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, NoShipment); // NoShipment
            BuildSearchUrl(ref srchUrl, IdPipa); // IdPipa
            BuildSearchUrl(ref srchUrl, TujuanKonsinyasiPipa); // TujuanKonsinyasiPipa
            BuildSearchUrl(ref srchUrl, QuantityKonsinyasiPipa); // QuantityKonsinyasiPipa
            BuildSearchUrl(ref srchUrl, TanggalSandar); // TanggalSandar
            BuildSearchUrl(ref srchUrl, TanggalDibuat); // TanggalDibuat
            BuildSearchUrl(ref srchUrl, TanggalDiperbarui); // TanggalDiperbarui
            BuildSearchUrl(ref srchUrl, MultipleTujuanKonsinyasi); // MultipleTujuanKonsinyasi
            BuildSearchUrl(ref srchUrl, MultipleTujuanKonsinyasiHidden); // MultipleTujuanKonsinyasiHidden
            BuildSearchUrl(ref srchUrl, MultipleQuantity); // MultipleQuantity
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
            // NomorPenyaluran
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomorPenyaluran"))
                    NomorPenyaluran.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomorPenyaluran", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_NomorPenyaluran"))
                NomorPenyaluran.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomorPenyaluran", Config.FilterOptionSeparator);

            // LinkProses
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_LinkProses"))
                    LinkProses.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_LinkProses", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_LinkProses"))
                LinkProses.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_LinkProses", Config.FilterOptionSeparator);

            // IdPlant
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IdPlant"))
                    IdPlant.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdPlant", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_IdPlant"))
                IdPlant.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdPlant", Config.FilterOptionSeparator);

            // TipePenyaluran
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TipePenyaluran"))
                    TipePenyaluran.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TipePenyaluran", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TipePenyaluran"))
                TipePenyaluran.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TipePenyaluran", Config.FilterOptionSeparator);

            // TipeProdukSTS
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TipeProdukSTS"))
                    TipeProdukSTS.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TipeProdukSTS", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TipeProdukSTS"))
                TipeProdukSTS.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TipeProdukSTS", Config.FilterOptionSeparator);

            // KategoriPenyaluran
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_KategoriPenyaluran"))
                    KategoriPenyaluran.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_KategoriPenyaluran", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_KategoriPenyaluran"))
                KategoriPenyaluran.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_KategoriPenyaluran", Config.FilterOptionSeparator);

            // IdModa
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IdModa"))
                    IdModa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdModa", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_IdModa"))
                IdModa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdModa", Config.FilterOptionSeparator);

            // NoShipment
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NoShipment"))
                    NoShipment.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NoShipment", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_NoShipment"))
                NoShipment.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NoShipment", Config.FilterOptionSeparator);

            // IdPipa
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IdPipa"))
                    IdPipa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdPipa", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_IdPipa"))
                IdPipa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdPipa", Config.FilterOptionSeparator);

            // NomorPolisi
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomorPolisi"))
                    NomorPolisi.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomorPolisi", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_NomorPolisi"))
                NomorPolisi.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomorPolisi", Config.FilterOptionSeparator);

            // NamaKapal
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NamaKapal"))
                    NamaKapal.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NamaKapal", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_NamaKapal"))
                NamaKapal.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NamaKapal", Config.FilterOptionSeparator);

            // JenisProduk
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_JenisProduk"))
                    JenisProduk.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_JenisProduk", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_JenisProduk"))
                JenisProduk.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_JenisProduk", Config.FilterOptionSeparator);

            // IdPenimbunan
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IdPenimbunan"))
                    IdPenimbunan.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdPenimbunan", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_IdPenimbunan"))
                IdPenimbunan.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdPenimbunan", Config.FilterOptionSeparator);

            // StatusProses
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_StatusProses"))
                    StatusProses.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_StatusProses", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_StatusProses"))
                StatusProses.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_StatusProses", Config.FilterOptionSeparator);

            // IdTemplate
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IdTemplate"))
                    IdTemplate.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IdTemplate", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_IdTemplate"))
                IdTemplate.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IdTemplate", Config.FilterOptionSeparator);

            // PersentaseProgress
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PersentaseProgress"))
                    PersentaseProgress.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PersentaseProgress", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_PersentaseProgress"))
                PersentaseProgress.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PersentaseProgress", Config.FilterOptionSeparator);

            // Tujuan
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Tujuan"))
                    Tujuan.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Tujuan", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Tujuan"))
                Tujuan.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Tujuan", Config.FilterOptionSeparator);

            // TujuanKonsinyasi
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TujuanKonsinyasi"))
                    TujuanKonsinyasi.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TujuanKonsinyasi", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TujuanKonsinyasi"))
                TujuanKonsinyasi.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TujuanKonsinyasi", Config.FilterOptionSeparator);

            // Volume
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Volume"))
                    Volume.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Volume", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Volume"))
                Volume.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Volume", Config.FilterOptionSeparator);

            // TujuanKonsinyasiPipa
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TujuanKonsinyasiPipa"))
                    TujuanKonsinyasiPipa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TujuanKonsinyasiPipa", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TujuanKonsinyasiPipa"))
                TujuanKonsinyasiPipa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TujuanKonsinyasiPipa", Config.FilterOptionSeparator);

            // QuantityKonsinyasiPipa
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_QuantityKonsinyasiPipa"))
                    QuantityKonsinyasiPipa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_QuantityKonsinyasiPipa", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_QuantityKonsinyasiPipa"))
                QuantityKonsinyasiPipa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_QuantityKonsinyasiPipa", Config.FilterOptionSeparator);

            // TujuanKonsinyasi2
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TujuanKonsinyasi2"))
                    TujuanKonsinyasi2.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TujuanKonsinyasi2", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TujuanKonsinyasi2"))
                TujuanKonsinyasi2.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TujuanKonsinyasi2", Config.FilterOptionSeparator);

            // Volume2
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Volume2"))
                    Volume2.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Volume2", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Volume2"))
                Volume2.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Volume2", Config.FilterOptionSeparator);

            // TujuanKonsinyasi3
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TujuanKonsinyasi3"))
                    TujuanKonsinyasi3.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TujuanKonsinyasi3", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TujuanKonsinyasi3"))
                TujuanKonsinyasi3.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TujuanKonsinyasi3", Config.FilterOptionSeparator);

            // Volume3
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Volume3"))
                    Volume3.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Volume3", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_Volume3"))
                Volume3.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Volume3", Config.FilterOptionSeparator);

            // TanggalSandar
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_TanggalSandar"))
                    TanggalSandar.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_TanggalSandar", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_TanggalSandar"))
                TanggalSandar.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_TanggalSandar", Config.FilterOptionSeparator);
            if (Form.ContainsKey("v_TanggalSandar"))
                TanggalSandar.AdvancedSearch.SearchCondition = CurrentForm.GetValue("v_TanggalSandar", Config.FilterOptionSeparator);
            if (Form.ContainsKey("y_TanggalSandar"))
                TanggalSandar.AdvancedSearch.SearchValue2 = CurrentForm.GetValue("y_TanggalSandar", Config.FilterOptionSeparator);
            if (Form.ContainsKey("w_TanggalSandar"))
                TanggalSandar.AdvancedSearch.SearchOperator2 = CurrentForm.GetValue("w_TanggalSandar", Config.FilterOptionSeparator);

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

            // MultipleTujuanKonsinyasi
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MultipleTujuanKonsinyasi"))
                    MultipleTujuanKonsinyasi.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MultipleTujuanKonsinyasi", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_MultipleTujuanKonsinyasi"))
                MultipleTujuanKonsinyasi.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MultipleTujuanKonsinyasi", Config.FilterOptionSeparator);

            // MultipleTujuanKonsinyasiHidden
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MultipleTujuanKonsinyasiHidden"))
                    MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MultipleTujuanKonsinyasiHidden", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_MultipleTujuanKonsinyasiHidden"))
                MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MultipleTujuanKonsinyasiHidden", Config.FilterOptionSeparator);

            // MultipleQuantity
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MultipleQuantity"))
                    MultipleQuantity.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MultipleQuantity", Config.FilterOptionSeparator);
            if (Form.ContainsKey("z_MultipleQuantity"))
                MultipleQuantity.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MultipleQuantity", Config.FilterOptionSeparator);
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

                // NoShipment
                NoShipment.HrefValue = "";
                NoShipment.TooltipValue = "";

                // IdPipa
                IdPipa.HrefValue = "";
                IdPipa.TooltipValue = "";

                // TujuanKonsinyasiPipa
                TujuanKonsinyasiPipa.HrefValue = "";
                TujuanKonsinyasiPipa.TooltipValue = "";

                // QuantityKonsinyasiPipa
                QuantityKonsinyasiPipa.HrefValue = "";
                QuantityKonsinyasiPipa.TooltipValue = "";

                // TanggalSandar
                TanggalSandar.HrefValue = "";
                TanggalSandar.TooltipValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";
                TanggalDibuat.TooltipValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
                TanggalDiperbarui.TooltipValue = "";

                // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.HrefValue = "";
                MultipleTujuanKonsinyasi.TooltipValue = "";

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.HrefValue = "";
                MultipleTujuanKonsinyasiHidden.TooltipValue = "";

                // MultipleQuantity
                MultipleQuantity.HrefValue = "";
                MultipleQuantity.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // NoShipment
                NoShipment.SetupEditAttributes();
                if (!NoShipment.Raw)
                    NoShipment.AdvancedSearch.SearchValue = HtmlDecode(NoShipment.AdvancedSearch.SearchValue);
                NoShipment.EditValue = HtmlEncode(NoShipment.AdvancedSearch.SearchValue);
                NoShipment.PlaceHolder = RemoveHtml(NoShipment.Caption);

                // IdPipa
                IdPipa.SetupEditAttributes();
                string curVal7 = ConvertToString(IdPipa.AdvancedSearch.SearchValue);
                if (IdPipa.Lookup != null && IsDictionary(IdPipa.Lookup?.Options) && IdPipa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPipa.EditValue = IdPipa.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk7 = "";
                    if (curVal7 == "") {
                        filterWrk7 = "0=1";
                    } else {
                        filterWrk7 = SearchFilter(IdPipa.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdPipa.AdvancedSearch.SearchValue, IdPipa.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                    }
                    string? sqlWrk7 = IdPipa.Lookup?.GetSql(true, filterWrk7, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    IdPipa.EditValue = rswrk7;
                }
                IdPipa.PlaceHolder = RemoveHtml(IdPipa.Caption);

                // TujuanKonsinyasiPipa
                TujuanKonsinyasiPipa.SetupEditAttributes();
                if (!TujuanKonsinyasiPipa.Raw)
                    TujuanKonsinyasiPipa.AdvancedSearch.SearchValue = HtmlDecode(TujuanKonsinyasiPipa.AdvancedSearch.SearchValue);
                TujuanKonsinyasiPipa.EditValue = HtmlEncode(TujuanKonsinyasiPipa.AdvancedSearch.SearchValue);
                TujuanKonsinyasiPipa.PlaceHolder = RemoveHtml(TujuanKonsinyasiPipa.Caption);

                // QuantityKonsinyasiPipa
                QuantityKonsinyasiPipa.SetupEditAttributes();
                if (!QuantityKonsinyasiPipa.Raw)
                    QuantityKonsinyasiPipa.AdvancedSearch.SearchValue = HtmlDecode(QuantityKonsinyasiPipa.AdvancedSearch.SearchValue);
                QuantityKonsinyasiPipa.EditValue = HtmlEncode(QuantityKonsinyasiPipa.AdvancedSearch.SearchValue);
                QuantityKonsinyasiPipa.PlaceHolder = RemoveHtml(QuantityKonsinyasiPipa.Caption);

                // TanggalSandar
                TanggalSandar.SetupEditAttributes();
                TanggalSandar.EditValue = FormatDateTime(UnformatDateTime(TanggalSandar.AdvancedSearch.SearchValue, TanggalSandar.FormatPattern), TanggalSandar.FormatPattern);
                TanggalSandar.PlaceHolder = RemoveHtml(TanggalSandar.Caption);
                TanggalSandar.SetupEditAttributes();
                TanggalSandar.EditValue2 = FormatDateTime(UnformatDateTime(TanggalSandar.AdvancedSearch.SearchValue2, TanggalSandar.FormatPattern), TanggalSandar.FormatPattern);
                TanggalSandar.PlaceHolder = RemoveHtml(TanggalSandar.Caption);

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

                // MultipleTujuanKonsinyasi
                MultipleTujuanKonsinyasi.SetupEditAttributes();
                MultipleTujuanKonsinyasi.EditValue = MultipleTujuanKonsinyasi.Options(true);
                MultipleTujuanKonsinyasi.PlaceHolder = RemoveHtml(MultipleTujuanKonsinyasi.Caption);

                // MultipleTujuanKonsinyasiHidden
                MultipleTujuanKonsinyasiHidden.SetupEditAttributes();
                if (!MultipleTujuanKonsinyasiHidden.Raw)
                    MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchValue = HtmlDecode(MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchValue);
                MultipleTujuanKonsinyasiHidden.EditValue = HtmlEncode(MultipleTujuanKonsinyasiHidden.AdvancedSearch.SearchValue);
                MultipleTujuanKonsinyasiHidden.PlaceHolder = RemoveHtml(MultipleTujuanKonsinyasiHidden.Caption);

                // MultipleQuantity
                MultipleQuantity.SetupEditAttributes();
                if (!MultipleQuantity.Raw)
                    MultipleQuantity.AdvancedSearch.SearchValue = HtmlDecode(MultipleQuantity.AdvancedSearch.SearchValue);
                MultipleQuantity.EditValue = HtmlEncode(MultipleQuantity.AdvancedSearch.SearchValue);
                MultipleQuantity.PlaceHolder = RemoveHtml(MultipleQuantity.Caption);
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
            if (!CheckDate(ConvertToString(TanggalSandar.AdvancedSearch.SearchValue), TanggalSandar.FormatPattern)) {
                TanggalSandar.AddErrorMessage(TanggalSandar.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalSandar.AdvancedSearch.SearchValue2), TanggalSandar.FormatPattern)) {
                TanggalSandar.AddErrorMessage(TanggalSandar.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalDibuat.AdvancedSearch.SearchValue), TanggalDibuat.FormatPattern)) {
                TanggalDibuat.AddErrorMessage(TanggalDibuat.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalDibuat.AdvancedSearch.SearchValue2), TanggalDibuat.FormatPattern)) {
                TanggalDibuat.AddErrorMessage(TanggalDibuat.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalDiperbarui.AdvancedSearch.SearchValue), TanggalDiperbarui.FormatPattern)) {
                TanggalDiperbarui.AddErrorMessage(TanggalDiperbarui.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(TanggalDiperbarui.AdvancedSearch.SearchValue2), TanggalDiperbarui.FormatPattern)) {
                TanggalDiperbarui.AddErrorMessage(TanggalDiperbarui.GetErrorMessage(false));
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
            NoShipment.AdvancedSearch.Load();
            IdPipa.AdvancedSearch.Load();
            TujuanKonsinyasiPipa.AdvancedSearch.Load();
            QuantityKonsinyasiPipa.AdvancedSearch.Load();
            TanggalSandar.AdvancedSearch.Load();
            TanggalDibuat.AdvancedSearch.Load();
            TanggalDiperbarui.AdvancedSearch.Load();
            MultipleTujuanKonsinyasi.AdvancedSearch.Load();
            MultipleTujuanKonsinyasiHidden.AdvancedSearch.Load();
            MultipleQuantity.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("PenyaluranList")), "", TableVar, true);
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
