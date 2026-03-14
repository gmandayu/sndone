namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VSampleOperasionalList", Name = "VSampleOperasionalList-VSampleOperasional-list")]
    [Route("Home/VSampleOperasionalList", Name = "VSampleOperasionalList-VSampleOperasional-list-2")]
    public async Task<IActionResult> VSampleOperasionalList()
    {
        // Create page object
        vSampleOperasionalList = new GLOBALS.VSampleOperasionalList(this);
        vSampleOperasionalList.Cache = _cache;

        // Run the page
        return await vSampleOperasionalList.Run();
    }
}
