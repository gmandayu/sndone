namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasCatatanKhusus" table
 */
[Table("SubAktivitasCatatanKhusus")]
public class SubAktivitasCatatanKhusus
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

    [Column("Kontaminasi")]
    public string? Kontaminasi { get; set; }

    [Column("Insident")]
    public string? Insident { get; set; }

    [Column("CuacaBuruk")]
    public string? CuacaBuruk { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
