namespace SnDOne.Entities;

/**
 * Entity class for "Penimbunan" table
 */
[Table("Penimbunan")]
public class Penimbunan
{
    [Key("IdPenimbunan")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPenimbunan { get; set; } = default!;

    [Column("NomorPenimbunan")]
    public required string NomorPenimbunan { get; set; } = default!;

    [Column("IdTemplate")]
    public int IdTemplate { get; set; } = 7;

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("Plant")]
    public required string? Plant { get; set; }

    [Column("TipeProdukSTS")]
    public string? TipeProdukSts { get; set; }

    [Column("IdPenerimaan")]
    public required int? IdPenerimaan { get; set; }

    [Column("IdTangki")]
    public required int? IdTangki { get; set; }

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
