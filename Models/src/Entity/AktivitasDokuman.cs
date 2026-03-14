namespace SnDOne.Entities;

/**
 * Entity class for "AktivitasDokumen" table
 */
[Table("AktivitasDokumen")]
public class AktivitasDokuman
{
    [Key("IdAktivitasDokumen")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAktivitasDokumen { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("IdProses")]
    public int? IdProses { get; set; }

    [Column("IdAktivitas")]
    public int? IdAktivitas { get; set; }

    [Column("IdDokumen")]
    public int? IdDokumen { get; set; }

    [Column("NamaDokumen")]
    public string? NamaDokumen { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("PathFile")]
    public string? PathFile { get; set; }

    [Column("StatusUpload")]
    public string? StatusUpload { get; set; }

    [Column("DiunggahOleh")]
    public string? DiunggahOleh { get; set; }

    [Column("TanggalUpload")]
    public DateTime? TanggalUpload { get; set; }

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }

    [Column("IdTemplateAktivitasDokumen")]
    public int? IdTemplateAktivitasDokumen { get; set; }

    [Column("WajibUpload")]
    public bool? WajibUpload { get; set; }

    [Column("TipeProses")]
    public string? TipeProses { get; set; }
}
