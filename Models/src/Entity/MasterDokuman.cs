namespace SnDOne.Entities;

/**
 * Entity class for "MasterDokumen" table
 */
[Table("MasterDokumen")]
public class MasterDokuman
{
    [Key("IdDokumen")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDokumen { get; set; } = default!;

    [Column("NamaDokumen")]
    public required string NamaDokumen { get; set; } = default!;
}
