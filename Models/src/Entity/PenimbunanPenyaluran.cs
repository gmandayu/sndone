namespace SnDOne.Entities;

/**
 * Entity class for "PenimbunanPenyaluran" table
 */
[Table("PenimbunanPenyaluran")]
public class PenimbunanPenyaluran
{
    [Key("IdPenimbunanPenyaluran")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPenimbunanPenyaluran { get; set; } = default!;

    [Column("NomorPenimbunanPenyaluran")]
    public required string NomorPenimbunanPenyaluran { get; set; } = default!;

    [Column("IdTemplate")]
    public int IdTemplate { get; set; } = 29;

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("Plant")]
    public required string? Plant { get; set; }

    [Column("TipeProdukSTS")]
    public string? TipeProdukSts { get; set; }

    [Column("TipePenyaluran")]
    public required string? TipePenyaluran { get; set; }

    [Column("JenisProduk")]
    public string? JenisProduk { get; set; }

    [Column("IdModa")]
    public required int? IdModa { get; set; }

    [Column("IdTangki")]
    public required int? IdTangki { get; set; }

    [Column("StatusProses")]
    public string? StatusProses { get; set; } = "Waiting";

    [Column("NoPenyaluran")]
    public string? NoPenyaluran { get; set; }

    [Column("PersentaseProgress")]
    public decimal? PersentaseProgress { get; set; }

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
