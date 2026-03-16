using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// aktivitasDokumenGrid
    /// </summary>
    public static AktivitasDokumenGrid aktivitasDokumenGrid
    {
        get => HttpData.Get<AktivitasDokumenGrid>("aktivitasDokumenGrid")!;
        set => HttpData["aktivitasDokumenGrid"] = value;
    }

    /// <summary>
    /// Page class for AktivitasDokumen
    /// </summary>
    public class AktivitasDokumenGrid : AktivitasDokumenGridBase
    {
        // Constructor
        public AktivitasDokumenGrid() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class AktivitasDokumenGridBase : AktivitasDokumen
    {
        // Page ID
        public string PageID = "grid";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "aktivitasDokumenGrid";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fAktivitasDokumengrid";

        public string FormActionName = "";

        public string FormBlankRowName = "";

        public string FormKeyCountName = "";

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
        public AktivitasDokumenGridBase(Controller? controller)
        {
            TableName = "AktivitasDokumen";

            // CSS class name as context
            TableVar = "AktivitasDokumen";
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Fixed header table
            if (!UseCustomTemplate)
                SetFixedHeaderTable(Config.UseFixedHeaderTable, Config.FixedHeaderTableHeight);
            FormActionName = Config.FormRowActionName;
            FormBlankRowName = Config.FormBlankRowName;
            FormKeyCountName = Config.FormKeyCountName;

            // Initialize
            FormActionName += "_" + FormName;
            OldKeyName += "_" + FormName;
            FormBlankRowName += "_" + FormName;
            FormKeyCountName += "_" + FormName;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // CSS class name as context
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Language object
            Language = ResolveLanguage();
            AddUrl = "AktivitasDokumenAdd";

            // Open connection
            Conn = Connection; // DN

            // Other options
            OtherOptions["addedit"] = new() {
                TagClassName = "ew-add-edit-option",
                UseDropDownButton = false,
                DropDownButtonPhrase = "ButtonAddEdit",
                UseButtonGroup = true
            };
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
        public string PageName => "AktivitasDokumenGrid";

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
            IdAktivitasDokumen.Visible = false;
            NoReferensi.SetVisibility();
            IdProses.SetVisibility();
            IdAktivitas.SetVisibility();
            IdDokumen.Visible = false;
            NamaDokumen.SetVisibility();
            TemplateDokumen.Visible = false;
            UploadDokumen.SetVisibility();
            DownloadDokumen.SetVisibility();
            Keterangan.Visible = false;
            PathFile.Visible = false;
            StatusUpload.Visible = false;
            DiunggahOleh.SetVisibility();
            TanggalUpload.SetVisibility();
            DiperbaruiOleh.SetVisibility();
            TanggalDiperbarui.SetVisibility();
            IdTemplateAktivitasDokumen.Visible = false;
            WajibUpload.SetVisibility();
            TipeProses.SetVisibility();
        }

        // Constructor
        public AktivitasDokumenGridBase() : this(null) { }

        /// <summary>
        /// Terminate page
        /// </summary>
        /// <param name="url">URL to rediect to</param>
        /// <returns>Page result</returns>
        public override IActionResult Terminate(string url = "")
        { // DN
            if (_terminated) return new EmptyResult();
            if (Empty(url)) return new EmptyResult();
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
        private IActionResult BuildApiTerminateResult(string url)
        {
            var result = new Dictionary<string, string> { { "version", Config.ProductVersion } };
            if (!Empty(url)) result.Add("url", GetUrl(url));
            foreach (var (key, value) in GetMessages()) result.Add(key, value);
            return Controller.Json(result);
        }

        private IActionResult HandleRedirect(string url)
        {
            SaveDebugMessage();
            return RedirectCore(url);
        }

        private IActionResult RedirectCore(string url)
        {
            return Controller.LocalRedirect(AppPath(url));
        }

        // Get all records from datareader
        [return: NotNullIfNotNull("dr")]
        protected async Task<List<Dictionary<string, object>>> GetRecordsFromRecordset(DbDataReader? dr)
        {
            List<Dictionary<string, object>> rows = [];
            while (dr != null && await dr.ReadAsync()) {
                await LoadRowValues(dr); // Set up DbValue/CurrentValue
                PathFile.OldUploadPath = PathFile.GetUploadPath();
                PathFile.UploadPath = PathFile.OldUploadPath;
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdAktivitasDokumen") ? dict["IdAktivitasDokumen"] : IdAktivitasDokumen.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdAktivitasDokumen.Visible = false;
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
        private Pager? _pager; // DN

        public int SelectedCount = 0;

        public int SelectedIndex = 0;

        #pragma warning disable 169

        public bool ShowOtherOptions = false;

        private DatabaseConnection<SqlConnection, SqlDbType>? _connection;
        #pragma warning restore 169

        public int DisplayRecords = 10; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public string PageSizes = "10,20,50,100,-1"; // Page sizes (comma separated)

        public string DefaultSearchWhere = ""; // Default search WHERE clause

        public string SearchWhere = ""; // Search WHERE clause

        public string SearchPanelClass = "ew-search-panel collapse show"; // Search panel class

        public int SearchColumnCount = 0; // For extended search

        public int SearchFieldsPerRow = 1; // For extended search

        public int RecordCount = 0; // Record count

        public int InlineRowCount = 0;

        public int StartRowCount = 1;

        public List<Tuple<string, Dictionary<string, string>>> Attributes = new(); // Row attributes and cell attributes

        public object RowIndex = 0; // Row index

        public int KeyCount = 0; // Key count

        public string MultiColumnGridClass = "row-cols-md";

        public string MultiColumnEditClass = "col-12 w-100";

        public string MultiColumnCardClass = "card h-100 ew-card";

        public string MultiColumnListOptionsPosition = "bottom-start";

        public string DbMasterFilter = ""; // Master filter

        public string DbDetailFilter = ""; // Detail filter

        public bool MasterRecordExists;

        public string MultiSelectKey = "";

        public string UserAction = ""; // User action

        public bool RestoreSearch = false;

        public SubPages? DetailPages; // Detail pages object

        public DbDataReader? Recordset;

        public List<string> RecordKeys = [];

        public bool IsModal = false;

        private string FilterForModalActions = "";

        private bool UseInfiniteScroll = false;

        // Pager
        public Pager Pager
        {
            get {
                _pager ??= new PrevNextPager(this, StartRecord, RecordsPerPage, TotalRecords, PageSizes, RecordRange, AutoHidePager, AutoHidePageSizeSelector);
                return _pager;
            }
        }

        #pragma warning disable 618
        // Connection
        public override DatabaseConnection<SqlConnection, SqlDbType> Connection
        {
            get {
                _connection ??= GetConnection2(DbId);
                return _connection;
            }
        }
        #pragma warning restore 618

        /// <summary>
        /// Load recordset from filter
        /// <param name="filter">Record filter</param>
        /// </summary>
        public async Task LoadRecordsetFromFilter(string filter)
        {
            // Set up list options
            await SetupListOptions();

            // Load recordset
            TotalRecords = LoadRecordCount(filter);
            StartRecord = 1;
            StopRecord = DisplayRecords;
            CurrentFilter = filter;
            Recordset = await LoadRecordset();
        }

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            // --- BEGIN include dipindah ke helper yang bisa return IActionResult ---
            var beginResult = await PageRunBeginAsync();
            if (beginResult != null)
                return beginResult;

            // --- Initial setup ---
            PrepareInitialSettings();

            // --- Process list actions (for list pages) ---
            var listActionResult = await ProcessListActionsIfNeeded();
            if (listActionResult != null)
                return listActionResult;

            // --- Setup display and commands ---
            SetupDisplayAndCommands();

            // --- Handle import (if applicable) ---
            var importResult = await HandleImportIfNeeded();
            if (importResult != null)
                return importResult;

            // --- Process inline actions ---
            var inlineResult = await ProcessInlineActions();
            if (inlineResult != null)
                return inlineResult;

            // --- Setup options visibility ---
            SetupOptionsVisibility();

            // --- Process search and filters ---
            var searchResult = await ProcessSearchAndFilters();
            if (searchResult != null)
                return searchResult;

            // --- Build filter and load records ---
            var recordResult = await BuildFilterAndLoadRecords();
            if (recordResult != null)
                return recordResult;

            // --- Handle API requests ---
            var apiResult = await HandleApiRequests();
            if (apiResult != null)
                return apiResult;

            // --- Final setup ---
            FinalSetup();

            // --- END include ---
            PageRunEnd();
            return new EmptyResult();
        }

        // ================== GENERATED HELPERS ==================
        private void PrepareInitialSettings()
        {
            // Multi column button position
            MultiColumnListOptionsPosition = Config.MultiColumnListOptionsPosition;
            if (Empty(DashboardReport))
                DashboardReport = Param(Config.PageDashboard);

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fAktivitasDokumengrid";

            // Set up infinite scroll
            UseInfiniteScroll = Param<bool>("infinitescroll");

            // Set up Dashboard Filter
            if (!Empty(DashboardReport))
                AddFilter(ref Filter, GetDashboardFilter(DashboardReport, TableVar));

            // Get command
            Command = Get("cmd").ToLower();
        }

        private async Task<IActionResult?> ProcessListActionsIfNeeded()
        {
            return null;
        }

        private void SetupDisplayAndCommands()
        {
            // Set up records per page
            SetupDisplayRecords();

            // Handle reset command
            ResetCommand();
        }

        private async Task<IActionResult?> HandleImportIfNeeded()
        {
            await Task.CompletedTask; // Satisfy async requirement
            return null;
        }

        private async Task<IActionResult?> ProcessInlineActions()
        {
            StringValues sv;

            // Check QueryString parameters
            HandleQueryStringParameters(out sv);

            // Clear inline mode if cancel
            if (IsCancel)
                ClearInlineMode();

            // Handle different edit modes
            var editModeResult = await HandleEditModes();
            if (editModeResult != null)
                return editModeResult;

            // Handle inline operations
            var inlineResult = await HandleInlineOperations();
            if (inlineResult != null)
                return inlineResult;
            return null;
        }

        private void HandleQueryStringParameters(out StringValues sv)
        {
            sv = default;
            if (Get("action", out sv)) {
                CurrentAction = sv.ToString();
            } else {
                if (Post("action", out sv)) {
                    if (sv.ToString() != UserAction)
                        CurrentAction = sv.ToString(); // Get action
                } else if (SameString(Session[Config.SessionInlineMode], "gridedit")) { // Previously in grid edit mode
                    if (Query.ContainsKey(Config.TableStartRec) || Query.ContainsKey(Config.TablePageNumber)) // Stay in grid edit mode if paging
                        GridEditMode();
                    else // Reset grid edit
                        ClearInlineMode();
                }
            }
        }

        private async Task<IActionResult?> HandleEditModes()
        {
            // Switch to grid edit mode
            if (IsGridEdit)
                GridEditMode();

            // Grid Update
            if (IsPost() && (IsGridUpdate || IsMultiUpdate || IsGridOverwrite) && (SameString(Session[Config.SessionInlineMode], "gridedit") || SameString(Session[Config.SessionInlineMode], "multiedit"))) {
                var gridUpdateResult = await HandleGridUpdate();
                if (gridUpdateResult != null)
                    return gridUpdateResult;
            }
            return null;
        }

        private async Task<IActionResult?> HandleGridUpdate()
        {
            var gridUpdate = false;
            if (await ValidateGridForm()) {
                gridUpdate = await GridUpdate();
            } else {
                gridUpdate = false;
            }
            if (gridUpdate) {
                // Handle modal grid edit and multi edit, redirect to list page directly
                if (IsModal && !UseAjaxActions)
                    return Terminate("AktivitasDokumenList");
            } else {
                EventCancelled = true;
                if (UseAjaxActions) {
                    if (IsModal)
                        AddHeader("Modal-Error", "?1");
                    else
                        return Controller.Json(new { success = false, error = GetFailureMessage() });
                }
                if (IsMultiUpdate) { // Stay in Multi-Edit mode
                    var records = GetGridFormValues().Select(row => row.ToDictionary(kvp => kvp.Key, kvp => (object)(kvp.Value ?? "")));
                    FilterForModalActions = GetFilterFromRecords(records);
                } else { // Stay in grid edit mode
                    GridEditMode();
                }
            }
            return null;
        }

        private async Task<IActionResult?> HandleInlineOperations()
        {
            // Switch to grid add mode
            if (IsGridAdd) {
                GridAddMode();
            // Grid Insert
            } else if (IsPost() && IsGridInsert && SameString(Session[Config.SessionInlineMode], "gridadd")) {
                return await HandleGridInsert();
            }
            return null;
        }

        private async Task<IActionResult?> HandleGridInsert()
        {
            var gridInsert = false;
            if (await ValidateGridForm())
                gridInsert = await GridInsert();
            if (gridInsert) {
                // Handle modal grid add, redirect to list page directly
                if (IsModal && !UseAjaxActions)
                    return Terminate("AktivitasDokumenList");
            } else {
                EventCancelled = true;
                if (UseAjaxActions) {
                    if (IsModal)
                        AddHeader("Modal-Error", "?1");
                    else
                        return Controller.Json(new { success = false, error = GetFailureMessage() });
                }
                GridAddMode(); // Stay in grid add mode
            }
            return null;
        }

        private void SetupOptionsVisibility()
        {
            // Hide list options
            if (IsExport()) {
                ListOptions.HideAllOptions(["sequence"]);
                ListOptions.UseDropDownButton = false; // Disable drop down button
                ListOptions.UseButtonGroup = false; // Disable button group
            } else if (IsGridAdd || IsGridEdit || IsMultiEdit || IsConfirm) {
                ListOptions.HideAllOptions();
                ListOptions.UseDropDownButton = false; // Disable drop down button
                ListOptions.UseButtonGroup = false; // Disable button group
            }

            // Show grid delete link for grid add / grid edit
            if (AllowAddDeleteRow) {
                if (IsGridAdd || IsGridEdit) {
                    var item = ListOptions["griddelete"];
                    if (item != null)
                        item.Visible = false;
                }
            }
        }

        private async Task<IActionResult?> ProcessSearchAndFilters()
        {
            SetupSortOrder();
            await Task.CompletedTask; // Satisfy async requirement
            RestoreDisplayRecords();
            return null;
        }

        private void RestoreDisplayRecords()
        {
            if (Command != "json" && (RecordsPerPage == -1 || RecordsPerPage > 0)) {
                DisplayRecords = RecordsPerPage;
            } else {
                DisplayRecords = 10;
                RecordsPerPage = DisplayRecords;
            }
        }

        private async Task<IActionResult?> BuildFilterAndLoadRecords()
        {
            await Task.CompletedTask; // Satisfy async requirement

            // Build filter
            if (!Security.CanList)
                Filter = "(0=1)"; // Filter all records

            // Restore master/detail filter from session
            DbMasterFilter = MasterFilterFromSession;
            DbDetailFilter = DetailFilterFromSession;
            AddFilter(ref Filter, DbDetailFilter);
            AddFilter(ref Filter, SearchWhere);

            // Load master records and handle early returns
            var masterResult = await LoadMasterRecords();
            if (masterResult != null)
                return masterResult;

            // Set up filter and load recordset
            SetupFilterAndRecordset();

            // Load recordset based on mode
            await LoadRecordsetByMode();

            // Setup list actions and load records
            await SetupListActionsAndRecords();
            return null;
        }

        private async Task<IActionResult?> LoadMasterRecords()
        {
            await Task.CompletedTask; // Satisfy async requirement

            // Load master record
            if (CurrentMode != "add" && !Empty(MasterFilterFromSession) && CurrentMasterTable == "Aktivitas") {
                aktivitas = Resolve("Aktivitas")!;
                if (aktivitas != null) {
                    var rowMaster = await aktivitas.Connection.GetRowAsync(aktivitas.GetSql(DbMasterFilter));
                    MasterRecordExists = rowMaster != null;
                    if (!MasterRecordExists) {
                        FailureMessage = Language.Phrase("NoRecord"); // Set no record found
                        return Terminate("AktivitasList"); // Return to master page
                    } else {
                        aktivitas.LoadListRowValues(rowMaster);
                    }
                    aktivitas.RowType = RowType.Master; // Master row
                    await aktivitas.RenderListRow(); // Note: Do it outside "using" // DN
                }
            }
            return null;
        }

        private void SetupFilterAndRecordset()
        {
            // Set up filter
            if (Command == "json") {
                UseSessionForListSql = false; // Do not use session for ListSql
                CurrentFilter = Filter;
            } else {
                SessionWhere = Filter;
                CurrentFilter = "";
            }
            Filter = ApplyUserIDFilters(Filter);
        }

        private async Task LoadRecordsetByMode()
        {
            if (IsGridAdd) {
                await LoadRecordsetForGridAdd();
            } else if ((IsEdit || IsCopy || IsInlineInserted || IsInlineUpdated) && UseInfiniteScroll) {
                await LoadRecordsetForInlineOperations();
            } else if (UseInfiniteScroll && IsGridInserted ||
                       UseInfiniteScroll && (IsGridEdit || IsGridUpdated) ||
                       IsMultiEdit ||
                       UseInfiniteScroll && IsMultiUpdated) {
                await LoadRecordsetForModalActions();
            } else {
                await LoadRecordsetNormal();
            }
        }

        private async Task LoadRecordsetForGridAdd()
        {
            await Task.CompletedTask; // Satisfy async requirement
            if (CurrentMode == "copy") {
                TotalRecords = await ListRecordCountAsync();
                Recordset = await LoadRecordset(StartRecord - 1, TotalRecords);
                StartRecord = 1;
                DisplayRecords = TotalRecords;
            } else {
                CurrentFilter = "0=1";
                StartRecord = 1;
                DisplayRecords = GridAddRowCount;
            }
            TotalRecords = DisplayRecords;
            StopRecord = DisplayRecords;
        }

        private async Task LoadRecordsetForInlineOperations()
        {
            // Get current record only
            CurrentFilter = IsInlineUpdated ? GetRecordFilter() : GetFilterFromRecordKeys();
            TotalRecords = ListRecordCount();
            StartRecord = 1;
            StopRecord = DisplayRecords;
            Recordset = await LoadRecordset();
        }

        private async Task LoadRecordsetForModalActions()
        {
            // Get current records only
            CurrentFilter = FilterForModalActions; // Restore filter
            TotalRecords = ListRecordCount();
            StartRecord = 1;
            StopRecord = DisplayRecords;
            Recordset = await LoadRecordset();
        }

        private async Task LoadRecordsetNormal()
        {
            TotalRecords = await ListRecordCountAsync();
            StopRecord = DisplayRecords;
            StartRecord = 1;
            DisplayRecords = TotalRecords; // Display all records
        }

        private async Task SetupListActionsAndRecords()
        {
            // Recordset
            bool selectLimit = UseSelectLimit;
            if (selectLimit)
                Recordset = await LoadRecordset(StartRecord - 1, DisplayRecords);
        }

        private async Task<IActionResult?> HandleApiRequests()
        {
            return await ProcessApiRequest();
        }

        private async Task<IActionResult?> ProcessApiRequest()
        {
            if (!IsApi())
                return null;
            if (CurrentPageName().ToLowerInvariant().EndsWith(Config.ApiListAction)) {
                return await HandleApiListAction();
            } else if (!Empty(FailureMessage)) {
                return Controller.Json(new { success = false, error = GetFailureMessage() });
            }
            return new EmptyResult();
        }

        private async Task<IActionResult> HandleApiListAction()
        {
            if (IsExport())
                return new EmptyResult();
            await MoveToStartRecord();
            using (Recordset) {
                return Controller.Json(new Dictionary<string, object> { 
                    {"success", true}, 
                    {TableVar, await GetRecordsFromRecordset(Recordset)}, 
                    {"totalRecordCount", TotalRecords}, 
                    {"version", Config.ProductVersion} 
                });
            }
        }

        private async Task MoveToStartRecord()
        {
            if (!Connection.SelectOffset && Recordset != null) {
                for (var i = 1; i <= StartRecord - 1; i++)
                    await Recordset.ReadAsync();
            }
        }

        private void FinalSetup()
        {
            // Render other options
            RenderOtherOptions();

            // Set ReturnUrl in header if necessary
            if (TempData["Return-Url"] != null)
                AddHeader("Return-Url", ConvertToString(TempData["Return-Url"]));
        }

        // ===== Wrap includes ke helper =====
        private async Task<IActionResult?> PageRunBeginAsync()
        {
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
            if (!Empty(Param("export")))
                Export = Param("export");

            // Get grid add count
            int gridaddcnt = Get<int>(Config.TableGridAddRowCount);
            if (gridaddcnt > 0)
                GridAddRowCount = gridaddcnt;

            // Set up list options
            await SetupListOptions();
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

            // Set up master detail parameters
            SetupMasterParms();

            // Setup other options
            SetupOtherOptions();

            // Set up lookup cache
            await SetupLookupOptions(IdProses);
            await SetupLookupOptions(IdAktivitas);
            await SetupLookupOptions(IdDokumen);
            await SetupLookupOptions(WajibUpload);

            // Load default values for add
            LoadDefaultValues();
            return null; // kalau include tidak melakukan return
        }

        private void PageRunEnd()
        {
            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();
                PageRenderingEventHandler?.Invoke(null, EventArgs.Empty);

                // Page Render event
                aktivitasDokumenGrid?.PageRender();
            }
        }
        #pragma warning restore 219

        // Get page number
        public int PageNumber => DisplayRecords > 0 && StartRecord > 0 ? ConvertToInt(Math.Ceiling((double)StartRecord / DisplayRecords)) : 1;

        // Set up number of records displayed per page
        protected void SetupDisplayRecords() {
            string wrk = Get(Config.TableRecordsPerPage);
            if (!Empty(wrk)) {
                if (IsNumeric(wrk)) {
                    DisplayRecords = ConvertToInt(wrk);
                } else {
                    if (SameText(wrk, "all")) { // Display all records
                        DisplayRecords = -1;
                    } else {
                        DisplayRecords = 10; // Non-numeric, load default
                    }
                }
                RecordsPerPage = DisplayRecords; // Save to Session
                // Reset start position
                StartRecord = 1;
                StartRecordNumber = StartRecord;
            }
        }

        // Exit inline mode
        protected void ClearInlineMode() {
            LastAction = CurrentAction; // Save last action
            CurrentAction = ""; // Clear action
            Session[Config.SessionInlineMode] = ""; // Clear inline mode
        }

        // Switch to grid add mode
        protected void GridAddMode() {
            CurrentAction = "gridadd";
            Session[Config.SessionInlineMode] = "gridadd"; // Enabled grid add
            HideFieldsForAddEdit();
        }

        // Switch to grid edit mode
        protected void GridEditMode() {
            CurrentAction = "gridedit";
            Session[Config.SessionInlineMode] = "gridedit"; // Enabled grid edit
            HideFieldsForAddEdit();
        }

        // Perform update to grid
        public async Task<bool> GridUpdate()
        {
            bool gridUpdate = true;

            // Get old recordset
            CurrentFilter = BuildKeyFilter();
            if (Empty(CurrentFilter))
                CurrentFilter = "0=1";
            string sql = CurrentSql;
            List<Dictionary<string, object>> rsold = await Connection.GetRowsAsync(sql);

            // Call Grid Updating event
            if (!GridUpdating(rsold)) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("GridEditCancelled"); // Set grid edit cancelled message
                EventCancelled = true;
                return false;
            }
            string wrkFilter = "";
            string key = "";

            // Update row index and get row key
            CurrentForm?.ResetIndex();
            int rowcnt = CurrentForm?.GetInt(FormKeyCountName) ?? 0;

            // Load default values for emptyRow checking // DN
            LoadDefaultValues();

            // Update all rows based on key
            try {
                for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                    CurrentForm!.Index = rowindex;
                    SetKey(CurrentForm.GetValue(OldKeyName));
                    string rowaction = CurrentForm.GetValue(FormActionName);

                    // Load all values and keys
                    if (rowaction != "insertdelete" && rowaction != "hide") { // Skip insert then deleted rows / hidden rows for grid edit
                        await LoadFormValues(); // Get form values
                        if (Empty(rowaction) || rowaction == "edit" || rowaction == "delete") {
                            gridUpdate = !Empty(OldKey); // Key must not be empty
                        } else {
                            gridUpdate = true;
                        }

                        // Skip empty row
                        if (rowaction == "insert" && EmptyRow()) {
                            // No action required
                        } else if (gridUpdate) { // Validate form and insert/update/delete record
                            if (rowaction == "delete") {
                                CurrentFilter = GetRecordFilter();
                                gridUpdate = await DeleteRows(); // Delete this row
                            } else {
                                if (rowaction == "insert") {
                                    gridUpdate = await AddRow(); // Insert this row
                                } else {
                                    if (!Empty(OldKey)) {
                                        SendEmail = false; // Do not send email on update success
                                        gridUpdate = await EditRow(); // Update this row
                                    }
                                } // End update
                                if (gridUpdate) // Get inserted or updated filter
                                    AddFilter(ref wrkFilter, GetRecordFilter(), "OR");
                            }
                        }
                        if (gridUpdate) {
                            if (!Empty(key))
                                key += ", ";
                            key += OldKey;
                        } else {
                            EventCancelled = true;
                            break;
                        }
                    }
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                gridUpdate = false;
            }
            if (gridUpdate) {
                FilterForModalActions = wrkFilter;

                // Get new recordset
                List<Dictionary<string, object>> rsnew = await Connection.GetRowsAsync(sql, true); // Use main connection (faster) // DN

                // Call Grid Updated event
                GridUpdated(rsold, rsnew);
                ClearInlineMode(); // Clear inline edit mode
            } else {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("UpdateFailed"); // Set update failed message
            }
            return gridUpdate;
        }

        // Build filter for all keys
        protected string BuildKeyFilter() {
            string wrkFilter = "";

            // Update row index and get row key
            int rowindex = 1;
            CurrentForm!.Index = rowindex;
            string thisKey = CurrentForm.GetValue(OldKeyName);
            while (!Empty(thisKey)) {
                SetKey(thisKey);
                if (!Empty(OldKey)) {
                    string filter = GetRecordFilter();
                    if (!Empty(wrkFilter))
                        wrkFilter += " OR ";
                    wrkFilter += filter;
                } else {
                    wrkFilter = "0=1";
                    break;
                }

                // Update row index and get row key
                rowindex++; // next row
                CurrentForm!.Index = rowindex;
                thisKey = CurrentForm.GetValue(OldKeyName);
            }
            return wrkFilter;
        }

        // Perform Grid Add
        #pragma warning disable 168, 219

        public async Task<bool> GridInsert()
        {
            int addcnt = 0;
            bool gridInsert = false;

            // Call Grid Inserting event
            if (!GridInserting()) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("GridAddCancelled"); // Set grid add cancelled message
                EventCancelled = true;
                return false;
            }

            // Init key filter
            string wrkFilter = "";
            string key = "";

            // Get row count
            CurrentForm?.ResetIndex();
            int rowcnt = CurrentForm?.GetInt(FormKeyCountName) ?? 0;

            // Load default values for emptyRow checking // DN
            LoadDefaultValues();

            // Insert all rows
            try {
                for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                    // Load current row values
                    CurrentForm!.Index = rowindex;
                    string rowaction = CurrentForm.GetValue(FormActionName);
                    Dictionary<string, object>? rsold = null;
                    if (!Empty(rowaction) && rowaction != "insert")
                        continue; // Skip
                    if (rowaction == "insert") {
                        OldKey = CurrentForm.GetValue(OldKeyName);
                        rsold = await LoadOldRecord(); // Load old record
                    }
                    await LoadFormValues(); // Get form values
                    if (!EmptyRow()) {
                        addcnt++;
                        SendEmail = false; // Do not send email on insert success
                        gridInsert = await AddRow(rsold); // Insert row (already validated by validateGridForm())
                        if (gridInsert) {
                            if (!Empty(key))
                                key += Config.CompositeKeySeparator;
                            key += ConvertToString(IdAktivitasDokumen.CurrentValue);

                            // Add filter for this record
                            AddFilter(ref wrkFilter, GetRecordFilter(), "OR");
                        } else {
                            EventCancelled = true;
                            break;
                        }
                    }
                }
                if (addcnt == 0) { // No record inserted
                    ClearInlineMode(); // Clear grid add mode and return
                    return true;
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                gridInsert = false;
            }
            if (gridInsert) {
                // Get new recordset
                CurrentFilter = wrkFilter;
                FilterForModalActions = wrkFilter;
                string sql = CurrentSql;
                List<Dictionary<string, object>> rsnew = await Connection.GetRowsAsync(sql, true); // Use main connection (faster) // DN

                // Call Grid Inserted event
                GridInserted(rsnew);
                ClearInlineMode(); // Clear grid add mode
            } else {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("InsertFailed"); // Set insert failed message
            }
            return gridInsert;
        }
        #pragma warning restore 168, 219

        // Check if empty row
        public bool EmptyRow()
        {
            if (CurrentForm == null)
                return true;
            if (CurrentForm.HasValue("x_NoReferensi") && CurrentForm.HasValue("o_NoReferensi") && !SameString(NoReferensi.CurrentValue, NoReferensi.DefaultValue) &&
            !(NoReferensi.IsForeignKey && CurrentMasterTable != "" && SameString(NoReferensi.CurrentValue, NoReferensi.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_IdProses") && CurrentForm.HasValue("o_IdProses") && !SameString(IdProses.CurrentValue, IdProses.DefaultValue) &&
            !(IdProses.IsForeignKey && CurrentMasterTable != "" && SameString(IdProses.CurrentValue, IdProses.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_IdAktivitas") && CurrentForm.HasValue("o_IdAktivitas") && !SameString(IdAktivitas.CurrentValue, IdAktivitas.DefaultValue) &&
            !(IdAktivitas.IsForeignKey && CurrentMasterTable != "" && SameString(IdAktivitas.CurrentValue, IdAktivitas.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_NamaDokumen") && CurrentForm.HasValue("o_NamaDokumen") && !SameString(NamaDokumen.CurrentValue, NamaDokumen.DefaultValue) &&
            !(NamaDokumen.IsForeignKey && CurrentMasterTable != "" && SameString(NamaDokumen.CurrentValue, NamaDokumen.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_UploadDokumen") && CurrentForm.HasValue("o_UploadDokumen") && !SameString(UploadDokumen.CurrentValue, UploadDokumen.DefaultValue) &&
            !(UploadDokumen.IsForeignKey && CurrentMasterTable != "" && SameString(UploadDokumen.CurrentValue, UploadDokumen.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_DownloadDokumen") && CurrentForm.HasValue("o_DownloadDokumen") && !SameString(DownloadDokumen.CurrentValue, DownloadDokumen.DefaultValue) &&
            !(DownloadDokumen.IsForeignKey && CurrentMasterTable != "" && SameString(DownloadDokumen.CurrentValue, DownloadDokumen.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_DiunggahOleh") && CurrentForm.HasValue("o_DiunggahOleh") && !SameString(DiunggahOleh.CurrentValue, DiunggahOleh.DefaultValue) &&
            !(DiunggahOleh.IsForeignKey && CurrentMasterTable != "" && SameString(DiunggahOleh.CurrentValue, DiunggahOleh.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_TanggalUpload") && CurrentForm.HasValue("o_TanggalUpload") && !SameString(FormatDateTime(TanggalUpload.CurrentValue, TanggalUpload.FormatPattern), FormatDateTime(TanggalUpload.DefaultValue, TanggalUpload.FormatPattern)) &&
            !(TanggalUpload.IsForeignKey && CurrentMasterTable != "" && SameString(FormatDateTime(TanggalUpload.CurrentValue, TanggalUpload.FormatPattern), FormatDateTime(TanggalUpload.SessionValue, TanggalUpload.FormatPattern))))
                return false;
            if (CurrentForm.HasValue("x_DiperbaruiOleh") && CurrentForm.HasValue("o_DiperbaruiOleh") && !SameString(DiperbaruiOleh.CurrentValue, DiperbaruiOleh.DefaultValue) &&
            !(DiperbaruiOleh.IsForeignKey && CurrentMasterTable != "" && SameString(DiperbaruiOleh.CurrentValue, DiperbaruiOleh.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_TanggalDiperbarui") && CurrentForm.HasValue("o_TanggalDiperbarui") && !SameString(FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern), FormatDateTime(TanggalDiperbarui.DefaultValue, TanggalDiperbarui.FormatPattern)) &&
            !(TanggalDiperbarui.IsForeignKey && CurrentMasterTable != "" && SameString(FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern), FormatDateTime(TanggalDiperbarui.SessionValue, TanggalDiperbarui.FormatPattern))))
                return false;
            if (CurrentForm.HasValue("x_WajibUpload") && CurrentForm.HasValue("o_WajibUpload") && ConvertToBool(WajibUpload.CurrentValue) != ConvertToBool(WajibUpload.DefaultValue) &&
            !(WajibUpload.IsForeignKey && CurrentMasterTable != "" && ConvertToBool(WajibUpload.CurrentValue) == ConvertToBool(WajibUpload.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_TipeProses") && CurrentForm.HasValue("o_TipeProses") && !SameString(TipeProses.CurrentValue, TipeProses.DefaultValue) &&
            !(TipeProses.IsForeignKey && CurrentMasterTable != "" && SameString(TipeProses.CurrentValue, TipeProses.SessionValue)))
                return false;
            return true;
        }

        // Validate grid form
        public async Task<bool> ValidateGridForm()
        {
            // Get row count
            CurrentForm?.ResetIndex();
            int rowcnt = CurrentForm?.GetInt(FormKeyCountName) ?? 0;

            // Load default values for emptyRow checking
            LoadDefaultValues();

            // Validate all records
            for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                // Load current row values
                CurrentForm!.Index = rowindex;
                string rowaction = CurrentForm.GetValue(FormActionName);
                if (rowaction != "delete" && rowaction != "insertdelete" && rowaction != "hide") {
                    await LoadFormValues(); // Get form values
                    if (rowaction == "insert" && EmptyRow()) {
                        // Ignore
                    } else if (!await ValidateForm()) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Get all form values of the grid
        public List<Dictionary<string, string?>> GetGridFormValues()
        {
            // Get row count
            CurrentForm?.ResetIndex();
            int rowcnt = CurrentForm?.GetInt(FormKeyCountName) ?? 0;
            List<Dictionary<string, string?>> rows = new();

            // Loop through all records
            for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                // Load current row values
                CurrentForm!.Index = rowindex;
                string rowaction = CurrentForm.GetValue(FormActionName);
                if (rowaction != "delete" && rowaction != "insertdelete") {
                    LoadFormValues().GetAwaiter().GetResult(); // Load form values (sync)
                    if (rowaction == "insert" && EmptyRow()) {
                        // Ignore
                    } else {
                        rows.Add(GetFormValues()); // Return row as array
                    }
                }
            }
            return rows; // Return as array of array
        }

        // Restore form values for current row
        public async Task RestoreCurrentRowFormValues(object index)
        {
            // Get row based on current index
            if (index is int idx)
                CurrentForm!.Index = idx;
            string rowaction = CurrentForm.GetValue(FormActionName);
            await LoadFormValues(); // Load form values
            // Set up invalid status correctly
            ResetFormError();
            if (rowaction == "insert" && EmptyRow()) {
                // Ignore
            } else {
                await ValidateForm();
            }
        }

        // Reset form status
        public void ResetFormError()
        {
            NoReferensi.ClearErrorMessage();
            IdProses.ClearErrorMessage();
            IdAktivitas.ClearErrorMessage();
            NamaDokumen.ClearErrorMessage();
            UploadDokumen.ClearErrorMessage();
            DownloadDokumen.ClearErrorMessage();
            DiunggahOleh.ClearErrorMessage();
            TanggalUpload.ClearErrorMessage();
            DiperbaruiOleh.ClearErrorMessage();
            TanggalDiperbarui.ClearErrorMessage();
            WajibUpload.ClearErrorMessage();
            TipeProses.ClearErrorMessage();
        }

        // Set up sort parameters
        protected void SetupSortOrder() {
            // Load default Sorting Order
            if (Command != "json") {
                string defaultSort = ""; // Set up default sort
                if (Empty(SessionOrderBy) && !Empty(defaultSort))
                    SessionOrderBy = defaultSort;
            }

            // Check for "order" parameter
            if (Get("order", out StringValues sv)) {
                CurrentOrder = sv.ToString();
                CurrentOrderType = Get("ordertype");
                StartRecordNumber = 1; // Reset start position
            }

            // Update field sort
            UpdateFieldSort();
        }

        /// <summary>
        /// Reset command
        /// cmd=reset (Reset search parameters)
        /// cmd=resetall (Reset search and master/detail parameters)
        /// cmd=resetsort (Reset sort parameters)
        /// </summary>
        protected void ResetCommand() {
            // Get reset cmd
            if (Command.ToLower().StartsWith("reset")) {
                // Reset master/detail keys
                if (SameText(Command, "resetall")) {
                    CurrentMasterTable = ""; // Clear master table
                    DbMasterFilter = "";
                    DbDetailFilter = "";
                    IdAktivitas.SessionValue = "";
                }

                // Reset (clear) sorting order
                if (SameText(Command, "resetsort")) {
                    string orderBy = "";
                    SessionOrderBy = orderBy;
                }

                // Reset start position
                StartRecord = 1;
                StartRecordNumber = StartRecord;
            }
        }

        #pragma warning disable 1998
        // Set up list options
        protected async Task SetupListOptions() {
            ListOption item;

            // "griddelete"
            if (AllowAddDeleteRow) {
                item = ListOptions.Add("griddelete");
                item.CssClass = "text-nowrap";
                item.OnLeft = true;
                item.Visible = false; // Default hidden
            }

            // Add group option item
            item = ListOptions.AddGroupOption();
            item.Body = "";
            item.OnLeft = true;
            item.Visible = false;

            // "view"
            item = ListOptions.Add("view");
            item.CssClass = "text-nowrap";
            item.Visible = Security.CanView;
            item.OnLeft = true;

            // "sequence"
            item = ListOptions.Add("sequence");
            item.CssClass = "text-nowrap";
            item.Visible = true;
            item.OnLeft = true; // Always on left
            item.ShowInDropDown = false;
            item.ShowInButtonGroup = false;

            // Drop down button for ListOptions
            ListOptions.UseDropDownButton = true;
            ListOptions.DropDownButtonPhrase = "ButtonListOptions";
            ListOptions.UseButtonGroup = false;
            if (ListOptions.UseButtonGroup && IsMobile())
                ListOptions.UseDropDownButton = true;

            //ListOptions.ButtonClass = ""; // Class for button group
            ListOptions[ListOptions.GroupOptionName]?.SetVisible(ListOptions.GroupOptionVisible);
        }
        #pragma warning restore 1998

        // Set up list options (extensions)
        protected void SetupListOptionsExt() {
            // Set up list options (to be implemented by extensions)
        }

        // Add "hash" parameter to URL
        public string UrlAddHash(string url, string hash)
        {
            return UseAjaxActions ? url : UrlAddQuery(url, "hash=" + hash);
        }

        // Render list options
        #pragma warning disable 168, 219, 1998

        public async Task RenderListOptions()
        {
            ListOption? listOption;
            bool isVisible = false; // DN
            ListOptions.LoadDefault();

            // Call ListOptions Rendering event
            ListOptionsRendering();

            // Set up row action and key
            if (IsNumeric(RowIndex) && RowType != RowType.View) {
                CurrentForm!.Index = ConvertToInt(RowIndex);
                var actionName = FormActionName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                var oldKeyName = OldKeyName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                var blankRowName = FormBlankRowName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                if (!Empty(RowAction))
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + actionName + "\" id=\"" + actionName + "\" value=\"" + RowAction + "\">";
                string oldKey = GetKey(false); // Get from OldValue
                if (!Empty(oldKeyName) && !Empty(oldKey)) {
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + oldKeyName + "\" id=\"" + oldKeyName + "\" value=\"" + HtmlEncode(oldKey) + "\">";
                }
                if (RowAction == "insert" && IsConfirm && EmptyRow())
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + blankRowName + "\" id=\"" + blankRowName + "\" value=\"1\">";
            }

            // "delete"
            if (AllowAddDeleteRow) {
                if (CurrentMode == "add" || CurrentMode == "copy" || CurrentMode == "edit") {
                    var options = ListOptions;
                    options.UseButtonGroup = true; // Use button group for grid delete button
                    listOption = options["griddelete"];
                    if (IsNumeric(RowIndex) && (RowAction == "" || RowAction == "edit")) { // Do not allow delete existing record
                        listOption?.SetBody("&nbsp;");
                    } else {
                        listOption?.SetBody("<a class=\"ew-grid-link ew-grid-delete\" title=\"" + Language.Phrase("DeleteLink", true) + "\" data-caption=\"" + Language.Phrase("DeleteLink", true) + "\" data-ew-action=\"delete-grid-row\" data-rowindex=\"" + RowIndex + "\">" + Language.Phrase("DeleteLink") + "</a>");
                    }
                }
            }

            // "sequence"
            listOption = ListOptions["sequence"];
            listOption?.SetBody(FormatSequenceNumber(RecordCount));
            if (CurrentMode == "view") {
            // "view"
            listOption = ListOptions["view"];
            string viewcaption = Language.Phrase("ViewLink", true);
            isVisible = Security.CanView;
            if (isVisible) {
                if (ModalView && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-table=""AktivitasDokumen"" data-caption=""{viewcaption}"" data-ew-action=""modal"" data-action=""view"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(ViewUrl)) + "\" data-btn=\"null\">" + Language.Phrase("ViewLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-caption=""{viewcaption}"" href=""" + HtmlEncode(AppPath(ViewUrl)) + "\">" + Language.Phrase("ViewLink") + "</a>");
            } else {
                listOption?.Clear();
            }
            } // End View mode
            RenderListOptionsExt();

            // Call ListOptions Rendered event
            ListOptionsRendered();
        }

        // Render list options (extensions)
        protected void RenderListOptionsExt() {
            // Render list options (to be implemented by extensions)
        }

        // Set up other options
        protected void SetupOtherOptions() {
            ListOptions option;
            ListOption item;
            option = OtherOptions["addedit"];
            option.UseDropDownButton = false;
            option.DropDownButtonPhrase = "ButtonAddEdit";
            option.UseButtonGroup = true;
            option.ButtonClass = ""; // Class for button group
            item = option.AddGroupOption();
            item.Body = "";
            item.Visible = false;
        }

        // Active user filter
        // - Get active users by SQL (SELECT COUNT(*) FROM UserTable WHERE ProfileField LIKE '%"SessionID":%')
        private string ActiveUserFilter()
        {
            if (UserProfile.IsForceLogoutUser) {
                var userProfileField = Fields[Config.UserProfileFieldName];
                return userProfileField.Expression + " LIKE '%\"" + UserProfile.SessionId + "\":%'";
            }
            return "0=1"; // No active users
        }

        // Create new column option // DN
        public void CreateColumnOption(ListOption item)
        {
            var field = FieldByName(item.Name);
            if (field?.Visible ?? false) {
                item.Body = "<button class=\"dropdown-item\">" +
                    "<div class=\"form-check ew-dropdown-checkbox\">" +
                    "<div class=\"form-check-input ew-dropdown-check-input\" data-field=\"" + field.Param + "\"></div>" +
                    "<label class=\"form-check-label ew-dropdown-check-label\">" + field.Caption + "</label></div></button>";
            }
        }

        // Render other options
        public void RenderOtherOptions()
        {
            ListOptions option;
            ListOption? item;
            var options = OtherOptions;
                if ((CurrentMode == "add" || CurrentMode == "copy" || CurrentMode == "edit") && !IsConfirm) { // Check add/copy/edit mode
                    if (AllowAddDeleteRow) {
                        option = options["addedit"];
                        option.UseDropDownButton = false;
                        item = option.Add("addblankrow");
                        item.Body = "<a class=\"ew-add-edit ew-add-blank-row\" title=\"" + Language.Phrase("AddBlankRow", true) + "\" data-caption=\"" + Language.Phrase("AddBlankRow", true) + "\" data-ew-action=\"add-grid-row\">" + Language.Phrase("AddBlankRow") + "</a>";
                        item.Visible = false;
                        ShowOtherOptions = item.Visible;
                    }
                }
                if (CurrentMode == "view") { // Check view mode
                    option = options["addedit"];
                    item = option.GetItem("add");
                    ShowOtherOptions = !Empty(item) && item.Visible;
                }
        }

        // Set up Grid
        public async Task SetupGrid()
        {
            SetupRecordRange();
            await HandleFormKeyCount();
            await HandleRecordset();
            await SetupAggregateAndInlineOperations();
        }

        private void SetupRecordRange()
        {
            StartRecord = 1;
            StopRecord = TotalRecords; // Show all records
        }

        private async Task HandleFormKeyCount()
        {
            // Restore number of post back records
            if (CurrentForm != null && (IsConfirm || EventCancelled)) {
                CurrentForm!.ResetIndex(); // DN
                if (CurrentForm!.HasValue(FormKeyCountName) && (IsGridAdd || IsGridEdit || IsConfirm)) {
                    KeyCount = CurrentForm.GetInt(FormKeyCountName);
                    StopRecord = StartRecord + KeyCount - 1;
                }
            }
        }

        private async Task HandleRecordset()
        {
            if (Recordset != null && Recordset.HasRows) {
                await HandleExistingRecordset();
            } else {
                HandleEmptyRecordset();
            }
        }

        private async Task HandleExistingRecordset()
        {
            if (!Connection.SelectOffset) { // DN
                for (int i = 1; i <= StartRecord - 1; i++) { // Move to first record
                    if (await Recordset.ReadAsync())
                        RecordCount++;
                }
            } else {
                RecordCount = StartRecord - 1;
            }
        }

        private void HandleEmptyRecordset()
        {
            if (IsGridAdd && !AllowAddDeleteRow && StopRecord == 0) { // Grid-Add with no records
                StopRecord = GridAddRowCount;
            } else if (IsAdd && TotalRecords == 0) { // Inline-Add with no records
                StopRecord = 1;
            }
        }

        private async Task SetupAggregateAndInlineOperations()
        {
            // Initialize aggregate
            RowType = RowType.AggregateInit;
            ResetAttributes();
            await RenderRow();
            SetupInlineOperations();
            SetupGridOperations();
        }

        private void SetupInlineOperations()
        {
            // If empty, means all conditions are not fulfilled
        }

        private void SetupGridOperations()
        {
            if ((IsGridAdd || IsGridEdit)) // Render template row first
                RowIndex = "$rowindex$";
        }

        // Set up Row
        public async Task SetupRow()
        {
            // Handle template row for grid operations
            if (await HandleTemplateRow())
                return;

            // Setup form and row index
            SetupFormAndRowIndex();

            // Initialize row attributes
            InitializeRowAttributes();

            // Load row data based on context
            await LoadRowData();

            // Setup row type and actions
            SetupRowTypeAndActions();

            // Handle edit mode specific setup
            await HandleEditModeSetup();

            // Handle form restoration on errors
            await HandleFormRestoration();

            // Setup row counts and final attributes
            SetupRowCountsAndAttributes();

            // Render row and options
            await RenderRowAndOptions();
        }

        private async Task<bool> HandleTemplateRow()
        {
            if ((IsGridAdd || IsGridEdit) && SameString(RowIndex, "$rowindex$")) { // Render template row first
                await LoadRowValues();

                // Set row properties
                ResetAttributes();
                RowAttrs.Add("data-rowindex", ConvertToString(RowIndex));
                RowAttrs.Add("id", "r0_AktivitasDokumen");
                RowAttrs.Add("data-rowtype", ConvertToString((int)RowType.Add));
                RowAttrs.Add("data-inline", (IsAdd || IsCopy || IsEdit) ? "true" : "false");
                RowAttrs.AppendClass("ew-template");

                // Render row
                RowType = RowType.Add;
                await RenderRow();

                // Render list options
                await RenderListOptions();

                // Reset record count for template row
                RecordCount--;
                return true; // Exit early
            }
            return false;
        }

        private void SetupFormAndRowIndex()
        {
            // If empty, means all conditions are not 
            if (CurrentForm != null && (IsGridAdd || IsGridEdit || IsConfirm || IsMultiEdit)) {
                RowIndex = ConvertToInt(RowIndex) + 1;
                CurrentForm!.SetIndex(ConvertToInt(RowIndex));
                if (CurrentForm!.HasValue(FormActionName) && (IsConfirm || EventCancelled))
                    RowAction = CurrentForm.GetValue(FormActionName);
                else if (IsGridAdd)
                    RowAction = "insert";
                else
                    RowAction = "";
            }
        }

        private void InitializeRowAttributes()
        {
            // Set up key count
            KeyCount = ConvertToInt(RowIndex);

            // Init row class and style
            ResetAttributes();
            CssClass = "";
        }

        private async Task LoadRowData()
        {
            await LoadRowDataForGrid();
        }

        private async Task LoadRowDataForGrid()
        {
            if (IsGridAdd) {
                if (CurrentMode == "copy") {
                    await LoadRowValues(Recordset); // Load row values
                    OldKey = GetKey(true); // Get from CurrentValue
                } else {
                    await LoadRowValues(); // Load default values
                    OldKey = "";
                }
            } else {
                await LoadRowValues(Recordset); // Load row values
                OldKey = GetKey(true); // Get from CurrentValue
            }
            SetKey(OldKey);
        }

        private async Task LoadRowDataForList()
        {
            if (IsCopy && InlineRowCount == 0 && !await LoadRow()) { // Inline copy
                CurrentAction = "add";
            }
            if (IsAdd && InlineRowCount == 0 || IsGridAdd) {
                await LoadRowValues(); // Load default values
                OldKey = "";
                SetKey(OldKey);
            } else if (IsInlineInserted && UseInfiniteScroll) {
                // Nothing to do, just use current values
            } else if (!(IsCopy && InlineRowCount == 0)) {
                await LoadRowValues(Recordset); // Load row values
                if (IsGridEdit || IsMultiEdit) {
                    OldKey = GetKey(true); // Get from CurrentValue
                    SetKey(OldKey);
                }
            }
        }

        private void SetupRowTypeAndActions()
        {
            RowType = RowType.View; // Render view
            if ((IsAdd || IsCopy) && InlineRowCount == 0 || IsGridAdd) // Add
                RowType = RowType.Add; // Render add
        }

        private async Task HandleEditModeSetup()
        {
            // If empty, means all conditions are not 
            if (IsGridAdd && EventCancelled && !CurrentForm!.HasValue(FormBlankRowName)) // Insert failed
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values
            await HandleInlineEditSetup();
            await HandleGridEditSetup();
            await HandleMultiEditSetup();
        }

        private async Task HandleInlineEditSetup()
        {
        }

        private async Task HandleGridEditSetup()
        {
            if (IsGridEdit) { // Grid edit
                if (EventCancelled)
                    await RestoreCurrentRowFormValues(RowIndex); // Restore form values
                if (RowAction == "insert")
                    RowType = RowType.Add; // Render add
                else
                    RowType = RowType.Edit; // Render edit
            }
        }

        private async Task HandleMultiEditSetup()
        {
        }

        private async Task HandleFormRestoration()
        {
            // If empty, means all conditions are not 
            if (IsGridEdit && (RowType == RowType.Edit || RowType == RowType.Add) && EventCancelled) // Update failed
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values
            if (IsConfirm) // Confirm row
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values
        }

        private void SetupRowCountsAndAttributes()
        {
            // Inline Add/Copy row (row 0)
            if (RowType == RowType.Add && (IsAdd || IsCopy)) {
                InlineRowCount++;
                RecordCount--; // Reset record count for inline add/copy row
                if (TotalRecords == 0) // Reset stop record if no records
                    StopRecord = 0;
            } else {
                // Inline Edit row
                if (RowType == RowType.Edit && IsEdit)
                    InlineRowCount++;
                RowCount++; // Increment row count
            }

            // Set up row attributes
            RowAttrs.Add("data-rowindex", ConvertToString(aktivitasDokumenGrid.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(aktivitasDokumenGrid.RowCount) + "_AktivitasDokumen");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(aktivitasDokumenGrid.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && aktivitasDokumenGrid.RowType == RowType.Add || IsEdit && aktivitasDokumenGrid.RowType == RowType.Edit) // Inline-Add/Edit row
                RowAttrs.AppendClass("table-active");
        }

        private async Task RenderRowAndOptions()
        {
            // Render row
            await RenderRow();

            // Render list options
            await RenderListOptions();
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
        var listwrk = fld.Lookup?.RenderViewRow(rswrk?[0]);
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
            PathFile.Upload.Index = ConvertToInt(RowIndex);
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
            CurrentForm.FormName = FormName;
            bool validate = !Config.ServerValidate;

            // Standard handling for 'NoReferensi'
            NoReferensi.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NoReferensi, "NoReferensi", "x_NoReferensi");
            if (CurrentForm.HasValue("o_NoReferensi"))
                NoReferensi.OldValue = CurrentForm.GetValue("o_NoReferensi");

            // Standard handling for 'IdProses'
            IdProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdProses, "IdProses", "x_IdProses", true, validate, false);
            if (CurrentForm.HasValue("o_IdProses"))
                IdProses.OldValue = CurrentForm.GetValue("o_IdProses");

            // Standard handling for 'IdAktivitas'
            IdAktivitas.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(IdAktivitas, "IdAktivitas", "x_IdAktivitas");
            if (CurrentForm.HasValue("o_IdAktivitas"))
                IdAktivitas.OldValue = CurrentForm.GetValue("o_IdAktivitas");

            // Standard handling for 'NamaDokumen'
            NamaDokumen.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(NamaDokumen, "NamaDokumen", "x_NamaDokumen");
            if (CurrentForm.HasValue("o_NamaDokumen"))
                NamaDokumen.OldValue = CurrentForm.GetValue("o_NamaDokumen");

            // Standard handling for 'UploadDokumen'
            UploadDokumen.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(UploadDokumen, "UploadDokumen", "x_UploadDokumen");
            if (CurrentForm.HasValue("o_UploadDokumen"))
                UploadDokumen.OldValue = CurrentForm.GetValue("o_UploadDokumen");

            // Standard handling for 'DownloadDokumen'
            DownloadDokumen.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(DownloadDokumen, "DownloadDokumen", "x_DownloadDokumen");
            if (CurrentForm.HasValue("o_DownloadDokumen"))
                DownloadDokumen.OldValue = CurrentForm.GetValue("o_DownloadDokumen");

            // Standard handling for 'DiunggahOleh'
            DiunggahOleh.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(DiunggahOleh, "DiunggahOleh", "x_DiunggahOleh");
            if (CurrentForm.HasValue("o_DiunggahOleh"))
                DiunggahOleh.OldValue = CurrentForm.GetValue("o_DiunggahOleh");

            // Standard handling for 'TanggalUpload'
            TanggalUpload.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalUpload, "TanggalUpload", "x_TanggalUpload", true, validate, true);
            TanggalUpload.OldValue = UnformatDateTime(CurrentForm.GetValue("o_TanggalUpload"), TanggalUpload.FormatPattern);

            // Standard handling for 'DiperbaruiOleh'
            DiperbaruiOleh.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(DiperbaruiOleh, "DiperbaruiOleh", "x_DiperbaruiOleh");
            if (CurrentForm.HasValue("o_DiperbaruiOleh"))
                DiperbaruiOleh.OldValue = CurrentForm.GetValue("o_DiperbaruiOleh");

            // Standard handling for 'TanggalDiperbarui'
            TanggalDiperbarui.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TanggalDiperbarui, "TanggalDiperbarui", "x_TanggalDiperbarui", true, validate, true);
            TanggalDiperbarui.OldValue = UnformatDateTime(CurrentForm.GetValue("o_TanggalDiperbarui"), TanggalDiperbarui.FormatPattern);

            // Standard handling for 'WajibUpload'
            WajibUpload.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(WajibUpload, "WajibUpload", "x_WajibUpload");
            if (CurrentForm.HasValue("o_WajibUpload"))
                WajibUpload.OldValue = CurrentForm.GetValue("o_WajibUpload");

            // Standard handling for 'TipeProses'
            TipeProses.MultiUpdate = string.Empty; // initialize (will be set later for update control if needed)
            SetNormalField(TipeProses, "TipeProses", "x_TipeProses");
            if (CurrentForm.HasValue("o_TipeProses"))
                TipeProses.OldValue = CurrentForm.GetValue("o_TipeProses");
            if (!IdAktivitasDokumen.IsDetailKey && !IsGridAdd && !IsAdd) {
                SetNormalField(IdAktivitasDokumen, "IdAktivitasDokumen", "x_IdAktivitasDokumen");
            }
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            if (!IsGridAdd && !IsAdd)
                IdAktivitasDokumen.CurrentValue = IdAktivitasDokumen.FormValue;
            NoReferensi.CurrentValue = NoReferensi.FormValue;
            IdProses.CurrentValue = IdProses.FormValue;
            IdAktivitas.CurrentValue = IdAktivitas.FormValue;
            NamaDokumen.CurrentValue = NamaDokumen.FormValue;
            UploadDokumen.CurrentValue = UploadDokumen.FormValue;
            DownloadDokumen.CurrentValue = DownloadDokumen.FormValue;
            DiunggahOleh.CurrentValue = DiunggahOleh.FormValue;
            TanggalUpload.CurrentValue = TanggalUpload.FormValue;
            TanggalUpload.CurrentValue = UnformatDateTime(TanggalUpload.CurrentValue, TanggalUpload.FormatPattern);
            DiperbaruiOleh.CurrentValue = DiperbaruiOleh.FormValue;
            TanggalDiperbarui.CurrentValue = TanggalDiperbarui.FormValue;
            TanggalDiperbarui.CurrentValue = UnformatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
            WajibUpload.CurrentValue = WajibUpload.FormValue;
            TipeProses.CurrentValue = TipeProses.FormValue;
        }

        // Load recordset // DN
        public async Task<DbDataReader?> LoadRecordset(int offset = -1, int rowcnt = -1)
        {
            // Load list page SQL
            string sql = ListSql;

            // Load recordset // DN
            var dr = await Connection.ExecuteReaderAsync(Connection.SelectLimitSql(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy)));

            // Call Recordset Selected event
            RecordsetSelected(dr);
            return dr;
        }

        // Load rows // DN
        public async Task<List<Dictionary<string, object>>> LoadRows(int offset = -1, int rowcnt = -1)
        {
            // Load list page SQL
            string sql = ListSql;

            // Load rows // DN
            return await Connection.GetRowsAsync(Connection.SelectLimitSql(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy)));
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
            IdAktivitasDokumen.SetDbValue(row["IdAktivitasDokumen"]);
            NoReferensi.SetDbValue(row["NoReferensi"]);
            IdProses.SetDbValue(row["IdProses"]);
            IdAktivitas.SetDbValue(row["IdAktivitas"]);
            IdDokumen.SetDbValue(row["IdDokumen"]);
            NamaDokumen.SetDbValue(row["NamaDokumen"]);
            TemplateDokumen.SetDbValue(row["TemplateDokumen"]);
            UploadDokumen.SetDbValue(row["UploadDokumen"]);
            DownloadDokumen.SetDbValue(row["DownloadDokumen"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            PathFile.Upload.DbValue = row["PathFile"];
            PathFile.SetDbValue(PathFile.Upload.DbValue);
            PathFile.Upload.Index = ConvertToInt(RowIndex);
            StatusUpload.SetDbValue(row["StatusUpload"]);
            DiunggahOleh.SetDbValue(row["DiunggahOleh"]);
            TanggalUpload.SetDbValue(row["TanggalUpload"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            IdTemplateAktivitasDokumen.SetDbValue(row["IdTemplateAktivitasDokumen"]);
            WajibUpload.SetDbValue((ConvertToBool(row["WajibUpload"]) ? "1" : "0"));
            TipeProses.SetDbValue(row["TipeProses"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("IdAktivitasDokumen", IdAktivitasDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("NoReferensi", NoReferensi.DefaultValue ?? DbNullValue); // DN
            row.Add("IdProses", IdProses.DefaultValue ?? DbNullValue); // DN
            row.Add("IdAktivitas", IdAktivitas.DefaultValue ?? DbNullValue); // DN
            row.Add("IdDokumen", IdDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("NamaDokumen", NamaDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("TemplateDokumen", TemplateDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("UploadDokumen", UploadDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("DownloadDokumen", DownloadDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("PathFile", PathFile.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusUpload", StatusUpload.DefaultValue ?? DbNullValue); // DN
            row.Add("DiunggahOleh", DiunggahOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalUpload", TanggalUpload.DefaultValue ?? DbNullValue); // DN
            row.Add("DiperbaruiOleh", DiperbaruiOleh.DefaultValue ?? DbNullValue); // DN
            row.Add("TanggalDiperbarui", TanggalDiperbarui.DefaultValue ?? DbNullValue); // DN
            row.Add("IdTemplateAktivitasDokumen", IdTemplateAktivitasDokumen.DefaultValue ?? DbNullValue); // DN
            row.Add("WajibUpload", WajibUpload.DefaultValue ?? DbNullValue); // DN
            row.Add("TipeProses", TipeProses.DefaultValue ?? DbNullValue); // DN
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

            // IdAktivitasDokumen

            // NoReferensi

            // IdProses

            // IdAktivitas

            // IdDokumen

            // NamaDokumen

            // TemplateDokumen

            // UploadDokumen

            // DownloadDokumen

            // Keterangan

            // PathFile

            // StatusUpload

            // DiunggahOleh

            // TanggalUpload

            // DiperbaruiOleh

            // TanggalDiperbarui

            // IdTemplateAktivitasDokumen

            // WajibUpload

            // TipeProses

            // View row
            if (RowType == RowType.View) {
                // NoReferensi

                // IdProses

                // IdAktivitas

                // IdDokumen

                // NamaDokumen

                // TemplateDokumen

                // UploadDokumen

                // DownloadDokumen

                // StatusUpload

                // DiunggahOleh

                // TanggalUpload

                // DiperbaruiOleh

                // TanggalDiperbarui

                // IdTemplateAktivitasDokumen

                // WajibUpload

                // TipeProses

                    // IdAktivitasDokumen
                    IdAktivitasDokumen.ViewValue = IdAktivitasDokumen.CurrentValue;
                    IdAktivitasDokumen.ViewCustomAttributes = "";

                    // NoReferensi
                    NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
                    NoReferensi.ViewCustomAttributes = "";

                    // IdProses
                    IdProses.ViewValue = IdProses.CurrentValue;

                    // awallookupbung
                    // IdProses
                    ResolveLookupView(IdProses, "IdProses", "number");
                    // akhirlookupbung
                    IdProses.ViewCustomAttributes = "";

                    // IdAktivitas

                    // awallookupbung
                    // IdAktivitas
                    ResolveLookupView(IdAktivitas, "IdAktivitas", "number");
                    // akhirlookupbung
                    IdAktivitas.ViewCustomAttributes = "";

                    // IdDokumen

                    // awallookupbung
                    // IdDokumen
                    ResolveLookupView(IdDokumen, "IdDokumen", "number");
                    // akhirlookupbung
                    IdDokumen.ViewCustomAttributes = "";

                    // NamaDokumen
                    NamaDokumen.ViewValue = ConvertToString(NamaDokumen.CurrentValue); // DN
                    NamaDokumen.ViewCustomAttributes = "";

                    // TemplateDokumen
                    TemplateDokumen.ViewValue = ConvertToString(TemplateDokumen.CurrentValue); // DN
                    TemplateDokumen.ViewCustomAttributes = "";

                    // UploadDokumen
                    UploadDokumen.ViewValue = UploadDokumen.CurrentValue;
                    UploadDokumen.ViewCustomAttributes = "";

                    // DownloadDokumen
                    DownloadDokumen.ViewValue = DownloadDokumen.CurrentValue;
                    DownloadDokumen.ViewCustomAttributes = "";

                    // StatusUpload
                    StatusUpload.ViewValue = ConvertToString(StatusUpload.CurrentValue); // DN
                    StatusUpload.ViewCustomAttributes = "";

                    // DiunggahOleh
                    DiunggahOleh.ViewValue = ConvertToString(DiunggahOleh.CurrentValue); // DN
                    DiunggahOleh.ViewCustomAttributes = "";

                    // TanggalUpload
                    TanggalUpload.ViewValue = TanggalUpload.CurrentValue;
                    TanggalUpload.ViewValue = FormatDateTime(TanggalUpload.ViewValue, TanggalUpload.FormatPattern);
                    TanggalUpload.ViewCustomAttributes = "";

                    // DiperbaruiOleh
                    DiperbaruiOleh.ViewValue = ConvertToString(DiperbaruiOleh.CurrentValue); // DN
                    DiperbaruiOleh.ViewCustomAttributes = "";

                    // TanggalDiperbarui
                    TanggalDiperbarui.ViewValue = TanggalDiperbarui.CurrentValue;
                    TanggalDiperbarui.ViewValue = FormatDateTime(TanggalDiperbarui.ViewValue, TanggalDiperbarui.FormatPattern);
                    TanggalDiperbarui.ViewCustomAttributes = "";

                    // IdTemplateAktivitasDokumen
                    IdTemplateAktivitasDokumen.ViewValue = IdTemplateAktivitasDokumen.CurrentValue;
                    IdTemplateAktivitasDokumen.ViewValue = FormatNumber(IdTemplateAktivitasDokumen.ViewValue, IdTemplateAktivitasDokumen.FormatPattern);
                    IdTemplateAktivitasDokumen.ViewCustomAttributes = "";

                    // WajibUpload
                    if (ConvertToBool(WajibUpload.CurrentValue)) {
                        WajibUpload.ViewValue = WajibUpload.TagCaption(1) != "" ? WajibUpload.TagCaption(1) : "Yes";
                    } else {
                        WajibUpload.ViewValue = WajibUpload.TagCaption(2) != "" ? WajibUpload.TagCaption(2) : "No";
                    }
                    WajibUpload.ViewCustomAttributes = "";

                    // TipeProses
                    TipeProses.ViewValue = ConvertToString(TipeProses.CurrentValue); // DN
                    TipeProses.ViewCustomAttributes = "";

                // NoReferensi
                NoReferensi.HrefValue = "";
                NoReferensi.TooltipValue = "";

                // IdProses
                IdProses.HrefValue = "";
                IdProses.TooltipValue = "";

                // IdAktivitas
                IdAktivitas.HrefValue = "";
                IdAktivitas.TooltipValue = "";

                // NamaDokumen
                NamaDokumen.HrefValue = "";
                NamaDokumen.TooltipValue = "";

                // UploadDokumen
                UploadDokumen.HrefValue = "";
                UploadDokumen.TooltipValue = "";

                // DownloadDokumen
                DownloadDokumen.HrefValue = "";
                DownloadDokumen.TooltipValue = "";

                // DiunggahOleh
                DiunggahOleh.HrefValue = "";
                DiunggahOleh.TooltipValue = "";

                // TanggalUpload
                TanggalUpload.HrefValue = "";
                TanggalUpload.TooltipValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";
                DiperbaruiOleh.TooltipValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
                TanggalDiperbarui.TooltipValue = "";

                // WajibUpload
                WajibUpload.HrefValue = "";
                WajibUpload.TooltipValue = "";

                // TipeProses
                TipeProses.HrefValue = "";
                TipeProses.TooltipValue = "";
            } else if (RowType == RowType.Add) {
                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // IdProses
                IdProses.SetupEditAttributes();
                IdProses.EditValue = IdProses.CurrentValue;

                // awallookupbung
                string curVal = ConvertToString(IdProses.CurrentValue);
                IdProses.EditValue = Empty(curVal) ? DbNullValue : HtmlEncode(FormatNumber(IdProses.CurrentValue, IdProses.FormatPattern));
                if (!Empty(curVal)) {
                    if (IdProses.Lookup != null && IsDictionary(IdProses.Lookup?.Options) && IdProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdProses.EditValue = IdProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", IdProses.CurrentValue, IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk = IdProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdProses.Lookup != null) { // Lookup values found
                            var listwrk = IdProses.Lookup?.RenderViewRow(rswrk[0]);
                            IdProses.EditValue = IdProses.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                IdProses.PlaceHolder = RemoveHtml(IdProses.Caption);
                if (!Empty(IdProses.EditValue) && IsNumeric(IdProses.EditValue)) {
                    IdProses.EditValue = FormatNumber(IdProses.EditValue, null);
                }

                // IdAktivitas
                IdAktivitas.SetupEditAttributes();
                if (!Empty(IdAktivitas.SessionValue)) {
                    IdAktivitas.CurrentValue = ForeignKeyValue(IdAktivitas.SessionValue);
                    IdAktivitas.OldValue = IdAktivitas.CurrentValue;

                    // awallookupbung
                    string curVal2 = ConvertToString(IdAktivitas.CurrentValue);
                    IdAktivitas.ViewValue = Empty(curVal2) ? DbNullValue : FormatNumber(IdAktivitas.CurrentValue, IdAktivitas.FormatPattern);
                    if (!Empty(curVal2)) {
                        if (IdAktivitas.Lookup != null && IsDictionary(IdAktivitas.Lookup?.Options) && IdAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            IdAktivitas.ViewValue = IdAktivitas.LookupCacheOption(curVal2);
                        } else { // Lookup from database // DN
                            string filterWrk2 = SearchFilter(IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", IdAktivitas.CurrentValue, IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                            string? sqlWrk2 = IdAktivitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                            List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk2?.Count > 0 && IdAktivitas.Lookup != null) { // Lookup values found
                                var listwrk = IdAktivitas.Lookup?.RenderViewRow(rswrk2[0]);
                                IdAktivitas.ViewValue = IdAktivitas.DisplayValue(listwrk);
                            }
                        }
                    }

                    // akhirlookupbung
                    IdAktivitas.ViewCustomAttributes = "";
                } else {
                    string curVal2 = ConvertToString(IdAktivitas.CurrentValue);
                    if (IdAktivitas.Lookup != null && IsDictionary(IdAktivitas.Lookup?.Options) && IdAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdAktivitas.EditValue = IdAktivitas.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        string filterWrk2 = "";
                        if (curVal2 == "") {
                            filterWrk2 = "0=1";
                        } else {
                            filterWrk2 = SearchFilter(IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", IdAktivitas.CurrentValue, IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        }
                        string? sqlWrk2 = IdAktivitas.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        IdAktivitas.EditValue = rswrk2;
                    }
                    IdAktivitas.PlaceHolder = RemoveHtml(IdAktivitas.Caption);
                    if (!Empty(IdAktivitas.EditValue) && IsNumeric(IdAktivitas.EditValue))
                        IdAktivitas.EditValue = FormatNumber(IdAktivitas.EditValue, null);
                }

                // NamaDokumen
                NamaDokumen.SetupEditAttributes();
                if (!NamaDokumen.Raw)
                    NamaDokumen.CurrentValue = HtmlDecode(NamaDokumen.CurrentValue);
                NamaDokumen.EditValue = HtmlEncode(NamaDokumen.CurrentValue);
                NamaDokumen.PlaceHolder = RemoveHtml(NamaDokumen.Caption);

                // UploadDokumen
                UploadDokumen.SetupEditAttributes();
                UploadDokumen.EditValue = UploadDokumen.CurrentValue; // DN
                UploadDokumen.PlaceHolder = RemoveHtml(UploadDokumen.Caption);

                // DownloadDokumen
                DownloadDokumen.SetupEditAttributes();
                DownloadDokumen.EditValue = DownloadDokumen.CurrentValue; // DN
                DownloadDokumen.PlaceHolder = RemoveHtml(DownloadDokumen.Caption);

                // DiunggahOleh
                DiunggahOleh.SetupEditAttributes();
                if (!DiunggahOleh.Raw)
                    DiunggahOleh.CurrentValue = HtmlDecode(DiunggahOleh.CurrentValue);
                DiunggahOleh.EditValue = HtmlEncode(DiunggahOleh.CurrentValue);
                DiunggahOleh.PlaceHolder = RemoveHtml(DiunggahOleh.Caption);

                // TanggalUpload
                TanggalUpload.SetupEditAttributes();
                TanggalUpload.EditValue = FormatDateTime(TanggalUpload.CurrentValue, TanggalUpload.FormatPattern);
                TanggalUpload.PlaceHolder = RemoveHtml(TanggalUpload.Caption);

                // DiperbaruiOleh
                DiperbaruiOleh.SetupEditAttributes();
                if (!DiperbaruiOleh.Raw)
                    DiperbaruiOleh.CurrentValue = HtmlDecode(DiperbaruiOleh.CurrentValue);
                DiperbaruiOleh.EditValue = HtmlEncode(DiperbaruiOleh.CurrentValue);
                DiperbaruiOleh.PlaceHolder = RemoveHtml(DiperbaruiOleh.Caption);

                // TanggalDiperbarui
                TanggalDiperbarui.SetupEditAttributes();
                TanggalDiperbarui.EditValue = FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);

                // WajibUpload
                WajibUpload.EditValue = WajibUpload.Options(false);
                WajibUpload.PlaceHolder = RemoveHtml(WajibUpload.Caption);

                // TipeProses
                TipeProses.SetupEditAttributes();
                if (!TipeProses.Raw)
                    TipeProses.CurrentValue = HtmlDecode(TipeProses.CurrentValue);
                TipeProses.EditValue = HtmlEncode(TipeProses.CurrentValue);
                TipeProses.PlaceHolder = RemoveHtml(TipeProses.Caption);

                // Add refer script

                // NoReferensi
                NoReferensi.HrefValue = "";

                // IdProses
                IdProses.HrefValue = "";

                // IdAktivitas
                IdAktivitas.HrefValue = "";

                // NamaDokumen
                NamaDokumen.HrefValue = "";

                // UploadDokumen
                UploadDokumen.HrefValue = "";

                // DownloadDokumen
                DownloadDokumen.HrefValue = "";

                // DiunggahOleh
                DiunggahOleh.HrefValue = "";

                // TanggalUpload
                TanggalUpload.HrefValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";

                // WajibUpload
                WajibUpload.HrefValue = "";

                // TipeProses
                TipeProses.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // NoReferensi
                NoReferensi.SetupEditAttributes();
                if (!NoReferensi.Raw)
                    NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
                NoReferensi.EditValue = HtmlEncode(NoReferensi.CurrentValue);
                NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

                // IdProses
                IdProses.SetupEditAttributes();
                IdProses.EditValue = IdProses.CurrentValue;

                // awallookupbung
                string curVal = ConvertToString(IdProses.CurrentValue);
                IdProses.EditValue = Empty(curVal) ? DbNullValue : HtmlEncode(FormatNumber(IdProses.CurrentValue, IdProses.FormatPattern));
                if (!Empty(curVal)) {
                    if (IdProses.Lookup != null && IsDictionary(IdProses.Lookup?.Options) && IdProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdProses.EditValue = IdProses.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        string filterWrk = SearchFilter(IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", IdProses.CurrentValue, IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                        string? sqlWrk = IdProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && IdProses.Lookup != null) { // Lookup values found
                            var listwrk = IdProses.Lookup?.RenderViewRow(rswrk[0]);
                            IdProses.EditValue = IdProses.DisplayValue(listwrk);
                        }
                    }
                }

                // akhirlookupbung
                IdProses.PlaceHolder = RemoveHtml(IdProses.Caption);
                if (!Empty(IdProses.EditValue) && IsNumeric(IdProses.EditValue)) {
                    IdProses.EditValue = FormatNumber(IdProses.EditValue, null);
                }

                // IdAktivitas
                IdAktivitas.SetupEditAttributes();
                if (!Empty(IdAktivitas.SessionValue)) {
                    IdAktivitas.CurrentValue = ForeignKeyValue(IdAktivitas.SessionValue);
                    IdAktivitas.OldValue = IdAktivitas.CurrentValue;

                    // awallookupbung
                    string curVal2 = ConvertToString(IdAktivitas.CurrentValue);
                    IdAktivitas.ViewValue = Empty(curVal2) ? DbNullValue : FormatNumber(IdAktivitas.CurrentValue, IdAktivitas.FormatPattern);
                    if (!Empty(curVal2)) {
                        if (IdAktivitas.Lookup != null && IsDictionary(IdAktivitas.Lookup?.Options) && IdAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            IdAktivitas.ViewValue = IdAktivitas.LookupCacheOption(curVal2);
                        } else { // Lookup from database // DN
                            string filterWrk2 = SearchFilter(IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", IdAktivitas.CurrentValue, IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                            string? sqlWrk2 = IdAktivitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                            List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk2?.Count > 0 && IdAktivitas.Lookup != null) { // Lookup values found
                                var listwrk = IdAktivitas.Lookup?.RenderViewRow(rswrk2[0]);
                                IdAktivitas.ViewValue = IdAktivitas.DisplayValue(listwrk);
                            }
                        }
                    }

                    // akhirlookupbung
                    IdAktivitas.ViewCustomAttributes = "";
                } else {
                    string curVal2 = ConvertToString(IdAktivitas.CurrentValue);
                    if (IdAktivitas.Lookup != null && IsDictionary(IdAktivitas.Lookup?.Options) && IdAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        IdAktivitas.EditValue = IdAktivitas.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        string filterWrk2 = "";
                        if (curVal2 == "") {
                            filterWrk2 = "0=1";
                        } else {
                            filterWrk2 = SearchFilter(IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", IdAktivitas.CurrentValue, IdAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                        }
                        string? sqlWrk2 = IdAktivitas.Lookup?.GetSql(true, filterWrk2, null, this, false, true);
                        List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        IdAktivitas.EditValue = rswrk2;
                    }
                    IdAktivitas.PlaceHolder = RemoveHtml(IdAktivitas.Caption);
                    if (!Empty(IdAktivitas.EditValue) && IsNumeric(IdAktivitas.EditValue))
                        IdAktivitas.EditValue = FormatNumber(IdAktivitas.EditValue, null);
                }

                // NamaDokumen
                NamaDokumen.SetupEditAttributes();
                if (!NamaDokumen.Raw)
                    NamaDokumen.CurrentValue = HtmlDecode(NamaDokumen.CurrentValue);
                NamaDokumen.EditValue = HtmlEncode(NamaDokumen.CurrentValue);
                NamaDokumen.PlaceHolder = RemoveHtml(NamaDokumen.Caption);

                // UploadDokumen
                UploadDokumen.SetupEditAttributes();
                UploadDokumen.EditValue = UploadDokumen.CurrentValue; // DN
                UploadDokumen.PlaceHolder = RemoveHtml(UploadDokumen.Caption);

                // DownloadDokumen
                DownloadDokumen.SetupEditAttributes();
                DownloadDokumen.EditValue = DownloadDokumen.CurrentValue; // DN
                DownloadDokumen.PlaceHolder = RemoveHtml(DownloadDokumen.Caption);

                // DiunggahOleh
                DiunggahOleh.SetupEditAttributes();
                if (!DiunggahOleh.Raw)
                    DiunggahOleh.CurrentValue = HtmlDecode(DiunggahOleh.CurrentValue);
                DiunggahOleh.EditValue = HtmlEncode(DiunggahOleh.CurrentValue);
                DiunggahOleh.PlaceHolder = RemoveHtml(DiunggahOleh.Caption);

                // TanggalUpload
                TanggalUpload.SetupEditAttributes();
                TanggalUpload.EditValue = FormatDateTime(TanggalUpload.CurrentValue, TanggalUpload.FormatPattern);
                TanggalUpload.PlaceHolder = RemoveHtml(TanggalUpload.Caption);

                // DiperbaruiOleh
                DiperbaruiOleh.SetupEditAttributes();
                if (!DiperbaruiOleh.Raw)
                    DiperbaruiOleh.CurrentValue = HtmlDecode(DiperbaruiOleh.CurrentValue);
                DiperbaruiOleh.EditValue = HtmlEncode(DiperbaruiOleh.CurrentValue);
                DiperbaruiOleh.PlaceHolder = RemoveHtml(DiperbaruiOleh.Caption);

                // TanggalDiperbarui
                TanggalDiperbarui.SetupEditAttributes();
                TanggalDiperbarui.EditValue = FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
                TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);

                // WajibUpload
                WajibUpload.EditValue = WajibUpload.Options(false);
                WajibUpload.PlaceHolder = RemoveHtml(WajibUpload.Caption);

                // TipeProses
                TipeProses.SetupEditAttributes();
                if (!TipeProses.Raw)
                    TipeProses.CurrentValue = HtmlDecode(TipeProses.CurrentValue);
                TipeProses.EditValue = HtmlEncode(TipeProses.CurrentValue);
                TipeProses.PlaceHolder = RemoveHtml(TipeProses.Caption);

                // Edit refer script

                // NoReferensi
                NoReferensi.HrefValue = "";

                // IdProses
                IdProses.HrefValue = "";

                // IdAktivitas
                IdAktivitas.HrefValue = "";

                // NamaDokumen
                NamaDokumen.HrefValue = "";

                // UploadDokumen
                UploadDokumen.HrefValue = "";

                // DownloadDokumen
                DownloadDokumen.HrefValue = "";

                // DiunggahOleh
                DiunggahOleh.HrefValue = "";

                // TanggalUpload
                TanggalUpload.HrefValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";

                // WajibUpload
                WajibUpload.HrefValue = "";

                // TipeProses
                TipeProses.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998

        private void ValidateCustomNoReferensi() {
            if (NoReferensi.Visible && NoReferensi.Required) {
                if (!NoReferensi.IsDetailKey && Empty(NoReferensi.FormValue)) {
                    NoReferensi.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomIdProses() {
            if (IdProses.Visible && IdProses.Required) {
                if (!IdProses.IsDetailKey && Empty(IdProses.FormValue)) {
                    IdProses.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomIdAktivitas() {
            if (IdAktivitas.Visible && IdAktivitas.Required) {
                if (!IdAktivitas.IsDetailKey && Empty(IdAktivitas.FormValue)) {
                    IdAktivitas.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomNamaDokumen() {
            if (NamaDokumen.Visible && NamaDokumen.Required) {
                if (!NamaDokumen.IsDetailKey && Empty(NamaDokumen.FormValue)) {
                    NamaDokumen.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomUploadDokumen() {
            if (UploadDokumen.Visible && UploadDokumen.Required) {
                if (!UploadDokumen.IsDetailKey && Empty(UploadDokumen.FormValue)) {
                    UploadDokumen.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomDownloadDokumen() {
            if (DownloadDokumen.Visible && DownloadDokumen.Required) {
                if (!DownloadDokumen.IsDetailKey && Empty(DownloadDokumen.FormValue)) {
                    DownloadDokumen.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomDiunggahOleh() {
            if (DiunggahOleh.Visible && DiunggahOleh.Required) {
                if (!DiunggahOleh.IsDetailKey && Empty(DiunggahOleh.FormValue)) {
                    DiunggahOleh.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomTanggalUpload() {
            if (TanggalUpload.Visible && TanggalUpload.Required) {
                if (!TanggalUpload.IsDetailKey && Empty(TanggalUpload.FormValue)) {
                    TanggalUpload.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomDiperbaruiOleh() {
            if (DiperbaruiOleh.Visible && DiperbaruiOleh.Required) {
                if (!DiperbaruiOleh.IsDetailKey && Empty(DiperbaruiOleh.FormValue)) {
                    DiperbaruiOleh.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomTanggalDiperbarui() {
            if (TanggalDiperbarui.Visible && TanggalDiperbarui.Required) {
                if (!TanggalDiperbarui.IsDetailKey && Empty(TanggalDiperbarui.FormValue)) {
                    TanggalDiperbarui.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomWajibUpload() {
            if (WajibUpload.Visible && WajibUpload.Required) {
                if (Empty(WajibUpload.FormValue)) {
                    WajibUpload.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        private void ValidateCustomTipeProses() {
            if (TipeProses.Visible && TipeProses.Required) {
                if (!TipeProses.IsDetailKey && Empty(TipeProses.FormValue)) {
                    TipeProses.AddErrorMessage(ConvertToString(TipeProses.RequiredErrorMessage).Replace("%s", TipeProses.Caption));
                }
            }
        }

        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
                ValidateCustomNoReferensi();
                ValidateCustomIdProses();
                if (!CheckInteger(IdProses.FormValue)) {
                    IdProses.AddErrorMessage(IdProses.GetErrorMessage(false));
                }
                ValidateCustomIdAktivitas();
                ValidateCustomNamaDokumen();
                ValidateCustomUploadDokumen();
                ValidateCustomDownloadDokumen();
                ValidateCustomDiunggahOleh();
                ValidateCustomTanggalUpload();
                if (!CheckDate(TanggalUpload.FormValue, TanggalUpload.FormatPattern)) {
                    TanggalUpload.AddErrorMessage(TanggalUpload.GetErrorMessage(false));
                }
                ValidateCustomDiperbaruiOleh();
                ValidateCustomTanggalDiperbarui();
                if (!CheckDate(TanggalDiperbarui.FormValue, TanggalDiperbarui.FormatPattern)) {
                    TanggalDiperbarui.AddErrorMessage(TanggalDiperbarui.GetErrorMessage(false));
                }
                ValidateCustomWajibUpload();
                ValidateCustomTipeProses();

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

        // Delete records (based on current filter)
        protected async Task<JsonBoolResult> DeleteRows() { // DN
            if (!Security.CanDelete) {
                FailureMessage = Language.Phrase("NoDeletePermission"); // No delete permission
                return JsonBoolResult.FalseResult; // No delete permission
            }
            List<Dictionary<string, object>> oldRows;
            bool result = true;
            try {
                string sql = CurrentSql;
                oldRows = await Connection.GetRowsAsync(sql);
                if (oldRows.Count() == 0) {
                    FailureMessage = Language.Phrase("NoRecord"); // No record found
                    return JsonBoolResult.FalseResult;
                }
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }
            List<string> successKeys = [], failKeys = [];
            try {
                // Call Row Deleting event
                if (result) {
                    foreach (var row in oldRows)
                        result = result && RowDeleting(row);
                }
                if (result) {
                    foreach (var row in oldRows) {
                        try {
                            result = await DeleteAsync(row) > 0;
                        } catch (Exception e) {
                            if (Config.Debug)
                                throw;
                            FailureMessage = e.Message; // Set up error message
                            result = false;
                        }
                        if (!result) {
                            if (UseTransaction) {
                                successKeys.Clear();
                                break;
                            }
                            failKeys.Add(GetKey(row)); // DN
                        } else {
                            if (Config.DeleteUploadFiles)
                                DeleteUploadedFiles(row);
                            RowDeleted(row);
                            successKeys.Add(GetKey(row)); // DN
                        }
                    }
                }
                result = successKeys.Count > 0;
                if (!result) {
                    // Set up error message
                    if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                        // Use the message, do nothing
                    } else if (!Empty(CancelMessage)) {
                        FailureMessage = CancelMessage;
                        CancelMessage = "";
                    } else {
                        FailureMessage = Language.Phrase("DeleteCancelled");
                    }
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                result = false;
            }

            // Write JSON for API request
            Dictionary<string, object> d = new();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                string table = TableVar;
                d.Add(table, RouteValues.Count > 2 && oldRows.Count == 1 ? oldRows[0] : oldRows); // If single-delete, route values are controller/action/id (count > 2)
                d.Add("action", Config.ApiDeleteAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, true);
            }
            return new JsonBoolResult(d, result);
        }

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
            bool validMasterRecord;
            object keyValue;
            object? v;
            string? masterFilter;
            Dictionary<string, object?> detailKeys;

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
            PathFile.OldUploadPath = PathFile.GetUploadPath();
            PathFile.UploadPath = PathFile.OldUploadPath;

            // NoReferensi
            NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue, NoReferensi.ReadOnly);

            // IdProses
            IdProses.SetDbValue(rsnew, IdProses.CurrentValue, IdProses.ReadOnly);

            // IdAktivitas
            if (!Empty(IdAktivitas.SessionValue))
                IdAktivitas.ReadOnly = true;
            IdAktivitas.SetDbValue(rsnew, IdAktivitas.CurrentValue, IdAktivitas.ReadOnly);

            // NamaDokumen
            NamaDokumen.SetDbValue(rsnew, NamaDokumen.CurrentValue, NamaDokumen.ReadOnly);

            // UploadDokumen
            UploadDokumen.SetDbValue(rsnew, UploadDokumen.CurrentValue, UploadDokumen.ReadOnly);

            // DownloadDokumen
            DownloadDokumen.SetDbValue(rsnew, DownloadDokumen.CurrentValue, DownloadDokumen.ReadOnly);

            // DiunggahOleh
            DiunggahOleh.SetDbValue(rsnew, DiunggahOleh.CurrentValue, DiunggahOleh.ReadOnly);

            // TanggalUpload
            TanggalUpload.SetDbValue(rsnew, ConvertToDateTime(TanggalUpload.CurrentValue, TanggalUpload.FormatPattern), TanggalUpload.ReadOnly);

            // DiperbaruiOleh
            DiperbaruiOleh.SetDbValue(rsnew, DiperbaruiOleh.CurrentValue, DiperbaruiOleh.ReadOnly);

            // TanggalDiperbarui
            TanggalDiperbarui.SetDbValue(rsnew, ConvertToDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern), TanggalDiperbarui.ReadOnly);

            // WajibUpload
            WajibUpload.SetDbValue(rsnew, ConvertToBool(WajibUpload.CurrentValue), WajibUpload.ReadOnly);

            // TipeProses
            TipeProses.SetDbValue(rsnew, TipeProses.CurrentValue, TipeProses.ReadOnly);
            return rsnew;
        }

        /// <summary>
        /// Restore edit form from row
        /// </summary>
        /// <param name="row">Current row</param>
        protected void RestoreEditFormFromRow(Dictionary<string, object> row)
        {
            object? value;
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.CurrentValue = value;
            if (row.TryGetValue("IdProses", out value)) // IdProses
                IdProses.CurrentValue = value;
            if (row.TryGetValue("IdAktivitas", out value)) // IdAktivitas
                IdAktivitas.CurrentValue = value;
            if (row.TryGetValue("NamaDokumen", out value)) // NamaDokumen
                NamaDokumen.CurrentValue = value;
            if (row.TryGetValue("UploadDokumen", out value)) // UploadDokumen
                UploadDokumen.CurrentValue = value;
            if (row.TryGetValue("DownloadDokumen", out value)) // DownloadDokumen
                DownloadDokumen.CurrentValue = value;
            if (row.TryGetValue("DiunggahOleh", out value)) // DiunggahOleh
                DiunggahOleh.CurrentValue = value;
            if (row.TryGetValue("TanggalUpload", out value)) // TanggalUpload
                TanggalUpload.CurrentValue = value;
            if (row.TryGetValue("DiperbaruiOleh", out value)) // DiperbaruiOleh
                DiperbaruiOleh.CurrentValue = value;
            if (row.TryGetValue("TanggalDiperbarui", out value)) // TanggalDiperbarui
                TanggalDiperbarui.CurrentValue = value;
            if (row.TryGetValue("WajibUpload", out value)) // WajibUpload
                WajibUpload.CurrentValue = value;
            if (row.TryGetValue("TipeProses", out value)) // TipeProses
                TipeProses.CurrentValue = value;
        }

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Set up foreign key field value from Session
            if (CurrentMasterTable == "Aktivitas") {
                IdAktivitas.Visible = true; // Need to insert foreign key
                IdAktivitas.CurrentValue = IdAktivitas.SessionValue;
            }

            // Get new row
            Dictionary<string, object> rsnew = GetAddRow();
            if (rsnew.Count == 0)
                return JsonBoolResult.FalseResult;

            // Update current values
            SetCurrentValues(rsnew);
            string? masterFilter;
            Dictionary<string, object?> detailKeys;
            bool validMasterRecord;

            // Load db values from rsold
            LoadDbValues(rsold);
            if (rsold != null) {
                PathFile.OldUploadPath = PathFile.GetUploadPath();
                PathFile.UploadPath = PathFile.OldUploadPath;
            } else {
                PathFile.UploadPath = PathFile.GetUploadPath();
            }

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["IdAktivitasDokumen"] = IdAktivitasDokumen.CurrentValue!;
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

                // NoReferensi
                NoReferensi.SetDbValue(rsnew, NoReferensi.CurrentValue);

                // IdProses
                IdProses.SetDbValue(rsnew, IdProses.CurrentValue);

                // IdAktivitas
                IdAktivitas.SetDbValue(rsnew, IdAktivitas.CurrentValue);

                // NamaDokumen
                NamaDokumen.SetDbValue(rsnew, NamaDokumen.CurrentValue);

                // UploadDokumen
                UploadDokumen.SetDbValue(rsnew, UploadDokumen.CurrentValue);

                // DownloadDokumen
                DownloadDokumen.SetDbValue(rsnew, DownloadDokumen.CurrentValue);

                // DiunggahOleh
                DiunggahOleh.SetDbValue(rsnew, DiunggahOleh.CurrentValue);

                // TanggalUpload
                TanggalUpload.SetDbValue(rsnew, ConvertToDateTime(TanggalUpload.CurrentValue, TanggalUpload.FormatPattern));

                // DiperbaruiOleh
                DiperbaruiOleh.SetDbValue(rsnew, DiperbaruiOleh.CurrentValue);

                // TanggalDiperbarui
                TanggalDiperbarui.SetDbValue(rsnew, ConvertToDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern));

                // WajibUpload
                WajibUpload.SetDbValue(rsnew, ConvertToBool(WajibUpload.CurrentValue), Empty(WajibUpload.CurrentValue));

                // TipeProses
                TipeProses.SetDbValue(rsnew, TipeProses.CurrentValue);
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
            if (row.TryGetValue("NoReferensi", out value)) // NoReferensi
                NoReferensi.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdProses", out value)) // IdProses
                IdProses.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("IdAktivitas", out value)) // IdAktivitas
                IdAktivitas.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("NamaDokumen", out value)) // NamaDokumen
                NamaDokumen.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("UploadDokumen", out value)) // UploadDokumen
                UploadDokumen.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DownloadDokumen", out value)) // DownloadDokumen
                DownloadDokumen.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DiunggahOleh", out value)) // DiunggahOleh
                DiunggahOleh.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalUpload", out value)) // TanggalUpload
                TanggalUpload.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("DiperbaruiOleh", out value)) // DiperbaruiOleh
                DiperbaruiOleh.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TanggalDiperbarui", out value)) // TanggalDiperbarui
                TanggalDiperbarui.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("WajibUpload", out value)) // WajibUpload
                WajibUpload.SetFormValue(ConvertToString(value));
            if (row.TryGetValue("TipeProses", out value)) // TipeProses
                TipeProses.SetFormValue(ConvertToString(value));
        }

        // Set up master/detail based on QueryString
        protected void SetupMasterParms() {
            // Hide foreign keys
            string masterTblVar = CurrentMasterTable;
            if (masterTblVar == "Aktivitas") {
                IdAktivitas.Visible = false;

                //if (aktivitas.EventCancelled) EventCancelled = true;
                if (Get<bool>("mastereventcancelled"))
                    EventCancelled = true;
            }
            DbMasterFilter = MasterFilterFromSession; // Get master filter from session
            DbDetailFilter = DetailFilterFromSession; // Get detail filter from session
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

        // ListOptions Load event
        public virtual void ListOptionsLoad() {
            // Example:
            //var opt = ListOptions.Add("new");
            //opt.Header = "xxx";
            //opt.OnLeft = true; // Link on left
            //opt.MoveTo(0); // Move to first column
        }

        // ListOptions Rendering event
        public virtual void ListOptionsRendering() {
            //xxxGrid.DetailAdd = (...condition...); // Set to true or false conditionally
            //xxxGrid.DetailEdit = (...condition...); // Set to true or false conditionally
            //xxxGrid.DetailView = (...condition...); // Set to true or false conditionally
        }

        // ListOptions Rendered event
        public virtual void ListOptionsRendered() {
            //Example:
            //ListOptions["new"].Body = "xxx";
        }

        // Row Custom Action event
        public virtual bool RowCustomAction(string action, Dictionary<string, object> row) {
            // Return false to abort
            return true;
        }

        // Grid Inserting event
        public virtual bool GridInserting() {
            // Enter your code here
            // To reject grid insert, set return value to false
            return true;
        }

        // Grid Inserted event
        public virtual void GridInserted(List<Dictionary<string, object>> rsnew) {
            //Log("Grid Inserted");
        }

        // Grid Updating event
        public virtual bool GridUpdating(List<Dictionary<string, object>> rsold) {
            // Enter your code here
            // To reject grid update, set return value to false
            return true;
        }

        // Grid Updated event
        public virtual void GridUpdated(List<Dictionary<string, object>> rsold, List<Dictionary<string, object>> rsnew) {
            //Log("Grid Updated");
        }
    } // End page class
} // End Partial class
