namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasStartBongkarList/{id?}", Name = "SubaktivitasStartBongkarList-SubaktivitasStartBongkar-list")]
    [Route("Home/SubaktivitasStartBongkarList/{id?}", Name = "SubaktivitasStartBongkarList-SubaktivitasStartBongkar-list-2")]
    public async Task<IActionResult> SubaktivitasStartBongkarList()
    {
        // Create page object
        subaktivitasStartBongkarList = new GLOBALS.SubaktivitasStartBongkarList(this);
        subaktivitasStartBongkarList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasStartBongkarList.Run();
    }

    // edit
    [Route("SubaktivitasStartBongkarEdit/{id?}", Name = "SubaktivitasStartBongkarEdit-SubaktivitasStartBongkar-edit")]
    [Route("Home/SubaktivitasStartBongkarEdit/{id?}", Name = "SubaktivitasStartBongkarEdit-SubaktivitasStartBongkar-edit-2")]
    public async Task<IActionResult> SubaktivitasStartBongkarEdit()
    {
        // Create page object
        subaktivitasStartBongkarEdit = new GLOBALS.SubaktivitasStartBongkarEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasStartBongkarEdit.Run();
    }
}
