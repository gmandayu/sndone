namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasInputHasilPemeriksaanPipaList/{id?}", Name = "SubaktivitasInputHasilPemeriksaanPipaList-SubaktivitasInputHasilPemeriksaanPipa-list")]
    [Route("Home/SubaktivitasInputHasilPemeriksaanPipaList/{id?}", Name = "SubaktivitasInputHasilPemeriksaanPipaList-SubaktivitasInputHasilPemeriksaanPipa-list-2")]
    public async Task<IActionResult> SubaktivitasInputHasilPemeriksaanPipaList()
    {
        // Create page object
        subaktivitasInputHasilPemeriksaanPipaList = new GLOBALS.SubaktivitasInputHasilPemeriksaanPipaList(this);
        subaktivitasInputHasilPemeriksaanPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasInputHasilPemeriksaanPipaList.Run();
    }

    // edit
    [Route("SubaktivitasInputHasilPemeriksaanPipaEdit/{id?}", Name = "SubaktivitasInputHasilPemeriksaanPipaEdit-SubaktivitasInputHasilPemeriksaanPipa-edit")]
    [Route("Home/SubaktivitasInputHasilPemeriksaanPipaEdit/{id?}", Name = "SubaktivitasInputHasilPemeriksaanPipaEdit-SubaktivitasInputHasilPemeriksaanPipa-edit-2")]
    public async Task<IActionResult> SubaktivitasInputHasilPemeriksaanPipaEdit()
    {
        // Create page object
        subaktivitasInputHasilPemeriksaanPipaEdit = new GLOBALS.SubaktivitasInputHasilPemeriksaanPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subaktivitasInputHasilPemeriksaanPipaEdit.Run();
    }
}
