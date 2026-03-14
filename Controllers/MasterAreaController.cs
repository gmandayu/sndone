namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterAreaList/{ID?}", Name = "MasterAreaList-MasterArea-list")]
    [Route("Home/MasterAreaList/{ID?}", Name = "MasterAreaList-MasterArea-list-2")]
    public async Task<IActionResult> MasterAreaList()
    {
        // Create page object
        masterAreaList = new GLOBALS.MasterAreaList(this);
        masterAreaList.Cache = _cache;

        // Run the page
        return await masterAreaList.Run();
    }

    // add
    [Route("MasterAreaAdd/{ID?}", Name = "MasterAreaAdd-MasterArea-add")]
    [Route("Home/MasterAreaAdd/{ID?}", Name = "MasterAreaAdd-MasterArea-add-2")]
    public async Task<IActionResult> MasterAreaAdd()
    {
        // Create page object
        masterAreaAdd = new GLOBALS.MasterAreaAdd(this);

        // Run the page
        return await masterAreaAdd.Run();
    }

    // view
    [Route("MasterAreaView/{ID?}", Name = "MasterAreaView-MasterArea-view")]
    [Route("Home/MasterAreaView/{ID?}", Name = "MasterAreaView-MasterArea-view-2")]
    public async Task<IActionResult> MasterAreaView()
    {
        // Create page object
        masterAreaView = new GLOBALS.MasterAreaView(this);

        // Run the page
        return await masterAreaView.Run();
    }

    // edit
    [Route("MasterAreaEdit/{ID?}", Name = "MasterAreaEdit-MasterArea-edit")]
    [Route("Home/MasterAreaEdit/{ID?}", Name = "MasterAreaEdit-MasterArea-edit-2")]
    public async Task<IActionResult> MasterAreaEdit()
    {
        // Create page object
        masterAreaEdit = new GLOBALS.MasterAreaEdit(this);

        // Run the page
        return await masterAreaEdit.Run();
    }

    // delete
    [Route("MasterAreaDelete/{ID?}", Name = "MasterAreaDelete-MasterArea-delete")]
    [Route("Home/MasterAreaDelete/{ID?}", Name = "MasterAreaDelete-MasterArea-delete-2")]
    public async Task<IActionResult> MasterAreaDelete()
    {
        // Create page object
        masterAreaDelete = new GLOBALS.MasterAreaDelete(this);

        // Run the page
        return await masterAreaDelete.Run();
    }
}
