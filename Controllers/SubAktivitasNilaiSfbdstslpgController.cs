namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiSfbdstslpgList/{id?}", Name = "SubAktivitasNilaiSfbdstslpgList-SubAktivitasNilaiSFBDSTSLPG-list")]
    [Route("Home/SubAktivitasNilaiSfbdstslpgList/{id?}", Name = "SubAktivitasNilaiSfbdstslpgList-SubAktivitasNilaiSFBDSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdstslpgList()
    {
        // Create page object
        subAktivitasNilaiSfbdstslpgList = new GLOBALS.SubAktivitasNilaiSfbdstslpgList(this);
        subAktivitasNilaiSfbdstslpgList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiSfbdstslpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiSfbdstslpgEdit/{id?}", Name = "SubAktivitasNilaiSfbdstslpgEdit-SubAktivitasNilaiSFBDSTSLPG-edit")]
    [Route("Home/SubAktivitasNilaiSfbdstslpgEdit/{id?}", Name = "SubAktivitasNilaiSfbdstslpgEdit-SubAktivitasNilaiSFBDSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdstslpgEdit()
    {
        // Create page object
        subAktivitasNilaiSfbdstslpgEdit = new GLOBALS.SubAktivitasNilaiSfbdstslpgEdit(this);

        // Run the page
        return await subAktivitasNilaiSfbdstslpgEdit.Run();
    }
}
