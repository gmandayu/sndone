namespace SnDOne.Entities;

/**
 * Entity class for "MasterArea" table
 */
[Table("MasterArea")]
public class MasterArea
{
    [Key("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("Area")]
    public string? Area { get; set; }
}
