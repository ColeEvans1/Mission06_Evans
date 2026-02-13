using Microsoft.AspNetCore.Mvc;
using Mission06_Evans.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost] //Actually submits the form
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)        // Are all validation rules met?
            {
                _context.Movies.Add(response);    // Yes → add to database
                _context.SaveChanges();         // Save it
                return RedirectToAction("Index"); // Go back to home
            }
            return View(response);  // No → show the form again with errors
        }

    }
}
