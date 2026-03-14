namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasSfadNewBlList/{id?}", Name = "SubAktivitasSfadNewBlList-SubAktivitasSFADNewBL-list")]
    [Route("Home/SubAktivitasSfadNewBlList/{id?}", Name = "SubAktivitasSfadNewBlList-SubAktivitasSFADNewBL-list-2")]
    public async Task<IActionResult> SubAktivitasSfadNewBlList()
    {
        // Create page object
        subAktivitasSfadNewBlList = new GLOBALS.SubAktivitasSfadNewBlList(this);
        subAktivitasSfadNewBlList.Cache = _cache;

        // Run the page
        return await subAktivitasSfadNewBlList.Run();
    }

    // edit
    [Route("SubAktivitasSfadNewBlEdit/{id?}", Name = "SubAktivitasSfadNewBlEdit-SubAktivitasSFADNewBL-edit")]
    [Route("Home/SubAktivitasSfadNewBlEdit/{id?}", Name = "SubAktivitasSfadNewBlEdit-SubAktivitasSFADNewBL-edit-2")]
    public async Task<IActionResult> SubAktivitasSfadNewBlEdit()
    {
        // Create page object
        subAktivitasSfadNewBlEdit = new GLOBALS.SubAktivitasSfadNewBlEdit(this);

        // Run the page
        return await subAktivitasSfadNewBlEdit.Run();
    }
}
