namespace SnDOne.Entities;

/**
 * Entity class for "SubaktivitasNilaiAgreement" table
 */
[Table("SubaktivitasNilaiAgreement")]
public class SubaktivitasNilaiAgreement
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

    [Column("Pressure")]
    public string? Pressure { get; set; } = "0";

    [Column("Flowrate")]
    public string? Flowrate { get; set; } = "0";

    [Column("StrippingTime")]
    public string? StrippingTime { get; set; }

    [Column("LamaPembongkaran")]
    public string? LamaPembongkaran { get; set; }

    [Column("ETC")]
    public DateTime? Etc { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }
}
