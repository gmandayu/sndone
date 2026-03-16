namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiSfbdList/{id?}", Name = "SubaktivitasNilaiSfbdList-SubaktivitasNilaiSFBD-list")]
    [Route("Home/SubaktivitasNilaiSfbdList/{id?}", Name = "SubaktivitasNilaiSfbdList-SubaktivitasNilaiSFBD-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiSfbdList()
    {
        // Create page object
        subaktivitasNilaiSfbdList = new GLOBALS.SubaktivitasNilaiSfbdList(this);
        subaktivitasNilaiSfbdList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasNilaiSfbdList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiSfbdEdit/{id?}", Name = "SubaktivitasNilaiSfbdEdit-SubaktivitasNilaiSFBD-edit")]
    [Route("Home/SubaktivitasNilaiSfbdEdit/{id?}", Name = "SubaktivitasNilaiSfbdEdit-SubaktivitasNilaiSFBD-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiSfbdEdit()
    {
        // Create page object
        subaktivitasNilaiSfbdEdit = new GLOBALS.SubaktivitasNilaiSfbdEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasNilaiSfbdEdit.Run();
    }
}
