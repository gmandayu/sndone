namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasKeberangkatanKapalPenyaluranLpgList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranLpgList-SubAktivitasKeberangkatanKapalPenyaluranLPG-list")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenyaluranLpgList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranLpgList-SubAktivitasKeberangkatanKapalPenyaluranLPG-list-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenyaluranLpgList()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenyaluranLpgList = new GLOBALS.SubAktivitasKeberangkatanKapalPenyaluranLpgList(this);
        subAktivitasKeberangkatanKapalPenyaluranLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasKeberangkatanKapalPenyaluranLpgList.Run();
    }

    // edit
    [Route("SubAktivitasKeberangkatanKapalPenyaluranLpgEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranLpgEdit-SubAktivitasKeberangkatanKapalPenyaluranLPG-edit")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenyaluranLpgEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranLpgEdit-SubAktivitasKeberangkatanKapalPenyaluranLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenyaluranLpgEdit()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenyaluranLpgEdit = new GLOBALS.SubAktivitasKeberangkatanKapalPenyaluranLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasKeberangkatanKapalPenyaluranLpgEdit.Run();
    }
}
