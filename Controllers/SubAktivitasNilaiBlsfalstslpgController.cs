namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBlsfalstslpgList/{id?}", Name = "SubAktivitasNilaiBlsfalstslpgList-SubAktivitasNilaiBLSFALSTSLPG-list")]
    [Route("Home/SubAktivitasNilaiBlsfalstslpgList/{id?}", Name = "SubAktivitasNilaiBlsfalstslpgList-SubAktivitasNilaiBLSFALSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalstslpgList()
    {
        // Create page object
        subAktivitasNilaiBlsfalstslpgList = new GLOBALS.SubAktivitasNilaiBlsfalstslpgList(this);
        subAktivitasNilaiBlsfalstslpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalstslpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBlsfalstslpgEdit/{id?}", Name = "SubAktivitasNilaiBlsfalstslpgEdit-SubAktivitasNilaiBLSFALSTSLPG-edit")]
    [Route("Home/SubAktivitasNilaiBlsfalstslpgEdit/{id?}", Name = "SubAktivitasNilaiBlsfalstslpgEdit-SubAktivitasNilaiBLSFALSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlsfalstslpgEdit()
    {
        // Create page object
        subAktivitasNilaiBlsfalstslpgEdit = new GLOBALS.SubAktivitasNilaiBlsfalstslpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBlsfalstslpgEdit.Run();
    }
}
