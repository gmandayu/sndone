namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasDataMobilTangkiMTGateOut" table
 */
[Table("SubAktivitasDataMobilTangkiMTGateOut")]
public class SubAktivitasDataMobilTangkiMtgateOut
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

    [Column("NomorSegel")]
    public string? NomorSegel { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("WaktuGateOut")]
    public DateTime? WaktuGateOut { get; set; }
}
