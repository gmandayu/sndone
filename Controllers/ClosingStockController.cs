namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("ClosingStockList/{IdClosingStock?}", Name = "ClosingStockList-ClosingStock-list")]
    [Route("Home/ClosingStockList/{IdClosingStock?}", Name = "ClosingStockList-ClosingStock-list-2")]
    public async Task<IActionResult> ClosingStockList()
    {
        // Create page object
        closingStockList = new GLOBALS.ClosingStockList(this);
        closingStockList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdClosingStock"];

        // Run the page
        return await closingStockList.Run();
    }

    // add
    [Route("ClosingStockAdd/{IdClosingStock?}", Name = "ClosingStockAdd-ClosingStock-add")]
    [Route("Home/ClosingStockAdd/{IdClosingStock?}", Name = "ClosingStockAdd-ClosingStock-add-2")]
    public async Task<IActionResult> ClosingStockAdd()
    {
        // Create page object
        closingStockAdd = new GLOBALS.ClosingStockAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdClosingStock"];

        // Run the page
        return await closingStockAdd.Run();
    }

    // view
    [Route("ClosingStockView/{IdClosingStock?}", Name = "ClosingStockView-ClosingStock-view")]
    [Route("Home/ClosingStockView/{IdClosingStock?}", Name = "ClosingStockView-ClosingStock-view-2")]
    public async Task<IActionResult> ClosingStockView()
    {
        // Create page object
        closingStockView = new GLOBALS.ClosingStockView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdClosingStock"];

        // Run the page
        return await closingStockView.Run();
    }

    // edit
    [Route("ClosingStockEdit/{IdClosingStock?}", Name = "ClosingStockEdit-ClosingStock-edit")]
    [Route("Home/ClosingStockEdit/{IdClosingStock?}", Name = "ClosingStockEdit-ClosingStock-edit-2")]
    public async Task<IActionResult> ClosingStockEdit()
    {
        // Create page object
        closingStockEdit = new GLOBALS.ClosingStockEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdClosingStock"];

        // Run the page
        return await closingStockEdit.Run();
    }

    // delete
    [Route("ClosingStockDelete/{IdClosingStock?}", Name = "ClosingStockDelete-ClosingStock-delete")]
    [Route("Home/ClosingStockDelete/{IdClosingStock?}", Name = "ClosingStockDelete-ClosingStock-delete-2")]
    public async Task<IActionResult> ClosingStockDelete()
    {
        // Create page object
        closingStockDelete = new GLOBALS.ClosingStockDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdClosingStock"];

        // Run the page
        return await closingStockDelete.Run();
    }

    // search
    [Route("ClosingStockSearch", Name = "ClosingStockSearch-ClosingStock-search")]
    [Route("Home/ClosingStockSearch", Name = "ClosingStockSearch-ClosingStock-search-2")]
    public async Task<IActionResult> ClosingStockSearch()
    {
        // Create page object
        closingStockSearch = new GLOBALS.ClosingStockSearch(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdClosingStock"];

        // Run the page
        return await closingStockSearch.Run();
    }
}
