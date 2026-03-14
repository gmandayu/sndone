namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymBBM" table
 */
[Table("SubAktivitasFormInputNilaiBLsesuaiCQLSTSPymBBM")]
public class SubAktivitasFormInputNilaiBlsesuaiCqlstspymBbm
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

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("KL_Obs")]
    public string? KlObs { get; set; }

    [Column("KL_15")]
    public string? Kl15 { get; set; }

    [Column("Barrels")]
    public string? Barrels { get; set; }

    [Column("LT")]
    public string? Lt { get; set; }

    [Column("MT")]
    public string? Mt { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("SFAL_KL_Obs")]
    public string? SfalKlObs { get; set; }

    [Column("SFAL_KL_15")]
    public string? SfalKl15 { get; set; }

    [Column("SFAL_Barrels")]
    public string? SfalBarrels { get; set; }

    [Column("SFAL_LT")]
    public string? SfalLt { get; set; }

    [Column("SFAL_MT")]
    public string? SfalMt { get; set; }
}
