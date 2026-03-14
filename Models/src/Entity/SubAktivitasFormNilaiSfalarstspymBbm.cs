namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormNilaiSFALARSTSPymBBM" table
 */
[Table("SubAktivitasFormNilaiSFALARSTSPymBBM")]
public class SubAktivitasFormNilaiSfalarstspymBbm
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

    [Column("SFAL_klobs")]
    public string? SfalKlobs { get; set; }

    [Column("SFAL_kl15")]
    public string? SfalKl15 { get; set; }

    [Column("SFAL_barrels")]
    public string? SfalBarrels { get; set; }

    [Column("SFAL_lt")]
    public string? SfalLt { get; set; }

    [Column("SFAL_mt")]
    public string? SfalMt { get; set; }

    [Column("AR_klobs")]
    public string? ArKlobs { get; set; }

    [Column("AR_kl15")]
    public string? ArKl15 { get; set; }

    [Column("AR_barrels")]
    public string? ArBarrels { get; set; }

    [Column("AR_lt")]
    public string? ArLt { get; set; }

    [Column("AR_mt")]
    public string? ArMt { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }
}
