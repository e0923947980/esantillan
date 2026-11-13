using SQLite;

namespace esantillan.Models;

[Table("estudiantes")]
public class Estudiante
{
    [PrimaryKey, AutoIncrement]
    public int Codigo { get; set; }

    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Apellido { get; set; } = string.Empty;

    public int Edad { get; set; }
}
