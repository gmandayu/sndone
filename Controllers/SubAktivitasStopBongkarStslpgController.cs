namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasStopBongkarStslpgList/{id?}", Name = "SubAktivitasStopBongkarStslpgList-SubAktivitasStopBongkarSTSLPG-list")]
    [Route("Home/SubAktivitasStopBongkarStslpgList/{id?}", Name = "SubAktivitasStopBongkarStslpgList-SubAktivitasStopBongkarSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasStopBongkarStslpgList()
    {
        // Create page object
        subAktivitasStopBongkarStslpgList = new GLOBALS.SubAktivitasStopBongkarStslpgList(this);
        subAktivitasStopBongkarStslpgList.Cache = _cache;

        // Run the page
        return await subAktivitasStopBongkarStslpgList.Run();
    }

    // edit
    [Route("SubAktivitasStopBongkarStslpgEdit/{id?}", Name = "SubAktivitasStopBongkarStslpgEdit-SubAktivitasStopBongkarSTSLPG-edit")]
    [Route("Home/SubAktivitasStopBongkarStslpgEdit/{id?}", Name = "SubAktivitasStopBongkarStslpgEdit-SubAktivitasStopBongkarSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasStopBongkarStslpgEdit()
    {
        // Create page object
        subAktivitasStopBongkarStslpgEdit = new GLOBALS.SubAktivitasStopBongkarStslpgEdit(this);

        // Run the page
        return await subAktivitasStopBongkarStslpgEdit.Run();
    }
}
