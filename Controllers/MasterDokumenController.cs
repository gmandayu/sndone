namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterDokumenList/{IdDokumen?}", Name = "MasterDokumenList-MasterDokumen-list")]
    [Route("Home/MasterDokumenList/{IdDokumen?}", Name = "MasterDokumenList-MasterDokumen-list-2")]
    public async Task<IActionResult> MasterDokumenList()
    {
        // Create page object
        masterDokumenList = new GLOBALS.MasterDokumenList(this);
        masterDokumenList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdDokumen"];

        // Run the page
        return await masterDokumenList.Run();
    }

    // add
    [Route("MasterDokumenAdd/{IdDokumen?}", Name = "MasterDokumenAdd-MasterDokumen-add")]
    [Route("Home/MasterDokumenAdd/{IdDokumen?}", Name = "MasterDokumenAdd-MasterDokumen-add-2")]
    public async Task<IActionResult> MasterDokumenAdd()
    {
        // Create page object
        masterDokumenAdd = new GLOBALS.MasterDokumenAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdDokumen"];

        // Run the page
        return await masterDokumenAdd.Run();
    }

    // view
    [Route("MasterDokumenView/{IdDokumen?}", Name = "MasterDokumenView-MasterDokumen-view")]
    [Route("Home/MasterDokumenView/{IdDokumen?}", Name = "MasterDokumenView-MasterDokumen-view-2")]
    public async Task<IActionResult> MasterDokumenView()
    {
        // Create page object
        masterDokumenView = new GLOBALS.MasterDokumenView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdDokumen"];

        // Run the page
        return await masterDokumenView.Run();
    }

    // edit
    [Route("MasterDokumenEdit/{IdDokumen?}", Name = "MasterDokumenEdit-MasterDokumen-edit")]
    [Route("Home/MasterDokumenEdit/{IdDokumen?}", Name = "MasterDokumenEdit-MasterDokumen-edit-2")]
    public async Task<IActionResult> MasterDokumenEdit()
    {
        // Create page object
        masterDokumenEdit = new GLOBALS.MasterDokumenEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdDokumen"];

        // Run the page
        return await masterDokumenEdit.Run();
    }

    // delete
    [Route("MasterDokumenDelete/{IdDokumen?}", Name = "MasterDokumenDelete-MasterDokumen-delete")]
    [Route("Home/MasterDokumenDelete/{IdDokumen?}", Name = "MasterDokumenDelete-MasterDokumen-delete-2")]
    public async Task<IActionResult> MasterDokumenDelete()
    {
        // Create page object
        masterDokumenDelete = new GLOBALS.MasterDokumenDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdDokumen"];

        // Run the page
        return await masterDokumenDelete.Run();
    }
}
