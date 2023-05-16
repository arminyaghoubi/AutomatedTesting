using Microsoft.AspNetCore.Mvc.Testing;
using MyApp;

namespace IntegrationTests.Controllers;

public class ProgramTestWithoutFixture : IAsyncDisposable
{
    private readonly WebApplicationFactory<WeatherForecast> _factory;
    private readonly HttpClient _client;

    public ProgramTestWithoutFixture()
    {
        _factory = new WebApplicationFactory<WeatherForecast>();
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Should_not_be_empty()
    {
        //Act
        var response = await _client.GetStringAsync("/");

        //Assert
        Assert.NotEqual(string.Empty, response);
    }

    public async ValueTask DisposeAsync()
    {
        _client.Dispose();
        await _factory.DisposeAsync();
    }
}