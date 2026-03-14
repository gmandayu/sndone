namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasStopBongkarList/{id?}", Name = "SubaktivitasStopBongkarList-SubaktivitasStopBongkar-list")]
    [Route("Home/SubaktivitasStopBongkarList/{id?}", Name = "SubaktivitasStopBongkarList-SubaktivitasStopBongkar-list-2")]
    public async Task<IActionResult> SubaktivitasStopBongkarList()
    {
        // Create page object
        subaktivitasStopBongkarList = new GLOBALS.SubaktivitasStopBongkarList(this);
        subaktivitasStopBongkarList.Cache = _cache;

        // Run the page
        return await subaktivitasStopBongkarList.Run();
    }

    // edit
    [Route("SubaktivitasStopBongkarEdit/{id?}", Name = "SubaktivitasStopBongkarEdit-SubaktivitasStopBongkar-edit")]
    [Route("Home/SubaktivitasStopBongkarEdit/{id?}", Name = "SubaktivitasStopBongkarEdit-SubaktivitasStopBongkar-edit-2")]
    public async Task<IActionResult> SubaktivitasStopBongkarEdit()
    {
        // Create page object
        subaktivitasStopBongkarEdit = new GLOBALS.SubaktivitasStopBongkarEdit(this);

        // Run the page
        return await subaktivitasStopBongkarEdit.Run();
    }
}
