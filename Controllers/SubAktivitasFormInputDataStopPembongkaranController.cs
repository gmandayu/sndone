namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputDataStopPembongkaranList/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranList-SubAktivitasFormInputDataStopPembongkaran-list")]
    [Route("Home/SubAktivitasFormInputDataStopPembongkaranList/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranList-SubAktivitasFormInputDataStopPembongkaran-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStopPembongkaranList()
    {
        // Create page object
        subAktivitasFormInputDataStopPembongkaranList = new GLOBALS.SubAktivitasFormInputDataStopPembongkaranList(this);
        subAktivitasFormInputDataStopPembongkaranList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputDataStopPembongkaranList.Run();
    }

    // add
    [Route("SubAktivitasFormInputDataStopPembongkaranAdd/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranAdd-SubAktivitasFormInputDataStopPembongkaran-add")]
    [Route("Home/SubAktivitasFormInputDataStopPembongkaranAdd/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranAdd-SubAktivitasFormInputDataStopPembongkaran-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStopPembongkaranAdd()
    {
        // Create page object
        subAktivitasFormInputDataStopPembongkaranAdd = new GLOBALS.SubAktivitasFormInputDataStopPembongkaranAdd(this);

        // Run the page
        return await subAktivitasFormInputDataStopPembongkaranAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputDataStopPembongkaranView/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranView-SubAktivitasFormInputDataStopPembongkaran-view")]
    [Route("Home/SubAktivitasFormInputDataStopPembongkaranView/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranView-SubAktivitasFormInputDataStopPembongkaran-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStopPembongkaranView()
    {
        // Create page object
        subAktivitasFormInputDataStopPembongkaranView = new GLOBALS.SubAktivitasFormInputDataStopPembongkaranView(this);

        // Run the page
        return await subAktivitasFormInputDataStopPembongkaranView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputDataStopPembongkaranEdit/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranEdit-SubAktivitasFormInputDataStopPembongkaran-edit")]
    [Route("Home/SubAktivitasFormInputDataStopPembongkaranEdit/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranEdit-SubAktivitasFormInputDataStopPembongkaran-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStopPembongkaranEdit()
    {
        // Create page object
        subAktivitasFormInputDataStopPembongkaranEdit = new GLOBALS.SubAktivitasFormInputDataStopPembongkaranEdit(this);

        // Run the page
        return await subAktivitasFormInputDataStopPembongkaranEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputDataStopPembongkaranDelete/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranDelete-SubAktivitasFormInputDataStopPembongkaran-delete")]
    [Route("Home/SubAktivitasFormInputDataStopPembongkaranDelete/{id?}", Name = "SubAktivitasFormInputDataStopPembongkaranDelete-SubAktivitasFormInputDataStopPembongkaran-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStopPembongkaranDelete()
    {
        // Create page object
        subAktivitasFormInputDataStopPembongkaranDelete = new GLOBALS.SubAktivitasFormInputDataStopPembongkaranDelete(this);

        // Run the page
        return await subAktivitasFormInputDataStopPembongkaranDelete.Run();
    }
}
