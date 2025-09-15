using System.Text.Json;
using ApiWeb;

public class AccesoADatosJSON : IAccesoADatos
{
    public List<Cadete> CargarCadete(string rutaArchivoCadete)
    {
        var cadetes = new List<Cadete>();
        if (File.Exists(rutaArchivoCadete))
        {
            string txtJson = File.ReadAllText(rutaArchivoCadete);
            cadetes = JsonSerializer.Deserialize<List<Cadete>>(txtJson);
        }
        return cadetes;
    }

    public Cadeteria CrearCadeteria(string rutaArchivoCadeteria)
    {
        Cadeteria cadeteria = null;
        if (File.Exists(rutaArchivoCadeteria))
        {
            string txtJson = File.ReadAllText(rutaArchivoCadeteria);
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(txtJson);
        }
        return cadeteria;
    }
}