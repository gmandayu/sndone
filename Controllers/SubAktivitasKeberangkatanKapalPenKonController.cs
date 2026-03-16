namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasKeberangkatanKapalPenKonList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenKonList-SubAktivitasKeberangkatanKapalPenKon-list")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenKonList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenKonList-SubAktivitasKeberangkatanKapalPenKon-list-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenKonList()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenKonList = new GLOBALS.SubAktivitasKeberangkatanKapalPenKonList(this);
        subAktivitasKeberangkatanKapalPenKonList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasKeberangkatanKapalPenKonList.Run();
    }

    // edit
    [Route("SubAktivitasKeberangkatanKapalPenKonEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenKonEdit-SubAktivitasKeberangkatanKapalPenKon-edit")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenKonEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenKonEdit-SubAktivitasKeberangkatanKapalPenKon-edit-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenKonEdit()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenKonEdit = new GLOBALS.SubAktivitasKeberangkatanKapalPenKonEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasKeberangkatanKapalPenKonEdit.Run();
    }
}
