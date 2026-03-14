namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataMobilTangkiMtGateInList/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateInList-SubAktivitasDataMobilTangkiMTGateIn-list")]
    [Route("Home/SubAktivitasDataMobilTangkiMtGateInList/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateInList-SubAktivitasDataMobilTangkiMTGateIn-list-2")]
    public async Task<IActionResult> SubAktivitasDataMobilTangkiMtGateInList()
    {
        // Create page object
        subAktivitasDataMobilTangkiMtGateInList = new GLOBALS.SubAktivitasDataMobilTangkiMtGateInList(this);
        subAktivitasDataMobilTangkiMtGateInList.Cache = _cache;

        // Run the page
        return await subAktivitasDataMobilTangkiMtGateInList.Run();
    }

    // edit
    [Route("SubAktivitasDataMobilTangkiMtGateInEdit/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateInEdit-SubAktivitasDataMobilTangkiMTGateIn-edit")]
    [Route("Home/SubAktivitasDataMobilTangkiMtGateInEdit/{id?}", Name = "SubAktivitasDataMobilTangkiMtGateInEdit-SubAktivitasDataMobilTangkiMTGateIn-edit-2")]
    public async Task<IActionResult> SubAktivitasDataMobilTangkiMtGateInEdit()
    {
        // Create page object
        subAktivitasDataMobilTangkiMtGateInEdit = new GLOBALS.SubAktivitasDataMobilTangkiMtGateInEdit(this);

        // Run the page
        return await subAktivitasDataMobilTangkiMtGateInEdit.Run();
    }
}
