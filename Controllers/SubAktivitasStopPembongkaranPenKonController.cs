namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasStopPembongkaranPenKonList/{id?}", Name = "SubAktivitasStopPembongkaranPenKonList-SubAktivitasStopPembongkaranPenKon-list")]
    [Route("Home/SubAktivitasStopPembongkaranPenKonList/{id?}", Name = "SubAktivitasStopPembongkaranPenKonList-SubAktivitasStopPembongkaranPenKon-list-2")]
    public async Task<IActionResult> SubAktivitasStopPembongkaranPenKonList()
    {
        // Create page object
        subAktivitasStopPembongkaranPenKonList = new GLOBALS.SubAktivitasStopPembongkaranPenKonList(this);
        subAktivitasStopPembongkaranPenKonList.Cache = _cache;

        // Run the page
        return await subAktivitasStopPembongkaranPenKonList.Run();
    }

    // edit
    [Route("SubAktivitasStopPembongkaranPenKonEdit/{id?}", Name = "SubAktivitasStopPembongkaranPenKonEdit-SubAktivitasStopPembongkaranPenKon-edit")]
    [Route("Home/SubAktivitasStopPembongkaranPenKonEdit/{id?}", Name = "SubAktivitasStopPembongkaranPenKonEdit-SubAktivitasStopPembongkaranPenKon-edit-2")]
    public async Task<IActionResult> SubAktivitasStopPembongkaranPenKonEdit()
    {
        // Create page object
        subAktivitasStopPembongkaranPenKonEdit = new GLOBALS.SubAktivitasStopPembongkaranPenKonEdit(this);

        // Run the page
        return await subAktivitasStopPembongkaranPenKonEdit.Run();
    }
}
