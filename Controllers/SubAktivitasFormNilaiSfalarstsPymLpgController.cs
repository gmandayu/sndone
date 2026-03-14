namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormNilaiSfalarstsPymLpgList/{id?}", Name = "SubAktivitasFormNilaiSfalarstsPymLpgList-SubAktivitasFormNilaiSFALARSTSPymLPG-list")]
    [Route("Home/SubAktivitasFormNilaiSfalarstsPymLpgList/{id?}", Name = "SubAktivitasFormNilaiSfalarstsPymLpgList-SubAktivitasFormNilaiSFALARSTSPymLPG-list-2")]
    public async Task<IActionResult> SubAktivitasFormNilaiSfalarstsPymLpgList()
    {
        // Create page object
        subAktivitasFormNilaiSfalarstsPymLpgList = new GLOBALS.SubAktivitasFormNilaiSfalarstsPymLpgList(this);
        subAktivitasFormNilaiSfalarstsPymLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasFormNilaiSfalarstsPymLpgList.Run();
    }

    // edit
    [Route("SubAktivitasFormNilaiSfalarstsPymLpgEdit/{id?}", Name = "SubAktivitasFormNilaiSfalarstsPymLpgEdit-SubAktivitasFormNilaiSFALARSTSPymLPG-edit")]
    [Route("Home/SubAktivitasFormNilaiSfalarstsPymLpgEdit/{id?}", Name = "SubAktivitasFormNilaiSfalarstsPymLpgEdit-SubAktivitasFormNilaiSFALARSTSPymLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasFormNilaiSfalarstsPymLpgEdit()
    {
        // Create page object
        subAktivitasFormNilaiSfalarstsPymLpgEdit = new GLOBALS.SubAktivitasFormNilaiSfalarstsPymLpgEdit(this);

        // Run the page
        return await subAktivitasFormNilaiSfalarstsPymLpgEdit.Run();
    }
}
