using Microsoft.EntityFrameworkCore;
using Proyecto.Interfaces;
using Proyecto.Models;
using Proyecto.Utilities;

namespace Proyecto.Services;

public class CatalogoService : ICatalogo
{
    private readonly VentasContext _context;
    private ControlError Log = new ControlError();

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
            respuesta.mensaje = "Ok";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "GetCategoria", ex.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> PostCategoria(Categorium categoria)
    {
        var respuesta = new Respuesta();
        try
        {
            var query = _context.Categoria.OrderByDescending(x => x.CategId).Select(x => x.CategId).FirstOrDefault();

            categoria.CategId = Convert.ToInt32(query) + 1;
            categoria.FechaHoraReg = DateTime.Now;

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            respuesta.codigo = "000";
            respuesta.mensaje = "Se insertó correctamente";
        }
        catch (Exception ee)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "PostCategoria", ee.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> PutCategoria(Categorium categoria)
    {
        var respuesta = new Respuesta();
        try
        {
            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();

            respuesta.codigo = "000";
            respuesta.mensaje = "Se insertó correctamente";
        }
        catch (Exception ex)
        {
            Log.LogErrorMetodos("CatalogoService", "PutCategoria", ex.Message);
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
            respuesta.mensaje = "Ok";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "GetMarca", ex.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> PostMarca(Marca marca)
    {
        var respuesta = new Respuesta();
        try
        {
            var query = _context.Marcas.OrderByDescending(x => x.MarcaId).Select(x => x.MarcaId).FirstOrDefault();

            marca.MarcaId = Convert.ToInt32(query) + 1;
            marca.FechaHoraReg = DateTime.Now;

            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            respuesta.codigo = "000";
            respuesta.mensaje = "Se insertó correctamente";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "PostMarca", ex.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> PutMarca(Marca marca)
    {
        var respuesta = new Respuesta();
        try
        {
            _context.Marcas.Update(marca);
            await _context.SaveChangesAsync();

            respuesta.codigo = "000";
            respuesta.mensaje = "Se insertó correctamente";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "PutMarca", ex.Message);
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
            respuesta.mensaje = "Ok";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "GetModelo", ex.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> PostModelo(Modelo modelo)
    {
        var respuesta = new Respuesta();
        try
        {
            var query = _context.Modelos.OrderByDescending(x => x.ModeloId).Select(x => x.ModeloId).FirstOrDefault();

            modelo.ModeloId = Convert.ToInt32(query) + 1;
            modelo.FechaHoraReg = DateTime.Now;

            _context.Modelos.Add(modelo);
            await _context.SaveChangesAsync();

            respuesta.codigo = "000";
            respuesta.mensaje = "Se insertó correctamente";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "PostModelo", ex.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> PutModelo(Modelo modelo)
    {
        var respuesta = new Respuesta();
        try
        {
            _context.Modelos.Update(modelo);
            await _context.SaveChangesAsync();

            respuesta.codigo = "000";
            respuesta.mensaje = "Se insertó correctamente";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "PutModelo", ex.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> GetCaja()
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta.codigo = "000";
            respuesta.data = await _context.Cajas.ToListAsync();
            respuesta.mensaje = "Ok";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "GetCaja", ex.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> PostCaja(Caja caja)
    {
        var respuesta = new Respuesta();
        try
        {
            var query = _context.Cajas.OrderByDescending(x => x.CajaId).Select(x => x.CajaId).FirstOrDefault();

            caja.CajaId = Convert.ToInt32(query) + 1;

            _context.Cajas.Add(caja);
            await _context.SaveChangesAsync();

            respuesta.codigo = "000";
            respuesta.mensaje = "Se insertó correctamente";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "PostCaja", ex.Message);
        }
        return respuesta;
    }

    public async Task<Respuesta> GetCiudad()
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta.codigo = "000";
            respuesta.data = await _context.Ciudads.ToListAsync();
            respuesta.mensaje = "Ok";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            Log.LogErrorMetodos("CatalogoService", "GetCiudad", ex.Message);
        }
        return respuesta;
    }
}