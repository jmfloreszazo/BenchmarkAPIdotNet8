using System.Net.Http.Headers;

namespace Benchmark;

public class APIControllerClient
{
    private readonly HttpClient _httpClient;

    public APIControllerClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task TestWeatherForecast()
    {
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.GetAsync("https://localhost:7002/WeatherForecast");

        if (response.IsSuccessStatusCode) _ = await response.Content.ReadAsStringAsync();
    }
}