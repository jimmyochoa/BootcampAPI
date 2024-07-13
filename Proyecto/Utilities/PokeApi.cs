using Newtonsoft.Json;
using Proyecto.DTOs;
using Proyecto.Models;

namespace Proyecto.Utilities;

public class PokeApi
{
    private ControlError log = new ControlError();

    public async Task<Respuesta> GetPokeApi(string url)
    {
        var respuesta = new Respuesta();
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            respuesta.codigo = "000";
            respuesta.data =JsonConvert.DeserializeObject<PokeApiDto>(json);
            respuesta.mensaje = "Se consumio correctamente";

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return respuesta;
    }
}