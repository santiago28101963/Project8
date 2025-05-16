// Ruta: Project8/Services/VehiculoImagenRepository.cs

using System.Data;
using Microsoft.Data.SqlClient;

namespace Project8.Services
{
    public class VehiculoImagenRepository
    {
        private readonly string _connectionString;

        public VehiculoImagenRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task GuardarImagenAsync(int vehiculoId, byte[] imagenBytes)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("INSERT INTO VehiculosImagenes (VehiculoId, Imagen) VALUES (@VehiculoId, @Imagen)", connection);

            command.Parameters.Add("@VehiculoId", SqlDbType.Int).Value = vehiculoId;
            command.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = imagenBytes;

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<byte[]?> ObtenerImagenAsync(int vehiculoId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT Imagen FROM VehiculosImagenes WHERE VehiculoId = @VehiculoId", connection);

            command.Parameters.Add("@VehiculoId", SqlDbType.Int).Value = vehiculoId;

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();
            return result as byte[];
        }
    }
}
