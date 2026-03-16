namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputLogbookPenerimaanPipaList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanPipaList-SubAktivitasFormInputLogbookPenerimaanPipa-list")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanPipaList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanPipaList-SubAktivitasFormInputLogbookPenerimaanPipa-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanPipaList()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanPipaList = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanPipaList(this);
        subAktivitasFormInputLogbookPenerimaanPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanPipaList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputLogbookPenerimaanPipaEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanPipaEdit-SubAktivitasFormInputLogbookPenerimaanPipa-edit")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanPipaEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanPipaEdit-SubAktivitasFormInputLogbookPenerimaanPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanPipaEdit()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanPipaEdit = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanPipaEdit.Run();
    }
}
