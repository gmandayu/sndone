namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiAgreementStslpgList/{id?}", Name = "SubAktivitasNilaiAgreementStslpgList-SubAktivitasNilaiAgreementSTSLPG-list")]
    [Route("Home/SubAktivitasNilaiAgreementStslpgList/{id?}", Name = "SubAktivitasNilaiAgreementStslpgList-SubAktivitasNilaiAgreementSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementStslpgList()
    {
        // Create page object
        subAktivitasNilaiAgreementStslpgList = new GLOBALS.SubAktivitasNilaiAgreementStslpgList(this);
        subAktivitasNilaiAgreementStslpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiAgreementStslpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiAgreementStslpgEdit/{id?}", Name = "SubAktivitasNilaiAgreementStslpgEdit-SubAktivitasNilaiAgreementSTSLPG-edit")]
    [Route("Home/SubAktivitasNilaiAgreementStslpgEdit/{id?}", Name = "SubAktivitasNilaiAgreementStslpgEdit-SubAktivitasNilaiAgreementSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementStslpgEdit()
    {
        // Create page object
        subAktivitasNilaiAgreementStslpgEdit = new GLOBALS.SubAktivitasNilaiAgreementStslpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiAgreementStslpgEdit.Run();
    }
}
