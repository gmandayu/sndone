namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputDataMobilTangkiList/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiList-SubAktivitasFormInputDataMobilTangki-list")]
    [Route("Home/SubAktivitasFormInputDataMobilTangkiList/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiList-SubAktivitasFormInputDataMobilTangki-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataMobilTangkiList()
    {
        // Create page object
        subAktivitasFormInputDataMobilTangkiList = new GLOBALS.SubAktivitasFormInputDataMobilTangkiList(this);
        subAktivitasFormInputDataMobilTangkiList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataMobilTangkiList.Run();
    }

    // add
    [Route("SubAktivitasFormInputDataMobilTangkiAdd/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiAdd-SubAktivitasFormInputDataMobilTangki-add")]
    [Route("Home/SubAktivitasFormInputDataMobilTangkiAdd/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiAdd-SubAktivitasFormInputDataMobilTangki-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataMobilTangkiAdd()
    {
        // Create page object
        subAktivitasFormInputDataMobilTangkiAdd = new GLOBALS.SubAktivitasFormInputDataMobilTangkiAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataMobilTangkiAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputDataMobilTangkiView/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiView-SubAktivitasFormInputDataMobilTangki-view")]
    [Route("Home/SubAktivitasFormInputDataMobilTangkiView/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiView-SubAktivitasFormInputDataMobilTangki-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataMobilTangkiView()
    {
        // Create page object
        subAktivitasFormInputDataMobilTangkiView = new GLOBALS.SubAktivitasFormInputDataMobilTangkiView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataMobilTangkiView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputDataMobilTangkiEdit/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiEdit-SubAktivitasFormInputDataMobilTangki-edit")]
    [Route("Home/SubAktivitasFormInputDataMobilTangkiEdit/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiEdit-SubAktivitasFormInputDataMobilTangki-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataMobilTangkiEdit()
    {
        // Create page object
        subAktivitasFormInputDataMobilTangkiEdit = new GLOBALS.SubAktivitasFormInputDataMobilTangkiEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataMobilTangkiEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputDataMobilTangkiDelete/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiDelete-SubAktivitasFormInputDataMobilTangki-delete")]
    [Route("Home/SubAktivitasFormInputDataMobilTangkiDelete/{id?}", Name = "SubAktivitasFormInputDataMobilTangkiDelete-SubAktivitasFormInputDataMobilTangki-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputDataMobilTangkiDelete()
    {
        // Create page object
        subAktivitasFormInputDataMobilTangkiDelete = new GLOBALS.SubAktivitasFormInputDataMobilTangkiDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputDataMobilTangkiDelete.Run();
    }
}
