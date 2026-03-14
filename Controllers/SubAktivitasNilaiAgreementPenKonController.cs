namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiAgreementPenKonList/{id?}", Name = "SubAktivitasNilaiAgreementPenKonList-SubAktivitasNilaiAgreementPenKon-list")]
    [Route("Home/SubAktivitasNilaiAgreementPenKonList/{id?}", Name = "SubAktivitasNilaiAgreementPenKonList-SubAktivitasNilaiAgreementPenKon-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenKonList()
    {
        // Create page object
        subAktivitasNilaiAgreementPenKonList = new GLOBALS.SubAktivitasNilaiAgreementPenKonList(this);
        subAktivitasNilaiAgreementPenKonList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiAgreementPenKonList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiAgreementPenKonEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenKonEdit-SubAktivitasNilaiAgreementPenKon-edit")]
    [Route("Home/SubAktivitasNilaiAgreementPenKonEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenKonEdit-SubAktivitasNilaiAgreementPenKon-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenKonEdit()
    {
        // Create page object
        subAktivitasNilaiAgreementPenKonEdit = new GLOBALS.SubAktivitasNilaiAgreementPenKonEdit(this);

        // Run the page
        return await subAktivitasNilaiAgreementPenKonEdit.Run();
    }
}
