namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasSFADNewBLSTSLPG" table
 */
[Table("SubAktivitasSFADNewBLSTSLPG")]
public class SubAktivitasSfadnewBlstslpg
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

    [Column("ApakahTerdapatROB")]
    public bool? ApakahTerdapatRob { get; set; }

    [Column("Import")]
    public bool? Import { get; set; }

    [Column("Tujuan")]
    public int? Tujuan { get; set; }

    [Column("ApakahAdaROB")]
    public string? ApakahAdaRob { get; set; }

    [Column("SFAD_mt")]
    public string? SfadMt { get; set; }

    [Column("NewBl_mt")]
    public string? NewBlMt { get; set; }

    [Column("AR45B_mt")]
    public string? Ar45BMt { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
