namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputDataKapalLpgList/{id?}", Name = "SubAktivitasInputDataKapalLpgList-SubAktivitasInputDataKapalLPG-list")]
    [Route("Home/SubAktivitasInputDataKapalLpgList/{id?}", Name = "SubAktivitasInputDataKapalLpgList-SubAktivitasInputDataKapalLPG-list-2")]
    public async Task<IActionResult> SubAktivitasInputDataKapalLpgList()
    {
        // Create page object
        subAktivitasInputDataKapalLpgList = new GLOBALS.SubAktivitasInputDataKapalLpgList(this);
        subAktivitasInputDataKapalLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasInputDataKapalLpgList.Run();
    }

    // edit
    [Route("SubAktivitasInputDataKapalLpgEdit/{id?}", Name = "SubAktivitasInputDataKapalLpgEdit-SubAktivitasInputDataKapalLPG-edit")]
    [Route("Home/SubAktivitasInputDataKapalLpgEdit/{id?}", Name = "SubAktivitasInputDataKapalLpgEdit-SubAktivitasInputDataKapalLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasInputDataKapalLpgEdit()
    {
        // Create page object
        subAktivitasInputDataKapalLpgEdit = new GLOBALS.SubAktivitasInputDataKapalLpgEdit(this);

        // Run the page
        return await subAktivitasInputDataKapalLpgEdit.Run();
    }
}
