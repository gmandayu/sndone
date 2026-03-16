namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStopPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasDataStopPenyaluranStsPyrLpgList-SubAktivitasDataStopPenyaluranSTSPyrLPG-list")]
    [Route("Home/SubAktivitasDataStopPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasDataStopPenyaluranStsPyrLpgList-SubAktivitasDataStopPenyaluranSTSPyrLPG-list-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranStsPyrLpgList()
    {
        // Create page object
        subAktivitasDataStopPenyaluranStsPyrLpgList = new GLOBALS.SubAktivitasDataStopPenyaluranStsPyrLpgList(this);
        subAktivitasDataStopPenyaluranStsPyrLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPenyaluranStsPyrLpgList.Run();
    }

    // edit
    [Route("SubAktivitasDataStopPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranStsPyrLpgEdit-SubAktivitasDataStopPenyaluranSTSPyrLPG-edit")]
    [Route("Home/SubAktivitasDataStopPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranStsPyrLpgEdit-SubAktivitasDataStopPenyaluranSTSPyrLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranStsPyrLpgEdit()
    {
        // Create page object
        subAktivitasDataStopPenyaluranStsPyrLpgEdit = new GLOBALS.SubAktivitasDataStopPenyaluranStsPyrLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPenyaluranStsPyrLpgEdit.Run();
    }
}
