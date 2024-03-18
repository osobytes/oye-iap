using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Tutor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? apellido { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? correo { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string? telefono_personal { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "")]
        public int? pago { get; set; }

        [Required]
        public bool? padrino { get; set; }

        public ICollection<AlumnoTutor> AlumnoTutores { get; set; }

    }
}
