namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataKapalStsPnrBbmList/{id?}", Name = "SubAktivitasDataKapalStsPnrBbmList-SubAktivitasDataKapalSTSPnrBBM-list")]
    [Route("Home/SubAktivitasDataKapalStsPnrBbmList/{id?}", Name = "SubAktivitasDataKapalStsPnrBbmList-SubAktivitasDataKapalSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasDataKapalStsPnrBbmList()
    {
        // Create page object
        subAktivitasDataKapalStsPnrBbmList = new GLOBALS.SubAktivitasDataKapalStsPnrBbmList(this);
        subAktivitasDataKapalStsPnrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataKapalStsPnrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasDataKapalStsPnrBbmEdit/{id?}", Name = "SubAktivitasDataKapalStsPnrBbmEdit-SubAktivitasDataKapalSTSPnrBBM-edit")]
    [Route("Home/SubAktivitasDataKapalStsPnrBbmEdit/{id?}", Name = "SubAktivitasDataKapalStsPnrBbmEdit-SubAktivitasDataKapalSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasDataKapalStsPnrBbmEdit()
    {
        // Create page object
        subAktivitasDataKapalStsPnrBbmEdit = new GLOBALS.SubAktivitasDataKapalStsPnrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataKapalStsPnrBbmEdit.Run();
    }
}
