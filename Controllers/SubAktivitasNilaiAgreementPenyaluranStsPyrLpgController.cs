namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiAgreementPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranStsPyrLpgList-SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG-list")]
    [Route("Home/SubAktivitasNilaiAgreementPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranStsPyrLpgList-SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenyaluranStsPyrLpgList()
    {
        // Create page object
        subAktivitasNilaiAgreementPenyaluranStsPyrLpgList = new GLOBALS.SubAktivitasNilaiAgreementPenyaluranStsPyrLpgList(this);
        subAktivitasNilaiAgreementPenyaluranStsPyrLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiAgreementPenyaluranStsPyrLpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiAgreementPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranStsPyrLpgEdit-SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG-edit")]
    [Route("Home/SubAktivitasNilaiAgreementPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranStsPyrLpgEdit-SubAktivitasNilaiAgreementPenyaluranSTSPyrLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenyaluranStsPyrLpgEdit()
    {
        // Create page object
        subAktivitasNilaiAgreementPenyaluranStsPyrLpgEdit = new GLOBALS.SubAktivitasNilaiAgreementPenyaluranStsPyrLpgEdit(this);

        // Run the page
        return await subAktivitasNilaiAgreementPenyaluranStsPyrLpgEdit.Run();
    }
}
