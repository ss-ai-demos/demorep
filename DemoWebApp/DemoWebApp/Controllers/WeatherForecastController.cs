using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Security.Claims;

namespace DemoWebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a collection of weather forecasts for the next five days.
        /// </summary>
        /// <remarks>Each forecast includes the date, temperature in Celsius, temperature in Fahrenheit, 
        /// and a summary description. The temperature values are randomly generated within a predefined range, and the
        /// summary is selected randomly from a predefined set of options.</remarks>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="WeatherForecast"/> objects representing the weather forecasts
        /// for the next five days.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index =>
            {
                var tempC = Random.Shared.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = tempC,
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            })
            .ToArray();
        }

        /// <summary>
        /// Reverses the input string.
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        [HttpPost("ReverseString")]
        public ActionResult<string> ReverseString([FromBody] string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("Input string cannot be null or empty.");
            }
            var reversed = new string(input.Reverse().ToArray());
            return Ok(reversed);
        }

        /// <summary>
        /// Reverses the digits of the input integer.
        /// </summary>
        /// <param name="input">The integer to reverse.</param>
        /// <returns>The reversed integer as a string.</returns>
        [HttpPost("ReverseInt")]
        public ActionResult<int> ReverseInt([FromBody] int input)
        {
            bool isNegative = input < 0;
            string digits = Math.Abs(input).ToString();
            string reversedDigits = new string(digits.Reverse().ToArray());
            string result = isNegative ? "-" + reversedDigits : reversedDigits;
            if (int.TryParse(result, out int reversedInt))
            {
                return Ok(reversedInt);
            }
            return BadRequest("Reversed integer is out of range.");
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
