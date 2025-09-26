using System.Text.Json;

namespace ApiWeb;

public class AccesoADatosPedidos
{
    private string path = "Datos/pedidos.json";
    public List<Pedido> CargarPedidos()
    {
        var pedidos = new List<Pedido>();
        if (File.Exists(path))
        {
            string txtJson = File.ReadAllText(path);
            pedidos = JsonSerializer.Deserialize<List<Pedido>>(txtJson);
        }
        return pedidos;
    }
    
    public void GuardarPedidos(List<Pedido> pedidoNuevo)
    {
        using (FileStream archivo = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter escribirPedido = new StreamWriter(archivo))
            {
                var archivoAGuardar = JsonSerializer.Serialize<List<Pedido>>(pedidoNuevo);
                escribirPedido.WriteLine(archivoAGuardar);
            }
        }
    }}