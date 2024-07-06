using Microsoft.EntityFrameworkCore;
using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Services;

public class ClienteService : ICliente
{
    private readonly VentasContext _context;
    
    public ClienteService(VentasContext context)
    {
        this._context = context;
    }
    
    public async Task<Respuesta> GetCliente(double clienteId, string? nombre, double identificacion)
    {
        var respuesta = new Respuesta();
        try
        {
            var query = _context.Clientes;
            
            if (clienteId == 0 && nombre == null && identificacion == 0)
            {
                respuesta.codigo = "000";
                /*
                respuesta.data = await query.Where(x => x.Estado.Equals("A")).ToListAsync();
                */
                respuesta.data = await (from c in query
                        where(c.Estado.Equals("A"))
                        select c
                    ).ToListAsync();
                respuesta.mensaje = "OK";
            }
            if (clienteId != 0 && nombre == null && identificacion == 0)
            {
                respuesta.codigo = "000";
                /*
                respuesta.data = await query.Where(x => x.ClienteId.Equals(clienteId)).ToListAsync();
                */
                respuesta.data = await (from c in query
                        where(c.ClienteId.Equals(clienteId))
                        select c
                    ).ToListAsync();
                respuesta.mensaje = "OK";
            }
            if (clienteId == 0 && nombre != null && identificacion == 0)
            {
                respuesta.codigo = "000";
                /*
                respuesta.data = await query.Where(x => x.ClienteNombre.Equals(nombre)).ToListAsync();
                */
                respuesta.data = await (from c in query
                        where(c.ClienteNombre.Equals(nombre))
                        select c
                    ).ToListAsync();
                respuesta.mensaje = "OK";
            }
            if (clienteId == 0 && nombre == null && identificacion != 0)
            {
                respuesta.codigo = "000";
                /*
                respuesta.data = await query.Where(x => x.Cedula.Equals(identificacion)).ToListAsync();
                */
                respuesta.data = await (from c in query
                        where(c.Cedula.Equals(identificacion))
                        select c
                    ).ToListAsync();
                respuesta.mensaje = "OK";
            }
            if (clienteId != 0 && nombre != null && identificacion != 0)
            {
                respuesta.codigo = "000";
                /*
                respuesta.data = await query.Where(x=>x.Estado.Equals("A") && x.ClienteId.Equals(clienteId) && x.ClienteNombre.Equals(nombre) && x.Cedula.Equals(identificacion)).ToListAsync();
                */
                respuesta.data = await (from c in query
                        where(c.ClienteId.Equals(clienteId) && c.ClienteNombre.Equals(nombre) && c.Estado.Equals("A") && c.Cedula.Equals(identificacion))
                        select c
                    ).ToListAsync();
                respuesta.mensaje = "OK";
            }
        }
        catch (Exception e)
        {
            respuesta.codigo = "999";
            respuesta.mensaje = $"Se presento une erro: {e.Message}";
            throw;
        }

        return respuesta;
    }
}