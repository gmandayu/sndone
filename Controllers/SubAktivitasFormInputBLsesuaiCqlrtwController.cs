namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputBLsesuaiCqlrtwList/{id?}", Name = "SubAktivitasFormInputBLsesuaiCqlrtwList-SubAktivitasFormInputBLsesuaiCQLRTW-list")]
    [Route("Home/SubAktivitasFormInputBLsesuaiCqlrtwList/{id?}", Name = "SubAktivitasFormInputBLsesuaiCqlrtwList-SubAktivitasFormInputBLsesuaiCQLRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputBLsesuaiCqlrtwList()
    {
        // Create page object
        subAktivitasFormInputBLsesuaiCqlrtwList = new GLOBALS.SubAktivitasFormInputBLsesuaiCqlrtwList(this);
        subAktivitasFormInputBLsesuaiCqlrtwList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputBLsesuaiCqlrtwList.Run();
    }

    // view
    [Route("SubAktivitasFormInputBLsesuaiCqlrtwView/{id?}", Name = "SubAktivitasFormInputBLsesuaiCqlrtwView-SubAktivitasFormInputBLsesuaiCQLRTW-view")]
    [Route("Home/SubAktivitasFormInputBLsesuaiCqlrtwView/{id?}", Name = "SubAktivitasFormInputBLsesuaiCqlrtwView-SubAktivitasFormInputBLsesuaiCQLRTW-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputBLsesuaiCqlrtwView()
    {
        // Create page object
        subAktivitasFormInputBLsesuaiCqlrtwView = new GLOBALS.SubAktivitasFormInputBLsesuaiCqlrtwView(this);

        // Run the page
        return await subAktivitasFormInputBLsesuaiCqlrtwView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputBLsesuaiCqlrtwEdit/{id?}", Name = "SubAktivitasFormInputBLsesuaiCqlrtwEdit-SubAktivitasFormInputBLsesuaiCQLRTW-edit")]
    [Route("Home/SubAktivitasFormInputBLsesuaiCqlrtwEdit/{id?}", Name = "SubAktivitasFormInputBLsesuaiCqlrtwEdit-SubAktivitasFormInputBLsesuaiCQLRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputBLsesuaiCqlrtwEdit()
    {
        // Create page object
        subAktivitasFormInputBLsesuaiCqlrtwEdit = new GLOBALS.SubAktivitasFormInputBLsesuaiCqlrtwEdit(this);

        // Run the page
        return await subAktivitasFormInputBLsesuaiCqlrtwEdit.Run();
    }
}
