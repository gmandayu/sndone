namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterPositionList/{IdPosition?}", Name = "MasterPositionList-MasterPosition-list")]
    [Route("Home/MasterPositionList/{IdPosition?}", Name = "MasterPositionList-MasterPosition-list-2")]
    public async Task<IActionResult> MasterPositionList()
    {
        // Create page object
        masterPositionList = new GLOBALS.MasterPositionList(this);
        masterPositionList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPosition"];

        // Run the page
        return await masterPositionList.Run();
    }

    // add
    [Route("MasterPositionAdd/{IdPosition?}", Name = "MasterPositionAdd-MasterPosition-add")]
    [Route("Home/MasterPositionAdd/{IdPosition?}", Name = "MasterPositionAdd-MasterPosition-add-2")]
    public async Task<IActionResult> MasterPositionAdd()
    {
        // Create page object
        masterPositionAdd = new GLOBALS.MasterPositionAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPosition"];

        // Run the page
        return await masterPositionAdd.Run();
    }

    // view
    [Route("MasterPositionView/{IdPosition?}", Name = "MasterPositionView-MasterPosition-view")]
    [Route("Home/MasterPositionView/{IdPosition?}", Name = "MasterPositionView-MasterPosition-view-2")]
    public async Task<IActionResult> MasterPositionView()
    {
        // Create page object
        masterPositionView = new GLOBALS.MasterPositionView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPosition"];

        // Run the page
        return await masterPositionView.Run();
    }

    // edit
    [Route("MasterPositionEdit/{IdPosition?}", Name = "MasterPositionEdit-MasterPosition-edit")]
    [Route("Home/MasterPositionEdit/{IdPosition?}", Name = "MasterPositionEdit-MasterPosition-edit-2")]
    public async Task<IActionResult> MasterPositionEdit()
    {
        // Create page object
        masterPositionEdit = new GLOBALS.MasterPositionEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPosition"];

        // Run the page
        return await masterPositionEdit.Run();
    }

    // delete
    [Route("MasterPositionDelete/{IdPosition?}", Name = "MasterPositionDelete-MasterPosition-delete")]
    [Route("Home/MasterPositionDelete/{IdPosition?}", Name = "MasterPositionDelete-MasterPosition-delete-2")]
    public async Task<IActionResult> MasterPositionDelete()
    {
        // Create page object
        masterPositionDelete = new GLOBALS.MasterPositionDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPosition"];

        // Run the page
        return await masterPositionDelete.Run();
    }
}
