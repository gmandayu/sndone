namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookJembatanTimbangLpgList/{id?}", Name = "SubAktivitasLogbookJembatanTimbangLpgList-SubAktivitasLogbookJembatanTimbangLPG-list")]
    [Route("Home/SubAktivitasLogbookJembatanTimbangLpgList/{id?}", Name = "SubAktivitasLogbookJembatanTimbangLpgList-SubAktivitasLogbookJembatanTimbangLPG-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookJembatanTimbangLpgList()
    {
        // Create page object
        subAktivitasLogbookJembatanTimbangLpgList = new GLOBALS.SubAktivitasLogbookJembatanTimbangLpgList(this);
        subAktivitasLogbookJembatanTimbangLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLogbookJembatanTimbangLpgList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookJembatanTimbangLpgEdit/{id?}", Name = "SubAktivitasLogbookJembatanTimbangLpgEdit-SubAktivitasLogbookJembatanTimbangLPG-edit")]
    [Route("Home/SubAktivitasLogbookJembatanTimbangLpgEdit/{id?}", Name = "SubAktivitasLogbookJembatanTimbangLpgEdit-SubAktivitasLogbookJembatanTimbangLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookJembatanTimbangLpgEdit()
    {
        // Create page object
        subAktivitasLogbookJembatanTimbangLpgEdit = new GLOBALS.SubAktivitasLogbookJembatanTimbangLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLogbookJembatanTimbangLpgEdit.Run();
    }
}
