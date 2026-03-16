namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookPenerimaanStsPymBbmList/{id?}", Name = "SubAktivitasLogbookPenerimaanStsPymBbmList-SubAktivitasLogbookPenerimaanSTSPymBBM-list")]
    [Route("Home/SubAktivitasLogbookPenerimaanStsPymBbmList/{id?}", Name = "SubAktivitasLogbookPenerimaanStsPymBbmList-SubAktivitasLogbookPenerimaanSTSPymBBM-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanStsPymBbmList()
    {
        // Create page object
        subAktivitasLogbookPenerimaanStsPymBbmList = new GLOBALS.SubAktivitasLogbookPenerimaanStsPymBbmList(this);
        subAktivitasLogbookPenerimaanStsPymBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLogbookPenerimaanStsPymBbmList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookPenerimaanStsPymBbmEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanStsPymBbmEdit-SubAktivitasLogbookPenerimaanSTSPymBBM-edit")]
    [Route("Home/SubAktivitasLogbookPenerimaanStsPymBbmEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanStsPymBbmEdit-SubAktivitasLogbookPenerimaanSTSPymBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanStsPymBbmEdit()
    {
        // Create page object
        subAktivitasLogbookPenerimaanStsPymBbmEdit = new GLOBALS.SubAktivitasLogbookPenerimaanStsPymBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLogbookPenerimaanStsPymBbmEdit.Run();
    }
}
