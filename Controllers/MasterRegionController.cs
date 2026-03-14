namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterRegionList/{IdRegion?}", Name = "MasterRegionList-MasterRegion-list")]
    [Route("Home/MasterRegionList/{IdRegion?}", Name = "MasterRegionList-MasterRegion-list-2")]
    public async Task<IActionResult> MasterRegionList()
    {
        // Create page object
        masterRegionList = new GLOBALS.MasterRegionList(this);
        masterRegionList.Cache = _cache;

        // Run the page
        return await masterRegionList.Run();
    }

    // add
    [Route("MasterRegionAdd/{IdRegion?}", Name = "MasterRegionAdd-MasterRegion-add")]
    [Route("Home/MasterRegionAdd/{IdRegion?}", Name = "MasterRegionAdd-MasterRegion-add-2")]
    public async Task<IActionResult> MasterRegionAdd()
    {
        // Create page object
        masterRegionAdd = new GLOBALS.MasterRegionAdd(this);

        // Run the page
        return await masterRegionAdd.Run();
    }

    // view
    [Route("MasterRegionView/{IdRegion?}", Name = "MasterRegionView-MasterRegion-view")]
    [Route("Home/MasterRegionView/{IdRegion?}", Name = "MasterRegionView-MasterRegion-view-2")]
    public async Task<IActionResult> MasterRegionView()
    {
        // Create page object
        masterRegionView = new GLOBALS.MasterRegionView(this);

        // Run the page
        return await masterRegionView.Run();
    }

    // edit
    [Route("MasterRegionEdit/{IdRegion?}", Name = "MasterRegionEdit-MasterRegion-edit")]
    [Route("Home/MasterRegionEdit/{IdRegion?}", Name = "MasterRegionEdit-MasterRegion-edit-2")]
    public async Task<IActionResult> MasterRegionEdit()
    {
        // Create page object
        masterRegionEdit = new GLOBALS.MasterRegionEdit(this);

        // Run the page
        return await masterRegionEdit.Run();
    }

    // delete
    [Route("MasterRegionDelete/{IdRegion?}", Name = "MasterRegionDelete-MasterRegion-delete")]
    [Route("Home/MasterRegionDelete/{IdRegion?}", Name = "MasterRegionDelete-MasterRegion-delete-2")]
    public async Task<IActionResult> MasterRegionDelete()
    {
        // Create page object
        masterRegionDelete = new GLOBALS.MasterRegionDelete(this);

        // Run the page
        return await masterRegionDelete.Run();
    }
}
