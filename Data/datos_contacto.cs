using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class datos_contacto
    {
        public int id_datos_contacto { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? id_tutor1 { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? id_tutor2 { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? direccion { get; set; }

    }
}
