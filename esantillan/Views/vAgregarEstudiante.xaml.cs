using esantillan.Models;

namespace esantillan.Views;

public partial class vAgregarEstudiante : ContentPage
{
    public vAgregarEstudiante()
    {
        InitializeComponent();
    }

    // CREATE
    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        lblMensaje.Text = "";

        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text))
        {
            lblMensaje.Text = "Nombre y apellido son obligatorios";
            return;
        }

        if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0)
        {
            lblMensaje.Text = "Ingrese una edad válida";
            return;
        }

        var estudiante = new Estudiante
        {
            Nombre = txtNombre.Text.Trim(),
            Apellido = txtApellido.Text.Trim(),
            Edad = edad
        };

        if (App._estudianteRepo.AddEstudiante(estudiante))
        {
            await DisplayAlert("Estudiante", App._estudianteRepo.StatusMessage, "Aceptar");
            await Navigation.PopAsync();
        }
        else
        {
            lblMensaje.Text = App._estudianteRepo.StatusMessage;
        }
    }
}
