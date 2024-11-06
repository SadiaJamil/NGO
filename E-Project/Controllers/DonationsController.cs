using E_Project.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Project.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _WebHostEnvironment;
        public DonationsController(ApplicationDbContext context, IWebHostEnvironment whe)
        {
            this._context = context;
            this._WebHostEnvironment = whe;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDonation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDonation(Donations donation)
        {
            if (ModelState.IsValid)
            {
                _context.donations.Add(donation);
                _context.SaveChanges();
                TempData["success"] = "Your donation has been added successfully!!!";
                return RedirectToAction("Index", "Web");
            }
            return View(donation);
        }
        public IActionResult ViewDonations()
        {
            var data = _context.donations.ToList();
            return View(data);
        }

        //Edit NGO
        public async Task<IActionResult> EditDonations(int id)
        {
            var data = await _context.donations.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> EditDonations(Donations donations)
        {
            if (ModelState.IsValid)
            {
                //var data = await _context.AssociatedNGOs.FindAsync(id);
                _context.donations.Update(donations);
                await _context.SaveChangesAsync();
                TempData["success"] = "Donation Updated Successfully..";
                return RedirectToAction("ViewDonations", "Donations");
            }

            return View(donations);
        }
        //delete Donation
        public async Task<IActionResult> DeleteDonation(int id)
        {
            var delete = await _context.donations.FindAsync(id);
            return View(delete);
        }
        [HttpPost, ActionName("DeleteDonation")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = _context.donations.Find(id);
            if (delete != null)
            {
                //var data = await _context.AssociatedNGOs.FindAsync(id);
                _context.donations.Remove(delete);
                await _context.SaveChangesAsync();
                TempData["delete_success"] = "Donation deleted Successfully..";
                return RedirectToAction("ViewDonations", "Donations");
            }

            return View();
        }
        public IActionResult DonationDetails(int id)
        {
            var find = _context.donations.Find(id);
            /// var find = _context.Employees.FirstOrDefault(x=>x.EmpId==id);
            return View(find);
        }
    }
}

