namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataGerbongKetelRtwList/{id?}", Name = "SubAktivitasDataGerbongKetelRtwList-SubAktivitasDataGerbongKetelRTW-list")]
    [Route("Home/SubAktivitasDataGerbongKetelRtwList/{id?}", Name = "SubAktivitasDataGerbongKetelRtwList-SubAktivitasDataGerbongKetelRTW-list-2")]
    public async Task<IActionResult> SubAktivitasDataGerbongKetelRtwList()
    {
        // Create page object
        subAktivitasDataGerbongKetelRtwList = new GLOBALS.SubAktivitasDataGerbongKetelRtwList(this);
        subAktivitasDataGerbongKetelRtwList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataGerbongKetelRtwList.Run();
    }

    // add
    [Route("SubAktivitasDataGerbongKetelRtwAdd/{id?}", Name = "SubAktivitasDataGerbongKetelRtwAdd-SubAktivitasDataGerbongKetelRTW-add")]
    [Route("Home/SubAktivitasDataGerbongKetelRtwAdd/{id?}", Name = "SubAktivitasDataGerbongKetelRtwAdd-SubAktivitasDataGerbongKetelRTW-add-2")]
    public async Task<IActionResult> SubAktivitasDataGerbongKetelRtwAdd()
    {
        // Create page object
        subAktivitasDataGerbongKetelRtwAdd = new GLOBALS.SubAktivitasDataGerbongKetelRtwAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataGerbongKetelRtwAdd.Run();
    }

    // view
    [Route("SubAktivitasDataGerbongKetelRtwView/{id?}", Name = "SubAktivitasDataGerbongKetelRtwView-SubAktivitasDataGerbongKetelRTW-view")]
    [Route("Home/SubAktivitasDataGerbongKetelRtwView/{id?}", Name = "SubAktivitasDataGerbongKetelRtwView-SubAktivitasDataGerbongKetelRTW-view-2")]
    public async Task<IActionResult> SubAktivitasDataGerbongKetelRtwView()
    {
        // Create page object
        subAktivitasDataGerbongKetelRtwView = new GLOBALS.SubAktivitasDataGerbongKetelRtwView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataGerbongKetelRtwView.Run();
    }

    // edit
    [Route("SubAktivitasDataGerbongKetelRtwEdit/{id?}", Name = "SubAktivitasDataGerbongKetelRtwEdit-SubAktivitasDataGerbongKetelRTW-edit")]
    [Route("Home/SubAktivitasDataGerbongKetelRtwEdit/{id?}", Name = "SubAktivitasDataGerbongKetelRtwEdit-SubAktivitasDataGerbongKetelRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasDataGerbongKetelRtwEdit()
    {
        // Create page object
        subAktivitasDataGerbongKetelRtwEdit = new GLOBALS.SubAktivitasDataGerbongKetelRtwEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataGerbongKetelRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasDataGerbongKetelRtwDelete/{id?}", Name = "SubAktivitasDataGerbongKetelRtwDelete-SubAktivitasDataGerbongKetelRTW-delete")]
    [Route("Home/SubAktivitasDataGerbongKetelRtwDelete/{id?}", Name = "SubAktivitasDataGerbongKetelRtwDelete-SubAktivitasDataGerbongKetelRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasDataGerbongKetelRtwDelete()
    {
        // Create page object
        subAktivitasDataGerbongKetelRtwDelete = new GLOBALS.SubAktivitasDataGerbongKetelRtwDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataGerbongKetelRtwDelete.Run();
    }
}
