namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasHasilPemeriksaanStslpgList/{id?}", Name = "SubAktivitasHasilPemeriksaanStslpgList-SubAktivitasHasilPemeriksaanSTSLPG-list")]
    [Route("Home/SubAktivitasHasilPemeriksaanStslpgList/{id?}", Name = "SubAktivitasHasilPemeriksaanStslpgList-SubAktivitasHasilPemeriksaanSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanStslpgList()
    {
        // Create page object
        subAktivitasHasilPemeriksaanStslpgList = new GLOBALS.SubAktivitasHasilPemeriksaanStslpgList(this);
        subAktivitasHasilPemeriksaanStslpgList.Cache = _cache;

        // Run the page
        return await subAktivitasHasilPemeriksaanStslpgList.Run();
    }

    // edit
    [Route("SubAktivitasHasilPemeriksaanStslpgEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanStslpgEdit-SubAktivitasHasilPemeriksaanSTSLPG-edit")]
    [Route("Home/SubAktivitasHasilPemeriksaanStslpgEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanStslpgEdit-SubAktivitasHasilPemeriksaanSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanStslpgEdit()
    {
        // Create page object
        subAktivitasHasilPemeriksaanStslpgEdit = new GLOBALS.SubAktivitasHasilPemeriksaanStslpgEdit(this);

        // Run the page
        return await subAktivitasHasilPemeriksaanStslpgEdit.Run();
    }
}
