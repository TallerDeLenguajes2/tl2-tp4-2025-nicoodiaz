namespace ApiWeb;

using ApiWeb;
public class Pedido
{

    public int NumeroPedido { get; set; } //Para que no se pueda cambiar fuera de la clase
    public string Observacion { get; set; }
    public EstadoPedido EstadoActualDelPedido { get; set; }
    
    public Cadete Cadete { get; set; }

    public Pedido(int numeroPedido, string observacionPedido, EstadoPedido estado)
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