namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputDataKapalStsPyrBbmList/{id?}", Name = "SubAktivitasInputDataKapalStsPyrBbmList-SubAktivitasInputDataKapalSTSPyrBBM-list")]
    [Route("Home/SubAktivitasInputDataKapalStsPyrBbmList/{id?}", Name = "SubAktivitasInputDataKapalStsPyrBbmList-SubAktivitasInputDataKapalSTSPyrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasInputDataKapalStsPyrBbmList()
    {
        // Create page object
        subAktivitasInputDataKapalStsPyrBbmList = new GLOBALS.SubAktivitasInputDataKapalStsPyrBbmList(this);
        subAktivitasInputDataKapalStsPyrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasInputDataKapalStsPyrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasInputDataKapalStsPyrBbmEdit/{id?}", Name = "SubAktivitasInputDataKapalStsPyrBbmEdit-SubAktivitasInputDataKapalSTSPyrBBM-edit")]
    [Route("Home/SubAktivitasInputDataKapalStsPyrBbmEdit/{id?}", Name = "SubAktivitasInputDataKapalStsPyrBbmEdit-SubAktivitasInputDataKapalSTSPyrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasInputDataKapalStsPyrBbmEdit()
    {
        // Create page object
        subAktivitasInputDataKapalStsPyrBbmEdit = new GLOBALS.SubAktivitasInputDataKapalStsPyrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasInputDataKapalStsPyrBbmEdit.Run();
    }
}
