using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWebAppEFCore.Data
{
    public class Institucion : Patrocinador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [StringLength(15, ErrorMessage = "El campo Teléfono debe tener como máximo 15 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo Teléfono solo puede contener números.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Descripción debe tener como máximo 200 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo Correo debe tener como máximo 100 caracteres.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Relación es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Relación debe tener como máximo 200 caracteres.")]
        public string Relacion { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        [StringLength(150, ErrorMessage = "El campo Dirección debe tener como máximo 150 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo TipoEmpresas es obligatorio.")]
        [Column(TypeName = "varchar(50)")]
        public TipoEmpresa TipoEmpresas { get; set; }
    }
}
