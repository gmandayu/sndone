namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasTotalRencanaPenyaluranList/{id?}", Name = "SubAktivitasTotalRencanaPenyaluranList-SubAktivitasTotalRencanaPenyaluran-list")]
    [Route("Home/SubAktivitasTotalRencanaPenyaluranList/{id?}", Name = "SubAktivitasTotalRencanaPenyaluranList-SubAktivitasTotalRencanaPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasTotalRencanaPenyaluranList()
    {
        // Create page object
        subAktivitasTotalRencanaPenyaluranList = new GLOBALS.SubAktivitasTotalRencanaPenyaluranList(this);
        subAktivitasTotalRencanaPenyaluranList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasTotalRencanaPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasTotalRencanaPenyaluranEdit/{id?}", Name = "SubAktivitasTotalRencanaPenyaluranEdit-SubAktivitasTotalRencanaPenyaluran-edit")]
    [Route("Home/SubAktivitasTotalRencanaPenyaluranEdit/{id?}", Name = "SubAktivitasTotalRencanaPenyaluranEdit-SubAktivitasTotalRencanaPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasTotalRencanaPenyaluranEdit()
    {
        // Create page object
        subAktivitasTotalRencanaPenyaluranEdit = new GLOBALS.SubAktivitasTotalRencanaPenyaluranEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasTotalRencanaPenyaluranEdit.Run();
    }
}
