namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputKeberangkatanMobilTangkiList/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiList-SubAktivitasFormInputKeberangkatanMobilTangki-list")]
    [Route("Home/SubAktivitasFormInputKeberangkatanMobilTangkiList/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiList-SubAktivitasFormInputKeberangkatanMobilTangki-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputKeberangkatanMobilTangkiList()
    {
        // Create page object
        subAktivitasFormInputKeberangkatanMobilTangkiList = new GLOBALS.SubAktivitasFormInputKeberangkatanMobilTangkiList(this);
        subAktivitasFormInputKeberangkatanMobilTangkiList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputKeberangkatanMobilTangkiList.Run();
    }

    // add
    [Route("SubAktivitasFormInputKeberangkatanMobilTangkiAdd/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiAdd-SubAktivitasFormInputKeberangkatanMobilTangki-add")]
    [Route("Home/SubAktivitasFormInputKeberangkatanMobilTangkiAdd/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiAdd-SubAktivitasFormInputKeberangkatanMobilTangki-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputKeberangkatanMobilTangkiAdd()
    {
        // Create page object
        subAktivitasFormInputKeberangkatanMobilTangkiAdd = new GLOBALS.SubAktivitasFormInputKeberangkatanMobilTangkiAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputKeberangkatanMobilTangkiAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputKeberangkatanMobilTangkiView/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiView-SubAktivitasFormInputKeberangkatanMobilTangki-view")]
    [Route("Home/SubAktivitasFormInputKeberangkatanMobilTangkiView/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiView-SubAktivitasFormInputKeberangkatanMobilTangki-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputKeberangkatanMobilTangkiView()
    {
        // Create page object
        subAktivitasFormInputKeberangkatanMobilTangkiView = new GLOBALS.SubAktivitasFormInputKeberangkatanMobilTangkiView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputKeberangkatanMobilTangkiView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputKeberangkatanMobilTangkiEdit/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiEdit-SubAktivitasFormInputKeberangkatanMobilTangki-edit")]
    [Route("Home/SubAktivitasFormInputKeberangkatanMobilTangkiEdit/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiEdit-SubAktivitasFormInputKeberangkatanMobilTangki-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputKeberangkatanMobilTangkiEdit()
    {
        // Create page object
        subAktivitasFormInputKeberangkatanMobilTangkiEdit = new GLOBALS.SubAktivitasFormInputKeberangkatanMobilTangkiEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputKeberangkatanMobilTangkiEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputKeberangkatanMobilTangkiDelete/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiDelete-SubAktivitasFormInputKeberangkatanMobilTangki-delete")]
    [Route("Home/SubAktivitasFormInputKeberangkatanMobilTangkiDelete/{id?}", Name = "SubAktivitasFormInputKeberangkatanMobilTangkiDelete-SubAktivitasFormInputKeberangkatanMobilTangki-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputKeberangkatanMobilTangkiDelete()
    {
        // Create page object
        subAktivitasFormInputKeberangkatanMobilTangkiDelete = new GLOBALS.SubAktivitasFormInputKeberangkatanMobilTangkiDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputKeberangkatanMobilTangkiDelete.Run();
    }
}
