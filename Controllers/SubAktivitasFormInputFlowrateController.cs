namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputFlowrateList/{id?}", Name = "SubAktivitasFormInputFlowrateList-SubAktivitasFormInputFlowrate-list")]
    [Route("Home/SubAktivitasFormInputFlowrateList/{id?}", Name = "SubAktivitasFormInputFlowrateList-SubAktivitasFormInputFlowrate-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateList()
    {
        // Create page object
        subAktivitasFormInputFlowrateList = new GLOBALS.SubAktivitasFormInputFlowrateList(this);
        subAktivitasFormInputFlowrateList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputFlowrateList.Run();
    }

    // add
    [Route("SubAktivitasFormInputFlowrateAdd/{id?}", Name = "SubAktivitasFormInputFlowrateAdd-SubAktivitasFormInputFlowrate-add")]
    [Route("Home/SubAktivitasFormInputFlowrateAdd/{id?}", Name = "SubAktivitasFormInputFlowrateAdd-SubAktivitasFormInputFlowrate-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateAdd()
    {
        // Create page object
        subAktivitasFormInputFlowrateAdd = new GLOBALS.SubAktivitasFormInputFlowrateAdd(this);

        // Run the page
        return await subAktivitasFormInputFlowrateAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputFlowrateView/{id?}", Name = "SubAktivitasFormInputFlowrateView-SubAktivitasFormInputFlowrate-view")]
    [Route("Home/SubAktivitasFormInputFlowrateView/{id?}", Name = "SubAktivitasFormInputFlowrateView-SubAktivitasFormInputFlowrate-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateView()
    {
        // Create page object
        subAktivitasFormInputFlowrateView = new GLOBALS.SubAktivitasFormInputFlowrateView(this);

        // Run the page
        return await subAktivitasFormInputFlowrateView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputFlowrateEdit/{id?}", Name = "SubAktivitasFormInputFlowrateEdit-SubAktivitasFormInputFlowrate-edit")]
    [Route("Home/SubAktivitasFormInputFlowrateEdit/{id?}", Name = "SubAktivitasFormInputFlowrateEdit-SubAktivitasFormInputFlowrate-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateEdit()
    {
        // Create page object
        subAktivitasFormInputFlowrateEdit = new GLOBALS.SubAktivitasFormInputFlowrateEdit(this);

        // Run the page
        return await subAktivitasFormInputFlowrateEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputFlowrateDelete/{id?}", Name = "SubAktivitasFormInputFlowrateDelete-SubAktivitasFormInputFlowrate-delete")]
    [Route("Home/SubAktivitasFormInputFlowrateDelete/{id?}", Name = "SubAktivitasFormInputFlowrateDelete-SubAktivitasFormInputFlowrate-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputFlowrateDelete()
    {
        // Create page object
        subAktivitasFormInputFlowrateDelete = new GLOBALS.SubAktivitasFormInputFlowrateDelete(this);

        // Run the page
        return await subAktivitasFormInputFlowrateDelete.Run();
    }
}
