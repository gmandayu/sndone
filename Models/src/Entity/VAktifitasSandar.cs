namespace SnDOne.Entities;

/**
 * Entity class for "v_aktifitas_sandar" table
 */
[Table("v_aktifitas_sandar")]
public class VAktifitasSandar
{
    [Key("IdAktivitas")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAktivitas { get; set; } = default!;

    [Column("NamaAktivitas")]
    public string? NamaAktivitas { get; set; }

    [Column("Nama_Proses")]
    public string? NamaProses { get; set; }

    [Column("No_referensi")]
    public string? NoReferensi { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("StatusAktivitas")]
    public string? StatusAktivitas { get; set; }

    [Column("Shipment")]
    public string? Shipment { get; set; }

    [Column("sandar_nama_kapal")]
    public string? SandarNamaKapal { get; set; }

    [Column("sandar_tgl_tiba")]
    public DateTime? SandarTglTiba { get; set; }

    [Column("sandar_nominasi")]
    public string? SandarNominasi { get; set; }

    [Column("IdProses")]
    public int? IdProses { get; set; }
}
