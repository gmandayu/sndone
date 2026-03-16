namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputFlowrateRtwList/{id?}", Name = "SubAktivitasInputFlowrateRtwList-SubAktivitasInputFlowrateRTW-list")]
    [Route("Home/SubAktivitasInputFlowrateRtwList/{id?}", Name = "SubAktivitasInputFlowrateRtwList-SubAktivitasInputFlowrateRTW-list-2")]
    public async Task<IActionResult> SubAktivitasInputFlowrateRtwList()
    {
        // Create page object
        subAktivitasInputFlowrateRtwList = new GLOBALS.SubAktivitasInputFlowrateRtwList(this);
        subAktivitasInputFlowrateRtwList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasInputFlowrateRtwList.Run();
    }

    // edit
    [Route("SubAktivitasInputFlowrateRtwEdit/{id?}", Name = "SubAktivitasInputFlowrateRtwEdit-SubAktivitasInputFlowrateRTW-edit")]
    [Route("Home/SubAktivitasInputFlowrateRtwEdit/{id?}", Name = "SubAktivitasInputFlowrateRtwEdit-SubAktivitasInputFlowrateRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasInputFlowrateRtwEdit()
    {
        // Create page object
        subAktivitasInputFlowrateRtwEdit = new GLOBALS.SubAktivitasInputFlowrateRtwEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasInputFlowrateRtwEdit.Run();
    }
}
