using esantillan.Repositories;
using esantillan.Utils;

namespace esantillan;

public partial class App : Application
{
    public static PersonRepository _personRepo { get; private set; } = null!;

    public App()
    {
        InitializeComponent();

        string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
        _personRepo = new PersonRepository(dbPath);
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
