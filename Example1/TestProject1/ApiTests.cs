using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unittest.Controllers;

namespace ALG_Developers.UnitTests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void GetDeveloperName_DeveloperExists_ReturnsName()
        {
            HomeController home = new HomeController();
            string result = home.GetDeveloperName(1);
            Assert.AreEqual(result, "Fernando");
        }
        [TestMethod]
        public void GetDeveloperName_DeveloperNotExists_ReturnsNotFound()
        {
            HomeController home = new HomeController();
            string result = home.GetDeveloperName(123);
            Assert.AreEqual(result, "Not Found");
        }
        [TestMethod]
        public void GetMessage_LogginInfo_ReturnsOk()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<ApiController>();
            ApiController home = new ApiController(logger);
            logger.LogInformation("Test");
            string result = home.GetMessage();
            Assert.AreEqual(result, "Ok");
        }

    }
}
