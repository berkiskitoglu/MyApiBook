using Microsoft.AspNetCore.Mvc;

namespace MyApiBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Admin()
        {
            return View();
        }
    }
}
