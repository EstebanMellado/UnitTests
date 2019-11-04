using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Unittest.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger _logger;
        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public string GetMessage()
        {
           _logger.LogError("Index Method Called!!!");
            _logger.LogInformation("Index Method Called!!!");
            return "Ok";
        }
    }
}