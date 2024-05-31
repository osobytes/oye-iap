using Microsoft.AspNetCore.Mvc;

namespace OyeIap.Server.Data.Model
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile[] files)
        {
            if (files.Length == 0)
            {
                ViewBag.Message = "No files selected";
                return View();
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "uploads", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            ViewBag.Message = "Files successfully uploaded";
            return View();
        }
    }
}
