namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasLogbookJembatanTimbangLPG" table
 */
[Table("SubAktivitasLogbookJembatanTimbangLPG")]
public class SubAktivitasLogbookJembatanTimbangLpg
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

    [Column("TimbanganAwal")]
    public string? TimbanganAwal { get; set; }

    [Column("TimbanganAkhir")]
    public string? TimbanganAkhir { get; set; }

    [Column("NetWight")]
    public string? NetWight { get; set; }

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
