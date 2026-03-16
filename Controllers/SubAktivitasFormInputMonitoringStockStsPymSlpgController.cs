namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputMonitoringStockStsPymSlpgList/{id?}", Name = "SubAktivitasFormInputMonitoringStockStsPymSlpgList-SubAktivitasFormInputMonitoringStockSTSPymSLPG-list")]
    [Route("Home/SubAktivitasFormInputMonitoringStockStsPymSlpgList/{id?}", Name = "SubAktivitasFormInputMonitoringStockStsPymSlpgList-SubAktivitasFormInputMonitoringStockSTSPymSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputMonitoringStockStsPymSlpgList()
    {
        // Create page object
        subAktivitasFormInputMonitoringStockStsPymSlpgList = new GLOBALS.SubAktivitasFormInputMonitoringStockStsPymSlpgList(this);
        subAktivitasFormInputMonitoringStockStsPymSlpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputMonitoringStockStsPymSlpgList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputMonitoringStockStsPymSlpgEdit/{id?}", Name = "SubAktivitasFormInputMonitoringStockStsPymSlpgEdit-SubAktivitasFormInputMonitoringStockSTSPymSLPG-edit")]
    [Route("Home/SubAktivitasFormInputMonitoringStockStsPymSlpgEdit/{id?}", Name = "SubAktivitasFormInputMonitoringStockStsPymSlpgEdit-SubAktivitasFormInputMonitoringStockSTSPymSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputMonitoringStockStsPymSlpgEdit()
    {
        // Create page object
        subAktivitasFormInputMonitoringStockStsPymSlpgEdit = new GLOBALS.SubAktivitasFormInputMonitoringStockStsPymSlpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputMonitoringStockStsPymSlpgEdit.Run();
    }
}
