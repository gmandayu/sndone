namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM" table
 */
[Table("SubAktivitasNilaiBLSFALPenyaluranSTSPyrBBM")]
public class SubAktivitasNilaiBlsfalpenyaluranStspyrBbm
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

    [Column("BL_KLObs")]
    public string? BlKlobs { get; set; }

    [Column("BL_KL15")]
    public string? BlKl15 { get; set; }

    [Column("BL_Barrels")]
    public string? BlBarrels { get; set; }

    [Column("BL_LT")]
    public string? BlLt { get; set; }

    [Column("BL_MT")]
    public string? BlMt { get; set; }

    [Column("SFAL_KLObs")]
    public string? SfalKlobs { get; set; }

    [Column("SFAL_KL15")]
    public string? SfalKl15 { get; set; }

    [Column("SFAL_Barrels")]
    public string? SfalBarrels { get; set; }

    [Column("SFAL_LT")]
    public string? SfalLt { get; set; }

    [Column("SFAL_MT")]
    public string? SfalMt { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
