namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiARsesuaiCqdlpgList/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdlpgList-SubAktivitasNilaiARsesuaiCQDLPG-list")]
    [Route("Home/SubAktivitasNilaiARsesuaiCqdlpgList/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdlpgList-SubAktivitasNilaiARsesuaiCQDLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiARsesuaiCqdlpgList()
    {
        // Create page object
        subAktivitasNilaiARsesuaiCqdlpgList = new GLOBALS.SubAktivitasNilaiARsesuaiCqdlpgList(this);
        subAktivitasNilaiARsesuaiCqdlpgList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiARsesuaiCqdlpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiARsesuaiCqdlpgEdit/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdlpgEdit-SubAktivitasNilaiARsesuaiCQDLPG-edit")]
    [Route("Home/SubAktivitasNilaiARsesuaiCqdlpgEdit/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdlpgEdit-SubAktivitasNilaiARsesuaiCQDLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiARsesuaiCqdlpgEdit()
    {
        // Create page object
        subAktivitasNilaiARsesuaiCqdlpgEdit = new GLOBALS.SubAktivitasNilaiARsesuaiCqdlpgEdit(this);

        // Run the page
        return await subAktivitasNilaiARsesuaiCqdlpgEdit.Run();
    }
}
