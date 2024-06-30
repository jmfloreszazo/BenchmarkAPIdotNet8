using FastEndpoints;
using System.Linq;

public class WeatherForecastEndpoint : EndpointWithoutRequest<WeatherForecastResponse[]>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/weatherforecast");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastResponse
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
            .ToArray();

        await SendAsync(forecast, cancellation: ct);
    }
}

public record WeatherForecastResponse(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}