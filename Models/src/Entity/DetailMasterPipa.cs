namespace SnDOne.Entities;

/**
 * Entity class for "DetailMasterPipa" table
 */
[Table("DetailMasterPipa")]
public class DetailMasterPipa
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idPipa")]
    public required int? IdPipa { get; set; }

    [Column("idPlantTujuan")]
    public required int? IdPlantTujuan { get; set; }

    [Column("Panjang")]
    public string? Panjang { get; set; }

    [Column("Diameter")]
    public string? Diameter { get; set; }

    [Column("Volume")]
    public string? Volume { get; set; }

    [Column("CreatedBy")]
    public string? CreatedBy { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("LastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
