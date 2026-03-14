namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("RencanaPenyaluranList/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranList-RencanaPenyaluran-list")]
    [Route("Home/RencanaPenyaluranList/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranList-RencanaPenyaluran-list-2")]
    public async Task<IActionResult> RencanaPenyaluranList()
    {
        // Create page object
        rencanaPenyaluranList = new GLOBALS.RencanaPenyaluranList(this);
        rencanaPenyaluranList.Cache = _cache;

        // Run the page
        return await rencanaPenyaluranList.Run();
    }

    // add
    [Route("RencanaPenyaluranAdd/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranAdd-RencanaPenyaluran-add")]
    [Route("Home/RencanaPenyaluranAdd/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranAdd-RencanaPenyaluran-add-2")]
    public async Task<IActionResult> RencanaPenyaluranAdd()
    {
        // Create page object
        rencanaPenyaluranAdd = new GLOBALS.RencanaPenyaluranAdd(this);

        // Run the page
        return await rencanaPenyaluranAdd.Run();
    }

    // view
    [Route("RencanaPenyaluranView/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranView-RencanaPenyaluran-view")]
    [Route("Home/RencanaPenyaluranView/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranView-RencanaPenyaluran-view-2")]
    public async Task<IActionResult> RencanaPenyaluranView()
    {
        // Create page object
        rencanaPenyaluranView = new GLOBALS.RencanaPenyaluranView(this);

        // Run the page
        return await rencanaPenyaluranView.Run();
    }

    // edit
    [Route("RencanaPenyaluranEdit/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranEdit-RencanaPenyaluran-edit")]
    [Route("Home/RencanaPenyaluranEdit/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranEdit-RencanaPenyaluran-edit-2")]
    public async Task<IActionResult> RencanaPenyaluranEdit()
    {
        // Create page object
        rencanaPenyaluranEdit = new GLOBALS.RencanaPenyaluranEdit(this);

        // Run the page
        return await rencanaPenyaluranEdit.Run();
    }

    // delete
    [Route("RencanaPenyaluranDelete/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranDelete-RencanaPenyaluran-delete")]
    [Route("Home/RencanaPenyaluranDelete/{IdRencanaPenyaluran?}", Name = "RencanaPenyaluranDelete-RencanaPenyaluran-delete-2")]
    public async Task<IActionResult> RencanaPenyaluranDelete()
    {
        // Create page object
        rencanaPenyaluranDelete = new GLOBALS.RencanaPenyaluranDelete(this);

        // Run the page
        return await rencanaPenyaluranDelete.Run();
    }

    // search
    [Route("RencanaPenyaluranSearch", Name = "RencanaPenyaluranSearch-RencanaPenyaluran-search")]
    [Route("Home/RencanaPenyaluranSearch", Name = "RencanaPenyaluranSearch-RencanaPenyaluran-search-2")]
    public async Task<IActionResult> RencanaPenyaluranSearch()
    {
        // Create page object
        rencanaPenyaluranSearch = new GLOBALS.RencanaPenyaluranSearch(this);

        // Run the page
        return await rencanaPenyaluranSearch.Run();
    }
}
