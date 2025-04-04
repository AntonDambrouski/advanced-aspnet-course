using Microsoft.AspNetCore.Mvc;
using MovieManagerApi.Servers;

namespace MovieManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly WeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController()
        {
            _weatherService = new WeatherService();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(int minTemperatureC)
        {
            var forecasts = _weatherService.GetAll();
            return forecasts.Where(forecasts => forecasts.TemperatureC >= minTemperatureC);
        }

        [HttpGet("{id:guid}", Name = "GetWeatherForecastById")]
        public ActionResult<WeatherForecast> Get(Guid id)
        {
            var forecast = _weatherService.Get(id);
            if (forecast == null)
            {
                return NotFound();
            }

            return forecast;
        }

        [HttpPost(Name = "AddWeatherForecast")]
        public ActionResult<WeatherForecast> Post(WeatherForecast forecast)
        {
            _weatherService.Add(forecast);

            return CreatedAtRoute("GetWeatherForecastById", new { id = forecast.Id }, forecast);
        }
    }
}
