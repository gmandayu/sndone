namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLaporanStockList/{id?}", Name = "SubAktivitasLaporanStockList-SubAktivitasLaporanStock-list")]
    [Route("Home/SubAktivitasLaporanStockList/{id?}", Name = "SubAktivitasLaporanStockList-SubAktivitasLaporanStock-list-2")]
    public async Task<IActionResult> SubAktivitasLaporanStockList()
    {
        // Create page object
        subAktivitasLaporanStockList = new GLOBALS.SubAktivitasLaporanStockList(this);
        subAktivitasLaporanStockList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLaporanStockList.Run();
    }

    // edit
    [Route("SubAktivitasLaporanStockEdit/{id?}", Name = "SubAktivitasLaporanStockEdit-SubAktivitasLaporanStock-edit")]
    [Route("Home/SubAktivitasLaporanStockEdit/{id?}", Name = "SubAktivitasLaporanStockEdit-SubAktivitasLaporanStock-edit-2")]
    public async Task<IActionResult> SubAktivitasLaporanStockEdit()
    {
        // Create page object
        subAktivitasLaporanStockEdit = new GLOBALS.SubAktivitasLaporanStockEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLaporanStockEdit.Run();
    }
}
