using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cryptography;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleTours.Models;
using TempleTours.Models.Database;

namespace TempleTours.Controllers
{
    public class HomeController : Controller
    {
        private ITempleTourRepo _repository;
        private TempleTourDbContext _context;
        public Tour UnfinishedTour { get; set; }//used as a placeholder

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ITempleTourRepo repo, TempleTourDbContext context)
        {
            _logger = logger;
            _repository = repo;
            _context = context;
        }

       

        public IActionResult Index()
        {
            //this one is ready
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            


            //This one should be ready to go
            return View(_repository.Tours
                .Where(t => t.Parties == null)
                .OrderBy(t => t.TourTime));
        }
        [HttpPost]
        public IActionResult SignUp(int tourId)
        {

            if (ModelState.IsValid)//validates tour, also might not need this depending on the date and time
            {
                UnfinishedTour = _context.Tours.First(t => t.TourId == tourId);
                //sets tour to UnfinishedTour variable so we can use it in UserForm 
                //and then save the finished product to the database

                return RedirectToAction("UserForm");//if valid returns UserForm
            }
            return View();//when submitted
        }
        [HttpPost]
        public IActionResult UserForm(TourParty tourParty)
        {
            if (ModelState.IsValid)//validates tour
            {
                
                //UnfinishedTour.AddTourist(tourParty);
                //_repository.Tours.Where(t => t.TourId == UnfinishedTour.TourId);

                //Product prodToUpdate = context.Products
                //     .Where(p => p.ProductID == product.ProductID).FirstOrDefault();

                if (UnfinishedTour != null)
                {
                    Tour tour = _context.Tours.First(t => t.TourId == UnfinishedTour.TourId);
                    tour.AddTourist(tourParty);
                    _context.SaveChanges();
                }




               


                //save changes to db
                return RedirectToAction("Index");//if valid returns UserForm
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserForm()
        {
            return View();
        }

        public IActionResult Appointments()
        {
            //this one should be ready
            return View(_repository.Tours
                .Where(t => t.Parties != null)
                .OrderBy(t => t.TourTime));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
