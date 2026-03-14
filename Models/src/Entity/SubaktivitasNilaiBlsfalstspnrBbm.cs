namespace SnDOne.Entities;

/**
 * Entity class for "SubaktivitasNilaiBLSFALSTSPnrBBM" table
 */
[Table("SubaktivitasNilaiBLSFALSTSPnrBBM")]
public class SubaktivitasNilaiBlsfalstspnrBbm
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("BL_klobs")]
    public string? BlKlobs { get; set; }

    [Column("BL_kl15")]
    public string? BlKl15 { get; set; }

    [Column("BL_barrels")]
    public string? BlBarrels { get; set; }

    [Column("BL_lt")]
    public string? BlLt { get; set; }

    [Column("BL_mt")]
    public string? BlMt { get; set; }

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

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("idProses")]
    public int? IdProses { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }
}
