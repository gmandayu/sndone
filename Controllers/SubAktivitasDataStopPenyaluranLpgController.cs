namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStopPenyaluranLpgList/{id?}", Name = "SubAktivitasDataStopPenyaluranLpgList-SubAktivitasDataStopPenyaluranLPG-list")]
    [Route("Home/SubAktivitasDataStopPenyaluranLpgList/{id?}", Name = "SubAktivitasDataStopPenyaluranLpgList-SubAktivitasDataStopPenyaluranLPG-list-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranLpgList()
    {
        // Create page object
        subAktivitasDataStopPenyaluranLpgList = new GLOBALS.SubAktivitasDataStopPenyaluranLpgList(this);
        subAktivitasDataStopPenyaluranLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPenyaluranLpgList.Run();
    }

    // edit
    [Route("SubAktivitasDataStopPenyaluranLpgEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranLpgEdit-SubAktivitasDataStopPenyaluranLPG-edit")]
    [Route("Home/SubAktivitasDataStopPenyaluranLpgEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranLpgEdit-SubAktivitasDataStopPenyaluranLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranLpgEdit()
    {
        // Create page object
        subAktivitasDataStopPenyaluranLpgEdit = new GLOBALS.SubAktivitasDataStopPenyaluranLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPenyaluranLpgEdit.Run();
    }
}
