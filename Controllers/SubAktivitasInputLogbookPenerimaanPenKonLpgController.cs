namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputLogbookPenerimaanPenKonLpgList/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPenKonLpgList-SubAktivitasInputLogbookPenerimaanPenKonLPG-list")]
    [Route("Home/SubAktivitasInputLogbookPenerimaanPenKonLpgList/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPenKonLpgList-SubAktivitasInputLogbookPenerimaanPenKonLPG-list-2")]
    public async Task<IActionResult> SubAktivitasInputLogbookPenerimaanPenKonLpgList()
    {
        // Create page object
        subAktivitasInputLogbookPenerimaanPenKonLpgList = new GLOBALS.SubAktivitasInputLogbookPenerimaanPenKonLpgList(this);
        subAktivitasInputLogbookPenerimaanPenKonLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasInputLogbookPenerimaanPenKonLpgList.Run();
    }

    // edit
    [Route("SubAktivitasInputLogbookPenerimaanPenKonLpgEdit/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPenKonLpgEdit-SubAktivitasInputLogbookPenerimaanPenKonLPG-edit")]
    [Route("Home/SubAktivitasInputLogbookPenerimaanPenKonLpgEdit/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPenKonLpgEdit-SubAktivitasInputLogbookPenerimaanPenKonLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasInputLogbookPenerimaanPenKonLpgEdit()
    {
        // Create page object
        subAktivitasInputLogbookPenerimaanPenKonLpgEdit = new GLOBALS.SubAktivitasInputLogbookPenerimaanPenKonLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasInputLogbookPenerimaanPenKonLpgEdit.Run();
    }
}
