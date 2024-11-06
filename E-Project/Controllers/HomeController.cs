using E_Project.Models;
using E_Project.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_Project.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _WebHostEnvironment;
        public HomeController(ApplicationDbContext context, IWebHostEnvironment whe)
        {
            this._context = context;
            this._WebHostEnvironment = whe;
        }
        //[Authorize(Roles = SD.Role_Admin)]
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = SD.Role_Admin)]
        public IActionResult DonationView()
        {
            var data = _context.donations.ToList();
            return View(data);
        }
        public IActionResult Donations()
        {
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var data = await _context.donations.FindAsync(id);
        //    return View(data);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, Donations Donate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var data = await _context.donations.FindAsync(id);
        //        _context.donations.Update(Donate);
        //        await _context.SaveChangesAsync();
        //        TempData["success"] = "Donation Updated Successfully..";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View(Donate) ;
        //}
        
        public IActionResult AssociatedNGOs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssociatedNGOs(AssociatedNGOs NGOs)
        {
            if (ModelState.IsValid)
            {
                _context.AssociatedNGOs.Add(NGOs);
                _context.SaveChanges();
                TempData["success"] = "NGO has been added successfully!!!";
                return RedirectToAction("Index", "Home");
            }
            return View(NGOs);
        }
        public IActionResult AssociatedNGOsView()
        {
            var data = _context.AssociatedNGOs.ToList();
            return View(data);
        }

        //Edit NGO
        public async Task<IActionResult> EditNGOs(int id)
        {
            var data = await _context.AssociatedNGOs.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> EditNGOs(AssociatedNGOs NGOs)
        {
            if (ModelState.IsValid)
            {
                //var data = await _context.AssociatedNGOs.FindAsync(id);
                _context.AssociatedNGOs.Update(NGOs);
                await _context.SaveChangesAsync();
                TempData["success"] = "NGO Updated Successfully..";
                return RedirectToAction("Index", "Home");
            }

            return View(NGOs);
        }
        //delete NGO
        public async Task<IActionResult> DeleteNGOs(int id)
        {
            var delete = await _context.AssociatedNGOs.FindAsync(id);
            return View(delete);
        }
        [HttpPost,ActionName("DeleteNGOs")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = _context.AssociatedNGOs.Find(id);
            if (delete != null)
            {
                //var data = await _context.AssociatedNGOs.FindAsync(id);
                _context.AssociatedNGOs.Remove(delete);
                await _context.SaveChangesAsync();
                TempData["success"] = "NGO deleted Successfully..";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
