namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAkivitasNilaiAktualDischargePipaList/{id?}", Name = "SubAkivitasNilaiAktualDischargePipaList-SubAkivitasNilaiAktualDischargePipa-list")]
    [Route("Home/SubAkivitasNilaiAktualDischargePipaList/{id?}", Name = "SubAkivitasNilaiAktualDischargePipaList-SubAkivitasNilaiAktualDischargePipa-list-2")]
    public async Task<IActionResult> SubAkivitasNilaiAktualDischargePipaList()
    {
        // Create page object
        subAkivitasNilaiAktualDischargePipaList = new GLOBALS.SubAkivitasNilaiAktualDischargePipaList(this);
        subAkivitasNilaiAktualDischargePipaList.Cache = _cache;

        // Run the page
        return await subAkivitasNilaiAktualDischargePipaList.Run();
    }

    // edit
    [Route("SubAkivitasNilaiAktualDischargePipaEdit/{id?}", Name = "SubAkivitasNilaiAktualDischargePipaEdit-SubAkivitasNilaiAktualDischargePipa-edit")]
    [Route("Home/SubAkivitasNilaiAktualDischargePipaEdit/{id?}", Name = "SubAkivitasNilaiAktualDischargePipaEdit-SubAkivitasNilaiAktualDischargePipa-edit-2")]
    public async Task<IActionResult> SubAkivitasNilaiAktualDischargePipaEdit()
    {
        // Create page object
        subAkivitasNilaiAktualDischargePipaEdit = new GLOBALS.SubAkivitasNilaiAktualDischargePipaEdit(this);

        // Run the page
        return await subAkivitasNilaiAktualDischargePipaEdit.Run();
    }
}
