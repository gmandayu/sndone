namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasPengecekanMtList/{id?}", Name = "SubAktivitasPengecekanMtList-SubAktivitasPengecekanMT-list")]
    [Route("Home/SubAktivitasPengecekanMtList/{id?}", Name = "SubAktivitasPengecekanMtList-SubAktivitasPengecekanMT-list-2")]
    public async Task<IActionResult> SubAktivitasPengecekanMtList()
    {
        // Create page object
        subAktivitasPengecekanMtList = new GLOBALS.SubAktivitasPengecekanMtList(this);
        subAktivitasPengecekanMtList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasPengecekanMtList.Run();
    }

    // edit
    [Route("SubAktivitasPengecekanMtEdit/{id?}", Name = "SubAktivitasPengecekanMtEdit-SubAktivitasPengecekanMT-edit")]
    [Route("Home/SubAktivitasPengecekanMtEdit/{id?}", Name = "SubAktivitasPengecekanMtEdit-SubAktivitasPengecekanMT-edit-2")]
    public async Task<IActionResult> SubAktivitasPengecekanMtEdit()
    {
        // Create page object
        subAktivitasPengecekanMtEdit = new GLOBALS.SubAktivitasPengecekanMtEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasPengecekanMtEdit.Run();
    }
}
