// New Addition
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;
using System.Diagnostics;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        // New Addition
        private MovieContext context { get; set; }

        public HomeController(MovieContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var movies = context.Movies
                .Include(m => m.Genre) // Order by genre
                .OrderBy(m => m.Name) // Order by name
                .ToList();

            return View(movies);
        }
    }
}
