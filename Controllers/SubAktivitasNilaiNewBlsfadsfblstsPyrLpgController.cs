namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiNewBlsfadsfblstsPyrLpgList/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblstsPyrLpgList-SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG-list")]
    [Route("Home/SubAktivitasNilaiNewBlsfadsfblstsPyrLpgList/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblstsPyrLpgList-SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiNewBlsfadsfblstsPyrLpgList()
    {
        // Create page object
        subAktivitasNilaiNewBlsfadsfblstsPyrLpgList = new GLOBALS.SubAktivitasNilaiNewBlsfadsfblstsPyrLpgList(this);
        subAktivitasNilaiNewBlsfadsfblstsPyrLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiNewBlsfadsfblstsPyrLpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiNewBlsfadsfblstsPyrLpgEdit/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblstsPyrLpgEdit-SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG-edit")]
    [Route("Home/SubAktivitasNilaiNewBlsfadsfblstsPyrLpgEdit/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblstsPyrLpgEdit-SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiNewBlsfadsfblstsPyrLpgEdit()
    {
        // Create page object
        subAktivitasNilaiNewBlsfadsfblstsPyrLpgEdit = new GLOBALS.SubAktivitasNilaiNewBlsfadsfblstsPyrLpgEdit(this);

        // Run the page
        return await subAktivitasNilaiNewBlsfadsfblstsPyrLpgEdit.Run();
    }
}
