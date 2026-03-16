namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStopPembongkaranRtwList/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwList-SubAktivitasDataStopPembongkaranRTW-list")]
    [Route("Home/SubAktivitasDataStopPembongkaranRtwList/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwList-SubAktivitasDataStopPembongkaranRTW-list-2")]
    public async Task<IActionResult> SubAktivitasDataStopPembongkaranRtwList()
    {
        // Create page object
        subAktivitasDataStopPembongkaranRtwList = new GLOBALS.SubAktivitasDataStopPembongkaranRtwList(this);
        subAktivitasDataStopPembongkaranRtwList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPembongkaranRtwList.Run();
    }

    // add
    [Route("SubAktivitasDataStopPembongkaranRtwAdd/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwAdd-SubAktivitasDataStopPembongkaranRTW-add")]
    [Route("Home/SubAktivitasDataStopPembongkaranRtwAdd/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwAdd-SubAktivitasDataStopPembongkaranRTW-add-2")]
    public async Task<IActionResult> SubAktivitasDataStopPembongkaranRtwAdd()
    {
        // Create page object
        subAktivitasDataStopPembongkaranRtwAdd = new GLOBALS.SubAktivitasDataStopPembongkaranRtwAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPembongkaranRtwAdd.Run();
    }

    // view
    [Route("SubAktivitasDataStopPembongkaranRtwView/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwView-SubAktivitasDataStopPembongkaranRTW-view")]
    [Route("Home/SubAktivitasDataStopPembongkaranRtwView/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwView-SubAktivitasDataStopPembongkaranRTW-view-2")]
    public async Task<IActionResult> SubAktivitasDataStopPembongkaranRtwView()
    {
        // Create page object
        subAktivitasDataStopPembongkaranRtwView = new GLOBALS.SubAktivitasDataStopPembongkaranRtwView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPembongkaranRtwView.Run();
    }

    // edit
    [Route("SubAktivitasDataStopPembongkaranRtwEdit/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwEdit-SubAktivitasDataStopPembongkaranRTW-edit")]
    [Route("Home/SubAktivitasDataStopPembongkaranRtwEdit/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwEdit-SubAktivitasDataStopPembongkaranRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStopPembongkaranRtwEdit()
    {
        // Create page object
        subAktivitasDataStopPembongkaranRtwEdit = new GLOBALS.SubAktivitasDataStopPembongkaranRtwEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPembongkaranRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasDataStopPembongkaranRtwDelete/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwDelete-SubAktivitasDataStopPembongkaranRTW-delete")]
    [Route("Home/SubAktivitasDataStopPembongkaranRtwDelete/{id?}", Name = "SubAktivitasDataStopPembongkaranRtwDelete-SubAktivitasDataStopPembongkaranRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasDataStopPembongkaranRtwDelete()
    {
        // Create page object
        subAktivitasDataStopPembongkaranRtwDelete = new GLOBALS.SubAktivitasDataStopPembongkaranRtwDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStopPembongkaranRtwDelete.Run();
    }
}
