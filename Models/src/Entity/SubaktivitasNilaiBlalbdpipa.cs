namespace SnDOne.Entities;

/**
 * Entity class for "SubaktivitasNilaiBLALBDPipa" table
 */
[Table("SubaktivitasNilaiBLALBDPipa")]
public class SubaktivitasNilaiBlalbdpipa
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

    [Column("AL_klobs")]
    public string? AlKlobs { get; set; }

    [Column("AL_kl15")]
    public string? AlKl15 { get; set; }

    [Column("AL_barrels")]
    public string? AlBarrels { get; set; }

    [Column("AL_lt")]
    public string? AlLt { get; set; }

    [Column("AL_mt")]
    public string? AlMt { get; set; }

    [Column("BD_klobs")]
    public string? BdKlobs { get; set; }

    [Column("BD_kl15")]
    public string? BdKl15 { get; set; }

    [Column("BD_barrels")]
    public string? BdBarrels { get; set; }

    [Column("BD_lt")]
    public string? BdLt { get; set; }

    [Column("BD_mt")]
    public string? BdMt { get; set; }

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
