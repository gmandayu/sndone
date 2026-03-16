namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasInputLogbookPenyaluranPipaBackupList/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupList-SubaktivitasInputLogbookPenyaluranPipa_Backup-list")]
    [Route("Home/SubaktivitasInputLogbookPenyaluranPipaBackupList/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupList-SubaktivitasInputLogbookPenyaluranPipa_Backup-list-2")]
    public async Task<IActionResult> SubaktivitasInputLogbookPenyaluranPipaBackupList()
    {
        // Create page object
        subaktivitasInputLogbookPenyaluranPipaBackupList = new GLOBALS.SubaktivitasInputLogbookPenyaluranPipaBackupList(this);
        subaktivitasInputLogbookPenyaluranPipaBackupList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasInputLogbookPenyaluranPipaBackupList.Run();
    }

    // add
    [Route("SubaktivitasInputLogbookPenyaluranPipaBackupAdd/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupAdd-SubaktivitasInputLogbookPenyaluranPipa_Backup-add")]
    [Route("Home/SubaktivitasInputLogbookPenyaluranPipaBackupAdd/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupAdd-SubaktivitasInputLogbookPenyaluranPipa_Backup-add-2")]
    public async Task<IActionResult> SubaktivitasInputLogbookPenyaluranPipaBackupAdd()
    {
        // Create page object
        subaktivitasInputLogbookPenyaluranPipaBackupAdd = new GLOBALS.SubaktivitasInputLogbookPenyaluranPipaBackupAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasInputLogbookPenyaluranPipaBackupAdd.Run();
    }

    // view
    [Route("SubaktivitasInputLogbookPenyaluranPipaBackupView/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupView-SubaktivitasInputLogbookPenyaluranPipa_Backup-view")]
    [Route("Home/SubaktivitasInputLogbookPenyaluranPipaBackupView/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupView-SubaktivitasInputLogbookPenyaluranPipa_Backup-view-2")]
    public async Task<IActionResult> SubaktivitasInputLogbookPenyaluranPipaBackupView()
    {
        // Create page object
        subaktivitasInputLogbookPenyaluranPipaBackupView = new GLOBALS.SubaktivitasInputLogbookPenyaluranPipaBackupView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasInputLogbookPenyaluranPipaBackupView.Run();
    }

    // edit
    [Route("SubaktivitasInputLogbookPenyaluranPipaBackupEdit/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupEdit-SubaktivitasInputLogbookPenyaluranPipa_Backup-edit")]
    [Route("Home/SubaktivitasInputLogbookPenyaluranPipaBackupEdit/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupEdit-SubaktivitasInputLogbookPenyaluranPipa_Backup-edit-2")]
    public async Task<IActionResult> SubaktivitasInputLogbookPenyaluranPipaBackupEdit()
    {
        // Create page object
        subaktivitasInputLogbookPenyaluranPipaBackupEdit = new GLOBALS.SubaktivitasInputLogbookPenyaluranPipaBackupEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasInputLogbookPenyaluranPipaBackupEdit.Run();
    }

    // delete
    [Route("SubaktivitasInputLogbookPenyaluranPipaBackupDelete/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupDelete-SubaktivitasInputLogbookPenyaluranPipa_Backup-delete")]
    [Route("Home/SubaktivitasInputLogbookPenyaluranPipaBackupDelete/{id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaBackupDelete-SubaktivitasInputLogbookPenyaluranPipa_Backup-delete-2")]
    public async Task<IActionResult> SubaktivitasInputLogbookPenyaluranPipaBackupDelete()
    {
        // Create page object
        subaktivitasInputLogbookPenyaluranPipaBackupDelete = new GLOBALS.SubaktivitasInputLogbookPenyaluranPipaBackupDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasInputLogbookPenyaluranPipaBackupDelete.Run();
    }
}
