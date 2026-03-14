namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasKeberangkatanRtwList/{id?}", Name = "SubAktivitasKeberangkatanRtwList-SubAktivitasKeberangkatanRTW-list")]
    [Route("Home/SubAktivitasKeberangkatanRtwList/{id?}", Name = "SubAktivitasKeberangkatanRtwList-SubAktivitasKeberangkatanRTW-list-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanRtwList()
    {
        // Create page object
        subAktivitasKeberangkatanRtwList = new GLOBALS.SubAktivitasKeberangkatanRtwList(this);
        subAktivitasKeberangkatanRtwList.Cache = _cache;

        // Run the page
        return await subAktivitasKeberangkatanRtwList.Run();
    }

    // add
    [Route("SubAktivitasKeberangkatanRtwAdd/{id?}", Name = "SubAktivitasKeberangkatanRtwAdd-SubAktivitasKeberangkatanRTW-add")]
    [Route("Home/SubAktivitasKeberangkatanRtwAdd/{id?}", Name = "SubAktivitasKeberangkatanRtwAdd-SubAktivitasKeberangkatanRTW-add-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanRtwAdd()
    {
        // Create page object
        subAktivitasKeberangkatanRtwAdd = new GLOBALS.SubAktivitasKeberangkatanRtwAdd(this);

        // Run the page
        return await subAktivitasKeberangkatanRtwAdd.Run();
    }

    // view
    [Route("SubAktivitasKeberangkatanRtwView/{id?}", Name = "SubAktivitasKeberangkatanRtwView-SubAktivitasKeberangkatanRTW-view")]
    [Route("Home/SubAktivitasKeberangkatanRtwView/{id?}", Name = "SubAktivitasKeberangkatanRtwView-SubAktivitasKeberangkatanRTW-view-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanRtwView()
    {
        // Create page object
        subAktivitasKeberangkatanRtwView = new GLOBALS.SubAktivitasKeberangkatanRtwView(this);

        // Run the page
        return await subAktivitasKeberangkatanRtwView.Run();
    }

    // edit
    [Route("SubAktivitasKeberangkatanRtwEdit/{id?}", Name = "SubAktivitasKeberangkatanRtwEdit-SubAktivitasKeberangkatanRTW-edit")]
    [Route("Home/SubAktivitasKeberangkatanRtwEdit/{id?}", Name = "SubAktivitasKeberangkatanRtwEdit-SubAktivitasKeberangkatanRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanRtwEdit()
    {
        // Create page object
        subAktivitasKeberangkatanRtwEdit = new GLOBALS.SubAktivitasKeberangkatanRtwEdit(this);

        // Run the page
        return await subAktivitasKeberangkatanRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasKeberangkatanRtwDelete/{id?}", Name = "SubAktivitasKeberangkatanRtwDelete-SubAktivitasKeberangkatanRTW-delete")]
    [Route("Home/SubAktivitasKeberangkatanRtwDelete/{id?}", Name = "SubAktivitasKeberangkatanRtwDelete-SubAktivitasKeberangkatanRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasKeberangkatanRtwDelete()
    {
        // Create page object
        subAktivitasKeberangkatanRtwDelete = new GLOBALS.SubAktivitasKeberangkatanRtwDelete(this);

        // Run the page
        return await subAktivitasKeberangkatanRtwDelete.Run();
    }
}
