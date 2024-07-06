using Microsoft.AspNetCore.Mvc;
using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : Controller
{
    public readonly ICliente _cliente;
    
    public ClienteController(ICliente cliente)
    {
        this._cliente = cliente;
    }
    
    [HttpGet]
    [Route("GetCliente")]
    public async Task<Respuesta> GetCliente(double clienteId, string? nombre, double identificacion)
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta = await _cliente.GetCliente(clienteId, nombre, identificacion);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return respuesta;
    }
}

