namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasLogbookPenerimaanSTSPymLPG" table
 */
[Table("SubAktivitasLogbookPenerimaanSTSPymLPG")]
public class SubAktivitasLogbookPenerimaanStspymLpg
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("Nama_Kapal")]
    public string? NamaKapal { get; set; }

    [Column("TanggalJam")]
    public DateTime? TanggalJam { get; set; }

    [Column("Nama_Kegiatan")]
    public string? NamaKegiatan { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Density")]
    public string? Density { get; set; }

    [Column("Temperatur")]
    public string? Temperatur { get; set; }

    [Column("Level")]
    public string? Level { get; set; }

    [Column("Volume")]
    public string? Volume { get; set; }

    [Column("Flowrate")]
    public string? Flowrate { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("SubAktivitasHasilPemeriksaanId")]
    public int? SubAktivitasHasilPemeriksaanId { get; set; }

    [Column("TanggalJamSOP")]
    public DateTime? TanggalJamSop { get; set; }

    [Column("SelisihWaktu")]
    public string? SelisihWaktu { get; set; }

    [Column("IsQualityActive")]
    public bool IsQualityActive { get; set; } = default!;
}
