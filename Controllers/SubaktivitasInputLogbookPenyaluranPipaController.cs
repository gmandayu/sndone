namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasInputLogbookPenyaluranPipaList/{Id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaList-SubaktivitasInputLogbookPenyaluranPipa-list")]
    [Route("Home/SubaktivitasInputLogbookPenyaluranPipaList/{Id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaList-SubaktivitasInputLogbookPenyaluranPipa-list-2")]
    public async Task<IActionResult> SubaktivitasInputLogbookPenyaluranPipaList()
    {
        // Create page object
        subaktivitasInputLogbookPenyaluranPipaList = new GLOBALS.SubaktivitasInputLogbookPenyaluranPipaList(this);
        subaktivitasInputLogbookPenyaluranPipaList.Cache = _cache;

        // Run the page
        return await subaktivitasInputLogbookPenyaluranPipaList.Run();
    }

    // edit
    [Route("SubaktivitasInputLogbookPenyaluranPipaEdit/{Id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaEdit-SubaktivitasInputLogbookPenyaluranPipa-edit")]
    [Route("Home/SubaktivitasInputLogbookPenyaluranPipaEdit/{Id?}", Name = "SubaktivitasInputLogbookPenyaluranPipaEdit-SubaktivitasInputLogbookPenyaluranPipa-edit-2")]
    public async Task<IActionResult> SubaktivitasInputLogbookPenyaluranPipaEdit()
    {
        // Create page object
        subaktivitasInputLogbookPenyaluranPipaEdit = new GLOBALS.SubaktivitasInputLogbookPenyaluranPipaEdit(this);

        // Run the page
        return await subaktivitasInputLogbookPenyaluranPipaEdit.Run();
    }
}
