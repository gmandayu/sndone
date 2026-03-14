namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputNilaiAktDischargeRTW" table
 */
[Table("SubAktivitasFormInputNilaiAktDischargeRTW")]
public class SubAktivitasFormInputNilaiAktDischargeRtw
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("Import")]
    public bool? Import { get; set; }

    [Column("ApakahAdaROB")]
    public bool? ApakahAdaRob { get; set; }

    [Column("Tujuan")]
    public int? Tujuan { get; set; }

    [Column("SFAD_KLObs")]
    public string? SfadKlobs { get; set; }

    [Column("SFAD_KL15")]
    public string? SfadKl15 { get; set; }

    [Column("SFAD_Barrels")]
    public string? SfadBarrels { get; set; }

    [Column("SFAD_LT")]
    public string? SfadLt { get; set; }

    [Column("SFAD_MT")]
    public string? SfadMt { get; set; }

    [Column("NewBL_KLObs")]
    public string? NewBlKlobs { get; set; }

    [Column("NewBL_KL15")]
    public string? NewBlKl15 { get; set; }

    [Column("NewBL_Barrels")]
    public string? NewBlBarrels { get; set; }

    [Column("NewBL_LT")]
    public string? NewBlLt { get; set; }

    [Column("NewBL_MT")]
    public string? NewBlMt { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("AR45B_klobs")]
    public string? Ar45BKlobs { get; set; }

    [Column("AR45B_kl15")]
    public string? Ar45BKl15 { get; set; }

    [Column("AR45B_Barrel")]
    public string? Ar45BBarrel { get; set; }

    [Column("AR45B_lt")]
    public string? Ar45BLt { get; set; }

    [Column("AR45B_mt")]
    public string? Ar45BMt { get; set; }
}
