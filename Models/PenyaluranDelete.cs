using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penyaluranDelete
    /// </summary>
    public static PenyaluranDelete penyaluranDelete
    {
        get => HttpData.Get<PenyaluranDelete>("penyaluranDelete")!;
        set => HttpData["penyaluranDelete"] = value;
    }

    /// <summary>
    /// Page class for Penyaluran
    /// </summary>
    public class PenyaluranDelete : PenyaluranDeleteBase
    {
        // Constructor
        public PenyaluranDelete(Controller controller) : base(controller)
        {
        }

        // Constructor
        public PenyaluranDelete() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            IdPlant.DisplayValueSeparator = " - ";
            JenisProduk.DisplayValueSeparator = " - ";
            TujuanKonsinyasi.DisplayValueSeparator = " - ";
            TujuanKonsinyasi2.DisplayValueSeparator = " - ";
            TujuanKonsinyasi3.DisplayValueSeparator = " - ";
            IdPipa.DisplayValueSeparator = " - ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class PenyaluranDeleteBase : Penyaluran
    {
        // Page ID
        public string PageID = "delete";

        // Project ID
        public string ProjectID = "{92B91853-0216-4B42-B097-FA7CDF2469EB}";

        // Page object name
        public string PageObjName = "penyaluranDelete";

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
        public PenyaluranDeleteBase(Controller? controller)
        {
            TableName = "Penyaluran";

            // Initialize
            CurrentPage = this;
        if (controller != null)
            Controller = controller;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

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
        public string PageName => "PenyaluranDelete";

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
            LinkProses.SetVisibility();
            LookupPlant.Visible = false;
            IdPlant.SetVisibility();
            TipePenyaluran.SetVisibility();
            TipeProdukSTS.SetVisibility();
            KategoriPenyaluran.SetVisibility();
            IdModa.SetVisibility();
            DetailRTW.Visible = false;
            NoShipment.Visible = false;
            IdPipa.SetVisibility();
            NomorPolisi.SetVisibility();
            NamaKapal.SetVisibility();
            JenisProduk.SetVisibility();
            IdPenimbunan.Visible = false;
            StatusProses.SetVisibility();
            IdTemplate.Visible = false;
            PersentaseProgress.SetVisibility();
            Tujuan.SetVisibility();
            TujuanKonsinyasi.SetVisibility();
            Volume.SetVisibility();
            TujuanKonsinyasiPipa.SetVisibility();
            QuantityKonsinyasiPipa.SetVisibility();
            TujuanKonsinyasi2.Visible = false;
            Volume2.Visible = false;
            TujuanKonsinyasi3.Visible = false;
            Volume3.Visible = false;
            TanggalSandar.SetVisibility();
            Catatan.Visible = false;
            DibuatOleh.SetVisibility();
            TanggalDibuat.SetVisibility();
            DiperbaruiOleh.SetVisibility();
            TanggalDiperbarui.SetVisibility();
            LookupTipeProduk.Visible = false;
            LookupJenisPlant.Visible = false;
            MultipleTujuanKonsinyasi.Visible = false;
            MultipleTujuanKonsinyasiHidden.Visible = false;
            MultipleQuantity.Visible = false;
        }

        // Constructor
        public PenyaluranDeleteBase() : this(null) { }

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
            key += UrlEncode(ConvertToString(dict.ContainsKey("IdPenyaluran") ? dict["IdPenyaluran"] : IdPenyaluran.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                IdPenyaluran.Visible = false;
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
                return Terminate("PenyaluranList");
            CurrentFilter = filter;

            // Check User ID (jika ada)
            res = await ValidateUserIdAsync(CurrentFilter);
            if (!res)
                return Terminate("PenyaluranList");

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
                return Terminate("PenyaluranList");
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
                penyaluranDelete?.PageRender();
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

            // NomorPenyaluran

            // LinkProses

            // LookupPlant

            // IdPlant

            // TipePenyaluran

            // TipeProdukSTS

            // KategoriPenyaluran

            // IdModa

            // DetailRTW
            DetailRTW.CellCssStyle = "white-space: nowrap;";

            // NoShipment
            NoShipment.CellCssStyle = "white-space: nowrap;";

            // IdPipa

            // NomorPolisi

            // NamaKapal

            // JenisProduk

            // IdPenimbunan

            // StatusProses

            // IdTemplate

            // PersentaseProgress

            // Tujuan

            // TujuanKonsinyasi

            // Volume

            // TujuanKonsinyasiPipa

            // QuantityKonsinyasiPipa

            // TujuanKonsinyasi2
            TujuanKonsinyasi2.CellCssStyle = "white-space: nowrap;";

            // Volume2
            Volume2.CellCssStyle = "white-space: nowrap;";

            // TujuanKonsinyasi3
            TujuanKonsinyasi3.CellCssStyle = "white-space: nowrap;";

            // Volume3
            Volume3.CellCssStyle = "white-space: nowrap;";

            // TanggalSandar

            // Catatan

            // DibuatOleh

            // TanggalDibuat

            // DiperbaruiOleh

            // TanggalDiperbarui

            // LookupTipeProduk
            LookupTipeProduk.CellCssStyle = "white-space: nowrap;";

            // LookupJenisPlant
            LookupJenisPlant.CellCssStyle = "white-space: nowrap;";

            // MultipleTujuanKonsinyasi

            // MultipleTujuanKonsinyasiHidden

            // MultipleQuantity

            // View row
            if (RowType == RowType.View) {
                // LookupPlant

                // IdPlant

                // TipePenyaluran

                // TipeProdukSTS

                // KategoriPenyaluran

                // IdModa

                // IdPipa

                // NomorPolisi

                // NamaKapal

                // JenisProduk

                // StatusProses

                // PersentaseProgress

                // Tujuan

                // TujuanKonsinyasi

                // Volume

                // TujuanKonsinyasiPipa

                // QuantityKonsinyasiPipa

                // TanggalSandar

                // DibuatOleh

                // TanggalDibuat

                // DiperbaruiOleh

                // TanggalDiperbarui

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

                    // awallookupbung
                    // IdPlant
                    ResolveLookupView(IdPlant, "IdPlant", "number");
                    // akhirlookupbung
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

                    // akhirlookupbung
                    TipeProdukSTS.ViewCustomAttributes = "";

                    // KategoriPenyaluran
                    if (!Empty(KategoriPenyaluran.CurrentValue)) {
                        KategoriPenyaluran.ViewValue = KategoriPenyaluran.OptionCaption(ConvertToString(KategoriPenyaluran.CurrentValue));
                    } else {
                        KategoriPenyaluran.ViewValue = DbNullValue;
                    }
                    KategoriPenyaluran.ViewCustomAttributes = "";

                    // IdModa

                    // awallookupbung
                    // IdModa
                    ResolveLookupView(IdModa, "IdModa", "number");
                    // akhirlookupbung
                    IdModa.ViewCustomAttributes = "";

                    // IdPipa

                    // awallookupbung
                    // IdPipa
                    ResolveLookupView(IdPipa, "id", "number");
                    // akhirlookupbung
                    IdPipa.ViewCustomAttributes = "";

                    // NomorPolisi
                    NomorPolisi.ViewValue = ConvertToString(NomorPolisi.CurrentValue); // DN
                    NomorPolisi.ViewCustomAttributes = "";

                    // NamaKapal
                    NamaKapal.ViewValue = ConvertToString(NamaKapal.CurrentValue); // DN
                    NamaKapal.ViewCustomAttributes = "";

                    // JenisProduk

                    // awallookupbung
                    // JenisProduk (jaga leading zero)
                    ResolveLookupView(JenisProduk, "NoProduk", "string");
                    // akhirlookupbung
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

                    // awallookupbung
                    // TujuanKonsinyasi
                    ResolveLookupView(TujuanKonsinyasi, "IdPlant", "number");
                    // akhirlookupbung
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

                // LinkProses
                LinkProses.HrefValue = "";
                LinkProses.TooltipValue = "";

                // IdPlant
                IdPlant.HrefValue = "";
                IdPlant.TooltipValue = "";

                // TipePenyaluran
                TipePenyaluran.HrefValue = "";
                TipePenyaluran.TooltipValue = "";

                // TipeProdukSTS
                TipeProdukSTS.HrefValue = "";
                TipeProdukSTS.TooltipValue = "";

                // KategoriPenyaluran
                KategoriPenyaluran.HrefValue = "";
                KategoriPenyaluran.TooltipValue = "";

                // IdModa
                IdModa.HrefValue = "";
                IdModa.TooltipValue = "";

                // IdPipa
                IdPipa.HrefValue = "";
                IdPipa.TooltipValue = "";

                // NomorPolisi
                NomorPolisi.HrefValue = "";
                NomorPolisi.TooltipValue = "";

                // NamaKapal
                NamaKapal.HrefValue = "";
                NamaKapal.TooltipValue = "";

                // JenisProduk
                JenisProduk.HrefValue = "";
                JenisProduk.TooltipValue = "";

                // StatusProses
                StatusProses.HrefValue = "";
                StatusProses.TooltipValue = "";

                // PersentaseProgress
                PersentaseProgress.HrefValue = "";
                PersentaseProgress.TooltipValue = "";

                // Tujuan
                Tujuan.HrefValue = "";
                Tujuan.TooltipValue = "";

                // TujuanKonsinyasi
                TujuanKonsinyasi.HrefValue = "";
                TujuanKonsinyasi.TooltipValue = "";

                // Volume
                Volume.HrefValue = "";
                Volume.TooltipValue = "";

                // TujuanKonsinyasiPipa
                TujuanKonsinyasiPipa.HrefValue = "";
                TujuanKonsinyasiPipa.TooltipValue = "";

                // QuantityKonsinyasiPipa
                QuantityKonsinyasiPipa.HrefValue = "";
                QuantityKonsinyasiPipa.TooltipValue = "";

                // TanggalSandar
                TanggalSandar.HrefValue = "";
                TanggalSandar.TooltipValue = "";

                // DibuatOleh
                DibuatOleh.HrefValue = "";
                DibuatOleh.TooltipValue = "";

                // TanggalDibuat
                TanggalDibuat.HrefValue = "";
                TanggalDibuat.TooltipValue = "";

                // DiperbaruiOleh
                DiperbaruiOleh.HrefValue = "";
                DiperbaruiOleh.TooltipValue = "";

                // TanggalDiperbarui
                TanggalDiperbarui.HrefValue = "";
                TanggalDiperbarui.TooltipValue = "";
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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("PenyaluranList")), "", TableVar, true);
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
