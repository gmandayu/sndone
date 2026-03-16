namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VAktifitasWithDokumenList/{IdAktivitas?}", Name = "VAktifitasWithDokumenList-v_aktifitas_with_dokumen-list")]
    [Route("Home/VAktifitasWithDokumenList/{IdAktivitas?}", Name = "VAktifitasWithDokumenList-v_aktifitas_with_dokumen-list-2")]
    public async Task<IActionResult> VAktifitasWithDokumenList()
    {
        // Create page object
        vAktifitasWithDokumenList = new GLOBALS.VAktifitasWithDokumenList(this);
        vAktifitasWithDokumenList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdAktivitas"];

        // Run the page
        return await vAktifitasWithDokumenList.Run();
    }

    // edit
    [Route("VAktifitasWithDokumenEdit/{IdAktivitas?}", Name = "VAktifitasWithDokumenEdit-v_aktifitas_with_dokumen-edit")]
    [Route("Home/VAktifitasWithDokumenEdit/{IdAktivitas?}", Name = "VAktifitasWithDokumenEdit-v_aktifitas_with_dokumen-edit-2")]
    public async Task<IActionResult> VAktifitasWithDokumenEdit()
    {
        // Create page object
        vAktifitasWithDokumenEdit = new GLOBALS.VAktifitasWithDokumenEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdAktivitas"];

        // Run the page
        return await vAktifitasWithDokumenEdit.Run();
    }
}
