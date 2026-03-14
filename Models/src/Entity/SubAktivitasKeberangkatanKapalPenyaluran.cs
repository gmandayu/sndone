namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasKeberangkatanKapalPenyaluran" table
 */
[Table("SubAktivitasKeberangkatanKapalPenyaluran")]
public class SubAktivitasKeberangkatanKapalPenyaluran
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

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
