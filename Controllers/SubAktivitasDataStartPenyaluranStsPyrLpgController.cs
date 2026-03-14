namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStartPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasDataStartPenyaluranStsPyrLpgList-SubAktivitasDataStartPenyaluranSTSPyrLPG-list")]
    [Route("Home/SubAktivitasDataStartPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasDataStartPenyaluranStsPyrLpgList-SubAktivitasDataStartPenyaluranSTSPyrLPG-list-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranStsPyrLpgList()
    {
        // Create page object
        subAktivitasDataStartPenyaluranStsPyrLpgList = new GLOBALS.SubAktivitasDataStartPenyaluranStsPyrLpgList(this);
        subAktivitasDataStartPenyaluranStsPyrLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasDataStartPenyaluranStsPyrLpgList.Run();
    }

    // edit
    [Route("SubAktivitasDataStartPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranStsPyrLpgEdit-SubAktivitasDataStartPenyaluranSTSPyrLPG-edit")]
    [Route("Home/SubAktivitasDataStartPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranStsPyrLpgEdit-SubAktivitasDataStartPenyaluranSTSPyrLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranStsPyrLpgEdit()
    {
        // Create page object
        subAktivitasDataStartPenyaluranStsPyrLpgEdit = new GLOBALS.SubAktivitasDataStartPenyaluranStsPyrLpgEdit(this);

        // Run the page
        return await subAktivitasDataStartPenyaluranStsPyrLpgEdit.Run();
    }
}
