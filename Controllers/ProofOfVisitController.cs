namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("ProofOfVisitList/{IdProofOfVisit?}", Name = "ProofOfVisitList-ProofOfVisit-list")]
    [Route("Home/ProofOfVisitList/{IdProofOfVisit?}", Name = "ProofOfVisitList-ProofOfVisit-list-2")]
    public async Task<IActionResult> ProofOfVisitList()
    {
        // Create page object
        proofOfVisitList = new GLOBALS.ProofOfVisitList(this);
        proofOfVisitList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdProofOfVisit"];

        // Run the page
        return await proofOfVisitList.Run();
    }

    // add
    [Route("ProofOfVisitAdd/{IdProofOfVisit?}", Name = "ProofOfVisitAdd-ProofOfVisit-add")]
    [Route("Home/ProofOfVisitAdd/{IdProofOfVisit?}", Name = "ProofOfVisitAdd-ProofOfVisit-add-2")]
    public async Task<IActionResult> ProofOfVisitAdd()
    {
        // Create page object
        proofOfVisitAdd = new GLOBALS.ProofOfVisitAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdProofOfVisit"];

        // Run the page
        return await proofOfVisitAdd.Run();
    }

    // view
    [Route("ProofOfVisitView/{IdProofOfVisit?}", Name = "ProofOfVisitView-ProofOfVisit-view")]
    [Route("Home/ProofOfVisitView/{IdProofOfVisit?}", Name = "ProofOfVisitView-ProofOfVisit-view-2")]
    public async Task<IActionResult> ProofOfVisitView()
    {
        // Create page object
        proofOfVisitView = new GLOBALS.ProofOfVisitView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdProofOfVisit"];

        // Run the page
        return await proofOfVisitView.Run();
    }

    // edit
    [Route("ProofOfVisitEdit/{IdProofOfVisit?}", Name = "ProofOfVisitEdit-ProofOfVisit-edit")]
    [Route("Home/ProofOfVisitEdit/{IdProofOfVisit?}", Name = "ProofOfVisitEdit-ProofOfVisit-edit-2")]
    public async Task<IActionResult> ProofOfVisitEdit()
    {
        // Create page object
        proofOfVisitEdit = new GLOBALS.ProofOfVisitEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdProofOfVisit"];

        // Run the page
        return await proofOfVisitEdit.Run();
    }

    // delete
    [Route("ProofOfVisitDelete/{IdProofOfVisit?}", Name = "ProofOfVisitDelete-ProofOfVisit-delete")]
    [Route("Home/ProofOfVisitDelete/{IdProofOfVisit?}", Name = "ProofOfVisitDelete-ProofOfVisit-delete-2")]
    public async Task<IActionResult> ProofOfVisitDelete()
    {
        // Create page object
        proofOfVisitDelete = new GLOBALS.ProofOfVisitDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdProofOfVisit"];

        // Run the page
        return await proofOfVisitDelete.Run();
    }
}
