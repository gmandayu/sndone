namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterTangki
    /// </summary>
    [MaybeNull]
    public static MasterTangki masterTangki
    {
        get => HttpData.Resolve<MasterTangki>("MasterTangki");
        set => HttpData["MasterTangki"] = value;
    }

    /// <summary>
    /// Table class for MasterTangki
    /// </summary>
    public class MasterTangki : DbTable
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

        public readonly DbField<SqlDbType> NamaTerminal;

        public readonly DbField<SqlDbType> Plant;

        public readonly DbField<SqlDbType> Sloc;

        public readonly DbField<SqlDbType> SeqTangki;

        public readonly DbField<SqlDbType> MatNo;

        public readonly DbField<SqlDbType> TglKalibrasi;

        public readonly DbField<SqlDbType> ExpDate;

        public readonly DbField<SqlDbType> Status;

        public readonly DbField<SqlDbType> TinggiMejaUk;

        public readonly DbField<SqlDbType> MaxDipping;

        public readonly DbField<SqlDbType> MaxCapacity;

        public readonly DbField<SqlDbType> UnpumpableQty;

        public readonly DbField<SqlDbType> PumpableQty;

        public readonly DbField<SqlDbType> etlDate;

        public readonly DbField<SqlDbType> LastUpdatedBy;

        public readonly DbField<SqlDbType> lastUpdatedDate;

        // Constructor
        public MasterTangki()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "MasterTangki";
            Name = "MasterTangki";
            Type = "TABLE";
            UpdateTable = "dbo.MasterTangki"; // Update Table
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
                CustomMessage = Language.FieldPhrase("MasterTangki", "id", "CustomMsg"),
                IsUpload = false
            };
            id.Raw = true;
            Fields.Add("id", id);

            // NamaTerminal
            NamaTerminal = new(this, "x_NamaTerminal", 202, SqlDbType.NVarChar) {
                Name = "NamaTerminal",
                Expression = "[NamaTerminal]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NamaTerminal]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaTerminal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "NamaTerminal", "CustomMsg"),
                IsUpload = false
            };
            NamaTerminal.Lookup = new Lookup<DbField>(NamaTerminal, "MasterTangki", true, "NamaTerminal", new List<string> {"NamaTerminal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("NamaTerminal", NamaTerminal);

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
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "Plant", "CustomMsg"),
                IsUpload = false
            };
            Plant.Lookup = new Lookup<DbField>(Plant, "MasterPlant", true, "Plant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, Plant) + "',[Nama_Terminal])");
            Fields.Add("Plant", Plant);

            // Sloc
            Sloc = new(this, "x_Sloc", 202, SqlDbType.NVarChar) {
                Name = "Sloc",
                Expression = "[Sloc]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Sloc]",
                DateTimeFormat = -1,
                VirtualExpression = "[Sloc]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "Sloc", "CustomMsg"),
                IsUpload = false
            };
            Sloc.Lookup = new Lookup<DbField>(Sloc, "MasterTangki", true, "Sloc", new List<string> {"Sloc", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Sloc", Sloc);

            // SeqTangki
            SeqTangki = new(this, "x_SeqTangki", 202, SqlDbType.NVarChar) {
                Name = "SeqTangki",
                Expression = "[SeqTangki]",
                UseBasicSearch = true,
                BasicSearchExpression = "[SeqTangki]",
                DateTimeFormat = -1,
                VirtualExpression = "[SeqTangki]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "SeqTangki", "CustomMsg"),
                IsUpload = false
            };
            SeqTangki.Lookup = new Lookup<DbField>(SeqTangki, "MasterTangki", true, "SeqTangki", new List<string> {"SeqTangki", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("SeqTangki", SeqTangki);

            // MatNo
            MatNo = new(this, "x_MatNo", 202, SqlDbType.NVarChar) {
                Name = "MatNo",
                Expression = "[MatNo]",
                UseBasicSearch = true,
                BasicSearchExpression = "[MatNo]",
                DateTimeFormat = -1,
                VirtualExpression = "[MatNo]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "MatNo", "CustomMsg"),
                IsUpload = false
            };
            MatNo.Lookup = new Lookup<DbField>(MatNo, "MasterTangki", true, "MatNo", new List<string> {"MatNo", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("MatNo", MatNo);

            // TglKalibrasi
            TglKalibrasi = new(this, "x_TglKalibrasi", 133, SqlDbType.Date) {
                Name = "TglKalibrasi",
                Expression = "[TglKalibrasi]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[TglKalibrasi]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[TglKalibrasi]",
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
                CustomMessage = Language.FieldPhrase("MasterTangki", "TglKalibrasi", "CustomMsg"),
                IsUpload = false
            };
            TglKalibrasi.Raw = true;
            TglKalibrasi.Lookup = new Lookup<DbField>(TglKalibrasi, "MasterTangki", true, "TglKalibrasi", new List<string> {"TglKalibrasi", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TglKalibrasi", TglKalibrasi);

            // ExpDate
            ExpDate = new(this, "x_ExpDate", 133, SqlDbType.Date) {
                Name = "ExpDate",
                Expression = "[ExpDate]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[ExpDate]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[ExpDate]",
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
                CustomMessage = Language.FieldPhrase("MasterTangki", "ExpDate", "CustomMsg"),
                IsUpload = false
            };
            ExpDate.Raw = true;
            ExpDate.Lookup = new Lookup<DbField>(ExpDate, "MasterTangki", true, "ExpDate", new List<string> {"ExpDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("ExpDate", ExpDate);

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
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                OptionCount = 2,
                SearchOperators = ["=", "<>", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "Status", "CustomMsg"),
                IsUpload = false
            };
            Status.Lookup = new Lookup<DbField>(Status, "MasterTangki", true, "Status", new List<string> {"Status", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Status", Status);

            // TinggiMejaUk
            TinggiMejaUk = new(this, "x_TinggiMejaUk", 202, SqlDbType.NVarChar) {
                Name = "TinggiMejaUk",
                Expression = "[TinggiMejaUk]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TinggiMejaUk]",
                DateTimeFormat = -1,
                VirtualExpression = "[TinggiMejaUk]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "TinggiMejaUk", "CustomMsg"),
                IsUpload = false
            };
            TinggiMejaUk.Lookup = new Lookup<DbField>(TinggiMejaUk, "MasterTangki", true, "TinggiMejaUk", new List<string> {"TinggiMejaUk", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("TinggiMejaUk", TinggiMejaUk);

            // MaxDipping
            MaxDipping = new(this, "x_MaxDipping", 202, SqlDbType.NVarChar) {
                Name = "MaxDipping",
                Expression = "[MaxDipping]",
                UseBasicSearch = true,
                BasicSearchExpression = "[MaxDipping]",
                DateTimeFormat = -1,
                VirtualExpression = "[MaxDipping]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "MaxDipping", "CustomMsg"),
                IsUpload = false
            };
            MaxDipping.Lookup = new Lookup<DbField>(MaxDipping, "MasterTangki", true, "MaxDipping", new List<string> {"MaxDipping", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("MaxDipping", MaxDipping);

            // MaxCapacity
            MaxCapacity = new(this, "x_MaxCapacity", 202, SqlDbType.NVarChar) {
                Name = "MaxCapacity",
                Expression = "[MaxCapacity]",
                UseBasicSearch = true,
                BasicSearchExpression = "[MaxCapacity]",
                DateTimeFormat = -1,
                VirtualExpression = "[MaxCapacity]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "MaxCapacity", "CustomMsg"),
                IsUpload = false
            };
            MaxCapacity.Lookup = new Lookup<DbField>(MaxCapacity, "MasterTangki", true, "MaxCapacity", new List<string> {"MaxCapacity", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("MaxCapacity", MaxCapacity);

            // UnpumpableQty
            UnpumpableQty = new(this, "x_UnpumpableQty", 202, SqlDbType.NVarChar) {
                Name = "UnpumpableQty",
                Expression = "[UnpumpableQty]",
                UseBasicSearch = true,
                BasicSearchExpression = "[UnpumpableQty]",
                DateTimeFormat = -1,
                VirtualExpression = "[UnpumpableQty]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "UnpumpableQty", "CustomMsg"),
                IsUpload = false
            };
            UnpumpableQty.Lookup = new Lookup<DbField>(UnpumpableQty, "MasterTangki", true, "UnpumpableQty", new List<string> {"UnpumpableQty", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("UnpumpableQty", UnpumpableQty);

            // PumpableQty
            PumpableQty = new(this, "x_PumpableQty", 202, SqlDbType.NVarChar) {
                Name = "PumpableQty",
                Expression = "[PumpableQty]",
                UseBasicSearch = true,
                BasicSearchExpression = "[PumpableQty]",
                DateTimeFormat = -1,
                VirtualExpression = "[PumpableQty]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterTangki", "PumpableQty", "CustomMsg"),
                IsUpload = false
            };
            PumpableQty.Lookup = new Lookup<DbField>(PumpableQty, "MasterTangki", true, "PumpableQty", new List<string> {"PumpableQty", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PumpableQty", PumpableQty);

            // etlDate
            etlDate = new(this, "x_etlDate", 135, SqlDbType.DateTime) {
                Name = "etlDate",
                Expression = "[etlDate]",
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
                CustomMessage = Language.FieldPhrase("MasterTangki", "etlDate", "CustomMsg"),
                IsUpload = false
            };
            etlDate.Raw = true;
            etlDate.Lookup = new Lookup<DbField>(etlDate, "MasterTangki", true, "etlDate", new List<string> {"etlDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("MasterTangki", "LastUpdatedBy", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedBy.Lookup = new Lookup<DbField>(LastUpdatedBy, "MasterTangki", true, "LastUpdatedBy", new List<string> {"LastUpdatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("MasterTangki", "lastUpdatedDate", "CustomMsg"),
                IsUpload = false
            };
            lastUpdatedDate.Raw = true;
            lastUpdatedDate.Lookup = new Lookup<DbField>(lastUpdatedDate, "MasterTangki", true, "lastUpdatedDate", new List<string> {"lastUpdatedDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("lastUpdatedDate", lastUpdatedDate);

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
            get => _sqlFrom ?? "dbo.MasterTangki";
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterTangki type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterTangki type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterTangki type", "data");
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
                NamaTerminal.DbValue = row["NamaTerminal"]; // Set DB value only
                Plant.DbValue = row["Plant"]; // Set DB value only
                Sloc.DbValue = row["Sloc"]; // Set DB value only
                SeqTangki.DbValue = row["SeqTangki"]; // Set DB value only
                MatNo.DbValue = row["MatNo"]; // Set DB value only
                TglKalibrasi.DbValue = row["TglKalibrasi"]; // Set DB value only
                ExpDate.DbValue = row["ExpDate"]; // Set DB value only
                Status.DbValue = row["Status"]; // Set DB value only
                TinggiMejaUk.DbValue = row["TinggiMejaUk"]; // Set DB value only
                MaxDipping.DbValue = row["MaxDipping"]; // Set DB value only
                MaxCapacity.DbValue = row["MaxCapacity"]; // Set DB value only
                UnpumpableQty.DbValue = row["UnpumpableQty"]; // Set DB value only
                PumpableQty.DbValue = row["PumpableQty"]; // Set DB value only
                etlDate.DbValue = row["etlDate"]; // Set DB value only
                LastUpdatedBy.DbValue = row["LastUpdatedBy"]; // Set DB value only
                lastUpdatedDate.DbValue = row["lastUpdatedDate"]; // Set DB value only
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
                    return "MasterTangkiList";
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
                "MasterTangkiView" => Language.Phrase("View"),
                "MasterTangkiEdit" => Language.Phrase("Edit"),
                "MasterTangkiAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "MasterTangkiList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "MasterTangkiView",
                Config.ApiAddAction => "MasterTangkiAdd",
                Config.ApiEditAction => "MasterTangkiEdit",
                Config.ApiDeleteAction => "MasterTangkiDelete",
                Config.ApiListAction => "MasterTangkiList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "MasterTangkiView",
                Config.ApiAddAction => "MasterTangkiAdd",
                Config.ApiEditAction => "MasterTangkiEdit",
                Config.ApiDeleteAction => "MasterTangkiDelete",
                Config.ApiListAction => "MasterTangkiList",
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
        public string ListUrl => "MasterTangkiList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("MasterTangkiView", parm);
            else
                url = KeyUrl("MasterTangkiView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "MasterTangkiAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "MasterTangkiAdd?" + parm;
            else
                url = "MasterTangkiAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("MasterTangkiEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("MasterTangkiList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("MasterTangkiAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("MasterTangkiList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("MasterTangkiDelete", parm)); // DN
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
            NamaTerminal.SetDbValue(row["NamaTerminal"]);
            Plant.SetDbValue(row["Plant"]);
            Sloc.SetDbValue(row["Sloc"]);
            SeqTangki.SetDbValue(row["SeqTangki"]);
            MatNo.SetDbValue(row["MatNo"]);
            TglKalibrasi.SetDbValue(row["TglKalibrasi"]);
            ExpDate.SetDbValue(row["ExpDate"]);
            Status.SetDbValue(row["Status"]);
            TinggiMejaUk.SetDbValue(row["TinggiMejaUk"]);
            MaxDipping.SetDbValue(row["MaxDipping"]);
            MaxCapacity.SetDbValue(row["MaxCapacity"]);
            UnpumpableQty.SetDbValue(row["UnpumpableQty"]);
            PumpableQty.SetDbValue(row["PumpableQty"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "MasterTangkiList";
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

            // NamaTerminal

            // Plant

            // Sloc

            // SeqTangki

            // MatNo

            // TglKalibrasi

            // ExpDate

            // Status

            // TinggiMejaUk

            // MaxDipping

            // MaxCapacity

            // UnpumpableQty

            // PumpableQty

            // etlDate

            // LastUpdatedBy

            // lastUpdatedDate

            // id
            id.ViewValue = id.CurrentValue;
            id.ViewCustomAttributes = "";

            // NamaTerminal
            NamaTerminal.ViewValue = ConvertToString(NamaTerminal.CurrentValue); // DN
            NamaTerminal.ViewCustomAttributes = "";

            // Plant

            // awallookupbung
            string curVal = ConvertToString(Plant.CurrentValue);
            Plant.ViewValue = Empty(curVal) ? DbNullValue : Plant.CurrentValue;
            if (!Empty(curVal)) {
                if (Plant.Lookup != null && IsDictionary(Plant.Lookup?.Options) && Plant.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Plant.ViewValue = Plant.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    string filterWrk = SearchFilter(Plant.Lookup?.GetTable()?.Fields["Plant"].SearchExpression, "=", Plant.CurrentValue, Plant.Lookup?.GetTable()?.Fields["Plant"].SearchDataType, "");
                    string? sqlWrk = Plant.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && Plant.Lookup != null) { // Lookup values found
                        var listwrk = Plant.Lookup?.RenderViewRow(rswrk[0]);
                        Plant.ViewValue = Plant.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            Plant.ViewCustomAttributes = "";

            // Sloc
            Sloc.ViewValue = ConvertToString(Sloc.CurrentValue); // DN
            Sloc.ViewCustomAttributes = "";

            // SeqTangki
            SeqTangki.ViewValue = ConvertToString(SeqTangki.CurrentValue); // DN
            SeqTangki.ViewCustomAttributes = "";

            // MatNo
            MatNo.ViewValue = ConvertToString(MatNo.CurrentValue); // DN
            MatNo.ViewCustomAttributes = "";

            // TglKalibrasi
            TglKalibrasi.ViewValue = TglKalibrasi.CurrentValue;
            TglKalibrasi.ViewValue = FormatDateTime(TglKalibrasi.ViewValue, TglKalibrasi.FormatPattern);
            TglKalibrasi.ViewCustomAttributes = "";

            // ExpDate
            ExpDate.ViewValue = ExpDate.CurrentValue;
            ExpDate.ViewValue = FormatDateTime(ExpDate.ViewValue, ExpDate.FormatPattern);
            ExpDate.ViewCustomAttributes = "";

            // Status
            if (!Empty(Status.CurrentValue)) {
                Status.ViewValue = Status.OptionCaption(ConvertToString(Status.CurrentValue));
            } else {
                Status.ViewValue = DbNullValue;
            }
            Status.ViewCustomAttributes = "";

            // TinggiMejaUk
            TinggiMejaUk.ViewValue = ConvertToString(TinggiMejaUk.CurrentValue); // DN
            TinggiMejaUk.ViewCustomAttributes = "";

            // MaxDipping
            MaxDipping.ViewValue = ConvertToString(MaxDipping.CurrentValue); // DN
            MaxDipping.ViewCustomAttributes = "";

            // MaxCapacity
            MaxCapacity.ViewValue = ConvertToString(MaxCapacity.CurrentValue); // DN
            MaxCapacity.ViewCustomAttributes = "";

            // UnpumpableQty
            UnpumpableQty.ViewValue = ConvertToString(UnpumpableQty.CurrentValue); // DN
            UnpumpableQty.ViewCustomAttributes = "";

            // PumpableQty
            PumpableQty.ViewValue = ConvertToString(PumpableQty.CurrentValue); // DN
            PumpableQty.ViewCustomAttributes = "";

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

            // id
            id.HrefValue = "";
            id.TooltipValue = "";

            // NamaTerminal
            NamaTerminal.HrefValue = "";
            NamaTerminal.TooltipValue = "";

            // Plant
            Plant.HrefValue = "";
            Plant.TooltipValue = "";

            // Sloc
            Sloc.HrefValue = "";
            Sloc.TooltipValue = "";

            // SeqTangki
            SeqTangki.HrefValue = "";
            SeqTangki.TooltipValue = "";

            // MatNo
            MatNo.HrefValue = "";
            MatNo.TooltipValue = "";

            // TglKalibrasi
            TglKalibrasi.HrefValue = "";
            TglKalibrasi.TooltipValue = "";

            // ExpDate
            ExpDate.HrefValue = "";
            ExpDate.TooltipValue = "";

            // Status
            Status.HrefValue = "";
            Status.TooltipValue = "";

            // TinggiMejaUk
            TinggiMejaUk.HrefValue = "";
            TinggiMejaUk.TooltipValue = "";

            // MaxDipping
            MaxDipping.HrefValue = "";
            MaxDipping.TooltipValue = "";

            // MaxCapacity
            MaxCapacity.HrefValue = "";
            MaxCapacity.TooltipValue = "";

            // UnpumpableQty
            UnpumpableQty.HrefValue = "";
            UnpumpableQty.TooltipValue = "";

            // PumpableQty
            PumpableQty.HrefValue = "";
            PumpableQty.TooltipValue = "";

            // etlDate
            etlDate.HrefValue = "";
            etlDate.TooltipValue = "";

            // LastUpdatedBy
            LastUpdatedBy.HrefValue = "";
            LastUpdatedBy.TooltipValue = "";

            // lastUpdatedDate
            lastUpdatedDate.HrefValue = "";
            lastUpdatedDate.TooltipValue = "";

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

            // NamaTerminal
            NamaTerminal.SetupEditAttributes();
            if (!NamaTerminal.Raw)
                NamaTerminal.CurrentValue = HtmlDecode(NamaTerminal.CurrentValue);
            NamaTerminal.EditValue = NamaTerminal.CurrentValue;
            NamaTerminal.PlaceHolder = RemoveHtml(NamaTerminal.Caption);

            // Plant
            Plant.SetupEditAttributes();
            Plant.PlaceHolder = RemoveHtml(Plant.Caption);

            // Sloc
            Sloc.SetupEditAttributes();
            if (!Sloc.Raw)
                Sloc.CurrentValue = HtmlDecode(Sloc.CurrentValue);
            Sloc.EditValue = Sloc.CurrentValue;
            Sloc.PlaceHolder = RemoveHtml(Sloc.Caption);

            // SeqTangki
            SeqTangki.SetupEditAttributes();
            if (!SeqTangki.Raw)
                SeqTangki.CurrentValue = HtmlDecode(SeqTangki.CurrentValue);
            SeqTangki.EditValue = SeqTangki.CurrentValue;
            SeqTangki.PlaceHolder = RemoveHtml(SeqTangki.Caption);

            // MatNo
            MatNo.SetupEditAttributes();
            if (!MatNo.Raw)
                MatNo.CurrentValue = HtmlDecode(MatNo.CurrentValue);
            MatNo.EditValue = MatNo.CurrentValue;
            MatNo.PlaceHolder = RemoveHtml(MatNo.Caption);

            // TglKalibrasi
            TglKalibrasi.SetupEditAttributes();
            TglKalibrasi.EditValue = FormatDateTime(TglKalibrasi.CurrentValue, TglKalibrasi.FormatPattern);
            TglKalibrasi.PlaceHolder = RemoveHtml(TglKalibrasi.Caption);

            // ExpDate
            ExpDate.SetupEditAttributes();
            ExpDate.EditValue = FormatDateTime(ExpDate.CurrentValue, ExpDate.FormatPattern);
            ExpDate.PlaceHolder = RemoveHtml(ExpDate.Caption);

            // Status
            Status.SetupEditAttributes();
            Status.EditValue = Status.Options(true);
            Status.PlaceHolder = RemoveHtml(Status.Caption);

            // TinggiMejaUk
            TinggiMejaUk.SetupEditAttributes();
            if (!TinggiMejaUk.Raw)
                TinggiMejaUk.CurrentValue = HtmlDecode(TinggiMejaUk.CurrentValue);
            TinggiMejaUk.EditValue = TinggiMejaUk.CurrentValue;
            TinggiMejaUk.PlaceHolder = RemoveHtml(TinggiMejaUk.Caption);

            // MaxDipping
            MaxDipping.SetupEditAttributes();
            if (!MaxDipping.Raw)
                MaxDipping.CurrentValue = HtmlDecode(MaxDipping.CurrentValue);
            MaxDipping.EditValue = MaxDipping.CurrentValue;
            MaxDipping.PlaceHolder = RemoveHtml(MaxDipping.Caption);

            // MaxCapacity
            MaxCapacity.SetupEditAttributes();
            if (!MaxCapacity.Raw)
                MaxCapacity.CurrentValue = HtmlDecode(MaxCapacity.CurrentValue);
            MaxCapacity.EditValue = MaxCapacity.CurrentValue;
            MaxCapacity.PlaceHolder = RemoveHtml(MaxCapacity.Caption);

            // UnpumpableQty
            UnpumpableQty.SetupEditAttributes();
            if (!UnpumpableQty.Raw)
                UnpumpableQty.CurrentValue = HtmlDecode(UnpumpableQty.CurrentValue);
            UnpumpableQty.EditValue = UnpumpableQty.CurrentValue;
            UnpumpableQty.PlaceHolder = RemoveHtml(UnpumpableQty.Caption);

            // PumpableQty
            PumpableQty.SetupEditAttributes();
            if (!PumpableQty.Raw)
                PumpableQty.CurrentValue = HtmlDecode(PumpableQty.CurrentValue);
            PumpableQty.EditValue = PumpableQty.CurrentValue;
            PumpableQty.PlaceHolder = RemoveHtml(PumpableQty.Caption);

            // etlDate
            etlDate.SetupEditAttributes();
            etlDate.EditValue = FormatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            etlDate.PlaceHolder = RemoveHtml(etlDate.Caption);

            // LastUpdatedBy
            LastUpdatedBy.SetupEditAttributes();
            if (!LastUpdatedBy.Raw)
                LastUpdatedBy.CurrentValue = HtmlDecode(LastUpdatedBy.CurrentValue);
            LastUpdatedBy.EditValue = LastUpdatedBy.CurrentValue;
            LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

            // lastUpdatedDate
            lastUpdatedDate.SetupEditAttributes();
            lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.CurrentValue, lastUpdatedDate.FormatPattern);
            lastUpdatedDate.PlaceHolder = RemoveHtml(lastUpdatedDate.Caption);

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
                        doc.ExportCaption(id);
                        doc.ExportCaption(NamaTerminal);
                        doc.ExportCaption(Plant);
                        doc.ExportCaption(Sloc);
                        doc.ExportCaption(SeqTangki);
                        doc.ExportCaption(MatNo);
                        doc.ExportCaption(TglKalibrasi);
                        doc.ExportCaption(ExpDate);
                        doc.ExportCaption(Status);
                        doc.ExportCaption(TinggiMejaUk);
                        doc.ExportCaption(MaxDipping);
                        doc.ExportCaption(MaxCapacity);
                        doc.ExportCaption(UnpumpableQty);
                        doc.ExportCaption(PumpableQty);
                        doc.ExportCaption(etlDate);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(lastUpdatedDate);
                    } else {
                        doc.ExportCaption(id);
                        doc.ExportCaption(NamaTerminal);
                        doc.ExportCaption(Plant);
                        doc.ExportCaption(Sloc);
                        doc.ExportCaption(SeqTangki);
                        doc.ExportCaption(MatNo);
                        doc.ExportCaption(TglKalibrasi);
                        doc.ExportCaption(ExpDate);
                        doc.ExportCaption(Status);
                        doc.ExportCaption(TinggiMejaUk);
                        doc.ExportCaption(MaxDipping);
                        doc.ExportCaption(MaxCapacity);
                        doc.ExportCaption(UnpumpableQty);
                        doc.ExportCaption(PumpableQty);
                        doc.ExportCaption(etlDate);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(lastUpdatedDate);
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
                            await doc.ExportField(id);
                            await doc.ExportField(NamaTerminal);
                            await doc.ExportField(Plant);
                            await doc.ExportField(Sloc);
                            await doc.ExportField(SeqTangki);
                            await doc.ExportField(MatNo);
                            await doc.ExportField(TglKalibrasi);
                            await doc.ExportField(ExpDate);
                            await doc.ExportField(Status);
                            await doc.ExportField(TinggiMejaUk);
                            await doc.ExportField(MaxDipping);
                            await doc.ExportField(MaxCapacity);
                            await doc.ExportField(UnpumpableQty);
                            await doc.ExportField(PumpableQty);
                            await doc.ExportField(etlDate);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(lastUpdatedDate);
                        } else {
                            await doc.ExportField(id);
                            await doc.ExportField(NamaTerminal);
                            await doc.ExportField(Plant);
                            await doc.ExportField(Sloc);
                            await doc.ExportField(SeqTangki);
                            await doc.ExportField(MatNo);
                            await doc.ExportField(TglKalibrasi);
                            await doc.ExportField(ExpDate);
                            await doc.ExportField(Status);
                            await doc.ExportField(TinggiMejaUk);
                            await doc.ExportField(MaxDipping);
                            await doc.ExportField(MaxCapacity);
                            await doc.ExportField(UnpumpableQty);
                            await doc.ExportField(PumpableQty);
                            await doc.ExportField(etlDate);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(lastUpdatedDate);
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
            rsnew["etlDate"] = DateTime.Now;
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
