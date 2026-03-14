namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// setPjs
    /// </summary>
    [MaybeNull]
    public static SetPjs setPjs
    {
        get => HttpData.Resolve<SetPjs>("SetPjs");
        set => HttpData["SetPjs"] = value;
    }

    /// <summary>
    /// Table class for SetPjs
    /// </summary>
    public class SetPjs : DbTable
    {
        public override Dictionary<string, string> KeyFields { get; set; } = new() { // DN
            { "Id", "Id" },
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

        public readonly DbField<SqlDbType> Id;

        public readonly DbField<SqlDbType> NomorPjs;

        public readonly DbField<SqlDbType> RedirectLink;

        public readonly DbField<SqlDbType> Nama;

        public readonly DbField<SqlDbType> OrganizationLevel;

        public readonly DbField<SqlDbType> Region;

        public readonly DbField<SqlDbType> Plant;

        public readonly DbField<SqlDbType> PosisiAwal;

        public readonly DbField<SqlDbType> PosisiPJS;

        public readonly DbField<SqlDbType> LookupPosition;

        public readonly DbField<SqlDbType> TanggalMulai;

        public readonly DbField<SqlDbType> TanggalSelesai;

        public readonly DbField<SqlDbType> Status;

        public readonly DbField<SqlDbType> DownloadSuratTugas;

        public readonly DbField<SqlDbType> SuratTugas;

        public readonly DbField<SqlDbType> Keterangan;

        public readonly DbField<SqlDbType> Remaks;

        public readonly DbField<SqlDbType> DibuatOleh;

        public readonly DbField<SqlDbType> TanggalDibuat;

        public readonly DbField<SqlDbType> DiperbaharuiOleh;

        public readonly DbField<SqlDbType> DiperbaharuiTanggal;

        public readonly DbField<SqlDbType> PlantAwal;

        public readonly DbField<SqlDbType> RegionAwal;

        // Constructor
        public SetPjs()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "SetPjs";
            Name = "SetPjs";
            Type = "TABLE";
            UpdateTable = "dbo.SetPjs"; // Update Table
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

            // Id
            Id = new(this, "x_Id", 3, SqlDbType.Int) {
                Name = "Id",
                Expression = "[Id]",
                BasicSearchExpression = "CAST([Id] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Id]",
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
                CustomMessage = Language.FieldPhrase("SetPjs", "Id", "CustomMsg"),
                IsUpload = false
            };
            Id.Raw = true;
            Fields.Add("Id", Id);

            // NomorPjs
            NomorPjs = new(this, "x_NomorPjs", 202, SqlDbType.NVarChar) {
                Name = "NomorPjs",
                Expression = "[NomorPjs]",
                BasicSearchExpression = "[NomorPjs]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomorPjs]",
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
                CustomMessage = Language.FieldPhrase("SetPjs", "NomorPjs", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomorPjs", NomorPjs);

            // RedirectLink
            RedirectLink = new(this, "x_RedirectLink", 202, SqlDbType.NVarChar) {
                Name = "RedirectLink",
                Expression = "'<a href=SetPjsView/' + CAST(Id AS NVARCHAR(50))+'>'+CAST(NomorPjs AS NVARCHAR(100))+'</a>'",
                UseBasicSearch = true,
                BasicSearchExpression = "'<a href=SetPjsView/' + CAST(Id AS NVARCHAR(50))+'>'+CAST(NomorPjs AS NVARCHAR(100))+'</a>'",
                DateTimeFormat = -1,
                VirtualExpression = "'<a href=SetPjsView/' + CAST(Id AS NVARCHAR(50))+'>'+CAST(NomorPjs AS NVARCHAR(100))+'</a>'",
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
                CustomMessage = Language.FieldPhrase("SetPjs", "RedirectLink", "CustomMsg"),
                IsUpload = false
            };
            RedirectLink.Lookup = new Lookup<DbField>(RedirectLink, "SetPjs", true, "RedirectLink", new List<string> {"RedirectLink", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("RedirectLink", RedirectLink);

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
                CustomMessage = Language.FieldPhrase("SetPjs", "Nama", "CustomMsg"),
                IsUpload = false
            };
            Nama.Lookup = new Lookup<DbField>(Nama, "SetPjs", true, "Nama", new List<string> {"Nama", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Nama", Nama);

            // OrganizationLevel
            OrganizationLevel = new(this, "x_OrganizationLevel", 202, SqlDbType.NVarChar) {
                Name = "OrganizationLevel",
                Expression = "[OrganizationLevel]",
                UseBasicSearch = true,
                BasicSearchExpression = "[OrganizationLevel]",
                DateTimeFormat = -1,
                VirtualExpression = "[OrganizationLevel]",
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
                OptionCount = 3,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "OrganizationLevel", "CustomMsg"),
                IsUpload = false
            };
            OrganizationLevel.Lookup = new Lookup<DbField>(OrganizationLevel, "SetPjs", true, "OrganizationLevel", new List<string> {"OrganizationLevel", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("OrganizationLevel", OrganizationLevel);

            // Region
            Region = new(this, "x_Region", 3, SqlDbType.Int) {
                Name = "Region",
                Expression = "[Region]",
                BasicSearchExpression = "CAST([Region] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Region]",
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
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "Region", "CustomMsg"),
                IsUpload = false
            };
            Region.Raw = true;
            Region.Lookup = new Lookup<DbField>(Region, "MasterRegion", false, "IdRegion", new List<string> {"Region", "", "", ""}, "", "", new List<string> {}, new List<string> {"x_Plant"}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[Region]");
            Fields.Add("Region", Region);

            // Plant
            Plant = new(this, "x_Plant", 3, SqlDbType.Int) {
                Name = "Plant",
                Expression = "[Plant]",
                BasicSearchExpression = "CAST([Plant] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Plant]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                Required = true, // Required field
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                SearchOperators = ["=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "Plant", "CustomMsg"),
                IsUpload = false
            };
            Plant.Raw = true;
            Plant.Lookup = new Lookup<DbField>(Plant, "MasterPlant", false, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {"x_Region"}, new List<string> {}, new List<string> {"Region"}, new List<string> {"x_Region"}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, Plant) + "',[Nama_Terminal])");
            Fields.Add("Plant", Plant);

            // PosisiAwal
            PosisiAwal = new(this, "x_PosisiAwal", 3, SqlDbType.Int) {
                Name = "PosisiAwal",
                Expression = "[PosisiAwal]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([PosisiAwal] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PosisiAwal]",
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
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("SetPjs", "PosisiAwal", "CustomMsg"),
                IsUpload = false
            };
            PosisiAwal.Raw = true;
            PosisiAwal.Lookup = new Lookup<DbField>(PosisiAwal, "MasterPosition", true, "IdPosition", new List<string> {"IdPosition", "NamaPosition", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT(CAST([IdPosition] AS NVARCHAR),'" + ValueSeparator(1, PosisiAwal) + "',[NamaPosition])");
            Fields.Add("PosisiAwal", PosisiAwal);

            // PosisiPJS
            PosisiPJS = new(this, "x_PosisiPJS", 3, SqlDbType.Int) {
                Name = "PosisiPJS",
                Expression = "[PosisiPJS]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([PosisiPJS] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PosisiPJS]",
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
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("SetPjs", "PosisiPJS", "CustomMsg"),
                IsUpload = false
            };
            PosisiPJS.Raw = true;
            PosisiPJS.Lookup = new Lookup<DbField>(PosisiPJS, "MasterPosition", true, "IdPosition", new List<string> {"IdPosition", "NamaPosition", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT(CAST([IdPosition] AS NVARCHAR),'" + ValueSeparator(1, PosisiPJS) + "',[NamaPosition])");
            Fields.Add("PosisiPJS", PosisiPJS);

            // LookupPosition
            LookupPosition = new(this, "x_LookupPosition", 200, SqlDbType.VarChar) {
                Name = "LookupPosition",
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
                Required = true, // Required field
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 1,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "LookupPosition", "CustomMsg"),
                IsUpload = false
            };
            LookupPosition.Lookup = new Lookup<DbField>(LookupPosition, "SetPjs", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LookupPosition", LookupPosition);

            // TanggalMulai
            TanggalMulai = new(this, "x_TanggalMulai", 133, SqlDbType.Date) {
                Name = "TanggalMulai",
                Expression = "[TanggalMulai]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TanggalMulai]", 5, "DB"),
                DateTimeFormat = 5,
                VirtualExpression = "[TanggalMulai]",
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
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(5)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("SetPjs", "TanggalMulai", "CustomMsg"),
                IsUpload = false
            };
            TanggalMulai.Raw = true;
            TanggalMulai.Lookup = new Lookup<DbField>(TanggalMulai, "SetPjs", true, "TanggalMulai", new List<string> {"TanggalMulai", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalMulai", TanggalMulai);

            // TanggalSelesai
            TanggalSelesai = new(this, "x_TanggalSelesai", 133, SqlDbType.Date) {
                Name = "TanggalSelesai",
                Expression = "[TanggalSelesai]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TanggalSelesai]", 5, "DB"),
                DateTimeFormat = 5,
                VirtualExpression = "[TanggalSelesai]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(5)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "TanggalSelesai", "CustomMsg"),
                IsUpload = false
            };
            TanggalSelesai.Raw = true;
            TanggalSelesai.Lookup = new Lookup<DbField>(TanggalSelesai, "SetPjs", true, "TanggalSelesai", new List<string> {"TanggalSelesai", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalSelesai", TanggalSelesai);

            // Status
            Status = new(this, "x_Status", 202, SqlDbType.NVarChar) {
                Name = "Status",
                Expression = "[Status]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Status]",
                DateTimeFormat = -1,
                VirtualExpression = "[Status]",
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
                CustomMessage = Language.FieldPhrase("SetPjs", "Status", "CustomMsg"),
                IsUpload = false
            };
            Status.Lookup = new Lookup<DbField>(Status, "SetPjs", true, "Status", new List<string> {"Status", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Status", Status);

            // DownloadSuratTugas
            DownloadSuratTugas = new(this, "x_DownloadSuratTugas", 202, SqlDbType.NVarChar) {
                Name = "DownloadSuratTugas",
                Expression = "CASE WHEN [SuratTugas] IS NOT NULL THEN '<a class=' + CHAR(34) + 'btn-download btn btn-primary' + CHAR(34) + ' data-id=' + CAST(Id AS NVARCHAR(50)) +  ' ><i class='+CHAR(34) + 'fas fa-download me-2' + CHAR(34)+'></i> Download Surat Tugas </a>' ELSE 'Not Uploaded' END",
                BasicSearchExpression = "CASE WHEN [SuratTugas] IS NOT NULL THEN '<a class=' + CHAR(34) + 'btn-download btn btn-primary' + CHAR(34) + ' data-id=' + CAST(Id AS NVARCHAR(50)) +  ' ><i class='+CHAR(34) + 'fas fa-download me-2' + CHAR(34)+'></i> Download Surat Tugas </a>' ELSE 'Not Uploaded' END",
                DateTimeFormat = -1,
                VirtualExpression = "CASE WHEN [SuratTugas] IS NOT NULL THEN '<a class=' + CHAR(34) + 'btn-download btn btn-primary' + CHAR(34) + ' data-id=' + CAST(Id AS NVARCHAR(50)) +  ' ><i class='+CHAR(34) + 'fas fa-download me-2' + CHAR(34)+'></i> Download Surat Tugas </a>' ELSE 'Not Uploaded' END",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "DownloadSuratTugas", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("DownloadSuratTugas", DownloadSuratTugas);

            // SuratTugas
            SuratTugas = new(this, "x_SuratTugas", 202, SqlDbType.NVarChar) {
                Name = "SuratTugas",
                Expression = "[SuratTugas]",
                BasicSearchExpression = "[SuratTugas]",
                DateTimeFormat = -1,
                VirtualExpression = "[SuratTugas]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "SuratTugas", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("SuratTugas", SuratTugas);

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
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "Keterangan", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Keterangan", Keterangan);

            // Remaks
            Remaks = new(this, "x_Remaks", 203, SqlDbType.NText) {
                Name = "Remaks",
                Expression = "[Remaks]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Remaks]",
                DateTimeFormat = -1,
                VirtualExpression = "[Remaks]",
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
                CustomMessage = Language.FieldPhrase("SetPjs", "Remaks", "CustomMsg"),
                IsUpload = false
            };
            Remaks.Lookup = new Lookup<DbField>(Remaks, "SetPjs", true, "Remaks", new List<string> {"Remaks", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Remaks", Remaks);

            // DibuatOleh
            DibuatOleh = new(this, "x_DibuatOleh", 3, SqlDbType.Int) {
                Name = "DibuatOleh",
                Expression = "[DibuatOleh]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([DibuatOleh] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[DibuatOleh]",
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
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("SetPjs", "DibuatOleh", "CustomMsg"),
                IsUpload = false
            };
            DibuatOleh.Raw = true;
            DibuatOleh.Lookup = new Lookup<DbField>(DibuatOleh, "MasterUser", true, "IdUser", new List<string> {"Username", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[Username]");
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
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("SetPjs", "TanggalDibuat", "CustomMsg"),
                IsUpload = false
            };
            TanggalDibuat.Raw = true;
            TanggalDibuat.Lookup = new Lookup<DbField>(TanggalDibuat, "SetPjs", true, "TanggalDibuat", new List<string> {"TanggalDibuat", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TanggalDibuat", TanggalDibuat);

            // DiperbaharuiOleh
            DiperbaharuiOleh = new(this, "x_DiperbaharuiOleh", 3, SqlDbType.Int) {
                Name = "DiperbaharuiOleh",
                Expression = "[DiperbaharuiOleh]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([DiperbaharuiOleh] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[DiperbaharuiOleh]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "DiperbaharuiOleh", "CustomMsg"),
                IsUpload = false
            };
            DiperbaharuiOleh.Raw = true;
            DiperbaharuiOleh.Lookup = new Lookup<DbField>(DiperbaharuiOleh, "MasterUser", true, "IdUser", new List<string> {"Username", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[Username]");
            Fields.Add("DiperbaharuiOleh", DiperbaharuiOleh);

            // DiperbaharuiTanggal
            DiperbaharuiTanggal = new(this, "x_DiperbaharuiTanggal", 135, SqlDbType.DateTime) {
                Name = "DiperbaharuiTanggal",
                Expression = "[DiperbaharuiTanggal]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[DiperbaharuiTanggal]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[DiperbaharuiTanggal]",
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
                CustomMessage = Language.FieldPhrase("SetPjs", "DiperbaharuiTanggal", "CustomMsg"),
                IsUpload = false
            };
            DiperbaharuiTanggal.Raw = true;
            DiperbaharuiTanggal.Lookup = new Lookup<DbField>(DiperbaharuiTanggal, "SetPjs", true, "DiperbaharuiTanggal", new List<string> {"DiperbaharuiTanggal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("DiperbaharuiTanggal", DiperbaharuiTanggal);

            // PlantAwal
            PlantAwal = new(this, "x_PlantAwal", 3, SqlDbType.Int) {
                Name = "PlantAwal",
                Expression = "[PlantAwal]",
                BasicSearchExpression = "CAST([PlantAwal] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PlantAwal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "PlantAwal", "CustomMsg"),
                IsUpload = false
            };
            PlantAwal.Raw = true;
            Fields.Add("PlantAwal", PlantAwal);

            // RegionAwal
            RegionAwal = new(this, "x_RegionAwal", 3, SqlDbType.Int) {
                Name = "RegionAwal",
                Expression = "[RegionAwal]",
                BasicSearchExpression = "CAST([RegionAwal] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[RegionAwal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SetPjs", "RegionAwal", "CustomMsg"),
                IsUpload = false
            };
            RegionAwal.Raw = true;
            Fields.Add("RegionAwal", RegionAwal);

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
            get => _sqlFrom ?? "dbo.SetPjs";
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
                string select = "*, '<a href=SetPjsView/' + CAST(Id AS NVARCHAR(50))+'>'+CAST(NomorPjs AS NVARCHAR(100))+'</a>' AS [RedirectLink], '' AS [LookupPosition], CASE WHEN [SuratTugas] IS NOT NULL THEN '<a class=' + CHAR(34) + 'btn-download btn btn-primary' + CHAR(34) + ' data-id=' + CAST(Id AS NVARCHAR(50)) +  ' ><i class='+CHAR(34) + 'fas fa-download me-2' + CHAR(34)+'></i> Download Surat Tugas </a>' ELSE 'Not Uploaded' END AS [DownloadSuratTugas]";
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
                attr.Name == "Id");
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
                attr.Name == "Id");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.SetPj type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                if (row.ContainsKey("Id"))
                    row["Id"] = lastInsertedId;
                else
                    row.Add("Id", lastInsertedId);
                Id.SetDbValue(lastInsertedId);
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.SetPj type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.SetPj type", "data");
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
                Id.DbValue = row["Id"]; // Set DB value only
                NomorPjs.DbValue = row["NomorPjs"]; // Set DB value only
                RedirectLink.DbValue = row["RedirectLink"]; // Set DB value only
                Nama.DbValue = row["Nama"]; // Set DB value only
                OrganizationLevel.DbValue = row["OrganizationLevel"]; // Set DB value only
                Region.DbValue = row["Region"]; // Set DB value only
                Plant.DbValue = row["Plant"]; // Set DB value only
                PosisiAwal.DbValue = row["PosisiAwal"]; // Set DB value only
                PosisiPJS.DbValue = row["PosisiPJS"]; // Set DB value only
                LookupPosition.DbValue = row["LookupPosition"]; // Set DB value only
                TanggalMulai.DbValue = row["TanggalMulai"]; // Set DB value only
                TanggalSelesai.DbValue = row["TanggalSelesai"]; // Set DB value only
                Status.DbValue = row["Status"]; // Set DB value only
                DownloadSuratTugas.DbValue = row["DownloadSuratTugas"]; // Set DB value only
                SuratTugas.DbValue = row["SuratTugas"]; // Set DB value only
                Keterangan.DbValue = row["Keterangan"]; // Set DB value only
                Remaks.DbValue = row["Remaks"]; // Set DB value only
                DibuatOleh.DbValue = row["DibuatOleh"]; // Set DB value only
                TanggalDibuat.DbValue = row["TanggalDibuat"]; // Set DB value only
                DiperbaharuiOleh.DbValue = row["DiperbaharuiOleh"]; // Set DB value only
                DiperbaharuiTanggal.DbValue = row["DiperbaharuiTanggal"]; // Set DB value only
                PlantAwal.DbValue = row["PlantAwal"]; // Set DB value only
                RegionAwal.DbValue = row["RegionAwal"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[Id] = @Id@";

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
                    return "SetPjsList";
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
                "SetPjsView" => Language.Phrase("View"),
                "SetPjsEdit" => Language.Phrase("Edit"),
                "SetPjsAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "SetPjsList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "SetPjsView",
                Config.ApiAddAction => "SetPjsAdd",
                Config.ApiEditAction => "SetPjsEdit",
                Config.ApiDeleteAction => "SetPjsDelete",
                Config.ApiListAction => "SetPjsList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "SetPjsView",
                Config.ApiAddAction => "SetPjsAdd",
                Config.ApiEditAction => "SetPjsEdit",
                Config.ApiDeleteAction => "SetPjsDelete",
                Config.ApiListAction => "SetPjsList",
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
        public string ListUrl => "SetPjsList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("SetPjsView", parm);
            else
                url = KeyUrl("SetPjsView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "SetPjsAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "SetPjsAdd?" + parm;
            else
                url = "SetPjsAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("SetPjsEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("SetPjsList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("SetPjsAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("SetPjsList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("SetPjsDelete", parm)); // DN
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
            json += "\"Id\":" + ConvertToJson(Id.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL // DN
        public string KeyUrl(string url, string parm = "")
        {
            if (!IsNull(Id.CurrentValue)) {
                url += "/" + Id.CurrentValue;
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
                if (RouteValues.TryGetValue("Id", out object? v0)) { // Id // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("Id");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (KeyFields.Count > 1 && (!IsArray(keys) || keys.Length != KeyFields.Count))
                    continue;
                if (!IsNumeric(keys)) // Id
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
                    Id.CurrentValue = keys;
                else
                    Id.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        // Load row values from recordset
        public void LoadListRowValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
            Id.SetDbValue(row["Id"]);
            NomorPjs.SetDbValue(row["NomorPjs"]);
            RedirectLink.SetDbValue(row["RedirectLink"]);
            Nama.SetDbValue(row["Nama"]);
            OrganizationLevel.SetDbValue(row["OrganizationLevel"]);
            Region.SetDbValue(row["Region"]);
            Plant.SetDbValue(row["Plant"]);
            PosisiAwal.SetDbValue(row["PosisiAwal"]);
            PosisiPJS.SetDbValue(row["PosisiPJS"]);
            LookupPosition.SetDbValue(row["LookupPosition"]);
            TanggalMulai.SetDbValue(row["TanggalMulai"]);
            TanggalSelesai.SetDbValue(row["TanggalSelesai"]);
            Status.SetDbValue(row["Status"]);
            DownloadSuratTugas.SetDbValue(row["DownloadSuratTugas"]);
            SuratTugas.SetDbValue(row["SuratTugas"]);
            Keterangan.SetDbValue(row["Keterangan"]);
            Remaks.SetDbValue(row["Remaks"]);
            DibuatOleh.SetDbValue(row["DibuatOleh"]);
            TanggalDibuat.SetDbValue(row["TanggalDibuat"]);
            DiperbaharuiOleh.SetDbValue(row["DiperbaharuiOleh"]);
            DiperbaharuiTanggal.SetDbValue(row["DiperbaharuiTanggal"]);
            PlantAwal.SetDbValue(row["PlantAwal"]);
            RegionAwal.SetDbValue(row["RegionAwal"]);
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "SetPjsList";
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

            // Id

            // NomorPjs

            // RedirectLink

            // Nama

            // OrganizationLevel

            // Region
            Region.CellCssStyle = "white-space: nowrap;";

            // Plant
            Plant.CellCssStyle = "white-space: nowrap;";

            // PosisiAwal

            // PosisiPJS

            // LookupPosition
            LookupPosition.CellCssStyle = "white-space: nowrap;";

            // TanggalMulai

            // TanggalSelesai

            // Status

            // DownloadSuratTugas
            DownloadSuratTugas.CellCssStyle = "white-space: nowrap;";

            // SuratTugas
            SuratTugas.CellCssStyle = "white-space: nowrap;";

            // Keterangan
            Keterangan.CellCssStyle = "white-space: nowrap;";

            // Remaks

            // DibuatOleh

            // TanggalDibuat

            // DiperbaharuiOleh

            // DiperbaharuiTanggal

            // PlantAwal
            PlantAwal.CellCssStyle = "white-space: nowrap;";

            // RegionAwal
            RegionAwal.CellCssStyle = "white-space: nowrap;";

            // Id
            Id.ViewValue = Id.CurrentValue;
            Id.ViewCustomAttributes = "";

            // NomorPjs
            NomorPjs.ViewValue = ConvertToString(NomorPjs.CurrentValue); // DN
            NomorPjs.ViewCustomAttributes = "";

            // RedirectLink
            RedirectLink.ViewValue = ConvertToString(RedirectLink.CurrentValue); // DN
            RedirectLink.ViewCustomAttributes = "";

            // Nama
            Nama.ViewValue = ConvertToString(Nama.CurrentValue); // DN
            Nama.ViewCustomAttributes = "";

            // OrganizationLevel
            if (!Empty(OrganizationLevel.CurrentValue)) {
                OrganizationLevel.ViewValue = OrganizationLevel.OptionCaption(ConvertToString(OrganizationLevel.CurrentValue));
            } else {
                OrganizationLevel.ViewValue = DbNullValue;
            }
            OrganizationLevel.ViewCustomAttributes = "";

            // Region
            string curVal2 = ConvertToString(Region.CurrentValue);
            if (!Empty(curVal2)) {
                if (Region.Lookup != null && IsDictionary(Region.Lookup?.Options) && Region.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Region.ViewValue = Region.LookupCacheOption(curVal2);
                } else { // Lookup from database // DN
                    string filterWrk2 = SearchFilter(Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchExpression, "=", Region.CurrentValue, Region.Lookup?.GetTable()?.Fields["IdRegion"].SearchDataType, "");
                    string? sqlWrk2 = Region.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk2?.Count > 0 && Region.Lookup != null) { // Lookup values found
                        var listwrk = Region.Lookup?.RenderViewRow(rswrk2[0]);
                        Region.ViewValue = Region.DisplayValue(listwrk);
                    } else {
                        Region.ViewValue = Region.CurrentValue;
                    }
                }
            } else {
                Region.ViewValue = DbNullValue;
            }
            Region.ViewCustomAttributes = "";

            // Plant
            string curVal3 = ConvertToString(Plant.CurrentValue);
            if (!Empty(curVal3)) {
                if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Plant.ViewValue = Plant.LookupCacheOption(curVal3);
                } else { // Lookup from database // DN
                    string filterWrk3 = SearchFilter(Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk3 = Plant.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk3?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                        var listwrk = Plant.Lookup?.RenderViewRow(rswrk3[0]);
                        Plant.ViewValue = Plant.DisplayValue(listwrk);
                    } else {
                        Plant.ViewValue = Plant.CurrentValue;
                    }
                }
            } else {
                Plant.ViewValue = DbNullValue;
            }
            Plant.ViewCustomAttributes = "";

            // PosisiAwal
            PosisiAwal.ViewValue = PosisiAwal.CurrentValue;
            string curVal4 = ConvertToString(PosisiAwal.CurrentValue);
            if (!Empty(curVal4)) {
                if (PosisiAwal.Lookup != null && IsDictionary(PosisiAwal.Lookup?.Options) && PosisiAwal.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PosisiAwal.ViewValue = PosisiAwal.LookupCacheOption(curVal4);
                } else { // Lookup from database // DN
                    string filterWrk4 = SearchFilter(PosisiAwal.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", PosisiAwal.CurrentValue, PosisiAwal.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                    string? sqlWrk4 = PosisiAwal.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk4?.Count > 0 && PosisiAwal.Lookup != null) { // Lookup values found
                        var listwrk = PosisiAwal.Lookup?.RenderViewRow(rswrk4[0]);
                        PosisiAwal.ViewValue = PosisiAwal.DisplayValue(listwrk);
                    } else {
                        PosisiAwal.ViewValue = PosisiAwal.CurrentValue;
                    }
                }
            } else {
                PosisiAwal.ViewValue = DbNullValue;
            }
            PosisiAwal.ViewCustomAttributes = "";

            // PosisiPJS
            PosisiPJS.ViewValue = PosisiPJS.CurrentValue;
            string curVal5 = ConvertToString(PosisiPJS.CurrentValue);
            if (!Empty(curVal5)) {
                if (PosisiPJS.Lookup != null && IsDictionary(PosisiPJS.Lookup?.Options) && PosisiPJS.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PosisiPJS.ViewValue = PosisiPJS.LookupCacheOption(curVal5);
                } else { // Lookup from database // DN
                    string filterWrk5 = SearchFilter(PosisiPJS.Lookup?.GetTable()?.Fields["IdPosition"].SearchExpression, "=", PosisiPJS.CurrentValue, PosisiPJS.Lookup?.GetTable()?.Fields["IdPosition"].SearchDataType, "");
                    string? sqlWrk5 = PosisiPJS.Lookup?.GetSql(false, filterWrk5, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk5 = sqlWrk5 != null ? Connection.GetRows(sqlWrk5) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk5?.Count > 0 && PosisiPJS.Lookup != null) { // Lookup values found
                        var listwrk = PosisiPJS.Lookup?.RenderViewRow(rswrk5[0]);
                        PosisiPJS.ViewValue = PosisiPJS.DisplayValue(listwrk);
                    } else {
                        PosisiPJS.ViewValue = PosisiPJS.CurrentValue;
                    }
                }
            } else {
                PosisiPJS.ViewValue = DbNullValue;
            }
            PosisiPJS.ViewCustomAttributes = "";

            // LookupPosition
            if (!Empty(LookupPosition.CurrentValue)) {
                LookupPosition.ViewValue = LookupPosition.OptionCaption(ConvertToString(LookupPosition.CurrentValue));
            } else {
                LookupPosition.ViewValue = DbNullValue;
            }
            LookupPosition.ViewCustomAttributes = "";

            // TanggalMulai
            TanggalMulai.ViewValue = TanggalMulai.CurrentValue;
            TanggalMulai.ViewValue = FormatDateTime(TanggalMulai.ViewValue, TanggalMulai.FormatPattern);
            TanggalMulai.ViewCustomAttributes = "";

            // TanggalSelesai
            TanggalSelesai.ViewValue = TanggalSelesai.CurrentValue;
            TanggalSelesai.ViewValue = FormatDateTime(TanggalSelesai.ViewValue, TanggalSelesai.FormatPattern);
            TanggalSelesai.ViewCustomAttributes = "";

            // Status
            Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
            Status.ViewCustomAttributes = "";

            // DownloadSuratTugas
            DownloadSuratTugas.ViewValue = ConvertToString(DownloadSuratTugas.CurrentValue); // DN
            DownloadSuratTugas.ViewCustomAttributes = "";

            // SuratTugas
            SuratTugas.ViewValue = ConvertToString(SuratTugas.CurrentValue); // DN
            SuratTugas.ViewCustomAttributes = "";

            // Keterangan
            Keterangan.ViewValue = Keterangan.CurrentValue;
            Keterangan.ViewCustomAttributes = "";

            // Remaks
            Remaks.ViewValue = Remaks.CurrentValue;
            Remaks.ViewCustomAttributes = "";

            // DibuatOleh
            DibuatOleh.ViewValue = DibuatOleh.CurrentValue;
            string curVal7 = ConvertToString(DibuatOleh.CurrentValue);
            if (!Empty(curVal7)) {
                if (DibuatOleh.Lookup != null && IsDictionary(DibuatOleh.Lookup?.Options) && DibuatOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    DibuatOleh.ViewValue = DibuatOleh.LookupCacheOption(curVal7);
                } else { // Lookup from database // DN
                    string filterWrk7 = SearchFilter(DibuatOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DibuatOleh.CurrentValue, DibuatOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                    string? sqlWrk7 = DibuatOleh.Lookup?.GetSql(false, filterWrk7, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk7 = sqlWrk7 != null ? Connection.GetRows(sqlWrk7) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk7?.Count > 0 && DibuatOleh.Lookup != null) { // Lookup values found
                        var listwrk = DibuatOleh.Lookup?.RenderViewRow(rswrk7[0]);
                        DibuatOleh.ViewValue = DibuatOleh.DisplayValue(listwrk);
                    } else {
                        DibuatOleh.ViewValue = DibuatOleh.CurrentValue;
                    }
                }
            } else {
                DibuatOleh.ViewValue = DbNullValue;
            }
            DibuatOleh.ViewCustomAttributes = "";

            // TanggalDibuat
            TanggalDibuat.ViewValue = TanggalDibuat.CurrentValue;
            TanggalDibuat.ViewValue = FormatDateTime(TanggalDibuat.ViewValue, TanggalDibuat.FormatPattern);
            TanggalDibuat.ViewCustomAttributes = "";

            // DiperbaharuiOleh
            DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.CurrentValue;
            string curVal8 = ConvertToString(DiperbaharuiOleh.CurrentValue);
            if (!Empty(curVal8)) {
                if (DiperbaharuiOleh.Lookup != null && IsDictionary(DiperbaharuiOleh.Lookup?.Options) && DiperbaharuiOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.LookupCacheOption(curVal8);
                } else { // Lookup from database // DN
                    string filterWrk8 = SearchFilter(DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DiperbaharuiOleh.CurrentValue, DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                    string? sqlWrk8 = DiperbaharuiOleh.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk8?.Count > 0 && DiperbaharuiOleh.Lookup != null) { // Lookup values found
                        var listwrk = DiperbaharuiOleh.Lookup?.RenderViewRow(rswrk8[0]);
                        DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.DisplayValue(listwrk);
                    } else {
                        DiperbaharuiOleh.ViewValue = DiperbaharuiOleh.CurrentValue;
                    }
                }
            } else {
                DiperbaharuiOleh.ViewValue = DbNullValue;
            }
            DiperbaharuiOleh.ViewCustomAttributes = "";

            // DiperbaharuiTanggal
            DiperbaharuiTanggal.ViewValue = DiperbaharuiTanggal.CurrentValue;
            DiperbaharuiTanggal.ViewValue = FormatDateTime(DiperbaharuiTanggal.ViewValue, DiperbaharuiTanggal.FormatPattern);
            DiperbaharuiTanggal.ViewCustomAttributes = "";

            // PlantAwal
            PlantAwal.ViewValue = PlantAwal.CurrentValue;
            PlantAwal.ViewCustomAttributes = "";

            // RegionAwal
            RegionAwal.ViewValue = RegionAwal.CurrentValue;
            RegionAwal.ViewValue = FormatNumber(RegionAwal.ViewValue, RegionAwal.FormatPattern);
            RegionAwal.ViewCustomAttributes = "";

            // Id
            Id.HrefValue = "";
            Id.TooltipValue = "";

            // NomorPjs
            NomorPjs.HrefValue = "";
            NomorPjs.TooltipValue = "";

            // RedirectLink
            RedirectLink.HrefValue = "";
            RedirectLink.TooltipValue = "";

            // Nama
            Nama.HrefValue = "";
            Nama.TooltipValue = "";

            // OrganizationLevel
            OrganizationLevel.HrefValue = "";
            OrganizationLevel.TooltipValue = "";

            // Region
            Region.HrefValue = "";
            Region.TooltipValue = "";

            // Plant
            Plant.HrefValue = "";
            Plant.TooltipValue = "";

            // PosisiAwal
            PosisiAwal.HrefValue = "";
            PosisiAwal.TooltipValue = "";

            // PosisiPJS
            PosisiPJS.HrefValue = "";
            PosisiPJS.TooltipValue = "";

            // LookupPosition
            LookupPosition.HrefValue = "";
            LookupPosition.TooltipValue = "";

            // TanggalMulai
            TanggalMulai.HrefValue = "";
            TanggalMulai.TooltipValue = "";

            // TanggalSelesai
            TanggalSelesai.HrefValue = "";
            TanggalSelesai.TooltipValue = "";

            // Status
            Status.HrefValue = "";
            Status.TooltipValue = "";

            // DownloadSuratTugas
            DownloadSuratTugas.HrefValue = "";
            DownloadSuratTugas.TooltipValue = "";

            // SuratTugas
            SuratTugas.HrefValue = "";
            SuratTugas.TooltipValue = "";

            // Keterangan
            Keterangan.HrefValue = "";
            Keterangan.TooltipValue = "";

            // Remaks
            Remaks.HrefValue = "";
            Remaks.TooltipValue = "";

            // DibuatOleh
            DibuatOleh.HrefValue = "";
            DibuatOleh.TooltipValue = "";

            // TanggalDibuat
            TanggalDibuat.HrefValue = "";
            TanggalDibuat.TooltipValue = "";

            // DiperbaharuiOleh
            DiperbaharuiOleh.HrefValue = "";
            DiperbaharuiOleh.TooltipValue = "";

            // DiperbaharuiTanggal
            DiperbaharuiTanggal.HrefValue = "";
            DiperbaharuiTanggal.TooltipValue = "";

            // PlantAwal
            PlantAwal.HrefValue = "";
            PlantAwal.TooltipValue = "";

            // RegionAwal
            RegionAwal.HrefValue = "";
            RegionAwal.TooltipValue = "";

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

            // Id
            Id.SetupEditAttributes();
            Id.EditValue = Id.CurrentValue;
            Id.ViewCustomAttributes = "";

            // NomorPjs
            NomorPjs.SetupEditAttributes();
            NomorPjs.EditValue = ConvertToString(NomorPjs.CurrentValue); // DN
            NomorPjs.ViewCustomAttributes = "";

            // RedirectLink
            RedirectLink.SetupEditAttributes();
            if (!RedirectLink.Raw)
                RedirectLink.CurrentValue = HtmlDecode(RedirectLink.CurrentValue);
            RedirectLink.EditValue = RedirectLink.CurrentValue;
            RedirectLink.PlaceHolder = RemoveHtml(RedirectLink.Caption);

            // Nama
            Nama.SetupEditAttributes();
            if (!Nama.Raw)
                Nama.CurrentValue = HtmlDecode(Nama.CurrentValue);
            Nama.EditValue = Nama.CurrentValue;
            Nama.PlaceHolder = RemoveHtml(Nama.Caption);

            // OrganizationLevel
            OrganizationLevel.SetupEditAttributes();
            OrganizationLevel.EditValue = OrganizationLevel.Options(true);
            OrganizationLevel.PlaceHolder = RemoveHtml(OrganizationLevel.Caption);

            // Region
            Region.SetupEditAttributes();
            Region.PlaceHolder = RemoveHtml(Region.Caption);

            // Plant
            Plant.SetupEditAttributes();
            Plant.PlaceHolder = RemoveHtml(Plant.Caption);

            // PosisiAwal
            PosisiAwal.SetupEditAttributes();
            PosisiAwal.EditValue = PosisiAwal.CurrentValue;
            PosisiAwal.PlaceHolder = RemoveHtml(PosisiAwal.Caption);

            // PosisiPJS
            PosisiPJS.SetupEditAttributes();
            PosisiPJS.EditValue = PosisiPJS.CurrentValue;
            PosisiPJS.PlaceHolder = RemoveHtml(PosisiPJS.Caption);

            // LookupPosition
            LookupPosition.SetupEditAttributes();
            LookupPosition.EditValue = LookupPosition.Options(true);
            LookupPosition.PlaceHolder = RemoveHtml(LookupPosition.Caption);

            // TanggalMulai
            TanggalMulai.SetupEditAttributes();
            TanggalMulai.EditValue = FormatDateTime(TanggalMulai.CurrentValue, TanggalMulai.FormatPattern);
            TanggalMulai.PlaceHolder = RemoveHtml(TanggalMulai.Caption);

            // TanggalSelesai
            TanggalSelesai.SetupEditAttributes();
            TanggalSelesai.EditValue = FormatDateTime(TanggalSelesai.CurrentValue, TanggalSelesai.FormatPattern);
            TanggalSelesai.PlaceHolder = RemoveHtml(TanggalSelesai.Caption);

            // Status
            Status.SetupEditAttributes();
            Status.EditValue = ConvertToString(Status.CurrentValue); // DN
            Status.ViewCustomAttributes = "";

            // DownloadSuratTugas
            DownloadSuratTugas.SetupEditAttributes();
            DownloadSuratTugas.EditValue = ConvertToString(DownloadSuratTugas.CurrentValue); // DN
            DownloadSuratTugas.ViewCustomAttributes = "";

            // SuratTugas
            SuratTugas.SetupEditAttributes();
            if (!SuratTugas.Raw)
                SuratTugas.CurrentValue = HtmlDecode(SuratTugas.CurrentValue);
            SuratTugas.EditValue = SuratTugas.CurrentValue;
            SuratTugas.PlaceHolder = RemoveHtml(SuratTugas.Caption);

            // Keterangan
            Keterangan.SetupEditAttributes();
            Keterangan.EditValue = Keterangan.CurrentValue; // DN
            Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

            // Remaks
            Remaks.SetupEditAttributes();
            Remaks.EditValue = Remaks.CurrentValue; // DN
            Remaks.PlaceHolder = RemoveHtml(Remaks.Caption);

            // DibuatOleh
            DibuatOleh.SetupEditAttributes();
            DibuatOleh.EditValue = DibuatOleh.CurrentValue;
            DibuatOleh.PlaceHolder = RemoveHtml(DibuatOleh.Caption);

            // TanggalDibuat
            TanggalDibuat.SetupEditAttributes();
            TanggalDibuat.EditValue = FormatDateTime(TanggalDibuat.CurrentValue, TanggalDibuat.FormatPattern);
            TanggalDibuat.PlaceHolder = RemoveHtml(TanggalDibuat.Caption);

            // DiperbaharuiOleh
            DiperbaharuiOleh.SetupEditAttributes();
            DiperbaharuiOleh.EditValue = DiperbaharuiOleh.CurrentValue;
            string curVal8 = ConvertToString(DiperbaharuiOleh.CurrentValue);
            if (!Empty(curVal8)) {
                if (DiperbaharuiOleh.Lookup != null && IsDictionary(DiperbaharuiOleh.Lookup?.Options) && DiperbaharuiOleh.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    DiperbaharuiOleh.EditValue = DiperbaharuiOleh.LookupCacheOption(curVal8);
                } else { // Lookup from database // DN
                    string filterWrk8 = SearchFilter(DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchExpression, "=", DiperbaharuiOleh.CurrentValue, DiperbaharuiOleh.Lookup?.GetTable()?.Fields["IdUser"].SearchDataType, "");
                    string? sqlWrk8 = DiperbaharuiOleh.Lookup?.GetSql(false, filterWrk8, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk8 = sqlWrk8 != null ? Connection.GetRows(sqlWrk8) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk8?.Count > 0 && DiperbaharuiOleh.Lookup != null) { // Lookup values found
                        var listwrk = DiperbaharuiOleh.Lookup?.RenderViewRow(rswrk8[0]);
                        DiperbaharuiOleh.EditValue = DiperbaharuiOleh.DisplayValue(listwrk);
                    } else {
                        DiperbaharuiOleh.EditValue = DiperbaharuiOleh.CurrentValue;
                    }
                }
            } else {
                DiperbaharuiOleh.EditValue = DbNullValue;
            }
            DiperbaharuiOleh.ViewCustomAttributes = "";

            // DiperbaharuiTanggal
            DiperbaharuiTanggal.SetupEditAttributes();
            DiperbaharuiTanggal.EditValue = DiperbaharuiTanggal.CurrentValue;
            DiperbaharuiTanggal.EditValue = FormatDateTime(DiperbaharuiTanggal.EditValue, DiperbaharuiTanggal.FormatPattern);
            DiperbaharuiTanggal.ViewCustomAttributes = "";

            // PlantAwal
            PlantAwal.SetupEditAttributes();
            PlantAwal.EditValue = PlantAwal.CurrentValue;
            PlantAwal.PlaceHolder = RemoveHtml(PlantAwal.Caption);

            // RegionAwal
            RegionAwal.SetupEditAttributes();
            RegionAwal.EditValue = RegionAwal.CurrentValue;
            RegionAwal.PlaceHolder = RemoveHtml(RegionAwal.Caption);
            if (!Empty(RegionAwal.EditValue) && IsNumeric(RegionAwal.EditValue))
                RegionAwal.EditValue = FormatNumber(RegionAwal.EditValue, null);

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
                        doc.ExportCaption(Id);
                        doc.ExportCaption(NomorPjs);
                        doc.ExportCaption(RedirectLink);
                        doc.ExportCaption(Nama);
                        doc.ExportCaption(OrganizationLevel);
                        doc.ExportCaption(Region);
                        doc.ExportCaption(Plant);
                        doc.ExportCaption(PosisiAwal);
                        doc.ExportCaption(PosisiPJS);
                        doc.ExportCaption(LookupPosition);
                        doc.ExportCaption(TanggalMulai);
                        doc.ExportCaption(TanggalSelesai);
                        doc.ExportCaption(Status);
                        doc.ExportCaption(DownloadSuratTugas);
                        doc.ExportCaption(SuratTugas);
                        doc.ExportCaption(Keterangan);
                        doc.ExportCaption(Remaks);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaharuiOleh);
                        doc.ExportCaption(DiperbaharuiTanggal);
                        doc.ExportCaption(PlantAwal);
                        doc.ExportCaption(RegionAwal);
                    } else {
                        doc.ExportCaption(Id);
                        doc.ExportCaption(NomorPjs);
                        doc.ExportCaption(RedirectLink);
                        doc.ExportCaption(Nama);
                        doc.ExportCaption(OrganizationLevel);
                        doc.ExportCaption(PosisiAwal);
                        doc.ExportCaption(PosisiPJS);
                        doc.ExportCaption(TanggalMulai);
                        doc.ExportCaption(TanggalSelesai);
                        doc.ExportCaption(Status);
                        doc.ExportCaption(SuratTugas);
                        doc.ExportCaption(Remaks);
                        doc.ExportCaption(DibuatOleh);
                        doc.ExportCaption(TanggalDibuat);
                        doc.ExportCaption(DiperbaharuiOleh);
                        doc.ExportCaption(DiperbaharuiTanggal);
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
                            await doc.ExportField(Id);
                            await doc.ExportField(NomorPjs);
                            await doc.ExportField(RedirectLink);
                            await doc.ExportField(Nama);
                            await doc.ExportField(OrganizationLevel);
                            await doc.ExportField(Region);
                            await doc.ExportField(Plant);
                            await doc.ExportField(PosisiAwal);
                            await doc.ExportField(PosisiPJS);
                            await doc.ExportField(LookupPosition);
                            await doc.ExportField(TanggalMulai);
                            await doc.ExportField(TanggalSelesai);
                            await doc.ExportField(Status);
                            await doc.ExportField(DownloadSuratTugas);
                            await doc.ExportField(SuratTugas);
                            await doc.ExportField(Keterangan);
                            await doc.ExportField(Remaks);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaharuiOleh);
                            await doc.ExportField(DiperbaharuiTanggal);
                            await doc.ExportField(PlantAwal);
                            await doc.ExportField(RegionAwal);
                        } else {
                            await doc.ExportField(Id);
                            await doc.ExportField(NomorPjs);
                            await doc.ExportField(RedirectLink);
                            await doc.ExportField(Nama);
                            await doc.ExportField(OrganizationLevel);
                            await doc.ExportField(PosisiAwal);
                            await doc.ExportField(PosisiPJS);
                            await doc.ExportField(TanggalMulai);
                            await doc.ExportField(TanggalSelesai);
                            await doc.ExportField(Status);
                            await doc.ExportField(SuratTugas);
                            await doc.ExportField(Remaks);
                            await doc.ExportField(DibuatOleh);
                            await doc.ExportField(TanggalDibuat);
                            await doc.ExportField(DiperbaharuiOleh);
                            await doc.ExportField(DiperbaharuiTanggal);
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
            var currentUser = CurrentUserLevel();
            var userRole = CurrentUserInfo("Rule").ToString();
            var idPosition = CurrentUserInfo("IdPosition");
            var idUser = CurrentUserInfo("IdUser");
            if (currentUser == "-1" || userRole == "15")
            {
                return;
            }
            if (idPosition == null){
                AddFilter(ref filter, "1=0");
                return;
            }
            if (userRole == "15")
            {
                string filterUserRegion = $@"
                    DibuatOleh = {idUser}
                    OR PosisiPJS IN (
                        SELECT IdPosition FROM MasterPosition
                        WHERE Role IN (14)
                    )
                ";
                AddFilter(ref filter, filterUserRegion);
                return;
            }
            else if (userRole == "14")
            {
                string filterUserRegion = $@"
                    DibuatOleh = {idUser}
                    OR PosisiPJS IN (
                        SELECT mt.IdPosition FROM MasterPosition mt
                        INNER JOIN MappingPosition mp ON mt.IdPosition = mp.IdPosition
                        WHERE mt.Role IN (10)
                        AND mp.IdRegion IN (
                            SELECT DISTINCT IdRegion FROM MappingPosition
                            WHERE IdPosition = {idPosition}
                        )
                    )
                ";
                AddFilter(ref filter, filterUserRegion);
                return;
            }
            else if (userRole == "10")
            {
                string filterUserPlant = $@"
                    DibuatOleh = {idUser}
                    OR PosisiPJS IN (
                        SELECT mt.IdPosition FROM MasterPosition mt
                        INNER JOIN MappingPosition mp ON mt.IdPosition = mp.IdPosition
                        WHERE mt.Role NOT IN (10, 14, 15)
                        AND mp.IdPlant IN (
                            SELECT DISTINCT IdPlant FROM MappingPosition
                            WHERE IdPosition = {idPosition}
                        )
                    )
                ";
                AddFilter(ref filter, filterUserPlant);
                return;
            }
            string filterUser = $"DibuatOleh = {idUser}";
            AddFilter(ref filter, filterUser);
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
            int userPjs = rs.ContainsKey("DibuatOleh") ? Convert.ToInt32(rs["DibuatOleh"].ToString()) : 0;
            int currentUserId = CurrentUserInfo("IdUser") != null ? Convert.ToInt32(CurrentUserInfo("IdUser")) : 0;
            if (userPjs != currentUserId) {
                CancelMessage = "You are not authorized to delete this PJS.";
                return false;
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
            if (!Empty(Status.CurrentValue)) {
                string warna = "#fff";
                string warnaFont = "#fff";
                switch (Status.CurrentValue.ToString()) {
                    case "Requested": 
                        warna = "#a3e0f7"; 
                        warnaFont = "#0c5460"; 
                        break;
                    case "Approved": 
                        warna = "#baffc9"; 
                        warnaFont = "#155724"; 
                        break;
                    case "Rejected": 
                        warna = "#ba313b";
                        break;
                    case "Canceled": 
                        warna = "#41464b";
                        warnaFont = "#e2e3e5"; 
                        break;
                }
                Status.ViewValue = Status.CurrentValue;
                Status.CellCssStyle =
                    $"background-color:{warna}; color:{warnaFont}; font-weight:bold; text-align:center; padding:4px 12px;";
            }
        }

        // User ID Filtering event
        public void UserIdFiltering(ref string filter) {
            // Enter your code here
        }
    }
} // End Partial class
