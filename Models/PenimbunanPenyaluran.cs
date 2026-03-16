namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penimbunanPenyaluran
    /// </summary>
    [MaybeNull]
    public static PenimbunanPenyaluran penimbunanPenyaluran
    {
        get => HttpData.Resolve<PenimbunanPenyaluran>("PenimbunanPenyaluran");
        set => HttpData["PenimbunanPenyaluran"] = value;
    }

    /// <summary>
    /// Table class for PenimbunanPenyaluran
    /// </summary>
    public class PenimbunanPenyaluran : DbTable
    {
        public override Dictionary<string, string> KeyFields { get; set; } = new() { // DN
            { "IdPenimbunanPenyaluran", "IdPenimbunanPenyaluran" },
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

        public bool ModalSearch = true;

        public bool ModalView = false;

        public bool ModalAdd = false;

        public bool ModalEdit = false;

        public bool ModalUpdate = false;

        public bool InlineDelete = false;

        public bool ModalGridAdd = false;

        public bool ModalGridEdit = false;

        public bool ModalMultiEdit = false;

        public readonly DbField<SqlDbType> IdPenimbunanPenyaluran;

        public readonly DbField<SqlDbType> NomorPenimbunanPenyaluran;

        public readonly DbField<SqlDbType> Proses2;

        public readonly DbField<SqlDbType> IdTemplate;

        public readonly DbField<SqlDbType> LookupPlant;

        public readonly DbField<SqlDbType> Plant;

        public readonly DbField<SqlDbType> TipeProdukSTS;

        public readonly DbField<SqlDbType> TipePenyaluran;

        public readonly DbField<SqlDbType> JenisProduk;

        public readonly DbField<SqlDbType> IdModa;

        public readonly DbField<SqlDbType> IdTangki;

        public readonly DbField<SqlDbType> StatusProses;

        public readonly DbField<SqlDbType> LookupNoPenyaluran;

        public readonly DbField<SqlDbType> NoPenyaluran;

        public readonly DbField<SqlDbType> PersentaseProgress;

        public readonly DbField<SqlDbType> Catatan;

        public readonly DbField<SqlDbType> DibuatOleh;

        public readonly DbField<SqlDbType> TanggalDibuat;

        public readonly DbField<SqlDbType> DiperbaruiOleh;

        public readonly DbField<SqlDbType> TanggalDiperbarui;

        public readonly DbField<SqlDbType> PlantForLookup;

        public readonly DbField<SqlDbType> LookupTipeProduk;

        public readonly DbField<SqlDbType> LookupJenisPlant;

        // Constructor
        public PenimbunanPenyaluran()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "PenimbunanPenyaluran";
            Name = "PenimbunanPenyaluran";
            Type = "TABLE";
            UpdateTable = "dbo.PenimbunanPenyaluran"; // Update Table
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

            // IdPenimbunanPenyaluran
            IdPenimbunanPenyaluran = new(this, "x_IdPenimbunanPenyaluran", 3, SqlDbType.Int) {
                Name = "IdPenimbunanPenyaluran",
                Expression = "[IdPenimbunanPenyaluran]",
                BasicSearchExpression = "CAST([IdPenimbunanPenyaluran] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdPenimbunanPenyaluran]",
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
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "IdPenimbunanPenyaluran", "CustomMsg"),
                IsUpload = false
            };
            IdPenimbunanPenyaluran.Raw = true;
            Fields.Add("IdPenimbunanPenyaluran", IdPenimbunanPenyaluran);

            // NomorPenimbunanPenyaluran
            NomorPenimbunanPenyaluran = new(this, "x_NomorPenimbunanPenyaluran", 200, SqlDbType.VarChar) {
                Name = "NomorPenimbunanPenyaluran",
                Expression = "[NomorPenimbunanPenyaluran]",
                BasicSearchExpression = "[NomorPenimbunanPenyaluran]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomorPenimbunanPenyaluran]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "NomorPenimbunanPenyaluran", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomorPenimbunanPenyaluran", NomorPenimbunanPenyaluran);

            // Proses
            Proses2 = new(this, "x_Proses2", 202, SqlDbType.NVarChar) {
                Name = "Proses",
                Expression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenimbunanPenyaluran AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenimbunanPenyaluran AS NVARCHAR(50))+'</a>'",
                UseBasicSearch = true,
                BasicSearchExpression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenimbunanPenyaluran AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenimbunanPenyaluran AS NVARCHAR(50))+'</a>'",
                DateTimeFormat = -1,
                VirtualExpression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenimbunanPenyaluran AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenimbunanPenyaluran AS NVARCHAR(50))+'</a>'",
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
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "Proses2", "CustomMsg"),
                IsUpload = false
            };
            Proses2.Lookup = new Lookup<DbField>(Proses2, "PenimbunanPenyaluran", true, "Proses", new List<string> {"Proses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Proses", Proses2);

            // IdTemplate
            IdTemplate = new(this, "x_IdTemplate", 3, SqlDbType.Int) {
                Name = "IdTemplate",
                Expression = "[IdTemplate]",
                BasicSearchExpression = "CAST([IdTemplate] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdTemplate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "IdTemplate", "CustomMsg"),
                IsUpload = false
            };
            IdTemplate.Raw = true;
            IdTemplate.GetDefault = () => 29;
            Fields.Add("IdTemplate", IdTemplate);

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
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "LookupPlant", "CustomMsg"),
                IsUpload = false
            };
            LookupPlant.Raw = true;
            LookupPlant.Lookup = new Lookup<DbField>(LookupPlant, "PenimbunanPenyaluran", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LookupPlant", LookupPlant);

            // Plant
            Plant = new(this, "x_Plant", 202, SqlDbType.NVarChar) {
                Name = "Plant",
                Expression = "[Plant]",
                UseBasicSearch = true,
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
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "Plant", "CustomMsg"),
                IsUpload = false
            };
            Plant.Lookup = new Lookup<DbField>(Plant, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {"x_NoPenyaluran"}, new List<string> {}, new List<string> {}, new List<string> {"Plant", "TipeProduk", "JenisPlant"}, new List<string> {"x_PlantForLookup", "x_LookupTipeProduk", "x_LookupJenisPlant"}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, Plant) + "',[Nama_Terminal])");
            Fields.Add("Plant", Plant);

            // TipeProdukSTS
            TipeProdukSTS = new(this, "x_TipeProdukSTS", 202, SqlDbType.NVarChar) {
                Name = "TipeProdukSTS",
                Expression = "[TipeProdukSTS]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TipeProdukSTS]",
                DateTimeFormat = -1,
                VirtualExpression = "[TipeProdukSTS]",
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
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "TipeProdukSTS", "CustomMsg"),
                IsUpload = false
            };
            TipeProdukSTS.Lookup = new Lookup<DbField>(TipeProdukSTS, "MasterProduk", true, "TipeProduk", new List<string> {"TipeProduk", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {"TipeProduk"}, new List<string> {"x_LookupTipeProduk"}, true, "", "", "[TipeProduk]");
            Fields.Add("TipeProdukSTS", TipeProdukSTS);

            // TipePenyaluran
            TipePenyaluran = new(this, "x_TipePenyaluran", 202, SqlDbType.NVarChar) {
                Name = "TipePenyaluran",
                Expression = "[TipePenyaluran]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TipePenyaluran]",
                DateTimeFormat = -1,
                VirtualExpression = "[TipePenyaluran]",
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
                UseFilter = true, // Table header filter
                OptionCount = 2,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "TipePenyaluran", "CustomMsg"),
                IsUpload = false
            };
            TipePenyaluran.Lookup = new Lookup<DbField>(TipePenyaluran, "PenimbunanPenyaluran", true, "TipePenyaluran", new List<string> {"TipePenyaluran", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TipePenyaluran", TipePenyaluran);

            // JenisProduk
            JenisProduk = new(this, "x_JenisProduk", 202, SqlDbType.NVarChar) {
                Name = "JenisProduk",
                Expression = "[JenisProduk]",
                UseBasicSearch = true,
                BasicSearchExpression = "[JenisProduk]",
                DateTimeFormat = -1,
                VirtualExpression = "[JenisProduk]",
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
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "JenisProduk", "CustomMsg"),
                IsUpload = false
            };
            JenisProduk.Lookup = new Lookup<DbField>(JenisProduk, "MasterProduk", true, "NoProduk", new List<string> {"NoProduk", "NamaProduk", "", ""}, "", "", new List<string> {"x_LookupTipeProduk"}, new List<string> {}, new List<string> {"TipeProduk"}, new List<string> {"x_TipeProduk"}, new List<string> {}, new List<string> {}, true, "", "", "CONCAT([NoProduk],'" + ValueSeparator(1, JenisProduk) + "',[NamaProduk])");
            Fields.Add("JenisProduk", JenisProduk);

            // IdModa
            IdModa = new(this, "x_IdModa", 3, SqlDbType.Int) {
                Name = "IdModa",
                Expression = "[IdModa]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([IdModa] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdModa]",
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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "IdModa", "CustomMsg"),
                IsUpload = false
            };
            IdModa.Raw = true;
            IdModa.Lookup = new Lookup<DbField>(IdModa, "MasterModa", true, "IdModa", new List<string> {"NamaModa", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "[Kategori] DESC", "", "[NamaModa]");
            Fields.Add("IdModa", IdModa);

            // IdTangki
            IdTangki = new(this, "x_IdTangki", 3, SqlDbType.Int) {
                Name = "IdTangki",
                Expression = "[IdTangki]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([IdTangki] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdTangki]",
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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "IdTangki", "CustomMsg"),
                IsUpload = false
            };
            IdTangki.Raw = true;
            IdTangki.Lookup = new Lookup<DbField>(IdTangki, "MasterTangki", true, "id", new List<string> {"Sloc", "SeqTangki", "NamaTerminal", ""}, "", "", new List<string> {"x_PlantForLookup"}, new List<string> {}, new List<string> {"Plant"}, new List<string> {"x_Plant"}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Sloc],'" + ValueSeparator(1, IdTangki) + "',[SeqTangki],'" + ValueSeparator(2, IdTangki) + "',[NamaTerminal])");
            IdTangki.GetSelectFilter = () => "lower([Status]) = 'operasi'";
            Fields.Add("IdTangki", IdTangki);

            // StatusProses
            StatusProses = new(this, "x_StatusProses", 200, SqlDbType.VarChar) {
                Name = "StatusProses",
                Expression = "[StatusProses]",
                UseBasicSearch = true,
                BasicSearchExpression = "[StatusProses]",
                DateTimeFormat = -1,
                VirtualExpression = "[StatusProses]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "StatusProses", "CustomMsg"),
                IsUpload = false
            };
            StatusProses.Lookup = new Lookup<DbField>(StatusProses, "PenimbunanPenyaluran", true, "StatusProses", new List<string> {"StatusProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            StatusProses.GetDefault = () => "Waiting";
            Fields.Add("StatusProses", StatusProses);

            // LookupNoPenyaluran
            LookupNoPenyaluran = new(this, "x_LookupNoPenyaluran", 200, SqlDbType.VarChar) {
                Name = "LookupNoPenyaluran",
                Expression = "''",
                BasicSearchExpression = "''",
                DateTimeFormat = -1,
                VirtualExpression = "''",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 1,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "LookupNoPenyaluran", "CustomMsg"),
                IsUpload = false
            };
            LookupNoPenyaluran.Lookup = new Lookup<DbField>(LookupNoPenyaluran, "PenimbunanPenyaluran", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LookupNoPenyaluran", LookupNoPenyaluran);

            // NoPenyaluran
            NoPenyaluran = new(this, "x_NoPenyaluran", 202, SqlDbType.NVarChar) {
                Name = "NoPenyaluran",
                Expression = "[NoPenyaluran]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NoPenyaluran]",
                DateTimeFormat = -1,
                VirtualExpression = "[NoPenyaluran]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "NoPenyaluran", "CustomMsg"),
                IsUpload = false
            };
            NoPenyaluran.Lookup = new Lookup<DbField>(NoPenyaluran, "Penyaluran", true, "NomorPenyaluran", new List<string> {"NomorPenyaluran", "", "", ""}, "", "", new List<string> {"x_Plant"}, new List<string> {}, new List<string> {"IdPlant"}, new List<string> {"x_IdPlant"}, new List<string> {"TipeProdukSTS", "JenisProduk"}, new List<string> {"x_TipeProdukSTS", "x_JenisProduk"}, false, "", "", "[NomorPenyaluran]");
            NoPenyaluran.GetSelectFilter = () => "TipePenyaluran = 'Konsinyasi' AND TanggalDibuat >= DATEADD(DAY, -14, GETDATE())";
            Fields.Add("NoPenyaluran", NoPenyaluran);

            // PersentaseProgress
            PersentaseProgress = new(this, "x_PersentaseProgress", 131, SqlDbType.Decimal) {
                Name = "PersentaseProgress",
                Expression = "[PersentaseProgress]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([PersentaseProgress] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PersentaseProgress]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "PersentaseProgress", "CustomMsg"),
                IsUpload = false
            };
            PersentaseProgress.Raw = true;
            PersentaseProgress.Lookup = new Lookup<DbField>(PersentaseProgress, "PenimbunanPenyaluran", true, "PersentaseProgress", new List<string> {"PersentaseProgress", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            PersentaseProgress.GetDefault = () => "0";
            Fields.Add("PersentaseProgress", PersentaseProgress);

            // Catatan
            Catatan = new(this, "x_Catatan", 201, SqlDbType.Text) {
                Name = "Catatan",
                Expression = "[Catatan]",
                BasicSearchExpression = "[Catatan]",
                DateTimeFormat = -1,
                VirtualExpression = "[Catatan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "Catatan", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Catatan", Catatan);

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
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "DibuatOleh", "CustomMsg"),
                IsUpload = false
            };
            DibuatOleh.Lookup = new Lookup<DbField>(DibuatOleh, "PenimbunanPenyaluran", true, "DibuatOleh", new List<string> {"DibuatOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            DibuatOleh.GetAutoUpdateValue = () => CurrentUserName();
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
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "TanggalDibuat", "CustomMsg"),
                IsUpload = false
            };
            TanggalDibuat.Raw = true;
            TanggalDibuat.Lookup = new Lookup<DbField>(TanggalDibuat, "PenimbunanPenyaluran", true, "TanggalDibuat", new List<string> {"TanggalDibuat", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            TanggalDibuat.GetAutoUpdateValue = () => CurrentDateTime();
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
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "DiperbaruiOleh", "CustomMsg"),
                IsUpload = false
            };
            DiperbaruiOleh.Lookup = new Lookup<DbField>(DiperbaruiOleh, "PenimbunanPenyaluran", true, "DiperbaruiOleh", new List<string> {"DiperbaruiOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            DiperbaruiOleh.GetAutoUpdateValue = () => CurrentUserName();
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
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "TanggalDiperbarui", "CustomMsg"),
                IsUpload = false
            };
            TanggalDiperbarui.Raw = true;
            TanggalDiperbarui.Lookup = new Lookup<DbField>(TanggalDiperbarui, "PenimbunanPenyaluran", true, "TanggalDiperbarui", new List<string> {"TanggalDiperbarui", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            TanggalDiperbarui.GetAutoUpdateValue = () => CurrentDateTime();
            Fields.Add("TanggalDiperbarui", TanggalDiperbarui);

            // PlantForLookup
            PlantForLookup = new(this, "x_PlantForLookup", 200, SqlDbType.VarChar) {
                Name = "PlantForLookup",
                Expression = "''",
                BasicSearchExpression = "''",
                DateTimeFormat = -1,
                VirtualExpression = "''",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "PlantForLookup", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PlantForLookup", PlantForLookup);

            // LookupTipeProduk
            LookupTipeProduk = new(this, "x_LookupTipeProduk", 200, SqlDbType.VarChar) {
                Name = "LookupTipeProduk",
                Expression = "''",
                BasicSearchExpression = "''",
                DateTimeFormat = -1,
                VirtualExpression = "''",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "LookupTipeProduk", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("LookupTipeProduk", LookupTipeProduk);

            // LookupJenisPlant
            LookupJenisPlant = new(this, "x_LookupJenisPlant", 200, SqlDbType.VarChar) {
                Name = "LookupJenisPlant",
                Expression = "''",
                BasicSearchExpression = "''",
                DateTimeFormat = -1,
                VirtualExpression = "''",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("PenimbunanPenyaluran", "LookupJenisPlant", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("LookupJenisPlant", LookupJenisPlant);

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
            get => _sqlFrom ?? "dbo.PenimbunanPenyaluran";
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
                string select = "*, '<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenimbunanPenyaluran AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenimbunanPenyaluran AS NVARCHAR(50))+'</a>' AS [Proses], '' AS [LookupNoPenyaluran], '' AS [PlantForLookup], '' AS [LookupTipeProduk], '' AS [LookupJenisPlant]";
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
                attr.Name == "IdPenimbunanPenyaluran");
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
                attr.Name == "IdPenimbunanPenyaluran");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.PenimbunanPenyaluran type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                if (row.ContainsKey("IdPenimbunanPenyaluran"))
                    row["IdPenimbunanPenyaluran"] = lastInsertedId;
                else
                    row.Add("IdPenimbunanPenyaluran", lastInsertedId);
                IdPenimbunanPenyaluran.SetDbValue(lastInsertedId);
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.PenimbunanPenyaluran type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.PenimbunanPenyaluran type", "data");
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
                IdPenimbunanPenyaluran.DbValue = row["IdPenimbunanPenyaluran"]; // Set DB value only
                NomorPenimbunanPenyaluran.DbValue = row["NomorPenimbunanPenyaluran"]; // Set DB value only
                Proses2.DbValue = row["Proses"]; // Set DB value only
                IdTemplate.DbValue = row["IdTemplate"]; // Set DB value only
                LookupPlant.DbValue = row["LookupPlant"]; // Set DB value only
                Plant.DbValue = row["Plant"]; // Set DB value only
                TipeProdukSTS.DbValue = row["TipeProdukSTS"]; // Set DB value only
                TipePenyaluran.DbValue = row["TipePenyaluran"]; // Set DB value only
                JenisProduk.DbValue = row["JenisProduk"]; // Set DB value only
                IdModa.DbValue = row["IdModa"]; // Set DB value only
                IdTangki.DbValue = row["IdTangki"]; // Set DB value only
                StatusProses.DbValue = row["StatusProses"]; // Set DB value only
                LookupNoPenyaluran.DbValue = row["LookupNoPenyaluran"]; // Set DB value only
                NoPenyaluran.DbValue = row["NoPenyaluran"]; // Set DB value only
                PersentaseProgress.DbValue = row["PersentaseProgress"]; // Set DB value only
                Catatan.DbValue = row["Catatan"]; // Set DB value only
                DibuatOleh.DbValue = row["DibuatOleh"]; // Set DB value only
                TanggalDibuat.DbValue = row["TanggalDibuat"]; // Set DB value only
                DiperbaruiOleh.DbValue = row["DiperbaruiOleh"]; // Set DB value only
                TanggalDiperbarui.DbValue = row["TanggalDiperbarui"]; // Set DB value only
                PlantForLookup.DbValue = row["PlantForLookup"]; // Set DB value only
                LookupTipeProduk.DbValue = row["LookupTipeProduk"]; // Set DB value only
                LookupJenisPlant.DbValue = row["LookupJenisPlant"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[IdPenimbunanPenyaluran] = @IdPenimbunanPenyaluran@";

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
                    return "PenimbunanPenyaluranList";
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
                "PenimbunanPenyaluranView" => Language.Phrase("View"),
                "PenimbunanPenyaluranEdit" => Language.Phrase("Edit"),
                "PenimbunanPenyaluranAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "PenimbunanPenyaluranList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "PenimbunanPenyaluranView",
                Config.ApiAddAction => "PenimbunanPenyaluranAdd",
                Config.ApiEditAction => "PenimbunanPenyaluranEdit",
                Config.ApiDeleteAction => "PenimbunanPenyaluranDelete",
                Config.ApiListAction => "PenimbunanPenyaluranList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "PenimbunanPenyaluranView",
                Config.ApiAddAction => "PenimbunanPenyaluranAdd",
                Config.ApiEditAction => "PenimbunanPenyaluranEdit",
                Config.ApiDeleteAction => "PenimbunanPenyaluranDelete",
                Config.ApiListAction => "PenimbunanPenyaluranList",
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
        public string ListUrl => "PenimbunanPenyaluranList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("PenimbunanPenyaluranView", parm);
            else
                url = KeyUrl("PenimbunanPenyaluranView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "PenimbunanPenyaluranAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "PenimbunanPenyaluranAdd?" + parm;
            else
                url = "PenimbunanPenyaluranAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("PenimbunanPenyaluranEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("PenimbunanPenyaluranList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("PenimbunanPenyaluranAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("PenimbunanPenyaluranList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("PenimbunanPenyaluranDelete", parm)); // DN
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
            json += "\"IdPenimbunanPenyaluran\":" + ConvertToJson(IdPenimbunanPenyaluran.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL // DN
        public string KeyUrl(string url, string parm = "")
        {
            if (!IsNull(IdPenimbunanPenyaluran.CurrentValue)) {
                url += "/" + IdPenimbunanPenyaluran.CurrentValue;
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
                if (RouteValues.TryGetValue("IdPenimbunanPenyaluran", out object? v0)) { // IdPenimbunanPenyaluran // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("IdPenimbunanPenyaluran");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (KeyFields.Count > 1 && (!IsArray(keys) || keys.Length != KeyFields.Count))
                    continue;
                if (!IsNumeric(keys)) // IdPenimbunanPenyaluran
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
                    IdPenimbunanPenyaluran.CurrentValue = keys;
                else
                    IdPenimbunanPenyaluran.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        // Load row values from recordset
        public void LoadListRowValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
            IdPenimbunanPenyaluran.SetDbValue(row["IdPenimbunanPenyaluran"]);
            NomorPenimbunanPenyaluran.SetDbValue(row["NomorPenimbunanPenyaluran"]);
            Proses2.SetDbValue(row["Proses"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            Plant.SetDbValue(row["Plant"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            TipePenyaluran.SetDbValue(row["TipePenyaluran"]);
            JenisProduk.SetDbValue(row["JenisProduk"]);
            IdModa.SetDbValue(row["IdModa"]);
            IdTangki.SetDbValue(row["IdTangki"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            LookupNoPenyaluran.SetDbValue(row["LookupNoPenyaluran"]);
            NoPenyaluran.SetDbValue(row["NoPenyaluran"]);
            PersentaseProgress.SetDbValue(row["PersentaseProgress"]);
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            PlantForLookup.SetDbValue(row["PlantForLookup"]);
            LookupTipeProduk.SetDbValue(row["LookupTipeProduk"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "PenimbunanPenyaluranList";
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

            // IdPenimbunanPenyaluran

            // NomorPenimbunanPenyaluran

            // Proses

            // IdTemplate

            // LookupPlant

            // Plant

            // TipeProdukSTS

            // TipePenyaluran

            // JenisProduk

            // IdModa

            // IdTangki

            // StatusProses

            // LookupNoPenyaluran
            LookupNoPenyaluran.CellCssStyle = "white-space: nowrap;";

            // NoPenyaluran

            // PersentaseProgress

            // Catatan

            // DibuatOleh

            // TanggalDibuat

            // DiperbaruiOleh

            // TanggalDiperbarui

            // PlantForLookup
            PlantForLookup.CellCssStyle = "white-space: nowrap;";

            // LookupTipeProduk
            LookupTipeProduk.CellCssStyle = "white-space: nowrap;";

            // LookupJenisPlant
            LookupJenisPlant.CellCssStyle = "white-space: nowrap;";

            // IdPenimbunanPenyaluran
            IdPenimbunanPenyaluran.ViewValue = IdPenimbunanPenyaluran.CurrentValue;
            IdPenimbunanPenyaluran.ViewValue = FormatNumber(IdPenimbunanPenyaluran.ViewValue, IdPenimbunanPenyaluran.FormatPattern);
            IdPenimbunanPenyaluran.ViewCustomAttributes = "";

            // NomorPenimbunanPenyaluran
            NomorPenimbunanPenyaluran.ViewValue = ConvertToString(NomorPenimbunanPenyaluran.CurrentValue); // DN
            NomorPenimbunanPenyaluran.ViewCustomAttributes = "";

            // Proses
            Proses2.ViewValue = ConvertToString(Proses2.CurrentValue); // DN
            Proses2.ViewCustomAttributes = "";

            // IdTemplate
            IdTemplate.ViewValue = IdTemplate.CurrentValue;
            IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
            IdTemplate.ViewCustomAttributes = "";

            // LookupPlant
            if (!Empty(LookupPlant.CurrentValue)) {
                LookupPlant.ViewValue = LookupPlant.OptionCaption(ConvertToString(LookupPlant.CurrentValue));
            } else {
                LookupPlant.ViewValue = DbNullValue;
            }
            LookupPlant.ViewCustomAttributes = "";

            // Plant
            Plant.ViewValue = ConvertToString(Plant.CurrentValue); // DN

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

            // TipeProdukSTS
            List<object?>? listWrk3 = [ // DN
                TipeProdukSTS.CurrentValue,
                TipeProdukSTS.CurrentValue,
            ];
            listWrk3 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk3, this);
            string? dispVal3 = TipeProdukSTS.DisplayValue(listWrk3);
            if (!Empty(dispVal3))
                TipeProdukSTS.ViewValue = dispVal3;

            // akhirlookupbung
            TipeProdukSTS.ViewCustomAttributes = "";

            // TipePenyaluran
            if (!Empty(TipePenyaluran.CurrentValue)) {
                TipePenyaluran.ViewValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
            } else {
                TipePenyaluran.ViewValue = DbNullValue;
            }
            TipePenyaluran.ViewCustomAttributes = "";

            // JenisProduk

            // awallookupbung
            string curVal5 = ConvertToString(JenisProduk.CurrentValue);
            JenisProduk.ViewValue = Empty(curVal5) ? DbNullValue : JenisProduk.CurrentValue;
            if (!Empty(curVal5)) {
                if (JenisProduk.Lookup != null && IsDictionary(JenisProduk.Lookup?.Options) && JenisProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    JenisProduk.ViewValue = JenisProduk.LookupCacheOption(curVal5);
                } else { // Lookup from database // DN
                    string filterWrk5 = SearchFilter(JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", JenisProduk.CurrentValue, JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                    string? sqlWrk5 = JenisProduk.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk5?.Count > 0 && JenisProduk.Lookup != null) { // Lookup values found
                        var listwrk = JenisProduk.Lookup?.RenderViewRow(rswrk5[0]);
                        JenisProduk.ViewValue = JenisProduk.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            JenisProduk.ViewCustomAttributes = "";

            // IdModa

            // awallookupbung
            string curVal6 = ConvertToString(IdModa.CurrentValue);
            IdModa.ViewValue = Empty(curVal6) ? DbNullValue : FormatNumber(IdModa.CurrentValue, IdModa.FormatPattern);
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
                    }
                }
            }

            // akhirlookupbung
            IdModa.ViewCustomAttributes = "";

            // IdTangki

            // awallookupbung
            string curVal7 = ConvertToString(IdTangki.CurrentValue);
            IdTangki.ViewValue = Empty(curVal7) ? DbNullValue : FormatNumber(IdTangki.CurrentValue, IdTangki.FormatPattern);
            if (!Empty(curVal7)) {
                if (IdTangki.Lookup != null && IsDictionary(IdTangki.Lookup?.Options) && IdTangki.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdTangki.ViewValue = IdTangki.LookupCacheOption(curVal7);
                } else { // Lookup from database // DN
                    string filterWrk7 = SearchFilter(IdTangki.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdTangki.CurrentValue, IdTangki.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                    var lookupFilter7 = () => IdTangki.GetSelectFilter();
                    string? sqlWrk7 = IdTangki.Lookup?.GetSql(false, filterWrk7, lookupFilter7, this, true, true);
                    List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk7?.Count > 0 && IdTangki.Lookup != null) { // Lookup values found
                        var listwrk = IdTangki.Lookup?.RenderViewRow(rswrk7[0]);
                        IdTangki.ViewValue = IdTangki.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            IdTangki.ViewCustomAttributes = "";

            // StatusProses
            StatusProses.ViewValue = StatusProses.CurrentValue;
            StatusProses.ViewCustomAttributes = "";

            // LookupNoPenyaluran
            if (!Empty(LookupNoPenyaluran.CurrentValue)) {
                LookupNoPenyaluran.ViewValue = LookupNoPenyaluran.OptionCaption(ConvertToString(LookupNoPenyaluran.CurrentValue));
            } else {
                LookupNoPenyaluran.ViewValue = DbNullValue;
            }
            LookupNoPenyaluran.ViewCustomAttributes = "";

            // NoPenyaluran
            NoPenyaluran.ViewValue = ConvertToString(NoPenyaluran.CurrentValue); // DN
            NoPenyaluran.ViewCustomAttributes = "";

            // PersentaseProgress
            PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
            PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
            PersentaseProgress.ViewCustomAttributes = "";

            // Catatan
            Catatan.ViewValue = Catatan.CurrentValue;
            Catatan.ViewCustomAttributes = "";

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

            // PlantForLookup
            PlantForLookup.ViewValue = PlantForLookup.CurrentValue;
            PlantForLookup.ViewCustomAttributes = "";

            // LookupTipeProduk
            LookupTipeProduk.ViewValue = LookupTipeProduk.CurrentValue;
            LookupTipeProduk.ViewCustomAttributes = "";

            // LookupJenisPlant
            LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
            LookupJenisPlant.ViewCustomAttributes = "";

            // IdPenimbunanPenyaluran
            IdPenimbunanPenyaluran.HrefValue = "";
            IdPenimbunanPenyaluran.TooltipValue = "";

            // NomorPenimbunanPenyaluran
            NomorPenimbunanPenyaluran.HrefValue = "";
            NomorPenimbunanPenyaluran.TooltipValue = "";

            // Proses
            Proses2.HrefValue = "";
            Proses2.TooltipValue = "";

            // IdTemplate
            IdTemplate.HrefValue = "";
            IdTemplate.TooltipValue = "";

            // LookupPlant
            LookupPlant.HrefValue = "";
            LookupPlant.TooltipValue = "";

            // Plant
            Plant.HrefValue = "";
            Plant.TooltipValue = "";

            // TipeProdukSTS
            TipeProdukSTS.HrefValue = "";
            TipeProdukSTS.TooltipValue = "";

            // TipePenyaluran
            TipePenyaluran.HrefValue = "";
            TipePenyaluran.TooltipValue = "";

            // JenisProduk
            JenisProduk.HrefValue = "";
            JenisProduk.TooltipValue = "";

            // IdModa
            IdModa.HrefValue = "";
            IdModa.TooltipValue = "";

            // IdTangki
            IdTangki.HrefValue = "";
            IdTangki.TooltipValue = "";

            // StatusProses
            StatusProses.HrefValue = "";
            StatusProses.TooltipValue = "";

            // LookupNoPenyaluran
            LookupNoPenyaluran.HrefValue = "";
            LookupNoPenyaluran.TooltipValue = "";

            // NoPenyaluran
            NoPenyaluran.HrefValue = "";
            NoPenyaluran.TooltipValue = "";

            // PersentaseProgress
            PersentaseProgress.HrefValue = "";
            PersentaseProgress.TooltipValue = "";

            // Catatan
            Catatan.HrefValue = "";
            Catatan.TooltipValue = "";

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

            // PlantForLookup
            PlantForLookup.HrefValue = "";
            PlantForLookup.TooltipValue = "";

            // LookupTipeProduk
            LookupTipeProduk.HrefValue = "";
            LookupTipeProduk.TooltipValue = "";

            // LookupJenisPlant
            LookupJenisPlant.HrefValue = "";
            LookupJenisPlant.TooltipValue = "";

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

            // IdPenimbunanPenyaluran
            IdPenimbunanPenyaluran.SetupEditAttributes();
            IdPenimbunanPenyaluran.EditValue = IdPenimbunanPenyaluran.CurrentValue;
            IdPenimbunanPenyaluran.EditValue = FormatNumber(IdPenimbunanPenyaluran.EditValue, IdPenimbunanPenyaluran.FormatPattern);
            IdPenimbunanPenyaluran.ViewCustomAttributes = "";

            // NomorPenimbunanPenyaluran
            NomorPenimbunanPenyaluran.SetupEditAttributes();
            NomorPenimbunanPenyaluran.EditValue = ConvertToString(NomorPenimbunanPenyaluran.CurrentValue); // DN
            NomorPenimbunanPenyaluran.ViewCustomAttributes = "";

            // Proses
            Proses2.SetupEditAttributes();
            if (!Proses2.Raw)
                Proses2.CurrentValue = HtmlDecode(Proses2.CurrentValue);
            Proses2.EditValue = Proses2.CurrentValue;
            Proses2.PlaceHolder = RemoveHtml(Proses2.Caption);

            // IdTemplate
            IdTemplate.SetupEditAttributes();
            IdTemplate.CurrentValue = FormatNumber(IdTemplate.CurrentValue, IdTemplate.FormatPattern);
            if (!Empty(IdTemplate.EditValue) && IsNumeric(IdTemplate.EditValue))
                IdTemplate.EditValue = FormatNumber(IdTemplate.EditValue, null);

            // LookupPlant
            LookupPlant.SetupEditAttributes();
            LookupPlant.EditValue = LookupPlant.Options(true);
            LookupPlant.PlaceHolder = RemoveHtml(LookupPlant.Caption);
            if (!Empty(LookupPlant.EditValue) && IsNumeric(LookupPlant.EditValue))
                LookupPlant.EditValue = FormatNumber(LookupPlant.EditValue, null);

            // Plant
            Plant.SetupEditAttributes();
            Plant.EditValue = ConvertToString(Plant.CurrentValue); // DN

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

            // TipeProdukSTS
            TipeProdukSTS.SetupEditAttributes();
            List<object?>? listWrk3 = [ // DN
                TipeProdukSTS.CurrentValue,
                TipeProdukSTS.CurrentValue,
            ];
            listWrk3 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk3, this);
            string? dispVal3 = TipeProdukSTS.DisplayValue(listWrk3);
            if (!Empty(dispVal3))
                TipeProdukSTS.EditValue = dispVal3;

            // akhirlookupbung
            TipeProdukSTS.ViewCustomAttributes = "";

            // TipePenyaluran
            TipePenyaluran.SetupEditAttributes();
            if (!Empty(TipePenyaluran.CurrentValue)) {
                TipePenyaluran.EditValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
            } else {
                TipePenyaluran.EditValue = DbNullValue;
            }
            TipePenyaluran.ViewCustomAttributes = "";

            // JenisProduk
            JenisProduk.SetupEditAttributes();

            // awallookupbung
            string curVal5 = ConvertToString(JenisProduk.CurrentValue);
            JenisProduk.EditValue = Empty(curVal5) ? DbNullValue : JenisProduk.CurrentValue;
            if (!Empty(curVal5)) {
                if (JenisProduk.Lookup != null && IsDictionary(JenisProduk.Lookup?.Options) && JenisProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    JenisProduk.EditValue = JenisProduk.LookupCacheOption(curVal5);
                } else { // Lookup from database // DN
                    string filterWrk5 = SearchFilter(JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", JenisProduk.CurrentValue, JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                    string? sqlWrk5 = JenisProduk.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk5?.Count > 0 && JenisProduk.Lookup != null) { // Lookup values found
                        var listwrk = JenisProduk.Lookup?.RenderViewRow(rswrk5[0]);
                        JenisProduk.EditValue = JenisProduk.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            JenisProduk.ViewCustomAttributes = "";

            // IdModa
            IdModa.SetupEditAttributes();

            // awallookupbung
            string curVal6 = ConvertToString(IdModa.CurrentValue);
            IdModa.EditValue = Empty(curVal6) ? DbNullValue : FormatNumber(IdModa.CurrentValue, IdModa.FormatPattern);
            if (!Empty(curVal6)) {
                if (IdModa.Lookup != null && IsDictionary(IdModa.Lookup?.Options) && IdModa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdModa.EditValue = IdModa.LookupCacheOption(curVal6);
                } else { // Lookup from database // DN
                    string filterWrk6 = SearchFilter(IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", IdModa.CurrentValue, IdModa.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                    string? sqlWrk6 = IdModa.Lookup?.GetSql(false, filterWrk6, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk6 = sqlWrk6 != null ? Connection.GetRows(sqlWrk6) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk6?.Count > 0 && IdModa.Lookup != null) { // Lookup values found
                        var listwrk = IdModa.Lookup?.RenderViewRow(rswrk6[0]);
                        IdModa.EditValue = IdModa.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            IdModa.ViewCustomAttributes = "";

            // IdTangki
            IdTangki.SetupEditAttributes();

            // awallookupbung
            string curVal7 = ConvertToString(IdTangki.CurrentValue);
            IdTangki.EditValue = Empty(curVal7) ? DbNullValue : FormatNumber(IdTangki.CurrentValue, IdTangki.FormatPattern);
            if (!Empty(curVal7)) {
                if (IdTangki.Lookup != null && IsDictionary(IdTangki.Lookup?.Options) && IdTangki.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdTangki.EditValue = IdTangki.LookupCacheOption(curVal7);
                } else { // Lookup from database // DN
                    string filterWrk7 = SearchFilter(IdTangki.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdTangki.CurrentValue, IdTangki.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                    var lookupFilter7 = () => IdTangki.GetSelectFilter();
                    string? sqlWrk7 = IdTangki.Lookup?.GetSql(false, filterWrk7, lookupFilter7, this, true, true);
                    List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk7?.Count > 0 && IdTangki.Lookup != null) { // Lookup values found
                        var listwrk = IdTangki.Lookup?.RenderViewRow(rswrk7[0]);
                        IdTangki.EditValue = IdTangki.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            IdTangki.ViewCustomAttributes = "";

            // StatusProses
            StatusProses.SetupEditAttributes();

            // LookupNoPenyaluran
            LookupNoPenyaluran.SetupEditAttributes();
            LookupNoPenyaluran.EditValue = LookupNoPenyaluran.Options(true);
            LookupNoPenyaluran.PlaceHolder = RemoveHtml(LookupNoPenyaluran.Caption);

            // NoPenyaluran
            NoPenyaluran.SetupEditAttributes();
            NoPenyaluran.EditValue = ConvertToString(NoPenyaluran.CurrentValue); // DN
            NoPenyaluran.ViewCustomAttributes = "";

            // PersentaseProgress
            PersentaseProgress.SetupEditAttributes();
            PersentaseProgress.CurrentValue = FormatPercent(PersentaseProgress.CurrentValue, PersentaseProgress.FormatPattern);

            // Catatan
            Catatan.SetupEditAttributes();
            Catatan.EditValue = Catatan.CurrentValue; // DN
            Catatan.PlaceHolder = RemoveHtml(Catatan.Caption);

            // DibuatOleh

            // TanggalDibuat

            // DiperbaruiOleh

            // TanggalDiperbarui

            // PlantForLookup
            PlantForLookup.SetupEditAttributes();

            // LookupTipeProduk
            LookupTipeProduk.SetupEditAttributes();

            // LookupJenisPlant
            LookupJenisPlant.SetupEditAttributes();

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
                        doc.ExportCaption(IdPenimbunanPenyaluran);
                        doc.ExportCaption(NomorPenimbunanPenyaluran);
                        doc.ExportCaption(Proses2);
                        doc.ExportCaption(IdTemplate);
                        doc.ExportCaption(LookupPlant);
                        doc.ExportCaption(Plant);
                        doc.ExportCaption(TipeProdukSTS);
                        doc.ExportCaption(TipePenyaluran);
                        doc.ExportCaption(JenisProduk);
                        doc.ExportCaption(IdModa);
                        doc.ExportCaption(IdTangki);
                        doc.ExportCaption(StatusProses);
                        doc.ExportCaption(NoPenyaluran);
                        doc.ExportCaption(PersentaseProgress);
                        doc.ExportCaption(Catatan);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
                    } else {
                        doc.ExportCaption(Proses2);
                        doc.ExportCaption(Plant);
                        doc.ExportCaption(TipeProdukSTS);
                        doc.ExportCaption(TipePenyaluran);
                        doc.ExportCaption(JenisProduk);
                        doc.ExportCaption(IdModa);
                        doc.ExportCaption(IdTangki);
                        doc.ExportCaption(StatusProses);
                        doc.ExportCaption(NoPenyaluran);
                        doc.ExportCaption(PersentaseProgress);
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
                            await doc.ExportField(IdPenimbunanPenyaluran);
                            await doc.ExportField(NomorPenimbunanPenyaluran);
                            await doc.ExportField(Proses2);
                            await doc.ExportField(IdTemplate);
                            await doc.ExportField(LookupPlant);
                            await doc.ExportField(Plant);
                            await doc.ExportField(TipeProdukSTS);
                            await doc.ExportField(TipePenyaluran);
                            await doc.ExportField(JenisProduk);
                            await doc.ExportField(IdModa);
                            await doc.ExportField(IdTangki);
                            await doc.ExportField(StatusProses);
                            await doc.ExportField(NoPenyaluran);
                            await doc.ExportField(PersentaseProgress);
                            await doc.ExportField(Catatan);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
                        } else {
                            await doc.ExportField(Proses2);
                            await doc.ExportField(Plant);
                            await doc.ExportField(TipeProdukSTS);
                            await doc.ExportField(TipePenyaluran);
                            await doc.ExportField(JenisProduk);
                            await doc.ExportField(IdModa);
                            await doc.ExportField(IdTangki);
                            await doc.ExportField(StatusProses);
                            await doc.ExportField(NoPenyaluran);
                            await doc.ExportField(PersentaseProgress);
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
            // Enter your code here
            var currentUser = CurrentUserLevel();
            var idPosition = CurrentUserInfo("IdPosition");
            if (currentUser == "-1" || currentUser == "3")
            {
                return;
            }
            if (idPosition == null){
                AddFilter(ref filter, "1=0");
                return;
            }
            if (currentUser == "4")
            {
                string selectPlntByRegion = $@"
                    Plant IN (
                        SELECT IdPlant FROM MappingPosition WHERE IdRegion IN (
                            SELECT IdRegion FROM MappingPosition WHERE IdPosition = {idPosition}
                        )
                    )
                ";
                AddFilter(ref filter, selectPlntByRegion);
                return;
            }
            AddFilter(ref filter, $"Plant IN (SELECT IdPlant FROM MappingPosition WHERE IdPosition = {idPosition})");
        }

        // Recordset Selected event
        public void RecordsetSelected(DbDataReader rs) {
            // Enter your code here
        }

        // Recordset Searching event
        public void RecordsetSearching(ref string filter) {
            string x_TanggalDibuat = HttpContext.Request.Query["x_TanggalDibuat"];
            string y_TanggalDibuat = HttpContext.Request.Query["y_TanggalDibuat"];
            string x_TanggalDiperbarui = HttpContext.Request.Query["x_TanggalDiperbarui"];
            string y_TanggalDiperbarui = HttpContext.Request.Query["y_TanggalDiperbarui"];
            if (!string.IsNullOrEmpty(x_TanggalDibuat) && !string.IsNullOrEmpty(y_TanggalDibuat))
            {
                string pattern = @"\[TanggalDibuat\]\s*=\s*'[^']+'";
                string replacement = $"([TanggalDibuat] BETWEEN '{x_TanggalDibuat}' AND '{y_TanggalDibuat}')";
                filter = Regex.Replace(filter, pattern, replacement);
            }
            if (!string.IsNullOrEmpty(x_TanggalDiperbarui) && !string.IsNullOrEmpty(y_TanggalDiperbarui))
            {
                string pattern = @"\[TanggalDiperbarui\]\s*=\s*'[^']+'";
                string replacement = $"([TanggalDiperbarui] BETWEEN '{x_TanggalDiperbarui}' AND '{y_TanggalDiperbarui}')";
                filter = Regex.Replace(filter, pattern, replacement);
            }
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
            try {
                // Generate nomor penimbunan penyaluran
                var idPlant        = rsnew["Plant"].ToString();
                var idTangki       = rsnew["IdTangki"].ToString();
                var plantForLookup = rsnew["PlantForLookup"].ToString();
                var tipe           = rsnew["TipePenyaluran"].ToString();
                string sqlGen = $"EXEC GenerateNomorReferensiPenimbunan {idPlant}, {idTangki}, 'PenimbunanPenyaluran', '{tipe}'";
                var nomorRef = ExecuteScalar(sqlGen) ?? throw new Exception("Gagal menghasilkan NomorReferensi.");
                rsnew["NomorPenimbunanPenyaluran"] = nomorRef.ToString();

                // Ambil waktu plant berdasarkan nomor referensi
                DateTime plantTime = DateTime.Now; // fallback
                var plantTimeObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @NomorReferensi = '{nomorRef}'");
                if (plantTimeObj != null && DateTime.TryParse(plantTimeObj.ToString(), out var tmp))
                    plantTime = tmp;

                // Isi kolom waktu
                rsnew["TanggalDibuat"]      = plantTime;
                rsnew["TanggalDiperbarui"]  = plantTime;
                rsnew["DibuatOleh"]         = CurrentUserName();
                rsnew["DiperbaruiOleh"]     = CurrentUserName();
            } catch (Exception ex) {
                Log("Error in Row_Inserting (GenerateNomorReferensi): " + ex.Message);
                CancelMessage = "Gagal generate Nomor Referensi: " + ex.Message;
                return false;
            }
            return true;
        }

        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
            try
            {
                int idModa = rsnew.ContainsKey("IdModa") && rsnew["IdModa"] != null ? Convert.ToInt32(rsnew["IdModa"]) : 0;
                string nomorReferensi = rsnew.ContainsKey("NomorPenimbunanPenyaluran") && rsnew["NomorPenimbunanPenyaluran"] != null ? rsnew["NomorPenimbunanPenyaluran"].ToString().Replace("'", "''") : "";
                string tipePenyaluran = rsnew.ContainsKey("TipePenyaluran") && rsnew["TipePenyaluran"] != null ? rsnew["TipePenyaluran"].ToString() : "";
                string dibuatOleh = CurrentUserName().Replace("'", "''");
                string? noPenyaluran = rsnew.ContainsKey("NoPenyaluran") && rsnew["NoPenyaluran"] != null ? rsnew["NoPenyaluran"].ToString().Replace("'", "''") : null;
                string sql;
                if (tipePenyaluran == "Sales")
                    sql = $"EXEC GenerateProsesAktivitas_PenimbunanPenyaluran '{nomorReferensi}', {idModa}, '{dibuatOleh}'";
                else
                {
                    string jenisProses = idModa == 12 ? "PenyimpananPenyaluranKonsinyasiPipaJarakDekat" : "PenimbunanPenyaluran";
                    string noPenyaluranSql = noPenyaluran != null ? $"'{noPenyaluran}'" : "NULL";
                    sql = $"EXEC GenerateProsesAktivitas_PenimbunanPenyaluranKonsinyasi '{nomorReferensi}', '{jenisProses}', '{dibuatOleh}', {noPenyaluranSql}, {idModa}";
                }
                ExecuteScalar(sql);
            }
            catch (Exception ex)
            {
                Log("Error in RowInserted (Generate Proses & Aktivitas): " + ex.Message);
            }
        }
        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            try {
                // Ambil NomorPenimbunanPenyaluran dari rsnew jika ada, kalau tidak pakai nilai lama
                string nomorRef = rsnew.ContainsKey("NomorPenimbunanPenyaluran")
                    ? rsnew["NomorPenimbunanPenyaluran"].ToString()
                    : rsold["NomorPenimbunanPenyaluran"].ToString();

                // Panggil GetPlantDateTime untuk mendapatkan waktu plant
                DateTime plantTime = DateTime.Now;
                var plantObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @NomorReferensi = '{nomorRef}'");
                if (plantObj != null && DateTime.TryParse(plantObj.ToString(), out var tmp))
                    plantTime = tmp;

                // Update kolom pembaruan
                rsnew["DiperbaruiOleh"]    = CurrentUserName();
                rsnew["TanggalDiperbarui"] = plantTime;
            } catch (Exception ex) {
                Log("Error in Row_Updating: " + ex.Message);
                CancelMessage = "Gagal memperbarui data: " + ex.Message;
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
        public bool RowDeleting(Dictionary<string, object> rs) 
        {
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
            // Lookup Selecting event
            if (fld.FieldVar == "x_IdModa")
                fld.Lookup.Distinct = false;
            // if (fld.Name != "Plant" || !Security.IsLoggedIn)
            //     return;

            // var currentUserLevel = CurrentUserLevel();
            // var userPlantId = CurrentUserInfo("Plant");
            // var idRegion = CurrentUserInfo("Region");
            // List<string> plantConditions = new();

            // if ((currentUserLevel == "1" || currentUserLevel == "2" || currentUserLevel == "5") && userPlantId != null) {
            //     fld.Lookup.UserFilter = "IdPlant = " + userPlantId;
            // } else if (currentUserLevel == "4") {
            //     if (idRegion == null) {
            //         fld.Lookup.UserFilter = "1=0"; // tidak ada data
            //         return;
            //     }

            //     string selectPlntByRegion = @"SELECT IdPlant FROM MasterPlant WHERE Region = @Region";
            //     using (SqlConnection sqlConnectionPlant = GetConnection("Db").OpenConnection())
            //     using (SqlCommand cmdRegion = new SqlCommand(selectPlntByRegion, sqlConnectionPlant)) {
            //         using (SqlDataReader readerRegion = cmdRegion.ExecuteReader()) {
            //             while (readerRegion.Read()) {
            //                 string plantId = readerRegion["IdPlant"].ToString() ?? "0";
            //                 plantConditions.Add(plantId);
            //             }
            //         }
            //     }

            //     fld.Lookup.UserFilter = plantConditions.Count > 0 
            //         ? "IdPlant IN (" + string.Join(",", plantConditions) + ")" 
            //         : "1=0";
            // }
        }
        // Row Rendering event
        public void RowRendering() {
            if (TipeProdukSTS.CurrentValue == null || 
                string.IsNullOrEmpty(TipeProdukSTS.CurrentValue.ToString()))
            {
                TipeProdukSTS.ViewValue = "";
            }
            else
            {
                TipeProdukSTS.ViewValue = TipeProdukSTS.CurrentValue;
            }
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
