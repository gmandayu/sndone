namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiSFBDPenKon" table
 */
[Table("SubAktivitasNilaiSFBDPenKon")]
public class SubAktivitasNilaiSfbdpenKon
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

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("SFBD_KLObs")]
    public string? SfbdKlobs { get; set; }

    [Column("SFBD_KL15")]
    public string? SfbdKl15 { get; set; }

    [Column("SFBD_Barrels")]
    public string? SfbdBarrels { get; set; }

    [Column("SFBD_LT")]
    public string? SfbdLt { get; set; }

    [Column("SFBD_MT")]
    public string? SfbdMt { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
