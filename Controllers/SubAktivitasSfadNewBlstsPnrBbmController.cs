namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasSfadNewBlstsPnrBbmList/{id?}", Name = "SubAktivitasSfadNewBlstsPnrBbmList-SubAktivitasSFADNewBLSTSPnrBBM-list")]
    [Route("Home/SubAktivitasSfadNewBlstsPnrBbmList/{id?}", Name = "SubAktivitasSfadNewBlstsPnrBbmList-SubAktivitasSFADNewBLSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasSfadNewBlstsPnrBbmList()
    {
        // Create page object
        subAktivitasSfadNewBlstsPnrBbmList = new GLOBALS.SubAktivitasSfadNewBlstsPnrBbmList(this);
        subAktivitasSfadNewBlstsPnrBbmList.Cache = _cache;

        // Run the page
        return await subAktivitasSfadNewBlstsPnrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasSfadNewBlstsPnrBbmEdit/{id?}", Name = "SubAktivitasSfadNewBlstsPnrBbmEdit-SubAktivitasSFADNewBLSTSPnrBBM-edit")]
    [Route("Home/SubAktivitasSfadNewBlstsPnrBbmEdit/{id?}", Name = "SubAktivitasSfadNewBlstsPnrBbmEdit-SubAktivitasSFADNewBLSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasSfadNewBlstsPnrBbmEdit()
    {
        // Create page object
        subAktivitasSfadNewBlstsPnrBbmEdit = new GLOBALS.SubAktivitasSfadNewBlstsPnrBbmEdit(this);

        // Run the page
        return await subAktivitasSfadNewBlstsPnrBbmEdit.Run();
    }
}
