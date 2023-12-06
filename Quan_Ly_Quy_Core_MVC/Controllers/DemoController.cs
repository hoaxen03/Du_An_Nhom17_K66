using Microsoft.AspNetCore.Mvc;

namespace Core_WebApp_API.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
