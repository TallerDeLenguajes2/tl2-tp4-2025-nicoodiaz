namespace ApiWeb;

using System.Data.Common;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using ApiWeb;
public class Cadeteria
{
    const int PRECIO_ENTREGA = 500;
    private static Cadeteria cadeteria;

    public static Cadeteria GetCadeteria()
    {
        if (cadeteria == null)
        {
            cadeteria = new Cadeteria();
        }
        return cadeteria;
    }
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }
    [JsonPropertyName("telefono")]

    public string Telefono { get; set; }
    [JsonPropertyName("listadoCadetes")]

    public List<Cadete> ListadoCadetes { get; set; } = [];
    [JsonPropertyName("listadoPedidos")]

    public List<Pedido> ListadoPedidos { get; set; } = [];

    public Cadeteria()
    {
/*         nombre = "Rico y Casero";
        telefono = "3815971655";
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();

        listadoCadetes.Add(new Cadete(1, "Diego", "Rivadavia 23", "317264"));
        listadoCadetes.Add(new Cadete(2, "David", "Rivadavia 23", "41273"));
        listadoCadetes.Add(new Cadete(3, "Julio", "Rivadavia 23", "412312"));

        listadoPedidos.Add(new Pedido(1, "Pedido 1", 0));
        listadoPedidos.Add(new Pedido(2, "Pedido 2", 0));
        listadoPedidos.Add(new Pedido(3, "Pedido 3", 0));
        listadoPedidos.Add(new Pedido(4, "Pedido 4", 0));
        listadoPedidos.Add(new Pedido(5, "Pedido 5", 0));
        listadoPedidos.Add(new Pedido(6, "Pedido 6", 0));
        listadoPedidos.Add(new Pedido(7, "Pedido 7", 0));
        listadoPedidos.Add(new Pedido(8, "Pedido 8", 0));
        listadoPedidos.Add(new Pedido(9, "Pedido 9", 0)); */
    }
    public List<Pedido> GetPedidos()
    {
        return ListadoPedidos;
    }
    public List<Cadete> GetCadetes()
    {
        return ListadoCadetes;
    }

    public Cadete BuscarCadetePorId(int idCadete)
    {
        return ListadoCadetes.Find(cadete => cadete.Id == idCadete);
    }

    public Pedido BuscarPedido(int nroPedido)
    {
        return ListadoPedidos.Find(pedido => pedido.NumeroPedido == nroPedido);
    }

    public bool DarAltaCadete(int idCadete, string nombre, string telefono, string direccion) //Para crear un nuevo cadete
    {
        var existeCadete = BuscarCadetePorId(idCadete);
        if (existeCadete is not null) return false;
        var nuevoCadete = new Cadete()
        {
            Id = idCadete,
            Nombre = nombre,
            Telefono = telefono,
            Direccion = direccion
        };

        ListadoCadetes.Add(nuevoCadete);
        return true;

    }
    public bool DarAltaPedido(int nroPedido, string observacion)
    {
        var existePedido = BuscarPedido(nroPedido);
        if (existePedido is not null) return false; // Veo si ya existe un pedido con ese numero

        var nuevoPedido = new Pedido(nroPedido, observacion, EstadoPedido.Pendiente);

        ListadoPedidos.Add(nuevoPedido);
        return true;

    }

    public bool AsignarCadetePedido(int nroPedido, int idCadete)
    {
        var pedido = BuscarPedido(nroPedido);
        var cadete = BuscarCadetePorId(idCadete);
        if (pedido is null || cadete is null) return false;
        if (pedido.EstadoActualDelPedido == EstadoPedido.Pendiente)
        {
            pedido.Cadete = cadete;
            CambiarEstado(pedido.NumeroPedido, EstadoPedido.Asignado);
            return true;
        }
        if (pedido.EstadoActualDelPedido == EstadoPedido.Asignado)
        {
            ReasignarPedido(pedido.NumeroPedido, cadete.Id);
            return true;
        }
        if (pedido.EstadoActualDelPedido == EstadoPedido.Cancelado || EstadoPedido.Entregado == pedido.EstadoActualDelPedido) return false;
        return false;
    }

    public bool ReasignarPedido(int nroPedido, int idCadeteNuevo)
    {
        var pedidoAReasignar = BuscarPedido(nroPedido); //Busco el pedido a reasignar
        bool pedidoReasignado = false;
        var nuevoCadete = BuscarCadetePorId(idCadeteNuevo); //Busco el nuevo cadete
        if (pedidoAReasignar is not null && nuevoCadete is not null && pedidoAReasignar.EstadoActualDelPedido == EstadoPedido.Asignado) //Si ninguno de los dos es falso
        {
            pedidoAReasignar.Cadete = nuevoCadete; //Asigno nuevo cadete
            pedidoReasignado = true; //Cambio la bandera
        }
        return pedidoReasignado; //Devuelvo segun corresponda
    }
    public bool CambiarEstado(int numeroPedido, EstadoPedido nuevoEstado)
    {
        var pedido = BuscarPedido(numeroPedido);
        if (pedido is not null)
        {
            if (pedido.EstadoActualDelPedido == EstadoPedido.Pendiente && (nuevoEstado == EstadoPedido.Asignado || nuevoEstado == EstadoPedido.Cancelado))
            {
                pedido.EstadoActualDelPedido = nuevoEstado;
                return true;
            }
            if (pedido.EstadoActualDelPedido == EstadoPedido.Asignado && nuevoEstado == EstadoPedido.Entregado)
            {
                pedido.EstadoActualDelPedido = nuevoEstado;
                return true;
            }
        }
        return false;
    }
    public double JornalACobrar(int idCadete)
    {
        return CantidadPedidosEntregados(idCadete) * PRECIO_ENTREGA;
    }

    public int CantidadPedidosEntregados(int idCadete)
    {
        int cantPedidos = 0;

        foreach (var pedido in ListadoPedidos)
        {
            if (pedido.EstadoActualDelPedido == EstadoPedido.Entregado && pedido.Cadete != null && pedido.Cadete.Id == idCadete)
                cantPedidos++;
        }
        return cantPedidos;
    }
    public int CantidadPedidosAsignados(int idCadete)
    {
        int cantPedidosAsignados = 0;
        foreach (var pedido in ListadoPedidos)
        {
            if (pedido.EstadoActualDelPedido == EstadoPedido.Asignado && pedido.Cadete != null && pedido.Cadete.Id == idCadete)
            {
                cantPedidosAsignados++;
            }
        }
        return cantPedidosAsignados;
    }
    public int CantidadPedidosIngresados()
    {
        int cantPedidosIngresados = 0;
        foreach (var pedido in ListadoPedidos)
        {
            if (pedido.EstadoActualDelPedido == EstadoPedido.Pendiente)
                cantPedidosIngresados++;
        }
        return cantPedidosIngresados;
    }

    public bool EliminarPedido(int numeroPedido)
    {
        var pedidoAEliminar = BuscarPedido(numeroPedido);
        if (pedidoAEliminar is null) return false;

        if (pedidoAEliminar.EstadoActualDelPedido == EstadoPedido.Cancelado || pedidoAEliminar.EstadoActualDelPedido == EstadoPedido.Pendiente)
        {
            ListadoPedidos.Remove(pedidoAEliminar);
            return true;
        }
        return false;
    }
    public bool EliminarCadete(int idCadeteAEliminar)
    {
        var cadete = BuscarCadetePorId(idCadeteAEliminar);
        var pedidosDelCadete = new List<Pedido>();
        if (cadete is null) return false;
        foreach (var p in ListadoPedidos)
        {
            if (p.Cadete != null && p.Cadete.Id == cadete.Id)
                pedidosDelCadete.Add(p);
        }
        Pedido tienePedidosEntregados = pedidosDelCadete.FirstOrDefault(p => p.EstadoActualDelPedido == EstadoPedido.Entregado);
        if (tienePedidosEntregados != null) return false;
        Pedido tienePedidosAsignados = pedidosDelCadete.FirstOrDefault(p => p.EstadoActualDelPedido == EstadoPedido.Asignado);
        if (tienePedidosAsignados != null) return false;
        ListadoCadetes.Remove(cadete);
        return true;
    }
}