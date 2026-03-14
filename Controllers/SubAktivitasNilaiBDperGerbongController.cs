namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiBDperGerbongList/{id?}", Name = "SubAktivitasNilaiBDperGerbongList-SubAktivitasNilaiBDperGerbong-list")]
    [Route("Home/SubAktivitasNilaiBDperGerbongList/{id?}", Name = "SubAktivitasNilaiBDperGerbongList-SubAktivitasNilaiBDperGerbong-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiBDperGerbongList()
    {
        // Create page object
        subAktivitasNilaiBDperGerbongList = new GLOBALS.SubAktivitasNilaiBDperGerbongList(this);
        subAktivitasNilaiBDperGerbongList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiBDperGerbongList.Run();
    }

    // add
    [Route("SubAktivitasNilaiBDperGerbongAdd/{id?}", Name = "SubAktivitasNilaiBDperGerbongAdd-SubAktivitasNilaiBDperGerbong-add")]
    [Route("Home/SubAktivitasNilaiBDperGerbongAdd/{id?}", Name = "SubAktivitasNilaiBDperGerbongAdd-SubAktivitasNilaiBDperGerbong-add-2")]
    public async Task<IActionResult> SubAktivitasNilaiBDperGerbongAdd()
    {
        // Create page object
        subAktivitasNilaiBDperGerbongAdd = new GLOBALS.SubAktivitasNilaiBDperGerbongAdd(this);

        // Run the page
        return await subAktivitasNilaiBDperGerbongAdd.Run();
    }

    // view
    [Route("SubAktivitasNilaiBDperGerbongView/{id?}", Name = "SubAktivitasNilaiBDperGerbongView-SubAktivitasNilaiBDperGerbong-view")]
    [Route("Home/SubAktivitasNilaiBDperGerbongView/{id?}", Name = "SubAktivitasNilaiBDperGerbongView-SubAktivitasNilaiBDperGerbong-view-2")]
    public async Task<IActionResult> SubAktivitasNilaiBDperGerbongView()
    {
        // Create page object
        subAktivitasNilaiBDperGerbongView = new GLOBALS.SubAktivitasNilaiBDperGerbongView(this);

        // Run the page
        return await subAktivitasNilaiBDperGerbongView.Run();
    }

    // edit
    [Route("SubAktivitasNilaiBDperGerbongEdit/{id?}", Name = "SubAktivitasNilaiBDperGerbongEdit-SubAktivitasNilaiBDperGerbong-edit")]
    [Route("Home/SubAktivitasNilaiBDperGerbongEdit/{id?}", Name = "SubAktivitasNilaiBDperGerbongEdit-SubAktivitasNilaiBDperGerbong-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiBDperGerbongEdit()
    {
        // Create page object
        subAktivitasNilaiBDperGerbongEdit = new GLOBALS.SubAktivitasNilaiBDperGerbongEdit(this);

        // Run the page
        return await subAktivitasNilaiBDperGerbongEdit.Run();
    }

    // delete
    [Route("SubAktivitasNilaiBDperGerbongDelete/{id?}", Name = "SubAktivitasNilaiBDperGerbongDelete-SubAktivitasNilaiBDperGerbong-delete")]
    [Route("Home/SubAktivitasNilaiBDperGerbongDelete/{id?}", Name = "SubAktivitasNilaiBDperGerbongDelete-SubAktivitasNilaiBDperGerbong-delete-2")]
    public async Task<IActionResult> SubAktivitasNilaiBDperGerbongDelete()
    {
        // Create page object
        subAktivitasNilaiBDperGerbongDelete = new GLOBALS.SubAktivitasNilaiBDperGerbongDelete(this);

        // Run the page
        return await subAktivitasNilaiBDperGerbongDelete.Run();
    }
}
