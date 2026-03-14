namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiSfblstsPymLpgList/{id?}", Name = "SubaktivitasNilaiSfblstsPymLpgList-SubaktivitasNilaiSFBLSTSPymLPG-list")]
    [Route("Home/SubaktivitasNilaiSfblstsPymLpgList/{id?}", Name = "SubaktivitasNilaiSfblstsPymLpgList-SubaktivitasNilaiSFBLSTSPymLPG-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiSfblstsPymLpgList()
    {
        // Create page object
        subaktivitasNilaiSfblstsPymLpgList = new GLOBALS.SubaktivitasNilaiSfblstsPymLpgList(this);
        subaktivitasNilaiSfblstsPymLpgList.Cache = _cache;

        // Run the page
        return await subaktivitasNilaiSfblstsPymLpgList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiSfblstsPymLpgEdit/{id?}", Name = "SubaktivitasNilaiSfblstsPymLpgEdit-SubaktivitasNilaiSFBLSTSPymLPG-edit")]
    [Route("Home/SubaktivitasNilaiSfblstsPymLpgEdit/{id?}", Name = "SubaktivitasNilaiSfblstsPymLpgEdit-SubaktivitasNilaiSFBLSTSPymLPG-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiSfblstsPymLpgEdit()
    {
        // Create page object
        subaktivitasNilaiSfblstsPymLpgEdit = new GLOBALS.SubaktivitasNilaiSfblstsPymLpgEdit(this);

        // Run the page
        return await subaktivitasNilaiSfblstsPymLpgEdit.Run();
    }
}
