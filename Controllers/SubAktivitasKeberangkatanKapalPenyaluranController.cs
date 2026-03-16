namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasKeberangkatanKapalPenyaluranList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranList-SubAktivitasKeberangkatanKapalPenyaluran-list")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenyaluranList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranList-SubAktivitasKeberangkatanKapalPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenyaluranList()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenyaluranList = new GLOBALS.SubAktivitasKeberangkatanKapalPenyaluranList(this);
        subAktivitasKeberangkatanKapalPenyaluranList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasKeberangkatanKapalPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasKeberangkatanKapalPenyaluranEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranEdit-SubAktivitasKeberangkatanKapalPenyaluran-edit")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenyaluranEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranEdit-SubAktivitasKeberangkatanKapalPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenyaluranEdit()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenyaluranEdit = new GLOBALS.SubAktivitasKeberangkatanKapalPenyaluranEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasKeberangkatanKapalPenyaluranEdit.Run();
    }
}
