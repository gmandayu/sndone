namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasHasilPemeriksaanLpgList/{id?}", Name = "SubaktivitasHasilPemeriksaanLpgList-SubaktivitasHasilPemeriksaanLPG-list")]
    [Route("Home/SubaktivitasHasilPemeriksaanLpgList/{id?}", Name = "SubaktivitasHasilPemeriksaanLpgList-SubaktivitasHasilPemeriksaanLPG-list-2")]
    public async Task<IActionResult> SubaktivitasHasilPemeriksaanLpgList()
    {
        // Create page object
        subaktivitasHasilPemeriksaanLpgList = new GLOBALS.SubaktivitasHasilPemeriksaanLpgList(this);
        subaktivitasHasilPemeriksaanLpgList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasHasilPemeriksaanLpgList.Run();
    }

    // edit
    [Route("SubaktivitasHasilPemeriksaanLpgEdit/{id?}", Name = "SubaktivitasHasilPemeriksaanLpgEdit-SubaktivitasHasilPemeriksaanLPG-edit")]
    [Route("Home/SubaktivitasHasilPemeriksaanLpgEdit/{id?}", Name = "SubaktivitasHasilPemeriksaanLpgEdit-SubaktivitasHasilPemeriksaanLPG-edit-2")]
    public async Task<IActionResult> SubaktivitasHasilPemeriksaanLpgEdit()
    {
        // Create page object
        subaktivitasHasilPemeriksaanLpgEdit = new GLOBALS.SubaktivitasHasilPemeriksaanLpgEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasHasilPemeriksaanLpgEdit.Run();
    }
}
