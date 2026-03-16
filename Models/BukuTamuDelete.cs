using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// bukuTamuDelete
    /// </summary>
    public static BukuTamuDelete bukuTamuDelete
    {
        get => HttpData.Get<BukuTamuDelete>("bukuTamuDelete")!;
        set => HttpData["bukuTamuDelete"] = value;
    }

    /// <summary>
    /// Page class for BukuTamu
    /// </summary>
    public class BukuTamuDelete : BukuTamuDeleteBase
    {
        // Constructor
        public BukuTamuDelete(Controller controller) : base(controller)
        {
        }

        // Constructor
        public BukuTamuDelete() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            Plant.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class BukuTamuDeleteBase : BukuTamu
    {
        // Page ID
        public string PageID = "delete";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "bukuTamuDelete";

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
        public BukuTamuDeleteBase(Controller? controller)
        {
            TableName = "BukuTamu";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (bukuTamu)
            if (bukuTamu == null || bukuTamu is BukuTamu)
                bukuTamu = this;

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
        public string PageName => "BukuTamuDelete";

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
            NomorBukuTamu.Visible = false;
            LinkRedirect.SetVisibility();
            LookupPlant.Visible = false;
            Plant.SetVisibility();
            Tanggal.SetVisibility();
            StatusZona.SetVisibility();
            Nama.SetVisibility();
            AsalPerusahaan.SetVisibility();
            Jabatan.SetVisibility();
            FungsiygDikunjungi.SetVisibility();
            MaksudKunjungan.SetVisibility();
            TandaPengenal.SetVisibility();
            TandaTangan.Visible = false;
            TandaTanganDownload.SetVisibility();
            Keterangan.SetVisibility();
            PintuUtamaId.SetVisibility();
            PintuUtamaInTanggal.SetVisibility();
            PintuUtamaInFoto.Visible = false;
            PintuUtamaInFotoDownload.SetVisibility();
            PintuUtamaInUser.SetVisibility();
            CustomPilihPintu.SetVisibility();
            PintuUtamaOutTanggal.SetVisibility();
            PintuUtamaOutFoto.Visible = false;
            PintuUtamaOutFotoDownload.SetVisibility();
            PintuUtamaOutUser.SetVisibility();
            LobbyUtamaId.SetVisibility();
            LobbyUtamaInTanggal.SetVisibility();
            LobbyUtamaInFoto.Visible = false;
            LobbyUtamaInFotoDownload.SetVisibility();
            LobbyUtamaInUser.SetVisibility();
            LobbyUtamaOutTanggal.SetVisibility();
            LobbyUtamaOutFoto.Visible = false;
            LobbyUtamaOutFotoDownload.SetVisibility();
            LobbyUtamaOutUser.SetVisibility();
            AreaTerlarangId.SetVisibility();
            AreaTerlarangInTanggal.SetVisibility();
            AreaTerlarangInFoto.Visible = false;
            AreaTerlarangInFotoDownload.SetVisibility();
            AreaTerlarangInUser.SetVisibility();
            AreaTerlarangOutTanggal.SetVisibility();
            AreaTerlarangOutFoto.Visible = false;
            AreaTerlarangOutFotoDownload.SetVisibility();
            AreaTerlarangOutUser.SetVisibility();
            etlDate.SetVisibility();
            LastUpdatedBy.SetVisibility();
            lastUpdatedDate.SetVisibility();
            StatusZonaPrev.Visible = false;
        }

        // Constructor
        public BukuTamuDeleteBase() : this(null) { }

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
            key += UrlEncode(ConvertToString(dict.ContainsKey("id") ? dict["id"] : id.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                id.Visible = false;
        }

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public int StartRecord;

        public int TotalRecords;

        public int RecordCount;

        public List<string> RecordKeys = new();

        public DbDataReader? Recordset;

        public int StartRowCount = 1;

        public bool IsModal = false;

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            var beginResult = await PageRunBeginAsync();
            if (beginResult != null) return beginResult;

            // === VARIABEL YANG DIPAKAI LINTAS-SECTION ===
            string filter;
            bool res;

            // === HELPER CALLS ===
            SetupMasterParameters();
            SetupBreadcrumb();

            // Load key parameters & filter
            RecordKeys = GetRecordKeys();
            filter = GetFilterFromRecordKeys();
            if (Empty(filter))
                return Terminate("BukuTamuList");
            CurrentFilter = filter;

            // Check User ID (jika ada)
            res = await ValidateUserIdAsync(CurrentFilter);
            if (!res)
                return Terminate("BukuTamuList");

            // Tentukan CurrentAction
            CurrentAction = DetermineCurrentAction();

            // Eksekusi action
            var actionResult = await ExecuteCurrentAction();
            if (actionResult != null) return actionResult;
            PageRunEnd();
            return PageResult();
        }

        // === HELPER METHODS ===
        private void SetupMasterParameters()
        {
        }

        private async Task<bool> ValidateUserIdAsync(string filter)
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            return true;
        }

        private string DetermineCurrentAction()
        {
            if (IsApi()) {
                return "delete";
            } else if (!Empty(Param("action"))) {
                return Param("action") == "delete" ? "delete" : "show";
            } else {
                return InlineDelete ? "delete" : "show";
            }
        }

        private async Task<IActionResult?> ExecuteCurrentAction()
        {
            if (IsDelete) {
                return await HandleDeleteAction();
            }
            if (IsShow) {
                return await HandleShowAction();
            }
            return null;
        }

        private async Task<IActionResult?> HandleDeleteAction()
        {
            SendEmail = true;
            var res = await DeleteRows();
            if (res) {
                if (Empty(SuccessMessage))
                    SuccessMessage = Language.Phrase("DeleteSuccess");
                if (IsJsonResponse()) {
                    ClearMessages();
                    return res;
                } else {
                    return Terminate(ReturnUrl);
                }
            } else {
                if (IsJsonResponse()) {
                    return Terminate();
                }
                if (UseAjaxActions)
                    return Controller.Json(new { success = false, error = GetFailureMessage() });
                if (InlineDelete)
                    return Terminate(ReturnUrl);
                else
                    CurrentAction = "show";
            }
            return null;
        }

        private async Task<IActionResult?> HandleShowAction()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled
            Recordset = await LoadRecordset();
            TotalRecords = await ListRecordCountAsync();
            if (TotalRecords <= 0) {
                CloseRecordset();
                return Terminate("BukuTamuList");
            }
            return null;
        }

        private async Task<IActionResult?> PageRunBeginAsync()
        {
            await Task.CompletedTask; // Satisfy async requirement
            // If null, the conditions aren't fulfilled

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
            await SetupLookupOptions(LookupPlant);
            await SetupLookupOptions(Plant);
            await SetupLookupOptions(FungsiygDikunjungi);
            await SetupLookupOptions(TandaPengenal);
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
                bukuTamuDelete?.PageRender();
            }
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
            id.SetDbValue(row["id"]);
            NomorBukuTamu.SetDbValue(row["NomorBukuTamu"]);
            LinkRedirect.SetDbValue(row["LinkRedirect"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            Plant.SetDbValue(row["Plant"]);
            Tanggal.SetDbValue(row["Tanggal"]);
            StatusZona.SetDbValue(row["StatusZona"]);
            Nama.SetDbValue(row["Nama"]);
            AsalPerusahaan.SetDbValue(row["AsalPerusahaan"]);
            Jabatan.SetDbValue(row["Jabatan"]);
            FungsiygDikunjungi.SetDbValue(row["FungsiygDikunjungi"]);
            MaksudKunjungan.SetDbValue(row["MaksudKunjungan"]);
            TandaPengenal.SetDbValue(row["TandaPengenal"]);
            TandaTangan.SetDbValue(row["TandaTangan"]);
            TandaTanganDownload.SetDbValue(row["TandaTanganDownload"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            PintuUtamaId.SetDbValue(row["PintuUtamaId"]);
            PintuUtamaInTanggal.SetDbValue(row["PintuUtamaInTanggal"]);
            PintuUtamaInFoto.SetDbValue(row["PintuUtamaInFoto"]);
            PintuUtamaInFotoDownload.SetDbValue(row["PintuUtamaInFotoDownload"]);
            PintuUtamaInUser.SetDbValue(row["PintuUtamaInUser"]);
            CustomPilihPintu.SetDbValue(row["CustomPilihPintu"]);
            PintuUtamaOutTanggal.SetDbValue(row["PintuUtamaOutTanggal"]);
            PintuUtamaOutFoto.SetDbValue(row["PintuUtamaOutFoto"]);
            PintuUtamaOutFotoDownload.SetDbValue(row["PintuUtamaOutFotoDownload"]);
            PintuUtamaOutUser.SetDbValue(row["PintuUtamaOutUser"]);
            LobbyUtamaId.SetDbValue(row["LobbyUtamaId"]);
            LobbyUtamaInTanggal.SetDbValue(row["LobbyUtamaInTanggal"]);
            LobbyUtamaInFoto.SetDbValue(row["LobbyUtamaInFoto"]);
            LobbyUtamaInFotoDownload.SetDbValue(row["LobbyUtamaInFotoDownload"]);
            LobbyUtamaInUser.SetDbValue(row["LobbyUtamaInUser"]);
            LobbyUtamaOutTanggal.SetDbValue(row["LobbyUtamaOutTanggal"]);
            LobbyUtamaOutFoto.SetDbValue(row["LobbyUtamaOutFoto"]);
            LobbyUtamaOutFotoDownload.SetDbValue(row["LobbyUtamaOutFotoDownload"]);
            LobbyUtamaOutUser.SetDbValue(row["LobbyUtamaOutUser"]);
            AreaTerlarangId.SetDbValue(row["AreaTerlarangId"]);
            AreaTerlarangInTanggal.SetDbValue(row["AreaTerlarangInTanggal"]);
            AreaTerlarangInFoto.SetDbValue(row["AreaTerlarangInFoto"]);
            AreaTerlarangInFotoDownload.SetDbValue(row["AreaTerlarangInFotoDownload"]);
            AreaTerlarangInUser.SetDbValue(row["AreaTerlarangInUser"]);
            AreaTerlarangOutTanggal.SetDbValue(row["AreaTerlarangOutTanggal"]);
            AreaTerlarangOutFoto.SetDbValue(row["AreaTerlarangOutFoto"]);
            AreaTerlarangOutFotoDownload.SetDbValue(row["AreaTerlarangOutFotoDownload"]);
            AreaTerlarangOutUser.SetDbValue(row["AreaTerlarangOutUser"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            StatusZonaPrev.SetDbValue(row["StatusZonaPrev"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("id", id.DefaultValue ?? DbNullValue); // DN
            row.Add("NomorBukuTamu", NomorBukuTamu.DefaultValue ?? DbNullValue); // DN
            row.Add("LinkRedirect", LinkRedirect.DefaultValue ?? DbNullValue); // DN
            row.Add("LookupPlant", LookupPlant.DefaultValue ?? DbNullValue); // DN
            row.Add("Plant", Plant.DefaultValue ?? DbNullValue); // DN
            row.Add("Tanggal", Tanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusZona", StatusZona.DefaultValue ?? DbNullValue); // DN
            row.Add("Nama", Nama.DefaultValue ?? DbNullValue); // DN
            row.Add("AsalPerusahaan", AsalPerusahaan.DefaultValue ?? DbNullValue); // DN
            row.Add("Jabatan", Jabatan.DefaultValue ?? DbNullValue); // DN
            row.Add("FungsiygDikunjungi", FungsiygDikunjungi.DefaultValue ?? DbNullValue); // DN
            row.Add("MaksudKunjungan", MaksudKunjungan.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaPengenal", TandaPengenal.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaTangan", TandaTangan.DefaultValue ?? DbNullValue); // DN
            row.Add("TandaTanganDownload", TandaTanganDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("Keterangan", Keterangan.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaId", PintuUtamaId.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInTanggal", PintuUtamaInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInFoto", PintuUtamaInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInFotoDownload", PintuUtamaInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaInUser", PintuUtamaInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("CustomPilihPintu", CustomPilihPintu.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutTanggal", PintuUtamaOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutFoto", PintuUtamaOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutFotoDownload", PintuUtamaOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("PintuUtamaOutUser", PintuUtamaOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaId", LobbyUtamaId.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInTanggal", LobbyUtamaInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInFoto", LobbyUtamaInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInFotoDownload", LobbyUtamaInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaInUser", LobbyUtamaInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutTanggal", LobbyUtamaOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutFoto", LobbyUtamaOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutFotoDownload", LobbyUtamaOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("LobbyUtamaOutUser", LobbyUtamaOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangId", AreaTerlarangId.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInTanggal", AreaTerlarangInTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInFoto", AreaTerlarangInFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInFotoDownload", AreaTerlarangInFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangInUser", AreaTerlarangInUser.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutTanggal", AreaTerlarangOutTanggal.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutFoto", AreaTerlarangOutFoto.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutFotoDownload", AreaTerlarangOutFotoDownload.DefaultValue ?? DbNullValue); // DN
            row.Add("AreaTerlarangOutUser", AreaTerlarangOutUser.DefaultValue ?? DbNullValue); // DN
            row.Add("etlDate", etlDate.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("lastUpdatedDate", lastUpdatedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("StatusZonaPrev", StatusZonaPrev.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // id

            // NomorBukuTamu

            // LinkRedirect

            // LookupPlant

            // Plant

            // Tanggal

            // StatusZona

            // Nama

            // AsalPerusahaan

            // Jabatan

            // FungsiygDikunjungi

            // MaksudKunjungan

            // TandaPengenal

            // TandaTangan

            // TandaTanganDownload

            // Keterangan

            // PintuUtamaId

            // PintuUtamaInTanggal

            // PintuUtamaInFoto

            // PintuUtamaInFotoDownload

            // PintuUtamaInUser

            // CustomPilihPintu

            // PintuUtamaOutTanggal

            // PintuUtamaOutFoto

            // PintuUtamaOutFotoDownload

            // PintuUtamaOutUser

            // LobbyUtamaId

            // LobbyUtamaInTanggal

            // LobbyUtamaInFoto

            // LobbyUtamaInFotoDownload

            // LobbyUtamaInUser

            // LobbyUtamaOutTanggal

            // LobbyUtamaOutFoto

            // LobbyUtamaOutFotoDownload

            // LobbyUtamaOutUser

            // AreaTerlarangId

            // AreaTerlarangInTanggal

            // AreaTerlarangInFoto

            // AreaTerlarangInFotoDownload

            // AreaTerlarangInUser

            // AreaTerlarangOutTanggal

            // AreaTerlarangOutFoto

            // AreaTerlarangOutFotoDownload

            // AreaTerlarangOutUser

            // etlDate

            // LastUpdatedBy

            // lastUpdatedDate

            // StatusZonaPrev

            // View row
            if (RowType == RowType.View) {
                // NomorBukuTamu

                // LinkRedirect

                // LookupPlant

                // Plant

                // Tanggal

                // StatusZona

                // Nama

                // AsalPerusahaan

                // Jabatan

                // FungsiygDikunjungi

                // MaksudKunjungan

                // TandaPengenal

                // TandaTangan

                // TandaTanganDownload

                // Keterangan

                // PintuUtamaId

                // PintuUtamaInTanggal

                // PintuUtamaInFotoDownload

                // PintuUtamaInUser

                // CustomPilihPintu

                // PintuUtamaOutTanggal

                // PintuUtamaOutFotoDownload

                // PintuUtamaOutUser

                // LobbyUtamaId

                // LobbyUtamaInTanggal

                // LobbyUtamaInFotoDownload

                // LobbyUtamaInUser

                // LobbyUtamaOutTanggal

                // LobbyUtamaOutFotoDownload

                // LobbyUtamaOutUser

                // AreaTerlarangId

                // AreaTerlarangInTanggal

                // AreaTerlarangInFotoDownload

                // AreaTerlarangInUser

                // AreaTerlarangOutTanggal

                // AreaTerlarangOutFotoDownload

                // AreaTerlarangOutUser

                // etlDate

                // LastUpdatedBy

                // lastUpdatedDate

                // StatusZonaPrev

                    // id
                    id.ViewValue = id.CurrentValue;
                    id.ViewCustomAttributes = "";

                    // NomorBukuTamu
                    NomorBukuTamu.ViewValue = ConvertToString(NomorBukuTamu.CurrentValue); // DN
                    NomorBukuTamu.ViewCustomAttributes = "";

                    // LinkRedirect
                    LinkRedirect.ViewValue = ConvertToString(LinkRedirect.CurrentValue); // DN
                    LinkRedirect.ViewCustomAttributes = "";

                    // LookupPlant
                    if (!Empty(LookupPlant.CurrentValue)) {
                        LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
                    } else {
                        LookupPlant.ViewValue = DbNullValue;
                    }
                    LookupPlant.ViewCustomAttributes = "";

                    // Plant
                    Plant.ViewValue = Plant.CurrentValue;

                    // awallookupbung
                    // Plant (jaga leading zero)
                    ResolveLookupView(Plant, "IdPlant", "string");
                    // akhirlookupbung
                    Plant.ViewCustomAttributes = "";

                    // Tanggal
                    Tanggal.ViewValue = Tanggal.CurrentValue;
                    Tanggal.ViewValue = FormatDateTime(Tanggal.ViewValue, Tanggal.FormatPattern);
                    Tanggal.ViewCustomAttributes = "";

                    // StatusZona
                    StatusZona.ViewValue = ConvertToString(StatusZona.CurrentValue); // DN
                    StatusZona.ViewCustomAttributes = "";

                    // Nama
                    Nama.ViewValue = ConvertToString(Nama.CurrentValue); // DN
                    Nama.ViewCustomAttributes = "";

                    // AsalPerusahaan
                    AsalPerusahaan.ViewValue = ConvertToString(AsalPerusahaan.CurrentValue); // DN
                    AsalPerusahaan.ViewCustomAttributes = "";

                    // Jabatan
                    Jabatan.ViewValue = ConvertToString(Jabatan.CurrentValue); // DN
                    Jabatan.ViewCustomAttributes = "";

                    // FungsiygDikunjungi

                    // awallookupbung
                    // FungsiygDikunjungi (jaga leading zero)
                    ResolveLookupView(FungsiygDikunjungi, "ID", "string");
                    // akhirlookupbung
                    FungsiygDikunjungi.ViewCustomAttributes = "";

                    // MaksudKunjungan
                    MaksudKunjungan.ViewValue = ConvertToString(MaksudKunjungan.CurrentValue); // DN
                    MaksudKunjungan.ViewCustomAttributes = "";

                    // TandaPengenal
                    if (!Empty(TandaPengenal.CurrentValue)) {
                        TandaPengenal.ViewValue = TandaPengenal.OptionCaption(ConvertToString(TandaPengenal.CurrentValue));
                    } else {
                        TandaPengenal.ViewValue = DbNullValue;
                    }
                    TandaPengenal.ViewCustomAttributes = "";

                    // TandaTangan
                    TandaTangan.ViewValue = TandaTangan.CurrentValue;
                    TandaTangan.ViewCustomAttributes = "";

                    // TandaTanganDownload
                    TandaTanganDownload.ViewValue = TandaTanganDownload.CurrentValue;
                    TandaTanganDownload.ViewCustomAttributes = "";

                    // Keterangan
                    Keterangan.ViewValue = Keterangan.CurrentValue;
                    Keterangan.ViewCustomAttributes = "";

                    // PintuUtamaId
                    PintuUtamaId.ViewValue = ConvertToString(PintuUtamaId.CurrentValue); // DN
                    PintuUtamaId.ViewCustomAttributes = "";

                    // PintuUtamaInTanggal
                    PintuUtamaInTanggal.ViewValue = PintuUtamaInTanggal.CurrentValue;
                    PintuUtamaInTanggal.ViewValue = FormatDateTime(PintuUtamaInTanggal.ViewValue, PintuUtamaInTanggal.FormatPattern);
                    PintuUtamaInTanggal.ViewCustomAttributes = "";

                    // PintuUtamaInFotoDownload
                    PintuUtamaInFotoDownload.ViewValue = PintuUtamaInFotoDownload.CurrentValue;
                    PintuUtamaInFotoDownload.ViewCustomAttributes = "";

                    // PintuUtamaInUser
                    PintuUtamaInUser.ViewValue = ConvertToString(PintuUtamaInUser.CurrentValue); // DN
                    PintuUtamaInUser.ViewCustomAttributes = "";

                    // CustomPilihPintu
                    CustomPilihPintu.ViewValue = ConvertToString(CustomPilihPintu.CurrentValue); // DN
                    CustomPilihPintu.ViewCustomAttributes = "";

                    // PintuUtamaOutTanggal
                    PintuUtamaOutTanggal.ViewValue = PintuUtamaOutTanggal.CurrentValue;
                    PintuUtamaOutTanggal.ViewValue = FormatDateTime(PintuUtamaOutTanggal.ViewValue, PintuUtamaOutTanggal.FormatPattern);
                    PintuUtamaOutTanggal.ViewCustomAttributes = "";

                    // PintuUtamaOutFotoDownload
                    PintuUtamaOutFotoDownload.ViewValue = PintuUtamaOutFotoDownload.CurrentValue;
                    PintuUtamaOutFotoDownload.ViewCustomAttributes = "";

                    // PintuUtamaOutUser
                    PintuUtamaOutUser.ViewValue = ConvertToString(PintuUtamaOutUser.CurrentValue); // DN
                    PintuUtamaOutUser.ViewCustomAttributes = "";

                    // LobbyUtamaId
                    LobbyUtamaId.ViewValue = ConvertToString(LobbyUtamaId.CurrentValue); // DN
                    LobbyUtamaId.ViewCustomAttributes = "";

                    // LobbyUtamaInTanggal
                    LobbyUtamaInTanggal.ViewValue = LobbyUtamaInTanggal.CurrentValue;
                    LobbyUtamaInTanggal.ViewValue = FormatDateTime(LobbyUtamaInTanggal.ViewValue, LobbyUtamaInTanggal.FormatPattern);
                    LobbyUtamaInTanggal.ViewCustomAttributes = "";

                    // LobbyUtamaInFotoDownload
                    LobbyUtamaInFotoDownload.ViewValue = LobbyUtamaInFotoDownload.CurrentValue;
                    LobbyUtamaInFotoDownload.ViewCustomAttributes = "";

                    // LobbyUtamaInUser
                    LobbyUtamaInUser.ViewValue = ConvertToString(LobbyUtamaInUser.CurrentValue); // DN
                    LobbyUtamaInUser.ViewCustomAttributes = "";

                    // LobbyUtamaOutTanggal
                    LobbyUtamaOutTanggal.ViewValue = LobbyUtamaOutTanggal.CurrentValue;
                    LobbyUtamaOutTanggal.ViewValue = FormatDateTime(LobbyUtamaOutTanggal.ViewValue, LobbyUtamaOutTanggal.FormatPattern);
                    LobbyUtamaOutTanggal.ViewCustomAttributes = "";

                    // LobbyUtamaOutFotoDownload
                    LobbyUtamaOutFotoDownload.ViewValue = LobbyUtamaOutFotoDownload.CurrentValue;
                    LobbyUtamaOutFotoDownload.ViewCustomAttributes = "";

                    // LobbyUtamaOutUser
                    LobbyUtamaOutUser.ViewValue = ConvertToString(LobbyUtamaOutUser.CurrentValue); // DN
                    LobbyUtamaOutUser.ViewCustomAttributes = "";

                    // AreaTerlarangId
                    AreaTerlarangId.ViewValue = ConvertToString(AreaTerlarangId.CurrentValue); // DN
                    AreaTerlarangId.ViewCustomAttributes = "";

                    // AreaTerlarangInTanggal
                    AreaTerlarangInTanggal.ViewValue = AreaTerlarangInTanggal.CurrentValue;
                    AreaTerlarangInTanggal.ViewValue = FormatDateTime(AreaTerlarangInTanggal.ViewValue, AreaTerlarangInTanggal.FormatPattern);
                    AreaTerlarangInTanggal.ViewCustomAttributes = "";

                    // AreaTerlarangInFotoDownload
                    AreaTerlarangInFotoDownload.ViewValue = AreaTerlarangInFotoDownload.CurrentValue;
                    AreaTerlarangInFotoDownload.ViewCustomAttributes = "";

                    // AreaTerlarangInUser
                    AreaTerlarangInUser.ViewValue = ConvertToString(AreaTerlarangInUser.CurrentValue); // DN
                    AreaTerlarangInUser.ViewCustomAttributes = "";

                    // AreaTerlarangOutTanggal
                    AreaTerlarangOutTanggal.ViewValue = AreaTerlarangOutTanggal.CurrentValue;
                    AreaTerlarangOutTanggal.ViewValue = FormatDateTime(AreaTerlarangOutTanggal.ViewValue, AreaTerlarangOutTanggal.FormatPattern);
                    AreaTerlarangOutTanggal.ViewCustomAttributes = "";

                    // AreaTerlarangOutFotoDownload
                    AreaTerlarangOutFotoDownload.ViewValue = AreaTerlarangOutFotoDownload.CurrentValue;
                    AreaTerlarangOutFotoDownload.ViewCustomAttributes = "";

                    // AreaTerlarangOutUser
                    AreaTerlarangOutUser.ViewValue = ConvertToString(AreaTerlarangOutUser.CurrentValue); // DN
                    AreaTerlarangOutUser.ViewCustomAttributes = "";

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

                    // StatusZonaPrev
                    StatusZonaPrev.ViewValue = ConvertToString(StatusZonaPrev.CurrentValue); // DN
                    StatusZonaPrev.ViewCustomAttributes = "";

                // LinkRedirect
                LinkRedirect.HrefValue = "";
                LinkRedirect.TooltipValue = "";

                // Plant
                Plant.HrefValue = "";
                Plant.TooltipValue = "";

                // Tanggal
                Tanggal.HrefValue = "";
                Tanggal.TooltipValue = "";

                // StatusZona
                StatusZona.HrefValue = "";
                StatusZona.TooltipValue = "";

                // Nama
                Nama.HrefValue = "";
                Nama.TooltipValue = "";

                // AsalPerusahaan
                AsalPerusahaan.HrefValue = "";
                AsalPerusahaan.TooltipValue = "";

                // Jabatan
                Jabatan.HrefValue = "";
                Jabatan.TooltipValue = "";

                // FungsiygDikunjungi
                FungsiygDikunjungi.HrefValue = "";
                FungsiygDikunjungi.TooltipValue = "";

                // MaksudKunjungan
                MaksudKunjungan.HrefValue = "";
                MaksudKunjungan.TooltipValue = "";

                // TandaPengenal
                TandaPengenal.HrefValue = "";
                TandaPengenal.TooltipValue = "";

                // TandaTanganDownload
                TandaTanganDownload.HrefValue = "";
                TandaTanganDownload.TooltipValue = "";

                // Keterangan
                Keterangan.HrefValue = "";
                Keterangan.TooltipValue = "";

                // PintuUtamaId
                PintuUtamaId.HrefValue = "";
                PintuUtamaId.TooltipValue = "";

                // PintuUtamaInTanggal
                PintuUtamaInTanggal.HrefValue = "";
                PintuUtamaInTanggal.TooltipValue = "";

                // PintuUtamaInFotoDownload
                PintuUtamaInFotoDownload.HrefValue = "";
                PintuUtamaInFotoDownload.TooltipValue = "";

                // PintuUtamaInUser
                PintuUtamaInUser.HrefValue = "";
                PintuUtamaInUser.TooltipValue = "";

                // CustomPilihPintu
                CustomPilihPintu.HrefValue = "";
                CustomPilihPintu.TooltipValue = "";

                // PintuUtamaOutTanggal
                PintuUtamaOutTanggal.HrefValue = "";
                PintuUtamaOutTanggal.TooltipValue = "";

                // PintuUtamaOutFotoDownload
                PintuUtamaOutFotoDownload.HrefValue = "";
                PintuUtamaOutFotoDownload.TooltipValue = "";

                // PintuUtamaOutUser
                PintuUtamaOutUser.HrefValue = "";
                PintuUtamaOutUser.TooltipValue = "";

                // LobbyUtamaId
                LobbyUtamaId.HrefValue = "";
                LobbyUtamaId.TooltipValue = "";

                // LobbyUtamaInTanggal
                LobbyUtamaInTanggal.HrefValue = "";
                LobbyUtamaInTanggal.TooltipValue = "";

                // LobbyUtamaInFotoDownload
                LobbyUtamaInFotoDownload.HrefValue = "";
                LobbyUtamaInFotoDownload.TooltipValue = "";

                // LobbyUtamaInUser
                LobbyUtamaInUser.HrefValue = "";
                LobbyUtamaInUser.TooltipValue = "";

                // LobbyUtamaOutTanggal
                LobbyUtamaOutTanggal.HrefValue = "";
                LobbyUtamaOutTanggal.TooltipValue = "";

                // LobbyUtamaOutFotoDownload
                LobbyUtamaOutFotoDownload.HrefValue = "";
                LobbyUtamaOutFotoDownload.TooltipValue = "";

                // LobbyUtamaOutUser
                LobbyUtamaOutUser.HrefValue = "";
                LobbyUtamaOutUser.TooltipValue = "";

                // AreaTerlarangId
                AreaTerlarangId.HrefValue = "";
                AreaTerlarangId.TooltipValue = "";

                // AreaTerlarangInTanggal
                AreaTerlarangInTanggal.HrefValue = "";
                AreaTerlarangInTanggal.TooltipValue = "";

                // AreaTerlarangInFotoDownload
                AreaTerlarangInFotoDownload.HrefValue = "";
                AreaTerlarangInFotoDownload.TooltipValue = "";

                // AreaTerlarangInUser
                AreaTerlarangInUser.HrefValue = "";
                AreaTerlarangInUser.TooltipValue = "";

                // AreaTerlarangOutTanggal
                AreaTerlarangOutTanggal.HrefValue = "";
                AreaTerlarangOutTanggal.TooltipValue = "";

                // AreaTerlarangOutFotoDownload
                AreaTerlarangOutFotoDownload.HrefValue = "";
                AreaTerlarangOutFotoDownload.TooltipValue = "";

                // AreaTerlarangOutUser
                AreaTerlarangOutUser.HrefValue = "";
                AreaTerlarangOutUser.TooltipValue = "";

                // etlDate
                etlDate.HrefValue = "";
                etlDate.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // lastUpdatedDate
                lastUpdatedDate.HrefValue = "";
                lastUpdatedDate.TooltipValue = "";
            }

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
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
            if (UseTransaction)
                Connection.BeginTrans();
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
            if (result) {
                if (UseTransaction)
                    Connection.CommitTrans(); // Commit the changes

                // Set warning message if delete some records failed
                if (failKeys.Count > 0)
                    WarningMessage = Language.Phrase("DeleteRecordsFailed").Replace("%k", String.Join(", ", failKeys));
            } else {
                if (UseTransaction)
                    Connection.RollbackTrans(); // Rollback changes
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

        // Set up Breadcrumb
        protected void SetupBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("BukuTamuList")), "", TableVar, true);
            string pageId = "delete";
            breadcrumb.Add("delete", pageId, url);
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
    } // End page class
} // End Partial class
