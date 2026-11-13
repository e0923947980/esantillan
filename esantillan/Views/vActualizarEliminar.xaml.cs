using esantillan.Models;

namespace esantillan.Views;

public partial class vActualizarEliminar : ContentPage
{
    private readonly Estudiante _estudiante;

    public vActualizarEliminar(Estudiante datos)
    {
        InitializeComponent();

        _estudiante = datos;
        txtCodigo.Text = datos.Codigo.ToString();
        txtNombre.Text = datos.Nombre;
        txtApellido.Text = datos.Apellido;
        txtEdad.Text = datos.Edad.ToString();
    }

    // UPDATE
    private async void btnActualizar_Clicked(object sender, EventArgs e)
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

        _estudiante.Nombre = txtNombre.Text.Trim();
        _estudiante.Apellido = txtApellido.Text.Trim();
        _estudiante.Edad = edad;

        bool ok = App._estudianteRepo.UpdateEstudiante(_estudiante);
        await DisplayAlert("Actualizar", App._estudianteRepo.StatusMessage, "Aceptar");

        if (ok)
            await Navigation.PopAsync();
    }

    // DELETE
    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert(
            "Eliminar",
            $"¿Eliminar a {_estudiante.Nombre} {_estudiante.Apellido}?",
            "Sí", "No");

        if (!confirmar)
            return;

        bool ok = App._estudianteRepo.DeleteEstudiante(_estudiante.Codigo);
        await DisplayAlert("Eliminar", App._estudianteRepo.StatusMessage, "Aceptar");

        if (ok)
            await Navigation.PopAsync();
    }
}
