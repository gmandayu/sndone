namespace SnDOne.Entities;

/**
 * Entity class for "FormInputProofOfVisit" table
 */
[Table("FormInputProofOfVisit")]
public class FormInputProofOfVisit
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("Lokasi")]
    public string? Lokasi { get; set; }

    [Column("UploadFoto")]
    public string? UploadFoto { get; set; }

    [Column("Ketidaksesuaiaan")]
    public string? Ketidaksesuaiaan { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("IdPosition")]
    public int? IdPosition { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("lastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("VerifikasiMOD")]
    public string? VerifikasiMod { get; set; }
}
