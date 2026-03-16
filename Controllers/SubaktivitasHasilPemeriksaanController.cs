namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasHasilPemeriksaanList/{id?}", Name = "SubaktivitasHasilPemeriksaanList-SubaktivitasHasilPemeriksaan-list")]
    [Route("Home/SubaktivitasHasilPemeriksaanList/{id?}", Name = "SubaktivitasHasilPemeriksaanList-SubaktivitasHasilPemeriksaan-list-2")]
    public async Task<IActionResult> SubaktivitasHasilPemeriksaanList()
    {
        // Create page object
        subaktivitasHasilPemeriksaanList = new GLOBALS.SubaktivitasHasilPemeriksaanList(this);
        subaktivitasHasilPemeriksaanList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasHasilPemeriksaanList.Run();
    }

    // edit
    [Route("SubaktivitasHasilPemeriksaanEdit/{id?}", Name = "SubaktivitasHasilPemeriksaanEdit-SubaktivitasHasilPemeriksaan-edit")]
    [Route("Home/SubaktivitasHasilPemeriksaanEdit/{id?}", Name = "SubaktivitasHasilPemeriksaanEdit-SubaktivitasHasilPemeriksaan-edit-2")]
    public async Task<IActionResult> SubaktivitasHasilPemeriksaanEdit()
    {
        // Create page object
        subaktivitasHasilPemeriksaanEdit = new GLOBALS.SubaktivitasHasilPemeriksaanEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasHasilPemeriksaanEdit.Run();
    }
}
