using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class instituciones_convenio
    {
        public int id_institucion_convenio { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? id_institucion { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? nombre_institucion { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string? telefono { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? relacion { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? desc_institucion { get; set; }

        [StringLength(150, ErrorMessage = "")]
        public string? direccion { get; set; }

    }
}
