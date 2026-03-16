namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataMobilTangkiMtGateOutList/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateOutList-SubAktivitasDataMobilTangkiMTGateOut-list")]
    [Route("Home/SubAktivitasDataMobilTangkiMtGateOutList/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateOutList-SubAktivitasDataMobilTangkiMTGateOut-list-2")]
    public async Task<IActionResult> SubAktivitasDataMobilTangkiMtGateOutList()
    {
        // Create page object
        subAktivitasDataMobilTangkiMtGateOutList = new GLOBALS.SubAktivitasDataMobilTangkiMtGateOutList(this);
        subAktivitasDataMobilTangkiMtGateOutList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataMobilTangkiMtGateOutList.Run();
    }

    // edit
    [Route("SubAktivitasDataMobilTangkiMtGateOutEdit/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateOutEdit-SubAktivitasDataMobilTangkiMTGateOut-edit")]
    [Route("Home/SubAktivitasDataMobilTangkiMtGateOutEdit/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateOutEdit-SubAktivitasDataMobilTangkiMTGateOut-edit-2")]
    public async Task<IActionResult> SubAktivitasDataMobilTangkiMtGateOutEdit()
    {
        // Create page object
        subAktivitasDataMobilTangkiMtGateOutEdit = new GLOBALS.SubAktivitasDataMobilTangkiMtGateOutEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataMobilTangkiMtGateOutEdit.Run();
    }
}
