namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasKapalBerangkatStsPnrBbmList/{id?}", Name = "SubaktivitasKapalBerangkatStsPnrBbmList-SubaktivitasKapalBerangkatSTSPnrBBM-list")]
    [Route("Home/SubaktivitasKapalBerangkatStsPnrBbmList/{id?}", Name = "SubaktivitasKapalBerangkatStsPnrBbmList-SubaktivitasKapalBerangkatSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubaktivitasKapalBerangkatStsPnrBbmList()
    {
        // Create page object
        subaktivitasKapalBerangkatStsPnrBbmList = new GLOBALS.SubaktivitasKapalBerangkatStsPnrBbmList(this);
        subaktivitasKapalBerangkatStsPnrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasKapalBerangkatStsPnrBbmList.Run();
    }

    // edit
    [Route("SubaktivitasKapalBerangkatStsPnrBbmEdit/{id?}", Name = "SubaktivitasKapalBerangkatStsPnrBbmEdit-SubaktivitasKapalBerangkatSTSPnrBBM-edit")]
    [Route("Home/SubaktivitasKapalBerangkatStsPnrBbmEdit/{id?}", Name = "SubaktivitasKapalBerangkatStsPnrBbmEdit-SubaktivitasKapalBerangkatSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubaktivitasKapalBerangkatStsPnrBbmEdit()
    {
        // Create page object
        subaktivitasKapalBerangkatStsPnrBbmEdit = new GLOBALS.SubaktivitasKapalBerangkatStsPnrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasKapalBerangkatStsPnrBbmEdit.Run();
    }
}
