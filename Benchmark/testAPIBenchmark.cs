using BenchmarkAPI;
using BenchmarkDotNet.Attributes;

namespace Benchmark;

[HtmlExporter]
public class testAPIBenchmark
{
    [Params(10, 20)]
    public int IterationCount;

    private readonly APIControllerClient _apiControllerClient= new APIControllerClient();
    private readonly APIMinimalClient _apiMinimalClient= new APIMinimalClient();
    private readonly APIFastEndpointClient _apiFastEndpointClient = new APIFastEndpointClient();

    [Benchmark]
    public async Task TestRestAPIControllerAsync()
    {
        for (int i = 0; i < IterationCount; i++)
        {
            await _apiControllerClient.TestWeatherForecast();
        }
    }

    [Benchmark]
    public async Task TestRestAPIMinimalAsync()
    {
        for (int i = 0; i < IterationCount; i++)
        {
            await _apiMinimalClient.TestWeatherForecast();
        }
    }

    [Benchmark]
    public async Task TestRestAPIFastEndpointAsync()
    {
        for (int i = 0; i < IterationCount; i++)
        {
            await _apiFastEndpointClient.TestWeatherForecast();
        }
    }

}