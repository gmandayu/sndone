namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiBDperGerbong" table
 */
[Table("SubAktivitasNilaiBDperGerbong")]
public class SubAktivitasNilaiBdperGerbong
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("NomorGerbongKertel")]
    public string? NomorGerbongKertel { get; set; }

    [Column("KL_Obs")]
    public string? KlObs { get; set; }

    [Column("KL_15")]
    public string? Kl15 { get; set; }

    [Column("Barrels")]
    public string? Barrels { get; set; }

    [Column("LT")]
    public string? Lt { get; set; }

    [Column("MT")]
    public string? Mt { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("Produk")]
    public string? Produk { get; set; }
}
