using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Project8.Models
{
    public static class AppConfiguration
    {
        public static string GetConnectionString()
        {
            // Obtener la ruta absoluta del archivo basado en el directorio base de la app
            var configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.local.json");

            if (!File.Exists(configPath))
                throw new FileNotFoundException($"No se encontró el archivo de configuración: {configPath}");

            var json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);

            return config["ConnectionStrings"]["DefaultConnection"];
        }
    }
}
