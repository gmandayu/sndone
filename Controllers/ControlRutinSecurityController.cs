namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("ControlRutinSecurityList/{IdCRS?}", Name = "ControlRutinSecurityList-ControlRutinSecurity-list")]
    [Route("Home/ControlRutinSecurityList/{IdCRS?}", Name = "ControlRutinSecurityList-ControlRutinSecurity-list-2")]
    public async Task<IActionResult> ControlRutinSecurityList()
    {
        // Create page object
        controlRutinSecurityList = new GLOBALS.ControlRutinSecurityList(this);
        controlRutinSecurityList.Cache = _cache;

        // Run the page
        return await controlRutinSecurityList.Run();
    }

    // add
    [Route("ControlRutinSecurityAdd/{IdCRS?}", Name = "ControlRutinSecurityAdd-ControlRutinSecurity-add")]
    [Route("Home/ControlRutinSecurityAdd/{IdCRS?}", Name = "ControlRutinSecurityAdd-ControlRutinSecurity-add-2")]
    public async Task<IActionResult> ControlRutinSecurityAdd()
    {
        // Create page object
        controlRutinSecurityAdd = new GLOBALS.ControlRutinSecurityAdd(this);

        // Run the page
        return await controlRutinSecurityAdd.Run();
    }

    // view
    [Route("ControlRutinSecurityView/{IdCRS?}", Name = "ControlRutinSecurityView-ControlRutinSecurity-view")]
    [Route("Home/ControlRutinSecurityView/{IdCRS?}", Name = "ControlRutinSecurityView-ControlRutinSecurity-view-2")]
    public async Task<IActionResult> ControlRutinSecurityView()
    {
        // Create page object
        controlRutinSecurityView = new GLOBALS.ControlRutinSecurityView(this);

        // Run the page
        return await controlRutinSecurityView.Run();
    }

    // edit
    [Route("ControlRutinSecurityEdit/{IdCRS?}", Name = "ControlRutinSecurityEdit-ControlRutinSecurity-edit")]
    [Route("Home/ControlRutinSecurityEdit/{IdCRS?}", Name = "ControlRutinSecurityEdit-ControlRutinSecurity-edit-2")]
    public async Task<IActionResult> ControlRutinSecurityEdit()
    {
        // Create page object
        controlRutinSecurityEdit = new GLOBALS.ControlRutinSecurityEdit(this);

        // Run the page
        return await controlRutinSecurityEdit.Run();
    }

    // delete
    [Route("ControlRutinSecurityDelete/{IdCRS?}", Name = "ControlRutinSecurityDelete-ControlRutinSecurity-delete")]
    [Route("Home/ControlRutinSecurityDelete/{IdCRS?}", Name = "ControlRutinSecurityDelete-ControlRutinSecurity-delete-2")]
    public async Task<IActionResult> ControlRutinSecurityDelete()
    {
        // Create page object
        controlRutinSecurityDelete = new GLOBALS.ControlRutinSecurityDelete(this);

        // Run the page
        return await controlRutinSecurityDelete.Run();
    }
}
