namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// subAktivitasNilaiBLdanAlrtw
    /// </summary>
    [MaybeNull]
    public static SubAktivitasNilaiBLdanAlrtw subAktivitasNilaiBLdanAlrtw
    {
        get => HttpData.Resolve<SubAktivitasNilaiBLdanAlrtw>("SubAktivitasNilaiBLdanALRTW");
        set => HttpData["SubAktivitasNilaiBLdanALRTW"] = value;
    }

    /// <summary>
    /// Table class for SubAktivitasNilaiBLdanALRTW
    /// </summary>
    public class SubAktivitasNilaiBLdanAlrtw : DbTable
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

        public readonly DbField<SqlDbType> idAktifitas;

        public readonly DbField<SqlDbType> StatusAktivitas;

        public readonly DbField<SqlDbType> BL_KL_Obs;

        public readonly DbField<SqlDbType> BL_KL_15;

        public readonly DbField<SqlDbType> BL_Barrels;

        public readonly DbField<SqlDbType> BL_LT;

        public readonly DbField<SqlDbType> BL_MT;

        public readonly DbField<SqlDbType> AL_KL_Obs;

        public readonly DbField<SqlDbType> AL_KL_15;

        public readonly DbField<SqlDbType> AL_Barrels;

        public readonly DbField<SqlDbType> AL_LT;

        public readonly DbField<SqlDbType> AL_MT;

        public readonly DbField<SqlDbType> userInput;

        public readonly DbField<SqlDbType> etlDate;

        public readonly DbField<SqlDbType> idProses;

        public readonly DbField<SqlDbType> LastUpdatedBy;

        public readonly DbField<SqlDbType> lastUpdatedDate;

        public readonly DbField<SqlDbType> NoReferensi;

        // Constructor
        public SubAktivitasNilaiBLdanAlrtw()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "SubAktivitasNilaiBLdanALRTW";
            Name = "SubAktivitasNilaiBLdanALRTW";
            Type = "TABLE";
            UpdateTable = "dbo.SubAktivitasNilaiBLdanALRTW"; // Update Table
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
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "id", "CustomMsg"),
                IsUpload = false
            };
            id.Raw = true;
            Fields.Add("id", id);

            // idAktifitas
            idAktifitas = new(this, "x_idAktifitas", 3, SqlDbType.Int) {
                Name = "idAktifitas",
                Expression = "[idAktifitas]",
                BasicSearchExpression = "CAST([idAktifitas] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[idAktifitas]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "idAktifitas", "CustomMsg"),
                IsUpload = false
            };
            idAktifitas.Raw = true;
            idAktifitas.Lookup = new Lookup<DbField>(idAktifitas, "Aktivitas", false, "IdAktivitas", new List<string> {"NamaAktivitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaAktivitas]");
            Fields.Add("idAktifitas", idAktifitas);

            // StatusAktivitas
            StatusAktivitas = new(this, "x_StatusAktivitas", 3, SqlDbType.Int) {
                Name = "StatusAktivitas",
                Expression = "idAktifitas",
                BasicSearchExpression = "CAST(idAktifitas AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "idAktifitas",
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
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "StatusAktivitas", "CustomMsg"),
                IsUpload = false
            };
            StatusAktivitas.Raw = true;
            StatusAktivitas.Lookup = new Lookup<DbField>(StatusAktivitas, "Aktivitas", false, "IdAktivitas", new List<string> {"StatusAktivitas", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[StatusAktivitas]");
            Fields.Add("StatusAktivitas", StatusAktivitas);

            // BL_KL_Obs
            BL_KL_Obs = new(this, "x_BL_KL_Obs", 202, SqlDbType.NVarChar) {
                Name = "BL_KL_Obs",
                Expression = "[BL_KL_Obs]",
                UseBasicSearch = true,
                BasicSearchExpression = "[BL_KL_Obs]",
                DateTimeFormat = -1,
                VirtualExpression = "[BL_KL_Obs]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "BL_KL_Obs", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BL_KL_Obs", BL_KL_Obs);

            // BL_KL_15
            BL_KL_15 = new(this, "x_BL_KL_15", 202, SqlDbType.NVarChar) {
                Name = "BL_KL_15",
                Expression = "[BL_KL_15]",
                UseBasicSearch = true,
                BasicSearchExpression = "[BL_KL_15]",
                DateTimeFormat = -1,
                VirtualExpression = "[BL_KL_15]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "BL_KL_15", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BL_KL_15", BL_KL_15);

            // BL_Barrels
            BL_Barrels = new(this, "x_BL_Barrels", 202, SqlDbType.NVarChar) {
                Name = "BL_Barrels",
                Expression = "[BL_Barrels]",
                UseBasicSearch = true,
                BasicSearchExpression = "[BL_Barrels]",
                DateTimeFormat = -1,
                VirtualExpression = "[BL_Barrels]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "BL_Barrels", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BL_Barrels", BL_Barrels);

            // BL_LT
            BL_LT = new(this, "x_BL_LT", 202, SqlDbType.NVarChar) {
                Name = "BL_LT",
                Expression = "[BL_LT]",
                UseBasicSearch = true,
                BasicSearchExpression = "[BL_LT]",
                DateTimeFormat = -1,
                VirtualExpression = "[BL_LT]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "BL_LT", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BL_LT", BL_LT);

            // BL_MT
            BL_MT = new(this, "x_BL_MT", 202, SqlDbType.NVarChar) {
                Name = "BL_MT",
                Expression = "[BL_MT]",
                UseBasicSearch = true,
                BasicSearchExpression = "[BL_MT]",
                DateTimeFormat = -1,
                VirtualExpression = "[BL_MT]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "BL_MT", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BL_MT", BL_MT);

            // AL_KL_Obs
            AL_KL_Obs = new(this, "x_AL_KL_Obs", 202, SqlDbType.NVarChar) {
                Name = "AL_KL_Obs",
                Expression = "[AL_KL_Obs]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AL_KL_Obs]",
                DateTimeFormat = -1,
                VirtualExpression = "[AL_KL_Obs]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "AL_KL_Obs", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AL_KL_Obs", AL_KL_Obs);

            // AL_KL_15
            AL_KL_15 = new(this, "x_AL_KL_15", 202, SqlDbType.NVarChar) {
                Name = "AL_KL_15",
                Expression = "[AL_KL_15]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AL_KL_15]",
                DateTimeFormat = -1,
                VirtualExpression = "[AL_KL_15]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "AL_KL_15", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AL_KL_15", AL_KL_15);

            // AL_Barrels
            AL_Barrels = new(this, "x_AL_Barrels", 202, SqlDbType.NVarChar) {
                Name = "AL_Barrels",
                Expression = "[AL_Barrels]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AL_Barrels]",
                DateTimeFormat = -1,
                VirtualExpression = "[AL_Barrels]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "AL_Barrels", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AL_Barrels", AL_Barrels);

            // AL_LT
            AL_LT = new(this, "x_AL_LT", 202, SqlDbType.NVarChar) {
                Name = "AL_LT",
                Expression = "[AL_LT]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AL_LT]",
                DateTimeFormat = -1,
                VirtualExpression = "[AL_LT]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "AL_LT", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AL_LT", AL_LT);

            // AL_MT
            AL_MT = new(this, "x_AL_MT", 202, SqlDbType.NVarChar) {
                Name = "AL_MT",
                Expression = "[AL_MT]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AL_MT]",
                DateTimeFormat = -1,
                VirtualExpression = "[AL_MT]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "AL_MT", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AL_MT", AL_MT);

            // userInput
            userInput = new(this, "x_userInput", 202, SqlDbType.NVarChar) {
                Name = "userInput",
                Expression = "[userInput]",
                UseBasicSearch = true,
                BasicSearchExpression = "[userInput]",
                DateTimeFormat = -1,
                VirtualExpression = "[userInput]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "userInput", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("userInput", userInput);

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
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "etlDate", "CustomMsg"),
                IsUpload = false
            };
            etlDate.Raw = true;
            Fields.Add("etlDate", etlDate);

            // idProses
            idProses = new(this, "x_idProses", 3, SqlDbType.Int) {
                Name = "idProses",
                Expression = "[idProses]",
                BasicSearchExpression = "CAST([idProses] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[idProses]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "idProses", "CustomMsg"),
                IsUpload = false
            };
            idProses.Raw = true;
            idProses.Lookup = new Lookup<DbField>(idProses, "Proses", false, "IdProses", new List<string> {"NamaProses", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "[NamaProses]");
            Fields.Add("idProses", idProses);

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
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "LastUpdatedBy", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("LastUpdatedBy", LastUpdatedBy);

            // lastUpdatedDate
            lastUpdatedDate = new(this, "x_lastUpdatedDate", 135, SqlDbType.DateTime) {
                Name = "lastUpdatedDate",
                Expression = "[lastUpdatedDate]",
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
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "lastUpdatedDate", "CustomMsg"),
                IsUpload = false
            };
            lastUpdatedDate.Raw = true;
            Fields.Add("lastUpdatedDate", lastUpdatedDate);

            // NoReferensi
            NoReferensi = new(this, "x_NoReferensi", 202, SqlDbType.NVarChar) {
                Name = "NoReferensi",
                Expression = "[NoReferensi]",
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
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("SubAktivitasNilaiBLdanALRTW", "NoReferensi", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NoReferensi", NoReferensi);

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
            get => _sqlFrom ?? "dbo.SubAktivitasNilaiBLdanALRTW";
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
                string select = "*, idAktifitas AS [StatusAktivitas]";
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.SubAktivitasNilaiBldanAlrtw type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.SubAktivitasNilaiBldanAlrtw type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.SubAktivitasNilaiBldanAlrtw type", "data");
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
                idAktifitas.DbValue = row["idAktifitas"]; // Set DB value only
                StatusAktivitas.DbValue = row["StatusAktivitas"]; // Set DB value only
                BL_KL_Obs.DbValue = row["BL_KL_Obs"]; // Set DB value only
                BL_KL_15.DbValue = row["BL_KL_15"]; // Set DB value only
                BL_Barrels.DbValue = row["BL_Barrels"]; // Set DB value only
                BL_LT.DbValue = row["BL_LT"]; // Set DB value only
                BL_MT.DbValue = row["BL_MT"]; // Set DB value only
                AL_KL_Obs.DbValue = row["AL_KL_Obs"]; // Set DB value only
                AL_KL_15.DbValue = row["AL_KL_15"]; // Set DB value only
                AL_Barrels.DbValue = row["AL_Barrels"]; // Set DB value only
                AL_LT.DbValue = row["AL_LT"]; // Set DB value only
                AL_MT.DbValue = row["AL_MT"]; // Set DB value only
                userInput.DbValue = row["userInput"]; // Set DB value only
                etlDate.DbValue = row["etlDate"]; // Set DB value only
                idProses.DbValue = row["idProses"]; // Set DB value only
                LastUpdatedBy.DbValue = row["LastUpdatedBy"]; // Set DB value only
                lastUpdatedDate.DbValue = row["lastUpdatedDate"]; // Set DB value only
                NoReferensi.DbValue = row["NoReferensi"]; // Set DB value only
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
                    return "SubAktivitasNilaiBLdanAlrtwList";
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
                "SubAktivitasNilaiBLdanAlrtwView" => Language.Phrase("View"),
                "SubAktivitasNilaiBLdanAlrtwEdit" => Language.Phrase("Edit"),
                "SubAktivitasNilaiBLdanAlrtwAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "SubAktivitasNilaiBLdanAlrtwList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "SubAktivitasNilaiBLdanAlrtwView",
                Config.ApiAddAction => "SubAktivitasNilaiBLdanAlrtwAdd",
                Config.ApiEditAction => "SubAktivitasNilaiBLdanAlrtwEdit",
                Config.ApiDeleteAction => "SubAktivitasNilaiBLdanAlrtwDelete",
                Config.ApiListAction => "SubAktivitasNilaiBLdanAlrtwList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "SubAktivitasNilaiBLdanAlrtwView",
                Config.ApiAddAction => "SubAktivitasNilaiBLdanAlrtwAdd",
                Config.ApiEditAction => "SubAktivitasNilaiBLdanAlrtwEdit",
                Config.ApiDeleteAction => "SubAktivitasNilaiBLdanAlrtwDelete",
                Config.ApiListAction => "SubAktivitasNilaiBLdanAlrtwList",
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
        public string ListUrl => "SubAktivitasNilaiBLdanAlrtwList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("SubAktivitasNilaiBLdanAlrtwView", parm);
            else
                url = KeyUrl("SubAktivitasNilaiBLdanAlrtwView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "SubAktivitasNilaiBLdanAlrtwAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "SubAktivitasNilaiBLdanAlrtwAdd?" + parm;
            else
                url = "SubAktivitasNilaiBLdanAlrtwAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("SubAktivitasNilaiBLdanAlrtwEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("SubAktivitasNilaiBLdanAlrtwList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("SubAktivitasNilaiBLdanAlrtwAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("SubAktivitasNilaiBLdanAlrtwList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("SubAktivitasNilaiBLdanAlrtwDelete", parm)); // DN
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
            idAktifitas.SetDbValue(row["idAktifitas"]);
            StatusAktivitas.SetDbValue(row["StatusAktivitas"]);
            BL_KL_Obs.SetDbValue(row["BL_KL_Obs"]);
            BL_KL_15.SetDbValue(row["BL_KL_15"]);
            BL_Barrels.SetDbValue(row["BL_Barrels"]);
            BL_LT.SetDbValue(row["BL_LT"]);
            BL_MT.SetDbValue(row["BL_MT"]);
            AL_KL_Obs.SetDbValue(row["AL_KL_Obs"]);
            AL_KL_15.SetDbValue(row["AL_KL_15"]);
            AL_Barrels.SetDbValue(row["AL_Barrels"]);
            AL_LT.SetDbValue(row["AL_LT"]);
            AL_MT.SetDbValue(row["AL_MT"]);
            userInput.SetDbValue(row["userInput"]);
            etlDate.SetDbValue(row["etlDate"]);
            idProses.SetDbValue(row["idProses"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            lastUpdatedDate.SetDbValue(row["lastUpdatedDate"]);
            NoReferensi.SetDbValue(row["NoReferensi"]);
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "SubAktivitasNilaiBLdanAlrtwList";
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

            // idAktifitas

            // StatusAktivitas

            // BL_KL_Obs

            // BL_KL_15

            // BL_Barrels

            // BL_LT

            // BL_MT

            // AL_KL_Obs

            // AL_KL_15

            // AL_Barrels

            // AL_LT

            // AL_MT

            // userInput

            // etlDate

            // idProses

            // LastUpdatedBy

            // lastUpdatedDate

            // NoReferensi

            // id
            id.ViewValue = id.CurrentValue;
            id.ViewCustomAttributes = "";

            // idAktifitas
            idAktifitas.ViewValue = idAktifitas.CurrentValue;

            // awallookupbung
            string curVal = ConvertToString(idAktifitas.CurrentValue);
            idAktifitas.ViewValue = Empty(curVal) ? DbNullValue : FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
            if (!Empty(curVal)) {
                if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idAktifitas.ViewValue = idAktifitas.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    string filterWrk = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                    string? sqlWrk = idAktifitas.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                        var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk[0]);
                        idAktifitas.ViewValue = idAktifitas.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            idAktifitas.ViewCustomAttributes = "";

            // StatusAktivitas
            StatusAktivitas.ViewValue = StatusAktivitas.CurrentValue;

            // awallookupbung
            string curVal2 = ConvertToString(StatusAktivitas.CurrentValue);
            StatusAktivitas.ViewValue = Empty(curVal2) ? DbNullValue : FormatNumber(StatusAktivitas.CurrentValue, StatusAktivitas.FormatPattern);
            if (!Empty(curVal2)) {
                if (StatusAktivitas.Lookup != null && IsDictionary(StatusAktivitas.Lookup?.Options) && StatusAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    StatusAktivitas.ViewValue = StatusAktivitas.LookupCacheOption(curVal2);
                } else { // Lookup from database // DN
                    string filterWrk2 = SearchFilter(StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", StatusAktivitas.CurrentValue, StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                    string? sqlWrk2 = StatusAktivitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk2?.Count > 0 && StatusAktivitas.Lookup != null) { // Lookup values found
                        var listwrk = StatusAktivitas.Lookup?.RenderViewRow(rswrk2[0]);
                        StatusAktivitas.ViewValue = StatusAktivitas.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            StatusAktivitas.ViewCustomAttributes = "";

            // BL_KL_Obs
            BL_KL_Obs.ViewValue = ConvertToString(BL_KL_Obs.CurrentValue); // DN
            BL_KL_Obs.ViewCustomAttributes = "";

            // BL_KL_15
            BL_KL_15.ViewValue = ConvertToString(BL_KL_15.CurrentValue); // DN
            BL_KL_15.ViewCustomAttributes = "";

            // BL_Barrels
            BL_Barrels.ViewValue = ConvertToString(BL_Barrels.CurrentValue); // DN
            BL_Barrels.ViewCustomAttributes = "";

            // BL_LT
            BL_LT.ViewValue = ConvertToString(BL_LT.CurrentValue); // DN
            BL_LT.ViewCustomAttributes = "";

            // BL_MT
            BL_MT.ViewValue = ConvertToString(BL_MT.CurrentValue); // DN
            BL_MT.ViewCustomAttributes = "";

            // AL_KL_Obs
            AL_KL_Obs.ViewValue = ConvertToString(AL_KL_Obs.CurrentValue); // DN
            AL_KL_Obs.ViewCustomAttributes = "";

            // AL_KL_15
            AL_KL_15.ViewValue = ConvertToString(AL_KL_15.CurrentValue); // DN
            AL_KL_15.ViewCustomAttributes = "";

            // AL_Barrels
            AL_Barrels.ViewValue = ConvertToString(AL_Barrels.CurrentValue); // DN
            AL_Barrels.ViewCustomAttributes = "";

            // AL_LT
            AL_LT.ViewValue = ConvertToString(AL_LT.CurrentValue); // DN
            AL_LT.ViewCustomAttributes = "";

            // AL_MT
            AL_MT.ViewValue = ConvertToString(AL_MT.CurrentValue); // DN
            AL_MT.ViewCustomAttributes = "";

            // userInput
            userInput.ViewValue = ConvertToString(userInput.CurrentValue); // DN
            userInput.ViewCustomAttributes = "";

            // etlDate
            etlDate.ViewValue = etlDate.CurrentValue;
            etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
            etlDate.ViewCustomAttributes = "";

            // idProses
            idProses.ViewValue = idProses.CurrentValue;

            // awallookupbung
            string curVal3 = ConvertToString(idProses.CurrentValue);
            idProses.ViewValue = Empty(curVal3) ? DbNullValue : FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
            if (!Empty(curVal3)) {
                if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idProses.ViewValue = idProses.LookupCacheOption(curVal3);
                } else { // Lookup from database // DN
                    string filterWrk3 = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                    string? sqlWrk3 = idProses.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk3?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                        var listwrk = idProses.Lookup?.RenderViewRow(rswrk3[0]);
                        idProses.ViewValue = idProses.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            idProses.ViewCustomAttributes = "";

            // LastUpdatedBy
            LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
            LastUpdatedBy.ViewCustomAttributes = "";

            // lastUpdatedDate
            lastUpdatedDate.ViewValue = lastUpdatedDate.CurrentValue;
            lastUpdatedDate.ViewValue = FormatDateTime(lastUpdatedDate.ViewValue, lastUpdatedDate.FormatPattern);
            lastUpdatedDate.ViewCustomAttributes = "";

            // NoReferensi
            NoReferensi.ViewValue = ConvertToString(NoReferensi.CurrentValue); // DN
            NoReferensi.ViewCustomAttributes = "";

            // id
            id.HrefValue = "";
            id.TooltipValue = "";

            // idAktifitas
            idAktifitas.HrefValue = "";
            idAktifitas.TooltipValue = "";

            // StatusAktivitas
            StatusAktivitas.HrefValue = "";
            StatusAktivitas.TooltipValue = "";

            // BL_KL_Obs
            BL_KL_Obs.HrefValue = "";
            BL_KL_Obs.TooltipValue = "";

            // BL_KL_15
            BL_KL_15.HrefValue = "";
            BL_KL_15.TooltipValue = "";

            // BL_Barrels
            BL_Barrels.HrefValue = "";
            BL_Barrels.TooltipValue = "";

            // BL_LT
            BL_LT.HrefValue = "";
            BL_LT.TooltipValue = "";

            // BL_MT
            BL_MT.HrefValue = "";
            BL_MT.TooltipValue = "";

            // AL_KL_Obs
            AL_KL_Obs.HrefValue = "";
            AL_KL_Obs.TooltipValue = "";

            // AL_KL_15
            AL_KL_15.HrefValue = "";
            AL_KL_15.TooltipValue = "";

            // AL_Barrels
            AL_Barrels.HrefValue = "";
            AL_Barrels.TooltipValue = "";

            // AL_LT
            AL_LT.HrefValue = "";
            AL_LT.TooltipValue = "";

            // AL_MT
            AL_MT.HrefValue = "";
            AL_MT.TooltipValue = "";

            // userInput
            userInput.HrefValue = "";
            userInput.TooltipValue = "";

            // etlDate
            etlDate.HrefValue = "";
            etlDate.TooltipValue = "";

            // idProses
            idProses.HrefValue = "";
            idProses.TooltipValue = "";

            // LastUpdatedBy
            LastUpdatedBy.HrefValue = "";
            LastUpdatedBy.TooltipValue = "";

            // lastUpdatedDate
            lastUpdatedDate.HrefValue = "";
            lastUpdatedDate.TooltipValue = "";

            // NoReferensi
            NoReferensi.HrefValue = "";
            NoReferensi.TooltipValue = "";

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

            // idAktifitas
            idAktifitas.SetupEditAttributes();
            idAktifitas.EditValue = idAktifitas.CurrentValue;

            // awallookupbung
            string curVal = ConvertToString(idAktifitas.CurrentValue);
            idAktifitas.EditValue = Empty(curVal) ? DbNullValue : FormatNumber(idAktifitas.CurrentValue, idAktifitas.FormatPattern);
            if (!Empty(curVal)) {
                if (idAktifitas.Lookup != null && IsDictionary(idAktifitas.Lookup?.Options) && idAktifitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idAktifitas.EditValue = idAktifitas.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    string filterWrk = SearchFilter(idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", idAktifitas.CurrentValue, idAktifitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                    string? sqlWrk = idAktifitas.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && idAktifitas.Lookup != null) { // Lookup values found
                        var listwrk = idAktifitas.Lookup?.RenderViewRow(rswrk[0]);
                        idAktifitas.EditValue = idAktifitas.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            idAktifitas.ViewCustomAttributes = "";

            // StatusAktivitas
            StatusAktivitas.SetupEditAttributes();
            StatusAktivitas.EditValue = StatusAktivitas.CurrentValue;

            // awallookupbung
            string curVal2 = ConvertToString(StatusAktivitas.CurrentValue);
            StatusAktivitas.EditValue = Empty(curVal2) ? DbNullValue : FormatNumber(StatusAktivitas.CurrentValue, StatusAktivitas.FormatPattern);
            if (!Empty(curVal2)) {
                if (StatusAktivitas.Lookup != null && IsDictionary(StatusAktivitas.Lookup?.Options) && StatusAktivitas.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    StatusAktivitas.EditValue = StatusAktivitas.LookupCacheOption(curVal2);
                } else { // Lookup from database // DN
                    string filterWrk2 = SearchFilter(StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchExpression, "=", StatusAktivitas.CurrentValue, StatusAktivitas.Lookup?.GetTable()?.Fields["IdAktivitas"].SearchDataType, "");
                    string? sqlWrk2 = StatusAktivitas.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk2?.Count > 0 && StatusAktivitas.Lookup != null) { // Lookup values found
                        var listwrk = StatusAktivitas.Lookup?.RenderViewRow(rswrk2[0]);
                        StatusAktivitas.EditValue = StatusAktivitas.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            StatusAktivitas.ViewCustomAttributes = "";

            // BL_KL_Obs
            BL_KL_Obs.SetupEditAttributes();
            if (!BL_KL_Obs.Raw)
                BL_KL_Obs.CurrentValue = HtmlDecode(BL_KL_Obs.CurrentValue);
            BL_KL_Obs.EditValue = BL_KL_Obs.CurrentValue;
            BL_KL_Obs.PlaceHolder = RemoveHtml(BL_KL_Obs.Caption);

            // BL_KL_15
            BL_KL_15.SetupEditAttributes();
            if (!BL_KL_15.Raw)
                BL_KL_15.CurrentValue = HtmlDecode(BL_KL_15.CurrentValue);
            BL_KL_15.EditValue = BL_KL_15.CurrentValue;
            BL_KL_15.PlaceHolder = RemoveHtml(BL_KL_15.Caption);

            // BL_Barrels
            BL_Barrels.SetupEditAttributes();
            if (!BL_Barrels.Raw)
                BL_Barrels.CurrentValue = HtmlDecode(BL_Barrels.CurrentValue);
            BL_Barrels.EditValue = BL_Barrels.CurrentValue;
            BL_Barrels.PlaceHolder = RemoveHtml(BL_Barrels.Caption);

            // BL_LT
            BL_LT.SetupEditAttributes();
            if (!BL_LT.Raw)
                BL_LT.CurrentValue = HtmlDecode(BL_LT.CurrentValue);
            BL_LT.EditValue = BL_LT.CurrentValue;
            BL_LT.PlaceHolder = RemoveHtml(BL_LT.Caption);

            // BL_MT
            BL_MT.SetupEditAttributes();
            if (!BL_MT.Raw)
                BL_MT.CurrentValue = HtmlDecode(BL_MT.CurrentValue);
            BL_MT.EditValue = BL_MT.CurrentValue;
            BL_MT.PlaceHolder = RemoveHtml(BL_MT.Caption);

            // AL_KL_Obs
            AL_KL_Obs.SetupEditAttributes();
            if (!AL_KL_Obs.Raw)
                AL_KL_Obs.CurrentValue = HtmlDecode(AL_KL_Obs.CurrentValue);
            AL_KL_Obs.EditValue = AL_KL_Obs.CurrentValue;
            AL_KL_Obs.PlaceHolder = RemoveHtml(AL_KL_Obs.Caption);

            // AL_KL_15
            AL_KL_15.SetupEditAttributes();
            if (!AL_KL_15.Raw)
                AL_KL_15.CurrentValue = HtmlDecode(AL_KL_15.CurrentValue);
            AL_KL_15.EditValue = AL_KL_15.CurrentValue;
            AL_KL_15.PlaceHolder = RemoveHtml(AL_KL_15.Caption);

            // AL_Barrels
            AL_Barrels.SetupEditAttributes();
            if (!AL_Barrels.Raw)
                AL_Barrels.CurrentValue = HtmlDecode(AL_Barrels.CurrentValue);
            AL_Barrels.EditValue = AL_Barrels.CurrentValue;
            AL_Barrels.PlaceHolder = RemoveHtml(AL_Barrels.Caption);

            // AL_LT
            AL_LT.SetupEditAttributes();
            if (!AL_LT.Raw)
                AL_LT.CurrentValue = HtmlDecode(AL_LT.CurrentValue);
            AL_LT.EditValue = AL_LT.CurrentValue;
            AL_LT.PlaceHolder = RemoveHtml(AL_LT.Caption);

            // AL_MT
            AL_MT.SetupEditAttributes();
            if (!AL_MT.Raw)
                AL_MT.CurrentValue = HtmlDecode(AL_MT.CurrentValue);
            AL_MT.EditValue = AL_MT.CurrentValue;
            AL_MT.PlaceHolder = RemoveHtml(AL_MT.Caption);

            // userInput
            userInput.SetupEditAttributes();
            if (!userInput.Raw)
                userInput.CurrentValue = HtmlDecode(userInput.CurrentValue);
            userInput.EditValue = userInput.CurrentValue;
            userInput.PlaceHolder = RemoveHtml(userInput.Caption);

            // etlDate
            etlDate.SetupEditAttributes();
            etlDate.EditValue = FormatDateTime(etlDate.CurrentValue, etlDate.FormatPattern);
            etlDate.PlaceHolder = RemoveHtml(etlDate.Caption);

            // idProses
            idProses.SetupEditAttributes();
            idProses.EditValue = idProses.CurrentValue;

            // awallookupbung
            string curVal3 = ConvertToString(idProses.CurrentValue);
            idProses.EditValue = Empty(curVal3) ? DbNullValue : FormatNumber(idProses.CurrentValue, idProses.FormatPattern);
            if (!Empty(curVal3)) {
                if (idProses.Lookup != null && IsDictionary(idProses.Lookup?.Options) && idProses.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idProses.EditValue = idProses.LookupCacheOption(curVal3);
                } else { // Lookup from database // DN
                    string filterWrk3 = SearchFilter(idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchExpression, "=", idProses.CurrentValue, idProses.Lookup?.GetTable()?.Fields["IdProses"].SearchDataType, "");
                    string? sqlWrk3 = idProses.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk3?.Count > 0 && idProses.Lookup != null) { // Lookup values found
                        var listwrk = idProses.Lookup?.RenderViewRow(rswrk3[0]);
                        idProses.EditValue = idProses.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            idProses.ViewCustomAttributes = "";

            // LastUpdatedBy
            LastUpdatedBy.SetupEditAttributes();
            LastUpdatedBy.EditValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
            LastUpdatedBy.ViewCustomAttributes = "";

            // lastUpdatedDate
            lastUpdatedDate.SetupEditAttributes();
            lastUpdatedDate.EditValue = lastUpdatedDate.CurrentValue;
            lastUpdatedDate.EditValue = FormatDateTime(lastUpdatedDate.EditValue, lastUpdatedDate.FormatPattern);
            lastUpdatedDate.ViewCustomAttributes = "";

            // NoReferensi
            NoReferensi.SetupEditAttributes();
            NoReferensi.EditValue = ConvertToString(NoReferensi.CurrentValue); // DN
            NoReferensi.ViewCustomAttributes = "";

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
                        doc.ExportCaption(idAktifitas);
                        doc.ExportCaption(StatusAktivitas);
                        doc.ExportCaption(BL_KL_Obs);
                        doc.ExportCaption(BL_KL_15);
                        doc.ExportCaption(BL_Barrels);
                        doc.ExportCaption(BL_LT);
                        doc.ExportCaption(BL_MT);
                        doc.ExportCaption(AL_KL_Obs);
                        doc.ExportCaption(AL_KL_15);
                        doc.ExportCaption(AL_Barrels);
                        doc.ExportCaption(AL_LT);
                        doc.ExportCaption(AL_MT);
                        doc.ExportCaption(userInput);
                        doc.ExportCaption(etlDate);
                        doc.ExportCaption(idProses);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(lastUpdatedDate);
                        doc.ExportCaption(NoReferensi);
                    } else {
                        doc.ExportCaption(id);
                        doc.ExportCaption(idAktifitas);
                        doc.ExportCaption(StatusAktivitas);
                        doc.ExportCaption(BL_KL_Obs);
                        doc.ExportCaption(BL_KL_15);
                        doc.ExportCaption(BL_Barrels);
                        doc.ExportCaption(BL_LT);
                        doc.ExportCaption(BL_MT);
                        doc.ExportCaption(AL_KL_Obs);
                        doc.ExportCaption(AL_KL_15);
                        doc.ExportCaption(AL_Barrels);
                        doc.ExportCaption(AL_LT);
                        doc.ExportCaption(AL_MT);
                        doc.ExportCaption(userInput);
                        doc.ExportCaption(etlDate);
                        doc.ExportCaption(idProses);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(lastUpdatedDate);
                        doc.ExportCaption(NoReferensi);
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
                            await doc.ExportField(idAktifitas);
                            await doc.ExportField(StatusAktivitas);
                            await doc.ExportField(BL_KL_Obs);
                            await doc.ExportField(BL_KL_15);
                            await doc.ExportField(BL_Barrels);
                            await doc.ExportField(BL_LT);
                            await doc.ExportField(BL_MT);
                            await doc.ExportField(AL_KL_Obs);
                            await doc.ExportField(AL_KL_15);
                            await doc.ExportField(AL_Barrels);
                            await doc.ExportField(AL_LT);
                            await doc.ExportField(AL_MT);
                            await doc.ExportField(userInput);
                            await doc.ExportField(etlDate);
                            await doc.ExportField(idProses);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(lastUpdatedDate);
                            await doc.ExportField(NoReferensi);
                        } else {
                            await doc.ExportField(id);
                            await doc.ExportField(idAktifitas);
                            await doc.ExportField(StatusAktivitas);
                            await doc.ExportField(BL_KL_Obs);
                            await doc.ExportField(BL_KL_15);
                            await doc.ExportField(BL_Barrels);
                            await doc.ExportField(BL_LT);
                            await doc.ExportField(BL_MT);
                            await doc.ExportField(AL_KL_Obs);
                            await doc.ExportField(AL_KL_15);
                            await doc.ExportField(AL_Barrels);
                            await doc.ExportField(AL_LT);
                            await doc.ExportField(AL_MT);
                            await doc.ExportField(userInput);
                            await doc.ExportField(etlDate);
                            await doc.ExportField(idProses);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(lastUpdatedDate);
                            await doc.ExportField(NoReferensi);
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
            return true;
        }

        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
        }

        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            try {
                // Ambil NoReferensi dari data baru jika ada; jika tidak, gunakan data lama
                var nomorReferensi = rsnew.ContainsKey("NoReferensi") ?
                    rsnew["NoReferensi"].ToString() :
                    rsold["NoReferensi"].ToString();

                // Panggil SP GetPlantDateTime dengan parameter NomorReferensi
                string sqlGetTime = $"EXEC dbo.GetPlantDateTime @NomorReferensi = '{nomorReferensi}'";
                var plantTimeObj = ExecuteScalar(sqlGetTime);

                // Default waktu jika SP mengembalikan NULL atau gagal diparse
                DateTime plantTime = DateTime.Now;
                if (plantTimeObj != null && DateTime.TryParse(plantTimeObj.ToString(), out var tmp))
                    plantTime = tmp;

                // Set field pembaruan menggunakan nama user dan waktu plant
                rsnew["LastUpdatedBy"] = CurrentUserName();
                rsnew["lastUpdatedDate"] = plantTime;
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
