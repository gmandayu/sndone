namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VFaceEnrollmentList/{IdUser?}", Name = "VFaceEnrollmentList-VFaceEnrollment-list")]
    [Route("Home/VFaceEnrollmentList/{IdUser?}", Name = "VFaceEnrollmentList-VFaceEnrollment-list-2")]
    public async Task<IActionResult> VFaceEnrollmentList()
    {
        // Create page object
        vFaceEnrollmentList = new GLOBALS.VFaceEnrollmentList(this);
        vFaceEnrollmentList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdUser"];

        // Run the page
        return await vFaceEnrollmentList.Run();
    }

    // edit
    [Route("VFaceEnrollmentEdit/{IdUser?}", Name = "VFaceEnrollmentEdit-VFaceEnrollment-edit")]
    [Route("Home/VFaceEnrollmentEdit/{IdUser?}", Name = "VFaceEnrollmentEdit-VFaceEnrollment-edit-2")]
    public async Task<IActionResult> VFaceEnrollmentEdit()
    {
        // Create page object
        vFaceEnrollmentEdit = new GLOBALS.VFaceEnrollmentEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdUser"];

        // Run the page
        return await vFaceEnrollmentEdit.Run();
    }

    // search
    [Route("VFaceEnrollmentSearch", Name = "VFaceEnrollmentSearch-VFaceEnrollment-search")]
    [Route("Home/VFaceEnrollmentSearch", Name = "VFaceEnrollmentSearch-VFaceEnrollment-search-2")]
    public async Task<IActionResult> VFaceEnrollmentSearch()
    {
        // Create page object
        vFaceEnrollmentSearch = new GLOBALS.VFaceEnrollmentSearch(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["IdUser"];

        // Run the page
        return await vFaceEnrollmentSearch.Run();
    }
}
