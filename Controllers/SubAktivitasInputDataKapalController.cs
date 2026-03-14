namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasInputDataKapalList/{id?}", Name = "SubAktivitasInputDataKapalList-SubAktivitasInputDataKapal-list")]
    [Route("Home/SubAktivitasInputDataKapalList/{id?}", Name = "SubAktivitasInputDataKapalList-SubAktivitasInputDataKapal-list-2")]
    public async Task<IActionResult> SubAktivitasInputDataKapalList()
    {
        // Create page object
        subAktivitasInputDataKapalList = new GLOBALS.SubAktivitasInputDataKapalList(this);
        subAktivitasInputDataKapalList.Cache = _cache;

        // Run the page
        return await subAktivitasInputDataKapalList.Run();
    }

    // edit
    [Route("SubAktivitasInputDataKapalEdit/{id?}", Name = "SubAktivitasInputDataKapalEdit-SubAktivitasInputDataKapal-edit")]
    [Route("Home/SubAktivitasInputDataKapalEdit/{id?}", Name = "SubAktivitasInputDataKapalEdit-SubAktivitasInputDataKapal-edit-2")]
    public async Task<IActionResult> SubAktivitasInputDataKapalEdit()
    {
        // Create page object
        subAktivitasInputDataKapalEdit = new GLOBALS.SubAktivitasInputDataKapalEdit(this);

        // Run the page
        return await subAktivitasInputDataKapalEdit.Run();
    }
}
