using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Patrocinios
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int IdInstitucion { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int IdTutor { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? DetallesAyuda { get; set; }

    }
}
