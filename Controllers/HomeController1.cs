using Microsoft.AspNetCore.Mvc;

namespace Mission__6.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
