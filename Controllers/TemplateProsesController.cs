namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TemplateProsesList/{IdTemplateProses?}", Name = "TemplateProsesList-TemplateProses-list")]
    [Route("Home/TemplateProsesList/{IdTemplateProses?}", Name = "TemplateProsesList-TemplateProses-list-2")]
    public async Task<IActionResult> TemplateProsesList()
    {
        // Create page object
        templateProsesList = new GLOBALS.TemplateProsesList(this);
        templateProsesList.Cache = _cache;

        // Run the page
        return await templateProsesList.Run();
    }

    // add
    [Route("TemplateProsesAdd/{IdTemplateProses?}", Name = "TemplateProsesAdd-TemplateProses-add")]
    [Route("Home/TemplateProsesAdd/{IdTemplateProses?}", Name = "TemplateProsesAdd-TemplateProses-add-2")]
    public async Task<IActionResult> TemplateProsesAdd()
    {
        // Create page object
        templateProsesAdd = new GLOBALS.TemplateProsesAdd(this);

        // Run the page
        return await templateProsesAdd.Run();
    }

    // view
    [Route("TemplateProsesView/{IdTemplateProses?}", Name = "TemplateProsesView-TemplateProses-view")]
    [Route("Home/TemplateProsesView/{IdTemplateProses?}", Name = "TemplateProsesView-TemplateProses-view-2")]
    public async Task<IActionResult> TemplateProsesView()
    {
        // Create page object
        templateProsesView = new GLOBALS.TemplateProsesView(this);

        // Run the page
        return await templateProsesView.Run();
    }

    // edit
    [Route("TemplateProsesEdit/{IdTemplateProses?}", Name = "TemplateProsesEdit-TemplateProses-edit")]
    [Route("Home/TemplateProsesEdit/{IdTemplateProses?}", Name = "TemplateProsesEdit-TemplateProses-edit-2")]
    public async Task<IActionResult> TemplateProsesEdit()
    {
        // Create page object
        templateProsesEdit = new GLOBALS.TemplateProsesEdit(this);

        // Run the page
        return await templateProsesEdit.Run();
    }

    // delete
    [Route("TemplateProsesDelete/{IdTemplateProses?}", Name = "TemplateProsesDelete-TemplateProses-delete")]
    [Route("Home/TemplateProsesDelete/{IdTemplateProses?}", Name = "TemplateProsesDelete-TemplateProses-delete-2")]
    public async Task<IActionResult> TemplateProsesDelete()
    {
        // Create page object
        templateProsesDelete = new GLOBALS.TemplateProsesDelete(this);

        // Run the page
        return await templateProsesDelete.Run();
    }
}
