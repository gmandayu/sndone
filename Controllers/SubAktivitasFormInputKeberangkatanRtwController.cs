namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputKeberangkatanRtwList/{id?}", Name = "SubAktivitasFormInputKeberangkatanRtwList-SubAktivitasFormInputKeberangkatanRTW-list")]
    [Route("Home/SubAktivitasFormInputKeberangkatanRtwList/{id?}", Name = "SubAktivitasFormInputKeberangkatanRtwList-SubAktivitasFormInputKeberangkatanRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputKeberangkatanRtwList()
    {
        // Create page object
        subAktivitasFormInputKeberangkatanRtwList = new GLOBALS.SubAktivitasFormInputKeberangkatanRtwList(this);
        subAktivitasFormInputKeberangkatanRtwList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputKeberangkatanRtwList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputKeberangkatanRtwEdit/{id?}", Name = "SubAktivitasFormInputKeberangkatanRtwEdit-SubAktivitasFormInputKeberangkatanRTW-edit")]
    [Route("Home/SubAktivitasFormInputKeberangkatanRtwEdit/{id?}", Name = "SubAktivitasFormInputKeberangkatanRtwEdit-SubAktivitasFormInputKeberangkatanRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputKeberangkatanRtwEdit()
    {
        // Create page object
        subAktivitasFormInputKeberangkatanRtwEdit = new GLOBALS.SubAktivitasFormInputKeberangkatanRtwEdit(this);

        // Run the page
        return await subAktivitasFormInputKeberangkatanRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputKeberangkatanRtwDelete/{id?}", Name = "SubAktivitasFormInputKeberangkatanRtwDelete-SubAktivitasFormInputKeberangkatanRTW-delete")]
    [Route("Home/SubAktivitasFormInputKeberangkatanRtwDelete/{id?}", Name = "SubAktivitasFormInputKeberangkatanRtwDelete-SubAktivitasFormInputKeberangkatanRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputKeberangkatanRtwDelete()
    {
        // Create page object
        subAktivitasFormInputKeberangkatanRtwDelete = new GLOBALS.SubAktivitasFormInputKeberangkatanRtwDelete(this);

        // Run the page
        return await subAktivitasFormInputKeberangkatanRtwDelete.Run();
    }
}
