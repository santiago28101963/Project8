// ViewModels/VehiculoItemViewModel.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Project8.Models;
using Project8.Services;

namespace Project8.ViewModels
{
    public class VehiculoItemViewModel : INotifyPropertyChanged
    {
        private readonly VehiculoService _vehiculoService = new();

        public Vehiculo Vehiculo { get; }

        // Propiedades públicas para el Binding en XAML
        public string Marca => Vehiculo.Marca;
        public string Modelo => Vehiculo.Modelo;
        public int Año => Vehiculo.Año;
        public decimal Precio => Vehiculo.Precio;

        private ImageSource? _imagen;
        public ImageSource? Imagen
        {
            get => _imagen;
            set
            {
                _imagen = value;
                OnPropertyChanged();
            }
        }

        public VehiculoItemViewModel(Vehiculo vehiculo)
        {
            Vehiculo = vehiculo;
        }

        public async Task CargarImagenAsync()
        {
            Imagen = await _vehiculoService.ObtenerImagenDeVehiculoAsync(Vehiculo.Id);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
