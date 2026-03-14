namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SetPjsList/{Id?}", Name = "SetPjsList-SetPjs-list")]
    [Route("Home/SetPjsList/{Id?}", Name = "SetPjsList-SetPjs-list-2")]
    public async Task<IActionResult> SetPjsList()
    {
        // Create page object
        setPjsList = new GLOBALS.SetPjsList(this);
        setPjsList.Cache = _cache;

        // Run the page
        return await setPjsList.Run();
    }

    // add
    [Route("SetPjsAdd/{Id?}", Name = "SetPjsAdd-SetPjs-add")]
    [Route("Home/SetPjsAdd/{Id?}", Name = "SetPjsAdd-SetPjs-add-2")]
    public async Task<IActionResult> SetPjsAdd()
    {
        // Create page object
        setPjsAdd = new GLOBALS.SetPjsAdd(this);

        // Run the page
        return await setPjsAdd.Run();
    }

    // view
    [Route("SetPjsView/{Id?}", Name = "SetPjsView-SetPjs-view")]
    [Route("Home/SetPjsView/{Id?}", Name = "SetPjsView-SetPjs-view-2")]
    public async Task<IActionResult> SetPjsView()
    {
        // Create page object
        setPjsView = new GLOBALS.SetPjsView(this);

        // Run the page
        return await setPjsView.Run();
    }

    // edit
    [Route("SetPjsEdit/{Id?}", Name = "SetPjsEdit-SetPjs-edit")]
    [Route("Home/SetPjsEdit/{Id?}", Name = "SetPjsEdit-SetPjs-edit-2")]
    public async Task<IActionResult> SetPjsEdit()
    {
        // Create page object
        setPjsEdit = new GLOBALS.SetPjsEdit(this);

        // Run the page
        return await setPjsEdit.Run();
    }

    // delete
    [Route("SetPjsDelete/{Id?}", Name = "SetPjsDelete-SetPjs-delete")]
    [Route("Home/SetPjsDelete/{Id?}", Name = "SetPjsDelete-SetPjs-delete-2")]
    public async Task<IActionResult> SetPjsDelete()
    {
        // Create page object
        setPjsDelete = new GLOBALS.SetPjsDelete(this);

        // Run the page
        return await setPjsDelete.Run();
    }
}
