// MainPage.xaml.cs
using Project8.ViewModels;
using System.Diagnostics;

namespace Project8
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private VehiculoViewModel ViewModel => BindingContext as VehiculoViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
        private VehiculoViewModel viewModel => BindingContext as VehiculoViewModel;

        private async void BtnMostrarVehiculos_Clicked(object sender, EventArgs e)
        {
            //LblCargando.IsVisible = true;

            await viewModel.CargarVehiculosAsync();

            LblTituloVehiculos.IsVisible = true;
            PanelBienvenida.IsVisible = false; // Oculta todo después de cargar
        }

    }
}
