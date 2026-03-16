namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("PenimbunanPenyaluranList/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranList-PenimbunanPenyaluran-list")]
    [Route("Home/PenimbunanPenyaluranList/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranList-PenimbunanPenyaluran-list-2")]
    public async Task<IActionResult> PenimbunanPenyaluranList()
    {
        // Create page object
        penimbunanPenyaluranList = new GLOBALS.PenimbunanPenyaluranList(this);
        penimbunanPenyaluranList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunanPenyaluran"];

        // Run the page
        return await penimbunanPenyaluranList.Run();
    }

    // add
    [Route("PenimbunanPenyaluranAdd/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranAdd-PenimbunanPenyaluran-add")]
    [Route("Home/PenimbunanPenyaluranAdd/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranAdd-PenimbunanPenyaluran-add-2")]
    public async Task<IActionResult> PenimbunanPenyaluranAdd()
    {
        // Create page object
        penimbunanPenyaluranAdd = new GLOBALS.PenimbunanPenyaluranAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunanPenyaluran"];

        // Run the page
        return await penimbunanPenyaluranAdd.Run();
    }

    // view
    [Route("PenimbunanPenyaluranView/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranView-PenimbunanPenyaluran-view")]
    [Route("Home/PenimbunanPenyaluranView/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranView-PenimbunanPenyaluran-view-2")]
    public async Task<IActionResult> PenimbunanPenyaluranView()
    {
        // Create page object
        penimbunanPenyaluranView = new GLOBALS.PenimbunanPenyaluranView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunanPenyaluran"];

        // Run the page
        return await penimbunanPenyaluranView.Run();
    }

    // edit
    [Route("PenimbunanPenyaluranEdit/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranEdit-PenimbunanPenyaluran-edit")]
    [Route("Home/PenimbunanPenyaluranEdit/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranEdit-PenimbunanPenyaluran-edit-2")]
    public async Task<IActionResult> PenimbunanPenyaluranEdit()
    {
        // Create page object
        penimbunanPenyaluranEdit = new GLOBALS.PenimbunanPenyaluranEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunanPenyaluran"];

        // Run the page
        return await penimbunanPenyaluranEdit.Run();
    }

    // delete
    [Route("PenimbunanPenyaluranDelete/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranDelete-PenimbunanPenyaluran-delete")]
    [Route("Home/PenimbunanPenyaluranDelete/{IdPenimbunanPenyaluran?}", Name = "PenimbunanPenyaluranDelete-PenimbunanPenyaluran-delete-2")]
    public async Task<IActionResult> PenimbunanPenyaluranDelete()
    {
        // Create page object
        penimbunanPenyaluranDelete = new GLOBALS.PenimbunanPenyaluranDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunanPenyaluran"];

        // Run the page
        return await penimbunanPenyaluranDelete.Run();
    }

    // search
    [Route("PenimbunanPenyaluranSearch", Name = "PenimbunanPenyaluranSearch-PenimbunanPenyaluran-search")]
    [Route("Home/PenimbunanPenyaluranSearch", Name = "PenimbunanPenyaluranSearch-PenimbunanPenyaluran-search-2")]
    public async Task<IActionResult> PenimbunanPenyaluranSearch()
    {
        // Create page object
        penimbunanPenyaluranSearch = new GLOBALS.PenimbunanPenyaluranSearch(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPenimbunanPenyaluran"];

        // Run the page
        return await penimbunanPenyaluranSearch.Run();
    }
}
