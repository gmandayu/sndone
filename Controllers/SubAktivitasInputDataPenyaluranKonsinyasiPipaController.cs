namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputDataPenyaluranKonsinyasiPipaList/{id?}", Name = "SubAktivitasInputDataPenyaluranKonsinyasiPipaList-SubAktivitasInputDataPenyaluranKonsinyasiPipa-list")]
    [Route("Home/SubAktivitasInputDataPenyaluranKonsinyasiPipaList/{id?}", Name = "SubAktivitasInputDataPenyaluranKonsinyasiPipaList-SubAktivitasInputDataPenyaluranKonsinyasiPipa-list-2")]
    public async Task<IActionResult> SubAktivitasInputDataPenyaluranKonsinyasiPipaList()
    {
        // Create page object
        subAktivitasInputDataPenyaluranKonsinyasiPipaList = new GLOBALS.SubAktivitasInputDataPenyaluranKonsinyasiPipaList(this);
        subAktivitasInputDataPenyaluranKonsinyasiPipaList.Cache = _cache;

        // Run the page
        return await subAktivitasInputDataPenyaluranKonsinyasiPipaList.Run();
    }

    // edit
    [Route("SubAktivitasInputDataPenyaluranKonsinyasiPipaEdit/{id?}", Name = "SubAktivitasInputDataPenyaluranKonsinyasiPipaEdit-SubAktivitasInputDataPenyaluranKonsinyasiPipa-edit")]
    [Route("Home/SubAktivitasInputDataPenyaluranKonsinyasiPipaEdit/{id?}", Name = "SubAktivitasInputDataPenyaluranKonsinyasiPipaEdit-SubAktivitasInputDataPenyaluranKonsinyasiPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasInputDataPenyaluranKonsinyasiPipaEdit()
    {
        // Create page object
        subAktivitasInputDataPenyaluranKonsinyasiPipaEdit = new GLOBALS.SubAktivitasInputDataPenyaluranKonsinyasiPipaEdit(this);

        // Run the page
        return await subAktivitasInputDataPenyaluranKonsinyasiPipaEdit.Run();
    }
}
