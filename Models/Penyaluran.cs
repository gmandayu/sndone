namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// penyaluran
    /// </summary>
    [MaybeNull]
    public static Penyaluran penyaluran
    {
        get => HttpData.Resolve<Penyaluran>("Penyaluran");
        set => HttpData["Penyaluran"] = value;
    }

    /// <summary>
    /// Table class for Penyaluran
    /// </summary>
    public class Penyaluran : DbTable
    {
        public override Dictionary<string, string> KeyFields { get; set; } = new() { // DN
            { "IdPenyaluran", "IdPenyaluran" },
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

        public readonly DbField<SqlDbType> IdPenyaluran;

        public readonly DbField<SqlDbType> NomorPenyaluran;

        public readonly DbField<SqlDbType> LinkProses;

        public readonly DbField<SqlDbType> LookupPlant;

        public readonly DbField<SqlDbType> IdPlant;

        public readonly DbField<SqlDbType> TipePenyaluran;

        public readonly DbField<SqlDbType> TipeProdukSTS;

        public readonly DbField<SqlDbType> KategoriPenyaluran;

        public readonly DbField<SqlDbType> IdModa;

        public readonly DbField<SqlDbType> DetailRTW;

        public readonly DbField<SqlDbType> NoShipment;

        public readonly DbField<SqlDbType> IdPipa;

        public readonly DbField<SqlDbType> NomorPolisi;

        public readonly DbField<SqlDbType> NamaKapal;

        public readonly DbField<SqlDbType> JenisProduk;

        public readonly DbField<SqlDbType> IdPenimbunan;

        public readonly DbField<SqlDbType> StatusProses;

        public readonly DbField<SqlDbType> IdTemplate;

        public readonly DbField<SqlDbType> PersentaseProgress;

        public readonly DbField<SqlDbType> Tujuan;

        public readonly DbField<SqlDbType> TujuanKonsinyasi;

        public readonly DbField<SqlDbType> Volume;

        public readonly DbField<SqlDbType> TujuanKonsinyasiPipa;

        public readonly DbField<SqlDbType> QuantityKonsinyasiPipa;

        public readonly DbField<SqlDbType> TujuanKonsinyasi2;

        public readonly DbField<SqlDbType> Volume2;

        public readonly DbField<SqlDbType> TujuanKonsinyasi3;

        public readonly DbField<SqlDbType> Volume3;

        public readonly DbField<SqlDbType> TanggalSandar;

        public readonly DbField<SqlDbType> Catatan;

        public readonly DbField<SqlDbType> DibuatOleh;

        public readonly DbField<SqlDbType> TanggalDibuat;

        public readonly DbField<SqlDbType> DiperbaruiOleh;

        public readonly DbField<SqlDbType> TanggalDiperbarui;

        public readonly DbField<SqlDbType> LookupTipeProduk;

        public readonly DbField<SqlDbType> LookupJenisPlant;

        public readonly DbField<SqlDbType> MultipleTujuanKonsinyasi;

        public readonly DbField<SqlDbType> MultipleTujuanKonsinyasiHidden;

        public readonly DbField<SqlDbType> MultipleQuantity;

        // Constructor
        public Penyaluran()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "Penyaluran";
            Name = "Penyaluran";
            Type = "TABLE";
            UpdateTable = "dbo.Penyaluran"; // Update Table
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
                HtmlTag = "HIDDEN",
                InputTextType = "text",
                IsAutoIncrement = true, // Autoincrement field
                IsPrimaryKey = true, // Primary key field
                Nullable = false, // NOT NULL field
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "IdPenyaluran", "CustomMsg"),
                IsUpload = false
            };
            IdPenyaluran.Raw = true;
            Fields.Add("IdPenyaluran", IdPenyaluran);

            // NomorPenyaluran
            NomorPenyaluran = new(this, "x_NomorPenyaluran", 200, SqlDbType.VarChar) {
                Name = "NomorPenyaluran",
                Expression = "[NomorPenyaluran]",
                BasicSearchExpression = "[NomorPenyaluran]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomorPenyaluran]",
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
                CustomMessage = Language.FieldPhrase("Penyaluran", "NomorPenyaluran", "CustomMsg"),
                IsUpload = false
            };
            NomorPenyaluran.Lookup = new Lookup<DbField>(NomorPenyaluran, "Penyaluran", true, "NomorPenyaluran", new List<string> {"NomorPenyaluran", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NomorPenyaluran", NomorPenyaluran);

            // LinkProses
            LinkProses = new(this, "x_LinkProses", 202, SqlDbType.NVarChar) {
                Name = "LinkProses",
                Expression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenyaluran AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenyaluran AS NVARCHAR(50))+'</a>'",
                UseBasicSearch = true,
                BasicSearchExpression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenyaluran AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenyaluran AS NVARCHAR(50))+'</a>'",
                DateTimeFormat = -1,
                VirtualExpression = "'<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenyaluran AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenyaluran AS NVARCHAR(50))+'</a>'",
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
                CustomMessage = Language.FieldPhrase("Penyaluran", "LinkProses", "CustomMsg"),
                IsUpload = false
            };
            LinkProses.Lookup = new Lookup<DbField>(LinkProses, "Penyaluran", true, "LinkProses", new List<string> {"LinkProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LinkProses", LinkProses);

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
                CustomMessage = Language.FieldPhrase("Penyaluran", "LookupPlant", "CustomMsg"),
                IsUpload = false
            };
            LookupPlant.Raw = true;
            LookupPlant.Lookup = new Lookup<DbField>(LookupPlant, "Penyaluran", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "IdPlant", "CustomMsg"),
                IsUpload = false
            };
            IdPlant.Raw = true;
            IdPlant.Lookup = new Lookup<DbField>(IdPlant, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {"x_IdPipa"}, new List<string> {}, new List<string> {}, new List<string> {"TipeProduk", "JenisPlant"}, new List<string> {"x_LookupTipeProduk", "x_LookupJenisPlant"}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, IdPlant) + "',[Nama_Terminal])");
            Fields.Add("IdPlant", IdPlant);

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
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                OptionCount = 2,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "TipePenyaluran", "CustomMsg"),
                IsUpload = false
            };
            TipePenyaluran.Lookup = new Lookup<DbField>(TipePenyaluran, "Penyaluran", true, "TipePenyaluran", new List<string> {"TipePenyaluran", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TipePenyaluran", TipePenyaluran);

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
                CustomMessage = Language.FieldPhrase("Penyaluran", "TipeProdukSTS", "CustomMsg"),
                IsUpload = false
            };
            TipeProdukSTS.Lookup = new Lookup<DbField>(TipeProdukSTS, "MasterProduk", true, "TipeProduk", new List<string> {"TipeProduk", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {"TipeProduk"}, new List<string> {"x_LookupTipeProduk"}, false, "", "", "[TipeProduk]");
            Fields.Add("TipeProdukSTS", TipeProdukSTS);

            // KategoriPenyaluran
            KategoriPenyaluran = new(this, "x_KategoriPenyaluran", 202, SqlDbType.NVarChar) {
                Name = "KategoriPenyaluran",
                Expression = "[KategoriPenyaluran]",
                UseBasicSearch = true,
                BasicSearchExpression = "[KategoriPenyaluran]",
                DateTimeFormat = -1,
                VirtualExpression = "[KategoriPenyaluran]",
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
                OptionCount = 2,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "KategoriPenyaluran", "CustomMsg"),
                IsUpload = false
            };
            KategoriPenyaluran.Lookup = new Lookup<DbField>(KategoriPenyaluran, "Penyaluran", true, "KategoriPenyaluran", new List<string> {"KategoriPenyaluran", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("KategoriPenyaluran", KategoriPenyaluran);

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
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "IdModa", "CustomMsg"),
                IsUpload = false
            };
            IdModa.Raw = true;
            IdModa.Lookup = new Lookup<DbField>(IdModa, "MasterModa", true, "IdModa", new List<string> {"NamaModa", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "[Kategori] DESC", "", "[NamaModa]");
            Fields.Add("IdModa", IdModa);

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
                CustomMessage = Language.FieldPhrase("Penyaluran", "DetailRTW", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("DetailRTW", DetailRTW);

            // NoShipment
            NoShipment = new(this, "x_NoShipment", 202, SqlDbType.NVarChar) {
                Name = "NoShipment",
                Expression = "[NoShipment]",
                BasicSearchExpression = "[NoShipment]",
                DateTimeFormat = -1,
                VirtualExpression = "[NoShipment]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "NoShipment", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NoShipment", NoShipment);

            // IdPipa
            IdPipa = new(this, "x_IdPipa", 3, SqlDbType.Int) {
                Name = "IdPipa",
                Expression = "[IdPipa]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([IdPipa] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdPipa]",
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
                CustomMessage = Language.FieldPhrase("Penyaluran", "IdPipa", "CustomMsg"),
                IsUpload = false
            };
            IdPipa.Raw = true;
            IdPipa.Lookup = new Lookup<DbField>(IdPipa, "MasterPipa", true, "id", new List<string> {"KeteranganPipa", "PlantAsal", "NamaPlantAsal", ""}, "", "", new List<string> {"x_IdPlant"}, new List<string> {}, new List<string> {"idPlantAsal"}, new List<string> {"x_idPlantAsal"}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([KeteranganPipa],'" + ValueSeparator(1, IdPipa) + "',[PlantAsal],'" + ValueSeparator(2, IdPipa) + "',[NamaPlantAsal])");
            Fields.Add("IdPipa", IdPipa);

            // NomorPolisi
            NomorPolisi = new(this, "x_NomorPolisi", 202, SqlDbType.NVarChar) {
                Name = "NomorPolisi",
                Expression = "[NomorPolisi]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NomorPolisi]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomorPolisi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "NomorPolisi", "CustomMsg"),
                IsUpload = false
            };
            NomorPolisi.Lookup = new Lookup<DbField>(NomorPolisi, "Penyaluran", true, "NomorPolisi", new List<string> {"NomorPolisi", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NomorPolisi", NomorPolisi);

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
                CustomMessage = Language.FieldPhrase("Penyaluran", "NamaKapal", "CustomMsg"),
                IsUpload = false
            };
            NamaKapal.Lookup = new Lookup<DbField>(NamaKapal, "Penyaluran", true, "NamaKapal", new List<string> {"NamaKapal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NamaKapal", NamaKapal);

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
                CustomMessage = Language.FieldPhrase("Penyaluran", "JenisProduk", "CustomMsg"),
                IsUpload = false
            };
            JenisProduk.Lookup = new Lookup<DbField>(JenisProduk, "MasterProduk", true, "NoProduk", new List<string> {"NoProduk", "NamaProduk", "", ""}, "", "", new List<string> {"x_LookupTipeProduk"}, new List<string> {}, new List<string> {"TipeProduk"}, new List<string> {"x_TipeProduk"}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([NoProduk],'" + ValueSeparator(1, JenisProduk) + "',[NamaProduk])");
            Fields.Add("JenisProduk", JenisProduk);

            // IdPenimbunan
            IdPenimbunan = new(this, "x_IdPenimbunan", 3, SqlDbType.Int) {
                Name = "IdPenimbunan",
                Expression = "[IdPenimbunan]",
                BasicSearchExpression = "CAST([IdPenimbunan] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdPenimbunan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "IdPenimbunan", "CustomMsg"),
                IsUpload = false
            };
            IdPenimbunan.Raw = true;
            IdPenimbunan.Lookup = new Lookup<DbField>(IdPenimbunan, "Penimbunan", true, "IdPenimbunan", new List<string> {"NomorPenimbunan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NomorPenimbunan]");
            Fields.Add("IdPenimbunan", IdPenimbunan);

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
                CustomMessage = Language.FieldPhrase("Penyaluran", "StatusProses", "CustomMsg"),
                IsUpload = false
            };
            StatusProses.Lookup = new Lookup<DbField>(StatusProses, "Penyaluran", true, "StatusProses", new List<string> {"StatusProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            StatusProses.GetDefault = () => "Waiting";
            Fields.Add("StatusProses", StatusProses);

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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "IdTemplate", "CustomMsg"),
                IsUpload = false
            };
            IdTemplate.Raw = true;
            IdTemplate.Lookup = new Lookup<DbField>(IdTemplate, "MasterTemplate", true, "IdTemplate", new List<string> {"NamaTemplate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaTemplate]");
            IdTemplate.GetDefault = () => 8;
            Fields.Add("IdTemplate", IdTemplate);

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
                CustomMessage = Language.FieldPhrase("Penyaluran", "PersentaseProgress", "CustomMsg"),
                IsUpload = false
            };
            PersentaseProgress.Raw = true;
            PersentaseProgress.Lookup = new Lookup<DbField>(PersentaseProgress, "Penyaluran", true, "PersentaseProgress", new List<string> {"PersentaseProgress", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            PersentaseProgress.GetDefault = () => 0;
            Fields.Add("PersentaseProgress", PersentaseProgress);

            // Tujuan
            Tujuan = new(this, "x_Tujuan", 200, SqlDbType.VarChar) {
                Name = "Tujuan",
                Expression = "[Tujuan]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Tujuan]",
                DateTimeFormat = -1,
                VirtualExpression = "[Tujuan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "Tujuan", "CustomMsg"),
                IsUpload = false
            };
            Tujuan.Lookup = new Lookup<DbField>(Tujuan, "Penyaluran", true, "Tujuan", new List<string> {"Tujuan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Tujuan", Tujuan);

            // TujuanKonsinyasi
            TujuanKonsinyasi = new(this, "x_TujuanKonsinyasi", 3, SqlDbType.Int) {
                Name = "TujuanKonsinyasi",
                Expression = "[TujuanKonsinyasi]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([TujuanKonsinyasi] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[TujuanKonsinyasi]",
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
                CustomMessage = Language.FieldPhrase("Penyaluran", "TujuanKonsinyasi", "CustomMsg"),
                IsUpload = false
            };
            TujuanKonsinyasi.Raw = true;
            TujuanKonsinyasi.Lookup = new Lookup<DbField>(TujuanKonsinyasi, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, TujuanKonsinyasi) + "',[Nama_Terminal])");
            Fields.Add("TujuanKonsinyasi", TujuanKonsinyasi);

            // Volume
            Volume = new(this, "x_Volume", 131, SqlDbType.Decimal) {
                Name = "Volume",
                Expression = "[Volume]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([Volume] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Volume]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "Volume", "CustomMsg"),
                IsUpload = false
            };
            Volume.Raw = true;
            Volume.Lookup = new Lookup<DbField>(Volume, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, Volume) + "',[Nama_Terminal])");
            Fields.Add("Volume", Volume);

            // TujuanKonsinyasiPipa
            TujuanKonsinyasiPipa = new(this, "x_TujuanKonsinyasiPipa", 200, SqlDbType.VarChar) {
                Name = "TujuanKonsinyasiPipa",
                Expression = "NomorPenyaluran",
                UseBasicSearch = true,
                BasicSearchExpression = "NomorPenyaluran",
                DateTimeFormat = -1,
                VirtualExpression = "NomorPenyaluran",
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
                CustomMessage = Language.FieldPhrase("Penyaluran", "TujuanKonsinyasiPipa", "CustomMsg"),
                IsUpload = false
            };
            TujuanKonsinyasiPipa.Lookup = new Lookup<DbField>(TujuanKonsinyasiPipa, "Penyaluran", true, "TujuanKonsinyasiPipa", new List<string> {"TujuanKonsinyasiPipa", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TujuanKonsinyasiPipa", TujuanKonsinyasiPipa);

            // QuantityKonsinyasiPipa
            QuantityKonsinyasiPipa = new(this, "x_QuantityKonsinyasiPipa", 200, SqlDbType.VarChar) {
                Name = "QuantityKonsinyasiPipa",
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
                CustomMessage = Language.FieldPhrase("Penyaluran", "QuantityKonsinyasiPipa", "CustomMsg"),
                IsUpload = false
            };
            QuantityKonsinyasiPipa.Lookup = new Lookup<DbField>(QuantityKonsinyasiPipa, "Penyaluran", true, "QuantityKonsinyasiPipa", new List<string> {"QuantityKonsinyasiPipa", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("QuantityKonsinyasiPipa", QuantityKonsinyasiPipa);

            // TujuanKonsinyasi2
            TujuanKonsinyasi2 = new(this, "x_TujuanKonsinyasi2", 3, SqlDbType.Int) {
                Name = "TujuanKonsinyasi2",
                Expression = "[TujuanKonsinyasi2]",
                BasicSearchExpression = "CAST([TujuanKonsinyasi2] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[TujuanKonsinyasi2]",
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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "TujuanKonsinyasi2", "CustomMsg"),
                IsUpload = false
            };
            TujuanKonsinyasi2.Raw = true;
            TujuanKonsinyasi2.Lookup = new Lookup<DbField>(TujuanKonsinyasi2, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, TujuanKonsinyasi2) + "',[Nama_Terminal])");
            Fields.Add("TujuanKonsinyasi2", TujuanKonsinyasi2);

            // Volume2
            Volume2 = new(this, "x_Volume2", 131, SqlDbType.Decimal) {
                Name = "Volume2",
                Expression = "[Volume2]",
                BasicSearchExpression = "CAST([Volume2] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Volume2]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "Volume2", "CustomMsg"),
                IsUpload = false
            };
            Volume2.Raw = true;
            Volume2.Lookup = new Lookup<DbField>(Volume2, "Penyaluran", true, "Volume2", new List<string> {"Volume2", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Volume2", Volume2);

            // TujuanKonsinyasi3
            TujuanKonsinyasi3 = new(this, "x_TujuanKonsinyasi3", 3, SqlDbType.Int) {
                Name = "TujuanKonsinyasi3",
                Expression = "[TujuanKonsinyasi3]",
                BasicSearchExpression = "CAST([TujuanKonsinyasi3] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[TujuanKonsinyasi3]",
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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "TujuanKonsinyasi3", "CustomMsg"),
                IsUpload = false
            };
            TujuanKonsinyasi3.Raw = true;
            TujuanKonsinyasi3.Lookup = new Lookup<DbField>(TujuanKonsinyasi3, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, TujuanKonsinyasi3) + "',[Nama_Terminal])");
            Fields.Add("TujuanKonsinyasi3", TujuanKonsinyasi3);

            // Volume3
            Volume3 = new(this, "x_Volume3", 131, SqlDbType.Decimal) {
                Name = "Volume3",
                Expression = "[Volume3]",
                BasicSearchExpression = "CAST([Volume3] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Volume3]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "Volume3", "CustomMsg"),
                IsUpload = false
            };
            Volume3.Raw = true;
            Volume3.Lookup = new Lookup<DbField>(Volume3, "Penyaluran", true, "Volume3", new List<string> {"Volume3", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Volume3", Volume3);

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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "TanggalSandar", "CustomMsg"),
                IsUpload = false
            };
            TanggalSandar.Raw = true;
            TanggalSandar.Lookup = new Lookup<DbField>(TanggalSandar, "Penyaluran", true, "TanggalSandar", new List<string> {"TanggalSandar", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalSandar", TanggalSandar);

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
                CustomMessage = Language.FieldPhrase("Penyaluran", "Catatan", "CustomMsg"),
                IsUpload = false
            };
            Catatan.Lookup = new Lookup<DbField>(Catatan, "Penyaluran", true, "Catatan", new List<string> {"Catatan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "DibuatOleh", "CustomMsg"),
                IsUpload = false
            };
            DibuatOleh.Lookup = new Lookup<DbField>(DibuatOleh, "Penyaluran", true, "DibuatOleh", new List<string> {"DibuatOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "TanggalDibuat", "CustomMsg"),
                IsUpload = false
            };
            TanggalDibuat.Raw = true;
            TanggalDibuat.Lookup = new Lookup<DbField>(TanggalDibuat, "Penyaluran", true, "TanggalDibuat", new List<string> {"TanggalDibuat", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "DiperbaruiOleh", "CustomMsg"),
                IsUpload = false
            };
            DiperbaruiOleh.Lookup = new Lookup<DbField>(DiperbaruiOleh, "Penyaluran", true, "DiperbaruiOleh", new List<string> {"DiperbaruiOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "TanggalDiperbarui", "CustomMsg"),
                IsUpload = false
            };
            TanggalDiperbarui.Raw = true;
            TanggalDiperbarui.Lookup = new Lookup<DbField>(TanggalDiperbarui, "Penyaluran", true, "TanggalDiperbarui", new List<string> {"TanggalDiperbarui", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("Penyaluran", "LookupTipeProduk", "CustomMsg"),
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
                CustomMessage = Language.FieldPhrase("Penyaluran", "LookupJenisPlant", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("LookupJenisPlant", LookupJenisPlant);

            // MultipleTujuanKonsinyasi
            MultipleTujuanKonsinyasi = new(this, "x_MultipleTujuanKonsinyasi", 200, SqlDbType.VarChar) {
                Name = "MultipleTujuanKonsinyasi",
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
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 1,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "MultipleTujuanKonsinyasi", "CustomMsg"),
                IsUpload = false
            };
            MultipleTujuanKonsinyasi.Lookup = new Lookup<DbField>(MultipleTujuanKonsinyasi, "Penyaluran", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("MultipleTujuanKonsinyasi", MultipleTujuanKonsinyasi);

            // MultipleTujuanKonsinyasiHidden
            MultipleTujuanKonsinyasiHidden = new(this, "x_MultipleTujuanKonsinyasiHidden", 200, SqlDbType.VarChar) {
                Name = "MultipleTujuanKonsinyasiHidden",
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
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "MultipleTujuanKonsinyasiHidden", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MultipleTujuanKonsinyasiHidden", MultipleTujuanKonsinyasiHidden);

            // MultipleQuantity
            MultipleQuantity = new(this, "x_MultipleQuantity", 200, SqlDbType.VarChar) {
                Name = "MultipleQuantity",
                Expression = "''",
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
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Penyaluran", "MultipleQuantity", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MultipleQuantity", MultipleQuantity);

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
            get => _sqlFrom ?? "dbo.Penyaluran";
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
                string select = "*, '<a href=ProsesList?cmd=search&x_IdReferensi%5B%5D='+ CAST(NomorPenyaluran AS NVARCHAR(50)) +'&search=&searchtype=>'+ CAST(NomorPenyaluran AS NVARCHAR(50))+'</a>' AS [LinkProses], NomorPenyaluran AS [TujuanKonsinyasiPipa], '' AS [QuantityKonsinyasiPipa], '' AS [LookupTipeProduk], '' AS [LookupJenisPlant], '' AS [MultipleTujuanKonsinyasi], '' AS [MultipleTujuanKonsinyasiHidden], '' AS [MultipleQuantity]";
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
                attr.Name == "IdPenyaluran");
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
                attr.Name == "IdPenyaluran");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Penyaluran type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                if (row.ContainsKey("IdPenyaluran"))
                    row["IdPenyaluran"] = lastInsertedId;
                else
                    row.Add("IdPenyaluran", lastInsertedId);
                IdPenyaluran.SetDbValue(lastInsertedId);
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Penyaluran type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Penyaluran type", "data");
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
                IdPenyaluran.DbValue = row["IdPenyaluran"]; // Set DB value only
                NomorPenyaluran.DbValue = row["NomorPenyaluran"]; // Set DB value only
                LinkProses.DbValue = row["LinkProses"]; // Set DB value only
                LookupPlant.DbValue = row["LookupPlant"]; // Set DB value only
                IdPlant.DbValue = row["IdPlant"]; // Set DB value only
                TipePenyaluran.DbValue = row["TipePenyaluran"]; // Set DB value only
                TipeProdukSTS.DbValue = row["TipeProdukSTS"]; // Set DB value only
                KategoriPenyaluran.DbValue = row["KategoriPenyaluran"]; // Set DB value only
                IdModa.DbValue = row["IdModa"]; // Set DB value only
                DetailRTW.DbValue = row["DetailRTW"]; // Set DB value only
                NoShipment.DbValue = row["NoShipment"]; // Set DB value only
                IdPipa.DbValue = row["IdPipa"]; // Set DB value only
                NomorPolisi.DbValue = row["NomorPolisi"]; // Set DB value only
                NamaKapal.DbValue = row["NamaKapal"]; // Set DB value only
                JenisProduk.DbValue = row["JenisProduk"]; // Set DB value only
                IdPenimbunan.DbValue = row["IdPenimbunan"]; // Set DB value only
                StatusProses.DbValue = row["StatusProses"]; // Set DB value only
                IdTemplate.DbValue = row["IdTemplate"]; // Set DB value only
                PersentaseProgress.DbValue = row["PersentaseProgress"]; // Set DB value only
                Tujuan.DbValue = row["Tujuan"]; // Set DB value only
                TujuanKonsinyasi.DbValue = row["TujuanKonsinyasi"]; // Set DB value only
                Volume.DbValue = row["Volume"]; // Set DB value only
                TujuanKonsinyasiPipa.DbValue = row["TujuanKonsinyasiPipa"]; // Set DB value only
                QuantityKonsinyasiPipa.DbValue = row["QuantityKonsinyasiPipa"]; // Set DB value only
                TujuanKonsinyasi2.DbValue = row["TujuanKonsinyasi2"]; // Set DB value only
                Volume2.DbValue = row["Volume2"]; // Set DB value only
                TujuanKonsinyasi3.DbValue = row["TujuanKonsinyasi3"]; // Set DB value only
                Volume3.DbValue = row["Volume3"]; // Set DB value only
                TanggalSandar.DbValue = row["TanggalSandar"]; // Set DB value only
                Catatan.DbValue = row["Catatan"]; // Set DB value only
                DibuatOleh.DbValue = row["DibuatOleh"]; // Set DB value only
                TanggalDibuat.DbValue = row["TanggalDibuat"]; // Set DB value only
                DiperbaruiOleh.DbValue = row["DiperbaruiOleh"]; // Set DB value only
                TanggalDiperbarui.DbValue = row["TanggalDiperbarui"]; // Set DB value only
                LookupTipeProduk.DbValue = row["LookupTipeProduk"]; // Set DB value only
                LookupJenisPlant.DbValue = row["LookupJenisPlant"]; // Set DB value only
                MultipleTujuanKonsinyasi.DbValue = row["MultipleTujuanKonsinyasi"]; // Set DB value only
                MultipleTujuanKonsinyasiHidden.DbValue = row["MultipleTujuanKonsinyasiHidden"]; // Set DB value only
                MultipleQuantity.DbValue = row["MultipleQuantity"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[IdPenyaluran] = @IdPenyaluran@";

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
                    return "PenyaluranList";
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
                "PenyaluranView" => Language.Phrase("View"),
                "PenyaluranEdit" => Language.Phrase("Edit"),
                "PenyaluranAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "PenyaluranList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "PenyaluranView",
                Config.ApiAddAction => "PenyaluranAdd",
                Config.ApiEditAction => "PenyaluranEdit",
                Config.ApiDeleteAction => "PenyaluranDelete",
                Config.ApiListAction => "PenyaluranList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "PenyaluranView",
                Config.ApiAddAction => "PenyaluranAdd",
                Config.ApiEditAction => "PenyaluranEdit",
                Config.ApiDeleteAction => "PenyaluranDelete",
                Config.ApiListAction => "PenyaluranList",
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
        public string ListUrl => "PenyaluranList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("PenyaluranView", parm);
            else
                url = KeyUrl("PenyaluranView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "PenyaluranAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "PenyaluranAdd?" + parm;
            else
                url = "PenyaluranAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("PenyaluranEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("PenyaluranList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("PenyaluranAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("PenyaluranList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("PenyaluranDelete", parm)); // DN
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
            json += "\"IdPenyaluran\":" + ConvertToJson(IdPenyaluran.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL // DN
        public string KeyUrl(string url, string parm = "")
        {
            if (!IsNull(IdPenyaluran.CurrentValue)) {
                url += "/" + IdPenyaluran.CurrentValue;
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
                if (RouteValues.TryGetValue("IdPenyaluran", out object? v0)) { // IdPenyaluran // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("IdPenyaluran");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (KeyFields.Count > 1 && (!IsArray(keys) || keys.Length != KeyFields.Count))
                    continue;
                if (!IsNumeric(keys)) // IdPenyaluran
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
                    IdPenyaluran.CurrentValue = keys;
                else
                    IdPenyaluran.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        // Load row values from recordset
        public void LoadListRowValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
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
            PersentaseProgress.SetDbValue(row["PersentaseProgress"]);
            Tujuan.SetDbValue(row["Tujuan"]);
            TujuanKonsinyasi.SetDbValue(row["TujuanKonsinyasi"]);
            Volume.SetDbValue(row["Volume"]);
            TujuanKonsinyasiPipa.SetDbValue(row["TujuanKonsinyasiPipa"]);
            QuantityKonsinyasiPipa.SetDbValue(row["QuantityKonsinyasiPipa"]);
            TujuanKonsinyasi2.SetDbValue(row["TujuanKonsinyasi2"]);
            Volume2.SetDbValue(row["Volume2"]);
            TujuanKonsinyasi3.SetDbValue(row["TujuanKonsinyasi3"]);
            Volume3.SetDbValue(row["Volume3"]);
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

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "PenyaluranList";
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

            // IdPenyaluran
            IdPenyaluran.ViewValue = IdPenyaluran.CurrentValue;
            IdPenyaluran.ViewCustomAttributes = "";

            // NomorPenyaluran
            NomorPenyaluran.ViewValue = ConvertToString(NomorPenyaluran.CurrentValue); // DN
            NomorPenyaluran.ViewCustomAttributes = "";

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
            string curVal2 = ConvertToString(IdPlant.CurrentValue);
            IdPlant.ViewValue = Empty(curVal2) ? DbNullValue : FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
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
                    }
                }
            }

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

            // DetailRTW
            DetailRTW.ViewValue = ConvertToString(DetailRTW.CurrentValue); // DN
            DetailRTW.ViewCustomAttributes = "";

            // NoShipment
            NoShipment.ViewValue = ConvertToString(NoShipment.CurrentValue); // DN
            NoShipment.ViewCustomAttributes = "";

            // IdPipa

            // awallookupbung
            string curVal7 = ConvertToString(IdPipa.CurrentValue);
            IdPipa.ViewValue = Empty(curVal7) ? DbNullValue : FormatNumber(IdPipa.CurrentValue, IdPipa.FormatPattern);
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
                    }
                }
            }

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
            string curVal8 = ConvertToString(JenisProduk.CurrentValue);
            JenisProduk.ViewValue = Empty(curVal8) ? DbNullValue : JenisProduk.CurrentValue;
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
                    }
                }
            }

            // akhirlookupbung
            JenisProduk.ViewCustomAttributes = "";

            // IdPenimbunan
            IdPenimbunan.ViewValue = IdPenimbunan.CurrentValue;

            // awallookupbung
            string curVal9 = ConvertToString(IdPenimbunan.CurrentValue);
            IdPenimbunan.ViewValue = Empty(curVal9) ? DbNullValue : FormatNumber(IdPenimbunan.CurrentValue, IdPenimbunan.FormatPattern);
            if (!Empty(curVal9)) {
                if (IdPenimbunan.Lookup != null && IsDictionary(IdPenimbunan.Lookup?.Options) && IdPenimbunan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPenimbunan.ViewValue = IdPenimbunan.LookupCacheOption(curVal9);
                } else { // Lookup from database // DN
                    string filterWrk9 = SearchFilter(IdPenimbunan.Lookup?.GetTable()?.Fields["IdPenimbunan"].SearchExpression, "=", IdPenimbunan.CurrentValue, IdPenimbunan.Lookup?.GetTable()?.Fields["IdPenimbunan"].SearchDataType, "");
                    string? sqlWrk9 = IdPenimbunan.Lookup?.GetSql(false, filterWrk9, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk9 = sqlWrk9 != null ? Connection.GetRows(sqlWrk9) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk9?.Count > 0 && IdPenimbunan.Lookup != null) { // Lookup values found
                        var listwrk = IdPenimbunan.Lookup?.RenderViewRow(rswrk9[0]);
                        IdPenimbunan.ViewValue = IdPenimbunan.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            IdPenimbunan.ViewCustomAttributes = "";

            // StatusProses
            StatusProses.ViewValue = StatusProses.CurrentValue;
            StatusProses.ViewCustomAttributes = "";

            // IdTemplate
            IdTemplate.ViewValue = IdTemplate.CurrentValue;
            IdTemplate.ViewValue = FormatNumber(IdTemplate.ViewValue, IdTemplate.FormatPattern);
            IdTemplate.ViewCustomAttributes = "";

            // PersentaseProgress
            PersentaseProgress.ViewValue = PersentaseProgress.CurrentValue;
            PersentaseProgress.ViewValue = FormatPercent(PersentaseProgress.ViewValue, PersentaseProgress.FormatPattern);
            PersentaseProgress.ViewCustomAttributes = "";

            // Tujuan
            Tujuan.ViewValue = ConvertToString(Tujuan.CurrentValue); // DN
            Tujuan.ViewCustomAttributes = "";

            // TujuanKonsinyasi

            // awallookupbung
            string curVal10 = ConvertToString(TujuanKonsinyasi.CurrentValue);
            TujuanKonsinyasi.ViewValue = Empty(curVal10) ? DbNullValue : FormatNumber(TujuanKonsinyasi.CurrentValue, TujuanKonsinyasi.FormatPattern);
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
                    }
                }
            }

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

            // TujuanKonsinyasi2

            // awallookupbung
            string curVal11 = ConvertToString(TujuanKonsinyasi2.CurrentValue);
            TujuanKonsinyasi2.ViewValue = Empty(curVal11) ? DbNullValue : FormatNumber(TujuanKonsinyasi2.CurrentValue, TujuanKonsinyasi2.FormatPattern);
            if (!Empty(curVal11)) {
                if (TujuanKonsinyasi2.Lookup != null && IsDictionary(TujuanKonsinyasi2.Lookup?.Options) && TujuanKonsinyasi2.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TujuanKonsinyasi2.ViewValue = TujuanKonsinyasi2.LookupCacheOption(curVal11);
                } else { // Lookup from database // DN
                    string filterWrk11 = SearchFilter(TujuanKonsinyasi2.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", TujuanKonsinyasi2.CurrentValue, TujuanKonsinyasi2.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk11 = TujuanKonsinyasi2.Lookup?.GetSql(false, filterWrk11, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk11 = sqlWrk11 != null ? Connection.GetRows(sqlWrk11) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk11?.Count > 0 && TujuanKonsinyasi2.Lookup != null) { // Lookup values found
                        var listwrk = TujuanKonsinyasi2.Lookup?.RenderViewRow(rswrk11[0]);
                        TujuanKonsinyasi2.ViewValue = TujuanKonsinyasi2.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            TujuanKonsinyasi2.ViewCustomAttributes = "";

            // Volume2
            Volume2.ViewValue = Volume2.CurrentValue;
            Volume2.ViewValue = FormatNumber(Volume2.ViewValue, Volume2.FormatPattern);
            Volume2.ViewCustomAttributes = "";

            // TujuanKonsinyasi3

            // awallookupbung
            string curVal12 = ConvertToString(TujuanKonsinyasi3.CurrentValue);
            TujuanKonsinyasi3.ViewValue = Empty(curVal12) ? DbNullValue : FormatNumber(TujuanKonsinyasi3.CurrentValue, TujuanKonsinyasi3.FormatPattern);
            if (!Empty(curVal12)) {
                if (TujuanKonsinyasi3.Lookup != null && IsDictionary(TujuanKonsinyasi3.Lookup?.Options) && TujuanKonsinyasi3.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TujuanKonsinyasi3.ViewValue = TujuanKonsinyasi3.LookupCacheOption(curVal12);
                } else { // Lookup from database // DN
                    string filterWrk12 = SearchFilter(TujuanKonsinyasi3.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", TujuanKonsinyasi3.CurrentValue, TujuanKonsinyasi3.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk12 = TujuanKonsinyasi3.Lookup?.GetSql(false, filterWrk12, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk12 = sqlWrk12 != null ? Connection.GetRows(sqlWrk12) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk12?.Count > 0 && TujuanKonsinyasi3.Lookup != null) { // Lookup values found
                        var listwrk = TujuanKonsinyasi3.Lookup?.RenderViewRow(rswrk12[0]);
                        TujuanKonsinyasi3.ViewValue = TujuanKonsinyasi3.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            TujuanKonsinyasi3.ViewCustomAttributes = "";

            // Volume3
            Volume3.ViewValue = Volume3.CurrentValue;
            Volume3.ViewValue = FormatNumber(Volume3.ViewValue, Volume3.FormatPattern);
            Volume3.ViewCustomAttributes = "";

            // TanggalSandar
            TanggalSandar.ViewValue = TanggalSandar.CurrentValue;
            TanggalSandar.ViewValue = FormatDateTime(TanggalSandar.ViewValue, TanggalSandar.FormatPattern);
            TanggalSandar.ViewCustomAttributes = "";

            // Catatan
            Catatan.ViewValue = Catatan.CurrentValue;
            Catatan.ViewCustomAttributes = "";

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

            // LookupTipeProduk
            LookupTipeProduk.ViewValue = LookupTipeProduk.CurrentValue;
            LookupTipeProduk.ViewCustomAttributes = "";

            // LookupJenisPlant
            LookupJenisPlant.ViewValue = LookupJenisPlant.CurrentValue;
            LookupJenisPlant.ViewCustomAttributes = "";

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

            // IdPenyaluran
            IdPenyaluran.HrefValue = "";
            IdPenyaluran.TooltipValue = "";

            // NomorPenyaluran
            NomorPenyaluran.HrefValue = "";
            NomorPenyaluran.TooltipValue = "";

            // LinkProses
            LinkProses.HrefValue = "";
            LinkProses.TooltipValue = "";

            // LookupPlant
            LookupPlant.HrefValue = "";
            LookupPlant.TooltipValue = "";

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

            // DetailRTW
            DetailRTW.HrefValue = "";
            DetailRTW.TooltipValue = "";

            // NoShipment
            NoShipment.HrefValue = "";
            NoShipment.TooltipValue = "";

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

            // IdPenimbunan
            IdPenimbunan.HrefValue = "";
            IdPenimbunan.TooltipValue = "";

            // StatusProses
            StatusProses.HrefValue = "";
            StatusProses.TooltipValue = "";

            // IdTemplate
            IdTemplate.HrefValue = "";
            IdTemplate.TooltipValue = "";

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

            // TujuanKonsinyasi2
            TujuanKonsinyasi2.HrefValue = "";
            TujuanKonsinyasi2.TooltipValue = "";

            // Volume2
            Volume2.HrefValue = "";
            Volume2.TooltipValue = "";

            // TujuanKonsinyasi3
            TujuanKonsinyasi3.HrefValue = "";
            TujuanKonsinyasi3.TooltipValue = "";

            // Volume3
            Volume3.HrefValue = "";
            Volume3.TooltipValue = "";

            // TanggalSandar
            TanggalSandar.HrefValue = "";
            TanggalSandar.TooltipValue = "";

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

            // MultipleTujuanKonsinyasi
            MultipleTujuanKonsinyasi.HrefValue = "";
            MultipleTujuanKonsinyasi.TooltipValue = "";

            // MultipleTujuanKonsinyasiHidden
            MultipleTujuanKonsinyasiHidden.HrefValue = "";
            MultipleTujuanKonsinyasiHidden.TooltipValue = "";

            // MultipleQuantity
            MultipleQuantity.HrefValue = "";
            MultipleQuantity.TooltipValue = "";

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

            // IdPenyaluran
            IdPenyaluran.SetupEditAttributes();

            // NomorPenyaluran
            NomorPenyaluran.SetupEditAttributes();
            NomorPenyaluran.EditValue = ConvertToString(NomorPenyaluran.CurrentValue); // DN
            NomorPenyaluran.ViewCustomAttributes = "";

            // LinkProses
            LinkProses.SetupEditAttributes();
            if (!LinkProses.Raw)
                LinkProses.CurrentValue = HtmlDecode(LinkProses.CurrentValue);
            LinkProses.EditValue = LinkProses.CurrentValue;
            LinkProses.PlaceHolder = RemoveHtml(LinkProses.Caption);

            // LookupPlant
            LookupPlant.SetupEditAttributes();
            LookupPlant.EditValue = LookupPlant.Options(true);
            LookupPlant.PlaceHolder = RemoveHtml(LookupPlant.Caption);
            if (!Empty(LookupPlant.EditValue) && IsNumeric(LookupPlant.EditValue))
                LookupPlant.EditValue = FormatNumber(LookupPlant.EditValue, null);

            // IdPlant
            IdPlant.SetupEditAttributes();
            IdPlant.EditValue = IdPlant.CurrentValue;

            // awallookupbung
            string curVal2 = ConvertToString(IdPlant.CurrentValue);
            IdPlant.EditValue = Empty(curVal2) ? DbNullValue : FormatNumber(IdPlant.CurrentValue, IdPlant.FormatPattern);
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
                    }
                }
            }

            // akhirlookupbung
            IdPlant.ViewCustomAttributes = "";

            // TipePenyaluran
            TipePenyaluran.SetupEditAttributes();
            if (!Empty(TipePenyaluran.CurrentValue)) {
                TipePenyaluran.EditValue = TipePenyaluran.OptionCaption(ConvertToString(TipePenyaluran.CurrentValue));
            } else {
                TipePenyaluran.EditValue = DbNullValue;
            }
            TipePenyaluran.ViewCustomAttributes = "";

            // TipeProdukSTS
            TipeProdukSTS.SetupEditAttributes();
            List<object?>? listWrk4 = [ // DN
                TipeProdukSTS.CurrentValue,
                TipeProdukSTS.CurrentValue,
            ];
            listWrk4 = TipeProdukSTS.Lookup?.RenderViewRow(listWrk4, this);
            string? dispVal4 = TipeProdukSTS.DisplayValue(listWrk4);
            if (!Empty(dispVal4))
                TipeProdukSTS.EditValue = dispVal4;

            // akhirlookupbung
            TipeProdukSTS.ViewCustomAttributes = "";

            // KategoriPenyaluran
            KategoriPenyaluran.SetupEditAttributes();
            if (!Empty(KategoriPenyaluran.CurrentValue)) {
                KategoriPenyaluran.EditValue = KategoriPenyaluran.OptionCaption(ConvertToString(KategoriPenyaluran.CurrentValue));
            } else {
                KategoriPenyaluran.EditValue = DbNullValue;
            }
            KategoriPenyaluran.ViewCustomAttributes = "";

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

            // DetailRTW
            DetailRTW.SetupEditAttributes();
            if (!DetailRTW.Raw)
                DetailRTW.CurrentValue = HtmlDecode(DetailRTW.CurrentValue);
            DetailRTW.EditValue = DetailRTW.CurrentValue;
            DetailRTW.PlaceHolder = RemoveHtml(DetailRTW.Caption);

            // NoShipment
            NoShipment.SetupEditAttributes();
            if (!NoShipment.Raw)
                NoShipment.CurrentValue = HtmlDecode(NoShipment.CurrentValue);
            NoShipment.EditValue = NoShipment.CurrentValue;
            NoShipment.PlaceHolder = RemoveHtml(NoShipment.Caption);

            // IdPipa
            IdPipa.SetupEditAttributes();

            // awallookupbung
            string curVal7 = ConvertToString(IdPipa.CurrentValue);
            IdPipa.EditValue = Empty(curVal7) ? DbNullValue : FormatNumber(IdPipa.CurrentValue, IdPipa.FormatPattern);
            if (!Empty(curVal7)) {
                if (IdPipa.Lookup != null && IsDictionary(IdPipa.Lookup?.Options) && IdPipa.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdPipa.EditValue = IdPipa.LookupCacheOption(curVal7);
                } else { // Lookup from database // DN
                    string filterWrk7 = SearchFilter(IdPipa.Lookup?.GetTable()?.Fields["id"].SearchExpression, "=", IdPipa.CurrentValue, IdPipa.Lookup?.GetTable()?.Fields["id"].SearchDataType, "");
                    string? sqlWrk7 = IdPipa.Lookup?.GetSql(false, filterWrk7, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk7?.Count > 0 && IdPipa.Lookup != null) { // Lookup values found
                        var listwrk = IdPipa.Lookup?.RenderViewRow(rswrk7[0]);
                        IdPipa.EditValue = IdPipa.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            IdPipa.ViewCustomAttributes = "";

            // NomorPolisi
            NomorPolisi.SetupEditAttributes();
            NomorPolisi.EditValue = ConvertToString(NomorPolisi.CurrentValue); // DN
            NomorPolisi.ViewCustomAttributes = "";

            // NamaKapal
            NamaKapal.SetupEditAttributes();
            NamaKapal.EditValue = ConvertToString(NamaKapal.CurrentValue); // DN
            NamaKapal.ViewCustomAttributes = "";

            // JenisProduk
            JenisProduk.SetupEditAttributes();

            // awallookupbung
            string curVal8 = ConvertToString(JenisProduk.CurrentValue);
            JenisProduk.EditValue = Empty(curVal8) ? DbNullValue : JenisProduk.CurrentValue;
            if (!Empty(curVal8)) {
                if (JenisProduk.Lookup != null && IsDictionary(JenisProduk.Lookup?.Options) && JenisProduk.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    JenisProduk.EditValue = JenisProduk.LookupCacheOption(curVal8);
                } else { // Lookup from database // DN
                    string filterWrk8 = SearchFilter(JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchExpression, "=", JenisProduk.CurrentValue, JenisProduk.Lookup?.GetTable()?.Fields["NoProduk"].SearchDataType, "");
                    string? sqlWrk8 = JenisProduk.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk8?.Count > 0 && JenisProduk.Lookup != null) { // Lookup values found
                        var listwrk = JenisProduk.Lookup?.RenderViewRow(rswrk8[0]);
                        JenisProduk.EditValue = JenisProduk.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            JenisProduk.ViewCustomAttributes = "";

            // IdPenimbunan
            IdPenimbunan.SetupEditAttributes();
            IdPenimbunan.EditValue = IdPenimbunan.CurrentValue;
            IdPenimbunan.PlaceHolder = RemoveHtml(IdPenimbunan.Caption);
            if (!Empty(IdPenimbunan.EditValue) && IsNumeric(IdPenimbunan.EditValue))
                IdPenimbunan.EditValue = FormatNumber(IdPenimbunan.EditValue, null);

            // StatusProses
            StatusProses.SetupEditAttributes();

            // IdTemplate
            IdTemplate.SetupEditAttributes();
            IdTemplate.CurrentValue = FormatNumber(IdTemplate.CurrentValue, IdTemplate.FormatPattern);
            if (!Empty(IdTemplate.EditValue) && IsNumeric(IdTemplate.EditValue))
                IdTemplate.EditValue = FormatNumber(IdTemplate.EditValue, null);

            // PersentaseProgress
            PersentaseProgress.SetupEditAttributes();
            PersentaseProgress.CurrentValue = FormatPercent(PersentaseProgress.CurrentValue, PersentaseProgress.FormatPattern);

            // Tujuan
            Tujuan.SetupEditAttributes();
            Tujuan.EditValue = ConvertToString(Tujuan.CurrentValue); // DN
            Tujuan.ViewCustomAttributes = "";

            // TujuanKonsinyasi
            TujuanKonsinyasi.SetupEditAttributes();

            // awallookupbung
            string curVal10 = ConvertToString(TujuanKonsinyasi.CurrentValue);
            TujuanKonsinyasi.EditValue = Empty(curVal10) ? DbNullValue : FormatNumber(TujuanKonsinyasi.CurrentValue, TujuanKonsinyasi.FormatPattern);
            if (!Empty(curVal10)) {
                if (TujuanKonsinyasi.Lookup != null && IsDictionary(TujuanKonsinyasi.Lookup?.Options) && TujuanKonsinyasi.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TujuanKonsinyasi.EditValue = TujuanKonsinyasi.LookupCacheOption(curVal10);
                } else { // Lookup from database // DN
                    string filterWrk10 = SearchFilter(TujuanKonsinyasi.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", TujuanKonsinyasi.CurrentValue, TujuanKonsinyasi.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk10 = TujuanKonsinyasi.Lookup?.GetSql(false, filterWrk10, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk10 = sqlWrk10 != null ? Connection.GetRows(sqlWrk10) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk10?.Count > 0 && TujuanKonsinyasi.Lookup != null) { // Lookup values found
                        var listwrk = TujuanKonsinyasi.Lookup?.RenderViewRow(rswrk10[0]);
                        TujuanKonsinyasi.EditValue = TujuanKonsinyasi.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            TujuanKonsinyasi.ViewCustomAttributes = "";

            // Volume
            Volume.SetupEditAttributes();
            Volume.EditValue = Volume.CurrentValue;
            Volume.EditValue = FormatNumber(Volume.EditValue, Volume.FormatPattern);
            Volume.ViewCustomAttributes = "";

            // TujuanKonsinyasiPipa
            TujuanKonsinyasiPipa.SetupEditAttributes();
            if (!TujuanKonsinyasiPipa.Raw)
                TujuanKonsinyasiPipa.CurrentValue = HtmlDecode(TujuanKonsinyasiPipa.CurrentValue);
            TujuanKonsinyasiPipa.EditValue = TujuanKonsinyasiPipa.CurrentValue;
            TujuanKonsinyasiPipa.PlaceHolder = RemoveHtml(TujuanKonsinyasiPipa.Caption);

            // QuantityKonsinyasiPipa
            QuantityKonsinyasiPipa.SetupEditAttributes();
            if (!QuantityKonsinyasiPipa.Raw)
                QuantityKonsinyasiPipa.CurrentValue = HtmlDecode(QuantityKonsinyasiPipa.CurrentValue);
            QuantityKonsinyasiPipa.EditValue = QuantityKonsinyasiPipa.CurrentValue;
            QuantityKonsinyasiPipa.PlaceHolder = RemoveHtml(QuantityKonsinyasiPipa.Caption);

            // TujuanKonsinyasi2
            TujuanKonsinyasi2.SetupEditAttributes();

            // awallookupbung
            string curVal11 = ConvertToString(TujuanKonsinyasi2.CurrentValue);
            TujuanKonsinyasi2.EditValue = Empty(curVal11) ? DbNullValue : FormatNumber(TujuanKonsinyasi2.CurrentValue, TujuanKonsinyasi2.FormatPattern);
            if (!Empty(curVal11)) {
                if (TujuanKonsinyasi2.Lookup != null && IsDictionary(TujuanKonsinyasi2.Lookup?.Options) && TujuanKonsinyasi2.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TujuanKonsinyasi2.EditValue = TujuanKonsinyasi2.LookupCacheOption(curVal11);
                } else { // Lookup from database // DN
                    string filterWrk11 = SearchFilter(TujuanKonsinyasi2.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", TujuanKonsinyasi2.CurrentValue, TujuanKonsinyasi2.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk11 = TujuanKonsinyasi2.Lookup?.GetSql(false, filterWrk11, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk11 = sqlWrk11 != null ? Connection.GetRows(sqlWrk11) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk11?.Count > 0 && TujuanKonsinyasi2.Lookup != null) { // Lookup values found
                        var listwrk = TujuanKonsinyasi2.Lookup?.RenderViewRow(rswrk11[0]);
                        TujuanKonsinyasi2.EditValue = TujuanKonsinyasi2.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            TujuanKonsinyasi2.ViewCustomAttributes = "";

            // Volume2
            Volume2.SetupEditAttributes();
            Volume2.EditValue = Volume2.CurrentValue;
            Volume2.EditValue = FormatNumber(Volume2.EditValue, Volume2.FormatPattern);
            Volume2.ViewCustomAttributes = "";

            // TujuanKonsinyasi3
            TujuanKonsinyasi3.SetupEditAttributes();

            // awallookupbung
            string curVal12 = ConvertToString(TujuanKonsinyasi3.CurrentValue);
            TujuanKonsinyasi3.EditValue = Empty(curVal12) ? DbNullValue : FormatNumber(TujuanKonsinyasi3.CurrentValue, TujuanKonsinyasi3.FormatPattern);
            if (!Empty(curVal12)) {
                if (TujuanKonsinyasi3.Lookup != null && IsDictionary(TujuanKonsinyasi3.Lookup?.Options) && TujuanKonsinyasi3.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TujuanKonsinyasi3.EditValue = TujuanKonsinyasi3.LookupCacheOption(curVal12);
                } else { // Lookup from database // DN
                    string filterWrk12 = SearchFilter(TujuanKonsinyasi3.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", TujuanKonsinyasi3.CurrentValue, TujuanKonsinyasi3.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk12 = TujuanKonsinyasi3.Lookup?.GetSql(false, filterWrk12, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk12 = sqlWrk12 != null ? Connection.GetRows(sqlWrk12) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk12?.Count > 0 && TujuanKonsinyasi3.Lookup != null) { // Lookup values found
                        var listwrk = TujuanKonsinyasi3.Lookup?.RenderViewRow(rswrk12[0]);
                        TujuanKonsinyasi3.EditValue = TujuanKonsinyasi3.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            TujuanKonsinyasi3.ViewCustomAttributes = "";

            // Volume3
            Volume3.SetupEditAttributes();
            Volume3.EditValue = Volume3.CurrentValue;
            Volume3.EditValue = FormatNumber(Volume3.EditValue, Volume3.FormatPattern);
            Volume3.ViewCustomAttributes = "";

            // TanggalSandar
            TanggalSandar.SetupEditAttributes();
            TanggalSandar.EditValue = TanggalSandar.CurrentValue;
            TanggalSandar.EditValue = FormatDateTime(TanggalSandar.EditValue, TanggalSandar.FormatPattern);
            TanggalSandar.ViewCustomAttributes = "";

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

            // MultipleTujuanKonsinyasi
            MultipleTujuanKonsinyasi.SetupEditAttributes();
            if (!Empty(MultipleTujuanKonsinyasi.CurrentValue)) {
                MultipleTujuanKonsinyasi.EditValue = MultipleTujuanKonsinyasi.OptionCaption(ConvertToString(MultipleTujuanKonsinyasi.CurrentValue));
            } else {
                MultipleTujuanKonsinyasi.EditValue = DbNullValue;
            }
            MultipleTujuanKonsinyasi.ViewCustomAttributes = "";

            // MultipleTujuanKonsinyasiHidden
            MultipleTujuanKonsinyasiHidden.SetupEditAttributes();

            // MultipleQuantity
            MultipleQuantity.SetupEditAttributes();
            MultipleQuantity.EditValue = ConvertToString(MultipleQuantity.CurrentValue); // DN
            MultipleQuantity.ViewCustomAttributes = "";

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
                        doc.ExportCaption(IdPenyaluran);
                        doc.ExportCaption(NomorPenyaluran);
                        doc.ExportCaption(LinkProses);
                        doc.ExportCaption(LookupPlant);
                        doc.ExportCaption(IdPlant);
                        doc.ExportCaption(TipePenyaluran);
                        doc.ExportCaption(TipeProdukSTS);
                        doc.ExportCaption(KategoriPenyaluran);
                        doc.ExportCaption(IdModa);
                        doc.ExportCaption(IdPipa);
                        doc.ExportCaption(NomorPolisi);
                        doc.ExportCaption(NamaKapal);
                        doc.ExportCaption(JenisProduk);
                        doc.ExportCaption(IdPenimbunan);
                        doc.ExportCaption(StatusProses);
                        doc.ExportCaption(IdTemplate);
                        doc.ExportCaption(PersentaseProgress);
                        doc.ExportCaption(Tujuan);
                        doc.ExportCaption(TujuanKonsinyasi);
                        doc.ExportCaption(Volume);
                        doc.ExportCaption(TujuanKonsinyasiPipa);
                        doc.ExportCaption(QuantityKonsinyasiPipa);
                        doc.ExportCaption(TanggalSandar);
                        doc.ExportCaption(Catatan);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
                    } else {
                        doc.ExportCaption(LinkProses);
                        doc.ExportCaption(LookupPlant);
                        doc.ExportCaption(IdPlant);
                        doc.ExportCaption(TipePenyaluran);
                        doc.ExportCaption(TipeProdukSTS);
                        doc.ExportCaption(KategoriPenyaluran);
                        doc.ExportCaption(IdModa);
                        doc.ExportCaption(IdPipa);
                        doc.ExportCaption(NomorPolisi);
                        doc.ExportCaption(NamaKapal);
                        doc.ExportCaption(JenisProduk);
                        doc.ExportCaption(StatusProses);
                        doc.ExportCaption(PersentaseProgress);
                        doc.ExportCaption(Tujuan);
                        doc.ExportCaption(TujuanKonsinyasi);
                        doc.ExportCaption(Volume);
                        doc.ExportCaption(TujuanKonsinyasiPipa);
                        doc.ExportCaption(QuantityKonsinyasiPipa);
                        doc.ExportCaption(TanggalSandar);
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
                            await doc.ExportField(IdPenyaluran);
                            await doc.ExportField(NomorPenyaluran);
                            await doc.ExportField(LinkProses);
                            await doc.ExportField(LookupPlant);
                            await doc.ExportField(IdPlant);
                            await doc.ExportField(TipePenyaluran);
                            await doc.ExportField(TipeProdukSTS);
                            await doc.ExportField(KategoriPenyaluran);
                            await doc.ExportField(IdModa);
                            await doc.ExportField(IdPipa);
                            await doc.ExportField(NomorPolisi);
                            await doc.ExportField(NamaKapal);
                            await doc.ExportField(JenisProduk);
                            await doc.ExportField(IdPenimbunan);
                            await doc.ExportField(StatusProses);
                            await doc.ExportField(IdTemplate);
                            await doc.ExportField(PersentaseProgress);
                            await doc.ExportField(Tujuan);
                            await doc.ExportField(TujuanKonsinyasi);
                            await doc.ExportField(Volume);
                            await doc.ExportField(TujuanKonsinyasiPipa);
                            await doc.ExportField(QuantityKonsinyasiPipa);
                            await doc.ExportField(TanggalSandar);
                            await doc.ExportField(Catatan);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
                        } else {
                            await doc.ExportField(LinkProses);
                            await doc.ExportField(LookupPlant);
                            await doc.ExportField(IdPlant);
                            await doc.ExportField(TipePenyaluran);
                            await doc.ExportField(TipeProdukSTS);
                            await doc.ExportField(KategoriPenyaluran);
                            await doc.ExportField(IdModa);
                            await doc.ExportField(IdPipa);
                            await doc.ExportField(NomorPolisi);
                            await doc.ExportField(NamaKapal);
                            await doc.ExportField(JenisProduk);
                            await doc.ExportField(StatusProses);
                            await doc.ExportField(PersentaseProgress);
                            await doc.ExportField(Tujuan);
                            await doc.ExportField(TujuanKonsinyasi);
                            await doc.ExportField(Volume);
                            await doc.ExportField(TujuanKonsinyasiPipa);
                            await doc.ExportField(QuantityKonsinyasiPipa);
                            await doc.ExportField(TanggalSandar);
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
            if (currentUser == "5"){
                AddFilter(ref filter, $"TipePenyaluran = 'Konsinyasi'");
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
            try 
            {
                var idPlantStr = rsnew.TryGetValue("IdPlant", out var vPlant) ? vPlant?.ToString() : null;
                if (string.IsNullOrWhiteSpace(idPlantStr) || !int.TryParse(idPlantStr, out var idPlant))
                    throw new Exception("IdPlant kosong atau tidak valid.");
                var tipePenyaluranRaw = rsnew.TryGetValue("TipePenyaluran", out var vTipe) ? vTipe?.ToString() : "";
                var tipePenyaluran = (tipePenyaluranRaw ?? "").Replace("'", "''");
                var idModa = rsnew.TryGetValue("IdModa", out var vModa) ? vModa?.ToString() : "";
                int idPipa = 0;
                if (rsnew.TryGetValue("IdPipa", out var vPipa) && vPipa != null)
                    int.TryParse(vPipa.ToString(), out idPipa);
                string sql;
                bool modaPipa = (idModa == "5" || idModa == "6");
                if (modaPipa && idPipa > 0)
                    sql = $"EXEC dbo.GenerateNomorReferensiPenyaluran @JenisPenyaluran = 'Penyaluran', @IdPlant = {idPlant}, @NoProdukOrTipePenyaluran = '{tipePenyaluran}', @IdPipa = {idPipa}";
                else
                    sql = $"EXEC dbo.GenerateNomorReferensiPenyaluran @JenisPenyaluran = 'Penyaluran', @IdPlant = {idPlant}, @NoProdukOrTipePenyaluran = '{tipePenyaluran}'";
                var nomorRefObj = ExecuteScalar(sql);
                if (nomorRefObj == null || string.IsNullOrWhiteSpace(nomorRefObj.ToString()))
                    throw new Exception("Gagal menghasilkan Nomor Referensi.");
                rsnew["NomorPenyaluran"] = nomorRefObj.ToString();
                DateTime plantTime = DateTime.Now;
                var plantObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @IdPlant = {idPlant}");
                if (plantObj != null && DateTime.TryParse(plantObj.ToString(), out var tmp))
                    plantTime = tmp;
                rsnew["TanggalDibuat"] = plantTime;
                rsnew["TanggalDiperbarui"] = plantTime;
                rsnew["DibuatOleh"] = CurrentUserName();
                rsnew["DiperbaruiOleh"] = CurrentUserName();
            }
            catch (Exception ex) 
            {
                Log("Error in Row_Inserting (GenerateNomorReferensiPenyaluran): " + ex.Message);
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
                var nomorReferensi = rsnew["NomorPenyaluran"].ToString();
                var jenisProses = "Penyaluran";
                var idModa = Convert.ToInt32(rsnew["IdModa"]);
                var dibuatOleh = CurrentUserName();
                var Tipe = rsnew["TipePenyaluran"].ToString();
                var kategori = rsnew.ContainsKey("KategoriPenyaluran")
                            ? rsnew["KategoriPenyaluran"]?.ToString()?.Trim()
                            : "";
                string NomorPolisi = rsnew.ContainsKey("NomorPolisi") ? rsnew["NomorPolisi"]?.ToString() ?? "" : "";
                string TipeProduk = rsnew.ContainsKey("LookupTipeProduk") ? rsnew["LookupTipeProduk"]?.ToString() ?? "" : "";
                string sql = "";
                if (Tipe == "Sales")
                {
                    if (kategori == "TAS/NGS" && idModa == 3 && TipeProduk == "LPG")
                    {
                        sql = $"EXEC GenerateProsesAktivitas_PenyaluranTasNgs '{nomorReferensi}', 'PenyaluranLPGTASNGS', {idModa}, '{dibuatOleh}', '{NomorPolisi}'";
                    }
                    else if (kategori == "TAS/NGS")
                    {
                        sql = $"EXEC GenerateProsesAktivitas_PenyaluranTasNgs '{nomorReferensi}', 'PenyaluranTasNgs', {idModa}, '{dibuatOleh}', '{NomorPolisi}'";
                    }
                    else if (kategori == "Non TAS/NGS" && idModa == 3 && TipeProduk == "LPG")
                    {
                        sql = $"EXEC GenerateProsesAktivitas_Penyaluran '{nomorReferensi}', 'PenyaluranTruck', {idModa},'{dibuatOleh}', '{NomorPolisi}'";
                    }
                    else
                    {
                        sql = $"EXEC GenerateProsesAktivitas_Penyaluran '{nomorReferensi}', '{jenisProses}', {idModa},'{dibuatOleh}', '{NomorPolisi}'";
                    }
                }
                else if (Tipe == "Konsinyasi")
                {
                    if (idModa == 3)
                    {
                        if (TipeProduk == "LPG")
                            sql = kategori == "TAS/NGS"
                                ? $"EXEC GenerateProsesAktivitas_PenyaluranTasNgs '{nomorReferensi}', 'PenyaluranLPGTASNGS', {idModa}, '{dibuatOleh}', '{NomorPolisi}'"
                                : $"EXEC GenerateProsesAktivitas_Penyaluran '{nomorReferensi}', 'PenyaluranTruck', {idModa},'{dibuatOleh}', '{NomorPolisi}'";
                        else
                            sql = kategori == "TAS/NGS"
                                ? $"EXEC GenerateProsesAktivitas_Penyaluran '{nomorReferensi}', 'PenyaluranKonsinyasiTruckTAS', {idModa},'{dibuatOleh}', '{NomorPolisi}'"
                                : $"EXEC GenerateProsesAktivitas_Penyaluran '{nomorReferensi}', 'PenyaluranKonsinyasiTruck', {idModa},'{dibuatOleh}', '{NomorPolisi}'";
                    }
                    else 
                    {
                        string namaKapal = rsnew.ContainsKey("NamaKapal") ? rsnew["NamaKapal"]?.ToString() ?? "" : "";
                        string IdPlant = rsnew.ContainsKey("IdPlant") ? rsnew["IdPlant"]?.ToString() ?? "" : "";
                        sql = $"EXEC GenerateProsesAktivitas_PenyaluranKonsinyasi '{nomorReferensi}', '{jenisProses}', {idModa},'{dibuatOleh}','{namaKapal}','{IdPlant}'";
                    }
                    /*
                    if (idModa == 3 && TipeProduk == "LPG")
                    {
                        if (kategori == "TAS/NGS")
                        {
                            sql = $"EXEC GenerateProsesAktivitas_PenyaluranTasNgs '{nomorReferensi}', 'PenyaluranLPGTASNGS', {idModa}, '{dibuatOleh}', '{NomorPolisi}'";
                        }
                        else
                        {
                            sql = $"EXEC GenerateProsesAktivitas_Penyaluran '{nomorReferensi}', 'PenyaluranTruck', {idModa},'{dibuatOleh}', '{NomorPolisi}'";
                        }
                    }
                    else
                    {
                        string namaKapal = rsnew.ContainsKey("NamaKapal") ? rsnew["NamaKapal"]?.ToString() ?? "" : "";
                        string IdPlant = rsnew.ContainsKey("IdPlant") ? rsnew["IdPlant"]?.ToString() ?? "" : "";
                        sql = $"EXEC GenerateProsesAktivitas_PenyaluranKonsinyasi '{nomorReferensi}', '{jenisProses}', {idModa},'{dibuatOleh}','{namaKapal}','{IdPlant}'";
                    }
                    */
                    if (idModa == 5 || idModa == 6 || idModa == 12)
                    {
                        var tujuanKonsinyasiJSON = rsnew.ContainsKey("MultipleTujuanKonsinyasiHidden")
                            ? rsnew["MultipleTujuanKonsinyasiHidden"]?.ToString()
                            : null;
                        List<TujuanKonsinyasiItem>? tujuanKonsinyasi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TujuanKonsinyasiItem>>(tujuanKonsinyasiJSON);
                        foreach (var item in tujuanKonsinyasi)
                        {
                            var idTujuan = item.Value?.Trim();
                            var namaTujuan = item.Label?.Trim() ?? "";
                            var qty = item.Qty;
                            string insertSql = @"
                                INSERT INTO DetailPenyaluranPipa
                                (NomorPenyaluran, TujuanKonsinyasi, Quantity)
                                VALUES
                                (@NoReferensi, @IdTujuanKonsinyasi, @Qty);
                            ";
                            using (SqlConnection conn = GetConnection("Db").OpenConnection())
                            {
                                using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@NoReferensi", nomorReferensi);
                                    cmd.Parameters.AddWithValue("@IdTujuanKonsinyasi", idTujuan);
                                    cmd.Parameters.AddWithValue("@Qty", qty);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                ExecuteScalar(sql);
            }
            catch (Exception ex)
            {
                // Optional: log error jika mau
                Console.WriteLine(ex);
                Log("Error in Row_Inserted (Generate Proses & Aktivitas): " + ex.Message);
            }
        }
        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            try {
                // Tentukan IdPlant atau NomorPenyaluran dari data baru/lama
                string idPlant        = rsnew.ContainsKey("IdPlant") 
                    ? rsnew["IdPlant"].ToString() 
                    : rsold["IdPlant"].ToString();
                // Atau, jika Anda ingin memakai nomor penyaluran:
                //string nomorRef = rsnew.ContainsKey("NomorPenyaluran") ? rsnew["NomorPenyaluran"].ToString() : rsold["NomorPenyaluran"].ToString();

                // Ambil waktu plant via SP GetPlantDateTime
                DateTime plantTime = DateTime.Now; // fallback
                var plantObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @IdPlant = {idPlant}");
                if (plantObj != null && DateTime.TryParse(plantObj.ToString(), out var tmp))
                    plantTime = tmp;

                // Set kolom pembaruan
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
            if (fld.FieldVar == "x_IdModa")
                fld.Lookup.Distinct = false;
            // var currentUserLevel = CurrentUserLevel();

            // if (fld.Name != "IdPlant" || !Security.IsLoggedIn)
            //     return;

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
            string noPenyaluran = NomorPenyaluran.CurrentValue?.ToString() ?? "";
            string sql = @"
                SELECT 
                    CONCAT(MP.Plant, ' - ', MP.Nama_Terminal) AS TujuanKonsinyasi,
                    D.Quantity
                FROM DetailPenyaluranPipa D
                JOIN MasterPlant MP ON D.TujuanKonsinyasi =  MP.IdPlant
                WHERE NomorPenyaluran = @NoReferensi
            ";
            using (SqlConnection conn = GetConnection("Db").OpenConnection()) {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", noPenyaluran);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        List<string> tujuanList = new();
                        List<string> quantityList = new();
                        while (reader.Read()) {
                            tujuanList.Add(reader["TujuanKonsinyasi"].ToString() ?? "");
                            quantityList.Add(reader["Quantity"].ToString() ?? "");
                        }
                        string tujuan = "", quantity = "";
                        if (tujuanList.Count > 0)
                        {
                            tujuan = string.Join(", ", tujuanList);
                        }
                        if (quantityList.Count > 0)
                        {
                            quantity = string.Join(", ", quantityList);
                        }
                        TujuanKonsinyasiPipa.CurrentValue = tujuan;
                        QuantityKonsinyasiPipa.CurrentValue = quantity;
                    }
                }
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
