namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterDermagaList/{IdDermaga?}", Name = "MasterDermagaList-MasterDermaga-list")]
    [Route("Home/MasterDermagaList/{IdDermaga?}", Name = "MasterDermagaList-MasterDermaga-list-2")]
    public async Task<IActionResult> MasterDermagaList()
    {
        // Create page object
        masterDermagaList = new GLOBALS.MasterDermagaList(this);
        masterDermagaList.Cache = _cache;

        // Run the page
        return await masterDermagaList.Run();
    }

    // add
    [Route("MasterDermagaAdd/{IdDermaga?}", Name = "MasterDermagaAdd-MasterDermaga-add")]
    [Route("Home/MasterDermagaAdd/{IdDermaga?}", Name = "MasterDermagaAdd-MasterDermaga-add-2")]
    public async Task<IActionResult> MasterDermagaAdd()
    {
        // Create page object
        masterDermagaAdd = new GLOBALS.MasterDermagaAdd(this);

        // Run the page
        return await masterDermagaAdd.Run();
    }

    // view
    [Route("MasterDermagaView/{IdDermaga?}", Name = "MasterDermagaView-MasterDermaga-view")]
    [Route("Home/MasterDermagaView/{IdDermaga?}", Name = "MasterDermagaView-MasterDermaga-view-2")]
    public async Task<IActionResult> MasterDermagaView()
    {
        // Create page object
        masterDermagaView = new GLOBALS.MasterDermagaView(this);

        // Run the page
        return await masterDermagaView.Run();
    }

    // edit
    [Route("MasterDermagaEdit/{IdDermaga?}", Name = "MasterDermagaEdit-MasterDermaga-edit")]
    [Route("Home/MasterDermagaEdit/{IdDermaga?}", Name = "MasterDermagaEdit-MasterDermaga-edit-2")]
    public async Task<IActionResult> MasterDermagaEdit()
    {
        // Create page object
        masterDermagaEdit = new GLOBALS.MasterDermagaEdit(this);

        // Run the page
        return await masterDermagaEdit.Run();
    }

    // delete
    [Route("MasterDermagaDelete/{IdDermaga?}", Name = "MasterDermagaDelete-MasterDermaga-delete")]
    [Route("Home/MasterDermagaDelete/{IdDermaga?}", Name = "MasterDermagaDelete-MasterDermaga-delete-2")]
    public async Task<IActionResult> MasterDermagaDelete()
    {
        // Create page object
        masterDermagaDelete = new GLOBALS.MasterDermagaDelete(this);

        // Run the page
        return await masterDermagaDelete.Run();
    }
}
