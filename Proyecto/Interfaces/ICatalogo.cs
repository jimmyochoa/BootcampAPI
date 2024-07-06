using Proyecto.Models;

namespace Proyecto.Interfaces;

public interface ICatalogo
{
    Task<Respuesta> GetCategoria();
    Task<Respuesta> GetMarca();
    Task<Respuesta> GetModelo();
    Task<Respuesta> GetSucursal();
}