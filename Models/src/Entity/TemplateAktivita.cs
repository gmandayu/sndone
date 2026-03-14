namespace SnDOne.Entities;

/**
 * Entity class for "TemplateAktivitas" table
 */
[Table("TemplateAktivitas")]
public class TemplateAktivita
{
    [Key("IdTemplateAktivitas")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTemplateAktivitas { get; set; } = default!;

    [Column("IdTemplateProses")]
    public required int IdTemplateProses { get; set; } = default!;

    [Column("UrutanAktivitas")]
    public required int UrutanAktivitas { get; set; } = default!;

    [Column("NamaAktivitas")]
    public required string NamaAktivitas { get; set; } = default!;

    [Column("IdPIC")]
    public required string IdPic { get; set; } = default!;

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

    [Column("TipeAktivitas")]
    public string? TipeAktivitas { get; set; }

    [Column("URL")]
    public string? Url { get; set; }
}
