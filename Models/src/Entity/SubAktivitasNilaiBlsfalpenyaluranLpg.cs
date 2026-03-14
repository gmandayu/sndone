namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiBLSFALPenyaluranLPG" table
 */
[Table("SubAktivitasNilaiBLSFALPenyaluranLPG")]
public class SubAktivitasNilaiBlsfalpenyaluranLpg
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("BL_MT")]
    public string? BlMt { get; set; }

    [Column("SFAL_MT")]
    public string? SfalMt { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
