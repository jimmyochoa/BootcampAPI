using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto.DTOs;
using Proyecto.Models;

namespace Proyecto.Utilities
{
    public class JokesApi
    {
        private readonly ControlError _log = new ControlError();

        public async Task<Respuesta> GetJokes(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    
                    var json = await response.Content.ReadAsStringAsync();
                    respuesta.codigo = "000";

                    if (url.Contains("/search"))
                    {
                        respuesta.data = JsonConvert.DeserializeObject<JokesApiQuery>(json);
                    }
                    else if (url.Contains("/random"))
                    {
                        respuesta.data = JsonConvert.DeserializeObject<JokesApiRandom>(json);
                    }
                    
                    respuesta.mensaje = "Se consumió correctamente";
                }
            }
            catch (Exception e)
            {
                _log.LogErrorMetodos("JokesApi", "GetJokes", e.Message);
                respuesta.codigo = "999";
                respuesta.mensaje = "Error al consumir el servicio";
            }

            return respuesta;
        }

        public async Task<Respuesta> GetJokeCategories(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    
                    var json = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<List<string>>(json);

                    respuesta.codigo = "000";
                    respuesta.data = categories;
                    respuesta.mensaje = "Se consumió correctamente";
                }
            }
            catch (Exception e)
            {
                _log.LogErrorMetodos("JokesApi", "GetJokeCategories", e.Message);
                respuesta.codigo = "999";
                respuesta.mensaje = "Error al consumir el servicio";
            }

            return respuesta;
        }
    }
}
