namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasSfadNewBllpgList/{id?}", Name = "SubAktivitasSfadNewBllpgList-SubAktivitasSFADNewBLLPG-list")]
    [Route("Home/SubAktivitasSfadNewBllpgList/{id?}", Name = "SubAktivitasSfadNewBllpgList-SubAktivitasSFADNewBLLPG-list-2")]
    public async Task<IActionResult> SubAktivitasSfadNewBllpgList()
    {
        // Create page object
        subAktivitasSfadNewBllpgList = new GLOBALS.SubAktivitasSfadNewBllpgList(this);
        subAktivitasSfadNewBllpgList.Cache = _cache;

        // Run the page
        return await subAktivitasSfadNewBllpgList.Run();
    }

    // edit
    [Route("SubAktivitasSfadNewBllpgEdit/{id?}", Name = "SubAktivitasSfadNewBllpgEdit-SubAktivitasSFADNewBLLPG-edit")]
    [Route("Home/SubAktivitasSfadNewBllpgEdit/{id?}", Name = "SubAktivitasSfadNewBllpgEdit-SubAktivitasSFADNewBLLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasSfadNewBllpgEdit()
    {
        // Create page object
        subAktivitasSfadNewBllpgEdit = new GLOBALS.SubAktivitasSfadNewBllpgEdit(this);

        // Run the page
        return await subAktivitasSfadNewBllpgEdit.Run();
    }
}
