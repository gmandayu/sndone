namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList-SubAktivitasKeberangkatanKapalPenyaluranSTSPyrBBM-list")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList-SubAktivitasKeberangkatanKapalPenyaluranSTSPyrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList = new GLOBALS.SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList(this);
        subAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasKeberangkatanKapalPenyaluranStsPyrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmEdit-SubAktivitasKeberangkatanKapalPenyaluranSTSPyrBBM-edit")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmEdit-SubAktivitasKeberangkatanKapalPenyaluranSTSPyrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmEdit()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenyaluranStsPyrBbmEdit = new GLOBALS.SubAktivitasKeberangkatanKapalPenyaluranStsPyrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasKeberangkatanKapalPenyaluranStsPyrBbmEdit.Run();
    }
}
