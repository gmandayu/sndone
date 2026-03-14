namespace SnDOne.Entities;

/**
 * Entity class for "SubaktivitasRencanaPenyaluranPipa" table
 */
[Table("SubaktivitasRencanaPenyaluranPipa")]
public class SubaktivitasRencanaPenyaluranPipa
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("TanggalJam")]
    public DateTime? TanggalJam { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }

    [Column("RencanaPenyaluran")]
    public string? RencanaPenyaluran { get; set; }

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
