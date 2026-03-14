namespace SnDOne.Entities;

/**
 * Entity class for "PenyimpananSample" table
 */
[Table("PenyimpananSample")]
public class PenyimpananSample
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NomorPenyimpananSample")]
    public string? NomorPenyimpananSample { get; set; }

    [Column("JenisSample")]
    public string? JenisSample { get; set; }

    [Column("IdPlant")]
    public int? IdPlant { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("NamaMasterSample")]
    public string? NamaMasterSample { get; set; }

    [Column("NomorSegel")]
    public string? NomorSegel { get; set; }

    [Column("Status")]
    public string? Status { get; set; }

    [Column("Foto")]
    public string? Foto { get; set; }

    [Column("ExpiredEst")]
    public DateTime? ExpiredEst { get; set; }

    [Column("TanggalDimusnahkan")]
    public DateTime? TanggalDimusnahkan { get; set; }

    [Column("LokasiPemusnahan")]
    public string? LokasiPemusnahan { get; set; }

    [Column("CreatedBy")]
    public string? CreatedBy { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
