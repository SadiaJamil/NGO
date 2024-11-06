using E_Project.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Project.Controllers
{
    public class PartnersController : Controller
	{
		private readonly ApplicationDbContext _context;

		private readonly IWebHostEnvironment _WebHostEnvironment;
		public PartnersController(ApplicationDbContext context, IWebHostEnvironment whe)
		{
			this._context = context;
			this._WebHostEnvironment = whe;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AddPartners()
		{
			return View();
		}

		[HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 1048576000)]
        [RequestSizeLimit(1048576000)]

        public IActionResult AddPartners(Partners partner)
        {
            string filename = "";
            if (partner.PartnerFILE == null)
            {
                return View();
            }
            string uploadfolder = Path.Combine(_WebHostEnvironment.WebRootPath, "Content/Images");///Path.Combine is used for combining
            filename = Guid.NewGuid().ToString() + " " + partner.PartnerFILE.FileName;///filename(EmpProfile is file information)
            string filepath = Path.Combine(uploadfolder, filename);

            string extension = Path.GetExtension(partner.PartnerFILE.FileName);

            if (extension.ToLower() == ".jfif" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".webp" || extension.ToLower() == ".mp4")
            {
                partner.PartnerFILE.CopyTo(new FileStream(filepath, FileMode.Create));///push to the database
                if (partner.PartnerFILE.Length <= 1048576000)
                {
                    Partners part = new Partners
                    {
                        PartnerName = partner.PartnerName,
                        PartnerEmail = partner.PartnerEmail,
                        PartnerContact = partner.PartnerContact,
                        PartnershipSDate = partner.PartnershipSDate,
                        PartnershipEDate = partner.PartnershipEDate,
                        PartnerLOGO = filename
                    };

                    _context.partners.Add(part);
                    _context.SaveChanges();
                    TempData["success"] = "New partner has been added successfully..";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "File Size is not Valid..";
                }

            }
            else
            {
                TempData["extension_error"] = "File Extension not Valid..";
            }
            return View();
        }
        public IActionResult ViewPartners()
		{
			var data = _context.partners.ToList();
			return View(data);
		}

        public IActionResult DetailsPartners(int id)
        {
            var find = _context.partners.Find(id);
            /// var find = _context.Employees.FirstOrDefault(x=>x.EmpId==id);
            return View(find);
        }

        //Edit Partners
        [HttpGet]
        public async Task<IActionResult> EditPartners(int id)
        {
            var data = await _context.partners.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 1048576000)]
        [RequestSizeLimit(1048576000)]
        public async Task<IActionResult> EditPartners(int id, Partners partner)
        {
            var data = await _context.partners.FindAsync(id);
            string? filename = "";
            if (partner.PartnerFILE != null)
            {
                string uploadfolder = Path.Combine(_WebHostEnvironment.WebRootPath, "Content/Images");
                filename = Guid.NewGuid().ToString() + " " + partner.PartnerFILE.FileName;
                string? filepath = Path.Combine(uploadfolder, filename);
                string? extension = Path.GetExtension(partner.PartnerFILE.FileName);

                if (extension.ToLower() == ".jfif" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".webp" || extension.ToLower() == ".mp4")
                {
                    partner.PartnerFILE.CopyTo(new FileStream(filepath, FileMode.Create));///push to the database
                    if (partner.PartnerFILE.Length <= 1048576000)
                    {

                        data.PartnerName = partner.PartnerName;
                        data.PartnerEmail = partner.PartnerEmail;
                        data.PartnerContact = partner.PartnerContact;
                        data.PartnershipSDate = partner.PartnershipSDate;
                        data.PartnershipEDate = partner.PartnershipEDate;
                        data.PartnerLOGO = filename;


                        _context.partners.Update(data);
                        await _context.SaveChangesAsync();
                        TempData["success"] = "Partner details updated Successfully..";
                        return RedirectToAction("ViewPartners", "Partners");
                    }
                    else
                    {
                        TempData["error"] = "File Size is not Valid..";
                    }

                }
                else
                {
                    TempData["extension_error"] = "File Extension not Valid..";
                }

            }
            return View();
        }

        ////Delete Parters
        [HttpGet]
        public async Task<IActionResult> DeletePartners(int id)
        {
            var delete_view = await _context.partners.FindAsync(id);
            return View(delete_view);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePartners(int id, Partners partner)
        {
            var data = await _context.partners.FindAsync(id);
            string deletefromfolder = Path.Combine(_WebHostEnvironment.WebRootPath, "Content/Images");
            string? currentImage = Path.Combine(Directory.GetCurrentDirectory(), deletefromfolder, data.PartnerName);

            _context.partners.Remove(data);
            if (await _context.SaveChangesAsync() > 0)
            {
                if (currentImage != null)
                {
                    if (System.IO.File.Exists(currentImage))
                    {
                        System.IO.File.Delete(currentImage);
                    }
                }
            }
            TempData["delete_success"] = "Partner has been deleted successfully...";
            return RedirectToAction("ViewPartners", "Partners");
        }
    }
}
