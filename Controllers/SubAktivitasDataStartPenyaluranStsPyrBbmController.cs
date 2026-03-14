namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStartPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasDataStartPenyaluranStsPyrBbmList-SubAktivitasDataStartPenyaluranSTSPyrBBM-list")]
    [Route("Home/SubAktivitasDataStartPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasDataStartPenyaluranStsPyrBbmList-SubAktivitasDataStartPenyaluranSTSPyrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranStsPyrBbmList()
    {
        // Create page object
        subAktivitasDataStartPenyaluranStsPyrBbmList = new GLOBALS.SubAktivitasDataStartPenyaluranStsPyrBbmList(this);
        subAktivitasDataStartPenyaluranStsPyrBbmList.Cache = _cache;

        // Run the page
        return await subAktivitasDataStartPenyaluranStsPyrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasDataStartPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranStsPyrBbmEdit-SubAktivitasDataStartPenyaluranSTSPyrBBM-edit")]
    [Route("Home/SubAktivitasDataStartPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranStsPyrBbmEdit-SubAktivitasDataStartPenyaluranSTSPyrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranStsPyrBbmEdit()
    {
        // Create page object
        subAktivitasDataStartPenyaluranStsPyrBbmEdit = new GLOBALS.SubAktivitasDataStartPenyaluranStsPyrBbmEdit(this);

        // Run the page
        return await subAktivitasDataStartPenyaluranStsPyrBbmEdit.Run();
    }
}
