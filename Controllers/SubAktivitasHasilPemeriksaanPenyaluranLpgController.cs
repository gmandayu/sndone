namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasHasilPemeriksaanPenyaluranLpgList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranLpgList-SubAktivitasHasilPemeriksaanPenyaluranLPG-list")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenyaluranLpgList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranLpgList-SubAktivitasHasilPemeriksaanPenyaluranLPG-list-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenyaluranLpgList()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenyaluranLpgList = new GLOBALS.SubAktivitasHasilPemeriksaanPenyaluranLpgList(this);
        subAktivitasHasilPemeriksaanPenyaluranLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasHasilPemeriksaanPenyaluranLpgList.Run();
    }

    // edit
    [Route("SubAktivitasHasilPemeriksaanPenyaluranLpgEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranLpgEdit-SubAktivitasHasilPemeriksaanPenyaluranLPG-edit")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenyaluranLpgEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranLpgEdit-SubAktivitasHasilPemeriksaanPenyaluranLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenyaluranLpgEdit()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenyaluranLpgEdit = new GLOBALS.SubAktivitasHasilPemeriksaanPenyaluranLpgEdit(this);

        // Run the page
        return await subAktivitasHasilPemeriksaanPenyaluranLpgEdit.Run();
    }
}
