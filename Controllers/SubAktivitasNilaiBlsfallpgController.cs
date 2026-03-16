namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBlsfallpgList/{id?}", Name = "SubAktivitasNilaiBlsfallpgList-SubAktivitasNilaiBLSFALLPG-list")]
    [Route("Home/SubAktivitasNilaiBlsfallpgList/{id?}", Name = "SubAktivitasNilaiBlsfallpgList-SubAktivitasNilaiBLSFALLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfallpgList()
    {
        // Create page object
        subAktivitasNilaiBlsfallpgList = new GLOBALS.SubAktivitasNilaiBlsfallpgList(this);
        subAktivitasNilaiBlsfallpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfallpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBlsfallpgEdit/{id?}", Name = "SubAktivitasNilaiBlsfallpgEdit-SubAktivitasNilaiBLSFALLPG-edit")]
    [Route("Home/SubAktivitasNilaiBlsfallpgEdit/{id?}", Name = "SubAktivitasNilaiBlsfallpgEdit-SubAktivitasNilaiBLSFALLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfallpgEdit()
    {
        // Create page object
        subAktivitasNilaiBlsfallpgEdit = new GLOBALS.SubAktivitasNilaiBlsfallpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfallpgEdit.Run();
    }
}
