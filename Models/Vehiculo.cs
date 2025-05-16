// Models/Vehiculo.cs
namespace Project8.Models
{
    public class Vehiculo
    {
        public int Id { get; set; } // Lo genera SQL Server automáticamente
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public decimal Precio { get; set; }
    }
}
