namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterProdukList/{NoProduk?}", Name = "MasterProdukList-MasterProduk-list")]
    [Route("Home/MasterProdukList/{NoProduk?}", Name = "MasterProdukList-MasterProduk-list-2")]
    public async Task<IActionResult> MasterProdukList()
    {
        // Create page object
        masterProdukList = new GLOBALS.MasterProdukList(this);
        masterProdukList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["NoProduk"];

        // Run the page
        return await masterProdukList.Run();
    }

    // add
    [Route("MasterProdukAdd/{NoProduk?}", Name = "MasterProdukAdd-MasterProduk-add")]
    [Route("Home/MasterProdukAdd/{NoProduk?}", Name = "MasterProdukAdd-MasterProduk-add-2")]
    public async Task<IActionResult> MasterProdukAdd()
    {
        // Create page object
        masterProdukAdd = new GLOBALS.MasterProdukAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["NoProduk"];

        // Run the page
        return await masterProdukAdd.Run();
    }

    // view
    [Route("MasterProdukView/{NoProduk?}", Name = "MasterProdukView-MasterProduk-view")]
    [Route("Home/MasterProdukView/{NoProduk?}", Name = "MasterProdukView-MasterProduk-view-2")]
    public async Task<IActionResult> MasterProdukView()
    {
        // Create page object
        masterProdukView = new GLOBALS.MasterProdukView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["NoProduk"];

        // Run the page
        return await masterProdukView.Run();
    }

    // edit
    [Route("MasterProdukEdit/{NoProduk?}", Name = "MasterProdukEdit-MasterProduk-edit")]
    [Route("Home/MasterProdukEdit/{NoProduk?}", Name = "MasterProdukEdit-MasterProduk-edit-2")]
    public async Task<IActionResult> MasterProdukEdit()
    {
        // Create page object
        masterProdukEdit = new GLOBALS.MasterProdukEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["NoProduk"];

        // Run the page
        return await masterProdukEdit.Run();
    }

    // delete
    [Route("MasterProdukDelete/{NoProduk?}", Name = "MasterProdukDelete-MasterProduk-delete")]
    [Route("Home/MasterProdukDelete/{NoProduk?}", Name = "MasterProdukDelete-MasterProduk-delete-2")]
    public async Task<IActionResult> MasterProdukDelete()
    {
        // Create page object
        masterProdukDelete = new GLOBALS.MasterProdukDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["NoProduk"];

        // Run the page
        return await masterProdukDelete.Run();
    }
}
