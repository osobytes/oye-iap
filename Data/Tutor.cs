using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Tutor : Patrocinador
    {
        [Required(ErrorMessage = "El campo Id es requerido.")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo ApellidoPaterno debe tener como máximo 100 caracteres.")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo ApellidoMaterno debe tener como máximo 100 caracteres.")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo Correo debe tener como máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo válida.")]
        public string Correo { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El campo Dirección debe tener como máximo 150 caracteres.")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El campo Teléfono debe tener como máximo 15 caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Pago es requerido.")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo Pago debe ser un valor numérico mayor o igual a 0.")]
        public int Pago { get; set; }

        public ICollection<AlumnoTutor> Alumnos { get; set; }
    }
}
