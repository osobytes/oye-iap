using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data;

public class Alumno
{ 
        public int Id { get; set; }

        public ICollection<AlumnoTutor> AlumnoTutores { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string? Apellido { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "")]
        public DateOnly? Fecha_ingreso { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "")]
        public string? Aparato_o_implante { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "")]
        public DateOnly? Fecha_aparato { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "")]
        public DateOnly? Fecha_implante { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "")]
        public string? Activo { get; set; }

        [DataType(DataType.Date, ErrorMessage = "")]
        public DateOnly? Fecha_egreso { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? Comentarios { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "")]
        public string? ZipCode { get; set; }
}
