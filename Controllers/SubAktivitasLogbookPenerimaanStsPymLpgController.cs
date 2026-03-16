namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookPenerimaanStsPymLpgList/{id?}", Name = "SubAktivitasLogbookPenerimaanStsPymLpgList-SubAktivitasLogbookPenerimaanSTSPymLPG-list")]
    [Route("Home/SubAktivitasLogbookPenerimaanStsPymLpgList/{id?}", Name = "SubAktivitasLogbookPenerimaanStsPymLpgList-SubAktivitasLogbookPenerimaanSTSPymLPG-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanStsPymLpgList()
    {
        // Create page object
        subAktivitasLogbookPenerimaanStsPymLpgList = new GLOBALS.SubAktivitasLogbookPenerimaanStsPymLpgList(this);
        subAktivitasLogbookPenerimaanStsPymLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLogbookPenerimaanStsPymLpgList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookPenerimaanStsPymLpgEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanStsPymLpgEdit-SubAktivitasLogbookPenerimaanSTSPymLPG-edit")]
    [Route("Home/SubAktivitasLogbookPenerimaanStsPymLpgEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanStsPymLpgEdit-SubAktivitasLogbookPenerimaanSTSPymLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanStsPymLpgEdit()
    {
        // Create page object
        subAktivitasLogbookPenerimaanStsPymLpgEdit = new GLOBALS.SubAktivitasLogbookPenerimaanStsPymLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLogbookPenerimaanStsPymLpgEdit.Run();
    }
}
