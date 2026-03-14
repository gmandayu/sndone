namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputLogbookPenerimaanRTW" table
 */
[Table("SubAktivitasFormInputLogbookPenerimaanRTW")]
public class SubAktivitasFormInputLogbookPenerimaanRtw
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("NamaKegiatan")]
    public string? NamaKegiatan { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Density")]
    public string? Density { get; set; }

    [Column("Temperature")]
    public string? Temperature { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("Level")]
    public string? Level { get; set; }

    [Column("Volume")]
    public string? Volume { get; set; }

    [Column("Flowrate")]
    public string? Flowrate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("SubAktivitasFormInputHslPemeriksaanRTWId")]
    public int? SubAktivitasFormInputHslPemeriksaanRtwid { get; set; }

    [Column("TanggalJamSOP")]
    public DateTime? TanggalJamSop { get; set; }

    [Column("SelisihWaktu")]
    public string? SelisihWaktu { get; set; }

    [Column("IsQualityActive")]
    public bool IsQualityActive { get; set; } = default!;
}
