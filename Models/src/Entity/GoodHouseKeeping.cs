namespace SnDOne.Entities;

/**
 * Entity class for "GoodHouseKeeping" table
 */
[Table("GoodHouseKeeping")]
public class GoodHouseKeeping
{
    [Key("IdGoodHouseKeeping")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdGoodHouseKeeping { get; set; } = default!;

    [Column("NomorGoodHouseKeeping")]
    public string? NomorGoodHouseKeeping { get; set; }

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("Plant")]
    public required int? Plant { get; set; }

    [Column("Catatan")]
    public string? Catatan { get; set; }

    [Column("DibuatOleh")]
    public string? DibuatOleh { get; set; }

    [Column("TanggalDibuat")]
    public DateTime? TanggalDibuat { get; set; }

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }
}
