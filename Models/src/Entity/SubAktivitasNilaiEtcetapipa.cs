namespace SnDOne.Entities;

/**
 * Entity class for "SubAktivitasNilaiETCETAPipa" table
 */
[Table("SubAktivitasNilaiETCETAPipa")]
public class SubAktivitasNilaiEtcetapipa
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

    [Column("IsiPipa")]
    public string? IsiPipa { get; set; }

    [Column("IsiPipa2")]
    public string? IsiPipa2 { get; set; }

    [Column("IsiPipa3")]
    public string? IsiPipa3 { get; set; }

    [Column("Flowrate")]
    public string? Flowrate { get; set; }

    [Column("LamaPengisian")]
    public string? LamaPengisian { get; set; }

    [Column("LamaPengiriman")]
    public string? LamaPengiriman { get; set; }

    [Column("LamaPengiriman2")]
    public string? LamaPengiriman2 { get; set; }

    [Column("LamaPengiriman3")]
    public string? LamaPengiriman3 { get; set; }

    [Column("ETC")]
    public DateTime? Etc { get; set; }

    [Column("ETA")]
    public DateTime? Eta { get; set; }

    [Column("ETA2")]
    public DateTime? Eta2 { get; set; }

    [Column("ETA3")]
    public DateTime? Eta3 { get; set; }

    [Column("userInput")]
    public string? UserInput { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }
}
