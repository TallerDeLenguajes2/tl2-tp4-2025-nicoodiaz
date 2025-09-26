using System.Text.Json;
using ApiWeb;

public class InformeCadete
{

    public int IdCadete { get; set; }
    public string DireccionCadete { get; set; }
    public int CantPedidosEntregados { get; set; }
    public int CantPedidosAsignados { get; set; }
    public int CantPedidosIngresados { get; set; }
    public double MontoGanado { get; set; }
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