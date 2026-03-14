namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputNilaiBD" table
 */
[Table("SubAktivitasFormInputNilaiBD")]
public class SubAktivitasFormInputNilaiBd
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("BD_KLObs")]
    public string? BdKlobs { get; set; }

    [Column("BD_KL15")]
    public string? BdKl15 { get; set; }

    [Column("BD_Barrels")]
    public string? BdBarrels { get; set; }

    [Column("BD_LT")]
    public string? BdLt { get; set; }

    [Column("BD_MT")]
    public string? BdMt { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
