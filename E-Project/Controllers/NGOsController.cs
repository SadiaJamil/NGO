using E_Project.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Project.Controllers
{
    public class NGOsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _WebHostEnvironment;
        public NGOsController(ApplicationDbContext context, IWebHostEnvironment whe)
        {
            this._context = context;
            this._WebHostEnvironment = whe;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNGOs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNGOs(AssociatedNGOs NGOs)
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
        public IActionResult ViewNGOs()
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
                return RedirectToAction("ViewNGOs", "NGOs");
            }

            return View(NGOs);
        }
        //delete NGO
        public async Task<IActionResult> DeleteNGOs(int id)
        {
            var delete = await _context.AssociatedNGOs.FindAsync(id);
            return View(delete);
        }
        [HttpPost, ActionName("DeleteNGOs")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = _context.AssociatedNGOs.Find(id);
            if (delete != null)
            {
                //var data = await _context.AssociatedNGOs.FindAsync(id);
                _context.AssociatedNGOs.Remove(delete);
                await _context.SaveChangesAsync();
                TempData["delete_success"] = "NGO deleted Successfully..";
                return RedirectToAction("ViewNGOs", "NGOs");
            }

            return View();
        }
    }
}
