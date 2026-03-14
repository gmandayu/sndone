namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookMonitoringStockList/{id?}", Name = "SubAktivitasLogbookMonitoringStockList-SubAktivitasLogbookMonitoringStock-list")]
    [Route("Home/SubAktivitasLogbookMonitoringStockList/{id?}", Name = "SubAktivitasLogbookMonitoringStockList-SubAktivitasLogbookMonitoringStock-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookMonitoringStockList()
    {
        // Create page object
        subAktivitasLogbookMonitoringStockList = new GLOBALS.SubAktivitasLogbookMonitoringStockList(this);
        subAktivitasLogbookMonitoringStockList.Cache = _cache;

        // Run the page
        return await subAktivitasLogbookMonitoringStockList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookMonitoringStockEdit/{id?}", Name = "SubAktivitasLogbookMonitoringStockEdit-SubAktivitasLogbookMonitoringStock-edit")]
    [Route("Home/SubAktivitasLogbookMonitoringStockEdit/{id?}", Name = "SubAktivitasLogbookMonitoringStockEdit-SubAktivitasLogbookMonitoringStock-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookMonitoringStockEdit()
    {
        // Create page object
        subAktivitasLogbookMonitoringStockEdit = new GLOBALS.SubAktivitasLogbookMonitoringStockEdit(this);

        // Run the page
        return await subAktivitasLogbookMonitoringStockEdit.Run();
    }
}
