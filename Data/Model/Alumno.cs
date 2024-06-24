using System;
using System.ComponentModel.DataAnnotations;

namespace OyeIap.Server.Data;

public class Alumno
{
    public int Id { get; set; }

    public ICollection<AlumnoTutor>? Tutores { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [StringLength(100, ErrorMessage = "El campo ApellidoPaterno debe tener como máximo 100 caracteres.")]
    public string ApellidoPaterno { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "El campo ApellidoMaterno debe tener como máximo 100 caracteres.")]
    public string ApellidoMaterno { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date, ErrorMessage = "El campo FechaIngreso debe ser una fecha válida.")]
    public DateOnly FechaIngreso { get; set; } = DateOnly.MinValue;

    public bool Aparato { get; set; }

    public bool Implante { get; set; }

    [DataType(DataType.Date, ErrorMessage = "El campo FechaAparato debe ser una fecha válida.")]
    public DateOnly FechaAparato { get; set; } = DateOnly.MinValue;


    [DataType(DataType.Date, ErrorMessage = "El campo FechaProgramacion debe ser una fecha válida.")]
    public DateOnly FechaProgramacion { get; set; } = DateOnly.MinValue;

    [DataType(DataType.Date, ErrorMessage = "El campo FechaImplante debe ser una fecha válida.")]
    public DateOnly FechaImplante { get; set; } = DateOnly.MinValue;


    [DataType(DataType.Date, ErrorMessage = "El campo FechaConexion debe ser una fecha válida.")]
    public DateOnly FechaConexion { get; set; } = DateOnly.MinValue;

    [Required]
    public bool Activo { get; set; }

    [DataType(DataType.Date, ErrorMessage = "El campo FechaEgreso debe ser una fecha válida.")]
    public DateOnly FechaEgreso { get; set; } = DateOnly.MinValue;

    [StringLength(200, ErrorMessage = "El campo Comentarios debe tener como máximo 200 caracteres.")]
    public string? Comentarios { get; set; } = string.Empty;

    //Datos de los tutores
    [Required]
    [StringLength(200, ErrorMessage = "El campo Nombre del tutor debe tener como máximo 200 caracteres.")]
    public string NombreTutor { get; set; } = string.Empty;

    [Required]
    [StringLength(200, ErrorMessage = "El campo apellido del tutor debe tener como máximo 200 caracteres.")]
    public string ApellidoPaternoTutor { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "El campo apellido del tutor debe tener como máximo 200 caracteres.")]
    public string? ApellidoMaternoTutor { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "El campo Correo debe tener como máximo 100 caracteres.")]
    [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo válida.")]
    public string? Correo { get; set; } = string.Empty;

    [StringLength(150, ErrorMessage = "El campo Dirección debe tener como máximo 150 caracteres.")]
    public string Direccion { get; set; } = string.Empty;

    [StringLength(15, ErrorMessage = "El campo Teléfono debe tener como máximo 15 caracteres.")]
    public string Telefono { get; set; } = string.Empty;

}