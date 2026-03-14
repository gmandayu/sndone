namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasTotalPenyaluranList/{id?}", Name = "SubAktivitasTotalPenyaluranList-SubAktivitasTotalPenyaluran-list")]
    [Route("Home/SubAktivitasTotalPenyaluranList/{id?}", Name = "SubAktivitasTotalPenyaluranList-SubAktivitasTotalPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasTotalPenyaluranList()
    {
        // Create page object
        subAktivitasTotalPenyaluranList = new GLOBALS.SubAktivitasTotalPenyaluranList(this);
        subAktivitasTotalPenyaluranList.Cache = _cache;

        // Run the page
        return await subAktivitasTotalPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasTotalPenyaluranEdit/{id?}", Name = "SubAktivitasTotalPenyaluranEdit-SubAktivitasTotalPenyaluran-edit")]
    [Route("Home/SubAktivitasTotalPenyaluranEdit/{id?}", Name = "SubAktivitasTotalPenyaluranEdit-SubAktivitasTotalPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasTotalPenyaluranEdit()
    {
        // Create page object
        subAktivitasTotalPenyaluranEdit = new GLOBALS.SubAktivitasTotalPenyaluranEdit(this);

        // Run the page
        return await subAktivitasTotalPenyaluranEdit.Run();
    }
}
