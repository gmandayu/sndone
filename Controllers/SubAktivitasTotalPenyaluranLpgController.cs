namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasTotalPenyaluranLpgList/{id?}", Name = "SubAktivitasTotalPenyaluranLpgList-SubAktivitasTotalPenyaluranLPG-list")]
    [Route("Home/SubAktivitasTotalPenyaluranLpgList/{id?}", Name = "SubAktivitasTotalPenyaluranLpgList-SubAktivitasTotalPenyaluranLPG-list-2")]
    public async Task<IActionResult> SubAktivitasTotalPenyaluranLpgList()
    {
        // Create page object
        subAktivitasTotalPenyaluranLpgList = new GLOBALS.SubAktivitasTotalPenyaluranLpgList(this);
        subAktivitasTotalPenyaluranLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasTotalPenyaluranLpgList.Run();
    }

    // edit
    [Route("SubAktivitasTotalPenyaluranLpgEdit/{id?}", Name = "SubAktivitasTotalPenyaluranLpgEdit-SubAktivitasTotalPenyaluranLPG-edit")]
    [Route("Home/SubAktivitasTotalPenyaluranLpgEdit/{id?}", Name = "SubAktivitasTotalPenyaluranLpgEdit-SubAktivitasTotalPenyaluranLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasTotalPenyaluranLpgEdit()
    {
        // Create page object
        subAktivitasTotalPenyaluranLpgEdit = new GLOBALS.SubAktivitasTotalPenyaluranLpgEdit(this);

        // Run the page
        return await subAktivitasTotalPenyaluranLpgEdit.Run();
    }
}
