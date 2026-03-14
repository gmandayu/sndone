namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiBLSFALLPG" table
 */
[Table("SubAktivitasNilaiBLSFALLPG")]
public class SubAktivitasNilaiBlsfallpg
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

    [Column("BL_mt")]
    public string? BlMt { get; set; }

    [Column("SFAL_mt")]
    public string? SfalMt { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }
}
