namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasStopBongkarLpgList/{id?}", Name = "SubAktivitasStopBongkarLpgList-SubAktivitasStopBongkarLPG-list")]
    [Route("Home/SubAktivitasStopBongkarLpgList/{id?}", Name = "SubAktivitasStopBongkarLpgList-SubAktivitasStopBongkarLPG-list-2")]
    public async Task<IActionResult> SubAktivitasStopBongkarLpgList()
    {
        // Create page object
        subAktivitasStopBongkarLpgList = new GLOBALS.SubAktivitasStopBongkarLpgList(this);
        subAktivitasStopBongkarLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasStopBongkarLpgList.Run();
    }

    // edit
    [Route("SubAktivitasStopBongkarLpgEdit/{id?}", Name = "SubAktivitasStopBongkarLpgEdit-SubAktivitasStopBongkarLPG-edit")]
    [Route("Home/SubAktivitasStopBongkarLpgEdit/{id?}", Name = "SubAktivitasStopBongkarLpgEdit-SubAktivitasStopBongkarLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasStopBongkarLpgEdit()
    {
        // Create page object
        subAktivitasStopBongkarLpgEdit = new GLOBALS.SubAktivitasStopBongkarLpgEdit(this);

        // Run the page
        return await subAktivitasStopBongkarLpgEdit.Run();
    }
}
