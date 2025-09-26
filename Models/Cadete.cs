using System.Text.Json.Serialization;
using ApiWeb;

namespace ApiWeb;

public class Cadete
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }
    [JsonPropertyName("direccion")]
    public string Direccion { get; set; }
    [JsonPropertyName("telefono")]
    public string Telefono { get; set; }
} 