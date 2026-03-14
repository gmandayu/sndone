namespace SnDOne.Entities;

/**
 * Entity class for "Penyaluran" table
 */
[Table("Penyaluran")]
public class Penyaluran
{
    [Key("IdPenyaluran")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPenyaluran { get; set; } = default!;

    [Column("NomorPenyaluran")]
    public required string NomorPenyaluran { get; set; } = default!;

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("IdPlant")]
    public int? IdPlant { get; set; }

    [Column("TipePenyaluran")]
    public string? TipePenyaluran { get; set; }

    [Column("TipeProdukSTS")]
    public string? TipeProdukSts { get; set; }

    [Column("KategoriPenyaluran")]
    public string? KategoriPenyaluran { get; set; }

    [Column("IdModa")]
    public int? IdModa { get; set; }

    [Column("DetailRTW")]
    public string? DetailRtw { get; set; }

    [Column("NoShipment")]
    public string? NoShipment { get; set; }

    [Column("IdPipa")]
    public int? IdPipa { get; set; }

    [Column("NomorPolisi")]
    public string? NomorPolisi { get; set; }

    [Column("NamaKapal")]
    public string? NamaKapal { get; set; }

    [Column("JenisProduk")]
    public string? JenisProduk { get; set; }

    [Column("IdPenimbunan")]
    public int? IdPenimbunan { get; set; }

    [Column("StatusProses")]
    public string? StatusProses { get; set; } = "Waiting";

    [Column("IdTemplate")]
    public int IdTemplate { get; set; } = 8;

    [Column("PersentaseProgress")]
    public decimal? PersentaseProgress { get; set; } = 0;

    [Column("Tujuan")]
    public string? Tujuan { get; set; }

    [Column("TujuanKonsinyasi")]
    public int? TujuanKonsinyasi { get; set; }

    [Column("Volume")]
    public decimal? Volume { get; set; }

    [Column("TujuanKonsinyasi2")]
    public int? TujuanKonsinyasi2 { get; set; }

    [Column("Volume2")]
    public decimal? Volume2 { get; set; }

    [Column("TujuanKonsinyasi3")]
    public int? TujuanKonsinyasi3 { get; set; }

    [Column("Volume3")]
    public decimal? Volume3 { get; set; }

    [Column("TanggalSandar")]
    public DateTime? TanggalSandar { get; set; }

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
