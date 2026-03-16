namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiSfbdPenKonList/{id?}", Name = "SubAktivitasNilaiSfbdPenKonList-SubAktivitasNilaiSFBDPenKon-list")]
    [Route("Home/SubAktivitasNilaiSfbdPenKonList/{id?}", Name = "SubAktivitasNilaiSfbdPenKonList-SubAktivitasNilaiSFBDPenKon-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdPenKonList()
    {
        // Create page object
        subAktivitasNilaiSfbdPenKonList = new GLOBALS.SubAktivitasNilaiSfbdPenKonList(this);
        subAktivitasNilaiSfbdPenKonList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiSfbdPenKonList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiSfbdPenKonEdit/{id?}", Name = "SubAktivitasNilaiSfbdPenKonEdit-SubAktivitasNilaiSFBDPenKon-edit")]
    [Route("Home/SubAktivitasNilaiSfbdPenKonEdit/{id?}", Name = "SubAktivitasNilaiSfbdPenKonEdit-SubAktivitasNilaiSFBDPenKon-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdPenKonEdit()
    {
        // Create page object
        subAktivitasNilaiSfbdPenKonEdit = new GLOBALS.SubAktivitasNilaiSfbdPenKonEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiSfbdPenKonEdit.Run();
    }
}
