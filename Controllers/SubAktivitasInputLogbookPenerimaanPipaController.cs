namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputLogbookPenerimaanPipaList/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPipaList-SubAktivitasInputLogbookPenerimaanPipa-list")]
    [Route("Home/SubAktivitasInputLogbookPenerimaanPipaList/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPipaList-SubAktivitasInputLogbookPenerimaanPipa-list-2")]
    public async Task<IActionResult> SubAktivitasInputLogbookPenerimaanPipaList()
    {
        // Create page object
        subAktivitasInputLogbookPenerimaanPipaList = new GLOBALS.SubAktivitasInputLogbookPenerimaanPipaList(this);
        subAktivitasInputLogbookPenerimaanPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasInputLogbookPenerimaanPipaList.Run();
    }

    // edit
    [Route("SubAktivitasInputLogbookPenerimaanPipaEdit/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPipaEdit-SubAktivitasInputLogbookPenerimaanPipa-edit")]
    [Route("Home/SubAktivitasInputLogbookPenerimaanPipaEdit/{id?}", Name = "SubAktivitasInputLogbookPenerimaanPipaEdit-SubAktivitasInputLogbookPenerimaanPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasInputLogbookPenerimaanPipaEdit()
    {
        // Create page object
        subAktivitasInputLogbookPenerimaanPipaEdit = new GLOBALS.SubAktivitasInputLogbookPenerimaanPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasInputLogbookPenerimaanPipaEdit.Run();
    }
}
