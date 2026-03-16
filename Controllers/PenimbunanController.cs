namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("PenimbunanList/{IdPenimbunan?}", Name = "PenimbunanList-Penimbunan-list")]
    [Route("Home/PenimbunanList/{IdPenimbunan?}", Name = "PenimbunanList-Penimbunan-list-2")]
    public async Task<IActionResult> PenimbunanList()
    {
        // Create page object
        penimbunanList = new GLOBALS.PenimbunanList(this);
        penimbunanList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunan"];

        // Run the page
        return await penimbunanList.Run();
    }

    // add
    [Route("PenimbunanAdd/{IdPenimbunan?}", Name = "PenimbunanAdd-Penimbunan-add")]
    [Route("Home/PenimbunanAdd/{IdPenimbunan?}", Name = "PenimbunanAdd-Penimbunan-add-2")]
    public async Task<IActionResult> PenimbunanAdd()
    {
        // Create page object
        penimbunanAdd = new GLOBALS.PenimbunanAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunan"];

        // Run the page
        return await penimbunanAdd.Run();
    }

    // view
    [Route("PenimbunanView/{IdPenimbunan?}", Name = "PenimbunanView-Penimbunan-view")]
    [Route("Home/PenimbunanView/{IdPenimbunan?}", Name = "PenimbunanView-Penimbunan-view-2")]
    public async Task<IActionResult> PenimbunanView()
    {
        // Create page object
        penimbunanView = new GLOBALS.PenimbunanView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunan"];

        // Run the page
        return await penimbunanView.Run();
    }

    // edit
    [Route("PenimbunanEdit/{IdPenimbunan?}", Name = "PenimbunanEdit-Penimbunan-edit")]
    [Route("Home/PenimbunanEdit/{IdPenimbunan?}", Name = "PenimbunanEdit-Penimbunan-edit-2")]
    public async Task<IActionResult> PenimbunanEdit()
    {
        // Create page object
        penimbunanEdit = new GLOBALS.PenimbunanEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunan"];

        // Run the page
        return await penimbunanEdit.Run();
    }

    // delete
    [Route("PenimbunanDelete/{IdPenimbunan?}", Name = "PenimbunanDelete-Penimbunan-delete")]
    [Route("Home/PenimbunanDelete/{IdPenimbunan?}", Name = "PenimbunanDelete-Penimbunan-delete-2")]
    public async Task<IActionResult> PenimbunanDelete()
    {
        // Create page object
        penimbunanDelete = new GLOBALS.PenimbunanDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunan"];

        // Run the page
        return await penimbunanDelete.Run();
    }

    // search
    [Route("PenimbunanSearch", Name = "PenimbunanSearch-Penimbunan-search")]
    [Route("Home/PenimbunanSearch", Name = "PenimbunanSearch-Penimbunan-search-2")]
    public async Task<IActionResult> PenimbunanSearch()
    {
        // Create page object
        penimbunanSearch = new GLOBALS.PenimbunanSearch(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunan"];

        // Run the page
        return await penimbunanSearch.Run();
    }
}
