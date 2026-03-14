namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputLogbookPenerimaanStsPymBbmList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymBbmList-SubAktivitasFormInputLogbookPenerimaanSTSPymBBM-list")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanStsPymBbmList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymBbmList-SubAktivitasFormInputLogbookPenerimaanSTSPymBBM-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanStsPymBbmList()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanStsPymBbmList = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanStsPymBbmList(this);
        subAktivitasFormInputLogbookPenerimaanStsPymBbmList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanStsPymBbmList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputLogbookPenerimaanStsPymBbmEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymBbmEdit-SubAktivitasFormInputLogbookPenerimaanSTSPymBBM-edit")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanStsPymBbmEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymBbmEdit-SubAktivitasFormInputLogbookPenerimaanSTSPymBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanStsPymBbmEdit()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanStsPymBbmEdit = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanStsPymBbmEdit(this);

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanStsPymBbmEdit.Run();
    }
}
