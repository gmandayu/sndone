namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBlPenKonList/{id?}", Name = "SubAktivitasNilaiBlPenKonList-SubAktivitasNilaiBLPenKon-list")]
    [Route("Home/SubAktivitasNilaiBlPenKonList/{id?}", Name = "SubAktivitasNilaiBlPenKonList-SubAktivitasNilaiBLPenKon-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlPenKonList()
    {
        // Create page object
        subAktivitasNilaiBlPenKonList = new GLOBALS.SubAktivitasNilaiBlPenKonList(this);
        subAktivitasNilaiBlPenKonList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiBlPenKonList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBlPenKonEdit/{id?}", Name = "SubAktivitasNilaiBlPenKonEdit-SubAktivitasNilaiBLPenKon-edit")]
    [Route("Home/SubAktivitasNilaiBlPenKonEdit/{id?}", Name = "SubAktivitasNilaiBlPenKonEdit-SubAktivitasNilaiBLPenKon-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBlPenKonEdit()
    {
        // Create page object
        subAktivitasNilaiBlPenKonEdit = new GLOBALS.SubAktivitasNilaiBlPenKonEdit(this);

        // Run the page
        return await subAktivitasNilaiBlPenKonEdit.Run();
    }
}
