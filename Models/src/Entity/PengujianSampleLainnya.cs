namespace SnDOne.Entities;

/**
 * Entity class for "PengujianSampleLainnya" table
 */
[Table("PengujianSampleLainnya")]
public class PengujianSampleLainnya
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NomorPengujianSampelLainnya")]
    public string? NomorPengujianSampelLainnya { get; set; }

    [Column("idPlant")]
    public int? IdPlant { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("UploadHasil")]
    public string? UploadHasil { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("DibuatOleh")]
    public string? DibuatOleh { get; set; }

    [Column("TanggalDibuat")]
    public DateTime? TanggalDibuat { get; set; }

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }
}
