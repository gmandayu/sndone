namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputNilaiBLnAlList/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlList-SubAktivitasFormInputNilaiBLnAL-list")]
    [Route("Home/SubAktivitasFormInputNilaiBLnAlList/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlList-SubAktivitasFormInputNilaiBLnAL-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLnAlList()
    {
        // Create page object
        subAktivitasFormInputNilaiBLnAlList = new GLOBALS.SubAktivitasFormInputNilaiBLnAlList(this);
        subAktivitasFormInputNilaiBLnAlList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputNilaiBLnAlList.Run();
    }

    // add
    [Route("SubAktivitasFormInputNilaiBLnAlAdd/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlAdd-SubAktivitasFormInputNilaiBLnAL-add")]
    [Route("Home/SubAktivitasFormInputNilaiBLnAlAdd/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlAdd-SubAktivitasFormInputNilaiBLnAL-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLnAlAdd()
    {
        // Create page object
        subAktivitasFormInputNilaiBLnAlAdd = new GLOBALS.SubAktivitasFormInputNilaiBLnAlAdd(this);

        // Run the page
        return await subAktivitasFormInputNilaiBLnAlAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputNilaiBLnAlView/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlView-SubAktivitasFormInputNilaiBLnAL-view")]
    [Route("Home/SubAktivitasFormInputNilaiBLnAlView/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlView-SubAktivitasFormInputNilaiBLnAL-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLnAlView()
    {
        // Create page object
        subAktivitasFormInputNilaiBLnAlView = new GLOBALS.SubAktivitasFormInputNilaiBLnAlView(this);

        // Run the page
        return await subAktivitasFormInputNilaiBLnAlView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputNilaiBLnAlEdit/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlEdit-SubAktivitasFormInputNilaiBLnAL-edit")]
    [Route("Home/SubAktivitasFormInputNilaiBLnAlEdit/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlEdit-SubAktivitasFormInputNilaiBLnAL-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLnAlEdit()
    {
        // Create page object
        subAktivitasFormInputNilaiBLnAlEdit = new GLOBALS.SubAktivitasFormInputNilaiBLnAlEdit(this);

        // Run the page
        return await subAktivitasFormInputNilaiBLnAlEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputNilaiBLnAlDelete/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlDelete-SubAktivitasFormInputNilaiBLnAL-delete")]
    [Route("Home/SubAktivitasFormInputNilaiBLnAlDelete/{id?}", Name = "SubAktivitasFormInputNilaiBLnAlDelete-SubAktivitasFormInputNilaiBLnAL-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLnAlDelete()
    {
        // Create page object
        subAktivitasFormInputNilaiBLnAlDelete = new GLOBALS.SubAktivitasFormInputNilaiBLnAlDelete(this);

        // Run the page
        return await subAktivitasFormInputNilaiBLnAlDelete.Run();
    }
}
