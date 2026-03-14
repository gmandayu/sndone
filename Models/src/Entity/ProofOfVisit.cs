namespace SnDOne.Entities;

/**
 * Entity class for "ProofOfVisit" table
 */
[Table("ProofOfVisit")]
public class ProofOfVisit
{
    [Key("IdProofOfVisit")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdProofOfVisit { get; set; } = default!;

    [Column("NomorProofOfVisit")]
    public string? NomorProofOfVisit { get; set; }

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("Plant")]
    public required int? Plant { get; set; }

    [Column("JumlahKetidaksesuaiaan")]
    public string? JumlahKetidaksesuaiaan { get; set; }

    [Column("TotalPengisian")]
    public string? TotalPengisian { get; set; }

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
