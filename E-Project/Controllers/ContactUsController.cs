using E_Project.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Project.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ContactUsController(ApplicationDbContext context, IWebHostEnvironment whe)
        {
            this._context = context;
            this._WebHostEnvironment = whe;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddContact()
        {
            return View();
        }

		[HttpPost]
		public IActionResult AddContact(ContactUs contact)
		{
			if (ModelState.IsValid)
			{
				_context.contacts.Add(contact);
				_context.SaveChanges();
				TempData["success"] = "Your message has been delivered successfully!!!";
				return RedirectToAction("Index", "Web");
			}
			return View(contact);
		}
		public IActionResult ViewContact()
		{
			var data = _context.contacts.ToList();
			return View(data);
		}
        //delete Contact
        public async Task<IActionResult> DeleteContact(int id)
        {
            var delete = await _context.contacts.FindAsync(id);
            return View(delete);
        }
        [HttpPost, ActionName("DeleteContact")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = _context.contacts.Find(id);
            if (delete != null)
            {
                
                _context.contacts.Remove(delete);
                await _context.SaveChangesAsync();
                TempData["delete_success"] = "Contact info deleted Successfully..";
                return RedirectToAction("ViewContact", "ContactUs");
            }

            return View();
        }
    }
}
