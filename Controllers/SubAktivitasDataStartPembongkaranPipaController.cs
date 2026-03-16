namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStartPembongkaranPipaList/{id?}", Name = "SubAktivitasDataStartPembongkaranPipaList-SubAktivitasDataStartPembongkaranPipa-list")]
    [Route("Home/SubAktivitasDataStartPembongkaranPipaList/{id?}", Name = "SubAktivitasDataStartPembongkaranPipaList-SubAktivitasDataStartPembongkaranPipa-list-2")]
    public async Task<IActionResult> SubAktivitasDataStartPembongkaranPipaList()
    {
        // Create page object
        subAktivitasDataStartPembongkaranPipaList = new GLOBALS.SubAktivitasDataStartPembongkaranPipaList(this);
        subAktivitasDataStartPembongkaranPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStartPembongkaranPipaList.Run();
    }

    // edit
    [Route("SubAktivitasDataStartPembongkaranPipaEdit/{id?}", Name = "SubAktivitasDataStartPembongkaranPipaEdit-SubAktivitasDataStartPembongkaranPipa-edit")]
    [Route("Home/SubAktivitasDataStartPembongkaranPipaEdit/{id?}", Name = "SubAktivitasDataStartPembongkaranPipaEdit-SubAktivitasDataStartPembongkaranPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStartPembongkaranPipaEdit()
    {
        // Create page object
        subAktivitasDataStartPembongkaranPipaEdit = new GLOBALS.SubAktivitasDataStartPembongkaranPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStartPembongkaranPipaEdit.Run();
    }
}
