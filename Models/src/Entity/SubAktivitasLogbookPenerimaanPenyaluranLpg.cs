namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasLogbookPenerimaanPenyaluranLPG" table
 */
[Table("SubAktivitasLogbookPenerimaanPenyaluranLPG")]
public class SubAktivitasLogbookPenerimaanPenyaluranLpg
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

    [Column("NomorTangki")]
    public string? NomorTangki { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("SPA")]
    public string? Spa { get; set; }

    [Column("BayNumber")]
    public string? BayNumber { get; set; }

    [Column("Quantity")]
    public string? Quantity { get; set; }

    [Column("MeterAwal")]
    public string? MeterAwal { get; set; }

    [Column("MeterAkhir")]
    public string? MeterAkhir { get; set; }

    [Column("PresentaseLevelRotoGauge")]
    public string? PresentaseLevelRotoGauge { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
