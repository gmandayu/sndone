namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputLogbookPenerimaanPenKonList/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPenKonList-SubAktivitasInputLogbookPenerimaanPenKon-list")]
    [Route("Home/SubAktivitasInputLogbookPenerimaanPenKonList/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPenKonList-SubAktivitasInputLogbookPenerimaanPenKon-list-2")]
    public async Task<IActionResult> SubAktivitasInputLogbookPenerimaanPenKonList()
    {
        // Create page object
        subAktivitasInputLogbookPenerimaanPenKonList = new GLOBALS.SubAktivitasInputLogbookPenerimaanPenKonList(this);
        subAktivitasInputLogbookPenerimaanPenKonList.Cache = _cache;

        // Run the page
        return await subAktivitasInputLogbookPenerimaanPenKonList.Run();
    }

    // edit
    [Route("SubAktivitasInputLogbookPenerimaanPenKonEdit/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPenKonEdit-SubAktivitasInputLogbookPenerimaanPenKon-edit")]
    [Route("Home/SubAktivitasInputLogbookPenerimaanPenKonEdit/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPenKonEdit-SubAktivitasInputLogbookPenerimaanPenKon-edit-2")]
    public async Task<IActionResult> SubAktivitasInputLogbookPenerimaanPenKonEdit()
    {
        // Create page object
        subAktivitasInputLogbookPenerimaanPenKonEdit = new GLOBALS.SubAktivitasInputLogbookPenerimaanPenKonEdit(this);

        // Run the page
        return await subAktivitasInputLogbookPenerimaanPenKonEdit.Run();
    }
}
