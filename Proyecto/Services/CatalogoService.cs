using Microsoft.EntityFrameworkCore;
using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Services;

public class CatalogoService : ICatalogo
{
    private readonly VentasContext _context;

    public CatalogoService(VentasContext context) 
    {
        this._context = context;
    }

    public async Task<Respuesta> GetCategoria()
    {
		var respuesta = new Respuesta();

		try
		{
            respuesta.codigo = "000";
            respuesta.data = await _context.Categoria.ToListAsync();
            respuesta.mensaje = "OK";

        }
		catch (Exception ex)
		{
            respuesta.codigo = "999";
            respuesta.mensaje = $"Me a presentado una novedad en el Metodo: GetCategoria, Error: {ex.Message}";

        }
        return respuesta;
    }

    public async Task<Respuesta> GetMarca()
    {
        var respuesta = new Respuesta();

        try
        {
            respuesta.codigo = "000";
            respuesta.data = await _context.Marcas.ToListAsync();
            respuesta.mensaje = "OK";

        }
        catch (Exception ex)
        {
            respuesta.codigo = "999";
            respuesta.mensaje = $"Me a presentado una novedad en el Metodo: GetMarca, Error: {ex.Message}";

        }
        return respuesta;
    }

    public async Task<Respuesta> GetModelo()
    {
        var respuesta = new Respuesta();

        try
        {
            respuesta.codigo = "000";
            respuesta.data = await _context.Modelos.ToListAsync();
            respuesta.mensaje = "OK";

        }
        catch (Exception ex)
        {
            respuesta.codigo = "999";
            respuesta.mensaje = $"Me a presentado una novedad en el Metodo: GetModelo, Error: {ex.Message}";

        }
        return respuesta;
    }

    public async Task<Respuesta> GetSucursal()
    {
        var respuesta = new Respuesta();

        try
        {
            respuesta.codigo = "000";
            respuesta.data = await _context.Sucursals.ToListAsync();
            respuesta.mensaje = "OK";

        }
        catch (Exception ex)
        {
            respuesta.codigo = "999";
            respuesta.mensaje = $"Me a presentado una novedad en el Metodo: GetSucursal, Error: {ex.Message}";

        }
        return respuesta;
    }
}