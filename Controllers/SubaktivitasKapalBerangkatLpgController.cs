namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasKapalBerangkatLpgList/{id?}", Name = "SubaktivitasKapalBerangkatLpgList-SubaktivitasKapalBerangkatLPG-list")]
    [Route("Home/SubaktivitasKapalBerangkatLpgList/{id?}", Name = "SubaktivitasKapalBerangkatLpgList-SubaktivitasKapalBerangkatLPG-list-2")]
    public async Task<IActionResult> SubaktivitasKapalBerangkatLpgList()
    {
        // Create page object
        subaktivitasKapalBerangkatLpgList = new GLOBALS.SubaktivitasKapalBerangkatLpgList(this);
        subaktivitasKapalBerangkatLpgList.Cache = _cache;

        // Run the page
        return await subaktivitasKapalBerangkatLpgList.Run();
    }

    // edit
    [Route("SubaktivitasKapalBerangkatLpgEdit/{id?}", Name = "SubaktivitasKapalBerangkatLpgEdit-SubaktivitasKapalBerangkatLPG-edit")]
    [Route("Home/SubaktivitasKapalBerangkatLpgEdit/{id?}", Name = "SubaktivitasKapalBerangkatLpgEdit-SubaktivitasKapalBerangkatLPG-edit-2")]
    public async Task<IActionResult> SubaktivitasKapalBerangkatLpgEdit()
    {
        // Create page object
        subaktivitasKapalBerangkatLpgEdit = new GLOBALS.SubaktivitasKapalBerangkatLpgEdit(this);

        // Run the page
        return await subaktivitasKapalBerangkatLpgEdit.Run();
    }
}
