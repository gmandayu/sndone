namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasArSesuaiCqdrtwList/{id?}", Name = "SubAktivitasArSesuaiCqdrtwList-SubAktivitasARSesuaiCQDRTW-list")]
    [Route("Home/SubAktivitasArSesuaiCqdrtwList/{id?}", Name = "SubAktivitasArSesuaiCqdrtwList-SubAktivitasARSesuaiCQDRTW-list-2")]
    public async Task<IActionResult> SubAktivitasArSesuaiCqdrtwList()
    {
        // Create page object
        subAktivitasArSesuaiCqdrtwList = new GLOBALS.SubAktivitasArSesuaiCqdrtwList(this);
        subAktivitasArSesuaiCqdrtwList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasArSesuaiCqdrtwList.Run();
    }

    // edit
    [Route("SubAktivitasArSesuaiCqdrtwEdit/{id?}", Name = "SubAktivitasArSesuaiCqdrtwEdit-SubAktivitasARSesuaiCQDRTW-edit")]
    [Route("Home/SubAktivitasArSesuaiCqdrtwEdit/{id?}", Name = "SubAktivitasArSesuaiCqdrtwEdit-SubAktivitasARSesuaiCQDRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasArSesuaiCqdrtwEdit()
    {
        // Create page object
        subAktivitasArSesuaiCqdrtwEdit = new GLOBALS.SubAktivitasArSesuaiCqdrtwEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasArSesuaiCqdrtwEdit.Run();
    }
}
