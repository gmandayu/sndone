namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiBlsfalList/{id?}", Name = "SubaktivitasNilaiBlsfalList-SubaktivitasNilaiBLSFAL-list")]
    [Route("Home/SubaktivitasNilaiBlsfalList/{id?}", Name = "SubaktivitasNilaiBlsfalList-SubaktivitasNilaiBLSFAL-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiBlsfalList()
    {
        // Create page object
        subaktivitasNilaiBlsfalList = new GLOBALS.SubaktivitasNilaiBlsfalList(this);
        subaktivitasNilaiBlsfalList.Cache = _cache;

        // Run the page
        return await subaktivitasNilaiBlsfalList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiBlsfalEdit/{id?}", Name = "SubaktivitasNilaiBlsfalEdit-SubaktivitasNilaiBLSFAL-edit")]
    [Route("Home/SubaktivitasNilaiBlsfalEdit/{id?}", Name = "SubaktivitasNilaiBlsfalEdit-SubaktivitasNilaiBLSFAL-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiBlsfalEdit()
    {
        // Create page object
        subaktivitasNilaiBlsfalEdit = new GLOBALS.SubaktivitasNilaiBlsfalEdit(this);

        // Run the page
        return await subaktivitasNilaiBlsfalEdit.Run();
    }
}
