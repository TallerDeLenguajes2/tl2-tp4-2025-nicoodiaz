namespace ApiWeb;

using System.Text.Json.Serialization;
using ApiWeb;
public class Pedido
{
    [JsonPropertyName("id")]
    public int NumeroPedido { get; set; } //Para que no se pueda cambiar fuera de la clase
    [JsonPropertyName("observacion")]
    public string Observacion { get; set; }
    [JsonPropertyName("estadoPedido")]
    public EstadoPedido EstadoActualDelPedido { get; set; }
    [JsonPropertyName("cadete")]
    public Cadete Cadete { get; set; }
    public Pedido()
    {
        
    }

    public Pedido(int numeroPedido, string observacionPedido, EstadoPedido estado, Cadete cadete)
    {
        NumeroPedido = numeroPedido;
        Observacion = observacionPedido;
        //this.datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia); //Creo por composicion Cliente-Pedido
        EstadoActualDelPedido = estado;
    }

/*     public string VerDireccionCliente()
    {
        return this.datosCliente.Direccion;
    }

    public string VerDatosCliente()
    {
        string datos = $"Nombre: {datosCliente.Nombre} | Telefono: {datosCliente.Telefono} | Direccion: {datosCliente.Direccion} | Referencia sobre donde vive: {datosCliente.DatosReferenciaDireccion}";
                System.Console.WriteLine($"---- Los datos del Cliente ----");
                System.Console.WriteLine($"Nombre: {datosCliente.Nombre} | Telefono: {datosCliente.Telefono} | Direccion: {datosCliente.Direccion} | Referencia sobre donde vive: {datosCliente.DatosReferenciaDireccion}"); 
        return datos;
    */
}