using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cryptography;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleTours.Models;
using TempleTours.Models.ViewModels;
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
            return View(_context.Tours.Where(t => t.Parties.Count == 0).OrderBy(t => t.TourTime));
        }
        [HttpPost]
        public IActionResult SignUp(int tourId)
        {

           
                UnfinishedTour = _context.Tours.First(t => t.TourId == tourId);
                //sets tour to UnfinishedTour variable so we can use it in UserForm 
                //and then save the finished product to the database
           
            return View("UserForm", new SignUpViewModel
            {
                Tour = UnfinishedTour,
                Party = new TourParty()
            });//when submitted
        }
        [HttpPost]
        public IActionResult UserForm(SignUpViewModel signUp)
        {
            if (ModelState.IsValid)//validates tour
            {
                
                
                Tour tour = _context.Tours.First(t => t.TourId == signUp.Tour.TourId);
                tour.Parties = new List<TourParty>();
                tour.Parties.Add(signUp.Party);
                _context.SaveChanges();
               

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
            IQueryable placeholder = _context.Tours.Where(t => t.Parties.Count > 0).OrderBy(t => t.TourTime);
            IQueryable PartyPlaceholder = _context.Parties;
            //this one should be ready
            return View(_context.Tours.Where(t => t.Parties.Count > 0 ).OrderBy(t => t.TourTime));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
