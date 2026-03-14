namespace SnDOne.Entities;

/**
 * Entity class for "MWTOnline" table
 */
[Table("MWTOnline")]
public class Mwtonline
{
    [Key("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("NoMWTOnline")]
    public string? NoMwtonline { get; set; }

    [Column("IdPlant")]
    public int? IdPlant { get; set; }

    [Column("TaskList")]
    public string? TaskList { get; set; }

    [Column("Status")]
    public string? Status { get; set; }

    [Column("File")]
    public string? File { get; set; }

    [Column("StatusEmail")]
    public string? StatusEmail { get; set; }

    [Column("CreatedBy")]
    public string? CreatedBy { get; set; }

    [Column("CreatedDate")]
    public DateTime? CreatedDate { get; set; }

    [Column("LastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [Column("LastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }

    [Column("CompletedBy")]
    public string? CompletedBy { get; set; }

    [Column("CompletedDate")]
    public DateTime? CompletedDate { get; set; }
}
