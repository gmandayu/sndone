namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList-SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymLPG-list")]
    [Route("Home/SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList-SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymLPG-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList()
    {
        // Create page object
        subAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList = new GLOBALS.SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList(this);
        subAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgEdit/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgEdit-SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymLPG-edit")]
    [Route("Home/SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgEdit/{id?}", Name = "SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgEdit-SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgEdit()
    {
        // Create page object
        subAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgEdit = new GLOBALS.SubAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgEdit(this);

        // Run the page
        return await subAktivitasFormInputNilaiBLsesuaiCqlstsPymLpgEdit.Run();
    }
}
