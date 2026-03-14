namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VAktifitasList", Name = "VAktifitasList-v_aktifitas-list")]
    [Route("Home/VAktifitasList", Name = "VAktifitasList-v_aktifitas-list-2")]
    public async Task<IActionResult> VAktifitasList()
    {
        // Create page object
        vAktifitasList = new GLOBALS.VAktifitasList(this);
        vAktifitasList.Cache = _cache;

        // Run the page
        return await vAktifitasList.Run();
    }
}
