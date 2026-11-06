using SQLite;
using esantillan.Models;

namespace esantillan.Repositories;

public class PersonRepository
{
    private readonly string _dbPath;
    private SQLiteConnection? conn;

    public string StatusMessage { get; set; } = string.Empty;

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Persona>();
    }

    // INSERT
    public void AddNewPerson(string name)
    {
        try
        {
            Init();

            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Debe ingresar un nombre válido");

            var persona = new Persona { Name = name.Trim() };
            int result = conn!.Insert(persona);

            StatusMessage = $"{result} registro(s) agregado(s): {persona.Name}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error al agregar '{name}': {ex.Message}";
        }
    }

    // SELECT
    public List<Persona> GetAllPerson()
    {
        try
        {
            Init();
            return conn!.Table<Persona>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error al consultar: {ex.Message}";
        }

        return new List<Persona>();
    }

    // DELETE
    public void DeletePerson(int id)
    {
        try
        {
            Init();

            int result = conn!.Delete<Persona>(id);

            StatusMessage = result > 0
                ? $"Persona con Id {id} eliminada correctamente"
                : $"No se encontró la persona con Id {id}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error al eliminar: {ex.Message}";
        }
    }
}
