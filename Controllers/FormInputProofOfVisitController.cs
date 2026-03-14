namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("FormInputProofOfVisitList/{id?}", Name = "FormInputProofOfVisitList-FormInputProofOfVisit-list")]
    [Route("Home/FormInputProofOfVisitList/{id?}", Name = "FormInputProofOfVisitList-FormInputProofOfVisit-list-2")]
    public async Task<IActionResult> FormInputProofOfVisitList()
    {
        // Create page object
        formInputProofOfVisitList = new GLOBALS.FormInputProofOfVisitList(this);
        formInputProofOfVisitList.Cache = _cache;

        // Run the page
        return await formInputProofOfVisitList.Run();
    }

    // add
    [Route("FormInputProofOfVisitAdd/{id?}", Name = "FormInputProofOfVisitAdd-FormInputProofOfVisit-add")]
    [Route("Home/FormInputProofOfVisitAdd/{id?}", Name = "FormInputProofOfVisitAdd-FormInputProofOfVisit-add-2")]
    public async Task<IActionResult> FormInputProofOfVisitAdd()
    {
        // Create page object
        formInputProofOfVisitAdd = new GLOBALS.FormInputProofOfVisitAdd(this);

        // Run the page
        return await formInputProofOfVisitAdd.Run();
    }

    // view
    [Route("FormInputProofOfVisitView/{id?}", Name = "FormInputProofOfVisitView-FormInputProofOfVisit-view")]
    [Route("Home/FormInputProofOfVisitView/{id?}", Name = "FormInputProofOfVisitView-FormInputProofOfVisit-view-2")]
    public async Task<IActionResult> FormInputProofOfVisitView()
    {
        // Create page object
        formInputProofOfVisitView = new GLOBALS.FormInputProofOfVisitView(this);

        // Run the page
        return await formInputProofOfVisitView.Run();
    }

    // edit
    [Route("FormInputProofOfVisitEdit/{id?}", Name = "FormInputProofOfVisitEdit-FormInputProofOfVisit-edit")]
    [Route("Home/FormInputProofOfVisitEdit/{id?}", Name = "FormInputProofOfVisitEdit-FormInputProofOfVisit-edit-2")]
    public async Task<IActionResult> FormInputProofOfVisitEdit()
    {
        // Create page object
        formInputProofOfVisitEdit = new GLOBALS.FormInputProofOfVisitEdit(this);

        // Run the page
        return await formInputProofOfVisitEdit.Run();
    }

    // delete
    [Route("FormInputProofOfVisitDelete/{id?}", Name = "FormInputProofOfVisitDelete-FormInputProofOfVisit-delete")]
    [Route("Home/FormInputProofOfVisitDelete/{id?}", Name = "FormInputProofOfVisitDelete-FormInputProofOfVisit-delete-2")]
    public async Task<IActionResult> FormInputProofOfVisitDelete()
    {
        // Create page object
        formInputProofOfVisitDelete = new GLOBALS.FormInputProofOfVisitDelete(this);

        // Run the page
        return await formInputProofOfVisitDelete.Run();
    }
}
