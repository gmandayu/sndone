using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public AktivitasEditBase(Controller? controller)
        {
            TableName = "Aktivitas";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

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
        public AktivitasEditBase() : this(null) { }

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
                        result.Add("view", pageName == "AktivitasView" ? "1" : "0"); // If View page, no primary button
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
            var beginResult = await PageRunBeginAsync();
            if (beginResult != null) return beginResult;

            // === VARIABLES YANG DIAKSES MULTI-SECTION ===
            bool loaded = false;
            bool postBack = false;

            // === HELPER METHOD CALLS ===
            PrepareInitialSettings();
            var actionSetup = await SetupCurrentAction();
            loaded = actionSetup.Loaded;
            postBack = actionSetup.PostBack;
            if (postBack) {
                await LoadFormValues();
                await HandleApiFormKeys();
                SetupDetailParms();
            }
            await SetupCaptchaAndDetails(postBack);
            if (postBack && !await ValidateForm()) {
                EventCancelled = true;
                RestoreFormValues();
                if (IsApi())
                    return Terminate();
                else
                    CurrentAction = "";
            }
            var actionResult = await ExecuteCurrentAction(loaded);
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

        private async Task<ActionSetupResult> SetupCurrentAction()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            var result = new ActionSetupResult();
            bool loaded = false;
            bool postBack = false;
            StringValues sv;
            object? rv;
            if (IsApi()) {
                loaded = true;
                string[] keyValues = {};
                if (RouteValues.TryGetValue("key", out object? k))
                    keyValues = ConvertToString(k).Split('/');
                if (RouteValues.TryGetValue("IdAktivitas", out rv)) {
                    IdAktivitas.FormValue = UrlDecode(rv);
                    IdAktivitas.OldValue = IdAktivitas.FormValue;
                } else if (CurrentForm.HasValue("x_IdAktivitas")) {
                    IdAktivitas.FormValue = CurrentForm.GetValue("x_IdAktivitas");
                    IdAktivitas.OldValue = IdAktivitas.FormValue;
                } else if (!Empty(keyValues)) {
                    IdAktivitas.OldValue = ConvertToString(keyValues[0]);
                } else {
                    loaded = false;
                }
                if (loaded)
                    loaded = await LoadRow();
                if (!loaded) {
                    FailureMessage = Language.Phrase("NoRecord");
                    return new ActionSetupResult { ActionResult = Terminate() };
                }
                CurrentAction = "update";
                OldKey = GetKey(true);
                postBack = true;
            } else {
                if (!Empty(Post("action"))) {
                    CurrentAction = Post("action");
                    if (!IsShow) postBack = true;
                    if (Post(OldKeyName, out sv))
                        SetKey(sv.ToString(), IsShow);
                } else {
                    CurrentAction = "show";
                    bool loadByQuery = false;
                    if (RouteValues.TryGetValue("IdAktivitas", out rv)) {
                        IdAktivitas.QueryValue = UrlDecode(rv);
                        loadByQuery = true;
                    } else if (Get("IdAktivitas", out sv)) {
                        IdAktivitas.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        IdAktivitas.CurrentValue = DbNullValue;
                    }
                }
                if (IsShow) {
                    loaded = await LoadRow();
                    OldKey = loaded ? GetKey(true) : "";
                }
            }
            result.Loaded = loaded;
            result.PostBack = postBack;
            return result;
        }

        private async Task HandleApiFormKeys()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            if (IsApi() && RouteValues.TryGetValue("key", out object? k)) {
                var keyValues = ConvertToString(k).Split('/');
                IdAktivitas.FormValue = ConvertToString(keyValues[0]);
            }
        }

        private async Task SetupCaptchaAndDetails(bool postBack)
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            if (postBack)
                SetupDetailParms();
        }

        private async Task<IActionResult?> ExecuteCurrentAction(bool loaded)
        {
            await Task.CompletedTask; // Satisfy async requirement
            switch (CurrentAction) {
                case "show":
                    return await HandleShowAction(loaded);
                case "update":
                    return await HandleUpdateAction();
            }
            return null;
        }

        private async Task<IActionResult?> HandleShowAction(bool loaded)
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            if (!loaded) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("NoRecord");
                return Terminate("AktivitasList");
            }
            SetupDetailParms();
            return null;
        }

        private async Task<IActionResult?> HandleUpdateAction()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            CloseRecordset();
            string returnUrl = DetermineReturnUrl();
            SendEmail = true;
            var res = await EditRow();
            if (res) {
                if (Empty(SuccessMessage))
                    SuccessMessage = Language.Phrase("UpdateSuccess");
                if (IsModal && UseAjaxActions) {
                    IsModal = false;
                    if (GetPageName(returnUrl) != "AktivitasList") {
                        TempData["Return-Url"] = returnUrl;
                        returnUrl = "AktivitasList";
                    }
                }
                if (IsJsonResponse()) {
                    ClearMessages();
                    return res;
                } else {
                    return Terminate(returnUrl);
                }
            } else if (IsApi()) {
                return Terminate();
            } else if (IsModal && UseAjaxActions) {
                return Controller.Json(new { success = false, error = GetFailureMessage() });
            } else if (FailureMessage == Language.Phrase("NoRecord")) {
                return Terminate(returnUrl);
            } else {
                EventCancelled = true;
                RestoreFormValues();
                SetupDetailParms();
                return null;
            }
        }

        private string DetermineReturnUrl()
        {
            string returnUrl = "";
            if (!Empty(CurrentDetailTable)) {
                returnUrl = GetViewUrl(Config.TableShowDetail + "=" + CurrentDetailTable);
            } else {
                returnUrl = ReturnUrl;
            }
            if (GetPageName(returnUrl) == "AktivitasList")
                returnUrl = AddMasterUrl(ListUrl);
            return returnUrl;
        }

        private async Task PrepareForRender()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            SetupBreadcrumb();
            RowType = RowType.Edit;
            ResetAttributes();
            await RenderRow();
        }

        private async Task<IActionResult?> PageRunBeginAsync()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled

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
                    await SetupLookupOptions(IdProses);
                    await SetupLookupOptions(IdTemplateAktivitas);
                    await SetupLookupOptions(TipeAktivitas);
                    await SetupLookupOptions(IsNominationTankReceivingLineOpen);
                    await SetupLookupOptions(IsNonNominationReceivingLineClosedAndSealed);
                    await SetupLookupOptions(IsTankEmptyAndDry);
                    await SetupLookupOptions(IsDocumentationComplete);
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
                        aktivitasEdit?.PageRender();
                    }
        }

        // Support class
        private sealed class ActionSetupResult
        {
            public bool Loaded { get; set; }

            public bool PostBack { get; set; }

            public bool LoadByPosition { get; set; }

            public IActionResult? ActionResult { get; set; }
        }
        #pragma warning restore 219
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

            // Standard handling for 'No_Referensi'
            No_Referensi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(No_Referensi, "No_Referensi", "x_No_Referensi");

            // Standard handling for 'IdProses'
            IdProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdProses, "IdProses", "x_IdProses");

            // Standard handling for 'IdTemplateAktivitas'
            IdTemplateAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdTemplateAktivitas, "IdTemplateAktivitas", "x_IdTemplateAktivitas");

            // Standard handling for 'Aktivitas2'
            Aktivitas2.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Aktivitas2, "Aktivitas", "x_Aktivitas2");

            // Standard handling for 'NamaAktivitas'
            NamaAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NamaAktivitas, "NamaAktivitas", "x_NamaAktivitas");

            // Standard handling for 'PIC'
            PIC.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PIC, "PIC", "x_PIC");

            // Standard handling for 'TanggalMulai'
            TanggalMulai.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalMulai, "TanggalMulai", "x_TanggalMulai", true, validate, true);

            // Standard handling for 'TanggalSelesai'
            TanggalSelesai.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalSelesai, "TanggalSelesai", "x_TanggalSelesai", true, validate, true);

            // Standard handling for 'StatusAktivitas'
            StatusAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(StatusAktivitas, "StatusAktivitas", "x_StatusAktivitas");

            // Standard handling for 'TipeAktivitas'
            TipeAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TipeAktivitas, "TipeAktivitas", "x_TipeAktivitas");

            // Standard handling for 'sandar_nama_kapal'
            sandar_nama_kapal.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(sandar_nama_kapal, "sandar_nama_kapal", "x_sandar_nama_kapal");

            // Standard handling for 'sandar_tgl_tiba'
            sandar_tgl_tiba.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(sandar_tgl_tiba, "sandar_tgl_tiba", "x_sandar_tgl_tiba", true, validate, true);

            // Standard handling for 'sandar_nominasi'
            sandar_nominasi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(sandar_nominasi, "sandar_nominasi", "x_sandar_nominasi");

            // Standard handling for 'Produk'
            Produk.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Produk, "Produk", "x_Produk");

            // Standard handling for 'Shipment'
            Shipment.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Shipment, "Shipment", "x_Shipment");

            // Standard handling for 'Nama_Proses'
            Nama_Proses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Nama_Proses, "Nama_Proses", "x_Nama_Proses");

            // Standard handling for 'IdDokumen'
            IdDokumen.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdDokumen, "IdDokumen", "x_IdDokumen", true, validate, false);

            // Standard handling for 'PathFile'
            PathFile.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(PathFile, "PathFile", "x_PathFile");

            // Standard handling for 'TanggalUploadDok'
            TanggalUploadDok.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalUploadDok, "TanggalUploadDok", "x_TanggalUploadDok", true, validate, true);

            // Standard handling for 'UserUploadDok'
            UserUploadDok.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(UserUploadDok, "UserUploadDok", "x_UserUploadDok");

            // Standard handling for 'NamaDokumen'
            NamaDokumen.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NamaDokumen, "NamaDokumen", "x_NamaDokumen");

            // Standard handling for 'Keterangan'
            Keterangan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Keterangan, "Keterangan", "x_Keterangan");

            // Standard handling for 'IdRefAnak'
            IdRefAnak.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdRefAnak, "IdRefAnak", "x_IdRefAnak", true, validate, false);

            // Standard handling for 'TableAnak'
            TableAnak.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TableAnak, "TableAnak", "x_TableAnak");

            // Standard handling for 'TipeProses'
            TipeProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TipeProses, "TipeProses", "x_TipeProses");

            // Standard handling for 'Urutan'
            Urutan.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(Urutan, "Urutan", "x_Urutan", true, validate, false);

            // Standard handling for 'IsNominationTankReceivingLineOpen'
            IsNominationTankReceivingLineOpen.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IsNominationTankReceivingLineOpen, "IsNominationTankReceivingLineOpen", "x_IsNominationTankReceivingLineOpen");

            // Standard handling for 'IsNonNominationReceivingLineClosedAndSealed'
            IsNonNominationReceivingLineClosedAndSealed.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IsNonNominationReceivingLineClosedAndSealed, "IsNonNominationReceivingLineClosedAndSealed", "x_IsNonNominationReceivingLineClosedAndSealed");

            // Standard handling for 'IsTankEmptyAndDry'
            IsTankEmptyAndDry.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IsTankEmptyAndDry, "IsTankEmptyAndDry", "x_IsTankEmptyAndDry");

            // Standard handling for 'IsDocumentationComplete'
            IsDocumentationComplete.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IsDocumentationComplete, "IsDocumentationComplete", "x_IsDocumentationComplete");
            if (!IdAktivitas.IsDetailKey) {
                SetNormalField(IdAktivitas, "IdAktivitas", "x_IdAktivitas");
            }
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
                // No_Referensi

                // IdProses

                // IdTemplateAktivitas

                // Aktivitas

                // NamaAktivitas

                // PIC

                // TanggalMulai

                // TanggalSelesai

                // StatusAktivitas

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

                // TipeAktivitas

                // sandar_nama_kapal

                // sandar_tgl_tiba

                // sandar_nominasi

                // Produk

                // Shipment

                // Nama_Proses

                // IdDokumen

                // PathFile

                // TanggalUploadDok

                // UserUploadDok

                // NamaDokumen

                // Keterangan

                // IdRefAnak

                // TableAnak

                // TipeProses

                // Urutan

                // IsNominationTankReceivingLineOpen

                // IsNonNominationReceivingLineClosedAndSealed

                // IsTankEmptyAndDry

                // IsDocumentationComplete

                    // IdAktivitas
                    IdAktivitas.ViewValue = IdAktivitas.CurrentValue;
                    IdAktivitas.ViewCustomAttributes = "";

                    // No_Referensi
                    No_Referensi.ViewValue = ConvertToString(No_Referensi.CurrentValue); // DN
                    No_Referensi.ViewCustomAttributes = "";

                    // IdProses

                    // awallookupbung
                    // IdProses
                    ResolveLookupView(IdProses, "IdProses", "number");
                    // akhirlookupbung
                    IdProses.ViewCustomAttributes = "";

                    // IdTemplateAktivitas

                    // awallookupbung
                    // IdTemplateAktivitas
                    ResolveLookupView(IdTemplateAktivitas, "IdTemplateAktivitas", "number");
                    // akhirlookupbung
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

        private void ValidateCustomNo_Referensi() {
            if (No_Referensi.Visible && No_Referensi.Required) {
                if (!No_Referensi.IsDetailKey && Empty(No_Referensi.FormValue)) {
                    No_Referensi.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomIdProses() {
            if (IdProses.Visible && IdProses.Required) {
                if (!IdProses.IsDetailKey && Empty(IdProses.FormValue)) {
                    IdProses.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomIdTemplateAktivitas() {
            if (IdTemplateAktivitas.Visible && IdTemplateAktivitas.Required) {
                if (!IdTemplateAktivitas.IsDetailKey && Empty(IdTemplateAktivitas.FormValue)) {
                    IdTemplateAktivitas.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomAktivitas2() {
            if (Aktivitas2.Visible && Aktivitas2.Required) {
                if (!Aktivitas2.IsDetailKey && Empty(Aktivitas2.FormValue)) {
                    Aktivitas2.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomNamaAktivitas() {
            if (NamaAktivitas.Visible && NamaAktivitas.Required) {
                if (!NamaAktivitas.IsDetailKey && Empty(NamaAktivitas.FormValue)) {
                    NamaAktivitas.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomPIC() {
            if (PIC.Visible && PIC.Required) {
                if (!PIC.IsDetailKey && Empty(PIC.FormValue)) {
                    PIC.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomTanggalMulai() {
            if (TanggalMulai.Visible && TanggalMulai.Required) {
                if (!TanggalMulai.IsDetailKey && Empty(TanggalMulai.FormValue)) {
                    TanggalMulai.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomTanggalSelesai() {
            if (TanggalSelesai.Visible && TanggalSelesai.Required) {
                if (!TanggalSelesai.IsDetailKey && Empty(TanggalSelesai.FormValue)) {
                    TanggalSelesai.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomStatusAktivitas() {
            if (StatusAktivitas.Visible && StatusAktivitas.Required) {
                if (!StatusAktivitas.IsDetailKey && Empty(StatusAktivitas.FormValue)) {
                    StatusAktivitas.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomTipeAktivitas() {
            if (TipeAktivitas.Visible && TipeAktivitas.Required) {
                if (!TipeAktivitas.IsDetailKey && Empty(TipeAktivitas.FormValue)) {
                    TipeAktivitas.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomsandar_nama_kapal() {
            if (sandar_nama_kapal.Visible && sandar_nama_kapal.Required) {
                if (!sandar_nama_kapal.IsDetailKey && Empty(sandar_nama_kapal.FormValue)) {
                    sandar_nama_kapal.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomsandar_tgl_tiba() {
            if (sandar_tgl_tiba.Visible && sandar_tgl_tiba.Required) {
                if (!sandar_tgl_tiba.IsDetailKey && Empty(sandar_tgl_tiba.FormValue)) {
                    sandar_tgl_tiba.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomsandar_nominasi() {
            if (sandar_nominasi.Visible && sandar_nominasi.Required) {
                if (!sandar_nominasi.IsDetailKey && Empty(sandar_nominasi.FormValue)) {
                    sandar_nominasi.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomProduk() {
            if (Produk.Visible && Produk.Required) {
                if (!Produk.IsDetailKey && Empty(Produk.FormValue)) {
                    Produk.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomShipment() {
            if (Shipment.Visible && Shipment.Required) {
                if (!Shipment.IsDetailKey && Empty(Shipment.FormValue)) {
                    Shipment.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomNama_Proses() {
            if (Nama_Proses.Visible && Nama_Proses.Required) {
                if (!Nama_Proses.IsDetailKey && Empty(Nama_Proses.FormValue)) {
                    Nama_Proses.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomIdDokumen() {
            if (IdDokumen.Visible && IdDokumen.Required) {
                if (!IdDokumen.IsDetailKey && Empty(IdDokumen.FormValue)) {
                    IdDokumen.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomPathFile() {
            if (PathFile.Visible && PathFile.Required) {
                if (!PathFile.IsDetailKey && Empty(PathFile.FormValue)) {
                    PathFile.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomTanggalUploadDok() {
            if (TanggalUploadDok.Visible && TanggalUploadDok.Required) {
                if (!TanggalUploadDok.IsDetailKey && Empty(TanggalUploadDok.FormValue)) {
                    TanggalUploadDok.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomUserUploadDok() {
            if (UserUploadDok.Visible && UserUploadDok.Required) {
                if (!UserUploadDok.IsDetailKey && Empty(UserUploadDok.FormValue)) {
                    UserUploadDok.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomNamaDokumen() {
            if (NamaDokumen.Visible && NamaDokumen.Required) {
                if (!NamaDokumen.IsDetailKey && Empty(NamaDokumen.FormValue)) {
                    NamaDokumen.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomKeterangan() {
            if (Keterangan.Visible && Keterangan.Required) {
                if (!Keterangan.IsDetailKey && Empty(Keterangan.FormValue)) {
                    Keterangan.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomIdRefAnak() {
            if (IdRefAnak.Visible && IdRefAnak.Required) {
                if (!IdRefAnak.IsDetailKey && Empty(IdRefAnak.FormValue)) {
                    IdRefAnak.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomTableAnak() {
            if (TableAnak.Visible && TableAnak.Required) {
                if (!TableAnak.IsDetailKey && Empty(TableAnak.FormValue)) {
                    TableAnak.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomTipeProses() {
            if (TipeProses.Visible && TipeProses.Required) {
                if (!TipeProses.IsDetailKey && Empty(TipeProses.FormValue)) {
                    TipeProses.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomUrutan() {
            if (Urutan.Visible && Urutan.Required) {
                if (!Urutan.IsDetailKey && Empty(Urutan.FormValue)) {
                    Urutan.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomIsNominationTankReceivingLineOpen() {
            if (IsNominationTankReceivingLineOpen.Visible && IsNominationTankReceivingLineOpen.Required) {
                if (Empty(IsNominationTankReceivingLineOpen.FormValue)) {
                    IsNominationTankReceivingLineOpen.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomIsNonNominationReceivingLineClosedAndSealed() {
            if (IsNonNominationReceivingLineClosedAndSealed.Visible && IsNonNominationReceivingLineClosedAndSealed.Required) {
                if (Empty(IsNonNominationReceivingLineClosedAndSealed.FormValue)) {
                    IsNonNominationReceivingLineClosedAndSealed.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomIsTankEmptyAndDry() {
            if (IsTankEmptyAndDry.Visible && IsTankEmptyAndDry.Required) {
                if (Empty(IsTankEmptyAndDry.FormValue)) {
                    IsTankEmptyAndDry.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        private void ValidateCustomIsDocumentationComplete() {
            if (IsDocumentationComplete.Visible && IsDocumentationComplete.Required) {
                if (Empty(IsDocumentationComplete.FormValue)) {
                    IsDocumentationComplete.AddErrorMessage(ConvertToString(IsDocumentationComplete.RequiredErrorMessage).Replace("%s", IsDocumentationComplete.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomNo_Referensi();
                ValidateCustomIdProses();
                ValidateCustomIdTemplateAktivitas();
                ValidateCustomAktivitas2();
                ValidateCustomNamaAktivitas();
                ValidateCustomPIC();
                ValidateCustomTanggalMulai();
                if (!CheckDate(TanggalMulai.FormValue, TanggalMulai.FormatPattern)) {
                    TanggalMulai.AddErrorMessage(TanggalMulai.GetErrorMessage(false));
                }
                ValidateCustomTanggalSelesai();
                if (!CheckDate(TanggalSelesai.FormValue, TanggalSelesai.FormatPattern)) {
                    TanggalSelesai.AddErrorMessage(TanggalSelesai.GetErrorMessage(false));
                }
                ValidateCustomStatusAktivitas();
                ValidateCustomTipeAktivitas();
                ValidateCustomsandar_nama_kapal();
                ValidateCustomsandar_tgl_tiba();
                if (!CheckDate(sandar_tgl_tiba.FormValue, sandar_tgl_tiba.FormatPattern)) {
                    sandar_tgl_tiba.AddErrorMessage(sandar_tgl_tiba.GetErrorMessage(false));
                }
                ValidateCustomsandar_nominasi();
                ValidateCustomProduk();
                ValidateCustomShipment();
                ValidateCustomNama_Proses();
                ValidateCustomIdDokumen();
                if (!CheckInteger(IdDokumen.FormValue)) {
                    IdDokumen.AddErrorMessage(IdDokumen.GetErrorMessage(false));
                }
                ValidateCustomPathFile();
                ValidateCustomTanggalUploadDok();
                if (!CheckDate(TanggalUploadDok.FormValue, TanggalUploadDok.FormatPattern)) {
                    TanggalUploadDok.AddErrorMessage(TanggalUploadDok.GetErrorMessage(false));
                }
                ValidateCustomUserUploadDok();
                ValidateCustomNamaDokumen();
                ValidateCustomKeterangan();
                ValidateCustomIdRefAnak();
                if (!CheckInteger(IdRefAnak.FormValue)) {
                    IdRefAnak.AddErrorMessage(IdRefAnak.GetErrorMessage(false));
                }
                ValidateCustomTableAnak();
                ValidateCustomTipeProses();
                ValidateCustomUrutan();
                if (!CheckInteger(Urutan.FormValue)) {
                    Urutan.AddErrorMessage(Urutan.GetErrorMessage(false));
                }
                ValidateCustomIsNominationTankReceivingLineOpen();
                ValidateCustomIsNonNominationReceivingLineClosedAndSealed();
                ValidateCustomIsTankEmptyAndDry();
                ValidateCustomIsDocumentationComplete();

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
