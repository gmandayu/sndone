namespace SnDOne.Entities;

/**
 * Entity class for "MasterUser" table
 */
[Table("MasterUser")]
public class MasterUser
{
    [Key("IdUser")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUser { get; set; } = default!;

    [Column("Email")]
    public required string? Email { get; set; }

    [Column("Username")]
    public required string Username { get; set; } = default!;

    [Column("PasswordHash")]
    public required string? PasswordHash { get; set; }

    [Column("NamaLengkap")]
    public string? NamaLengkap { get; set; }

    [Column("UserLevel")]
    public required int UserLevel { get; set; } = default!;

    [Column("Rule")]
    public required string? Rule { get; set; }

    [Column("IdPosition")]
    public int? IdPosition { get; set; }

    [Column("Region")]
    public int? Region { get; set; }

    [Column("Plant")]
    public int? Plant { get; set; }

    [Column("StatusAktif")]
    public bool? StatusAktif { get; set; } = true;

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("DibuatOleh")]
    public string? DibuatOleh { get; set; }

    [Column("TanggalDibuat")]
    public DateTime? TanggalDibuat { get; set; }

    [Column("DiperbaruiOleh")]
    public string? DiperbaruiOleh { get; set; }

    [Column("TanggalDiperbarui")]
    public DateTime? TanggalDiperbarui { get; set; }

    [Column("IsResetable")]
    public bool? IsResetable { get; set; }

    [Column("IsVerify")]
    public bool? IsVerify { get; set; }

    [Column("Face")]
    public string? Face { get; set; }

    [Column("AzurePersonId")]
    public Guid? AzurePersonId { get; set; }

    [Column("TanggalInputFace")]
    public DateTime? TanggalInputFace { get; set; }

    [Column("UserInputFace")]
    public string? UserInputFace { get; set; }

    [Column("IdIdaman")]
    public string? IdIdaman { get; set; }

    [Column("exception ")]
    public bool? Exception { get; set; }
}
