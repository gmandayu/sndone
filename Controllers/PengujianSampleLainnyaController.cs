namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("PengujianSampleLainnyaList/{id?}", Name = "PengujianSampleLainnyaList-PengujianSampleLainnya-list")]
    [Route("Home/PengujianSampleLainnyaList/{id?}", Name = "PengujianSampleLainnyaList-PengujianSampleLainnya-list-2")]
    public async Task<IActionResult> PengujianSampleLainnyaList()
    {
        // Create page object
        pengujianSampleLainnyaList = new GLOBALS.PengujianSampleLainnyaList(this);
        pengujianSampleLainnyaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await pengujianSampleLainnyaList.Run();
    }

    // add
    [Route("PengujianSampleLainnyaAdd/{id?}", Name = "PengujianSampleLainnyaAdd-PengujianSampleLainnya-add")]
    [Route("Home/PengujianSampleLainnyaAdd/{id?}", Name = "PengujianSampleLainnyaAdd-PengujianSampleLainnya-add-2")]
    public async Task<IActionResult> PengujianSampleLainnyaAdd()
    {
        // Create page object
        pengujianSampleLainnyaAdd = new GLOBALS.PengujianSampleLainnyaAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await pengujianSampleLainnyaAdd.Run();
    }

    // view
    [Route("PengujianSampleLainnyaView/{id?}", Name = "PengujianSampleLainnyaView-PengujianSampleLainnya-view")]
    [Route("Home/PengujianSampleLainnyaView/{id?}", Name = "PengujianSampleLainnyaView-PengujianSampleLainnya-view-2")]
    public async Task<IActionResult> PengujianSampleLainnyaView()
    {
        // Create page object
        pengujianSampleLainnyaView = new GLOBALS.PengujianSampleLainnyaView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await pengujianSampleLainnyaView.Run();
    }

    // edit
    [Route("PengujianSampleLainnyaEdit/{id?}", Name = "PengujianSampleLainnyaEdit-PengujianSampleLainnya-edit")]
    [Route("Home/PengujianSampleLainnyaEdit/{id?}", Name = "PengujianSampleLainnyaEdit-PengujianSampleLainnya-edit-2")]
    public async Task<IActionResult> PengujianSampleLainnyaEdit()
    {
        // Create page object
        pengujianSampleLainnyaEdit = new GLOBALS.PengujianSampleLainnyaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await pengujianSampleLainnyaEdit.Run();
    }

    // delete
    [Route("PengujianSampleLainnyaDelete/{id?}", Name = "PengujianSampleLainnyaDelete-PengujianSampleLainnya-delete")]
    [Route("Home/PengujianSampleLainnyaDelete/{id?}", Name = "PengujianSampleLainnyaDelete-PengujianSampleLainnya-delete-2")]
    public async Task<IActionResult> PengujianSampleLainnyaDelete()
    {
        // Create page object
        pengujianSampleLainnyaDelete = new GLOBALS.PengujianSampleLainnyaDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await pengujianSampleLainnyaDelete.Run();
    }
}
