namespace SnDOne.Entities;

/**
 * Entity class for "SetUserMOD" table
 */
[Table("SetUserMOD")]
public class SetUserMod
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("Plant")]
    public required int? Plant { get; set; }

    [Column("LookupUserMod")]
    public required int? LookupUserMod { get; set; }

    [Column("UserMOD")]
    public required int? UserMod { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
