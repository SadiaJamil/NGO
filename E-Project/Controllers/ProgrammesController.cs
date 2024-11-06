using E_Project.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace E_Project.Controllers
{
    public class ProgrammesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProgrammesController(ApplicationDbContext context, IWebHostEnvironment whe)
        {
            this._context = context;
            this._WebHostEnvironment = whe;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProgrammes()
        {
            return View();
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 1048576000)]
        [RequestSizeLimit(1048576000)]

        public IActionResult AddProgrammes(Programmes programme)
        {
            string filename = "";
            if (programme.ProgrammeFile == null)
            {
                return View();
            }
            string uploadfolder = Path.Combine(_WebHostEnvironment.WebRootPath, "Content/Images");///Path.Combine is used for combining
            filename = Guid.NewGuid().ToString() + " " + programme.ProgrammeFile.FileName;///filename(EmpProfile is file information)
            string filepath = Path.Combine(uploadfolder, filename);

            string extension = Path.GetExtension(programme.ProgrammeFile.FileName);

            if (extension.ToLower() == ".jfif" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".webp" || extension.ToLower() == ".mp4")
            {
                programme.ProgrammeFile.CopyTo(new FileStream(filepath, FileMode.Create));///push to the database
                if (programme.ProgrammeFile.Length <= 1048576000)
                {
                    Programmes pro = new Programmes
                    {
                        ProgrammeName = programme.ProgrammeName,
                        ProgStartDate = programme.ProgStartDate,
                        ProgEndDate = programme.ProgEndDate,
                        ProgrammeIMG = filename
                    };

                    _context.programmes.Add(pro);
                    _context.SaveChanges();
                    TempData["success"] = "Programme Added Successfully..";
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
        public IActionResult ViewProgrammes()
        {
            var data = _context.programmes.ToList();
            return View(data);
        }

        public IActionResult DetailsProgrammes(int id)
        {
            var find = _context.programmes.Find(id);
            /// var find = _context.Employees.FirstOrDefault(x=>x.EmpId==id);
            return View(find);
        }

        ////Edit Programme
        [HttpGet]
        public async Task<IActionResult> EditProgrammes(int id)
        {
            var data = await _context.programmes.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 1048576000)]
        [RequestSizeLimit(1048576000)]
        public async Task<IActionResult> EditProgrammes(int id, Programmes programme)
        {
            var data = await _context.programmes.FindAsync(id);
            string? filename = "";
            if (programme.ProgrammeFile != null)
            {
                string uploadfolder = Path.Combine(_WebHostEnvironment.WebRootPath, "Content/Images");
                filename = Guid.NewGuid().ToString() + " " + programme.ProgrammeFile.FileName;
                string? filepath = Path.Combine(uploadfolder, filename);
                string? extension = Path.GetExtension(programme.ProgrammeFile.FileName);

                if (extension.ToLower() == ".jfif" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".webp" || extension.ToLower() == ".mp4")
                {
                    programme.ProgrammeFile.CopyTo(new FileStream(filepath, FileMode.Create));///push to the database
                    if (programme.ProgrammeFile.Length <= 1048576000)
                    {

                        data.ProgrammeName = programme.ProgrammeName;
                        data.ProgStartDate = programme.ProgStartDate;
                        data.ProgEndDate = programme.ProgEndDate;
                        data.ProgrammeIMG = filename;


                        _context.programmes.Update(data);
                        await _context.SaveChangesAsync();
                        TempData["success"] = "Programme Added Successfully..";
                        return RedirectToAction("ViewProgrammes", "Programmes");
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

        //////Delete Programme
        [HttpGet]
        public async Task<IActionResult> DeleteProgrammes(int id)
        {
            var delete_view = await _context.programmes.FindAsync(id);
            return View(delete_view);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProgrammes(int id, Programmes programmes)
        {
            var data = await _context.programmes.FindAsync(id);
            string deletefromfolder = Path.Combine(_WebHostEnvironment.WebRootPath, "Content/Images");
            string? currentImage = Path.Combine(Directory.GetCurrentDirectory(), deletefromfolder, data.ProgrammeName);

            _context.programmes.Remove(data);
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
            TempData["delete_success"] = "Programme Deleted Successfully...";
            return RedirectToAction("ViewProgrammes", "Programmes");
        }
    }
}

