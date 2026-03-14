namespace SnDOne.Entities;

/**
 * Entity class for "ControlRutinSecurity" table
 */
[Table("ControlRutinSecurity")]
public class ControlRutinSecurity
{
    [Key("IdCRS")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCrs { get; set; } = default!;

    [Column("NomorCRS")]
    public required string NomorCrs { get; set; } = default!;

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("Plant")]
    public int? Plant { get; set; }

    [Column("JumlahKetidaksesuaiaan")]
    public required int JumlahKetidaksesuaiaan { get; set; } = default!;

    [Column("Catatan")]
    public string? Catatan { get; set; }

    [Column("DibuatOleh")]
    public required string DibuatOleh { get; set; } = default!;

    [Column("TanggalDibuat")]
    public required DateTime TanggalDibuat { get; set; } = default!;

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }
}
