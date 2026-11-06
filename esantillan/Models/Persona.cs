using SQLite;

namespace esantillan.Models;

[Table("people")]
public class Persona
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string Name { get; set; } = string.Empty;
}
