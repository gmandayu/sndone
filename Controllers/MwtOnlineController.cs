namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MwtOnlineList/{Id?}", Name = "MwtOnlineList-MWTOnline-list")]
    [Route("Home/MwtOnlineList/{Id?}", Name = "MwtOnlineList-MWTOnline-list-2")]
    public async Task<IActionResult> MwtOnlineList()
    {
        // Create page object
        mwtOnlineList = new GLOBALS.MwtOnlineList(this);
        mwtOnlineList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["Id"];

        // Run the page
        return await mwtOnlineList.Run();
    }

    // add
    [Route("MwtOnlineAdd/{Id?}", Name = "MwtOnlineAdd-MWTOnline-add")]
    [Route("Home/MwtOnlineAdd/{Id?}", Name = "MwtOnlineAdd-MWTOnline-add-2")]
    public async Task<IActionResult> MwtOnlineAdd()
    {
        // Create page object
        mwtOnlineAdd = new GLOBALS.MwtOnlineAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["Id"];

        // Run the page
        return await mwtOnlineAdd.Run();
    }

    // edit
    [Route("MwtOnlineEdit/{Id?}", Name = "MwtOnlineEdit-MWTOnline-edit")]
    [Route("Home/MwtOnlineEdit/{Id?}", Name = "MwtOnlineEdit-MWTOnline-edit-2")]
    public async Task<IActionResult> MwtOnlineEdit()
    {
        // Create page object
        mwtOnlineEdit = new GLOBALS.MwtOnlineEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["Id"];

        // Run the page
        return await mwtOnlineEdit.Run();
    }

    // delete
    [Route("MwtOnlineDelete/{Id?}", Name = "MwtOnlineDelete-MWTOnline-delete")]
    [Route("Home/MwtOnlineDelete/{Id?}", Name = "MwtOnlineDelete-MWTOnline-delete-2")]
    public async Task<IActionResult> MwtOnlineDelete()
    {
        // Create page object
        mwtOnlineDelete = new GLOBALS.MwtOnlineDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["Id"];

        // Run the page
        return await mwtOnlineDelete.Run();
    }
}
