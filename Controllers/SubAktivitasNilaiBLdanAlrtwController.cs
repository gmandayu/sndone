namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBLdanAlrtwList/{id?}", Name = "SubAktivitasNilaiBLdanAlrtwList-SubAktivitasNilaiBLdanALRTW-list")]
    [Route("Home/SubAktivitasNilaiBLdanAlrtwList/{id?}", Name = "SubAktivitasNilaiBLdanAlrtwList-SubAktivitasNilaiBLdanALRTW-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBLdanAlrtwList()
    {
        // Create page object
        subAktivitasNilaiBLdanAlrtwList = new GLOBALS.SubAktivitasNilaiBLdanAlrtwList(this);
        subAktivitasNilaiBLdanAlrtwList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBLdanAlrtwList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBLdanAlrtwEdit/{id?}", Name = "SubAktivitasNilaiBLdanAlrtwEdit-SubAktivitasNilaiBLdanALRTW-edit")]
    [Route("Home/SubAktivitasNilaiBLdanAlrtwEdit/{id?}", Name = "SubAktivitasNilaiBLdanAlrtwEdit-SubAktivitasNilaiBLdanALRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBLdanAlrtwEdit()
    {
        // Create page object
        subAktivitasNilaiBLdanAlrtwEdit = new GLOBALS.SubAktivitasNilaiBLdanAlrtwEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiBLdanAlrtwEdit.Run();
    }
}
