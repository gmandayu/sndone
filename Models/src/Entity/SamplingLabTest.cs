namespace SnDOne.Entities;

/**
 * Entity class for "SamplingLabTest" table
 */
[Table("SamplingLabTest")]
public class SamplingLabTest
{
    [Key("IdSamplingLabTest")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdSamplingLabTest { get; set; } = default!;

    [Column("NomorSamplingLabTest")]
    public required string NomorSamplingLabTest { get; set; } = default!;

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("IdPlant")]
    public required int? IdPlant { get; set; }

    [Column("IdReferensi")]
    public required string? IdReferensi { get; set; }

    [Column("IdPenimbunan")]
    public int? IdPenimbunan { get; set; }

    [Column("IdTemplate")]
    public int IdTemplate { get; set; } = 27;

    [Column("StatusProses")]
    public string? StatusProses { get; set; } = "Waiting";

    [Column("PersentaseProgress")]
    public decimal? PersentaseProgress { get; set; }

    [Column("IdModa")]
    public int? IdModa { get; set; }

    [Column("TipePenyaluran")]
    public string? TipePenyaluran { get; set; }

    [Column("KategoriPenyaluran")]
    public string? KategoriPenyaluran { get; set; } = "Non TAS/NGS";

    [Column("NomorPolisi")]
    public string? NomorPolisi { get; set; }

    [Column("TipeProdukSTS")]
    public string? TipeProdukSts { get; set; }

    [Column("KodeProduk")]
    public required string? KodeProduk { get; set; }

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
