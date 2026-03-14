namespace SnDOne.Entities;

/**
 * Entity class for "MWTOnlineDetail" table
 */
[Table("MWTOnlineDetail")]
public class MwtonlineDetail
{
    [Key("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("Penjelasan")]
    public string? Penjelasan { get; set; }

    [Column("UploadEvidence")]
    public string? UploadEvidence { get; set; }

    [Column("CreatedDate")]
    public DateTime? CreatedDate { get; set; }

    [Column("CreatedBy")]
    public string? CreatedBy { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("LastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("StatusEmail")]
    public string? StatusEmail { get; set; }

    [Column("FileType")]
    public string? FileType { get; set; }

    [Column("OriginalFileName")]
    public string? OriginalFileName { get; set; }

    [Column("Flag")]
    public string? Flag { get; set; }
}
