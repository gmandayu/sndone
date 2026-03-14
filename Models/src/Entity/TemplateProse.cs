namespace SnDOne.Entities;

/**
 * Entity class for "TemplateProses" table
 */
[Table("TemplateProses")]
public class TemplateProse
{
    [Key("IdTemplateProses")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTemplateProses { get; set; } = default!;

    [Column("IdTemplate")]
    public required int IdTemplate { get; set; } = default!;

    [Column("UrutanProses")]
    public required int UrutanProses { get; set; } = default!;

    [Column("NamaProses")]
    public required string NamaProses { get; set; } = default!;

    [Column("IdPIC")]
    public required int IdPic { get; set; } = default!;

    [Column("IdTools")]
    public required int IdTools { get; set; } = default!;

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

    [Column("TipeProses")]
    public string? TipeProses { get; set; }
}
