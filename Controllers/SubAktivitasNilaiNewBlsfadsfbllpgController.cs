namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiNewBlsfadsfbllpgList/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfbllpgList-SubAktivitasNilaiNewBLSFADSFBLLPG-list")]
    [Route("Home/SubAktivitasNilaiNewBlsfadsfbllpgList/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfbllpgList-SubAktivitasNilaiNewBLSFADSFBLLPG-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiNewBlsfadsfbllpgList()
    {
        // Create page object
        subAktivitasNilaiNewBlsfadsfbllpgList = new GLOBALS.SubAktivitasNilaiNewBlsfadsfbllpgList(this);
        subAktivitasNilaiNewBlsfadsfbllpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiNewBlsfadsfbllpgList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiNewBlsfadsfbllpgEdit/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfbllpgEdit-SubAktivitasNilaiNewBLSFADSFBLLPG-edit")]
    [Route("Home/SubAktivitasNilaiNewBlsfadsfbllpgEdit/{id?}", Name = "SubAktivitasNilaiNewBlsfadsfbllpgEdit-SubAktivitasNilaiNewBLSFADSFBLLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiNewBlsfadsfbllpgEdit()
    {
        // Create page object
        subAktivitasNilaiNewBlsfadsfbllpgEdit = new GLOBALS.SubAktivitasNilaiNewBlsfadsfbllpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiNewBlsfadsfbllpgEdit.Run();
    }
}
