namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VAktifitasSandarList/{IdAktivitas?}", Name = "VAktifitasSandarList-v_aktifitas_sandar-list")]
    [Route("Home/VAktifitasSandarList/{IdAktivitas?}", Name = "VAktifitasSandarList-v_aktifitas_sandar-list-2")]
    public async Task<IActionResult> VAktifitasSandarList()
    {
        // Create page object
        vAktifitasSandarList = new GLOBALS.VAktifitasSandarList(this);
        vAktifitasSandarList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdAktivitas"];

        // Run the page
        return await vAktifitasSandarList.Run();
    }

    // edit
    [Route("VAktifitasSandarEdit/{IdAktivitas?}", Name = "VAktifitasSandarEdit-v_aktifitas_sandar-edit")]
    [Route("Home/VAktifitasSandarEdit/{IdAktivitas?}", Name = "VAktifitasSandarEdit-v_aktifitas_sandar-edit-2")]
    public async Task<IActionResult> VAktifitasSandarEdit()
    {
        // Create page object
        vAktifitasSandarEdit = new GLOBALS.VAktifitasSandarEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdAktivitas"];

        // Run the page
        return await vAktifitasSandarEdit.Run();
    }
}
