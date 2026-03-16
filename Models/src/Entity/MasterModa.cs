namespace SnDOne.Entities;

/**
 * Entity class for "MasterModa" table
 */
[Table("MasterModa")]
public class MasterModa
{
    [Key("IdModa")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdModa { get; set; } = default!;

    [Column("NamaModa")]
    public required string NamaModa { get; set; } = default!;

    [Column("Kategori")]
    public string? Kategori { get; set; }
}
