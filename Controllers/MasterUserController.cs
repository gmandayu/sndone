namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterUserList/{IdUser?}", Name = "MasterUserList-MasterUser-list")]
    [Route("Home/MasterUserList/{IdUser?}", Name = "MasterUserList-MasterUser-list-2")]
    public async Task<IActionResult> MasterUserList()
    {
        // Create page object
        masterUserList = new GLOBALS.MasterUserList(this);
        masterUserList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdUser"];

        // Run the page
        return await masterUserList.Run();
    }

    // add
    [Route("MasterUserAdd/{IdUser?}", Name = "MasterUserAdd-MasterUser-add")]
    [Route("Home/MasterUserAdd/{IdUser?}", Name = "MasterUserAdd-MasterUser-add-2")]
    public async Task<IActionResult> MasterUserAdd()
    {
        // Create page object
        masterUserAdd = new GLOBALS.MasterUserAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdUser"];

        // Run the page
        return await masterUserAdd.Run();
    }

    // view
    [Route("MasterUserView/{IdUser?}", Name = "MasterUserView-MasterUser-view")]
    [Route("Home/MasterUserView/{IdUser?}", Name = "MasterUserView-MasterUser-view-2")]
    public async Task<IActionResult> MasterUserView()
    {
        // Create page object
        masterUserView = new GLOBALS.MasterUserView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdUser"];

        // Run the page
        return await masterUserView.Run();
    }

    // edit
    [Route("MasterUserEdit/{IdUser?}", Name = "MasterUserEdit-MasterUser-edit")]
    [Route("Home/MasterUserEdit/{IdUser?}", Name = "MasterUserEdit-MasterUser-edit-2")]
    public async Task<IActionResult> MasterUserEdit()
    {
        // Create page object
        masterUserEdit = new GLOBALS.MasterUserEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdUser"];

        // Run the page
        return await masterUserEdit.Run();
    }

    // delete
    [Route("MasterUserDelete/{IdUser?}", Name = "MasterUserDelete-MasterUser-delete")]
    [Route("Home/MasterUserDelete/{IdUser?}", Name = "MasterUserDelete-MasterUser-delete-2")]
    public async Task<IActionResult> MasterUserDelete()
    {
        // Create page object
        masterUserDelete = new GLOBALS.MasterUserDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdUser"];

        // Run the page
        return await masterUserDelete.Run();
    }
}
