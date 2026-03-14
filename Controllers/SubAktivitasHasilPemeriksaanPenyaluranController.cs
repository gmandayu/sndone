namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasHasilPemeriksaanPenyaluranList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranList-SubAktivitasHasilPemeriksaanPenyaluran-list")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenyaluranList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranList-SubAktivitasHasilPemeriksaanPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenyaluranList()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenyaluranList = new GLOBALS.SubAktivitasHasilPemeriksaanPenyaluranList(this);
        subAktivitasHasilPemeriksaanPenyaluranList.Cache = _cache;

        // Run the page
        return await subAktivitasHasilPemeriksaanPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasHasilPemeriksaanPenyaluranEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranEdit-SubAktivitasHasilPemeriksaanPenyaluran-edit")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenyaluranEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenyaluranEdit-SubAktivitasHasilPemeriksaanPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenyaluranEdit()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenyaluranEdit = new GLOBALS.SubAktivitasHasilPemeriksaanPenyaluranEdit(this);

        // Run the page
        return await subAktivitasHasilPemeriksaanPenyaluranEdit.Run();
    }
}
