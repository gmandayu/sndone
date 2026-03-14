namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputDataStartPembongkaranList/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranList-SubAktivitasFormInputDataStartPembongkaran-list")]
    [Route("Home/SubAktivitasFormInputDataStartPembongkaranList/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranList-SubAktivitasFormInputDataStartPembongkaran-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStartPembongkaranList()
    {
        // Create page object
        subAktivitasFormInputDataStartPembongkaranList = new GLOBALS.SubAktivitasFormInputDataStartPembongkaranList(this);
        subAktivitasFormInputDataStartPembongkaranList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputDataStartPembongkaranList.Run();
    }

    // add
    [Route("SubAktivitasFormInputDataStartPembongkaranAdd/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranAdd-SubAktivitasFormInputDataStartPembongkaran-add")]
    [Route("Home/SubAktivitasFormInputDataStartPembongkaranAdd/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranAdd-SubAktivitasFormInputDataStartPembongkaran-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStartPembongkaranAdd()
    {
        // Create page object
        subAktivitasFormInputDataStartPembongkaranAdd = new GLOBALS.SubAktivitasFormInputDataStartPembongkaranAdd(this);

        // Run the page
        return await subAktivitasFormInputDataStartPembongkaranAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputDataStartPembongkaranView/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranView-SubAktivitasFormInputDataStartPembongkaran-view")]
    [Route("Home/SubAktivitasFormInputDataStartPembongkaranView/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranView-SubAktivitasFormInputDataStartPembongkaran-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStartPembongkaranView()
    {
        // Create page object
        subAktivitasFormInputDataStartPembongkaranView = new GLOBALS.SubAktivitasFormInputDataStartPembongkaranView(this);

        // Run the page
        return await subAktivitasFormInputDataStartPembongkaranView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputDataStartPembongkaranEdit/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranEdit-SubAktivitasFormInputDataStartPembongkaran-edit")]
    [Route("Home/SubAktivitasFormInputDataStartPembongkaranEdit/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranEdit-SubAktivitasFormInputDataStartPembongkaran-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStartPembongkaranEdit()
    {
        // Create page object
        subAktivitasFormInputDataStartPembongkaranEdit = new GLOBALS.SubAktivitasFormInputDataStartPembongkaranEdit(this);

        // Run the page
        return await subAktivitasFormInputDataStartPembongkaranEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputDataStartPembongkaranDelete/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranDelete-SubAktivitasFormInputDataStartPembongkaran-delete")]
    [Route("Home/SubAktivitasFormInputDataStartPembongkaranDelete/{id?}", Name = "SubAktivitasFormInputDataStartPembongkaranDelete-SubAktivitasFormInputDataStartPembongkaran-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataStartPembongkaranDelete()
    {
        // Create page object
        subAktivitasFormInputDataStartPembongkaranDelete = new GLOBALS.SubAktivitasFormInputDataStartPembongkaranDelete(this);

        // Run the page
        return await subAktivitasFormInputDataStartPembongkaranDelete.Run();
    }
}
