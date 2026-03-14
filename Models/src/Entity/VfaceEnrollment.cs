namespace SnDOne.Entities;

/**
 * Entity class for "VFaceEnrollment" table
 */
[Table("VFaceEnrollment")]
public class VfaceEnrollment
{
    [Key("IdUser")]
    public required int IdUser { get; set; } = default!;

    [Column("Username")]
    public required string Username { get; set; } = default!;

    [Column("Email")]
    public string? Email { get; set; }

    [Column("NamaLengkap")]
    public string? NamaLengkap { get; set; }

    [Column("IdPosition")]
    public int? IdPosition { get; set; }

    [Column("Jabatan")]
    public string? Jabatan { get; set; }

    [Column("Face")]
    public string? Face { get; set; }

    [Column("TanggalInputFace")]
    public DateTime? TanggalInputFace { get; set; }

    [Column("UserInputFace")]
    public string? UserInputFace { get; set; }

    [Column("AzurePersonId")]
    public Guid? AzurePersonId { get; set; }
}
