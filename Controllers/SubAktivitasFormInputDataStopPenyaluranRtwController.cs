namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputDataStopPenyaluranRtwList/{id?}", Name = "SubAktivitasFormInputDataStopPenyaluranRtwList-SubAktivitasFormInputDataStopPenyaluranRTW-list")]
    [Route("Home/SubAktivitasFormInputDataStopPenyaluranRtwList/{id?}", Name = "SubAktivitasFormInputDataStopPenyaluranRtwList-SubAktivitasFormInputDataStopPenyaluranRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStopPenyaluranRtwList()
    {
        // Create page object
        subAktivitasFormInputDataStopPenyaluranRtwList = new GLOBALS.SubAktivitasFormInputDataStopPenyaluranRtwList(this);
        subAktivitasFormInputDataStopPenyaluranRtwList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataStopPenyaluranRtwList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputDataStopPenyaluranRtwEdit/{id?}", Name = "SubAktivitasFormInputDataStopPenyaluranRtwEdit-SubAktivitasFormInputDataStopPenyaluranRTW-edit")]
    [Route("Home/SubAktivitasFormInputDataStopPenyaluranRtwEdit/{id?}", Name = "SubAktivitasFormInputDataStopPenyaluranRtwEdit-SubAktivitasFormInputDataStopPenyaluranRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStopPenyaluranRtwEdit()
    {
        // Create page object
        subAktivitasFormInputDataStopPenyaluranRtwEdit = new GLOBALS.SubAktivitasFormInputDataStopPenyaluranRtwEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataStopPenyaluranRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputDataStopPenyaluranRtwDelete/{id?}", Name = "SubAktivitasFormInputDataStopPenyaluranRtwDelete-SubAktivitasFormInputDataStopPenyaluranRTW-delete")]
    [Route("Home/SubAktivitasFormInputDataStopPenyaluranRtwDelete/{id?}", Name = "SubAktivitasFormInputDataStopPenyaluranRtwDelete-SubAktivitasFormInputDataStopPenyaluranRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStopPenyaluranRtwDelete()
    {
        // Create page object
        subAktivitasFormInputDataStopPenyaluranRtwDelete = new GLOBALS.SubAktivitasFormInputDataStopPenyaluranRtwDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataStopPenyaluranRtwDelete.Run();
    }
}
