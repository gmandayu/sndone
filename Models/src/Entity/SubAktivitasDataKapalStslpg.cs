namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasDataKapalSTSLPG" table
 */
[Table("SubAktivitasDataKapalSTSLPG")]
public class SubAktivitasDataKapalStslpg
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("lastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("namakapal")]
    public string? Namakapal { get; set; }

    [Column("shipment")]
    public string? Shipment { get; set; }

    [Column("produk")]
    public string? Produk { get; set; }

    [Column("nominasi")]
    public string? Nominasi { get; set; }

    [Column("tgltiba")]
    public DateTime? Tgltiba { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
