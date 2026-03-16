namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataMobilTangkiMtGateInLpgList/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateInLpgList-SubAktivitasDataMobilTangkiMTGateInLPG-list")]
    [Route("Home/SubAktivitasDataMobilTangkiMtGateInLpgList/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateInLpgList-SubAktivitasDataMobilTangkiMTGateInLPG-list-2")]
    public async Task<IActionResult> SubAktivitasDataMobilTangkiMtGateInLpgList()
    {
        // Create page object
        subAktivitasDataMobilTangkiMtGateInLpgList = new GLOBALS.SubAktivitasDataMobilTangkiMtGateInLpgList(this);
        subAktivitasDataMobilTangkiMtGateInLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataMobilTangkiMtGateInLpgList.Run();
    }

    // edit
    [Route("SubAktivitasDataMobilTangkiMtGateInLpgEdit/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateInLpgEdit-SubAktivitasDataMobilTangkiMTGateInLPG-edit")]
    [Route("Home/SubAktivitasDataMobilTangkiMtGateInLpgEdit/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateInLpgEdit-SubAktivitasDataMobilTangkiMTGateInLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasDataMobilTangkiMtGateInLpgEdit()
    {
        // Create page object
        subAktivitasDataMobilTangkiMtGateInLpgEdit = new GLOBALS.SubAktivitasDataMobilTangkiMtGateInLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataMobilTangkiMtGateInLpgEdit.Run();
    }
}
