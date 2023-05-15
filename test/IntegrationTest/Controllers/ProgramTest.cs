using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace IntegrationTests.Controllers;

public class ProgramTest : IClassFixture<WebApplicationFactory<Program>>
{
    private const string _url = "/";
    private readonly HttpClient _client;

    public ProgramTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    public class Get : ProgramTest
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

        [Theory]
        [InlineData("ArminYaghoubi1@gmail.com")]
        public async Task Should_be_response_email(string email)
        {
            //Act
            var response = await _client.GetStringAsync(_url);

            //Assert
            Assert.Equal(email, response);
        }
    }
}