namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// masterPipa
    /// </summary>
    [MaybeNull]
    public static MasterPipa masterPipa
    {
        get => HttpData.Resolve<MasterPipa>("MasterPipa");
        set => HttpData["MasterPipa"] = value;
    }

    /// <summary>
    /// Table class for MasterPipa
    /// </summary>
    public class MasterPipa : DbTable
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

        public readonly DbField<SqlDbType> KeteranganPipa;

        public readonly DbField<SqlDbType> idPlantAsal;

        public readonly DbField<SqlDbType> idPlantTujuan;

        public readonly DbField<SqlDbType> Panjang;

        public readonly DbField<SqlDbType> Diameter;

        public readonly DbField<SqlDbType> Volume;

        public readonly DbField<SqlDbType> Flowrate;

        public readonly DbField<SqlDbType> idPlantTujuan2;

        public readonly DbField<SqlDbType> Panjang2;

        public readonly DbField<SqlDbType> Diameter2;

        public readonly DbField<SqlDbType> Volume2;

        public readonly DbField<SqlDbType> Flowrate2;

        public readonly DbField<SqlDbType> idPlantTujuan3;

        public readonly DbField<SqlDbType> Panjang3;

        public readonly DbField<SqlDbType> Diameter3;

        public readonly DbField<SqlDbType> Volume3;

        public readonly DbField<SqlDbType> Flowrate3;

        public readonly DbField<SqlDbType> BiayaProject;

        public readonly DbField<SqlDbType> PlantAsal;

        public readonly DbField<SqlDbType> NamaPlantAsal;

        public readonly DbField<SqlDbType> PlantTujuan;

        public readonly DbField<SqlDbType> NamaPlantTujuan;

        public readonly DbField<SqlDbType> PlantTujuan2;

        public readonly DbField<SqlDbType> NamaPlantTujuan2;

        public readonly DbField<SqlDbType> PlantTujuan3;

        public readonly DbField<SqlDbType> NamaPlantTujuan3;

        public readonly DbField<SqlDbType> CreatedBy;

        public readonly DbField<SqlDbType> etlDate;

        public readonly DbField<SqlDbType> LastUpdatedBy;

        public readonly DbField<SqlDbType> LastUpdatedDate;

        // Constructor
        public MasterPipa()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "MasterPipa";
            Name = "MasterPipa";
            Type = "TABLE";
            UpdateTable = "dbo.MasterPipa"; // Update Table
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "id", "CustomMsg"),
                IsUpload = false
            };
            id.Raw = true;
            Fields.Add("id", id);

            // KeteranganPipa
            KeteranganPipa = new(this, "x_KeteranganPipa", 202, SqlDbType.NVarChar) {
                Name = "KeteranganPipa",
                Expression = "[KeteranganPipa]",
                UseBasicSearch = true,
                BasicSearchExpression = "[KeteranganPipa]",
                DateTimeFormat = -1,
                VirtualExpression = "[KeteranganPipa]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "KeteranganPipa", "CustomMsg"),
                IsUpload = false
            };
            KeteranganPipa.Lookup = new Lookup<DbField>(KeteranganPipa, "MasterPipa", true, "KeteranganPipa", new List<string> {"KeteranganPipa", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("KeteranganPipa", KeteranganPipa);

            // idPlantAsal
            idPlantAsal = new(this, "x_idPlantAsal", 3, SqlDbType.Int) {
                Name = "idPlantAsal",
                Expression = "[idPlantAsal]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([idPlantAsal] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[idPlantAsal]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "idPlantAsal", "CustomMsg"),
                IsUpload = false
            };
            idPlantAsal.Raw = true;
            idPlantAsal.Lookup = new Lookup<DbField>(idPlantAsal, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {"Plant", "Nama_Terminal"}, new List<string> {"x_PlantAsal", "x_NamaPlantAsal"}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, idPlantAsal) + "',[Nama_Terminal])");
            Fields.Add("idPlantAsal", idPlantAsal);

            // idPlantTujuan
            idPlantTujuan = new(this, "x_idPlantTujuan", 3, SqlDbType.Int) {
                Name = "idPlantTujuan",
                Expression = "[idPlantTujuan]",
                BasicSearchExpression = "CAST([idPlantTujuan] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[idPlantTujuan]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "idPlantTujuan", "CustomMsg"),
                IsUpload = false
            };
            idPlantTujuan.Raw = true;
            idPlantTujuan.Lookup = new Lookup<DbField>(idPlantTujuan, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {"Plant", "Nama_Terminal"}, new List<string> {"x_NamaPlantTujuan", "x_PlantTujuan2"}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, idPlantTujuan) + "',[Nama_Terminal])");
            Fields.Add("idPlantTujuan", idPlantTujuan);

            // Panjang
            Panjang = new(this, "x_Panjang", 131, SqlDbType.Decimal) {
                Name = "Panjang",
                Expression = "[Panjang]",
                BasicSearchExpression = "CAST([Panjang] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Panjang]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Panjang", "CustomMsg"),
                IsUpload = false
            };
            Panjang.Raw = true;
            Panjang.Lookup = new Lookup<DbField>(Panjang, "MasterPipa", true, "Panjang", new List<string> {"Panjang", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Panjang", Panjang);

            // Diameter
            Diameter = new(this, "x_Diameter", 131, SqlDbType.Decimal) {
                Name = "Diameter",
                Expression = "[Diameter]",
                BasicSearchExpression = "CAST([Diameter] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Diameter]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Diameter", "CustomMsg"),
                IsUpload = false
            };
            Diameter.Raw = true;
            Diameter.Lookup = new Lookup<DbField>(Diameter, "MasterPipa", true, "Diameter", new List<string> {"Diameter", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Diameter", Diameter);

            // Volume
            Volume = new(this, "x_Volume", 131, SqlDbType.Decimal) {
                Name = "Volume",
                Expression = "[Volume]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Volume", "CustomMsg"),
                IsUpload = false
            };
            Volume.Raw = true;
            Volume.Lookup = new Lookup<DbField>(Volume, "MasterPipa", true, "Volume", new List<string> {"Volume", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Volume", Volume);

            // Flowrate
            Flowrate = new(this, "x_Flowrate", 131, SqlDbType.Decimal) {
                Name = "Flowrate",
                Expression = "[Flowrate]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([Flowrate] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Flowrate]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Flowrate", "CustomMsg"),
                IsUpload = false
            };
            Flowrate.Raw = true;
            Flowrate.Lookup = new Lookup<DbField>(Flowrate, "MasterPipa", true, "Flowrate", new List<string> {"Flowrate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Flowrate", Flowrate);

            // idPlantTujuan2
            idPlantTujuan2 = new(this, "x_idPlantTujuan2", 3, SqlDbType.Int) {
                Name = "idPlantTujuan2",
                Expression = "[idPlantTujuan2]",
                BasicSearchExpression = "CAST([idPlantTujuan2] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[idPlantTujuan2]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "idPlantTujuan2", "CustomMsg"),
                IsUpload = false
            };
            idPlantTujuan2.Raw = true;
            idPlantTujuan2.Lookup = new Lookup<DbField>(idPlantTujuan2, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {"Plant", "Nama_Terminal"}, new List<string> {"x_PlantTujuan2", "x_NamaPlantTujuan2"}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, idPlantTujuan2) + "',[Nama_Terminal])");
            Fields.Add("idPlantTujuan2", idPlantTujuan2);

            // Panjang2
            Panjang2 = new(this, "x_Panjang2", 131, SqlDbType.Decimal) {
                Name = "Panjang2",
                Expression = "[Panjang2]",
                BasicSearchExpression = "CAST([Panjang2] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Panjang2]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Panjang2", "CustomMsg"),
                IsUpload = false
            };
            Panjang2.Raw = true;
            Panjang2.Lookup = new Lookup<DbField>(Panjang2, "MasterPipa", true, "Panjang2", new List<string> {"Panjang2", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Panjang2", Panjang2);

            // Diameter2
            Diameter2 = new(this, "x_Diameter2", 131, SqlDbType.Decimal) {
                Name = "Diameter2",
                Expression = "[Diameter2]",
                BasicSearchExpression = "CAST([Diameter2] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Diameter2]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Diameter2", "CustomMsg"),
                IsUpload = false
            };
            Diameter2.Raw = true;
            Diameter2.Lookup = new Lookup<DbField>(Diameter2, "MasterPipa", true, "Diameter2", new List<string> {"Diameter2", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Diameter2", Diameter2);

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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "Volume2", "CustomMsg"),
                IsUpload = false
            };
            Volume2.Raw = true;
            Volume2.Lookup = new Lookup<DbField>(Volume2, "MasterPipa", true, "Volume2", new List<string> {"Volume2", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Volume2", Volume2);

            // Flowrate2
            Flowrate2 = new(this, "x_Flowrate2", 131, SqlDbType.Decimal) {
                Name = "Flowrate2",
                Expression = "[Flowrate2]",
                BasicSearchExpression = "CAST([Flowrate2] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Flowrate2]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Flowrate2", "CustomMsg"),
                IsUpload = false
            };
            Flowrate2.Raw = true;
            Flowrate2.Lookup = new Lookup<DbField>(Flowrate2, "MasterPipa", true, "Flowrate2", new List<string> {"Flowrate2", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Flowrate2", Flowrate2);

            // idPlantTujuan3
            idPlantTujuan3 = new(this, "x_idPlantTujuan3", 3, SqlDbType.Int) {
                Name = "idPlantTujuan3",
                Expression = "[idPlantTujuan3]",
                BasicSearchExpression = "CAST([idPlantTujuan3] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[idPlantTujuan3]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "idPlantTujuan3", "CustomMsg"),
                IsUpload = false
            };
            idPlantTujuan3.Raw = true;
            idPlantTujuan3.Lookup = new Lookup<DbField>(idPlantTujuan3, "MasterPlant", true, "IdPlant", new List<string> {"Plant", "Nama_Terminal", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {"Plant", "Nama_Terminal"}, new List<string> {"x_PlantTujuan3", "x_NamaPlantTujuan3"}, false, "", "", "CONCAT([Plant],'" + ValueSeparator(1, idPlantTujuan3) + "',[Nama_Terminal])");
            Fields.Add("idPlantTujuan3", idPlantTujuan3);

            // Panjang3
            Panjang3 = new(this, "x_Panjang3", 131, SqlDbType.Decimal) {
                Name = "Panjang3",
                Expression = "[Panjang3]",
                BasicSearchExpression = "CAST([Panjang3] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Panjang3]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Panjang3", "CustomMsg"),
                IsUpload = false
            };
            Panjang3.Raw = true;
            Panjang3.Lookup = new Lookup<DbField>(Panjang3, "MasterPipa", true, "Panjang3", new List<string> {"Panjang3", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Panjang3", Panjang3);

            // Diameter3
            Diameter3 = new(this, "x_Diameter3", 131, SqlDbType.Decimal) {
                Name = "Diameter3",
                Expression = "[Diameter3]",
                BasicSearchExpression = "CAST([Diameter3] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Diameter3]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Diameter3", "CustomMsg"),
                IsUpload = false
            };
            Diameter3.Raw = true;
            Diameter3.Lookup = new Lookup<DbField>(Diameter3, "MasterPipa", true, "Diameter3", new List<string> {"Diameter3", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Diameter3", Diameter3);

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
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "Volume3", "CustomMsg"),
                IsUpload = false
            };
            Volume3.Raw = true;
            Volume3.Lookup = new Lookup<DbField>(Volume3, "MasterPipa", true, "Volume3", new List<string> {"Volume3", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Volume3", Volume3);

            // Flowrate3
            Flowrate3 = new(this, "x_Flowrate3", 131, SqlDbType.Decimal) {
                Name = "Flowrate3",
                Expression = "[Flowrate3]",
                BasicSearchExpression = "CAST([Flowrate3] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Flowrate3]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "Flowrate3", "CustomMsg"),
                IsUpload = false
            };
            Flowrate3.Raw = true;
            Flowrate3.Lookup = new Lookup<DbField>(Flowrate3, "MasterPipa", true, "Flowrate3", new List<string> {"Flowrate3", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("Flowrate3", Flowrate3);

            // BiayaProject
            BiayaProject = new(this, "x_BiayaProject", 131, SqlDbType.Decimal) {
                Name = "BiayaProject",
                Expression = "[BiayaProject]",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST([BiayaProject] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[BiayaProject]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "BiayaProject", "CustomMsg"),
                IsUpload = false
            };
            BiayaProject.Raw = true;
            BiayaProject.Lookup = new Lookup<DbField>(BiayaProject, "MasterPipa", true, "BiayaProject", new List<string> {"BiayaProject", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("BiayaProject", BiayaProject);

            // PlantAsal
            PlantAsal = new(this, "x_PlantAsal", 202, SqlDbType.NVarChar) {
                Name = "PlantAsal",
                Expression = "[PlantAsal]",
                UseBasicSearch = true,
                BasicSearchExpression = "[PlantAsal]",
                DateTimeFormat = -1,
                VirtualExpression = "[PlantAsal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "PlantAsal", "CustomMsg"),
                IsUpload = false
            };
            PlantAsal.Lookup = new Lookup<DbField>(PlantAsal, "MasterPipa", true, "PlantAsal", new List<string> {"PlantAsal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, true, "", "", "");
            Fields.Add("PlantAsal", PlantAsal);

            // NamaPlantAsal
            NamaPlantAsal = new(this, "x_NamaPlantAsal", 202, SqlDbType.NVarChar) {
                Name = "NamaPlantAsal",
                Expression = "[NamaPlantAsal]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NamaPlantAsal]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaPlantAsal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "NamaPlantAsal", "CustomMsg"),
                IsUpload = false
            };
            NamaPlantAsal.Lookup = new Lookup<DbField>(NamaPlantAsal, "MasterPipa", true, "NamaPlantAsal", new List<string> {"NamaPlantAsal", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, true, "", "", "");
            Fields.Add("NamaPlantAsal", NamaPlantAsal);

            // PlantTujuan
            PlantTujuan = new(this, "x_PlantTujuan", 202, SqlDbType.NVarChar) {
                Name = "PlantTujuan",
                Expression = "[PlantTujuan]",
                BasicSearchExpression = "[PlantTujuan]",
                DateTimeFormat = -1,
                VirtualExpression = "[PlantTujuan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "PlantTujuan", "CustomMsg"),
                IsUpload = false
            };
            PlantTujuan.Lookup = new Lookup<DbField>(PlantTujuan, "MasterPipa", true, "PlantTujuan", new List<string> {"PlantTujuan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("PlantTujuan", PlantTujuan);

            // NamaPlantTujuan
            NamaPlantTujuan = new(this, "x_NamaPlantTujuan", 202, SqlDbType.NVarChar) {
                Name = "NamaPlantTujuan",
                Expression = "[NamaPlantTujuan]",
                BasicSearchExpression = "[NamaPlantTujuan]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaPlantTujuan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "NamaPlantTujuan", "CustomMsg"),
                IsUpload = false
            };
            NamaPlantTujuan.Lookup = new Lookup<DbField>(NamaPlantTujuan, "MasterPipa", true, "NamaPlantTujuan", new List<string> {"NamaPlantTujuan", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, true, "", "", "");
            Fields.Add("NamaPlantTujuan", NamaPlantTujuan);

            // PlantTujuan2
            PlantTujuan2 = new(this, "x_PlantTujuan2", 202, SqlDbType.NVarChar) {
                Name = "PlantTujuan2",
                Expression = "[PlantTujuan2]",
                BasicSearchExpression = "[PlantTujuan2]",
                DateTimeFormat = -1,
                VirtualExpression = "[PlantTujuan2]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "PlantTujuan2", "CustomMsg"),
                IsUpload = false
            };
            PlantTujuan2.Lookup = new Lookup<DbField>(PlantTujuan2, "MasterPipa", true, "PlantTujuan2", new List<string> {"PlantTujuan2", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, true, "", "", "");
            Fields.Add("PlantTujuan2", PlantTujuan2);

            // NamaPlantTujuan2
            NamaPlantTujuan2 = new(this, "x_NamaPlantTujuan2", 202, SqlDbType.NVarChar) {
                Name = "NamaPlantTujuan2",
                Expression = "[NamaPlantTujuan2]",
                BasicSearchExpression = "[NamaPlantTujuan2]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaPlantTujuan2]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "NamaPlantTujuan2", "CustomMsg"),
                IsUpload = false
            };
            NamaPlantTujuan2.Lookup = new Lookup<DbField>(NamaPlantTujuan2, "MasterPipa", true, "NamaPlantTujuan2", new List<string> {"NamaPlantTujuan2", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, true, "", "", "");
            Fields.Add("NamaPlantTujuan2", NamaPlantTujuan2);

            // PlantTujuan3
            PlantTujuan3 = new(this, "x_PlantTujuan3", 202, SqlDbType.NVarChar) {
                Name = "PlantTujuan3",
                Expression = "[PlantTujuan3]",
                BasicSearchExpression = "[PlantTujuan3]",
                DateTimeFormat = -1,
                VirtualExpression = "[PlantTujuan3]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "PlantTujuan3", "CustomMsg"),
                IsUpload = false
            };
            PlantTujuan3.Lookup = new Lookup<DbField>(PlantTujuan3, "MasterPipa", true, "PlantTujuan3", new List<string> {"PlantTujuan3", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, true, "", "", "");
            Fields.Add("PlantTujuan3", PlantTujuan3);

            // NamaPlantTujuan3
            NamaPlantTujuan3 = new(this, "x_NamaPlantTujuan3", 202, SqlDbType.NVarChar) {
                Name = "NamaPlantTujuan3",
                Expression = "[NamaPlantTujuan3]",
                BasicSearchExpression = "[NamaPlantTujuan3]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaPlantTujuan3]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = ["=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "NamaPlantTujuan3", "CustomMsg"),
                IsUpload = false
            };
            NamaPlantTujuan3.Lookup = new Lookup<DbField>(NamaPlantTujuan3, "MasterPipa", true, "NamaPlantTujuan3", new List<string> {"NamaPlantTujuan3", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, true, "", "", "");
            Fields.Add("NamaPlantTujuan3", NamaPlantTujuan3);

            // CreatedBy
            CreatedBy = new(this, "x_CreatedBy", 202, SqlDbType.NVarChar) {
                Name = "CreatedBy",
                Expression = "[CreatedBy]",
                UseBasicSearch = true,
                BasicSearchExpression = "[CreatedBy]",
                DateTimeFormat = -1,
                VirtualExpression = "[CreatedBy]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "CreatedBy", "CustomMsg"),
                IsUpload = false
            };
            CreatedBy.Lookup = new Lookup<DbField>(CreatedBy, "MasterPipa", true, "CreatedBy", new List<string> {"CreatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("CreatedBy", CreatedBy);

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
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(9)),
                SearchOperators = ["=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN"],
                CustomMessage = Language.FieldPhrase("MasterPipa", "etlDate", "CustomMsg"),
                IsUpload = false
            };
            etlDate.Raw = true;
            etlDate.Lookup = new Lookup<DbField>(etlDate, "MasterPipa", true, "etlDate", new List<string> {"etlDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "LastUpdatedBy", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedBy.Lookup = new Lookup<DbField>(LastUpdatedBy, "MasterPipa", true, "LastUpdatedBy", new List<string> {"LastUpdatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LastUpdatedBy", LastUpdatedBy);

            // LastUpdatedDate
            LastUpdatedDate = new(this, "x_LastUpdatedDate", 135, SqlDbType.DateTime) {
                Name = "LastUpdatedDate",
                Expression = "[LastUpdatedDate]",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("[LastUpdatedDate]", 9, "DB"),
                DateTimeFormat = 9,
                VirtualExpression = "[LastUpdatedDate]",
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
                CustomMessage = Language.FieldPhrase("MasterPipa", "LastUpdatedDate", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDate.Raw = true;
            LastUpdatedDate.Lookup = new Lookup<DbField>(LastUpdatedDate, "MasterPipa", true, "LastUpdatedDate", new List<string> {"LastUpdatedDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, false, "", "", "");
            Fields.Add("LastUpdatedDate", LastUpdatedDate);

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
            get => _sqlFrom ?? "dbo.MasterPipa";
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterPipa type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterPipa type", "data");
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
                throw new ArgumentException("Data must be of anonymous or Dictionary<string, object> or Entities.MasterPipa type", "data");
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
                KeteranganPipa.DbValue = row["KeteranganPipa"]; // Set DB value only
                idPlantAsal.DbValue = row["idPlantAsal"]; // Set DB value only
                idPlantTujuan.DbValue = row["idPlantTujuan"]; // Set DB value only
                Panjang.DbValue = row["Panjang"]; // Set DB value only
                Diameter.DbValue = row["Diameter"]; // Set DB value only
                Volume.DbValue = row["Volume"]; // Set DB value only
                Flowrate.DbValue = row["Flowrate"]; // Set DB value only
                idPlantTujuan2.DbValue = row["idPlantTujuan2"]; // Set DB value only
                Panjang2.DbValue = row["Panjang2"]; // Set DB value only
                Diameter2.DbValue = row["Diameter2"]; // Set DB value only
                Volume2.DbValue = row["Volume2"]; // Set DB value only
                Flowrate2.DbValue = row["Flowrate2"]; // Set DB value only
                idPlantTujuan3.DbValue = row["idPlantTujuan3"]; // Set DB value only
                Panjang3.DbValue = row["Panjang3"]; // Set DB value only
                Diameter3.DbValue = row["Diameter3"]; // Set DB value only
                Volume3.DbValue = row["Volume3"]; // Set DB value only
                Flowrate3.DbValue = row["Flowrate3"]; // Set DB value only
                BiayaProject.DbValue = row["BiayaProject"]; // Set DB value only
                PlantAsal.DbValue = row["PlantAsal"]; // Set DB value only
                NamaPlantAsal.DbValue = row["NamaPlantAsal"]; // Set DB value only
                PlantTujuan.DbValue = row["PlantTujuan"]; // Set DB value only
                NamaPlantTujuan.DbValue = row["NamaPlantTujuan"]; // Set DB value only
                PlantTujuan2.DbValue = row["PlantTujuan2"]; // Set DB value only
                NamaPlantTujuan2.DbValue = row["NamaPlantTujuan2"]; // Set DB value only
                PlantTujuan3.DbValue = row["PlantTujuan3"]; // Set DB value only
                NamaPlantTujuan3.DbValue = row["NamaPlantTujuan3"]; // Set DB value only
                CreatedBy.DbValue = row["CreatedBy"]; // Set DB value only
                etlDate.DbValue = row["etlDate"]; // Set DB value only
                LastUpdatedBy.DbValue = row["LastUpdatedBy"]; // Set DB value only
                LastUpdatedDate.DbValue = row["LastUpdatedDate"]; // Set DB value only
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
                    return "MasterPipaList";
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
                "MasterPipaView" => Language.Phrase("View"),
                "MasterPipaEdit" => Language.Phrase("Edit"),
                "MasterPipaAdd" => Language.Phrase("Add"),
                _ => String.Empty
            };
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "MasterPipaList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "MasterPipaView",
                Config.ApiAddAction => "MasterPipaAdd",
                Config.ApiEditAction => "MasterPipaEdit",
                Config.ApiDeleteAction => "MasterPipaDelete",
                Config.ApiListAction => "MasterPipaList",
                _ => String.Empty
            };
        }

        // API page class name // DN
        public string GetApiPageClassName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "MasterPipaView",
                Config.ApiAddAction => "MasterPipaAdd",
                Config.ApiEditAction => "MasterPipaEdit",
                Config.ApiDeleteAction => "MasterPipaDelete",
                Config.ApiListAction => "MasterPipaList",
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
        public string ListUrl => "MasterPipaList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("MasterPipaView", parm);
            else
                url = KeyUrl("MasterPipaView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "MasterPipaAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "MasterPipaAdd?" + parm;
            else
                url = "MasterPipaAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("MasterPipaEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("MasterPipaList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("MasterPipaAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("MasterPipaList", "action=copy"))); // DN

        // Delete URL
        public string GetDeleteUrl(string parm = "")
        {
            return UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
                ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
                : AppPath(KeyUrl("MasterPipaDelete", parm)); // DN
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
            KeteranganPipa.SetDbValue(row["KeteranganPipa"]);
            idPlantAsal.SetDbValue(row["idPlantAsal"]);
            idPlantTujuan.SetDbValue(row["idPlantTujuan"]);
            Panjang.SetDbValue(row["Panjang"]);
            Diameter.SetDbValue(row["Diameter"]);
            Volume.SetDbValue(row["Volume"]);
            Flowrate.SetDbValue(row["Flowrate"]);
            idPlantTujuan2.SetDbValue(row["idPlantTujuan2"]);
            Panjang2.SetDbValue(row["Panjang2"]);
            Diameter2.SetDbValue(row["Diameter2"]);
            Volume2.SetDbValue(row["Volume2"]);
            Flowrate2.SetDbValue(row["Flowrate2"]);
            idPlantTujuan3.SetDbValue(row["idPlantTujuan3"]);
            Panjang3.SetDbValue(row["Panjang3"]);
            Diameter3.SetDbValue(row["Diameter3"]);
            Volume3.SetDbValue(row["Volume3"]);
            Flowrate3.SetDbValue(row["Flowrate3"]);
            BiayaProject.SetDbValue(row["BiayaProject"]);
            PlantAsal.SetDbValue(row["PlantAsal"]);
            NamaPlantAsal.SetDbValue(row["NamaPlantAsal"]);
            PlantTujuan.SetDbValue(row["PlantTujuan"]);
            NamaPlantTujuan.SetDbValue(row["NamaPlantTujuan"]);
            PlantTujuan2.SetDbValue(row["PlantTujuan2"]);
            NamaPlantTujuan2.SetDbValue(row["NamaPlantTujuan2"]);
            PlantTujuan3.SetDbValue(row["PlantTujuan3"]);
            NamaPlantTujuan3.SetDbValue(row["NamaPlantTujuan3"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            etlDate.SetDbValue(row["etlDate"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDate.SetDbValue(row["LastUpdatedDate"]);
        }

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr) => LoadListRowValues(GetDictionary(dr));

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "MasterPipaList";
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

            // KeteranganPipa

            // idPlantAsal

            // idPlantTujuan

            // Panjang

            // Diameter

            // Volume

            // Flowrate

            // idPlantTujuan2

            // Panjang2

            // Diameter2

            // Volume2

            // Flowrate2

            // idPlantTujuan3

            // Panjang3

            // Diameter3

            // Volume3

            // Flowrate3

            // BiayaProject

            // PlantAsal

            // NamaPlantAsal

            // PlantTujuan

            // NamaPlantTujuan

            // PlantTujuan2

            // NamaPlantTujuan2

            // PlantTujuan3

            // NamaPlantTujuan3

            // CreatedBy

            // etlDate

            // LastUpdatedBy

            // LastUpdatedDate

            // id
            id.ViewValue = id.CurrentValue;
            id.ViewCustomAttributes = "";

            // KeteranganPipa
            KeteranganPipa.ViewValue = ConvertToString(KeteranganPipa.CurrentValue); // DN
            KeteranganPipa.ViewCustomAttributes = "";

            // idPlantAsal

            // awallookupbung
            string curVal = ConvertToString(idPlantAsal.CurrentValue);
            idPlantAsal.ViewValue = Empty(curVal) ? DbNullValue : FormatNumber(idPlantAsal.CurrentValue, idPlantAsal.FormatPattern);
            if (!Empty(curVal)) {
                if (idPlantAsal.Lookup != null && IsDictionary(idPlantAsal.Lookup?.Options) && idPlantAsal.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idPlantAsal.ViewValue = idPlantAsal.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    string filterWrk = SearchFilter(idPlantAsal.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantAsal.CurrentValue, idPlantAsal.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk = idPlantAsal.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && idPlantAsal.Lookup != null) { // Lookup values found
                        var listwrk = idPlantAsal.Lookup?.RenderViewRow(rswrk[0]);
                        idPlantAsal.ViewValue = idPlantAsal.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            idPlantAsal.ViewCustomAttributes = "";

            // idPlantTujuan

            // awallookupbung
            string curVal2 = ConvertToString(idPlantTujuan.CurrentValue);
            idPlantTujuan.ViewValue = Empty(curVal2) ? DbNullValue : FormatNumber(idPlantTujuan.CurrentValue, idPlantTujuan.FormatPattern);
            if (!Empty(curVal2)) {
                if (idPlantTujuan.Lookup != null && IsDictionary(idPlantTujuan.Lookup?.Options) && idPlantTujuan.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idPlantTujuan.ViewValue = idPlantTujuan.LookupCacheOption(curVal2);
                } else { // Lookup from database // DN
                    string filterWrk2 = SearchFilter(idPlantTujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan.CurrentValue, idPlantTujuan.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk2 = idPlantTujuan.Lookup?.GetSql(false, filterWrk2, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk2 = sqlWrk2 != null ? Connection.GetRows(sqlWrk2) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk2?.Count > 0 && idPlantTujuan.Lookup != null) { // Lookup values found
                        var listwrk = idPlantTujuan.Lookup?.RenderViewRow(rswrk2[0]);
                        idPlantTujuan.ViewValue = idPlantTujuan.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            idPlantTujuan.ViewCustomAttributes = "";

            // Panjang
            Panjang.ViewValue = Panjang.CurrentValue;
            Panjang.ViewValue = FormatNumber(Panjang.ViewValue, Panjang.FormatPattern);
            Panjang.ViewCustomAttributes = "";

            // Diameter
            Diameter.ViewValue = Diameter.CurrentValue;
            Diameter.ViewValue = FormatNumber(Diameter.ViewValue, Diameter.FormatPattern);
            Diameter.ViewCustomAttributes = "";

            // Volume
            Volume.ViewValue = Volume.CurrentValue;
            Volume.ViewValue = FormatNumber(Volume.ViewValue, Volume.FormatPattern);
            Volume.ViewCustomAttributes = "";

            // Flowrate
            Flowrate.ViewValue = Flowrate.CurrentValue;
            Flowrate.ViewValue = FormatNumber(Flowrate.ViewValue, Flowrate.FormatPattern);
            Flowrate.ViewCustomAttributes = "";

            // idPlantTujuan2

            // awallookupbung
            string curVal3 = ConvertToString(idPlantTujuan2.CurrentValue);
            idPlantTujuan2.ViewValue = Empty(curVal3) ? DbNullValue : FormatNumber(idPlantTujuan2.CurrentValue, idPlantTujuan2.FormatPattern);
            if (!Empty(curVal3)) {
                if (idPlantTujuan2.Lookup != null && IsDictionary(idPlantTujuan2.Lookup?.Options) && idPlantTujuan2.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idPlantTujuan2.ViewValue = idPlantTujuan2.LookupCacheOption(curVal3);
                } else { // Lookup from database // DN
                    string filterWrk3 = SearchFilter(idPlantTujuan2.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan2.CurrentValue, idPlantTujuan2.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk3 = idPlantTujuan2.Lookup?.GetSql(false, filterWrk3, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk3 = sqlWrk3 != null ? Connection.GetRows(sqlWrk3) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk3?.Count > 0 && idPlantTujuan2.Lookup != null) { // Lookup values found
                        var listwrk = idPlantTujuan2.Lookup?.RenderViewRow(rswrk3[0]);
                        idPlantTujuan2.ViewValue = idPlantTujuan2.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            idPlantTujuan2.ViewCustomAttributes = "";

            // Panjang2
            Panjang2.ViewValue = Panjang2.CurrentValue;
            Panjang2.ViewValue = FormatNumber(Panjang2.ViewValue, Panjang2.FormatPattern);
            Panjang2.ViewCustomAttributes = "";

            // Diameter2
            Diameter2.ViewValue = Diameter2.CurrentValue;
            Diameter2.ViewValue = FormatNumber(Diameter2.ViewValue, Diameter2.FormatPattern);
            Diameter2.ViewCustomAttributes = "";

            // Volume2
            Volume2.ViewValue = Volume2.CurrentValue;
            Volume2.ViewValue = FormatNumber(Volume2.ViewValue, Volume2.FormatPattern);
            Volume2.ViewCustomAttributes = "";

            // Flowrate2
            Flowrate2.ViewValue = Flowrate2.CurrentValue;
            Flowrate2.ViewValue = FormatNumber(Flowrate2.ViewValue, Flowrate2.FormatPattern);
            Flowrate2.ViewCustomAttributes = "";

            // idPlantTujuan3

            // awallookupbung
            string curVal4 = ConvertToString(idPlantTujuan3.CurrentValue);
            idPlantTujuan3.ViewValue = Empty(curVal4) ? DbNullValue : FormatNumber(idPlantTujuan3.CurrentValue, idPlantTujuan3.FormatPattern);
            if (!Empty(curVal4)) {
                if (idPlantTujuan3.Lookup != null && IsDictionary(idPlantTujuan3.Lookup?.Options) && idPlantTujuan3.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    idPlantTujuan3.ViewValue = idPlantTujuan3.LookupCacheOption(curVal4);
                } else { // Lookup from database // DN
                    string filterWrk4 = SearchFilter(idPlantTujuan3.Lookup?.GetTable()?.Fields["IdPlant"].SearchExpression, "=", idPlantTujuan3.CurrentValue, idPlantTujuan3.Lookup?.GetTable()?.Fields["IdPlant"].SearchDataType, "");
                    string? sqlWrk4 = idPlantTujuan3.Lookup?.GetSql(false, filterWrk4, null, this, true, true);
                    List<Dictionary<string, object>>? rswrk4 = sqlWrk4 != null ? Connection.GetRows(sqlWrk4) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk4?.Count > 0 && idPlantTujuan3.Lookup != null) { // Lookup values found
                        var listwrk = idPlantTujuan3.Lookup?.RenderViewRow(rswrk4[0]);
                        idPlantTujuan3.ViewValue = idPlantTujuan3.DisplayValue(listwrk);
                    }
                }
            }

            // akhirlookupbung
            idPlantTujuan3.ViewCustomAttributes = "";

            // Panjang3
            Panjang3.ViewValue = Panjang3.CurrentValue;
            Panjang3.ViewValue = FormatNumber(Panjang3.ViewValue, Panjang3.FormatPattern);
            Panjang3.ViewCustomAttributes = "";

            // Diameter3
            Diameter3.ViewValue = Diameter3.CurrentValue;
            Diameter3.ViewValue = FormatNumber(Diameter3.ViewValue, Diameter3.FormatPattern);
            Diameter3.ViewCustomAttributes = "";

            // Volume3
            Volume3.ViewValue = Volume3.CurrentValue;
            Volume3.ViewValue = FormatNumber(Volume3.ViewValue, Volume3.FormatPattern);
            Volume3.ViewCustomAttributes = "";

            // Flowrate3
            Flowrate3.ViewValue = Flowrate3.CurrentValue;
            Flowrate3.ViewValue = FormatNumber(Flowrate3.ViewValue, Flowrate3.FormatPattern);
            Flowrate3.ViewCustomAttributes = "";

            // BiayaProject
            BiayaProject.ViewValue = BiayaProject.CurrentValue;
            BiayaProject.ViewValue = FormatNumber(BiayaProject.ViewValue, BiayaProject.FormatPattern);
            BiayaProject.ViewCustomAttributes = "";

            // PlantAsal
            PlantAsal.ViewValue = ConvertToString(PlantAsal.CurrentValue); // DN
            PlantAsal.ViewCustomAttributes = "";

            // NamaPlantAsal
            NamaPlantAsal.ViewValue = ConvertToString(NamaPlantAsal.CurrentValue); // DN
            NamaPlantAsal.ViewCustomAttributes = "";

            // PlantTujuan
            PlantTujuan.ViewValue = ConvertToString(PlantTujuan.CurrentValue); // DN
            PlantTujuan.ViewCustomAttributes = "";

            // NamaPlantTujuan
            NamaPlantTujuan.ViewValue = ConvertToString(NamaPlantTujuan.CurrentValue); // DN
            NamaPlantTujuan.ViewCustomAttributes = "";

            // PlantTujuan2
            PlantTujuan2.ViewValue = ConvertToString(PlantTujuan2.CurrentValue); // DN
            PlantTujuan2.ViewCustomAttributes = "";

            // NamaPlantTujuan2
            NamaPlantTujuan2.ViewValue = ConvertToString(NamaPlantTujuan2.CurrentValue); // DN
            NamaPlantTujuan2.ViewCustomAttributes = "";

            // PlantTujuan3
            PlantTujuan3.ViewValue = ConvertToString(PlantTujuan3.CurrentValue); // DN
            PlantTujuan3.ViewCustomAttributes = "";

            // NamaPlantTujuan3
            NamaPlantTujuan3.ViewValue = ConvertToString(NamaPlantTujuan3.CurrentValue); // DN
            NamaPlantTujuan3.ViewCustomAttributes = "";

            // CreatedBy
            CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
            CreatedBy.ViewCustomAttributes = "";

            // etlDate
            etlDate.ViewValue = etlDate.CurrentValue;
            etlDate.ViewValue = FormatDateTime(etlDate.ViewValue, etlDate.FormatPattern);
            etlDate.ViewCustomAttributes = "";

            // LastUpdatedBy
            LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
            LastUpdatedBy.ViewCustomAttributes = "";

            // LastUpdatedDate
            LastUpdatedDate.ViewValue = LastUpdatedDate.CurrentValue;
            LastUpdatedDate.ViewValue = FormatDateTime(LastUpdatedDate.ViewValue, LastUpdatedDate.FormatPattern);
            LastUpdatedDate.ViewCustomAttributes = "";

            // id
            id.HrefValue = "";
            id.TooltipValue = "";

            // KeteranganPipa
            KeteranganPipa.HrefValue = "";
            KeteranganPipa.TooltipValue = "";

            // idPlantAsal
            idPlantAsal.HrefValue = "";
            idPlantAsal.TooltipValue = "";

            // idPlantTujuan
            idPlantTujuan.HrefValue = "";
            idPlantTujuan.TooltipValue = "";

            // Panjang
            Panjang.HrefValue = "";
            Panjang.TooltipValue = "";

            // Diameter
            Diameter.HrefValue = "";
            Diameter.TooltipValue = "";

            // Volume
            Volume.HrefValue = "";
            Volume.TooltipValue = "";

            // Flowrate
            Flowrate.HrefValue = "";
            Flowrate.TooltipValue = "";

            // idPlantTujuan2
            idPlantTujuan2.HrefValue = "";
            idPlantTujuan2.TooltipValue = "";

            // Panjang2
            Panjang2.HrefValue = "";
            Panjang2.TooltipValue = "";

            // Diameter2
            Diameter2.HrefValue = "";
            Diameter2.TooltipValue = "";

            // Volume2
            Volume2.HrefValue = "";
            Volume2.TooltipValue = "";

            // Flowrate2
            Flowrate2.HrefValue = "";
            Flowrate2.TooltipValue = "";

            // idPlantTujuan3
            idPlantTujuan3.HrefValue = "";
            idPlantTujuan3.TooltipValue = "";

            // Panjang3
            Panjang3.HrefValue = "";
            Panjang3.TooltipValue = "";

            // Diameter3
            Diameter3.HrefValue = "";
            Diameter3.TooltipValue = "";

            // Volume3
            Volume3.HrefValue = "";
            Volume3.TooltipValue = "";

            // Flowrate3
            Flowrate3.HrefValue = "";
            Flowrate3.TooltipValue = "";

            // BiayaProject
            BiayaProject.HrefValue = "";
            BiayaProject.TooltipValue = "";

            // PlantAsal
            PlantAsal.HrefValue = "";
            PlantAsal.TooltipValue = "";

            // NamaPlantAsal
            NamaPlantAsal.HrefValue = "";
            NamaPlantAsal.TooltipValue = "";

            // PlantTujuan
            PlantTujuan.HrefValue = "";
            PlantTujuan.TooltipValue = "";

            // NamaPlantTujuan
            NamaPlantTujuan.HrefValue = "";
            NamaPlantTujuan.TooltipValue = "";

            // PlantTujuan2
            PlantTujuan2.HrefValue = "";
            PlantTujuan2.TooltipValue = "";

            // NamaPlantTujuan2
            NamaPlantTujuan2.HrefValue = "";
            NamaPlantTujuan2.TooltipValue = "";

            // PlantTujuan3
            PlantTujuan3.HrefValue = "";
            PlantTujuan3.TooltipValue = "";

            // NamaPlantTujuan3
            NamaPlantTujuan3.HrefValue = "";
            NamaPlantTujuan3.TooltipValue = "";

            // CreatedBy
            CreatedBy.HrefValue = "";
            CreatedBy.TooltipValue = "";

            // etlDate
            etlDate.HrefValue = "";
            etlDate.TooltipValue = "";

            // LastUpdatedBy
            LastUpdatedBy.HrefValue = "";
            LastUpdatedBy.TooltipValue = "";

            // LastUpdatedDate
            LastUpdatedDate.HrefValue = "";
            LastUpdatedDate.TooltipValue = "";

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

            // KeteranganPipa
            KeteranganPipa.SetupEditAttributes();
            if (!KeteranganPipa.Raw)
                KeteranganPipa.CurrentValue = HtmlDecode(KeteranganPipa.CurrentValue);
            KeteranganPipa.EditValue = KeteranganPipa.CurrentValue;
            KeteranganPipa.PlaceHolder = RemoveHtml(KeteranganPipa.Caption);

            // idPlantAsal
            idPlantAsal.SetupEditAttributes();
            idPlantAsal.PlaceHolder = RemoveHtml(idPlantAsal.Caption);
            if (!Empty(idPlantAsal.EditValue) && IsNumeric(idPlantAsal.EditValue))
                idPlantAsal.EditValue = FormatNumber(idPlantAsal.EditValue, null);

            // idPlantTujuan
            idPlantTujuan.SetupEditAttributes();
            idPlantTujuan.PlaceHolder = RemoveHtml(idPlantTujuan.Caption);
            if (!Empty(idPlantTujuan.EditValue) && IsNumeric(idPlantTujuan.EditValue))
                idPlantTujuan.EditValue = FormatNumber(idPlantTujuan.EditValue, null);

            // Panjang
            Panjang.SetupEditAttributes();
            Panjang.EditValue = Panjang.CurrentValue;
            Panjang.PlaceHolder = RemoveHtml(Panjang.Caption);
            if (!Empty(Panjang.EditValue) && IsNumeric(Panjang.EditValue))
                Panjang.EditValue = FormatNumber(Panjang.EditValue, null);

            // Diameter
            Diameter.SetupEditAttributes();
            Diameter.EditValue = Diameter.CurrentValue;
            Diameter.PlaceHolder = RemoveHtml(Diameter.Caption);
            if (!Empty(Diameter.EditValue) && IsNumeric(Diameter.EditValue))
                Diameter.EditValue = FormatNumber(Diameter.EditValue, null);

            // Volume
            Volume.SetupEditAttributes();
            Volume.EditValue = Volume.CurrentValue;
            Volume.PlaceHolder = RemoveHtml(Volume.Caption);
            if (!Empty(Volume.EditValue) && IsNumeric(Volume.EditValue))
                Volume.EditValue = FormatNumber(Volume.EditValue, null);

            // Flowrate
            Flowrate.SetupEditAttributes();
            Flowrate.EditValue = Flowrate.CurrentValue;
            Flowrate.PlaceHolder = RemoveHtml(Flowrate.Caption);
            if (!Empty(Flowrate.EditValue) && IsNumeric(Flowrate.EditValue))
                Flowrate.EditValue = FormatNumber(Flowrate.EditValue, null);

            // idPlantTujuan2
            idPlantTujuan2.SetupEditAttributes();
            idPlantTujuan2.PlaceHolder = RemoveHtml(idPlantTujuan2.Caption);
            if (!Empty(idPlantTujuan2.EditValue) && IsNumeric(idPlantTujuan2.EditValue))
                idPlantTujuan2.EditValue = FormatNumber(idPlantTujuan2.EditValue, null);

            // Panjang2
            Panjang2.SetupEditAttributes();
            Panjang2.EditValue = Panjang2.CurrentValue;
            Panjang2.PlaceHolder = RemoveHtml(Panjang2.Caption);
            if (!Empty(Panjang2.EditValue) && IsNumeric(Panjang2.EditValue))
                Panjang2.EditValue = FormatNumber(Panjang2.EditValue, null);

            // Diameter2
            Diameter2.SetupEditAttributes();
            Diameter2.EditValue = Diameter2.CurrentValue;
            Diameter2.PlaceHolder = RemoveHtml(Diameter2.Caption);
            if (!Empty(Diameter2.EditValue) && IsNumeric(Diameter2.EditValue))
                Diameter2.EditValue = FormatNumber(Diameter2.EditValue, null);

            // Volume2
            Volume2.SetupEditAttributes();
            Volume2.EditValue = Volume2.CurrentValue;
            Volume2.PlaceHolder = RemoveHtml(Volume2.Caption);
            if (!Empty(Volume2.EditValue) && IsNumeric(Volume2.EditValue))
                Volume2.EditValue = FormatNumber(Volume2.EditValue, null);

            // Flowrate2
            Flowrate2.SetupEditAttributes();
            Flowrate2.EditValue = Flowrate2.CurrentValue;
            Flowrate2.PlaceHolder = RemoveHtml(Flowrate2.Caption);
            if (!Empty(Flowrate2.EditValue) && IsNumeric(Flowrate2.EditValue))
                Flowrate2.EditValue = FormatNumber(Flowrate2.EditValue, null);

            // idPlantTujuan3
            idPlantTujuan3.SetupEditAttributes();
            idPlantTujuan3.PlaceHolder = RemoveHtml(idPlantTujuan3.Caption);
            if (!Empty(idPlantTujuan3.EditValue) && IsNumeric(idPlantTujuan3.EditValue))
                idPlantTujuan3.EditValue = FormatNumber(idPlantTujuan3.EditValue, null);

            // Panjang3
            Panjang3.SetupEditAttributes();
            Panjang3.EditValue = Panjang3.CurrentValue;
            Panjang3.PlaceHolder = RemoveHtml(Panjang3.Caption);
            if (!Empty(Panjang3.EditValue) && IsNumeric(Panjang3.EditValue))
                Panjang3.EditValue = FormatNumber(Panjang3.EditValue, null);

            // Diameter3
            Diameter3.SetupEditAttributes();
            Diameter3.EditValue = Diameter3.CurrentValue;
            Diameter3.PlaceHolder = RemoveHtml(Diameter3.Caption);
            if (!Empty(Diameter3.EditValue) && IsNumeric(Diameter3.EditValue))
                Diameter3.EditValue = FormatNumber(Diameter3.EditValue, null);

            // Volume3
            Volume3.SetupEditAttributes();
            Volume3.EditValue = Volume3.CurrentValue;
            Volume3.PlaceHolder = RemoveHtml(Volume3.Caption);
            if (!Empty(Volume3.EditValue) && IsNumeric(Volume3.EditValue))
                Volume3.EditValue = FormatNumber(Volume3.EditValue, null);

            // Flowrate3
            Flowrate3.SetupEditAttributes();
            Flowrate3.EditValue = Flowrate3.CurrentValue;
            Flowrate3.PlaceHolder = RemoveHtml(Flowrate3.Caption);
            if (!Empty(Flowrate3.EditValue) && IsNumeric(Flowrate3.EditValue))
                Flowrate3.EditValue = FormatNumber(Flowrate3.EditValue, null);

            // BiayaProject
            BiayaProject.SetupEditAttributes();
            BiayaProject.EditValue = BiayaProject.CurrentValue;
            BiayaProject.PlaceHolder = RemoveHtml(BiayaProject.Caption);
            if (!Empty(BiayaProject.EditValue) && IsNumeric(BiayaProject.EditValue))
                BiayaProject.EditValue = FormatNumber(BiayaProject.EditValue, null);

            // PlantAsal
            PlantAsal.SetupEditAttributes();
            if (!PlantAsal.Raw)
                PlantAsal.CurrentValue = HtmlDecode(PlantAsal.CurrentValue);
            PlantAsal.EditValue = PlantAsal.CurrentValue;
            PlantAsal.PlaceHolder = RemoveHtml(PlantAsal.Caption);

            // NamaPlantAsal
            NamaPlantAsal.SetupEditAttributes();
            if (!NamaPlantAsal.Raw)
                NamaPlantAsal.CurrentValue = HtmlDecode(NamaPlantAsal.CurrentValue);
            NamaPlantAsal.EditValue = NamaPlantAsal.CurrentValue;
            NamaPlantAsal.PlaceHolder = RemoveHtml(NamaPlantAsal.Caption);

            // PlantTujuan
            PlantTujuan.SetupEditAttributes();
            if (!PlantTujuan.Raw)
                PlantTujuan.CurrentValue = HtmlDecode(PlantTujuan.CurrentValue);
            PlantTujuan.EditValue = PlantTujuan.CurrentValue;
            PlantTujuan.PlaceHolder = RemoveHtml(PlantTujuan.Caption);

            // NamaPlantTujuan
            NamaPlantTujuan.SetupEditAttributes();
            if (!NamaPlantTujuan.Raw)
                NamaPlantTujuan.CurrentValue = HtmlDecode(NamaPlantTujuan.CurrentValue);
            NamaPlantTujuan.EditValue = NamaPlantTujuan.CurrentValue;
            NamaPlantTujuan.PlaceHolder = RemoveHtml(NamaPlantTujuan.Caption);

            // PlantTujuan2
            PlantTujuan2.SetupEditAttributes();
            if (!PlantTujuan2.Raw)
                PlantTujuan2.CurrentValue = HtmlDecode(PlantTujuan2.CurrentValue);
            PlantTujuan2.EditValue = PlantTujuan2.CurrentValue;
            PlantTujuan2.PlaceHolder = RemoveHtml(PlantTujuan2.Caption);

            // NamaPlantTujuan2
            NamaPlantTujuan2.SetupEditAttributes();
            if (!NamaPlantTujuan2.Raw)
                NamaPlantTujuan2.CurrentValue = HtmlDecode(NamaPlantTujuan2.CurrentValue);
            NamaPlantTujuan2.EditValue = NamaPlantTujuan2.CurrentValue;
            NamaPlantTujuan2.PlaceHolder = RemoveHtml(NamaPlantTujuan2.Caption);

            // PlantTujuan3
            PlantTujuan3.SetupEditAttributes();
            if (!PlantTujuan3.Raw)
                PlantTujuan3.CurrentValue = HtmlDecode(PlantTujuan3.CurrentValue);
            PlantTujuan3.EditValue = PlantTujuan3.CurrentValue;
            PlantTujuan3.PlaceHolder = RemoveHtml(PlantTujuan3.Caption);

            // NamaPlantTujuan3
            NamaPlantTujuan3.SetupEditAttributes();
            if (!NamaPlantTujuan3.Raw)
                NamaPlantTujuan3.CurrentValue = HtmlDecode(NamaPlantTujuan3.CurrentValue);
            NamaPlantTujuan3.EditValue = NamaPlantTujuan3.CurrentValue;
            NamaPlantTujuan3.PlaceHolder = RemoveHtml(NamaPlantTujuan3.Caption);

            // CreatedBy
            CreatedBy.SetupEditAttributes();
            if (!CreatedBy.Raw)
                CreatedBy.CurrentValue = HtmlDecode(CreatedBy.CurrentValue);
            CreatedBy.EditValue = CreatedBy.CurrentValue;
            CreatedBy.PlaceHolder = RemoveHtml(CreatedBy.Caption);

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

            // LastUpdatedDate
            LastUpdatedDate.SetupEditAttributes();
            LastUpdatedDate.EditValue = FormatDateTime(LastUpdatedDate.CurrentValue, LastUpdatedDate.FormatPattern);
            LastUpdatedDate.PlaceHolder = RemoveHtml(LastUpdatedDate.Caption);

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
                        doc.ExportCaption(KeteranganPipa);
                        doc.ExportCaption(idPlantAsal);
                        doc.ExportCaption(Flowrate);
                        doc.ExportCaption(BiayaProject);
                        doc.ExportCaption(PlantAsal);
                        doc.ExportCaption(NamaPlantAsal);
                        doc.ExportCaption(CreatedBy);
                        doc.ExportCaption(etlDate);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(LastUpdatedDate);
                    } else {
                        doc.ExportCaption(id);
                        doc.ExportCaption(KeteranganPipa);
                        doc.ExportCaption(idPlantAsal);
                        doc.ExportCaption(idPlantTujuan);
                        doc.ExportCaption(Panjang);
                        doc.ExportCaption(Diameter);
                        doc.ExportCaption(Volume);
                        doc.ExportCaption(Flowrate);
                        doc.ExportCaption(idPlantTujuan2);
                        doc.ExportCaption(Panjang2);
                        doc.ExportCaption(Diameter2);
                        doc.ExportCaption(Volume2);
                        doc.ExportCaption(Flowrate2);
                        doc.ExportCaption(idPlantTujuan3);
                        doc.ExportCaption(Panjang3);
                        doc.ExportCaption(Diameter3);
                        doc.ExportCaption(Volume3);
                        doc.ExportCaption(Flowrate3);
                        doc.ExportCaption(BiayaProject);
                        doc.ExportCaption(PlantAsal);
                        doc.ExportCaption(NamaPlantAsal);
                        doc.ExportCaption(PlantTujuan);
                        doc.ExportCaption(NamaPlantTujuan);
                        doc.ExportCaption(PlantTujuan2);
                        doc.ExportCaption(NamaPlantTujuan2);
                        doc.ExportCaption(PlantTujuan3);
                        doc.ExportCaption(NamaPlantTujuan3);
                        doc.ExportCaption(CreatedBy);
                        doc.ExportCaption(etlDate);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(LastUpdatedDate);
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
                            await doc.ExportField(KeteranganPipa);
                            await doc.ExportField(idPlantAsal);
                            await doc.ExportField(Flowrate);
                            await doc.ExportField(BiayaProject);
                            await doc.ExportField(PlantAsal);
                            await doc.ExportField(NamaPlantAsal);
                            await doc.ExportField(CreatedBy);
                            await doc.ExportField(etlDate);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(LastUpdatedDate);
                        } else {
                            await doc.ExportField(id);
                            await doc.ExportField(KeteranganPipa);
                            await doc.ExportField(idPlantAsal);
                            await doc.ExportField(idPlantTujuan);
                            await doc.ExportField(Panjang);
                            await doc.ExportField(Diameter);
                            await doc.ExportField(Volume);
                            await doc.ExportField(Flowrate);
                            await doc.ExportField(idPlantTujuan2);
                            await doc.ExportField(Panjang2);
                            await doc.ExportField(Diameter2);
                            await doc.ExportField(Volume2);
                            await doc.ExportField(Flowrate2);
                            await doc.ExportField(idPlantTujuan3);
                            await doc.ExportField(Panjang3);
                            await doc.ExportField(Diameter3);
                            await doc.ExportField(Volume3);
                            await doc.ExportField(Flowrate3);
                            await doc.ExportField(BiayaProject);
                            await doc.ExportField(PlantAsal);
                            await doc.ExportField(NamaPlantAsal);
                            await doc.ExportField(PlantTujuan);
                            await doc.ExportField(NamaPlantTujuan);
                            await doc.ExportField(PlantTujuan2);
                            await doc.ExportField(NamaPlantTujuan2);
                            await doc.ExportField(PlantTujuan3);
                            await doc.ExportField(NamaPlantTujuan3);
                            await doc.ExportField(CreatedBy);
                            await doc.ExportField(etlDate);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(LastUpdatedDate);
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
            var idPlant     = rsnew["idPlantAsal"].ToString();
            DateTime plantTime = DateTime.Now;
            var plantObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @IdPlant = {idPlant}");
            if (plantObj != null && DateTime.TryParse(plantObj.ToString(), out var tmp))
                plantTime = tmp;
            rsnew["etlDate"] = plantTime;
            rsnew["CreatedBy"] = CurrentUserName();
            return true;
        }

        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
        }

        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            var idPlant     = rsnew["idPlantAsal"].ToString();
            DateTime plantTime = DateTime.Now;
            var plantObj = ExecuteScalar($"EXEC dbo.GetPlantDateTime @IdPlant = {idPlant}");
            if (plantObj != null && DateTime.TryParse(plantObj.ToString(), out var tmp))
                plantTime = tmp;
            rsnew["LastUpdatedDate"] = plantTime;
            rsnew["LastUpdatedBy"] = CurrentUserName();
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
