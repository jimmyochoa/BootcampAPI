using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Utilities;

namespace Proyecto.Controllers;

[ApiController]
[Route("[controller]")]
public class ExtrasController : Controller
{
    private ControlError log = new ControlError();
    private PokeApi pokeApi = new PokeApi();
    private readonly IConfiguration _configuration;

    public ExtrasController(IConfiguration configuration)
    {
        this._configuration = configuration;
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
        }

        return respuesta;
    }
}