namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasInputDataRTW" table
 */
[Table("SubAktivitasInputDataRTW")]
public class SubAktivitasInputDataRtw
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

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("NomorGerbongKertel")]
    public string? NomorGerbongKertel { get; set; }

    [Column("MeterAwal")]
    public string? MeterAwal { get; set; }

    [Column("MeterAkhir")]
    public string? MeterAkhir { get; set; }

    [Column("Total")]
    public string? Total { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("NoMeter")]
    public string? NoMeter { get; set; }

    [Column("Quantity")]
    public string? Quantity { get; set; }

    [Column("HasilPengukuranT2")]
    public string? HasilPengukuranT2 { get; set; }

    [Column("PICPengisian")]
    public string? Picpengisian { get; set; }

    [Column("NomorGerbongKertel2")]
    public string? NomorGerbongKertel2 { get; set; }

    [Column("NomorGerbongKertel3")]
    public string? NomorGerbongKertel3 { get; set; }

    [Column("Quantity2")]
    public string? Quantity2 { get; set; }

    [Column("Quantity3")]
    public string? Quantity3 { get; set; }

    [Column("HasilPengukuranT2_2")]
    public string? HasilPengukuranT22 { get; set; }

    [Column("HasilPengukuranT2_3")]
    public string? HasilPengukuranT23 { get; set; }

    [Column("TotalGK")]
    public string? TotalGk { get; set; }

    [Column("Selisih")]
    public string? Selisih { get; set; }
}
