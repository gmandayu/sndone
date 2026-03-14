namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasInputDataKapal" table
 */
[Table("SubAktivitasInputDataKapal")]
public class SubAktivitasInputDataKapal
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

    [Column("NamaKapal")]
    public string? NamaKapal { get; set; }

    [Column("JenisProduk")]
    public string? JenisProduk { get; set; }

    [Column("Nominasi")]
    public string? Nominasi { get; set; }

    [Column("VoyageNumber")]
    public string? VoyageNumber { get; set; }

    [Column("TanggalTiba")]
    public DateTime? TanggalTiba { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
