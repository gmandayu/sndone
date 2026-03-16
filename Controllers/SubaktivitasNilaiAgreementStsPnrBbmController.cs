namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiAgreementStsPnrBbmList/{id?}", Name = "SubaktivitasNilaiAgreementStsPnrBbmList-SubaktivitasNilaiAgreementSTSPnrBBM-list")]
    [Route("Home/SubaktivitasNilaiAgreementStsPnrBbmList/{id?}", Name = "SubaktivitasNilaiAgreementStsPnrBbmList-SubaktivitasNilaiAgreementSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiAgreementStsPnrBbmList()
    {
        // Create page object
        subaktivitasNilaiAgreementStsPnrBbmList = new GLOBALS.SubaktivitasNilaiAgreementStsPnrBbmList(this);
        subaktivitasNilaiAgreementStsPnrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasNilaiAgreementStsPnrBbmList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiAgreementStsPnrBbmEdit/{id?}", Name = "SubaktivitasNilaiAgreementStsPnrBbmEdit-SubaktivitasNilaiAgreementSTSPnrBBM-edit")]
    [Route("Home/SubaktivitasNilaiAgreementStsPnrBbmEdit/{id?}", Name = "SubaktivitasNilaiAgreementStsPnrBbmEdit-SubaktivitasNilaiAgreementSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiAgreementStsPnrBbmEdit()
    {
        // Create page object
        subaktivitasNilaiAgreementStsPnrBbmEdit = new GLOBALS.SubaktivitasNilaiAgreementStsPnrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasNilaiAgreementStsPnrBbmEdit.Run();
    }
}
