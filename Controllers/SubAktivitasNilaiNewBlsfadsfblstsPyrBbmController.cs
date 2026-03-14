namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiNewBlsfadsfblstsPyrBbmList/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblstsPyrBbmList-SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM-list")]
    [Route("Home/SubAktivitasNilaiNewBlsfadsfblstsPyrBbmList/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblstsPyrBbmList-SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiNewBlsfadsfblstsPyrBbmList()
    {
        // Create page object
        subAktivitasNilaiNewBlsfadsfblstsPyrBbmList = new GLOBALS.SubAktivitasNilaiNewBlsfadsfblstsPyrBbmList(this);
        subAktivitasNilaiNewBlsfadsfblstsPyrBbmList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiNewBlsfadsfblstsPyrBbmList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiNewBlsfadsfblstsPyrBbmEdit/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblstsPyrBbmEdit-SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM-edit")]
    [Route("Home/SubAktivitasNilaiNewBlsfadsfblstsPyrBbmEdit/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblstsPyrBbmEdit-SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiNewBlsfadsfblstsPyrBbmEdit()
    {
        // Create page object
        subAktivitasNilaiNewBlsfadsfblstsPyrBbmEdit = new GLOBALS.SubAktivitasNilaiNewBlsfadsfblstsPyrBbmEdit(this);

        // Run the page
        return await subAktivitasNilaiNewBlsfadsfblstsPyrBbmEdit.Run();
    }
}
