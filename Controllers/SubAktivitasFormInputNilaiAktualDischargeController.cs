namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasFormInputNilaiAktualDischargeList/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeList-SubAktivitasFormInputNilaiAktualDischarge-list")]
    [Route("Home/SubAktivitasFormInputNilaiAktualDischargeList/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeList-SubAktivitasFormInputNilaiAktualDischarge-list-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktualDischargeList()
    {
        // Create page object
        subAktivitasFormInputNilaiAktualDischargeList = new GLOBALS.SubAktivitasFormInputNilaiAktualDischargeList(this);
        subAktivitasFormInputNilaiAktualDischargeList.Cache = _cache;

        // Run the page
        return await subAktivitasFormInputNilaiAktualDischargeList.Run();
    }

    // add
    [Route("SubAktivitasFormInputNilaiAktualDischargeAdd/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeAdd-SubAktivitasFormInputNilaiAktualDischarge-add")]
    [Route("Home/SubAktivitasFormInputNilaiAktualDischargeAdd/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeAdd-SubAktivitasFormInputNilaiAktualDischarge-add-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktualDischargeAdd()
    {
        // Create page object
        subAktivitasFormInputNilaiAktualDischargeAdd = new GLOBALS.SubAktivitasFormInputNilaiAktualDischargeAdd(this);

        // Run the page
        return await subAktivitasFormInputNilaiAktualDischargeAdd.Run();
    }

    // view
    [Route("SubAktivitasFormInputNilaiAktualDischargeView/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeView-SubAktivitasFormInputNilaiAktualDischarge-view")]
    [Route("Home/SubAktivitasFormInputNilaiAktualDischargeView/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeView-SubAktivitasFormInputNilaiAktualDischarge-view-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktualDischargeView()
    {
        // Create page object
        subAktivitasFormInputNilaiAktualDischargeView = new GLOBALS.SubAktivitasFormInputNilaiAktualDischargeView(this);

        // Run the page
        return await subAktivitasFormInputNilaiAktualDischargeView.Run();
    }

    // edit
    [Route("SubAktivitasFormInputNilaiAktualDischargeEdit/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeEdit-SubAktivitasFormInputNilaiAktualDischarge-edit")]
    [Route("Home/SubAktivitasFormInputNilaiAktualDischargeEdit/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeEdit-SubAktivitasFormInputNilaiAktualDischarge-edit-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktualDischargeEdit()
    {
        // Create page object
        subAktivitasFormInputNilaiAktualDischargeEdit = new GLOBALS.SubAktivitasFormInputNilaiAktualDischargeEdit(this);

        // Run the page
        return await subAktivitasFormInputNilaiAktualDischargeEdit.Run();
    }

    // delete
    [Route("SubAktivitasFormInputNilaiAktualDischargeDelete/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeDelete-SubAktivitasFormInputNilaiAktualDischarge-delete")]
    [Route("Home/SubAktivitasFormInputNilaiAktualDischargeDelete/{id?}", Name = "SubAktivitasFormInputNilaiAktualDischargeDelete-SubAktivitasFormInputNilaiAktualDischarge-delete-2")]
    public async Task<IActionResult> SubAktivitasFormInputNilaiAktualDischargeDelete()
    {
        // Create page object
        subAktivitasFormInputNilaiAktualDischargeDelete = new GLOBALS.SubAktivitasFormInputNilaiAktualDischargeDelete(this);

        // Run the page
        return await subAktivitasFormInputNilaiAktualDischargeDelete.Run();
    }
}
