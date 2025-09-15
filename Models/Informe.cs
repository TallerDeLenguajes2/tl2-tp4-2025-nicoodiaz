using System.Text.Json;
using ApiWeb;

public class InformeCadete
{
    private int idCadete;
    private string direccionCadete;
    private int cantPedidosEntregados;
    private int cantPedidosAsignados;
    private int cantPedidosIngresados;
    private double montoGanado;

    public int IdCadete { get => idCadete; set => idCadete = value; }
    public string DireccionCadete { get => direccionCadete; set => direccionCadete = value; }
    public int CantPedidosEntregados { get => cantPedidosEntregados; set => cantPedidosEntregados = value; }
    public int CantPedidosAsignados { get => cantPedidosAsignados; set => cantPedidosAsignados = value; }
    public int CantPedidosIngresados { get => cantPedidosIngresados; set => cantPedidosIngresados = value; }
    public double MontoGanado { get => montoGanado; set => montoGanado = value; }
}

public class Informe
{
    List<InformeCadete> informeParaCadete;

    public Informe()
    {
        informeParaCadete = new List<InformeCadete>();
    }

    public List<InformeCadete> generarInforme(Cadeteria cadeteria)
    {
        foreach (var cadete in cadeteria.GetCadetes())
        {
            var informe = new InformeCadete
            {
                IdCadete = cadete.Id,
                DireccionCadete = cadete.Direccion,
                CantPedidosEntregados = cadeteria.CantidadPedidosEntregados(cadete.Id),
                CantPedidosAsignados = cadeteria.CantidadPedidosAsignados(cadete.Id),
                CantPedidosIngresados = cadeteria.CantidadPedidosIngresados(),
                MontoGanado = cadeteria.JornalACobrar(cadete.Id)
            };
            informeParaCadete.Add(informe);
        }
        return informeParaCadete;
    }
    public string GenerarInformeJSON(Cadeteria cadeteria)
    {
        var informes = generarInforme(cadeteria);
        return JsonSerializer.Serialize(informes);
    }

}