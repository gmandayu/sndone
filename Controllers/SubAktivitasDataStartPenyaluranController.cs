namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStartPenyaluranList/{id?}", Name = "SubAktivitasDataStartPenyaluranList-SubAktivitasDataStartPenyaluran-list")]
    [Route("Home/SubAktivitasDataStartPenyaluranList/{id?}", Name = "SubAktivitasDataStartPenyaluranList-SubAktivitasDataStartPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranList()
    {
        // Create page object
        subAktivitasDataStartPenyaluranList = new GLOBALS.SubAktivitasDataStartPenyaluranList(this);
        subAktivitasDataStartPenyaluranList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStartPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasDataStartPenyaluranEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranEdit-SubAktivitasDataStartPenyaluran-edit")]
    [Route("Home/SubAktivitasDataStartPenyaluranEdit/{id?}", Name = "SubAktivitasDataStartPenyaluranEdit-SubAktivitasDataStartPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStartPenyaluranEdit()
    {
        // Create page object
        subAktivitasDataStartPenyaluranEdit = new GLOBALS.SubAktivitasDataStartPenyaluranEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasDataStartPenyaluranEdit.Run();
    }
}
