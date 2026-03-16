namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormNilaiSfalarstsPymBbmList/{id?}", Name = "SubAktivitasFormNilaiSfalarstsPymBbmList-SubAktivitasFormNilaiSFALARSTSPymBBM-list")]
    [Route("Home/SubAktivitasFormNilaiSfalarstsPymBbmList/{id?}", Name = "SubAktivitasFormNilaiSfalarstsPymBbmList-SubAktivitasFormNilaiSFALARSTSPymBBM-list-2")]
    public async Task<IActionResult> SubAktivitasFormNilaiSfalarstsPymBbmList()
    {
        // Create page object
        subAktivitasFormNilaiSfalarstsPymBbmList = new GLOBALS.SubAktivitasFormNilaiSfalarstsPymBbmList(this);
        subAktivitasFormNilaiSfalarstsPymBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormNilaiSfalarstsPymBbmList.Run();
    }

    // edit
    [Route("SubAktivitasFormNilaiSfalarstsPymBbmEdit/{id?}", Name = "SubAktivitasFormNilaiSfalarstsPymBbmEdit-SubAktivitasFormNilaiSFALARSTSPymBBM-edit")]
    [Route("Home/SubAktivitasFormNilaiSfalarstsPymBbmEdit/{id?}", Name = "SubAktivitasFormNilaiSfalarstsPymBbmEdit-SubAktivitasFormNilaiSFALARSTSPymBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasFormNilaiSfalarstsPymBbmEdit()
    {
        // Create page object
        subAktivitasFormNilaiSfalarstsPymBbmEdit = new GLOBALS.SubAktivitasFormNilaiSfalarstsPymBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormNilaiSfalarstsPymBbmEdit.Run();
    }
}
