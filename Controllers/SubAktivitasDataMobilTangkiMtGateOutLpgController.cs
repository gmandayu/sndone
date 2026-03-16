namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataMobilTangkiMtGateOutLpgList/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateOutLpgList-SubAktivitasDataMobilTangkiMTGateOutLPG-list")]
    [Route("Home/SubAktivitasDataMobilTangkiMtGateOutLpgList/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateOutLpgList-SubAktivitasDataMobilTangkiMTGateOutLPG-list-2")]
    public async Task<IActionResult> SubAktivitasDataMobilTangkiMtGateOutLpgList()
    {
        // Create page object
        subAktivitasDataMobilTangkiMtGateOutLpgList = new GLOBALS.SubAktivitasDataMobilTangkiMtGateOutLpgList(this);
        subAktivitasDataMobilTangkiMtGateOutLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataMobilTangkiMtGateOutLpgList.Run();
    }

    // edit
    [Route("SubAktivitasDataMobilTangkiMtGateOutLpgEdit/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateOutLpgEdit-SubAktivitasDataMobilTangkiMTGateOutLPG-edit")]
    [Route("Home/SubAktivitasDataMobilTangkiMtGateOutLpgEdit/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateOutLpgEdit-SubAktivitasDataMobilTangkiMTGateOutLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasDataMobilTangkiMtGateOutLpgEdit()
    {
        // Create page object
        subAktivitasDataMobilTangkiMtGateOutLpgEdit = new GLOBALS.SubAktivitasDataMobilTangkiMtGateOutLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataMobilTangkiMtGateOutLpgEdit.Run();
    }
}
