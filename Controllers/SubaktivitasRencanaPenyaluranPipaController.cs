namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubaktivitasRencanaPenyaluranPipaList/{id?}", Name = "SubaktivitasRencanaPenyaluranPipaList-SubaktivitasRencanaPenyaluranPipa-list")]
    [Route("Home/SubaktivitasRencanaPenyaluranPipaList/{id?}", Name = "SubaktivitasRencanaPenyaluranPipaList-SubaktivitasRencanaPenyaluranPipa-list-2")]
    public async Task<IActionResult> SubaktivitasRencanaPenyaluranPipaList()
    {
        // Create page object
        subaktivitasRencanaPenyaluranPipaList = new GLOBALS.SubaktivitasRencanaPenyaluranPipaList(this);
        subaktivitasRencanaPenyaluranPipaList.Cache = _cache;

        // Run the page
        return await subaktivitasRencanaPenyaluranPipaList.Run();
    }

    // edit
    [Route("SubaktivitasRencanaPenyaluranPipaEdit/{id?}", Name = "SubaktivitasRencanaPenyaluranPipaEdit-SubaktivitasRencanaPenyaluranPipa-edit")]
    [Route("Home/SubaktivitasRencanaPenyaluranPipaEdit/{id?}", Name = "SubaktivitasRencanaPenyaluranPipaEdit-SubaktivitasRencanaPenyaluranPipa-edit-2")]
    public async Task<IActionResult> SubaktivitasRencanaPenyaluranPipaEdit()
    {
        // Create page object
        subaktivitasRencanaPenyaluranPipaEdit = new GLOBALS.SubaktivitasRencanaPenyaluranPipaEdit(this);

        // Run the page
        return await subaktivitasRencanaPenyaluranPipaEdit.Run();
    }
}
