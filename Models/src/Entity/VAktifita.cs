namespace SnDOne.Entities;

/**
 * Entity class for "v_aktifitas" table
 */
[Table("v_aktifitas")]
public class VAktifita
{
    [Column("IdAktivitas")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAktivitas { get; set; } = default!;

    [Column("NamaAktivitas")]
    public string? NamaAktivitas { get; set; }

    [Column("Nama_Proses")]
    public string? NamaProses { get; set; }

    [Column("No_referensi")]
    public string? NoReferensi { get; set; }

    [Column("Shipment")]
    public string? Shipment { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("StatusAktivitas")]
    public string? StatusAktivitas { get; set; }

    [Column("IdProses")]
    public int? IdProses { get; set; }
}
