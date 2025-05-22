using Project8.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Project8.Repositories
{
    public class VehiculoRepository
    {
        private readonly string _connectionString;

        public VehiculoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Vehiculo>> ObtenerVehiculosAsync()
        {
            var vehiculos = new List<Vehiculo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Marca, Modelo, Año, Precio FROM Vehiculos";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var marca = reader["Marca"].ToString();
                        var modelo = reader["Modelo"].ToString();

                        var vehiculo = new Vehiculo
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Marca = marca,
                            Modelo = modelo,
                            Año = Convert.ToInt32(reader["Año"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            ImagenNombre = $"{marca.ToLower()}{1}.png" // Ej: toyota1.png
                        };

                        // NUEVAS LÍNEAS AGREGADAS AQUÍ
                        // Convertimos la marca a minúsculas y quitamos espacios para formar nombres de imagen válidos
                        string marcaImagen = vehiculo.Marca.ToLower().Replace(" ", "");

                        // Asignamos las rutas a las propiedades correctas
                        vehiculo.ImagenIzquierda = $"{marcaImagen}1.png";  // Ej: toyota1.png
                        vehiculo.ImagenDerecha = $"{marcaImagen}2.png";   // Ej: toyota2.png

                        vehiculos.Add(vehiculo);
                    }
                }
            }

            return vehiculos;
        }


    }
}
