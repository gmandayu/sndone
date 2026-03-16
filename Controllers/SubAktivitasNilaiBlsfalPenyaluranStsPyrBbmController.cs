namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmList-SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM-list")]
    [Route("Home/SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmList-SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmList()
    {
        // Create page object
        subAktivitasNilaiBlsfalPenyaluranStsPyrBbmList = new GLOBALS.SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmList(this);
        subAktivitasNilaiBlsfalPenyaluranStsPyrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalPenyaluranStsPyrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmEdit-SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM-edit")]
    [Route("Home/SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmEdit-SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmEdit()
    {
        // Create page object
        subAktivitasNilaiBlsfalPenyaluranStsPyrBbmEdit = new GLOBALS.SubAktivitasNilaiBlsfalPenyaluranStsPyrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalPenyaluranStsPyrBbmEdit.Run();
    }
}
