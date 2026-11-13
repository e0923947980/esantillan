using esantillan.Repositories;
using esantillan.Utils;

namespace esantillan;

public partial class App : Application
{
    public static PersonRepository _personRepo { get; private set; } = null!;
    public static EstudianteRepository _estudianteRepo { get; private set; } = null!;

    public App()
    {
        InitializeComponent();

        _personRepo = new PersonRepository(FileAccessHelper.GetLocalFilePath("people.db3"));
        _estudianteRepo = new EstudianteRepository(FileAccessHelper.GetLocalFilePath("estudiantes.db3"));
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
