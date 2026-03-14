namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputHslPemeriksaanList/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanList-SubAktivitasFormInputHslPemeriksaan-list")]
    [Route("Home/SubAktivitasFormInputHslPemeriksaanList/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanList-SubAktivitasFormInputHslPemeriksaan-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputHslPemeriksaanList()
    {
        // Create page object
        subAktivitasFormInputHslPemeriksaanList = new GLOBALS.SubAktivitasFormInputHslPemeriksaanList(this);
        subAktivitasFormInputHslPemeriksaanList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputHslPemeriksaanList.Run();
    }

    // add
    [Route("SubAktivitasFormInputHslPemeriksaanAdd/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanAdd-SubAktivitasFormInputHslPemeriksaan-add")]
    [Route("Home/SubAktivitasFormInputHslPemeriksaanAdd/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanAdd-SubAktivitasFormInputHslPemeriksaan-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputHslPemeriksaanAdd()
    {
        // Create page object
        subAktivitasFormInputHslPemeriksaanAdd = new GLOBALS.SubAktivitasFormInputHslPemeriksaanAdd(this);

        // Run the page
        return await subAktivitasFormInputHslPemeriksaanAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputHslPemeriksaanView/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanView-SubAktivitasFormInputHslPemeriksaan-view")]
    [Route("Home/SubAktivitasFormInputHslPemeriksaanView/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanView-SubAktivitasFormInputHslPemeriksaan-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputHslPemeriksaanView()
    {
        // Create page object
        subAktivitasFormInputHslPemeriksaanView = new GLOBALS.SubAktivitasFormInputHslPemeriksaanView(this);

        // Run the page
        return await subAktivitasFormInputHslPemeriksaanView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputHslPemeriksaanEdit/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanEdit-SubAktivitasFormInputHslPemeriksaan-edit")]
    [Route("Home/SubAktivitasFormInputHslPemeriksaanEdit/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanEdit-SubAktivitasFormInputHslPemeriksaan-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputHslPemeriksaanEdit()
    {
        // Create page object
        subAktivitasFormInputHslPemeriksaanEdit = new GLOBALS.SubAktivitasFormInputHslPemeriksaanEdit(this);

        // Run the page
        return await subAktivitasFormInputHslPemeriksaanEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputHslPemeriksaanDelete/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanDelete-SubAktivitasFormInputHslPemeriksaan-delete")]
    [Route("Home/SubAktivitasFormInputHslPemeriksaanDelete/{id?}", Name = "SubAktivitasFormInputHslPemeriksaanDelete-SubAktivitasFormInputHslPemeriksaan-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputHslPemeriksaanDelete()
    {
        // Create page object
        subAktivitasFormInputHslPemeriksaanDelete = new GLOBALS.SubAktivitasFormInputHslPemeriksaanDelete(this);

        // Run the page
        return await subAktivitasFormInputHslPemeriksaanDelete.Run();
    }
}
