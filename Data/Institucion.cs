using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Institucion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public String Nombre { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public int Telefono { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "")]
        public string Desc_institucion { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "")]
        public string Relacion { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "")]
        public string tipo_empresa { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? Desc_ayuda { get; set; }

    }
}
