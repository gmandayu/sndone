namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasHasilPemeriksaanPipaList/{id?}", Name = "SubAktivitasHasilPemeriksaanPipaList-SubAktivitasHasilPemeriksaanPipa-list")]
    [Route("Home/SubAktivitasHasilPemeriksaanPipaList/{id?}", Name = "SubAktivitasHasilPemeriksaanPipaList-SubAktivitasHasilPemeriksaanPipa-list-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPipaList()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPipaList = new GLOBALS.SubAktivitasHasilPemeriksaanPipaList(this);
        subAktivitasHasilPemeriksaanPipaList.Cache = _cache;

        // Run the page
        return await subAktivitasHasilPemeriksaanPipaList.Run();
    }

    // edit
    [Route("SubAktivitasHasilPemeriksaanPipaEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPipaEdit-SubAktivitasHasilPemeriksaanPipa-edit")]
    [Route("Home/SubAktivitasHasilPemeriksaanPipaEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPipaEdit-SubAktivitasHasilPemeriksaanPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPipaEdit()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPipaEdit = new GLOBALS.SubAktivitasHasilPemeriksaanPipaEdit(this);

        // Run the page
        return await subAktivitasHasilPemeriksaanPipaEdit.Run();
    }
}
