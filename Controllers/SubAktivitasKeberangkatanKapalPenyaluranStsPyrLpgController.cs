namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList-SubAktivitasKeberangkatanKapalPenyaluranSTSPyrLPG-list")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList-SubAktivitasKeberangkatanKapalPenyaluranSTSPyrLPG-list-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList = new GLOBALS.SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList(this);
        subAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasKeberangkatanKapalPenyaluranStsPyrLpgList.Run();
    }

    // edit
    [Route("SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgEdit-SubAktivitasKeberangkatanKapalPenyaluranSTSPyrLPG-edit")]
    [Route("Home/SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgEdit-SubAktivitasKeberangkatanKapalPenyaluranSTSPyrLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgEdit()
    {
        // Create page object
        subAktivitasKeberangkatanKapalPenyaluranStsPyrLpgEdit = new GLOBALS.SubAktivitasKeberangkatanKapalPenyaluranStsPyrLpgEdit(this);

        // Run the page
        return await subAktivitasKeberangkatanKapalPenyaluranStsPyrLpgEdit.Run();
    }
}
