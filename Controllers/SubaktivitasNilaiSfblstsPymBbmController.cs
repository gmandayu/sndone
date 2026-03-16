namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiSfblstsPymBbmList/{id?}", Name = "SubaktivitasNilaiSfblstsPymBbmList-SubaktivitasNilaiSFBLSTSPymBBM-list")]
    [Route("Home/SubaktivitasNilaiSfblstsPymBbmList/{id?}", Name = "SubaktivitasNilaiSfblstsPymBbmList-SubaktivitasNilaiSFBLSTSPymBBM-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiSfblstsPymBbmList()
    {
        // Create page object
        subaktivitasNilaiSfblstsPymBbmList = new GLOBALS.SubaktivitasNilaiSfblstsPymBbmList(this);
        subaktivitasNilaiSfblstsPymBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasNilaiSfblstsPymBbmList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiSfblstsPymBbmEdit/{id?}", Name = "SubaktivitasNilaiSfblstsPymBbmEdit-SubaktivitasNilaiSFBLSTSPymBBM-edit")]
    [Route("Home/SubaktivitasNilaiSfblstsPymBbmEdit/{id?}", Name = "SubaktivitasNilaiSfblstsPymBbmEdit-SubaktivitasNilaiSFBLSTSPymBBM-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiSfblstsPymBbmEdit()
    {
        // Create page object
        subaktivitasNilaiSfblstsPymBbmEdit = new GLOBALS.SubaktivitasNilaiSfblstsPymBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasNilaiSfblstsPymBbmEdit.Run();
    }
}
