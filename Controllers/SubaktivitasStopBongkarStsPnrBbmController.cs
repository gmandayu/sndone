namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasStopBongkarStsPnrBbmList/{id?}", Name = "SubaktivitasStopBongkarStsPnrBbmList-SubaktivitasStopBongkarSTSPnrBBM-list")]
    [Route("Home/SubaktivitasStopBongkarStsPnrBbmList/{id?}", Name = "SubaktivitasStopBongkarStsPnrBbmList-SubaktivitasStopBongkarSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubaktivitasStopBongkarStsPnrBbmList()
    {
        // Create page object
        subaktivitasStopBongkarStsPnrBbmList = new GLOBALS.SubaktivitasStopBongkarStsPnrBbmList(this);
        subaktivitasStopBongkarStsPnrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasStopBongkarStsPnrBbmList.Run();
    }

    // edit
    [Route("SubaktivitasStopBongkarStsPnrBbmEdit/{id?}", Name = "SubaktivitasStopBongkarStsPnrBbmEdit-SubaktivitasStopBongkarSTSPnrBBM-edit")]
    [Route("Home/SubaktivitasStopBongkarStsPnrBbmEdit/{id?}", Name = "SubaktivitasStopBongkarStsPnrBbmEdit-SubaktivitasStopBongkarSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubaktivitasStopBongkarStsPnrBbmEdit()
    {
        // Create page object
        subaktivitasStopBongkarStsPnrBbmEdit = new GLOBALS.SubaktivitasStopBongkarStsPnrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasStopBongkarStsPnrBbmEdit.Run();
    }
}
