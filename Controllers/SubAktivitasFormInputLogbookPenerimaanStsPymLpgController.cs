namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputLogbookPenerimaanStsPymLpgList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgList-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-list")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanStsPymLpgList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgList-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanStsPymLpgList()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanStsPymLpgList = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanStsPymLpgList(this);
        subAktivitasFormInputLogbookPenerimaanStsPymLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanStsPymLpgList.Run();
    }

    // add
    [Route("SubAktivitasFormInputLogbookPenerimaanStsPymLpgAdd/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgAdd-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-add")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanStsPymLpgAdd/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgAdd-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanStsPymLpgAdd()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanStsPymLpgAdd = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanStsPymLpgAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanStsPymLpgAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputLogbookPenerimaanStsPymLpgView/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgView-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-view")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanStsPymLpgView/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgView-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanStsPymLpgView()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanStsPymLpgView = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanStsPymLpgView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanStsPymLpgView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputLogbookPenerimaanStsPymLpgEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgEdit-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-edit")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanStsPymLpgEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgEdit-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanStsPymLpgEdit()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanStsPymLpgEdit = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanStsPymLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanStsPymLpgEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputLogbookPenerimaanStsPymLpgDelete/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgDelete-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-delete")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanStsPymLpgDelete/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanStsPymLpgDelete-SubAktivitasFormInputLogbookPenerimaanSTSPymLPG-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanStsPymLpgDelete()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanStsPymLpgDelete = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanStsPymLpgDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanStsPymLpgDelete.Run();
    }
}
