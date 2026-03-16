namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterTemplateList/{IdTemplate?}", Name = "MasterTemplateList-MasterTemplate-list")]
    [Route("Home/MasterTemplateList/{IdTemplate?}", Name = "MasterTemplateList-MasterTemplate-list-2")]
    public async Task<IActionResult> MasterTemplateList()
    {
        // Create page object
        masterTemplateList = new GLOBALS.MasterTemplateList(this);
        masterTemplateList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdTemplate"];

        // Run the page
        return await masterTemplateList.Run();
    }

    // add
    [Route("MasterTemplateAdd/{IdTemplate?}", Name = "MasterTemplateAdd-MasterTemplate-add")]
    [Route("Home/MasterTemplateAdd/{IdTemplate?}", Name = "MasterTemplateAdd-MasterTemplate-add-2")]
    public async Task<IActionResult> MasterTemplateAdd()
    {
        // Create page object
        masterTemplateAdd = new GLOBALS.MasterTemplateAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdTemplate"];

        // Run the page
        return await masterTemplateAdd.Run();
    }

    // view
    [Route("MasterTemplateView/{IdTemplate?}", Name = "MasterTemplateView-MasterTemplate-view")]
    [Route("Home/MasterTemplateView/{IdTemplate?}", Name = "MasterTemplateView-MasterTemplate-view-2")]
    public async Task<IActionResult> MasterTemplateView()
    {
        // Create page object
        masterTemplateView = new GLOBALS.MasterTemplateView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdTemplate"];

        // Run the page
        return await masterTemplateView.Run();
    }

    // edit
    [Route("MasterTemplateEdit/{IdTemplate?}", Name = "MasterTemplateEdit-MasterTemplate-edit")]
    [Route("Home/MasterTemplateEdit/{IdTemplate?}", Name = "MasterTemplateEdit-MasterTemplate-edit-2")]
    public async Task<IActionResult> MasterTemplateEdit()
    {
        // Create page object
        masterTemplateEdit = new GLOBALS.MasterTemplateEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdTemplate"];

        // Run the page
        return await masterTemplateEdit.Run();
    }

    // delete
    [Route("MasterTemplateDelete/{IdTemplate?}", Name = "MasterTemplateDelete-MasterTemplate-delete")]
    [Route("Home/MasterTemplateDelete/{IdTemplate?}", Name = "MasterTemplateDelete-MasterTemplate-delete-2")]
    public async Task<IActionResult> MasterTemplateDelete()
    {
        // Create page object
        masterTemplateDelete = new GLOBALS.MasterTemplateDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdTemplate"];

        // Run the page
        return await masterTemplateDelete.Run();
    }
}
