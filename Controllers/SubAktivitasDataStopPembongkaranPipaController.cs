namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStopPembongkaranPipaList/{id?}", Name = "SubAktivitasDataStopPembongkaranPipaList-SubAktivitasDataStopPembongkaranPipa-list")]
    [Route("Home/SubAktivitasDataStopPembongkaranPipaList/{id?}", Name = "SubAktivitasDataStopPembongkaranPipaList-SubAktivitasDataStopPembongkaranPipa-list-2")]
    public async Task<IActionResult> SubAktivitasDataStopPembongkaranPipaList()
    {
        // Create page object
        subAktivitasDataStopPembongkaranPipaList = new GLOBALS.SubAktivitasDataStopPembongkaranPipaList(this);
        subAktivitasDataStopPembongkaranPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPembongkaranPipaList.Run();
    }

    // edit
    [Route("SubAktivitasDataStopPembongkaranPipaEdit/{id?}", Name = "SubAktivitasDataStopPembongkaranPipaEdit-SubAktivitasDataStopPembongkaranPipa-edit")]
    [Route("Home/SubAktivitasDataStopPembongkaranPipaEdit/{id?}", Name = "SubAktivitasDataStopPembongkaranPipaEdit-SubAktivitasDataStopPembongkaranPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStopPembongkaranPipaEdit()
    {
        // Create page object
        subAktivitasDataStopPembongkaranPipaEdit = new GLOBALS.SubAktivitasDataStopPembongkaranPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPembongkaranPipaEdit.Run();
    }
}
