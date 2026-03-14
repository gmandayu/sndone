namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasLogbookMonitoringStock" table
 */
[Table("SubAktivitasLogbookMonitoringStock")]
public class SubAktivitasLogbookMonitoringStock
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

    [Column("Nomor_Tangki")]
    public string? NomorTangki { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Aktivitas")]
    public string? Aktivitas { get; set; }

    [Column("Level_Tangki")]
    public string? LevelTangki { get; set; }

    [Column("Volume_KLObs")]
    public string? VolumeKlobs { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("IdPlant")]
    public int? IdPlant { get; set; }
}
