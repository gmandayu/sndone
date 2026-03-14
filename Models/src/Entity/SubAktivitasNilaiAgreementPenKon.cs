namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiAgreementPenKon" table
 */
[Table("SubAktivitasNilaiAgreementPenKon")]
public class SubAktivitasNilaiAgreementPenKon
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

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("Flowrate")]
    public string? Flowrate { get; set; }

    [Column("Pressure")]
    public string? Pressure { get; set; }

    [Column("StrippingTime")]
    public string? StrippingTime { get; set; }

    [Column("ETC")]
    public DateTime? Etc { get; set; }

    [Column("LamaPembongkaran")]
    public string? LamaPembongkaran { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
