using System.Net.Http.Headers;

namespace Benchmark;

public class APIMinimalClient
{
    private readonly HttpClient _httpClient;

    public APIMinimalClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task TestWeatherForecast()
    {
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.GetAsync("https://localhost:7163/WeatherForecast");

        if (response.IsSuccessStatusCode) _ = await response.Content.ReadAsStringAsync();
    }
}