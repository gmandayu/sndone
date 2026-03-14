namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penerimaan
    /// </summary>
    [MaybeNull]
    public static Penerimaan penerimaan
    {
        get => HttpData.Resolve<Penerimaan>("Penerimaan");
        set => HttpData["Penerimaan"] = value;
    }

    /// <summary>
    /// Table class for Penerimaan
    /// </summary>
    public class Penerimaan : DbTable
    {
        public override Dictionary<string, string> KeyFields { get; set; } = new() { // DN
            { "IdPenerimaan", "IdPenerimaan" },
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

        public readonly DbField<SqlDbType> IdPenerimaan;

        public readonly DbField<SqlDbType> NomorPenerimaan;

        public readonly DbField<SqlDbType> Proses2;

        public readonly DbField<SqlDbType> NomorVoyage;

        public readonly DbField<SqlDbType> NomorPengiriman;

        public readonly DbField<SqlDbType> LookupPlant;

        public readonly DbField<SqlDbType> IdPlant;

        public readonly DbField<SqlDbType> TipeProdukSTS;

        public readonly DbField<SqlDbType> KodeProduk;

        public readonly DbField<SqlDbType> ModaTransportasi;

        public readonly DbField<SqlDbType> NamaKapal;

        public readonly DbField<SqlDbType> DetailRTW;

        public readonly DbField<SqlDbType> Refinery;

        public readonly DbField<SqlDbType> IdPenyaluran;

        public readonly DbField<SqlDbType> PenyaluranLookup;

        public readonly DbField<SqlDbType> TanggalSandar;

        public readonly DbField<SqlDbType> IdDermaga;

        public readonly DbField<SqlDbType> StatusProses;

        public readonly DbField<SqlDbType> PersentaseProgress;

        public readonly DbField<SqlDbType> IdTemplate;

        public readonly DbField<SqlDbType> Catatan;

        public readonly DbField<SqlDbType> DibuatOleh;

        public readonly DbField<SqlDbType> TanggalDibuat;

        public readonly DbField<SqlDbType> DiperbaruiOleh;

        public readonly DbField<SqlDbType> TanggalDiperbarui;

        public readonly DbField<SqlDbType> LookupTipeProduk;

        public readonly DbField<SqlDbType> LookupJenisPlant;

        // Constructor
        public Penerimaan()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "Penerimaan";
            Name = "Penerimaan";
            Type = "TABLE";
            UpdateTable = "dbo.Penerimaan"; // Update Table
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

            // IdPenerimaan
            IdPenerimaan = new(this, "x_IdPenerimaan", 3, SqlDbType.Int) {
                Name = "IdPenerimaan",
                Expression = "[IdPenerimaan]",
                BasicSearchExpression = "CAST([IdPenerimaan] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdPenerimaan]",
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
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "IdPenerimaan", "CustomMsg"),
                IsUpload = false
            };
            IdPenerimaan.Raw = true;
            Fields.Add("IdPenerimaan", IdPenerimaan);

            // NomorPenerimaan
            NomorPenerimaan = new(this, "x_NomorPenerimaan", 200, SqlDbType.VarChar) {
                Name = "NomorPenerimaan",
                Expression = "[NomorPenerimaan]",
                BasicSearchExpression = "[NomorPenerimaan]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomorPenerimaan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "NomorPenerimaan", "CustomMsg"),
                IsUpload = false
            };
            NomorPenerimaan.Lookup = new Lookup<DbField>(NomorPenerimaan, "Penerimaan", true, "NomorPenerimaan", new List<string> {"NomorPenerimaan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NomorPenerimaan", NomorPenerimaan);

            // Proses
            Proses2 = new(this, "x_Proses2", 202, SqlDbType.NVarChar) {
                Name = "Proses",
                Expression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenerimaan AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenerimaan AS NVARCHAR(50))+'</a>'",
                UseBasicSearch = true,
                BasicSearchExpression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenerimaan AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenerimaan AS NVARCHAR(50))+'</a>'",
                DateTimeFormat = -1,
                VirtualExpression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenerimaan AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenerimaan AS NVARCHAR(50))+'</a>'",
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
                CustomMessage = Language.FieldPhrase("Penerimaan", "Proses2", "CustomMsg"),
                IsUpload = false
            };
            Proses2.Lookup = new Lookup<DbField>(Proses2, "Penerimaan", true, "Proses", new List<string> {"Proses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Proses", Proses2);

            // NomorVoyage
            NomorVoyage = new(this, "x_NomorVoyage", 200, SqlDbType.VarChar) {
                Name = "NomorVoyage",
                Expression = "[NomorVoyage]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NomorVoyage]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomorVoyage]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "NomorVoyage", "CustomMsg"),
                IsUpload = false
            };
            NomorVoyage.Lookup = new Lookup<DbField>(NomorVoyage, "Penerimaan", true, "NomorVoyage", new List<string> {"NomorVoyage", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NomorVoyage", NomorVoyage);

            // NomorPengiriman
            NomorPengiriman = new(this, "x_NomorPengiriman", 200, SqlDbType.VarChar) {
                Name = "NomorPengiriman",
                Expression = "[NomorPengiriman]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NomorPengiriman]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomorPengiriman]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "NomorPengiriman", "CustomMsg"),
                IsUpload = false
            };
            NomorPengiriman.Lookup = new Lookup<DbField>(NomorPengiriman, "Penerimaan", true, "NomorPengiriman", new List<string> {"NomorPengiriman", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NomorPengiriman", NomorPengiriman);

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
                CustomMessage = Language.FieldPhrase("Penerimaan", "LookupPlant", "CustomMsg"),
                IsUpload = false
            };
            LookupPlant.Raw = true;
            LookupPlant.Lookup = new Lookup<DbField>(LookupPlant, "Penerimaan", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {"x_IdDermaga"}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LookupPlant", LookupPlant);

            // IdPlant
            IdPlant = new(this, "x_IdPlant", 3, SqlDbType.Int) {
                Name = "IdPlant",
                Expression = "[IdPlant]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([IdPlant] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdPlant]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "IdPlant", "CustomMsg"),
                IsUpload = false
            };
            IdPlant.Raw = true;
            IdPlant.Lookup = new Lookup<DbField>(IdPlant, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {"TipeProduk", "JenisPlant"}, new List<string> {"x_LookupTipeProduk", "x_LookupJenisPlant"}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, IdPlant) + "',[Nama_Terminal])");
            Fields.Add("IdPlant", IdPlant);

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
                CustomMessage = Language.FieldPhrase("Penerimaan", "TipeProdukSTS", "CustomMsg"),
                IsUpload = false
            };
            TipeProdukSTS.Lookup = new Lookup<DbField>(TipeProdukSTS, "MasterProduk", true, "TipeProduk", new List<string> {"TipeProduk", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {"TipeProduk"}, new List<string> {"x_LookupTipeProduk"}, false, "", "", "[TipeProduk]");
            Fields.Add("TipeProdukSTS", TipeProdukSTS);

            // KodeProduk
            KodeProduk = new(this, "x_KodeProduk", 200, SqlDbType.VarChar) {
                Name = "KodeProduk",
                Expression = "[KodeProduk]",
                UseBasicSearch = true,
                BasicSearchExpression = "[KodeProduk]",
                DateTimeFormat = -1,
                VirtualExpression = "[KodeProduk]",
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
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "KodeProduk", "CustomMsg"),
                IsUpload = false
            };
            KodeProduk.Lookup = new Lookup<DbField>(KodeProduk, "MasterProduk", true, "NoProduk", new List<string> {"NoProduk", "NamaProduk", "", ""}, "", "", new List<string> {"x_LookupTipeProduk"}, new List<string> {}, new List<string> {"TipeProduk"}, new List<string> {"x_TipeProduk"}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([NoProduk],'" + ValueSeparator(1, KodeProduk) + "',[NamaProduk])");
            Fields.Add("KodeProduk", KodeProduk);

            // ModaTransportasi
            ModaTransportasi = new(this, "x_ModaTransportasi", 200, SqlDbType.VarChar) {
                Name = "ModaTransportasi",
                Expression = "[ModaTransportasi]",
                UseBasicSearch = true,
                BasicSearchExpression = "[ModaTransportasi]",
                DateTimeFormat = -1,
                VirtualExpression = "[ModaTransportasi]",
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
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "ModaTransportasi", "CustomMsg"),
                IsUpload = false
            };
            ModaTransportasi.Lookup = new Lookup<DbField>(ModaTransportasi, "MasterModa", true, "IdModa", new List<string> {"NamaModa", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaModa]");
            Fields.Add("ModaTransportasi", ModaTransportasi);

            // NamaKapal
            NamaKapal = new(this, "x_NamaKapal", 202, SqlDbType.NVarChar) {
                Name = "NamaKapal",
                Expression = "[NamaKapal]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NamaKapal]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaKapal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "NamaKapal", "CustomMsg"),
                IsUpload = false
            };
            NamaKapal.Lookup = new Lookup<DbField>(NamaKapal, "Penerimaan", true, "NamaKapal", new List<string> {"NamaKapal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NamaKapal", NamaKapal);

            // DetailRTW
            DetailRTW = new(this, "x_DetailRTW", 202, SqlDbType.NVarChar) {
                Name = "DetailRTW",
                Expression = "[DetailRTW]",
                BasicSearchExpression = "[DetailRTW]",
                DateTimeFormat = -1,
                VirtualExpression = "[DetailRTW]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "DetailRTW", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("DetailRTW", DetailRTW);

            // Refinery
            Refinery = new(this, "x_Refinery", 11, SqlDbType.Bit) {
                Name = "Refinery",
                Expression = "[Refinery]",
                BasicSearchExpression = "[Refinery]",
                DateTimeFormat = -1,
                VirtualExpression = "[Refinery]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                UseFilter = true, // Table header filter
                OptionCount = 2,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "Refinery", "CustomMsg"),
                IsUpload = false
            };
            Refinery.Raw = true;
            Refinery.Lookup = new Lookup<DbField>(Refinery, "Penerimaan", true, "Refinery", new List<string> {"Refinery", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Refinery.UserValues = ["1"];
            Fields.Add("Refinery", Refinery);

            // IdPenyaluran
            IdPenyaluran = new(this, "x_IdPenyaluran", 3, SqlDbType.Int) {
                Name = "IdPenyaluran",
                Expression = "[IdPenyaluran]",
                BasicSearchExpression = "CAST([IdPenyaluran] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdPenyaluran]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 1,
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "IdPenyaluran", "CustomMsg"),
                IsUpload = false
            };
            IdPenyaluran.Raw = true;
            IdPenyaluran.Lookup = new Lookup<DbField>(IdPenyaluran, "Penerimaan", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("IdPenyaluran", IdPenyaluran);

            // PenyaluranLookup
            PenyaluranLookup = new(this, "x_PenyaluranLookup", 3, SqlDbType.Int) {
                Name = "PenyaluranLookup",
                Expression = "IdPenyaluran",
                BasicSearchExpression = "CAST(IdPenyaluran AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "IdPenyaluran",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                IsCustom = true, // Custom field
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "PenyaluranLookup", "CustomMsg"),
                IsUpload = false
            };
            PenyaluranLookup.Raw = true;
            PenyaluranLookup.Lookup = new Lookup<DbField>(PenyaluranLookup, "Penyaluran", false, "IdPenyaluran", new List<string> {"NomorPenyaluran", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NomorPenyaluran]");
            Fields.Add("PenyaluranLookup", PenyaluranLookup);

            // TanggalSandar
            TanggalSandar = new(this, "x_TanggalSandar", 135, SqlDbType.DateTime) {
                Name = "TanggalSandar",
                Expression = "[TanggalSandar]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TanggalSandar]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[TanggalSandar]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "TanggalSandar", "CustomMsg"),
                IsUpload = false
            };
            TanggalSandar.Raw = true;
            TanggalSandar.Lookup = new Lookup<DbField>(TanggalSandar, "Penerimaan", true, "TanggalSandar", new List<string> {"TanggalSandar", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalSandar", TanggalSandar);

            // IdDermaga
            IdDermaga = new(this, "x_IdDermaga", 3, SqlDbType.Int) {
                Name = "IdDermaga",
                Expression = "[IdDermaga]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([IdDermaga] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdDermaga]",
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
                CustomMessage = Language.FieldPhrase("Penerimaan", "IdDermaga", "CustomMsg"),
                IsUpload = false
            };
            IdDermaga.Raw = true;
            IdDermaga.Lookup = new Lookup<DbField>(IdDermaga, "MasterDermaga", true, "IdDermaga", new List<string> {"Equipment_ID", "Jenis_Sartam", "Kapasitas_DWT", ""}, "", "", new List<string> {"x_LookupPlant"}, new List<string> {}, new List<string> {"Id_Plant"}, new List<string> {"x_Id_Plant"}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Equipment_ID],'" + ValueSeparator(1, IdDermaga) + "',[Jenis_Sartam],'" + ValueSeparator(2, IdDermaga) + "',[Kapasitas_DWT])");
            Fields.Add("IdDermaga", IdDermaga);

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
                CustomMessage = Language.FieldPhrase("Penerimaan", "StatusProses", "CustomMsg"),
                IsUpload = false
            };
            StatusProses.Lookup = new Lookup<DbField>(StatusProses, "Penerimaan", true, "StatusProses", new List<string> {"StatusProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            StatusProses.GetDefault = () => "Waiting";
            Fields.Add("StatusProses", StatusProses);

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
                CustomMessage = Language.FieldPhrase("Penerimaan", "PersentaseProgress", "CustomMsg"),
                IsUpload = false
            };
            PersentaseProgress.Raw = true;
            PersentaseProgress.Lookup = new Lookup<DbField>(PersentaseProgress, "Penerimaan", true, "PersentaseProgress", new List<string> {"PersentaseProgress", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            PersentaseProgress.GetDefault = () => 0;
            Fields.Add("PersentaseProgress", PersentaseProgress);

            // IdTemplate
            IdTemplate = new(this, "x_IdTemplate", 3, SqlDbType.Int) {
                Name = "IdTemplate",
                Expression = "[IdTemplate]",
                UseBasicSearch = true,
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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "IdTemplate", "CustomMsg"),
                IsUpload = false
            };
            IdTemplate.Raw = true;
            IdTemplate.Lookup = new Lookup<DbField>(IdTemplate, "Penerimaan", true, "IdTemplate", new List<string> {"IdTemplate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            IdTemplate.GetDefault = () => 1;
            Fields.Add("IdTemplate", IdTemplate);

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
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penerimaan", "Catatan", "CustomMsg"),
                IsUpload = false
            };
            Catatan.Lookup = new Lookup<DbField>(Catatan, "Penerimaan", true, "Catatan", new List<string> {"Catatan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("Penerimaan", "DibuatOleh", "CustomMsg"),
                IsUpload = false
            };
            DibuatOleh.Lookup = new Lookup<DbField>(DibuatOleh, "MasterUser", true, "IdUser", new List<string> {"Username", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[Username]");
            DibuatOleh.GetAutoUpdateValue = () => CurrentUserName();
            DibuatOleh.GetDefault = () => CurrentUserName();
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
                CustomMessage = Language.FieldPhrase("Penerimaan", "TanggalDibuat", "CustomMsg"),
                IsUpload = false
            };
            TanggalDibuat.Raw = true;
            TanggalDibuat.Lookup = new Lookup<DbField>(TanggalDibuat, "Penerimaan", true, "TanggalDibuat", new List<string> {"TanggalDibuat", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("Penerimaan", "DiperbaruiOleh", "CustomMsg"),
                IsUpload = false
            };
            DiperbaruiOleh.Lookup = new Lookup<DbField>(DiperbaruiOleh, "Penerimaan", true, "DiperbaruiOleh", new List<string> {"DiperbaruiOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("Penerimaan", "TanggalDiperbarui", "CustomMsg"),
                IsUpload = false
            };
            TanggalDiperbarui.Raw = true;
            TanggalDiperbarui.Lookup = new Lookup<DbField>(TanggalDiperbarui, "Penerimaan", true, "TanggalDiperbarui", new List<string> {"TanggalDiperbarui", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            TanggalDiperbarui.GetAutoUpdateValue = () => CurrentDateTime();
            Fields.Add("TanggalDiperbarui", TanggalDiperbarui);

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
                CustomMessage = Language.FieldPhrase("Penerimaan", "LookupTipeProduk", "CustomMsg"),
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
                CustomMessage = Language.FieldPhrase("Penerimaan", "LookupJenisPlant", "CustomMsg"),
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
            get => _sqlFrom ?? "dbo.Penerimaan";
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
                string select = "*, '<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenerimaan AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenerimaan AS NVARCHAR(50))+'</a>' AS [Proses], IdPenyaluran AS [PenyaluranLookup], '' AS [LookupTipeProduk], '' AS [LookupJenisPlant]";
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
                attr.Name == "IdPenerimaan");
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
                attr.Name == "IdPenerimaan");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Penerimaan type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                if (row.ContainsKey("IdPenerimaan"))
                    row["IdPenerimaan"] = lastInsertedId;
                else
                    row.Add("IdPenerimaan", lastInsertedId);
                IdPenerimaan.SetDbValue(lastInsertedId);
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Penerimaan type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Penerimaan type", "data");
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
                IdPenerimaan.DbValue = row["IdPenerimaan"]; // Set DB value only
                NomorPenerimaan.DbValue = row["NomorPenerimaan"]; // Set DB value only
                Proses2.DbValue = row["Proses"]; // Set DB value only
                NomorVoyage.DbValue = row["NomorVoyage"]; // Set DB value only
                NomorPengiriman.DbValue = row["NomorPengiriman"]; // Set DB value only
                LookupPlant.DbValue = row["LookupPlant"]; // Set DB value only
                IdPlant.DbValue = row["IdPlant"]; // Set DB value only
                TipeProdukSTS.DbValue = row["TipeProdukSTS"]; // Set DB value only
                KodeProduk.DbValue = row["KodeProduk"]; // Set DB value only
                ModaTransportasi.DbValue = row["ModaTransportasi"]; // Set DB value only
                NamaKapal.DbValue = row["NamaKapal"]; // Set DB value only
                DetailRTW.DbValue = row["DetailRTW"]; // Set DB value only
                Refinery.DbValue = (ConvertToBool(row["Refinery"]) ? "1" : "0"); // Set DB value only
                IdPenyaluran.DbValue = row["IdPenyaluran"]; // Set DB value only
                PenyaluranLookup.DbValue = row["PenyaluranLookup"]; // Set DB value only
                TanggalSandar.DbValue = row["TanggalSandar"]; // Set DB value only
                IdDermaga.DbValue = row["IdDermaga"]; // Set DB value only
                StatusProses.DbValue = row["StatusProses"]; // Set DB value only
                PersentaseProgress.DbValue = row["PersentaseProgress"]; // Set DB value only
                IdTemplate.DbValue = row["IdTemplate"]; // Set DB value only
                Catatan.DbValue = row["Catatan"]; // Set DB value only
                DibuatOleh.DbValue = row["DibuatOleh"]; // Set DB value only
                TanggalDibuat.DbValue = row["TanggalDibuat"]; // Set DB value only
                DiperbaruiOleh.DbValue = row["DiperbaruiOleh"]; // Set DB value only
                TanggalDiperbarui.DbValue = row["TanggalDiperbarui"]; // Set DB value only
                LookupTipeProduk.DbValue = row["LookupTipeProduk"]; // Set DB value only
                LookupJenisPlant.DbValue = row["LookupJenisPlant"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[IdPenerimaan] = @IdPenerimaan@";

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
                    return "PenerimaanList";
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
                "PenerimaanView" => Language.Phrase("View"),
                "PenerimaanEdit" => Language.Phrase("Edit"),
                "PenerimaanAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "PenerimaanList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "PenerimaanView",
                Config.ApiAddAction => "PenerimaanAdd",
                Config.ApiEditAction => "PenerimaanEdit",
                Config.ApiDeleteAction => "PenerimaanDelete",
                Config.ApiListAction => "PenerimaanList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "PenerimaanView",
                Config.ApiAddAction => "PenerimaanAdd",
                Config.ApiEditAction => "PenerimaanEdit",
                Config.ApiDeleteAction => "PenerimaanDelete",
                Config.ApiListAction => "PenerimaanList",
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
        public string ListUrl => "PenerimaanList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("PenerimaanView", parm);
            else
                url = KeyUrl("PenerimaanView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "PenerimaanAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "PenerimaanAdd?" + parm;
            else
                url = "PenerimaanAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("PenerimaanEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("PenerimaanList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("PenerimaanAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("PenerimaanList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("PenerimaanDelete", parm)); // DN
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
            json += "\"IdPenerimaan\":" + ConvertToJson(IdPenerimaan.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL // DN
        public string KeyUrl(string url, string parm = "")
        {
            if (!IsNull(IdPenerimaan.CurrentValue)) {
                url += "/" + IdPenerimaan.CurrentValue;
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
                if (RouteValues.TryGetValue("IdPenerimaan", out object? v0)) { // IdPenerimaan // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("IdPenerimaan");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (KeyFields.Count > 1 && (!IsArray(keys) || keys.Length != KeyFields.Count))
                    continue;
                if (!IsNumeric(keys)) // IdPenerimaan
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
                    IdPenerimaan.CurrentValue = keys;
                else
                    IdPenerimaan.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        // Load row values from recordset
        public void LoadListRowValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
            IdPenerimaan.SetDbValue(row["IdPenerimaan"]);
            NomorPenerimaan.SetDbValue(row["NomorPenerimaan"]);
            Proses2.SetDbValue(row["Proses"]);
            NomorVoyage.SetDbValue(row["NomorVoyage"]);
            NomorPengiriman.SetDbValue(row["NomorPengiriman"]);
            LookupPlant.SetDbValue(row["LookupPlant"]);
            IdPlant.SetDbValue(row["IdPlant"]);
            TipeProdukSTS.SetDbValue(row["TipeProdukSTS"]);
            KodeProduk.SetDbValue(row["KodeProduk"]);
            ModaTransportasi.SetDbValue(row["ModaTransportasi"]);
            NamaKapal.SetDbValue(row["NamaKapal"]);
            DetailRTW.SetDbValue(row["DetailRTW"]);
            Refinery.SetDbValue(ConvertToBool(row["Refinery"]) ? "1" : "0");
            IdPenyaluran.SetDbValue(row["IdPenyaluran"]);
            PenyaluranLookup.SetDbValue(row["PenyaluranLookup"]);
            TanggalSandar.SetDbValue(row["TanggalSandar"]);
            IdDermaga.SetDbValue(row["IdDermaga"]);
            StatusProses.SetDbValue(row["StatusProses"]);
            PersentaseProgress.SetDbValue(row["PersentaseProgress"]);
            IdTemplate.SetDbValue(row["IdTemplate"]);
            Catatan.SetDbValue(row["Catatan"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            LookupTipeProduk.SetDbValue(row["LookupTipeProduk"]);
            LookupJenisPlant.SetDbValue(row["LookupJenisPlant"]);
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "PenerimaanList";
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

            // IdPenerimaan

            // NomorPenerimaan
            NomorPenerimaan.CellCssStyle = "min-width: 15vw;";

            // Proses

            // NomorVoyage

            // NomorPengiriman

            // LookupPlant

            // IdPlant

            // TipeProdukSTS

            // KodeProduk

            // ModaTransportasi

            // NamaKapal

            // DetailRTW
            DetailRTW.CellCssStyle = "white-space: nowrap;";

            // Refinery

            // IdPenyaluran

            // PenyaluranLookup

            // TanggalSandar

            // IdDermaga

            // StatusProses

            // PersentaseProgress

            // IdTemplate

            // Catatan

            // DibuatOleh

            // TanggalDibuat

            // DiperbaruiOleh

            // TanggalDiperbarui

            // LookupTipeProduk
            LookupTipeProduk.CellCssStyle = "white-space: nowrap;";

            // LookupJenisPlant
            LookupJenisPlant.CellCssStyle = "white-space: nowrap;";

            // IdPenerimaan
            IdPenerimaan.ViewValue = IdPenerimaan.CurrentValue;
            IdPenerimaan.ViewCustomAttributes = "";

            // NomorPenerimaan
            NomorPenerimaan.ViewValue = ConvertToString(NomorPenerimaan.CurrentValue); // DN
            NomorPenerimaan.ViewCustomAttributes = "";

            // Proses
            Proses2.ViewValue = ConvertToString(Proses2.CurrentValue); // DN
            Proses2.ViewCustomAttributes = "";

            // NomorVoyage
            NomorVoyage.ViewValue = ConvertToString(NomorVoyage.CurrentValue); // DN
            NomorVoyage.ViewCustomAttributes = "";

            // NomorPengiriman
            NomorPengiriman.ViewValue = ConvertToString(NomorPengiriman.CurrentValue); // DN
            NomorPengiriman.ViewCustomAttributes = "";

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

            // KodeProduk
            string curVal4 = ConvertToString(KodeProduk.CurrentValue);
            if (!Empty(curVal4)) {
                if (KodeProduk.Lookup != null && IsDictionary(KodeProduk.Lookup?.Options) && KodeProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    KodeProduk.ViewValue = KodeProduk.LookupCacheOption(curVal4);
                } else { // Lookup from database // DN
                    string filterWrk4 = SearchFilter(KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", KodeProduk.CurrentValue, KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                    string? sqlWrk4 = KodeProduk.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk4?.Count > 0 && KodeProduk.Lookup != null) { // Lookup values found
                        var listwrk = KodeProduk.Lookup?.RenderViewRow(rswrk4[0]);
                        KodeProduk.ViewValue = KodeProduk.DisplayValue(listwrk);
                    } else {
                        KodeProduk.ViewValue = KodeProduk.CurrentValue;
                    }
                }
            } else {
                KodeProduk.ViewValue = DbNullValue;
            }
            KodeProduk.ViewCustomAttributes = "";

            // ModaTransportasi
            string curVal5 = ConvertToString(ModaTransportasi.CurrentValue);
            if (!Empty(curVal5)) {
                if (ModaTransportasi.Lookup != null && IsDictionary(ModaTransportasi.Lookup?.Options) && ModaTransportasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ModaTransportasi.ViewValue = ModaTransportasi.LookupCacheOption(curVal5);
                } else { // Lookup from database // DN
                    string filterWrk5 = SearchFilter(ModaTransportasi.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", ModaTransportasi.CurrentValue, ModaTransportasi.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                    string? sqlWrk5 = ModaTransportasi.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk5?.Count > 0 && ModaTransportasi.Lookup != null) { // Lookup values found
                        var listwrk = ModaTransportasi.Lookup?.RenderViewRow(rswrk5[0]);
                        ModaTransportasi.ViewValue = ModaTransportasi.DisplayValue(listwrk);
                    } else {
                        ModaTransportasi.ViewValue = ModaTransportasi.CurrentValue;
                    }
                }
            } else {
                ModaTransportasi.ViewValue = DbNullValue;
            }
            ModaTransportasi.ViewCustomAttributes = "";

            // NamaKapal
            NamaKapal.ViewValue = ConvertToString(NamaKapal.CurrentValue); // DN
            NamaKapal.ViewCustomAttributes = "";

            // DetailRTW
            DetailRTW.ViewValue = ConvertToString(DetailRTW.CurrentValue); // DN
            DetailRTW.ViewCustomAttributes = "";

            // Refinery
            if (ConvertToBool(Refinery.CurrentValue)) {
                Refinery.ViewValue = Refinery.TagCaption(1) != "" ? Refinery.TagCaption(1) : "Yes";
            } else {
                Refinery.ViewValue = Refinery.TagCaption(2) != "" ? Refinery.TagCaption(2) : "No";
            }
            Refinery.ViewCustomAttributes = "";

            // IdPenyaluran
            if (!Empty(IdPenyaluran.CurrentValue)) {
                IdPenyaluran.ViewValue = IdPenyaluran.OptionCaption(ConvertToString(IdPenyaluran.CurrentValue));
            } else {
                IdPenyaluran.ViewValue = DbNullValue;
            }
            IdPenyaluran.ViewCustomAttributes = "";

            // PenyaluranLookup
            PenyaluranLookup.ViewValue = PenyaluranLookup.CurrentValue;
            string curVal8 = ConvertToString(PenyaluranLookup.CurrentValue);
            if (!Empty(curVal8)) {
                if (PenyaluranLookup.Lookup != null && IsDictionary(PenyaluranLookup.Lookup?.Options) && PenyaluranLookup.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PenyaluranLookup.ViewValue = PenyaluranLookup.LookupCacheOption(curVal8);
                } else { // Lookup from database // DN
                    string filterWrk8 = SearchFilter(PenyaluranLookup.Lookup?.GetTable()?.Fields["IdPenyaluran"].SearchExpression, "=", PenyaluranLookup.CurrentValue, PenyaluranLookup.Lookup?.GetTable()?.Fields["IdPenyaluran"].SearchDataType, "");
                    string? sqlWrk8 = PenyaluranLookup.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk8?.Count > 0 && PenyaluranLookup.Lookup != null) { // Lookup values found
                        var listwrk = PenyaluranLookup.Lookup?.RenderViewRow(rswrk8[0]);
                        PenyaluranLookup.ViewValue = PenyaluranLookup.DisplayValue(listwrk);
                    } else {
                        PenyaluranLookup.ViewValue = FormatNumber(PenyaluranLookup.CurrentValue, PenyaluranLookup.FormatPattern);
                    }
                }
            } else {
                PenyaluranLookup.ViewValue = DbNullValue;
            }
            PenyaluranLookup.ViewCustomAttributes = "";

            // TanggalSandar
            TanggalSandar.ViewValue = TanggalSandar.CurrentValue;
            TanggalSandar.ViewValue = FormatDateTime(TanggalSandar.ViewValue, TanggalSandar.FormatPattern);
            TanggalSandar.ViewCustomAttributes = "";

            // IdDermaga
            string curVal9 = ConvertToString(IdDermaga.CurrentValue);
            if (!Empty(curVal9)) {
                if (IdDermaga.Lookup != null && IsDictionary(IdDermaga.Lookup?.Options) && IdDermaga.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdDermaga.ViewValue = IdDermaga.LookupCacheOption(curVal9);
                } else { // Lookup from database // DN
                    string filterWrk9 = SearchFilter(IdDermaga.Lookup?.GetTable()?.Fields["IdDermaga"].SearchExpression, "=", IdDermaga.CurrentValue, IdDermaga.Lookup?.GetTable()?.Fields["IdDermaga"].SearchDataType, "");
                    string? sqlWrk9 = IdDermaga.Lookup?.GetSql(false, filterWrk9, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk9 = sqlWrk9 != null ? Connection.GetRows(sqlWrk9) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk9?.Count > 0 && IdDermaga.Lookup != null) { // Lookup values found
                        var listwrk = IdDermaga.Lookup?.RenderViewRow(rswrk9[0]);
                        IdDermaga.ViewValue = IdDermaga.DisplayValue(listwrk);
                    } else {
                        IdDermaga.ViewValue = FormatNumber(IdDermaga.CurrentValue, IdDermaga.FormatPattern);
                    }
                }
            } else {
                IdDermaga.ViewValue = DbNullValue;
            }
            IdDermaga.ViewCustomAttributes = "";

            // StatusProses
            StatusProses.ViewValue = StatusProses.CurrentValue;
            StatusProses.ViewCustomAttributes = "";

            // PersentaseProgress
            PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
            PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
            PersentaseProgress.ViewCustomAttributes = "";

            // IdTemplate
            IdTemplate.ViewValue = IdTemplate.CurrentValue;
            IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
            IdTemplate.ViewCustomAttributes = "";

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

            // LookupTipeProduk
            LookupTipeProduk.ViewValue = LookupTipeProduk.CurrentValue;
            LookupTipeProduk.ViewCustomAttributes = "";

            // LookupJenisPlant
            LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
            LookupJenisPlant.ViewCustomAttributes = "";

            // IdPenerimaan
            IdPenerimaan.HrefValue = "";
            IdPenerimaan.TooltipValue = "";

            // NomorPenerimaan
            NomorPenerimaan.HrefValue = "";
            NomorPenerimaan.TooltipValue = "";

            // Proses
            Proses2.HrefValue = "";
            Proses2.TooltipValue = "";

            // NomorVoyage
            NomorVoyage.HrefValue = "";
            NomorVoyage.TooltipValue = "";

            // NomorPengiriman
            NomorPengiriman.HrefValue = "";
            NomorPengiriman.TooltipValue = "";

            // LookupPlant
            LookupPlant.HrefValue = "";
            LookupPlant.TooltipValue = "";

            // IdPlant
            IdPlant.HrefValue = "";
            IdPlant.TooltipValue = "";

            // TipeProdukSTS
            TipeProdukSTS.HrefValue = "";
            TipeProdukSTS.TooltipValue = "";

            // KodeProduk
            KodeProduk.HrefValue = "";
            KodeProduk.TooltipValue = "";

            // ModaTransportasi
            ModaTransportasi.HrefValue = "";
            ModaTransportasi.TooltipValue = "";

            // NamaKapal
            NamaKapal.HrefValue = "";
            NamaKapal.TooltipValue = "";

            // DetailRTW
            DetailRTW.HrefValue = "";
            DetailRTW.TooltipValue = "";

            // Refinery
            Refinery.HrefValue = "";
            Refinery.TooltipValue = "";

            // IdPenyaluran
            IdPenyaluran.HrefValue = "";
            IdPenyaluran.TooltipValue = "";

            // PenyaluranLookup
            PenyaluranLookup.HrefValue = "";
            PenyaluranLookup.TooltipValue = "";

            // TanggalSandar
            TanggalSandar.HrefValue = "";
            TanggalSandar.TooltipValue = "";

            // IdDermaga
            IdDermaga.HrefValue = "";
            IdDermaga.TooltipValue = "";

            // StatusProses
            StatusProses.HrefValue = "";
            StatusProses.TooltipValue = "";

            // PersentaseProgress
            PersentaseProgress.HrefValue = "";
            PersentaseProgress.TooltipValue = "";

            // IdTemplate
            IdTemplate.HrefValue = "";
            IdTemplate.TooltipValue = "";

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

            // IdPenerimaan
            IdPenerimaan.SetupEditAttributes();
            IdPenerimaan.EditValue = IdPenerimaan.CurrentValue;
            IdPenerimaan.ViewCustomAttributes = "";

            // NomorPenerimaan
            NomorPenerimaan.SetupEditAttributes();
            NomorPenerimaan.EditValue = ConvertToString(NomorPenerimaan.CurrentValue); // DN
            NomorPenerimaan.ViewCustomAttributes = "";

            // Proses
            Proses2.SetupEditAttributes();
            if (!Proses2.Raw)
                Proses2.CurrentValue = HtmlDecode(Proses2.CurrentValue);
            Proses2.EditValue = Proses2.CurrentValue;
            Proses2.PlaceHolder = RemoveHtml(Proses2.Caption);

            // NomorVoyage
            NomorVoyage.SetupEditAttributes();
            if (!NomorVoyage.Raw)
                NomorVoyage.CurrentValue = HtmlDecode(NomorVoyage.CurrentValue);
            NomorVoyage.EditValue = NomorVoyage.CurrentValue;
            NomorVoyage.PlaceHolder = RemoveHtml(NomorVoyage.Caption);

            // NomorPengiriman
            NomorPengiriman.SetupEditAttributes();
            if (!NomorPengiriman.Raw)
                NomorPengiriman.CurrentValue = HtmlDecode(NomorPengiriman.CurrentValue);
            NomorPengiriman.EditValue = NomorPengiriman.CurrentValue;
            NomorPengiriman.PlaceHolder = RemoveHtml(NomorPengiriman.Caption);

            // LookupPlant
            LookupPlant.SetupEditAttributes();
            LookupPlant.EditValue = LookupPlant.Options(true);
            LookupPlant.PlaceHolder = RemoveHtml(LookupPlant.Caption);
            if (!Empty(LookupPlant.EditValue) && IsNumeric(LookupPlant.EditValue))
                LookupPlant.EditValue = FormatNumber(LookupPlant.EditValue, null);

            // IdPlant
            IdPlant.SetupEditAttributes();
            IdPlant.EditValue = IdPlant.CurrentValue;
            string curVal2 = ConvertToString(IdPlant.CurrentValue);
            if (!Empty(curVal2)) {
                if (IdPlant.Lookup != null && IsDictionary(IdPlant.Lookup?.Options) && IdPlant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPlant.EditValue = IdPlant.LookupCacheOption(curVal2);
                } else { // Lookup from database // DN
                    string filterWrk2 = SearchFilter(IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", IdPlant.CurrentValue, IdPlant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk2 = IdPlant.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk2?.Count > 0 && IdPlant.Lookup != null) { // Lookup values found
                        var listwrk = IdPlant.Lookup?.RenderViewRow(rswrk2[0]);
                        IdPlant.EditValue = IdPlant.DisplayValue(listwrk);
                    } else {
                        IdPlant.EditValue = FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
                    }
                }
            } else {
                IdPlant.EditValue = DbNullValue;
            }
            IdPlant.ViewCustomAttributes = "";

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
            TipeProdukSTS.ViewCustomAttributes = "";

            // KodeProduk
            KodeProduk.SetupEditAttributes();
            string curVal4 = ConvertToString(KodeProduk.CurrentValue);
            if (!Empty(curVal4)) {
                if (KodeProduk.Lookup != null && IsDictionary(KodeProduk.Lookup?.Options) && KodeProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    KodeProduk.EditValue = KodeProduk.LookupCacheOption(curVal4);
                } else { // Lookup from database // DN
                    string filterWrk4 = SearchFilter(KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", KodeProduk.CurrentValue, KodeProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                    string? sqlWrk4 = KodeProduk.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk4?.Count > 0 && KodeProduk.Lookup != null) { // Lookup values found
                        var listwrk = KodeProduk.Lookup?.RenderViewRow(rswrk4[0]);
                        KodeProduk.EditValue = KodeProduk.DisplayValue(listwrk);
                    } else {
                        KodeProduk.EditValue = KodeProduk.CurrentValue;
                    }
                }
            } else {
                KodeProduk.EditValue = DbNullValue;
            }
            KodeProduk.ViewCustomAttributes = "";

            // ModaTransportasi
            ModaTransportasi.SetupEditAttributes();
            string curVal5 = ConvertToString(ModaTransportasi.CurrentValue);
            if (!Empty(curVal5)) {
                if (ModaTransportasi.Lookup != null && IsDictionary(ModaTransportasi.Lookup?.Options) && ModaTransportasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ModaTransportasi.EditValue = ModaTransportasi.LookupCacheOption(curVal5);
                } else { // Lookup from database // DN
                    string filterWrk5 = SearchFilter(ModaTransportasi.Lookup?.GetTable()?.Fields["IdModa"].SearchExpression, "=", ModaTransportasi.CurrentValue, ModaTransportasi.Lookup?.GetTable()?.Fields["IdModa"].SearchDataType, "");
                    string? sqlWrk5 = ModaTransportasi.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk5?.Count > 0 && ModaTransportasi.Lookup != null) { // Lookup values found
                        var listwrk = ModaTransportasi.Lookup?.RenderViewRow(rswrk5[0]);
                        ModaTransportasi.EditValue = ModaTransportasi.DisplayValue(listwrk);
                    } else {
                        ModaTransportasi.EditValue = ModaTransportasi.CurrentValue;
                    }
                }
            } else {
                ModaTransportasi.EditValue = DbNullValue;
            }
            ModaTransportasi.ViewCustomAttributes = "";

            // NamaKapal
            NamaKapal.SetupEditAttributes();
            NamaKapal.EditValue = ConvertToString(NamaKapal.CurrentValue); // DN
            NamaKapal.ViewCustomAttributes = "";

            // DetailRTW
            DetailRTW.SetupEditAttributes();
            if (!DetailRTW.Raw)
                DetailRTW.CurrentValue = HtmlDecode(DetailRTW.CurrentValue);
            DetailRTW.EditValue = DetailRTW.CurrentValue;
            DetailRTW.PlaceHolder = RemoveHtml(DetailRTW.Caption);

            // Refinery
            Refinery.SetupEditAttributes();
            if (ConvertToBool(Refinery.CurrentValue)) {
                Refinery.EditValue = Refinery.TagCaption(1) != "" ? Refinery.TagCaption(1) : "Yes";
            } else {
                Refinery.EditValue = Refinery.TagCaption(2) != "" ? Refinery.TagCaption(2) : "No";
            }
            Refinery.ViewCustomAttributes = "";

            // IdPenyaluran
            IdPenyaluran.SetupEditAttributes();
            if (!Empty(IdPenyaluran.CurrentValue)) {
                IdPenyaluran.EditValue = IdPenyaluran.OptionCaption(ConvertToString(IdPenyaluran.CurrentValue));
            } else {
                IdPenyaluran.EditValue = DbNullValue;
            }
            IdPenyaluran.ViewCustomAttributes = "";

            // PenyaluranLookup
            PenyaluranLookup.SetupEditAttributes();
            PenyaluranLookup.EditValue = PenyaluranLookup.CurrentValue;
            string curVal8 = ConvertToString(PenyaluranLookup.CurrentValue);
            if (!Empty(curVal8)) {
                if (PenyaluranLookup.Lookup != null && IsDictionary(PenyaluranLookup.Lookup?.Options) && PenyaluranLookup.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PenyaluranLookup.EditValue = PenyaluranLookup.LookupCacheOption(curVal8);
                } else { // Lookup from database // DN
                    string filterWrk8 = SearchFilter(PenyaluranLookup.Lookup?.GetTable()?.Fields["IdPenyaluran"].SearchExpression, "=", PenyaluranLookup.CurrentValue, PenyaluranLookup.Lookup?.GetTable()?.Fields["IdPenyaluran"].SearchDataType, "");
                    string? sqlWrk8 = PenyaluranLookup.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk8?.Count > 0 && PenyaluranLookup.Lookup != null) { // Lookup values found
                        var listwrk = PenyaluranLookup.Lookup?.RenderViewRow(rswrk8[0]);
                        PenyaluranLookup.EditValue = PenyaluranLookup.DisplayValue(listwrk);
                    } else {
                        PenyaluranLookup.EditValue = FormatNumber(PenyaluranLookup.CurrentValue, PenyaluranLookup.FormatPattern);
                    }
                }
            } else {
                PenyaluranLookup.EditValue = DbNullValue;
            }
            PenyaluranLookup.ViewCustomAttributes = "";

            // TanggalSandar
            TanggalSandar.SetupEditAttributes();
            TanggalSandar.EditValue = TanggalSandar.CurrentValue;
            TanggalSandar.EditValue = FormatDateTime(TanggalSandar.EditValue, TanggalSandar.FormatPattern);
            TanggalSandar.ViewCustomAttributes = "";

            // IdDermaga
            IdDermaga.SetupEditAttributes();
            string curVal9 = ConvertToString(IdDermaga.CurrentValue);
            if (!Empty(curVal9)) {
                if (IdDermaga.Lookup != null && IsDictionary(IdDermaga.Lookup?.Options) && IdDermaga.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdDermaga.EditValue = IdDermaga.LookupCacheOption(curVal9);
                } else { // Lookup from database // DN
                    string filterWrk9 = SearchFilter(IdDermaga.Lookup?.GetTable()?.Fields["IdDermaga"].SearchExpression, "=", IdDermaga.CurrentValue, IdDermaga.Lookup?.GetTable()?.Fields["IdDermaga"].SearchDataType, "");
                    string? sqlWrk9 = IdDermaga.Lookup?.GetSql(false, filterWrk9, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk9 = sqlWrk9 != null ? Connection.GetRows(sqlWrk9) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk9?.Count > 0 && IdDermaga.Lookup != null) { // Lookup values found
                        var listwrk = IdDermaga.Lookup?.RenderViewRow(rswrk9[0]);
                        IdDermaga.EditValue = IdDermaga.DisplayValue(listwrk);
                    } else {
                        IdDermaga.EditValue = FormatNumber(IdDermaga.CurrentValue, IdDermaga.FormatPattern);
                    }
                }
            } else {
                IdDermaga.EditValue = DbNullValue;
            }
            IdDermaga.ViewCustomAttributes = "";

            // StatusProses
            StatusProses.SetupEditAttributes();

            // PersentaseProgress
            PersentaseProgress.SetupEditAttributes();
            PersentaseProgress.CurrentValue = FormatPercent(PersentaseProgress.CurrentValue, PersentaseProgress.FormatPattern);

            // IdTemplate
            IdTemplate.SetupEditAttributes();
            IdTemplate.CurrentValue = FormatNumber(IdTemplate.CurrentValue, IdTemplate.FormatPattern);
            if (!Empty(IdTemplate.EditValue) && IsNumeric(IdTemplate.EditValue))
                IdTemplate.EditValue = FormatNumber(IdTemplate.EditValue, null);

            // Catatan
            Catatan.SetupEditAttributes();
            Catatan.EditValue = Catatan.CurrentValue; // DN
            Catatan.PlaceHolder = RemoveHtml(Catatan.Caption);

            // DibuatOleh

            // TanggalDibuat

            // DiperbaruiOleh

            // TanggalDiperbarui

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
                        doc.ExportCaption(NomorPenerimaan);
                        doc.ExportCaption(Proses2);
                        doc.ExportCaption(NomorVoyage);
                        doc.ExportCaption(NomorPengiriman);
                        doc.ExportCaption(LookupPlant);
                        doc.ExportCaption(IdPlant);
                        doc.ExportCaption(TipeProdukSTS);
                        doc.ExportCaption(KodeProduk);
                        doc.ExportCaption(ModaTransportasi);
                        doc.ExportCaption(NamaKapal);
                        doc.ExportCaption(Refinery);
                        doc.ExportCaption(PenyaluranLookup);
                        doc.ExportCaption(TanggalSandar);
                        doc.ExportCaption(IdDermaga);
                        doc.ExportCaption(StatusProses);
                        doc.ExportCaption(PersentaseProgress);
                        doc.ExportCaption(IdTemplate);
                        doc.ExportCaption(Catatan);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
                    } else {
                        doc.ExportCaption(Proses2);
                        doc.ExportCaption(NomorVoyage);
                        doc.ExportCaption(NomorPengiriman);
                        doc.ExportCaption(IdPlant);
                        doc.ExportCaption(TipeProdukSTS);
                        doc.ExportCaption(KodeProduk);
                        doc.ExportCaption(ModaTransportasi);
                        doc.ExportCaption(NamaKapal);
                        doc.ExportCaption(Refinery);
                        doc.ExportCaption(PenyaluranLookup);
                        doc.ExportCaption(TanggalSandar);
                        doc.ExportCaption(IdDermaga);
                        doc.ExportCaption(StatusProses);
                        doc.ExportCaption(PersentaseProgress);
                        doc.ExportCaption(IdTemplate);
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
                            await doc.ExportField(NomorPenerimaan);
                            await doc.ExportField(Proses2);
                            await doc.ExportField(NomorVoyage);
                            await doc.ExportField(NomorPengiriman);
                            await doc.ExportField(LookupPlant);
                            await doc.ExportField(IdPlant);
                            await doc.ExportField(TipeProdukSTS);
                            await doc.ExportField(KodeProduk);
                            await doc.ExportField(ModaTransportasi);
                            await doc.ExportField(NamaKapal);
                            await doc.ExportField(Refinery);
                            await doc.ExportField(PenyaluranLookup);
                            await doc.ExportField(TanggalSandar);
                            await doc.ExportField(IdDermaga);
                            await doc.ExportField(StatusProses);
                            await doc.ExportField(PersentaseProgress);
                            await doc.ExportField(IdTemplate);
                            await doc.ExportField(Catatan);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
                        } else {
                            await doc.ExportField(Proses2);
                            await doc.ExportField(NomorVoyage);
                            await doc.ExportField(NomorPengiriman);
                            await doc.ExportField(IdPlant);
                            await doc.ExportField(TipeProdukSTS);
                            await doc.ExportField(KodeProduk);
                            await doc.ExportField(ModaTransportasi);
                            await doc.ExportField(NamaKapal);
                            await doc.ExportField(Refinery);
                            await doc.ExportField(PenyaluranLookup);
                            await doc.ExportField(TanggalSandar);
                            await doc.ExportField(IdDermaga);
                            await doc.ExportField(StatusProses);
                            await doc.ExportField(PersentaseProgress);
                            await doc.ExportField(IdTemplate);
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
                    IdPlant IN (
                        SELECT IdPlant FROM MappingPosition WHERE IdRegion IN (
                            SELECT IdRegion FROM MappingPosition WHERE IdPosition = {idPosition}
                        )
                    )
                ";
                AddFilter(ref filter, selectPlntByRegion);
                return;
            }
            AddFilter(ref filter, $"IdPlant IN (SELECT IdPlant FROM MappingPosition WHERE IdPosition = {idPosition})");
        }

        // Recordset Selected event
        public void RecordsetSelected(DbDataReader rs) {
            // Enter your code here
        }

        // Recordset Searching event
        public void RecordsetSearching(ref string filter) {
            string x_TanggalSandar = HttpContext.Request.Query["x_TanggalSandar"];
            string y_TanggalSandar = HttpContext.Request.Query["y_TanggalSandar"];
            string x_TanggalDibuat = HttpContext.Request.Query["x_TanggalDibuat"];
            string y_TanggalDibuat = HttpContext.Request.Query["y_TanggalDibuat"];
            string x_TanggalDiperbarui = HttpContext.Request.Query["x_TanggalDiperbarui"];
            string y_TanggalDiperbarui = HttpContext.Request.Query["y_TanggalDiperbarui"];
            if (!string.IsNullOrEmpty(x_TanggalSandar) && !string.IsNullOrEmpty(y_TanggalSandar))
            {
                string pattern = @"\[TanggalSandar\]\s*=\s*'[^']+'";
                string replacement = $"([TanggalSandar] BETWEEN '{x_TanggalSandar}' AND '{y_TanggalSandar}')";
                filter = Regex.Replace(filter, pattern, replacement);
            }
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
                var idPlant     = rsnew["IdPlant"].ToString();
                var kodeProduk  = rsnew["KodeProduk"].ToString();
                rsnew["DibuatOleh"] = CurrentUserName();

                // Generate nomor referensi
                string sqlNomor = $"EXEC GenerateNomorReferensi {idPlant}, '{kodeProduk}'";
                var nomorReferensiObj = ExecuteScalar(sqlNomor);
                if (nomorReferensiObj == null)
                    throw new Exception("Gagal menghasilkan NomorReferensi.");
                string nomorReferensi = nomorReferensiObj.ToString();
                rsnew["NomorPenerimaan"] = nomorReferensi;

                // Ambil waktu plant via SP GetPlantDateTime (gunakan IdPlant atau NomorPenerimaan)
                DateTime plantTime = DateTime.Now;
                var plantObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @IdPlant = {idPlant}");
                if (plantObj != null && DateTime.TryParse(plantObj.ToString(), out var tmp))
                    plantTime = tmp;

                // Set tanggal dibuat dan diperbarui dengan waktu plant
                rsnew["TanggalDibuat"] = plantTime;
                rsnew["TanggalDiperbarui"] = plantTime;
            } catch (Exception ex) {
                Log("Error in Row_Inserting (GenerateNomorReferensi): " + ex.Message);
                CancelMessage = "Gagal generate Nomor Referensi: " + ex.Message;
                return false;
            }
            return true;
        }

        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            try {
                string nomorReferensi = rsnew["NomorPenerimaan"].ToString();
                // Siapkan parameter lain untuk GenerateProsesAktivitas_ByReferensi
                string jenisProses = "Penerimaan"; // atau "Penyaluran", "Penimbunan"
                int idModa = Convert.ToInt32(rsnew["ModaTransportasi"]);
                int IdPlant = Convert.ToInt32(rsnew["IdPlant"]);
                string dibuatOleh = CurrentUserName();
                int refinery = rsnew.ContainsKey("Refinery")
                               ? Convert.ToInt32(rsnew["Refinery"])
                               : 0;

                // Jalankan SP kedua
                string sql = $"EXEC GenerateProsesAktivitas_Penerimaan '{nomorReferensi}', {IdPlant}, '{jenisProses}', {idModa}, '{dibuatOleh}', {refinery}";
                ExecuteScalar(sql);
            } catch (Exception ex) {
                // Log error
                Log("Error in Row_Inserted (GenerateNomorReferensi & GenerateProsesAktivitas): " + ex.Message);
            }
        }

        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            try {
                // Ambil IdPlant atau NomorPenerimaan dari record
                var idPlant = rsnew.ContainsKey("IdPlant") 
                    ? rsnew["IdPlant"].ToString() 
                    : rsold["IdPlant"].ToString();

                // Panggil GetPlantDateTime untuk mendapatkan waktu plant
                DateTime plantTime = DateTime.Now;
                var plantObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @IdPlant = {idPlant}");
                if (plantObj != null && DateTime.TryParse(plantObj.ToString(), out var tmp))
                    plantTime = tmp;

                // Set kolom pembaruan
                rsnew["DiperbaruiOleh"] = CurrentUserName();
                rsnew["TanggalDiperbarui"] = plantTime;
            } catch (Exception ex) {
                Log("Error in Row_Updating: " + ex.Message);
                CancelMessage = "Gagal memperbarui data: " + ex.Message;
                return false;
            }
            return true;
        }

        public void RowUpdated(Dictionary<string, object> rsold, Dictionary<string, object> rsnew)
        {
            var nomorPenerimaan = rsnew.ContainsKey("NomorPenerimaan")
                        ? rsnew["NomorPenerimaan"].ToString() : rsold["NomorPenerimaan"].ToString();
            var idModa = rsnew.ContainsKey("ModaTransportasi")
                        ? Convert.ToInt32(rsnew["ModaTransportasi"]) : Convert.ToInt32(rsold["ModaTransportasi"]);
            var dibuatOleh = CurrentUserName(); // atau gunakan kolom user aktif sistem kamu
            var plantDateTime = DateTime.Now;
            var newIdPenyaluran = rsnew.ContainsKey("IdPenyaluran") ? Convert.ToInt32(rsnew["IdPenyaluran"]) : 0;
            var oldIdPenyaluran = rsold.ContainsKey("IdPenyaluran") ? Convert.ToInt32(rsold["IdPenyaluran"]) : 0;
            if (newIdPenyaluran != 0 && oldIdPenyaluran == 0)
            {
                // Hanya untuk moda pipa (IdModa = 5)
                if (idModa == 5)
                {
                    try
                    {
                        string sqlCekNominasi = @$"SELECT TOP 1 Nominasi FROM SubAktivitasNilaiEstimasisFlowratePipa WHERE NoReferensi = '{nomorPenerimaan}'";
                        var nominasiData = ExecuteRow(sqlCekNominasi);
                        var nominasiString = nominasiData.ContainsKey("Nominasi") ? nominasiData["Nominasi"] : null;
                        if (nominasiString == null) 
                        {
                            string sqlGetVolumePenyaluranData = @$"SELECT TOP 1 Pny.Volume
                                FROM Penerimaan Pnr
                                JOIN Penyaluran Pny ON Pny.IdPenyaluran = Pnr.IdPenyaluran
                                WHERE Pnr.NomorPenerimaan = '{nomorPenerimaan}'";
                            var volumePenyaluranData = ExecuteRow(sqlGetVolumePenyaluranData);
                            if (volumePenyaluranData != null)
                            {
                                ExecuteScalar(@"UPDATE SubAktivitasNilaiEstimasisFlowratePipa 
                                    SET Nominasi = @Volume WHERE NoReferensi = @NomorPenerimaan",
                                    new Dictionary<string, object> {
                                        {"@Volume", volumePenyaluranData["Volume"]},
                                        {"@NomorPenerimaan", nomorPenerimaan}
                                });
                            }
                        }

                        // 1️⃣ Ambil IdPenyaluran dan NomorPenyaluran
                        string sqlGetPenyaluran = @$"SELECT TOP 1 Pnr.IdPenyaluran, Pny.NomorPenyaluran
                            FROM Penerimaan Pnr
                            JOIN Penyaluran Pny ON Pny.IdPenyaluran = Pnr.IdPenyaluran
                            WHERE Pnr.NomorPenerimaan = '{nomorPenerimaan}'";
                        var penyaluranData = ExecuteRow(sqlGetPenyaluran);
                        if (penyaluranData != null)
                        {
                            var idPenyaluran = Convert.ToInt32(penyaluranData["IdPenyaluran"]);
                            var nomorPenyaluran = penyaluranData["NomorPenyaluran"].ToString();

                            // ===============================
                            // 2️⃣ Cek & Copy Dokumen 211 → 208
                            // ===============================
                            string cekDokumen211 = @$"SELECT TOP 1 IdAktivitasDokumen, StatusUpload 
                                            FROM AktivitasDokumen WHERE IdDokumen = 211 AND NoReferensi = '{nomorPenyaluran}' ";
                            var dok211 = ExecuteRow(cekDokumen211);
                            if (dok211 != null)
                            {
                                // Cek penerimaan (208)
                                string cek208 = @$"SELECT TOP 1 IdAktivitasDokumen FROM AktivitasDokumen 
                                                WHERE NoReferensi = '{nomorPenerimaan}' AND IdDokumen = 208";
                                var penerimaan208 = ExecuteRow(cek208);
                                if (penerimaan208 != null)
                                {
                                    // Cek dokumen detail
                                    string cekDokDetail208 = @$"SELECT TOP 1 id FROM AktivitasDokumenDetail Adds where IdAktivitasDokumen = " + penerimaan208["IdAktivitasDokumen"];
                                    var dokDetail208Data = ExecuteRow(cekDokDetail208);
                                    if (dokDetail208Data == null)
                                    {
                                        // Update status upload
                                        ExecuteScalar(@"UPDATE AktivitasDokumen 
                                                SET StatusUpload = @StatusUpload,
                                                DiunggahOleh = @DiunggahOleh,
                                                TanggalUpload = @TanggalUpload,
                                                DiperbaruiOleh = @DiperbaruiOleh,
                                                TanggalDiperbarui = @TanggalDiperbarui
                                                WHERE NoReferensi = @NomorPenerimaan AND IdDokumen = 208",
                                            new Dictionary<string, object> {
                                                {"@StatusUpload", dok211["StatusUpload"]},
                                                {"@DiunggahOleh", dibuatOleh},
                                                {"@TanggalUpload", plantDateTime},
                                                {"@DiperbaruiOleh", dibuatOleh},
                                                {"@TanggalDiperbarui", plantDateTime},
                                                {"@NomorPenerimaan", nomorPenerimaan}
                                        });

                                        // Copy file detail
                                        ExecuteScalar(@"INSERT INTO AktivitasDokumenDetail (IdAktivitasDokumen, FileName, DiunggahOleh, TanggalDiunggah)
                                                SELECT @IdAktivitasDokumenPenerimaan, FileName, @DibuatOleh, @PlantDateTime
                                                FROM AktivitasDokumenDetail
                                                WHERE IdAktivitasDokumen = @IdAktivitasDokumenPenyaluran",
                                            new Dictionary<string, object> {
                                                {"@IdAktivitasDokumenPenerimaan", penerimaan208["IdAktivitasDokumen"]},
                                                {"@IdAktivitasDokumenPenyaluran", dok211["IdAktivitasDokumen"]},
                                                {"@DibuatOleh", dibuatOleh},
                                                {"@PlantDateTime", plantDateTime}
                                        });
                                    }
                                }
                            }

                            // ===============================
                            // 3️⃣ Cek & Copy Dokumen 212 → 209
                            // ===============================
                            string cekDokumen212 = @$"SELECT TOP 1 IdAktivitasDokumen, StatusUpload 
                                FROM AktivitasDokumen 
                                WHERE NoReferensi = '{nomorPenyaluran}' AND IdDokumen = 212";
                            var dok212 = ExecuteRow(cekDokumen212);
                            if (dok212 != null)
                            {
                                string cek209 = @$"SELECT TOP 1 IdAktivitasDokumen 
                                    FROM AktivitasDokumen 
                                    WHERE NoReferensi = '{nomorPenerimaan}' AND IdDokumen = 209";
                                var penerimaan209 = ExecuteRow(cek209);
                                if (penerimaan209 != null)
                                {
                                    // Cek dokumen detail
                                    string cekDokDetail209 = @$"SELECT TOP 1 id FROM AktivitasDokumenDetail Adds where IdAktivitasDokumen = " + penerimaan209["IdAktivitasDokumen"];
                                    var dokDetail209Data = ExecuteRow(cekDokDetail209);
                                    if (dokDetail209Data == null)
                                    {
                                        ExecuteScalar(@"UPDATE AktivitasDokumen 
                                                SET StatusUpload = @StatusUpload,
                                                DiunggahOleh = @DiunggahOleh,
                                                TanggalUpload = @TanggalUpload,
                                                DiperbaruiOleh = @DiperbaruiOleh,
                                                TanggalDiperbarui = @TanggalDiperbarui
                                                WHERE NoReferensi = @NomorPenerimaan AND IdDokumen = 209",
                                            new Dictionary<string, object> {
                                                {"@StatusUpload", dok211["StatusUpload"]},
                                                {"@DiunggahOleh", dibuatOleh},
                                                {"@TanggalUpload", plantDateTime},
                                                {"@DiperbaruiOleh", dibuatOleh},
                                                {"@TanggalDiperbarui", plantDateTime},
                                                {"@NomorPenerimaan", nomorPenerimaan}
                                        });
                                        ExecuteScalar(@"INSERT INTO AktivitasDokumenDetail (IdAktivitasDokumen, FileName, DiunggahOleh, TanggalDiunggah)
                                                SELECT @IdAktivitasDokumenPenerimaan, FileName, @DibuatOleh, @PlantDateTime
                                                FROM AktivitasDokumenDetail
                                                WHERE IdAktivitasDokumen = @IdAktivitasDokumenPenyaluran",
                                            new Dictionary<string, object> {
                                                {"@IdAktivitasDokumenPenerimaan", penerimaan209["IdAktivitasDokumen"]},
                                                {"@IdAktivitasDokumenPenyaluran", dok212["IdAktivitasDokumen"]},
                                                {"@DibuatOleh", dibuatOleh},
                                                {"@PlantDateTime", plantDateTime}
                                        });
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log("Error Row_Updated (copy dokumen pipa): " + ex.Message);
                    }
                }
            }
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
