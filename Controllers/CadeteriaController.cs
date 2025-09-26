using Microsoft.AspNetCore.Mvc;
using ApiWeb;

namespace tl2_tp4_2025_nicoodiaz.Controllers;

[ApiController]
[Route("api/cadeteria")]
public class CadeteriaController : ControllerBase
{
    private readonly Cadeteria laCadeteria;
    private AccesoADatosCadeteria ADCadeteria;
    private AccesoADatosCadetes ADCadetes;
    private AccesoADatosPedidos ADPedidos;
    public CadeteriaController()
    {
        ADCadeteria = new AccesoADatosCadeteria();
        ADCadetes = new AccesoADatosCadetes();
        ADPedidos = new AccesoADatosPedidos();
        laCadeteria = ADCadeteria.CrearCadeteria();
        //laCadeteria = Cadeteria.GetCadeteria();
        laCadeteria.ListadoCadetes = ADCadetes.CargarCadete();
        laCadeteria.ListadoPedidos = ADPedidos.CargarPedidos();
    }

    [HttpGet("cadeteria")]
    public IActionResult GetCadeteria()
    {
        string info = $"{laCadeteria.Nombre} | {laCadeteria.Telefono}";
        return Ok(info);
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
    [HttpPost("agregarPedido")]
    public IActionResult AgregarPedido(int nroPedido, string observacion)
    {
        if (!laCadeteria.DarAltaPedido(nroPedido, observacion)) return BadRequest("Fallo al crear pedido");
        ADPedidos.GuardarPedidos(laCadeteria.ListadoPedidos);
        return Created();
    }

    [HttpPut("asignar")]
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        if (!laCadeteria.AsignarCadetePedido(idPedido, idCadete)) return NotFound("Fallo al asignar pedido");
        ADPedidos.GuardarPedidos(laCadeteria.ListadoPedidos);
        return Ok("Pedido asignado");
    }

    [HttpPut("cambiarEstado")]
    public IActionResult CambiarEstadoPedido(int idPedido, EstadoPedido nuevoEstado)
    {
        if (!laCadeteria.CambiarEstado(idPedido, nuevoEstado)) return NotFound("No se pudo cambiar estado");
        ADPedidos.GuardarPedidos(laCadeteria.ListadoPedidos);
        return Ok("Estado cambiado");
    }

    [HttpPut("reasignar")]
    public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        if (!laCadeteria.ReasignarPedido(idPedido, idNuevoCadete)) return NotFound("No se cambio el cadete");
        ADPedidos.GuardarPedidos(laCadeteria.ListadoPedidos);
        return Ok("Cadete reasignado");
    }
}