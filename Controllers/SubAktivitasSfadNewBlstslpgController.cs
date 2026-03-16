namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasSfadNewBlstslpgList/{id?}", Name = "SubAktivitasSfadNewBlstslpgList-SubAktivitasSFADNewBLSTSLPG-list")]
    [Route("Home/SubAktivitasSfadNewBlstslpgList/{id?}", Name = "SubAktivitasSfadNewBlstslpgList-SubAktivitasSFADNewBLSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasSfadNewBlstslpgList()
    {
        // Create page object
        subAktivitasSfadNewBlstslpgList = new GLOBALS.SubAktivitasSfadNewBlstslpgList(this);
        subAktivitasSfadNewBlstslpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasSfadNewBlstslpgList.Run();
    }

    // edit
    [Route("SubAktivitasSfadNewBlstslpgEdit/{id?}", Name = "SubAktivitasSfadNewBlstslpgEdit-SubAktivitasSFADNewBLSTSLPG-edit")]
    [Route("Home/SubAktivitasSfadNewBlstslpgEdit/{id?}", Name = "SubAktivitasSfadNewBlstslpgEdit-SubAktivitasSFADNewBLSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasSfadNewBlstslpgEdit()
    {
        // Create page object
        subAktivitasSfadNewBlstslpgEdit = new GLOBALS.SubAktivitasSfadNewBlstslpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasSfadNewBlstslpgEdit.Run();
    }
}
