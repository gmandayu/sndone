namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasFormInputFlowrateRTW" table
 */
[Table("SubAktivitasFormInputFlowrateRTW")]
public class SubAktivitasFormInputFlowrateRtw
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

    [Column("Flowrate")]
    public string? Flowrate { get; set; }

    [Column("StrippingTime")]
    public string? StrippingTime { get; set; }

    [Column("Pressuren")]
    public string? Pressuren { get; set; }

    [Column("LamaPembongkaran")]
    public string? LamaPembongkaran { get; set; }

    [Column("ETC")]
    public DateTime? Etc { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
