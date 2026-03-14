namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasLogbookPenerimaanPenyaluran" table
 */
[Table("SubAktivitasLogbookPenerimaanPenyaluran")]
public class SubAktivitasLogbookPenerimaanPenyaluran
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("LO")]
    public string? Lo { get; set; }

    [Column("NomorTangki")]
    public string? NomorTangki { get; set; }

    [Column("MeterAwal")]
    public string? MeterAwal { get; set; }

    [Column("MeterAkhir")]
    public string? MeterAkhir { get; set; }

    [Column("Volume")]
    public string? Volume { get; set; }

    [Column("BayNumber")]
    public string? BayNumber { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("NomorKompartment")]
    public string? NomorKompartment { get; set; }

    [Column("InLineBlending")]
    public bool? InLineBlending { get; set; }

    [Column("NomorTangki2")]
    public string? NomorTangki2 { get; set; }

    [Column("NoMeter")]
    public string? NoMeter { get; set; }
}
