using Microsoft.AspNetCore.Mvc;
using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogoController : Controller
{
    private readonly ICatalogo _catalogo;

    public CatalogoController(ICatalogo catalogo) 
    {
        this._catalogo = catalogo;
    }

    [HttpGet]
    [Route("GetCategoria")]
    public async Task<Respuesta> GetCategoria()
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta = await _catalogo.GetCategoria();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return respuesta;
    }

    [HttpGet]
    [Route("GetMarca")]
    public async Task<Respuesta> GetMarca()
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta = await _catalogo.GetMarca();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return respuesta;
    }

    [HttpGet]
    [Route("GetModelo")]
    public async Task<Respuesta> GetModelo()
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta = await _catalogo.GetModelo();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return respuesta;
    }

    [HttpGet]
    [Route("GetSucursal")]
    public async Task<Respuesta> GetSucursal()
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta = await _catalogo.GetSucursal();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return respuesta;
    }
}