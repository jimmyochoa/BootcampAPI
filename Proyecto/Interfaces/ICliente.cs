using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Proyecto.Models;

namespace Proyecto.Interfaces;

public interface ICliente
{
    Task<Respuesta> GetCliente(double clienteId, string? nombre, double identificacion);
    Task<Respuesta> PostCliente(Cliente cliente);
    Task<Respuesta> PutCliente(Cliente cliente);
}