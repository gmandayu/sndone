namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterPicList/{IdPIC?}", Name = "MasterPicList-MasterPIC-list")]
    [Route("Home/MasterPicList/{IdPIC?}", Name = "MasterPicList-MasterPIC-list-2")]
    public async Task<IActionResult> MasterPicList()
    {
        // Create page object
        masterPicList = new GLOBALS.MasterPicList(this);
        masterPicList.Cache = _cache;

        // Run the page
        return await masterPicList.Run();
    }

    // add
    [Route("MasterPicAdd/{IdPIC?}", Name = "MasterPicAdd-MasterPIC-add")]
    [Route("Home/MasterPicAdd/{IdPIC?}", Name = "MasterPicAdd-MasterPIC-add-2")]
    public async Task<IActionResult> MasterPicAdd()
    {
        // Create page object
        masterPicAdd = new GLOBALS.MasterPicAdd(this);

        // Run the page
        return await masterPicAdd.Run();
    }

    // view
    [Route("MasterPicView/{IdPIC?}", Name = "MasterPicView-MasterPIC-view")]
    [Route("Home/MasterPicView/{IdPIC?}", Name = "MasterPicView-MasterPIC-view-2")]
    public async Task<IActionResult> MasterPicView()
    {
        // Create page object
        masterPicView = new GLOBALS.MasterPicView(this);

        // Run the page
        return await masterPicView.Run();
    }

    // edit
    [Route("MasterPicEdit/{IdPIC?}", Name = "MasterPicEdit-MasterPIC-edit")]
    [Route("Home/MasterPicEdit/{IdPIC?}", Name = "MasterPicEdit-MasterPIC-edit-2")]
    public async Task<IActionResult> MasterPicEdit()
    {
        // Create page object
        masterPicEdit = new GLOBALS.MasterPicEdit(this);

        // Run the page
        return await masterPicEdit.Run();
    }

    // delete
    [Route("MasterPicDelete/{IdPIC?}", Name = "MasterPicDelete-MasterPIC-delete")]
    [Route("Home/MasterPicDelete/{IdPIC?}", Name = "MasterPicDelete-MasterPIC-delete-2")]
    public async Task<IActionResult> MasterPicDelete()
    {
        // Create page object
        masterPicDelete = new GLOBALS.MasterPicDelete(this);

        // Run the page
        return await masterPicDelete.Run();
    }
}
