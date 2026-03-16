namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasLogbookPenerimaanPenyaluranLpgList/{id?}", Name = "SubAktivitasLogbookPenerimaanPenyaluranLpgList-SubAktivitasLogbookPenerimaanPenyaluranLPG-list")]
    [Route("Home/SubAktivitasLogbookPenerimaanPenyaluranLpgList/{id?}", Name = "SubAktivitasLogbookPenerimaanPenyaluranLpgList-SubAktivitasLogbookPenerimaanPenyaluranLPG-list-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanPenyaluranLpgList()
    {
        // Create page object
        subAktivitasLogbookPenerimaanPenyaluranLpgList = new GLOBALS.SubAktivitasLogbookPenerimaanPenyaluranLpgList(this);
        subAktivitasLogbookPenerimaanPenyaluranLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLogbookPenerimaanPenyaluranLpgList.Run();
    }

    // edit
    [Route("SubAktivitasLogbookPenerimaanPenyaluranLpgEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanPenyaluranLpgEdit-SubAktivitasLogbookPenerimaanPenyaluranLPG-edit")]
    [Route("Home/SubAktivitasLogbookPenerimaanPenyaluranLpgEdit/{id?}", Name = "SubAktivitasLogbookPenerimaanPenyaluranLpgEdit-SubAktivitasLogbookPenerimaanPenyaluranLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasLogbookPenerimaanPenyaluranLpgEdit()
    {
        // Create page object
        subAktivitasLogbookPenerimaanPenyaluranLpgEdit = new GLOBALS.SubAktivitasLogbookPenerimaanPenyaluranLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasLogbookPenerimaanPenyaluranLpgEdit.Run();
    }
}
