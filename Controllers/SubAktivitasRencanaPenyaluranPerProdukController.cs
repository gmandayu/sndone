namespace SnDOne.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("SubAktivitasRencanaPenyaluranPerProdukList/{id?}", Name = "SubAktivitasRencanaPenyaluranPerProdukList-SubAktivitasRencanaPenyaluranPerProduk-list")]
    [Route("Home/SubAktivitasRencanaPenyaluranPerProdukList/{id?}", Name = "SubAktivitasRencanaPenyaluranPerProdukList-SubAktivitasRencanaPenyaluranPerProduk-list-2")]
    public async Task<IActionResult> SubAktivitasRencanaPenyaluranPerProdukList()
    {
        // Create page object
        subAktivitasRencanaPenyaluranPerProdukList = new GLOBALS.SubAktivitasRencanaPenyaluranPerProdukList(this);
        subAktivitasRencanaPenyaluranPerProdukList.Cache = _cache;

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasRencanaPenyaluranPerProdukList.Run();
    }

    // edit
    [Route("SubAktivitasRencanaPenyaluranPerProdukEdit/{id?}", Name = "SubAktivitasRencanaPenyaluranPerProdukEdit-SubAktivitasRencanaPenyaluranPerProduk-edit")]
    [Route("Home/SubAktivitasRencanaPenyaluranPerProdukEdit/{id?}", Name = "SubAktivitasRencanaPenyaluranPerProdukEdit-SubAktivitasRencanaPenyaluranPerProduk-edit-2")]
    public async Task<IActionResult> SubAktivitasRencanaPenyaluranPerProdukEdit()
    {
        // Create page object
        subAktivitasRencanaPenyaluranPerProdukEdit = new GLOBALS.SubAktivitasRencanaPenyaluranPerProdukEdit(this);

        // Run the page

        // Touch route params to satisfy analyzers
                    _ = RouteData.Values["id"];

        // Run the page
        return await subAktivitasRencanaPenyaluranPerProdukEdit.Run();
    }
}
