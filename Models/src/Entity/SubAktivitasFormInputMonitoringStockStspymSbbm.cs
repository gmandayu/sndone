namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputMonitoringStockSTSPymSBBM" table
 */
[Table("SubAktivitasFormInputMonitoringStockSTSPymSBBM")]
public class SubAktivitasFormInputMonitoringStockStspymSbbm
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

    [Column("NomorTangki")]
    public string? NomorTangki { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Aktivitas")]
    public string? Aktivitas { get; set; }

    [Column("QuantityAwal")]
    public string? QuantityAwal { get; set; }

    [Column("QuantityAkhir")]
    public string? QuantityAkhir { get; set; }

    [Column("Flowrate")]
    public string? Flowrate { get; set; }

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

    [Column("TanggalQuantityAwal")]
    public DateTime? TanggalQuantityAwal { get; set; }

    [Column("TanggalQuantityAkhir")]
    public DateTime? TanggalQuantityAkhir { get; set; }
}
