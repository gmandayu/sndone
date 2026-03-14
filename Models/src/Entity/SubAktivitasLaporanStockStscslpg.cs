namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasLaporanStockSTSCSLPG" table
 */
[Table("SubAktivitasLaporanStockSTSCSLPG")]
public class SubAktivitasLaporanStockStscslpg
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

    [Column("StockAwal")]
    public string? StockAwal { get; set; }

    [Column("Penerimaan")]
    public string? Penerimaan { get; set; }

    [Column("Penyaluran")]
    public string? Penyaluran { get; set; }

    [Column("StockAkhir")]
    public string? StockAkhir { get; set; }

    [Column("WorkingLoss")]
    public string? WorkingLoss { get; set; }

    [Column("Presentase")]
    public string? Presentase { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("Tangki")]
    public string? Tangki { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }
}
