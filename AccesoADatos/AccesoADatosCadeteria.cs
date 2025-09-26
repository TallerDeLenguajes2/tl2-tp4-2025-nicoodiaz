using System.Text.Json;

namespace ApiWeb;

public class AccesoADatosCadeteria
{
    private string path = "Datos/cadeteria.json";
        public Cadeteria CrearCadeteria()
    {
        Cadeteria cadeteria = null;
        if (File.Exists(path))
        {
            string txtJson = File.ReadAllText(path);
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(txtJson);
        }
        return cadeteria;
    }
}