using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data;

public class Alumno
{
    public int Id { get; set; }

    public ICollection<AlumnoTutor> Tutores { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
    public string Nombre { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo ApellidoPaterno debe tener como máximo 100 caracteres.")]
    public string ApellidoPaterno { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo ApellidoMaterno debe tener como máximo 100 caracteres.")]
    public string ApellidoMaterno { get; set; }

    [StringLength(100, ErrorMessage = "El campo Correo debe tener como máximo 100 caracteres.")]
    [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo válida.")]
    public string Correo { get; set; }

    [StringLength(150, ErrorMessage = "El campo Dirección debe tener como máximo 150 caracteres.")]
    public string Direccion { get; set; }

    [StringLength(15, ErrorMessage = "El campo Teléfono debe tener como máximo 15 caracteres.")]
    public string Telefono { get; set; }

    [Required]
    [DataType(DataType.Date, ErrorMessage = "El campo FechaIngreso debe ser una fecha válida.")]
    public DateOnly FechaIngreso { get; set; }

    [Required]
    public bool Aparato { get; set; }

    [Required]
    public bool Implante { get; set; }

    [DataType(DataType.Date, ErrorMessage = "El campo FechaAparato debe ser una fecha válida.")]
    public DateOnly? FechaAparato { get; set; }


    [DataType(DataType.Date, ErrorMessage = "El campo FechaProgramacion debe ser una fecha válida.")]
    public DateOnly? FechaProgramacion { get; set; }

    [DataType(DataType.Date, ErrorMessage = "El campo FechaImplante debe ser una fecha válida.")]
    public DateOnly? FechaImplante { get; set; }


    [DataType(DataType.Date, ErrorMessage = "El campo FechaConexion debe ser una fecha válida.")]
    public DateOnly? FechaConexion { get; set; }

    [Required]
    public bool Activo { get; set; }

    [DataType(DataType.Date, ErrorMessage = "El campo FechaEgreso debe ser una fecha válida.")]
    public DateOnly? FechaEgreso { get; set; }

    [StringLength(200, ErrorMessage = "El campo Comentarios debe tener como máximo 200 caracteres.")]
    public string? Comentarios { get; set; }

}
