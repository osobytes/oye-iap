using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class patrocinadores
    {
        public int id_patrocinadores { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? id_institucion { get; set; }

        [StringLength(100, ErrorMessage = "")]
        public int? id_tutor1 { get; set; }

        [StringLength(100, ErrorMessage = "")]
        public int? id_tutor2 { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? apellido { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? correo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? donacion { get; set; }

        [StringLength(50, ErrorMessage = "")]
        public string? empresa_o_institucion { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string? telefono_personal { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string? telefono_empresa { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? ayuda { get; set; }

    }
}
