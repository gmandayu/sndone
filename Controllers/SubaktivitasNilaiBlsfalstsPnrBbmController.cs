namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiBlsfalstsPnrBbmList/{id?}", Name = "SubaktivitasNilaiBlsfalstsPnrBbmList-SubaktivitasNilaiBLSFALSTSPnrBBM-list")]
    [Route("Home/SubaktivitasNilaiBlsfalstsPnrBbmList/{id?}", Name = "SubaktivitasNilaiBlsfalstsPnrBbmList-SubaktivitasNilaiBLSFALSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiBlsfalstsPnrBbmList()
    {
        // Create page object
        subaktivitasNilaiBlsfalstsPnrBbmList = new GLOBALS.SubaktivitasNilaiBlsfalstsPnrBbmList(this);
        subaktivitasNilaiBlsfalstsPnrBbmList.Cache = _cache;

        // Run the page
        return await subaktivitasNilaiBlsfalstsPnrBbmList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiBlsfalstsPnrBbmEdit/{id?}", Name = "SubaktivitasNilaiBlsfalstsPnrBbmEdit-SubaktivitasNilaiBLSFALSTSPnrBBM-edit")]
    [Route("Home/SubaktivitasNilaiBlsfalstsPnrBbmEdit/{id?}", Name = "SubaktivitasNilaiBlsfalstsPnrBbmEdit-SubaktivitasNilaiBLSFALSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiBlsfalstsPnrBbmEdit()
    {
        // Create page object
        subaktivitasNilaiBlsfalstsPnrBbmEdit = new GLOBALS.SubaktivitasNilaiBlsfalstsPnrBbmEdit(this);

        // Run the page
        return await subaktivitasNilaiBlsfalstsPnrBbmEdit.Run();
    }
}
