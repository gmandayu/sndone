namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("PenyimpananSampleList/{id?}", Name = "PenyimpananSampleList-PenyimpananSample-list")]
    [Route("Home/PenyimpananSampleList/{id?}", Name = "PenyimpananSampleList-PenyimpananSample-list-2")]
    public async Task<IActionResult> PenyimpananSampleList()
    {
        // Create page object
        penyimpananSampleList = new GLOBALS.PenyimpananSampleList(this);
        penyimpananSampleList.Cache = _cache;

        // Run the page
        return await penyimpananSampleList.Run();
    }

    // add
    [Route("PenyimpananSampleAdd/{id?}", Name = "PenyimpananSampleAdd-PenyimpananSample-add")]
    [Route("Home/PenyimpananSampleAdd/{id?}", Name = "PenyimpananSampleAdd-PenyimpananSample-add-2")]
    public async Task<IActionResult> PenyimpananSampleAdd()
    {
        // Create page object
        penyimpananSampleAdd = new GLOBALS.PenyimpananSampleAdd(this);

        // Run the page
        return await penyimpananSampleAdd.Run();
    }

    // view
    [Route("PenyimpananSampleView/{id?}", Name = "PenyimpananSampleView-PenyimpananSample-view")]
    [Route("Home/PenyimpananSampleView/{id?}", Name = "PenyimpananSampleView-PenyimpananSample-view-2")]
    public async Task<IActionResult> PenyimpananSampleView()
    {
        // Create page object
        penyimpananSampleView = new GLOBALS.PenyimpananSampleView(this);

        // Run the page
        return await penyimpananSampleView.Run();
    }

    // edit
    [Route("PenyimpananSampleEdit/{id?}", Name = "PenyimpananSampleEdit-PenyimpananSample-edit")]
    [Route("Home/PenyimpananSampleEdit/{id?}", Name = "PenyimpananSampleEdit-PenyimpananSample-edit-2")]
    public async Task<IActionResult> PenyimpananSampleEdit()
    {
        // Create page object
        penyimpananSampleEdit = new GLOBALS.PenyimpananSampleEdit(this);

        // Run the page
        return await penyimpananSampleEdit.Run();
    }

    // delete
    [Route("PenyimpananSampleDelete/{id?}", Name = "PenyimpananSampleDelete-PenyimpananSample-delete")]
    [Route("Home/PenyimpananSampleDelete/{id?}", Name = "PenyimpananSampleDelete-PenyimpananSample-delete-2")]
    public async Task<IActionResult> PenyimpananSampleDelete()
    {
        // Create page object
        penyimpananSampleDelete = new GLOBALS.PenyimpananSampleDelete(this);

        // Run the page
        return await penyimpananSampleDelete.Run();
    }
}
