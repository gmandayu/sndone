namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiAgreementPenyaluranLpgList/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranLpgList-SubAktivitasNilaiAgreementPenyaluranLPG-list")]
    [Route("Home/SubAktivitasNilaiAgreementPenyaluranLpgList/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranLpgList-SubAktivitasNilaiAgreementPenyaluranLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenyaluranLpgList()
    {
        // Create page object
        subAktivitasNilaiAgreementPenyaluranLpgList = new GLOBALS.SubAktivitasNilaiAgreementPenyaluranLpgList(this);
        subAktivitasNilaiAgreementPenyaluranLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiAgreementPenyaluranLpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiAgreementPenyaluranLpgEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranLpgEdit-SubAktivitasNilaiAgreementPenyaluranLPG-edit")]
    [Route("Home/SubAktivitasNilaiAgreementPenyaluranLpgEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranLpgEdit-SubAktivitasNilaiAgreementPenyaluranLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenyaluranLpgEdit()
    {
        // Create page object
        subAktivitasNilaiAgreementPenyaluranLpgEdit = new GLOBALS.SubAktivitasNilaiAgreementPenyaluranLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiAgreementPenyaluranLpgEdit.Run();
    }
}
