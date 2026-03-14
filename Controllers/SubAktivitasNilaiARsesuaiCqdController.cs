namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiARsesuaiCqdList/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdList-SubAktivitasNilaiARsesuaiCQD-list")]
    [Route("Home/SubAktivitasNilaiARsesuaiCqdList/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdList-SubAktivitasNilaiARsesuaiCQD-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiARsesuaiCqdList()
    {
        // Create page object
        subAktivitasNilaiARsesuaiCqdList = new GLOBALS.SubAktivitasNilaiARsesuaiCqdList(this);
        subAktivitasNilaiARsesuaiCqdList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiARsesuaiCqdList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiARsesuaiCqdEdit/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdEdit-SubAktivitasNilaiARsesuaiCQD-edit")]
    [Route("Home/SubAktivitasNilaiARsesuaiCqdEdit/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdEdit-SubAktivitasNilaiARsesuaiCQD-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiARsesuaiCqdEdit()
    {
        // Create page object
        subAktivitasNilaiARsesuaiCqdEdit = new GLOBALS.SubAktivitasNilaiARsesuaiCqdEdit(this);

        // Run the page
        return await subAktivitasNilaiARsesuaiCqdEdit.Run();
    }
}
