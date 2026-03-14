namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("DetailMasterPipaList/{id?}", Name = "DetailMasterPipaList-DetailMasterPipa-list")]
    [Route("Home/DetailMasterPipaList/{id?}", Name = "DetailMasterPipaList-DetailMasterPipa-list-2")]
    public async Task<IActionResult> DetailMasterPipaList()
    {
        // Create page object
        detailMasterPipaList = new GLOBALS.DetailMasterPipaList(this);
        detailMasterPipaList.Cache = _cache;

        // Run the page
        return await detailMasterPipaList.Run();
    }

    // add
    [Route("DetailMasterPipaAdd/{id?}", Name = "DetailMasterPipaAdd-DetailMasterPipa-add")]
    [Route("Home/DetailMasterPipaAdd/{id?}", Name = "DetailMasterPipaAdd-DetailMasterPipa-add-2")]
    public async Task<IActionResult> DetailMasterPipaAdd()
    {
        // Create page object
        detailMasterPipaAdd = new GLOBALS.DetailMasterPipaAdd(this);

        // Run the page
        return await detailMasterPipaAdd.Run();
    }

    // view
    [Route("DetailMasterPipaView/{id?}", Name = "DetailMasterPipaView-DetailMasterPipa-view")]
    [Route("Home/DetailMasterPipaView/{id?}", Name = "DetailMasterPipaView-DetailMasterPipa-view-2")]
    public async Task<IActionResult> DetailMasterPipaView()
    {
        // Create page object
        detailMasterPipaView = new GLOBALS.DetailMasterPipaView(this);

        // Run the page
        return await detailMasterPipaView.Run();
    }

    // edit
    [Route("DetailMasterPipaEdit/{id?}", Name = "DetailMasterPipaEdit-DetailMasterPipa-edit")]
    [Route("Home/DetailMasterPipaEdit/{id?}", Name = "DetailMasterPipaEdit-DetailMasterPipa-edit-2")]
    public async Task<IActionResult> DetailMasterPipaEdit()
    {
        // Create page object
        detailMasterPipaEdit = new GLOBALS.DetailMasterPipaEdit(this);

        // Run the page
        return await detailMasterPipaEdit.Run();
    }

    // delete
    [Route("DetailMasterPipaDelete/{id?}", Name = "DetailMasterPipaDelete-DetailMasterPipa-delete")]
    [Route("Home/DetailMasterPipaDelete/{id?}", Name = "DetailMasterPipaDelete-DetailMasterPipa-delete-2")]
    public async Task<IActionResult> DetailMasterPipaDelete()
    {
        // Create page object
        detailMasterPipaDelete = new GLOBALS.DetailMasterPipaDelete(this);

        // Run the page
        return await detailMasterPipaDelete.Run();
    }
}
