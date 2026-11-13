using SQLite;
using esantillan.Models;

namespace esantillan.Repositories;

public class EstudianteRepository
{
    private readonly string _dbPath;
    private SQLiteConnection? conn;

    public string StatusMessage { get; set; } = string.Empty;

    public EstudianteRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Estudiante>();
    }

    // CREATE
    public bool AddEstudiante(Estudiante estudiante)
    {
        try
        {
            Init();
            conn!.Insert(estudiante);
            StatusMessage = $"Estudiante {estudiante.Nombre} {estudiante.Apellido} agregado correctamente";
            return true;
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error al agregar: {ex.Message}";
            return false;
        }
    }

    // READ
    public List<Estudiante> GetAllEstudiantes()
    {
        try
        {
            Init();
            return conn!.Table<Estudiante>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error al consultar: {ex.Message}";
        }

        return new List<Estudiante>();
    }

    // UPDATE
    public bool UpdateEstudiante(Estudiante estudiante)
    {
        try
        {
            Init();
            int result = conn!.Update(estudiante);

            StatusMessage = result > 0
                ? $"Estudiante {estudiante.Codigo} actualizado correctamente"
                : $"No se encontró el estudiante {estudiante.Codigo}";
            return result > 0;
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error al actualizar: {ex.Message}";
            return false;
        }
    }

    // DELETE
    public bool DeleteEstudiante(int codigo)
    {
        try
        {
            Init();
            int result = conn!.Delete<Estudiante>(codigo);

            StatusMessage = result > 0
                ? $"Estudiante {codigo} eliminado correctamente"
                : $"No se encontró el estudiante {codigo}";
            return result > 0;
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error al eliminar: {ex.Message}";
            return false;
        }
    }
}
