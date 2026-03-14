namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("PenyaluranList/{IdPenyaluran?}", Name = "PenyaluranList-Penyaluran-list")]
    [Route("Home/PenyaluranList/{IdPenyaluran?}", Name = "PenyaluranList-Penyaluran-list-2")]
    public async Task<IActionResult> PenyaluranList()
    {
        // Create page object
        penyaluranList = new GLOBALS.PenyaluranList(this);
        penyaluranList.Cache = _cache;

        // Run the page
        return await penyaluranList.Run();
    }

    // add
    [Route("PenyaluranAdd/{IdPenyaluran?}", Name = "PenyaluranAdd-Penyaluran-add")]
    [Route("Home/PenyaluranAdd/{IdPenyaluran?}", Name = "PenyaluranAdd-Penyaluran-add-2")]
    public async Task<IActionResult> PenyaluranAdd()
    {
        // Create page object
        penyaluranAdd = new GLOBALS.PenyaluranAdd(this);

        // Run the page
        return await penyaluranAdd.Run();
    }

    // view
    [Route("PenyaluranView/{IdPenyaluran?}", Name = "PenyaluranView-Penyaluran-view")]
    [Route("Home/PenyaluranView/{IdPenyaluran?}", Name = "PenyaluranView-Penyaluran-view-2")]
    public async Task<IActionResult> PenyaluranView()
    {
        // Create page object
        penyaluranView = new GLOBALS.PenyaluranView(this);

        // Run the page
        return await penyaluranView.Run();
    }

    // edit
    [Route("PenyaluranEdit/{IdPenyaluran?}", Name = "PenyaluranEdit-Penyaluran-edit")]
    [Route("Home/PenyaluranEdit/{IdPenyaluran?}", Name = "PenyaluranEdit-Penyaluran-edit-2")]
    public async Task<IActionResult> PenyaluranEdit()
    {
        // Create page object
        penyaluranEdit = new GLOBALS.PenyaluranEdit(this);

        // Run the page
        return await penyaluranEdit.Run();
    }

    // delete
    [Route("PenyaluranDelete/{IdPenyaluran?}", Name = "PenyaluranDelete-Penyaluran-delete")]
    [Route("Home/PenyaluranDelete/{IdPenyaluran?}", Name = "PenyaluranDelete-Penyaluran-delete-2")]
    public async Task<IActionResult> PenyaluranDelete()
    {
        // Create page object
        penyaluranDelete = new GLOBALS.PenyaluranDelete(this);

        // Run the page
        return await penyaluranDelete.Run();
    }

    // search
    [Route("PenyaluranSearch", Name = "PenyaluranSearch-Penyaluran-search")]
    [Route("Home/PenyaluranSearch", Name = "PenyaluranSearch-Penyaluran-search-2")]
    public async Task<IActionResult> PenyaluranSearch()
    {
        // Create page object
        penyaluranSearch = new GLOBALS.PenyaluranSearch(this);

        // Run the page
        return await penyaluranSearch.Run();
    }
}
