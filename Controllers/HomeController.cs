using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Cryptography;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleTours.Models;
using TempleTours.Models.Database;
using TempleTours.Models.ViewModels;

namespace TempleTours.Controllers
{
    public class HomeController : Controller
    {
        private ITempleTourRepo _repository;

        private readonly ILogger<HomeController> _logger;

        private TempleTourDbContext _context;

        public HomeController(ILogger<HomeController> logger, ITempleTourRepo repo, TempleTourDbContext context)
        {
            _logger = logger;
            _repository = repo;
            _context = context;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("GET request on Index.");
            //this one is ready
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("GET request on Privacy.");
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            _logger.LogInformation("GET request on SignUp.");
            //This one should be ready to go
            return View(from t in _repository.Tours
                        where t.TourTime > DateTime.Now
                        where !t.Parties.Any()
                        orderby t.TourTime
                        select t
                        );
        }

        [HttpPost]
        public IActionResult SignUp(int tourId)
        {
            _logger.LogInformation("POST request on SignUp.");
            if (ModelState.IsValid)//validates tour, also might not need this depending on the date and time
            {
                //sets tour to UnfinishedTour variable so we can use it in UserForm 
                //and then save the finished product to the database
                var signUp = new SignUpViewModel
                {
                    TourId = _repository.Tours
                           .Where(t => t.TourId == tourId)
                           .FirstOrDefault().TourId,
                };
                return View("UserForm", signUp);//if valid returns UserForm
            }
            
            // Pass back the same Tour instance if the model is not valid.
            return View(_repository.Tours.
                        Where(t => t.TourId == tourId));//when submitted
        }


        [HttpGet]
        public IActionResult UserForm(int tourId)
        {
            _logger.LogInformation("GET request on UserForm.");
            var signUp = new SignUpViewModel
            {
                TourId = tourId
            };

            // Return the ViewModel with the proper Tour object and a 
            // new Party to be filled out.
            return View(signUp);
        }

        [HttpPost]
        public IActionResult UserForm(SignUpViewModel signUp)
        {
            _logger.LogInformation("POST request on UserForm.");
            if (ModelState.IsValid)//validates tour
            {
                // If valid, add the Party to the DB.
                Tour addTour = _repository.Tours
                               .Where(t => t.TourId == signUp.TourId)
                               .FirstOrDefault();
                var party = new Party
                {
                    EmailAddress = signUp.EmailAddress,
                    PartyName = signUp.PartyName,
                    PhoneNumber = signUp.PhoneNumber,
                    PartySize = signUp.PartySize,
                    Tour = addTour,
                    TourId = signUp.TourId
                };
                _context.Parties.Add(party);
                addTour.Parties.Add(party);
                _context.SaveChanges();
                return RedirectToAction("Index");//if valid returns UserForm
            }
            // If invalid, render the model with errors.
            return View(signUp);
        }

        public IActionResult Appointments()
        {
            //this one should be ready
            return View(_repository.Tours
                        .Include(t => t.Parties)
                        .Where(t => t.Parties.Any())
                        .OrderBy(t => t.TourTime)
                        );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
