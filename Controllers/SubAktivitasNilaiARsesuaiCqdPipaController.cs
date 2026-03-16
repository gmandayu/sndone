namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiARsesuaiCqdPipaList/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdPipaList-SubAktivitasNilaiARsesuaiCQDPipa-list")]
    [Route("Home/SubAktivitasNilaiARsesuaiCqdPipaList/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdPipaList-SubAktivitasNilaiARsesuaiCQDPipa-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiARsesuaiCqdPipaList()
    {
        // Create page object
        subAktivitasNilaiARsesuaiCqdPipaList = new GLOBALS.SubAktivitasNilaiARsesuaiCqdPipaList(this);
        subAktivitasNilaiARsesuaiCqdPipaList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiARsesuaiCqdPipaList.Run();
    }

    // edit
    [Route("SubAktivitasNilaiARsesuaiCqdPipaEdit/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdPipaEdit-SubAktivitasNilaiARsesuaiCQDPipa-edit")]
    [Route("Home/SubAktivitasNilaiARsesuaiCqdPipaEdit/{id?}", Name = "SubAktivitasNilaiARsesuaiCqdPipaEdit-SubAktivitasNilaiARsesuaiCQDPipa-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiARsesuaiCqdPipaEdit()
    {
        // Create page object
        subAktivitasNilaiARsesuaiCqdPipaEdit = new GLOBALS.SubAktivitasNilaiARsesuaiCqdPipaEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasNilaiARsesuaiCqdPipaEdit.Run();
    }
}
