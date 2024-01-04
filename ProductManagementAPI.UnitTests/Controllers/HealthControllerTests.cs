
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProductManagementAPI.Controllers.health;
using System.Reflection;


namespace ProductManagementAPI.UnitTests.Controllers
{
    [TestClass]
    public class HealthControllerTests
    {
        private HealthController _healthController;
        private IConfiguration _configuration;

        [TestInitialize]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"Environment", "Development"} 
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _healthController = new HealthController(_configuration);
        }

        [TestMethod]
        public void Get_ReturnsHealthStatus()
        {
            // Act
            var result = _healthController.Get();
             
            Assert.IsNotNull(result, "The result of the Get method is null.");
             
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult, "The result is not an OkObjectResult.");
             
            Assert.AreEqual(200, okResult.StatusCode, "The status code is not 200.");
             
            var health = okResult.Value.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(okResult.Value));

            Assert.IsNotNull(health, "The health object is null.");
            Assert.AreEqual("ok", health["Status"], "The status property is not 'ok'.");
             
            var expectedAssemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
            Assert.AreEqual(expectedAssemblyName, health["Name"], "The name property is incorrect.");

            Assert.AreEqual("15.0.0.0", health["Version"], "The version property is incorrect.");
            Assert.AreEqual(_configuration.GetValue<string>("Environment"), health["Environment"], "The environment property is incorrect.");
        }
    }
}
