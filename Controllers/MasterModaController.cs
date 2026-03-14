namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MasterModaList/{IdModa?}", Name = "MasterModaList-MasterModa-list")]
    [Route("Home/MasterModaList/{IdModa?}", Name = "MasterModaList-MasterModa-list-2")]
    public async Task<IActionResult> MasterModaList()
    {
        // Create page object
        masterModaList = new GLOBALS.MasterModaList(this);
        masterModaList.Cache = _cache;

        // Run the page
        return await masterModaList.Run();
    }

    // add
    [Route("MasterModaAdd/{IdModa?}", Name = "MasterModaAdd-MasterModa-add")]
    [Route("Home/MasterModaAdd/{IdModa?}", Name = "MasterModaAdd-MasterModa-add-2")]
    public async Task<IActionResult> MasterModaAdd()
    {
        // Create page object
        masterModaAdd = new GLOBALS.MasterModaAdd(this);

        // Run the page
        return await masterModaAdd.Run();
    }

    // view
    [Route("MasterModaView/{IdModa?}", Name = "MasterModaView-MasterModa-view")]
    [Route("Home/MasterModaView/{IdModa?}", Name = "MasterModaView-MasterModa-view-2")]
    public async Task<IActionResult> MasterModaView()
    {
        // Create page object
        masterModaView = new GLOBALS.MasterModaView(this);

        // Run the page
        return await masterModaView.Run();
    }

    // edit
    [Route("MasterModaEdit/{IdModa?}", Name = "MasterModaEdit-MasterModa-edit")]
    [Route("Home/MasterModaEdit/{IdModa?}", Name = "MasterModaEdit-MasterModa-edit-2")]
    public async Task<IActionResult> MasterModaEdit()
    {
        // Create page object
        masterModaEdit = new GLOBALS.MasterModaEdit(this);

        // Run the page
        return await masterModaEdit.Run();
    }

    // delete
    [Route("MasterModaDelete/{IdModa?}", Name = "MasterModaDelete-MasterModa-delete")]
    [Route("Home/MasterModaDelete/{IdModa?}", Name = "MasterModaDelete-MasterModa-delete-2")]
    public async Task<IActionResult> MasterModaDelete()
    {
        // Create page object
        masterModaDelete = new GLOBALS.MasterModaDelete(this);

        // Run the page
        return await masterModaDelete.Run();
    }
}
