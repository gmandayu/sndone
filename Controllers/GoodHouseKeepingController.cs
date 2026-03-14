namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("GoodHouseKeepingList/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingList-GoodHouseKeeping-list")]
    [Route("Home/GoodHouseKeepingList/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingList-GoodHouseKeeping-list-2")]
    public async Task<IActionResult> GoodHouseKeepingList()
    {
        // Create page object
        goodHouseKeepingList = new GLOBALS.GoodHouseKeepingList(this);
        goodHouseKeepingList.Cache = _cache;

        // Run the page
        return await goodHouseKeepingList.Run();
    }

    // add
    [Route("GoodHouseKeepingAdd/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingAdd-GoodHouseKeeping-add")]
    [Route("Home/GoodHouseKeepingAdd/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingAdd-GoodHouseKeeping-add-2")]
    public async Task<IActionResult> GoodHouseKeepingAdd()
    {
        // Create page object
        goodHouseKeepingAdd = new GLOBALS.GoodHouseKeepingAdd(this);

        // Run the page
        return await goodHouseKeepingAdd.Run();
    }

    // view
    [Route("GoodHouseKeepingView/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingView-GoodHouseKeeping-view")]
    [Route("Home/GoodHouseKeepingView/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingView-GoodHouseKeeping-view-2")]
    public async Task<IActionResult> GoodHouseKeepingView()
    {
        // Create page object
        goodHouseKeepingView = new GLOBALS.GoodHouseKeepingView(this);

        // Run the page
        return await goodHouseKeepingView.Run();
    }

    // edit
    [Route("GoodHouseKeepingEdit/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingEdit-GoodHouseKeeping-edit")]
    [Route("Home/GoodHouseKeepingEdit/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingEdit-GoodHouseKeeping-edit-2")]
    public async Task<IActionResult> GoodHouseKeepingEdit()
    {
        // Create page object
        goodHouseKeepingEdit = new GLOBALS.GoodHouseKeepingEdit(this);

        // Run the page
        return await goodHouseKeepingEdit.Run();
    }

    // delete
    [Route("GoodHouseKeepingDelete/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingDelete-GoodHouseKeeping-delete")]
    [Route("Home/GoodHouseKeepingDelete/{IdGoodHouseKeeping?}", Name = "GoodHouseKeepingDelete-GoodHouseKeeping-delete-2")]
    public async Task<IActionResult> GoodHouseKeepingDelete()
    {
        // Create page object
        goodHouseKeepingDelete = new GLOBALS.GoodHouseKeepingDelete(this);

        // Run the page
        return await goodHouseKeepingDelete.Run();
    }
}
