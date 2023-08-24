using ApiGatewayBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGatewayBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IHttpClientFactory _httpClientFactory;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IHttpClientFactory httpClientFactory, ILogger<WeatherForecastController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> Get()
        {
            List<WeatherForecast> lista = new List<WeatherForecast>();

            var clienteMongo = _httpClientFactory.CreateClient("Mongo");
            var response = await clienteMongo.GetAsync("/WeatherForecast");
            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true 
                };
                var resultado = JsonSerializer.Deserialize<List<WeatherForecast>>(contenido, options);
                lista.AddRange(resultado!);
            }

            var clienteSql = _httpClientFactory.CreateClient("Sql");
            response = await clienteSql.GetAsync("/WeatherForecast");
            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var resultado = JsonSerializer.Deserialize<List<WeatherForecast>>(contenido, options);
                lista.AddRange(resultado!);
            }
            return lista;
        }
    }
}