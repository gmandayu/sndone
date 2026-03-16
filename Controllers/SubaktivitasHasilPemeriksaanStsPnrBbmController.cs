namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasHasilPemeriksaanStsPnrBbmList/{id?}", Name = "SubaktivitasHasilPemeriksaanStsPnrBbmList-SubaktivitasHasilPemeriksaanSTSPnrBBM-list")]
    [Route("Home/SubaktivitasHasilPemeriksaanStsPnrBbmList/{id?}", Name = "SubaktivitasHasilPemeriksaanStsPnrBbmList-SubaktivitasHasilPemeriksaanSTSPnrBBM-list-2")]
    public async Task<IActionResult> SubaktivitasHasilPemeriksaanStsPnrBbmList()
    {
        // Create page object
        subaktivitasHasilPemeriksaanStsPnrBbmList = new GLOBALS.SubaktivitasHasilPemeriksaanStsPnrBbmList(this);
        subaktivitasHasilPemeriksaanStsPnrBbmList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasHasilPemeriksaanStsPnrBbmList.Run();
    }

    // edit
    [Route("SubaktivitasHasilPemeriksaanStsPnrBbmEdit/{id?}", Name = "SubaktivitasHasilPemeriksaanStsPnrBbmEdit-SubaktivitasHasilPemeriksaanSTSPnrBBM-edit")]
    [Route("Home/SubaktivitasHasilPemeriksaanStsPnrBbmEdit/{id?}", Name = "SubaktivitasHasilPemeriksaanStsPnrBbmEdit-SubaktivitasHasilPemeriksaanSTSPnrBBM-edit-2")]
    public async Task<IActionResult> SubaktivitasHasilPemeriksaanStsPnrBbmEdit()
    {
        // Create page object
        subaktivitasHasilPemeriksaanStsPnrBbmEdit = new GLOBALS.SubaktivitasHasilPemeriksaanStsPnrBbmEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasHasilPemeriksaanStsPnrBbmEdit.Run();
    }
}
