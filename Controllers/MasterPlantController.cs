namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterPlantList/{IdPlant?}", Name = "MasterPlantList-MasterPlant-list")]
    [Route("Home/MasterPlantList/{IdPlant?}", Name = "MasterPlantList-MasterPlant-list-2")]
    public async Task<IActionResult> MasterPlantList()
    {
        // Create page object
        masterPlantList = new GLOBALS.MasterPlantList(this);
        masterPlantList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPlant"];

        // Run the page
        return await masterPlantList.Run();
    }

    // add
    [Route("MasterPlantAdd/{IdPlant?}", Name = "MasterPlantAdd-MasterPlant-add")]
    [Route("Home/MasterPlantAdd/{IdPlant?}", Name = "MasterPlantAdd-MasterPlant-add-2")]
    public async Task<IActionResult> MasterPlantAdd()
    {
        // Create page object
        masterPlantAdd = new GLOBALS.MasterPlantAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPlant"];

        // Run the page
        return await masterPlantAdd.Run();
    }

    // view
    [Route("MasterPlantView/{IdPlant?}", Name = "MasterPlantView-MasterPlant-view")]
    [Route("Home/MasterPlantView/{IdPlant?}", Name = "MasterPlantView-MasterPlant-view-2")]
    public async Task<IActionResult> MasterPlantView()
    {
        // Create page object
        masterPlantView = new GLOBALS.MasterPlantView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPlant"];

        // Run the page
        return await masterPlantView.Run();
    }

    // edit
    [Route("MasterPlantEdit/{IdPlant?}", Name = "MasterPlantEdit-MasterPlant-edit")]
    [Route("Home/MasterPlantEdit/{IdPlant?}", Name = "MasterPlantEdit-MasterPlant-edit-2")]
    public async Task<IActionResult> MasterPlantEdit()
    {
        // Create page object
        masterPlantEdit = new GLOBALS.MasterPlantEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPlant"];

        // Run the page
        return await masterPlantEdit.Run();
    }

    // delete
    [Route("MasterPlantDelete/{IdPlant?}", Name = "MasterPlantDelete-MasterPlant-delete")]
    [Route("Home/MasterPlantDelete/{IdPlant?}", Name = "MasterPlantDelete-MasterPlant-delete-2")]
    public async Task<IActionResult> MasterPlantDelete()
    {
        // Create page object
        masterPlantDelete = new GLOBALS.MasterPlantDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdPlant"];

        // Run the page
        return await masterPlantDelete.Run();
    }
}
