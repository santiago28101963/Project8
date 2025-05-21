using Project8.Models;
using Project8.Services;

namespace Project8.Resources.Views.Pages
{
    public partial class VehiculoPage : ContentPage
    {
        private readonly VehiculoService _vehiculoService;

        public VehiculoPage()
        {
            InitializeComponent();
            _vehiculoService = new VehiculoService();

            // Llamar al método asincrónico correctamente
            _ = CargarVehiculosAsync(); // no se espera resultado, así evitamos warning
        }

        // Ahora el método es async porque usamos await dentro
        private async Task CargarVehiculosAsync()
        {
            var vehiculos = await _vehiculoService.ObtenerVehiculosAsync();
            VehiculosCollectionView.ItemsSource = vehiculos;
        }
    }
}
