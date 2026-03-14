namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookPenerimaanLpgList/{id?}", Name = "SubAktivitasLogbookPenerimaanLpgList-SubAktivitasLogbookPenerimaanLPG-list")]
    [Route("Home/SubAktivitasLogbookPenerimaanLpgList/{id?}", Name = "SubAktivitasLogbookPenerimaanLpgList-SubAktivitasLogbookPenerimaanLPG-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanLpgList()
    {
        // Create page object
        subAktivitasLogbookPenerimaanLpgList = new GLOBALS.SubAktivitasLogbookPenerimaanLpgList(this);
        subAktivitasLogbookPenerimaanLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasLogbookPenerimaanLpgList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookPenerimaanLpgEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanLpgEdit-SubAktivitasLogbookPenerimaanLPG-edit")]
    [Route("Home/SubAktivitasLogbookPenerimaanLpgEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanLpgEdit-SubAktivitasLogbookPenerimaanLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanLpgEdit()
    {
        // Create page object
        subAktivitasLogbookPenerimaanLpgEdit = new GLOBALS.SubAktivitasLogbookPenerimaanLpgEdit(this);

        // Run the page
        return await subAktivitasLogbookPenerimaanLpgEdit.Run();
    }
}
