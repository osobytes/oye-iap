using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class patrocinadores
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public int Id_institucion { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public int Id_tutor { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string Correo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int Donacion { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? Ayuda { get; set; }

    }
}
