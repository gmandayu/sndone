namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("PenerimaanList/{IdPenerimaan?}", Name = "PenerimaanList-Penerimaan-list")]
    [Route("Home/PenerimaanList/{IdPenerimaan?}", Name = "PenerimaanList-Penerimaan-list-2")]
    public async Task<IActionResult> PenerimaanList()
    {
        // Create page object
        penerimaanList = new GLOBALS.PenerimaanList(this);
        penerimaanList.Cache = _cache;

        // Run the page
        return await penerimaanList.Run();
    }

    // add
    [Route("PenerimaanAdd/{IdPenerimaan?}", Name = "PenerimaanAdd-Penerimaan-add")]
    [Route("Home/PenerimaanAdd/{IdPenerimaan?}", Name = "PenerimaanAdd-Penerimaan-add-2")]
    public async Task<IActionResult> PenerimaanAdd()
    {
        // Create page object
        penerimaanAdd = new GLOBALS.PenerimaanAdd(this);

        // Run the page
        return await penerimaanAdd.Run();
    }

    // view
    [Route("PenerimaanView/{IdPenerimaan?}", Name = "PenerimaanView-Penerimaan-view")]
    [Route("Home/PenerimaanView/{IdPenerimaan?}", Name = "PenerimaanView-Penerimaan-view-2")]
    public async Task<IActionResult> PenerimaanView()
    {
        // Create page object
        penerimaanView = new GLOBALS.PenerimaanView(this);

        // Run the page
        return await penerimaanView.Run();
    }

    // edit
    [Route("PenerimaanEdit/{IdPenerimaan?}", Name = "PenerimaanEdit-Penerimaan-edit")]
    [Route("Home/PenerimaanEdit/{IdPenerimaan?}", Name = "PenerimaanEdit-Penerimaan-edit-2")]
    public async Task<IActionResult> PenerimaanEdit()
    {
        // Create page object
        penerimaanEdit = new GLOBALS.PenerimaanEdit(this);

        // Run the page
        return await penerimaanEdit.Run();
    }

    // delete
    [Route("PenerimaanDelete/{IdPenerimaan?}", Name = "PenerimaanDelete-Penerimaan-delete")]
    [Route("Home/PenerimaanDelete/{IdPenerimaan?}", Name = "PenerimaanDelete-Penerimaan-delete-2")]
    public async Task<IActionResult> PenerimaanDelete()
    {
        // Create page object
        penerimaanDelete = new GLOBALS.PenerimaanDelete(this);

        // Run the page
        return await penerimaanDelete.Run();
    }

    // search
    [Route("PenerimaanSearch", Name = "PenerimaanSearch-Penerimaan-search")]
    [Route("Home/PenerimaanSearch", Name = "PenerimaanSearch-Penerimaan-search-2")]
    public async Task<IActionResult> PenerimaanSearch()
    {
        // Create page object
        penerimaanSearch = new GLOBALS.PenerimaanSearch(this);

        // Run the page
        return await penerimaanSearch.Run();
    }
}
