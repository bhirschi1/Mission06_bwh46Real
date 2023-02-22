using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_bwh46.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_bwh46.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieEntriesContext _movieEntriesContext { get; set; }

        // constructor
        public HomeController(ILogger<HomeController> logger, MovieEntriesContext entry)
        {
            _logger = logger;
            _movieEntriesContext = entry;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Return the podcasts page
        public IActionResult Podcasts()
        {
            return View();
        }

        //create both a get and post action for the Movies so we can submit data with the post but still access the site
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = _movieEntriesContext.Category.ToList();

            return View("Movies", new MovieEntry());
        }

        [HttpPost]
        public IActionResult Movies(MovieEntry movieEntry)
        {
            //Data validation
            if (ModelState.IsValid)
            { //Save the movie that was submitted via the form
                _movieEntriesContext.Add(movieEntry);
                _movieEntriesContext.SaveChanges();
                ViewBag.Categories = _movieEntriesContext.Category.ToList();
                var movies = _movieEntriesContext.Entries.Include(m => m.category).ToList();
                return View("ListMovies", movies);
            }
            else
            {
                ViewBag.Categories = _movieEntriesContext.Category.ToList();
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult ListMovies()
        {
            var allMovies = _movieEntriesContext.Entries
                .Include(x => x.category)
                .ToList();

            return View(allMovies);
        }
        [HttpGet]
        public IActionResult Edit(int entryId)
        {
            // this viewbag.cate... sends all the categories in the table to be used for a 
            // select option for a new movie entry or an updated one
            ViewBag.Categories = _movieEntriesContext.Category.ToList();

            // this entry is specified when the user clicks the edit button in the table 
            // in the ListMovies.cshtml file
            var entry = _movieEntriesContext.Entries.Single(x => x.entryId == entryId);
            return View("Movies", entry);
        }
        [HttpPost]
        public IActionResult Edit(MovieEntry updatedEntry)
        {
            // must do same data validation as the new movie entry
            if (ModelState.IsValid)
            { //Save the movie that was submitted via the form
                _movieEntriesContext.Update(updatedEntry);
                _movieEntriesContext.SaveChanges();
                ViewBag.Categories = _movieEntriesContext.Category.ToList();
                return RedirectToAction("ListMovies");
            }
            else
            {
                // Return the Movies view if it is not valid
                ViewBag.Categories = _movieEntriesContext.Category.ToList();
                return View("Movies");
            }
        }

        // deleting a movie entry based on the entryId sent with the button in the table
        [HttpGet]
        public IActionResult Delete(int entryId)
        {
            var entry = _movieEntriesContext.Entries.Single(x => x.entryId == entryId);

            return View(entry);
        }
        // actually deleting the movieEntry
        [HttpPost]
        public IActionResult Delete(MovieEntry entry)
        {
            _movieEntriesContext.Entries.Remove(entry);
            _movieEntriesContext.SaveChanges();

            return RedirectToAction("ListMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
