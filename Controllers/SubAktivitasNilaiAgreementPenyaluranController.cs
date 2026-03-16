namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiAgreementPenyaluranList/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranList-SubAktivitasNilaiAgreementPenyaluran-list")]
    [Route("Home/SubAktivitasNilaiAgreementPenyaluranList/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranList-SubAktivitasNilaiAgreementPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenyaluranList()
    {
        // Create page object
        subAktivitasNilaiAgreementPenyaluranList = new GLOBALS.SubAktivitasNilaiAgreementPenyaluranList(this);
        subAktivitasNilaiAgreementPenyaluranList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiAgreementPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiAgreementPenyaluranEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranEdit-SubAktivitasNilaiAgreementPenyaluran-edit")]
    [Route("Home/SubAktivitasNilaiAgreementPenyaluranEdit/{id?}", Name = "SubAktivitasNilaiAgreementPenyaluranEdit-SubAktivitasNilaiAgreementPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiAgreementPenyaluranEdit()
    {
        // Create page object
        subAktivitasNilaiAgreementPenyaluranEdit = new GLOBALS.SubAktivitasNilaiAgreementPenyaluranEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiAgreementPenyaluranEdit.Run();
    }
}
