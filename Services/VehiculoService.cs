//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.Data.SqlClient;
//using Microsoft.Maui.Controls;
//using Project8.Models;
//using Project8.Services;

//namespace Project8.Services
//{
//    public class VehiculoService
//    {
//        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=EcommerceDelUsadoDB;Trusted_Connection=True;TrustServerCertificate=True;";
//        private readonly VehiculoImagenRepository _imagenRepo;

//        public VehiculoService()
//        {
//            _imagenRepo = new VehiculoImagenRepository(_connectionString);
//        }

//        public async Task<List<Vehiculo>> ObtenerVehiculosAsync()
//        {
//            var vehiculos = new List<Vehiculo>();

//            using (var connection = new SqlConnection(_connectionString))
//            {
//                await connection.OpenAsync();

//                var command = new SqlCommand("SELECT Id, Marca, Modelo, Año, Precio FROM Vehiculos", connection);
//                using (var reader = await command.ExecuteReaderAsync())
//                {
//                    while (await reader.ReadAsync())
//                    {
//                        vehiculos.Add(new Vehiculo
//                        {
//                            Id = reader.GetInt32(0),
//                            Marca = reader.GetString(1),
//                            Modelo = reader.GetString(2),
//                            Año = reader.GetInt32(3),
//                            Precio = reader.GetDecimal(4)
//                        });
//                    }
//                }
//            }

//            return vehiculos;
//        }

//        public async Task GuardarImagenDeVehiculoAsync(int vehiculoId, byte[] imagen)
//        {
//            await _imagenRepo.GuardarImagenAsync(vehiculoId, imagen);
//        }

//        public async Task<ImageSource?> ObtenerImagenDeVehiculoAsync(int vehiculoId)
//        {
//            var bytes = await _imagenRepo.ObtenerImagenAsync(vehiculoId);
//            if (bytes == null) return null;

//            return ImageSource.FromStream(() => new MemoryStream(bytes));
//        }
//    }
//}

//Puedes hacer un pequeño método de prueba para validar conexión y consulta sin complicaciones. Aqui en este codigo se anexo esto alcodigo de arriba que es funcional.
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using Project8.Models;
using Project8.Services;

namespace Project8.Services
{
    public class VehiculoService
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=EcommerceDelUsadoDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly VehiculoImagenRepository _imagenRepo;

        public VehiculoService()
        {
            _imagenRepo = new VehiculoImagenRepository(_connectionString);
        }

        public async Task<List<Vehiculo>> ObtenerVehiculosAsync()
        {
            var vehiculos = new List<Vehiculo>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("SELECT Id, Marca, Modelo, Año, Precio FROM Vehiculos", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        vehiculos.Add(new Vehiculo
                        {
                            Id = reader.GetInt32(0),
                            Marca = reader.GetString(1),
                            Modelo = reader.GetString(2),
                            Año = reader.GetInt32(3),
                            Precio = reader.GetDecimal(4)
                        });
                    }
                }
            }

            return vehiculos;
        }

        public async Task GuardarImagenDeVehiculoAsync(int vehiculoId, byte[] imagen)
        {
            await _imagenRepo.GuardarImagenAsync(vehiculoId, imagen);
        }

        public async Task<ImageSource?> ObtenerImagenDeVehiculoAsync(int vehiculoId)
        {
            var bytes = await _imagenRepo.ObtenerImagenAsync(vehiculoId);
            if (bytes == null) return null;

            return ImageSource.FromStream(() => new MemoryStream(bytes));
        }

        // ✅ Nuevo método para probar conexión
        public async Task<bool> ProbarConexionAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand("SELECT COUNT(*) FROM Vehiculos", connection);
                var count = (int)await command.ExecuteScalarAsync();

                System.Diagnostics.Debug.WriteLine($"Vehículos en BD: {count}");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error de conexión: {ex.Message}");
                return false;
            }
        }
    }
}
