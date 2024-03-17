using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class alumno
    {
            public int Id_alumno { get; set; }

            [StringLength(100, ErrorMessage = "")]
            public int? id_tutor1 { get; set; }

            [StringLength(100, ErrorMessage = "")]
            public int? id_tutor2 { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "")]
            public string? nombre { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "")]
            public string? apellido { get; set; }

            [Required]
            [DataType(DataType.Date, ErrorMessage = "")]
            public DateOnly? fecha_ingreso { get; set; }

            [Required]
            [StringLength(20, ErrorMessage = "")]
            public string? aparato_o_implante { get; set; }

            [Required]
            [DataType(DataType.Date, ErrorMessage = "")]
            public DateOnly? fecha_aparato { get; set; }

            [Required]
            [DataType(DataType.Date, ErrorMessage = "")]
            public DateOnly? fecha_implante { get; set; }

            [Required]
            [StringLength(2, ErrorMessage = "")]
            public string? activo { get; set; }

            [Required]
            [StringLength(200, ErrorMessage = "")]
            public string? comentarios { get; set; }

            [DataType(DataType.Date, ErrorMessage = "")]
            public DateOnly? fecha_egreso { get; set; }

            [Required]
            [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "")]
            public string? ZipCode { get; set; }
    }
}
