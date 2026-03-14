namespace SnDOne.Entities;

/**
 * Entity class for "SubaktivitasInputLogbookPenyaluranPipa" table
 */
[Table("SubaktivitasInputLogbookPenyaluranPipa")]
public class SubaktivitasInputLogbookPenyaluranPipa
{
    [Key("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("IdAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("NomorTangki")]
    public string? NomorTangki { get; set; }

    [Column("LO")]
    public string? Lo { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("MeterAwal")]
    public string? MeterAwal { get; set; }

    [Column("Quantity")]
    public string? Quantity { get; set; }

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

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }
}
