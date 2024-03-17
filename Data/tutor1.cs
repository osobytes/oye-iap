using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class tutor1
    {
        public int id_tutor1 { get; set; }

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
        [StringLength(15, ErrorMessage = "")]
        public int? pago { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public bool? padrino { get; set; }

    }
}
