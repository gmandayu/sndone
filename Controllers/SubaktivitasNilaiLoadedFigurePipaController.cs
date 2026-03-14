namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasNilaiLoadedFigurePipaList/{id?}", Name = "SubaktivitasNilaiLoadedFigurePipaList-SubaktivitasNilaiLoadedFigurePipa-list")]
    [Route("Home/SubaktivitasNilaiLoadedFigurePipaList/{id?}", Name = "SubaktivitasNilaiLoadedFigurePipaList-SubaktivitasNilaiLoadedFigurePipa-list-2")]
    public async Task<IActionResult> SubaktivitasNilaiLoadedFigurePipaList()
    {
        // Create page object
        subaktivitasNilaiLoadedFigurePipaList = new GLOBALS.SubaktivitasNilaiLoadedFigurePipaList(this);
        subaktivitasNilaiLoadedFigurePipaList.Cache = _cache;

        // Run the page
        return await subaktivitasNilaiLoadedFigurePipaList.Run();
    }

    // edit
    [Route("SubaktivitasNilaiLoadedFigurePipaEdit/{id?}", Name = "SubaktivitasNilaiLoadedFigurePipaEdit-SubaktivitasNilaiLoadedFigurePipa-edit")]
    [Route("Home/SubaktivitasNilaiLoadedFigurePipaEdit/{id?}", Name = "SubaktivitasNilaiLoadedFigurePipaEdit-SubaktivitasNilaiLoadedFigurePipa-edit-2")]
    public async Task<IActionResult> SubaktivitasNilaiLoadedFigurePipaEdit()
    {
        // Create page object
        subaktivitasNilaiLoadedFigurePipaEdit = new GLOBALS.SubaktivitasNilaiLoadedFigurePipaEdit(this);

        // Run the page
        return await subaktivitasNilaiLoadedFigurePipaEdit.Run();
    }
}
