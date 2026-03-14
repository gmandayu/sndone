namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputBLsesuaiCQLRTW" table
 */
[Table("SubAktivitasFormInputBLsesuaiCQLRTW")]
public class SubAktivitasFormInputBlsesuaiCqlrtw
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("KL_Obs")]
    public string? KlObs { get; set; }

    [Column("KL_15")]
    public string? Kl15 { get; set; }

    [Column("Barrels")]
    public string? Barrels { get; set; }

    [Column("LT")]
    public string? Lt { get; set; }

    [Column("ML")]
    public string? Ml { get; set; }

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
