namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataKapalLpgList/{id?}", Name = "SubAktivitasDataKapalLpgList-SubAktivitasDataKapalLPG-list")]
    [Route("Home/SubAktivitasDataKapalLpgList/{id?}", Name = "SubAktivitasDataKapalLpgList-SubAktivitasDataKapalLPG-list-2")]
    public async Task<IActionResult> SubAktivitasDataKapalLpgList()
    {
        // Create page object
        subAktivitasDataKapalLpgList = new GLOBALS.SubAktivitasDataKapalLpgList(this);
        subAktivitasDataKapalLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataKapalLpgList.Run();
    }

    // edit
    [Route("SubAktivitasDataKapalLpgEdit/{id?}", Name = "SubAktivitasDataKapalLpgEdit-SubAktivitasDataKapalLPG-edit")]
    [Route("Home/SubAktivitasDataKapalLpgEdit/{id?}", Name = "SubAktivitasDataKapalLpgEdit-SubAktivitasDataKapalLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasDataKapalLpgEdit()
    {
        // Create page object
        subAktivitasDataKapalLpgEdit = new GLOBALS.SubAktivitasDataKapalLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataKapalLpgEdit.Run();
    }
}
