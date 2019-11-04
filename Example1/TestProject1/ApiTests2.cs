using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unittest.Controllers;

namespace ALG_Developers.UnitTests
{
    [TestClass]
    public class ApiTests2
    {
        [DataTestMethod]
        [DataRow(1, "Fernando")]
        [DataRow(2, "Florencia")]
        [DataRow(123, "Not Found")]
        public void GetDeveloperName_DeveloperExists_ReturnsName(int empId, string name)
        {
            HomeController home = new HomeController();
            string result = home.GetDeveloperName(empId);
            Assert.AreEqual(result, name);
        }
    }
}
