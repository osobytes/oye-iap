using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class Tutor : Patrocinador
    {
        [Required(ErrorMessage = "El campo Id es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(100, ErrorMessage = "El campo Nombre debe tener una longitud máxima de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        [StringLength(100, ErrorMessage = "El campo Apellido debe tener una longitud máxima de 100 caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido.")]
        [StringLength(100, ErrorMessage = "El campo Correo debe tener una longitud máxima de 100 caracteres.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Dirección es requerido.")]
        [StringLength(150, ErrorMessage = "El campo Dirección debe tener una longitud máxima de 150 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        [StringLength(15, ErrorMessage = "El campo Teléfono debe tener una longitud máxima de 15 caracteres.")]
        // [RegularExpression("^[0-9]*$", ErrorMessage = "El campo Teléfono solo puede contener números.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Pago es requerido.")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo Pago debe ser un valor numérico mayor o igual a 0.")]
        public int Pago { get; set; }

        public ICollection<AlumnoTutor> AlumnoTutores { get; set; }

    }
}
