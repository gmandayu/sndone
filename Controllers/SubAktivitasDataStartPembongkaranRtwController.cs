namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasDataStartPembongkaranRtwList/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwList-SubAktivitasDataStartPembongkaranRTW-list")]
    [Route("Home/SubAktivitasDataStartPembongkaranRtwList/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwList-SubAktivitasDataStartPembongkaranRTW-list-2")]
    public async Task<IActionResult> SubAktivitasDataStartPembongkaranRtwList()
    {
        // Create page object
        subAktivitasDataStartPembongkaranRtwList = new GLOBALS.SubAktivitasDataStartPembongkaranRtwList(this);
        subAktivitasDataStartPembongkaranRtwList.Cache = _cache;

        // Run the page
        return await subAktivitasDataStartPembongkaranRtwList.Run();
    }

    // add
    [Route("SubAktivitasDataStartPembongkaranRtwAdd/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwAdd-SubAktivitasDataStartPembongkaranRTW-add")]
    [Route("Home/SubAktivitasDataStartPembongkaranRtwAdd/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwAdd-SubAktivitasDataStartPembongkaranRTW-add-2")]
    public async Task<IActionResult> SubAktivitasDataStartPembongkaranRtwAdd()
    {
        // Create page object
        subAktivitasDataStartPembongkaranRtwAdd = new GLOBALS.SubAktivitasDataStartPembongkaranRtwAdd(this);

        // Run the page
        return await subAktivitasDataStartPembongkaranRtwAdd.Run();
    }

    // view
    [Route("SubAktivitasDataStartPembongkaranRtwView/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwView-SubAktivitasDataStartPembongkaranRTW-view")]
    [Route("Home/SubAktivitasDataStartPembongkaranRtwView/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwView-SubAktivitasDataStartPembongkaranRTW-view-2")]
    public async Task<IActionResult> SubAktivitasDataStartPembongkaranRtwView()
    {
        // Create page object
        subAktivitasDataStartPembongkaranRtwView = new GLOBALS.SubAktivitasDataStartPembongkaranRtwView(this);

        // Run the page
        return await subAktivitasDataStartPembongkaranRtwView.Run();
    }

    // edit
    [Route("SubAktivitasDataStartPembongkaranRtwEdit/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwEdit-SubAktivitasDataStartPembongkaranRTW-edit")]
    [Route("Home/SubAktivitasDataStartPembongkaranRtwEdit/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwEdit-SubAktivitasDataStartPembongkaranRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasDataStartPembongkaranRtwEdit()
    {
        // Create page object
        subAktivitasDataStartPembongkaranRtwEdit = new GLOBALS.SubAktivitasDataStartPembongkaranRtwEdit(this);

        // Run the page
        return await subAktivitasDataStartPembongkaranRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasDataStartPembongkaranRtwDelete/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwDelete-SubAktivitasDataStartPembongkaranRTW-delete")]
    [Route("Home/SubAktivitasDataStartPembongkaranRtwDelete/{id?}", Name = "SubAktivitasDataStartPembongkaranRtwDelete-SubAktivitasDataStartPembongkaranRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasDataStartPembongkaranRtwDelete()
    {
        // Create page object
        subAktivitasDataStartPembongkaranRtwDelete = new GLOBALS.SubAktivitasDataStartPembongkaranRtwDelete(this);

        // Run the page
        return await subAktivitasDataStartPembongkaranRtwDelete.Run();
    }
}
