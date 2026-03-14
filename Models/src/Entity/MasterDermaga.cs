namespace SnDOne.Entities;

/**
 * Entity class for "MasterDermaga" table
 */
[Table("MasterDermaga")]
public class MasterDermaga
{
    [Key("IdDermaga")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDermaga { get; set; } = default!;

    [Column("Region")]
    public string? Region { get; set; }

    [Column("Id_Plant")]
    public int? IdPlant { get; set; }

    [Column("Plant")]
    public string? Plant { get; set; }

    [Column("TBBM")]
    public string? Tbbm { get; set; }

    [Column("Equipment_ID")]
    public string? EquipmentId { get; set; }

    [Column("Fungsi")]
    public string? Fungsi { get; set; }

    [Column("Kapasitas_DWT")]
    public string? KapasitasDwt { get; set; }

    [Column("Kategori_Kapasitas")]
    public string? KategoriKapasitas { get; set; }

    [Column("Jenis_Sartam")]
    public string? JenisSartam { get; set; }

    [Column("Type_Sartam")]
    public string? TypeSartam { get; set; }

    [Column("Tahun_Pembuatan")]
    public string? TahunPembuatan { get; set; }

    [Column("Kategori_Port")]
    public string? KategoriPort { get; set; }

    [Column("DibuatOleh")]
    public string? DibuatOleh { get; set; }

    [Column("TanggalDibuat")]
    public DateTime? TanggalDibuat { get; set; }

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }
}
