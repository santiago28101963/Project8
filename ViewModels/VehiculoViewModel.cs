using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Project8.Models;
using Project8.Services;

namespace Project8.ViewModels
{
    public class VehiculoViewModel
    {
        public ObservableCollection<VehiculoItemViewModel> Vehiculos { get; set; } = new();
        private readonly VehiculoService _vehiculoService = new();

        public async Task CargarVehiculosAsync()
        {
            System.Diagnostics.Debug.WriteLine("Iniciando carga de vehículos...");

            var lista = await _vehiculoService.ObtenerVehiculosAsync();

            Vehiculos.Clear();

            foreach (var v in lista)
            {
                var itemVM = new VehiculoItemViewModel(v);
                await itemVM.CargarImagenAsync();  // Carga la imagen por vehículo
                Vehiculos.Add(itemVM);
            }

            System.Diagnostics.Debug.WriteLine($"Vehículos cargados: {Vehiculos.Count}");
        }
    }
}
