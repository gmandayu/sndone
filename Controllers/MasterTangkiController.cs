namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterTangkiList/{id?}", Name = "MasterTangkiList-MasterTangki-list")]
    [Route("Home/MasterTangkiList/{id?}", Name = "MasterTangkiList-MasterTangki-list-2")]
    public async Task<IActionResult> MasterTangkiList()
    {
        // Create page object
        masterTangkiList = new GLOBALS.MasterTangkiList(this);
        masterTangkiList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await masterTangkiList.Run();
    }

    // add
    [Route("MasterTangkiAdd/{id?}", Name = "MasterTangkiAdd-MasterTangki-add")]
    [Route("Home/MasterTangkiAdd/{id?}", Name = "MasterTangkiAdd-MasterTangki-add-2")]
    public async Task<IActionResult> MasterTangkiAdd()
    {
        // Create page object
        masterTangkiAdd = new GLOBALS.MasterTangkiAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await masterTangkiAdd.Run();
    }

    // view
    [Route("MasterTangkiView/{id?}", Name = "MasterTangkiView-MasterTangki-view")]
    [Route("Home/MasterTangkiView/{id?}", Name = "MasterTangkiView-MasterTangki-view-2")]
    public async Task<IActionResult> MasterTangkiView()
    {
        // Create page object
        masterTangkiView = new GLOBALS.MasterTangkiView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await masterTangkiView.Run();
    }

    // edit
    [Route("MasterTangkiEdit/{id?}", Name = "MasterTangkiEdit-MasterTangki-edit")]
    [Route("Home/MasterTangkiEdit/{id?}", Name = "MasterTangkiEdit-MasterTangki-edit-2")]
    public async Task<IActionResult> MasterTangkiEdit()
    {
        // Create page object
        masterTangkiEdit = new GLOBALS.MasterTangkiEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await masterTangkiEdit.Run();
    }

    // delete
    [Route("MasterTangkiDelete/{id?}", Name = "MasterTangkiDelete-MasterTangki-delete")]
    [Route("Home/MasterTangkiDelete/{id?}", Name = "MasterTangkiDelete-MasterTangki-delete-2")]
    public async Task<IActionResult> MasterTangkiDelete()
    {
        // Create page object
        masterTangkiDelete = new GLOBALS.MasterTangkiDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await masterTangkiDelete.Run();
    }
}
