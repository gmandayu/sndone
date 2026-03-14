namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasDataMobilTangkiMTGateIn" table
 */
[Table("SubAktivitasDataMobilTangkiMTGateIn")]
public class SubAktivitasDataMobilTangkiMtgateIn
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

    [Column("NomorPolisi")]
    public string? NomorPolisi { get; set; }

    [Column("AMT")]
    public string? Amt { get; set; }

    [Column("WaktuGateIn")]
    public DateTime? WaktuGateIn { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
