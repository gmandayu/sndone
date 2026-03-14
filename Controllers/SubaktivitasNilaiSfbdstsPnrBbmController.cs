namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiSfbdstsPnrBbmList/{id?}", Name = "SubaktivitasNilaiSfbdstsPnrBbmList-SubaktivitasNilaiSFBDSTSPnrBBM-list")]
    [Route("Home/SubaktivitasNilaiSfbdstsPnrBbmList/{id?}", Name = "SubaktivitasNilaiSfbdstsPnrBbmList-SubaktivitasNilaiSFBDSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiSfbdstsPnrBbmList()
    {
        // Create page object
        subaktivitasNilaiSfbdstsPnrBbmList = new GLOBALS.SubaktivitasNilaiSfbdstsPnrBbmList(this);
        subaktivitasNilaiSfbdstsPnrBbmList.Cache = _cache;

        // Run the page
        return await subaktivitasNilaiSfbdstsPnrBbmList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiSfbdstsPnrBbmEdit/{id?}", Name = "SubaktivitasNilaiSfbdstsPnrBbmEdit-SubaktivitasNilaiSFBDSTSPnrBBM-edit")]
    [Route("Home/SubaktivitasNilaiSfbdstsPnrBbmEdit/{id?}", Name = "SubaktivitasNilaiSfbdstsPnrBbmEdit-SubaktivitasNilaiSFBDSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiSfbdstsPnrBbmEdit()
    {
        // Create page object
        subaktivitasNilaiSfbdstsPnrBbmEdit = new GLOBALS.SubaktivitasNilaiSfbdstsPnrBbmEdit(this);

        // Run the page
        return await subaktivitasNilaiSfbdstsPnrBbmEdit.Run();
    }
}
