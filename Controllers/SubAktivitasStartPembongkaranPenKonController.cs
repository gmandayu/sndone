namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasStartPembongkaranPenKonList/{id?}", Name = "SubAktivitasStartPembongkaranPenKonList-SubAktivitasStartPembongkaranPenKon-list")]
    [Route("Home/SubAktivitasStartPembongkaranPenKonList/{id?}", Name = "SubAktivitasStartPembongkaranPenKonList-SubAktivitasStartPembongkaranPenKon-list-2")]
    public async Task<IActionResult> SubAktivitasStartPembongkaranPenKonList()
    {
        // Create page object
        subAktivitasStartPembongkaranPenKonList = new GLOBALS.SubAktivitasStartPembongkaranPenKonList(this);
        subAktivitasStartPembongkaranPenKonList.Cache = _cache;

        // Run the page
        return await subAktivitasStartPembongkaranPenKonList.Run();
    }

    // edit
    [Route("SubAktivitasStartPembongkaranPenKonEdit/{id?}", Name = "SubAktivitasStartPembongkaranPenKonEdit-SubAktivitasStartPembongkaranPenKon-edit")]
    [Route("Home/SubAktivitasStartPembongkaranPenKonEdit/{id?}", Name = "SubAktivitasStartPembongkaranPenKonEdit-SubAktivitasStartPembongkaranPenKon-edit-2")]
    public async Task<IActionResult> SubAktivitasStartPembongkaranPenKonEdit()
    {
        // Create page object
        subAktivitasStartPembongkaranPenKonEdit = new GLOBALS.SubAktivitasStartPembongkaranPenKonEdit(this);

        // Run the page
        return await subAktivitasStartPembongkaranPenKonEdit.Run();
    }
}
