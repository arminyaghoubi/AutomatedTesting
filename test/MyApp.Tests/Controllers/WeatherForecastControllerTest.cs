using Microsoft.Extensions.Logging;
using MyApp.Controllers;

namespace MyApp.Tests.Controllers;

public class WeatherForecastControllerTest
{
    public class Get : WeatherForecastControllerTest
    {
        [Fact]
        public void Should_be_temperature_between_two_number()
        {
            //Arrange
            var controller = new WeatherForecastController();

            //Act
            var result = controller.Get();

            //Assert
            foreach (var item in result)
            {
                Assert.InRange(item.TemperatureC, -20, 54);
            }
        }
    }
}