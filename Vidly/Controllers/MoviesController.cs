using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Areas.AppData;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDataDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDataDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }
        // GET; /Movies
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList<Movie>();

            return View(movies);
        }

        // GET: /Movies/Details
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null) throw new ArgumentException("This page is not found.");

            return View(movie);
            
        }

        // GET: /Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}
