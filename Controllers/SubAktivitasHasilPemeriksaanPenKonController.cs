namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasHasilPemeriksaanPenKonList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenKonList-SubAktivitasHasilPemeriksaanPenKon-list")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenKonList/{id?}", Name = "SubAktivitasHasilPemeriksaanPenKonList-SubAktivitasHasilPemeriksaanPenKon-list-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenKonList()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenKonList = new GLOBALS.SubAktivitasHasilPemeriksaanPenKonList(this);
        subAktivitasHasilPemeriksaanPenKonList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasHasilPemeriksaanPenKonList.Run();
    }

    // edit
    [Route("SubAktivitasHasilPemeriksaanPenKonEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenKonEdit-SubAktivitasHasilPemeriksaanPenKon-edit")]
    [Route("Home/SubAktivitasHasilPemeriksaanPenKonEdit/{id?}", Name = "SubAktivitasHasilPemeriksaanPenKonEdit-SubAktivitasHasilPemeriksaanPenKon-edit-2")]
    public async Task<IActionResult> SubAktivitasHasilPemeriksaanPenKonEdit()
    {
        // Create page object
        subAktivitasHasilPemeriksaanPenKonEdit = new GLOBALS.SubAktivitasHasilPemeriksaanPenKonEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasHasilPemeriksaanPenKonEdit.Run();
    }
}
