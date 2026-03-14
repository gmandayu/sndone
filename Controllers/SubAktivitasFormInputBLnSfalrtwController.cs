namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputBLnSfalrtwList/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwList-SubAktivitasFormInputBLnSFALRTW-list")]
    [Route("Home/SubAktivitasFormInputBLnSfalrtwList/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwList-SubAktivitasFormInputBLnSFALRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputBLnSfalrtwList()
    {
        // Create page object
        subAktivitasFormInputBLnSfalrtwList = new GLOBALS.SubAktivitasFormInputBLnSfalrtwList(this);
        subAktivitasFormInputBLnSfalrtwList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputBLnSfalrtwList.Run();
    }

    // add
    [Route("SubAktivitasFormInputBLnSfalrtwAdd/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwAdd-SubAktivitasFormInputBLnSFALRTW-add")]
    [Route("Home/SubAktivitasFormInputBLnSfalrtwAdd/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwAdd-SubAktivitasFormInputBLnSFALRTW-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputBLnSfalrtwAdd()
    {
        // Create page object
        subAktivitasFormInputBLnSfalrtwAdd = new GLOBALS.SubAktivitasFormInputBLnSfalrtwAdd(this);

        // Run the page
        return await subAktivitasFormInputBLnSfalrtwAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputBLnSfalrtwView/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwView-SubAktivitasFormInputBLnSFALRTW-view")]
    [Route("Home/SubAktivitasFormInputBLnSfalrtwView/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwView-SubAktivitasFormInputBLnSFALRTW-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputBLnSfalrtwView()
    {
        // Create page object
        subAktivitasFormInputBLnSfalrtwView = new GLOBALS.SubAktivitasFormInputBLnSfalrtwView(this);

        // Run the page
        return await subAktivitasFormInputBLnSfalrtwView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputBLnSfalrtwEdit/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwEdit-SubAktivitasFormInputBLnSFALRTW-edit")]
    [Route("Home/SubAktivitasFormInputBLnSfalrtwEdit/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwEdit-SubAktivitasFormInputBLnSFALRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputBLnSfalrtwEdit()
    {
        // Create page object
        subAktivitasFormInputBLnSfalrtwEdit = new GLOBALS.SubAktivitasFormInputBLnSfalrtwEdit(this);

        // Run the page
        return await subAktivitasFormInputBLnSfalrtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputBLnSfalrtwDelete/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwDelete-SubAktivitasFormInputBLnSFALRTW-delete")]
    [Route("Home/SubAktivitasFormInputBLnSfalrtwDelete/{id?}", Name = "SubAktivitasFormInputBLnSfalrtwDelete-SubAktivitasFormInputBLnSFALRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputBLnSfalrtwDelete()
    {
        // Create page object
        subAktivitasFormInputBLnSfalrtwDelete = new GLOBALS.SubAktivitasFormInputBLnSfalrtwDelete(this);

        // Run the page
        return await subAktivitasFormInputBLnSfalrtwDelete.Run();
    }
}
