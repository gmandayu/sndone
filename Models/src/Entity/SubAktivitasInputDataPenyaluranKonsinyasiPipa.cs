namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasInputDataPenyaluranKonsinyasiPipa" table
 */
[Table("SubAktivitasInputDataPenyaluranKonsinyasiPipa")]
public class SubAktivitasInputDataPenyaluranKonsinyasiPipa
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

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("Nominasi")]
    public string? Nominasi { get; set; }

    [Column("NoUrut")]
    public string? NoUrut { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
