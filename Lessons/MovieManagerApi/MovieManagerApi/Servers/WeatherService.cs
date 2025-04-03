namespace MovieManagerApi.Servers;

public class WeatherService
{
    private static readonly List<WeatherForecast> _forecasts = new();

    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    static WeatherService()
    {
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
             .ToArray();

        _forecasts.AddRange(forecasts);
    }

    public List<WeatherForecast> GetAll() => _forecasts;

    public WeatherForecast? Get(Guid id) => _forecasts.FirstOrDefault(f => f.Id == id);

    public void Add(WeatherForecast forecast) => _forecasts.Add(forecast);
}
