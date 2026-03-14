namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiNewBlsfadsfblList/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblList-SubAktivitasNilaiNewBLSFADSFBL-list")]
    [Route("Home/SubAktivitasNilaiNewBlsfadsfblList/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblList-SubAktivitasNilaiNewBLSFADSFBL-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiNewBlsfadsfblList()
    {
        // Create page object
        subAktivitasNilaiNewBlsfadsfblList = new GLOBALS.SubAktivitasNilaiNewBlsfadsfblList(this);
        subAktivitasNilaiNewBlsfadsfblList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiNewBlsfadsfblList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiNewBlsfadsfblEdit/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblEdit-SubAktivitasNilaiNewBLSFADSFBL-edit")]
    [Route("Home/SubAktivitasNilaiNewBlsfadsfblEdit/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfblEdit-SubAktivitasNilaiNewBLSFADSFBL-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiNewBlsfadsfblEdit()
    {
        // Create page object
        subAktivitasNilaiNewBlsfadsfblEdit = new GLOBALS.SubAktivitasNilaiNewBlsfadsfblEdit(this);

        // Run the page
        return await subAktivitasNilaiNewBlsfadsfblEdit.Run();
    }
}
