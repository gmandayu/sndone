namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("FormInputControlRutinSecurityList/{Id?}", Name = "FormInputControlRutinSecurityList-FormInputControlRutinSecurity-list")]
    [Route("Home/FormInputControlRutinSecurityList/{Id?}", Name = "FormInputControlRutinSecurityList-FormInputControlRutinSecurity-list-2")]
    public async Task<IActionResult> FormInputControlRutinSecurityList()
    {
        // Create page object
        formInputControlRutinSecurityList = new GLOBALS.FormInputControlRutinSecurityList(this);
        formInputControlRutinSecurityList.Cache = _cache;

        // Run the page
        return await formInputControlRutinSecurityList.Run();
    }

    // add
    [Route("FormInputControlRutinSecurityAdd/{Id?}", Name = "FormInputControlRutinSecurityAdd-FormInputControlRutinSecurity-add")]
    [Route("Home/FormInputControlRutinSecurityAdd/{Id?}", Name = "FormInputControlRutinSecurityAdd-FormInputControlRutinSecurity-add-2")]
    public async Task<IActionResult> FormInputControlRutinSecurityAdd()
    {
        // Create page object
        formInputControlRutinSecurityAdd = new GLOBALS.FormInputControlRutinSecurityAdd(this);

        // Run the page
        return await formInputControlRutinSecurityAdd.Run();
    }

    // view
    [Route("FormInputControlRutinSecurityView/{Id?}", Name = "FormInputControlRutinSecurityView-FormInputControlRutinSecurity-view")]
    [Route("Home/FormInputControlRutinSecurityView/{Id?}", Name = "FormInputControlRutinSecurityView-FormInputControlRutinSecurity-view-2")]
    public async Task<IActionResult> FormInputControlRutinSecurityView()
    {
        // Create page object
        formInputControlRutinSecurityView = new GLOBALS.FormInputControlRutinSecurityView(this);

        // Run the page
        return await formInputControlRutinSecurityView.Run();
    }

    // edit
    [Route("FormInputControlRutinSecurityEdit/{Id?}", Name = "FormInputControlRutinSecurityEdit-FormInputControlRutinSecurity-edit")]
    [Route("Home/FormInputControlRutinSecurityEdit/{Id?}", Name = "FormInputControlRutinSecurityEdit-FormInputControlRutinSecurity-edit-2")]
    public async Task<IActionResult> FormInputControlRutinSecurityEdit()
    {
        // Create page object
        formInputControlRutinSecurityEdit = new GLOBALS.FormInputControlRutinSecurityEdit(this);

        // Run the page
        return await formInputControlRutinSecurityEdit.Run();
    }

    // delete
    [Route("FormInputControlRutinSecurityDelete/{Id?}", Name = "FormInputControlRutinSecurityDelete-FormInputControlRutinSecurity-delete")]
    [Route("Home/FormInputControlRutinSecurityDelete/{Id?}", Name = "FormInputControlRutinSecurityDelete-FormInputControlRutinSecurity-delete-2")]
    public async Task<IActionResult> FormInputControlRutinSecurityDelete()
    {
        // Create page object
        formInputControlRutinSecurityDelete = new GLOBALS.FormInputControlRutinSecurityDelete(this);

        // Run the page
        return await formInputControlRutinSecurityDelete.Run();
    }
}
