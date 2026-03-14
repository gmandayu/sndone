namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputDataGerbongKetelRtwList/{id?}", Name = "SubAktivitasFormInputDataGerbongKetelRtwList-SubAktivitasFormInputDataGerbongKetelRTW-list")]
    [Route("Home/SubAktivitasFormInputDataGerbongKetelRtwList/{id?}", Name = "SubAktivitasFormInputDataGerbongKetelRtwList-SubAktivitasFormInputDataGerbongKetelRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataGerbongKetelRtwList()
    {
        // Create page object
        subAktivitasFormInputDataGerbongKetelRtwList = new GLOBALS.SubAktivitasFormInputDataGerbongKetelRtwList(this);
        subAktivitasFormInputDataGerbongKetelRtwList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputDataGerbongKetelRtwList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputDataGerbongKetelRtwEdit/{id?}", Name = "SubAktivitasFormInputDataGerbongKetelRtwEdit-SubAktivitasFormInputDataGerbongKetelRTW-edit")]
    [Route("Home/SubAktivitasFormInputDataGerbongKetelRtwEdit/{id?}", Name = "SubAktivitasFormInputDataGerbongKetelRtwEdit-SubAktivitasFormInputDataGerbongKetelRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataGerbongKetelRtwEdit()
    {
        // Create page object
        subAktivitasFormInputDataGerbongKetelRtwEdit = new GLOBALS.SubAktivitasFormInputDataGerbongKetelRtwEdit(this);

        // Run the page
        return await subAktivitasFormInputDataGerbongKetelRtwEdit.Run();
    }
}
