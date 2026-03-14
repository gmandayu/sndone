namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLaporanStockStscslpgList/{id?}", Name = "SubAktivitasLaporanStockStscslpgList-SubAktivitasLaporanStockSTSCSLPG-list")]
    [Route("Home/SubAktivitasLaporanStockStscslpgList/{id?}", Name = "SubAktivitasLaporanStockStscslpgList-SubAktivitasLaporanStockSTSCSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasLaporanStockStscslpgList()
    {
        // Create page object
        subAktivitasLaporanStockStscslpgList = new GLOBALS.SubAktivitasLaporanStockStscslpgList(this);
        subAktivitasLaporanStockStscslpgList.Cache = _cache;

        // Run the page
        return await subAktivitasLaporanStockStscslpgList.Run();
    }

    // edit
    [Route("SubAktivitasLaporanStockStscslpgEdit/{id?}", Name = "SubAktivitasLaporanStockStscslpgEdit-SubAktivitasLaporanStockSTSCSLPG-edit")]
    [Route("Home/SubAktivitasLaporanStockStscslpgEdit/{id?}", Name = "SubAktivitasLaporanStockStscslpgEdit-SubAktivitasLaporanStockSTSCSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasLaporanStockStscslpgEdit()
    {
        // Create page object
        subAktivitasLaporanStockStscslpgEdit = new GLOBALS.SubAktivitasLaporanStockStscslpgEdit(this);

        // Run the page
        return await subAktivitasLaporanStockStscslpgEdit.Run();
    }
}
