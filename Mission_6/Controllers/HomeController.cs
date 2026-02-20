using Microsoft.AspNetCore.Mvc;
using Mission06_Evans.Models;
using System.Diagnostics;

namespace Mission06_Evans.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp) //Constructor builds instance of db using context
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("AddMovie", new Movie());
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View(response);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie updatedInfo)
        {
            _context.Movies.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}
