namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SetUserModList/{id?}", Name = "SetUserModList-SetUserMOD-list")]
    [Route("Home/SetUserModList/{id?}", Name = "SetUserModList-SetUserMOD-list-2")]
    public async Task<IActionResult> SetUserModList()
    {
        // Create page object
        setUserModList = new GLOBALS.SetUserModList(this);
        setUserModList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await setUserModList.Run();
    }

    // add
    [Route("SetUserModAdd/{id?}", Name = "SetUserModAdd-SetUserMOD-add")]
    [Route("Home/SetUserModAdd/{id?}", Name = "SetUserModAdd-SetUserMOD-add-2")]
    public async Task<IActionResult> SetUserModAdd()
    {
        // Create page object
        setUserModAdd = new GLOBALS.SetUserModAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await setUserModAdd.Run();
    }

    // view
    [Route("SetUserModView/{id?}", Name = "SetUserModView-SetUserMOD-view")]
    [Route("Home/SetUserModView/{id?}", Name = "SetUserModView-SetUserMOD-view-2")]
    public async Task<IActionResult> SetUserModView()
    {
        // Create page object
        setUserModView = new GLOBALS.SetUserModView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await setUserModView.Run();
    }

    // edit
    [Route("SetUserModEdit/{id?}", Name = "SetUserModEdit-SetUserMOD-edit")]
    [Route("Home/SetUserModEdit/{id?}", Name = "SetUserModEdit-SetUserMOD-edit-2")]
    public async Task<IActionResult> SetUserModEdit()
    {
        // Create page object
        setUserModEdit = new GLOBALS.SetUserModEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await setUserModEdit.Run();
    }

    // delete
    [Route("SetUserModDelete/{id?}", Name = "SetUserModDelete-SetUserMOD-delete")]
    [Route("Home/SetUserModDelete/{id?}", Name = "SetUserModDelete-SetUserMOD-delete-2")]
    public async Task<IActionResult> SetUserModDelete()
    {
        // Create page object
        setUserModDelete = new GLOBALS.SetUserModDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await setUserModDelete.Run();
    }
}
