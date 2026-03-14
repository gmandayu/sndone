namespace SnDOne.Entities;

/**
 * Entity class for "MasterPosition" table
 */
[Table("MasterPosition")]
public class MasterPosition
{
    [Key("IdPosition")]
    public required int IdPosition { get; set; } = default!;

    [Column("NamaPosition")]
    public required string NamaPosition { get; set; } = default!;

    [Column("Location")]
    public string? Location { get; set; }

    [Column("UserLevel")]
    public required int? UserLevel { get; set; }

    [Column("Role")]
    public required int? Role { get; set; }
}
