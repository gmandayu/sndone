namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputNilaiARsesuaiCqdTruckList/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckList-SubAktivitasFormInputNilaiARsesuaiCQDTruck-list")]
    [Route("Home/SubAktivitasFormInputNilaiARsesuaiCqdTruckList/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckList-SubAktivitasFormInputNilaiARsesuaiCQDTruck-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiARsesuaiCqdTruckList()
    {
        // Create page object
        subAktivitasFormInputNilaiARsesuaiCqdTruckList = new GLOBALS.SubAktivitasFormInputNilaiARsesuaiCqdTruckList(this);
        subAktivitasFormInputNilaiARsesuaiCqdTruckList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiARsesuaiCqdTruckList.Run();
    }

    // add
    [Route("SubAktivitasFormInputNilaiARsesuaiCqdTruckAdd/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckAdd-SubAktivitasFormInputNilaiARsesuaiCQDTruck-add")]
    [Route("Home/SubAktivitasFormInputNilaiARsesuaiCqdTruckAdd/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckAdd-SubAktivitasFormInputNilaiARsesuaiCQDTruck-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiARsesuaiCqdTruckAdd()
    {
        // Create page object
        subAktivitasFormInputNilaiARsesuaiCqdTruckAdd = new GLOBALS.SubAktivitasFormInputNilaiARsesuaiCqdTruckAdd(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiARsesuaiCqdTruckAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputNilaiARsesuaiCqdTruckView/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckView-SubAktivitasFormInputNilaiARsesuaiCQDTruck-view")]
    [Route("Home/SubAktivitasFormInputNilaiARsesuaiCqdTruckView/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckView-SubAktivitasFormInputNilaiARsesuaiCQDTruck-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiARsesuaiCqdTruckView()
    {
        // Create page object
        subAktivitasFormInputNilaiARsesuaiCqdTruckView = new GLOBALS.SubAktivitasFormInputNilaiARsesuaiCqdTruckView(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiARsesuaiCqdTruckView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputNilaiARsesuaiCqdTruckEdit/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckEdit-SubAktivitasFormInputNilaiARsesuaiCQDTruck-edit")]
    [Route("Home/SubAktivitasFormInputNilaiARsesuaiCqdTruckEdit/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckEdit-SubAktivitasFormInputNilaiARsesuaiCQDTruck-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiARsesuaiCqdTruckEdit()
    {
        // Create page object
        subAktivitasFormInputNilaiARsesuaiCqdTruckEdit = new GLOBALS.SubAktivitasFormInputNilaiARsesuaiCqdTruckEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiARsesuaiCqdTruckEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputNilaiARsesuaiCqdTruckDelete/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckDelete-SubAktivitasFormInputNilaiARsesuaiCQDTruck-delete")]
    [Route("Home/SubAktivitasFormInputNilaiARsesuaiCqdTruckDelete/{id?}", Name = "SubAktivitasFormInputNilaiARsesuaiCqdTruckDelete-SubAktivitasFormInputNilaiARsesuaiCQDTruck-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiARsesuaiCqdTruckDelete()
    {
        // Create page object
        subAktivitasFormInputNilaiARsesuaiCqdTruckDelete = new GLOBALS.SubAktivitasFormInputNilaiARsesuaiCqdTruckDelete(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiARsesuaiCqdTruckDelete.Run();
    }
}
