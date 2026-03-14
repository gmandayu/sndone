namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputLogbookPenerimaanTruckList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanTruckList-SubAktivitasFormInputLogbookPenerimaanTruck-list")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanTruckList/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanTruckList-SubAktivitasFormInputLogbookPenerimaanTruck-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanTruckList()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanTruckList = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanTruckList(this);
        subAktivitasFormInputLogbookPenerimaanTruckList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanTruckList.Run();
    }

    // view
    [Route("SubAktivitasFormInputLogbookPenerimaanTruckView/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanTruckView-SubAktivitasFormInputLogbookPenerimaanTruck-view")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanTruckView/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanTruckView-SubAktivitasFormInputLogbookPenerimaanTruck-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanTruckView()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanTruckView = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanTruckView(this);

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanTruckView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputLogbookPenerimaanTruckEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanTruckEdit-SubAktivitasFormInputLogbookPenerimaanTruck-edit")]
    [Route("Home/SubAktivitasFormInputLogbookPenerimaanTruckEdit/{id?}", Name = "SubAktivitasFormInputLogbookPenerimaanTruckEdit-SubAktivitasFormInputLogbookPenerimaanTruck-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputLogbookPenerimaanTruckEdit()
    {
        // Create page object
        subAktivitasFormInputLogbookPenerimaanTruckEdit = new GLOBALS.SubAktivitasFormInputLogbookPenerimaanTruckEdit(this);

        // Run the page
        return await subAktivitasFormInputLogbookPenerimaanTruckEdit.Run();
    }
}
