namespace SnDOne.Entities;

/**
 * Entity class for "SubAkivitasNilaiAktualDischargePipa" table
 */
[Table("SubAkivitasNilaiAktualDischargePipa")]
public class SubAkivitasNilaiAktualDischargePipa
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("idAktifitas")]
    public int? IdAktifitas { get; set; }

    [Column("AktualDischarge_klobs")]
    public string? AktualDischargeKlobs { get; set; }

    [Column("AktualDischarge_kl15")]
    public string? AktualDischargeKl15 { get; set; }

    [Column("AktualDischarge_barrels")]
    public string? AktualDischargeBarrels { get; set; }

    [Column("AktualDischarge_lt")]
    public string? AktualDischargeLt { get; set; }

    [Column("AktualDischarge_mt")]
    public string? AktualDischargeMt { get; set; }

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
