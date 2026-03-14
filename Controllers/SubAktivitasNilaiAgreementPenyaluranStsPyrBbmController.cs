namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiAgreementPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranStsPyrBbmList-SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM-list")]
    [Route("Home/SubAktivitasNilaiAgreementPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranStsPyrBbmList-SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenyaluranStsPyrBbmList()
    {
        // Create page object
        subAktivitasNilaiAgreementPenyaluranStsPyrBbmList = new GLOBALS.SubAktivitasNilaiAgreementPenyaluranStsPyrBbmList(this);
        subAktivitasNilaiAgreementPenyaluranStsPyrBbmList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiAgreementPenyaluranStsPyrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiAgreementPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranStsPyrBbmEdit-SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM-edit")]
    [Route("Home/SubAktivitasNilaiAgreementPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranStsPyrBbmEdit-SubAktivitasNilaiAgreementPenyaluranSTSPyrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenyaluranStsPyrBbmEdit()
    {
        // Create page object
        subAktivitasNilaiAgreementPenyaluranStsPyrBbmEdit = new GLOBALS.SubAktivitasNilaiAgreementPenyaluranStsPyrBbmEdit(this);

        // Run the page
        return await subAktivitasNilaiAgreementPenyaluranStsPyrBbmEdit.Run();
    }
}
