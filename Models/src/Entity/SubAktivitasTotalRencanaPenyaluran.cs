namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasTotalRencanaPenyaluran" table
 */
[Table("SubAktivitasTotalRencanaPenyaluran")]
public class SubAktivitasTotalRencanaPenyaluran
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

    [Column("TanggalJam")]
    public DateTime? TanggalJam { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("RencanaPenyaluranKL")]
    public string? RencanaPenyaluranKl { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
