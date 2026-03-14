namespace SnDOne.Entities;

/**
 * Entity class for "SubaktivitasKapalBerangkat" table
 */
[Table("SubaktivitasKapalBerangkat")]
public class SubaktivitasKapalBerangkat
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

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("tglBerangkat")]
    public DateTime? TglBerangkat { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }
}
