namespace SnDOne.Entities;

/**
 * Entity class for "SubaktivitasInputHasilPemeriksaanPipa" table
 */
[Table("SubaktivitasInputHasilPemeriksaanPipa")]
public class SubaktivitasInputHasilPemeriksaanPipa
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("TanggalJam")]
    public DateTime? TanggalJam { get; set; }

    [Column("NamaKegiatan")]
    public string? NamaKegiatan { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Density")]
    public string? Density { get; set; }

    [Column("Temperature")]
    public string? Temperature { get; set; }

    [Column("Pressure")]
    public string? Pressure { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("QuantityDischarge")]
    public string? QuantityDischarge { get; set; }

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
}
