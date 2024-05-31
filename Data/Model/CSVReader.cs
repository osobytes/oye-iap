using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OyeIap.Server.Pages;
using System.Text;

//Aqui estaba intentando crear el lector del CSV, e hice mas o menos el de padrinos

namespace OyeIap.Server.Data.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class CSVReader : Controller
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

                // Obtiene la ruta de la carpeta de carga en el servidor
                string uploadFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                // Genera un nombre de archivo único para evitar conflictos
                string uploadedFileName = Guid.NewGuid().ToString() + ".csv";

                // Combina la ruta de la carpeta de carga con el nombre de archivo generado
                string csvFilePath = Path.Combine(uploadFolderPath, uploadedFileName);

                string linea;

                // Procesa el archivo CSV (aquí puedes implementar la lógica para leer y procesar el archivo)
                System.IO.StreamReader archivo = new System.IO.StreamReader(csvFilePath);
                archivo.ReadLine();

                //No terminado
                /*while((linea = archivo.ReadLine()) != null)
                {
                    string[] fila = linea.Split(',');
                    var tutor = new Tutor
                    {
                        Nombre = fila[0],
                        NombreFiscal = RandomOne(_nombres),
                        ApellidoPaterno = apellidoPaterno,
                        ApellidoMaterno = RandomOne(_apellidos),
                        NombreP1 = RandomOne(_nombres),
                        ApellidoPaternoP1 = apellidoPaterno,
                        ApellidoMaternoP1 = RandomOne(_apellidos),
                        Correo = $"{RandomOne(_nombres).Replace(" ", "").ToLower()}@example.com",
                        Direccion = sameAddress ? alumno.Direccion : RandomOne(_direcciones),
                        Telefono = $"123456789{i}",
                        TelefonoEmpresa = $"123456789{i}",
                        RFC = $"123456789{i}",
                        PatrocinioActivo = random.Next(2) == 0,
                        PersonaF = random.Next(2) == 0,
                        PersonaM = random.Next(2) == 0,
                        PersonaFisica = "Pago",
                        PersonaMoral = "Pago",
                        EmpresaNombre = RandomOne(_nombresEmpresa),
                        TipoEmp = RandomEnumValue<TipoEmpresa>(),
                        DetallesAyuda = "Detalles de ayuda",
                        Donacion = random.Next(100, 1000),
                        InformacionExtra = "Informacion Extra",
                        comentarios = "comentarios",
                        RegimenFiscal = "Demás ingresos",
                        CorreoEmpresa = $"{RandomOne(_nombres).Replace(" ", "").ToLower()}@example.com"
                    };
                }*/

                return Ok("CSV file uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
