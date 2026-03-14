namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputDataMobilTangki" table
 */
[Table("SubAktivitasFormInputDataMobilTangki")]
public class SubAktivitasFormInputDataMobilTangki
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

    [Column("JenisProduk")]
    public string? JenisProduk { get; set; }

    [Column("Shipment")]
    public string? Shipment { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("NomorPolisi")]
    public string? NomorPolisi { get; set; }

    [Column("Nominasi")]
    public string? Nominasi { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
