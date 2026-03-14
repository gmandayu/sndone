namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("AktivitasList/{IdAktivitas?}", Name = "AktivitasList-Aktivitas-list")]
    [Route("Home/AktivitasList/{IdAktivitas?}", Name = "AktivitasList-Aktivitas-list-2")]
    public async Task<IActionResult> AktivitasList()
    {
        // Create page object
        aktivitasList = new GLOBALS.AktivitasList(this);
        aktivitasList.Cache = _cache;

        // Run the page
        return await aktivitasList.Run();
    }

    // edit
    [Route("AktivitasEdit/{IdAktivitas?}", Name = "AktivitasEdit-Aktivitas-edit")]
    [Route("Home/AktivitasEdit/{IdAktivitas?}", Name = "AktivitasEdit-Aktivitas-edit-2")]
    public async Task<IActionResult> AktivitasEdit()
    {
        // Create page object
        aktivitasEdit = new GLOBALS.AktivitasEdit(this);

        // Run the page
        return await aktivitasEdit.Run();
    }
}
