namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStopPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasDataStopPenyaluranStsPyrBbmList-SubAktivitasDataStopPenyaluranSTSPyrBBM-list")]
    [Route("Home/SubAktivitasDataStopPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasDataStopPenyaluranStsPyrBbmList-SubAktivitasDataStopPenyaluranSTSPyrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranStsPyrBbmList()
    {
        // Create page object
        subAktivitasDataStopPenyaluranStsPyrBbmList = new GLOBALS.SubAktivitasDataStopPenyaluranStsPyrBbmList(this);
        subAktivitasDataStopPenyaluranStsPyrBbmList.Cache = _cache;

        // Run the page
        return await subAktivitasDataStopPenyaluranStsPyrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasDataStopPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranStsPyrBbmEdit-SubAktivitasDataStopPenyaluranSTSPyrBBM-edit")]
    [Route("Home/SubAktivitasDataStopPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranStsPyrBbmEdit-SubAktivitasDataStopPenyaluranSTSPyrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranStsPyrBbmEdit()
    {
        // Create page object
        subAktivitasDataStopPenyaluranStsPyrBbmEdit = new GLOBALS.SubAktivitasDataStopPenyaluranStsPyrBbmEdit(this);

        // Run the page
        return await subAktivitasDataStopPenyaluranStsPyrBbmEdit.Run();
    }
}
