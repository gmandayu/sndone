namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList-SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymBBM-list")]
    [Route("Home/SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList-SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymBBM-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList()
    {
        // Create page object
        subAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList = new GLOBALS.SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList(this);
        subAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmEdit/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmEdit-SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymBBM-edit")]
    [Route("Home/SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmEdit/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmEdit-SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymBBM-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmEdit()
    {
        // Create page object
        subAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmEdit = new GLOBALS.SubAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputNilaiBLsesuaiCqlstsPymBbmEdit.Run();
    }
}
