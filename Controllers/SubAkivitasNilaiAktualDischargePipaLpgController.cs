namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAkivitasNilaiAktualDischargePipaLpgList/{id?}", Name = "SubAkivitasNilaiAktualDischargePipaLpgList-SubAkivitasNilaiAktualDischargePipaLPG-list")]
    [Route("Home/SubAkivitasNilaiAktualDischargePipaLpgList/{id?}", Name = "SubAkivitasNilaiAktualDischargePipaLpgList-SubAkivitasNilaiAktualDischargePipaLPG-list-2")]
    public async Task<IActionResult> SubAkivitasNilaiAktualDischargePipaLpgList()
    {
        // Create page object
        subAkivitasNilaiAktualDischargePipaLpgList = new GLOBALS.SubAkivitasNilaiAktualDischargePipaLpgList(this);
        subAkivitasNilaiAktualDischargePipaLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAkivitasNilaiAktualDischargePipaLpgList.Run();
    }

    // edit
    [Route("SubAkivitasNilaiAktualDischargePipaLpgEdit/{id?}", Name = "SubAkivitasNilaiAktualDischargePipaLpgEdit-SubAkivitasNilaiAktualDischargePipaLPG-edit")]
    [Route("Home/SubAkivitasNilaiAktualDischargePipaLpgEdit/{id?}", Name = "SubAkivitasNilaiAktualDischargePipaLpgEdit-SubAkivitasNilaiAktualDischargePipaLPG-edit-2")]
    public async Task<IActionResult> SubAkivitasNilaiAktualDischargePipaLpgEdit()
    {
        // Create page object
        subAkivitasNilaiAktualDischargePipaLpgEdit = new GLOBALS.SubAkivitasNilaiAktualDischargePipaLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAkivitasNilaiAktualDischargePipaLpgEdit.Run();
    }
}
