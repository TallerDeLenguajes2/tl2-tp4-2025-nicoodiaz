namespace ApiWeb;

using ApiWeb;
public class Pedido
{
    private int numeroPedido;
    private string observacion;
    //private Cliente datosCliente;
    private EstadoPedido estadoActualDelPedido;
    private Cadete cadete;


    public int NumeroPedido { get => numeroPedido; } //Para que no se pueda cambiar fuera de la clase
    public string Observacion { get => observacion; set => observacion = value; }
    public EstadoPedido EstadoActualDelPedido { get => estadoActualDelPedido; set => estadoActualDelPedido = value; }
    
    public Cadete Cadete { get => cadete; set => cadete = value; }

    public Pedido(int numeroPedido, string observacionPedido, EstadoPedido estado)
    {
        this.numeroPedido = numeroPedido;
        this.observacion = observacionPedido;
        //this.datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia); //Creo por composicion Cliente-Pedido
        this.estadoActualDelPedido = estado;
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