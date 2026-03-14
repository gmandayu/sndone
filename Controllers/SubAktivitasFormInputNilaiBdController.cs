namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputNilaiBdList/{id?}", Name = "SubAktivitasFormInputNilaiBdList-SubAktivitasFormInputNilaiBD-list")]
    [Route("Home/SubAktivitasFormInputNilaiBdList/{id?}", Name = "SubAktivitasFormInputNilaiBdList-SubAktivitasFormInputNilaiBD-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBdList()
    {
        // Create page object
        subAktivitasFormInputNilaiBdList = new GLOBALS.SubAktivitasFormInputNilaiBdList(this);
        subAktivitasFormInputNilaiBdList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputNilaiBdList.Run();
    }

    // add
    [Route("SubAktivitasFormInputNilaiBdAdd/{id?}", Name = "SubAktivitasFormInputNilaiBdAdd-SubAktivitasFormInputNilaiBD-add")]
    [Route("Home/SubAktivitasFormInputNilaiBdAdd/{id?}", Name = "SubAktivitasFormInputNilaiBdAdd-SubAktivitasFormInputNilaiBD-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBdAdd()
    {
        // Create page object
        subAktivitasFormInputNilaiBdAdd = new GLOBALS.SubAktivitasFormInputNilaiBdAdd(this);

        // Run the page
        return await subAktivitasFormInputNilaiBdAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputNilaiBdView/{id?}", Name = "SubAktivitasFormInputNilaiBdView-SubAktivitasFormInputNilaiBD-view")]
    [Route("Home/SubAktivitasFormInputNilaiBdView/{id?}", Name = "SubAktivitasFormInputNilaiBdView-SubAktivitasFormInputNilaiBD-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBdView()
    {
        // Create page object
        subAktivitasFormInputNilaiBdView = new GLOBALS.SubAktivitasFormInputNilaiBdView(this);

        // Run the page
        return await subAktivitasFormInputNilaiBdView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputNilaiBdEdit/{id?}", Name = "SubAktivitasFormInputNilaiBdEdit-SubAktivitasFormInputNilaiBD-edit")]
    [Route("Home/SubAktivitasFormInputNilaiBdEdit/{id?}", Name = "SubAktivitasFormInputNilaiBdEdit-SubAktivitasFormInputNilaiBD-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBdEdit()
    {
        // Create page object
        subAktivitasFormInputNilaiBdEdit = new GLOBALS.SubAktivitasFormInputNilaiBdEdit(this);

        // Run the page
        return await subAktivitasFormInputNilaiBdEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputNilaiBdDelete/{id?}", Name = "SubAktivitasFormInputNilaiBdDelete-SubAktivitasFormInputNilaiBD-delete")]
    [Route("Home/SubAktivitasFormInputNilaiBdDelete/{id?}", Name = "SubAktivitasFormInputNilaiBdDelete-SubAktivitasFormInputNilaiBD-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBdDelete()
    {
        // Create page object
        subAktivitasFormInputNilaiBdDelete = new GLOBALS.SubAktivitasFormInputNilaiBdDelete(this);

        // Run the page
        return await subAktivitasFormInputNilaiBdDelete.Run();
    }
}
