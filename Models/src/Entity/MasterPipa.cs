namespace SnDOne.Entities;

/**
 * Entity class for "MasterPipa" table
 */
[Table("MasterPipa")]
public class MasterPipa
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("KeteranganPipa")]
    public required string KeteranganPipa { get; set; } = default!;

    [Column("idPlantAsal")]
    public int? IdPlantAsal { get; set; }

    [Column("idPlantTujuan")]
    public int? IdPlantTujuan { get; set; }

    [Column("Panjang")]
    public decimal? Panjang { get; set; }

    [Column("Diameter")]
    public decimal? Diameter { get; set; }

    [Column("Volume")]
    public decimal? Volume { get; set; }

    [Column("Flowrate")]
    public decimal? Flowrate { get; set; }

    [Column("idPlantTujuan2")]
    public int? IdPlantTujuan2 { get; set; }

    [Column("Panjang2")]
    public decimal? Panjang2 { get; set; }

    [Column("Diameter2")]
    public decimal? Diameter2 { get; set; }

    [Column("Volume2")]
    public decimal? Volume2 { get; set; }

    [Column("Flowrate2")]
    public decimal? Flowrate2 { get; set; }

    [Column("idPlantTujuan3")]
    public int? IdPlantTujuan3 { get; set; }

    [Column("Panjang3")]
    public decimal? Panjang3 { get; set; }

    [Column("Diameter3")]
    public decimal? Diameter3 { get; set; }

    [Column("Volume3")]
    public decimal? Volume3 { get; set; }

    [Column("Flowrate3")]
    public decimal? Flowrate3 { get; set; }

    [Column("BiayaProject")]
    public decimal? BiayaProject { get; set; }

    [Column("PlantAsal")]
    public string? PlantAsal { get; set; }

    [Column("NamaPlantAsal")]
    public string? NamaPlantAsal { get; set; }

    [Column("PlantTujuan")]
    public string? PlantTujuan { get; set; }

    [Column("NamaPlantTujuan")]
    public string? NamaPlantTujuan { get; set; }

    [Column("PlantTujuan2")]
    public string? PlantTujuan2 { get; set; }

    [Column("NamaPlantTujuan2")]
    public string? NamaPlantTujuan2 { get; set; }

    [Column("PlantTujuan3")]
    public string? PlantTujuan3 { get; set; }

    [Column("NamaPlantTujuan3")]
    public string? NamaPlantTujuan3 { get; set; }

    [Column("CreatedBy")]
    public required string CreatedBy { get; set; } = default!;

    [Column("etlDate")]
    public required DateTime EtlDate { get; set; } = default!;

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("LastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
