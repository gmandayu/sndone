namespace SnDOne.Entities;

/**
 * Entity class for "ClosingStock" table
 */
[Table("ClosingStock")]
public class ClosingStock
{
    [Key("IdClosingStock")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdClosingStock { get; set; } = default!;

    [Column("IdTemplate")]
    public int IdTemplate { get; set; } = 30;

    [Column("NomorClosingStock")]
    public required string NomorClosingStock { get; set; } = default!;

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("Plant")]
    public required string? Plant { get; set; }

    [Column("TipeProdukSTS")]
    public string? TipeProdukSts { get; set; }

    [Column("IdTangki")]
    public required int? IdTangki { get; set; }

    [Column("TanggalClosingStock")]
    public DateTime? TanggalClosingStock { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("StatusProses")]
    public string? StatusProses { get; set; } = "Waiting";

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
