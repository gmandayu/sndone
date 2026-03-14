namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasSFADNewBL" table
 */
[Table("SubAktivitasSFADNewBL")]
public class SubAktivitasSfadnewBl
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("ApakahAdaROB")]
    public string? ApakahAdaRob { get; set; }

    [Column("Import")]
    public bool? Import { get; set; }

    [Column("ApakahTerdapatROB")]
    public bool? ApakahTerdapatRob { get; set; }

    [Column("Tujuan")]
    public int? Tujuan { get; set; }

    [Column("SFAD_klobs")]
    public string? SfadKlobs { get; set; }

    [Column("SFAD_kl15")]
    public string? SfadKl15 { get; set; }

    [Column("SFAD_barrels")]
    public string? SfadBarrels { get; set; }

    [Column("SFAD_lt")]
    public string? SfadLt { get; set; }

    [Column("SFAD_mt")]
    public string? SfadMt { get; set; }

    [Column("NewBl_klobs")]
    public string? NewBlKlobs { get; set; }

    [Column("NewBl_kl15")]
    public string? NewBlKl15 { get; set; }

    [Column("NewBl_barrels")]
    public string? NewBlBarrels { get; set; }

    [Column("NewBl_lt")]
    public string? NewBlLt { get; set; }

    [Column("NewBl_mt")]
    public string? NewBlMt { get; set; }

    [Column("AR45B_klobs")]
    public string? Ar45BKlobs { get; set; }

    [Column("AR45B_kl15")]
    public string? Ar45BKl15 { get; set; }

    [Column("AR45B_barrels")]
    public string? Ar45BBarrels { get; set; }

    [Column("AR45B_lt")]
    public string? Ar45BLt { get; set; }

    [Column("AR45B_mt")]
    public string? Ar45BMt { get; set; }
}
