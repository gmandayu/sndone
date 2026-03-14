namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterFungsiKunjunganList/{ID?}", Name = "MasterFungsiKunjunganList-MasterFungsiKunjungan-list")]
    [Route("Home/MasterFungsiKunjunganList/{ID?}", Name = "MasterFungsiKunjunganList-MasterFungsiKunjungan-list-2")]
    public async Task<IActionResult> MasterFungsiKunjunganList()
    {
        // Create page object
        masterFungsiKunjunganList = new GLOBALS.MasterFungsiKunjunganList(this);
        masterFungsiKunjunganList.Cache = _cache;

        // Run the page
        return await masterFungsiKunjunganList.Run();
    }

    // add
    [Route("MasterFungsiKunjunganAdd/{ID?}", Name = "MasterFungsiKunjunganAdd-MasterFungsiKunjungan-add")]
    [Route("Home/MasterFungsiKunjunganAdd/{ID?}", Name = "MasterFungsiKunjunganAdd-MasterFungsiKunjungan-add-2")]
    public async Task<IActionResult> MasterFungsiKunjunganAdd()
    {
        // Create page object
        masterFungsiKunjunganAdd = new GLOBALS.MasterFungsiKunjunganAdd(this);

        // Run the page
        return await masterFungsiKunjunganAdd.Run();
    }

    // view
    [Route("MasterFungsiKunjunganView/{ID?}", Name = "MasterFungsiKunjunganView-MasterFungsiKunjungan-view")]
    [Route("Home/MasterFungsiKunjunganView/{ID?}", Name = "MasterFungsiKunjunganView-MasterFungsiKunjungan-view-2")]
    public async Task<IActionResult> MasterFungsiKunjunganView()
    {
        // Create page object
        masterFungsiKunjunganView = new GLOBALS.MasterFungsiKunjunganView(this);

        // Run the page
        return await masterFungsiKunjunganView.Run();
    }

    // edit
    [Route("MasterFungsiKunjunganEdit/{ID?}", Name = "MasterFungsiKunjunganEdit-MasterFungsiKunjungan-edit")]
    [Route("Home/MasterFungsiKunjunganEdit/{ID?}", Name = "MasterFungsiKunjunganEdit-MasterFungsiKunjungan-edit-2")]
    public async Task<IActionResult> MasterFungsiKunjunganEdit()
    {
        // Create page object
        masterFungsiKunjunganEdit = new GLOBALS.MasterFungsiKunjunganEdit(this);

        // Run the page
        return await masterFungsiKunjunganEdit.Run();
    }

    // delete
    [Route("MasterFungsiKunjunganDelete/{ID?}", Name = "MasterFungsiKunjunganDelete-MasterFungsiKunjungan-delete")]
    [Route("Home/MasterFungsiKunjunganDelete/{ID?}", Name = "MasterFungsiKunjunganDelete-MasterFungsiKunjungan-delete-2")]
    public async Task<IActionResult> MasterFungsiKunjunganDelete()
    {
        // Create page object
        masterFungsiKunjunganDelete = new GLOBALS.MasterFungsiKunjunganDelete(this);

        // Run the page
        return await masterFungsiKunjunganDelete.Run();
    }
}
