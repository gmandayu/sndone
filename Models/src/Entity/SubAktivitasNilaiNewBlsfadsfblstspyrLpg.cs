namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG" table
 */
[Table("SubAktivitasNilaiNewBLSFADSFBLSTSPyrLPG")]
public class SubAktivitasNilaiNewBlsfadsfblstspyrLpg
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

    [Column("NewBL_MT")]
    public string? NewBlMt { get; set; }

    [Column("SFAD_MT")]
    public string? SfadMt { get; set; }

    [Column("SFBL_MT")]
    public string? SfblMt { get; set; }

    [Column("ExROB")]
    public bool? ExRob { get; set; }

    [Column("NoPenerimaan")]
    public string? NoPenerimaan { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
