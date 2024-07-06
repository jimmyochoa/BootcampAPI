using Proyecto.Models;

namespace Proyecto.Controllers;

using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Interfaces;

[ApiController]
[Route("[controller]")]
public class VentasController : Controller
{
    private readonly IVentas _ventas;
    public VentasController(IVentas ventas)
    {
        this._ventas = ventas;
    }

    [HttpGet]
    [Route("GetVentasReporte")]
    public async Task<Respuesta> GetVentaReporte()
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta = await _ventas.GetVentaReporte();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return respuesta;
    }
    
    [HttpGet]
    [Route("GetVentas")]
    public async Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteId)
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta = await _ventas.GetVentas(numFactura, precio, vendedor, clienteId);
        }
        catch (Exception)
        {

            throw;
        }
        return respuesta;
    }

    [HttpGet]
    [Route("PostVenta")]
    public async Task<Respuesta> PostVenta(Venta venta)
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta = await _ventas.PostVenta(venta);
        }
        catch (Exception)
        {

            throw;
        }
        return respuesta;
    }
}
