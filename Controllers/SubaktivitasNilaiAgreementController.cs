namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiAgreementList/{id?}", Name = "SubaktivitasNilaiAgreementList-SubaktivitasNilaiAgreement-list")]
    [Route("Home/SubaktivitasNilaiAgreementList/{id?}", Name = "SubaktivitasNilaiAgreementList-SubaktivitasNilaiAgreement-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiAgreementList()
    {
        // Create page object
        subaktivitasNilaiAgreementList = new GLOBALS.SubaktivitasNilaiAgreementList(this);
        subaktivitasNilaiAgreementList.Cache = _cache;

        // Run the page
        return await subaktivitasNilaiAgreementList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiAgreementEdit/{id?}", Name = "SubaktivitasNilaiAgreementEdit-SubaktivitasNilaiAgreement-edit")]
    [Route("Home/SubaktivitasNilaiAgreementEdit/{id?}", Name = "SubaktivitasNilaiAgreementEdit-SubaktivitasNilaiAgreement-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiAgreementEdit()
    {
        // Create page object
        subaktivitasNilaiAgreementEdit = new GLOBALS.SubaktivitasNilaiAgreementEdit(this);

        // Run the page
        return await subaktivitasNilaiAgreementEdit.Run();
    }
}
