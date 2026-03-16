namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("AktivitasDokumenList/{IdAktivitasDokumen?}", Name = "AktivitasDokumenList-AktivitasDokumen-list")]
    [Route("Home/AktivitasDokumenList/{IdAktivitasDokumen?}", Name = "AktivitasDokumenList-AktivitasDokumen-list-2")]
    public async Task<IActionResult> AktivitasDokumenList()
    {
        // Create page object
        aktivitasDokumenList = new GLOBALS.AktivitasDokumenList(this);
        aktivitasDokumenList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdAktivitasDokumen"];

        // Run the page
        return await aktivitasDokumenList.Run();
    }

    // view
    [Route("AktivitasDokumenView/{IdAktivitasDokumen?}", Name = "AktivitasDokumenView-AktivitasDokumen-view")]
    [Route("Home/AktivitasDokumenView/{IdAktivitasDokumen?}", Name = "AktivitasDokumenView-AktivitasDokumen-view-2")]
    public async Task<IActionResult> AktivitasDokumenView()
    {
        // Create page object
        aktivitasDokumenView = new GLOBALS.AktivitasDokumenView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdAktivitasDokumen"];

        // Run the page
        return await aktivitasDokumenView.Run();
    }
}
