using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Interfaces;
using Models;

public interface IProducto
{
    Task<Respuesta> GetListaProductos(int productoID, float precio);
    Task<Respuesta> PostProducto(Producto producto);
    Task<Respuesta> PutProducto(Producto producto);
}