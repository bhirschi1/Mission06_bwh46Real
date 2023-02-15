using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieEntry movieEntry)
        {
            //Save the movie that was submitted via the form
            _movieEntriesContext.Add(movieEntry);
            _movieEntriesContext.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
