namespace SnDOne.Entities;

/**
 * Entity class for "MasterProduk" table
 */
[Table("MasterProduk")]
public class MasterProduk
{
    [Key("NoProduk")]
    public required string NoProduk { get; set; } = default!;

    [Column("NamaProduk")]
    public required string? NamaProduk { get; set; }

    [Column("TipeProduk")]
    public required string? TipeProduk { get; set; }

    [Column("DensityMin")]
    public string? DensityMin { get; set; }

    [Column("DensityMax")]
    public string? DensityMax { get; set; }
}
