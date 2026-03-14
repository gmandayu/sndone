namespace SnDOne.Entities;

/**
 * Entity class for "MasterFungsiKunjungan" table
 */
[Table("MasterFungsiKunjungan")]
public class MasterFungsiKunjungan
{
    [Key("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("FungsiKunjungan")]
    public string? FungsiKunjungan { get; set; }
}
