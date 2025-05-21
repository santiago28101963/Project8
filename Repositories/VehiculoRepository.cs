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

                var query = "SELECT Id, Marca, Modelo, Año, Precio FROM Vehiculos";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
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
    }
}
