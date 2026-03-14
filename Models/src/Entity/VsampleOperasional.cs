namespace SnDOne.Entities;

/**
 * Entity class for "VSampleOperasional" table
 */
[Table("VSampleOperasional")]
public class VsampleOperasional
{
    [Column("NoReferensi")]
    public required string NoReferensi { get; set; } = default!;

    [Column("Proses")]
    public required string Proses { get; set; } = default!;

    [Column("Plant")]
    public required string Plant { get; set; } = default!;

    [Column("Moda")]
    public string? Moda { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("NamaDokumen")]
    public string? NamaDokumen { get; set; }

    [Column("IdAktivitasDokumen")]
    public required int IdAktivitasDokumen { get; set; } = default!;

    [Column("StatusUpload")]
    public string? StatusUpload { get; set; }

    [Column("StatusPrevProses")]
    public string? StatusPrevProses { get; set; }
}
