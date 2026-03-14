namespace SnDOne.Entities;

/**
 * Entity class for "Penerimaan" table
 */
[Table("Penerimaan")]
public class Penerimaan
{
    [Key("IdPenerimaan")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPenerimaan { get; set; } = default!;

    [Column("NomorPenerimaan")]
    public required string NomorPenerimaan { get; set; } = default!;

    [Column("NomorVoyage")]
    public string? NomorVoyage { get; set; }

    [Column("NomorPengiriman")]
    public string? NomorPengiriman { get; set; }

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("IdPlant")]
    public required int IdPlant { get; set; } = default!;

    [Column("TipeProdukSTS")]
    public string? TipeProdukSts { get; set; }

    [Column("KodeProduk")]
    public required string? KodeProduk { get; set; }

    [Column("ModaTransportasi")]
    public required string? ModaTransportasi { get; set; }

    [Column("NamaKapal")]
    public string? NamaKapal { get; set; }

    [Column("DetailRTW")]
    public string? DetailRtw { get; set; }

    [Column("Refinery")]
    public bool? Refinery { get; set; }

    [Column("IdPenyaluran")]
    public int? IdPenyaluran { get; set; }

    [Column("TanggalSandar")]
    public required DateTime TanggalSandar { get; set; } = default!;

    [Column("IdDermaga")]
    public int? IdDermaga { get; set; }

    [Column("StatusProses")]
    public string? StatusProses { get; set; } = "Waiting";

    [Column("PersentaseProgress")]
    public decimal? PersentaseProgress { get; set; } = 0;

    [Column("IdTemplate")]
    public int IdTemplate { get; set; } = 1;

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
