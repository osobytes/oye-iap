using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class instituciones_relacionadas
    {
        public int id_institucion { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? nombre_institucion { get; set; }

        [StringLength(100, ErrorMessage = "")]
        public string? desc_ayuda { get; set; }

        [StringLength(100, ErrorMessage = "")]
        public string? tipo_empresa { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? desc_que_hace { get; set; }

    }
}
