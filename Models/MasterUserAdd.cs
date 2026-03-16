using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterUserAdd
    /// </summary>
    public static MasterUserAdd masterUserAdd
    {
        get => HttpData.Get<MasterUserAdd>("masterUserAdd")!;
        set => HttpData["masterUserAdd"] = value;
    }

    /// <summary>
    /// Page class for MasterUser
    /// </summary>
    public class MasterUserAdd : MasterUserAddBase
    {
        // Constructor
        public MasterUserAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MasterUserAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
            IdPosition.DisplayValueSeparator = " - ";
            if (CurrentPageID() == "add")
                IdIdaman.RowAttrs["class"] = "d-none";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MasterUserAddBase : MasterUser
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "masterUserAdd";

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
        public MasterUserAddBase(Controller? controller)
        {
            TableName = "MasterUser";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (masterUser)
            if (masterUser == null || masterUser is MasterUser)
                masterUser = this;

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
        public string PageName => "MasterUserAdd";

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
            IdUser.Visible = false;
            _Email.SetVisibility();
            _Username.SetVisibility();
            PasswordHash.SetVisibility();
            NamaLengkap.SetVisibility();
            _UserLevel.SetVisibility();
            Rule.SetVisibility();
            IdPosition.SetVisibility();
            Region.SetVisibility();
            Plant.SetVisibility();
            LookupPosition.SetVisibility();
            StatusAktif.SetVisibility();
            Keterangan.SetVisibility();
            DibuatOleh.Visible = false;
            TanggalDibuat.Visible = false;
            DiperbaruiOleh.Visible = false;
            TanggalDiperbarui.Visible = false;
            IsResetable.Visible = false;
            IsVerify.Visible = false;
            Face.Visible = false;
            AzurePersonId.Visible = false;
            TanggalInputFace.Visible = false;
            UserInputFace.Visible = false;
            IdIdaman.SetVisibility();
            exception.Visible = false;
        }

        // Constructor
        public MasterUserAddBase() : this(null) { }

        /// <summary>
        /// Terminate page
        /// </summary>
        /// <param name="url">URL to rediect to</param>
        /// <returns>Page result</returns>
        public override IActionResult Terminate(string url = "")
        { // DN
            if (_terminated) return new EmptyResult();
            InvokeUnloadHooks();
            if (!IsApi()) PageRedirecting(ref url);
            Collect();                // DN
            _terminated = true;       // DN
            if (IsApi()) return BuildApiTerminateResult(url);
            if (ActionResult != null) return ActionResult;
            if (Empty(url)) return new EmptyResult();
            if (!Config.Debug) ResponseClear();
            if (Response != null && !Response.HasStarted)
                return HandleRedirect(url);
            return new EmptyResult();
        }

        // ================= HELPER METHODS =================
        private void InvokeUnloadHooks()
        {
                    // Page Unload event
                    PageUnload();

                // Global Page Unloaded event
                PageUnloaded();
            PageUnloadedEventHandler?.Invoke(null, EventArgs.Empty);
        }

        private IActionResult BuildApiTerminateResult(string url)
        {
            var result = new Dictionary<string, string> { { "version", Config.ProductVersion } };
            if (!Empty(url)) result.Add("url", GetUrl(url));
            foreach (var (key, value) in GetMessages()) result.Add(key, value);
            return Controller.Json(result);
        }

        private IActionResult HandleRedirect(string url)
        {
            if (IsModal) return BuildModalResult_ListAddEditUpdateViewSearch(url);
            SaveDebugMessage();
            return RedirectCore(url);
        }

        private IActionResult RedirectCore(string url)
        {
            return Controller.LocalRedirect(AppPath(url));
        }

        private IActionResult BuildModalResult_ListAddEditUpdateViewSearch(string url)
        {
            string pageName = GetPageName(url);
                var result = new Dictionary<string, string> { { "url", GetUrl(url) }, { "modal", "1" } }; // modal=1
                    if (SameString(pageName, GetPageName(ListUrl)) ||
                        SameString(pageName, GetPageName(ViewUrl)) ||
                        SameString(pageName, GetPageName(GetCurrentMasterTable()?.ViewUrl ?? "")))
                    {
                // List / View / Master View page
                    if (!SameString(pageName, ListUrl))
                    {
                        result.Add("caption", GetModalCaption(pageName));
                        result.Add("view", pageName == "MasterUserView" ? "1" : "0"); // If View page, no primary button
                    }
                    else
                    {
                        result.Add("error", FailureMessage); // List page should not be shown as modal => error
                        ClearFailureMessage();
                    }
                    }
                    else
                    { // Other pages (add messages and then clear messages)
                        result = GetMessages();
                        result.Add("modal", "1");
                        ClearMessages();
                    }
                return Controller.Json(result);
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

        // Get record from Dictionary (refactor: low cognitive complexity)
        protected Dictionary<string, object>? GetRecordFromDictionary(Dictionary<string, object>? dict)
        {
            if (dict is null) return null;
            var row = new Dictionary<string, object>();
            foreach (var (key, value) in dict)
            {
                if (!Fields.TryGetValue(key, out DbField? fld) || fld is null) continue;
                if (!ShouldIncludeField(fld)) continue;
                var cell = fld.HtmlTag == "FILE"
                    ? BuildFileCell(fld, value, dict)
                    : BuildScalarCell(fld, value);
                if (cell is not null)
                    row[key] = cell;
            }
            return row;
        }

        // ---- Helpers ----
        private static bool ShouldIncludeField(DbField fld)
            => fld.Visible || fld.IsPrimaryKey;

        private object? BuildFileCell(DbField fld, object value, Dictionary<string, object> srcRow)
        {
            if (Empty(value)) return null; // (sesuai kode asli: tidak menambahkan key)

            // Blob
            if (fld.DataType == DataType.Blob)
            {
                var bytes = (byte[])value;
                var url = FullUrl($"{GetPageName(Config.ApiUrl)}/{Config.ApiFileAction}/{fld.TableVar}/{fld.Param}/{GetRecordKeyValue(srcRow)}");
                return FileMeta(ContentType(bytes), url, fld.Param + ContentExtension(bytes));
            }

            // Non-blob
            var s = ConvertToString(value);
            if (!fld.UploadMultiple || !s.Contains(Config.MultipleUploadSeparator))
            {
                var url = FullUrl($"{GetPageName(Config.ApiUrl)}/{Config.ApiFileAction}/{fld.TableVar}/{Encrypt(fld.PhysicalUploadPath + s)}");
                return FileMeta(ContentType(s), url, s);
            }

            // Multiple files
            var files = s.Split(Config.MultipleUploadSeparator);
            return files
                .Where(f => !Empty(f))
                .Select(f =>
                {
                    var url = FullUrl($"{GetPageName(Config.ApiUrl)}/{Config.ApiFileAction}/{fld.TableVar}/{Encrypt(fld.PhysicalUploadPath + f)}");
                    return FileMeta(ContentType(f), url, f);
                });
        }

        private static Dictionary<string, object> FileMeta(string type, string url, string name) =>
            new Dictionary<string, object> { { "type", type }, { "url", url }, { "name", name } };

        private object BuildScalarCell(DbField fld, object value)
        {
            var s = ConvertToString(value);
            if (fld.DataType == DataType.Date && value is DateTime dt)
                s = dt.ToString("s");
            return ConvertToString(s);
        }

// Get record key value from array
protected string GetRecordKeyValue(Dictionary<string, object> dict) {
            string key = "";
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdUser") ? dict["IdUser"] : IdUser.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdUser.Visible = false;
        }

        #pragma warning disable 219
/// <summary>
/// Lookup data from table
/// </summary>
        public async Task<Dictionary<string, object>> Lookup(Dictionary<string, string>? dict = null)
{
    Language = ResolveLanguage();
    Security = ResolveSecurity();
    var lookupField = FieldByName(GetFieldName(dict));
    var lookup = lookupField?.Lookup;
    if (lookup == null)
        return new Dictionary<string, object>();
            string lookupType = GetLookupType(dict);
    var (searchValue, pageSize) = GetSearchAndPageSize(dict, lookupType);
    int offset = CalculateOffset(dict, pageSize);
    ApplyUserSettings(dict, lookup);
    ApplyFilterValues(dict, lookup);
    lookup.LookupType = lookupType;
    lookup.SearchValue = searchValue;
    lookup.PageSize = pageSize;
    lookup.Offset = offset;
    return await lookup.ToJson(this);
}

private string GetFieldName(Dictionary<string, string>? dict)
{
    return GetValue(dict, "field", Post("field"));
}

private string GetLookupType(Dictionary<string, string>? dict)
{
    return GetValue(dict, "ajax", Post("ajax") ?? "unknown");
}

private (string searchValue, int pageSize) GetSearchAndPageSize(Dictionary<string, string>? dict, string lookupType)
{
    string searchValue = "";
    int pageSize = -1;
    if (SameText(lookupType, "modal") || SameText(lookupType, "filter"))
    {
        searchValue = GetValue(dict, new[] { "q", "sv" }, Param("q") ?? Post("sv"));
        int fallback = 10;
        if (IsNumeric(Param("n")))
        {
            fallback = Param<int>("n");
        }
        else if (Post("recperpage", out StringValues rpp))
        {
            fallback = ConvertToInt(rpp.ToString());
        }
        pageSize = GetInt(dict, new[] { "n", "recperpage" }, fallback);
    }
    else if (SameText(lookupType, "autosuggest"))
    {
        searchValue = GetValue(dict, "q", Param("q"));
        pageSize = GetInt(dict, "n", IsNumeric(Param("n")) ? Param<int>("n") : -1);
        if (pageSize <= 0)
            pageSize = Config.AutoSuggestMaxEntries;
    }
    return (searchValue, pageSize);
}

private int CalculateOffset(Dictionary<string, string>? dict, int pageSize)
{
    int start = GetInt(dict, "start", IsNumeric(Param("start")) ? Param<int>("start") : -1);
    int page = GetInt(dict, "page", IsNumeric(Param("page")) ? Param<int>("page") : -1);
    if (start >= 0)
        return start;
    return (page > 0 && pageSize > 0)
        ? (page - 1) * pageSize
        : 0;
}

private void ApplyUserSettings(Dictionary<string, string>? dict, dynamic lookup)
{
    string userSelect = Decrypt(GetValue(dict, "s", Post("s")));
    string userFilter = Decrypt(GetValue(dict, "f", Post("f")));
    string userOrderBy = Decrypt(GetValue(dict, "o", Post("o")));
    if (!string.IsNullOrEmpty(userSelect)) lookup.UserSelect = userSelect;
    if (!string.IsNullOrEmpty(userFilter)) lookup.UserFilter = userFilter;
    if (!string.IsNullOrEmpty(userOrderBy)) lookup.UserOrderBy = userOrderBy;
}

private void ApplyFilterValues(Dictionary<string, string>? dict, dynamic lookup)
{
    lookup.FilterValues.Clear();
    StringValues keys = GetKeys(dict);
    if (!Empty(keys))
    {
        lookup.FilterFields = new List<string>(); // Skip parent fields if any
        lookup.FilterValues.Add(string.Join(",", keys.ToArray()));
    }
    else
    {
        string lookupValue = GetValue(dict, new[] { "v0", "lookupValue" }, Post<string>("v0") ?? Post("lookupValue"));
        lookup.FilterValues.Add(lookupValue);
        int cnt = lookup.FilterFields?.Count ?? 0;
        for (int i = 1; i <= cnt; i++)
        {
            var val = UrlDecode(GetValue(dict, $"v{i}", Post($"v{i}")));
            if (val != null)
                lookup.FilterValues.Add(val);
        }
    }
}

private string GetValue(Dictionary<string, string>? dict, string key, string? fallback = null)
{
    return IsDictionary(dict) && dict.TryGetValue(key, out var v) && v != null ? v : fallback ?? "";
}

private string GetValue(Dictionary<string, string>? dict, string[] keys, string? fallback = null)
{
    foreach (var key in keys)
    {
        if (IsDictionary(dict) && dict.TryGetValue(key, out var v) && v != null)
            return v;
    }
    return fallback ?? "";
}

private int GetInt(Dictionary<string, string>? dict, string key, int fallback)
{
    return IsDictionary(dict) && dict.TryGetValue(key, out var v) ? ConvertToInt(v) : fallback;
}

private int GetInt(Dictionary<string, string>? dict, string[] keys, int fallback)
{
    foreach (var key in keys)
    {
        if (IsDictionary(dict) && dict.TryGetValue(key, out var v))
            return ConvertToInt(v);
    }
    return fallback;
}

private StringValues GetKeys(Dictionary<string, string>? dict)
{
    if (IsDictionary(dict) && dict.TryGetValue("keys", out var v) && !Empty(v))
        return (StringValues)v;
    return Post("keys[]", out StringValues k) ? k : StringValues.Empty;
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
            var beginResult = await PageRunBeginAsync();
            if (beginResult != null) return beginResult;

            // === VARIABLES YANG DIAKSES MULTI-SECTION - TETAP DI RUN() ===
            bool postBack = false;
            StringValues sv;

            // === HELPER METHOD CALLS ===
            PrepareInitialSettings();
            var actionSetup = SetupCurrentAction();
            postBack = actionSetup.PostBack;
            sv = actionSetup.StringValues;
            CurrentAction = actionSetup.CurrentAction;
            var rsold = await LoadOldRecord();
            SetupMasterParameters();
            if (postBack) {
                await LoadFormValues();
                await SetupCaptchaAndDetails();
                if (!await ValidateForm()) {
                    EventCancelled = true;
                    RestoreFormValues();
                    if (IsApi())
                        return Terminate();
                    else
                        CurrentAction = "show";
                }
            }
            var actionResult = await ExecuteCurrentAction(rsold);
            if (actionResult != null) return actionResult;
            await PrepareForRender();
            PageRunEnd();
            return PageResult();
        }

        // === HELPER METHODS ===
        private void PrepareInitialSettings()
        {
            if (IsModal) SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;
        }

        private ActionSetupResult SetupCurrentAction()
        {
            var result = new ActionSetupResult();
            if (IsApi()) {
                result.CurrentAction = "insert";
                result.PostBack = true;
            } else if (!Empty(Post("action"))) {
                result.CurrentAction = Post("action");
                if (Post(OldKeyName, out StringValues sv)) {
                    SetKey(sv.ToString());
                    result.StringValues = sv;
                }
                result.PostBack = true;
            } else {
                result.CurrentAction = HandleNonPostBackAction();
            }
            return result;
        }

        private string HandleNonPostBackAction()
        {
            string[] keyValues = {};
            object? rv;
            StringValues sv;
            if (RouteValues.TryGetValue("key", out object? k))
                keyValues = ConvertToString(k).Split('/');
            if (RouteValues.TryGetValue("IdUser", out rv)) {
                IdUser.QueryValue = UrlDecode(rv);
            } else if (Get("IdUser", out sv)) {
                IdUser.QueryValue = sv.ToString();
            }
            OldKey = GetKey(true);
            CopyRecord = !Empty(OldKey);
            if (CopyRecord) {
                SetKey(OldKey);
                return "copy";
            } else {
                return "show";
            }
        }

        private void SetupMasterParameters()
        {
        }

        private async Task SetupCaptchaAndDetails()
        {
        }

        private async Task<IActionResult?> ExecuteCurrentAction(Dictionary<string, object>? rsold)
        {
            switch (CurrentAction) {
                case "copy":
                    return HandleCopyAction(rsold);
                case "insert":
                    return await HandleInsertAction(rsold);
            }
            return null;
        }

        private IActionResult? HandleCopyAction(Dictionary<string, object>? rsold)
        {
            if (rsold == null) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("NoRecord");
                return Terminate("MasterUserList");
            }
            return null;
        }

        private async Task<IActionResult?> HandleInsertAction(Dictionary<string, object>? rsold)
        {
            SendEmail = true;
            var res = await AddRow(rsold);
            if (res) {
                return await HandleSuccessfulInsert(res);
            } else if (IsApi()) {
                return Terminate();
            } else {
                EventCancelled = true;
                RestoreFormValues();
                return null;
            }
        }

        private async Task<IActionResult> HandleSuccessfulInsert(JsonBoolResult res)
        {
            if (Empty(SuccessMessage) && Post("addopt") != "1")
                SuccessMessage = Language.Phrase("AddSuccess");
            string returnUrl = DetermineReturnUrl();
            HandleAjaxActions(ref returnUrl);
            if (IsJsonResponse()) {
                ClearMessages();
                return res;
            } else {
                return Terminate(returnUrl);
            }
        }

        private string DetermineReturnUrl()
        {
            string returnUrl = "";
            returnUrl = ReturnUrl;
            if (GetPageName(returnUrl) == "MasterUserList")
                returnUrl = AddMasterUrl(ListUrl);
            else if (GetPageName(returnUrl) == "MasterUserView")
                returnUrl = ViewUrl;
            return returnUrl;
        }

        private void HandleAjaxActions(ref string returnUrl)
        {
            if (IsModal && UseAjaxActions) {
                IsModal = false;
                if (GetPageName(returnUrl) != "MasterUserList") {
                    TempData["Return-Url"] = returnUrl;
                    returnUrl = "MasterUserList";
                }
            }
        }

        private async Task PrepareForRender()
        {
            SetupBreadcrumb();
            RowType = RowType.Add;
            ResetAttributes();
            await RenderRow();
        }

        private async Task<IActionResult?> PageRunBeginAsync()
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
                    PageLoadingEventHandler?.Invoke(null, EventArgs.Empty);

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
                    if (!UseAjaxActions) {
                        HideFieldsForAddEdit();
                    }
                    else { // Use inline delete
                        InlineDelete = true;
                    }

                    // Set up lookup cache
                    await SetupLookupOptions(_UserLevel);
                    await SetupLookupOptions(Rule);
                    await SetupLookupOptions(IdPosition);
                    await SetupLookupOptions(Region);
                    await SetupLookupOptions(Plant);
                    await SetupLookupOptions(LookupPosition);
                    await SetupLookupOptions(StatusAktif);
                    await SetupLookupOptions(IsResetable);
                    await SetupLookupOptions(IsVerify);
                    await SetupLookupOptions(exception);

                    // Load default values for add
                    LoadDefaultValues();
            return null;
        }

        private void PageRunEnd()
        {
                    // Set LoginStatus, Page Rendering and Page Render
                    if (!IsApi() && !IsTerminated) {
                        SetupLoginStatus(); // Setup login status

                        // Pass login status to client side
                        SetClientVar("login", LoginStatus);

                        // Global Page Rendering event
                        PageRendering();
                        PageRenderingEventHandler?.Invoke(null, EventArgs.Empty);

                        // Page Render event
                        masterUserAdd?.PageRender();
                    }
        }

        // Support class
        private sealed class ActionSetupResult
        {
            public string CurrentAction { get; set; } = "";

            public bool PostBack { get; set; }

            public StringValues StringValues { get; set; }
        }

        // ================== GENERATED HELPERS ==================
        private void ResolveLookupView(dynamic fld, string keyFieldName, string fallbackType = "auto")
        {
            string curVal = ConvertToString(fld.CurrentValue);

            // kosong → DbNullValue lalu selesai
            if (Empty(curVal))
            {
                fld.ViewValue = DbNullValue;
                return;
            }

            // siapkan fallback awal (kalau cache/DB tidak dapat)
            if (fallbackType == "number")
            {
                fld.ViewValue = FormatNumber(fld.CurrentValue, fld.FormatPattern);
            }
            else if (fallbackType == "date")
            {
                var tmp = fld.CurrentValue;
                fld.ViewValue = FormatDateTime(tmp, fld.FormatPattern);
            }
            else if (fallbackType == "string")
            {
                fld.ViewValue = ConvertToString(fld.CurrentValue);
            }
            else
            { // auto
                fld.ViewValue = IsNumeric(fld.CurrentValue)
                    ? FormatNumber(fld.CurrentValue, fld.FormatPattern)
                    : ConvertToString(fld.CurrentValue);
            }

            // coba dari cache
            if (fld.Lookup != null && IsDictionary(fld.Lookup?.Options) && fld.Lookup?.Options.Values.Count > 0)
            {
                fld.ViewValue = fld.LookupCacheOption(curVal);
                return;
            }

            // fallback: query DB
            var keyField = fld.Lookup?.GetTable()?.Fields[keyFieldName];
            string filterWrk = SearchFilter(keyField?.SearchExpression, "=", fld.CurrentValue, keyField?.SearchDataType, "");
            string? sqlWrk = fld.Lookup?.GetSql(false, filterWrk, null, this, true, true);
            List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null;
            if (rswrk?.Count > 0 && fld.Lookup != null)
            {
                var listwrk = fld.Lookup?.RenderViewRow(rswrk[0]);
                fld.ViewValue = fld.DisplayValue(listwrk);
            }
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
            // If empty means, all condition is not fulfilled
            StatusAktif.DefaultValue = StatusAktif.GetDefault(); // DN
            StatusAktif.OldValue = StatusAktif.DefaultValue;
        }

        #pragma warning disable 1998
        // Helper methods (placed inside the same partial class as LoadFormValues)
        private void SetNormalField(dynamic fld, string fldName, string fldVar, bool includeValidate = false, bool validateFlag = false, bool unformatDate = false) {
            // Determine value once
            string val = CurrentForm.HasValue(fldName) ? CurrentForm.GetValue(fldName) : CurrentForm.GetValue(fldVar);
            if (!fld.IsDetailKey) {
                // API: if field not present in request, disable update
                if (IsApi() && !CurrentForm.HasValue(fldName) && !CurrentForm.HasValue(fldVar))
                    fld.Visible = false; // Disable update for API request
                else {
                    // Call appropriate SetFormValue overload
                    if (includeValidate)
                        fld.SetFormValue(val, true, validateFlag);
                    else
                        fld.SetFormValue(val);
                }
                if (unformatDate)
                    fld.CurrentValue = UnformatDateTime(fld.CurrentValue, fld.FormatPattern);
            }
        }

        private void SetFieldValueWithRaw(dynamic fld, string rawValue) {
            // Helper in case caller wants to set from a raw form object call rather than val computed here
            if (!fld.IsDetailKey) {
                if (IsApi() && string.IsNullOrEmpty(rawValue)) // rawValue empty simulates missing
                    fld.Visible = false;
                else
                    fld.SetFormValue(rawValue);
            }
        }

        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;

            // Standard handling for '_Email'
            _Email.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(_Email, "Email", "x__Email", true, validate, false);

            // Standard handling for '_Username'
            _Username.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(_Username, "Username", "x__Username");

            // Standard handling for 'PasswordHash'
            PasswordHash.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PasswordHash, "PasswordHash", "x_PasswordHash");

            // Standard handling for 'NamaLengkap'
            NamaLengkap.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NamaLengkap, "NamaLengkap", "x_NamaLengkap");

            // Standard handling for '_UserLevel'
            _UserLevel.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(_UserLevel, "UserLevel", "x__UserLevel");

            // Standard handling for 'Rule'
            Rule.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Rule, "Rule", "x_Rule");

            // Standard handling for 'IdPosition'
            IdPosition.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdPosition, "IdPosition", "x_IdPosition", true, validate, false);

            // Standard handling for 'Region'
            Region.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Region, "Region", "x_Region");

            // Standard handling for 'Plant'
            Plant.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Plant, "Plant", "x_Plant");

            // Standard handling for 'LookupPosition'
            LookupPosition.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(LookupPosition, "LookupPosition", "x_LookupPosition");

            // Standard handling for 'StatusAktif'
            StatusAktif.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(StatusAktif, "StatusAktif", "x_StatusAktif");

            // Standard handling for 'Keterangan'
            Keterangan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Keterangan, "Keterangan", "x_Keterangan");

            // Standard handling for 'IdIdaman'
            IdIdaman.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdIdaman, "IdIdaman", "x_IdIdaman");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            _Email.CurrentValue = _Email.FormValue;
            _Username.CurrentValue = _Username.FormValue;
            PasswordHash.CurrentValue = PasswordHash.FormValue;
            NamaLengkap.CurrentValue = NamaLengkap.FormValue;
            _UserLevel.CurrentValue = _UserLevel.FormValue;
            Rule.CurrentValue = Rule.FormValue;
            IdPosition.CurrentValue = IdPosition.FormValue;
            Region.CurrentValue = Region.FormValue;
            Plant.CurrentValue = Plant.FormValue;
            LookupPosition.CurrentValue = LookupPosition.FormValue;
            StatusAktif.CurrentValue = StatusAktif.FormValue;
            Keterangan.CurrentValue = Keterangan.FormValue;
            IdIdaman.CurrentValue = IdIdaman.FormValue;
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
            _Email.SetDbValue(row["Email"]);
            _Username.SetDbValue(row["Username"]);
            PasswordHash.SetDbValue(row["PasswordHash"]);
            NamaLengkap.SetDbValue(row["NamaLengkap"]);
            _UserLevel.SetDbValue(row["UserLevel"]);
            Rule.SetDbValue(row["Rule"]);
            IdPosition.SetDbValue(row["IdPosition"]);
            Region.SetDbValue(row["Region"]);
            Plant.SetDbValue(row["Plant"]);
            LookupPosition.SetDbValue(row["LookupPosition"]);
            StatusAktif.SetDbValue((ConvertToBool(row["StatusAktif"]) ? "1" : "0"));
            Keterangan.SetDbValue(row["Keterangan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            IsResetable.SetDbValue((ConvertToBool(row["IsResetable"]) ? "1" : "0"));
            IsVerify.SetDbValue((ConvertToBool(row["IsVerify"]) ? "1" : "0"));
            Face.SetDbValue(row["Face"]);
            AzurePersonId.SetDbValue(row["AzurePersonId"]);
            TanggalInputFace.SetDbValue(row["TanggalInputFace"]);
            UserInputFace.SetDbValue(row["UserInputFace"]);
            IdIdaman.SetDbValue(row["IdIdaman"]);
            exception.SetDbValue((ConvertToBool(row["exception "]) ? "1" : "0"));
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdUser", IdUser.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("Username", _Username.DefaultValue ?? DbNullValue); // DN
            row.Add("PasswordHash", PasswordHash.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaLengkap", NamaLengkap.DefaultValue ?? DbNullValue); // DN
            row.Add("UserLevel", _UserLevel.DefaultValue ?? DbNullValue); // DN
            row.Add("Rule", Rule.DefaultValue ?? DbNullValue); // DN
            row.Add("IdPosition", IdPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("Region", Region.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPosition", LookupPosition.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusAktif", StatusAktif.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("DibuatOleh", DibuatOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDibuat", TanggalDibuat.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("IsResetable", IsResetable.DefaultValue ?? DbNullValue); // DN
            row.Add("IsVerify", IsVerify.DefaultValue ?? DbNullValue); // DN
            row.Add("Face", Face.DefaultValue ?? DbNullValue); // DN
            row.Add("AzurePersonId", AzurePersonId.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalInputFace", TanggalInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("UserInputFace", UserInputFace.DefaultValue ?? DbNullValue); // DN
            row.Add("IdIdaman", IdIdaman.DefaultValue ?? DbNullValue); // DN
            row.Add("exception ", exception.DefaultValue ?? DbNullValue); // DN
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

            // IdUser
            IdUser.RowCssClass = "row";

            // Email
            _Email.RowCssClass = "row";

            // Username
            _Username.RowCssClass = "row";

            // PasswordHash
            PasswordHash.RowCssClass = "row";

            // NamaLengkap
            NamaLengkap.RowCssClass = "row";

            // UserLevel
            _UserLevel.RowCssClass = "row";

            // Rule
            Rule.RowCssClass = "row";

            // IdPosition
            IdPosition.RowCssClass = "row";

            // Region
            Region.RowCssClass = "row";

            // Plant
            Plant.RowCssClass = "row";

            // LookupPosition
            LookupPosition.RowCssClass = "row";

            // StatusAktif
            StatusAktif.RowCssClass = "row";

            // Keterangan
            Keterangan.RowCssClass = "row";

            // DibuatOleh
            DibuatOleh.RowCssClass = "row";

            // TanggalDibuat
            TanggalDibuat.RowCssClass = "row";

            // DiperbaruiOleh
            DiperbaruiOleh.RowCssClass = "row";

            // TanggalDiperbarui
            TanggalDiperbarui.RowCssClass = "row";

            // IsResetable
            IsResetable.RowCssClass = "row";

            // IsVerify
            IsVerify.RowCssClass = "row";

            // Face
            Face.RowCssClass = "row";

            // AzurePersonId
            AzurePersonId.RowCssClass = "row";

            // TanggalInputFace
            TanggalInputFace.RowCssClass = "row";

            // UserInputFace
            UserInputFace.RowCssClass = "row";

            // IdIdaman
            IdIdaman.RowCssClass = "row";

            // exception 
            exception.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // Email

                // Username

                // PasswordHash

                // NamaLengkap

                // UserLevel

                // Rule

                // IdPosition

                // Region

                // Plant

                // LookupPosition

                // StatusAktif

                // Keterangan

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

                // IsResetable

                // IsVerify

                // Face

                // AzurePersonId

                // TanggalInputFace

                // UserInputFace

                // IdIdaman

                // exception 

                    // IdUser
                    IdUser.ViewValue = IdUser.CurrentValue;
                    IdUser.ViewCustomAttributes = "";

                    // Email
                    _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                    _Email.ViewCustomAttributes = "";

                    // Username
                    _Username.ViewValue = ConvertToString(_Username.CurrentValue); // DN
                    _Username.ViewCustomAttributes = "";

                    // PasswordHash
                    PasswordHash.ViewValue = Language.Phrase("PasswordMask");
                    PasswordHash.ViewCustomAttributes = "";

                    // NamaLengkap
                    NamaLengkap.ViewValue = ConvertToString(NamaLengkap.CurrentValue); // DN
                    NamaLengkap.ViewCustomAttributes = "";

                    // UserLevel
                    if (Security.CanAdmin) {
                        // awallookupbung
                    // _UserLevel
                    ResolveLookupView(_UserLevel, "UserLevelID", "number");
                    // akhirlookupbung
                    } else {
                        _UserLevel.ViewValue = Language.Phrase("PasswordMask");
                    }
                    _UserLevel.ViewCustomAttributes = "";

                    // Rule

                    // awallookupbung
                    // Rule (jaga leading zero)
                    ResolveLookupView(Rule, "IdPIC", "string");
                    // akhirlookupbung
                    Rule.ViewCustomAttributes = "";

                    // IdPosition
                    IdPosition.ViewValue = IdPosition.CurrentValue;

                    // awallookupbung
                    // IdPosition
                    ResolveLookupView(IdPosition, "IdPosition", "number");
                    // akhirlookupbung
                    IdPosition.ViewCustomAttributes = "";

                    // Region

                    // awallookupbung
                    // Region (jaga leading zero)
                    ResolveLookupView(Region, "IdRegion", "string");
                    // akhirlookupbung
                    Region.ViewCustomAttributes = "";

                    // Plant

                    // awallookupbung
                    // Plant
                    ResolveLookupView(Plant, "IdPlant", "number");
                    // akhirlookupbung
                    Plant.ViewCustomAttributes = "";

                    // LookupPosition
                    if (!Empty(LookupPosition.CurrentValue)) {
                        LookupPosition.ViewValue = LookupPosition.OptionCaption(ConvertToString(LookupPosition.CurrentValue));
                    } else {
                        LookupPosition.ViewValue = DbNullValue;
                    }
                    LookupPosition.ViewCustomAttributes = "";

                    // StatusAktif
                    if (ConvertToBool(StatusAktif.CurrentValue)) {
                        StatusAktif.ViewValue = StatusAktif.TagCaption(1) != "" ? StatusAktif.TagCaption(1) : "Yes";
                    } else {
                        StatusAktif.ViewValue = StatusAktif.TagCaption(2) != "" ? StatusAktif.TagCaption(2) : "No";
                    }
                    StatusAktif.ViewCustomAttributes = "";

                    // Keterangan
                    Keterangan.ViewValue = Keterangan.CurrentValue;
                    Keterangan.ViewCustomAttributes = "";

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

                    // IsResetable
                    if (ConvertToBool(IsResetable.CurrentValue)) {
                        IsResetable.ViewValue = IsResetable.TagCaption(1) != "" ? IsResetable.TagCaption(1) : "Yes";
                    } else {
                        IsResetable.ViewValue = IsResetable.TagCaption(2) != "" ? IsResetable.TagCaption(2) : "No";
                    }
                    IsResetable.ViewCustomAttributes = "";

                    // IsVerify
                    if (ConvertToBool(IsVerify.CurrentValue)) {
                        IsVerify.ViewValue = IsVerify.TagCaption(1) != "" ? IsVerify.TagCaption(1) : "Yes";
                    } else {
                        IsVerify.ViewValue = IsVerify.TagCaption(2) != "" ? IsVerify.TagCaption(2) : "No";
                    }
                    IsVerify.ViewCustomAttributes = "";

                    // Face
                    Face.ViewValue = ConvertToString(Face.CurrentValue); // DN
                    Face.ViewCustomAttributes = "";

                    // AzurePersonId
                    AzurePersonId.ViewValue = ConvertToString(AzurePersonId.CurrentValue); // DN
                    AzurePersonId.ViewCustomAttributes = "";

                    // TanggalInputFace
                    TanggalInputFace.ViewValue = TanggalInputFace.CurrentValue;
                    TanggalInputFace.ViewValue = FormatDateTime(TanggalInputFace.ViewValue, TanggalInputFace.FormatPattern);
                    TanggalInputFace.ViewCustomAttributes = "";

                    // UserInputFace
                    UserInputFace.ViewValue = ConvertToString(UserInputFace.CurrentValue); // DN
                    UserInputFace.ViewCustomAttributes = "";

                    // IdIdaman
                    IdIdaman.ViewValue = ConvertToString(IdIdaman.CurrentValue); // DN
                    IdIdaman.ViewCustomAttributes = "";

                    // exception 
                    if (ConvertToBool(exception.CurrentValue)) {
                        exception.ViewValue = exception.TagCaption(1) != "" ? exception.TagCaption(1) : "Yes";
                    } else {
                        exception.ViewValue = exception.TagCaption(2) != "" ? exception.TagCaption(2) : "No";
                    }
                    exception.ViewCustomAttributes = "";

                // Email
                _Email.HrefValue = "";

                // Username
                _Username.HrefValue = "";

                // PasswordHash
                PasswordHash.HrefValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";

                // UserLevel
                _UserLevel.HrefValue = "";

                // Rule
                Rule.HrefValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // LookupPosition
                LookupPosition.HrefValue = "";

                // StatusAktif
                StatusAktif.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // IdIdaman
                IdIdaman.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // Email
                _Email.SetupEditAttributes();
                if (!_Email.Raw)
                    _Email.CurrentValue = HtmlDecode(_Email.CurrentValue);
                _Email.EditValue = HtmlEncode(_Email.CurrentValue);
                _Email.PlaceHolder = RemoveHtml(_Email.Caption);

                // Username
                _Username.SetupEditAttributes();
                if (!_Username.Raw)
                    _Username.CurrentValue = HtmlDecode(_Username.CurrentValue);
                _Username.EditValue = HtmlEncode(_Username.CurrentValue);
                _Username.PlaceHolder = RemoveHtml(_Username.Caption);

                // PasswordHash
                PasswordHash.SetupEditAttributes();
                PasswordHash.PlaceHolder = RemoveHtml(PasswordHash.Caption);

                // NamaLengkap
                NamaLengkap.SetupEditAttributes();
                if (!NamaLengkap.Raw)
                    NamaLengkap.CurrentValue = HtmlDecode(NamaLengkap.CurrentValue);
                NamaLengkap.EditValue = HtmlEncode(NamaLengkap.CurrentValue);
                NamaLengkap.PlaceHolder = RemoveHtml(NamaLengkap.Caption);

                // UserLevel
                _UserLevel.SetupEditAttributes();
                if (!Security.CanAdmin) { // System admin
                    _UserLevel.EditValue = Language.Phrase("PasswordMask");
                } else {
                    string curVal = ConvertToString(_UserLevel.CurrentValue);
                    if (_UserLevel.Lookup != null && IsDictionary(_UserLevel.Lookup?.Options) && _UserLevel.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        _UserLevel.EditValue = _UserLevel.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        string filterWrk = "";
                        if (curVal == "") {
                            filterWrk = "0=1";
                        } else {
                            filterWrk = SearchFilter(_UserLevel.Lookup?.GetTable()?.Fields["UserLevelID"].SearchExpression, "=", _UserLevel.CurrentValue, _UserLevel.Lookup?.GetTable()?.Fields["UserLevelID"].SearchDataType, "");
                        }
                        string? sqlWrk = _UserLevel.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        _UserLevel.EditValue = rswrk;
                    }
                    _UserLevel.PlaceHolder = RemoveHtml(_UserLevel.Caption);
                    if (!Empty(_UserLevel.EditValue) && IsNumeric(_UserLevel.EditValue))
                        _UserLevel.EditValue = FormatNumber(_UserLevel.EditValue, null);
                }

                // Rule
                Rule.SetupEditAttributes();
                string curVal2 = ConvertToString(Rule.CurrentValue);
                if (Rule.Lookup != null && IsDictionary(Rule.Lookup?.Options) && Rule.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Rule.EditValue = Rule.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk2 = "";
                    if (curVal2 == "") {
                        filterWrk2 = "0=1";
                    } else {
                        filterWrk2 = SearchFilter(Rule.Lookup?.GetTable()?.Fields["IdPIC"].SearchExpression, "=", Rule.CurrentValue, Rule.Lookup?.GetTable()?.Fields["IdPIC"].SearchDataType, "");
                    }
                    string? sqlWrk2 = Rule.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Rule.EditValue = rswrk2;
                }
                Rule.PlaceHolder = RemoveHtml(Rule.Caption);

                // IdPosition
                IdPosition.SetupEditAttributes();
                IdPosition.EditValue = IdPosition.CurrentValue;

                // awallookupbung
                string curVal3 = ConvertToString(IdPosition.CurrentValue);
                IdPosition.EditValue = Empty(curVal3) ? DbNullValue : HtmlEncode(FormatNumber(IdPosition.CurrentValue, IdPosition.FormatPattern));
                if (!Empty(curVal3)) {
                    if (IdPosition.Lookup != null && IsDictionary(IdPosition.Lookup?.Options) && IdPosition.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdPosition.EditValue = IdPosition.LookupCacheOption(curVal3);
                    } else { // Lookup from database // DN
                        string filterWrk3 = SearchFilter(IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", IdPosition.CurrentValue, IdPosition.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                        string? sqlWrk3 = IdPosition.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk3?.Count > 0 && IdPosition.Lookup != null) { // Lookup values found
                            var listwrk = IdPosition.Lookup?.RenderViewRow(rswrk3[0]);
                            IdPosition.EditValue = IdPosition.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                IdPosition.PlaceHolder = RemoveHtml(IdPosition.Caption);
                if (!Empty(IdPosition.EditValue) && IsNumeric(IdPosition.EditValue))
                    IdPosition.EditValue = FormatNumber(IdPosition.EditValue, null);

                // Region
                Region.SetupEditAttributes();
                string curVal4 = ConvertToString(Region.CurrentValue);
                if (Region.Lookup != null && IsDictionary(Region.Lookup?.Options) && Region.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Region.EditValue = Region.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk4 = "";
                    if (curVal4 == "") {
                        filterWrk4 = "0=1";
                    } else {
                        filterWrk4 = SearchFilter(Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchExpression, "=", Region.CurrentValue, Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchDataType, "");
                    }
                    string? sqlWrk4 = Region.Lookup?.GetSql(true, filterWrk4, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Region.EditValue = rswrk4;
                }
                Region.PlaceHolder = RemoveHtml(Region.Caption);

                // Plant
                Plant.SetupEditAttributes();
                string curVal5 = ConvertToString(Plant.CurrentValue);
                if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Plant.EditValue = Plant.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    string filterWrk5 = "";
                    if (curVal5 == "") {
                        filterWrk5 = "0=1";
                    } else {
                        filterWrk5 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    }
                    string? sqlWrk5 = Plant.Lookup?.GetSql(true, filterWrk5, null, this, false, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Plant.EditValue = rswrk5;
                }
                Plant.PlaceHolder = RemoveHtml(Plant.Caption);
                if (!Empty(Plant.EditValue) && IsNumeric(Plant.EditValue))
                    Plant.EditValue = FormatNumber(Plant.EditValue, null);

                // LookupPosition
                LookupPosition.SetupEditAttributes();
                LookupPosition.EditValue = LookupPosition.Options(true);
                LookupPosition.PlaceHolder = RemoveHtml(LookupPosition.Caption);

                // StatusAktif
                StatusAktif.EditValue = StatusAktif.Options(false);
                StatusAktif.PlaceHolder = RemoveHtml(StatusAktif.Caption);

                // Keterangan
                Keterangan.SetupEditAttributes();
                Keterangan.EditValue = Keterangan.CurrentValue; // DN
                Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

                // IdIdaman
                IdIdaman.SetupEditAttributes();
                if (!IdIdaman.Raw)
                    IdIdaman.CurrentValue = HtmlDecode(IdIdaman.CurrentValue);
                IdIdaman.EditValue = HtmlEncode(IdIdaman.CurrentValue);
                IdIdaman.PlaceHolder = RemoveHtml(IdIdaman.Caption);

                // Add refer script

                // Email
                _Email.HrefValue = "";

                // Username
                _Username.HrefValue = "";

                // PasswordHash
                PasswordHash.HrefValue = "";

                // NamaLengkap
                NamaLengkap.HrefValue = "";

                // UserLevel
                _UserLevel.HrefValue = "";

                // Rule
                Rule.HrefValue = "";

                // IdPosition
                IdPosition.HrefValue = "";

                // Region
                Region.HrefValue = "";

                // Plant
                Plant.HrefValue = "";

                // LookupPosition
                LookupPosition.HrefValue = "";

                // StatusAktif
                StatusAktif.HrefValue = "";

                // Keterangan
                Keterangan.HrefValue = "";

                // IdIdaman
                IdIdaman.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998

        private void ValidateCustom_Email() {
            if (_Email.Visible && _Email.Required) {
                if (!_Email.IsDetailKey && Empty(_Email.FormValue)) {
                    _Email.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustom_Username() {
            if (_Username.Visible && _Username.Required) {
                if (!_Username.IsDetailKey && Empty(_Username.FormValue)) {
                    _Username.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomPasswordHash() {
            if (PasswordHash.Visible && PasswordHash.Required) {
                if (!PasswordHash.IsDetailKey && Empty(PasswordHash.FormValue)) {
                    PasswordHash.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomNamaLengkap() {
            if (NamaLengkap.Visible && NamaLengkap.Required) {
                if (!NamaLengkap.IsDetailKey && Empty(NamaLengkap.FormValue)) {
                    NamaLengkap.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustom_UserLevel() {
            if (_UserLevel.Visible && _UserLevel.Required) {
                if (Security.CanAdmin && !_UserLevel.IsDetailKey && Empty(_UserLevel.FormValue)) {
                    _UserLevel.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomRule() {
            if (Rule.Visible && Rule.Required) {
                if (!Rule.IsDetailKey && Empty(Rule.FormValue)) {
                    Rule.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomIdPosition() {
            if (IdPosition.Visible && IdPosition.Required) {
                if (!IdPosition.IsDetailKey && Empty(IdPosition.FormValue)) {
                    IdPosition.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomRegion() {
            if (Region.Visible && Region.Required) {
                if (!Region.IsDetailKey && Empty(Region.FormValue)) {
                    Region.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomPlant() {
            if (Plant.Visible && Plant.Required) {
                if (!Plant.IsDetailKey && Empty(Plant.FormValue)) {
                    Plant.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomLookupPosition() {
            if (LookupPosition.Visible && LookupPosition.Required) {
                if (!LookupPosition.IsDetailKey && Empty(LookupPosition.FormValue)) {
                    LookupPosition.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomStatusAktif() {
            if (StatusAktif.Visible && StatusAktif.Required) {
                if (Empty(StatusAktif.FormValue)) {
                    StatusAktif.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomKeterangan() {
            if (Keterangan.Visible && Keterangan.Required) {
                if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                    Keterangan.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        private void ValidateCustomIdIdaman() {
            if (IdIdaman.Visible && IdIdaman.Required) {
                if (!IdIdaman.IsDetailKey && Empty(IdIdaman.FormValue)) {
                    IdIdaman.AddErrorMessage(ConvertToString(IdIdaman.RequiredErrorMessage).Replace("%s", IdIdaman.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustom_Email();
                if (!CheckEmail(_Email.FormValue)) {
                    _Email.AddErrorMessage(_Email.GetErrorMessage(false));
                }
                ValidateCustom_Username();
                if (!_Username.Raw && Config.RemoveXssEnabled && CheckUsername(_Username.FormValue)) {
                    _Username.AddErrorMessage(Language.Phrase("InvalidUsernameChars"));
                }
                ValidateCustomPasswordHash();
                if (!PasswordHash.Raw && Config.RemoveXssEnabled && CheckPassword(PasswordHash.FormValue)) {
                    PasswordHash.AddErrorMessage(Language.Phrase("InvalidPasswordChars"));
                }
                ValidateCustomNamaLengkap();
                ValidateCustom_UserLevel();
                ValidateCustomRule();
                ValidateCustomIdPosition();
                if (!CheckInteger(IdPosition.FormValue)) {
                    IdPosition.AddErrorMessage(IdPosition.GetErrorMessage(false));
                }
                ValidateCustomRegion();
                ValidateCustomPlant();
                ValidateCustomLookupPosition();
                ValidateCustomStatusAktif();
                ValidateCustomKeterangan();
                ValidateCustomIdIdaman();

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
            if (!Empty(_Username.CurrentValue)) { // Check field with unique index
                var filter = "(Username = '" + AdjustSql(_Username.CurrentValue, DbId) + "')";
                if (await GetQueryBuilder().WhereRaw(filter).ExistsAsync()) { // DN
                    FailureMessage = Language.Phrase("DupIndex").Replace("%f", _Username.Caption).Replace("%v", ConvertToString(_Username.CurrentValue));
                    return JsonBoolResult.FalseResult;
                }
            }

            // Load db values from rsold
            LoadDbValues(rsold);

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["IdUser"] = IdUser.CurrentValue!;
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

                // Email
                _Email.SetDbValue(rsnew, _Email.CurrentValue);

                // Username
                _Username.SetDbValue(rsnew, _Username.CurrentValue);

                // PasswordHash
                if (Config.EncryptedPassword && !IsMaskedPassword(PasswordHash.CurrentValue)) {
                    PasswordHash.CurrentValue = EncryptPassword(Config.CaseSensitivePassword ? ConvertToString(PasswordHash.CurrentValue) : ConvertToString(PasswordHash.CurrentValue).ToLowerInvariant());
                }
                PasswordHash.SetDbValue(rsnew, PasswordHash.CurrentValue);

                // NamaLengkap
                NamaLengkap.SetDbValue(rsnew, NamaLengkap.CurrentValue);

                // UserLevel
                if (Security.CanAdmin) { // System admin
                _UserLevel.SetDbValue(rsnew, _UserLevel.CurrentValue);
                }

                // Rule
                Rule.SetDbValue(rsnew, Rule.CurrentValue);

                // IdPosition
                IdPosition.SetDbValue(rsnew, IdPosition.CurrentValue);

                // Region
                Region.SetDbValue(rsnew, Region.CurrentValue);

                // Plant
                Plant.SetDbValue(rsnew, Plant.CurrentValue);

                // LookupPosition
                LookupPosition.SetDbValue(rsnew, LookupPosition.CurrentValue);

                // StatusAktif
                StatusAktif.SetDbValue(rsnew, ConvertToBool(StatusAktif.CurrentValue), Empty(StatusAktif.CurrentValue));

                // Keterangan
                Keterangan.SetDbValue(rsnew, Keterangan.CurrentValue);

                // IdIdaman
                IdIdaman.SetDbValue(rsnew, IdIdaman.CurrentValue);
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
            if (row.TryGetValue("Email", out value)) // Email
                _Email.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Username", out value)) // Username
                _Username.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("PasswordHash", out value)) // PasswordHash
                PasswordHash.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NamaLengkap", out value)) // NamaLengkap
                NamaLengkap.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("UserLevel", out value)) // UserLevel
                _UserLevel.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Rule", out value)) // Rule
                Rule.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdPosition", out value)) // IdPosition
                IdPosition.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Region", out value)) // Region
                Region.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Plant", out value)) // Plant
                Plant.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("LookupPosition", out value)) // LookupPosition
                LookupPosition.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("StatusAktif", out value)) // StatusAktif
                StatusAktif.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("Keterangan", out value)) // Keterangan
                Keterangan.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdIdaman", out value)) // IdIdaman
                IdIdaman.SetFormValue(ConvertToString(value));
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MasterUserList")), "", TableVar, true);
            string pageId = IsCopy ? "Copy" : "Add";
            breadcrumb.Add("add", pageId, url);
            CurrentBreadcrumb = breadcrumb;
        }

        // Setup lookup options
        public async Task SetupLookupOptions(DbField fld)
        {
            if (fld.Lookup == null)
                return;
            if (fld.Lookup.Options.Count is int opt && opt > 0) 
                return;
            Func<string>? lookupFilter = null;
            dynamic conn = Connection;

                // Set up lookup SQL

                // Always call to Lookup.GetSql so that user can setup Lookup.Options in Lookup Selecting server event
                var sql = fld.Lookup.GetSql(false, "", lookupFilter, this);

                // Set up lookup cache
                if (fld.HasLookupOptions ||
                    !fld.UseLookupCache ||
                    Empty(sql) ||
                    fld.Lookup.ParentFields.Count != 0 ||
                    fld.Lookup.Options.Count != 0)
                            return;
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
