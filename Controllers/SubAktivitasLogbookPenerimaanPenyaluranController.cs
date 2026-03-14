namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookPenerimaanPenyaluranList/{id?}", Name = "SubAktivitasLogbookPenerimaanPenyaluranList-SubAktivitasLogbookPenerimaanPenyaluran-list")]
    [Route("Home/SubAktivitasLogbookPenerimaanPenyaluranList/{id?}", Name = "SubAktivitasLogbookPenerimaanPenyaluranList-SubAktivitasLogbookPenerimaanPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanPenyaluranList()
    {
        // Create page object
        subAktivitasLogbookPenerimaanPenyaluranList = new GLOBALS.SubAktivitasLogbookPenerimaanPenyaluranList(this);
        subAktivitasLogbookPenerimaanPenyaluranList.Cache = _cache;

        // Run the page
        return await subAktivitasLogbookPenerimaanPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookPenerimaanPenyaluranEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanPenyaluranEdit-SubAktivitasLogbookPenerimaanPenyaluran-edit")]
    [Route("Home/SubAktivitasLogbookPenerimaanPenyaluranEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanPenyaluranEdit-SubAktivitasLogbookPenerimaanPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanPenyaluranEdit()
    {
        // Create page object
        subAktivitasLogbookPenerimaanPenyaluranEdit = new GLOBALS.SubAktivitasLogbookPenerimaanPenyaluranEdit(this);

        // Run the page
        return await subAktivitasLogbookPenerimaanPenyaluranEdit.Run();
    }
}
