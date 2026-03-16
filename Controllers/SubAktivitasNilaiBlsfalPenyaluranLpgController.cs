namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBlsfalPenyaluranLpgList/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranLpgList-SubAktivitasNilaiBLSFALPenyaluranLPG-list")]
    [Route("Home/SubAktivitasNilaiBlsfalPenyaluranLpgList/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranLpgList-SubAktivitasNilaiBLSFALPenyaluranLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalPenyaluranLpgList()
    {
        // Create page object
        subAktivitasNilaiBlsfalPenyaluranLpgList = new GLOBALS.SubAktivitasNilaiBlsfalPenyaluranLpgList(this);
        subAktivitasNilaiBlsfalPenyaluranLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalPenyaluranLpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBlsfalPenyaluranLpgEdit/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranLpgEdit-SubAktivitasNilaiBLSFALPenyaluranLPG-edit")]
    [Route("Home/SubAktivitasNilaiBlsfalPenyaluranLpgEdit/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranLpgEdit-SubAktivitasNilaiBLSFALPenyaluranLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalPenyaluranLpgEdit()
    {
        // Create page object
        subAktivitasNilaiBlsfalPenyaluranLpgEdit = new GLOBALS.SubAktivitasNilaiBlsfalPenyaluranLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalPenyaluranLpgEdit.Run();
    }
}
