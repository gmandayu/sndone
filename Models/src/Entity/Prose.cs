namespace SnDOne.Entities;

/**
 * Entity class for "Proses" table
 */
[Table("Proses")]
public class Prose
{
    [Key("IdProses")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdProses { get; set; } = default!;

    [Column("IdReferensi")]
    public required string IdReferensi { get; set; } = default!;

    [Column("IdTemplateProses")]
    public int? IdTemplateProses { get; set; }

    [Column("NamaProses")]
    public string? NamaProses { get; set; }

    [Column("TanggalMulai")]
    public DateTime? TanggalMulai { get; set; }

    [Column("TanggalSelesai")]
    public DateTime? TanggalSelesai { get; set; }

    [Column("StatusProses")]
    public string? StatusProses { get; set; }

    [Column("TipeProses")]
    public string? TipeProses { get; set; }

    [Column("Catatan")]
    public string? Catatan { get; set; }

    [Column("DibuatOleh")]
    public string? DibuatOleh { get; set; }

    [Column("TanggalDibuat")]
    public DateTime? TanggalDibuat { get; set; }

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }
}
