namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SamplingLabTestList/{IdSamplingLabTest?}", Name = "SamplingLabTestList-SamplingLabTest-list")]
    [Route("Home/SamplingLabTestList/{IdSamplingLabTest?}", Name = "SamplingLabTestList-SamplingLabTest-list-2")]
    public async Task<IActionResult> SamplingLabTestList()
    {
        // Create page object
        samplingLabTestList = new GLOBALS.SamplingLabTestList(this);
        samplingLabTestList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdSamplingLabTest"];

        // Run the page
        return await samplingLabTestList.Run();
    }

    // add
    [Route("SamplingLabTestAdd/{IdSamplingLabTest?}", Name = "SamplingLabTestAdd-SamplingLabTest-add")]
    [Route("Home/SamplingLabTestAdd/{IdSamplingLabTest?}", Name = "SamplingLabTestAdd-SamplingLabTest-add-2")]
    public async Task<IActionResult> SamplingLabTestAdd()
    {
        // Create page object
        samplingLabTestAdd = new GLOBALS.SamplingLabTestAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdSamplingLabTest"];

        // Run the page
        return await samplingLabTestAdd.Run();
    }

    // view
    [Route("SamplingLabTestView/{IdSamplingLabTest?}", Name = "SamplingLabTestView-SamplingLabTest-view")]
    [Route("Home/SamplingLabTestView/{IdSamplingLabTest?}", Name = "SamplingLabTestView-SamplingLabTest-view-2")]
    public async Task<IActionResult> SamplingLabTestView()
    {
        // Create page object
        samplingLabTestView = new GLOBALS.SamplingLabTestView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdSamplingLabTest"];

        // Run the page
        return await samplingLabTestView.Run();
    }

    // edit
    [Route("SamplingLabTestEdit/{IdSamplingLabTest?}", Name = "SamplingLabTestEdit-SamplingLabTest-edit")]
    [Route("Home/SamplingLabTestEdit/{IdSamplingLabTest?}", Name = "SamplingLabTestEdit-SamplingLabTest-edit-2")]
    public async Task<IActionResult> SamplingLabTestEdit()
    {
        // Create page object
        samplingLabTestEdit = new GLOBALS.SamplingLabTestEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdSamplingLabTest"];

        // Run the page
        return await samplingLabTestEdit.Run();
    }

    // delete
    [Route("SamplingLabTestDelete/{IdSamplingLabTest?}", Name = "SamplingLabTestDelete-SamplingLabTest-delete")]
    [Route("Home/SamplingLabTestDelete/{IdSamplingLabTest?}", Name = "SamplingLabTestDelete-SamplingLabTest-delete-2")]
    public async Task<IActionResult> SamplingLabTestDelete()
    {
        // Create page object
        samplingLabTestDelete = new GLOBALS.SamplingLabTestDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdSamplingLabTest"];

        // Run the page
        return await samplingLabTestDelete.Run();
    }

    // search
    [Route("SamplingLabTestSearch", Name = "SamplingLabTestSearch-SamplingLabTest-search")]
    [Route("Home/SamplingLabTestSearch", Name = "SamplingLabTestSearch-SamplingLabTest-search-2")]
    public async Task<IActionResult> SamplingLabTestSearch()
    {
        // Create page object
        samplingLabTestSearch = new GLOBALS.SamplingLabTestSearch(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdSamplingLabTest"];

        // Run the page
        return await samplingLabTestSearch.Run();
    }
}
