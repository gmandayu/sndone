namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputMonitoringStockStsPymSbbmList/{id?}", Name = "SubAktivitasFormInputMonitoringStockStsPymSbbmList-SubAktivitasFormInputMonitoringStockSTSPymSBBM-list")]
    [Route("Home/SubAktivitasFormInputMonitoringStockStsPymSbbmList/{id?}", Name = "SubAktivitasFormInputMonitoringStockStsPymSbbmList-SubAktivitasFormInputMonitoringStockSTSPymSBBM-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputMonitoringStockStsPymSbbmList()
    {
        // Create page object
        subAktivitasFormInputMonitoringStockStsPymSbbmList = new GLOBALS.SubAktivitasFormInputMonitoringStockStsPymSbbmList(this);
        subAktivitasFormInputMonitoringStockStsPymSbbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputMonitoringStockStsPymSbbmList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputMonitoringStockStsPymSbbmEdit/{id?}", Name = "SubAktivitasFormInputMonitoringStockStsPymSbbmEdit-SubAktivitasFormInputMonitoringStockSTSPymSBBM-edit")]
    [Route("Home/SubAktivitasFormInputMonitoringStockStsPymSbbmEdit/{id?}", Name = "SubAktivitasFormInputMonitoringStockStsPymSbbmEdit-SubAktivitasFormInputMonitoringStockSTSPymSBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputMonitoringStockStsPymSbbmEdit()
    {
        // Create page object
        subAktivitasFormInputMonitoringStockStsPymSbbmEdit = new GLOBALS.SubAktivitasFormInputMonitoringStockStsPymSbbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputMonitoringStockStsPymSbbmEdit.Run();
    }
}
