namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasKapalBerangkatStslpgList/{id?}", Name = "SubAktivitasKapalBerangkatStslpgList-SubAktivitasKapalBerangkatSTSLPG-list")]
    [Route("Home/SubAktivitasKapalBerangkatStslpgList/{id?}", Name = "SubAktivitasKapalBerangkatStslpgList-SubAktivitasKapalBerangkatSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasKapalBerangkatStslpgList()
    {
        // Create page object
        subAktivitasKapalBerangkatStslpgList = new GLOBALS.SubAktivitasKapalBerangkatStslpgList(this);
        subAktivitasKapalBerangkatStslpgList.Cache = _cache;

        // Run the page
        return await subAktivitasKapalBerangkatStslpgList.Run();
    }

    // edit
    [Route("SubAktivitasKapalBerangkatStslpgEdit/{id?}", Name = "SubAktivitasKapalBerangkatStslpgEdit-SubAktivitasKapalBerangkatSTSLPG-edit")]
    [Route("Home/SubAktivitasKapalBerangkatStslpgEdit/{id?}", Name = "SubAktivitasKapalBerangkatStslpgEdit-SubAktivitasKapalBerangkatSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasKapalBerangkatStslpgEdit()
    {
        // Create page object
        subAktivitasKapalBerangkatStslpgEdit = new GLOBALS.SubAktivitasKapalBerangkatStslpgEdit(this);

        // Run the page
        return await subAktivitasKapalBerangkatStslpgEdit.Run();
    }
}
