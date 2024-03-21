using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Tutor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int Correo { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public string Telefono_personal { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public int Pago { get; set; }

        public bool? Padrino { get; set; }

        public ICollection<AlumnoTutor> AlumnoTutores { get; set; }

    }
}
