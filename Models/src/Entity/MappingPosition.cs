namespace SnDOne.Entities;

/**
 * Entity class for "MappingPosition" table
 */
[Table("MappingPosition")]
public class MappingPosition
{
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("IdPosition")]
    public required int IdPosition { get; set; } = default!;

    [Column("IdRegion")]
    public required int? IdRegion { get; set; }

    [Column("NamaRegion")]
    public string? NamaRegion { get; set; }

    [Column("IdPlant")]
    public required int IdPlant { get; set; } = default!;

    [Column("NamaPlant")]
    public string? NamaPlant { get; set; }
}
