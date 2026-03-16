namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    // Configuration
    public static partial class Config
    {
        // Init
        public static void Init()
        {
            // Authentications
            Authentications = new() {
                {"Google", new() {
                    Enabled = false,
                    Id = Configuration["Google:Id"] ?? "",
                    Color = Configuration["Google:Color"] ?? "",
                    Secret = Configuration["Google:Secret"] ?? ""
                }},
                {"Facebook", new() {
                    Enabled = false,
                    Id = Configuration["Facebook:Id"] ?? "",
                    Color = Configuration["Facebook:Color"] ?? "",
                    Secret = Configuration["Facebook:Secret"] ?? ""
                }},
                {"Microsoft", new() { // Use "Microsoft" as key, not "Azure"
                    Enabled = false,
                    Id = Configuration["Azure:Id"] ?? "",
                    Color = Configuration["Azure:Color"] ?? "",
                    Secret = Configuration["Azure:Secret"] ?? ""
                }},
                {"Saml", new() {
                    Enabled = false,
                    Color = Configuration["Saml:Color"] ?? "",
                }}
            }; // DN

            // SMTP server
            SmtpServer = Configuration["Smtp:Server"] ?? ""; // SMTP server
            SmtpServerPort = ConvertToInt(Configuration["Smtp:Port"]); // SMTP server port
            SmtpSecureOption = Configuration["Smtp:SecureOption"] ?? "None"; // Default is None
            SmtpServerUsername = Configuration["Smtp:Username"] ?? ""; // SMTP server user name
            SmtpServerPassword = Configuration["Smtp:Password"] ?? ""; // SMTP server password

            // Config Init event
            ConfigInit();
            ConfigInitEventHandler?.Invoke(null, EventArgs.Empty);
        }

        // Config Init

        // Config Init event
        public static void ConfigInit() {
            // Enter your code here
        }

        // Debug
        public static bool Debug { get; set; } = false;

        public static string DebugMessageTemplate { get; set; } = @"<div class=""card card-danger ew-debug""><div class=""card-header""><h3 class=""card-title"">%t</h3><div class=""card-tools""><button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse""><i class=""fa-solid fa-minus""></i></button></div></div><div class=""card-body"">%s</div></div>";

        // Log SQL to file
        private static bool _logSqlEnabled = false;

        public static bool LogSqlEnabled
        {
            get => _logSqlEnabled;
            set => _logSqlEnabled = value;
        }

    // Product version
    public const string ProductVersion = "24.11.0";

        // Project
        public const string ProjectNamespace = "SnDOne";

        public const string ProjectClassName = "SnDOne.Models.SnDOne"; // DN

        public static string PathDelimiter { get; set; } = ConvertToString(Path.DirectorySeparatorChar); // Physical path delimiter // DN

        public static short UnformatYear { get; set; } = 50; // Unformat year

        public const string ProjectName = "SnDOne"; // Project name

        public static string ControllerName { get; set; } = "Home"; // Controller name // DN

        public const string ProjectId = "{92B91853-0216-4B42-B097-FA7CDF2469EB}"; // Project ID (GUID)

        public static readonly string RandomKey = "wnhefSbM58xZiG4z"; // Random key for encryption // DN

        public static string EncryptionKey { get; set; } = ""; // Encryption key for data protection

        public static readonly string ProjectStylesheetFilename = "css/sndone.css"; // Project stylesheet file name (relative to wwwroot)

        public static bool UseCompressedStylesheet { get; set; } = true; // Compressed stylesheet

        public static string FontAwesomeStylesheet { get; set; } = "plugins/fontawesome-free/css/all.min.css"; // Font Awesome Free stylesheet

        public static string Charset { get; set; } = "utf-8"; // Project charset

        public static string EmailCharset { get; set; } = Charset; // Email charset

        public static string EmailKeywordSeparator { get; set; } = ""; // Email keyword separator

        public static string CompositeKeySeparator { get; set; } = ","; // Composite key separator

        public static Dictionary<string, string> ExportTableCellSyles { get; set; } = new() // Export table cell CSS styles, use inline style for Gmail
        {
            { "border", "1px solid #dddddd" },
            { "padding", "5px" }
        };

        public static bool HighlightCompare { get; set; } = true; // Case-insensitive

        public static int FontSize { get; set; } = 14;

        public static bool Cache { get; set; } = false; // Cache // DN

        public static bool LazyLoad { get; set; } = true; // Lazy loading of images

        public static string RelatedProjectId { get; set; } = "";

        public static bool CheckOldUserLevels { get; set; } = false; // Check old Dynamic User Level Security settings

        public static bool DeleteUploadFiles { get; set; } = false; // Delete uploaded file on deleting record

        public static string FileNotFound { get; set; } = "/9j/4AAQSkZJRgABAQAAAQABAAD/7QAuUGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAABIcAigADEZpbGVOb3RGb3VuZAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wgARCAABAAEDAREAAhEBAxEB/8QAFAABAAAAAAAAAAAAAAAAAAAACP/EABQBAQAAAAAAAAAAAAAAAAAAAAD/2gAMAwEAAhADEAAAAD+f/8QAFBABAAAAAAAAAAAAAAAAAAAAAP/aAAgBAQABPwB//8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAgBAgEBPwB//8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAgBAwEBPwB//9k="; // 1x1 jpeg with IPTC data "2#040"="FileNotFound"

        public static string BodyClass { get; set; } = "hold-transition layout-fixed"; // CSS class(es) for <body> tag

        public static string BodyStyle { get; set; } = ""; // CSS style for <body> tag

        public static string SidebarClass { get; set; } = "main-sidebar sidebar-dark-primary"; // CSS class(es) for sidebar

        public static string NavbarClass { get; set; } = "main-header navbar navbar-expand navbar-primary navbar-dark border-bottom-0"; // CSS class(es) for navbar

        public static string ClassPrefix { get; set; } = "_"; // Prefix for invalid CSS class names

        public static bool UseJavascriptMessage { get; set; } = true; // Use JavaScript message (toast)

        // External JavaScripts
        public static List<string> JavaScriptFiles { get; set; } = new()
        {
        };

        // External StyleSheets
        public static List<string> StylesheetFiles { get; set; } = new()
        {
        };

        // Authentication configuration for Google/Facebook
        public static Dictionary<string, AuthenticationProvider> Authentications { get; set; } = new();

        // Database time zone
        // Difference to Greenwich time (GMT) with colon between hours and minutes, e.g. +02:00
        public static string DbTimeZone { get; set; } = "";

        // Password (hashed and case-sensitivity)
        // Note: If you enable hashed password, make sure that the passwords in your
        // user table are stored as hash of the clear text password. If you also use
        // case-insensitive password, convert the clear text passwords to lower case
        // first before calculating hash. Otherwise, existing users will not be able
        // to login. Hashed password is irreversible, it will be reset during password recovery.
        public static bool EncryptedPassword { get; set; } = true; // Encrypted password

        public static bool CaseSensitivePassword { get; set; } = false; // Case Sensitive password

        public static Encoding Md5Encoding { get; set; } = Encoding.Unicode; // Encoding for computing MD5 hash // DN

        // Remove XSS use HtmlSanitizer
        // Note: If you want to allow these keywords, remove them from the following array at your own risks.
        public static bool RemoveXssEnabled { get; set; } = true;

        // Check Token
        public static bool CheckToken { get; set; } = true; // Check post token by AntiforgeryToken // DN

        // Session timeout time
        public static int SessionTimeout { get; set; } = 15; // Session timeout time (minutes)

        // Session keep alive interval
        public static int SessionKeepAliveInterval { get; set; } = 60; // Session keep alive interval (seconds)

        public static int SessionTimeoutCountdown { get; set; } = 60; // Session timeout count down interval (seconds)

        // Session names
        public const string SessionStatus = ProjectName + "_Status"; // Login status

        public const string SessionUserName = SessionStatus + "_UserName"; // User name

        public const string SessionUserLoginType = SessionStatus + "_UserLoginType"; // User login type

        public const string SessionUserId = SessionStatus + "_UserID"; // User ID

        public const string SessionUserPrimaryKey = SessionStatus + "_UserPrimaryKey"; // User Profile

        public const string SessionUserProfile = SessionStatus + "_UserProfile"; // User Profile

        public const string SessionUserProfileUserName = SessionUserProfile + "_UserName";

        public const string SessionUserProfilePassword = SessionUserProfile + "_Password";

        public const string SessionUserProfileLoginType = SessionUserProfile + "_LoginType";

        public const string SessionUserProfileSecret = SessionUserProfile + "_Secret";

        public const string SessionUserProfileRecord = SessionUserProfile + "_Record";

        public const string SessionUserProfileSecurityCode = SessionUserProfile + "_SecurityCode";

        public const string SysAdminUserProfile = "UserProfile";

        public const string SysAdminEmailAddress = "EmailAddress";

        public const string SysAdminPhoneNumber = "PhoneNumber";

        public const string SessionUserLevelId = SessionStatus + "_UserLevel"; // User level ID

        public const string SessionUserLevelList = SessionStatus + "_UserLevelList"; // User Level List

        public const string SessionUserLevelListLoaded = SessionStatus + "_UserLevelListLoaded"; // User Level List Loaded

        public const string SessionUserLevel = SessionStatus + "_UserLevelValue"; // User level

        public const string SessionParentUserId = SessionStatus + "_ParentUserID"; // Parent user ID

        public const string SessionSysAdmin = ProjectName + "_SysAdmin"; // System admin

        public const string SessionProjectId = ProjectName + "_ProjectID"; // User Level project ID

        public const string SessionUserLevelArrays = ProjectName + "_UserLevelArrays"; // User level List // DN

        public const string SessionUserLevelPrivArrays = ProjectName + "_UserLevelPrivArrays"; // User level privilege List // DN

        public const string SessionUserLevelMessage = ProjectName + "_UserLevelMessage"; // User Level messsage

        public const string SessionMessage = ProjectName + "_Message"; // System message

        public const string SessionFailureMessage = ProjectName + "_FailureMessage"; // Failure message

        public const string SessionSuccessMessage = ProjectName + "_SuccessMessage"; // Success message

        public const string SessionWarningMessage = ProjectName + "_WarningMessage"; // Warning message

        public const string SessionMessageHeading = ProjectName + "_MessageHeading"; // Message heading

        public const string SessionInlineMode = ProjectName + "_InlineMode"; // Inline mode

        public const string SessionBreadcrumb = ProjectName + "_Breadcrumb"; // Breadcrumb

        public const string SessionHistory = ProjectName + "_History"; // History (Breadcrumb)

        public const string SessionTempImages = ProjectName + "_TempImages"; // Temp images

        public const string SessionDebugMessage = ProjectName + "_DebugMessage"; // Debug message

        public const string SessionLastRefreshTime = ProjectName + "_LastRefreshTime"; // Last refresh time

        public const string SessionCaptchaCode = ProjectName + "_Captcha"; // Captcha code

        // Language settings
        public static List<string> Languages { get; set; } = ["en-US"];

        public static string LanguagesFile { get; set; } = "languages.xml";

        public static string LanguageFolder { get; set; } = "lang/";

        public static string DefaultLanguageId { get; set; } = "en-US";

        public const string SessionLanguageId = ProjectName + "_LanguageId"; // Language ID

        public static string LocaleFolder { get; set; } = "locale/";

        public const string SessionActiveUsers = ProjectName + "_ActiveUsers"; // Active Users

        // Page token
        public const string TokenNameKey = "csrf_name";

        public const string TokenName = "__RequestVerificationToken"; // DO NOT CHANGE! // DN

        public const string TokenValueKey = "__RequestVerificationToken"; // DO NOT CHANGE! // DN

        public const string SessionToken = ProjectName + "_Token";

        // Use database transaction
        public static bool UseTransaction { get; set; } = true;

        // Query timeout for query factory // DN
        public static int QueryTimeout { get; set; } = 30;

        // Data types
        public static List<DataType> CustomTemplateDataTypes { get; set; } = [DataType.Number, DataType.Date, DataType.String, DataType.Boolean, DataType.Time]; // Data to be passed to Custom Template

        public static int DataStringMaxLength { get; set; } = 1024;

        // Empty/all values
        public const string EmptyValue = "##empty##";

        public const string AllValue = "##all##";

        // Boolean values for ENUM('Y'/'N') or ENUM(1/0)
        public const string TrueString = "'Y'";

        public const string FalseString = "'N'";

        // List actions
        public const string ActionPostback = "P"; // Post back

        public const string ActionAjax = "A"; // Ajax

        public const string ActionMultiple = "M"; // Multiple records

        public const string ActionSingle = "S"; // Single record

        public const string ActionCustom = "C"; // Custom HTML

        // Table parameters
        public const string TableRecordsPerPage = "recperpage"; // Records per page

        public const string TableStartRec = "start"; // Start record

        public const string TablePageNumber = "page"; // Page number

        public const string TableBasicSearch = "search"; // Basic search keyword

        public const string TableBasicSearchType = "searchtype"; // Basic search type

        public const string TableAdvancedSearch = "advsrch"; // Advanced search

        public const string TableSearchWhere = "searchwhere"; // Search where clause

        public const string TableWhere = "where"; // Table where

        public const string TableOrderBy = "orderby"; // Table order by

        public const string TableOrderByList = "orderbylist"; // Table order by (list page)

        public const string TableRules = "rules"; // Table rules (QueryBuilder)

        public const string DashboardFilter = "dashboardfilter"; // Table filter for dashboard search

        public const string TableDetailOrderBy = "detailorderby"; // Table detail order by (report page)

        public const string TableSort = "sort"; // Table sort

        public const string TableKey = "key"; // Table key

        public const string TableShowMaster = "showmaster"; // Table show master

        public const string TableMaster = "master"; // Table show master (alternate key)

        public const string TableShowDetail = "showdetail"; // Table show detail

        public const string TableMasterTable = "mastertable"; // Master table

        public const string TableDetailTable = "detailtable"; // Detail table

        public const string TableReturnUrl = "return"; // Return URL

        public const string TableExportReturnUrl = "exportreturn"; // Export return URL

        public const string TableGridAddRowCount = "gridaddcnt"; // Grid add row count

        // Page layout
        public const string PageLayout = "layout"; // Page layout

        public static List<string> PageLayouts { get; set; } = [ // Supported page layouts
            "table",
            "cards"
        ];

        // Page dashboard
        public const string PageDashboard = "dashboard"; // Page is dashboard

        // Log user ID or user name
        public static bool LogUserId { get; set; } = true; // Log user ID

        // Audit Trail
        public static bool AuditTrailToDatabase { get; set; } = true; // Write to database

        public static string AuditTrailDbId { get; set; } = "DB"; // DB ID

        public static string AuditTrailTableName { get; set; } = "AuditTrail"; // Table name

        public static string AuditTrailTableVar { get; set; } = "AuditTrail"; // Table var

        public static string AuditTrailFieldNameDateTime { get; set; } = "DateTime"; // DateTime field name

        public static string AuditTrailFieldNameScript { get; set; } = "Script"; // Script field name

        public static string AuditTrailFieldNameUser { get; set; } = "User"; // User field name

        public static string AuditTrailFieldNameAction { get; set; } = "Action"; // Action field name

        public static string AuditTrailFieldNameTable { get; set; } = "Table"; // Table field name

        public static string AuditTrailFieldNameField { get; set; } = "Field"; // Field field name

        public static string AuditTrailFieldNameKeyvalue { get; set; } = "KeyValue"; // Key Value field name

        public static string AuditTrailFieldNameOldvalue { get; set; } = "OldValue"; // Old Value field name

        public static string AuditTrailFieldNameNewvalue { get; set; } = "NewValue"; // New Value field name

        // Export Log
        public static string ExportPathEnable { get; set; } = "export-92b91853-0216-4b42-b097-fa7cdf2469eb"; // Export folder

        public static string ExportLogDbId { get; set; } = "DB"; // DB ID

        public static string ExportLogTableName { get; set; } = ""; // Table name

        public static string ExportLogTableVar { get; set; } = ""; // Table var

        public static string ExportLogFieldNameFileId { get; set; } = "undefined"; // File id (GUID) field name

        public static string ExportLogFieldNameDateTime { get; set; } = "undefined"; // DateTime field name

        public static string ExportLogFieldNameDateTimeAlias { get; set; } = "datetime"; // DateTime field name Alias

        public static string ExportLogFieldNameUser { get; set; } = "undefined"; // User field name

        public static string ExportLogFieldNameExportType { get; set; } = "undefined"; // Export Type field name

        public static string ExportLogFieldNameExportTypeAlias { get; set; } = "type"; // Export Type field name Alias

        public static string ExportLogFieldNameTable { get; set; } = "undefined"; // Table field name

        public static string ExportLogFieldNameTableAlias { get; set; } = "tablename"; // Table field name Alias

        public static string ExportLogFieldNameKeyValue { get; set; } = "undefined"; // Key Value field name

        public static string ExportLogFieldNameFileName { get; set; } = "undefined"; // File name field name

        public static string ExportLogFieldNameFileNameAlias { get; set; } = "filename"; // File name field name Alias

        public static string ExportLogFieldNameRequest { get; set; } = "undefined"; // Request field name

        public static int ExportFilesExpiryTime { get; set; } = 0; // Files expiry time (minutes)

        public static string ExportLogSearch { get; set; } = "search"; // Export log search

        public static string ExportLogLimit { get; set; } = "limit"; // Search by limit

        public static string ExportLogArchivePrefix { get; set; } = "export"; // Export log archive prefix

        public static readonly bool LogAllExportRequests = false; // Log all export requests

        // Push Notification keys
        public static string PushServerPublicKey { get; set; } = ""; // Public Key

        public static string PushServerPrivateKey { get; set; } = ""; // Private Key
        // Subscription table for Push Notification
        public static string SubscriptionDbId { get; set; } = "DB"; // Subscription DB ID

        public static string SubscriptionTable { get; set; } = "undefined"; // Subscription table

        public static string SubscriptionTableName { get; set; } = ""; // Subscription table name

        public static string SubscriptionTableVar { get; set; } = ""; // Subscription table var

        public static string SubscriptionFieldNameId { get; set; } = ""; // Subscription Id field name

        public static string SubscriptionFieldNameUser { get; set; } = ""; // Subscription User field name

        public static string SubscriptionFieldNameEndpoint { get; set; } = ""; // Subscription Endpoint field name

        public static string SubscriptionFieldNamePublicKey { get; set; } = ""; // Subscription Public Key field name

        public static string SubscriptionFieldNameAuthToken { get; set; } = ""; // Subscription Auth Token field name

        public static string SubscriptionFieldNameContentEncoding { get; set; } = ""; // Subscription Auth Token field name

        // Security
        public static bool EncryptionEnabled { get; set; } = false; // Encryption enabled

        public static bool EncryptUserNameAndPassword { get; set; } = false; // Encrypt user name / password

        public static string AdminUserName { get; set; } = "admin"; // Administrator user name

        public static string AdminPassword { get; set; } = "Pat@ad111!n?#"; // Administrator password

        public static bool UseCustomLogin { get; set; } = true; // Use custom login (Windows/LDAP/User_CustomValidate)

        public static bool AllowLoginByUrl { get; set; } = true; // Allow login by URL

        public static bool PasswordHash { get; set; } = false; // Use BCrypt.Net-Next password hashing functions

        public static bool UseModalLogin { get; set; } = false; // Use modal login

        public static bool UseModalRegister { get; set; } = false; // Use modal register

        public static bool UseModalChangePassword { get; set; } = true; // Use modal change password

        public static readonly bool UseModalResetPassword = false; // Use modal reset password

        public static int ResetPasswordTimeLimit { get; set; } = 60; // Reset password time limit (minutes)

        public static bool IsWindowsAuthentication { get; set; } = false; // Windows Authentication // DN

        public static string SamlAuthenticationType { get; set; } = "Federation"; // DN

        // User Level table/field
        public static string UserLevelDbId { get; set; } = "DB"; // Database ID

        public static string UserLevelTableName { get; set; } = "UserLevels"; // User level (table name)

        public static string UserLevelIdFieldName { get; set; } = "UserLevelID"; // Id (field name)

        public static string UserLevelNameFieldName { get; set; } = "UserLevelName"; // Name (field name)

        public static string UserLevelTable { get; set; } = "dbo.UserLevels"; // For SQL

        public static string UserLevelIdField { get; set; } = "UserLevelID"; // For SQL

        public static string UserLevelNameField { get; set; } = "UserLevelName"; // For SQL

        // User Level Permissions table/field
        public static string UserLevelPrivDbId { get; set; } = "DB"; // Database ID

        public static string UserLevelPrivTableName { get; set; } = "UserLevelPermissions"; // User level permissions (table name)

        public static string UserLevelPrivTableNameFieldName { get; set; } = "TableName"; // Table name (field name)

        public static string UserLevelPrivUserLevelIdFieldName { get; set; } = "UserLevelID"; // User level ID (field name)

        public static string UserLevelPrivPrivFieldName { get; set; } = "Permission"; // Priv (field name)

        public static string UserLevelPrivTable { get; set; } = "dbo.UserLevelPermissions"; // For SQL

        public static string UserLevelPrivTableNameField { get; set; } = "TableName"; // For SQL

        public static string UserLevelPrivUserLevelIdField { get; set; } = "UserLevelID"; // For SQL

        public static string UserLevelPrivPrivField { get; set; } = "Permission"; // For SQL

        public static int UserLevelPrivTableNameFieldSize { get; set; } = 255;

        // User ID
        public static int DefaultUserIdAllowSecurity { get; set; } = 360;

        // User table/field names
        public static string UserTableName { get; set; } = "MasterUser";

        public static string UserPrimaryKeyFieldName { get; set; } = "IdUser";

        public static string LoginUsernameFieldName { get; set; } = "Username";

        public static string LoginPasswordFieldName { get; set; } = "PasswordHash";

        public static string UserIdFieldName { get; set; } = "";

        public static string ParentUserIdFieldName { get; set; } = "";

        public static string UserLevelFieldName { get; set; } = "UserLevel";

        public static string UserProfileFieldName { get; set; } = "";

        public static bool RegisterActivate { get; set; } = false;

        public static bool RegisterAutoLogin { get; set; } = false;

        public static string RegisterActivateFieldName { get; set; } = "";

        public static string RegisterActivateFieldValue { get; set; } = "1";

        public static readonly string UserEmailFieldName = "Email";

        public static string UserPhoneFieldName { get; set; } = "";

        public static string UserImageFieldName { get; set; } = "";

        public static int UserImageSize { get; set; } = 40;

        public static bool UserImageCrop { get; set; } = true;

        // User table filters
        public static string UserTableDbId { get; set; } = "DB";

        public static string UserTableDefault { get; set; } = "dbo.MasterUser";

        public static string UserNameFilter { get; set; } = "([Username] = '%u')";

        public static string UserIdFilter { get; set; } = "";

        public static readonly string UserEmailFilter = "([Email] = '%e')";

        public static string UserActivateFilter { get; set; } = "";

        public static string SearchFilterOption { get; set; } = "Client";

        // Auto hide pager
        public static bool AutoHidePager { get; set; } = false;

        public static bool AutoHidePageSizeSelector { get; set; } = false;

        // Email
        public static string EmailClass { get; set; } = "Email"; // Email class

        public static string SmtpServer { get; set; } = ""; // SMTP server

        public static int SmtpServerPort { get; set; } = 0; // SMTP server port

        public static string SmtpSecureOption { get; set; } = "None"; // SMTP secure options

        public static string SmtpServerUsername { get; set; } = ""; // SMTP server user name

        public static string SmtpServerPassword { get; set; } = ""; // SMTP server password

        public static readonly string SenderEmail = "anharkhoirun@gmail.com"; // Sender email

        public static string RecipientEmail { get; set; } = ""; // Recipient email

        public static int MaxEmailRecipient { get; set; } = 3;

        public static int MaxEmailSentCount { get; set; } = 3;

        public static string ExportEmailCounter { get; set; } = SessionStatus + "_EmailCounter";

        // Email/SMS Templates // DN
        public static string EmailChangePasswordTemplate { get; set; } = "ChangePassword";

        public static string EmailNotifyTemplate { get; set; } = "Notify";

        public static string EmailRegisterTemplate { get; set; } = "Register";

        public static string EmailResetPasswordTemplate { get; set; } = "ResetPassword";

        public static string EmailOneTimePasswordTemplate { get; set; } = "OneTimePassword";

        public static string SmsOneTimePasswordTemplate { get; set; } = "OneTimePasswordSms";

        // SMS
        public static string SmsClass { get; set; } = "Sms"; // Sms class // DN

        public static string SmsTemplatePath { get; set; } = "_txt"; // Template path // DN

        /// <summary>
        /// SMS region code
        /// https://github.com/twcclegg/libphonenumber-csharp
        /// - null => Use region code from locale (i.e. en-US => US)
        /// </summary>
        public static string? SmsRegionCode { get; set; } = null;

        // Remote files (Azure/AWS/GCP)
        public static string RemoteFilePattern { get; set; } = @"://";

        public static string AzureUrlPattern { get; set; } = "https://{0}.blob.core.windows.net/{1}/{2}"; // e.g. https://<myaccount>.blob.core.windows.net/<mycontainer>/<myblob>

        public static string AwsUrlPattern { get; set; } = "https://{1}.s3.{0}.amazonaws.com/{2}"; // e.g.. https://<bucket-name>.s3.<region-code>.amazonaws.com/<key-name>

        public static string GcpUrlPattern { get; set; } = "https://storage.googleapis.com/{1}/{2}"; // e.g. https://storage.googleapis.com/<BUCKET_NAME>/<OBJECT_NAME>

        // File upload
        public static string UploadType { get; set; } = "POST"; // HTTP request method for the file uploads, e.g. "POST", "PUT

        // File handler // DN
        public static string FileUrl { get; set; } = "";

        // File upload
        public static string UploadTempPathDefault { get; set; } = ""; // Upload temp path

        public static string UploadTempHrefPath { get; set; } = ""; // Upload temp href path

        public static string UploadDestPath { get; set; } = "files/"; // Upload destination path

        public static string UploadTempFolderPrefix { get; set; } = "temp__"; // Upload temp folders prefix

        public static int UploadTempFolderTimeLimit { get; set; } = 1440; // Upload temp folder time limit (minutes)

        public static string UploadThumbnailFolder { get; set; } = "thumbnail"; // Temporary thumbnail folder

        public static int UploadThumbnailWidth { get; set; } = 200; // Temporary thumbnail max width

        public static int UploadThumbnailHeight { get; set; } = 0; // Temporary thumbnail max height

        public static int? MaxFileCount { get; set; } = null; // Max file count

        public static bool ImageCropper { get; set; } = false; // Upload cropper

        public static string UploadAllowedFileExtensions { get; set; } = "gif,jpg,jpeg,bmp,png,doc,docx,xls,xlsx,pdf,zip"; // Allowed file extensions

        public static List<string> ImageAllowedFileExtensions { get; set; } = ["gif","jpe","jpeg","jpg","png","bmp"]; // Allowed file extensions for images

        public static List<string> DownloadAllowedFileExtensions { get; set; } = ["csv","pdf","xls","doc","xlsx","docx"]; // Allowed file extensions for download (non-image)

        public static bool EncryptFilePath { get; set; } = true; // Encrypt file path

        public static int MaxFileSize { get; set; } = 2000000; // Max file size

        public static int ThumbnailDefaultWidth { get; set; } = 100; // Thumbnail default width

        public static int ThumbnailDefaultHeight { get; set; } = 0; // Thumbnail default height

        public static bool UploadConvertAccentedChars { get; set; } = false; // Convert accented chars in upload file name

        public static bool UseColorbox { get; set; } = true; // Use Colorbox

        public static char MultipleUploadSeparator { get; set; } = ','; // Multiple upload separator

        public static bool CreateUploadFileOnCopy { get; set; } = true; // Create upload file on copy

        // Image resize
        public static bool ResizeIgnoreAspectRatio { get; set; } = false;

        public static bool ResizeLess { get; set; } = false;

        // Form hidden tag names (Note: DO NOT modify prefix "k_")
        public static string FormKeyCountName { get; set; } = "key_count";

        public static string FormRowActionName { get; set; } = "k_action";

        public static string FormBlankRowName { get; set; } = "k_blankrow";

        public static string FormOldKeyName { get; set; } = "k_oldkey";

        // Table actions
        public static string ListAction { get; set; } = "list"; // Table list action

        public static string ViewAction { get; set; } = "view"; // Table view action

        public static string AddAction { get; set; } = "add"; // Table add action

        public static string AddoptAction { get; set; } = "addopt"; // Table addopt action

        public static string EditAction { get; set; } = "edit"; // Table edit action

        public static string UpdateAction { get; set; } = "update"; // Table update action

        public static string DeleteAction { get; set; } = "delete"; // Table delete action

        public static string SearchAction { get; set; } = "search"; // Table search action

        public static string QueryAction { get; set; } = "query"; // Table search action

        public static string PreviewAction { get; set; } = "preview"; // Table preview action

        public static string CustomReportAction { get; set; } = "custom"; // Custom report action

        public static string SummaryReportAction { get; set; } = "summary"; // Summary report action

        public static string CrosstabReportAction { get; set; } = "crosstab"; // Crosstab report action

        public static string DashboardReportAction { get; set; } = "dashboard"; // Dashboard report action

        public static string CalendarReportAction { get; set; } = "calendar"; // Calendar report action

        // API
        public static string ApiUrl { get; set; } = "api/"; // API URL

        public static string ApiActionName { get; set; } = "action"; // API action name

        public static string ApiObjectName { get; set; } = "table"; // API object name
        // export related (start)
        public static string ApiExportName { get; set; } = "export"; // API export name

        public static string ApiExportSave { get; set; } = "save"; // API export save file

        public static string ApiExportOutput { get; set; } = "output"; // API export output file as inline/attachment

        public static string ApiExportDownload { get; set; } = "download"; // API export download file => disposition=attachment

        public static string ApiExportFileName { get; set; } = "filename"; // API export file name

        public static string ApiExportContentType { get; set; } = "contenttype"; // API export content type

        public static string ApiExportUseCharset { get; set; } = "usecharset"; // API export use charset in content type header

        public static string ApiExportUseBom { get; set; } = "usebom"; // API export use BOM

        public static string ApiExportCacheControl { get; set; } = "cachecontrol"; // API export cache control header

        public static string ApiExportDisposition { get; set; } = "disposition"; // API export disposition (inline/attachment)
        // export related (end)
        public static string ApiFieldName { get; set; } = "field"; // API field name

        public static string ApiKeyName { get; set; } = "key"; // API key name

        public static string ApiFileTokenName { get; set; } = "filetoken"; // API upload file token name

        public static string ApiLoginUsername { get; set; } = "username"; // API login user name

        public static string ApiLoginPassword { get; set; } = "password"; // API login password

        public static string ApiLoginSecurityCode { get; set; } = "securitycode"; // API login security code

        public static string ApiLoginExpire { get; set; } = "expire"; // API login expire (hours)

        public static string ApiLoginPermission { get; set; } = "permission"; // API login expire permission (hours)

        public static string ApiLookupPage { get; set; } = "page"; // API lookup page name

        public static string ApiUserlevelName { get; set; } = "userlevel"; // API userlevel name

        public static string ApiPushNotificationSubscribe { get; set; } = "subscribe"; // API push notification subscribe

        public static string ApiPushNotificationSend { get; set; } = "send"; // API push notification send

        public static string ApiPushNotificationDelete { get; set; } = "delete"; // API push notification delete

        public static string Api2FaShow { get; set; } = "show"; // API two factor authentication show

        public static string Api2FaVerify { get; set; } = "verify"; // API two factor authentication verify

        public static string Api2FaReset { get; set; } = "reset"; // API two factor authentication reset

        public static string Api2FaBackupCodes { get; set; } = "codes"; // API two factor authentication backup codes

        public static string Api2FaNewBackupCodes { get; set; } = "newcodes"; // API two factor authentication new backup codes

        public static string Api2FaSendOtp { get; set; } = "otp"; // API two factor authentication send one time password

        // API actions
        public const string ApiListAction = "list"; // API list action

        public const string ApiViewAction = "view"; // API view action

        public const string ApiAddAction = "add"; // API add action

        public const string ApiRegisterAction = "register"; // API register action

        public const string ApiEditAction = "edit"; // API edit action

        public const string ApiDeleteAction = "delete"; // API delete action

        public const string ApiLoginAction = "login"; // API login action

        public const string ApiFileAction = "file"; // API file action

        public const string ApiUploadAction = "upload"; // API upload action

        public const string ApiJqueryUploadAction = "jupload"; // API jQuery upload action

        public const string ApiSessionAction = "session"; // API get session action

        public const string ApiLookupAction = "lookup"; // API lookup action

        public const string ApiImportAction = "import"; // API import action

        public const string ApiExportAction = "export"; // API export action

        public const string ApiExportChartAction = "chart"; // API export chart action

        public const string ApiPermissionsAction = "permissions"; // API permissions action

        public static string ApiPushNotificationAction { get; set; } = "push"; // API push notification action

        public static string Api2FaAction { get; set; } = "twofa"; // API two factor authentication action

        public static string ApiChatAction { get; set; } = "chat"; // API chat action

        public static List<string> ApiPageActions { get; set; } = new()
        {
            ApiListAction,
            ApiViewAction,
            ApiAddAction,
            ApiEditAction,
            ApiDeleteAction,
            ApiFileAction,
            ApiExportAction
        };

        // List page inline/grid/modal settings
        public static bool UseAjaxActions { get; set; } = false;

        // Send push notification time limit
        public static int SendPushNotificationTimeLimit { get; set; } = 300;

        public static bool PushAnonymous { get; set; } = false;

        // Use two factor Authentication
        public static bool UseTwoFactorAuthentication { get; set; } = false;

        public static bool ForceTwoFactorAuthentication { get; set; } = false;

        public static string TwoFactorAuthenticationType { get; set; } = "google";

        public static string TwoFactorAuthenticationIssuer { get; set; } = ProjectName;

        public static TimeSpan TwoFactorAuthenticationDiscrepancy { get; set; } = TimeSpan.FromMinutes(5);

        public static int TwoFactorAuthenticationQrcodeSize { get; set; } = 3; // Number of pixels per QR Module (2 = ~120x120px QRCode, should be 10 or less)

        public static int TwoFactorAuthenticationPassCodeLength { get; set; } = 6;

        public static int TwoFactorAuthenticationBackupCodeLength { get; set; } = 8;

        public static int TwoFactorAuthenticationBackupCodeCount { get; set; } = 10;

        public static bool OtpOnly { get; set; } = false;

        public static string AdminOtpAccount { get; set; } = "";

        // Import records
        public static Encoding ImportCsvEncoding { get; set; } = Encoding.UTF8; // Import CSV encoding

        public static CultureInfo ImportCsvCulture { get; set; } = CultureInfo.InvariantCulture; // Import CSV culture

        public static char ImportCsvDelimiter { get; set; } = ','; // Import CSV delimiter character

        public static char ImportCsvTextQualifier { get; set; } = '"'; // Import CSV text qualifier character

        public static string ImportCsvEol { get; set; } = "\r\n"; // Import CSV end of line, default CRLF

        public static string ImportFileAllowedExtensions { get; set; } = "csv,xlsx"; // Import file allowed extensions

        public static bool ImportInsertOnly { get; set; } = true; // Import by insert only

        public static bool ImportUseTransaction { get; set; } = true; // Import use transaction

        public static int ImportMaxFailures { get; set; } = 1; // Import maximum number of failures

        // Logging and audit trail
        public static string LogPathDefault { get; set; } = "log/"; // Logging and audit trail path (relative to wwwroot)

        // Export records
        public static bool ExportAll { get; set; } = true; // Export all records

        public static bool ExportOriginalValue { get; set; } = false; // True to export original value

        public static bool ExportFieldCaption { get; set; } = false; // True to export field caption

        public static bool ExportFieldImage { get; set; } = true; // True to export field image

        public static bool ExportCssStyles { get; set; } = true; // True to export css styles

        public static bool ExportMasterRecord { get; set; } = true; // True to export master record

        public static bool ExportMasterRecordForCsv { get; set; } = false; // True to export master record for CSV

        public static bool ExportDetailRecords { get; set; } = true; // True to export detail records

        public static bool ExportDetailRecordsForCsv { get; set; } = false; // True to export detail records for CSV

        // Export classes
        public static Dictionary<string, string> Export { get; set; } = new(StringComparer.OrdinalIgnoreCase)
        {
            { "email", "ExportEmail" },
            { "html", "ExportHtml" },
            { "word", "ExportWord" },
            { "excel", "ExportExcel" },
            { "pdf", "ExportPdf" },
            { "csv", "ExportCsv" },
            { "xml", "ExportXml" },
            { "json", "ExportJson" }
        };

        // Export report methods
        public static Dictionary<string, string> ExportReport { get; set; } = new(StringComparer.OrdinalIgnoreCase)
        {
            { "email", "ExportEmail" },
            { "html", "ExportHtml" },
            { "word", "ExportWord" },
            { "excel", "ExportExcel" },
            { "pdf", "ExportPdf" }
        };

        // Full URL protocols ("http" or "https")
        public static Dictionary<string, string?> FullUrlProtocols { get; set; } = new(StringComparer.OrdinalIgnoreCase)
        {
            {"href", null},
            {"upload", null},
            {"resetpwd", null},
            {"activate", null},
            {"auth", null},
            {"export", null},
        };

        // Named types // DN
        public static Dictionary<string, Type> NamedTypes { get; set; } = new()
        {
            {"Aktivitas", typeof(Aktivitas)},
            {"AktivitasDokumen", typeof(AktivitasDokumen)},
            {"BukuTamu", typeof(BukuTamu)},
            {"ClosingStock", typeof(ClosingStock)},
            {"ControlRutinSecurity", typeof(ControlRutinSecurity)},
            {"DetailMasterPipa", typeof(DetailMasterPipa)},
            {"FormInputControlRutinSecurity", typeof(FormInputControlRutinSecurity)},
            {"FormInputGoodHouseKeeping", typeof(FormInputGoodHouseKeeping)},
            {"FormInputProofOfVisit", typeof(FormInputProofOfVisit)},
            {"GoodHouseKeeping", typeof(GoodHouseKeeping)},
            {"MappingPosition", typeof(MappingPosition)},
            {"MasterArea", typeof(MasterArea)},
            {"MasterDermaga", typeof(MasterDermaga)},
            {"MasterDokumen", typeof(MasterDokumen)},
            {"MasterFungsiKunjungan", typeof(MasterFungsiKunjungan)},
            {"MasterModa", typeof(MasterModa)},
            {"MasterPIC", typeof(MasterPic)},
            {"MasterPipa", typeof(MasterPipa)},
            {"MasterPlant", typeof(MasterPlant)},
            {"MasterPosition", typeof(MasterPosition)},
            {"MasterProduk", typeof(MasterProduk)},
            {"MasterRegion", typeof(MasterRegion)},
            {"MasterTangki", typeof(MasterTangki)},
            {"MasterTemplate", typeof(MasterTemplate)},
            {"MasterTools", typeof(MasterTools)},
            {"MasterUser", typeof(MasterUser)},
            {"MWTOnline", typeof(MwtOnline)},
            {"MWTOnlineDetail", typeof(MwtOnlineDetail)},
            {"Penerimaan", typeof(Penerimaan)},
            {"PengujianSampleLainnya", typeof(PengujianSampleLainnya)},
            {"Penimbunan", typeof(Penimbunan)},
            {"PenimbunanPenyaluran", typeof(PenimbunanPenyaluran)},
            {"Penyaluran", typeof(Penyaluran)},
            {"PenyimpananSample", typeof(PenyimpananSample)},
            {"ProofOfVisit", typeof(ProofOfVisit)},
            {"Proses", typeof(Proses)},
            {"RencanaPenyaluran", typeof(RencanaPenyaluran)},
            {"SamplingLabTest", typeof(SamplingLabTest)},
            {"SetUserMOD", typeof(SetUserMod)},
            {"SubAkivitasNilaiAktualDischargePipa", typeof(SubAkivitasNilaiAktualDischargePipa)},
            {"SubAkivitasNilaiAktualDischargePipaLPG", typeof(SubAkivitasNilaiAktualDischargePipaLpg)},
            {"SubAktivitasARSesuaiCQDRTW", typeof(SubAktivitasArSesuaiCqdrtw)},
            {"SubAktivitasCatatanKhusus", typeof(SubAktivitasCatatanKhusus)},
            {"SubAktivitasDataGerbongKetelRTW", typeof(SubAktivitasDataGerbongKetelRtw)},
            {"SubaktivitasDataKapal", typeof(SubaktivitasDataKapal)},
            {"SubAktivitasDataKapalLPG", typeof(SubAktivitasDataKapalLpg)},
            {"SubAktivitasDataKapalSTSLPG", typeof(SubAktivitasDataKapalStslpg)},
            {"SubAktivitasDataKapalSTSPnrBBM", typeof(SubAktivitasDataKapalStsPnrBbm)},
            {"SubAktivitasDataMobilTangkiMTGateIn", typeof(SubAktivitasDataMobilTangkiMtGateIn)},
            {"SubAktivitasDataMobilTangkiMTGateInLPG", typeof(SubAktivitasDataMobilTangkiMtGateInLpg)},
            {"SubAktivitasDataMobilTangkiMTGateOut", typeof(SubAktivitasDataMobilTangkiMtGateOut)},
            {"SubAktivitasDataMobilTangkiMTGateOutLPG", typeof(SubAktivitasDataMobilTangkiMtGateOutLpg)},
            {"SubAktivitasDataStartPembongkaranPipa", typeof(SubAktivitasDataStartPembongkaranPipa)},
            {"SubAktivitasDataStartPembongkaranRTW", typeof(SubAktivitasDataStartPembongkaranRtw)},
            {"SubAktivitasDataStartPenyaluran", typeof(SubAktivitasDataStartPenyaluran)},
            {"SubAktivitasDataStartPenyaluranLPG", typeof(SubAktivitasDataStartPenyaluranLpg)},
            {"SubAktivitasDataStartPenyaluranPipa", typeof(SubAktivitasDataStartPenyaluranPipa)},
            {"SubAktivitasDataStartPenyaluranSTSPyrBBM", typeof(SubAktivitasDataStartPenyaluranStsPyrBbm)},
            {"SubAktivitasDataStartPenyaluranSTSPyrLPG", typeof(SubAktivitasDataStartPenyaluranStsPyrLpg)},
            {"SubAktivitasDataStopPembongkaranPipa", typeof(SubAktivitasDataStopPembongkaranPipa)},
            {"SubAktivitasDataStopPembongkaranRTW", typeof(SubAktivitasDataStopPembongkaranRtw)},
            {"SubAktivitasDataStopPenyaluran", typeof(SubAktivitasDataStopPenyaluran)},
            {"SubAktivitasDataStopPenyaluranLPG", typeof(SubAktivitasDataStopPenyaluranLpg)},
            {"SubAktivitasDataStopPenyaluranPipa", typeof(SubAktivitasDataStopPenyaluranPipa)},
            {"SubAktivitasDataStopPenyaluranSTSPyrBBM", typeof(SubAktivitasDataStopPenyaluranStsPyrBbm)},
            {"SubAktivitasDataStopPenyaluranSTSPyrLPG", typeof(SubAktivitasDataStopPenyaluranStsPyrLpg)},
            {"SubAktivitasFormInputBLnSFALRTW", typeof(SubAktivitasFormInputBLnSfalrtw)},
            {"SubAktivitasFormInputBLsesuaiCQLRTW", typeof(SubAktivitasFormInputBLsesuaiCqlrtw)},
            {"SubAktivitasFormInputDataGerbongKetelRTW", typeof(SubAktivitasFormInputDataGerbongKetelRtw)},
            {"SubAktivitasFormInputDataMobilTangki", typeof(SubAktivitasFormInputDataMobilTangki)},
            {"SubAktivitasFormInputDataStartPembongkaran", typeof(SubAktivitasFormInputDataStartPembongkaran)},
            {"SubAktivitasFormInputDataStartPenyaluranRTW", typeof(SubAktivitasFormInputDataStartPenyaluranRtw)},
            {"SubAktivitasFormInputDataStopPembongkaran", typeof(SubAktivitasFormInputDataStopPembongkaran)},
            {"SubAktivitasFormInputDataStopPenyaluranRTW", typeof(SubAktivitasFormInputDataStopPenyaluranRtw)},
            {"SubAktivitasFormInputFlowrate", typeof(SubAktivitasFormInputFlowrate)},
            {"SubAktivitasFormInputFlowrateRTW", typeof(SubAktivitasFormInputFlowrateRtw)},
            {"SubAktivitasFormInputHasilPemeriksaanPipa", typeof(SubAktivitasFormInputHasilPemeriksaanPipa)},
            {"SubAktivitasFormInputHslPemeriksaan", typeof(SubAktivitasFormInputHslPemeriksaan)},
            {"SubAktivitasFormInputKeberangkatanMobilTangki", typeof(SubAktivitasFormInputKeberangkatanMobilTangki)},
            {"SubAktivitasFormInputKeberangkatanRTW", typeof(SubAktivitasFormInputKeberangkatanRtw)},
            {"SubAktivitasFormInputLogbMonitoringStockRTW", typeof(SubAktivitasFormInputLogbMonitoringStockRtw)},
            {"SubAktivitasFormInputLogbookPenerimaanPipa", typeof(SubAktivitasFormInputLogbookPenerimaanPipa)},
            {"SubAktivitasFormInputLogbookPenerimaanRTW", typeof(SubAktivitasFormInputLogbookPenerimaanRtw)},
            {"SubAktivitasFormInputLogbookPenerimaanSTSPymBBM", typeof(SubAktivitasFormInputLogbookPenerimaanStsPymBbm)},
            {"SubAktivitasFormInputLogbookPenerimaanSTSPymLPG", typeof(SubAktivitasFormInputLogbookPenerimaanStsPymLpg)},
            {"SubAktivitasFormInputLogbookPenerimaanTruck", typeof(SubAktivitasFormInputLogbookPenerimaanTruck)},
            {"SubAktivitasFormInputMonitoringStockSTSPymSBBM", typeof(SubAktivitasFormInputMonitoringStockStsPymSbbm)},
            {"SubAktivitasFormInputMonitoringStockSTSPymSLPG", typeof(SubAktivitasFormInputMonitoringStockStsPymSlpg)},
            {"SubAktivitasFormInputNilaiAktDischargeRTW", typeof(SubAktivitasFormInputNilaiAktDischargeRtw)},
            {"SubAktivitasFormInputNilaiAktualDischarge", typeof(SubAktivitasFormInputNilaiAktualDischarge)},
            {"SubAktivitasFormInputNilaiARsesuaiCQDTruck", typeof(SubAktivitasFormInputNilaiARsesuaiCqdTruck)},
            {"SubAktivitasFormInputNilaiBD", typeof(SubAktivitasFormInputNilaiBd)},
            {"SubAktivitasFormInputNilaiBLnAL", typeof(SubAktivitasFormInputNilaiBLnAl)},
            {"SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymBBM", typeof(SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbm)},
            {"SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymLPG", typeof(SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpg)},
            {"SubAktivitasFormInputNilaiBLsesuaiCQLTruck", typeof(SubAktivitasFormInputNilaiBLsesuaiCqlTruck)},
            {"SubAktivitasFormNilaiSFALARSTSPymBBM", typeof(SubAktivitasFormNilaiSfalarstsPymBbm)},
            {"SubAktivitasFormNilaiSFALARSTSPymLPG", typeof(SubAktivitasFormNilaiSfalarstsPymLpg)},
            {"SubaktivitasHasilPemeriksaan", typeof(SubaktivitasHasilPemeriksaan)},
            {"SubaktivitasHasilPemeriksaanLPG", typeof(SubaktivitasHasilPemeriksaanLpg)},
            {"SubAktivitasHasilPemeriksaanPenKon", typeof(SubAktivitasHasilPemeriksaanPenKon)},
            {"SubAktivitasHasilPemeriksaanPenyaluran", typeof(SubAktivitasHasilPemeriksaanPenyaluran)},
            {"SubAktivitasHasilPemeriksaanPenyaluranLPG", typeof(SubAktivitasHasilPemeriksaanPenyaluranLpg)},
            {"SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM", typeof(SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbm)},
            {"SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG", typeof(SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpg)},
            {"SubAktivitasHasilPemeriksaanPipa", typeof(SubAktivitasHasilPemeriksaanPipa)},
            {"SubAktivitasHasilPemeriksaanSTSLPG", typeof(SubAktivitasHasilPemeriksaanStslpg)},
            {"SubaktivitasHasilPemeriksaanSTSPnrBBM", typeof(SubaktivitasHasilPemeriksaanStsPnrBbm)},
            {"SubAktivitasInputDataKapal", typeof(SubAktivitasInputDataKapal)},
            {"SubAktivitasInputDataKapalLPG", typeof(SubAktivitasInputDataKapalLpg)},
            {"SubAktivitasInputDataKapalSTSPyrBBM", typeof(SubAktivitasInputDataKapalStsPyrBbm)},
            {"SubAktivitasInputDataKapalSTSPyrLPG", typeof(SubAktivitasInputDataKapalStsPyrLpg)},
            {"SubAktivitasInputDataPenyaluranKonsinyasiPipa", typeof(SubAktivitasInputDataPenyaluranKonsinyasiPipa)},
            {"SubAktivitasInputDataRTW", typeof(SubAktivitasInputDataRtw)},
            {"SubAktivitasInputFlowrateRTW", typeof(SubAktivitasInputFlowrateRtw)},
            {"SubaktivitasInputHasilPemeriksaanPipa", typeof(SubaktivitasInputHasilPemeriksaanPipa)},
            {"SubAktivitasInputLogbookPenerimaanPenKon", typeof(SubAktivitasInputLogbookPenerimaanPenKon)},
            {"SubAktivitasInputLogbookPenerimaanPenKonLPG", typeof(SubAktivitasInputLogbookPenerimaanPenKonLpg)},
            {"SubAktivitasInputLogbookPenerimaanPipa", typeof(SubAktivitasInputLogbookPenerimaanPipa)},
            {"SubaktivitasInputLogbookPenyaluranPipa", typeof(SubaktivitasInputLogbookPenyaluranPipa)},
            {"SubaktivitasInputLogbookPenyaluranPipa_Backup", typeof(SubaktivitasInputLogbookPenyaluranPipaBackup)},
            {"SubaktivitasKapalBerangkat", typeof(SubaktivitasKapalBerangkat)},
            {"SubaktivitasKapalBerangkatLPG", typeof(SubaktivitasKapalBerangkatLpg)},
            {"SubAktivitasKapalBerangkatSTSLPG", typeof(SubAktivitasKapalBerangkatStslpg)},
            {"SubaktivitasKapalBerangkatSTSPnrBBM", typeof(SubaktivitasKapalBerangkatStsPnrBbm)},
            {"SubAktivitasKeberangkatanKapalPenKon", typeof(SubAktivitasKeberangkatanKapalPenKon)},
            {"SubAktivitasKeberangkatanKapalPenyaluran", typeof(SubAktivitasKeberangkatanKapalPenyaluran)},
            {"SubAktivitasKeberangkatanKapalPenyaluranLPG", typeof(SubAktivitasKeberangkatanKapalPenyaluranLpg)},
            {"SubAktivitasKeberangkatanKapalPenyaluranSTSPyrBBM", typeof(SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbm)},
            {"SubAktivitasKeberangkatanKapalPenyaluranSTSPyrLPG", typeof(SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpg)},
            {"SubAktivitasKeberangkatanRTW", typeof(SubAktivitasKeberangkatanRtw)},
            {"SubAktivitasLaporanStock", typeof(SubAktivitasLaporanStock)},
            {"SubAktivitasLaporanStockSTSCSBBM", typeof(SubAktivitasLaporanStockStscsbbm)},
            {"SubAktivitasLaporanStockSTSCSLPG", typeof(SubAktivitasLaporanStockStscslpg)},
            {"SubAktivitasLogbookJembatanTimbangLPG", typeof(SubAktivitasLogbookJembatanTimbangLpg)},
            {"SubAktivitasLogbookMonitoringStock", typeof(SubAktivitasLogbookMonitoringStock)},
            {"SubAktivitasLogbookMonitoringStockPipa", typeof(SubAktivitasLogbookMonitoringStockPipa)},
            {"SubAktivitasLogbookPenerimaan", typeof(SubAktivitasLogbookPenerimaan)},
            {"SubAktivitasLogbookPenerimaanLPG", typeof(SubAktivitasLogbookPenerimaanLpg)},
            {"SubAktivitasLogbookPenerimaanPenyaluran", typeof(SubAktivitasLogbookPenerimaanPenyaluran)},
            {"SubAktivitasLogbookPenerimaanPenyaluranLPG", typeof(SubAktivitasLogbookPenerimaanPenyaluranLpg)},
            {"SubAktivitasLogbookPenerimaanSTSPymBBM", typeof(SubAktivitasLogbookPenerimaanStsPymBbm)},
            {"SubAktivitasLogbookPenerimaanSTSPymLPG", typeof(SubAktivitasLogbookPenerimaanStsPymLpg)},
            {"SubAktivitasNilaiActualPumping", typeof(SubAktivitasNilaiActualPumping)},
            {"SubaktivitasNilaiAgreement", typeof(SubaktivitasNilaiAgreement)},
            {"SubAktivitasNilaiAgreementLPG", typeof(SubAktivitasNilaiAgreementLpg)},
            {"SubAktivitasNilaiAgreementPenKon", typeof(SubAktivitasNilaiAgreementPenKon)},
            {"SubAktivitasNilaiAgreementPenyaluran", typeof(SubAktivitasNilaiAgreementPenyaluran)},
            {"SubAktivitasNilaiAgreementPenyaluranLPG", typeof(SubAktivitasNilaiAgreementPenyaluranLpg)},
            {"SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM", typeof(SubAktivitasNilaiAgreementPenyaluranStsPyrBbm)},
            {"SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG", typeof(SubAktivitasNilaiAgreementPenyaluranStsPyrLpg)},
            {"SubAktivitasNilaiAgreementSTSLPG", typeof(SubAktivitasNilaiAgreementStslpg)},
            {"SubaktivitasNilaiAgreementSTSPnrBBM", typeof(SubaktivitasNilaiAgreementStsPnrBbm)},
            {"SubAktivitasNilaiARsesuaiCQD", typeof(SubAktivitasNilaiARsesuaiCqd)},
            {"SubAktivitasNilaiARsesuaiCQDLPG", typeof(SubAktivitasNilaiARsesuaiCqdlpg)},
            {"SubAktivitasNilaiARsesuaiCQDPipa", typeof(SubAktivitasNilaiARsesuaiCqdPipa)},
            {"SubAktivitasNilaiARsesuaiCQDPipaLPG", typeof(SubAktivitasNilaiARsesuaiCqdPipaLpg)},
            {"SubAktivitasNilaiBDperGerbong", typeof(SubAktivitasNilaiBDperGerbong)},
            {"SubAktivitasNilaiBLdanALRTW", typeof(SubAktivitasNilaiBLdanAlrtw)},
            {"SubAktivitasNilaiBLPenKon", typeof(SubAktivitasNilaiBlPenKon)},
            {"SubAktivitasNilaiBLPenKonLPG", typeof(SubAktivitasNilaiBlPenKonLpg)},
            {"SubaktivitasNilaiBLSFAL", typeof(SubaktivitasNilaiBlsfal)},
            {"SubAktivitasNilaiBLSFALLPG", typeof(SubAktivitasNilaiBlsfallpg)},
            {"SubAktivitasNilaiBLSFALPenyaluran", typeof(SubAktivitasNilaiBlsfalPenyaluran)},
            {"SubAktivitasNilaiBLSFALPenyaluranLPG", typeof(SubAktivitasNilaiBlsfalPenyaluranLpg)},
            {"SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM", typeof(SubAktivitasNilaiBlsfalPenyaluranStsPyrBbm)},
            {"SubAktivitasNilaiBLSFALPenyaluranSTSPyrLPG", typeof(SubAktivitasNilaiBlsfalPenyaluranStsPyrLpg)},
            {"SubAktivitasNilaiBLSFALSTSLPG", typeof(SubAktivitasNilaiBlsfalstslpg)},
            {"SubaktivitasNilaiBLSFALSTSPnrBBM", typeof(SubaktivitasNilaiBlsfalstsPnrBbm)},
            {"SubAktivitasNilaiEstimasisFlowratePipa", typeof(SubAktivitasNilaiEstimasisFlowratePipa)},
            {"SubAktivitasNilaiETCETAPipa", typeof(SubAktivitasNilaiEtcetaPipa)},
            {"SubaktivitasNilaiLoadedFigurePipa", typeof(SubaktivitasNilaiLoadedFigurePipa)},
            {"SubAktivitasNilaiNewBLSFADSFBL", typeof(SubAktivitasNilaiNewBlsfadsfbl)},
            {"SubAktivitasNilaiNewBLSFADSFBLLPG", typeof(SubAktivitasNilaiNewBlsfadsfbllpg)},
            {"SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM", typeof(SubAktivitasNilaiNewBlsfadsfblstsPyrBbm)},
            {"SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG", typeof(SubAktivitasNilaiNewBlsfadsfblstsPyrLpg)},
            {"SubaktivitasNilaiSFBD", typeof(SubaktivitasNilaiSfbd)},
            {"SubAktivitasNilaiSFBDLPG", typeof(SubAktivitasNilaiSfbdlpg)},
            {"SubAktivitasNilaiSFBDPenKon", typeof(SubAktivitasNilaiSfbdPenKon)},
            {"SubAktivitasNilaiSFBDRTW", typeof(SubAktivitasNilaiSfbdrtw)},
            {"SubAktivitasNilaiSFBDSTSLPG", typeof(SubAktivitasNilaiSfbdstslpg)},
            {"SubaktivitasNilaiSFBDSTSPnrBBM", typeof(SubaktivitasNilaiSfbdstsPnrBbm)},
            {"SubaktivitasNilaiSFBLSTSPymBBM", typeof(SubaktivitasNilaiSfblstsPymBbm)},
            {"SubaktivitasNilaiSFBLSTSPymLPG", typeof(SubaktivitasNilaiSfblstsPymLpg)},
            {"SubAktivitasPengecekanMT", typeof(SubAktivitasPengecekanMt)},
            {"SubAktivitasRealisasiPenyaluranPerProduk", typeof(SubAktivitasRealisasiPenyaluranPerProduk)},
            {"SubAktivitasRencanaPenyaluranPerProduk", typeof(SubAktivitasRencanaPenyaluranPerProduk)},
            {"SubaktivitasRencanaPenyaluranPipa", typeof(SubaktivitasRencanaPenyaluranPipa)},
            {"SubAktivitasSFADNewBL", typeof(SubAktivitasSfadNewBl)},
            {"SubAktivitasSFADNewBLLPG", typeof(SubAktivitasSfadNewBllpg)},
            {"SubAktivitasSFADNewBLSTSLPG", typeof(SubAktivitasSfadNewBlstslpg)},
            {"SubAktivitasSFADNewBLSTSPnrBBM", typeof(SubAktivitasSfadNewBlstsPnrBbm)},
            {"SubaktivitasStartBongkar", typeof(SubaktivitasStartBongkar)},
            {"SubAktivitasStartBongkarLPG", typeof(SubAktivitasStartBongkarLpg)},
            {"SubAktivitasStartBongkarSTSLPG", typeof(SubAktivitasStartBongkarStslpg)},
            {"SubaktivitasStartBongkarSTSPnrBBM", typeof(SubaktivitasStartBongkarStsPnrBbm)},
            {"SubAktivitasStartPembongkaranPenKon", typeof(SubAktivitasStartPembongkaranPenKon)},
            {"SubaktivitasStopBongkar", typeof(SubaktivitasStopBongkar)},
            {"SubAktivitasStopBongkarLPG", typeof(SubAktivitasStopBongkarLpg)},
            {"SubAktivitasStopBongkarSTSLPG", typeof(SubAktivitasStopBongkarStslpg)},
            {"SubaktivitasStopBongkarSTSPnrBBM", typeof(SubaktivitasStopBongkarStsPnrBbm)},
            {"SubAktivitasStopPembongkaranPenKon", typeof(SubAktivitasStopPembongkaranPenKon)},
            {"SubAktivitasStopPenyaluranPipa", typeof(SubAktivitasStopPenyaluranPipa)},
            {"SubAktivitasTotalPenyaluran", typeof(SubAktivitasTotalPenyaluran)},
            {"SubAktivitasTotalPenyaluranLPG", typeof(SubAktivitasTotalPenyaluranLpg)},
            {"SubAktivitasTotalRencanaPenyaluran", typeof(SubAktivitasTotalRencanaPenyaluran)},
            {"TemplateAktivitas", typeof(TemplateAktivitas)},
            {"TemplateAktivitasDokumen", typeof(TemplateAktivitasDokumen)},
            {"TemplateProses", typeof(TemplateProses)},
            {"UserLevelPermissions", typeof(UserLevelPermissions)},
            {"UserLevels", typeof(UserLevels)},
            {"v_aktifitas", typeof(VAktifitas)},
            {"v_aktifitas_sandar", typeof(VAktifitasSandar)},
            {"v_aktifitas_with_dokumen", typeof(VAktifitasWithDokumen)},
            {"VFaceEnrollment", typeof(VFaceEnrollment)},
            {"VSampleOperasional", typeof(VSampleOperasional)},
            {"SubaktivitasNilaiBLALBDPipa", typeof(SubaktivitasNilaiBlalbdPipa)},
            {"SetPjs", typeof(SetPjs)},
            {"usertable", typeof(MasterUser)},
        };

        // Database IDs // DN
        public static Dictionary<string, string> DbIds { get; set; } = new()
        {
            {"Aktivitas", "DB"},
            {"AktivitasDokumen", "DB"},
            {"BukuTamu", "DB"},
            {"ClosingStock", "DB"},
            {"ControlRutinSecurity", "DB"},
            {"DetailMasterPipa", "DB"},
            {"FormInputControlRutinSecurity", "DB"},
            {"FormInputGoodHouseKeeping", "DB"},
            {"FormInputProofOfVisit", "DB"},
            {"GoodHouseKeeping", "DB"},
            {"MappingPosition", "DB"},
            {"MasterArea", "DB"},
            {"MasterDermaga", "DB"},
            {"MasterDokumen", "DB"},
            {"MasterFungsiKunjungan", "DB"},
            {"MasterModa", "DB"},
            {"MasterPIC", "DB"},
            {"MasterPipa", "DB"},
            {"MasterPlant", "DB"},
            {"MasterPosition", "DB"},
            {"MasterProduk", "DB"},
            {"MasterRegion", "DB"},
            {"MasterTangki", "DB"},
            {"MasterTemplate", "DB"},
            {"MasterTools", "DB"},
            {"MasterUser", "DB"},
            {"MWTOnline", "DB"},
            {"MWTOnlineDetail", "DB"},
            {"Penerimaan", "DB"},
            {"PengujianSampleLainnya", "DB"},
            {"Penimbunan", "DB"},
            {"PenimbunanPenyaluran", "DB"},
            {"Penyaluran", "DB"},
            {"PenyimpananSample", "DB"},
            {"ProofOfVisit", "DB"},
            {"Proses", "DB"},
            {"RencanaPenyaluran", "DB"},
            {"SamplingLabTest", "DB"},
            {"SetUserMOD", "DB"},
            {"SubAkivitasNilaiAktualDischargePipa", "DB"},
            {"SubAkivitasNilaiAktualDischargePipaLPG", "DB"},
            {"SubAktivitasARSesuaiCQDRTW", "DB"},
            {"SubAktivitasCatatanKhusus", "DB"},
            {"SubAktivitasDataGerbongKetelRTW", "DB"},
            {"SubaktivitasDataKapal", "DB"},
            {"SubAktivitasDataKapalLPG", "DB"},
            {"SubAktivitasDataKapalSTSLPG", "DB"},
            {"SubAktivitasDataKapalSTSPnrBBM", "DB"},
            {"SubAktivitasDataMobilTangkiMTGateIn", "DB"},
            {"SubAktivitasDataMobilTangkiMTGateInLPG", "DB"},
            {"SubAktivitasDataMobilTangkiMTGateOut", "DB"},
            {"SubAktivitasDataMobilTangkiMTGateOutLPG", "DB"},
            {"SubAktivitasDataStartPembongkaranPipa", "DB"},
            {"SubAktivitasDataStartPembongkaranRTW", "DB"},
            {"SubAktivitasDataStartPenyaluran", "DB"},
            {"SubAktivitasDataStartPenyaluranLPG", "DB"},
            {"SubAktivitasDataStartPenyaluranPipa", "DB"},
            {"SubAktivitasDataStartPenyaluranSTSPyrBBM", "DB"},
            {"SubAktivitasDataStartPenyaluranSTSPyrLPG", "DB"},
            {"SubAktivitasDataStopPembongkaranPipa", "DB"},
            {"SubAktivitasDataStopPembongkaranRTW", "DB"},
            {"SubAktivitasDataStopPenyaluran", "DB"},
            {"SubAktivitasDataStopPenyaluranLPG", "DB"},
            {"SubAktivitasDataStopPenyaluranPipa", "DB"},
            {"SubAktivitasDataStopPenyaluranSTSPyrBBM", "DB"},
            {"SubAktivitasDataStopPenyaluranSTSPyrLPG", "DB"},
            {"SubAktivitasFormInputBLnSFALRTW", "DB"},
            {"SubAktivitasFormInputBLsesuaiCQLRTW", "DB"},
            {"SubAktivitasFormInputDataGerbongKetelRTW", "DB"},
            {"SubAktivitasFormInputDataMobilTangki", "DB"},
            {"SubAktivitasFormInputDataStartPembongkaran", "DB"},
            {"SubAktivitasFormInputDataStartPenyaluranRTW", "DB"},
            {"SubAktivitasFormInputDataStopPembongkaran", "DB"},
            {"SubAktivitasFormInputDataStopPenyaluranRTW", "DB"},
            {"SubAktivitasFormInputFlowrate", "DB"},
            {"SubAktivitasFormInputFlowrateRTW", "DB"},
            {"SubAktivitasFormInputHasilPemeriksaanPipa", "DB"},
            {"SubAktivitasFormInputHslPemeriksaan", "DB"},
            {"SubAktivitasFormInputKeberangkatanMobilTangki", "DB"},
            {"SubAktivitasFormInputKeberangkatanRTW", "DB"},
            {"SubAktivitasFormInputLogbMonitoringStockRTW", "DB"},
            {"SubAktivitasFormInputLogbookPenerimaanPipa", "DB"},
            {"SubAktivitasFormInputLogbookPenerimaanRTW", "DB"},
            {"SubAktivitasFormInputLogbookPenerimaanSTSPymBBM", "DB"},
            {"SubAktivitasFormInputLogbookPenerimaanSTSPymLPG", "DB"},
            {"SubAktivitasFormInputLogbookPenerimaanTruck", "DB"},
            {"SubAktivitasFormInputMonitoringStockSTSPymSBBM", "DB"},
            {"SubAktivitasFormInputMonitoringStockSTSPymSLPG", "DB"},
            {"SubAktivitasFormInputNilaiAktDischargeRTW", "DB"},
            {"SubAktivitasFormInputNilaiAktualDischarge", "DB"},
            {"SubAktivitasFormInputNilaiARsesuaiCQDTruck", "DB"},
            {"SubAktivitasFormInputNilaiBD", "DB"},
            {"SubAktivitasFormInputNilaiBLnAL", "DB"},
            {"SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymBBM", "DB"},
            {"SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymLPG", "DB"},
            {"SubAktivitasFormInputNilaiBLsesuaiCQLTruck", "DB"},
            {"SubAktivitasFormNilaiSFALARSTSPymBBM", "DB"},
            {"SubAktivitasFormNilaiSFALARSTSPymLPG", "DB"},
            {"SubaktivitasHasilPemeriksaan", "DB"},
            {"SubaktivitasHasilPemeriksaanLPG", "DB"},
            {"SubAktivitasHasilPemeriksaanPenKon", "DB"},
            {"SubAktivitasHasilPemeriksaanPenyaluran", "DB"},
            {"SubAktivitasHasilPemeriksaanPenyaluranLPG", "DB"},
            {"SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM", "DB"},
            {"SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG", "DB"},
            {"SubAktivitasHasilPemeriksaanPipa", "DB"},
            {"SubAktivitasHasilPemeriksaanSTSLPG", "DB"},
            {"SubaktivitasHasilPemeriksaanSTSPnrBBM", "DB"},
            {"SubAktivitasInputDataKapal", "DB"},
            {"SubAktivitasInputDataKapalLPG", "DB"},
            {"SubAktivitasInputDataKapalSTSPyrBBM", "DB"},
            {"SubAktivitasInputDataKapalSTSPyrLPG", "DB"},
            {"SubAktivitasInputDataPenyaluranKonsinyasiPipa", "DB"},
            {"SubAktivitasInputDataRTW", "DB"},
            {"SubAktivitasInputFlowrateRTW", "DB"},
            {"SubaktivitasInputHasilPemeriksaanPipa", "DB"},
            {"SubAktivitasInputLogbookPenerimaanPenKon", "DB"},
            {"SubAktivitasInputLogbookPenerimaanPenKonLPG", "DB"},
            {"SubAktivitasInputLogbookPenerimaanPipa", "DB"},
            {"SubaktivitasInputLogbookPenyaluranPipa", "DB"},
            {"SubaktivitasInputLogbookPenyaluranPipa_Backup", "DB"},
            {"SubaktivitasKapalBerangkat", "DB"},
            {"SubaktivitasKapalBerangkatLPG", "DB"},
            {"SubAktivitasKapalBerangkatSTSLPG", "DB"},
            {"SubaktivitasKapalBerangkatSTSPnrBBM", "DB"},
            {"SubAktivitasKeberangkatanKapalPenKon", "DB"},
            {"SubAktivitasKeberangkatanKapalPenyaluran", "DB"},
            {"SubAktivitasKeberangkatanKapalPenyaluranLPG", "DB"},
            {"SubAktivitasKeberangkatanKapalPenyaluranSTSPyrBBM", "DB"},
            {"SubAktivitasKeberangkatanKapalPenyaluranSTSPyrLPG", "DB"},
            {"SubAktivitasKeberangkatanRTW", "DB"},
            {"SubAktivitasLaporanStock", "DB"},
            {"SubAktivitasLaporanStockSTSCSBBM", "DB"},
            {"SubAktivitasLaporanStockSTSCSLPG", "DB"},
            {"SubAktivitasLogbookJembatanTimbangLPG", "DB"},
            {"SubAktivitasLogbookMonitoringStock", "DB"},
            {"SubAktivitasLogbookMonitoringStockPipa", "DB"},
            {"SubAktivitasLogbookPenerimaan", "DB"},
            {"SubAktivitasLogbookPenerimaanLPG", "DB"},
            {"SubAktivitasLogbookPenerimaanPenyaluran", "DB"},
            {"SubAktivitasLogbookPenerimaanPenyaluranLPG", "DB"},
            {"SubAktivitasLogbookPenerimaanSTSPymBBM", "DB"},
            {"SubAktivitasLogbookPenerimaanSTSPymLPG", "DB"},
            {"SubAktivitasNilaiActualPumping", "DB"},
            {"SubaktivitasNilaiAgreement", "DB"},
            {"SubAktivitasNilaiAgreementLPG", "DB"},
            {"SubAktivitasNilaiAgreementPenKon", "DB"},
            {"SubAktivitasNilaiAgreementPenyaluran", "DB"},
            {"SubAktivitasNilaiAgreementPenyaluranLPG", "DB"},
            {"SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM", "DB"},
            {"SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG", "DB"},
            {"SubAktivitasNilaiAgreementSTSLPG", "DB"},
            {"SubaktivitasNilaiAgreementSTSPnrBBM", "DB"},
            {"SubAktivitasNilaiARsesuaiCQD", "DB"},
            {"SubAktivitasNilaiARsesuaiCQDLPG", "DB"},
            {"SubAktivitasNilaiARsesuaiCQDPipa", "DB"},
            {"SubAktivitasNilaiARsesuaiCQDPipaLPG", "DB"},
            {"SubAktivitasNilaiBDperGerbong", "DB"},
            {"SubAktivitasNilaiBLdanALRTW", "DB"},
            {"SubAktivitasNilaiBLPenKon", "DB"},
            {"SubAktivitasNilaiBLPenKonLPG", "DB"},
            {"SubaktivitasNilaiBLSFAL", "DB"},
            {"SubAktivitasNilaiBLSFALLPG", "DB"},
            {"SubAktivitasNilaiBLSFALPenyaluran", "DB"},
            {"SubAktivitasNilaiBLSFALPenyaluranLPG", "DB"},
            {"SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM", "DB"},
            {"SubAktivitasNilaiBLSFALPenyaluranSTSPyrLPG", "DB"},
            {"SubAktivitasNilaiBLSFALSTSLPG", "DB"},
            {"SubaktivitasNilaiBLSFALSTSPnrBBM", "DB"},
            {"SubAktivitasNilaiEstimasisFlowratePipa", "DB"},
            {"SubAktivitasNilaiETCETAPipa", "DB"},
            {"SubaktivitasNilaiLoadedFigurePipa", "DB"},
            {"SubAktivitasNilaiNewBLSFADSFBL", "DB"},
            {"SubAktivitasNilaiNewBLSFADSFBLLPG", "DB"},
            {"SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM", "DB"},
            {"SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG", "DB"},
            {"SubaktivitasNilaiSFBD", "DB"},
            {"SubAktivitasNilaiSFBDLPG", "DB"},
            {"SubAktivitasNilaiSFBDPenKon", "DB"},
            {"SubAktivitasNilaiSFBDRTW", "DB"},
            {"SubAktivitasNilaiSFBDSTSLPG", "DB"},
            {"SubaktivitasNilaiSFBDSTSPnrBBM", "DB"},
            {"SubaktivitasNilaiSFBLSTSPymBBM", "DB"},
            {"SubaktivitasNilaiSFBLSTSPymLPG", "DB"},
            {"SubAktivitasPengecekanMT", "DB"},
            {"SubAktivitasRealisasiPenyaluranPerProduk", "DB"},
            {"SubAktivitasRencanaPenyaluranPerProduk", "DB"},
            {"SubaktivitasRencanaPenyaluranPipa", "DB"},
            {"SubAktivitasSFADNewBL", "DB"},
            {"SubAktivitasSFADNewBLLPG", "DB"},
            {"SubAktivitasSFADNewBLSTSLPG", "DB"},
            {"SubAktivitasSFADNewBLSTSPnrBBM", "DB"},
            {"SubaktivitasStartBongkar", "DB"},
            {"SubAktivitasStartBongkarLPG", "DB"},
            {"SubAktivitasStartBongkarSTSLPG", "DB"},
            {"SubaktivitasStartBongkarSTSPnrBBM", "DB"},
            {"SubAktivitasStartPembongkaranPenKon", "DB"},
            {"SubaktivitasStopBongkar", "DB"},
            {"SubAktivitasStopBongkarLPG", "DB"},
            {"SubAktivitasStopBongkarSTSLPG", "DB"},
            {"SubaktivitasStopBongkarSTSPnrBBM", "DB"},
            {"SubAktivitasStopPembongkaranPenKon", "DB"},
            {"SubAktivitasStopPenyaluranPipa", "DB"},
            {"SubAktivitasTotalPenyaluran", "DB"},
            {"SubAktivitasTotalPenyaluranLPG", "DB"},
            {"SubAktivitasTotalRencanaPenyaluran", "DB"},
            {"TemplateAktivitas", "DB"},
            {"TemplateAktivitasDokumen", "DB"},
            {"TemplateProses", "DB"},
            {"UserLevelPermissions", "DB"},
            {"UserLevels", "DB"},
            {"v_aktifitas", "DB"},
            {"v_aktifitas_sandar", "DB"},
            {"v_aktifitas_with_dokumen", "DB"},
            {"VFaceEnrollment", "DB"},
            {"VSampleOperasional", "DB"},
            {"SubaktivitasNilaiBLALBDPipa", "DB"},
            {"SetPjs", "DB"},
        };

        // Secondary connection name // DN
        public static string SecondaryConnectionName { get; set; } = "_2";

        // Boolean HTML attributes
        public static List<string> BooleanHtmlAttributes { get; set; } = [
            "allowfullscreen",
            "allowpaymentrequest",
            "async",
            "autofocus",
            "autoplay",
            "checked",
            "controls",
            "default",
            "defer",
            "disabled",
            "formnovalidate",
            "hidden",
            "ismap",
            "itemscope",
            "loop",
            "multiple",
            "muted",
            "nomodule",
            "novalidate",
            "open",
            "readonly",
            "required",
            "reversed",
            "selected",
            "typemustmatch"
        ];

        // HTML singleton tags
        public static List<string> HtmlSingletonTags { get; set; } = [
            "area",
            "base",
            "br",
            "col",
            "command",
            "embed",
            "hr",
            "img",
            "input",
            "keygen",
            "link",
            "meta",
            "param",
            "source",
            "track",
            "wbr"
        ];

        // Use ILIKE for PostgreSQL
        public static bool UseIlikeForPostgresql { get; set; } = true;

        // Use collation for MySQL
        public static string LikeCollationForMysql { get; set; } = "";

        // Use collation for MsSQL
        public static string LikeCollationForMssql { get; set; } = "";

        // Use collation for MsSQL
        public static string LikeCollationForSqlite { get; set; } = "";

        // Null / Not Null values
        public const string NullValue = "##null##";

        public const string NotNullValue = "##notnull##";

        /// <summary>
        /// Search multi value option
        /// 1 - no multi value
        /// 2 - AND all multi values
        /// 3 - OR all multi values
        /// </summary>
        /// <value></value>
        public static short SearchMultiValueOption { get; set; } = 3;

        // Advanced search
        public static string SearchOption { get; set; } = "AUTO";

        // Quick search
        public static string BasicSearchIgnorePattern { get; set; } = @"[\?,\^\*\(\)\[\]\""]"; // Ignore special characters

        public static bool BasicSearchAnyFields { get; set; } = false; // Search "All keywords" in any selected fields

        // Sort options
        public static string SortOption { get; set; } = "Tristate"; // Sort option (toggle/tristate)

        // Validate option
        public static bool ClientValidate { get; set; } = true;

        public static bool ServerValidate { get; set; } = false;

        public static string InvalidUsernameCharacters { get; set; } = "<>\"'&";

        public static string InvalidPasswordCharacters { get; set; } = "<>\"'&";

        // Blob field byte count for hash value calculation
        public static int BlobFieldByteCount { get; set; } = 256;

        // Native select-one
        public static bool UseNativeSelectOne { get; set; } = false;

        // Auto suggest max entries
        public static int AutoSuggestMaxEntries { get; set; } = 10;

        // Auto suggest for all display fields
        public static bool LookupAllDisplayFields { get; set; } = false;

        // Lookup page size
        public static int LookupPageSize { get; set; } = 100;

        // Filter page size
        public static int FilterPageSize { get; set; } = 100;

        // Auto fill original value
        public static bool AutoFillOriginalValue { get; set; } = false;

        // Lookup filter value separator
        public static char MultipleOptionSeparator { get; set; } = ',';

        public static char FilterOptionSeparator { get; set; } = '|';

        public static bool UseLookupCache { get; set; } = true;

        public static int LookupCacheCount { get; set; } = 100;

        public static List<string> LookupCachePageIds { get; set; } = ["list", "grid"];

        // Page Title Style
        public static string PageTitleStyle { get; set; } = "Breadcrumbs";

        // Responsive table
        public static bool UseResponsiveTable { get; set; } = true;

        public static string ResponsiveTableClass { get; set; } = "table-responsive";

        // Fixed header table
        public static string FixedHeaderTableClass { get; set; } = "table-head-fixed";

        public static bool UseFixedHeaderTable { get; set; } = false;

        public static string FixedHeaderTableHeight { get; set; } = "mh-400px"; // CSS class for fixed header table height

        // Multi column list options position
        public static string MultiColumnListOptionsPosition { get; set; } = "bottom-start";

        // RTL
        public static List<string> RtlLanguages { get; set; } = ["ar", "fa", "he", "iw", "ug", "ur"];

        // Date/Time without seconds
        public static bool DatetimeWithoutSeconds { get; set; } = false;

        // Multiple selection
        public static string OptionHtmlTemplate { get; set; } = "<span class=\"ew-option\">{value}</span>"; // Note: class="ew-option" must match CSS style in project stylesheet

        public static string OptionSeparator { get; set; } = ", ";

        // Cookies
        public static int CookieExpires { get; set; } = 365; // Cookie expiry in days

        public static DateTime CookieExpiryTime { get; set; } = DateTime.Today.AddDays(CookieExpires);

        public static string CookieSameSite { get; set; } = "Unspecified";

        public static bool CookieHttpOnly { get; set; } = true;

        public static bool CookieSecure { get; set; } = false;

        public static string CookieConsentClass { get; set; } = "text-bg-secondary"; // CSS class name for cookie consent

        public static string CookieConsentButtonClass { get; set; } = "btn btn-dark btn-sm"; // CSS class name for cookie consent buttons

        // Token expiry time
        public static int ActivateLinkExpiryTime { get; set; } = 30 * 60; // Activation token, 30 minutes by default

        public static int RememberMeExpiryTime { get; set; } = 365 * 24 * 60 * 60; // Remember me (Auto login) token, one year by default

        // Mime type // DN
        public static string DefaultMimeType { get; set; } = "application/octet-stream";

        /// <summary>
        /// Reports
        /// </summary>

        // Chart
        public static int ChartWidth { get; set; } = 600;

        public static int ChartHeight { get; set; } = 500;

        public static bool ChartShowBlankSeries { get; set; } = false; // Show blank series

        public static bool ChartShowZeroInStackChart { get; set; } = false; // Show zero in stack chart

        public static bool ChartShowMissingSeriesValuesAsZero { get; set; } = true; // Show missing series values as zero

        public static bool ChartScaleBeginWithZero { get; set; } = false; // Chart scale begin with zero

        public static double ChartScaleMinimumValue { get; set; } = 0; // Chart scale minimum value

        public static double ChartScaleMaximumValue { get; set; } = 0; // Chart scale maximum value

        public static bool ChartShowPercentage { get; set; } = false; // Show percentage in Pie/Doughnut charts

        public static string ChartColorPalette { get; set; } = ""; // Color pallette (global)

        // Drill down setting
        public static bool UseDrillDownPanel { get; set; } = true; // Use popup panel for drill down

        // Filter
        public static bool ShowCurrentFilter { get; set; } = false; // True to show current filter

        public static bool ShowDrillDownFilter { get; set; } = true; // True to show drill down filter

        // Table level constants
        public static string TableGroupPerPage { get; set; } = "recperpage";

        public static string TableStartGroup { get; set; } = "start";

        public static string TableSortChart { get; set; } = "sortchart"; // Table sort chart

        // Page break
        public static string PageBreakHtml { get; set; } = "<div style=\"page-break-after:always;\"></div>";

        // User permissions
        public static List<string> Privileges { get; set; } = [
            "add",
            "delete",
            "edit",
            "list",
            "view",
            "search",
            "import",
            "lookup",
            "export",
            "push",
            "admin" // Put "admin" at last for userpriv page
        ];

        // Download PDF file (instead of shown in browser)
        public static bool DownloadPdfFile { get; set; } = false;

        // Embed PDF documents
        public static bool EmbedPdf { get; set; } = true;

        // Advanced Filters
        public static Dictionary<string, Dictionary<string, string>> ReportAdvancedFilters { get; set; } = new(StringComparer.OrdinalIgnoreCase)
        {
            { "PastFuture", new() { { "Past", "IsPast" }, { "Future", "IsFuture" } } },
            { "RelativeDayPeriods", new() { { "Last30Days", "IsLast30Days" }, { "Last14Days", "IsLast14Days" }, { "Last7Days", "IsLast7Days" }, { "Next7Days", "IsNext7Days" }, { "Next14Days", "IsNext14Days" }, { "Next30Days", "IsNext30Days" } } },
            { "RelativeDays", new() { { "Yesterday", "IsYesterday" }, { "Today", "IsToday" }, { "Tomorrow", "IsTomorrow" } } },
            { "RelativeWeeks", new() { { "LastTwoWeeks", "IsLast2Weeks" }, { "LastWeek", "IsLastWeek" }, { "ThisWeek", "IsThisWeek" }, { "NextWeek", "IsNextWeek" }, { "NextTwoWeeks", "IsNext2Weeks" } } },
            { "RelativeMonths", new() { { "LastMonth", "IsLastMonth" }, { "ThisMonth", "IsThisMonth" }, { "NextMonth", "IsNextMonth" } } },
            { "RelativeYears", new() { { "LastYear", "IsLastYear" }, { "ThisYear", "IsThisYear" }, { "NextYear", "IsNextYear" } } }
        };

        // Float fields default decimal position
        public static int DefaultDecimalPrecision { get; set; } = 2;

        // Chart
        public static string DefaultChartRenderer { get; set; } = "";

        // Captcha class // DN
        public static string CaptchaClass { get; set; } = "CaptchaBase";

        // API version
        public static string ApiVersion { get; set; } = "v1";

        /// <summary>
        /// Get property/field by name
        /// </summary>
        /// <param name="name"></param>
        public static object? Get(string name) =>
            typeof(Config).GetProperty(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)?.GetValue(null) ?? // Get property
            typeof(Config).GetField(name)?.GetValue(null); // Get field

        /// <summary>
        /// Float fields default number format
        /// See https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
        /// </summary>
        public static string DefaultNumberFormat { get; set; } = "#,##0.##";

        // Pace options
        public static Dictionary<string, object> PaceOptions { get; set; } = new()
        {
            {
                "ajax", new Dictionary<string, object>() {
                    { "trackMethods", (List<string>)["GET", "POST"] },
                    { "ignoreURLs", (List<string>)["/session?"] }
                }
            },
            {
                "eventLag", false  // For Firefox
            }
        };

        /// <summary>
        /// Date time formats
        /// See: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
        /// Note: "y" - The year, from 0 to 99. // DN
        /// </summary>
        public static Dictionary<int, string> DateFormats { get; set; } = new()
        {
            { 4, "HH:mm" },
            { 5, "yyyy/MM/dd" },
            { 6, "MM/dd/yyyy" },
            { 7, "dd/MM/yyyy" },
            { 9, "yyyy/MM/dd HH:mm:ss" },
            { 10, "MM/dd/yyyy HH:mm:ss" },
            { 11, "dd/MM/yyyy HH:mm:ss" },
            { 109, "yyyy/MM/dd HH:mm" },
            { 110, "MM/dd/yyyy HH:mm" },
            { 111, "dd/MM/yyyy HH:mm" },
            { 12, "yy/MM/dd" },
            { 13, "MM/dd/yy" },
            { 14, "dd/MM/yy" },
            { 15, "yy/MM/dd HH:mm:ss" },
            { 16, "MM/dd/yy HH:mm:ss" },
            { 17, "dd/MM/yy HH:mm:ss" },
            { 115, "yy/MM/dd HH:mm" },
            { 116, "MM/dd/yy HH:mm" },
            { 117, "dd/MM/yy HH:mm" },
        };

        // Database date time formats
        public static Dictionary<string, Dictionary<string, string>> DbDateFormats { get; set; } = new()
        {
            { "MYSQL", new() {
                    { "dd", "%d" },
                    { "d", "%e" },
                    { "HH", "%H" },
                    { "H", "%k" },
                    { "hh", "%h" },
                    { "h", "%l" },
                    { "MM", "%m" },
                    { "M", "%c" },
                    { "mm", "%i" },
                    { "m", "%i" },
                    { "ss", "%S" },
                    { "s", "%S" },
                    { "yy", "%y" },
                    { "y", "%Y" },
                    { "a", "%p" }
                }
            },
            { "POSTGRESQL", new() {
                    { "dd", "DD" },
                    { "d", "FMDD" },
                    { "HH", "HH24" },
                    { "H", "FMHH24" },
                    { "hh", "HH12" },
                    { "h", "FMHH12" },
                    { "MM", "MM" },
                    { "M", "FMMM" },
                    { "mm", "MI" },
                    { "m", "FMMI" },
                    { "ss", "SS" },
                    { "s", "FMSS" },
                    { "yy", "YY" },
                    { "y", "YYYY" },
                    { "a", "AM" }
                }
            },
            { "MSSQL", new() {
                    { "dd", "dd" },
                    { "d", "d" },
                    { "HH", "HH" },
                    { "H", "H" },
                    { "hh", "hh" },
                    { "h", "h" },
                    { "MM", "MM" },
                    { "M", "M" },
                    { "mm", "mm" },
                    { "m", "m" },
                    { "ss", "ss" },
                    { "s", "s" },
                    { "yy", "yy" },
                    { "y", "yyyy" },
                    { "a", "tt" }
                }
            },
            { "ORACLE", new() {
                    { "dd", "DD" },
                    { "d", "FMDD" },
                    { "HH", "HH24" },
                    { "H", "FMHH24" },
                    { "hh", "HH12" },
                    { "h", "FMHH12" },
                    { "MM", "MM" },
                    { "M", "FMMM" },
                    { "mm", "MI" },
                    { "m", "FMMI" },
                    { "ss", "SS" },
                    { "s", "FMSS" },
                    { "yy", "YY" },
                    { "y", "YYYY" },
                    { "a", "AM" }
                }
            },
            { "SQLITE", new() {
                    { "dd", "%d" },
                    { "d", "%d" },
                    { "HH", "%H" },
                    { "H", "%H" },
                    { "hh", "%I" },
                    { "h", "%I" },
                    { "MM", "%m" },
                    { "M", "%m" },
                    { "mm", "%M" },
                    { "m", "%M" },
                    { "ss", "%S" },
                    { "s", "%S" },
                    { "yy", "%y" },
                    { "y", "%Y" },
                    { "a", "%P" }
                }
            }
        };

        // Quarter name
        //public static string QuarterPattern { get; set; } = "QQQQ"; // Note: No Q format string, not used
        public static string QuarterPattern { get; set; } = "";

        // Month name
        public static string MonthPattern { get; set; } = "MMM";

        // Table client side variables
        public static List<string> TableClientVars { get; set; } = new()
        {
            "TableName",
            "TableCaption"
        };

        // Field client side variables
        public static List<string> FieldClientVars { get; set; } = new()
        {
            "Name",
            "Caption",
            "Visible",
            "Required",
            "IsInvalid",
            "Raw",
            "ClientFormatPattern",
            "ClientSearchOperators"
        };

        // Query builder search operators
        public static Dictionary<string, string> ClientSearchOperators { get; set; } = new()
        {
            { "=", "equal" },
            { "<>", "not_equal" },
            { "IN", "in" },
            { "NOT IN", "not_in" },
            { "<", "less" },
            { "<=", "less_or_equal" },
            { ">", "greater" },
            { ">=", "greater_or_equal" },
            { "BETWEEN", "between" },
            { "NOT BETWEEN", "not_between" },
            { "STARTS WITH", "begins_with" },
            { "NOT STARTS WITH", "not_begins_with" },
            { "LIKE", "contains" },
            { "NOT LIKE", "not_contains" },
            { "ENDS WITH", "ends_with" },
            { "NOT ENDS WITH", "not_ends_with" },
            { "IS EMPTY", "is_empty" },
            { "IS NOT EMPTY", "is_not_empty" },
            { "IS NULL", "is_null" },
            { "IS NOT NULL", "is_not_null" }
        };

        // Query builder search operators settings
        public static Dictionary<string, Dictionary<string, object>> QueryBuilderOperators { get; set; } = new()
        {
            { "equal", new() {
                    { "type", "equal" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string", "number", "datetime", "boolean"] }
                }
            },
            { "not_equal", new() {
                    { "type", "not_equal" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string", "number", "datetime", "boolean"] }
                }
            },
            { "in", new() {
                    { "type", "in" },
                    { "nb_inputs", 1 },
                    { "multiple", true },
                    { "apply_to", (List<string>)["string", "number", "datetime"] }
                }
            },
            { "not_in", new() {
                    { "type", "not_in" },
                    { "nb_inputs", 1 },
                    { "multiple", true },
                    { "apply_to", (List<string>)["string", "number", "datetime"] }
                }
            },
            { "less", new() {
                    { "type", "less" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["number", "datetime"] }
                }
            },
            { "less_or_equal", new() {
                    { "type", "less_or_equal" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["number", "datetime"] }
                }
            },
            { "greater", new() {
                    { "type", "greater" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["number", "datetime"] }
                }
            },
            { "greater_or_equal", new() {
                    { "type", "greater_or_equal" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["number", "datetime"] }
                }
            },
            { "between", new() {
                    { "type", "between" },
                    { "nb_inputs", 2 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["number", "datetime"] }
                }
            },
            { "not_between", new() {
                    { "type", "not_between" },
                    { "nb_inputs", 2 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["number", "datetime"] }
                }
            },
            { "begins_with", new() {
                    { "type", "begins_with" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string"] }
                }
            },
            { "not_begins_with", new() {
                    { "type", "not_begins_with" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string"] }
                }
            },
            { "contains", new() {
                    { "type", "contains" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string"] }
                }
            },
            { "not_contains", new() {
                    { "type", "not_contains" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string"] }
                }
            },
            { "ends_with", new() {
                    { "type", "ends_with" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string"] }
                }
            },
            { "not_ends_with", new() {
                    { "type", "not_ends_with" },
                    { "nb_inputs", 1 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string"] }
                }
            },
            { "is_empty", new() {
                    { "type", "is_empty" },
                    { "nb_inputs", 0 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string"] }
                }
            },
            { "is_not_empty", new() {
                    { "type", "is_not_empty" },
                    { "nb_inputs", 0 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string"] }
                }
            },
            { "is_null", new() {
                    { "type", "is_null" },
                    { "nb_inputs", 0 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string", "number", "datetime", "boolean"] }
                }
            },
            { "is_not_null", new() {
                    { "type", "is_not_null" },
                    { "nb_inputs", 0 },
                    { "multiple", false },
                    { "apply_to", (List<string>)["string", "number", "datetime", "boolean"] }
                }
            }
        };

        // Value separator for IN operator
        public static string InOperatorValueSeparator { get; set; } = "|";

        // Value separator for BETWEEN operator
        public static string BetweenOperatorValueSeparator { get; set; } = "|";

        // Value separator for OR operator
        public static string OrOperatorValueSeparator { get; set; } = "||";

        // Config client side variables
        public static List<string> ConfigClientVars { get; set; } = new()
        {
            "DEBUG",
            "SESSION_TIMEOUT_COUNTDOWN", // Count down time to session timeout (seconds)
            "SESSION_KEEP_ALIVE_INTERVAL", // Keep alive interval (seconds)
            "API_FILE_TOKEN_NAME", // API file token name
            "API_URL", // API file name
            "API_ACTION_NAME", // API action name
            "API_OBJECT_NAME", // API object name
            "API_LIST_ACTION", // API list action
            "API_VIEW_ACTION", // API view action
            "API_ADD_ACTION", // API add action
            "API_EDIT_ACTION", // API edit action
            "API_DELETE_ACTION", // API delete action
            "API_LOGIN_ACTION", // API login action
            "API_FILE_ACTION", // API file action
            "API_UPLOAD_ACTION", // API upload action
            "API_JQUERY_UPLOAD_ACTION", // API jQuery upload action
            "API_SESSION_ACTION", // API get session action
            "API_LOOKUP_ACTION", // API lookup action
            "API_LOOKUP_PAGE", // API lookup page name
            "API_IMPORT_ACTION", // API import action
            "API_EXPORT_ACTION", // API export action
            "API_EXPORT_CHART_ACTION", // API export chart action
            "API_CHAT_ACTION", // API chat action
            "PUSH_SERVER_PUBLIC_KEY", // Push Server Public Key
            "API_PUSH_NOTIFICATION_ACTION", // API push notification action
            "API_PUSH_NOTIFICATION_SUBSCRIBE", // API push notification subscribe
            "API_PUSH_NOTIFICATION_DELETE", // API push notification delete
            "API_2FA_ACTION", // API two factor authentication action
            "API_2FA_SHOW", // API two factor authentication show
            "API_2FA_VERIFY", // API two factor authentication verify
            "API_2FA_RESET", // API two factor authentication reset
            "API_2FA_BACKUP_CODES", // API two factor authentication backup codes
            "API_2FA_NEW_BACKUP_CODES", // API two factor authentication new backup codes
            "API_2FA_SEND_OTP", // API two factor authentication send one time password
            "TWO_FACTOR_AUTHENTICATION_TYPE", // Two factor authentication type
            "MULTIPLE_OPTION_SEPARATOR", // Multiple option separator
            "AUTO_SUGGEST_MAX_ENTRIES", // Auto-Suggest max entries
            "LOOKUP_PAGE_SIZE", // Lookup page size
            "FILTER_PAGE_SIZE", // Filter page size
            "MAX_EMAIL_RECIPIENT",
            "UPLOAD_THUMBNAIL_WIDTH", // Upload thumbnail width
            "UPLOAD_THUMBNAIL_HEIGHT", // Upload thumbnail height
            "MULTIPLE_UPLOAD_SEPARATOR", // Upload multiple separator
            "IMPORT_FILE_ALLOWED_EXTENSIONS", // Import file allowed extensions
            "USE_COLORBOX",
            "PROJECT_STYLESHEET_FILENAME", // Project style sheet
            "EMBED_PDF",
            "LAZY_LOAD",
            "REMOVE_XSS",
            "ENCRYPTED_PASSWORD",
            "INVALID_USERNAME_CHARACTERS",
            "INVALID_PASSWORD_CHARACTERS",
            "USE_RESPONSIVE_TABLE",
            "RESPONSIVE_TABLE_CLASS",
            "SEARCH_FILTER_OPTION",
            "OPTION_HTML_TEMPLATE",
            "PAGE_LAYOUT",
            "CLIENT_VALIDATE",
            "IN_OPERATOR_VALUE_SEPARATOR",
            "TABLE_BASIC_SEARCH",
            "TABLE_BASIC_SEARCH_TYPE",
            "TABLE_PAGE_NUMBER",
            "TABLE_SORT",
            "FORM_KEY_COUNT_NAME",
            "FORM_ROW_ACTION_NAME",
            "FORM_BLANK_ROW_NAME",
            "FORM_OLD_KEY_NAME",
            "IMPORT_MAX_FAILURES",
            "TWO_FACTOR_AUTHENTICATION_PASS_CODE_LENGTH",
            "USE_JAVASCRIPT_MESSAGE",
            "LIST_ACTION",
            "VIEW_ACTION",
            "EDIT_ACTION",
            "IS_WINDOWS_AUTHENTICATION", // DN
            "RTL_LANGUAGES"
        };

        /// <summary>
        /// Additional JSON configuration files
        /// e.g. Config_Init server event
        /// JsonFiles.Add(new { Path = "foobar.json", Optional = false, ReloadOnChange = true });
        /// </summary>
        public static List<dynamic> JsonFiles { get; set; } = [];

        /// <summary>
        /// Chat URL
        /// </summary>
        public static string ChatUrl { get; set; } = "";
    }
} // End Partial class
