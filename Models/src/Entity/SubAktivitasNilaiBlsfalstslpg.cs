namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiBLSFALSTSLPG" table
 */
[Table("SubAktivitasNilaiBLSFALSTSLPG")]
public class SubAktivitasNilaiBlsfalstslpg
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("BL_mt")]
    public string? BlMt { get; set; }

    [Column("SFAL_mt")]
    public string? SfalMt { get; set; }

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
