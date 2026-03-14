namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // AktivitasTabel (custom)
    [Route("AktivitasTabel/{**key}", Name = "AktivitasTabel-AktivitasTabel-custom")]
    [Route("Home/AktivitasTabel/{**key}", Name = "AktivitasTabel-AktivitasTabel-custom-2")]
    public async Task<IActionResult> AktivitasTabel()
    {
        // Create page object
        aktivitasTabel = new GLOBALS.AktivitasTabel(this);

        // Run the page
        return await aktivitasTabel.Run();
    }
}
