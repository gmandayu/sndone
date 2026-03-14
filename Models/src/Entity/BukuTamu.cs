namespace SnDOne.Entities;

/**
 * Entity class for "BukuTamu" table
 */
[Table("BukuTamu")]
public class BukuTamu
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NomorBukuTamu")]
    public string? NomorBukuTamu { get; set; }

    [Column("LookupPlant")]
    public required int? LookupPlant { get; set; }

    [Column("Plant")]
    public required int? Plant { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("StatusZona")]
    public string? StatusZona { get; set; }

    [Column("Nama")]
    public string? Nama { get; set; }

    [Column("AsalPerusahaan")]
    public string? AsalPerusahaan { get; set; }

    [Column("Jabatan")]
    public string? Jabatan { get; set; }

    [Column("FungsiygDikunjungi")]
    public string? FungsiygDikunjungi { get; set; }

    [Column("MaksudKunjungan")]
    public string? MaksudKunjungan { get; set; }

    [Column("TandaPengenal")]
    public string? TandaPengenal { get; set; }

    [Column("TandaTangan")]
    public string? TandaTangan { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("PintuUtamaId")]
    public string? PintuUtamaId { get; set; }

    [Column("PintuUtamaInTanggal")]
    public DateTime? PintuUtamaInTanggal { get; set; }

    [Column("PintuUtamaInFoto")]
    public string? PintuUtamaInFoto { get; set; }

    [Column("PintuUtamaInUser")]
    public string? PintuUtamaInUser { get; set; }

    [Column("PintuUtamaOutTanggal")]
    public DateTime? PintuUtamaOutTanggal { get; set; }

    [Column("PintuUtamaOutFoto")]
    public string? PintuUtamaOutFoto { get; set; }

    [Column("PintuUtamaOutUser")]
    public string? PintuUtamaOutUser { get; set; }

    [Column("LobbyUtamaId")]
    public string? LobbyUtamaId { get; set; }

    [Column("LobbyUtamaInTanggal")]
    public DateTime? LobbyUtamaInTanggal { get; set; }

    [Column("LobbyUtamaInFoto")]
    public string? LobbyUtamaInFoto { get; set; }

    [Column("LobbyUtamaInUser")]
    public string? LobbyUtamaInUser { get; set; }

    [Column("LobbyUtamaOutTanggal")]
    public DateTime? LobbyUtamaOutTanggal { get; set; }

    [Column("LobbyUtamaOutFoto")]
    public string? LobbyUtamaOutFoto { get; set; }

    [Column("LobbyUtamaOutUser")]
    public string? LobbyUtamaOutUser { get; set; }

    [Column("AreaTerlarangId")]
    public string? AreaTerlarangId { get; set; }

    [Column("AreaTerlarangInTanggal")]
    public DateTime? AreaTerlarangInTanggal { get; set; }

    [Column("AreaTerlarangInFoto")]
    public string? AreaTerlarangInFoto { get; set; }

    [Column("AreaTerlarangInUser")]
    public string? AreaTerlarangInUser { get; set; }

    [Column("AreaTerlarangOutTanggal")]
    public DateTime? AreaTerlarangOutTanggal { get; set; }

    [Column("AreaTerlarangOutFoto")]
    public string? AreaTerlarangOutFoto { get; set; }

    [Column("AreaTerlarangOutUser")]
    public string? AreaTerlarangOutUser { get; set; }

    [Column("etlDate")]
    public DateTime? EtlDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("StatusZonaPrev")]
    public string? StatusZonaPrev { get; set; }
}
