namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputHasilPemeriksaanPipaList/{id?}", Name = "SubAktivitasFormInputHasilPemeriksaanPipaList-SubAktivitasFormInputHasilPemeriksaanPipa-list")]
    [Route("Home/SubAktivitasFormInputHasilPemeriksaanPipaList/{id?}", Name = "SubAktivitasFormInputHasilPemeriksaanPipaList-SubAktivitasFormInputHasilPemeriksaanPipa-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputHasilPemeriksaanPipaList()
    {
        // Create page object
        subAktivitasFormInputHasilPemeriksaanPipaList = new GLOBALS.SubAktivitasFormInputHasilPemeriksaanPipaList(this);
        subAktivitasFormInputHasilPemeriksaanPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputHasilPemeriksaanPipaList.Run();
    }

    // edit
    [Route("SubAktivitasFormInputHasilPemeriksaanPipaEdit/{id?}", Name = "SubAktivitasFormInputHasilPemeriksaanPipaEdit-SubAktivitasFormInputHasilPemeriksaanPipa-edit")]
    [Route("Home/SubAktivitasFormInputHasilPemeriksaanPipaEdit/{id?}", Name = "SubAktivitasFormInputHasilPemeriksaanPipaEdit-SubAktivitasFormInputHasilPemeriksaanPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputHasilPemeriksaanPipaEdit()
    {
        // Create page object
        subAktivitasFormInputHasilPemeriksaanPipaEdit = new GLOBALS.SubAktivitasFormInputHasilPemeriksaanPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasFormInputHasilPemeriksaanPipaEdit.Run();
    }
}
