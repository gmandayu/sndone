namespace SnDOne.Entities;

/**
 * Entity class for "RencanaPenyaluran" table
 */
[Table("RencanaPenyaluran")]
public class RencanaPenyaluran
{
    [Key("IdRencanaPenyaluran")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRencanaPenyaluran { get; set; } = default!;

    [Column("NomorRencanaPenyaluran")]
    public required string NomorRencanaPenyaluran { get; set; } = default!;

    [Column("IdPenimbunan")]
    public int? IdPenimbunan { get; set; }

    [Column("IdTemplate")]
    public int IdTemplate { get; set; } = 26;

    [Column("StatusProses")]
    public string? StatusProses { get; set; } = "Waiting";

    [Column("PersentaseProgress")]
    public decimal? PersentaseProgress { get; set; }

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("IdPlant")]
    public required int? IdPlant { get; set; }

    [Column("TipeProdukSTS")]
    public string? TipeProdukSts { get; set; }

    [Column("IdModa")]
    public string? IdModa { get; set; }

    [Column("TipePenyaluran")]
    public string? TipePenyaluran { get; set; }

    [Column("KategoriPenyaluran")]
    public string? KategoriPenyaluran { get; set; } = "Non TAS/NGS";

    [Column("Tujuan")]
    public string? Tujuan { get; set; }

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
