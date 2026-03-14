namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStartPenyaluranLpgList/{id?}", Name = "SubAktivitasDataStartPenyaluranLpgList-SubAktivitasDataStartPenyaluranLPG-list")]
    [Route("Home/SubAktivitasDataStartPenyaluranLpgList/{id?}", Name = "SubAktivitasDataStartPenyaluranLpgList-SubAktivitasDataStartPenyaluranLPG-list-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranLpgList()
    {
        // Create page object
        subAktivitasDataStartPenyaluranLpgList = new GLOBALS.SubAktivitasDataStartPenyaluranLpgList(this);
        subAktivitasDataStartPenyaluranLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasDataStartPenyaluranLpgList.Run();
    }

    // edit
    [Route("SubAktivitasDataStartPenyaluranLpgEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranLpgEdit-SubAktivitasDataStartPenyaluranLPG-edit")]
    [Route("Home/SubAktivitasDataStartPenyaluranLpgEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranLpgEdit-SubAktivitasDataStartPenyaluranLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranLpgEdit()
    {
        // Create page object
        subAktivitasDataStartPenyaluranLpgEdit = new GLOBALS.SubAktivitasDataStartPenyaluranLpgEdit(this);

        // Run the page
        return await subAktivitasDataStartPenyaluranLpgEdit.Run();
    }
}
