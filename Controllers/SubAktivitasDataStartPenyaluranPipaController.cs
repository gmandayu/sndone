namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStartPenyaluranPipaList/{id?}", Name = "SubAktivitasDataStartPenyaluranPipaList-SubAktivitasDataStartPenyaluranPipa-list")]
    [Route("Home/SubAktivitasDataStartPenyaluranPipaList/{id?}", Name = "SubAktivitasDataStartPenyaluranPipaList-SubAktivitasDataStartPenyaluranPipa-list-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranPipaList()
    {
        // Create page object
        subAktivitasDataStartPenyaluranPipaList = new GLOBALS.SubAktivitasDataStartPenyaluranPipaList(this);
        subAktivitasDataStartPenyaluranPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStartPenyaluranPipaList.Run();
    }

    // edit
    [Route("SubAktivitasDataStartPenyaluranPipaEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranPipaEdit-SubAktivitasDataStartPenyaluranPipa-edit")]
    [Route("Home/SubAktivitasDataStartPenyaluranPipaEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranPipaEdit-SubAktivitasDataStartPenyaluranPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranPipaEdit()
    {
        // Create page object
        subAktivitasDataStartPenyaluranPipaEdit = new GLOBALS.SubAktivitasDataStartPenyaluranPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStartPenyaluranPipaEdit.Run();
    }
}
