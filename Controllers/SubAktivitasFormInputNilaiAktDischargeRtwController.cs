namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputNilaiAktDischargeRtwList/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwList-SubAktivitasFormInputNilaiAktDischargeRTW-list")]
    [Route("Home/SubAktivitasFormInputNilaiAktDischargeRtwList/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwList-SubAktivitasFormInputNilaiAktDischargeRTW-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktDischargeRtwList()
    {
        // Create page object
        subAktivitasFormInputNilaiAktDischargeRtwList = new GLOBALS.SubAktivitasFormInputNilaiAktDischargeRtwList(this);
        subAktivitasFormInputNilaiAktDischargeRtwList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiAktDischargeRtwList.Run();
    }

    // add
    [Route("SubAktivitasFormInputNilaiAktDischargeRtwAdd/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwAdd-SubAktivitasFormInputNilaiAktDischargeRTW-add")]
    [Route("Home/SubAktivitasFormInputNilaiAktDischargeRtwAdd/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwAdd-SubAktivitasFormInputNilaiAktDischargeRTW-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktDischargeRtwAdd()
    {
        // Create page object
        subAktivitasFormInputNilaiAktDischargeRtwAdd = new GLOBALS.SubAktivitasFormInputNilaiAktDischargeRtwAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiAktDischargeRtwAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputNilaiAktDischargeRtwView/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwView-SubAktivitasFormInputNilaiAktDischargeRTW-view")]
    [Route("Home/SubAktivitasFormInputNilaiAktDischargeRtwView/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwView-SubAktivitasFormInputNilaiAktDischargeRTW-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktDischargeRtwView()
    {
        // Create page object
        subAktivitasFormInputNilaiAktDischargeRtwView = new GLOBALS.SubAktivitasFormInputNilaiAktDischargeRtwView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiAktDischargeRtwView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputNilaiAktDischargeRtwEdit/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwEdit-SubAktivitasFormInputNilaiAktDischargeRTW-edit")]
    [Route("Home/SubAktivitasFormInputNilaiAktDischargeRtwEdit/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwEdit-SubAktivitasFormInputNilaiAktDischargeRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktDischargeRtwEdit()
    {
        // Create page object
        subAktivitasFormInputNilaiAktDischargeRtwEdit = new GLOBALS.SubAktivitasFormInputNilaiAktDischargeRtwEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiAktDischargeRtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputNilaiAktDischargeRtwDelete/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwDelete-SubAktivitasFormInputNilaiAktDischargeRTW-delete")]
    [Route("Home/SubAktivitasFormInputNilaiAktDischargeRtwDelete/{id?}", Name = "SubAktivitasFormInputNilaiAktDischargeRtwDelete-SubAktivitasFormInputNilaiAktDischargeRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktDischargeRtwDelete()
    {
        // Create page object
        subAktivitasFormInputNilaiAktDischargeRtwDelete = new GLOBALS.SubAktivitasFormInputNilaiAktDischargeRtwDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiAktDischargeRtwDelete.Run();
    }
}
