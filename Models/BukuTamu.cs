namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// bukuTamu
    /// </summary>
    [MaybeNull]
    public static BukuTamu bukuTamu
    {
        get => HttpData.Resolve<BukuTamu>("BukuTamu");
        set => HttpData["BukuTamu"] = value;
    }

    /// <summary>
    /// Table class for BukuTamu
    /// </summary>
    public class BukuTamu : DbTable
    {
        public override Dictionary<string, string> KeyFields { get; set; } = new() { // DN
            { "id", "id" },
        };

        public int RowCount = 0; // DN

        public bool UseSessionForListSql = true;

        // Column CSS classes
        public string LeftColumnClass = "col-sm-2 col-form-label ew-label";

        public string RightColumnClass = "col-sm-10";

        public string OffsetColumnClass = "col-sm-10 offset-sm-2";

        public string TableLeftColumnClass = "w-col-2";

        // Ajax / Modal
        public bool UseAjaxActions = false;

        public bool ModalSearch = false;

        public bool ModalView = false;

        public bool ModalAdd = false;

        public bool ModalEdit = false;

        public bool ModalUpdate = false;

        public bool InlineDelete = false;

        public bool ModalGridAdd = false;

        public bool ModalGridEdit = false;

        public bool ModalMultiEdit = false;

        public readonly DbField<SqlDbType> id;

        public readonly DbField<SqlDbType> NomorBukuTamu;

        public readonly DbField<SqlDbType> LinkRedirect;

        public readonly DbField<SqlDbType> LookupPlant;

        public readonly DbField<SqlDbType> Plant;

        public readonly DbField<SqlDbType> Tanggal;

        public readonly DbField<SqlDbType> StatusZona;

        public readonly DbField<SqlDbType> Nama;

        public readonly DbField<SqlDbType> AsalPerusahaan;

        public readonly DbField<SqlDbType> Jabatan;

        public readonly DbField<SqlDbType> FungsiygDikunjungi;

        public readonly DbField<SqlDbType> MaksudKunjungan;

        public readonly DbField<SqlDbType> TandaPengenal;

        public readonly DbField<SqlDbType> TandaTangan;

        public readonly DbField<SqlDbType> TandaTanganDownload;

        public readonly DbField<SqlDbType> Keterangan;

        public readonly DbField<SqlDbType> PintuUtamaId;

        public readonly DbField<SqlDbType> PintuUtamaInTanggal;

        public readonly DbField<SqlDbType> PintuUtamaInFoto;

        public readonly DbField<SqlDbType> PintuUtamaInFotoDownload;

        public readonly DbField<SqlDbType> PintuUtamaInUser;

        public readonly DbField<SqlDbType> CustomPilihPintu;

        public readonly DbField<SqlDbType> PintuUtamaOutTanggal;

        public readonly DbField<SqlDbType> PintuUtamaOutFoto;

        public readonly DbField<SqlDbType> PintuUtamaOutFotoDownload;

        public readonly DbField<SqlDbType> PintuUtamaOutUser;

        public readonly DbField<SqlDbType> LobbyUtamaId;

        public readonly DbField<SqlDbType> LobbyUtamaInTanggal;

        public readonly DbField<SqlDbType> LobbyUtamaInFoto;

        public readonly DbField<SqlDbType> LobbyUtamaInFotoDownload;

        public readonly DbField<SqlDbType> LobbyUtamaInUser;

        public readonly DbField<SqlDbType> LobbyUtamaOutTanggal;

        public readonly DbField<SqlDbType> LobbyUtamaOutFoto;

        public readonly DbField<SqlDbType> LobbyUtamaOutFotoDownload;

        public readonly DbField<SqlDbType> LobbyUtamaOutUser;

        public readonly DbField<SqlDbType> AreaTerlarangId;

        public readonly DbField<SqlDbType> AreaTerlarangInTanggal;

        public readonly DbField<SqlDbType> AreaTerlarangInFoto;

        public readonly DbField<SqlDbType> AreaTerlarangInFotoDownload;

        public readonly DbField<SqlDbType> AreaTerlarangInUser;

        public readonly DbField<SqlDbType> AreaTerlarangOutTanggal;

        public readonly DbField<SqlDbType> AreaTerlarangOutFoto;

        public readonly DbField<SqlDbType> AreaTerlarangOutFotoDownload;

        public readonly DbField<SqlDbType> AreaTerlarangOutUser;

        public readonly DbField<SqlDbType> etlDate;

        public readonly DbField<SqlDbType> LastUpdatedBy;

        public readonly DbField<SqlDbType> lastUpdatedDate;

        public readonly DbField<SqlDbType> StatusZonaPrev;

        // Constructor
        public BukuTamu()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "BukuTamu";
            Name = "BukuTamu";
            Type = "TABLE";
            UpdateTable = "dbo.BukuTamu"; // Update Table
            DbId = "DB"; // DN
            ExportAll = true;
            ExportPageBreakCount = 0; // Page break per every n record (PDF only)
            ExportPageOrientation = "portrait"; // Page orientation (PDF only)
            ExportPageSize = "a4"; // Page size (PDF only)
            ExportColumnWidths = []; // Column widths (PDF only) // DN
            ExportExcelPageOrientation = ""; // Page orientation (EPPlus only)
            ExportExcelPageSize = ""; // Page size (EPPlus only)
            ExportWordPageOrientation = ""; // Page orientation (Word only)
            DetailAdd = false; // Allow detail add
            DetailEdit = false; // Allow detail edit
            DetailView = false; // Allow detail view
            ShowMultipleDetails = false; // Show multiple details
            GridAddRowCount = 5;
            AllowAddDeleteRow = true; // Allow add/delete row
            UseAjaxActions = UseAjaxActions || Config.UseAjaxActions;
            UserIdAllowSecurity = Config.DefaultUserIdAllowSecurity; // User ID Allow

            // id
            id = new(this, "x_id", 3, SqlDbType.Int) {
                Name = "id",
                Expression = "[id]",
                BasicSearchExpression = "CAST([id] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[id]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "NO",
                InputTextType = "text",
                IsAutoIncrement = true, // Autoincrement field
                IsPrimaryKey = true, // Primary key field
                Nullable = false, // NOT NULL field
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "id", "CustomMsg"),
                IsUpload = false
            };
            id.Raw = true;
            Fields.Add("id", id);

            // NomorBukuTamu
            NomorBukuTamu = new(this, "x_NomorBukuTamu", 202, SqlDbType.NVarChar) {
                Name = "NomorBukuTamu",
                Expression = "[NomorBukuTamu]",
                BasicSearchExpression = "[NomorBukuTamu]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomorBukuTamu]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "NomorBukuTamu", "CustomMsg"),
                IsUpload = false
            };
            NomorBukuTamu.Lookup = new Lookup<DbField>(NomorBukuTamu, "BukuTamu", true, "NomorBukuTamu", new List<string> {"NomorBukuTamu", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NomorBukuTamu", NomorBukuTamu);

            // LinkRedirect
            LinkRedirect = new(this, "x_LinkRedirect", 202, SqlDbType.NVarChar) {
                Name = "LinkRedirect",
                Expression = "'<a href=bukutamuedit/' + CAST(id AS NVARCHAR(50))+'>'+CAST(NomorBukuTamu AS NVARCHAR(50))+'</a>'",
                UseBasicSearch = true,
                BasicSearchExpression = "'<a href=bukutamuedit/' + CAST(id AS NVARCHAR(50))+'>'+CAST(NomorBukuTamu AS NVARCHAR(50))+'</a>'",
                DateTimeFormat = -1,
                VirtualExpression = "'<a href=bukutamuedit/' + CAST(id AS NVARCHAR(50))+'>'+CAST(NomorBukuTamu AS NVARCHAR(50))+'</a>'",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                IsCustom = true, // Custom field
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LinkRedirect", "CustomMsg"),
                IsUpload = false
            };
            LinkRedirect.Lookup = new Lookup<DbField>(LinkRedirect, "BukuTamu", true, "LinkRedirect", new List<string> {"LinkRedirect", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LinkRedirect", LinkRedirect);

            // LookupPlant
            LookupPlant = new(this, "x_LookupPlant", 3, SqlDbType.Int) {
                Name = "LookupPlant",
                Expression = "[LookupPlant]",
                BasicSearchExpression = "CAST([LookupPlant] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[LookupPlant]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                Required = true, // Required field
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 1,
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LookupPlant", "CustomMsg"),
                IsUpload = false
            };
            LookupPlant.Raw = true;
            LookupPlant.Lookup = new Lookup<DbField>(LookupPlant, "BukuTamu", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LookupPlant", LookupPlant);

            // Plant
            Plant = new(this, "x_Plant", 3, SqlDbType.Int) {
                Name = "Plant",
                Expression = "[Plant]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([Plant] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Plant]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "Plant", "CustomMsg"),
                IsUpload = false
            };
            Plant.Raw = true;
            Plant.Lookup = new Lookup<DbField>(Plant, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, Plant) + "',[Nama_Terminal])");
            Fields.Add("Plant", Plant);

            // Tanggal
            Tanggal = new(this, "x_Tanggal", 135, SqlDbType.DateTime) {
                Name = "Tanggal",
                Expression = "[Tanggal]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[Tanggal]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[Tanggal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "Tanggal", "CustomMsg"),
                IsUpload = false
            };
            Tanggal.Raw = true;
            Tanggal.Lookup = new Lookup<DbField>(Tanggal, "BukuTamu", true, "Tanggal", new List<string> {"Tanggal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Tanggal", Tanggal);

            // StatusZona
            StatusZona = new(this, "x_StatusZona", 202, SqlDbType.NVarChar) {
                Name = "StatusZona",
                Expression = "[StatusZona]",
                UseBasicSearch = true,
                BasicSearchExpression = "[StatusZona]",
                DateTimeFormat = -1,
                VirtualExpression = "[StatusZona]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "StatusZona", "CustomMsg"),
                IsUpload = false
            };
            StatusZona.Lookup = new Lookup<DbField>(StatusZona, "BukuTamu", true, "StatusZona", new List<string> {"StatusZona", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("StatusZona", StatusZona);

            // Nama
            Nama = new(this, "x_Nama", 202, SqlDbType.NVarChar) {
                Name = "Nama",
                Expression = "[Nama]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Nama]",
                DateTimeFormat = -1,
                VirtualExpression = "[Nama]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "Nama", "CustomMsg"),
                IsUpload = false
            };
            Nama.Lookup = new Lookup<DbField>(Nama, "BukuTamu", true, "Nama", new List<string> {"Nama", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Nama", Nama);

            // AsalPerusahaan
            AsalPerusahaan = new(this, "x_AsalPerusahaan", 202, SqlDbType.NVarChar) {
                Name = "AsalPerusahaan",
                Expression = "[AsalPerusahaan]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AsalPerusahaan]",
                DateTimeFormat = -1,
                VirtualExpression = "[AsalPerusahaan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AsalPerusahaan", "CustomMsg"),
                IsUpload = false
            };
            AsalPerusahaan.Lookup = new Lookup<DbField>(AsalPerusahaan, "BukuTamu", true, "AsalPerusahaan", new List<string> {"AsalPerusahaan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("AsalPerusahaan", AsalPerusahaan);

            // Jabatan
            Jabatan = new(this, "x_Jabatan", 202, SqlDbType.NVarChar) {
                Name = "Jabatan",
                Expression = "[Jabatan]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Jabatan]",
                DateTimeFormat = -1,
                VirtualExpression = "[Jabatan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "Jabatan", "CustomMsg"),
                IsUpload = false
            };
            Jabatan.Lookup = new Lookup<DbField>(Jabatan, "BukuTamu", true, "Jabatan", new List<string> {"Jabatan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Jabatan", Jabatan);

            // FungsiygDikunjungi
            FungsiygDikunjungi = new(this, "x_FungsiygDikunjungi", 202, SqlDbType.NVarChar) {
                Name = "FungsiygDikunjungi",
                Expression = "[FungsiygDikunjungi]",
                UseBasicSearch = true,
                BasicSearchExpression = "[FungsiygDikunjungi]",
                DateTimeFormat = -1,
                VirtualExpression = "[FungsiygDikunjungi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "FungsiygDikunjungi", "CustomMsg"),
                IsUpload = false
            };
            FungsiygDikunjungi.Lookup = new Lookup<DbField>(FungsiygDikunjungi, "MasterFungsiKunjungan", true, "ID", new List<string> {"FungsiKunjungan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "[ID] ASC", "", "[FungsiKunjungan]");
            Fields.Add("FungsiygDikunjungi", FungsiygDikunjungi);

            // MaksudKunjungan
            MaksudKunjungan = new(this, "x_MaksudKunjungan", 202, SqlDbType.NVarChar) {
                Name = "MaksudKunjungan",
                Expression = "[MaksudKunjungan]",
                UseBasicSearch = true,
                BasicSearchExpression = "[MaksudKunjungan]",
                DateTimeFormat = -1,
                VirtualExpression = "[MaksudKunjungan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "MaksudKunjungan", "CustomMsg"),
                IsUpload = false
            };
            MaksudKunjungan.Lookup = new Lookup<DbField>(MaksudKunjungan, "BukuTamu", true, "MaksudKunjungan", new List<string> {"MaksudKunjungan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("MaksudKunjungan", MaksudKunjungan);

            // TandaPengenal
            TandaPengenal = new(this, "x_TandaPengenal", 202, SqlDbType.NVarChar) {
                Name = "TandaPengenal",
                Expression = "[TandaPengenal]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TandaPengenal]",
                DateTimeFormat = -1,
                VirtualExpression = "[TandaPengenal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                OptionCount = 3,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "TandaPengenal", "CustomMsg"),
                IsUpload = false
            };
            TandaPengenal.Lookup = new Lookup<DbField>(TandaPengenal, "BukuTamu", true, "TandaPengenal", new List<string> {"TandaPengenal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TandaPengenal", TandaPengenal);

            // TandaTangan
            TandaTangan = new(this, "x_TandaTangan", 202, SqlDbType.NVarChar) {
                Name = "TandaTangan",
                Expression = "[TandaTangan]",
                BasicSearchExpression = "[TandaTangan]",
                DateTimeFormat = -1,
                VirtualExpression = "[TandaTangan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "TandaTangan", "CustomMsg"),
                IsUpload = false
            };
            TandaTangan.Lookup = new Lookup<DbField>(TandaTangan, "BukuTamu", true, "TandaTangan", new List<string> {"TandaTangan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TandaTangan", TandaTangan);

            // TandaTanganDownload
            TandaTanganDownload = new(this, "x_TandaTanganDownload", 203, SqlDbType.NText) {
                Name = "TandaTanganDownload",
                Expression = "CASE WHEN TandaTangan IS NOT NULL AND LTRIM(RTRIM(TandaTangan)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'TandaTangan' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Tanda Tangan</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN TandaTangan IS NOT NULL AND LTRIM(RTRIM(TandaTangan)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'TandaTangan' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Tanda Tangan</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN TandaTangan IS NOT NULL AND LTRIM(RTRIM(TandaTangan)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'TandaTangan' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Tanda Tangan</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "TandaTanganDownload", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("TandaTanganDownload", TandaTanganDownload);

            // Keterangan
            Keterangan = new(this, "x_Keterangan", 203, SqlDbType.NText) {
                Name = "Keterangan",
                Expression = "[Keterangan]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Keterangan]",
                DateTimeFormat = -1,
                VirtualExpression = "[Keterangan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "Keterangan", "CustomMsg"),
                IsUpload = false
            };
            Keterangan.Lookup = new Lookup<DbField>(Keterangan, "BukuTamu", true, "Keterangan", new List<string> {"Keterangan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Keterangan", Keterangan);

            // PintuUtamaId
            PintuUtamaId = new(this, "x_PintuUtamaId", 202, SqlDbType.NVarChar) {
                Name = "PintuUtamaId",
                Expression = "[PintuUtamaId]",
                BasicSearchExpression = "[PintuUtamaId]",
                DateTimeFormat = -1,
                VirtualExpression = "[PintuUtamaId]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaId", "CustomMsg"),
                IsUpload = false
            };
            PintuUtamaId.Lookup = new Lookup<DbField>(PintuUtamaId, "BukuTamu", true, "PintuUtamaId", new List<string> {"PintuUtamaId", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PintuUtamaId", PintuUtamaId);

            // PintuUtamaInTanggal
            PintuUtamaInTanggal = new(this, "x_PintuUtamaInTanggal", 135, SqlDbType.DateTime) {
                Name = "PintuUtamaInTanggal",
                Expression = "[PintuUtamaInTanggal]",
                BasicSearchExpression = CastDateFieldForLike("[PintuUtamaInTanggal]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[PintuUtamaInTanggal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaInTanggal", "CustomMsg"),
                IsUpload = false
            };
            PintuUtamaInTanggal.Raw = true;
            PintuUtamaInTanggal.Lookup = new Lookup<DbField>(PintuUtamaInTanggal, "BukuTamu", true, "PintuUtamaInTanggal", new List<string> {"PintuUtamaInTanggal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PintuUtamaInTanggal", PintuUtamaInTanggal);

            // PintuUtamaInFoto
            PintuUtamaInFoto = new(this, "x_PintuUtamaInFoto", 203, SqlDbType.NText) {
                Name = "PintuUtamaInFoto",
                Expression = "[PintuUtamaInFoto]",
                BasicSearchExpression = "[PintuUtamaInFoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[PintuUtamaInFoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaInFoto", "CustomMsg"),
                IsUpload = false
            };
            PintuUtamaInFoto.Lookup = new Lookup<DbField>(PintuUtamaInFoto, "BukuTamu", true, "PintuUtamaInFoto", new List<string> {"PintuUtamaInFoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PintuUtamaInFoto", PintuUtamaInFoto);

            // PintuUtamaInFotoDownload
            PintuUtamaInFotoDownload = new(this, "x_PintuUtamaInFotoDownload", 203, SqlDbType.NText) {
                Name = "PintuUtamaInFotoDownload",
                Expression = "CASE WHEN PintuUtamaInFoto IS NOT NULL AND LTRIM(RTRIM(PintuUtamaInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'PintuUtamaInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN PintuUtamaInFoto IS NOT NULL AND LTRIM(RTRIM(PintuUtamaInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'PintuUtamaInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN PintuUtamaInFoto IS NOT NULL AND LTRIM(RTRIM(PintuUtamaInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'PintuUtamaInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaInFotoDownload", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PintuUtamaInFotoDownload", PintuUtamaInFotoDownload);

            // PintuUtamaInUser
            PintuUtamaInUser = new(this, "x_PintuUtamaInUser", 202, SqlDbType.NVarChar) {
                Name = "PintuUtamaInUser",
                Expression = "[PintuUtamaInUser]",
                UseBasicSearch = true,
                BasicSearchExpression = "[PintuUtamaInUser]",
                DateTimeFormat = -1,
                VirtualExpression = "[PintuUtamaInUser]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaInUser", "CustomMsg"),
                IsUpload = false
            };
            PintuUtamaInUser.Lookup = new Lookup<DbField>(PintuUtamaInUser, "BukuTamu", true, "PintuUtamaInUser", new List<string> {"PintuUtamaInUser", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PintuUtamaInUser", PintuUtamaInUser);

            // CustomPilihPintu
            CustomPilihPintu = new(this, "x_CustomPilihPintu", 200, SqlDbType.VarChar) {
                Name = "CustomPilihPintu",
                Expression = "''",
                UseBasicSearch = true,
                BasicSearchExpression = "''",
                DateTimeFormat = -1,
                VirtualExpression = "''",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                IsCustom = true, // Custom field
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "CustomPilihPintu", "CustomMsg"),
                IsUpload = false
            };
            CustomPilihPintu.Lookup = new Lookup<DbField>(CustomPilihPintu, "BukuTamu", true, "CustomPilihPintu", new List<string> {"CustomPilihPintu", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("CustomPilihPintu", CustomPilihPintu);

            // PintuUtamaOutTanggal
            PintuUtamaOutTanggal = new(this, "x_PintuUtamaOutTanggal", 135, SqlDbType.DateTime) {
                Name = "PintuUtamaOutTanggal",
                Expression = "[PintuUtamaOutTanggal]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[PintuUtamaOutTanggal]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[PintuUtamaOutTanggal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaOutTanggal", "CustomMsg"),
                IsUpload = false
            };
            PintuUtamaOutTanggal.Raw = true;
            PintuUtamaOutTanggal.Lookup = new Lookup<DbField>(PintuUtamaOutTanggal, "BukuTamu", true, "PintuUtamaOutTanggal", new List<string> {"PintuUtamaOutTanggal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PintuUtamaOutTanggal", PintuUtamaOutTanggal);

            // PintuUtamaOutFoto
            PintuUtamaOutFoto = new(this, "x_PintuUtamaOutFoto", 203, SqlDbType.NText) {
                Name = "PintuUtamaOutFoto",
                Expression = "[PintuUtamaOutFoto]",
                BasicSearchExpression = "[PintuUtamaOutFoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[PintuUtamaOutFoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaOutFoto", "CustomMsg"),
                IsUpload = false
            };
            PintuUtamaOutFoto.Lookup = new Lookup<DbField>(PintuUtamaOutFoto, "BukuTamu", true, "PintuUtamaOutFoto", new List<string> {"PintuUtamaOutFoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PintuUtamaOutFoto", PintuUtamaOutFoto);

            // PintuUtamaOutFotoDownload
            PintuUtamaOutFotoDownload = new(this, "x_PintuUtamaOutFotoDownload", 203, SqlDbType.NText) {
                Name = "PintuUtamaOutFotoDownload",
                Expression = "CASE WHEN PintuUtamaOutFoto IS NOT NULL AND LTRIM(RTRIM(PintuUtamaOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'PintuUtamaOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN PintuUtamaOutFoto IS NOT NULL AND LTRIM(RTRIM(PintuUtamaOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'PintuUtamaOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN PintuUtamaOutFoto IS NOT NULL AND LTRIM(RTRIM(PintuUtamaOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'PintuUtamaOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaOutFotoDownload", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PintuUtamaOutFotoDownload", PintuUtamaOutFotoDownload);

            // PintuUtamaOutUser
            PintuUtamaOutUser = new(this, "x_PintuUtamaOutUser", 202, SqlDbType.NVarChar) {
                Name = "PintuUtamaOutUser",
                Expression = "[PintuUtamaOutUser]",
                UseBasicSearch = true,
                BasicSearchExpression = "[PintuUtamaOutUser]",
                DateTimeFormat = -1,
                VirtualExpression = "[PintuUtamaOutUser]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "PintuUtamaOutUser", "CustomMsg"),
                IsUpload = false
            };
            PintuUtamaOutUser.Lookup = new Lookup<DbField>(PintuUtamaOutUser, "BukuTamu", true, "PintuUtamaOutUser", new List<string> {"PintuUtamaOutUser", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PintuUtamaOutUser", PintuUtamaOutUser);

            // LobbyUtamaId
            LobbyUtamaId = new(this, "x_LobbyUtamaId", 202, SqlDbType.NVarChar) {
                Name = "LobbyUtamaId",
                Expression = "[LobbyUtamaId]",
                UseBasicSearch = true,
                BasicSearchExpression = "[LobbyUtamaId]",
                DateTimeFormat = -1,
                VirtualExpression = "[LobbyUtamaId]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaId", "CustomMsg"),
                IsUpload = false
            };
            LobbyUtamaId.Lookup = new Lookup<DbField>(LobbyUtamaId, "BukuTamu", true, "LobbyUtamaId", new List<string> {"LobbyUtamaId", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LobbyUtamaId", LobbyUtamaId);

            // LobbyUtamaInTanggal
            LobbyUtamaInTanggal = new(this, "x_LobbyUtamaInTanggal", 135, SqlDbType.DateTime) {
                Name = "LobbyUtamaInTanggal",
                Expression = "[LobbyUtamaInTanggal]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[LobbyUtamaInTanggal]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[LobbyUtamaInTanggal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaInTanggal", "CustomMsg"),
                IsUpload = false
            };
            LobbyUtamaInTanggal.Raw = true;
            LobbyUtamaInTanggal.Lookup = new Lookup<DbField>(LobbyUtamaInTanggal, "BukuTamu", true, "LobbyUtamaInTanggal", new List<string> {"LobbyUtamaInTanggal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LobbyUtamaInTanggal", LobbyUtamaInTanggal);

            // LobbyUtamaInFoto
            LobbyUtamaInFoto = new(this, "x_LobbyUtamaInFoto", 203, SqlDbType.NText) {
                Name = "LobbyUtamaInFoto",
                Expression = "[LobbyUtamaInFoto]",
                BasicSearchExpression = "[LobbyUtamaInFoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[LobbyUtamaInFoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaInFoto", "CustomMsg"),
                IsUpload = false
            };
            LobbyUtamaInFoto.Lookup = new Lookup<DbField>(LobbyUtamaInFoto, "BukuTamu", true, "LobbyUtamaInFoto", new List<string> {"LobbyUtamaInFoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LobbyUtamaInFoto", LobbyUtamaInFoto);

            // LobbyUtamaInFotoDownload
            LobbyUtamaInFotoDownload = new(this, "x_LobbyUtamaInFotoDownload", 203, SqlDbType.NText) {
                Name = "LobbyUtamaInFotoDownload",
                Expression = "CASE WHEN LobbyUtamaInFoto IS NOT NULL AND LTRIM(RTRIM(LobbyUtamaInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'LobbyUtamaInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN LobbyUtamaInFoto IS NOT NULL AND LTRIM(RTRIM(LobbyUtamaInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'LobbyUtamaInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN LobbyUtamaInFoto IS NOT NULL AND LTRIM(RTRIM(LobbyUtamaInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'LobbyUtamaInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaInFotoDownload", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("LobbyUtamaInFotoDownload", LobbyUtamaInFotoDownload);

            // LobbyUtamaInUser
            LobbyUtamaInUser = new(this, "x_LobbyUtamaInUser", 202, SqlDbType.NVarChar) {
                Name = "LobbyUtamaInUser",
                Expression = "[LobbyUtamaInUser]",
                UseBasicSearch = true,
                BasicSearchExpression = "[LobbyUtamaInUser]",
                DateTimeFormat = -1,
                VirtualExpression = "[LobbyUtamaInUser]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaInUser", "CustomMsg"),
                IsUpload = false
            };
            LobbyUtamaInUser.Lookup = new Lookup<DbField>(LobbyUtamaInUser, "BukuTamu", true, "LobbyUtamaInUser", new List<string> {"LobbyUtamaInUser", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LobbyUtamaInUser", LobbyUtamaInUser);

            // LobbyUtamaOutTanggal
            LobbyUtamaOutTanggal = new(this, "x_LobbyUtamaOutTanggal", 135, SqlDbType.DateTime) {
                Name = "LobbyUtamaOutTanggal",
                Expression = "[LobbyUtamaOutTanggal]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[LobbyUtamaOutTanggal]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[LobbyUtamaOutTanggal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaOutTanggal", "CustomMsg"),
                IsUpload = false
            };
            LobbyUtamaOutTanggal.Raw = true;
            LobbyUtamaOutTanggal.Lookup = new Lookup<DbField>(LobbyUtamaOutTanggal, "BukuTamu", true, "LobbyUtamaOutTanggal", new List<string> {"LobbyUtamaOutTanggal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LobbyUtamaOutTanggal", LobbyUtamaOutTanggal);

            // LobbyUtamaOutFoto
            LobbyUtamaOutFoto = new(this, "x_LobbyUtamaOutFoto", 203, SqlDbType.NText) {
                Name = "LobbyUtamaOutFoto",
                Expression = "[LobbyUtamaOutFoto]",
                BasicSearchExpression = "[LobbyUtamaOutFoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[LobbyUtamaOutFoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaOutFoto", "CustomMsg"),
                IsUpload = false
            };
            LobbyUtamaOutFoto.Lookup = new Lookup<DbField>(LobbyUtamaOutFoto, "BukuTamu", true, "LobbyUtamaOutFoto", new List<string> {"LobbyUtamaOutFoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LobbyUtamaOutFoto", LobbyUtamaOutFoto);

            // LobbyUtamaOutFotoDownload
            LobbyUtamaOutFotoDownload = new(this, "x_LobbyUtamaOutFotoDownload", 203, SqlDbType.NText) {
                Name = "LobbyUtamaOutFotoDownload",
                Expression = "CASE WHEN LobbyUtamaOutFoto IS NOT NULL AND LTRIM(RTRIM(LobbyUtamaOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'LobbyUtamaOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN LobbyUtamaOutFoto IS NOT NULL AND LTRIM(RTRIM(LobbyUtamaOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'LobbyUtamaOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN LobbyUtamaOutFoto IS NOT NULL AND LTRIM(RTRIM(LobbyUtamaOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'LobbyUtamaOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaOutFotoDownload", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("LobbyUtamaOutFotoDownload", LobbyUtamaOutFotoDownload);

            // LobbyUtamaOutUser
            LobbyUtamaOutUser = new(this, "x_LobbyUtamaOutUser", 202, SqlDbType.NVarChar) {
                Name = "LobbyUtamaOutUser",
                Expression = "[LobbyUtamaOutUser]",
                UseBasicSearch = true,
                BasicSearchExpression = "[LobbyUtamaOutUser]",
                DateTimeFormat = -1,
                VirtualExpression = "[LobbyUtamaOutUser]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LobbyUtamaOutUser", "CustomMsg"),
                IsUpload = false
            };
            LobbyUtamaOutUser.Lookup = new Lookup<DbField>(LobbyUtamaOutUser, "BukuTamu", true, "LobbyUtamaOutUser", new List<string> {"LobbyUtamaOutUser", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LobbyUtamaOutUser", LobbyUtamaOutUser);

            // AreaTerlarangId
            AreaTerlarangId = new(this, "x_AreaTerlarangId", 202, SqlDbType.NVarChar) {
                Name = "AreaTerlarangId",
                Expression = "[AreaTerlarangId]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AreaTerlarangId]",
                DateTimeFormat = -1,
                VirtualExpression = "[AreaTerlarangId]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangId", "CustomMsg"),
                IsUpload = false
            };
            AreaTerlarangId.Lookup = new Lookup<DbField>(AreaTerlarangId, "BukuTamu", true, "AreaTerlarangId", new List<string> {"AreaTerlarangId", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("AreaTerlarangId", AreaTerlarangId);

            // AreaTerlarangInTanggal
            AreaTerlarangInTanggal = new(this, "x_AreaTerlarangInTanggal", 135, SqlDbType.DateTime) {
                Name = "AreaTerlarangInTanggal",
                Expression = "[AreaTerlarangInTanggal]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[AreaTerlarangInTanggal]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[AreaTerlarangInTanggal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangInTanggal", "CustomMsg"),
                IsUpload = false
            };
            AreaTerlarangInTanggal.Raw = true;
            AreaTerlarangInTanggal.Lookup = new Lookup<DbField>(AreaTerlarangInTanggal, "BukuTamu", true, "AreaTerlarangInTanggal", new List<string> {"AreaTerlarangInTanggal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("AreaTerlarangInTanggal", AreaTerlarangInTanggal);

            // AreaTerlarangInFoto
            AreaTerlarangInFoto = new(this, "x_AreaTerlarangInFoto", 203, SqlDbType.NText) {
                Name = "AreaTerlarangInFoto",
                Expression = "[AreaTerlarangInFoto]",
                BasicSearchExpression = "[AreaTerlarangInFoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[AreaTerlarangInFoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangInFoto", "CustomMsg"),
                IsUpload = false
            };
            AreaTerlarangInFoto.Lookup = new Lookup<DbField>(AreaTerlarangInFoto, "BukuTamu", true, "AreaTerlarangInFoto", new List<string> {"AreaTerlarangInFoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("AreaTerlarangInFoto", AreaTerlarangInFoto);

            // AreaTerlarangInFotoDownload
            AreaTerlarangInFotoDownload = new(this, "x_AreaTerlarangInFotoDownload", 203, SqlDbType.NText) {
                Name = "AreaTerlarangInFotoDownload",
                Expression = "CASE WHEN AreaTerlarangInFoto IS NOT NULL AND LTRIM(RTRIM(AreaTerlarangInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'AreaTerlarangInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN AreaTerlarangInFoto IS NOT NULL AND LTRIM(RTRIM(AreaTerlarangInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'AreaTerlarangInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN AreaTerlarangInFoto IS NOT NULL AND LTRIM(RTRIM(AreaTerlarangInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'AreaTerlarangInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangInFotoDownload", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AreaTerlarangInFotoDownload", AreaTerlarangInFotoDownload);

            // AreaTerlarangInUser
            AreaTerlarangInUser = new(this, "x_AreaTerlarangInUser", 202, SqlDbType.NVarChar) {
                Name = "AreaTerlarangInUser",
                Expression = "[AreaTerlarangInUser]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AreaTerlarangInUser]",
                DateTimeFormat = -1,
                VirtualExpression = "[AreaTerlarangInUser]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangInUser", "CustomMsg"),
                IsUpload = false
            };
            AreaTerlarangInUser.Lookup = new Lookup<DbField>(AreaTerlarangInUser, "BukuTamu", true, "AreaTerlarangInUser", new List<string> {"AreaTerlarangInUser", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("AreaTerlarangInUser", AreaTerlarangInUser);

            // AreaTerlarangOutTanggal
            AreaTerlarangOutTanggal = new(this, "x_AreaTerlarangOutTanggal", 135, SqlDbType.DateTime) {
                Name = "AreaTerlarangOutTanggal",
                Expression = "[AreaTerlarangOutTanggal]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[AreaTerlarangOutTanggal]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[AreaTerlarangOutTanggal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangOutTanggal", "CustomMsg"),
                IsUpload = false
            };
            AreaTerlarangOutTanggal.Raw = true;
            AreaTerlarangOutTanggal.Lookup = new Lookup<DbField>(AreaTerlarangOutTanggal, "BukuTamu", true, "AreaTerlarangOutTanggal", new List<string> {"AreaTerlarangOutTanggal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("AreaTerlarangOutTanggal", AreaTerlarangOutTanggal);

            // AreaTerlarangOutFoto
            AreaTerlarangOutFoto = new(this, "x_AreaTerlarangOutFoto", 203, SqlDbType.NText) {
                Name = "AreaTerlarangOutFoto",
                Expression = "[AreaTerlarangOutFoto]",
                BasicSearchExpression = "[AreaTerlarangOutFoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[AreaTerlarangOutFoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangOutFoto", "CustomMsg"),
                IsUpload = false
            };
            AreaTerlarangOutFoto.Lookup = new Lookup<DbField>(AreaTerlarangOutFoto, "BukuTamu", true, "AreaTerlarangOutFoto", new List<string> {"AreaTerlarangOutFoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("AreaTerlarangOutFoto", AreaTerlarangOutFoto);

            // AreaTerlarangOutFotoDownload
            AreaTerlarangOutFotoDownload = new(this, "x_AreaTerlarangOutFotoDownload", 203, SqlDbType.NText) {
                Name = "AreaTerlarangOutFotoDownload",
                Expression = "CASE WHEN AreaTerlarangOutFoto IS NOT NULL AND LTRIM(RTRIM(AreaTerlarangOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'AreaTerlarangOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN AreaTerlarangOutFoto IS NOT NULL AND LTRIM(RTRIM(AreaTerlarangOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'AreaTerlarangOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN AreaTerlarangOutFoto IS NOT NULL AND LTRIM(RTRIM(AreaTerlarangOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'AreaTerlarangOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangOutFotoDownload", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AreaTerlarangOutFotoDownload", AreaTerlarangOutFotoDownload);

            // AreaTerlarangOutUser
            AreaTerlarangOutUser = new(this, "x_AreaTerlarangOutUser", 202, SqlDbType.NVarChar) {
                Name = "AreaTerlarangOutUser",
                Expression = "[AreaTerlarangOutUser]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AreaTerlarangOutUser]",
                DateTimeFormat = -1,
                VirtualExpression = "[AreaTerlarangOutUser]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "AreaTerlarangOutUser", "CustomMsg"),
                IsUpload = false
            };
            AreaTerlarangOutUser.Lookup = new Lookup<DbField>(AreaTerlarangOutUser, "BukuTamu", true, "AreaTerlarangOutUser", new List<string> {"AreaTerlarangOutUser", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("AreaTerlarangOutUser", AreaTerlarangOutUser);

            // etlDate
            etlDate = new(this, "x_etlDate", 135, SqlDbType.DateTime) {
                Name = "etlDate",
                Expression = "[etlDate]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[etlDate]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[etlDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "etlDate", "CustomMsg"),
                IsUpload = false
            };
            etlDate.Raw = true;
            etlDate.Lookup = new Lookup<DbField>(etlDate, "BukuTamu", true, "etlDate", new List<string> {"etlDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("etlDate", etlDate);

            // LastUpdatedBy
            LastUpdatedBy = new(this, "x_LastUpdatedBy", 202, SqlDbType.NVarChar) {
                Name = "LastUpdatedBy",
                Expression = "[LastUpdatedBy]",
                UseBasicSearch = true,
                BasicSearchExpression = "[LastUpdatedBy]",
                DateTimeFormat = -1,
                VirtualExpression = "[LastUpdatedBy]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "LastUpdatedBy", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedBy.Lookup = new Lookup<DbField>(LastUpdatedBy, "BukuTamu", true, "LastUpdatedBy", new List<string> {"LastUpdatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LastUpdatedBy", LastUpdatedBy);

            // lastUpdatedDate
            lastUpdatedDate = new(this, "x_lastUpdatedDate", 135, SqlDbType.DateTime) {
                Name = "lastUpdatedDate",
                Expression = "[lastUpdatedDate]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[lastUpdatedDate]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[lastUpdatedDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "lastUpdatedDate", "CustomMsg"),
                IsUpload = false
            };
            lastUpdatedDate.Raw = true;
            lastUpdatedDate.Lookup = new Lookup<DbField>(lastUpdatedDate, "BukuTamu", true, "lastUpdatedDate", new List<string> {"lastUpdatedDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("lastUpdatedDate", lastUpdatedDate);

            // StatusZonaPrev
            StatusZonaPrev = new(this, "x_StatusZonaPrev", 202, SqlDbType.NVarChar) {
                Name = "StatusZonaPrev",
                Expression = "[StatusZonaPrev]",
                BasicSearchExpression = "[StatusZonaPrev]",
                DateTimeFormat = -1,
                VirtualExpression = "[StatusZonaPrev]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("BukuTamu", "StatusZonaPrev", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("StatusZonaPrev", StatusZonaPrev);

            // Call Table Load event
            TableLoad();
        }

        #pragma warning disable 618
        // Connection
        public override DatabaseConnection<SqlConnection, SqlDbType> Connection => GetConnection(DbId);
        #pragma warning restore 618

        // Set Field Visibility
        public override bool GetFieldVisibility(string fldname)
        {
            var fld = FieldByName(fldname);
            return fld?.Visible ?? false; // Returns original value
        }

        // Set left column class (must be predefined col-*-* classes of Bootstrap grid system)
        public void SetLeftColumnClass(string columnClass)
        {
            Match m = Regex.Match(columnClass, @"^col\-(\w+)\-(\d+)$");
            if (m.Success) {
                LeftColumnClass = columnClass + " col-form-label ew-label";
                RightColumnClass = "col-" + m.Groups[1].Value + "-" + ConvertToString(12 - ConvertToInt(m.Groups[2].Value));
                OffsetColumnClass = RightColumnClass + " " + columnClass.Replace("col-", "offset-");
                TableLeftColumnClass = Regex.Replace(columnClass, @"/^col-\w+-(\d+)$/", "w-col-$1"); // Change to w-col-*
            }
        }

        // Multiple column sort
        public void UpdateSort(DbField fld, bool ctrl)
        {
            string sortField, lastSort, curSort, orderBy, lastOrderBy, curOrderBy;
            if (CurrentOrder == fld.Name) {
                sortField = fld.Expression;
                lastSort = fld.Sort;
                if ((new[] { "ASC", "DESC", "NO" }).Contains(CurrentOrderType)) {
                    curSort = CurrentOrderType;
                } else {
                    curSort = lastSort;
                }
                lastOrderBy = (new[] { "ASC", "DESC" }).Contains(lastSort) ? sortField + " " + lastSort : "";
                curOrderBy = (new[] { "ASC", "DESC" }).Contains(curSort) ? sortField + " " + curSort : "";
                if (ctrl) {
                    orderBy = SessionOrderBy;
                    List<string> listOrderBy = !Empty(orderBy) ? orderBy.Split([", "], StringSplitOptions.None).ToList() : new();
                    if (!Empty(lastOrderBy) && listOrderBy.Contains(lastOrderBy)) {
                        if (Empty(curOrderBy)) {
                            listOrderBy.Remove(lastOrderBy);
                        } else {
                            var index = listOrderBy.IndexOf(lastOrderBy);
                            listOrderBy[index] = curOrderBy;
                        }
                    } else if (!Empty(curOrderBy)) {
                        listOrderBy.Add(curOrderBy);
                    }
                    orderBy = String.Join(", ", listOrderBy);
                    SessionOrderBy = orderBy; // Save to Session
                } else {
                    SessionOrderBy = curOrderBy; // Save to Session
                }
            }
        }

        // Update field sort
        public void UpdateFieldSort()
        {
            string orderBy = SessionOrderBy; // Get ORDER BY from Session
            var flds = GetSortFields(orderBy);
            foreach (var (key, field) in Fields) {
                string fldSort = "";
                foreach (var fld in flds) {
                    if (fld[0] == field.Expression || fld[0] == field.VirtualExpression)
                        fldSort = fld[1];
                }
                field.Sort = fldSort;
            }
        }

        // Current master table name
        public string CurrentMasterTable
        {
            get => Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableMasterTable);
            set => Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableMasterTable] = value;
        }

        // Current detail table name
        public string CurrentDetailTable
        {
            get => Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableDetailTable);
            set => Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableDetailTable] = value;
        }

        #pragma warning disable 1998
        // Render X Axis for chart
        public async Task<Dictionary<string, object>> RenderChartXAxis(string chartVar, Dictionary<string, object> chartRow)
        {
            return chartRow;
        }
        #pragma warning restore 1998

        // Table level SQL
        // FROM
        private string? _sqlFrom = null;

        public string SqlFrom
        {
            get => _sqlFrom ?? "dbo.BukuTamu";
            set => _sqlFrom = value;
        }

        // SELECT
        private string? _sqlSelect = null;

        public string SqlSelect
        {
            get => _sqlSelect ?? "SELECT " + SqlSelectFields + " FROM " + SqlFrom;
            set => _sqlSelect = value;
        }

        private string SqlSelectFields
        {
            get {
                string select = "*, '<a href=bukutamuedit/' + CAST(id AS NVARCHAR(50))+'>'+CAST(NomorBukuTamu AS NVARCHAR(50))+'</a>' AS [LinkRedirect], CASE WHEN TandaTangan IS NOT NULL AND LTRIM(RTRIM(TandaTangan)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'TandaTangan' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Tanda Tangan</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END AS [TandaTanganDownload], CASE WHEN PintuUtamaInFoto IS NOT NULL AND LTRIM(RTRIM(PintuUtamaInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'PintuUtamaInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END AS [PintuUtamaInFotoDownload], '' AS [CustomPilihPintu], CASE WHEN PintuUtamaOutFoto IS NOT NULL AND LTRIM(RTRIM(PintuUtamaOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'PintuUtamaOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END AS [PintuUtamaOutFotoDownload], CASE WHEN LobbyUtamaInFoto IS NOT NULL AND LTRIM(RTRIM(LobbyUtamaInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'LobbyUtamaInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END AS [LobbyUtamaInFotoDownload], CASE WHEN LobbyUtamaOutFoto IS NOT NULL AND LTRIM(RTRIM(LobbyUtamaOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'LobbyUtamaOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END AS [LobbyUtamaOutFotoDownload], CASE WHEN AreaTerlarangInFoto IS NOT NULL AND LTRIM(RTRIM(AreaTerlarangInFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'AreaTerlarangInFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END AS [AreaTerlarangInFotoDownload], CASE WHEN AreaTerlarangOutFoto IS NOT NULL AND LTRIM(RTRIM(AreaTerlarangOutFoto)) <> '' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' data-id=' + CAST(id AS NVARCHAR(255)) + ' data-field=' + CHAR(34) + 'AreaTerlarangOutFoto' + CHAR(34) + '><i class=' + CHAR(34) + 'fas fa-download me-2' + CHAR(34) + '></i> Download Foto</a>' ELSE '<p id=' + CAST(id AS NVARCHAR(255)) + '>Not Uploaded</p>' END AS [AreaTerlarangOutFotoDownload]";
                if (select == "*") {
                    bool useFieldNames = false; // Reserved, not used
                    List<string> fieldNames = [];
                    foreach (var (key, fld) in Fields) {
                        string expr = fld.Expression;
                        fieldNames.Add(expr);
                    }
                    if (useFieldNames)
                        select = String.Join(", ", fieldNames);
                }
                return select;
            }
        }

        // WHERE // DN
        private string? _sqlWhere = null;

        public string SqlWhere
        {
            get {
                string where = "";
                return _sqlWhere ?? where;
            }
            set {
                _sqlWhere = value;
            }
        }

        // Group By
        private string? _sqlGroupBy = null;

        public string SqlGroupBy
        {
            get => _sqlGroupBy ?? "";
            set => _sqlGroupBy = value;
        }

        // Having
        private string? _sqlHaving = null;

        public string SqlHaving
        {
            get => _sqlHaving ?? "";
            set => _sqlHaving = value;
        }

        // Order By
        private string? _sqlOrderBy = null;

        public string SqlOrderBy
        {
            get => _sqlOrderBy ?? "";
            set => _sqlOrderBy = value;
        }

        // Apply User ID filters
        public string ApplyUserIDFilters(string filter, string id = "")
        {
            return filter;
        }

        // Check if User ID security allows view all
        public bool UserIDAllow(string id = "")
        {
            int allow = UserIdAllowSecurity;
            return id switch {
                "add" => ((allow & 1) == 1),
                "copy" => ((allow & 1) == 1),
                "gridadd" => ((allow & 1) == 1),
                "register" => ((allow & 1) == 1),
                "addopt" => ((allow & 1) == 1),
                "edit" => ((allow & 4) == 4),
                "gridedit" => ((allow & 4) == 4),
                "update" => ((allow & 4) == 4),
                "changepassword" => ((allow & 4) == 4),
                "resetpassword" => ((allow & 4) == 4),
                "delete" => ((allow & 2) == 2),
                "view" => ((allow & 32) == 32),
                "search" => ((allow & 64) == 64),
                "lookup" => ((allow & 256) == 256),
                _ => ((allow & 8) == 8)
            };
        }

        /// <summary>
        /// Get record count by reading data reader (Async) // DN
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="c">Connection</param>
        /// <returns>Record count</returns>
        public async Task<int> GetRecordCountAsync(string sql, dynamic? c = null) {
            try {
                var cnt = 0;
                var conn = c ?? Connection;
                using var dr = await conn.ExecuteReaderAsync(sql, main: false);
                if (dr != null) {
                    while (await dr.ReadAsync())
                        cnt++;
                }
                return cnt;
            } catch {
                if (Config.Debug)
                    throw;
                return -1;
            }
        }

        /// <summary>
        /// Get record count by reading data reader // DN
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="c">Connection</param>
        /// <returns>Record count</returns>
        public int GetRecordCount(string sql, dynamic? c = null) => GetRecordCountAsync(sql, c).GetAwaiter().GetResult();

        /// <summary>
        /// Try to get record count by SELECT COUNT(*) (Async) // DN
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="c">Connection</param>
        /// <returns>Record count</returns>
        public async Task<int> TryGetRecordCountAsync(string sql, dynamic? c = null)
        {
            string orderBy = OrderBy;
            var conn = c ?? Connection;
            sql = Regex.Replace(sql, @"/\*BeginOrderBy\*/[\s\S]+/\*EndOrderBy\*/", "", RegexOptions.IgnoreCase).Trim(); // Remove ORDER BY clause (MSSQL)
            if (!Empty(orderBy) && sql.EndsWith(orderBy))
                sql = sql.Substring(0, sql.Length - orderBy.Length); // Remove ORDER BY clause
            try {
                string sqlcnt;
                if ((new[] { "TABLE", "VIEW", "LINKTABLE" }).Contains(Type) && sql.StartsWith(SqlSelect)) { // Handle Custom Field
                    sqlcnt = "SELECT COUNT(*) FROM " + SqlFrom + sql.Substring(SqlSelect.Length);
                } else {
                    sqlcnt = "SELECT COUNT(*) FROM (" + sql + ") EW_COUNT_TABLE";
                }
                return await conn?.ExecuteScalarAsync<int>(sqlcnt) ?? 0;
            } catch {
                return await GetRecordCountAsync(sql, conn);
            }
        }

        /// <summary>
        /// Try to get record count by SELECT COUNT(*) // DN
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="c">Connection</param>
        /// <returns>Record count</returns>
        public int TryGetRecordCount(string sql, dynamic? c = null) => TryGetRecordCountAsync(sql, c).GetAwaiter().GetResult();

        // Get SQL
        public string GetSql(string where, string orderBy = "") => BuildSelectSql(SqlSelect, SqlWhere, SqlGroupBy, SqlHaving, SqlOrderBy, where, orderBy);

        // Table SQL
        public string CurrentSql
        {
            get {
                string filter = CurrentFilter;
                filter = ApplyUserIDFilters(filter); // Add User ID filter
                string sort = SessionOrderBy;
                return GetSql(filter, sort);
            }
        }

        // Table SQL with List page filter
        public string ListSql
        {
            get {
                string sort = "";
                string select = "";
                string filter = UseSessionForListSql ? SessionWhere : "";
                AddFilter(ref filter, CurrentFilter);
                RecordsetSelecting(ref filter);
                filter = ApplyUserIDFilters(filter); // Add User ID filter
                select = SqlSelect;
                sort = UseSessionForListSql ? SessionOrderBy : "";
                return BuildSelectSql(select, SqlWhere, SqlGroupBy, SqlHaving, SqlOrderBy, filter, sort);
            }
        }

        // Get ORDER BY clause
        public string OrderBy
        {
            get {
                string sort = SessionOrderBy;
                return BuildSelectSql("", "", "", "", SqlOrderBy, "", sort);
            }
        }

        /// <summary>
        /// Get record count based on filter (for detail record count in master table pages) (Async) // DN
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Record count</returns>
        public async Task<int> LoadRecordCountAsync(string filter) => await TryGetRecordCountAsync(GetSql(filter));

        /// <summary>
        /// Get record count based on filter (for detail record count in master table pages) // DN
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Record count</returns>
        public int LoadRecordCount(string filter) => TryGetRecordCount(GetSql(filter));

        /// <summary>
        /// Get record count (for current List page) (Async) // DN
        /// </summary>
        /// <returns>Record count</returns>
        public async Task<int> ListRecordCountAsync() => await TryGetRecordCountAsync(ListSql);

        /// <summary>
        /// Get record count (for current List page) // DN
        /// </summary>
        /// <returns>Record count</returns>
        public int ListRecordCount() => TryGetRecordCount(ListSql);

        /// <summary>
        /// Inserts the specified entity into the database and returns the ID
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity</typeparam>
        /// <typeparam name="T">The type of the ID (int)</typeparam>
        /// <param name="entity">The entity to be inserted</param>
        /// <param name="transaction">Optional transaction for the command</param>
        /// <param name="timeout">Timeout period</param>
        /// <param name="main">Use main connection or not</param>
        /// <returns>The ID of the inserted entity</returns>
        public override T InsertGetId<TEntity, T>(TEntity entity, IDbTransaction? transaction = null, int? timeout = null, bool main = false)
            where TEntity : class
        {
            var row = BuildDictionaryFromObject(entity, Crud.Create);
            var queryBuilder = GetQueryBuilder(main);
            T id = queryBuilder.InsertGetId<T>(row, transaction ?? GetTransaction(main), timeout);
            var prop = typeof(TEntity).GetRuntimeProperties().FirstOrDefault(p => p.GetCustomAttribute(typeof(ColumnAttribute)) is ColumnAttribute attr &&
                attr.Name == "id");
            prop?.SetValue(entity, id);
            return id;
        }

        /// <summary>
        /// Inserts the specified entity into the database and returns the ID
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity</typeparam>
        /// <typeparam name="T">The type of the ID (int)</typeparam>
        /// <param name="entity">The entity to be inserted</param>
        /// <param name="transaction">Optional transaction for the command</param>
        /// <param name="timeout">Timeout period</param>
        /// <param name="cancellationToken">Optional cancellation token for the command</param>
        /// <param name="main">Use main connection or not</param>
        /// <returns>The ID of the inserted entity</returns>
        public override async Task<T> InsertGetIdAsync<TEntity, T>(TEntity entity, IDbTransaction? transaction = null, int? timeout = null, CancellationToken cancellationToken = default, bool main = false)
            where TEntity : class
        {
            var row = BuildDictionaryFromObject(entity, Crud.Create);
            var queryBuilder = GetQueryBuilder(main);
            T id = await queryBuilder.InsertGetIdAsync<T>(row, transaction ?? GetTransaction(main), timeout, cancellationToken);
            var prop = typeof(TEntity).GetRuntimeProperties().FirstOrDefault(p => p.GetCustomAttribute(typeof(ColumnAttribute)) is ColumnAttribute attr &&
                attr.Name == "id");
            prop?.SetValue(entity, id);
            return id;
        }

        /// <summary>
        /// Insert (Async)
        /// </summary>
        /// <param name="data">Data to be inserted (IDictionary|Anonymous)</param>
        /// <returns>Row affected</returns>
        public async Task<int> InsertAsync(object data)
        {
            int result = 0;
            IDictionary<string, object> row;
            if (data is IDictionary<string, object> d)
                row = d;
            else if (IsAnonymousType(data))
                row = ConvertToDictionary<object>(data);
            else if (IsEntity(data))
                row = BuildDictionaryFromObject(data, Crud.Create).ToDictionary();
            else
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.BukuTamu type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                if (row.ContainsKey("id"))
                    row["id"] = lastInsertedId;
                else
                    row.Add("id", lastInsertedId);
                id.SetDbValue(lastInsertedId);
                result = 1;
            } catch (Exception e) {
                CurrentPage?.SetFailureMessage(e.Message);
                if (Config.Debug)
                    throw;
            }
            return result;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="data">Data to be inserted (IDictionary|Anonymous)</param>
        /// <returns>Row affected</returns>
        public int Insert(object data) => InsertAsync(data).GetAwaiter().GetResult();

        /// <summary>
        /// Update (Async)
        /// </summary>
        /// <param name="data">Data (with primary key) to be updated (IDictionary|Anonymous)</param>
        /// <returns>Row affected</returns>
        public async Task<int> UpdateAsync(object data)
        {
            IDictionary<string, object> row;
            if (data is IDictionary<string, object> d)
                row = d;
            else if (IsAnonymousType(data))
                row = ConvertToDictionary<object>(data);
            else
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> type", "data");
            var where = GetRowFilter(row);
            if (where != null) {
                foreach (string key in where.Keys)
                    row.Remove(key);
                return await UpdateAsync(row, where);
            }
            return -1; // Prevent update all record
        }

        /// <summary>
        /// Update (Async)
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <returns>Row affected</returns>
        public async Task<int> UpdateAsync(object data, object? where) => await UpdateAsync(data, where, null);

        #pragma warning disable 168, 219
        /// <summary>
        /// Update (Async)
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous)</param>
        /// <param name="rsold">Old record</param>
        /// <returns>Row affected</returns>
        public async Task<int> UpdateAsync(object data, object? where, Dictionary<string, object>? rsold)
        {
            int result = -1;
            IDictionary<string, object> row;
            if (data is IDictionary<string, object> d)
                row = d;
            else if (IsAnonymousType(data))
                row = ConvertToDictionary<object>(data);
            else if (IsEntity(data))
                row = BuildDictionaryFromObject(data, Crud.Update).ToDictionary();
            else
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.BukuTamu type", "data");
            Dictionary<string, object> rscascade = new();
            row = row.Where(kvp => FieldByName(kvp.Key) is DbField fld && !fld.IsCustom).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            string filter = CurrentFilter;
            if (!Empty(filter))
                queryBuilder.WhereRaw(filter);
            if (IsAnonymousType(where))
                queryBuilder.Where(where);
            else if (where is IDictionary<string, object> dict)
                queryBuilder.Where(dict);
            else if (where is string)
                queryBuilder.WhereRaw((string)where);
            if (GetRowFilter(rsold) is IDictionary<string, object> rowFilter) // Add filter from old record
                queryBuilder.Where(rowFilter);
            if (queryBuilder.HasComponent("where")) // Prevent update all records
                result = await queryBuilder.UpdateAsync(row);
            return result;
        }
        #pragma warning restore 168, 219

        /// <summary>
        /// Gather a list of key-values representing the properties of the object and their values
        /// </summary>
        /// <param name="data">The plain C# object</param>
        /// <param name="crud">Operation</param>
        /// <returns></returns>
        public override Dictionary<string, object> BuildDictionaryFromObject(object data, Crud crud = Crud.None)
        {
            var dictionary = new Dictionary<string, object>();
            var props = data.GetType().GetRuntimeProperties().ToArray();
            foreach (var property in props) {
                if (property.IsDefined(typeof(IgnoreAttribute)))
                    continue;
                var colAttr = property.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute;
                var fldName = colAttr?.Name ?? property.Name;
                if (!Fields.TryGetValue(fldName, out DbField? fld) || fld == null || fld.IsCustom || (crud == Crud.Create || crud == Crud.Update) && fld.IsAutoIncrement)
                    continue;
                if (crud == Crud.Update && colAttr is KeyAttribute)
                    continue;
                var value = property.GetValue(data);
                if (crud == Crud.Create || crud == Crud.Update) {
                    var dbType = ((DbField<SqlDbType>)fld).DbType;
                    if (dbType == SqlDbType.VarBinary || dbType == SqlDbType.Binary || dbType == SqlDbType.Image)
                        value = new SqlBinaryParameter(value, fld.Nullable); // Cannot update to null directly (Dapper/Microsoft.Data.SqlClient bug?)
                    if ((fld.DataType == DataType.String || fld.DataType == DataType.Memo) && value is string s && !Empty(s)) {
                        if (fld.IsEncrypted)
                            value = AesEncrypt(s);
                        else if (!fld.Raw)
                            value = RemoveXss(s);
                        if (fld.UserValues != null) {
                            if (fld.IsEnum) {
                                if (!fld.UserValues.Contains(s))
                                    throw new ArgumentException($"Invalid {fld.Name} value");
                            } else if (fld.IsSet && s.Split(Config.MultipleOptionSeparator) is IList list) {
                                foreach (var v in list) {
                                    if (!fld.UserValues.Contains(v))
                                        throw new ArgumentException($"Invalid {fld.Name} value");
                                }
                            }
                        }
                    }
                }
                dictionary.Add(fld.Name, value!);
            }
            return dictionary;
        }

        /// <summary>
        /// Convert entity values
        /// </summary>
        /// <param name="entity">Entity returned by Dapper</param>
        /// <returns>Entity</returns>
        [return: NotNullIfNotNull("entity")]
        public override TEntity? ConvertEntity<TEntity>(TEntity? entity)
            where TEntity : class
        {
            if (entity == null)
                return null;
            var props = entity.GetType().GetRuntimeProperties();
            foreach (var property in props) {
                var colAttr = property.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute;
                var fldName = colAttr?.Name ?? property.Name;
                if (!Fields.TryGetValue(fldName, out DbField? fld) || fld == null || fld.IsCustom || fld.IsAutoIncrement)
                    continue;
                if (((DbField<SqlDbType>)fld).DbType == SqlDbType.Timestamp)
                    continue;
                var value = property.GetValue(entity);
                if ((fld.DataType == DataType.String || fld.DataType == DataType.Memo) && value is string s && !Empty(s)) {
                    if (fld.IsEncrypted)
                        property.SetValue(entity, AesDecrypt(s));
                    else if (!fld.Raw)
                        property.SetValue(entity, HtmlDecode(s));
                }
            }
            return entity;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data">Data (with primary key) to be updated (IDictionary|Anonymous)</param>
        /// <returns>Row affected</returns>
        public int Update(object data) => UpdateAsync(data).GetAwaiter().GetResult();

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <returns>Row affected</returns>
        public int Update(object data, object where) => UpdateAsync(data, where).GetAwaiter().GetResult();

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <param name="rsold">Old record</param>
        /// <returns>Row affected</returns>
        public int Update(object data, object where, Dictionary<string, object> rsold) => UpdateAsync(data, where, rsold).GetAwaiter().GetResult();

        #pragma warning disable 168, 1998
        /// <summary>
        /// Delete (Async)
        /// </summary>
        /// <param name="data">Data to be removed (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <returns>Row affected</returns>
        public async Task<int> DeleteAsync(object? data, object? where = null)
        {
            bool delete = true;
            IDictionary<string, object>? row = null;
            if (data is IDictionary<string, object> d)
                row = d;
            else if (IsAnonymousType(data))
                row = ConvertToDictionary<object>(data);
            else if (IsEntity(data))
                row = BuildDictionaryFromObject(data, Crud.Delete).ToDictionary();
            else
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.BukuTamu type", "data");
            var queryBuilder = GetQueryBuilder(true); // Use main connection
            if (GetRowFilter(row) is IDictionary<string, object> rowFilter)
                queryBuilder.Where(rowFilter);
            if (IsAnonymousType(where))
                queryBuilder.Where(where);
            else if (where is IDictionary<string, object> dict)
                queryBuilder.Where(dict);
            else if (where is string)
                queryBuilder.WhereRaw((string)where);
            int result = delete && queryBuilder.HasComponent("where") // Avoid delete if no WHERE clause
                ? await queryBuilder.DeleteAsync(Connection.Transaction)
                : -1;
            return result;
        }
        #pragma warning restore 168, 1998

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="data">Data to be removed (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <returns>Row affected</returns>
        public int Delete(object data, object? where = null) => DeleteAsync(data, where).GetAwaiter().GetResult();

        // Load DbValue from recordset
        public void LoadDbValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
            try {
                id.DbValue = row["id"]; // Set DB value only
                NomorBukuTamu.DbValue = row["NomorBukuTamu"]; // Set DB value only
                LinkRedirect.DbValue = row["LinkRedirect"]; // Set DB value only
                LookupPlant.DbValue = row["LookupPlant"]; // Set DB value only
                Plant.DbValue = row["Plant"]; // Set DB value only
                Tanggal.DbValue = row["Tanggal"]; // Set DB value only
                StatusZona.DbValue = row["StatusZona"]; // Set DB value only
                Nama.DbValue = row["Nama"]; // Set DB value only
                AsalPerusahaan.DbValue = row["AsalPerusahaan"]; // Set DB value only
                Jabatan.DbValue = row["Jabatan"]; // Set DB value only
                FungsiygDikunjungi.DbValue = row["FungsiygDikunjungi"]; // Set DB value only
                MaksudKunjungan.DbValue = row["MaksudKunjungan"]; // Set DB value only
                TandaPengenal.DbValue = row["TandaPengenal"]; // Set DB value only
                TandaTangan.DbValue = row["TandaTangan"]; // Set DB value only
                TandaTanganDownload.DbValue = row["TandaTanganDownload"]; // Set DB value only
                Keterangan.DbValue = row["Keterangan"]; // Set DB value only
                PintuUtamaId.DbValue = row["PintuUtamaId"]; // Set DB value only
                PintuUtamaInTanggal.DbValue = row["PintuUtamaInTanggal"]; // Set DB value only
                PintuUtamaInFoto.DbValue = row["PintuUtamaInFoto"]; // Set DB value only
                PintuUtamaInFotoDownload.DbValue = row["PintuUtamaInFotoDownload"]; // Set DB value only
                PintuUtamaInUser.DbValue = row["PintuUtamaInUser"]; // Set DB value only
                CustomPilihPintu.DbValue = row["CustomPilihPintu"]; // Set DB value only
                PintuUtamaOutTanggal.DbValue = row["PintuUtamaOutTanggal"]; // Set DB value only
                PintuUtamaOutFoto.DbValue = row["PintuUtamaOutFoto"]; // Set DB value only
                PintuUtamaOutFotoDownload.DbValue = row["PintuUtamaOutFotoDownload"]; // Set DB value only
                PintuUtamaOutUser.DbValue = row["PintuUtamaOutUser"]; // Set DB value only
                LobbyUtamaId.DbValue = row["LobbyUtamaId"]; // Set DB value only
                LobbyUtamaInTanggal.DbValue = row["LobbyUtamaInTanggal"]; // Set DB value only
                LobbyUtamaInFoto.DbValue = row["LobbyUtamaInFoto"]; // Set DB value only
                LobbyUtamaInFotoDownload.DbValue = row["LobbyUtamaInFotoDownload"]; // Set DB value only
                LobbyUtamaInUser.DbValue = row["LobbyUtamaInUser"]; // Set DB value only
                LobbyUtamaOutTanggal.DbValue = row["LobbyUtamaOutTanggal"]; // Set DB value only
                LobbyUtamaOutFoto.DbValue = row["LobbyUtamaOutFoto"]; // Set DB value only
                LobbyUtamaOutFotoDownload.DbValue = row["LobbyUtamaOutFotoDownload"]; // Set DB value only
                LobbyUtamaOutUser.DbValue = row["LobbyUtamaOutUser"]; // Set DB value only
                AreaTerlarangId.DbValue = row["AreaTerlarangId"]; // Set DB value only
                AreaTerlarangInTanggal.DbValue = row["AreaTerlarangInTanggal"]; // Set DB value only
                AreaTerlarangInFoto.DbValue = row["AreaTerlarangInFoto"]; // Set DB value only
                AreaTerlarangInFotoDownload.DbValue = row["AreaTerlarangInFotoDownload"]; // Set DB value only
                AreaTerlarangInUser.DbValue = row["AreaTerlarangInUser"]; // Set DB value only
                AreaTerlarangOutTanggal.DbValue = row["AreaTerlarangOutTanggal"]; // Set DB value only
                AreaTerlarangOutFoto.DbValue = row["AreaTerlarangOutFoto"]; // Set DB value only
                AreaTerlarangOutFotoDownload.DbValue = row["AreaTerlarangOutFotoDownload"]; // Set DB value only
                AreaTerlarangOutUser.DbValue = row["AreaTerlarangOutUser"]; // Set DB value only
                etlDate.DbValue = row["etlDate"]; // Set DB value only
                LastUpdatedBy.DbValue = row["LastUpdatedBy"]; // Set DB value only
                lastUpdatedDate.DbValue = row["lastUpdatedDate"]; // Set DB value only
                StatusZonaPrev.DbValue = row["StatusZonaPrev"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[id] = @id@";

        #pragma warning disable 168, 219
        // Get record filter as string
        public string GetRecordFilter(Dictionary<string, object>? row = null, bool current = false)
        {
            string keyFilter = _sqlKeyFilter;
            object? val = null, result = "";
            foreach (var (fldName, fldParm) in KeyFields) {
                var fld = FieldByName(fldName);
                if (fld == null)
                    throw new Exception($"Field '{fldName}' not found");
                val = row?.TryGetValue(fldName, out result) ?? false
                    ? result
                    : !Empty(fld.OldValue) && !current ? fld.OldValue : fld.CurrentValue;
                if (fld.DataType == DataType.Number && !IsNumeric(val))
                    return "0=1"; // Invalid key
                if (fld.DataType == DataType.Date)
                    val = UnformatDateTime(val, fld.FormatPattern);
                if (val == null)
                    return "0=1"; // Invalid key
                keyFilter = keyFilter.Replace($"@{fldParm}@", AdjustSql(val, DbId)); // Replace key value
            }
            return keyFilter;
        }

        // Get record filter as Dictionary // DN
        public override Dictionary<string, object>? GetRowFilter(object? data = null, bool remove = false)
        {
            if (data == null)
                return null;
            var row = ConvertToDictionary<object>(data);
            Dictionary<string, object>? keyFilter = new();
            foreach (var (fldName, fldParm) in KeyFields) {
                object? val = row.TryGetValue(fldName, out object? result) ? result : null;
                if (Empty(val) || FieldByName(fldName)?.DataType == DataType.Number && !IsNumeric(val)) // Invalid key
                    return null;
                keyFilter.Add(fldName, val); // Add key value
                if (remove && data is IDictionary<string, object> dict)
                    dict.Remove(fldName);
            }
            return keyFilter.Count > 0 ? keyFilter : null;
        }

        // Get record filter as Dictionary // DN
        public override Dictionary<string, object>? GetRowFilter(object[]? ids = null)
        {
            if (ids == null || ids.Length != KeyFields.Count)
                return null;
            Dictionary<string, object>? keyFilter = new();
            int i = 0;
            foreach (var (fldName, fldParm) in KeyFields) {
                object val = ids[i++];
                if (Empty(val) || FieldByName(fldName)?.DataType == DataType.Number && !IsNumeric(val)) // Invalid key
                    return null;
                keyFilter.Add(fldName, val); // Add key value
            }
            return keyFilter.Count > 0 ? keyFilter : null;
        }

        // Return URL
        public string ReturnUrl
        {
            get {
                string name = Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl;
                // Get referer URL automatically
                if (!Empty(ReferUrl()) && !SameText(ReferPage(), CurrentPageName()) &&
                    !SameText(ReferPage(), "login")) {// Referer not same page or login page
                        Session[name] = ReferUrl(); // Save to Session
                }
                if (!Empty(Session[name])) {
                    return Session.GetString(name);
                } else {
                    return "BukuTamuList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            return pageName switch {
                "BukuTamuView" => Language.Phrase("View"),
                "BukuTamuEdit" => Language.Phrase("Edit"),
                "BukuTamuAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "BukuTamuList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "BukuTamuView",
                Config.ApiAddAction => "BukuTamuAdd",
                Config.ApiEditAction => "BukuTamuEdit",
                Config.ApiDeleteAction => "BukuTamuDelete",
                Config.ApiListAction => "BukuTamuList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "BukuTamuView",
                Config.ApiAddAction => "BukuTamuAdd",
                Config.ApiEditAction => "BukuTamuEdit",
                Config.ApiDeleteAction => "BukuTamuDelete",
                Config.ApiListAction => "BukuTamuList",
                _ => String.Empty
            };
        }

        // Current URL
        public string GetCurrentUrl(string parm = "")
        {
            string url = CurrentPageName();
            if (!Empty(parm))
                url = KeyUrl(url, parm);
            else
                url = KeyUrl(url, Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // List URL
        public string ListUrl => "BukuTamuList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("BukuTamuView", parm);
            else
                url = KeyUrl("BukuTamuView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "BukuTamuAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "BukuTamuAdd?" + parm;
            else
                url = "BukuTamuAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("BukuTamuEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("BukuTamuList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("BukuTamuAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("BukuTamuList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("BukuTamuDelete", parm)); // DN
        }

        // Delete URL
        public string DeleteUrl => GetDeleteUrl();

        // Add master URL
        public string AddMasterUrl(string url)
        {
            return url;
        }

        // Get primary key as JSON
        public string KeyToJson(bool htmlEncode = false)
        {
            string json = "";
            json += "\"id\":" + ConvertToJson(id.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL // DN
        public string KeyUrl(string url, string parm = "")
        {
            if (!IsNull(id.CurrentValue)) {
                url += "/" + id.CurrentValue;
            } else {
                return "javascript:ew.alert(ew.language.phrase('InvalidRecord'));";
            }
            if (Empty(parm))
                return url;
            else
                return url + "?" + parm;
        }

        // Render sort
        public string RenderFieldHeader(DbField fld)
        {
            string sortUrl = "";
            string attrs = "";
            if (CurrentPageID() != "grid" && fld.Sortable) {
                sortUrl = SortUrl(fld);
                attrs = " role=\"button\" data-ew-action=\"sort\" data-ajax=\"" + (UseAjaxActions ? "true" : "false") + "\" data-sort-url=\"" + sortUrl + "\" data-sort-type=\"2\"";
                if (!Empty(ContextClass)) // Add context
                    attrs += " data-context=\"" + HtmlEncode(ContextClass) + "\"";
            }
            string html = "<div class=\"ew-table-header-caption\"" + attrs + ">" + fld.Caption + "</div>";
            if (!Empty(sortUrl)) {
                html += "<div class=\"ew-table-header-sort\">" + fld.SortIcon + "</div>";
            }
            if (CurrentPageID() != "grid" && !IsExport() && fld.UseFilter && Security.CanSearch) {
                html += "<div class=\"ew-filter-dropdown-btn\" data-ew-action=\"filter\" data-table=\"" + fld.TableVar + "\" data-field=\"" + fld.FieldVar +
                    "\"><div class=\"ew-table-header-filter\" role=\"button\" aria-haspopup=\"true\">" + Language.Phrase("Filter") +
                    (IsList(fld.EditValue) ? Language.Phrase("FilterCount").Replace("%c", ((IList)fld.EditValue).Count.ToString()) : "") +
                    "</div></div>";
            }
            html = "<div class=\"ew-table-header-btn\">" + html + "</div>";
            if (UseCustomTemplate) {
                string scriptId = ("tpc_{id}").Replace("{id}", fld.TableVar + "_" + fld.Param);
                html = "<template id=\"" + scriptId + "\">" + html + "</template>";
            }
            return html;
        }

        // Sort URL (already URL-encoded)
        public string SortUrl(DbField fld)
        {
            if (!Empty(CurrentAction) || !Empty(Export) ||
                ((int[])[141, 201, 203, 128, 204, 205]).Contains(fld.Type)) { // Unsortable data type
                return "";
            } else if (fld.Sortable) {
                string urlParm = "order=" + UrlEncode(fld.Name) + "&amp;ordertype=" + fld.NextSort;
                if (!Empty(DashboardReport))
                    urlParm += "&amp;" + Config.PageDashboard + "=true";
                return AddMasterUrl(CurrentDashboardPageUrl() + "?" + urlParm);
            }
            return "";
        }

        #pragma warning disable 168, 219
        // Get key as string
        public string GetKey(bool current = false, string? keySeparator = null)
        {
            List<string> keys = [];
            string val;
            string sep = keySeparator ?? Config.CompositeKeySeparator;
            foreach (var (fldName, fldParm) in KeyFields) {
                val = current ? ConvertToString(FieldByName(fldName)?.CurrentValue) : ConvertToString(FieldByName(fldName)?.OldValue);
                if (Empty(val))
                    return String.Empty;
                keys.Add(val);
            }
            return String.Join(sep, keys);
        }

        // Get record filter as string // DN
        public string GetKey(IDictionary<string, object> row)
        {
            List<string> keys = [];
            object? val = null, result;
            foreach (var (fldName, fldParm) in KeyFields) {
                val = row?.TryGetValue(fldName, out result) ?? false ? ConvertToString(result) : null;
                if (Empty(val))
                    return String.Empty; // Invalid key
                keys.Add(ConvertToString(val)); // Add key value
            }
            return String.Join(Config.CompositeKeySeparator, keys);
        }
        #pragma warning restore 168, 219

        // Set key
        public void SetKey(string key, bool current = false, string? keySeparator = null)
        {
            OldKey = key;
            string sep = keySeparator ?? Config.CompositeKeySeparator;
            string[] keys = OldKey.Split(Convert.ToChar(sep));
            if (keys.Length == KeyFields.Count) {
                for (int i = 0; i < KeyFields.Count; i++) {
                    var fld = FieldByName(KeyFields.ElementAt(i).Key);
                    if (fld != null) {
                        if (current)
                            fld.CurrentValue = keys[i];
                        else
                            fld.OldValue = keys[i];
                    }
                }
            }
        }

        #pragma warning disable 168
        // Get record keys
        public List<string> GetRecordKeys()
        {
            List<string> result = new();
            StringValues sv;
            List<string> keysList = new();
            if (Post("key_m[]", out sv) || Get("key_m[]", out sv)) { // DN
                keysList = ((StringValues)sv).Select(k => ConvertToString(k)).ToList();
            } else if (RouteValues.Count > 0 || Query.Count > 0 || Form.Count > 0) { // DN
                string key = "";
                string[] keyValues = {};
                if (IsApi() && RouteValues.TryGetValue("key", out object? k)) {
                    string str = ConvertToString(k);
                    keyValues = str.Split('/');
                }
                if (RouteValues.TryGetValue("id", out object? v0)) { // id // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("id");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (KeyFields.Count > 1 && (!IsArray(keys) || keys.Length != KeyFields.Count))
                    continue;
                if (!IsNumeric(keys)) // id
                    continue;
                result.Add(keys);
            }
            return result;
        }
        #pragma warning restore 168

        // Get filter from records
        public string GetFilterFromRecords(IEnumerable<Dictionary<string, object>> rows) =>
            String.Join(" OR ", rows.Select(row => "(" + GetRecordFilter(row) + ")"));

        // Get filter from record keys
        public string GetFilterFromRecordKeys(bool setCurrent = true)
        {
            List<string> recordKeys = GetRecordKeys();
            string keyFilter = "";
            foreach (var keys in recordKeys) {
                if (!Empty(keyFilter))
                    keyFilter += " OR ";
                if (setCurrent)
                    id.CurrentValue = keys;
                else
                    id.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        // Load row values from recordset
        public void LoadListRowValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
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

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "BukuTamuList";
            dynamic? page = CreateInstance(pageName, [Controller]); // DN
            if (page != null) {
                page.UseLayout = false; // DN
                await page.LoadRecordsetFromFilter(filter);
                string html = await GetViewOutput(pageName, null, page, false);
                page.Terminate(); // Terminate page and clean up
                return html;
            }
            return "";
        }

        #pragma warning disable 1998
        // Render list row values
        public async Task RenderListRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes

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
            string curVal2 = ConvertToString(Plant.CurrentValue);
            Plant.ViewValue = Empty(curVal2) ? DbNullValue : Plant.CurrentValue;
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
                    }
                }
            }

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
            string curVal3 = ConvertToString(FungsiygDikunjungi.CurrentValue);
            FungsiygDikunjungi.ViewValue = Empty(curVal3) ? DbNullValue : FungsiygDikunjungi.CurrentValue;
            if (!Empty(curVal3)) {
                if (FungsiygDikunjungi.Lookup != null && IsDictionary(FungsiygDikunjungi.Lookup?.Options) && FungsiygDikunjungi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    FungsiygDikunjungi.ViewValue = FungsiygDikunjungi.LookupCacheOption(curVal3);
                } else { // Lookup from database // DN
                    string filterWrk3 = SearchFilter(FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchExpression, "=", FungsiygDikunjungi.CurrentValue, FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchDataType, "");
                    string? sqlWrk3 = FungsiygDikunjungi.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk3?.Count > 0 && FungsiygDikunjungi.Lookup != null) { // Lookup values found
                        var listwrk = FungsiygDikunjungi.Lookup?.RenderViewRow(rswrk3[0]);
                        FungsiygDikunjungi.ViewValue = FungsiygDikunjungi.DisplayValue(listwrk);
                    }
                }
            }

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

            // PintuUtamaInFoto
            PintuUtamaInFoto.ViewValue = PintuUtamaInFoto.CurrentValue;
            PintuUtamaInFoto.ViewCustomAttributes = "";

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

            // PintuUtamaOutFoto
            PintuUtamaOutFoto.ViewValue = PintuUtamaOutFoto.CurrentValue;
            PintuUtamaOutFoto.ViewCustomAttributes = "";

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

            // LobbyUtamaInFoto
            LobbyUtamaInFoto.ViewValue = LobbyUtamaInFoto.CurrentValue;
            LobbyUtamaInFoto.ViewCustomAttributes = "";

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

            // LobbyUtamaOutFoto
            LobbyUtamaOutFoto.ViewValue = LobbyUtamaOutFoto.CurrentValue;
            LobbyUtamaOutFoto.ViewCustomAttributes = "";

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

            // AreaTerlarangInFoto
            AreaTerlarangInFoto.ViewValue = AreaTerlarangInFoto.CurrentValue;
            AreaTerlarangInFoto.ViewCustomAttributes = "";

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

            // AreaTerlarangOutFoto
            AreaTerlarangOutFoto.ViewValue = AreaTerlarangOutFoto.CurrentValue;
            AreaTerlarangOutFoto.ViewCustomAttributes = "";

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

            // id
            id.HrefValue = "";
            id.TooltipValue = "";

            // NomorBukuTamu
            NomorBukuTamu.HrefValue = "";
            NomorBukuTamu.TooltipValue = "";

            // LinkRedirect
            LinkRedirect.HrefValue = "";
            LinkRedirect.TooltipValue = "";

            // LookupPlant
            LookupPlant.HrefValue = "";
            LookupPlant.TooltipValue = "";

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

            // TandaTangan
            TandaTangan.HrefValue = "";
            TandaTangan.TooltipValue = "";

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

            // PintuUtamaInFoto
            PintuUtamaInFoto.HrefValue = "";
            PintuUtamaInFoto.TooltipValue = "";

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

            // PintuUtamaOutFoto
            PintuUtamaOutFoto.HrefValue = "";
            PintuUtamaOutFoto.TooltipValue = "";

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

            // LobbyUtamaInFoto
            LobbyUtamaInFoto.HrefValue = "";
            LobbyUtamaInFoto.TooltipValue = "";

            // LobbyUtamaInFotoDownload
            LobbyUtamaInFotoDownload.HrefValue = "";
            LobbyUtamaInFotoDownload.TooltipValue = "";

            // LobbyUtamaInUser
            LobbyUtamaInUser.HrefValue = "";
            LobbyUtamaInUser.TooltipValue = "";

            // LobbyUtamaOutTanggal
            LobbyUtamaOutTanggal.HrefValue = "";
            LobbyUtamaOutTanggal.TooltipValue = "";

            // LobbyUtamaOutFoto
            LobbyUtamaOutFoto.HrefValue = "";
            LobbyUtamaOutFoto.TooltipValue = "";

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

            // AreaTerlarangInFoto
            AreaTerlarangInFoto.HrefValue = "";
            AreaTerlarangInFoto.TooltipValue = "";

            // AreaTerlarangInFotoDownload
            AreaTerlarangInFotoDownload.HrefValue = "";
            AreaTerlarangInFotoDownload.TooltipValue = "";

            // AreaTerlarangInUser
            AreaTerlarangInUser.HrefValue = "";
            AreaTerlarangInUser.TooltipValue = "";

            // AreaTerlarangOutTanggal
            AreaTerlarangOutTanggal.HrefValue = "";
            AreaTerlarangOutTanggal.TooltipValue = "";

            // AreaTerlarangOutFoto
            AreaTerlarangOutFoto.HrefValue = "";
            AreaTerlarangOutFoto.TooltipValue = "";

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

            // StatusZonaPrev
            StatusZonaPrev.HrefValue = "";
            StatusZonaPrev.TooltipValue = "";

            // Call Row Rendered event
            RowRendered();

            // Save data for Custom Template
            Rows.Add(CustomTemplateFieldValues());
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Render edit row values
        public async Task RenderEditRow()
        {
            // Call Row Rendering event
            RowRendering();

            // id
            id.SetupEditAttributes();
            id.EditValue = id.CurrentValue;
            id.ViewCustomAttributes = "";

            // NomorBukuTamu
            NomorBukuTamu.SetupEditAttributes();
            NomorBukuTamu.EditValue = ConvertToString(NomorBukuTamu.CurrentValue); // DN
            NomorBukuTamu.ViewCustomAttributes = "";

            // LinkRedirect
            LinkRedirect.SetupEditAttributes();
            LinkRedirect.EditValue = ConvertToString(LinkRedirect.CurrentValue); // DN
            LinkRedirect.ViewCustomAttributes = "";

            // LookupPlant
            LookupPlant.SetupEditAttributes();
            LookupPlant.EditValue = LookupPlant.Options(true);
            LookupPlant.PlaceHolder = RemoveHtml(LookupPlant.Caption);
            if (!Empty(LookupPlant.EditValue) && IsNumeric(LookupPlant.EditValue))
                LookupPlant.EditValue = FormatNumber(LookupPlant.EditValue, null);

            // Plant
            Plant.SetupEditAttributes();
            Plant.EditValue = Plant.CurrentValue;

            // awallookupbung
            string curVal2 = ConvertToString(Plant.CurrentValue);
            Plant.EditValue = Empty(curVal2) ? DbNullValue : Plant.CurrentValue;
            if (!Empty(curVal2)) {
                if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Plant.EditValue = Plant.LookupCacheOption(curVal2);
                } else { // Lookup from database // DN
                    string filterWrk2 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk2 = Plant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk2?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                        var listwrk = Plant.Lookup?.RenderViewRow(rswrk2[0]);
                        Plant.EditValue = Plant.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            Plant.ViewCustomAttributes = "";

            // Tanggal
            Tanggal.SetupEditAttributes();
            Tanggal.EditValue = Tanggal.CurrentValue;
            Tanggal.EditValue = FormatDateTime(Tanggal.EditValue, Tanggal.FormatPattern);
            Tanggal.ViewCustomAttributes = "";

            // StatusZona
            StatusZona.SetupEditAttributes();
            StatusZona.EditValue = ConvertToString(StatusZona.CurrentValue); // DN
            StatusZona.ViewCustomAttributes = "";

            // Nama
            Nama.SetupEditAttributes();
            Nama.EditValue = ConvertToString(Nama.CurrentValue); // DN
            Nama.ViewCustomAttributes = "";

            // AsalPerusahaan
            AsalPerusahaan.SetupEditAttributes();
            AsalPerusahaan.EditValue = ConvertToString(AsalPerusahaan.CurrentValue); // DN
            AsalPerusahaan.ViewCustomAttributes = "";

            // Jabatan
            Jabatan.SetupEditAttributes();
            Jabatan.EditValue = ConvertToString(Jabatan.CurrentValue); // DN
            Jabatan.ViewCustomAttributes = "";

            // FungsiygDikunjungi
            FungsiygDikunjungi.SetupEditAttributes();

            // awallookupbung
            string curVal3 = ConvertToString(FungsiygDikunjungi.CurrentValue);
            FungsiygDikunjungi.EditValue = Empty(curVal3) ? DbNullValue : FungsiygDikunjungi.CurrentValue;
            if (!Empty(curVal3)) {
                if (FungsiygDikunjungi.Lookup != null && IsDictionary(FungsiygDikunjungi.Lookup?.Options) && FungsiygDikunjungi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    FungsiygDikunjungi.EditValue = FungsiygDikunjungi.LookupCacheOption(curVal3);
                } else { // Lookup from database // DN
                    string filterWrk3 = SearchFilter(FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchExpression, "=", FungsiygDikunjungi.CurrentValue, FungsiygDikunjungi.Lookup?.GetTable()?.Fields["ID"].SearchDataType, "");
                    string? sqlWrk3 = FungsiygDikunjungi.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk3?.Count > 0 && FungsiygDikunjungi.Lookup != null) { // Lookup values found
                        var listwrk = FungsiygDikunjungi.Lookup?.RenderViewRow(rswrk3[0]);
                        FungsiygDikunjungi.EditValue = FungsiygDikunjungi.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            FungsiygDikunjungi.ViewCustomAttributes = "";

            // MaksudKunjungan
            MaksudKunjungan.SetupEditAttributes();
            MaksudKunjungan.EditValue = ConvertToString(MaksudKunjungan.CurrentValue); // DN
            MaksudKunjungan.ViewCustomAttributes = "";

            // TandaPengenal
            TandaPengenal.SetupEditAttributes();
            if (!Empty(TandaPengenal.CurrentValue)) {
                TandaPengenal.EditValue = TandaPengenal.OptionCaption(ConvertToString(TandaPengenal.CurrentValue));
            } else {
                TandaPengenal.EditValue = DbNullValue;
            }
            TandaPengenal.ViewCustomAttributes = "";

            // TandaTangan
            TandaTangan.SetupEditAttributes();
            TandaTangan.EditValue = TandaTangan.CurrentValue; // DN
            TandaTangan.PlaceHolder = RemoveHtml(TandaTangan.Caption);

            // TandaTanganDownload
            TandaTanganDownload.SetupEditAttributes();
            TandaTanganDownload.EditValue = TandaTanganDownload.CurrentValue; // DN
            TandaTanganDownload.PlaceHolder = RemoveHtml(TandaTanganDownload.Caption);

            // Keterangan
            Keterangan.SetupEditAttributes();
            Keterangan.EditValue = Keterangan.CurrentValue; // DN
            Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

            // PintuUtamaId
            PintuUtamaId.SetupEditAttributes();
            if (!PintuUtamaId.Raw)
                PintuUtamaId.CurrentValue = HtmlDecode(PintuUtamaId.CurrentValue);
            PintuUtamaId.EditValue = PintuUtamaId.CurrentValue;
            PintuUtamaId.PlaceHolder = RemoveHtml(PintuUtamaId.Caption);

            // PintuUtamaInTanggal
            PintuUtamaInTanggal.SetupEditAttributes();
            PintuUtamaInTanggal.EditValue = FormatDateTime(PintuUtamaInTanggal.CurrentValue, PintuUtamaInTanggal.FormatPattern);
            PintuUtamaInTanggal.PlaceHolder = RemoveHtml(PintuUtamaInTanggal.Caption);

            // PintuUtamaInFoto
            PintuUtamaInFoto.SetupEditAttributes();
            PintuUtamaInFoto.EditValue = PintuUtamaInFoto.CurrentValue; // DN
            PintuUtamaInFoto.PlaceHolder = RemoveHtml(PintuUtamaInFoto.Caption);

            // PintuUtamaInFotoDownload
            PintuUtamaInFotoDownload.SetupEditAttributes();
            PintuUtamaInFotoDownload.EditValue = PintuUtamaInFotoDownload.CurrentValue; // DN
            PintuUtamaInFotoDownload.PlaceHolder = RemoveHtml(PintuUtamaInFotoDownload.Caption);

            // PintuUtamaInUser
            PintuUtamaInUser.SetupEditAttributes();
            PintuUtamaInUser.EditValue = ConvertToString(PintuUtamaInUser.CurrentValue); // DN
            PintuUtamaInUser.ViewCustomAttributes = "";

            // CustomPilihPintu
            CustomPilihPintu.SetupEditAttributes();
            if (!CustomPilihPintu.Raw)
                CustomPilihPintu.CurrentValue = HtmlDecode(CustomPilihPintu.CurrentValue);
            CustomPilihPintu.EditValue = CustomPilihPintu.CurrentValue;
            CustomPilihPintu.PlaceHolder = RemoveHtml(CustomPilihPintu.Caption);

            // PintuUtamaOutTanggal
            PintuUtamaOutTanggal.SetupEditAttributes();
            PintuUtamaOutTanggal.EditValue = FormatDateTime(PintuUtamaOutTanggal.CurrentValue, PintuUtamaOutTanggal.FormatPattern);
            PintuUtamaOutTanggal.PlaceHolder = RemoveHtml(PintuUtamaOutTanggal.Caption);

            // PintuUtamaOutFoto
            PintuUtamaOutFoto.SetupEditAttributes();
            PintuUtamaOutFoto.EditValue = PintuUtamaOutFoto.CurrentValue; // DN
            PintuUtamaOutFoto.PlaceHolder = RemoveHtml(PintuUtamaOutFoto.Caption);

            // PintuUtamaOutFotoDownload
            PintuUtamaOutFotoDownload.SetupEditAttributes();
            PintuUtamaOutFotoDownload.EditValue = PintuUtamaOutFotoDownload.CurrentValue; // DN
            PintuUtamaOutFotoDownload.PlaceHolder = RemoveHtml(PintuUtamaOutFotoDownload.Caption);

            // PintuUtamaOutUser
            PintuUtamaOutUser.SetupEditAttributes();
            PintuUtamaOutUser.EditValue = ConvertToString(PintuUtamaOutUser.CurrentValue); // DN
            PintuUtamaOutUser.ViewCustomAttributes = "";

            // LobbyUtamaId
            LobbyUtamaId.SetupEditAttributes();
            if (!LobbyUtamaId.Raw)
                LobbyUtamaId.CurrentValue = HtmlDecode(LobbyUtamaId.CurrentValue);
            LobbyUtamaId.EditValue = LobbyUtamaId.CurrentValue;
            LobbyUtamaId.PlaceHolder = RemoveHtml(LobbyUtamaId.Caption);

            // LobbyUtamaInTanggal
            LobbyUtamaInTanggal.SetupEditAttributes();
            LobbyUtamaInTanggal.EditValue = FormatDateTime(LobbyUtamaInTanggal.CurrentValue, LobbyUtamaInTanggal.FormatPattern);
            LobbyUtamaInTanggal.PlaceHolder = RemoveHtml(LobbyUtamaInTanggal.Caption);

            // LobbyUtamaInFoto
            LobbyUtamaInFoto.SetupEditAttributes();
            LobbyUtamaInFoto.EditValue = LobbyUtamaInFoto.CurrentValue; // DN
            LobbyUtamaInFoto.PlaceHolder = RemoveHtml(LobbyUtamaInFoto.Caption);

            // LobbyUtamaInFotoDownload
            LobbyUtamaInFotoDownload.SetupEditAttributes();
            LobbyUtamaInFotoDownload.EditValue = LobbyUtamaInFotoDownload.CurrentValue; // DN
            LobbyUtamaInFotoDownload.PlaceHolder = RemoveHtml(LobbyUtamaInFotoDownload.Caption);

            // LobbyUtamaInUser
            LobbyUtamaInUser.SetupEditAttributes();
            LobbyUtamaInUser.EditValue = ConvertToString(LobbyUtamaInUser.CurrentValue); // DN
            LobbyUtamaInUser.ViewCustomAttributes = "";

            // LobbyUtamaOutTanggal
            LobbyUtamaOutTanggal.SetupEditAttributes();
            LobbyUtamaOutTanggal.EditValue = FormatDateTime(LobbyUtamaOutTanggal.CurrentValue, LobbyUtamaOutTanggal.FormatPattern);
            LobbyUtamaOutTanggal.PlaceHolder = RemoveHtml(LobbyUtamaOutTanggal.Caption);

            // LobbyUtamaOutFoto
            LobbyUtamaOutFoto.SetupEditAttributes();
            LobbyUtamaOutFoto.EditValue = LobbyUtamaOutFoto.CurrentValue; // DN
            LobbyUtamaOutFoto.PlaceHolder = RemoveHtml(LobbyUtamaOutFoto.Caption);

            // LobbyUtamaOutFotoDownload
            LobbyUtamaOutFotoDownload.SetupEditAttributes();
            LobbyUtamaOutFotoDownload.EditValue = LobbyUtamaOutFotoDownload.CurrentValue; // DN
            LobbyUtamaOutFotoDownload.PlaceHolder = RemoveHtml(LobbyUtamaOutFotoDownload.Caption);

            // LobbyUtamaOutUser
            LobbyUtamaOutUser.SetupEditAttributes();
            LobbyUtamaOutUser.EditValue = ConvertToString(LobbyUtamaOutUser.CurrentValue); // DN
            LobbyUtamaOutUser.ViewCustomAttributes = "";

            // AreaTerlarangId
            AreaTerlarangId.SetupEditAttributes();
            if (!AreaTerlarangId.Raw)
                AreaTerlarangId.CurrentValue = HtmlDecode(AreaTerlarangId.CurrentValue);
            AreaTerlarangId.EditValue = AreaTerlarangId.CurrentValue;
            AreaTerlarangId.PlaceHolder = RemoveHtml(AreaTerlarangId.Caption);

            // AreaTerlarangInTanggal
            AreaTerlarangInTanggal.SetupEditAttributes();
            AreaTerlarangInTanggal.EditValue = FormatDateTime(AreaTerlarangInTanggal.CurrentValue, AreaTerlarangInTanggal.FormatPattern);
            AreaTerlarangInTanggal.PlaceHolder = RemoveHtml(AreaTerlarangInTanggal.Caption);

            // AreaTerlarangInFoto
            AreaTerlarangInFoto.SetupEditAttributes();
            AreaTerlarangInFoto.EditValue = AreaTerlarangInFoto.CurrentValue; // DN
            AreaTerlarangInFoto.PlaceHolder = RemoveHtml(AreaTerlarangInFoto.Caption);

            // AreaTerlarangInFotoDownload
            AreaTerlarangInFotoDownload.SetupEditAttributes();
            AreaTerlarangInFotoDownload.EditValue = AreaTerlarangInFotoDownload.CurrentValue; // DN
            AreaTerlarangInFotoDownload.PlaceHolder = RemoveHtml(AreaTerlarangInFotoDownload.Caption);

            // AreaTerlarangInUser
            AreaTerlarangInUser.SetupEditAttributes();
            AreaTerlarangInUser.EditValue = ConvertToString(AreaTerlarangInUser.CurrentValue); // DN
            AreaTerlarangInUser.ViewCustomAttributes = "";

            // AreaTerlarangOutTanggal
            AreaTerlarangOutTanggal.SetupEditAttributes();
            AreaTerlarangOutTanggal.EditValue = FormatDateTime(AreaTerlarangOutTanggal.CurrentValue, AreaTerlarangOutTanggal.FormatPattern);
            AreaTerlarangOutTanggal.PlaceHolder = RemoveHtml(AreaTerlarangOutTanggal.Caption);

            // AreaTerlarangOutFoto
            AreaTerlarangOutFoto.SetupEditAttributes();
            AreaTerlarangOutFoto.EditValue = AreaTerlarangOutFoto.CurrentValue; // DN
            AreaTerlarangOutFoto.PlaceHolder = RemoveHtml(AreaTerlarangOutFoto.Caption);

            // AreaTerlarangOutFotoDownload
            AreaTerlarangOutFotoDownload.SetupEditAttributes();
            AreaTerlarangOutFotoDownload.EditValue = AreaTerlarangOutFotoDownload.CurrentValue; // DN
            AreaTerlarangOutFotoDownload.PlaceHolder = RemoveHtml(AreaTerlarangOutFotoDownload.Caption);

            // AreaTerlarangOutUser
            AreaTerlarangOutUser.SetupEditAttributes();
            AreaTerlarangOutUser.EditValue = ConvertToString(AreaTerlarangOutUser.CurrentValue); // DN
            AreaTerlarangOutUser.ViewCustomAttributes = "";

            // etlDate
            etlDate.SetupEditAttributes();
            etlDate.EditValue = etlDate.CurrentValue;
            etlDate.EditValue = FormatDateTime(etlDate.EditValue, etlDate.FormatPattern);
            etlDate.ViewCustomAttributes = "";

            // LastUpdatedBy
            LastUpdatedBy.SetupEditAttributes();
            LastUpdatedBy.EditValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
            LastUpdatedBy.ViewCustomAttributes = "";

            // lastUpdatedDate
            lastUpdatedDate.SetupEditAttributes();
            lastUpdatedDate.EditValue = lastUpdatedDate.CurrentValue;
            lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.EditValue, lastUpdatedDate.FormatPattern);
            lastUpdatedDate.ViewCustomAttributes = "";

            // StatusZonaPrev
            StatusZonaPrev.SetupEditAttributes();
            if (!StatusZonaPrev.Raw)
                StatusZonaPrev.CurrentValue = HtmlDecode(StatusZonaPrev.CurrentValue);
            StatusZonaPrev.EditValue = StatusZonaPrev.CurrentValue;
            StatusZonaPrev.PlaceHolder = RemoveHtml(StatusZonaPrev.Caption);

            // Call Row Rendered event
            RowRendered();
        }
        #pragma warning restore 1998

        // Aggregate list row values
        public void AggregateListRowValues()
        {
        }

        #pragma warning disable 1998
        // Aggregate list row (for rendering)
        public async Task AggregateListRow()
        {
            // Call Row Rendered event
            RowRendered();
        }
        #pragma warning restore 1998

        // Export data in HTML/CSV/Word/Excel/Email/PDF format
        public async Task ExportDocument(dynamic doc, DbDataReader dataReader, int startRec, int stopRec, string exportType = "")
        {
            if (doc == null)
                return;
            if (dataReader == null)
                return;
            if (!doc.ExportCustom) {
                // Write header
                doc.ExportTableHeader();
                if (doc.Horizontal) { // Horizontal format, write header
                    doc.BeginExportRow();
                    if (exportType == "view") {
                        doc.ExportCaption(NomorBukuTamu);
                        doc.ExportCaption(LookupPlant);
                        doc.ExportCaption(Plant);
                        doc.ExportCaption(Tanggal);
                        doc.ExportCaption(StatusZona);
                        doc.ExportCaption(Nama);
                        doc.ExportCaption(AsalPerusahaan);
                        doc.ExportCaption(Jabatan);
                        doc.ExportCaption(FungsiygDikunjungi);
                        doc.ExportCaption(MaksudKunjungan);
                        doc.ExportCaption(TandaPengenal);
                        doc.ExportCaption(TandaTanganDownload);
                        doc.ExportCaption(Keterangan);
                        doc.ExportCaption(PintuUtamaId);
                        doc.ExportCaption(PintuUtamaInTanggal);
                        doc.ExportCaption(PintuUtamaInFotoDownload);
                        doc.ExportCaption(PintuUtamaInUser);
                        doc.ExportCaption(CustomPilihPintu);
                        doc.ExportCaption(PintuUtamaOutTanggal);
                        doc.ExportCaption(PintuUtamaOutFotoDownload);
                        doc.ExportCaption(PintuUtamaOutUser);
                        doc.ExportCaption(LobbyUtamaId);
                        doc.ExportCaption(LobbyUtamaInTanggal);
                        doc.ExportCaption(LobbyUtamaInFotoDownload);
                        doc.ExportCaption(LobbyUtamaInUser);
                        doc.ExportCaption(LobbyUtamaOutTanggal);
                        doc.ExportCaption(LobbyUtamaOutFotoDownload);
                        doc.ExportCaption(LobbyUtamaOutUser);
                        doc.ExportCaption(AreaTerlarangId);
                        doc.ExportCaption(AreaTerlarangInTanggal);
                        doc.ExportCaption(AreaTerlarangInFotoDownload);
                        doc.ExportCaption(AreaTerlarangInUser);
                        doc.ExportCaption(AreaTerlarangOutTanggal);
                        doc.ExportCaption(AreaTerlarangOutFotoDownload);
                        doc.ExportCaption(AreaTerlarangOutUser);
                        doc.ExportCaption(etlDate);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(lastUpdatedDate);
                        doc.ExportCaption(StatusZonaPrev);
                    } else {
                        doc.ExportCaption(id);
                        doc.ExportCaption(NomorBukuTamu);
                        doc.ExportCaption(LinkRedirect);
                        doc.ExportCaption(LookupPlant);
                        doc.ExportCaption(Plant);
                        doc.ExportCaption(Tanggal);
                        doc.ExportCaption(StatusZona);
                        doc.ExportCaption(Nama);
                        doc.ExportCaption(AsalPerusahaan);
                        doc.ExportCaption(Jabatan);
                        doc.ExportCaption(FungsiygDikunjungi);
                        doc.ExportCaption(MaksudKunjungan);
                        doc.ExportCaption(TandaPengenal);
                        doc.ExportCaption(TandaTangan);
                        doc.ExportCaption(PintuUtamaId);
                        doc.ExportCaption(PintuUtamaInTanggal);
                        doc.ExportCaption(PintuUtamaInUser);
                        doc.ExportCaption(CustomPilihPintu);
                        doc.ExportCaption(PintuUtamaOutTanggal);
                        doc.ExportCaption(PintuUtamaOutUser);
                        doc.ExportCaption(LobbyUtamaId);
                        doc.ExportCaption(LobbyUtamaInTanggal);
                        doc.ExportCaption(LobbyUtamaInUser);
                        doc.ExportCaption(LobbyUtamaOutTanggal);
                        doc.ExportCaption(LobbyUtamaOutUser);
                        doc.ExportCaption(AreaTerlarangId);
                        doc.ExportCaption(AreaTerlarangInTanggal);
                        doc.ExportCaption(AreaTerlarangInUser);
                        doc.ExportCaption(AreaTerlarangOutTanggal);
                        doc.ExportCaption(AreaTerlarangOutUser);
                        doc.ExportCaption(etlDate);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(lastUpdatedDate);
                        doc.ExportCaption(StatusZonaPrev);
                    }
                    doc.EndExportRow();
                }
            }
            int recCnt = startRec - 1;
            // Read first record for View Page // DN
            if (exportType == "view") {
                await dataReader.ReadAsync();
            // Move to and read first record for list page // DN
            } else {
                if (Connection.SelectOffset) {
                    await dataReader.ReadAsync();
                } else {
                    for (int i = 0; i < startRec; i++) // Move to the start record and use do-while loop
                        await dataReader.ReadAsync();
                }
            }
            int rowcnt = 0; // DN
            do { // DN
                recCnt++;
                if (recCnt >= startRec) {
                    rowcnt = recCnt - startRec + 1;

                    // Page break
                    if (ExportPageBreakCount > 0) {
                        if (rowcnt > 1 && (rowcnt - 1) % ExportPageBreakCount == 0)
                            doc.ExportPageBreak();
                    }
                    LoadListRowValues(dataReader);

                    // Render row
                    RowType = RowType.View; // Render view
                    ResetAttributes();
                    await RenderListRow();
                    if (!doc.ExportCustom) {
                        doc.BeginExportRow(rowcnt); // Allow CSS styles if enabled
                        if (exportType == "view") {
                            await doc.ExportField(NomorBukuTamu);
                            await doc.ExportField(LookupPlant);
                            await doc.ExportField(Plant);
                            await doc.ExportField(Tanggal);
                            await doc.ExportField(StatusZona);
                            await doc.ExportField(Nama);
                            await doc.ExportField(AsalPerusahaan);
                            await doc.ExportField(Jabatan);
                            await doc.ExportField(FungsiygDikunjungi);
                            await doc.ExportField(MaksudKunjungan);
                            await doc.ExportField(TandaPengenal);
                            await doc.ExportField(TandaTanganDownload);
                            await doc.ExportField(Keterangan);
                            await doc.ExportField(PintuUtamaId);
                            await doc.ExportField(PintuUtamaInTanggal);
                            await doc.ExportField(PintuUtamaInFotoDownload);
                            await doc.ExportField(PintuUtamaInUser);
                            await doc.ExportField(CustomPilihPintu);
                            await doc.ExportField(PintuUtamaOutTanggal);
                            await doc.ExportField(PintuUtamaOutFotoDownload);
                            await doc.ExportField(PintuUtamaOutUser);
                            await doc.ExportField(LobbyUtamaId);
                            await doc.ExportField(LobbyUtamaInTanggal);
                            await doc.ExportField(LobbyUtamaInFotoDownload);
                            await doc.ExportField(LobbyUtamaInUser);
                            await doc.ExportField(LobbyUtamaOutTanggal);
                            await doc.ExportField(LobbyUtamaOutFotoDownload);
                            await doc.ExportField(LobbyUtamaOutUser);
                            await doc.ExportField(AreaTerlarangId);
                            await doc.ExportField(AreaTerlarangInTanggal);
                            await doc.ExportField(AreaTerlarangInFotoDownload);
                            await doc.ExportField(AreaTerlarangInUser);
                            await doc.ExportField(AreaTerlarangOutTanggal);
                            await doc.ExportField(AreaTerlarangOutFotoDownload);
                            await doc.ExportField(AreaTerlarangOutUser);
                            await doc.ExportField(etlDate);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(lastUpdatedDate);
                            await doc.ExportField(StatusZonaPrev);
                        } else {
                            await doc.ExportField(id);
                            await doc.ExportField(NomorBukuTamu);
                            await doc.ExportField(LinkRedirect);
                            await doc.ExportField(LookupPlant);
                            await doc.ExportField(Plant);
                            await doc.ExportField(Tanggal);
                            await doc.ExportField(StatusZona);
                            await doc.ExportField(Nama);
                            await doc.ExportField(AsalPerusahaan);
                            await doc.ExportField(Jabatan);
                            await doc.ExportField(FungsiygDikunjungi);
                            await doc.ExportField(MaksudKunjungan);
                            await doc.ExportField(TandaPengenal);
                            await doc.ExportField(TandaTangan);
                            await doc.ExportField(PintuUtamaId);
                            await doc.ExportField(PintuUtamaInTanggal);
                            await doc.ExportField(PintuUtamaInUser);
                            await doc.ExportField(CustomPilihPintu);
                            await doc.ExportField(PintuUtamaOutTanggal);
                            await doc.ExportField(PintuUtamaOutUser);
                            await doc.ExportField(LobbyUtamaId);
                            await doc.ExportField(LobbyUtamaInTanggal);
                            await doc.ExportField(LobbyUtamaInUser);
                            await doc.ExportField(LobbyUtamaOutTanggal);
                            await doc.ExportField(LobbyUtamaOutUser);
                            await doc.ExportField(AreaTerlarangId);
                            await doc.ExportField(AreaTerlarangInTanggal);
                            await doc.ExportField(AreaTerlarangInUser);
                            await doc.ExportField(AreaTerlarangOutTanggal);
                            await doc.ExportField(AreaTerlarangOutUser);
                            await doc.ExportField(etlDate);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(lastUpdatedDate);
                            await doc.ExportField(StatusZonaPrev);
                        }
                        doc.EndExportRow(rowcnt);
                    }
                }

                // Call Row Export server event
                if (doc.ExportCustom)
                    RowExport(doc, dataReader);
            } while (recCnt < stopRec && await dataReader.ReadAsync()); // DN
            if (!doc.ExportCustom)
                doc.ExportTableFooter();
        }

        // Table filter
        private string? _tableFilter = null;

        public string TableFilter
        {
            get => _tableFilter ?? "";
            set => _tableFilter = value;
        }

        // TblBasicSearchDefault
        private string? _tableBasicSearchDefault = null;

        public string TableBasicSearchDefault
        {
            get => _tableBasicSearchDefault ?? "";
            set => _tableBasicSearchDefault = value;
        }

        #pragma warning disable 1998
        // Get file data
        public async Task<IActionResult> GetFileData(string fldparm, string[] keys, bool resize, int width = -1, int height = -1)
        {
            if (width < 0)
                width = Config.ThumbnailDefaultWidth;
            if (height < 0)
                height = Config.ThumbnailDefaultHeight;

            // No binary fields
            return JsonBoolResult.FalseResult; // Incorrect key
        }
        #pragma warning restore 1998

        // Table level events

        // Table Load event
        public void TableLoad()
        {
            // Enter your code here
        }

        // Recordset Selecting event
        public void RecordsetSelecting(ref string filter) {
            // Enter your code here
                    var currentUser = CurrentUserLevel();
                    var idPosition = CurrentUserInfo("IdPosition");
                    string regionId = Request.Query.TryGetValue("x_filterRegion", out var r) ? r.ToString() : "All";
                    string plantId  = Request.Query.TryGetValue("x_filterPlant",  out var p) ? p.ToString() : "All";
                    if (currentUser == "-1" || currentUser == "3")
                    {
                        if (!string.IsNullOrEmpty(plantId) && plantId != "All")
                            AddFilter(ref filter, $"Plant = {plantId}");
                        else if (!string.IsNullOrEmpty(regionId) && regionId != "All")
                            AddFilter(ref filter, $"Plant IN (SELECT IdPlant FROM MasterPlant WHERE Region = {regionId})");
                        return;
                    }
                    if (idPosition == null) {
                        AddFilter(ref filter, "1=0");
                        return;
                    }
                    if (currentUser == "4")
                    {
                        string baseFilter = $@"Plant IN (
                            SELECT IdPlant FROM MappingPosition WHERE IdRegion IN (
                                SELECT IdRegion FROM MappingPosition WHERE IdPosition = {idPosition}
                            )
                        )";
                        AddFilter(ref filter, baseFilter);
                        if (!string.IsNullOrEmpty(plantId) && plantId != "All")
                            AddFilter(ref filter, $"Plant = {plantId}");
                        else if (!string.IsNullOrEmpty(regionId) && regionId != "All")
                            AddFilter(ref filter, $"Plant IN (SELECT IdPlant FROM MasterPlant WHERE Region = {regionId})");
                        return;
                    }
                    AddFilter(ref filter, $"Plant IN (SELECT IdPlant FROM MappingPosition WHERE IdPosition = {idPosition})");
                    if (!string.IsNullOrEmpty(plantId) && plantId != "All")
                        AddFilter(ref filter, $"Plant = {plantId}");
                    else if (!string.IsNullOrEmpty(regionId) && regionId != "All")
                        AddFilter(ref filter, $"Plant IN (SELECT IdPlant FROM MasterPlant WHERE Region = {regionId})");
                }

        // Recordset Selected event
        public void RecordsetSelected(DbDataReader rs) {
            // Enter your code here
        }

        // Recordset Searching event
        public void RecordsetSearching(ref string filter) {
            // Enter your code here
        }

        // Recordset Search Validated event
        public void RecordsetSearchValidated() {
            // Enter your code here
        }

        // Row_Selecting event
        public void RowSelecting(ref string filter) {
            // Enter your code here
        }

        // Row Selected event
        public void RowSelected(Dictionary<string, object> row) {
            //Log("Row Selected");
        }

        // Row Inserting event
        public bool RowInserting(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew)
        {
            try {
                // --- Ambil & validasi Plant (wajib) ---
                string idPlant = "";

                // Tangkap dari field Plant (lookup link field IdPlant)
                if (rsnew.TryGetValue("Plant", out var plantVal) && plantVal != null && !Empty(plantVal)) {
                    idPlant = Convert.ToString(plantVal)?.Trim() ?? "";
                }

                // Validasi lagi (fallback ke IdPlant kalau field ini dikirim terpisah)
                if (string.IsNullOrEmpty(idPlant) && rsnew.TryGetValue("IdPlant", out var vIdPlant) && vIdPlant != null && !Empty(vIdPlant)) {
                    idPlant = Convert.ToString(vIdPlant)?.Trim() ?? "";
                }
                if (string.IsNullOrEmpty(idPlant)) {
                    CancelMessage = "Plant wajib diisi.";
                    return false;
                }

                // --- Generate Nomor Buku Tamu ---
                var conn = Connection;
                var nomorObj = conn.ExecuteScalar("EXEC dbo.GenerateNomorBukuTamu @IdPlant = @p0", new { p0 = idPlant });
                if (nomorObj == null) {
                    CancelMessage = "Gagal menghasilkan Nomor Buku Tamu.";
                    return false;
                }
                rsnew["NomorBukuTamu"] = Convert.ToString(nomorObj);

                // --- Ambil waktu lokal plant ---
                DateTime plantTime = DateTime.Now;
                var plantObj = conn.ExecuteScalar("EXEC dbo.GetPlantDateTime @IdPlant = @p0", new { p0 = idPlant });
                if (plantObj != null && DateTime.TryParse(Convert.ToString(plantObj), out var tmp))
                    plantTime = tmp;

                // --- Field tanggal & audit ---
                // if (!rsnew.ContainsKey("Tanggal") || rsnew["Tanggal"] == null || Empty(rsnew["Tanggal"]))
                //     rsnew["Tanggal"] = plantTime;
                rsnew["Tanggal"] = plantTime;
                rsnew["etlDate"] = plantTime;
                rsnew["LastUpdatedBy"] = CurrentUserName();
                rsnew["LastUpdatedDate"] = plantTime;
                rsnew["StatusZona"] = "Pintu Utama";
            } catch (Exception ex) {
                Log("Error in BukuTamu Row_Inserting: " + ex.Message);
                CancelMessage = "Gagal menyimpan data Buku Tamu: " + ex.Message;
                return false;
            }
            return true;
        }

        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
        }

        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew)
        {
            try
            {
                // --- Ambil IdPlant ---
                var idPlant = rsnew.ContainsKey("Plant")
                    ? Convert.ToString(rsnew["Plant"])
                    : Convert.ToString(rsold["Plant"]);

                // --- Ambil waktu lokal plant ---
                DateTime plantTime = DateTime.Now;
                var plantObj = ExecuteScalar("EXEC dbo.GetPlantDateTime @IdPlant = @p0", new { p0 = idPlant });
                if (plantObj != null && DateTime.TryParse(Convert.ToString(plantObj), out var tmp))
                    plantTime = tmp;

                // --- Audit fields ---
                rsnew["LastUpdatedBy"] = CurrentUserName() ?? "";
                rsnew["LastUpdatedDate"] = plantTime;

                // --- Helper ---
                object FieldVal(string name) => rsnew.GetValueOrDefault(name) ?? rsold.GetValueOrDefault(name);
                bool EmptyField(string name) => Empty(FieldVal(name));

                // --- Lindungi kolom file agar tidak ter-NULL saat submit tanpa file ---
                var fileCols = new[]
                {
                    "TandaTangan",
                    "PintuUtamaInFoto",
                    "PintuUtamaOutFoto",
                    "LobbyUtamaInFoto",
                    "LobbyUtamaOutFoto",
                    "AreaTerlarangInFoto",
                    "AreaTerlarangOutFoto"
                };
                foreach (var col in fileCols)
                {
                    var newHas = rsnew.ContainsKey(col);
                    var newEmpty = !newHas || Empty(rsnew[col]);
                    var oldHasVal = rsold.ContainsKey(col) && !Empty(rsold[col]);
                    if (newEmpty && oldHasVal)
                        rsnew[col] = rsold[col];
                }

                // --- Booleans "kelengkapan" tiap tahapan ---
                bool done_PU_In = !EmptyField("PintuUtamaId") && !EmptyField("PintuUtamaInTanggal") && !EmptyField("PintuUtamaInFoto");
                bool done_LU_In = !EmptyField("LobbyUtamaId") && !EmptyField("LobbyUtamaInTanggal") && !EmptyField("LobbyUtamaInFoto");
                bool done_LU_Out = !EmptyField("LobbyUtamaOutTanggal") && !EmptyField("LobbyUtamaOutFoto");
                bool done_AT_In = !EmptyField("AreaTerlarangId") && !EmptyField("AreaTerlarangInTanggal") && !EmptyField("AreaTerlarangInFoto");
                bool done_AT_Out = !EmptyField("AreaTerlarangOutTanggal") && !EmptyField("AreaTerlarangOutFoto");
                bool done_PU_Out = !EmptyField("PintuUtamaOutTanggal") && !EmptyField("PintuUtamaOutFoto");

                // --- Auto-set <Group>User bila semua field group terisi (independen dari dropdown) ---
                void EnsureUserWhenComplete(string[] req, string userField)
                {
                    bool complete = req.All(f => !EmptyField(f));
                    bool userEmpty = EmptyField(userField);
                    if (complete && userEmpty)
                        rsnew[userField] = CurrentUserName() ?? "";
                }

                // Pintu Utama In
                EnsureUserWhenComplete(new[] { "PintuUtamaId", "PintuUtamaInTanggal", "PintuUtamaInFoto" }, "PintuUtamaInUser");
                // Lobby Utama In
                EnsureUserWhenComplete(new[] { "LobbyUtamaId", "LobbyUtamaInTanggal", "LobbyUtamaInFoto" }, "LobbyUtamaInUser");
                // Lobby Utama Out
                EnsureUserWhenComplete(new[] { "LobbyUtamaOutTanggal", "LobbyUtamaOutFoto" }, "LobbyUtamaOutUser");
                // Area Terlarang In
                EnsureUserWhenComplete(new[] { "AreaTerlarangId", "AreaTerlarangInTanggal", "AreaTerlarangInFoto" }, "AreaTerlarangInUser");
                // Area Terlarang Out
                EnsureUserWhenComplete(new[] { "AreaTerlarangOutTanggal", "AreaTerlarangOutFoto" }, "AreaTerlarangOutUser");
                // Pintu Utama Out
                EnsureUserWhenComplete(new[] { "PintuUtamaOutTanggal", "PintuUtamaOutFoto" }, "PintuUtamaOutUser");

                // --- Fungsi kalkulasi StatusZona otomatis (tanpa cek kosong) ---
                string ComputeStatusZona()
                {
                    if (done_PU_Out)
                        return "Complete";

                    // Kondisi tambahan (prioritas tinggi):
                    // 1) AT_Out sudah, LU_In sudah, tapi LU_Out belum -> Lobby Utama
                    if (done_AT_Out && done_LU_In && !done_LU_Out)
                        return "Lobby Utama";

                    // 2) LU_Out sudah, AT_In sudah, tapi AT_Out belum -> Area Terlarang
                    if (done_LU_Out && done_AT_In && !done_AT_Out)
                        return "Area Terlarang";

                    // Rantai normal:
                    if (done_AT_In && !done_AT_Out)
                        return "Area Terlarang";
                    if (done_LU_In && !done_LU_Out)
                        return "Lobby Utama";
                    if (done_PU_In)
                        return "Pintu Utama";

                    // Default (belum ada apa-apa yang cukup)
                    return Convert.ToString(FieldVal("StatusZona")) ?? "";
                }

                // --- (Tetap) logika berdasarkan pilihan dropdown bila ada ---
                string tahap = Convert.ToString(rsnew.GetValueOrDefault("CustomPilihPintu")
                    ?? rsold.GetValueOrDefault("CustomPilihPintu") ?? "");
                bool dropdownApplied = false;
                switch (tahap)
                {
                    case "1": // Pintu Utama Out
                        if (EmptyField("PintuUtamaOutTanggal") || EmptyField("PintuUtamaOutFoto"))
                        {
                            CancelMessage = "Pintu Utama Out harus lengkap (Tanggal & Foto).";
                            return false;
                        }
                        rsnew["PintuUtamaOutUser"] = CurrentUserName();
                        rsnew["StatusZona"] = "Complete";
                        dropdownApplied = true;
                        break;
                    case "2": // Lobby Utama In
                        if (EmptyField("LobbyUtamaId") || EmptyField("LobbyUtamaInTanggal") || EmptyField("LobbyUtamaInFoto"))
                        {
                            CancelMessage = "Lobby Utama In harus lengkap (Id, Tanggal & Foto).";
                            return false;
                        }
                        rsnew["LobbyUtamaInUser"] = CurrentUserName();
                        rsnew["StatusZona"] = "Lobby Utama";
                        dropdownApplied = true;
                        break;
                    case "3": // Area Terlarang In
                        if (EmptyField("AreaTerlarangId") || EmptyField("AreaTerlarangInTanggal") || EmptyField("AreaTerlarangInFoto"))
                        {
                            CancelMessage = "Area Terlarang In harus lengkap (Id, Tanggal & Foto).";
                            return false;
                        }
                        rsnew["AreaTerlarangInUser"] = CurrentUserName();
                        rsnew["StatusZona"] = "Area Terlarang";
                        dropdownApplied = true;
                        break;
                    case "4": // Lobby Utama Out
                        if (EmptyField("LobbyUtamaOutTanggal") || EmptyField("LobbyUtamaOutFoto"))
                        {
                            CancelMessage = "Lobby Utama Out harus lengkap (Tanggal & Foto).";
                            return false;
                        }
                        rsnew["LobbyUtamaOutUser"] = CurrentUserName();
                        // Jika sebelumnya pernah masuk AT dan belum keluar AT -> tetap Area Terlarang, else kembali ke Pintu Utama
                        rsnew["StatusZona"] = (!EmptyField("AreaTerlarangInTanggal") && EmptyField("AreaTerlarangOutTanggal"))
                                                    ? "Area Terlarang"
                                                    : "Pintu Utama";
                        dropdownApplied = true;
                        break;
                    case "5": // Area Terlarang Out
                        if (EmptyField("AreaTerlarangOutTanggal") || EmptyField("AreaTerlarangOutFoto"))
                        {
                            CancelMessage = "Area Terlarang Out harus lengkap (Tanggal & Foto).";
                            return false;
                        }
                        rsnew["AreaTerlarangOutUser"] = CurrentUserName();
                        // Jika sebelumnya masuk Lobby dan belum out Lobby -> Lobby Utama, else kembali Pintu Utama
                        rsnew["StatusZona"] = (!EmptyField("LobbyUtamaInTanggal") && EmptyField("LobbyUtamaOutTanggal"))
                                                    ? "Lobby Utama"
                                                    : "Pintu Utama";
                        dropdownApplied = true;
                        break;
                    default:
                        // tidak memilih tahap → biarkan auto-fill di bawah
                        break;
                }

                // --- Jika tidak memakai dropdown, tetap set StatusZona hasil kalkulasi otomatis (SELALU jalan) ---
                if (!dropdownApplied)
                {
                    rsnew["StatusZona"] = ComputeStatusZona();
                }
            }
            catch (Exception ex)
            {
                Log("Error in BukuTamu Row_Updating: " + ex.Message);
                CancelMessage = "Gagal memperbarui data Buku Tamu: " + ex.Message;
                return false;
            }
            return true;
        }

        // Row Updated event
        public void RowUpdated(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            //Log("Row Updated");
        }

        // Row Update Conflict event
        public bool RowUpdateConflict(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            // Enter your code here
            // To ignore conflict, set return value to false
            return true;
        }

        // Recordset Deleting event
        public bool RowDeleting(Dictionary<string, object> rs) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            return true;
        }

        // Row Deleted event
        public void RowDeleted(Dictionary<string, object> rs) {
            //Log("Row Deleted");
        }

        // Row Export event
        // doc = export document object
        public virtual void RowExport(dynamic doc, DbDataReader rs) {
            //doc.Text.Append("<div>" + MyField.ViewValue +"</div>"); // Build HTML with field value: rs["MyField"] or MyField.ViewValue
        }

        // Email Sending event
        public virtual bool EmailSending(EmailBase email, dynamic? args) {
            //Log(email);
            return true;
        }

        // Lookup Selecting event
        public void LookupSelecting(DbField fld, ref string filter) {
            // Enter your code here
            if (fld.Name != "IdPlant" || !Security.IsLoggedIn)
                return;
            var currentUserLevel = CurrentUserLevel();
            var userPlantId = CurrentUserInfo("Plant");
            var idRegion = CurrentUserInfo("Region");
            List<string> plantConditions = new();
            if ((currentUserLevel == "1" || currentUserLevel == "2" || currentUserLevel == "5") && userPlantId != null) {
                fld.Lookup.UserFilter = "IdPlant = " + userPlantId;
            } else if (currentUserLevel == "4") {
                if (idRegion == null) {
                    fld.Lookup.UserFilter = "1=0"; // tidak ada data
                    return;
                }
                string selectPlntByRegion = @"SELECT IdPlant FROM MasterPlant WHERE Region = @Region";
                using (SqlConnection sqlConnectionPlant = GetConnection("Db").OpenConnection())
                using (SqlCommand cmdRegion = new SqlCommand(selectPlntByRegion, sqlConnectionPlant)) {
                    cmdRegion.Parameters.AddWithValue("@Region", idRegion);
                    using (SqlDataReader readerRegion = cmdRegion.ExecuteReader()) {
                        while (readerRegion.Read()) {
                            string plantId = readerRegion["IdPlant"].ToString() ?? "0";
                            plantConditions.Add(plantId);
                        }
                    }
                }
                fld.Lookup.UserFilter = plantConditions.Count > 0 
                    ? "IdPlant IN (" + string.Join(",", plantConditions) + ")" 
                    : "1=0";
            }
        }

        // Row Rendering event
        public void RowRendering() {
            // Enter your code here
        }

        // Row Rendered event
        public void RowRendered()
        {
            try {
                // Pewarnaan StatusZona
                if (!Empty(StatusZona.CurrentValue)) {
                    string warna = "#fff";
                    string warnaFont = "#fff";
                    switch (StatusZona.CurrentValue.ToString()) {
                        case "Pintu Utama": warna = "#3c6dbd"; break;   // Biru
                        case "Lobby Utama": warna = "#ffcc00"; break;   // Kuning
                        case "Area Terlarang": warna = "#ba313b"; break; // Merah
                        case "Keluar": warna = "#198754"; break;      // Hijau
                    }
                    StatusZona.ViewValue = StatusZona.CurrentValue;
                    StatusZona.CellCssStyle =
                        $"background-color:{warna}; color:{warnaFont}; font-weight:bold; text-align:center; padding:4px 12px;";
                }

                // === Lock field groups kalau semua field terisi ===
                var groups = new List<DbField[]> {
                    new [] { PintuUtamaId, PintuUtamaInTanggal, PintuUtamaInFoto, PintuUtamaInUser },
                    new [] { LobbyUtamaId, LobbyUtamaInTanggal, LobbyUtamaInFoto, LobbyUtamaInUser },
                    new [] { LobbyUtamaOutTanggal, LobbyUtamaOutFoto, LobbyUtamaOutUser },
                    new [] { AreaTerlarangId, AreaTerlarangInTanggal, AreaTerlarangInFoto, AreaTerlarangInUser },
                    new [] { AreaTerlarangOutTanggal, AreaTerlarangOutFoto, AreaTerlarangOutUser },
                    new [] { PintuUtamaOutTanggal, PintuUtamaOutFoto, PintuUtamaOutUser }
                };
                foreach (var g in groups)
                {
                    bool allFilled = g.All(f => f != null && !Empty(f.CurrentValue));
                    if (allFilled)
                    {
                        foreach (var f in g)
                        {
                            if (f != null) f.ReadOnly = true;
                        }
                    }
                }
            } catch (Exception ex) {
                Log("Error in BukuTamu Row_Rendered: " + ex.Message);
            }
        }

        // User ID Filtering event
        public void UserIdFiltering(ref string filter) {
            // Enter your code here
        }
    }
} // End Partial class
