namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataKapalStslpgList/{id?}", Name = "SubAktivitasDataKapalStslpgList-SubAktivitasDataKapalSTSLPG-list")]
    [Route("Home/SubAktivitasDataKapalStslpgList/{id?}", Name = "SubAktivitasDataKapalStslpgList-SubAktivitasDataKapalSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasDataKapalStslpgList()
    {
        // Create page object
        subAktivitasDataKapalStslpgList = new GLOBALS.SubAktivitasDataKapalStslpgList(this);
        subAktivitasDataKapalStslpgList.Cache = _cache;

        // Run the page
        return await subAktivitasDataKapalStslpgList.Run();
    }

    // edit
    [Route("SubAktivitasDataKapalStslpgEdit/{id?}", Name = "SubAktivitasDataKapalStslpgEdit-SubAktivitasDataKapalSTSLPG-edit")]
    [Route("Home/SubAktivitasDataKapalStslpgEdit/{id?}", Name = "SubAktivitasDataKapalStslpgEdit-SubAktivitasDataKapalSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasDataKapalStslpgEdit()
    {
        // Create page object
        subAktivitasDataKapalStslpgEdit = new GLOBALS.SubAktivitasDataKapalStslpgEdit(this);

        // Run the page
        return await subAktivitasDataKapalStslpgEdit.Run();
    }
}
