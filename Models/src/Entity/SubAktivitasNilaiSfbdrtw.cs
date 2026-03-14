namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiSFBDRTW" table
 */
[Table("SubAktivitasNilaiSFBDRTW")]
public class SubAktivitasNilaiSfbdrtw
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("SFBD_KL_Obs")]
    public string? SfbdKlObs { get; set; }

    [Column("SFBD_KL_15")]
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

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }
}
