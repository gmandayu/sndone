namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList-SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG-list")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList-SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG-list-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList = new GLOBALS.SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList(this);
        subAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasHasilPemeriksaanPenyaluranStsPyrLpgList.Run();
    }

    // edit
    [Route("SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgEdit-SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG-edit")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgEdit-SubAktivitasHasilPemeriksaanPenyaluranSTSPyrLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgEdit()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenyaluranStsPyrLpgEdit = new GLOBALS.SubAktivitasHasilPemeriksaanPenyaluranStsPyrLpgEdit(this);

        // Run the page
        return await subAktivitasHasilPemeriksaanPenyaluranStsPyrLpgEdit.Run();
    }
}
