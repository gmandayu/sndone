namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// User level class
    /// </summary>
    public class UserLevel
    {
        // User level ID
        [Column("UserLevelID")]
        public int Id { set; get; }

        // Name
        [Column("UserLevelName")]
        public string Name { set; get; } = "";
    }
} // End Partial class
