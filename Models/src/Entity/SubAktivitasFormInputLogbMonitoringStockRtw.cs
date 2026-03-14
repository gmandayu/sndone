namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputLogbMonitoringStockRTW" table
 */
[Table("SubAktivitasFormInputLogbMonitoringStockRTW")]
public class SubAktivitasFormInputLogbMonitoringStockRtw
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("NoTangki")]
    public int? NoTangki { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Aktivitas")]
    public string? Aktivitas { get; set; }

    [Column("LevelTangki")]
    public string? LevelTangki { get; set; }

    [Column("Volume")]
    public string? Volume { get; set; }

    [Column("Flowrate")]
    public string? Flowrate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }
}
