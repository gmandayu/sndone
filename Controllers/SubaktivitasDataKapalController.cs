namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasDataKapalList/{id?}", Name = "SubaktivitasDataKapalList-SubaktivitasDataKapal-list")]
    [Route("Home/SubaktivitasDataKapalList/{id?}", Name = "SubaktivitasDataKapalList-SubaktivitasDataKapal-list-2")]
    public async Task<IActionResult> SubaktivitasDataKapalList()
    {
        // Create page object
        subaktivitasDataKapalList = new GLOBALS.SubaktivitasDataKapalList(this);
        subaktivitasDataKapalList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasDataKapalList.Run();
    }

    // edit
    [Route("SubaktivitasDataKapalEdit/{id?}", Name = "SubaktivitasDataKapalEdit-SubaktivitasDataKapal-edit")]
    [Route("Home/SubaktivitasDataKapalEdit/{id?}", Name = "SubaktivitasDataKapalEdit-SubaktivitasDataKapal-edit-2")]
    public async Task<IActionResult> SubaktivitasDataKapalEdit()
    {
        // Create page object
        subaktivitasDataKapalEdit = new GLOBALS.SubaktivitasDataKapalEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasDataKapalEdit.Run();
    }
}
