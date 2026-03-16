namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// aktivitasDokumen
    /// </summary>
    [MaybeNull]
    public static AktivitasDokumen aktivitasDokumen
    {
        get => HttpData.Resolve<AktivitasDokumen>("AktivitasDokumen");
        set => HttpData["AktivitasDokumen"] = value;
    }

    /// <summary>
    /// Table class for AktivitasDokumen
    /// </summary>
    public class AktivitasDokumen : DbTable
    {
        public override Dictionary<string, string> KeyFields { get; set; } = new() { // DN
            { "IdAktivitasDokumen", "IdAktivitasDokumen" },
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

        public bool ModalGridEdit = true;

        public bool ModalMultiEdit = false;

        public readonly DbField<SqlDbType> IdAktivitasDokumen;

        public readonly DbField<SqlDbType> NoReferensi;

        public readonly DbField<SqlDbType> IdProses;

        public readonly DbField<SqlDbType> IdAktivitas;

        public readonly DbField<SqlDbType> IdDokumen;

        public readonly DbField<SqlDbType> NamaDokumen;

        public readonly DbField<SqlDbType> TemplateDokumen;

        public readonly DbField<SqlDbType> UploadDokumen;

        public readonly DbField<SqlDbType> DownloadDokumen;

        public readonly DbField<SqlDbType> Keterangan;

        public readonly DbField<SqlDbType> PathFile;

        public readonly DbField<SqlDbType> StatusUpload;

        public readonly DbField<SqlDbType> DiunggahOleh;

        public readonly DbField<SqlDbType> TanggalUpload;

        public readonly DbField<SqlDbType> DiperbaruiOleh;

        public readonly DbField<SqlDbType> TanggalDiperbarui;

        public readonly DbField<SqlDbType> IdTemplateAktivitasDokumen;

        public readonly DbField<SqlDbType> WajibUpload;

        public readonly DbField<SqlDbType> TipeProses;

        // Constructor
        public AktivitasDokumen()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "AktivitasDokumen";
            Name = "AktivitasDokumen";
            Type = "TABLE";
            UpdateTable = "dbo.AktivitasDokumen"; // Update Table
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
            UseColumnVisibility = true;
            UserIdAllowSecurity = Config.DefaultUserIdAllowSecurity; // User ID Allow

            // IdAktivitasDokumen
            IdAktivitasDokumen = new(this, "x_IdAktivitasDokumen", 3, SqlDbType.Int) {
                Name = "IdAktivitasDokumen",
                Expression = "[IdAktivitasDokumen]",
                BasicSearchExpression = "CAST([IdAktivitasDokumen] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdAktivitasDokumen]",
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "IdAktivitasDokumen", "CustomMsg"),
                IsUpload = false
            };
            IdAktivitasDokumen.Raw = true;
            Fields.Add("IdAktivitasDokumen", IdAktivitasDokumen);

            // NoReferensi
            NoReferensi = new(this, "x_NoReferensi", 200, SqlDbType.VarChar) {
                Name = "NoReferensi",
                Expression = "[NoReferensi]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NoReferensi]",
                DateTimeFormat = -1,
                VirtualExpression = "[NoReferensi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "NoReferensi", "CustomMsg"),
                IsUpload = false
            };
            NoReferensi.Lookup = new Lookup<DbField>(NoReferensi, "AktivitasDokumen", true, "NoReferensi", new List<string> {"NoReferensi", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NoReferensi", NoReferensi);

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
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "IdProses", "CustomMsg"),
                IsUpload = false
            };
            IdProses.Raw = true;
            IdProses.Lookup = new Lookup<DbField>(IdProses, "Proses", true, "IdProses", new List<string> {"NamaProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaProses]");
            Fields.Add("IdProses", IdProses);

            // IdAktivitas
            IdAktivitas = new(this, "x_IdAktivitas", 3, SqlDbType.Int) {
                Name = "IdAktivitas",
                Expression = "[IdAktivitas]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([IdAktivitas] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdAktivitas]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                IsForeignKey = true, // Foreign key field
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "IdAktivitas", "CustomMsg"),
                IsUpload = false
            };
            IdAktivitas.Raw = true;
            IdAktivitas.Lookup = new Lookup<DbField>(IdAktivitas, "Aktivitas", true, "IdAktivitas", new List<string> {"NamaAktivitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaAktivitas]");
            Fields.Add("IdAktivitas", IdAktivitas);

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
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "IdDokumen", "CustomMsg"),
                IsUpload = false
            };
            IdDokumen.Raw = true;
            IdDokumen.Lookup = new Lookup<DbField>(IdDokumen, "MasterDokumen", true, "IdDokumen", new List<string> {"NamaDokumen", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaDokumen]");
            Fields.Add("IdDokumen", IdDokumen);

            // NamaDokumen
            NamaDokumen = new(this, "x_NamaDokumen", 203, SqlDbType.NText) {
                Name = "NamaDokumen",
                Expression = "[NamaDokumen]",
                UseBasicSearch = true,
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
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "NamaDokumen", "CustomMsg"),
                IsUpload = false
            };
            NamaDokumen.Lookup = new Lookup<DbField>(NamaDokumen, "AktivitasDokumen", true, "NamaDokumen", new List<string> {"NamaDokumen", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NamaDokumen", NamaDokumen);

            // TemplateDokumen
            TemplateDokumen = new(this, "x_TemplateDokumen", 202, SqlDbType.NVarChar) {
                Name = "TemplateDokumen",
                Expression = "'<a class=' + CHAR(34) + 'download-template btn btn-primary' + CHAR(34) + ' href=TemplateDokumen?IdDokumen=' + CAST(IdDokumen AS NVARCHAR(20)) + '>Download Template</a>'",
                BasicSearchExpression = "'<a class=' + CHAR(34) + 'download-template btn btn-primary' + CHAR(34) + ' href=TemplateDokumen?IdDokumen=' + CAST(IdDokumen AS NVARCHAR(20)) + '>Download Template</a>'",
                DateTimeFormat = -1,
                VirtualExpression = "'<a class=' + CHAR(34) + 'download-template btn btn-primary' + CHAR(34) + ' href=TemplateDokumen?IdDokumen=' + CAST(IdDokumen AS NVARCHAR(20)) + '>Download Template</a>'",
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "TemplateDokumen", "CustomMsg"),
                IsUpload = false
            };
            TemplateDokumen.Lookup = new Lookup<DbField>(TemplateDokumen, "AktivitasDokumen", true, "TemplateDokumen", new List<string> {"TemplateDokumen", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TemplateDokumen", TemplateDokumen);

            // UploadDokumen
            UploadDokumen = new(this, "x_UploadDokumen", 203, SqlDbType.NText) {
                Name = "UploadDokumen",
                Expression = "CASE WHEN WajibUpload = 1 THEN '<button class=' + CHAR(34) + 'upload-document btn btn-primary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '  NamaDokumen='+ CHAR(34) + CAST(NamaDokumen AS NVARCHAR(255)) + CHAR(34) + '><i class=' + CHAR(34) + 'fa-solid fa-upload me-2' + CHAR(34) + '></i> Upload Document</button>' WHEN WajibUpload = 0 THEN  '<button class=' + CHAR(34) + 'upload-document btn btn-secondary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '  NamaDokumen='+ CHAR(34) + CAST(NamaDokumen AS NVARCHAR(255)) + CHAR(34) + '><i class=' + CHAR(34) + 'fa-solid fa-upload me-2' + CHAR(34) + '></i> Upload Document</button>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN WajibUpload = 1 THEN '<button class=' + CHAR(34) + 'upload-document btn btn-primary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '  NamaDokumen='+ CHAR(34) + CAST(NamaDokumen AS NVARCHAR(255)) + CHAR(34) + '><i class=' + CHAR(34) + 'fa-solid fa-upload me-2' + CHAR(34) + '></i> Upload Document</button>' WHEN WajibUpload = 0 THEN  '<button class=' + CHAR(34) + 'upload-document btn btn-secondary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '  NamaDokumen='+ CHAR(34) + CAST(NamaDokumen AS NVARCHAR(255)) + CHAR(34) + '><i class=' + CHAR(34) + 'fa-solid fa-upload me-2' + CHAR(34) + '></i> Upload Document</button>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN WajibUpload = 1 THEN '<button class=' + CHAR(34) + 'upload-document btn btn-primary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '  NamaDokumen='+ CHAR(34) + CAST(NamaDokumen AS NVARCHAR(255)) + CHAR(34) + '><i class=' + CHAR(34) + 'fa-solid fa-upload me-2' + CHAR(34) + '></i> Upload Document</button>' WHEN WajibUpload = 0 THEN  '<button class=' + CHAR(34) + 'upload-document btn btn-secondary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '  NamaDokumen='+ CHAR(34) + CAST(NamaDokumen AS NVARCHAR(255)) + CHAR(34) + '><i class=' + CHAR(34) + 'fa-solid fa-upload me-2' + CHAR(34) + '></i> Upload Document</button>' END",
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "UploadDokumen", "CustomMsg"),
                IsUpload = false
            };
            UploadDokumen.Lookup = new Lookup<DbField>(UploadDokumen, "AktivitasDokumen", true, "UploadDokumen", new List<string> {"UploadDokumen", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("UploadDokumen", UploadDokumen);

            // DownloadDokumen
            DownloadDokumen = new(this, "x_DownloadDokumen", 203, SqlDbType.NText) {
                Name = "DownloadDokumen",
                Expression = "CASE WHEN StatusUpload = 'Uploaded' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) +  ' IdDokumen = ' + CAST(IdDokumen AS NVARCHAR(255)) + ' WajibUpload = '+ CAST(WajibUpload AS NVARCHAR(20)) +'><i class='+CHAR(34) + 'fas fa-download me-2' + CHAR(34)+'></i> Download Document</a>' ELSE '<p class='+CHAR(34)+'not-uploaded m-0' +CHAR(34)+ ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdDokumen = ' + CAST(IdDokumen AS NVARCHAR(255)) +  ' WajibUpload = '+ CAST(WajibUpload AS NVARCHAR(20)) +'>Not Uploaded</p>' END",
                UseBasicSearch = true,
                BasicSearchExpression = "CASE WHEN StatusUpload = 'Uploaded' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) +  ' IdDokumen = ' + CAST(IdDokumen AS NVARCHAR(255)) + ' WajibUpload = '+ CAST(WajibUpload AS NVARCHAR(20)) +'><i class='+CHAR(34) + 'fas fa-download me-2' + CHAR(34)+'></i> Download Document</a>' ELSE '<p class='+CHAR(34)+'not-uploaded m-0' +CHAR(34)+ ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdDokumen = ' + CAST(IdDokumen AS NVARCHAR(255)) +  ' WajibUpload = '+ CAST(WajibUpload AS NVARCHAR(20)) +'>Not Uploaded</p>' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN StatusUpload = 'Uploaded' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) +  ' IdDokumen = ' + CAST(IdDokumen AS NVARCHAR(255)) + ' WajibUpload = '+ CAST(WajibUpload AS NVARCHAR(20)) +'><i class='+CHAR(34) + 'fas fa-download me-2' + CHAR(34)+'></i> Download Document</a>' ELSE '<p class='+CHAR(34)+'not-uploaded m-0' +CHAR(34)+ ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdDokumen = ' + CAST(IdDokumen AS NVARCHAR(255)) +  ' WajibUpload = '+ CAST(WajibUpload AS NVARCHAR(20)) +'>Not Uploaded</p>' END",
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "DownloadDokumen", "CustomMsg"),
                IsUpload = false
            };
            DownloadDokumen.Lookup = new Lookup<DbField>(DownloadDokumen, "AktivitasDokumen", true, "DownloadDokumen", new List<string> {"DownloadDokumen", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("DownloadDokumen", DownloadDokumen);

            // Keterangan
            Keterangan = new(this, "x_Keterangan", 203, SqlDbType.NText) {
                Name = "Keterangan",
                Expression = "[Keterangan]",
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "Keterangan", "CustomMsg"),
                IsUpload = false
            };
            Keterangan.Lookup = new Lookup<DbField>(Keterangan, "AktivitasDokumen", true, "Keterangan", new List<string> {"Keterangan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Keterangan", Keterangan);

            // PathFile
            PathFile = new(this, "x_PathFile", 201, SqlDbType.Text) {
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
                HtmlTag = "FILE",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "PathFile", "CustomMsg"),
                IsUpload = true
            };
            PathFile.Lookup = new Lookup<DbField>(PathFile, "AktivitasDokumen", true, "PathFile", new List<string> {"PathFile", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            PathFile.GetUploadPath = () => (Configuration["UploadPathActivityDocument"] ?? "Uploads/Activity Document");
            Fields.Add("PathFile", PathFile);

            // StatusUpload
            StatusUpload = new(this, "x_StatusUpload", 200, SqlDbType.VarChar) {
                Name = "StatusUpload",
                Expression = "[StatusUpload]",
                BasicSearchExpression = "[StatusUpload]",
                DateTimeFormat = -1,
                VirtualExpression = "[StatusUpload]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "StatusUpload", "CustomMsg"),
                IsUpload = false
            };
            StatusUpload.Lookup = new Lookup<DbField>(StatusUpload, "AktivitasDokumen", true, "StatusUpload", new List<string> {"StatusUpload", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("StatusUpload", StatusUpload);

            // DiunggahOleh
            DiunggahOleh = new(this, "x_DiunggahOleh", 200, SqlDbType.VarChar) {
                Name = "DiunggahOleh",
                Expression = "[DiunggahOleh]",
                UseBasicSearch = true,
                BasicSearchExpression = "[DiunggahOleh]",
                DateTimeFormat = -1,
                VirtualExpression = "[DiunggahOleh]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "DiunggahOleh", "CustomMsg"),
                IsUpload = false
            };
            DiunggahOleh.Lookup = new Lookup<DbField>(DiunggahOleh, "AktivitasDokumen", true, "DiunggahOleh", new List<string> {"DiunggahOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("DiunggahOleh", DiunggahOleh);

            // TanggalUpload
            TanggalUpload = new(this, "x_TanggalUpload", 135, SqlDbType.DateTime) {
                Name = "TanggalUpload",
                Expression = "[TanggalUpload]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TanggalUpload]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[TanggalUpload]",
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "TanggalUpload", "CustomMsg"),
                IsUpload = false
            };
            TanggalUpload.Raw = true;
            TanggalUpload.Lookup = new Lookup<DbField>(TanggalUpload, "AktivitasDokumen", true, "TanggalUpload", new List<string> {"TanggalUpload", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalUpload", TanggalUpload);

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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "DiperbaruiOleh", "CustomMsg"),
                IsUpload = false
            };
            DiperbaruiOleh.Lookup = new Lookup<DbField>(DiperbaruiOleh, "AktivitasDokumen", true, "DiperbaruiOleh", new List<string> {"DiperbaruiOleh", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "TanggalDiperbarui", "CustomMsg"),
                IsUpload = false
            };
            TanggalDiperbarui.Raw = true;
            TanggalDiperbarui.Lookup = new Lookup<DbField>(TanggalDiperbarui, "AktivitasDokumen", true, "TanggalDiperbarui", new List<string> {"TanggalDiperbarui", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalDiperbarui", TanggalDiperbarui);

            // IdTemplateAktivitasDokumen
            IdTemplateAktivitasDokumen = new(this, "x_IdTemplateAktivitasDokumen", 3, SqlDbType.Int) {
                Name = "IdTemplateAktivitasDokumen",
                Expression = "[IdTemplateAktivitasDokumen]",
                BasicSearchExpression = "CAST([IdTemplateAktivitasDokumen] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[IdTemplateAktivitasDokumen]",
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "IdTemplateAktivitasDokumen", "CustomMsg"),
                IsUpload = false
            };
            IdTemplateAktivitasDokumen.Raw = true;
            IdTemplateAktivitasDokumen.Lookup = new Lookup<DbField>(IdTemplateAktivitasDokumen, "AktivitasDokumen", true, "IdTemplateAktivitasDokumen", new List<string> {"IdTemplateAktivitasDokumen", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("IdTemplateAktivitasDokumen", IdTemplateAktivitasDokumen);

            // WajibUpload
            WajibUpload = new(this, "x_WajibUpload", 11, SqlDbType.Bit) {
                Name = "WajibUpload",
                Expression = "[WajibUpload]",
                BasicSearchExpression = "[WajibUpload]",
                DateTimeFormat = -1,
                VirtualExpression = "[WajibUpload]",
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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "WajibUpload", "CustomMsg"),
                IsUpload = false
            };
            WajibUpload.Raw = true;
            WajibUpload.Lookup = new Lookup<DbField>(WajibUpload, "AktivitasDokumen", true, "WajibUpload", new List<string> {"WajibUpload", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            WajibUpload.UserValues = ["1"];
            Fields.Add("WajibUpload", WajibUpload);

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
                CustomMessage = Language.FieldPhrase("AktivitasDokumen", "TipeProses", "CustomMsg"),
                IsUpload = false
            };
            TipeProses.Lookup = new Lookup<DbField>(TipeProses, "AktivitasDokumen", true, "TipeProses", new List<string> {"TipeProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TipeProses", TipeProses);

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

        // Session master where clause
        public string MasterFilterFromSession
        {
            get { // Master filter
                string masterFilter = "";
            if (CurrentMasterTable == "Aktivitas") {
                dynamic masterTable = Resolve("Aktivitas")!;
                if (!Empty(IdAktivitas.SessionValue))
                    masterFilter += "" + KeyFilter(masterTable.IdAktivitas, IdAktivitas.SessionValue, masterTable.IdAktivitas.DataType, masterTable.DbId);
                else
                    return "";
            }
                return masterFilter;
            }
        }

        // Session detail WHERE clause
        public string DetailFilterFromSession
        {
            get { // Detail filter
                string detailFilter = "";
                if (CurrentMasterTable == "Aktivitas") {
                    dynamic masterTable = Resolve("Aktivitas")!;
                    if (!Empty(IdAktivitas.SessionValue))
                        detailFilter += "" + KeyFilter(IdAktivitas, IdAktivitas.SessionValue, masterTable.IdAktivitas.DataType, DbId);
                    else
                        return "";
                }
                return detailFilter;
            }
        }

        // Master filter // DN
        public string? MasterFilter(dynamic? masterTable, Dictionary<string, object?> keys) // DN
        {
            bool validKeys = true;
            object key = "";
            switch (masterTable?.TableVar) {
            case "Aktivitas":
                key = keys["IdAktivitas"] ?? "";
                if (Empty(key)) {
                    if (masterTable.IdAktivitas.Required) // Required field and empty value
                        return ""; // Return empty filter
                    validKeys = false;
                } else if (!validKeys) { // Already has empty key
                    return ""; // Return empty filter
                }
                if (validKeys) {
                    return KeyFilter(masterTable.IdAktivitas, keys["IdAktivitas"], IdAktivitas.DataType, DbId);
                }
                break;
            }
            return null; // All null values and no required fields
        }

        // Detail filter // DN
        public string DetailFilter(dynamic masterTable) // DN
        {
            return masterTable.TableVar switch {
                "Aktivitas" => KeyFilter(IdAktivitas, masterTable.IdAktivitas.DbValue, masterTable.IdAktivitas.DataType, masterTable.DbId),
                _ => ""
            };
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
            get => _sqlFrom ?? "dbo.AktivitasDokumen";
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
                string select = "*, '<a class=' + CHAR(34) + 'download-template btn btn-primary' + CHAR(34) + ' href=TemplateDokumen?IdDokumen=' + CAST(IdDokumen AS NVARCHAR(20)) + '>Download Template</a>' AS [TemplateDokumen], CASE WHEN WajibUpload = 1 THEN '<button class=' + CHAR(34) + 'upload-document btn btn-primary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '  NamaDokumen='+ CHAR(34) + CAST(NamaDokumen AS NVARCHAR(255)) + CHAR(34) + '><i class=' + CHAR(34) + 'fa-solid fa-upload me-2' + CHAR(34) + '></i> Upload Document</button>' WHEN WajibUpload = 0 THEN  '<button class=' + CHAR(34) + 'upload-document btn btn-secondary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdAktivitas=' + CAST(IdAktivitas AS NVARCHAR(255)) + '  NamaDokumen='+ CHAR(34) + CAST(NamaDokumen AS NVARCHAR(255)) + CHAR(34) + '><i class=' + CHAR(34) + 'fa-solid fa-upload me-2' + CHAR(34) + '></i> Upload Document</button>' END AS [UploadDokumen], CASE WHEN StatusUpload = 'Uploaded' THEN '<a class=' + CHAR(34) + 'download-document btn btn-primary' + CHAR(34) + ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) +  ' IdDokumen = ' + CAST(IdDokumen AS NVARCHAR(255)) + ' WajibUpload = '+ CAST(WajibUpload AS NVARCHAR(20)) +'><i class='+CHAR(34) + 'fas fa-download me-2' + CHAR(34)+'></i> Download Document</a>' ELSE '<p class='+CHAR(34)+'not-uploaded m-0' +CHAR(34)+ ' IdAktivitasDokumen=' + CAST(IdAktivitasDokumen AS NVARCHAR(255)) + ' IdDokumen = ' + CAST(IdDokumen AS NVARCHAR(255)) +  ' WajibUpload = '+ CAST(WajibUpload AS NVARCHAR(20)) +'>Not Uploaded</p>' END AS [DownloadDokumen]";
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
                attr.Name == "IdAktivitasDokumen");
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
                attr.Name == "IdAktivitasDokumen");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.AktivitasDokuman type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                if (row.ContainsKey("IdAktivitasDokumen"))
                    row["IdAktivitasDokumen"] = lastInsertedId;
                else
                    row.Add("IdAktivitasDokumen", lastInsertedId);
                IdAktivitasDokumen.SetDbValue(lastInsertedId);
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.AktivitasDokuman type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.AktivitasDokuman type", "data");
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
                IdAktivitasDokumen.DbValue = row["IdAktivitasDokumen"]; // Set DB value only
                NoReferensi.DbValue = row["NoReferensi"]; // Set DB value only
                IdProses.DbValue = row["IdProses"]; // Set DB value only
                IdAktivitas.DbValue = row["IdAktivitas"]; // Set DB value only
                IdDokumen.DbValue = row["IdDokumen"]; // Set DB value only
                NamaDokumen.DbValue = row["NamaDokumen"]; // Set DB value only
                TemplateDokumen.DbValue = row["TemplateDokumen"]; // Set DB value only
                UploadDokumen.DbValue = row["UploadDokumen"]; // Set DB value only
                DownloadDokumen.DbValue = row["DownloadDokumen"]; // Set DB value only
                Keterangan.DbValue = row["Keterangan"]; // Set DB value only
                PathFile.Upload.DbValue = row["PathFile"];
                StatusUpload.DbValue = row["StatusUpload"]; // Set DB value only
                DiunggahOleh.DbValue = row["DiunggahOleh"]; // Set DB value only
                TanggalUpload.DbValue = row["TanggalUpload"]; // Set DB value only
                DiperbaruiOleh.DbValue = row["DiperbaruiOleh"]; // Set DB value only
                TanggalDiperbarui.DbValue = row["TanggalDiperbarui"]; // Set DB value only
                IdTemplateAktivitasDokumen.DbValue = row["IdTemplateAktivitasDokumen"]; // Set DB value only
                WajibUpload.DbValue = (ConvertToBool(row["WajibUpload"]) ? "1" : "0"); // Set DB value only
                TipeProses.DbValue = row["TipeProses"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
            PathFile.OldUploadPath = PathFile.GetUploadPath();
            if (!Empty(row["PathFile"])) {
                DeleteFile(PathFile.OldPhysicalUploadPath + row["PathFile"]);
            }
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[IdAktivitasDokumen] = @IdAktivitasDokumen@";

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
                    return "AktivitasDokumenList";
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
                "AktivitasDokumenView" => Language.Phrase("View"),
                "AktivitasDokumenEdit" => Language.Phrase("Edit"),
                "AktivitasDokumenAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "AktivitasDokumenList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "AktivitasDokumenView",
                Config.ApiAddAction => "AktivitasDokumenAdd",
                Config.ApiEditAction => "AktivitasDokumenEdit",
                Config.ApiDeleteAction => "AktivitasDokumenDelete",
                Config.ApiListAction => "AktivitasDokumenList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "AktivitasDokumenView",
                Config.ApiAddAction => "AktivitasDokumenAdd",
                Config.ApiEditAction => "AktivitasDokumenEdit",
                Config.ApiDeleteAction => "AktivitasDokumenDelete",
                Config.ApiListAction => "AktivitasDokumenList",
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
        public string ListUrl => "AktivitasDokumenList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("AktivitasDokumenView", parm);
            else
                url = KeyUrl("AktivitasDokumenView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "AktivitasDokumenAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "AktivitasDokumenAdd?" + parm;
            else
                url = "AktivitasDokumenAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("AktivitasDokumenEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("AktivitasDokumenList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("AktivitasDokumenAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("AktivitasDokumenList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("AktivitasDokumenDelete", parm)); // DN
        }

        // Delete URL
        public string DeleteUrl => GetDeleteUrl();

        // Add master URL
        public string AddMasterUrl(string url)
        {
            if (CurrentMasterTable == "Aktivitas" && !url.Contains(Config.TableShowMaster + "=")) {
                url += (url.Contains("?") ? "&" : "?") + Config.TableShowMaster + "=" + CurrentMasterTable;
                url += "&" + ForeignKeyUrl("fk_IdAktivitas", IdAktivitas.SessionValue); // Use Session Value
            }
            return url;
        }

        // Get primary key as JSON
        public string KeyToJson(bool htmlEncode = false)
        {
            string json = "";
            json += "\"IdAktivitasDokumen\":" + ConvertToJson(IdAktivitasDokumen.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL // DN
        public string KeyUrl(string url, string parm = "")
        {
            if (!IsNull(IdAktivitasDokumen.CurrentValue)) {
                url += "/" + IdAktivitasDokumen.CurrentValue;
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
                if (RouteValues.TryGetValue("IdAktivitasDokumen", out object? v0)) { // IdAktivitasDokumen // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("IdAktivitasDokumen");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (KeyFields.Count > 1 && (!IsArray(keys) || keys.Length != KeyFields.Count))
                    continue;
                if (!IsNumeric(keys)) // IdAktivitasDokumen
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
                    IdAktivitasDokumen.CurrentValue = keys;
                else
                    IdAktivitasDokumen.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        // Load row values from recordset
        public void LoadListRowValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
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
            StatusUpload.SetDbValue(row["StatusUpload"]);
            DiunggahOleh.SetDbValue(row["DiunggahOleh"]);
            TanggalUpload.SetDbValue(row["TanggalUpload"]);
            DiperbaruiOleh.SetDbValue(row["DiperbaruiOleh"]);
            TanggalDiperbarui.SetDbValue(row["TanggalDiperbarui"]);
            IdTemplateAktivitasDokumen.SetDbValue(row["IdTemplateAktivitasDokumen"]);
            WajibUpload.SetDbValue(ConvertToBool(row["WajibUpload"]) ? "1" : "0");
            TipeProses.SetDbValue(row["TipeProses"]);
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "AktivitasDokumenList";
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

            // IdAktivitasDokumen
            IdAktivitasDokumen.ViewValue = IdAktivitasDokumen.CurrentValue;
            IdAktivitasDokumen.ViewCustomAttributes = "";

            // NoReferensi
            NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
            NoReferensi.ViewCustomAttributes = "";

            // IdProses
            IdProses.ViewValue = IdProses.CurrentValue;

            // awallookupbung
            string curVal = ConvertToString(IdProses.CurrentValue);
            IdProses.ViewValue = Empty(curVal) ? DbNullValue : FormatNumber(IdProses.CurrentValue, IdProses.FormatPattern);
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
                    }
                }
            }

            // akhirlookupbung
            IdProses.ViewCustomAttributes = "";

            // IdAktivitas

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

            // IdDokumen

            // awallookupbung
            string curVal3 = ConvertToString(IdDokumen.CurrentValue);
            IdDokumen.ViewValue = Empty(curVal3) ? DbNullValue : FormatNumber(IdDokumen.CurrentValue, IdDokumen.FormatPattern);
            if (!Empty(curVal3)) {
                if (IdDokumen.Lookup != null && IsDictionary(IdDokumen.Lookup?.Options) && IdDokumen.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    IdDokumen.ViewValue = IdDokumen.LookupCacheOption(curVal3);
                } else { // Lookup from database // DN
                    string filterWrk3 = SearchFilter(IdDokumen.Lookup?.GetTable()?.Fields["IdDokumen"].SearchExpression, "=", IdDokumen.CurrentValue, IdDokumen.Lookup?.GetTable()?.Fields["IdDokumen"].SearchDataType, "");
                    string? sqlWrk3 = IdDokumen.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk3?.Count > 0 && IdDokumen.Lookup != null) { // Lookup values found
                        var listwrk = IdDokumen.Lookup?.RenderViewRow(rswrk3[0]);
                        IdDokumen.ViewValue = IdDokumen.DisplayValue(listwrk);
                    }
                }
            }

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

            // Keterangan
            Keterangan.ViewValue = Keterangan.CurrentValue;
            Keterangan.ViewCustomAttributes = "";

            // PathFile
            PathFile.UploadPath = PathFile.GetUploadPath();
            if (!IsNull(PathFile.Upload.DbValue)) {
                PathFile.ViewValue = PathFile.Upload.DbValue;
            } else {
                PathFile.ViewValue = "";
            }
            PathFile.ViewCustomAttributes = "";

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

            // IdAktivitasDokumen
            IdAktivitasDokumen.HrefValue = "";
            IdAktivitasDokumen.TooltipValue = "";

            // NoReferensi
            NoReferensi.HrefValue = "";
            NoReferensi.TooltipValue = "";

            // IdProses
            IdProses.HrefValue = "";
            IdProses.TooltipValue = "";

            // IdAktivitas
            IdAktivitas.HrefValue = "";
            IdAktivitas.TooltipValue = "";

            // IdDokumen
            IdDokumen.HrefValue = "";
            IdDokumen.TooltipValue = "";

            // NamaDokumen
            NamaDokumen.HrefValue = "";
            NamaDokumen.TooltipValue = "";

            // TemplateDokumen
            TemplateDokumen.HrefValue = "";
            TemplateDokumen.TooltipValue = "";

            // UploadDokumen
            UploadDokumen.HrefValue = "";
            UploadDokumen.TooltipValue = "";

            // DownloadDokumen
            DownloadDokumen.HrefValue = "";
            DownloadDokumen.TooltipValue = "";

            // Keterangan
            Keterangan.HrefValue = "";
            Keterangan.TooltipValue = "";

            // PathFile
            PathFile.HrefValue = "";
            PathFile.ExportHrefValue = PathFile.UploadPath + PathFile.Upload.DbValue;
            PathFile.TooltipValue = "";

            // StatusUpload
            StatusUpload.HrefValue = "";
            StatusUpload.TooltipValue = "";

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

            // IdTemplateAktivitasDokumen
            IdTemplateAktivitasDokumen.HrefValue = "";
            IdTemplateAktivitasDokumen.TooltipValue = "";

            // WajibUpload
            WajibUpload.HrefValue = "";
            WajibUpload.TooltipValue = "";

            // TipeProses
            TipeProses.HrefValue = "";
            TipeProses.TooltipValue = "";

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

            // IdAktivitasDokumen
            IdAktivitasDokumen.SetupEditAttributes();
            IdAktivitasDokumen.EditValue = IdAktivitasDokumen.CurrentValue;
            IdAktivitasDokumen.ViewCustomAttributes = "";

            // NoReferensi
            NoReferensi.SetupEditAttributes();
            if (!NoReferensi.Raw)
                NoReferensi.CurrentValue = HtmlDecode(NoReferensi.CurrentValue);
            NoReferensi.EditValue = NoReferensi.CurrentValue;
            NoReferensi.PlaceHolder = RemoveHtml(NoReferensi.Caption);

            // IdProses
            IdProses.SetupEditAttributes();
            IdProses.EditValue = IdProses.CurrentValue;
            IdProses.PlaceHolder = RemoveHtml(IdProses.Caption);
            if (!Empty(IdProses.EditValue) && IsNumeric(IdProses.EditValue))
                IdProses.EditValue = FormatNumber(IdProses.EditValue, null);

            // IdAktivitas
            IdAktivitas.SetupEditAttributes();
            if (!Empty(IdAktivitas.SessionValue)) {
                IdAktivitas.CurrentValue = ForeignKeyValue(IdAktivitas.SessionValue);

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
                IdAktivitas.PlaceHolder = RemoveHtml(IdAktivitas.Caption);
                if (!Empty(IdAktivitas.EditValue) && IsNumeric(IdAktivitas.EditValue))
                    IdAktivitas.EditValue = FormatNumber(IdAktivitas.EditValue, null);
            }

            // IdDokumen
            IdDokumen.SetupEditAttributes();
            IdDokumen.PlaceHolder = RemoveHtml(IdDokumen.Caption);
            if (!Empty(IdDokumen.EditValue) && IsNumeric(IdDokumen.EditValue))
                IdDokumen.EditValue = FormatNumber(IdDokumen.EditValue, null);

            // NamaDokumen
            NamaDokumen.SetupEditAttributes();
            if (!NamaDokumen.Raw)
                NamaDokumen.CurrentValue = HtmlDecode(NamaDokumen.CurrentValue);
            NamaDokumen.EditValue = NamaDokumen.CurrentValue;
            NamaDokumen.PlaceHolder = RemoveHtml(NamaDokumen.Caption);

            // TemplateDokumen
            TemplateDokumen.SetupEditAttributes();
            if (!TemplateDokumen.Raw)
                TemplateDokumen.CurrentValue = HtmlDecode(TemplateDokumen.CurrentValue);
            TemplateDokumen.EditValue = TemplateDokumen.CurrentValue;
            TemplateDokumen.PlaceHolder = RemoveHtml(TemplateDokumen.Caption);

            // UploadDokumen
            UploadDokumen.SetupEditAttributes();
            UploadDokumen.EditValue = UploadDokumen.CurrentValue; // DN
            UploadDokumen.PlaceHolder = RemoveHtml(UploadDokumen.Caption);

            // DownloadDokumen
            DownloadDokumen.SetupEditAttributes();
            DownloadDokumen.EditValue = DownloadDokumen.CurrentValue; // DN
            DownloadDokumen.PlaceHolder = RemoveHtml(DownloadDokumen.Caption);

            // Keterangan
            Keterangan.SetupEditAttributes();
            Keterangan.EditValue = Keterangan.CurrentValue; // DN
            Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

            // PathFile
            PathFile.SetupEditAttributes();
            PathFile.UploadPath = PathFile.GetUploadPath();
            if (!IsNull(PathFile.Upload.DbValue)) {
                PathFile.EditValue = PathFile.Upload.DbValue;
            } else {
                PathFile.EditValue = "";
            }
            if (!Empty(PathFile.CurrentValue))
                    PathFile.Upload.FileName = ConvertToString(PathFile.CurrentValue);

            // StatusUpload
            StatusUpload.SetupEditAttributes();
            if (!StatusUpload.Raw)
                StatusUpload.CurrentValue = HtmlDecode(StatusUpload.CurrentValue);
            StatusUpload.EditValue = StatusUpload.CurrentValue;
            StatusUpload.PlaceHolder = RemoveHtml(StatusUpload.Caption);

            // DiunggahOleh
            DiunggahOleh.SetupEditAttributes();
            if (!DiunggahOleh.Raw)
                DiunggahOleh.CurrentValue = HtmlDecode(DiunggahOleh.CurrentValue);
            DiunggahOleh.EditValue = DiunggahOleh.CurrentValue;
            DiunggahOleh.PlaceHolder = RemoveHtml(DiunggahOleh.Caption);

            // TanggalUpload
            TanggalUpload.SetupEditAttributes();
            TanggalUpload.EditValue = FormatDateTime(TanggalUpload.CurrentValue, TanggalUpload.FormatPattern);
            TanggalUpload.PlaceHolder = RemoveHtml(TanggalUpload.Caption);

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

            // IdTemplateAktivitasDokumen
            IdTemplateAktivitasDokumen.SetupEditAttributes();
            IdTemplateAktivitasDokumen.EditValue = IdTemplateAktivitasDokumen.CurrentValue;
            IdTemplateAktivitasDokumen.PlaceHolder = RemoveHtml(IdTemplateAktivitasDokumen.Caption);
            if (!Empty(IdTemplateAktivitasDokumen.EditValue) && IsNumeric(IdTemplateAktivitasDokumen.EditValue))
                IdTemplateAktivitasDokumen.EditValue = FormatNumber(IdTemplateAktivitasDokumen.EditValue, null);

            // WajibUpload
            WajibUpload.EditValue = WajibUpload.Options(false);
            WajibUpload.PlaceHolder = RemoveHtml(WajibUpload.Caption);

            // TipeProses
            TipeProses.SetupEditAttributes();
            if (!TipeProses.Raw)
                TipeProses.CurrentValue = HtmlDecode(TipeProses.CurrentValue);
            TipeProses.EditValue = TipeProses.CurrentValue;
            TipeProses.PlaceHolder = RemoveHtml(TipeProses.Caption);

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
                        doc.ExportCaption(NoReferensi);
                        doc.ExportCaption(IdProses);
                        doc.ExportCaption(IdAktivitas);
                        doc.ExportCaption(IdDokumen);
                        doc.ExportCaption(NamaDokumen);
                        doc.ExportCaption(TemplateDokumen);
                        doc.ExportCaption(UploadDokumen);
                        doc.ExportCaption(DownloadDokumen);
                        doc.ExportCaption(Keterangan);
                        doc.ExportCaption(StatusUpload);
                        doc.ExportCaption(DiunggahOleh);
                        doc.ExportCaption(TanggalUpload);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
                        doc.ExportCaption(IdTemplateAktivitasDokumen);
                        doc.ExportCaption(WajibUpload);
                        doc.ExportCaption(TipeProses);
                    } else {
                        doc.ExportCaption(IdAktivitasDokumen);
                        doc.ExportCaption(NoReferensi);
                        doc.ExportCaption(IdProses);
                        doc.ExportCaption(IdAktivitas);
                        doc.ExportCaption(IdDokumen);
                        doc.ExportCaption(NamaDokumen);
                        doc.ExportCaption(TemplateDokumen);
                        doc.ExportCaption(StatusUpload);
                        doc.ExportCaption(DiunggahOleh);
                        doc.ExportCaption(TanggalUpload);
                        doc.ExportCaption(DiperbaruiOleh);
                        doc.ExportCaption(TanggalDiperbarui);
                        doc.ExportCaption(IdTemplateAktivitasDokumen);
                        doc.ExportCaption(WajibUpload);
                        doc.ExportCaption(TipeProses);
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
                            await doc.ExportField(NoReferensi);
                            await doc.ExportField(IdProses);
                            await doc.ExportField(IdAktivitas);
                            await doc.ExportField(IdDokumen);
                            await doc.ExportField(NamaDokumen);
                            await doc.ExportField(TemplateDokumen);
                            await doc.ExportField(UploadDokumen);
                            await doc.ExportField(DownloadDokumen);
                            await doc.ExportField(Keterangan);
                            await doc.ExportField(StatusUpload);
                            await doc.ExportField(DiunggahOleh);
                            await doc.ExportField(TanggalUpload);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
                            await doc.ExportField(IdTemplateAktivitasDokumen);
                            await doc.ExportField(WajibUpload);
                            await doc.ExportField(TipeProses);
                        } else {
                            await doc.ExportField(IdAktivitasDokumen);
                            await doc.ExportField(NoReferensi);
                            await doc.ExportField(IdProses);
                            await doc.ExportField(IdAktivitas);
                            await doc.ExportField(IdDokumen);
                            await doc.ExportField(NamaDokumen);
                            await doc.ExportField(TemplateDokumen);
                            await doc.ExportField(StatusUpload);
                            await doc.ExportField(DiunggahOleh);
                            await doc.ExportField(TanggalUpload);
                            await doc.ExportField(DiperbaruiOleh);
                            await doc.ExportField(TanggalDiperbarui);
                            await doc.ExportField(IdTemplateAktivitasDokumen);
                            await doc.ExportField(WajibUpload);
                            await doc.ExportField(TipeProses);
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

            // Set up field names
            string fldName = "", fileNameFld = "", fileTypeFld = "";
            if (SameText(fldparm, "PathFile")) {
                fldName = "PathFile";
                fileNameFld = "PathFile";
            } else {
                return JsonBoolResult.FalseResult; // Incorrect field
            }

            // Set up key values
            if (keys.Length == KeyFields.Count) {
                for (int i = 0; i < KeyFields.Count; i++) {
                    var fld = FieldByName(KeyFields.ElementAt(i).Key);
                    if (fld != null)
                        fld.CurrentValue = keys[i];
                }
            } else {
                return JsonBoolResult.FalseResult; // Incorrect key
            }

            // Set up filter (WHERE Clause)
            string filter = GetRecordFilter();
            CurrentFilter = filter;
            string sql = CurrentSql;
            using var rs = await Connection.ExecuteReaderAsync(sql);
            if (rs != null && await rs.ReadAsync()) {
                var val = rs[fldName];
                if (!Empty(val)) {
                    if (Fields.TryGetValue(fldName, out DbField? fld) && fld != null) {
                        // Binary data
                        if (fld.IsBlob) {
                            byte[] data = (byte[])val;
                            if (resize && data.Length > 0)
                                ResizeBinary(ref data, ref width, ref height);
                            string? contentType = "";

                            // Write file type
                            if (!Empty(fileTypeFld) && !Empty(rs[fileTypeFld]))
                                contentType = ConvertToString(rs[fileTypeFld]);
                            else
                                contentType = ContentType(data);

                            // Write file data
                            if (data.Take(8).SequenceEqual((byte[])[0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00]) && // Fix Office 2007 documents
                                !data.TakeLast(4).SequenceEqual((byte[])[0x00, 0x00, 0x00, 0x00]))
                                data.Concat((byte[])[0x00, 0x00, 0x00, 0x00]);

                            // Clear any debug message
                            // Response?.Clear();

                            // Return file content result // DN
                            string? downloadFileName = !Empty(fileNameFld) && !Empty(rs[fileNameFld])
                                ? ConvertToString(rs[fileNameFld])
                                : DownloadFileName;
                            string ext = ContentExtension(data).Replace(".", ""); // Get file extension
                            bool isPdf = SameText(ext, "pdf");
                            bool downloadPdf = !Config.EmbedPdf && Config.DownloadPdfFile;
                            if (isPdf && !downloadPdf) // Embed PDF or not download PDF // DN
                                downloadFileName = null;
                            return Controller.File(data, contentType, downloadFileName);

                        // Upload to folder
                        } else {
                            List<string> files;
                            if (fld.UploadMultiple)
                                files = ConvertToString(val).Split(Config.MultipleUploadSeparator).ToList();
                            else
                                files = [ConvertToString(val)];
                            var mi = fld.GetType().GetMethod("GetUploadPath");
                            if (mi != null) // GetUploadPath
                                fld.UploadPath = ConvertToString(mi.Invoke(fld, null));
                            var result = files.ToDictionary(f => f, f => Config.EncryptFilePath
                                ? FullUrl(Config.ApiUrl + Config.ApiFileAction + "/" + TableVar + "/" + Encrypt(fld.PhysicalUploadPath + f))
                                : FullUrl(fld.HrefPath + f));
                            return new JsonBoolResult(new Dictionary<string, object> { { fld.Param, result } }, true);
                        }
                    }
                }
            }
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
            return true;
        }

        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
        }

        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            try {
                // Tetap set user pembaruan
                rsnew["DiperbaruiOleh"] = CurrentUserName();
                string noReferensi = rsnew.ContainsKey("NoReferensi")
                    ? rsnew["NoReferensi"]?.ToString()
                    : rsold.ContainsKey("NoReferensi")
                        ? rsold["NoReferensi"]?.ToString()
                        : null;

                // Panggil SP GetPlantDateTime untuk mendapat waktu lokal plant
                DateTime plantTime = DateTime.Now; // fallback
                if (!string.IsNullOrWhiteSpace(noReferensi)) {
                    var plantObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @NomorReferensi = '{noReferensi}'");
                    if (plantObj != null && DateTime.TryParse(plantObj.ToString(), out var tmp))
                        plantTime = tmp;
                }
                rsnew["lastUpdatedDate"] = plantTime;

                // Logika penghapusan dokumen lama dan unggah dokumen baru tidak diubah
                string newDocument = rsnew.ContainsKey("PathFile") ? rsnew["PathFile"]?.ToString() ?? "" : "";
                string oldDocument = rsold.ContainsKey("PathFile") ? rsold["PathFile"]?.ToString() ?? "" : "";
                if (rsnew.ContainsKey("PathFile")) {
                    if (!string.IsNullOrEmpty(oldDocument) && oldDocument != newDocument) {
                        string filePath = Path.Combine(Configuration["UploadPathActivityDocument"] ?? "wwwroot/Uploads/Activity Document", oldDocument);
                        if (File.Exists(filePath)) {
                            try { File.Delete(filePath); } catch (Exception ex) { Console.WriteLine(ex); }
                        }
                    }
                    if (!string.IsNullOrEmpty(newDocument)) {
                        rsnew["DiunggahOleh"] = CurrentUserName();
                        rsnew["TanggalUpload"] = plantTime;
                    }
                }
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
        public bool RowDeleting(Dictionary<string, object> rs) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            string oldDocument = rs.ContainsKey("PathFile") ? rs["PathFile"]?.ToString() ?? "" : "";
            if (!string.IsNullOrEmpty(oldDocument.ToString())) {
                string filePath = Path.Combine(Configuration["UploadPathActivityDocument"] ?? "wwwroot/Uploads/Activity Document", oldDocument);
                if (File.Exists(filePath)) {
                    try {
                        File.Delete(filePath);
                    } catch (Exception ex) {
                        Console.WriteLine(ex);
                    }
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
