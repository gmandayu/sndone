namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiSfbdlpgList/{id?}", Name = "SubAktivitasNilaiSfbdlpgList-SubAktivitasNilaiSFBDLPG-list")]
    [Route("Home/SubAktivitasNilaiSfbdlpgList/{id?}", Name = "SubAktivitasNilaiSfbdlpgList-SubAktivitasNilaiSFBDLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdlpgList()
    {
        // Create page object
        subAktivitasNilaiSfbdlpgList = new GLOBALS.SubAktivitasNilaiSfbdlpgList(this);
        subAktivitasNilaiSfbdlpgList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiSfbdlpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiSfbdlpgEdit/{id?}", Name = "SubAktivitasNilaiSfbdlpgEdit-SubAktivitasNilaiSFBDLPG-edit")]
    [Route("Home/SubAktivitasNilaiSfbdlpgEdit/{id?}", Name = "SubAktivitasNilaiSfbdlpgEdit-SubAktivitasNilaiSFBDLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdlpgEdit()
    {
        // Create page object
        subAktivitasNilaiSfbdlpgEdit = new GLOBALS.SubAktivitasNilaiSfbdlpgEdit(this);

        // Run the page
        return await subAktivitasNilaiSfbdlpgEdit.Run();
    }
}
