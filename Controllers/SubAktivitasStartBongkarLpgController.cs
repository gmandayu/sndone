namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasStartBongkarLpgList/{id?}", Name = "SubAktivitasStartBongkarLpgList-SubAktivitasStartBongkarLPG-list")]
    [Route("Home/SubAktivitasStartBongkarLpgList/{id?}", Name = "SubAktivitasStartBongkarLpgList-SubAktivitasStartBongkarLPG-list-2")]
    public async Task<IActionResult> SubAktivitasStartBongkarLpgList()
    {
        // Create page object
        subAktivitasStartBongkarLpgList = new GLOBALS.SubAktivitasStartBongkarLpgList(this);
        subAktivitasStartBongkarLpgList.Cache = _cache;

        // Run the page
        return await subAktivitasStartBongkarLpgList.Run();
    }

    // edit
    [Route("SubAktivitasStartBongkarLpgEdit/{id?}", Name = "SubAktivitasStartBongkarLpgEdit-SubAktivitasStartBongkarLPG-edit")]
    [Route("Home/SubAktivitasStartBongkarLpgEdit/{id?}", Name = "SubAktivitasStartBongkarLpgEdit-SubAktivitasStartBongkarLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasStartBongkarLpgEdit()
    {
        // Create page object
        subAktivitasStartBongkarLpgEdit = new GLOBALS.SubAktivitasStartBongkarLpgEdit(this);

        // Run the page
        return await subAktivitasStartBongkarLpgEdit.Run();
    }
}
