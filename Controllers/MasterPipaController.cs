namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterPipaList/{id?}", Name = "MasterPipaList-MasterPipa-list")]
    [Route("Home/MasterPipaList/{id?}", Name = "MasterPipaList-MasterPipa-list-2")]
    public async Task<IActionResult> MasterPipaList()
    {
        // Create page object
        masterPipaList = new GLOBALS.MasterPipaList(this);
        masterPipaList.Cache = _cache;

        // Run the page
        return await masterPipaList.Run();
    }

    // add
    [Route("MasterPipaAdd/{id?}", Name = "MasterPipaAdd-MasterPipa-add")]
    [Route("Home/MasterPipaAdd/{id?}", Name = "MasterPipaAdd-MasterPipa-add-2")]
    public async Task<IActionResult> MasterPipaAdd()
    {
        // Create page object
        masterPipaAdd = new GLOBALS.MasterPipaAdd(this);

        // Run the page
        return await masterPipaAdd.Run();
    }

    // view
    [Route("MasterPipaView/{id?}", Name = "MasterPipaView-MasterPipa-view")]
    [Route("Home/MasterPipaView/{id?}", Name = "MasterPipaView-MasterPipa-view-2")]
    public async Task<IActionResult> MasterPipaView()
    {
        // Create page object
        masterPipaView = new GLOBALS.MasterPipaView(this);

        // Run the page
        return await masterPipaView.Run();
    }

    // edit
    [Route("MasterPipaEdit/{id?}", Name = "MasterPipaEdit-MasterPipa-edit")]
    [Route("Home/MasterPipaEdit/{id?}", Name = "MasterPipaEdit-MasterPipa-edit-2")]
    public async Task<IActionResult> MasterPipaEdit()
    {
        // Create page object
        masterPipaEdit = new GLOBALS.MasterPipaEdit(this);

        // Run the page
        return await masterPipaEdit.Run();
    }

    // delete
    [Route("MasterPipaDelete/{id?}", Name = "MasterPipaDelete-MasterPipa-delete")]
    [Route("Home/MasterPipaDelete/{id?}", Name = "MasterPipaDelete-MasterPipa-delete-2")]
    public async Task<IActionResult> MasterPipaDelete()
    {
        // Create page object
        masterPipaDelete = new GLOBALS.MasterPipaDelete(this);

        // Run the page
        return await masterPipaDelete.Run();
    }
}
