using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data;

public class Alumno
{
    public int Id { get; set; }

    public ICollection<AlumnoTutor> AlumnoTutores { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
    public string? Nombre { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo Apellido debe tener como máximo 100 caracteres.")]
    public string? Apellido { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "El campo Dirección debe tener como máximo 150 caracteres.")]
    public string? Direccion { get; set; }

    [Required]
    [DataType(DataType.Date, ErrorMessage = "El campo FechaIngreso debe ser una fecha válida.")]
    public DateOnly? FechaIngreso { get; set; }

    [Required]
    public bool Aparato { get; set; }

    [Required]
    public bool Implante { get; set; }

    [Required]
    [DataType(DataType.Date, ErrorMessage = "El campo FechaAparato debe ser una fecha válida.")]
    public DateOnly? FechaAparato { get; set; }

    [Required]
    [DataType(DataType.Date, ErrorMessage = "El campo FechaImplante debe ser una fecha válida.")]
    public DateOnly? FechaImplante { get; set; }

        [Required]
        public bool Activo { get; set; }

    [DataType(DataType.Date, ErrorMessage = "El campo FechaEgreso debe ser una fecha válida.")]
    public DateOnly? FechaEgreso { get; set; }

    [StringLength(200, ErrorMessage = "El campo Comentarios debe tener como máximo 200 caracteres.")]
    public string? Comentarios { get; set; }
}
