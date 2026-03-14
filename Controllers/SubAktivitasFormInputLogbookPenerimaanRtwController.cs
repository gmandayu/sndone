namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputLogbookPenerimaanRtwList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanRtwList-SubAktivitasFormInputLogbookPenerimaanRTW-list")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanRtwList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanRtwList-SubAktivitasFormInputLogbookPenerimaanRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanRtwList()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanRtwList = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanRtwList(this);
        subAktivitasFormInputLogbookPenerimaanRtwList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanRtwList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputLogbookPenerimaanRtwEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanRtwEdit-SubAktivitasFormInputLogbookPenerimaanRTW-edit")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanRtwEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanRtwEdit-SubAktivitasFormInputLogbookPenerimaanRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanRtwEdit()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanRtwEdit = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanRtwEdit(this);

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanRtwEdit.Run();
    }
}
