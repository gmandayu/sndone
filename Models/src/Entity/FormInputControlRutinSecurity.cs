namespace SnDOne.Entities;

/**
 * Entity class for "FormInputControlRutinSecurity" table
 */
[Table("FormInputControlRutinSecurity")]
public class FormInputControlRutinSecurity
{
    [Key("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoReferensi")]
    public string? NoReferensi { get; set; }

    [Column("NamaSecurity")]
    public string? NamaSecurity { get; set; }

    [Column("Tanggal")]
    public DateTime? Tanggal { get; set; }

    [Column("Lokasi")]
    public string? Lokasi { get; set; }

    [Column("UploadFoto")]
    public string? UploadFoto { get; set; }

    [Column("Ketidaksesuaiaan")]
    public string? Ketidaksesuaiaan { get; set; }

    [Column("Keterangan")]
    public string? Keterangan { get; set; }

    [Column("IdPosition")]
    public int? IdPosition { get; set; }

    [Column("UserInput")]
    public string? UserInput { get; set; }

    [Column("EtlDate")]
    public DateTime EtlDate { get; set; } = default!;

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("LastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}
