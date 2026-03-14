namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBlPenKonLpgList/{id?}", Name = "SubAktivitasNilaiBlPenKonLpgList-SubAktivitasNilaiBLPenKonLPG-list")]
    [Route("Home/SubAktivitasNilaiBlPenKonLpgList/{id?}", Name = "SubAktivitasNilaiBlPenKonLpgList-SubAktivitasNilaiBLPenKonLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlPenKonLpgList()
    {
        // Create page object
        subAktivitasNilaiBlPenKonLpgList = new GLOBALS.SubAktivitasNilaiBlPenKonLpgList(this);
        subAktivitasNilaiBlPenKonLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiBlPenKonLpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBlPenKonLpgEdit/{id?}", Name = "SubAktivitasNilaiBlPenKonLpgEdit-SubAktivitasNilaiBLPenKonLPG-edit")]
    [Route("Home/SubAktivitasNilaiBlPenKonLpgEdit/{id?}", Name = "SubAktivitasNilaiBlPenKonLpgEdit-SubAktivitasNilaiBLPenKonLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlPenKonLpgEdit()
    {
        // Create page object
        subAktivitasNilaiBlPenKonLpgEdit = new GLOBALS.SubAktivitasNilaiBlPenKonLpgEdit(this);

        // Run the page
        return await subAktivitasNilaiBlPenKonLpgEdit.Run();
    }
}
