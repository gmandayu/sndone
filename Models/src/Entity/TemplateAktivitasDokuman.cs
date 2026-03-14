namespace SnDOne.Entities;

/**
 * Entity class for "TemplateAktivitasDokumen" table
 */
[Table("TemplateAktivitasDokumen")]
public class TemplateAktivitasDokuman
{
    [Key("IdTemplateAktivitasDokumen")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTemplateAktivitasDokumen { get; set; } = default!;

    [Column("IdTemplateAktivitas")]
    public required int IdTemplateAktivitas { get; set; } = default!;

    [Column("IdDokumen")]
    public required int IdDokumen { get; set; } = default!;

    [Column("WajibUpload")]
    public bool? WajibUpload { get; set; } = true;
}
