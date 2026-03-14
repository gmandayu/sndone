namespace SnDOne.Entities;

/**
 * Entity class for "v_aktifitas_with_dokumen" table
 */
[Table("v_aktifitas_with_dokumen")]
public class VAktifitasWithDokuman
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

    [Column("Shipment")]
    public string? Shipment { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("StatusAktivitas")]
    public string? StatusAktivitas { get; set; }

    [Column("IdDokumen")]
    public int? IdDokumen { get; set; }

    [Column("NamaDokumen")]
    public string? NamaDokumen { get; set; }

    [Column("PathFile")]
    public string? PathFile { get; set; }

    [Column("TanggalUploadDok")]
    public DateTime? TanggalUploadDok { get; set; }

    [Column("UserUploadDok")]
    public string? UserUploadDok { get; set; }

    [Column("IdProses")]
    public int? IdProses { get; set; }
}
