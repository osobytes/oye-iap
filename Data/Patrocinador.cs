using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Patrocinador
    {
        [Required]
        public bool PatrocinioActivo { get; set; }

        [Required]
        public int Donacion { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "")]
        public string DetallesAyuda { get; set; }        
    }
}
