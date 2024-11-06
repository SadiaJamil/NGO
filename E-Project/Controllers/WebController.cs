using E_Project.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Project.Controllers
{
    //[Area("User")]
    public class WebController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _WebHostEnvironment;
        public WebController(ApplicationDbContext context, IWebHostEnvironment whe)
        {
            this._context = context;
            this._WebHostEnvironment = whe;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult DonationView()
        {
            var data = _context.donations.ToList();
            return View(data);
        }
        public IActionResult Donations()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Donations(Donations don)
        {
            if (ModelState.IsValid)
            {
                _context.donations.Add(don);
                _context.SaveChanges();
                TempData["success"] = "Donation has been added successfully!!!";
                return RedirectToAction("Index", "Web");
            }
            return View(don);
        }
      
        public IActionResult about()
        {
            return View();
        }

       
       
        public IActionResult contact()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult contact(ContactUs contactUs)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.contacts.Add(contactUs);
        //        _context.SaveChanges();
        //        TempData["success"] = "Donation has been added successfully!!!";
        //        return RedirectToAction("Index", "Web");
        //    }
        //    return View(contactUs);
        //}

        public IActionResult HelpCenter ()
        {
            return View();
        }

        public IActionResult partners()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult what_we_do()
        {
            return View();
        }
        public IActionResult mission()
        {
            return View();
        }
        public IActionResult team()
        {
            return View();
        }
        public IActionResult achievements()
        {
            return View();
        }
        public IActionResult supporters()
        {
            return View();
        }
        public IActionResult terms()
        {
            return View();
        }
        public IActionResult testimonial()
        {
            return View();
        }

        public IActionResult gallery()
        {
            return View();
        }
    }
}
