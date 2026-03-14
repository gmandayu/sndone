namespace SnDOne.Entities;

/**
 * Entity class for "MasterPIC" table
 */
[Table("MasterPIC")]
public class MasterPic
{
    [Key("IdPIC")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPic { get; set; } = default!;

    [Column("NamaPIC")]
    public required string NamaPic { get; set; } = default!;
}
