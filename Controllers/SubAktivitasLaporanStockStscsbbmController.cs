namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLaporanStockStscsbbmList/{id?}", Name = "SubAktivitasLaporanStockStscsbbmList-SubAktivitasLaporanStockSTSCSBBM-list")]
    [Route("Home/SubAktivitasLaporanStockStscsbbmList/{id?}", Name = "SubAktivitasLaporanStockStscsbbmList-SubAktivitasLaporanStockSTSCSBBM-list-2")]
    public async Task<IActionResult> SubAktivitasLaporanStockStscsbbmList()
    {
        // Create page object
        subAktivitasLaporanStockStscsbbmList = new GLOBALS.SubAktivitasLaporanStockStscsbbmList(this);
        subAktivitasLaporanStockStscsbbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLaporanStockStscsbbmList.Run();
    }

    // edit
    [Route("SubAktivitasLaporanStockStscsbbmEdit/{id?}", Name = "SubAktivitasLaporanStockStscsbbmEdit-SubAktivitasLaporanStockSTSCSBBM-edit")]
    [Route("Home/SubAktivitasLaporanStockStscsbbmEdit/{id?}", Name = "SubAktivitasLaporanStockStscsbbmEdit-SubAktivitasLaporanStockSTSCSBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasLaporanStockStscsbbmEdit()
    {
        // Create page object
        subAktivitasLaporanStockStscsbbmEdit = new GLOBALS.SubAktivitasLaporanStockStscsbbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLaporanStockStscsbbmEdit.Run();
    }
}
