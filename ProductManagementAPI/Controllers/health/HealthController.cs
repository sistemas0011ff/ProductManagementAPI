using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ProductManagementAPI.Controllers.health
{

    /// <summary>
    /// Controller that provides information about the application's health status.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // <summary>
        /// Initializes a new instance of the <see cref="HealthController"/> class.
        /// </summary>
        /// <param name="configuration">The application's configuration settings.</param>
        public HealthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Retrieves the current health status of the application.
        /// </summary>
        /// <remarks>
        /// Example request:
        ///
        ///     GET /health
        ///
        /// </remarks>
        /// <returns>An object containing the health information of the application.</returns>
        /// <response code="200">Returns the health status of the application.</response>
        [HttpGet]
        public IActionResult Get()
        {
            var health = new
            {
                Status = "ok",
                Assembly.GetEntryAssembly()?.GetName().Name,
                Version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString(),
                Environment = _configuration.GetValue<string>("Environment") // Assuming you have Environment in appsettings.json or similar
            };

            return Ok(health);
        }
    }
}
