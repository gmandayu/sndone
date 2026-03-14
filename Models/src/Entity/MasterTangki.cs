namespace SnDOne.Entities;

/**
 * Entity class for "MasterTangki" table
 */
[Table("MasterTangki")]
public class MasterTangki
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NamaTerminal")]
    public string? NamaTerminal { get; set; }

    [Column("Plant")]
    public string? Plant { get; set; }

    [Column("Sloc")]
    public string? Sloc { get; set; }

    [Column("SeqTangki")]
    public string? SeqTangki { get; set; }

    [Column("MatNo")]
    public string? MatNo { get; set; }

    [Column("TglKalibrasi")]
    public DateTime? TglKalibrasi { get; set; }

    [Column("ExpDate")]
    public DateTime? ExpDate { get; set; }

    [Column("Status")]
    public string? Status { get; set; }

    [Column("TinggiMejaUk")]
    public string? TinggiMejaUk { get; set; }

    [Column("MaxDipping")]
    public string? MaxDipping { get; set; }

    [Column("MaxCapacity")]
    public string? MaxCapacity { get; set; }

    [Column("UnpumpableQty")]
    public string? UnpumpableQty { get; set; }

    [Column("PumpableQty")]
    public string? PumpableQty { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
