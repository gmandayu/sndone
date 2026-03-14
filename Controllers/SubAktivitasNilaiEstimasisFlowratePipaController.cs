namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiEstimasisFlowratePipaList/{id?}", Name = "SubAktivitasNilaiEstimasisFlowratePipaList-SubAktivitasNilaiEstimasisFlowratePipa-list")]
    [Route("Home/SubAktivitasNilaiEstimasisFlowratePipaList/{id?}", Name = "SubAktivitasNilaiEstimasisFlowratePipaList-SubAktivitasNilaiEstimasisFlowratePipa-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiEstimasisFlowratePipaList()
    {
        // Create page object
        subAktivitasNilaiEstimasisFlowratePipaList = new GLOBALS.SubAktivitasNilaiEstimasisFlowratePipaList(this);
        subAktivitasNilaiEstimasisFlowratePipaList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiEstimasisFlowratePipaList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiEstimasisFlowratePipaEdit/{id?}", Name = "SubAktivitasNilaiEstimasisFlowratePipaEdit-SubAktivitasNilaiEstimasisFlowratePipa-edit")]
    [Route("Home/SubAktivitasNilaiEstimasisFlowratePipaEdit/{id?}", Name = "SubAktivitasNilaiEstimasisFlowratePipaEdit-SubAktivitasNilaiEstimasisFlowratePipa-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiEstimasisFlowratePipaEdit()
    {
        // Create page object
        subAktivitasNilaiEstimasisFlowratePipaEdit = new GLOBALS.SubAktivitasNilaiEstimasisFlowratePipaEdit(this);

        // Run the page
        return await subAktivitasNilaiEstimasisFlowratePipaEdit.Run();
    }
}
