using System.Text.Json;

namespace ApiWeb;

public class AccesoADatosCadetes
{
    private string path = "Datos/cadetes.json";
    public List<Cadete> CargarCadete()
    {
        var cadetes = new List<Cadete>();
        if (File.Exists(path))
        {
            string txtJson = File.ReadAllText(path);
            cadetes = JsonSerializer.Deserialize<List<Cadete>>(txtJson);
        }
        return cadetes;
    }
    
    public void GuardarCadetes(Cadete cadeteNuevo)
    {
        using (FileStream archivo = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter escribirCadetes = new StreamWriter(archivo))
            {
                var archivoAGuardar = JsonSerializer.Serialize(cadeteNuevo);
                escribirCadetes.WriteLine(archivoAGuardar);
            }
        }
    }}