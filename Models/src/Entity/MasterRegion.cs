namespace SnDOne.Entities;

/**
 * Entity class for "MasterRegion" table
 */
[Table("MasterRegion")]
public class MasterRegion
{
    [Key("IdRegion")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRegion { get; set; } = default!;

    [Column("Region")]
    public required string Region { get; set; } = default!;

    [Column("RegionCode")]
    public string? RegionCode { get; set; }
}
