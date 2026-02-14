using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission__6.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Mission__6.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult collection()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Movies = _context.Movies.Include(m => m.Category).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult gettoknowyou()
        {
            return View();
        }

        [HttpPost]
        public IActionResult collection(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return RedirectToAction("collection");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}