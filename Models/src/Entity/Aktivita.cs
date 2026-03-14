namespace SnDOne.Entities;

/**
 * Entity class for "Aktivitas" table
 */
[Table("Aktivitas")]
public class Aktivita
{
    [Key("IdAktivitas")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAktivitas { get; set; } = default!;

    [Column("No_Referensi")]
    public string? NoReferensi { get; set; }

    [Column("IdProses")]
    public int? IdProses { get; set; }

    [Column("IdTemplateAktivitas")]
    public int? IdTemplateAktivitas { get; set; }

    [Column("NamaAktivitas")]
    public string? NamaAktivitas { get; set; }

    [Column("PIC")]
    public string? Pic { get; set; }

    [Column("TanggalMulai")]
    public DateTime? TanggalMulai { get; set; }

    [Column("TanggalSelesai")]
    public DateTime? TanggalSelesai { get; set; }

    [Column("StatusAktivitas")]
    public string? StatusAktivitas { get; set; }

    [Column("DibuatOleh")]
    public string? DibuatOleh { get; set; }

    [Column("TanggalDibuat")]
    public DateTime? TanggalDibuat { get; set; }

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }

    [Column("TipeAktivitas")]
    public string? TipeAktivitas { get; set; }

    [Column("sandar_nama_kapal")]
    public string? SandarNamaKapal { get; set; }

    [Column("sandar_tgl_tiba")]
    public DateTime? SandarTglTiba { get; set; }

    [Column("sandar_nominasi")]
    public string? SandarNominasi { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Shipment")]
    public string? Shipment { get; set; }

    [Column("Nama_Proses")]
    public string? NamaProses { get; set; }

    [Column("IdDokumen")]
    public int? IdDokumen { get; set; }

    [Column("PathFile")]
    public string? PathFile { get; set; }

    [Column("TanggalUploadDok")]
    public DateTime? TanggalUploadDok { get; set; }

    [Column("UserUploadDok")]
    public string? UserUploadDok { get; set; }

    [Column("NamaDokumen")]
    public string? NamaDokumen { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("IdRefAnak")]
    public int? IdRefAnak { get; set; }

    [Column("TableAnak")]
    public string? TableAnak { get; set; }

    [Column("TipeProses")]
    public string? TipeProses { get; set; }

    [Column("Urutan")]
    public int? Urutan { get; set; }

    [Column("IsNominationTankReceivingLineOpen")]
    public bool IsNominationTankReceivingLineOpen { get; set; } = default!;

    [Column("IsNonNominationReceivingLineClosedAndSealed")]
    public bool IsNonNominationReceivingLineClosedAndSealed { get; set; } = default!;

    [Column("IsTankEmptyAndDry")]
    public bool IsTankEmptyAndDry { get; set; } = default!;

    [Column("IsDocumentationComplete")]
    public bool IsDocumentationComplete { get; set; } = default!;
}
