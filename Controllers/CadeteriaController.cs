using Microsoft.AspNetCore.Mvc;
using ApiWeb;

namespace tl2_tp4_2025_nicoodiaz.Controllers;

[ApiController]
[Route("api/cadeteria")]
public class CadeteriaController : ControllerBase
{
    private Cadeteria laCadeteria;
    private AccesoADatosJSON accesoADatos;
    public CadeteriaController()
    {
        accesoADatos = new AccesoADatosJSON();
        //var Cadeteria = accesoADatos.CrearCadeteria("../Datos/cadeteria.json");
        laCadeteria = Cadeteria.GetCadeteria();
    }

    [HttpGet("pedidos")]
    public IActionResult GetPedidos()
    {
        var listado = laCadeteria.GetPedidos();
        if (listado is null) return NotFound();
        return Ok(laCadeteria.GetPedidos());
    }
    [HttpGet("cadetes")]
    public IActionResult GetCadete()
    {
        var cadetes = laCadeteria.GetCadetes();
        if (cadetes is null) return NotFound();
        return Ok(cadetes);
    }

    [HttpGet("informe")]
    public IActionResult GetInforme()
    {
        var informe = new Informe();
        string informeParaJSON = informe.GenerarInformeJSON(laCadeteria);
        return Ok(informeParaJSON);
    }
    [HttpPost("agregarPedido/{pedido}")]
    public IActionResult AgregarPedido(Pedido pedido)
    {
        if (!laCadeteria.DarAltaPedido(pedido.NumeroPedido, pedido.Observacion)) return NotFound("Fallo al crear pedido");
        return Ok("Pedido Creado");
    }

    [HttpPut("asignar")]
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        if (!laCadeteria.AsignarCadetePedido(idPedido, idCadete)) return NotFound("Fallo al asignar pedido");
        return Ok("Pedido asignado");
    }
/* 
    [HttpPut("cambiarEstado")]
    public IActionResult CambiarEstadoPedido(int idPedido, int nuevoEstado)
    {
        if (!laCadeteria.CambiarEstado(idPedido, nuevoEstado)) return NotFound("No se pudo cambiar estado");
        return Ok("Estado cambiado");
    }
 */
    [HttpPut("reasignar")]
    public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        if (!laCadeteria.ReasignarPedido(idPedido, idNuevoCadete)) return NotFound("No se cambio el cadete");
        return Ok("Cadete reasignado");
    }
}