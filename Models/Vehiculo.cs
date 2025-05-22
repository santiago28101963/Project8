namespace Project8.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public decimal Precio { get; set; }

        public string ImagenNombre { get; set; }       // Imagen principal ( imagen base del vehículo, por ejemplo "toyota1.png")
        public string ImagenIzquierda { get; set; }    // Nueva propiedad para imagen izquierda
        public string ImagenDerecha { get; set; }      // Nueva propiedad para imagen derecha
    }
}