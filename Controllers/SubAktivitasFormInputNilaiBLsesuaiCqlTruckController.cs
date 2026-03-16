namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputNilaiBLsesuaiCqlTruckList/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlTruckList-SubAktivitasFormInputNilaiBLsesuaiCQLTruck-list")]
    [Route("Home/SubAktivitasFormInputNilaiBLsesuaiCqlTruckList/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlTruckList-SubAktivitasFormInputNilaiBLsesuaiCQLTruck-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLsesuaiCqlTruckList()
    {
        // Create page object
        subAktivitasFormInputNilaiBLsesuaiCqlTruckList = new GLOBALS.SubAktivitasFormInputNilaiBLsesuaiCqlTruckList(this);
        subAktivitasFormInputNilaiBLsesuaiCqlTruckList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiBLsesuaiCqlTruckList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputNilaiBLsesuaiCqlTruckEdit/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlTruckEdit-SubAktivitasFormInputNilaiBLsesuaiCQLTruck-edit")]
    [Route("Home/SubAktivitasFormInputNilaiBLsesuaiCqlTruckEdit/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlTruckEdit-SubAktivitasFormInputNilaiBLsesuaiCQLTruck-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLsesuaiCqlTruckEdit()
    {
        // Create page object
        subAktivitasFormInputNilaiBLsesuaiCqlTruckEdit = new GLOBALS.SubAktivitasFormInputNilaiBLsesuaiCqlTruckEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiBLsesuaiCqlTruckEdit.Run();
    }
}
