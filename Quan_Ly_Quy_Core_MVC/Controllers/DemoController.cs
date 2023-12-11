using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Quan_Ly_Quy_Core_API.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThuChi()
        {  return View("ThuChi"); }
    }
}
