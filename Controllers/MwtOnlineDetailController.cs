namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MwtOnlineDetailList/{Id?}", Name = "MwtOnlineDetailList-MWTOnlineDetail-list")]
    [Route("Home/MwtOnlineDetailList/{Id?}", Name = "MwtOnlineDetailList-MWTOnlineDetail-list-2")]
    public async Task<IActionResult> MwtOnlineDetailList()
    {
        // Create page object
        mwtOnlineDetailList = new GLOBALS.MwtOnlineDetailList(this);
        mwtOnlineDetailList.Cache = _cache;

        // Run the page
        return await mwtOnlineDetailList.Run();
    }

    // edit
    [Route("MwtOnlineDetailEdit/{Id?}", Name = "MwtOnlineDetailEdit-MWTOnlineDetail-edit")]
    [Route("Home/MwtOnlineDetailEdit/{Id?}", Name = "MwtOnlineDetailEdit-MWTOnlineDetail-edit-2")]
    public async Task<IActionResult> MwtOnlineDetailEdit()
    {
        // Create page object
        mwtOnlineDetailEdit = new GLOBALS.MwtOnlineDetailEdit(this);

        // Run the page
        return await mwtOnlineDetailEdit.Run();
    }
}
