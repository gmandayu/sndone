namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputDataRtwList/{id?}", Name = "SubAktivitasInputDataRtwList-SubAktivitasInputDataRTW-list")]
    [Route("Home/SubAktivitasInputDataRtwList/{id?}", Name = "SubAktivitasInputDataRtwList-SubAktivitasInputDataRTW-list-2")]
    public async Task<IActionResult> SubAktivitasInputDataRtwList()
    {
        // Create page object
        subAktivitasInputDataRtwList = new GLOBALS.SubAktivitasInputDataRtwList(this);
        subAktivitasInputDataRtwList.Cache = _cache;

        // Run the page
        return await subAktivitasInputDataRtwList.Run();
    }

    // edit
    [Route("SubAktivitasInputDataRtwEdit/{id?}", Name = "SubAktivitasInputDataRtwEdit-SubAktivitasInputDataRTW-edit")]
    [Route("Home/SubAktivitasInputDataRtwEdit/{id?}", Name = "SubAktivitasInputDataRtwEdit-SubAktivitasInputDataRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasInputDataRtwEdit()
    {
        // Create page object
        subAktivitasInputDataRtwEdit = new GLOBALS.SubAktivitasInputDataRtwEdit(this);

        // Run the page
        return await subAktivitasInputDataRtwEdit.Run();
    }
}
