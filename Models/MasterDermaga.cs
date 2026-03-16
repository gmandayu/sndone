namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterDermaga
    /// </summary>
    [MaybeNull]
    public static MasterDermaga masterDermaga
    {
        get => HttpData.Resolve<MasterDermaga>("MasterDermaga");
        set => HttpData["MasterDermaga"] = value;
    }

    /// <summary>
    /// Table class for MasterDermaga
    /// </summary>
    public class MasterDermaga : DbTable
    {
        public override Dictionary<string, string> KeyFields { get; set; } = new() { // DN
            { "IdDermaga", "IdDermaga" },
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

        public readonly DbField<SqlDbType> IdDermaga;

        public readonly DbField<SqlDbType> Region;

        public readonly DbField<SqlDbType> Id_Plant;

        public readonly DbField<SqlDbType> Plant;

        public readonly DbField<SqlDbType> TBBM;

        public readonly DbField<SqlDbType> Equipment_ID;

        public readonly DbField<SqlDbType> Fungsi;

        public readonly DbField<SqlDbType> Kapasitas_DWT;

        public readonly DbField<SqlDbType> Kategori_Kapasitas;

        public readonly DbField<SqlDbType> Jenis_Sartam;

        public readonly DbField<SqlDbType> Type_Sartam;

        public readonly DbField<SqlDbType> Tahun_Pembuatan;

        public readonly DbField<SqlDbType> Kategori_Port;

        public readonly DbField<SqlDbType> DibuatOleh;

        public readonly DbField<SqlDbType> TanggalDibuat;

        public readonly DbField<SqlDbType> DiperbaruiOleh;

        public readonly DbField<SqlDbType> TanggalDiperbarui;

        // Constructor
        public MasterDermaga()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "MasterDermaga";
            Name = "MasterDermaga";
            Type = "TABLE";
            UpdateTable = "dbo.MasterDermaga"; // Update Table
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

            // IdDermaga
            IdDermaga = new(this, "x_IdDermaga", 3, SqlDbType.Int) {
                Name = "IdDermaga",
                Expression = "[IdDermaga]",
                BasicSearchExpression = "CAST([IdDermaga] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdDermaga]",
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
                CustomMessage = Language.FieldPhrase("MasterDermaga", "IdDermaga", "CustomMsg"),
                IsUpload = false
            };
            IdDermaga.Raw = true;
            Fields.Add("IdDermaga", IdDermaga);

            // Region
            Region = new(this, "x_Region", 202, SqlDbType.NVarChar) {
                Name = "Region",
                Expression = "[Region]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Region]",
                DateTimeFormat = -1,
                VirtualExpression = "[Region]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Region", "CustomMsg"),
                IsUpload = false
            };
            Region.Lookup = new Lookup<DbField>(Region, "MasterDermaga", true, "Region", new List<string> {"Region", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Region", Region);

            // Id_Plant
            Id_Plant = new(this, "x_Id_Plant", 3, SqlDbType.Int) {
                Name = "Id_Plant",
                Expression = "[Id_Plant]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([Id_Plant] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Id_Plant]",
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
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Id_Plant", "CustomMsg"),
                IsUpload = false
            };
            Id_Plant.Raw = true;
            Id_Plant.Lookup = new Lookup<DbField>(Id_Plant, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, Id_Plant) + "',[Nama_Terminal])");
            Fields.Add("Id_Plant", Id_Plant);

            // Plant
            Plant = new(this, "x_Plant", 202, SqlDbType.NVarChar) {
                Name = "Plant",
                Expression = "[Plant]",
                BasicSearchExpression = "[Plant]",
                DateTimeFormat = -1,
                VirtualExpression = "[Plant]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Plant", "CustomMsg"),
                IsUpload = false
            };
            Plant.Lookup = new Lookup<DbField>(Plant, "MasterDermaga", true, "Plant", new List<string> {"Plant", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Plant", Plant);

            // TBBM
            TBBM = new(this, "x_TBBM", 202, SqlDbType.NVarChar) {
                Name = "TBBM",
                Expression = "[TBBM]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TBBM]",
                DateTimeFormat = -1,
                VirtualExpression = "[TBBM]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "TBBM", "CustomMsg"),
                IsUpload = false
            };
            TBBM.Lookup = new Lookup<DbField>(TBBM, "MasterDermaga", true, "TBBM", new List<string> {"TBBM", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TBBM", TBBM);

            // Equipment_ID
            Equipment_ID = new(this, "x_Equipment_ID", 202, SqlDbType.NVarChar) {
                Name = "Equipment_ID",
                Expression = "[Equipment_ID]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Equipment_ID]",
                DateTimeFormat = -1,
                VirtualExpression = "[Equipment_ID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Equipment_ID", "CustomMsg"),
                IsUpload = false
            };
            Equipment_ID.Lookup = new Lookup<DbField>(Equipment_ID, "MasterDermaga", true, "Equipment_ID", new List<string> {"Equipment_ID", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Equipment_ID", Equipment_ID);

            // Fungsi
            Fungsi = new(this, "x_Fungsi", 202, SqlDbType.NVarChar) {
                Name = "Fungsi",
                Expression = "[Fungsi]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Fungsi]",
                DateTimeFormat = -1,
                VirtualExpression = "[Fungsi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Fungsi", "CustomMsg"),
                IsUpload = false
            };
            Fungsi.Lookup = new Lookup<DbField>(Fungsi, "MasterDermaga", true, "Fungsi", new List<string> {"Fungsi", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Fungsi", Fungsi);

            // Kapasitas_DWT
            Kapasitas_DWT = new(this, "x_Kapasitas_DWT", 202, SqlDbType.NVarChar) {
                Name = "Kapasitas_DWT",
                Expression = "[Kapasitas_DWT]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Kapasitas_DWT]",
                DateTimeFormat = -1,
                VirtualExpression = "[Kapasitas_DWT]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Kapasitas_DWT", "CustomMsg"),
                IsUpload = false
            };
            Kapasitas_DWT.Lookup = new Lookup<DbField>(Kapasitas_DWT, "MasterDermaga", true, "Kapasitas_DWT", new List<string> {"Kapasitas_DWT", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Kapasitas_DWT", Kapasitas_DWT);

            // Kategori_Kapasitas
            Kategori_Kapasitas = new(this, "x_Kategori_Kapasitas", 202, SqlDbType.NVarChar) {
                Name = "Kategori_Kapasitas",
                Expression = "[Kategori_Kapasitas]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Kategori_Kapasitas]",
                DateTimeFormat = -1,
                VirtualExpression = "[Kategori_Kapasitas]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Kategori_Kapasitas", "CustomMsg"),
                IsUpload = false
            };
            Kategori_Kapasitas.Lookup = new Lookup<DbField>(Kategori_Kapasitas, "MasterDermaga", true, "Kategori_Kapasitas", new List<string> {"Kategori_Kapasitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Kategori_Kapasitas", Kategori_Kapasitas);

            // Jenis_Sartam
            Jenis_Sartam = new(this, "x_Jenis_Sartam", 202, SqlDbType.NVarChar) {
                Name = "Jenis_Sartam",
                Expression = "[Jenis_Sartam]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Jenis_Sartam]",
                DateTimeFormat = -1,
                VirtualExpression = "[Jenis_Sartam]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Jenis_Sartam", "CustomMsg"),
                IsUpload = false
            };
            Jenis_Sartam.Lookup = new Lookup<DbField>(Jenis_Sartam, "MasterDermaga", true, "Jenis_Sartam", new List<string> {"Jenis_Sartam", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Jenis_Sartam", Jenis_Sartam);

            // Type_Sartam
            Type_Sartam = new(this, "x_Type_Sartam", 202, SqlDbType.NVarChar) {
                Name = "Type_Sartam",
                Expression = "[Type_Sartam]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Type_Sartam]",
                DateTimeFormat = -1,
                VirtualExpression = "[Type_Sartam]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Type_Sartam", "CustomMsg"),
                IsUpload = false
            };
            Type_Sartam.Lookup = new Lookup<DbField>(Type_Sartam, "MasterDermaga", true, "Type_Sartam", new List<string> {"Type_Sartam", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Type_Sartam", Type_Sartam);

            // Tahun_Pembuatan
            Tahun_Pembuatan = new(this, "x_Tahun_Pembuatan", 202, SqlDbType.NVarChar) {
                Name = "Tahun_Pembuatan",
                Expression = "[Tahun_Pembuatan]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Tahun_Pembuatan]",
                DateTimeFormat = -1,
                VirtualExpression = "[Tahun_Pembuatan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Tahun_Pembuatan", "CustomMsg"),
                IsUpload = false
            };
            Tahun_Pembuatan.Lookup = new Lookup<DbField>(Tahun_Pembuatan, "MasterDermaga", true, "Tahun_Pembuatan", new List<string> {"Tahun_Pembuatan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Tahun_Pembuatan", Tahun_Pembuatan);

            // Kategori_Port
            Kategori_Port = new(this, "x_Kategori_Port", 202, SqlDbType.NVarChar) {
                Name = "Kategori_Port",
                Expression = "[Kategori_Port]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Kategori_Port]",
                DateTimeFormat = -1,
                VirtualExpression = "[Kategori_Port]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "Kategori_Port", "CustomMsg"),
                IsUpload = false
            };
            Kategori_Port.Lookup = new Lookup<DbField>(Kategori_Port, "MasterDermaga", true, "Kategori_Port", new List<string> {"Kategori_Port", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Kategori_Port", Kategori_Port);

            // DibuatOleh
            DibuatOleh = new(this, "x_DibuatOleh", 200, SqlDbType.VarChar) {
                Name = "DibuatOleh",
                Expression = "[DibuatOleh]",
                UseBasicSearch = true,
                BasicSearchExpression = "[DibuatOleh]",
                DateTimeFormat = -1,
                VirtualExpression = "[DibuatOleh]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "DibuatOleh", "CustomMsg"),
                IsUpload = false
            };
            DibuatOleh.Lookup = new Lookup<DbField>(DibuatOleh, "MasterDermaga", true, "DibuatOleh", new List<string> {"DibuatOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("DibuatOleh", DibuatOleh);

            // TanggalDibuat
            TanggalDibuat = new(this, "x_TanggalDibuat", 135, SqlDbType.DateTime) {
                Name = "TanggalDibuat",
                Expression = "[TanggalDibuat]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TanggalDibuat]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[TanggalDibuat]",
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
                CustomMessage = Language.FieldPhrase("MasterDermaga", "TanggalDibuat", "CustomMsg"),
                IsUpload = false
            };
            TanggalDibuat.Raw = true;
            TanggalDibuat.Lookup = new Lookup<DbField>(TanggalDibuat, "MasterDermaga", true, "TanggalDibuat", new List<string> {"TanggalDibuat", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalDibuat", TanggalDibuat);

            // DiperbaruiOleh
            DiperbaruiOleh = new(this, "x_DiperbaruiOleh", 200, SqlDbType.VarChar) {
                Name = "DiperbaruiOleh",
                Expression = "[DiperbaruiOleh]",
                UseBasicSearch = true,
                BasicSearchExpression = "[DiperbaruiOleh]",
                DateTimeFormat = -1,
                VirtualExpression = "[DiperbaruiOleh]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterDermaga", "DiperbaruiOleh", "CustomMsg"),
                IsUpload = false
            };
            DiperbaruiOleh.Lookup = new Lookup<DbField>(DiperbaruiOleh, "MasterDermaga", true, "DiperbaruiOleh", new List<string> {"DiperbaruiOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("DiperbaruiOleh", DiperbaruiOleh);

            // TanggalDiperbarui
            TanggalDiperbarui = new(this, "x_TanggalDiperbarui", 135, SqlDbType.DateTime) {
                Name = "TanggalDiperbarui",
                Expression = "[TanggalDiperbarui]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TanggalDiperbarui]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[TanggalDiperbarui]",
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
                CustomMessage = Language.FieldPhrase("MasterDermaga", "TanggalDiperbarui", "CustomMsg"),
                IsUpload = false
            };
            TanggalDiperbarui.Raw = true;
            TanggalDiperbarui.Lookup = new Lookup<DbField>(TanggalDiperbarui, "MasterDermaga", true, "TanggalDiperbarui", new List<string> {"TanggalDiperbarui", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalDiperbarui", TanggalDiperbarui);

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
            get => _sqlFrom ?? "dbo.MasterDermaga";
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
                string select = "*";
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
                attr.Name == "IdDermaga");
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
                attr.Name == "IdDermaga");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterDermaga type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                if (row.ContainsKey("IdDermaga"))
                    row["IdDermaga"] = lastInsertedId;
                else
                    row.Add("IdDermaga", lastInsertedId);
                IdDermaga.SetDbValue(lastInsertedId);
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterDermaga type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterDermaga type", "data");
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
                IdDermaga.DbValue = row["IdDermaga"]; // Set DB value only
                Region.DbValue = row["Region"]; // Set DB value only
                Id_Plant.DbValue = row["Id_Plant"]; // Set DB value only
                Plant.DbValue = row["Plant"]; // Set DB value only
                TBBM.DbValue = row["TBBM"]; // Set DB value only
                Equipment_ID.DbValue = row["Equipment_ID"]; // Set DB value only
                Fungsi.DbValue = row["Fungsi"]; // Set DB value only
                Kapasitas_DWT.DbValue = row["Kapasitas_DWT"]; // Set DB value only
                Kategori_Kapasitas.DbValue = row["Kategori_Kapasitas"]; // Set DB value only
                Jenis_Sartam.DbValue = row["Jenis_Sartam"]; // Set DB value only
                Type_Sartam.DbValue = row["Type_Sartam"]; // Set DB value only
                Tahun_Pembuatan.DbValue = row["Tahun_Pembuatan"]; // Set DB value only
                Kategori_Port.DbValue = row["Kategori_Port"]; // Set DB value only
                DibuatOleh.DbValue = row["DibuatOleh"]; // Set DB value only
                TanggalDibuat.DbValue = row["TanggalDibuat"]; // Set DB value only
                DiperbaruiOleh.DbValue = row["DiperbaruiOleh"]; // Set DB value only
                TanggalDiperbarui.DbValue = row["TanggalDiperbarui"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[IdDermaga] = @IdDermaga@";

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
                    return "MasterDermagaList";
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
                "MasterDermagaView" => Language.Phrase("View"),
                "MasterDermagaEdit" => Language.Phrase("Edit"),
                "MasterDermagaAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "MasterDermagaList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "MasterDermagaView",
                Config.ApiAddAction => "MasterDermagaAdd",
                Config.ApiEditAction => "MasterDermagaEdit",
                Config.ApiDeleteAction => "MasterDermagaDelete",
                Config.ApiListAction => "MasterDermagaList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "MasterDermagaView",
                Config.ApiAddAction => "MasterDermagaAdd",
                Config.ApiEditAction => "MasterDermagaEdit",
                Config.ApiDeleteAction => "MasterDermagaDelete",
                Config.ApiListAction => "MasterDermagaList",
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
        public string ListUrl => "MasterDermagaList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("MasterDermagaView", parm);
            else
                url = KeyUrl("MasterDermagaView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "MasterDermagaAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "MasterDermagaAdd?" + parm;
            else
                url = "MasterDermagaAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("MasterDermagaEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("MasterDermagaList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("MasterDermagaAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("MasterDermagaList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("MasterDermagaDelete", parm)); // DN
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
            json += "\"IdDermaga\":" + ConvertToJson(IdDermaga.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL // DN
        public string KeyUrl(string url, string parm = "")
        {
            if (!IsNull(IdDermaga.CurrentValue)) {
                url += "/" + IdDermaga.CurrentValue;
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
                if (RouteValues.TryGetValue("IdDermaga", out object? v0)) { // IdDermaga // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("IdDermaga");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (KeyFields.Count > 1 && (!IsArray(keys) || keys.Length != KeyFields.Count))
                    continue;
                if (!IsNumeric(keys)) // IdDermaga
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
                    IdDermaga.CurrentValue = keys;
                else
                    IdDermaga.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        // Load row values from recordset
        public void LoadListRowValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
            IdDermaga.SetDbValue(row["IdDermaga"]);
            Region.SetDbValue(row["Region"]);
            Id_Plant.SetDbValue(row["Id_Plant"]);
            Plant.SetDbValue(row["Plant"]);
            TBBM.SetDbValue(row["TBBM"]);
            Equipment_ID.SetDbValue(row["Equipment_ID"]);
            Fungsi.SetDbValue(row["Fungsi"]);
            Kapasitas_DWT.SetDbValue(row["Kapasitas_DWT"]);
            Kategori_Kapasitas.SetDbValue(row["Kategori_Kapasitas"]);
            Jenis_Sartam.SetDbValue(row["Jenis_Sartam"]);
            Type_Sartam.SetDbValue(row["Type_Sartam"]);
            Tahun_Pembuatan.SetDbValue(row["Tahun_Pembuatan"]);
            Kategori_Port.SetDbValue(row["Kategori_Port"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "MasterDermagaList";
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

            // IdDermaga

            // Region

            // Id_Plant

            // Plant

            // TBBM

            // Equipment_ID

            // Fungsi

            // Kapasitas_DWT

            // Kategori_Kapasitas

            // Jenis_Sartam

            // Type_Sartam

            // Tahun_Pembuatan

            // Kategori_Port

            // DibuatOleh

            // TanggalDibuat

            // DiperbaruiOleh

            // TanggalDiperbarui

            // IdDermaga
            IdDermaga.ViewValue = IdDermaga.CurrentValue;
            IdDermaga.ViewCustomAttributes = "";

            // Region
            Region.ViewValue = ConvertToString(Region.CurrentValue); // DN
            Region.ViewCustomAttributes = "";

            // Id_Plant

            // awallookupbung
            string curVal = ConvertToString(Id_Plant.CurrentValue);
            Id_Plant.ViewValue = Empty(curVal) ? DbNullValue : FormatNumber(Id_Plant.CurrentValue, Id_Plant.FormatPattern);
            if (!Empty(curVal)) {
                if (Id_Plant.Lookup != null && IsDictionary(Id_Plant.Lookup?.Options) && Id_Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Id_Plant.ViewValue = Id_Plant.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    string filterWrk = SearchFilter(Id_Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Id_Plant.CurrentValue, Id_Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk = Id_Plant.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && Id_Plant.Lookup != null) { // Lookup values found
                        var listwrk = Id_Plant.Lookup?.RenderViewRow(rswrk[0]);
                        Id_Plant.ViewValue = Id_Plant.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            Id_Plant.ViewCustomAttributes = "";

            // Plant
            Plant.ViewValue = ConvertToString(Plant.CurrentValue); // DN
            Plant.ViewCustomAttributes = "";

            // TBBM
            TBBM.ViewValue = ConvertToString(TBBM.CurrentValue); // DN
            TBBM.ViewCustomAttributes = "";

            // Equipment_ID
            Equipment_ID.ViewValue = ConvertToString(Equipment_ID.CurrentValue); // DN
            Equipment_ID.ViewCustomAttributes = "";

            // Fungsi
            Fungsi.ViewValue = ConvertToString(Fungsi.CurrentValue); // DN
            Fungsi.ViewCustomAttributes = "";

            // Kapasitas_DWT
            Kapasitas_DWT.ViewValue = ConvertToString(Kapasitas_DWT.CurrentValue); // DN
            Kapasitas_DWT.ViewCustomAttributes = "";

            // Kategori_Kapasitas
            Kategori_Kapasitas.ViewValue = ConvertToString(Kategori_Kapasitas.CurrentValue); // DN
            Kategori_Kapasitas.ViewCustomAttributes = "";

            // Jenis_Sartam
            Jenis_Sartam.ViewValue = ConvertToString(Jenis_Sartam.CurrentValue); // DN
            Jenis_Sartam.ViewCustomAttributes = "";

            // Type_Sartam
            Type_Sartam.ViewValue = ConvertToString(Type_Sartam.CurrentValue); // DN
            Type_Sartam.ViewCustomAttributes = "";

            // Tahun_Pembuatan
            Tahun_Pembuatan.ViewValue = ConvertToString(Tahun_Pembuatan.CurrentValue); // DN
            Tahun_Pembuatan.ViewCustomAttributes = "";

            // Kategori_Port
            Kategori_Port.ViewValue = ConvertToString(Kategori_Port.CurrentValue); // DN
            Kategori_Port.ViewCustomAttributes = "";

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

            // IdDermaga
            IdDermaga.HrefValue = "";
            IdDermaga.TooltipValue = "";

            // Region
            Region.HrefValue = "";
            Region.TooltipValue = "";

            // Id_Plant
            Id_Plant.HrefValue = "";
            Id_Plant.TooltipValue = "";

            // Plant
            Plant.HrefValue = "";
            Plant.TooltipValue = "";

            // TBBM
            TBBM.HrefValue = "";
            TBBM.TooltipValue = "";

            // Equipment_ID
            Equipment_ID.HrefValue = "";
            Equipment_ID.TooltipValue = "";

            // Fungsi
            Fungsi.HrefValue = "";
            Fungsi.TooltipValue = "";

            // Kapasitas_DWT
            Kapasitas_DWT.HrefValue = "";
            Kapasitas_DWT.TooltipValue = "";

            // Kategori_Kapasitas
            Kategori_Kapasitas.HrefValue = "";
            Kategori_Kapasitas.TooltipValue = "";

            // Jenis_Sartam
            Jenis_Sartam.HrefValue = "";
            Jenis_Sartam.TooltipValue = "";

            // Type_Sartam
            Type_Sartam.HrefValue = "";
            Type_Sartam.TooltipValue = "";

            // Tahun_Pembuatan
            Tahun_Pembuatan.HrefValue = "";
            Tahun_Pembuatan.TooltipValue = "";

            // Kategori_Port
            Kategori_Port.HrefValue = "";
            Kategori_Port.TooltipValue = "";

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

            // IdDermaga
            IdDermaga.SetupEditAttributes();
            IdDermaga.EditValue = IdDermaga.CurrentValue;
            IdDermaga.ViewCustomAttributes = "";

            // Region
            Region.SetupEditAttributes();
            if (!Region.Raw)
                Region.CurrentValue = HtmlDecode(Region.CurrentValue);
            Region.EditValue = Region.CurrentValue;
            Region.PlaceHolder = RemoveHtml(Region.Caption);

            // Id_Plant
            Id_Plant.SetupEditAttributes();
            Id_Plant.PlaceHolder = RemoveHtml(Id_Plant.Caption);
            if (!Empty(Id_Plant.EditValue) && IsNumeric(Id_Plant.EditValue))
                Id_Plant.EditValue = FormatNumber(Id_Plant.EditValue, null);

            // Plant
            Plant.SetupEditAttributes();
            if (!Plant.Raw)
                Plant.CurrentValue = HtmlDecode(Plant.CurrentValue);
            Plant.EditValue = Plant.CurrentValue;
            Plant.PlaceHolder = RemoveHtml(Plant.Caption);

            // TBBM
            TBBM.SetupEditAttributes();
            if (!TBBM.Raw)
                TBBM.CurrentValue = HtmlDecode(TBBM.CurrentValue);
            TBBM.EditValue = TBBM.CurrentValue;
            TBBM.PlaceHolder = RemoveHtml(TBBM.Caption);

            // Equipment_ID
            Equipment_ID.SetupEditAttributes();
            if (!Equipment_ID.Raw)
                Equipment_ID.CurrentValue = HtmlDecode(Equipment_ID.CurrentValue);
            Equipment_ID.EditValue = Equipment_ID.CurrentValue;
            Equipment_ID.PlaceHolder = RemoveHtml(Equipment_ID.Caption);

            // Fungsi
            Fungsi.SetupEditAttributes();
            if (!Fungsi.Raw)
                Fungsi.CurrentValue = HtmlDecode(Fungsi.CurrentValue);
            Fungsi.EditValue = Fungsi.CurrentValue;
            Fungsi.PlaceHolder = RemoveHtml(Fungsi.Caption);

            // Kapasitas_DWT
            Kapasitas_DWT.SetupEditAttributes();
            if (!Kapasitas_DWT.Raw)
                Kapasitas_DWT.CurrentValue = HtmlDecode(Kapasitas_DWT.CurrentValue);
            Kapasitas_DWT.EditValue = Kapasitas_DWT.CurrentValue;
            Kapasitas_DWT.PlaceHolder = RemoveHtml(Kapasitas_DWT.Caption);

            // Kategori_Kapasitas
            Kategori_Kapasitas.SetupEditAttributes();
            if (!Kategori_Kapasitas.Raw)
                Kategori_Kapasitas.CurrentValue = HtmlDecode(Kategori_Kapasitas.CurrentValue);
            Kategori_Kapasitas.EditValue = Kategori_Kapasitas.CurrentValue;
            Kategori_Kapasitas.PlaceHolder = RemoveHtml(Kategori_Kapasitas.Caption);

            // Jenis_Sartam
            Jenis_Sartam.SetupEditAttributes();
            if (!Jenis_Sartam.Raw)
                Jenis_Sartam.CurrentValue = HtmlDecode(Jenis_Sartam.CurrentValue);
            Jenis_Sartam.EditValue = Jenis_Sartam.CurrentValue;
            Jenis_Sartam.PlaceHolder = RemoveHtml(Jenis_Sartam.Caption);

            // Type_Sartam
            Type_Sartam.SetupEditAttributes();
            if (!Type_Sartam.Raw)
                Type_Sartam.CurrentValue = HtmlDecode(Type_Sartam.CurrentValue);
            Type_Sartam.EditValue = Type_Sartam.CurrentValue;
            Type_Sartam.PlaceHolder = RemoveHtml(Type_Sartam.Caption);

            // Tahun_Pembuatan
            Tahun_Pembuatan.SetupEditAttributes();
            if (!Tahun_Pembuatan.Raw)
                Tahun_Pembuatan.CurrentValue = HtmlDecode(Tahun_Pembuatan.CurrentValue);
            Tahun_Pembuatan.EditValue = Tahun_Pembuatan.CurrentValue;
            Tahun_Pembuatan.PlaceHolder = RemoveHtml(Tahun_Pembuatan.Caption);

            // Kategori_Port
            Kategori_Port.SetupEditAttributes();
            if (!Kategori_Port.Raw)
                Kategori_Port.CurrentValue = HtmlDecode(Kategori_Port.CurrentValue);
            Kategori_Port.EditValue = Kategori_Port.CurrentValue;
            Kategori_Port.PlaceHolder = RemoveHtml(Kategori_Port.Caption);

            // DibuatOleh
            DibuatOleh.SetupEditAttributes();
            if (!DibuatOleh.Raw)
                DibuatOleh.CurrentValue = HtmlDecode(DibuatOleh.CurrentValue);
            DibuatOleh.EditValue = DibuatOleh.CurrentValue;
            DibuatOleh.PlaceHolder = RemoveHtml(DibuatOleh.Caption);

            // TanggalDibuat
            TanggalDibuat.SetupEditAttributes();
            TanggalDibuat.EditValue = FormatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);

            // DiperbaruiOleh
            DiperbaruiOleh.SetupEditAttributes();
            if (!DiperbaruiOleh.Raw)
                DiperbaruiOleh.CurrentValue = HtmlDecode(DiperbaruiOleh.CurrentValue);
            DiperbaruiOleh.EditValue = DiperbaruiOleh.CurrentValue;
            DiperbaruiOleh.PlaceHolder = RemoveHtml(DiperbaruiOleh.Caption);

            // TanggalDiperbarui
            TanggalDiperbarui.SetupEditAttributes();
            TanggalDiperbarui.EditValue = FormatDateTime(TanggalDiperbarui.CurrentValue, TanggalDiperbarui.FormatPattern);
            TanggalDiperbarui.PlaceHolder = RemoveHtml(TanggalDiperbarui.Caption);

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
                        doc.ExportCaption(IdDermaga);
                        doc.ExportCaption(Region);
                        doc.ExportCaption(Id_Plant);
                        doc.ExportCaption(TBBM);
                        doc.ExportCaption(Equipment_ID);
                        doc.ExportCaption(Fungsi);
                        doc.ExportCaption(Kapasitas_DWT);
                        doc.ExportCaption(Kategori_Kapasitas);
                        doc.ExportCaption(Jenis_Sartam);
                        doc.ExportCaption(Type_Sartam);
                        doc.ExportCaption(Tahun_Pembuatan);
                        doc.ExportCaption(Kategori_Port);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
                    } else {
                        doc.ExportCaption(IdDermaga);
                        doc.ExportCaption(Region);
                        doc.ExportCaption(Id_Plant);
                        doc.ExportCaption(Plant);
                        doc.ExportCaption(TBBM);
                        doc.ExportCaption(Equipment_ID);
                        doc.ExportCaption(Fungsi);
                        doc.ExportCaption(Kapasitas_DWT);
                        doc.ExportCaption(Kategori_Kapasitas);
                        doc.ExportCaption(Jenis_Sartam);
                        doc.ExportCaption(Type_Sartam);
                        doc.ExportCaption(Tahun_Pembuatan);
                        doc.ExportCaption(Kategori_Port);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
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
                            await doc.ExportField(IdDermaga);
                            await doc.ExportField(Region);
                            await doc.ExportField(Id_Plant);
                            await doc.ExportField(TBBM);
                            await doc.ExportField(Equipment_ID);
                            await doc.ExportField(Fungsi);
                            await doc.ExportField(Kapasitas_DWT);
                            await doc.ExportField(Kategori_Kapasitas);
                            await doc.ExportField(Jenis_Sartam);
                            await doc.ExportField(Type_Sartam);
                            await doc.ExportField(Tahun_Pembuatan);
                            await doc.ExportField(Kategori_Port);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
                        } else {
                            await doc.ExportField(IdDermaga);
                            await doc.ExportField(Region);
                            await doc.ExportField(Id_Plant);
                            await doc.ExportField(Plant);
                            await doc.ExportField(TBBM);
                            await doc.ExportField(Equipment_ID);
                            await doc.ExportField(Fungsi);
                            await doc.ExportField(Kapasitas_DWT);
                            await doc.ExportField(Kategori_Kapasitas);
                            await doc.ExportField(Jenis_Sartam);
                            await doc.ExportField(Type_Sartam);
                            await doc.ExportField(Tahun_Pembuatan);
                            await doc.ExportField(Kategori_Port);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
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
            if (CurrentUserLevel() != "2") 
                return;
            var idPosition = CurrentUserInfo("IdPosition");
            if (idPosition == null){
                AddFilter(ref filter, "1=0");
                return;
            }
            AddFilter(ref filter, $"Id_Plant IN (SELECT IdPlant FROM MappingPosition WHERE IdPosition = {idPosition})");
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
        public bool RowInserting(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            return true;
        }

        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
        }

        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
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
        }

        // Row Rendering event
        public void RowRendering() {
            // Enter your code here
        }

        // Row Rendered event
        public void RowRendered() {
            //VarDump(<FieldName>); // View field properties
        }

        // User ID Filtering event
        public void UserIdFiltering(ref string filter) {
            // Enter your code here
        }
    }
} // End Partial class
