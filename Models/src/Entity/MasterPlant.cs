namespace SnDOne.Entities;

/**
 * Entity class for "MasterPlant" table
 */
[Table("MasterPlant")]
public class MasterPlant
{
    [Key("IdPlant")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPlant { get; set; } = default!;

    [Column("Terminal_Manager")]
    public string? TerminalManager { get; set; }

    [Column("PRL")]
    public string? Prl { get; set; }

    [Column("Status")]
    public string? Status { get; set; }

    [Column("Terminal_Induk")]
    public string? TerminalInduk { get; set; }

    [Column("Nama_Terminal")]
    public string? NamaTerminal { get; set; }

    [Column("Region")]
    public string? Region { get; set; }

    [Column("Fungsi")]
    public string? Fungsi { get; set; }

    [Column("Cost_Center")]
    public string? CostCenter { get; set; }

    [Column("Jenis")]
    public string? Jenis { get; set; }

    [Column("Plant")]
    public string? Plant { get; set; }

    [Column("UTC")]
    public string? Utc { get; set; }

    [Column("TipeProduk")]
    public string? TipeProduk { get; set; }

    [Column("JenisPlant")]
    public string? JenisPlant { get; set; }

    [Column("DibuatOleh")]
    public string? DibuatOleh { get; set; }

    [Column("TanggalDibuat")]
    public DateTime? TanggalDibuat { get; set; }

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }
}
