using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission__6.Models;
using Mission__6.Data;
using System.Diagnostics;

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
        public IActionResult Collection()
        {
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            var movies = _context.Movies.Include(m => m.Category).OrderBy(m => m.Title).ToList();
            return View(movies);
        }

        [HttpPost]
        public IActionResult Collection(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return RedirectToAction("Collection");
            }
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            var movies = _context.Movies.Include(m => m.Category).OrderBy(m => m.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Application movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Collection");
            }
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Include(m => m.Category).FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int MovieId)
        {
            var movie = _context.Movies.Find(MovieId);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Collection");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult gettoknowyou()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}