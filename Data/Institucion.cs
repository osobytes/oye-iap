using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Institucion : Patrocinador
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string Correo { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "")]
        public string Relacion { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "")]
        public TipoEmpresa TipoEmpresas { get; set; }

    }
}
