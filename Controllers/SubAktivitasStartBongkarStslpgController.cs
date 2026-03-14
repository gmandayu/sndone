namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasStartBongkarStslpgList/{id?}", Name = "SubAktivitasStartBongkarStslpgList-SubAktivitasStartBongkarSTSLPG-list")]
    [Route("Home/SubAktivitasStartBongkarStslpgList/{id?}", Name = "SubAktivitasStartBongkarStslpgList-SubAktivitasStartBongkarSTSLPG-list-2")]
    public async Task<IActionResult> SubAktivitasStartBongkarStslpgList()
    {
        // Create page object
        subAktivitasStartBongkarStslpgList = new GLOBALS.SubAktivitasStartBongkarStslpgList(this);
        subAktivitasStartBongkarStslpgList.Cache = _cache;

        // Run the page
        return await subAktivitasStartBongkarStslpgList.Run();
    }

    // edit
    [Route("SubAktivitasStartBongkarStslpgEdit/{id?}", Name = "SubAktivitasStartBongkarStslpgEdit-SubAktivitasStartBongkarSTSLPG-edit")]
    [Route("Home/SubAktivitasStartBongkarStslpgEdit/{id?}", Name = "SubAktivitasStartBongkarStslpgEdit-SubAktivitasStartBongkarSTSLPG-edit-2")]
    public async Task<IActionResult> SubAktivitasStartBongkarStslpgEdit()
    {
        // Create page object
        subAktivitasStartBongkarStslpgEdit = new GLOBALS.SubAktivitasStartBongkarStslpgEdit(this);

        // Run the page
        return await subAktivitasStartBongkarStslpgEdit.Run();
    }
}
