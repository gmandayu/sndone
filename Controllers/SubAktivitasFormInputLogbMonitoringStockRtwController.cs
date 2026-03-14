namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputLogbMonitoringStockRtwList/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwList-SubAktivitasFormInputLogbMonitoringStockRTW-list")]
    [Route("Home/SubAktivitasFormInputLogbMonitoringStockRtwList/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwList-SubAktivitasFormInputLogbMonitoringStockRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbMonitoringStockRtwList()
    {
        // Create page object
        subAktivitasFormInputLogbMonitoringStockRtwList = new GLOBALS.SubAktivitasFormInputLogbMonitoringStockRtwList(this);
        subAktivitasFormInputLogbMonitoringStockRtwList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputLogbMonitoringStockRtwList.Run();
    }

    // add
    [Route("SubAktivitasFormInputLogbMonitoringStockRtwAdd/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwAdd-SubAktivitasFormInputLogbMonitoringStockRTW-add")]
    [Route("Home/SubAktivitasFormInputLogbMonitoringStockRtwAdd/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwAdd-SubAktivitasFormInputLogbMonitoringStockRTW-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbMonitoringStockRtwAdd()
    {
        // Create page object
        subAktivitasFormInputLogbMonitoringStockRtwAdd = new GLOBALS.SubAktivitasFormInputLogbMonitoringStockRtwAdd(this);

        // Run the page
        return await subAktivitasFormInputLogbMonitoringStockRtwAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputLogbMonitoringStockRtwView/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwView-SubAktivitasFormInputLogbMonitoringStockRTW-view")]
    [Route("Home/SubAktivitasFormInputLogbMonitoringStockRtwView/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwView-SubAktivitasFormInputLogbMonitoringStockRTW-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbMonitoringStockRtwView()
    {
        // Create page object
        subAktivitasFormInputLogbMonitoringStockRtwView = new GLOBALS.SubAktivitasFormInputLogbMonitoringStockRtwView(this);

        // Run the page
        return await subAktivitasFormInputLogbMonitoringStockRtwView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputLogbMonitoringStockRtwEdit/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwEdit-SubAktivitasFormInputLogbMonitoringStockRTW-edit")]
    [Route("Home/SubAktivitasFormInputLogbMonitoringStockRtwEdit/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwEdit-SubAktivitasFormInputLogbMonitoringStockRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbMonitoringStockRtwEdit()
    {
        // Create page object
        subAktivitasFormInputLogbMonitoringStockRtwEdit = new GLOBALS.SubAktivitasFormInputLogbMonitoringStockRtwEdit(this);

        // Run the page
        return await subAktivitasFormInputLogbMonitoringStockRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputLogbMonitoringStockRtwDelete/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwDelete-SubAktivitasFormInputLogbMonitoringStockRTW-delete")]
    [Route("Home/SubAktivitasFormInputLogbMonitoringStockRtwDelete/{id?}", Name = "SubAktivitasFormInputLogbMonitoringStockRtwDelete-SubAktivitasFormInputLogbMonitoringStockRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbMonitoringStockRtwDelete()
    {
        // Create page object
        subAktivitasFormInputLogbMonitoringStockRtwDelete = new GLOBALS.SubAktivitasFormInputLogbMonitoringStockRtwDelete(this);

        // Run the page
        return await subAktivitasFormInputLogbMonitoringStockRtwDelete.Run();
    }
}
