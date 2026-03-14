namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputFlowrateRtwList/{id?}", Name = "SubAktivitasFormInputFlowrateRtwList-SubAktivitasFormInputFlowrateRTW-list")]
    [Route("Home/SubAktivitasFormInputFlowrateRtwList/{id?}", Name = "SubAktivitasFormInputFlowrateRtwList-SubAktivitasFormInputFlowrateRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateRtwList()
    {
        // Create page object
        subAktivitasFormInputFlowrateRtwList = new GLOBALS.SubAktivitasFormInputFlowrateRtwList(this);
        subAktivitasFormInputFlowrateRtwList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputFlowrateRtwList.Run();
    }

    // add
    [Route("SubAktivitasFormInputFlowrateRtwAdd/{id?}", Name = "SubAktivitasFormInputFlowrateRtwAdd-SubAktivitasFormInputFlowrateRTW-add")]
    [Route("Home/SubAktivitasFormInputFlowrateRtwAdd/{id?}", Name = "SubAktivitasFormInputFlowrateRtwAdd-SubAktivitasFormInputFlowrateRTW-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateRtwAdd()
    {
        // Create page object
        subAktivitasFormInputFlowrateRtwAdd = new GLOBALS.SubAktivitasFormInputFlowrateRtwAdd(this);

        // Run the page
        return await subAktivitasFormInputFlowrateRtwAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputFlowrateRtwView/{id?}", Name = "SubAktivitasFormInputFlowrateRtwView-SubAktivitasFormInputFlowrateRTW-view")]
    [Route("Home/SubAktivitasFormInputFlowrateRtwView/{id?}", Name = "SubAktivitasFormInputFlowrateRtwView-SubAktivitasFormInputFlowrateRTW-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateRtwView()
    {
        // Create page object
        subAktivitasFormInputFlowrateRtwView = new GLOBALS.SubAktivitasFormInputFlowrateRtwView(this);

        // Run the page
        return await subAktivitasFormInputFlowrateRtwView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputFlowrateRtwEdit/{id?}", Name = "SubAktivitasFormInputFlowrateRtwEdit-SubAktivitasFormInputFlowrateRTW-edit")]
    [Route("Home/SubAktivitasFormInputFlowrateRtwEdit/{id?}", Name = "SubAktivitasFormInputFlowrateRtwEdit-SubAktivitasFormInputFlowrateRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateRtwEdit()
    {
        // Create page object
        subAktivitasFormInputFlowrateRtwEdit = new GLOBALS.SubAktivitasFormInputFlowrateRtwEdit(this);

        // Run the page
        return await subAktivitasFormInputFlowrateRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputFlowrateRtwDelete/{id?}", Name = "SubAktivitasFormInputFlowrateRtwDelete-SubAktivitasFormInputFlowrateRTW-delete")]
    [Route("Home/SubAktivitasFormInputFlowrateRtwDelete/{id?}", Name = "SubAktivitasFormInputFlowrateRtwDelete-SubAktivitasFormInputFlowrateRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateRtwDelete()
    {
        // Create page object
        subAktivitasFormInputFlowrateRtwDelete = new GLOBALS.SubAktivitasFormInputFlowrateRtwDelete(this);

        // Run the page
        return await subAktivitasFormInputFlowrateRtwDelete.Run();
    }
}
