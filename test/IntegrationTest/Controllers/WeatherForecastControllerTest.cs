using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace IntegrationTests.Controllers;

public class WeatherForecastControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private const string _url = "/WeatherForecast";
    private readonly HttpClient _client;

    public WeatherForecastControllerTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    public class Get : WeatherForecastControllerTest
    {
        public Get(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_be_response_200()
        {
            //Act
            var response = await _client.GetAsync(_url);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
