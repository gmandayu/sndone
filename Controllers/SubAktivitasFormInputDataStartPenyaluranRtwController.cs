namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputDataStartPenyaluranRtwList/{id?}", Name = "SubAktivitasFormInputDataStartPenyaluranRtwList-SubAktivitasFormInputDataStartPenyaluranRTW-list")]
    [Route("Home/SubAktivitasFormInputDataStartPenyaluranRtwList/{id?}", Name = "SubAktivitasFormInputDataStartPenyaluranRtwList-SubAktivitasFormInputDataStartPenyaluranRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStartPenyaluranRtwList()
    {
        // Create page object
        subAktivitasFormInputDataStartPenyaluranRtwList = new GLOBALS.SubAktivitasFormInputDataStartPenyaluranRtwList(this);
        subAktivitasFormInputDataStartPenyaluranRtwList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataStartPenyaluranRtwList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputDataStartPenyaluranRtwEdit/{id?}", Name = "SubAktivitasFormInputDataStartPenyaluranRtwEdit-SubAktivitasFormInputDataStartPenyaluranRTW-edit")]
    [Route("Home/SubAktivitasFormInputDataStartPenyaluranRtwEdit/{id?}", Name = "SubAktivitasFormInputDataStartPenyaluranRtwEdit-SubAktivitasFormInputDataStartPenyaluranRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStartPenyaluranRtwEdit()
    {
        // Create page object
        subAktivitasFormInputDataStartPenyaluranRtwEdit = new GLOBALS.SubAktivitasFormInputDataStartPenyaluranRtwEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataStartPenyaluranRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputDataStartPenyaluranRtwDelete/{id?}", Name = "SubAktivitasFormInputDataStartPenyaluranRtwDelete-SubAktivitasFormInputDataStartPenyaluranRTW-delete")]
    [Route("Home/SubAktivitasFormInputDataStartPenyaluranRtwDelete/{id?}", Name = "SubAktivitasFormInputDataStartPenyaluranRtwDelete-SubAktivitasFormInputDataStartPenyaluranRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStartPenyaluranRtwDelete()
    {
        // Create page object
        subAktivitasFormInputDataStartPenyaluranRtwDelete = new GLOBALS.SubAktivitasFormInputDataStartPenyaluranRtwDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataStartPenyaluranRtwDelete.Run();
    }
}
