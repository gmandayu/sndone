namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookPenerimaanList/{id?}", Name = "SubAktivitasLogbookPenerimaanList-SubAktivitasLogbookPenerimaan-list")]
    [Route("Home/SubAktivitasLogbookPenerimaanList/{id?}", Name = "SubAktivitasLogbookPenerimaanList-SubAktivitasLogbookPenerimaan-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanList()
    {
        // Create page object
        subAktivitasLogbookPenerimaanList = new GLOBALS.SubAktivitasLogbookPenerimaanList(this);
        subAktivitasLogbookPenerimaanList.Cache = _cache;

        // Run the page
        return await subAktivitasLogbookPenerimaanList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookPenerimaanEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanEdit-SubAktivitasLogbookPenerimaan-edit")]
    [Route("Home/SubAktivitasLogbookPenerimaanEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanEdit-SubAktivitasLogbookPenerimaan-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanEdit()
    {
        // Create page object
        subAktivitasLogbookPenerimaanEdit = new GLOBALS.SubAktivitasLogbookPenerimaanEdit(this);

        // Run the page
        return await subAktivitasLogbookPenerimaanEdit.Run();
    }
}
