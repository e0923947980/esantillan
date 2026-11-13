using esantillan.Models;

namespace esantillan.Views;

public partial class vEstudiante : ContentPage
{
    public vEstudiante()
    {
        InitializeComponent();
    }

    // Cada vez que se vuelve a esta pantalla se refresca la tabla
    protected override void OnAppearing()
    {
        base.OnAppearing();
        listaEstudiantes.ItemsSource = App._estudianteRepo.GetAllEstudiantes();
    }

    private async void btnNuevo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new vAgregarEstudiante());
    }

    private async void listaEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Estudiante seleccionado)
        {
            // Quita la selección para poder volver a tocar la misma fila
            listaEstudiantes.SelectedItem = null;
            await Navigation.PushAsync(new vActualizarEliminar(seleccionado));
        }
    }
}
