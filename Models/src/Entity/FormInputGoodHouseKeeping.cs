namespace SnDOne.Entities;

/**
 * Entity class for "FormInputGoodHouseKeeping" table
 */
[Table("FormInputGoodHouseKeeping")]
public class FormInputGoodHouseKeeping
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("tgltiba")]
    public DateTime? Tgltiba { get; set; }

    [Column("Lokasi")]
    public string? Lokasi { get; set; }

    [Column("UploadFoto")]
    public string? UploadFoto { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("lastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
