namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiAgreementLpgList/{id?}", Name = "SubAktivitasNilaiAgreementLpgList-SubAktivitasNilaiAgreementLPG-list")]
    [Route("Home/SubAktivitasNilaiAgreementLpgList/{id?}", Name = "SubAktivitasNilaiAgreementLpgList-SubAktivitasNilaiAgreementLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementLpgList()
    {
        // Create page object
        subAktivitasNilaiAgreementLpgList = new GLOBALS.SubAktivitasNilaiAgreementLpgList(this);
        subAktivitasNilaiAgreementLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiAgreementLpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiAgreementLpgEdit/{id?}", Name = "SubAktivitasNilaiAgreementLpgEdit-SubAktivitasNilaiAgreementLPG-edit")]
    [Route("Home/SubAktivitasNilaiAgreementLpgEdit/{id?}", Name = "SubAktivitasNilaiAgreementLpgEdit-SubAktivitasNilaiAgreementLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementLpgEdit()
    {
        // Create page object
        subAktivitasNilaiAgreementLpgEdit = new GLOBALS.SubAktivitasNilaiAgreementLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiAgreementLpgEdit.Run();
    }
}
