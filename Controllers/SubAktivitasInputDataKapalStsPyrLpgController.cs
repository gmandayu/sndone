namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputDataKapalStsPyrLpgList/{id?}", Name = "SubAktivitasInputDataKapalStsPyrLpgList-SubAktivitasInputDataKapalSTSPyrLPG-list")]
    [Route("Home/SubAktivitasInputDataKapalStsPyrLpgList/{id?}", Name = "SubAktivitasInputDataKapalStsPyrLpgList-SubAktivitasInputDataKapalSTSPyrLPG-list-2")]
    public async Task<IActionResult> SubAktivitasInputDataKapalStsPyrLpgList()
    {
        // Create page object
        subAktivitasInputDataKapalStsPyrLpgList = new GLOBALS.SubAktivitasInputDataKapalStsPyrLpgList(this);
        subAktivitasInputDataKapalStsPyrLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasInputDataKapalStsPyrLpgList.Run();
    }

    // edit
    [Route("SubAktivitasInputDataKapalStsPyrLpgEdit/{id?}", Name = "SubAktivitasInputDataKapalStsPyrLpgEdit-SubAktivitasInputDataKapalSTSPyrLPG-edit")]
    [Route("Home/SubAktivitasInputDataKapalStsPyrLpgEdit/{id?}", Name = "SubAktivitasInputDataKapalStsPyrLpgEdit-SubAktivitasInputDataKapalSTSPyrLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasInputDataKapalStsPyrLpgEdit()
    {
        // Create page object
        subAktivitasInputDataKapalStsPyrLpgEdit = new GLOBALS.SubAktivitasInputDataKapalStsPyrLpgEdit(this);

        // Run the page
        return await subAktivitasInputDataKapalStsPyrLpgEdit.Run();
    }
}
