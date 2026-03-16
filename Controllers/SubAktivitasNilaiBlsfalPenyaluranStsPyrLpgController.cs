namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgList-SubAktivitasNilaiBLSFALPenyaluranSTSPyrLPG-list")]
    [Route("Home/SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgList-SubAktivitasNilaiBLSFALPenyaluranSTSPyrLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgList()
    {
        // Create page object
        subAktivitasNilaiBlsfalPenyaluranStsPyrLpgList = new GLOBALS.SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgList(this);
        subAktivitasNilaiBlsfalPenyaluranStsPyrLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalPenyaluranStsPyrLpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgEdit-SubAktivitasNilaiBLSFALPenyaluranSTSPyrLPG-edit")]
    [Route("Home/SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgEdit-SubAktivitasNilaiBLSFALPenyaluranSTSPyrLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgEdit()
    {
        // Create page object
        subAktivitasNilaiBlsfalPenyaluranStsPyrLpgEdit = new GLOBALS.SubAktivitasNilaiBlsfalPenyaluranStsPyrLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalPenyaluranStsPyrLpgEdit.Run();
    }
}
