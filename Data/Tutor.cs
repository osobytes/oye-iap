using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Tutor : Patrocinador
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
        public string Correo { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public string Telefono { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "")]
        public int Pago { get; set; }

        public ICollection<AlumnoTutor> AlumnoTutores { get; set; }

    }
}
