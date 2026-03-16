namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStopPenyaluranPipaList/{id?}", Name = "SubAktivitasDataStopPenyaluranPipaList-SubAktivitasDataStopPenyaluranPipa-list")]
    [Route("Home/SubAktivitasDataStopPenyaluranPipaList/{id?}", Name = "SubAktivitasDataStopPenyaluranPipaList-SubAktivitasDataStopPenyaluranPipa-list-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranPipaList()
    {
        // Create page object
        subAktivitasDataStopPenyaluranPipaList = new GLOBALS.SubAktivitasDataStopPenyaluranPipaList(this);
        subAktivitasDataStopPenyaluranPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPenyaluranPipaList.Run();
    }

    // edit
    [Route("SubAktivitasDataStopPenyaluranPipaEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranPipaEdit-SubAktivitasDataStopPenyaluranPipa-edit")]
    [Route("Home/SubAktivitasDataStopPenyaluranPipaEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranPipaEdit-SubAktivitasDataStopPenyaluranPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranPipaEdit()
    {
        // Create page object
        subAktivitasDataStopPenyaluranPipaEdit = new GLOBALS.SubAktivitasDataStopPenyaluranPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPenyaluranPipaEdit.Run();
    }
}
