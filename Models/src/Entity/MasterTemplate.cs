namespace SnDOne.Entities;

/**
 * Entity class for "MasterTemplate" table
 */
[Table("MasterTemplate")]
public class MasterTemplate
{
    [Key("IdTemplate")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTemplate { get; set; } = default!;

    [Column("NamaTemplate")]
    public required string NamaTemplate { get; set; } = default!;

    [Column("IdModa")]
    public int? IdModa { get; set; }

    [Column("JenisProses")]
    public string? JenisProses { get; set; }

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

    [Column("TipePenimbunan")]
    public string? TipePenimbunan { get; set; }

    [Column("TipePenyaluran")]
    public string? TipePenyaluran { get; set; }

    [Column("KategoriPenyaluran")]
    public string? KategoriPenyaluran { get; set; }

    [Column("NamaDokumen")]
    public string? NamaDokumen { get; set; }
}
