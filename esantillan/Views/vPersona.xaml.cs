using esantillan.Models;

namespace esantillan.Views;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
    }

    private void CargarLista()
    {
        listaPersonas.ItemsSource = App._personRepo.GetAllPerson();
    }

    // MOSTRAR (SELECT)
    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        List<Persona> people = App._personRepo.GetAllPerson();
        listaPersonas.ItemsSource = people;
    }

    // AGREGAR (INSERT)
    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        App._personRepo.AddNewPerson(txtName.Text);
        lblStatusMessage.Text = App._personRepo.StatusMessage;

        txtName.Text = string.Empty;
        CargarLista();
    }

    // ELIMINAR (DELETE)
    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        // El BindingContext del botón es la Persona de esa fila
        var persona = (Persona)((Button)sender).BindingContext;

        lblStatusMessage.Text = "";
        App._personRepo.DeletePerson(persona.Id);
        lblStatusMessage.Text = App._personRepo.StatusMessage;

        // Refrescar la lista para que desaparezca la fila borrada
        CargarLista();
    }
}
