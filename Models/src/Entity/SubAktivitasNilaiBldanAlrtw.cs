namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiBLdanALRTW" table
 */
[Table("SubAktivitasNilaiBLdanALRTW")]
public class SubAktivitasNilaiBldanAlrtw
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("BL_KL_Obs")]
    public string? BlKlObs { get; set; }

    [Column("BL_KL_15")]
    public string? BlKl15 { get; set; }

    [Column("BL_Barrels")]
    public string? BlBarrels { get; set; }

    [Column("BL_LT")]
    public string? BlLt { get; set; }

    [Column("BL_MT")]
    public string? BlMt { get; set; }

    [Column("AL_KL_Obs")]
    public string? AlKlObs { get; set; }

    [Column("AL_KL_15")]
    public string? AlKl15 { get; set; }

    [Column("AL_Barrels")]
    public string? AlBarrels { get; set; }

    [Column("AL_LT")]
    public string? AlLt { get; set; }

    [Column("AL_MT")]
    public string? AlMt { get; set; }

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
