namespace SnDOne.Controllers;

[ApiController]
[Route("api/[controller]/")]
[EnableCors("ApiCorsPolicy")]
[HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
public abstract class ApiController : Controller
{
    public static Lang Language = ResolveLanguage();
}

/// <summary>
/// List records from a table
/// </summary>
/// <example>
/// api/list/cars
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class ListController : ApiController
{
    [HttpGet("{table}")]
    public async Task<IActionResult> List([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "List", [this]);
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(false, Language.Phrase("FailedToCreate"));
    }
}

/// <summary>
/// Get a record from a table
/// </summary>
/// <example>
/// api/view/cars/1/...
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class ViewController : ApiController
{
    [HttpGet("{table}/{**key}")]
    public async Task<IActionResult> Get([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "View", [this]);
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(false, Language.Phrase("FailedToCreate"));
    }
}

/// <summary>
/// Insert a record to a table by POST
/// </summary>
/// <example>
/// api/add
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class AddController : ApiController
{
    [HttpPost("{table}")]
    public async Task<IActionResult> Add([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "Add", [this]);
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(false, Language.Phrase("FailedToCreate"));
    }
}

/// <summary>
/// Edit a record by POST
/// </summary>
/// <example>
/// api/edit/cars/1/...
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class EditController : ApiController
{
    [HttpPost("{table}/{**key}")]
    public async Task<IActionResult> Edit([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "Edit", [this]);
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(false, Language.Phrase("FailedToCreate"));
    }
}

/// <summary>
/// Delete a record from a table
/// </summary>
/// <example>
/// api/delete/cars/1/...
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class DeleteController : ApiController
{
    [HttpGet("{table}/{**key}")]
    [HttpPost("{table}")]
    public async Task<IActionResult> Delete([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "Delete", [this]);
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(false, Language.Phrase("FailedToCreate"));
    }
}

/// <summary>
/// Export file
/// </summary>
/// <example>
/// api/export/cars
/// </example>
[Authorize(Policy = "ApiUserLevelLite")]
public class ExportController : ApiController
{
    /// <summary>
    /// Export file by export type and table name
    /// </summary>
    /// <param name="type">Export type</param>
    /// <param name="table">Table name</param>
    /// <returns>Export content</returns>
    [HttpPost("{type}/{table}")]
    [HttpGet("{type}/{table}")]
    public async Task<IActionResult> ExportData([FromRoute] string type, [FromRoute] string table)
    {
        ExportHandler obj = new(this);
        return await obj.ExportData(type, table);
    }

    /// <summary>
    /// Export file by export type, table name and primary key
    /// </summary>
    /// <param name="type">Export type</param>
    /// <param name="table">Table name</param>
    /// <param name="key">Primary key</param>
    /// <returns>Export content</returns>
    [HttpPost("{type}/{table}/{**key}")]
    [HttpGet("{type}/{table}/{**key}")]
    public async Task<IActionResult> ExportData([FromRoute] string type, [FromRoute] string table, [FromRoute] string key)
    {
        ExportHandler obj = new(this);
        return await obj.ExportData(type, table, key.Split('/'));
    }

    /// <summary>
    /// Search export file
    /// </summary>
    /// <param name="search">File guid / search</param>
    /// <returns>Export content</returns>
    [HttpGet("{search}")]
    public async Task<IActionResult> Search([FromRoute] string search)
    {
        ExportHandler obj = new(this);
        return await obj.Search(search);
    }
}

/// <summary>
/// Register a record to a table by POST
/// </summary>
/// <example>
/// api/register
/// </example>
[AllowAnonymous]
public class RegisterController : ApiController
{
    // Post
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var obj = CreateInstance("Register", [this]);
        if (obj != null)
            return await obj.Run();
        return new JsonBoolResult(false, Language.Phrase("FailedToCreate"));
    }
}

/// <summary>
/// Login by POST
/// </summary>
/// <example>
/// api/login
/// </example>
[AllowAnonymous]
public class LoginController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] LoginModel model)
    {
        // User profile
        Profile = ResolveProfile();

        // Security
        Security = ResolveSecurity();

        // As an example, AuthService.CreateToken can return Jose.JWT.Encode(claims, YourTokenSecretKey, Jose.JwsAlgorithm.HS256);
        if (await Security.ValidateUser(model))
            return Ok(new { JWT = Security.CreateJwtToken(model.Expire * 60 * 60, model.Permission) });
        return BadRequest(new { error = Language.Phrase("InvalidUidPwd") });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] LoginModel model)
    {
        // User profile
        Profile = ResolveProfile();

        // Security
        Security = ResolveSecurity();

        // As an example, AuthService.CreateToken can return Jose.JWT.Encode(claims, YourTokenSecretKey, Jose.JwsAlgorithm.HS256);
        if (await Security.ValidateUser(model))
            return Ok(new { JWT = Security.CreateJwtToken(model.Expire * 60 * 60, model.Permission) });
        return BadRequest(new { error =  Language.Phrase("InvalidUidPwd") });
    }
}

/// <summary>
/// Get a file
/// </summary>
/// <example>
/// api/file/cars/Picture/1/...
/// </example>
public class FileController : ApiController
{
    /// <summary>
    /// Get file by table name, field name and primary key
    /// </summary>
    /// <param name="table">Table name</param>
    /// <param name="field">Field name</param>
    /// <param name="key">Primary key</param>
    /// <returns>File result</returns>
    [Authorize(Policy = "UserLevel")]
    [HttpGet("{table}/{field}/{**key}")]
    public async Task<IActionResult> GetFile([FromRoute] string table, [FromRoute] string field, [FromRoute] string key)
    {
        FileViewer obj = new(this);
        return await obj.GetFile(table, field, key.Split('/'));
    }

    /// <summary>
    /// Get file by table name and file path
    /// </summary>
    /// <param name="table">Table name</param>
    /// <param name="fn">File path</param>
    /// <returns>File result</returns>
    [Authorize(Policy = "UserLevel")]
    [HttpGet("{table}/{fn}")]
    public async Task<IActionResult> GetFile([FromRoute] string table, [FromRoute] string fn)
    {
        FileViewer obj = new(this);
        return await obj.GetFile(table, fn);
    }

    /// <summary>
    /// Get file by file path
    /// </summary>
    /// <param name="fn">File path</param>
    /// <returns>File result</returns>
    [AllowAnonymous]
    [HttpGet("{fn}")]
    public async Task<IActionResult> GetFile([FromRoute] string fn)
    {
        FileViewer obj = new(this);
        return await obj.GetFile(fn);
    }
}

/// <summary>
/// File upload
/// </summary>
/// <example>
/// api/upload
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class UploadController : ApiController
{
    [HttpPost]
    [HttpPut]
    public async Task<IActionResult> Post() => await HttpUpload.GetUploadedFiles();
}

/// <summary>
/// File upload with jQuery File Upload
/// </summary>
/// <example>
/// api/jupload
/// </example>
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class JUploadController : ApiController
{
    [HttpGet]
    [HttpPost]
    [HttpPut]
    public async Task<IActionResult> Index()
    {
        var obj = new UploadHandler(this);
        return await obj.Run();
    }
}

/// <summary>
/// Session handler
/// </summary>
/// <example>
/// api/session
/// </example>
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class SessionController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        var obj = new SessionHandler(this);
        return obj.GetSession();
    }
}

/// <summary>
/// Lookup (UpdateOption/ModalLookup/AutoSuggest/AutoFill)
/// </summary>
/// <example>
/// api/lookup
/// </example>
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class LookupController : ApiController
{
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<IActionResult> Post([FromForm] string page) // Single request
    {
        dynamic? obj = Resolve(page); // Get object created in API permission handler
        var res = await obj?.Lookup() ?? new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion };
        return new JsonBoolResult((object)res, res.TryGetValue("result", out object? v) ? ConvertToString(v) == "OK" : false);
    }

    [HttpPost]
    [Consumes("application/json")]
    public async Task<IActionResult> Batch([FromBody] List<Dictionary<string, string>> pages) // Batch request (json)
    {
        List<object> responses = [];
        foreach (Dictionary<string, string> req in pages) {
            if (req.TryGetValue(Config.ApiLookupPage, out string? page) && req.TryGetValue(Config.ApiFieldName, out string? fieldName)) {
                dynamic? obj = Resolve(page); // Get object
                dynamic? tbl = obj?.FieldByName(fieldName)?.Lookup?.GetTable(); // Get table
                if (tbl != null) {
                    Security.LoadTablePermissions(tbl.TableVar);
                    object res = Security.CanLookup
                        ? await obj?.Lookup(req) ?? new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion }
                        : new { success = false, error = "401 " + Language.Phrase("401"), version = Config.ProductVersion };
                    responses.Add(res);
                }
            }
        }
        return Json(responses);
    }
}

/// <summary>
/// Chart exporter
/// </summary>
/// <example>
/// api/chart
/// </example>
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ChartController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var exporter = new ChartExporter(this);
        return await exporter.Export();
    }
}

/// <summary>
/// Permissions
/// </summary>
/// <example>
/// api/permissions/{userlevel}
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class PermissionsController : ApiController
{
    [AllowAnonymous]
    [HttpGet("{userlevel?}")]
    public IActionResult Get([FromRoute] string userlevel)
    {
        if (!ValidApiRequest())
            return new EmptyResult();
        Security.SetupUserLevel();

        // Check user level
        int userLevel = -2; // Default anonymous
        List<int> userLevels = [];
        userLevels.Add(userLevel);
        if (Security.IsLoggedIn) {
            if (Security.IsSysAdmin && IsNumeric(userlevel) && userlevel != "-1") { // Get permissions for user level
                if (Security.UserLevelIDExists(ConvertToInt(userlevel))) { // Make sure user level exists
                    userLevel = ConvertToInt(userlevel);
                    userLevels.Clear();
                    userLevels.Add(userLevel);
                }
            } else { // Get current user permissions
                userLevel = ConvertToInt(Security.CurrentUserLevelID);
                userLevels = Security.UserLevelID;
            }
        }
        Dictionary<string, int> privs = new();
        var wrkTable = Config.UserLevelTablePermissions;
        foreach (var table in wrkTable) {
            if (table.Allowed) {
                int priv = 0;
                foreach (int lvl in userLevels)
                    priv |= Security.GetUserLevelPriv(table.ProjectId + table.TableName, lvl);
                privs.Add(table.TableVar, priv);
            }
        }
        return Json(new { userlevel = userLevel, permissions = privs });
    }

    // Post with route
    [HttpPost("{userlevel}")]
    public async Task<IActionResult> PostWithRoute([FromRoute] string userlevel, [FromBody] Dictionary<string, int> permissions)
    {
        if (!ValidApiRequest())
            return new EmptyResult();
        await Security.SetupUserLevels();

        // Check if admin
        if (!Security.IsSysAdmin)
            return new EmptyResult();

        // Check user level
        int userLevel;
        if (IsNumeric(userlevel) && userlevel != "-1") { // Set permissions for user level
            userLevel = ConvertToInt(userlevel);
        } else {
            return new EmptyResult();
        }
        Dictionary<string, int> privs = new();
        Dictionary<string, int> privsOut = new();
        var wrkTable = Config.UserLevelTablePermissions;
        foreach (var table in wrkTable) {
            if (table.Allowed && permissions.ContainsKey(table.TableVar)) {
                int priv = permissions[table.TableVar];
                privs.Add(table.ProjectId + table.TableName, priv);
                privsOut.Add(table.TableName, priv);
            }
        }
        var mi = Security.GetType().GetMethod("UpdatePermissions", BindingFlags.Public | BindingFlags.Instance);
        if (mi?.Invoke(Security, [userLevel, privs]) is Task<bool> res)
            await res; // Update Permissions
        return Json(new { success = true, userlevel = userLevel, permissions = privsOut });
    }
}

/// <summary>
/// Enable/Disable Chat
/// </summary>
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ChatController : ApiController
{
    [HttpGet("{enabled}")]
    public async Task<IActionResult> Get([FromRoute] string enabled)
    {
        if (!IsSysAdmin()) {
            if (await ResolveProfile().SetUserName(CurrentUserName()).SetChatEnabled(ConvertToBool(enabled)).SaveToStorageAsync())
                return Json(new { success = true });
        }
        return Json(new { success = false });
    }
}

// Custom API actions
public partial class LookUpListController : ApiController
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public LookUpListController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    private string EncodeForXSS(string input)
    {
        return input;
        if (string.IsNullOrEmpty(input)) return input;
        return input
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'", "&#39;")
            .Replace("(", "&#40;")
            .Replace(")", "&#41;")
            .Replace("{", "&#123;")
            .Replace("}", "&#125;");
    }

    private string GetTipeProses(string tipeProses)
    {
        return tipeProses switch
        {
            "PenyaluranTruck" or "PenyaluranLPGTASNGS" or "PenyaluranKonsinyasiSTSBBM" or "PenyaluranTasNgs" or "PenyaluranKonsinyasiSTSLPG" or
            "PenyaluranPipa" or "PenyaluranSalesPipa" or "PenyaluranPipaLPG" or "PenyaluranKonsinyasiRTW" or "PenyaluranKonsinyasiTruck" or "PenyaluranKonsinyasiTruckTAS" or "PenyaluranPipaJarakDekat"
                => "Penyaluran",
            "PenerimaanSTSBBM" or "PenerimaanSTSLPG" or "PenerimaanPipa" or "PenerimaanRTW" or "PenerimaanTruck" or "PenerimaanPipaRefinery"
                => "Penerimaan",
            "PenyimpananPenerimaanLPG" or "PenyimpananPenerimaanSTSBBM" or "PenyimpananPenerimaanLPGSTS" or "PenyimpananPenerimaanPipa" or 
            "PenyimpananPenerimaanPipaLPG" or "PenyimpananPenerimaanRTW" or "PenyimpananPenerimaanTruck"
                => "Penimbunan",
            "PenimbunanPenyaluranLPG" or "PenyimpananPenyaluranSalesSTSBBM" or "PenyimpananPenyaluranKonsinyasiSTSBBM" or
            "PenyimpananPenyaluranSalesSTSLPG" or "PenyimpananPenyaluranKonsinyasiSTSLPG" or "PenyimpananPenyaluranSalesPipa" or
            "PenyimpananPenyaluranKonsinyasiPipa" or "PenyimpananPenyaluranSalesRTW" or "PenyimpananPenyaluranKonsinyasiRTW" or "PenyimpananPenyaluranKonsinyasi"
                => "PenimbunanPenyaluran",
            "ClosingStockSTSBBM" or "ClosingStockSTSLPG" 
                => "ClosingStock",
            "RencanaPenyaluranLPG" or "RencanaPenyaluranPipa"
                => "RencanaPenyaluran",
            _ => tipeProses
        };
    }

    private async Task UpdateStatusProsesByIdAktivitas(int idAktivitas)
    {
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            "EXEC UpdateStatusProses_ByAktivitas @IdAktivitas",
            new Dictionary<string, object> {
                { "@IdAktivitas", idAktivitas }
            },
            idAktivitas: idAktivitas
        );
    }

    [HttpGet("sub-aktivitas/startup")]
    public async Task<IActionResult> GetStartupSubAktivitasData(int idAktivitas)
    {
        if (!IsLoggedIn())
        {
            throw new LogErrorException("Unauthorized access", StatusCodes.Status401Unauthorized , idAktivitas: idAktivitas);
        }
        var isEditable = await CheckIsEditableSubAktivitas(idAktivitas);
        var statusAktivitas = await DatabaseQueryHelper.ExecuteSelectSingleAsync<string>(
            "Select Top 1 StatusAktivitas from Aktivitas Where IdAktivitas = @IdAktivitas",
            reader => reader.GetString(0),
            new Dictionary<string, object> { { "@IdAktivitas", idAktivitas } },
            idAktivitas: idAktivitas);
        var logAktivitas = await DatabaseQueryHelper.ExecuteSelectListQueryAsync<GetStartupSubAktivitasResponse.LogAktivitasResponse>(
            @"SELECT a.NamaAktivitas as Aktivitas, log.username as Username, log.status_aktivitas as StatusAktivitas, log.etl_date as Tanggal, log.Catatan FROM log_aktivitas log INNER JOIN Aktivitas a ON log.id_aktivitas = a.IdAktivitas WHERE log.id_aktivitas = @IdAktivitas ORDER BY Tanggal DESC;",
            reader => new GetStartupSubAktivitasResponse.LogAktivitasResponse
            {
                Aktivitas = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                UserName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                StatusAktivitas = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                Tanggal = reader.IsDBNull(3)
                    ? string.Empty
                    : reader.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss"),
                Catatan = reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
            },
            new Dictionary<string, object> { { "@IdAktivitas", idAktivitas } },
            idAktivitas: idAktivitas);
        return Ok(new GetStartupSubAktivitasResponse
        {
            IsEditable = isEditable,
            StatusAktivitas = statusAktivitas,
            LogAktivitas = logAktivitas
        });
    }

    private async Task<bool> CheckIsEditableSubAktivitas(int idAktivitas)
    {
        string currentUser = CurrentUserLevel();
        string idPos = CurrentUserInfo("IdPosition")?.ToString();
        string sqlData = @"EXEC CheckIsEditableAktivitasForm_ByAktivitasId @IdAktivitas";
        string tableRef = "", colPlant = "";
        string userName = CurrentUserName();
        var isEditable = true;
        var countRole = 0;
        isEditable = await DatabaseQueryHelper.ExecuteSelectSingleAsync<bool>(
            sqlData,
            reader => reader.GetBoolean(0),
            new Dictionary<string, object> { { "@IdAktivitas", idAktivitas } },
            idAktivitas: idAktivitas);
        tableRef = await DatabaseQueryHelper.ExecuteSelectSingleAsync<string>(
                    "SELECT TipeProses FROM Aktivitas WHERE IdAktivitas = @IdAktivitas",
                    reader => reader.GetString(0),
                    new Dictionary<string, object> { { "@IdAktivitas", idAktivitas } },
                    idAktivitas: idAktivitas);
        switch (tableRef)
        {
            case "Penyaluran" or "PenyaluranTruck" or "PenyaluranLPGTASNGS" or "PenyaluranKonsinyasiSTSBBM" or "PenyaluranTasNgs" or "PenyaluranKonsinyasiSTSLPG" or
                 "PenyaluranPipa" or "PenyaluranSalesPipa" or "PenyaluranPipaLPG" or "PenyaluranKonsinyasiRTW" or "PenyaluranKonsinyasiTruck" or "PenyaluranKonsinyasiTruckTAS":
                tableRef = "Penyaluran";
                colPlant = "IdPlant";
                break;
            case "Penerimaan" or "PenerimaanSTSBBM" or "PenerimaanSTSLPG" or "PenerimaanPipa" or "PenerimaanRTW" or "PenerimaanTruck" or "PenerimaanPipaRefinery":
                tableRef = "Penerimaan";
                colPlant = "IdPlant";
                break;
            case "Penimbunan" or "PenyimpananPenerimaanLPG" or "PenyimpananPenerimaanSTSBBM" or "PenyimpananPenerimaanLPGSTS" or "PenyimpananPenerimaanPipa" or "PenyimpananPenerimaanPipaLPG" or "PenyimpananPenerimaanRTW" or "PenyimpananPenerimaanTruck":
                tableRef = "Penimbunan";
                colPlant = "Plant";
                break;
            case "PenimbunanPenyaluran" or "PenimbunanPenyaluranLPG" or "PenyimpananPenyaluranSalesSTSBBM" or "PenyimpananPenyaluranKonsinyasiSTSBBM" or
                 "PenyimpananPenyaluranSalesSTSLPG" or "PenyimpananPenyaluranKonsinyasiSTSLPG" or "PenyimpananPenyaluranSalesPipa" or
                 "PenyimpananPenyaluranKonsinyasiPipa" or "PenyimpananPenyaluranSalesRTW" or "PenyimpananPenyaluranKonsinyasiRTW" or "PenyimpananPenyaluranKonsinyasi":
                tableRef = "PenimbunanPenyaluran";
                colPlant = "Plant";
                break;
            case "RencanaPenyaluran" or "RencanaPenyaluranLPG" or "RencanaPenyaluranPipa":
                tableRef = "RencanaPenyaluran";
                colPlant = "IdPlant";
                break;
            case "SamplingLabTest":
                colPlant = "IdPlant";
                break;
            case "ClosingStock" or "ClosingStockSTSBBM" or "ClosingStockSTSLPG":
                colPlant = "Plant";
                break;
        }
        if (currentUser != "-1")
        {
            var idPic = CurrentUserInfo("Rule");
            if (idPic == null) return false;
            string sqlCekRole = @"WITH SplitValues AS (
                        SELECT
                            A.IdTemplateAktivitas,
                            TRIM(value) AS IdPIC,
                            A.IdAktivitas
                        FROM Aktivitas A
                                JOIN TemplateAktivitas TA ON A.IdTemplateAktivitas = TA.IdTemplateAktivitas
                                CROSS APPLY STRING_SPLIT(TA.IdPIC, ',')
                    )
                    SELECT COUNT(DISTINCT IdTemplateAktivitas) AS JumlahAktivitas
                    FROM SplitValues
                    WHERE IdPIC = @IdPIc and IdAktivitas = @IdAktivitas";
            countRole = await DatabaseQueryHelper.ExecuteSelectSingleAsync<int>(
                sqlCekRole,
                reader => reader.GetInt32(0),
                new Dictionary<string, object>
                {
                    { "@IdAktivitas", idAktivitas },
                    { "@IdPic", idPic }
                },
                idAktivitas: idAktivitas);
            if (countRole < 1)
            {
                isEditable = false;
            }
        }
        if (currentUser == "3")
        {
            isEditable = false;
        } 
        else if (currentUser == "6")
        {
            isEditable = true;
            if (string.IsNullOrEmpty(idPos) || string.IsNullOrEmpty(colPlant) || string.IsNullOrEmpty(tableRef)) 
            {
                return false;
            }
            sqlData = $@"SELECT COUNT(*) AS JumlahSesuai
                            FROM Aktivitas a
                            JOIN {tableRef} p ON a.No_Referensi = p.Nomor{tableRef}
                            JOIN MasterPlant mp ON p.{colPlant} = mp.IdPlant
                            WHERE a.IdAktivitas = @IdAktivitas
                            AND mp.JenisPlant = 'STS'
                            AND p.{colPlant} IN (
                                SELECT IdPlant 
                                FROM MappingPosition 
                                WHERE IdPosition = @IdPosition
                            );
                            ";
            int plantCount = 0;
            plantCount = await DatabaseQueryHelper.ExecuteSelectSingleAsync<int>(
                sqlData,
                reader => reader.GetInt32(0),
                new Dictionary<string, object>
                {
                    { "@IdAktivitas", idAktivitas },
                    { "@IdPosition", idPos }
                },
                idAktivitas: idAktivitas);
            if (plantCount <= 0)
            {
                var idTemplateProses = 0;
                var acceptProcessListUser6 = new List<int> { 22, 23, 25, 48, 49, 50, 76, 77, 78, 79, 80, 81, 21, 26, 160, 161};
                sqlData = @"SELECT P.IdTemplateProses
                        from Aktivitas A
                    JOIN dbo.Proses P on A.IdProses = P.IdProses
                    WHERE A.IdAktivitas = @IdAktivitas";
                idTemplateProses = await DatabaseQueryHelper.ExecuteSelectSingleAsync<int>(
                    sqlData,
                    reader => reader.GetInt32(0),
                    new Dictionary<string, object>
                    {
                        { "@IdAktivitas", idAktivitas }
                    },
                    idAktivitas: idAktivitas);
                if (!acceptProcessListUser6.Contains(idTemplateProses))
                {
                    isEditable = false;
                }
            }
        }
        return isEditable;
    }

    [HttpGet("Tipe-Produk")]
    public async Task<IActionResult> GetTipeProduk(int idAktivitas)
    {
        var sqlQuery = @"Select Top 1 MP.TipeProduk
                from Aktivitas
                Join PenimbunanPenyaluran RP on RP.NomorPenimbunanPenyaluran = Aktivitas.No_Referensi
                Join MasterPlant MP on MP.IdPlant = RP.Plant
                Where IdAktivitas = @IdAktivitas";
        var result = await DatabaseQueryHelper.ExecuteSelectSingleAsync<object>(
            sqlQuery,
            reader => new
            {
                TipeProduk = reader.IsDBNull(0) ? null : reader.GetString(0)
            },
            new Dictionary<string, object> { { "@IdAktivitas", idAktivitas } },
            idAktivitas: idAktivitas
        );
        return Ok(result);
    }

    private async Task AddLogAktivitas(int idAktivitas, string statusAktivitas, string? catatan = null)
    {
        (string noReferensi, int idProses) = await DatabaseQueryHelper.ExecuteSelectSingleAsync<(string, int)>(
            "SELECT No_Referensi, IdProses FROM Aktivitas WHERE IdAktivitas = @IdAktivitas",
            reader => (
                reader.IsDBNull(0) ? "" : reader.GetString(0),
                reader.IsDBNull(1) ? 0  : reader.GetInt32(1)
            ),
            new Dictionary<string, object> { { "@IdAktivitas", idAktivitas } },
            idAktivitas: idAktivitas
        );
        DateTime plantTime = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
            "EXEC dbo.GetPlantDateTime @NomorReferensi = @NomorReferensi",
            reader => {
                var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                if (val == null) return DateTime.Now;
                return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
            },
            new Dictionary<string, object> { { "@NomorReferensi", noReferensi } },
            noReferensi: noReferensi,
            idProses: idProses,
            idAktivitas: idAktivitas
        );
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            @"  INSERT INTO log_aktivitas 
                (no_referensi, id_proses, id_aktivitas, username, status_aktivitas, etl_date, Catatan)
                VALUES (@NoReferensi, @IdProses, @IdAktivitas, @Username, @Status, @PlantTime, @Catatan)", 
            new Dictionary<string, object> { 
                { "@NoReferensi", noReferensi },
                { "@IdProses", idProses },
                { "@IdAktivitas", idAktivitas },
                { "@Username", CurrentUserName() },
                { "@Status", statusAktivitas },
                { "@PlantTime", plantTime },
                { "@Catatan", catatan ?? "" }
            },
            noReferensi: noReferensi,
            idProses: idProses,
            idAktivitas: idAktivitas
        );
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            @"  UPDATE Aktivitas 
                    SET DiperbaruiOleh = @CurrentUser, TanggalDiperbarui = @PlantTime 
                WHERE IdAktivitas = @IdAktivitas", 
            new Dictionary<string, object> { 
                { "@IdAktivitas", idAktivitas },
                { "@CurrentUser", CurrentUserName() },
                { "@PlantTime", plantTime }
            },
            noReferensi: noReferensi,
            idProses: idProses,
            idAktivitas: idAktivitas
        );
    }

    private async Task UpdateProsesValue(int idAktivitas)
    {
        using (SqlConnection connection = GetConnection("Db").OpenConnection())
        {
            string updateStatusAndProgresSql = "";
            string username = CurrentUserName();
            bool updatedProsesTimestamp = false;
            var (idProses, statusAktivitas, tipeProses, noReferensi) =
                await DatabaseQueryHelper.ExecuteSelectSingleAsync<(
                    int idProses,
                    string statusAktivitas,
                    string tipeProses,
                    string noReferensi
                )>(
                    @"  SELECT TOP 1 IdProses, StatusAktivitas, TipeProses, No_Referensi 
                        FROM Aktivitas WHERE IdAktivitas = @IdAktivitas",
                    reader => (
                        reader.IsDBNull(0) ? 0  : reader.GetInt32(0),
                        reader.IsDBNull(1) ? "" : reader.GetString(1),
                        reader.IsDBNull(2) ? "" : reader.GetString(2),
                        reader.IsDBNull(3) ? "" : reader.GetString(3)
                    ),
                    new Dictionary<string, object> {
                        { "@IdAktivitas", idAktivitas }
                    },
                    idAktivitas: idAktivitas
                );
            if (idProses == 0)
                return;
            int totalNotCompleted = await DatabaseQueryHelper.ExecuteSelectSingleAsync<int>(
                @"  SELECT COUNT(*)
                    FROM Aktivitas a
                    WHERE a.IdProses = @IdProses
                    AND a.StatusAktivitas NOT IN ('Completed','Editing', 'Completed Edit')
                    AND (
                        a.TipeAktivitas = 'Form'
                        OR (
                            a.TipeAktivitas = 'Dokumen'
                            AND EXISTS (
                                SELECT 1
                                FROM AktivitasDokumen ad
                                WHERE ad.IdAktivitas = a.IdAktivitas
                                    AND ad.WajibUpload = 1
                            )
                        ) or 
                        (a.TipeAktivitas = 'Tabel' and a.IdTemplateAktivitas != 179)
                    );",
                reader => (
                    reader.IsDBNull(0) ? 0  : reader.GetInt32(0)
                ),
                new Dictionary<string, object> { { "@IdProses", idProses } },
                noReferensi: noReferensi,
                idProses: idProses,
                idAktivitas: idAktivitas
            );
            var (tanggalMulai, tanggalSelesai) =
                await DatabaseQueryHelper.ExecuteSelectSingleAsync<(
                    DateTime? TanggalMulai,
                    DateTime? TanggalSelesai
                )>(
                    "SELECT TanggalMulai, TanggalSelesai FROM Proses WHERE IdProses = @IdProses",
                    reader => (
                        reader.IsDBNull(0) ? (DateTime?)null : reader.GetDateTime(0),
                        reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1)
                    ),
                    new Dictionary<string, object> { { "@IdProses", idProses } },
                    noReferensi: noReferensi,
                    idProses: idProses,
                    idAktivitas: idAktivitas
                );
            DateTime plantTime = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
                "EXEC dbo.GetPlantDateTime @NomorReferensi = @NomorReferensi",
                reader => {
                    var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                    if (val == null) return DateTime.Now;
                    return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
                },
                new Dictionary<string, object> { { "@NomorReferensi", noReferensi } },
                noReferensi: noReferensi,
                idProses: idProses,
                idAktivitas: idAktivitas
            );
            if (totalNotCompleted == 0)
            {
                await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                    @"  UPDATE Proses 
                        SET TanggalSelesai = @PlantTime, 
                            DiperbaruiOleh = @Username, 
                            TanggalDiperbarui = @PlantTime 
                        WHERE IdProses = @IdProses;", 
                    new Dictionary<string, object> { 
                        { "@PlantTime", plantTime },
                        { "@Username", username },
                        { "@IdProses", idProses }
                    },
                    noReferensi: noReferensi,
                    idProses: idProses,
                    idAktivitas: idAktivitas
                );
                updatedProsesTimestamp = true;
            }
            if (tanggalMulai == null)
            {
                await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                    @"  UPDATE Proses 
                        SET TanggalMulai = @PlantTime, 
                            DiperbaruiOleh = @Username, 
                            TanggalDiperbarui = @PlantTime 
                        WHERE IdProses = @IdProses;", 
                    new Dictionary<string, object> { 
                        { "@PlantTime", plantTime },
                        { "@Username", username },
                        { "@IdProses", idProses }
                    },
                    noReferensi: noReferensi,
                    idProses: idProses,
                    idAktivitas: idAktivitas
                );
                updatedProsesTimestamp = true;
            }
            if (!updatedProsesTimestamp)
            {
                await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                    @"  UPDATE Proses 
                        SET TanggalDiperbarui = @PlantTime, 
                            DiperbaruiOleh = @Username 
                        WHERE IdProses = @IdProses;", 
                    new Dictionary<string, object> { 
                        { "@PlantTime", plantTime },
                        { "@Username", username },
                        { "@IdProses", idProses }
                    },
                    noReferensi: noReferensi,
                    idProses: idProses,
                    idAktivitas: idAktivitas
                );
            }
            tipeProses = GetTipeProses(tipeProses);
            switch (tipeProses) {
                case "Penerimaan":
                    updateStatusAndProgresSql = @"UPDATE P
                            SET
                                P.StatusProses = T.StatusProsesGabungan,
                                P.PersentaseProgress = T.PersentaseProses,
                                P.TanggalDiperbarui = @PlantTime
                            FROM Penerimaan P
                            JOIN (
                                SELECT
                                    P2.NomorPenerimaan,
                                    CASE
                                        WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses = 'Waiting' THEN 1 ELSE 0 END) THEN 'Waiting'
                                        WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) THEN 'Complete'
                                        ELSE 'In Progress'
                                    END AS StatusProsesGabungan,
                                    ROUND(
                                        CAST(SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) AS FLOAT)
                                        / COUNT(*), 2
                                    ) AS PersentaseProses
                                FROM Penerimaan P2
                                JOIN dbo.Proses A ON P2.NomorPenerimaan = A.IdReferensi
                                WHERE P2.NomorPenerimaan = @NomorPenerimaan
                                GROUP BY P2.NomorPenerimaan
                            ) T ON P.NomorPenerimaan = T.NomorPenerimaan
                            WHERE P.NomorPenerimaan = @NomorPenerimaan;";
                    await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                        updateStatusAndProgresSql, 
                        new Dictionary<string, object> { 
                            { "@NomorPenerimaan", noReferensi },
                            { "@PlantTime", plantTime }
                        },
                        noReferensi: noReferensi,
                        idProses: idProses,
                        idAktivitas: idAktivitas
                    );
                    break;
                case "Penyaluran":
                    updateStatusAndProgresSql = @"UPDATE P
                        SET
                            P.StatusProses = T.StatusProsesGabungan,
                            P.PersentaseProgress = T.PersentaseProses, 
                            P.TanggalDiperbarui = @PlantTime
                        FROM Penyaluran P
                        JOIN (
                            SELECT
                                P2.NomorPenyaluran,
                                CASE
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses = 'Waiting' THEN 1 ELSE 0 END) THEN 'Waiting'
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) THEN 'Complete'
                                    ELSE 'In Progress'
                                END AS StatusProsesGabungan,
                                ROUND(
                                    CAST(SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) AS FLOAT)
                                    / COUNT(*), 2
                                ) AS PersentaseProses
                            FROM Penyaluran P2
                            JOIN dbo.Proses A ON P2.NomorPenyaluran  = A.IdReferensi
                            WHERE P2.NomorPenyaluran = @NomorPenyaluran
                            GROUP BY P2.NomorPenyaluran
                        ) T ON P.NomorPenyaluran = T.NomorPenyaluran
                        WHERE P.NomorPenyaluran = @NomorPenyaluran;";
                    await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                        updateStatusAndProgresSql, 
                        new Dictionary<string, object> { 
                            { "@NomorPenyaluran", noReferensi },
                            { "@PlantTime", plantTime }
                        },
                        noReferensi: noReferensi,
                        idProses: idProses,
                        idAktivitas: idAktivitas
                    );
                    break;
                case "RencanaPenyaluran":
                    updateStatusAndProgresSql = @"UPDATE P
                        SET
                            P.StatusProses = T.StatusProsesGabungan,
                            P.PersentaseProgress = T.PersentaseProses, 
                            P.TanggalDiperbarui = @PlantTime
                        FROM RencanaPenyaluran P
                        JOIN (
                            SELECT
                                P2.NomorRencanaPenyaluran,
                                CASE
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses = 'Waiting' THEN 1 ELSE 0 END) THEN 'Waiting'
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) THEN 'Complete'
                                    ELSE 'In Progress'
                                END AS StatusProsesGabungan,
                                ROUND(
                                    CAST(SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) AS FLOAT)
                                    / COUNT(*), 2
                                ) AS PersentaseProses
                            FROM RencanaPenyaluran P2
                            JOIN dbo.Proses A ON P2.NomorRencanaPenyaluran  = A.IdReferensi
                            WHERE P2.NomorRencanaPenyaluran = @NomorPenyaluran
                            GROUP BY P2.NomorRencanaPenyaluran
                        ) T ON P.NomorRencanaPenyaluran = T.NomorRencanaPenyaluran
                        WHERE P.NomorRencanaPenyaluran = @NomorPenyaluran;";
                    await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                        updateStatusAndProgresSql, 
                        new Dictionary<string, object> { 
                            { "@NomorPenyaluran", noReferensi },
                            { "@PlantTime", plantTime }
                        },
                        noReferensi: noReferensi,
                        idProses: idProses,
                        idAktivitas: idAktivitas
                    );
                    break;
                case "SamplingLabTest":
                    updateStatusAndProgresSql = @"UPDATE P
                        SET
                            P.StatusProses = T.StatusProsesGabungan,
                            P.PersentaseProgress = T.PersentaseProses, 
                            P.TanggalDiperbarui = @PlantTime
                        FROM SamplingLabTest P
                        JOIN (
                            SELECT
                                P2.NomorSamplingLabTest,
                                CASE
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses = 'Waiting' THEN 1 ELSE 0 END) THEN 'Waiting'
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) THEN 'Complete'
                                    ELSE 'In Progress'
                                END AS StatusProsesGabungan,
                                ROUND(
                                    CAST(SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) AS FLOAT)
                                    / COUNT(*), 2
                                ) AS PersentaseProses
                            FROM SamplingLabTest P2
                            JOIN dbo.Proses A ON P2.NomorSamplingLabTest  = A.IdReferensi
                            WHERE P2.NomorSamplingLabTest = @NomorPenyaluran
                            GROUP BY P2.NomorSamplingLabTest
                        ) T ON P.NomorSamplingLabTest = T.NomorSamplingLabTest
                        WHERE P.NomorSamplingLabTest = @NomorPenyaluran;";
                    await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                        updateStatusAndProgresSql, 
                        new Dictionary<string, object> { 
                            { "@NomorPenyaluran", noReferensi },
                            { "@PlantTime", plantTime }
                        },
                        noReferensi: noReferensi,
                        idProses: idProses,
                        idAktivitas: idAktivitas
                    );
                    break; 
                case "Penimbunan":
                    updateStatusAndProgresSql = @"UPDATE P
                        SET
                            P.StatusProses = T.StatusProsesGabungan,
                            P.PersentaseProgress = T.PersentaseProses, 
                            P.TanggalDiperbarui = @PlantTime
                        FROM Penimbunan P
                        JOIN (
                            SELECT
                                P2.NomorPenimbunan,
                                CASE
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses = 'Waiting' THEN 1 ELSE 0 END) THEN 'Waiting'
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) THEN 'Complete'
                                    ELSE 'In Progress'
                                END AS StatusProsesGabungan,
                                ROUND(
                                    CAST(SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) AS FLOAT)
                                    / COUNT(*), 2
                                ) AS PersentaseProses
                            FROM Penimbunan P2
                            JOIN dbo.Proses A ON P2.NomorPenimbunan  = A.IdReferensi
                            WHERE P2.NomorPenimbunan = @NomorPenimbunan
                            GROUP BY P2.NomorPenimbunan
                        ) T ON P.NomorPenimbunan = T.NomorPenimbunan
                        WHERE P.NomorPenimbunan = @NomorPenimbunan;";
                    await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                        updateStatusAndProgresSql, 
                        new Dictionary<string, object> { 
                            { "@NomorPenimbunan", noReferensi },
                            { "@PlantTime", plantTime }
                        },
                        noReferensi: noReferensi,
                        idProses: idProses,
                        idAktivitas: idAktivitas
                    );
                    break; 
                case "PenimbunanPenyaluran":
                    updateStatusAndProgresSql = @"UPDATE P
                        SET
                            P.StatusProses = T.StatusProsesGabungan,
                            P.PersentaseProgress = T.PersentaseProses, 
                            P.TanggalDiperbarui = @PlantTime
                        FROM PenimbunanPenyaluran P
                        JOIN (
                            SELECT
                                P2.NomorPenimbunanPenyaluran,
                                CASE
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses = 'Waiting' THEN 1 ELSE 0 END) THEN 'Waiting'
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) THEN 'Complete'
                                    ELSE 'In Progress'
                                END AS StatusProsesGabungan,
                                ROUND(
                                    CAST(SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) AS FLOAT)
                                    / COUNT(*), 2
                                ) AS PersentaseProses
                            FROM PenimbunanPenyaluran P2
                            JOIN dbo.Proses A ON P2.NomorPenimbunanPenyaluran  = A.IdReferensi
                            WHERE P2.NomorPenimbunanPenyaluran = @NomorPenimbunanPenyaluran
                            GROUP BY P2.NomorPenimbunanPenyaluran
                        ) T ON P.NomorPenimbunanPenyaluran = T.NomorPenimbunanPenyaluran
                        WHERE P.NomorPenimbunanPenyaluran = @NomorPenimbunanPenyaluran;";
                    await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                        updateStatusAndProgresSql, 
                        new Dictionary<string, object> { 
                            { "@NomorPenimbunanPenyaluran", noReferensi },
                            { "@PlantTime", plantTime }
                        },
                        noReferensi: noReferensi,
                        idProses: idProses,
                        idAktivitas: idAktivitas
                    );
                    break;
                case "ClosingStock":
                    updateStatusAndProgresSql = @"UPDATE P
                        SET
                            P.StatusProses = T.StatusProsesGabungan,
                            P.PersentaseProgress = T.PersentaseProses, 
                            P.TanggalDiperbarui = @PlantTime
                        FROM ClosingStock P
                        JOIN (
                            SELECT
                                P2.NomorClosingStock,
                                CASE
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses = 'Waiting' THEN 1 ELSE 0 END) THEN 'Waiting'
                                    WHEN COUNT(*) = SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) THEN 'Complete'
                                    ELSE 'In Progress'
                                END AS StatusProsesGabungan,
                                ROUND(
                                    CAST(SUM(CASE WHEN A.StatusProses IN ('Completed', 'Editing', 'Completed Edit') THEN 1 ELSE 0 END) AS FLOAT)
                                    / COUNT(*), 2
                                ) AS PersentaseProses
                            FROM ClosingStock P2
                            JOIN dbo.Proses A ON P2.NomorClosingStock  = A.IdReferensi
                            WHERE P2.NomorClosingStock = @NomorClosingStock
                            GROUP BY P2.NomorClosingStock
                        ) T ON P.NomorClosingStock = T.NomorClosingStock
                        WHERE P.NomorClosingStock = @NomorClosingStock;";
                    await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                        updateStatusAndProgresSql, 
                        new Dictionary<string, object> { 
                            { "@NomorClosingStock", noReferensi },
                            { "@PlantTime", plantTime }
                        },
                        noReferensi: noReferensi,
                        idProses: idProses,
                        idAktivitas: idAktivitas
                    );
                    break;
            }   
        }
    }

    private async Task UpdateTanggalAktivitas(int idAktivitas)
    {
        var (statusAktivitas, noReferensi, tanggalMulai, tanggalSelesai) =
            await DatabaseQueryHelper.ExecuteSelectSingleAsync<(
                string StatusAktivitas,
                string NoReferensi,
                DateTime? TanggalMulai,
                DateTime? TanggalSelesai
            )>(
                @"  SELECT StatusAktivitas, No_Referensi, TanggalMulai, TanggalSelesai
                    FROM Aktivitas 
                    WHERE IdAktivitas = @IdAktivitas;",
                reader => (
                    reader.IsDBNull(0) ? "" : reader.GetString(0),
                    reader.IsDBNull(1) ? "" : reader.GetString(1),
                    reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                    reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)
                ),
                new Dictionary<string, object> { { "@IdAktivitas", idAktivitas } },
                idAktivitas: idAktivitas
            );
        DateTime plantDateTime = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
            "EXEC dbo.GetPlantDateTime @NomorReferensi = @NomorReferensi",
            reader => {
                var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                if (val == null) return DateTime.Now;
                return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
            },
            new Dictionary<string, object> { { "@NomorReferensi", noReferensi } },
            noReferensi: noReferensi,
            idAktivitas: idAktivitas
        );
        if (statusAktivitas == "Draft" && tanggalMulai == null)
        {
            await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                @"  UPDATE Aktivitas 
                    SET TanggalMulai = @PlantDateTime 
                    WHERE IdAktivitas = @IdAktivitas", 
                new Dictionary<string, object> { 
                    { "@PlantDateTime", plantDateTime },
                    { "@IdAktivitas", idAktivitas }
                },
                noReferensi: noReferensi,
                idAktivitas: idAktivitas
            );
        }
        else if (statusAktivitas == "Completed" 
                || statusAktivitas == "Editing" 
                || statusAktivitas == "Completed Edit")
        {
            await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                @"  UPDATE Aktivitas 
                    SET TanggalSelesai = @PlantDateTime 
                    WHERE IdAktivitas = @IdAktivitas", 
                new Dictionary<string, object> { 
                    { "@PlantDateTime", plantDateTime },
                    { "@IdAktivitas", idAktivitas }
                },
                noReferensi: noReferensi,
                idAktivitas: idAktivitas
            );
        }
        await UpdateProsesValue(idAktivitas);
    }

    [HttpGet("get-dropdown/user-plant")]
    public IActionResult GetUserPlantDropdown(int plantId)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        List<DropdownResponse> plans = new List<DropdownResponse>();
        var parameters = new Dictionary<string, object>();
        string sql = @"Select MU.IdUser as Value, MU.NamaLengkap as Label From MasterUser MU WHERE IdPosition IN (Select Distinct IdPosition From MappingPosition WHERE IdPlant = @IdPlant AND UserLevel NOT IN (-1, 3, 4))";
        parameters.Add("@IdPlant", plantId);
        try
        {
            plans = DatabaseQueryHelper.ExecuteSelectListQuery<DropdownResponse>(
                sql,
                reader => new DropdownResponse
                {
                    Value = reader["Value"] != DBNull.Value ? Convert.ToInt32(reader["Value"]) : 0,
                    Label = reader["Label"]?.ToString() ?? ""
                }, 
                parameters
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ErrorResponseDto("Failed", StatusCodes.Status500InternalServerError);
        }
        return Json(plans);
    }

    [HttpGet("get-dropdown/tujuan-konsinyasi")]
    public IActionResult GetTujuanKonsinyasi(int idPipa, int idModa)
    {
        if (!IsLoggedIn()) return Json(new { success = false, message = "Not authorized." });
        var list = new List<object>();
        string sql = "";
        if (idModa == 12)
        {
            sql = @"
                SELECT 
                    IdPlant AS Value,
                    CONCAT(Plant, ' - ', Nama_Terminal) AS Label,
                    0 AS Volume
                FROM MasterPlant ORDER BY Plant;";
        }
        else
        {
            sql = @"
                SELECT 
                    DMP.idPlantTujuan AS Value,
                    CONCAT(MP.Plant, ' - ', MP.Nama_Terminal) AS Label,
                    DMP.Volume
                FROM DetailMasterPipa DMP
                LEFT JOIN MasterPlant MP ON DMP.idPlantTujuan = MP.IdPlant
                WHERE DMP.idPipa = @idPipa;";
        }
        try
        {
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (idModa != 12)
                    cmd.Parameters.AddWithValue("@idPipa", idPipa);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new {
                            Value = r["Value"].ToString(),
                            Label = r["Label"].ToString(),
                            Volume = r["Volume"].ToString()
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Error fetching tujuan konsinyasi");
        }
        return Json(list);
    }

    [HttpGet("get-dropdown/lookup-penyaluran")]
    public IActionResult GetLookupPenyaluran(int idPlant, string menu, int? idModa)
    {
        if (!IsLoggedIn()) return Json(new { success = false, message = "Not authorized." });
        var list = new List<object>();
        string sql = "";
        try
        {
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            {
                DateTime plantDateTime = DateTime.Now;
                string sqlPlantTime = "EXEC dbo.GetPlantDateTime @IdPlant = @idPlant;";
                using (SqlCommand spCmd = new SqlCommand(sqlPlantTime, conn))
                {
                    spCmd.Parameters.Add("@IdPlant", SqlDbType.Int).Value = idPlant;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        plantDateTime = (DateTime)spResult;
                    }
                }
                if (menu == "PenimbunanPenyaluran")
                {
                    plantDateTime = plantDateTime.AddDays(-14);
                    int idModaParam = (idModa == null) ? -1 : Convert.ToInt32(idModa);
                    sql = @"
                    SELECT 
                        IdPenyaluran,
                        NomorPenyaluran
                    FROM Penyaluran WHERE IdPlant = @idPlant
                        AND IdModa = @IdModa
                        AND TanggalDibuat >= @plantDateTime 
                        AND TipePenyaluran = 'Konsinyasi'
                    ORDER BY TanggalDibuat DESC;";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPlant", idPlant);
                        cmd.Parameters.AddWithValue("@plantDateTime", plantDateTime);
                        cmd.Parameters.AddWithValue("@IdModa", idModaParam);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                list.Add(new {
                                    IdPenyaluran = r["IdPenyaluran"].ToString(),
                                    NomorPenyaluran = r["NomorPenyaluran"].ToString()
                                });
                            }
                        }
                    }
                }
                else
                {
                    plantDateTime = plantDateTime.AddDays(-3);
                    sql = @"
                    SELECT 
                        IdPenyaluran,
                        NomorPenyaluran
                    FROM Penyaluran WHERE IdPlant = @idPlant 
                        AND TanggalDibuat >= @plantDateTime
                    ORDER BY TanggalDibuat DESC;";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPlant", idPlant);
                        cmd.Parameters.AddWithValue("@plantDateTime", plantDateTime);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                list.Add(new {
                                    IdPenyaluran = r["IdPenyaluran"].ToString(),
                                    NomorPenyaluran = r["NomorPenyaluran"].ToString()
                                });
                            }
                        }
                    }
                }
                // using (SqlCommand cmd = new SqlCommand(sql, conn))
                // {
                //     cmd.Parameters.AddWithValue("@idPlant", idPlant);
                //     cmd.Parameters.AddWithValue("@plantDateTime", plantDateTime);
                //     using (SqlDataReader r = cmd.ExecuteReader())
                //     {
                //         while (r.Read())
                //         {
                //             list.Add(new {
                //                 IdPenyaluran = r["IdPenyaluran"].ToString(),
                //                 NomorPenyaluran = r["NomorPenyaluran"].ToString()
                //             });
                //         }
                //     }
                // }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Error fetching data Penyaluran");
        }
        return Json(list);
    }

    [HttpGet("get-dropdown/plant")]
    public IActionResult GetPlanDropdown(string? Menu = "HSSE")
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        List<DropdownResponse> plans = new List<DropdownResponse>();
        var currentUserLevel = CurrentUserLevel();
        var idRegion = CurrentUserInfo("Region");
        var idPosition = CurrentUserInfo("IdPosition");
        var idRole = CurrentUserInfo("Rule")?.ToString();
        var parameters = new Dictionary<string, object>();
        string sql = "";
        switch (currentUserLevel)
        {
            case "1" or "2" or "5" or "6" or "7":
                sql = @"SELECT DISTINCT MP.IdPlant as Value, CONCAT(Mp.Plant , ' - ', MP.Nama_Terminal) as Label" +
                      "  from MasterPlant MP " +
                      "   Join MappingPosition POS ON MP.IdPlant = POS.IdPlant " +
                    "WHERE POS.IdPosition = @IdPosition";
                if ((idRole == "12" || (idRole == "13" && Menu != "Penyaluran")) && Menu != "HSSE") 
                {
                    sql += " AND JenisPlant = 'STS'";
                }
                if (idPosition == null) return Json(plans);
                parameters.Add("@IdPosition", idPosition);
                break;
            case "4": // Region
                sql = @"SELECT DISTINCT MP.IdPlant as Value, CONCAT(Mp.Plant , ' - ', MP.Nama_Terminal) as Label" +
                      "  from MasterPlant MP " +
                      "   Join MappingPosition POS ON MP.IdPlant = POS.IdPlant " +
                      "WHERE POS.IdPosition = @IdPosition";
                if ((idRole == "12" || idRole == "13") && Menu != "HSSE") 
                {
                    sql += " AND JenisPlant = 'STS'";
                }
                if (idPosition == null) return Json(plans);
                parameters.Add("@IdPosition", idPosition);
                break;
            default:
                sql = @"SELECT DISTINCT MP.IdPlant as Value, CONCAT(Mp.Plant , ' - ', MP.Nama_Terminal) as Label" +
                      "  from MasterPlant MP ";
                break;
        }
        try
        {
            plans = DatabaseQueryHelper.ExecuteSelectListQuery<DropdownResponse>(
                sql,
                reader => new DropdownResponse
                {
                    Value = reader["Value"] != DBNull.Value ? Convert.ToInt32(reader["Value"]) : 0,
                    Label = reader["Label"]?.ToString() ?? ""
                }, 
                parameters
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ErrorResponseDto("Failed", StatusCodes.Status500InternalServerError);
        }
        return Json(plans);
    }

    [HttpGet("get-dropdown/penyaluran-to-penerimaan")]
    public IActionResult GetPenyaluranListToPenerimaan(int plantId = 0, int modaId = 0)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        List<DropdownResponse> plans = new List<DropdownResponse>();
        var parameters = new Dictionary<string, object>();
        string sql = "";
        DateTime plantTime = DatabaseQueryHelper.ExecuteSelectSingle<DateTime>(
            "EXEC dbo.GetPlantDateTime @IdPlant = @IdPlant",
            reader => {
                var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                if (val == null) return DateTime.Now;
                return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
            },
            new Dictionary<string, object> { { "@IdPlant", plantId } }
        );
        if (modaId == 4) // RTW
        {
            sql = @"
                SELECT 
                    Pn.IdPenyaluran AS Value, 
                    Pn.NomorPenyaluran AS Label
                FROM Penyaluran Pn
                JOIN MasterPlant MP 
                    ON MP.IdPlant = Pn.TujuanKonsinyasi
                WHERE Pn.IdModa = @ModaId
                AND MP.IdPlant = @PlantId
                AND NOT EXISTS (
                    SELECT 1
                    FROM Penerimaan P
                    WHERE P.IdPenyaluran = Pn.IdPenyaluran
                    AND P.IdPlant = MP.IdPlant
                )
                AND Pn.TanggalDibuat >= DATEADD(DAY, -7, @plantTime)
                AND Pn.NomorPenyaluran LIKE 'K-%'
                ORDER BY Pn.TanggalDibuat DESC;
            ";
        }
        else if (modaId == 3) // Truck
        {
            sql = @"
                SELECT 
                    Pn.IdPenyaluran AS Value, 
                    Pn.NomorPenyaluran AS Label
                FROM Penyaluran Pn
                JOIN MasterPlant MP 
                    ON MP.IdPlant = Pn.TujuanKonsinyasi
                WHERE Pn.IdModa = @ModaId
                AND MP.IdPlant = @PlantId
                AND Pn.TanggalDibuat >= DATEADD(DAY, -7, @plantTime)
                AND Pn.NomorPenyaluran LIKE 'K-%'                
                ORDER BY Pn.TanggalDibuat DESC;
            ";
        }
        else
        {
            sql = @"
                SELECT 
                    Pn.IdPenyaluran AS Value, 
                    Pn.NomorPenyaluran AS Label
                FROM Penyaluran Pn
                JOIN DetailPenyaluranPipa Dp 
                    ON Pn.NomorPenyaluran = Dp.NomorPenyaluran
                JOIN MasterPlant MP 
                    ON MP.IdPlant = Dp.TujuanKonsinyasi
                WHERE Pn.IdModa = @ModaId
                AND MP.IdPlant = @PlantId
                AND NOT EXISTS (
                    SELECT 1
                    FROM Penerimaan P
                    WHERE P.IdPenyaluran = Pn.IdPenyaluran
                    AND P.IdPlant = MP.IdPlant
                )
                AND Pn.TanggalDibuat >= DATEADD(DAY, -7, @plantTime)
                AND Pn.NomorPenyaluran LIKE 'K-%'
                ORDER BY Pn.TanggalDibuat DESC;
            ";
        }
        parameters.Add("@plantTime", plantTime);
        parameters.Add("@ModaId", modaId);
        parameters.Add("@PlantId", plantId);
        try
        {
            plans = DatabaseQueryHelper.ExecuteSelectListQuery<DropdownResponse>(
                sql,
                reader => new DropdownResponse
                {
                    Value = reader["Value"] != DBNull.Value ? Convert.ToInt32(reader["Value"]) : 0,
                    Label = reader["Label"]?.ToString() ?? ""
                },
                parameters
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ErrorResponseDto("Failed", StatusCodes.Status500InternalServerError);
        }
        return Json(plans);
    }

    [HttpGet("get-dropdown/penerimaan-to-penimbunan")]
    public IActionResult GetPenerimaanListToPenimbunan(int plantId = 0)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        List<DropdownResponse> results = new List<DropdownResponse>();
        var parameters = new Dictionary<string, object>();
        DateTime plantTime = DatabaseQueryHelper.ExecuteSelectSingle<DateTime>(
            "EXEC dbo.GetPlantDateTime @IdPlant = @IdPlant",
            reader => {
                var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                if (val == null) return DateTime.Now;
                return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
            },
            new Dictionary<string, object> { { "@IdPlant", plantId } }
        );
        string sql = @"
                SELECT 
                    IdPenerimaan AS Value, 
                    NomorPenerimaan AS Label
                FROM Penerimaan
                WHERE IdPlant = @PlantId
                ORDER BY TanggalSandar DESC;
            ";
        parameters.Add("@plantTime", plantTime);
        parameters.Add("@PlantId", plantId);
        try
        {
            results = DatabaseQueryHelper.ExecuteSelectListQuery<DropdownResponse>(
                sql,
                reader => new DropdownResponse
                {
                    Value = reader["Value"] != DBNull.Value ? Convert.ToInt32(reader["Value"]) : 0,
                    Label = reader["Label"]?.ToString() ?? ""
                },
                parameters
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ErrorResponseDto("Failed", StatusCodes.Status500InternalServerError);
        }
        return Json(results);
    }

    [HttpGet("subaktivitas-hasil-pemeriksaan/get-by-penimbunan")]
    public IActionResult SubAktivitasHasilPemeriksaanByPenimbunan(int idAktivitas, string? jenis = "BBM")
    {
        if (!IsLoggedIn())
            return Json(new
            {
                success = false,
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan."
            });
        try
        {
            var jenisUpper = (jenis ?? "BBM").ToUpper();
            string tableName = jenisUpper switch
            {
                "BBM" => "SubaktivitasHasilPemeriksaan",
                "LPG" => "SubaktivitasHasilPemeriksaanLPG",
                "BBM_STS" => "SubaktivitasHasilPemeriksaanSTSPnrBBM",
                "LPG_STS" => "SubaktivitasHasilPemeriksaanSTSLPG",
                "PIPA_BBM" => "SubAktivitasFormInputHasilPemeriksaanPipa",
                "PIPA_LPG" => "SubAktivitasFormInputHasilPemeriksaanPipa",
                "BBM_RTW" => "SubAktivitasFormInputHslPemeriksaanRTW",
                _ => "SubaktivitasHasilPemeriksaan"
            };
            bool isRtw = jenisUpper == "BBM_RTW";
            string extraSelectRtw = isRtw ? ", SHP.NamaKegiatan, CONCAT(MP.NoProduk, CONCAT(' - ', MP.NamaProduk)) AS LabelProduk, NULL AS Level, NULL AS Quantity, NULL AS Flowrate" : "";
            string extraJoinRtw = isRtw ? "JOIN MasterProduk MP ON SHP.Produk = MP.NoProduk" : "";
            string sqlData = $@"
            SELECT 
                SHP.Id, 
                SHP.TanggalJam, 
                SHP.Density, 
                SHP.Temperature, 
                SHP.Keterangan
                {extraSelectRtw}
            FROM Aktivitas A
            JOIN Penimbunan P ON A.No_Referensi = P.NomorPenimbunan
            JOIN Penerimaan PN ON P.IdPenerimaan = PN.IdPenerimaan
            JOIN {tableName} SHP ON PN.NomorPenerimaan = SHP.NoReferensi
            {extraJoinRtw}
            WHERE A.IdAktivitas = @IdAktivitas;";
            static bool HasColumn(SqlDataReader r, string name)
            {
                for (int i = 0; i < r.FieldCount; i++)
                    if (string.Equals(r.GetName(i), name, StringComparison.OrdinalIgnoreCase))
                        return true;
                return false;
            }
            List<SubAktivitasHasilPemeriksaanResponse> result = new();
            using SqlConnection conn = GetConnection("Db").OpenConnection();
            using SqlCommand cmd = new SqlCommand(sqlData, conn);
            cmd.CommandTimeout = 300;
            cmd.Parameters.Add("@IdAktivitas", SqlDbType.Int).Value = idAktivitas;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new SubAktivitasHasilPemeriksaanResponse
                    {
                        Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : null,
                        TanggalJam = reader["TanggalJam"] != DBNull.Value ? Convert.ToDateTime(reader["TanggalJam"]) : null,
                        Density = reader["Density"]?.ToString(),
                        Temperature = reader["Temperature"]?.ToString(),
                        Keterangan = reader["Keterangan"]?.ToString()
                    };
                    if (isRtw)
                    {
                        if (HasColumn(reader, "NamaKegiatan"))
                            item.NamaKegiatan = reader["NamaKegiatan"]?.ToString();
                        if (HasColumn(reader, "LabelProduk"))
                            item.LabelProduk = reader["LabelProduk"]?.ToString();
                        if (HasColumn(reader, "Level"))
                            item.Level = reader["Level"]?.ToString();
                        if (HasColumn(reader, "Quantity") && reader["Quantity"] != DBNull.Value)
                            item.Quantity = Convert.ToDecimal(reader["Quantity"]);
                        if (HasColumn(reader, "Flowrate") && reader["Flowrate"] != DBNull.Value)
                            item.Flowrate = Convert.ToDecimal(reader["Flowrate"]);
                    }
                    result.Add(item);
                }
            }
            return Json(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server");
        }
    }

    [HttpGet("subaktivitas-hasil-pemeriksaan/get-by-penyaluran")]
    public IActionResult SubAktivitasHasilPemeriksaanByPenyaluran(int idAktivitas, string? jenis = "BBM")
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." 
            };
            return Json(response);
        }
        try
        {
            string tableName = "";
            switch (jenis.ToUpper())
            {
                case "BBM":
                    tableName = "SubAktivitasHasilPemeriksaanPenyaluran";
                    break;
                case "LPG":
                    tableName = "SubAktivitasHasilPemeriksaanPenyaluranLPG";
                    break;
                case "BBM_STS":
                    tableName = "SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM";
                    break;
                case "LPG_STS":
                    tableName = "SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG";
                    break;
                case "PIPA_BBM":
                    tableName = "SubAktivitasHasilPemeriksaanPipa";
                    break;
            };
            string batchColumnSql = jenis.ToUpper() == "PIPA_BBM" 
                ? "SHP.NoBatch AS NomorBatch" 
                : "NULL AS NomorBatch";
            string sqlData = $@"
                SELECT
                    SHP.Id,
                    SHP.Tanggal,
                    SHP.Density,
                    SHP.Produk,
                    SHP.Temperature,
                    SHP.Keterangan,
                    {batchColumnSql},
                    SHP.Produk + ' - ' + MP.NamaProduk AS LabelProduk
                FROM Aktivitas A
                JOIN PenimbunanPenyaluran P ON A.No_Referensi = P.NomorPenimbunanPenyaluran
                JOIN Penyaluran PN ON P.NoPenyaluran = PN.NomorPenyaluran
                JOIN {tableName} SHP ON PN.NomorPenyaluran = SHP.NoReferensi
                LEFT JOIN MasterProduk MP ON SHP.Produk = MP.NoProduk
                WHERE A.IdAktivitas = @IdAktivitas";
            var result = new List<SubAktivitasHasilPemeriksaanResponse>();
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sqlData, conn))
            {
                cmd.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new SubAktivitasHasilPemeriksaanResponse
                        {
                            Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : null,
                            TanggalJam = reader["Tanggal"] != DBNull.Value ? Convert.ToDateTime(reader["Tanggal"]) : null,
                            LabelProduk = reader["LabelProduk"]?.ToString(),
                            Density = reader["Density"]?.ToString(),
                            Temperature = reader["Temperature"]?.ToString(),
                            Keterangan = reader["Keterangan"]?.ToString(),
                            NomorBatch = reader["NomorBatch"]?.ToString()
                        });
                    }
                }
            }
            return Json(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPut("wajib-upload-dokumen-penkon/update")]
    public IActionResult UpdateWajibUploadDokumen(int idProses, double r1Value, string? jenis = "BBM"){
        int idTemplateAktivitas = 0;     
        switch (jenis.ToUpper())
        {
            case "BBM":
                idTemplateAktivitas = 86;
                break;
            case "LPG":
                idTemplateAktivitas = 119;
                break;
        } 
        int isWajibUpload = r1Value >= -0.125 ? 0 : 1;
        string sqlData = @"UPDATE AktivitasDokumen set WajibUpload = @WajibUploadValue
                where IdProses = @IdProses and StatusUpload <> 'Uploaded' and IdTemplateAktivitasDokumen = @IdTemplateAktivitas ";
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                // Update Status
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@WajibUploadValue", isWajibUpload);
                    sqlCommand.Parameters.AddWithValue("@IdProses", idProses);
                    sqlCommand.Parameters.AddWithValue("@IdTemplateAktivitas", idTemplateAktivitas);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            var responseSuccess = new
            {
                success = true,
                message = "Dokumen berhasil diperbarui."
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("check_valid_status_aktivitas")]
    public IActionResult CheckIsStatusAktivitasValid(int idAktivitas, string originalStatus)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            var currentStatus = "";
            string sqlCekStatusAktivitas = @"SELECT StatusAktivitas from Aktivitas where IdAktivitas = @IdAktivitas";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlCekStatusAktivitas, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            currentStatus = dataReader["StatusAktivitas"]?.ToString() ?? "";
                        }
                    }
                }
            }
            if (currentStatus != originalStatus) 
            {
                return Json(new
                {
                    IsValid = false,
                    Message = "Status aktivitas telah diubah oleh pengguna lain. Silakan refresh halaman."
                });
            }
            return Json(new
            {
                IsValid = true,
                Message = "Success"
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("get_referensi_detail")]
    public IActionResult GetReferensiDetail(string? nomorReferensi = "", int? idProses = 0)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        if (string.IsNullOrWhiteSpace(nomorReferensi) && (idProses == null || idProses == 0))
        {
            return Json(new
            {
                success = false,
                message = CurrentLanguage == "en-US"
                    ? "Please provide Nomor Referensi or ID Proses."
                    : "Harap isi Nomor Referensi atau ID Proses."
            });
        }
        try
        {
            int varIdProses = 0;
            string varTipeProses = "";
            string varNamaJudul = "-";
            bool useNomorReferensi = !string.IsNullOrWhiteSpace(nomorReferensi);
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                // Step 1: Query yang disederhanakan dengan NOLOCK hint untuk performa
                string getInfoSql = useNomorReferensi
                    ? @"
                        SELECT TOP 1
                            p.TipeProses,
                            p.IdProses
                        FROM Proses p WITH (NOLOCK)
                        INNER JOIN Aktivitas a WITH (NOLOCK) ON a.IdProses = p.IdProses
                        WHERE p.IdReferensi = @nomorReferensi;
                    "
                    : @"
                        SELECT TOP 1
                            p.TipeProses,
                            p.IdProses
                        FROM Proses p WITH (NOLOCK)
                        INNER JOIN Aktivitas a WITH (NOLOCK) ON a.IdProses = p.IdProses
                        WHERE p.IdProses = @idProses;
                    ";
                using (SqlCommand cmdInfo = new SqlCommand(getInfoSql, sqlConnection))
                {
                    cmdInfo.CommandTimeout = 120; // Reduced timeout untuk query simple
                    cmdInfo.Parameters.AddWithValue("@nomorReferensi", nomorReferensi ?? "");
                    cmdInfo.Parameters.AddWithValue("@idProses", idProses ?? 0);
                    using (SqlDataReader reader = cmdInfo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            varIdProses = reader["IdProses"] != DBNull.Value ? Convert.ToInt32(reader["IdProses"]) : 0;
                            varTipeProses = reader["TipeProses"]?.ToString() ?? "";
                        }
                        else
                        {
                            // Tidak ada data ditemukan
                            return Json(new
                            {
                                success = false,
                                message = CurrentLanguage == "en-US"
                                    ? "Data not found."
                                    : "Data tidak ditemukan."
                            });
                        }
                    }
                }

                // Normalisasi tipe proses
                varTipeProses = varTipeProses switch
                {
                    "PenyaluranTruck" or "PenyaluranLPGTASNGS" => "Penyaluran",
                    "PenerimaanSTSBBM" or "PenerimaanSTSLPG" => "Penerimaan",
                    _ => varTipeProses
                };

                // Step 2: Query detail berdasarkan tipe proses
                string sqlGetPenerimaan = GetOptimizedQueryByType(varTipeProses, useNomorReferensi);
                using (SqlCommand sqlCommand = new SqlCommand(sqlGetPenerimaan, sqlConnection))
                {
                    sqlCommand.CommandTimeout = 120; // Timeout yang lebih reasonable
                    sqlCommand.Parameters.AddWithValue("@nomorReferensi", nomorReferensi ?? "");
                    sqlCommand.Parameters.AddWithValue("@IdProses", idProses ?? 0);
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            varNamaJudul = dataReader["KeteranganJudul"]?.ToString() ?? "-";
                        }
                    }
                }
            }
            return Json(new
            {
                success = true,
                namaJudul = varNamaJudul,
                tipeProses = varTipeProses,
                nomorReferensi = nomorReferensi,
                IdProses = idProses
            });
        }
        catch (SqlException sqlEx) when (sqlEx.Number == -2) // Timeout
        {
            return Json(new
            {
                success = false,
                message = CurrentLanguage == "en-US"
                    ? "Request timeout. Please try again later."
                    : "Waktu tunggu habis. Silakan coba lagi nanti."
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                message = CurrentLanguage == "en-US"
                    ? "An error occurred. Please contact administrator."
                    : "Terjadi kesalahan. Hubungi administrator."
            });
        }
    }

    private string GetOptimizedQueryByType(string tipeProses, bool useNomorReferensi)
    {
        return tipeProses switch
        {
            "Penerimaan" or "PenerimaanSTSBBM" or "PenerimaanSTSLPG" or "PenerimaanRTW" or "PenerimaanTruck" or "PenerimaanPipaRefinery" => $@"
            SELECT TOP 1
                'PENERIMAAN <span style=""color: red"">' + p.NomorPenerimaan + '</span>' +
                ', Produk : <span style=""color: red"">' + UPPER(COALESCE(mp.NamaProduk, '-')) + '</span>' +
                ', Moda : <span style=""color: red"">' + UPPER(COALESCE(mm.NamaModa, '-')) + '</span>' +
                CASE 
                    WHEN p.ModaTransportasi IN (1,2) THEN 
                        ', Dermaga : <span style=""color: red"">' +
                        UPPER(COALESCE(md.TBBM, '') + ' ' + COALESCE(md.Equipment_ID, '-')) + '</span>' +
                        ', Kapal : <span style=""color: red"">' + UPPER(COALESCE(p.NamaKapal, '-')) + '</span>'
                    WHEN p.ModaTransportasi IN (5,6) THEN 
                        ', ETA : <span style=""color: red"">' +
                        COALESCE(etaAgg.ETAList, '-') + '</span>'
                    ELSE ''
                END AS KeteranganJudul
            FROM Penerimaan p
            INNER JOIN Proses pr ON pr.IdReferensi = p.NomorPenerimaan
            INNER JOIN Aktivitas ak ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterProduk mp ON p.KodeProduk = mp.NoProduk
            LEFT JOIN MasterDermaga md ON p.IdDermaga = md.IdDermaga
            LEFT JOIN MasterModa mm ON p.ModaTransportasi = mm.IdModa
            LEFT JOIN Penyaluran pn ON p.IdPenyaluran = pn.IdPenyaluran
            OUTER APPLY (
                SELECT
                    STRING_AGG(
                        FORMAT(
                            COALESCE(NULLIF(a.ETA_Dinamis, ''), a.ETA),
                            'yyyy-MM-dd HH:mm:ss'
                        ),
                        ', '
                    ) AS ETAList
                FROM SubAktivitasAnakNilaiETCETAPipa a
                WHERE a.NoReferensi = COALESCE(NULLIF(pn.NomorPenyaluran, ''), p.NomorPenerimaan)
                AND COALESCE(NULLIF(a.ETA_Dinamis, ''), a.ETA) IS NOT NULL
                AND a.idPlantTujuan = p.IdPlant
            ) etaAgg
            {WhereBy("p.NomorPenerimaan", useNomorReferensi)};
            ",
            "Penyaluran" or "PenyaluranKonsinyasiSTSBBM" or "PenyaluranTruck" or "PenyaluranLPGTASNGS" or "PenyaluranKonsinyasiRTW" or
            "PenyaluranKonsinyasiSTSLPG" or "PenyaluranPipa" or "PenyaluranPipaLPG" or "PenyaluranSalesPipa" or "PenyaluranTasNgs" or "PenyaluranKonsinyasiTruck" or "PenyaluranKonsinyasiTruckTAS" or "PenyaluranPipaJarakDekat" => $@"
            SELECT TOP 1
                'PENYALURAN <span style=""color: red"">' + p.NomorPenyaluran + '</span>' +
                ', Plant : <span style=""color: red"">' + UPPER(ISNULL(mp.Nama_Terminal,'-')) + '</span>' +
                CASE
                    WHEN UPPER(ISNULL(p.TipePenyaluran,'')) = 'KONSINYASI'
                        THEN ', Jenis Produk : <span style=""color: red"">' + UPPER(ISNULL(mprod.NamaProduk,'-')) + '</span>'
                    ELSE ''
                END +
                CASE
                    WHEN UPPER(ISNULL(p.TipePenyaluran,'')) = 'SALES'
                        THEN ', Kategori : <span style=""color: red"">' + UPPER(ISNULL(p.KategoriPenyaluran,'-')) + '</span>'
                    ELSE ''
                END +
                ', Tipe : <span style=""color: red"">' + UPPER(ISNULL(p.TipePenyaluran,'-')) + '</span>' +
                CASE
                    WHEN UPPER(ISNULL(p.TipePenyaluran,'')) = 'SALES'
                        THEN ', Tujuan : <span style=""color: red"">' + UPPER(ISNULL(p.Tujuan,'-')) + '</span>'
                    WHEN UPPER(ISNULL(p.TipePenyaluran,'')) = 'KONSINYASI'
                        THEN ', Tujuan : <span style=""color: red"">' + UPPER(ISNULL(tu.Nama_Terminal,'-')) + '</span>'
                    ELSE ''
                END +
                CASE
                    WHEN UPPER(ISNULL(p.TipePenyaluran,'')) = 'SALES'
                        THEN ', No Polisi : <span style=""color: red"">' + UPPER(ISNULL(p.NomorPolisi,'-')) + '</span>'
                    WHEN UPPER(ISNULL(p.TipePenyaluran,'')) = 'KONSINYASI' AND ISNULL(p.IdModa,0) <> 5
                        THEN ', Kapal : <span style=""color: red"">' + UPPER(ISNULL(p.NamaKapal,'-')) + '</span>'
                    ELSE ''
                END AS KeteranganJudul
            FROM Penyaluran p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorPenyaluran
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterPlant mp WITH (NOLOCK) ON p.IdPlant = mp.IdPlant
            LEFT JOIN MasterPlant tu WITH (NOLOCK) ON p.TujuanKonsinyasi = tu.IdPlant
            LEFT JOIN MasterProduk mprod WITH (NOLOCK) ON p.JenisProduk = mprod.NoProduk
            {WhereBy("p.NomorPenyaluran", useNomorReferensi)};",
            "PenyimpananPenerimaanLPG" or "PenyimpananPenerimaanSTSBBM" or "PenyimpananPenerimaanLPGSTS" or "PenyimpananPenerimaanTruck" => $@"
            SELECT TOP 1
                'PROSES PENERIMAAN <span style=""color: red"">' + p.NomorPenimbunan + '</span>' +
                ', Tangki : <span style=""color: red"">' + UPPER(ISNULL(mt.NamaTerminal,'-')) + ' - ' +
                UPPER(ISNULL(mt.SeqTangki,'-')) + '</span>' AS KeteranganJudul
            FROM Penimbunan p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorPenimbunan
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterTangki mt WITH (NOLOCK) ON p.IdTangki = mt.Id
            {WhereBy("p.NomorPenimbunan", useNomorReferensi)};",
            "Penimbunan" or "PenyimpananPenerimaanPipa" or "PenyimpananPenerimaanPipaLPG" or "PenyimpananPenerimaanRTW" => $@"
            SELECT TOP 1
                'PROSES PENERIMAAN <span style=""color: red"">' + p.NomorPenimbunan + '</span>' +
                ', Tangki : <span style=""color: red"">' + UPPER(ISNULL(mt.NamaTerminal,'-')) + ' - ' + 
                UPPER(ISNULL(mt.SeqTangki,'-')) + '</span>' AS KeteranganJudul
            FROM Penimbunan p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorPenimbunan
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterTangki mt WITH (NOLOCK) ON p.IdTangki = mt.Id
            {WhereBy("p.NomorPenimbunan", useNomorReferensi)};",
            "PenimbunanPenyaluran" or "PenyimpananPenyaluranSalesSTSBBM" or "PenyimpananPenyaluranKonsinyasiSTSBBM" or
            "PenyimpananPenyaluranSalesSTSLPG" or "PenyimpananPenyaluranKonsinyasiSTSLPG" or "PenyimpananPenyaluranSalesPipa" or
            "PenyimpananPenyaluranKonsinyasiPipa" or "PenyimpananPenyaluranSalesRTW" or "PenyimpananPenyaluranKonsinyasiRTW" or "PenyimpananPenyaluranKonsinyasi" => $@"
            SELECT TOP 1
                'PROSES PENYALURAN <span style=""color: red"">' + p.NomorPenimbunanPenyaluran + '</span>' +
                ', Tangki : <span style=""color: red"">' + UPPER(ISNULL(mt.NamaTerminal,'-')) + ' - ' + 
                UPPER(ISNULL(mt.SeqTangki,'-')) + '</span>' AS KeteranganJudul
            FROM PenimbunanPenyaluran p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorPenimbunanPenyaluran
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterTangki mt WITH (NOLOCK) ON p.IdTangki = mt.Id
            {WhereBy("p.NomorPenimbunanPenyaluran", useNomorReferensi)};",
            "RencanaPenyaluran" or "RencanaPenyaluranLPG" or "RencanaPenyaluranPipa" => $@"
            SELECT TOP 1
                'RENCANA & REALISASI PENYALURAN <span style=""color: red"">' + p.NomorRencanaPenyaluran + '</span>' + 
                ', Plant : <span style=""color: red"">' + UPPER(ISNULL(mp.Nama_Terminal,'-')) + '</span>' + 
                ', Kategori : <span style=""color: red"">' + UPPER(ISNULL(p.KategoriPenyaluran,'-')) + '</span>' + 
                ', Tipe : <span style=""color: red"">' + UPPER(ISNULL(p.TipePenyaluran,'-')) + '</span>' + 
                ', Tujuan : <span style=""color: red"">' + UPPER(ISNULL(p.Tujuan,'-')) + '</span>' + 
                ', Moda : <span style=""color: red"">' + UPPER(ISNULL(mm.NamaModa,'-')) + '</span>' AS KeteranganJudul
            FROM RencanaPenyaluran p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorRencanaPenyaluran
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterPlant mp WITH (NOLOCK) ON p.IdPlant = mp.IdPlant 
            LEFT JOIN MasterModa mm WITH (NOLOCK) ON p.IdModa = mm.IdModa
            {WhereBy("p.NomorRencanaPenyaluran", useNomorReferensi)};",
            "PenimbunanPenyaluranLPG" => $@"
            SELECT TOP 1
                'PROSES PENYALURAN <span style=""color: red"">' + p.NomorPenimbunanPenyaluran + '</span>' +
                ', Plant : <span style=""color: red"">' + 
                    UPPER(ISNULL(mpId.Nama_Terminal, mpKode.Nama_Terminal)) + '</span>' +
                ', Tangki : <span style=""color: red"">' + 
                    UPPER(ISNULL(mt.NamaTerminal,'-')) + '</span>' +
                CASE 
                    WHEN UPPER(ISNULL(p.TipePenyaluran,'')) = 'KONSINYASI'
                        THEN ', Jenis Produk : <span style=""color: red"">' + 
                            UPPER(ISNULL(mprod.NamaProduk,'-')) + '</span>'
                    ELSE ''
                END +
                ', Tipe : <span style=""color: red"">' + UPPER(ISNULL(p.TipePenyaluran,'-')) + '</span>' AS KeteranganJudul
            FROM PenimbunanPenyaluran p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorPenimbunanPenyaluran
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterTangki mt WITH (NOLOCK) ON p.IdTangki = mt.Id
            LEFT JOIN MasterPlant mpId WITH (NOLOCK) ON mpId.IdPlant = TRY_CONVERT(INT, p.Plant)
            LEFT JOIN MasterPlant mpKode WITH (NOLOCK) ON mpKode.Plant = p.Plant
            LEFT JOIN Penyaluran pn WITH (NOLOCK) ON pn.NomorPenyaluran = p.NoPenyaluran
            LEFT JOIN MasterProduk mprod WITH (NOLOCK) ON mprod.NoProduk = pn.JenisProduk
            {WhereBy("p.NomorPenimbunanPenyaluran", useNomorReferensi)};",
            "SamplingLabTest" => $@"
            SELECT TOP 1
                'SAMPLING LAB TEST <span style=""color: red"">' + p.NomorSamplingLabTest + '</span>' + 
                ', Plant : <span style=""color: red"">' + UPPER(ISNULL(mp.Nama_Terminal,'-')) + '</span>' + 
                ', Kategori : <span style=""color: red"">' + UPPER(ISNULL(p.KategoriPenyaluran,'-')) + '</span>' + 
                ', Tipe : <span style=""color: red"">' + UPPER(ISNULL(p.TipePenyaluran,'-')) + '</span>' + 
                ', Tujuan : <span style=""color: red"">' + UPPER(ISNULL(p.Tujuan,'-')) + '</span>' + 
                ', Moda : <span style=""color: red"">' + UPPER(ISNULL(mm.NamaModa,'-')) + '</span>' + 
                ', No Polisi : <span style=""color: red"">' + UPPER(ISNULL(p.NomorPolisi,'-')) + '</span>' AS KeteranganJudul
            FROM SamplingLabTest p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorSamplingLabTest
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterPlant mp WITH (NOLOCK) ON p.IdPlant = mp.IdPlant 
            LEFT JOIN MasterModa mm WITH (NOLOCK) ON p.IdModa = mm.IdModa
            {WhereBy("p.NomorSamplingLabTest", useNomorReferensi)};",
            "ClosingStock" => $@"
            SELECT TOP 1
                'CLOSING STOCK <span style=""color: red"">' + p.NomorClosingStock + '</span>' + 
                ', Plant : <span style=""color: red"">' + UPPER(ISNULL(mp.Nama_Terminal,'-')) + '</span>' + 
                ', Tangki : <span style=""color: red"">' + UPPER(ISNULL(mt.NamaTerminal,'-')) + ' - ' + 
                UPPER(ISNULL(mt.SeqTangki,'-')) + '</span>' AS KeteranganJudul
            FROM ClosingStock p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorClosingStock
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterPlant mp WITH (NOLOCK) ON p.Plant = mp.IdPlant  
            LEFT JOIN MasterTangki mt WITH (NOLOCK) ON p.IdTangki = mt.Id
            {WhereBy("p.NomorClosingStock", useNomorReferensi)};",
            "ClosingStockSTSBBM" or "ClosingStockSTSLPG" => $@"
            SELECT TOP 1
                'CLOSING STOCK STS BBM <span style=""color: red"">' + p.NomorClosingStock + '</span>' +
                ', Plant : <span style=""color: red"">' +
                    UPPER(ISNULL(mpId.Nama_Terminal, mpKode.Nama_Terminal)) + '</span>' +
                ', Tangki : <span style=""color: red"">' +
                    UPPER(ISNULL(mt.NamaTerminal,'-')) + ' - ' + UPPER(ISNULL(mt.SeqTangki,'-')) + '</span>' AS KeteranganJudul
            FROM ClosingStock p WITH (NOLOCK)
            INNER JOIN Proses pr WITH (NOLOCK) ON pr.IdReferensi = p.NomorClosingStock
            INNER JOIN Aktivitas ak WITH (NOLOCK) ON ak.IdProses = pr.IdProses
            LEFT JOIN MasterPlant mpId WITH (NOLOCK) ON mpId.IdPlant = TRY_CONVERT(INT, p.Plant)
            LEFT JOIN MasterPlant mpKode WITH (NOLOCK) ON mpKode.Plant = p.Plant
            LEFT JOIN MasterTangki mt WITH (NOLOCK) ON p.IdTangki = mt.Id
            {WhereBy("p.NomorClosingStock", useNomorReferensi)};",
            _ => "SELECT TOP 1 '0' AS KeteranganJudul;"
        };
    }

    private static string WhereBy(string nomorColumn, bool useNomorReferensi)
    {
        return useNomorReferensi
            ? $"WHERE {nomorColumn} = @nomorReferensi"
            : "WHERE ak.IdProses = @IdProses";
    }

    // GET: api/LookUpList/get_ghk_header?nomorReferensi=GHK-xxxx
    [HttpGet("get_ghk_header")]
    public IActionResult GetGhkHeader(string? nomorReferensi)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Tidak diizinkan." });
        if (string.IsNullOrWhiteSpace(nomorReferensi))
            return Json(new { success = false, message = "Parameter nomorReferensi wajib diisi." });
        try
        {
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT
                    PlantName      = mp.Plant + ' - ' + COALESCE(mp.Nama_Terminal, ''),
                    Tanggal        = CONVERT(varchar(10),
                                            COALESCE(MIN(fi.tgltiba), ghk.TanggalDibuat),
                                            103),
                    TanggalGhk     = CONVERT(varchar(10), ghk.TanggalDibuat, 103),
                    TanggalGhkIso  = CONVERT(varchar(10), ghk.TanggalDibuat, 23)
                FROM dbo.GoodHouseKeeping ghk
                LEFT JOIN dbo.FormInputGoodHouseKeeping fi
                ON fi.NoReferensi = ghk.NomorGoodHouseKeeping
                LEFT JOIN dbo.MasterPlant mp
                ON mp.IdPlant = ghk.LookupPlant
                WHERE ghk.NomorGoodHouseKeeping = @NoRef
                GROUP BY mp.Plant, mp.Nama_Terminal, ghk.TanggalDibuat;", conn))
            {
                cmd.Parameters.AddWithValue("@NoRef", nomorReferensi);
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                        return Json(new { success = false, message = "Data tidak ditemukan." });
                    var plant   = rd["PlantName"]?.ToString() ?? "";
                    var tanggal = rd["Tanggal"]?.ToString() ?? "";
                    var tglGhk  = rd["TanggalGhk"]?.ToString() ?? "";
                    var tglIso  = rd["TanggalGhkIso"]?.ToString() ?? "";
                    var namaJudul = $"Plant: {plant}, Tanggal: {tanggal}";
                    return Json(new { success = true, plant, tanggal, namaJudul,
                                    tanggalGhk = tglGhk, tanggalGhkIso = tglIso });
                }
            }
        }
        catch (Exception ex)
        {
            Log("get_ghk_header error: " + ex.Message);
            return Json(new { success = false, message = "Terjadi kesalahan server." });
        }
    }
    // ghk
    [HttpGet("goodhousekeeping/get_tanggal_dibuat")]
    public IActionResult GetTanggalDibuatGhk(string? noReferensi)
    {
        if (!IsLoggedIn())
        {
            return Json(new { success = false, message = "Tidak diizinkan." });
        }
        if (string.IsNullOrWhiteSpace(noReferensi))
        {
            return Json(new { success = true, found = false, message = "NoReferensi kosong." });
        }
        try
        {
            string tanggalIso = null;
            string sql = @"SELECT TOP 1 CONVERT(varchar(10), TanggalDibuat, 23) AS TanggalDibuatIso
                        FROM GoodHouseKeeping
                        WHERE NomorGoodHouseKeeping = @NoReferensi";
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(noReferensi));
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        tanggalIso = rd["TanggalDibuatIso"]?.ToString();
                    }
                }
            }
            if (string.IsNullOrEmpty(tanggalIso))
                return Json(new { success = true, found = false, message = "Referensi tidak ditemukan." });
            return Json(new { success = true, found = true, tanggalDibuatIso = tanggalIso });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Server error.");
        }
    }

    // pov
    [HttpGet("get_pov_header")]
    public IActionResult GetPovHeader(string? nomorReferensi)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Tidak diizinkan." });
        if (string.IsNullOrWhiteSpace(nomorReferensi))
            return Json(new { success = false, message = "Parameter nomorReferensi wajib diisi." });
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(@"
                SELECT
                PlantDisplay =
                    CASE
                    WHEN NULLIF(mp.Nama_Terminal, '') IS NULL
                        THEN LTRIM(RTRIM(mp.Plant))
                    ELSE LTRIM(RTRIM(mp.Plant)) + ' - ' + LTRIM(RTRIM(mp.Nama_Terminal))
                    END,
                Tanggal = CONVERT(varchar(10), COALESCE(d.Tanggal, pov.TanggalDibuat), 103)
                FROM dbo.ProofOfVisit pov
                OUTER APPLY (
                SELECT TOP (1) fi.Tanggal
                FROM dbo.FormInputProofOfVisit fi
                WHERE fi.NoReferensi = pov.NomorProofOfVisit
                ORDER BY fi.lastUpdatedDate DESC, fi.id DESC
                ) AS d
                LEFT JOIN dbo.MasterPlant mp
                ON mp.IdPlant = pov.LookupPlant
                WHERE pov.NomorProofOfVisit = @NoRef;", conn))
            {
                cmd.Parameters.AddWithValue("@NoRef", nomorReferensi);
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                        return Json(new { success = false, message = "Data tidak ditemukan." });
                    var plantDisplay = rd["PlantDisplay"]?.ToString() ?? "-";
                    var tanggal      = rd["Tanggal"]?.ToString() ?? "-";

                    // Bentuk string judul persis yang diinginkan
                    var namaJudul = $"Plant: {plantDisplay}, Tanggal: {tanggal}";
                    return Json(new
                    {
                        success = true,
                        plantDisplay,
                        tanggal,
                        namaJudul
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Log("get_pov_header error: " + ex.Message);
            return Json(new { success = false, message = "Terjadi kesalahan server." });
        }
    }

    [HttpGet("get_penerimaan_detail")]
    public IActionResult GetPenerimaanDetail(string? nomorPenerimaan = "", int? idProses = 0)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            string sqlGetPenerimaan = @"select Top 1 mp.NamaProduk, IIF(sdk.namakapal is null, '', sdk.namakapal) as NamaKapal,
             IIF(p.NomorPengiriman is null, '', p.NomorPengiriman)  as NomorPengiriman,
             pr.NamaProses as NamaProses
                from Penerimaan p
            join Proses pr on pr.IdReferensi = p.NomorPenerimaan
            join Aktivitas ak on ak.IdProses = pr.idProses
            join SubaktivitasDataKapal sdk on sdk.NoReferensi = p.NomorPenerimaan
            join MasterProduk mp on mp.NoProduk = p.KodeProduk
            WHERE p.NomorPenerimaan = @NomorPenerimaan or ak.idProses = @IdProses";
            var namaProduk = "";
            var namaKapal = "";
            var nomorPengiriman = "";
            var namaProses = "";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlGetPenerimaan, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NomorPenerimaan", nomorPenerimaan);
                    sqlCommand.Parameters.AddWithValue("@IdProses", idProses);
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            namaProduk = dataReader["NamaProduk"].ToString() ?? "";
                            namaKapal = dataReader["NamaKapal"].ToString() ?? "";
                            nomorPengiriman = dataReader["NomorPengiriman"].ToString() ?? "";
                            namaProses = dataReader["NamaProses"].ToString() ?? "";
                        }
                    }
                }
            }
            return Json(new
            {
                namaProduk,
                namaKapal,
                nomorPengiriman,
                namaProses
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("get_tanggal_tiba_sandar")]
    public IActionResult GetTanggalTibaSandar(string NoReferensi, string Menu)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            string sqlGetTanggal = "";
            if (Menu == "Penerimaan") {
                sqlGetTanggal = @"select Top 1 p.NomorPenerimaan, p.TanggalSandar, sdk.tgltiba as TanggalTiba 
                    from Penerimaan p left join SubaktivitasDataKapal sdk on sdk.NoReferensi = p.NomorPenerimaan
                    where NomorPenerimaan = @NoReferensi";
            } else if (Menu == "Penyaluran") {
                sqlGetTanggal = @"select Top 1 p.NomorPenyaluran, p.TanggalSandar, sdk.TanggalTiba 
                    from Penyaluran p left join SubAktivitasInputDataKapal sdk on sdk.NoReferensi = p.NomorPenyaluran
                    where p.NomorPenyaluran = @NoReferensi";
            } else if (Menu == "PenerimaanRTW") {
                sqlGetTanggal = @"select Top 1 p.NomorPenerimaan, p.TanggalSandar, sdk.TanggalTiba as TanggalTiba 
                    from Penerimaan p left join SubAktivitasDataGerbongKetelRTW sdk on sdk.NoReferensi = p.NomorPenerimaan
                    where NomorPenerimaan = @NoReferensi";
            } else if (Menu == "PenerimaanTruck") {
                sqlGetTanggal = @"select Top 1 p.NomorPenerimaan, p.TanggalSandar, sdk.Tanggal as TanggalTiba 
                    from Penerimaan p left join SubAktivitasFormInputDataMobilTangki sdk on sdk.NoReferensi = p.NomorPenerimaan
                    where NomorPenerimaan = @NoReferensi";
            } 
            DateTime? tanggalTiba = DateTime.Now;
            DateTime? tanggalSandar = DateTime.Now;
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlGetTanggal, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", NoReferensi);
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            tanggalSandar = dataReader["TanggalSandar"] as DateTime?;
                            tanggalTiba = dataReader["TanggalTiba"] as DateTime?;
                        }
                    }
                }
            }
            return Json(new
            {
                tanggalTiba,
                tanggalSandar
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    private void GenerateLogbookPenerimaan(
        SqlConnection sqlConnection,
        string NoReferensi,
        string TableAgreement,
        string TableStartBongkar,
        string TableLogbook,
        string IdTemplate,
        string? tglStartCol = "tglStartBongkar"
    )
    {
        int idPenerimaan;
        string namaKapal;
        string kodeProduk;
        string noProduk;
        string namaProduk;
        DateTime etc;
        DateTime tglStartBongkar;
        using (var cmd = new SqlCommand(@"
            SELECT StatusAktivitas
            FROM Aktivitas
            WHERE No_Referensi = @NoReferensi
                AND TableAnak IN (@tableAgreement, @tableStartBongkar);", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            cmd.Parameters.AddWithValue("@tableAgreement", TableAgreement);
            cmd.Parameters.AddWithValue("@tableStartBongkar", TableStartBongkar);
            using (var rd = cmd.ExecuteReader())
            {
                if (!rd.Read()) return;
                while (rd.Read())
                {
                    string statusAktivitas = rd["StatusAktivitas"]?.ToString() ?? "";
                    if (statusAktivitas != "Completed" && statusAktivitas != "Completed Edit")
                        return;
                }
            }
        }
        using (var cmd = new SqlCommand(@"
            SELECT 
                p.IdPenerimaan,
                p.NamaKapal,
                p.KodeProduk,
                mp.NoProduk,
                mp.NamaProduk
            FROM Penerimaan p
            JOIN MasterProduk mp ON mp.NoProduk = p.KodeProduk
            WHERE p.NomorPenerimaan = @NoReferensi", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            using (var rd = cmd.ExecuteReader())
            {
                if (!rd.Read()) return;
                idPenerimaan = rd.GetInt32(0);
                namaKapal  = rd.IsDBNull(1) ? "" : rd.GetString(1);
                kodeProduk = rd.IsDBNull(2) ? "" : rd.GetString(2);
                noProduk   = rd.IsDBNull(3) ? "" : rd.GetString(3);
                namaProduk = rd.IsDBNull(4) ? "" : rd.GetString(4);
            }
        }
        using (var cmd = new SqlCommand($@"
            SELECT TOP 1 ETC
            FROM {TableAgreement}
            WHERE NoReferensi = @NoReferensi", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value) return;
            if (!DateTime.TryParse(result.ToString(), out etc)) return;
        }
        using (var cmd = new SqlCommand($@"
            SELECT TOP 1 {tglStartCol}
            FROM {TableStartBongkar}
            WHERE NoReferensi = @NoReferensi", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value) return;
            if (!DateTime.TryParse(result.ToString(), out tglStartBongkar)) return;
        }
        var listNomorPenimbunan = new List<string>();
        using (var cmd = new SqlCommand(@"
            SELECT NomorPenimbunan
            FROM Penimbunan
            WHERE IdPenerimaan = @IdPenerimaan", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@IdPenerimaan", idPenerimaan);
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    var np = rd.GetString(0);
                    if (!string.IsNullOrEmpty(np))
                        listNomorPenimbunan.Add(np);
                }
            }
        }
        if (listNomorPenimbunan.Count == 0)
            return;
        bool tanpaNamaKapal =
            TableAgreement == "SubAktivitasNilaiEstimasisFlowratePipa" ||
            TableAgreement == "SubAktivitasFormInputFlowrateRTW" ||
            TableAgreement == "SubAktivitasFormInputFlowrate";
        string namaKegiatan = tanpaNamaKapal
            ? $"Logbook Penerimaan Produk {noProduk} - {namaProduk}"
            : $"Logbook Penerimaan {namaKapal}, Produk {noProduk} - {namaProduk}";
        foreach (var nomorPenimbunan in listNomorPenimbunan)
        {
            int countLogbook;
            using (var cmd = new SqlCommand($@"
                SELECT COUNT(*)
                FROM {TableLogbook}
                WHERE NoReferensi = @NoReferensi", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", nomorPenimbunan);
                countLogbook = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
            }
            if (countLogbook > 0)
                continue;
            int idProses;
            int idAktivitas;
            using (var cmd = new SqlCommand($@"
                SELECT TOP 1 IdProses, IdAktivitas
                FROM Aktivitas
                WHERE No_Referensi = @NoRef
                AND IdTemplateAktivitas = {IdTemplate}", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoRef", nomorPenimbunan);
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                        continue;
                    idProses    = rd.GetInt32(0);
                    idAktivitas = rd.GetInt32(1);
                }
            }
            var listTanggal = new List<DateTime>();
            DateTime current = tglStartBongkar.AddHours(1);
            if (TableAgreement == "SubAktivitasFormInputFlowrate")
            {
                listTanggal.Add(current);
            }
            else
            {    
                while (current <= etc)
                {
                    listTanggal.Add(current);
                    current = current.AddHours(1);
                }
            }
            foreach (var tgl in listTanggal)
            {
                if (tanpaNamaKapal)
                {
                    using (var cmd = new SqlCommand($@"
                        INSERT INTO {TableLogbook}
                        (IdProses, IdAktifitas, NoReferensi, Produk, NamaKegiatan, TanggalJamSOP, userInput)
                        VALUES
                        (@IdProses, @IdAktivitas, @NoReferensi, @Produk, @NamaKegiatan, @TanggalJamSOP, 'SYSTEM')",
                        sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IdProses", idProses);
                        cmd.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                        cmd.Parameters.AddWithValue("@NoReferensi", nomorPenimbunan);
                        cmd.Parameters.AddWithValue("@Produk", kodeProduk);
                        cmd.Parameters.AddWithValue("@NamaKegiatan", namaKegiatan);
                        cmd.Parameters.AddWithValue("@TanggalJamSOP", tgl);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmd = new SqlCommand($@"
                        INSERT INTO {TableLogbook}
                        (IdProses, IdAktifitas, NoReferensi, Nama_Kapal, Produk, Nama_Kegiatan, TanggalJamSOP, userInput)
                        VALUES
                        (@IdProses, @IdAktivitas, @NoReferensi, @NamaKapal, @Produk, @NamaKegiatan, @TanggalJamSOP, 'SYSTEM')",
                        sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@IdProses", idProses);
                        cmd.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                        cmd.Parameters.AddWithValue("@NoReferensi", nomorPenimbunan);
                        cmd.Parameters.AddWithValue("@NamaKapal", namaKapal);
                        cmd.Parameters.AddWithValue("@Produk", kodeProduk);
                        cmd.Parameters.AddWithValue("@NamaKegiatan", namaKegiatan);
                        cmd.Parameters.AddWithValue("@TanggalJamSOP", tgl);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    private void GenerateHasilPemeriksaan(
        SqlConnection sqlConnection,
        string NoReferensi,
        string TableAgreement,
        string TableStartBongkar,
        string TablePemeriksaan,
        string IdTemplate,
        string? tglStartCol = "tglStartBongkar"
    )
    {
        int idPenerimaan;
        string namaKapal;
        string kodeProduk;
        string noProduk;
        string namaProduk;
        DateTime etc;
        DateTime tglStartBongkar;
        using (var cmd = new SqlCommand(@"
            SELECT StatusAktivitas
            FROM Aktivitas
            WHERE No_Referensi = @NoReferensi
                AND TableAnak IN (@tableAgreement, @tableStartBongkar);", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            cmd.Parameters.AddWithValue("@tableAgreement", TableAgreement);
            cmd.Parameters.AddWithValue("@tableStartBongkar", TableStartBongkar);
            using (var rd = cmd.ExecuteReader())
            {
                if (!rd.Read()) return;
                while (rd.Read())
                {
                    string statusAktivitas = rd["StatusAktivitas"]?.ToString() ?? "";
                    if (statusAktivitas != "Completed" && statusAktivitas != "Completed Edit")
                        return;
                }
            }
        }
        using (var cmd = new SqlCommand(@"
            SELECT 
                p.IdPenerimaan,
                p.NamaKapal,
                p.KodeProduk,
                mp.NoProduk,
                mp.NamaProduk
            FROM Penerimaan p
            JOIN MasterProduk mp ON mp.NoProduk = p.KodeProduk
            WHERE p.NomorPenerimaan = @NoReferensi", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            using (var rd = cmd.ExecuteReader())
            {
                if (!rd.Read()) return;
                idPenerimaan = rd.GetInt32(0);
                namaKapal  = rd.IsDBNull(1) ? "" : rd.GetString(1);
                kodeProduk = rd.IsDBNull(2) ? "" : rd.GetString(2);
                noProduk   = rd.IsDBNull(3) ? "" : rd.GetString(3);
                namaProduk = rd.IsDBNull(4) ? "" : rd.GetString(4);
            }
        }
        using (var cmd = new SqlCommand($@"
            SELECT TOP 1 ETC
            FROM {TableAgreement}
            WHERE NoReferensi = @NoReferensi", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value) return;
            if (!DateTime.TryParse(result.ToString(), out etc)) return;
        }
        using (var cmd = new SqlCommand($@"
            SELECT TOP 1 {tglStartCol}
            FROM {TableStartBongkar}
            WHERE NoReferensi = @NoReferensi", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value) return;
            if (!DateTime.TryParse(result.ToString(), out tglStartBongkar)) return;
        }
        int countData;
        using (var cmd = new SqlCommand($@"
            SELECT COUNT(*)
            FROM {TablePemeriksaan}
            WHERE NoReferensi = @NoReferensi", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
            countData = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
        }
        if (countData > 0)
            return;
        int idProses;
        int idAktivitas;
        using (var cmd = new SqlCommand($@"
            SELECT TOP 1 IdProses, IdAktivitas
            FROM Aktivitas
            WHERE No_Referensi = @NoRef
            AND IdTemplateAktivitas = {IdTemplate}", sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoRef", NoReferensi);
            using (var rd = cmd.ExecuteReader())
            {
                if (!rd.Read()) return;
                idProses    = rd.GetInt32(0);
                idAktivitas = rd.GetInt32(1);
            }
        }
        string namaKegiatan;
        bool tanpaNamaKapal =
            TablePemeriksaan == "SubAktivitasFormInputHasilPemeriksaanPipa" ||
            TablePemeriksaan == "SubAktivitasFormInputHslPemeriksaanRTW" ||
            TablePemeriksaan == "SubAktivitasFormInputHslPemeriksaan";
        if (tanpaNamaKapal)
            namaKegiatan = $"Monitoring Pembongkaran, Produk {noProduk} - {namaProduk}";
        else
            namaKegiatan = $"Monitoring Pembongkaran {namaKapal}, Produk {noProduk} - {namaProduk}";
        var listTanggal = new List<DateTime>();
        DateTime batasSatuJam = tglStartBongkar.AddHours(1);
        DateTime current = tglStartBongkar.AddMinutes(15);
        if (TablePemeriksaan == "SubAktivitasFormInputHslPemeriksaan")
        {
            listTanggal.Add(batasSatuJam);
        }
        else
        {
            while (current <= etc)
            {
                listTanggal.Add(current);
                if (current < batasSatuJam)
                    current = current.AddMinutes(15);
                else
                    current = current.AddHours(1);
            }
        }
        foreach (var tgl in listTanggal)
        {
            if (tanpaNamaKapal)
            {
                using (var cmd = new SqlCommand($@"
                    INSERT INTO {TablePemeriksaan}
                    (IdProses, IdAktifitas, NoReferensi, Produk, NamaKegiatan, TanggalJamSOP, userInput)
                    VALUES
                    (@IdProses, @IdAktivitas, @NoReferensi, @Produk, @NamaKegiatan, @TanggalJamSOP, 'SYSTEM')",
                    sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdProses", idProses);
                    cmd.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
                    cmd.Parameters.AddWithValue("@Produk", kodeProduk);
                    cmd.Parameters.AddWithValue("@NamaKegiatan", namaKegiatan);
                    cmd.Parameters.AddWithValue("@TanggalJamSOP", tgl);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                using (var cmd = new SqlCommand($@"
                    INSERT INTO {TablePemeriksaan}
                    (IdProses, IdAktifitas, NoReferensi, NamaKapal, Produk, NamaKegiatan, TanggalJamSOP, userInput)
                    VALUES
                    (@IdProses, @IdAktivitas, @NoReferensi, @NamaKapal, @Produk, @NamaKegiatan, @TanggalJamSOP, 'SYSTEM')",
                    sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdProses", idProses);
                    cmd.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
                    cmd.Parameters.AddWithValue("@NamaKapal", namaKapal);
                    cmd.Parameters.AddWithValue("@Produk", kodeProduk);
                    cmd.Parameters.AddWithValue("@NamaKegiatan", namaKegiatan);
                    cmd.Parameters.AddWithValue("@TanggalJamSOP", tgl);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    [HttpPost("generate_etc")]
    public IActionResult GenerateEtc([FromBody] UpdateByNoReferensi request)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            decimal nominasiValue = 0, Flowrate = 0, StrippingTime = 0;
            string tipeProduk = "", jenisPlant = "", sql = "", tableA = "SubaktivitasDataKapal", tableB = "SubaktivitasNilaiAgreement", tableC = "SubaktivitasStartBongkar";
            using var sqlConnection = GetConnection("Db").OpenConnection();
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 TipeProduk FROM MasterProduk WHERE NoProduk = (SELECT TOP 1 KodeProduk FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi)", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                tipeProduk = cmd.ExecuteScalar()?.ToString() ?? "";
            }
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 JenisPlant FROM MasterPlant WHERE IdPlant = (SELECT TOP 1 IdPlant FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi)", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                jenisPlant = cmd.ExecuteScalar()?.ToString() ?? "";
            }
            if (jenisPlant.ToUpper() == "STS" && tipeProduk.ToUpper() == "BBM") {
                tableA = "SubaktivitasDataKapalSTSPnrBBM";
                tableB = "SubaktivitasNilaiAgreementSTSPnrBBM";
                tableC = "SubaktivitasStartBongkarSTSPnrBBM";
            } else if (jenisPlant.ToUpper() == "STS" && tipeProduk.ToUpper() == "LPG") {
                tableA = "SubAktivitasDataKapalSTSLPG";
                tableB = "SubAktivitasNilaiAgreementSTSLPG";
                tableC = "SubAktivitasStartBongkarSTSLPG";
            } else if (tipeProduk.ToUpper() == "LPG") {
                tableA = "SubAktivitasDataKapalLPG";
                tableB = "SubAktivitasNilaiAgreementLPG";
                tableC = "SubAktivitasStartBongkarLPG";
            }
            sql = $@"SELECT 
                        A.nominasi,
                        B.Flowrate,
                        B.StrippingTime 
                    from {tableA} A
                    JOIN {tableB} B ON A.NoReferensi = B.NoReferensi
                    WHERE A.NoReferensi = @NoReferensi";
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                using(SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        nominasiValue = reader["nominasi"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["nominasi"]) 
                            : 0;
                        Flowrate = reader["Flowrate"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["Flowrate"]) 
                            : 0;
                        StrippingTime = reader["StrippingTime"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["StrippingTime"]) 
                            : 0;
                    }
                }
            }
            if (Flowrate != 0 && StrippingTime != 0) {
                decimal LamaPembongkaran = Math.Round((nominasiValue / Flowrate) + StrippingTime, 4);
                sql = $@"UPDATE {tableB} SET LamaPembongkaran = @LamaPembongkaran WHERE NoReferensi = @NoReferensi";
                using(SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LamaPembongkaran", LamaPembongkaran);
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                    sqlCommand.ExecuteNonQuery();
                }
                int jam = (int)Math.Floor(LamaPembongkaran);
                decimal totalMenitDesimal = (LamaPembongkaran - jam) * 60;
                int menit = (int)Math.Floor(totalMenitDesimal);
                decimal sisaDetikDesimal = (totalMenitDesimal - menit) * 60;
                int detik = (int)Math.Ceiling(sisaDetikDesimal);
                sql = $@"
                    UPDATE na
                    SET na.ETC = DATEADD(SECOND, @LamaDetik,
                                DATEADD(MINUTE, @LamaMenit,
                                DATEADD(HOUR, @LamaJam, sb.tglStartBongkar)))
                    FROM {tableB} na
                    JOIN {tableC} sb ON na.NoReferensi = sb.NoReferensi
                    WHERE na.NoReferensi = @NoReferensi AND sb.tglStartBongkar IS NOT NULL;
                ";
                using(SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LamaJam", jam);
                    sqlCommand.Parameters.AddWithValue("@LamaMenit", menit);
                    sqlCommand.Parameters.AddWithValue("@LamaDetik", detik);
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                    sqlCommand.ExecuteNonQuery();
                }
            } else {
                return Ok( new {
                    success = false,
                    message = "Gagal Generate Lama Pembongkaran dan ETC Nilai Agreement Karena Nilai Flowrate Kosong atau 0"
                });
            }
            if (tableA == "SubaktivitasDataKapal")
            {
                GenerateHasilPemeriksaan(sqlConnection, request.NoReferensi, tableB, tableC, "SubaktivitasHasilPemeriksaan", "13");
                GenerateLogbookPenerimaan(sqlConnection, request.NoReferensi, tableB, tableC, "SubAktivitasLogbookPenerimaan", "34");
            } 
            else if (tableA == "SubaktivitasDataKapalSTSPnrBBM")
            {
                GenerateHasilPemeriksaan(sqlConnection, request.NoReferensi, tableB, tableC, "SubaktivitasHasilPemeriksaanSTSPnrBBM", "199");
                GenerateLogbookPenerimaan(sqlConnection, request.NoReferensi, tableB, tableC, "SubAktivitasLogbookPenerimaanSTSPymBBM", "209");
            }
            else if (tableA == "SubAktivitasDataKapalSTSLPG")
            {
                GenerateHasilPemeriksaan(sqlConnection, request.NoReferensi, tableB, tableC, "SubAktivitasHasilPemeriksaanSTSLPG", "273");
                GenerateLogbookPenerimaan(sqlConnection, request.NoReferensi, tableB, tableC, "SubAktivitasLogbookPenerimaanSTSPymLPG", "250");
            }
            else if (tableA == "SubAktivitasDataKapalLPG")
            {
                GenerateHasilPemeriksaan(sqlConnection, request.NoReferensi, tableB, tableC, "SubAktivitasHasilPemeriksaanLPG", "140");
                GenerateLogbookPenerimaan(sqlConnection, request.NoReferensi, tableB, tableC, "SubAktivitasLogbookPenerimaanLPG", "148");
            }
            var responseSuccess = new
            {
                success = true,
                message = "Lama pembongkaran dan ETC berhasil diperbarui."
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("generate_etc_truck")]
    public IActionResult GenerateEtcTruck([FromBody] UpdateByNoReferensi request)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            decimal nominasiValue = 0, Flowrate = 0, StrippingTime = 0;
            using var sqlConnection = GetConnection("Db").OpenConnection();
            string sql = $@"SELECT 
                        A.Nominasi,
                        B.Flowrate,
                        B.StrippingTime 
                    from SubAktivitasFormInputDataMobilTangki A
                    JOIN SubAktivitasFormInputFlowrate B ON A.NoReferensi = B.NoReferensi
                    WHERE A.NoReferensi = @NoReferensi";
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                using(SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        nominasiValue = reader["Nominasi"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["Nominasi"]) 
                            : 0;
                        Flowrate = reader["Flowrate"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["Flowrate"]) 
                            : 0;
                        StrippingTime = reader["StrippingTime"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["StrippingTime"]) 
                            : 0;
                    }
                }
            }
            if (Flowrate != 0 && StrippingTime != 0) {
                decimal LamaPembongkaran = Math.Round((nominasiValue / Flowrate) + StrippingTime, 4);
                sql = $@"UPDATE SubAktivitasFormInputFlowrate SET LamaPembongkaran = @LamaPembongkaran WHERE NoReferensi = @NoReferensi";
                using(SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LamaPembongkaran", LamaPembongkaran);
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                    sqlCommand.ExecuteNonQuery();
                }
                int jam = (int)Math.Floor(LamaPembongkaran);
                decimal totalMenitDesimal = (LamaPembongkaran - jam) * 60;
                int menit = (int)Math.Floor(totalMenitDesimal);
                decimal sisaDetikDesimal = (totalMenitDesimal - menit) * 60;
                int detik = (int)Math.Ceiling(sisaDetikDesimal);
                sql = $@"
                    UPDATE na
                    SET na.ETC = DATEADD(SECOND, @LamaDetik,
                                DATEADD(MINUTE, @LamaMenit,
                                DATEADD(HOUR, @LamaJam, sb.Tanggal)))
                    FROM SubAktivitasFormInputFlowrate na
                    JOIN SubAktivitasFormInputDataStartPembongkaran sb ON na.NoReferensi = sb.NoReferensi
                    WHERE na.NoReferensi = @NoReferensi AND sb.Tanggal IS NOT NULL;
                ";
                using(SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LamaJam", jam);
                    sqlCommand.Parameters.AddWithValue("@LamaMenit", menit);
                    sqlCommand.Parameters.AddWithValue("@LamaDetik", detik);
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                    sqlCommand.ExecuteNonQuery();
                }
                GenerateLogbookPenerimaan(sqlConnection, request.NoReferensi, "SubAktivitasFormInputFlowrate", "SubAktivitasFormInputDataStartPembongkaran", "SubAktivitasFormInputLogbookPenerimaanTruck", "432", "Tanggal");
                GenerateHasilPemeriksaan(sqlConnection, request.NoReferensi, "SubAktivitasFormInputFlowrate", "SubAktivitasFormInputDataStartPembongkaran", "SubAktivitasFormInputHslPemeriksaan", "426", "Tanggal");
            } else {
                return Ok( new {
                    success = false,
                    message = "Gagal Generate Lama Pembongkaran dan ETC Karena Nilai Flowrate Kosong atau 0"
                });
            }
            var responseSuccess = new
            {
                success = true,
                message = "Lama pembongkaran dan ETC berhasil diperbarui."
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("generate_etc_rtw")]
    public IActionResult GenerateEtcRtw([FromBody] UpdateByNoReferensi request)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            decimal nominasiValue = 0, Flowrate = 0, StrippingTime = 0;
            using var sqlConnection = GetConnection("Db").OpenConnection();
            string sql = $@"SELECT 
                        A.nominasi,
                        B.Flowrate,
                        B.StrippingTime 
                    from SubAktivitasDataGerbongKetelRTW A
                    JOIN SubAktivitasFormInputFlowrateRTW B ON A.NoReferensi = B.NoReferensi
                    WHERE A.NoReferensi = @NoReferensi";
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                using(SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        nominasiValue = reader["nominasi"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["nominasi"]) 
                            : 0;
                        Flowrate = reader["Flowrate"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["Flowrate"]) 
                            : 0;
                        StrippingTime = reader["StrippingTime"] != DBNull.Value 
                            ? Convert.ToDecimal(reader["StrippingTime"]) 
                            : 0;
                    }
                }
            }
            if (Flowrate != 0 && StrippingTime != 0) {
                decimal LamaPembongkaran = Math.Round((nominasiValue / Flowrate) + StrippingTime, 4);
                sql = $@"UPDATE SubAktivitasFormInputFlowrateRTW SET LamaPembongkaran = @LamaPembongkaran WHERE NoReferensi = @NoReferensi";
                using(SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LamaPembongkaran", LamaPembongkaran);
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                    sqlCommand.ExecuteNonQuery();
                }
                int jam = (int)Math.Floor(LamaPembongkaran);
                decimal totalMenitDesimal = (LamaPembongkaran - jam) * 60;
                int menit = (int)Math.Floor(totalMenitDesimal);
                decimal sisaDetikDesimal = (totalMenitDesimal - menit) * 60;
                int detik = (int)Math.Ceiling(sisaDetikDesimal);
                sql = $@"
                    UPDATE na
                    SET na.ETC = DATEADD(SECOND, @LamaDetik,
                                DATEADD(MINUTE, @LamaMenit,
                                DATEADD(HOUR, @LamaJam, sb.Tanggal)))
                    FROM SubAktivitasFormInputFlowrateRTW na
                    JOIN SubAktivitasDataStartPembongkaranRTW sb ON na.NoReferensi = sb.NoReferensi
                    WHERE na.NoReferensi = @NoReferensi AND sb.Tanggal IS NOT NULL;
                ";
                using(SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LamaJam", jam);
                    sqlCommand.Parameters.AddWithValue("@LamaMenit", menit);
                    sqlCommand.Parameters.AddWithValue("@LamaDetik", detik);
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", request.NoReferensi);
                    sqlCommand.ExecuteNonQuery();
                }
                GenerateLogbookPenerimaan(sqlConnection, request.NoReferensi, "SubAktivitasFormInputFlowrateRTW", "SubAktivitasDataStartPembongkaranRTW", "SubAktivitasFormInputLogbookPenerimaanRTW", "394", "Tanggal");
                GenerateHasilPemeriksaan(sqlConnection, request.NoReferensi, "SubAktivitasFormInputFlowrateRTW", "SubAktivitasDataStartPembongkaranRTW", "SubAktivitasFormInputHslPemeriksaanRTW", "378", "Tanggal");
            } else {
                return Ok( new {
                    success = false,
                    message = "Gagal Generate Lama Pembongkaran dan ETC Karena Nilai Flowrate Kosong atau 0"
                });
            }
            var responseSuccess = new
            {
                success = true,
                message = "Lama pembongkaran dan ETC berhasil diperbarui."
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("generate_etc_pipa")]
    public IActionResult GenerateEtcPipa(string noReferensi)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            var query = @"
                DECLARE @LamaPembongkaran DECIMAL(18,2);
                DECLARE @NomorPenerimaan VARCHAR(50) = @InputNomorPenerimaan;
                SELECT
                    @LamaPembongkaran = CASE
                        WHEN TRY_CAST(SEF.Flowrate AS DECIMAL(18,4)) IS NULL
                            OR TRY_CAST(SEF.Flowrate AS DECIMAL(18,4)) = 0 THEN NULL
                        ELSE ROUND(
                                (
                                    ISNULL(TRY_CAST(SEF.Nominasi AS DECIMAL(18,4)), 0) /
                                    TRY_CAST(SEF.Flowrate AS DECIMAL(18,4))
                                ), 4
                            )
                    END
                FROM Penerimaan PN
                JOIN SubAktivitasDataStartPembongkaranPipa SDP ON PN.NomorPenerimaan = SDP.NoReferensi
                JOIN SubAktivitasNilaiEstimasisFlowratePipa SEF ON PN.NomorPenerimaan = SEF.NoReferensi
                WHERE PN.NomorPenerimaan = @NomorPenerimaan;
                UPDATE SubAktivitasNilaiEstimasisFlowratePipa
                SET LamaPembongkaran = @LamaPembongkaran,
                    ETC = (
                        SELECT
                            CASE
                                WHEN @LamaPembongkaran IS NULL THEN NULL
                                ELSE DATEADD(Minute , CAST(@LamaPembongkaran * 60 AS BIGINT), SDP.tglStartBongkar)
                            END AS ETC
                        FROM SubAktivitasDataStartPembongkaranPipa SDP
                        WHERE SDP.NoReferensi = @NomorPenerimaan
                    )
                WHERE NoReferensi = @NomorPenerimaan;
                ";
            using var sqlConnection = GetConnection("Db").OpenConnection();
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@InputNomorPenerimaan", noReferensi);
                sqlCommand.ExecuteNonQuery();
            }
            int idModa = 0;
            bool isRefinery = false;
            using (var cmd = new SqlCommand(@"
                SELECT 
                    ModaTransportasi,
                    Refinery
                FROM Penerimaan 
                WHERE NomorPenerimaan = @NoReferensi", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", noReferensi);
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read()) {
                        idModa = Convert.ToInt32(rd.GetString(0));
                        isRefinery = rd.GetBoolean(1);
                    }
                }
            }
            if (idModa == 6)
            {
                GenerateLogbookPenerimaan(sqlConnection, noReferensi, "SubAktivitasNilaiEstimasisFlowratePipa", "SubAktivitasDataStartPembongkaranPipa", "SubAktivitasFormInputLogbookPenerimaanPipa", "361");
            }
            else
            {
                GenerateLogbookPenerimaan(sqlConnection, noReferensi, "SubAktivitasNilaiEstimasisFlowratePipa", "SubAktivitasDataStartPembongkaranPipa", "SubAktivitasFormInputLogbookPenerimaanPipa", "325");
            }
            if (isRefinery && idModa == 5)
            {
                GenerateHasilPemeriksaan(sqlConnection, noReferensi, "SubAktivitasNilaiEstimasisFlowratePipa", "SubAktivitasDataStartPembongkaranPipa", "SubAktivitasFormInputHasilPemeriksaanPipa", "465");
            }
            else 
            {
                GenerateHasilPemeriksaan(sqlConnection, noReferensi, "SubAktivitasNilaiEstimasisFlowratePipa", "SubAktivitasDataStartPembongkaranPipa", "SubAktivitasFormInputHasilPemeriksaanPipa", "312");
            }
            var responseSuccess = new
            {
                success = true,
                message = "Lama pembongkaran dan ETC berhasil diperbarui."
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("generate_nomor_penerimaan")]
    public IActionResult generate_nomor_penerimaan(string kodeProduk = "", int idPlant = 0)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." 
            };
            return Json(response);
        }
        string sqlData = @"EXEC GenerateNomorReferensi @IdPlant, @KodeProduk";
        string noReferensi = "";
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdPlant", idPlant);
                    sqlCommand.Parameters.AddWithValue("@KodeProduk", kodeProduk); // ← 🔧 Tambah titik koma di sini
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            noReferensi = reader["NomorReferensi"]?.ToString() ?? "";
                        }
                    }
                }
            }
            var responseSuccess = new
            {
                success = true,
                nomorReferensi = noReferensi
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("get_status_aktivitas")]
    public IActionResult get_status_aktivitas(int idAktivitas)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." 
            };
            return Json(response);
        }
        string sqlData = @"Select Top 1 StatusAktivitas from Aktivitas Where IdAktivitas = @IdAktivitas";
        string statusAktivitas = "";
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            statusAktivitas = reader["StatusAktivitas"]?.ToString() ?? "";
                        }
                    }
                }
            }
            var responseSuccess = new
            {
                success = true,
                statusAktivitas = statusAktivitas
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("check_iseditable_aktivitas_form")]
    public IActionResult CheckEditableAktivitasForm(int idAktivitas)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." 
            };
            return Json(response);
        }
        string currentUser = CurrentUserLevel();
        string idPos = CurrentUserInfo("IdPosition")?.ToString();
        string sqlData = @"EXEC CheckIsEditableAktivitasForm_ByAktivitasId @IdAktivitas";
        string tableRef = "", colPlant = "";
        var isEditable = true;
        var countRole = 0;
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isEditable = reader["IsEditable"] != DBNull.Value && Convert.ToBoolean(reader["IsEditable"]);
                        }
                    }
                }
                sqlData = "SELECT TipeProses FROM Aktivitas WHERE IdAktivitas = @IdAktivitas";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tableRef = reader["TipeProses"]?.ToString() ?? "";
                        }
                    }
                }
                switch (tableRef)
                {
                    case "PenyaluranTruck" or "PenyaluranLPGTASNGS" or "PenyaluranKonsinyasiSTSBBM" or "Penyaluran":
                        tableRef = "Penyaluran";
                        colPlant = "IdPlant";
                        break;
                    case "PenerimaanSTSBBM" or "PenerimaanSTSLPG" or "Penerimaan" or "PenerimaanRTW":
                        tableRef = "Penerimaan";
                        colPlant = "IdPlant";
                        break;
                    case "PenyimpananPenerimaanLPG" or "PenyimpananPenerimaanSTSBBM" or "PenyimpananPenerimaanLPGSTS" or "Penimbunan":
                        tableRef = "Penimbunan";
                        colPlant = "Plant";
                        break;
                    case "PenimbunanPenyaluran" or "PenimbunanPenyaluranLPG" or "PenyimpananPenyaluranSalesSTSBBM" or "PenyimpananPenyaluranKonsinyasiSTSBBM" or "PenyimpananPenyaluranSalesSTSLPG" or "PenyimpananPenyaluranKonsinyasiSTSLPG":
                        tableRef = "PenimbunanPenyaluran";
                        colPlant = "Plant";
                        break;
                    case "RencanaPenyaluran" or "RencanaPenyaluranLPG":
                        tableRef = "RencanaPenyaluran";
                        colPlant = "IdPlant";
                        break;
                    case "SamplingLabTest":
                        colPlant = "IdPlant";
                        break;
                    case "ClosingStock":
                        colPlant = "Plant";
                        break;
                }
            }
            if (currentUser != "-1")
            {
                var idPic = CurrentUserInfo("Rule");
                if (idPic == null)
                {
                    return Json(new
                    {
                        success = true,
                        isEditable = false
                    });
                }
                string sqlCekRole = @"WITH SplitValues AS (
                        SELECT
                            A.IdTemplateAktivitas,
                            TRIM(value) AS IdPIC,
                            A.IdAktivitas
                        FROM Aktivitas A
                                JOIN TemplateAktivitas TA ON A.IdTemplateAktivitas = TA.IdTemplateAktivitas
                                CROSS APPLY STRING_SPLIT(TA.IdPIC, ',')
                    )
                    SELECT COUNT(DISTINCT IdTemplateAktivitas) AS JumlahAktivitas
                    FROM SplitValues
                    WHERE IdPIC = @IdPIc and IdAktivitas = @IdAktivitas";
                using (SqlConnection sqlConnectionRole = GetConnection("Db").OpenConnection())
                {
                    using (SqlCommand sqlCommandRole = new SqlCommand(sqlCekRole, sqlConnectionRole))
                    {
                        sqlCommandRole.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                        sqlCommandRole.Parameters.AddWithValue("@IdPic", idPic);
                        using (SqlDataReader readerRole = sqlCommandRole.ExecuteReader())
                        {
                            if (readerRole.Read())
                            {
                                countRole = readerRole["JumlahAktivitas"] != DBNull.Value ? Convert.ToInt32(readerRole["JumlahAktivitas"]) : 0;
                            }
                        }
                    }
                }
                if (countRole < 1)
                {
                    isEditable = false;
                }
            }
            if (currentUser == "3")
            {
                isEditable = false;
            }
            else if (currentUser == "6")
            {
                if (string.IsNullOrEmpty(idPos))
                {
                    return Json(new
                    {
                        success = true,
                        isEditable = false
                    });
                }
                sqlData = $@"SELECT COUNT(*) AS JumlahSesuai
                            FROM Aktivitas a
                            JOIN {tableRef} p ON a.No_Referensi = p.Nomor{tableRef}
                            JOIN MasterPlant mp ON p.{colPlant} = mp.IdPlant
                            WHERE a.IdAktivitas = @IdAktivitas
                            AND mp.JenisPlant = 'STS'
                            AND p.{colPlant} IN (
                                SELECT IdPlant 
                                FROM MappingPosition 
                                WHERE IdPosition = @IdPosition
                            );
                            ";
                int plantCount = 0;
                using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                        sqlCommand.Parameters.AddWithValue("@IdPosition", idPos);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                plantCount = reader["JumlahSesuai"] != DBNull.Value ? Convert.ToInt32(reader["JumlahSesuai"]) : 0;
                            }
                        }
                    }
                }
                if (plantCount <= 0)
                {
                    var idTemplateProses = 0;
                    var acceptProcessListUser6 = new List<int> { 22, 23, 25, 48, 49, 50, 76, 77, 78, 79, 80, 81 };
                    sqlData = @"SELECT P.IdTemplateProses
                        from Aktivitas A
                    JOIN dbo.Proses P on A.IdProses = P.IdProses
                    WHERE A.IdAktivitas = @IdAktivitas";
                    using (SqlConnection sqlConnectionUser6 = GetConnection("Db").OpenConnection())
                    {
                        using (SqlCommand sqlCommandUser6 = new SqlCommand(sqlData, sqlConnectionUser6))
                        {
                            sqlCommandUser6.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                            using (SqlDataReader readerUser6 = sqlCommandUser6.ExecuteReader())
                            {
                                if (readerUser6.Read())
                                {
                                    idTemplateProses = readerUser6["IdTemplateProses"] != DBNull.Value ? Convert.ToInt32(readerUser6["IdTemplateProses"]) : 0;
                                }
                            }
                        }
                    }
                    if (!acceptProcessListUser6.Contains(idTemplateProses))
                    {
                        isEditable = false;
                    }
                }
            }
            var responseSuccess = new
            {
                success = true,
                isEditable = isEditable
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("update_status_aktivitas")]
    public async Task<IActionResult> UpdateStatusAktivitas(int idAktivitas, string statusAktivitas)
    {
        if (!IsLoggedIn())
        {
            throw new LogErrorException("Unauthorized access", StatusCodes.Status401Unauthorized , idAktivitas: idAktivitas);
        }
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            "UPDATE Aktivitas SET StatusAktivitas = @StatusAktivitas WHERE IdAktivitas = @IdAktivitas", 
            new Dictionary<string, object> { 
                { "@StatusAktivitas", statusAktivitas },
                { "@IdAktivitas", idAktivitas }
            },
            idAktivitas: idAktivitas
        );
        await UpdateStatusProsesByIdAktivitas(idAktivitas);
        await AddLogAktivitas(idAktivitas, statusAktivitas);
        await UpdateTanggalAktivitas(idAktivitas);
        return Ok( new
        {
            success = true,
            message = "Status aktivitas berhasil diperbarui."
        });
    }   

    [HttpPost("update_status_aktivitas-v2")]
    public async Task<IActionResult> UpdateStatusAktivitasV2([FromBody] UpdateStatusAktivitasRequest request)
    {
        if (!IsLoggedIn())
        {
            throw new LogErrorException("Unauthorized access", StatusCodes.Status401Unauthorized , idAktivitas: request.IdAktivitas);
        }
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            "UPDATE Aktivitas SET StatusAktivitas = @StatusAktivitas WHERE IdAktivitas = @IdAktivitas", 
            new Dictionary<string, object> { 
                { "@StatusAktivitas", request.StatusAktivitas },
                { "@IdAktivitas", request.IdAktivitas }
            },
            idAktivitas: request.IdAktivitas
        );
        await UpdateStatusProsesByIdAktivitas(request.IdAktivitas);
        await AddLogAktivitas(request.IdAktivitas, request.StatusAktivitas, request.Catatan);
        await UpdateTanggalAktivitas(request.IdAktivitas);
        return Ok( new
        {
            success = true,
            message = "Status aktivitas berhasil diperbarui."
        });
    }   

    [HttpPost("UploadAktivitasDokumen")]
    public async Task<IActionResult> UploadAktivitasDokumen([FromForm] UploadAktivitasDokumenRequest data) {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        try {
            int count = 0;
            string IdAktivitasDokumen = data.IdAktivitasDokumen;
            var files = data.files ?? new List<IFormFile>();
            var deletedIds = data.DeletedIds ?? new List<string>();
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection()) {
                string sqlData = "SELECT StatusAktivitas FROM Aktivitas WHERE IdAktivitas = (SELECT TOP 1 IdAktivitas FROM AktivitasDokumen WHERE IdAktivitasDokumen = @IdAktivitasDokumen);";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitasDokumen", EncodeForXSS(IdAktivitasDokumen));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                        if (reader.Read()) {
                            string statusAktivitas = reader["StatusAktivitas"]?.ToString() ?? "";
                            if (statusAktivitas == "Completed Edit") {
                                return Ok(new { success = false, message = "Aktivitas telah Completed Edit dan tidak dapat diedit lagi." });
                            }
                        }
                    }
                }
                sqlData = "SELECT COUNT(*) FROM AktivitasDokumenDetail WHERE IdAktivitasDokumen = @IdAktivitasDokumen";
                using (SqlCommand cmd = new SqlCommand(sqlData, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdAktivitasDokumen", IdAktivitasDokumen);
                    count = (int)cmd.ExecuteScalar();
                }
                if ((files.Count == 0 && deletedIds.Count >= count) || (files.Count == 0 && count == 0)) {
                    return BadRequest("Dokumen tidak boleh kosong.");
                }
                DateTime plantDateTime = DateTime.Now;
                string sqlPlantTime = "EXEC dbo.GetPlantDateTime @NomorReferensi = @NoReferensi;";
                using (SqlCommand spCmd = new SqlCommand(sqlPlantTime, sqlConnection))
                {
                    spCmd.Parameters.Add("@NoReferensi", SqlDbType.VarChar).Value = data.NoReferensi;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        plantDateTime = (DateTime)spResult;
                    }
                }
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string uniqueFileName = await UploadDokumenToAzureBlob(file, "ActivityDocument");
                        string insertFileSql = @"
                            INSERT INTO AktivitasDokumenDetail (IdAktivitasDokumen, FileName, DiunggahOleh, TanggalDiunggah)
                            VALUES (@IdAktivitasDokumen, @FileName, @DiunggahOleh, @TanggalDiunggah);";
                        using (SqlCommand cmdFile = new SqlCommand(insertFileSql, sqlConnection))
                        {
                            cmdFile.Parameters.AddWithValue("@IdAktivitasDokumen", IdAktivitasDokumen);
                            cmdFile.Parameters.AddWithValue("@FileName", uniqueFileName);
                            cmdFile.Parameters.AddWithValue("@DiunggahOleh", CurrentUserName());
                            cmdFile.Parameters.AddWithValue("@TanggalDiunggah", plantDateTime);
                            cmdFile.ExecuteNonQuery();
                        }
                    }
                }
                foreach (var delId in deletedIds)
                {
                    string deleteSQL = "DELETE FROM AktivitasDokumenDetail WHERE id = @id;";
                    using (SqlCommand cmdFile = new SqlCommand(deleteSQL, sqlConnection))
                    {
                        cmdFile.Parameters.AddWithValue("@id", delId);
                        cmdFile.ExecuteNonQuery();
                    }
                }
                sqlData = "UPDATE AktivitasDokumen SET StatusUpload = 'Uploaded', DiunggahOleh=  @DiunggahOleh, TanggalUpload = @TanggalUpload, DiperbaruiOleh = @DiperbaruiOleh, TanggalDiperbarui = @TanggalDiperbarui WHERE IdAktivitasDokumen = @IdAktivitasDokumen;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@DiunggahOleh", EncodeForXSS(CurrentUserName()));
                    sqlCommand.Parameters.AddWithValue("@TanggalUpload", plantDateTime);
                    sqlCommand.Parameters.AddWithValue("@DiperbaruiOleh", EncodeForXSS(CurrentUserName()));
                    sqlCommand.Parameters.AddWithValue("@TanggalDiperbarui", plantDateTime);
                    sqlCommand.Parameters.AddWithValue("@IdAktivitasDokumen", EncodeForXSS(IdAktivitasDokumen));
                    sqlCommand.ExecuteNonQuery();
                }
                sqlData = "SELECT COUNT(*) FROM AktivitasDokumen WHERE StatusUpload <> 'Uploaded' AND WajibUpload = 1 AND IdAktivitas = @IdAktivitas;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", EncodeForXSS(data.IdAktivitas));
                    count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
            }
            return Ok(new { success = true, message = "Berhasil Upload Dokumen.", NotUploadedCount = count });
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetTanggalDibuatCRS")]
    public IActionResult GetTanggalDibuatCRS(string? noReferensi)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        if (string.IsNullOrWhiteSpace(noReferensi))
        {
            return BadRequest(new { success = false, message = "Nomor Referensi is required." });
        }
        try
        {
            DateTime? tanggalDibuat = null;
            string sql = "SELECT TOP 1 TanggalDibuat FROM ControlRutinSecurity WHERE NomorCRS = @NoReferensi";
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", noReferensi);
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    tanggalDibuat = Convert.ToDateTime(result);
                }
            }
            if (tanggalDibuat.HasValue)
            {
                // Return the date in UTC format for easy parsing in JavaScript
                return Ok(new { success = true, tanggalDibuat = tanggalDibuat.Value.ToUniversalTime() });
            }
            else
            {
                return NotFound(new { success = false, message = "Control Rutin Security not found." });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = "An error occurred on the server." });
        }
    }

[HttpGet("get_crs_header")]
        public IActionResult GetCrsHeader(string? nomorReferensi)
        {
            if (!IsLoggedIn())
                return Json(new { success = false, message = "Tidak diizinkan." });
            if (string.IsNullOrWhiteSpace(nomorReferensi))
                return Json(new { success = false, message = "Parameter nomorReferensi wajib diisi." });
            try
            {
                using (var conn = GetConnection("Db").OpenConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT
                                    PlantDisplay =
                                        CASE
                                        WHEN NULLIF(mp.Nama_Terminal, '') IS NULL
                                            THEN LTRIM(RTRIM(mp.Plant))
                                        ELSE LTRIM(RTRIM(mp.Plant)) + ' - ' + LTRIM(RTRIM(mp.Nama_Terminal))
                                        END,
                                    Tanggal = CONVERT(varchar(10), COALESCE(d.Tanggal, pov.TanggalDibuat), 103)
                                    FROM dbo.ControlRutinSecurity pov
                                    OUTER APPLY (
                                    SELECT TOP (1) fi.Tanggal
                                    FROM dbo.FormInputControlRutinSecurity fi
                                    WHERE fi.NoReferensi = pov.NomorCRS
                                    ORDER BY fi.lastUpdatedDate DESC, fi.id DESC
                                    ) AS d
                                    LEFT JOIN dbo.MasterPlant mp
                                    ON mp.IdPlant = pov.LookupPlant
                                    WHERE pov.NomorCRS = @NoRef;", conn))
                {
                    cmd.Parameters.AddWithValue("@NoRef", nomorReferensi);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                            return Json(new { success = false, message = "Data tidak ditemukan." });
                        var plantDisplay = rd["PlantDisplay"]?.ToString() ?? "-";
                        var tanggal      = rd["Tanggal"]?.ToString() ?? "-";

                        // Bentuk string judul persis yang diinginkan
                        var namaJudul = $"Plant: {plantDisplay}, Tanggal: {tanggal}";
                        return Json(new
                        {
                            success = true,
                            plantDisplay,
                            tanggal,
                            namaJudul
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Log("get_pov_header error: " + ex.Message);
                return Json(new { success = false, message = "Terjadi kesalahan server." });
            }
        }

    [HttpPost("UploadDocumentGHKandPOV")]
    public async Task<IActionResult> UploadDocumentGHKandPOV([FromForm] UploadDocumentGHKandPOVRequest data) {
        if (!IsLoggedIn()) 
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        if (data.files == null || data?.files.Count == 0) 
        {
            return BadRequest("File tidak boleh kosong.");
        }
        try
        {
            int idRef = 0;
            string selfieFileName = "";
            string tableRef = "GoodHouseKeeping", 
                tableName = "FormInputGoodHouseKeeping",
                tableAnak = "DetailUploadGHK",
                colTanggal = "tgltiba",
                colIdRef = "idGHK",
                docPath = "GHKDocument";
            if (data.Menu == "POV")
            {
                tableRef = "ProofOfVisit";
                tableName = "FormInputProofOfVisit";
                tableAnak = "DetailUploadPOV";
                colTanggal = "Tanggal";
                colIdRef = "idPOV";
                docPath = "POVDocument";
            } else if (data.Menu == "CRS")
            {
                tableRef = "ControlRutinSecurity";
                tableName = "FormInputControlRutinSecurity";
                tableAnak = "DetailUploadCRS";
                colTanggal = "Tanggal";
                colIdRef = "IdCRS";
                docPath = "CRSDocument";
            }
            // if (data.VerifikasiMOD != null && data.VerifikasiMOD.Length > 0)
            // {
            //     selfieFileName = await UploadDokumenToAzureBlob(data.VerifikasiMOD, "SelfieVerification");
            // }
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                bool checkCRS = data.Menu == "CRS";
                string nomorTabel = checkCRS ? "CRS" : tableRef;
                DateTime plantDateTime = DateTime.Now;
                string sqlPlantTime = $@"
                    DECLARE @IdPlant INT;
                    SELECT @IdPlant = LookupPlant
                    FROM {tableRef} 
                    WHERE Nomor{nomorTabel} = @NoReferensi;
                    EXEC dbo.GetPlantDateTime @IdPlant = @IdPlant;
                ";
                using (SqlCommand spCmd = new SqlCommand(sqlPlantTime, sqlConnection))
                {
                    spCmd.Parameters.Add("@NoReferensi", SqlDbType.VarChar).Value = data.NoReferensi;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        plantDateTime = (DateTime)spResult;
                    }
                }
                int idPosition = 0; // Default to 0
                var positionObj = CurrentUserInfo("IdPosition");
                if (positionObj != null)
                {
                    // Safely parse the object to an integer
                    int.TryParse(positionObj.ToString(), out idPosition);
                }
                string insertFormSql = "";
                if (data.Menu == "POV")
                {
                    insertFormSql = $@"
                    INSERT INTO {tableName} (NoReferensi, {colTanggal}, UploadFoto, Lokasi, Keterangan, VerifikasiMOD, userInput, etlDate, IdPosition, Ketidaksesuaiaan)
                    OUTPUT INSERTED.Id
                    VALUES (@NoReferensi, @Tanggal, @UploadFoto, @Lokasi, @Keterangan, @VerifikasiMODFile, @userInput, @etlDate, @IdPosition, @Ketidaksesuaiaan);";
                    using (SqlCommand cmd = new SqlCommand(insertFormSql, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                        cmd.Parameters.AddWithValue("@Tanggal", data.Tanggal);
                        cmd.Parameters.AddWithValue("@UploadFoto", "Uploaded");
                        cmd.Parameters.AddWithValue("@Lokasi", data.Lokasi ?? "");
                        cmd.Parameters.AddWithValue("@Keterangan", data.Keterangan ?? "");
                        cmd.Parameters.AddWithValue("@VerifikasiMODFile", selfieFileName);
                        cmd.Parameters.AddWithValue("@userInput", CurrentUserName());
                        cmd.Parameters.AddWithValue("@etlDate", plantDateTime);
                        cmd.Parameters.AddWithValue("@IdPosition", idPosition);
                        cmd.Parameters.AddWithValue("@Ketidaksesuaiaan", data.Ketidaksesuaiaan ?? (object)DBNull.Value);
                        idRef = (int)cmd.ExecuteScalar();
                    }
                    string countSql = "SELECT COUNT(*) FROM FormInputProofOfVisit WHERE NoReferensi = @NoReferensi AND Ketidaksesuaiaan = 'Ya';";
                    int ketidaksesuaianCount = 0;
                    using (SqlCommand countCmd = new SqlCommand(countSql, sqlConnection))
                    {
                        countCmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                        ketidaksesuaianCount = (int)countCmd.ExecuteScalar();
                    }
                    string updatePovSql = "UPDATE ProofOfVisit SET JumlahKetidaksesuaiaan = @Count WHERE NomorProofOfVisit = @NoReferensi;";
                    using (SqlCommand updateCmd = new SqlCommand(updatePovSql, sqlConnection))
                    {
                        updateCmd.Parameters.AddWithValue("@Count", ketidaksesuaianCount.ToString());
                        updateCmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                        updateCmd.ExecuteNonQuery();
                    }
                    string updateTotalPengisianQuery = @"
                        UPDATE ProofOfVisit
                        SET TotalPengisian =
                        (
                            SELECT CAST(COUNT(DISTINCT Lokasi) AS NVARCHAR(10))
                            FROM FormInputProofOfVisit
                            WHERE NoReferensi = @NoReferensi
                        )
                        WHERE NomorProofOfVisit = @NoReferensi";
                    using (SqlCommand cmd = new SqlCommand(updateTotalPengisianQuery, sqlConnection))
                    {
                        cmd.Parameters.Add("@NoReferensi", SqlDbType.NVarChar, 50).Value = data.NoReferensi;
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string additionalCol = checkCRS ? ", NamaSecurity, LastUpdatedBy, IdPosition, Ketidaksesuaiaan" : "";
                    string additionalVal = checkCRS ? ", @NamaSecurity, @LastUpdatedBy, @IdPosition, @Ketidaksesuaiaan" : "";
                    insertFormSql = $@"
                    INSERT INTO {tableName} (NoReferensi, {colTanggal}, UploadFoto, Lokasi, Keterangan, userInput, etlDate{additionalCol})
                    OUTPUT INSERTED.Id
                    VALUES (@NoReferensi, @Tanggal, @UploadFoto, @Lokasi, @Keterangan, @userInput, @etlDate{additionalVal});";
                    using (SqlCommand cmd = new SqlCommand(insertFormSql, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                        cmd.Parameters.AddWithValue("@Tanggal", data.Tanggal);
                        cmd.Parameters.AddWithValue("@UploadFoto", "Uploaded");
                        cmd.Parameters.AddWithValue("@Lokasi", data.Lokasi ?? "");
                        cmd.Parameters.AddWithValue("@Keterangan", data.Keterangan ?? "");
                        cmd.Parameters.AddWithValue("@userInput", CurrentUserName());
                        cmd.Parameters.AddWithValue("@etlDate", plantDateTime);
                        if (checkCRS)
                        {
                            cmd.Parameters.AddWithValue("@NamaSecurity", data.NamaSecurity ?? "");
                            cmd.Parameters.AddWithValue("@LastUpdatedBy", CurrentUserName());
                            cmd.Parameters.AddWithValue("@Ketidaksesuaiaan", data.Ketidaksesuaiaan ?? "");
                            cmd.Parameters.AddWithValue("@IdPosition", idPosition);
                        }
                        idRef = (int)cmd.ExecuteScalar();
                    }
                    if (checkCRS)
                    {
                        bool checkSesuai = string.Equals(data.Ketidaksesuaiaan, "Ya", StringComparison.OrdinalIgnoreCase);
                        if (checkSesuai)
                        {
                            Execute(
                                @"UPDATE ControlRutinSecurity
                                SET JumlahKetidaksesuaiaan = ISNULL(JumlahKetidaksesuaiaan, 0) + 1
                                WHERE NomorCRS = @NomorCRS",
                                new { NomorCRS = data.NoReferensi }
                            );
                        }
                    }
                }
                foreach (var file in data.files)
                {
                    if (file.Length > 0)
                    {
                        string uniqueFileName = await UploadDokumenToAzureBlob(file, docPath);
                        string insertFileSql = $@"
                        INSERT INTO {tableAnak} ({colIdRef}, NoReferensi, FileName, userInput, etlDate)
                        VALUES (@idRef, @NoReferensi, @FileName, @userInput, @etlDate);";
                        using (SqlCommand cmdFile = new SqlCommand(insertFileSql, sqlConnection))
                        {
                            cmdFile.Parameters.AddWithValue("@idRef", idRef);
                            cmdFile.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                            cmdFile.Parameters.AddWithValue("@FileName", uniqueFileName);
                            cmdFile.Parameters.AddWithValue("@userInput", CurrentUserName());
                            cmdFile.Parameters.AddWithValue("@etlDate", plantDateTime);
                            cmdFile.ExecuteNonQuery();
                        }
                    }
                }
            }
            return Ok(new
            {
                success = true,
                message = "Berhasil Upload Dokumen.",
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("UpdateDocumentGHKandPOV")]
    public async Task<IActionResult> UpdateDocumentGHKandPOV([FromForm] UpdateDocumentGHKandPOVRequest data) {
        if (!IsLoggedIn()) 
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        if (string.IsNullOrEmpty(data?.idRef))
        {
            return BadRequest("Id tidak boleh kosong.");
        }
        try
        {
            string idRef = data.idRef;
            var files = data.files ?? new List<IFormFile>();
            var deletedIds = data.DeletedIds ?? new List<string>();
            string tableRef = "GoodHouseKeeping", 
                   tableName = "FormInputGoodHouseKeeping",
                   tableAnak = "DetailUploadGHK",
                   colTanggal = "tgltiba",
                   colIdRef = "idGHK",
                   docPath = "GHKDocument";
            if (data.Menu == "POV") {
                tableRef = "ProofOfVisit";
                tableName = "FormInputProofOfVisit";
                tableAnak = "DetailUploadPOV";
                colTanggal = "Tanggal";
                colIdRef = "idPOV";
                docPath = "POVDocument";
            } else if (data.Menu == "CRS")
            {
                tableRef = "ControlRutinSecurity";
                tableName = "FormInputControlRutinSecurity";
                tableAnak = "DetailUploadCRS";
                colTanggal = "Tanggal";
                colIdRef = "IdCRS";
                docPath = "CRSDocument";
            }
            int fileCount = 0;
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                bool checkCRS = data.Menu == "CRS";
                string nomorTabel = checkCRS ? "CRS" : tableRef;
                DateTime plantDateTime = DateTime.Now;
                string sqlPlantTime = $@"
                    DECLARE @IdPlant INT;
                    SELECT @IdPlant = Plant
                    FROM {tableRef} 
                    WHERE Nomor{nomorTabel} = @NoReferensi;
                    EXEC dbo.GetPlantDateTime @IdPlant = @IdPlant;
                ";
                using (SqlCommand spCmd = new SqlCommand(sqlPlantTime, sqlConnection))
                {
                    spCmd.Parameters.Add("@NoReferensi", SqlDbType.VarChar).Value = data.NoReferensi;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        plantDateTime = (DateTime)spResult;
                    }
                }
                string sql = $"SELECT COUNT(*) FROM {tableAnak} WHERE {colIdRef} = @idRef";
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@idRef", idRef);
                    fileCount = (int)cmd.ExecuteScalar();
                }
                if (files.Count == 0 && deletedIds.Count >= fileCount) {
                    return BadRequest("File foto tidak boleh kosong.");
                }
                if (data.Menu == "CRS")
                {
                    string updateFormSql = $@"
                        UPDATE {tableName} SET 
                            NoReferensi = @NoReferensi, 
                            {colTanggal} = @Tanggal, 
                            Lokasi = @Lokasi, 
                            Keterangan = @Keterangan, 
                            LastUpdatedBy = @lastUpdatedBy,
                            LastUpdatedDate = @lastUpdatedDate,
                            NamaSecurity = @NamaSecurity,
                            Ketidaksesuaiaan = @Ketidaksesuaiaan
                        WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(updateFormSql, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@id", idRef);
                        cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                        cmd.Parameters.AddWithValue("@Tanggal", data.Tanggal);
                        cmd.Parameters.AddWithValue("@Lokasi", data.Lokasi ?? "");
                        cmd.Parameters.AddWithValue("@Keterangan", data.Keterangan ?? "");
                        cmd.Parameters.AddWithValue("@lastUpdatedBy", CurrentUserName());
                        cmd.Parameters.AddWithValue("@lastUpdatedDate", plantDateTime);
                        cmd.Parameters.AddWithValue("@NamaSecurity", data.NamaSecurity ?? "");
                        cmd.Parameters.AddWithValue("@Ketidaksesuaiaan", data.Ketidaksesuaiaan ?? "");
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("UpdateCRSWithKetidaksesuaiaan", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = int.Parse(idRef);
                        cmd.Parameters.Add("@NomorCRS", SqlDbType.VarChar, 50).Value = data.NoReferensi;
                        cmd.Parameters.Add("@NewValue", SqlDbType.VarChar, 10).Value = data.Ketidaksesuaiaan ?? "";
                        cmd.ExecuteNonQuery();
                    }
                }
                else 
                {
                    string updateFormSql = $@"
                        UPDATE {tableName} SET 
                            NoReferensi = @NoReferensi, 
                            {colTanggal} = @Tanggal, 
                            Lokasi = @Lokasi, 
                            Keterangan = @Keterangan, 
                            lastUpdatedBy = @lastUpdatedBy, 
                            lastUpdatedDate = @lastUpdatedDate
                        WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(updateFormSql, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@id", idRef);
                        cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                        cmd.Parameters.AddWithValue("@Tanggal", data.Tanggal);
                        cmd.Parameters.AddWithValue("@Lokasi", data.Lokasi ?? "");
                        cmd.Parameters.AddWithValue("@Keterangan", data.Keterangan ?? "");
                        cmd.Parameters.AddWithValue("@lastUpdatedBy", CurrentUserName());
                        cmd.Parameters.AddWithValue("@lastUpdatedDate", plantDateTime);
                        cmd.ExecuteNonQuery();
                    }
                }
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string uniqueFileName = await UploadDokumenToAzureBlob(file, docPath);
                        string insertFileSql = $@"
                            INSERT INTO {tableAnak} ({colIdRef}, NoReferensi, FileName, userInput, etlDate)
                            VALUES (@idRef, @NoReferensi, @FileName, @userInput, @etlDate);";
                        using (SqlCommand cmdFile = new SqlCommand(insertFileSql, sqlConnection))
                        {
                            cmdFile.Parameters.AddWithValue("@idRef", idRef);
                            cmdFile.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                            cmdFile.Parameters.AddWithValue("@FileName", uniqueFileName);
                            cmdFile.Parameters.AddWithValue("@userInput", CurrentUserName());
                            cmdFile.Parameters.AddWithValue("@etlDate", plantDateTime);
                            cmdFile.ExecuteNonQuery();
                        }
                    }
                }
                foreach (var delId in deletedIds)
                {
                    string deleteSQL = $"DELETE FROM {tableAnak} WHERE id = @id;";
                    using (SqlCommand cmdFile = new SqlCommand(deleteSQL, sqlConnection))
                    {
                        cmdFile.Parameters.AddWithValue("@id", delId);
                        cmdFile.ExecuteNonQuery();
                    }
                }
            }
            return Ok(new
            {
                success = true,
                message = "Berhasil Update Dokumen.",
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    // GET /api/LookUpList/CheckPlantDateMod?idPlant=1106&tanggal=2025-10-13
    [HttpGet("CheckPlantDateMod")]
    public IActionResult CheckPlantDateMod(int idPlant, string tanggal)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Not authorized.", StatusCodes.Status401Unauthorized);
        }

        // Parse tanggal (terima format umum .NET)
        DateTime tanggalParam;
        if (!DateTime.TryParse(tanggal, out tanggalParam))
        {
            return ErrorResponseDto("Tanggal tidak valid.", StatusCodes.Status400BadRequest);
        }
        int total = 0;
        string plantCode = string.Empty;
        string terminalName = string.Empty;

        // 1) Ambil Plant & Nama_Terminal dari MasterPlant
        string sqlPlant = "SELECT TOP 1 Plant, Nama_Terminal FROM MasterPlant WHERE IdPlant = @IdPlant";

        // 2) Hitung SetUserMOD untuk Plant & Tanggal (dibandingkan by DATE)
        string sqlCount = @"
            SELECT COUNT(*) AS Total
            FROM SetUserMOD
            WHERE Plant = @PlantCode
            AND CAST(Tanggal AS DATE) = @Tanggal;";
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                // Ambil Plant code + Terminal
                using (SqlCommand cmdPlant = new SqlCommand(sqlPlant, sqlConnection))
                {
                    cmdPlant.Parameters.AddWithValue("@IdPlant", idPlant);
                    using (SqlDataReader rd = cmdPlant.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            plantCode = rd["Plant"] != DBNull.Value ? (Convert.ToString(rd["Plant"]) ?? "") : "";
                            terminalName = rd["Nama_Terminal"] != DBNull.Value ? (Convert.ToString(rd["Nama_Terminal"]) ?? "") : "";
                        }
                    }
                }

                // Hitung eksistensi (kalau plantCode kosong, tetap jalan -> total=0)
                using (SqlCommand cmdCount = new SqlCommand(sqlCount, sqlConnection))
                {
                    cmdCount.Parameters.AddWithValue("@PlantCode", plantCode);
                    var pTanggal = cmdCount.Parameters.Add("@Tanggal", SqlDbType.Date);
                    pTanggal.Value = tanggalParam.Date;
                    using (SqlDataReader reader = cmdCount.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            total = reader["Total"] != DBNull.Value ? Convert.ToInt32(reader["Total"]) : 0;
                        }
                    }
                }
            }
            return Ok(new
            {
                success = true,
                exists = total > 0,
                total = total,
                plant = plantCode,
                terminalName = terminalName,                  // ← tambahan
                tanggal = tanggalParam.ToString("yyyy-MM-dd")
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ErrorResponseDto("Terjadi kesalahan dalam memproses data", StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("GetMODForPOV")]
    public IActionResult GetMODForPOV([FromQuery] string noRef)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        try
        {
            noRef = (noRef ?? "").Trim();
            if (string.IsNullOrWhiteSpace(noRef))
                return Json(new { success = false, message = "Nomor referensi kosong." });
            var parts = noRef.Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length < 4 || !parts[0].Equals("POV", StringComparison.OrdinalIgnoreCase))
                return Json(new { success = false, message = "Format Nomor Proof of Visit tidak valid." });

            // parse date dari nomor referensi
            var dateToken = parts[2];
            if (dateToken.Length != 8
                || !int.TryParse(dateToken.Substring(0, 4), out var year)
                || !int.TryParse(dateToken.Substring(4, 2), out var month)
                || !int.TryParse(dateToken.Substring(6, 2), out var day))
                return Json(new { success = false, message = "Tanggal Proof of Visit tidak valid." });
            DateTime povDate;
            try { povDate = new DateTime(year, month, day).Date; }
            catch { return Json(new { success = false, detail = "Tanggal Proof of Visit tidak valid." }); }
            using var conn = GetConnection("Db").OpenConnection();

            // get plant id
            const string query1 = @"SELECT TOP 1 COALESCE(Plant, LookupPlant) FROM ProofOfVisit WHERE NomorProofOfVisit = @noReferensi";
            int plantId;
            using (var cmd = new SqlCommand(query1, conn))
            {
                cmd.Parameters.Add("@noReferensi", SqlDbType.NVarChar, 50).Value = noRef;
                var obj = cmd.ExecuteScalar();
                if (obj == null || obj == DBNull.Value)
                    return Json(new { success = false, message = "Plant tidak ditemukan untuk NoReferensi tersebut." });
                if (!int.TryParse(Convert.ToString(obj), out plantId) || plantId <= 0)
                    return Json(new { success = false, message = "Plant pada ProofOfVisit tidak valid (bukan IdPlant)." });
            }

            // get plant time
            DateTime dtPlant = DateTime.Now;
            using (var cmd = new SqlCommand("dbo.GetPlantDateTime", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlant", SqlDbType.Int).Value = plantId;
                var obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value && obj is DateTime dt)
                    dtPlant = dt;
            }

            // get user mod
            int? userModId = null;
            string? userModName = null;
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 
                    TRY_CONVERT(int, s.UserMOD) AS UserModId,
                    u.NamaLengkap
                FROM SetUserMOD s
                    LEFT JOIN MasterUser u ON u.IdUser = TRY_CONVERT(int, s.UserMOD)
                WHERE s.LookupPlant = @LookupPlant 
                    AND TRY_CONVERT(date, s.Tanggal) = @Tanggal
                ORDER BY TRY_CONVERT(datetime, s.Tanggal) DESC", conn))
            {
                cmd.Parameters.Add("@LookupPlant", SqlDbType.Int).Value = plantId;
                cmd.Parameters.Add("@Tanggal", SqlDbType.Date).Value = povDate;
                using var rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (!rd.IsDBNull(0))
                        userModId = rd.GetInt32(0);
                    userModName = rd.IsDBNull(1) ? null : rd.GetString(1);
                }
            }

            // resolve current logged in user
            int uid = 0;
            var s1 = Convert.ToString(CurrentUserInfo("IdUser"));
            if (!string.IsNullOrWhiteSpace(s1))
                int.TryParse(s1, out uid);
            if (uid == 0)
            {
                var raw = Convert.ToString(CurrentUserID());
                if (!string.IsNullOrWhiteSpace(raw))
                    int.TryParse(raw, out uid);
            }
            if (uid == 0)
            {
                var uname = Convert.ToString(CurrentUserInfo("NamaLengkap")) ?? "";
                if (!string.IsNullOrWhiteSpace(uname))
                {
                    using var cmd = new SqlCommand(@"SELECT TOP 1 IdUser FROM MasterUser WHERE NamaLengkap = @uname", conn);
                    cmd.Parameters.Add("@uname", SqlDbType.NVarChar, 100).Value = uname;
                    var obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                        int.TryParse(Convert.ToString(obj), out uid);
                }
            }
            return Json(new
            {
                success = true,
                plantId,
                plant = parts[1], // token kode plant dari noRef (misal 1112)
                tanggal = povDate.ToString("yyyy-MM-dd"),
                plantDateTime = dtPlant.ToString("yyyy-MM-dd HH:mm:ss"),
                userModId,
                userModName,
                uid,
                isCurrentUserMOD = (userModId.HasValue && uid == userModId.Value)
            });
        }
        catch (Exception ex) 
        {
            Log("GetMODForPOV failed: " + ex);
            return Json(new { success = false, message = ex.Message });
        }
    }

    private async Task<string> UploadDokumenToAzureBlob(IFormFile data, string path)
    {
        string? connectionString = Configuration["AzureBlob:ConnectionString"];
        string? containerName = Configuration["AzureBlob:ContainerName"];
        var originalFileName = Path.GetFileNameWithoutExtension(data.FileName);
        var extension = Path.GetExtension(data.FileName);
        var uniqueFileName = $"{originalFileName}_{DateTime.Now:yyyyMMddHHmmssfff}{extension}";
        if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // buat container jika belum ada
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);

            // buat blob dan upload
            var blobPath = $"{path}/{uniqueFileName}";
            var blobClient = containerClient.GetBlobClient(blobPath);
            using (var stream = data.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = data.ContentType });
            }
        }
        else
        {
            string curdir = Directory.GetCurrentDirectory();
            string uploadPath = Path.Combine(curdir, "wwwroot", "Uploads", path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            var filePath = Path.Combine(uploadPath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await data.CopyToAsync(stream);
            }
        }
        return uniqueFileName;
    }

    [HttpGet("DownloadDocumentZip")]
    public async Task<IActionResult> DownloadDocumentZip(string? idRef, string? table, string? colRef, string? path)
    {
        if (!IsLoggedIn())
        {
            return Json(new { success = false, message = "Not authorized." });
        }
        string sqlData = $"SELECT FileName FROM {table} WHERE {colRef} = @idRef;";
        List<string> dokumenList = new List<string>();
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@idRef", idRef ?? "");
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["FileName"] != DBNull.Value)
                        {
                            dokumenList.Add(reader["FileName"].ToString());
                        }
                    }
                }
            }
            if (dokumenList.Count == 0)
            {
                return NotFound(new { success = false, message = "Tidak ada dokumen ditemukan." });
            }
            using (var zipStream = new MemoryStream())
            {
                using (var archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create, true))
                {
                    string? connectionString = Configuration["AzureBlob:ConnectionString"];
                    string? containerName = Configuration["AzureBlob:ContainerName"];
                    foreach (var dokumen in dokumenList)
                    {
                        if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
                        {
                            string blobPath = $"{path}/{dokumen}";
                            var blobServiceClient = new BlobServiceClient(connectionString);
                            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                            var blobClient = containerClient.GetBlobClient(blobPath);
                            if (await blobClient.ExistsAsync())
                            {
                                var downloadInfo = await blobClient.DownloadAsync();
                                using var entryStream = archive.CreateEntry(dokumen, System.IO.Compression.CompressionLevel.Fastest).Open();
                                await downloadInfo.Value.Content.CopyToAsync(entryStream);
                            }
                        }
                        else
                        {
                            string curdir = Directory.GetCurrentDirectory();
                            string folderPath = Path.Combine(curdir, "wwwroot", "Uploads", path);
                            string filePath = Path.Combine(folderPath, dokumen);
                            if (System.IO.File.Exists(filePath))
                            {
                                var entry = archive.CreateEntry(dokumen, System.IO.Compression.CompressionLevel.Fastest);
                                using var entryStream = entry.Open();
                                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                                await entryStream.WriteAsync(fileBytes, 0, fileBytes.Length);
                            }
                        }
                    }
                }
                zipStream.Position = 0;
                string zipFileName = $"{path}_{idRef}_{DateTime.Now:yyyyMMddHHmmss}.zip";
                return File(zipStream.ToArray(), "application/zip", zipFileName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("DownloadSingleDocument")]
    public async Task<IActionResult> DownloadSingleDocument(string? id, string? menu)
    {
        if (!IsLoggedIn())
            return Unauthorized(new { success = false, message = "Unauthorized access" });
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(menu))
            return BadRequest(new { success = false, message = "Invalid parameters" });
        var menuMap = new Dictionary<string, (string sql, string folder)>
        {
            ["AktivitasDokumen"] = ("SELECT FileName FROM AktivitasDokumenDetail WHERE id = @id;", "ActivityDocument"),
            ["GHK"]              = ("SELECT FileName FROM DetailUploadGHK WHERE id = @id;", "GHKDocument"),
            ["POV"]              = ("SELECT FileName FROM DetailUploadPOV WHERE id = @id;", "POVDocument"),
            ["MWTOnline"]        = ("SELECT UploadEvidence FROM MWTOnlineDetail WHERE id = @id;", "MWTOnlineDocument"),
            ["CRS"]              = ("SELECT FileName FROM DetailUploadCRS WHERE id = @id;", "CRSDocument"),
            ["PJS"]              = ("SELECT SuratTugas FROM SetPjs WHERE id = @id;", "PJSDocument")
        };
        if (!menuMap.TryGetValue(menu, out var config))
            return BadRequest(new { success = false, message = "Invalid menu" });
        try
        {
            string fileName = await DatabaseQueryHelper.ExecuteSelectSingleAsync<string>(
                config.sql,
                r => r.IsDBNull(0) ? "" : r.GetString(0),
                new Dictionary<string, object> { { "@id", id } }
            );
            if (string.IsNullOrWhiteSpace(fileName))
                return NotFound(new { success = false, message = "File not found." });
            string contentType = GetContentType(fileName);
            string? connectionString = Configuration["AzureBlob:ConnectionString"];
            string? containerName = Configuration["AzureBlob:ContainerName"];
            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
            {
                var blobService = new BlobServiceClient(connectionString);
                var container = blobService.GetBlobContainerClient(containerName);
                string blobPath = $"{config.folder}/{fileName}";
                var blob = container.GetBlobClient(blobPath);
                if (await blob.ExistsAsync())
                {
                    var dl = await blob.DownloadAsync();
                    return File(dl.Value.Content, contentType, fileName);
                }
            }
            string localPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", config.folder, fileName);
            if (!System.IO.File.Exists(localPath))
                return NotFound(new { success = false, message = "File not found on the server." });
            var bytes = await System.IO.File.ReadAllBytesAsync(localPath);
            return File(bytes, contentType, fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, new { success = false, message = "An error occurred on the server." });
        }
    }

    [HttpGet("GetPreviewDocument")]
    public async Task<IActionResult> GetPreviewDocument(string? id)
    {
        if (!IsLoggedIn())
            return Unauthorized(new { success = false, message = "Unauthorized access" });
        const string sql = @"SELECT UploadEvidence 
                             FROM MWTOnlineDetail 
                             WHERE id = @id;";
        string fileName = await DatabaseQueryHelper.ExecuteSelectSingleAsync<string>(
            sql,
            r => r.IsDBNull(0) ? "" : r.GetString(0),
            new Dictionary<string, object> { { "@id", id } }
        );
        if (string.IsNullOrEmpty(fileName))
            return NotFound();
        string extension = Path.GetExtension(fileName).ToLower();
        if (!new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" }.Contains(extension))
            return BadRequest("File bukan gambar.");
        string folder = "MWTOnlineDocument";
        string? conn = Configuration["AzureBlob:ConnectionString"];
        string? container = Configuration["AzureBlob:ContainerName"];
        if (!string.IsNullOrEmpty(conn) && !string.IsNullOrEmpty(container))
        {
            string blobPath = $"{folder}/{fileName}";
            var blob = new BlobServiceClient(conn)
                .GetBlobContainerClient(container)
                .GetBlobClient(blobPath);
            if (await blob.ExistsAsync())
            {
                var dl = await blob.DownloadAsync();
                return File(dl.Value.Content, $"image/{extension.Trim('.')}");
            }
        }
        string localPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "Uploads",
            folder,
            fileName
        );
        if (!System.IO.File.Exists(localPath))
            return NotFound();
        var bytes = await System.IO.File.ReadAllBytesAsync(localPath);
        return File(bytes, $"image/{extension.Trim('.')}");
    }

    [HttpGet("DownloadFaceEnrollment")]
    public async Task<IActionResult> DownloadFaceEnrollment(string? FileName)
    {
        if (!IsLoggedIn())
        {
            return Json(new { success = false, message = "Not authorized." });
        }
        try
        {
            string path = "FaceEnrollment";
            string connectionString = Configuration["AzureBlob:ConnectionString"];
            string containerName = Configuration["AzureBlob:ContainerName"];
            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
            {
                string blobPath = $"{path}/{FileName}";
                var blobServiceClient = new BlobServiceClient(connectionString);
                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlobClient(blobPath);
                if (!await blobClient.ExistsAsync())
                {
                    return NotFound(new { success = false, message = "File not found in Azure Blob Storage." });
                }
                var downloadInfo = await blobClient.DownloadAsync();
                string extension = Path.GetExtension(FileName).ToLowerInvariant();
                string contentType = extension switch
                {
                    ".gif" => "image/gif",
                    ".jpg" => "image/jpeg",
                    ".jpeg" => "image/jpeg",
                    ".bmp" => "image/bmp",
                    ".png" => "image/png",
                    ".doc" => "application/msword",
                    ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    ".xls" => "application/vnd.ms-excel",
                    ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    ".pdf" => "application/pdf",
                    ".zip" => "application/zip",
                    ".txt" => "text/plain",
                    _ => "application/octet-stream"
                };
                Response.Headers.Remove("Content-Disposition");
                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{FileName}\"");
                return File(downloadInfo.Value.Content, contentType, FileName);
            }
            string curdir = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(curdir, "wwwroot", "Uploads", path);
            string filePath = Path.Combine(folderPath, FileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(new { success = false, message = "File not found on the server." });
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            string extension_local = Path.GetExtension(FileName).ToLower();
            string contentType_local = extension_local switch
            {
                ".gif"  => "image/gif",
                ".jpg"  => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".bmp"  => "image/bmp",
                ".png"  => "image/png",
                ".doc"  => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls"  => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".pdf"  => "application/pdf",
                ".zip"  => "application/zip",
                ".txt"  => "text/plain",
                _       => "application/octet-stream"
            };
            Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{FileName}\"");
            return File(fileBytes, contentType_local, $"{FileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("UploadDocumentBukuTamu")]
    public async Task<IActionResult> UploadDocumentBukuTamu(

        [FromForm] IFormFile file,
        [FromForm] string field,
        [FromForm] string? nomorBukuTamu,
        [FromForm] string? id
    )
    {
        if (!IsLoggedIn())
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        if (file == null || file.Length == 0)
            return BadRequest("File tidak boleh kosong.");
        if (string.IsNullOrEmpty(field))
            return BadRequest("Field tidak boleh kosong.");
        if (string.IsNullOrEmpty(nomorBukuTamu) && string.IsNullOrEmpty(id))
            return BadRequest("Key record (NomorBukuTamu atau Id) tidak boleh kosong.");
        var allowedFields = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
            "TandaTangan",
            "PintuUtamaInFoto",
            "PintuUtamaOutFoto",
            "LobbyUtamaInFoto",
            "LobbyUtamaOutFoto",
            "AreaTerlarangInFoto",
            "AreaTerlarangOutFoto"
        };
        if (!allowedFields.Contains(field))
            return BadRequest("Field tidak diizinkan.");
        try {
            string path = "BukuTamuDocument";
            string uniqueFileName = await UploadDokumenToAzureBlob(file, path);
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string whereKey = !string.IsNullOrEmpty(nomorBukuTamu) ? "NomorBukuTamu = @Key" : "Id = @Key";
                using var cmd = new SqlCommand($@"
                    UPDATE BukuTamu
                    SET [{field}] = @FileName,
                        LastUpdatedBy = @User,
                        LastUpdatedDate = @Date
                    WHERE {whereKey};", sqlConnection);
                cmd.Parameters.AddWithValue("@Key", !string.IsNullOrEmpty(nomorBukuTamu) ? nomorBukuTamu : id);
                cmd.Parameters.AddWithValue("@FileName", uniqueFileName);
                cmd.Parameters.AddWithValue("@User", CurrentUserName());
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                await cmd.ExecuteNonQueryAsync();
            }
            return Ok(new { success = true, message = "Upload berhasil", fileName = uniqueFileName });
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "Error: " + ex.Message);
        }
    }

    [HttpGet("DownloadDocumentBukuTamu")]
    public async Task<IActionResult> DownloadDocumentBukuTamu(string? field, string? nomorBukuTamu, string? id)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        if (string.IsNullOrEmpty(field))
            return BadRequest("Field tidak boleh kosong.");
        if (string.IsNullOrEmpty(nomorBukuTamu) && string.IsNullOrEmpty(id))
            return BadRequest("Key record (NomorBukuTamu atau Id) tidak boleh kosong.");
        try {
            string fileName = "";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection()) {
                string whereKey = !string.IsNullOrEmpty(nomorBukuTamu) ? "NomorBukuTamu = @Key" : "Id = @Key";
                using (SqlCommand cmd = new SqlCommand($"SELECT {field} FROM BukuTamu WHERE {whereKey};", sqlConnection)) {
                    cmd.Parameters.AddWithValue("@Key", !string.IsNullOrEmpty(nomorBukuTamu) ? nomorBukuTamu : id);
                    fileName = cmd.ExecuteScalar()?.ToString();
                }
            }
            if (string.IsNullOrEmpty(fileName))
                return NotFound(new { success = false, message = "File tidak ditemukan." });
            string path = "BukuTamuDocument";
            string connectionString = Configuration["AzureBlob:ConnectionString"];
            string containerName = Configuration["AzureBlob:ContainerName"];
            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName)) {
                string blobPath = $"{path}/{fileName}";
                var blobServiceClient = new BlobServiceClient(connectionString);
                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlobClient(blobPath);
                if (!await blobClient.ExistsAsync())
                    return NotFound(new { success = false, message = "File tidak ditemukan di Azure." });
                var downloadInfo = await blobClient.DownloadAsync();
                string contentType = GetContentType(fileName);
                Response.Headers.Remove("Content-Disposition");
                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");
                return File(downloadInfo.Value.Content, contentType, fileName);
            }

            // Local fallback
            string curdir = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(curdir, "wwwroot", "Uploads", path);
            string filePath = Path.Combine(folderPath, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound(new { success = false, message = "File tidak ditemukan di server." });
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            string contentTypeLocal = GetContentType(fileName);
            return File(fileBytes, contentTypeLocal, fileName);
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "Error: " + ex.Message);
        }
    }

    private static string GetContentType(string fileName)
    {
        string extension = Path.GetExtension(fileName).ToLowerInvariant();
        return extension switch
        {
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            ".pdf" => "application/pdf",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".xls" => "application/vnd.ms-excel",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".zip" => "application/zip",
            ".txt" => "text/plain",
            _ => "application/octet-stream"
        };
    }

    [HttpPost("UpdateStatusAktivitasByDocument")]
    public async Task<IActionResult> UpdateStatusAktivitasByDocument([FromForm] UpdateStatusAktivitasByDocumentRequest data)
    {
        if (!IsLoggedIn())
        {
            throw new LogErrorException("Unauthorized access", StatusCodes.Status401Unauthorized, idAktivitas: int.Parse(data.IdAktivitas));
        }
        if (data.StatusAktivitas == "Completed" || data.StatusAktivitas == "Completed Edit")
        {
            int WajibUpload = await DatabaseQueryHelper.ExecuteSelectSingleAsync<int>(
                "SELECT COUNT(WajibUpload) FROM AktivitasDokumen WHERE IdAktivitas = @IdAktivitas AND StatusUpload <> 'Uploaded' AND WajibUpload = 1;", 
                reader => reader.IsDBNull(0) ? 0  : reader.GetInt32(0),
                new Dictionary<string, object> { { "@IdAktivitas", data.IdAktivitas } },
                idAktivitas: int.Parse(data.IdAktivitas)
            );
            if (WajibUpload >= 1)
            {
                throw new LogErrorException("Incomplete Documents", StatusCodes.Status400BadRequest, idAktivitas: int.Parse(data.IdAktivitas));
            }
        }
        string noReferensi = await DatabaseQueryHelper.ExecuteSelectSingleAsync<string>(
            "SELECT No_Referensi FROM Aktivitas WHERE IdAktivitas = @IdAktivitas;", 
            reader => reader.IsDBNull(0) ? "" : reader.GetString(0),
            new Dictionary<string, object> { { "@IdAktivitas", data.IdAktivitas } },
            idAktivitas: int.Parse(data.IdAktivitas)
        );
        DateTime plantDateTime = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
            "EXEC dbo.GetPlantDateTime @NomorReferensi = @NomorReferensi",
            reader => {
                var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                if (val == null) return DateTime.Now;
                return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
            },
            new Dictionary<string, object> { { "@NomorReferensi", noReferensi } },
            noReferensi: noReferensi,
            idAktivitas: int.Parse(data.IdAktivitas)
        );
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            @"  UPDATE Aktivitas 
                SET StatusAktivitas = @StatusAktivitas, 
                    Keterangan = @Keterangan, 
                    IsNominationTankReceivingLineOpen = @IsNominationTankReceivingLineOpen,
                    IsNonNominationReceivingLineClosedAndSealed = @IsNonNominationReceivingLineClosedAndSealed,
                    IsTankEmptyAndDry = @IsTankEmptyAndDry,
                    IsDocumentationComplete = @IsDocumentationComplete,
                    TanggalDiperbarui = @PlantTime, 
                    DiperbaruiOleh = @DiperbaruiOleh 
                WHERE IdAktivitas = @IdAktivitas;", 
            new Dictionary<string, object> { 
                { "@StatusAktivitas", data.StatusAktivitas },
                { "@Keterangan", data.Keterangan ?? "" },
                { "@IsNominationTankReceivingLineOpen", data.IsNominationTankReceivingLineOpen ? 1 : 0 },
                { "@IsNonNominationReceivingLineClosedAndSealed", data.IsNonNominationReceivingLineClosedAndSealed ? 1 : 0 },
                { "@IsTankEmptyAndDry", data.IsTankEmptyAndDry ? 1 : 0 },
                { "@IsDocumentationComplete", data.IsDocumentationComplete ? 1 : 0 },
                { "@PlantTime", plantDateTime },
                { "@DiperbaruiOleh", CurrentUserName() },
                { "@IdAktivitas", data.IdAktivitas }
            },
            noReferensi: noReferensi,
            idAktivitas: int.Parse(data.IdAktivitas)
        );
        await UpdateStatusProsesByIdAktivitas(int.Parse(data.IdAktivitas));
        await AddLogAktivitas(int.Parse(data.IdAktivitas), data.StatusAktivitas, data.Catatan);
        await UpdateTanggalAktivitas(int.Parse(data.IdAktivitas));
        return Ok( new
        {
            success = true,
            message = "Aktivitas berhasil diperbarui."
        });
    }

    [HttpGet("GetNomorPenerimaanFromPenimbunan")]
    public IActionResult GetNomorPenerimaanFromPenimbunan(string? NomorPenimbunan)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string nomorPenerimaan = "";
        string sql = @"
            SELECT TOP 1 pn.NomorPenerimaan
            FROM Penimbunan P
            JOIN Penerimaan pn ON pn.IdPenerimaan = P.IdPenerimaan
            WHERE P.NomorPenimbunan = @NomorPenimbunan";
        try
        {
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@NomorPenimbunan", EncodeForXSS(NomorPenimbunan));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nomorPenerimaan = reader["NomorPenerimaan"]?.ToString() ?? "";
                    }
                }
            }
            return Ok(new
            {
                success = true,
                nomorPenerimaan = nomorPenerimaan
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetARValue")]
    public IActionResult GetARValue(string? NoReferensi, string? Jenis = "BBM")
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string sqlData = "";
        switch (Jenis.ToUpper())
        {
            case "BBM":
                sqlData = @"SELECT
                            SUM(cast(ar.KL_Obs as float)) as klobs,
                            SUM(cast(ar.KL_15 as float)) as kl15,
                            SUM(cast(ar.Barrels as float)) as barrels,
                            SUM(cast(ar.LT as float)) as lt,
                            SUM(cast(ar.MT as float)) as mt
                        FROM Penerimaan p
                        JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                        JOIN (
                            SELECT KL_Obs, kl_15, barrels, LT, MT, cqd.NoReferensi, A.StatusAktivitas
                                FROm SubAktivitasNilaiARsesuaiCQD cqd
                                JOIN Aktivitas A ON A.IdAktivitas = cqd.idAktifitas
                                WHERE A.StatusAktivitas IN('Completed', 'Completed Edit')
                        ) as AR ON AR.NoReferensi = p2.NomorPenimbunan
                        WHERE p.NomorPenerimaan = @NoReferensi
                        group by p.NomorPenerimaan";
                break;
            case "STSBBM":
                sqlData = @"SELECT
                            SUM(cast(ar.AR_klobs as float)) as klobs,
                            SUM(cast(ar.AR_kl15 as float)) as kl15,
                            SUM(cast(ar.AR_barrels as float)) as barrels,
                            SUM(cast(ar.AR_lt as float)) as lt,
                            SUM(cast(ar.AR_mt as float)) as mt
                        FROM Penerimaan p
                        JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                        JOIN (
                            SELECT AR_klobs, AR_kl15, AR_barrels, AR_lt, AR_mt, cqd.NoReferensi, A.StatusAktivitas
                                FROm SubAktivitasFormNilaiSFALARSTSPymBBM cqd
                                JOIN Aktivitas A ON A.IdAktivitas = cqd.idAktifitas
                                WHERE A.StatusAktivitas IN('Completed', 'Completed Edit')
                        ) as AR ON AR.NoReferensi = p2.NomorPenimbunan
                        WHERE p.NomorPenerimaan = @NoReferensi
                        group by p.NomorPenerimaan";
                break;
            case "LPG":
                sqlData = @"SELECT
                            SUM(cast(ar.MT as float)) as mt
                        FROM Penerimaan p
                        JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                        JOIN (
                            SELECT MT, cqd.NoReferensi, A.StatusAktivitas
                                FROm SubAktivitasNilaiARsesuaiCQDLPG cqd
                                JOIN Aktivitas A ON A.IdAktivitas = cqd.idAktifitas
                                WHERE A.StatusAktivitas IN('Completed', 'Completed Edit')
                        ) as AR ON AR.NoReferensi = p2.NomorPenimbunan
                        WHERE p.NomorPenerimaan = @NoReferensi
                        group by p.NomorPenerimaan";
                break;
            case "STSLPG":
                sqlData = @"SELECT
                            SUM(cast(ar.AR_mt as float)) as mt
                        FROM Penerimaan p
                        JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                        JOIN (
                            SELECT AR_MT, cqd.NoReferensi, A.StatusAktivitas
                                FROm SubAktivitasFormNilaiSFALARSTSPymLPG cqd
                                JOIN Aktivitas A ON A.IdAktivitas = cqd.idAktifitas
                                WHERE A.StatusAktivitas IN('Completed', 'Completed Edit')
                        ) as AR ON AR.NoReferensi = p2.NomorPenimbunan
                        WHERE p.NomorPenerimaan = @NoReferensi
                        group by p.NomorPenerimaan";
                break;
            case "RTW":
                sqlData = @"SELECT
                            SUM(cast(ar.KL_Obs as float)) as klobs,
                            SUM(cast(ar.KL_15 as float)) as kl15,
                            SUM(cast(ar.Barrels as float)) as barrels,
                            SUM(cast(ar.LT as float)) as lt,
                            SUM(cast(ar.MT as float)) as mt
                        FROM Penerimaan p
                        JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                        JOIN (
                            SELECT KL_Obs, kl_15, barrels, LT, MT, cqd.NoReferensi, A.StatusAktivitas
                                FROm SubAktivitasARSesuaiCQDRTW cqd
                                JOIN Aktivitas A ON A.IdAktivitas = cqd.idAktifitas
                                WHERE A.StatusAktivitas IN('Completed', 'Completed Edit')
                        ) as AR ON AR.NoReferensi = p2.NomorPenimbunan
                        WHERE p.NomorPenerimaan = @NoReferensi
                        group by p.NomorPenerimaan";
                break;
            case "TRUCK":
                sqlData = @"SELECT
                            SUM(cast(ar.KL_Obs as float)) as klobs,
                            SUM(cast(ar.KL_15 as float)) as kl15,
                            SUM(cast(ar.Barrels as float)) as barrels,
                            SUM(cast(ar.LT as float)) as lt,
                            SUM(cast(ar.MT as float)) as mt
                        FROM Penerimaan p
                        JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                        JOIN (
                            SELECT KL_Obs, kl_15, barrels, LT, MT, cqd.NoReferensi, A.StatusAktivitas
                                FROm SubAktivitasFormInputNilaiARsesuaiCQDTruck cqd
                                JOIN Aktivitas A ON A.IdAktivitas = cqd.idAktifitas
                                WHERE A.StatusAktivitas IN('Completed', 'Completed Edit')
                        ) as AR ON AR.NoReferensi = p2.NomorPenimbunan
                        WHERE p.NomorPenerimaan = @NoReferensi
                        group by p.NomorPenerimaan";
                break;
            case "PIPA":
                sqlData = @"SELECT
                            SUM(cast(ar.KLObs as float)) as klobs,
                            SUM(cast(ar.KL15 as float)) as kl15,
                            SUM(cast(ar.Barrels as float)) as barrels,
                            SUM(cast(ar.LT as float)) as lt,
                            SUM(cast(ar.MT as float)) as mt
                        FROM Penerimaan p
                        JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                        JOIN (
                            SELECT KLObs, kl15, barrels, LT, MT, cqd.NoReferensi, A.StatusAktivitas
                                FROm SubAktivitasNilaiARsesuaiCQDPipa cqd
                                JOIN Aktivitas A ON A.IdAktivitas = cqd.idAktifitas
                                WHERE A.StatusAktivitas IN('Completed', 'Completed Edit')
                        ) as AR ON AR.NoReferensi = p2.NomorPenimbunan
                        WHERE p.NomorPenerimaan = @NoReferensi
                        group by p.NomorPenerimaan";
                break;
        };
        float klobs = 0, kl15 = 0, barrels = 0, lt = 0, mt = 0;
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (Jenis.ToUpper() == "LPG" || Jenis.ToUpper() == "STSLPG")
                            {
                                mt = reader.IsDBNull(reader.GetOrdinal("mt"))
                                    ? 0f
                                    : Convert.ToSingle(reader["mt"]);
                            }
                            else
                            {
                                klobs = reader.IsDBNull(reader.GetOrdinal("klobs"))
                                    ? 0f
                                    : Convert.ToSingle(reader["klobs"]);
                                kl15 = reader.IsDBNull(reader.GetOrdinal("kl15"))
                                    ? 0f
                                    : Convert.ToSingle(reader["kl15"]);
                                barrels = reader.IsDBNull(reader.GetOrdinal("barrels"))
                                    ? 0f
                                    : Convert.ToSingle(reader["barrels"]);
                                lt = reader.IsDBNull(reader.GetOrdinal("lt"))
                                    ? 0f
                                    : Convert.ToSingle(reader["lt"]);
                                mt = reader.IsDBNull(reader.GetOrdinal("mt"))
                                    ? 0f
                                    : Convert.ToSingle(reader["mt"]);
                            }
                        }
                    }
                }
            }
            return Ok( new {
                success = true,
                klobs = klobs,
                kl15 = kl15,
                barrels = barrels,
                lt = lt,
                mt = mt
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetSFBDValue")]
    public IActionResult GetSFBDValue(string? NoReferensi, string? Jenis = "BBM")
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string sqlData = "";
        switch (Jenis.ToUpper())
        {
            case "BBM":
                sqlData = @"SELECT TOP 1 klobs, kl15, barrels, lt, mt FROM SubaktivitasNilaiSFBD WHERE NoReferensi = @NoReferensi";
                break;
            case "STSBBM":
                sqlData = @"SELECT TOP 1 klobs, kl15, barrels, lt, mt FROM SubaktivitasNilaiSFBDSTSPnrBBM WHERE NoReferensi = @NoReferensi";
                break;
            case "LPG":
                sqlData = @"SELECT TOP 1 mt FROM SubAktivitasNilaiSFBDLPG WHERE NoReferensi = @NoReferensi";
                break;
            case "STSLPG":
                sqlData = @"SELECT TOP 1 mt FROM SubAktivitasNilaiSFBDSTSLPG WHERE NoReferensi = @NoReferensi";
                break;
            case "RTW":
                sqlData = @"SELECT TOP 1 SFBD_KL_Obs as klobs, SFBD_KL_15 as kl15, SFBD_Barrels as barrels, SFBD_LT as lt, SFBD_MT as mt FROM SubAktivitasNilaiSFBDRTW WHERE NoReferensi = @NoReferensi";
                break;
            case "TRUCK":
                sqlData = @"SELECT TOP 1 BD_KLObs as klobs, BD_KL15 as kl15, BD_Barrels as barrels, BD_LT as lt, BD_MT as mt FROM SubAktivitasFormInputNilaiBD WHERE NoReferensi = @NoReferensi";
                break;
        };
        string klobs = "", kl15 = "", barrels = "", lt = "", mt = "";
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (Jenis.ToUpper() == "LPG" || Jenis.ToUpper() == "STSLPG")
                            {
                                mt = reader["mt"]?.ToString() ?? "";
                            } 
                            else
                            {
                                klobs = reader["klobs"]?.ToString() ?? "";
                                kl15 = reader["kl15"]?.ToString() ?? "";
                                barrels = reader["barrels"]?.ToString() ?? "";
                                lt = reader["lt"]?.ToString() ?? "";
                                mt = reader["mt"]?.ToString() ?? "";    
                            }
                        }
                    }
                }
            }
            return Ok( new {
                success = true,
                klobs = klobs,
                kl15 = kl15,
                barrels = barrels,
                lt = lt,
                mt = mt
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetADValue")]
    public IActionResult GetADValue(string? NoReferensi)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string sqlData = "SELECT TOP 1 KL_Obs, ApakahAdaROB FROM SubAktivitasFormInputNilaiAktualDischarge WHERE NoReferensi = @NoReferensi";
        string klobs = "";
        bool isROB = false;
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            klobs = reader["KL_Obs"]?.ToString() ?? "";
                            isROB = reader["ApakahAdaROB"] == DBNull.Value ? false : Convert.ToBoolean(reader["ApakahAdaROB"]);
                        }
                    }
                }
            }
            return Ok( new {
                success = true,
                klobs = klobs,
                isROB = isROB
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetSFBLValue")]
    public IActionResult GetSFBLValue(string? NoReferensi, string? Jenis = "BBM")
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string sqlData = "";
        switch (Jenis.ToUpper())
        {
            case "STSBBM":
                sqlData = @"SELECT TOP 1 klobs, kl15, barrels, lt, mt FROM SubaktivitasNilaiSFBLSTSPymBBM WHERE NoReferensi = @NoReferensi";
                break;
            case "STSLPG":
                sqlData = @"SELECT TOP 1 mt FROM SubaktivitasNilaiSFBLSTSPymLPG WHERE NoReferensi = @NoReferensi";
                break;
        };
        string klobs = "", kl15 = "", barrels = "", lt = "", mt = "";
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (Jenis.ToUpper() == "BBM" || Jenis.ToUpper() == "STSBBM")
                            {
                                klobs = reader["klobs"]?.ToString() ?? "";
                                kl15 = reader["kl15"]?.ToString() ?? "";
                                barrels = reader["barrels"]?.ToString() ?? "";
                                lt = reader["lt"]?.ToString() ?? "";
                                mt = reader["mt"]?.ToString() ?? "";
                            }
                            else if (Jenis.ToUpper() == "LPG" || Jenis.ToUpper() == "STSLPG")
                            {
                                mt = reader["mt"]?.ToString() ?? "";
                            }
                        }
                    }
                }
            }
            return Ok( new {
                success = true,
                klobs = klobs,
                kl15 = kl15,
                barrels = barrels,
                lt = lt,
                mt = mt
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetBLALBDValue")]
    public IActionResult GetBLALBDValue(string? NoReferensi)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string sqlData = @"SELECT TOP 1 sa.BL_klobs, sa.BL_kl15, sa.BL_barrels, sa.BL_lt, sa.BL_mt, sa.AL_klobs, sa.AL_kl15, sa.AL_barrels, sa.AL_lt, sa.AL_mt, sa.BD_klobs, sa.BD_kl15, sa.BD_barrels, sa.BD_lt, sa.BD_mt, pn.Refinery
                           FROM SubaktivitasNilaiBLALBDPipa sa
                           LEFT JOIN Penerimaan pn ON sa.NoReferensi = pn.NomorPenerimaan
                           LEFT JOIN Penimbunan pb ON pn.IdPenerimaan = pb.IdPenerimaan
                           WHERE pb.NomorPenimbunan = @NoReferensi;
                        ";
        string bl_klobs = "", bl_kl15 = "", bl_barrels = "", bl_lt = "", bl_mt = "", al_klobs = "", al_kl15 = "", al_barrels = "", al_lt = "", al_mt = "", bd_klobs = "", bd_kl15 = "", bd_barrels = "", bd_lt = "", bd_mt = "";
        bool isRefinery = false;
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bl_klobs = reader["BL_klobs"]?.ToString() ?? "";
                            bl_kl15 = reader["BL_kl15"]?.ToString() ?? "";
                            bl_barrels = reader["BL_barrels"]?.ToString() ?? "";
                            bl_lt = reader["BL_lt"]?.ToString() ?? "";
                            bl_mt = reader["BL_mt"]?.ToString() ?? "";
                            al_klobs = reader["AL_klobs"]?.ToString() ?? "";
                            al_kl15 = reader["AL_kl15"]?.ToString() ?? "";
                            al_barrels = reader["AL_barrels"]?.ToString() ?? "";
                            al_lt = reader["AL_lt"]?.ToString() ?? "";
                            al_mt = reader["AL_mt"]?.ToString() ?? "";
                            bd_klobs = reader["BD_klobs"]?.ToString() ?? "";
                            bd_kl15 = reader["BD_kl15"]?.ToString() ?? "";
                            bd_barrels = reader["BD_barrels"]?.ToString() ?? "";
                            bd_lt = reader["BD_lt"]?.ToString() ?? "";
                            bd_mt = reader["BD_mt"]?.ToString() ?? "";
                            isRefinery = reader["Refinery"] == DBNull.Value ? false : Convert.ToBoolean(reader["Refinery"]);
                        }
                    }
                }
            }
            return Ok( new {
                success = true,
                bl_klobs = bl_klobs,
                bl_kl15 = bl_kl15,
                bl_barrels = bl_barrels,
                bl_lt = bl_lt,
                bl_mt = bl_mt,
                al_klobs = al_klobs,
                al_kl15 = al_kl15,
                al_barrels = al_barrels,
                al_lt = al_lt,
                al_mt = al_mt,
                bd_klobs = bd_klobs,
                bd_kl15 = bd_kl15,
                bd_barrels = bd_barrels,
                bd_lt = bd_lt,
                bd_mt = bd_mt,
                isRefinery = isRefinery
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetBLSFALValue")]
    public IActionResult GetBLSFALValue(string? NoReferensi, string? Jenis = "BBM")
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string sqlData = "";
        switch (Jenis.ToUpper())
        {
            case "BBM":
                sqlData = "SELECT TOP 1 BL_klobs, BL_kl15, BL_barrels, BL_lt, BL_mt, SFAL_klobs, SFAL_kl15, SFAL_barrels, SFAL_lt, SFAL_mt FROM SubaktivitasNilaiBLSFAL WHERE NoReferensi = @NoReferensi";
                break;
            case "STSBBM":
                sqlData = "SELECT TOP 1 BL_klobs, BL_kl15, BL_barrels, BL_lt, BL_mt, SFAL_klobs, SFAL_kl15, SFAL_barrels, SFAL_lt, SFAL_mt FROM SubaktivitasNilaiBLSFALSTSPnrBBM WHERE NoReferensi = @NoReferensi";
                break;
            case "LPG":
                sqlData = "SELECT TOP 1  BL_mt, SFAL_mt FROM SubAktivitasNilaiBLSFALLPG WHERE NoReferensi = @NoReferensi";
                break;
            case "STSLPG":
                sqlData = "SELECT TOP 1  BL_mt, SFAL_mt FROM SubAktivitasNilaiBLSFALSTSLPG WHERE NoReferensi = @NoReferensi";
                break;
            case "RTW":
                sqlData = "SELECT TOP 1 BL_klobs, BL_kl15, BL_barrels, BL_lt, BL_mt, SFAL_klobs, SFAL_kl15, SFAL_barrels, SFAL_lt, SFAL_mt FROM SubAktivitasFormInputBLnSFALRTW WHERE NoReferensi = @NoReferensi";
                break;
            case "TRUCK":
                sqlData = "SELECT TOP 1 BL_klobs, BL_kl15, BL_barrels, BL_lt, BL_mt, AL_klobs AS SFAL_klobs, AL_kl15 AS SFAL_kl15, AL_barrels AS SFAL_barrels, AL_lt AS SFAL_lt, AL_mt AS SFAL_mt FROM SubAktivitasFormInputNilaiBLnAL WHERE NoReferensi = @NoReferensi";
                break;
        };
        string bl_klobs = "", bl_kl15 = "", bl_barrels = "", bl_lt = "", bl_mt = "", sfal_klobs = "", sfal_kl15 = "", sfal_barrels = "", sfal_lt = "", sfal_mt = "";
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (Jenis.ToUpper() == "LPG" || Jenis.ToUpper() == "STSLPG")
                            {
                                bl_mt = reader["BL_mt"]?.ToString() ?? "";
                                sfal_mt = reader["SFAL_mt"]?.ToString() ?? "";
                            }
                            else
                            {
                                bl_klobs = reader["BL_klobs"]?.ToString() ?? "";
                                bl_kl15 = reader["BL_kl15"]?.ToString() ?? "";
                                bl_barrels = reader["BL_barrels"]?.ToString() ?? "";
                                bl_lt = reader["BL_lt"]?.ToString() ?? "";
                                bl_mt = reader["BL_mt"]?.ToString() ?? "";
                                sfal_klobs = reader["SFAL_klobs"]?.ToString() ?? "";
                                sfal_kl15 = reader["SFAL_kl15"]?.ToString() ?? "";
                                sfal_barrels = reader["SFAL_barrels"]?.ToString() ?? "";
                                sfal_lt = reader["SFAL_lt"]?.ToString() ?? "";
                                sfal_mt = reader["SFAL_mt"]?.ToString() ?? "";
                            }
                        }
                    }
                }
            }
            return Ok( new {
                success = true,
                bl_klobs = bl_klobs,
                bl_kl15 = bl_kl15,
                bl_barrels = bl_barrels,
                bl_lt = bl_lt,
                bl_mt = bl_mt,
                sfal_klobs = sfal_klobs,
                sfal_kl15 = sfal_kl15,
                sfal_barrels = sfal_barrels,
                sfal_lt = sfal_lt,
                sfal_mt = sfal_mt
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetNewBLValue")]
    public IActionResult GetNewBLValue(string? NoReferensi, string? Jenis = "BBM")
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            string blSfalQuery = "", arQuery = "";
            switch(Jenis.ToUpper())
            {
                case "BBM":
                    blSfalQuery = "SELECT TOP 1 BL_klobs, BL_kl15, BL_barrels, BL_lt, BL_mt FROM SubaktivitasNilaiBLSFAL WHERE NoReferensi = @NoReferensi";
                    arQuery = @"SELECT
                                    SUM(cast(ar.KL_Obs as DECIMAL(18,3))) as klobs,
                                    SUM(cast(ar.KL_15 as DECIMAL(18,3))) as kl15,
                                    SUM(cast(ar.Barrels as DECIMAL(18,3))) as barrels,
                                    SUM(cast(ar.LT as DECIMAL(18,3))) as lt,
                                    SUM(cast(ar.MT as DECIMAL(18,3))) as mt
                                FROM Penerimaan p
                                JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                                JOIN SubAktivitasNilaiARsesuaiCQD ar on p2.NomorPenimbunan = ar.NoReferensi
                                WHERE p.NomorPenerimaan = @NoReferensi
                                group by p.NomorPenerimaan";
                    break;
                case "STSBBM":
                    blSfalQuery = "SELECT TOP 1 BL_klobs, BL_kl15, BL_barrels, BL_lt, BL_mt FROM SubaktivitasNilaiBLSFALSTSPnrBBM WHERE NoReferensi = @NoReferensi";
                    arQuery = @"SELECT
                                    SUM(cast(ar.AR_KLObs as DECIMAL(18,3))) as klobs,
                                    SUM(cast(ar.AR_KL15 as DECIMAL(18,3))) as kl15,
                                    SUM(cast(ar.AR_Barrels as DECIMAL(18,3))) as barrels,
                                    SUM(cast(ar.AR_LT as DECIMAL(18,3))) as lt,
                                    SUM(cast(ar.AR_MT as DECIMAL(18,3))) as mt
                                FROM Penerimaan p
                                JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                                JOIN SubAktivitasFormNilaiSFALARSTSPymBBM ar on p2.NomorPenimbunan = ar.NoReferensi
                                WHERE p.NomorPenerimaan = @NoReferensi
                                group by p.NomorPenerimaan";
                    break;
                case "RTW":
                    blSfalQuery = "SELECT TOP 1 BL_klobs, BL_kl15, BL_barrels, BL_lt, BL_mt FROM SubAktivitasFormInputBLnSFALRTW WHERE NoReferensi = @NoReferensi";
                    arQuery = @"SELECT
                                    SUM(cast(ar.KL_Obs as DECIMAL(18,3))) as klobs,
                                    SUM(cast(ar.KL_15 as DECIMAL(18,3))) as kl15,
                                    SUM(cast(ar.Barrels as DECIMAL(18,3))) as barrels,
                                    SUM(cast(ar.LT as DECIMAL(18,3))) as lt,
                                    SUM(cast(ar.MT as DECIMAL(18,3))) as mt
                                FROM Penerimaan p
                                JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                                JOIN SubAktivitasARSesuaiCQDRTW ar on p2.NomorPenimbunan = ar.NoReferensi
                                WHERE p.NomorPenerimaan = @NoReferensi
                                group by p.NomorPenerimaan";
                    break;
                case "LPG":
                    blSfalQuery = "SELECT TOP 1 0 as klobs, 0 as kl15, 0 as barrels, 0 as lt, BL_mt FROM SubAktivitasNilaiBLSFALLPG WHERE NoReferensi = @NoReferensi";
                    arQuery = @"SELECT
                                    0 as klobs,
                                    0 as kl15,
                                    0 as barrels,
                                    0 as lt,
                                    SUM(cast(ar.MT as DECIMAL(18,3))) as mt
                                FROM Penerimaan p
                                JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                                JOIN SubAktivitasNilaiARsesuaiCQDLPG ar on p2.NomorPenimbunan = ar.NoReferensi
                                WHERE p.NomorPenerimaan = @NoReferensi
                                group by p.NomorPenerimaan";
                    break;
                case "STSLPG":
                    blSfalQuery = "SELECT TOP 1 0 as klobs, 0 as kl15, 0 as barrels, 0 as lt, BL_mt FROM SubAktivitasNilaiBLSFALSTSLPG WHERE NoReferensi = @NoReferensi";
                    arQuery = @"SELECT
                                    0 as klobs,
                                    0 as kl15,
                                    0 as barrels,
                                    0 as lt,
                                    SUM(cast(ar.AR_MT as DECIMAL(18,3))) as mt
                                FROM Penerimaan p
                                JOIN dbo.Penimbunan P2 on p.IdPenerimaan = P2.IdPenerimaan
                                JOIN SubAktivitasFormNilaiSFALARSTSPymLPG ar on p2.NomorPenimbunan = ar.NoReferensi
                                WHERE p.NomorPenerimaan = @NoReferensi
                                group by p.NomorPenerimaan";
                    break;
            };
            var blValues = GetValuesFromDb(blSfalQuery, NoReferensi);
            var arValues = GetValuesFromDb(arQuery, NoReferensi);
            return Ok(new
            {
                success = true,
                klobs = blValues.Item1 - arValues.Item1,
                kl15 = blValues.Item2 - arValues.Item2,
                barrels = blValues.Item3 - arValues.Item3,
                lt = blValues.Item4 - arValues.Item4,
                mt = blValues.Item5 - arValues.Item5
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    private (float, float, float, float, float) GetValuesFromDb(string sqlQuery, string? noReferensi)
    {
        using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
        {
            sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(noReferensi));
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    var klobs = reader.IsDBNull(0) ? 0f : Convert.ToSingle(reader.GetValue(0));
                    var kl15 = reader.IsDBNull(1) ? 0f : Convert.ToSingle(reader.GetValue(1));
                    var barrels = reader.IsDBNull(2) ? 0f : Convert.ToSingle(reader.GetValue(2));
                    var lt = reader.IsDBNull(3) ? 0f : Convert.ToSingle(reader.GetValue(3));
                    var mt = reader.IsDBNull(4) ? 0f : Convert.ToSingle(reader.GetValue(4));
                    return (klobs, kl15, barrels, lt, mt);
                }
            }
        }
        return (0f, 0f, 0f, 0f, 0f);
    }

    [HttpGet("SetRedirectSession")]
    public IActionResult SetRedirectSession() {
        if (!IsLoggedIn()) {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try {
            Session.SetBool("RedirectToAktivitasList", true);
            return Ok( new { success = true });
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetRedirectSession")]
    public IActionResult GetRedirectSession() {
        if (!IsLoggedIn()) {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try {
            bool redirect = Session.GetBool("RedirectToAktivitasList");
            bool currentSession = false;
            if (redirect) {
                Session.SetBool("RedirectToAktivitasList", false);
                currentSession = Session.GetBool("RedirectToAktivitasList");
                return Ok(new { redirect = true, currentSession = currentSession });
            }
            currentSession = Session.GetBool("RedirectToAktivitasList");
            return Ok(new { redirect = false, currentSession = currentSession });
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("CheckIdPositionIsMapped")]
    public IActionResult CheckIdPositionIsMapped() {
        if (!IsLoggedIn()) {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try {
            string sessionInfo = Session.GetString("IdPositionIsNotMapped");
            string userLevel = CurrentUserLevel().ToString();
            string idPos = CurrentUserInfo("IdPosition")?.ToString();
            if (userLevel == "-1" || userLevel == "3") {
                return Ok(new { isNotMapped = false });
            }
            if (string.IsNullOrEmpty(idPos)) {
                Session.SetString("IdPositionIsNotMapped", "n");
                return Ok(new { isNotMapped = true });
            }
            if (sessionInfo == "y") {
                Session.SetString("IdPositionIsNotMapped", "n");
                return Ok(new { isNotMapped = true });
            }
            int count = 0;
            string sql = "SELECT COUNT(IdPosition) AS CountIdPos FROM MappingPosition WHERE IdPosition = @IdPosition";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdPosition", idPos);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader.HasRows)
                        {
                            count = reader["CountIdPos"] != DBNull.Value ? Convert.ToInt32(reader["CountIdPos"]) : 0;
                        }
                    }
                }
            }
            if (sessionInfo != "n" && count <= 0) {
                Session.SetString("IdPositionIsNotMapped", "n");
                return Ok(new { isNotMapped = true });
            }
            Session.SetString("IdPositionIsNotMapped", "n");
            return Ok(new { isNotMapped = false });
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, ex);
        }
    }

    [HttpGet("GetRValue")]
    public IActionResult GetRValue(string? NoReferensi, string? Menu, string? Jenis = "BBM") {
        if (!IsLoggedIn()) {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            float R1 = 0, R2 = 0, R3 = 0, R4 = 0;
            string StatusSFBD = "", StatusAR = "", arIdTemplateAktivitas = "", sfbdIdTemplateAktivitas = "";
            string sqlData = "";
            switch (Jenis.ToUpper())
            {
                case "BBM":
                    sqlData = @"SELECT
                                        BLSF.SFAL_barrels AS SFAL,
                                        BLSF.BL_barrels AS BL,
                                        SF.barrels AS SFBD,
                                        SUM(CAST(AR.Barrels AS DECIMAL(18,3))) AS AR,
                                        ISNULL(SB.NewBl_barrels, 0) AS NewBL
                                    FROM
                                        SubaktivitasNilaiBLSFAL AS BLSF
                                    LEFT JOIN
                                        SubaktivitasNilaiSFBD AS SF ON BLSF.NoReferensi = SF.NoReferensi
                                    JOIN
                                        Penerimaan Pr ON pr.NomorPenerimaan = SF.NoReferensi
                                    LEFT JOIN
                                        Penimbunan Pb ON pb.IdPenerimaan = pr.IdPenerimaan
                                    LEFT JOIN (
                                        SELECT AR.*, A.StatusAktivitas
                                        FROM SubAktivitasNilaiARsesuaiCQD AS AR
                                        JOIN Aktivitas A ON A.IdAktivitas = AR.idAktifitas
                                        WHERE A.StatusAktivitas IN ('Completed', 'Completed Edit')
                                    ) AS AR ON Pb.NomorPenimbunan = AR.NoReferensi
                                    LEFT JOIN SubAktivitasSFADNewBL AS SB ON SB.NoReferensi = PR.NomorPenerimaan
                                    WHERE
                                        BLSF.NoReferensi = @NoReferensi
                                    GROUP BY
                                        BLSF.SFAL_barrels, BLSF.BL_barrels, SF.barrels, SB.NewBl_barrels;";
                    arIdTemplateAktivitas = "37";
                    sfbdIdTemplateAktivitas = "6";
                    break;
                case "STSBBM":
                    sqlData = @$"SELECT
                                    BLSF.SFAL_barrels AS SFAL,
                                    BLSF.BL_barrels AS BL,
                                    SF.barrels AS SFBD,
                                    SUM(CAST(AR.AR_barrels AS DECIMAL(18,3))) AS AR,
                                    ISNULL(SB.NewBl_barrels, 0) AS NewBL
                                FROM
                                    SubaktivitasNilaiBLSFALSTSPnrBBM AS BLSF
                                LEFT JOIN
                                    SubaktivitasNilaiSFBDSTSPnrBBM AS SF ON BLSF.NoReferensi = SF.NoReferensi
                                JOIN
                                    Penerimaan Pr ON pr.NomorPenerimaan = SF.NoReferensi
                                LEFT JOIN
                                    Penimbunan Pb ON pb.IdPenerimaan = pr.IdPenerimaan
                                LEFT JOIN (
                                    SELECT AR.*, A.StatusAktivitas
                                    FROM SubAktivitasFormNilaiSFALARSTSPymBBM AS AR
                                    JOIN Aktivitas A ON A.IdAktivitas = AR.idAktifitas
                                    { (Menu == "Penimbunan"
                                        ? "WHERE 1=1"
                                        : "WHERE A.StatusAktivitas IN ('Completed', 'Completed Edit')") }
                                ) AS AR ON Pb.NomorPenimbunan = AR.NoReferensi
                                LEFT JOIN SubAktivitasSFADNewBLSTSPnrBBM AS SB ON SB.NoReferensi = PR.NomorPenerimaan
                                WHERE
                                    { (Menu == "Penimbunan" ? "PB.NomorPenimbunan" : "BLSF.NoReferensi") } = @NoReferensi
                                GROUP BY
                                    BLSF.SFAL_barrels, BLSF.BL_barrels, SF.barrels, SB.NewBl_barrels;";
                    arIdTemplateAktivitas = "37";
                    sfbdIdTemplateAktivitas = "192";
                    break;
                case "LPG":
                    sqlData = @"SELECT
                                BLSF.SFAL_mt AS SFAL,
                                BLSF.BL_mt AS BL,
                                SF.mt AS SFBD,
                                SUM(CAST(AR.MT AS DECIMAL(18,3))) AS AR,
                                ISNULL(SB.NewBl_mt, 0) AS NewBL
                            FROM
                                SubAktivitasNilaiBLSFALLPG AS BLSF
                            LEFT JOIN
                                SubAktivitasNilaiSFBDLPG AS SF ON BLSF.NoReferensi = SF.NoReferensi
                            JOIN
                                Penerimaan Pr ON pr.NomorPenerimaan = SF.NoReferensi
                            LEFT JOIN
                                Penimbunan Pb ON pb.IdPenerimaan = pr.IdPenerimaan
                            LEFT JOIN (
                                SELECT AR.*, A.StatusAktivitas
                                FROM SubAktivitasNilaiARsesuaiCQDLPG AS AR
                                JOIN Aktivitas A ON A.IdAktivitas = AR.idAktifitas
                                WHERE A.StatusAktivitas IN ('Completed', 'Completed Edit')
                            ) AS AR ON Pb.NomorPenimbunan = AR.NoReferensi
                            LEFT JOIN SubAktivitasSFADNewBLLPG AS SB ON SB.NoReferensi = PR.NomorPenerimaan
                            WHERE
                                BLSF.NoReferensi = @NoReferensi
                            GROUP BY
                                BLSF.SFAL_mt, BLSF.BL_mt, SF.mt, SB.NewBl_mt;";
                    arIdTemplateAktivitas = "151";
                    sfbdIdTemplateAktivitas = "134";
                    break;
                case "STSLPG":
                    sqlData = @"SELECT
                                BLSF.SFAL_mt AS SFAL,
                                BLSF.BL_mt AS BL,
                                SF.mt AS SFBD,
                                SUM(CAST(AR.AR_MT AS DECIMAL(18,3))) AS AR,
                                ISNULL(SB.NewBl_mt, 0) AS NewBL
                            FROM
                                SubAktivitasNilaiBLSFALSTSLPG AS BLSF
                            LEFT JOIN
                                SubAktivitasNilaiSFBDSTSLPG AS SF ON BLSF.NoReferensi = SF.NoReferensi
                            JOIN
                                Penerimaan Pr ON pr.NomorPenerimaan = SF.NoReferensi
                            LEFT JOIN
                                Penimbunan Pb ON pb.IdPenerimaan = pr.IdPenerimaan
                            LEFT JOIN (
                                SELECT AR.*, A.StatusAktivitas
                                FROM SubAktivitasFormNilaiSFALARSTSPymLPG AS AR
                                JOIN Aktivitas A ON A.IdAktivitas = AR.idAktifitas
                                WHERE A.StatusAktivitas IN ('Completed', 'Completed Edit')
                            ) AS AR ON Pb.NomorPenimbunan = AR.NoReferensi
                            LEFT JOIN SubAktivitasSFADNewBLSTSLPG AS SB ON SB.NoReferensi = PR.NomorPenerimaan
                            WHERE
                                BLSF.NoReferensi = @NoReferensi
                            GROUP BY
                                BLSF.SFAL_mt, BLSF.BL_mt, SF.mt, SB.NewBl_mt;";
                    arIdTemplateAktivitas = "253";
                    sfbdIdTemplateAktivitas = "267";
                    break;
                case "RTW":
                    sqlData = $@"SELECT
                                        BLSF.SFAL_barrels AS SFAL,
                                        BLSF.BL_barrels AS BL,
                                        SF.SFBD_barrels AS SFBD,
                                        SUM(CAST(AR.Barrels AS DECIMAL(18,3))) AS AR,
                                        ISNULL(SB.NewBl_barrels, 0) AS NewBL
                                    FROM
                                        SubAktivitasFormInputBLnSFALRTW AS BLSF
                                    LEFT JOIN
                                        SubAktivitasNilaiSFBDRTW AS SF ON BLSF.NoReferensi = SF.NoReferensi
                                    JOIN
                                        Penerimaan Pr ON pr.NomorPenerimaan = SF.NoReferensi
                                    LEFT JOIN
                                        Penimbunan Pb ON pb.IdPenerimaan = pr.IdPenerimaan
                                    LEFT JOIN (
                                        SELECT AR.*, A.StatusAktivitas
                                        FROM SubAktivitasARSesuaiCQDRTW AS AR
                                        JOIN Aktivitas A ON A.IdAktivitas = AR.idAktifitas
                                        WHERE A.StatusAktivitas IN ('Draft', 'Completed', 'Completed Edit')
                                    ) AS AR ON Pb.NomorPenimbunan = AR.NoReferensi
                                    LEFT JOIN SubAktivitasFormInputNilaiAktDischargeRTW AS SB ON SB.NoReferensi = PR.NomorPenerimaan
                                    WHERE
                                        {((Menu == "NEWBL" || Menu == "BLSFAL" || Menu == "SFBD") ? "BLSF" : "AR")}.NoReferensi = @NoReferensi
                                    GROUP BY
                                        BLSF.SFAL_barrels, BLSF.BL_barrels, SF.SFBD_barrels, SB.NewBl_barrels;";
                    arIdTemplateAktivitas = "397";
                    sfbdIdTemplateAktivitas = "372";
                    break;
                case "TRUCK":
                    sqlData = $@"SELECT
                                        BLSF.AL_klobs AS SFAL,
                                        BLSF.BL_klobs AS BL,
                                        SF.BD_klobs AS SFBD,
                                        SUM(CAST(AR.kl_obs AS DECIMAL(18,3))) AS AR,
                                        0 AS NewBL
                                    FROM
                                        SubAktivitasFormInputNilaiBLnAL AS BLSF
                                    LEFT JOIN
                                        SubAktivitasFormInputNilaiBD AS SF ON BLSF.NoReferensi = SF.NoReferensi
                                    JOIN
                                        Penerimaan Pr ON pr.NomorPenerimaan = SF.NoReferensi
                                    LEFT JOIN
                                        Penimbunan Pb ON pb.IdPenerimaan = pr.IdPenerimaan
                                    LEFT JOIN (
                                        SELECT AR.*, A.StatusAktivitas
                                        FROM SubAktivitasFormInputNilaiARsesuaiCQDTruck AS AR
                                        JOIN Aktivitas A ON A.IdAktivitas = AR.idAktifitas
                                        WHERE A.StatusAktivitas IN ('Draft', 'Completed', 'Completed Edit')
                                    ) AS AR ON Pb.NomorPenimbunan = AR.NoReferensi
                                    WHERE
                                        BLSF.NoReferensi = @NoReferensi
                                    GROUP BY
                                        BLSF.AL_klobs, BLSF.BL_klobs, SF.BD_klobs;";
                    arIdTemplateAktivitas = "436";
                    sfbdIdTemplateAktivitas = "419";
                    break;
                case "PIPA":
                    sqlData = $@"SELECT
                                    SA.AL_barrels AS SFAL,
                                    SA.BL_barrels AS BL,
                                    SA.BD_barrels AS SFBD,
                                    SUM(CAST(AR.Barrels AS DECIMAL(18,3))) AS AR,
                                    0 AS NewBL
                                FROM
                                    SubaktivitasNilaiBLALBDPipa AS SA
                                JOIN
                                    Penerimaan Pr ON pr.NomorPenerimaan = SA.NoReferensi
                                LEFT JOIN
                                    Penimbunan Pb ON pb.IdPenerimaan = pr.IdPenerimaan
                                LEFT JOIN (
                                    SELECT AR.*, A.StatusAktivitas
                                    FROM SubAktivitasNilaiARsesuaiCQDPipa AS AR
                                    JOIN Aktivitas A ON A.IdAktivitas = AR.idAktifitas
                                    WHERE A.StatusAktivitas IN ('Draft', 'Completed', 'Completed Edit')
                                ) AS AR ON Pb.NomorPenimbunan = AR.NoReferensi
                                WHERE
                                    SA.NoReferensi = @NoReferensi
                                GROUP BY
                                    SA.AL_barrels, SA.BL_barrels, SA.BD_barrels;";
                    arIdTemplateAktivitas = "466";
                    sfbdIdTemplateAktivitas = "419";
                    break;
            };
            if (Menu == "AR" && Jenis == "BBM"){
                sqlData = @"SELECT
                                BLSF.SFAL_barrels AS SFAL,
                                BLSF.BL_barrels AS BL,
                                SF.barrels AS SFBD,
                                AR.Barrels AS AR,
                                SB.NewBl_barrels AS NewBL
                            FROM SubAktivitasNilaiARsesuaiCQD AR
                            JOIN Penimbunan pn on pn.NomorPenimbunan = AR.NoReferensi
                            LEFT JOIN dbo.Penerimaan P on pn.IdPenerimaan = P.IdPenerimaan
                            LEFT JOIN SubaktivitasNilaiBLSFAL BLSF on BLSF.NoReferensi = p.NomorPenerimaan
                            LEFT JOIN SubaktivitasNilaiSFBD SF on SF.NoReferensi = p.NomorPenerimaan
                            LEFT JOIN SubAktivitasSFADNewBL SB on SB.NoReferensi = p.NomorPenerimaan
                            WHERE Ar.NoReferensi = @NoReferensi";
            } else if (Menu == "AR" && Jenis == "LPG"){
                sqlData = @"SELECT
                                BLSF.SFAL_mt AS SFAL,
                                BLSF.BL_mt AS BL,
                                SF.mt AS SFBD,
                                AR.MT AS AR,
                                SB.NewBl_mt AS NewBL
                            FROM SubAktivitasNilaiARsesuaiCQDLPG AR
                            JOIN Penimbunan pn on pn.NomorPenimbunan = AR.NoReferensi
                            LEFT JOIN dbo.Penerimaan P on pn.IdPenerimaan = P.IdPenerimaan
                            LEFT JOIN SubAktivitasNilaiBLSFALLPG BLSF on BLSF.NoReferensi = p.NomorPenerimaan
                            LEFT JOIN SubAktivitasNilaiSFBDLPG SF on SF.NoReferensi = p.NomorPenerimaan
                            LEFT JOIN SubAktivitasSFADNewBLLPG SB on SB.NoReferensi = p.NomorPenerimaan
                            WHERE Ar.NoReferensi = @NoReferensi";
            } else if (Menu == "AR" && Jenis == "STSLPG") {
                sqlData = @"SELECT
                                BLSF.SFAL_mt AS SFAL,
                                BLSF.BL_mt AS BL,
                                SF.mt AS SFBD,
                                AR.AR_MT AS AR,
                                SB.NewBl_mt AS NewBL
                            FROM SubAktivitasFormNilaiSFALARSTSPymLPG AR
                            JOIN Penimbunan pn on pn.NomorPenimbunan = AR.NoReferensi
                            LEFT JOIN dbo.Penerimaan P on pn.IdPenerimaan = P.IdPenerimaan
                            LEFT JOIN SubAktivitasNilaiBLSFALSTSLPG BLSF on BLSF.NoReferensi = p.NomorPenerimaan
                            LEFT JOIN SubAktivitasNilaiSFBDSTSLPG SF on SF.NoReferensi = p.NomorPenerimaan
                            LEFT JOIN SubAktivitasSFADNewBLSTSLPG SB on SB.NoReferensi = p.NomorPenerimaan
                            WHERE Ar.NoReferensi = @NoReferensi";
            } else if (Menu == "AR" && Jenis == "Truck") {
                sqlData = @"SELECT
                                BLSF.AL_KLObs AS SFAL,
                                BLSF.BL_KLObs AS BL,
                                SF.BD_KLObs AS SFBD,
                                AR.KL_Obs AS AR,
                                0 AS NewBL
                            FROM SubAktivitasFormInputNilaiARsesuaiCQDTruck AR
                            JOIN Penimbunan pn on pn.NomorPenimbunan = AR.NoReferensi
                            LEFT JOIN dbo.Penerimaan P on pn.IdPenerimaan = P.IdPenerimaan
                            LEFT JOIN SubAktivitasFormInputNilaiBLnAL BLSF on BLSF.NoReferensi = p.NomorPenerimaan
                            LEFT JOIN SubAktivitasFormInputNilaiBD SF on SF.NoReferensi = p.NomorPenerimaan
                            WHERE Ar.NoReferensi = @NoReferensi";
            }
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            float SFAL = reader.IsDBNull(reader.GetOrdinal("SFAL")) 
                                ? 0f 
                                : Convert.ToSingle(reader["SFAL"]);
                            float BL = reader.IsDBNull(reader.GetOrdinal("BL")) 
                                ? 0f 
                                : Convert.ToSingle(reader["BL"]);
                            float SFBD = reader.IsDBNull(reader.GetOrdinal("SFBD")) 
                                ? 0f 
                                : Convert.ToSingle(reader["SFBD"]);
                            float AR = reader.IsDBNull(reader.GetOrdinal("AR")) 
                                ? 0f 
                                : Convert.ToSingle(reader["AR"]);
                            float NewBL = reader.IsDBNull(reader.GetOrdinal("NewBL")) 
                                ? 0f 
                                : Convert.ToSingle(reader["NewBL"]);
                            if (BL != 0) {
                                R1 = (SFAL-BL)/BL;
                                R2 = (SFBD-SFAL)/BL;
                                R3 = ((AR + NewBL) - SFBD) / BL;
                                R4 = (AR-BL)/BL;
                            } else {
                                return Ok( new {
                                    success = false,
                                    message = "Can't calculate R1-R4 value, because BL value is null or 0"
                                });
                            }
                        }
                    }
                }
                response["success"] = true;
                response["R1"] = R1;
                sqlData = "SELECT StatusAktivitas FROM Aktivitas WHERE IdTemplateAktivitas = @SfbdIdTemplate AND No_Referensi = @NoReferensi;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    sqlCommand.Parameters.AddWithValue("@SfbdIdTemplate", sfbdIdTemplateAktivitas);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                        if (reader.Read()) {
                            StatusSFBD = reader["StatusAktivitas"]?.ToString() ?? "";
                        }
                    }
                }

                // sqlData = "SELECT StatusAktivitas FROM Aktivitas WHERE IdTemplateAktivitas = '37' AND No_Referensi = @NoReferensi;";
                // using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                //     sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                //     using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                //         if (reader.Read()) {
                //             StatusAR = reader["StatusAktivitas"]?.ToString() ?? "";
                //         }
                //     }
                // }
                var jumlahAr = 0;
                sqlData = @"SELECT COUNT(*) as JumlahAr
                        FROM Aktivitas A
                        JOIN Penimbunan Pb ON pb.NomorPenimbunan = A.No_Referensi
                        JOIN Penerimaan Pn ON pn.IdPenerimaan = pb.IdPenerimaan
                        WHERE IdTemplateAktivitas = @ArIdAktivitas
                        AND pn.NomorPenerimaan = @NoReferensi AND StatusAktivitas IN('Completed', 'Completed Edit');";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    sqlCommand.Parameters.AddWithValue("@ArIdAktivitas", arIdTemplateAktivitas);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                        if (reader.Read()) {
                            jumlahAr = reader["JumlahAr"] != DBNull.Value ? Convert.ToInt32(reader["JumlahAr"]) : 0;
                        }
                    }
                }
                if (Menu == "BLSFAL") {
                    if (StatusSFBD == "Completed" || StatusSFBD == "Completed Edit") {
                        response["R2"] = R2;
                    }
                    if (jumlahAr > 0) {
                        response["R3"] = R3;
                        response["R4"] = R4;
                    }
                    // response["R2"] = R2;
                    // response["R3"] = R3;
                    // response["R4"] = R4;
                    // if ((StatusAR == "Completed" || StatusAR == "Completed Edit" || StatusAR == "Editing")) {
                    //     response["R3"] = R3;
                    //     response["R4"] = R4;
                    // }
                } else if (Menu == "SFBD") {
                    response["R2"] = R2;
                    if (jumlahAr > 0) {
                        response["R3"] = R3;
                        response["R4"] = R4;
                    }
                    // response["R3"] = R3;
                    // response["R4"] = R4;
                    // if ((StatusAR == "Completed" || StatusAR == "Completed Edit")) {
                    //     response["R3"] = R3;
                    //     response["R4"] = R4;
                    // }
                } else if (Menu == "AR" || Menu == "NEWBL") {
                    response["R2"] = R2;
                    response["R3"] = R3;
                    response["R4"] = R4;
                } else {
                    response["R2"] = R2;
                    response["R3"] = R3;
                    response["R4"] = R4;
                }
            }
            return Json(response);
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetLogValueByIdAktivitas")]
    public IActionResult GetLogValueByIdAktivitas(string? IdAktivitas)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string sqlData = "SELECT a.NamaAktivitas as Aktivitas, log.username as Username, log.status_aktivitas as StatusAktivitas, log.etl_date as Tanggal, log.Catatan FROM log_aktivitas log INNER JOIN Aktivitas a ON log.id_aktivitas = a.IdAktivitas WHERE log.id_aktivitas = @IdAktivitas ORDER BY Tanggal DESC;";
        List<Dictionary<string, object>> resultList = new List<Dictionary<string, object>>();
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", EncodeForXSS(IdAktivitas));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                resultList.Add(new Dictionary<string, object>
                                {
                                    { "Aktivitas", reader["Aktivitas"]?.ToString() ?? "" },
                                    { "Username", reader["Username"]?.ToString() ?? "" },
                                    { "StatusAktivitas", reader["StatusAktivitas"]?.ToString() ?? "" },
                                    { "Tanggal", reader["Tanggal"]?.ToString() ?? "" },
                                    { "Catatan",  reader["Catatan"]?.ToString() ?? ""}
                                });
                            }
                        }
                        else
                        {
                            return Ok(new { success = false, result = resultList });
                        }
                    }
                }
            }
            return Ok(new
            {
                success = true,
                result = resultList
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetWajibUpload")]
    public IActionResult GetWajibUpload(string? IdAktivitas, string? IdDokumen)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        bool WajibUpload = false;
        string sqlData = "SELECT TOP 1 WajibUpload FROM TemplateAktivitasDokumen WHERE IdDokumen = @IdDokumen AND IdTemplateAktivitas = (SELECT IdTemplateAktivitas FROM Aktivitas WHERE IdAktivitas = @IdAktivitas);";
        try {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection()) {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", EncodeForXSS(IdAktivitas));
                    sqlCommand.Parameters.AddWithValue("@IdDokumen", EncodeForXSS(IdDokumen));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                        if (reader.Read()) {
                            WajibUpload = reader["WajibUpload"] != DBNull.Value && (bool)reader["WajibUpload"];
                        }
                    }
                }
            }
            return Ok(new {
                success = true,
                WajibUpload = WajibUpload
            });
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("UpdateAktivitasTabel")]
    public async Task<IActionResult> UpdateAktivitasTabel([FromBody] UpdateAktivitasTabelRequest payload)
    {
        if (!IsLoggedIn())
        {
            throw new LogErrorException(
                "Unauthorized access", 
                StatusCodes.Status401Unauthorized, 
                noReferensi: payload.NoReferensi,
                idProses: int.Parse(payload.IdProses),
                idAktivitas: int.Parse(payload.IdAktivitas)
            );
        }
        string tableName = payload.TableName?.ToString();
        var allowedTables = (await DatabaseQueryHelper.ExecuteSelectListQueryAsync(
            "SELECT URL FROM TemplateAktivitas WHERE TipeAktivitas = 'Tabel';",
            reader => reader.IsDBNull(reader.GetOrdinal("URL")) ? null : reader.GetString(reader.GetOrdinal("URL")),
            noReferensi: payload.NoReferensi,
            idProses: int.Parse(payload.IdProses),
            idAktivitas: int.Parse(payload.IdAktivitas)
        ))
        .Where(x => x != null)
        .ToList();
        if (!allowedTables.Contains(tableName))
        {
            throw new LogErrorException(
                "Invalid Table Name",
                StatusCodes.Status406NotAcceptable, 
                noReferensi: payload.NoReferensi,
                idProses: int.Parse(payload.IdProses),
                idAktivitas: int.Parse(payload.IdAktivitas)
            );
        }
        var listAdd = payload.ItemsAdd;
        var listDelete = payload.DeletedIds;
        var listUpdate = payload.ItemsUpdate;
        if (payload.Status != "Completed" && payload.Status != "Completed Edit")
        {
            if ((listAdd == null || listAdd.Count == 0) &&
                (listDelete == null || listDelete.Count == 0) &&
                (listUpdate == null || listUpdate.Count == 0) && 
                (string.IsNullOrEmpty(payload.Catatan)))
            {
                throw new LogErrorException(
                    "Tidak ada perubahan untuk disimpan.", 
                    StatusCodes.Status400BadRequest, 
                    noReferensi: payload.NoReferensi,
                    idProses: int.Parse(payload.IdProses),
                    idAktivitas: int.Parse(payload.IdAktivitas)
                );
            }
        }
        else
        {
            if (listAdd == null || listAdd.Count == 0)
            {
                int count = await DatabaseQueryHelper.ExecuteSelectSingleAsync<int>(
                    $"SELECT COUNT(*) FROM {tableName} WHERE idAktifitas = @IdAktivitas;",
                    reader => reader.IsDBNull(0) ? 0  : reader.GetInt32(0),
                    new Dictionary<string, object> { { "@IdAktivitas", payload.IdAktivitas } },
                    noReferensi: payload.NoReferensi,
                    idProses: int.Parse(payload.IdProses),
                    idAktivitas: int.Parse(payload.IdAktivitas)
                );
                if (count == 0 || count == listDelete.Count)
                {
                    throw new LogErrorException(
                        "Tidak ada data untuk disubmit.", 
                        StatusCodes.Status400BadRequest, 
                        noReferensi: payload.NoReferensi,
                        idProses: int.Parse(payload.IdProses),
                        idAktivitas: int.Parse(payload.IdAktivitas)
                    );
                }
            }
        }
        DateTime plantTime = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
            "EXEC dbo.GetPlantDateTime @NomorReferensi = @NomorReferensi",
            reader => {
                var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                if (val == null) return DateTime.Now;
                return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
            },
            new Dictionary<string, object> { { "@NomorReferensi", payload.NoReferensi } },
            noReferensi: payload.NoReferensi,
            idProses: int.Parse(payload.IdProses),
            idAktivitas: int.Parse(payload.IdAktivitas)
        );
        foreach (var item in listAdd)
        {
            DateTime plantDateTime = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
                "EXEC dbo.GetPlantDateTime @NomorReferensi = @NomorReferensi",
                reader => {
                    var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                    if (val == null) return DateTime.Now;
                    return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
                },
                new Dictionary<string, object> { { "@NomorReferensi", payload.NoReferensi } },
                noReferensi: payload.NoReferensi,
                idProses: int.Parse(payload.IdProses),
                idAktivitas: int.Parse(payload.IdAktivitas)
            );
            var columns = string.Join(",", item.Keys);
            var parameters = string.Join(",", item.Keys.Select(k => "@" + k));
            string insertQuery = $@"INSERT INTO {tableName} (idAktifitas, idProses, NoReferensi, etlDate, userInput, {columns}) 
                                    VALUES (@IdAktivitas, @IdProses, @NoReferensi, @etlDate, @userInput, {parameters});";
            var paramValues = new Dictionary<string, object>
            {
                { "@IdAktivitas", EncodeForXSS(payload.IdAktivitas) },
                { "@IdProses", int.Parse(payload.IdProses) },
                { "@NoReferensi", EncodeForXSS(payload.NoReferensi) },
                { "@etlDate", plantDateTime },
                { "@userInput", CurrentUserName() }
            };
            foreach (var kv in item)
            {
                object value = kv.Value ?? DBNull.Value;
                if (kv.Key == "TanggalJam" 
                    || kv.Key == "Tanggal" 
                    || kv.Key == "TanggalQuantityAwal" 
                    || kv.Key == "TanggalQuantityAkhir")
                {
                    if (DateTime.TryParse(kv.Value?.ToString(), out var parsedDate))
                    {
                        value = parsedDate;
                    }
                    else
                    {
                        value = DBNull.Value;
                    }
                    paramValues.Add("@" + kv.Key, value);
                }
                else
                {
                    paramValues.Add("@" + kv.Key, EncodeForXSS(value.ToString()));
                }
            }
            await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                insertQuery, 
                paramValues,
                noReferensi: payload.NoReferensi,
                idProses: int.Parse(payload.IdProses),
                idAktivitas: int.Parse(payload.IdAktivitas)
            );
        }
        foreach (var item in listDelete)
        {
            await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                $"DELETE FROM {tableName} WHERE id = @Id", 
                new Dictionary<string, object> { { "@Id", item } },
                noReferensi: payload.NoReferensi,
                idProses: int.Parse(payload.IdProses),
                idAktivitas: int.Parse(payload.IdAktivitas)
            );
        }
        foreach (var item in listUpdate)
        {
            DateTime plantDateTime = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
                "EXEC dbo.GetPlantDateTime @NomorReferensi = @NomorReferensi",
                reader => {
                    var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                    if (val == null) return DateTime.Now;
                    return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
                },
                new Dictionary<string, object> { { "@NomorReferensi", payload.NoReferensi } },
                noReferensi: payload.NoReferensi,
                idProses: int.Parse(payload.IdProses),
                idAktivitas: int.Parse(payload.IdAktivitas)
            );
            var setClauses = string.Join(",", item.Where(kv => kv.Key != "id").Select(kv => $"{kv.Key} = @{kv.Key}"));
            string updateQuery = $"UPDATE {tableName} SET {setClauses}, LastUpdatedBy = @LastUpdatedBy, lastUpdatedDate = @lastUpdatedDate WHERE id = @id";
            var parameters = new Dictionary<string, object>
            {
                { "@LastUpdatedBy", EncodeForXSS(CurrentUserName()) },
                { "@lastUpdatedDate", plantDateTime }
            };
            foreach (var kv in item)
            {
                object value = kv.Value ?? DBNull.Value;
                if (kv.Key == "TanggalJam" 
                    || kv.Key == "Tanggal" 
                    || kv.Key == "TanggalQuantityAwal" 
                    || kv.Key == "TanggalQuantityAkhir")
                {
                    if (DateTime.TryParse(kv.Value?.ToString(), out var parsedDate))
                    {
                        value = parsedDate;
                    }
                    else
                    {
                        value = DBNull.Value;
                    }
                    parameters.Add("@" + kv.Key, value);
                }
                else
                {
                    parameters.Add("@" + kv.Key, EncodeForXSS(value.ToString()));
                }
            }
            await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                updateQuery, 
                parameters,
                noReferensi: payload.NoReferensi,
                idProses: int.Parse(payload.IdProses),
                idAktivitas: int.Parse(payload.IdAktivitas)
            );
        }
        string updateStatusQuery = "";
        if (payload.Status == "Completed" || payload.Status == "Completed Edit")
        {
            updateStatusQuery = @"UPDATE Aktivitas 
                                SET StatusAktivitas = @Status, 
                                    DiperbaruiOleh = @DiperbaruiOleh, 
                                    TanggalDiperbarui = @TanggalDiperbarui 
                                WHERE IdAktivitas = @IdAktivitas;
                                UPDATE Aktivitas 
                                SET TanggalSelesai = @TanggalDiperbarui 
                                WHERE IdAktivitas = @IdAktivitas AND TanggalSelesai IS NULL;";
        }
        else
        {
            updateStatusQuery = @"UPDATE Aktivitas 
                                SET StatusAktivitas = @Status, 
                                    DiperbaruiOleh = @DiperbaruiOleh, 
                                    TanggalDiperbarui = @TanggalDiperbarui 
                                WHERE IdAktivitas = @IdAktivitas;
                                UPDATE Aktivitas 
                                SET TanggalMulai = @TanggalDiperbarui 
                                WHERE IdAktivitas = @IdAktivitas AND TanggalMulai IS NULL;";
        }
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            updateStatusQuery, 
            new Dictionary<string, object> { 
                { "@Status", EncodeForXSS(payload.Status) }, 
                { "@DiperbaruiOleh", CurrentUserName() }, 
                { "@TanggalDiperbarui", plantTime }, 
                { "@IdAktivitas", EncodeForXSS(payload.IdAktivitas) }
            },
            noReferensi: payload.NoReferensi,
            idProses: int.Parse(payload.IdProses),
            idAktivitas: int.Parse(payload.IdAktivitas)
        );
        await AddLogAktivitas(int.Parse(payload.IdAktivitas), payload.Status, payload.Catatan);
        await UpdateStatusProsesByIdAktivitas(int.Parse(payload.IdAktivitas));
        await UpdateTanggalAktivitas(int.Parse(payload.IdAktivitas));
        if (tableName == "SubAktivitasHasilPemeriksaanPipa")
        {
            await GenerateDynamicETCETA(payload.NoReferensi);
        }
        return Ok( new
        {
            success = true,
            message = "Perubahan berhasil disimpan."
        });
    }

    [HttpPost("CheckDuplicateReferensi")]
    public IActionResult CheckDuplicateReferensi([FromBody] CheckDuplicateReferensiRequest payload) 
    {
        if (!IsLoggedIn())
        {
            var response = new
            {
                success = false,
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan."
            };
            return Json(response);
        }
        List<string> allowedTables = new List<string> {
            "Penerimaan", 
            "Penimbunan", 
            "Penyaluran", 
            "PenimbunanPenyaluran", 
            "RencanaPenyaluran", 
            "SamplingLabTest",
            "ClosingStock"
        };
        string tableName = payload.Referensi?.ToString();
        if (!allowedTables.Contains(tableName))
        {
            var response = new { success = false, message = "Referensi table tidak valid." };
            return Json(response);
        }
        var Data = payload.Data;
        bool duplicate = false;
        try 
        {
            var columns = string.Join(" AND ", Data.Keys.Select(k => k + " = @" + k));
            string sql = $@"SELECT COUNT(*) FROM {tableName} WHERE {columns};";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    foreach (var kv in Data)
                    {
                        object value = kv.Value ?? DBNull.Value;
                        cmd.Parameters.AddWithValue("@" + kv.Key, value.ToString());
                    }
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        duplicate = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Json( new {
                success = false,
                message = "Terjadi kesalahan pada server.",
                error = ex
            });
        }
        return Ok(new { success = true, duplicate = duplicate });
    }

    [HttpPost("update_lop_r1")]
    public IActionResult update_lop_r1([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." 
            };
            return Json(response);
        }
        try
        {
            float R1 = 0;
            string sqlData = @"";
            int idDokumen = 47;
            switch (data.Jenis.ToUpper())
            {
                case "BBM":
                    sqlData = @"SELECT 
                                BL_Barrels AS BL,
                                SFAL_Barrels AS SFAL
                            FROM SubAktivitasNilaiBLSFALPenyaluran
                            WHERE idAktifitas = @IdAktivitas;";
                    idDokumen = 47;
                    break;
                case "STSBBM":
                    sqlData = @"SELECT 
                                BL_Barrels AS BL,
                                SFAL_Barrels AS SFAL
                            FROM SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM
                            WHERE idAktifitas = @IdAktivitas;";
                    idDokumen = 156;
                    break;
                case "LPG":
                    sqlData = @"SELECT 
                                BL_MT AS BL,
                                SFAL_MT AS SFAL
                            FROM SubAktivitasNilaiBLSFALPenyaluranLPG
                            WHERE idAktifitas = @IdAktivitas;";
                    idDokumen = 106;
                    break;
                case "STSLPG":
                    sqlData = @"SELECT 
                                BL_MT AS BL,
                                SFAL_MT AS SFAL
                            FROM SubAktivitasNilaiBLSFALPenyaluranSTSPyrLPG
                            WHERE idAktifitas = @IdAktivitas;";
                    idDokumen = 202;
                    break;
            };
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", EncodeForXSS(data.IdAktivitas));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            float SFAL = reader.IsDBNull(reader.GetOrdinal("SFAL")) 
                                ? 0f 
                                : Convert.ToSingle(reader["SFAL"]);
                            float BL = reader.IsDBNull(reader.GetOrdinal("BL")) 
                                ? 0f 
                                : Convert.ToSingle(reader["BL"]);
                            if (BL != 0)
                            {
                                R1 = ((SFAL - BL) / BL) * 100;
                            }
                            else
                            {
                                return Ok(new
                                {
                                    success = false,
                                    message = "Can't calculate R1 value, because BL value is null or 0"
                                });
                            }
                        }
                    }
                }
                if (R1 < -0.125)
                {
                    sqlData = "UPDATE AktivitasDokumen SET WajibUpload = CAST(1 AS BIT) WHERE NoReferensi = @NoReferensi AND IdProses = @IdProses AND IdDokumen = @IdDokumen AND StatusUpload <> 'Uploaded';";
                }
                else
                {
                    sqlData = "UPDATE AktivitasDokumen SET WajibUpload = CAST(0 AS BIT) WHERE NoReferensi = @NoReferensi AND IdProses = @IdProses AND IdDokumen = @IdDokumen AND StatusUpload <> 'Uploaded';";
                }
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(data.NoReferensi));
                    sqlCommand.Parameters.AddWithValue("@IdProses", EncodeForXSS(data.IdProses));
                    sqlCommand.Parameters.AddWithValue("@IdDokumen", idDokumen);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    // helper function update dokumen wajib upload
    private void UpdateDokumenWajibUpload(SqlConnection conn, string noReferensi, bool wajib, params int[] dokIds)
    {
        if (dokIds == null || dokIds.Length == 0)
            return; // tidak ada dokumen, tidak usah update

        // buat parameter untuk IN clause
        var idParams = dokIds
            .Select((id, idx) => "@id" + idx)
            .ToArray();
        string sql = $@"
            UPDATE AktivitasDokumen 
            SET WajibUpload = @WajibUpload
            WHERE NoReferensi = @NoReferensi 
            AND IdDokumen IN ({string.Join(", ", idParams)})
            AND StatusUpload <> 'Uploaded'";
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(noReferensi));
        cmd.Parameters.Add("@WajibUpload", SqlDbType.Bit).Value = wajib;

        // binding id parameter
        for (int i = 0; i < dokIds.Length; i++)
        {
            cmd.Parameters.AddWithValue(idParams[i], dokIds[i]);
        }
        cmd.ExecuteNonQuery();
    }

    // Refactor Cognitive Complexity
    [HttpPost("update_lop_r2")]
    public IActionResult update_lop_r2([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = "Not authorized."
            };
            return Json(response);
        }
        try
        {
            float R2 = 0;
            int idDokumen = 11;
            string sqlData = "", tipeProduk = "", jenisPlant = "";
            sqlData = @"SELECT BLSF.BL_barrels AS BL, BLSF.SFAL_barrels AS SFAL, SF.barrels AS SFBD 
                            FROM SubaktivitasNilaiBLSFAL BLSF LEFT JOIN SubaktivitasNilaiSFBD SF
                            ON BLSF.NoReferensi = SF.NoReferensi
                            WHERE BLSF.NoReferensi = @NoReferensi;";
            using var sqlConnection = GetConnection("Db").OpenConnection();
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 TipeProduk FROM MasterProduk WHERE NoProduk = (SELECT TOP 1 KodeProduk FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi)", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                tipeProduk = cmd.ExecuteScalar()?.ToString() ?? "";
            }
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 JenisPlant FROM MasterPlant WHERE IdPlant = (SELECT TOP 1 IdPlant FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi)", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                jenisPlant = cmd.ExecuteScalar()?.ToString() ?? "";
            }
            if (jenisPlant.ToUpper() == "STS" && tipeProduk.ToUpper() == "BBM") {
                sqlData = @"SELECT BLSF.BL_barrels AS BL, BLSF.SFAL_barrels AS SFAL, SF.barrels AS SFBD 
                            FROM SubaktivitasNilaiBLSFALSTSPnrBBM BLSF LEFT JOIN SubaktivitasNilaiSFBDSTSPnrBBM SF
                            ON BLSF.NoReferensi = SF.NoReferensi
                            WHERE BLSF.NoReferensi = @NoReferensi;";
                idDokumen = 122;
            } else if (jenisPlant.ToUpper() == "STS" && tipeProduk.ToUpper() == "LPG") {
                sqlData = @"SELECT BLSF.BL_mt AS BL, BLSF.SFAL_mt AS SFAL, SF.mt AS SFBD 
                            FROM SubAktivitasNilaiBLSFALSTSLPG BLSF LEFT JOIN SubaktivitasNilaiSFBDSTSLPG SF
                            ON BLSF.NoReferensi = SF.NoReferensi
                            WHERE BLSF.NoReferensi = @NoReferensi;";
                idDokumen = 176;
            } else if (tipeProduk.ToUpper() == "LPG") {
                sqlData = @"SELECT BLSF.BL_mt AS BL, BLSF.SFAL_mt AS SFAL, SF.mt AS SFBD 
                            FROM SubAktivitasNilaiBLSFALLPG BLSF LEFT JOIN SubaktivitasNilaiSFBDLPG SF
                            ON BLSF.NoReferensi = SF.NoReferensi
                            WHERE BLSF.NoReferensi = @NoReferensi;";
                idDokumen = 74;
            }
            using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(data.NoReferensi));
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        float SFAL = reader.IsDBNull(reader.GetOrdinal("SFAL")) 
                            ? 0f 
                            : Convert.ToSingle(reader["SFAL"]);
                        float BL = reader.IsDBNull(reader.GetOrdinal("BL")) 
                            ? 0f 
                            : Convert.ToSingle(reader["BL"]);
                        float SFBD = reader.IsDBNull(reader.GetOrdinal("SFBD")) 
                            ? 0f 
                            : Convert.ToSingle(reader["SFBD"]);
                        if (BL != 0)
                        {
                            R2 = ((SFBD - SFAL) / BL) * 100;
                            Console.WriteLine(SFBD);
                            Console.WriteLine(SFAL);
                            Console.WriteLine(BL);
                            Console.WriteLine(R2);
                        }
                        else
                        {
                            return Ok(new
                            {
                                success = false,
                                message = "Can't calculate R2 value, because BL value is null or 0"
                            });
                        }
                    }
                }
            }
            UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, R2 < -0.07, idDokumen);
            return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    // Refactor Cognitive Complexity
    [HttpPost("update_lop_r3_r4")]
    public IActionResult UpdateLopR3R4([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        try
        {
            float sfbd = 0, bl = 0, ar = 0, newbl = 0;
            bool isROB = false;
            int idDokR3 = 18, idDokR4 = 19;
            string tipeProses = "", nomorPenerimaan = "";
            string tipeProduk = "", jenisPlant = "", tableA = "SubaktivitasNilaiBLSFAL", tableB = "SubaktivitasNilaiSFBD", tableC = "SubAktivitasNilaiARsesuaiCQD", tblNewBL = "SubAktivitasSFADNewBL", colA = "BL_barrels", colB = "Barrels", colC = "Barrels", colNewBL = "NewBl_barrels";
            using var sqlConnection = GetConnection("Db").OpenConnection();
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 TipeProses FROM Aktivitas WHERE IdAktivitas = @IdAktivitas", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@IdAktivitas", data.IdAktivitas);
                tipeProses = cmd.ExecuteScalar()?.ToString() ?? "";
            }
            if (tipeProses == "Penerimaan" || tipeProses == "PenerimaanSTSBBM" || tipeProses == "PenerimaanSTSLPG")
            {
                nomorPenerimaan = data.NoReferensi;
                using (var cmd = new SqlCommand(
                    "SELECT TOP 1 TipeProduk FROM MasterProduk WHERE NoProduk = (SELECT TOP 1 KodeProduk FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi)", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    tipeProduk = (result == null || result == DBNull.Value) ? "" : result.ToString();
                }
                using (var cmd = new SqlCommand(
                    "SELECT TOP 1 JenisPlant FROM MasterPlant WHERE IdPlant = (SELECT TOP 1 IdPlant FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi)", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    jenisPlant = cmd.ExecuteScalar()?.ToString() ?? "";
                }
                if (tipeProduk.ToUpper() == "BBM" && jenisPlant.ToUpper() == "STS"){
                    tableA = "SubaktivitasNilaiBLSFALSTSPnrBBM";
                    tableB = "SubaktivitasNilaiSFBDSTSPnrBBM";
                    tableC = "SubAktivitasFormNilaiSFALARSTSPymBBM";
                    tblNewBL = "SubAktivitasSFADNewBLSTSPnrBBM";
                    colC = "AR_barrels";
                    idDokR3 = 123;
                    idDokR4 = 126;
                } else if (tipeProduk.ToUpper() == "LPG" && jenisPlant.ToUpper() == "STS"){
                    tableA = "SubaktivitasNilaiBLSFALSTSLPG";
                    tableB = "SubaktivitasNilaiSFBDSTSLPG";
                    tableC = "SubAktivitasFormNilaiSFALARSTSPymLPG";
                    tblNewBL = "SubAktivitasSFADNewBLSTSLPG";
                    colA = "BL_mt";
                    colB = "mt";
                    colC = "AR_mt";
                    colNewBL = "NewBl_mt";
                    idDokR3 = 177;
                    idDokR4 = 181;
                } else if (tipeProduk.ToUpper() == "LPG") {
                    tableA = "SubAktivitasNilaiBLSFALLPG";
                    tableB = "SubaktivitasNilaiSFBDLPG";
                    tableC = "SubAktivitasNilaiARsesuaiCQDLPG";
                    tblNewBL = "SubAktivitasSFADNewBLLPG";
                    colA = "BL_mt";
                    colB = "mt";
                    colC = "MT";
                    colNewBL = "NewBl_mt";
                    idDokR3 = 81;
                    idDokR4 = 82;
                }
                using (var cmd = new SqlCommand($"SELECT {colA} FROM {tableA} WHERE NoReferensi = @NoReferensi", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    bl = (result == DBNull.Value || result == null) ? 0f : Convert.ToSingle(result);
                }
                using (var cmd = new SqlCommand($"SELECT {colB} FROM {tableB} WHERE NoReferensi = @NoReferensi", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    sfbd = (result == DBNull.Value || result == null) ? 0f : Convert.ToSingle(result);
                }
                // NewBL
                using (var cmd = new SqlCommand($@"SELECT TOP 1 {colNewBL}, ApakahTerdapatROB FROM {tblNewBL} WHERE NoReferensi = @NoReferensi", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            newbl = reader[colNewBL] == DBNull.Value || reader[colNewBL] == null ? 0f : Convert.ToSingle(reader[colNewBL]);
                            isROB = reader["ApakahTerdapatROB"] == DBNull.Value || reader["ApakahTerdapatROB"] == null ? false : Convert.ToBoolean(reader["ApakahTerdapatROB"]);
                        }
                    }
                }
                using (var cmd = new SqlCommand($@"
                    SELECT SUM(CAST(SA.{colC} AS FLOAT)) 
                    FROM {tableC} SA
                    JOIN Aktivitas A ON SA.idAktifitas = A.IdAktivitas
                    WHERE SA.NoReferensi IN (
                        SELECT NomorPenimbunan FROM Penimbunan 
                        WHERE IdPenerimaan = (
                            SELECT TOP 1 IdPenerimaan FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi
                        )
                    ) 
                    AND A.StatusAktivitas NOT IN ('Waiting','Draft')", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    ar = (result == DBNull.Value || result == null) ? 0f : Convert.ToSingle(result);
                }
            }
            else if (tipeProses == "Penimbunan")
            {
                using (var cmd = new SqlCommand(@"
                    SELECT NomorPenerimaan FROM Penerimaan 
                    WHERE IdPenerimaan = (SELECT TOP 1 IdPenerimaan FROM Penimbunan WHERE NomorPenimbunan = @NoReferensi)", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    nomorPenerimaan = (result == null || result == DBNull.Value) ? "" : result.ToString();
                }
                using (var cmd = new SqlCommand($@"
                    SELECT Barrels FROM {tableB} 
                    WHERE NoReferensi = (
                        SELECT TOP 1 NomorPenerimaan 
                        FROM Penerimaan WHERE IdPenerimaan = (
                            SELECT TOP 1 IdPenerimaan FROM Penimbunan WHERE NomorPenimbunan = @NoReferensi
                        )
                    )", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    sfbd = (result == DBNull.Value || result == null) ? 0f : Convert.ToSingle(result);
                }
                using (var cmd = new SqlCommand(@"
                    SELECT BL_barrels FROM SubaktivitasNilaiBLSFAL 
                    WHERE NoReferensi = (
                        SELECT TOP 1 NomorPenerimaan 
                        FROM Penerimaan WHERE IdPenerimaan = (
                            SELECT TOP 1 IdPenerimaan FROM Penimbunan WHERE NomorPenimbunan = @NoReferensi
                        )
                    )", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    bl = (result == DBNull.Value || result == null) ? 0f : Convert.ToSingle(result);
                }
                // NewBL (BBM)
                using (var cmd = new SqlCommand(@"
                    SELECT TOP 1 NewBl_barrels
                    FROM SubAktivitasSFADNewBL
                    WHERE NoReferensi = (
                        SELECT TOP 1 NomorPenerimaan 
                        FROM Penerimaan WHERE IdPenerimaan = (
                            SELECT TOP 1 IdPenerimaan FROM Penimbunan WHERE NomorPenimbunan = @NoReferensi
                        )
                    )", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    newbl = (result == DBNull.Value || result == null) ? 0f : Convert.ToSingle(result);
                }
                using (var cmd = new SqlCommand(@"
                    SELECT SUM(CAST(SA.Barrels AS FLOAT)) 
                    FROM SubAktivitasNilaiARsesuaiCQD SA
                    JOIN Aktivitas A ON SA.idAktifitas = A.IdAktivitas
                    WHERE SA.NoReferensi IN (
                        SELECT NomorPenimbunan FROM Penimbunan WHERE IdPenerimaan = (
                            SELECT TOP 1 IdPenerimaan FROM Penimbunan WHERE NomorPenimbunan = @NoReferensi
                        )
                    )
                    AND A.StatusAktivitas IN ('Completed','Completed Edit')", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    var result = cmd.ExecuteScalar();
                    ar = (result == DBNull.Value || result == null) ? 0f : Convert.ToSingle(result);
                }
            }
            else if (tipeProses == "PenyimpananPenerimaanSTSBBM")
            {
                using (var cmd = new SqlCommand(@"SELECT
                                    BLSF.SFAL_barrels AS SFAL,
                                    BLSF.BL_barrels AS BL,
                                    SF.barrels AS SFBD,
                                    SUM(CAST(AR.AR_barrels AS DECIMAL(18,3))) AS AR,
                                    ISNULL(SB.NewBl_barrels, 0) AS NewBL
                                FROM
                                    SubaktivitasNilaiBLSFALSTSPnrBBM AS BLSF
                                LEFT JOIN
                                    SubaktivitasNilaiSFBDSTSPnrBBM AS SF ON BLSF.NoReferensi = SF.NoReferensi
                                JOIN
                                    Penerimaan Pr ON pr.NomorPenerimaan = SF.NoReferensi
                                LEFT JOIN
                                    Penimbunan Pb ON pb.IdPenerimaan = pr.IdPenerimaan
                                LEFT JOIN (
                                    SELECT AR.*, A.StatusAktivitas
                                    FROM SubAktivitasFormNilaiSFALARSTSPymBBM AS AR
                                    JOIN Aktivitas A ON A.IdAktivitas = AR.idAktifitas
                                ) AS AR ON Pb.NomorPenimbunan = AR.NoReferensi
                                LEFT JOIN SubAktivitasSFADNewBLSTSPnrBBM AS SB ON SB.NoReferensi = PR.NomorPenerimaan
                                WHERE
                                    PB.NomorPenimbunan = @NoReferensi
                                GROUP BY
                                    BLSF.SFAL_barrels, BLSF.BL_barrels, SF.barrels, SB.NewBl_barrels;", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bl   = reader["BL"]   == DBNull.Value ? 0f : Convert.ToSingle(reader["BL"]);
                            sfbd = reader["SFBD"] == DBNull.Value ? 0f : Convert.ToSingle(reader["SFBD"]);
                            ar   = reader["AR"]   == DBNull.Value ? 0f : Convert.ToSingle(reader["AR"]);
                        }
                    }
                }
                float r4Value = (ar - bl) / bl * 100;
                UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, r4Value < -0.125, 134);
                return Ok(new { success = true, R4 = r4Value, message = "Aktivitas Dokumen Berhasil Diupdate." });
            }
            else
            {
                return Ok(new { success = false, message = "Invalid TipeProses" });
            }
            if (bl == 0)
                return Ok(new { success = false, message = "Can't calculate R3 & R4, BL value is null or 0" });
            float r3 = ((ar + newbl) - sfbd) / bl * 100;
            float r4 = (ar - bl) / bl * 100;
            UpdateDokumenWajibUpload(sqlConnection, nomorPenerimaan, r3 < -0.125, idDokR3);
            if (isROB)
            {   
                UpdateDokumenWajibUpload(sqlConnection, nomorPenerimaan, false, idDokR4);
            } else
            {
                UpdateDokumenWajibUpload(sqlConnection, nomorPenerimaan, r4 < -0.125, idDokR4);
            }
            return Ok(new { success = true, R3 = r3, R4 = r4, message = "Aktivitas Dokumen LoP R3 dan R4 Berhasil Diupdate." });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("update_lop_r2_rtw")]
    public async Task<IActionResult> UpdateLopR2Rtw([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
            return ErrorResponseDto("Not authorized.", StatusCodes.Status401Unauthorized);
        var master = await DatabaseQueryHelper.ExecuteSelectSingleAsync<
            (double BL, double SFAL, double SFBD)
        >(
            @"SELECT TOP 1
                A.BL_Barrels,
                A.SFAL_Barrels,
                B.SFBD_Barrels
            FROM SubAktivitasFormInputBLnSFALRTW A
            JOIN SubAktivitasNilaiSFBDRTW B 
                ON A.NoReferensi = B.NoReferensi
            WHERE A.NoReferensi = @NoReferensi;",
            reader => (
                reader.IsDBNull(0) ? 0d : Convert.ToDouble(reader.GetValue(0)),
                reader.IsDBNull(1) ? 0d : Convert.ToDouble(reader.GetValue(1)),
                reader.IsDBNull(2) ? 0d : Convert.ToDouble(reader.GetValue(2))
            ),
            new Dictionary<string, object> { { "@NoReferensi", data.NoReferensi } },
            noReferensi: data.NoReferensi
        );
        var (BL, SFAL, SFBD) = master;
        double R2 = (SFBD-SFAL)/BL * 100;
        using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
        {
            UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, R2 < -0.1, 244);
        }
        return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
    }

    [HttpPost("update_lop_r2_truck")]
    public async Task<IActionResult> UpdateLopR2Truck([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
            return ErrorResponseDto("Not authorized.", StatusCodes.Status401Unauthorized);
        var master = await DatabaseQueryHelper.ExecuteSelectSingleAsync<
            (double BL, double SFAL, double SFBD)
        >(
            @"SELECT TOP 1
                A.BL_KLObs,
                A.AL_KLObs,
                B.BD_KLObs
            FROM SubAktivitasFormInputNilaiBLnAL A
            JOIN SubAktivitasFormInputNilaiBD B 
                ON A.NoReferensi = B.NoReferensi
            WHERE A.NoReferensi = @NoReferensi;",
            reader => (
                reader.IsDBNull(0) ? 0d : Convert.ToDouble(reader.GetValue(0)),
                reader.IsDBNull(1) ? 0d : Convert.ToDouble(reader.GetValue(1)),
                reader.IsDBNull(2) ? 0d : Convert.ToDouble(reader.GetValue(2))
            ),
            new Dictionary<string, object> { { "@NoReferensi", data.NoReferensi } },
            noReferensi: data.NoReferensi
        );
        var (BL, SFAL, SFBD) = master;
        double R2 = (SFBD-SFAL)/BL * 100;
        using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
        {
            UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, R2 < -0.1, 273);
        }
        return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
    }

    [HttpPost("insertTotalBDToSubAktivitasNilaiSFBDRTW")]
    public async Task<IActionResult> InsertTotalBDToSubAktivitasNilaiSFBDRTW([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
            return ErrorResponseDto("Not authorized.", StatusCodes.Status401Unauthorized);
        var master = await DatabaseQueryHelper.ExecuteSelectSingleAsync<
            (double SumKLOBS, double SumKL15, double SumBarrels, double SumLT, double SumMT)
        >(
            @"SELECT
                SUM(CAST(KL_Obs AS DECIMAL(18, 2))) AS SumKLOBS,
                SUM(CAST(KL_15 AS DECIMAL(18, 2))) AS SumKL15,
                SUM(CAST(Barrels AS DECIMAL(18, 2))) AS SumBarrels,
                SUM(CAST(LT AS DECIMAL(18, 2))) AS SumLT,
                SUM(CAST(MT AS DECIMAL(18, 2))) AS SumMT
            FROM SubAktivitasNilaiBDPerGerbong A
            WHERE A.NoReferensi = @NoReferensi;",
            reader => (
                reader.IsDBNull(0) ? 0d : Convert.ToDouble(reader.GetValue(0)),
                reader.IsDBNull(1) ? 0d : Convert.ToDouble(reader.GetValue(1)),
                reader.IsDBNull(2) ? 0d : Convert.ToDouble(reader.GetValue(2)),
                reader.IsDBNull(3) ? 0d : Convert.ToDouble(reader.GetValue(3)),
                reader.IsDBNull(4) ? 0d : Convert.ToDouble(reader.GetValue(4))
            ),
            new Dictionary<string, object> { { "@NoReferensi", data.NoReferensi } },
            noReferensi: data.NoReferensi
        );
        var (SumKLOBS, SumKL15, SumBarrels, SumLT, SumMT) = master;
        string sqlGetTime = $"EXEC dbo.GetPlantDateTime @NomorReferensi = '{data.NoReferensi}'";
        var plantTimeObj = ExecuteScalar(sqlGetTime);
        DateTime plantTime = DateTime.Now;
        if (plantTimeObj != null && DateTime.TryParse(plantTimeObj.ToString(), out var tmp))
            plantTime = tmp;
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            @"UPDATE SubAktivitasNilaiSFBDRTW
            SET
                SFBD_KL_Obs = @SFBD_KL_Obs,
                SFBD_KL_15 = @SFBD_KL_15,
                SFBD_Barrels = @SFBD_Barrels,
                SFBD_LT = @SFBD_LT,
                SFBD_MT = @SFBD_MT,
                LastUpdatedBy = @LastUpdatedBy,
                lastUpdatedDate = @lastUpdatedDate
            WHERE
                NoReferensi = @NoReferensi AND idProses = @IdProses",
            new Dictionary<string, object>
            {
                { "@SFBD_KL_Obs", SumKLOBS },
                { "@SFBD_KL_15", SumKL15 },
                { "@SFBD_Barrels", SumBarrels },
                { "@SFBD_LT", SumLT },
                { "@SFBD_MT", SumMT },
                { "@LastUpdatedBy", CurrentUserName() },
                { "@lastUpdatedDate", plantTime },
                { "@IdProses", data.IdProses },
                { "@NoReferensi", data.NoReferensi }
            },
            noReferensi: data.NoReferensi
        );
        return Ok(new { success = true, message = "Subaktivitas Berhasil Dibuat."});
    }

    [HttpPost("update_lop_r4_rtw")]
    public async Task<IActionResult> UpdateLopR4Rtw([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
            return ErrorResponseDto("Not authorized.", StatusCodes.Status401Unauthorized);
        bool ROB = await DatabaseQueryHelper.ExecuteSelectSingleAsync<bool>(
            "SELECT TOP 1 ApakahAdaROB FROM SubAktivitasFormInputNilaiAktDischargeRTW WHERE NoReferensi = @NoReferensi;",
            reader => reader.IsDBNull(0) ? false : reader.GetBoolean(0),
            new Dictionary<string, object> {{ "@NoReferensi", data.NoReferensi}}
        );
        SqlConnection sqlConnection = GetConnection("Db").OpenConnection();
        if (ROB)
        {
            UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, false, 246);
            return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
        }
        var master = await DatabaseQueryHelper.ExecuteSelectSingleAsync<
            (double BL, double AR)
        >(
            @"SELECT TOP 1
                F.BL_Barrels,
                X.TotalAR AS AR
            FROM SubAktivitasFormInputBLnSFALRTW F
            OUTER APPLY (
                SELECT SUM(CAST(AR.Barrels AS FLOAT)) AS TotalAR
                FROM Penerimaan PR
                JOIN Penimbunan PNB
                    ON PNB.IdPenerimaan = PR.IdPenerimaan
                JOIN SubAktivitasARSesuaiCQDRTW AR
                    ON AR.NoReferensi = PNB.NomorPenimbunan
                WHERE PR.NomorPenerimaan = @NoReferensi
            ) X
            WHERE F.NoReferensi = @NoReferensi;",
            reader => (
                reader.IsDBNull(0) ? 0d : Convert.ToDouble(reader.GetValue(0)),
                reader.IsDBNull(1) ? 0d : Convert.ToDouble(reader.GetValue(1))
            ),
            new Dictionary<string, object> { { "@NoReferensi", data.NoReferensi } },
            noReferensi: data.NoReferensi
        );
        var (BL, AR) = master;
        double R4 = (AR - BL) / BL * 100;
        UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, R4 < -0.125, 246);
        return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
    }

    [HttpPost("update_lop_pumping")]
    public IActionResult update_lop_pumping([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = "Tidak diizinkan." 
            };
            return Json(response);
        }
        try
        {
            string tipeProduk = "", jenisPlant = "";
            DateTime? etc = null, stopBongkar = null;
            int idDokumen = 20;
            string sqlData = @"SELECT A.ETC, S.tglStopBongkar FROM SubaktivitasNilaiAgreement A JOIN SubaktivitasStopBongkar S
                            ON A.NoReferensi = S.NoReferensi
                            WHERE S.NoReferensi = @NoReferensi;";
            using var sqlConnection = GetConnection("Db").OpenConnection();
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 TipeProduk FROM MasterProduk WHERE NoProduk = (SELECT TOP 1 KodeProduk FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi)", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                var result = cmd.ExecuteScalar();
                tipeProduk = (result == null || result == DBNull.Value) ? "" : result.ToString();
            }
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 JenisPlant FROM MasterPlant WHERE IdPlant = (SELECT TOP 1 IdPlant FROM Penerimaan WHERE NomorPenerimaan = @NoReferensi)", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                jenisPlant = cmd.ExecuteScalar()?.ToString() ?? "";
            }
            if (jenisPlant.ToUpper() == "STS" && tipeProduk.ToUpper() == "BBM") {
                sqlData = @"SELECT A.ETC, S.tglStopBongkar FROM SubaktivitasNilaiAgreementSTSPnrBBM A JOIN SubaktivitasStopBongkarSTSPnrBBM S
                            ON A.NoReferensi = S.NoReferensi
                            WHERE S.NoReferensi = @NoReferensi;";
                idDokumen = 128;
            } else if (jenisPlant.ToUpper() == "STS" && tipeProduk.ToUpper() == "LPG") {
                sqlData = @"SELECT A.ETC, S.tglStopBongkar FROM SubaktivitasNilaiAgreementSTSLPG A JOIN SubaktivitasStopBongkarSTSLPG S
                            ON A.NoReferensi = S.NoReferensi
                            WHERE S.NoReferensi = @NoReferensi;";
                idDokumen = 180;
            } else if (tipeProduk.ToUpper() == "LPG") {
                sqlData = @"SELECT A.ETC, S.tglStopBongkar FROM SubAktivitasNilaiAgreementLPG A JOIN SubAktivitasStopBongkarLPG S
                            ON A.NoReferensi = S.NoReferensi
                            WHERE S.NoReferensi = @NoReferensi;";
                idDokumen = 83;
            }
            using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection)) {
                sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(data.NoReferensi));
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["ETC"] != DBNull.Value)
                        {
                            etc = Convert.ToDateTime(reader["ETC"]);
                        }
                        if (reader["tglStopBongkar"] != DBNull.Value)
                        {
                            stopBongkar = Convert.ToDateTime(reader["tglStopBongkar"]);
                        }
                    }
                }
            }
            UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, stopBongkar > etc, idDokumen);
            using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(data.NoReferensi));
                sqlCommand.Parameters.AddWithValue("@IdProses", EncodeForXSS(data.IdProses));
                sqlCommand.ExecuteNonQuery();
            }
            return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("update_AMT_value")]
    public IActionResult UpdateAMTValue([FromBody] UpdateAMTRequest payload)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." 
            };
            return Json(response);
        }
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string TipeProses = "";
                string sqlData = "SELECT TipeProses FROM Aktivitas WHERE IdAktivitas = @IdAktivitas";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", payload.IdAktivitas);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TipeProses = reader["TipeProses"].ToString();
                        }
                    }
                }
                sqlData = $"UPDATE SubAktivitasDataMobilTangkiMTGateOut SET AMT = @AMT WHERE NoReferensi = @NoReferensi";
                if (TipeProses == "PenyaluranTruck") {
                    sqlData = $"UPDATE SubAktivitasDataMobilTangkiMTGateOutLPG SET AMT = @AMT WHERE NoReferensi = @NoReferensi";
                }
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", payload.NoReferensi);
                    sqlCommand.Parameters.AddWithValue("@AMT", payload.AMT);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            var responseSuccess = new
            {
                success = true,
                message = "Nilai AMT pada MT Gate Out berhasil diperbarui."
            };
            return Json(responseSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetLaporanStockValue")]
    public IActionResult GetLaporanStockValue(string? NoReferensi, string? IdAktivitas)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            double StockAwal = 0, Penerimaan = 0, Penyaluran = 0, StockAkhir = 0;
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string sqlData = @"SELECT TOP 1 StockAkhir
                                FROM SubAktivitasLaporanStock
                                WHERE idAktifitas != @IdAktivitas
                                AND CAST(etlDate AS DATE) = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE)
                                ORDER BY etlDate DESC;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", EncodeForXSS(IdAktivitas));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StockAwal = reader["StockAkhir"] != DBNull.Value 
                                ? Convert.ToDouble(reader["StockAkhir"]) 
                                : 0;
                        }
                    }
                }
                sqlData = @"SELECT TOP 1 TotalPenyaluran, StokAkhir
                            FROM SubAktivitasTotalPenyaluran
                            WHERE NoReferensi = (
                                SELECT TOP 1 NomorPenimbunanPenyaluran 
                                FROM PenimbunanPenyaluran 
                                WHERE IdTangki = (
                                    SELECT TOP 1 IdTangki 
                                    FROM ClosingStock 
                                    WHERE NomorClosingStock = @NoReferensi
                                ) and TipePenyaluran = 'Sales'
                                ORDER BY TanggalDibuat DESC
                            )
                            ORDER BY etlDate DESC;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Penyaluran = reader["TotalPenyaluran"] != DBNull.Value 
                                ? Convert.ToDouble(reader["TotalPenyaluran"]) 
                                : 0;
                            StockAkhir = reader["StokAkhir"] != DBNull.Value 
                                ? Convert.ToDouble(reader["StokAkhir"]) 
                                : 0;
                        }
                    }
                }
                sqlData = @"SELECT SUM(TRY_CAST(KL_Obs AS FLOAT)) AS Penerimaan
                            FROM SubAktivitasNilaiARsesuaiCQD
                            WHERE CAST(LastUpdatedDate AS DATE) = CAST(GETDATE() AS DATE);
                            ";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Penerimaan = reader["Penerimaan"] != DBNull.Value
                                ? Convert.ToDouble(reader["Penerimaan"])
                                : 0;
                        }
                    }
                }
            }
            return Ok( new {
                success = true,
                StockAwal = StockAwal,
                Penerimaan = Penerimaan,
                Penyaluran = Penyaluran,
                StockAkhir = StockAkhir,
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetLaporanStockSTSCSBBMValue")]
    public IActionResult GetLaporanStockSTSCSBBMValue(string? NoReferensi, string? IdAktivitas)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Tidak diizinkan." });
        try
        {
            double StockAwal = 0, Penerimaan = 0, Penyaluran = 0, StockAkhir = 0;
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string sqlData = @"SELECT TOP 1 StockAkhir
                                FROM SubAktivitasLaporanStockSTSCSBBM
                                WHERE idAktifitas != @IdAktivitas
                                AND CAST(etlDate AS DATE) = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE)
                                ORDER BY etlDate DESC;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", EncodeForXSS(IdAktivitas));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                            StockAwal = reader["StockAkhir"] != DBNull.Value ? Convert.ToDouble(reader["StockAkhir"]) : 0;
                    }
                }
                sqlData = @"SELECT TOP 1 TotalPenyaluran, StokAkhir
                            FROM SubAktivitasTotalPenyaluran
                            WHERE NoReferensi = (
                                SELECT TOP 1 NomorPenimbunanPenyaluran 
                                FROM PenimbunanPenyaluran 
                                WHERE IdTangki = (
                                    SELECT TOP 1 IdTangki 
                                    FROM ClosingStock 
                                    WHERE NomorClosingStock = @NoReferensi
                                ) and TipePenyaluran = 'Sales'
                                ORDER BY TanggalDibuat DESC
                            )
                            ORDER BY etlDate DESC;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Penyaluran = reader["TotalPenyaluran"] != DBNull.Value ? Convert.ToDouble(reader["TotalPenyaluran"]) : 0;
                            StockAkhir = reader["StokAkhir"] != DBNull.Value ? Convert.ToDouble(reader["StokAkhir"]) : 0;
                        }
                    }
                }

                // Penerimaan dari SubAktivitasNilaiARsesuaiCQD
                sqlData = @"SELECT SUM(TRY_CAST(KL_Obs AS FLOAT)) AS Penerimaan
                            FROM SubAktivitasNilaiARsesuaiCQD
                            WHERE CAST(LastUpdatedDate AS DATE) = CAST(GETDATE() AS DATE);";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                            Penerimaan = reader["Penerimaan"] != DBNull.Value ? Convert.ToDouble(reader["Penerimaan"]) : 0;
                    }
                }
            }
            return Ok(new {
                success = true,
                StockAwal = StockAwal,
                Penerimaan = Penerimaan,
                Penyaluran = Penyaluran,
                StockAkhir = StockAkhir,
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Terjadi kesalahan di server.");
        }
    }

    [HttpGet("GetNewBLSFADValue")]
    public IActionResult GetNewBLSFADValue(string? NoReferensi, string? Jenis = "BBM")
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        string sqlData = "";
        string NewBL_KLObs = "", NewBL_KL15 = "", NewBL_Barrels = "", NewBL_LT = "", NewBL_MT = "", SFAD_KLObs = "", SFAD_KL15 = "", SFAD_Barrels = "", SFAD_LT = "", SFAD_MT = "";
        switch (Jenis.ToUpper())
        {
            case "BBM":
                sqlData = @"SELECT TOP 1 NewBL_KLObs, NewBL_KL15, NewBL_Barrels, NewBL_LT, NewBL_mt, SFAD_KLObs, SFAD_KL15, SFAD_Barrels, SFAD_LT, SFAD_MT 
                FROM (
                    SELECT NewBL_KLObs, NewBL_KL15, NewBL_Barrels, NewBL_LT, NewBL_mt, SFAD_KLObs, SFAD_KL15, SFAD_Barrels, SFAD_LT, SFAD_MT FROM SubAktivitasSFADNewBLSTSPnrBBM WHERE NoReferensi = @NoReferensi
                    UNION
                    SELECT NewBL_KLObs, NewBL_KL15, NewBL_Barrels, NewBL_LT, NewBL_mt, SFAD_KLObs, SFAD_KL15, SFAD_Barrels, SFAD_LT, SFAD_MT FROM SubAktivitasSFADNewBL WHERE NoReferensi = @NoReferensi
                ) AS s";
                break;
            case "STSBBM":
                sqlData = @"SELECT TOP 1 NewBL_KLObs, NewBL_KL15, NewBL_Barrels, NewBL_LT, NewBL_mt, SFAD_KLObs, SFAD_KL15, SFAD_Barrels, SFAD_LT, SFAD_MT 
                FROM (
                    SELECT NewBL_KLObs, NewBL_KL15, NewBL_Barrels, NewBL_LT, NewBL_mt, SFAD_KLObs, SFAD_KL15, SFAD_Barrels, SFAD_LT, SFAD_MT FROM SubAktivitasSFADNewBLSTSPnrBBM WHERE NoReferensi = @NoReferensi
                    UNION
                    SELECT NewBL_KLObs, NewBL_KL15, NewBL_Barrels, NewBL_LT, NewBL_mt, SFAD_KLObs, SFAD_KL15, SFAD_Barrels, SFAD_LT, SFAD_MT FROM SubAktivitasSFADNewBL WHERE NoReferensi = @NoReferensi
                ) AS s";
                break;
            case "LPG":
                sqlData = @"SELECT TOP 1 0 as NewBL_KLObs, 0 as NewBL_KL15, 
                     0 as NewBL_Barrels, 0 as NewBL_LT, 
                     s.NewBL_mt, 
                     0 as SFAD_KLObs, 
                     0 as SFAD_KL15, 
                     0 as SFAD_Barrels, 
                     0 as SFAD_LT, s.SFAD_MT 
                    FROM (
                        SELECT NewBL_mt, SFAD_MT FROM SubAktivitasSFADNewBLSTSLPG WHERE NoReferensi = @NoReferensi
                        UNION
                        SELECT NewBL_mt, SFAD_MT FROM SubAktivitasSFADNewBLLPG WHERE NoReferensi = @NoReferensi
                    ) AS s";
                break;
            case "STSLPG":
                sqlData = @"SELECT TOP 1 0 as NewBL_KLObs, 0 as NewBL_KL15, 
                     0 as NewBL_Barrels, 0 as NewBL_LT, 
                     s.NewBL_mt, 
                     0 as SFAD_KLObs, 
                     0 as SFAD_KL15, 
                     0 as SFAD_Barrels, 
                     0 as SFAD_LT, s.SFAD_MT 
                    FROM (
                        SELECT NewBL_mt, SFAD_MT FROM SubAktivitasSFADNewBLSTSLPG WHERE NoReferensi = @NoReferensi
                        UNION
                        SELECT NewBL_mt, SFAD_MT FROM SubAktivitasSFADNewBLLPG WHERE NoReferensi = @NoReferensi
                    ) AS s";
                break;
        };
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NewBL_KLObs = reader["NewBL_KLObs"]?.ToString() ?? "";
                            NewBL_KL15 = reader["NewBL_KL15"]?.ToString() ?? "";
                            NewBL_Barrels = reader["NewBL_Barrels"]?.ToString() ?? "";
                            NewBL_LT = reader["NewBL_LT"]?.ToString() ?? "";
                            NewBL_MT = reader["NewBL_MT"]?.ToString() ?? "";
                            SFAD_KLObs = reader["SFAD_KLObs"]?.ToString() ?? "";
                            SFAD_KL15 = reader["SFAD_KL15"]?.ToString() ?? "";
                            SFAD_Barrels = reader["SFAD_Barrels"]?.ToString() ?? "";
                            SFAD_LT = reader["SFAD_LT"]?.ToString() ?? "";
                            SFAD_MT = reader["SFAD_MT"]?.ToString() ?? "";
                        }
                    }
                }
            }
            return Ok( new {
                success = true,
                NewBL_KLObs = NewBL_KLObs,
                NewBL_KL15 = NewBL_KL15,
                NewBL_Barrels = NewBL_Barrels,
                NewBL_LT = NewBL_LT,
                NewBL_MT = NewBL_MT,
                SFAD_KLObs = SFAD_KLObs,
                SFAD_KL15 = SFAD_KL15,
                SFAD_Barrels = SFAD_Barrels,
                SFAD_LT = SFAD_LT,
                SFAD_MT = SFAD_MT
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    // Refactor Cognitive Complexity
    [HttpGet("GetRValueKonsinyasi")]
    public IActionResult GetRValueKonsinyasi(string? IdAktivitas, string? Menu, string? Jenis = "BBM") {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        try {
            var response = new Dictionary<string, object>();
            string newBlQuery = "", blsfalQuery = "", blPenKonQuery = "";
            switch (Jenis.ToUpper())
            {
                case "BBM":
                    newBlQuery = "SELECT NewBL_Barrels AS NewBL, SFAD_Barrels AS SFAD, SFBL_Barrels AS SFBL FROM SubAktivitasNilaiNewBLSFADSFBL WHERE idAktifitas = @IdAktivitas;";
                    blsfalQuery = "SELECT BL_Barrels AS BL, SFAL_Barrels AS SFAL FROM SubAktivitasNilaiBLSFALPenyaluran WHERE idAktifitas = @IdAktivitas;";
                    blPenKonQuery = "SELECT BL_Barrels AS BL, SFAL_Barrels AS SFAL FROM SubAktivitasNilaiBLPenKon WHERE idAktifitas = @IdAktivitas;";
                    break;
                case "STSBBM":
                    newBlQuery = "SELECT NewBL_Barrels AS NewBL, SFAD_Barrels AS SFAD, SFBL_Barrels AS SFBL FROM SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM WHERE idAktifitas = @IdAktivitas;";
                    blsfalQuery = "SELECT BL_Barrels AS BL, SFAL_Barrels AS SFAL FROM SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM WHERE idAktifitas = @IdAktivitas;";
                    break;
                case "LPG":
                    newBlQuery = "SELECT NewBL_MT AS NewBL, SFAD_MT AS SFAD, SFBL_MT AS SFBL FROM SubAktivitasNilaiNewBLSFADSFBLLPG WHERE idAktifitas = @IdAktivitas;";
                    blsfalQuery = "SELECT BL_MT AS BL, SFAL_MT AS SFAL FROM SubAktivitasNilaiBLSFALPenyaluranLPG WHERE idAktifitas = @IdAktivitas;";
                    blPenKonQuery = "SELECT BL_MT AS BL, SFAL_MT AS SFAL FROM SubAktivitasNilaiBLPenKonLPG WHERE idAktifitas = @IdAktivitas;";
                    break;
                case "STSLPG":
                    newBlQuery = "SELECT NewBL_MT AS NewBL, SFAD_MT AS SFAD, SFBL_MT AS SFBL FROM SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG WHERE idAktifitas = @IdAktivitas;";
                    blsfalQuery = "SELECT BL_MT AS BL, SFAL_MT AS SFAL FROM SubAktivitasNilaiBLSFALPenyaluranSTSPyrLPG WHERE idAktifitas = @IdAktivitas;";
                    blPenKonQuery = "SELECT BL_MT AS BL, SFAL_MT AS SFAL FROM SubAktivitasNilaiBLPenKonSTSPyrLPG WHERE idAktifitas = @IdAktivitas;";
                    break;
                case "RTW":
                    newBlQuery = "";
                    blsfalQuery = "SELECT BL_Barrels AS BL, AL_Barrels AS SFAL FROM SubAktivitasNilaiBLdanALRTW WHERE idAktifitas = @IdAktivitas;";
                    blPenKonQuery = "";
                    break;
            };
            Dictionary<string, string> QueryDict = new()
            {
                { "NewBL",  newBlQuery  },
                { "BLSFAL",  blsfalQuery },
                { "BLPenKon",blPenKonQuery }
            };
            if (!QueryDict.TryGetValue(Menu, out string? sqlData)) //1
            {
                return Ok(new { success = false, message = "Invalid menu" });
            }
            using var sqlConnection = GetConnection("Db").OpenConnection();
            using var sqlCommand = new SqlCommand(sqlData, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@IdAktivitas", EncodeForXSS(IdAktivitas));
            using var reader = sqlCommand.ExecuteReader();
            if (!reader.Read())
                return Ok(new { success = false, message = "No data found" });
            float GetFloat(string col) =>
                reader.IsDBNull(reader.GetOrdinal(col)) ? 0f : Convert.ToSingle(reader[col]); //1
            if (Menu == "NewBL" || Menu == "STSBBMNewBL") {
                float NewBL = GetFloat("NewBL"),
                    SFAD  = GetFloat("SFAD"),
                    SFBL  = GetFloat("SFBL");
                if (NewBL == 0)
                    return Ok(new { success = false, message = "Can't calculate R1-R4 value, because BL value is null or 0" });
                response["R1"] = (SFAD - NewBL) / NewBL;
                response["R2"] = (SFBL - SFAD) / NewBL;
            }
            else {
                float BL = GetFloat("BL"),
                    SFAL = GetFloat("SFAL");
                if (BL == 0)
                    return Ok(new { success = false, message = "Can't calculate R1 value, because BL value is null or 0" });
                response["R1"] = (SFAL - BL) / BL;
            }
            response["success"] = true;
            return Json(response);
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("update_dokumen_exrob")]
    public IActionResult update_dokumen_exrob([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = "Not authorized." 
            };
            return Json(response);
        }
        try
        {
            string tipeProduk = data.Jenis;
            bool ExROB = false;
            string tableName = "SubAktivitasNilaiNewBLSFADSFBL";
            List<int> dokIds = new List<int> { 37, 38, 39, 40, 41, 42 };
            if (tipeProduk == "LPG") {
                tableName = "SubAktivitasNilaiNewBLSFADSFBLLPG";
                dokIds = new List<int> { 97, 98, 99, 100, 101, 102 };
            } else if (tipeProduk == "STSBBM") {
                tableName = "SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM";
                dokIds = new List<int> { 146, 147, 148, 149, 150, 151 };
            }
            else if (tipeProduk == "STSLPG") {
                tableName = "SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG";
                dokIds = new List<int> { 191, 192, 193, 194, 195, 196 };
            }
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string sqlData = $"SELECT ExROB FROM {tableName} WHERE idAktifitas = @IdAktivitas;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitas", EncodeForXSS(data.IdAktivitas));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ExROB = reader["ExROB"] != DBNull.Value && Convert.ToBoolean(reader["ExROB"]);
                        }
                    }
                }
                UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, ExROB, dokIds.ToArray());
            }
            return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("generate_etc_konsinyasi")]
    public IActionResult GenerateEtcKonsinyasi([FromBody] UpdateByNoReferensi data)
    {
        if (!IsLoggedIn()) {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            float ETC = 0, Nominasi = 0, LamaPembongkaran = 0, Flowrate = 0;
            string sqlData = @"", sqlUpdateAgreement = "", sqlETC = "";
            switch (data.Jenis.ToUpper())
            {
                case "RTW":
                    sqlData = @"SELECT 
                                A.Nominasi, 
                                B.Flowrate 
                            FROM SubAktivitasFormInputDataGerbongKetelRTW A 
                            JOIN SubAktivitasInputFlowrateRTW B ON A.NoReferensi = B.NoReferensi
                            WHERE A.NoReferensi = @NoReferensi;";
                    sqlUpdateAgreement = @"UPDATE SubAktivitasInputFlowrateRTW SET LamaPembongkaran = @LamaPembongkaran WHERE NoReferensi = @NoReferensi";
                    sqlETC = @"
                        UPDATE na
                        SET na.ETC = DATEADD(SECOND, @LamaDetik,
                                    DATEADD(MINUTE, @LamaMenit,
                                    DATEADD(HOUR, @LamaJam, sb.Tanggal)))
                        FROM SubAktivitasInputFlowrateRTW na
                        JOIN SubAktivitasFormInputDataStartPenyaluranRTW sb ON na.NoReferensi = sb.NoReferensi
                        WHERE na.NoReferensi = @NoReferensi AND sb.Tanggal IS NOT NULL;
                    ";
                    break;
                case "BBM":
                    sqlData = @"SELECT 
                                A.Nominasi, 
                                B.Flowrate 
                            FROM SubAktivitasInputDataKapal A 
                            JOIN SubAktivitasNilaiAgreementPenyaluran B ON A.NoReferensi = B.NoReferensi
                            WHERE A.NoReferensi = @NoReferensi;";
                    sqlUpdateAgreement = @"UPDATE SubAktivitasNilaiAgreementPenyaluran SET LamaPembongkaran = @LamaPembongkaran WHERE NoReferensi = @NoReferensi";
                    sqlETC = @"
                        UPDATE na
                        SET na.ETC = DATEADD(SECOND, @LamaDetik,
                                    DATEADD(MINUTE, @LamaMenit,
                                    DATEADD(HOUR, @LamaJam, sb.Tanggal)))
                        FROM SubAktivitasNilaiAgreementPenyaluran na
                        JOIN SubAktivitasDataStartPenyaluran sb ON na.NoReferensi = sb.NoReferensi
                        WHERE na.NoReferensi = @NoReferensi AND sb.Tanggal IS NOT NULL;
                    ";
                    break;
                case "LPG":
                    sqlData = @"SELECT 
                                A.Nominasi, 
                                B.Flowrate 
                            FROM SubAktivitasInputDataKapalLPG A 
                            JOIN SubAktivitasNilaiAgreementPenyaluranLPG B ON A.NoReferensi = B.NoReferensi
                            WHERE A.NoReferensi = @NoReferensi;";
                    sqlUpdateAgreement = @"UPDATE SubAktivitasNilaiAgreementPenyaluranLPG SET LamaPembongkaran = @LamaPembongkaran WHERE NoReferensi = @NoReferensi";
                    sqlETC = @"
                        UPDATE na
                        SET na.ETC = DATEADD(SECOND, @LamaDetik,
                                    DATEADD(MINUTE, @LamaMenit,
                                    DATEADD(HOUR, @LamaJam, sb.Tanggal)))
                        FROM SubAktivitasNilaiAgreementPenyaluranLPG na
                        JOIN SubAktivitasDataStartPenyaluranLPG sb ON na.NoReferensi = sb.NoReferensi
                        WHERE na.NoReferensi = @NoReferensi AND sb.Tanggal IS NOT NULL;
                    ";
                    break;
                case "STSBBM":
                    sqlData = @"SELECT 
                                A.Nominasi, 
                                B.Flowrate 
                            FROM SubAktivitasInputDataKapalSTSPyrBBM A 
                            JOIN SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM B ON A.NoReferensi = B.NoReferensi
                            WHERE A.NoReferensi = @NoReferensi;";
                    sqlUpdateAgreement = @"UPDATE SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM SET LamaPembongkaran = @LamaPembongkaran WHERE NoReferensi = @NoReferensi";
                    sqlETC = @"
                        UPDATE na
                        SET na.ETC = DATEADD(SECOND, @LamaDetik,
                                    DATEADD(MINUTE, @LamaMenit,
                                    DATEADD(HOUR, @LamaJam, sb.Tanggal)))
                        FROM SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM na
                        JOIN SubAktivitasDataStartPenyaluranSTSPyrBBM sb ON na.NoReferensi = sb.NoReferensi
                        WHERE na.NoReferensi = @NoReferensi AND sb.Tanggal IS NOT NULL;
                    ";
                    break;
                case "STSLPG":
                    sqlData = @"SELECT 
                                A.Nominasi, 
                                B.Flowrate 
                            FROM SubAktivitasInputDataKapalSTSPyrLPG A 
                            JOIN SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG B ON A.NoReferensi = B.NoReferensi
                            WHERE A.NoReferensi = @NoReferensi;";
                    sqlUpdateAgreement = @"UPDATE SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG SET LamaPembongkaran = @LamaPembongkaran WHERE NoReferensi = @NoReferensi";
                    sqlETC = @"
                        UPDATE na
                        SET na.ETC = DATEADD(SECOND, @LamaDetik,
                                    DATEADD(MINUTE, @LamaMenit,
                                    DATEADD(HOUR, @LamaJam, sb.Tanggal)))
                        FROM SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG na
                        JOIN SubAktivitasDataStartPenyaluranSTSPyrLPG sb ON na.NoReferensi = sb.NoReferensi
                        WHERE na.NoReferensi = @NoReferensi AND sb.Tanggal IS NOT NULL;
                    ";
                    break;
            };
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(data.NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Nominasi = reader.IsDBNull(reader.GetOrdinal("Nominasi")) 
                                ? 0f 
                                : Convert.ToSingle(reader["Nominasi"]);
                            Flowrate = reader.IsDBNull(reader.GetOrdinal("Flowrate")) 
                                ? 0f 
                                : Convert.ToSingle(reader["Flowrate"]);
                        }
                    }
                }
                if (Flowrate != 0) {
                    LamaPembongkaran = Nominasi / Flowrate;
                    using(SqlCommand updateAgreementCommand = new SqlCommand(sqlUpdateAgreement, sqlConnection))
                    {
                        updateAgreementCommand.Parameters.AddWithValue("@LamaPembongkaran", LamaPembongkaran);
                        updateAgreementCommand.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                        updateAgreementCommand.ExecuteNonQuery();
                    }
                    int jam = (int)Math.Floor(LamaPembongkaran);
                    float totalMenitDesimal = (LamaPembongkaran - jam) * 60;
                    int menit = (int)Math.Floor(totalMenitDesimal);
                    float sisaDetikDesimal = (totalMenitDesimal - menit) * 60;
                    int detik = (int)Math.Ceiling(sisaDetikDesimal);
                    using(SqlCommand updateAgreementCommand = new SqlCommand(sqlETC, sqlConnection))
                    {
                        updateAgreementCommand.Parameters.AddWithValue("@LamaJam", jam);
                        updateAgreementCommand.Parameters.AddWithValue("@LamaMenit", menit);
                        updateAgreementCommand.Parameters.AddWithValue("@LamaDetik", detik);
                        updateAgreementCommand.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                        updateAgreementCommand.ExecuteNonQuery();
                    }
                } else {
                    return Ok( new {
                        success = false,
                        message = "Gagal Generate Lama Pembongkaran dan ETC Nilai Agreement Karena Nilai Flowrate Kosong atau 0"
                    });
                }
            }
            if (data.Jenis.ToUpper() != "RTW")
            {
                UpdateLOPSlowPumping(data.NoReferensi, data.Jenis);
            }
            return Ok( new {
                success = true,
                LamaPembongkaran = LamaPembongkaran,
                ETC = ETC,
                message = "Berhasil Generate Lama Pembongkaran dan ETC Nilai Agreement Penyaluran Konsinyasi"
            });
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    private static DateTime TambahDurasiKeTanggal(DateTime start, double durasiJam)
    {
        int jam = (int)Math.Floor(durasiJam);
        double totalMenitDesimal = (durasiJam - jam) * 60;
        int menit = (int)Math.Floor(totalMenitDesimal);
        double sisaDetikDesimal = (totalMenitDesimal - menit) * 60;
        int detik = (int)Math.Ceiling(sisaDetikDesimal);
        var dt = start.AddHours(jam).AddMinutes(menit).AddSeconds(detik);
        return dt;
    }

    [HttpPost("generate_etc_konsinyasi_pipa")]
    public async Task<IActionResult> GenerateEtcKonsinyasiPipa([FromBody] UpdateByNoReferensi data)
    {
        if (!IsLoggedIn())
            return ErrorResponseDto("Not authorized.", StatusCodes.Status401Unauthorized);
        var master = await DatabaseQueryHelper.ExecuteSelectSingleAsync<
            (double Nominasi, double Flowrate, DateTime? TanggalStart, string TipeProses)
        >(
            @"SELECT TOP 1
                b.Nominasi,
                a.Flowrate,
                c.Tanggal,
                ak.TipeProses
            FROM SubAktivitasNilaiETCETAPipa a
            JOIN SubAktivitasInputDataPenyaluranKonsinyasiPipa b
                ON a.NoReferensi = b.NoReferensi
            JOIN SubAktivitasDataStartPenyaluranPipa c
                ON a.NoReferensi = c.NoReferensi
            JOIN Aktivitas ak ON a.idAktifitas = ak.IdAktivitas
            WHERE a.NoReferensi = @NoReferensi",
            reader => (
                reader.IsDBNull(0) ? 0d : Convert.ToDouble(reader.GetValue(0)),
                reader.IsDBNull(1) ? 0d : Convert.ToDouble(reader.GetValue(1)),
                reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                reader.IsDBNull(3) ? "" : reader.GetValue(3).ToString()
            ),
            new Dictionary<string, object>
            {
                { "@NoReferensi", data.NoReferensi }
            },
            noReferensi: data.NoReferensi
        );
        var (nominasi, flowrate, tanggalStart, tipeProses) = master;
        if (tanggalStart == null)
            return Ok(new
            {
                success = false,
                message = "Tanggal start penyaluran belum tersedia."
            });
        if (flowrate == 0)
            return Ok(new
            {
                success = false,
                message = "Flowrate tidak boleh 0 atau kosong."
            });
        double lamaPengisian = nominasi / flowrate;
        DateTime etc = TambahDurasiKeTanggal(tanggalStart.Value, lamaPengisian);
        await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
            @"UPDATE SubAktivitasNilaiETCETAPipa
            SET LamaPengisian = @LamaPengisian,
                ETC = @ETC
            WHERE NoReferensi = @NoReferensi",
            new Dictionary<string, object>
            {
                { "@NoReferensi", data.NoReferensi },
                { "@LamaPengisian", lamaPengisian },
                { "@ETC", etc }
            },
            noReferensi: data.NoReferensi
        );
        if (tipeProses == "PenyaluranPipaJarakDekat")
            return Ok(new
            {
                success = true,
                LamaPengisian = lamaPengisian,
                ETC = etc,
                message = "Berhasil generate LamaPengisian/ETC."
            });
        (double lamaJam, DateTime eta) HitungETA(double isiPipa)
        {
            if (isiPipa <= 0)
                return (0, tanggalStart.Value);
            double lamaPengiriman = Math.Round(isiPipa / flowrate, 4);
            DateTime eta = TambahDurasiKeTanggal(tanggalStart.Value, lamaPengiriman);
            return (lamaPengiriman, eta);
        }
        var anakRows = (await DatabaseQueryHelper.ExecuteSelectListQueryAsync(
            @"SELECT id, IsiPipa
            FROM SubAktivitasAnakNilaiETCETAPipa
            WHERE NoReferensi = @NoReferensi
            ORDER BY id",
            reader => new
            {
                Id = reader.GetInt32(0),
                IsiPipa = reader.IsDBNull(1) ? 0d : Convert.ToDouble(reader.GetValue(1))
            },
            new Dictionary<string, object>
            {
                { "@NoReferensi", data.NoReferensi }
            },
            noReferensi: data.NoReferensi
        )).ToList();
        var hasilAnak = new List<object>();
        foreach (var anak in anakRows)
        {
            var (lamaPengiriman, eta) = HitungETA(anak.IsiPipa);
            await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                @"UPDATE SubAktivitasAnakNilaiETCETAPipa
                SET LamaPengiriman = @LamaPengiriman,
                    ETA = @ETA
                WHERE id = @id
                    AND NoReferensi = @NoReferensi",
                new Dictionary<string, object>
                {
                    { "@NoReferensi", data.NoReferensi },
                    { "@id", anak.Id },
                    { "@LamaPengiriman", lamaPengiriman },
                    { "@ETA", eta }
                },
                noReferensi: data.NoReferensi
            );
            hasilAnak.Add(new
            {
                id = anak.Id,
                IsiPipa = anak.IsiPipa,
                LamaPengiriman = lamaPengiriman,
                ETA = eta
            });
        }
        return Ok(new
        {
            success = true,
            LamaPengisian = lamaPengisian,
            ETC = etc,
            Anak = hasilAnak,
            message = "Berhasil generate LamaPengisian/ETC dan LamaPengiriman/ETA."
        });
    }

    private static DateTime HitungETA(DateTime tanggalSekarang, double isiPipa, double totalTerima, double flowrate)
    {
        if (flowrate <= 0)
            throw new LogErrorException(
                "Flowrate tidak boleh kurang dari 0.", 
                StatusCodes.Status400BadRequest
            );
        double sisaVolume = isiPipa - totalTerima;
        double durasiJam = sisaVolume / flowrate;
        return tanggalSekarang.AddHours(durasiJam);
    }

    private async Task GenerateDynamicETCETA(string NoReferensi)
    {
        // cek tipe proses
        var tipeProses =
            await DatabaseQueryHelper.ExecuteSelectSingleAsync<string>(
                @"SELECT TOP 1 a.TipeProses
                FROM Aktivitas a
                JOIN SubAktivitasHasilPemeriksaanPipa b
                    ON a.IdAktivitas = b.idAktifitas
                WHERE b.NoReferensi = @NoReferensi",
                reader => reader.IsDBNull(0) ? "" : reader.GetString(0),
                new Dictionary<string, object> { { "@NoReferensi", NoReferensi } },
                noReferensi: NoReferensi
            );
        bool isPipaJarakDekat = tipeProses == "PenyaluranPipaJarakDekat";
        var (nominasi, tanggalStart) =
            await DatabaseQueryHelper.ExecuteSelectSingleAsync<(double, DateTime?)>(
                @"SELECT TOP 1
                    b.Nominasi,
                    c.Tanggal
                FROM SubAktivitasNilaiETCETAPipa a
                JOIN SubAktivitasInputDataPenyaluranKonsinyasiPipa b
                    ON a.NoReferensi = b.NoReferensi
                JOIN SubAktivitasDataStartPenyaluranPipa c
                    ON a.NoReferensi = c.NoReferensi
                WHERE a.NoReferensi = @NoReferensi",
                reader => (
                    reader.IsDBNull(0) ? 0d : Convert.ToDouble(reader.GetValue(0)),
                    reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1)
                ),
                new Dictionary<string, object> { { "@NoReferensi", NoReferensi } },
                noReferensi: NoReferensi
            );
        if (tanggalStart == null)
            throw new LogErrorException(
                "Tanggal start kosong.",
                StatusCodes.Status400BadRequest,
                noReferensi: NoReferensi
            );
        var listMasterData = (await DatabaseQueryHelper.ExecuteSelectListQueryAsync(
            @"SELECT Id, Tanggal, Flowrate, VolumeDischarge
            FROM SubAktivitasHasilPemeriksaanPipa
            WHERE NoReferensi = @NoReferensi
            ORDER BY etlDate ASC",
            reader => new
            {
                Id = reader.GetInt32(0),
                Tanggal = reader.IsDBNull(1) ? (DateTime?)null : reader.GetDateTime(1),
                Flowrate = reader.IsDBNull(2) ? 0d : Convert.ToDouble(reader.GetValue(2)),
                Quantity = reader.IsDBNull(3) ? 0d : Convert.ToDouble(reader.GetValue(3))
            },
            new Dictionary<string, object> { { "@NoReferensi", NoReferensi } },
            noReferensi: NoReferensi
        )).ToList();
        var listDetailData = (await DatabaseQueryHelper.ExecuteSelectListQueryAsync(
            @"SELECT id, IsiPipa
            FROM SubAktivitasAnakNilaiETCETAPipa
            WHERE NoReferensi = @NoReferensi
            ORDER BY id ASC",
            reader => new
            {
                Id = reader.GetInt32(0),
                IsiPipa = reader.IsDBNull(1) ? 0d : Convert.ToDouble(reader.GetValue(1))
            },
            new Dictionary<string, object>
            {
                { "@NoReferensi", NoReferensi }
            },
            noReferensi: NoReferensi
        )).ToList();
        if (listDetailData.Count == 0)
            return;
        if (listMasterData.Count == 0)
        {
            foreach (var anak in listDetailData)
            {
                await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                    @"UPDATE SubAktivitasAnakNilaiETCETAPipa
                    SET ETA_Dinamis = NULL
                    WHERE id = @Id;",
                    new Dictionary<string, object>
                    {
                        { "@Id", anak.Id }
                    },
                    noReferensi: NoReferensi
                );
            }
            return;
        }
        double totalTerima = 0;
        double totalTerimaKumulatif = 0;
        for (int i = 0; i < listMasterData.Count; i++)
        {
            var curr = listMasterData[i];
            if (curr.Flowrate <= 0)
                throw new LogErrorException("Flowrate harus lebih besar dari 0.", StatusCodes.Status400BadRequest, noReferensi: NoReferensi);
            if (curr.Tanggal == null)
                throw new LogErrorException("Tanggal pemeriksaan kosong.", StatusCodes.Status400BadRequest, noReferensi: NoReferensi);
            if (curr.Quantity < 0)
                throw new LogErrorException("Quantity tidak boleh minus.", StatusCodes.Status400BadRequest, noReferensi: NoReferensi);
            totalTerima = (i == 0) ? curr.Quantity : totalTerima + curr.Quantity;
            double sisaNominasi = nominasi - totalTerima;
            DateTime tanggalSekarang = curr.Tanggal.Value;
            DateTime ETC = tanggalSekarang.AddHours(sisaNominasi / curr.Flowrate);
            await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                @"UPDATE SubAktivitasHasilPemeriksaanPipa
                SET 
                    TotalTerima = @TotalTerima,
                    ETC = @ETC
                WHERE Id = @Id",
                new Dictionary<string, object>
                {
                    { "@Id", curr.Id },
                    { "@TotalTerima", totalTerima },
                    { "@ETC", ETC }
                },
                noReferensi: NoReferensi
            );
            totalTerimaKumulatif = totalTerima;
        }

        // jika PenyaluranPipaJarakDekat, tidak perlu generate ETA Dinamis
        if (isPipaJarakDekat)
            return;
        var last = listMasterData.Last();
        if (last.Tanggal == null)
            throw new LogErrorException(
                "Tanggal pemeriksaan terakhir kosong.",
                StatusCodes.Status400BadRequest,
                noReferensi: NoReferensi
            );
        if (last.Flowrate == 0)
            throw new LogErrorException(
                "Flowrate pemeriksaan terakhir tidak boleh 0 atau kosong.",
                StatusCodes.Status400BadRequest,
                noReferensi: NoReferensi
            );
        DateTime lastTanggal = last.Tanggal.Value;
        double lastFlowrate = last.Flowrate;
        foreach (var anak in listDetailData)
        {
            DateTime etaDinamis = HitungETA(lastTanggal, anak.IsiPipa, totalTerimaKumulatif, lastFlowrate);
            await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(
                @"UPDATE SubAktivitasAnakNilaiETCETAPipa
                SET ETA_Dinamis = @ETA_Dinamis
                WHERE id = @Id;",
                new Dictionary<string, object>
                {
                    { "@Id", anak.Id },
                    { "@ETA_Dinamis", etaDinamis }
                },
                noReferensi: NoReferensi
            );
        }
    }

    [HttpPost("UpdateSFADNewBL")]
    public IActionResult UpdateSFADNewBL([FromBody] UpdateByNoReferensi data)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." 
            };
            return Json(response);
        }
        try
        {
            string sqlData = "";
            switch (data.Jenis.ToUpper())
            {
                case "BBM":
                    sqlData = @"UPDATE A
                            SET 
                                A.NewBL_KLObs = B.NewBL_klobs,
                                A.NewBL_KL15 = B.NewBL_kl15,
                                A.NewBL_Barrels = B.NewBL_barrels,
                                A.NewBL_LT = B.NewBL_lt,
                                A.NewBL_MT = B.NewBL_mt,
                                A.SFAD_KLObs = B.SFAD_klobs,
                                A.SFAD_KL15 = B.SFAD_kl15,
                                A.SFAD_Barrels = B.SFAD_barrels,
                                A.SFAD_LT = B.SFAD_lt,
                                A.SFAD_MT = B.SFAD_mt
                            FROM SubAktivitasNilaiNewBLSFADSFBL A
                            JOIN SubAktivitasSFADNewBL B
                                ON A.NoPenerimaan = B.NoReferensi
                            WHERE B.NoReferensi = @NoReferensi;
                            ";
                    break;
                case "STSBBM":
                    sqlData = @"UPDATE A
                            SET 
                                A.NewBL_KLObs = B.NewBL_klobs,
                                A.NewBL_KL15 = B.NewBL_kl15,
                                A.NewBL_Barrels = B.NewBL_barrels,
                                A.NewBL_LT = B.NewBL_lt,
                                A.NewBL_MT = B.NewBL_mt,
                                A.SFAD_KLObs = B.SFAD_klobs,
                                A.SFAD_KL15 = B.SFAD_kl15,
                                A.SFAD_Barrels = B.SFAD_barrels,
                                A.SFAD_LT = B.SFAD_lt,
                                A.SFAD_MT = B.SFAD_mt
                            FROM SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM A
                            JOIN SubAktivitasSFADNewBLSTSPnrBBM B
                                ON A.NoPenerimaan = B.NoReferensi
                            WHERE B.NoReferensi = @NoReferensi;
                            ";
                    break;
                case "LPG":
                    sqlData = @"UPDATE A
                            SET 
                                A.NewBL_MT = B.NewBL_mt,
                                A.SFAD_MT = B.SFAD_mt
                            FROM SubAktivitasNilaiNewBLSFADSFBLLPG A
                            JOIN SubAktivitasSFADNewBLLPG B
                                ON A.NoPenerimaan = B.NoReferensi
                            WHERE B.NoReferensi = @NoReferensi;
                            ";
                    break;
                case "STSLPG":
                    sqlData = @"UPDATE A
                            SET 
                                A.NewBL_MT = B.NewBL_mt,
                                A.SFAD_MT = B.SFAD_mt
                            FROM SubAktivitasNilaiNewBLSFADSFBLLPG A
                            JOIN SubAktivitasSFADNewBLSTSLPG B
                                ON A.NoPenerimaan = B.NoReferensi
                            WHERE B.NoReferensi = @NoReferensi;
                            ";
                    break;
            };
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(data.NoReferensi));
                    sqlCommand.ExecuteNonQuery();
                }
            }
            return Ok(new { success = true, message = "Aktivitas Berhasil Diupdate."});
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    private void UpdateLOPSlowPumping(string NoReferensi, string? Jenis = "BBM") {
        DateTime? etc = null, stopBongkar = null;
        string sqlData = "";
        int idDokumen = 46;
        switch (Jenis.ToUpper())
        {
            case "BBM":
                sqlData =
                    @"SELECT A.ETC, S.Tanggal FROM SubaktivitasNilaiAgreementPenyaluran A JOIN SubaktivitasDataStopPenyaluran S
                        ON A.NoReferensi = S.NoReferensi
                        WHERE S.NoReferensi = @NoReferensi;";
                idDokumen = 46;
                break;
            case "STSBBM":
                sqlData =
                    @"SELECT A.ETC, S.Tanggal FROM SubaktivitasNilaiAgreementPenyaluranSTSPyrBBM A JOIN SubaktivitasDataStopPenyaluranSTSPyrBBM S
                        ON A.NoReferensi = S.NoReferensi
                        WHERE S.NoReferensi = @NoReferensi;";
                idDokumen = 155;
                break;
            case "LPG":
                sqlData =
                    @"SELECT A.ETC, S.Tanggal FROM SubaktivitasNilaiAgreementPenyaluranLPG A JOIN SubAktivitasDataStopPenyaluranLPG S
                        ON A.NoReferensi = S.NoReferensi
                        WHERE S.NoReferensi = @NoReferensi;";
                idDokumen = 105;
                break;
            case "STSLPG":
                sqlData =
                    @"SELECT A.ETC, S.Tanggal FROM SubaktivitasNilaiAgreementPenyaluranSTSPyrLPG A JOIN SubAktivitasDataStopPenyaluranSTSPyrLPG S
                        ON A.NoReferensi = S.NoReferensi
                        WHERE S.NoReferensi = @NoReferensi;";
                idDokumen = 201;
                break;
        }
        using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
        {
            using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@NoReferensi", EncodeForXSS(NoReferensi));
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["ETC"] != DBNull.Value)
                        {
                            etc = Convert.ToDateTime(reader["ETC"]);
                        }
                        if (reader["Tanggal"] != DBNull.Value)
                        {
                            stopBongkar = Convert.ToDateTime(reader["Tanggal"]);
                        }
                    }
                }
            }
            UpdateDokumenWajibUpload(sqlConnection, NoReferensi, stopBongkar > etc, idDokumen);
        }
    }

    [HttpPost("update_lop_slow_pumping")]
    public IActionResult update_lop_slow_pumping([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
        {
            var response = new 
            { 
                success = false, 
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." 
            };
            return Json(response);
        }
        try
        {
            UpdateLOPSlowPumping(data.NoReferensi, data.Jenis);
            return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate."});
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("get_penyaluran_volume")]
    public IActionResult GetPenyaluranVolume(string? NoReferensi)
    {
        if (!IsLoggedIn())
        {
            var response = new
            {
                success = false,
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan."
            };
            return Json(response);
        }
        try
        {
            float volume = 0;
            string sql = @"SELECT Volume FROM Penyaluran WHERE NomorPenyaluran = @NomorPenyaluran";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NomorPenyaluran", EncodeForXSS(NoReferensi));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            volume = reader.IsDBNull(reader.GetOrdinal("Volume"))
                                ? 0f
                                : Convert.ToSingle(reader["Volume"]);
                        }
                        else
                        {
                            return Ok(new
                            {
                                success = false,
                                message = "Data tidak ditemukan untuk NomorPenyaluran yang diberikan."
                            });
                        }
                    }
                }
            }
            return Ok(new
            {
                success = true,
                volume = volume,
                message = "Berhasil mengambil nilai Volume."
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, new
            {
                success = false,
                message = "Terjadi kesalahan di server.",
                error = ex.Message
            });
        }
    }

    [HttpGet("getnamalengkap")]
    public IActionResult GetNamaLengkap()
    {
        if (!IsLoggedIn())
        {
            var response = new
            {
                success = false,
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan."
            };
            return Json(response);
        }
        var nama = CurrentUserInfo("NamaLengkap")?.ToString();
        if (string.IsNullOrWhiteSpace(nama))
        {
            nama = CurrentUserName();
        }
        return Ok(new
        {
            success = true,
            namalengkap = nama
        });
    }

    // get status verify pdp ======
    [HttpGet("getverify")]
    public IActionResult GetVerify()
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        bool isVerify = false;
        bool isAdmin = false; // <== Tambahkan variabel flag admin

        // pengecualian: jika Administrator, anggap sudah verifikasi
        try {
            var userLevelStr = CurrentUserLevel() != null ? CurrentUserLevel().ToString() : "";
            if (userLevelStr == "-1") {        // Level "-1" = Administrator
                isAdmin = true;
                return Ok(new { success = true, isverify = true, isadmin = isAdmin });
            }
        } catch {
            // jika gagal membaca level user, lanjutkan ke proses normal
        }
        try {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(
                "SELECT ISNULL(IsVerify, 0) FROM MasterUser WHERE UPPER(Username) = UPPER(@Username)", conn))
            {
                cmd.Parameters.AddWithValue("@Username", CurrentUserName());
                object val = cmd.ExecuteScalar();
                // Jika baris tidak ditemukan, treat sebagai sudah verifikasi
                if (val == null) {
                    isVerify = true;
                } else {
                    isVerify = Convert.ToInt32(val) == 1;
                }
            }
        } catch (Exception ex) {
            return StatusCode(500, new { success = false, message = ex.Message });
        }
        return Ok(new { success = true, isverify = isVerify, isadmin = isAdmin });
    }

    // pdp update verify to 1 ======
    [HttpPost("updateverify")]
    public IActionResult UpdateVerify()
    {
        if (!IsLoggedIn())
            return StatusCode(401, new { success = false, message = "Not authorized." });
        try {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(
                "UPDATE MasterUser SET IsVerify = 1, DiperbaruiOleh = @Username, TanggalDiperbarui = GETDATE() WHERE Username = @Username", conn))
            {
                cmd.Parameters.AddWithValue("@Username", CurrentUserName());
                cmd.ExecuteNonQuery();
            }
            return Ok(new { success = true });
        } catch (Exception ex) {
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }
    // pdp reset verify to 0 ======
    [HttpPost("resetverify")]
    public IActionResult ResetVerify()
    {
        if (!IsLoggedIn())
            return StatusCode(401, new { success = false, message = "Not authorized." });

        // <<< tambahkan guard admin, supaya aman walau ada manipulasi client
        var lv = CurrentUserLevel()?.ToString();
        if (lv == "-1") // Admin
            return StatusCode(403, new { success = false, message = "Administrator tidak memerlukan fitur ini." });
        try {
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(
                "UPDATE MasterUser SET IsVerify = 0, DiperbaruiOleh = @Username, TanggalDiperbarui = GETDATE() " +
                "WHERE UPPER(Username) = UPPER(@Username)", conn))
            {
                cmd.Parameters.AddWithValue("@Username", CurrentUserName());
                cmd.ExecuteNonQuery();
            }
            return Ok(new { success = true });
        } catch (Exception ex) {
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    // Refactor Cognitive Complexity
    [HttpPost("CheckDeletableReferensi")]
    public IActionResult CheckDeletableReferensi([FromBody] DeleteReferensiRequest payload)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Not authorized.", StatusCodes.Status401Unauthorized);
        }
        var allowedLevels = new[] { "-1", "2", "4", "5" };
        if (!allowedLevels.Contains(CurrentUserLevel()))
        {
            return ErrorResponseDto("Anda tidak diizinkan menghapus data ini", StatusCodes.Status403Forbidden);
        }
        List<string> NoReferensiError = new List<string>();
        List<string> NoReferensiToDelete = new List<string>();
        string sql = "";
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                NoReferensiToDelete = GetDeleteReferenceNumbers(sqlConnection, payload);
                if (!NoReferensiToDelete.Any())
                {
                    return ErrorResponseDto("Tidak ada referensi yang dapat dihapus", StatusCodes.Status400BadRequest);
                }
                if (payload.Referensi == "Penerimaan")
                {
                    NoReferensiError.AddRange(ValidateDeletePenerimaanReferences(sqlConnection, payload.IdReferensi));
                }
                if (payload.Referensi == "Penyaluran")
                {
                    if (CurrentUserLevel() == "5")
                    {
                        return ErrorResponseDto("Anda tidak diizinkan menghapus data ini", StatusCodes.Status403Forbidden);
                    }
                    NoReferensiError.AddRange(ValidateDeletePenyaluranReferences(sqlConnection, payload.IdReferensi));
                }
                if (NoReferensiError.Any())
                {
                    return ErrorResponseDto($"Tidak dapat menghapus data: {string.Join(", ", NoReferensiError)} karena telah digunakan oleh proses yang lain", StatusCodes.Status400BadRequest);
                }
                if (CurrentUserLevel() == "5")
                {
                    var authResult =
                        ValidateUserDeleteReferences(sqlConnection, payload);
                    NoReferensiError.AddRange(authResult.Item2);
                }
                if (NoReferensiError.Any())
                {
                    return ErrorResponseDto($"Tidak dapat menghapus data: {string.Join(", ", NoReferensiError)} karena bukan merupakan data yang anda buat", StatusCodes.Status400BadRequest);
                }
                foreach (var item in NoReferensiToDelete)
                {
                    sql = "SP_DeleteReferensi";
                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@noReferensi", item);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return Ok(
            new
            {
                success = true,
                message = "Berhasil menghapus data!"
            }
        );
    }

    private List<string> GetDeleteReferenceNumbers(SqlConnection connection, dynamic payload)
    {
        var referenceNumbers = new List<string>();
        const string sql = "SELECT Nomor{0} FROM {0} WHERE Id{0} = @item";
        foreach (var item in payload.IdReferensi)
        {
            var query = string.Format(sql, payload.Referensi);
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@item", item);
            using var reader = command.ExecuteReader();
            if (reader.Read() && reader.HasRows)
            {
                var referenceNumber = reader[$"Nomor{payload.Referensi}"]?.ToString();
                if (!string.IsNullOrEmpty(referenceNumber))
                {
                    referenceNumbers.Add(referenceNumber);
                }
            }
        }
        return referenceNumbers;
    }

    private List<string> ValidateDeletePenerimaanReferences(SqlConnection connection, IEnumerable<string> idList)
    {
        var errorReferences = new List<string>();
        const string sql = @"
        SELECT TOP 1 PR.NomorPenerimaan 
        FROM Penimbunan PN 
        JOIN Penerimaan PR ON PN.IdPenerimaan = PR.IdPenerimaan
        WHERE PR.IdPenerimaan = @IdPenerimaan";
        foreach (var id in idList)
        {
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPenerimaan", id);
            using var reader = command.ExecuteReader();
            if (reader.Read() && reader.HasRows)
            {
                var nomorPenerimaan = reader["NomorPenerimaan"]?.ToString();
                if (!string.IsNullOrEmpty(nomorPenerimaan))
                {
                    errorReferences.Add(nomorPenerimaan);
                }
            }
        }
        return errorReferences;
    }

    // Refactor Cognitive Complexity
    private List<string> ValidateDeletePenyaluranReferences(SqlConnection connection, IEnumerable<string> idList)
    {
        var errorReferences = new List<string>();
        string sql = "";
        foreach (var item in idList)
        {
            sql = @"SELECT TOP 1
                                    PN.NomorPenyaluran 
                                FROM Penyaluran PN 
                                JOIN PenimbunanPenyaluran PP ON PN.NomorPenyaluran = PP.NoPenyaluran
                                WHERE PN.IdPenyaluran = @IdPenyaluran";
            using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
            {
                sqlCommand.Parameters.AddWithValue("@IdPenyaluran", item);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string NoPenyaluran = reader["NomorPenyaluran"].ToString() ?? "";
                        if (!string.IsNullOrEmpty(NoPenyaluran) && !errorReferences.Contains(NoPenyaluran)) //4
                        {
                            errorReferences.Add(NoPenyaluran);
                        }
                    }
                }
            }
            sql = @"SELECT TOP 1
                                    PN.NomorPenyaluran 
                                FROM Penyaluran PN 
                                JOIN SamplingLabTest ST ON PN.NomorPenyaluran = ST.IdReferensi
                                WHERE PN.IdPenyaluran = @IdPenyaluran";
            using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
            {
                sqlCommand.Parameters.AddWithValue("@IdPenyaluran", item);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string NoPenyaluran = reader["NomorPenyaluran"].ToString() ?? "";
                        if (!string.IsNullOrEmpty(NoPenyaluran) && !errorReferences.Contains(NoPenyaluran))
                        {
                            errorReferences.Add(NoPenyaluran);
                        }
                    }
                }
            }
        }
        return errorReferences;
    }

    // Refactor Cognitive Complexity
    private (bool, List<string>) ValidateUserDeleteReferences(SqlConnection sqlConnection, DeleteReferensiRequest payload)
    {
        var isDelete = true;
        var NoReferensiError = new List<string>();
        string sql;
        foreach (var item in payload.IdReferensi)
        {
            sql = $"SELECT Nomor{payload.Referensi} AS Nomor, DibuatOleh FROM {payload.Referensi} WHERE Id{payload.Referensi} = @item";
            using (var sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@item", item);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.Read()) continue;
                    var nomor = reader["Nomor"].ToString() ?? "";
                    var dibuatOleh = reader["DibuatOleh"];
                    bool valid = dibuatOleh?.ToString() == CurrentUserName();
                    if (!valid)
                    {
                        isDelete = false;
                        NoReferensiError.Add(nomor);
                    }
                }
            }
        }
        return (isDelete, NoReferensiError);
    }

    [HttpGet("GetTotalTangki")]
    public IActionResult GetTotalTangki(int idTangki, int idPlant, string? idProduk = null)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Not authorized.", StatusCodes.Status401Unauthorized);
        }
        int totalTangki = 0;
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string checkPlantSql = @"SELECT TOP 1 MP.JenisPlant
                                        FROM MasterTangki MT
                                        JOIN MasterPlant MP ON MT.Plant = MP.Plant
                                        WHERE MT.Id = @IdTangki 
                                          AND LOWER(MT.Status) = 'operasi'";
                string jenisPlant = "";
                using (SqlCommand cmdCheck = new SqlCommand(checkPlantSql, sqlConnection))
                {
                    cmdCheck.Parameters.AddWithValue("@IdTangki", idTangki);
                    var result = cmdCheck.ExecuteScalar();
                    jenisPlant = result?.ToString()?.ToUpper() ?? "";
                }
                if (jenisPlant == "STS")
                {
                    return Ok(new
                    {
                        success = true,
                        totalTangki = 0,
                        jenisPlant = jenisPlant,
                    });
                }
                DateTime DateTimeNow = DateTime.Now;
                string getTimeSql = "EXEC dbo.GetPlantDateTime @IdPlant = @Plant";
                using (SqlCommand getTimeCmd = new SqlCommand(getTimeSql, sqlConnection))
                {
                    getTimeCmd.Parameters.AddWithValue("@Plant", idPlant);
                    var result = getTimeCmd.ExecuteScalar();
                    if (result != null && DateTime.TryParse(result.ToString(), out var dt))
                    {
                        DateTimeNow = dt;
                    }
                }
                string sqlData = @"SELECT COUNT(*) as TotalTangki 
                                  FROM ClosingStock 
                                  WHERE IdTangki = @IdTangki 
                                  AND CAST(TanggalDibuat AS DATE) = CAST(@PlantTime AS DATE)";
                if (!string.IsNullOrEmpty(idProduk))
                {
                    sqlData += " AND Produk = @IdProduk";
                }
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdTangki", idTangki);
                    sqlCommand.Parameters.AddWithValue("@PlantTime", DateTimeNow);
                    if (!string.IsNullOrEmpty(idProduk))
                    {
                        sqlCommand.Parameters.AddWithValue("@IdProduk", idProduk);
                    }
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalTangki = reader["TotalTangki"] != DBNull.Value ? Convert.ToInt32(reader["TotalTangki"]) : 0;
                        }
                    }
                }
            }
            return Ok(new
            {
                success = true,
                totalTangki = totalTangki
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return ErrorResponseDto("Terjadi kesalahan dalam memproses data", StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("GetMeterAwalBayNumber")]
    public IActionResult GetMeterAwalBayNumber(string? TableAnak, string? NoReferensi, string? BayNumber = "", string? NoMeter = "")
    {
        if (!IsLoggedIn())
        {
            return Json( 
                new {
                    success = false,
                    message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan."
                }
            );
        }
        List<string> allowedTables = new List<string> {
            "SubAktivitasLogbookPenerimaanPenyaluran", 
            "SubAktivitasLogbookPenerimaanPenyaluranLPG",
            "SubAktivitasInputDataRTW"
        };
        if (!allowedTables.Contains(TableAnak))
        {
            return Json( new { success = false, message = "Nama Table Tidak Valid" } );
        }
        if (string.IsNullOrEmpty(BayNumber) && string.IsNullOrEmpty(NoMeter)) {
            return Json( 
                new {
                    success = false,
                    message = $"Bay Number & No Meter is Null"
                }
            );
        }
        Dictionary<string, object> response = new Dictionary<string, object>();
        float meterAkhirValue = 0;
        string sql = "";
        switch (TableAnak)
        {
            case "SubAktivitasLogbookPenerimaanPenyaluran":
                sql = $@"
                    SELECT TOP 1 SA.MeterAkhir
                    FROM {TableAnak} SA
                    JOIN Penyaluran P ON SA.NoReferensi = P.NomorPenyaluran
                    WHERE SA.BayNumber = @BayNumber
                    AND SA.NoMeter = @NoMeter
                    AND P.IdPlant = (
                        SELECT TOP 1 IdPlant 
                        FROM Penyaluran 
                        WHERE NomorPenyaluran = @NoReferensi
                    )
                    ORDER BY SA.etlDate DESC;
                ";
                break;
            case "SubAktivitasLogbookPenerimaanPenyaluranLPG":
                sql = $@"
                    SELECT TOP 1 SA.MeterAkhir
                    FROM {TableAnak} SA
                    JOIN Penyaluran P ON SA.NoReferensi = P.NomorPenyaluran
                    WHERE SA.BayNumber = @BayNumber
                    AND P.IdPlant = (
                        SELECT TOP 1 IdPlant 
                        FROM Penyaluran 
                        WHERE NomorPenyaluran = @NoReferensi
                    )
                    ORDER BY SA.etlDate DESC;
                ";
                break;
            case "SubAktivitasInputDataRTW":
                sql = $@"
                    SELECT TOP 1 SA.MeterAkhir
                    FROM {TableAnak} SA
                    JOIN Penyaluran P ON SA.NoReferensi = P.NomorPenyaluran
                    WHERE SA.NoMeter = @NoMeter
                    AND P.IdPlant = (
                        SELECT TOP 1 IdPlant 
                        FROM Penyaluran 
                        WHERE NomorPenyaluran = @NoReferensi
                    )
                    ORDER BY SA.etlDate DESC;
                ";
                break;
        }
        try {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection()) {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", NoReferensi);
                    if (TableAnak == "SubAktivitasLogbookPenerimaanPenyaluran")
                    {
                        sqlCommand.Parameters.AddWithValue("@BayNumber", BayNumber);                    
                        sqlCommand.Parameters.AddWithValue("@NoMeter", NoMeter);                    
                    }
                    else if (TableAnak == "SubAktivitasLogbookPenerimaanPenyaluranLPG")
                    {
                        sqlCommand.Parameters.AddWithValue("@BayNumber", BayNumber);
                    }
                    else if (TableAnak == "SubAktivitasInputDataRTW")
                    {
                        sqlCommand.Parameters.AddWithValue("@NoMeter", NoMeter);
                    }
                    using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                        if (reader.Read()) {
                            var meterAkhirObj = reader["MeterAkhir"];
                            if (meterAkhirObj != DBNull.Value)
                            {
                                if (float.TryParse(meterAkhirObj.ToString(), out meterAkhirValue))
                                {
                                    response["success"] = true;
                                    response["MeterAkhir"] = meterAkhirValue;
                                }
                                else
                                {
                                    response["success"] = false;
                                }
                            }
                            else
                            {
                                response["success"] = false;
                            }
                        }
                    }
                }
            }
        } 
        catch (Exception ex)
        {
            response["success"] = false;
            response["message"] = ex;
            Console.WriteLine(ex);
        }
        return Json(response);
    }

    [HttpPost("SendEmail")]
    public async Task<IActionResult> SendEmail([FromBody] SendEmailRequest payload)
    {
        try
        {
            string sql = "SELECT TOP 1 IdUser, Email, Username, NamaLengkap FROM MasterUser WHERE Email = @Email;";
            string Email = "", Username = "", Name = "", IdUser = "";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Email", payload.Email);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Email = reader["Email"]?.ToString() ?? "";
                            Username = reader["Username"]?.ToString() ?? "";
                            Name = reader["NamaLengkap"]?.ToString() ?? "";
                            IdUser = reader["IdUser"]?.ToString() ?? "";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Username))
                {
                    string fullUrl = $"{Request.Scheme}://{Request.Host}/login";
                    var activateLink = fullUrl + "?action=resetpassword";
                    activateLink += "&user=" + RawUrlEncode(IdUser);
                    string code = IdUser + "," + StdCurrentDateTime();
                    activateLink += "&code=" + Encrypt(code);
                    string EmailBody = $@"
                    <html>
                    <head>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                            }}
                            p, a {{
                                margin-bottom: 4px;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='content'>
                            <p>Dengan hormat, Bapak/Ibu {Name}.</p>
                            <br>
                            <p>Untuk memulai proses pengaturan ulang kata sandi untuk akun Anda (Username: {Username}), silakan klik tautan di bawah ini:</p>
                            <a href='{activateLink}'> Reset Password </a>
                            <p>Jika mengeklik tautan di atas tidak berhasil, salin dan tempel URL di jendela browser baru untuk melakukan pengaturan ulang kata sandi.</p>
                            <p>Anda dapat mengabaikan email ini dengan aman jika Anda bukan pihak yang meminta pengaturan ulang kata sandi. Pengguna lain mungkin tidak sengaja memasukkan alamat email Anda saat mencoba mengatur ulang kata sandinya.</p>
                            <br>
                            <p>Salam Hormat,</p>
                            <p>S&D One</p>
                        </div>
                    </body>
                    </html>";
                    await SendMblastNotification(Name, Email, "Reset Password", EmailBody);
                    sql = "UPDATE MasterUser SET IsResetable = CAST(1 AS BIT) WHERE Email = @Email;";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Email", payload.Email);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    return Json(
                        new
                        {
                            success = false,
                            message = "Email tidak terdaftar dalam sistem kami"
                        }
                    );
                }
            }
        }
        catch (Exception ex)
        {
            return Json(
                new
                {
                    success = false,
                    message = "Terjadi kesalahan di server",
                    error = ex
                }
            );
        }
        return Ok(
            new
            {
                success = true,
                message = "Berhasil mengirim email reset password!"
            }
        );
    }

    private async Task<string> GetMblastToken()
    {
        try
        {
            Console.WriteLine("[DEBUG] Requesting Mblast Token...");
            string tokenUrl = Configuration["Mblast:TokenUrl"];
            using (var client = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(Configuration["Mblast:ClientId"]?.Trim() ?? ""), "client_id");
                content.Add(new StringContent(Configuration["Mblast:ClientSecret"]?.Trim() ?? ""), "client_secret");
                content.Add(new StringContent(Configuration["Mblast:GrantType"]?.Trim() ?? ""), "grant_type");
                content.Add(new StringContent(Configuration["Mblast:Scope"]?.Trim() ?? ""), "scope");
                var response = await client.PostAsync(tokenUrl, content);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("[DEBUG] Token Retrieved Successfully.");
                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        return doc.RootElement.GetProperty("access_token").GetString();
                    }
                }
                Console.WriteLine($"[DEBUG-ERROR] Token Failed. Status: {response.StatusCode}. Response: {jsonString}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[DEBUG-EXCEPTION] Token Error: " + ex.Message);
        }
        return "";
    }

    private async Task SendMblastNotification(string recipientName, string recipientEmail, string subject, string body)
    {
        Console.WriteLine($"[DEBUG] Preparing to send email to: {recipientEmail}");
        string token = await GetMblastToken();
        if (string.IsNullOrEmpty(token)) 
        {
            Console.WriteLine("[DEBUG-ERROR] Cannot send email: Token is empty.");
            return;
        }
        string mailUrl = Configuration["Mblast:MailUrl"];
        string finalBody = body.Replace("[Nama User]", recipientName);
        finalBody = finalBody.Replace("\r\n", "<br>").Replace("\n", "<br>");
        try
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(Configuration["Mblast:AppId"]), "AppId");
                formData.Add(new StringContent(Configuration["Mblast:AppSecret"]), "AppSecret");
                formData.Add(new StringContent(recipientEmail), "To");
                formData.Add(new StringContent(subject), "Subject");
                formData.Add(new StringContent(finalBody), "Body");

                // Execute Request
                var response = await client.PostAsync(mailUrl, formData);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"[DEBUG] Email Sent Successfully to {recipientEmail}. Response: {responseString}");
                }
                else 
                {
                    Console.WriteLine($"[DEBUG-ERROR] Email API Failed. Status: {response.StatusCode}. Details: {responseString}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[DEBUG-EXCEPTION] Email Exception ({recipientEmail}): " + ex.Message);
        }
    }

    private async Task ProcessEmailQueue(string plantId, string subjectTemplate, string bodyTemplate, Dictionary<string, string> placeholders)
    {
        try 
        {
            List<(string Name, string Email)> recipients = new();
            string testEmail = Configuration["Mblast:TestEmail"];
            Console.WriteLine($"[DEBUG] Checking Email Configuration. TestEmail value: '{testEmail}'");
            if (!string.IsNullOrEmpty(testEmail))
            {
                recipients.Add(("Tester", testEmail)); 
                Console.WriteLine($"[DEBUG] MODE: TESTING. Target: {testEmail}");
            }
            else
            {
                Console.WriteLine($"[DEBUG] MODE: ACTUAL. Querying database for users...");
                string dbName = Configuration["Databases:DB:dbname"];
                string dbUser = Configuration["Databases:DB:username"];
                string dbPass = Configuration["Databases:DB:password"];
                string baseConn = Configuration["Databases:DB:connectionstring"];
                string connectionString = baseConn
                    .Replace("{dbname}", dbName)
                    .Replace("{uid}", dbUser)
                    .Replace("{pwd}", dbPass);
                using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"
                        SELECT DISTINCT mu.NamaLengkap, mu.Email 
                        FROM MasterUser mu
                        JOIN MappingPosition mp ON mu.IdPosition = mp.IdPosition
                        WHERE mp.IdPlant = @IdPlant AND mu.Email IS NOT NULL AND LEN(mu.Email) > 5 AND mu.UserLevel = 2 AND mu.[Rule] = '10'";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPlant", plantId);
                        using (var rdr = await cmd.ExecuteReaderAsync())
                        {
                            while (await rdr.ReadAsync())
                            {
                                recipients.Add((rdr["NamaLengkap"].ToString(), rdr["Email"].ToString()));
                            }
                        }
                    }
                }
                Console.WriteLine($"[Email Mode] ACTUAL. Found {recipients.Count} recipients.");
            }
            foreach(var kvp in placeholders)
            {
                bodyTemplate = bodyTemplate.Replace(kvp.Key, kvp.Value);
            }
            foreach (var user in recipients)
            {
                await SendMblastNotification(user.Name, user.Email, subjectTemplate, bodyTemplate);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("[DEBUG-CRITICAL] ProcessEmailQueue Crash: " + ex.Message);
        }
    }

    private bool ValidateLinkResetPassword(string action, string user, string code)
    {
        string[] activateCode = Decrypt(code).Split(',');
        DateTime? dt = activateCode.Length > 1 ? ParseDateTime(activateCode[1]) : null;
        string activateUser = activateCode.Length > 0 ? activateCode[0] : "";
        double diff = dt.HasValue ? ((TimeSpan)(DateTime.Now - dt.Value)).TotalMinutes : -1;
        if (!SameString(user, activateUser) || diff < 0 || diff > 60 || !SameText(action, "resetpassword")) {
            return false;
        }
        string sql = "SELECT TOP 1 Username, IsResetable FROM MasterUser WHERE IdUser = @IdUser;";
        using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
        {
            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@IdUser", user);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bool IsResetable = reader["IsResetable"] != DBNull.Value && (bool)reader["IsResetable"];
                        if (!IsResetable) {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    [HttpPost("ValidateResetPassword")]
    public IActionResult ValidateResetPassword([FromBody] ValidateResetPasswordRequest payload)
    {
        return Json(
            new
            {
                success = true,
                valid = ValidateLinkResetPassword(payload.Action, payload.User, payload.Code)
            }
        );
    }

    [HttpPost("ResetPassword")]
    public IActionResult ResetPassword([FromBody] ResetPasswordRequest payload)
    {
        try
        {
            if (!ValidateLinkResetPassword(payload.Action, payload.User, payload.Code)) {
                return Json(
                    new
                    {
                        success = false,
                        message = "Link reset password tidak valid"
                    }
                );
            }
            if (payload.NewPassword != payload.NewPasswordConfirm)
            {
                return Json(
                    new
                    {
                        success = false,
                        message = "Password dan konfirmasi password tidak sama"
                    }
                );
            }
            string sql = "SELECT TOP 1 Username FROM MasterUser WHERE IdUser = @IdUser;";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdUser", payload.User);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string Username = reader["Username"]?.ToString() ?? "";
                            if (!string.IsNullOrEmpty(Username)) {
                                var hasher = MD5.Create();
                                byte[] data = hasher.ComputeHash(Config.Md5Encoding.GetBytes(payload.NewPassword));
                                var builder = new StringBuilder();
                                for (int i = 0; i < data.Length; i++)
                                    builder.Append(data[i].ToString("x2"));
                                var md5 = builder.ToString();
                                sql = "UPDATE MasterUser SET PasswordHash = @md5, IsResetable = CAST(0 AS BIT) WHERE IdUser = @IdUser;";
                                using (SqlCommand sqlCommand2 = new SqlCommand(sql, sqlConnection))
                                {
                                    sqlCommand2.Parameters.AddWithValue("@IdUser", payload.User);
                                    sqlCommand2.Parameters.AddWithValue("@md5", md5);
                                    sqlCommand2.ExecuteNonQuery();
                                }
                            } else {
                                return Json(
                                    new
                                    {
                                        success = false,
                                        message = "Username tidak ditemukan"
                                    }
                                );
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return Json(
                new
                {
                    success = false,
                    message = "Terjadi kesalahan di server",
                    error = ex
                }
            );
            Console.WriteLine(ex);
        }
        return Ok(
            new
            {
                success = true,
                message = "Berhasil reset password!"
            }
        );
    }

    [HttpGet("GetIdReferensi")]
    public IActionResult GetIdReferensi(string NoReferensi, string Referensi)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        try
        {
            string IdReferensi = "";
            string sqlCekStatusAktivitas = $@"SELECT Id{Referensi} from {Referensi} where Nomor{Referensi} = @NoReferensi";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlCekStatusAktivitas, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", NoReferensi);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IdReferensi = reader[$"Id{Referensi}"]?.ToString() ?? "";
                        }
                    }
                }
            }
            return Ok(new
            {
                success = true,
                IdReferensi = IdReferensi,
                Referensi = Referensi
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    private IActionResult ErrorResponseDto(string message, int statusCode = 501)
    {
        var response = new
        {
            statusCode = statusCode,
            success = false,
            message = message
        };
        return Json(response);
    }

    [HttpPost("ExportAktivitasTabel")]
    public IActionResult ExportAktivitasTabel([FromBody] ExportAktivitasTabelRequest payload)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        try
        {
            Dictionary<string, (string Table, string Sql)> map = new(StringComparer.OrdinalIgnoreCase)
            {
                ["SubaktivitasHasilPemeriksaan"] = ("SubaktivitasHasilPemeriksaan", @"SELECT NamaKegiatan, TanggalJam, Density, Temperature, Pressure, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasFormInputHslPemeriksaan"] = ("SubAktivitasFormInputHslPemeriksaan", @"SELECT NamaKegiatan, Tanggal, Density, Temperature, Pressure, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasHasilPemeriksaanPipa"] = ("SubAktivitasHasilPemeriksaanPipa", @"SELECT Nama_Kegiatan, Tanggal, VolumeDischarge AS Quantity, Density, Temperatur, Pressure, Flowrate, TotalTerima, ETC, ETA, ETA2, ETA3, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasHasilPemeriksaanLPG"] = ("SubAktivitasHasilPemeriksaanLPG", @"SELECT NamaKegiatan, TanggalJam, Density, Temperature, Pressure, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasHasilPemeriksaanSTSLPG"] = ("SubAktivitasHasilPemeriksaanSTSLPG", @"SELECT NamaKegiatan, TanggalJam, Density, Temperature, Pressure, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubaktivitasInputHasilPemeriksaanPipa"] = ("SubaktivitasInputHasilPemeriksaanPipa", @"SELECT NamaKegiatan, TanggalJam, Density, Temperature, Pressure, QuantityDischarge AS Quantity, Flowrate, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubaktivitasRencanaPenyaluranPipa"] = ("SubaktivitasRencanaPenyaluranPipa", @"SELECT A.Produk + ' - ' + MP.NamaProduk AS Produk, A.TanggalJam, A.RencanaPenyaluran, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookPenerimaan"] = ("SubAktivitasLogbookPenerimaan", @"SELECT A.Nama_Kapal, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.Nama_Kegiatan, A.TanggalJamSOP AS [Tanggal Jam SOP], A.TanggalJam AS [Tanggal Jam Aktual], A.SelisihWaktu, CASE WHEN A.IsQualityActive = 1 THEN 'On' ELSE 'Off' END AS Quality, A.Density, A.Temperatur, A.Keterangan, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookPenerimaanLPG"] = ("SubAktivitasLogbookPenerimaanLPG", @"SELECT A.Nama_Kapal, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.Nama_Kegiatan, A.TanggalJam, A.Density, A.Temperatur, A.Keterangan, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookPenerimaanSTSPymBBM"] = ("SubAktivitasLogbookPenerimaanSTSPymBBM", @"SELECT A.Nama_Kapal, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.Nama_Kegiatan, A.TanggalJam, A.Density, A.Temperatur, A.Keterangan, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookPenerimaanSTSPymLPG"] = ("SubAktivitasLogbookPenerimaanSTSPymLPG", @"SELECT A.Nama_Kapal, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.Nama_Kegiatan, A.TanggalJam, A.Density, A.Temperatur, A.Keterangan, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasFormInputLogbookPenerimaanPipa"] = ("SubAktivitasFormInputLogbookPenerimaanPipa", @"SELECT NamaKegiatan, NamaBatch, TanggalJam, Density, Temperature, Level, Volume AS Quantity, Flowrate, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookMonitoringStock"] = ("SubAktivitasLogbookMonitoringStock", @"SELECT CAST(A.IdPlant AS VARCHAR(50)) + ' - ' + MPT.Nama_Terminal AS Plant, MT.Sloc + ' - ' + MT.SeqTangki + ' - ' + MT.NamaTerminal AS Tangki, A.Produk + ' - ' + MP.NamaProduk AS Produk, Aktivitas, Level_Tangki, Volume_KLObs AS Quantity, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk LEFT JOIN MasterTangki MT ON A.Nomor_Tangki = MT.id LEFT JOIN MasterPlant MPT ON A.IdPlant = MPT.IdPlant WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookPenerimaanPenyaluran"] = ("SubAktivitasLogbookPenerimaanPenyaluran", @"SELECT A.LO, MT.Sloc + ' - ' + MT.SeqTangki + ' - ' + MT.NamaTerminal AS Tangki, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.MeterAwal, A.MeterAkhir, A.Volume AS Quantity, A.BayNumber, A.NomorKompartment, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk LEFT JOIN MasterTangki MT ON A.NomorTangki = MT.id WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasRencanaPenyaluranPerProduk"] = ("SubAktivitasRencanaPenyaluranPerProduk", @"SELECT A.Produk + ' - ' + MP.NamaProduk AS Produk, A.Shift1, A.Shift2, A.Shift3, A.Shift4, Total, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasRealisasiPenyaluranPerProduk"] = ("SubAktivitasRealisasiPenyaluranPerProduk", @"SELECT A.Produk + ' - ' + MP.NamaProduk AS Produk, A.Shift1, A.Shift2, A.Shift3, A.Shift4, Total, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasHasilPemeriksaanPenyaluran"] = ("SubAktivitasHasilPemeriksaanPenyaluran", @"SELECT NamaKegiatan, Tanggal, Density, Temperature, Pressure, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM"] = ("SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM", @"SELECT NamaKegiatan, Tanggal, Density, Temperature, Pressure, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasHasilPemeriksaanPenyaluranLPG"] = ("SubAktivitasHasilPemeriksaanPenyaluranLPG", @"SELECT NamaKegiatan, Tanggal, Density, Temperature, Pressure, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasInputLogbookPenerimaanPenKon"] = ("SubAktivitasInputLogbookPenerimaanPenKon", @"SELECT A.Nama_Kegiatan, A.Nama_Kapal, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.Tanggal, A.Density, A.Temperatur, A.Keterangan, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasInputLogbookPenerimaanPenKonLPG"] = ("SubAktivitasInputLogbookPenerimaanPenKonLPG", @"SELECT A.Nama_Kegiatan, A.Nama_Kapal, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.Tanggal, A.Density, A.Temperatur, A.Keterangan, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasInputLogbookPenerimaanPipa"] = ("SubAktivitasInputLogbookPenerimaanPipa", @"SELECT A.NamaKegiatan, A.NamaBatch, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.TanggalJam, A.Density, A.Temperature, A.Keterangan, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasFormInputLogbookPenerimaanTruck"] = ("SubAktivitasFormInputLogbookPenerimaanTruck", @"SELECT A.NamaKegiatan, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.TanggalJamSOP, A.SelisihWaktu, A.IsQualityActive AS Quality, A.Tanggal, A.Density, A.Temperatur, A.Keterangan, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookPenerimaanPenyaluranLPG"] = ("SubAktivitasLogbookPenerimaanPenyaluranLPG", @"SELECT MT.Sloc + ' - ' + MT.SeqTangki + ' - ' + MT.NamaTerminal AS Tangki, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.SPA, A.BayNumber, A.Quantity, A.MeterAwal, A.MeterAkhir, A.PresentaseLevelRotoGauge, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk LEFT JOIN MasterTangki MT ON A.NomorTangki = MT.id WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubaktivitasInputLogbookPenyaluranPipa"] = ("SubaktivitasInputLogbookPenyaluranPipa", @"SELECT MT.Sloc + ' - ' + MT.SeqTangki + ' - ' + MT.NamaTerminal AS Tangki, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.LO, A.Quantity, A.MeterAwal, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk LEFT JOIN MasterTangki MT ON A.NomorTangki = MT.id WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookJembatanTimbangLPG"] = ("SubAktivitasLogbookJembatanTimbangLPG", @"SELECT MT.Sloc + ' - ' + MT.SeqTangki + ' - ' + MT.NamaTerminal AS Tangki, A.Produk + ' - ' + MP.NamaProduk AS Produk, A.SPA, A.TimbanganAwal, A.TimbanganAkhir, A.NetWight, A.PresentaseLevelRotoGauge, A.userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk LEFT JOIN MasterTangki MT ON A.NomorTangki = MT.id WHERE A.idAktifitas = @IdAktivitas;"),
                ["SubAktivitasFormInputLogbookPenerimaanRTW"] = ("SubAktivitasFormInputLogbookPenerimaanRTW", @"SELECT NamaKegiatan, Tanggal, A.Produk + ' - ' + MP.NamaProduk AS Produk, Volume AS Quantity, Density, Flowrate, Level, Keterangan, userInput AS DibuatOleh, etlDate AS TanggalDibuat, LastUpdatedBy AS DiperbaruiOleh, lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasFormInputMonitoringStockSTSPymSBBM"] = ("SubAktivitasFormInputMonitoringStockSTSPymSBBM", @"SELECT Aktivitas AS NamaKegiatan, TanggalQuantityAwal, QuantityAwal AS MeterAwal, TanggalQuantityAkhir, QuantityAkhir AS MeterAkhir, A.Produk + ' - ' + MP.NamaProduk AS Produk, MT.Sloc + ' - ' + MT.SeqTangki + ' - ' + MT.NamaTerminal AS Tangki, Flowrate, Keterangan, userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk LEFT JOIN MasterTangki MT ON A.NomorTangki = MT.id WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasFormInputLogbookPenerimaanSTSPymBBM"] = ("SubAktivitasFormInputLogbookPenerimaanSTSPymBBM", @"SELECT Nama_Kapal, Tanggal, Nama_Kegiatan, A.Produk + ' - ' + MP.NamaProduk AS Produk, Density, Temperatur, Keterangan, userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasLogbookMonitoringStockPipa"] = ("SubAktivitasLogbookMonitoringStockPipa", @"SELECT Aktivitas AS NamaKegiatan, A.Produk + ' - ' + MP.NamaProduk AS Produk, MT.Sloc + ' - ' + MT.SeqTangki + ' - ' + MT.NamaTerminal AS Tangki, Level_Tangki, Flowrate, userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk LEFT JOIN MasterTangki MT ON A.Nomor_Tangki = MT.id WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasFormInputLogbookPenerimaanSTSPymLPG"] = ("SubAktivitasFormInputLogbookPenerimaanSTSPymLPG", @"SELECT Nama_Kegiatan, Nama_Kapal, Tanggal, A.Produk + ' - ' + MP.NamaProduk AS Produk, Density, Temperatur, Keterangan, userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG"] = ("SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG", @"SELECT NamaKegiatan, NamaKapal, Tanggal, A.Produk + ' - ' + MP.NamaProduk AS Produk, Density, Temperature, Pressure, Keterangan, userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE idAktifitas = @IdAktivitas;"),
                ["SubAktivitasInputDataRTW"] = ("SubAktivitasInputDataRTW", @"SELECT A.Produk, A.PICPengisian, NoMeter, NomorGerbongKertel, Quantity, HasilPengukuranT2, NomorGerbongKertel2, Quantity2, HasilPengukuranT2_2, NomorGerbongKertel3, Quantity3, HasilPengukuranT2_3, MeterAwal, MeterAkhir, TotalGK, Total AS TotalMeter, Selisih, userInput AS DibuatOleh, A.etlDate AS TanggalDibuat, A.LastUpdatedBy AS DiperbaruiOleh, A.lastUpdatedDate AS TanggalDiperbarui FROM {0} A LEFT JOIN MasterProduk MP ON A.Produk = MP.NoProduk WHERE idAktifitas = @IdAktivitas;"),
            };
            if (string.IsNullOrWhiteSpace(payload.TableName) || !map.TryGetValue(payload.TableName, out var def))
                return BadRequest(new { success = false, message = "Tabel tidak valid." });
            var sql = string.Format(def.Sql, def.Table);
            var dt = new DataTable();
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@IdAktivitas", SqlDbType.Int).Value = payload.IdAktivitas;
                using (var reader = cmd.ExecuteReader())
                    dt.Load(reader);
            }
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Export");
                int row = 1;
                int col = 1;

                // general data
                if (payload.GeneralData != null && payload.GeneralData.Count > 0)
                {
                    // header
                    foreach (var kv in payload.GeneralData)
                    {
                        var cell = ws.Cell(row, col++);
                        cell.Value = kv.Key;
                        cell.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightGreen;
                        cell.Style.Font.Bold = true;
                    }

                    // value
                    row++;
                    col = 1;
                    foreach (var kv in payload.GeneralData)
                    {
                        var v = kv.Value;
                        ws.Cell(row, col++).SetValue(v?.ToString() ?? string.Empty);
                    }
                    var gRange = ws.Range(1, 1, row, payload.GeneralData.Count);
                    gRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                    gRange.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                    row += 2;
                }

                // data aktivitas tabel
                if (dt.Rows.Count > 0)
                {
                    var tableCell = ws.Cell(row, 1);
                    var xlTable = tableCell.InsertTable(dt, "SpecificData", true);
                    xlTable.Theme = ClosedXML.Excel.XLTableTheme.None;
                    xlTable.ShowAutoFilter = true;
                    var headerRange = xlTable.HeadersRow().AsRange();
                    headerRange.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightBlue;
                    headerRange.Style.Font.Bold = true;
                    var used = ws.RangeUsed();
                    used.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                    used.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                }
                ws.Columns().AdjustToContents();
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"{payload.TableName}_{payload.NoReferensi}.xlsx"
                    );
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetTipePenyaluran")]
    public IActionResult GetTipePenyaluran(string? NoReferensi)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        if (string.IsNullOrWhiteSpace(NoReferensi))
            return Ok(new { success = false, message = "NoReferensi is required." });
        try
        {
            using var sqlConnection = GetConnection("Db").OpenConnection();
            string TipePenyaluran = "";
            string KategoriPenyaluran = "";
            int? IdModa = null;
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 TipePenyaluran, KategoriPenyaluran, IdModa
                FROM Penyaluran
                WHERE NomorPenyaluran = @NoReferensi", sqlConnection))
            {
                cmd.Parameters.Add("@NoReferensi", System.Data.SqlDbType.VarChar).Value = NoReferensi;
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        TipePenyaluran = reader["TipePenyaluran"]?.ToString() ?? "";
                        KategoriPenyaluran = reader["KategoriPenyaluran"]?.ToString() ?? "";
                        if (reader["IdModa"] != DBNull.Value)
                            IdModa = Convert.ToInt32(reader["IdModa"]);
                    }
                    else
                    {
                        return Ok(new { success = false, message = "Nomor penyaluran tidak ditemukan." });
                    }
                }
            }
            return Ok(new
            {
                success = true,
                TipePenyaluran,
                KategoriPenyaluran,
                IdModa // <— dikembalikan ke client
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    // [HttpGet("GetTipePenyaluran")]
    // public IActionResult GetTipePenyaluran(string? NoReferensi)
    // {
    //     if (!IsLoggedIn())
    //         return Json(new { success = false, message = "Not authorized." });

    //     try
    //     {
    //         string TipePenyaluran;
    //         using (var cmd = new SqlCommand("SELECT TOP 1 TipePenyaluran FROM Penyaluran WHERE NomorPenyaluran = @NoReferensi", sqlConnection))
    //         {
    //             cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi);
    //             TipePenyaluran = cmd.ExecuteScalar()?.ToString() ?? "";
    //         }

    //         return Ok(new { success = true, TipePenyaluran = TipePenyaluran });
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine(ex);
    //         return StatusCode(500, "An error occurred on the server.");
    //     }
    // }
    [HttpGet("GetAktivitasDokumenDetail")]
    public IActionResult GetAktivitasDokumenDetail(string? IdAktivitasDokumen)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        try
        {
            List<Dictionary<string, object>> dokumenList = new List<Dictionary<string, object>>();
            string sqlData = "SELECT id, FileName FROM AktivitasDokumenDetail WHERE IdAktivitasDokumen = @IdAktivitasDokumen;";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection()) {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdAktivitasDokumen", IdAktivitasDokumen ?? "");
                    using (SqlDataReader rs = sqlCommand.ExecuteReader()) {
                        while (rs.Read()) {
                            Dictionary<string, object> row = new Dictionary<string, object>();
                            for (int i = 0; i < rs.FieldCount; i++) {
                                row[rs.GetName(i)] = rs[i] != null? rs[i] : "";
                            }
                            dokumenList.Add(row);
                        }
                    }
                }
            }
            return Ok(new { 
                success = true, 
                dataDokumen = dokumenList 
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("getTimbangan_Awal")]
    public IActionResult getTimbangan_Awal(string? NoReferensi)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not Authorized." });
        try 
        {
            using var sqlConnection = GetConnection("Db").OpenConnection();
            string Timbangan_awal = "";
            string sqlQuery = @"SELECT TOP 1 TimbanganAwal 
                            FROM SubAktivitasDataMobilTangkiMTGateInLPG 
                            WHERE NoReferensi = @NoReferensi";
            using (var cmd = new SqlCommand(sqlQuery, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", NoReferensi ?? (object)DBNull.Value);
                var result = cmd.ExecuteScalar();
                Timbangan_awal = result?.ToString() ?? "";
            }
            return Ok(new { success = true, Timbangan_awal });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    [HttpGet("get-last-quantity-akhir")]
    public IActionResult GetLastQuantityAkhir(string noReferensi)
    {
        if (!IsLoggedIn())
        {
            return Json(new { success = false, message = "Not authorized." });
        }
        try
        {
            using (SqlConnection connection = GetConnection("Db").OpenConnection())
            {
                // Query untuk mengambil QuantityAkhir dari data terbaru
                string sqlQuery = $@"
                    SELECT TOP 1 QuantityAkhir
                    FROM SubAktivitasFormInputMonitoringStockSTSPymSBBM
                    WHERE NoReferensi = @NoReferensi
                    ORDER BY id DESC";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@NoReferensi", noReferensi);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var quantityAkhir = reader["QuantityAkhir"]?.ToString() ?? "";
                            return Json(new { 
                                success = true, 
                                QuantityAkhir = quantityAkhir
                            });
                        }
                        else
                        {
                            return Json(new { 
                                success = false, 
                                message = "Tidak ada data sebelumnya" 
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error GetLastQuantityAkhir: {ex.Message}");
            return Json(new { 
                success = false, 
                message = "Terjadi kesalahan pada server: " + ex.Message 
            });
        }
    }

    [HttpGet("get-produk-penimbunan-penyaluran")]
    public IActionResult GetProdukPenimbunanPenyaluran(string noReferensi)
    {
        if (!IsLoggedIn())
        {
            return Json(new { success = false, message = "Not authorized." });
        }
        try
        {
            using (SqlConnection connection = GetConnection("Db").OpenConnection())
            {
                string sqlQuery = @"
                    SELECT TOP 1 JenisProduk
                    FROM PenimbunanPenyaluran
                    WHERE NomorPenimbunanPenyaluran = @NoReferensi";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@NoReferensi", noReferensi);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var jenisProduk = reader["JenisProduk"]?.ToString() ?? "";
                            return Json(new { 
                                success = true, 
                                JenisProduk = jenisProduk
                            });
                        }
                        else
                        {
                            return Json(new { 
                                success = false, 
                                message = "Tidak ada data produk" 
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error GetProdukPenimbunanPenyaluran: {ex.Message}");
            return Json(new { 
                success = false, 
                message = "Terjadi kesalahan pada server: " + ex.Message 
            });
        }
    }

    private async Task InsertBukuTamuDetail(
        SqlConnection sqlConnection,
        string noReferensi,
        string area,
        string areaId,
        DateTime tanggal,
        string foto,
        string userInput)
        {
        string insertDetailQuery = @"
            INSERT INTO BukuTamuDetail 
            (NoReferensi, Area, AreaId, Tanggal, Foto, UserInput)
            VALUES 
            (@NoReferensi, @Area, @AreaId, @Tanggal, @Foto, @UserInput);";
        using (SqlCommand cmd = new SqlCommand(insertDetailQuery, sqlConnection))
        {
            cmd.Parameters.AddWithValue("@NoReferensi", noReferensi);
            cmd.Parameters.AddWithValue("@Area", area);
            cmd.Parameters.AddWithValue("@AreaId", !string.IsNullOrEmpty(areaId) ? areaId : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Tanggal", tanggal);
            cmd.Parameters.AddWithValue("@Foto", !string.IsNullOrEmpty(foto) ? foto : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UserInput", userInput);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    private string GetAreaName(string pintu)
    {
        return pintu switch
        {
            "PintuUtamaIn" => "Pintu Utama In",
            "PintuUtamaOut" => "Pintu Utama Out",
            "LobbyUtamaIn" => "Lobby Utama In",
            "LobbyUtamaOut" => "Lobby Utama Out",
            "AreaTerlarangIn" => "Area Terlarang In",
            "AreaTerlarangOut" => "Area Terlarang Out",
            _ => "Unknown"
        };
    }

    [HttpPost("AddBukuTamu")]
    public async Task<IActionResult> AddBukuTamu([FromForm] BukuTamuRequest payload)
    {
        try
        {
            if (!IsLoggedIn())
            {
                var response = new { success = false, message = "Not authorized." };
                return Json(response);
            }
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                DateTime etlDateValue = DateTime.Now;
                using (SqlCommand etlCmd = new SqlCommand(
                    "EXEC dbo.GetPlantDateTime @IdPlant = @Plant", sqlConnection))
                {
                    etlCmd.Parameters.AddWithValue("@Plant", payload.Plant);
                    var etlObj = etlCmd.ExecuteScalar();
                    if (etlObj != null && DateTime.TryParse(etlObj.ToString(), out var etlParsed))
                        etlDateValue = etlParsed;
                }
                string NomorBukuTamu = "";
                using (SqlCommand spCmd = new SqlCommand(
                    "EXEC dbo.GenerateNomorBukuTamu @IdPlant = @Plant, @EtlDate = @EtlDate", sqlConnection))
                {
                    spCmd.Parameters.AddWithValue("@Plant", payload.Plant);
                    spCmd.Parameters.AddWithValue("@EtlDate", etlDateValue); 
                    NomorBukuTamu = spCmd.ExecuteScalar()?.ToString() ?? "";
                }
                DateTime tanggalPintuUtamaIn = DateTime.Now;
                if (DateTime.TryParse(payload.PintuUtamaInTanggal.ToString(), out var pintuDt))
                {
                    tanggalPintuUtamaIn = pintuDt;
                }
                DateTime DateTimeNow = DateTime.Now;
                if (DateTime.TryParse(payload.Tanggal.ToString(), out var dt))
                {
                    DateTimeNow = dt;
                }
                string ttdFileName = await UploadDokumenToAzureBlob(payload.TandaTangan, "BukuTamuDocument");
                string pintuUtamaFileName = "";
                if (payload.File is { Length: > 0 })
                {
                    pintuUtamaFileName = await UploadDokumenToAzureBlob(payload.File, "BukuTamuDocument");
                }
                string insertQuery = $@"INSERT INTO BukuTamu 
                                        (NomorBukuTamu, TandaTangan, StatusZona, StatusZonaPrev,
                                        Plant, Tanggal, Nama, AsalPerusahaan, Jabatan, FungsiYgDikunjungi, 
                                        MaksudKunjungan, TandaPengenal, PintuUtamaId, PintuUtamaInTanggal, Keterangan, 
                                        PintuUtamaInFoto, PintuUtamaInUser, etlDate, LookupPlant) 
                                        VALUES (@NomorBukuTamu, @TandaTangan, @StatusZona, @StatusZonaPrev,
                                        @Plant, @Tanggal, @Nama, @AsalPerusahaan, @Jabatan, @FungsiYgDikunjungi, 
                                        @MaksudKunjungan, @TandaPengenal, @PintuUtamaId, @PintuUtamaInTanggal, @Keterangan, 
                                        @PintuUtamaInFoto, @PintuUtamaInUser, @etlDate, @LookupPlant);";
                using (SqlCommand cmd = new SqlCommand(insertQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NomorBukuTamu", NomorBukuTamu);
                    cmd.Parameters.AddWithValue("@TandaTangan", ttdFileName);
                    cmd.Parameters.AddWithValue("@StatusZona", "Pintu Utama");
                    cmd.Parameters.AddWithValue("@StatusZonaPrev", "Pintu Utama");
                    cmd.Parameters.AddWithValue("@Plant", payload.Plant); 
                    cmd.Parameters.AddWithValue("@LookupPlant", payload.Plant); 
                    cmd.Parameters.AddWithValue("@Tanggal", DateTimeNow); 
                    cmd.Parameters.AddWithValue("@Nama", payload.Nama); 
                    cmd.Parameters.AddWithValue("@AsalPerusahaan", payload.AsalPerusahaan); 
                    cmd.Parameters.AddWithValue("@Jabatan", payload.Jabatan); 
                    cmd.Parameters.AddWithValue("@FungsiYgDikunjungi", payload.FungsiYgDikunjungi); 
                    cmd.Parameters.AddWithValue("@MaksudKunjungan", payload.MaksudKunjungan); 
                    cmd.Parameters.AddWithValue("@TandaPengenal", payload.TandaPengenal); 
                    cmd.Parameters.AddWithValue("@PintuUtamaId", payload.PintuId); 
                    cmd.Parameters.AddWithValue("@PintuUtamaInTanggal", tanggalPintuUtamaIn);
                    cmd.Parameters.AddWithValue("@Keterangan", !string.IsNullOrEmpty(payload.Keterangan) ? payload.Keterangan : ""); 
                    cmd.Parameters.AddWithValue("@PintuUtamaInUser", CurrentUserName());
                    cmd.Parameters.AddWithValue("@etlDate", etlDateValue);
                    if (!string.IsNullOrEmpty(pintuUtamaFileName)) {
                        cmd.Parameters.AddWithValue("@PintuUtamaInFoto", pintuUtamaFileName);
                    } else {
                        cmd.Parameters.AddWithValue("@PintuUtamaInFoto", DBNull.Value);
                    }
                    await cmd.ExecuteNonQueryAsync();
                }
                await InsertBukuTamuDetail(
                    sqlConnection,
                    noReferensi: NomorBukuTamu,
                    area: "Pintu Utama In",
                    areaId: payload.PintuId,
                    tanggal: tanggalPintuUtamaIn,
                    foto: pintuUtamaFileName,
                    userInput: CurrentUserName()
                );
                Console.WriteLine($"[LOG] Added to BukuTamuDetail: {NomorBukuTamu} - Pintu Utama In");
                }
            return Ok(new { success = true, message = "Berhasil tambah data buku tamu." });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    private Dictionary<string, object> GetStatusZonaBukuTamu(SqlConnection sqlConnection, string pintu, string id) {
        Dictionary<string, object> response = new Dictionary<string, object>();
        if (pintu == "PintuUtamaOut") {
            response["StatusZona"] = "Keluar";
            response["StatusZonaPrev"] = "Keluar";
        }
        if (pintu == "LobbyUtamaOut") {
            response["StatusZona"] = "Pintu Utama";
            response["StatusZonaPrev"] = "Pintu Utama";
        }
        if (pintu == "AreaTerlarangOut") {
            using (SqlCommand cmd = new SqlCommand("SELECT StatusZonaPrev FROM BukuTamu WHERE id = @id", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                string status = cmd.ExecuteScalar()?.ToString() ?? "";
                response["StatusZona"] = status;
                response["StatusZonaPrev"] = status;
            }
        }
        if (pintu == "PintuUtamaIn") {
            response["StatusZona"] = "Pintu Utama";
            response["StatusZonaPrev"] = "Pintu Utama";
            response["PintuId"] = "PintuUtamaId";
        }
        if (pintu == "LobbyUtamaIn") {
            response["StatusZona"] = "Lobby Utama";
            response["StatusZonaPrev"] = "Pintu Utama";
            response["PintuId"] = "LobbyUtamaId";
        }
        if (pintu == "AreaTerlarangIn") {
            response["StatusZona"] = "Area Terlarang";
            using (SqlCommand cmd = new SqlCommand("SELECT StatusZona FROM BukuTamu WHERE id = @id", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                string status = cmd.ExecuteScalar()?.ToString() ?? "";
                response["StatusZonaPrev"] = status;
            }
            response["PintuId"] = "AreaTerlarangId";
        }
        return response;
    }

    [HttpPost("UpdateBukuTamu")]
    public async Task<IActionResult> UpdateBukuTamu([FromForm] BukuTamuRequest payload)
    {
        try
        {
            if (!IsLoggedIn())
            {
                var response = new { success = false, message = "Not authorized." };
                return Json(response);
            }
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string pintu = payload.Pintu, id = payload.Id, PintuId = payload.PintuId;
                string nomorBukuTamu = "";
                using (SqlCommand cmd = new SqlCommand("SELECT NomorBukuTamu FROM BukuTamu WHERE id = @id", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    nomorBukuTamu = cmd.ExecuteScalar()?.ToString() ?? "";
                }
                string FileName = "";
                if (payload.File is { Length: > 0 })
                {
                    FileName = await UploadDokumenToAzureBlob(payload.File, "BukuTamuDocument");
                }
                DateTime Tanggal = DateTime.Now;
                if (DateTime.TryParse(payload.Tanggal?.ToString(), out var parsedDate))
                {
                    Tanggal = parsedDate;
                }
                var status = GetStatusZonaBukuTamu(sqlConnection, pintu, id);
                string StatusZona = status["StatusZona"].ToString(), StatusZonaPrev = status["StatusZonaPrev"].ToString();
                string updateQuery = $@"Update BukuTamu SET ";
                if (!string.IsNullOrEmpty(PintuId)) {
                    updateQuery += $"{status["PintuId"].ToString()} = @PintuId,";
                }
                if (!string.IsNullOrEmpty(FileName)) {
                    updateQuery += $"{pintu}Foto = @FileName,";
                }
                updateQuery += $@"{pintu}Tanggal = @Tanggal, {pintu}User = @user, StatusZonaPrev = @StatusZonaPrev, StatusZona = @StatusZona, LastUpdatedBy = @LastUpdatedBy, LastUpdatedDate = @LastUpdatedDate WHERE id = @id;";
                using (SqlCommand cmd = new SqlCommand(updateQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@StatusZonaPrev", StatusZonaPrev);
                    cmd.Parameters.AddWithValue("@StatusZona", StatusZona);
                    cmd.Parameters.AddWithValue("@user", CurrentUserName());
                    cmd.Parameters.AddWithValue("@LastUpdatedBy", CurrentUserName());
                    cmd.Parameters.AddWithValue("@Tanggal", Tanggal);
                    cmd.Parameters.AddWithValue("@LastUpdatedDate", Tanggal);
                    cmd.Parameters.AddWithValue("@id", id);
                    if (!string.IsNullOrEmpty(PintuId)) {
                        cmd.Parameters.AddWithValue("@PintuId", PintuId);
                    }
                    if (!string.IsNullOrEmpty(FileName)) {
                        cmd.Parameters.AddWithValue("@FileName", FileName);
                    }
                    await cmd.ExecuteNonQueryAsync();
                }
                string areaName = GetAreaName(pintu);
                await InsertBukuTamuDetail(
                    sqlConnection,
                    noReferensi: nomorBukuTamu,
                    area: areaName,
                    areaId: PintuId ?? "",
                    tanggal: Tanggal,
                    foto: FileName,
                    userInput: CurrentUserName()
                );
                Console.WriteLine($"[LOG] Added to BukuTamuDetail: {nomorBukuTamu} - {areaName}");
                }
            return Ok(new { success = true, message = "Berhasil update data buku tamu." });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("DownloadBukuTamu")]
    public async Task<IActionResult> DownloadBukuTamu(string? id, string? column)
    {
        if (!IsLoggedIn())
        {
            return Json(new { success = false, message = "Not authorized." });
        }
        string sqlData = $"SELECT TOP 1 {column} FROM BukuTamu WHERE id = @id;";
        try
        {
            string FileName = "";
            string path = "BukuTamuDocument";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@id", id ?? "");
                FileName = sqlCommand.ExecuteScalar().ToString();
            }
            string connectionString = Configuration["AzureBlob:ConnectionString"];
            string containerName = Configuration["AzureBlob:ContainerName"];
            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
            {
                string blobPath = $"{path}/{FileName}";
                var blobServiceClient = new BlobServiceClient(connectionString);
                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlobClient(blobPath);
                if (!await blobClient.ExistsAsync())
                {
                    return NotFound(new { success = false, message = "File not found in Azure Blob Storage." });
                }
                var downloadInfo = await blobClient.DownloadAsync();
                string extension = Path.GetExtension(FileName).ToLowerInvariant();
                string contentType = extension switch
                {
                    ".gif" => "image/gif",
                    ".jpg" => "image/jpeg",
                    ".jpeg" => "image/jpeg",
                    ".bmp" => "image/bmp",
                    ".png" => "image/png",
                    ".doc" => "application/msword",
                    ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    ".xls" => "application/vnd.ms-excel",
                    ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    ".pdf" => "application/pdf",
                    ".zip" => "application/zip",
                    ".txt" => "text/plain",
                    _ => "application/octet-stream"
                };
                Response.Headers.Remove("Content-Disposition");
                Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{FileName}\"");
                return File(downloadInfo.Value.Content, contentType, FileName);
            }
            string curdir = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(curdir, "wwwroot", "Uploads", path);
            string filePath = Path.Combine(folderPath, FileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(new { success = false, message = "File not found on the server." });
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            string extension_local = Path.GetExtension(FileName).ToLower();
            string contentType_local = extension_local switch
            {
                ".gif"  => "image/gif",
                ".jpg"  => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".bmp"  => "image/bmp",
                ".png"  => "image/png",
                ".doc"  => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls"  => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".pdf"  => "application/pdf",
                ".zip"  => "application/zip",
                ".txt"  => "text/plain",
                _       => "application/octet-stream"
            };
            Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{FileName}\"");
            return File(fileBytes, contentType_local, $"{FileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetBukuTamuDetail")]
    public async Task<IActionResult> GetBukuTamuDetail(string? id, string? nomorBukuTamu)
    {
        Console.WriteLine($"=== GetBukuTamuDetail Called ===");
        Console.WriteLine($"id: {id}");
        Console.WriteLine($"nomorBukuTamu: {nomorBukuTamu}");
        if (!IsLoggedIn())
        {
            Console.WriteLine("Not logged in!");
            return Unauthorized(new { success = false, message = "Not authorized." });
        }
        if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(nomorBukuTamu))
        {
            Console.WriteLine("Missing parameters!");
            return BadRequest(new { success = false, message = "Key (id atau nomorBukuTamu) wajib diisi." });
        }
        try
        {
            var list = new List<object>();
            using (var conn = GetConnection("Db").OpenConnection())
            {
                string noRef = nomorBukuTamu ?? "";
                if (string.IsNullOrEmpty(noRef) && !string.IsNullOrEmpty(id))
                {
                    Console.WriteLine($"Getting NomorBukuTamu from id: {id}");
                    using var cmdNo = new SqlCommand("SELECT NomorBukuTamu FROM BukuTamu WHERE Id = @Id;", conn);
                    cmdNo.Parameters.AddWithValue("@Id", id);
                    noRef = cmdNo.ExecuteScalar()?.ToString() ?? "";
                    Console.WriteLine($"Found NomorBukuTamu: {noRef}");
                    if (string.IsNullOrEmpty(noRef))
                    {
                        Console.WriteLine("NomorBukuTamu not found!");
                        return NotFound(new { success = false, message = "NomorBukuTamu tidak ditemukan." });
                    }
                }
                Console.WriteLine($"Querying BukuTamuDetail with NoReferensi: {noRef}");
                using var cmd = new SqlCommand(@"
                    SELECT Id, NoReferensi, Area, AreaId, Tanggal, Foto, UserInput
                    FROM BukuTamuDetail
                    WHERE NoReferensi = @NoRef
                    ORDER BY Tanggal DESC;", conn);
                cmd.Parameters.AddWithValue("@NoRef", noRef);
                using var rd = await cmd.ExecuteReaderAsync();
                while (await rd.ReadAsync())
                {
                    list.Add(new {
                        Id        = (int)rd["Id"],
                        Area      = rd["Area"]?.ToString() ?? "",
                        AreaId    = rd["AreaId"]?.ToString() ?? "",
                        Tanggal   = rd["Tanggal"] != DBNull.Value 
                                    ? ((DateTime)rd["Tanggal"]).ToString("yyyy/MM/dd HH:mm:ss") 
                                    : "",
                        Foto      = rd["Foto"]?.ToString() ?? "",
                        UserInput = rd["UserInput"]?.ToString() ?? ""
                    });
                }
            }
            Console.WriteLine($"Returning {list.Count} records");
            return Ok(new { success = true, data = list });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
            return StatusCode(500, new { 
                success = false, 
                message = "Terjadi kesalahan: " + ex.Message 
            });
        }
    }

    [HttpGet("DownloadBukuTamuDetailFoto")]
    public async Task<IActionResult> DownloadBukuTamuDetailFoto(int id)
    {
        if (!IsLoggedIn())
            return Unauthorized(new { success = false, message = "Not authorized." });
        string? fileName;
        using (var conn = GetConnection("Db").OpenConnection())
        using (var cmd = new SqlCommand("SELECT Foto FROM BukuTamuDetail WHERE Id = @Id;", conn))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            fileName = cmd.ExecuteScalar()?.ToString();
        }
        if (string.IsNullOrEmpty(fileName))
            return NotFound(new { success = false, message = "File tidak ditemukan." });
        string path = "BukuTamuDocument";
        string connectionString = Configuration["AzureBlob:ConnectionString"];
        string containerName   = Configuration["AzureBlob:ContainerName"];
        if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
        {
            var svc       = new BlobServiceClient(connectionString);
            var container = svc.GetBlobContainerClient(containerName);
            var blob      = container.GetBlobClient($"{path}/{fileName}");
            if (!await blob.ExistsAsync())
                return NotFound(new { success = false, message = "File tidak ditemukan di Azure." });
            var dl = await blob.DownloadAsync();
            string contentType = GetContentType(fileName);
            Response.Headers.Remove("Content-Disposition");
            Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");
            return File(dl.Value.Content, contentType, fileName);
        }
        var localPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", path, fileName);
        if (!System.IO.File.Exists(localPath))
            return NotFound(new { success = false, message = "File tidak ditemukan di server." });
        var bytes = System.IO.File.ReadAllBytes(localPath);
        return File(bytes, GetContentType(fileName), fileName);
    }

    [HttpPost("update_dokumen_over_toleransi")]
    public IActionResult update_dokumen_over_toleransi([FromBody] UpdateDokumenMandatory data)
    {
        if (!IsLoggedIn())
        {
            var response = new
            {
                success = false,
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan."
            };
            return Json(response);
        }
        try
        {
            float R4 = 0;
            string sqlData = @"
                SELECT 
                    SAR.AR_mt AS AR,
                    SBL.BL_mt AS BL
                FROM SubAktivitasFormNilaiSFALARSTSPymLPG AS SAR
                JOIN Penimbunan AS P
                    ON SAR.NoReferensi = P.NomorPenimbunan
                JOIN Penerimaan AS PR
                    ON P.IdPenerimaan = PR.IdPenerimaan
                JOIN SubAktivitasNilaiBLSFALLPG AS SBL
                    ON SBL.NoReferensi = PR.NomorPenerimaan
                WHERE SAR.NoReferensi = @NoReferensi;
            ";
            int idDokumen = 163;
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NoReferensi", data.NoReferensi);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            float AR = reader.IsDBNull(reader.GetOrdinal("AR"))
                                ? 0f
                                : Convert.ToSingle(reader["AR"]);
                            float BL = reader.IsDBNull(reader.GetOrdinal("BL"))
                                ? 0f
                                : Convert.ToSingle(reader["BL"]);
                            if (BL != 0)
                            {
                                R4 = (AR - BL) / BL * 100;
                            }
                            else
                            {
                                return Ok(new
                                {
                                    success = false,
                                    message = "Can't calculate R4 value, because BL value is null or 0"
                                });
                            }
                        }
                    }
                }
                UpdateDokumenWajibUpload(sqlConnection, data.NoReferensi, R4 < -0.125, idDokumen);
            }
            return Ok(new { success = true, message = "Aktivitas Dokumen Berhasil Diupdate." });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, ex);
        }
    }

    [HttpGet("GetTanggalDibuatPOV")]
    public IActionResult GetTanggalDibuatPOV(string? noReferensi)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        if (string.IsNullOrWhiteSpace(noReferensi))
        {
            return BadRequest(new { success = false, message = "Nomor Referensi is required." });
        }
        try
        {
            DateTime? tanggalDibuat = null;
            string sql = "SELECT TOP 1 TanggalDibuat FROM ProofOfVisit WHERE NomorProofOfVisit = @NoReferensi";
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@NoReferensi", noReferensi);
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    tanggalDibuat = Convert.ToDateTime(result);
                }
            }
            if (tanggalDibuat.HasValue)
            {
                // Return the date in UTC format for easy parsing in JavaScript
                return Ok(new { success = true, tanggalDibuat = tanggalDibuat.Value.ToUniversalTime() });
            }
            else
            {
                return NotFound(new { success = false, message = "Proof of Visit not found." });
            }
        }
        catch (Exception ex)
        {
            Log("GetTanggalDibuatPOV error: " + ex.Message);
            return StatusCode(500, new { success = false, message = "An error occurred on the server." });
        }
    }

    [HttpPost("FaceEnrollment")]
    public async Task<IActionResult> FaceEnrollment([FromForm] FaceEnrollmentRequest data)
    {
        if (data.Face == null || data.Face.Length == 0)
            return BadRequest(new { message = "File wajah wajib diunggah." });
        if (string.IsNullOrWhiteSpace(data.IdUser) || string.IsNullOrWhiteSpace(data.Username))
            return BadRequest(new { message = "IdUser dan Username wajib diisi." });
        string groupId = Configuration["Face:LargePersonGroupId"];
        var endpoint = new Uri(Configuration["Face:Endpoint"]);
        var key = new AzureKeyCredential(Configuration["Face:Key"]);
        FaceAdministrationClient adminClient = new FaceAdministrationClient(endpoint, key);
        var group = adminClient.GetLargePersonGroupClient(groupId);
        try { group.GetLargePersonGroup(); }
        catch { group.Create(groupId, recognitionModel: FaceRecognitionModel.Recognition04); }
        var createPerson = group.CreatePerson(data.Username);
        var personId = createPerson.Value.PersonId;
        using var ms = new MemoryStream();
        await data.Face.CopyToAsync(ms); ms.Position = 0;
        await group.AddFaceAsync(
            personId,
            BinaryData.FromStream(ms)
        );
        var op = await group.TrainAsync(Azure.WaitUntil.Completed);
        await op.WaitForCompletionResponseAsync();
        string uniqueFileName = await UploadDokumenToAzureBlob(data.Face, "FaceEnrollment");
        DateTime DateTimeNow = DateTime.Now;
        if (DateTime.TryParse(data.Tanggal.ToString(), out var dt))
        {
            DateTimeNow = dt;
        }
        using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
        {
            string sqlData = "UPDATE MasterUser SET AzurePersonId = @AzurePersonId, Face = @FileName, TanggalInputFace = @Tanggal, UserInputFace = @User WHERE IdUser = @IdUser";
            using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@AzurePersonId", personId.ToString());
                sqlCommand.Parameters.AddWithValue("@FileName", uniqueFileName);
                sqlCommand.Parameters.AddWithValue("@IdUser", data.IdUser);
                sqlCommand.Parameters.AddWithValue("@Tanggal", DateTimeNow);
                sqlCommand.Parameters.AddWithValue("@User", CurrentUserName());
                int rows = await sqlCommand.ExecuteNonQueryAsync();
                if (rows == 0)
                    return NotFound(new { message = "User tidak ditemukan di tabel MasterUser." });
            }
        }
        return Ok( new { 
            success = true,
            message = $"Enroll wajah berhasil untuk {data.Username}.", 
            personId = personId 
        });
    }

    [HttpPost("TestFace")]
    public async Task<IActionResult> TestFace([FromForm] FaceEnrollmentRequest data)
    {
        if (data.Face == null || data.Face.Length == 0)
            return BadRequest(new { message = "File wajah wajib diunggah." });
        string personUserName = "", personName = "";
        string groupId = Configuration["Face:LargePersonGroupId"];
        var endpoint = new Uri(Configuration["Face:Endpoint"]);
        var key = new AzureKeyCredential(Configuration["Face:Key"]);
        FaceAdministrationClient adminClient = new FaceAdministrationClient(endpoint, key);
        FaceClient FaceClient = new FaceClient(endpoint, key);
        using var ms = new MemoryStream();
        await data.Face.CopyToAsync(ms); ms.Position = 0;
        var detected = FaceClient.Detect(
            imageContent: BinaryData.FromStream(ms),
            detectionModel: FaceDetectionModel.Detection03,
            recognitionModel: FaceRecognitionModel.Recognition04,
            returnFaceId: true
        );
        var faceIds = detected.Value
            .Select(d => d.FaceId)
            .Where(id => id != null)
            .ToList();
        if (faceIds.Count == 0)
            return Json(new { message = "Tidak ada wajah terdeteksi." });
        var payload = new
        {
            faceIds = faceIds,
            largePersonGroupId = groupId,
            maxNumOfCandidatesReturned = 1
        };
        using var rc = RequestContent.Create(payload);
        var identifyResp = FaceClient.IdentifyFromLargePersonGroup(rc);
        using var doc = JsonDocument.Parse(identifyResp.ContentStream);
        var first = doc.RootElement.EnumerateArray().FirstOrDefault();
        var cand = first.TryGetProperty("candidates", out var candsEl)
            ? candsEl.EnumerateArray().FirstOrDefault()
            : default;
        if (cand.ValueKind == JsonValueKind.Undefined || !cand.TryGetProperty("personId", out var pidEl))
            return Json(new { message = "Tidak ada kandidat yang cocok." });
        var personId = pidEl.GetGuid();
        var confidence = Math.Round(cand.GetProperty("confidence").GetDouble(), 4);
        var group = adminClient.GetLargePersonGroupClient(groupId);
        var personInfo = group.GetPerson(personId);
        personName = personInfo.Value.Name.ToString();
        return Json( new
        {
            success = true,
            message = $"Dikenali sebagai: {personName}, dengan tingkat kecocokan {confidence * 100}%",
            recognizedAs = personName,
            confidence = confidence
        });
    }

    [HttpGet("CheckFaceEnrollment")]
    public async Task<IActionResult> CheckFaceEnrollment(int idUser)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        if (idUser <= 0)
        {
            return BadRequest(new { success = false, message = "ID User tidak valid." });
        }
        bool isEnrolled = false;
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            {
                string sql = "SELECT AzurePersonId FROM MasterUser WHERE IdUser = @IdUser";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUser", idUser);
                    var result = await cmd.ExecuteScalarAsync();
                    isEnrolled = (result != null && result != DBNull.Value);
                }
            }
            return Ok(new { success = true, isEnrolled = isEnrolled });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error CheckFaceEnrollment: {ex.Message}");
            return StatusCode(500, new { success = false, message = "Terjadi kesalahan pada server saat memeriksa status enrollment wajah." });
        }
    }

    [HttpPost("DeleteFaceEnrollment")]
    public async Task<IActionResult> DeleteFaceEnrollment([FromForm] FaceEnrollmentDelete data)
    {
        if (string.IsNullOrWhiteSpace(data.IdUser) || string.IsNullOrWhiteSpace(data.AzurePersonId))
            return BadRequest(new { success = false, message = "IdUser dan AzurePersonId wajib diisi." });
        try
        {
            string groupId = Configuration["Face:LargePersonGroupId"];
            var endpoint = new Uri(Configuration["Face:Endpoint"]);
            var key = new AzureKeyCredential(Configuration["Face:Key"]);
            FaceAdministrationClient adminClient = new FaceAdministrationClient(endpoint, key);
            var group = adminClient.GetLargePersonGroupClient(groupId);

            // Hapus person dari Azure Face API
            var deleteOperation = await group.DeletePersonAsync(Guid.Parse(data.AzurePersonId));

            // Update database - set AzurePersonId dan Face ke NULL
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string sqlData = @"UPDATE MasterUser 
                            SET AzurePersonId = NULL, 
                                Face = NULL, 
                                TanggalInputFace = NULL,
                                UserInputFace = @User 
                            WHERE IdUser = @IdUser AND AzurePersonId = @AzurePersonId";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdUser", data.IdUser);
                    sqlCommand.Parameters.AddWithValue("@AzurePersonId", data.AzurePersonId);
                    sqlCommand.Parameters.AddWithValue("@User", CurrentUserName());
                    int rows = await sqlCommand.ExecuteNonQueryAsync();
                    if (rows == 0)
                        return NotFound(new { success = false, message = "Data tidak ditemukan atau AzurePersonId tidak sesuai." });
                }
            }
            return Ok(new
            {
                success = true,
                message = $"Data wajah berhasil dihapus untuk user {data.IdUser}."
            });
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            // Jika person sudah tidak ada di Azure, tetap hapus dari database
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string sqlData = @"UPDATE MasterUser 
                            SET AzurePersonId = NULL, 
                                Face = NULL, 
                                TanggalInputFace = NULL,
                                UserInputFace = @User 
                            WHERE IdUser = @IdUser AND AzurePersonId = @AzurePersonId";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdUser", data.IdUser);
                    sqlCommand.Parameters.AddWithValue("@AzurePersonId", data.AzurePersonId);
                    sqlCommand.Parameters.AddWithValue("@User", CurrentUserName());
                    int rows = await sqlCommand.ExecuteNonQueryAsync();
                    if (rows > 0)
                    {
                        return Ok(new
                        {
                            success = true,
                            message = $"Data wajah berhasil dihapus (data Azure sudah tidak ada)."
                        });
                    }
                }
            }
            return NotFound(new { success = false, message = "Data tidak ditemukan." });
        }
        catch (FormatException)
        {
            return BadRequest(new { success = false, message = "Format AzurePersonId tidak valid." });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting face enrollment: {ex}");
            return StatusCode(500, new { success = false, message = "Terjadi kesalahan pada server saat menghapus data wajah." });
        }
    }

    [HttpPost("DeleteAllFaceEnrollments")]
    public async Task<IActionResult> DeleteAllFaceEnrollments()
    {
        if (!IsLoggedIn())
        {
            return Json(new { success = false, message = "Not authorized." });
        }
        try
        {
            var endpoint = new Uri(Configuration["Face:Endpoint"]);
            var key = new AzureKeyCredential(Configuration["Face:Key"]);
            string groupId = Configuration["Face:LargePersonGroupId"];
            FaceAdministrationClient adminClient = new FaceAdministrationClient(endpoint, key);

            // Hapus seluruh group (otomatis hapus semua person & faces di dalamnya)
            var group = adminClient.GetLargePersonGroupClient(groupId);
            await group.DeleteAsync();

            // Buat group baru kosong
            await group.CreateAsync("Karyawan-Local", recognitionModel: FaceRecognitionModel.Recognition04);

            // Update database - set semua AzurePersonId ke NULL
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string sqlData = @"UPDATE MasterUser 
                            SET AzurePersonId = NULL, 
                                Face = NULL, 
                                TanggalInputFace = NULL,
                                UserInputFace = @User";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@User", CurrentUserName());
                    int rows = await sqlCommand.ExecuteNonQueryAsync();
                    return Ok(new
                    {
                        success = true,
                        message = $"Berhasil menghapus semua data wajah. {rows} user terupdate di database."
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting all face enrollments: {ex}");
            return StatusCode(500, new { success = false, message = "Terjadi kesalahan saat menghapus semua data wajah." });
        }
    }

    private class PlantDashboardData
    {
        public string RegionName { get; set; }

        public string PlantCode { get; set; }

        public Dictionary<string, int> Stats { get; set; } = new Dictionary<string, int>();
    }

    [HttpGet("ExportDashboard")]
    public IActionResult ExportDashboard(

        [FromQuery] string startDate, 
        [FromQuery] string endDate, 
        [FromQuery] string region, 
        [FromQuery] string plant)
    {
        // if (!IsLoggedIn())
        // {
        //     return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        // }
        var userLevel = CurrentUserLevel();
        var userIdPosition = CurrentUserInfo("IdPosition");
        var plantId = "";
        var whereFilter = "";
        var whereFilterPlant = "";
        var whereFilterPoV = "";
        var whereFilterPlantGHK = "";
        var whereFilterPlantMWT = "";
        List<string> plantFilters = new();
        Console.WriteLine($"Cek user export: UserLevel={userLevel}, PositionID={userIdPosition}");
        var startDateParam = string.IsNullOrEmpty(startDate) ? DateTime.Now.ToString("yyyy-MM-dd") : startDate;
        var endDateParam = string.IsNullOrEmpty(endDate) ? DateTime.Now.ToString("yyyy-MM-dd") : endDate;
        var regionIdParam = region;
        var plantIdParam = plant;
        var filterBetweenDate = $"WHERE CAST(p.TanggalDibuat AS date) BETWEEN '{startDateParam}' AND '{endDateParam}'";
        var filterBetweenDateBukuTamu = $"WHERE CAST(p.Tanggal AS date) BETWEEN '{startDateParam}' AND '{endDateParam}'";
        var filterBetweenDatePov = $"WHERE CAST(f.Tanggal AS date) BETWEEN '{startDateParam}' AND '{endDateParam}'";
        var filterBetweenDateGHK = $"WHERE CAST(GHK.TanggalDibuat AS date) BETWEEN '{startDateParam}' AND '{endDateParam}'";
        if (userLevel != "-1" && userLevel != "3" && userLevel != "4")
        {
            plantId = CurrentUserInfo("Plant")?.ToString();
        }
        using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
        {
            if (userLevel == "4")
            {
                if (!string.IsNullOrEmpty(plantIdParam) && plantIdParam != "All")
                {
                    plantFilters.Add(plantIdParam);
                }
                else if (!string.IsNullOrEmpty(regionIdParam) && regionIdParam != "All")
                {
                    var cmd = new SqlCommand("SELECT IdPlant FROM MasterPlant WHERE Region = @Region", sqlConnection);
                    cmd.Parameters.AddWithValue("@Region", regionIdParam);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = reader["IdPlant"].ToString();
                            if (!string.IsNullOrEmpty(p)) plantFilters.Add(p);
                        }
                    }
                }
                else
                {
                    var cmd = new SqlCommand("SELECT IdPlant FROM MasterPlant WHERE Region IN (SELECT IdRegion FROM MappingPosition WHERE IdPosition = @userIdPosition)", sqlConnection);
                    cmd.Parameters.AddWithValue("@userIdPosition", userIdPosition);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = reader["IdPlant"].ToString();
                            if (!string.IsNullOrEmpty(p)) plantFilters.Add(p);
                        }
                    }
                }
            }
            else if (userLevel == "-1" || userLevel == "3")
            {
                if (!string.IsNullOrEmpty(plantIdParam) && plantIdParam != "All")
                {
                    plantFilters.Add(plantIdParam);
                }
                else if (!string.IsNullOrEmpty(regionIdParam) && regionIdParam != "All")
                {
                    var cmd = new SqlCommand("SELECT IdPlant FROM MasterPlant WHERE Region = @Region", sqlConnection);
                    cmd.Parameters.AddWithValue("@Region", regionIdParam);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = reader["IdPlant"].ToString();
                            if (!string.IsNullOrEmpty(p)) plantFilters.Add(p);
                        }
                    }
                }
                else
                {
                    var cmd = new SqlCommand("SELECT IdPlant FROM MasterPlant", sqlConnection);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = reader["IdPlant"].ToString();
                            if (!string.IsNullOrEmpty(p)) plantFilters.Add(p);
                        }
                    }
                }
            }
            else 
            {
                if (userIdPosition == null) userIdPosition = "0";
                if (!string.IsNullOrEmpty(plantIdParam) && plantIdParam != "All")
                {
                    plantFilters.Add(plantIdParam);
                }
                else
                {
                    var cmd = new SqlCommand("SELECT DISTINCT IdPlant FROM MappingPosition WHERE IdPosition = @userIdPosition", sqlConnection);
                    cmd.Parameters.AddWithValue("@userIdPosition", userIdPosition);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = reader["IdPlant"].ToString();
                            if (!string.IsNullOrEmpty(p)) plantFilters.Add(p);
                        }
                    }
                }
            }
            if (plantFilters.Count > 0)
            {
                var safePlantFilters = plantFilters.Select(p => $"'{EncodeForXSS(p)}'").ToList(); 
                var filterParts = safePlantFilters.Select(p => $"p.IdPlant = {p}");
                whereFilter = "AND (" + string.Join(" OR ", filterParts) + ")";
                var filterPartsPlant = safePlantFilters.Select(p => $"p.Plant = {p}");
                whereFilterPlant = "AND (" + string.Join(" OR ", filterPartsPlant) + ")";
                var filterPartsGhk = safePlantFilters.Select(p => $"GHK.Plant = {p}");
                whereFilterPlantGHK = "AND (" + string.Join(" OR ", filterPartsGhk) + ")";
                var povParts = safePlantFilters.Select(p => $"p.LookupPlant = {p}");
                whereFilterPoV = " AND (" + string.Join(" OR ", povParts) + ")";
                whereFilterPlantMWT = whereFilter.Replace("p.IdPlant", "MWT.IdPlant");
            }
            else if (userLevel != "-1" && userLevel != "3")
            {
                whereFilter = " AND p.IdPlant = '0'"; // No data
                whereFilterPlant = " AND p.Plant = '0'";
                whereFilterPlantGHK = " AND GHK.Plant = '0'";
                whereFilterPoV = " AND p.LookupPlant = '0'";
                whereFilterPlantMWT = " AND MWT.IdPlant = '0'";
            }
            string query = $@"
            SELECT 
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Penerimaan' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.IdPlant,
                COUNT(*) AS Total,
                ISNULL(SUM(IIF(p.StatusProses = 'Waiting', 1, 0)), 0) AS Waiting,
                ISNULL(SUM(IIF(p.StatusProses = 'In Progress', 1, 0)), 0) AS InProgress,
                ISNULL(SUM(IIF(p.StatusProses = 'Complete', 1, 0)), 0) AS Complete
            FROM Penerimaan p 
            LEFT JOIN MasterPlant mp ON p.IdPlant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDate} {whereFilter}
            GROUP BY mr.Region, p.IdPlant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Penerimaan Penyimpanan' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.Plant AS IdPlant,
                COUNT(*) AS Total,
                ISNULL(SUM(IIF(p.StatusProses = 'Waiting', 1, 0)), 0) AS Waiting,
                ISNULL(SUM(IIF(p.StatusProses = 'In Progress', 1, 0)), 0) AS InProgress,
                ISNULL(SUM(IIF(p.StatusProses = 'Complete', 1, 0)), 0) AS Complete
            FROM Penimbunan p 
            LEFT JOIN MasterPlant mp ON p.Plant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDate} {whereFilterPlant}
            GROUP BY mr.Region, p.Plant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Penyaluran Penyimpanan' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.Plant AS IdPlant,
                COUNT(*) AS Total,
                ISNULL(SUM(IIF(p.StatusProses = 'Waiting', 1, 0)), 0) AS Waiting,
                ISNULL(SUM(IIF(p.StatusProses = 'In Progress', 1, 0)), 0) AS InProgress,
                ISNULL(SUM(IIF(p.StatusProses = 'Complete', 1, 0)), 0) AS Complete
            FROM PenimbunanPenyaluran p 
            LEFT JOIN MasterPlant mp ON p.Plant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDate} {whereFilterPlant}
            GROUP BY mr.Region, p.Plant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Closing Stock Penyimpanan' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.Plant AS IdPlant,
                COUNT(*) AS Total,
                ISNULL(SUM(IIF(p.StatusProses = 'Waiting', 1, 0)), 0) AS Waiting,
                ISNULL(SUM(IIF(p.StatusProses = 'In Progress', 1, 0)), 0) AS InProgress,
                ISNULL(SUM(IIF(p.StatusProses = 'Complete', 1, 0)), 0) AS Complete
            FROM ClosingStock p 
            LEFT JOIN MasterPlant mp ON p.Plant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDate} {whereFilterPlant}
            GROUP BY mr.Region, p.Plant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Rencana & Realisasi Penyaluran' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.IdPlant,
                COUNT(*) AS Total,
                ISNULL(SUM(IIF(p.StatusProses = 'Waiting', 1, 0)), 0) AS Waiting,
                ISNULL(SUM(IIF(p.StatusProses = 'In Progress', 1, 0)), 0) AS InProgress,
                ISNULL(SUM(IIF(p.StatusProses = 'Complete', 1, 0)), 0) AS Complete
            FROM RencanaPenyaluran p 
            LEFT JOIN MasterPlant mp ON p.IdPlant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDate} {whereFilter}
            GROUP BY mr.Region, p.IdPlant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Proses Penyaluran' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.IdPlant,
                COUNT(*) AS Total,
                ISNULL(SUM(IIF(p.StatusProses = 'Waiting', 1, 0)), 0) AS Waiting,
                ISNULL(SUM(IIF(p.StatusProses = 'In Progress', 1, 0)), 0) AS InProgress,
                ISNULL(SUM(IIF(p.StatusProses = 'Complete', 1, 0)), 0) AS Complete
            FROM Penyaluran p 
            LEFT JOIN MasterPlant mp ON p.IdPlant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDate} {whereFilter}
            GROUP BY mr.Region, p.IdPlant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Sampling Lab Test Penyaluran' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.IdPlant,
                COUNT(*) AS Total,
                ISNULL(SUM(IIF(p.StatusProses = 'Waiting', 1, 0)), 0) AS Waiting,
                ISNULL(SUM(IIF(p.StatusProses = 'In Progress', 1, 0)), 0) AS InProgress,
                ISNULL(SUM(IIF(p.StatusProses = 'Complete', 1, 0)), 0) AS Complete
            FROM SamplingLabTest p 
            LEFT JOIN MasterPlant mp ON p.IdPlant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDate} {whereFilter}
            GROUP BY mr.Region, p.IdPlant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Proof of Visit' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.LookupPlant AS IdPlant,
                COUNT(*) AS Total,
                COUNT(*) AS Waiting, -- This maps to 'Total Data'
                ISNULL(SUM(CASE WHEN UPPER(LTRIM(RTRIM(ISNULL(f.Ketidaksesuaiaan,'')))) = 'TIDAK' THEN 1 ELSE 0 END),0) AS InProgress, -- This maps to 'Sesuai'
                ISNULL(SUM(CASE WHEN UPPER(LTRIM(RTRIM(ISNULL(f.Ketidaksesuaiaan,'')))) = 'YA' THEN 1 ELSE 0 END),0) AS Complete -- This maps to 'Tidak Sesuai'
            FROM FormInputProofOfVisit f
            LEFT JOIN ProofOfVisit p ON p.NomorProofOfVisit = f.NoReferensi
            LEFT JOIN MasterPlant mp ON mp.IdPlant = p.LookupPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDatePov} 
            {whereFilterPoV}
            GROUP BY mr.Region, p.LookupPlant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Buku Tamu' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, p.Plant AS IdPlant,
                COUNT(distinct(pd.NoReferensi)) AS Total,
                ISNULL(SUM(IIF(pd.Area = 'Pintu Utama In', 1, 0)), 0) AS Pintu_Utama,
                ISNULL(SUM(IIF(pd.Area = 'Lobby Utama In', 1, 0)), 0) AS Lobby_Utama,
                ISNULL(SUM(IIF(pd.Area = 'Area Terlarang In', 1, 0)), 0) AS Area_Terlarang
            FROM BukuTamu p 
            INNER JOIN BukuTamuDetail pd on pd.NoReferensi = p.NomorBukuTamu
            LEFT JOIN MasterPlant mp ON p.Plant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDateBukuTamu} 
            {whereFilterPlant}
            GROUP BY mr.Region, p.Plant, mp.Plant, mp.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(MR.Region, 'No Region') AS RegionName,
                'MWT Online' AS CardName, MP.Plant AS PlantCode, MP.Nama_Terminal AS PlantName, MWT.IdPlant AS IdPlant,
                COUNT(*)                                          AS Total,
                ISNULL(SUM(IIF(MWT.Status = 'On Progress', 1, 0)), 0) AS Waiting,
                ISNULL(SUM(IIF(MWT.Status = 'Back Log', 1, 0)), 0)    AS InProgress,
                ISNULL(SUM(IIF(MWT.Status = 'Completed', 1, 0)), 0)   AS Complete
            FROM MWTOnline MWT 
            LEFT JOIN MasterPlant MP ON MWT.IdPlant = MP.IdPlant
            LEFT JOIN MasterRegion MR ON MP.Region = MR.IdRegion
            WHERE CAST(MWT.CreatedDate AS date) BETWEEN '{startDateParam}' AND '{endDateParam}'
            {whereFilterPlantMWT}
            GROUP BY MR.Region, MWT.IdPlant, MP.Plant, MP.Nama_Terminal
            UNION ALL
            SELECT
                ISNULL(mr.Region, 'No Region') AS RegionName, 
                'Good House Keeping' AS CardName, mp.Plant AS PlantCode, mp.Nama_Terminal AS PlantName, GHK.Plant AS IdPlant,
                COUNT(GHK.NomorGoodHouseKeeping) AS Total,
                COUNT(FGHK.NoReferensi) AS Waiting, -- Renamed from 'Input_GHK'
                0 AS InProgress, -- Added missing column
                0 AS Complete    -- Added missing column
            FROM GoodHouseKeeping GHK 
            LEFT JOIN FormInputGoodHouseKeeping FGHK ON GHK.NomorGoodHouseKeeping = FGHK.NoReferensi
            LEFT JOIN MasterPlant mp ON GHK.Plant = mp.IdPlant
            LEFT JOIN MasterRegion mr ON mp.Region = mr.IdRegion 
            {filterBetweenDateGHK}
            {whereFilterPlantGHK}
            GROUP BY mr.Region, GHK.Plant, mp.Plant, mp.Nama_Terminal
            ";
            var pivotedData = new Dictionary<string, PlantDashboardData>();
            var cmdExport = new SqlCommand(query, sqlConnection);
            using (var rd = cmdExport.ExecuteReader())
            {
                while (rd.Read())
                {
                    string plantName = rd["PlantName"]?.ToString();
                    string plantCode = rd["PlantCode"]?.ToString() ?? "Unknown";
                    string regionName = rd["RegionName"]?.ToString() ?? "No Region"; 
                    if (string.IsNullOrEmpty(plantName))
                    {
                        plantName = $"PlantID: {rd["IdPlant"]?.ToString() ?? "Unknown"}";
                    }
                    string cardName = rd["CardName"].ToString();
                    if (!pivotedData.ContainsKey(plantName))
                    {
                        pivotedData[plantName] = new PlantDashboardData { RegionName = regionName, PlantCode = plantCode };
                    }
                    if (cardName == "Proof of Visit")
                    {
                        pivotedData[plantName].Stats["Proof of Visit_Total Data"] = Convert.ToInt32(rd["Waiting"]);
                        pivotedData[plantName].Stats["Proof of Visit_Sesuai"] = Convert.ToInt32(rd["InProgress"]);
                        pivotedData[plantName].Stats["Proof of Visit_Tidak Sesuai"] = Convert.ToInt32(rd["Complete"]);
                    }
                    else if (cardName == "Buku Tamu")
                    {
                        pivotedData[plantName].Stats["Buku Tamu_Total"] = Convert.ToInt32(rd["Total"]);
                        pivotedData[plantName].Stats["Buku Tamu_Pintu Utama"] = Convert.ToInt32(rd["Waiting"]);
                        pivotedData[plantName].Stats["Buku Tamu_Lobby Utama"] = Convert.ToInt32(rd["InProgress"]);
                        pivotedData[plantName].Stats["Buku Tamu_Area Terlarang"] = Convert.ToInt32(rd["Complete"]);
                    }
                    else if (cardName == "Good House Keeping")
                    {
                        pivotedData[plantName].Stats["Good House Keeping_Total"] = Convert.ToInt32(rd["Total"]);
                        pivotedData[plantName].Stats["Good House Keeping_Input GHK"] = Convert.ToInt32(rd["Waiting"]);
                    }
                    else if (cardName == "MWT Online")
                    {
                        pivotedData[plantName].Stats["MWT Online_Total"] = Convert.ToInt32(rd["Total"]);
                        pivotedData[plantName].Stats["MWT Online_On Progress"] = Convert.ToInt32(rd["Waiting"]);
                        pivotedData[plantName].Stats["MWT Online_Back Log"] = Convert.ToInt32(rd["InProgress"]);
                        pivotedData[plantName].Stats["MWT Online_Completed"] = Convert.ToInt32(rd["Complete"]);
                    }
                    else 
                    {
                        pivotedData[plantName].Stats[cardName + "_Total"] = Convert.ToInt32(rd["Total"]);
                        pivotedData[plantName].Stats[cardName + "_Waiting"] = Convert.ToInt32(rd["Waiting"]);
                        pivotedData[plantName].Stats[cardName + "_In Progress"] = Convert.ToInt32(rd["InProgress"]);
                        pivotedData[plantName].Stats[cardName + "_Complete"] = Convert.ToInt32(rd["Complete"]);
                    }
                }
            }
            var cardHeaders = new List<Tuple<string, List<string>>>
            {
                Tuple.Create("Penerimaan", new List<string> { "Total", "Waiting", "In Progress", "Complete" }),
                Tuple.Create("Penerimaan Penyimpanan", new List<string> { "Total", "Waiting", "In Progress", "Complete" }),
                Tuple.Create("Penyaluran Penyimpanan", new List<string> { "Total", "Waiting", "In Progress", "Complete" }),
                Tuple.Create("Closing Stock Penyimpanan", new List<string> { "Total", "Waiting", "In Progress", "Complete" }),
                Tuple.Create("Rencana & Realisasi Penyaluran", new List<string> { "Total", "Waiting", "In Progress", "Complete" }),
                Tuple.Create("Proses Penyaluran", new List<string> { "Total", "Waiting", "In Progress", "Complete" }),
                Tuple.Create("Sampling Lab Test Penyaluran", new List<string> { "Total", "Waiting", "In Progress", "Complete" }),
                Tuple.Create("Proof of Visit", new List<string> { "Total Data", "Tidak Sesuai", "Sesuai" }),
                Tuple.Create("Buku Tamu", new List<string> { "Total", "Pintu Utama", "Lobby Utama", "Area Terlarang" }),
                Tuple.Create("MWT Online", new List<string> { "Total", "On Progress", "Back Log", "Completed" }),
                Tuple.Create("Good House Keeping", new List<string> { "Total", "Input GHK" })
            };
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Dashboard Export");
                ws.Cell("A1").Value = "Start Date";
                ws.Cell("B1").Value = startDate; 
                ws.Cell("A2").Value = "End Date";
                ws.Cell("B2").Value = endDate;   
                ws.Range("A1:A2").Style.Font.Bold = true;
                ws.Range("B1:B2").Style.DateFormat.Format = "dd/MM/yyyy";
                int headerRow = 4;
                int subHeaderRow = 5;
                int col = 1; 
                ws.Cell(headerRow, col).Value = "Region";
                ws.Range(headerRow, col, subHeaderRow, col).Merge().Style
                    .Font.SetBold(true)
                    .Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGray)
                    .Alignment.SetHorizontal(ClosedXML.Excel.XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(ClosedXML.Excel.XLAlignmentVerticalValues.Center);
                col++;
                ws.Cell(headerRow, col).Value = "Plant Code";
                ws.Range(headerRow, col, subHeaderRow, col).Merge().Style
                    .Font.SetBold(true)
                    .Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGray)
                    .Alignment.SetHorizontal(ClosedXML.Excel.XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(ClosedXML.Excel.XLAlignmentVerticalValues.Center);
                col++;
                ws.Cell(headerRow, col).Value = "Plant Name";
                ws.Range(headerRow, col, subHeaderRow, col).Merge().Style 
                    .Font.SetBold(true)
                    .Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGray)
                    .Alignment.SetHorizontal(ClosedXML.Excel.XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(ClosedXML.Excel.XLAlignmentVerticalValues.Center);
                col++; 
                foreach (var card in cardHeaders)
                {
                    string cardName = card.Item1;
                    List<string> subHeaders = card.Item2;
                    int startCol = col;
                    int endCol = col + subHeaders.Count - 1;
                    ws.Cell(headerRow, startCol).Value = cardName;
                    ws.Range(headerRow, startCol, headerRow, endCol).Merge().Style
                        .Font.SetBold(true)
                        .Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightBlue)
                        .Alignment.SetHorizontal(ClosedXML.Excel.XLAlignmentHorizontalValues.Center);
                    for (int i = 0; i < subHeaders.Count; i++)
                    {
                        ws.Cell(subHeaderRow, col + i).Value = subHeaders[i];
                    }
                    ws.Range(subHeaderRow, startCol, subHeaderRow, endCol).Style
                        .Font.SetBold(true)
                        .Fill.SetBackgroundColor(ClosedXML.Excel.XLColor.LightGray);
                    col += subHeaders.Count;
                }
                int currentRow = subHeaderRow + 1; 
                foreach (var plantEntry in pivotedData.OrderBy(p => p.Key))
                {
                    string plantName = plantEntry.Key;
                    var data = plantEntry.Value;
                    ws.Cell(currentRow, 1).Value = data.RegionName;     
                    ws.Cell(currentRow, 2).Value = data.PlantCode;    
                    ws.Cell(currentRow, 3).Value = plantName;
                    int dataCol = 4;
                    foreach (var card in cardHeaders)
                    {
                        string cardName = card.Item1;
                        foreach (var subHeader in card.Item2)
                        {
                            string key = $"{cardName}_{subHeader}";
                            if (data.Stats.TryGetValue(key, out int value)) 
                            {
                                ws.Cell(currentRow, dataCol).Value = value;
                            }
                            else
                            {
                                ws.Cell(currentRow, dataCol).Value = 0; 
                            }
                            dataCol++;
                        }
                    }
                    currentRow++;
                }
                ws.Columns().AdjustToContents();
                var usedRange = ws.Range(headerRow, 1, Math.Max(subHeaderRow, currentRow - 1), col - 1); 
                usedRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                usedRange.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    Response.Headers.Append("Access-Control-Expose-Headers", "Content-Disposition");
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"SND_Dashboard_Export.xlsx"); 
                }
            }
        }
    }

    [HttpPost("AddMWTOnline")]
    public async Task<IActionResult> AddMWTOnline([FromForm] MWTOnlineRequest payload)
    {
        try
        {
            if (!IsLoggedIn())
            {
                var response = new { success = false, message = "Not authorized." };
                return Json(response);
            }
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string NomorMWT = "", FileName = "";
                string OriginalFileName = "", FileType = "";
                using (SqlCommand spCmd = new SqlCommand("EXEC dbo.GenerateNomorMWTOnline @IdPlant = @Plant", sqlConnection))
                {
                    spCmd.Parameters.AddWithValue("@Plant", payload.Plant);
                    NomorMWT = spCmd.ExecuteScalar()?.ToString() ?? "";
                }
                DateTime DateTimeNow = DateTime.Now;
                string getTimeSql = "EXEC dbo.GetPlantDateTime @IdPlant = @Plant";
                using (SqlCommand getTimeCmd = new SqlCommand(getTimeSql, sqlConnection))
                {
                    getTimeCmd.Parameters.AddWithValue("@Plant", payload.Plant);
                    var result = getTimeCmd.ExecuteScalar();
                    if (result != null && DateTime.TryParse(result.ToString(), out var dt))
                    {
                        DateTimeNow = dt;
                    }
                }
                if (payload.File is { Length: > 0 })
                {
                    FileName = await UploadDokumenToAzureBlob(payload.File, "MWTOnlineDocument");
                    OriginalFileName = payload.File.FileName;
                    FileType = payload.File.ContentType;
                }
                string insertQuery = @"
                INSERT INTO MWTOnline 
                (NoMWTOnline, IdPlant, TaskList, [File], Status, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
                VALUES (@NoMWTOnline, @IdPlant, @TaskList, @File, @Status, @CreatedBy, @CreatedDate, @CreatedBy, @CreatedDate);
                DECLARE @NewId INT = SCOPE_IDENTITY(); 
                INSERT INTO MWTOnlineDetail
                (NoReferensi, Penjelasan, UploadEvidence, CreatedBy, CreatedDate, FileType, OriginalFileName) 
                VALUES (@NoMWTOnline, @TaskList, @File, @CreatedBy, @CreatedDate, @FileType, @OriginalFileName);
                SELECT @NewId;";
                using (SqlCommand cmd = new SqlCommand(insertQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoMWTOnline", NomorMWT);
                    cmd.Parameters.AddWithValue("@IdPlant", payload.Plant);
                    cmd.Parameters.AddWithValue("@TaskList", (object?)payload.Deskripsi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", "On Progress");
                    cmd.Parameters.AddWithValue("@CreatedBy", CurrentUserName());
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTimeNow);
                    if (!string.IsNullOrEmpty(FileName)) {
                        cmd.Parameters.AddWithValue("@File", FileName);
                        cmd.Parameters.AddWithValue("@FileType", FileType);
                        cmd.Parameters.AddWithValue("@OriginalFileName", OriginalFileName);
                    } else {
                        cmd.Parameters.AddWithValue("@File", DBNull.Value);
                        cmd.Parameters.AddWithValue("@FileType", DBNull.Value);
                        cmd.Parameters.AddWithValue("@OriginalFileName", DBNull.Value);
                    }
                    var resultId = await cmd.ExecuteScalarAsync();
                    string currentUserForEmail = CurrentUserName();
                    string baseUrl = $"{Request.Scheme}://{Request.Host}";
                    try {
                        var serviceProvider = HttpContext.RequestServices;
                        var hubContext = serviceProvider.GetService(typeof(Microsoft.AspNetCore.SignalR.IHubContext<MwtChatHub>)) as Microsoft.AspNetCore.SignalR.IHubContext<MwtChatHub>;
                        if (hubContext != null) {
                            await Microsoft.AspNetCore.SignalR.ClientProxyExtensions.SendAsync(hubContext.Clients.All, "UpdateMwtBadge", System.Threading.CancellationToken.None);
                        }
                    } catch (Exception ex) {
                        Console.WriteLine("SignalR Broadcast Error: " + ex.Message);
                    }
                    _ = Task.Run(async () => 
                    {
                        try {
                            string linkMwt = $"{baseUrl}/MwtOnlineEdit/{resultId}";
                            string currentDate = DateTime.UtcNow.AddHours(7).ToString("dd MMM yyyy, HH:mm");
                            string currentUser = currentUserForEmail;
                            string subject = "[NO-REPLY] Notifikasi MWT Online – MWT Online Baru Diterima";
                            string body = @"
                            Yth. Bapak/Ibu [Nama User],
                            Anda telah menerima MWT Online dengan detail berikut:
                            Nomor MWT: [No MWT]
                            Tanggal Penerimaan: [Tanggal]
                            Dikirim oleh: [Nama Pengirim]
                            Silakan melakukan pengecekan dan menindaklanjuti MWT tersebut melalui link berikut:

                            [Link MWT Online]
                            Catatan:
                            Email ini bersifat no-reply. Untuk memberikan respon atau informasi tambahan, silakan lakukan langsung melalui sistem S&D One menggunakan link di atas.
                            Terima kasih.
                            Hormat kami,
                            S&D One";
                            var placeholders = new Dictionary<string, string>
                            {
                                { "[No MWT]", NomorMWT },
                                { "[Tanggal]", currentDate },
                                { "[Nama Pengirim]", currentUser },
                                { "[Link MWT Online]", linkMwt }
                            };
                            await ProcessEmailQueue(payload.Plant.ToString(), subject, body, placeholders);
                        }
                        catch (Exception ex) { Console.WriteLine("Email Background Task Error: " + ex.Message); }
                    });
                    return Ok(new { success = true, message = "Berhasil menambah data MWT Online.", id = resultId });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, $"An error occurred on the server.{ex}");
        }
    }

    [HttpPost("v2/AddMWTOnline")]
    public async Task<IActionResult> AddMWTOnlineV2([FromForm] MWTOnlineRequest payload)
    {
        try
        {
            if (!IsLoggedIn()) throw new LogErrorException("Unauthorized", 401);
            string nomorMwt = string.Empty, fileName = string.Empty, originalFileName = string.Empty, fileType = string.Empty, userName = CurrentUserName();
            DateTime now = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
                "EXEC dbo.GetPlantDateTime @IdPlant = @Plant",
                reader => {
                    var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                    if (val == null) return DateTime.Now;
                    return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
                },
                new Dictionary<string, object> { { "@Plant", payload.Plant } }
            );
            var fileInfoList = new List<dynamic>();
            nomorMwt = await DatabaseQueryHelper.ExecuteSelectSingleAsync<string>(
                "EXEC dbo.GenerateNomorMWTOnline @IdPlant = @Plant",
                reader => reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                new Dictionary<string, object> {{ "@Plant", payload.Plant}});
            if (payload.Files != null && payload.Files.Count > 0)
            {
                foreach (var file in payload.Files)
                {
                    var azurFileName = await UploadDokumenToAzureBlob(file, "MWTOnlineDocument");
                    fileInfoList.Add(new 
                        { FileName = azurFileName, OriginalFileName = file.FileName, FileType = file.ContentType });
                }
            }
            if (fileInfoList.Count > 0)
            {
                fileName = fileInfoList[0].FileName;
                originalFileName = fileInfoList[0].OriginalFileName;
                fileType = fileInfoList[0].FileType;
            }
            int resultId = 0;
            resultId = await DatabaseQueryHelper.ExecuteSelectSingleAsync<int>(
                @"INSERT INTO MWTOnline (NoMWTOnline, IdPlant, TaskList, [File], Status, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
                    VALUES (@NoMWTOnline, @IdPlant, @TaskList, @File, @Status, @CreatedBy, @CreatedDate, @CreatedBy, @CreatedDate); 
                    DECLARE @NewId INT = SCOPE_IDENTITY();
                     SELECT @NewId;",
                reader => reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                new Dictionary<string, object> {
                    { "@NoMWTOnline", nomorMwt },
                    { "@IdPlant", payload.Plant },
                    { "@TaskList", (object?)payload.Deskripsi ?? DBNull.Value },
                    { "@Status", "On Progress" },
                    { "@CreatedBy", userName },
                    { "@CreatedDate", now },
                    { "@File", string.IsNullOrEmpty(fileName) ? DBNull.Value : fileName },
                    { "@FileType", string.IsNullOrEmpty(fileType) ? DBNull.Value : fileType },
                    { "@OriginalFileName", string.IsNullOrEmpty(originalFileName) ? DBNull.Value : fileType }
                });
            if (fileInfoList.Any())
            {
                var insertDetailQuery = @"
                    INSERT INTO MWTOnlineDetail
                        (NoReferensi, Penjelasan, UploadEvidence, CreatedBy, CreatedDate, FileType, OriginalFileName, Flag) 
                    VALUES 
                        (@NoMWTOnline, @TaskList, @File, @CreatedBy, @CreatedDate, @FileType, @OriginalFileName, @Flag);";
                await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(insertDetailQuery, new Dictionary<string, object> {
                    { "@NoMWTOnline", nomorMwt },
                    { "@TaskList", (object?)payload.Deskripsi ?? DBNull.Value },
                    { "@File", DBNull.Value },
                    { "@CreatedBy", userName },
                    { "@CreatedDate", now },
                    { "@FileType", DBNull.Value },
                    { "@OriginalFileName", DBNull.Value },
                    { "@Flag", "1"}
                });
                insertDetailQuery = @"
                    INSERT INTO MWTOnlineDetail
                        (NoReferensi, Penjelasan, UploadEvidence, CreatedBy, CreatedDate, FileType, OriginalFileName, Flag) 
                    VALUES 
                        (@NoMWTOnline, @TaskList, @File, @CreatedBy, @CreatedDate, @FileType, @OriginalFileName, '0');";
                for (int i = 0; i < fileInfoList.Count; i++)
                {
                    var o = fileInfoList[i];
                    await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(insertDetailQuery, new Dictionary<string, object> {
                        { "@NoMWTOnline", nomorMwt },
                        {
                            "@TaskList",
                            i == 0
                                ? (object?)payload.DeskripsiFile ?? DBNull.Value
                                : DBNull.Value
                        },
                        { "@File", string.IsNullOrEmpty(o.FileName) ? DBNull.Value : o.FileName },
                        { "@CreatedBy", userName },
                        { "@CreatedDate", now },
                        { "@FileType", string.IsNullOrEmpty(o.FileType) ? DBNull.Value : o.FileType },
                        { "@OriginalFileName", string.IsNullOrEmpty(o.OriginalFileName) ? DBNull.Value : o.OriginalFileName }
                    });
                }
            }
            else
            {
                var insertDetailQuery = @"
                    INSERT INTO MWTOnlineDetail
                        (NoReferensi, Penjelasan, UploadEvidence, CreatedBy, CreatedDate, FileType, OriginalFileName, Flag) 
                    VALUES 
                        (@NoMWTOnline, @TaskList, @File, @CreatedBy, @CreatedDate, @FileType, @OriginalFileName, @Flag);";
                await DatabaseQueryHelper.ExecuteNonSelectQueryAsync(insertDetailQuery, new Dictionary<string, object> {
                    { "@NoMWTOnline", nomorMwt },
                    { "@TaskList", (object?)payload.Deskripsi ?? DBNull.Value },
                    { "@File", string.IsNullOrEmpty(fileName) ? DBNull.Value : fileName },
                    { "@CreatedBy", CurrentUserName() },
                    { "@CreatedDate", DateTime.Now },
                    { "@FileType", string.IsNullOrEmpty(fileType) ? DBNull.Value : fileType },
                    { "@OriginalFileName", string.IsNullOrEmpty(originalFileName) ? DBNull.Value : fileType },
                    { "@Flag", "1"}
                });
            }
            string baseUrl = $"{Request.Scheme}://{Request.Host}";
            try 
            {
                var serviceProvider = HttpContext.RequestServices;
                var hubContext = serviceProvider.GetService(typeof(Microsoft.AspNetCore.SignalR.IHubContext<MwtChatHub>)) as Microsoft.AspNetCore.SignalR.IHubContext<MwtChatHub>;
                if (hubContext != null) {
                    await Microsoft.AspNetCore.SignalR.ClientProxyExtensions.SendAsync(hubContext.Clients.All, "UpdateMwtBadge", System.Threading.CancellationToken.None);
                }
            } catch (Exception ex) {
                Console.WriteLine("SignalR Broadcast Error: " + ex.Message);
            }
            _ = Task.Run(async () => 
            {
                try {
                    string linkMwt = $"{baseUrl}/MwtOnlineEdit/{resultId}";
                    string currentDate = now.ToString("dd MMM yyyy, HH:mm");
                    string currentUser = userName;
                    string subject = "[NO-REPLY] Notifikasi MWT Online – MWT Online Baru Diterima";
                    string body = @"
                            Yth. Bapak/Ibu [Nama User],
                            Anda telah menerima MWT Online dengan detail berikut:
                            Nomor MWT: [No MWT]
                            Tanggal Penerimaan: [Tanggal]
                            Dikirim oleh: [Nama Pengirim]
                            Silakan melakukan pengecekan dan menindaklanjuti MWT tersebut melalui link berikut:

                            [Link MWT Online]
                            Catatan:
                            Email ini bersifat no-reply. Untuk memberikan respon atau informasi tambahan, silakan lakukan langsung melalui sistem S&D One menggunakan link di atas.
                            Terima kasih.
                            Hormat kami,
                            S&D One";
                    var placeholders = new Dictionary<string, string>
                    {
                        { "[No MWT]", nomorMwt },
                        { "[Tanggal]", currentDate },
                        { "[Nama Pengirim]", currentUser },
                        { "[Link MWT Online]", linkMwt } 
                    };
                    await ProcessEmailQueue(payload.Plant.ToString(), subject, body, placeholders);
                }
                catch (Exception ex) { Console.WriteLine("Email Background Task Error: " + ex.Message); }
            });
            return Ok(new { success = true, message = "Berhasil menambah data MWT Online.", id = resultId });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw new LogErrorException($"An error occurred on the server.{ex}", 500);
        }
    }

    [HttpPost("uploadChatFile")]
    public async Task<IActionResult> UploadChatFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");
        string fileUrl = await UploadDokumenToAzureBlob(file, "MWTOnlineDocument");
        return Ok(new { 
            fileUrl = fileUrl, 
            fileType = file.ContentType, 
            originalName = file.FileName 
        });
    }

    [HttpGet("GetMwtOnProgressCount")]
    public IActionResult GetMwtOnProgressCount()
    {
        if (!IsLoggedIn()) return Json(new { success = false, count = 0 });
        var userLevel = CurrentUserLevel()?.ToString();
        var idPosition = CurrentUserInfo("IdPosition");
        int count = 0;
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            {
                string sql = "SELECT COUNT(*) FROM MWTOnline WHERE Status IN ('On Progress', 'Back Log')";
                if (userLevel != "-1")
                {
                    if (!string.IsNullOrEmpty(idPosition?.ToString()))
                    {
                        sql += " AND IdPlant IN (SELECT IdPlant FROM MappingPosition WHERE IdPosition = @IdPosition)";
                    }
                    else
                    {
                        return Json(new { success = true, count = 0 });
                    }
                }
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (userLevel != "-1")
                    {
                        cmd.Parameters.AddWithValue("@IdPosition", idPosition);
                    }
                    count = (int)cmd.ExecuteScalar();
                }
            }
            return Json(new { success = true, count = count });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("CompleteMWT")]
    public async Task<IActionResult> CompleteMWT([FromForm] int id)
    {
        if (!IsLoggedIn()) return Json(new { success = false, message = "Not authorized." });
        try
        {
            string idPlant = "";
            string noMwt = ""; 
            string createdBy = "";
            string status = "";
            string dateForEmail = "";
            using (var conn = GetConnection("Db").OpenConnection())
            {
                string sqlCheck = "SELECT CreatedBy, Status, IdPlant, NoMWTOnline FROM MWTOnline WHERE Id = @Id";
                using (var cmd = new SqlCommand(sqlCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            createdBy = rdr["CreatedBy"]?.ToString() ?? "";
                            status = rdr["Status"]?.ToString() ?? "";
                            idPlant = rdr["IdPlant"]?.ToString() ?? "";
                            noMwt = rdr["NoMWTOnline"]?.ToString() ?? "";
                        }
                        else
                        {
                            return Json(new { success = false, message = "Data not found." });
                        }
                    }
                }
                if (status == "Completed")
                {
                    return Json(new { success = false, message = "Task is already completed." });
                }
                if (!createdBy.Equals(CurrentUserName(), StringComparison.OrdinalIgnoreCase))
                {
                    return Json(new { success = false, message = "Only the creator can complete this task." });
                }
                DateTime plantTime = await DatabaseQueryHelper.ExecuteSelectSingleAsync<DateTime>(
                    "EXEC dbo.GetPlantDateTime @IdPlant = @idPlant",
                    reader => {
                        var val = reader.IsDBNull(0) ? null : reader.GetValue(0);
                        if (val == null) return DateTime.Now;
                        return DateTime.TryParse(val.ToString(), out var dt) ? dt : DateTime.Now;
                    },
                    new Dictionary<string, object> { { "@idPlant", Convert.ToInt32(idPlant) } }
                );
                string sqlUpdate = @"UPDATE MWTOnline 
                                     SET Status = 'Completed', 
                                         CompletedBy = @User, 
                                         CompletedDate = @plantTime,
                                         LastUpdatedBy = @User, 
                                         LastUpdatedDate = @plantTime  
                                     WHERE Id = @Id";
                using (var cmd = new SqlCommand(sqlUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@User", CurrentUserName());
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@plantTime", plantTime);
                    await cmd.ExecuteNonQueryAsync();
                }
                dateForEmail = plantTime.ToString("dd MMM yyyy, HH:mm");
            }
            string currentUserForEmail = CurrentUserName();
            string baseUrl = $"{Request.Scheme}://{Request.Host}";
            try {
                var serviceProvider = HttpContext.RequestServices;
                var hubContext = serviceProvider.GetService(typeof(Microsoft.AspNetCore.SignalR.IHubContext<MwtChatHub>)) as Microsoft.AspNetCore.SignalR.IHubContext<MwtChatHub>;
                if (hubContext != null) {
                    await Microsoft.AspNetCore.SignalR.ClientProxyExtensions.SendAsync(hubContext.Clients.All, "UpdateMwtBadge", System.Threading.CancellationToken.None);
                }
            } catch (Exception ex) {
                Console.WriteLine("SignalR Broadcast Error: " + ex.Message);
            }
            _ = Task.Run(async () => 
            {
                try {
                    string linkMwt = $"{baseUrl}/MwtOnlineEdit/{id}";
                    string completedDate = dateForEmail;
                    string currentUser = currentUserForEmail;
                    string subject = "[NO-REPLY] Notifikasi MWT Online – MWT Online Telah Selesai";
                    string body = @"
                    Yth. Bapak/Ibu [Nama User],
                    MWT Online dengan detail berikut telah diselesaikan (Completed):
                    Nomor MWT: [No MWT]
                    Tanggal Penyelesaian: [Tanggal Selesai]
                    Diselesaikan oleh: [Nama Penyelesai]
                    Anda dapat melihat status akhir dan detail tindak lanjut MWT tersebut melalui link berikut:

                    [Link MWT Online]
                    Catatan:
                    Email ini bersifat no-reply. Untuk memberikan respon atau informasi tambahan, silakan lakukan langsung melalui sistem S&D One menggunakan link di atas.
                    Terima kasih.
                    Hormat kami,
                    S&D One";
                    var placeholders = new Dictionary<string, string>
                    {
                        { "[No MWT]", noMwt },
                        { "[Tanggal Selesai]", completedDate },
                        { "[Nama Penyelesai]", currentUser },
                        { "[Link MWT Online]", linkMwt }
                    };
                    await ProcessEmailQueue(idPlant, subject, body, placeholders);
                }
                catch (Exception ex) { Console.WriteLine("Email Completed Task Error: " + ex.Message); }
            });
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("CheckAndSetBacklog")]
    public async Task<IActionResult> CheckAndSetBacklog()
    {
        if (!IsLoggedIn()) return Json(new { success = false });
        try
        {
            using (var conn = GetConnection("Db").OpenConnection())
            {
                string sql = @"
                    UPDATE MWTOnline
                    SET Status = 'Back Log',
                        LastUpdatedDate = GETDATE()
                    WHERE Status = 'On Progress'
                    AND LastUpdatedDate < DATEADD(HOUR, -24, GETDATE())";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Backlog Check Error: " + ex.Message);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("DownloadMwtZip")]
    public async Task<IActionResult> DownloadMwtZip(string noMwt)
    {
        if (!IsLoggedIn()) return Unauthorized(new { success = false, message = "Not authorized." });
        if (string.IsNullOrEmpty(noMwt)) return BadRequest(new { success = false, message = "NoMWT is required." });
        try
        {
            List<string> fileList = new List<string>();
            string sql = "SELECT UploadEvidence FROM MWTOnlineDetail WHERE NoReferensi = @NoRef AND UploadEvidence IS NOT NULL AND UploadEvidence <> ''";
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@NoRef", noMwt);
                using (var rdr = await cmd.ExecuteReaderAsync())
                {
                    while (await rdr.ReadAsync())
                    {
                        fileList.Add(rdr["UploadEvidence"].ToString());
                    }
                }
            }
            if (fileList.Count == 0) return NotFound(new { success = false, message = "No files found for this MWT." });
            using (var zipStream = new MemoryStream())
            {
                using (var archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create, true))
                {
                    string connectionString = Configuration["AzureBlob:ConnectionString"];
                    string containerName = Configuration["AzureBlob:ContainerName"];
                    string folderName = "MWTOnlineDocument"; 
                    foreach (var fileName in fileList)
                    {
                        try 
                        {
                            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
                            {
                                string blobPath = $"{folderName}/{fileName}";
                                var blobServiceClient = new BlobServiceClient(connectionString);
                                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                                var blobClient = containerClient.GetBlobClient(blobPath);
                                if (await blobClient.ExistsAsync())
                                {
                                    var downloadInfo = await blobClient.DownloadAsync();
                                    var entry = archive.CreateEntry(fileName, System.IO.Compression.CompressionLevel.Fastest);
                                    using (var entryStream = entry.Open())
                                    {
                                        await downloadInfo.Value.Content.CopyToAsync(entryStream);
                                    }
                                }
                            }
                            else
                            {
                                string localPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", folderName, fileName);
                                if (System.IO.File.Exists(localPath))
                                {
                                    var entry = archive.CreateEntry(fileName, System.IO.Compression.CompressionLevel.Fastest);
                                    using (var entryStream = entry.Open())
                                    using (var fileStream = System.IO.File.OpenRead(localPath))
                                    {
                                        await fileStream.CopyToAsync(entryStream);
                                    }
                                }
                            }
                        }
                        catch (Exception innerEx) {
                            Console.WriteLine($"Error zipping file {fileName}: {innerEx.Message}");
                        }
                    }
                }
                zipStream.Position = 0;
                string zipName = $"MWT_{noMwt}_{DateTime.Now:yyyyMMddHHmmss}.zip";
                return File(zipStream.ToArray(), "application/zip", zipName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred while generating the ZIP.");
        }
    }

    [HttpPost("uploadChatFiles")]
    public async Task<IActionResult> UploadChatFiles(List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
            return BadRequest("No files uploaded.");
        var uploadedFiles = new List<object>();
        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                string fileUrl = await UploadDokumenToAzureBlob(file, "MWTOnlineDocument");
                uploadedFiles.Add(new { 
                    fileUrl = fileUrl, 
                    fileType = file.ContentType, 
                    originalFileName = file.FileName
                });
            }
        }
        return Ok(new { 
            success = true, 
            files = uploadedFiles 
        });
    }

    [HttpGet("DownloadMwtMainFile")]
    public async Task<IActionResult> DownloadMwtMainFile(int id)
    {
        if (!IsLoggedIn()) return Unauthorized();
        string sql = "SELECT TOP 1 [File] FROM MWTOnline WHERE Id = @Id";
        string fileName = await DatabaseQueryHelper.ExecuteSelectSingleAsync<string>(
            sql, r => r.IsDBNull(0) ? "" : r.GetString(0), 
            new Dictionary<string, object> { { "@Id", id } }
        );
        if (string.IsNullOrEmpty(fileName)) return NotFound("File not found.");
        string folder = "MWTOnlineDocument";
        string connectionString = Configuration["AzureBlob:ConnectionString"];
        string containerName = Configuration["AzureBlob:ContainerName"];
        if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(containerName))
        {
            var blobService = new BlobServiceClient(connectionString);
            var container = blobService.GetBlobContainerClient(containerName);
            var blob = container.GetBlobClient($"{folder}/{fileName}");
            if (await blob.ExistsAsync())
            {
                var dl = await blob.DownloadAsync();
                return File(dl.Value.Content, "application/octet-stream", fileName);
            }
        }
        string localPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", folder, fileName);
        if (!System.IO.File.Exists(localPath)) return NotFound("File not found on server.");
        var bytes = await System.IO.File.ReadAllBytesAsync(localPath);
        return File(bytes, "application/octet-stream", fileName);
    }

    [HttpGet("get-dropdown/produk-by-plant")]
    public IActionResult GetProdukByPlant(int plantId)
    {
        if (!IsLoggedIn()) return Json(new { success = false, message = "Not authorized." });
        var list = new List<object>();
        string sql = @"
            SELECT P.NoProduk AS Value, CONCAT(P.NoProduk, ' - ', P.NamaProduk) AS Label
            FROM MasterProduk P
            JOIN MasterPlant MPL ON P.TipeProduk = MPL.TipeProduk
            WHERE MPL.IdPlant = @PlantId
            ORDER BY P.NamaProduk";
        try
        {
            using (SqlConnection conn = GetConnection("Db").OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PlantId", plantId);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new {
                            Value = r["Value"].ToString(),
                            Label = r["Label"].ToString()
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Error fetching products");
        }
        return Json(list);
    }

    [HttpGet("get-dropdown/user-position")]
    public async Task<IActionResult> GetUserPositionDropdown(int UserLevel, int? IdRule = null, int? IdRegion = null, int? IdPlant = null)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        List<DropdownResponse> positions = new List<DropdownResponse>();
        var parameters = new Dictionary<string, object>();
        string sql = "", whereRegion = "", wherePlant = "", whereRule = "";
        parameters.Add("@UserLevel", UserLevel);
        if (IdRule != null)
        {
            whereRule = " AND MP.Role = @IdRule ";
            parameters.Add("@IdRule", IdRule);
        }
        if (IdRegion != null)
        {
            whereRegion = " AND MAP.IdRegion = @IdRegion ";
            parameters.Add("@IdRegion", IdRegion);
        } 
        if (IdPlant != null)
        {
            wherePlant = " AND MAP.IdPlant = @IdPlant ";
            parameters.Add("@IdPlant", IdPlant);
        }
        sql = $@"
        SELECT DISTINCT
            MP.IdPosition AS Value,
            CAST(MP.IdPosition AS NVARCHAR(255)) + ' - ' + MP.NamaPosition AS Label
        FROM MasterPosition MP
        JOIN MappingPosition MAP ON MP.IdPosition = MAP.IdPosition
        WHERE
            (@UserLevel = -1 OR MP.UserLevel = @UserLevel)
            {whereRule}
            {whereRegion}
            {wherePlant};
        ";
        positions = DatabaseQueryHelper.ExecuteSelectListQuery<DropdownResponse>(
            sql,
            reader => new DropdownResponse
            {
                Value = reader["Value"] != DBNull.Value ? Convert.ToInt32(reader["Value"]) : 0,
                Label = reader["Label"]?.ToString() ?? ""
            }, 
            parameters
        );
        return Json(positions);
    }

    [HttpGet("get-dropdown/pjs-position")]
    public async Task<IActionResult> GetPjsPositionDropdown(string OrganizationLevel, int? IdRegion = null, int? IdPlant = null)
    {
        if (!IsLoggedIn())
        {
            return ErrorResponseDto("Unauthorized", StatusCodes.Status401Unauthorized);
        }
        List<DropdownResponse> positions = new List<DropdownResponse>();
        var parameters = new Dictionary<string, object>();
        string sql = "";
        switch (OrganizationLevel.ToUpper())
        {
            case "REGION":
                sql = @"SELECT DISTINCT 
                            mt.IdPosition AS Value,
                            CONCAT(mt.IdPosition, ' - ', mt.NamaPosition) AS Label
                        FROM MasterPosition mt
                        INNER JOIN MappingPosition mp ON mt.IdPosition = mp.IdPosition
                        WHERE mp.IdRegion = @IdRegion
                            AND mt.Role = 14;
                    ";
                parameters.Add("@IdRegion", IdRegion);
                break;
            case "PLANT":
                sql = @"SELECT DISTINCT 
                            mt.IdPosition AS Value,
                            CONCAT(mt.IdPosition, ' - ', mt.NamaPosition) AS Label
                        FROM MasterPosition mt
                        INNER JOIN MappingPosition mp ON mt.IdPosition = mp.IdPosition
                        WHERE mp.IdRegion = @IdRegion
                            AND mp.IdPlant = @IdPlant
                            AND mt.Role NOT IN (14, 15);
                    ";
                parameters.Add("@IdRegion", IdRegion);
                parameters.Add("@IdPlant", IdPlant);
                break;
            case "PUSAT":
                sql = @"SELECT DISTINCT 
                            mt.IdPosition AS Value,
                            CONCAT(mt.IdPosition, ' - ', mt.NamaPosition) AS Label
                        FROM MasterPosition mt
                        INNER JOIN MappingPosition mp ON mt.IdPosition = mp.IdPosition
                        WHERE mt.Role = @Role
                    ";
                parameters.Add("@Role", 15);
                break;
            default:
                return ErrorResponseDto("Tanggal tidak valid.", StatusCodes.Status400BadRequest);
        }
        positions = DatabaseQueryHelper.ExecuteSelectListQuery<DropdownResponse>(
            sql,
            reader => new DropdownResponse
            {
                Value = reader["Value"] != DBNull.Value ? Convert.ToInt32(reader["Value"]) : 0,
                Label = reader["Label"]?.ToString() ?? ""
            }, 
            parameters
        );
        return Json(positions);
    }

    [HttpPost("AddNewPjs")]
    public async Task<IActionResult> AddNewPjs([FromForm] AddNewPjsDto payload)
    {
        try
        {
            if (!IsLoggedIn())
            {
                var response = new { success = false, message = "Not authorized." };
                return Json(response);
            }
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string NoPjs = "", sqlQuery = "", prefix = "", suffix = "";
                string organizationLevel = payload.OrganizationLevel?.ToUpper() ?? "";
                sqlQuery = "SELECT exception FROM MasterUser WHERE IdUser = @id;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", CurrentUserInfo("IdUser"));
                    using (SqlDataReader rd = sqlCommand.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            bool isException = rd["exception"] != DBNull.Value ? Convert.ToBoolean(rd["exception"]) : false;
                            if (isException)
                            {
                                return Json(new { success = false, message = "Your account is currently under exception and cannot make PJS requests." });
                            }
                        }
                    }
                }
                DateTime DateTimeNow = DateTime.Now;
                sqlQuery = $@"
                    DECLARE @IdPlant INT;
                    SELECT TOP 1 @IdPlant = IdPlant
                    FROM MappingPosition
                    WHERE IdPosition = @IdPosition;
                    EXEC dbo.GetPlantDateTime @IdPlant = @IdPlant;
                ";
                using (SqlCommand spCmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    spCmd.Parameters.Add("@IdPosition", SqlDbType.Int).Value = payload.PosisiPJS;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        DateTimeNow = (DateTime)spResult;
                    }
                }
                switch (organizationLevel)
                {
                    case "REGION":
                        using (SqlCommand spCmd = new SqlCommand("EXEC dbo.GenerateNomorPjs @OrganizationLevel = @Level, @RegionId = @IdRegion", sqlConnection))
                        {
                            spCmd.Parameters.AddWithValue("@Level", organizationLevel);
                            spCmd.Parameters.AddWithValue("@IdRegion", payload.IdRegion);
                            NoPjs = spCmd.ExecuteScalar()?.ToString() ?? "";
                        }
                        prefix = ", Region";
                        suffix = ", @IdRegion";
                        break;
                    case "PLANT":
                        using (SqlCommand spCmd = new SqlCommand("EXEC dbo.GenerateNomorPjs @OrganizationLevel = @Level, @IdPlant = @IdPlant", sqlConnection))
                        {
                            spCmd.Parameters.AddWithValue("@Level", organizationLevel);
                            spCmd.Parameters.AddWithValue("@IdPlant", payload.IdPlant);
                            NoPjs = spCmd.ExecuteScalar()?.ToString() ?? "";
                        }
                        prefix = ", Region, Plant";
                        suffix = ", @IdRegion, @IdPlant";
                        break;
                    case "PUSAT":
                        using (SqlCommand spCmd = new SqlCommand("EXEC dbo.GenerateNomorPjs @OrganizationLevel = @Level", sqlConnection))
                        {
                            spCmd.Parameters.AddWithValue("@Level", organizationLevel);
                            NoPjs = spCmd.ExecuteScalar()?.ToString() ?? "";
                        }
                        break;
                }
                string suratTugasFileName = await UploadDokumenToAzureBlob(payload.SuratTugas, "PJSDocument");
                string nama = CurrentUserInfo("NamaLengkap")?.ToString();
                if (string.IsNullOrWhiteSpace(nama))
                {
                    nama = CurrentUserName();
                }
                sqlQuery = $@"INSERT INTO SetPjs 
                            (NomorPjs, SuratTugas, PosisiAwal, TanggalMulai, TanggalSelesai, PosisiPJS, Keterangan, Status, DibuatOleh, TanggalDibuat, Nama, OrganizationLevel{prefix})
                            VALUES 
                            (@NomorPjs, @SuratTugas, @PosisiAwal, @TanggalMulai, @TanggalSelesai, @PosisiPJS, @Keterangan, @Status, @DibuatOleh, @TanggalDibuat, @Nama, @OrganizationLevel{suffix});";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NomorPjs", NoPjs);
                    cmd.Parameters.AddWithValue("@SuratTugas", suratTugasFileName);
                    cmd.Parameters.AddWithValue("@PosisiAwal", CurrentUserInfo("IdPosition"));
                    cmd.Parameters.AddWithValue("@TanggalMulai", payload.TanggalMulai);
                    cmd.Parameters.AddWithValue("@TanggalSelesai", payload.TanggalSelesai);
                    cmd.Parameters.AddWithValue("@PosisiPJS", payload.PosisiPJS);
                    cmd.Parameters.AddWithValue("@Keterangan", payload.Keterangan?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@Status", "Requested");
                    cmd.Parameters.AddWithValue("@DibuatOleh", CurrentUserInfo("IdUser"));
                    cmd.Parameters.AddWithValue("@TanggalDibuat", DateTimeNow);
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@OrganizationLevel", organizationLevel);
                    if (organizationLevel == "REGION")
                    {
                        cmd.Parameters.AddWithValue("@IdRegion", payload.IdRegion);
                    }
                    else if (organizationLevel == "PLANT")
                    {
                        cmd.Parameters.AddWithValue("@IdRegion", payload.IdRegion);
                        cmd.Parameters.AddWithValue("@IdPlant", payload.IdPlant);
                    }
                    await cmd.ExecuteNonQueryAsync();
                }
                sqlQuery = @"
                    INSERT INTO LogPjs (NomorPjs, Status, Username, EtlDate, Catatan) 
                    VALUES (@NoPjs, @Status, @Username, @EtlDate, @Catatan)
                ";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NoPjs", NoPjs);
                    cmd.Parameters.AddWithValue("@Status", "Requested");
                    cmd.Parameters.AddWithValue("@Username", CurrentUserName());
                    cmd.Parameters.AddWithValue("@EtlDate", DateTimeNow);
                    cmd.Parameters.AddWithValue("@Catatan", "New Request PJS");
                    cmd.ExecuteNonQuery();
                }
            }
            return Ok(new { success = true, message = "Berhasil tambah data PJS." });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("UpdatePjs")]
    public async Task<IActionResult> UpdatePjs([FromForm] UpdatePjsDto payload)
    {
        try
        {
            if (!IsLoggedIn())
            {
                var response = new { success = false, message = "Not authorized." };
                return Json(response);
            }
            int currentUserId = CurrentUserInfo("IdUser") != null ? Convert.ToInt32(CurrentUserInfo("IdUser")) : 0;
            string sqlQuery = "", pjsStatus = "";
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                sqlQuery = $@"
                    SELECT Status, DibuatOleh FROM SetPjs
                    WHERE Id = @id
                ";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", payload.Id);
                    using (SqlDataReader rd = sqlCommand.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            pjsStatus = rd["Status"] != DBNull.Value ? rd["Status"].ToString() : "";
                            int pjsUserId = rd["DibuatOleh"] != DBNull.Value ? Convert.ToInt32(rd["DibuatOleh"]) : 0;
                            if (pjsStatus.ToLower() != "requested")
                            {
                                return Json(new { success = false, message = "Only PJS with 'Requested' status can be updated." });
                            }
                            if (pjsUserId != currentUserId)
                            {
                                return Json(new { success = false, message = "You are not authorized to update this PJS." });
                            }
                        }
                    }
                }
                DateTime DateTimeNow = DateTime.Now;
                sqlQuery = $@"
                    DECLARE @IdPlant INT;
                    SELECT TOP 1 @IdPlant = IdPlant
                    FROM MappingPosition
                    WHERE IdPosition = @IdPosition;
                    EXEC dbo.GetPlantDateTime @IdPlant = @IdPlant;
                ";
                using (SqlCommand spCmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    spCmd.Parameters.Add("@IdPosition", SqlDbType.Int).Value = payload.PosisiPJS;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        DateTimeNow = (DateTime)spResult;
                    }
                }
                string suratTugasFileName = "", prefix = "";
                if (payload.SuratTugas is { Length: > 0 })
                {
                    suratTugasFileName = await UploadDokumenToAzureBlob(payload.SuratTugas, "PJSDocument");
                    prefix = "SuratTugas = @SuratTugas,";
                }
                sqlQuery = $@"UPDATE SetPjs SET {prefix} TanggalMulai = @TanggalMulai, TanggalSelesai = @TanggalSelesai, PosisiPJS = @PosisiPJS, Keterangan = @Keterangan, DiperbaharuiOleh = @DiperbaharuiOleh, DiperbaharuiTanggal = @TanggalDiperbaharui WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", payload.Id);
                    cmd.Parameters.AddWithValue("@TanggalMulai", payload.TanggalMulai);
                    cmd.Parameters.AddWithValue("@TanggalSelesai", payload.TanggalSelesai);
                    cmd.Parameters.AddWithValue("@PosisiPJS", payload.PosisiPJS);
                    cmd.Parameters.AddWithValue("@Keterangan", payload.Keterangan?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@DiperbaharuiOleh", currentUserId);
                    cmd.Parameters.AddWithValue("@TanggalDiperbaharui", DateTimeNow);
                    if (payload.SuratTugas is { Length: > 0 })
                    {
                        cmd.Parameters.AddWithValue("@SuratTugas", suratTugasFileName);
                    }
                    await cmd.ExecuteNonQueryAsync();
                }
                AddLogPjs(payload.Id, pjsStatus, DateTimeNow, sqlConnection, "Update PJS");
            }
            return Ok(new { success = true, message = "Berhasil update data PJS." });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpPost("ApprovalPjs")]
    public async Task<IActionResult> ApprovalPjs([FromForm] ApprovalPjsDto payload)
    {
        try
        {
            if (!IsLoggedIn())
            {
                var response = new { success = false, message = "Not authorized." };
                return Json(response);
            }
            int pjsUserLevel = 0, pjsRole = 0;
            string sqlQuery = "";
            string status = payload.ApprovalStatus;
            int currentUserPositionId = CurrentUserInfo("IdPosition") != null ? Convert.ToInt32(CurrentUserInfo("IdPosition")) : 0;
            int currentUserId = CurrentUserInfo("IdUser") != null ? Convert.ToInt32(CurrentUserInfo("IdUser")) : 0;
            int currentUserLevel = CurrentUserLevel() != null ? Convert.ToInt32(CurrentUserLevel()) : 0;
            int currentRole = CurrentUserInfo("Rule") != null ? Convert.ToInt32(CurrentUserInfo("Rule")) : 0;
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                sqlQuery = $@"
                    SELECT pjs.Status, pjs.DibuatOleh, mu.exception 
                    FROM SetPjs pjs
                    INNER JOIN MasterUser mu ON pjs.DibuatOleh = mu.IdUser
                    WHERE pjs.Id = @id
                ";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", payload.Id);
                    using (SqlDataReader rd = sqlCommand.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            string pjsStatus = rd["Status"] != DBNull.Value ? rd["Status"].ToString() : "";
                            int pjsUserId = rd["DibuatOleh"] != DBNull.Value ? Convert.ToInt32(rd["DibuatOleh"]) : 0;
                            bool isException = rd["exception"] != DBNull.Value ? Convert.ToBoolean(rd["exception"]) : false;
                            if (pjsStatus.ToLower() != "requested" && status.ToLower() != "canceled")
                            {
                                return Json(new { success = false, message = "Only PJS with 'Requested' status can be updated." });
                            }
                            if (pjsUserId == currentUserId)
                            {
                                return Json(new { success = false, message = "You are not authorized to update the status of this PJS." });
                            }
                            if (isException && status.ToLower() != "canceled")
                            {
                                return Json(new { success = false, message = "The creator of this PJS is an exception user. Approval is not allowed." });
                            }
                        }
                    }
                }
                sqlQuery = $@"
                    SELECT UserLevel, Role FROM MasterPosition 
                    WHERE IdPosition = @IdPosition
                ";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdPosition", payload.PosisiPJS);
                    using (SqlDataReader rd = sqlCommand.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            pjsUserLevel = rd["UserLevel"] != DBNull.Value ? Convert.ToInt32(rd["UserLevel"]) : 0;
                            pjsRole = rd["Role"] != DBNull.Value ? Convert.ToInt32(rd["Role"]) : 0;
                        }
                    }
                }
                switch (pjsRole)
                {
                    case 15:
                        if (currentUserLevel != -1)
                        {
                            return Json(new { success = false, message = "Unauthorized: Only Admin can update the status of this PJS." });
                        }
                        break;
                    case 14:
                        if (currentUserLevel != -1 && currentRole != 15)
                        {
                            return Json(new { success = false, message = "Unauthorized: Only User Pusat/Admin can update the status of this PJS." });
                        }
                        break;
                    case 10:
                        if (currentUserLevel != -1 && currentRole != 14)
                        {
                            return Json(new { success = false, message = "Unauthorized: Only User Region/Admin can update the status of this PJS." });
                        }
                        bool isSameRegion = false;
                        sqlQuery = @"
                            SELECT 1
                            FROM MappingPosition mpPjs
                            INNER JOIN MappingPosition mpApprover
                                ON mpPjs.IdRegion = mpApprover.IdRegion
                            WHERE mpPjs.IdPosition = @PjsPosition
                            AND mpApprover.IdPosition = @ApproverPosition
                        ";
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                        {
                            cmd.Parameters.Add("@PjsPosition", SqlDbType.Int).Value = payload.PosisiPJS;
                            cmd.Parameters.Add("@ApproverPosition", SqlDbType.Int).Value = currentUserPositionId;
                            var result = cmd.ExecuteScalar();
                            isSameRegion = result != null;
                        }
                        if (currentUserLevel != -1 && !isSameRegion)
                        {
                            return Json(new { success = false, message = "Unauthorized: You can only update the status of this PJS if you are in the same region." });
                        }
                        break;
                    default:
                        if (currentUserLevel != -1 && currentRole != 10)
                        {
                            return Json(new { success = false, message = "Unauthorized: Only FTM/OH/User Plant/Admin can update the status of this PJS." });
                        }
                        bool isSamePlant = false;
                        sqlQuery = @"
                            SELECT 1
                            FROM MappingPosition mpPjs
                            INNER JOIN MappingPosition mpApprover
                                ON mpPjs.IdPlant = mpApprover.IdPlant
                            WHERE mpPjs.IdPosition = @PjsPosition
                            AND mpApprover.IdPosition = @ApproverPosition
                        ";
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                        {
                            cmd.Parameters.Add("@PjsPosition", SqlDbType.Int).Value = payload.PosisiPJS;
                            cmd.Parameters.Add("@ApproverPosition", SqlDbType.Int).Value = currentUserPositionId;
                            var result = cmd.ExecuteScalar();
                            isSamePlant = result != null;
                        }
                        if (currentUserLevel != -1 && !isSamePlant)
                        {
                            return Json(new { success = false, message = "Unauthorized: You can only update the status of this PJS if you are in the same plant." });
                        }
                        break;
                }
                DateTime DateTimeNow = DateTime.Now;
                sqlQuery = $@"
                    DECLARE @IdPlant INT;
                    SELECT TOP 1 @IdPlant = IdPlant
                    FROM MappingPosition
                    WHERE IdPosition = @IdPosition;
                    EXEC dbo.GetPlantDateTime @IdPlant = @IdPlant;
                ";
                using (SqlCommand spCmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    spCmd.Parameters.Add("@IdPosition", SqlDbType.Int).Value = payload.PosisiPJS;
                    var spResult = spCmd.ExecuteScalar();
                    if (spResult != DBNull.Value && spResult != null)
                    {
                        DateTimeNow = (DateTime)spResult;
                    }
                }
                if (status == "Approved")
                {
                    sqlQuery = @"UPDATE SetPjs SET Status = 'Approved', DiperbaharuiOleh = @DiperbaharuiOleh, DiperbaharuiTanggal = @TanggalDiperbaharui WHERE Id = @id";
                }
                else if (status == "Rejected")
                {
                    sqlQuery = @"UPDATE SetPjs SET Status = 'Rejected', Remaks = @Remarks, DiperbaharuiOleh = @DiperbaharuiOleh, DiperbaharuiTanggal = @TanggalDiperbaharui WHERE Id = @id";
                }
                else if (status == "Canceled")
                {
                    sqlQuery = @"UPDATE SetPjs SET Status = 'Canceled', DiperbaharuiOleh = @DiperbaharuiOleh, DiperbaharuiTanggal = @TanggalDiperbaharui WHERE Id = @id";
                }
                using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", payload.Id);
                    cmd.Parameters.AddWithValue("@DiperbaharuiOleh", currentUserId);
                    cmd.Parameters.AddWithValue("@TanggalDiperbaharui", DateTimeNow);
                    if (status == "Rejected")
                    {
                        cmd.Parameters.AddWithValue("@Remarks", payload.Remarks ?? "");
                    }
                    await cmd.ExecuteNonQueryAsync();
                }
                if (status == "Approved")
                {
                    sqlQuery = @"
                        UPDATE mu
                        SET mu.IdPosition = pjs.PosisiPJS,
                            mu.exception = 1,
                            mu.[Rule] = mp.Role,
                            mu.UserLevel = mp.UserLevel,
                            mu.DiperbaruiOleh = @DiperbaruiOleh,
                            mu.TanggalDiperbarui = @DateTimeNow
                        FROM MasterUser mu
                        INNER JOIN SetPJS pjs 
                            ON mu.IdUser = pjs.DibuatOleh
                        INNER JOIN MasterPosition mp 
                            ON pjs.PosisiPJS = mp.IdPosition
                        WHERE pjs.Id = @Id
                            AND pjs.TanggalMulai <= CONVERT(date, @DateTimeNow)
                            AND ISNULL(mu.exception, 0) <> 1;
                    ";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@id", payload.Id);
                        cmd.Parameters.AddWithValue("@DiperbaruiOleh", currentUserId);
                        cmd.Parameters.AddWithValue("@DateTimeNow", DateTimeNow);
                        await cmd.ExecuteNonQueryAsync();
                    }
                } 
                else if (status == "Canceled")
                {
                    sqlQuery = @"
                        UPDATE mu
                        SET mu.IdPosition = pjs.PosisiAwal,
                            mu.exception = 0,
                            mu.[Rule] = mp.Role,
                            mu.UserLevel = mp.UserLevel,
                            mu.DiperbaruiOleh = @DiperbaruiOleh,
                            mu.TanggalDiperbarui = @DateTimeNow
                        FROM MasterUser mu
                        INNER JOIN SetPJS pjs 
                            ON mu.IdUser = pjs.DibuatOleh
                        INNER JOIN MasterPosition mp 
                            ON pjs.PosisiAwal = mp.IdPosition
                        WHERE pjs.Id = @Id
                            AND exception = 1;
                    ";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@id", payload.Id);
                        cmd.Parameters.AddWithValue("@DiperbaruiOleh", currentUserId);
                        cmd.Parameters.AddWithValue("@DateTimeNow", DateTimeNow);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                AddLogPjs(payload.Id, status, DateTimeNow, sqlConnection, "Approval");
            }
            return Ok(new { success = true, message = "Berhasil update status PJS." });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    private void AddLogPjs(int idPjs, string status, DateTime DateTimeNow, SqlConnection sqlConnection, string catatan)
    {
        string sqlQuery = @"
            INSERT INTO LogPjs (NomorPjs, Status, Username, EtlDate, Catatan)
            SELECT pjs.NomorPjs, @Status, @Username, @EtlDate, @Catatan
            FROM SetPjs pjs
            WHERE pjs.Id = @IdPjs;
        ";
        using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
        {
            cmd.Parameters.AddWithValue("@IdPjs", idPjs);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Username", CurrentUserName());
            cmd.Parameters.AddWithValue("@EtlDate", DateTimeNow);
            cmd.Parameters.AddWithValue("@Catatan", catatan);
            cmd.ExecuteNonQuery();
        }
    }

    [HttpGet("GetLogPjs")]
    public IActionResult GetLogPjs(string NomorPjs)
    {
        if (!IsLoggedIn())
        {
            var response = new { success = false, message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan." };
            return Json(response);
        }
        List<Dictionary<string, object>> resultList = new List<Dictionary<string, object>>();
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string sqlData = "SELECT Username, Status, EtlDate, Catatan FROM LogPjs WHERE NomorPjs = @NomorPjs ORDER BY EtlDate DESC;";
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NomorPjs", EncodeForXSS(NomorPjs));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                resultList.Add(new Dictionary<string, object>
                                {
                                    { "Username", reader["Username"]?.ToString() ?? "" },
                                    { "Status", reader["Status"]?.ToString() ?? "" },
                                    { "EtlDate", reader["EtlDate"] != DBNull.Value ? Convert.ToDateTime(reader["EtlDate"]).ToString("yyyy-MM-dd HH:mm:ss") : "" },
                                    { "Catatan", reader["Catatan"]?.ToString() ?? "" }
                                });
                            }
                        }
                        else
                        {
                            return Ok(new { success = false, result = resultList });
                        }
                    }
                }
            }
            return Ok(new
            {
                success = true,
                result = resultList
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetDetailPjs")]
    public IActionResult GetDetailPjs()
    {
        if (!IsLoggedIn())
        {
            var response = new
            {
                success = false,
                message = CurrentLanguage == "en-US" ? "Not authorized." : "Tidak diizinkan."
            };
            return Json(response);
        }
        var result = new Dictionary<string, object>();
        try
        {
            using (SqlConnection sqlConnection = GetConnection("Db").OpenConnection())
            {
                string sqlData = @"
                    SELECT TOP 1
                        CONCAT(mp.IdPosition, ' - ', mp.NamaPosition) AS PosisiPJS,
                        pjs.TanggalMulai,
                        pjs.TanggalSelesai,
                        mu.[exception]
                    FROM SetPjs pjs
                    INNER JOIN MasterPosition mp ON pjs.PosisiPJS = mp.IdPosition
                    INNER JOIN MasterUser mu ON pjs.DibuatOleh = mu.IdUser
                    WHERE pjs.DibuatOleh = @IdUser 
                    AND mu.[exception] = 1
                    ORDER BY pjs.TanggalDibuat DESC;
                ";
                int idUser = CurrentUserInfo("IdUser") != null
                    ? Convert.ToInt32(CurrentUserInfo("IdUser"))
                    : 0;
                using (SqlCommand sqlCommand = new SqlCommand(sqlData, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@IdUser", SqlDbType.Int).Value = idUser;
                    using (SqlDataReader rd = sqlCommand.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            result["PosisiPJS"] = rd["PosisiPJS"] != DBNull.Value ? rd["PosisiPJS"].ToString() : null;
                            result["TanggalMulai"] = rd["TanggalMulai"] != DBNull.Value ? Convert.ToDateTime(rd["TanggalMulai"]).ToString("yyyy/MM/dd") : null;
                            result["TanggalSelesai"] = rd["TanggalSelesai"] != DBNull.Value ? Convert.ToDateTime(rd["TanggalSelesai"]).ToString("yyyy/MM/dd") : null;
                            result["exception"] = rd["exception"] != DBNull.Value && Convert.ToBoolean(rd["exception"]);
                        }
                    }
                }
            }
            return Ok(new
            {
                success = true,
                result
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred on the server.");
        }
    }

    [HttpGet("GetVisitors")]
    public IActionResult GetVisitors(DateTime startDate, DateTime endDate)
    {
        if (!IsLoggedIn())
        {
            return Json(new { success = false, message = "Not authorized." });
        }
        List<object> data = new List<object>();
        try
        {
            using (SqlConnection connection = GetConnection("Db").OpenConnection())
            {
                string query = @"
                    SELECT 
                        bt.Id,
                        bt.Nama AS Name,
                        bt.AsalPerusahaan AS Company,
                        bt.Jabatan AS Position,
                        bt.Tanggal AS Visit_Date,
                        CONCAT(p.Plant, ' - ', p.Nama_Terminal) AS Location,
                        bt.MaksudKunjungan AS Purpose
                    FROM BukuTamu bt
                    INNER JOIN MasterPlant p 
                        ON bt.Plant = p.IdPlant
                    WHERE 
                        p.Region = 7
                        AND bt.Tanggal >= @StartDate
                        AND bt.Tanggal < DATEADD(DAY,1,@EndDate)
                    ORDER BY bt.Tanggal";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new
                            {
                                Id = reader["Id"],
                                Name = reader["Name"]?.ToString(),
                                Company = reader["Company"]?.ToString(),
                                Position = reader["Position"]?.ToString(),
                                Visit_Date = Convert.ToDateTime(reader["Visit_Date"]).ToString("yyyy/MM/dd HH:mm:ss"),
                                Location = reader["Location"]?.ToString(),
                                Purpose = reader["Purpose"]?.ToString()
                            });
                        }
                    }
                }
            }
            return Json(new { success = true, data });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    [HttpPost("position-by-email")]
    public IActionResult CheckIdamanPositionManual([FromBody] CheckIdamanPositionRequest request)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        try
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email))
                return Json(new { success = false, message = "Email wajib diisi." });
            string normalizedEmail = request.Email.Trim();
            dynamic existingMasterUser = QueryBuilder("MasterUser")
                .Select("IdUser", "Email", "NamaLengkap", "UserName")
                .Where("Email", normalizedEmail)
                .FirstOrDefault();
            bool alreadyExistsInMasterUser = existingMasterUser != null;
            bool isPjs = false;
            if (alreadyExistsInMasterUser && existingMasterUser?.IdUser != null)
            {
                int idUser = Convert.ToInt32(existingMasterUser.IdUser);
                dynamic existingSetPjs = QueryBuilder("SetPjs")
                    .Where("DibuatOleh", idUser)
                    .Where("Status", "Approved")
                    .FirstOrDefault();
                isPjs = existingSetPjs != null;
            }

            /*
             * sementara comment dulu
            if (alreadyExistsInMasterUser)
            {
                return Json(new
                {
                    success = false,
                    message = "Sudah terdapat user dengan email ini."
                });
            }
            */
            var idamanProfile = GetIdamanUserPositionByEmail(normalizedEmail);
            bool userFoundInIdaman = !string.IsNullOrWhiteSpace(idamanProfile.Email);
            if (!userFoundInIdaman)
            {
                return Json(new
                {
                    success = false,
                    message = "User tidak ditemukan di Idaman.",
                    data = new
                    {
                        email = normalizedEmail,
                        alreadyExistsInMasterUser = alreadyExistsInMasterUser,
                        isPjs = isPjs
                    }
                });
            }
            int resolvedPositionId = idamanProfile.IdPosition;
            string resolvedPositionName = idamanProfile.PositionName ?? string.Empty;
            string resolvedEmail = idamanProfile.Email ?? normalizedEmail;
            string resolvedFullName = idamanProfile.FullName ?? string.Empty;
            string resolvedUserName = idamanProfile.UserName ?? string.Empty;
            string resolvedIdPositionIdaman = idamanProfile.IdPositionIdaman ?? string.Empty;
            int resolvedRole = -1;
            int resolvedUserLevel = 8;
            dynamic existingMasterPosition = QueryBuilder("MasterPosition")
                .Where("IdPosition", resolvedPositionId)
                .Select("IdPosition", "NamaPosition", "Role", "UserLevel")
                .FirstOrDefault();
            if (existingMasterPosition == null || existingMasterPosition?.IdPosition == null)
            {
                QueryBuilder("MasterPosition").Insert(new
                {
                    IdPosition = resolvedPositionId,
                    NamaPosition = resolvedPositionName,
                    Role = -1,
                    UserLevel = 8
                });
            }
            else
            {
                resolvedRole = existingMasterPosition?.Role != null
                    ? Convert.ToInt32(existingMasterPosition.Role)
                    : -1;
                resolvedUserLevel = existingMasterPosition?.UserLevel != null
                    ? Convert.ToInt32(existingMasterPosition.UserLevel)
                    : 8;
            }
            string resolvedUserLevelName = string.Empty;
            dynamic existingUserLevel = QueryBuilder("UserLevels")
                .Where("UserLevelID", resolvedUserLevel)
                .Select("UserLevelID", "UserLevelName")
                .FirstOrDefault();
            if (existingUserLevel != null && existingUserLevel?.UserLevelName != null)
                resolvedUserLevelName = Convert.ToString(existingUserLevel.UserLevelName) ?? string.Empty;
            string resolvedRoleName = string.Empty;
            dynamic existingRole = QueryBuilder("MasterPIC")
                .Where("IdPIC", resolvedRole)
                .Select("IdPIC", "NamaPIC")
                .FirstOrDefault();
            if (existingRole != null && existingRole?.NamaPIC != null)
                resolvedRoleName = Convert.ToString(existingRole.NamaPIC);
            return Json(new
            {
                success = true,
                data = new
                {
                    user = new
                    {
                        email = resolvedEmail,
                        fullName = resolvedFullName,
                        userName = resolvedUserName,
                        level = new
                        {
                            id = resolvedUserLevel,
                            name = resolvedUserLevelName
                        },
                        role = new
                        {
                            id = resolvedRole,
                            name = resolvedRoleName,
                        },
                        idaman = new
                        {
                            id = idamanProfile.IdIdaman,
                            position = new
                            {
                                id = resolvedPositionId,
                                idIdaman = resolvedIdPositionIdaman,
                                name = resolvedPositionName,
                            },
                        },
                        exists = alreadyExistsInMasterUser,
                        isPjs = isPjs
                    },
                }
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                message = "Terjadi kesalahan.",
                detail = ex.Message
            });
        }
    }

    private IdamanResolvedUserDto GetIdamanUserPositionByEmail(string email)
    {
        using var httpClient = new HttpClient();
        var tokenRequest = new HttpRequestMessage(HttpMethod.Post, $"{IdamanApiUrls.LoginBaseUrl}/connect/token")
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", IdamanApiUrls.ClientId },
                { "client_secret", IdamanApiUrls.ClientSecret },
                { "scope", IdamanApiUrls.Scope },
                { "grant_type", IdamanApiUrls.GrantType }
            })
        };
        var tokenResponse = httpClient.SendAsync(tokenRequest).Result;
        tokenResponse.EnsureSuccessStatusCode();
        var tokenPayload = tokenResponse.Content.ReadAsStringAsync().Result;
        var tokenResult = System.Text.Json.JsonSerializer.Deserialize<TokenResponse>(tokenPayload, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var accessToken = tokenResult?.access_token;
        if (string.IsNullOrWhiteSpace(accessToken))
            throw new Exception("Token Idaman tidak berhasil didapatkan.");
        string? nextPageUrl = $"{IdamanApiUrls.RestBaseUrl}/v1/users/company/2222?SearchText={email}";
        int resolvedPositionId = 11111111;
        var result = new IdamanResolvedUserDto();
        while (!string.IsNullOrWhiteSpace(nextPageUrl))
        {
            var userRequest = new HttpRequestMessage(HttpMethod.Get, nextPageUrl);
            userRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var userResponse = httpClient.SendAsync(userRequest).Result;
            userResponse.EnsureSuccessStatusCode();
            var responsePayload = userResponse.Content.ReadAsStringAsync().Result;
            var userSearchResult = System.Text.Json.JsonSerializer.Deserialize<IdamanUserSearchResponse>(responsePayload, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); ;
            if (userSearchResult?.value != null)
            {
                var matchedUser = userSearchResult.value.FirstOrDefault(user => !string.IsNullOrWhiteSpace(user.email) && user.email.Equals(email, StringComparison.OrdinalIgnoreCase));
                if (matchedUser != null)
                {
                    if (!int.TryParse(matchedUser.position?.id, out resolvedPositionId))
                        resolvedPositionId = 11111111;
                    result.IdPosition = resolvedPositionId;
                    result.IdPositionIdaman = matchedUser.position?.id ?? string.Empty;
                    result.PositionName = matchedUser.position?.name ?? string.Empty;
                    result.Email = matchedUser.email ?? string.Empty;
                    result.IdIdaman = matchedUser.id ?? string.Empty;
                    result.FullName = matchedUser.displayName ?? string.Empty;
                    result.UserName = matchedUser.username ?? string.Empty;
                    break;
                }
            }
            nextPageUrl = userSearchResult?.next;
        }
        return result;
    }
}

public class ImagesController : Controller
{
    private readonly string imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "bgimages");

    [HttpGet]
    public IActionResult GetImageList()
    {
        if (!Directory.Exists(imagesDirectory))
        {
            return NotFound();
        }
        var files = Directory.GetFiles(imagesDirectory)
            .Where(file => file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png") || file.EndsWith(".gif"))
            .Select(file => $"bgimages/{Path.GetFileName(file)}");
        return Json(files);
    }
}

public partial class QqController : ApiController
{
    private readonly IConfiguration _config;

    private readonly IWebHostEnvironment _env;

    public QqController(IConfiguration config, IWebHostEnvironment env)
    {
        _config = config;
        _env = env;
    }

    private static string GetContentTypeFromFileName(string fileName)
    {
        string ext = Path.GetExtension(fileName).ToLowerInvariant();
        return ext switch
        {
            ".gif" => "image/gif",
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            ".bmp" => "image/bmp",
            ".png" => "image/png",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".xls" => "application/vnd.ms-excel",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".pdf" => "application/pdf",
            ".zip" => "application/zip",
            ".txt" => "text/plain",
            _ => "application/octet-stream"
        };
    }

    private sealed class UploadResult
    {
        public string StoredFileName { get; set; } = "";

        public bool IsAzure { get; set; }

        public string? ContainerName { get; set; }

        public string? BlobPath { get; set; }     // e.g. "PengujianSampleLainnya/abc.zip"

        public string? LocalFullPath { get; set; } // e.g. ".../wwwroot/Uploads/..../abc.zip"
    }

    private async Task<UploadResult> UploadStreamAsync(Stream stream, string originalFileName, string path, string contentType)
    {
        var connString = _config["AzureBlob:ConnectionString"];
        var containerName = _config["AzureBlob:ContainerName"];
        var baseName = Path.GetFileNameWithoutExtension(originalFileName);
        var ext = Path.GetExtension(originalFileName);
        var uniqueFileName = $"{baseName}_{DateTime.Now:yyyyMMddHHmmssfff}{ext}";

        // azure
        if (!string.IsNullOrWhiteSpace(connString) && !string.IsNullOrWhiteSpace(containerName))
        {
            var blobServiceClient = new BlobServiceClient(connString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);
            var blobPath = $"{path}/{uniqueFileName}";
            var blobClient = containerClient.GetBlobClient(blobPath);
            stream.Position = 0;
            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType });
            return new UploadResult
            {
                StoredFileName = uniqueFileName,
                IsAzure = true,
                ContainerName = containerName,
                BlobPath = blobPath
            };
        }

        // fallback to local
        string root = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string uploadDir = Path.Combine(root, "Uploads", path);
        Directory.CreateDirectory(uploadDir);
        string fullPath = Path.Combine(uploadDir, uniqueFileName);
        stream.Position = 0;
        await using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            await stream.CopyToAsync(fs);
        return new UploadResult
        {
            StoredFileName = uniqueFileName,
            IsAzure = false,
            LocalFullPath = fullPath
        };
    }

    private async Task DeleteUploadedAsync(UploadResult? u)
    {
        if (u == null) return;
        try
        {
            if (u.IsAzure)
            {
                var connString = _config["AzureBlob:ConnectionString"];
                if (string.IsNullOrWhiteSpace(connString) || string.IsNullOrWhiteSpace(u.ContainerName) || string.IsNullOrWhiteSpace(u.BlobPath))
                    return;
                var blobServiceClient = new BlobServiceClient(connString);
                var containerClient = blobServiceClient.GetBlobContainerClient(u.ContainerName);
                var blobClient = containerClient.GetBlobClient(u.BlobPath);
                await blobClient.DeleteIfExistsAsync();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(u.LocalFullPath) && System.IO.File.Exists(u.LocalFullPath))
                    System.IO.File.Delete(u.LocalFullPath);
            }
        }
        catch
        { }
    }

    private async Task<UploadResult> UploadFilesSmartAsync(List<IFormFile> files, string path, string baseName)
    {
        if (files.Count == 1)
        {
            var f = files[0];
            var ct = string.IsNullOrWhiteSpace(f.ContentType) ? GetContentTypeFromFileName(f.FileName) : f.ContentType;
            await using var s = f.OpenReadStream();
            return await UploadStreamAsync(s, f.FileName, path, ct);
        }

        // > 1 file => zip
        var (zipStream, zipName) = await BuildZipAsync(files); // zipName bisa kamu set baseName + ".zip" di BuildZipAsync
        await using (zipStream)
        {
            var finalZipName = string.IsNullOrWhiteSpace(zipName) ? $"{baseName}.zip" : zipName;
            return await UploadStreamAsync(zipStream, finalZipName, path, "application/zip");
        }
    }

    [HttpPost("psm-add")]
    public async Task<IActionResult> AddPenyimpananSample([FromForm] PenyimpananSampleRequest request)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized" });
        UploadResult? uploaded = null;
        try
        {
            var files = request.Foto?.Where(f => f?.Length > 0).ToList() ?? new List<IFormFile>();
            if (files.Count == 0)
                return Json(new { success = false, message = "File tidak boleh kosong." });
            using SqlConnection conn = GetConnection("Db").OpenConnection();
            string noPenyimpanan;
            using (var cmd = new SqlCommand("EXEC dbo.GenerateNomorPenyimpananSample @IdPlant = @IdPlant", conn))
            {
                cmd.Parameters.Add("@IdPlant", SqlDbType.Int).Value = request.IdPlant;
                noPenyimpanan = (await cmd.ExecuteScalarAsync())?.ToString()?.Trim() ?? "";
            }
            if (string.IsNullOrWhiteSpace(noPenyimpanan))
                return Json(new { success = false, message = "Gagal generate nomor penyimpanan sample." });
            var baseName = $"PSM_{noPenyimpanan}".Replace("/", "-").Replace("\\", "-").Replace(" ", "_");
            uploaded = await UploadFilesSmartAsync(files, path: "PenyimpananSample", baseName: baseName);
            using var tx = conn.BeginTransaction();
            try
            {
                const string query = @"
                    INSERT INTO PenyimpananSample (JenisSample, IdPlant, Tanggal, NamaMasterSample, NomorSegel, Foto, ExpiredEst, etlDate, LastUpdatedBy, lastUpdatedDate, Status, NomorPenyimpananSample, CreatedBy)
                    OUTPUT INSERTED.Id
                    VALUES (@JenisSample, @IdPlant, @Tanggal, @NamaMasterSample, @NomorSegel, @Foto, @ExpiredEst, @Now, @User, @Now, @Status, @NomorPenyimpananSample, @User);";
                using var cmd = new SqlCommand(query, conn, tx);
                var user = CurrentUserName();
                var now = DateTime.Now;
                cmd.Parameters.Add("@JenisSample", SqlDbType.VarChar, 50).Value = request.JenisSample;
                cmd.Parameters.Add("@IdPlant", SqlDbType.Int).Value = request.IdPlant;
                cmd.Parameters.Add("@Tanggal", SqlDbType.DateTime).Value = request.Tanggal;
                cmd.Parameters.Add("@NamaMasterSample", SqlDbType.NVarChar, 255).Value = (object?)request.NamaMasterSample ?? DBNull.Value;
                cmd.Parameters.Add("@NomorSegel", SqlDbType.NVarChar, 100).Value = string.IsNullOrWhiteSpace(request.NomorSegel) ? (object)DBNull.Value : request.NomorSegel.Trim();
                cmd.Parameters.Add("@Foto", SqlDbType.NVarChar, 500).Value = string.IsNullOrWhiteSpace(uploaded?.StoredFileName) ? DBNull.Value : uploaded!.StoredFileName;
                cmd.Parameters.Add("@ExpiredEst", SqlDbType.DateTime).Value = request.ExpiredEst.HasValue ? request.ExpiredEst.Value : (object)DBNull.Value;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = "Tersimpan";
                cmd.Parameters.Add("@NomorPenyimpananSample", SqlDbType.NVarChar, 100).Value = noPenyimpanan;
                cmd.Parameters.Add("@Now", SqlDbType.DateTime).Value = now;
                cmd.Parameters.Add("@User", SqlDbType.NVarChar, 100).Value = user;
                var newIdObj = await cmd.ExecuteScalarAsync();
                if (newIdObj == null || newIdObj == DBNull.Value)
                    throw new Exception("Gagal menambahkan data.");
                tx.Commit();
                return Json(new { success = true, message = "Berhasil menambahkan data." });
            }
            catch
            {
                tx.Rollback();
                // DB gagal → hapus blob/local yang sudah terupload
                await DeleteUploadedAsync(uploaded);
                throw;
            }
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            return Json(new { success = false, message = "Terjadi kesalahan saat menyimpan data." });
        }
    }

    [HttpPost("psl-add")]
    public async Task<IActionResult> AddPengujianSampleLainnya([FromForm] PengujianSampleLainnyaRequest request)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized" });
        UploadResult? uploaded = null;
        try
        {
            // --- validate
            string idPlant = (request.idPlant ?? "").Trim();
            string produk = (request.Produk ?? "").Trim();
            string tanggalRaw = (request.Tanggal ?? "").Trim();
            string keterangan = (request.Keterangan ?? "").Trim();
            if (string.IsNullOrWhiteSpace(idPlant))
                return Json(new { success = false, message = "Plant is required." });
            if (string.IsNullOrWhiteSpace(tanggalRaw))
                return Json(new { success = false, message = "Tanggal is required." });
            if (string.IsNullOrWhiteSpace(produk))
                return Json(new { success = false, message = "Produk is required." });
            if (!DateTime.TryParse(tanggalRaw, out var tanggal))
                return Json(new { success = false, message = "Format tanggal tidak valid." });
            var files = request.files?.Where(f => f?.Length > 0).ToList() ?? new List<IFormFile>();
            if (files.Count == 0)
                return Json(new { success = false, message = "File tidak boleh kosong." });
            using SqlConnection conn = GetConnection("Db").OpenConnection();

            // --- generate nomor (di luar tx boleh, tapi aman juga di dalam)
            string noPengujian;
            using (var cmd = new SqlCommand("EXEC dbo.GenerateNomorPengujianSampleLainnya @IdPlant = @IdPlant", conn))
            {
                cmd.Parameters.Add("@IdPlant", SqlDbType.NVarChar, 50).Value = idPlant;
                noPengujian = (await cmd.ExecuteScalarAsync())?.ToString()?.Trim() ?? "";
            }
            if (string.IsNullOrWhiteSpace(noPengujian))
                throw new Exception("Gagal generate nomor pengujian.");

            // --- upload 1 file langsung, >1 zip
            // baseName buat nama zip yang enak (optional)
            var baseName = $"PSL_{noPengujian}".Replace("/", "-").Replace("\\", "-").Replace(" ", "_");
            uploaded = await UploadFilesSmartAsync(files, path: "PengujianSampleLainnya", baseName: baseName);

            // --- DB transaction
            using var tx = conn.BeginTransaction();
            try
            {
                const string query = @"
                    INSERT INTO PengujianSampleLainnya (NomorPengujianSampelLainnya, IdPlant, Tanggal, Produk, UploadHasil, Keterangan, DibuatOleh, TanggalDibuat, DiperbaruiOleh, TanggalDiperbarui)
                    OUTPUT INSERTED.Id
                    VALUES (@NoPengujian, @IdPlant, @Tanggal, @Produk, @UploadHasil, @Keterangan, @User, @Now, @User, @Now);";
                using var cmd = new SqlCommand(query, conn, tx);
                var user = CurrentUserName();
                var now = DateTime.Now;
                cmd.Parameters.Add("@NoPengujian", SqlDbType.NVarChar, 100).Value = noPengujian;
                cmd.Parameters.Add("@IdPlant", SqlDbType.NVarChar, 50).Value = idPlant;
                cmd.Parameters.Add("@Tanggal", SqlDbType.DateTime).Value = tanggal;
                cmd.Parameters.Add("@Produk", SqlDbType.NVarChar, 100).Value = produk;
                cmd.Parameters.Add("@UploadHasil", SqlDbType.NVarChar, 255).Value =
                    string.IsNullOrWhiteSpace(uploaded?.StoredFileName) ? DBNull.Value : uploaded!.StoredFileName;
                cmd.Parameters.Add("@Keterangan", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(keterangan) ? DBNull.Value : keterangan;
                cmd.Parameters.Add("@User", SqlDbType.NVarChar, 100).Value = user;
                cmd.Parameters.Add("@Now", SqlDbType.DateTime).Value = now;
                var newIdObj = await cmd.ExecuteScalarAsync();
                if (newIdObj == null || newIdObj == DBNull.Value)
                    throw new Exception("Gagal menambahkan data.");
                tx.Commit();
                return Json(new { success = true, message = "Berhasil menambahkan data." });
            }
            catch
            {
                tx.Rollback();
                // DB gagal → hapus blob/local yang sudah terupload
                await DeleteUploadedAsync(uploaded);
                throw;
            }
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            return Json(new { success = false, message = "Terjadi kesalahan saat menyimpan data." });
        }
    }

    [HttpGet("download")]
    public async Task<IActionResult> Download(int id, string type)
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        type = (type ?? "").Trim().ToLowerInvariant();

        // ===== CENTRALIZED MAPPING =====
        var fileMap = new Dictionary<string, (string Column, string Folder)>
        {
            { "psl", ("UploadHasil", "PengujianSampleLainnya") },
            { "psm", ("Foto", "PenyimpananSample") },
            // add more...
        };
        if (!fileMap.TryGetValue(type, out var config))
            return Json(new { success = false, message = "Invalid attachment type." });
        string col = config.Column;
        string folder = config.Folder; // samakan aja dengan nama tabel

        // ===== GET FILENAME FROM DB =====
        string? storedFilename;
        using (SqlConnection conn = GetConnection("Db").OpenConnection())
        using (SqlCommand cmd = new SqlCommand(
            $"SELECT {col} FROM {folder} WHERE Id = @Id", conn))
        {
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            storedFilename = (await cmd.ExecuteScalarAsync())?.ToString();
        }
        storedFilename = (storedFilename ?? "").Trim();
        if (string.IsNullOrWhiteSpace(storedFilename))
            return Json(new { success = false, message = "File not found." });
        var contentType = GetContentTypeFromFileName(storedFilename);
        string? connString = _config["AzureBlob:ConnectionString"];
        string? containerName = _config["AzureBlob:ContainerName"];
        string blobPath = $"{folder}/{storedFilename}";

        // ===== AZURE =====
        if (!string.IsNullOrWhiteSpace(connString) && !string.IsNullOrWhiteSpace(containerName))
        {
            var service = new BlobServiceClient(connString);
            var container = service.GetBlobContainerClient(containerName);
            var blob = container.GetBlobClient(blobPath);
            if (!await blob.ExistsAsync())
                return Json(new { success = false, message = "File not found." });
            var response = await blob.DownloadStreamingAsync();
            var dl = response.Value;
            return File(dl.Content, contentType, storedFilename);
        }

        // ===== LOCAL FALLBACK =====
        string root = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string fullPath = Path.Combine(root, "Uploads", folder, storedFilename);
        if (!System.IO.File.Exists(fullPath))
            return Json(new { success = false, message = "File not found." });
        var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        return File(fs, contentType, storedFilename);
    }
}

public partial class PovController : ApiController
{
    private readonly IConfiguration _config;

    public PovController(IConfiguration config)
    {
        _config = config;
    }

    //private SqlConnection GetConnection()
    //{
    //    var cs = _config.GetConnectionString("Db");
    //    return new SqlConnection(cs);
    //}
    [HttpGet("permission/valid")]
    public async Task<IActionResult> GetPermission()
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized." });
        try
        {
            int.TryParse(Convert.ToString(CurrentUserInfo("IdUser")), out int uid);
            var parameters = new Dictionary<string, object>
            {
                ["@Uid"] = uid,
            };
            var sql = @"
            SELECT CASE 
                WHEN EXISTS (SELECT 1 FROM SetUserMOD WHERE UserMOD = @Uid AND CAST (Tanggal AS DATE) = CAST (GETDATE() AS DATE)) THEN 1 
                ELSE 0 
            END AS Valid;";
            int validInt = DatabaseQueryHelper.ExecuteSelectSingle<int>(
                sql,
                reader => reader["Valid"] != DBNull.Value ? Convert.ToInt32(reader["Valid"]) : 0,
                parameters
            );
            return Json(new { success = true, data = new { valid = validInt == 1 }, message = "" });
        }
        catch (Exception ex) 
        {
            return Json(new { success = false, message = ex.Message });
        } 
    }

    [HttpGet("dropdown/plant")]
    public IActionResult GetPlantDropdown(string? menu = "HSSE") 
    {
        if (!IsLoggedIn())
            return Json(new { success = false, message = "Not authorized.", data = Array.Empty<DropdownResponse>() });
        try 
        {
            int.TryParse(Convert.ToString(CurrentUserInfo("IdUser")), out int uid);
            int.TryParse(Convert.ToString(CurrentUserInfo("UserLevel")), out int ulv);
            int.TryParse(Convert.ToString(CurrentUserInfo("Rule")), out int rule);
            int.TryParse(Convert.ToString(CurrentUserInfo("IdPosition")), out int idPosition);
            menu ??= "HSSE";
            bool isHSSE = menu.Equals("HSSE", StringComparison.OrdinalIgnoreCase);
            bool isPenyaluran = menu.Equals("Penyaluran", StringComparison.OrdinalIgnoreCase);
            var parameters = new Dictionary<string, object>
            {
                ["@Uid"] = uid,
                ["@IdPosition"] = idPosition,
                // ...add more
            };
            bool isModToday;
            using (var conn = GetConnection("Db").OpenConnection())
            using (var cmd = new SqlCommand(@"
            SELECT CASE WHEN EXISTS (
                SELECT 1
                FROM SetUserMOD
                WHERE UserMOD = @Uid
                  AND Tanggal >= CONVERT(date, GETDATE())
                  AND Tanggal <  DATEADD(day, 1, CONVERT(date, GETDATE()))
            ) THEN 1 ELSE 0 END;", conn))
            {
                cmd.Parameters.Add("@Uid", SqlDbType.Int).Value = uid;
                isModToday = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }

            // query 1: query untuk user MOD hari ini, dipengaruhi data dari table SetUserMOD
            const string query1 = @"
                SELECT DISTINCT
                    MP.IdPlant AS [Value],
                    CONCAT(MP.Plant, ' - ', MP.Nama_Terminal) AS Label
                FROM SetUserMOD SUMOD
                    JOIN MasterPlant MP ON MP.IdPlant = SUMOD.LookupPlant
                WHERE SUMOD.UserMOD = @Uid
                    AND SUMOD.Tanggal >= CONVERT(date, GETDATE())
                    AND SUMOD.Tanggal <  DATEADD(day, 1, CONVERT(date, GETDATE()))";
            // query 2: query berdasarkan IdPosition
            const string query2 = @"
                SELECT DISTINCT
                    MP.IdPlant AS [Value],
                    CONCAT(MP.Plant, ' - ', MP.Nama_Terminal) AS Label
                FROM MasterPlant MP
                JOIN MappingPosition POS ON MP.IdPlant = POS.IdPlant
                WHERE POS.IdPosition = @IdPosition";
            // query 3: query untuk semua plant
            const string query3 = @"
                SELECT DISTINCT
                    MP.IdPlant AS [Value],
                    CONCAT(MP.Plant, ' - ', MP.Nama_Terminal) AS Label
                FROM MasterPlant MP";
            string query;
            if (isModToday)
                query = query1;
            else 
            {
                bool useMappingPosition = (ulv is 1 or 2 or 5 or 6 or 7 or 4) || rule == 10;
                if (!useMappingPosition || ulv is -1) 
                {
                    // paksa user administrator tampil semua, tanpa memperhatikan rule
                    // tapi kalau administrator strict bisa OH, ganti aja ke if (!useMappingPosition || (isAdmin && !isOH))
                    query = query3;
                }
                else
                {
                    bool needStsFilter = ulv == 4
                        ? (rule == 12 || rule == 13) && !isHSSE
                        : (rule == 12 || (rule == 13 && !isPenyaluran)) && !isHSSE;
                    query = query2 + (needStsFilter ? " AND MP.JenisPlant = 'STS'" : "");
                }
            }
            var plants = DatabaseQueryHelper.ExecuteSelectListQuery<DropdownResponse>(
                query,
                reader => new DropdownResponse
                {
                    Value = reader["Value"] != DBNull.Value ? Convert.ToInt32(reader["Value"]) : 0,
                    Label = reader["Label"]?.ToString() ?? ""
                },
                parameters);
            return Json(new { success = true, data = plants, message = "" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, data = Array.Empty<DropdownResponse>(), message = ex.Message });
        }
    }
}
