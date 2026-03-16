namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasKapalBerangkatList/{id?}", Name = "SubaktivitasKapalBerangkatList-SubaktivitasKapalBerangkat-list")]
    [Route("Home/SubaktivitasKapalBerangkatList/{id?}", Name = "SubaktivitasKapalBerangkatList-SubaktivitasKapalBerangkat-list-2")]
    public async Task<IActionResult> SubaktivitasKapalBerangkatList()
    {
        // Create page object
        subaktivitasKapalBerangkatList = new GLOBALS.SubaktivitasKapalBerangkatList(this);
        subaktivitasKapalBerangkatList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasKapalBerangkatList.Run();
    }

    // edit
    [Route("SubaktivitasKapalBerangkatEdit/{id?}", Name = "SubaktivitasKapalBerangkatEdit-SubaktivitasKapalBerangkat-edit")]
    [Route("Home/SubaktivitasKapalBerangkatEdit/{id?}", Name = "SubaktivitasKapalBerangkatEdit-SubaktivitasKapalBerangkat-edit-2")]
    public async Task<IActionResult> SubaktivitasKapalBerangkatEdit()
    {
        // Create page object
        subaktivitasKapalBerangkatEdit = new GLOBALS.SubaktivitasKapalBerangkatEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasKapalBerangkatEdit.Run();
    }
}
