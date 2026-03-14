namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStopPenyaluranList/{id?}", Name = "SubAktivitasDataStopPenyaluranList-SubAktivitasDataStopPenyaluran-list")]
    [Route("Home/SubAktivitasDataStopPenyaluranList/{id?}", Name = "SubAktivitasDataStopPenyaluranList-SubAktivitasDataStopPenyaluran-list-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranList()
    {
        // Create page object
        subAktivitasDataStopPenyaluranList = new GLOBALS.SubAktivitasDataStopPenyaluranList(this);
        subAktivitasDataStopPenyaluranList.Cache = _cache;

        // Run the page
        return await subAktivitasDataStopPenyaluranList.Run();
    }

    // edit
    [Route("SubAktivitasDataStopPenyaluranEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranEdit-SubAktivitasDataStopPenyaluran-edit")]
    [Route("Home/SubAktivitasDataStopPenyaluranEdit/{id?}", Name = "SubAktivitasDataStopPenyaluranEdit-SubAktivitasDataStopPenyaluran-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStopPenyaluranEdit()
    {
        // Create page object
        subAktivitasDataStopPenyaluranEdit = new GLOBALS.SubAktivitasDataStopPenyaluranEdit(this);

        // Run the page
        return await subAktivitasDataStopPenyaluranEdit.Run();
    }
}
