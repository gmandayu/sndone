namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("FormInputGoodHouseKeepingList/{id?}", Name = "FormInputGoodHouseKeepingList-FormInputGoodHouseKeeping-list")]
    [Route("Home/FormInputGoodHouseKeepingList/{id?}", Name = "FormInputGoodHouseKeepingList-FormInputGoodHouseKeeping-list-2")]
    public async Task<IActionResult> FormInputGoodHouseKeepingList()
    {
        // Create page object
        formInputGoodHouseKeepingList = new GLOBALS.FormInputGoodHouseKeepingList(this);
        formInputGoodHouseKeepingList.Cache = _cache;

        // Run the page
        return await formInputGoodHouseKeepingList.Run();
    }

    // add
    [Route("FormInputGoodHouseKeepingAdd/{id?}", Name = "FormInputGoodHouseKeepingAdd-FormInputGoodHouseKeeping-add")]
    [Route("Home/FormInputGoodHouseKeepingAdd/{id?}", Name = "FormInputGoodHouseKeepingAdd-FormInputGoodHouseKeeping-add-2")]
    public async Task<IActionResult> FormInputGoodHouseKeepingAdd()
    {
        // Create page object
        formInputGoodHouseKeepingAdd = new GLOBALS.FormInputGoodHouseKeepingAdd(this);

        // Run the page
        return await formInputGoodHouseKeepingAdd.Run();
    }

    // view
    [Route("FormInputGoodHouseKeepingView/{id?}", Name = "FormInputGoodHouseKeepingView-FormInputGoodHouseKeeping-view")]
    [Route("Home/FormInputGoodHouseKeepingView/{id?}", Name = "FormInputGoodHouseKeepingView-FormInputGoodHouseKeeping-view-2")]
    public async Task<IActionResult> FormInputGoodHouseKeepingView()
    {
        // Create page object
        formInputGoodHouseKeepingView = new GLOBALS.FormInputGoodHouseKeepingView(this);

        // Run the page
        return await formInputGoodHouseKeepingView.Run();
    }

    // edit
    [Route("FormInputGoodHouseKeepingEdit/{id?}", Name = "FormInputGoodHouseKeepingEdit-FormInputGoodHouseKeeping-edit")]
    [Route("Home/FormInputGoodHouseKeepingEdit/{id?}", Name = "FormInputGoodHouseKeepingEdit-FormInputGoodHouseKeeping-edit-2")]
    public async Task<IActionResult> FormInputGoodHouseKeepingEdit()
    {
        // Create page object
        formInputGoodHouseKeepingEdit = new GLOBALS.FormInputGoodHouseKeepingEdit(this);

        // Run the page
        return await formInputGoodHouseKeepingEdit.Run();
    }

    // delete
    [Route("FormInputGoodHouseKeepingDelete/{id?}", Name = "FormInputGoodHouseKeepingDelete-FormInputGoodHouseKeeping-delete")]
    [Route("Home/FormInputGoodHouseKeepingDelete/{id?}", Name = "FormInputGoodHouseKeepingDelete-FormInputGoodHouseKeeping-delete-2")]
    public async Task<IActionResult> FormInputGoodHouseKeepingDelete()
    {
        // Create page object
        formInputGoodHouseKeepingDelete = new GLOBALS.FormInputGoodHouseKeepingDelete(this);

        // Run the page
        return await formInputGoodHouseKeepingDelete.Run();
    }
}
