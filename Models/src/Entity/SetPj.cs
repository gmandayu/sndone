namespace SnDOne.Entities;

/**
 * Entity class for "SetPjs" table
 */
[Table("SetPjs")]
public class SetPj
{
    [Key("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NomorPjs")]
    public required string NomorPjs { get; set; } = default!;

    [Column("Nama")]
    public string? Nama { get; set; }

    [Column("OrganizationLevel")]
    public required string? OrganizationLevel { get; set; }

    [Column("Region")]
    public int? Region { get; set; }

    [Column("Plant")]
    public required int? Plant { get; set; }

    [Column("PosisiAwal")]
    public required int PosisiAwal { get; set; } = default!;

    [Column("PosisiPJS")]
    public required int PosisiPjs { get; set; } = default!;

    [Column("TanggalMulai")]
    public required DateTime TanggalMulai { get; set; } = default!;

    [Column("TanggalSelesai")]
    public required DateTime? TanggalSelesai { get; set; }

    [Column("Status")]
    public required string Status { get; set; } = default!;

    [Column("SuratTugas")]
    public string? SuratTugas { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("Remaks")]
    public string? Remaks { get; set; }

    [Column("DibuatOleh")]
    public required int DibuatOleh { get; set; } = default!;

    [Column("TanggalDibuat")]
    public required DateTime TanggalDibuat { get; set; } = default!;

    [Column("DiperbaharuiOleh")]
    public int? DiperbaharuiOleh { get; set; }

    [Column("DiperbaharuiTanggal")]
    public DateTime? DiperbaharuiTanggal { get; set; }

    [Column("PlantAwal")]
    public int? PlantAwal { get; set; }

    [Column("RegionAwal")]
    public int? RegionAwal { get; set; }
}
