using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class datos_contacto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? Id_tutor { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int? Direccion { get; set; }

    }
}
