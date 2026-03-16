namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MappingPositionList", Name = "MappingPositionList-MappingPosition-list")]
    [Route("Home/MappingPositionList", Name = "MappingPositionList-MappingPosition-list-2")]
    public async Task<IActionResult> MappingPositionList()
    {
        // Create page object
        mappingPositionList = new GLOBALS.MappingPositionList(this);
        mappingPositionList.Cache = _cache;

        // Run the page

        // Run the page
        return await mappingPositionList.Run();
    }

    // add
    [Route("MappingPositionAdd", Name = "MappingPositionAdd-MappingPosition-add")]
    [Route("Home/MappingPositionAdd", Name = "MappingPositionAdd-MappingPosition-add-2")]
    public async Task<IActionResult> MappingPositionAdd()
    {
        // Create page object
        mappingPositionAdd = new GLOBALS.MappingPositionAdd(this);

        // Run the page

        // Run the page
        return await mappingPositionAdd.Run();
    }
}
