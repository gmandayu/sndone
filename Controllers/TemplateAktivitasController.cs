namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TemplateAktivitasList/{IdTemplateAktivitas?}", Name = "TemplateAktivitasList-TemplateAktivitas-list")]
    [Route("Home/TemplateAktivitasList/{IdTemplateAktivitas?}", Name = "TemplateAktivitasList-TemplateAktivitas-list-2")]
    public async Task<IActionResult> TemplateAktivitasList()
    {
        // Create page object
        templateAktivitasList = new GLOBALS.TemplateAktivitasList(this);
        templateAktivitasList.Cache = _cache;

        // Run the page
        return await templateAktivitasList.Run();
    }

    // add
    [Route("TemplateAktivitasAdd/{IdTemplateAktivitas?}", Name = "TemplateAktivitasAdd-TemplateAktivitas-add")]
    [Route("Home/TemplateAktivitasAdd/{IdTemplateAktivitas?}", Name = "TemplateAktivitasAdd-TemplateAktivitas-add-2")]
    public async Task<IActionResult> TemplateAktivitasAdd()
    {
        // Create page object
        templateAktivitasAdd = new GLOBALS.TemplateAktivitasAdd(this);

        // Run the page
        return await templateAktivitasAdd.Run();
    }

    // view
    [Route("TemplateAktivitasView/{IdTemplateAktivitas?}", Name = "TemplateAktivitasView-TemplateAktivitas-view")]
    [Route("Home/TemplateAktivitasView/{IdTemplateAktivitas?}", Name = "TemplateAktivitasView-TemplateAktivitas-view-2")]
    public async Task<IActionResult> TemplateAktivitasView()
    {
        // Create page object
        templateAktivitasView = new GLOBALS.TemplateAktivitasView(this);

        // Run the page
        return await templateAktivitasView.Run();
    }

    // edit
    [Route("TemplateAktivitasEdit/{IdTemplateAktivitas?}", Name = "TemplateAktivitasEdit-TemplateAktivitas-edit")]
    [Route("Home/TemplateAktivitasEdit/{IdTemplateAktivitas?}", Name = "TemplateAktivitasEdit-TemplateAktivitas-edit-2")]
    public async Task<IActionResult> TemplateAktivitasEdit()
    {
        // Create page object
        templateAktivitasEdit = new GLOBALS.TemplateAktivitasEdit(this);

        // Run the page
        return await templateAktivitasEdit.Run();
    }

    // delete
    [Route("TemplateAktivitasDelete/{IdTemplateAktivitas?}", Name = "TemplateAktivitasDelete-TemplateAktivitas-delete")]
    [Route("Home/TemplateAktivitasDelete/{IdTemplateAktivitas?}", Name = "TemplateAktivitasDelete-TemplateAktivitas-delete-2")]
    public async Task<IActionResult> TemplateAktivitasDelete()
    {
        // Create page object
        templateAktivitasDelete = new GLOBALS.TemplateAktivitasDelete(this);

        // Run the page
        return await templateAktivitasDelete.Run();
    }
}
