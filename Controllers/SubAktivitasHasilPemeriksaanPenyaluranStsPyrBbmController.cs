namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList-SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM-list")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList-SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList = new GLOBALS.SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList(this);
        subAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList.Cache = _cache;

        // Run the page
        return await subAktivitasHasilPemeriksaanPenyaluranStsPyrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmEdit-SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM-edit")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmEdit-SubAktivitasHasilPemeriksaanPenyaluranSTSPyrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmEdit()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenyaluranStsPyrBbmEdit = new GLOBALS.SubAktivitasHasilPemeriksaanPenyaluranStsPyrBbmEdit(this);

        // Run the page
        return await subAktivitasHasilPemeriksaanPenyaluranStsPyrBbmEdit.Run();
    }
}
