using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data;

public class Alumno
{ 
        public int Id { get; set; }

        public ICollection<AlumnoTutor> AlumnoTutores { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "")]     
        public string Direccion { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "")]
        public DateOnly? FechaIngreso { get; set; }

        public bool Aparato { get; set; }
        public bool Implante { get; set; }

        [DataType(DataType.Date, ErrorMessage = "")]
        public DateOnly? FechaAparato { get; set; }

        [DataType(DataType.Date, ErrorMessage = "")]
        public DateOnly? FechaImplante { get; set; }

        [Required]
        public bool Activo { get; set; }

        [DataType(DataType.Date, ErrorMessage = "")]
        public DateOnly? FechaEgreso { get; set; }

        [StringLength(200, ErrorMessage = "")]
        public string? Comentarios { get; set; }
}
