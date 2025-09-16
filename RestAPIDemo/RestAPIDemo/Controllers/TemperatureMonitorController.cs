using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestAPIDemo.Controllers
{
    /// <summary>
    /// Controller for monitoring temperature.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TemperatureMonitorController : ControllerBase
    {
        private readonly ILogger<TemperatureMonitorController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureMonitorController"/> class.
        /// </summary>
        /// <param name="logger">Logger instance for the controller.</param>
        public TemperatureMonitorController(ILogger<TemperatureMonitorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Monitors and returns the current temperature in Celsius.
        /// </summary>
        /// <returns>The current temperature in Celsius.</returns>
        [HttpGet("MonitorTemperature")]
        public ActionResult<int> MonitorTemperature()
        {
            // Simulate temperature monitoring (replace with actual logic as needed)
            int currentTemperatureC = Random.Shared.Next(-20, 55);
            _logger.LogInformation($"Monitored temperature: {currentTemperatureC}°C");
            return Ok(currentTemperatureC);
        }
    }
}