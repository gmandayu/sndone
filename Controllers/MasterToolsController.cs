namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterToolsList/{IdTools?}", Name = "MasterToolsList-MasterTools-list")]
    [Route("Home/MasterToolsList/{IdTools?}", Name = "MasterToolsList-MasterTools-list-2")]
    public async Task<IActionResult> MasterToolsList()
    {
        // Create page object
        masterToolsList = new GLOBALS.MasterToolsList(this);
        masterToolsList.Cache = _cache;

        // Run the page
        return await masterToolsList.Run();
    }

    // add
    [Route("MasterToolsAdd/{IdTools?}", Name = "MasterToolsAdd-MasterTools-add")]
    [Route("Home/MasterToolsAdd/{IdTools?}", Name = "MasterToolsAdd-MasterTools-add-2")]
    public async Task<IActionResult> MasterToolsAdd()
    {
        // Create page object
        masterToolsAdd = new GLOBALS.MasterToolsAdd(this);

        // Run the page
        return await masterToolsAdd.Run();
    }

    // view
    [Route("MasterToolsView/{IdTools?}", Name = "MasterToolsView-MasterTools-view")]
    [Route("Home/MasterToolsView/{IdTools?}", Name = "MasterToolsView-MasterTools-view-2")]
    public async Task<IActionResult> MasterToolsView()
    {
        // Create page object
        masterToolsView = new GLOBALS.MasterToolsView(this);

        // Run the page
        return await masterToolsView.Run();
    }

    // edit
    [Route("MasterToolsEdit/{IdTools?}", Name = "MasterToolsEdit-MasterTools-edit")]
    [Route("Home/MasterToolsEdit/{IdTools?}", Name = "MasterToolsEdit-MasterTools-edit-2")]
    public async Task<IActionResult> MasterToolsEdit()
    {
        // Create page object
        masterToolsEdit = new GLOBALS.MasterToolsEdit(this);

        // Run the page
        return await masterToolsEdit.Run();
    }

    // delete
    [Route("MasterToolsDelete/{IdTools?}", Name = "MasterToolsDelete-MasterTools-delete")]
    [Route("Home/MasterToolsDelete/{IdTools?}", Name = "MasterToolsDelete-MasterTools-delete-2")]
    public async Task<IActionResult> MasterToolsDelete()
    {
        // Create page object
        masterToolsDelete = new GLOBALS.MasterToolsDelete(this);

        // Run the page
        return await masterToolsDelete.Run();
    }
}
