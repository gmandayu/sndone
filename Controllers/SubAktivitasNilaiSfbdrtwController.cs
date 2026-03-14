namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasNilaiSfbdrtwList/{id?}", Name = "SubAktivitasNilaiSfbdrtwList-SubAktivitasNilaiSFBDRTW-list")]
    [Route("Home/SubAktivitasNilaiSfbdrtwList/{id?}", Name = "SubAktivitasNilaiSfbdrtwList-SubAktivitasNilaiSFBDRTW-list-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdrtwList()
    {
        // Create page object
        subAktivitasNilaiSfbdrtwList = new GLOBALS.SubAktivitasNilaiSfbdrtwList(this);
        subAktivitasNilaiSfbdrtwList.Cache = _cache;

        // Run the page
        return await subAktivitasNilaiSfbdrtwList.Run();
    }

    // add
    [Route("SubAktivitasNilaiSfbdrtwAdd/{id?}", Name = "SubAktivitasNilaiSfbdrtwAdd-SubAktivitasNilaiSFBDRTW-add")]
    [Route("Home/SubAktivitasNilaiSfbdrtwAdd/{id?}", Name = "SubAktivitasNilaiSfbdrtwAdd-SubAktivitasNilaiSFBDRTW-add-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdrtwAdd()
    {
        // Create page object
        subAktivitasNilaiSfbdrtwAdd = new GLOBALS.SubAktivitasNilaiSfbdrtwAdd(this);

        // Run the page
        return await subAktivitasNilaiSfbdrtwAdd.Run();
    }

    // view
    [Route("SubAktivitasNilaiSfbdrtwView/{id?}", Name = "SubAktivitasNilaiSfbdrtwView-SubAktivitasNilaiSFBDRTW-view")]
    [Route("Home/SubAktivitasNilaiSfbdrtwView/{id?}", Name = "SubAktivitasNilaiSfbdrtwView-SubAktivitasNilaiSFBDRTW-view-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdrtwView()
    {
        // Create page object
        subAktivitasNilaiSfbdrtwView = new GLOBALS.SubAktivitasNilaiSfbdrtwView(this);

        // Run the page
        return await subAktivitasNilaiSfbdrtwView.Run();
    }

    // edit
    [Route("SubAktivitasNilaiSfbdrtwEdit/{id?}", Name = "SubAktivitasNilaiSfbdrtwEdit-SubAktivitasNilaiSFBDRTW-edit")]
    [Route("Home/SubAktivitasNilaiSfbdrtwEdit/{id?}", Name = "SubAktivitasNilaiSfbdrtwEdit-SubAktivitasNilaiSFBDRTW-edit-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdrtwEdit()
    {
        // Create page object
        subAktivitasNilaiSfbdrtwEdit = new GLOBALS.SubAktivitasNilaiSfbdrtwEdit(this);

        // Run the page
        return await subAktivitasNilaiSfbdrtwEdit.Run();
    }

    // delete
    [Route("SubAktivitasNilaiSfbdrtwDelete/{id?}", Name = "SubAktivitasNilaiSfbdrtwDelete-SubAktivitasNilaiSFBDRTW-delete")]
    [Route("Home/SubAktivitasNilaiSfbdrtwDelete/{id?}", Name = "SubAktivitasNilaiSfbdrtwDelete-SubAktivitasNilaiSFBDRTW-delete-2")]
    public async Task<IActionResult> SubAktivitasNilaiSfbdrtwDelete()
    {
        // Create page object
        subAktivitasNilaiSfbdrtwDelete = new GLOBALS.SubAktivitasNilaiSfbdrtwDelete(this);

        // Run the page
        return await subAktivitasNilaiSfbdrtwDelete.Run();
    }
}
