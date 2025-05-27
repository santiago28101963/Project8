using Project8.Models; // Incluye AppConfiguration y modelos
using Project8.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project8;

namespace Project8.Services
{
    public class VehiculoService
    {
        private readonly VehiculoRepository _repository;

        public VehiculoService()
        {
            string connectionString = AppConfiguration.GetConnectionString();
            _repository = new VehiculoRepository(connectionString);
        }

        public async Task<List<Vehiculo>> ObtenerVehiculosAsync()
        {
            return await _repository.ObtenerVehiculosAsync();
        }
    }
}
