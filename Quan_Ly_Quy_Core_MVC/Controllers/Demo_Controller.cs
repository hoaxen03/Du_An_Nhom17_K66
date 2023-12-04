using Microsoft.AspNetCore.Mvc;

namespace Quan_Ly_Quy_Core_MVC.Controllers
{
    public class Demo_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
