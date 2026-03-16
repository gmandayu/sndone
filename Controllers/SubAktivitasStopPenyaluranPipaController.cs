namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasStopPenyaluranPipaList/{id?}", Name = "SubAktivitasStopPenyaluranPipaList-SubAktivitasStopPenyaluranPipa-list")]
    [Route("Home/SubAktivitasStopPenyaluranPipaList/{id?}", Name = "SubAktivitasStopPenyaluranPipaList-SubAktivitasStopPenyaluranPipa-list-2")]
    public async Task<IActionResult> SubAktivitasStopPenyaluranPipaList()
    {
        // Create page object
        subAktivitasStopPenyaluranPipaList = new GLOBALS.SubAktivitasStopPenyaluranPipaList(this);
        subAktivitasStopPenyaluranPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasStopPenyaluranPipaList.Run();
    }

    // edit
    [Route("SubAktivitasStopPenyaluranPipaEdit/{id?}", Name = "SubAktivitasStopPenyaluranPipaEdit-SubAktivitasStopPenyaluranPipa-edit")]
    [Route("Home/SubAktivitasStopPenyaluranPipaEdit/{id?}", Name = "SubAktivitasStopPenyaluranPipaEdit-SubAktivitasStopPenyaluranPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasStopPenyaluranPipaEdit()
    {
        // Create page object
        subAktivitasStopPenyaluranPipaEdit = new GLOBALS.SubAktivitasStopPenyaluranPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasStopPenyaluranPipaEdit.Run();
    }
}
