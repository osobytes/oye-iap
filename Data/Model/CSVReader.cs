using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OyeIap.Server.Pages;
using System.Text;



namespace OyeIap.Server.Data.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class CSVReader : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CSVReader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("process")]
        public IActionResult ProcessCsv()
        {
            try
            {
                // Verifica si se ha enviado un archivo
                if (Request.Form.Files.Count == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                // Obtiene el archivo subido
                var file = Request.Form.Files[0];

                // Verifica si el archivo es un archivo CSV
                if (file.ContentType != "text/csv")
                {
                    return BadRequest("Uploaded file must be a CSV file.");
                }

                // Obtiene la ruta de la carpeta de carga en el servidor
                string uploadFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                // Crea la carpeta de carga si no existe
                Directory.CreateDirectory(uploadFolderPath);

                // Genera un nombre de archivo único para evitar conflictos
                string uploadedFileName = Guid.NewGuid().ToString() + ".csv";

                // Combina la ruta de la carpeta de carga con el nombre de archivo generado
                string csvFilePath = Path.Combine(uploadFolderPath, uploadedFileName);

                // Guarda el archivo subido en el servidor
                using (var stream = new FileStream(csvFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Procesa el archivo CSV (aquí puedes implementar la lógica para leer y procesar el archivo)

                return Ok("CSV file uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
