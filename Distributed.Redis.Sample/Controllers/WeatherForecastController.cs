namespace Distributed.Redis.Sample.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const string WeatherForecastCacheKey = "WEATHER_FORECAST_LIST";

        private static readonly string[] s_summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ICacheService _cacheService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheService cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

            var result = await _cacheService.GetAsync<IEnumerable<WeatherForecast>>(WeatherForecastCacheKey);
            if (result == null)
            {
                result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = s_summaries[Random.Shared.Next(s_summaries.Length)]
                }).ToArray();

                await _cacheService.SetAsync(WeatherForecastCacheKey, result);
            }

            return result;
        }
    }
}
