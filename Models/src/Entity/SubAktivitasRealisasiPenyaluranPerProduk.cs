namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasRealisasiPenyaluranPerProduk" table
 */
[Table("SubAktivitasRealisasiPenyaluranPerProduk")]
public class SubAktivitasRealisasiPenyaluranPerProduk
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Shift1")]
    public string? Shift1 { get; set; }

    [Column("Shift2")]
    public string? Shift2 { get; set; }

    [Column("Shift3")]
    public string? Shift3 { get; set; }

    [Column("Shift4")]
    public string? Shift4 { get; set; }

    [Column("Total")]
    public string? Total { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
