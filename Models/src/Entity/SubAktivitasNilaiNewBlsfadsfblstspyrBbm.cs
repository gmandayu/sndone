namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM" table
 */
[Table("SubAktivitasNilaiNewBLSFADSFBLSTSPyrBBM")]
public class SubAktivitasNilaiNewBlsfadsfblstspyrBbm
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

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

    [Column("SFBL_KLObs")]
    public string? SfblKlobs { get; set; }

    [Column("SFBL_KL15")]
    public string? SfblKl15 { get; set; }

    [Column("SFBL_Barrels")]
    public string? SfblBarrels { get; set; }

    [Column("SFBL_LT")]
    public string? SfblLt { get; set; }

    [Column("SFBL_MT")]
    public string? SfblMt { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("ExROB")]
    public bool? ExRob { get; set; }

    [Column("NoPenerimaan")]
    public string? NoPenerimaan { get; set; }
}
