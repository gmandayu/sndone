namespace SnDOne.Entities;

/**
 * Entity class for "MasterTools" table
 */
[Table("MasterTools")]
public class MasterTool
{
    [Key("IdTools")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTools { get; set; } = default!;

    [Column("NamaTools")]
    public required string NamaTools { get; set; } = default!;
}
