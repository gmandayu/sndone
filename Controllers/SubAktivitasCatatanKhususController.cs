namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasCatatanKhususList/{id?}", Name = "SubAktivitasCatatanKhususList-SubAktivitasCatatanKhusus-list")]
    [Route("Home/SubAktivitasCatatanKhususList/{id?}", Name = "SubAktivitasCatatanKhususList-SubAktivitasCatatanKhusus-list-2")]
    public async Task<IActionResult> SubAktivitasCatatanKhususList()
    {
        // Create page object
        subAktivitasCatatanKhususList = new GLOBALS.SubAktivitasCatatanKhususList(this);
        subAktivitasCatatanKhususList.Cache = _cache;

        // Run the page
        return await subAktivitasCatatanKhususList.Run();
    }

    // edit
    [Route("SubAktivitasCatatanKhususEdit/{id?}", Name = "SubAktivitasCatatanKhususEdit-SubAktivitasCatatanKhusus-edit")]
    [Route("Home/SubAktivitasCatatanKhususEdit/{id?}", Name = "SubAktivitasCatatanKhususEdit-SubAktivitasCatatanKhusus-edit-2")]
    public async Task<IActionResult> SubAktivitasCatatanKhususEdit()
    {
        // Create page object
        subAktivitasCatatanKhususEdit = new GLOBALS.SubAktivitasCatatanKhususEdit(this);

        // Run the page
        return await subAktivitasCatatanKhususEdit.Run();
    }
}
