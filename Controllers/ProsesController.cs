namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("ProsesList/{IdProses?}", Name = "ProsesList-Proses-list")]
    [Route("Home/ProsesList/{IdProses?}", Name = "ProsesList-Proses-list-2")]
    public async Task<IActionResult> ProsesList()
    {
        // Create page object
        prosesList = new GLOBALS.ProsesList(this);
        prosesList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdProses"];

        // Run the page
        return await prosesList.Run();
    }

    // view
    [Route("ProsesView/{IdProses?}", Name = "ProsesView-Proses-view")]
    [Route("Home/ProsesView/{IdProses?}", Name = "ProsesView-Proses-view-2")]
    public async Task<IActionResult> ProsesView()
    {
        // Create page object
        prosesView = new GLOBALS.ProsesView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdProses"];

        // Run the page
        return await prosesView.Run();
    }
}
