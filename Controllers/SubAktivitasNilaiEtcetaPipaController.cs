namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiEtcetaPipaList/{id?}", Name = "SubAktivitasNilaiEtcetaPipaList-SubAktivitasNilaiETCETAPipa-list")]
    [Route("Home/SubAktivitasNilaiEtcetaPipaList/{id?}", Name = "SubAktivitasNilaiEtcetaPipaList-SubAktivitasNilaiETCETAPipa-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiEtcetaPipaList()
    {
        // Create page object
        subAktivitasNilaiEtcetaPipaList = new GLOBALS.SubAktivitasNilaiEtcetaPipaList(this);
        subAktivitasNilaiEtcetaPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiEtcetaPipaList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiEtcetaPipaEdit/{id?}", Name = "SubAktivitasNilaiEtcetaPipaEdit-SubAktivitasNilaiETCETAPipa-edit")]
    [Route("Home/SubAktivitasNilaiEtcetaPipaEdit/{id?}", Name = "SubAktivitasNilaiEtcetaPipaEdit-SubAktivitasNilaiETCETAPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiEtcetaPipaEdit()
    {
        // Create page object
        subAktivitasNilaiEtcetaPipaEdit = new GLOBALS.SubAktivitasNilaiEtcetaPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiEtcetaPipaEdit.Run();
    }
}
