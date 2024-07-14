using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Utilities;
using System.Threading.Tasks;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtrasController : ControllerBase
    {
        private ControlError log = new ControlError();
        private JokesApi jokesApi = new JokesApi();
        private PokeApi pokeApi = new PokeApi();
        private readonly IConfiguration _configuration;

        public ExtrasController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("SearchJokesByQuery")]
        public async Task<Respuesta> SearchJokesByQuery(string query)
        {
            var respuesta = new Respuesta();
            try
            {
                var baseUrl = _configuration.GetSection("Keys:UrlJokesApi").Value;
                var url = $"{baseUrl}/search?query={query}";
                respuesta = await jokesApi.GetJokes(url);
            }
            catch (Exception e)
            {
                log.LogErrorMetodos("ExtrasController", "SearchJokesByQuery", e.Message);
                respuesta.codigo = "999";
                respuesta.mensaje = "Error al consumir el servicio";
            }

            return respuesta;
        }
        
        [HttpGet]
        [Route("GetRandomJokes")]
        public async Task<Respuesta> GetRandomJokes(string category)
        {
            var respuesta = new Respuesta();
            try
            {
                var baseUrl = _configuration.GetSection("Keys:UrlJokesApi").Value;
                var url = $"{baseUrl}/random/?category={category}";
                respuesta = await jokesApi.GetJokes(url);
            }
            catch (Exception e)
            {
                log.LogErrorMetodos("ExtrasController", "GetRandomJokes", e.Message);
                respuesta.codigo = "999";
                respuesta.mensaje = "Error al consumir el servicio";
            }

            return respuesta;
        }
        
        [HttpGet]
        [Route("GetJokesCategories")]
        public async Task<Respuesta> GetJokesCategories()
        {
            var respuesta = new Respuesta();
            try
            {
                var baseUrl = _configuration.GetSection("Keys:UrlJokesApi").Value;
                var url = $"{baseUrl}/categories";
                respuesta = await jokesApi.GetJokeCategories(url);
            }
            catch (Exception e)
            {
                log.LogErrorMetodos("ExtrasController", "GetJokesCategories", e.Message);
                respuesta.codigo = "999";
                respuesta.mensaje = "Error al consumir el servicio";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("GetPokeApi")]
        public async Task<Respuesta> GetPokeApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlPokeApi").Value;
                respuesta = await pokeApi.GetPokeApi(url);
            }
            catch (Exception e)
            {
                log.LogErrorMetodos("ExtrasController", "GetPokeApi", e.Message);
                respuesta.codigo = "999";
                respuesta.mensaje = "Error al consumir el servicio";
            }

            return respuesta;
        }
    }
}
