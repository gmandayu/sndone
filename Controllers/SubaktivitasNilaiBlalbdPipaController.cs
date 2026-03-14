namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiBlalbdPipaList/{id?}", Name = "SubaktivitasNilaiBlalbdPipaList-SubaktivitasNilaiBLALBDPipa-list")]
    [Route("Home/SubaktivitasNilaiBlalbdPipaList/{id?}", Name = "SubaktivitasNilaiBlalbdPipaList-SubaktivitasNilaiBLALBDPipa-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiBlalbdPipaList()
    {
        // Create page object
        subaktivitasNilaiBlalbdPipaList = new GLOBALS.SubaktivitasNilaiBlalbdPipaList(this);
        subaktivitasNilaiBlalbdPipaList.Cache = _cache;

        // Run the page
        return await subaktivitasNilaiBlalbdPipaList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiBlalbdPipaEdit/{id?}", Name = "SubaktivitasNilaiBlalbdPipaEdit-SubaktivitasNilaiBLALBDPipa-edit")]
    [Route("Home/SubaktivitasNilaiBlalbdPipaEdit/{id?}", Name = "SubaktivitasNilaiBlalbdPipaEdit-SubaktivitasNilaiBLALBDPipa-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiBlalbdPipaEdit()
    {
        // Create page object
        subaktivitasNilaiBlalbdPipaEdit = new GLOBALS.SubaktivitasNilaiBlalbdPipaEdit(this);

        // Run the page
        return await subaktivitasNilaiBlalbdPipaEdit.Run();
    }
}
