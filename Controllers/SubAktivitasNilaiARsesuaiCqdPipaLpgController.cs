namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiARsesuaiCqdPipaLpgList/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdPipaLpgList-SubAktivitasNilaiARsesuaiCQDPipaLPG-list")]
    [Route("Home/SubAktivitasNilaiARsesuaiCqdPipaLpgList/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdPipaLpgList-SubAktivitasNilaiARsesuaiCQDPipaLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiARsesuaiCqdPipaLpgList()
    {
        // Create page object
        subAktivitasNilaiARsesuaiCqdPipaLpgList = new GLOBALS.SubAktivitasNilaiARsesuaiCqdPipaLpgList(this);
        subAktivitasNilaiARsesuaiCqdPipaLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiARsesuaiCqdPipaLpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiARsesuaiCqdPipaLpgEdit/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdPipaLpgEdit-SubAktivitasNilaiARsesuaiCQDPipaLPG-edit")]
    [Route("Home/SubAktivitasNilaiARsesuaiCqdPipaLpgEdit/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdPipaLpgEdit-SubAktivitasNilaiARsesuaiCQDPipaLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiARsesuaiCqdPipaLpgEdit()
    {
        // Create page object
        subAktivitasNilaiARsesuaiCqdPipaLpgEdit = new GLOBALS.SubAktivitasNilaiARsesuaiCqdPipaLpgEdit(this);

        // Run the page
        return await subAktivitasNilaiARsesuaiCqdPipaLpgEdit.Run();
    }
}
