namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasStartBongkarStsPnrBbmList/{id?}", Name = "SubaktivitasStartBongkarStsPnrBbmList-SubaktivitasStartBongkarSTSPnrBBM-list")]
    [Route("Home/SubaktivitasStartBongkarStsPnrBbmList/{id?}", Name = "SubaktivitasStartBongkarStsPnrBbmList-SubaktivitasStartBongkarSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubaktivitasStartBongkarStsPnrBbmList()
    {
        // Create page object
        subaktivitasStartBongkarStsPnrBbmList = new GLOBALS.SubaktivitasStartBongkarStsPnrBbmList(this);
        subaktivitasStartBongkarStsPnrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasStartBongkarStsPnrBbmList.Run();
    }

    // edit
    [Route("SubaktivitasStartBongkarStsPnrBbmEdit/{id?}", Name = "SubaktivitasStartBongkarStsPnrBbmEdit-SubaktivitasStartBongkarSTSPnrBBM-edit")]
    [Route("Home/SubaktivitasStartBongkarStsPnrBbmEdit/{id?}", Name = "SubaktivitasStartBongkarStsPnrBbmEdit-SubaktivitasStartBongkarSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubaktivitasStartBongkarStsPnrBbmEdit()
    {
        // Create page object
        subaktivitasStartBongkarStsPnrBbmEdit = new GLOBALS.SubaktivitasStartBongkarStsPnrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasStartBongkarStsPnrBbmEdit.Run();
    }
}
