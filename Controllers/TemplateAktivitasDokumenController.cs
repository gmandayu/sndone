namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TemplateAktivitasDokumenList/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenList-TemplateAktivitasDokumen-list")]
    [Route("Home/TemplateAktivitasDokumenList/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenList-TemplateAktivitasDokumen-list-2")]
    public async Task<IActionResult> TemplateAktivitasDokumenList()
    {
        // Create page object
        templateAktivitasDokumenList = new GLOBALS.TemplateAktivitasDokumenList(this);
        templateAktivitasDokumenList.Cache = _cache;

        // Run the page
        return await templateAktivitasDokumenList.Run();
    }

    // add
    [Route("TemplateAktivitasDokumenAdd/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenAdd-TemplateAktivitasDokumen-add")]
    [Route("Home/TemplateAktivitasDokumenAdd/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenAdd-TemplateAktivitasDokumen-add-2")]
    public async Task<IActionResult> TemplateAktivitasDokumenAdd()
    {
        // Create page object
        templateAktivitasDokumenAdd = new GLOBALS.TemplateAktivitasDokumenAdd(this);

        // Run the page
        return await templateAktivitasDokumenAdd.Run();
    }

    // view
    [Route("TemplateAktivitasDokumenView/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenView-TemplateAktivitasDokumen-view")]
    [Route("Home/TemplateAktivitasDokumenView/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenView-TemplateAktivitasDokumen-view-2")]
    public async Task<IActionResult> TemplateAktivitasDokumenView()
    {
        // Create page object
        templateAktivitasDokumenView = new GLOBALS.TemplateAktivitasDokumenView(this);

        // Run the page
        return await templateAktivitasDokumenView.Run();
    }

    // edit
    [Route("TemplateAktivitasDokumenEdit/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenEdit-TemplateAktivitasDokumen-edit")]
    [Route("Home/TemplateAktivitasDokumenEdit/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenEdit-TemplateAktivitasDokumen-edit-2")]
    public async Task<IActionResult> TemplateAktivitasDokumenEdit()
    {
        // Create page object
        templateAktivitasDokumenEdit = new GLOBALS.TemplateAktivitasDokumenEdit(this);

        // Run the page
        return await templateAktivitasDokumenEdit.Run();
    }

    // delete
    [Route("TemplateAktivitasDokumenDelete/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenDelete-TemplateAktivitasDokumen-delete")]
    [Route("Home/TemplateAktivitasDokumenDelete/{IdTemplateAktivitasDokumen?}", Name = "TemplateAktivitasDokumenDelete-TemplateAktivitasDokumen-delete-2")]
    public async Task<IActionResult> TemplateAktivitasDokumenDelete()
    {
        // Create page object
        templateAktivitasDokumenDelete = new GLOBALS.TemplateAktivitasDokumenDelete(this);

        // Run the page
        return await templateAktivitasDokumenDelete.Run();
    }
}
