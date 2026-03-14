namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiActualPumpingList/{id?}", Name = "SubAktivitasNilaiActualPumpingList-SubAktivitasNilaiActualPumping-list")]
    [Route("Home/SubAktivitasNilaiActualPumpingList/{id?}", Name = "SubAktivitasNilaiActualPumpingList-SubAktivitasNilaiActualPumping-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiActualPumpingList()
    {
        // Create page object
        subAktivitasNilaiActualPumpingList = new GLOBALS.SubAktivitasNilaiActualPumpingList(this);
        subAktivitasNilaiActualPumpingList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiActualPumpingList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiActualPumpingEdit/{id?}", Name = "SubAktivitasNilaiActualPumpingEdit-SubAktivitasNilaiActualPumping-edit")]
    [Route("Home/SubAktivitasNilaiActualPumpingEdit/{id?}", Name = "SubAktivitasNilaiActualPumpingEdit-SubAktivitasNilaiActualPumping-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiActualPumpingEdit()
    {
        // Create page object
        subAktivitasNilaiActualPumpingEdit = new GLOBALS.SubAktivitasNilaiActualPumpingEdit(this);

        // Run the page
        return await subAktivitasNilaiActualPumpingEdit.Run();
    }
}
