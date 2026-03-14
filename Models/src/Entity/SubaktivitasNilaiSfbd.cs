namespace SnDOne.Entities;

/**
 * Entity class for "SubaktivitasNilaiSFBD" table
 */
[Table("SubaktivitasNilaiSFBD")]
public class SubaktivitasNilaiSfbd
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

    [Column("klobs")]
    public string? Klobs { get; set; }

    [Column("kl15")]
    public string? Kl15 { get; set; }

    [Column("barrels")]
    public string? Barrels { get; set; }

    [Column("lt")]
    public string? Lt { get; set; }

    [Column("mt")]
    public string? Mt { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }
}
