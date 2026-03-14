namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasHasilPemeriksaanPipa" table
 */
[Table("SubAktivitasHasilPemeriksaanPipa")]
public class SubAktivitasHasilPemeriksaanPipa
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

    [Column("NoBatch")]
    public string? NoBatch { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("Nama_Kegiatan")]
    public string? NamaKegiatan { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Density")]
    public string? Density { get; set; }

    [Column("Temperature")]
    public string? Temperature { get; set; }

    [Column("Pressure")]
    public string? Pressure { get; set; }

    [Column("VolumeDischarge")]
    public string? VolumeDischarge { get; set; }

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

    [Column("TotalTerima")]
    public string? TotalTerima { get; set; }

    [Column("ETC")]
    public DateTime? Etc { get; set; }

    [Column("ETA")]
    public DateTime? Eta { get; set; }

    [Column("ETA2")]
    public DateTime? Eta2 { get; set; }

    [Column("ETA3")]
    public DateTime? Eta3 { get; set; }
}
