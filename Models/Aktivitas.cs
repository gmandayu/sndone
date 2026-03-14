namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// aktivitas
    /// </summary>
    [MaybeNull]
    public static Aktivitas aktivitas
    {
        get => HttpData.Resolve<Aktivitas>("Aktivitas");
        set => HttpData["Aktivitas"] = value;
    }

    /// <summary>
    /// Table class for Aktivitas
    /// </summary>
    public class Aktivitas : DbTable
    {
        public override Dictionary<string, string> KeyFields { get; set; } = new() { // DN
            { "IdAktivitas", "IdAktivitas" },
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

        public readonly DbField<SqlDbType> IdAktivitas;

        public readonly DbField<SqlDbType> No_Referensi;

        public readonly DbField<SqlDbType> IdProses;

        public readonly DbField<SqlDbType> IdTemplateAktivitas;

        public readonly DbField<SqlDbType> Aktivitas2;

        public readonly DbField<SqlDbType> NamaAktivitas;

        public readonly DbField<SqlDbType> PIC;

        public readonly DbField<SqlDbType> TanggalMulai;

        public readonly DbField<SqlDbType> TanggalSelesai;

        public readonly DbField<SqlDbType> StatusAktivitas;

        public readonly DbField<SqlDbType> DibuatOleh;

        public readonly DbField<SqlDbType> TanggalDibuat;

        public readonly DbField<SqlDbType> DiperbaruiOleh;

        public readonly DbField<SqlDbType> TanggalDiperbarui;

        public readonly DbField<SqlDbType> TipeAktivitas;

        public readonly DbField<SqlDbType> sandar_nama_kapal;

        public readonly DbField<SqlDbType> sandar_tgl_tiba;

        public readonly DbField<SqlDbType> sandar_nominasi;

        public readonly DbField<SqlDbType> Produk;

        public readonly DbField<SqlDbType> Shipment;

        public readonly DbField<SqlDbType> Nama_Proses;

        public readonly DbField<SqlDbType> IdDokumen;

        public readonly DbField<SqlDbType> PathFile;

        public readonly DbField<SqlDbType> TanggalUploadDok;

        public readonly DbField<SqlDbType> UserUploadDok;

        public readonly DbField<SqlDbType> NamaDokumen;

        public readonly DbField<SqlDbType> Keterangan;

        public readonly DbField<SqlDbType> IdRefAnak;

        public readonly DbField<SqlDbType> TableAnak;

        public readonly DbField<SqlDbType> TipeProses;

        public readonly DbField<SqlDbType> Urutan;

        public readonly DbField<SqlDbType> IsNominationTankReceivingLineOpen;

        public readonly DbField<SqlDbType> IsNonNominationReceivingLineClosedAndSealed;

        public readonly DbField<SqlDbType> IsTankEmptyAndDry;

        public readonly DbField<SqlDbType> IsDocumentationComplete;

        // Constructor
        public Aktivitas()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "Aktivitas";
            Name = "Aktivitas";
            Type = "TABLE";
            UpdateTable = "dbo.Aktivitas"; // Update Table
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
            DetailEdit = true; // Allow detail edit
            DetailView = false; // Allow detail view
            ShowMultipleDetails = false; // Show multiple details
            GridAddRowCount = 5;
            AllowAddDeleteRow = true; // Allow add/delete row
            UseAjaxActions = UseAjaxActions || Config.UseAjaxActions;
            UserIdAllowSecurity = Config.DefaultUserIdAllowSecurity; // User ID Allow

            // IdAktivitas
            IdAktivitas = new(this, "x_IdAktivitas", 3, SqlDbType.Int) {
                Name = "IdAktivitas",
                Expression = "[IdAktivitas]",
                BasicSearchExpression = "CAST([IdAktivitas] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdAktivitas]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "NO",
                InputTextType = "text",
                IsAutoIncrement = true, // Autoincrement field
                IsPrimaryKey = true, // Primary key field
                IsForeignKey = true, // Foreign key field
                Nullable = false, // NOT NULL field
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "IdAktivitas", "CustomMsg"),
                IsUpload = false
            };
            IdAktivitas.Raw = true;
            Fields.Add("IdAktivitas", IdAktivitas);

            // No_Referensi
            No_Referensi = new(this, "x_No_Referensi", 202, SqlDbType.NVarChar) {
                Name = "No_Referensi",
                Expression = "[No_Referensi]",
                UseBasicSearch = true,
                BasicSearchExpression = "[No_Referensi]",
                DateTimeFormat = -1,
                VirtualExpression = "[No_Referensi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "No_Referensi", "CustomMsg"),
                IsUpload = false
            };
            No_Referensi.Lookup = new Lookup<DbField>(No_Referensi, "Aktivitas", true, "No_Referensi", new List<string> {"No_Referensi", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("No_Referensi", No_Referensi);

            // IdProses
            IdProses = new(this, "x_IdProses", 3, SqlDbType.Int) {
                Name = "IdProses",
                Expression = "[IdProses]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([IdProses] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdProses]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "IdProses", "CustomMsg"),
                IsUpload = false
            };
            IdProses.Raw = true;
            IdProses.Lookup = new Lookup<DbField>(IdProses, "Proses", true, "IdProses", new List<string> {"NamaProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaProses]");
            Fields.Add("IdProses", IdProses);

            // IdTemplateAktivitas
            IdTemplateAktivitas = new(this, "x_IdTemplateAktivitas", 3, SqlDbType.Int) {
                Name = "IdTemplateAktivitas",
                Expression = "[IdTemplateAktivitas]",
                BasicSearchExpression = "CAST([IdTemplateAktivitas] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdTemplateAktivitas]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "IdTemplateAktivitas", "CustomMsg"),
                IsUpload = false
            };
            IdTemplateAktivitas.Raw = true;
            IdTemplateAktivitas.Lookup = new Lookup<DbField>(IdTemplateAktivitas, "TemplateAktivitas", true, "IdTemplateAktivitas", new List<string> {"NamaAktivitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaAktivitas]");
            Fields.Add("IdTemplateAktivitas", IdTemplateAktivitas);

            // Aktivitas
            Aktivitas2 = new(this, "x_Aktivitas2", 203, SqlDbType.NText) {
                Name = "Aktivitas",
                Expression = "CASE WHEN TipeAktivitas = 'Dokumen' THEN '<a href=AktivitasDokumenList?showmaster=Aktivitas&fk_IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' WHEN TipeAktivitas = 'Form' AND TableAnak IS NOT NULL AND IdRefAnak IS NOT NULL THEN  '<a href=' + CAST(TableAnak AS NVARCHAR(255)) + 'Edit/' + CAST(IdRefAnak AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' WHEN TipeAktivitas = 'Tabel' THEN '<a href=AktivitasTabel?IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' ELSE CAST(NamaAktivitas AS NVARCHAR(255)) END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN TipeAktivitas = 'Dokumen' THEN '<a href=AktivitasDokumenList?showmaster=Aktivitas&fk_IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' WHEN TipeAktivitas = 'Form' AND TableAnak IS NOT NULL AND IdRefAnak IS NOT NULL THEN  '<a href=' + CAST(TableAnak AS NVARCHAR(255)) + 'Edit/' + CAST(IdRefAnak AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' WHEN TipeAktivitas = 'Tabel' THEN '<a href=AktivitasTabel?IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' ELSE CAST(NamaAktivitas AS NVARCHAR(255)) END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN TipeAktivitas = 'Dokumen' THEN '<a href=AktivitasDokumenList?showmaster=Aktivitas&fk_IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' WHEN TipeAktivitas = 'Form' AND TableAnak IS NOT NULL AND IdRefAnak IS NOT NULL THEN  '<a href=' + CAST(TableAnak AS NVARCHAR(255)) + 'Edit/' + CAST(IdRefAnak AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' WHEN TipeAktivitas = 'Tabel' THEN '<a href=AktivitasTabel?IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' ELSE CAST(NamaAktivitas AS NVARCHAR(255)) END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "Aktivitas2", "CustomMsg"),
                IsUpload = false
            };
            Aktivitas2.Lookup = new Lookup<DbField>(Aktivitas2, "Aktivitas", true, "Aktivitas", new List<string> {"Aktivitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Aktivitas", Aktivitas2);

            // NamaAktivitas
            NamaAktivitas = new(this, "x_NamaAktivitas", 203, SqlDbType.NText) {
                Name = "NamaAktivitas",
                Expression = "[NamaAktivitas]",
                BasicSearchExpression = "[NamaAktivitas]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaAktivitas]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "NamaAktivitas", "CustomMsg"),
                IsUpload = false
            };
            NamaAktivitas.Lookup = new Lookup<DbField>(NamaAktivitas, "Aktivitas", true, "NamaAktivitas", new List<string> {"NamaAktivitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NamaAktivitas", NamaAktivitas);

            // PIC
            PIC = new(this, "x_PIC", 200, SqlDbType.VarChar) {
                Name = "PIC",
                Expression = "[PIC]",
                UseBasicSearch = true,
                BasicSearchExpression = "[PIC]",
                DateTimeFormat = -1,
                VirtualExpression = "[PIC]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "PIC", "CustomMsg"),
                IsUpload = false
            };
            PIC.Lookup = new Lookup<DbField>(PIC, "MasterPIC", true, "IdPIC", new List<string> {"NamaPIC", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaPIC]");
            Fields.Add("PIC", PIC);

            // TanggalMulai
            TanggalMulai = new(this, "x_TanggalMulai", 135, SqlDbType.DateTime) {
                Name = "TanggalMulai",
                Expression = "[TanggalMulai]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TanggalMulai]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[TanggalMulai]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "TanggalMulai", "CustomMsg"),
                IsUpload = false
            };
            TanggalMulai.Raw = true;
            TanggalMulai.Lookup = new Lookup<DbField>(TanggalMulai, "Aktivitas", true, "TanggalMulai", new List<string> {"TanggalMulai", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalMulai", TanggalMulai);

            // TanggalSelesai
            TanggalSelesai = new(this, "x_TanggalSelesai", 135, SqlDbType.DateTime) {
                Name = "TanggalSelesai",
                Expression = "[TanggalSelesai]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TanggalSelesai]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[TanggalSelesai]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "TanggalSelesai", "CustomMsg"),
                IsUpload = false
            };
            TanggalSelesai.Raw = true;
            TanggalSelesai.Lookup = new Lookup<DbField>(TanggalSelesai, "Aktivitas", true, "TanggalSelesai", new List<string> {"TanggalSelesai", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalSelesai", TanggalSelesai);

            // StatusAktivitas
            StatusAktivitas = new(this, "x_StatusAktivitas", 200, SqlDbType.VarChar) {
                Name = "StatusAktivitas",
                Expression = "[StatusAktivitas]",
                UseBasicSearch = true,
                BasicSearchExpression = "[StatusAktivitas]",
                DateTimeFormat = -1,
                VirtualExpression = "[StatusAktivitas]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "StatusAktivitas", "CustomMsg"),
                IsUpload = false
            };
            StatusAktivitas.Lookup = new Lookup<DbField>(StatusAktivitas, "Aktivitas", true, "StatusAktivitas", new List<string> {"StatusAktivitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("StatusAktivitas", StatusAktivitas);

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
                CustomMessage = Language.FieldPhrase("Aktivitas", "DibuatOleh", "CustomMsg"),
                IsUpload = false
            };
            DibuatOleh.Lookup = new Lookup<DbField>(DibuatOleh, "Aktivitas", true, "DibuatOleh", new List<string> {"DibuatOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "TanggalDibuat", "CustomMsg"),
                IsUpload = false
            };
            TanggalDibuat.Raw = true;
            TanggalDibuat.Lookup = new Lookup<DbField>(TanggalDibuat, "Aktivitas", true, "TanggalDibuat", new List<string> {"TanggalDibuat", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "DiperbaruiOleh", "CustomMsg"),
                IsUpload = false
            };
            DiperbaruiOleh.Lookup = new Lookup<DbField>(DiperbaruiOleh, "Aktivitas", true, "DiperbaruiOleh", new List<string> {"DiperbaruiOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "TanggalDiperbarui", "CustomMsg"),
                IsUpload = false
            };
            TanggalDiperbarui.Raw = true;
            TanggalDiperbarui.Lookup = new Lookup<DbField>(TanggalDiperbarui, "Aktivitas", true, "TanggalDiperbarui", new List<string> {"TanggalDiperbarui", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            TanggalDiperbarui.GetAutoUpdateValue = () => CurrentDateTime();
            Fields.Add("TanggalDiperbarui", TanggalDiperbarui);

            // TipeAktivitas
            TipeAktivitas = new(this, "x_TipeAktivitas", 202, SqlDbType.NVarChar) {
                Name = "TipeAktivitas",
                Expression = "[TipeAktivitas]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TipeAktivitas]",
                DateTimeFormat = -1,
                VirtualExpression = "[TipeAktivitas]",
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
                OptionCount = 4,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "TipeAktivitas", "CustomMsg"),
                IsUpload = false
            };
            TipeAktivitas.Lookup = new Lookup<DbField>(TipeAktivitas, "Aktivitas", true, "TipeAktivitas", new List<string> {"TipeAktivitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TipeAktivitas", TipeAktivitas);

            // sandar_nama_kapal
            sandar_nama_kapal = new(this, "x_sandar_nama_kapal", 202, SqlDbType.NVarChar) {
                Name = "sandar_nama_kapal",
                Expression = "[sandar_nama_kapal]",
                BasicSearchExpression = "[sandar_nama_kapal]",
                DateTimeFormat = -1,
                VirtualExpression = "[sandar_nama_kapal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "sandar_nama_kapal", "CustomMsg"),
                IsUpload = false
            };
            sandar_nama_kapal.Lookup = new Lookup<DbField>(sandar_nama_kapal, "Aktivitas", true, "sandar_nama_kapal", new List<string> {"sandar_nama_kapal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("sandar_nama_kapal", sandar_nama_kapal);

            // sandar_tgl_tiba
            sandar_tgl_tiba = new(this, "x_sandar_tgl_tiba", 135, SqlDbType.DateTime) {
                Name = "sandar_tgl_tiba",
                Expression = "[sandar_tgl_tiba]",
                BasicSearchExpression = CastDateFieldForLike("[sandar_tgl_tiba]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[sandar_tgl_tiba]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "sandar_tgl_tiba", "CustomMsg"),
                IsUpload = false
            };
            sandar_tgl_tiba.Raw = true;
            sandar_tgl_tiba.Lookup = new Lookup<DbField>(sandar_tgl_tiba, "Aktivitas", true, "sandar_tgl_tiba", new List<string> {"sandar_tgl_tiba", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("sandar_tgl_tiba", sandar_tgl_tiba);

            // sandar_nominasi
            sandar_nominasi = new(this, "x_sandar_nominasi", 202, SqlDbType.NVarChar) {
                Name = "sandar_nominasi",
                Expression = "[sandar_nominasi]",
                BasicSearchExpression = "[sandar_nominasi]",
                DateTimeFormat = -1,
                VirtualExpression = "[sandar_nominasi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "sandar_nominasi", "CustomMsg"),
                IsUpload = false
            };
            sandar_nominasi.Lookup = new Lookup<DbField>(sandar_nominasi, "Aktivitas", true, "sandar_nominasi", new List<string> {"sandar_nominasi", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("sandar_nominasi", sandar_nominasi);

            // Produk
            Produk = new(this, "x_Produk", 202, SqlDbType.NVarChar) {
                Name = "Produk",
                Expression = "[Produk]",
                BasicSearchExpression = "[Produk]",
                DateTimeFormat = -1,
                VirtualExpression = "[Produk]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "Produk", "CustomMsg"),
                IsUpload = false
            };
            Produk.Lookup = new Lookup<DbField>(Produk, "Aktivitas", true, "Produk", new List<string> {"Produk", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Produk", Produk);

            // Shipment
            Shipment = new(this, "x_Shipment", 202, SqlDbType.NVarChar) {
                Name = "Shipment",
                Expression = "[Shipment]",
                BasicSearchExpression = "[Shipment]",
                DateTimeFormat = -1,
                VirtualExpression = "[Shipment]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "Shipment", "CustomMsg"),
                IsUpload = false
            };
            Shipment.Lookup = new Lookup<DbField>(Shipment, "Aktivitas", true, "Shipment", new List<string> {"Shipment", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Shipment", Shipment);

            // Nama_Proses
            Nama_Proses = new(this, "x_Nama_Proses", 202, SqlDbType.NVarChar) {
                Name = "Nama_Proses",
                Expression = "[Nama_Proses]",
                BasicSearchExpression = "[Nama_Proses]",
                DateTimeFormat = -1,
                VirtualExpression = "[Nama_Proses]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "Nama_Proses", "CustomMsg"),
                IsUpload = false
            };
            Nama_Proses.Lookup = new Lookup<DbField>(Nama_Proses, "Aktivitas", true, "Nama_Proses", new List<string> {"Nama_Proses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Nama_Proses", Nama_Proses);

            // IdDokumen
            IdDokumen = new(this, "x_IdDokumen", 3, SqlDbType.Int) {
                Name = "IdDokumen",
                Expression = "[IdDokumen]",
                BasicSearchExpression = "CAST([IdDokumen] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdDokumen]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "IdDokumen", "CustomMsg"),
                IsUpload = false
            };
            IdDokumen.Raw = true;
            IdDokumen.Lookup = new Lookup<DbField>(IdDokumen, "Aktivitas", true, "IdDokumen", new List<string> {"IdDokumen", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("IdDokumen", IdDokumen);

            // PathFile
            PathFile = new(this, "x_PathFile", 202, SqlDbType.NVarChar) {
                Name = "PathFile",
                Expression = "[PathFile]",
                BasicSearchExpression = "[PathFile]",
                DateTimeFormat = -1,
                VirtualExpression = "[PathFile]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "PathFile", "CustomMsg"),
                IsUpload = false
            };
            PathFile.Lookup = new Lookup<DbField>(PathFile, "Aktivitas", true, "PathFile", new List<string> {"PathFile", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PathFile", PathFile);

            // TanggalUploadDok
            TanggalUploadDok = new(this, "x_TanggalUploadDok", 135, SqlDbType.DateTime) {
                Name = "TanggalUploadDok",
                Expression = "[TanggalUploadDok]",
                BasicSearchExpression = CastDateFieldForLike("[TanggalUploadDok]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[TanggalUploadDok]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "TanggalUploadDok", "CustomMsg"),
                IsUpload = false
            };
            TanggalUploadDok.Raw = true;
            TanggalUploadDok.Lookup = new Lookup<DbField>(TanggalUploadDok, "Aktivitas", true, "TanggalUploadDok", new List<string> {"TanggalUploadDok", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalUploadDok", TanggalUploadDok);

            // UserUploadDok
            UserUploadDok = new(this, "x_UserUploadDok", 202, SqlDbType.NVarChar) {
                Name = "UserUploadDok",
                Expression = "[UserUploadDok]",
                BasicSearchExpression = "[UserUploadDok]",
                DateTimeFormat = -1,
                VirtualExpression = "[UserUploadDok]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "UserUploadDok", "CustomMsg"),
                IsUpload = false
            };
            UserUploadDok.Lookup = new Lookup<DbField>(UserUploadDok, "Aktivitas", true, "UserUploadDok", new List<string> {"UserUploadDok", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("UserUploadDok", UserUploadDok);

            // NamaDokumen
            NamaDokumen = new(this, "x_NamaDokumen", 202, SqlDbType.NVarChar) {
                Name = "NamaDokumen",
                Expression = "[NamaDokumen]",
                BasicSearchExpression = "[NamaDokumen]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaDokumen]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "NamaDokumen", "CustomMsg"),
                IsUpload = false
            };
            NamaDokumen.Lookup = new Lookup<DbField>(NamaDokumen, "Aktivitas", true, "NamaDokumen", new List<string> {"NamaDokumen", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NamaDokumen", NamaDokumen);

            // Keterangan
            Keterangan = new(this, "x_Keterangan", 201, SqlDbType.Text) {
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "Keterangan", "CustomMsg"),
                IsUpload = false
            };
            Keterangan.Lookup = new Lookup<DbField>(Keterangan, "Aktivitas", true, "Keterangan", new List<string> {"Keterangan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Keterangan", Keterangan);

            // IdRefAnak
            IdRefAnak = new(this, "x_IdRefAnak", 3, SqlDbType.Int) {
                Name = "IdRefAnak",
                Expression = "[IdRefAnak]",
                BasicSearchExpression = "CAST([IdRefAnak] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdRefAnak]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "IdRefAnak", "CustomMsg"),
                IsUpload = false
            };
            IdRefAnak.Raw = true;
            IdRefAnak.Lookup = new Lookup<DbField>(IdRefAnak, "Aktivitas", true, "IdRefAnak", new List<string> {"IdRefAnak", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("IdRefAnak", IdRefAnak);

            // TableAnak
            TableAnak = new(this, "x_TableAnak", 202, SqlDbType.NVarChar) {
                Name = "TableAnak",
                Expression = "[TableAnak]",
                BasicSearchExpression = "[TableAnak]",
                DateTimeFormat = -1,
                VirtualExpression = "[TableAnak]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "TableAnak", "CustomMsg"),
                IsUpload = false
            };
            TableAnak.Lookup = new Lookup<DbField>(TableAnak, "Aktivitas", true, "TableAnak", new List<string> {"TableAnak", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TableAnak", TableAnak);

            // TipeProses
            TipeProses = new(this, "x_TipeProses", 202, SqlDbType.NVarChar) {
                Name = "TipeProses",
                Expression = "[TipeProses]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TipeProses]",
                DateTimeFormat = -1,
                VirtualExpression = "[TipeProses]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "TipeProses", "CustomMsg"),
                IsUpload = false
            };
            TipeProses.Lookup = new Lookup<DbField>(TipeProses, "Aktivitas", true, "TipeProses", new List<string> {"TipeProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TipeProses", TipeProses);

            // Urutan
            Urutan = new(this, "x_Urutan", 3, SqlDbType.Int) {
                Name = "Urutan",
                Expression = "[Urutan]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([Urutan] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Urutan]",
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
                CustomMessage = Language.FieldPhrase("Aktivitas", "Urutan", "CustomMsg"),
                IsUpload = false
            };
            Urutan.Raw = true;
            Urutan.Lookup = new Lookup<DbField>(Urutan, "Aktivitas", true, "Urutan", new List<string> {"Urutan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Urutan", Urutan);

            // IsNominationTankReceivingLineOpen
            IsNominationTankReceivingLineOpen = new(this, "x_IsNominationTankReceivingLineOpen", 11, SqlDbType.Bit) {
                Name = "IsNominationTankReceivingLineOpen",
                Expression = "[IsNominationTankReceivingLineOpen]",
                BasicSearchExpression = "[IsNominationTankReceivingLineOpen]",
                DateTimeFormat = -1,
                VirtualExpression = "[IsNominationTankReceivingLineOpen]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = ["=", "<>"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "IsNominationTankReceivingLineOpen", "CustomMsg"),
                IsUpload = false
            };
            IsNominationTankReceivingLineOpen.Raw = true;
            IsNominationTankReceivingLineOpen.Lookup = new Lookup<DbField>(IsNominationTankReceivingLineOpen, "Aktivitas", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            IsNominationTankReceivingLineOpen.UserValues = ["1"];
            Fields.Add("IsNominationTankReceivingLineOpen", IsNominationTankReceivingLineOpen);

            // IsNonNominationReceivingLineClosedAndSealed
            IsNonNominationReceivingLineClosedAndSealed = new(this, "x_IsNonNominationReceivingLineClosedAndSealed", 11, SqlDbType.Bit) {
                Name = "IsNonNominationReceivingLineClosedAndSealed",
                Expression = "[IsNonNominationReceivingLineClosedAndSealed]",
                BasicSearchExpression = "[IsNonNominationReceivingLineClosedAndSealed]",
                DateTimeFormat = -1,
                VirtualExpression = "[IsNonNominationReceivingLineClosedAndSealed]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = ["=", "<>"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "IsNonNominationReceivingLineClosedAndSealed", "CustomMsg"),
                IsUpload = false
            };
            IsNonNominationReceivingLineClosedAndSealed.Raw = true;
            IsNonNominationReceivingLineClosedAndSealed.Lookup = new Lookup<DbField>(IsNonNominationReceivingLineClosedAndSealed, "Aktivitas", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            IsNonNominationReceivingLineClosedAndSealed.UserValues = ["1"];
            Fields.Add("IsNonNominationReceivingLineClosedAndSealed", IsNonNominationReceivingLineClosedAndSealed);

            // IsTankEmptyAndDry
            IsTankEmptyAndDry = new(this, "x_IsTankEmptyAndDry", 11, SqlDbType.Bit) {
                Name = "IsTankEmptyAndDry",
                Expression = "[IsTankEmptyAndDry]",
                BasicSearchExpression = "[IsTankEmptyAndDry]",
                DateTimeFormat = -1,
                VirtualExpression = "[IsTankEmptyAndDry]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = ["=", "<>"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "IsTankEmptyAndDry", "CustomMsg"),
                IsUpload = false
            };
            IsTankEmptyAndDry.Raw = true;
            IsTankEmptyAndDry.Lookup = new Lookup<DbField>(IsTankEmptyAndDry, "Aktivitas", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            IsTankEmptyAndDry.UserValues = ["1"];
            Fields.Add("IsTankEmptyAndDry", IsTankEmptyAndDry);

            // IsDocumentationComplete
            IsDocumentationComplete = new(this, "x_IsDocumentationComplete", 11, SqlDbType.Bit) {
                Name = "IsDocumentationComplete",
                Expression = "[IsDocumentationComplete]",
                BasicSearchExpression = "[IsDocumentationComplete]",
                DateTimeFormat = -1,
                VirtualExpression = "[IsDocumentationComplete]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = ["=", "<>"],
                CustomMessage = Language.FieldPhrase("Aktivitas", "IsDocumentationComplete", "CustomMsg"),
                IsUpload = false
            };
            IsDocumentationComplete.Raw = true;
            IsDocumentationComplete.Lookup = new Lookup<DbField>(IsDocumentationComplete, "Aktivitas", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            IsDocumentationComplete.UserValues = ["1"];
            Fields.Add("IsDocumentationComplete", IsDocumentationComplete);

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

        // List of current detail table names
        public List<string> CurrentDetailTables => CurrentDetailTable.Split(',').ToList();

        // Get detail URL
        public string DetailUrl
        {
            get {
                string detailUrl = "";
                if (CurrentDetailTable == "AktivitasDokumen" && aktivitasDokumen != null) {
                    detailUrl = aktivitasDokumen.ListUrl + "?" + Config.TableShowMaster + "=" + TableVar;
                    detailUrl += "&" + ForeignKeyUrl("fk_IdAktivitas", IdAktivitas.CurrentValue);
                }
                if (Empty(detailUrl))
                    detailUrl = "AktivitasList";
                return detailUrl;
            }
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
            get => _sqlFrom ?? "dbo.Aktivitas";
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
                string select = "*, CASE WHEN TipeAktivitas = 'Dokumen' THEN '<a href=AktivitasDokumenList?showmaster=Aktivitas&fk_IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' WHEN TipeAktivitas = 'Form' AND TableAnak IS NOT NULL AND IdRefAnak IS NOT NULL THEN  '<a href=' + CAST(TableAnak AS NVARCHAR(255)) + 'Edit/' + CAST(IdRefAnak AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' WHEN TipeAktivitas = 'Tabel' THEN '<a href=AktivitasTabel?IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '>' + CAST(NamaAktivitas AS NVARCHAR(255)) + '</a>' ELSE CAST(NamaAktivitas AS NVARCHAR(255)) END AS [Aktivitas]";
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
                attr.Name == "IdAktivitas");
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
                attr.Name == "IdAktivitas");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Aktivita type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                if (row.ContainsKey("IdAktivitas"))
                    row["IdAktivitas"] = lastInsertedId;
                else
                    row.Add("IdAktivitas", lastInsertedId);
                IdAktivitas.SetDbValue(lastInsertedId);
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Aktivita type", "data");
            bool cascadeUpdate = false;
            DbDataReader? drwrk;
            int updateResult;
            Dictionary<string, object> rscascade = new();
            if (rsold != null) {
            }
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.Aktivita type", "data");
            List<Dictionary<string, object>>? dtlrows;
            if (row != null) {
            }
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
                IdAktivitas.DbValue = row["IdAktivitas"]; // Set DB value only
                No_Referensi.DbValue = row["No_Referensi"]; // Set DB value only
                IdProses.DbValue = row["IdProses"]; // Set DB value only
                IdTemplateAktivitas.DbValue = row["IdTemplateAktivitas"]; // Set DB value only
                Aktivitas2.DbValue = row["Aktivitas"]; // Set DB value only
                NamaAktivitas.DbValue = row["NamaAktivitas"]; // Set DB value only
                PIC.DbValue = row["PIC"]; // Set DB value only
                TanggalMulai.DbValue = row["TanggalMulai"]; // Set DB value only
                TanggalSelesai.DbValue = row["TanggalSelesai"]; // Set DB value only
                StatusAktivitas.DbValue = row["StatusAktivitas"]; // Set DB value only
                DibuatOleh.DbValue = row["DibuatOleh"]; // Set DB value only
                TanggalDibuat.DbValue = row["TanggalDibuat"]; // Set DB value only
                DiperbaruiOleh.DbValue = row["DiperbaruiOleh"]; // Set DB value only
                TanggalDiperbarui.DbValue = row["TanggalDiperbarui"]; // Set DB value only
                TipeAktivitas.DbValue = row["TipeAktivitas"]; // Set DB value only
                sandar_nama_kapal.DbValue = row["sandar_nama_kapal"]; // Set DB value only
                sandar_tgl_tiba.DbValue = row["sandar_tgl_tiba"]; // Set DB value only
                sandar_nominasi.DbValue = row["sandar_nominasi"]; // Set DB value only
                Produk.DbValue = row["Produk"]; // Set DB value only
                Shipment.DbValue = row["Shipment"]; // Set DB value only
                Nama_Proses.DbValue = row["Nama_Proses"]; // Set DB value only
                IdDokumen.DbValue = row["IdDokumen"]; // Set DB value only
                PathFile.DbValue = row["PathFile"]; // Set DB value only
                TanggalUploadDok.DbValue = row["TanggalUploadDok"]; // Set DB value only
                UserUploadDok.DbValue = row["UserUploadDok"]; // Set DB value only
                NamaDokumen.DbValue = row["NamaDokumen"]; // Set DB value only
                Keterangan.DbValue = row["Keterangan"]; // Set DB value only
                IdRefAnak.DbValue = row["IdRefAnak"]; // Set DB value only
                TableAnak.DbValue = row["TableAnak"]; // Set DB value only
                TipeProses.DbValue = row["TipeProses"]; // Set DB value only
                Urutan.DbValue = row["Urutan"]; // Set DB value only
                IsNominationTankReceivingLineOpen.DbValue = (ConvertToBool(row["IsNominationTankReceivingLineOpen"]) ? "1" : "0"); // Set DB value only
                IsNonNominationReceivingLineClosedAndSealed.DbValue = (ConvertToBool(row["IsNonNominationReceivingLineClosedAndSealed"]) ? "1" : "0"); // Set DB value only
                IsTankEmptyAndDry.DbValue = (ConvertToBool(row["IsTankEmptyAndDry"]) ? "1" : "0"); // Set DB value only
                IsDocumentationComplete.DbValue = (ConvertToBool(row["IsDocumentationComplete"]) ? "1" : "0"); // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[IdAktivitas] = @IdAktivitas@";

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
                    return "AktivitasList";
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
                "AktivitasView" => Language.Phrase("View"),
                "AktivitasEdit" => Language.Phrase("Edit"),
                "AktivitasAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "AktivitasList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "AktivitasView",
                Config.ApiAddAction => "AktivitasAdd",
                Config.ApiEditAction => "AktivitasEdit",
                Config.ApiDeleteAction => "AktivitasDelete",
                Config.ApiListAction => "AktivitasList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "AktivitasView",
                Config.ApiAddAction => "AktivitasAdd",
                Config.ApiEditAction => "AktivitasEdit",
                Config.ApiDeleteAction => "AktivitasDelete",
                Config.ApiListAction => "AktivitasList",
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
        public string ListUrl => "AktivitasList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("AktivitasView", parm);
            else
                url = KeyUrl("AktivitasView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "AktivitasAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "AktivitasAdd?" + parm;
            else
                url = "AktivitasAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("AktivitasEdit", parm);
            else
                url = KeyUrl("AktivitasEdit", Config.TableShowDetail + "=");
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("AktivitasList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("AktivitasAdd", parm);
            else
                url = KeyUrl("AktivitasAdd", Config.TableShowDetail + "=");
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("AktivitasList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("AktivitasDelete", parm)); // DN
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
            json += "\"IdAktivitas\":" + ConvertToJson(IdAktivitas.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL // DN
        public string KeyUrl(string url, string parm = "")
        {
            if (!IsNull(IdAktivitas.CurrentValue)) {
                url += "/" + IdAktivitas.CurrentValue;
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
                if (RouteValues.TryGetValue("IdAktivitas", out object? v0)) { // IdAktivitas // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("IdAktivitas");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (KeyFields.Count > 1 && (!IsArray(keys) || keys.Length != KeyFields.Count))
                    continue;
                if (!IsNumeric(keys)) // IdAktivitas
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
                    IdAktivitas.CurrentValue = keys;
                else
                    IdAktivitas.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        // Load row values from recordset
        public void LoadListRowValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
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
            IsNominationTankReceivingLineOpen.SetDbValue(ConvertToBool(row["IsNominationTankReceivingLineOpen"]) ? "1" : "0");
            IsNonNominationReceivingLineClosedAndSealed.SetDbValue(ConvertToBool(row["IsNonNominationReceivingLineClosedAndSealed"]) ? "1" : "0");
            IsTankEmptyAndDry.SetDbValue(ConvertToBool(row["IsTankEmptyAndDry"]) ? "1" : "0");
            IsDocumentationComplete.SetDbValue(ConvertToBool(row["IsDocumentationComplete"]) ? "1" : "0");
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "AktivitasList";
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

            // IdAktivitas

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
            TableAnak.CellCssStyle = "min-width: 15vw;";

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
            string curVal = ConvertToString(IdProses.CurrentValue);
            if (!Empty(curVal)) {
                if (IdProses.Lookup != null && IsDictionary(IdProses.Lookup?.Options) && IdProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdProses.ViewValue = IdProses.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    string filterWrk = SearchFilter(IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", IdProses.CurrentValue, IdProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                    string? sqlWrk = IdProses.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && IdProses.Lookup != null) { // Lookup values found
                        var listwrk = IdProses.Lookup?.RenderViewRow(rswrk[0]);
                        IdProses.ViewValue = IdProses.DisplayValue(listwrk);
                    } else {
                        IdProses.ViewValue = FormatNumber(IdProses.CurrentValue, IdProses.FormatPattern);
                    }
                }
            } else {
                IdProses.ViewValue = DbNullValue;
            }
            IdProses.ViewCustomAttributes = "";

            // IdTemplateAktivitas
            string curVal2 = ConvertToString(IdTemplateAktivitas.CurrentValue);
            if (!Empty(curVal2)) {
                if (IdTemplateAktivitas.Lookup != null && IsDictionary(IdTemplateAktivitas.Lookup?.Options) && IdTemplateAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdTemplateAktivitas.ViewValue = IdTemplateAktivitas.LookupCacheOption(curVal2);
                } else { // Lookup from database // DN
                    string filterWrk2 = SearchFilter(IdTemplateAktivitas.Lookup?.GetTable()?.Fields["IdTemplateAktivitas"].SearchExpression, "=", IdTemplateAktivitas.CurrentValue, IdTemplateAktivitas.Lookup?.GetTable()?.Fields["IdTemplateAktivitas"].SearchDataType, "");
                    string? sqlWrk2 = IdTemplateAktivitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk2?.Count > 0 && IdTemplateAktivitas.Lookup != null) { // Lookup values found
                        var listwrk = IdTemplateAktivitas.Lookup?.RenderViewRow(rswrk2[0]);
                        IdTemplateAktivitas.ViewValue = IdTemplateAktivitas.DisplayValue(listwrk);
                    } else {
                        IdTemplateAktivitas.ViewValue = FormatNumber(IdTemplateAktivitas.CurrentValue, IdTemplateAktivitas.FormatPattern);
                    }
                }
            } else {
                IdTemplateAktivitas.ViewValue = DbNullValue;
            }
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

            // IdAktivitas
            IdAktivitas.HrefValue = "";
            IdAktivitas.TooltipValue = "";

            // No_Referensi
            No_Referensi.HrefValue = "";
            No_Referensi.TooltipValue = "";

            // IdProses
            IdProses.HrefValue = "";
            IdProses.TooltipValue = "";

            // IdTemplateAktivitas
            IdTemplateAktivitas.HrefValue = "";
            IdTemplateAktivitas.TooltipValue = "";

            // Aktivitas
            Aktivitas2.HrefValue = "";
            Aktivitas2.TooltipValue = "";

            // NamaAktivitas
            NamaAktivitas.HrefValue = "";
            NamaAktivitas.TooltipValue = "";

            // PIC
            PIC.HrefValue = "";
            PIC.TooltipValue = "";

            // TanggalMulai
            TanggalMulai.HrefValue = "";
            TanggalMulai.TooltipValue = "";

            // TanggalSelesai
            TanggalSelesai.HrefValue = "";
            TanggalSelesai.TooltipValue = "";

            // StatusAktivitas
            StatusAktivitas.HrefValue = "";
            StatusAktivitas.TooltipValue = "";

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

            // TipeAktivitas
            TipeAktivitas.HrefValue = "";
            TipeAktivitas.TooltipValue = "";

            // sandar_nama_kapal
            sandar_nama_kapal.HrefValue = "";
            sandar_nama_kapal.TooltipValue = "";

            // sandar_tgl_tiba
            sandar_tgl_tiba.HrefValue = "";
            sandar_tgl_tiba.TooltipValue = "";

            // sandar_nominasi
            sandar_nominasi.HrefValue = "";
            sandar_nominasi.TooltipValue = "";

            // Produk
            Produk.HrefValue = "";
            Produk.TooltipValue = "";

            // Shipment
            Shipment.HrefValue = "";
            Shipment.TooltipValue = "";

            // Nama_Proses
            Nama_Proses.HrefValue = "";
            Nama_Proses.TooltipValue = "";

            // IdDokumen
            IdDokumen.HrefValue = "";
            IdDokumen.TooltipValue = "";

            // PathFile
            PathFile.HrefValue = "";
            PathFile.TooltipValue = "";

            // TanggalUploadDok
            TanggalUploadDok.HrefValue = "";
            TanggalUploadDok.TooltipValue = "";

            // UserUploadDok
            UserUploadDok.HrefValue = "";
            UserUploadDok.TooltipValue = "";

            // NamaDokumen
            NamaDokumen.HrefValue = "";
            NamaDokumen.TooltipValue = "";

            // Keterangan
            Keterangan.HrefValue = "";
            Keterangan.TooltipValue = "";

            // IdRefAnak
            IdRefAnak.HrefValue = "";
            IdRefAnak.TooltipValue = "";

            // TableAnak
            TableAnak.HrefValue = "";
            TableAnak.TooltipValue = "";

            // TipeProses
            TipeProses.HrefValue = "";
            TipeProses.TooltipValue = "";

            // Urutan
            Urutan.HrefValue = "";
            Urutan.TooltipValue = "";

            // IsNominationTankReceivingLineOpen
            IsNominationTankReceivingLineOpen.HrefValue = "";
            IsNominationTankReceivingLineOpen.TooltipValue = "";

            // IsNonNominationReceivingLineClosedAndSealed
            IsNonNominationReceivingLineClosedAndSealed.HrefValue = "";
            IsNonNominationReceivingLineClosedAndSealed.TooltipValue = "";

            // IsTankEmptyAndDry
            IsTankEmptyAndDry.HrefValue = "";
            IsTankEmptyAndDry.TooltipValue = "";

            // IsDocumentationComplete
            IsDocumentationComplete.HrefValue = "";
            IsDocumentationComplete.TooltipValue = "";

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

            // IdAktivitas
            IdAktivitas.SetupEditAttributes();
            IdAktivitas.EditValue = IdAktivitas.CurrentValue;
            IdAktivitas.ViewCustomAttributes = "";

            // No_Referensi
            No_Referensi.SetupEditAttributes();
            if (!No_Referensi.Raw)
                No_Referensi.CurrentValue = HtmlDecode(No_Referensi.CurrentValue);
            No_Referensi.EditValue = No_Referensi.CurrentValue;
            No_Referensi.PlaceHolder = RemoveHtml(No_Referensi.Caption);

            // IdProses
            IdProses.SetupEditAttributes();
            IdProses.PlaceHolder = RemoveHtml(IdProses.Caption);
            if (!Empty(IdProses.EditValue) && IsNumeric(IdProses.EditValue))
                IdProses.EditValue = FormatNumber(IdProses.EditValue, null);

            // IdTemplateAktivitas
            IdTemplateAktivitas.SetupEditAttributes();
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
            NamaAktivitas.EditValue = NamaAktivitas.CurrentValue;
            NamaAktivitas.PlaceHolder = RemoveHtml(NamaAktivitas.Caption);

            // PIC
            PIC.SetupEditAttributes();
            if (!PIC.Raw)
                PIC.CurrentValue = HtmlDecode(PIC.CurrentValue);
            PIC.EditValue = PIC.CurrentValue;
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
            StatusAktivitas.EditValue = StatusAktivitas.CurrentValue;
            StatusAktivitas.PlaceHolder = RemoveHtml(StatusAktivitas.Caption);

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

            // TanggalDiperbarui

            // TipeAktivitas
            TipeAktivitas.SetupEditAttributes();
            TipeAktivitas.EditValue = TipeAktivitas.Options(true);
            TipeAktivitas.PlaceHolder = RemoveHtml(TipeAktivitas.Caption);

            // sandar_nama_kapal
            sandar_nama_kapal.SetupEditAttributes();
            if (!sandar_nama_kapal.Raw)
                sandar_nama_kapal.CurrentValue = HtmlDecode(sandar_nama_kapal.CurrentValue);
            sandar_nama_kapal.EditValue = sandar_nama_kapal.CurrentValue;
            sandar_nama_kapal.PlaceHolder = RemoveHtml(sandar_nama_kapal.Caption);

            // sandar_tgl_tiba
            sandar_tgl_tiba.SetupEditAttributes();
            sandar_tgl_tiba.EditValue = FormatDateTime(sandar_tgl_tiba.CurrentValue, sandar_tgl_tiba.FormatPattern);
            sandar_tgl_tiba.PlaceHolder = RemoveHtml(sandar_tgl_tiba.Caption);

            // sandar_nominasi
            sandar_nominasi.SetupEditAttributes();
            if (!sandar_nominasi.Raw)
                sandar_nominasi.CurrentValue = HtmlDecode(sandar_nominasi.CurrentValue);
            sandar_nominasi.EditValue = sandar_nominasi.CurrentValue;
            sandar_nominasi.PlaceHolder = RemoveHtml(sandar_nominasi.Caption);

            // Produk
            Produk.SetupEditAttributes();
            if (!Produk.Raw)
                Produk.CurrentValue = HtmlDecode(Produk.CurrentValue);
            Produk.EditValue = Produk.CurrentValue;
            Produk.PlaceHolder = RemoveHtml(Produk.Caption);

            // Shipment
            Shipment.SetupEditAttributes();
            if (!Shipment.Raw)
                Shipment.CurrentValue = HtmlDecode(Shipment.CurrentValue);
            Shipment.EditValue = Shipment.CurrentValue;
            Shipment.PlaceHolder = RemoveHtml(Shipment.Caption);

            // Nama_Proses
            Nama_Proses.SetupEditAttributes();
            if (!Nama_Proses.Raw)
                Nama_Proses.CurrentValue = HtmlDecode(Nama_Proses.CurrentValue);
            Nama_Proses.EditValue = Nama_Proses.CurrentValue;
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
            PathFile.EditValue = PathFile.CurrentValue;
            PathFile.PlaceHolder = RemoveHtml(PathFile.Caption);

            // TanggalUploadDok
            TanggalUploadDok.SetupEditAttributes();
            TanggalUploadDok.EditValue = FormatDateTime(TanggalUploadDok.CurrentValue, TanggalUploadDok.FormatPattern);
            TanggalUploadDok.PlaceHolder = RemoveHtml(TanggalUploadDok.Caption);

            // UserUploadDok
            UserUploadDok.SetupEditAttributes();
            if (!UserUploadDok.Raw)
                UserUploadDok.CurrentValue = HtmlDecode(UserUploadDok.CurrentValue);
            UserUploadDok.EditValue = UserUploadDok.CurrentValue;
            UserUploadDok.PlaceHolder = RemoveHtml(UserUploadDok.Caption);

            // NamaDokumen
            NamaDokumen.SetupEditAttributes();
            if (!NamaDokumen.Raw)
                NamaDokumen.CurrentValue = HtmlDecode(NamaDokumen.CurrentValue);
            NamaDokumen.EditValue = NamaDokumen.CurrentValue;
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
            TableAnak.EditValue = TableAnak.CurrentValue;
            TableAnak.PlaceHolder = RemoveHtml(TableAnak.Caption);

            // TipeProses
            TipeProses.SetupEditAttributes();
            if (!TipeProses.Raw)
                TipeProses.CurrentValue = HtmlDecode(TipeProses.CurrentValue);
            TipeProses.EditValue = TipeProses.CurrentValue;
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
                        doc.ExportCaption(No_Referensi);
                        doc.ExportCaption(IdProses);
                        doc.ExportCaption(IdTemplateAktivitas);
                        doc.ExportCaption(Aktivitas2);
                        doc.ExportCaption(NamaAktivitas);
                        doc.ExportCaption(PIC);
                        doc.ExportCaption(TanggalMulai);
                        doc.ExportCaption(TanggalSelesai);
                        doc.ExportCaption(StatusAktivitas);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
                        doc.ExportCaption(TipeAktivitas);
                        doc.ExportCaption(sandar_nama_kapal);
                        doc.ExportCaption(sandar_tgl_tiba);
                        doc.ExportCaption(sandar_nominasi);
                        doc.ExportCaption(Produk);
                        doc.ExportCaption(Shipment);
                        doc.ExportCaption(Nama_Proses);
                        doc.ExportCaption(IdDokumen);
                        doc.ExportCaption(PathFile);
                        doc.ExportCaption(TanggalUploadDok);
                        doc.ExportCaption(UserUploadDok);
                        doc.ExportCaption(NamaDokumen);
                        doc.ExportCaption(Keterangan);
                        doc.ExportCaption(IdRefAnak);
                        doc.ExportCaption(TableAnak);
                        doc.ExportCaption(TipeProses);
                        doc.ExportCaption(Urutan);
                        doc.ExportCaption(IsNominationTankReceivingLineOpen);
                        doc.ExportCaption(IsNonNominationReceivingLineClosedAndSealed);
                        doc.ExportCaption(IsTankEmptyAndDry);
                        doc.ExportCaption(IsDocumentationComplete);
                    } else {
                        doc.ExportCaption(IdAktivitas);
                        doc.ExportCaption(No_Referensi);
                        doc.ExportCaption(IdProses);
                        doc.ExportCaption(IdTemplateAktivitas);
                        doc.ExportCaption(NamaAktivitas);
                        doc.ExportCaption(PIC);
                        doc.ExportCaption(TanggalMulai);
                        doc.ExportCaption(TanggalSelesai);
                        doc.ExportCaption(StatusAktivitas);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
                        doc.ExportCaption(TipeAktivitas);
                        doc.ExportCaption(sandar_nama_kapal);
                        doc.ExportCaption(sandar_tgl_tiba);
                        doc.ExportCaption(sandar_nominasi);
                        doc.ExportCaption(Produk);
                        doc.ExportCaption(Shipment);
                        doc.ExportCaption(Nama_Proses);
                        doc.ExportCaption(IdDokumen);
                        doc.ExportCaption(PathFile);
                        doc.ExportCaption(TanggalUploadDok);
                        doc.ExportCaption(UserUploadDok);
                        doc.ExportCaption(NamaDokumen);
                        doc.ExportCaption(IdRefAnak);
                        doc.ExportCaption(TableAnak);
                        doc.ExportCaption(TipeProses);
                        doc.ExportCaption(Urutan);
                        doc.ExportCaption(IsNominationTankReceivingLineOpen);
                        doc.ExportCaption(IsNonNominationReceivingLineClosedAndSealed);
                        doc.ExportCaption(IsTankEmptyAndDry);
                        doc.ExportCaption(IsDocumentationComplete);
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
                            await doc.ExportField(No_Referensi);
                            await doc.ExportField(IdProses);
                            await doc.ExportField(IdTemplateAktivitas);
                            await doc.ExportField(Aktivitas2);
                            await doc.ExportField(NamaAktivitas);
                            await doc.ExportField(PIC);
                            await doc.ExportField(TanggalMulai);
                            await doc.ExportField(TanggalSelesai);
                            await doc.ExportField(StatusAktivitas);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
                            await doc.ExportField(TipeAktivitas);
                            await doc.ExportField(sandar_nama_kapal);
                            await doc.ExportField(sandar_tgl_tiba);
                            await doc.ExportField(sandar_nominasi);
                            await doc.ExportField(Produk);
                            await doc.ExportField(Shipment);
                            await doc.ExportField(Nama_Proses);
                            await doc.ExportField(IdDokumen);
                            await doc.ExportField(PathFile);
                            await doc.ExportField(TanggalUploadDok);
                            await doc.ExportField(UserUploadDok);
                            await doc.ExportField(NamaDokumen);
                            await doc.ExportField(Keterangan);
                            await doc.ExportField(IdRefAnak);
                            await doc.ExportField(TableAnak);
                            await doc.ExportField(TipeProses);
                            await doc.ExportField(Urutan);
                            await doc.ExportField(IsNominationTankReceivingLineOpen);
                            await doc.ExportField(IsNonNominationReceivingLineClosedAndSealed);
                            await doc.ExportField(IsTankEmptyAndDry);
                            await doc.ExportField(IsDocumentationComplete);
                        } else {
                            await doc.ExportField(IdAktivitas);
                            await doc.ExportField(No_Referensi);
                            await doc.ExportField(IdProses);
                            await doc.ExportField(IdTemplateAktivitas);
                            await doc.ExportField(NamaAktivitas);
                            await doc.ExportField(PIC);
                            await doc.ExportField(TanggalMulai);
                            await doc.ExportField(TanggalSelesai);
                            await doc.ExportField(StatusAktivitas);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
                            await doc.ExportField(TipeAktivitas);
                            await doc.ExportField(sandar_nama_kapal);
                            await doc.ExportField(sandar_tgl_tiba);
                            await doc.ExportField(sandar_nominasi);
                            await doc.ExportField(Produk);
                            await doc.ExportField(Shipment);
                            await doc.ExportField(Nama_Proses);
                            await doc.ExportField(IdDokumen);
                            await doc.ExportField(PathFile);
                            await doc.ExportField(TanggalUploadDok);
                            await doc.ExportField(UserUploadDok);
                            await doc.ExportField(NamaDokumen);
                            await doc.ExportField(IdRefAnak);
                            await doc.ExportField(TableAnak);
                            await doc.ExportField(TipeProses);
                            await doc.ExportField(Urutan);
                            await doc.ExportField(IsNominationTankReceivingLineOpen);
                            await doc.ExportField(IsNonNominationReceivingLineClosedAndSealed);
                            await doc.ExportField(IsTankEmptyAndDry);
                            await doc.ExportField(IsDocumentationComplete);
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
            rsnew["DibuatOleh"] = CurrentUserName();
            rsnew["TanggalDibuat"] = DateTime.Now;
            rsnew["DiperbaruiOleh"] = CurrentUserName();
            rsnew["TanggalDiperbarui"] = DateTime.Now;
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
            rsnew["DiperbaruiOleh"] = CurrentUserName();
            rsnew["TanggalDiperbarui"] = DateTime.Now;
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
            String sqlData = "SELECT PathFile FROM AktivitasDokumen WHERE IdAktivitas = @IdAktivitas;";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection()) {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", rs["IdAktivitas"] );
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dokumenLama = reader["PathFile"].ToString();
                            if (!string.IsNullOrEmpty(dokumenLama)) {
                                string filePath = Path.Combine(Configuration["UploadPathActivityDocument"] ?? "wwwroot/Uploads/Activity Document", dokumenLama);
                                if (File.Exists(filePath)) {
                                    try {
                                        File.Delete(filePath);
                                    } catch (Exception ex) {
                                        Console.WriteLine(ex);
                                    }
                                }
                            }
                        }
                    }
                }
                sqlData = "DELETE FROM AktivitasDokumen WHERE idAktivitas = @IdAktivitas;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", rs["IdAktivitas"]);
                    sqlCommand.ExecuteNonQuery();
                }
            }
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
