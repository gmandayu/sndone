namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBlsfalPenyaluranList/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranList-SubAktivitasNilaiBLSFALPenyaluran-list")]
    [Route("Home/SubAktivitasNilaiBlsfalPenyaluranList/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranList-SubAktivitasNilaiBLSFALPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalPenyaluranList()
    {
        // Create page object
        subAktivitasNilaiBlsfalPenyaluranList = new GLOBALS.SubAktivitasNilaiBlsfalPenyaluranList(this);
        subAktivitasNilaiBlsfalPenyaluranList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBlsfalPenyaluranEdit/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranEdit-SubAktivitasNilaiBLSFALPenyaluran-edit")]
    [Route("Home/SubAktivitasNilaiBlsfalPenyaluranEdit/{id?}", Name = "SubAktivitasNilaiBlsfalPenyaluranEdit-SubAktivitasNilaiBLSFALPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalPenyaluranEdit()
    {
        // Create page object
        subAktivitasNilaiBlsfalPenyaluranEdit = new GLOBALS.SubAktivitasNilaiBlsfalPenyaluranEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalPenyaluranEdit.Run();
    }
}
