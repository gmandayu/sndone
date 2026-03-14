namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasRealisasiPenyaluranPerProdukList/{id?}", Name = "SubAktivitasRealisasiPenyaluranPerProdukList-SubAktivitasRealisasiPenyaluranPerProduk-list")]
    [Route("Home/SubAktivitasRealisasiPenyaluranPerProdukList/{id?}", Name = "SubAktivitasRealisasiPenyaluranPerProdukList-SubAktivitasRealisasiPenyaluranPerProduk-list-2")]
    public async Task<IActionResult> SubAktivitasRealisasiPenyaluranPerProdukList()
    {
        // Create page object
        subAktivitasRealisasiPenyaluranPerProdukList = new GLOBALS.SubAktivitasRealisasiPenyaluranPerProdukList(this);
        subAktivitasRealisasiPenyaluranPerProdukList.Cache = _cache;

        // Run the page
        return await subAktivitasRealisasiPenyaluranPerProdukList.Run();
    }

    // edit
    [Route("SubAktivitasRealisasiPenyaluranPerProdukEdit/{id?}", Name = "SubAktivitasRealisasiPenyaluranPerProdukEdit-SubAktivitasRealisasiPenyaluranPerProduk-edit")]
    [Route("Home/SubAktivitasRealisasiPenyaluranPerProdukEdit/{id?}", Name = "SubAktivitasRealisasiPenyaluranPerProdukEdit-SubAktivitasRealisasiPenyaluranPerProduk-edit-2")]
    public async Task<IActionResult> SubAktivitasRealisasiPenyaluranPerProdukEdit()
    {
        // Create page object
        subAktivitasRealisasiPenyaluranPerProdukEdit = new GLOBALS.SubAktivitasRealisasiPenyaluranPerProdukEdit(this);

        // Run the page
        return await subAktivitasRealisasiPenyaluranPerProdukEdit.Run();
    }
}
