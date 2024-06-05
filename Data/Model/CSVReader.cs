using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

//Aqui estaba intentando crear el lector del CSV, e hice mas o menos el de padrinos

namespace OyeIap.Server.Data.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class CSVReader : Controller
    {

        private readonly ApplicationDbContext _context;

        public CSVReader(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var tutor = _context.Tutores.ToList();
            return View(tutor);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Por favor seleccione un archivo CSV.";
                return View("Tutores");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Tutor>().ToList();
                    _context.Tutores.AddRange(records);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Tutores");
        }
    }
}
