namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookMonitoringStockPipaList/{id?}", Name = "SubAktivitasLogbookMonitoringStockPipaList-SubAktivitasLogbookMonitoringStockPipa-list")]
    [Route("Home/SubAktivitasLogbookMonitoringStockPipaList/{id?}", Name = "SubAktivitasLogbookMonitoringStockPipaList-SubAktivitasLogbookMonitoringStockPipa-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookMonitoringStockPipaList()
    {
        // Create page object
        subAktivitasLogbookMonitoringStockPipaList = new GLOBALS.SubAktivitasLogbookMonitoringStockPipaList(this);
        subAktivitasLogbookMonitoringStockPipaList.Cache = _cache;

        // Run the page
        return await subAktivitasLogbookMonitoringStockPipaList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookMonitoringStockPipaEdit/{id?}", Name = "SubAktivitasLogbookMonitoringStockPipaEdit-SubAktivitasLogbookMonitoringStockPipa-edit")]
    [Route("Home/SubAktivitasLogbookMonitoringStockPipaEdit/{id?}", Name = "SubAktivitasLogbookMonitoringStockPipaEdit-SubAktivitasLogbookMonitoringStockPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookMonitoringStockPipaEdit()
    {
        // Create page object
        subAktivitasLogbookMonitoringStockPipaEdit = new GLOBALS.SubAktivitasLogbookMonitoringStockPipaEdit(this);

        // Run the page
        return await subAktivitasLogbookMonitoringStockPipaEdit.Run();
    }
}
