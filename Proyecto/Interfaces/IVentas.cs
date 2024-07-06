using Proyecto.Models;

namespace Proyecto.Interfaces;

public interface IVentas
{
    Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteId);
    Task<Respuesta> PostVenta(Venta venta);
    Task<Respuesta> GetVentaReporte();
}
