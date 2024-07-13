using Microsoft.EntityFrameworkCore;
using Proyecto.DTOs;
using Proyecto.Models;
using Proyecto.Interfaces;
using Proyecto.Utilities;

namespace Proyecto.Services;
public class VentasServices : IVentas
{
    private readonly VentasContext _context;
    private ControlError log = new ControlError();

    public VentasServices(VentasContext context)
    {
        this._context = context;
    }

    public async Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteId)
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta.codigo = "000";
            IQueryable<VentasDto> query = (from v in _context.Ventas
                join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                join p in _context.Productos on v.ProductoId equals p.ProductoId
                join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                join ca in _context.Categoria on v.CategId equals ca.CategId
                join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                join cc in _context.Cajas on v.CajaId equals cc.CajaId
                join vv in _context.Vendedors on v.VendedorId equals vv.VendedorId
                select new VentasDto
                {
                    IdFactura = v.IdFactura,
                    NumFact = v.NumFact,
                    FechaHora = v.FechaHora,
                    ClienteId = cl.ClienteId,
                    ClienteNombre = cl.ClienteNombre,
                    ProductoNombre = p.ProductoDescrip,
                    ModeloNombre = mo.ModeloDescripción,
                    CategNombre = ca.CategNombre,
                    MarcaNombre = ma.MarcaNombre,
                    SucursalNombre = su.SucursalNombre,
                    CajaNombre = cc.CajaDescripcion,
                    VendedorId = v.VendedorId,
                    VendedorNombre = vv.VendedorDescripcion,
                    Precio = v.Precio,
                    Unidades = v.Unidades,
                    Estado = v.Estado
                });
            if (!string.IsNullOrEmpty(numFactura) && numFactura != "0")
            {
                query = query.Where(n => n.NumFact == numFactura);
            }

            if (!string.IsNullOrEmpty(numFactura) && numFactura != "0" && precio != 0)
            {
                query = query.Where(n => n.NumFact == numFactura && n.Precio == precio);
            }

            if (precio != 0)
            {
                query = query.Where(n => n.Precio == precio);
            }

            if (vendedor != 0)
            {
                query = query.Where(n => n.VendedorId == vendedor);
            }

            if (clienteId != 0)
            {
                query = query.Where(n => n.ClienteId == clienteId);
            }
            

            respuesta.data = await query.ToListAsync();
            respuesta.mensaje = "Ok";
        }
        catch (Exception ee)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
            log.LogErrorMetodos("VentasServices", "GetVentas", ee.Message);
        }

        return respuesta;
    }

    public async Task<Respuesta> GetVentaReporte()
    {
        var respuesta = new Respuesta();
        try
        {
            respuesta.codigo = "000";

            respuesta.data = await _context.Ventas
                .Where(v => v.Precio > 100)
                .GroupBy(v => v.Precio)
                .Select(g => new
                {
                    CantidadRegistro = g.Count(),
                    ValorConsultado = g.Key
                }).ToListAsync();
            respuesta.mensaje = "OK";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return respuesta;
    }
    public async Task<Respuesta> PostVenta(Venta venta)
    {
        var respuesta = new Respuesta();
        try
        {
            var query = _context.Ventas.OrderByDescending(x => x.IdFactura).Select(x => x.IdFactura)
                .FirstOrDefault();

            venta.IdFactura = Convert.ToInt32(query) + 1;

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            respuesta.codigo = "999";
            respuesta.mensaje = "Ok";
        }
        catch (Exception ex)
        {
            respuesta.codigo = "000";
            respuesta.mensaje = $"Se ha generado una novedad , error {ex.Message}";
        }

        return respuesta;
    }
}
